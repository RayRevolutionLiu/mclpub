using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
namespace mclpub
{
    public class adpub_list_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = '')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_empno) AS srspn_empno, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date FROM dbo.srspn WHERE (srspn_atype <> 'A') AND (srspn_atype <> 'F')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub(string yyyymm, string bkcd, string strEmpNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 100 PERCENT 0 AS ItemNo, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_pubseq,");
            sb.Append(@" dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_ltpcd, CASE WHEN pub_fgfixpg = '0' THEN '否' ELSE '是' END AS pub_fgfixpg, CASE WHEN pub_fggot = '0' THEN '否' ELSE '是' END AS pub_fggot, dbo.c2_pub.pub_modempno, ");
            sb.Append(@"dbo.c2_pub.pub_remark, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pub_origjbkno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno,");
            sb.Append(@" dbo.c2_pub.pub_chgjbkno, CASE WHEN pub_fgrechg = '0' THEN '否' ELSE '是' END AS pub_fgrechg, dbo.c2_pub.pub_njtpcd, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.c2_pub.pub_bkcd, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm,");
            sb.Append(@" RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm, RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm, RTRIM(dbo.book.bk_nm) AS bk_nm");
            sb.Append(@", RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.c2_pub.pub_drafttp, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_fgupdated, dbo.c2_lprior.lp_priorseq");
            sb.Append(@", dbo.c2_lprior.lp_bkcd, dbo.c2_pub.pub_njtpcd + ' ' + dbo.c2_njtp.njtp_nm AS nostr, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, c2_pub.pub_adamt,c2_pub.pub_chgamt, c2_pub.pub_fginved,iad.iad_iano, ia.ia_invno FROM dbo.c2_pub INNER ");
            sb.Append(@"JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno");
            sb.Append(@" = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND");
            sb.Append(@" dbo.c2_pub.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd ");
            sb.Append(@"LEFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT ");
            sb.Append(@"OUTER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN ");
            sb.Append(@"dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno LEFT OUTER JOIN iad INNER JOIN ia ON iad.iad_syscd = ia.ia_syscd AND iad.iad_iano = ia.ia_iano ON c2_pub.pub_syscd = iad.iad_syscd AND c2_pub.pub_contno = iad.iad_fk1 AND c2_pub.pub_yyyymm = iad.iad_fk2 AND c2_pub.pub_pubseq = iad.iad_fk3 ");
            sb.Append(@"WHERE (dbo.c2_pub.pub_yyyymm = @yyyymm) AND (dbo.c2_pub.pub_bkcd = @bkcd) AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1') ");
            if (strEmpNo.ToString().Trim() != "")
            {
                sb.Append(@"AND cont_empno=@strEmpNo ");
            }
            sb.Append(@"ORDER BY dbo.c2_lprior.lp_priorseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm DESC, dbo.c2_pub.pub_pubseq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@strEmpNo", strEmpNo);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectbookp(string yyyymm, string bkcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bkp_pno FROM bookp WHERE (bkp_date = @yyyymm) AND (bkp_bkcd = @bkcd) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}