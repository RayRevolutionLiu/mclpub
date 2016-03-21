using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;


namespace mclpub
{
    public class ContChkList_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel");
            sb.Append(@", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp");
            sb.Append(@"n_empno FROM srspn WHERE (srspn_atype = 'B') OR (srspn_atype = 'C')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds);
            return ds;

        }

        public DataSet GetContract(string STRtbxContNo, string STRtbxSDate, string STRtbxEDate, string STRddlEmpData, string STRddlClosed)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno");
            sb.Append(@", c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, (c4_cont.cont_pubtm-c4_cont.cont_resttm) AS enpubtm");
            sb.Append(@", c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, c4_cont.cont_paidamt, c4_cont.cont_restamt");
            sb.Append(@", c4_cont.cont_ccont, c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, c4_cont.cont_credate, c4_cont.cont_moddate, c4_cont.cont_modempno");
            sb.Append(@", c4_cont.cont_oldcontno, c4_cont.cont_fgpayonce, c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, cust.cust_nm");
            sb.Append(@", mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_respnm, mfr.mfr_respjbti, srspn.srspn_cname AS inputuser, srspn_1.srspn_cname AS moduser FROM c4_cont");
            sb.Append(@" LEFT OUTER JOIN cust ON c4_cont.cont_custno = cust.cust_custno LEFT OUTER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno");
            sb.Append(@" INNER JOIN srspn ON c4_cont.cont_empno = srspn.srspn_empno INNER JOIN srspn srspn_1 ON c4_cont.cont_modempno = srspn_1.srspn_empno WHERE 1=1 ");

            if (STRtbxContNo.ToString().Trim() != "")
            {
                sb.Append(@" AND (cont_contno=@STRtbxContNo) ");
            }

            if (STRtbxSDate.ToString().Trim() != "" && STRtbxEDate.ToString().Trim() != "")
            {
                sb.Append(@" AND (@STRtbxSDate <= cont_signdate AND cont_signdate <= @STRtbxEDate) ");
            }

            if (STRddlEmpData.ToString().Trim() != "")
            {
                sb.Append(@" AND (cont_empno=@STRddlEmpData) ");
            }

            if (STRddlClosed.ToString().Trim() != "")
            {
                sb.Append(@" AND (cont_fgclosed=@STRddlClosed) ");
            }

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@STRtbxContNo", STRtbxContNo);
            if (STRtbxSDate.ToString().Trim() != "")
            {
                oCmd.Parameters.AddWithValue("@STRtbxSDate", STRtbxSDate.ToString().Substring(0, 4) + STRtbxSDate.ToString().Substring(5, 2) + STRtbxSDate.ToString().Substring(8, 2));
            }
            if (STRtbxEDate.ToString().Trim() != "")
            {
                oCmd.Parameters.AddWithValue("@STRtbxEDate", STRtbxEDate.ToString().Substring(0, 4) + STRtbxEDate.ToString().Substring(5, 2) + STRtbxEDate.ToString().Substring(8, 2));
            }
            oCmd.Parameters.AddWithValue("@STRddlEmpData", STRddlEmpData);
            oCmd.Parameters.AddWithValue("@STRddlClosed", STRddlClosed);
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


        public DataSet GetOrByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *");
            sb.Append(@" FROM c4_or WHERE or_contno=@contno ");
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
    }
}
