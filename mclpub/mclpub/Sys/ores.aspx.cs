using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class ores : System.Web.UI.Page
    {
        ores_DB myores = new ores_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();

                string strAssignedContNo = "";
                DataSet ds = myores.OutPutMaxValue();
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

                TextBoxores_orescd.Text = strAssignedContNo;
            }
        }

        public void BindGrid()
        {
            DataSet ds = myores.Selectc1_ores();
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

            Label Labelores_orescd = (Label)thisRow.Cells[1].FindControl("Labelores_orescd");
            Label Labelores_oresnm = (Label)thisRow.Cells[2].FindControl("Labelores_oresnm");

            TextBox TextBoxores_orescd = (TextBox)thisRow.Cells[1].FindControl("TextBoxores_orescd");
            TextBox TextBoxores_oresnm = (TextBox)thisRow.Cells[2].FindControl("TextBoxores_oresnm");

            Labelores_orescd.Visible = false;
            Labelores_oresnm.Visible = false;

            TextBoxores_orescd.Visible = true;
            TextBoxores_oresnm.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Button SubBtn_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            string itp_itpid = thisRow.Cells[0].Text.Trim();

            Label Labelores_orescd = (Label)thisRow.Cells[1].FindControl("Labelores_orescd");
            Label Labelores_oresnm = (Label)thisRow.Cells[2].FindControl("Labelores_oresnm");

            TextBox TextBoxores_orescd = (TextBox)thisRow.Cells[1].FindControl("TextBoxores_orescd");
            TextBox TextBoxores_oresnm = (TextBox)thisRow.Cells[2].FindControl("TextBoxores_oresnm");


            if (TextBoxores_orescd.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "訂單來源代碼不能為空值");
                return;
            }

            if (TextBoxores_oresnm.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "訂單來源名稱不能為空值");
                return;
            }

            //DataSet ds1 = myores.Selectc1_ores();

            //DataView dv = ds1.Tables[0].DefaultView;
            //string Strfilter = " 1=1 AND ores_orescd = '" + TextBoxores_orescd.Text.Trim() + "'";

            //dv.RowFilter = Strfilter;

            //if (dv.Count > 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            //    return;
            //}

            myores.Updatec1_ores(TextBoxores_orescd.Text.Trim(), TextBoxores_oresnm.Text.Trim(), itp_itpid);


            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;


            SubBtn_button.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            Labelores_orescd.Visible = true;
            Labelores_oresnm.Visible = true;

            TextBoxores_orescd.Visible = false;
            TextBoxores_oresnm.Visible = false;

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

            Label Labelores_orescd = (Label)thisRow.Cells[1].FindControl("Labelores_orescd");
            Label Labelores_oresnm = (Label)thisRow.Cells[2].FindControl("Labelores_oresnm");

            TextBox TextBoxores_orescd = (TextBox)thisRow.Cells[1].FindControl("TextBoxores_orescd");
            TextBox TextBoxores_oresnm = (TextBox)thisRow.Cells[2].FindControl("TextBoxores_oresnm");

            Labelores_orescd.Visible = true;
            Labelores_oresnm.Visible = true;

            TextBoxores_orescd.Visible = false;
            TextBoxores_oresnm.Visible = false;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string accid = thisRow.Cells[0].Text;
            myores.Delc1_ores(accid);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");
        }
    }
}