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
    public class adlprior_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_lprior()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd, COUNT(dbo.c2_pub.pub_contno) AS PubCounts");
            sb.Append(@", dbo.c2_lprior.lp_lpid, dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm FROM dbo.c2_lprior INNER JOIN");
            sb.Append(@" dbo.book ON dbo.c2_lprior.lp_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.c2_ltp ON dbo.c2_lprior.lp_ltpcd = dbo.c2_ltp.ltp_ltpcd");
            sb.Append(@" INNER JOIN dbo.c2_clr ON dbo.c2_lprior.lp_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ON dbo.c2_lprior.lp_pgscd = dbo.c2_pgsize.pgs_pgscd");
            sb.Append(@" LEFT OUTER JOIN dbo.c2_pub ON dbo.c2_lprior.lp_clrcd = dbo.c2_pub.pub_clrcd AND dbo.c2_lprior.lp_ltpcd = dbo.c2_pub.pub_ltpcd AND dbo.c2_lprior.lp_pgscd = dbo.c2_pub.pub_pgscd ");
            sb.Append(@"AND dbo.c2_lprior.lp_bkcd = dbo.c2_pub.pub_bkcd GROUP BY dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd");
            sb.Append(@", dbo.c2_lprior.lp_pgscd, dbo.c2_lprior.lp_lpid, dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm ORDER BY dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void deletec2_lprior(string lp_lpid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from c2_lprior where lp_lpid=@lp_lpid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@lp_lpid", lp_lpid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public DataSet SelectMAXc2_lprior(string bkcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT lp_bkcd, MAX(lp_priorseq) AS MaxSeq FROM dbo.c2_lprior WHERE (lp_bkcd = @bkcd) GROUP BY lp_bkcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_lpriorMore()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lprior");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Updatec2_lprior(string lp_bkcd, string lp_priorseq, string lp_ltpcd, string lp_clrcd, string lp_pgscd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c2_lprior SET lp_priorseq = @lp_priorseq WHERE (lp_bkcd = @lp_bkcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_clrcd = @lp_clrcd) AND (lp_pgscd = @lp_pgscd)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@lp_bkcd", lp_bkcd);
            oCmd.Parameters.AddWithValue("@lp_priorseq", lp_priorseq);
            oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        //底下為GRIDVEIW點擊修改之後產生之DPBINDING
        public DataSet Book()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bk_bkid, bk_bkcd, bk_nm FROM dbo.book");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet c2_clr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT clr_clrid, clr_clrcd, clr_nm FROM dbo.c2_clr");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet c2_ltp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ltp_ltpid, ltp_ltpcd, ltp_nm FROM dbo.c2_ltp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet c2_pgsize()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pgs_pgsid, pgs_pgscd, pgs_nm FROM dbo.c2_pgsize");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        //底下為修改按下確定後的查詢是否有重覆筆數

        public DataSet Checkc2_lprior()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from c2_lprior");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Checkc2_lprior2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT lp_lpid, lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lprior");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Updatec2_lpriorFinal(string lp_lpid, string lp_bkcd, string lp_priorseq, string lp_clrcd, string lp_ltpcd, string lp_pgscd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update c2_lprior set lp_bkcd=@lp_bkcd, lp_priorseq=@lp_priorseq, lp_clrcd=@lp_clrcd, lp_ltpcd=@lp_ltpcd, lp_pgscd=@lp_pgscd where lp_lpid=@lp_lpid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@lp_lpid", lp_lpid);
            oCmd.Parameters.AddWithValue("@lp_bkcd", lp_bkcd);
            oCmd.Parameters.AddWithValue("@lp_priorseq", lp_priorseq);
            oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        //底下是新增跳窗的下拉選單連結
        public DataSet NewBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Newc2_clr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT clr_clrid, clr_clrcd, clr_nm FROM dbo.c2_clr");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Newc2_ltp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ltp_ltpid, ltp_ltpcd, ltp_nm FROM dbo.c2_ltp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Newc2_pgsize()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pgs_pgsid, pgs_pgscd, pgs_nm FROM dbo.c2_pgsize");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}