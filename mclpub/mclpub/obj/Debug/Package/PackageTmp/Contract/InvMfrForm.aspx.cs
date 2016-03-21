using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class InvMfrForm : System.Web.UI.Page
    {
        InvMfrForm_DB myInv = new InvMfrForm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 抓預設資料 (廠商客戶資料) - 新增Form
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
                this.lblImSeq.Visible = false;

                BindGrid2();

            }
        }

        // 給預設資料 - 新增Form
        private void InitialData()
        {
            // 顯示下拉式選單 程式名稱的 DB 值
            DataTable dt = myInv.SelectFgitri();
            ddlIMfgITRI.DataSource = dt;
            ddlIMfgITRI.DataTextField = "fgitri_name";
            ddlIMfgITRI.DataValueField = "fgitri_fgitri";
            ddlIMfgITRI.DataBind();


            // 給下拉式選單 預選值
            this.ddlIMInvtp.ClearSelection();
            this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
            this.ddlIMTaxtp.ClearSelection();
            ddlIMTaxtp.SelectedIndex = 0;
            this.ddlIMfgITRI.ClearSelection();
            ddlIMfgITRI.SelectedIndex = 0;


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
                DataSet ds2 = myInv.SelectCust();
                DataView dv2 = ds2.Tables["cust"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr2 = "1=1";
                rowfilterstr2 = rowfilterstr2 + " AND cust_custno='" + custno + "'";
                dv2.RowFilter = rowfilterstr2;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
                //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

                if (dv2.Count > 0)
                {
                    // 抓出 客戶相關資料
                    string custnm = "";
                    string custjbti = "";
                    string custtel = "";
                    string custfax = "";
                    string custcell = "";
                    string custemail = "";
                    string mfrno = "";
                    custnm = dv2[0]["cust_nm"].ToString().Trim();
                    custjbti = dv2[0]["cust_jbti"].ToString().Trim();
                    custtel = dv2[0]["cust_tel"].ToString().Trim();
                    custfax = dv2[0]["cust_fax"].ToString().Trim();
                    custcell = dv2[0]["cust_cell"].ToString().Trim();
                    custemail = dv2[0]["cust_email"].ToString().Trim();
                    mfrno = dv2[0]["cust_mfrno"].ToString().Trim();
                    //Response.Write("mfrno= " + mfrno + "<br>");

                    if (custnm != "")
                        this.tbxIMName.Text = custnm;
                    if (custjbti != "")
                        this.tbxIMJobTitle.Text = custjbti;
                    if (custtel != "")
                        this.tbxIMTel.Text = custtel;
                    if (custfax != "")
                        this.tbxIMFax.Text = custfax;
                    if (custcell != "")
                        this.tbxIMCell.Text = custcell;
                    if (custemail != "")
                        this.tbxIMEmail.Text = custemail;

                    // 顯示 客戶編號 (not visible)
                    this.lblCustNo.Text = custno;


                    // 顯示廠商相關資料
                    if (mfrno != "")
                    {
                        // 顯示 廠商統編 (not visible)
                        this.lblMfrNo.Text = mfrno;

                        this.tbxIMMfrNo.Text = mfrno;
                        // 使用 DataSet 方法, 並指定使用的 table 名稱
                        DataSet ds3 = myInv.SelectMfr();
                        DataView dv3 = ds3.Tables["mfr"].DefaultView;

                        // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                        string rowfilterstr3 = "1=1";
                        rowfilterstr3 = rowfilterstr3 + " AND mfr_mfrno='" + mfrno + "'";
                        dv3.RowFilter = rowfilterstr3;

                        // 檢查並輸出 最後 Row Filter 的結果
                        //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
                        //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

                        if (dv3.Count > 0)
                        {
                            // 抓出 廠商相關資料
                            string mfrinm = "";
                            string mfrzipcode = "";
                            string mfraddr = "";
                            mfrinm = dv3[0]["mfr_inm"].ToString().Trim();
                            mfrzipcode = dv3[0]["mfr_izip"].ToString().Trim();
                            mfraddr = dv3[0]["mfr_iaddr"].ToString().Trim();

                            if (mfrzipcode != "")
                                this.tbxIMZipcode.Text = mfrzipcode;
                            if (mfraddr != "")
                                this.tbxIMAddr.Text = mfraddr;

                            // 顯示廠商發票名稱及統編
                            this.lblMfrNo.Text = mfrno;
                            this.lblMfrInfo.Text = "預設廠商：" + mfrinm + " (" + mfrno + ")";
                        }
                    }
                }
            }
        }


        // 載入歷史資料
        private void BindGrid1()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds4 = myInv.SelectInvmfr();
            DataView dv4 = ds4.Tables["invmfr"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr4 = "1=1";

            string old_contno = "";
            if (Context.Request.QueryString["old_contno"].ToString().Trim() != "")
            {
                old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
                rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + old_contno + "'";
            }
            else
            {
                old_contno = "0";
            }
            dv4.RowFilter = rowfilterstr4;
            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
            //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv4.Count > 0)
            {
                GridView1.DataSource = dv4;
                GridView1.DataBind();
            }

        }


        protected void GridView1OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 發票類別
                string invcd = e.Row.Cells[11].Text.Trim();
                switch (invcd)
                {
                    case "2":
                        e.Row.Cells[11].Text = "二聯";
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.OrangeRed;
                        break;
                    case "3":
                        e.Row.Cells[11].Text = "三聯";
                        break;
                    case "4":
                        e.Row.Cells[11].Text = "其他";
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.Green;
                        break;
                    case "9":
                        e.Row.Cells[11].Text = "不清楚";
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        e.Row.Cells[11].Text = "三聯";
                        break;
                }

                // 發票課稅別
                string taxtp = e.Row.Cells[12].Text.Trim();
                switch (taxtp)
                {
                    case "1":
                        e.Row.Cells[12].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[12].Text = "零稅";
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.OrangeRed;
                        break;
                    case "3":
                        e.Row.Cells[12].Text = "免稅";
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Green;
                        break;
                    case "9":
                        e.Row.Cells[12].Text = "不清楚";
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        e.Row.Cells[12].Text = "應稅5%";
                        break;
                }

                // 院所內註記
                string fgItri = e.Row.Cells[13].Text.Trim();
                switch (fgItri)
                {
                    case "":
                        e.Row.Cells[13].Text = "否";
                        break;
                    case "06":
                        e.Row.Cells[13].Text = "所內";
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.OrangeRed;
                        break;
                    case "07":
                        e.Row.Cells[13].Text = "院內";
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.Blue;
                        break;
                    default:
                        e.Row.Cells[13].Text = "否";
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
                string strimseq = e.CommandArgument.ToString();
                //Response.Write("strsyscd= " + strsyscd + ", ");
                //Response.Write("strcontno= " + strcontno + ", ");
                //Response.Write("strimseq= " + strimseq + "<br>");


                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds4 = myInv.SelectInvmfr();
                DataView dv4 = ds4.Tables["invmfr"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr4 = "1=1";
                rowfilterstr4 = rowfilterstr4 + " AND im_syscd='" + strsyscd + "'";
                rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strcontno + "'";
                rowfilterstr4 = rowfilterstr4 + " AND im_imseq='" + strimseq + "'";
                dv4.RowFilter = rowfilterstr4;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                // 載入資料
                if (dv4.Count > 0)
                {
                    // 將序號顯示在 lblIMSeq; 否則修改時無法抓出其序號
                    this.lblImSeq.Visible = true;
                    this.lblImSeq.Text = strimseq;

                    // 顯示其相關資料
                    this.tbxIMContNo.Text = strcontno;
                    this.tbxIMMfrNo.Text = dv4[0]["im_mfrno"].ToString().Trim();
                    this.tbxIMName.Text = dv4[0]["im_nm"].ToString().Trim();
                    this.tbxIMJobTitle.Text = dv4[0]["im_jbti"].ToString().Trim();
                    this.tbxIMZipcode.Text = dv4[0]["im_zip"].ToString().Trim();
                    this.tbxIMAddr.Text = dv4[0]["im_addr"].ToString().Trim();
                    this.tbxIMTel.Text = dv4[0]["im_tel"].ToString().Trim();
                    this.tbxIMFax.Text = dv4[0]["im_fax"].ToString().Trim();
                    this.tbxIMCell.Text = dv4[0]["im_cell"].ToString().Trim();
                    this.tbxIMEmail.Text = dv4[0]["im_email"].ToString().Trim();
                    // 下述 coding 無法抓出正確之 下拉式選單的預選值
                    //this.ddlIMInvtp.ClearSelection();
                    //this.ddlIMInvtp.SelectedItem.Value = dv4[0]["im_invcd"].ToString().Trim();
                    //this.ddlIMTaxtp.ClearSelection();
                    //this.ddlIMTaxtp.SelectedItem.Value = dv4[0]["im_taxtp"].ToString().Trim();
                    //this.ddlIMfgITRI.ClearSelection();
                    //this.ddlIMfgITRI.SelectedItem.Value = dv4[0]["im_fgitri"].ToString().Trim();

                    // 發票類別代碼
                    this.ddlIMInvtp.ClearSelection();
                    string invcd = dv4[0]["im_invcd"].ToString().Trim();
                    switch (invcd)
                    {
                        case "2":
                            this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
                            break;
                        case "3":
                            this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
                            break;
                        case "4":
                            this.ddlIMInvtp.Items.FindByValue("4").Selected = true;
                            break;
                        case "9":
                            this.ddlIMInvtp.Items.FindByValue("9").Selected = true;
                            break;
                        default:
                            this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
                            break;
                    }

                    // 發票課稅別
                    this.ddlIMTaxtp.ClearSelection();
                    string taxtp = dv4[0]["im_taxtp"].ToString().Trim();
                    switch (taxtp)
                    {
                        case "1":
                            this.ddlIMTaxtp.SelectedIndex = 0;
                            break;
                        case "2":
                            this.ddlIMTaxtp.SelectedIndex = 1;
                            break;
                        case "3":
                            this.ddlIMTaxtp.SelectedIndex = 2;
                            break;
                        case "9":
                            this.ddlIMTaxtp.SelectedIndex = 3;
                            break;
                        default:
                            this.ddlIMTaxtp.SelectedIndex = 0;
                            break;
                    }

                    // 院所內註記
                    this.ddlIMfgITRI.ClearSelection();
                    string fgitri = dv4[0]["im_fgitri"].ToString().Trim();
                    switch (fgitri)
                    {
                        case "":
                            this.ddlIMfgITRI.SelectedIndex = 0;
                            break;
                        case "06":
                            this.ddlIMfgITRI.SelectedIndex = 1;
                            break;
                        case "07":
                            this.ddlIMfgITRI.SelectedIndex = 2;
                            break;
                        default:
                            this.ddlIMfgITRI.SelectedIndex = 0;
                            break;
                    }
                }

                // 新增成功後, 將 儲存修改按鈕隱藏起來
                this.btnModify.Visible = false;
                this.btnSave.Visible = true;
            }
            #endregion
        }


        // 載入 已新增之資料
        private void BindGrid2()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds4 = myInv.SelectInvmfr();
            DataView dv4 = ds4.Tables["invmfr"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr4 = "1=1";

            string contno = "";
            if (Context.Request.QueryString["contno"].ToString().Trim() != "")
            {
                contno = Context.Request.QueryString["contno"].ToString().Trim();
                rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + contno + "'";
            }
            dv4.RowFilter = rowfilterstr4;
            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
            //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv4.Count > 0)
            {
                GridView2.DataSource = dv4;
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
                // 發票類別
                string invcd = e.Row.Cells[12].Text.Trim();
                switch (invcd)
                {
                    case "2":
                        e.Row.Cells[12].Text = "二聯";
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.OrangeRed;
                        break;
                    case "3":
                        e.Row.Cells[12].Text = "三聯";
                        break;
                    case "4":
                        e.Row.Cells[12].Text = "其他";
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Green;
                        break;
                    case "9":
                        e.Row.Cells[12].Text = "不清楚";
                        e.Row.Cells[12].ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        e.Row.Cells[12].Text = "三聯";
                        break;
                }

                // 發票課稅別
                string taxtp = e.Row.Cells[13].Text.Trim();
                switch (taxtp)
                {
                    case "1":
                        e.Row.Cells[13].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[13].Text = "零稅";
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.OrangeRed;
                        break;
                    case "3":
                        e.Row.Cells[13].Text = "免稅";
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.Green;
                        break;
                    case "9":
                        e.Row.Cells[13].Text = "不清楚";
                        e.Row.Cells[13].ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        e.Row.Cells[13].Text = "應稅5%";
                        break;
                }

                // 院所內註記
                string fgItri = e.Row.Cells[14].Text.Trim();
                switch (fgItri)
                {
                    case "":
                        e.Row.Cells[14].Text = "否";
                        break;
                    case "06":
                        e.Row.Cells[14].Text = "所內";
                        e.Row.Cells[14].ForeColor = System.Drawing.Color.OrangeRed;
                        break;
                    case "07":
                        e.Row.Cells[14].Text = "院內";
                        e.Row.Cells[14].ForeColor = System.Drawing.Color.Blue;
                        break;
                    default:
                        e.Row.Cells[14].Text = "否";
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
                string strIMSeq = e.CommandArgument.ToString();
                //Response.Write("strSyscd= " + strSyscd + ", ");
                //Response.Write("strContNo= " + strContNo + ", ");
                //Response.Write("strIMSeq= " + strIMSeq + "<br>");


                // 步驟一: 檢查此 IMSeq 是否有落版資料使用中, 若是, 不允許修改
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds6 = myInv.SelectC2_pub();
                DataView dv6 = ds6.Tables["c2_pub"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr6 = "1=1";
                rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strSyscd + "'";
                rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strContNo + "'";
                rowfilterstr6 = rowfilterstr6 + " AND im_imseq='" + strIMSeq + "'";
                dv6.RowFilter = rowfilterstr6;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
                //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

                // 若已被落版使用, 給予警告訊息
                if (dv6.Count > 0)
                {
                    // 以 Javascript 的 window.alert()  來告知訊息
                    LiteralControl litAlert1 = new LiteralControl();
                    litAlert1.Text = "<script language=javascript>alert(\"刪除失敗：本發票廠商已被落版使用, 無法刪除本筆\");</script>";
                    Page.Controls.Add(litAlert1);
                }
                // 若尚未被落版使用, 允許刪除
                // 步驟二: 進行刪除動作
                else
                {
                    // 步驟一：進行刪除動作
                    // 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
                    try
                    {
                        myInv.DelInvmfr(strSyscd, strContNo, strIMSeq);
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
                    DataSet ds5 = myInv.SelectMaxInvmfr();
                    DataView dv5 = ds5.Tables["invmfr"].DefaultView;

                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                    string rowfilterstr5 = "1=1";
                    rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strContNo + "'";
                    dv5.RowFilter = rowfilterstr5;

                    // 檢查並輸出 最後 Row Filter 的結果
                    //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
                    //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

                    // 抓出最新的 雜誌收件人序號
                    string MaxIMSeq = "01";
                    int intMaxIMSeq = Convert.ToInt16(MaxIMSeq);
                    if (dv5.Count > 0)
                    {
                        MaxIMSeq = dv5[0]["MaxIMSeq"].ToString();
                        //Response.Write("MaxIMSeq= " + MaxIMSeq + "<br>");
                        intMaxIMSeq = Convert.ToInt16(MaxIMSeq);
                        //Response.Write("intMaxIMSeq= " + intMaxIMSeq + "<br>");

                        // 步驟三: 更新之後的序號之處理
                        int intCurrentIMSeq = Convert.ToInt16(strIMSeq);
                        if (strIMSeq == MaxIMSeq)
                        {
                            //Response.Write("do nothing...直接執行刪除資料即可<br>");
                        }
                        else
                        {
                            //Response.Write("處理更新事宜<br>");


                            // 抓出 按下刪除之下一序號, 做為 for loop 起始值
                            int intNextIMSeq = intCurrentIMSeq + 1;
                            //Response.Write("intNextIMSeq= " + intNextIMSeq + "<br>");

                            // 抓出逐行落版資料, 做更新其落版序號之動作
                            for (int i = intNextIMSeq; i <= intMaxIMSeq; i++)
                            {
                                string stri = Convert.ToString(i);
                                if (stri.Length < 2)
                                    stri = "0" + stri;
                                //Response.Write("stri= " + stri + "<br>");

                                // 抓出逐行落版資料之 PK
                                // 使用 DataSet 方法, 並指定使用的 table 名稱
                                DataSet ds4 = myInv.SelectInvmfr();
                                DataView dv4 = ds4.Tables["invmfr"].DefaultView;

                                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                                string rowfilterstr4 = "1=1";
                                rowfilterstr4 = rowfilterstr4 + " AND  im_syscd='C2' ";
                                rowfilterstr4 = rowfilterstr4 + " AND  im_contno='" + strContNo + "'";
                                dv4.RowFilter = rowfilterstr4;

                                // 檢查並輸出 最後 Row Filter 的結果
                                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                                if (dv4.Count > 0)
                                {
                                    string iSyscd = "C2";
                                    string iContNo = dv4[0]["im_contno"].ToString();
                                    string iIMSeq = dv4[0]["im_imseq"].ToString();
                                    //Response.Write("iSyscd= " + iSyscd + ", ");
                                    //Response.Write("iContNo= " + iContNo + ", ");
                                    //Response.Write("iIMSeq= " + iIMSeq + "<br>");

                                    int intNewIMSeq = i - 1;
                                    string strNewIMSeq = Convert.ToString(intNewIMSeq);
                                    if (strNewIMSeq.Length < 2)
                                        strNewIMSeq = "0" + strNewIMSeq;
                                    //Response.Write("strNewIMSeq= " + strNewIMSeq + "<br>");


                                    // 執行更新動作
                                    // 執行 將值塞入 sqlCommand4.Parameters 中, 以執行 新增入資料庫
                                    //Response.Write(this.sqlCommand4.CommandText);
                                    try
                                    {
                                        myInv.UpdateInvmfr2(strSyscd, strContNo, strNewIMSeq, stri);
                                    }
                                    catch (System.Data.SqlClient.SqlException ex4)
                                    {
                                        Response.Write(ex4.Message + "<br>");
                                    }

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

                    // 給預設資料 - 新增Form
                    //Response.Write("Datagrid2.Items.Count= " + Datagrid2.Items.Count + "<br>");
                    if (GridView2.Rows.Count == 1)
                    {
                        InitialData();
                    }
                }

                // 結束 if(e.CommandName == "Delete")
            }

            #endregion

            #region 修改動作
            if (e.CommandName == "LKedit")
            {
                // 按下 修改 按鈕的處理
                // 抓出 PK 值, 將相關資料載入 新增Form 裡
                string strSyscd = "C2";
                string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
                string strIMSeq = e.CommandArgument.ToString();
                //Response.Write("strsyscd= " + strsyscd + ", ");
                //Response.Write("strcontno= " + strcontno + ", ");
                ///Response.Write("strimseq= " + strimseq + "<br>");


                // 步驟一: 檢查此 IMSeq 是否有落版資料使用中, 若是, 不允許修改
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds6 = myInv.SelectC2_pub();
                DataView dv6 = ds6.Tables["c2_pub"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr6 = "1=1";
                rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strSyscd + "'";
                rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strContNo + "'";
                rowfilterstr6 = rowfilterstr6 + " AND im_imseq='" + strIMSeq + "'";
                dv6.RowFilter = rowfilterstr6;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
                //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

                // 若已被落版使用, 給予警告訊息
                if (dv6.Count > 0)
                {
                    // 以 Javascript 的 window.alert()  來告知訊息
                    LiteralControl litAlert1 = new LiteralControl();
                    litAlert1.Text = "<script language=javascript>alert(\"請注意：本發票廠商已被落版使用, \\n請勿修改發廠收件人姓名, 造成舊資料有誤！(其他地址等資料可修改）\");</script>";
                    Page.Controls.Add(litAlert1);
                    this.tbxIMName.Enabled = false;
                }
                else
                {
                    this.tbxIMName.Enabled = true;
                }

                // 步驟二: 進行修改動作
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds4 = myInv.SelectInvmfr();
                DataView dv4 = ds4.Tables["invmfr"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr4 = "1=1";
                rowfilterstr4 = rowfilterstr4 + " AND im_syscd='" + strSyscd + "'";
                rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strContNo + "'";
                rowfilterstr4 = rowfilterstr4 + " AND im_imseq='" + strIMSeq + "'";
                dv4.RowFilter = rowfilterstr4;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                // 載入資料
                if (dv4.Count > 0)
                {
                    // 將序號顯示在 lblIMSeq; 否則修改時無法抓出其序號
                    this.lblImSeq.Visible = true;
                    this.lblImSeq.Text = strIMSeq;

                    // 顯示其相關資料
                    this.tbxIMContNo.Text = strContNo;
                    this.tbxIMMfrNo.Text = dv4[0]["im_mfrno"].ToString().Trim();
                    this.tbxIMName.Text = dv4[0]["im_nm"].ToString().Trim();
                    this.tbxIMJobTitle.Text = dv4[0]["im_jbti"].ToString().Trim();
                    this.tbxIMZipcode.Text = dv4[0]["im_zip"].ToString().Trim();
                    this.tbxIMAddr.Text = dv4[0]["im_addr"].ToString().Trim();
                    this.tbxIMTel.Text = dv4[0]["im_tel"].ToString().Trim();
                    this.tbxIMFax.Text = dv4[0]["im_fax"].ToString().Trim();
                    this.tbxIMCell.Text = dv4[0]["im_cell"].ToString().Trim();
                    this.tbxIMEmail.Text = dv4[0]["im_email"].ToString().Trim();
                    // 下述 coding 無法抓出正確之 下拉式選單的預選值
                    //this.ddlIMInvtp.SelectedItem.Value = dv4[0]["im_invcd"].ToString().Trim();
                    //this.ddlIMTaxtp.SelectedItem.Value = dv4[0]["im_taxtp"].ToString().Trim();
                    //this.ddlIMfgITRI.SelectedItem.Value = dv4[0]["im_fgitri"].ToString().Trim();

                    // 發票類別代碼
                    this.ddlIMInvtp.ClearSelection();
                    string invcd = dv4[0]["im_invcd"].ToString().Trim();
                    switch (invcd)
                    {
                        case "2":
                            this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
                            break;
                        case "3":
                            this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
                            break;
                        case "4":
                            this.ddlIMInvtp.Items.FindByValue("4").Selected = true;
                            break;
                        case "9":
                            this.ddlIMInvtp.Items.FindByValue("9").Selected = true;
                            break;
                        default:
                            this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
                            break;
                    }

                    // 發票課稅別
                    this.ddlIMTaxtp.ClearSelection();
                    string taxtp = dv4[0]["im_taxtp"].ToString().Trim();
                    switch (taxtp)
                    {
                        case "1":
                            this.ddlIMTaxtp.SelectedIndex = 0;
                            break;
                        case "2":
                            this.ddlIMTaxtp.SelectedIndex = 1;
                            break;
                        case "3":
                            this.ddlIMTaxtp.SelectedIndex = 2;
                            break;
                        case "9":
                            this.ddlIMTaxtp.SelectedIndex = 3;
                            break;
                        default:
                            this.ddlIMTaxtp.SelectedIndex = 0;
                            break;
                    }

                    // 院所內註記
                    this.ddlIMfgITRI.ClearSelection();
                    string fgitri = dv4[0]["im_fgitri"].ToString().Trim();
                    switch (fgitri)
                    {
                        case "":
                            this.ddlIMfgITRI.SelectedIndex = 0;
                            break;
                        case "06":
                            this.ddlIMfgITRI.SelectedIndex = 1;
                            break;
                        case "07":
                            this.ddlIMfgITRI.SelectedIndex = 2;
                            break;
                        default:
                            this.ddlIMfgITRI.SelectedIndex = 0;
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
            // 執行 新增動作 (先檢查收件人姓名是否有重覆輸入; 若否, 則新增之)
            //CheckDuplication();

            // 新增入資料庫
            InsertDB();


            // Refresh Datagrid2
            GridView2.Visible = true;
            BindGrid2();
        }


        // 新增資料入 DB Table
        private void InsertDB()
        {
            // 抓出 畫面上的值
            string strSyscd = "C2";
            string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
            string strMfrno = this.tbxIMMfrNo.Text.ToString().Trim();
            string strIMName = this.tbxIMName.Text.ToString().Trim();
            string strIMJobTitle = this.tbxIMJobTitle.Text.ToString().Trim();
            string strIMZipcode = this.tbxIMZipcode.Text.ToString().Trim();
            string strIMAddr = this.tbxIMAddr.Text.ToString().Trim();
            string strIMTel = this.tbxIMTel.Text.ToString().Trim();
            string strIMFax = this.tbxIMFax.Text.ToString().Trim();
            string strIMCell = this.tbxIMCell.Text.ToString().Trim();
            string strIMEmail = this.tbxIMEmail.Text.ToString().Trim();
            string strIMinvcd = this.ddlIMInvtp.SelectedItem.Value.ToString().Trim();
            string strIMtaxtp = this.ddlIMTaxtp.SelectedItem.Value.ToString().Trim();
            string strIMfgitri = this.ddlIMfgITRI.SelectedItem.Value.ToString().Trim();
            //Response.Write("strContNo= " + strContNo + "<br>");
            //Response.Write("strMfrno= " + strMfrno + "<br>");
            //Response.Write("strIMinvcd= " + strIMinvcd + "<br>");


            // 檢查廠商統編: 若非一般編碼(十位數皆為數字), 則為個人戶, 則只允許其 "發票 類別" 為 "二聯"
            string strFirststrMfrno = strMfrno == "" ? "" : strMfrno.Substring(0, 1);
            //Response.Write("strFirststrMfrno= " + strFirststrMfrno + "<br>");
            //Response.Write("Compare(strFirststrMfrno, 'A')= " + Compare(strFirststrMfrno, 'A') + "<br>");
            //Response.Write("strFirststrMfrno.CompareTo('A')= " + strFirststrMfrno.CompareTo('A') + "<br>");
            // Syntax of Compare class: Less than zero meaning strA is greater than strB
            //if(Compare(strFirststrMfrno, 'A') > 0)
            //			if(strFirststrMfrno.ToUpper().CompareTo('A') > 0)
            //			if(strFirststrMfrno != "0" || strFirststrMfrno != "1" || strFirststrMfrno != "2" || strFirststrMfrno != "3" || strFirststrMfrno != "4" || strFirststrMfrno != "5" || strFirststrMfrno != "6" || strFirststrMfrno != "7" || strFirststrMfrno != "8" || strFirststrMfrno != "9")
            if (strFirststrMfrno != "0" && strFirststrMfrno != "1" && strFirststrMfrno != "2" && strFirststrMfrno != "3" && strFirststrMfrno != "4" && strFirststrMfrno != "5" && strFirststrMfrno != "6" && strFirststrMfrno != "7" && strFirststrMfrno != "8" && strFirststrMfrno != "9")
            {
                if (strIMinvcd != "2")
                {
                    // 以 Javascript 的 window.alert()  來告知訊息
                    LiteralControl litAlert = new LiteralControl();
                    litAlert.Text = "<script language=javascript>alert(\"自動更新通知: 本筆為個人戶, 發票類別已更正為二聯\");</script>";
                    Page.Controls.Add(litAlert);
                }

                // 做自動更正之動作
                strIMinvcd = "2";
                this.ddlIMInvtp.ClearSelection();
                this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
                //Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 個人戶-二聯<br>");
            }
            //			else
            //			{
            //				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 廠商-二聯或三聯<-br>");
            //			}


            // 抓出新序號, 先抓出目前最大的 im_imseq+1
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds5 = myInv.SelectMaxInvmfr();
            DataView dv5 = ds5.Tables["invmfr"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";
            rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strContNo + "'";
            dv5.RowFilter = rowfilterstr5;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 抓出最新的 發票廠商收件人序號
            string strIMSeq = "01";
            if (dv5.Count > 0)
            {
                strIMSeq = Convert.ToString(Convert.ToInt32(dv5[0][0].ToString().Trim()) + 1);
                if (strIMSeq.Length < 2)
                    strIMSeq = "0" + strIMSeq;
            }
            else
            {
                strIMSeq = "01";
            }
            //Response.Write("strIMSeq= " + strIMSeq + "<br>");

            // 確認執行 sqlSelectCommand1 成功
            bool ResultFlag1 = false;
            
            try
            {
                myInv.InsertInvmfr(strSyscd, strContNo, strIMSeq, strMfrno, strIMName, strIMJobTitle, strIMZipcode, strIMAddr, strIMTel, strIMFax, strIMCell, strIMEmail, strIMinvcd, strIMtaxtp, strIMfgitri);
                ResultFlag1 = true;
            }
            catch (System.Data.SqlClient.SqlException ex1)
            {
                Response.Write(ex1.Message + "<br>");
                ResultFlag1 = false;
            }

             //輸出執行結果
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


        private void ModifyDB()
        {
            // 顯示欲修改之 發票廠商收件人序號
            this.lblImSeq.Visible = true;

            // 抓出 畫面上的值
            string strsyscd = "C2";
            string strcontno = this.tbxIMContNo.Text.ToString().Trim();
            // 抓出其 收件人序號 (由 DataGrid1_ItemCommand() 帶出此值到 lblImSeq )
            string strimseq = this.lblImSeq.Text.ToString();
            string strMfrno = this.tbxIMMfrNo.Text.ToString().Trim();
            string strIMName = this.tbxIMName.Text.ToString().Trim();
            string strIMJobTitle = this.tbxIMJobTitle.Text.ToString().Trim();
            string strIMZipcode = this.tbxIMZipcode.Text.ToString().Trim();
            string strIMAddr = this.tbxIMAddr.Text.ToString().Trim();
            string strIMTel = this.tbxIMTel.Text.ToString().Trim();
            string strIMFax = this.tbxIMFax.Text.ToString().Trim();
            string strIMCell = this.tbxIMCell.Text.ToString().Trim();
            string strIMEmail = this.tbxIMEmail.Text.ToString().Trim();
            string strIMinvcd = this.ddlIMInvtp.SelectedItem.Value.ToString().Trim();
            string strIMtaxtp = this.ddlIMTaxtp.SelectedItem.Value.ToString().Trim();
            string strIMfgitri = this.ddlIMfgITRI.SelectedItem.Value.ToString().Trim();
            //Response.Write("strimseq= " + strimseq + "<br>");
            //Response.Write("strIMName= " + strIMName + "<br>");
            //Response.Write("strIMinvcd= " + strIMinvcd + "<br>");
            //Response.Write("strIMtaxtp= " + strIMtaxtp + "<br>");
            //Response.Write("strIMfgitri= " + strIMfgitri + "<br>");


            // 本段 coding 同 InsertDB() 裡之同段
            // 檢查廠商統編: 若非一般編碼(十位數皆為數字), 則為個人戶, 則只允許其 "發票 類別" 為 "二聯"
            string strFirststrMfrno = strMfrno.Substring(0, 1);
            //Response.Write("strFirststrMfrno= " + strFirststrMfrno + "<br>");
            //			if(strFirststrMfrno != "0" || strFirststrMfrno != "1" || strFirststrMfrno != "2" || strFirststrMfrno != "3" || strFirststrMfrno != "4" || strFirststrMfrno != "5" || strFirststrMfrno != "6" || strFirststrMfrno != "7" || strFirststrMfrno != "8" || strFirststrMfrno != "9")
            if (strFirststrMfrno != "0" && strFirststrMfrno != "1" && strFirststrMfrno != "2" && strFirststrMfrno != "3" && strFirststrMfrno != "4" && strFirststrMfrno != "5" && strFirststrMfrno != "6" && strFirststrMfrno != "7" && strFirststrMfrno != "8" && strFirststrMfrno != "9")
            {
                if (strIMinvcd != "2")
                {
                    // 以 Javascript 的 window.alert()  來告知訊息
                    LiteralControl litAlert = new LiteralControl();
                    litAlert.Text = "<script language=javascript>alert(\"自動更新通知: 本筆為個人戶, 發票類別已更正為二聯\");</script>";
                    Page.Controls.Add(litAlert);
                }

                // 做自動更正之動作
                strIMinvcd = "2";
                this.ddlIMInvtp.ClearSelection();
                this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
                //Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 個人戶-二聯<br>");
            }
            //			else
            //			{
            //				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 廠商-二聯或三聯<-br>");
            //			}

            // 確認執行 sqlCommand3 成功
            bool ResultFlag3 = false;
            //Response.Write(strMfrno + "," + strIMName + "," + strIMZipcode + "," + strIMAddr + "," + strIMAddr + "," + strIMTel + "," + strIMFax + "," + strIMCell + "," + strIMEmail + "," + strIMinvcd + "," + strIMtaxtp + "," + strIMfgitri + "," + strsyscd + "," + strcontno + "," + strimseq);
            try
            {
                myInv.UpdateInvmfr(strMfrno, strIMName, strIMJobTitle, strIMZipcode, strIMAddr, strIMTel, strIMFax, strIMCell, strIMEmail, strIMinvcd, strIMtaxtp, strIMfgitri, strsyscd, strcontno, strimseq);
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


        // 將畫面上殘餘資料(按下 新增/修改/刪除後) 清除
        private void ClearForm()
        {
            // 將畫面上殘餘資料清除為空
            // 注意: 下拉式選單 要使用 SelectedIndex 的技巧
            this.lblImSeq.Text = "";
            //this.tbxIMContNo.Text = "";
            this.tbxIMMfrNo.Text = "";
            this.tbxIMName.Text = "";
            this.tbxIMJobTitle.Text = "";
            this.tbxIMZipcode.Text = "";
            this.tbxIMAddr.Text = "";
            this.tbxIMTel.Text = "";
            this.tbxIMFax.Text = "";
            this.tbxIMCell.Text = "";
            this.tbxIMEmail.Text = "";

            // 給下拉式選單 預選值 (同 InitialData() 裡同段落 )
            this.ddlIMInvtp.ClearSelection();
            this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
            this.ddlIMTaxtp.ClearSelection();
            ddlIMTaxtp.SelectedIndex = 0;
            this.ddlIMfgITRI.ClearSelection();
            ddlIMfgITRI.SelectedIndex = 0;
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
        }


    }
}
