using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class S_SearchCust1 : System.Web.UI.Page
    {
        SearchCustOrder_DB mySearch = new SearchCustOrder_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GVSearchCust";
            if (!IsPostBack)
            {
                if (GVSearchCust.Rows.Count > 0)
                {
                    SearchIcon.Visible = true;
                    UCPager1.Visible = true;
                }
                else
                {
                    SearchIcon.Visible = false;
                    UCPager1.Visible = false;
                }

            }
        }

        public void BindGrid()
        {
            string STRtbxCompanyname = "";
            string STRtbxMfrno = "";
            string STRtbxCustNo = "";
            string STRtbxCustName = "";
            if (tbxCompanyname.Text.Trim() != "")
            {
                STRtbxCompanyname = tbxCompanyname.Text.Trim();
            }
            if (tbxMfrno.Text.Trim() != "")
            {
                STRtbxMfrno = tbxMfrno.Text.Trim();
            }
            if (tbxCustNo.Text.Trim() != "")
            {
                STRtbxCustNo = tbxCustNo.Text.Trim();
            }
            if (tbxCustName.Text.Trim() != "")
            {
                STRtbxCustName = tbxCustName.Text.Trim();
            }

            DataTable ds = mySearch.SelectBtn(STRtbxCompanyname, STRtbxMfrno, STRtbxCustNo, STRtbxCustName);
            this.UCPager1.Dtdata = ds;
            this.UCPager1.UCPageBind();

            if (ds.Rows.Count > 0)
            {
                UCPager1.Visible = true;
            }
            else
            {
                UCPager1.Visible = false;
            }
        }


        protected void gv_data_Sorting(object sender, GridViewSortEventArgs e)
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


            string STRtbxCompanyname = "";
            string STRtbxMfrno = "";
            string STRtbxCustNo = "";
            string STRtbxCustName = "";
            if (tbxCompanyname.Text.Trim() != "")
            {
                STRtbxCompanyname = tbxCompanyname.Text.Trim();
            }
            if (tbxMfrno.Text.Trim() != "")
            {
                STRtbxMfrno = tbxMfrno.Text.Trim();
            }
            if (tbxCustNo.Text.Trim() != "")
            {
                STRtbxCustNo = tbxCustNo.Text.Trim();
            }
            if (tbxCustName.Text.Trim() != "")
            {
                STRtbxCustName = tbxCustName.Text.Trim();
            }

            DataTable ds = mySearch.SelectBtn(STRtbxCompanyname, STRtbxMfrno, STRtbxCustNo, STRtbxCustName);

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = ds.DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            this.UCPager1.Dtdata = dv.ToTable();
            this.UCPager1.UCPageBind();
        }


        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            BindGrid();

        }

        protected void AddCust_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Subscriber/PubSearchCustEdit.aspx");
        }

        protected void AddComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Subscriber/AddComp.aspx");
        }


        protected void Edit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[3].Text;
            Response.Redirect(string.Format("../Subscriber/PubSearchCustEdit.aspx?custnoID={0}", ide));
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[3].Text;
            mySearch.InsertTmp(ide);
            Response.Redirect(string.Format("S_CustDetail.aspx?id={0}&type=01", ide));
        }


        //Response.Redirect("~/Subscriber/PubSearchCustEdit.aspx?custnoID={0}");
        protected void GVSearchCust_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                if (e.Row.Cells[7].Text.Trim() != "")
                {
                    e.Row.Cells[7].Text = e.Row.Cells[7].Text.Substring(0, 4) + "/" + e.Row.Cells[7].Text.Substring(4, 2) + "/" + e.Row.Cells[7].Text.Substring(6, 2);
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }
    }
}