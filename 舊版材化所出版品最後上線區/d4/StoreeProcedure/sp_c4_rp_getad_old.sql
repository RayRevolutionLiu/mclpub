/* C4�ʽZ�� */
/* �ʽZ��W�h�G���]�ʽZ�~�묰@yyyymm�A�ʽZ��ƳW�h��
1. �����ץB�X���w����Gcont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)<@yyyymm
2. �����ץB�X��������Gcont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)=@yyyymm
3. �����ץB�X���Y�N����Gcont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)=@yyyymm+1�]�[����A�O���~���D�^
4. �����ץB������Gcont_fgclosed='0' AND SUBSTRING(cont_edate, 1, 6)>@yyyymm+1�]�[����A�O���~���D�^
�Ѧ��G
���p1�A��뤣�|���s�i
���p2�B3���i�঳�s�i�A�]�i��S���s�i�A��ƥH�����B��m���Ƨ�
���p2����ƭn���S�Omark(*)
���p4�A�]�O���i�঳�s�i�A�]�i��S��
�t�~�A�H�}�ߵo�����B�O�H�G�w�g�}�ߵo���}�߲M��Y�p��
*/
CREATE PROC dbo.sp_c4_rp_getad(@yyyymm  CHAR(6) )
AS
BEGIN 
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION create_trans
/*   ���նʽZ�~�묰200210
DECLARE  @yyyymm CHAR(6)
SELECT @yyyymm = '200210'
*/
/* �ʽZ�몺�U�@�Ӥ� */
DECLARE @next_yyyymm  CHAR(6)
SELECT @next_yyyymm = 
	CASE    
                	WHEN SUBSTRING(@yyyymm,5,2) <= '11'  THEN ( SUBSTRING(@yyyymm,1,4) + CONVERT(CHAR(2), CONVERT(INT, SUBSTRING(@yyyymm, 5, 2)+1)))
		ELSE (CONVERT(CHAR(4), CONVERT(INT, SUBSTRING(@yyyymm,1,4))+1) + '01')
	END
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
/* �w�}�ߵo�����B */
DELETE FROM wk_c4_getad_ia_amt
INSERT INTO  wk_c4_getad_ia_amt        
 SELECT substring(dbo.ia.ia_contno,3,6),   
         dbo.ia.ia_pyat  
    FROM dbo.ia  
   WHERE ( dbo.ia.ia_syscd = 'C4' ) AND  
         ( dbo.ia.ia_status = 'v' )    
/* ���ͶʽZ���� */
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
         /* �s�i�Ѽ� */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*�s�i����
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '����'
	    WHEN adr_adcate='I' THEN '����'
	    WHEN adr_adcate='N' THEN '�`��'
	    ELSE ''
	END,
         /*�s�i��m   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '����'
	    WHEN adr_keyword='h1' THEN '�k�@'
	    WHEN adr_keyword='h2' THEN '�k�G'
	    WHEN adr_keyword='h3' THEN '�k�T'
	    WHEN adr_keyword='h4' THEN '�k�|'
	    WHEN adr_keyword='w1' THEN '��@'
	    WHEN adr_keyword='w2' THEN '��G'
	    WHEN adr_keyword='w3' THEN '��T'
	    WHEN adr_keyword='w4' THEN '��|'
	    WHEN adr_keyword='w5' THEN '�夭'
	    WHEN adr_keyword='w6' THEN '�夻'
	    ELSE ''
	END,
         /* ��Z���O   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '����'
	    WHEN adr_fgfixad='1' THEN '�w��'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* ���ɽZ���O   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '�½Z'
	    WHEN adr_drafttp='2' THEN '�s�Z'
	    WHEN adr_drafttp='3' THEN '��Z'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* ��Z   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '�O'
	    WHEN adr_fggot='0' THEN '�_'
	    ELSE ''
	END,
         /* �����Z���O
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '�½Z'
	    WHEN adr_urltp='2' THEN '�s�Z'
	    WHEN adr_urltp='3' THEN '��Z'
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
         /* �s�i�Ѽ� */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*�s�i����
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '����'
	    WHEN adr_adcate='I' THEN '����'
	    WHEN adr_adcate='N' THEN '�`��'
	    ELSE ''
	END,
         /*�s�i��m   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '����'
	    WHEN adr_keyword='h1' THEN '�k�@'
	    WHEN adr_keyword='h2' THEN '�k�G'
	    WHEN adr_keyword='h3' THEN '�k�T'
	    WHEN adr_keyword='h4' THEN '�k�|'
	    WHEN adr_keyword='w1' THEN '��@'
	    WHEN adr_keyword='w2' THEN '��G'
	    WHEN adr_keyword='w3' THEN '��T'
	    WHEN adr_keyword='w4' THEN '��|'
	    WHEN adr_keyword='w5' THEN '�夭'
	    WHEN adr_keyword='w6' THEN '�夻'
	    ELSE ''
	END,
         /* ��Z���O   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '����'
	    WHEN adr_fgfixad='1' THEN '�w��'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* ���ɽZ���O   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '�½Z'
	    WHEN adr_drafttp='2' THEN '�s�Z'
	    WHEN adr_drafttp='3' THEN '��Z'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* ��Z   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '�O'
	    WHEN adr_fggot='0' THEN '�_'
	    ELSE ''
	END,
         /* �����Z���O
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '�½Z'
	    WHEN adr_urltp='2' THEN '�s�Z'
	    WHEN adr_urltp='3' THEN '��Z'
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
         /* �s�i�Ѽ� */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*�s�i����
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '����'
	    WHEN adr_adcate='I' THEN '����'
	    WHEN adr_adcate='N' THEN '�`��'
	    ELSE ''
	END,
         /*�s�i��m   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '����'
	    WHEN adr_keyword='h1' THEN '�k�@'
	    WHEN adr_keyword='h2' THEN '�k�G'
	    WHEN adr_keyword='h3' THEN '�k�T'
	    WHEN adr_keyword='h4' THEN '�k�|'
	    WHEN adr_keyword='w1' THEN '��@'
	    WHEN adr_keyword='w2' THEN '��G'
	    WHEN adr_keyword='w3' THEN '��T'
	    WHEN adr_keyword='w4' THEN '��|'
	    WHEN adr_keyword='w5' THEN '�夭'
	    WHEN adr_keyword='w6' THEN '�夻'
	    ELSE ''
	END,
         /* ��Z���O   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '����'
	    WHEN adr_fgfixad='1' THEN '�w��'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* ���ɽZ���O   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '�½Z'
	    WHEN adr_drafttp='2' THEN '�s�Z'
	    WHEN adr_drafttp='3' THEN '��Z'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* ��Z   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '�O'
	    WHEN adr_fggot='0' THEN '�_'
	    ELSE ''
	END,
         /* �����Z���O
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '�½Z'
	    WHEN adr_urltp='2' THEN '�s�Z'
	    WHEN adr_urltp='3' THEN '��Z'
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
         /* �s�i�Ѽ� */  
         tot_adr_addays=
	CASE
	    WHEN adr_sdate IS NULL OR adr_edate IS NULL THEN 0
	    ELSE DATEDIFF(DAY, CONVERT(DATETIME, adr_sdate, 112), CONVERT(DATETIME, adr_edate, 112))+1
	END,   
         /*�s�i����
         dbo.c4_adr.adr_adcate,
        */
         s_adr_adcate =
	CASE
	    WHEN adr_adcate='M' THEN '����'
	    WHEN adr_adcate='I' THEN '����'
	    WHEN adr_adcate='N' THEN '�`��'
	    ELSE ''
	END,
         /*�s�i��m   
         dbo.c4_adr.adr_keyword,
        */
        s_adr_keyword = 
	CASE
	    WHEN adr_keyword='h0' THEN '����'
	    WHEN adr_keyword='h1' THEN '�k�@'
	    WHEN adr_keyword='h2' THEN '�k�G'
	    WHEN adr_keyword='h3' THEN '�k�T'
	    WHEN adr_keyword='h4' THEN '�k�|'
	    WHEN adr_keyword='w1' THEN '��@'
	    WHEN adr_keyword='w2' THEN '��G'
	    WHEN adr_keyword='w3' THEN '��T'
	    WHEN adr_keyword='w4' THEN '��|'
	    WHEN adr_keyword='w5' THEN '�夭'
	    WHEN adr_keyword='w6' THEN '�夻'
	    ELSE ''
	END,
         /* ��Z���O   
         dbo.c4_adr.adr_fgfixad,
         */
         s_adr_fgfixad = 
	CASE
	    WHEN adr_fgfixad='0' THEN '����'
	    WHEN adr_fgfixad='1' THEN '�w��'
	    WHEN adr_fgfixad IS NULL THEN ''
	END,
         dbo.c4_adr.adr_impr,
         /* ���ɽZ���O   
         dbo.c4_adr.adr_drafttp,
         */
         s_adr_drafttp=
	CASE
	    WHEN adr_drafttp='1' THEN '�½Z'
	    WHEN adr_drafttp='2' THEN '�s�Z'
	    WHEN adr_drafttp='3' THEN '��Z'
	    ELSE ''
	END,
         dbo.c4_adr.adr_imgurl,
         /* ��Z   
         dbo.c4_adr.adr_fggot,   
         */
	s_adr_fggot=
	CASE
	    WHEN adr_fggot='1' THEN '�O'
	    WHEN adr_fggot='0' THEN '�_'
	    ELSE ''
	END,
         /* �����Z���O
         dbo.c4_adr.adr_urltp,   
         */
	s_adr_utltp =
	CASE
	    WHEN adr_urltp='1' THEN '�½Z'
	    WHEN adr_urltp='2' THEN '�s�Z'
	    WHEN adr_urltp='3' THEN '��Z'
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
