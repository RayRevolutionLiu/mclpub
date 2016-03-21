using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class RptFileUpQuery_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSrspns()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM srspn where (srspn_atype = 'B') OR (srspn_atype = 'C')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet SelectExcelList(string tbxSDate, string tbxEDate, string ddlEmpData, string ddlKeyword)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(*) AS adr_count, SUM(c4_adr.adr_impr) AS sum_impr, ");
            sb.Append(@"c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword ");
            sb.Append(@"FROM c4_adr INNER JOIN ");
            sb.Append(@"c4_cont ON c4_adr.adr_contno = c4_cont.cont_contno WHERE 1=1 ");
            if (tbxSDate.ToString().Trim() != "" && tbxEDate.ToString().Trim() != "")
            {
                sb.Append(@" AND (@tbxSDate <= adr_addate AND adr_addate <= @tbxEDate) ");
            }
            if (ddlEmpData != "")
            {
                sb.Append(@" AND cont_empno=@ddlEmpData ");
            }
            if (ddlKeyword != "")
            {
                sb.Append(@" AND adr_keyword=@ddlKeyword ");
            }
            //sb.Append(@"");
            sb.Append(@"GROUP BY  c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword ");
            sb.Append(@"ORDER BY  c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@tbxSDate", Convert.ToDateTime(tbxSDate) == null ? "" : tbxSDate.Substring(0, 4) + tbxSDate.Substring(5, 2) + tbxSDate.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@tbxEDate", Convert.ToDateTime(tbxEDate) == null ? "" : tbxEDate.Substring(0, 4) + tbxEDate.Substring(5, 2) + tbxEDate.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@ddlEmpData", ddlEmpData);
            oCmd.Parameters.AddWithValue("@ddlKeyword", ddlKeyword);
            oda.Fill(ds);
            return ds;
        }
    }
}