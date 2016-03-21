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
    public class iaFm1_Addia_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_Cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp,");
            sb.Append(@"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2");
            sb.Append(@"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con");
            sb.Append(@"t_edate, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_custno, RTRIM(dbo.cust.cust");
            sb.Append(@"_nm) AS cust_nm, dbo.cust.cust_tel, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pa");
            sb.Append(@"idamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_oldcontno, dbo.c2_cont.cont_mo");
            sb.Append(@"ddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, dbo.c2_cont.cont_f");
            sb.Append(@"gcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgp");
            sb.Append(@"ubed, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.invmfr.im_imseq, RTRIM(dbo.invmfr.i");
            sb.Append(@"m_nm) AS im_nm, dbo.cust.cust_custno, dbo.invmfr.im_contno, dbo.invmfr.im_syscd, ");
            sb.Append(@" dbo.mfr.mfr_mfrno, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) ");
            sb.Append(@" AS srspn_cname, dbo.book.bk_bkcd, dbo.srspn.srspn_empno, dbo.c2_cont.cont_totjt");
            sb.Append(@"m, dbo.c2_cont.cont_tottm FROM dbo.c2_cont INNER JOIN dbo.invmfr ON dbo.c2_cont.");
            sb.Append(@"cont_syscd = dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_con");
            sb.Append(@"tno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER  ");
            sb.Append(@"JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book O");
            sb.Append(@"N dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.srspn ON dbo.c2_cont.c");
            sb.Append(@"ont_empno = dbo.srspn.srspn_empno LEFT OUTER JOIN dbo.c2_pub ON dbo.c2_cont.cont");
            sb.Append(@"_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contn");
            sb.Append(@"o WHERE (dbo.c2_cont.cont_fgpayonce = '1') AND (dbo.c2_cont.cont_fgcancel = '0')");
            sb.Append(@" AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1') AND");
            sb.Append(@"(RTRIM(LTRIM(dbo.c2_pub.pub_fginved)) = '')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectc2_Cont2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c");
            sb.Append(@"2_pub.pub_pgno AS pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_p");
            sb.Append(@"ub.pub_pgscd, dbo.c2_pub.pub_fgfixpg, dbo.c2_pub.pub_remark, dbo.c2_pub.pub_draf");
            sb.Append(@"ttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub_origbkcd, dbo.c");
            sb.Append(@"2_pub.pub_origjno, dbo.c2_pub.pub_origjbkno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.");
            sb.Append(@"pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2_pub.pub_fgrechg, dbo.c2_pub.pub_bkcd");
            sb.Append(@", RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(");
            sb.Append(@"dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm, RTRIM(db");
            sb.Append(@"o.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.c2_pub.");
            sb.Append(@"pub_modempno, dbo.c2_pub.pub_imseq, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_adamt");
            sb.Append(@", dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_costctr, dbo.c2_p");
            sb.Append(@"ub.pub_syscd, dbo.mfr.mfr_inm, dbo.cust.cust_nm, dbo.book.bk_nm AS Expr1, dbo.sr");
            sb.Append(@"spn.srspn_cname AS Expr2, dbo.srspn.srspn_tel, dbo.c2_ltp.ltp_nm AS Expr3, dbo.c");
            sb.Append(@"2_clr.clr_nm AS Expr4, dbo.c2_pgsize.pgs_nm AS Expr5, dbo.c2_njtp.njtp_nm AS Exp");
            sb.Append(@"r6, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_ltpcd, dbo.c2_njtp.nj");
            sb.Append(@"tp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo");
            sb.Append(@".srspn.srspn_empno FROM dbo.srspn RIGHT OUTER JOIN dbo.c2_ltp RIGHT OUTER JOIN d");
            sb.Append(@"bo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_con");
            sb.Append(@"tno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.");
            sb.Append(@"c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_c");
            sb.Append(@"ustno = dbo.cust.cust_custno LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd ");
            sb.Append(@"= dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = d");
            sb.Append(@"bo.c2_pgsize.pgs_pgscd ON dbo.c2_ltp.ltp_ltpcd = dbo.c2_pub.pub_ltpcd LEFT OUTER");
            sb.Append(@" JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER ");
            sb.Append(@"JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd ON dbo.srspn.srspn_e");
            sb.Append(@"mpno = dbo.c2_cont.cont_empno WHERE (RTRIM(LTRIM(dbo.c2_pub.pub_fginved)) ='') AND (dbo.c2_c");
            sb.Append(@"ont.cont_fgpubed = '1') AND (dbo.c2_cont.cont_fgpayonce = '1') AND (dbo.c2_cont.");
            sb.Append(@"cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_pub.pub_ada");
            sb.Append(@"mt + dbo.c2_pub.pub_chgamt > 0) ORDER BY dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public void UPDATEsp_c2_add_1_ia_1(string syscd, string contno, string imseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"dbo.sp_c2_add_1_ia_1");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@imseq", imseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void UPDATEc2_pub(string syscd, string contno, string yyyymm, string pubseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c2_pub SET pub_fginved = 'v' WHERE (RTRIM(LTRIM(pub_fginved)) = '') AND (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@pubseq", pubseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UPDATEc2_cont(int paidamt, int restamt, string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c2_cont SET cont_paidamt = @paidamt, cont_restamt = @restamt WHERE (cont_syscd = 'C2') AND (cont_contno = @contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@paidamt", paidamt);
            oCmd.Parameters.AddWithValue("@restamt", restamt);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet SelectMaxia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MAX(ia_iano) AS MaxIANno FROM dbo.ia WHERE (ia_syscd = 'C2')");
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