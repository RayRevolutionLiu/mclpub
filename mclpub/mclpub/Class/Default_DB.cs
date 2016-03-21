using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class Default_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectindexSp_Inquiry(string STRtbxCompany, string STRtbxcontno, string STRtbxCname)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"indexSp_Inquiry");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@CompanyName", STRtbxCompany.ToUpper());
            oCmd.Parameters.AddWithValue("@CustName", STRtbxcontno.ToUpper());
            oCmd.Parameters.AddWithValue("@Cust_nm", STRtbxCname.ToUpper());
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}