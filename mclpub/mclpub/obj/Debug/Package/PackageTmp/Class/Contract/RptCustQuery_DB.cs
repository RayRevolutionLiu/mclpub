using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class RptCustQuery_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable GetClass2(int cls1id)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM c4_class2 WHERE cls2_cls1id=@cls2_cls1id");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cls2_cls1id", cls1id);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable GetSrspns()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM srspn where (srspn_atype = 'B') OR (srspn_atype = 'C')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectChkBtn(string strddlContType, string strtbxSDate, string strtbxEDate, string strddlClass1, string strddlClass2, string strddlEmpData, string strddlClosed)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.*, ISNULL(wk_c4_atpstring.wkatp_atpstr, '') AS wkatp_atpstr,");
            sb.Append(@"ISNULL(wk_c4_fbkstring.wkfbk_fbkstr, '') AS wkfbk_fbkstr, ");
            sb.Append(@"mfr.mfr_inm, srspn.srspn_cname, ISNULL(wk_c4_matpstring.wkmatp_matpstr, '') AS wkmatp_matpstr ");
            sb.Append(@"FROM c4_cont INNER JOIN ");
            sb.Append(@"mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ");
            sb.Append(@"srspn ON c4_cont.cont_empno = srspn.srspn_empno LEFT OUTER JOIN ");
            sb.Append(@"wk_c4_fbkstring ON ");
            sb.Append(@"c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_fbkstring.wkfbk_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_matpstring ON ");
            sb.Append(@"c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_matpstring.wkmatp_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_atpstring ON ");
            sb.Append(@"c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_atpstring.wkatp_contno ");
            sb.Append(@"WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') ");
            if (strddlContType.ToString() != "")
            {
                sb.Append(@" AND cont_conttp=@cont_conttp ");
            }
            if (strtbxEDate.ToString() != "" && strtbxEDate.ToString() != "")
            {
                sb.Append(@" AND ((cont_sdate<=@strtbxSDate AND cont_edate>=@strtbxSDate) OR (cont_sdate>=@strtbxSDate AND cont_sdate<=@strtbxEDate)) ");
            }
            if (strddlClass1.ToString() != "")
            {
                sb.Append(@" AND wkmatp_matpstr LIKE '%'+@strddlClass1+'%' ");
            }
            if (strddlClass2.ToString() != "")
            {
                sb.Append(@" AND wkatp_atpstr LIKE '%'+@strddlClass2+'%' ");
            }
            if (strddlEmpData.ToString() != "")
            {
                sb.Append(@" AND cont_empno=@strddlEmpData ");
            }
            if (strddlClosed.ToString() != "")
            {
                sb.Append(@" AND cont_fgclosed=@strddlClosed ");
            }
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_conttp", strddlContType);
            oCmd.Parameters.AddWithValue("@strtbxSDate", strtbxSDate);
            oCmd.Parameters.AddWithValue("@strtbxEDate", strtbxEDate);
            oCmd.Parameters.AddWithValue("@strddlClass1", strddlClass1);
            oCmd.Parameters.AddWithValue("@strddlClass2", strddlClass2);
            oCmd.Parameters.AddWithValue("@strddlEmpData", strddlEmpData);
            oCmd.Parameters.AddWithValue("@strddlClosed", strddlClosed);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }



        public DataTable PayedMoney(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia WHERE (ia_syscd = 'C4') AND (SUBSTRING(ia_contno, 3, 6) = @cont_contno) AND (ia.ia_pyno <> '') GROUP BY  ia_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable CountDateSandE(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MIN(adr_addate) AS sdate, MAX(adr_addate) AS edate FROM c4_adr WHERE (adr_contno = @cont_contno) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }
    }
}
