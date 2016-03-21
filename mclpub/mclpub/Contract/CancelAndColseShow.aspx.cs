using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class CancelAndColseShow : System.Web.UI.Page
    {
        CancelAndCloseShow_DB myCancel = new CancelAndCloseShow_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView01";
            this.UCPager2.Ctrl_GV = "GridView02";
            this.UCPager3.Ctrl_GV = "GridView03";

            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;
                UCPager2.Visible = false;
                UCPager3.Visible = false;
                btnCancel.Visible = false;
                //因為<span class="stripMe">會在GRIDVIEW被隱藏的時候還出現 所以要一起藏
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
        }


        public DataSet BindGrid()
        {
            DataSet ds = new DataSet();

            //顯示已結案合約書
            if (DpSelectType.SelectedValue.ToString() == "01")
            {
                GridView01.Visible = true;
                UCPager1.Visible = true;
                GridView02.Visible = false;
                UCPager2.Visible = false;
                GridView03.Visible = false;
                UCPager3.Visible = false;
                btnCancel.Visible = false;
                ds = myCancel.SelectGrid01(tbxCompanyName.Text.Trim(),tbxMfrNo.Text.Trim(),tbxCustNo.Text.Trim(),tbxCustName.Text.Trim(),tbxContNo.Text.Trim());
                this.UCPager1.Dtdata = ds.Tables["c2_cont"];
                this.UCPager1.UCPageBind();

                //因為<span class="stripMe">會在GRIDVIEW被隱藏的時候還出現 所以要一起藏
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;

            }

            //註銷合約書
            if (DpSelectType.SelectedValue.ToString() == "02")
            {
                GridView01.Visible = false;
                UCPager1.Visible = false;
                GridView02.Visible = true;
                UCPager2.Visible = true;
                GridView03.Visible = false;
                UCPager3.Visible = false;

                LiteralControl litAlertInv1 = new LiteralControl();
                litAlertInv1.Text = "<script language=javascript>alert(\"請先進入[維護合約書] 之[額外備註]部分, 說明為何要註銷此合約~\\n再繼續進行本註銷動作!\");</script>";
                Page.Controls.Add(litAlertInv1);

                ds = myCancel.SelectGrid02(tbxCompanyName.Text.Trim(), tbxMfrNo.Text.Trim(), tbxCustNo.Text.Trim(), tbxCustName.Text.Trim(), tbxContNo.Text.Trim());
                this.UCPager2.Dtdata = ds.Tables["c2_cont"];
                this.UCPager2.UCPageBind();
                UCPager2.Visible = true;
                if (ds.Tables["c2_cont"].Rows.Count > 0)
                {
                    btnCancel.Visible = true;
                }


                //因為<span class="stripMe">會在GRIDVIEW被隱藏的時候還出現 所以要一起藏
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
                
            }

            //顯示已註銷合約書
            if (DpSelectType.SelectedValue.ToString() == "03")
            {
                GridView01.Visible = false;
                UCPager1.Visible = false;
                GridView02.Visible = false;
                UCPager2.Visible = false;
                GridView03.Visible = true;
                UCPager3.Visible = true;
                btnCancel.Visible = false;

                ds = myCancel.SelectGrid03(tbxCompanyName.Text.Trim(), tbxMfrNo.Text.Trim(), tbxCustNo.Text.Trim(), tbxCustName.Text.Trim(), tbxContNo.Text.Trim());
                this.UCPager3.Dtdata = ds.Tables["c2_cont"];
                this.UCPager3.UCPageBind();


                //因為<span class="stripMe">會在GRIDVIEW被隱藏的時候還出現 所以要一起藏
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
            }

            SearchIcon.Visible = true;

            return ds;
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            string msg = CheckData();
            if (msg.Length > 0)
            {
                this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                return;
            }

            BindGrid();
        }


        private string CheckData()
        {
            string msg = "";
            if (DpSelectType.SelectedValue.ToString() == "99")
            {
                msg += "請選擇查詢類別!\\r\\n";
            }

            return msg;
        }

        protected void GridView01OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                    // 合約類別
                    int ContTypeCode = int.Parse(e.Row.Cells[1].Text.Trim());
                    if (ContTypeCode == 1)
                        e.Row.Cells[1].Text = "一般合約";
                    else
                        e.Row.Cells[1].Text = "<font color=blue>推廣合約</font>";

                    //書籍類別
                    //string bkcd = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();

                    // 合約起日 & 合約迄日
                    string StartDate = e.Row.Cells[3].Text.Trim();
                    //DataGrid1.Items[i].Cells[4].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
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
                    e.Row.Cells[3].Text = StartDate;

                    string EndDate = e.Row.Cells[4].Text.Trim();
                    //DataGrid1.Items[i].Cells[5].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
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
                    e.Row.Cells[4].Text = EndDate;

                    // 已註銷註記
                    string strfgcancel = e.Row.Cells[10].Text.Trim();
                    //Response.Write("strfgcancel= " + strfgcancel + "<br>");
                    if (strfgcancel == "0")
                    {
                        e.Row.Cells[10].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[10].Text = "<font color=red>是</font>";
                    }

                    // 已落版註記
                    string strfgpubed = e.Row.Cells[11].Text.Trim();
                    //Response.Write("strfgpubed= " + strfgpubed + "<br>");
                    if (strfgpubed == "0")
                    {
                        e.Row.Cells[11].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[11].Text = "<font color=red>是</font>";
                    }

                    HyperLink System_SN = (HyperLink)e.Row.Cells[12].FindControl("HyperLink1");
                    System_SN.NavigateUrl = "javascript:doDetail('800','600','ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(e.Row.Cells[7].Text.Trim()) + "&cont_contno=" + sec.encryptquerystring(e.Row.Cells[0].Text.Trim()) + "&dpplane=false');";
            }

        }

        protected void GridView02_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                    // 合約類別
                    int ContTypeCode = int.Parse(e.Row.Cells[1].Text.Trim());
                    if (ContTypeCode == 1)
                        e.Row.Cells[1].Text = "一般合約";
                    else
                        e.Row.Cells[1].Text = "<font color=blue>推廣合約</font>";

                    //書籍類別
                    //string bkcd = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();

                    // 合約起日 & 合約迄日
                    string StartDate = e.Row.Cells[3].Text.Trim();
                    //DataGrid1.Items[i].Cells[4].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
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
                    e.Row.Cells[3].Text = StartDate;

                    // 合約迄日
                    string EndDate = e.Row.Cells[4].Text.Trim();
                    //DataGrid1.Items[i].Cells[5].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
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
                    e.Row.Cells[4].Text = EndDate;

                    // 已結案註記
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

                    // 已落版註記
                    string strfgpubed = e.Row.Cells[11].Text.Trim();
                    //Response.Write("strfgpubed= " + strfgpubed + "<br>");
                    if (strfgpubed == "0")
                    {
                        e.Row.Cells[11].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[11].Text = "<font color=red>是</font>";
                    }


                    HyperLink System_SN = (HyperLink)e.Row.Cells[13].FindControl("HyperLink1");
                    System_SN.NavigateUrl = "javascript:doDetail('800','600','ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(e.Row.Cells[7].Text.Trim()) + "&cont_contno=" + sec.encryptquerystring(e.Row.Cells[0].Text.Trim()) + "&dpplane=false');";

                    HyperLink System_SN2 = (HyperLink)e.Row.Cells[14].FindControl("HyperLink2");
                    System_SN2.NavigateUrl = string.Format("javascript:location.href=\"PlaneCont2Edit.aspx?cust_custno={0}&cont_contno={1}\"", sec.decryptquerystring(e.Row.Cells[7].Text.Trim()), sec.decryptquerystring(e.Row.Cells[0].Text.Trim()));
                
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int i;
            bool chk = false;
            for (i = 0; i < this.GridView02.Rows.Count; i++)
            {
                if (((CheckBox)GridView02.Rows[i].FindControl("CheckBox2")).Checked)
                {
                    string strSyscd = "C2";
                    string strContNo = GridView02.DataKeys[i].Value.ToString();
                    //PatentBehind_DB.DelOnline(AllGoodsGrid.DataKeys[i].Value.ToString());//先刪除主要的ROW DATA
                    myCancel.UpdateC2_cont(strSyscd, strContNo);

                    chk = true;
                    //Response.Write(AllGoodsGrid.DataKeys[i].Value.ToString());
                    //GridView1.DataKeys[i].Value.ToString() 可以抓到該列的DataKeys的值，我設定的是pk值 
                }
            }

            if (chk == true)
            {
                JavaScript.AlertMessage(this.Page, string.Format("已註銷!"));
                CheckBtn_Click(sender, e);
            }
            else
            {
                JavaScript.AlertMessage(this.Page, string.Format("請勾選需要註銷的資料"));
            }
        }

        protected void GridView03_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 合約類別
                int ContTypeCode = int.Parse(e.Row.Cells[1].Text.Trim());
                if (ContTypeCode == 1)
                    e.Row.Cells[1].Text = "一般合約";
                else
                    e.Row.Cells[1].Text = "<font color=blue>推廣合約</font>";

                //書籍類別
                //string bkcd = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();

                // 合約起日 & 合約迄日
                string StartDate = e.Row.Cells[3].Text.Trim();
                //DataGrid1.Items[i].Cells[4].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
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
                e.Row.Cells[3].Text = StartDate;

                string EndDate = e.Row.Cells[4].Text.Trim();
                //DataGrid1.Items[i].Cells[5].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
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
                e.Row.Cells[4].Text = EndDate;

                // 已結案註記
                string strfgclosed = e.Row.Cells[10].Text.Trim();
                if (strfgclosed == "0")
                {
                    e.Row.Cells[10].Text = "否";
                }
                else
                {
                    e.Row.Cells[10].Text = "<font color=red>是</font>";
                }

                // 已落版註記
                string strfgpubed = e.Row.Cells[11].Text.Trim();
                if (strfgpubed == "0")
                {
                    e.Row.Cells[11].Text = "否";
                }
                else
                {
                    e.Row.Cells[11].Text = "<font color=red>是</font>";
                }

                HyperLink System_SN = (HyperLink)e.Row.Cells[12].FindControl("HyperLink1");
                System_SN.NavigateUrl = "javascript:doDetail('800','600','ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(e.Row.Cells[7].Text.Trim()) + "&cont_contno=" + sec.encryptquerystring(e.Row.Cells[0].Text.Trim()) + "&dpplane=false');";
            }
        }
    }
}
