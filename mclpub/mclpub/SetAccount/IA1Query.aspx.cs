using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class IA1Query : System.Web.UI.Page
    {
        IA1Query_DB myia1 = new IA1Query_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            UCPager1.Ctrl_GV = "DataGrid1";

            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Bind_dgdCont();
        }

        #region 連結合約資料
        /// <summary>
        /// 連結合約資料
        /// </summary>
        /// <returns>找到的資料筆數</returns>
        private void Bind_dgdCont()
        {
            DataSet ds = myia1.GetAllFormalContracts(tbxMfrNm.Text.Trim(), tbxMfrNo.Text.Trim(), tbxCustNo.Text.Trim(), tbxCustNm.Text.Trim());

            UCPager1.Dtdata = ds.Tables[0];
            UCPager1.UCPageBind();

            SearchIcon.Visible = true;
            if (ds.Tables[0].Rows.Count > 0)
            {
                UCPager1.Visible = true;
            }
            else
            {
                UCPager1.Visible = false;
            }

        }
        #endregion

        protected void lngGoThis_Click(object sender, EventArgs e)
        {
            string contno = tbxContNo.Text.Trim();
            if (contno == "")
            {
                JavaScript.AlertMessage(this.Page, "欲直接挑選開立發票項目，合約編號不可空白");
                return;
            }

            DataSet ds = myia1.GetSingleContractByContNo(contno);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cont_conttp"].ToString() == "01")
                {
                    Response.Redirect("IA1QueryCont.aspx?ContNo=" + sec.encryptquerystring(contno) + "&ImSeq=00");
                }
                else
                {
                    JavaScript.AlertMessage(this.Page, "此合約非一般合約, 不需開立發票");
                    return;
                }
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "找不到合約" + contno + "的資料，請檢查合約編號是否正確或通知聯絡人");
                return;
            }
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.Cells[8].Text.Trim())
                {
                    case "0":
                        e.Row.Cells[8].Text = "否";
                        break;
                    case "1":
                        e.Row.Cells[8].Text = "是";
                        break;
                    default:
                        e.Row.Cells[8].Text = "(無法辨識)";
                        break;
                }

                switch (e.Row.Cells[9].Text.Trim())
                {
                    case "0":
                        e.Row.Cells[9].Text = "否";
                        break;
                    case "1":
                        e.Row.Cells[9].Text = "<font color=red>是</font>";
                        break;
                    default:
                        e.Row.Cells[9].Text = "(無法辨識)";
                        break;
                }

                switch (e.Row.Cells[10].Text.Trim())
                {
                    case "01":
                        e.Row.Cells[10].Text = "一般";
                        break;
                    case "09":
                        e.Row.Cells[10].Text = "推廣";
                        break;
                    default:
                        e.Row.Cells[10].Text = "(無法辨識)";
                        break;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            string ContNo;
            ContNo = thisRow.Cells[1].Text.Trim();
            if (thisRow.Cells[10].Text == "一般")
            {
                Response.Redirect("IA1QueryCont.aspx?ContNo=" + sec.encryptquerystring(ContNo) + "&ImSeq=00");
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "此合約非一般合約, 不需開立發票");
                return;
            }
        }
    }
}