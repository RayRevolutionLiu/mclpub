using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace mclpub
{
    public class adpgsize_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_pgsize()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from c2_pgsize");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@lp_bkcd", lp_bkcd);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            //oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            //oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectc2_pub(string pgscd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_pgsize.pgs_pgscd, dbo.c2_pgsize.pgs_nm FROM dbo.c2_pgsize INNER JOIN dbo.c2_pub ON dbo.c2_pgsize.pgs_pgscd = dbo.c2_pub.pub_pgscd WHERE (dbo.c2_pgsize.pgs_pgscd = @pgscd) GROUP BY dbo.c2_pgsize.pgs_pgscd, dbo.c2_pgsize.pgs_nm");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pgscd", pgscd);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            //oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            //oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void Delc2_pgsize(string pgs_pgsid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from c2_pgsize where pgs_pgsid=@pgs_pgsid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pgs_pgsid", pgs_pgsid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void UPDATEc2_pgsize(string pgs_pgscd, string pgs_nm, string pgs_pgsid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update c2_pgsize set pgs_pgscd=@pgs_pgscd,pgs_nm=@pgs_nm where pgs_pgsid=@pgs_pgsid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pgs_pgscd", pgs_pgscd);
            oCmd.Parameters.AddWithValue("@pgs_nm", pgs_nm);
            oCmd.Parameters.AddWithValue("@pgs_pgsid", pgs_pgsid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet SelectCountc2_pgsize()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select count(*) as CountNo,max(pgs_pgscd) as MaxCountNo from c2_pgsize");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public void INSERTc2_pgsize(string pgs_pgscd, string pgs_nm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into c2_pgsize(pgs_pgscd,pgs_nm) values(@pgs_pgscd,@pgs_nm)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pgs_pgscd", pgs_pgscd);
            oCmd.Parameters.AddWithValue("@pgs_nm", pgs_nm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}