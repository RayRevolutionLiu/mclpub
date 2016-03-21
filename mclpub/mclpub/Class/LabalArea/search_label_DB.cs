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
    public class search_label_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectMtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpid, mtp_mtpcd, mtp_nm FROM dbo.mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "mtp");
            return ds;

        }

        public DataSet Selectc1_obtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_obtp");
            return ds;

        }


        public DataSet Selectc1_otp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_otp");
            return ds;

        }


        public void UpdateTmp1(string syscd, string otp1cd, string mtpcd, string btpcd, string maildate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_tmp_001";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@otp1cd", otp1cd);
            oCmd.Parameters.AddWithValue("@mtpcd", mtpcd);
            oCmd.Parameters.AddWithValue("@btpcd", btpcd);
            oCmd.Parameters.AddWithValue("@maildate", maildate);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public DataSet SelectTmp_label1()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.tmp_label1.od_odid, dbo.tmp_label1.od_syscd + dbo.tmp_label1.od_custno + dbo.tmp_label1.od_otp1cd + dbo.tmp_label1.od_otp1seq AS nostr, dbo.tmp_label1.od_oditem, dbo.tmp_label1.od_sdate + '~' + dbo.tmp_label1.od_edate AS datestr,");
            sb.Append(@" dbo.tmp_label1.ra_mnt, dbo.tmp_label1.ra_mtpcd, dbo.tmp_label1.mtp_nm, dbo.tmp_label1.obtp_obtpnm, dbo.tmp_label1.ra_oritem, dbo.c1_order.o_otp2cd");
            sb.Append(@", dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_syscd FROM dbo.tmp_label1 INNER JOIN dbo.c1_order ON dbo.tmp_label1.od_syscd = dbo.c1_order.o_syscd");
            sb.Append(@" AND dbo.tmp_label1.od_custno = dbo.c1_order.o_custno AND dbo.tmp_label1.od_otp1cd = dbo.c1_order.o_otp1cd AND dbo.tmp_label1.od_otp1seq = dbo.c1_order.o_otp1seq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "tmp_label1");
            return ds;

        }

        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "srspn");
            return ds;

        }


        public DataSet SelectExportExcel(string type2, string mnt)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT tmp_label1.*, c1_order.o_otp2cd, c1_cust.cust_nm, mfr.mfr_inm, c1_or.or_nm, c1_or.or_addr, c1_or.or_zip, c1_or.or_fgmosea ");
            sb.Append(@",c1_order.o_date FROM c1_or INNER JOIN ");
            sb.Append(@"c1_order ON c1_or.or_syscd = c1_order.o_syscd AND ");
            sb.Append(@"c1_or.or_custno = c1_order.o_custno AND ");
            sb.Append(@"c1_or.or_otp1cd = c1_order.o_otp1cd AND ");
            sb.Append(@"c1_or.or_otp1seq = c1_order.o_otp1seq INNER JOIN ");
            sb.Append(@"tmp_label1 ON c1_order.o_syscd = tmp_label1.od_syscd AND ");
            sb.Append(@"c1_order.o_custno = tmp_label1.od_custno AND ");
            sb.Append(@"c1_order.o_otp1cd = tmp_label1.od_otp1cd AND ");
            sb.Append(@"c1_order.o_otp1seq = tmp_label1.od_otp1seq AND ");
            sb.Append(@"c1_or.or_oritem = tmp_label1.ra_oritem INNER JOIN ");
            sb.Append(@"c1_cust ON c1_order.o_custno = c1_cust.cust_custno INNER JOIN ");
            sb.Append(@"mfr ON c1_cust.cust_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE c1_order.o_otp2cd = @type2 ");
            if (mnt.ToString() == "0")
            {
                sb.Append(@"AND tmp_label1.ra_mnt >5 ");
            }
            else
            {
                sb.Append(@" AND tmp_label1.ra_mnt=@mnt ");
            }
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@type2", type2);
            oCmd.Parameters.AddWithValue("@mnt", mnt);
            //oCmd.Parameters.AddWithValue("@maildate", maildate);
            //oCmd.Parameters.AddWithValue("@maildate", maildate);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet SelectBookpNoOrderByDate(string YandMdate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.bookp.*, dbo.book.bk_nm AS bk_nm FROM dbo.bookp INNER JOIN dbo.book ON dbo.bookp.bkp_bkcd = dbo.book.bk_bkcd WHERE bkp_date=@YandMdate ORDER BY CONVERT(int, bkp_pno) DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@YandMdate", YandMdate);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}