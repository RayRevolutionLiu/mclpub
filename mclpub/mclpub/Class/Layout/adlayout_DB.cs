using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace mclpub
{
    public class adlayout_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_ltp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from c2_ltp");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@lp_bkcd", lp_bkcd);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            //oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            //oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub(string ltpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_ltp.ltp_ltpcd, dbo.c2_ltp.ltp_nm FROM dbo.c2_ltp INNER JOIN dbo.c2_pub ON dbo.c2_ltp.ltp_ltpcd = dbo.c2_pub.pub_ltpcd WHERE (dbo.c2_ltp.ltp_ltpcd = @ltpcd) GROUP BY dbo.c2_ltp.ltp_ltpcd, dbo.c2_ltp.ltp_nm");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ltpcd", ltpcd);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            //oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            //oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void Delc2_clr(string ltp_ltpid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from c2_ltp where ltp_ltpid=@ltp_ltpid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ltp_ltpid", ltp_ltpid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UPDATEc2_clr(string ltp_ltpcd, string ltp_nm, string ltp_ltpid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update c2_ltp set ltp_ltpcd=@ltp_ltpcd,ltp_nm=@ltp_nm where ltp_ltpid=@ltp_ltpid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ltp_ltpcd", ltp_ltpcd);
            oCmd.Parameters.AddWithValue("@ltp_nm", ltp_nm);
            oCmd.Parameters.AddWithValue("@ltp_ltpid", ltp_ltpid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void INSERTc2_clr(string ltp_ltpcd, string ltp_nm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into c2_ltp(ltp_ltpcd,ltp_nm) values(@ltp_ltpcd,@ltp_nm)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ltp_ltpcd", ltp_ltpcd);
            oCmd.Parameters.AddWithValue("@ltp_nm", ltp_nm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}