using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class PlaneCont_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelecChkBtn(string mfr_inm, string cust_mfrno, string cust_custno, string cust_nm,string level)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti");
            sb.Append(@", cust.cust_mfrno, cust.cust_tel, cust.cust_fax, cust.cust_cell, cust.cust_regdate, cust.cust_moddate");
            sb.Append(@", cust.cust_itpcd, cust.cust_btpcd, cust.cust_rtpcd, cust.cust_email, cust.cust_oldcustno, cust.cust_orgisyscd,cust_srspn_empno ");
            sb.Append(@" FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno WHERE 1=1 ");
            if (mfr_inm.ToString() != "")
            {
                sb.Append(@"and mfr_inm Like '%'+@mfr_inm+'%' ");
            }
            if (cust_mfrno.ToString() != "")
            {
                sb.Append(@"and cust_mfrno Like '%'+@cust_mfrno+'%' ");
            }
            if (cust_custno.ToString() != "")
            {
                sb.Append(@"and cust_custno=@cust_custno ");
            }
            if (cust_nm.ToString() != "")
            {
                sb.Append(@"and cust_nm Like '%'+@cust_nm+'%' ");
            }
            if (level.ToString() == "D")
            {
                sb.Append(@"and (cust_srspn_empno = @level or cust_mfrno in (@FindMfrByEmpno))");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            oCmd.Parameters.AddWithValue("@cust_mfrno", cust_mfrno);
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oCmd.Parameters.AddWithValue("@cust_nm", cust_nm);
            oCmd.Parameters.AddWithValue("@level", level);
            oCmd.Parameters.AddWithValue("@FindMfrByEmpno", FindMfrByEmpno(level));
            oda.Fill(ds);
            return ds;

        }
        //上面需要使用的function
        private string FindMfrByEmpno(string empno)
        {
            SqlConnection connection = new SqlConnection(Conn);
            connection.Open();
            string sql = "select cont_mfrno from c2_cont where cont_empno = '" + empno + "' group by cont_mfrno";
            SqlCommand com = new SqlCommand(sql, connection);
            SqlDataReader dr = com.ExecuteReader();
            string mfrnos = "";
            while (dr.Read())
                mfrnos += "'" + dr[0] + "',";

            dr.Close();
            connection.Close();
            if (mfrnos.Length > 0)
                return mfrnos.Substring(0, mfrnos.Length - 1);
            else
                return "''";
        }


        public DataTable Checkmfrno(string mfr_mfrno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from mfr where 1=1 and mfr_mfrno=@mfr_mfrno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }
    }

}
