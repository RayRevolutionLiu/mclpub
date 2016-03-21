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
    public class iaFm1_Rec_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            //sb.Append(@"");
            sb.Append(@"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm,");
            sb.Append(@" c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_fgclosed, c2_cont.cont_custno, RTRIM(cust.cust_nm) AS cust_nm, cust.cust_tel, c2_cont.cont_totamt, c2_cont.cont_paidamt");
            sb.Append(@", c2_cont.cont_restamt, c2_cont.cont_oldcontno, c2_cont.cont_moddate, c2_cont.cont_fgpayonce, c2_cont.cont_modempno, c2_cont.cont_fgcancel, c2_cont.cont_credate,");
            sb.Append(@" c2_cont.cont_fgtemp, c2_cont.cont_fgpubed, RTRIM(mfr.mfr_inm) AS mfr_inm, invmfr.im_imseq, RTRIM(invmfr.im_nm) AS im_nm, cust.cust_custno, invmfr.im_contno, invmfr.im_syscd");
            sb.Append(@", mfr.mfr_mfrno, RTRIM(book.bk_nm) AS bk_nm, RTRIM(srspn.srspn_cname) AS srspn_cname, book.bk_bkcd, srspn.srspn_empno, c2_cont.cont_totjtm, c2_cont.cont_tottm");
            sb.Append(@" FROM c2_cont INNER JOIN invmfr ON c2_cont.cont_syscd = invmfr.im_syscd AND c2_cont.cont_contno = invmfr.im_contno INNER JOIN cust ON c2_cont.cont_custno");
            sb.Append(@" = cust.cust_custno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN srspn ON c2_cont.cont_empno = ");
            sb.Append(@"srspn.srspn_empno WHERE (c2_cont.cont_fgpayonce = '1') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_fgpubed = '1')");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            //sb.Append(@"");
            sb.Append(@"SELECT DISTINCT ia.ia_syscd, ia.ia_iano, RTRIM(ia.ia_mfrno) AS ia_mfrno, RTRIM(ia.ia_contno) AS ia_contno, RTRIM(ia.ia_rnm) AS ia_rnm, invmfr.im_imseq");
            sb.Append(@" FROM ia INNER JOIN invmfr ON ia.ia_syscd = invmfr.im_syscd AND ia.ia_rnm = invmfr.im_nm WHERE (ia.ia_syscd = 'C2') ORDER BY ia.ia_iano");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectia2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, ia.ia_iasseq, ia.ia_iaitem, ia.ia_iano, ia.ia_refno, ia.ia_mfrno, ia.ia_pyno, ia.ia_pyseq, ia.ia_pyat, ia.ia_ivat, ia.ia_invno,");
            sb.Append(@" ia.ia_invdate, ia.ia_fgitri, ia.ia_rnm, ia.ia_raddr, ia.ia_rzip, ia.ia_rjbti, ia.ia_rtel, ia.ia_fgnonauto, ia.ia_invcd, ia.ia_taxtp, ia.ia_status, ia.ia_cname, ia.ia_tel");
            sb.Append(@", ia.ia_contno, RTRIM(mfr.mfr_inm) AS mfr_inm FROM ia INNER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (ia.ia_syscd = 'C2') AND (ia.ia_status = ' ')");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}