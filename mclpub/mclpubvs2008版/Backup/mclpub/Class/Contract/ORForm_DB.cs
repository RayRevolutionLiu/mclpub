using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;


namespace mclpub
{
    public class ORForm_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectCust()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cust_custno, cust_nm, cust_jbti, cust_tel, cust_fax, cust_cell, cust_email");
            sb.Append(@", cust_mfrno FROM cust");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "cust");
            return ds;

        }


        public DataSet SelectMtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "mtp");
            return ds;

        }


        public DataSet SelectMfr()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip FROM mfr");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "mfr");
            return ds;

        }


        public DataSet SelectC2_or()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax");
            sb.Append(@", or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea ");
            //sb.Append(@"");
            sb.Append(@"FROM c2_or WHERE (or_syscd = 'C2')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "c2_or");
            return ds;

        }


        public DataSet SelectMaxC2_or()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MAX(or_oritem) AS MaxORItem, or_contno FROM c2_or WHERE (or_syscd = 'C2') ");
            sb.Append(@"GROUP BY or_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds, "c2_or");
            return ds;

        }


        public void DelC2_or(string strSyscd, string strContNo, string strORItem)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM c2_or WHERE (or_syscd = @syscd) AND (or_oritem = @oritem) AND (or_contno = @contno)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@oritem", strContNo);
            oCmd.Parameters.AddWithValue("@contno", strORItem);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void UpdateC2_or(string strSyscd, string strContNo, string strNewORItem, string stri)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c2_or SET or_oritem = @Neworitem WHERE (or_syscd = @syscd) AND (or_contno = @contno) AND (or_oritem = @oritem)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@Neworitem", strSyscd);
            oCmd.Parameters.AddWithValue("@syscd", strContNo);
            oCmd.Parameters.AddWithValue("@contno", strNewORItem);
            oCmd.Parameters.AddWithValue("@oritem", stri);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void UpdateC2_orALL(string strMfrinm, string strORName, string strORJobTitle, string strORZipcode, string strORAddr, string strORTel, string strORFax, string strORCell, string strOREmail, string strORPubCount, string strORUnPubCount, string strORmtpcd, string strORfgmosea, string strsyscd, string strcontno, string strORItem)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE c2_or SET or_inm = @inm, or_nm = @nm, or_jbti = @jbti, or_addr = @addr, or_zip = @zip, or_tel = @tel, or_fax = @fax, or_cell = @cell, or_email = @email, or_mtpcd = @mtpcd, or_pubcnt = @pubcnt, or_unpubcnt = @unpubcnt, or_fgmosea = @fgmosea WHERE (or_syscd = @syscd) AND (or_contno = @contno) AND (or_oritem = @oritem)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@inm", strMfrinm);
            oCmd.Parameters.AddWithValue("@nm", strORName);
            oCmd.Parameters.AddWithValue("@jbti", strORJobTitle);
            oCmd.Parameters.AddWithValue("@addr", strORZipcode);
            oCmd.Parameters.AddWithValue("@zip", strORAddr);
            oCmd.Parameters.AddWithValue("@tel", strORTel);
            oCmd.Parameters.AddWithValue("@fax", strORFax);
            oCmd.Parameters.AddWithValue("@cell", strORCell);
            oCmd.Parameters.AddWithValue("@email", strOREmail);
            oCmd.Parameters.AddWithValue("@mtpcd", strORPubCount);
            oCmd.Parameters.AddWithValue("@pubcnt", strORUnPubCount);
            oCmd.Parameters.AddWithValue("@unpubcnt", strORmtpcd);
            oCmd.Parameters.AddWithValue("@fgmosea", strORfgmosea);
            oCmd.Parameters.AddWithValue("@syscd", strsyscd);
            oCmd.Parameters.AddWithValue("@contno", strcontno);
            oCmd.Parameters.AddWithValue("@oritem", strORItem);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public void InsertC2_or(string strSyscd, string strContNo, string strORItem, string strMfrinm, string strORName, string strORJobTitle, string strORZipcode, string strORAddr, string strORTel, string strORFax, string strORCell, string strOREmail, string strPubCount, string strUnPubCount, string strORmtpcd, string strORfgmosea)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"INSERT INTO c2_or (or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea) VALUES (@syscd, @contno, @oritem, @inm, @nm, @jbti, @addr, @zip, @tel, @fax, @cell, @email, @mtpcd, @pubcnt, @unpubcnt, @fgmosea)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Parameters.AddWithValue("@oritem", strORItem);
            oCmd.Parameters.AddWithValue("@inm", strMfrinm);
            oCmd.Parameters.AddWithValue("@nm", strORName);
            oCmd.Parameters.AddWithValue("@jbti", strORJobTitle);
            oCmd.Parameters.AddWithValue("@zip", strORZipcode);
            oCmd.Parameters.AddWithValue("@addr", strORAddr);
            oCmd.Parameters.AddWithValue("@tel", strORTel);
            oCmd.Parameters.AddWithValue("@fax", strORFax);
            oCmd.Parameters.AddWithValue("@cell", strORCell);
            oCmd.Parameters.AddWithValue("@email", strOREmail);
            oCmd.Parameters.AddWithValue("@pubcnt", strPubCount);
            oCmd.Parameters.AddWithValue("@unpubcnt", strUnPubCount);
            oCmd.Parameters.AddWithValue("@mtpcd", strORmtpcd);
            oCmd.Parameters.AddWithValue("@fgmosea", strORfgmosea);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }
    }
}
