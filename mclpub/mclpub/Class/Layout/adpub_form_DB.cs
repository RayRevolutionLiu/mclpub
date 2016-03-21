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
    public class adpub_form_DB
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

        public DataSet Selectc2_pub(string yyyyymm, string bkcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 100 PERCENT 0 AS ItemNo, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_pubseq,");
            sb.Append(@" dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_ltpcd");
            sb.Append(@", CASE WHEN pub_fgfixpg = '0' THEN '否' ELSE '是' END AS pub_fgfixpg, CASE WHEN pub_fggot = '0' THEN '否' ELSE '是' END AS pub_fggot, dbo.c2_pub.pub_modempno, ");
            sb.Append(@"dbo.c2_pub.pub_remark, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno,");
            sb.Append(@" dbo.c2_pub.pub_origjbkno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno");
            sb.Append(@", CASE WHEN pub_fgrechg = '0' THEN '否' ELSE '是' END AS pub_fgrechg, dbo.c2_pub.pub_njtpcd, RTRIM(dbo.mfr.mfr_inm) ");
            sb.Append(@"AS mfr_inm, dbo.c2_pub.pub_bkcd, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm,");
            sb.Append(@" RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm, RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp");
            sb.Append(@".njtp_nm) AS njtp_nm, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cnam");
            sb.Append(@"e) AS srspn_cname, dbo.c2_pub.pub_drafttp, dbo.c2_pub.pub_syscd,");
            sb.Append(@" dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_fgupdated, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_bk");
            sb.Append(@"cd, dbo.c2_pub.pub_njtpcd + ' ' + dbo.c2_njtp.njtp_nm AS nostr FROM dbo.c2_pub ");
            sb.Append(@"INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo");
            sb.Append(@".c2_pub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno");
            sb.Append(@" = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = ");
            sb.Append(@"dbo.c2_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.");
            sb.Append(@"c2_pub.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd");
            sb.Append(@" LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_cl");
            sb.Append(@"rcd LEFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pg");
            sb.Append(@"scd LEFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT");
            sb.Append(@" OUTER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT");
            sb.Append(@" OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER ");
            sb.Append(@"JOIN dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno WHERE ");
            sb.Append(@"(dbo.c2_pub.pub_yyyymm = @yyyymm) AND (dbo.c2_pub.pub_bkcd = @bkcd) AND (dbo.c2_cont.cont_fgtemp");
            sb.Append(@" = '0') AND (dbo.c2_cont.cont_fgpubed = '1')  AND (dbo.c2_cont.cont_fgclosed = '0')  AND (dbo.c2_cont.cont_fgcancel = '0') ORDER BY dbo.c2_lprior.lp_priorseq");
            sb.Append(@", dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm DESC, ");
            sb.Append(@"dbo.c2_pub.pub_pubseq");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyyymm);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet SelectBookExport(string pub_chgbkcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM book WHERE bk_bkcd=@pub_chgbkcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pub_chgbkcd", pub_chgbkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}