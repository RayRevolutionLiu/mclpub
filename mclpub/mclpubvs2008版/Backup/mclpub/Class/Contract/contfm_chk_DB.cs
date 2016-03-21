using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;


namespace mclpub
{
    public class contfm_chk_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelectC2_pub(string dpstr)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            if (dpstr.ToString() == "1")
            {
                sb.Append(@"SELECT dbo.c2_cont.cont_contid, dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno,RTRIM(dbo.c2_cont.cont_custno) AS cont_custno,");
                sb.Append(@"dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c");
                sb.Append(@"2_cont.cont_empno, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.co");
                sb.Append(@"nt_autel, dbo.c2_cont.cont_aufax, dbo.c2_cont.cont_aucell, dbo.c2_cont.cont_auem");
                sb.Append(@"ail, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_totjtm, db");
                sb.Append(@"o.c2_cont.cont_madejtm, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont_disc, dbo.c2_");
                sb.Append(@"cont.cont_freetm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_tottm, dbo.c2_cont");
                sb.Append(@".cont_pubtm, dbo.c2_cont.cont_resttm, dbo.c2_cont.cont_chgjtm, dbo.c2_cont.cont_");
                sb.Append(@"custno, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pubamt, dbo.c2_cont.cont_chgam");
                sb.Append(@"t, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_clrtm, d");
                sb.Append(@"bo.c2_cont.cont_menotm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_oldcontno, d");
                sb.Append(@"bo.c2_cont.cont_moddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, ");
                sb.Append(@"dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_adamt, dbo");
                sb.Append(@".c2_cont.cont_freebkcnt, dbo.c2_cont.cont_remark, dbo.c2_cont.cont_fgtemp, dbo.c");
                sb.Append(@"2_cont.cont_fgpubed, dbo.c2_cont.cont_restclrtm, dbo.c2_cont.cont_restmenotm, db");
                sb.Append(@"o.c2_cont.cont_restgetclrtm, dbo.c2_cont.cont_njtpcnt, RTRIM(dbo.book.bk_nm) AS ");
                sb.Append(@"bk_nm, dbo.book.bk_bkcd, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.mfr.mfr_mf");
                sb.Append(@"rno) AS mfr_mfrno, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname FROM dbo.c2_cont ");
                sb.Append(@"INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.m");
                sb.Append(@"fr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.srspn ON dbo.c2_");
                sb.Append(@"cont.cont_empno = dbo.srspn.srspn_empno WHERE 1=1 AND (cont_clrtm = 0) AND (cont_getclrtm = 0) AND (cont_menotm = 0) ORDER BY c2_cont.cont_contno ASC");
            }
            if (dpstr.ToString() == "2")
            {
                sb.Append(@"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, dbo.c2_cont.cont_bkcd,");
                sb.Append(@" RTRIM(dbo.c2_pub.pub_modempno) AS pub_modempno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm,");
                sb.Append(@" dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_conttp, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.c2_cont.cont_signdate,");
                sb.Append(@" RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.c2_cont.cont_custno) AS cont_custno, RTRIM(dbo.cust.cust_nm) AS cust_nm,");
                sb.Append(@" dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_disc, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_getclrtm,");
                sb.Append(@" dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_oldcontno, dbo.srspn.srspn_cname, dbo.srspn.srspn_empno");
                sb.Append(@" FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno AND");
                sb.Append(@" dbo.c2_cont.cont_empno <> dbo.c2_pub.pub_modempno INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno ");
                sb.Append(@"INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno");
                sb.Append(@" WHERE 1=1 AND (cont_fgtemp = '0') AND (cont_fgcancel = '0') AND (cont_fgpubed = '1') ORDER BY c2_cont.cont_contno ASC");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }
    }
}
