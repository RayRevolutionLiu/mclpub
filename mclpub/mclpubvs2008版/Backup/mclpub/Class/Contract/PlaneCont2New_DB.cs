using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class PlaneCont2New_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public void DelBlankContData()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"DELETE FROM c2_cont WHERE (cont_conttp = '') AND (cont_bkcd = '')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void DelInvmfr(string strSyscd, string strCurrentContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"DELETE FROM invmfr WHERE (im_syscd = @syscd) AND (im_contno = @contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strCurrentContNo);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void DelC2_or(string strSyscd, string strCurrentContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"DELETE FROM c2_or WHERE (or_syscd = @syscd) AND (or_contno = @contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strCurrentContNo);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void DelC2_cont(string strSyscd, string strCurrentContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"DELETE FROM c2_cont WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strCurrentContNo);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public DataSet SelectCust()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.cust.cust_custid, dbo.cust.cust_custno, RTRIM(dbo.cust.cust_nm) AS cust_nm, RTRIM(dbo.cust.cust_mfrno) AS cust_mfrno, dbo.cust.cust_jbti, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.mfr.mfr_mfrid,");
            sb.Append(@" RTRIM(dbo.mfr.mfr_mfrno) AS mfr_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.mfr.mfr_respnm) AS mfr_respnm, dbo.mfr.mfr_respjbti, dbo.mfr.mfr_tel, RTRIM(dbo.mfr.mfr_fax) AS mfr_fax,");
            sb.Append(@" RTRIM(dbo.mfr.mfr_iaddr) AS mfr_iaddr, dbo.mfr.mfr_izip, dbo.mfr.mfr_regdate, dbo.cust.cust_cell, dbo.cust.cust_email, RTRIM(dbo.cust.cust_oldcustno) AS cust_oldcustno");
            sb.Append(@", RTRIM(dbo.cust.cust_orgisyscd) AS cust_orgisyscd, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.mfr.mfr_mfrno AS Expr1 ");
            sb.Append(@"FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "cust");
            return ds;

        }


        public DataSet SelectBooks()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = '')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "book");
            return ds;

        }


        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel");
            sb.Append(@", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp");
            sb.Append(@"n_empno FROM dbo.srspn WHERE (srspn_atype <> 'A') AND (srspn_atype <> 'E') AND (srspn_atype <> 'F')");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "srspn");
            return ds;

        }


        public DataSet SelectMaxC2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(*) AS TotalCount, MAX(cont_contno) AS MaxContNo FROM dbo.c2_cont");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "c2_cont");
            return ds;

        }


        public void InsertC2_cont(string strSyscd, string strCurrentContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO c2_cont (cont_syscd, cont_contno, cont_fgtemp) VALUES (@syscd, @contno, '1')");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strCurrentContNo);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public DataSet SelectInvmfr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, ");
            sb.Append(@"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM dbo.invmfr");
            sb.Append(@" WHERE (im_syscd = 'C2')");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "invmfr");
            return ds;

        }


        public DataSet SelectC2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm");
            sb.Append(@", cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt");
            sb.Append(@", cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_modempno, cont_fgcancel");
            sb.Append(@", cont_credate, cont_adamt, cont_freebkcnt, cont_remark, cont_fgtemp, cont_fgpubed, cont_restclrtm, cont_restmenotm, cont_restgetclrtm FROM dbo.c2_cont");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "c2_cont");
            return ds;

        }


        public DataSet SelectC2_or()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel");
            sb.Append(@", or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea FROM dbo.c2_or");
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
            sb.Append(@"SELECT mtp_mtpcd, mtp_nm FROM dbo.mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "mtp");
            return ds;

        }


        public void UpdateC2_cont(string strMfrNo, string strCustNo, string strSyscd, string strContNo, string strContType, string strBkcd, string strSignDate, string strEmpNo, string strStartDate,
            string strEndDate, string strfgClosed, string strOldContNo, string strModifyDate, string strfgPayOnce, string strModifyEmpNo, string strfgCancel, string strCreateDate, string strTotalJTime,
            string strMadeJTime, string strRestJTime, string strDiscount, string strFreeTime, string strTotalTime, string strPubTime, string strRestTime, string strChangeJTime, string strTotalAmount,
            string strPubAdAmount, string strPubChangeAmount, string strPaidAmount, string strRestAmount, string strColorTime, string strMenoTime, string strGetColorTime, string strADAmount, string strFreeBookCount
            , string strRestColorTime, string strRestGetColorTime, string strRestMenoTime, string strAUName, string strAUTel, string strAUFax, string strAUCell, string strAUEmail, string strRemark)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c2_cont SET cont_conttp = @conttp, cont_bkcd = @bkcd, cont_signdate = @signdate, cont_empno = @empno, cont_mfrno = @mfrno, cont_aunm = @aunm");
            sb.Append(@", cont_autel = @autel, cont_aufax = @aufax, cont_aucell = @aucell, cont_auemail = @auemail, cont_sdate = @sdate, cont_edate = @edate, cont_totjtm = @totjtm");
            sb.Append(@", cont_madejtm = @madejtm, cont_restjtm = @restjtm, cont_disc = @disc, cont_freetm = @freetm, cont_fgclosed = @fgclosed, cont_tottm = @tottm, cont_pubtm = @pubtm, cont_resttm = @resttm");
            sb.Append(@", cont_chgjtm = @chgjtm, cont_custno = @custno, cont_totamt = @totamt, cont_pubamt = @pubamt, cont_chgamt = @chgamt, cont_paidamt = @paidamt, cont_restamt = @restamt");
            sb.Append(@", cont_clrtm = @clrtm, cont_menotm = @menotm, cont_getclrtm = @getclrtm, cont_oldcontno = @oldcontno, cont_moddate = @moddate, cont_fgpayonce = @fgpayonce");
            sb.Append(@", cont_modempno = @modempno, cont_fgcancel = @fgcancel, cont_credate = @credate, cont_adamt = @adamt, cont_freebkcnt = @freebkcnt, cont_remark = @remark");
            sb.Append(@", cont_fgtemp = '0', cont_fgpubed = '0', cont_restclrtm = @restclrtm, cont_restmenotm = @restmenotm, cont_restgetclrtm = @restgetclrtm, cont_njtpcnt = 0 ");
            sb.Append(@"WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfrno", strMfrNo);
            oCmd.Parameters.AddWithValue("@custno", strCustNo);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Parameters.AddWithValue("@conttp", strContType);
            oCmd.Parameters.AddWithValue("@bkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@signdate", strSignDate);
            oCmd.Parameters.AddWithValue("@empno", strEmpNo);
            oCmd.Parameters.AddWithValue("@sdate", strStartDate);
            oCmd.Parameters.AddWithValue("@edate", strEndDate);
            oCmd.Parameters.AddWithValue("@fgclosed", strfgClosed);
            oCmd.Parameters.AddWithValue("@oldcontno", strOldContNo);
            oCmd.Parameters.AddWithValue("@moddate", strModifyDate);
            oCmd.Parameters.AddWithValue("@fgpayonce", strfgPayOnce);
            oCmd.Parameters.AddWithValue("@modempno", strModifyEmpNo);
            oCmd.Parameters.AddWithValue("@fgcancel", strfgCancel);
            oCmd.Parameters.AddWithValue("@credate", strCreateDate);
            oCmd.Parameters.AddWithValue("@totjtm", strTotalJTime);
            oCmd.Parameters.AddWithValue("@madejtm", strMadeJTime);
            oCmd.Parameters.AddWithValue("@restjtm", strRestJTime);
            oCmd.Parameters.AddWithValue("@disc", strDiscount);
            oCmd.Parameters.AddWithValue("@freetm", strFreeTime);
            oCmd.Parameters.AddWithValue("@tottm", strTotalTime);
            oCmd.Parameters.AddWithValue("@pubtm", strPubTime);
            oCmd.Parameters.AddWithValue("@resttm", strRestTime);
            oCmd.Parameters.AddWithValue("@chgjtm", strChangeJTime);
            oCmd.Parameters.AddWithValue("@totamt", strTotalAmount);
            oCmd.Parameters.AddWithValue("@pubamt", strPubAdAmount);
            oCmd.Parameters.AddWithValue("@chgamt", strPubChangeAmount);
            oCmd.Parameters.AddWithValue("@paidamt", strPaidAmount);
            oCmd.Parameters.AddWithValue("@restamt", strRestAmount);
            oCmd.Parameters.AddWithValue("@clrtm", strColorTime);
            oCmd.Parameters.AddWithValue("@menotm", strMenoTime);
            oCmd.Parameters.AddWithValue("@getclrtm", strGetColorTime);
            oCmd.Parameters.AddWithValue("@adamt", strADAmount);
            oCmd.Parameters.AddWithValue("@freebkcnt", strFreeBookCount);
            oCmd.Parameters.AddWithValue("@restclrtm", strRestColorTime);
            oCmd.Parameters.AddWithValue("@restmenotm", strRestGetColorTime);
            oCmd.Parameters.AddWithValue("@restgetclrtm", strRestMenoTime);
            oCmd.Parameters.AddWithValue("@aunm", strAUName);
            oCmd.Parameters.AddWithValue("@autel", strAUTel);
            oCmd.Parameters.AddWithValue("@aufax", strAUFax);
            oCmd.Parameters.AddWithValue("@aucell", strAUCell);
            oCmd.Parameters.AddWithValue("@auemail", strAUEmail);
            oCmd.Parameters.AddWithValue("@remark", strRemark);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}
