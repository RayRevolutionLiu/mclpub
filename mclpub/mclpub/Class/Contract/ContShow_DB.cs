using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Collections;

namespace mclpub
{
    public class ContShow_DB
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

        public string SelectSrspnCname(string empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from srspn where srspn_empno=@empno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@empno", empno);
            oda.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["srspn_cname"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}