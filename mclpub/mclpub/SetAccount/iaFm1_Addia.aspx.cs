using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class iaFm1_Addia : System.Web.UI.Page
    {
        security sec = new security();
        iaFm1_Addia_DB myiaFm = new iaFm1_Addia_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "DataGrid1";
            if (!IsPostBack)
            {
                try
                {
                    // 抓出 合約及發廠資料
                    GetContIM();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            btnShowFullCont.Attributes.Add("onClick", "javascript:doDetail('920','600','../Contract/ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(tbxCustNo.Text.ToString().Trim()) + "&cont_contno=" + Context.Request.QueryString["contno"].ToString().Trim() + "&dpplane=true');");
            btnModifyCont.Attributes.Add("onClick", "javascript:doDetail('920','600','../Contract/PlaneCont2Edit.aspx?cust_custno=" + sec.encryptquerystring(tbxCustNo.Text.ToString().Trim()) + "&cont_contno=" + sec.encryptquerystring(Context.Request.QueryString["contno"].ToString().Trim()) + "');");
            btnModifyPub.Attributes.Add("onClick", "javascript:doDetail('920','600','../Layout/PubFm.aspx?contno=" + sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim()) + "&bkcd=" + tbxbkcd.Text + "&fgnew=" + tbxfgpubed.Text.ToString().Trim() + "');");
        }

        // 抓出 合約及發廠資料
        private void GetContIM()
        {
            this.lblMessage.Text = "";
            this.btnConfirmAmt.Visible = true;
            this.btnAddia.Visible = false;
            this.btnModifyCont.Visible = false;
            this.btnModifyPub.Visible = false;

            string contno = string.IsNullOrEmpty(Request.QueryString["contno"].ToString().Trim()) == true ? "" : sec.decryptquerystring(Request.QueryString["contno"].ToString().Trim());
            string imseq = string.IsNullOrEmpty(Request.QueryString["imseq"].ToString().Trim()) == true ? "" : sec.decryptquerystring(Request.QueryString["imseq"].ToString().Trim());

            if (contno != "" && imseq != "")
            {
                // 抓出網頁變數的值
                string strContNo = contno;
                string strIMSeq = imseq;
                string strIMName = "";
                this.lblContNo.Text = "您挑選的合約書編號：" + strContNo;
                this.lblIMSeq.Text = "發票廠商收件人：" + strIMSeq;


                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds1 = myiaFm.Selectc2_Cont();
                DataView dv1 = ds1.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr1 = "1=1";
                rowfilterstr1 = rowfilterstr1 + " AND im_contno = '" + strContNo + "'";
                rowfilterstr1 = rowfilterstr1 + " AND im_imseq = '" + strIMSeq + "'";
                dv1.RowFilter = rowfilterstr1;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
                //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

                if (dv1.Count > 0)
                {
                    strIMName = dv1[0]["im_nm"].ToString().Trim();
                    this.lblContNo.Text = "您挑選的合約是：" + strContNo;
                    this.lblIMSeq.Text = this.lblIMSeq.Text + "-" + strIMName;

                    // 顯示合約相關資料 -- 含廠商/客戶, 合約金額資料
                    LoadCont();

                    // 顯示其落版資料 - 尚未開立發票的
                    BindGrid1();
                }
            }
        }

        // 顯示合約相關資料 -- custno, 以便做為 '顯示合約落版資料' 的傳遞變數
        private void LoadCont()
        {

            string strContNo = string.IsNullOrEmpty(Request.QueryString["contno"].ToString().Trim()) == true ? "" : sec.decryptquerystring(Request.QueryString["contno"].ToString().Trim());


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myiaFm.Selectc2_Cont();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            rowfilterstr1 = rowfilterstr1 + " AND cont_contno = '" + strContNo + "'";
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            if (dv1.Count > 0)
            {
                // 抓出資料
                string strbkcd = dv1[0]["cont_bkcd"].ToString();
                string strfgpubed = dv1[0]["cont_fgpubed"].ToString().Trim();
                string strCustNo = dv1[0]["cont_custno"].ToString().Trim();
                string strCustName = dv1[0]["cust_nm"].ToString().Trim();
                string strMfrNo = dv1[0]["cont_mfrno"].ToString().Trim();
                string strMfrIName = dv1[0]["mfr_inm"].ToString().Trim();
                string intTotalAmt = dv1[0]["cont_totamt"].ToString().Trim();
                string intPaidAmt = dv1[0]["cont_paidamt"].ToString().Trim();
                string intRestAmt = dv1[0]["cont_restamt"].ToString().Trim();

                // 顯示資料
                this.tbxbkcd.Text = strbkcd;
                this.tbxfgpubed.Text = strfgpubed;
                this.tbxCustNo.Text = strCustNo;
                this.lblMfrCust.Text = "(廠商名稱：" + strMfrIName + " (" + strMfrNo + ")" + "；客戶名稱：" + strCustName + ")";

                this.pnl1.Visible = true;
                this.pnl2.Visible = false;
                this.pnl3.Visible = false;
                this.lblContTotalAmt.Text = intTotalAmt;
                this.lblContPaidAmt.Text = intPaidAmt;
                this.lblContRestAmt.Text = intRestAmt;
            }
        }


        // 顯示其落版資料 - 尚未開立發票的
        private void BindGrid1()
        {
            // 抓出網頁變數的值
            string strContNo = string.IsNullOrEmpty(Request.QueryString["contno"].ToString().Trim()) == true ? "" : sec.decryptquerystring(Request.QueryString["contno"].ToString().Trim());
            string strIMSeq = string.IsNullOrEmpty(Request.QueryString["imseq"].ToString().Trim()) == true ? "" : sec.decryptquerystring(Request.QueryString["imseq"].ToString().Trim());


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myiaFm.Selectc2_Cont2();
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            rowfilterstr2 = rowfilterstr2 + " AND pub_contno = '" + strContNo + "'";
            rowfilterstr2 = rowfilterstr2 + " AND pub_imseq = '" + strIMSeq + "'";
            rowfilterstr2 = rowfilterstr2 + " AND pub_fginved = ' '";
            // 下一行之備註: 因區隔材料所的上線資訊, 故舊落版資料小於等於 200209 的, 將不准再出現於 發票產生 流程中
            // 以免舊資訊重覆開立發票資料, 造成困擾.
            rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm>='200209'";
            dv2.RowFilter = rowfilterstr2;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

            if (dv2.Count > 0)
            {
                this.lblMessage.Text = "(此合約還有 " + dv2.Count + " 筆未開立的落版資料.)";

                UCPager1.Dtdata = dv2.ToTable();
                UCPager1.UCPageBind();
            }
            else
            {
                this.btnAddia.Visible = false;
                JavaScript.AlertMessageRedirect(this.Page, "無未開立發票開立單的落版資料", "iaFm1_Add.aspx");
            }
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                    // 刊登年月
                    string YYYYMM = e.Row.Cells[1].Text.ToString().Trim();
                    YYYYMM = YYYYMM.Substring(0, 4) + "/" + YYYYMM.Substring(4, 2);
                    //Response.Write("StartDate= " + StartDate + "<br>");
                    e.Row.Cells[1].Text = YYYYMM;

                    // 固定頁次註記
                    string fgfixpg = e.Row.Cells[7].Text.ToString().Trim();
                    //Response.Write("fgfixpg= " + fgfixpg + "<br>");
                    if (fgfixpg == "0")
                        e.Row.Cells[7].Text = "否";
                    else
                        e.Row.Cells[7].Text = "<font color='Red'>是</font>";

                    // 稿件類別
                    string drfttp = e.Row.Cells[8].Text.ToString().Trim();
                    //Response.Write("drfttp= " + drfttp + "<br>");
                    switch (drfttp)
                    {
                        case "1":
                            e.Row.Cells[8].Text = "舊稿";

                            // 清除其他稿件資料
                            e.Row.Cells[9].Text = "";
                            e.Row.Cells[10].Text = "";
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[12].Text = "";
                            e.Row.Cells[13].Text = "";
                            e.Row.Cells[14].Text = "";
                            break;
                        case "2":
                            e.Row.Cells[8].Text = "新稿";

                            // 到稿註記
                            string fggot1 = e.Row.Cells[9].Text.ToString().Trim();
                            //Response.Write("fggot1= " + fggot1 "<br>");
                            if (fggot1 == "0")
                                e.Row.Cells[9].Text = "<font color='Red'>否</font>";
                            else
                                e.Row.Cells[9].Text = "是";

                            // 清除其他稿件資料
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[12].Text = "";
                            e.Row.Cells[13].Text = "";
                            e.Row.Cells[14].Text = "";
                            e.Row.Cells[15].Text = "";
                            e.Row.Cells[16].Text = "";
                            e.Row.Cells[17].Text = "";
                            break;
                        case "3":
                            e.Row.Cells[8].Text = "改稿";

                            // 書籍類別
                            string chgbkcd = e.Row.Cells[11].Text.ToString().Trim();
                            //Response.Write("chgbkcd= " + chgbkcd "<br>");
                            if (chgbkcd == "01")
                                e.Row.Cells[11].Text = "工材雜誌";
                            else if (chgbkcd == "02")
                                e.Row.Cells[11].Text = "電材雜誌";

                            // 到稿註記
                            string fggot2 = e.Row.Cells[9].Text.ToString().Trim();
                            //Response.Write("fggot2= " + fggot2 "<br>");
                            if (fggot2 == "0")
                                e.Row.Cells[9].Text = "<font color='Red'>否</font>";
                            else
                                e.Row.Cells[9].Text = "是";

                            // 改稿重出片註記
                            string fgrechg = e.Row.Cells[14].Text.ToString().Trim();
                            //Response.Write("fgrechg= " + fgrechg "<br>");
                            if (fgrechg == "0")
                                e.Row.Cells[14].Text = "否";
                            else
                                e.Row.Cells[14].Text = "<font color='Red'>是</font>";

                            // 清除其他稿件資料
                            e.Row.Cells[10].Text = "";
                            e.Row.Cells[15].Text = "";
                            e.Row.Cells[16].Text = "";
                            e.Row.Cells[17].Text = "";
                            break;
                        default:
                            e.Row.Cells[8].Text = "舊稿";
                            break;
                    }
                
            }
        }

        protected void btnConfirmAmt_Click(object sender, EventArgs e)
        {
            this.pnl1.Visible = true;
            this.pnl2.Visible = true;
            this.pnl3.Visible = true;

            // 抓出 已挑選 pnl2 及 將更新 pnl3 之資料
            int intPickTotalAdAmt = 0, intPickTotalChgAmt = 0, intPickTotalAmt = 0;
            int intContTotalAmt = 0, intContPaidAmt = 0, intContRestAmt = 0;
            int intNewContTotalAmt = 0, intNewContPaidAmt = 0, intNewContRestAmt = 0;

            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                bool strSelect = ((CheckBox)DataGrid1.Rows[i].FindControl("CheckBox2")).Checked;

                // 抓出被挑選者
                if (strSelect == true)
                {
                    // 抓出各筆之 廣告金額, 換稿金額
                    int intAdAmt = Convert.ToInt32(DataGrid1.Rows[i].Cells[18].Text.ToString());
                    int intChgAmt = Convert.ToInt32(DataGrid1.Rows[i].Cells[19].Text.ToString());
                    //Response.Write("intAdAmt= " + intAdAmt + ", ");
                    //Response.Write("intChgAmt= " + intChgAmt + "<br>");

                    // 抓出已挑選金額資料 之 總廣告金額, 總換稿金額, 小計
                    intPickTotalAdAmt = intPickTotalAdAmt + intAdAmt;
                    intPickTotalChgAmt = intPickTotalChgAmt + intChgAmt;
                    intPickTotalAmt = intPickTotalAdAmt + intPickTotalChgAmt;
                    this.lblPickAdAmt.Text = Convert.ToString(intPickTotalAdAmt);
                    this.lblPickChgAmt.Text = Convert.ToString(intPickTotalChgAmt);
                    this.lblPickTotalAmt.Text = Convert.ToString(intPickTotalAmt);
                    //Response.Write("intPickTotalAdAmt= " + intPickTotalAdAmt + ", ");
                    //Response.Write("intPickTotalChgAmt= " + intPickTotalChgAmt + "<br>");
                    //Response.Write("intPickTotalAmt= " + intPickTotalAmt + "<br>");


                    // 抓出合約金額資料 之 合約金額, 已繳金額, 剩餘金額
                    intContTotalAmt = Convert.ToInt32(this.lblContTotalAmt.Text.ToString().Trim());
                    intContPaidAmt = Convert.ToInt32(this.lblContPaidAmt.Text.ToString().Trim());
                    intContRestAmt = Convert.ToInt32(this.lblContRestAmt.Text.ToString().Trim());
                    //Response.Write("intContTotalAmt= " + intContTotalAmt + "<br>");
                    //Response.Write("intContPaidAmt= " + intContPaidAmt + "<br>");
                    //Response.Write("intContRestAmt= " + intContRestAmt + "<br>");


                    // 抓出將更新之合約金額資料 之 合約金額, 已繳金額, 剩餘金額
                    intNewContTotalAmt = intContTotalAmt;
                    intNewContPaidAmt = intContPaidAmt + intPickTotalAmt;
                    intNewContRestAmt = intNewContTotalAmt - intNewContPaidAmt;
                    //Response.Write("intNewContTotalAmt= " + intNewContTotalAmt + "<br>");
                    //Response.Write("intNewContPaidAmt= " + intNewContPaidAmt + "<br>");
                    //Response.Write("intNewContRestAmt= " + intNewContRestAmt + "<br>");
                    this.lblNewContTotalAmt.Text = Convert.ToString(intNewContTotalAmt);
                    this.lblNewContPaidAmt.Text = Convert.ToString(intNewContPaidAmt);
                    this.lblNewContRestAmt.Text = Convert.ToString(intNewContRestAmt);
                }
            }


            // 檢查 將更新之合約 '剩餘金額' & '已繳金額' 資料是否合理
            if (intNewContRestAmt > 0 || intNewContPaidAmt <= intContTotalAmt)
            {
                this.btnConfirmAmt.Visible = false;
                this.btnAddia.Visible = true;

                this.btnModifyCont.Visible = false;
                this.btnModifyPub.Visible = false;
            }
            else if (intNewContRestAmt < 0 || intNewContPaidAmt > intContTotalAmt)
            {
                this.btnAddia.Visible = false;
                JavaScript.AlertMessage(this.Page, "將更新之合約 '剩餘金額' & '已繳金額' 資料不合理,\\n 無法產生發票開立單, 請先修正 合約或落版資料!!!");

                this.btnModifyCont.Visible = true;
                this.btnModifyPub.Visible = true;
            }
        }
            
		// 產生發票開立單 按鈕的處理
		protected void btnAddia_Click(object sender, System.EventArgs e)
		{
			// 先挑出被勾選的 ContNo & IMseq
			// 執行 新增 ia & iad
			CreateIA();
			// Refresh DataList1
			BindGrid1();
		}

        private void CreateIA()
        {
            string strSyscd = "C2";
            string strContNo = string.IsNullOrEmpty(Request.QueryString["contno"].ToString().Trim()) == true ? "" : sec.decryptquerystring(Request.QueryString["contno"].ToString().Trim());
            string strIMSeq = string.IsNullOrEmpty(Request.QueryString["imseq"].ToString().Trim()) == true ? "" : sec.decryptquerystring(Request.QueryString["imseq"].ToString().Trim());


            // step1 - 更新被挑選落版之 發票開立單註記 (由 ' ' 改為 'v')
            int intTotalAdAmt = 0, intTotalChgAmt = 0;
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                // 抓出 每一筆落版資料
                bool strSelect = ((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked;
                string strYYYYMM = DataGrid1.Rows[i].Cells[1].Text.ToString().Trim();
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
                string strPubSeq = DataGrid1.Rows[i].Cells[2].Text.ToString();
                int intAdAmt = Convert.ToInt32(DataGrid1.Rows[i].Cells[18].Text.ToString());
                int intChgAmt = Convert.ToInt32(DataGrid1.Rows[i].Cells[19].Text.ToString());
                //Response.Write("i= " + i + ", ");
                //Response.Write("strSyscd= " + strSyscd + ", ");
                //Response.Write("strContNo= " + strContNo + ", ");
                //Response.Write("strSelect= " + strSelect + ", ");
                //Response.Write("strYYYYMM= " + strYYYYMM + ", ");
                //Response.Write("strPubSeq= " + strPubSeq + "");
                //Response.Write("strIMSeq= " + strIMSeq + ", ");
                //Response.Write("intAdAmt= " + intAdAmt + ", ");
                //Response.Write("intChgAmt= " + intChgAmt + "<br>");

                // 抓出被挑選者
                if (strSelect == true)
                {
                    intTotalAdAmt = intTotalAdAmt + intAdAmt;
                    intTotalChgAmt = intTotalChgAmt + intChgAmt;
                    //this.lblAmtCount.Text = "金額 小計：$" + intTotalAdAmt + "／$" + intTotalChgAmt;
                    //Response.Write("i= " + i + ", ");
                    //Response.Write("strSyscd= " + strSyscd + ", ");
                    //Response.Write("strContNo= " + strContNo + ", ");
                    //Response.Write("strYYYYMM= " + strYYYYMM + ", ");
                    //Response.Write("strPubSeq= " + strPubSeq + ", ");
                    //Response.Write("strIMSeq= " + strIMSeq + "<br>");
                    //Response.Write("intTotalAdAmt= " + intTotalAdAmt + ", ");
                    //Response.Write("intTotalChgAmt= " + intTotalChgAmt + "<br>");


                    // 更新被挑選的落版資料之 pub_fginved 從 ' ' 變為 'v'
                    // 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
                    //Response.Write(this.sqlCommand1.CommandText);
                    bool ResultFlag1 = false;
                    try
                    {
                        myiaFm.UPDATEc2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq);
                        ResultFlag1 = true;
                    }
                    catch (System.Data.SqlClient.SqlException ex1)
                    {
                        throw new Exception(ex1.Message);
                    }
                    //Response.Write("ResultFlag1= " + ResultFlag1 + "<br>");

                    // 輸出執行結果
                    if (ResultFlag1)
                    {
                        //Response.Write("更新落版檔的發票開立單註記 成功!<br>");
                    }
                    else
                    {
                        //Response.Write("更新落版檔的發票開立單註記 失敗!<br>");
                    }
                    // 結束 if(strSelect == true)
                }
                // 結束 for loop
            }



            // step2 - 產生 ia & iad -- 呼叫 sp_c2_add_1_ia_1
            //Response.Write(this.sqlCommand2.CommandText);
            bool ResultFlag2 = false;
            try
            {
                myiaFm.UPDATEsp_c2_add_1_ia_1(strSyscd, strContNo, strIMSeq);
                ResultFlag2 = true;
            }
            catch (System.Data.SqlClient.SqlException ex2)
            {
                ResultFlag2 = false;
                throw new Exception(ex2.Message);
            }
            //Response.Write("ResultFlag2= " + ResultFlag2 + "<br>");

            // 輸出執行結果
            if (ResultFlag2)
            {
                //Response.Write("<font size=2>新增發票開立單成功!</font><br>");
                JavaScript.AlertMessage(this.Page, "合約書編號: " + strContNo + " 的發票開立單 新增成功");
            }
            else
            {
                //Response.Write("<font size=2>新增發票開立單失敗!</font><br>");
                JavaScript.AlertMessage(this.Page, "合約書編號: " + strContNo + " 的發票開立單 新增失敗");
            }



            // step3 - 更新 合約資料之 已繳金額 & 剩餘金額 欄位值
            //Response.Write(this.sqlCommand3.CommandText);

            // 確認執行 sqlCommand3 成功
            bool ResultFlag3 = false;

            try
            {
                int strNewContPaidAmt = Convert.ToInt32(lblNewContPaidAmt.Text.ToString().Trim());
                int strNewContRestAmt = Convert.ToInt32(lblNewContRestAmt.Text.ToString().Trim());
                myiaFm.UPDATEc2_cont(strNewContPaidAmt, strNewContRestAmt, strContNo);
                ResultFlag3 = true;
            }
            catch (System.Data.SqlClient.SqlException ex3)
            {
                throw new Exception(ex3.Message);
                ResultFlag3 = false;
            }
            //Response.Write("ResultFlag3= " + ResultFlag3 + "<br>");

            // 輸出執行結果
            if (ResultFlag3)
            {
                //Response.Write("<font size=2>更新合約之已繳金額&剩餘金額成功!</font><br>");
                JavaScript.AlertMessage(this.Page, "合約書編號: " + strContNo + " 之已繳&剩餘金額 更新成功");
            }
            else
            {
                //Response.Write("<font size=2>更新合約之已繳金額&剩餘金額失敗!</font><br>");
                JavaScript.AlertMessage(this.Page, "合約書編號: " + strContNo + " 之已繳&剩餘金額 更新成功失敗");
            }


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myiaFm.SelectMaxia();
            DataView dv3 = ds3.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv3.Count > 0)
            {
                string strMaxIANo = dv3[0]["MaxIANno"].ToString().Trim();
                this.tbxIANo.Text = strMaxIANo;
                //Response.Write("strMaxIANo= " + strMaxIANo + "<br>");

                // 轉址處理 - 發票開立單檢核表 - 一次付款
                Response.Redirect("iaFm1_chklist.aspx?contno=" + sec.encryptquerystring(strContNo) + "&imseq=" + sec.encryptquerystring(strIMSeq) + "&iano=" + sec.encryptquerystring(strMaxIANo));
            }
        }

    }
}