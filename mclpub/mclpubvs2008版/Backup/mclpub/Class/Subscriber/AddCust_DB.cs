using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class AddCust_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelectAllComp(string mfr_inm, string mfr_mfrno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from mfr where 1=1 ");
            if (mfr_inm.ToString() != "")
            {
                sb.Append(@"AND mfr_inm LIKE '%'+@mfr_inm+'%' ");
            }
            if (mfr_mfrno.ToString() != "")
            {
                sb.Append(@"AND mfr_mfrno LIKE '%'+@mfr_mfrno+'%' ");
            }
            sb.Append(@"order by mfr_inm");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }
    }
}
