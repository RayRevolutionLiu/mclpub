using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class PlaneCont_2 : System.Web.UI.Page
    {
        PlaneCont_2_DB myPlane2 = new PlaneCont_2_DB();
        security sec = new security();

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
            DataTable dt = myPlane2.SelecPCGV2(custno);
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
                if (e.Row.Cells[1].Text == "01")
                {
                    e.Row.Cells[1].Text = "一般";
                }
                else
                {
                    e.Row.Cells[1].Text = "<font color=red>推廣</font>";
                }


                // 簽約日期
                string SignDate = e.Row.Cells[3].Text.Trim();
                if (SignDate != "")
                {
                    if (SignDate.Length >= 7)
                        SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (SignDate.IndexOf("\\") != -1)
                        {
                            //SignDate = SignDate.Split('/', 2);
                        }
                        else
                            SignDate = SignDate;
                    }
                }
                else
                {
                    SignDate = SignDate;
                }
                e.Row.Cells[3].Text = SignDate;


                // 合約起日
                string StartDate = e.Row.Cells[4].Text.Trim();
                //dgdCont.Items[i].Cells[4].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                if (StartDate != "")
                {
                    if (StartDate.Length >= 6)
                        StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (StartDate.IndexOf("\\") != -1)
                        {
                            //StartDate = StartDate.Split('/', 2);
                        }
                        else
                            StartDate = StartDate;
                    }
                }
                else
                {
                    StartDate = StartDate;
                }
                e.Row.Cells[4].Text = StartDate;


                // 合約迄日
                string EndDate = e.Row.Cells[5].Text.Trim();
                //dgdCont.Items[i].Cells[5].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                if (EndDate != "")
                {
                    if (EndDate.Length >= 6)
                        EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (EndDate.IndexOf("\\") != -1)
                        {
                            //EndDate = EndDate.Split('/', 2);
                        }
                        else
                            EndDate = EndDate;
                    }
                }
                else
                {
                    EndDate = EndDate;
                }
                e.Row.Cells[5].Text = EndDate;


                // 一次付清註記
                string strfgpayonce = e.Row.Cells[9].Text.Trim();
                //Response.Write("strfgpayonce= " + strfgpayonce + "<br>");
                if (strfgpayonce != "")
                {
                    if (strfgpayonce == "0")
                    {
                        e.Row.Cells[9].Text = "否";
                    }
                    else if (strfgpayonce == "1")
                    {
                        e.Row.Cells[9].Text = "<font color=red>是</font>";
                    }
                }
                else
                {
                    e.Row.Cells[9].Text = "<font color='Gray'>(無資料)</font>";
                }


                // 結案註記
                string strfgclosed = e.Row.Cells[10].Text.Trim();
                //Response.Write("strfgclosed= " + strfgclosed + "<br>");
                if (strfgclosed == "0")
                {
                    e.Row.Cells[10].Text = "否";
                }
                else
                {
                    e.Row.Cells[10].Text = "<font color=red>是</font>";
                    e.Row.Cells[18].Enabled = false;
                }

                // 已落版註記
                string strfgpubed = e.Row.Cells[15].Text.Trim();
                //Response.Write("strfgpubed= " + strfgpubed + "<br>");
                if (strfgpubed == "0")
                {
                    e.Row.Cells[15].Text = "否";
                }
                else
                {
                    e.Row.Cells[15].Text = "<font color=red>是</font>";
                }

                // 已註銷註記
                string strcancel = e.Row.Cells[16].Text.Trim();

                if (strcancel == "0")
                {
                    e.Row.Cells[16].Text = "否";
                }
                else
                {
                    e.Row.Cells[16].Text = "<font color=red>是</font>";
                }

                HyperLink System_SN = (HyperLink)e.Row.Cells[17].FindControl("HyperLink1");
                System_SN.NavigateUrl = "javascript:doDetail('800','600','ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(Request.QueryString["custno"].ToString()) + "&cont_contno=" + sec.encryptquerystring(e.Row.Cells[0].Text.Trim()) + "&dpplane=false');";

                Button BtnEdit = (Button)e.Row.Cells[18].FindControl("Button2");
                BtnEdit.PostBackUrl = string.Format("javascript:location.href=\"PlaneCont2Edit.aspx?cust_custno={0}&cont_contno={1}\"", sec.encryptquerystring(Request.QueryString["custno"].ToString()), sec.encryptquerystring(e.Row.Cells[0].Text.Trim()));


                Button BtnNew = (Button)e.Row.Cells[19].FindControl("Button1");
                BtnNew.PostBackUrl = string.Format("javascript:location.href=\"PlaneCont2New.aspx?cust_custno={0}&cont_contno={1}\"", Request.QueryString["custno"].ToString(), e.Row.Cells[0].Text.Trim());
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlaneCont.aspx");
        }

        protected void AddNewCont_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlaneCont2New.aspx?cust_custno=" + Context.Request.QueryString["custno"] + "&cont_contno=0");
        }
    }
}
