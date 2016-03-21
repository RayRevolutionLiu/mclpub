-- =====================
-- 2003/05/22 
--廣告落版上稿狀況查詢
-- =====================
CREATE PROCEDURE dbo.sp_c4_get_adrpublish_fileup
(
	@adr_addate CHAR(8)
)
AS
BEGIN
SET NOCOUNT ON

BEGIN DISTRIBUTED TRANSACTION myTransaction

--超複雜一把的
SELECT
	c4_adr.adr_syscd,
	c4_adr.adr_contno,
	c4_adr.adr_seq,
	CONVERT(CHAR(10), CONVERT(DATETIME, c4_adr.adr_addate, 112), 111) as adr_addate,
	adr_adcate=CASE
			WHEN adr_adcate='M' THEN '首頁'
			WHEN adr_adcate='I' THEN '內頁'
			WHEN adr_adcate='N' THEN '奈米'
			ELSE '(無定義)'
			END,
	adr_keyword=CASE
			WHEN adr_keyword='h0' THEN '正中'
			WHEN adr_keyword='h1' THEN '右一'
			WHEN adr_keyword='h2' THEN '右二'
			WHEN adr_keyword='h3' THEN '右三'
			WHEN adr_keyword='h4' THEN '右四'
			WHEN adr_keyword='w1' THEN '右文一'
			WHEN adr_keyword='w2' THEN '右文二'
			WHEN adr_keyword='w3' THEN '右文三'
			WHEN adr_keyword='w4' THEN '右文四'
			WHEN adr_keyword='w5' THEN '右文五'
			WHEN adr_keyword='w6' THEN '右文六'
			ELSE '(無定義)'
			END,
	c4_adr.adr_alttext,
	c4_adr.adr_imgurl,
	c4_adr.adr_impr,
	c4_adr.adr_navurl,
	adr_drafttp=CASE
			WHEN adr_drafttp='1' THEN '舊槁'
			WHEN adr_drafttp='2' THEN '新槁'
			WHEN adr_drafttp='3' THEN '改槁'
			ELSE '(無定義)'
			END,
	adr_urltp=CASE
			WHEN adr_urltp='1' THEN '舊槁'
			WHEN adr_urltp='2' THEN '新槁'
			WHEN adr_urltp='3' THEN '改槁'
			ELSE '(無定義)'
			END,
	c4_adr.adr_imseq,
	c4_adr.adr_remark,
	adr_fgfixad=CASE
			WHEN adr_fgfixad='1' THEN '定播'
			WHEN adr_fgfixad='0' THEN '輪播'
			ELSE '(無定義)'
			END,
	adr_fggot=CASE
			WHEN adr_fggot='1' THEN '是'
			WHEN adr_fggot='0' THEN '否'
			ELSE '(無定義)'
			END,
	c4_cont.cont_conttp,
	c4_cont.cont_empno,
	c4_cont.cont_mfrno,
	c4_cont.cont_custno,
	c4_cont.cont_aunm,
	cust.cust_nm, mfr.mfr_inm,
	invmfr.im_nm,
	srspn.srspn_cname,
	adr_adcate AS sort_adcate,
	adr_keyword AS sort_keyword
FROM
	c4_adr
INNER JOIN c4_cont ON
	c4_adr.adr_syscd = c4_cont.cont_syscd AND
        c4_adr.adr_contno = c4_cont.cont_contno
LEFT OUTER JOIN invmfr ON
	c4_adr.adr_syscd = invmfr.im_syscd AND 
	c4_adr.adr_contno = invmfr.im_contno AND 
	c4_adr.adr_imseq = invmfr.im_imseq
LEFT OUTER JOIN mfr ON
	c4_cont.cont_mfrno = mfr.mfr_mfrno
LEFT OUTER JOIN cust ON
	c4_cont.cont_custno = cust.cust_custno
LEFT OUTER JOIN srspn ON
	RTRIM(c4_cont.cont_empno) = RTRIM(srspn_empno)
WHERE
	adr_addate=@adr_addate AND
	cont_fgtemp='0' AND cont_fgcancel='0' AND cont_fgclosed='0'

-- Commit 
COMMIT TRANSACTION myTransaction

SET NOCOUNT OFF
END
GO
