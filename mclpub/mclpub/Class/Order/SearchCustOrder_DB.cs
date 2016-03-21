using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;


namespace mclpub
{
    public class SearchCustOrder_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelectBtn(string STRtbxCompanyname, string STRtbxMfrno, string STRtbxCustNo, string STRtbxCustName)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_cust.cust_custid, dbo.c1_cust.cust_custno, dbo.c1_cust.cust_nm, dbo.c1_cust.cust_jbti, dbo.c1_cust.cust_mfrno, dbo.c1_cust.cust_tel");
            sb.Append(@", dbo.c1_cust.cust_regdate, dbo.c1_cust.cust_moddate");
            sb.Append(@", dbo.c1_cust.cust_itpcd, dbo.mfr.mfr_inm AS mfrnm, dbo.mfr.mfr_mfrid,");
            sb.Append(@" dbo.mfr.mfr_mfrno FROM dbo.c1_cust INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno WHERE 1=1 ");
            if (STRtbxCompanyname.ToString() != "")
            {
                sb.Append(@" AND mfr_inm LIKE '%'+@STRtbxCompanyname+'%' ");
            }
            if (STRtbxMfrno.ToString() != "")
            {
                sb.Append(@" AND UPPER(cust_mfrno) LIKE '%'+@STRtbxMfrno+'%' ");
            }
            if (STRtbxCustNo.ToString() != "")
            {
                sb.Append(@" AND cust_custno=@STRtbxCustNo ");
            }
            if (STRtbxCustName.ToString() != "")
            {
                sb.Append(@" AND cust_nm LIKE '%'+@STRtbxCustName+'%'  ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@STRtbxCompanyname", STRtbxCompanyname);
            oCmd.Parameters.AddWithValue("@STRtbxMfrno", STRtbxMfrno.ToUpper());
            oCmd.Parameters.AddWithValue("@STRtbxCustNo", STRtbxCustNo);
            oCmd.Parameters.AddWithValue("@STRtbxCustName", STRtbxCustName);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public void InsertTmp(string custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_tmp_002";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", "C1");
            oCmd.Parameters.AddWithValue("@custno", custno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}
