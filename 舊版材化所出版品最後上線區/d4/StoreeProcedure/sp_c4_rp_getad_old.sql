/* C4催稿單 */
/* 催稿單規則：假設催稿年月為@yyyymm，催稿資料規則為
1. 未結案且合約已到期：cont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)<@yyyymm
2. 未結案且合約當月到期：cont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)=@yyyymm
3. 未結案且合約即將到期：cont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)=@yyyymm+1（加月份，記住跨年問題）
4. 未結案且未到期：cont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)>@yyyymm+1（加月份，記住跨年問題）
由此：
情況1，當月不會有廣告
情況2、3當月可能有廣告，也可能沒有廣告，資料以版面、位置做排序
情況2的資料要做特別mark(*)
情況4，也是當月可能有廣告，也可能沒有
另外，以開立發票金額是以：已經開立發票開立清單即計算
*/
CREATE PROC dbo.sp_c4_rp_getad(@yyyymm  CHAR(6) )
AS
BEGIN 
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION create_trans
/*   測試催稿年月為200210
DECLARE  @yyyymm CHAR(6)
SELECT @yyyymm = '200210'
*/
/* 催稿月的下一個月 */
DECLARE @next_yyyymm  CHAR(6)
SELECT @next_yyyymm = 
	CASE    
                	WHEN SUBSTRING(@yyyymm,5,2) <= '11'  THEN ( SUBSTRING(@yyyymm,1,4) + CONVERT(CHAR(2), CONVERT(INT, SUBSTRING(@yyyymm, 5, 2)+1)))
		ELSE (CONVERT(CHAR(4), CONVERT(INT, SUBSTRING(@yyyymm,1,4))+1) + '01')
	END
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
DELETE  FROM wk_c4_getad_urltp
INSERT INTO wk_c4_getad_urltp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_urltp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 已開立發票金額 */
DELETE FROM wk_c4_getad_ia_amt
INSERT INTO  wk_c4_getad_ia_amt        
 SELECT substring(dbo.ia.ia_contno,3,6),   
         dbo.ia.ia_pyat  
    FROM dbo.ia  
   WHERE ( dbo.ia.ia_syscd = 'C4' ) AND  
         ( dbo.ia.ia_status = 'v' )    
/* 產生催稿單資料 */
DELETE  FROM wk_c4_getad
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
         dbo.c4_adr.adr_sdate,   
         dbo.c4_adr.adr_edate,
         /* 廣告天數 */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*廣告頁面
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '首頁'
	    WHEN adr_adcate='I' THEN '內頁'
	    WHEN adr_adcate='N' THEN '奈米'
	    ELSE ''
	END,
         /*廣告位置   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '正中'
	    WHEN adr_keyword='h1' THEN '右一'
	    WHEN adr_keyword='h2' THEN '右二'
	    WHEN adr_keyword='h3' THEN '右三'
	    WHEN adr_keyword='h4' THEN '右四'
	    WHEN adr_keyword='w1' THEN '文一'
	    WHEN adr_keyword='w2' THEN '文二'
	    WHEN adr_keyword='w3' THEN '文三'
	    WHEN adr_keyword='w4' THEN '文四'
	    WHEN adr_keyword='w5' THEN '文五'
	    WHEN adr_keyword='w6' THEN '文六'
	    ELSE ''
	END,
         /* 到稿註記   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '輪播'
	    WHEN adr_fgfixad='1' THEN '定播'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* 圖檔稿類別   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '舊稿'
	    WHEN adr_drafttp='2' THEN '新稿'
	    WHEN adr_drafttp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* 到稿   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '是'
	    WHEN adr_fggot='0' THEN '否'
	    ELSE ''
	END,
         /* 網頁稿類別
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '舊稿'
	    WHEN adr_urltp='2' THEN '新稿'
	    WHEN adr_urltp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_navurl,   
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - dbo.wk_c4_getad_drafttp.drafttp_cnt) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - dbo.wk_c4_getad_urltp.urltp_cnt) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         dbo.wk_c4_getad_ia_amt.ia_amt,   
         dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno
FROM dbo.c4_cont,   
         dbo.c4_adr,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp  
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_syscd *= dbo.c4_adr.adr_syscd ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.c4_adr.adr_contno ) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate < @yyyymm ) )   
ORDER BY dbo.c4_cont.cont_edate ASC,   
         dbo.c4_adr.adr_adcate ASC,   
         dbo.c4_adr.adr_keyword ASC  
/*2*/
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
         dbo.c4_adr.adr_sdate,   
         dbo.c4_adr.adr_edate,
         /* 廣告天數 */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*廣告頁面
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '首頁'
	    WHEN adr_adcate='I' THEN '內頁'
	    WHEN adr_adcate='N' THEN '奈米'
	    ELSE ''
	END,
         /*廣告位置   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '正中'
	    WHEN adr_keyword='h1' THEN '右一'
	    WHEN adr_keyword='h2' THEN '右二'
	    WHEN adr_keyword='h3' THEN '右三'
	    WHEN adr_keyword='h4' THEN '右四'
	    WHEN adr_keyword='w1' THEN '文一'
	    WHEN adr_keyword='w2' THEN '文二'
	    WHEN adr_keyword='w3' THEN '文三'
	    WHEN adr_keyword='w4' THEN '文四'
	    WHEN adr_keyword='w5' THEN '文五'
	    WHEN adr_keyword='w6' THEN '文六'
	    ELSE ''
	END,
         /* 到稿註記   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '輪播'
	    WHEN adr_fgfixad='1' THEN '定播'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* 圖檔稿類別   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '舊稿'
	    WHEN adr_drafttp='2' THEN '新稿'
	    WHEN adr_drafttp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* 到稿   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '是'
	    WHEN adr_fggot='0' THEN '否'
	    ELSE ''
	END,
         /* 網頁稿類別
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '舊稿'
	    WHEN adr_urltp='2' THEN '新稿'
	    WHEN adr_urltp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_navurl,   
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - dbo.wk_c4_getad_drafttp.drafttp_cnt) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - dbo.wk_c4_getad_urltp.urltp_cnt) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         dbo.wk_c4_getad_ia_amt.ia_amt,   
         dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno
FROM dbo.c4_cont,   
         dbo.c4_adr,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp  
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_syscd *= dbo.c4_adr.adr_syscd ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.c4_adr.adr_contno ) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate = @yyyymm ) )   
ORDER BY dbo.c4_cont.cont_edate ASC,   
         dbo.c4_adr.adr_adcate ASC,   
         dbo.c4_adr.adr_keyword ASC   
/*3*/
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
         dbo.c4_adr.adr_sdate,   
         dbo.c4_adr.adr_edate,
         /* 廣告天數 */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*廣告頁面
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '首頁'
	    WHEN adr_adcate='I' THEN '內頁'
	    WHEN adr_adcate='N' THEN '奈米'
	    ELSE ''
	END,
         /*廣告位置   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '正中'
	    WHEN adr_keyword='h1' THEN '右一'
	    WHEN adr_keyword='h2' THEN '右二'
	    WHEN adr_keyword='h3' THEN '右三'
	    WHEN adr_keyword='h4' THEN '右四'
	    WHEN adr_keyword='w1' THEN '文一'
	    WHEN adr_keyword='w2' THEN '文二'
	    WHEN adr_keyword='w3' THEN '文三'
	    WHEN adr_keyword='w4' THEN '文四'
	    WHEN adr_keyword='w5' THEN '文五'
	    WHEN adr_keyword='w6' THEN '文六'
	    ELSE ''
	END,
         /* 到稿註記   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '輪播'
	    WHEN adr_fgfixad='1' THEN '定播'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* 圖檔稿類別   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '舊稿'
	    WHEN adr_drafttp='2' THEN '新稿'
	    WHEN adr_drafttp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* 到稿   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '是'
	    WHEN adr_fggot='0' THEN '否'
	    ELSE ''
	END,
         /* 網頁稿類別
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '舊稿'
	    WHEN adr_urltp='2' THEN '新稿'
	    WHEN adr_urltp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_navurl,   
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - dbo.wk_c4_getad_drafttp.drafttp_cnt) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - dbo.wk_c4_getad_urltp.urltp_cnt) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         dbo.wk_c4_getad_ia_amt.ia_amt,   
         dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno
FROM dbo.c4_cont,   
         dbo.c4_adr,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp  
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_syscd *= dbo.c4_adr.adr_syscd ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.c4_adr.adr_contno ) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate = @next_yyyymm ) )   
ORDER BY dbo.c4_cont.cont_edate ASC,   
         dbo.c4_adr.adr_adcate ASC,   
         dbo.c4_adr.adr_keyword ASC
/*4*/
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
         dbo.c4_adr.adr_sdate,   
         dbo.c4_adr.adr_edate,
         /* 廣告天數 */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*廣告頁面
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '首頁'
	    WHEN adr_adcate='I' THEN '內頁'
	    WHEN adr_adcate='N' THEN '奈米'
	    ELSE ''
	END,
         /*廣告位置   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '正中'
	    WHEN adr_keyword='h1' THEN '右一'
	    WHEN adr_keyword='h2' THEN '右二'
	    WHEN adr_keyword='h3' THEN '右三'
	    WHEN adr_keyword='h4' THEN '右四'
	    WHEN adr_keyword='w1' THEN '文一'
	    WHEN adr_keyword='w2' THEN '文二'
	    WHEN adr_keyword='w3' THEN '文三'
	    WHEN adr_keyword='w4' THEN '文四'
	    WHEN adr_keyword='w5' THEN '文五'
	    WHEN adr_keyword='w6' THEN '文六'
	    ELSE ''
	END,
         /* 到稿註記   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '輪播'
	    WHEN adr_fgfixad='1' THEN '定播'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* 圖檔稿類別   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '舊稿'
	    WHEN adr_drafttp='2' THEN '新稿'
	    WHEN adr_drafttp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* 到稿   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '是'
	    WHEN adr_fggot='0' THEN '否'
	    ELSE ''
	END,
         /* 網頁稿類別
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '舊稿'
	    WHEN adr_urltp='2' THEN '新稿'
	    WHEN adr_urltp='3' THEN '改稿'
	    ELSE ''
	END,
         dbo.c4_adr.adr_navurl,   
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - dbo.wk_c4_getad_drafttp.drafttp_cnt) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - dbo.wk_c4_getad_urltp.urltp_cnt) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         dbo.wk_c4_getad_ia_amt.ia_amt,   
         dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno
FROM dbo.c4_cont,   
         dbo.c4_adr,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp  
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_syscd *= dbo.c4_adr.adr_syscd ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.c4_adr.adr_contno ) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate > @next_yyyymm ) )   
ORDER BY dbo.c4_cont.cont_edate ASC,   
         dbo.c4_adr.adr_adcate ASC,   
         dbo.c4_adr.adr_keyword ASC    
COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END

GO
