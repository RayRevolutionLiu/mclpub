using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Pay
{
    public partial class PayFilter : System.Web.UI.Page
    {
        PayFilter_DB myPay = new PayFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string keyword = tbxKeyWord.Text.Trim();
            DataSet ds1 = myPay.Selectia(keyword);
            DataView dv1 = ds1.Tables[0].DefaultView;
            //if (tbxlst_sdate.Text.Trim() != "" && tbxlst_edate.Text.Trim() != "")
            //{
            //    dv1.RowFilter = "";
            //}
            DataList1.DataSource = dv1;
            DataList1.DataBind();
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                if (DataList1.Items.Count == 0)
                {
                    ((Panel)e.Item.FindControl("Panel_Noting")).Visible = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool chk = false;
            string strbuf = string.Empty;
            int count = 0;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
                {
                    strbuf += ((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
                    count += Convert.ToInt32(((Label)DataList1.Items[i].FindControl("lblAmt")).Text);
                    chk = true;
                }
            }
            
            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("請選擇欲付款之發票"));
                return;
            }
            else
            {
                security se = new security();
                string ConvertCount = se.encryptquerystring(count.ToString());
                string Convertstrbuf = se.encryptquerystring(strbuf);
                if (Context.Request.QueryString["caller"] == "order")
                {
                    Response.Redirect("PayTypeForm.aspx?count=" + ConvertCount + "&caller=order&no=" + Convertstrbuf);
                }
                else
                {
                    Response.Redirect("PayTypeForm.aspx?count=" + ConvertCount + "&caller=&no=" + Convertstrbuf);
                }
            }
        }
    }
}