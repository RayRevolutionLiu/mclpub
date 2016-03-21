using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Pay
{
    public partial class PayFMFilter : System.Web.UI.Page
    {
        PayFMFilter_DB myPay = new PayFMFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nostr = "";
            DataSet ds1 = myPay.Selectpy();
            DataView dv1 = ds1.Tables[0].DefaultView;
            dv1.RowFilter = "py_pyno='" + tbxPyno.Text.Trim() + "'";

            if (dv1.Count <= 0)
            {
                JavaScript.AlertMessage(this.Page, "查無此繳款編號");
                return;
            }
            else
            {
                if (dv1[0].Row["py_pysdate"].ToString().Trim() == "")
                {
                    DataSet ds2 = myPay.Selectpyd();
                    DataView dv2 = ds2.Tables[0].DefaultView;
                    dv2.RowFilter = "pyd_pyno='" + tbxPyno.Text.Trim() + "' and pyd_cancel=''";
                    for (int i = 0; i < dv2.Count; i++)
                        nostr += dv2[i].Row["pyd_iano"];
                    Response.Redirect("PayTypeFM.aspx?pyno=" + tbxPyno.Text.Trim() + "&no=" + nostr);
                }
                else
                {
                    JavaScript.AlertMessage(this.Page, "此繳款資料已產生繳款清單不允許修改");
                    return;
                }
            }
        }
    }
}