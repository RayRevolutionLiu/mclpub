using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class bookp : System.Web.UI.Page
    {
        bookp_DB myBook = new bookp_DB();

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
            DataSet dsddl = myBook.ddlSelectAllBooks();
            this.ddlbkp_bkcd.DataTextField = "bk_nm";
            this.ddlbkp_bkcd.DataValueField = "bk_bkcd";
            this.ddlbkp_bkcd.DataSource = dsddl;
            this.ddlbkp_bkcd.DataBind();

            DataSet ds = myBook.Selectbookp();
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

        protected void GVEdit_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)//如果第一次點選排序的話，預設就是「升」
            {
                ViewState["SortDirection"] = " ASC";
            }
            //判斷如果已經對某欄位排序過，再判斷是否針對同個欄位排序
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                //如果針對同個欄位排序，則進行「升」「降」的切換
                if (ViewState["SortDirection"].ToString() == " DESC")
                    ViewState["SortDirection"] = " ASC";
                else
                    ViewState["SortDirection"] = " DESC";

            }
            else
            {
                //第一次對某欄位排序，就是「升」
                ViewState["SortDirection"] = " ASC";
            }

            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
            }
            int Columns_i = 0;
            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                if (e.SortExpression == ((GridView)sender).Columns[i].SortExpression)
                {
                    Columns_i = i;
                    if (ViewState["SortDirection"].ToString() == " DESC")
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
                    }
                    else
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
                    }
                }
            }

            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱


            DataSet ds = myBook.Selectbookp();
            DataTable dt = ds.Tables[0];

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = dt.DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            this.UCPager1.Dtdata = dv.ToTable();
            this.UCPager1.UCPageBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Edit_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[4].FindControl("SubBtn");
            Button CancelBtn = (Button)thisRow.Cells[4].FindControl("CancelBtn");

            Edit_button.Visible = false;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;

            Label Labelbk_nm = (Label)thisRow.Cells[1].FindControl("Labelbk_nm");
            Label Labelbkp_date = (Label)thisRow.Cells[2].FindControl("Labelbkp_date");
            Label Labelbkp_pno = (Label)thisRow.Cells[3].FindControl("Labelbkp_pno");

            DropDownList TextBoxbk_nm = (DropDownList)thisRow.Cells[1].FindControl("TextBoxbk_nm");
            TextBox TextBoxbkp_date = (TextBox)thisRow.Cells[2].FindControl("TextBoxbkp_date");
            TextBox TextBoxbkp_pno = (TextBox)thisRow.Cells[3].FindControl("TextBoxbkp_pno");

            DataSet dsddl = myBook.ddlSelectAllBooks();
            TextBoxbk_nm.DataTextField = "bk_nm";
            TextBoxbk_nm.DataValueField = "bk_bkcd";
            TextBoxbk_nm.DataSource = dsddl;
            TextBoxbk_nm.DataBind();

            TextBoxbk_nm.SelectedValue = TextBoxbk_nm.Items.FindByText(Labelbk_nm.Text).Value.ToString();

            Labelbk_nm.Visible = false;
            Labelbkp_date.Visible = false;
            Labelbkp_pno.Visible = false;

            TextBoxbk_nm.Visible = true;
            TextBoxbkp_date.Visible = true;
            TextBoxbkp_pno.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Sub_button = (Button)sender;
            Button Editbtn = (Button)thisRow.Cells[4].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[4].FindControl("CancelBtn");

            string bkp_bkpid = thisRow.Cells[0].Text.Trim();
            Label Labelbk_nm = (Label)thisRow.Cells[1].FindControl("Labelbk_nm");
            Label Labelbkp_date = (Label)thisRow.Cells[2].FindControl("Labelbkp_date");
            Label Labelbkp_pno = (Label)thisRow.Cells[3].FindControl("Labelbkp_pno");

            DropDownList TextBoxbk_nm = (DropDownList)thisRow.Cells[1].FindControl("TextBoxbk_nm");
            TextBox TextBoxbkp_date = (TextBox)thisRow.Cells[2].FindControl("TextBoxbkp_date");
            TextBox TextBoxbkp_pno = (TextBox)thisRow.Cells[3].FindControl("TextBoxbkp_pno");


            if (TextBoxbkp_date.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "書籍出版年月不能為空值");
                return;
            }

            if (TextBoxbkp_pno.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "書籍期別不能為空值");
                return;
            }

            DataSet ds1 = myBook.Selectbookp();

            DataView dv = ds1.Tables[0].DefaultView;
            string Strfilter = " 1=1 AND bkp_bkcd = '" + TextBoxbk_nm.SelectedValue.ToString() + "' AND bkp_date = '" + TextBoxbkp_date.Text.Trim() + "' AND bkp_pno='" + TextBoxbkp_pno.Text.Trim() + "'";

            dv.RowFilter = Strfilter;

            if (dv.Count > 0)
            {
                JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
                return;
            }

            myBook.Updatebook(bkp_bkpid, TextBoxbk_nm.SelectedValue.ToString(), TextBoxbkp_date.Text, TextBoxbkp_pno.Text);

            Sub_button.Visible = false;
            Editbtn.Visible = true;
            CancelBtn.Visible = false;

            Labelbk_nm.Visible = true;
            Labelbkp_date.Visible = true;
            Labelbkp_pno.Visible = true;

            TextBoxbk_nm.Visible = false;
            TextBoxbkp_date.Visible = false;
            TextBoxbkp_pno.Visible = false;

            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料更新成功!");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Cancel_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[4].FindControl("SubBtn");
            Button editbtn = (Button)thisRow.Cells[4].FindControl("btnEdit");

            Cancel_button.Visible = false;
            editbtn.Visible = true;
            SubBtn.Visible = false;

            Label Labelbk_nm = (Label)thisRow.Cells[1].FindControl("Labelbk_nm");
            Label Labelbkp_date = (Label)thisRow.Cells[2].FindControl("Labelbkp_date");
            Label Labelbkp_pno = (Label)thisRow.Cells[3].FindControl("Labelbkp_pno");

            DropDownList TextBoxbk_nm = (DropDownList)thisRow.Cells[1].FindControl("TextBoxbk_nm");
            TextBox TextBoxbkp_date = (TextBox)thisRow.Cells[2].FindControl("TextBoxbkp_date");
            TextBox TextBoxbkp_pno = (TextBox)thisRow.Cells[3].FindControl("TextBoxbkp_pno");

            Labelbk_nm.Visible = true;
            Labelbkp_date.Visible = true;
            Labelbkp_pno.Visible = true;

            TextBoxbk_nm.Visible = false;
            TextBoxbkp_date.Visible = false;
            TextBoxbkp_pno.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            myBook.Delbook(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}