using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace mclpub
{
    public class BulkOrder_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

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


        public DataSet Selectc1_order()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_order.o_oid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno");
            sb.Append(@", dbo.c1_order.o_inm, dbo.c1_order.o_ijbti, dbo.c1_order.o_iaddr, dbo.c1_order.o_izip, dbo.c1_order.o_itel, dbo.c1_order.o_ifax, dbo.c1_order.o_icell");
            sb.Append(@", dbo.c1_order.o_iemail, dbo.c1_order.o_pytpcd, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_date, dbo.c1_order.o_moddate, dbo.c1_order.o_oldvdate, dbo.c1_order.o_empno, dbo.c1_order.o_xmldata");
            sb.Append(@", dbo.c1_order.o_orescd, dbo.c1_order.o_invcd, dbo.c1_order.o_taxtp, dbo.c1_cust.cust_nm, dbo.c1_cust.cust_custno, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrid, dbo.c1_cust.cust_tel, dbo.c1_od.od_btpcd");
            sb.Append(@", dbo.c1_od.od_sdate, dbo.c1_od.od_edate, dbo.c1_od.od_custno, dbo.c1_od.od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_syscd, dbo.mfr.mfr_mfrno FROM dbo.c1_order");
            sb.Append(@" INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ON dbo.c1_order.o_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd");
            sb.Append(@" AND dbo.c1_order.o_custno = dbo.c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq WHERE (dbo.c1_order.o_syscd = 'C1')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_order");
            return ds;

        }


        public void UpdateFirst(string od_edate, string Original_od_custno, string Original_od_oditem, string Original_od_otp1cd, string Original_od_otp1seq, string Original_od_syscd, string od_btpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE dbo.c1_od SET od_edate = @od_edate WHERE (od_custno = @Original_od_custno) AND (od_oditem = @Original_od_oditem) AND (od_otp1cd = @Original_od_otp1cd) AND (od_otp1seq = @Original_od_otp1seq) AND (od_syscd = @Original_od_syscd) AND (od_btpcd = @od_btpcd)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@od_edate", od_edate);
            oCmd.Parameters.AddWithValue("@Original_od_custno", Original_od_custno);
            oCmd.Parameters.AddWithValue("@Original_od_oditem", Original_od_oditem);
            oCmd.Parameters.AddWithValue("@Original_od_otp1cd", Original_od_otp1cd);
            oCmd.Parameters.AddWithValue("@Original_od_otp1seq", Original_od_otp1seq);
            oCmd.Parameters.AddWithValue("@Original_od_syscd", Original_od_syscd);
            oCmd.Parameters.AddWithValue("@od_btpcd", od_btpcd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UpdateSec(string o_xmldata, string o_moddate, string o_custno, string o_otp1cd, string o_otp1seq, string o_syscd, string Original_o_custno, string Original_o_otp1cd, string Original_o_otp1seq, string Original_o_syscd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE dbo.c1_order SET o_xmldata = @o_xmldata, o_moddate = @o_moddate, o_custno = @o_custno, o_otp1cd = @o_otp1cd, o_otp1seq = @o_otp1seq, o_syscd = @o_syscd WHERE (o_custno = @Original_o_custno) AND (o_otp1cd = @Original_o_otp1cd) AND (o_otp1seq = @Original_o_otp1seq) AND (o_syscd = @Original_o_syscd)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@o_xmldata", o_xmldata);
            oCmd.Parameters.AddWithValue("@o_moddate", o_moddate);
            oCmd.Parameters.AddWithValue("@o_custno", o_custno);
            oCmd.Parameters.AddWithValue("@o_otp1cd", o_otp1cd);
            oCmd.Parameters.AddWithValue("@o_otp1seq", o_otp1seq);
            oCmd.Parameters.AddWithValue("@o_syscd", o_syscd);
            oCmd.Parameters.AddWithValue("@Original_o_custno", Original_o_custno);
            oCmd.Parameters.AddWithValue("@Original_o_otp1cd", Original_o_otp1cd);
            oCmd.Parameters.AddWithValue("@Original_o_otp1seq", Original_o_otp1seq);
            oCmd.Parameters.AddWithValue("@Original_o_syscd", Original_o_syscd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}
