using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Collections;

namespace mclpub
{
    public class RptAdrBillQuery_DB
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
            //oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }

        public DataSet ExportExcel(string tbxMfrName, string tbxSDate, string tbxEDate, string ddlEmpData, string ddlKeyword)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_adr.*, c4_cont.cont_mfrno, mfr.mfr_inm, c4_cont.cont_empno, srspn.srspn_cname ");
            sb.Append(@"FROM c4_adr INNER JOIN ");
            sb.Append(@"c4_cont ON c4_adr.adr_syscd = c4_cont.cont_syscd AND  ");
            sb.Append(@"c4_adr.adr_contno = c4_cont.cont_contno INNER JOIN ");
            sb.Append(@"srspn ON c4_cont.cont_empno = srspn.srspn_empno INNER JOIN ");
            sb.Append(@"mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') ");
            if (tbxMfrName != "")
            {
                sb.Append(@" AND mfr_inm Like '%'+@tbxMfrName+'%' ");
            }
            if (tbxSDate != "" && tbxEDate != "")
            {
                DateTime sdate;
                DateTime edate;
                sdate = DateTime.ParseExact(tbxSDate, "yyyy/MM/dd", null);
                edate = DateTime.ParseExact(tbxEDate, "yyyy/MM/dd", null);
                sb.Append(@" AND @tbxSDate <= adr_addate AND adr_addate<= @tbxEDate ");
            }
            else if (tbxSDate!= "")
            {
                sb.Append(@" AND @tbxSDate <= adr_addate ");
            }
            else if (tbxEDate != "")
            {
                sb.Append(@" AND adr_addate <= @tbxEDate ");
            }
            if (ddlEmpData != "")
            {
                sb.Append(@" AND cont_empno=@ddlEmpData ");
            }
            if (ddlKeyword != "")
            {
                sb.Append(@" AND adr_keyword=@ddlKeyword ");
            }
            sb.Append(@" ORDER BY c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword, c4_adr.adr_contno ");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@tbxMfrName", tbxMfrName);
            oCmd.Parameters.AddWithValue("@tbxSDate", Convert.ToDateTime(tbxSDate) == null ? "" : tbxSDate.Substring(0, 4) + tbxSDate.Substring(5, 2) + tbxSDate.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@tbxEDate", Convert.ToDateTime(tbxEDate) == null ? "" : tbxEDate.Substring(0, 4) + tbxEDate.Substring(5, 2) + tbxEDate.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@ddlEmpData", ddlEmpData);
            oCmd.Parameters.AddWithValue("@ddlKeyword", ddlKeyword);
            oda.Fill(ds);
            return ds;
        }


        public DataSet ExportExcelRptAdrQuery(string tbxMfrName, string tbxSDate, string tbxEDate, string ddlEmpData)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT wk_c4_adrlist.*, srspn.srspn_cname, v_c4_sum_adr_amt.sum_invamt ");
            sb.Append(@"FROM wk_c4_adrlist LEFT OUTER JOIN ");
            sb.Append(@"v_c4_sum_adr_amt ON ");
            sb.Append(@"wk_c4_adrlist.cont_contno = v_c4_sum_adr_amt.adr_contno LEFT OUTER JOIN ");
            sb.Append(@"srspn ON ");
            sb.Append(@"wk_c4_adrlist.cont_empno COLLATE Chinese_Taiwan_Stroke_CI_AS = srspn.srspn_empno ");
            sb.Append(@"WHERE adr_sdate <> ''");
            if (tbxMfrName != "")
            {
                sb.Append(@" AND mfr_inm Like '%'+@tbxMfrName+'%' ");
            }
            if (tbxSDate != "" && tbxEDate != "")
            {
                DateTime sdate;
                DateTime edate;
                sdate = DateTime.ParseExact(tbxSDate, "yyyy/MM/dd", null);
                edate = DateTime.ParseExact(tbxEDate, "yyyy/MM/dd", null);
                sb.Append(@" AND @tbxSDate <= adr_addate AND adr_addate<= @tbxEDate ");
            }
            else if (tbxSDate != "")
            {
                sb.Append(@" AND @tbxSDate <= adr_addate ");
            }
            else if (tbxEDate != "")
            {
                sb.Append(@" AND adr_addate <= @tbxEDate ");
            }
            if (ddlEmpData != "")
            {
                sb.Append(@" AND cont_empno=@ddlEmpData ");
            }

            sb.Append(@" ORDER BY cont_contno, adr_seq ");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@tbxMfrName", tbxMfrName);
            oCmd.Parameters.AddWithValue("@tbxSDate", tbxSDate);
            oCmd.Parameters.AddWithValue("@tbxEDate", tbxEDate);
            oCmd.Parameters.AddWithValue("@ddlEmpData", ddlEmpData);
            oda.Fill(ds);
            return ds;
        }


        public DataSet RptAdrList(string sdate, string edate, string tbxMfrName, string ddlEmpData)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c4_rp_adrlist";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@sdate", sdate);
            oCmd.Parameters.AddWithValue("@edate", edate);

            if (tbxMfrName.ToString().Trim() != "")
            {
                oCmd.Parameters.AddWithValue("@tbxMfrName", tbxMfrName);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@tbxMfrName", DBNull.Value);
            }

            if (ddlEmpData.ToString().Trim() != "")
            {
                oCmd.Parameters.AddWithValue("@ddlEmpData", ddlEmpData);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@ddlEmpData", DBNull.Value);
            }
            oda.Fill(ds);
            return ds;
        }

    }
}