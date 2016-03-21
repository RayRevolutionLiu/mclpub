using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class RemailFM : System.Web.UI.Page
    {
        RemailFM_DB myRemail = new RemailFM_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //
                // Evals true first time browser hits the page
                //
                string id = Context.Request.QueryString["id"];
                string seq = Context.Request.QueryString["seq"];
                string oritem = Context.Request.QueryString["oritem"];
                lblNo.Text = id.Substring(0, 13);
                lblCustNo.Text = id.Substring(2, 6);
                //訂購類別
                DataSet ds4 = myRemail.Selectc1_otp();
                DataView dv4 = ds4.Tables[0].DefaultView;
                dv4.RowFilter = "otp_otp1cd=" + id.Substring(8, 2);
                lblType1.Text = dv4[0].Row["otp_otp1nm"].ToString();
                //訂戶資料
                DataSet ds1 = myRemail.Selectc1_cust();
                DataView dv1 = ds1.Tables[0].DefaultView;
                dv1.RowFilter = "cust_custno=" + id.Substring(2, 6);
                lblCustName.Text = dv1[0].Row["cust_nm"].ToString();
                lblCoName.Text = dv1[0].Row["mfr_inm"].ToString();
                //收件人資料
                DataSet ds2 = myRemail.Selectc1_or();
                DataView dv2 = ds2.Tables[0].DefaultView;
                dv2.RowFilter = "or_custno=" + lblCustNo.Text + " and or_otp1cd=" + id.Substring(8, 2) +
                    " and or_otp1seq=" + id.Substring(10, 3) + " and or_oritem=" + oritem;
                //					+" and ra_oditem="+oditem;
                lblRecName.Text = dv2[0].Row["or_nm"].ToString();
                lblRecAddr.Text = dv2[0].Row["or_addr"].ToString();
                //補書序號
                DataSet ds3 = myRemail.Selectc1_remail();
                DataView dv3 = ds3.Tables[0].DefaultView;
                dv3.RowFilter = "rm_custno=" + id.Substring(2, 6) + " and rm_otp1cd='" + id.Substring(8, 2) + "'" +
                    " and rm_otp1seq=" + id.Substring(10, 3) + " and rm_oritem=" + oritem + " and rm_seq=" + seq;
                lblRemailSeq.Text = dv3[0].Row["rm_seq"].ToString().Trim();
                textarea1.Value = dv3[0].Row["rm_cont"].ToString().Trim();
                if (dv3[0].Row["rm_fgsent"].ToString().Trim() == "Y")
                    ddlSendFlag.SelectedIndex = 0;
                else if (dv3[0].Row["rm_fgsent"].ToString().Trim() == "N")
                    ddlSendFlag.SelectedIndex = 1;
                else if (dv3[0].Row["rm_fgsent"].ToString().Trim() == "D")
                    ddlSendFlag.SelectedIndex = 2;
                else if (dv3[0].Row["rm_fgsent"].ToString().Trim() == "C")
                    ddlSendFlag.SelectedIndex = 3;
                //補書日期
                tbxRemailDate.Text = dv3[0].Row["rm_date"].ToString().Trim();
                lblsdate.Text = dv3[0].Row["rm_sdate"].ToString().Trim();
                lbledate.Text = dv3[0].Row["rm_edate"].ToString().Trim();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Context.Request.QueryString["id"] != null && Context.Request.QueryString["id"].ToString() != "" && Context.Request.QueryString["id"].ToString().Length >= 13)
            {
                string id = Context.Request.QueryString["id"];
                myRemail.Updatec1_remail(id.Substring(0, 2), id.Substring(2, 6), id.Substring(8, 2), id.Substring(10, 3), Context.Request.QueryString["oritem"], lblRemailSeq.Text,
                    textarea1.Value, tbxRemailDate.Text, ddlSendFlag.SelectedItem.Value.Trim(), lblsdate.Text.Trim(), lbledate.Text.Trim(), id.Substring(2, 6), Context.Request.QueryString["oritem"],
                    id.Substring(8, 2), id.Substring(10, 3), id.Substring(0, 2), lblRemailSeq.Text);

                JavaScript.AlertMessageRedirect(this.Page, "修改補書資料已完成", "RemailSearch.aspx?function1=mod");

            }
            else
            {
                JavaScript.AlertMessage(this.Page, "參數錯誤");
                return;
            }

        }
    }
}