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
    public class IA1Query_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSingleContractByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp");
            sb.Append(@", c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, c4_cont.cont_aunm,");
            sb.Append(@" c4_cont.cont_autel, c4_cont.cont_aufax, c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm");
            sb.Append(@", c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, c4_cont.cont_csdate");
            sb.Append(@", c4_cont.cont_pdcont, c4_cont.cont_remark, c4_cont.cont_credate, c4_cont.cont_moddate, c4_cont.cont_modempno, c4_cont.cont_oldcontno,");
            sb.Append(@" c4_cont.cont_fgpayonce, c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, cust.cust_nm");
            sb.Append(@", mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_respnm, mfr.mfr_respjbti FROM c4_cont LEFT OUTER JOIN cust ON c4_cont.cont_custno = cust.cust_custno");
            sb.Append(@" LEFT OUTER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno WHERE c4_cont.cont_contno= @contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet GetAllFormalContracts(string tbxMfrNm, string tbxMfrNo, string tbxCustNo, string tbxCustNm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, c4_cont.cont_signdate, c4_cont.cont_sdate,");
            sb.Append(@" c4_cont.cont_edate, c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax,");
            sb.Append(@" c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, c4_cont.cont_toturltm, c4_cont.cont_disc");
            sb.Append(@", c4_cont.cont_totamt, c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, c4_cont.cont_credate,");
            sb.Append(@" c4_cont.cont_moddate, c4_cont.cont_modempno, c4_cont.cont_oldcontno, c4_cont.cont_fgpayonce, c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, c4_cont.cont_fgclosed, ");
            sb.Append(@"c4_cont.cont_fgcancel, cust.cust_custno, cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm FROM c4_cont INNER JOIN cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON");
            sb.Append(@" cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '0') AND (c4_cont.cont_fgclosed = '0') ");
            if (tbxMfrNm != "")
            {
                sb.Append(@" AND mfr_inm Like '%'+@tbxMfrNm+'%' ");
            }
            if (tbxMfrNo != "")
            {
                sb.Append(@" AND mfr_mfrno Like '%'+@tbxMfrNo+'%' ");
            }
            if (tbxCustNo != "")
            {
                sb.Append(@" AND cust_custno Like '%'+@tbxCustNo+'%' ");
            }
            if (tbxCustNm != "")
            {
                sb.Append(@" AND cust_nm Like '%'+@tbxCustNm+'%' ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@tbxMfrNm", tbxMfrNm);
            oCmd.Parameters.AddWithValue("@tbxMfrNo", tbxMfrNo);
            oCmd.Parameters.AddWithValue("@tbxCustNo", tbxCustNo);
            oCmd.Parameters.AddWithValue("@tbxCustNm", tbxCustNm);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}