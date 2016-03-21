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
    public class PubFm_chklist_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_pub(string STRtbxDate1, string STRtbxDate2, string STRtbxContNo, string STRtbxMfrIName)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.c2_pub.pub_contno, dbo.mfr.mfr_inm FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno WHERE 1=1 ");
            if (STRtbxDate1 != "" && STRtbxDate2 != "")
            {
                sb.Append(@"AND (dbo.c2_pub.pub_yyyymm >= @date1) AND (dbo.c2_pub.pub_yyyymm <= @date2)");
            }

            if (STRtbxContNo != "")
            {
                sb.Append(@" AND (pub_contno Like '%'+@STRtbxContNo+'%') ");
            }

            if (STRtbxMfrIName != "")
            {
                sb.Append(@" AND (mfr_inm Like '%'+@STRtbxMfrIName+'%') ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@date1", STRtbxDate1 == "" ? "" : STRtbxDate1.Substring(0, 4) + STRtbxDate1.Substring(5, 2));
            oCmd.Parameters.AddWithValue("@date2", STRtbxDate2 == "" ? "" : STRtbxDate2.Substring(0, 4) + STRtbxDate2.Substring(5, 2));
            oCmd.Parameters.AddWithValue("@STRtbxContNo", STRtbxContNo);
            oCmd.Parameters.AddWithValue("@STRtbxMfrIName", STRtbxMfrIName);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet SelectInvmfr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, ");
            sb.Append(@"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM dbo.invmfr WHERE im_syscd='C2' ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectc2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp");
            sb.Append(@", dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.c2_cont.cont_sdate");
            sb.Append(@", dbo.c2_cont.cont_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_disc, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_adamt, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_getclrtm");
            sb.Append(@", dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_custno, dbo.cust.cust_nm, dbo.c2_cont.cont_fgclosed");
            sb.Append(@", dbo.c2_cont.cont_oldcontno, dbo.mfr.mfr_inm, dbo.c2_cont.cont_freebkcnt, dbo.c2_cont.cont_remark, dbo.c2_cont.cont_njtpcnt, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c2_cont.cont_freetm");
            sb.Append(@", dbo.c2_cont.cont_chgjtm FROM dbo.c2_cont INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectc2_pub2(string date1, string date2, string strContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, ");
            sb.Append(@"dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd");
            sb.Append(@", dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_drafttp,");
            sb.Append(@" dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pub_origjbkno,");
            sb.Append(@"  dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, ");
            sb.Append(@" dbo.c2_pub.pub_fgrechg, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub_projno,");
            sb.Append(@"dbo.c2_pub.pub_costctr, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginvself,");
            sb.Append(@"dbo.c2_pub.pub_pno, dbo.c2_pub.pub_remark, dbo.c2_pub.pub_fgfixpg, ");
            sb.Append(@"dbo.c2_pub.pub_moddate, dbo.c2_pub.pub_modempno, dbo.c2_pub.pub_bkcd, ");
            sb.Append(@"dbo.c2_pub.pub_imseq, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, ");
            sb.Append(@"dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_njtp.njtp_nm,");
            sb.Append(@"dbo.srspn.srspn_cname, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd,");
            sb.Append(@"dbo.c2_ltp.ltp_ltpcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd,");
            sb.Append(@"dbo.srspn.srspn_empno, dbo.invmfr.im_nm, dbo.invmfr.im_mfrno, dbo.invmfr.im_contno, ");
            sb.Append(@"dbo.invmfr.im_imseq, dbo.invmfr.im_syscd FROM dbo.c2_pub ");
            sb.Append(@"INNER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN ");
            sb.Append(@"dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ");
            sb.Append(@"ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd INNER JOIN dbo.srspn ON ");
            sb.Append(@"dbo.c2_pub.pub_modempno = dbo.srspn.srspn_empno INNER JOIN dbo.invmfr ");
            sb.Append(@"ON dbo.c2_pub.pub_syscd = dbo.invmfr.im_syscd AND dbo.c2_pub.pub_contno = dbo.invmfr.im_contno AND dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq LEFT ");
            sb.Append(@"OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN ");
            sb.Append(@"dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd WHERE 1=1 ");
            if (date1 != "" && date2 != "")
            {
                sb.Append(@" AND (pub_yyyymm >= @date1)  AND (pub_yyyymm <= @date2)");
            }
            sb.Append(@" AND (pub_contno like '%'+@strContNo+'%')");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@date1", date1);
            oCmd.Parameters.AddWithValue("@date2", date2);
            oCmd.Parameters.AddWithValue("@strContNo", strContNo);
            //oCmd.Parameters.AddWithValue("@STRtbxMfrIName", STRtbxMfrIName);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}