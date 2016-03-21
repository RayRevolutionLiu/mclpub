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
    public class iaFm1_chklist_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectMAXia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MAX(ia_iano) AS MaxIANno FROM ia WHERE (ia_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectinvmfra()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_tel, im_invcd, im_taxtp, im_fgitri FROM invmfr ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectinvmfrachklist()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, im_imseq, im_mfrno, RTRIM(im_nm) AS im_nm FROM dbo.invmfr WHERE (im_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectc2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_fgclosed, c2_cont.cont_custno,");
            sb.Append(@" RTRIM(cust.cust_nm) AS cust_nm, cust.cust_tel, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_cont.cont_oldcontno, c2_cont.cont_moddate,");
            sb.Append(@" c2_cont.cont_fgpayonce, c2_cont.cont_modempno, c2_cont.cont_fgcancel, c2_cont.cont_credate, c2_cont.cont_fgtemp, c2_cont.cont_fgpubed, RTRIM(mfr.mfr_inm)");
            sb.Append(@" AS mfr_inm, invmfr.im_imseq, RTRIM(invmfr.im_nm) AS im_nm, cust.cust_custno, invmfr.im_contno, invmfr.im_syscd, mfr.mfr_mfrno, RTRIM(book.bk_nm)");
            sb.Append(@" AS bk_nm, RTRIM(srspn.srspn_cname) AS srspn_cname, book.bk_bkcd, srspn.srspn_empno, c2_cont.cont_totjtm, c2_cont.cont_tottm FROM c2_cont INNER JOIN invmfr ON");
            sb.Append(@" c2_cont.cont_syscd = invmfr.im_syscd AND c2_cont.cont_contno = invmfr.im_contno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON");
            sb.Append(@" c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno");
            sb.Append(@" WHERE (c2_cont.cont_fgpayonce = '1') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_fgpubed = '1')");
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
            sb.Append(@"SELECT ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, ia.ia_iasseq, ia.ia_iaitem, ia.ia_iano, ia.ia_refno, RTRIM(ia.ia_mfrno) AS ia_mfrno, ia.ia_pyno, ia.ia_pyseq, ia.ia_pyat, ia.ia_ivat, ia.ia_invno, ia.ia_invdate,");
            sb.Append(@" ia.ia_fgitri, RTRIM(ia.ia_rnm) AS ia_rnm, RTRIM(ia.ia_raddr) AS ia_raddr, RTRIM(ia.ia_rzip) AS ia_rzip, RTRIM(ia.ia_rjbti) AS ia_rjbti, RTRIM(ia.ia_rtel) AS ia_rtel,");
            sb.Append(@" ia.ia_fgnonauto, ia.ia_invcd, ia.ia_taxtp, ia.ia_status, RTRIM(ia.ia_cname) AS ia_cname, RTRIM(ia.ia_tel) AS ia_tel, ia.ia_contno, iad.iad_iadid, iad.iad_syscd,");
            sb.Append(@" iad.iad_iano, iad.iad_iaditem, iad.iad_fk1, iad.iad_fk2, iad.iad_fk3, iad.iad_fk4, iad.iad_projno, iad.iad_costctr, RTRIM(iad.iad_desc) AS iad_desc, iad.iad_qty");
            sb.Append(@", iad.iad_unit, iad.iad_uprice, iad.iad_amt, RTRIM(mfr.mfr_inm) AS mfr_inm FROM ia INNER JOIN iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano ");
            sb.Append(@"INNER JOIN c2_cont ON iad.iad_fk1 = c2_cont.cont_contno INNER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (c2_cont.cont_fgpayonce = '1') ORDER BY ia.ia_iano DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectiachklist()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_refno,");
            sb.Append(@" dbo.ia.ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat, dbo.ia.ia_ivat, dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.ia.ia_raddr,");
            sb.Append(@" dbo.ia.ia_rzip, dbo.ia.ia_rjbti, dbo.ia.ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, dbo.ia.ia_cname, dbo.ia.ia_tel, dbo.ia.ia_contno,");
            sb.Append(@" RTRIM(dbo.mfr.mfr_inm) AS mfr_inm FROM dbo.ia INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_syscd = 'C2') AND (RTRIM(LTRIM(dbo.ia.ia_status)) = '')");
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