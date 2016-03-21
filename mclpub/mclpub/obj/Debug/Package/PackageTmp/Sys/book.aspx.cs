using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class book : System.Web.UI.Page
    {
        book_DB myBook = new book_DB();

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
            DataSet ds = myBook.Selectbook();
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

            Label Labelbk_nm = (Label)thisRow.Cells[1].FindControl("Labelbk_bkcd");
            Label Labellp_priorseq = (Label)thisRow.Cells[2].FindControl("Labelbk_nm");

            TextBox TextBoxbk_nm = (TextBox)thisRow.Cells[1].FindControl("TextBoxbk_bkcd");
            TextBox TextBoxlp_priorseq = (TextBox)thisRow.Cells[2].FindControl("TextBoxbk_nm");

            Labelbk_nm.Visible = false;
            Labellp_priorseq.Visible = false;

            TextBoxbk_nm.Visible = true;
            TextBoxlp_priorseq.Visible = true;

        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Sub_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            Sub_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            string bk_bkid = thisRow.Cells[0].Text;
            Label Labelbk_nm = (Label)thisRow.Cells[1].FindControl("Labelbk_bkcd");
            Label Labellp_priorseq = (Label)thisRow.Cells[2].FindControl("Labelbk_nm");

            TextBox TextBoxbk_nm = (TextBox)thisRow.Cells[1].FindControl("TextBoxbk_bkcd");
            TextBox TextBoxlp_priorseq = (TextBox)thisRow.Cells[2].FindControl("TextBoxbk_nm");

            myBook.Updatebook(bk_bkid, TextBoxbk_nm.Text.Trim(), TextBoxlp_priorseq.Text.Trim());


            Labelbk_nm.Visible = true;
            Labellp_priorseq.Visible = true;

            TextBoxbk_nm.Visible = false;
            TextBoxlp_priorseq.Visible = false;

            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料更新成功!");
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button Cancel_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");

            Cancel_button.Visible = false;
            SubBtn.Visible = false;
            btnEdit.Visible = true;

            Label Labelbk_nm = (Label)thisRow.Cells[1].FindControl("Labelbk_bkcd");
            Label Labellp_priorseq = (Label)thisRow.Cells[2].FindControl("Labelbk_nm");

            TextBox TextBoxbk_nm = (TextBox)thisRow.Cells[1].FindControl("TextBoxbk_bkcd");
            TextBox TextBoxlp_priorseq = (TextBox)thisRow.Cells[2].FindControl("TextBoxbk_nm");

            Labelbk_nm.Visible = true;
            Labellp_priorseq.Visible = true;

            TextBoxbk_nm.Visible = false;
            TextBoxlp_priorseq.Visible = false;
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