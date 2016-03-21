using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class SAPListEdit : System.Web.UI.Page
    {
        SAPListEdit_DB mySAP = new SAPListEdit_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = mySAP.SelectSyscd();
                ds.Tables[0].DefaultView.Sort = "sys_syscd ASC";
                ddlBookType.DataTextField = ds.Tables[0].Columns[1].ToString();
                ddlBookType.DataValueField = ds.Tables[0].Columns[0].ToString();
                ddlBookType.DataSource = ds.Tables[0].DefaultView;
                ddlBookType.DataBind();

                SearchIcon.Visible = false;
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;

            DataSet ds = mySAP.Selectias();
            DataView dv = ds.Tables[0].DefaultView;
            string filter = "1=1";

            if (ddlBookType.SelectedValue.ToString() != "")
            {
                filter += " AND ias_syscd = '" + ddlBookType.SelectedValue.ToString() + "'";
            }
            if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
            {
                try
                {
                    string Sdate = tbxSDate.Text.Trim().Substring(0, 4) + tbxSDate.Text.Trim().Substring(5, 2);
                    string Edate = tbxEDate.Text.Trim().Substring(0, 4) + tbxEDate.Text.Trim().Substring(5, 2);
                    filter += " AND (ias_iasdate >= '" + Sdate + "' AND ias_iasdate <= '" + Edate + "') ";
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                    return;
                }
            }

            dv.RowFilter = filter;

            GridView1.DataSource = dv;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                if (e.Row.Cells[8].Text == "是")
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.Red; 
                }
                if (e.Row.Cells[9].Text == "是")
                {
                    e.Row.Cells[9].ForeColor = System.Drawing.Color.Red; 
                }
            }
        }

        protected void GVEdit_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)//如果第一次點選排序的話，預設就是「升」
            {
                ViewState["SortDirection"] = " DESC";
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
                ViewState["SortDirection"] = " DESC";
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
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
                    }
                    else
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
                    }
                }
            }

            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱
            DataSet ds = mySAP.Selectias();
            DataView dv = ds.Tables[0].DefaultView;
            string filter = "1=1";

            if (ddlBookType.SelectedValue.ToString() != "")
            {
                filter += " AND ias_syscd = '" + ddlBookType.SelectedValue.ToString() + "'";
            }
            if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
            {
                try
                {
                    string Sdate = tbxSDate.Text.Trim().Substring(0, 4) + tbxSDate.Text.Trim().Substring(5, 2);
                    string Edate = tbxEDate.Text.Trim().Substring(0, 4) + tbxEDate.Text.Trim().Substring(5, 2);
                    filter += " AND (ias_iasdate >= '" + Sdate + "' AND ias_iasdate <= '" + Edate + "') ";
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                    return;
                }
            }

            dv.RowFilter = filter;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
    }
}