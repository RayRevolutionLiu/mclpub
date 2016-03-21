using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace mclpub.SetAccount
{
    public partial class SAPRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        #region sp_sap_recovery_001, sp_sap_recovery_002
        public bool Recovery001()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_sap_recovery_001";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", lblyyyymm.Text.Trim());
            oCmd.Parameters.AddWithValue("@batch_seq", lblbatchseq.Text.Trim());
            SqlParameter retValParam = oCmd.Parameters.Add("@rtn", SqlDbType.Char, 6);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            //影響的資料數如果大於0就是該im無法刪除
            if (retValParam.Value == "1")
                return false;
            else
                return true;
        }

        public bool Recovery002()
        {

            SqlCommand oCmd1 = new SqlCommand();
            oCmd1.Connection = new SqlConnection(Conn);
            oCmd1.CommandText = @"sp_sap_recovery_002";
            oCmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd1);
            oCmd1.Parameters.AddWithValue("@yyyymm", lblyyyymm.Text.Trim());
            oCmd1.Parameters.AddWithValue("@batch_seq", lblbatchseq.Text.Trim());
            SqlParameter retValParam = oCmd1.Parameters.Add("@rtn", SqlDbType.Char, 6);
            retValParam.Direction = ParameterDirection.Output;
            oCmd1.Connection.Open();
            oCmd1.ExecuteNonQuery();
            oCmd1.Connection.Close();

            //影響的資料數如果大於0就是該im無法刪除
            if (retValParam.Value == "1")
                return false;
            else
                return true;
        }
        #endregion

        protected void btn_Recovery_Click(object sender, EventArgs e)
        {
            if (lblyyyymm.Text.Trim() == "")
            {
                lblMessage1.Text = "轉檔年月不可空白";
                return;
            }
            if (lblbatchseq.Text.Trim() == "")
            {
                lblMessage1.Text = "批次不可空白";
                return;
            }
            if(!Recovery001())
            {
                lblMessage1.Text = "Recovery001-Error!";
                return;
            }
            if (!Recovery002())
            {
                lblMessage1.Text = "Recovery002-Error!";
                return;
            }
            lblMessage1.Text = "發票開立單轉SAP回復--成功";
        }
    }
}