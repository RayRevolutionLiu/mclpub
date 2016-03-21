using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class CancelAndCloseShow_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectGrid01(string tbxCompanyName, string tbxMfrNo, string tbxCustNo, string tbxCustName, string tbxContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno");
            sb.Append(@", c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, mfr.mfr_mfrid, mfr.mfr_mfrno");
            sb.Append(@", mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_tel, cust.cust_oldcustno,");
            sb.Append(@" book.bk_nm, book.bk_bkcd, c2_cont.cont_fgclosed, c2_cont.cont_fgpubed, c2_cont.cont_fgcancel FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgclosed <> '0')");
            if (tbxCompanyName.ToString() != "")
            {
                sb.Append(@" and mfr_inm Like '%'+@tbxCompanyName+'%' ");
            }
            if (tbxMfrNo.ToString() != "")
            {
                sb.Append(@" and mfr_mfrno Like '%'+@tbxMfrNo+'%' ");
            }
            if (tbxCustNo.ToString() != "")
            {
                sb.Append(@" and cont_custno Like '%'+@tbxCustNo+'%' ");
            }
            if (tbxCustNo.ToString() != "")
            {
                sb.Append(@" and cust_nm Like '%'+@tbxCustName+'%' ");
            }
            if (tbxContNo.ToString() != "")
            {
                sb.Append(@" and cont_contno Like '%'+@tbxContNo+'%' ");
            }
            sb.Append(@" order by c2_cont.cont_contno ASC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@tbxCompanyName", tbxCompanyName);
            oCmd.Parameters.AddWithValue("@tbxMfrNo", tbxMfrNo);
            oCmd.Parameters.AddWithValue("@tbxCustNo", tbxCustNo);
            oCmd.Parameters.AddWithValue("@tbxCustName", tbxCustName);
            oCmd.Parameters.AddWithValue("@tbxContNo", tbxContNo);
            oda.Fill(ds, "c2_cont");
            return ds;

        }



        public DataSet SelectGrid02(string tbxCompanyName, string tbxMfrNo, string tbxCustNo, string tbxCustName, string tbxContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp");
            sb.Append(@", c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_sdate");
            sb.Append(@", c2_cont.cont_edate, c2_cont.cont_custno, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, cust.cust_custid, cust.cust_custno, cust.cust_nm");
            sb.Append(@", cust.cust_jbti, cust.cust_tel, cust.cust_oldcustno, book.bk_nm, book.bk_bkcd, c2_cont.cont_fgclosed, c2_cont.cont_fgpubed, c2_cont.cont_fgcancel FROM c2_cont ");
            sb.Append(@"INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust");
            sb.Append(@" ON c2_cont.cont_custno = cust.cust_custno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgcancel <> '1')");
            if (tbxCompanyName.ToString() != "")
            {
                sb.Append(@" and mfr_inm Like '%'+@tbxCompanyName+'%' ");
            }
            if (tbxMfrNo.ToString() != "")
            {
                sb.Append(@" and mfr_mfrno Like '%'+@tbxMfrNo+'%' ");
            }
            if (tbxCustNo.ToString() != "")
            {
                sb.Append(@" and cont_custno Like '%'+@tbxCustNo+'%' ");
            }
            if (tbxCustNo.ToString() != "")
            {
                sb.Append(@" and cust_nm Like '%'+@tbxCustName+'%' ");
            }
            if (tbxContNo.ToString() != "")
            {
                sb.Append(@" and cont_contno Like '%'+@tbxContNo+'%' ");
            }
            sb.Append(@" order by c2_cont.cont_contno ASC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@tbxCompanyName", tbxCompanyName);
            oCmd.Parameters.AddWithValue("@tbxMfrNo", tbxMfrNo);
            oCmd.Parameters.AddWithValue("@tbxCustNo", tbxCustNo);
            oCmd.Parameters.AddWithValue("@tbxCustName", tbxCustName);
            oCmd.Parameters.AddWithValue("@tbxContNo", tbxContNo);
            oda.Fill(ds, "c2_cont");
            return ds;

        }




        public void UpdateC2_cont(string strSyscd, string strContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c2_cont SET cont_fgcancel = 1 WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@syscd", strSyscd);
            oCmd.Parameters.AddWithValue("@contno", strContNo);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }



        public DataSet SelectGrid03(string tbxCompanyName, string tbxMfrNo, string tbxCustNo, string tbxCustName, string tbxContNo)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp");
            sb.Append(@", c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_sdate");
            sb.Append(@", c2_cont.cont_edate, c2_cont.cont_custno, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, cust.cust_custid, cust.cust_custno, cust.cust_nm");
            sb.Append(@", cust.cust_jbti, cust.cust_tel, cust.cust_oldcustno, book.bk_nm, book.bk_bkcd, c2_cont.cont_fgclosed, c2_cont.cont_fgpubed, c2_cont.cont_fgcancel FROM c2_cont ");
            sb.Append(@"INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust");
            sb.Append(@" ON c2_cont.cont_custno = cust.cust_custno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgcancel <> '0')");
            if (tbxCompanyName.ToString() != "")
            {
                sb.Append(@" and mfr_inm Like '%'+@tbxCompanyName+'%' ");
            }
            if (tbxMfrNo.ToString() != "")
            {
                sb.Append(@" and mfr_mfrno Like '%'+@tbxMfrNo+'%' ");
            }
            if (tbxCustNo.ToString() != "")
            {
                sb.Append(@" and cont_custno Like '%'+@tbxCustNo+'%' ");
            }
            if (tbxCustNo.ToString() != "")
            {
                sb.Append(@" and cust_nm Like '%'+@tbxCustName+'%' ");
            }
            if (tbxContNo.ToString() != "")
            {
                sb.Append(@" and cont_contno Like '%'+@tbxContNo+'%' ");
            }
            sb.Append(@" order by c2_cont.cont_contno ASC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@tbxCompanyName", tbxCompanyName);
            oCmd.Parameters.AddWithValue("@tbxMfrNo", tbxMfrNo);
            oCmd.Parameters.AddWithValue("@tbxCustNo", tbxCustNo);
            oCmd.Parameters.AddWithValue("@tbxCustName", tbxCustName);
            oCmd.Parameters.AddWithValue("@tbxContNo", tbxContNo);
            oda.Fill(ds, "c2_cont");
            return ds;

        }
    }
}
