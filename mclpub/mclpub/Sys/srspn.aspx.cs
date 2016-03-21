using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class srspn : System.Web.UI.Page
    {
        srspn_DB mysrspn = new srspn_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();

            }
        }

        private DataView BoundDataset()
        {
            DataSet ds = mysrspn.Selectsrspn();
            DataView dv = ds.Tables[0].DefaultView;
            string Keyword = TexTBoxKeyWord.Text.Trim();
            string STRfilter = "1=1 AND (srspn_empno LIKE '%"+Keyword.ToString()+"%' ";
            STRfilter += "OR srspn_cname LIKE '%" + Keyword.ToString() + "%' ";
            STRfilter += "OR srspn_tel LIKE '%" + Keyword.ToString() + "%' ";
            STRfilter += "OR srspn_atype LIKE '%" + Keyword.ToString() + "%' ";
            STRfilter += "OR srspn_orgcd LIKE '%" + Keyword.ToString() + "%' ";
            STRfilter += "OR srspn_deptcd LIKE '%" + Keyword.ToString() + "%' ) ";
            if (Keyword != "")
            {
                dv.RowFilter = STRfilter;
            }
            return dv;       
        }


        private void BindGrid()
        {
            DataTable dsddl = mysrspn.SelectSrspn_atype();
            this.ddlsrspn_atypeAdd.DataTextField = "name";
            this.ddlsrspn_atypeAdd.DataValueField = "value";
            this.ddlsrspn_atypeAdd.DataSource = dsddl;
            this.ddlsrspn_atypeAdd.DataBind();

            DataSet dsdd2 = mysrspn.SelectOrgCod();
            this.ddlOrgAbbNameAdd.DataTextField = "org_abbr_chnm1";
            this.ddlOrgAbbNameAdd.DataValueField = "org_orgcd";
            this.ddlOrgAbbNameAdd.DataSource = dsdd2;
            this.ddlOrgAbbNameAdd.DataBind();

            TextBoxsrspn_datedAdd.Text = DateTime.Now.ToString("yyyyMMdd");

            DataView dv = BoundDataset();
            UCPager1.Dtdata = dv.ToTable();
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

        protected void CheckBtn_Click(object sender, EventArgs e)
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

            Label Labelsrspn_empno = (Label)thisRow.Cells[1].FindControl("Labelsrspn_empno");
            Label Labelsrspn_cname = (Label)thisRow.Cells[2].FindControl("Labelsrspn_cname");
            Label Labelsrspn_tel = (Label)thisRow.Cells[3].FindControl("Labelsrspn_tel");
            Label Labelsrspn_atype = (Label)thisRow.Cells[4].FindControl("Labelsrspn_atype");
            Label LabelOrgAbbName = (Label)thisRow.Cells[5].FindControl("LabelOrgAbbName");
            Label Labelsrspn_deptcd = (Label)thisRow.Cells[6].FindControl("Labelsrspn_deptcd");
            Label Labelsrspn_date = (Label)thisRow.Cells[7].FindControl("Labelsrspn_date");
            

            TextBox TextBoxsrspn_empno = (TextBox)thisRow.Cells[1].FindControl("TextBoxsrspn_empno");
            TextBox TextBoxsrspn_cname = (TextBox)thisRow.Cells[2].FindControl("TextBoxsrspn_cname");
            TextBox TextBoxsrspn_tel = (TextBox)thisRow.Cells[3].FindControl("TextBoxsrspn_tel");
            DropDownList ddlsrspn_atype = (DropDownList)thisRow.Cells[4].FindControl("ddlsrspn_atype");
            DropDownList ddlOrgAbbName = (DropDownList)thisRow.Cells[5].FindControl("ddlOrgAbbName");
            TextBox TextBoxsrspn_deptcd = (TextBox)thisRow.Cells[6].FindControl("TextBoxsrspn_deptcd");
            TextBox TextBoxsrspn_dated = (TextBox)thisRow.Cells[7].FindControl("TextBoxsrspn_dated");
            Label Label1 = (Label)thisRow.Cells[7].FindControl("Label1");

            Labelsrspn_empno.Visible = false;
            Labelsrspn_cname.Visible = false;
            Labelsrspn_tel.Visible = false;
            Labelsrspn_atype.Visible = false;
            LabelOrgAbbName.Visible = false;
            Labelsrspn_deptcd.Visible = false;
            Labelsrspn_date.Visible = false;

            TextBoxsrspn_empno.Visible = true;
            TextBoxsrspn_cname.Visible = true;
            TextBoxsrspn_tel.Visible = true;
            ddlsrspn_atype.Visible = true;
            ddlOrgAbbName.Visible = true;
            TextBoxsrspn_deptcd.Visible = true;
            TextBoxsrspn_dated.Visible = true;
            Label1.Visible = true;

            DataTable dsddl = mysrspn.SelectSrspn_atype();
            ddlsrspn_atype.DataTextField = "name";
            ddlsrspn_atype.DataValueField = "value";
            ddlsrspn_atype.DataSource = dsddl;
            ddlsrspn_atype.DataBind();

            ddlsrspn_atype.SelectedValue = Labelsrspn_atype.Text.Trim();

            DataSet dsdd2 = mysrspn.SelectOrgCod();
            ddlOrgAbbName.DataTextField = "org_abbr_chnm1";
            ddlOrgAbbName.DataValueField = "org_orgcd";
            ddlOrgAbbName.DataSource = dsdd2;
            ddlOrgAbbName.DataBind();

            try
            {
                ddlOrgAbbName.SelectedValue = ddlOrgAbbName.Items.FindByText(LabelOrgAbbName.Text).Value.ToString();
            }
            catch
            {
                ddlOrgAbbName.SelectedIndex = 0;
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
            Label Labelsrspn_empno = (Label)thisRow.Cells[1].FindControl("Labelsrspn_empno");
            Label Labelsrspn_cname = (Label)thisRow.Cells[2].FindControl("Labelsrspn_cname");
            Label Labelsrspn_tel = (Label)thisRow.Cells[3].FindControl("Labelsrspn_tel");
            Label Labelsrspn_atype = (Label)thisRow.Cells[4].FindControl("Labelsrspn_atype");
            Label LabelOrgAbbName = (Label)thisRow.Cells[5].FindControl("LabelOrgAbbName");
            Label Labelsrspn_deptcd = (Label)thisRow.Cells[6].FindControl("Labelsrspn_deptcd");
            Label Labelsrspn_date = (Label)thisRow.Cells[7].FindControl("Labelsrspn_date");
            

            TextBox TextBoxsrspn_empno = (TextBox)thisRow.Cells[1].FindControl("TextBoxsrspn_empno");
            TextBoxsrspn_empno.Enabled = false;
            TextBox TextBoxsrspn_cname = (TextBox)thisRow.Cells[2].FindControl("TextBoxsrspn_cname");
            TextBox TextBoxsrspn_tel = (TextBox)thisRow.Cells[3].FindControl("TextBoxsrspn_tel");
            DropDownList ddlsrspn_atype = (DropDownList)thisRow.Cells[4].FindControl("ddlsrspn_atype");
            DropDownList ddlOrgAbbName = (DropDownList)thisRow.Cells[5].FindControl("ddlOrgAbbName");
            TextBox TextBoxsrspn_deptcd = (TextBox)thisRow.Cells[6].FindControl("TextBoxsrspn_deptcd");
            TextBox TextBoxsrspn_dated = (TextBox)thisRow.Cells[7].FindControl("TextBoxsrspn_dated");
            Label Label1 = (Label)thisRow.Cells[7].FindControl("Label1");

            if (TextBoxsrspn_empno.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "業務人員工號不能為空值");
                return;
            }
            else
            {
                if (TextBoxsrspn_empno.Text.Trim().Length != 6)
                {
                    JavaScript.AlertMessage(this.Page, "請輸入六位數字");
                    return;
                }
            }

            if (TextBoxsrspn_dated.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "業務人員註冊日不能為空值");
                return;
            }
            else
            {
                try
                {
                    int date = Convert.ToInt32(TextBoxsrspn_dated.Text.Trim());

                }
                catch(Exception ex)
                {
                    JavaScript.AlertMessage(this.Page, "業務人員註冊日請依範例格式輸入");
                    return;
                }
            }

            //DataSet ds1 = mysrspn.Selectsrspn();

            //DataView dv = ds1.Tables[0].DefaultView;
            //string Strfilter = " 1=1 AND srspn_empno = '" + TextBoxsrspn_empno.Text.Trim() + "'";

            //dv.RowFilter = Strfilter;

            //if (dv.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            //    return;
            //}

            mysrspn.Updatesrspn(TextBoxsrspn_empno.Text.Trim(), TextBoxsrspn_cname.Text.Trim(), TextBoxsrspn_tel.Text.Trim(), ddlsrspn_atype.SelectedValue.ToString().Trim(),
                ddlOrgAbbName.SelectedValue.ToString().Trim(), TextBoxsrspn_deptcd.Text.Trim(), TextBoxsrspn_dated.Text.Trim(), itp_itpid);

            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelsrspn_empno.Visible = true;
            Labelsrspn_cname.Visible = true;
            Labelsrspn_tel.Visible = true;
            Labelsrspn_atype.Visible = true;
            LabelOrgAbbName.Visible = true;
            Labelsrspn_deptcd.Visible = true;
            Labelsrspn_date.Visible = true;
            

            TextBoxsrspn_empno.Visible = false;
            TextBoxsrspn_cname.Visible = false;
            TextBoxsrspn_tel.Visible = false;
            ddlsrspn_atype.Visible = false;
            ddlOrgAbbName.Visible = false;
            TextBoxsrspn_deptcd.Visible = false;
            TextBoxsrspn_dated.Visible = false;
            Label1.Visible = false;

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

            Label Labelsrspn_empno = (Label)thisRow.Cells[1].FindControl("Labelsrspn_empno");
            Label Labelsrspn_cname = (Label)thisRow.Cells[2].FindControl("Labelsrspn_cname");
            Label Labelsrspn_tel = (Label)thisRow.Cells[3].FindControl("Labelsrspn_tel");
            Label Labelsrspn_atype = (Label)thisRow.Cells[4].FindControl("Labelsrspn_atype");
            Label LabelOrgAbbName = (Label)thisRow.Cells[5].FindControl("LabelOrgAbbName");
            Label Labelsrspn_deptcd = (Label)thisRow.Cells[6].FindControl("Labelsrspn_deptcd");
            Label Labelsrspn_date = (Label)thisRow.Cells[7].FindControl("Labelsrspn_date");
            

            TextBox TextBoxsrspn_empno = (TextBox)thisRow.Cells[1].FindControl("TextBoxsrspn_empno");
            TextBox TextBoxsrspn_cname = (TextBox)thisRow.Cells[2].FindControl("TextBoxsrspn_cname");
            TextBox TextBoxsrspn_tel = (TextBox)thisRow.Cells[3].FindControl("TextBoxsrspn_tel");
            DropDownList ddlsrspn_atype = (DropDownList)thisRow.Cells[4].FindControl("ddlsrspn_atype");
            DropDownList ddlOrgAbbName = (DropDownList)thisRow.Cells[5].FindControl("ddlOrgAbbName");
            TextBox TextBoxsrspn_deptcd = (TextBox)thisRow.Cells[6].FindControl("TextBoxsrspn_deptcd");
            TextBox TextBoxsrspn_dated = (TextBox)thisRow.Cells[7].FindControl("TextBoxsrspn_dated");
            Label Label1 = (Label)thisRow.Cells[7].FindControl("Label1");

            Labelsrspn_empno.Visible = true;
            Labelsrspn_cname.Visible = true;
            Labelsrspn_tel.Visible = true;
            Labelsrspn_atype.Visible = true;
            LabelOrgAbbName.Visible = true;
            Labelsrspn_deptcd.Visible = true;
            Labelsrspn_date.Visible = true;
            

            TextBoxsrspn_empno.Visible = false;
            TextBoxsrspn_cname.Visible = false;
            TextBoxsrspn_tel.Visible = false;
            ddlsrspn_atype.Visible = false;
            ddlOrgAbbName.Visible = false;
            TextBoxsrspn_deptcd.Visible = false;
            TextBoxsrspn_dated.Visible = false;
            Label1.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            mysrspn.Delsrspn(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}