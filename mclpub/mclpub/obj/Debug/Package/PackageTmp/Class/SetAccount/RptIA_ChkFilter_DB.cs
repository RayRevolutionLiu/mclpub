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
    public class RptIA_ChkFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetIAB(string StrYYYYMM)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();//底下的是正式的 下面的是測試用
            sb.Append(@"select  iab.*, srspn.srspn_cname from iab INNER JOIN srspn ON iab.iab_createmen COLLATE Chinese_Taiwan_Stroke_CI_AS = srspn.srspn_empno where (iab_syscd = 'C4') AND (iab_iabdate = @StrYYYYMM) ORDER BY iab_iabseq DESC ");
            //sb.Append(@"select  iab.*, srspn.srspn_cname from iab INNER JOIN srspn ON iab.iab_createmen COLLATE Chinese_Taiwan_Stroke_CI_AS = srspn.srspn_empno where (iab_syscd = 'C4')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@StrYYYYMM", StrYYYYMM);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet GetIA(string iabdate, string iabseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, mfr.mfr_inm, c4_cont.cont_empno FROM ia INNER JOIN c4_cont ON ia.ia_syscd = c4_cont.cont_syscd AND SUBSTRING(ia.ia_contno, 3, 6)");
            sb.Append(@" = c4_cont.cont_contno LEFT OUTER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (ia.ia_syscd = 'C4') ");
            sb.Append(@" AND (ia.ia_iabdate= @iabdate ) AND (ia.ia_iabseq= @iabseq ) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iabdate", iabdate.Trim());
            oCmd.Parameters.AddWithValue("@iabseq", iabseq.Trim());
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet GetIAPrint(string iabdate, string iabseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ia.*, iad.*, mfr.mfr_inm AS im_mfr_inm, mfr_1.mfr_inm AS cont_mfr_inm, c4_cont.cont_contno, ");
            sb.Append(@"c4_cont.cont_empno, c4_cont.cont_sdate, c4_cont.cont_edate, ");
            sb.Append(@"c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, c4_adr.adr_chgamt, c4_adr.adr_remark ");
            sb.Append(@"FROM ia INNER JOIN ");
            sb.Append(@"iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN ");
            sb.Append(@"c4_cont ON iad.iad_syscd = c4_cont.cont_syscd AND ");
            sb.Append(@"iad.iad_fk1 = c4_cont.cont_contno INNER JOIN ");
            sb.Append(@"c4_adr ON iad.iad_syscd = c4_adr.adr_syscd AND ");
            sb.Append(@"iad.iad_fk1 = c4_adr.adr_contno AND iad.iad_fk3 = c4_adr.adr_seq AND ");
            sb.Append(@"iad.iad_fk2 = c4_adr.adr_addate LEFT OUTER JOIN ");
            sb.Append(@"mfr ON ia.ia_mfrno = mfr.mfr_mfrno LEFT OUTER JOIN ");
            sb.Append(@"mfr mfr_1 ON c4_cont.cont_mfrno = mfr_1.mfr_mfrno ");
            sb.Append(@"WHERE (ia.ia_syscd = 'C4')");//底下的是正式的 下面的是測試用
            sb.Append(@" AND (ia.ia_iabdate = @iabdate ) AND (ia.ia_iabseq = @iabseq ) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iabdate", iabdate);
            oCmd.Parameters.AddWithValue("@iabseq", iabseq);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public bool RecoveryIA1(string iano)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_ia_1_recovery");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iano", iano);
            SqlParameter retValParam = oCmd.Parameters.Add("@effects", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            if (Convert.ToInt32(retValParam.Value) <= 0)
            {
                return false;
            }

            return true;
        }

        public bool RecoveryIA(string iabdate, string iabseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_ia_batch_recovery");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iabdate", iabdate);
            oCmd.Parameters.AddWithValue("@iabseq", iabseq);
            SqlParameter retValParam = oCmd.Parameters.Add("@effects", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            if (Convert.ToInt32(retValParam.Value) <= 0)
            {
                return false;
            }

            return true;
        }
    }
}