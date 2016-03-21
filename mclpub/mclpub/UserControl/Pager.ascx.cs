using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.UserControl
{
    public partial class Pager : System.Web.UI.UserControl
    {
        GridView gv_data = new GridView();

        private string _Ctrl_GV = "";
        /// <summary>
        /// GridView控制項的ID名稱
        /// </summary>
        public string Ctrl_GV
        {
            get { return this._Ctrl_GV; }
            set { this._Ctrl_GV = value; }
        }

        DataTable _Dtdata = new DataTable();
        public DataTable Dtdata
        {
            get { return (DataTable)ViewState["_Dtdata"]; }
            set { ViewState["_Dtdata"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            gv_data = (GridView)this.NamingContainer.FindControl(Ctrl_GV);
            gv_data.AllowPaging = true;
            txt_page.Visible = false;
            lbtn_go1.Visible = false;
            //gv_data.PagerSettings.Visible = false;//將原本GridView預設的分頁功能隱藏，採用此控制項
            //gv_data.PageSize = 10;
        }

        #region 按鈕事件

        #region 第一頁
        protected void lbtn_first_Click(object sender, EventArgs e)
        {
            gv_data.DataSource = Dtdata;
            gv_data.PageIndex = 0;
            gv_data.DataBind();
            BindPage();
        }

        #endregion

        #region 前十頁
        protected void lbtn_pre10page_Click(object sender, EventArgs e)
        {
            if (gv_data.Rows.Count > 0)
            {
                gv_data.DataSource = Dtdata;
                if (gv_data.PageIndex - 10 < 0)
                    gv_data.PageIndex = 0;
                else
                    gv_data.PageIndex = gv_data.PageIndex - 10;

                gv_data.DataBind();
                BindPage();
            }
        }
        #endregion

        #region 上一頁
        protected void lbtn_prepage_Click(object sender, EventArgs e)
        {
            if (gv_data.PageIndex != 0)
            {
                gv_data.DataSource = Dtdata;
                gv_data.PageIndex = gv_data.PageIndex - 1;
                gv_data.DataBind();
                BindPage();

            }
        }
        #endregion

        #region 下一頁
        protected void lbtn_nextpage_Click(object sender, EventArgs e)
        {
            gv_data.DataSource = Dtdata;
            gv_data.PageIndex = gv_data.PageIndex + 1;
            gv_data.DataBind();
            BindPage();

        }
        #endregion

        #region 下十頁
        protected void lbtn_next10page_Click(object sender, EventArgs e)
        {
            if (gv_data.Rows.Count > 0)
            {
                gv_data.DataSource = Dtdata;
                if (gv_data.PageIndex + 10 >= gv_data.PageCount)
                    gv_data.PageIndex = gv_data.PageCount - 1;
                else
                    gv_data.PageIndex = gv_data.PageIndex + 10;

                gv_data.DataBind();
                BindPage();
            }
        }
        #endregion

        #region 最末頁
        protected void lbtn_last_Click(object sender, EventArgs e)
        {
            if (gv_data.Rows.Count > 0)
            {
                gv_data.DataSource = Dtdata;
                gv_data.PageIndex = gv_data.PageCount - 1;
                gv_data.DataBind();
                BindPage();
            }

        }
        #endregion

        #region 指定幾筆一頁
        protected void lbtn_go1_Click(object sender, EventArgs e)
        {
            if (txt_page.Text != "")
                gv_data.PageSize = int.Parse(txt_page.Text);

            UCPageBind();
        }
        #endregion

        #region 跳至頁數
        protected void lbtn_page_Click(object sender, EventArgs e)
        {
            if (gv_data.Rows.Count > 0)
            {
                gv_data.DataSource = Dtdata;
                gv_data.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument) - 1;
                gv_data.DataBind();
                BindPage();
            }

        }
        #endregion


        #endregion

        #region 公有函式
        /// <summary>
        /// 繫結資料
        /// </summary>
        public void UCPageBind()
        {
            gv_data = (GridView)this.NamingContainer.FindControl(Ctrl_GV);
            gv_data.DataSource = Dtdata;
            gv_data.DataBind();
            BindPage();
            if (Dtdata.Rows.Count == 0)
                table_pager.Visible = false;
            else
                table_pager.Visible = true;

        }
        #endregion

        #region 私有函式
        /// <summary>
        /// 計算頁碼、資料筆數
        /// </summary>
        private void BindPage()
        {
            //顯示筆數、頁數資料
            if (gv_data.Rows.Count > 0)
            {
                lbl_datacount.Text = ((DataTable)gv_data.DataSource).Rows.Count.ToString();
                lbl_pagecount.Text = gv_data.PageCount.ToString();
            }
            else
            {
                lbl_datacount.Text = "0";
                lbl_pagecount.Text = "0";
            }

            //用來記錄頁碼的DataTable
            DataTable dtPage = new DataTable();
            dtPage.Columns.Add("page");

            //產生清單頁碼數的DropDownList、DataTable
            ddl_gopage.Items.Clear();
            for (int i = 0; i < gv_data.PageCount + 1; i++)
            {
                if (i == 0)
                    ddl_gopage.Items.Add(new ListItem(" ", "0"));
                else
                {
                    ddl_gopage.Items.Add(new ListItem(i.ToString()));

                    //新增頁碼至DataTable
                    DataRow myRow = dtPage.NewRow();
                    myRow["page"] = i;
                    dtPage.Rows.Add(myRow);
                }

            }

            dtPage.DefaultView.RowFilter = "";
            if (gv_data.PageIndex > 0)
            {
                ddl_gopage.SelectedIndex = gv_data.PageIndex + 1;//(自己加 讓DP能產生出目前頁面數)
            }
            else
            {
                if (gv_data.Rows.Count > 0)
                {
                    ddl_gopage.SelectedIndex = 1;
                }
            }
            #region 將頁碼清單只維持在10頁
            int LocalPageCount = Convert.ToInt32(gv_data.PageCount);
            int LocalPageIndex = Convert.ToInt32(gv_data.PageIndex);
            int ShowPageStart = 0;
            int ShowPageEnd = 0;

            //若頁碼已經是在10頁內的話，就不用判斷了
            if (LocalPageCount > 10)
            {
                if ((LocalPageIndex >= 0) && (LocalPageIndex <= 6))
                {
                    ShowPageStart = 1;
                }
                else
                {
                    ShowPageStart = LocalPageIndex - 5;
                }

                if ((ShowPageStart + 9) >= LocalPageCount) ShowPageEnd = LocalPageCount;
                else ShowPageEnd = ShowPageStart + 9;
                if (ShowPageEnd > LocalPageCount) ShowPageEnd = LocalPageCount;

                dtPage.DefaultView.RowFilter = string.Format("page >= {0} and page <= {1}", ShowPageStart, ShowPageEnd);
            }
            #endregion

            //產生頁碼清單Repeater
            rep_page.DataSource = dtPage;
            rep_page.DataBind();
        }
        #endregion

        #region DrowDownList事件
        protected void ddl_gopage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_gopage.SelectedItem.Text.Trim() != "")
            {
                gv_data.DataSource = Dtdata;
                gv_data.PageIndex = Convert.ToInt32(((DropDownList)sender).SelectedValue) - 1;
                gv_data.DataBind();
                BindPage();
            }
        }
        #endregion

        #region Repeater事件

        protected void rep_page_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
                return;

            LinkButton lbtn_page = (LinkButton)e.Item.FindControl("lbtn_page");
            //屬於目前的頁次的話，則不顯示底線，也將其功能關閉
            if (DataBinder.Eval(e.Item.DataItem, "page").ToString() == Convert.ToString(gv_data.PageIndex + 1))
            {
                lbtn_page.Attributes["style"] = "text-decoration: none;";
                lbtn_page.Enabled = false;
            }
        }
        #endregion
    }
}