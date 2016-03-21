using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class Customer_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable SelectCustomerTable(string TXcust_nm, string TXcust_custno, string TXmfr_inm, string TXcust_mfrno,string TXcust_tel,string TXcust_srspn_empno,string pwerRowData, string cust_srspn_empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            if (pwerRowData.ToString().Trim() != "D")
            {
                sb.Append(@"SELECT cust.*, srspn_cname,mfr_mfrno,mfr_inm AS mfr_inm FROM cust INNER JOIN mfr ON cust_mfrno = mfr_mfrno INNER JOIN srspn ON cust_srspn_empno = srspn_empno ");
            }
            else
            {
                sb.Append(@"SELECT cust.*, srspn_cname,mfr_mfrno,mfr_inm AS mfr_inm FROM cust INNER JOIN mfr ON cust_mfrno = mfr_mfrno INNER JOIN srspn ON cust_srspn_empno = srspn_empno and cust_srspn_empno=@cust_srspn_empno ");
            }

            if (TXcust_nm.ToString() != "")
            {
                sb.Append(@"and cust_nm like '%'+@TXcust_nm+'%' ");
            }
            if (TXcust_custno.ToString() != "")
            {
                sb.Append(@"and cust_custno like '%'+@TXcust_custno+'%' ");
            }
            if (TXmfr_inm.ToString() != "")
            {
                sb.Append(@"and mfr_inm like '%'+@TXmfr_inm+'%' ");
            }
            if (TXcust_mfrno.ToString() != "")
            {
                sb.Append(@"and cust_mfrno like '%'+@TXcust_mfrno+'%' ");
            }
            if (TXcust_tel.ToString() != "")
            {
                sb.Append(@"and cust_tel like '%'+@TXcust_tel+'%' ");
            }
            if (TXcust_srspn_empno.ToString() != "")
            {
                sb.Append(@"and (cust_srspn_empno like '%'+@TXcust_srspn_empno+'%' OR srspn_cname like '%'+@TXcust_srspn_empno+'%') ");
            }

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@TXcust_nm", TXcust_nm);
            oCmd.Parameters.AddWithValue("@TXcust_custno", TXcust_custno);
            oCmd.Parameters.AddWithValue("@TXmfr_inm", TXmfr_inm);
            oCmd.Parameters.AddWithValue("@TXcust_mfrno", TXcust_mfrno);
            oCmd.Parameters.AddWithValue("@TXcust_tel", TXcust_tel);
            oCmd.Parameters.AddWithValue("@TXcust_srspn_empno", TXcust_srspn_empno);
            oCmd.Parameters.AddWithValue("@cust_srspn_empno", cust_srspn_empno);
            oda.Fill(ds);
            return ds;

        }


        public void DelCust(string cust_custid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from cust where cust_custid=@cust_custid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cust_custid", cust_custid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}
