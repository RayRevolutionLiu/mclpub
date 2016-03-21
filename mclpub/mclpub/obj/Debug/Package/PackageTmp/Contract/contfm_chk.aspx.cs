using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class contfm_chk : System.Web.UI.Page
    {
        contfm_chk_DB mycontfm = new contfm_chk_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";

            if (!IsPostBack)
            {
                this.SearchIcon.Visible = false;
                UCPager1.Visible = false;
                GridView1.Visible = false;
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


        // 顯示資料：彩套黑次數皆為０
        private void BindGrid()
        {
            UCPager1.Dtdata = null;
            // 抓出篩選條件
            string strFilter = this.ddlFilter.SelectedItem.Value.ToString().Trim();

            DataTable dt = new DataTable();
            dt = mycontfm.SelectC2_pub(strFilter);

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
            this.SearchIcon.Visible = true;
            GridView1.Visible = true;
            UCPager1.Visible = true;
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();
            // 若搜尋結果為 "找不到" 的處理
            if (dt.Rows.Count == 0)
            {
                UCPager1.Visible = false;
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
            string strFilter = this.ddlFilter.SelectedItem.Value.ToString().Trim();

            DataTable dt = new DataTable();
            dt = mycontfm.SelectC2_pub(strFilter);

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = dt.DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            this.UCPager1.Dtdata = dv.ToTable();
            this.UCPager1.UCPageBind();
        }



        protected void GridView1OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[20].Visible = false;
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                    // 合約類別
                string strconttp = e.Row.Cells[1].Text.Trim();
                    //Response.Write("strconttp= " + strconttp + "<br>");
                    if (strconttp == "01")
                    {
                        e.Row.Cells[1].Text = "一般";
                    }
                    else if (strconttp == "09")
                    {
                        e.Row.Cells[1].Text = "推廣";
                    }

                    // 合約起迄日
                    string strSDate = e.Row.Cells[3].Text.Trim();
                    //strSDate = strSDate.Substring(0, 4) + "/" + strSDate.Substring(4, 2);
                    if (strSDate != "")
                    {
                        if (strSDate.Length >= 6)
                            strSDate = strSDate.Substring(0, 4) + "/" + strSDate.Substring(4, 2);
                        else
                        {
                            // 分離 \ 符號以取得數字
                            if (strSDate.IndexOf("\\") != -1)
                            {
                                //strSDate = strSDate.Split('/', 2);
                            }
                            else
                                strSDate = strSDate;
                        }
                    }
                    else
                    {
                        strSDate = strSDate;
                    }
                    //Response.Write("strSDate= " + strSDate + "<br>");
                    e.Row.Cells[3].Text = strSDate;

                    string strEDate = e.Row.Cells[4].Text.Trim();
                    //strEDate = strEDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
                    if (strEDate != "")
                    {
                        if (strEDate.Length >= 6)
                            strEDate = strSDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
                        else
                        {
                            // 分離 \ 符號以取得數字
                            if (strEDate.IndexOf("\\") != -1)
                            {
                                //strEDate = strEDate.Split('/', 2);
                            }
                            else
                                strEDate = strEDate;
                        }
                    }
                    else
                    {
                        strEDate = strEDate;
                    }
                    //Response.Write("strEDate= " + strEDate + "<br>");
                    e.Row.Cells[4].Text = strEDate;

                    // 簽約日期
                    string strSignDate = e.Row.Cells[5].Text.Trim();
                    //strSignDate = strSignDate.Substring(0, 4) + "/" + strSignDate.Substring(4, 2) + "/" + strSignDate.Substring(6, 2);
                    if (strSignDate != "")
                    {
                        if (strSignDate.Length >= 6)
                            strSignDate = strSignDate.Substring(0, 4) + "/" + strSignDate.Substring(4, 2) + "/" + strSignDate.Substring(6, 2);
                        else
                        {
                            // 分離 \ 符號以取得數字
                            if (strSignDate.IndexOf("\\") != -1)
                            {
                                //strSignDate = strSignDate.Split('/', 2);
                            }
                            else
                                strSignDate = strSignDate;
                        }
                    }
                    else
                    {
                        strSignDate = strSignDate;
                    }
                    //Response.Write("strEDate= " + strEDate + "<br>");
                    e.Row.Cells[5].Text = strSignDate;


                    // 一次付款
                    string strpayonce = e.Row.Cells[9].Text.Trim();
                    //Response.Write("strpayonce= " + strpayonce + "<br>");
                    if (strpayonce == "0")
                    {
                        e.Row.Cells[9].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[9].Text = "<font color=red>是</font>";
                    }

                    // 已結案
                    string strfgclosed = e.Row.Cells[10].Text.Trim();
                    //Response.Write("strfgclosed= " + strfgclosed + "<br>");
                    if (strfgclosed == "0")
                    {
                        e.Row.Cells[10].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[10].Text = "<font color=red>是</font>";
                    }

                    // 已落版
                    string strPubed = e.Row.Cells[15].Text.Trim();
                    //Response.Write("strPubed= " + strPubed + "<br>");
                    if (strPubed == "0")
                    {
                        e.Row.Cells[15].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[15].Text = "<font color=red>是</font>";
                    }

                    // 已註銷
                    string strfgCancel = e.Row.Cells[16].Text.Trim();
                    //Response.Write("strfgCancel= " + strfgCancel + "<br>");
                    if (strfgCancel == "0")
                    {
                        e.Row.Cells[16].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[16].Text = "<font color=red>是</font>";
                    }


                    Button BtnEdit = (Button)e.Row.Cells[19].FindControl("Button2");
                    BtnEdit.PostBackUrl = string.Format("javascript:location.href=\"PlaneCont2Edit.aspx?cust_custno={0}&cont_contno={1}\"", sec.encryptquerystring(e.Row.Cells[20].Text.Trim()), sec.encryptquerystring(e.Row.Cells[0].Text.Trim()));

                    HyperLink System_SN = (HyperLink)e.Row.Cells[18].FindControl("HyperLink1");
                    System_SN.NavigateUrl = "javascript:doDetail('800','600','ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(e.Row.Cells[20].Text.Trim()) + "&cont_contno=" + sec.encryptquerystring(e.Row.Cells[0].Text.Trim()) + "&dpplane=true');";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[20].Visible = false;
            }
        }


        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            SearchIcon.Visible = false;
            UCPager1.Visible = false;

        }
    }
}
