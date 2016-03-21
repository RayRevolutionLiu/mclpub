using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace mclpub.Layout
{
    public partial class PubFm : System.Web.UI.Page
    {
        PubFm_DB myPub = new PubFm_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                imbIMRefresh.Attributes.Add("style", "display:none");
                // 抓預設資料 (廠商客戶資料) - 新增Form
                InitialData();

                // 給預設值, 如刊登年月, 書籍期別
                //NewData();

                // 預設: 隱藏 落版序號; 按下 修改時才會顯示
                this.lblPubSeq.Visible = false;


                // 檢查是否 已落版 (0: 否; 1: 是)
                if (Context.Request.QueryString["fgnew"].ToString().Trim() == "0")
                {
                    // do nothing 不載入 (無初始資料)
                    this.lblAddMessage.Text = "無初始資料, 請自行新增!<br>";
                }
                else
                {
                    BindGrid1();
                }
                //BindGrid1();
            }
            imgContdetail.Attributes.Add("onclick", "javascript:doDetail('800','700','../Contract/ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(hiddenCustNo.Value) + "&cont_contno=" +sec.encryptquerystring(tbxContNo.Text) + "&dpplane=false')");
        }


        // 載入 已新增之資料
        private void BindGrid1()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myPub.Selectc2_pub();
            DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";

            string contno = "";
            if (Context.Request.QueryString["contno"].ToString().Trim() != "")
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
                rowfilterstr1 = rowfilterstr1 + " and pub_syscd = 'C2'";
                rowfilterstr1 = rowfilterstr1 + " and pub_contno = '" + contno + "'";
            }
            else
            {
                contno = "";
            }
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv1.Count > 0)
            {
                DataGrid1.DataSource = dv1;
                DataGrid1.DataBind();

                // 若有落版資料, 則顯示其合計資料－已落版 總筆數, 已落版 總稿件, 已落版總廣告金額 & 已落版總換稿金額
                GetCounts();


                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                int i;
                for (i = 0; i < DataGrid1.Items.Count; i++)
                {
                    // 刊登年月
                    //string yyyymm = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
                    //yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
                    //DataGrid1.Items[i].Cells[3].Text = yyyymm;

                    // 固定頁次註記
                    string fgfixpg = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
                    if (fgfixpg == "0")
                        fgfixpg = "否";
                    else
                        fgfixpg = "是";
                    DataGrid1.Items[i].Cells[10].Text = fgfixpg;

                    // 稿件類別
                    string drafttp = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
                    switch (drafttp)
                    {
                        case "1":
                            DataGrid1.Items[i].Cells[13].Text = "舊稿";
                            DataGrid1.Items[i].Cells[14].Text = "";
                            break;
                        case "2":
                            DataGrid1.Items[i].Cells[13].Text = "新稿";
                            // 到稿註記
                            string fggot1 = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
                            if (fggot1 == "0")
                                fggot1 = "否";
                            else
                                fggot1 = "是";
                            DataGrid1.Items[i].Cells[14].Text = fggot1;
                            break;
                        case "3":
                            DataGrid1.Items[i].Cells[13].Text = "改稿";
                            // 到稿註記
                            string fggot2 = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
                            if (fggot2 == "0")
                                fggot2 = "否";
                            else
                                fggot2 = "是";
                            DataGrid1.Items[i].Cells[14].Text = fggot2;
                            break;
                        default:
                            DataGrid1.Items[i].Cells[13].Text = "舊稿";
                            DataGrid1.Items[i].Cells[14].Text = "";
                            break;
                    }

                    // 舊稿期別 -- 只有當稿件類別是 舊稿時, 才顯示此欄資料
                    if (drafttp == "1")
                        DataGrid1.Items[i].Cells[15].Text = DataGrid1.Items[i].Cells[15].Text;
                    else
                        DataGrid1.Items[i].Cells[15].Text = "";

                    // 改稿期別 -- 只有當稿件類別是 改稿時, 才顯示此欄資料
                    if (drafttp == "3")
                        DataGrid1.Items[i].Cells[16].Text = DataGrid1.Items[i].Cells[16].Text;
                    else
                        DataGrid1.Items[i].Cells[16].Text = "";

                    // 已開發票開立單註記
                    string fginved = DataGrid1.Items[i].Cells[19].Text.ToString().Trim();
                    if (fginved != "")
                    {
                        if (fginved == "9")
                            fginved = "<font color=Blue>已挑未開(特別處理)</font>";
                        if (fginved == "t")
                            fginved = "<font color=Blue>已挑未開</font>";
                        if (fginved == "v")
                            fginved = "<font color=Blue>已挑未開</font>";
                        else if (fginved == "1")
                            fginved = "<font color=Red>是(已開)</font>";
                    }
                    else
                        fginved = "否(未開)";
                    DataGrid1.Items[i].Cells[19].Text = fginved;

                    // 發票開立單人工處理註記
                    string fginvself = DataGrid1.Items[i].Cells[20].Text.ToString().Trim();
                    if (fginvself == "0")
                        fginvself = "否";
                    else
                        fginvself = "<font color=Red>是</font>";
                    DataGrid1.Items[i].Cells[20].Text = fginvself;


                    // 院所內註記
                    string fgitri = DataGrid1.Items[i].Cells[25].Text.ToString().Trim();
                    //Response.Write("fgitri= " + fgitri + "<br>");
                    switch (fgitri)
                    {
                        case "":
                            DataGrid1.Items[i].Cells[26].ForeColor = Color.Black;
                            break;
                        case "06":
                            DataGrid1.Items[i].Cells[26].ForeColor = Color.OrangeRed;
                            break;
                        case "07":
                            DataGrid1.Items[i].Cells[26].ForeColor = Color.Blue;
                            break;
                        default:
                            DataGrid1.Items[i].Cells[25].ForeColor = Color.Black;
                            break;
                    }
                }
                this.lblAddMessage.Text = "";
            }
            else
            {
                // 若無 落版資料
                this.DataGrid1.Visible = false;
                this.lblAddMessage.Text = this.lblAddMessage.Text;


                // 更新 已落版註記 (以免刪除落版資料到底時, 其合約書之已落版註記是錯的資料)
                string strSyscd = "C2";
                string strContNo = this.tbxContNo.Text.ToString().Trim();
                //Response.Write("strSyscd= " + strSyscd + "<br>");
                //Response.Write("strContNo= " + strContNo + "<br>");

                // 執行 將值塞入 sqlCommand5.Parameters 中, 以執行 新增入資料庫
                //Response.Write(this.sqlCommand5.CommandText);
                myPub.Updatec2_cont(strSyscd, strContNo);

            }
        }

        // 若有落版資料, 則顯示其合計資料－已落版 總筆數, 已落版 總稿件, 已落版總廣告金額 & 已落版總換稿金額
        private void GetCounts()
        {
            string strContNo = this.tbxContNo.Text.ToString().Trim();
            //Response.Write("strContNo= " + strContNo + "<br>");


            // 顯示 已落版 總筆數
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds13 = myPub.Selectc2_pub2();
            DataView dv13 = ds13.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr13 = "1=1";
            rowfilterstr13 = rowfilterstr13 + " AND pub_syscd='C2'";
            rowfilterstr13 = rowfilterstr13 + " AND pub_contno='" + strContNo + "'";
            dv13.RowFilter = rowfilterstr13;


            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv13.Count= "+ dv13.Count + "<BR>");
            //Response.Write("dv13.RowFilter= " + dv13.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            int PubCounts = 0;
            if (dv13.Count > 0)
            {
                PubCounts = Convert.ToInt32(dv13[0]["CountNo"].ToString().Trim());
                this.lblPubCounts.Text = "(已落版 總筆數：" + PubCounts + ")";
            }
            else
            {
                this.lblPubCounts.Text = "<font color='Red'>(已落版 總筆數：0)</font>";
            }


            // 顯示 已落版 總稿件
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds15 = myPub.Selectc2_pub3();
            DataView dv15 = ds15.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr15 = "1=1";
            rowfilterstr15 = rowfilterstr15 + " AND pub_syscd='C2'";
            rowfilterstr15 = rowfilterstr15 + " AND pub_contno='" + strContNo + "'";
            dv15.RowFilter = rowfilterstr15;


            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv15.Count= "+ dv15.Count + "<BR>");
            //Response.Write("dv15.RowFilter= " + dv15.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            string Drafttp, DraftName;
            int DraftCounts = 0;
            if (dv15.Count > 0)
            {
                this.lblDraftCounts.Text = "（已落版 總稿件－";

                for (int i = 0; i < dv15.Count; i++)
                {
                    Drafttp = dv15[i]["pub_drafttp"].ToString().Trim();
                    //Response.Write("Drafttp= " + Drafttp + "<br>");
                    switch (Drafttp)
                    {
                        case "1":
                            DraftName = "舊稿";
                            break;
                        case "2":
                            DraftName = "新稿";
                            break;
                        case "3":
                            DraftName = "改稿";
                            break;
                        default:
                            DraftName = "舊稿";
                            break;
                    }
                    DraftCounts = Convert.ToInt32(dv15[i]["CountNo"].ToString().Trim());
                    this.lblDraftCounts.Text = this.lblDraftCounts.Text + DraftName + "：" + DraftCounts + "／";
                }
                int Leni = this.lblDraftCounts.Text.Length;
                //Response.Write("Leni= " + Leni + "<br>");
                this.lblDraftCounts.Text = this.lblDraftCounts.Text.Substring(0, Leni - 1) + "）";
            }
            else
            {
                this.lblDraftCounts.Text = "（已落版稿件－無）";
            }


            // 顯示 已落版總廣告金額 & 已落版總換稿金額
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds13_2 = myPub.Selectc2_pub4();
            DataView dv13_2 = ds13_2.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr13_2 = "1=1";
            rowfilterstr13_2 = rowfilterstr13_2 + " AND pub_syscd='C2'";
            rowfilterstr13_2 = rowfilterstr13_2 + " AND pub_contno='" + strContNo + "'";
            dv13_2.RowFilter = rowfilterstr13_2;


            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv13_2.Count= "+ dv13_2.Count + "<BR>");
            //Response.Write("dv13_2.RowFilter= " + dv13_2.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            int TotPubAdAmt = 0;
            int TotPubChgAmt = 0;
            if (dv13_2.Count > 0)
            {
                TotPubAdAmt = Convert.ToInt32(dv13_2[0]["pub_adamt"].ToString().Trim());
                TotPubChgAmt = Convert.ToInt32(dv13_2[0]["pub_chgamt"].ToString().Trim());
                this.lblAmtCounts.Text = "（已落版 總廣告金額／總換稿金額：$" + TotPubAdAmt + "／$" + TotPubChgAmt + "）";
            }
            else
            {
                this.lblAmtCounts.Text = "<font color='Red'>已落版 總廣告金額／總換稿金額：$0／$0</font>";
            }
        }

        private void InitialData()
        {
            this.hiddenMfrNo.Value = "";
            this.hiddenCustNo.Value = "";
            this.hiddenIMfgitri.Value = "";


            // 顯示下拉式選單 廣告色彩的 DB 值
            DataSet ds3 = myPub.Selectc2_clr();
            ddlColorCode.DataSource = ds3;
            ddlColorCode.DataTextField = "clr_nm";
            ddlColorCode.DataValueField = "clr_clrcd";
            ddlColorCode.DataBind();

            // 顯示下拉式選單 廣告版面的 DB 值
            DataSet ds4 = myPub.Selectc2_ltp();
            ddlLTypeCode.DataSource = ds4;
            ddlLTypeCode.DataTextField = "ltp_nm";
            ddlLTypeCode.DataValueField = "ltp_ltpcd";
            ddlLTypeCode.DataBind();

            // 顯示下拉式選單 廣告篇幅的 DB 值
            DataSet ds5 = myPub.Selectc2_pgs();
            ddlPageSizeCode.DataSource = ds5;
            ddlPageSizeCode.DataTextField = "pgs_nm";
            ddlPageSizeCode.DataValueField = "pgs_pgscd";
            ddlPageSizeCode.DataBind();

            // 顯示下拉式選單 新稿製法的 DB 值
            DataSet ds6 = myPub.Selectc2_njtp();
            ddlNJTypeCode.DataSource = ds6;
            ddlNJTypeCode.DataTextField = "njtp_nm";
            ddlNJTypeCode.DataValueField = "njtp_njtpcd";
            ddlNJTypeCode.DataBind();

            // 顯示下拉式選單 舊稿書類的 DB 值
            DataSet ds7 = myPub.SelectBook();
            DataView dv7 = ds7.Tables[0].DefaultView;
            ddlOrigBookCode.DataSource = dv7;
            dv7.RowFilter = "proj_fgitri=''";
            ddlOrigBookCode.DataTextField = "bk_nm";
            ddlOrigBookCode.DataValueField = "bk_bkcd";
            ddlOrigBookCode.DataBind();

            // 顯示下拉式選單 改稿書類的 DB 值
            DataSet ds72 = myPub.SelectBook();
            ddlChgBookCode.DataSource = ds72;
            ddlChgBookCode.DataTextField = "bk_nm";
            ddlChgBookCode.DataValueField = "bk_bkcd";
            ddlChgBookCode.DataBind();

            string strbkcd = "";
            if (Context.Request.QueryString["bkcd"].ToString().Trim() != "")
            {
                strbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
            }
            else
            {
                strbkcd = "";
            }
            //Response.Write("strbkcd= " + strbkcd + "<br>");
            this.tbxBkcd.Text = strbkcd;


            // 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
            this.btnSave.Visible = true;
            this.btnModify.Visible = false;
            this.btnLoadData.Visible = true;
            this.btnGoChkList.Visible = true;
            this.lblPubSeq.Visible = false;

            // 隱藏不同的稿件類別
            this.ddlLTypeCode.SelectedIndex = 0;
            this.ddlColorCode.SelectedIndex = 0;
            this.ddlPageSizeCode.SelectedIndex = 0;
            this.ddlDraftType.SelectedIndex = 0;
            this.ddlOrigBookCode.SelectedIndex = 0;
            this.rblfggot.Visible = false;
            this.pnlOrig.Visible = true;
            this.pnlChg.Visible = false;
            this.rblfgrechg.Visible = false;
            this.pnlNjtp.Visible = false;
            this.rblfggot.Visible = false;

            // 固定頁次預設值 (否: 0, 若變更廣告版面, 則也會變更固定頁次註記之值)
            this.rblfgfixpage.SelectedIndex = 1;


            // 載入 合約書相關資料
            LoadContData();


            // 預選 下拉式選單
            SetPullDownIndex();

            //慧芸新增 要把一進來的舊稿期別 廣告色彩 廣告篇幅 都預設成GRID裡面最新的一筆
            SetDefaultValue();
        }

        private void SetDefaultValue()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            string contno = "";
            if (Context.Request.QueryString["contno"].ToString().Trim() != "")
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
            }

            DataSet ds1 = myPub.SelectTop1c2_pub(contno);


            if (ds1.Tables[0].Rows.Count > 0)
            {
                this.ddlLTypeCode.ClearSelection();
                this.ddlLTypeCode.Items.FindByValue(ds1.Tables[0].Rows[0]["pub_ltpcd"].ToString()).Selected = true;//廣告版面
                this.ddlColorCode.ClearSelection();
                this.ddlColorCode.Items.FindByValue(ds1.Tables[0].Rows[0]["pub_clrcd"].ToString()).Selected = true;//廣告色彩
                this.ddlPageSizeCode.ClearSelection();
                this.ddlPageSizeCode.Items.FindByValue(ds1.Tables[0].Rows[0]["pub_pgscd"].ToString()).Selected = true;//廣告篇幅
                //tbxOrigjno.Text = ds1.Tables[0].Rows[0]["pub_pno"].ToString();//舊稿期別
                //tbxOrigbkno.Text = ds1.Tables[0].Rows[0]["pub_pgno"].ToString();//舊稿頁碼
                tbxOrigjno.Text = "";//舊稿期別 2021/05/11慧芸又要讓預設值空值
                tbxOrigbkno.Text = "";//舊稿頁碼 2021/05/11慧芸又要讓預設值空值
                //dv1[0]["pub_ltpcd"].ToString()

            }

            //Response.Write(ds1.Tables[0].Rows.Count);
        }

        // 預選 下拉式選單
        private void SetPullDownIndex()
        {
            // 廣告版面
            this.ddlLTypeCode.ClearSelection();
            this.ddlLTypeCode.SelectedIndex = 0;

            // 廣告色彩, 並判斷 合約書之彩/套/黑白次數(>0), 來預選廣告色彩 (Selected)
            // 缺點: 若同時有 兩種以上色彩存在時, 依 if elseif 的先後次序來顯示(如 彩/套=>出現彩色; 套/黑白=>出現套色)
            this.ddlColorCode.ClearSelection();
            if (int.Parse(this.tbxClrtm.Text == "" ? "0" : tbxClrtm.Text) > 0)
                this.ddlColorCode.Items.FindByValue("01").Selected = true;
            else if (int.Parse(this.tbxGetClrtm.Text == "" ? "0" : tbxGetClrtm.Text) > 0)
                this.ddlColorCode.Items.FindByValue("02").Selected = true;
            else if (int.Parse(this.tbxMenotm.Text == "" ? "0" : tbxMenotm.Text) > 0)
                this.ddlColorCode.Items.FindByValue("03").Selected = true;

            // 廣告篇幅
            this.ddlPageSizeCode.ClearSelection();
            this.ddlPageSizeCode.Items.FindByValue("01").Selected = true;
        }

        // 載入 合約書相關資料
        private void LoadContData()
        {
            // 抓出 合約書相關資料
            string contno = "";
            if (Context.Request.QueryString["contno"].ToString().Trim() != "")
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
                this.tbxContNo.Text = contno;

                // 塞入相關合約書資料
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds2 = myPub.Selectc2_cont();
                DataView dv2 = ds2.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr2 = "1=1";
                rowfilterstr2 = rowfilterstr2 + " AND cont_contno='" + contno + "'";
                dv2.RowFilter = rowfilterstr2;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
                //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

                // 若搜尋結果為 "找到" 的處理
                if (dv2.Count > 0)
                {
                    // 顯示 廠商統編
                    string strMfrIName = "", strMfrNo = "", strCustNo = "", strCustName = "";
                    this.lblContNo.Text = "合約編號／廠商(簡)／客戶：";
                    if (dv2[0]["mfr_inm"].ToString().Trim() != "")
                    {
                        strMfrIName = dv2[0]["mfr_inm"].ToString().Trim();
                    }
                    else
                    {
                        strMfrIName = strMfrIName;
                    }
                    if (dv2[0]["cont_mfrno"].ToString().Trim() != "")
                    {
                        strMfrNo = dv2[0]["cont_mfrno"].ToString().Trim();
                        this.hiddenMfrNo.Value = strMfrNo;
                    }
                    else
                    {
                        strMfrNo = strMfrNo;
                        this.hiddenMfrNo.Value = strMfrNo;
                    }
                    if (strMfrIName != "" && strMfrIName != "")
                    {
                        if (strMfrIName.Length >= 6)
                        {
                            strMfrIName = strMfrIName.Substring(0, 6) + "...";
                        }
                        else
                        {
                            strMfrIName = strMfrIName;
                        }
                        this.tbxMfrNo.Text = strMfrIName + " (" + strMfrNo + ")";
                    }
                    else
                    {
                        this.tbxMfrNo.Text = "(查無資料)";
                    }
                    strCustNo = dv2[0]["cont_custno"].ToString().Trim();
                    this.hiddenCustNo.Value = strCustNo;
                    strCustName = dv2[0]["cust_nm"].ToString().Trim();
                    this.tbxCustNo.Text = strCustName + " (" + strCustNo + ")";
                    //Response.Write("strMfrIName= " + strMfrIName + "<br>");
                    //Response.Write("strMfrNo= " + strMfrNo + "<br>");
                    //Response.Write("strCustNo= " + strCustNo + "<br>");
                    //Response.Write("strCustName= " + strCustName + "<br>");

                    // 顯示 刊登年月之合理範圍
                    string strSDate = "", strEDate = "";
                    strSDate = dv2[0]["cont_sdate"].ToString().Trim();
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
                            {
                                strSDate = strSDate;

                                // 以 Javascript 的 window.close() 來告知訊息
                                LiteralControl litAlert1 = new LiteralControl();
                                litAlert1.Text = "<script language=javascript>alert(\"注意：合約起日不符合規則 'yyyy/mm'.\");</script>";
                                Page.Controls.Add(litAlert1);
                            }
                        }
                    }
                    else
                    {
                        strSDate = strSDate;
                    }
                    tbxStartdate.Text = strSDate;
                    strEDate = dv2[0]["cont_edate"].ToString().Trim();
                    //strEDate = strEDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
                    if (strEDate != "")
                    {
                        if (strEDate.Length >= 6)
                            strEDate = strEDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
                        else
                        {
                            // 分離 \ 符號以取得數字
                            if (strEDate.IndexOf("\\") != -1)
                            {
                                //strEDate = strEDate.Split('/', 2);
                            }
                            else
                            {
                                strEDate = strEDate;

                                // 以 Javascript 的 window.close() 來告知訊息
                                LiteralControl litAlert1 = new LiteralControl();
                                litAlert1.Text = "<script language=javascript>alert(\"注意：合約迄日不符合規則 'yyyy/mm'.\");</script>";
                                Page.Controls.Add(litAlert1);
                            }
                        }
                    }
                    else
                    {
                        strEDate = strEDate;
                    }
                    this.tbxEndDate.Text = strEDate;

                    // 指定 預設之刊登年月 = 合約起日之年月
                    string yyyymm = dv2[0]["cont_sdate"].ToString().Trim();


                    // 顯示合約書細節之相關資料
                    string tottm = "";
                    string totjtm = "";
                    string chgjtm = "";
                    string freetm = "";
                    string totamt = "";
                    string adamt = "";
                    string Clrtm = "";
                    string GetClrtm = "";
                    string Menotm = "";
                    string ContMessage = " ";
                    ContMessage = ContMessage + "合約參考資料－";
                    this.lblContMessage.Text = ContMessage;

                    // 總刊登次數
                    if (dv2[0]["cont_tottm"].ToString().Trim() != "")
                    {
                        tottm = dv2[0]["cont_tottm"].ToString().Trim();
                    }
                    else
                        tottm = "0";
                    this.lblTottm.Text = "總刊登次數: ";
                    this.tbxTottm.Text = tottm;

                    // 總製稿次數
                    if (dv2[0]["cont_totjtm"].ToString().Trim() != "")
                    {
                        totjtm = dv2[0]["cont_totjtm"].ToString().Trim();
                    }
                    else
                        totjtm = "0";
                    this.lblTotjtm.Text = "總製稿次數: ";
                    this.tbxTotjtm.Text = totjtm;

                    // 換稿次數
                    if (dv2[0]["cont_chgjtm"].ToString().Trim() != "")
                    {
                        chgjtm = dv2[0]["cont_chgjtm"].ToString().Trim();
                    }
                    else
                        chgjtm = "0";
                    this.lblChgjtm.Text = "換稿次數: ";
                    this.tbxChgjtm.Text = chgjtm;

                    // 贈送次數
                    if (dv2[0]["cont_freetm"].ToString().Trim() != "")
                    {
                        freetm = dv2[0]["cont_freetm"].ToString().Trim();
                    }
                    else
                        freetm = "0";
                    this.lblFreetm.Text = "贈送次數: ";
                    this.tbxFreetm.Text = freetm;

                    // 合約總金額
                    if (dv2[0]["cont_totamt"].ToString().Trim() != "")
                    {
                        totamt = dv2[0]["cont_totamt"].ToString().Trim();
                    }
                    else
                        totamt = "0";
                    this.lblTotamt.Text = "合約總金額: $ ";
                    this.tbxTotamt.Text = totamt;

                    // 合約書 廣告費單價
                    if (dv2[0]["cont_adamt"].ToString().Trim() != "")
                    {
                        adamt = dv2[0]["cont_adamt"].ToString().Trim();
                    }
                    else
                    {
                        adamt = "0";
                    }
                    this.lblContAdamt.Text = "廣告費單價: $";
                    this.tbxContAdamt.Text = adamt;
                    // 指定預設之 廣告金額 & 換稿金額
                    this.tbxAdAmt.Text = adamt;
                    this.tbxChgAmt.Text = "0";

                    // 合約書 剩餘彩色次數
                    if (dv2[0]["cont_clrtm"].ToString().Trim() != "")
                    {
                        Clrtm = dv2[0]["cont_clrtm"].ToString().Trim();
                    }
                    else
                    {
                        Clrtm = "0";
                    }
                    this.lblClrtm.Text = "彩色次數: ";
                    this.tbxClrtm.Text = Clrtm;

                    // 合約書 剩餘套色次數
                    if (dv2[0]["cont_getclrtm"].ToString().Trim() != "")
                    {
                        GetClrtm = dv2[0]["cont_getclrtm"].ToString().Trim();
                    }
                    else
                    {
                        GetClrtm = "0";
                    }
                    this.lblGetClrtm.Text = "套色次數: ";
                    this.tbxGetClrtm.Text = GetClrtm;

                    // 合約書 剩餘黑白次數
                    if (dv2[0]["cont_menotm"].ToString().Trim() != "")
                    {
                        Menotm = dv2[0]["cont_menotm"].ToString().Trim();
                    }
                    else
                    {
                        Menotm = "0";
                    }
                    this.lblMenotm.Text = "黑白次數: ";
                    this.tbxMenotm.Text = Menotm;


                    // 預設 發票廠商收件人序號及其姓名
                    GetInitIMData();



                    // 載入 書籍類別, 計劃代號, 成本中心相關資料
                    LoadBkcdProjCost();
                }
            }
            else
            {
                // do nothing 不載入
                this.lblAddMessage.Text = "無合約書編號資料, 無法載入落版資料; 請回上一步驟重新搜尋!<br>";
            }

        }

        // 預設 發票廠商收件人序號及其姓名
        private void GetInitIMData()
        {
            // 抓出 合約書相關資料
            string contno = "";
            if (Context.Request.QueryString["contno"].ToString().Trim() != "")
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
            }


            // 顯示下拉式選單 發票廠商收件人的 DB 值
            DataSet ds9 = myPub.Selectinvmfr(contno);
            ddlIMSeq.DataSource = ds9;
            ddlIMSeq.DataTextField = "im_nm";
            ddlIMSeq.DataValueField = "im_imseq";
            ddlIMSeq.DataBind();


            // 顯示總筆數
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds20 = myPub.Selectinvmfr2();
            DataView dv20 = ds20.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr20 = "1=1";
            rowfilterstr20 = rowfilterstr20 + " AND im_contno='" + contno + "'";
            dv20.RowFilter = rowfilterstr20;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv20.Count= "+ dv20.Count + "<BR>");
            //Response.Write("dv20.RowFilter= " + dv20.RowFilter + "<BR>");

            string strfgItri = "";
            // 若搜尋結果為 "找不到" 的處理
            int IMCount = 0;
            if (dv20.Count > 0)
            {
                IMCount = Convert.ToInt32(dv20[0]["CountNo"].ToString().Trim());
                lblIMCount.Text = "(有 " + IMCount + " 人)";

                // 抓出第一筆下拉式選單之 im_fgitri, 當做串至 book+proj 時抓計劃代號及成本中心的判斷值
                DataView dv9 = ds9.Tables[0].DefaultView;
                strfgItri = dv9[0]["im_fgitri"].ToString();
            }
            else
            {
                this.lblIMCount.Text = "<font color='Red'>(查無資料!)</font>";

                // 抓出第一筆下拉式選單之 im_fgitri, 當做串至 book+proj 時抓計劃代號及成本中心的判斷值
                strfgItri = " ";
            }
            //Response.Write("strfgItri= " + strfgItri + "<br>");
            this.hiddenIMfgitri.Value = strfgItri;
        }

        // 載入 書籍類別, 計劃代號, 成本中心相關資料
        private void LoadBkcdProjCost()
        {
            // 檢查是否有書籍代碼, 顯示其相關資料, 並帶出 計劃代號及成本中心 DB 值
            if (Context.Request.QueryString["bkcd"].ToString().Trim() != "")
            {
                // 顯示 合約書籍的相關資料: 書籍名稱及代碼
                string strbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
                this.tbxBkcd.Text = strbkcd;
                string strIMfgitri = this.hiddenIMfgitri.Value.ToString().Trim();
                //Response.Write("strbkcd= " + strbkcd + "<br>");
                //Response.Write("strIMfgitri= " + strIMfgitri + "<br>");


                // 先變更下拉式選單 舊稿書類/改稿書類, 再載入 書籍類別, 計劃代號, 成本中心相關資料
                // 變更下拉式選單 舊稿書類
                if (this.pnlOrig.Visible == true)
                {
                    this.ddlOrigBookCode.ClearSelection();
                    this.ddlOrigBookCode.Items.FindByValue(strbkcd).Selected = true;
                    //Response.Write("ddlOrigBookCode= " + dv7[0]["bk_bkcd"].ToString() + "<br>");
                }

                // 變更下拉式選單 改稿書類
                if (this.pnlChg.Visible == true)
                {
                    this.ddlChgBookCode.ClearSelection();
                    this.ddlChgBookCode.Items.FindByValue(strbkcd).Selected = true;
                    //Response.Write("ddlChgBookCode= " + dv7[0]["bk_bkcd"].ToString() + "<br>");
                }


                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds7 = myPub.SelectBook();
                DataView dv7 = ds7.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr7 = "1=1";
                rowfilterstr7 = rowfilterstr7 + " AND proj_bkcd='" + strbkcd + "'";
                rowfilterstr7 = rowfilterstr7 + " AND proj_fgitri='" + strIMfgitri + "'";
                dv7.RowFilter = rowfilterstr7;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
                //Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");

                // 若搜尋結果為 "找到" 的處理: 載入 書籍類別, 計劃代號, 成本中心相關資料
                if (dv7.Count > 0)
                {
                    //this.tbxBkcd.Text = "合約書類：" + this.tbxBkcd.Text;
                    this.tbxBookName.Text = dv7[0]["bk_nm"].ToString().Trim();
                    this.lblProjCostMessage.Text = "計劃代號／成本中心：";
                    this.lblProjNo.Text = dv7[0]["proj_projno"].ToString().Trim();
                    this.lblCostCtr.Text = dv7[0]["proj_costctr"].ToString().Trim();

                    // 若該發廠收件人為特殊之'發票類型', 則顯示其文字 -- 以下為 1/29/2003 added
                    string strfgitri = dv7[0]["proj_fgitri"].ToString().Trim();
                    if (strfgitri != "")
                        lblfgItrI.Text = " (" + dv7[0]["fgitri_name"].ToString().Trim() + ")";
                    else
                        lblfgItrI.Text = "";
                }
            }
            else
            {
                this.lblAddMessage.Text = "該合約並未指定 書籍類別, 故此處無法帶出計劃代號及成本中心資料!<br>請回維護合約書修正!";
            }
        }

        protected void imbIMRefresh_Click(object sender, ImageClickEventArgs e)
        {
            GetInitIMData();         
        }




        // 清除畫面, 恢復至畫面初始
        private void ClearForm()
        {
            // 回復 - 不允許修改 PK, 隱藏 PubSeq & YYYYMM & PNo
            this.lblPubSeq.Enabled = true;
            this.tbxYYYYMM.Disabled = false;
            this.tbxBkpPno.Disabled = false;


            // 清除畫面上的資料
            InitialData();
            //NewData();
            this.tbxYYYYMM.Value = "";
            this.tbxBkpPno.Value = "";
            this.tbxPageNo.Text = "";
            this.tbxRemark.Text = "";
            this.tbxOrigjno.Text = "";
            this.tbxOrigbkno.Text = "";

        }

        protected void DataGrid1_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string strSyscd = "C2";
                string strContNo = this.tbxContNo.Text.ToString().Trim();
                string strYYYYMM = e.Item.Cells[3].Text.ToString().Trim();
                string strPubSeq = e.Item.Cells[2].Text.ToString();
                string strIMSeq = e.Item.Cells[11].Text.ToString().Trim();
                string strinved2 = e.Item.Cells[21].Text.ToString().Trim();
                //Response.Write("strSyscd= " + strSyscd + "<br>");
                //Response.Write("strContNo= " + strContNo + "<br>");
                //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
                //Response.Write("strPubSeq= " + strPubSeq + "<br>");
                //Response.Write("strIMSeq= " + strIMSeq + "<br>");
                //Response.Write("strinved2= " + strinved2 + "<br>");

                // 若落版資料已開發票(='v' or '1'), 則不予刪除, 但給予警告訊息; 除非將發票退回(改寫回 ' '), 才可刪除
                if (strinved2 == "v" || strinved2 == "1")
                {
                    // 以 Javascript 的 window.alert()  來告知訊息
                    LiteralControl litAlertInv2 = new LiteralControl();
                    litAlertInv2.Text = "<script language=javascript>alert(\"不可刪除此筆落版檔, 因它已開立發票; 除非將此發票退回!\");</script>";
                    Page.Controls.Add(litAlertInv2);
                }
                // 可進行刪除動作
                else
                {
                    // 若落版資料 已結案且美編註記為1, 不允許刪除
                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds17 = myPub.Selectc2_cont2();
                    DataView dv17 = ds17.Tables[0].DefaultView;

                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                    string rowfilterstr17 = "1=1";
                    rowfilterstr17 = rowfilterstr17 + " AND pub_syscd='" + strSyscd + "'";
                    rowfilterstr17 = rowfilterstr17 + " AND pub_contno='" + strContNo + "'";
                    rowfilterstr17 = rowfilterstr17 + " AND pub_yyyymm='" + strYYYYMM + "'";
                    rowfilterstr17 = rowfilterstr17 + " AND pub_pubseq='" + strPubSeq + "'";
                    //rowfilterstr17 = rowfilterstr17 + " AND pub_imseq='" + strIMSeq + "'";
                    rowfilterstr17 = rowfilterstr17 + " OR cont_fgclosed='1'";
                    rowfilterstr17 = rowfilterstr17 + " OR pub_fgupdated='1'";
                    rowfilterstr17 = rowfilterstr17 + " OR pub_fgact='1'";
                    dv17.RowFilter = rowfilterstr17;

                    // 檢查並輸出 最後 Row Filter 的結果
                    //Response.Write("dv17.Count= "+ dv17.Count + "<BR>");
                    //Response.Write("dv17.RowFilter= " + dv17.RowFilter + "<BR>");

                    // 若找不到此筆落版, 告知無法刪除
                    if (dv17.Count < 0)
                    {
                        // do nothing
                        // 以 Javascript 的 window.alert()  來告知訊息
                        LiteralControl litAlert1 = new LiteralControl();
                        litAlert1.Text = "<script language=javascript>alert(\"不可刪除此筆落版檔, 因它可能已結案\n或已做排版動作(或美編已做樣後修改)!\");</script>";
                        Page.Controls.Add(litAlert1);
                    }
                    // 若找到(表示該合約尚未結案或尚未做排版動作或美編尚未做樣後修改動作), 則刪除該筆落版
                    else
                    {
                        // 業務權限為 A or B 者, 才可刪除 落版資料
                        string srspnAType = "";
                        //				if(Session["atype"].ToString()=="a" || Session["atype"].ToString()=="b")
                        //				{
                        //				}
                        //				else
                        //				{
                        //					LiteralControl litAlert = new LiteralControl();
                        //					litAlert.Text = "<script language=javascript>alert(\"您沒有權限進行刪除, 請洽正式員工處理!\");</script>";
                        //					Page.Controls.Add(litAlert);
                        //				}



                        // 步驟一: 刪除該筆落版資料
                        // 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 刪除
                        myPub.Deletec2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq);


                        // 步驟二: 抓出該落版資料的最大落版序號 MaxPubSeq; 若有(>1), 好方便抓出之後筆數之逐行資料, 再做更新處理
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds22 = myPub.Selectc2_pub5(strContNo, strYYYYMM);
                        // 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
                        DataView dv22 = ds22.Tables[0].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                        string rowfilterstr22 = "1=1";
                        dv22.RowFilter = rowfilterstr22;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv22.Count= "+ dv22.Count + "<BR>");
                        //Response.Write("dv22.RowFilter= " + dv22.RowFilter + "<BR>");

                        // 若搜尋結果為 "找到" 的處理
                        string MaxPubSeq = "01";
                        int intMaxPubSeq = Convert.ToInt16(MaxPubSeq);
                        if (dv22.Count > 0)
                        {
                            MaxPubSeq = dv22[0]["MaxPubSeq"].ToString();
                            //Response.Write("MaxPubSeq= " + MaxPubSeq + "<br>");
                            intMaxPubSeq = Convert.ToInt16(MaxPubSeq);
                            //Response.Write("intMaxPubSeq= " + intMaxPubSeq + "<br>");

                            // 步驟三: 更新之後的序號之處理
                            int intCurrentPubSeq = Convert.ToInt16(strPubSeq);
                            if (strPubSeq == MaxPubSeq)
                            {
                                //Response.Write("do nothing...直接執行刪除落版資料即可<br>");
                            }
                            else
                            {
                                //Response.Write("處理更新事宜<br>");


                                // 抓出 按下刪除之下一序號, 做為 for loop 起始值
                                int intNextPubSeq = intCurrentPubSeq + 1;
                                //Response.Write("intNextPubSeq= " + intNextPubSeq + "<br>");

                                // 抓出逐行落版資料, 做更新其落版序號之動作
                                for (int i = intNextPubSeq; i <= intMaxPubSeq; i++)
                                {
                                    string stri = Convert.ToString(i);
                                    if (stri.Length < 2)
                                        stri = "0" + stri;
                                    //Response.Write("stri= " + stri + "<br>");

                                    // 抓出逐行落版資料之 PK
                                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                                    DataSet ds1 = myPub.Selectc2_pub();
                                    // 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
                                    DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

                                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                                    // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                                    string rowfilterstr1 = "1=1";
                                    rowfilterstr1 = rowfilterstr1 + " AND  pub_syscd='C2' ";
                                    rowfilterstr1 = rowfilterstr1 + " AND  pub_contno='" + strContNo + "'";
                                    rowfilterstr1 = rowfilterstr1 + " AND  pub_yyyymm='" + strYYYYMM + "'";
                                    rowfilterstr1 = rowfilterstr1 + " AND  pub_pubseq='" + stri + "'";
                                    dv1.RowFilter = rowfilterstr1;

                                    // 檢查並輸出 最後 Row Filter 的結果
                                    //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
                                    //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

                                    if (dv1.Count > 0)
                                    {
                                        string iSyscd = "C2";
                                        string iContNo = dv1[0]["pub_contno"].ToString();
                                        string iYYYYMM = dv1[0]["pub_yyyymm"].ToString();
                                        //Response.Write("iSyscd= " + iSyscd + ", ");
                                        //Response.Write("iContNo= " + iContNo + ", ");
                                        //Response.Write("iYYYYMM= " + iYYYYMM + ", ");
                                        //Response.Write("iPubSeq= " + stri + "<BR><BR>");

                                        int intNewPubSeq = i - 1;
                                        string strNewPubSeq = Convert.ToString(intNewPubSeq);
                                        if (strNewPubSeq.Length < 2)
                                            strNewPubSeq = "0" + strNewPubSeq;

                                        //// 執行更新動作
                                        //string strConn9 = "server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
                                        ////string strConn9 = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
                                        //SqlConnection myConn9 = new SqlConnection(strConn9);

                                        //SqlDataAdapter cmd9 = new SqlDataAdapter("UPDATE c2_pub SET pub_pubseq = '" + strNewPubSeq + "' WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)", myConn9);
                                        ////Response.Write("cmd9= UPDATE c2_pub SET pub_pubseq = '" + strNewPubSeq + "' WHERE (pub_syscd = " + iSyscd + ") AND (pub_contno = " + iContNo + ") AND (pub_yyyymm = " + iYYYYMM+ ") AND (pub_pubseq = " + stri + ")<br><br>");

                                        ////cmd9.SelectCommand.Parameters.Add("@pub_pubid",SqlDbType.Int,4).Value = id;
                                        //cmd9.SelectCommand.Parameters.Add("@syscd", SqlDbType.Char, 2).Value = iSyscd;
                                        //cmd9.SelectCommand.Parameters.Add("@contno", SqlDbType.Char, 6).Value = iContNo;
                                        //cmd9.SelectCommand.Parameters.Add("@yyyymm", SqlDbType.Char, 6).Value = iYYYYMM;
                                        //cmd9.SelectCommand.Parameters.Add("@pubseq", SqlDbType.Char, 2).Value = stri;

                                        //DataSet ds9 = new DataSet();
                                        //cmd9.Fill(ds9, "c2_pub");
                                    }
                                    else
                                    {
                                        // Response.Write("do nothing!<br>");
                                    }

                                    // 結束 for loop
                                }
                                // 結束 步驟三 else
                            }
                        }
                        else
                        {
                            MaxPubSeq = "01";
                            intMaxPubSeq = 1;
                        }

                        // Refresh Page
                        DataGrid1.CurrentPageIndex = 0;
                        BindGrid1();



                        // 回寫 合約相關資料
                        // 先抓出 合約書相關資料, 再做計算
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds11 = myPub.Selectc2_cont3();
                        DataView dv11 = ds11.Tables[0].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                        string rowfilterstr11 = "1=1";
                        rowfilterstr11 = rowfilterstr11 + " AND cont_syscd='" + strSyscd + "'";
                        rowfilterstr11 = rowfilterstr11 + " AND cont_contno='" + strContNo + "'";
                        dv11.RowFilter = rowfilterstr11;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv11.Count= "+ dv11.Count + "<BR>");
                        //Response.Write("dv11.RowFilter= " + dv11.RowFilter + "<BR>");
                        int ContTottm = 0;
                        int ContTotClrtm = 0;
                        int ContTotGetClrtm = 0;
                        int ContTotMenotm = 0;
                        int ContTotjtm = 0;
                        int ContNjtpcnt = 0;
                        if (dv11.Count > 0)
                        {
                            // 計算 剩餘刊登次數 - 先抓出 總刊登次數
                            ContTottm = Convert.ToInt32(dv11[0]["cont_tottm"].ToString().Trim());

                            // 計算 剩餘彩色/套色/黑白次數 - 先抓出 (總)彩色/套色/黑白次數
                            ContTotClrtm = Convert.ToInt32(dv11[0]["cont_clrtm"].ToString().Trim());
                            ContTotGetClrtm = Convert.ToInt32(dv11[0]["cont_getclrtm"].ToString().Trim());
                            ContTotMenotm = Convert.ToInt32(dv11[0]["cont_menotm"].ToString().Trim());

                            // 計算 剩餘製稿次數 - 先抓出 總製稿次數
                            ContTotjtm = Convert.ToInt32(dv11[0]["cont_totjtm"].ToString().Trim());

                            // 計算 新稿份數
                            ContNjtpcnt = Convert.ToInt32(dv11[0]["cont_njtpcnt"].ToString().Trim());
                        }
                        else
                        {
                            ContTottm = ContTottm;
                            ContTotClrtm = ContTotClrtm;
                            ContTotGetClrtm = ContTotGetClrtm;
                            ContTotMenotm = ContTotMenotm;
                            ContTotjtm = ContTotjtm;
                            ContNjtpcnt = ContNjtpcnt;
                        }


                        // 重新計算 新結果
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds13 = myPub.Selectc2_pub7();
                        DataView dv13 = ds13.Tables[0].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                        string rowfilterstr13 = "1=1";
                        rowfilterstr13 = rowfilterstr13 + " AND pub_syscd='" + strSyscd + "'";
                        rowfilterstr13 = rowfilterstr13 + " AND pub_contno='" + strContNo + "'";
                        dv13.RowFilter = rowfilterstr13;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv13.Count= "+ dv13.Count + "<BR>");
                        //Response.Write("dv13.RowFilter= " + dv13.RowFilter + "<BR>");

                        float PubAdAmt = 0;
                        float PubChgAmt = 0;
                        float ContPubAmt = 0;
                        float ContChgAmt = 0;
                        if (dv13.Count > 0)
                        {
                            // 落版總廣告金額 & 落版總換稿金額
                            PubAdAmt = Convert.ToSingle(dv13[0]["pub_adamt"].ToString().Trim());
                            ContPubAmt = PubAdAmt;
                            //Response.Write("PubAdAmt= " + PubAdAmt + "<br>");
                            //Response.Write("ContPubAmt= " + ContPubAmt + "<br>");
                            PubChgAmt = Convert.ToSingle(dv13[0]["pub_chgamt"].ToString().Trim());
                            ContChgAmt = PubChgAmt;
                            //Response.Write("PubChgAmt= " + PubChgAmt + "<br>");
                            //Response.Write("ContChgAmt= " + ContChgAmt + "<br>");
                        }
                        else
                        {
                            ContPubAmt = ContPubAmt;
                            ContChgAmt = ContChgAmt;
                        }


                        int PubClrCount = 0;
                        int ContPubClrtm = 0;
                        int ContPubGetClrtm = 0;
                        int ContPubMenotm = 0;
                        int ContRestClrtm = 0;
                        int ContRestGetClrtm = 0;
                        int ContRestMenotm = 0;
                        // 剩餘彩色/套色/黑白次數
                        string clrcd = "";
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds14 = myPub.Selectc2_pub6();
                        DataView dv14 = ds14.Tables[0].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                        string rowfilterstr14 = "1=1";
                        rowfilterstr14 = rowfilterstr14 + " AND pub_syscd='" + strSyscd + "'";
                        rowfilterstr14 = rowfilterstr14 + " AND pub_contno='" + strContNo + "'";
                        dv14.RowFilter = rowfilterstr14;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv14.Count= "+ dv14.Count + "<BR>");
                        //Response.Write("dv14.RowFilter= " + dv14.RowFilter + "<BR>");

                        if (dv14.Count > 0)
                        {
                            for (int i = 0; i < dv14.Count; i++)
                            {
                                clrcd = dv14[i]["pub_clrcd"].ToString().Trim();
                                PubClrCount = Convert.ToInt32(dv14[i]["CountNo"].ToString().Trim());
                                //Response.Write("clrcd= " + clrcd + "<br>");
                                //Response.Write("PubClrCount= " + PubClrCount + "<br>");

                                // 若為其他, 則依情況減一(當有資料時)
                                // 依不同廣告色彩, 抓出目前已刊登的廣告色彩次數 PubClrCount, 以求得剩餘彩色/套色/黑白次數
                                // 註: 以下 else 要暫時 disable, 才能抓到累積的次數; 否則是各行的正確結果
                                if (clrcd == "01")
                                {
                                    ContPubClrtm = PubClrCount;
                                    ContRestClrtm = ContTotClrtm - ContPubClrtm;
                                }
                                //else
                                //ContRestClrtm = 0;
                                if (clrcd == "02")
                                {
                                    ContPubGetClrtm = PubClrCount;
                                    ContRestGetClrtm = ContTotGetClrtm - ContPubGetClrtm;
                                }
                                //else
                                //ContRestGetClrtm = 0;
                                if (clrcd == "03")
                                {
                                    ContPubMenotm = PubClrCount;
                                    ContRestMenotm = ContTotMenotm - ContPubMenotm;
                                }
                                //else
                                //ContRestMenotm = 0;
                                //Response.Write("PubClrCount= " + PubClrCount + "<br>");
                                //Response.Write("ContPubClrtm= " + ContPubClrtm + "<br>");
                                //Response.Write("ContPubGetClrtm= " + ContPubGetClrtm + "<br>");
                                //Response.Write("ContPubMenotm= " + ContPubMenotm + "<br>");
                                //Response.Write("ContRestClrtm= " + ContRestClrtm + "<br>");
                                //Response.Write("ContRestGetClrtm= " + ContRestGetClrtm + "<br>");
                                //Response.Write("ContRestMenotm= " + ContRestMenotm + "<br>");
                                // 結束 for loop
                            }
                        }
                        else
                        {
                            PubClrCount = 0;
                            ContRestClrtm = ContTotClrtm;
                            ContRestGetClrtm = ContTotGetClrtm;
                            ContRestMenotm = ContTotMenotm;
                        }


                        int PubDraftCount = 0;
                        int ContMadejtm = 0;
                        int ContRestjtm = 0;
                        // 已製稿次數 & 剩餘製稿次數
                        string drafttp = "";
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds15 = myPub.Selectc2_pub8();
                        DataView dv15 = ds15.Tables[0].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                        string rowfilterstr15 = "1=1";
                        rowfilterstr15 = rowfilterstr15 + " AND pub_syscd='" + strSyscd + "'";
                        rowfilterstr15 = rowfilterstr15 + " AND pub_contno='" + strContNo + "'";
                        dv15.RowFilter = rowfilterstr15;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv15.Count= "+ dv15.Count + "<BR>");
                        //Response.Write("dv15.RowFilter= " + dv15.RowFilter + "<BR>");

                        if (dv15.Count > 0)
                        {
                            for (int j = 0; j < dv15.Count; j++)
                            {
                                drafttp = dv15[j]["pub_drafttp"].ToString().Trim();
                                PubDraftCount = Convert.ToInt32(dv15[j]["CountNo"].ToString().Trim());
                                //Response.Write("drafttp= " + drafttp + "<br>");
                                //Response.Write("PubDraftCount= " + PubDraftCount + "<br>");

                                // 若為舊稿, 不予處理
                                if (drafttp == "1")
                                {
                                    ContMadejtm = ContMadejtm;
                                    ContRestjtm = ContTotjtm - ContMadejtm;
                                }
                                // 若為 新稿/改稿, 則已製稿次數-1, 剩餘製稿次數+1
                                else
                                {
                                    ContMadejtm = ContMadejtm + PubDraftCount;
                                    ContRestjtm = ContTotjtm - ContMadejtm;
                                }
                            }
                            //Response.Write("ContMadejtm= " + ContMadejtm + "<br>");
                            //Response.Write("ContRestjtm= " + ContRestjtm + "<br>");
                        }
                        else
                        {
                            ContMadejtm = ContMadejtm;
                            ContRestjtm = ContTotjtm - ContMadejtm;
                        }


                        int PubtmCount = 0;
                        int ContPubtm = 0;
                        int ContResttm = 0;
                        // 已刊登次數 & 剩餘刊登次數
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds18 = myPub.Selectc2_pub9();
                        DataView dv18 = ds18.Tables[0].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                        string rowfilterstr18 = "1=1";
                        rowfilterstr18 = rowfilterstr18 + " AND pub_contno='" + strContNo + "'";
                        dv18.RowFilter = rowfilterstr18;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv18.Count= "+ dv18.Count + "<BR>");
                        //Response.Write("dv18.RowFilter= " + dv18.RowFilter + "<BR>");

                        if (dv18.Count > 0)
                        {
                            PubtmCount = Convert.ToInt16(dv18[0]["CountNo"].ToString().Trim());
                            ContPubtm = PubtmCount;
                            ContResttm = ContTottm - PubtmCount;
                        }
                        else
                        {
                            PubtmCount = 0;
                            ContPubtm = 0;
                            ContResttm = ContTottm - ContPubtm;
                        }
                        //Response.Write("PubtmCount= " + PubtmCount + "<br>");
                        //Response.Write("ContPubtm= " + ContPubtm + "<br>");
                        //Response.Write("ContTottm= " + ContTottm + "<br>");
                        //Response.Write("ContResttm= " + ContResttm + "<br>");


                        // 新稿份數
                        //Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds19 = myPub.Selectc2_pub10();
                        DataView dv19 = ds19.Tables[0].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                        string rowfilterstr19 = "1=1";
                        rowfilterstr19 = rowfilterstr19 + " AND pub_contno='" + strContNo + "'";
                        dv19.RowFilter = rowfilterstr19;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv19.Count= "+ dv19.Count + "<BR>");
                        //Response.Write("dv19.RowFilter= " + dv19.RowFilter + "<BR>");

                        if (dv19.Count > 0)
                        {
                            ContNjtpcnt = Convert.ToInt16(dv19[0]["CountNo"].ToString().Trim());
                        }
                        else
                        {
                            ContNjtpcnt = ContNjtpcnt;
                        }
                        ContNjtpcnt = ContNjtpcnt;
                        //Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");


                        string Contfgpubed = "1";
                        // 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
                        //Response.Write(this.sqlCommand2.CommandText);

                        myPub.Updatec2_cont2(ContPubAmt, ContChgAmt, Contfgpubed, ContRestClrtm, ContRestMenotm, ContRestGetClrtm,
                            ContMadejtm, ContRestjtm, ContPubtm, ContResttm, ContNjtpcnt, strSyscd, strContNo);


                        // Refresh DataGrid1
                        // 若刪除所有資料時, 則不應再顯示 DataGrid1()
                        //Response.Write("DataGrid1.Items.Count= " + DataGrid1.Items.Count + "<br>");
                        DataGrid1.CurrentPageIndex = 0;
                        BindGrid1();


                        // 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
                        this.btnSave.Visible = true;
                        this.btnModify.Visible = false;
                        this.btnLoadData.Visible = true;
                        this.btnGoChkList.Visible = true;


                        // 給預設資料 - 新增Form
                        if (DataGrid1.Items.Count == 1)
                        {
                            InitialData();
                            //NewData();
                        }


                        // 清除畫面, 恢復至畫面初始
                        ClearForm();

                        // 結束 else -若找到(表示該合約尚未結案或尚未做排版動作或美編尚未做樣後修改動作), 則刪除該筆落版
                    }

                    // 結束 else (可進行刪除動作)
                }

                // 結束 if(e.CommandName == "Delete")
            }
        }

        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // 不允許修改 PK, 隱藏 PubSeq & YYYYMM & PNo
                // 注意: 若使用者輸錯 PK 資料, 要求刪除錯誤資料並重新輸入新的正確資料!
                this.lblPubSeq.Enabled = false;
                this.tbxYYYYMM.Disabled = true;
                this.tbxBkpPno.Disabled = true;


                // 抓出 PK 值, 將相關資料載入 新增Form 裡
                string strSyscd = "C2";
                string strContNo = this.tbxContNo.Text.ToString().Trim();
                string strYYYYMM = e.Item.Cells[3].Text.ToString().Trim();
                string strPubSeq = e.Item.Cells[2].Text.ToString();
                string strIMName = e.Item.Cells[12].Text.ToString().Trim();
                string strinved = e.Item.Cells[19].Text.ToString().Trim();
                //Response.Write("strSyscd= " + strSyscd + ", ");
                //Response.Write("strContNo= " + strContNo + ", ");
                //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
                //Response.Write("strPubSeq= " + strPubSeq + "<br>");
                //Response.Write("strIMName= " + strIMName + "<br>");
                //Response.Write("strinved= " + strinved + "<br>");

                // 若落版資料已開發票(='v' or '1'), 則不予修改, 但給予警告訊息; 除非將發票退回(改寫回 ' '), 才可修改
                if (strinved == "v" || strinved == "1")
                {
                    // 以 Javascript 的 window.alert()  來告知訊息
                    JavaScript.AlertMessage(this.Page, "不可修改此筆落版檔, 因它已開立發票; 除非將此發票退回");
                    return;
                    //LiteralControl litAlertInv1 = new LiteralControl();
                    //litAlertInv1.Text = "<script language=javascript>alert(\"不可修改此筆落版檔, 因它已開立發票; 除非將此發票退回!\");</script>";
                    //Page.Controls.Add(litAlertInv1);
                }
                // 可進行修改動作
                else
                {
                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds12 = myPub.Selectc2_pub11();
                    DataView dv12 = ds12.Tables[0].DefaultView;

                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                    string rowfilterstr12 = "1=1";
                    rowfilterstr12 = rowfilterstr12 + " AND pub_syscd='" + strSyscd + "'";
                    rowfilterstr12 = rowfilterstr12 + " AND pub_contno='" + strContNo + "'";
                    rowfilterstr12 = rowfilterstr12 + " AND pub_yyyymm='" + strYYYYMM + "'";
                    rowfilterstr12 = rowfilterstr12 + " AND pub_pubseq='" + strPubSeq + "'";
                    dv12.RowFilter = rowfilterstr12;

                    // 檢查並輸出 最後 Row Filter 的結果
                    //Response.Write("dv12.Count= "+ dv12.Count + "<BR>");
                    //Response.Write("dv12.RowFilter= " + dv12.RowFilter + "<BR>");

                    // 載入資料			
                    if (dv12.Count > 0)
                    {
                        // 將序號顯示在 lblORItem; 否則修改時無法抓出其序號
                        this.lblPubSeq.Visible = true;
                        this.lblPubSeq.Text = strPubSeq;

                        // 顯示其相關資料
                        this.tbxYYYYMM.Value = strYYYYMM;
                        this.tbxBkpPno.Value = dv12[0]["pub_pno"].ToString().Trim();
                        this.tbxPageNo.Text = dv12[0]["pub_pgno"].ToString().Trim();
                        this.ddlColorCode.ClearSelection();
                        this.ddlColorCode.Items.FindByValue(dv12[0]["pub_clrcd"].ToString()).Selected = true;
                        this.ddlLTypeCode.ClearSelection();
                        this.ddlLTypeCode.Items.FindByValue(dv12[0]["pub_ltpcd"].ToString()).Selected = true;
                        int ltpcd = Convert.ToInt16(dv12[0]["pub_ltpcd"].ToString().Trim());
                        this.ddlPageSizeCode.ClearSelection();
                        this.ddlPageSizeCode.Items.FindByValue(dv12[0]["pub_pgscd"].ToString()).Selected = true;
                        // 註: rblfgfixpage 使用 SelectItem.Value並不能正確顯示其 index, 且 rblfgfixpage 的 Selected="True" 要關閉
                        //Response.Write("pub_fgfixpg= " + dv12[0]["pub_fgfixpg"].ToString().Trim() + "<br>");
                        this.rblfgfixpage.ClearSelection();
                        this.rblfgfixpage.Items.FindByValue(dv12[0]["pub_fgfixpg"].ToString().Trim()).Selected = true;
                        // 檢查 發廠收件人筆數, 來判斷下拉式選單的位置
                        // 清除 下拉式選項, 再尋找其預選
                        this.ddlIMSeq.ClearSelection();
                        //Response.Write("this.ddlIMSeq.SelectedIndex= " + this.ddlIMSeq.SelectedIndex + "<br>");
                        if (this.ddlIMSeq.SelectedIndex >= 1)
                        {
                            this.ddlIMSeq.Items.FindByValue(dv12[0]["pub_imseq"].ToString()).Selected = true;
                        }
                        // 11/22/2002 debug 註：若開啟此段 else, 則客戶端偶爾會產生 ErrorMessage
                        //						else
                        //						{
                        //							this.ddlIMSeq.Items.FindByValue(dv12[0]["pub_imseq"].ToString()).Selected = true;
                        //						}
                        this.tbxAdAmt.Text = dv12[0]["pub_adamt"].ToString().Trim();
                        this.tbxChgAmt.Text = dv12[0]["pub_chgamt"].ToString().Trim();
                        this.tbxRemark.Text = dv12[0]["pub_remark"].ToString().Trim();
                        string drafttp = dv12[0]["pub_drafttp"].ToString().Trim();
                        this.ddlDraftType.ClearSelection();
                        this.ddlDraftType.Items.FindByValue(dv12[0]["pub_drafttp"].ToString().Trim()).Selected = true;
                        if (drafttp == "1")
                        {
                            this.pnlOrig.Visible = true;
                            this.pnlChg.Visible = false;
                            this.rblfgrechg.Visible = false;
                            this.pnlNjtp.Visible = false;
                            this.rblfggot.Visible = false;

                            this.ddlOrigBookCode.ClearSelection();
                            this.ddlOrigBookCode.SelectedIndex = Convert.ToInt32(dv12[0]["pub_origbkcd"].ToString()) - 1;
                            this.tbxOrigjno.Text = dv12[0]["pub_origjno"].ToString().Trim();
                            this.tbxOrigbkno.Text = dv12[0]["pub_origjbkno"].ToString().Trim();
                        }
                        else if (drafttp == "2")
                        {
                            this.pnlOrig.Visible = false;
                            this.pnlChg.Visible = false;
                            this.rblfgrechg.Visible = false;
                            this.pnlNjtp.Visible = true;
                            this.rblfggot.Visible = true;

                            this.ddlNJTypeCode.ClearSelection();
                            this.ddlNJTypeCode.Items.FindByValue(dv12[0]["pub_njtpcd"].ToString()).Selected = true;

                            this.rblfggot.ClearSelection();
                            this.rblfggot.Items.FindByValue(dv12[0]["pub_fggot"].ToString().Trim()).Selected = true;
                        }
                        else if (drafttp == "3")
                        {
                            this.pnlOrig.Visible = false;
                            this.pnlChg.Visible = true;
                            this.rblfgrechg.Visible = true;
                            this.pnlNjtp.Visible = false;
                            this.rblfggot.Visible = true;

                            this.ddlChgBookCode.ClearSelection();
                            this.ddlChgBookCode.Items.FindByValue(dv12[0]["pub_chgbkcd"].ToString()).Selected = true;
                            this.tbxChgjno.Text = dv12[0]["pub_chgjno"].ToString().Trim();
                            this.tbxChgbkno.Text = dv12[0]["pub_chgjbkno"].ToString().Trim();
                            this.rblfgrechg.ClearSelection();
                            this.rblfgrechg.Items.FindByValue(dv12[0]["pub_fgrechg"].ToString().Trim()).Selected = true;
                            this.rblfggot.ClearSelection();
                            this.rblfggot.Items.FindByValue(dv12[0]["pub_fggot"].ToString().Trim()).Selected = true;
                        }
                        // 計劃代號 & 成本中心
                        this.lblProjNo.Text = dv12[0]["pub_projno"].ToString().Trim();
                        this.lblCostCtr.Text = dv12[0]["pub_costctr"].ToString().Trim();
                        this.RdPull.ClearSelection();
                        this.RdPull.Items.FindByValue(dv12[0]["pub_pulpg"].ToString().Trim()).Selected = true;
                        //RdPull.SelectedItem
                    }

                    // 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
                    this.btnModify.Visible = true;
                    this.btnSave.Visible = false;
                    this.btnLoadData.Visible = false;
                    this.btnGoChkList.Visible = false;

                    // 結束 else (可進行修改動作)
                }

                // 結束 if(e.CommandName == "Delete")
            }
        }

        // 若下拉式選單 廣告版面變更時 (且其為特殊版面), 則判斷是否要變更其 刊登頁碼
        protected void ddlLTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
			// 抓出 廣告版面代碼值
			string ltpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
			//Response.Write("ltpcd= " + ltpcd + "<br>");
			
			// 判斷頁碼及固定頁次註記
			string strPgno = "";
			// 封面
			if(ltpcd == "01")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 封面裡頁
			else if(ltpcd == "02")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 封底
			else if(ltpcd == "03")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 封底裡頁
			else if(ltpcd == "04")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 首頁
			else if(ltpcd == "05")
			{
				strPgno = "3";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 目錄右頁 - check c2_pgno 裡的資料值, 來決定此處的頁數範圍 (資料值-2 ~ 資料值-1)
			else if(ltpcd == "06")
			{
				strPgno = "";
				this.rblfgfixpage.SelectedIndex = 0;
				
				// 先抓出 內頁的起始頁碼
				if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
				{
					// 顯示 合約書籍的相關資料: 書籍名稱及代碼
					string strbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
					// 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds16 = myPub.Selectc2_pgno();
					DataView dv16 = ds16.Tables[0].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr16 = "1=1";
					rowfilterstr16 = rowfilterstr16 + " AND pg_bkcd='" + strbkcd + "'";
					dv16.RowFilter = rowfilterstr16;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv16.Count= "+ dv16.Count + "<BR>");
					//Response.Write("dv16.RowFilter= " + dv16.RowFilter + "<BR>");
					
					int StartPageNo = 0;
					int sNewPageNo = 0;
					int eNewPageNo = 0;
					if(dv16.Count > 0)
					{
						StartPageNo = Convert.ToInt16(dv16[0]["pg_startpgno"].ToString().Trim());
						sNewPageNo = StartPageNo - 2;
						eNewPageNo = StartPageNo -1;
						//Response.Write("StartPageNo= " + StartPageNo + "<br>");
						//Response.Write("sNewPageNo= " + sNewPageNo + "<br>");
						//Response.Write("eNewPageNo= " + eNewPageNo + "<br>");
						
                        //// 以 Javascript 的 window.alert()  來告知訊息
                        //LiteralControl litAlert2 = new LiteralControl();
                        ////litAlert2.Text = "<script language=javascript>alert(\"目錄右頁的刊登頁碼範圍為 " + sNewPageNo + "~" + eNewPageNo + ", 請自行填入!\");</script>";
                        //litAlert2.Text = "<script language=javascript>alert(\"目錄右頁的刊登頁碼, 請自行填入!\");</script>";
                        //Page.Controls.Add(litAlert2);
                        JavaScript.AlertMessage(this.Page, "目錄右頁的刊登頁碼, 請自行填入!");
					}
					else
					{
                        //LiteralControl litAlert1 = new LiteralControl();
                        //litAlert1.Text = "<script language=javascript>alert(\"您沒有定義此種書籍類別的內頁起始頁碼, 請先至維護區維護!\n此處無法判斷目錄右頁的刊登頁碼範圍!!!\");</script>";
                        //Page.Controls.Add(litAlert1);
                        JavaScript.AlertMessage(this.Page, "您沒有定義此種書籍類別的內頁起始頁碼, 請先至維護區維護!\n此處無法判斷目錄右頁的刊登頁碼範圍!!!");
					}
				}
			}
			// 內頁
			else if(ltpcd == "50")
			{
				strPgno = this.tbxPageNo.Text;
				this.rblfgfixpage.SelectedIndex = 1;
			}
			this.tbxPageNo.Text = strPgno;
		
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 抓出 合約起迄日, 以判斷刊登年月是否在其範圍內, 若是, 則新增; 否則不予新增
            string strSDate = tbxStartdate.Text.Trim();
            strSDate = strSDate.Substring(0, 4) + strSDate.Substring(5, 2);
            string strEDate = this.tbxEndDate.Text.ToString().Trim();
            strEDate = strEDate.Substring(0, 4) + strEDate.Substring(5, 2);
            //Response.Write("strEDate=" + strEDate + "<br>");
            //Response.Write("strEDate=" + strEDate + "<br>");
            int intSDate = Convert.ToInt32(strSDate);
            int intEDate = Convert.ToInt32(strEDate);
            int intYYYYMM = Convert.ToInt32(this.tbxYYYYMM.Value.ToString().Trim());

            // 若在範圍內
            if (intSDate <= intYYYYMM && intYYYYMM <= intEDate)
            {
                // 抓出最新的 落版序號
                GetNewPubSeq();

                // 檢查 版面優先次序是否存在, 若存在呼叫InsertToDB(); 否則不允許新增
                CheckLPriorSeq1();

                //				this.lblAddMessage.Text = "";
                //				
                //				
                //				// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
                //				this.btnSave.Visible = true;
                //				this.btnModify.Visible = false;
                //				this.btnLoadData.Visible = true;
                //				this.btnGoChkList.Visible = true;
                //				this.lblPubSeq.Visible = false;
                //				
                //				// 資料回復初始狀態
                //				InitialData();
                //				//NewData();
                //				
                //				// Refresh DataGrid1
                //				DataGrid1.Visible = true;
                //				DataGrid1.CurrentPageIndex = 0;
                //				BindGrid1();
            }
            // 若刊登年月不在合約起迄範圍內的處理
            else
            {
                JavaScript.AlertMessage(this.Page, "刊登年月必須在合約起迄範圍內, 否則無法新增, 請修正!");
                return;
            }

            // 隱藏 序號之顯示
            this.lblPubSeq.Visible = false;
        }

        // 預設 發票廠商收件人序號 - 按下 "儲存新增" 後, 再去抓出正確的落版序號 (依不同刊登年月)
        private void GetNewPubSeq()
        {
            // 顯示 序號
            this.lblPubSeq.Visible = true;

            // 抓出 合約書相關資料
            string contno = "";
            string yyyymm = "";
            if (Context.Request.QueryString["contno"].ToString().Trim() != "")
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
                if (this.tbxYYYYMM.Value.ToString().Trim() != "")
                    yyyymm = this.tbxYYYYMM.Value;
                else
                    yyyymm = yyyymm;
                //Response.Write("contno= " + contno + "<br>");
                //Response.Write("yyyymm= " + yyyymm + "<br>");

                // 預設 落版序號 - 按下 "儲存新增" 後, 再去抓出正確的落版序號 (依不同刊登年月)
                string NewPubSeq = "01";

                // 預設 發票廠商收件人 序號 & 姓名
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds10 = myPub.Selectc2_pubSave();
                DataView dv10 = ds10.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr10 = "1=1";
                rowfilterstr10 = rowfilterstr10 + " AND pub_contno='" + contno + "'";
                rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm='" + yyyymm + "'";
                dv10.RowFilter = rowfilterstr10;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv10.Count= "+ dv10.Count + "<BR>");
                //Response.Write("dv10.RowFilter= " + dv10.RowFilter + "<BR>");

                // 若搜尋結果為 "找不到" 的處理
                if (dv10.Count > 0)
                {
                    NewPubSeq = Convert.ToString(Convert.ToInt32(dv10[0]["pub_pubseq"].ToString().Trim()) + 1);
                    if (NewPubSeq.Length < 2)
                        NewPubSeq = "0" + NewPubSeq;
                    else
                        NewPubSeq = NewPubSeq;
                }
                else
                {
                    NewPubSeq = NewPubSeq;
                }
                //Response.Write("NewPubSeq= " + NewPubSeq + "<br>");

                // 顯示 序號
                this.lblPubSeq.Text = NewPubSeq;
            }
        }


        // 抓出畫面上 廣告版面/廣告色彩/廣告篇幅, 檢查此組合是否存在於 c2_lprior
        private void CheckLPriorSeq1()
        {
            // 落版檔資料 - 抓下畫面上的值
            string strBkcd = this.tbxBkcd.Text.ToString();
            string strLtpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
            string strClrcd = this.ddlColorCode.SelectedItem.Value.ToString();
            string strPgscd = this.ddlPageSizeCode.SelectedItem.Value.ToString();
            //Response.Write("strLtpcd= " + strLtpcd + "<br>");
            //Response.Write("strClrcd= " + strClrcd + "<br>");
            //Response.Write("strPgscd= " + strPgscd + "<br>");

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds21 = myPub.Selectc2_lprior();
            DataView dv21 = ds21.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr21 = "1=1";
            rowfilterstr21 = rowfilterstr21 + " AND lp_bkcd='" + strBkcd + "'";
            rowfilterstr21 = rowfilterstr21 + " AND lp_ltpcd='" + strLtpcd + "'";
            rowfilterstr21 = rowfilterstr21 + " AND lp_clrcd='" + strClrcd + "'";
            rowfilterstr21 = rowfilterstr21 + " AND lp_pgscd='" + strPgscd + "'";
            dv21.RowFilter = rowfilterstr21;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv21.Count= "+ dv21.Count + "<BR>");
            //Response.Write("dv21.RowFilter= " + dv21.RowFilter + "<BR>");

            // 若搜尋結果為 "找到" 的處理: 允許新增/修改
            if (dv21.Count > 0)
            {
                // 判斷狀態
                if (btnSave.Visible == true)
                {
                    // 執行新增動作
                    InsertToDB();


                    this.lblAddMessage.Text = "";

                    // 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
                    this.btnSave.Visible = true;
                    this.btnModify.Visible = false;
                    this.btnLoadData.Visible = true;
                    this.btnGoChkList.Visible = true;
                    this.lblPubSeq.Visible = false;

                    // 資料回復初始狀態
                    InitialData();
                    //NewData();

                    // Refresh DataGrid1
                    DataGrid1.Visible = true;
                    DataGrid1.CurrentPageIndex = 0;
                    BindGrid1();
                }
            }
            // 若找不到資料, 警告之並出現新視窗要求新增
            else
            {
                JavaScript.AlertMessage(this.Page, "廣告版面/廣告色彩/廣告篇幅 組合不存在 請檢查並重新輸入");
                return;
                // 開啟小視窗
                //string strbuf = "adlprior_addnew.aspx";
                //strbuf = strbuf + "?function=new&ltpcd=" + strLtpcd + "&clrcd=" + strClrcd + "&pgscd=" + strPgscd;
                ////Response.Write(strbuf);
                //this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>"); 

            }
        }

        // 新增落版資料
        private void InsertToDB()
        {
            // 落版檔資料 - 抓下畫面上的值
            string strSyscd = "C2";
            string strContNo = this.tbxContNo.Text.ToString().Trim();
            string strYYYYMM = this.tbxYYYYMM.Value.ToString().Trim();
            string strPubSeq = this.lblPubSeq.Text.ToString().Trim();
            int strPgNo = 0;
            if (this.tbxPageNo.Text.ToString().Trim() != "")
                strPgNo = Convert.ToInt32(this.tbxPageNo.Text.ToString().Trim());
            else
                strPgNo = strPgNo;
            string strLtpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
            string strClrcd = this.ddlColorCode.SelectedItem.Value.ToString();
            string strPgscd = this.ddlPageSizeCode.SelectedItem.Value.ToString();
            float strAdAmt = 0;
            if (this.tbxAdAmt.Text.ToString().Trim() != "")
                strAdAmt = Convert.ToSingle(this.tbxAdAmt.Text.ToString().Trim());
            else
                strAdAmt = strAdAmt;
            float strChgAmt = 0;
            if (this.tbxChgAmt.Text.ToString().Trim() != "")
                strChgAmt = Convert.ToSingle(this.tbxChgAmt.Text.ToString().Trim());
            else
                strChgAmt = strChgAmt;
            string strOrigBkcd = "";
            int strOrigJNo = 0;
            if (this.tbxOrigjno.Text.ToString().Trim() != "")
                strOrigJNo = Convert.ToInt32(this.tbxOrigjno.Text.ToString().Trim());
            else
                strOrigJNo = strOrigJNo;
            int strOrigBkno = 0;
            if (this.tbxOrigbkno.Text.ToString().Trim() != "")
                strOrigBkno = Convert.ToInt32(this.tbxOrigbkno.Text.ToString().Trim());
            else
                strOrigBkno = strOrigBkno;
            string strChgBkcd = "";
            int strChgJNo = 0;
            if (this.tbxChgjno.Text.ToString().Trim() != "")
                strChgJNo = Convert.ToInt32(this.tbxChgjno.Text.ToString().Trim());
            else
                strChgJNo = strChgJNo;
            int strChgBkno = 0;
            if (this.tbxChgbkno.Text.ToString().Trim() != "")
                strChgBkno = Convert.ToInt32(this.tbxChgbkno.Text.ToString().Trim());
            else
                strChgBkno = strChgBkno;
            string strfgReChg = "";
            string strNjtpcd = "";
            string strfgGot = "0";
            string strDrafttp = this.ddlDraftType.SelectedItem.Value.ToString().Trim();
            //Response.Write("strDrafttp= " + strDrafttp + "<br>");
            switch (strDrafttp)
            {
                case "1":
                    strOrigBkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString().Trim();
                    strOrigJNo = strOrigJNo;
                    strOrigBkno = strOrigBkno;
                    strChgBkcd = "";
                    strNjtpcd = "";
                    break;
                case "2":
                    strNjtpcd = this.ddlNJTypeCode.SelectedItem.Value.ToString();
                    strOrigBkcd = "";
                    strChgBkcd = "";
                    // 若 rblfggot 沒有選擇時, 給予預設值 0
                    if (this.rblfggot.SelectedIndex >= 0)
                        strfgGot = this.rblfggot.SelectedItem.Value.ToString().Trim();
                    else
                        strfgGot = strfgGot;
                    break;
                case "3":
                    strChgBkcd = this.ddlChgBookCode.SelectedItem.Value.ToString().Trim();
                    strChgJNo = strChgJNo;
                    strChgBkno = strChgBkno;
                    // 若 strfgReChg 沒有選擇時, 給予預設值 0
                    strfgReChg = "0";
                    if (this.rblfgrechg.SelectedIndex >= 0)
                        strfgReChg = this.rblfgrechg.SelectedItem.Value.ToString().Trim();
                    else
                        strfgReChg = strfgReChg;
                    // 若 rblfggot 沒有選擇時, 給予預設值 0
                    if (this.rblfggot.SelectedIndex >= 0)
                        strfgGot = this.rblfggot.SelectedItem.Value.ToString().Trim();
                    else
                        strfgGot = strfgGot;
                    break;
                default:
                    strOrigBkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString().Trim();
                    strOrigJNo = strOrigJNo;
                    strOrigBkno = strOrigBkno;
                    strChgBkcd = "";
                    strNjtpcd = "";
                    break;
            }
            string strProjNo = this.lblProjNo.Text.ToString().Trim();
            string strCostCtr = this.lblCostCtr.Text.ToString().Trim();
            // 給予 fginved 預設值 ' ' (表示 否 (尚未開立 發票開立單))
            string strfgInvcd = " ";
            // 給予 fginvself 預設值 0 (表示 否)
            string strfgInvSelf = "0";
            string strPNo = this.tbxBkpPno.Value;
            string strRemark = this.tbxRemark.Text.ToString().Trim();
            string strfgFixPg = "0";
            // 若 rblfgfixpage 沒有選擇時, 給予預設值 0
            if (this.rblfgfixpage.SelectedIndex >= 0)
                strfgFixPg = this.rblfgfixpage.SelectedItem.Value.ToString().Trim();
            else
                strfgFixPg = strfgFixPg;
            string strModDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
            //string strModEmpNo = "800443";
            // 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_show.aspx.cs 處不同處 
            // 抓出登入者的工號, 作為預設 修改業務員 之值
            string strModEmpNo = "";
            //Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
            // 若有登入者的資料, 則抓出並預選 修改業務員之下拉式選單
            if (Account.GetAccInfo().srspn_empno.ToString().Trim() != null && Account.GetAccInfo().srspn_empno.ToString().Trim() != "")
            {
                strModEmpNo = Account.GetAccInfo().srspn_empno.ToString().Trim();
            }
            // 若無登入者的資料, 則抓出並預選 修改業務員為 康靜怡 (800443, SelectedIndex=02)
            else
            {
                strModEmpNo = "800443";
            }
            string strBkcd = this.tbxBkcd.Text.ToString();
            string strImSeq = "";
            // 若找無 ddlIMSeq 資料
            if (this.ddlIMSeq.Items.Count != 0)
            {
                strImSeq = this.ddlIMSeq.SelectedItem.Value.ToString();
            }
            string strfgUpdated = "0";
            string strfgAct = "0";

            string strpulpg = "0";
            // 若 rblfgfixpage 沒有選擇時, 給予預設值 0
            if (this.RdPull.SelectedIndex >= 0)
            {
                strpulpg = this.RdPull.SelectedItem.Value.ToString().Trim();
            }
            //Response.Write("strSyscd= " + strSyscd + ", ");
            //Response.Write("strContNo= " + strContNo + ", ");
            //Response.Write("strYYYYMM= " + strYYYYMM + ", ");
            //Response.Write("strPubSeq= " + strPubSeq + "<br>");
            //Response.Write("strPgNo= " + strPgNo + "<br>");
            //Response.Write("strLtpcd= " + strLtpcd + "<br>");
            //Response.Write("strClrcd= " + strClrcd + "<br>");
            //Response.Write("strPgscd= " + strPgscd + "<br>");
            //Response.Write("strAdAmt= " + strAdAmt + "<br>");
            //Response.Write("strChgAmt= " + strChgAmt + "<br>");
            //Response.Write("strDrafttp= " + strDrafttp + "<br>");
            //Response.Write("strOrigBkcd= " + strOrigBkcd + "<br>");
            //Response.Write("strOrigJNo= " + strOrigJNo + "<br>");
            //Response.Write("strOrigBkno= " + strOrigBkno + "<br>");
            //Response.Write("strChgBkcd= " + strChgBkcd + "<br>");
            //Response.Write("strChgJNo= " + strChgJNo + "<br>");
            //Response.Write("strChgBkno= " + strChgBkno + "<br>");
            //Response.Write("strfgReChg= " + strfgReChg + "<br>");
            //Response.Write("strNjtpcd= " + strNjtpcd + "<br>");
            //Response.Write("strfgGot= " + strfgGot + "<br>");
            //Response.Write("strProjNo= " + strProjNo + "<br>");
            //Response.Write("strCostCtr= " + strCostCtr + "<br>");
            //Response.Write("strfgInvcd= " + strfgInvcd + "<br>");
            //Response.Write("strfgInvSelf= " + strfgInvSelf + "<br>");
            //Response.Write("strPNo= " + strPNo + "<br>");
            //Response.Write("strRemark= " + strRemark + "<br>");
            //Response.Write("strfgFixPg= " + strfgFixPg + "<br>");
            //Response.Write("strModDate= " + strModDate + "<br>");
            //Response.Write("strModEmpNo= " + strModEmpNo + "<br>");
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strImSeq= " + strImSeq + "<br>");
            //Response.Write("strfgUpdated= " + strfgUpdated + "<br>");
            //Response.Write("strfgAct= " + strfgAct + "<br>");

            // 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
            //Response.Write(this.sqlCommand1.CommandText);
            // 此外, 若 ddlIMSeq 不為空者, 則允許新增
            if (strImSeq.Trim() != "")
            {
                myPub.Insertc2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq, strPgNo, strLtpcd, strClrcd, strPgscd, strAdAmt, strChgAmt, strDrafttp, strOrigBkcd, strOrigJNo, strOrigBkno,
                    strChgBkcd, strChgJNo, strChgBkno, strfgReChg, strfgGot, strNjtpcd, strProjNo, strCostCtr, strfgInvcd, strfgInvSelf, strPNo, strRemark, strfgFixPg, strModDate, strModEmpNo, strBkcd,
                    strImSeq, strfgUpdated, strfgAct, strpulpg);
                // 確認執行 sqlCommand1 成功


                // 更新 合約檔 相關資料 - 
                // 先抓出 合約書相關資料, 再做計算
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds11 = myPub.Selectc2_cont3();
                DataView dv11 = ds11.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr11 = "1=1";
                rowfilterstr11 = rowfilterstr11 + " AND cont_syscd='" + strSyscd + "'";
                rowfilterstr11 = rowfilterstr11 + " AND cont_contno='" + strContNo + "'";
                dv11.RowFilter = rowfilterstr11;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv11.Count= "+ dv11.Count + "<BR>");
                //Response.Write("dv11.RowFilter= " + dv11.RowFilter + "<BR>");

                // 若搜尋結果為 "找不到" 的處理
                float ContPubAmt = 0;
                float ContChgAmt = 0;
                int ContRestClrtm = 0;
                int ContRestGetClrtm = 0;
                int ContRestMenotm = 0;
                int ContTotjtm = 0;
                int ContMadejtm = 0;
                int ContRestjtm = 0;
                int ContPubtm = 0;
                int ContResttm = 0;
                string Contfgpubed = "1";
                int ContNjtpcnt = 0;
                if (dv11.Count > 0)
                {
                    ContPubAmt = Convert.ToSingle(dv11[0]["cont_pubamt"].ToString().Trim());
                    ContChgAmt = Convert.ToSingle(dv11[0]["cont_chgamt"].ToString().Trim());
                    ContRestClrtm = Convert.ToInt32(dv11[0]["cont_restclrtm"].ToString().Trim());
                    ContRestGetClrtm = Convert.ToInt32(dv11[0]["cont_restgetclrtm"].ToString().Trim());
                    ContRestMenotm = Convert.ToInt32(dv11[0]["cont_restmenotm"].ToString().Trim());
                    ContTotjtm = Convert.ToInt32(dv11[0]["cont_totjtm"].ToString().Trim());
                    ContMadejtm = Convert.ToInt32(dv11[0]["cont_madejtm"].ToString().Trim());
                    ContRestjtm = Convert.ToInt32(dv11[0]["cont_restjtm"].ToString().Trim());
                    ContPubtm = Convert.ToInt32(dv11[0]["cont_pubtm"].ToString().Trim());
                    ContResttm = Convert.ToInt32(dv11[0]["cont_resttm"].ToString().Trim());
                    ContNjtpcnt = Convert.ToInt32(dv11[0]["cont_njtpcnt"].ToString().Trim());
                }

                // 重新計算 新結果
                // 落版總廣告金額 & 落版總換稿金額
                ContPubAmt = ContPubAmt + strAdAmt;
                ContChgAmt = ContChgAmt + strChgAmt;


                // 剩餘彩色/套色/黑白次數
                int CountClrtm = 0;
                CountClrtm = 1;
                // 若次數>0 (表示有資料), 則剩餘次數減一
                if (ContRestClrtm > 0)
                {
                    ContRestClrtm = ContRestClrtm - CountClrtm;
                }
                else
                {
                    ContRestClrtm = ContRestClrtm;
                }

                if (ContRestGetClrtm > 0)
                {
                    ContRestGetClrtm = ContRestGetClrtm - CountClrtm;
                }
                else
                {
                    ContRestGetClrtm = ContRestGetClrtm;
                }

                if (ContRestMenotm > 0)
                {
                    ContRestMenotm = ContRestMenotm - CountClrtm;
                }
                else
                {
                    ContRestMenotm = ContRestMenotm;
                }


                // 已製稿次數 & 剩餘製稿次數
                int CountMadejtm = 0;
                //Response.Write("strDrafttp= " + strDrafttp + "<br>");
                // 若為舊稿, 不做處理
                if (strDrafttp == "1")
                {
                    CountMadejtm = 0;
                    ContMadejtm = ContMadejtm;
                    ContRestjtm = ContTotjtm - ContMadejtm;
                }
                // 若為 新稿/改稿, 則已製稿次數+1, 剩餘製稿次數-1
                else
                {
                    CountMadejtm = 1;
                    ContMadejtm = ContMadejtm + CountMadejtm;
                    ContRestjtm = ContRestjtm - CountMadejtm;
                }


                // 已刊登次數 & 剩餘刊登次數
                int PubtmCount = 1;
                ContPubtm = ContPubtm + PubtmCount;
                ContResttm = ContResttm - PubtmCount;


                // 新稿份數
                int CountNjtpcd = 1;
                //Response.Write("strDrafttp= " + strDrafttp + "<br>");
                if (strDrafttp == "2")
                    ContNjtpcnt = ContNjtpcnt + CountNjtpcd;
                else
                    ContNjtpcnt = ContNjtpcnt;
                //Response.Write("CountNjtpcd= " + CountNjtpcd + "<br>");


                myPub.Updatec2_cont2(ContPubAmt, ContChgAmt, Contfgpubed, ContRestClrtm, ContRestMenotm, ContRestGetClrtm, ContMadejtm, ContRestjtm, ContPubtm, ContResttm, ContNjtpcnt, strSyscd, strContNo);

                JavaScript.AlertMessage(this.Page, "更新合約書相關資料成功!");
                // 確認執行 sqlCommand2 成功


                // panel 重新歸回
                this.ddlDraftType.SelectedIndex = 0;
                this.pnlOrig.Visible = true;
                this.pnlChg.Visible = false;
                this.rblfgrechg.Visible = false;
                this.pnlNjtp.Visible = false;


                // 結束: 若 ddlIMSeq 不為空者
            }
            else
            {
                // 以 Javascript 的 window.alert()  來告知訊息
                //LiteralControl litAlert2 = new LiteralControl();
                //litAlert2.Text = "<script language=javascript>alert(\"新增失敗: 不允許發票廠商收件人資料為空白. 請先補足!\");</script>";
                //Page.Controls.Add(litAlert2);
                JavaScript.AlertMessage(this.Page, "新增失敗: 不允許發票廠商收件人資料為空白. 請先補足!");
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            CheckLPriorSeq2();
        }

        // 抓出畫面上 廣告版面/廣告色彩/廣告篇幅, 檢查此組合是否存在於 c2_lprior
        public void CheckLPriorSeq2()
        {
            // 落版檔資料 - 抓下畫面上的值
            string strBkcd = tbxBkcd.Text.Trim();
            string strLtpcd = ddlLTypeCode.SelectedItem.Value.ToString().Trim();
            string strClrcd = ddlColorCode.SelectedItem.Value.ToString().Trim();
            string strPgscd = ddlPageSizeCode.SelectedItem.Value.ToString().Trim();
            //Response.Write("strLtpcd= " + strLtpcd + "<br>");
            //Response.Write("strClrcd= " + strClrcd + "<br>");
            //Response.Write("strPgscd= " + strPgscd + "<br>");

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds21 = myPub.Selectc2_lprior();
            DataView dv21 = ds21.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr21 = "1=1";
            rowfilterstr21 = rowfilterstr21 + " AND lp_bkcd='" + strBkcd + "'";
            rowfilterstr21 = rowfilterstr21 + " AND lp_ltpcd='" + strLtpcd + "'";
            rowfilterstr21 = rowfilterstr21 + " AND lp_clrcd='" + strClrcd + "'";
            rowfilterstr21 = rowfilterstr21 + " AND lp_pgscd='" + strPgscd + "'";
            dv21.RowFilter = rowfilterstr21;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv21.Count= "+ dv21.Count + "<BR>");
            //Response.Write("dv21.RowFilter= " + dv21.RowFilter + "<BR>");

            // 若搜尋結果為 "找到" 的處理: 允許新增/修改
            if (dv21.Count > 0)
            {
                // 執行修改動作
                ModifyDB();

                // Refresh Page
                DataGrid1.CurrentPageIndex = 0;
                BindGrid1();

                // 修改成功後, 將 儲存修改按鈕隱藏起來
                this.btnModify.Visible = false;
                this.btnSave.Visible = true;
                this.btnLoadData.Visible = true;


                // 回復 - 不允許修改 PK, 隱藏 PubSeq & YYYYMM & PNo
                this.lblPubSeq.Enabled = true;
                this.tbxYYYYMM.Disabled = false;
                this.tbxBkpPno.Disabled = false;

                // 資料回復初始狀態
                InitialData();
                //NewData();
            }
            // 若找不到資料, 警告之並出現新視窗要求新增
            else
            {
                // 開啟小視窗
                string strbuf = "adlprior_addnew.aspx";
                strbuf = strbuf + "?function=mod&ltpcd=" + strLtpcd + "&clrcd=" + strClrcd + "&pgscd=" + strPgscd;
                //Response.Write(strbuf);

                // 以 Javascript 的 window.alert()  來告知訊息 - 移至 adlprior_addnew.aspx.cs
                // 以 Javascript 的 window.open()  來告知訊息
                this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>"); 
                //litWinOpen1.Text="<script language=\"javascript\">window.showModalDialog(\"" + strbuf + "\", 'new Object()', 'dialogWidth:700px; dialogHeight:400px; dialogLeft:30px; dialogTop:22px; center:yes; scroll:yes; status:no; help:no;');</script>";
            }
        }

        // 修改資料 from DB Table
        private void ModifyDB()
        {
            // 抓出 畫面上的值
            string strSyscd = "C2";
            string strContNo = this.tbxContNo.Text.ToString().Trim();
            string strPubSeq = this.lblPubSeq.Text.ToString();
            string strYYYYMM = this.tbxYYYYMM.Value.ToString().Trim();
            string strBkpPno = this.tbxBkpPno.Value.ToString().Trim();
            int intPgNo = 0;
            if (this.tbxPageNo.Text.ToString().Trim() != "")
                intPgNo = Convert.ToInt32(this.tbxPageNo.Text.ToString().Trim());
            string strClrcd = this.ddlColorCode.SelectedItem.Value.ToString();
            string strLtpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
            string strPgscd = this.ddlPageSizeCode.SelectedItem.Value.ToString();
            // 若 strfgfixpg 沒有選擇時, 給予預設值 0
            string strfgfixpg = "0";
            if (this.rblfgfixpage.SelectedIndex >= 0)
                strfgfixpg = this.rblfgfixpage.SelectedItem.Value.ToString().Trim();
            else
                strfgfixpg = strfgfixpg;
            string strIMSeq = this.ddlIMSeq.SelectedItem.Value.ToString();
            float floatAdAmt = Convert.ToSingle(this.tbxAdAmt.Text.ToString().Trim());
            float floatChgAmt = Convert.ToSingle(this.tbxChgAmt.Text.ToString().Trim());

            string strpulpg = "0";
            if (this.RdPull.SelectedIndex >= 0)
            {
                strpulpg = this.RdPull.SelectedItem.Value.ToString().Trim();
            }
            //// 給予 strfginved 預設值 ' '  (表示 否 (尚未開立 發票開立單))
            //string strfginved = " ";
            // 給予 strfginvself 預設值 0 (表示 否)
            //string strfginvself = "0";
            string strRemark = this.tbxRemark.Text.ToString().Trim();
            string strDrafttp = this.ddlDraftType.SelectedItem.Value.ToString().Trim();
            string strOrigbkcd = "";
            int intOrigjno = 0;
            int intOrigbkno = 0;
            string strChgbkcd = "";
            int intChgjno = 0;
            int intChgbkno = 0;
            string strfgReChg = "";
            string strNjtpcd = "";
            string strfggot = "0";
            if (strDrafttp == "1")
            {
                strOrigbkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString();
                if (tbxOrigjno.Text.Trim() != "")
                    intOrigjno = Convert.ToInt32(tbxOrigjno.Text.Trim());

                if (tbxOrigbkno.Text.Trim() != "")
                    intOrigbkno = Convert.ToInt32(tbxOrigbkno.Text.Trim());

            }
            else if (strDrafttp == "2")
            {
                strNjtpcd = this.ddlNJTypeCode.SelectedItem.Value.ToString().Trim();
                // 若 strfggot 沒有選擇時, 給予預設值 0
                if (this.rblfggot.SelectedIndex >= 0)
                    strfggot = this.rblfggot.SelectedItem.Value.ToString().Trim();
                else
                    strfggot = strfggot;
            }
            else if (strDrafttp == "3")
            {
                strChgbkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString();
                if (this.tbxChgjno.Text.ToString().Trim() != "")
                    intChgjno = Convert.ToInt32(this.tbxChgjno.Text.ToString().Trim());
                else
                    intChgjno = intChgjno;
                if (this.tbxChgbkno.Text.ToString().Trim() != "")
                    intChgbkno = Convert.ToInt32(this.tbxChgbkno.Text.ToString().Trim());
                else
                    intChgbkno = intChgbkno;
                // 若 strfgReChg 沒有選擇時, 給予預設值 0
                strfgReChg = "0";
                if (this.rblfgrechg.SelectedIndex >= 0)
                    strfgReChg = this.rblfgrechg.SelectedItem.Value.ToString().Trim();
                else
                    strfgReChg = strfgReChg;
                // 若 strfggot 沒有選擇時, 給予預設值 0
                if (this.rblfggot.SelectedIndex >= 0)
                    strfggot = this.rblfggot.SelectedItem.Value.ToString().Trim();
                else
                    strfggot = strfggot;
            }
            string strProjNo = this.lblProjNo.Text.ToString().Trim();
            string strCostCtr = this.lblCostCtr.Text.ToString().Trim();
            string strBkcd = this.tbxBkcd.Text.ToString();
            string strModDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
            //string strModEmpNo = "800443";
            // 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_show.aspx.cs 處不同處 
            // 抓出登入者的工號, 作為預設 修改業務員 之值
            string strModEmpNo = "";
            //Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
            // 若有登入者的資料, 則抓出並預選 修改業務員之下拉式選單

            if (Account.GetAccInfo().srspn_empno.ToString().Trim() != null && Account.GetAccInfo().srspn_empno.ToString().Trim() != "")
            {
                strModEmpNo = Account.GetAccInfo().srspn_empno.ToString().Trim();
            }
            else
            {
                strModEmpNo = "800443";// 若無登入者的資料, 則抓出並預選 修改業務員為 康靜怡 (800443, SelectedIndex=02)
            }

            myPub.Updatec2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq, intPgNo, strLtpcd, strClrcd, strPgscd, floatAdAmt, floatChgAmt, strDrafttp, strOrigbkcd, intOrigjno,
                intOrigbkno, strChgbkcd, intChgjno, intChgbkno, strfgReChg, strfggot, strNjtpcd, strProjNo, strCostCtr, strBkpPno, strRemark, strfgfixpg, strModDate, strModEmpNo, strBkcd, strIMSeq, strpulpg);


            // 確認執行 sqlSelectCommand1 成功


            // 回寫 合約相關資料
            // 先抓出 合約書相關資料, 再做計算
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds11 = myPub.Selectc2_cont3();
            DataView dv11 = ds11.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr11 = "1=1";
            rowfilterstr11 = rowfilterstr11 + " AND cont_syscd='" + strSyscd + "'";
            rowfilterstr11 = rowfilterstr11 + " AND cont_contno='" + strContNo + "'";
            dv11.RowFilter = rowfilterstr11;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv11.Count= "+ dv11.Count + "<BR>");
            //Response.Write("dv11.RowFilter= " + dv11.RowFilter + "<BR>");
            int ContTottm = 0;
            int ContTotClrtm = 0;
            int ContTotGetClrtm = 0;
            int ContTotMenotm = 0;
            int ContTotjtm = 0;
            int ContNjtpcnt = 0;
            if (dv11.Count > 0)
            {
                // 計算 剩餘刊登次數 - 先抓出 總刊登次數
                ContTottm = Convert.ToInt32(dv11[0]["cont_tottm"].ToString().Trim());

                // 計算 剩餘彩色/套色/黑白次數 - 先抓出 (總)彩色/套色/黑白次數
                ContTotClrtm = Convert.ToInt32(dv11[0]["cont_clrtm"].ToString().Trim());
                ContTotGetClrtm = Convert.ToInt32(dv11[0]["cont_getclrtm"].ToString().Trim());
                ContTotMenotm = Convert.ToInt32(dv11[0]["cont_menotm"].ToString().Trim());

                // 計算 剩餘製稿次數 - 先抓出 總製稿次數
                ContTotjtm = Convert.ToInt32(dv11[0]["cont_totjtm"].ToString().Trim());

                // 計算 新稿份數
                ContNjtpcnt = Convert.ToInt32(dv11[0]["cont_njtpcnt"].ToString().Trim());
            }
            else
            {
                ContTottm = ContTottm;
                ContTotClrtm = ContTotClrtm;
                ContTotGetClrtm = ContTotGetClrtm;
                ContTotMenotm = ContTotMenotm;
                ContTotjtm = ContTotjtm;
                ContNjtpcnt = ContNjtpcnt;
            }


            // 重新計算 新結果
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds13 = myPub.Selectc2_pub7();
            DataView dv13 = ds13.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr13 = "1=1";
            rowfilterstr13 = rowfilterstr13 + " AND pub_syscd='" + strSyscd + "'";
            rowfilterstr13 = rowfilterstr13 + " AND pub_contno='" + strContNo + "'";
            dv13.RowFilter = rowfilterstr13;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv13.Count= "+ dv13.Count + "<BR>");
            //Response.Write("dv13.RowFilter= " + dv13.RowFilter + "<BR>");

            float PubAdAmt = 0;
            float PubChgAmt = 0;
            float ContPubAmt = 0;
            float ContChgAmt = 0;
            if (dv13.Count > 0)
            {
                // 落版總廣告金額 & 落版總換稿金額
                PubAdAmt = Convert.ToSingle(dv13[0]["pub_adamt"].ToString().Trim());
                ContPubAmt = PubAdAmt;
                //Response.Write("PubAdAmt= " + PubAdAmt + "<br>");
                //Response.Write("ContPubAmt= " + ContPubAmt + "<br>");
                PubChgAmt = Convert.ToSingle(dv13[0]["pub_chgamt"].ToString().Trim());
                ContChgAmt = PubChgAmt;
                //Response.Write("PubChgAmt= " + PubChgAmt + "<br>");
                //Response.Write("ContChgAmt= " + ContChgAmt + "<br>");
            }
            else
            {
                ContPubAmt = ContPubAmt;
                ContChgAmt = ContChgAmt;
            }


            int PubClrCount = 0;
            int ContPubClrtm = 0;
            int ContPubGetClrtm = 0;
            int ContPubMenotm = 0;
            int ContRestClrtm = 0;
            int ContRestGetClrtm = 0;
            int ContRestMenotm = 0;
            // 剩餘彩色/套色/黑白次數
            string clrcd = "";
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds14 = myPub.Selectc2_pub6();
            DataView dv14 = ds14.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr14 = "1=1";
            rowfilterstr14 = rowfilterstr14 + " AND pub_syscd='" + strSyscd + "'";
            rowfilterstr14 = rowfilterstr14 + " AND pub_contno='" + strContNo + "'";
            dv14.RowFilter = rowfilterstr14;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv14.Count= "+ dv14.Count + "<BR>");
            //Response.Write("dv14.RowFilter= " + dv14.RowFilter + "<BR>");

            if (dv14.Count > 0)
            {
                for (int i = 0; i < dv14.Count; i++)
                {
                    clrcd = dv14[i]["pub_clrcd"].ToString().Trim();
                    PubClrCount = Convert.ToInt32(dv14[i]["CountNo"].ToString().Trim());
                    //Response.Write("clrcd= " + clrcd + "<br>");
                    //Response.Write("PubClrCount= " + PubClrCount + "<br>");

                    // 若為其他, 則依情況減一(當有資料時)
                    // 依不同廣告色彩, 抓出目前已刊登的廣告色彩次數 PubClrCount, 以求得剩餘彩色/套色/黑白次數
                    // 註: 以下 else 要暫時 disable, 才能抓到累積的次數; 否則是各行的正確結果
                    if (clrcd == "01")
                    {
                        ContPubClrtm = PubClrCount;
                        ContRestClrtm = ContTotClrtm - ContPubClrtm;
                    }
                    //else
                    //ContRestClrtm = 0;
                    if (clrcd == "02")
                    {
                        ContPubGetClrtm = PubClrCount;
                        ContRestGetClrtm = ContTotGetClrtm - ContPubGetClrtm;
                    }
                    //else
                    //ContRestGetClrtm = 0;
                    if (clrcd == "03")
                    {
                        ContPubMenotm = PubClrCount;
                        ContRestMenotm = ContTotMenotm - ContPubMenotm;
                    }
                    //else
                    //ContRestMenotm = 0;
                    //Response.Write("PubClrCount= " + PubClrCount + "<br>");
                    //Response.Write("ContPubClrtm= " + ContPubClrtm + "<br>");
                    //Response.Write("ContPubGetClrtm= " + ContPubGetClrtm + "<br>");
                    //Response.Write("ContPubMenotm= " + ContPubMenotm + "<br>");
                    //Response.Write("ContRestClrtm= " + ContRestClrtm + "<br>");
                    //Response.Write("ContRestGetClrtm= " + ContRestGetClrtm + "<br>");
                    //Response.Write("ContRestMenotm= " + ContRestMenotm + "<br>");
                    // 結束 for loop
                }
            }
            else
            {
                PubClrCount = 0;
                ContRestClrtm = ContTotClrtm;
                ContRestGetClrtm = ContTotGetClrtm;
                ContRestMenotm = ContTotMenotm;
            }


            int PubDraftCount = 0;
            int ContMadejtm = 0;
            int ContRestjtm = 0;
            // 已製稿次數 & 剩餘製稿次數
            string drafttp = "";
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds15 = myPub.Selectc2_pub8();
            DataView dv15 = ds15.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr15 = "1=1";
            rowfilterstr15 = rowfilterstr15 + " AND pub_syscd='" + strSyscd + "'";
            rowfilterstr15 = rowfilterstr15 + " AND pub_contno='" + strContNo + "'";
            dv15.RowFilter = rowfilterstr15;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv15.Count= "+ dv15.Count + "<BR>");
            //Response.Write("dv15.RowFilter= " + dv15.RowFilter + "<BR>");

            if (dv15.Count > 0)
            {
                for (int j = 0; j < dv15.Count; j++)
                {
                    drafttp = dv15[j]["pub_drafttp"].ToString().Trim();
                    PubDraftCount = Convert.ToInt32(dv15[j]["CountNo"].ToString().Trim());
                    //Response.Write("drafttp= " + drafttp + "<br>");
                    //Response.Write("PubDraftCount= " + PubDraftCount + "<br>");

                    // 若為舊稿, 不予處理
                    if (drafttp == "1")
                    {
                        ContMadejtm = ContMadejtm;
                        ContRestjtm = ContTotjtm - ContMadejtm;
                    }
                    // 若為 新稿/改稿, 則已製稿次數-1, 剩餘製稿次數+1
                    else
                    {
                        ContMadejtm = ContMadejtm + PubDraftCount;
                        ContRestjtm = ContTotjtm - ContMadejtm;
                    }
                    //Response.Write("ContMadejtm= " + ContMadejtm + "<br>");
                    //Response.Write("ContRestjtm= " + ContRestjtm + "<br>");
                }
            }
            else
            {
                ContMadejtm = ContMadejtm;
                ContRestjtm = ContTotjtm - ContMadejtm;
            }


            int PubtmCount = 0;
            int ContPubtm = 0;
            int ContResttm = 0;
            // 已刊登次數 & 剩餘刊登次數
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds18 = myPub.Selectc2_pub9();
            DataView dv18 = ds18.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr18 = "1=1";
            rowfilterstr18 = rowfilterstr18 + " AND pub_contno='" + strContNo + "'";
            dv18.RowFilter = rowfilterstr18;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv18.Count= "+ dv18.Count + "<BR>");
            //Response.Write("dv18.RowFilter= " + dv18.RowFilter + "<BR>");

            if (dv18.Count > 0)
            {
                PubtmCount = Convert.ToInt16(dv18[0]["CountNo"].ToString().Trim());
                ContPubtm = PubtmCount;
                ContResttm = ContTottm - PubtmCount;
            }
            else
            {
                PubtmCount = 0;
                ContPubtm = 0;
                ContResttm = ContTottm - ContPubtm;
            }
            //Response.Write("PubtmCount= " + PubtmCount + "<br>");
            //Response.Write("ContPubtm= " + ContPubtm + "<br>");
            //Response.Write("ContTottm= " + ContTottm + "<br>");
            //Response.Write("ContResttm= " + ContResttm + "<br>");


            // 新稿份數
            //Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds19 = myPub.Selectc2_pub10();
            DataView dv19 = ds19.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr19 = "1=1";
            rowfilterstr19 = rowfilterstr19 + " AND pub_contno='" + strContNo + "'";
            dv19.RowFilter = rowfilterstr19;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv19.Count= "+ dv19.Count + "<BR>");
            //Response.Write("dv19.RowFilter= " + dv19.RowFilter + "<BR>");

            if (dv19.Count > 0)
            {
                ContNjtpcnt = Convert.ToInt16(dv19[0]["CountNo"].ToString().Trim());
            }
            else
            {
                ContNjtpcnt = ContNjtpcnt;
            }
            //Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
            ContNjtpcnt = ContNjtpcnt;
            //Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");


            string Contfgpubed = "1";
            // 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 更新
            //Response.Write(this.sqlCommand2.CommandText);


            myPub.Updatec2_cont2(ContPubAmt, ContChgAmt, Contfgpubed, ContRestClrtm, ContRestMenotm, ContRestGetClrtm, ContMadejtm, ContRestjtm, ContPubtm, ContResttm, ContNjtpcnt, strSyscd, strContNo);
            // 確認執行 sqlCommand2 成功

            JavaScript.AlertMessage(this.Page, "更新合約書相關資料成功");
            // 清除畫面, 恢復至畫面初始
            ClearForm();

        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            // 呼叫 InitialData() function
            InitialData();
            //NewData();

            // 清除資料
            this.tbxYYYYMM.Value = "";
            this.tbxBkpPno.Value = "";
            this.tbxPageNo.Text = "";
            this.tbxOrigjno.Text = "";
            this.tbxOrigbkno.Text = "";
        }

        protected void btnGoChkList_Click(object sender, EventArgs e)
        {
            Response.Redirect("PubFm_chklist.aspx");
        }

        protected void ddlDraftType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 抓出目前選擇的 稿件類別
            string drafttp = "";
            drafttp = this.ddlDraftType.SelectedItem.Value.ToString().Trim();

            // 依不同類別, 顯示不同 Panel
            if (drafttp == "1")
            {
                this.pnlOrig.Visible = true;
                this.pnlChg.Visible = false;
                this.rblfgrechg.Visible = false;
                this.pnlNjtp.Visible = false;
                this.rblfggot.Visible = false;
                SetDefaultValue();
                // 以 Javascript 的 window.alert()  來告知訊息
                JavaScript.AlertMessage(this.Page, "您選擇 '舊稿'! 請注意金額是否填在 '廣告金額'~");

            }
            else if (drafttp == "2")
            {
                this.pnlOrig.Visible = false;
                this.pnlChg.Visible = false;
                this.rblfgrechg.Visible = false;
                this.pnlNjtp.Visible = true;
                this.rblfggot.Visible = true;
                this.rblfggot.SelectedIndex = 1;

                // 以 Javascript 的 window.alert()  來告知訊息
                JavaScript.AlertMessage(this.Page, "您選擇 '新稿'! 請注意金額是否填在 '換稿金額', 並請註記是否到稿~");
            }
            else if (drafttp == "3")
            {
                this.pnlOrig.Visible = false;
                this.pnlChg.Visible = true;
                this.rblfgrechg.Visible = true;
                this.pnlNjtp.Visible = false;
                this.rblfggot.Visible = true;
                this.rblfggot.SelectedIndex = 1;

                // 以 Javascript 的 window.alert()  來告知訊息
                JavaScript.AlertMessage(this.Page, "您選擇 '改稿'! 請注意金額是否填在 '換稿金額', 並請註記是否到稿");
            }
            else
            {
                this.pnlOrig.Visible = true;
                this.pnlChg.Visible = false;
                this.rblfgrechg.Visible = false;
                this.pnlNjtp.Visible = false;
                this.rblfggot.Visible = false;
            }
        }
    }
}