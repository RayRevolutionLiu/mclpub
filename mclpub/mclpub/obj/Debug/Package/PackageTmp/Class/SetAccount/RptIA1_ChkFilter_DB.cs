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
    public class RptIA1_ChkFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetIA(string iabdate, string iabseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, mfr.mfr_inm, c4_cont.cont_empno FROM ia INNER JOIN c4_cont ON ia.ia_syscd = c4_cont.cont_syscd AND SUBSTRING(ia.ia_contno, 3, 6) = c4_cont.cont_contno LEFT OUTER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (ia.ia_syscd = 'C4') AND (ia.ia_iabdate= @iabdate ) AND (ia.ia_iabseq= @iabseq ) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iabdate", iabdate);
            oCmd.Parameters.AddWithValue("@iabseq", iabseq);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet GetIAPrint(string iano)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ia.*, iad.*, mfr.mfr_inm AS im_mfr_inm, mfr.mfr_inm AS cont_mfr_inm, c4_cont.cont_contno, ");
            sb.Append(@"c4_cont.cont_empno, c4_cont.cont_sdate, c4_cont.cont_edate, ");
            sb.Append(@"c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, c4_adr.adr_chgamt, c4_adr.adr_remark ");
            sb.Append(@"FROM ia INNER JOIN ");
            sb.Append(@"iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN ");
            sb.Append(@"c4_cont ON iad.iad_syscd = c4_cont.cont_syscd AND ");
            sb.Append(@"iad.iad_fk1 = c4_cont.cont_contno INNER JOIN ");
            sb.Append(@"c4_adr ON iad.iad_syscd = c4_adr.adr_syscd AND ");
            sb.Append(@"iad.iad_fk1 = c4_adr.adr_contno AND iad.iad_fk3 = c4_adr.adr_seq AND ");
            sb.Append(@"iad.iad_fk2 = c4_adr.adr_addate LEFT OUTER JOIN ");
            sb.Append(@"mfr ON ia.ia_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE (ia.ia_syscd = 'C4') AND (ia.ia_iano = @iano) ORDER BY iad_iaditem");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iano", iano);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}