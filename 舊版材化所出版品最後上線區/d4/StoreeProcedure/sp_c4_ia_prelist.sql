-- =====================
-- 2003/09/01 
-- 單一合約單一發票廠商
-- 發票開立預覽清單
-- =====================
CREATE PROCEDURE dbo.sp_c4_ia_prelist
(
	@contno CHAR(6),
	@imseq	CHAR(2)
)
AS
BEGIN
SET NOCOUNT ON

BEGIN DISTRIBUTED TRANSACTION myTransaction
DELETE wk_c4_ia_prelist
INSERT INTO wk_c4_ia_prelist
SELECT         c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_custno, cust.cust_nm, 
                          c4_cont.cont_mfrno, ISNULL(mfr_1.mfr_inm, '') AS cont_mfr_inm, 
                          c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, 
                          srspn.srspn_cname, c4_cont.cont_totamt, invmfr.im_nm, invmfr.im_mfrno, 
                          ISNULL(mfr_2.mfr_inm, '') AS im_mfr_inm, invmfr.im_zip, invmfr.im_addr, 
                          invmfr.im_invcd, invmfr.im_taxtp, invmfr.im_fgitri, c4_adr.adr_addate, 
                          c4_adr.adr_seq, c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, 
                          c4_adr.adr_chgamt, c4_adr.adr_imseq 
FROM             srspn INNER JOIN
                          c4_cont INNER JOIN
                          mfr mfr_1 ON c4_cont.cont_mfrno = mfr_1.mfr_mfrno ON 
                          srspn.srspn_empno = c4_cont.cont_empno INNER JOIN
                          cust ON c4_cont.cont_custno = cust.cust_custno RIGHT OUTER JOIN
                          mfr mfr_2 RIGHT OUTER JOIN
                          c4_adr INNER JOIN
                          invmfr ON c4_adr.adr_syscd = invmfr.im_syscd AND 
                          c4_adr.adr_contno = invmfr.im_contno AND 
                          c4_adr.adr_imseq = invmfr.im_imseq ON mfr_2.mfr_mfrno = invmfr.im_mfrno ON
                           c4_cont.cont_syscd = c4_adr.adr_syscd AND 
                          c4_cont.cont_contno = c4_adr.adr_contno
WHERE         (c4_cont.cont_contno = @contno) AND (c4_adr.adr_imseq = @imseq) AND (c4_adr.adr_fginved = 'v')

-- Commit 
COMMIT TRANSACTION myTransaction

SET NOCOUNT OFF
END
GO
