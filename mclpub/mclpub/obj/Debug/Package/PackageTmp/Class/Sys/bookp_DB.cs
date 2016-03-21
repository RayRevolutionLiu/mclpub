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
    public class bookp_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectbookp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.bookp.*, dbo.book.bk_nm AS bk_nm FROM dbo.bookp INNER JOIN dbo.book ON dbo.bookp.bkp_bkcd = dbo.book.bk_bkcd ORDER BY CONVERT(int, bkp_pno) DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet ddlSelectAllBooks()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from book ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void Insertbook(string bkp_bkcd, string bkp_date, string bkp_pno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into bookp (bkp_bkcd,bkp_date, bkp_pno) values(@bkp_bkcd,@bkp_date,@bkp_pno)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkp_bkcd", bkp_bkcd);
            oCmd.Parameters.AddWithValue("@bkp_date", bkp_date);
            oCmd.Parameters.AddWithValue("@bkp_pno", bkp_pno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Delbook(string bkp_bkpid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"Delete From bookp where bkp_bkpid=@bkp_bkpid ";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkp_bkpid", bkp_bkpid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Updatebook(string bkp_bkpid, string bkp_bkcd, string bkp_date, string bkp_pno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE bookp SET bkp_bkcd=@bkp_bkcd,bkp_date=@bkp_date,bkp_pno=@bkp_pno WHERE bkp_bkpid=@bkp_bkpid ";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkp_bkpid", bkp_bkpid);
            oCmd.Parameters.AddWithValue("@bkp_bkcd", bkp_bkcd);
            oCmd.Parameters.AddWithValue("@bkp_date", bkp_date);
            oCmd.Parameters.AddWithValue("@bkp_pno", bkp_pno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}