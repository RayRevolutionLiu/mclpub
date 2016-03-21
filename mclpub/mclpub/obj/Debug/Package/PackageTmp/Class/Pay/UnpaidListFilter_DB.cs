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
    public class UnpaidListFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectv_ia_unpaid(string tbxProj, string tbxDate1, string tbxDate2, string tbxMfrno, string tbxMfrname,string tbxInvno, string tbxIano,string type)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM dbo.v_ia_unpaid ");
            if (type == "excel")
            {
                sb.Append(@" INNER JOIN dbo.srspn ON dbo.v_ia_unpaid.ias_createmen = dbo.srspn.srspn_empno ");
            }
            sb.Append(@" WHERE 1=1 ");

            if (tbxProj.ToString().Trim() != "")
            {
                sb.Append(@" AND iad_projno = @tbxProj");
            }
            if (tbxDate1.ToString().Trim() != "" && tbxDate2.ToString().Trim() != "")
            {
                sb.Append(@" AND (ia_invdate >= @tbxDate1 AND ia_invdate <= @tbxDate2) ");
            }
            if (tbxMfrno.ToString().Trim() != "")
            {
                sb.Append(@" AND ia_mfrno = @tbxMfrno ");
            }
            if (tbxMfrname.ToString().Trim() != "")
            {
                sb.Append(@" AND mfr_inm LIKE '%'+@tbxMfrname+'%' ");
            }
            if (tbxInvno.ToString().Trim() != "")
            {
                sb.Append(@" AND ia_invno = @tbxInvno ");
            }
            if (tbxIano.ToString().Trim() != "")
            {
                sb.Append(@" AND ia_iano = @tbxIano ");
            }
            sb.Append(@"ORDER BY ia_invdate ASC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@tbxProj", tbxProj);
            oCmd.Parameters.AddWithValue("@tbxDate1", tbxDate1);
            oCmd.Parameters.AddWithValue("@tbxDate2", tbxDate2);
            oCmd.Parameters.AddWithValue("@tbxMfrno", tbxMfrno);
            oCmd.Parameters.AddWithValue("@tbxMfrname", tbxMfrname);
            oCmd.Parameters.AddWithValue("@tbxInvno", tbxInvno);
            oCmd.Parameters.AddWithValue("@tbxIano", tbxIano);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}