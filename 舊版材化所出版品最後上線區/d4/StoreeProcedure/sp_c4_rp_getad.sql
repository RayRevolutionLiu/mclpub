/* C4�ʽZ�� ���]�t��������*/

CREATE PROC dbo.sp_c4_rp_getad
(
 @sdate  CHAR(8),	---�ʽZ�_�l���
 @edate  CHAR(8)	---�ʽZ�������
)
AS
BEGIN 
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION create_trans

/* �ثe�s���ɽZ�A�s�Z�B��Z���ƩM */
DELETE FROM wk_c4_getad_drafttp
INSERT INTO wk_c4_getad_drafttp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_syscd = dbo.c4_adr.adr_syscd ) AND  
	( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_drafttp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* �ثe�s�����Z�A�s�Z�B��Z���ƩM */
DELETE  FROM wk_c4_getad_urltp
INSERT INTO wk_c4_getad_urltp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_urltp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* �w�}�ߵo�����B, �w��SAP */
DELETE FROM wk_c4_getad_ia_amt
INSERT INTO  wk_c4_getad_ia_amt        
 SELECT substring(dbo.ia.ia_contno,3,6),   
         dbo.ia.ia_pyat  
    FROM dbo.ia  
   WHERE ( dbo.ia.ia_syscd = 'C4' ) AND  
         ( dbo.ia.ia_status = 'v' )    
/* �p��ʽZ�϶����������_�W */
DELETE FROM wk_c4_getad_adr

declare @adr_sdate char(8), @adr_edate char(8), @adr_addate char(8), @adr_count	int
declare @contno char(6)
set @adr_count=0
set @adr_sdate=''
set @adr_edate=''
DECLARE Cont_Cursor CURSOR FOR
 select cont_contno
 from c4_cont
 where ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ))
OPEN Cont_Cursor
FETCH NEXT FROM Cont_Cursor
    into @contno
WHILE @@FETCH_STATUS = 0
BEGIN
    set @adr_count=0
	set @adr_sdate=''
	set @adr_edate=''
	DECLARE Adr_Cursor CURSOR FOR
	 select adr_addate
	 from c4_adr
	 where ( ( adr_contno = @contno )
	  AND (adr_addate>=@sdate)
	  AND (adr_addate<=@edate))
	ORDER BY adr_addate
	OPEN Adr_Cursor
	FETCH NEXT FROM Adr_Cursor
		into @adr_addate
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @adr_count=0
			set @adr_sdate=@adr_addate
		set @adr_edate=@adr_addate
		set @adr_count=@adr_count+1

	    FETCH NEXT FROM Adr_Cursor
	    into @adr_addate
	END
	CLOSE Adr_Cursor
	DEALLOCATE Adr_Cursor
	INSERT INTO wk_c4_getad_adr
		values (@contno, @adr_sdate, @adr_edate, @adr_count)

    FETCH NEXT FROM Cont_Cursor
    into @contno
END
CLOSE Cont_Cursor
DEALLOCATE Cont_Cursor
/* ���ͶʽZ���� */
DELETE  FROM wk_c4_getad
/*1:�w���,������*/
INSERT INTO wk_c4_getad
SELECT
         dbo.c4_cont.cont_contno,
         dbo.c4_cont.cont_aunm,   
         dbo.mfr.mfr_inm,   
         dbo.c4_cont.cont_autel,   
         dbo.c4_cont.cont_aufax,   
         dbo.c4_cont.cont_aucell,   
         dbo.c4_cont.cont_sdate,   
         dbo.c4_cont.cont_edate,
         dbo.wk_c4_getad_adr.adr_sdate,   
         dbo.wk_c4_getad_adr.adr_edate,'',
         /* �s�i�Ѽ� */  
         dbo.wk_c4_getad_adr.tot_adr_addays,
         '','','',0,'', '', '', '', '',
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         ISNULL(dbo.wk_c4_getad_ia_amt.ia_amt, 0),   
         dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno,
         '1'	---������O
FROM dbo.c4_cont,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp,
         dbo.wk_c4_getad_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_adr.cont_contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate < @sdate ) )   
ORDER BY dbo.c4_cont.cont_contno
/*0:�����*/
INSERT INTO wk_c4_getad
SELECT
         dbo.c4_cont.cont_contno,
         dbo.c4_cont.cont_aunm,   
         dbo.mfr.mfr_inm,   
         dbo.c4_cont.cont_autel,   
         dbo.c4_cont.cont_aufax,   
         dbo.c4_cont.cont_aucell,   
         dbo.c4_cont.cont_sdate,   
         dbo.c4_cont.cont_edate,
         dbo.wk_c4_getad_adr.adr_sdate,   
         dbo.wk_c4_getad_adr.adr_edate,'',
         /* �s�i�Ѽ� */  
         dbo.wk_c4_getad_adr.tot_adr_addays,
         '','','',0,'', '', '', '', '',
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         ISNULL(dbo.wk_c4_getad_ia_amt.ia_amt, 0),   
         dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno,
         '0'
FROM dbo.c4_cont,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp ,
         dbo.wk_c4_getad_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_adr.cont_contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate >= @sdate ) )   
ORDER BY dbo.c4_cont.cont_contno
COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END
GO
