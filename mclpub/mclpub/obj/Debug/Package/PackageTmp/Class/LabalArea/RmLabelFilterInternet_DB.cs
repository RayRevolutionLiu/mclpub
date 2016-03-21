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
    public class RmLabelFilterInternet_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetContRemailOrMfrCustWithFilter(string strFilter)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cont_syscd, cont_contno, cont_conttp, rm_oritem, rm_seq, rm_cont, rm_date, rm_fgsent, rm_contno, rm_syscd, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_fgmosea, or_contno, or_oritem, or_syscd, mfr_inm, mfr_mfrno, cust_nm, cust_custno FROM c4_cont INNER JOIN c4_remail ON cont_syscd = rm_syscd AND cont_contno = rm_contno INNER JOIN c4_or ON cont_syscd = or_syscd AND cont_contno = or_contno AND rm_oritem = or_oritem INNER JOIN mfr ON cont_mfrno = mfr_mfrno INNER JOIN cust ON cont_custno = cust_custno");
            if (strFilter.ToString().Trim() != "")
            {
                sb.Append(@" WHERE " + strFilter);
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void UpdateRemailPrintOK(string rm_contno, string rm_oritem, string rm_seq, string rm_fgsent, string rm_fgprint)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c4_remail SET rm_date=@rm_date, rm_fgsent=@rm_fgsent, rm_fgprint=@rm_fgprint WHERE rm_syscd='C4' AND rm_contno=@rm_contno AND rm_oritem=@rm_oritem AND rm_seq=@rm_seq";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_contno", rm_contno);
            oCmd.Parameters.AddWithValue("@rm_oritem", rm_oritem);
            oCmd.Parameters.AddWithValue("@rm_seq", rm_seq);
            oCmd.Parameters.AddWithValue("@rm_date", DateTime.Now.ToString("yyyyMMdd"));
            oCmd.Parameters.AddWithValue("@rm_fgsent", rm_fgsent);
            oCmd.Parameters.AddWithValue("@rm_fgprint", rm_fgprint);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void ClearRemailFgPrint()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c4_remail SET rm_fgprint=''";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UpdateRemailDate(string rm_contno, string rm_oritem, string rm_seq, string rm_fgprint)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c4_remail SET rm_date=@rm_date, rm_fgprint=@rm_fgprint WHERE rm_syscd='C4' AND rm_contno=@rm_contno AND rm_oritem=@rm_oritem AND rm_seq=@rm_seq";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_contno", rm_contno);
            oCmd.Parameters.AddWithValue("@rm_oritem", rm_oritem);
            oCmd.Parameters.AddWithValue("@rm_seq", rm_seq);
            oCmd.Parameters.AddWithValue("@rm_date", DateTime.Now.ToString("yyyyMMdd"));
            oCmd.Parameters.AddWithValue("@rm_fgprint", rm_fgprint);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet GetRemailLabel()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, cont_conttpName = CASE cont_conttp WHEN '01' THEN '一般' WHEN '09' THEN '推廣' ELSE '' END  FROM c4_remail INNER JOIN c4_or ON c4_remail.rm_syscd = c4_or.or_syscd AND  c4_remail.rm_contno = c4_or.or_contno AND  c4_remail.rm_oritem = c4_or.or_oritem INNER JOIN c4_ramt ON c4_or.or_syscd = c4_ramt.ma_syscd AND  c4_or.or_contno = c4_ramt.ma_contno AND  c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN mtp ON c4_ramt.ma_mtpcd = mtp.mtp_mtpcd  INNER JOIN c4_cont ON c4_remail.rm_syscd = c4_cont.cont_syscd AND c4_remail.rm_contno = c4_cont.cont_contno WHERE rm_fgprint = 'v'");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}