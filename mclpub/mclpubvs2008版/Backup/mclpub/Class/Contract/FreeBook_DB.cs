using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class FreeBook_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSingleContractByContNo(string contno)
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
            sb.Append(@"c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno,cont_oldcontno, ");
            sb.Append(@"cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, ");
            sb.Append(@"mfr.mfr_respnm, mfr.mfr_respjbti ");
            sb.Append(@"FROM c4_cont INNER JOIN ");
            sb.Append(@"cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN ");
            sb.Append(@"mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE c4_cont.cont_contno=@contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetMfrCustByCustNo(string cust_custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, ");
            sb.Append(@"cust_email, cust_regdate, cust_moddate, cust_itpcd, cust_btpcd, cust_rtpcd, ");
            sb.Append(@"cust_oldcustno, cust_orgisyscd, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, ");
            sb.Append(@"mfr_respnm, mfr_respjbti, mfr_tel, mfr_fax, mfr_regdate ");
            sb.Append(@"FROM cust INNER JOIN mfr ON cust_mfrno = mfr_mfrno ");
            sb.Append(@"WHERE cust_custno=@cust_custno");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetOrByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT or_inm,or_syscd, or_contno, or_oritem, or_nm, or_jbti, or_addr, or_zip, or_tel, ");
            sb.Append(@"or_fax, or_cell, or_email, or_fgmosea FROM c4_or WHERE or_contno=@contno ");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetFbkOrByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_freebk.fbk_syscd, c4_freebk.fbk_contno, c4_freebk.fbk_fbkitem, ");
            sb.Append(@"c4_freebk.fbk_bkcd, freecat.fc_nm, c4_ramt.ma_oritem, c4_or.or_nm, ");
            sb.Append(@"c4_or.or_fgmosea, c4_freebk.fbk_bkcd, c4_or.or_contno, ");
            sb.Append(@"c4_or.or_oritem, c4_or.or_syscd, c4_ramt.ma_contno, ");
            sb.Append(@"c4_ramt.ma_fbkitem, c4_ramt.ma_syscd, c4_ramt.ma_sdate, c4_ramt.ma_edate, c4_ramt.ma_pubmnt, ");
            sb.Append(@"c4_ramt.ma_unpubmnt, c4_ramt.ma_mtpcd, c4_or.or_addr, ");
            sb.Append(@"SUBSTRING(ma_sdate, 1, 4) + '/' + SUBSTRING(ma_sdate, 5, 2) AS str_ma_sdate, ");
            sb.Append(@"SUBSTRING(ma_edate, 1, 4) + '/' + SUBSTRING(ma_edate, 5, 2) AS str_ma_edate ");
            sb.Append(@"FROM c4_freebk INNER JOIN ");
            sb.Append(@"c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND ");
            sb.Append(@"c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN ");
            sb.Append(@"c4_ramt ON c4_freebk.fbk_syscd = c4_ramt.ma_syscd AND ");
            sb.Append(@"c4_freebk.fbk_contno = c4_ramt.ma_contno AND ");
            sb.Append(@"c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem AND ");
            sb.Append(@"c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN ");
            sb.Append(@"freecat ON c4_freebk.fbk_bkcd = freecat.fc_fccd ");
            sb.Append(@"WHERE c4_freebk.fbk_contno=@contno ");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }


        #region 取郵寄類別資料
        public DataSet GetMtps()
        {
            SqlConnection myConnection = new SqlConnection(Conn);
            string strCmd = "SELECT mtp_mtpcd, mtp_nm FROM mtp";

            SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);

            DataSet ds = new DataSet();

            myCommand.Fill(ds);

            return ds;
        }
        #endregion


        public string AddOr(string or_contno, string or_inm, string or_nm, string or_jbti, string or_addr, string or_zip, string or_tel, string or_fax, string or_cell, string or_email, string or_fgmosea)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_add_or";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@or_contno", or_contno);
            oCmd.Parameters.AddWithValue("@or_inm", or_inm);
            oCmd.Parameters.AddWithValue("@or_nm", or_nm);
            oCmd.Parameters.AddWithValue("@or_jbti", or_jbti);
            oCmd.Parameters.AddWithValue("@or_addr", or_addr);
            oCmd.Parameters.AddWithValue("@or_zip", or_zip);
            oCmd.Parameters.AddWithValue("@or_tel", or_tel);
            oCmd.Parameters.AddWithValue("@or_fax", or_fax);
            oCmd.Parameters.AddWithValue("@or_cell", or_cell);
            oCmd.Parameters.AddWithValue("@or_email", or_email);
            oCmd.Parameters.AddWithValue("@or_fgmosea", or_fgmosea);
            SqlParameter retValParam = oCmd.Parameters.Add("@or_oritem", SqlDbType.Char, 2);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            return Convert.ToString(retValParam.Value);
        }


        public int DeleteOr(string or_contno, string or_oritem)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_delete_or";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@or_contno", or_contno);
            oCmd.Parameters.AddWithValue("@or_oritem", or_oritem);
            SqlParameter retValParam = oCmd.Parameters.Add("@effects", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            return Convert.ToInt32(retValParam.Value);
        }


        public string AddFreeBk(string new_contno, string fbk_bkcd, string ma_oritem, string ma_sdate, string ma_edate, string ma_pubmnt, string ma_unpubmnt, string ma_mtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_add_freebk";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@new_contno", new_contno);
            oCmd.Parameters.AddWithValue("@fbk_bkcd", fbk_bkcd);
            oCmd.Parameters.AddWithValue("@ma_oritem", ma_oritem);
            oCmd.Parameters.AddWithValue("@ma_sdate", ma_sdate);
            oCmd.Parameters.AddWithValue("@ma_edate", ma_edate);
            oCmd.Parameters.AddWithValue("@ma_pubmnt", ma_pubmnt);
            oCmd.Parameters.AddWithValue("@ma_unpubmnt", ma_unpubmnt);
            oCmd.Parameters.AddWithValue("@ma_mtpcd", ma_mtpcd);
            SqlParameter retValParam = oCmd.Parameters.Add("@fbk_fbkitem", SqlDbType.Char, 2);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            return Convert.ToString(retValParam.Value);
        }


        public bool Delete_1_FreeBk(string new_contno, string fbk_fbkitem, string ma_oritem)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_delete_1_freebk";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@new_contno", new_contno);
            oCmd.Parameters.AddWithValue("@fbk_fbkitem", fbk_fbkitem);
            oCmd.Parameters.AddWithValue("@ma_oritem", ma_oritem);
            SqlParameter retValParam = oCmd.Parameters.Add("@success", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            //success=0失敗，success=1成功
            if (Convert.ToInt32(retValParam.Value) == 0)
                return false;
            else
                return true;
        }



        public void UpdateOr(string new_contno, string or_oritem, string or_inm, string or_nm, string or_jbti, string or_addr, string or_zip, string or_tel, string or_fax, string or_cell, string or_email, string or_fgmosea)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_update_or";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@new_contno", new_contno);
            oCmd.Parameters.AddWithValue("@or_oritem", or_oritem);
            oCmd.Parameters.AddWithValue("@or_inm", or_inm);
            oCmd.Parameters.AddWithValue("@or_nm", or_nm);
            oCmd.Parameters.AddWithValue("@or_jbti", or_jbti);
            oCmd.Parameters.AddWithValue("@or_addr", or_addr);
            oCmd.Parameters.AddWithValue("@or_zip", or_zip);
            oCmd.Parameters.AddWithValue("@or_tel", or_tel);
            oCmd.Parameters.AddWithValue("@or_fax", or_fax);
            oCmd.Parameters.AddWithValue("@or_cell", or_cell);
            oCmd.Parameters.AddWithValue("@or_email", or_email);
            oCmd.Parameters.AddWithValue("@or_fgmosea", or_fgmosea);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public string UpdateFreeBk(string new_contno, string fbk_fbkitem, string fbk_bkcd, string ma_oritem, string ma_sdate, string ma_edate, string ma_pubmnt, string ma_unpubmnt, string ma_mtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_update_freebk";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@new_contno", new_contno);
            oCmd.Parameters.AddWithValue("@fbk_fbkitem", fbk_fbkitem);
            oCmd.Parameters.AddWithValue("@fbk_bkcd", fbk_bkcd);
            oCmd.Parameters.AddWithValue("@ma_oritem", ma_oritem);
            oCmd.Parameters.AddWithValue("@ma_sdate", ma_sdate);
            oCmd.Parameters.AddWithValue("@ma_edate", ma_edate);
            oCmd.Parameters.AddWithValue("@ma_pubmnt", ma_pubmnt);
            oCmd.Parameters.AddWithValue("@ma_unpubmnt", ma_unpubmnt);
            oCmd.Parameters.AddWithValue("@ma_mtpcd", ma_mtpcd);
            SqlParameter retValParam = oCmd.Parameters.Add("@ret_fbkitem", SqlDbType.Char, 2);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            return Convert.ToString(retValParam.Value);
        }
    }
}
