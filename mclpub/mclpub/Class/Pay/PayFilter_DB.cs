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
    public class PayFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectia(string keyword)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iano, dbo.ia.ia_mfrno, dbo.ia.ia_pyat, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrno, dbo.ia.ia_refno FROM dbo.ia INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_pyno = '') ");
            if (keyword != "")
            {
                sb.Append(@" AND (LOWER(ia_refno) LIKE '%'+@keyword+'%' ");
                sb.Append(@" OR LOWER(ia_mfrno) LIKE '%'+@keyword+'%' ");
                sb.Append(@" OR LOWER(mfr_inm) LIKE '%'+@keyword+'%' ");
                sb.Append(@" OR LOWER(ia_rnm) LIKE '%'+@keyword+'%' ");
                sb.Append(@" OR LOWER(ia_pyat) LIKE '%'+@keyword+'%') ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}