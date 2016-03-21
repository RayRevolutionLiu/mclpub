using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mclpub.Contract;
using System.Data;

namespace mclpub.Contract
{
    public partial class InterPlaneCont : System.Web.UI.Page
    {
        InterPlaneCont_DB cust = new InterPlaneCont_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "ContGV";
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;

            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            DataSet ds = cust.GetMfrCustomers();
            DataView dv = ds.Tables[0].DefaultView;

            string strFilter = GetFilters();

            if (strFilter.Trim() != "")
            {
                dv.RowFilter = strFilter;
            }
            dv.Sort = "cust_custno";

            //Response.Write(dv.Count);
            DataTable dt = new DataTable();
            dt = dv.ToTable();

            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();

            SearchIcon.Visible = true;

            if (dv.Count > 0)
            {
                UCPager1.Visible = true;
            }
        }


        #region 組合查詢條件
        /// <summary>
        /// 組合查詢條件
        /// </summary>
        /// <returns>組合後的條件字串</returns>
        private string GetFilters()
        {
            int fc = 0;
            string strFilter = "";

            //廠商名稱
            if (tbxMfrNm.Text.Trim() != "")
            {
                strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
                fc++;
            }

            //統一編號
            if (tbxMfrNo.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "mfr_mfrno LIKE '%" + tbxMfrNo.Text.Trim() + "%'";
                fc++;
            }

            //客戶編號
            if (tbxCustNo.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "cust_custno LIKE '%" + tbxCustNo.Text.Trim() + "%'";
                fc++;
            }

            //客戶姓名
            if (tbxCustNm.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "cust_nm LIKE '%" + tbxCustNm.Text.Trim() + "%'";
                fc++;
            }

            return strFilter;
        }
        #endregion

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


        protected void lkRedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[1].Text;
            Response.Redirect(string.Format("../Subscriber/Cust_Edit.aspx?editID={0}", ide));

        }

        protected void BtnRedrectEdit(object sender, EventArgs e)//確定維護
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[4].Text;
            Response.Redirect(string.Format("ContQueryFormal.aspx?custno={0}", ide));

        }


        protected void AddComp_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Subscriber/AddComp.aspx");
        }

        protected void AddCust_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Subscriber/AddCust.aspx");
        }

        protected void lngGoThis_Click(object sender, EventArgs e)
        {
            string contno = tbxContNo.Text.Trim();
            if (contno == "")
            {
                JavaScript.AlertMessage(this.Page, "欲直接維護合約，合約編號不可空白");
                return;
            }
            DataTable dt = cust.GetSingleContractByContNo(contno);


            if (dt.Rows.Count == 0)
            {
                JavaScript.AlertMessage(this.Page, "找不到合約" + contno + "的資料，請檢查合約編號是否正確或通知聯絡人");
            }
            else
            {
                Response.Redirect("ContMaintain.aspx?ContNo=" + contno);
            }
        }
    }
}
