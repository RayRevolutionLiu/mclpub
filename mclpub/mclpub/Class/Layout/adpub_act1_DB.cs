using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace mclpub
{
    public class adpub_act1_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "book");
            return ds;
        }


        public DataSet SelectC2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_pgno, dbo.c2_lprior.lp_priorseq, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_drafttp, dbo.c2_pub.pub_imseq, dbo.c2_pub.pub_fgfixpg, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, dbo.c2_lprior.lp_bkcd, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno LEFT OUTER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pub.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd WHERE (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pub");
            return ds;
        }


        public DataSet SelectC2_pub2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_pub.pub_pgno AS PageNo, RTRIM(dbo.c2_pub.pub_contno) AS pub_contno,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_pubseq) AS pub_pubseq, RTRIM(dbo.c2_pub.pub_yyyymm) AS pub_yyyymm,");
            sb.Append(@"dbo.c2_pub.pub_pgno AS pub_pgno, RTRIM(dbo.c2_pub.pub_ltpcd) AS pub_ltpcd,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_clrcd) AS pub_clrcd, RTRIM(dbo.c2_pub.pub_pgscd) AS pub_pgscd,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_fgfixpg) AS pub_fgfixpg, RTRIM(dbo.c2_pub.pub_fggot) AS pub_fggot,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_modempno) AS pub_modempno, RTRIM(dbo.c2_pub.pub_remark) AS pub_remark,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_origbkcd) AS pub_origbkcd, RTRIM(dbo.c2_pub.pub_origjno) AS pub_origjno,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_origjbkno) AS pub_origjbkno, RTRIM(dbo.c2_pub.pub_chgbkcd) AS pub_chgbkcd,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_chgjno) AS pub_chgjno, RTRIM(dbo.c2_pub.pub_chgjbkno) AS pub_chgjbkno,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_fgrechg) AS pub_fgrechg, RTRIM(dbo.c2_pub.pub_njtpcd) AS pub_njtpcd,");
            sb.Append(@"RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, 8 AS layout2, RTRIM(dbo.c2_pub.pub_bkcd) AS pub_bkcd,");
            sb.Append(@"RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm,");
            sb.Append(@"RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm,");
            sb.Append(@"RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname,");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_drafttp) AS pub_drafttp, dbo.c2_pub.pub_contno AS pub_contno,");
            sb.Append(@"dbo.c2_pub.pub_pubseq AS pub_pubseq, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm ");
            sb.Append(@"AS pub_yyyymm, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_bkcd, dbo.c2_cont.cont_fgclosed,");
            sb.Append(@" dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed,");
            sb.Append(@" dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.c2_pub INNER");
            sb.Append(@" JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND ");
            sb.Append(@"dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON ");
            sb.Append(@"dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_lprior ON ");
            sb.Append(@"dbo.c2_pub.pub_ltpcd = dbo.c2_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd ");
            sb.Append(@"AND dbo.c2_pub.pub_pgscd = dbo.c2_lprior.lp_pgscd AND ");
            sb.Append(@"dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd LEFT OUTER JOIN dbo.c2_clr ");
            sb.Append(@"ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize ON ");
            sb.Append(@"dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = ");
            sb.Append(@"dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd ");
            sb.Append(@"LEFT OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN dbo.srspn ON ");
            sb.Append(@" dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgtemp = '0') AND ");
            sb.Append(@" (dbo.c2_cont.cont_fgpubed = '1') ORDER BY dbo.c2_lprior.lp_priorseq, dbo.c2_pub.pub_pgno, ");
            sb.Append(@" dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pub");
            return ds;
        }


        public DataSet SelectC2_ltp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ltp_ltpcd, ltp_nm FROM dbo.c2_ltp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_ltp");
            return ds;
        }

        public DataSet SelectC2_clr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT clr_clrcd, clr_nm FROM dbo.c2_clr");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_clr");
            return ds;
        }

        public DataSet SelectC2_pgsize()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pgs_pgscd, pgs_nm FROM dbo.c2_pgsize");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pgsize");
            return ds;
        }
    }
}