using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class njtype : System.Web.UI.Page
    {
        adpub_actupdate_DB myadpub = new adpub_actupdate_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataSet ds = myadpub.njtp_detailASPX();
            DataView dv = ds.Tables[0].DefaultView;
            if (tbxQString.Text.Trim() != "")
            {
                dv.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() + "%'";
            }

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


        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBox2");
            Button Edit_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            accid.Visible = true;
            accidTbx.Visible = false;
            accid2.Visible = true;
            accidTbx2.Visible = false;
            SubBtn.Visible = true;
            CancelBtn.Visible = false;
            Edit_button.Visible = true;

            string ide = thisRow.Cells[0].Text;

            myadpub.Update(ide, accidTbx.Text.Trim(), accidTbx2.Text.Trim());
            BindGrid();
            JavaScript.AlertMessage(this.Page, "更新成功!");

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
            string ide = thisRow.Cells[0].Text;
            string strnjtpcd = thisRow.Cells[1].Text;
            DataSet ds = myadpub.Selectc2_pubASPX(strnjtpcd);
            DataView dv1 = ds.Tables[0].DefaultView;

            string rowfilterstr1 = "1=1";
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


			// 若搜尋結果為 "找不到" 的處理
            if (dv1.Count > 0)
            {
                int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());
                //Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

                if (intPubCounts > 0)
                {
                    // 以 Javascript 的 window.close() 來告知訊息
                    JavaScript.AlertMessage(this.Page, "刪除無效：本筆資料已被使用, 將不允許刪除！");
                }
            }
            else
            {
                myadpub.delete(ide);
                BindGrid();
                JavaScript.AlertMessage(this.Page, "資料刪除成功 !");
            }
        }

        protected void Query_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            tbxQString.Text = "";
            BindGrid();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            DataSet ds1 = myadpub.njtp_detailASPX();

            DataView dv = ds1.Tables[0].DefaultView;
            dv.RowFilter = "njtp_njtpcd = '" + njtp_njtpcd.Text.Trim() + "'";

            if (dv.Count > 0)
            {
                JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            }

            else
            {
                myadpub.Insert(njtp_njtpcd.Text.Trim(), njtp_nm.Text.Trim());
                BindGrid();
                JavaScript.AlertMessage(this.Page, "新增成功!");
            }
        }

    }
}