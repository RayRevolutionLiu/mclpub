using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class PubSearchCust_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable SelectComp(string mfrno, string company)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mfr_mfrid, mfr_mfrno, mfr_inm FROM mfr WHERE 1=1 ");
            if (mfrno.ToString() != "")
            {
                sb.Append(@"and mfr_mfrno=@mfrno ");
            }
            if (company.ToString() != "")
            {
                sb.Append(@"and mfr_inm=@company ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@mfrno", mfrno);
            oCmd.Parameters.AddWithValue("@company", company);

            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectC1cust(string tbxMfrnoSearch, string tbxCustNo, string tbxCustName,string CompanyName)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cust_custid, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_regdate, cust_moddate, cust_fgoi, cust_fgoe");
            sb.Append(@" FROM c1_cust INNER JOIN mfr ON c1_cust.cust_mfrno=mfr.mfr_mfrno WHERE 1=1 ");
            if (tbxMfrnoSearch.ToString() != "")
            {
                sb.Append(@"and cust_mfrno=@cust_mfrno ");
            }
            if (tbxCustNo.ToString() != "")
            {
                sb.Append(@"and cust_custno=@cust_custno ");
            }
            if (tbxCustName.ToString() != "")
            {
                sb.Append(@"and cust_nm LIKE '%'+@cust_nm+'%'");
            }
            if (CompanyName.ToString() != "")
            {
                sb.Append(@"and mfr_inm LIKE '%'+@mfr_inm+'%'");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@cust_mfrno", tbxMfrnoSearch);
            oCmd.Parameters.AddWithValue("@cust_custno", tbxCustNo);
            oCmd.Parameters.AddWithValue("@cust_nm", tbxCustName);
            oCmd.Parameters.AddWithValue("@mfr_inm", CompanyName);
            oda.Fill(ds);
            return ds;

        }
    }
}
