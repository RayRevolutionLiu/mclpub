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
    public class syscd_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectsyscd()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * FROM syscd ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        //public DataSet OutPutMaxValue()
        //{
        //    SqlCommand oCmd = new SqlCommand();
        //    oCmd.Connection = new SqlConnection(Conn);
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(@"select count(*) as C1,max(itp_itpcd) as MaxCountNo from itp ");
        //    oCmd.CommandText = sb.ToString();
        //    oCmd.CommandType = CommandType.Text;
        //    SqlDataAdapter oda = new SqlDataAdapter(oCmd);
        //    DataSet ds = new DataSet();
        //    oda.Fill(ds);
        //    return ds;
        //}

        public void Delsyscd(string sys_sysid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from syscd where sys_sysid=@sys_sysid ";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@sys_sysid", sys_sysid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Insertsyscd(string sys_syscd, string sys_nm, string sys_deptcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into syscd(sys_syscd,sys_nm,sys_deptcd) values(@sys_syscd,@sys_nm,@sys_deptcd)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@sys_syscd", sys_syscd);
            oCmd.Parameters.AddWithValue("@sys_nm", sys_nm);
            oCmd.Parameters.AddWithValue("@sys_deptcd", sys_deptcd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Updatesyscd(string sys_syscd, string sys_nm, string sys_deptcd, string sys_sysid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update syscd set sys_syscd=@sys_syscd,sys_nm=@sys_nm,sys_deptcd=@sys_deptcd where sys_sysid=@sys_sysid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@sys_syscd", sys_syscd);
            oCmd.Parameters.AddWithValue("@sys_nm", sys_nm);
            oCmd.Parameters.AddWithValue("@sys_deptcd", sys_deptcd);
            oCmd.Parameters.AddWithValue("@sys_sysid", sys_sysid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}