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
    public class PubFm_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_clr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT clr_clrid, clr_clrcd, RTRIM(clr_nm) AS clr_nm FROM dbo.c2_clr");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_ltp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ltp_ltpcd, RTRIM(ltp_nm) AS ltp_nm FROM dbo.c2_ltp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pgs()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pgs_pgscd, RTRIM(pgs_nm) AS pgs_nm FROM dbo.c2_pgsize");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_njtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT njtp_njtpcd, RTRIM(njtp_nm) AS njtp_nm FROM dbo.c2_njtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet SelectBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr, dbo.fgitri.fgitri_name, dbo.fgitri.fgitri_fgitri FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd INNER JOIN dbo.fgitri ON dbo.proj.proj_fgitri = dbo.fgitri.fgitri_fgitri WHERE (dbo.proj.proj_syscd = 'C2')");
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
            sb.Append(@"SELECT dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_modempno, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_chgjtm, dbo.c2_cont.cont_custno, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pubamt");
            sb.Append(@", dbo.c2_cont.cont_chgamt, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_adamt, dbo.c2_cont.cont_freebkcnt, dbo.c2_cont.cont_freetm");
            sb.Append(@", dbo.c2_cont.cont_tottm + dbo.c2_cont.cont_freetm AS MaxPubTime, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_fgclosed");
            sb.Append(@", dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_restclrtm, dbo.c2_cont.cont_restmenotm, dbo.c2_cont.cont_restgetclrtm, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt");
            sb.Append(@", dbo.c2_cont.cont_pubtm, dbo.c2_cont.cont_resttm, dbo.c2_cont.cont_madejtm, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont_disc, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.cust.cust_nm)");
            sb.Append(@" AS cust_nm FROM dbo.c2_cont INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet Selectc2_cont2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_cont.cont_fgclosed, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_imseq FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet Selectinvmfr(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, im_imseq, im_nm, im_fgitri FROM dbo.invmfr WHERE (im_syscd = 'C2') AND (im_contno = @contno) ORDER BY im_imid DESC");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectinvmfr2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, COUNT(*) AS CountNo FROM dbo.invmfr WHERE (im_syscd = 'C2') GROUP BY im_syscd, im_contno");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet Selectc2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 100 PERCENT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pu");
            sb.Append(@"b_pubseq, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pno, dbo.c2_pub.pub_pgno, dbo.c2");
            sb.Append(@"_pub.pub_bkcd, dbo.c2_pub.pub_clrcd,case ISNULL(dbo.c2_pub.pub_pulpg,'0') WHEN '0' THEN '否' WHEN '1' THEN '是' END AS pub_pulpg, dbo.c2_clr.clr_nm, dbo.c2_pub.pub_ltpcd, db");
            sb.Append(@"o.c2_ltp.ltp_nm, dbo.c2_pub.pub_pgscd, dbo.c2_pgsize.pgs_nm, dbo.c2_pub.pub_fgfi");
            sb.Append(@"xpg, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_drafttp, dbo.c2_pub.pub_adamt, dbo.c2_");
            sb.Append(@"pub.pub_chgamt, dbo.invmfr.im_imseq, dbo.invmfr.im_nm, dbo.c2_pub.pub_imseq, dbo");
            sb.Append(@".c2_pub.pub_fgupdated, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_ltpcd, dbo.c2_pgsize");
            sb.Append(@".pgs_pgscd, dbo.invmfr.im_contno, dbo.invmfr.im_syscd, dbo.c2_pub.pub_fginved, d");
            sb.Append(@"bo.c2_pub.pub_fginvself, dbo.c2_pub.pub_fgact, dbo.c2_pub.pub_moddate, dbo.c2_pu");
            sb.Append(@"b.pub_origjbkno, dbo.c2_pub.pub_chgjbkno, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pu");
            sb.Append(@"b_origjno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_fgrechg");
            sb.Append(@", dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_costctr, dbo.fgit");
            sb.Append(@"ri.fgitri_fgitri, dbo.invmfr.im_fgitri, dbo.fgitri.fgitri_name FROM dbo.fgitri I");
            sb.Append(@"NNER JOIN dbo.invmfr ON dbo.fgitri.fgitri_fgitri = dbo.invmfr.im_fgitri COLLATE ");
            sb.Append(@"Chinese_Taiwan_Stroke_BIN RIGHT OUTER JOIN dbo.c2_pub INNER JOIN dbo.c2_clr ON d");
            sb.Append(@"bo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_ltp ON dbo.c2_pub.p");
            sb.Append(@"ub_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd");
            sb.Append(@" = dbo.c2_pgsize.pgs_pgscd ON dbo.invmfr.im_imseq = dbo.c2_pub.pub_imseq AND dbo");
            sb.Append(@".invmfr.im_syscd = dbo.c2_pub.pub_syscd AND dbo.invmfr.im_contno = dbo.c2_pub.pu");
            sb.Append(@"b_contno ORDER BY dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yy");
            sb.Append(@"yymm, dbo.c2_pub.pub_pubseq");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pub");
            return ds;
        }


        public DataSet SelectTop1c2_pub(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 1 dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pu");
            sb.Append(@"b_pubseq, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pno, dbo.c2_pub.pub_pgno, dbo.c2");
            sb.Append(@"_pub.pub_bkcd, dbo.c2_pub.pub_clrcd, dbo.c2_clr.clr_nm, dbo.c2_pub.pub_ltpcd, db");
            sb.Append(@"o.c2_ltp.ltp_nm, dbo.c2_pub.pub_pgscd, dbo.c2_pgsize.pgs_nm, dbo.c2_pub.pub_fgfi");
            sb.Append(@"xpg, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_drafttp, dbo.c2_pub.pub_adamt, dbo.c2_");
            sb.Append(@"pub.pub_chgamt, dbo.invmfr.im_imseq, dbo.invmfr.im_nm, dbo.c2_pub.pub_imseq, dbo");
            sb.Append(@".c2_pub.pub_fgupdated, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_ltpcd, dbo.c2_pgsize");
            sb.Append(@".pgs_pgscd, dbo.invmfr.im_contno, dbo.invmfr.im_syscd, dbo.c2_pub.pub_fginved, d");
            sb.Append(@"bo.c2_pub.pub_fginvself, dbo.c2_pub.pub_fgact, dbo.c2_pub.pub_moddate, dbo.c2_pu");
            sb.Append(@"b.pub_origjbkno, dbo.c2_pub.pub_chgjbkno, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pu");
            sb.Append(@"b_origjno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_fgrechg");
            sb.Append(@", dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_costctr, dbo.fgit");
            sb.Append(@"ri.fgitri_fgitri, dbo.invmfr.im_fgitri, dbo.fgitri.fgitri_name FROM dbo.fgitri I");
            sb.Append(@"NNER JOIN dbo.invmfr ON dbo.fgitri.fgitri_fgitri = dbo.invmfr.im_fgitri COLLATE ");
            sb.Append(@"Chinese_Taiwan_Stroke_BIN RIGHT OUTER JOIN dbo.c2_pub INNER JOIN dbo.c2_clr ON d");
            sb.Append(@"bo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_ltp ON dbo.c2_pub.p");
            sb.Append(@"ub_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd");
            sb.Append(@" = dbo.c2_pgsize.pgs_pgscd ON dbo.invmfr.im_imseq = dbo.c2_pub.pub_imseq AND dbo");
            sb.Append(@".invmfr.im_syscd = dbo.c2_pub.pub_syscd AND dbo.invmfr.im_contno = dbo.c2_pub.pu");
            sb.Append(@"b_contno WHERE 1=1 ");
            if (contno.ToString().Trim() != "")
            {
                sb.Append(@" AND pub_syscd = 'C2' AND pub_contno=@pub_contno ");
            }
            sb.Append(@" ORDER BY pub_yyyymm DESC");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            oCmd.Parameters.AddWithValue("@pub_contno", contno);
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Updatec2_cont(string syscd, string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c2_cont SET cont_fgpubed = '0' WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet Selectc2_pub2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, SUM(pub_adamt) AS pub_adamt, SUM(pub_chgamt) AS pub_chgamt, COUNT(*) AS CountNo FROM dbo.c2_pub GROUP BY pub_syscd, pub_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pub");
            return ds;
        }

        public DataSet Selectc2_pub3()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, pub_drafttp, COUNT(*) AS CountNo FROM dbo.c2_pub GROUP BY pub_syscd, pub_contno, pub_drafttp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pub");
            return ds;
        }

        public DataSet Selectc2_pub4()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, SUM(pub_adamt) AS pub_adamt, SUM(pub_chgamt) AS pub_chgamt, COUNT(*) AS CountNo FROM dbo.c2_pub GROUP BY pub_syscd, pub_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_pub");
            return ds;
        }


        public void Deletec2_pub(string syscd, string contno, string yyyymm, string pubseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM c2_pub WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
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

        public DataSet Selectc2_pub5(string contno, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, pub_yyyymm, MAX(pub_pubseq) AS MaxPubSeq FROM dbo.c2_pub WHERE (pub_syscd = 'C2') AND (pub_contno = @contno)");
            sb.Append(@" AND (pub_yyyymm = @yyyymm) GROUP BY pub_syscd, pub_contno, pub_yyyymm");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet Selectc2_cont3()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cont_syscd, cont_contno, cont_totjtm, cont_madejtm, cont_restjtm, cont_tottm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_pubamt, cont_chgamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_adamt, cont_restclrtm, cont_restmenotm, cont_restgetclrtm, cont_fgpubed, cont_njtpcnt FROM dbo.c2_cont");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet Selectc2_pub6()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, pub_clrcd, COUNT(*) AS CountNo FROM dbo.c2_pub GROUP BY pub_syscd, pub_contno, pub_clrcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub7()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, SUM(pub_adamt) AS pub_adamt, SUM(pub_chgamt) AS pub_chgamt, COUNT(*) AS CountNo FROM dbo.c2_pub GROUP BY pub_syscd, pub_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub8()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, pub_drafttp, COUNT(*) AS CountNo FROM dbo.c2_pub GROUP BY pub_syscd, pub_contno, pub_drafttp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub9()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, COUNT(*) AS CountNo FROM dbo.c2_pub WHERE (pub_syscd = 'C2') GROUP BY pub_syscd, pub_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub10()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, pub_contno, pub_drafttp, COUNT(*) AS CountNo FROM dbo.c2_pub WHERE (pub_drafttp = '2') GROUP BY pub_syscd, pub_contno, pub_drafttp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Updatec2_cont2(float pubamt, float chgamt, string fgpubed, int restclrtm, int restmenotm, int restgetclrtm, int madejtm, int restjtm,
            int pubtm, int resttm, int njtpcnt, string syscd, string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c2_cont SET cont_pubamt = @pubamt, cont_chgamt = @chgamt, cont_fgpubed = @fgpubed, cont_restclrtm = @restclrtm, cont_restmenotm = @restmenotm, cont_restgetclrtm = @restgetclrtm, cont_madejtm = @madejtm, cont_restjtm = @restjtm, cont_pubtm = @pubtm, cont_resttm = @resttm, cont_njtpcnt = @njtpcnt WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pubamt", pubamt);
            oCmd.Parameters.AddWithValue("@chgamt", chgamt);
            oCmd.Parameters.AddWithValue("@fgpubed", fgpubed);
            oCmd.Parameters.AddWithValue("@restclrtm", restclrtm);
            oCmd.Parameters.AddWithValue("@restmenotm", restmenotm);
            oCmd.Parameters.AddWithValue("@restgetclrtm", restgetclrtm);
            oCmd.Parameters.AddWithValue("@madejtm", madejtm);
            oCmd.Parameters.AddWithValue("@restjtm", restjtm);
            oCmd.Parameters.AddWithValue("@pubtm", pubtm);
            oCmd.Parameters.AddWithValue("@resttm", resttm);
            oCmd.Parameters.AddWithValue("@njtpcnt", njtpcnt);
            oCmd.Parameters.AddWithValue("@syscd", syscd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public DataSet Selectc2_pub11()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pub_syscd, ISNULL(pub_pulpg,'0') AS pub_pulpg, pub_contno, pub_yyyymm, pub_pubseq, pub_pgno, pub_ltpcd, pub_clrcd, pub_pgscd, pub_adamt, pub_chgamt, pub_drafttp, pub_origbkcd, pub_origjno, pub_origjbkno, pub_chgbkcd, pub_chgjno, pub_chgjbkno, pub_fgrechg, pub_fggot, pub_njtpcd, pub_projno, pub_costctr, pub_fginved, pub_fginvself, pub_pno, pub_remark, pub_fgfixpg, pub_moddate, pub_modempno, pub_bkcd, pub_imseq, pub_fgupdated, pub_fgact FROM dbo.c2_pub");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectbookp_get()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_nm, dbo.bookp.bkp_date, RTRIM(dbo.bookp.bkp_pno) AS bkp_pno, dbo.book.bk_bkcd, dbo.bookp.bkp_bkcd FROM dbo.bookp INNER JOIN dbo.book ON dbo.bookp.bkp_bkcd = dbo.book.bk_bkcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pgno()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pg_bkcd, pg_startpgno FROM dbo.c2_pgno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pubSave()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(*) AS CountNo, pub_contno, pub_yyyymm, pub_pubseq FROM dbo.c2_pub GROUP BY pub_yyyymm, pub_pubseq, pub_contno ORDER BY pub_contno, pub_yyyymm, pub_pubseq DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_lprior()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT lp_bkcd, lp_priorseq, lp_ltpcd, lp_clrcd, lp_pgscd FROM dbo.c2_lprior");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Insertc2_pub(string strSyscd, string strContNo, string strYYYYMM, string strPubSeq, int strPgNo, string strLtpcd, string strClrcd, string strPgscd,
    float strAdAmt, float strChgAmt, string strDrafttp, string strOrigBkcd, int strOrigJNo, int strOrigBkno, string strChgBkcd, int strChgJNo, int strChgBkno, string strfgReChg, string strfgGot, string strNjtpcd,
             string strProjNo, string strCostCtr, string strfgInvcd, string strfgInvSelf, string strPNo, string strRemark, string strfgFixPg, string strModDate, string strModEmpNo, string strBkcd, string strImSeq
            , string strfgUpdated, string strfgAct, string strpulpg)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"INSERT INTO c2_pub (pub_syscd, pub_contno, pub_yyyymm, pub_pubseq, pub_pgno, pub_ltpcd, pub_clrcd, pub_pgscd, pub_adamt, pub_chgamt, pub_drafttp, pub_origbkcd, pub_origjno, pub_origjbkno, pub_chgbkcd, pub_chgjno, pub_chgjbkno, pub_fgrechg, pub_fggot, pub_njtpcd, pub_projno, pub_costctr, pub_fginved, pub_fginvself, pub_pno, pub_remark, pub_fgfixpg, pub_moddate, pub_modempno, pub_bkcd, pub_imseq, pub_fgupdated, pub_fgact, pub_pulpg) VALUES (@syscd, @contno, @yyyymm, @pubseq, @pgno, @ltpcd, @clrcd, @pgscd, @adamt, @chgamt, @drafttp, @origbkcd, @origjno, @origjbkno, @chgbkcd, @chgjno, @chgjbkno, @fgrechg, @fggot, @njtpcd, @projno, @costctr, @fginved, @fginvself, @pno, @remark, @fgfixpg, @moddate, @modempno, @bkcd, @imseq, @fgupdated, @fgact, @strpulpg)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Parameters.AddWithValue("@yyyymm", strYYYYMM);
            oCmd.Parameters.AddWithValue("@pubseq", strPubSeq);
            oCmd.Parameters.AddWithValue("@pgno", strPgNo);
            oCmd.Parameters.AddWithValue("@ltpcd", strLtpcd);
            oCmd.Parameters.AddWithValue("@clrcd", strClrcd);
            oCmd.Parameters.AddWithValue("@pgscd", strPgscd);
            oCmd.Parameters.AddWithValue("@adamt", strAdAmt);
            oCmd.Parameters.AddWithValue("@chgamt", strChgAmt);
            oCmd.Parameters.AddWithValue("@drafttp", strDrafttp);
            oCmd.Parameters.AddWithValue("@origbkcd", strOrigBkcd);
            oCmd.Parameters.AddWithValue("@origjno", strOrigJNo);
            oCmd.Parameters.AddWithValue("@origjbkno", strOrigBkno);
            oCmd.Parameters.AddWithValue("@chgbkcd", strChgBkcd);
            oCmd.Parameters.AddWithValue("@chgjno", strChgJNo);
            oCmd.Parameters.AddWithValue("@chgjbkno", strChgBkno);
            oCmd.Parameters.AddWithValue("@fgrechg", strfgReChg);
            oCmd.Parameters.AddWithValue("@fggot", strfgGot);
            oCmd.Parameters.AddWithValue("@njtpcd", strNjtpcd);
            oCmd.Parameters.AddWithValue("@projno", strProjNo);
            oCmd.Parameters.AddWithValue("@costctr", strCostCtr);
            oCmd.Parameters.AddWithValue("@fginved", strfgInvcd);
            oCmd.Parameters.AddWithValue("@fginvself", strfgInvSelf);
            oCmd.Parameters.AddWithValue("@pno", strPNo);
            oCmd.Parameters.AddWithValue("@remark", strRemark);
            oCmd.Parameters.AddWithValue("@fgfixpg", strfgFixPg);
            oCmd.Parameters.AddWithValue("@moddate", strModDate);
            oCmd.Parameters.AddWithValue("@modempno", strModEmpNo);
            oCmd.Parameters.AddWithValue("@bkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@imseq", strImSeq);
            oCmd.Parameters.AddWithValue("@fgupdated", strfgUpdated);
            oCmd.Parameters.AddWithValue("@fgact", strfgAct);
            oCmd.Parameters.AddWithValue("@strpulpg", strpulpg);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void Updatec2_pub(string strSyscd, string strContNo, string strYYYYMM, string strPubSeq, int intPgNo, string strLtpcd, string strClrcd, string strPgscd, float floatAdAmt, float floatChgAmt, string strDrafttp,
            string strOrigbkcd, int intOrigjno, int intOrigbkno, string strChgbkcd, int intChgjno, int intChgbkno, string strfgReChg, string strfggot, string strNjtpcd, string strProjNo, string strCostCtr, string strBkpPno,
            string strRemark, string strfgfixpg, string strModDate, string strModEmpNo, string strBkcd, string strIMSeq,string strpulpg)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE dbo.c2_pub SET pub_pgno = @pgno, pub_ltpcd = @ltpcd, pub_clrcd = @clrcd, pub_pgscd = @pgscd, pub_adamt = @adamt, pub_chgamt = @chgamt, pub_drafttp = @drafttp, pub_origbkcd = @origbkcd, pub_origjno = @origjno, pub_origjbkno = @origjbkno, pub_chgbkcd = @chgbkcd, pub_chgjno = @chgjno, pub_chgjbkno = @chgjbkno, pub_fgrechg = @fgrechg, pub_fggot = @fggot, pub_njtpcd = @njtpcd, pub_projno = @projno, pub_costctr = @costctr, pub_pno = @pno, pub_remark = @remark, pub_fgfixpg = @fgfixpg, pub_moddate = @moddate, pub_modempno = @modempno, pub_bkcd = @bkcd, pub_imseq = @imseq, pub_pulpg= @strpulpg WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pgno", intPgNo);
            oCmd.Parameters.AddWithValue("@ltpcd", strLtpcd);
            oCmd.Parameters.AddWithValue("@clrcd", strClrcd);
            oCmd.Parameters.AddWithValue("@pgscd", strPgscd);
            oCmd.Parameters.AddWithValue("@adamt", floatAdAmt);
            oCmd.Parameters.AddWithValue("@chgamt", floatChgAmt);
            oCmd.Parameters.AddWithValue("@drafttp", strDrafttp);
            oCmd.Parameters.AddWithValue("@origbkcd", strOrigbkcd);
            oCmd.Parameters.AddWithValue("@origjno", intOrigjno);
            oCmd.Parameters.AddWithValue("@origjbkno", intOrigbkno);
            oCmd.Parameters.AddWithValue("@chgbkcd", strChgbkcd);
            oCmd.Parameters.AddWithValue("@chgjno", intChgjno);
            oCmd.Parameters.AddWithValue("@chgjbkno", intChgbkno);
            oCmd.Parameters.AddWithValue("@fgrechg", strfgReChg);
            oCmd.Parameters.AddWithValue("@fggot", strfggot);
            oCmd.Parameters.AddWithValue("@njtpcd", strNjtpcd);
            oCmd.Parameters.AddWithValue("@projno", strProjNo);
            oCmd.Parameters.AddWithValue("@costctr", strCostCtr);
            oCmd.Parameters.AddWithValue("@pno", strBkpPno);
            oCmd.Parameters.AddWithValue("@remark", strRemark);
            oCmd.Parameters.AddWithValue("@fgfixpg", strfgfixpg);
            oCmd.Parameters.AddWithValue("@moddate", strModDate);
            oCmd.Parameters.AddWithValue("@modempno", strModEmpNo);
            oCmd.Parameters.AddWithValue("@bkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@imseq", strIMSeq);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Parameters.AddWithValue("@yyyymm", strYYYYMM);
            oCmd.Parameters.AddWithValue("@pubseq", strPubSeq);
            oCmd.Parameters.AddWithValue("@strpulpg", strpulpg);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet Selectc2_pubForpubqno_get()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_yyyymm, c2_pub.pub_pubseq, c2_pub.pub_pno, c2_pub.pub_pgno, c2_cont.cont_mfrno, c2_cont.cont_custno, c2_cont.cont_contno, c2_cont.cont_syscd FROM c2_pub LEFT OUTER JOIN c2_cont ON c2_pub.pub_syscd = c2_cont.cont_syscd AND c2_pub.pub_contno = c2_cont.cont_contno WHERE (c2_pub.pub_syscd = 'C2') AND (c2_pub.pub_pgno <> '0') order by pub_pno DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}