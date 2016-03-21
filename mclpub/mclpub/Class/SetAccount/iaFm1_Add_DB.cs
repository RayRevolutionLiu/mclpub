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
    public class iaFm1_Add_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_Cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, ");
            sb.Append(@"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno");
            sb.Append(@", dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate,");
            sb.Append(@" dbo.c2_cont.cont_edate, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_custno,");
            sb.Append(@" RTRIM(dbo.cust.cust_nm) AS cust_nm, dbo.cust.cust_tel, dbo.c2_cont.cont_totamt,");
            sb.Append(@" dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_oldcontno,");
            sb.Append(@" dbo.c2_cont.cont_moddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno,");
            sb.Append(@" dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_fgtemp,");
            sb.Append(@" dbo.c2_cont.cont_fgpubed, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.invmfr.im_imseq");
            sb.Append(@", RTRIM(dbo.invmfr.im_nm) AS im_nm, dbo.cust.cust_custno, dbo.invmfr.im_contno, dbo.invmfr.im_syscd,");
            sb.Append(@" dbo.mfr.mfr_mfrno, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname)");
            sb.Append(@" AS srspn_cname, dbo.book.bk_bkcd, dbo.srspn.srspn_empno");
            sb.Append(@", dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_tottm FROM dbo.c2_cont");
            sb.Append(@" INNER JOIN dbo.invmfr ON dbo.c2_cont.cont_syscd = dbo.invmfr.im_syscd AND");
            sb.Append(@" dbo.c2_cont.cont_contno = dbo.invmfr.im_contno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER ");
            sb.Append(@"JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN ");
            sb.Append(@"dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.srspn");
            sb.Append(@" ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgpayonce = '1') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0')");
            sb.Append(@" AND (dbo.c2_cont.cont_fgpubed = '1')");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectc2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 100 PERCENT dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.p");
            sb.Append(@"ub_pubseq, dbo.c2_pub.pub_pgno AS pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub");
            sb.Append(@"_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_fgfixpg, dbo.c2_pub.pub_remark, dbo");
            sb.Append(@".c2_pub.pub_drafttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub");
            sb.Append(@"_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pub_origjbkno, dbo.c2_pub.pub_chgb");
            sb.Append(@"kcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2_pub.pub_fgrechg, dbo");
            sb.Append(@".c2_pub.pub_bkcd, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm, RTRIM(dbo.c2_clr.clr_nm) A");
            sb.Append(@"S clr_nm, RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS n");
            sb.Append(@"jtp_nm, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cn");
            sb.Append(@"ame, dbo.c2_pub.pub_modempno, dbo.c2_pub.pub_imseq, dbo.c2_pub.pub_fginved, dbo.");
            sb.Append(@"c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_c");
            sb.Append(@"ostctr, dbo.c2_pub.pub_syscd, dbo.mfr.mfr_inm, dbo.cust.cust_nm, dbo.book.bk_nm ");
            sb.Append(@"AS bk_nm, dbo.srspn.srspn_cname AS srspn_cname, dbo.srspn.srspn_tel, dbo.c2_ltp.");
            sb.Append(@"ltp_nm AS ltp_nm, dbo.c2_clr.clr_nm AS clr_nm, dbo.c2_pgsize.pgs_nm AS pgs_nm, d");
            sb.Append(@"bo.c2_njtp.njtp_nm AS njtp_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_lt");
            sb.Append(@"p.ltp_ltpcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_cus");
            sb.Append(@"tno, dbo.mfr.mfr_mfrno, dbo.srspn.srspn_empno, dbo.c2_pub.pub_fginvself, dbo.c2_");
            sb.Append(@"pub.pub_pno, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact FROM dbo.srspn RIGHT");
            sb.Append(@" OUTER JOIN dbo.c2_ltp RIGHT OUTER JOIN dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo");
            sb.Append(@".c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_c");
            sb.Append(@"ont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno ");
            sb.Append(@"INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno LEFT OUTER");
            sb.Append(@" JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN ");
            sb.Append(@"dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd ON dbo.c2_ltp.lt");
            sb.Append(@"p_ltpcd = dbo.c2_pub.pub_ltpcd LEFT OUTER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njt");
            sb.Append(@"pcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkc");
            sb.Append(@"d = dbo.book.bk_bkcd ON dbo.srspn.srspn_empno = dbo.c2_cont.cont_empno ");
            sb.Append(@"WHERE (RTRIM(LTRIM(dbo.c2_pub.pub_fginved)) = '') AND (dbo.c2_cont.cont_fgpubed = '1') AND (dbo.c2_con");
            sb.Append(@"t.cont_fgpayonce = '1') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.c");
            sb.Append(@"ont_fgtemp = '0') AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0) ORDER B");
            sb.Append(@"Y dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}