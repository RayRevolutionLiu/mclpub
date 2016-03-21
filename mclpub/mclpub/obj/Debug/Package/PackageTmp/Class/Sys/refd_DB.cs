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
    public class refd_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectrefd()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.refd.*, dbo.syscd.sys_nm AS sys_nm FROM dbo.refd INNER JOIN dbo.syscd ON dbo.refd.rd_syscd = dbo.syscd.sys_syscd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectsyscd()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from syscd ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectproj()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from proj ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Deleterefd(string rd_rdid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from refd where rd_rdid=@rd_rdid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rd_rdid", rd_rdid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet SelectPkeyDouble(string rd_syscd, string rd_projno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from refd WHERE rd_syscd=@rd_syscd AND rd_projno=@rd_projno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rd_syscd", rd_syscd);
            oCmd.Parameters.AddWithValue("@rd_projno", rd_projno);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void UpDaterefd(string rd_syscd, string rd_projno, string rd_costctr, string rd_accdcr, string rd_descr, string rd_rdid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update refd set rd_syscd=@rd_syscd,rd_projno=@rd_projno,rd_costctr=@rd_costctr,rd_accdcr=@rd_accdcr,rd_descr=@rd_descr where rd_rdid=@rd_rdid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rd_syscd", rd_syscd);
            oCmd.Parameters.AddWithValue("@rd_projno", rd_projno);
            oCmd.Parameters.AddWithValue("@rd_costctr", rd_costctr);
            oCmd.Parameters.AddWithValue("@rd_accdcr", rd_accdcr);
            oCmd.Parameters.AddWithValue("@rd_descr", rd_descr);
            oCmd.Parameters.AddWithValue("@rd_rdid", rd_rdid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void INSERTrefd(string rd_syscd, string rd_projno, string rd_costctr, string rd_accdcr, string rd_descr)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into refd(rd_syscd,rd_projno,rd_costctr,rd_accdcr,rd_descr) values(@rd_syscd,@rd_projno,@rd_costctr,@rd_accdcr,@rd_descr)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rd_syscd", rd_syscd);
            oCmd.Parameters.AddWithValue("@rd_projno", rd_projno);
            oCmd.Parameters.AddWithValue("@rd_costctr", rd_costctr);
            oCmd.Parameters.AddWithValue("@rd_accdcr", rd_accdcr);
            oCmd.Parameters.AddWithValue("@rd_descr", rd_descr);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}