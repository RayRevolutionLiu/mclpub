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
    public class AdrGenXml_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetAdrPublishFileUp(string adr_addate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_get_adrpublish_fileup");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@adr_addate", adr_addate);
            oda.Fill(ds);
            return ds;
        }

        public DataSet GetAdrXmlData(string adr_addate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_get_adr_xml_data");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@adr_addate", adr_addate);
            oda.Fill(ds,"Ad");
            return ds;
        }

        public void UpdateXmlFileLog(string addate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c4_xmlfilelog SET xml_fgexist=0, xml_createdate=GETDATE() WHERE xml_date=@addate");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@addate", addate);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}