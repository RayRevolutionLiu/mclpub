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
    public class CheckList3_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_Order()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_refno, dbo.ia.ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq");
            sb.Append(@", dbo.ia.ia_pyat, dbo.ia.ia_ivat, dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.ia.ia_raddr, dbo.ia.ia_rzip, dbo.ia.ia_rjbti");
            sb.Append(@", dbo.ia.ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, dbo.ia.ia_cname, dbo.ia.ia_tel, dbo.ia.ia_contno, dbo.iad.iad_iadid");
            sb.Append(@", dbo.iad.iad_syscd, dbo.iad.iad_iano, dbo.iad.iad_iaditem, dbo.iad.iad_fk1, dbo.iad.iad_fk2, dbo.iad.iad_fk3, dbo.iad.iad_fk4, dbo.iad.iad_projno,");
            sb.Append(@" dbo.iad.iad_costctr, dbo.iad.iad_desc, dbo.iad.iad_qty, dbo.iad.iad_unit, dbo.iad.iad_uprice, dbo.iad.iad_amt, dbo.c1_order.o_status, dbo.c1_order.o_custno,");
            sb.Append(@" dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_syscd FROM dbo.ia INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND");
            sb.Append(@" dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c1_order ON dbo.ia.ia_syscd = dbo.c1_order.o_syscd AND dbo.ia.ia_iano = dbo.c1_order.o_iano ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}