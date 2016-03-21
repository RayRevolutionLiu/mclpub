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
    public class refm_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectrefm()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.refm.*, dbo.syscd.sys_nm AS sys_nm FROM dbo.refm INNER JOIN dbo.syscd ON dbo.refm.rm_syscd = dbo.syscd.sys_syscd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void Deleterefm(string rm_rmid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from refm where rm_rmid=@rm_rmid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_rmid", rm_rmid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
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

        public void UpDaterefm(string rm_rmid, string rm_syscd, string rm_remark, string rm_deptcd, string rm_accddr, string rm_idescr, string rm_iunit, string rm_iremark)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update refm set rm_syscd=@rm_syscd,rm_remark=@rm_remark,rm_deptcd=@rm_deptcd,rm_accddr=@rm_accddr,rm_idescr=@rm_idescr,rm_iunit=@rm_iunit,rm_iremark=@rm_iremark where rm_rmid=@rm_rmid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_rmid", rm_rmid);
            oCmd.Parameters.AddWithValue("@rm_syscd", rm_syscd);
            oCmd.Parameters.AddWithValue("@rm_remark", rm_remark);
            oCmd.Parameters.AddWithValue("@rm_deptcd", rm_deptcd);
            oCmd.Parameters.AddWithValue("@rm_accddr", rm_accddr);
            oCmd.Parameters.AddWithValue("@rm_idescr", rm_idescr);
            oCmd.Parameters.AddWithValue("@rm_iunit", rm_iunit);
            oCmd.Parameters.AddWithValue("@rm_iremark", rm_iremark);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void INSERTrefm(string rm_syscd, string rm_remark, string rm_deptcd, string rm_accddr, string rm_idescr, string rm_iunit, string rm_iremark)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into refm(rm_syscd,rm_remark,rm_deptcd,rm_accddr,rm_idescr,rm_iunit,rm_iremark) values(@rm_syscd,@rm_remark,@rm_deptcd,@rm_accddr,@rm_idescr,@rm_iunit,@rm_iremark)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_syscd", rm_syscd);
            oCmd.Parameters.AddWithValue("@rm_remark", rm_remark);
            oCmd.Parameters.AddWithValue("@rm_deptcd", rm_deptcd);
            oCmd.Parameters.AddWithValue("@rm_accddr", rm_accddr);
            oCmd.Parameters.AddWithValue("@rm_idescr", rm_idescr);
            oCmd.Parameters.AddWithValue("@rm_iunit", rm_iunit);
            oCmd.Parameters.AddWithValue("@rm_iremark", rm_iremark);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet SelectREFM_syscd(string rm_syscd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from refm WHERE rm_syscd=@rm_syscd ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_syscd", rm_syscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}