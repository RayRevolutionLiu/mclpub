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
    public class iaFm1_Recia_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, ");
            sb.Append(@"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno");
            sb.Append(@", dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate,");
            sb.Append(@" dbo.c2_cont.cont_edate, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_custno, RTRIM(dbo.cust.cust");
            sb.Append(@"_nm) AS cust_nm, dbo.cust.cust_tel, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pa");
            sb.Append(@"idamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_oldcontno, dbo.c2_cont.cont_mo");
            sb.Append(@"ddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, dbo.c2_cont.cont_f");
            sb.Append(@"gcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgp");
            sb.Append(@"ubed, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.invmfr.im_imseq, RTRIM(dbo.invmfr.i");
            sb.Append(@"m_nm) AS im_nm, dbo.cust.cust_custno, dbo.invmfr.im_contno, dbo.invmfr.im_syscd,");
            sb.Append(@" dbo.mfr.mfr_mfrno, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname)");
            sb.Append(@" AS srspn_cname, dbo.book.bk_bkcd, dbo.srspn.srspn_empno, dbo.c2_cont.cont_totjt");
            sb.Append(@"m, dbo.c2_cont.cont_tottm FROM dbo.c2_cont INNER JOIN dbo.invmfr ON dbo.c2_cont.");
            sb.Append(@"cont_syscd = dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_con");
            sb.Append(@"tno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER ");
            sb.Append(@"JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book O");
            sb.Append(@"N dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.srspn ON dbo.c2_cont.c");
            sb.Append(@"ont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgpayonce = '1') AND (");
            sb.Append(@"dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2");
            sb.Append(@"_cont.cont_fgpubed = '1') ");
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


        public DataSet Selectia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq,");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            sb.Append(@" dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_refno, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat,");
            sb.Append(@" dbo.ia.ia_ivat, dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rzip)");
            sb.Append(@" AS ia_rzip, RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status,");
            sb.Append(@" RTRIM(dbo.ia.ia_cname) AS ia_cname, RTRIM(dbo.ia.ia_tel) AS ia_tel, dbo.ia.ia_contno, dbo.iad.iad_iadid, dbo.iad.iad_syscd, dbo.iad.iad_iano, dbo.iad.iad_iaditem,");
            sb.Append(@" dbo.iad.iad_fk1, dbo.iad.iad_fk2, dbo.iad.iad_fk3, dbo.iad.iad_fk4, dbo.iad.iad_projno, dbo.iad.iad_costctr, RTRIM(dbo.iad.iad_desc) AS iad_desc,");
            sb.Append(@" dbo.iad.iad_qty, dbo.iad.iad_unit, dbo.iad.iad_uprice, dbo.iad.iad_amt, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm FROM dbo.ia INNER JOIN dbo.iad ON ");
            sb.Append(@"dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c2_cont ON dbo.iad.iad_fk1 = dbo.c2_cont.cont_contno");
            sb.Append(@" INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.c2_cont.cont_fgpayonce = '1') ORDER BY dbo.ia.ia_iano DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public void UPDATEc2_pub(string syscd, string contno, string yyyymm, string pubseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c2_pub SET pub_fginved = ' ' WHERE (pub_fginved = '1') AND (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@pubseq", pubseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void Callsp_c2_delete_ia_1(string syscd, string contno, string yyyymm, string pubseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c2_delete_ia_1");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@pubseq", pubseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void UDPATEc2_cont(string paidamt, string restamt, string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c2_cont SET cont_paidamt = @paidamt, cont_restamt = @restamt WHERE (cont_syscd = 'C2') AND (cont_contno = @contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@paidamt", paidamt);
            oCmd.Parameters.AddWithValue("@restamt", restamt);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}