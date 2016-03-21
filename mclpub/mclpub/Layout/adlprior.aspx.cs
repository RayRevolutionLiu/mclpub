using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adlprior : System.Web.UI.Page
    {
        adlprior_DB myad = new adlprior_DB();

        private static string global_bkcd;
        private static string global_priorseq;
        private static string global_clrcd;
        private static string global_ltpcd;
        private static string global_pgscd;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();
                BindNewDrop();
            }
        }

        public void BindGrid()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myad.Selectc2_lprior();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            if (this.tbxQString.Text != null && this.tbxQString.Text.ToString().Trim() != "")
            {
                if (this.ddlQueryField.SelectedIndex == 0)
                {
                    rowfilterstr1 = rowfilterstr1 + " AND bk_nm like '%" + this.tbxQString.Text.ToString().Trim() + "%' ";
                }
                else if (this.ddlQueryField.SelectedIndex == 1)
                {
                    rowfilterstr1 = rowfilterstr1 + " AND lp_priorseq like '%" + this.tbxQString.Text.ToString() + "%' ";
                }
                else if (this.ddlQueryField.SelectedIndex == 2)
                {
                    rowfilterstr1 = rowfilterstr1 + " AND ltp_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
                }
                else if (this.ddlQueryField.SelectedIndex == 3)
                {
                    rowfilterstr1 = rowfilterstr1 + " AND clr_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
                }
                else if (this.ddlQueryField.SelectedIndex == 4)
                {
                    rowfilterstr1 = rowfilterstr1 + " AND pgs_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
                }
            }
            else
            {
                rowfilterstr1 = rowfilterstr1;
            }
            dv1.RowFilter = rowfilterstr1;

            UCPager1.Dtdata = dv1.ToTable();
            UCPager1.UCPageBind();

        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            if (Convert.ToInt32(thisRow.Cells[10].Text) <= 0)
            {
                Label accid = (Label)thisRow.Cells[1].FindControl("Labelbk_nm");
                Label accid2 = (Label)thisRow.Cells[2].FindControl("Labellp_priorseq");
                Label accid3 = (Label)thisRow.Cells[3].FindControl("Labelltp_nm");
                Label accid4 = (Label)thisRow.Cells[4].FindControl("Labelclr_nm");
                Label accid5 = (Label)thisRow.Cells[5].FindControl("Labelpgs_nm");
                DropDownList accidTbx = (DropDownList)thisRow.Cells[1].FindControl("TextBoxbk_nm");
                TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBoxlp_priorseq");
                DropDownList accidTbx3 = (DropDownList)thisRow.Cells[3].FindControl("TextBoxltp_nm");
                DropDownList accidTbx4 = (DropDownList)thisRow.Cells[4].FindControl("TextBoxclr_nm");
                DropDownList accidTbx5 = (DropDownList)thisRow.Cells[5].FindControl("TextBoxpgs_nm");

                DataSet dsBook = myad.Book();
                DataSet dsc2_clr = myad.c2_clr();
                DataSet dsc2_ltp = myad.c2_ltp();
                DataSet dsc2_pgsize = myad.c2_pgsize();



                DataView dv1 = dsBook.Tables[0].DefaultView;
                accidTbx.DataSource = dv1;
                accidTbx.DataTextField = "bk_nm";
                accidTbx.DataValueField = "bk_bkcd";
                accidTbx.DataBind();

                DataView dv2 = dsc2_ltp.Tables[0].DefaultView;
                accidTbx3.DataSource = dv2;
                accidTbx3.DataTextField = "ltp_nm";
                accidTbx3.DataValueField = "ltp_ltpcd";
                accidTbx3.DataBind();

                DataView dv3 = dsc2_clr.Tables[0].DefaultView;
                accidTbx4.DataSource = dv3;
                accidTbx4.DataTextField = "clr_nm";
                accidTbx4.DataValueField = "clr_clrcd";
                accidTbx4.DataBind();

                DataView dv4 = dsc2_pgsize.Tables[0].DefaultView;
                accidTbx5.DataSource = dv4;
                accidTbx5.DataTextField = "pgs_nm";
                accidTbx5.DataValueField = "pgs_pgscd";
                accidTbx5.DataBind();

                DataSet ds1 = myad.Checkc2_lprior2();
                DataView dvc2 = ds1.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                dvc2.RowFilter = " lp_lpid=" + thisRow.Cells[0].Text;
                // 指定 global_xxx 為原來存在資料庫中的初始值; 以傳遞到 btnUpdate_Click() 來做比較

                if (dvc2.Count > 0)
                {
                    string bkcd = dvc2[0]["lp_bkcd"].ToString();
                    string priorseq = dvc2[0]["lp_priorseq"].ToString();
                    string clrcd = dvc2[0]["lp_clrcd"].ToString();
                    string ltpcd = dvc2[0]["lp_ltpcd"].ToString();
                    string pgscd = dvc2[0]["lp_pgscd"].ToString();

                    global_bkcd = bkcd;
                    global_priorseq = priorseq;
                    global_clrcd = clrcd;
                    global_ltpcd = ltpcd;
                    global_pgscd = pgscd;

                    accidTbx.Items.FindByText(accid.Text).Selected = true;
                    accidTbx3.Items.FindByText(accid3.Text).Selected = true;
                    accidTbx4.Items.FindByText(accid4.Text).Selected = true;
                    accidTbx5.Items.FindByText(accid5.Text).Selected = true;

                }


                Button Edit_button = (Button)sender;
                Button SubBtn = (Button)thisRow.Cells[7].FindControl("SubBtn");
                Button CancelBtn = (Button)thisRow.Cells[7].FindControl("CancelBtn");

                accid.Visible = false;
                accid2.Visible = false;
                accid3.Visible = false;
                accid4.Visible = false;
                accid5.Visible = false;

                accidTbx.Visible = true;
                accidTbx2.Visible = true;
                accidTbx3.Visible = true;
                accidTbx4.Visible = true;
                accidTbx5.Visible = true;

                SubBtn.Visible = true;
                CancelBtn.Visible = true;
                Edit_button.Visible = false;
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "修改無效：本筆資料已被使用, 將不允許修改！");
            }

        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            DropDownList accidTbx = (DropDownList)thisRow.Cells[1].FindControl("TextBoxbk_nm");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBoxlp_priorseq");
            DropDownList accidTbx3 = (DropDownList)thisRow.Cells[3].FindControl("TextBoxltp_nm");
            DropDownList accidTbx4 = (DropDownList)thisRow.Cells[4].FindControl("TextBoxclr_nm");
            DropDownList accidTbx5 = (DropDownList)thisRow.Cells[5].FindControl("TextBoxpgs_nm");

            DataSet ds = myad.Checkc2_lprior();
            DataView dv = ds.Tables[0].DefaultView;

            string Currentbkcd = accidTbx.SelectedItem.Value.Trim();
            string Currentpriorseq = accidTbx2.Text.ToString().Trim();
            string Currentclrcd = accidTbx4.SelectedItem.Value.Trim();
            string Currentltpcd = accidTbx3.SelectedItem.Value.Trim();
            string Currentpgscd = accidTbx5.SelectedItem.Value.Trim();
            dv.RowFilter = "lp_bkcd = '" + Currentbkcd + "' AND lp_priorseq = '" + Currentpriorseq + "' AND lp_clrcd = '" + Currentclrcd + "' AND lp_ltpcd = '" + Currentltpcd + "' AND lp_pgscd = '" + Currentpgscd + "'";

            if (dv.Count > 0 && (Currentbkcd != global_bkcd || Currentpriorseq != global_priorseq || Currentclrcd != global_clrcd || Currentltpcd != global_ltpcd || Currentpgscd != global_pgscd))
            {
                JavaScript.AlertMessage(this.Page, "修改失敗: 此筆資料已經存在!");
            }
            else
            {
                myad.Updatec2_lpriorFinal(thisRow.Cells[0].Text.Trim(), Currentbkcd, Currentpriorseq, Currentclrcd, Currentltpcd, Currentpgscd);
                BindGrid();
                JavaScript.AlertMessage(this.Page, "修改成功");
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Label accid = (Label)thisRow.Cells[1].FindControl("Labelbk_nm");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Labellp_priorseq");
            Label accid3 = (Label)thisRow.Cells[3].FindControl("Labelltp_nm");
            Label accid4 = (Label)thisRow.Cells[4].FindControl("Labelclr_nm");
            Label accid5 = (Label)thisRow.Cells[5].FindControl("Labelpgs_nm");
            DropDownList accidTbx = (DropDownList)thisRow.Cells[1].FindControl("TextBoxbk_nm");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBoxlp_priorseq");
            DropDownList accidTbx3 = (DropDownList)thisRow.Cells[3].FindControl("TextBoxltp_nm");
            DropDownList accidTbx4 = (DropDownList)thisRow.Cells[4].FindControl("TextBoxclr_nm");
            DropDownList accidTbx5 = (DropDownList)thisRow.Cells[5].FindControl("TextBoxpgs_nm");

            accid.Visible = true;
            accid2.Visible = true;
            accid3.Visible = true;
            accid4.Visible = true;
            accid5.Visible = true;

            accidTbx.Visible = false;
            accidTbx2.Visible = false;
            accidTbx3.Visible = false;
            accidTbx4.Visible = false;
            accidTbx5.Visible = false;

            Button cancel_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[7].FindControl("SubBtn");
            Button EditBtn = (Button)thisRow.Cells[7].FindControl("btnEdit");

            cancel_button.Visible = false;
            SubBtn.Visible = false;
            EditBtn.Visible = true;
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string strbkcd = thisRow.Cells[6].Text.ToString();
            string strltpcd = thisRow.Cells[7].Text.ToString();
            string strclrcd = thisRow.Cells[8].Text.ToString();
            string strpgscd = thisRow.Cells[9].Text.ToString();

            DataSet ds = myad.Selectc2_lprior();
            DataView dv1 = ds.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            rowfilterstr1 = rowfilterstr1 + " AND lp_bkcd='" + strbkcd + "'";
            rowfilterstr1 = rowfilterstr1 + " AND lp_ltpcd='" + strltpcd + "'";
            rowfilterstr1 = rowfilterstr1 + " AND lp_clrcd='" + strclrcd + "'";
            rowfilterstr1 = rowfilterstr1 + " AND lp_pgscd='" + strpgscd + "'";
            dv1.RowFilter = rowfilterstr1;

            if (dv1.Count > 0)
            {
                int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());

                if (intPubCounts > 0)
                {
                    JavaScript.AlertMessage(this.Page, "刪除無效：本筆資料已被使用, 將不允許刪除！");
                }
                else
                {
                    string CurrentBookCode = thisRow.Cells[6].Text.ToString();
                    Label accid = (Label)thisRow.Cells[2].FindControl("Labellp_priorseq");
                    string CurrentPriorSeq = accid.Text;
                    int intCurrentPriorSeq = Convert.ToInt16(CurrentPriorSeq);
                    myad.deletec2_lprior(thisRow.Cells[0].Text);
                    BindGrid();


                    DataSet ds2 = myad.SelectMAXc2_lprior(CurrentBookCode);
                    DataView dv2 = ds2.Tables[0].DefaultView;
                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                    string rowfilterstr2 = "1=1";
                    dv2.RowFilter = rowfilterstr2;

                    // 檢查並輸出 最後 Row Filter 的結果
                    //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
                    //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

                    // 若搜尋結果為 "找不到" 的處理
                    string MaxLPSeq = "01";
                    int intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
                    if (dv2.Count > 0)
                    {
                        MaxLPSeq = dv2[0]["MaxSeq"].ToString();
                        intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
                        int intNextLPSeq = intCurrentPriorSeq + 1;

                        for (int i = intNextLPSeq; i <= intMaxLPSeq; i++)
                        {
                            //Response.Write("i= " + i + ", ");
                            string stri = Convert.ToString(i);
                            if (stri.Length < 2)
                                stri = "0" + stri;
                            //Response.Write("stri= " + stri + "<br>");

                            // 使用 DataSet 方法, 並指定使用的 table 名稱
                            DataSet ds3 = myad.Selectc2_lpriorMore();
                            DataView dv3 = ds3.Tables["c2_lprior"].DefaultView;

                            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                            string rowfilterstr3 = "1=1";
                            rowfilterstr3 = rowfilterstr3 + " AND lp_bkcd=" + CurrentBookCode;
                            rowfilterstr3 = rowfilterstr3 + " AND lp_priorseq=" + stri;
                            dv3.RowFilter = rowfilterstr3;

                            // 檢查並輸出 最後 Row Filter 的結果
                            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
                            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

                            if (dv3.Count > 0)
                            {
                                // 抓出 之後筆數之相關值 - 書籍代碼, 廣告版面代碼, 廣告色彩代碼, 廣告篇幅代碼
                                string iBookCode = dv3[0]["lp_bkcd"].ToString();
                                string iLayoutTypeCode = dv3[0]["lp_ltpcd"].ToString();
                                string iColorCode = dv3[0]["lp_clrcd"].ToString();
                                string iPageSizeCode = dv3[0]["lp_pgscd"].ToString();
                                //Response.Write("iBookCode= " + iBookCode + ", ");
                                //Response.Write("iLPSeq= " + stri + ", ");
                                //Response.Write("iLayoutTypeCode= " + iLayoutTypeCode + ", ");
                                //Response.Write("iColorCode= " + iColorCode + ", ");
                                //Response.Write("iPageSizeCode= " + iPageSizeCode + "<br>");

                                int intNewLPSeq = i - 1;
                                string strNewLPSeq = Convert.ToString(intNewLPSeq);
                                if (strNewLPSeq.Length < 2)
                                    strNewLPSeq = "0" + strNewLPSeq;
                                //Response.Write("strNewLPSeq= " + strNewLPSeq + "<br>");

                                // 執行更新動作
                                //string strConn9="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
                                myad.Updatec2_lprior(iBookCode, strNewLPSeq, iLayoutTypeCode, iColorCode, iPageSizeCode);
                            }
                        }
                    }
                    else
                    {
                        MaxLPSeq = MaxLPSeq;
                    }


                    BindGrid();
                    JavaScript.AlertMessage(this.Page, "資料刪除成功 !");
                }
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "查無此筆資料, 無法刪除!");
            }
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
            }
        }

        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void Query_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            tbxQString.Text = "";
            BindGrid();
        }

        private void BindNewDrop()
        {
            // 顯示下拉式選單 書籍類別的 DB 值
            DataSet ds2 = myad.NewBook();
            DataView dv2 = ds2.Tables[0].DefaultView;
            ddlBookCode.DataSource = dv2;
            ddlBookCode.DataTextField = "bk_nm";
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();

            // 顯示下拉式選單 廣告色彩的 DB 值
            DataSet ds3 = myad.Newc2_clr();
            DataView dv3 = ds3.Tables[0].DefaultView;
            ddlColorCode.DataSource = dv3;
            ddlColorCode.DataTextField = "clr_nm";
            ddlColorCode.DataValueField = "clr_clrcd";
            ddlColorCode.DataBind();

            // 顯示下拉式選單 廣告版面的 DB 值
            DataSet ds4 = myad.Newc2_ltp();
            DataView dv4 = ds4.Tables[0].DefaultView;
            ddlLayoutTypeCode.DataSource = dv4;
            ddlLayoutTypeCode.DataTextField = "ltp_nm";
            ddlLayoutTypeCode.DataValueField = "ltp_ltpcd";
            ddlLayoutTypeCode.DataBind();

            // 顯示下拉式選單 廣告篇幅的 DB 值
            DataSet ds5 = myad.Newc2_pgsize();
            DataView dv5 = ds5.Tables[0].DefaultView;
            ddPageSizeCode.DataSource = dv5;
            ddPageSizeCode.DataTextField = "pgs_nm";
            ddPageSizeCode.DataValueField = "pgs_pgscd";
            ddPageSizeCode.DataBind();
        }
    }
}