using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class RptIncomeQuery_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSrspns()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname FROM srspn where (srspn_atype = 'B') OR (srspn_atype = 'C')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }

        public DataSet SelectAll(string tbxSDate, string tbxEDate,string cont_empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MIN(c4_adr.adr_addate) AS sdate, MAX(c4_adr.adr_addate) AS edate, ");
            sb.Append(@"c4_adr.adr_contno, COUNT(*) AS adr_count, SUM(c4_adr.adr_invamt) ");
            sb.Append(@"AS sum_invamt, SUM(c4_adr.adr_adamt) AS sum_adamt, ");
            sb.Append(@"SUM(c4_adr.adr_desamt) AS sum_desamt, SUM(c4_adr.adr_chgamt) ");
            sb.Append(@"AS sum_chgamt, mfr.mfr_inm FROM c4_adr INNER JOIN ");
            sb.Append(@"c4_cont ON c4_adr.adr_contno = c4_cont.cont_contno INNER JOIN ");
            sb.Append(@"mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') ");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");

            if (tbxSDate != "" && tbxEDate!="")
            {
                sb.Append(@" AND ( @tbxSDate <= adr_addate AND adr_addate <= @tbxEDate )");
            }
            if (cont_empno != "")
            {
                sb.Append(@" AND (cont_empno = @cont_empno) ");
            }

            sb.Append(@"GROUP BY  c4_adr.adr_contno, mfr.mfr_inm ORDER BY  c4_adr.adr_contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@tbxSDate", tbxSDate);
            oCmd.Parameters.AddWithValue("@tbxEDate", tbxEDate);
            oCmd.Parameters.AddWithValue("@cont_empno", cont_empno);
            oda.Fill(ds);
            return ds;
        }
    }
}