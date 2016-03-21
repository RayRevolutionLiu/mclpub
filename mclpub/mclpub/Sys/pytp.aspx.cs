using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class pytp : System.Web.UI.Page
    {
        pytp_DB mypytp = new pytp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();
                string strAssignedContNo = "";
                DataSet ds = mypytp.OutPutMaxValue();
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

                TextBoxpytp_pytpcd.Text = strAssignedContNo;
            }
        }

        public void BindGrid()
        {
            DataSet ds = mypytp.Selectpytp();
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

            Label Labelpytp_pytpcd = (Label)thisRow.Cells[1].FindControl("Labelpytp_pytpcd");
            Label Labelpytp_nm = (Label)thisRow.Cells[2].FindControl("Labelpytp_nm");

            TextBox TextBoxpytp_pytpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxpytp_pytpcd");
            TextBox TextBoxpytp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxpytp_nm");

            Labelpytp_pytpcd.Visible = false;
            Labelpytp_nm.Visible = false;

            TextBoxpytp_pytpcd.Visible = true;
            TextBoxpytp_nm.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button SubBtn_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            string itp_itpid = thisRow.Cells[0].Text.Trim();
            Label Labelpytp_pytpcd = (Label)thisRow.Cells[1].FindControl("Labelpytp_pytpcd");
            Label Labelpytp_nm = (Label)thisRow.Cells[2].FindControl("Labelpytp_nm");

            TextBox TextBoxpytp_pytpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxpytp_pytpcd");
            TextBox TextBoxpytp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxpytp_nm");


            if (TextBoxpytp_pytpcd.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "付款方式代碼不能為空值");
                return;
            }

            if (TextBoxpytp_nm.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "付款方式名稱不能為空值");
                return;
            }

            //DataSet ds1 = mypytp.Selectpytp();

            //DataView dv = ds1.Tables[0].DefaultView;
            //string Strfilter = " 1=1 AND pytp_pytpcd = '" + TextBoxpytp_pytpcd.Text.Trim() + "'";

            //dv.RowFilter = Strfilter;

            //if (dv.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            //    return;
            //}

            mypytp.Updatepytp(TextBoxpytp_pytpcd.Text.Trim(), TextBoxpytp_nm.Text.Trim(), itp_itpid);


            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;


            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelpytp_pytpcd.Visible = true;
            Labelpytp_nm.Visible = true;

            TextBoxpytp_pytpcd.Visible = false;
            TextBoxpytp_nm.Visible = false;

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

            Label Labelpytp_pytpcd = (Label)thisRow.Cells[1].FindControl("Labelpytp_pytpcd");
            Label Labelpytp_nm = (Label)thisRow.Cells[2].FindControl("Labelpytp_nm");

            TextBox TextBoxpytp_pytpcd = (TextBox)thisRow.Cells[1].FindControl("TextBoxpytp_pytpcd");
            TextBox TextBoxpytp_nm = (TextBox)thisRow.Cells[2].FindControl("TextBoxpytp_nm");

            Labelpytp_pytpcd.Visible = true;
            Labelpytp_nm.Visible = true;

            TextBoxpytp_pytpcd.Visible = false;
            TextBoxpytp_nm.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            mypytp.Delpytp(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}