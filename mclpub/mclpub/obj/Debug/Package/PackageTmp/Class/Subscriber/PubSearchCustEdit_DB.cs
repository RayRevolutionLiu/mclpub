using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;


namespace mclpub
{
    public class PubSearchCustEdit_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public void InsertCustEdit(string cust_btpcd, string cust_custno, string cust_nm, string cust_jbti, string cust_mfrno, string cust_tel, string cust_fax, string cust_cell, string cust_email, string cust_regdate, string cust_moddate, string cust_fgoi,string cust_fgoe, string cust_otp1seq1, string cust_otp1seq2, string cust_otp1seq3, string cust_otp1seq9, string cust_itpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO c1_cust(cust_btpcd, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_fgoi, cust_fgoe, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9, cust_itpcd)");
            sb.Append(@" VALUES ");
            sb.Append(@"(@cust_btpcd, @cust_custno, @cust_nm, @cust_jbti, @cust_mfrno, @cust_tel, @cust_fax, @cust_cell, @cust_email, @cust_regdate, @cust_moddate, @cust_fgoi, @cust_fgoe, @cust_otp1seq1, @cust_otp1seq2, @cust_otp1seq3, @cust_otp1seq9, @cust_itpcd)");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cust_btpcd", cust_btpcd);
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oCmd.Parameters.AddWithValue("@cust_nm", cust_nm);
            oCmd.Parameters.AddWithValue("@cust_jbti", cust_jbti);
            oCmd.Parameters.AddWithValue("@cust_mfrno", cust_mfrno);
            oCmd.Parameters.AddWithValue("@cust_tel", cust_tel);
            oCmd.Parameters.AddWithValue("@cust_fax", cust_fax);
            oCmd.Parameters.AddWithValue("@cust_cell", cust_cell);
            oCmd.Parameters.AddWithValue("@cust_email", cust_email);
            oCmd.Parameters.AddWithValue("@cust_regdate", cust_regdate);
            oCmd.Parameters.AddWithValue("@cust_moddate", cust_moddate);
            oCmd.Parameters.AddWithValue("@cust_fgoi", cust_fgoi);
            oCmd.Parameters.AddWithValue("@cust_fgoe", cust_fgoe);
            oCmd.Parameters.AddWithValue("@cust_otp1seq1", cust_otp1seq1);
            oCmd.Parameters.AddWithValue("@cust_otp1seq2", cust_otp1seq2);
            oCmd.Parameters.AddWithValue("@cust_otp1seq3", cust_otp1seq3);
            oCmd.Parameters.AddWithValue("@cust_otp1seq9", cust_otp1seq9);
            oCmd.Parameters.AddWithValue("@cust_itpcd", cust_itpcd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataTable CreateNewCustno()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MAX(cust_custno) AS maxcustno FROM c1_cust");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            //oCmd.Parameters.AddWithValue("@mfrno", mfrno);
            //oCmd.Parameters.AddWithValue("@company", company);

            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectAllC1_Cust(string cust_custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM c1_cust WHERE cust_custno=@cust_custno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            //oCmd.Parameters.AddWithValue("@company", company);

            oda.Fill(ds);
            return ds;

        }


        public void EditCustEdit(string cust_btpcd, string cust_custno, string cust_nm, string cust_jbti, string cust_mfrno, string cust_tel, string cust_fax, string cust_cell, string cust_email, string cust_regdate, string cust_moddate, string cust_itpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c1_cust SET cust_custno = @cust_custno, cust_nm = @cust_nm, cust_jbti = @cust_jbti, cust_mfrno = @cust_mfrno, cust_tel = @cust_tel,");
            sb.Append(@"cust_fax = @cust_fax, cust_cell = @cust_cell, cust_email = @cust_email, cust_regdate = @cust_regdate, cust_moddate = @cust_moddate, cust_itpcd = @cust_itpcd, cust_btpcd = @cust_btpcd ");
            sb.Append(@"WHERE (cust_custno = @cust_custno)");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cust_btpcd", cust_btpcd);
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oCmd.Parameters.AddWithValue("@cust_nm", cust_nm);
            oCmd.Parameters.AddWithValue("@cust_jbti", cust_jbti);
            oCmd.Parameters.AddWithValue("@cust_mfrno", cust_mfrno);
            oCmd.Parameters.AddWithValue("@cust_tel", cust_tel);
            oCmd.Parameters.AddWithValue("@cust_fax", cust_fax);
            oCmd.Parameters.AddWithValue("@cust_cell", cust_cell);
            oCmd.Parameters.AddWithValue("@cust_email", cust_email);
            oCmd.Parameters.AddWithValue("@cust_regdate", cust_regdate);
            oCmd.Parameters.AddWithValue("@cust_moddate", cust_moddate);
            oCmd.Parameters.AddWithValue("@cust_itpcd", cust_itpcd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}
