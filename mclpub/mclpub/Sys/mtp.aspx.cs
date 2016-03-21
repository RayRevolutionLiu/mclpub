using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class mtp : System.Web.UI.Page
    {
        mtp_DB mymtp = new mtp_DB();

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
            DataSet ds = mymtp.Selectmtp();
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

            Label Labelmtp_mtpcd = (Label)thisRow.Cells[1].FindControl("Labelmtp_mtpcd");
            Label Labelmtp_nm = (Label)thisRow.Cells[2].FindControl("Labelmtp_nm");

            TextBox TextBoxmtp_mtpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxmtp_mtpcd");
            TextBox TextBoxmtp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxmtp_nm");

            Labelmtp_mtpcd.Visible = false;
            Labelmtp_nm.Visible = false;

            TextBoxmtp_mtpcd.Visible = true;
            TextBoxmtp_nm.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button SubBtn_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            string itp_itpid = thisRow.Cells[0].Text.Trim();
            Label Labelmtp_mtpcd = (Label)thisRow.Cells[1].FindControl("Labelmtp_mtpcd");
            Label Labelmtp_nm = (Label)thisRow.Cells[2].FindControl("Labelmtp_nm");

            TextBox TextBoxmtp_mtpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxmtp_mtpcd");
            TextBox TextBoxmtp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxmtp_nm");


            if (TextBoxmtp_mtpcd.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "郵寄類別代碼不能為空值");
                return;
            }

            if (TextBoxmtp_nm.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "郵寄類別名稱不能為空值");
                return;
            }

            //DataSet ds1 = mymtp.Selectmtp();

            //DataView dv = ds1.Tables[0].DefaultView;
            //string Strfilter = " 1=1 AND mtp_mtpcd = '" + TextBoxmtp_mtpcd.Text.Trim() + "'";

            //dv.RowFilter = Strfilter;

            //if (dv.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            //    return;
            //}

            mymtp.Updatemtp(TextBoxmtp_mtpcd.Text.Trim(), TextBoxmtp_nm.Text.Trim(), itp_itpid);


            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;


            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelmtp_mtpcd.Visible = true;
            Labelmtp_nm.Visible = true;

            TextBoxmtp_mtpcd.Visible = false;
            TextBoxmtp_nm.Visible = false;

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

            Label Labelmtp_mtpcd = (Label)thisRow.Cells[1].FindControl("Labelmtp_mtpcd");
            Label Labelmtp_nm = (Label)thisRow.Cells[2].FindControl("Labelmtp_nm");

            TextBox TextBoxmtp_mtpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxmtp_mtpcd");
            TextBox TextBoxmtp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxmtp_nm");

            Labelmtp_mtpcd.Visible = true;
            Labelmtp_nm.Visible = true;

            TextBoxmtp_mtpcd.Visible = false;
            TextBoxmtp_nm.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            mymtp.Delmtp(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}