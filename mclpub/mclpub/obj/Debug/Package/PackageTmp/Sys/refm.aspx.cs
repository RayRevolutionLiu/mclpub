using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class refm : System.Web.UI.Page
    {
        refm_DB myrefm = new refm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();

                DataSet ds = myrefm.Selectsyscd();
                ddlrm_syscd.DataTextField = "sys_nm";
                ddlrm_syscd.DataValueField = "sys_syscd";
                ddlrm_syscd.DataSource = ds;
                ddlrm_syscd.DataBind();
            }
        }

        public void BindGrid()
        {
            DataSet ds = myrefm.Selectrefm();
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
            Button SubBtn = (Button)thisRow.Cells[8].FindControl("SubBtn");
            Button CancelBtn = (Button)thisRow.Cells[8].FindControl("CancelBtn");

            Edit_button.Visible = false;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;

            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelrm_remark = (Label)thisRow.Cells[2].FindControl("Labelrm_remark");
            Label Labelrm_deptcd = (Label)thisRow.Cells[3].FindControl("Labelrm_deptcd");
            Label Labelrm_accddr = (Label)thisRow.Cells[4].FindControl("Labelrm_accddr");
            Label Labelrm_idescr = (Label)thisRow.Cells[5].FindControl("Labelrm_idescr");
            Label Labelrm_iunit = (Label)thisRow.Cells[6].FindControl("Labelrm_iunit");
            Label Labelrm_iremark = (Label)thisRow.Cells[7].FindControl("Labelrm_iremark");

            DropDownList DropDownListsys_nm = (DropDownList)thisRow.Cells[1].FindControl("DropDownListsys_nm");
            DataSet ds = myrefm.Selectsyscd();
            DropDownListsys_nm.DataTextField = "sys_nm";
            DropDownListsys_nm.DataValueField = "sys_syscd";
            DropDownListsys_nm.DataSource = ds;
            DropDownListsys_nm.DataBind();
            DropDownListsys_nm.SelectedValue = DropDownListsys_nm.Items.FindByText(Labelsys_nm.Text).Value;

            TextBox TextBoxrm_remark = (TextBox)thisRow.Cells[2].FindControl("TextBoxrm_remark");
            TextBox TextBoxrm_deptcd = (TextBox)thisRow.Cells[3].FindControl("TextBoxrm_deptcd");
            TextBox TextBoxrm_accddr = (TextBox)thisRow.Cells[4].FindControl("TextBoxrm_accddr");
            TextBox TextBoxrm_idescr = (TextBox)thisRow.Cells[5].FindControl("TextBoxrm_idescr");
            TextBox TextBoxrm_iunit = (TextBox)thisRow.Cells[6].FindControl("TextBoxrm_iunit");
            TextBox TextBoxrm_iremark = (TextBox)thisRow.Cells[7].FindControl("TextBoxrm_iremark");

            Labelsys_nm.Visible = false;
            Labelrm_remark.Visible = false;
            Labelrm_deptcd.Visible  = false;
            Labelrm_accddr.Visible  = false;
            Labelrm_idescr.Visible  = false;
            Labelrm_iunit.Visible = false;
            Labelrm_iremark.Visible = false;

            DropDownListsys_nm.Visible = true;
            TextBoxrm_remark.Visible  = true;
            TextBoxrm_deptcd.Visible  = true;
            TextBoxrm_accddr.Visible  = true;
            TextBoxrm_idescr.Visible  = true;
            TextBoxrm_iunit.Visible = true;
            TextBoxrm_iremark.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Sub_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[8].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[8].FindControl("CancelBtn");

            string bk_bkid = thisRow.Cells[0].Text;
            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelrm_remark = (Label)thisRow.Cells[2].FindControl("Labelrm_remark");
            Label Labelrm_deptcd = (Label)thisRow.Cells[3].FindControl("Labelrm_deptcd");
            Label Labelrm_accddr = (Label)thisRow.Cells[4].FindControl("Labelrm_accddr");
            Label Labelrm_idescr = (Label)thisRow.Cells[5].FindControl("Labelrm_idescr");
            Label Labelrm_iunit = (Label)thisRow.Cells[6].FindControl("Labelrm_iunit");
            Label Labelrm_iremark = (Label)thisRow.Cells[7].FindControl("Labelrm_iremark");

            DropDownList DropDownListsys_nm = (DropDownList)thisRow.Cells[1].FindControl("DropDownListsys_nm");
            TextBox TextBoxrm_remark = (TextBox)thisRow.Cells[2].FindControl("TextBoxrm_remark");
            TextBox TextBoxrm_deptcd = (TextBox)thisRow.Cells[3].FindControl("TextBoxrm_deptcd");
            TextBox TextBoxrm_accddr = (TextBox)thisRow.Cells[4].FindControl("TextBoxrm_accddr");
            TextBox TextBoxrm_idescr = (TextBox)thisRow.Cells[5].FindControl("TextBoxrm_idescr");
            TextBox TextBoxrm_iunit = (TextBox)thisRow.Cells[6].FindControl("TextBoxrm_iunit");
            TextBox TextBoxrm_iremark = (TextBox)thisRow.Cells[7].FindControl("TextBoxrm_iremark");


            //DataSet ds = myrefm.SelectREFM_syscd(DropDownListsys_nm.SelectedValue.ToString());

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "系統代號重複");
            //    return;
            //}

            myrefm.UpDaterefm(bk_bkid, DropDownListsys_nm.SelectedValue.ToString(), TextBoxrm_remark.Text.Trim(), TextBoxrm_deptcd.Text.Trim(),
                TextBoxrm_accddr.Text.Trim(), TextBoxrm_idescr.Text.Trim(), TextBoxrm_iunit.Text.Trim(), TextBoxrm_iremark.Text.Trim());


            Sub_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelsys_nm.Visible = true;
            Labelrm_remark.Visible = true;
            Labelrm_deptcd.Visible = true;
            Labelrm_accddr.Visible = true;
            Labelrm_idescr.Visible = true;
            Labelrm_iunit.Visible = true;
            Labelrm_iremark.Visible = true;

            DropDownListsys_nm.Visible = false;
            TextBoxrm_remark.Visible = false;
            TextBoxrm_deptcd.Visible = false;
            TextBoxrm_accddr.Visible = false;
            TextBoxrm_idescr.Visible = false;
            TextBoxrm_iunit.Visible = false;
            TextBoxrm_iremark.Visible = false;

            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料更新成功!");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Cancel_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[8].FindControl("SubBtn");
            Button btnEdit = (Button)thisRow.Cells[8].FindControl("btnEdit");

            Cancel_button.Visible = false;
            SubBtn.Visible = false;
            btnEdit.Visible = true;

            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelrm_remark = (Label)thisRow.Cells[2].FindControl("Labelrm_remark");
            Label Labelrm_deptcd = (Label)thisRow.Cells[3].FindControl("Labelrm_deptcd");
            Label Labelrm_accddr = (Label)thisRow.Cells[4].FindControl("Labelrm_accddr");
            Label Labelrm_idescr = (Label)thisRow.Cells[5].FindControl("Labelrm_idescr");
            Label Labelrm_iunit = (Label)thisRow.Cells[6].FindControl("Labelrm_iunit");
            Label Labelrm_iremark = (Label)thisRow.Cells[7].FindControl("Labelrm_iremark");

            DropDownList DropDownListsys_nm = (DropDownList)thisRow.Cells[1].FindControl("DropDownListsys_nm");
            TextBox TextBoxrm_remark = (TextBox)thisRow.Cells[2].FindControl("TextBoxrm_remark");
            TextBox TextBoxrm_deptcd = (TextBox)thisRow.Cells[3].FindControl("TextBoxrm_deptcd");
            TextBox TextBoxrm_accddr = (TextBox)thisRow.Cells[4].FindControl("TextBoxrm_accddr");
            TextBox TextBoxrm_idescr = (TextBox)thisRow.Cells[5].FindControl("TextBoxrm_idescr");
            TextBox TextBoxrm_iunit = (TextBox)thisRow.Cells[6].FindControl("TextBoxrm_iunit");
            TextBox TextBoxrm_iremark = (TextBox)thisRow.Cells[7].FindControl("TextBoxrm_iremark");

            Labelsys_nm.Visible = true;
            Labelrm_remark.Visible = true;
            Labelrm_deptcd.Visible = true;
            Labelrm_accddr.Visible = true;
            Labelrm_idescr.Visible = true;
            Labelrm_iunit.Visible = true;
            Labelrm_iremark.Visible = true;

            DropDownListsys_nm.Visible = false;
            TextBoxrm_remark.Visible = false;
            TextBoxrm_deptcd.Visible = false;
            TextBoxrm_accddr.Visible = false;
            TextBoxrm_idescr.Visible = false;
            TextBoxrm_iunit.Visible = false;
            TextBoxrm_iremark.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            myrefm.Deleterefm(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}