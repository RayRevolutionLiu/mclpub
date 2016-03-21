using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class PubSearchCust : System.Web.UI.Page
    {
        PubSearchCust_DB myPub = new PubSearchCust_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "PsGV";

            if (!IsPostBack)
            {
                UCPager1.Visible = false;

                if (PsGV.Rows.Count == 0)
                {
                    SearchIcon.Visible = false;
                }
                else
                {
                    SearchIcon.Visible = true;
                }
            }
        }

        public void BindGrid()
        {
            DataTable dt = myPub.SelectC1cust(tbxMfrnoSearch.Text.Trim(), tbxCustNo.Text.Trim(), tbxCustName.Text.Trim(),tbxCompanyname.Text.Trim());
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();
        }

        protected void PsGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                if (e.Row.Cells[5].Text.Trim() != "")
                {
                    e.Row.Cells[5].Text = e.Row.Cells[5].Text.Substring(0, 4) + "/" + e.Row.Cells[5].Text.Substring(4, 2) + "/" + e.Row.Cells[5].Text.Substring(6, 2);
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
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
                {
                    ViewState["SortDirection"] = " ASC";
                }
                else
                {
                    ViewState["SortDirection"] = " DESC";
                }

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
                    if (ViewState["SortDirection"].ToString() == " ASC")
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
                    }
                    else
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
                    }
                }
            }


            //if (ViewState["SortDirection"] == null)
            //{
            //    ViewState["SortDirection"] = " ASC";
            //}
            //for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            //{
            //    ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
            //    ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
            //}
            //string ViewState_SortDirection = ViewState["SortDirection"].ToString();
            //int Columns_i = 0;
            //for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            //{
            //    if (e.SortExpression == ((GridView)sender).Columns[i].SortExpression)
            //    {
            //        Columns_i = i;
            //        if (ViewState["SortDirection"].ToString() == SortDirection.Ascending.ToString())
            //        {
            //            e.SortDirection = SortDirection.Descending;
            //            ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
            //            ViewState["SortDirection"] = " DESC";
            //        }
            //        else
            //        {
            //            e.SortDirection = SortDirection.Ascending;
            //            ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
            //            ViewState["SortDirection"] = " ASC";
            //        }
            //    }
            //}

            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱

            DataTable dt = myPub.SelectC1cust(tbxMfrnoSearch.Text.Trim(), tbxCustNo.Text.Trim(), tbxCustName.Text.Trim(),tbxCompanyname.Text.Trim());

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = dt.DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            this.UCPager1.Dtdata = dv.ToTable();
            this.UCPager1.UCPageBind();
        }


        protected void RedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[1].Text;
            Response.Redirect(string.Format("PubSearchCustEdit.aspx?custnoID={0}", ide));

        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            UCPager1.Visible = true;
            BindGrid();

        }

        protected void AddCust_Click(object sender, EventArgs e)
        {
            Response.Redirect("PubSearchCustEdit.aspx");
        }

        protected void CustDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustListFilter.aspx");
        }
    }


}
