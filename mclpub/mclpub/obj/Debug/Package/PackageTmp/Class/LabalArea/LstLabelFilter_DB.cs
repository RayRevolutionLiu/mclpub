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
    public class LstLabelFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_lost()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_lost.lst_lstid, dbo.c1_lost.lst_syscd, dbo.c1_lost.lst_custno, dbo.c1_lost.lst_otp1cd, dbo.c1_lost.lst_otp1seq, dbo.c1_lost.lst_oritem, dbo.c1_lost.lst_seq, dbo.c1_lost.lst_cont, dbo.c1_lost.lst_date, dbo.c1_lost.lst_rea, dbo.c1_lost.lst_fgsent, dbo.c1_or.or_nm, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.c1_or.or_fgmosea, dbo.c1_lost.lst_syscd + dbo.c1_lost.lst_custno + dbo.c1_lost.lst_otp1cd + dbo.c1_lost.lst_otp1seq + dbo.c1_lost.lst_oritem AS nostr FROM dbo.c1_lost INNER JOIN dbo.c1_or ON dbo.c1_lost.lst_syscd = dbo.c1_or.or_syscd AND dbo.c1_lost.lst_custno = dbo.c1_or.or_custno AND dbo.c1_lost.lst_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_lost.lst_oritem = dbo.c1_or.or_oritem");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_lost");
            return ds;

        }

        public void DelTmp_table2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM dbo.tmp_label2";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@Istr0", Istr0);
            //oCmd.Parameters.AddWithValue("@Istr1", Istr1);
            //oCmd.Parameters.AddWithValue("@Istr2", Istr2);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Update2(string lst_syscd, string lst_custno, string lst_otp1cd, string lst_otp1seq, string lst_oritem, string lst_seq, string lst_date, string lst_fgsent, string Original_lst_custno, string Original_lst_oritem, string Original_lst_otp1cd, string Original_lst_otp1seq, string Original_lst_syscd, string Original_lst_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE dbo.c1_lost SET lst_syscd = @lst_syscd, lst_custno = @lst_custno, lst_otp1cd = @lst_otp1cd, lst_otp1seq = @lst_otp1seq, lst_oritem = @lst_oritem, lst_seq = @lst_seq, lst_date = @lst_date, lst_fgsent = @lst_fgsent WHERE (lst_custno = @Original_lst_custno) AND (lst_oritem = @Original_lst_oritem) AND (lst_otp1cd = @Original_lst_otp1cd) AND (lst_otp1seq = @Original_lst_otp1seq) AND (lst_syscd = @Original_lst_syscd) AND (lst_seq = @Original_lst_seq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@lst_syscd", lst_syscd);
            oCmd.Parameters.AddWithValue("@lst_custno", lst_custno);
            oCmd.Parameters.AddWithValue("@lst_otp1cd", lst_otp1cd);
            oCmd.Parameters.AddWithValue("@lst_otp1seq", lst_otp1seq);
            oCmd.Parameters.AddWithValue("@lst_oritem", lst_oritem);
            oCmd.Parameters.AddWithValue("@lst_seq", lst_seq);
            oCmd.Parameters.AddWithValue("@lst_date", lst_date);
            oCmd.Parameters.AddWithValue("@lst_fgsent", lst_fgsent);
            oCmd.Parameters.AddWithValue("@Original_lst_custno", Original_lst_custno);
            oCmd.Parameters.AddWithValue("@Original_lst_oritem", Original_lst_oritem);
            oCmd.Parameters.AddWithValue("@Original_lst_otp1cd", Original_lst_otp1cd);
            oCmd.Parameters.AddWithValue("@Original_lst_otp1seq", Original_lst_otp1seq);
            oCmd.Parameters.AddWithValue("@Original_lst_syscd", Original_lst_syscd);
            oCmd.Parameters.AddWithValue("@Original_lst_seq", Original_lst_seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Insert1(string tmp_syscd, string tmp_custno, string tmp_otp1cd, string tmp_otp1seq, string tmp_oritem, string tmp_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"INSERT INTO dbo.tmp_label2(tmp_syscd, tmp_custno, tmp_otp1cd, tmp_otp1seq, tmp_oritem, tmp_seq) VALUES (@tmp_syscd, @tmp_custno, @tmp_otp1cd, @tmp_otp1seq, @tmp_oritem, @tmp_seq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@tmp_syscd", tmp_syscd);
            oCmd.Parameters.AddWithValue("@tmp_custno", tmp_custno);
            oCmd.Parameters.AddWithValue("@tmp_otp1cd", tmp_otp1cd);
            oCmd.Parameters.AddWithValue("@tmp_otp1seq", tmp_otp1seq);
            oCmd.Parameters.AddWithValue("@tmp_oritem", tmp_oritem);
            oCmd.Parameters.AddWithValue("@tmp_seq", tmp_seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}