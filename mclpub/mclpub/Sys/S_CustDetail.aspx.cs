using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class S_CustDetail : System.Web.UI.Page
    {
        CustDetail_DB myCust = new CustDetail_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string type = Request.QueryString["type"];
                if (type != "01" && type != "02" && type != "03" && type != "09")
                {
                    JavaScript.AlertMessageRedirect(this.Page, "參數不正確", "../Default.aspx");
                    return;
                }
                if (type == "01")
                {
                    titlename.Text = "訂閱訂單";
                }
                else if (type == "02")
                {
                    titlename.Text = "贈戶訂單";
                }
                else if (type == "03")
                {
                    titlename.Text = "推廣戶訂單";
                }
                else if (type == "09")
                {
                    titlename.Text = "零售訂單";
                }
            }
            catch
            {
                Application["ErrorMsg"] = "網址參數不正確";
                Response.Redirect("~/errorPage.aspx");
            }

            if (!IsPostBack)
            {
                string type = Request.QueryString["type"];
                DataSet ds2 = myCust.SelectAll();
                DataView dv2 = ds2.Tables["c1_od"].DefaultView;
                dv2.RowFilter = "od_otp1cd='" + type + "'";
                dv2.Sort = "od_otp1seq DESC";
                if (dv2.Count == 0)
                {
                    if (type == "01")
                        lblMessage.Text = "沒有訂閱歷史訂單";
                    else if (type == "02")
                        lblMessage.Text = "沒有贈閱歷史訂單";
                    else if (type == "03")
                        lblMessage.Text = "沒有推廣歷史訂單";
                    else if (type == "09")
                        lblMessage.Text = "沒有零售歷史訂單";
                    AddNewCont.Visible = true;
                }
                else
                {

                    lblCaption.Text = "註:選擇[詳細資料]可看到此訂單的原始資料, 選[新增]即將此訂單資料帶入新增訂單畫面";
                    PCGV2.DataSource = dv2;
                    PCGV2.DataBind();
                    lblMessage.Text = dv2.Count.ToString() + "筆訂單資料";
                    lblCaption.Visible = true;
                    AddNewCont.Visible = false;

                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("S_SearchCust1.aspx"));
        }

        //protected void delete_Click(object sender, EventArgs e)
        //{
        //    GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
        //    string ide = thisRow.Cells[0].Text;
        //    string type = Request.QueryString["type"];
        //    string id = Request.QueryString["id"].ToString();
        //    myCust.delete(id, type, ide);
        //    myCust.deleteTmp(id, type, ide);
        //    JavaScript.AlertMessage(this.Page, "註銷訂單" + ide + "成功!!");
        //    DataSet ds2 = myCust.SelectAll();
        //    DataView dv2 = ds2.Tables["c1_od"].DefaultView;
        //    dv2.RowFilter = "od_otp1cd='" + type + "'";
        //    dv2.Sort = " od_otp1seq DESC ";
        //    PCGV2.DataSource = dv2;
        //    PCGV2.DataBind();
        //    lblMessage.Text = dv2.Count.ToString() + "筆訂單資料";
        //}

        protected void Add_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[0].Text;
            string type = Request.QueryString["type"];
            if (type == "01")
                Response.Redirect("S_OrderForm.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);
            //else if (type == "02")
            //    Response.Redirect("FreeForm.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);
            //else if (type == "03")
            //    Response.Redirect("FreeForm.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);
            //else if (type == "09")
            //    Response.Redirect("OrderForm.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);

        }

        //protected void Edit_Click(object sender, EventArgs e)
        //{
        //    GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
        //    string ide = thisRow.Cells[0].Text;
        //    string type = Request.QueryString["type"];

        //    if (type == "01")
        //        Response.Redirect("OrderFM.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);
        //    else if (type == "02")
        //        Response.Redirect("FreeFM.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);
        //    else if (type == "03")
        //        Response.Redirect("FreeFM.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);
        //    else if (type == "09")
        //        Response.Redirect("OrderFM.aspx?id=" + Context.Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + ide);

        //}

        protected void PCGV2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string type = Request.QueryString["type"];
                HyperLink System_SN = (HyperLink)e.Row.Cells[6].FindControl("HyperLink1");
                System_SN.NavigateUrl = "javascript:doDetail('800','600','../Order/ShowOrder.aspx?id=" + Request.QueryString["id"].ToString().Trim() + "&type1=" + type + "&seq=" + e.Row.Cells[0].Text.Trim() + "');";
            }
        }

        protected void AddNewCont_Click(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            if (type == "01")
                Response.Redirect("S_OrderForm.aspx?id=" + Context.Request.QueryString["id"] + "&type1=" + type + "&seq1=000");
            //else if (type == "02")
            //    Response.Redirect("FreeForm.aspx?id=" + Context.Request.QueryString["id"] + "&type1=" + type + "&seq1=000");
            //else if (type == "03")
            //    Response.Redirect("FreeForm.aspx?id=" + Context.Request.QueryString["id"] + "&type1=" + type + "&seq1=000");
            //else if (type == "09")
            //    Response.Redirect("OrderForm.aspx?id=" + Context.Request.QueryString["id"] + "&type1=" + type + "&seq1=000");
        }

        protected void PCGV2_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)//如果第一次點選排序的話，預設就是「升」
            {
                ViewState["SortDirection"] = " ASC";
            }
            //判斷如果已經對某欄位排序過，再判斷是否針對同個欄位排序
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                //如果針對同個欄位排序，則進行「升」「降」的切換
                if (ViewState["SortDirection"].ToString() == " ASC")
                {
                    ViewState["SortDirection"] = " DESC";
                }
                else
                {
                    ViewState["SortDirection"] = " ASC";
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

            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱

            string type = Request.QueryString["type"];
            DataSet ds2 = myCust.SelectAll();
            DataView dv2 = ds2.Tables["c1_od"].DefaultView;
            dv2.RowFilter = "od_otp1cd='" + type + "'";
            dv2.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();

            if (dv2.Count == 0)
            {
                if (type == "01")
                    lblMessage.Text = "沒有訂閱歷史訂單";
                else if (type == "02")
                    lblMessage.Text = "沒有贈閱歷史訂單";
                else if (type == "03")
                    lblMessage.Text = "沒有推廣歷史訂單";
                else if (type == "09")
                    lblMessage.Text = "沒有零售歷史訂單";
                AddNewCont.Visible = true;
            }
            else
            {

                lblCaption.Text = "註:選擇[詳細資料]可看到此訂單的原始資料, 選[新增]即將此訂單資料帶入新增訂單畫面";
                PCGV2.DataSource = dv2;
                PCGV2.DataBind();
                lblMessage.Text = dv2.Count.ToString() + "筆訂單資料";
                lblCaption.Visible = true;
                AddNewCont.Visible = false;

            }

        }
    }
}