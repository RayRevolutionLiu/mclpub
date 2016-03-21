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
    public class srspn_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectsrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.srspn.*,LTRIM(RTRIM(srspn_deptcd)) as srspn_deptcd, orgcod.org_abbr_chnm1 AS OrgAbbName FROM dbo.srspn INNER JOIN common..orgcod ON dbo.srspn.srspn_orgcd COLLATE Chinese_Taiwan_Stroke_BIN = orgcod.org_orgcd order by srspn_atype");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Delsrspn(string srspn_id)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from srspn where srspn_id=@srspn_id ";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@srspn_id", srspn_id);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void Updatesrspn(string srspn_empno, string srspn_cname, string srspn_tel, string srspn_atype, string srspn_orgcd, string srspn_deptcd,
            string srspn_date, string srspn_id)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"update srspn set srspn_empno=@srspn_empno,srspn_cname=@srspn_cname,srspn_tel=@srspn_tel,srspn_atype=@srspn_atype,");
            sb.Append(@"srspn_orgcd=@srspn_orgcd,srspn_deptcd=@srspn_deptcd,srspn_date=@srspn_date where srspn_id=@srspn_id ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@srspn_empno", srspn_empno);
            oCmd.Parameters.AddWithValue("@srspn_cname", srspn_cname);
            oCmd.Parameters.AddWithValue("@srspn_tel", srspn_tel);
            oCmd.Parameters.AddWithValue("@srspn_atype", srspn_atype);
            oCmd.Parameters.AddWithValue("@srspn_orgcd", srspn_orgcd);
            oCmd.Parameters.AddWithValue("@srspn_deptcd", srspn_deptcd);
            oCmd.Parameters.AddWithValue("@srspn_date", srspn_date);
            oCmd.Parameters.AddWithValue("@srspn_id", srspn_id);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public DataSet SelectOrgCod()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT org_orgcd,org_abbr_chnm1 FROM common..orgcod WHERE org_status='A'");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Insertsrspn(string srspn_empno, string srspn_cname, string srspn_tel, string srspn_atype, string srspn_orgcd, string srspn_deptcd, string srspn_date)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into srspn(srspn_empno,srspn_cname,srspn_tel,srspn_atype,srspn_orgcd,srspn_deptcd,srspn_date) values(@srspn_empno,@srspn_cname,@srspn_tel,@srspn_atype,@srspn_orgcd,@srspn_deptcd,@srspn_date)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@srspn_empno", srspn_empno);
            oCmd.Parameters.AddWithValue("@srspn_cname", srspn_cname);
            oCmd.Parameters.AddWithValue("@srspn_tel", srspn_tel);
            oCmd.Parameters.AddWithValue("@srspn_atype", srspn_atype);
            oCmd.Parameters.AddWithValue("@srspn_orgcd", srspn_orgcd);
            oCmd.Parameters.AddWithValue("@srspn_deptcd", srspn_deptcd);
            oCmd.Parameters.AddWithValue("@srspn_date", srspn_date);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public DataTable SelectSrspn_atype()//權限別沒有資料庫 在這裡湊出DataSet再丟出去
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("value", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("name", Type.GetType("System.String"));

            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr = dt.NewRow();
            dr["value"] = "A";
            dr["name"] = "A - 應用程式開發者";
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["value"] = "B";
            dr1["name"] = "B - 主要業務負責人";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["value"] = "C";
            dr2["name"] = "C - 次要業務負責人";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["value"] = "D";
            dr3["name"] = "D - 院外業務人員";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["value"] = "E";
            dr4["name"] = "E - 訂戶人員";
            dt.Rows.Add(dr4);

            DataRow dr6 = dt.NewRow();
            dr6["value"] = "F";
            dr6["name"] = "F - 會計人員";
            dt.Rows.Add(dr6);

            return dt;

        }
    }
}