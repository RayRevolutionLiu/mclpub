using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace mclpub.Sys
{
    public partial class proj : System.Web.UI.Page
    {
        proj_DB myproj = new proj_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "ContGV";
            if (!IsPostBack)
            {
                BindGrid();

                if (ContGV.Rows.Count > 0)
                {
                    SearchIcon.Visible = true;
                    UCPager1.Visible = true;
                }
                else
                {
                    SearchIcon.Visible = false;
                    UCPager1.Visible = false;
                }
            }
        }

        public void BindGrid()
        {
            DataTable dsddl = myproj.Selectsyscd();
            ddlsys_nm.DataTextField = "sys_nm";
            ddlsys_nm.DataValueField = "sys_syscd";
            ddlsys_nm.DataSource = dsddl;
            ddlsys_nm.DataBind();

            DataTable dsdd2 = myproj.Selectbook();
            DataRow dr = dsdd2.NewRow();
            dr["bk_nm"] = "請選擇";
            dr["bk_bkcd"] = "00";
            dsdd2.Rows.Add(dr);
            dsdd2.DefaultView.Sort = "bk_bkcd ASC";

            ddlbk_nm.DataTextField = "bk_nm";
            ddlbk_nm.DataValueField = "bk_bkcd";
            ddlbk_nm.DataSource = dsdd2;
            ddlbk_nm.DataBind();

            DataTable dsdd3 = myproj.Selectfgitri();
            ddlfgitri_nm.DataTextField = "fgitri_name";
            ddlfgitri_nm.DataValueField = "fgitri_fgitri";
            ddlfgitri_nm.DataSource = dsdd3;
            ddlfgitri_nm.DataBind();

            string STRtbxQString = "";
            if (tbxQString.Text.Trim() != "")
            {
                STRtbxQString = tbxQString.Text.Trim();
            }
            DataSet ds = myproj.SelectTitle(STRtbxQString, ddlQueryField.SelectedItem.Value.ToString().Trim());

            this.UCPager1.Dtdata = ds.Tables[0];
            this.UCPager1.UCPageBind();
        }


        protected void Query_Click(object sender, EventArgs e)
        {
            BindGrid();
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

            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelbk_nm = (Label)thisRow.Cells[2].FindControl("Labelbk_nm");
            Label Labelfgitri_nm = (Label)thisRow.Cells[3].FindControl("Labelfgitri_nm");
            Label Labelproj_projno = (Label)thisRow.Cells[4].FindControl("Labelproj_projno");
            Label Labelproj_costctr = (Label)thisRow.Cells[5].FindControl("Labelproj_costctr");
            Label Labelproj_cont = (Label)thisRow.Cells[6].FindControl("Labelproj_cont");

            DropDownList ddlsys_nm = (DropDownList)thisRow.Cells[1].FindControl("ddlsys_nm");
            DropDownList ddlbk_nm = (DropDownList)thisRow.Cells[2].FindControl("ddlbk_nm");
            DropDownList ddlfgitri_nm = (DropDownList)thisRow.Cells[3].FindControl("ddlfgitri_nm");
            TextBox TextBoxproj_projno = (TextBox)thisRow.Cells[4].FindControl("TextBoxproj_projno");
            TextBox TextBoxproj_costctr = (TextBox)thisRow.Cells[5].FindControl("TextBoxproj_costctr");
            TextBox TextBoxproj_cont = (TextBox)thisRow.Cells[6].FindControl("TextBoxproj_cont");

            Labelsys_nm.Visible = false;
            Labelbk_nm.Visible = false;
            Labelfgitri_nm.Visible = false;
            Labelproj_projno.Visible = false;
            Labelproj_costctr.Visible = false;
            Labelproj_cont.Visible = false;

            ddlsys_nm.Visible = true;
            ddlbk_nm.Visible = true;
            ddlfgitri_nm.Visible = true;
            TextBoxproj_projno.Visible = true;
            TextBoxproj_costctr.Visible = true;
            TextBoxproj_cont.Visible = true;

            DataTable dsddl = myproj.Selectsyscd();
            ddlsys_nm.DataTextField = "sys_nm";
            ddlsys_nm.DataValueField = "sys_syscd";
            ddlsys_nm.DataSource = dsddl;
            ddlsys_nm.DataBind();

            try
            {
                ddlsys_nm.SelectedValue = ddlsys_nm.Items.FindByText(Labelsys_nm.Text).Value.ToString();
            }
            catch
            {
                ddlsys_nm.SelectedIndex = 0;
            }

            DataTable dsdd2 = myproj.Selectbook();
            DataRow dr = dsdd2.NewRow();
            dr["bk_nm"] = "請選擇";
            dr["bk_bkcd"] = "00";
            dsdd2.Rows.Add(dr);
            dsdd2.DefaultView.Sort = "bk_bkcd ASC";

            ddlbk_nm.DataTextField = "bk_nm";
            ddlbk_nm.DataValueField = "bk_bkcd";
            ddlbk_nm.DataSource = dsdd2;
            ddlbk_nm.DataBind();

            try
            {
                ddlbk_nm.SelectedValue = ddlbk_nm.Items.FindByText(Labelbk_nm.Text).Value.ToString();
            }
            catch
            {
                ddlbk_nm.SelectedIndex = 0;
            }

            DataTable dsdd3 = myproj.Selectfgitri();
            ddlfgitri_nm.DataTextField = "fgitri_name";
            ddlfgitri_nm.DataValueField = "fgitri_fgitri";
            ddlfgitri_nm.DataSource = dsdd3;
            ddlfgitri_nm.DataBind();

            try
            {
                ddlfgitri_nm.SelectedValue = ddlfgitri_nm.Items.FindByText(Labelfgitri_nm.Text).Value.ToString();
            }
            catch
            {
                ddlfgitri_nm.SelectedIndex = 0;
            }
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
            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelbk_nm = (Label)thisRow.Cells[2].FindControl("Labelbk_nm");
            Label Labelfgitri_nm = (Label)thisRow.Cells[3].FindControl("Labelfgitri_nm");
            Label Labelproj_projno = (Label)thisRow.Cells[4].FindControl("Labelproj_projno");
            Label Labelproj_costctr = (Label)thisRow.Cells[5].FindControl("Labelproj_costctr");
            Label Labelproj_cont = (Label)thisRow.Cells[6].FindControl("Labelproj_cont");

            DropDownList ddlsys_nm = (DropDownList)thisRow.Cells[1].FindControl("ddlsys_nm");
            DropDownList ddlbk_nm = (DropDownList)thisRow.Cells[2].FindControl("ddlbk_nm");
            DropDownList ddlfgitri_nm = (DropDownList)thisRow.Cells[3].FindControl("ddlfgitri_nm");
            TextBox TextBoxproj_projno = (TextBox)thisRow.Cells[4].FindControl("TextBoxproj_projno");
            TextBox TextBoxproj_costctr = (TextBox)thisRow.Cells[5].FindControl("TextBoxproj_costctr");
            TextBox TextBoxproj_cont = (TextBox)thisRow.Cells[6].FindControl("TextBoxproj_cont");

            if (ddlsys_nm.SelectedValue.ToString().Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "系統代碼名稱不能為空值");
                return;
            }
            if (TextBoxproj_projno.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "計畫代號不能為空值");
                return;
            }

            ////DataSet ds1 = mysrspn.Selectsrspn();

            ////DataView dv = ds1.Tables[0].DefaultView;
            ////string Strfilter = " 1=1 AND srspn_empno = '" + TextBoxsrspn_empno.Text.Trim() + "'";

            ////dv.RowFilter = Strfilter;

            ////if (dv.Count > 0)
            ////{
            ////    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            ////    return;
            ////}

            myproj.Updateproj(ddlsys_nm.SelectedValue.ToString(), ddlbk_nm.SelectedValue.ToString(), ddlfgitri_nm.SelectedValue.ToString(), TextBoxproj_projno.Text.Trim(),
                TextBoxproj_costctr.Text.Trim(), TextBoxproj_cont.Text.Trim(), itp_itpid);

            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelsys_nm.Visible = true;
            Labelbk_nm.Visible = true;
            Labelfgitri_nm.Visible = true;
            Labelproj_projno.Visible  = true;
            Labelproj_costctr.Visible = true;
            Labelproj_cont.Visible = true;

            ddlsys_nm.Visible = false;
            ddlbk_nm.Visible = false;
            ddlfgitri_nm.Visible = false;
            TextBoxproj_projno.Visible = false;
            TextBoxproj_costctr.Visible = false;
            TextBoxproj_cont.Visible = false;

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

            Label Labelsys_nm = (Label)thisRow.Cells[1].FindControl("Labelsys_nm");
            Label Labelbk_nm = (Label)thisRow.Cells[2].FindControl("Labelbk_nm");
            Label Labelfgitri_nm = (Label)thisRow.Cells[3].FindControl("Labelfgitri_nm");
            Label Labelproj_projno = (Label)thisRow.Cells[4].FindControl("Labelproj_projno");
            Label Labelproj_costctr = (Label)thisRow.Cells[5].FindControl("Labelproj_costctr");
            Label Labelproj_cont = (Label)thisRow.Cells[6].FindControl("Labelproj_cont");

            DropDownList ddlsys_nm = (DropDownList)thisRow.Cells[1].FindControl("ddlsys_nm");
            DropDownList ddlbk_nm = (DropDownList)thisRow.Cells[2].FindControl("ddlbk_nm");
            DropDownList ddlfgitri_nm = (DropDownList)thisRow.Cells[3].FindControl("ddlfgitri_nm");
            TextBox TextBoxproj_projno = (TextBox)thisRow.Cells[4].FindControl("TextBoxproj_projno");
            TextBox TextBoxproj_costctr = (TextBox)thisRow.Cells[5].FindControl("TextBoxproj_costctr");
            TextBox TextBoxproj_cont = (TextBox)thisRow.Cells[6].FindControl("TextBoxproj_cont");

            Labelsys_nm.Visible = true;
            Labelbk_nm.Visible = true;
            Labelfgitri_nm.Visible = true;
            Labelproj_projno.Visible = true;
            Labelproj_costctr.Visible = true;
            Labelproj_cont.Visible = true;

            ddlsys_nm.Visible = false;
            ddlbk_nm.Visible = false;
            ddlfgitri_nm.Visible = false;
            TextBoxproj_projno.Visible = false;
            TextBoxproj_costctr.Visible = false;
            TextBoxproj_cont.Visible = false;;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[0].Text;

            myproj.Deleteproj(ide);
            BindGrid();

            JavaScript.AlertMessage(this.Page, "資料刪除成功 !");
        }

        protected void ContGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }
        }
    }
}