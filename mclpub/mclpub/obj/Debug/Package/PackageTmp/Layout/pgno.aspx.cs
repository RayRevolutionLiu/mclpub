using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace mclpub.Layout
{
    public partial class pgno : System.Web.UI.Page
    {
        pgno_DB mypgno = new pgno_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid1();
                InitialData();
            }
        }

        // 顯示 DataGrid1
        public void BindGrid1()
        {
            // 先檢查該合約是否有未開發票的落版資料, 若無, 不予轉址
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = mypgno.Selectc2_pgno();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


            if (dv1.Count > 0)
            {
                UCPager1.Dtdata = dv1.ToTable();
                UCPager1.UCPageBind();
            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[3].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[3].Visible = false;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            accidTbx.Enabled = false;
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
                JavaScript.AlertMessage(this.Page, "起始頁碼為必填欄位!");
                return;
            }
            //修改搞定舊OK了
            mypgno.UPDATEC2_pgno(CellZreo, thisRow.Cells[3].Text.Trim(), accidTbx2.Text.Trim());
            JavaScript.AlertMessage(this.Page, "資料修改成功!");
            BindGrid1();
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
            string id = thisRow.Cells[3].Text.ToString().Trim();
            mypgno.DelC2_pgno(id);
            BindGrid1();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");

        }


        private void InitialData()
        {
            this.tbxStartPageNo.Text = "4";

            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter2.Select statement; 
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds1 = mypgno.SelectBook();
            DataView dv1 = ds1.Tables[0].DefaultView;
            ddlBkcd.DataSource = dv1;
            dv1.RowFilter = "proj_fgitri=''";
            ddlBkcd.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBkcd.DataValueField = "bk_bkcd";
            ddlBkcd.DataBind();
        }
    }
}