using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class CustDetail_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectAll()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.tmp_cust1.od_syscd, dbo.tmp_cust1.od_custno");
            sb.Append(@", dbo.tmp_cust1.od_otp1cd, dbo.tmp_cust1.od_otp1seq, dbo.tmp_cust1.begin_end, dbo.tmp_cust1.otp_otp1nm, dbo.tmp_cust1.otp_otp2nm, dbo.tmp_cust1.obtp_obtpnm");
            sb.Append(@", dbo.tmp_cust1.ra_oditem, dbo.tmp_cust1.ra_oritem, dbo.c1_or.or_nm, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq");
            sb.Append(@", dbo.c1_or.or_syscd FROM dbo.tmp_cust1 INNER JOIN dbo.c1_or ON dbo.tmp_cust1.od_syscd = dbo.c1_or.or_syscd AND dbo.tmp_cust1.od_custno = dbo.c1_or.or_custno");
            sb.Append(@" AND dbo.tmp_cust1.od_otp1cd = dbo.c1_or.or_otp1cd AND dbo.tmp_cust1.od_otp1seq = dbo.c1_or.or_otp1seq AND dbo.tmp_cust1.ra_oritem = dbo.c1_or.or_oritem");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_od");
            return ds;

        }


        public void delete(string custno, string otp1cd, string otp1seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"dbo.sp_c1_cancel_order";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", "C1");
            oCmd.Parameters.AddWithValue("@custno", custno);
            oCmd.Parameters.AddWithValue("@otp1cd", otp1cd);
            oCmd.Parameters.AddWithValue("@otp1seq", otp1seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void deleteTmp(string custno, string otp1cd, string otp1seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM dbo.tmp_cust1 WHERE (od_syscd = @od_syscd) AND (od_custno = @od_custno) AND (od_otp1cd = @od_otp1cd) AND (od_otp1seq = @od_otp1seq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@od_syscd", "C1");
            oCmd.Parameters.AddWithValue("@od_custno", custno);
            oCmd.Parameters.AddWithValue("@od_otp1cd", otp1cd);
            oCmd.Parameters.AddWithValue("@od_otp1seq", otp1seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}
