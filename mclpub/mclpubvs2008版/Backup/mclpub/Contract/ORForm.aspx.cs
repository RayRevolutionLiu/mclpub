using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class ORForm : System.Web.UI.Page
    {
        ORForm_DB myOR = new ORForm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 給預設資料 - 新增Form
                InitialData();

                // 判斷是否要 載入歷史資料
                // 若 fgnew=1 載入 歷史資料
                // 若 fgnew=0 為新合約, 並無初始資料, 故不需做 BindGrid1()
                if (Context.Request.QueryString["fgnew"].ToString().Trim() == "1")
                {
                    BindGrid1();
                }
                else
                {
                    // do nothing 不載入
                    this.lblHistoryMessage.Text = "無初始資料, 請自行新增!<br>";
                }


                // 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
                this.btnModify.Visible = false;
                this.btnSave.Visible = true;
                this.btnLoadData.Visible = true;
                this.lblORItem.Visible = false;

                BindGrid2();


                // 顯示下拉式選單 郵寄類別代碼的 DB 值
                DataSet ds1 = myOR.SelectMtp();
                ddlORmtpcd.DataSource = ds1;
                ddlORmtpcd.DataTextField = "mtp_nm";
                ddlORmtpcd.DataValueField = "mtp_mtpcd";
                ddlORmtpcd.DataBind();

                // 給下拉式選單 預選值
                ddlORmtpcd.SelectedIndex = 0;
                ddlORfgmosea.SelectedIndex = 0;
            }
        }


        // 給預設資料 - 新增Form
        private void InitialData()
        {
            // 設預設值: 有登本數 & 未登本數
            this.tbxORPubCount.Text = "0";
            this.tbxORUnPubCount.Text = "0";


            // 藉由前一網頁傳來的變數值字串 
            string contno = "";
            string custno = "";

            // 載入預設資料 - 合約書編號
            if (Context.Request.QueryString["contno"].ToString().Trim() != "" || Context.Request.QueryString["contno"].ToString().Trim() != null)
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
                //Response.Write("contno= " + contno + "<BR>");
            }

            // 載入預設資料 - 抓出廠商編號及客戶資料
            if (Context.Request.QueryString["custno"].ToString().Trim() != "" || Context.Request.QueryString["custno"].ToString().Trim() != null)
            {
                custno = Context.Request.QueryString["custno"].ToString().Trim();
                //Response.Write("custno= " + custno + "<BR>");


                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds3 = myOR.SelectCust();
                DataView dv3 = ds3.Tables["cust"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr3 = "1=1";
                rowfilterstr3 = rowfilterstr3 + " AND cust_custno='" + custno + "'";
                dv3.RowFilter = rowfilterstr3;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
                //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

                // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
                if (dv3.Count > 0)
                {
                    // 抓出 客戶相關資料
                    string custnm = "";
                    string custjbti = "";
                    string custtel = "";
                    string custfax = "";
                    string custcell = "";
                    string custemail = "";
                    string mfrno = "";
                    custnm = dv3[0]["cust_nm"].ToString().Trim();
                    custjbti = dv3[0]["cust_jbti"].ToString().Trim();
                    custtel = dv3[0]["cust_tel"].ToString().Trim();
                    custfax = dv3[0]["cust_fax"].ToString().Trim();
                    custcell = dv3[0]["cust_cell"].ToString().Trim();
                    custemail = dv3[0]["cust_email"].ToString().Trim();
                    mfrno = dv3[0]["cust_mfrno"].ToString().Trim();
                    //Response.Write("mfrno= " + mfrno + "<br>");

                    if (custnm != "")
                        this.tbxORName.Text = custnm;
                    if (custjbti != "")
                        this.tbxORJobTitle.Text = custjbti;
                    if (custtel != "")
                        this.tbxORTel.Text = custtel;
                    if (custfax != "")
                        this.tbxORFax.Text = custfax;
                    if (custcell != "")
                        this.tbxORCell.Text = custcell;
                    if (custemail != "")
                        this.tbxOREmail.Text = custemail;

                    // 顯示 客戶編號 (not visible)
                    this.lblCustNo.Text = custno;


                    // 顯示廠商相關資料
                    if (mfrno != "")
                    {
                        // 顯示 廠商統編 (not visible)
                        this.lblMfrNo.Text = mfrno;

                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds4 = myOR.SelectMfr();
                        DataView dv4 = ds4.Tables["mfr"].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        string rowfilterstr4 = "1=1";
                        rowfilterstr4 = rowfilterstr4 + " AND mfr_mfrno='" + mfrno + "'";
                        dv4.RowFilter = rowfilterstr4;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                        //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                        if (dv4.Count > 0)
                        {
                            // 抓出 廠商相關資料
                            string mfrinm = "";
                            string mfrzipcode = "";
                            string mfraddr = "";
                            mfrinm = dv4[0]["mfr_inm"].ToString().Trim();
                            mfrzipcode = dv4[0]["mfr_izip"].ToString().Trim();
                            mfraddr = dv4[0]["mfr_iaddr"].ToString().Trim();

                            if (mfrinm != "")
                                this.tbxORMfrIName.Text = mfrinm;
                            if (mfrzipcode != "")
                                this.tbxORZipcode.Text = mfrzipcode;
                            if (mfraddr != "")
                                this.tbxORAddr.Text = mfraddr;

                            // 顯示廠商發票名稱及統編
                            this.lblMfrNo.Text = mfrno;
                            this.lblMfrInfo.Text = "預設廠商：" + mfrinm + " (" + mfrno + ")";
                        }
                    }
                }
            }
        }


        private void BindGrid1()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds5 = myOR.SelectC2_or();
            DataView dv5 = ds5.Tables["c2_or"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";

            string old_contno = "";
            if (Context.Request.QueryString["old_contno"].ToString().Trim() != "")
            {
                old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
                rowfilterstr5 = rowfilterstr5 + " and or_contno = '" + old_contno + "'";
            }
            else
            {
                old_contno = "0";
            }
            dv5.RowFilter = rowfilterstr5;
            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv5.Count > 0)
            {
                GridView1.DataSource = dv5;
                GridView1.DataBind();

            }

        }


        protected void GridView1OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 郵寄類別代碼
                string mtpcd = e.Row.Cells[13].Text.Trim();
                //Response.Write("mtpcd= " + mtpcd + "<br>");

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds1 = myOR.SelectMtp();
                DataView dv1 = ds1.Tables["mtp"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr1 = "1=1";
                rowfilterstr1 = rowfilterstr1 + " AND mtp_mtpcd='" + mtpcd + "'";
                dv1.RowFilter = rowfilterstr1;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
                //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

                if (dv1.Count > 0)
                {
                    // 抓出 郵寄類別相關資料
                    string mtpnm = dv1[0]["mtp_nm"].ToString().Trim();
                    e.Row.Cells[13].Text = mtpnm;
                }
                else
                {
                    e.Row.Cells[13].Text = "<font color='Red'>（資料有誤)</font>";
                }


                // 海外郵寄註記
                string fgmosea = e.Row.Cells[14].Text.Trim();
                switch (fgmosea)
                {
                    case "0":
                        e.Row.Cells[14].Text = "國內";
                        break;
                    case "1":
                        e.Row.Cells[14].Text = "<font color='Red'>國外</font>";
                        break;
                    default:
                        e.Row.Cells[14].Text = "國內";
                        break;
                }
            }
        }

        protected void GridView1OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 載入資料
            if (e.CommandName == "LKload")
            {
                // 抓出 PK 值, 將相關資料載入 新增Form 裡
                string strsyscd = "C2";
                string strcontno = Context.Request.QueryString["old_contno"].ToString().Trim();
                string strORItem = e.CommandArgument.ToString();
                //Response.Write("strsyscd= " + strsyscd + ", ");
                //Response.Write("strcontno= " + strcontno + ", ");
                //Response.Write("strORItem= " + strORItem + "<br>");

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds5 = myOR.SelectC2_or();
                DataView dv5 = ds5.Tables["c2_or"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr5 = "1=1";
                rowfilterstr5 = rowfilterstr5 + " AND or_syscd='" + strsyscd + "'";
                rowfilterstr5 = rowfilterstr5 + " AND or_contno='" + strcontno + "'";
                rowfilterstr5 = rowfilterstr5 + " AND or_oritem='" + strORItem + "'";
                dv5.RowFilter = rowfilterstr5;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
                //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

                // 載入資料			
                if (dv5.Count > 0)
                {
                    // 將序號顯示在 lblORItem; 否則修改時無法抓出其序號
                    this.lblORItem.Visible = true;
                    this.lblORItem.Text = strORItem;

                    // 顯示其相關資料
                    this.tbxORContNo.Text = strcontno;
                    this.tbxORMfrIName.Text = dv5[0]["or_inm"].ToString().Trim();
                    this.tbxORName.Text = dv5[0]["or_nm"].ToString().Trim();
                    this.tbxORJobTitle.Text = dv5[0]["or_jbti"].ToString().Trim();
                    this.tbxORZipcode.Text = dv5[0]["or_zip"].ToString().Trim();
                    this.tbxORAddr.Text = dv5[0]["or_addr"].ToString().Trim();
                    this.tbxORTel.Text = dv5[0]["or_tel"].ToString().Trim();
                    this.tbxORFax.Text = dv5[0]["or_fax"].ToString().Trim();
                    this.tbxORCell.Text = dv5[0]["or_cell"].ToString().Trim();
                    this.tbxOREmail.Text = dv5[0]["or_email"].ToString().Trim();
                    this.tbxORPubCount.Text = dv5[0]["or_pubcnt"].ToString().Trim();
                    this.tbxORUnPubCount.Text = dv5[0]["or_unpubcnt"].ToString().Trim();
                    // 下述 coding 無法抓出正確之 下拉式選單的預選值
                    //this.ddlORmtpcd.SelectedItem.Value = dv5[0]["or_mtpcd"].ToString().Trim();
                    //this.ddlORfgmosea.SelectedItem.Value = dv5[0]["or_fgmosea"].ToString().Trim();

                    // 發票類別代碼
                    string mtpcd = dv5[0]["or_mtpcd"].ToString().Trim();
                    switch (mtpcd)
                    {
                        case "11":
                            this.ddlORmtpcd.SelectedIndex = 0;
                            break;
                        case "12":
                            this.ddlORmtpcd.SelectedIndex = 1;
                            break;
                        case "19":
                            this.ddlORmtpcd.SelectedIndex = 2;
                            break;
                        case "21":
                            this.ddlORmtpcd.SelectedIndex = 3;
                            break;
                        case "22":
                            this.ddlORmtpcd.SelectedIndex = 4;
                            break;
                        case "23":
                            this.ddlORmtpcd.SelectedIndex = 5;
                            break;
                        case "24":
                            this.ddlORmtpcd.SelectedIndex = 6;
                            break;
                        case "26":
                            this.ddlORmtpcd.SelectedIndex = 7;
                            break;
                        case "27":
                            this.ddlORmtpcd.SelectedIndex = 8;
                            break;
                        case "28":
                            this.ddlORmtpcd.SelectedIndex = 9;
                            break;
                        case "29":
                            this.ddlORmtpcd.SelectedIndex = 10;
                            break;
                        default:
                            this.ddlORmtpcd.SelectedIndex = 0;
                            break;
                    }

                    // 發票類別代碼
                    string fgmosea = dv5[0]["or_fgmosea"].ToString().Trim();
                    switch (fgmosea)
                    {
                        case "0":
                            this.ddlORfgmosea.SelectedIndex = 0;
                            break;
                        case "1":
                            this.ddlORfgmosea.SelectedIndex = 1;
                            break;
                        default:
                            this.ddlORfgmosea.SelectedIndex = 0;
                            break;
                    }

                }

                // 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
                // 載入歷史資料後, 須再按 儲存新增, 才會呼叫 btnSave_Click()
                this.btnModify.Visible = false;
                this.btnSave.Visible = true;
            }
            #endregion
        }


        private void BindGrid2()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds5 = myOR.SelectC2_or();
            DataView dv5 = ds5.Tables["c2_or"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";

            string contno = "";
            if (Context.Request.QueryString["contno"].ToString().Trim() != "")
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
                rowfilterstr5 = rowfilterstr5 + " and or_contno = '" + contno + "'";
            }
            dv5.RowFilter = rowfilterstr5;
            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv5.Count > 0)
            {
                GridView2.DataSource = dv5;
                GridView2.DataBind();

            }
            // 若全部刪除完時, 仍顯示殘存的最後一筆資料; 下段為清除此 bug
            else
            {
                GridView2.Visible = false;
            }
        }


        protected void GridView2OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 郵寄類別代碼
                string mtpcd = e.Row.Cells[14].Text.Trim();

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds1 = myOR.SelectMtp();
                DataView dv1 = ds1.Tables["mtp"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr1 = "1=1";
                rowfilterstr1 = rowfilterstr1 + " AND mtp_mtpcd='" + mtpcd + "'";
                dv1.RowFilter = rowfilterstr1;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
                //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

                if (dv1.Count > 0)
                {
                    // 抓出 郵寄類別相關資料
                    string mtpnm = dv1[0]["mtp_nm"].ToString().Trim();
                    e.Row.Cells[14].Text = mtpnm;
                }
                else
                {
                    e.Row.Cells[14].Text = "（資料有誤)";
                }


                // 海外郵寄註記
                string fgmosea = e.Row.Cells[15].Text.Trim();
                switch (fgmosea)
                {
                    case "0":
                        e.Row.Cells[15].Text = "國內";
                        break;
                    case "1":
                        e.Row.Cells[15].Text = "<font color='Red'>國外</font>";
                        break;
                    default:
                        e.Row.Cells[15].Text = "國內";
                        break;
                }
            }
        }

        protected void GridView2OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region 刪除動作
            if (e.CommandName == "LKdel")
            {
                // 抓出 PK 值, 以稍後做 刪除動作
                string strSyscd = "C2";
                string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
                string strORItem = e.CommandArgument.ToString().Trim();
                //Response.Write("strsyscd= " + strsyscd + ", ");
                //Response.Write("strcontno= " + strcontno + ", ");
                //Response.Write("strORItem= " + strORItem + "<br>");


                // 步驟一：進行刪除動作
                // 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
                try
                {
                    myOR.DelC2_or(strSyscd, strORItem, strContNo);
                    // 以 Javascript 的 window.alert()  來告知訊息
                    LiteralControl litAlert = new LiteralControl();
                    litAlert.Text = "<script language=javascript>alert(\"刪除成功\");</script>";
                    Page.Controls.Add(litAlert);
                }
                catch (System.Data.SqlClient.SqlException ex2)
                {
                    Response.Write(ex2.Message + "<br>");

                    // 以 Javascript 的 window.alert()  來告知訊息
                    LiteralControl litAlert = new LiteralControl();
                    litAlert.Text = "<script language=javascript>alert(\"刪除失敗\");</script>";
                    Page.Controls.Add(litAlert);
                }


                // 步驟二: 抓出目前最大雜收人序號, 以判斷是否要做 or_oritem 之更新動作
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds6 = myOR.SelectMaxC2_or();
                DataView dv6 = ds6.Tables["c2_or"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr6 = "1=1";
                rowfilterstr6 = rowfilterstr6 + " AND or_contno='" + strContNo + "'";
                dv6.RowFilter = rowfilterstr6;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
                //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

                // 抓出最新的 雜誌收件人序號
                string MaxORItem = "01";
                int intMaxORItem = Convert.ToInt16(MaxORItem);
                if (dv6.Count > 0)
                {
                    MaxORItem = dv6[0]["MaxORItem"].ToString();
                    //Response.Write("MaxORItem= " + MaxORItem + "<br>");
                    intMaxORItem = Convert.ToInt16(MaxORItem);
                    //Response.Write("intMaxORItem= " + intMaxORItem + "<br>");

                    // 步驟三: 更新之後的序號之處理
                    int intCurrentORItem = Convert.ToInt16(strORItem);
                    if (strORItem == MaxORItem)
                    {
                        //Response.Write("do nothing...直接執行刪除資料即可<br>");
                    }
                    else
                    {
                        //Response.Write("處理更新事宜<br>");


                        // 抓出 按下刪除之下一序號, 做為 for loop 起始值
                        int intNextORItem = intCurrentORItem + 1;
                        //Response.Write("intNextORItem= " + intNextORItem + "<br>");

                        // 抓出逐行落版資料, 做更新其落版序號之動作
                        for (int i = intNextORItem; i <= intMaxORItem; i++)
                        {
                            string stri = Convert.ToString(i);
                            if (stri.Length < 2)
                                stri = "0" + stri;
                            //Response.Write("stri= " + stri + "<br>");

                            // 抓出逐行落版資料之 PK
                            // 使用 DataSet 方法, 並指定使用的 table 名稱
                            DataSet ds5 = myOR.SelectC2_or();
                            DataView dv5 = ds5.Tables["c2_or"].DefaultView;

                            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                            string rowfilterstr5 = "1=1";
                            rowfilterstr5 = rowfilterstr5 + " AND  or_syscd='C2' ";
                            rowfilterstr5 = rowfilterstr5 + " AND  or_contno='" + strContNo + "'";
                            dv5.RowFilter = rowfilterstr5;

                            // 檢查並輸出 最後 Row Filter 的結果
                            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
                            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

                            if (dv5.Count > 0)
                            {
                                string iSyscd = "C2";
                                string iContNo = dv5[0]["or_contno"].ToString();
                                string iORItem = dv5[0]["or_oritem"].ToString();
                                //Response.Write("iSyscd= " + iSyscd + ", ");
                                //Response.Write("iContNo= " + iContNo + ", ");
                                //Response.Write("iORItem= " + iORItem + "<br>");

                                int intNewORItem = i - 1;
                                string strNewORItem = Convert.ToString(intNewORItem);
                                if (strNewORItem.Length < 2)
                                    strNewORItem = "0" + strNewORItem;
                                //Response.Write("strNewORItem= " + strNewORItem + "<br>");

                                try
                                {
                                    myOR.UpdateC2_or(strSyscd, strContNo, strNewORItem, stri);
                                }
                                catch (System.Data.SqlClient.SqlException ex4)
                                {
                                    Response.Write(ex4.Message + "<br>");
                                }

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


                // Refresh Page
                BindGrid2();

                // 將畫面上殘餘資料清除為空
                ClearForm();

                // 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
                this.btnModify.Visible = false;
                this.btnSave.Visible = true;
                this.btnLoadData.Visible = true;

                // 若刪除所有資料時, 則不應再顯示 Datagrid2()
                //Response.Write("Datagrid2.Items.Count= " + Datagrid2.Items.Count + "<br>");
                if (GridView2.Rows.Count == 1)
                {
                    InitialData();
                }

            }

            #endregion

            #region 修改動作
            if (e.CommandName == "LKedit")
            {
                // 抓出 PK 值, 將相關資料載入 新增Form 裡
                string strsyscd = "C2";
                string strcontno = Context.Request.QueryString["contno"].ToString().Trim();
                string strORItem = e.CommandArgument.ToString();
                //Response.Write("strsyscd= " + strsyscd + ", ");
                //Response.Write("strcontno= " + strcontno + ", ");
                ///Response.Write("strORItem= " + strORItem + "<br>");

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds5 = myOR.SelectC2_or();
                DataView dv5 = ds5.Tables["c2_or"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr5 = "1=1";
                rowfilterstr5 = rowfilterstr5 + " AND or_syscd='" + strsyscd + "'";
                rowfilterstr5 = rowfilterstr5 + " AND or_contno='" + strcontno + "'";
                rowfilterstr5 = rowfilterstr5 + " AND or_oritem='" + strORItem + "'";
                dv5.RowFilter = rowfilterstr5;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
                //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

                // 載入資料			
                if (dv5.Count > 0)
                {
                    // 將序號顯示在 lblORItem; 否則修改時無法抓出其序號
                    this.lblORItem.Visible = true;
                    this.lblORItem.Text = strORItem;

                    // 顯示其相關資料
                    this.tbxORContNo.Text = strcontno;
                    this.tbxORMfrIName.Text = dv5[0]["or_inm"].ToString().Trim();
                    this.tbxORName.Text = dv5[0]["or_nm"].ToString().Trim();
                    this.tbxORJobTitle.Text = dv5[0]["or_jbti"].ToString().Trim();
                    this.tbxORZipcode.Text = dv5[0]["or_zip"].ToString().Trim();
                    this.tbxORAddr.Text = dv5[0]["or_addr"].ToString().Trim();
                    this.tbxORTel.Text = dv5[0]["or_tel"].ToString().Trim();
                    this.tbxORFax.Text = dv5[0]["or_fax"].ToString().Trim();
                    this.tbxORCell.Text = dv5[0]["or_cell"].ToString().Trim();
                    this.tbxOREmail.Text = dv5[0]["or_email"].ToString().Trim();
                    this.tbxORPubCount.Text = dv5[0]["or_pubcnt"].ToString().Trim();
                    this.tbxORUnPubCount.Text = dv5[0]["or_unpubcnt"].ToString().Trim();
                    // 下述 coding 無法抓出正確之 下拉式選單的預選值
                    //this.ddlORmtpcd.SelectedItem.Value = dv5[0]["or_mtpcd"].ToString().Trim();
                    //this.ddlORfgmosea.SelectedItem.Value = dv5[0]["or_fgmosea"].ToString().Trim();

                    // 郵寄類別代碼
                    string mtpcd = dv5[0]["or_mtpcd"].ToString().Trim();
                    switch (mtpcd)
                    {
                        case "11":
                            this.ddlORmtpcd.SelectedIndex = 0;
                            break;
                        case "12":
                            this.ddlORmtpcd.SelectedIndex = 1;
                            break;
                        case "19":
                            this.ddlORmtpcd.SelectedIndex = 2;
                            break;
                        case "21":
                            this.ddlORmtpcd.SelectedIndex = 3;
                            break;
                        case "22":
                            this.ddlORmtpcd.SelectedIndex = 4;
                            break;
                        case "23":
                            this.ddlORmtpcd.SelectedIndex = 5;
                            break;
                        case "24":
                            this.ddlORmtpcd.SelectedIndex = 6;
                            break;
                        case "26":
                            this.ddlORmtpcd.SelectedIndex = 7;
                            break;
                        case "27":
                            this.ddlORmtpcd.SelectedIndex = 8;
                            break;
                        case "28":
                            this.ddlORmtpcd.SelectedIndex = 9;
                            break;
                        case "29":
                            this.ddlORmtpcd.SelectedIndex = 10;
                            break;
                        default:
                            this.ddlORmtpcd.SelectedIndex = 0;
                            break;
                    }

                    // 海外郵寄註記
                    string fgmosea = dv5[0]["or_fgmosea"].ToString().Trim();
                    switch (fgmosea)
                    {
                        case "0":
                            this.ddlORfgmosea.SelectedIndex = 0;
                            break;
                        case "1":
                            this.ddlORfgmosea.SelectedIndex = 1;
                            break;
                        default:
                            this.ddlORfgmosea.SelectedIndex = 0;
                            break;
                    }

                }

                // 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
                this.btnModify.Visible = true;
                this.btnSave.Visible = false;
                this.btnLoadData.Visible = false;

                // 結束 if(e.CommandName == "Select")
            
            }
            #endregion
                
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 新增入資料庫
            InsertDB();


            // Refresh Datagrid2
            GridView2.Visible = true;
            BindGrid2();
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            // 執行 修改動作
            ModifyDB();

            // Refresh Page
            BindGrid2();

            // 修改成功後, 將 儲存修改按鈕隱藏起來
            this.btnModify.Visible = false;
            this.btnSave.Visible = true;
            this.btnLoadData.Visible = true;

            // 將畫面上殘餘資料清除為空
            ClearForm();
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            InitialData();
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.tbxORPubCount.Text = "0";
            this.tbxORUnPubCount.Text = "0";
        }


        // 修改資料 from DB Table
        private void ModifyDB()
        {
            // 顯示欲修改之 雜誌收件人序號
            this.lblORItem.Visible = true;

            // 抓出 畫面上的值
            string strsyscd = "C2";
            string strcontno = this.tbxORContNo.Text.ToString().Trim();
            // 抓出其 收件人序號 (由 DataGrid1_ItemCommand() 帶出此值到 lblORItem )
            string strORItem = this.lblORItem.Text.ToString();
            string strMfrinm = this.tbxORMfrIName.Text.ToString().Trim();
            string strORName = this.tbxORName.Text.ToString().Trim();
            string strORJobTitle = this.tbxORJobTitle.Text.ToString().Trim();
            string strORZipcode = this.tbxORZipcode.Text.ToString().Trim();
            string strORAddr = this.tbxORAddr.Text.ToString().Trim();
            string strORTel = this.tbxORTel.Text.ToString().Trim();
            string strORFax = this.tbxORFax.Text.ToString().Trim();
            string strORCell = this.tbxORCell.Text.ToString().Trim();
            string strOREmail = this.tbxOREmail.Text.ToString().Trim();
            string strORPubCount = this.tbxORPubCount.Text.ToString().Trim();
            string strORUnPubCount = this.tbxORUnPubCount.Text.ToString().Trim();
            string strORmtpcd = this.ddlORmtpcd.SelectedItem.Value.ToString().Trim();
            string strORfgmosea = this.ddlORfgmosea.SelectedItem.Value.ToString().Trim();
            //Response.Write("strimseq= " + strimseq + "<br>");
            //Response.Write("strIMName= " + strIMName + "<br>");
            //Response.Write("strORmtpcd= " + strORmtpcd + "<br>");
            //Response.Write("strORfgmosea= " + strORfgmosea + "<br>");

            // 確認執行 sqlSelectCommand1 成功
            bool ResultFlag3 = false;
            try
            {
                myOR.UpdateC2_orALL(strMfrinm, strORName, strORJobTitle, strORZipcode, strORAddr, strORTel, strORFax, strORCell, strOREmail, strORPubCount, strORUnPubCount, strORmtpcd, strORfgmosea, strsyscd, strcontno, strORItem);
                ResultFlag3 = true;
            }
            catch (System.Data.SqlClient.SqlException ex3)
            {
                Response.Write(ex3.Message + "<br>");
                ResultFlag3 = false;
            }

            // 輸出執行結果
            if (ResultFlag3)
            {
                //Response.Write("修改成功!<br>");

                // 以 Javascript 的 window.alert()  來告知訊息
                LiteralControl litAlert = new LiteralControl();
                litAlert.Text = "<script language=javascript>alert(\"修改成功\");</script>";
                Page.Controls.Add(litAlert);
            }
            else
            {
                //Response.Write("修改失敗!<br>");

                // 以 Javascript 的 window.alert()  來告知訊息
                LiteralControl litAlert = new LiteralControl();
                litAlert.Text = "<script language=javascript>alert(\"修改失敗\");</script>";
                Page.Controls.Add(litAlert);
            }

        }


        private void InsertDB()
        {
            // 抓出 畫面上的值
            string strSyscd = "C2";
            string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
            string strMfrinm = this.tbxORMfrIName.Text.ToString().Trim();
            string strORName = this.tbxORName.Text.ToString().Trim();
            string strORJobTitle = this.tbxORJobTitle.Text.ToString().Trim();
            string strORZipcode = this.tbxORZipcode.Text.ToString().Trim();
            string strORAddr = this.tbxORAddr.Text.ToString().Trim();
            string strORTel = this.tbxORTel.Text.ToString().Trim();
            string strORFax = this.tbxORFax.Text.ToString().Trim();
            string strORCell = this.tbxORCell.Text.ToString().Trim();
            string strOREmail = this.tbxOREmail.Text.ToString().Trim();
            string strPubCount = "0";
            if (this.tbxORPubCount.Text.ToString().Trim() != "")
            {
                strPubCount = this.tbxORPubCount.Text.ToString().Trim();
            }
            string strUnPubCount = "0";
            if (this.tbxORUnPubCount.Text.ToString().Trim() != "")
            {
                strUnPubCount = this.tbxORUnPubCount.Text.ToString().Trim();
            }

            string strORmtpcd = this.ddlORmtpcd.SelectedItem.Value.ToString().Trim();
            string strORfgmosea = this.ddlORfgmosea.SelectedItem.Value.ToString().Trim();
            //Response.Write("strContNo= " + strContNo + "<br>");
            //Response.Write("strMfrinm= " + strMfrinm + "<br>");
            //Response.Write("strORmtpcd= " + strORmtpcd + "<br>");
            //Response.Write("strORfgmosea= " + strORfgmosea + "<br>");


            // 抓出新序號, 先抓出目前最大的 im_imseq+1
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds6 = myOR.SelectMaxC2_or();
            DataView dv6 = ds6.Tables["c2_or"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr6 = "1=1";
            rowfilterstr6 = rowfilterstr6 + " AND or_contno='" + strContNo + "'";
            dv6.RowFilter = rowfilterstr6;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
            //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

            // 抓出最新的 發票廠商收件人序號
            string strORItem = "01";
            if (dv6.Count > 0)
            {
                strORItem = Convert.ToString(Convert.ToInt32(dv6[0][0].ToString().Trim()) + 1);
                if (strORItem.Length < 2)
                    strORItem = "0" + strORItem;
            }
            else
            {
                strORItem = "01";
            }
            //Response.Write("strORItem= " + strORItem + "<br>");

            // 確認執行 sqlSelectCommand1 成功
            bool ResultFlag1 = false;
            try
            {
                myOR.InsertC2_or(strSyscd, strContNo, strORItem, strMfrinm, strORName, strORJobTitle, strORZipcode, strORAddr, strORTel, strORFax, strORCell, strOREmail, strPubCount, strUnPubCount, strORmtpcd, strORfgmosea);
                ResultFlag1 = true;
            }
            catch (System.Data.SqlClient.SqlException ex1)
            {
                Response.Write(ex1.Message + "<br>");
                ResultFlag1 = false;
            }

            // 輸出執行結果
            if (ResultFlag1)
            {
                //Response.Write("新增成功!<br>");

                // 以 Javascript 的 window.alert()  來告知訊息
                LiteralControl litAlert = new LiteralControl();
                litAlert.Text = "<script language=javascript>alert(\"新增成功\");</script>";
                Page.Controls.Add(litAlert);

                // 以 Javascript 的 window.close() 來告知訊息
                //LiteralControl litCloseWin = new LiteralControl();
                //litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
                //Page.Controls.Add(litCloseWin);
            }
            else
            {
                //Response.Write("新增失敗!<br>");

                // 以 Javascript 的 window.alert()  來告知訊息
                LiteralControl litAlert = new LiteralControl();
                litAlert.Text = "<script language=javascript>alert(\"新增失敗\");</script>";
                Page.Controls.Add(litAlert);

                // 以 Javascript 的 window.close() 來告知訊息
                //LiteralControl litCloseWin = new LiteralControl();
                //litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
                //Page.Controls.Add(litCloseWin);
            }
            // 將畫面上殘餘資料清除為空
            ClearForm();

        }


        private void ClearForm()
        {
            // 將畫面上殘餘資料清除為空
            // 注意: 下拉式選單 要使用 SelectedIndex 的技巧
            this.lblORItem.Text = "";
            //this.tbxORContNo.Text = "";
            this.tbxORMfrIName.Text = "";
            this.tbxORName.Text = "";
            this.tbxORJobTitle.Text = "";
            this.tbxORZipcode.Text = "";
            this.tbxORAddr.Text = "";
            this.tbxORTel.Text = "";
            this.tbxORFax.Text = "";
            this.tbxORCell.Text = "";
            this.tbxOREmail.Text = "";
            this.tbxORPubCount.Text = "";
            this.tbxORUnPubCount.Text = "";
            this.ddlORmtpcd.SelectedIndex = 0;
            this.ddlORfgmosea.SelectedIndex = 0;
        }
    }
}
