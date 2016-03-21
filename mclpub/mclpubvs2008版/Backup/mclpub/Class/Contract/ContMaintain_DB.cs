using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class ContMaintain_DB
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


        public SqlDataReader GetContCounts(string contno)
        {
            SqlConnection myConnection = new SqlConnection(Conn);
            string strCmd = "sp_c4_get_cont_counts";

            SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            // 設定Parameter
            SqlParameter param_adrd_contno = new SqlParameter("@adr_contno", SqlDbType.Char, 6);
            param_adrd_contno.Value = contno;
            myCommand.Parameters.Add(param_adrd_contno);

            //OUTPUT Parameters
            SqlParameter param_pubedtm = new SqlParameter("@pubedtm", SqlDbType.Int);
            param_pubedtm.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(param_pubedtm);

            SqlParameter param_paidamt = new SqlParameter("@paidamt", SqlDbType.Float);
            param_paidamt.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(param_paidamt);

            myConnection.Open();
            SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;
        }


        public void UpdateCont(string cont_contno, string cont_conttp, string cont_signdate, string cont_sdate, string cont_edate, string cont_empno, string cont_aunm, string cont_autel, 
            string cont_aufax, string cont_aucell, string cont_auemail, int cont_freetm, int cont_pubtm, int cont_resttm, int cont_totimgtm, int cont_toturltm, float cont_disc
            , float cont_totamt, float cont_paidamt, float cont_restamt, string cont_remark, string cont_moddate, string cont_modempno, string cont_fgpayonce, string cont_fgclosed
            , string cont_ccont, string cont_pdcont, string cont_csdate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_update_cont";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oCmd.Parameters.AddWithValue("@cont_conttp", cont_conttp);
            oCmd.Parameters.AddWithValue("@cont_signdate", cont_signdate);
            oCmd.Parameters.AddWithValue("@cont_sdate", cont_sdate);
            oCmd.Parameters.AddWithValue("@cont_edate", cont_edate);
            oCmd.Parameters.AddWithValue("@cont_empno", cont_empno);
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
            oCmd.Parameters.AddWithValue("@cont_moddate", cont_moddate);
            oCmd.Parameters.AddWithValue("@cont_modempno", cont_modempno);
            oCmd.Parameters.AddWithValue("@cont_fgpayonce", cont_fgpayonce);
            oCmd.Parameters.AddWithValue("@cont_fgclosed", cont_fgclosed);
            oCmd.Parameters.AddWithValue("@cont_ccont", cont_ccont);
            oCmd.Parameters.AddWithValue("@cont_pdcont", cont_pdcont);
            oCmd.Parameters.AddWithValue("@cont_csdate", cont_csdate);

            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UpdateContSetCancel(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "UPDATE c4_cont SET cont_fgcancel='1' WHERE cont_contno=@cont_contno";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

    }
}
