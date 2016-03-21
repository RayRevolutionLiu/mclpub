using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class ContFm_chklist_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel");
            sb.Append(@", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp");
            sb.Append(@"n_empno FROM srspn WHERE (srspn_atype <> 'A') AND (srspn_atype <> 'F')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "srspn");
            return ds;

        }


        public DataSet SelectC2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm, c2_cont.cont_custno, cust.cust_nm, c2_cont.cont_signdate, c2_cont.cont_conttp, c2_cont.cont_bkcd");
            sb.Append(@", c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_empno, c2_cont.cont_fgpayonce, c2_cont.cont_fgclosed, c2_cont.cont_modempno, c2_cont.cont_fgcancel, c2_cont.cont_oldcontno");
            sb.Append(@", c2_cont.cont_credate, c2_cont.cont_moddate, c2_cont.cont_totjtm, c2_cont.cont_madejtm, c2_cont.cont_restjtm, c2_cont.cont_tottm, c2_cont.cont_pubtm");
            sb.Append(@", c2_cont.cont_resttm, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_cont.cont_chgjtm, c2_cont.cont_freetm, c2_cont.cont_adamt");
            sb.Append(@", c2_cont.cont_disc, c2_cont.cont_freebkcnt, c2_cont.cont_clrtm, c2_cont.cont_getclrtm, c2_cont.cont_menotm, c2_cont.cont_pubamt, c2_cont.cont_chgamt");
            sb.Append(@", c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_aufax, c2_cont.cont_aucell, c2_cont.cont_auemail, c2_cont.cont_remark, c2_cont.cont_fgtemp");
            sb.Append(@", c2_cont.cont_syscd, cust.cust_custno, mfr.mfr_mfrno, srspn.srspn_cname, srspn.srspn_empno, book.bk_nm, book.bk_bkcd FROM c2_cont INNER JOIN mfr ON ");
            sb.Append(@"c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno "); 
            sb.Append(@"INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "c2_cont");
            return ds;

        }


        public DataSet SelectInvmfr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, ");
            sb.Append(@"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM invmfr");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "invmfr");
            return ds;

        }


        public DataSet SelectC2_or()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel");
            sb.Append(@", or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea FROM c2_or");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "c2_or");
            return ds;

        }


        public DataSet SelectMtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpcd, mtp_nm FROM mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "mtp");
            return ds;

        }
    }
}
