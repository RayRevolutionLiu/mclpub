using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class otp : System.Web.UI.Page
    {
        otp_DB myotp = new otp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();

                DataTable dt = myotp.SelectOtpName();
                ddlotp_otp1cd.DataSource = dt;
                ddlotp_otp1cd.DataTextField = "name";
                ddlotp_otp1cd.DataValueField = "value";
                ddlotp_otp1cd.DataBind();

                ddlotp_otp1cd.SelectedIndex = 0;

                DataTable dtMax = myotp.OutPutMaxValue(ddlotp_otp1cd.SelectedValue.ToString());
                DataView dv = dtMax.DefaultView;

                string strAssignedContNo = "";

                if (dv.Count > 0 && dv[0]["C1"].ToString() != "0")
                {
                    if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1)) < 10)
                    {
                        strAssignedContNo = Convert.ToString("0" + (Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                    }
                    else
                    {
                        strAssignedContNo = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                    }
                }
                else
                {
                    strAssignedContNo += "01";
                }

                TextBoxotp_otp2cd.Text = strAssignedContNo;

            }
        }

        public void BindGrid()
        {
            DataSet ds = myotp.Selectc1_otp();
            DataTable dt = ds.Tables[0];
            UCPager1.Dtdata = dt;
            UCPager1.UCPageBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Edit_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            Edit_button.Visible = false;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;

            string optcd = thisRow.Cells[1].Text.Trim();
            Label Labelotp_otp1nm = (Label)thisRow.Cells[2].FindControl("Labelotp_otp1nm");
            Label Labelotp_otp2cd = (Label)thisRow.Cells[3].FindControl("Labelotp_otp2cd");
            Label Labelotp_otp2nm = (Label)thisRow.Cells[4].FindControl("Labelotp_otp2nm");

            DropDownList ddlotp_otp1nm = (DropDownList)thisRow.Cells[2].FindControl("ddlotp_otp1nm");
            TextBox TextBoxotp_otp2cd = (TextBox)thisRow.Cells[3].FindControl("TextBoxotp_otp2cd");
            TextBox TextBoxotp_otp2nm = (TextBox)thisRow.Cells[4].FindControl("TextBoxotp_otp2nm");


            DataTable dt = myotp.SelectOtpName();
            ddlotp_otp1nm.DataSource = dt;
            ddlotp_otp1nm.DataTextField = "name";
            ddlotp_otp1nm.DataValueField = "value";
            ddlotp_otp1nm.DataBind();

            ddlotp_otp1nm.SelectedValue = optcd;

            Labelotp_otp1nm.Visible = false;
            Labelotp_otp2cd.Visible = false;
            Labelotp_otp2nm.Visible = false;

            ddlotp_otp1nm.Visible = true;
            TextBoxotp_otp2cd.Visible = true;
            TextBoxotp_otp2nm.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button SubBtn_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            string itp_itpid = thisRow.Cells[0].Text.Trim();
            //string otp_otp1cd = thisRow.Cells[1].Text.Trim();

            Label Labelotp_otp1nm = (Label)thisRow.Cells[2].FindControl("Labelotp_otp1nm");
            Label Labelotp_otp2cd = (Label)thisRow.Cells[3].FindControl("Labelotp_otp2cd");
            Label Labelotp_otp2nm = (Label)thisRow.Cells[4].FindControl("Labelotp_otp2nm");

            DropDownList ddlotp_otp1nm = (DropDownList)thisRow.Cells[2].FindControl("ddlotp_otp1nm");
            TextBox TextBoxotp_otp2cd = (TextBox)thisRow.Cells[3].FindControl("TextBoxotp_otp2cd");
            TextBox TextBoxotp_otp2nm = (TextBox)thisRow.Cells[4].FindControl("TextBoxotp_otp2nm");


            if (ddlotp_otp1nm.SelectedValue.ToString()=="")
            {
                JavaScript.AlertMessage(this.Page, "訂購類別1名稱不能為空值");
                return;
            }

            if (TextBoxotp_otp2cd.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "訂購類別2代碼不能為空值");
                return;
            }

            if (TextBoxotp_otp2nm.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "訂購類別2名稱不能為空值");
                return;
            }

            //DataSet ds1 = myotp.Selectc1_otp();

            //DataView dv = ds1.Tables[0].DefaultView;
            //string Strfilter = " 1=1 AND otp_otp1cd = '" + ddlotp_otp1nm.SelectedValue.ToString().Trim() + "' AND otp_otp2cd='" + TextBoxotp_otp2cd.Text.Trim() + "'";

            //dv.RowFilter = Strfilter;

            //if (dv.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            //    return;
            //}

            myotp.Updatec1_otp(ddlotp_otp1nm.SelectedValue.ToString(), ddlotp_otp1nm.SelectedItem.Text.ToString(), TextBoxotp_otp2cd.Text.Trim(),
                TextBoxotp_otp2nm.Text.Trim(), itp_itpid);

            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;


            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelotp_otp1nm.Visible = true;
            Labelotp_otp2cd.Visible = true;
            Labelotp_otp2nm.Visible = true;

            ddlotp_otp1nm.Visible = false;
            TextBoxotp_otp2cd.Visible = false;
            TextBoxotp_otp2nm.Visible = false;

            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料更新成功!");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Cancel_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button EditBtn = (Button)thisRow.Cells[3].FindControl("btnEdit");

            Cancel_button.Visible = false;
            SubBtn.Visible = false;
            EditBtn.Visible = true;

            Label Labelotp_otp1nm = (Label)thisRow.Cells[2].FindControl("Labelotp_otp1nm");
            Label Labelotp_otp2cd = (Label)thisRow.Cells[3].FindControl("Labelotp_otp2cd");
            Label Labelotp_otp2nm = (Label)thisRow.Cells[4].FindControl("Labelotp_otp2nm");

            DropDownList ddlotp_otp1nm = (DropDownList)thisRow.Cells[2].FindControl("ddlotp_otp1nm");
            TextBox TextBoxotp_otp2cd = (TextBox)thisRow.Cells[3].FindControl("TextBoxotp_otp2cd");
            TextBox TextBoxotp_otp2nm = (TextBox)thisRow.Cells[4].FindControl("TextBoxotp_otp2nm");

            Labelotp_otp1nm.Visible = true;
            Labelotp_otp2cd.Visible = true;
            Labelotp_otp2nm.Visible = true;

            ddlotp_otp1nm.Visible = false;
            TextBoxotp_otp2cd.Visible = false;
            TextBoxotp_otp2nm.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            myotp.Delc1_otp(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}