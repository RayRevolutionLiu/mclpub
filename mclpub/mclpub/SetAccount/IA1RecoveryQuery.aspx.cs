using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class IA1RecoveryQuery : System.Web.UI.Page
    {
        RptIA_ChkFilter_DB myRpt = new RptIA_ChkFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "DataGrid1";

            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind_dgdCont();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string iano = thisRow.Cells[0].Text.Trim();

            if (thisRow.Cells[11].Text.Trim() == "")
            {
                bool flag = myRpt.RecoveryIA1(iano);
                if (flag)
                {
                    Bind_dgdCont();
                    JavaScript.AlertMessage(this.Page, "發票開立單Recovery完成");
                    //					Response.Redirect("content.htm");
                }
                else
                    JavaScript.AlertMessage(this.Page, "發票開立單Recovery失敗, 請稍後再試!!");
            }
            else if (thisRow.Cells[11].Text.Trim() == "v")
            {
                JavaScript.AlertMessage(this.Page,"此發票開立單已產生清單,無法回復");
                return;
            }
            else if (thisRow.Cells[11].Text.Trim() == "5")
            {
                JavaScript.AlertMessage(this.Page,"此發票開立單已列印清單,無法回復");
                return;
            }
            else if (thisRow.Cells[11].Text.Trim() == "7")
            {
                JavaScript.AlertMessage(this.Page, "此發票開立單已轉SAP,無法回復");
                return;
            }

        }

        #region 連結合約資料
        /// <summary>
        /// 連結合約資料
        /// </summary>
        /// <returns>找到的資料筆數</returns>
        private void Bind_dgdCont()
        {
            DataSet ds = myRpt.GetIA("", "");
            DataView dv = ds.Tables[0].DefaultView;

            string strFilter = GetFilters();
            if (strFilter.Trim() != "")
            {
                dv.RowFilter = strFilter;
            }

            SearchIcon.Visible = true;
            if (dv.Count > 0)
            {
                UCPager1.Visible = true;
            }
            else
            {
                UCPager1.Visible = false;
            }

            UCPager1.Dtdata = dv.ToTable();
            UCPager1.UCPageBind();
        }
        #endregion

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
                strFilter += "ia_mfrno = '" + tbxMfrNo.Text.Trim() + "'";
                fc++;
            }

            //發票收件人
            if (tbxRecNm.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "ia_rnm LIKE '%" + tbxRecNm.Text.Trim() + "%'";
                fc++;
            }

            //發票開立單編號
            if (tbxIano.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "ia_iano = '" + tbxIano.Text.Trim() + "'";
                fc++;
            }

            return strFilter;
        }
        #endregion

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[11].Visible = false;
                switch (e.Row.Cells[6].Text.Trim())
                {
                    case "2":
                        e.Row.Cells[6].Text = "二聯";
                        break;
                    case "3":
                        e.Row.Cells[6].Text = "三聯";
                        break;
                    case "4":
                        e.Row.Cells[6].Text = "其他";
                        break;
                    default:
                        e.Row.Cells[6].Text = "";
                        break;
                }
                switch (e.Row.Cells[7].Text.Trim())
                {
                    case "1":
                        e.Row.Cells[7].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[7].Text = "零稅";
                        break;
                    case "3":
                        e.Row.Cells[7].Text = "免稅";
                        break;
                    default:
                        e.Row.Cells[7].Text = "";
                        break;
                }
                switch (e.Row.Cells[8].Text.Trim())
                {
                    case "06":
                        e.Row.Cells[8].Text = "所內";
                        break;
                    case "07":
                        e.Row.Cells[8].Text = "院內";
                        break;
                    case "":
                        e.Row.Cells[8].Text = "一般";
                        break;
                    default:
                        e.Row.Cells[8].Text = "";
                        break;
                }
                switch (e.Row.Cells[11].Text.Trim())
                {
                    case "v":
                        e.Row.Cells[9].Text = "<font color=red>已產生清單</font>";
                        ((Button)e.Row.Cells[10].FindControl("Button1")).Enabled = false;
                        break;
                    case "5":
                        e.Row.Cells[9].Text = "<font color=red>已列印清單</font>";
                        ((Button)e.Row.Cells[10].FindControl("Button1")).Enabled = false;
                        break;
                    case "7":
                        e.Row.Cells[9].Text = "<font color=red>已轉SAP</font>";
                        ((Button)e.Row.Cells[10].FindControl("Button1")).Enabled = false;
                        break;
                    default:
                        e.Row.Cells[9].Text = "尚未產生清單";
                        break;
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[11].Visible = false;
            }
        }
    }
}