using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adpub_act1 : System.Web.UI.Page
    {
        adpub_act1_DB myadpub = new adpub_act1_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    switch (Request["action"].ToString().Trim())
                    {
                        case "1":
                            {
                                lbtitle.Text = "廣告排版動作 步驟一";
                                break;
                            }
                        case "2":
                            {
                                lbtitle.Text = "美編樣後修正 步驟一";
                                break;
                            }
                        default:
                            {
                                JavaScript.AlertMessageRedirect(this.Page, "參數錯誤", "adpub_act1.aspx?action=1");
                                break;
                            }
                    }
                }
                catch
                {
                    JavaScript.AlertMessageRedirect(this.Page, "參數錯誤", "adpub_act1.aspx?action=1");
                }

                SearchIcon.Visible = false;
                // 給 截止年月 tbxYYYYMM 預設值 (今天年月)
                this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();

                // 書籍類別給預設值
                //this.ddlBookCode.SelectedItem.Value = "00";

                // 清空查詢結果的訊息
                lblMessage.Text = "";


                // 顯示下拉式選單 書籍類別的 DB 值
                // 關於 nostr, 請參 sqlDataAdapter3.Select statement; 
                // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
                DataSet ds2 = myadpub.SelectBook();
                DataView dv2 = ds2.Tables["book"].DefaultView;
                ddlBookCode.DataSource = dv2;
                dv2.RowFilter = "proj_fgitri=''";
                ddlBookCode.DataTextField = "bk_nm";
                //ddlBookCode.DataValueField="nostr";
                // 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
                ddlBookCode.DataValueField = "bk_bkcd";
                ddlBookCode.DataBind();
            }
        }

        protected void BtnRedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ContNo = thisRow.Cells[0].Text.Trim();
            string YYYYMM = this.tbxPubDate.Text.ToString().Trim();
            YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
            string PubSeq = thisRow.Cells[1].Text.Trim();
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();

            string strbuf = "PubFm.aspx?contno=" + ContNo + "&bkcd=" + strBkcd + "&fgnew=1";


            this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>");
        }

        protected void BtnRedrectEdit2(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ContNo = thisRow.Cells[0].Text.Trim();
            string YYYYMM = this.tbxPubDate.Text.ToString().Trim();
            YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
            string PubSeq = thisRow.Cells[1].Text.Trim();
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();

            string strbuf = "PubFm.aspx?contno=" + ContNo + "&bkcd=" + strBkcd + "&fgnew=1";

            this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>");
        }


        protected void lnbShow_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            // 清除 DataGrid1
            GV1.Visible = false;
            GV2.Visible = false;

            // 檢查是否有資料不合理 - 該落版之無廣告優先次序
            CheckLPriorSeqisNull();

            // 檢查是否有資料不合理 - 該落版(特殊版面)的刊登頁碼為 0 (因特殊版面皆為固定頁次, 故不允許此)
            CheckSpecialPgNo();

        }

        // 檢查是否有資料不合理 - 該落版之無廣告優先次序
        private void CheckLPriorSeqisNull()
        {
            // 抓出 網頁變數
            string bkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
            yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myadpub.SelectC2_pub();
            DataView dv3 = ds3.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND pub_bkcd = '" + bkcd + "'";
            rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm = '" + yyyyymm + "'";
            rowfilterstr3 = rowfilterstr3 + " AND (lp_priorseq IS NULL)";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若有資料須修正時, 顯示 DataGrid1
            if (dv3.Count > 0)
            {
                this.lblMessage.Text = "很抱歉, 您必須修正：１．以下 " + dv3.Count + " 筆不合理的資料項(廣告優先次序未指定或不合理), 才能繼續進行排版動作!<br>２．全部修正完, 請再按一次 '查詢' 按鈕來繼續進行排版!";
                BindGrid1();
            }
            else
            {
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds1 = myadpub.SelectC2_pub2();
                DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
                string rowfilterstr1 = "1=1";

                // 若書籍類別有選擇(即<>00)的話, 則給予 SQL Filter 條件
                if (ddlBookCode.SelectedItem.Value.ToString() != "")
                    rowfilterstr1 = rowfilterstr1 + " and (pub_bkcd = '" + bkcd + "')";
                else
                    rowfilterstr1 = rowfilterstr1;

                // 刊登年月, 則給予 SQL Filter 條件
                rowfilterstr1 = rowfilterstr1 + " and (pub_yyyymm like '%" + yyyyymm + "%')";
                dv1.RowFilter = rowfilterstr1;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv.Count= "+ dv.Count + "<BR>");
                //Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

                // 若搜尋結果為 "找不到" 的處理
                if (dv1.Count == 0)
                    lblMessage.Text = "結果: 找不到符合條件的資料, 您可以重設條件!";
                else
                {
                    // 檢查並輸出 最後 Row Filter 的結果
                    //Response.Write("rowfilterstr= " + rowfilterstr + "<BR>");

                    // 抓出下一步驟要轉址到什處去?  (因此網頁由 2.3.1 & 2.3.2 共用)
                    // action=1 => 2.3.1 廣告落版動作; action=2 => 2.3.2 美編樣後修正
                    string RedirectURL = "";
                    if (Context.Request.QueryString["action"] == "1")
                        RedirectURL = "adpub_act2.aspx?bkcd=" + bkcd + "&yyyymm=" + yyyyymm;
                    else if (Context.Request.QueryString["action"] == "2")
                        RedirectURL = "adpub_actupdate.aspx?bkcd=" + bkcd + "&yyyymm=" + yyyyymm;

                    //Response.Write("dv.Count= "+ dv.Count + "<BR>");
                    lblMessage.Text = "結果: 找到 <B>" + dv1.Count.ToString() + "</B>筆資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_self'>此連結</A> 來繼續進行下一動作!<br>";

                    //DataGrid1.DataSource=dv;
                    //DataGrid1.DataBind();
                }
            }
        }


        private void BindGrid1()
        {
            // 顯示 DataGrid1
            GV1.Visible = true;

            // 抓出 網頁變數
            string bkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
            string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
            yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myadpub.SelectC2_pub();
            DataView dv3 = ds3.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND pub_bkcd = '" + bkcd + "'";
            rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm = '" + yyyyymm + "'";
            rowfilterstr3 = rowfilterstr3 + " AND (lp_priorseq IS NULL) ";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若有資料須修正時, 顯示 DataGrid1
            if (dv3.Count > 0)
            {
                GV1.DataSource = dv3;
                GV1.DataBind();
            }
        }


        // 檢查是否有資料不合理 - 該落版(特殊版面)的刊登頁碼為 0 (因特殊版面皆為固定頁次, 故不允許此)
        private void CheckSpecialPgNo()
        {
            // 抓出 網頁變數
            string bkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
            string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
            yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myadpub.SelectC2_pub();
            DataView dv3 = ds3.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_bkcd = '" + bkcd + "')";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_yyyymm = '" + yyyyymm + "')";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_ltpcd = '50')";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_pgno = 0)";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_fgfixpg = '1')";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若有資料須修正時, 顯示 DataGrid1
            if (dv3.Count > 0)
            {
                this.lblMessage.Text = "很抱歉, 您必須修正：１．以下 " + dv3.Count + " 筆不合理的資料項<br>(一般版面資料若為 '固定頁次(是)', 其'刊登頁碼'不允許為0), <br>&nbsp;&nbsp;才能繼續進行排版動作!<br>２．全部修正完, 請再按一次 '查詢' 按鈕來繼續進行排版!";
                BindGrid2();
            }
        }


        private void BindGrid2()
        {
            // 顯示 DataGrid2
            GV2.Visible = true;


            // 抓出 網頁變數
            string bkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
            string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
            yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myadpub.SelectC2_pub();
            DataView dv3 = ds3.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND pub_bkcd = '" + bkcd + "'";
            rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm = '" + yyyyymm + "'";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_ltpcd = '50')";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_pgno = 0)";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_fgfixpg = '1')";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若有資料須修正時, 顯示 DataGrid1
            if (dv3.Count > 0)
            {
                GV2.DataSource = dv3;
                GV2.DataBind();
                // 結束 if(dv3.Count > 0)
            }
        }


        protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 廣告版面
                string strltpcd = e.Row.Cells[2].Text.Trim();
                string strLtpName = "";

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds5 = myadpub.SelectC2_ltp();
                DataView dv5 = ds5.Tables["c2_ltp"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr5 = "1=1";
                rowfilterstr5 = rowfilterstr5 + " AND ltp_ltpcd='" + strltpcd + "'";
                dv5.RowFilter = rowfilterstr5;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
                //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

                if (dv5.Count > 0)
                {
                    // 抓出相對應的 名稱
                    strLtpName = dv5[0]["ltp_nm"].ToString().Trim();
                    e.Row.Cells[2].Text = strLtpName;
                }


                // 廣告色彩
                string strclrcd = e.Row.Cells[3].Text.Trim();
                string strClrName = "";

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds4 = myadpub.SelectC2_clr();
                DataView dv4 = ds4.Tables["c2_clr"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr4 = "1=1";
                rowfilterstr4 = rowfilterstr4 + " AND clr_clrcd='" + strclrcd + "'";
                dv4.RowFilter = rowfilterstr4;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                if (dv4.Count > 0)
                {
                    // 抓出相對應的 名稱
                    strClrName = dv4[0]["clr_nm"].ToString().Trim();
                    e.Row.Cells[3].Text = strClrName;
                }


                // 廣告篇幅
                string strpgscd = e.Row.Cells[4].Text.Trim();
                string strPgsName = "";

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds6 = myadpub.SelectC2_pgsize();
                DataView dv6 = ds6.Tables["c2_pgsize"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr6 = "1=1";
                rowfilterstr6 = rowfilterstr6 + " AND pgs_pgscd='" + strpgscd + "'";
                dv6.RowFilter = rowfilterstr6;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                if (dv6.Count > 0)
                {
                    // 抓出相對應的 名稱
                    strPgsName = dv6[0]["pgs_nm"].ToString().Trim();
                    e.Row.Cells[4].Text = strPgsName;
                }


                // 到稿註記
                string strfgGot = e.Row.Cells[5].Text.Trim();
                string strfgGotText = "";
                if (strfgGot == "1")
                    strfgGotText = "<font color='Red'>否</font>";
                else
                    strfgGotText = "是";
                e.Row.Cells[5].Text = strfgGotText;


                // 稿件類別
                string strDrafttp = e.Row.Cells[6].Text.Trim();
                switch (strDrafttp)
                {
                    case "1":
                        e.Row.Cells[6].Text = "舊稿";
                        break;
                    case "2":
                        e.Row.Cells[6].Text = "新稿";
                        break;
                    case "3":
                        e.Row.Cells[6].Text = "改稿";
                        break;
                    default:
                        break;
                }


                // 前往修改 的按鈕 - 見 DataGrid1_ItemCommand()

                // 結束 for loop

            }
        }

        protected void GV2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 刊登年月
                string strYYYYMM = e.Row.Cells[1].Text.Trim();
                strYYYYMM = strYYYYMM.Substring(0, 4) + "/" + strYYYYMM.Substring(4, 2);
                e.Row.Cells[1].Text = strYYYYMM;


                // 固定頁次註記
                string strfixpg = e.Row.Cells[4].Text.Trim();
                if (strfixpg == "0")
                    e.Row.Cells[4].Text = "否";
                else
                    e.Row.Cells[4].Text = "是";


                // 廣告版面
                string strltpcd = e.Row.Cells[5].Text.Trim();
                string strLtpName = "";

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds5 = myadpub.SelectC2_ltp();
                DataView dv5 = ds5.Tables["c2_ltp"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr5 = "1=1";
                rowfilterstr5 = rowfilterstr5 + " AND ltp_ltpcd='" + strltpcd + "'";
                dv5.RowFilter = rowfilterstr5;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
                //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

                if (dv5.Count > 0)
                {
                    // 抓出相對應的 名稱
                    strLtpName = dv5[0]["ltp_nm"].ToString().Trim();
                    e.Row.Cells[5].Text = strLtpName;
                }


                // 廣告色彩
                string strclrcd = e.Row.Cells[6].Text.Trim();
                string strClrName = "";

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds4 = myadpub.SelectC2_clr();
                DataView dv4 = ds4.Tables["c2_clr"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr4 = "1=1";
                rowfilterstr4 = rowfilterstr4 + " AND clr_clrcd='" + strclrcd + "'";
                dv4.RowFilter = rowfilterstr4;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                if (dv4.Count > 0)
                {
                    // 抓出相對應的 名稱
                    strClrName = dv4[0]["clr_nm"].ToString().Trim();
                    e.Row.Cells[6].Text = strClrName;
                }


                // 廣告篇幅
                string strpgscd = e.Row.Cells[7].Text.Trim();
                string strPgsName = "";

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds6 = myadpub.SelectC2_pgsize();
                DataView dv6 = ds6.Tables["c2_pgsize"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr6 = "1=1";
                rowfilterstr6 = rowfilterstr6 + " AND pgs_pgscd='" + strpgscd + "'";
                dv6.RowFilter = rowfilterstr6;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                if (dv6.Count > 0)
                {
                    // 抓出相對應的 名稱
                    strPgsName = dv6[0]["pgs_nm"].ToString().Trim();
                    e.Row.Cells[7].Text = strPgsName;
                }


                // 到稿註記
                string strfgGot = e.Row.Cells[8].Text.Trim();
                string strfgGotText = "";
                if (strfgGot == "1")
                    strfgGotText = "<font color='Red'>否</font>";
                else
                    strfgGotText = "是";
                e.Row.Cells[8].Text = strfgGotText;


                // 稿件類別
                string strDrafttp = e.Row.Cells[9].Text.Trim();
                switch (strDrafttp)
                {
                    case "1":
                        e.Row.Cells[9].Text = "舊稿";
                        break;
                    case "2":
                        e.Row.Cells[9].Text = "新稿";
                        break;
                    case "3":
                        e.Row.Cells[9].Text = "改稿";
                        break;
                    default:
                        break;
                }


                // 前往修改 的按鈕 - 見 DataGrid1_ItemCommand()

                // 結束 for loop
            }
        }
    }
}