using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class refd : System.Web.UI.Page
    {
        refd_DB myrefd = new refd_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";

            if (!IsPostBack)
            {
                BindGrid();
                DataSet ds = myrefd.Selectsyscd();
                ddlrd_syscd.DataTextField = "sys_nm";
                ddlrd_syscd.DataValueField = "sys_syscd";
                ddlrd_syscd.DataSource = ds;
                ddlrd_syscd.DataBind();

                DataSet dsddlrd_projno = myrefd.Selectproj();
                ddlrd_projno.DataTextField = "proj_projno";
                ddlrd_projno.DataValueField = "proj_projno";
                ddlrd_projno.DataSource = dsddlrd_projno;
                ddlrd_projno.DataBind();
            }
        }

        public void BindGrid()
        {
            DataSet ds = myrefd.Selectrefd();
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
            Button SubBtn = (Button)thisRow.Cells[7].FindControl("SubBtn");
            Button CancelBtn = (Button)thisRow.Cells[7].FindControl("CancelBtn");

            Edit_button.Visible = false;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;

            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelrd_projno = (Label)thisRow.Cells[2].FindControl("Labelrd_projno");
            Label Labelrd_costctr = (Label)thisRow.Cells[3].FindControl("Labelrd_costctr");
            Label Labelrd_accdcr = (Label)thisRow.Cells[4].FindControl("Labelrd_accdcr");
            Label Labelrd_descr = (Label)thisRow.Cells[5].FindControl("Labelrd_descr");

            DropDownList DropDownListsys_nm = (DropDownList)thisRow.Cells[1].FindControl("DropDownListsys_nm");
            DropDownList DropDownListrd_projno = (DropDownList)thisRow.Cells[2].FindControl("DropDownListrd_projno");

            DataSet ds = myrefd.Selectsyscd();
            DropDownListsys_nm.DataTextField = "sys_nm";
            DropDownListsys_nm.DataValueField = "sys_syscd";
            DropDownListsys_nm.DataSource = ds;
            DropDownListsys_nm.DataBind();
            DropDownListsys_nm.SelectedValue = DropDownListsys_nm.Items.FindByText(Labelsys_nm.Text).Value;

            DataSet dsrd_projno = myrefd.Selectproj();
            DropDownListrd_projno.DataTextField = "proj_projno";
            DropDownListrd_projno.DataValueField = "proj_projno";
            DropDownListrd_projno.DataSource = dsrd_projno;
            DropDownListrd_projno.DataBind();
            try
            {
                DropDownListrd_projno.SelectedValue = DropDownListrd_projno.Items.FindByText(Labelrd_projno.Text).Value;
            }
            catch
            {
                DropDownListrd_projno.SelectedIndex = 0;
            }

            TextBox TextBoxrd_costctr = (TextBox)thisRow.Cells[3].FindControl("TextBoxrd_costctr");
            TextBox TextBoxrd_accdcr = (TextBox)thisRow.Cells[4].FindControl("TextBoxrd_accdcr");
            TextBox TextBoxrd_descr = (TextBox)thisRow.Cells[5].FindControl("TextBoxrd_descr");

            Labelsys_nm.Visible = false;
            Labelrd_projno.Visible = false;
            Labelrd_costctr.Visible = false;
            Labelrd_accdcr.Visible = false;
            Labelrd_descr.Visible = false;

            DropDownListsys_nm.Visible = true;
            DropDownListrd_projno.Visible = true;
            TextBoxrd_costctr.Visible = true;
            TextBoxrd_accdcr.Visible = true;
            TextBoxrd_descr.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Sub_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[7].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[7].FindControl("CancelBtn");

            string bk_bkid = thisRow.Cells[0].Text;
            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelrd_projno = (Label)thisRow.Cells[2].FindControl("Labelrd_projno");
            Label Labelrd_costctr = (Label)thisRow.Cells[3].FindControl("Labelrd_costctr");
            Label Labelrd_accdcr = (Label)thisRow.Cells[4].FindControl("Labelrd_accdcr");
            Label Labelrd_descr = (Label)thisRow.Cells[5].FindControl("Labelrd_descr");

            DropDownList DropDownListsys_nm = (DropDownList)thisRow.Cells[1].FindControl("DropDownListsys_nm");
            DropDownList DropDownListrd_projno = (DropDownList)thisRow.Cells[2].FindControl("DropDownListrd_projno");
            TextBox TextBoxrd_costctr = (TextBox)thisRow.Cells[3].FindControl("TextBoxrd_costctr");
            TextBox TextBoxrd_accdcr = (TextBox)thisRow.Cells[4].FindControl("TextBoxrd_accdcr");
            TextBox TextBoxrd_descr = (TextBox)thisRow.Cells[5].FindControl("TextBoxrd_descr");


            //DataSet ds = myrefd.SelectPkeyDouble(DropDownListsys_nm.SelectedValue.ToString().Trim(), DropDownListrd_projno.SelectedValue.ToString().Trim());

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "系統代碼與計畫代號重複");
            //    return;
            //}

            myrefd.UpDaterefd(DropDownListsys_nm.SelectedValue.ToString().Trim(), DropDownListrd_projno.SelectedValue.ToString().Trim(),
                TextBoxrd_costctr.Text.Trim(), TextBoxrd_accdcr.Text.Trim(), TextBoxrd_descr.Text.Trim(), bk_bkid);


            Sub_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelsys_nm.Visible = true;
            Labelrd_projno.Visible = true;
            Labelrd_costctr.Visible = true;
            Labelrd_accdcr.Visible = true;
            Labelrd_descr.Visible = true;

            DropDownListsys_nm.Visible = false;
            DropDownListrd_projno.Visible = false;
            TextBoxrd_costctr.Visible = false;
            TextBoxrd_accdcr.Visible = false;
            TextBoxrd_descr.Visible = false;

            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料更新成功!");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Cancel_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[7].FindControl("SubBtn");
            Button btnEdit = (Button)thisRow.Cells[7].FindControl("btnEdit");

            Cancel_button.Visible = false;
            SubBtn.Visible = false;
            btnEdit.Visible = true;

            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelrd_projno = (Label)thisRow.Cells[2].FindControl("Labelrd_projno");
            Label Labelrd_costctr = (Label)thisRow.Cells[3].FindControl("Labelrd_costctr");
            Label Labelrd_accdcr = (Label)thisRow.Cells[4].FindControl("Labelrd_accdcr");
            Label Labelrd_descr = (Label)thisRow.Cells[5].FindControl("Labelrd_descr");

            DropDownList DropDownListsys_nm = (DropDownList)thisRow.Cells[1].FindControl("DropDownListsys_nm");
            DropDownList DropDownListrd_projno = (DropDownList)thisRow.Cells[2].FindControl("DropDownListrd_projno");
            TextBox TextBoxrd_costctr = (TextBox)thisRow.Cells[3].FindControl("TextBoxrd_costctr");
            TextBox TextBoxrd_accdcr = (TextBox)thisRow.Cells[4].FindControl("TextBoxrd_accdcr");
            TextBox TextBoxrd_descr = (TextBox)thisRow.Cells[5].FindControl("TextBoxrd_descr");

            Labelsys_nm.Visible = true;
            Labelrd_projno.Visible = true;
            Labelrd_costctr.Visible = true;
            Labelrd_accdcr.Visible = true;
            Labelrd_descr.Visible = true;

            DropDownListsys_nm.Visible = false;
            DropDownListrd_projno.Visible = false;
            TextBoxrd_costctr.Visible = false;
            TextBoxrd_accdcr.Visible = false;
            TextBoxrd_descr.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            myrefd.Deleterefd(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}