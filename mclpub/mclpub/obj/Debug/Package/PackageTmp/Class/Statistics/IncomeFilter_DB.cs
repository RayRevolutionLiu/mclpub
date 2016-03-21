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
    public class IncomeFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_obtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selecttmp_statistics()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.tmp_statistics.tmp_otp1cd, dbo.tmp_statistics.tmp_otp2cd, dbo.tmp_statistics.tmp_btpcd, dbo.tmp_statistics.tmp_param1, dbo.tmp_statistics.tmp_param2, dbo.c1_otp.otp_otp1nm,");
            sb.Append(@" dbo.c1_otp.otp_otp2nm, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obtp.obtp_otp1cd, dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd FROM dbo.tmp_statistics");
            sb.Append(@" INNER JOIN dbo.c1_otp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND dbo.tmp_statistics.tmp_otp2cd COLLATE");
            sb.Append(@" Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd INNER JOIN dbo.c1_obtp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS");
            sb.Append(@" = dbo.c1_obtp.obtp_otp1cd AND dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_obtpcd");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        /// <summary>
        /// 匯出EXCEL的SELECT COMMAND還多JOIN了一個proj 所以額外寫過
        /// </summary>
        /// <returns></returns>
        public DataSet Selecttmp_statisticsEXCEL()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.c1_obtp.obtp_obtpnm, dbo.proj.proj_projno ");
            sb.Append(@"FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON ");
            sb.Append(@"dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND ");
            sb.Append(@"dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd INNER JOIN ");
            sb.Append(@"dbo.c1_obtp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_otp1cd ");
            sb.Append(@"AND dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_obtpcd ");
            sb.Append(@"INNER JOIN dbo.proj ON dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.proj.proj_bkcd ");
            sb.Append(@"WHERE (dbo.proj.proj_syscd = 'C1') AND (dbo.proj.proj_fgitri = '')	");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void sp_c1_tmp_income1(string date1, string date2, string projno, string otp1cd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c1_tmp_income1";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@date1", date1);
            oCmd.Parameters.AddWithValue("@date2", date2);
            oCmd.Parameters.AddWithValue("@projno", projno);
            oCmd.Parameters.AddWithValue("@otp1cd", otp1cd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}