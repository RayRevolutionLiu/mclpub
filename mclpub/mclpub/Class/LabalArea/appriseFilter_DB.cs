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
    public class appriseFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public void Excute(string syscd, string otp1cd, string btpcd, string sdate, string edate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_tmp_003");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@otp1cd", otp1cd);
            oCmd.Parameters.AddWithValue("@btpcd", btpcd);
            oCmd.Parameters.AddWithValue("@sdate", sdate);
            oCmd.Parameters.AddWithValue("@edate", edate);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet SelectTmp1_table()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.tmp_label1.od_odid, dbo.tmp_label1.od_syscd + dbo.tmp_label1.od_custno + dbo.tmp_label1.od_otp1cd + dbo.tmp_label1.od_otp1seq AS nostr, dbo.tmp_label1.od_oditem, dbo.tmp_label1.od_sdate + '~' + dbo.tmp_label1.od_edate AS datestr, dbo.tmp_label1.ra_mnt, dbo.tmp_label1.ra_mtpcd, dbo.tmp_label1.mtp_nm, dbo.tmp_label1.obtp_obtpnm, dbo.tmp_label1.ra_oritem, dbo.c1_or.or_fgmosea, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.tmp_label1 INNER JOIN dbo.c1_or ON dbo.tmp_label1.od_syscd = dbo.c1_or.or_syscd AND dbo.tmp_label1.od_custno = dbo.c1_or.or_custno AND dbo.tmp_label1.od_otp1cd = dbo.c1_or.or_otp1cd AND dbo.tmp_label1.od_otp1seq = dbo.c1_or.or_otp1seq ORDER BY dbo.tmp_label1.od_syscd + dbo.tmp_label1.od_custno + dbo.tmp_label1.od_otp1cd + dbo.tmp_label1.od_otp1seq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
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
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "srspn");
            return ds;

        }


        public DataSet SelectExportExcel(string or_fgmosea)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT tmp_label1.*, c1_cust.cust_nm, mfr.mfr_inm, c1_or.or_nm, c1_or.or_addr, c1_or.or_zip, c1_or.or_fgmosea ");
            sb.Append(@",c1_order.o_date FROM c1_or INNER JOIN c1_order ON c1_or.or_syscd = c1_order.o_syscd AND ");
            sb.Append(@"c1_or.or_custno = c1_order.o_custno AND c1_or.or_otp1cd = c1_order.o_otp1cd AND ");
            sb.Append(@"c1_or.or_otp1seq = c1_order.o_otp1seq INNER JOIN ");
            sb.Append(@"tmp_label1 ON c1_order.o_syscd = tmp_label1.od_syscd AND ");
            sb.Append(@"c1_order.o_custno = tmp_label1.od_custno AND c1_order.o_otp1cd = tmp_label1.od_otp1cd AND ");
            sb.Append(@"c1_order.o_otp1seq = tmp_label1.od_otp1seq INNER JOIN c1_cust ON c1_order.o_custno = c1_cust.cust_custno INNER JOIN ");
            sb.Append(@"mfr ON c1_cust.cust_mfrno = mfr.mfr_mfrno WHERE c1_or.or_fgmosea = @or_fgmosea");
            sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@or_fgmosea", or_fgmosea);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "srspn");
            return ds;

        }
    }
}