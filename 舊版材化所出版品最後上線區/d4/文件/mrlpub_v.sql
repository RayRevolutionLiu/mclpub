if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_adamtlist]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_adamtlist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_admadelist]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_admadelist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_mailmnt]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_mailmnt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_pub]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_pub]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_sum_adr_amt]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_sum_adr_amt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_c4_unpub]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_c4_unpub]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.v_c4_admadelist
AS
SELECT         dbo.c4_adr.*, dbo.mfr.mfr_inm AS mfr_inm, 
                          dbo.srspn.srspn_cname AS srspn_cname, 
                          dbo.c4_cont.cont_empno AS cont_empno
FROM             dbo.c4_cont INNER JOIN
                          dbo.c4_adr ON dbo.c4_cont.cont_syscd = dbo.c4_adr.adr_syscd AND 
                          dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno INNER JOIN
                          dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN
                          dbo.srspn ON dbo.c4_cont.cont_empno = dbo.srspn.srspn_empno
WHERE         (dbo.c4_adr.adr_navurl <> '1') AND (dbo.c4_adr.adr_drafttp <> '1') AND 
                          (dbo.c4_cont.cont_fgtemp = '0') AND (dbo.c4_cont.cont_fgcancel = '0')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.v_c4_mailmnt
AS
SELECT         dbo.c4_cont.cont_contno, dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_empno, 
                          dbo.c4_cont.cont_mfrno, dbo.c4_cont.cont_fgtemp, dbo.c4_cont.cont_fgcancel, 
                          dbo.c4_freebk.fbk_bkcd, dbo.c4_ramt.ma_sdate, dbo.c4_ramt.ma_edate, 
                          dbo.c4_ramt.ma_pubmnt, dbo.c4_ramt.ma_unpubmnt, dbo.c4_ramt.ma_mtpcd, 
                          dbo.c4_or.or_fgmosea
FROM             dbo.c4_cont INNER JOIN
                          dbo.c4_freebk ON 
                          dbo.c4_cont.cont_contno = dbo.c4_freebk.fbk_contno INNER JOIN
                          dbo.c4_ramt ON dbo.c4_freebk.fbk_contno = dbo.c4_ramt.ma_contno AND 
                          dbo.c4_freebk.fbk_fbkitem = dbo.c4_ramt.ma_fbkitem INNER JOIN
                          dbo.c4_or ON dbo.c4_ramt.ma_contno = dbo.c4_or.or_contno AND 
                          dbo.c4_ramt.ma_oritem = dbo.c4_or.or_oritem

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.v_c4_pub
AS
SELECT         COUNT(*) AS pub_count, conttp, mtpcd, pubmnt, bkcd, fgmosea, empno
FROM             dbo.wk_c4_mail_mnt
WHERE         (yyyymm = '200308')
GROUP BY  conttp, mtpcd, pubmnt, bkcd, fgmosea, empno

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.v_c4_sum_adr_amt
AS
SELECT         TOP 100 PERCENT SUM(dbo.c4_adr.adr_invamt) AS sum_invamt, 
                          SUM(dbo.c4_adr.adr_adamt) AS sum_adamt, SUM(dbo.c4_adr.adr_desamt) 
                          AS sum_desamt, SUM(dbo.c4_adr.adr_chgamt) AS sum_chgamt, 
                          dbo.c4_adr.adr_contno
FROM             dbo.c4_adr INNER JOIN
                          dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND 
                          dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno
GROUP BY  dbo.c4_adr.adr_contno, dbo.c4_cont.cont_fgtemp, 
                          dbo.c4_cont.cont_fgcancel
HAVING          (dbo.c4_cont.cont_fgtemp = '0') AND (dbo.c4_cont.cont_fgcancel = '0')
ORDER BY  dbo.c4_adr.adr_contno

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.v_c4_unpub
AS
SELECT         COUNT(*) AS unpub_count, conttp, mtpcd, unpubmnt, fgmosea, empno
FROM             dbo.wk_c4_mail_mnt
WHERE         (yyyymm = '200308') AND (bkcd = '01')
GROUP BY  conttp, mtpcd, unpubmnt, fgmosea, empno

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.v_c4_adamtlist
AS
SELECT         dbo.c4_cont.cont_contno, dbo.c4_adr.adr_seq, dbo.mfr.mfr_mfrno, 
                          dbo.mfr.mfr_inm, dbo.mfr.mfr_iaddr, dbo.c4_adr.adr_addate, 
                          dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_impr, 
                          dbo.c4_adr.adr_invamt, dbo.c4_adr.adr_adamt, dbo.c4_adr.adr_desamt, 
                          dbo.c4_adr.adr_chgamt, dbo.c4_adr.adr_fginved, dbo.c4_cont.cont_empno, 
                          dbo.ia.ia_invno, dbo.ia.ia_iano
FROM             dbo.ia INNER JOIN
                          dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND 
                          dbo.ia.ia_iano = dbo.iad.iad_iano RIGHT OUTER JOIN
                          dbo.c4_cont INNER JOIN
                          dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN
                          dbo.c4_adr ON dbo.c4_cont.cont_syscd = dbo.c4_adr.adr_syscd AND 
                          dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ON 
                          dbo.iad.iad_syscd = dbo.c4_adr.adr_syscd AND 
                          dbo.iad.iad_fk1 = dbo.c4_adr.adr_contno AND 
                          dbo.iad.iad_fk2 = dbo.c4_adr.adr_addate AND 
                          dbo.iad.iad_fk3 = dbo.c4_adr.adr_seq
WHERE         (dbo.c4_cont.cont_fgtemp = '0') AND (dbo.c4_cont.cont_fgcancel = '0')

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

