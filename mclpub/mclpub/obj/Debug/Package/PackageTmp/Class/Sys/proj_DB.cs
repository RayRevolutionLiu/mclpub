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
    public class proj_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectTitle(string STRtbxQString, string STRddlQueryField)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, dbo.proj.*, dbo.book.bk_nm AS bk_nm, dbo.syscd.sys_nm AS sys_nm, fgitri.fgitri_name AS fgitri_nm FROM dbo.proj INNER JOIN dbo.syscd ON dbo.proj.proj_syscd = dbo.syscd.sys_syscd INNER JOIN fgitri ON dbo.proj.proj_fgitri = fgitri.fgitri_fgitri LEFT OUTER JOIN dbo.book ON dbo.proj.proj_bkcd = dbo.book.bk_bkcd WHERE 1=1 ");
            if (STRtbxQString.ToString().Trim() != "")
            {
                sb.Append(@" AND " + STRddlQueryField + " LIKE '%'+@STRtbxQString+'%' ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@STRtbxQString", STRtbxQString);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Deleteproj(string proj_projid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from proj where proj_projid=@proj_projid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@proj_projid", proj_projid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Insertproj(string proj_syscd, string proj_bkcd, string proj_fgitri, string proj_projno, string proj_costctr, string proj_cont)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into proj(proj_syscd,proj_bkcd,proj_fgitri,proj_projno,proj_costctr,proj_cont) values(@proj_syscd,@proj_bkcd,@proj_fgitri,@proj_projno,@proj_costctr,@proj_cont)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@proj_syscd", proj_syscd);
            oCmd.Parameters.AddWithValue("@proj_bkcd", proj_bkcd);
            oCmd.Parameters.AddWithValue("@proj_fgitri", proj_fgitri);
            oCmd.Parameters.AddWithValue("@proj_projno", proj_projno);
            oCmd.Parameters.AddWithValue("@proj_costctr", proj_costctr);
            oCmd.Parameters.AddWithValue("@proj_cont", proj_cont);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Updateproj(string proj_syscd, string proj_bkcd, string proj_fgitri, string proj_projno, string proj_costctr, string proj_cont, string proj_projid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"update proj set proj_syscd=@proj_syscd,proj_bkcd=@proj_bkcd,proj_fgitri=@proj_fgitri");
            sb.Append(@",proj_projno=@proj_projno,proj_costctr=@proj_costctr,proj_cont=@proj_cont where proj_projid=@proj_projid ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@proj_syscd", proj_syscd);
            oCmd.Parameters.AddWithValue("@proj_bkcd", proj_bkcd);
            oCmd.Parameters.AddWithValue("@proj_fgitri", proj_fgitri);
            oCmd.Parameters.AddWithValue("@proj_projno", proj_projno);
            oCmd.Parameters.AddWithValue("@proj_costctr", proj_costctr);
            oCmd.Parameters.AddWithValue("@proj_cont", proj_cont);
            oCmd.Parameters.AddWithValue("@proj_projid", proj_projid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public DataTable Selectsyscd()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from syscd ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;
        }

        public DataTable Selectbook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from book ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;
        }

        public DataTable Selectfgitri()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from fgitri ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;
        }

        public DataTable Selectproj()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from proj ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;
        }
    }
}