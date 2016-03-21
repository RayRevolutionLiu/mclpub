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
    public class iaFm2_RecAll_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.ia.ia_syscd, dbo.ia.ia_iano, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno");
            sb.Append(@", RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rzip) AS ia_rzip");
            sb.Append(@", RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.iad.iad_iaditem, RTRIM(dbo.iad.iad_fk1) AS iad_fk1");
            sb.Append(@", RTRIM(dbo.iad.iad_fk2) AS iad_fk2, RTRIM(dbo.iad.iad_fk3) AS iad_fk3, RTRIM(dbo.iad.iad_fk4) AS iad_fk4, RTRIM(dbo.iad.iad_desc) AS iad_desc, dbo.iad.iad_projno");
            sb.Append(@", dbo.iad.iad_costctr, dbo.iad.iad_qty, dbo.iad.iad_amt, dbo.ia.ia_iabdate, dbo.ia.ia_iabseq, dbo.iad.iad_iano, dbo.iad.iad_syscd, RTRIM(dbo.ia.ia_cname) ");
            sb.Append(@"AS ia_cname, dbo.iab.iab_createdate, RTRIM(dbo.iab.iab_createmen) AS iab_createmen, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.iab.iab_iabdate,");
            sb.Append(@"CASE WHEN ia_invcd = '2' THEN '二聯式' WHEN ia_invcd = '3' ");
            sb.Append(@" THEN '三聯式' WHEN ia_invcd = '4' THEN '其他' ");
            sb.Append(@" ELSE '不清楚' END AS ia_invcdText, ");
            sb.Append(@" CASE WHEN ia_taxtp = '1' THEN '應稅5%' WHEN ia_taxtp = '2' ");
            sb.Append(@" THEN '零稅' WHEN ia_taxtp = '3' THEN '免稅' ");
            sb.Append(@" ELSE '不清楚' END AS ia_taxtpText ");
            sb.Append(@", dbo.iab.iab_iabseq, dbo.iab.iab_syscd FROM dbo.ia INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER");
            sb.Append(@" JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.iab ON dbo.ia.ia_syscd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.iab.iab_syscd AND dbo.ia.ia_iabdate");
            sb.Append(@" = dbo.iab.iab_iabdate AND dbo.ia.ia_iabseq = dbo.iab.iab_iabseq INNER JOIN dbo.srspn ON dbo.iab.iab_createmen COLLATE Chinese_Taiwan_Stroke_CI_AS");
            sb.Append(@" = dbo.srspn.srspn_empno WHERE (dbo.ia.ia_syscd = 'C2') AND (RTRIM(LTRIM(dbo.ia.ia_status)) = '') ORDER BY dbo.ia.ia_iano, dbo.ia.ia_mfrno, dbo.ia.ia_rnm");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void Runsp_c2_delete_ia_all(string iabdate, string iabseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c2_delete_ia_all");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@iabdate", iabdate);
            oCmd.Parameters.AddWithValue("@iabseq", iabseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}