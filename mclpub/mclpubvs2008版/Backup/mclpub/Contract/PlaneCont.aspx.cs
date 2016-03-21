using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace mclpub.Contract
{
    public partial class PlaneCont : System.Web.UI.Page
    {
        PlaneCont_DB myPlane = new PlaneCont_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "ContGV";

            if (!IsPostBack)
            {
                if (ContGV.Rows.Count > 0)
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

        protected void ContGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
                // e.Row.Cells[1].Visible = false;
                //Button d = (Button)e.Row.Cells[6].FindControl("Button2");
                ////LinkButton d = (LinkButton)e.Row.Cells[8].FindControl("LinkButton1");
                //d.OnClientClick = "javascript:return confirm('確定刪除？')";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
                //e.Row.Cells[1].Visible = false;
            }

        }

        protected void GVEdit_Sorting(object sender, GridViewSortEventArgs e)
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
            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱

            DataTable dt = myPlane.SelecChkBtn(tbxCompanyName.Text.Trim(), tbxMfrNo.Text.Trim(), tbxCustNo.Text.Trim(), tbxCustName.Text.Trim(), Account.GetAccInfo().srspn_empno);

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = dt.DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            this.UCPager1.Dtdata = dv.ToTable();
            this.UCPager1.UCPageBind();
        }


        protected void lkRedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[1].Text;
            Response.Redirect(string.Format("../Subscriber/Cust_Edit.aspx?editID={0}", ide));

        }

        protected void BtnRedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[4].Text;
            Response.Redirect(string.Format("PlaneCont_2.aspx?custno={0}", ide));

        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = myPlane.SelecChkBtn(tbxCompanyName.Text.Trim(), tbxMfrNo.Text.Trim(), tbxCustNo.Text.Trim(), tbxCustName.Text.Trim(), Account.GetAccInfo().srspn_empno);
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();

            SearchIcon.Visible = true;
            if (dt.Rows.Count > 0)
            {
                UCPager1.Visible = true;
            }
            else
            {
                UCPager1.Visible = false;
            }

        }

        protected void AddComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Subscriber/AddComp.aspx");
        }

        protected void AddCust_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Subscriber/AddCust.aspx");
        }
    }
}
