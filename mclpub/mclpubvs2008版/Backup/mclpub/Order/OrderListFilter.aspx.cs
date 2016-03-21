using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Order
{
    public partial class OrderListFilter : System.Web.UI.Page
    {
        OrderListFilter_DB myOrder = new OrderListFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //付款方式
                DataSet ds3 = myOrder.SelectPytp();
                DataRow dr2 = ds3.Tables[0].NewRow();
                dr2["pytp_pytpcd"] = "00";
                dr2["pytp_nm"] = "請選擇";
                ds3.Tables[0].Rows.Add(dr2);
                ds3.Tables[0].DefaultView.Sort = "pytp_pytpcd ASC";
                DataView dv = ds3.Tables[0].DefaultView;
                ddlPayType.DataSource = dv;
                ddlPayType.DataTextField = "pytp_nm";
                ddlPayType.DataValueField = "pytp_pytpcd";
                ddlPayType.DataBind();
                btnPrintList.Enabled = false;
                //				Response.Write(Session["cname"].ToString());
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            string STRddlPayType = "";
            string STRtbxOrderDate1 = "";
            string STRtbxOrderDate2 = "";
            string STRtbxDate1 = "";
            string STRtbxDate2 = "";
            string STRddlOrderType = "";
            string STRddlBookType = "";
            string STRtbxRecName = "";

            if (ddlPayType.SelectedValue.ToString().Trim() != "00")
            {
                STRddlPayType = ddlPayType.SelectedItem.Value.Trim();
            }
            if (tbxOrderDate1.Text.Trim() != "" && tbxOrderDate2.Text.Trim() != "")
            {
                STRtbxOrderDate1 = tbxOrderDate1.Text.Substring(0, 4) + tbxOrderDate1.Text.Substring(5, 2) + tbxOrderDate1.Text.Substring(8, 2);
                STRtbxOrderDate2 = tbxOrderDate2.Text.Substring(0, 4) + tbxOrderDate2.Text.Substring(5, 2) + tbxOrderDate2.Text.Substring(8, 2);
            }
            if (tbxDate1.Text.Trim() != "" && tbxDate2.Text.Trim() != "")
            {
                STRtbxDate1 = tbxDate1.Text.Substring(0, 4) + tbxDate1.Text.Substring(5, 2) + tbxDate1.Text.Substring(8, 2);
                STRtbxDate2 = tbxDate2.Text.Substring(0, 4) + tbxDate2.Text.Substring(5, 2) + tbxDate2.Text.Substring(8, 2);
            }
            if (ddlOrderType.SelectedValue.ToString().Trim() != "00")
            {
                STRddlOrderType = ddlOrderType.SelectedItem.Value.Trim();
            }
            if (ddlBookType.SelectedValue.ToString().Trim() != "")
            {
                STRddlBookType =ddlBookType.SelectedItem.Value.Trim();
            }
            if (tbxRecName.Text.Trim() != "")
            {
                STRtbxRecName = tbxRecName.Text.Trim();
            }

            DataSet ds1 = myOrder.Selectc1_od(STRddlPayType, STRtbxOrderDate1, STRtbxOrderDate2, STRtbxDate1, STRtbxDate2, STRddlOrderType, STRddlBookType, STRtbxRecName);

            GVSearchCust.DataSource = ds1;
            GVSearchCust.DataBind();

            if (ds1.Tables[0].Rows.Count > 0)
            {
                btnPrintList.Enabled = true;
            }
            else
            {
                btnPrintList.Enabled = false;
            }
        }

        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //書籍類別
            DataSet ds2 = myOrder.Selectc1_obtp();
            DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
            dv2.RowFilter = "obtp_otp1cd='" + ddlOrderType.SelectedItem.Value + "'";
            ddlBookType.DataSource = dv2;
            ddlBookType.DataTextField = "obtp_obtpnm";
            ddlBookType.DataValueField = "obtp_obtpcd";
            ddlBookType.DataBind();
        }
    }
}
