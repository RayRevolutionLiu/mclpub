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
    public class otp_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_otp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * FROM c1_otp ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataTable OutPutMaxValue(string otp_otp1cd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select count(*) as C1,max(otp_otp2cd) as MaxCountNo from c1_otp WHERE otp_otp1cd=@otp_otp1cd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@otp_otp1cd", otp_otp1cd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;
        }

        public void Delc1_otp(string otp_otpid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from c1_otp where otp_otpid=@otp_otpid ";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@otp_otpid", otp_otpid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Insertc1_otp(string otp_otp1cd, string otp_otp1nm, string otp_otp2cd, string otp_otp2nm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into c1_otp(otp_otp1cd,otp_otp1nm,otp_otp2cd,otp_otp2nm) values(@otp_otp1cd,@otp_otp1nm,@otp_otp2cd,@otp_otp2nm)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@otp_otp1cd", otp_otp1cd);
            oCmd.Parameters.AddWithValue("@otp_otp1nm", otp_otp1nm);
            oCmd.Parameters.AddWithValue("@otp_otp2cd", otp_otp2cd);
            oCmd.Parameters.AddWithValue("@otp_otp2nm", otp_otp2nm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Updatec1_otp(string otp_otp1cd, string otp_otp1nm, string otp_otp2cd, string otp_otp2nm, string otp_otpid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update c1_otp set otp_otp1cd=@otp_otp1cd,otp_otp1nm=@otp_otp1nm,otp_otp2cd=@otp_otp2cd,otp_otp2nm=@otp_otp2nm where otp_otpid=@otp_otpid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@otp_otp1cd", otp_otp1cd);
            oCmd.Parameters.AddWithValue("@otp_otp1nm", otp_otp1nm);
            oCmd.Parameters.AddWithValue("@otp_otp2cd", otp_otp2cd);
            oCmd.Parameters.AddWithValue("@otp_otp2nm", otp_otp2nm);
            oCmd.Parameters.AddWithValue("@otp_otpid", otp_otpid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public DataTable SelectOtpName()//類別1名稱
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("value", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("name", Type.GetType("System.String"));

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr = dt.NewRow();
            dr["value"] = "01";
            dr["name"] = "訂閱";
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["value"] = "02";
            dr1["name"] = "贈閱";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["value"] = "03";
            dr2["name"] = "推廣";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["value"] = "09";
            dr3["name"] = "零售";
            dt.Rows.Add(dr3);

            return dt;

        }
    }
}