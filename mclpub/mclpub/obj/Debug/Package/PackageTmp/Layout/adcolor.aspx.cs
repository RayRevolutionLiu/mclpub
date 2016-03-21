using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adcolor : System.Web.UI.Page
    {
        adcolor_DB myadcolor = new adcolor_DB();

        private static string global_cd;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();
                NewWindDefault();
            }
        }

        public void BindGrid()
        {

            DataSet ds = myadcolor.Selectc2_clr();
            DataView dv = ds.Tables[0].DefaultView;

            string rowfilterstr1 = "1=1";
            dv.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


            if (dv.Count > 0)
            {
                UCPager1.Dtdata = dv.ToTable();
                UCPager1.UCPageBind();
            }
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
            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBox2");
            Button Edit_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            accid.Visible = false;
            accidTbx.Visible = true;
            accid2.Visible = false;
            accidTbx2.Visible = true;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;
            Edit_button.Visible = false;

            global_cd = accid.Text;

        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string CellZreo = thisRow.Cells[0].Text.Trim();
            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBox2");
            Button Edit_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            accid.Visible = true;
            accidTbx.Visible = false;
            accid2.Visible = true;
            accidTbx2.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;
            Edit_button.Visible = false;

            if (accidTbx2.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "廣告色彩代碼為必填欄位!");
                return;
            }

            if (accidTbx2.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "廣告色彩名稱為必填欄位!");
                return;
            }

            DataSet ds = myadcolor.Selectc2_clr();

            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "clr_clrcd = '" + accidTbx.Text.Trim() + "'";

            if (dv.Count > 0 && global_cd != accidTbx.Text)
            {
                JavaScript.AlertMessage(this.Page, "廣告色彩代碼重複!");
                return;
            }


            //修改搞定舊OK了
            myadcolor.UPDATEc2_clr(accidTbx.Text.Trim(), accidTbx2.Text.Trim(), CellZreo);
            JavaScript.AlertMessage(this.Page, "資料修改成功!");
            BindGrid();
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBox2");
            Button Edit_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");

            accid.Visible = true;
            accidTbx.Visible = false;
            accid2.Visible = true;
            accidTbx2.Visible = false;

            SubBtn.Visible = false;
            btnEdit.Visible = true;
            Edit_button.Visible = false;


        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");

            DataSet ds1 = myadcolor.SelectJudgeDelc2_clr(accid.Text.Trim());
            DataView dv1 = ds1.Tables[0].DefaultView;

            if (dv1.Count > 0)
            {
                int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());
                if (intPubCounts > 0)
                {
                    // 以 Javascript 的 window.close() 來告知訊息
                    JavaScript.AlertMessage(this.Page, "刪除無效：本筆資料已被使用, 將不允許刪除！");
                    return;
                }
            }
            else
            {
                myadcolor.Delc2_clr(thisRow.Cells[0].Text.ToString().Trim());
                BindGrid();
                JavaScript.AlertMessage(this.Page, "資料刪除成功!");
            }
        }

        private void NewWindDefault()
        {
            DataSet ds = myadcolor.CountMaxClrcd();
            DataView dv = ds.Tables[0].DefaultView;

            string strAssignedNewCode = "";

            if (dv.Count > 0 && dv[0]["CountNo"].ToString() != "0")
            {
                if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1)) < 10)
                {
                    strAssignedNewCode = Convert.ToString("0" + (Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                }
                else
                {
                    strAssignedNewCode = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                }
            }
            else
            {
                strAssignedNewCode += "01";
            }

            clr_clrcd.Text = strAssignedNewCode;
        }
    }
}