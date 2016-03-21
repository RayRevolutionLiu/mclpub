using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class ContQueryFormal_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        #region 由客戶編號取得合約資料，註銷、暫存的不在要求範圍內
        /// <summary>
        /// 由客戶編號取得合約資料，註銷、暫存的不在要求範圍內
        /// </summary>
        /// <param name="custno">客戶編號</param>
        /// <returns>合約書資料</returns>
        public DataTable GetContractsByCustNo(string cont_custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, ");
            sb.Append(@"c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, ");
            sb.Append(@"c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, ");
            sb.Append(@"c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, ");
            sb.Append(@"c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, ");
            sb.Append(@"c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, ");
            sb.Append(@"c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, ");
            sb.Append(@"c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, ");
            sb.Append(@"c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, ");
            sb.Append(@"c4_cont.cont_credate, c4_cont.cont_moddate, ");
            sb.Append(@"c4_cont.cont_modempno, c4_cont.cont_fgpayonce, ");
            sb.Append(@"c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, ");
            sb.Append(@"c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, ");
            sb.Append(@"cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, ");
            sb.Append(@"mfr.mfr_respnm, mfr.mfr_respjbti ");
            sb.Append(@"FROM c4_cont INNER JOIN ");
            sb.Append(@"cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN ");
            sb.Append(@"mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '0') AND c4_cont.cont_custno=@cont_custno ");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds);
            return ds;
        }
        #endregion
    }
}
