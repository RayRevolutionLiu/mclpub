using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class SetRecForm_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectMtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpid, mtp_mtpcd, mtp_nm FROM dbo.mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}
