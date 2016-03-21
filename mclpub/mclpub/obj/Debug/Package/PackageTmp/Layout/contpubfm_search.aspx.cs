using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class contpubfm_search : System.Web.UI.Page
    {
        contpubfm_search_DB mycont = new contpubfm_search_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GVcont";
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;
                lblMessage.Visible = false;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            ShowPub();
        }

        // 按下 "查詢" 按鈕 的處理
        private void ShowPub()
        {

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = mycont.Selectc2_pub();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr1 = "mfr_mfrno Like '%" + tbxMfrNo.Text.Trim() + "%'";

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            //防呆處理: 若無資料時, 則給錯誤訊息
            if (tbxMfrName.Text != "")
                rowfilterstr1 = rowfilterstr1 + " and mfr_inm Like '%" + tbxMfrName.Text.Trim() + "%'";

            if (tbxCustNo.Text != "")
                rowfilterstr1 = rowfilterstr1 + " and cont_custno ='" + tbxCustNo.Text.Trim() + "'";

            if (tbxCustName.Text != "")
                rowfilterstr1 = rowfilterstr1 + " and cust_nm Like '%" + tbxCustName.Text.Trim() + "%'";

            if (tbxContNo.Text != "")
                rowfilterstr1 = rowfilterstr1 + " and cont_contno like '%" + tbxContNo.Text.Trim() + "%'";

            dv1.RowFilter = rowfilterstr1;

            // 若搜尋結果為 "找不到" 的處理
            if (dv1.Count == 0)
            {

            }
            //lblMessage.Text="查詢結果: 找不到符合條件的資料, 請重設條件!  或請先新增<A HREF='../d5/Mfr.aspx' Target='_new'>廠商</A> 或 <A HREF='../d1/NewCust.aspx?mfrno=' Target='_new'>客戶</A>, 再回來搜尋並新增.";
            else
            {
                UCPager1.Visible = true;
                lblMessage.Text = "結果: 找到 " + dv1.Count.ToString() + "筆資料";
            }

            UCPager1.Dtdata = dv1.ToTable();
            UCPager1.UCPageBind();

        }

        protected void GVcont_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink System_SN = (HyperLink)e.Row.Cells[13].FindControl("HyperLink1");
                System_SN.NavigateUrl = "javascript:doDetail('800','600','../Contract/ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(e.Row.Cells[8].Text.Trim()) + "&cont_contno=" + sec.encryptquerystring(e.Row.Cells[0].Text.Trim()) + "&dpplane=true');";

                e.Row.Cells[2].Visible = false;
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
                    string StartDate = e.Row.Cells[4].Text.Trim();
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
                    e.Row.Cells[4].Text = StartDate;

                    string EndDate = e.Row.Cells[5].Text.Trim();
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
                    e.Row.Cells[5].Text = EndDate;

                    // 已結案註記
                    string strfgclosed = e.Row.Cells[11].Text.Trim();
                    //Response.Write("strfgclosed= " + strfgclosed + "<br>");
                    if (strfgclosed == "0")
                    {
                        e.Row.Cells[11].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[11].Text = "<font color=red>是</font>";
                    }

                    // 已註銷註記
                    string strfgcancel = e.Row.Cells[12].Text.Trim();
                    //Response.Write("strfgcancel= " + strfgcancel + "<br>");
                    if (strfgcancel == "0")
                    {
                        e.Row.Cells[12].Text = "否";
                    }
                    else
                    {
                        e.Row.Cells[12].Text = "<font color=red>是</font>";
                    }
                

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
            }
        }
    }
}