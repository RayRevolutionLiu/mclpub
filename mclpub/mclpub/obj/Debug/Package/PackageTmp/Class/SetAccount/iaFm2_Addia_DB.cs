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
    public class iaFm2_Addia_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectbook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm)");
            //sb.Append(@"");
            sb.Append(@" AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM");
            sb.Append(@" dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectc2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_costctr, dbo.refd.rd_projno, dbo.refd.rd_costctr, dbo.c2_pub.pub_imseq, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_empno FROM dbo.c2_pub INNER JOIN dbo.refd ON dbo.c2_pub.pub_syscd = dbo.refd.rd_syscd ");
            sb.Append(@"AND dbo.c2_pub.pub_projno <> dbo.refd.rd_projno AND dbo.c2_pub.pub_costctr <> dbo.refd.rd_costctr INNER JOIN dbo.invmfr ON dbo.c2_pub.pub_syscd = dbo.invmfr.im_syscd AND dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq");
            sb.Append(@" INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno WHERE (dbo.c2_cont.cont_fgpubed = '1') AND");
            sb.Append(@" (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (RTRIM(LTRIM(dbo.c2_pub.pub_fginved)) = '' OR dbo.c2_pub.pub_fginved = 't') AND (RTRIM(dbo.invmfr.im_fgitri) = '') AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectc2_cont2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.iab.iab_syscd, dbo.iab.iab_iabdate, dbo.iab.iab_iabseq, dbo.iab.iab_createdate, dbo.iab.iab_createmen, dbo.c2_pub.pub_bkcd FROM dbo.iab INNER JOIN dbo.ia");
            sb.Append(@" ON dbo.iab.iab_syscd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.ia.ia_syscd AND dbo.iab.iab_iabdate = dbo.ia.ia_iabdate AND dbo.iab.iab_iabseq = dbo.ia.ia_iabseq");
            sb.Append(@" INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c2_pub ON dbo.iad.iad_syscd = dbo.c2_pub.pub_syscd");
            sb.Append(@" AND dbo.iad.iad_fk1 = dbo.c2_pub.pub_contno AND dbo.iad.iad_fk2 = dbo.c2_pub.pub_yyyymm AND dbo.iad.iad_fk3 = dbo.c2_pub.pub_pubseq WHERE (dbo.iab.iab_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectc2_cont3()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, ");
            sb.Append(@"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2");
            sb.Append(@"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con");
            sb.Append(@"t_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_totam");
            sb.Append(@"t, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_custno, ");
            sb.Append(@"dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_fgcancel");
            sb.Append(@", dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.mfr.mfr_inm, dbo.cust.c");
            sb.Append(@"ust_nm, dbo.cust.cust_tel, dbo.srspn.srspn_cname, dbo.c2_pub.pub_syscd, dbo.c2_p");
            sb.Append(@"ub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_pgno");
            sb.Append(@", dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_ltp.l");
            sb.Append(@"tp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_pub.pub_fgfixpg, dbo.c2_p");
            sb.Append(@"ub.pub_drafttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_njtp.njtp_nm");
            sb.Append(@", dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2");
            sb.Append(@"_pub.pub_fgrechg, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pu");
            sb.Append(@"b_origjbkno, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_modempn");
            sb.Append(@"o, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_imseq, dbo.invmfr.im_nm, dbo.c2_pub.pub_r");
            sb.Append(@"emark, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_lt");
            sb.Append(@"pcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_custno, dbo");
            sb.Append(@".invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.mfr.mfr_mfrno, ");
            sb.Append(@"dbo.srspn.srspn_empno, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginvself, dbo.c2_");
            sb.Append(@"pub.pub_projno, dbo.c2_pub.pub_costctr FROM dbo.c2_cont INNER JOIN dbo.mfr ON db");
            sb.Append(@"o.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont");
            sb.Append(@"_custno = dbo.cust.cust_custno INNER JOIN dbo.srspn ON dbo.c2_cont.cont_empno = ");
            sb.Append(@"dbo.srspn.srspn_empno INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_p");
            sb.Append(@"ub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.");
            sb.Append(@"invmfr ON dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq AND dbo.c2_cont.cont_syscd ");
            sb.Append(@"= dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_contno LEFT OU");
            sb.Append(@"TER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN ");
            sb.Append(@"dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN d");
            sb.Append(@"bo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_");
            sb.Append(@"clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize");
            sb.Append(@" ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd WHERE (dbo.c2_cont.cont_fgpub");
            sb.Append(@"ed = '1') AND (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel ");
            sb.Append(@"= '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (RTRIM(LTRIM(dbo.c2_pub.pub_fginved)) = '' OR ");
            sb.Append(@"dbo.c2_pub.pub_fginved = 't') AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectc2_cont4()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, ");
            sb.Append(@"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2");
            sb.Append(@"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con");
            sb.Append(@"t_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_totam");
            sb.Append(@"t, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_custno, ");
            sb.Append(@"dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_fgcancel");
            sb.Append(@", dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.mfr.mfr_inm, dbo.cust.c");
            sb.Append(@"ust_nm, dbo.cust.cust_tel, dbo.srspn.srspn_cname, dbo.c2_pub.pub_syscd, dbo.c2_p");
            sb.Append(@"ub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_pgno");
            sb.Append(@", dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_ltp.l");
            sb.Append(@"tp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_pub.pub_fgfixpg, dbo.c2_p");
            sb.Append(@"ub.pub_drafttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_njtp.njtp_nm");
            sb.Append(@", dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2");
            sb.Append(@"_pub.pub_fgrechg, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pu");
            sb.Append(@"b_origjbkno, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_modempn");
            sb.Append(@"o, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_imseq, dbo.invmfr.im_nm, dbo.c2_pub.pub_r");
            sb.Append(@"emark, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_lt");
            sb.Append(@"pcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_custno, dbo");
            sb.Append(@".invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.mfr.mfr_mfrno, ");
            sb.Append(@"dbo.srspn.srspn_empno, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginvself, dbo.c2_");
            sb.Append(@"pub.pub_projno, dbo.c2_pub.pub_costctr FROM dbo.c2_cont INNER JOIN dbo.mfr ON db");
            sb.Append(@"o.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont");
            sb.Append(@"_custno = dbo.cust.cust_custno INNER JOIN dbo.srspn ON dbo.c2_cont.cont_empno = ");
            sb.Append(@"dbo.srspn.srspn_empno INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_p");
            sb.Append(@"ub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.");
            sb.Append(@"invmfr ON dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq AND dbo.c2_cont.cont_syscd ");
            sb.Append(@"= dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_contno LEFT OU");
            sb.Append(@"TER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN ");
            sb.Append(@"dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN d");
            sb.Append(@"bo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_");
            sb.Append(@"clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize");
            sb.Append(@" ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd WHERE (dbo.c2_cont.cont_fgpub");
            sb.Append(@"ed = '1') AND (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel ");
            sb.Append(@"= '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (RTRIM(LTRIM(dbo.c2_pub.pub_fginved)) = 't' )");
            sb.Append(@" AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectv_c2_iaFm2_prelist2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, CASE WHEN im_invcd = '2' THEN '二聯式' WHEN im_invcd = '3' THEN '三聯式' WHEN im_invcd = '4' THEN '其他' ");
            sb.Append(@" ELSE '不清楚' END AS im_invcdText, ");
            sb.Append(@" CASE WHEN im_taxtp = '1' THEN '應稅5%' WHEN im_taxtp = '2' ");
            sb.Append(@" THEN '零稅' WHEN im_taxtp = '3' THEN '免稅' ");
            sb.Append(@" ELSE '不清楚' END AS im_taxtpText ");
            sb.Append(@" FROM             v_c2_iaFm2_prelist2 ");
            sb.Append(@" WHERE (1=1) ");
            //sb.Append(@"");
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

        public DataSet SelectdistinctContno(string strBkcd, string strYYYYMM)//用來算匯出EXCEL的時候 總共會多出幾個小計
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT distinct pub_contno ");
            sb.Append(@" FROM   v_c2_iaFm2_prelist2 ");
            sb.Append(@" WHERE (1=1) AND cont_bkcd=@cont_bkcd AND pub_yyyymm<=@pub_yyyymm AND pub_yyyymm>='200209'");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_bkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@pub_yyyymm", strYYYYMM);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void UPDATEc2_pub(string syscd, string contno, string yyyymm, string pubseq, string EmptyOrT)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            if (EmptyOrT == "t")
            {
                sb.Append(@"UPDATE c2_pub SET pub_fginved = 't' WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)");
            }
            else if (EmptyOrT == "3")
            {
                sb.Append(@"UPDATE c2_pub SET pub_fginved = ' ' WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq) AND (pub_fginved = 't')");
            }
            else
            {
                sb.Append(@"UPDATE c2_pub SET pub_fginved = ' ' WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)");
            }
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

        public DataSet Selectiab(string date)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(iab_iabid) AS CountNo, MAX(iab_iabseq) AS Maxiabseq FROM dbo.iab WHERE (iab_syscd = 'C2') AND (iab_iabdate = @date)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@date", date);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void INSERTiab(string iabdate, string iabseq, string credate, string creempno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO iab (iab_syscd, iab_iabdate, iab_iabseq, iab_createdate, iab_createmen) VALUES ('C2', @iabdate, @iabseq, @credate, @creempno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iabdate", iabdate);
            oCmd.Parameters.AddWithValue("@iabseq", iabseq);
            oCmd.Parameters.AddWithValue("@credate", credate);
            oCmd.Parameters.AddWithValue("@creempno", creempno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void UPDATEc2_pub2(string syscd, string contno, string yyyymm, string pubseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c2_pub SET pub_fginved = 'v' WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq) AND (pub_fginved = 't')");
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

        public DataSet SelectDISTINCTc2_cont(string bkcd, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_pub.pub_imseq FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno WHERE (dbo.c2_cont.cont_fgpubed = '1') AND (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_pub.pub_fginved = 'v') AND (dbo.c2_cont.cont_bkcd = @bkcd) AND (dbo.c2_pub.pub_yyyymm <= @yyyymm) AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void RunSpsp_c2_add_ia(string syscd, string contno, string imseq, string iabdate, string iabseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c2_add_ia");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@imseq", imseq);
            oCmd.Parameters.AddWithValue("@iabdate", iabdate);
            oCmd.Parameters.AddWithValue("@iabseq", iabseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public DataSet SelectiaChklist2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 100 PERCENT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano");
            sb.Append(@", dbo.ia.ia_refno, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat, dbo.ia.ia_ivat, dbo.ia.ia_invno,");
            sb.Append(@" dbo.ia.ia_invdate, dbo.ia.ia_fgitri, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rzip) AS ia_rzip,");
            sb.Append(@" RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, RTRIM(dbo.ia.ia_cname)");
            sb.Append(@" AS ia_cname, RTRIM(dbo.ia.ia_tel) AS ia_tel, dbo.ia.ia_contno, dbo.iad.iad_iadid, dbo.iad.iad_syscd, dbo.iad.iad_iano, dbo.iad.iad_iaditem, dbo.iad.iad_fk1");
            sb.Append(@", dbo.iad.iad_fk2, dbo.iad.iad_fk3, dbo.iad.iad_fk4, dbo.iad.iad_projno, dbo.iad.iad_costctr, RTRIM(dbo.iad.iad_desc) AS iad_desc, dbo.iad.iad_qty, dbo.iad.iad_unit,");
            sb.Append(@" dbo.iad.iad_uprice, dbo.iad.iad_amt, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd,");
            sb.Append(@"CASE WHEN ia_invcd = '2' THEN '二聯式' WHEN ia_invcd = '3' ");
            sb.Append(@"THEN '三聯式' WHEN ia_invcd = '4' THEN '其他' ");
            sb.Append(@"ELSE '不清楚' END AS ia_invcdText, ");
            sb.Append(@"CASE WHEN ia_taxtp = '1' THEN '應稅5%' WHEN ia_taxtp = '2' ");
            sb.Append(@"THEN '零稅' WHEN ia_taxtp = '3' THEN '免稅' ");
            sb.Append(@"ELSE '不清楚' END AS ia_taxtpText ");
            sb.Append(@" FROM dbo.ia ");
            sb.Append(@"INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c2_cont ON dbo.iad.iad_fk1 = dbo.c2_cont.cont_contno ");
            sb.Append(@"INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_syscd = 'C2') AND (dbo.c2_cont.cont_fgpayonce = '1') ORDER BY dbo.ia.ia_iano DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet CountDistinctia_iano(string strBkcd, string strYYYYMM)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT distinct dbo.ia.ia_iano");
            sb.Append(@" FROM dbo.ia ");
            sb.Append(@"INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c2_cont ON dbo.iad.iad_fk1 = dbo.c2_cont.cont_contno ");
            sb.Append(@"INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_syscd = 'C2') AND (dbo.c2_cont.cont_fgpayonce = '1') ");
            sb.Append(@"AND cont_bkcd = @cont_bkcd ");
            sb.Append(@"AND iad_fk2 = @iad_fk2");
            //sb.Append(@"");
            sb.Append(@" ORDER BY dbo.ia.ia_iano DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_bkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@iad_fk2", strYYYYMM);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}