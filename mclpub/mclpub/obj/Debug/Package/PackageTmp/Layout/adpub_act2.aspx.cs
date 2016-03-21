using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Xml;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.Layout
{
    public partial class adpub_act2 : System.Web.UI.Page
    {
        adpub_act2_DB myadpub = new adpub_act2_DB();

        public int Pubrow = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 讀取一般版面的起始頁碼 (根據指定之書籍類別)
                tbxStartPageNo.Value = GetStartPageNo().ToString();
                
                // 給預設值
                InitialMyData();


                //Load Data From DB, 轉成 xml 型態, 再填入 document.form1.hidData.Value
                LoadDataFromDB_special();
                LoadDataFromDB();
                //因為Firefox的函數沒辦法LOAD XML 所以必須把XML轉成字串
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("adpub_data_empty.xml"));           
                hid_xxx.Value = xd.OuterXml.ToString();


                //BindSpecialGrid();
                //BindCommonGrid();
            }
        }

        // 讀取一般版面的起始頁碼 (根據指定之書籍類別)(意思是說一般版面的刊登頁碼會從6開始計數)
        private int GetStartPageNo()
        {
            // 抓出 書籍代碼
            string strBkcd = Context.Request.QueryString["bkcd"].ToString();

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myadpub.Selectc2_pgno();
            // 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
            DataView dv3 = ds3.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND pg_bkcd='" + strBkcd + "'";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若搜尋結果為 "找到" 的處理
            string strStartPgNo = "0";
            if (dv3.Count > 0)
            {
                strStartPgNo = dv3[0]["pg_startpgno"].ToString();
            }

            return Convert.ToInt32(strStartPgNo);

            //Response.Write("strStartPgNo= " + strStartPgNo + "<br>");
        }

        // Load from DB : 一般版面的資料
        private void LoadDataFromDB()
        {
            // 抓出網頁變數 bkcd & yyyymm
            string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
            string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

            DataSet ds = myadpub.SelectCommonGV(Reqbkcd, Reqyyyymm);
            DataView dv = ds.Tables[0].DefaultView;

            // 抓出總筆數
            int TotalCount = dv.Count;
            //Response.Write(" TotalCount = " + TotalCount + "<BR>");

            if (TotalCount > 0)
            {
                // 抓出廣告版面代碼, 以算出版面２, 重排頁次時才能算對
                // 先抓出各行的 廣告版面代碼
                for (int i = 0; i < TotalCount; i++)
                {
                    // 此 for loop 是將 dv[i][j] 值為空者, 強迫塞入一個空白符號
                    //顯示出所有的 dv[i][j] 裡的資料, 並用 \ 符號隔開區別
                    // j=1; j<30 : 1~30 是根據 item 共有 29 個而來
                    for (int j = 1; j < 30; j++)
                    {
                        //Response.Write(j + ":" + dv[i][j] + "\\ \n");
                        if (dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
                            dv[i][j] = " ";
                    }


                    // 註: 改稿期別 若改為 改稿期別, 則會有 Error: "在必須有物件的執行個體處找到 null 值。"
                    // 依不同的 稿件類別, 於畫面上不顯示(清除)不相關的資料值
                    string drafttp = dv[i]["稿件類別代碼"].ToString();
                    // 若稿件類別為 舊稿, 則清除 改稿及新稿之資料
                    if (drafttp == "1")
                    {
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }
                    // 若稿件類別為 新稿, 則清除 舊稿及改稿之資料
                    else if (drafttp == "2")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                    }
                    // 若稿件類別為 改稿, 則清除 舊稿及新稿之資料
                    else if (drafttp == "3")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }


                    // 判別 廣告版面代碼 為 全頁(01) 或 半頁(02), 並使版面２資料與之同步, 再輸出訊息至版面２
                    // 如此 doReOrder() 才可算出正確頁次
                    string pgscd = dv[i]["廣告版面代碼"].ToString();

                    // 判別 廣告篇幅 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    if (pgscd == "01")
                    {
                        //Response.Write(" 版面２ = 8<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 8;
                        //pagelayout2.Value = 8;
                    }
                    else if (pgscd == "02")
                    {
                        //Response.Write(" 版面２ = 4<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 4;
                        //pagelayout2.Value = 4;
                    }

                    // 若廣告篇幅為 '半頁' 時, 輸出不同顏色供辨識
                    // 因值塞入 xml 裡, 故顏色仍無法於 table 中顯示不同顏色
                    //					string pgsnm = dv[i]["廣告篇幅"].ToString();
                    //					if(pgsnm == "全頁")
                    //					{
                    //						pgsnm = pgsnm;
                    //					}
                    //					else if(pgsnm == "半頁")
                    //					{
                    //						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
                    //					}
                    //					//Response.Write("pgsnm= " + pgsnm + "<br>");


                    // 判別 固定頁次註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgFixPage = dv[i]["固定頁次註記"].ToString();
                    if (fgFixPage == "0")
                    {
                        dv[i]["固定頁次註記"] = "否";
                    }
                    else
                    {
                        dv[i]["固定頁次註記"] = "是";
                    }


                    // 判別 到稿註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgGot = dv[i]["到稿註記"].ToString();
                    if (fgGot == "0")
                    {
                        dv[i]["到稿註記"] = "否";
                    }
                    else
                    {
                        dv[i]["到稿註記"] = "是";
                    }

                    // 舊稿書籍名稱已抓到 bk_nm; 若舊稿書籍名稱使用 bk_nm, 改稿書籍名稱 不可同時又使用 bk_nm, 必須手動判別
                    // 判別 改稿書籍代碼 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    string chgbkcd = dv[i]["改稿書籍代碼"].ToString();
                    if (chgbkcd == "01")
                    {
                        dv[i]["改稿書籍代碼"] = "工材雜誌";
                    }
                    else if (chgbkcd == "02")
                    {
                        dv[i]["改稿書籍代碼"] = "電材雜誌";
                    }

                }
            }
            // 若資料庫裡無資料, 顯示其訊息
            else
            {
                this.lblDBMessage.Text = "目前資料庫中無資料!";
            }

            if (dv.Count == 0)
            {
                JavaScript.AlertMessageRedirect(this.Page, "無資料可落版", "adpub_act1.aspx?action=1");
            }
            else
            {
                //底下的是要把特殊版面加進去的SELECT COMMAND
                DataSet dsSortable = myadpub.SelectCommonGV(Reqbkcd, Reqyyyymm);
                DataView dvSortable = dsSortable.Tables[0].DefaultView;
                bindPanel(dvSortable);//把落版的部分資料載入
            }
            // 轉成 xml 型態, 填入 document.form1.hidData.Value
            //Response.Write("ds= " + ds.GetXml() + "<br>");
            hidData.Value = ds.GetXml();
            //Response.Write("hidData.Value= " + hidData.Value + "<br>");
        }

        // 給預設值
        private void InitialMyData()
        {
            // 抓出網頁變數 bkcd & yyyymm, 將之轉成文字顯示之
            string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
            string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();
            //Response.Write("Reqbkcd= " + Reqbkcd + "<br>");
            //Response.Write("Reqyyyymm= " + Reqyyyymm + "<br>");

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds = myadpub.SelectBook();
            DataView dv = ds.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            dv.RowFilter = "1=1";
            if (Reqbkcd != "")
                dv.RowFilter = "bk_bkcd=" + Reqbkcd;
            else
                dv.RowFilter = dv.RowFilter;

            //防呆處理: 若 BookName 無資料時, 則給錯誤訊息
            string BookName = "";
            if (dv.Count > 0)
                BookName = dv[0]["bk_nm"].ToString();
            else
                BookName = BookName;
            //Response.Write("BookName= " + BookName + "<br>");
            this.lblSearchKeyword.Text = BookName;

            // 檢查網頁變數 刊登年月 是否有輸入
            if (Reqyyyymm != "")
            {
                if (Reqyyyymm.Length == 6)
                    Reqyyyymm = Reqyyyymm.Substring(0, 4) + " / " + Reqyyyymm.Substring(4, 2);
                else
                    Reqyyyymm = Reqyyyymm;
                this.lblSearchKeyword.Text = lblSearchKeyword.Text + " & 刊登年月 " + Reqyyyymm;
                //Response.Write("無刊登年月資料<br>");
            }
            else
            {
                this.lblSearchKeyword.Text = lblSearchKeyword.Text;
                //Response.Write("刊登年月 " + Reqyyyymm + "<br>");
            }


            // 抓出總筆數
            // 檢查網頁變數 刊登年月 是否有輸入
            if (Reqbkcd != "" && Reqyyyymm != "")
            {
                Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds2 = myadpub.Selectc2_pub();
                DataView dv2 = ds2.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr2 = "1=1";
                rowfilterstr2 = rowfilterstr2 + " AND pub_bkcd='" + Reqbkcd + "'";
                rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm='" + Reqyyyymm + "'";
                dv2.RowFilter = rowfilterstr2;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
                //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

                if (dv2.Count > 0)
                {
                    //Response.Write("Total: " + dv2.Count.ToString() + "<br>");
                    this.lblTotalCounts.Text = "(  總筆數：" + dv2.Count.ToString() + "筆；";
                    this.lblTotalCounts.Text = this.lblTotalCounts.Text + "廣告色彩/篇幅 小計：";

                    // 抓出 廣告色彩+廣告篇幅 的小計
                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds4 = myadpub.Selectc2_pub2(Reqbkcd, Reqyyyymm);
                    DataView dv4 = ds4.Tables[0].DefaultView;

                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    string rowfilterstr4 = "1=1";
                    //rowfilterstr4 = rowfilterstr4 + " AND pub_bkcd='" + Reqbkcd + "'";
                    //rowfilterstr4 = rowfilterstr4 + " AND pub_yyyymm='" + Reqyyyymm + "'";
                    dv4.RowFilter = rowfilterstr4;

                    // 檢查並輸出 最後 Row Filter 的結果
                    //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                    //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                    if (dv4.Count > 0)
                    {
                        //this.lblClrPgsGroupCount.Text = "" + ")";
                        this.lblClrPgsGroupCount.Text = "";

                        string ClrName = "", PgsName = "";
                        int ClrPgsCountNo = 0;
                        for (int i = 0; i < dv4.Count; i++)
                        {
                            // 抓出每一筆資料
                            ClrName = dv4[i]["clr_nm"].ToString().Trim();
                            PgsName = dv4[i]["pgs_nm"].ToString().Trim();
                            ClrPgsCountNo = Convert.ToInt32(dv4[i]["CountNo"].ToString().Trim());
                            this.lblClrPgsGroupCount.Text = this.lblClrPgsGroupCount.Text + ClrName + PgsName + ":" + ClrPgsCountNo + "筆&nbsp;&nbsp;";
                        }
                    }
                    else
                    {
                        this.lblClrPgsGroupCount.Text = "<font color='Gray'>無資料</font>)";
                    }
                    this.lblClrPgsGroupCount.Text = this.lblClrPgsGroupCount.Text + ")";
                }
            }
        }

        // Load from DB : 特殊版面的資料
        private void LoadDataFromDB_special()
        {
            // 抓出網頁變數 bkcd & yyyymm
            string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
            string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

            DataSet ds = myadpub.SelectspecialGV(Reqbkcd, Reqyyyymm);
            DataView dv = ds.Tables[0].DefaultView;

            // 抓出總筆數
            int TotalCount = dv.Count;
            //Response.Write(" TotalCount = " + TotalCount + "<BR>");

            if (TotalCount > 0)
            {
                // 抓出廣告版面代碼, 以算出版面２, 重排頁次時才能算對
                // 先抓出各行的 廣告版面代碼
                for (int i = 0; i < TotalCount; i++)
                {
                    // 此 for loop 是將 dv[i][j] 值為空者, 強迫塞入一個空白符號
                    //顯示出所有的 dv[i][j] 裡的資料, 並用 \ 符號隔開區別
                    // j=1; j<30 : 1~30 是根據 item 共有 29 個而來
                    for (int j = 1; j < 30; j++)
                    {
                        //Response.Write(j + ":" + dv[i][j] + "\\ \n");
                        if (dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
                            dv[i][j] = " ";
                    }


                    // 註: 改稿期別 若改為 改稿期別, 則會有 Error: "在必須有物件的執行個體處找到 null 值。"
                    // 依不同的 稿件類別, 於畫面上不顯示(清除)不相關的資料值
                    string drafttp = dv[i]["稿件類別代碼"].ToString();
                    // 若稿件類別為 舊稿, 則清除 改稿及新稿之資料
                    if (drafttp == "1")
                    {
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }
                    // 若稿件類別為 新稿, 則清除 舊稿及改稿之資料
                    else if (drafttp == "2")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                    }
                    // 若稿件類別為 改稿, 則清除 舊稿及新稿之資料
                    else if (drafttp == "3")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }


                    // 判別 廣告版面代碼 為 全頁(01) 或 半頁(02), 並使版面２資料與之同步, 再輸出訊息至版面２
                    // 如此 doReOrder() 才可算出正確頁次
                    string pgscd = dv[i]["廣告版面代碼"].ToString();

                    // 判別 廣告篇幅 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    if (pgscd == "01")
                    {
                        //Response.Write(" 版面２ = 8<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 8;
                        //pagelayout2.Value = 8;
                    }
                    else if (pgscd == "02")
                    {
                        //Response.Write(" 版面２ = 4<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 4;
                        //pagelayout2.Value = 4;
                    }

                    //					// 若廣告篇幅為 '半頁' 時, 輸出不同顏色供辨識
                    //					// 因值塞入 xml 裡, 故顏色仍無法於 table 中顯示不同顏色
                    //					string pgsnm = dv[i]["廣告篇幅"].ToString();
                    //					if(pgsnm == "全頁")
                    //					{
                    //						pgsnm = pgsnm;
                    //					}
                    //					else if(pgsnm == "半頁")
                    //					{
                    //						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
                    //					}
                    //					//Response.Write("pgsnm= " + pgsnm + "<br>");


                    // 判別 固定頁次註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgFixPage = dv[i]["固定頁次註記"].ToString();
                    if (fgFixPage == "0")
                    {
                        dv[i]["固定頁次註記"] = "否";
                    }
                    else
                    {
                        dv[i]["固定頁次註記"] = "是";
                    }


                    // 判別 到稿註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgGot = dv[i]["到稿註記"].ToString();
                    if (fgGot == "0")
                    {
                        dv[i]["到稿註記"] = "否";
                    }
                    else
                    {
                        dv[i]["到稿註記"] = "是";
                    }

                    // 舊稿書籍名稱已抓到 bk_nm; 若舊稿書籍名稱使用 bk_nm, 改稿書籍名稱 不可同時又使用 bk_nm, 必須手動判別
                    // 判別 改稿書籍代碼 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    string chgbkcd = dv[i]["改稿書籍代碼"].ToString();
                    if (chgbkcd == "01")
                    {
                        dv[i]["改稿書籍代碼"] = "工材雜誌";
                    }
                    else if (chgbkcd == "02")
                    {
                        dv[i]["改稿書籍代碼"] = "電材雜誌";
                    }

                }
            }
            // 若資料庫裡無資料, 顯示其訊息
            else
            {
                this.lblDBMessage.Text = "目前資料庫中無資料!";
            }


            // 轉成 xml 型態, 填入 document.form1.hidData.Value
            //Response.Write("ds= " + ds.GetXml() + "<br>");
            hidData_special.Value = ds.GetXml();
            //Response.Write("hidData_special.Value= " + hidData_special.Value + "<br>");
        }



        #region 20120115要求把舊的落板復原 所以新的檢視Table被廢除
        //Bind把特殊版面
        private void BindSpecialGrid()
        {
            // 抓出網頁變數 bkcd & yyyymm
            string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
            string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

            DataSet ds = myadpub.SelectspecialGV(Reqbkcd, Reqyyyymm);
            DataView dv = ds.Tables[0].DefaultView;
            // 抓出總筆數
            int TotalCount = dv.Count;
            if (TotalCount > 0)
            {
                // 抓出廣告版面代碼, 以算出版面２, 重排頁次時才能算對
                // 先抓出各行的 廣告版面代碼
                for (int i = 0; i < TotalCount; i++)
                {
                    // 此 for loop 是將 dv[i][j] 值為空者, 強迫塞入一個空白符號
                    //顯示出所有的 dv[i][j] 裡的資料, 並用 \ 符號隔開區別
                    // j=1; j<30 : 1~30 是根據 item 共有 29 個而來
                    for (int j = 1; j < 30; j++)
                    {
                        //Response.Write(j + ":" + dv[i][j] + "\\ \n");
                        if (dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
                            dv[i][j] = " ";
                    }


                    // 註: 改稿期別 若改為 改稿期別, 則會有 Error: "在必須有物件的執行個體處找到 null 值。"
                    // 依不同的 稿件類別, 於畫面上不顯示(清除)不相關的資料值
                    string drafttp = dv[i]["稿件類別代碼"].ToString();
                    // 若稿件類別為 舊稿, 則清除 改稿及新稿之資料
                    if (drafttp == "1")
                    {
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }
                    // 若稿件類別為 新稿, 則清除 舊稿及改稿之資料
                    else if (drafttp == "2")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                    }
                    // 若稿件類別為 改稿, 則清除 舊稿及新稿之資料
                    else if (drafttp == "3")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }


                    // 判別 廣告版面代碼 為 全頁(01) 或 半頁(02), 並使版面２資料與之同步, 再輸出訊息至版面２
                    // 如此 doReOrder() 才可算出正確頁次
                    string pgscd = dv[i]["廣告版面代碼"].ToString();

                    // 判別 廣告篇幅 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    if (pgscd == "01")
                    {
                        //Response.Write(" 版面２ = 8<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 8;
                        //pagelayout2.Value = 8;
                    }
                    else if (pgscd == "02")
                    {
                        //Response.Write(" 版面２ = 4<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 4;
                        //pagelayout2.Value = 4;
                    }

                    //					// 若廣告篇幅為 '半頁' 時, 輸出不同顏色供辨識
                    //					// 因值塞入 xml 裡, 故顏色仍無法於 table 中顯示不同顏色
                    //					string pgsnm = dv[i]["廣告篇幅"].ToString();
                    //					if(pgsnm == "全頁")
                    //					{
                    //						pgsnm = pgsnm;
                    //					}
                    //					else if(pgsnm == "半頁")
                    //					{
                    //						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
                    //					}
                    //					//Response.Write("pgsnm= " + pgsnm + "<br>");


                    // 判別 固定頁次註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgFixPage = dv[i]["固定頁次註記"].ToString();
                    if (fgFixPage == "0")
                    {
                        dv[i]["固定頁次註記"] = "否";
                    }
                    else
                    {
                        dv[i]["固定頁次註記"] = "是";
                    }


                    // 判別 到稿註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgGot = dv[i]["到稿註記"].ToString();
                    if (fgGot == "0")
                    {
                        dv[i]["到稿註記"] = "否";
                    }
                    else
                    {
                        dv[i]["到稿註記"] = "是";
                    }

                    // 舊稿書籍名稱已抓到 bk_nm; 若舊稿書籍名稱使用 bk_nm, 改稿書籍名稱 不可同時又使用 bk_nm, 必須手動判別
                    // 判別 改稿書籍代碼 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    string chgbkcd = dv[i]["改稿書籍代碼"].ToString();
                    if (chgbkcd == "01")
                    {
                        dv[i]["改稿書籍代碼"] = "工材雜誌";
                    }
                    else if (chgbkcd == "02")
                    {
                        dv[i]["改稿書籍代碼"] = "電材雜誌";
                    }

                }
            }

            //specialGV.DataSource = dv;
            //specialGV.DataBind();
        }

        //Bind把一般版面
        private void BindCommonGrid()
        {
            // 抓出網頁變數 bkcd & yyyymm
            string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
            string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

            DataSet ds = myadpub.SelectCommonGV(Reqbkcd, Reqyyyymm);
            DataView dv = ds.Tables[0].DefaultView;
            // 抓出總筆數
            int TotalCount = dv.Count;
            //Response.Write(" TotalCount = " + TotalCount + "<BR>");

            if (TotalCount > 0)
            {
                // 抓出廣告版面代碼, 以算出版面２, 重排頁次時才能算對
                // 先抓出各行的 廣告版面代碼
                for (int i = 0; i < TotalCount; i++)
                {
                    // 此 for loop 是將 dv[i][j] 值為空者, 強迫塞入一個空白符號
                    //顯示出所有的 dv[i][j] 裡的資料, 並用 \ 符號隔開區別
                    // j=1; j<30 : 1~30 是根據 item 共有 29 個而來
                    for (int j = 1; j < 30; j++)
                    {
                        //Response.Write(j + ":" + dv[i][j] + "\\ \n");
                        if (dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
                            dv[i][j] = " ";
                    }


                    // 註: 改稿期別 若改為 改稿期別, 則會有 Error: "在必須有物件的執行個體處找到 null 值。"
                    // 依不同的 稿件類別, 於畫面上不顯示(清除)不相關的資料值
                    string drafttp = dv[i]["稿件類別代碼"].ToString();
                    // 若稿件類別為 舊稿, 則清除 改稿及新稿之資料
                    if (drafttp == "1")
                    {
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }
                    // 若稿件類別為 新稿, 則清除 舊稿及改稿之資料
                    else if (drafttp == "2")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["改稿期別"] = " ";
                        dv[i]["改稿頁碼"] = " ";
                        dv[i]["改稿重出片註記"] = " ";
                    }
                    // 若稿件類別為 改稿, 則清除 舊稿及新稿之資料
                    else if (drafttp == "3")
                    {
                        dv[i]["舊稿期別"] = " ";
                        dv[i]["舊稿頁碼"] = " ";
                        dv[i]["新稿製法代碼"] = " ";
                    }


                    // 判別 廣告版面代碼 為 全頁(01) 或 半頁(02), 並使版面２資料與之同步, 再輸出訊息至版面２
                    // 如此 doReOrder() 才可算出正確頁次
                    string pgscd = dv[i]["廣告版面代碼"].ToString();

                    // 判別 廣告篇幅 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    if (pgscd == "01")
                    {
                        //Response.Write(" 版面２ = 8<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 8;
                        //pagelayout2.Value = 8;
                    }
                    else if (pgscd == "02")
                    {
                        //Response.Write(" 版面２ = 4<BR>");
                        // 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
                        dv[i]["版面2"] = 4;
                        //pagelayout2.Value = 4;
                    }

                    // 若廣告篇幅為 '半頁' 時, 輸出不同顏色供辨識
                    // 因值塞入 xml 裡, 故顏色仍無法於 table 中顯示不同顏色
                    //					string pgsnm = dv[i]["廣告篇幅"].ToString();
                    //					if(pgsnm == "全頁")
                    //					{
                    //						pgsnm = pgsnm;
                    //					}
                    //					else if(pgsnm == "半頁")
                    //					{
                    //						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
                    //					}
                    //					//Response.Write("pgsnm= " + pgsnm + "<br>");


                    // 判別 固定頁次註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgFixPage = dv[i]["固定頁次註記"].ToString();
                    if (fgFixPage == "0")
                    {
                        dv[i]["固定頁次註記"] = "否";
                    }
                    else
                    {
                        dv[i]["固定頁次註記"] = "是";
                    }


                    // 判別 到稿註記 為 0(否) 或 1(是), 並輸出訊息
                    string fgGot = dv[i]["到稿註記"].ToString();
                    if (fgGot == "0")
                    {
                        dv[i]["到稿註記"] = "否";
                    }
                    else
                    {
                        dv[i]["到稿註記"] = "是";
                    }

                    // 舊稿書籍名稱已抓到 bk_nm; 若舊稿書籍名稱使用 bk_nm, 改稿書籍名稱 不可同時又使用 bk_nm, 必須手動判別
                    // 判別 改稿書籍代碼 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
                    string chgbkcd = dv[i]["改稿書籍代碼"].ToString();
                    if (chgbkcd == "01")
                    {
                        dv[i]["改稿書籍代碼"] = "工材雜誌";
                    }
                    else if (chgbkcd == "02")
                    {
                        dv[i]["改稿書籍代碼"] = "電材雜誌";
                    }

                }
            }


            //CommonGV.DataSource = dv;
            //CommonGV.DataBind();

            if (dv.Count == 0)
            {
                JavaScript.AlertMessageRedirect(this.Page, "無資料可落版", "adpub_act1.aspx?action=1");
            }
            else
            {
                //底下的是要把特殊版面加進去的SELECT COMMAND
                DataSet dsSortable = myadpub.SelectCommonGV(Reqbkcd, Reqyyyymm);
                DataView dvSortable = dsSortable.Tables[0].DefaultView;
                bindPanel(dvSortable);//把落版的部分資料載入
            }
        }

        #endregion



        //Bind落版
        private void bindPanel(DataView dv)
        {
            dv = AddNewFront(dv);
            //#region 填入中間空缺的頁碼 包括前面的1~5
            ////int page_row_start = GetStartPageNo();  //刊登頁碼的起始值
            //int page_row_start = 1;  //刊登頁碼的起始值
            //int dv_row_count = dv.Count ;  //資料來源的計數
            //int page_row_value_before = 0;  //上一次資料的起始值加上迴圈次數
            //for (int page_row = 0; page_row < dv_row_count; page_row++)  //依dv的資料筆數跑迴圈
            //{
            //    if (Convert.ToInt32(dv[page_row]["刊登頁碼"]) >= page_row_start)  //如果資料來源的刊登頁碼數大於等於刊登頁碼的起始值則進入迴圈
            //    {
            //        if (page_row + page_row_start != Convert.ToInt32(dv[page_row]["刊登頁碼"]))  //如果迴圈進行次數加上刊登頁碼的起始值不等於目前資料來源的刊登頁碼
            //        {
            //            //開始進行迴圈，規則是最後一次處理過的資料，頁碼值跟目前資料來源的刊登頁碼做迴圈，條件是頁碼值小於刊登頁碼，就加一行
            //            for (int num_to_next_count = page_row_value_before; num_to_next_count < Convert.ToInt32(dv[page_row]["刊登頁碼"]); num_to_next_count++)
            //            {
            //                if (num_to_next_count + 1 != Convert.ToInt32(dv[page_row]["刊登頁碼"]) && num_to_next_count + 1 >= page_row_start)
            //                {
            //                    DataRowView drv = dv.AddNew();
            //                    drv["刊登頁碼"] = num_to_next_count + 1;
            //                    drv.EndEdit();
            //                }
            //            }
            //        }
            //        page_row_value_before = Convert.ToInt32(dv[page_row]["刊登頁碼"]);  //紀錄這一次經過的頁碼值
            //    }
                
            //}
            dv.Sort = "刊登頁碼 asc";
            //#endregion

            #region 新增三個原本是int的欄位 轉換為string
            dv = ThreeString(dv);
            #endregion

            #region 把同樣頁碼的合併
            dv = MergeCell(dv);
            #endregion

            //要把最後面空缺的補上去 例如最後剩下5 那就要把16-5=11個空的給補上去
            if (dv.Count % 16 != 0)
            {
                int Add_count = 16 - dv.Count % 16;
                for (int i = 0; i < Add_count; i++)
                {
                    DataRowView drv = dv.AddNew();
                    drv["刊登頁碼轉"] = "XXX";
                    drv.EndEdit();
                }
            }

            //第一件事先把筆數算清楚 底一下才好做動作
            int Rowcount = dv.Count;
            int Groupcount = 0;//總共需要幾個小群組(16個為一組)
            if (Rowcount == 0)
            {
                HtmlGenericControl p = new HtmlGenericControl("p");
                p.InnerText = "查詢無結果";
                PanelLayoutAll.Controls.Add(p);
            }
            else
            {
                //先除以16 看到底需要幾列
                if (Rowcount % 16 == 0)
                {
                    Groupcount = Rowcount / 16;//如果整除 就剛好等於答案
                }
                else if (Rowcount % 16 != 0 && Rowcount / 16 == 0)//表示不足一組
                {
                    Groupcount = 1;
                }
                else
                {
                    Groupcount = Rowcount / 16 + 1;
                }

                HtmlGenericControl table = new HtmlGenericControl("table");


                for (int i = 0; i < Groupcount; i++)
                {
                    HtmlGenericControl trSeparator = new HtmlGenericControl("tr");
                    HtmlGenericControl tdSeparator = new HtmlGenericControl("td");

                    HtmlGenericControl tr1 = new HtmlGenericControl("tr");
                    HtmlGenericControl tr2 = new HtmlGenericControl("tr");
                    HtmlGenericControl td1 = new HtmlGenericControl("td");
                    HtmlGenericControl td2 = new HtmlGenericControl("td");

                    HtmlGenericControl div1 = new HtmlGenericControl("div");
                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    HtmlGenericControl ul1 = new HtmlGenericControl("ul");  //上面的ul
                    HtmlGenericControl ul2 = new HtmlGenericControl("ul");  //下面的ul
                    ul1.Attributes.Add("id", "sortable1");
                    ul1.Attributes.Add("class", "connectedSortable");
                    ul2.Attributes.Add("id", "sortable2");
                    ul2.Attributes.Add("class", "connectedSortable");

                    for (int row = Pubrow; row < Rowcount + 1; row++)  //依一個row內的index資料去跑迴圈
                    {
                        Pubrow = row;
                        HtmlGenericControl li1 = new HtmlGenericControl("li");  //包在上面的ul裡面
                        HtmlGenericControl li2 = new HtmlGenericControl("li");  //包在下面的ul裡面

                        HtmlGenericControl divIn1 = new HtmlGenericControl("div");
                        HtmlGenericControl divIn2 = new HtmlGenericControl("div");
                        HtmlGenericControl divIn3 = new HtmlGenericControl("div");
                        HtmlGenericControl divIn4 = new HtmlGenericControl("div");
                        HtmlGenericControl divIn5 = new HtmlGenericControl("div");
                        HtmlGenericControl divIn6 = new HtmlGenericControl("div");
                        HtmlGenericControl divICenter = new HtmlGenericControl("div");
                        HtmlGenericControl divInTotal = new HtmlGenericControl("div");
                        HtmlGenericControl divOldPgno1 = new HtmlGenericControl("div");
                        HtmlGenericControl divOldPgno2 = new HtmlGenericControl("div");
                        //HtmlGenericControl p3 = new HtmlGenericControl("p");

                        #region 半頁+半頁 那就進if
                        //如果是半頁+半頁 那就進if 全頁進else
                        if (dv[row - 1]["公司名稱"].ToString().IndexOf(",") != -1 && dv[row - 1]["刊登頁碼轉"].ToString().IndexOf(",") != -1 && dv[row - 1]["舊稿期別轉"].ToString().IndexOf(",") != -1)
                        {
                            if (row % 4 == 1)  //如果index是1
                            {
                                string[] compName = dv[row - 1]["公司名稱"].ToString().Split(',');
                                string[] pgno = dv[row - 1]["刊登頁碼轉"].ToString().Split(',');
                                string[] old = dv[row - 1]["舊稿期別轉"].ToString().Split(',');
                                string[] oldpgno = dv[row - 1]["舊稿頁碼轉"].ToString().Split(',');
                                divIn1.InnerText = compName[0].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + pgno[0].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + old[0].ToString();
                                divOldPgno1.InnerText = "舊稿頁碼:" + oldpgno[0].ToString();
                                divICenter.InnerText = "----------------";
                                divICenter.Attributes.Add("align", "center");
                                divIn4.InnerText = compName[1].ToString();
                                divIn4.Attributes.Add("style", "color:Red");
                                divIn5.InnerText = "刊登頁碼:" + pgno[1].ToString();
                                divIn5.Attributes.Add("style", "color:Blue");
                                divIn6.InnerText = "舊稿期別:" + old[1].ToString();
                                divOldPgno2.InnerText = "舊稿頁碼:" + oldpgno[1].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                divInTotal.Controls.Add(divICenter);
                                divInTotal.Controls.Add(divIn5);
                                divInTotal.Controls.Add(divIn4);
                                divInTotal.Controls.Add(divIn6);
                                divInTotal.Controls.Add(divOldPgno2);
                                li1.Controls.Add(divInTotal);
                                li1.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li1.Attributes.Add("name", "999");
                                    li1.Attributes.Add("class", "ui-state-default2 ui-state-disabled");
                                }
                                else
                                {
                                    li1.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li1.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul1.Controls.Add(li1);
                            }
                            if (row % 4 == 2)  //如果index是2
                            {
                                string[] compName = dv[row - 1]["公司名稱"].ToString().Split(',');
                                string[] pgno = dv[row - 1]["刊登頁碼轉"].ToString().Split(',');
                                string[] old = dv[row - 1]["舊稿期別轉"].ToString().Split(',');
                                string[] oldpgno = dv[row - 1]["舊稿頁碼轉"].ToString().Split(',');
                                divIn1.InnerText = compName[0].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + pgno[0].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + old[0].ToString();
                                divOldPgno1.InnerText = "舊稿頁碼:" + oldpgno[0].ToString();
                                divICenter.InnerText = "----------------";
                                divICenter.Attributes.Add("align", "center");
                                divIn4.InnerText = compName[1].ToString();
                                divIn4.Attributes.Add("style", "color:Red");
                                divIn5.InnerText = "刊登頁碼:" + pgno[1].ToString();
                                divIn5.Attributes.Add("style", "color:Blue");
                                divIn6.InnerText = "舊稿期別:" + old[1].ToString();
                                divOldPgno2.InnerText = "舊稿頁碼:" + oldpgno[1].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                divInTotal.Controls.Add(divICenter);
                                divInTotal.Controls.Add(divIn5);
                                divInTotal.Controls.Add(divIn4);
                                divInTotal.Controls.Add(divIn6);
                                divInTotal.Controls.Add(divOldPgno2);
                                li2.Controls.Add(divInTotal);
                                li2.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li2.Attributes.Add("name", "999");
                                    li2.Attributes.Add("class", "ui-state-default2 ui-state-disabled");
                                }
                                else
                                {
                                    li2.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li2.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul2.Controls.Add(li2);
                            }
                            if (row % 4 == 3)  //如果index是3
                            {
                                string[] compName = dv[row - 1]["公司名稱"].ToString().Split(',');
                                string[] pgno = dv[row - 1]["刊登頁碼轉"].ToString().Split(',');
                                string[] old = dv[row - 1]["舊稿期別轉"].ToString().Split(',');
                                string[] oldpgno = dv[row - 1]["舊稿頁碼轉"].ToString().Split(',');
                                divIn1.InnerText = compName[0].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + pgno[0].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + old[0].ToString();
                                divOldPgno1.Attributes.Add("style", "color:Blue");
                                divICenter.InnerText = "----------------";
                                divICenter.Attributes.Add("align", "center");
                                divIn4.InnerText = compName[1].ToString();
                                divIn4.Attributes.Add("style", "color:Red");
                                divIn5.InnerText = "刊登頁碼:" + pgno[1].ToString();
                                divIn5.Attributes.Add("style", "color:Blue");
                                divIn6.InnerText = "舊稿期別:" + old[1].ToString();
                                divOldPgno2.InnerText = "舊稿頁碼:" + oldpgno[1].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                divInTotal.Controls.Add(divICenter);
                                divInTotal.Controls.Add(divIn5);
                                divInTotal.Controls.Add(divIn4);
                                divInTotal.Controls.Add(divIn6);
                                divInTotal.Controls.Add(divOldPgno2);
                                li2.Controls.Add(divInTotal);
                                li2.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li2.Attributes.Add("name", "999");
                                    li2.Attributes.Add("class", "ui-state-default2 ui-state-disabled");
                                }
                                else
                                {
                                    li2.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li2.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul2.Controls.Add(li2);
                            }
                            if (row % 4 == 0)  //如果index是4
                            {
                                string[] compName = dv[row - 1]["公司名稱"].ToString().Split(',');
                                string[] pgno = dv[row - 1]["刊登頁碼轉"].ToString().Split(',');
                                string[] old = dv[row - 1]["舊稿期別轉"].ToString().Split(',');
                                string[] oldpgno = dv[row - 1]["舊稿頁碼轉"].ToString().Split(',');
                                divIn1.InnerText = compName[0].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + pgno[0].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + old[0].ToString();
                                divOldPgno1.InnerText = "舊稿頁碼:" + oldpgno[0].ToString();
                                divICenter.InnerText = "----------------";
                                divICenter.Attributes.Add("align", "center");
                                divIn4.InnerText = compName[1].ToString();
                                divIn4.Attributes.Add("style", "color:Red");
                                divIn5.InnerText = "刊登頁碼:" + pgno[1].ToString();
                                divIn5.Attributes.Add("style", "color:Blue");
                                divIn6.InnerText = "舊稿期別:" + old[1].ToString();
                                divOldPgno2.InnerText = "舊稿頁碼:" + oldpgno[1].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                divInTotal.Controls.Add(divICenter);
                                divInTotal.Controls.Add(divIn5);
                                divInTotal.Controls.Add(divIn4);
                                divInTotal.Controls.Add(divIn6);
                                divInTotal.Controls.Add(divOldPgno2);
                                li1.Controls.Add(divInTotal);
                                li1.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li1.Attributes.Add("name", "999");
                                    li1.Attributes.Add("class", "ui-state-default2 ui-state-disabled");
                                }
                                else
                                {
                                    li1.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li1.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul1.Controls.Add(li1);
                            }
                        }

                        #endregion
                        #region 全頁 進else
                        else
                        {
                            if (row % 4 == 1)  //如果index是1
                            {
                                divIn1.InnerText = dv[row - 1]["公司名稱"].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + dv[row - 1]["刊登頁碼轉"].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + dv[row - 1]["舊稿期別轉"].ToString();
                                divOldPgno1.InnerText = "舊稿頁碼:" + dv[row - 1]["舊稿頁碼轉"].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                li1.Controls.Add(divInTotal);
                                li1.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li1.Attributes.Add("name", "999");
                                    li1.Attributes.Add("class", "ui-state-default2 ui-state-disabled");

                                }
                                else
                                {
                                    li1.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li1.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul1.Controls.Add(li1);
                            }
                            if (row % 4 == 2)  //如果index是2
                            {
                                divIn1.InnerText = dv[row - 1]["公司名稱"].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + dv[row - 1]["刊登頁碼轉"].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + dv[row - 1]["舊稿期別轉"].ToString();
                                divOldPgno1.InnerText = "舊稿頁碼:" + dv[row - 1]["舊稿頁碼轉"].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                li2.Controls.Add(divInTotal);
                                li2.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li2.Attributes.Add("name", "999");
                                    li2.Attributes.Add("class", "ui-state-default2 ui-state-disabled");
                                }
                                else
                                {
                                    li2.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li2.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul2.Controls.Add(li2);
                            }
                            if (row % 4 == 3)  //如果index是3
                            {
                                divIn1.InnerText = dv[row - 1]["公司名稱"].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + dv[row - 1]["刊登頁碼轉"].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + dv[row - 1]["舊稿期別轉"].ToString();
                                divOldPgno1.InnerText = "舊稿頁碼:" + dv[row - 1]["舊稿頁碼轉"].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                li2.Controls.Add(divInTotal);
                                li2.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li2.Attributes.Add("name", "999");
                                    li2.Attributes.Add("class", "ui-state-default2 ui-state-disabled");
                                }
                                else
                                {
                                    li2.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li2.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul2.Controls.Add(li2);
                            }
                            if (row % 4 == 0)  //如果index是4
                            {
                                divIn1.InnerText = dv[row - 1]["公司名稱"].ToString();
                                divIn1.Attributes.Add("style", "color:Red");
                                divIn2.InnerText = "刊登頁碼:" + dv[row - 1]["刊登頁碼轉"].ToString();
                                divIn2.Attributes.Add("style", "color:Blue");
                                divIn3.InnerText = "舊稿期別:" + dv[row - 1]["舊稿期別轉"].ToString();
                                divOldPgno1.InnerText = "舊稿頁碼:" + dv[row - 1]["舊稿頁碼轉"].ToString();
                                divInTotal.Controls.Add(divIn2);
                                divInTotal.Controls.Add(divIn1);
                                divInTotal.Controls.Add(divIn3);
                                divInTotal.Controls.Add(divOldPgno1);
                                li1.Controls.Add(divInTotal);
                                li1.Attributes.Add("class", "ui-state-default2");
                                if (dv[row - 1]["公司名稱"].ToString().Trim() == "")//如果是硬塞進去的值 會沒有公司名稱 所以就把name給空掉
                                {
                                    li1.Attributes.Add("name", "999");
                                    li1.Attributes.Add("class", "ui-state-default2 ui-state-disabled");
                                }
                                else
                                {
                                    li1.Attributes.Add("name", dv[row - 1]["刊登頁碼轉"].ToString() + "~" + dv[row - 1]["合約書編號"].ToString() + "~" + dv[row - 1]["刊登年月"].ToString() + "~" + dv[row - 1]["落版序號"].ToString());
                                    li1.Attributes.Add("style", dv[row - 1]["拉頁標註"].ToString().Trim() == "1" ? borderColor("拉頁") : borderColor(dv[row - 1]["廣告色彩"].ToString() + "-" + dv[row - 1]["廣告篇幅"].ToString()));
                                }
                                ul1.Controls.Add(li1);
                            }
                        }

                        #endregion

                        if (row % 16 == 0)
                        {
                            Pubrow = row + 1;
                            break;
                        }

                    }


                    div1.Controls.Add(ul1);
                    div2.Controls.Add(ul2);
                    td1.Controls.Add(div1);
                    td2.Controls.Add(div2);
                    tr1.Controls.Add(td1);
                    tr2.Controls.Add(td2);
                    table.Controls.Add(tr1);
                    table.Controls.Add(tr2);
                    tdSeparator.InnerText = " ";
                    tdSeparator.Attributes.Add("style", "height:20px");
                    trSeparator.Controls.Add(tdSeparator);
                    table.Controls.Add(trSeparator);
                }

                PanelLayoutAll.Controls.Add(table);
            }
        }

        private string borderColor(string color)
        {
            string feedbkSTR = "";
            string switchSTR = color.IndexOf("-") == -1 ? color : color.Substring(0, color.IndexOf("-"));
            switch (switchSTR)
            {
                case "彩色":
                    {
                        feedbkSTR = "border-color:Green; border-width:3px";
                        break;
                    }
                case "套色":
                    {
                        feedbkSTR = "border-color:#fe7800; border-width:3px";
                        break;
                    }
                case "黑白":
                    {
                        if (color.IndexOf("半頁") == -1)
                        {
                            feedbkSTR = "border-color:Black; border-width:3px";
                        }
                        else
                        {
                            feedbkSTR = "";
                        }
                        
                        break;
                    }
                case "拉頁":
                    {
                        feedbkSTR = "border-color:Red; border-width:3px";
                        break;
                    }
                default:
                    {
                        feedbkSTR = "";
                        break;
                    }
            }
            return feedbkSTR;
        }

        protected void specialGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "合約書<br />編號";
                e.Row.Cells[2].Text = "落版<br />序號";
                e.Row.Cells[3].Text = "刊登<br />年月";
                e.Row.Cells[4].Text = "刊登<br />頁碼";
                e.Row.Cells[8].Text = "固定<br />頁次";
                e.Row.Cells[11].Text = "新稿<br />製法";
                e.Row.Cells[12].Text = "改稿<br />書籍";
                e.Row.Cells[13].Text = "改稿<br />期別";
                e.Row.Cells[14].Text = "改稿<br />頁碼";
                e.Row.Cells[15].Text = "改稿<br />重出片";
                e.Row.Cells[16].Text = "舊稿<br />書籍";
                e.Row.Cells[17].Text = "舊稿<br />期別";
                e.Row.Cells[18].Text = "舊稿<br />頁碼";
                e.Row.Cells[19].Text = "落版<br />業務員";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }

        //protected void CommonGV_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.Cells[1].Text = "合約書<br />編號";
        //        e.Row.Cells[2].Text = "落版<br />序號";
        //        e.Row.Cells[3].Text = "刊登<br />年月";
        //        e.Row.Cells[4].Text = "刊登<br />頁碼";
        //        e.Row.Cells[8].Text = "固定<br />頁次";
        //        e.Row.Cells[11].Text = "新稿<br />製法";
        //        e.Row.Cells[12].Text = "改稿<br />書籍";
        //        e.Row.Cells[13].Text = "改稿<br />期別";
        //        e.Row.Cells[14].Text = "改稿<br />頁碼";
        //        e.Row.Cells[15].Text = "改稿<br />重出片";
        //        e.Row.Cells[16].Text = "舊稿<br />書籍";
        //        e.Row.Cells[17].Text = "舊稿<br />期別";
        //        e.Row.Cells[18].Text = "舊稿<br />頁碼";
        //        e.Row.Cells[19].Text = "落版<br />業務員";
        //    }

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //    }
        //}

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript",
            //"function checkLayout() {var liObjs = document.getElementsByTagName('ul');for (var i = 0; i < liObjs.length; i++) {if (liObjs[i].getAttribute('id') != '' && liObjs[i].getAttribute('id') != null) {if (liObjs[i].childNodes.length != 8) {alert('落版錯誤 請檢查');return;}}}}", true);

            string[] array = hidData_special.Value.Split('-');
            //string[] array = hidData_special.Text.Split('-');
            string[] afterArray = new string[array.Length];//弄一個新的array 把空格先空出來
            //備註 因為落版已經被我弄成16的倍數(後面就算沒值的 也會被補上空格 所以底下的迴圈就不會有問題了)
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 16 == 0)
                {
                    afterArray[i] = array[i];
                }
                if (i % 16 == 1)
                {
                    afterArray[i] = array[i + 7];
                }
                if (i % 16 == 2)
                {
                    afterArray[i] = array[i + 7];
                }
                if (i % 16 == 3)
                {
                    afterArray[i] = array[i - 2];
                }
                if (i % 16 == 4)
                {
                    afterArray[i] = array[i - 2];
                }
                if (i % 16 == 5)
                {
                    afterArray[i] = array[i + 5];
                }
                if (i % 16 == 6)
                {
                    afterArray[i] = array[i + 5];
                }
                if (i % 16 == 7)
                {
                    afterArray[i] = array[i - 4];
                }
                if (i % 16 == 8)
                {
                    afterArray[i] = array[i - 4];
                }
                if (i % 16 == 9)
                {
                    afterArray[i] = array[i + 3];
                }
                if (i % 16 == 10)
                {
                    afterArray[i] = array[i + 3];
                }
                if (i % 16 == 11)
                {
                    afterArray[i] = array[i - 6];
                }
                if (i % 16 == 12)
                {
                    afterArray[i] = array[i - 6];
                }
                if (i % 16 == 13)
                {
                    afterArray[i] = array[i + 1];
                }
                if (i % 16 == 14)
                {
                    afterArray[i] = array[i + 1];
                }
                if (i % 16 == 15)
                {
                    afterArray[i] = array[i - 8];
                }
            }


            int StartNum = GetStartPageNo();
            string Page = "";
            for (int j = 0; j < afterArray.Length; j++)
            {
                if (afterArray[j].ToString().Trim() != "999")//如果不是空的跟填塞的
                {
                    string[] finalsplit = afterArray[j].ToString().Split('~');
                    if (finalsplit[0].ToString().IndexOf(",") != -1 && finalsplit[1].ToString().IndexOf(",") != -1 && finalsplit[2].ToString().IndexOf(",") != -1 && finalsplit[3].ToString().IndexOf(",") != -1)
                    {
                        //如果是半頁
                        string[] halfArray0 = finalsplit[0].ToString().Split(',');
                        string[] halfArray1 = finalsplit[1].ToString().Split(',');
                        string[] halfArray2 = finalsplit[2].ToString().Split(',');
                        string[] halfArray3 = finalsplit[3].ToString().Split(',');
                        myadpub.UpdatePgno(StartNum, halfArray1[0].ToString(), halfArray2[0].ToString(), halfArray3[0].ToString(), Convert.ToInt32(halfArray0[0].ToString()));
                        myadpub.UpdatePgno(StartNum, halfArray1[1].ToString(), halfArray2[1].ToString(), halfArray3[1].ToString(), Convert.ToInt32(halfArray0[1].ToString()));
                        StartNum++;
                    }
                    else
                    {
                        //如果是全頁
                        myadpub.UpdatePgno(StartNum, finalsplit[1].ToString(), finalsplit[2].ToString(), finalsplit[3].ToString(), Convert.ToInt32(finalsplit[0].ToString()));
                        StartNum++;
                    }
                }
                else
                {
                    continue;
                    ////如果等於空的或是多出來填塞在後面的 name就會等於999
                    //StartNum++;
                }
            }

            //string textarray = "";
            //for (int j = 0; j < afterArray.Length; j++)
            //{
            //    if (j == afterArray.Length - 1)
            //    {
            //        textarray = textarray + afterArray[j].ToString();
            //    }
            //    else
            //    {
            //        textarray = textarray + afterArray[j].ToString() + "-";
            //    }
            //}
            //Response.Write(textarray);//到此步驟可以把排序順好 
            //hidData_special.Text = textarray;

            JavaScript.AlertMessageRedirect(this.Page, "落版完成!!", string.Format("adpub_act2.aspx?bkcd={0}&yyyymm={1}", Request["bkcd"].ToString(), Request["yyyymm"].ToString()));
            //Response.Redirect(string.Format("adpub_act2.aspx?bkcd={0}&yyyymm={1}", Request["bkcd"].ToString(), Request["yyyymm"].ToString()));
        }

        #region 判斷匯出Excel時每一格是何種色彩
        public TXlsCellRange judgeColor(string colorType)
        {
            TXlsCellRange RangeSpec = new TXlsCellRange("B3:B3");//特殊版面
            TXlsCellRange RangeColor = new TXlsCellRange("B4:B4");//彩色版面
            TXlsCellRange RangeInClude = new TXlsCellRange("B5:B5");//套色版面
            TXlsCellRange RangeComm = new TXlsCellRange("B6:B6");//一般版面

            TXlsCellRange rangeOutPut = null;
            switch (colorType)
            {
                case "特殊":
                    {
                        rangeOutPut = RangeSpec;
                        break;
                    }
                case "彩色":
                    {
                        rangeOutPut = RangeColor;
                        break;
                    }
                case "套色":
                    {
                        rangeOutPut = RangeInClude;
                        break;
                    }
                case "黑白":
                    {
                        rangeOutPut = RangeComm;
                        break;
                    }
            }

            return rangeOutPut;
        }
        #endregion

        #region c2_pgno裡面有規定起始的頁碼應該是多少 GetStartPageNo()是去抓那個頁碼數 -1是因為前面要補起始頁碼的前面剩的數目
        public DataView AddNewFront(DataView dv)
        {
            for (int i = 0; i < GetStartPageNo() - 1; i++)//c2_pgno裡面有規定起始的頁碼應該是多少 GetStartPageNo()是去抓那個頁碼數 -1是因為前面要補起始頁碼的前面剩的數目
            {
                DataRowView drv = dv.AddNew();
                drv["刊登頁碼"] = 5 - 6 - i;
                drv.EndEdit();
            }

            return dv;
        }
        #endregion

        #region 新增三個原本是int的欄位 轉換為string
        public DataView ThreeString(DataView dv)
        {
            DataTable dtConvert = dv.ToTable();
            DataColumn dc1 = null;
            DataColumn dc2 = null;
            DataColumn dc3 = null;
            dc1 = dtConvert.Columns.Add("刊登頁碼轉", Type.GetType("System.String"));
            dc2 = dtConvert.Columns.Add("舊稿期別轉", Type.GetType("System.String"));
            dc3 = dtConvert.Columns.Add("舊稿頁碼轉", Type.GetType("System.String"));
            for (int i = 0; i < dtConvert.Rows.Count; i++)
            {
                dtConvert.Rows[i]["刊登頁碼轉"] = dtConvert.Rows[i]["刊登頁碼"].ToString();
                dtConvert.Rows[i]["舊稿期別轉"] = dtConvert.Rows[i]["舊稿期別"].ToString().Trim() == "" ? "0" : dtConvert.Rows[i]["舊稿期別"].ToString();
                dtConvert.Rows[i]["舊稿頁碼轉"] = dtConvert.Rows[i]["舊稿頁碼"].ToString().Trim() == "" ? "" : dtConvert.Rows[i]["舊稿頁碼"].ToString();
            }

            dv = dtConvert.DefaultView;
            return dv;
        }
        #endregion

        #region 把同樣頁碼的合併
        public DataView MergeCell(DataView dv)
        {
            int firstpgnp = Convert.ToInt32(dv[0]["刊登頁碼"].ToString());//先抓出第一筆的頁碼
            for (int count = 1; count < dv.Count; count++)
            {
                if (firstpgnp != 0)
                {
                    if (Convert.ToInt32(dv[count]["刊登頁碼"].ToString()) == firstpgnp)//如果第0筆跟第一筆一樣
                    {
                        DataRowView drv = dv[count];

                        drv.BeginEdit();
                        drv[1] = dv[count - 1]["合約書編號"].ToString() + "," + dv[count]["合約書編號"].ToString();
                        drv[2] = dv[count - 1]["落版序號"].ToString() + "," + dv[count]["落版序號"].ToString();
                        drv[3] = dv[count - 1]["刊登年月"].ToString() + "," + dv[count]["刊登年月"].ToString();
                        drv[20] = dv[count - 1]["公司名稱"].ToString() + "," + dv[count]["公司名稱"].ToString();
                        drv[33] = dv[count - 1]["刊登頁碼轉"].ToString() + "," + dv[count]["刊登頁碼轉"].ToString();
                        drv[34] = dv[count - 1]["舊稿期別轉"].ToString() + "," + dv[count]["舊稿期別轉"].ToString();
                        drv[35] = dv[count - 1]["舊稿頁碼轉"].ToString() + "," + dv[count]["舊稿頁碼轉"].ToString();
                        drv.EndEdit();
                        drv.BeginEdit();
                        drv = dv[count - 1];
                        count--;
                        drv.Delete();
                        //4.結束編輯DataView
                        drv.EndEdit();

                    }
                    firstpgnp = Convert.ToInt32(dv[count]["刊登頁碼"].ToString());
                }

            }
            return dv;

        }
        #endregion

        #region 判斷迴圈內每一筆資料是什麼顏色

        public string ForLoopColor(int i,DataView dvComm)
        {
            if (i < GetStartPageNo() - 1 && dvComm[i]["公司名稱"].ToString().Trim() == "")
            {
                return "黑白";//前面那5筆空的 用黑白全頁給他
            }
            else
            {
                return dvComm[i]["廣告色彩"].ToString().Trim();
            }
        }
        #endregion

        protected void exportExcelBtn_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Layout/Template/adpub_act2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            //Xls.InsertAndCopyRange(myRange2, dt.Rows.Count + 4 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);

            // 抓出網頁變數 bkcd & yyyymm
            string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
            string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

            DataSet dsComm = myadpub.SelectCommonGV(Reqbkcd, Reqyyyymm);
            DataView dvComm = dsComm.Tables[0].DefaultView;//一般版面

            dvComm = AddNewFront(dvComm);//c2_pgno裡面有規定起始的頁碼應該是多少 GetStartPageNo()是去抓那個頁碼數 -1是因為前面要補起始頁碼的前面剩的數目
            dvComm.Sort = "刊登頁碼 asc";
            dvComm = ThreeString(dvComm);//新增三個原本是int的欄位 轉換為string
            dvComm = MergeCell(dvComm);//把同樣頁碼的合併



            DataSet dsSpec = myadpub.SelectspecialGV(Reqbkcd, Reqyyyymm);
            DataView dvSpec = dsSpec.Tables[0].DefaultView;//特殊版面
            //dvSpec.RowFilter = " 頁次 = 0 ";

            #region 設定欄位高度 因為落板不可能超過那麼多筆 所以設定底下的高度寫死就夠了

            Xls.SetRowHeight(2, 1400);

            Xls.SetRowHeight(4, 1400);
            Xls.SetRowHeight(5, 1400);
                                 
            Xls.SetRowHeight(7, 1400);
            Xls.SetRowHeight(8, 1400);

            Xls.SetRowHeight(10, 1400);
            Xls.SetRowHeight(11, 1400);
                                 
            Xls.SetRowHeight(13, 1400);
            Xls.SetRowHeight(14, 1400);
                                   
            Xls.SetRowHeight(16, 1400);
            Xls.SetRowHeight(17, 1400);

            Xls.SetRowHeight(19, 1400);
            Xls.SetRowHeight(20, 1400);

            Xls.SetRowHeight(22, 1400);
            Xls.SetRowHeight(23, 1400);
            #endregion

            #region 期別
            DataSet dsBookp = myadpub.SelectBookp(Reqyyyymm);

            if (dsBookp.Tables[0].Rows.Count > 0)
            {
                Xls.SetCellValue(2, 1, dsBookp.Tables[0].Rows[0]["bkp_pno"].ToString().Trim());
            }
            #endregion

            #region 特殊版面之框架
            for (int i = 0; i < dvSpec.Count; i++)
            {
                Xls.InsertAndCopyRange(judgeColor("特殊"), 2, 2 + i, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                Xls.SetCellValue(2, 2 + i, dvSpec[i]["廣告版面"].ToString() + "\t\n" + "公司名稱:" + dvSpec[i]["公司名稱"].ToString() + "\t\n" + "舊稿期別:" + dvSpec[i]["舊稿期別"].ToString() + "\t\n" + "舊稿頁碼:" + dvSpec[i]["舊稿頁碼"].ToString());
            }
            #endregion

            #region 一般版面之框架
            int whichRow = 4;//用來判斷現在是第幾個ROW
            int whichCol = 1;//用來判斷現在是第幾個Col
            for (int i = 0; i < dvComm.Count; i++)
            {
                if (i % 16 == 0 && i != 0)//跳下一台
                {
                    whichRow = whichRow + 3;
                    whichCol = 1;
                }

                if (i % 4 == 0)//左上
                {
                    Xls.InsertAndCopyRange(judgeColor(ForLoopColor(i, dvComm)), whichRow, whichCol, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                    Xls.SetCellValue(whichRow, whichCol, "刊登頁碼:" + dvComm[i]["刊登頁碼轉"].ToString() + "\t\n" + "公司名稱:" + dvComm[i]["公司名稱"].ToString() + "\t\n" + "舊稿期別:" + dvComm[i]["舊稿期別轉"].ToString() + "\t\n" + "舊稿頁碼:" + dvComm[i]["舊稿頁碼轉"].ToString());
                }
                if (i % 4 == 1)//左下
                {
                    Xls.InsertAndCopyRange(judgeColor(ForLoopColor(i, dvComm)), whichRow + 1, whichCol, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                    Xls.SetCellValue(whichRow + 1, whichCol, "刊登頁碼:" + dvComm[i]["刊登頁碼轉"].ToString() + "\t\n" + "公司名稱:" + dvComm[i]["公司名稱"].ToString() + "\t\n" + "舊稿期別:" + dvComm[i]["舊稿期別轉"].ToString() + "\t\n" + "舊稿頁碼:" + dvComm[i]["舊稿頁碼轉"].ToString());
                    whichCol++;
                }
                if (i % 4 == 2)//右下
                {
                    Xls.InsertAndCopyRange(judgeColor(ForLoopColor(i, dvComm)), whichRow + 1, whichCol, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                    Xls.SetCellValue(whichRow + 1, whichCol, "刊登頁碼:" + dvComm[i]["刊登頁碼轉"].ToString() + "\t\n" + "公司名稱:" + dvComm[i]["公司名稱"].ToString() + "\t\n" + "舊稿期別:" + dvComm[i]["舊稿期別轉"].ToString() + "\t\n" + "舊稿頁碼:" + dvComm[i]["舊稿頁碼轉"].ToString());
                }
                if (i % 4 == 3)//右上
                {
                    Xls.InsertAndCopyRange(judgeColor(ForLoopColor(i, dvComm)), whichRow, whichCol, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                    Xls.SetCellValue(whichRow, whichCol, "刊登頁碼:" + dvComm[i]["刊登頁碼轉"].ToString() + "\t\n" + "公司名稱:" + dvComm[i]["公司名稱"].ToString() + "\t\n" + "舊稿期別:" + dvComm[i]["舊稿期別轉"].ToString() + "\t\n" + "舊稿頁碼:" + dvComm[i]["舊稿頁碼轉"].ToString());
                    whichCol++;
                }

            }
            #endregion


            Common.excuteExcel(Xls, "adpub_act2.xls");
        }
        
    }
}