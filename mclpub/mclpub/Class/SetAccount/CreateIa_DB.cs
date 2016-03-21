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
    public class CreateIa_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_order()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_order.o_oid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c1_order.o_date, dbo.c1_order.o_xmldata, dbo.c1_order.o_cancel");
            sb.Append(@", dbo.c1_order.o_iano, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.c1_cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c1_order.o_syscd + dbo.c1_order.o_custno +");
            sb.Append(@" dbo.c1_order.o_otp1cd + dbo.c1_order.o_otp1seq AS nostr, dbo.c1_order.o_indate, dbo.c1_order.o_special, dbo.c1_order.o_status FROM dbo.c1_order INNER JOIN");
            sb.Append(@" dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ON dbo.c1_order.o_mfrno = dbo.mfr.mfr_mfrno ");
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

        public DataSet Selectc1_obtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT isnull(MAX(ia_iano),0) AS max_iano, ia_syscd FROM dbo.ia GROUP BY ia_syscd HAVING (ia_syscd = 'C1')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void INSERTia(string ia_syscd, string ia_iasdate, string ia_iasseq, string ia_iaitem, string ia_iano, string ia_refno, string ia_mfrno,
             string ia_pyno, string ia_pyseq, string ia_pyat, int ia_ivat, int ia_invno, string ia_invdate, string ia_fgitri, string ia_rnm,
             string ia_raddr, string ia_rzip, string ia_rjbti, string ia_rtel, string ia_fgnonauto, string ia_invcd, string ia_taxtp, string ia_status,
             string ia_cname, string ia_tel, string ia_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO dbo.ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno)");
            sb.Append(@" VALUES (@ia_syscd, @ia_iasdate, @ia_iasseq, @ia_iaitem, @ia_iano, @ia_refno, @ia_mfrno, @ia_pyno, @ia_pyseq, @ia_pyat, @ia_ivat, @ia_invno, @ia_invdate, @ia_fgitri, @ia_rnm, @ia_raddr, @ia_rzip, @ia_rjbti, @ia_rtel, @ia_fgnonauto, @ia_invcd, @ia_taxtp, @ia_status, @ia_cname, @ia_tel, @ia_contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ia_syscd", ia_syscd);
            oCmd.Parameters.AddWithValue("@ia_iasdate", ia_iasdate);
            oCmd.Parameters.AddWithValue("@ia_iasseq", ia_iasseq);
            oCmd.Parameters.AddWithValue("@ia_iaitem", ia_iaitem);
            oCmd.Parameters.AddWithValue("@ia_iano", ia_iano);
            oCmd.Parameters.AddWithValue("@ia_refno", ia_refno);
            oCmd.Parameters.AddWithValue("@ia_mfrno", ia_mfrno);
            oCmd.Parameters.AddWithValue("@ia_pyno", ia_pyno);
            oCmd.Parameters.AddWithValue("@ia_pyseq", ia_pyseq);
            oCmd.Parameters.AddWithValue("@ia_pyat", ia_pyat);
            oCmd.Parameters.AddWithValue("@ia_ivat", ia_ivat);
            oCmd.Parameters.AddWithValue("@ia_invno", ia_invno);
            oCmd.Parameters.AddWithValue("@ia_invdate", ia_invdate);
            oCmd.Parameters.AddWithValue("@ia_fgitri", ia_fgitri);
            oCmd.Parameters.AddWithValue("@ia_rnm", ia_rnm);
            oCmd.Parameters.AddWithValue("@ia_raddr", ia_raddr);
            oCmd.Parameters.AddWithValue("@ia_rzip", ia_rzip);
            oCmd.Parameters.AddWithValue("@ia_rjbti", ia_rjbti);
            oCmd.Parameters.AddWithValue("@ia_rtel", ia_rtel);
            oCmd.Parameters.AddWithValue("@ia_fgnonauto", ia_fgnonauto);
            oCmd.Parameters.AddWithValue("@ia_invcd", ia_invcd);
            oCmd.Parameters.AddWithValue("@ia_taxtp", ia_taxtp);
            oCmd.Parameters.AddWithValue("@ia_status", ia_status);
            oCmd.Parameters.AddWithValue("@ia_cname", ia_cname);
            oCmd.Parameters.AddWithValue("@ia_tel", ia_tel);
            oCmd.Parameters.AddWithValue("@ia_contno", ia_contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void INSERTiad(string iad_syscd, string iad_iano, string iad_iaditem, string iad_fk1, string iad_fk2, string iad_fk3, string iad_fk4,
     string iad_projno, string iad_costctr, string iad_desc, int iad_qty, int iad_amt)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO dbo.iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt) ");
            sb.Append(@"VALUES (@iad_syscd, @iad_iano, @iad_iaditem, @iad_fk1, @iad_fk2, @iad_fk3, @iad_fk4, @iad_projno, @iad_costctr, @iad_desc, @iad_qty, @iad_amt) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iad_syscd", iad_syscd);
            oCmd.Parameters.AddWithValue("@iad_iano", iad_iano);
            oCmd.Parameters.AddWithValue("@iad_iaditem", iad_iaditem);
            oCmd.Parameters.AddWithValue("@iad_fk1", iad_fk1);
            oCmd.Parameters.AddWithValue("@iad_fk2", iad_fk2);
            oCmd.Parameters.AddWithValue("@iad_fk3", iad_fk3);
            oCmd.Parameters.AddWithValue("@iad_fk4", iad_fk4);
            oCmd.Parameters.AddWithValue("@iad_projno", iad_projno);
            oCmd.Parameters.AddWithValue("@iad_costctr", iad_costctr);
            oCmd.Parameters.AddWithValue("@iad_desc", iad_desc);
            oCmd.Parameters.AddWithValue("@iad_qty", iad_qty);
            oCmd.Parameters.AddWithValue("@iad_amt", iad_amt);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UPDATEc1_order(string o_iano, string o_status, string o_syscd, string o_custno, string o_otp1cd, string o_otp1seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE dbo.c1_order SET o_iano = @o_iano, o_status = @o_status WHERE ");
            sb.Append(@"(o_syscd = @o_syscd) AND (o_custno = @o_custno) AND (o_otp1cd = @o_otp1cd) AND (o_otp1seq = @o_otp1seq)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@o_iano", o_iano);
            oCmd.Parameters.AddWithValue("@o_status", o_status);
            oCmd.Parameters.AddWithValue("@o_syscd", o_syscd);
            oCmd.Parameters.AddWithValue("@o_custno", o_custno);
            oCmd.Parameters.AddWithValue("@o_otp1cd", o_otp1cd);
            oCmd.Parameters.AddWithValue("@o_otp1seq", o_otp1seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}