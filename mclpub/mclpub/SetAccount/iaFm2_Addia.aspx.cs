using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.SetAccount
{
    public partial class iaFm2_Addia : System.Web.UI.Page
    {
        iaFm2_Addia_DB myiaFm2 = new iaFm2_Addia_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialData();
                SearchIcon.Visible = false;

                serverID.Value = tbxYYYYMM.ClientID + "," + DataGrid1.ID;
            }
        }

        // 載入初始資料
        private void InitialData()
        {
            this.lblMessage.Text = "";


            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter2.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds1 = myiaFm2.Selectbook();
            DataView dv1 = ds1.Tables[0].DefaultView;
            ddlBkcd.DataSource = dv1;
            dv1.RowFilter = "proj_fgitri=''";
            ddlBkcd.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBkcd.DataValueField = "bk_bkcd";
            ddlBkcd.DataBind();
            this.ddlBkcd.SelectedIndex = 0;

            this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM");


            // 隱藏發票開立資料
            this.pnlPub.Visible = false;
            this.pnlPubProjError.Visible = false;
            this.btnPickReset.Visible = false;
            this.lblMemo2.Visible = false;
            this.lblMemo3.Visible = false;
            this.btnCreateIA.Visible = false;
            this.lblPickMessage.Text = "";
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            CheckPubProj();
        }


        // 檢查落版檔的計劃代號是否合理 (與傳票檔 refd 做比較)
        private void CheckPubProj()
        {
            if (tbxYYYYMM.Text.Length != 7 && tbxYYYYMM.Text.IndexOf("/") == 4)
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }
            // 抓出畫面上的值, 作為篩選資料的條件
            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            //string StrSQL="select * from c2_cont";//旻修 2005/11/29新增
            //sqlDataAdapter cmdSQL=new sqlDataAdapter(strSQL,)
            DataSet ds10 = myiaFm2.Selectc2_cont();
            DataView dv10 = ds10.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr10 = "1=1";
            //旻修測試->string rowfilterstr10 = "cont_conttp=01";
            rowfilterstr10 = rowfilterstr10 + " AND cont_bkcd='" + strBkcd + "'";
            rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm<='" + strYYYYMM + "'";
            // 下一行之備註: 因區隔材料所的上線資訊, 故舊落版資料小於等於 200209 的, 將不准再出現於 發票產生 流程中
            // 以免舊資訊重覆開立發票資料, 造成困擾.//20051129旻修暫時將此行註解//
            rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm>='200209'";
            dv10.RowFilter = rowfilterstr10;

            // Order By Filter
            if (this.ddlOrderByFilter.SelectedItem.Value == "1")
            {
                dv10.Sort = "cont_contno";
            }
            else if (this.ddlOrderByFilter.SelectedItem.Value == "2")
            {
                dv10.Sort = "cont_empno";
            }

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv10.Count= "+ dv10.Count + "<BR>");
            //Response.Write("dv10.RowFilter= " + dv10.RowFilter + "<BR>");

            // 若搜尋結果為 "找到" 的處理
            if (dv10.Count > 0)
            {
                // 顯示錯誤之落版資料
                this.pnlPub.Visible = false;
                this.pnlPubProjError.Visible = true;
                this.lblMemo3.Visible = true;

                DataGrid2.DataSource = dv10;
                DataGrid2.DataBind();
            }
            else
            {
                // 顯示發票開立資料
                this.pnlPub.Visible = true;
                this.pnlPubProjError.Visible = false;
                

                // 檢查當月是否已做挑選或開立動作, 再判斷是否轉址
                CheckIAStatus();


                BindGrid1();
            }
        }

        public void CheckIAStatus()
        {
            // 抓出畫面上的值, 作為篩選資料的條件
            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strBkName = this.ddlBkcd.SelectedItem.Text.ToString().Trim();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strBkName= " + strBkName + "<br>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myiaFm2.Selectc2_cont2();
            DataView dv3 = ds3.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND (iab_iabdate = '" + strYYYYMM + "')";
            rowfilterstr3 = rowfilterstr3 + " AND (pub_bkcd = '" + strBkcd + "')";
            dv3.RowFilter = rowfilterstr3;


            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 當月 "已" 做挑選或開立動作
            if (dv3.Count > 0)
            {
                this.tbxIAStatus.Text = "1";
                hidIAStatus.Value = "1";

                // 以下改以 Javascript 之 Client端 來判斷
                // 以 Javascript 的 window.alert()  來告知訊息
                JavaScript.AlertMessage(this.Page, " " + strBkName + "當月已開立過發票開立單!");
            }
            // 當月 "尚未" 做挑選或開立動作
            else
            {
                this.tbxIAStatus.Text = "0";
                hidIAStatus.Value = "0";
            }
            //Response.Write("this.hidIAStatus.Value= " + this.hidIAStatus.Value + "<br>");
        }

        // 顯示 DataGrid1
        private void BindGrid1()
        {
            // 抓出畫面上的值, 作為篩選資料的條件
            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strBkName = this.ddlBkcd.SelectedItem.Text.ToString().Trim();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strBkName= " + strBkName + "<br>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myiaFm2.Selectc2_cont3();
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";
            rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm<='" + strYYYYMM + "'";
            // 下一行之備註: 因區隔材料所的上線資訊, 故舊落版資料小於等於 200209 的, 將不准再出現於 發票產生 流程中
            // 以免舊資訊重覆開立發票資料, 造成困擾.
            rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm>='200209'";
            dv2.RowFilter = rowfilterstr2;

            // Order By Filter
            if (this.ddlOrderByFilter.SelectedItem.Value == "1")
            {
                dv2.Sort = "cont_contno";
            }
            else if (this.ddlOrderByFilter.SelectedItem.Value == "2")
            {
                dv2.Sort = "cont_empno";
            }

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

            // 若搜尋結果為 "找到" 的處理
            if (dv2.Count > 0)
            {
                DataGrid1.DataSource = dv2;
                DataGrid1.DataBind();

                // 判斷當月是否已開立過 發票開立單, 並給予訊息告知
                if (this.tbxIAStatus.Text.ToString().Trim() == "0")
                {
                    this.lblMessage.Text = "<font color='Red'>" + strBkName + " " + this.tbxYYYYMM.Text.ToString().Trim() + " 尚未開立過</font>發票開立單; ";
                }
                else
                {
                    this.lblMessage.Text = "<font color='Red'>" + strBkName + " " + this.tbxYYYYMM.Text.ToString().Trim() + " 已開立過</font>發票開立單 (您可檢視檢核表來查詢). ";
                }
                this.lblMessage.Text = this.lblMessage.Text + "目前尚有 <font color='Red'>" + dv2.Count + "</font> 筆落版資料可供開立!";


                // 顯示相關按鈕
                this.btnPickReset.Visible = true;
                this.lblMemo2.Visible = true;
                this.btnCreateIA.Visible = true;
                SearchIcon.Visible = true;
            }
            else
            {
                this.lblMessage.Text = "本月已無落版資料須開立！(或請重設搜尋條件)";
                this.pnlPub.Visible = false;
                SearchIcon.Visible = false;
            }
        }

        protected void DataGrid2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 合約類別
                string conttp = e.Row.Cells[2].Text.ToString().Trim();
                //Response.Write("conttp= " + conttp + "<br>");
                if (conttp == "01")
                    e.Row.Cells[2].Text = "一般";
                else if (conttp == "09")
                    e.Row.Cells[2].Text = "<font color='Red'>推廣</font>";

                // 合約起日
                string StartDate = e.Row.Cells[3].Text.ToString().Trim();
                StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                //Response.Write("StartDate= " + StartDate + "<br>");
                e.Row.Cells[3].Text = StartDate;

                // 合約迄日
                string EndDate = e.Row.Cells[4].Text.ToString().Trim();
                EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                //Response.Write("EndDate= " + EndDate + "<br>");
                e.Row.Cells[4].Text = EndDate;

                // 刊登年月 -- 針對不同月份, 整行給予不同顏色標示
                string yyyymm = e.Row.Cells[12].Text.ToString().Trim();
                //Response.Write("yyyymm= " + yyyymm + "<br>");
                if (yyyymm != strYYYYMM)
                {
                    e.Row.Cells[12].ForeColor = System.Drawing.Color.DarkOrange;
                    e.Row.BackColor = System.Drawing.Color.Lavender;
                }
                e.Row.Cells[12].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);

                // 固定頁次註記
                string fgfixpg = e.Row.Cells[20].Text.ToString().Trim();
                //Response.Write("fgfixpg= " + fgfixpg + "<br>");
                if (fgfixpg == "0")
                    e.Row.Cells[20].Text = "否";
                else
                    e.Row.Cells[20].Text = "是";

                // 稿件類別
                string drafttp = e.Row.Cells[21].Text.ToString().Trim();
                //Response.Write("drafttp= " + drafttp + "<br>");
                switch (drafttp)
                {
                    case "1":
                        e.Row.Cells[21].Text = "舊稿";

                        // 清除其他不相關資料
                        e.Row.Cells[22].Text = "";
                        e.Row.Cells[23].Text = "";
                        e.Row.Cells[24].Text = "";
                        break;
                    case "2":
                        e.Row.Cells[21].Text = "新稿";

                        // 到稿註記
                        string fggot1 = e.Row.Cells[23].Text.ToString().Trim();
                        //Response.Write("fggot1= " + fggot1 + "<br>");
                        if (fggot1 == "0")
                            e.Row.Cells[23].Text = "否";
                        else
                            e.Row.Cells[23].Text = "是";

                        // 清除其他不相關資料
                        e.Row.Cells[24].Text = "";
                        e.Row.Cells[25].Text = "";
                        break;
                    case "3":
                        e.Row.Cells[21].Text = "改稿";

                        // 到稿註記
                        string fggot2 = e.Row.Cells[23].Text.ToString().Trim();
                        //Response.Write("fggot2= " + fggot2 + "<br>");
                        if (fggot2 == "0")
                            e.Row.Cells[23].Text = "否";
                        else
                            e.Row.Cells[23].Text = "是";

                        // 清除其他不相關資料
                        e.Row.Cells[22].Text = "";
                        e.Row.Cells[25].Text = "";
                        break;
                    default:
                        e.Row.Cells[21].Text = "舊稿";

                        // 清除其他不相關資料
                        e.Row.Cells[22].Text = "";
                        e.Row.Cells[23].Text = "";
                        e.Row.Cells[24].Text = "";
                        break;
                }

            }

        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("newDate", e.Row.Cells[12].Text.Trim());

                string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式

                    // 合約類別
                    string conttp = e.Row.Cells[2].Text.ToString().Trim();
                    //Response.Write("conttp= " + conttp + "<br>");
                    if (conttp == "01")
                        e.Row.Cells[2].Text = "一般";
                    else if (conttp == "09")
                        e.Row.Cells[2].Text = "<font color='Red'>推廣</font>";

                    // 合約起日
                    string StartDate = e.Row.Cells[3].Text.ToString().Trim();
                    StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                    //Response.Write("StartDate= " + StartDate + "<br>");
                    e.Row.Cells[3].Text = StartDate;

                    // 合約迄日
                    string EndDate = e.Row.Cells[4].Text.ToString().Trim();
                    EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                    //Response.Write("EndDate= " + EndDate + "<br>");
                    e.Row.Cells[4].Text = EndDate;

                    // 刊登年月 -- 針對不同月份, 整行給予不同顏色標示
                    string yyyymm = e.Row.Cells[12].Text.ToString().Trim();
                    //Response.Write("yyyymm= " + yyyymm + "<br>");
                    if (yyyymm != strYYYYMM)
                    {
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.DarkOrange;
                        //e.Row.BackColor = System.Drawing.Color.Lavender;
                       // e.Row.Attributes.Add("style", "background-color:Lavender !important");
                    }
                    e.Row.Cells[12].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);

                    // 固定頁次註記
                    string fgfixpg = e.Row.Cells[20].Text.ToString().Trim();
                    //Response.Write("fgfixpg= " + fgfixpg + "<br>");
                    if (fgfixpg == "0")
                        e.Row.Cells[20].Text = "否";
                    else
                        e.Row.Cells[20].Text = "是";

                    // 稿件類別
                    string drafttp = e.Row.Cells[21].Text.ToString().Trim();
                    //Response.Write("drafttp= " + drafttp + "<br>");
                    switch (drafttp)
                    {
                        case "1":
                            e.Row.Cells[21].Text = "舊稿";

                            // 清除其他不相關資料
                            e.Row.Cells[22].Text = "";
                            e.Row.Cells[23].Text = "";
                            e.Row.Cells[24].Text = "";
                            break;
                        case "2":
                            e.Row.Cells[21].Text = "新稿";

                            // 到稿註記
                            string fggot1 = e.Row.Cells[23].Text.ToString().Trim();
                            //Response.Write("fggot1= " + fggot1 + "<br>");
                            if (fggot1 == "0")
                                e.Row.Cells[23].Text = "否";
                            else
                                e.Row.Cells[23].Text = "是";

                            // 清除其他不相關資料
                            e.Row.Cells[24].Text = "";
                            e.Row.Cells[25].Text = "";
                            break;
                        case "3":
                            e.Row.Cells[21].Text = "改稿";

                            // 到稿註記
                            string fggot2 = e.Row.Cells[23].Text.ToString().Trim();
                            //Response.Write("fggot2= " + fggot2 + "<br>");
                            if (fggot2 == "0")
                                e.Row.Cells[23].Text = "否";
                            else
                                e.Row.Cells[23].Text = "是";

                            // 清除其他不相關資料
                            e.Row.Cells[22].Text = "";
                            e.Row.Cells[25].Text = "";
                            break;
                        default:
                            e.Row.Cells[21].Text = "舊稿";

                            // 清除其他不相關資料
                            e.Row.Cells[22].Text = "";
                            e.Row.Cells[23].Text = "";
                            e.Row.Cells[24].Text = "";
                            break;
                    }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string Syscd = "C2";
            string ContNo = thisRow.Cells[1].Text.ToString().Trim();
            string YYYYMM = thisRow.Cells[12].Text.ToString().Trim();
            YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
            string PubSeq = thisRow.Cells[13].Text.ToString().Trim();
            string strBkcd = thisRow.Cells[31].Text.ToString();

            // 轉址動作
            string strbuf = "../Layout/PubFm.aspx?contno=" + ContNo + "&bkcd=" + strBkcd + "&fgnew=1";
            //Response.Write("strbuf= " + strbuf + "<br>");

            JavaScript.PopUp(this.Page, strbuf);
            // 以 Javascript 的 window.close() 來告知訊息
        }

        protected void btnConfirmAmt_Click(object sender, EventArgs e)
        {
            // 將已挑選的落版資料 pub_fginved 值做註記 (由 ' ' 改為 't' (意指 temp)), 好由 DataGrid2 呼叫
            UpdatefgTemp();


            // 告知 被挑選之總筆數
            CountPick();
            // Refresh DataGrid1
            //DataGrid1.CurrentPageIndex=0;
            //BindGrid1();
            // 開啟新視窗 - 預覽 發票開立單 (列印清單) 的處理
            doPrintList();
        }


        // 將已挑選的落版資料 pub_fginved 值做註記 (由 ' ' 改為 't' (意指 temp)), 好由 DataGrid2 呼叫
        private void UpdatefgTemp()
        {
            // 抓出 DataGrid1 被挑選的資料
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                // 檢查被挑選的狀態值
                bool strSelect = ((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked;
                //Response.Write("strSelect= " + strSelect + "<br>");

                // 抓出畫面上的值, 作為篩選資料的條件
                string strSyscd = "C2";
                string strContNo = DataGrid1.Rows[i].Cells[1].Text.ToString().Trim(); ;
                string strYYYYMM = DataGrid1.Rows[i].Cells[12].Text.ToString().Trim();
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
                string strPubSeq = DataGrid1.Rows[i].Cells[13].Text.ToString().Trim();
                //Response.Write("strSyscd= " + strSyscd + ", ");
                //Response.Write("strContNo= " + strContNo + ", ");
                //Response.Write("strYYYYMM= " + strYYYYMM + ", ");
                //Response.Write("strPubSeq= " + strPubSeq + "<br>");

                // 抓出被挑選的資料
                if (strSelect == true)
                {
                    // 更新 '被挑選' 的落版資料之 pub_fginved 從 ' ' 變為 't'
                    // 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
                    //Response.Write(this.sqlCommand1.CommandText);
                    try
                    {
                        myiaFm2.UPDATEc2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq, "t");
                        //Response.Write("落版資料更新成功");
                    }
                    catch (System.Data.SqlClient.SqlException ex1)
                    {
                        throw new Exception(ex1.Message);
                        //Response.Write("落版資料更新失敗");
                    }
                    // 結束 if(strSelect == true)
                }
                else
                {
                    // 更新 '沒有被挑選' 的落版資料之 pub_fginved 從 't' 變為 ' '
                    // 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 更新
                    //Response.Write(this.sqlCommand2.CommandText);
                    try
                    {
                        myiaFm2.UPDATEc2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq, "");
                        //Response.Write("落版資料更新成功");
                    }
                    catch (System.Data.SqlClient.SqlException ex2)
                    {
                        throw new Exception(ex2.Message);
                        //Response.Write("落版資料更新失敗");
                    }
                }
                // 結束 for(int i=0; i < DataGrid1.Items.Count; i++)
            }
        }

        // 告知 被挑選之總筆數
        private void CountPick()
        {
            // 抓出畫面上的值, 作為篩選資料的條件
            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds4 = myiaFm2.Selectc2_cont4();
            DataView dv4 = ds4.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr4 = "1=1";
            rowfilterstr4 = rowfilterstr4 + " AND cont_bkcd='" + strBkcd + "'";
            rowfilterstr4 = rowfilterstr4 + " AND pub_yyyymm<='" + strYYYYMM + "'";
            dv4.RowFilter = rowfilterstr4;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
            //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

             //若搜尋結果為 "找到" 的處理
            if (dv4.Count > 0)
            {
                this.lblPickMessage.Text = "您目前已挑選 " + dv4.Count + " 筆落版資料來開立!";
            }
            else
            {
                this.lblPickMessage.Text = "您目前沒有挑選落版資料來開立!";
            }
        }

        // 開啟新視窗 - 預覽 發票開立單 (列印清單) 的處理
        private void doPrintList()
        {
            if (tbxYYYYMM.Text.Length != 7 && tbxYYYYMM.Text.IndexOf("/") == 4)
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }

            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string strSortFilter = this.ddlOrderByFilter.SelectedItem.Value.ToString().Trim();

            DataSet ds10 = myiaFm2.Selectv_c2_iaFm2_prelist2();
            DataView dv = ds10.Tables[0].DefaultView;

            DataSet ds = myiaFm2.SelectdistinctContno(strBkcd, strYYYYMM);//用來算匯出EXCEL的時候 總共會多出幾個小計

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr10 = "1=1";
            //旻修測試->string rowfilterstr10 = "cont_conttp=01";
            rowfilterstr10 = rowfilterstr10 + " AND cont_bkcd='" + strBkcd + "'";
            rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm<='" + strYYYYMM + "'";
            // 下一行之備註: 因區隔材料所的上線資訊, 故舊落版資料小於等於 200209 的, 將不准再出現於 發票產生 流程中
            // 以免舊資訊重覆開立發票資料, 造成困擾.//20051129旻修暫時將此行註解//
            rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm>='200209'";
            dv.RowFilter = rowfilterstr10;

            if (this.ddlOrderByFilter.SelectedItem.Value == "1")
            {
                dv.Sort = "pub_contno";
            }
            else if (this.ddlOrderByFilter.SelectedItem.Value == "2")
            {
                dv.Sort = "cont_empno";
            }

            if (dv.Count <= 0)
            {
                JavaScript.AlertMessage(this.Page, "無資料");
                return;
            }

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/SetAccount/template/iaFm2_prelist2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A6:S6");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A7:S7");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:S1");

            if (dv.Count + ds.Tables[0].Rows.Count == 1)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (dv.Count + ds.Tables[0].Rows.Count > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 8; i < dv.Count + 8 - 2 + ds.Tables[0].Rows.Count; i++)//加上小計
                    {
                        countback++;
                        if (countback % 2 == 0)
                        {
                            //藍色
                            Xls.InsertAndCopyRange(myRangeBlue, i, 1, 1, TFlxInsertMode.NoneDown);

                        }
                        else
                        {
                            //白色
                            Xls.InsertAndCopyRange(myRange, i, 1, 1, TFlxInsertMode.NoneDown);
                        }
                    }
                }
            }

            Xls.SetCellValue(3, 4, ddlBkcd.SelectedItem.Text.ToString());
            Xls.SetCellValue(4, 4, tbxYYYYMM.Text.Trim());
            Xls.SetCellValue(3, 18, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(4, 18, DateTime.Now.ToString("yyyy/MM/dd"));

            string preNo = "";
            string preIMSeq = "";
            int count = 0;
            int Xvalue = 0;
            int sum_pubadamt = 0;
            int sum_pubchgamt = 0;
            int sum_pubtotamt = 0;

            int TotalAdamt = 0;
            int TotalChgamt = 0;
            int Totalamt = 0;

            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["pub_contno"].ToString().Trim() != preNo)
                {
                    if (Xvalue != 0)
                    {
                        Xls.SetCellValue(Xvalue + 6, 1, "");
                        Xls.SetCellValue(Xvalue + 6, 2, "");
                        Xls.SetCellValue(Xvalue + 6, 3, "");
                        Xls.SetCellValue(Xvalue + 6, 4, "");
                        Xls.SetCellValue(Xvalue + 6, 5, "");
                        Xls.SetCellValue(Xvalue + 6, 6, "");
                        Xls.SetCellValue(Xvalue + 6, 7, "");
                        Xls.SetCellValue(Xvalue + 6, 8, "");
                        Xls.SetCellValue(Xvalue + 6, 9, "");
                        Xls.SetCellValue(Xvalue + 6, 10, "");
                        Xls.SetCellValue(Xvalue + 6, 11, "");
                        Xls.SetCellValue(Xvalue + 6, 12, "");
                        Xls.SetCellValue(Xvalue + 6, 13, "");
                        Xls.SetCellValue(Xvalue + 6, 14, "");
                        Xls.SetCellValue(Xvalue + 6, 15, "");
                        Xls.SetCellValue(Xvalue + 6, 16, "小計：");
                        Xls.SetCellValue(Xvalue + 6, 17, sum_pubadamt);
                        Xls.SetCellValue(Xvalue + 6, 18, sum_pubchgamt);
                        Xls.SetCellValue(Xvalue + 6, 19, sum_pubtotamt);
                        Xvalue++;
                    }


                    Xls.SetCellValue(Xvalue + 6, 1, count + 1);
                    count++;
                    Xls.SetCellValue(Xvalue + 6, 2, dv[i]["pub_contno"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 3, dv[i]["cont_sedate"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 4, dv[i]["cont_mfrno"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 5, dv[i]["mfr_inm"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 6, dv[i]["srspn_cname"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 7, dv[i]["cont_totamt"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 8, dv[i]["im_nm"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 9, dv[i]["im_mfrinm"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 10, dv[i]["im_zip"].ToString().Trim() + " " + dv[i]["im_addr"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 11, dv[i]["im_invcdText"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 12, dv[i]["im_taxtpText"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 13, dv[i]["pub_yyyymm"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 14, dv[i]["pub_pubseq"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 15, dv[i]["clr_nm"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 16, dv[i]["pub_projno"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 17, dv[i]["pub_adamt"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 18, dv[i]["pub_chgamt"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 6, 19, dv[i]["pub_totamt"].ToString().Trim());
                    Xvalue++;

                    sum_pubadamt = Convert.ToInt32(dv[i]["pub_adamt"].ToString().Trim());
                    sum_pubchgamt = Convert.ToInt32(dv[i]["pub_chgamt"].ToString().Trim());
                    sum_pubtotamt = Convert.ToInt32(dv[i]["pub_totamt"].ToString().Trim());
                }
                else
                {
                    if (dv[i]["pub_imseq"].ToString().Trim() != preIMSeq)
                    {
                        if (Xvalue != 0)
                        {
                            Xls.SetCellValue(Xvalue + 6, 1, "");
                            Xls.SetCellValue(Xvalue + 6, 2, "");
                            Xls.SetCellValue(Xvalue + 6, 3, "");
                            Xls.SetCellValue(Xvalue + 6, 4, "");
                            Xls.SetCellValue(Xvalue + 6, 5, "");
                            Xls.SetCellValue(Xvalue + 6, 6, "");
                            Xls.SetCellValue(Xvalue + 6, 7, "");
                            Xls.SetCellValue(Xvalue + 6, 8, "");
                            Xls.SetCellValue(Xvalue + 6, 9, "");
                            Xls.SetCellValue(Xvalue + 6, 10, "");
                            Xls.SetCellValue(Xvalue + 6, 11, "");
                            Xls.SetCellValue(Xvalue + 6, 12, "");
                            Xls.SetCellValue(Xvalue + 6, 13, "");
                            Xls.SetCellValue(Xvalue + 6, 14, "");
                            Xls.SetCellValue(Xvalue + 6, 15, "");
                            Xls.SetCellValue(Xvalue + 6, 16, "小計：");
                            Xls.SetCellValue(Xvalue + 6, 17, sum_pubadamt);
                            Xls.SetCellValue(Xvalue + 6, 18, sum_pubchgamt);
                            Xls.SetCellValue(Xvalue + 6, 19, sum_pubtotamt);
                            Xvalue++;
                        }
                        Xls.SetCellValue(Xvalue + 6, 1, "");
                        Xls.SetCellValue(Xvalue + 6, 2, "");
                        Xls.SetCellValue(Xvalue + 6, 3, "");
                        Xls.SetCellValue(Xvalue + 6, 4, "");
                        Xls.SetCellValue(Xvalue + 6, 5, "");
                        Xls.SetCellValue(Xvalue + 6, 6, "");
                        Xls.SetCellValue(Xvalue + 6, 7, "");
                        Xls.SetCellValue(Xvalue + 6, 8, dv[i]["im_nm"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 9, dv[i]["im_mfrinm"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 10, dv[i]["im_zip"].ToString().Trim() + " " + dv[i]["im_addr"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 11, dv[i]["im_invcdText"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 12, dv[i]["im_taxtpText"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 13, dv[i]["pub_yyyymm"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 14, dv[i]["pub_pubseq"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 15, dv[i]["clr_nm"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 16, dv[i]["pub_projno"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 17, dv[i]["pub_adamt"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 18, dv[i]["pub_chgamt"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 19, dv[i]["pub_totamt"].ToString().Trim());
                        Xvalue++;
                        sum_pubadamt += Convert.ToInt32(dv[i]["pub_adamt"].ToString().Trim());
                        sum_pubchgamt += Convert.ToInt32(dv[i]["pub_chgamt"].ToString().Trim());
                        sum_pubtotamt += Convert.ToInt32(dv[i]["pub_totamt"].ToString().Trim());
                    }
                    else
                    {
                        Xls.SetCellValue(Xvalue + 6, 1, "");
                        Xls.SetCellValue(Xvalue + 6, 2, "");
                        Xls.SetCellValue(Xvalue + 6, 3, "");
                        Xls.SetCellValue(Xvalue + 6, 4, "");
                        Xls.SetCellValue(Xvalue + 6, 5, "");
                        Xls.SetCellValue(Xvalue + 6, 6, "");
                        Xls.SetCellValue(Xvalue + 6, 7, "");
                        Xls.SetCellValue(Xvalue + 6, 8, "");
                        Xls.SetCellValue(Xvalue + 6, 9, "");
                        Xls.SetCellValue(Xvalue + 6, 10, "");
                        Xls.SetCellValue(Xvalue + 6, 11, "");
                        Xls.SetCellValue(Xvalue + 6, 12, "");
                        Xls.SetCellValue(Xvalue + 6, 13, dv[i]["pub_yyyymm"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 14, dv[i]["pub_pubseq"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 15, dv[i]["clr_nm"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 16, dv[i]["pub_projno"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 17, dv[i]["pub_adamt"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 18, dv[i]["pub_chgamt"].ToString().Trim());
                        Xls.SetCellValue(Xvalue + 6, 19, dv[i]["pub_totamt"].ToString().Trim());
                        sum_pubadamt += Convert.ToInt32(dv[i]["pub_adamt"].ToString().Trim());
                        sum_pubchgamt += Convert.ToInt32(dv[i]["pub_chgamt"].ToString().Trim());
                        sum_pubtotamt += Convert.ToInt32(dv[i]["pub_totamt"].ToString().Trim());
                        Xvalue++;
                    }
                }

                if (i == dv.Count - 1)//最後一個小計
                {
                    Xls.SetCellValue(Xvalue + 6, 1, "");
                    Xls.SetCellValue(Xvalue + 6, 2, "");
                    Xls.SetCellValue(Xvalue + 6, 3, "");
                    Xls.SetCellValue(Xvalue + 6, 4, "");
                    Xls.SetCellValue(Xvalue + 6, 5, "");
                    Xls.SetCellValue(Xvalue + 6, 6, "");
                    Xls.SetCellValue(Xvalue + 6, 7, "");
                    Xls.SetCellValue(Xvalue + 6, 8, "");
                    Xls.SetCellValue(Xvalue + 6, 9, "");
                    Xls.SetCellValue(Xvalue + 6, 10, "");
                    Xls.SetCellValue(Xvalue + 6, 11, "");
                    Xls.SetCellValue(Xvalue + 6, 12, "");
                    Xls.SetCellValue(Xvalue + 6, 13, "");
                    Xls.SetCellValue(Xvalue + 6, 14, "");
                    Xls.SetCellValue(Xvalue + 6, 15, "");
                    Xls.SetCellValue(Xvalue + 6, 16, "小計：");
                    Xls.SetCellValue(Xvalue + 6, 17, sum_pubadamt);
                    Xls.SetCellValue(Xvalue + 6, 18, sum_pubchgamt);
                    Xls.SetCellValue(Xvalue + 6, 19, sum_pubtotamt);
                }

                preNo = dv[i]["pub_contno"].ToString().Trim();
                preIMSeq = dv[i]["pub_imseq"].ToString().Trim();

                TotalAdamt += Convert.ToInt32(dv[i]["pub_adamt"].ToString().Trim());
                TotalChgamt += Convert.ToInt32(dv[i]["pub_chgamt"].ToString().Trim());
                Totalamt += Convert.ToInt32(dv[i]["pub_totamt"].ToString().Trim());
            }

            Xls.InsertAndCopyRange(myRangeTotal, Xvalue + 6 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(Xvalue + 6 + 1, 17, TotalAdamt);
            Xls.SetCellValue(Xvalue + 6 + 1, 18, TotalChgamt);
            Xls.SetCellValue(Xvalue + 6 + 1, 19, Totalamt);

            Common.excuteExcel(Xls, "iaFm2_prelist2.xls");
        }

        protected void btnPickReset_Click(object sender, EventArgs e)
        {
            // 抓出 DataGrid1 被挑選的落版資料
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                // 抓出畫面上的值, 作為篩選資料的條件
                string strSyscd = "C2";
                string strContNo = DataGrid1.Rows[i].Cells[1].Text.ToString().Trim(); ;
                string strYYYYMM = DataGrid1.Rows[i].Cells[12].Text.ToString().Trim();
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
                string strPubSeq = DataGrid1.Rows[i].Cells[13].Text.ToString().Trim();
                //Response.Write("strSyscd= " + strSyscd + ", ");
                //Response.Write("strContNo= " + strContNo + ", ");
                //Response.Write("strYYYYMM= " + strYYYYMM + ", ");
                //Response.Write("strPubSeq= " + strPubSeq + "<br>");


                // 更新被挑選的落版資料之 pub_fginved 從 't' 變為 ' '
                // 執行 將值塞入 sqlCommand3.Parameters 中, 以執行 更新
                try
                {
                    myiaFm2.UPDATEc2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq, "3");
                    //Response.Write("落版資料回復成功, 請重新挑選");
                    this.lblPickMessage.Text = "";
                }
                catch (System.Data.SqlClient.SqlException ex3)
                {
                    throw new Exception(ex3.Message);
                    //Response.Write("落版資料回復失敗, 請重新挑選");
                }
                // 結束 for(int i=0; i < DataGrid1.Items.Count; i++)
            }

            JavaScript.AlertMessage(this.Page, "資料回復成功, 請重新挑選!\\n若要繼續預開, 請再按下 '清除重查' 按鈕!");
            // 以 Javascript 的 window.alert()  來告知訊息
            SearchIcon.Visible = false;

            // Reset to initial status
            InitialData();
        }

        protected void btnCreateIA_Click(object sender, EventArgs e)
        {
            if (tbxYYYYMM.Text.Length != 7)
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }

            // 抓出畫面上的值, 作為 執行 sp 的 @值
            string strSyscd = "C2";
            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strSortFilter = this.ddlOrderByFilter.SelectedItem.Value.ToString().Trim();
            string strIabDate = this.tbxYYYYMM.Text.ToString().Trim();
            strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
            string strLEmpNo = Account.GetAccInfo().srspn_empno.ToString().Trim();
            //Response.Write("strSyscd= " + strSyscd + ", ");
            //Response.Write("strBkcd= " + strBkcd + ", ");
            //Response.Write("strSortFilter= " + strSortFilter + ", ");
            //Response.Write("strIabDate= " + strIabDate + ", ");
            //Response.Write("strLEmpNo= " + strLEmpNo + "<br>");


            // 步驟一: 抓出此筆資料的 iab_iabseq -- 先抓出資料庫的最大值, 再加一
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds6 = myiaFm2.Selectiab(strIabDate);
            DataView dv6 = ds6.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr6 = "1=1";
            dv6.RowFilter = rowfilterstr6;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
            //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

            string strCurrentIabSeq;
            // 若搜尋結果為 "找到" 的處理
            if (int.Parse(dv6[0][0].ToString().Trim()) > 0)
            {
                // 抓出 新的合約書編號 = 目前資料庫中的Max合約書編號+1
                strCurrentIabSeq = Convert.ToString(Convert.ToInt32(dv6[0][1].ToString().Trim()) + 1);
                //Response.Write("strCurrentIabSeq= " + strCurrentIabSeq + "<br>");
            }
            else
            {
                strCurrentIabSeq = "000001";
            }
            // 做補零動作: strCurrentIabSeq 必須是六位數
            if (strCurrentIabSeq.Length == 1)
                strCurrentIabSeq = "00000" + strCurrentIabSeq;
            else if (strCurrentIabSeq.Length == 2)
                strCurrentIabSeq = "0000" + strCurrentIabSeq;
            else if (strCurrentIabSeq.Length == 3)
                strCurrentIabSeq = "000" + strCurrentIabSeq;
            else if (strCurrentIabSeq.Length == 4)
                strCurrentIabSeq = "00" + strCurrentIabSeq;
            else if (strCurrentIabSeq.Length == 5)
                strCurrentIabSeq = "0" + strCurrentIabSeq;
            else if (strCurrentIabSeq.Length == 6)
                strCurrentIabSeq = strCurrentIabSeq;
            //Response.Write("strCurrentIabSeq= " + strCurrentIabSeq + "<br>");


            // 新增 iab 資料 -- 單筆
            // 執行 將值塞入 sqlCommand6.Parameters 中, 以執行 更新
            //Response.Write(this.sqlCommand6.CommandText);
            string strIabCreDate = System.DateTime.Today.ToString("yyyyMMdd");

            try
            {
                myiaFm2.INSERTiab(strIabDate, strCurrentIabSeq, strIabCreDate, strLEmpNo);
                //Response.Write("新增 iab 資料成功<br>");
            }
            catch (System.Data.SqlClient.SqlException ex6)
            {
                throw new Exception(ex6.Message);
                //Response.Write("新增 iab 資料失敗<br>");
            }


            // 步驟二: 由 DataGrid1 抓出落版資料, 更新其 pub_fginved 由 't' 為 'v'
            if (DataGrid1.Rows.Count > 0)
            {
                // 抓出每筆落版資料
                for (int i = 0; i < DataGrid1.Rows.Count; i++)
                {
                    // 檢查被挑選的狀態值
                    bool strSelect = ((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked;
                    //Response.Write("strSelect= " + strSelect + "<br>");


                    // 抓出 每一筆 '被挑選的' 落版資料, 並更新其 pub_fginved 由 't' 為 'v'
                    string strContNo, strYYYYMM, strPubSeq, strIMSeq;
                    // 抓出被挑選的資料
                    if (strSelect == true)
                    {
                        strContNo = DataGrid1.Rows[i].Cells[1].Text.ToString().Trim();
                        strYYYYMM = DataGrid1.Rows[i].Cells[12].Text.ToString().Trim();
                        strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
                        strPubSeq = DataGrid1.Rows[i].Cells[13].Text.ToString();
                        strIMSeq = DataGrid1.Rows[i].Cells[14].Text.ToString().Trim();
                        //Response.Write("i= " + i + ", ");
                        //Response.Write("strSyscd= " + strSyscd + ", ");
                        //Response.Write("strContNo= " + strContNo + ", ");
                        //Response.Write("strYYYYMM= " + strYYYYMM + ", ");
                        //Response.Write("strPubSeq= " + strPubSeq + "");
                        //Response.Write("strIMSeq= " + strIMSeq + "<br>");
                        try
                        {
                            myiaFm2.UPDATEc2_pub2(strSyscd, strContNo, strYYYYMM, strPubSeq);
                            //Response.Write("落版資料更新成功<br>");
                        }
                        catch (System.Data.SqlClient.SqlException ex4)
                        {
                            throw new Exception(ex4.Message);
                            //Response.Write("落版資料更新失敗<br>");
                        }
                    }

                    // 結束 for(int i=0; i< DataGrid1.Items.Count ; i++)
                }


                // 抓出被挑選之 contno & IMSeq, 以傳入 sp
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds8 = myiaFm2.SelectDISTINCTc2_cont(strBkcd, strIabDate);
                DataView dv8 = ds8.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr8 = "1=1";
                dv8.RowFilter = rowfilterstr8;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
                //Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR>");

                string iSyscd = "C2", iContNo, iIMSeq, istrCurrentIabSeq, istrIabDate;
                if (dv8.Count > 0)
                {
                    for (int j = 0; j < dv8.Count; j++)
                    {
                        iContNo = dv8[j]["cont_contno"].ToString().Trim();
                        iIMSeq = dv8[j]["pub_imseq"].ToString();
                        istrCurrentIabSeq = strCurrentIabSeq;
                        strIabDate = this.tbxYYYYMM.Text.ToString().Trim();
                        strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
                        istrIabDate = strIabDate;
                        //istrLEmpNo = strLEmpNo;
                        //Response.Write("iSyscd= " + iSyscd + ", ");
                        //Response.Write("iContNo= " + iContNo + ", ");
                        //Response.Write("iIMSeq= " + iIMSeq + ", ");
                        //Response.Write("istrCurrentIabSeq= " + istrCurrentIabSeq + ", ");
                        //Response.Write("istrIabDate= " + istrIabDate + "<br>");
                        //Response.Write("istrLEmpNo= " + istrLEmpNo + "<br>");

                        // 步驟二: 呼叫 sp
                        // 執行 將值塞入 sqlCommand5.Parameters 中, 以執行 更新

                        // 確認執行 sqlCommand5 成功
                        try
                        {
                            myiaFm2.RunSpsp_c2_add_ia(iSyscd, iContNo, iIMSeq, istrIabDate, istrCurrentIabSeq);
                            //Response.Write("執行 sp 成功<br><br>");
                        }
                        catch (System.Data.SqlClient.SqlException ex5)
                        {
                            throw new Exception(ex5.Message);
                            //Response.Write("執行 sp 失敗<br><br>");
                        }

                    }
                }
                else
                {
                    //Response.Write("dv8.Count <= 0<br>");
                }

                // 轉址 - 直接顯示 ia 檢核表
                //注意 參數action 不需要了
                string strbuf = "iaFm2_chklist_ia.aspx?bkcd=" + sec.encryptquerystring(strBkcd) + "&yyyymm=" + sec.encryptquerystring(strIabDate) + "&sort=" + sec.encryptquerystring(strSortFilter) + "&iabseq=" + sec.encryptquerystring(strCurrentIabSeq);
                // 以 Javascript 的 window.close() 來告知訊息
                JavaScript.AlertMessageRedirect(this.Page, "產生發票開立單成功!\\n請檢視發票開立單檢核表", strbuf);

                // 結束 if(DataGrid1.Items.Count > 0)
            }
        }
    }
}