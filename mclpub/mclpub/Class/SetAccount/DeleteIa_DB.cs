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
    public class DeleteIa_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, ");
            sb.Append(@"dbo.ia.ia_refno, dbo.ia.ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat, dbo.ia.ia_ivat, ");
            sb.Append(@"dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.ia.ia_raddr, dbo.ia.ia_rzip, ");
            sb.Append(@"dbo.ia.ia_rjbti, dbo.ia.ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, ");
            sb.Append(@"dbo.ia.ia_cname, dbo.ia.ia_tel, dbo.ia.ia_contno, dbo.c1_order.o_syscd + dbo.c1_order.o_custno + ");
            sb.Append(@"dbo.c1_order.o_otp1cd + dbo.c1_order.o_otp1seq AS nostr, dbo.c1_order.o_date, dbo.c1_od.od_sdate + '~' + ");
            sb.Append(@"dbo.c1_od.od_edate AS datestr, dbo.c1_od.od_btpcd, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, ");
            sb.Append(@"dbo.c1_obtp.obtp_otp1cd, dbo.c1_od.od_custno, dbo.c1_od.od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, ");
            sb.Append(@"dbo.c1_od.od_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_syscd ");
            sb.Append(@"FROM dbo.ia INNER JOIN dbo.c1_order ON dbo.ia.ia_syscd = dbo.c1_order.o_syscd AND dbo.ia.ia_iano = ");
            sb.Append(@"dbo.c1_order.o_iano INNER JOIN dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c1_order.o_custno = ");
            sb.Append(@"dbo.c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_order.o_otp1seq = ");
            sb.Append(@"dbo.c1_od.od_otp1seq INNER JOIN dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd AND ");
            sb.Append(@"dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd ");
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


        public void UPDATEc1_orderSpecialFM(string modstatus, string moduid, string iano)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE dbo.c1_order SET o_modstatus = @modstatus, o_moduid = @moduid WHERE (o_iano = @iano) AND (o_syscd = 'C1') ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@modstatus", modstatus);
            oCmd.Parameters.AddWithValue("@moduid", moduid);
            oCmd.Parameters.AddWithValue("@iano", iano);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}