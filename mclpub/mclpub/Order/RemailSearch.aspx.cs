using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class RemailSearch : System.Web.UI.Page
    {
        RemailSearch_DB myRemail = new RemailSearch_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.UCPager1.Ctrl_GV = "GridView1";
            this.UCPager2.Ctrl_GV = "GridView2";

            if (Context.Request.QueryString["function1"] == null || Context.Request.QueryString["function1"] == "" || (Context.Request.QueryString["function1"] != "new" && Context.Request.QueryString["function1"] != "mod"))
            {
                JavaScript.AlertMessageRedirect(this.Page, "參數錯誤", "../Default.aspx");
                return;
            }

            
            if (!IsPostBack)
            {
                if (Context.Request.QueryString["function1"] == "new")
                {
                    titlelb.Text = "補書登錄";
                    rblSent.Enabled = false;
                }
                if (Context.Request.QueryString["function1"] == "mod")
                {
                    titlelb.Text = "補書單修改/查詢";
                }
                SearchIcon.Visible = false;
                //UCPager1.Visible = false;
                UCPager2.Visible = false;
            }
        }

        protected void lnbSearch_Click(object sender, EventArgs e)
        {
            if (Context.Request.QueryString["function1"] == "new")
            {
                ShowCust();

            }
            else if (Context.Request.QueryString["function1"] == "mod")
            {
                DataGrid2_DataBind();
            }
        }


        private void BindPage()
        {
            DataSet ds1 = myRemail.Selectc1_order(tbxOrderNo.Text, tbxCompanyname.Text, tbxMfrno.Text, tbxCustNo.Text, tbxCustName.Text, tbxRecName.Text, tbxRecAddr.Text, tbxRecTel.Text, tbxOrderDate1.Text, tbxOrderDate2.Text);
            DataTable dt = ds1.Tables[0];
            if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
            {
                DataView dv = dt.DefaultView;
                dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
           
            if (dt.Rows.Count > 0)
            {
                PagerBind(dt);//分頁連接
            }
        }

        protected void gv_data_Sorting(object sender, GridViewSortEventArgs e)
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
                {
                    ViewState["SortDirection"] = " ASC";
                }
                else
                {
                    ViewState["SortDirection"] = " DESC";
                }

            }
            else
            {
                //第一次對某欄位排序，就是「升」
                ViewState["SortDirection"] = " ASC";
            }

            //for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            //{
            //    ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
            //    ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
            //}
            int Columns_i = 0;
            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                if (e.SortExpression == ((GridView)sender).Columns[i].SortExpression)
                {
                    Columns_i = i;
                    if (ViewState["SortDirection"].ToString() == " ASC")
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
                    }
                    else
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
                    }
                }
            }

            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱

            DataSet ds1 = myRemail.Selectc1_order(tbxOrderNo.Text, tbxCompanyname.Text, tbxMfrno.Text, tbxCustNo.Text, tbxCustName.Text, tbxRecName.Text, tbxRecAddr.Text, tbxRecTel.Text, tbxOrderDate1.Text, tbxOrderDate2.Text);
            DataTable dt = ds1.Tables[0];

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = dt.DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            GridView1.DataSource = dv;
            GridView1.DataBind();
            if (dt.Rows.Count > 0)
            {
                PagerBind(dt);//分頁連接
            }
        }

        public void PagerBind(DataTable dt)
        {
            Label lbl_pagecount = (Label)GridView1.BottomPagerRow.FindControl("lbl_pagecount");
            Label lbl_datacount = (Label)GridView1.BottomPagerRow.FindControl("lbl_datacount");



            lbl_pagecount.Text = GridView1.PageCount.ToString();
            lbl_datacount.Text = dt.Rows.Count.ToString();

            int count = 0;

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count % 10 == 0)
                {
                    count = dt.Rows.Count / 10;
                }
                else
                {
                    count = dt.Rows.Count / 10 + 1;

                }
            }
            DropDownList ddlpage = (DropDownList)GridView1.BottomPagerRow.FindControl("ddl_gopage");
            DataTable dtPage = new DataTable();
            dtPage.Columns.Add("page");
            for (int i = 1; i < count + 1; i++)
            {
                ddlpage.Items.Add(new ListItem(i.ToString(), i.ToString()));
                DataRow myRow = dtPage.NewRow();
                myRow["page"] = i;
                dtPage.Rows.Add(myRow);
            }

            ddlpage.SelectedIndex = GridView1.PageIndex;


            int LocalPageCount = Convert.ToInt32(GridView1.PageCount);
            int LocalPageIndex = Convert.ToInt32(GridView1.PageIndex);
            int ShowPageStart = 0;
            int ShowPageEnd = 0;

            //若頁碼已經是在10頁內的話，就不用判斷了
            if (LocalPageCount > 10)
            {
                if ((LocalPageIndex >= 0) && (LocalPageIndex <= 6))
                {
                    ShowPageStart = 1;
                }
                else
                {
                    ShowPageStart = LocalPageIndex - 5;
                }

                if ((ShowPageStart + 9) >= LocalPageCount) ShowPageEnd = LocalPageCount;
                else ShowPageEnd = ShowPageStart + 9;
                if (ShowPageEnd > LocalPageCount) ShowPageEnd = LocalPageCount;

                dtPage.DefaultView.RowFilter = string.Format("page >= {0} and page <= {1}", ShowPageStart, ShowPageEnd);
            }

            //產生頁碼清單Repeater
            Repeater rep_page = (Repeater)GridView1.BottomPagerRow.FindControl("rep_page");
            rep_page.DataSource = dtPage;
            rep_page.DataBind();
        }

        private void ShowCust()
        {
            GridView1.PageIndex = 0;
            BindPage();
            //UCPager1.Dtdata = dt;
            //UCPager1.UCPageBind();
            SearchIcon.Visible = true;
            //if (dt.Rows.Count > 0)
            //{
            //    UCPager1.Visible = true;
            //}
            //else
            //{
            //    UCPager1.Visible = false;
            //}
        }

        protected void Query_Click(object sender, EventArgs e)
        {
            int intpageindex = 0;
            LinkButton lkbtn = (LinkButton)sender;
            switch (lkbtn.CommandArgument.ToString())
            {
                case "last":
                    intpageindex = GridView1.PageCount - 1;
                    break;
                case "first":
                    intpageindex = 0;
                    break;
                case "back10page":
                    {
                        if (GridView1.PageIndex >= 10)
                        {
                            intpageindex = GridView1.PageIndex - 10;
                        }
                        else
                        {
                            intpageindex = 0;
                        }
                        break;
                    }
                case "backpage":
                    {
                        if (GridView1.PageIndex > 0)
                        {
                            intpageindex = GridView1.PageIndex - 1;
                        }
                        break;
                    }
                case "Advance10page":
                    {
                        if (GridView1.PageIndex + 10 <= GridView1.PageCount - 1)
                        {
                            intpageindex = GridView1.PageIndex + 10;
                        }
                        else
                        {
                            intpageindex = GridView1.PageCount - 1;
                        }
                        break;
                    }
                case "Advancepage":
                    {
                        if (GridView1.PageIndex + 1 < GridView1.PageCount - 1)
                        {
                            intpageindex = GridView1.PageIndex + 1;
                        }
                        else
                        {
                            intpageindex = GridView1.PageCount - 1;
                        }
                        break;
                    }

            }
            GridView1.PageIndex = intpageindex;
            BindPage();
        }

        protected void rep_page_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
                return;

            LinkButton lbtn_page = (LinkButton)e.Item.FindControl("lbtn_page");
            //屬於目前的頁次的話，則不顯示底線，也將其功能關閉
            if (DataBinder.Eval(e.Item.DataItem, "page").ToString() == Convert.ToString(GridView1.PageIndex + 1))
            {
                lbtn_page.Attributes["style"] = "text-decoration: none;";
                lbtn_page.Enabled = false;
            }
        }

        #region 跳至頁數
        protected void lbtn_page_Click(object sender, EventArgs e)
        {
            //Repeater rpter = ((Repeater)GridView1.BottomPagerRow.FindControl("rep_page"));
            //LinkButton lkbtn = ((LinkButton)rpter.FindControl("lbtn_page"));
            //JavaScript.AlertMessage(this.Page, lkbtn.CommandArgument.ToString());
            //Response.Write(lkbtn.CommandArgument.ToString());
            if (GridView1.Rows.Count > 0)
            {
                GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument) - 1;
                BindPage();
            }

        }
        #endregion

        protected void ddl_gopage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl_gopage = ((DropDownList)GridView1.BottomPagerRow.FindControl("ddl_gopage"));
            GridView1.PageIndex = Convert.ToInt32(ddl_gopage.SelectedValue.ToString()) - 1;
            BindPage();
        }

        protected void btnComplement_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string strbuf;
            strbuf = "RemailForm.aspx?id=" + thisRow.Cells[0].Text;
            strbuf = strbuf + "&oritem=" + thisRow.Cells[4].Text;
            strbuf = strbuf + "&date=" + thisRow.Cells[8].Text;
            strbuf = strbuf + thisRow.Cells[9].Text;
            strbuf = strbuf + "&prepage=";
            //strbuf="RemailForm.aspx?id="+DataGrid1.SelectedItem.Cells[0].Text.ToString().Trim()+"&oritem="+DataGrid1.SelectedItem.Cells[4].Text.ToString().Trim()
            //	+"&date="+DataGrid1.SelectedItem.Cells[8].Text.ToString().Trim()+DataGrid1.SelectedItem.Cells[9].Text.ToString().Trim()+"&prepage=";
            //Response.Write("strbuf= " + strbuf + "<br>");
            Response.Redirect(strbuf);
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Response.Redirect("RemailFM.aspx?id=" + thisRow.Cells[1].Text.Trim() + "&seq=" + thisRow.Cells[2].Text.Trim() + "&oritem=" + thisRow.Cells[7].Text.Trim());
        }

        protected void del_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            string strbuf;
            strbuf = thisRow.Cells[1].Text.Trim();
            myRemail.Delc1_remail(strbuf.Substring(2, 6), thisRow.Cells[7].Text.Trim(), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(0, 2), thisRow.Cells[2].Text.Trim());
            DataGrid2_DataBind();
        }

        #region Gridview2
        private void DataGrid2_DataBind()
        {
            string date1, date2;
            DataSet ds2 = myRemail.Selectc1_remail();
            DataView dv2 = ds2.Tables[0].DefaultView;
            string strbuf = "";
            if (rblSent.SelectedItem.Value == "0")
                strbuf = "rm_fgsent <> 'C'";
            else if (rblSent.SelectedItem.Value == "1")
                strbuf = "rm_fgsent = 'C'";
            if (tbxOrderNo.Text != "")
            {
                strbuf += " and rm_custno='" + tbxOrderNo.Text.Substring(2, 6) + "'";
                strbuf += " and rm_otp1cd='" + tbxOrderNo.Text.Substring(8, 2) + "'";
                strbuf += " and rm_otp1seq='" + tbxOrderNo.Text.Substring(10, 3) + "'";
            }
            if (tbxCompanyname.Text != "")
                strbuf += " and mfr_inm Like '" + tbxCompanyname.Text.Trim() + "%'";
            if (tbxMfrno.Text != "")
                strbuf += " and mfr_mfrno = '" + tbxMfrno.Text.Trim() + "'";
            if (tbxCustNo.Text != "")
                //					if(tbxOrderNo.Text=="")
                strbuf += " and rm_custno = '" + tbxCustNo.Text.Trim() + "'";
            if (tbxCustName.Text != "")
                strbuf += " and cust_nm Like '" + tbxCustName.Text.Trim() + "%'";
            if (tbxRecName.Text != "")
                strbuf += " and or_nm Like '" + tbxRecName.Text.Trim() + "%'";
            if (tbxRecAddr.Text != "")
                strbuf += " and or_addr Like '%" + tbxRecAddr.Text.Trim() + "%'";
            if (tbxRecTel.Text != "")
                strbuf += " and or_tel=" + tbxRecTel.Text.Trim();
            if (tbxOrderDate1.Text != "" && tbxOrderDate2.Text != "")
            {
                date1 = tbxOrderDate1.Text.Substring(0, 4) + tbxOrderDate1.Text.Substring(5, 2) + tbxOrderDate1.Text.Substring(8, 2);
                date2 = tbxOrderDate2.Text.Substring(0, 4) + tbxOrderDate2.Text.Substring(5, 2) + tbxOrderDate2.Text.Substring(8, 2);
                strbuf += " and (o_date>='" + date1 + "' and o_date<='" + date2 + "')";
            }
            dv2.RowFilter = strbuf;
            UCPager2.Dtdata = dv2.ToTable();
            UCPager2.UCPageBind();

            SearchIcon.Visible = true;
            if (dv2.Count > 0)
            {
                UCPager2.Visible = true;
            }
            else
            {
                UCPager2.Visible = false;
            }
        }

        #endregion
    }
}