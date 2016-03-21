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
    public class RemailFM_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_otp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT otp_otp1cd, otp_otp1nm FROM dbo.c1_otp ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc1_cust()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_cust.cust_custid, dbo.c1_cust.cust_custno, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm");
            sb.Append(@", dbo.mfr.mfr_mfrid, dbo.mfr.mfr_mfrno FROM dbo.c1_cust INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc1_or()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_or.or_orid, dbo.c1_or.or_syscd, dbo.c1_or.or_custno, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq");
            sb.Append(@", dbo.c1_or.or_oritem, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_addr, dbo.c1_ramt.ra_mnt, dbo.c1_ramt.ra_custno, dbo.c1_ramt.ra_oditem, dbo.c1_ramt.ra_oritem");
            sb.Append(@", dbo.c1_ramt.ra_otp1cd, dbo.c1_ramt.ra_otp1seq, dbo.c1_ramt.ra_syscd FROM dbo.c1_or INNER JOIN dbo.c1_ramt ON dbo.c1_or.or_syscd = dbo.c1_ramt.ra_syscd AND dbo.c1_or.or_custno");
            sb.Append(@" = dbo.c1_ramt.ra_custno AND dbo.c1_or.or_otp1cd = dbo.c1_ramt.ra_otp1cd AND dbo.c1_or.or_otp1seq = dbo.c1_ramt.ra_otp1seq WHERE (dbo.c1_or.or_syscd = 'C1')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc1_remail()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT rm_rmid, rm_syscd, rm_custno, rm_otp1cd, rm_otp1seq, rm_oritem, rm_seq, rm_cont, rm_date, rm_fgsent, rm_sdate, rm_edate FROM dbo.c1_remail WHERE (rm_syscd = 'C1')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Updatec1_remail(string rm_syscd, string rm_custno, string rm_otp1cd, string rm_otp1seq, string rm_oritem, string rm_seq, string rm_cont,
            string rm_date, string rm_fgsent, string rm_sdate, string rm_edate, string Original_rm_custno, string Original_rm_oritem, string Original_rm_otp1cd, string Original_rm_otp1seq,
            string Original_rm_syscd, string Original_rm_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE dbo.c1_remail SET rm_syscd = @rm_syscd, rm_custno = @rm_custno, rm_otp1cd = @rm_otp1cd, rm_otp1seq = @rm_otp1seq, rm_oritem = @rm_oritem, rm_seq = @rm_seq, rm_cont = @rm_cont, rm_date = @rm_date, rm_fgsent = @rm_fgsent, rm_sdate = @rm_sdate, rm_edate = @rm_edate WHERE (rm_custno = @Original_rm_custno) AND (rm_oritem = @Original_rm_oritem) AND (rm_otp1cd = @Original_rm_otp1cd) AND (rm_otp1seq = @Original_rm_otp1seq) AND (rm_syscd = @Original_rm_syscd) AND (rm_seq = @Original_rm_seq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_syscd", rm_syscd);
            oCmd.Parameters.AddWithValue("@rm_custno", rm_custno);
            oCmd.Parameters.AddWithValue("@rm_otp1cd", rm_otp1cd);
            oCmd.Parameters.AddWithValue("@rm_otp1seq", rm_otp1seq);
            oCmd.Parameters.AddWithValue("@rm_oritem", rm_oritem);
            oCmd.Parameters.AddWithValue("@rm_seq", rm_seq);
            oCmd.Parameters.AddWithValue("@rm_cont", rm_cont);
            oCmd.Parameters.AddWithValue("@rm_date", rm_date);
            oCmd.Parameters.AddWithValue("@rm_fgsent", rm_fgsent);
            oCmd.Parameters.AddWithValue("@rm_sdate", rm_sdate);
            oCmd.Parameters.AddWithValue("@rm_edate", rm_edate);
            oCmd.Parameters.AddWithValue("@Original_rm_custno", Original_rm_custno);
            oCmd.Parameters.AddWithValue("@Original_rm_oritem", Original_rm_oritem);
            oCmd.Parameters.AddWithValue("@Original_rm_otp1cd", Original_rm_otp1cd);
            oCmd.Parameters.AddWithValue("@Original_rm_otp1seq", Original_rm_otp1seq);
            oCmd.Parameters.AddWithValue("@Original_rm_syscd", Original_rm_syscd);
            oCmd.Parameters.AddWithValue("@Original_rm_seq", Original_rm_seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}