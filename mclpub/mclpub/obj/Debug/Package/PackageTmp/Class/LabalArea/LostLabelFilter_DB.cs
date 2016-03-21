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
    public class LostLabelFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetContOrMfrCustFbkRamtLostWithFilter(string strFilter)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cont_syscd, cont_contno, cont_custno, cont_conttp, cont_sdate, cont_edate");
            sb.Append(@", cont_mfrno, or_oritem, or_nm, or_jbti, or_addr, or_tel, or_contno, or_syscd, or_fgmosea, cust_nm, mfr_inm, cust_custno, mfr_mfrno, fbk_fbkitem, fbk_bkcd");
            sb.Append(@", fbk_contno, fbk_syscd, ma_pubmnt, ma_unpubmnt, ma_fbkitem, ma_oritem, ma_contno, ma_syscd, CONVERT(CHAR(2), ma_pubmnt) + '/' + CONVERT(CHAR(2), ma_unpubmnt) AS fbkmnt");
            sb.Append(@", lst_seq, lst_cont, lst_date, lst_rea, lst_fgsent, lst_contno, lst_fbkitem, lst_oritem, lst_syscd , freecat.fc_nm FROM c4_cont INNER JOIN c4_or ON cont_syscd = or_syscd");
            sb.Append(@" AND cont_contno = or_contno LEFT OUTER JOIN cust ON cont_custno = cust.cust_custno LEFT OUTER JOIN mfr ON cont_mfrno = mfr_mfrno INNER JOIN c4_freebk ON cont_syscd = fbk_syscd");
            sb.Append(@" AND cont_contno = fbk_contno INNER JOIN c4_ramt ON cont_syscd = ma_syscd AND cont_contno = ma_contno AND fbk_fbkitem = ma_fbkitem AND or_oritem = ma_oritem INNER JOIN c4_lost");
            sb.Append(@" ON cont_syscd = lst_syscd AND cont_contno = lst_contno AND fbk_fbkitem = lst_fbkitem AND or_oritem = lst_oritem INNER JOIN freecat ON c4_freebk.fbk_bkcd = freecat.fc_fccd");
            if (strFilter.ToString().Trim() != "")
            {
                sb.Append(@" WHERE " + strFilter);
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public void ClearLostFgPrint()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c4_lost SET lst_fgprint=''";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UpdateLostDate(string lst_contno, string lst_fbkitem, string lst_oritem, string lst_seq, string lst_fgprint)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c4_lost SET lst_date=@lst_date, lst_fgprint=@lst_fgprint WHERE lst_syscd='C4' AND lst_contno=@lst_contno AND lst_fbkitem=@lst_fbkitem AND lst_oritem=@lst_oritem AND lst_seq=@lst_seq";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@lst_contno", lst_contno);
            oCmd.Parameters.AddWithValue("@lst_fbkitem", lst_fbkitem);
            oCmd.Parameters.AddWithValue("@lst_oritem", lst_oritem);
            oCmd.Parameters.AddWithValue("@lst_seq", lst_seq);
            oCmd.Parameters.AddWithValue("@lst_fgprint", lst_fgprint);
            oCmd.Parameters.AddWithValue("@lst_date", DateTime.Now.ToString("yyyyMMdd"));
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet GetLostLabel()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, cont_conttpName = CASE cont_conttp WHEN '01' THEN '一般' WHEN '09' THEN '推廣' ELSE '' END  FROM c4_lost INNER JOIN c4_or ON c4_lost.lst_syscd = c4_or.or_syscd AND  c4_lost.lst_contno = c4_or.or_contno AND  c4_lost.lst_oritem = c4_or.or_oritem INNER JOIN c4_ramt ON c4_or.or_syscd = c4_ramt.ma_syscd AND  c4_or.or_contno = c4_ramt.ma_contno AND  c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN mtp ON c4_ramt.ma_mtpcd = mtp.mtp_mtpcd  INNER JOIN c4_cont ON c4_lost.lst_syscd = c4_cont.cont_syscd AND c4_lost.lst_contno = c4_cont.cont_contno WHERE lst_fgprint = 'v'");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public void UpdateLostPrintOK(string lst_contno, string lst_fbkitem, string lst_oritem, string lst_seq, string lst_fgsent, string lst_fgprint)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c4_lost SET lst_date=@lst_date, lst_fgprint=@lst_fgprint WHERE lst_syscd='C4' AND lst_contno=@lst_contno AND lst_fbkitem=@lst_fbkitem AND lst_oritem=@lst_oritem AND lst_seq=@lst_seq";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@lst_contno", lst_contno);
            oCmd.Parameters.AddWithValue("@lst_fbkitem", lst_fbkitem);
            oCmd.Parameters.AddWithValue("@lst_oritem", lst_oritem);
            oCmd.Parameters.AddWithValue("@lst_seq", lst_seq);
            oCmd.Parameters.AddWithValue("@lst_fgprint", lst_fgprint);
            oCmd.Parameters.AddWithValue("@lst_date", DateTime.Now.ToString("yyyyMMdd"));
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}