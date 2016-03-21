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
    public class BookMntFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selecttmp_statistics()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.tmp_statistics.tmp_otp1cd, dbo.tmp_statistics.tmp_otp2cd, dbo.tmp_statistics.tmp_btpcd, ");
            sb.Append(@"dbo.tmp_statistics.tmp_param1, dbo.tmp_statistics.tmp_param2, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, ");
            sb.Append(@"dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd, dbo.mtp.mtp_nm, dbo.mtp.mtp_mtpcd FROM dbo.tmp_statistics LEFT ");
            sb.Append(@"OUTER JOIN dbo.c1_otp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = ");
            sb.Append(@"dbo.c1_otp.otp_otp1cd AND dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = ");
            sb.Append(@"dbo.c1_otp.otp_otp2cd INNER JOIN dbo.mtp ON dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS ");
            sb.Append(@"= dbo.mtp.mtp_mtpcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void sp_c1_tmp_statistics(string type, string btpcd, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c1_tmp_statistics";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@type", type);
            oCmd.Parameters.AddWithValue("@btpcd", btpcd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet Selecttmp_statisticsForExcel1to5(int type,string page)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            if (page == "book_mnt1")
            {
                sb.Append(@"SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm ");
                sb.Append(@"FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON ");
                sb.Append(@"dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND ");
                sb.Append(@"dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd ");
                sb.Append(@"WHERE (dbo.tmp_statistics.tmp_param2 = @type) ");
            }
            else
            {
                sb.Append(@"SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.mtp.mtp_nm ");
                sb.Append(@"FROM dbo.tmp_statistics LEFT OUTER JOIN dbo.c1_otp ON ");
                sb.Append(@"dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND ");
                sb.Append(@"dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd ");
                sb.Append(@"INNER JOIN dbo.mtp ON  dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.mtp.mtp_mtpcd ");
                sb.Append(@"WHERE (dbo.tmp_statistics.tmp_param2 = @type)");
                sb.Append(@"ORDER BY tmp_btpcd, tmp_otp1cd, tmp_otp2cd");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@type", type);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selecttmp_statisticsForExcel6(string date_str, string btpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM dbo.c1_od INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND ");
            sb.Append(@"dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND ");
            sb.Append(@"dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem ");
            sb.Append(@"WHERE (SUBSTRING(dbo.c1_od.od_sdate, 1, 6) <= @date_str ) AND ");
            sb.Append(@"(SUBSTRING(dbo.c1_od.od_edate, 1, 6) >= @date_str ) AND ");
            sb.Append(@"(dbo.c1_ramt.ra_mnt > 5) AND (dbo.c1_ramt.ra_mtpcd = '11') AND ");
            sb.Append(@"(dbo.c1_od.od_btpcd = @btpcd ) ");
            sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@date_str", date_str);
            oCmd.Parameters.AddWithValue("@btpcd", btpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet SelectBookp(string bkp_date)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM bookp WHERE bkp_date = @bkp_date ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkp_date", bkp_date);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}