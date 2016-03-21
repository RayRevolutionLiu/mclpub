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
    public class adpub_act2_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_pgno()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pg_bkcd, pg_startpgno FROM dbo.c2_pgno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet SelectBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bk_bkid, bk_bkcd, RTRIM(bk_nm) AS bk_nm FROM dbo.book");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet SelectBookp(string bkp_date)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bkp_pno FROM dbo.bookp WHERE bkp_date = @bkp_date");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkp_date", bkp_date);
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
            sb.Append(@"SELECT dbo.c2_pub.pub_pgno AS PageNo, RTRIM(dbo.c2_pub.pub_contno) AS pub_contno,");
            sb.Append(@" RTRIM(dbo.c2_pub.pub_pubseq) AS pub_pubseq, RTRIM(dbo.c2_pub.pub_yyyymm) AS pub");
            sb.Append(@"_yyyymm, dbo.c2_pub.pub_pgno AS pub_pgno, RTRIM(dbo.c2_pub.pub_ltpcd) AS pub_ltp");
            sb.Append(@"cd, RTRIM(dbo.c2_pub.pub_clrcd) AS pub_clrcd, RTRIM(dbo.c2_pub.pub_pgscd) AS pub");
            sb.Append(@"_pgscd, RTRIM(dbo.c2_pub.pub_fgfixpg) AS pub_fgfixpg, RTRIM(dbo.c2_pub.pub_fggot");
            sb.Append(@") AS pub_fggot, RTRIM(dbo.c2_pub.pub_modempno) AS pub_modempno, RTRIM(dbo.c2_pub");
            sb.Append(@".pub_remark) AS pub_remark, RTRIM(dbo.c2_pub.pub_origbkcd) AS pub_origbkcd, RTRI");
            sb.Append(@"M(dbo.c2_pub.pub_origjno) AS pub_origjno, RTRIM(dbo.c2_pub.pub_origjbkno) AS pub");
            sb.Append(@"_origjbkno, RTRIM(dbo.c2_pub.pub_chgbkcd) AS pub_chgbkcd, RTRIM(dbo.c2_pub.pub_c");
            sb.Append(@"hgjno) AS pub_chgjno, RTRIM(dbo.c2_pub.pub_chgjbkno) AS pub_chgjbkno, RTRIM(dbo.");
            sb.Append(@"c2_pub.pub_fgrechg) AS pub_fgrechg, RTRIM(dbo.c2_pub.pub_njtpcd) AS pub_njtpcd, ");
            sb.Append(@"RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, 8 AS layout2, RTRIM(dbo.c2_pub.pub_bkcd) AS p");
            sb.Append(@"ub_bkcd, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm,");
            sb.Append(@" RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm, R");
            sb.Append(@"TRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, RTRI");
            sb.Append(@"M(dbo.c2_pub.pub_drafttp) AS pub_drafttp, dbo.c2_pub.pub_contno AS pub_contno, d");
            sb.Append(@"bo.c2_pub.pub_pubseq AS pub_pubseq, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm ");
            sb.Append(@"AS pub_yyyymm, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_bkcd, dbo.c2_cont.con");
            sb.Append(@"t_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont");
            sb.Append(@"_fgpubed, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.c2_pub INNER ");
            sb.Append(@"JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_p");
            sb.Append(@"ub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfr");
            sb.Append(@"no = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2");
            sb.Append(@"_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pu");
            sb.Append(@"b.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_");
            sb.Append(@"bkcd LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd L");
            sb.Append(@"EFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd L");
            sb.Append(@"EFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OU");
            sb.Append(@"TER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUT");
            sb.Append(@"ER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN d");
            sb.Append(@"bo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.co");
            sb.Append(@"nt_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_f");
            sb.Append(@"gtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1') ORDER BY dbo.c2_lprior.lp_prio");
            sb.Append(@"rseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub2(string bkcd, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, COUNT(dbo.c2_pub.pub_contno) AS CountNo, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed FROM dbo.c2_pub INNER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno WHERE (dbo.c2_pub.pub_bkcd = @bkcd) AND (dbo.c2_pub.pub_yyyymm = @yyyymm) AND (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1') GROUP BY dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet SelectspecialGV(string bkcd, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            string strSelectCommand = "SELECT c2_pub.pub_pgno AS 頁次, RTRIM(c2_pub.pub_contno) AS 合約書編號, RTRIM(c2_pub.pub_pubseq) AS 落版序號, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_yyyymm) AS 刊登年月, c2_pub.pub_pgno AS 刊登頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_clrcd) AS 廣告色彩代碼, RTRIM(c2_pub.pub_pgscd) AS 廣告版面代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_ltpcd) AS 廣告篇幅代碼, RTRIM(c2_pub.pub_fgfixpg) AS 固定頁次註記, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fggot) AS 到稿註記, RTRIM(c2_pub.pub_modempno) AS 落版業務員工號, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_remark) AS 備註, RTRIM(c2_pub.pub_origbkcd) AS 舊稿書籍代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_origjno) AS 舊稿期別, RTRIM(c2_pub.pub_origjbkno) AS 舊稿頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_chgbkcd) AS 改稿書籍代碼, RTRIM(c2_pub.pub_chgjno) ";
            strSelectCommand = strSelectCommand + " AS 改稿期別, RTRIM(c2_pub.pub_chgjbkno) AS 改稿頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fgrechg) AS 改稿重出片註記, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_njtpcd) AS 新稿製法代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(mfr.mfr_inm) AS 公司名稱, 8 AS 版面2, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_bkcd) AS 書籍類別代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_clr.clr_nm) AS 廣告色彩, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_ltp.ltp_nm) AS 廣告版面, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pgsize.pgs_nm) AS 廣告篇幅, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_njtp.njtp_nm) AS 新稿製法, ";
            strSelectCommand = strSelectCommand + " RTRIM(book.bk_nm) AS 舊稿書籍名稱, ";
            strSelectCommand = strSelectCommand + " RTRIM(srspn.srspn_cname) AS 落版業務員姓名, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS 稿件類別代碼, ";
            strSelectCommand = strSelectCommand + " c2_lprior.lp_priorseq AS 廣告優先次序, c2_lprior.lp_bkcd AS 廣告優先次序書籍類別代碼";
            strSelectCommand = strSelectCommand + " FROM c2_pub ";
            strSelectCommand = strSelectCommand + " INNER JOIN ";
            strSelectCommand = strSelectCommand + " c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_syscd = c2_cont.cont_syscd INNER JOIN ";
            strSelectCommand = strSelectCommand + " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ";
            strSelectCommand = strSelectCommand + " c2_lprior ON c2_pub.pub_ltpcd = c2_lprior.lp_ltpcd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_clrcd = c2_lprior.lp_clrcd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_pgscd = c2_lprior.lp_pgscd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " book ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
            strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =@bkcd) AND (c2_pub.pub_yyyymm =@yyyymm) ";
            strSelectCommand = strSelectCommand + " AND (CONVERT(int,c2_pub.pub_ltpcd) < 50) ";//再去代碼那邊加一行備註 若是要新增特殊版面 則數字要小於50
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgclosed = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgcancel = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgtemp = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgpubed = '1') ";
            strSelectCommand = strSelectCommand + " ORDER BY 廣告優先次序, 刊登頁碼 ";
            sb.Append(@"" + strSelectCommand + "");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            DataSet ds = new DataSet("root");
            oda.Fill(ds);
            return ds;
        }


        public DataSet SelectCommonGV(string bkcd, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            string strSelectCommand = "SELECT 0 AS 頁次, RTRIM(c2_pub.pub_contno) AS 合約書編號, RTRIM(c2_pub.pub_pubseq) AS 落版序號, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_yyyymm) AS 刊登年月, c2_pub.pub_pgno AS 刊登頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_clrcd) AS 廣告色彩代碼, RTRIM(c2_pub.pub_pgscd) AS 廣告版面代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_ltpcd) AS 廣告篇幅代碼, RTRIM(c2_pub.pub_fgfixpg) AS 固定頁次註記, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fggot) AS 到稿註記, RTRIM(c2_pub.pub_modempno) AS 落版業務員工號, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_remark) AS 備註, RTRIM(c2_pub.pub_origbkcd) AS 舊稿書籍代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_origjno) AS 舊稿期別, RTRIM(c2_pub.pub_origjbkno) AS 舊稿頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_chgbkcd) AS 改稿書籍代碼, RTRIM(c2_pub.pub_chgjno) ";
            strSelectCommand = strSelectCommand + " AS 改稿期別, RTRIM(c2_pub.pub_chgjbkno) AS 改稿頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fgrechg) AS 改稿重出片註記,";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_njtpcd) AS 新稿製法代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(mfr.mfr_inm) AS 公司名稱, 8 AS 版面2, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_bkcd) AS 書籍類別代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_clr.clr_nm) AS 廣告色彩, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_ltp.ltp_nm) AS 廣告版面, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pgsize.pgs_nm) AS 廣告篇幅, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_njtp.njtp_nm) AS 新稿製法, ";
            strSelectCommand = strSelectCommand + " RTRIM(book.bk_nm) AS 舊稿書籍名稱, ";
            strSelectCommand = strSelectCommand + " RTRIM(srspn.srspn_cname) AS 落版業務員姓名, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS 稿件類別代碼, ";
            strSelectCommand = strSelectCommand + " c2_lprior.lp_priorseq AS 廣告優先次序, c2_lprior.lp_bkcd AS 廣告優先次序書籍類別代碼,c2_pub.pub_pulpg AS 拉頁標註 ";
            strSelectCommand = strSelectCommand + " FROM c2_pub ";
            strSelectCommand = strSelectCommand + " INNER JOIN ";
            strSelectCommand = strSelectCommand + " c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_syscd = c2_cont.cont_syscd INNER JOIN ";
            strSelectCommand = strSelectCommand + " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ";
            strSelectCommand = strSelectCommand + " c2_lprior ON c2_pub.pub_ltpcd = c2_lprior.lp_ltpcd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_clrcd = c2_lprior.lp_clrcd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_pgscd = c2_lprior.lp_pgscd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " book ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
            strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =@bkcd) AND (c2_pub.pub_yyyymm =@yyyymm) ";
            strSelectCommand = strSelectCommand + " AND (CONVERT(int,c2_pub.pub_ltpcd) >= 50) ";//再去代碼那邊加一行備註 若是要新增一般版面 則數字要大於50
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgclosed = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgcancel = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgtemp = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgpubed = '1') ";
            strSelectCommand = strSelectCommand + " ORDER BY 廣告優先次序, 刊登頁碼, 合約書編號, 落版序號 ";
            sb.Append(@"" + strSelectCommand + "");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            DataSet ds = new DataSet("root");
            oda.Fill(ds,"item");
            return ds;
        }

        public void UpdatePgno(int pub_pgno, string pub_contno, string pub_yyyymm, string pub_pubseq, int Changepub_pgno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c2_pub SET pub_pgno = @pub_pgno WHERE pub_syscd ='C2' AND pub_contno=@pub_contno AND pub_yyyymm=@pub_yyyymm AND pub_pubseq=@pub_pubseq AND pub_pgno=@Changepub_pgno ";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pub_pgno", pub_pgno);
            oCmd.Parameters.AddWithValue("@pub_contno", pub_contno);
            oCmd.Parameters.AddWithValue("@pub_yyyymm", pub_yyyymm);
            oCmd.Parameters.AddWithValue("@pub_pubseq", pub_pubseq);
            oCmd.Parameters.AddWithValue("@Changepub_pgno", Changepub_pgno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet SelectspecialGVForCount(string bkcd, string yyyymm)//拿來計算目錄用
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            string strSelectCommand = "SELECT c2_pub.pub_pgno AS 頁次, RTRIM(c2_pub.pub_contno) AS 合約書編號, RTRIM(c2_pub.pub_pubseq) AS 落版序號, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_yyyymm) AS 刊登年月, c2_pub.pub_pgno AS 刊登頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_clrcd) AS 廣告色彩代碼, RTRIM(c2_pub.pub_pgscd) AS 廣告版面代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_ltpcd) AS 廣告篇幅代碼, RTRIM(c2_pub.pub_fgfixpg) AS 固定頁次註記, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fggot) AS 到稿註記, RTRIM(c2_pub.pub_modempno) AS 落版業務員工號, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_remark) AS 備註, RTRIM(c2_pub.pub_origbkcd) AS 舊稿書籍代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_origjno) AS 舊稿期別, RTRIM(c2_pub.pub_origjbkno) AS 舊稿頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_chgbkcd) AS 改稿書籍代碼, RTRIM(c2_pub.pub_chgjno) ";
            strSelectCommand = strSelectCommand + " AS 改稿期別, RTRIM(c2_pub.pub_chgjbkno) AS 改稿頁碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fgrechg) AS 改稿重出片註記, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_njtpcd) AS 新稿製法代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(mfr.mfr_inm) AS 公司名稱, 8 AS 版面2, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_bkcd) AS 書籍類別代碼, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_clr.clr_nm) AS 廣告色彩, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_ltp.ltp_nm) AS 廣告版面, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pgsize.pgs_nm) AS 廣告篇幅, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_njtp.njtp_nm) AS 新稿製法, ";
            strSelectCommand = strSelectCommand + " RTRIM(book.bk_nm) AS 舊稿書籍名稱, ";
            strSelectCommand = strSelectCommand + " RTRIM(srspn.srspn_cname) AS 落版業務員姓名, ";
            strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS 稿件類別代碼, ";
            strSelectCommand = strSelectCommand + " c2_lprior.lp_priorseq AS 廣告優先次序, c2_lprior.lp_bkcd AS 廣告優先次序書籍類別代碼";
            strSelectCommand = strSelectCommand + " FROM c2_pub ";
            strSelectCommand = strSelectCommand + " INNER JOIN ";
            strSelectCommand = strSelectCommand + " c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_syscd = c2_cont.cont_syscd INNER JOIN ";
            strSelectCommand = strSelectCommand + " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ";
            strSelectCommand = strSelectCommand + " c2_lprior ON c2_pub.pub_ltpcd = c2_lprior.lp_ltpcd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_clrcd = c2_lprior.lp_clrcd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_pgscd = c2_lprior.lp_pgscd AND ";
            strSelectCommand = strSelectCommand + " c2_pub.pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " book ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN ";
            strSelectCommand = strSelectCommand + " srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
            strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =@bkcd) AND (c2_pub.pub_yyyymm =@yyyymm) ";
            strSelectCommand = strSelectCommand + " AND (c2_pub.pub_ltpcd IN ('01','02','03','04','05','06')) ";//因為他一直新增很多廣告篇幅代碼 所以只好用IN把特殊頁面的給IN掉
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgclosed = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgcancel = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgtemp = '0') ";
            strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgpubed = '1') ";
            strSelectCommand = strSelectCommand + " AND (c2_pub.pub_pgno <> '0') ";
            strSelectCommand = strSelectCommand + " ORDER BY 廣告優先次序, 刊登頁碼 ";
            sb.Append(@"" + strSelectCommand + "");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}