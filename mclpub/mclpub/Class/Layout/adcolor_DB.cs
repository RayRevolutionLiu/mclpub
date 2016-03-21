using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
namespace mclpub
{
    public class adcolor_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_clr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from c2_clr");
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

        public DataSet SelectJudgeDelc2_clr(string clrcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_clr.clr_clrcd, dbo.c2_clr.clr_nm FROM dbo.c2_pub INNER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd WHERE (dbo.c2_clr.clr_clrcd = @clrcd) GROUP BY dbo.c2_clr.clr_clrcd, dbo.c2_clr.clr_nm");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@clrcd", clrcd);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            //oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            //oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void Delc2_clr(string clr_clrid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from c2_clr where clr_clrid=@clr_clrid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@clr_clrid", clr_clrid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet CountMaxClrcd()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select count(*) as CountNo,max(clr_clrcd) as MaxCountNo from c2_clr");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void INSERTc2_clr(string clr_clrcd, string clr_nm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into c2_clr(clr_clrcd,clr_nm) values(@clr_clrcd,@clr_nm)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@clr_clrcd", clr_clrcd);
            oCmd.Parameters.AddWithValue("@clr_nm", clr_nm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void UPDATEc2_clr(string clr_clrcd, string clr_nm, string clr_clrid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update c2_clr set clr_clrcd=@clr_clrcd,clr_nm=@clr_nm where clr_clrid=@clr_clrid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@clr_clrcd", clr_clrcd);
            oCmd.Parameters.AddWithValue("@clr_nm", clr_nm);
            oCmd.Parameters.AddWithValue("@clr_clrid", clr_clrid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}