using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class cont_list_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelectBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND proj_fgitri=''");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel");
            sb.Append(@", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srspn_empno");
            sb.Append(@" FROM dbo.srspn WHERE (srspn_atype <> 'A') AND (srspn_atype <> 'F')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectChkBtn(string strBkcd, string strEmpNo, string strSignDate1, string strSignDate2, string strStartDate, string strEndDate, string strfgClosed,string strMfrIName)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.c2_cont.cont_aunm");
            sb.Append(@", dbo.c2_cont.cont_autel, dbo.c2_cont.cont_aufax, dbo.c2_cont.cont_aucell, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_sdate");
            sb.Append(@", dbo.c2_cont.cont_edate, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_disc");
            sb.Append(@", dbo.c2_cont.cont_freetm, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_madejtm, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_pubtm, dbo.c2_cont.cont_resttm");
            sb.Append(@", dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_pubamt, dbo.c2_cont.cont_chgamt, dbo.c2_cont.cont_fgpayonce");
            sb.Append(@", RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, dbo.c2_cont.cont_fgcancel, RTRIM(dbo.c2_cont.cont_oldcontno) AS cont_oldcontno, dbo.c2_cont.cont_custno, RTRIM(dbo.cust.cust_nm)");
            sb.Append(@" AS cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_tel FROM dbo.c2_cont INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book");
            sb.Append(@" ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno WHERE (dbo.c2_cont.cont_fgtemp = '0')");
            sb.Append(@" AND cont_bkcd=@strBkcd");
            if (strEmpNo.ToString() != "000000")
            {
                sb.Append(@" AND cont_empno=@strEmpNo");
            }
            if (strSignDate1.ToString() != "" && strSignDate2 != "")
            {
                sb.Append(@" AND (cont_signdate >=@strSignDate1) AND (cont_signdate <= @strSignDate2)");
            }
            if (strStartDate.ToString() != "" && strEndDate.ToString() != "")
            {
                sb.Append(@" AND (cont_sdate >= @strStartDate) AND (cont_edate <= @strEndDate)");
            }
            if (strfgClosed.ToString() != "99")
            {
                sb.Append(@" AND (cont_fgclosed=@strfgClosed)");
            }
            if (strMfrIName.ToString() != "")
            {
                sb.Append(@" AND (mfr_inm like '%'+@strMfrIName+'%')");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@strBkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@strEmpNo", strEmpNo);
            oCmd.Parameters.AddWithValue("@strSignDate1", strSignDate1);
            oCmd.Parameters.AddWithValue("@strSignDate2", strSignDate2);
            oCmd.Parameters.AddWithValue("@strStartDate", strStartDate);
            oCmd.Parameters.AddWithValue("@strEndDate", strEndDate);
            oCmd.Parameters.AddWithValue("@strfgClosed", strfgClosed);
            oCmd.Parameters.AddWithValue("@strMfrIName", strMfrIName);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable Runsp_c2_contlist2_1(string strBkcd, string strEmpNo, string strSignDate1, string strSignDate2, string strStartDate, string strEndDate, string strfgClosed, string strMfrIName)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"dbo.[sp_c2_contlist2_1]";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", strBkcd);

            if (strEmpNo.ToString() == "000000")
            {
                oCmd.Parameters.AddWithValue("@strEmpNo", DBNull.Value);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@strEmpNo", strEmpNo);
            }
            if (strSignDate1.ToString() == "" && strSignDate2.ToString() == "")
            {
                oCmd.Parameters.AddWithValue("@strSignDate1", DBNull.Value);
                oCmd.Parameters.AddWithValue("@strSignDate2", DBNull.Value);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@strSignDate1", strSignDate1);
                oCmd.Parameters.AddWithValue("@strSignDate2", strSignDate2);
            }
            if (strStartDate.ToString() == "" && strEndDate.ToString() == "")
            {
                oCmd.Parameters.AddWithValue("@strStartDate", DBNull.Value);
                oCmd.Parameters.AddWithValue("@strEndDate", DBNull.Value);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@strStartDate", strStartDate);
                oCmd.Parameters.AddWithValue("@strEndDate", strEndDate);
            }
            if (strfgClosed.ToString() == "99")
            {
                oCmd.Parameters.AddWithValue("@strfgClosed", DBNull.Value);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@strfgClosed", strfgClosed);
            }
            if (strMfrIName.ToString() == "")
            {
                oCmd.Parameters.AddWithValue("@strMfrIName", DBNull.Value);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@strMfrIName", strMfrIName);
            }

            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

            //oCmd.Connection.Open();
            //oCmd.ExecuteNonQuery();
            //oCmd.Connection.Close();

        }


        public DataTable SelectChkBtn2(string strBkcd, string strEmpNo, string strSignDate1, string strSignDate2, string strStartDate, string strEndDate, string strfgClosed, string strMfrIName)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_signdate, ");
            sb.Append(@" c2_cont.cont_mfrno, RTRIM(mfr.mfr_inm) AS mfr_inm, c2_cont.cont_aunm, ");
            sb.Append(@" c2_cont.cont_autel, c2_cont.cont_aufax, c2_cont.cont_aucell, ");
            sb.Append(@" c2_cont.cont_bkcd, RTRIM(book.bk_nm) AS bk_nm, c2_cont.cont_conttp, ");
            sb.Append(@" substring(c2_cont.cont_sdate, 1, 4) + '/' + substring(c2_cont.cont_sdate, 4, 2) AS cont_sdate, ");
            sb.Append(@" substring(c2_cont.cont_edate, 1, 4) + '/' + substring(c2_cont.cont_edate, 4, 2) AS cont_edate, ");
            sb.Append(@" c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_clrtm, ");
            sb.Append(@" c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_clrtm, ");
            sb.Append(@" c2_cont.cont_getclrtm, c2_cont.cont_menotm, c2_cont.cont_fgclosed, ");
            sb.Append(@" c2_cont.cont_fgpubed, c2_cont.cont_disc, c2_cont.cont_freetm, ");
            sb.Append(@" c2_cont.cont_totjtm, c2_cont.cont_madejtm, c2_cont.cont_restjtm, ");
            sb.Append(@" c2_cont.cont_tottm, c2_cont.cont_pubtm, c2_cont.cont_resttm, ");
            sb.Append(@" c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, ");
            sb.Append(@" c2_cont.cont_pubamt, c2_cont.cont_chgamt, c2_cont.cont_fgpayonce, ");
            sb.Append(@" RTRIM(c2_cont.cont_empno) AS cont_empno, c2_cont.cont_fgcancel, ");
            sb.Append(@" RTRIM(c2_cont.cont_oldcontno) AS cont_oldcontno, c2_cont.cont_custno, ");
            sb.Append(@" RTRIM(cust.cust_nm) AS cust_nm, cust.cust_jbti, cust.cust_tel, cont_freebkcnt, ");
            sb.Append(@" cont_chgjtm, c2_contlist2.ornamestr, ");
            sb.Append(@" c2_contlist2.orfullnamestr ");
            sb.Append(@" FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ");
            sb.Append(@" book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN ");
            sb.Append(@" cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN ");
            sb.Append(@" c2_contlist2 ON c2_cont.cont_syscd COLLATE Chinese_Taiwan_Stroke_BIN = c2_contlist2.syscd ");
            sb.Append(@" AND c2_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = c2_contlist2.contno WHERE (c2_cont.cont_fgtemp = '0') ");
            sb.Append(@" AND cont_bkcd=@strBkcd");

            if (strEmpNo.ToString() != "000000")
            {
                sb.Append(@" AND cont_empno=@strEmpNo");
            }
            if (strSignDate1.ToString() != "" && strSignDate2 != "")
            {
                sb.Append(@" AND (cont_signdate >=@strSignDate1) AND (cont_signdate <= @strSignDate2)");
            }
            if (strStartDate.ToString() != "" && strEndDate.ToString() != "")
            {
                sb.Append(@" AND (cont_sdate >= @strStartDate) AND (cont_edate <= @strEndDate)");
            }
            if (strfgClosed.ToString() != "99")
            {
                sb.Append(@" AND (cont_fgclosed=@strfgClosed)");
            }
            if (strMfrIName.ToString() != "")
            {
                sb.Append(@" AND (mfr_inm like '%'+@strMfrIName+'%')");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@strBkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@strEmpNo", strEmpNo);
            oCmd.Parameters.AddWithValue("@strSignDate1", strSignDate1);
            oCmd.Parameters.AddWithValue("@strSignDate2", strSignDate2);
            oCmd.Parameters.AddWithValue("@strStartDate", strStartDate);
            oCmd.Parameters.AddWithValue("@strEndDate", strEndDate);
            oCmd.Parameters.AddWithValue("@strfgClosed", strfgClosed);
            oCmd.Parameters.AddWithValue("@strMfrIName", strMfrIName);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }
    }
}
