using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class Company_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable SelectCompanyTable(string TicketName, string TicketNum, string TicketAddr, string CompTel, string pwerRowData, string cust_srspn_empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            if (pwerRowData.ToString() == "D")
            {
                sb.Append(@"select mfr.* from mfr,cust where cust_srspn_empno=@cust_srspn_empno ");
                sb.Append(@"and mfr_mfrno = cust_mfrno ");
            }
            else
            {
                sb.Append(@"select * from mfr where 1=1 ");
            }

            if (TicketName.ToString() != "")
            {
                sb.Append(@"and UPPER(mfr_inm) like '%'+@TicketName+'%' ");
            }
            if (TicketNum.ToString() != "")
            {
                sb.Append(@"and mfr_mfrno like '%'+@TicketNum+'%' ");
            }
            if (TicketAddr.ToString() != "")
            {
                sb.Append(@"and mfr_iaddr like '%'+@TicketAddr+'%' ");
            }
            if (CompTel.ToString() != "")
            {
                sb.Append(@"and mfr_tel like '%'+@CompTel+'%' ");
            }

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@TicketName", TicketName.ToUpper());
            oCmd.Parameters.AddWithValue("@TicketNum", TicketNum);
            oCmd.Parameters.AddWithValue("@TicketAddr", TicketAddr);
            oCmd.Parameters.AddWithValue("@CompTel", CompTel);
            oCmd.Parameters.AddWithValue("@cust_srspn_empno", cust_srspn_empno);
            oda.Fill(ds);
            return ds;

        }


        public void DelComp(string id)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"delete from mfr where mfr_mfrid=@mfr_mfrid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfr_mfrid", id);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}
