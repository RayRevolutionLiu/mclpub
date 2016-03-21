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
    public class SubmitJudge_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_lprior(string lp_bkcd, string lp_ltpcd, string lp_clrcd, string lp_pgscd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT lp_lpid, lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lprior ");
            sb.Append(@" WHERE 1=1 AND lp_bkcd=@lp_bkcd ");
            sb.Append(@"AND lp_ltpcd=@lp_ltpcd ");
            sb.Append(@"AND lp_clrcd=@lp_clrcd ");
            sb.Append(@"AND lp_pgscd=@lp_pgscd ");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@lp_bkcd", lp_bkcd);
            oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet SelectMaxc2_lprior(string bkcd)
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

        public DataSet SelectNextc2_lprior()
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
            oCmd.CommandText = @"UPDATE c2_lprior SET lp_priorseq = @lp_priorseq WHERE (lp_bkcd = @lp_bkcd) AND (lp_clrcd = @lp_clrcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_pgscd = @lp_pgscd)";
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


        public void Insertc2_lprior(string lp_bkcd, string lp_priorseq, string lp_ltpcd, string lp_clrcd, string lp_pgscd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into c2_lprior(lp_bkcd, lp_priorseq, lp_ltpcd, lp_clrcd, lp_pgscd) values(@lp_bkcd, @lp_priorseq, @lp_ltpcd, @lp_clrcd, @lp_pgscd)";
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
    }
}