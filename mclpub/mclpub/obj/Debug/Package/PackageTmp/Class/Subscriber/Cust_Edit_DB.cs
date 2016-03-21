using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class Cust_Edit_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable AddNum()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select count(*) as C1,max(cust_custno) as MaxCountNo from cust";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectTitle()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select * from mfr order by mfr_inm";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectOthers(string mfr_mfrno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select * from mfr where mfr_mfrno=@mfr_mfrno";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelecSeles()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select * from srspn where srspn_atype in ('B','C','D')";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectChKBoxs1()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select * from itp";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectChKBoxs2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select * from btp";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable JudgeDoubleOrNot(string cust_custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select * from cust where cust_custno=@cust_custno";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public void InsertNewCust(string cust_custno, string cust_nm, string cust_jbti, string cust_mfrno, string cust_tel, string cust_fax, string cust_cell, string cust_email, string cust_regdate, string cust_moddate, string cust_oldcustno, string cust_itpcd, string cust_rtpcd, string cust_btpcd, string cust_srspn_empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"insert into cust(cust_custno,cust_nm,cust_jbti,cust_mfrno,cust_tel,cust_fax,cust_cell,cust_email,cust_regdate,cust_moddate,cust_oldcustno,cust_itpcd,cust_rtpcd,cust_btpcd,cust_srspn_empno) values(@cust_custno,@cust_nm,@cust_jbti,@cust_mfrno,@cust_tel,@cust_fax,@cust_cell,@cust_email,@cust_regdate,@cust_moddate,@cust_oldcustno,@cust_itpcd,@cust_rtpcd,@cust_btpcd,@cust_srspn_empno)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oCmd.Parameters.AddWithValue("@cust_nm", cust_nm);
            oCmd.Parameters.AddWithValue("@cust_jbti", cust_jbti);
            oCmd.Parameters.AddWithValue("@cust_mfrno", cust_mfrno);
            oCmd.Parameters.AddWithValue("@cust_tel", cust_tel);
            oCmd.Parameters.AddWithValue("@cust_fax", cust_fax);
            oCmd.Parameters.AddWithValue("@cust_cell", cust_cell);
            oCmd.Parameters.AddWithValue("@cust_email", cust_email);
            oCmd.Parameters.AddWithValue("@cust_regdate", cust_regdate);
            oCmd.Parameters.AddWithValue("@cust_moddate", cust_moddate);
            oCmd.Parameters.AddWithValue("@cust_oldcustno", cust_oldcustno);
            oCmd.Parameters.AddWithValue("@cust_itpcd", cust_itpcd);
            oCmd.Parameters.AddWithValue("@cust_rtpcd", cust_rtpcd);
            oCmd.Parameters.AddWithValue("@cust_btpcd", cust_btpcd);
            oCmd.Parameters.AddWithValue("@cust_srspn_empno", cust_srspn_empno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public DataTable SelectAllForEdit(string cust_custid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"select * from cust where cust_custid=@cust_custid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cust_custid", cust_custid);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public void EditCust(string cust_custno, string cust_nm, string cust_jbti, string cust_mfrno, string cust_tel, string cust_fax, string cust_cell, string cust_email, string cust_regdate, string cust_moddate, string cust_oldcustno, string cust_itpcd, string cust_rtpcd, string cust_btpcd, string cust_srspn_empno, string cust_custid)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"update cust set cust_custno=@cust_custno,cust_nm=@cust_nm,cust_jbti=@cust_jbti,cust_mfrno=@cust_mfrno,cust_tel=@cust_tel,cust_fax=@cust_fax,cust_cell=@cust_cell,cust_email=@cust_email,cust_regdate=@cust_regdate,cust_moddate=@cust_moddate,cust_oldcustno=@cust_oldcustno,cust_itpcd=@cust_itpcd,cust_btpcd=@cust_btpcd,cust_rtpcd=@cust_rtpcd,cust_srspn_empno=@cust_srspn_empno where cust_custid=@cust_custid";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oCmd.Parameters.AddWithValue("@cust_nm", cust_nm);
            oCmd.Parameters.AddWithValue("@cust_jbti", cust_jbti);
            oCmd.Parameters.AddWithValue("@cust_mfrno", cust_mfrno);
            oCmd.Parameters.AddWithValue("@cust_tel", cust_tel);
            oCmd.Parameters.AddWithValue("@cust_fax", cust_fax);
            oCmd.Parameters.AddWithValue("@cust_cell", cust_cell);
            oCmd.Parameters.AddWithValue("@cust_email", cust_email);
            oCmd.Parameters.AddWithValue("@cust_regdate", cust_regdate);
            oCmd.Parameters.AddWithValue("@cust_moddate", cust_moddate);
            oCmd.Parameters.AddWithValue("@cust_oldcustno", cust_oldcustno);
            oCmd.Parameters.AddWithValue("@cust_itpcd", cust_itpcd);
            oCmd.Parameters.AddWithValue("@cust_rtpcd", cust_rtpcd);
            oCmd.Parameters.AddWithValue("@cust_btpcd", cust_btpcd);
            oCmd.Parameters.AddWithValue("@cust_srspn_empno", cust_srspn_empno);
            oCmd.Parameters.AddWithValue("@cust_custid", cust_custid);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}
