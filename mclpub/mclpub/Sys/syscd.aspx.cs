using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class syscd : System.Web.UI.Page
    {
        syscd_DB mysyscd = new syscd_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();

            }
        }

        public void BindGrid()
        {
            DataSet ds = mysyscd.Selectsyscd();
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

            Label Labelsys_syscd = (Label)thisRow.Cells[1].FindControl("Labelsys_syscd");
            Label Labelsys_nm = (Label)thisRow.Cells[2].FindControl("Labelsys_nm");
            Label Labelsys_deptcd = (Label)thisRow.Cells[2].FindControl("Labelsys_deptcd");

            TextBox TextBoxsys_syscd = (TextBox)thisRow.Cells[1].FindControl("TextBoxsys_syscd");
            TextBox TextBoxsys_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxsys_nm");
            TextBox TextBoxsys_deptcd = (TextBox)thisRow.Cells[2].FindControl("TextBoxsys_deptcd");

            Labelsys_syscd.Visible = false;
            Labelsys_nm.Visible = false;
            Labelsys_deptcd.Visible = false;

            TextBoxsys_syscd.Visible = true;
            TextBoxsys_syscd.Enabled = false;
            TextBoxsys_nm.Visible = true;
            TextBoxsys_deptcd.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button SubBtn_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;
            string itp_itpid = thisRow.Cells[0].Text.Trim();
            Label Labelsys_syscd = (Label)thisRow.Cells[1].FindControl("Labelsys_syscd");
            Label Labelsys_nm = (Label)thisRow.Cells[2].FindControl("Labelsys_nm");
            Label Labelsys_deptcd = (Label)thisRow.Cells[2].FindControl("Labelsys_deptcd");

            TextBox TextBoxsys_syscd = (TextBox)thisRow.Cells[1].FindControl("TextBoxsys_syscd");
            TextBox TextBoxsys_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxsys_nm");
            TextBox TextBoxsys_deptcd = (TextBox)thisRow.Cells[2].FindControl("TextBoxsys_deptcd");


            if (TextBoxsys_syscd.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "系統代碼不能為空值");
                return;
            }

            if (TextBoxsys_nm.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "系統代碼名稱不能為空值");
                return;
            }

            if (TextBoxsys_deptcd.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "部門代碼不能為空值");
                return;
            }

            //DataSet ds1 = mysyscd.Selectsyscd();

            //DataView dv = ds1.Tables[0].DefaultView;
            //string Strfilter = " 1=1 AND sys_syscd = '" + TextBoxsys_syscd.Text.Trim() + "'";

            //dv.RowFilter = Strfilter;

            //if (dv.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            //    return;
            //}

            mysyscd.Updatesyscd(TextBoxsys_syscd.Text.Trim(), TextBoxsys_nm.Text.Trim(), TextBoxsys_deptcd.Text.Trim(), itp_itpid);

            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelsys_syscd.Visible = true;
            Labelsys_nm.Visible = true;
            Labelsys_deptcd.Visible = true;

            TextBoxsys_syscd.Visible = false;
            TextBoxsys_nm.Visible = false;
            TextBoxsys_deptcd.Visible = false;

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

            Label Labelsys_syscd = (Label)thisRow.Cells[1].FindControl("Labelsys_syscd");
            Label Labelsys_nm = (Label)thisRow.Cells[2].FindControl("Labelsys_nm");
            Label Labelsys_deptcd = (Label)thisRow.Cells[2].FindControl("Labelsys_deptcd");

            TextBox TextBoxsys_syscd = (TextBox)thisRow.Cells[1].FindControl("TextBoxsys_syscd");
            TextBox TextBoxsys_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxsys_nm");
            TextBox TextBoxsys_deptcd = (TextBox)thisRow.Cells[2].FindControl("TextBoxsys_deptcd");

            Labelsys_syscd.Visible = true;
            Labelsys_nm.Visible = true;
            Labelsys_deptcd.Visible = true;

            TextBoxsys_syscd.Visible = false;
            TextBoxsys_nm.Visible = false;
            TextBoxsys_deptcd.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            mysyscd.Delsyscd(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}