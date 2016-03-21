using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace mclpub.Sys
{
    public partial class S_FixCostCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE refd set rd_costctr=@pyno;");
            sb.Append(@"UPDATE c2_pub set pub_costctr=@pyno ");
            oCmd.CommandText = sb.ToString();
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pyno", tbxCostCenterNo.Text.Trim());
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            JavaScript.AlertMessage(this.Page, "成本中心異動修正成功");

        }
    }
}