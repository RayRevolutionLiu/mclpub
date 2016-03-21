using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class ContQueryFormal : System.Web.UI.Page
    {
        ContQueryFormal_DB myCont = new ContQueryFormal_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }


        public void bindGrid()
        {
            string custno = Context.Request.QueryString["custno"].Trim();
            DataTable dt = myCont.GetContractsByCustNo(custno);
            PCGV2.DataSource = dt;
            PCGV2.DataBind();

            if (dt.Rows.Count == 0)
            {
                AddNewCont.Visible = true;
                lblMessage.Text = "此客戶沒有歷史訂單, 請新增空白合約書";
            }
            else
            {
                AddNewCont.Visible = false;
                lblMessage.Text = "此客戶有 " + dt.Rows.Count.ToString() + "筆歷史資料";
            }

        }


        protected void PCGV2OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime signdate, sdate, edate;
                //處理 簽約日期、合約起迄日
                try
                {
                    signdate = DateTime.ParseExact(e.Row.Cells[1].Text.Trim(), "yyyyMMdd", null);
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "資料庫中的簽約日期格式錯誤，請通知聯絡人");
                    return;
                }

                try
                {
                    sdate = DateTime.ParseExact(e.Row.Cells[2].Text.Trim(), "yyyyMMdd", null);
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "資料庫中的簽約日期格式錯誤，請通知聯絡人");
                    return;
                }

                try
                {
                    edate = DateTime.ParseExact(e.Row.Cells[3].Text.Trim(), "yyyyMMdd", null);
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "資料庫中的簽約日期格式錯誤，請通知聯絡人");
                    return;
                }

                e.Row.Cells[1].Text = signdate.ToString("yyyy/MM/dd");
                e.Row.Cells[2].Text = sdate.ToString("yyyy/MM/dd");
                e.Row.Cells[3].Text = edate.ToString("yyyy/MM/dd");

                //處理一次付清註記
                switch (e.Row.Cells[7].Text.Trim())
                {
                    case "0":
                        e.Row.Cells[7].Text = "否";
                        break;
                    case "1":
                        e.Row.Cells[7].Text = "<font color=red>是</font>";
                        break;
                    default:
                        e.Row.Cells[7].Text = "(錯誤)";
                        break;
                }

                //處理結案註記
                switch (e.Row.Cells[8].Text.Trim())
                {
                    case "0":
                        e.Row.Cells[8].Text = "否";
                        break;
                    case "1":
                        e.Row.Cells[8].Text = "<font color=red>是</font>";
                        e.Row.Cells[11].Enabled = false;
                        break;
                    default:
                        e.Row.Cells[8].Text = "(錯誤)";
                        e.Row.Cells[11].Enabled = false;
                        break;
                }

                //處理合約類別
                switch (e.Row.Cells[9].Text.Trim())
                {
                    case "01":
                        e.Row.Cells[9].Text = "一般";
                        break;
                    case "09":
                        e.Row.Cells[9].Text = "推廣";
                        break;
                    default:
                        e.Row.Cells[9].Text = "(錯誤)";
                        break;
                }

                Button BtnEdit = (Button)e.Row.Cells[11].FindControl("Button2");
                BtnEdit.PostBackUrl = string.Format("javascript:location.href=\"ContMaintain.aspx?contno={0}\"", e.Row.Cells[0].Text.Trim());


                Button BtnNew = (Button)e.Row.Cells[12].FindControl("Button1");
                BtnNew.PostBackUrl = string.Format("javascript:location.href=\"ContNew.aspx?old_contno={0}\"", e.Row.Cells[0].Text.Trim());
            }

        }

        protected void AddNewCont_Click(object sender, EventArgs e)
        {
            string custno;
            if (Request.QueryString["custno"] == null || Request.QueryString["custno"] == "")
            {
                throw new Exception("客戶編號不能為空值");
            }
            else
            {
                custno = Request.QueryString["custno"];
            }

            Response.Redirect("~/Contract/ContNew.aspx?CustNo=" + custno);		
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InterPlaneCont.aspx");
        }
    }
}
