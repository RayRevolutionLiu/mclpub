using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class IARecoveryQuery : System.Web.UI.Page
    {
        RptIA_ChkFilter_DB myRpt = new RptIA_ChkFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                string datestr = DateTime.Today.ToString("yyyy/MM/dd");
                tbxYYYYMM.Text = datestr.Substring(0, 7);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxYYYYMM.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "產生年月不可空白");
                return;
            }
            if (tbxBatch.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "產生批次不可空白");
                return;
            }
            string iabdate = tbxYYYYMM.Text.Substring(0, 4) + tbxYYYYMM.Text.Substring(5, 2);
            string iabseq = tbxBatch.Text.Trim();
            DataSet ds = myRpt.GetIA(iabdate, iabseq);
            DataView dv = ds.Tables[0].DefaultView;

            if (dv.Count > 0)
            {
                btnOK.Visible = true;
            }
            SearchIcon.Visible = true;
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[10].Visible = false;
                switch (e.Row.Cells[6].Text.Trim().Replace("&nbsp;",""))
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
                switch (e.Row.Cells[7].Text.Trim().Replace("&nbsp;", ""))
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
                switch (e.Row.Cells[8].Text.Trim().Replace("&nbsp;", ""))
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
                switch (e.Row.Cells[10].Text.Trim().Replace("&nbsp;", ""))
                {
                    case "v":
                        e.Row.Cells[9].Text = "<font color=red>已產生清單</font>";
                        break;
                    case "5":
                        e.Row.Cells[9].Text = "<font color=red>已列印清單</font>";
                        break;
                    case "7":
                        e.Row.Cells[9].Text = "<font color=red>已轉SAP</font>";
                        break;
                    default:
                        e.Row.Cells[9].Text = "尚未產生清單";
                        break;
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[10].Visible = false;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            switch (DataGrid1.Rows[0].Cells[10].Text.Trim())
            {
                case "v":
                    JavaScript.AlertMessage(this.Page, "此批發票已產生清單, 不能回復(Recovery)");
                    return;
                case "5":
                    JavaScript.AlertMessage(this.Page, "此批發票已列印清單, 不能回復(Recovery)");
                    return;
                case "7":
                    JavaScript.AlertMessage(this.Page, "此批發票已轉SAP, 不能回復(Recovery)");
                    return;
                default:
                    JavaScript.AlertMessage(this.Page, "尚未產生清單");
                    break;
            }

            string iabdate = tbxYYYYMM.Text.Substring(0, 4) + tbxYYYYMM.Text.Substring(5, 2);
            string iabseq = tbxBatch.Text.Trim();

            bool flag = myRpt.RecoveryIA(iabdate, iabseq);
            if (flag)
            {
                JavaScript.AlertMessage(this.Page, "發票開立單Recovery完成");
            }
            else
                JavaScript.AlertMessage(this.Page, "發票開立單Recovery失敗, 請稍後再試");
        }
    }
}