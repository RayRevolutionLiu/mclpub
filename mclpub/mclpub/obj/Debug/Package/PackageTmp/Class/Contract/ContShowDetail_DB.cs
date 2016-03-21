using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class ContShowDetail_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelecAllValue(string cust_custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cust.cust_custid, cust.cust_custno, RTRIM(cust.cust_nm) AS cust_nm, RTRIM(cust.cust_mfrno) AS cust_mfrno, ");
            sb.Append(@"cust.cust_jbti, cust.cust_tel, cust.cust_fax, mfr.mfr_mfrid, RTRIM(mfr.mfr_mfrno) AS mfr_mfrno,");
            sb.Append(@" RTRIM(mfr.mfr_inm) AS mfr_inm, RTRIM(mfr.mfr_respnm) AS mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, ");
            sb.Append(@" RTRIM(mfr.mfr_fax) AS mfr_fax, RTRIM(mfr.mfr_iaddr) AS mfr_iaddr, mfr.mfr_izip, mfr.mfr_regdate, cust.cust_cell,");
            sb.Append(@" cust.cust_email, RTRIM(cust.cust_oldcustno) AS cust_oldcustno, RTRIM(cust.cust_orgisyscd) AS cust_orgisyscd,");
            sb.Append(@" cust.cust_regdate, cust.cust_moddate, mfr.mfr_mfrno AS Expr1 ");
            sb.Append(@" FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno WHERE 1=1 AND cust_custno=@cust_custno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectBooks()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, RTRIM(proj.proj_fgitri) AS proj_fgitri,");
            sb.Append(@" proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr,");
            sb.Append(@" proj.proj_bkcd, proj.proj_fgitri AS Expr1 ");
            sb.Append(@" FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd ");
            sb.Append(@" WHERE (proj.proj_syscd = 'C2') AND proj_fgitri='' ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel,");
            sb.Append(@" srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srspn_empno");
            sb.Append(@" FROM srspn WHERE (srspn_atype <> 'A') AND (srspn_atype <> 'E') AND (srspn_atype <> 'F')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectContract(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax,");
            sb.Append(@" cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, ");
            sb.Append(@" cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm,");
            sb.Append(@" cont_oldcontno, cont_moddate, cont_fgpayonce, cont_modempno, cont_fgcancel, cont_credate, cont_adamt, cont_freebkcnt, cont_remark, cont_fgtemp, cont_fgpubed,");
            sb.Append(@" cont_restclrtm, cont_restmenotm, cont_restgetclrtm, cont_njtpcnt FROM c2_cont WHERE 1=1 AND cont_contno=@cont_contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable Selectinvmfr(string im_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, ");
            sb.Append(@"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM invmfr WHE");
            sb.Append(@"RE (im_syscd = 'C2') AND im_syscd='C2' AND im_contno=@im_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@im_contno", im_contno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable Selectc2_or(string or_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, o");
            sb.Append(@"r_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea F");
            sb.Append(@"ROM c2_or WHERE 1=1 AND or_syscd='C2' AND or_contno=@or_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@or_contno", or_contno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable Selectmtp(string mtp_mtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpcd, mtp_nm FROM mtp WHERE 1=1 AND mtp_mtpcd=@mtp_mtpcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mtp_mtpcd", mtp_mtpcd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }




        //落版資料
        public DataSet SelectC2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2");
            sb.Append(@"_pub.pub_pubseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd");
            sb.Append(@", dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.");
            sb.Append(@"pub_drafttp, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pub_ori");
            sb.Append(@"gjbkno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, ");
            sb.Append(@"dbo.c2_pub.pub_fgrechg, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub.");
            sb.Append(@"pub_projno, dbo.c2_pub.pub_costctr, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginv");
            sb.Append(@"self, dbo.c2_pub.pub_pno, dbo.c2_pub.pub_remark, dbo.c2_pub.pub_fgfixpg, dbo.c2_");
            sb.Append(@"pub.pub_moddate, dbo.c2_pub.pub_modempno, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_im");
            sb.Append(@"seq, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, dbo.c2_ltp.ltp_nm, dbo.c2_c");
            sb.Append(@"lr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_njtp.njtp_nm, dbo.srspn.srspn_cname, dbo");
            sb.Append(@".invmfr.im_nm, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_lt");
            sb.Append(@"p.ltp_ltpcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.invmfr.im_con");
            sb.Append(@"tno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.srspn.srspn_empno FROM dbo.c2");
            sb.Append(@"_pub INNER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER ");
            sb.Append(@"JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2");
            sb.Append(@"_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd INNER JOIN dbo.srspn O");
            sb.Append(@"N dbo.c2_pub.pub_modempno = dbo.srspn.srspn_empno INNER JOIN dbo.invmfr ON dbo.c");
            sb.Append(@"2_pub.pub_syscd = dbo.invmfr.im_syscd AND dbo.c2_pub.pub_contno = dbo.invmfr.im_");
            sb.Append(@"contno AND dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq LEFT OUTER JOIN dbo.c2_njt");
            sb.Append(@"p ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON");
            sb.Append(@" dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pub");
            return ds;

        }
    }
}
