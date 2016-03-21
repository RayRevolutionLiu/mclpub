using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class InterPlaneCont_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        #region 取得廠商客戶資料
        /// <summary>
        /// 取得廠商客戶資料
        /// </summary>
        /// <returns>廠商客戶資料</returns>
        public DataSet GetMfrCustomers()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_iaddr, mfr.mfr_izip, ");
            sb.Append(@"mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_regdate, cust.cust_custid, ");
            sb.Append(@"cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_mfrno, cust.cust_tel, cust.cust_fax, ");
            sb.Append(@"cust.cust_cell, cust.cust_email, cust.cust_regdate, cust.cust_moddate, cust.cust_itpcd, cust.cust_btpcd, ");
            sb.Append(@"cust.cust_rtpcd, cust.cust_oldcustno FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }
        #endregion


        #region 載入單筆合約資料+廠商名稱+客戶名稱
        /// <summary>
        /// 載入單筆合約資料+廠商名稱+客戶名稱
        /// </summary>
        /// <param name="contno">合約書編號</param>
        /// <returns>合約書資料</returns>
        public DataTable GetSingleContractByContNo(string contno)
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
            sb.Append(@"WHERE c4_cont.cont_contno=@cont_contno ");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@cont_contno", contno);
            oda.Fill(ds);
            return ds;
        }
        #endregion

    }
}
