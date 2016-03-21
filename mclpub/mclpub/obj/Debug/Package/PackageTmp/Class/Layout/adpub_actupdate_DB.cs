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
    public class adpub_actupdate_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 100 PERCENT dbo.c2_pub.pub_pubid AS ID, 0 AS 頁次, RTRIM(dbo.c2_pub.pub_");
            sb.Append(@"contno) AS 合約書編號, RTRIM(dbo.c2_pub.pub_pubseq) AS 落版序號, RTRIM(dbo.c2_pub.pub_yyyymm) AS 刊登年月, ");
            sb.Append(@"dbo.c2_pub.pub_pgno AS 刊登頁碼, RTRIM(dbo.c2_pub.pub_clrcd) AS 廣告色彩代碼");
            sb.Append(@", RTRIM(dbo.c2_pub.pub_pgscd) AS 廣告版面代碼, RTRIM(dbo.c2_pub.pub_ltpcd) AS 廣告篇幅代碼, ");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_fgfixpg) AS 固定頁次註記, RTRIM(dbo.c2_pub.pub_fggot) AS 到稿註記");
            sb.Append(@", RTRIM(dbo.c2_pub.pub_modempno) AS 落版業務員工號, RTRIM(dbo.c2_pub.pub_remark) AS 備註");
            sb.Append(@", RTRIM(dbo.c2_pub.pub_origbkcd) AS 舊稿書籍代碼, RTRIM(dbo.c2_pub.pub_origjno) AS 舊稿期別");
            sb.Append(@", RTRIM(dbo.c2_pub.pub_origjbkno) AS 舊稿頁碼, RTRIM(dbo.c2_pub.pub_chgbkcd) AS 改稿書籍代碼, ");
            sb.Append(@"RTRIM(dbo.c2_pub.pub_chgjno) AS 改稿期別, RTRIM(dbo.c2_pub.pub_chgjbkno) AS 改稿頁碼");
            sb.Append(@", RTRIM(dbo.c2_pub.pub_fgrechg) AS 改稿重出片註記, RTRIM(dbo.c2_pub.pub_njtpcd) AS 新稿製法代碼, ");
            sb.Append(@"RTRIM(dbo.mfr.mfr_inm) AS 公司名稱, 8 AS 版面2, RTRIM(dbo.c2_pub.pub_bkcd) AS 書籍類別代碼, ");
            sb.Append(@"RTRIM(dbo.c2_clr.clr_nm) AS 廣告色彩, RTRIM(dbo.c2_ltp.ltp_nm) AS 廣告版面");
            sb.Append(@", RTRIM(dbo.c2_pgsize.pgs_nm) AS 廣告篇幅, RTRIM(dbo.c2_njtp.njtp_nm) AS 新稿製法, RTRIM(dbo.book.bk_nm) AS 舊稿書籍名稱,");
            sb.Append(@" RTRIM(dbo.srspn.srspn_cname) AS 落版業務員姓名, RTRIM(dbo.c2_pub.pub_drafttp)");
            sb.Append(@" AS 稿件類別代碼, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_syscd, ");
            sb.Append(@"dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_fgupdated AS 美編樣後修改註記, dbo.c2_lprior.lp_priorseq");
            sb.Append(@" AS 廣告優先次序, dbo.c2_lprior.lp_bkcd, dbo.c2_pub.pub_njtpcd + ' ' + dbo.c2_njtp.njtp_nm");
            sb.Append(@" AS njtp_nostr FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno");
            sb.Append(@" = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.co");
            sb.Append(@"nt_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER ");
            sb.Append(@"JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2_lprior.lp_ltpcd AND dbo.c2_p");
            sb.Append(@"ub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pub.pub_pgscd = dbo.c2_lprior.l");
            sb.Append(@"p_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd LEFT OUTER JOIN dbo.c2_c");
            sb.Append(@"lr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize ");
            sb.Append(@"ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.c2_ltp ON ");
            sb.Append(@"dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_njtp ON dbo.c");
            sb.Append(@"2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON dbo.c2_pu");
            sb.Append(@"b.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN dbo.srspn ON dbo.c2_cont.cont_");
            sb.Append(@"empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c");
            sb.Append(@"2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont");
            sb.Append(@".cont_fgpubed = '1') ORDER BY 廣告優先次序, 刊登頁碼, 合約書編號, 刊登年月 DESC, 落版序號");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_njtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT njtp_njtpcd, njtp_nm FROM dbo.c2_njtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet njtp_detailASPX()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM c2_njtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pubASPX(string njtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_njtp.njtp_njtpcd, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm FROM dbo.c2_njtp INNER JOIN dbo.c2_pub ON dbo.c2_njtp.njtp_njtpcd = dbo.c2_pub.pub_njtpcd WHERE (dbo.c2_njtp.njtp_njtpcd = @njtpcd) GROUP BY dbo.c2_njtp.njtp_njtpcd, dbo.c2_njtp.njtp_nm");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@njtpcd", njtpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void delete(string njtp_njtpid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from c2_njtp where njtp_njtpid=@njtp_njtpid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@njtp_njtpid", Convert.ToInt32(njtp_njtpid));
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Insert(string njtp_njtpcd, string njtp_nm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into c2_njtp(njtp_njtpcd,njtp_nm) values(@njtp_njtpcd,@njtp_nm)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@njtp_njtpcd", njtp_njtpcd);
            oCmd.Parameters.AddWithValue("@njtp_nm", njtp_nm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Update(string njtp_njtpid,string njtp_njtpcd, string njtp_nm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update c2_njtp set njtp_njtpcd=@njtp_njtpcd,njtp_nm=@njtp_nm where njtp_njtpid=@njtp_njtpid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@njtp_njtpid", njtp_njtpid);
            oCmd.Parameters.AddWithValue("@njtp_njtpcd", njtp_njtpcd);
            oCmd.Parameters.AddWithValue("@njtp_nm", njtp_nm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Updatec2_pub(string pub_njtpcd, int pub_chgjbkno, string pub_fgrechg, string pub_fgupdated, string pub_syscd, string pub_contno, string pub_yyyymm, string pub_pubseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c2_pub SET pub_njtpcd = @njtpcd, pub_chgjbkno = @chgjbkno, pub_fgrechg = @fgrechg, pub_fgupdated = @fgupdated WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@njtpcd", pub_njtpcd);
            oCmd.Parameters.AddWithValue("@chgjbkno", pub_chgjbkno);
            oCmd.Parameters.AddWithValue("@fgrechg", pub_fgrechg);
            oCmd.Parameters.AddWithValue("@fgupdated", pub_fgupdated);
            oCmd.Parameters.AddWithValue("@syscd", pub_syscd);
            oCmd.Parameters.AddWithValue("@contno", pub_contno);
            oCmd.Parameters.AddWithValue("@yyyymm", pub_yyyymm);
            oCmd.Parameters.AddWithValue("@pubseq", pub_pubseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}