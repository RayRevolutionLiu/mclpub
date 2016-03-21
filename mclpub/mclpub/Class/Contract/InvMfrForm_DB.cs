using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class InvMfrForm_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelectFgitri()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT fgitri.fgitri_fgitri, fgitri.fgitri_name, dbo.proj.proj_fgitri FR");
            sb.Append(@"OM dbo.proj INNER JOIN fgitri ON dbo.proj.proj_fgitri COLLATE Chinese_Taiwan_Str");
            sb.Append(@"oke_BIN = fgitri.fgitri_fgitri WHERE (dbo.proj.proj_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;

        }

        //從以下開始我懶的用DATATABLE了 直接複製貼上DataSet啦!!
        public DataSet SelectCust()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cust_custno, cust_nm, cust_jbti, cust_tel, cust_fax, cust_cell, cust_email");
            sb.Append(@", cust_mfrno FROM dbo.cust");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds,"cust");
            return ds;

        }


        public DataSet SelectMfr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip FROM dbo.mfr");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds, "mfr");
            return ds;

        }


        public DataSet SelectInvmfr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd FROM dbo.invmfr WHERE (im_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds, "invmfr");
            return ds;

        }


        public DataSet SelectMaxInvmfr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MAX(im_imseq) AS MaxIMSeq, im_contno FROM dbo.invmfr WHERE (im_syscd = 'C2') GROUP BY im_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds, "invmfr");
            return ds;

        }


        public DataSet SelectC2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.invmfr.im_syscd, dbo.invmfr.im_contno, dbo.invmfr.im_imseq FROM dbo.invmfr");
            sb.Append(@" INNER JOIN dbo.c2_pub ON dbo.invmfr.im_syscd = dbo.c2_pub.pub_syscd AND dbo");
            sb.Append(@".invmfr.im_contno = dbo.c2_pub.pub_contno AND dbo.invmfr.im_imseq = dbo.c2_pub.pub_imseq");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds, "c2_pub");
            return ds;

        }



        public void InsertInvmfr(string strSyscd, string strContNo, string strIMSeq, string strMfrno, string strIMName, string strIMJobTitle, string strIMZipcode, string strIMAddr, string strIMTel, string strIMFax, string strIMCell, string strIMEmail, string strIMinvcd, string strIMtaxtp, string strIMfgitri)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"INSERT INTO invmfr (im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri) VALUES (@syscd, @contno, @imseq, @mfrno, @nm, @jbti, @zip, @addr, @tel, @fax, @cell, @email, @invcd, @taxtp, @fgitri)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Parameters.AddWithValue("@imseq", strIMSeq);
            oCmd.Parameters.AddWithValue("@mfrno", strMfrno);
            oCmd.Parameters.AddWithValue("@nm", strIMName);
            oCmd.Parameters.AddWithValue("@jbti", strIMJobTitle);
            oCmd.Parameters.AddWithValue("@zip", strIMZipcode);
            oCmd.Parameters.AddWithValue("@addr", strIMAddr);
            oCmd.Parameters.AddWithValue("@tel", strIMTel);
            oCmd.Parameters.AddWithValue("@fax", strIMFax);
            oCmd.Parameters.AddWithValue("@cell", strIMCell);
            oCmd.Parameters.AddWithValue("@email", strIMEmail);
            oCmd.Parameters.AddWithValue("@invcd", strIMinvcd);
            oCmd.Parameters.AddWithValue("@taxtp", strIMtaxtp);
            oCmd.Parameters.AddWithValue("@fgitri", strIMfgitri);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void UpdateInvmfr(string strMfrno, string strIMName, string strIMJobTitle, string strIMZipcode, string strIMAddr, string strIMTel, string strIMFax, string strIMCell, string strIMEmail, string strIMinvcd, string strIMtaxtp, string strIMfgitri, string strsyscd, string strcontno, string strimseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE invmfr SET im_mfrno = @mfrno, im_nm = @nm, im_jbti = @jbti, im_zip = @zip, im_addr = @addr, im_tel = @tel, im_fax = @fax, im_cell = @cell, im_email = @email, im_invcd = @invcd, im_taxtp = @taxtp, im_fgitri = @fgitri WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_imseq = @imseq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@mfrno", strMfrno);
            oCmd.Parameters.AddWithValue("@nm", strIMName);
            oCmd.Parameters.AddWithValue("@jbti", strIMJobTitle);
            oCmd.Parameters.AddWithValue("@zip", strIMZipcode);
            oCmd.Parameters.AddWithValue("@addr", strIMAddr);
            oCmd.Parameters.AddWithValue("@tel", strIMTel);
            oCmd.Parameters.AddWithValue("@fax", strIMFax);
            oCmd.Parameters.AddWithValue("@cell", strIMCell);
            oCmd.Parameters.AddWithValue("@email", strIMEmail);
            oCmd.Parameters.AddWithValue("@invcd", strIMinvcd);
            oCmd.Parameters.AddWithValue("@taxtp", strIMtaxtp);
            oCmd.Parameters.AddWithValue("@fgitri", strIMfgitri);
            oCmd.Parameters.AddWithValue("@syscd", strsyscd);
            oCmd.Parameters.AddWithValue("@contno", strcontno);
            oCmd.Parameters.AddWithValue("@imseq", strimseq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void DelInvmfr(string strSyscd, string strContNo, string strIMSeq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM invmfr WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_imseq = @imseq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Parameters.AddWithValue("@imseq", strIMSeq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void UpdateInvmfr2(string strSyscd, string strContNo, string strNewIMSeq, string stri)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE invmfr SET im_imseq = @NewIMSeq WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_imseq = @imseq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Parameters.AddWithValue("@NewIMSeq", strNewIMSeq);
            oCmd.Parameters.AddWithValue("@imseq", stri);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}
