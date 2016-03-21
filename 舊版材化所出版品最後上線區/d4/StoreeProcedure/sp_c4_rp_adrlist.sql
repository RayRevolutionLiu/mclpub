/* C4廣告落版統計表*/

CREATE PROC dbo.sp_c4_rp_adrlist
(
 @sdate  CHAR(8),	---廣告起始日期
 @edate  CHAR(8)	---廣告結束日期
)
AS
BEGIN 
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION create_trans

/* 目前製圖檔稿，新稿、改稿次數和 */
DELETE FROM wk_c4_getad_drafttp
INSERT INTO wk_c4_getad_drafttp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_syscd = dbo.c4_adr.adr_syscd ) AND  
	( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_drafttp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 目前製網頁稿，新稿、改稿次數和 */
DELETE FROM wk_c4_getad_urltp
INSERT INTO wk_c4_getad_urltp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_urltp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 計算區間中之落版起訖 */
DELETE FROM wk_c4_adrlist_adr

declare @adr_sdate char(8), @adr_edate char(8), @adr_addate char(8), @adr_count	int
declare @contno char(6), @seq char(2), @fgfixad char(1)
declare @adcate_M_count int, @adcate_I_count int, @adcate_N_count int
declare @adr_adcate char(1), @adr_impr int
declare @sum_adamt int, @sum_desamt int, @sum_chgamt int
declare @adr_adamt int, @adr_desamt int, @adr_chgamt int
set @adr_count=0
set @adr_sdate=''
set @adr_edate=''
set @adcate_M_count = 0
set @adcate_I_count = 0
set @adcate_N_count = 0
set @sum_adamt = 0
set @sum_desamt = 0
set @sum_chgamt = 0
DECLARE Cont_Cursor CURSOR FOR
SELECT DISTINCT c4_adr.adr_seq, c4_cont.cont_contno, c4_adr.adr_fgfixad
FROM c4_cont INNER JOIN
     c4_adr ON c4_cont.cont_contno = c4_adr.adr_contno
WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '0')
ORDER BY  c4_cont.cont_contno
OPEN Cont_Cursor
FETCH NEXT FROM Cont_Cursor
    into @seq, @contno, @fgfixad
WHILE @@FETCH_STATUS = 0
BEGIN
    set @adr_count=0
	set @adr_sdate=''
	set @adr_edate=''
	set @adcate_M_count = 0
	set @adcate_I_count = 0
	set @adcate_N_count = 0
	set @sum_adamt = 0
	set @sum_desamt = 0
	set @sum_chgamt = 0
	DECLARE Adr_Cursor CURSOR FOR
	 select adr_addate, adr_adcate, adr_impr, adr_adamt, adr_desamt, adr_chgamt
	 from c4_adr
	 where ( ( adr_contno = @contno )
	  AND (adr_seq = @seq)
	  AND (adr_addate>=@sdate)
	  AND (adr_addate<=@edate))
	ORDER BY adr_addate
	OPEN Adr_Cursor
	FETCH NEXT FROM Adr_Cursor
		into @adr_addate, @adr_adcate, @adr_impr, @adr_adamt, @adr_desamt, @adr_chgamt
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @adr_count=0
		  begin
			set @adr_sdate=@adr_addate
		  end
		set @adr_edate=@adr_addate
		set @adr_count=@adr_count+1
		if @adr_adcate = 'M'
		  begin
			set @adcate_M_count = @adcate_M_count + 1
		  end
		if @adr_adcate = 'I'
		  begin
			set @adcate_I_count = @adcate_I_count + 1
		  end
		if @adr_adcate = 'N'
		  begin
			set @adcate_N_count = @adcate_N_count + 1
		  end
		set @sum_adamt = @sum_adamt + @adr_adamt
		set @sum_desamt = @sum_desamt + @adr_desamt
		set @sum_chgamt = @sum_chgamt + @adr_chgamt
		  
	    FETCH NEXT FROM Adr_Cursor
	    into @adr_addate, @adr_adcate, @adr_impr, @adr_adamt, @adr_desamt, @adr_chgamt
	END
	CLOSE Adr_Cursor
	DEALLOCATE Adr_Cursor
	INSERT INTO wk_c4_adrlist_adr
		values (@contno, @seq, @adr_sdate, @adr_edate, @adr_count, 
		@adcate_M_count, @adcate_I_count, @adcate_N_count, @fgfixad, 
		@sum_adamt, @sum_desamt, @sum_chgamt)

    FETCH NEXT FROM Cont_Cursor
    into @seq, @contno, @fgfixad
END
CLOSE Cont_Cursor
DEALLOCATE Cont_Cursor
/* 產生統計表資料 */
DELETE  FROM wk_c4_adrlist
INSERT INTO wk_c4_adrlist
SELECT
         dbo.c4_cont.cont_contno,
         dbo.wk_c4_adrlist_adr.adr_seq,
         dbo.mfr.mfr_inm,   
         dbo.wk_c4_adrlist_adr.adr_sdate,   
         dbo.wk_c4_adrlist_adr.adr_edate,
         /* 廣告天數 */  
         dbo.wk_c4_adrlist_adr.tot_adr_addays,
         /* 各版面落版次數 */
         dbo.wk_c4_adrlist_adr.adr_adcate_M,
         dbo.wk_c4_adrlist_adr.adr_adcate_I,
         dbo.wk_c4_adrlist_adr.adr_adcate_N,
         dbo.wk_c4_adrlist_adr.adr_fgfixad,
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_resttm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,
         ISNULL(dbo.wk_c4_adrlist_adr.sum_adamt, 0),
         ISNULL(dbo.wk_c4_adrlist_adr.sum_desamt, 0),
         ISNULL(dbo.wk_c4_adrlist_adr.sum_chgamt, 0),
         dbo.c4_cont.cont_totamt,
         dbo.c4_cont.cont_empno,
         dbo.c4_cont.cont_remark
FROM dbo.c4_cont,   
         dbo.mfr,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp,
         dbo.wk_c4_adrlist_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno = dbo.wk_c4_adrlist_adr.cont_contno ) AND  
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' )  
ORDER BY dbo.c4_cont.cont_contno

COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END
GO
