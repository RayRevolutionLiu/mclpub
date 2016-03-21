using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace mclpub.Pay
{
    public partial class PayDelete : System.Web.UI.Page
    {
        PayDelete_DB myPay = new PayDelete_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool flag1 = true;
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
                    for (int i = 0; i < dv1.Count; i++)
                    {
                        if (dv1[i].Row["ias_trans_sap"].ToString().Trim() == "1")
                            flag1 = false;
                    }
                    if (flag1)
                    {
                        PayDelGV.Visible = true;
                        PayDelGV.DataSource = dv1;
                        PayDelGV.DataBind();
                        btnDelete.Visible = true;
                        SearchIcon.Visible = true;
                    }
                    else
                    {
                        JavaScript.AlertMessage(this.Page, "此繳款資料之發票已轉SAP, 不允許刪除");
                        return;
                    }
                }
                else
                {
                    JavaScript.AlertMessage(this.Page, "此繳款資料已產生繳款清單不允許刪除");
                    return;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            myPay.Deletepy(tbxPyno.Text.Trim());
            PayDelGV.Visible = false;
            btnDelete.Visible = false;
            SearchIcon.Visible = false;
            JavaScript.AlertMessage(this.Page, "刪除繳款資料已完成");
        }
    }
}