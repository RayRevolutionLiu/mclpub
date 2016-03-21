using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class ContCanceled_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetContCanceled()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM c4_cont INNER JOIN cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '1')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }

        public bool UpdateContRecoverCanceled(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "UPDATE c4_cont SET cont_fgcancel='0' WHERE cont_contno=@cont_contno";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oCmd.Connection.Open();
            int num = oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            if (num != 1)
            {
                return false;
            }
            return true;

        }


    }
}
