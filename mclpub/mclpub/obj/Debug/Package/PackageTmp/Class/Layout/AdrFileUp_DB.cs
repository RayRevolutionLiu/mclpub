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
    public class AdrFileUp_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSingleContractByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, c4_cont.cont_credate, c4_cont.cont_moddate, c4_cont.cont_modempno, c4_cont.cont_oldcontno, c4_cont.cont_fgpayonce, c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_respnm, mfr.mfr_respjbti FROM c4_cont LEFT OUTER JOIN cust ON c4_cont.cont_custno = cust.cust_custno LEFT OUTER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno WHERE c4_cont.cont_contno=@contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }

        public DataSet GetAdvertisements(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT adr_syscd, adr_contno, adr_seq, adr_addate, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_impr, adr_navurl, adr_drafttp, adr_urltp, adr_imseq, adr_invamt, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_projno, adr_costctr, adr_fginved, adr_fgfixad, adr_fgimggot, adr_fgurlgot, adr_fginvself, adr_fgact FROM c4_adr WHERE adr_syscd='C4' AND adr_contno=@contno ORDER BY adr_addate");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public bool CheckXmlFileLog(string xmldate)
        {
            bool flag = false;
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT xml_date, xml_fgexist FROM c4_xmlfilelog WHERE xml_date=@xmldate");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            oCmd.Parameters.AddWithValue("@xmldate", xmldate);
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["xml_fgexist"].ToString() == "1")
                {
                    flag = true;
                }
            }
            else
            {
                flag = false;
            }
            return flag;

        }

        public void UpdateAdrFileUp(string adr_contno, string adr_seq, string adr_addate, string adr_alttext, string adr_navurl, string adr_remark, string adr_imgurl, string adr_drafttp, string adr_urltp)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c4_update_adr_fileup";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@adr_contno", adr_contno);
            oCmd.Parameters.AddWithValue("@adr_seq", adr_seq);
            oCmd.Parameters.AddWithValue("@adr_addate", adr_addate);
            oCmd.Parameters.AddWithValue("@adr_alttext", adr_alttext);
            oCmd.Parameters.AddWithValue("@adr_navurl", adr_navurl);
            oCmd.Parameters.AddWithValue("@adr_remark", adr_remark);
            oCmd.Parameters.AddWithValue("@adr_imgurl", adr_imgurl);
            oCmd.Parameters.AddWithValue("@adr_drafttp", adr_drafttp);
            oCmd.Parameters.AddWithValue("@adr_urltp", adr_urltp);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}