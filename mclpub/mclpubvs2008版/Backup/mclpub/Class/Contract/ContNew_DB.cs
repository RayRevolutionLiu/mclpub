using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class ContNew_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM srspn where srspn_atype <> 'A' and srspn_atype <> 'E' and srspn_atype <> 'F'");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }


        public string AddContract(string cont_empno, string cont_oldcontno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_add_new_cont";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_empno", cont_empno);
            oCmd.Parameters.AddWithValue("@cont_oldcontno", cont_oldcontno);
            SqlParameter retValParam = oCmd.Parameters.Add("@cont_contno", SqlDbType.Char, 10);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            return Convert.ToString(retValParam.Value);
        }


        public DataSet GetMfrCustByCustNo(string cust_custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_itpcd, cust_btpcd, cust_rtpcd, cust_oldcustno, cust_orgisyscd, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, mfr_respnm, mfr_respjbti, mfr_tel, mfr_fax, mfr_regdate FROM cust INNER JOIN mfr ON cust_mfrno = mfr_mfrno WHERE cust_custno=@cust_custno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }


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


        public DataSet GetAtpMtps_Display(string contno, string classtype)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cls_contno, cls_cls1id, cls_cls2id, cls_cls3id, c4_class1.cls1_name, c4_class2.cls2_cname, c4_class3.cls3_cname FROM c4_classes ");
            sb.Append(@"INNER JOIN c4_class1 ON c4_classes.cls_cls1id = c4_class1.cls1_cls1id INNER JOIN c4_class2 ON c4_classes.cls_cls2id = c4_class2.cls2_cls2id");
            sb.Append(@" AND  c4_classes.cls_cls1id = c4_class2.cls2_cls1id INNER JOIN c4_class3 ON c4_classes.cls_cls3id = c4_class3.cls3_cls3id AND");
            sb.Append(@"  c4_classes.cls_cls2id = c4_class3.cls3_cls2id AND  c4_classes.cls_cls1id = c4_class3.cls3_cls1id WHERE cls_contno=@contno AND cls_cls1id=@classtype ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@classtype", classtype);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetOrByContNo(string or_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM c4_or WHERE or_contno=@or_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@or_contno", or_contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetFbkOrByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_freebk.fbk_syscd, c4_freebk.fbk_contno, c4_freebk.fbk_fbkitem, c4_freebk.fbk_bkcd, freecat.fc_nm, c4_ramt.ma_oritem, c4_or.or_nm, c4_or.or_fgmosea, c4_freebk.fbk_bkcd, c4_or.or_contno, c4_or.or_oritem, c4_or.or_syscd");
            sb.Append(@", c4_ramt.ma_contno, c4_ramt.ma_fbkitem, c4_ramt.ma_syscd, c4_ramt.ma_sdate, c4_ramt.ma_edate, c4_ramt.ma_pubmnt, c4_ramt.ma_unpubmnt, c4_ramt.ma_mtpcd, c4_or.or_addr");
            sb.Append(@", SUBSTRING(ma_sdate, 1, 4) + '/' + SUBSTRING(ma_sdate, 5, 2) AS str_ma_sdate, SUBSTRING(ma_edate, 1, 4) + '/' + SUBSTRING(ma_edate, 5, 2) AS str_ma_edate");
            sb.Append(@" FROM c4_freebk INNER JOIN c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND c4_freebk.fbk_contno = c4_or.or_contno");
            sb.Append(@" INNER JOIN c4_ramt ON c4_freebk.fbk_syscd = c4_ramt.ma_syscd AND c4_freebk.fbk_contno = c4_ramt.ma_contno AND c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem");
            sb.Append(@" AND c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN freecat ON c4_freebk.fbk_bkcd = freecat.fc_fccd WHERE c4_freebk.fbk_contno=@contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetInvMfr(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select invmfr.*, proj.proj_projno, invcd = CASE im_invcd WHEN '2' THEN '二聯' WHEN '3' THEN '三聯' ELSE '其他' END,");
            sb.Append(@"imfgitri= CASE im_fgitri WHEN '06' THEN '所內' WHEN '07' THEN '院內' ELSE '一般' END");
            sb.Append(@", taxtp = CASE im_taxtp WHEN '1' THEN '應稅5%' WHEN '2' THEN '零稅' ELSE '免稅' END FROM invmfr");
            sb.Append(@" INNER JOIN proj ON invmfr.im_syscd = proj.proj_syscd AND invmfr.im_fgitri = proj.proj_fgitri WHERE im_syscd='C4' AND im_contno=@contno ");
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

        public bool UpdateToBeFormal(string cont_contno, string cont_conttp, string cont_signdate, string cont_sdate, string cont_edate, string cont_empno, string cont_mfrno, string cont_custno, string cont_aunm, string cont_autel, string cont_aufax, string cont_aucell, string cont_auemail, int cont_freetm, int cont_pubtm, int cont_resttm, int cont_totimgtm, int cont_toturltm, float cont_disc, float cont_totamt, float cont_paidamt, float cont_restamt, string cont_remark, string cont_credate, string cont_moddate, string cont_modempno, string cont_fgpayonce, string cont_ccont, string cont_pdcont, string cont_csdate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_update_cont_to_be_formal";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oCmd.Parameters.AddWithValue("@cont_conttp", cont_conttp);
            oCmd.Parameters.AddWithValue("@cont_signdate", cont_signdate);
            oCmd.Parameters.AddWithValue("@cont_sdate", cont_sdate);
            oCmd.Parameters.AddWithValue("@cont_edate", cont_edate);
            oCmd.Parameters.AddWithValue("@cont_empno", cont_empno);
            oCmd.Parameters.AddWithValue("@cont_mfrno", cont_mfrno);
            oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oCmd.Parameters.AddWithValue("@cont_aunm", cont_aunm);
            oCmd.Parameters.AddWithValue("@cont_autel", cont_autel);
            oCmd.Parameters.AddWithValue("@cont_aufax", cont_aufax);
            oCmd.Parameters.AddWithValue("@cont_aucell", cont_aucell);
            oCmd.Parameters.AddWithValue("@cont_auemail", cont_auemail);
            oCmd.Parameters.AddWithValue("@cont_freetm", cont_freetm);
            oCmd.Parameters.AddWithValue("@cont_pubtm", cont_pubtm);
            oCmd.Parameters.AddWithValue("@cont_resttm", cont_resttm);
            oCmd.Parameters.AddWithValue("@cont_totimgtm", cont_totimgtm);
            oCmd.Parameters.AddWithValue("@cont_toturltm", cont_toturltm);
            oCmd.Parameters.AddWithValue("@cont_disc", cont_disc);
            oCmd.Parameters.AddWithValue("@cont_totamt", cont_totamt);
            oCmd.Parameters.AddWithValue("@cont_paidamt", cont_paidamt);
            oCmd.Parameters.AddWithValue("@cont_restamt", cont_restamt);
            oCmd.Parameters.AddWithValue("@cont_remark", cont_remark);
            oCmd.Parameters.AddWithValue("@cont_credate", cont_credate);
            oCmd.Parameters.AddWithValue("@cont_moddate", cont_moddate);
            oCmd.Parameters.AddWithValue("@cont_modempno", cont_modempno);
            oCmd.Parameters.AddWithValue("@cont_fgpayonce", cont_fgpayonce);
            oCmd.Parameters.AddWithValue("@cont_ccont", cont_ccont);
            oCmd.Parameters.AddWithValue("@cont_pdcont", cont_pdcont);
            oCmd.Parameters.AddWithValue("@cont_csdate", cont_csdate);
            SqlParameter retValParam = oCmd.Parameters.Add("@success", SqlDbType.Char, 10);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            return (Convert.ToInt32(retValParam.Value) == 1);

        }


        public void DeleteContTemp(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_clean_c4_tempcont";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


    }
}
