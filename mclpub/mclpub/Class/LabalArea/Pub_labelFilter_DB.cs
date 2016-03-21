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
    public class Pub_labelFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetFreeBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * from freecat");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet GetSrspns()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname FROM srspn where (srspn_atype = 'B') OR (srspn_atype = 'C')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet GetMailType()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT LTRIM(RTRIM(mtp_mtpcd)) AS mtp_mtpcd, mtp_nm from mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public bool CreateLabelList(string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_label_list");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            SqlParameter retValParam = oCmd.Parameters.Add("@effects",SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
            if (Convert.ToInt32(retValParam.Value) <= 0)
            {
                return false;
            }
            return true;

        }


        public string GetBookPno(string bkcd, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM bookp WHERE (bkp_bkcd = @bkcd) AND (bkp_date = @yyyymm)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            DataSet set = new DataSet();
            oda.Fill(set);
            DataView view = set.Tables[0].DefaultView;
            if (view.Count <= 0)
            {
                return "";
            }
            //return view.get_Item(0).get_Row().get_Item("bkp_pno").ToString();
            return view[0]["bkp_pno"].ToString();
        }


        public DataSet GetLabelWithFilter(string strFilter)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, mtp.mtp_nm, freecat.fc_nm, cont_conttpName = CASE cont_conttp WHEN '01' THEN '一般' WHEN '09' THEN '推廣' ELSE '' END FROM wk_c4_label_list INNER JOIN srspn ON wk_c4_label_list.cont_empno = srspn.srspn_empno INNER JOIN mtp ON wk_c4_label_list.ma_mtpcd = mtp.mtp_mtpcd INNER JOIN freecat ON wk_c4_label_list.fbk_bkcd = freecat.fc_fccd WHERE ma_mnt > 0 ");
            if (strFilter.ToString() != "")
            {
                sb.Append(@" AND " + strFilter + " ORDER BY ma_mnt, cont_contno");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}