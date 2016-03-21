using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class btp : System.Web.UI.Page
    {
        btp_DB myitp = new btp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();

                string strAssignedContNo = "";
                DataSet ds = myitp.OutPutMaxValue();
                DataView dv = ds.Tables[0].DefaultView;

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

                TextBoxbtp_btpcd.Text = strAssignedContNo;
            }
        }

        public void BindGrid()
        {
            DataSet ds = myitp.Selectbtp();
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

            Label Labelitp_itpcd = (Label)thisRow.Cells[1].FindControl("Labelbtp_btpcd");
            Label Labelitp_nm = (Label)thisRow.Cells[2].FindControl("Labelbtp_nm");

            TextBox TextBoxitp_itpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxbtp_btpcd");
            TextBox TextBoxitp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxbtp_nm");

            Labelitp_itpcd.Visible = false;
            Labelitp_nm.Visible = false;

            TextBoxitp_itpcd.Visible = true;
            TextBoxitp_nm.Visible = true;
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
            Label Labelitp_itpcd = (Label)thisRow.Cells[1].FindControl("Labelbtp_btpcd");
            Label Labelitp_nm = (Label)thisRow.Cells[2].FindControl("Labelbtp_nm");

            TextBox TextBoxitp_itpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxbtp_btpcd");
            TextBox TextBoxitp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxbtp_nm");


            if (TextBoxitp_itpcd.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "領域代碼不能為空值");
                return;
            }

            if (TextBoxitp_nm.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "領域代碼名稱不能為空值");
                return;
            }

            //DataSet ds1 = myitp.Selectbtp();

            //DataView dv = ds1.Tables[0].DefaultView;
            //string Strfilter = " 1=1 AND btp_btpcd = '" + TextBoxitp_itpcd.Text.Trim() + "'";

            //dv.RowFilter = Strfilter;

            //if (dv.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            //    return;
            //}

            myitp.Updatebtp(TextBoxitp_itpcd.Text.Trim(), TextBoxitp_nm.Text.Trim(), itp_itpid);

            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelitp_itpcd.Visible = true;
            Labelitp_nm.Visible = true;

            TextBoxitp_itpcd.Visible = false;
            TextBoxitp_nm.Visible = false;

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

            Label Labelitp_itpcd = (Label)thisRow.Cells[1].FindControl("Labelbtp_btpcd");
            Label Labelitp_nm = (Label)thisRow.Cells[2].FindControl("Labelbtp_nm");

            TextBox TextBoxitp_itpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxbtp_btpcd");
            TextBox TextBoxitp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxbtp_nm");

            Labelitp_itpcd.Visible = true;
            Labelitp_nm.Visible = true;

            TextBoxitp_itpcd.Visible = false;
            TextBoxitp_nm.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            myitp.Delbtp(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}