using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class MfrSearch_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable SelectComp(string mfrno, string company)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mfr_mfrid, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, mfr_respnm, mfr_respjbti, mfr_tel, mfr_fax, mfr_regdate FROM mfr WHERE 1=1 ");
            if (mfrno.ToString() != "")
            {
                sb.Append(@"and mfr_mfrno like '%'+@mfrno+'%' ");
            }
            if (company.ToString() != "")
            {
                sb.Append(@"and mfr_inm like '%'+@company+'%' ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@mfrno", mfrno);
            oCmd.Parameters.AddWithValue("@company", company);
            //oCmd.Parameters.AddWithValue("@TXcust_custno", TXcust_custno);
            //oCmd.Parameters.AddWithValue("@TXmfr_inm", TXmfr_inm);
            //oCmd.Parameters.AddWithValue("@TXcust_mfrno", TXcust_mfrno);
            //oCmd.Parameters.AddWithValue("@TXcust_tel", TXcust_tel);
            //oCmd.Parameters.AddWithValue("@TXcust_srspn_empno", TXcust_srspn_empno);
            //oCmd.Parameters.AddWithValue("@cust_srspn_empno", cust_srspn_empno);
            oda.Fill(ds);
            return ds;

        }
    }
}
