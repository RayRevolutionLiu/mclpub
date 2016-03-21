using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class RemailForm : System.Web.UI.Page
    {
        RemailForm_DB myRe = new RemailForm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Context.Request.QueryString["id"];
                string date = Context.Request.QueryString["date"];
                string oritem = Context.Request.QueryString["oritem"];
                lblNo.Text = id.Substring(0, 13);
                lblCustNo.Text = id.Substring(2, 6);
                //訂購類別
                DataSet ds4 = myRe.Selectc1_otp();
                DataView dv4 = ds4.Tables[0].DefaultView;
                dv4.RowFilter = "otp_otp1cd=" + id.Substring(8, 2);
                lblType1.Text = dv4[0].Row["otp_otp1nm"].ToString();
                //訂戶資料
                DataSet ds1 = myRe.Selectc1_cust();
                DataView dv1 = ds1.Tables[0].DefaultView;
                dv1.RowFilter = "cust_custno=" + id.Substring(2, 6);
                lblCustName.Text = dv1[0].Row["cust_nm"].ToString();
                lblCoName.Text = dv1[0].Row["mfr_inm"].ToString();
                //收件人資料
                DataSet ds2 = myRe.Selectc1_or();
                DataView dv2 = ds2.Tables[0].DefaultView;
                dv2.RowFilter = "or_custno=" + lblCustNo.Text + " and or_otp1cd=" + id.Substring(8, 2) +
                    " and or_otp1seq=" + id.Substring(10, 3) + " and or_oritem=" + oritem;
                //					+" and ra_oditem="+oditem;
                lblRecName.Text = dv2[0].Row["or_nm"].ToString();
                lblRecAddr.Text = dv2[0].Row["or_addr"].ToString();
                //補書序號
                DataSet ds3 = myRe.Selectc1_remail();
                DataView dv3 = ds3.Tables[0].DefaultView;
                dv3.RowFilter = "rm_custno=" + id.Substring(2, 6) + " and rm_otp1cd='" + id.Substring(8, 2) + "'" +
                    " and rm_otp1seq=" + id.Substring(10, 3) + " and rm_oritem=" + oritem;
                //					+" and rm_oditem="+oditem;
                string str2 = ((int)(dv3.Count + 1)).ToString();
                int j = 2 - str2.Length;
                for (int i = 0; i < j; i++)
                    str2 = "0" + str2;
                lblRemailSeq.Text = str2;
                //補書登錄日期
                if (date.Length <= 0)
                {
                    lblsdate.Text = "";
                    lbledate.Text = "";
                }
                else
                {
                    lblsdate.Text = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6, 2);
                    lbledate.Text = date.Substring(8, 4) + "/" + date.Substring(12, 2) + "/" + date.Substring(14, 2);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string id = Context.Request.QueryString["id"];
            myRe.Insertc1_remail("C1", lblCustNo.Text, id.Substring(8, 2), id.Substring(10, 3), Context.Request.QueryString["oritem"], lblRemailSeq.Text, textarea1.Value, "", ddlSendFlag.SelectedItem.Value.Trim(), lblsdate.Text.Trim(), lbledate.Text.Trim());
            btnOK.Enabled = false;
            lblMessage.Text = "補書登錄完成";
            JavaScript.AlertMessage(this.Page, "補書登錄完成");
        }
    }
}