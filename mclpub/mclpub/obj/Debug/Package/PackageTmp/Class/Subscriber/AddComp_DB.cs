using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class AddComp_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable Checkmfrno(string mfr_mfrid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from mfr where 1=1");
            if (mfr_mfrid.ToString() != "")
            {
                sb.Append(@" and mfr_mfrid=@mfr_mfrid");

            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfr_mfrid", mfr_mfrid);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable Drop3rdSelect()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select count(*) as C1,max(mfr_mfrno) as MaxCountNo from mfr where mfr_mfrno like '%AA%'";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public void InsertNewComp(string mfr_mfrno, string mfr_inm, string mfr_iaddr, string mfr_izip, string mfr_respnm, string mfr_respjbti, string mfr_tel, string mfr_fax, string mfr_regdate,string mfr_foreign)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into mfr(mfr_mfrno,mfr_inm,mfr_iaddr,mfr_izip,mfr_respnm,mfr_respjbti,mfr_tel,mfr_fax,mfr_regdate,mfr_foreign) values(@mfr_mfrno,@mfr_inm,@mfr_iaddr,@mfr_izip,@mfr_respnm,@mfr_respjbti,@mfr_tel,@mfr_fax,@mfr_regdate,@mfr_foreign)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            oCmd.Parameters.AddWithValue("@mfr_iaddr", mfr_iaddr);
            oCmd.Parameters.AddWithValue("@mfr_izip", mfr_izip);
            oCmd.Parameters.AddWithValue("@mfr_respnm", mfr_respnm);
            oCmd.Parameters.AddWithValue("@mfr_respjbti", mfr_respjbti);
            oCmd.Parameters.AddWithValue("@mfr_tel", mfr_tel);
            oCmd.Parameters.AddWithValue("@mfr_fax", mfr_fax);
            oCmd.Parameters.AddWithValue("@mfr_regdate", mfr_regdate);
            oCmd.Parameters.AddWithValue("@mfr_foreign", mfr_foreign);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }

        public void UpdateComp(string mfr_mfrno, string mfr_inm, string mfr_iaddr, string mfr_izip, string mfr_respnm, string mfr_respjbti, string mfr_tel, string mfr_fax, string mfr_regdate, string id, string mfr_foreign)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update mfr set mfr_mfrno=@mfr_mfrno,mfr_inm=@mfr_inm,mfr_iaddr=@mfr_iaddr,mfr_izip=@mfr_izip,mfr_respnm=@mfr_respnm,mfr_respjbti=@mfr_respjbti,mfr_tel=@mfr_tel,mfr_fax=@mfr_fax,mfr_regdate=@mfr_regdate,mfr_foreign=@mfr_foreign where mfr_mfrid=@mfr_mfrid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            oCmd.Parameters.AddWithValue("@mfr_iaddr", mfr_iaddr);
            oCmd.Parameters.AddWithValue("@mfr_izip", mfr_izip);
            oCmd.Parameters.AddWithValue("@mfr_respnm", mfr_respnm);
            oCmd.Parameters.AddWithValue("@mfr_respjbti", mfr_respjbti);
            oCmd.Parameters.AddWithValue("@mfr_tel", mfr_tel);
            oCmd.Parameters.AddWithValue("@mfr_fax", mfr_fax);
            oCmd.Parameters.AddWithValue("@mfr_regdate", mfr_regdate);
            oCmd.Parameters.AddWithValue("@mfr_mfrid", id);
            oCmd.Parameters.AddWithValue("@mfr_foreign", mfr_foreign);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}
