using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
namespace mclpub
{
    public class OrderForm_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectPytp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet SelectC1_otp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet SelectC1_order()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_order.o_oid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c1_order.o_inm, dbo.c1_order.o_ijbti, dbo.c1_order.o_iaddr, dbo.c1_order.o_izip, dbo.c1_order.o_itel, dbo.c1_order.o_ifax, dbo.c1_order.o_icell, dbo.c1_order.o_iemail, dbo.c1_order.o_pytpcd, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_date, dbo.c1_order.o_moddate, dbo.c1_order.o_oldvdate, dbo.c1_order.o_empno, dbo.c1_order.o_xmldata, dbo.c1_order.o_orescd, dbo.c1_order.o_invcd, dbo.c1_order.o_taxtp, dbo.c1_cust.cust_otp1seq1, dbo.c1_cust.cust_otp1seq2, dbo.c1_cust.cust_otp1seq3, dbo.c1_cust.cust_otp1seq9, dbo.c1_cust.cust_custno FROM dbo.c1_order INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_order");
            return ds;

        }


        public DataSet SelectC1_obtpJoinProj()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_obtp.obtp_obtpid, dbo.c1_obtp.obtp_otp1cd, dbo.c1_obtp.obtp_obtpcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.proj.proj_fgitri AS fgitri, dbo.proj.proj_bkcd, dbo.proj.proj_syscd FROM dbo.c1_obtp INNER JOIN dbo.proj ON dbo.c1_obtp.obtp_obtpcd = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C1')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet("書籍資料");
            oda.Fill(ds, "書籍明細");
            return ds;

        }


        public DataSet SelectC1_cust()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_cust.cust_custid, dbo.c1_cust.cust_custno, dbo.c1_cust.cust_fgoi, dbo.c1_cust.cust_fgoe, dbo.c1_cust.cust_mfrno, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_mfrno, dbo.mfr.mfr_iaddr FROM dbo.c1_cust INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet SelectC1_ores()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ores_oresid, ores_orescd, ores_oresnm FROM dbo.c1_ores");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectsrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  srspn_empno, srspn_cname FROM dbo.srspn WHERE srspn_atype = 'B' OR srspn_atype = 'C'");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}
