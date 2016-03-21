using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class iaFm1_Recia : System.Web.UI.Page
    {
        security sec = new security();
        iaFm1_Recia_DB myiaFm1 = new iaFm1_Recia_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // 抓出 合約及發廠資料
                    if (sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim()) != "" && sec.decryptquerystring(Context.Request.QueryString["imseq"].ToString().Trim()) != "")
                    {
                        GetContIM();

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            btnShowFullCont.Attributes.Add("onClick", "javascript:doDetail('920','600','../Contract/ContShowDetail.aspx?cust_custno=" + sec.encryptquerystring(tbxCustNo.Text.ToString().Trim()) + "&cont_contno=" + Context.Request.QueryString["contno"].ToString().Trim() + "&dpplane=true');");
        }

        private void GetContIM()
        {
            this.lblMessage.Text = "";
            this.btnRecia.Visible = false;
            this.btnModifyCont.Visible = false;
            this.btnModifyPub.Visible = false;
            // 抓出網頁變數的值
            string strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());
            string strIMSeq = sec.decryptquerystring(Context.Request.QueryString["imseq"].ToString().Trim());
            string strIMName = "";
            this.lblContNo.Text = "您挑選的合約書編號：" + strContNo;
            this.lblIMSeq.Text = "發票廠商收件人：" + strIMSeq;


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myiaFm1.Selectc2_cont();
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

        // 顯示合約相關資料 -- custno, 以便做為 '顯示合約落版資料' 的傳遞變數
        private void LoadCont()
        {
            string strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myiaFm1.Selectc2_cont();
            DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

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
                this.lblMfrCust.Text = "(廠商名稱：" + strMfrNo + "-" + strMfrIName + "；客戶名稱：" + strCustName + ")";

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
            string strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());
            string strIMSeq =  sec.decryptquerystring(Context.Request.QueryString["imseq"].ToString().Trim());


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myiaFm1.Selectc2_cont();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            rowfilterstr1 = rowfilterstr1 + " AND cont_syscd = 'C2'";
            rowfilterstr1 = rowfilterstr1 + " AND cont_contno = '" + strContNo + "'";
            //rowfilterstr1 = rowfilterstr1 + " AND im_imseq = '" + strIMSeq + "'";
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            if (dv1.Count > 0)
            {
                DataGrid1.DataSource = dv1;
                DataGrid1.DataBind();


                // 顯示 發票明細資料
                BindGrid2();

                // 抓出 確認金額
                CheckAmt();

                // 結束 if(dv2.Count > 0)
            }
            else
            {
                this.btnRecia.Visible = false;
            }
        }

        private void BindGrid2()
        {
            string strContNo, strIANo;
            strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());
            strIANo = sec.decryptquerystring(Context.Request.QueryString["iano"].ToString().Trim());


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myiaFm1.Selectia();
            DataView dv3 = ds3.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND ia_syscd = 'C2'";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iano = '" + strIANo + "'";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iasdate = '' ";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iasseq = '' ";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iaitem = '' ";
            rowfilterstr3 = rowfilterstr3 + " AND ia_contno = 'C2" + strContNo + "'";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv3.Count > 0)
            {
                this.lblIAMessage.Text = "本合約共有 " + dv3.Count + " 筆發票明細資料!";

                DataGrid2.DataSource = dv3;
                DataGrid2.DataBind();
            }
        }


        private void CheckAmt()
        {
            // 顯示 Panel 資料
            this.pnl1.Visible = true;
            this.pnl2.Visible = true;
            this.pnl3.Visible = true;

            // 抓出 已挑選 pnl2 及 將更新 pnl3 之資料
            int intPickTotalAmt = 0;
            int intContTotalAmt = 0, intContPaidAmt = 0, intContRestAmt = 0;
            int intNewContTotalAmt = 0, intNewContPaidAmt = 0, intNewContRestAmt = 0;

            // 抓出已挑選金額資料 之 總廣告金額, 總換稿金額, 小計
            string strContNo, strIANo;
            strContNo = Context.Request.QueryString["contno"].ToString().Trim();
            strIANo = Context.Request.QueryString["iano"].ToString().Trim();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myiaFm1.Selectia();
            DataView dv3 = ds3.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND ia_syscd = 'C2'";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iano = '" + strIANo + "'";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iasdate = '' ";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iasseq = '' ";
            rowfilterstr3 = rowfilterstr3 + " AND ia_iaitem = '' ";
            rowfilterstr3 = rowfilterstr3 + " AND ia_contno = 'C2" + strContNo + "'";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv3.Count > 0)
            {
                intPickTotalAmt = Convert.ToInt32(dv3[0]["ia_pyat"].ToString().Trim());
                this.lblPickTotalAmt.Text = Convert.ToString(intPickTotalAmt);
                //Response.Write("intPickTotalAmt= " + intPickTotalAmt + "<br>");
            }

            // 抓出合約金額資料 之 合約金額, 已繳金額, 剩餘金額
            intContTotalAmt = Convert.ToInt32(this.lblContTotalAmt.Text.ToString().Trim());
            intContPaidAmt = Convert.ToInt32(this.lblContPaidAmt.Text.ToString().Trim());
            intContRestAmt = Convert.ToInt32(this.lblContRestAmt.Text.ToString().Trim());
            //Response.Write("intContTotalAmt= " + intContTotalAmt + "<br>");
            //Response.Write("intContPaidAmt= " + intContPaidAmt + "<br>");
            //Response.Write("intContRestAmt= " + intContRestAmt + "<br>");


            // 抓出將更新之合約金額資料 之 合約金額, 已繳金額, 剩餘金額
            intNewContTotalAmt = intContTotalAmt;
            intNewContPaidAmt = intContPaidAmt - intPickTotalAmt;
            intNewContRestAmt = intNewContTotalAmt - intNewContPaidAmt;
            //Response.Write("intNewContTotalAmt= " + intNewContTotalAmt + "<br>");
            //Response.Write("intNewContPaidAmt= " + intNewContPaidAmt + "<br>");
            //Response.Write("intNewContRestAmt= " + intNewContRestAmt + "<br>");
            this.lblNewContTotalAmt.Text = Convert.ToString(intNewContTotalAmt);
            this.lblNewContPaidAmt.Text = Convert.ToString(intNewContPaidAmt);
            this.lblNewContRestAmt.Text = Convert.ToString(intNewContRestAmt);


            //			// 檢查 將更新之合約 '剩餘金額' & '已繳金額' 資料是否合理
            //			if(intNewContRestAmt > 0 || intNewContPaidAmt <= intContTotalAmt)
            //			{
            this.btnRecia.Visible = true;

            this.btnModifyCont.Visible = false;
            this.btnModifyPub.Visible = false;
            //			}
            //			else if(intNewContRestAmt < 0 || intNewContPaidAmt > intContTotalAmt)
            //			{
            //				this.btnRecia.Visible = false;
            //
            //				// 以 Javascript 的 window.close() 來告知訊息
            //				LiteralControl litAlert1 = new LiteralControl();
            //				litAlert1.Text = "<script language=javascript>alert(\"將更新之合約 '剩餘金額' & '已繳金額' 資料不合理,\\n 無法產生發票開立單, 請先修正 合約或落版資料!!!\");</script>";
            //				Page.Controls.Add(litAlert1);
            //
            //				this.btnModifyCont.Visible = true;
            //				this.btnModifyPub.Visible = true;
            //			}
        }



        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 合約類別
                string conttp = e.Row.Cells[4].Text.ToString().Trim();
                //Response.Write("conttp= " + conttp + "<br>");
                if (conttp == "01")
                    e.Row.Cells[4].Text = "一般";
                else if (conttp == "09")
                    e.Row.Cells[4].Text = "<font color='Red'>推廣</font>";

                // 簽約日期
                string SignDate = e.Row.Cells[5].Text.ToString().Trim();
                SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                //Response.Write("SignDate= " + SignDate + "<br>");
                e.Row.Cells[5].Text = SignDate;

                // 合約起日
                string StartDate = e.Row.Cells[6].Text.ToString().Trim();
                StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                //Response.Write("StartDate= " + StartDate + "<br>");
                e.Row.Cells[6].Text = StartDate;

                // 合約迄日
                string EndDate = e.Row.Cells[7].Text.ToString().Trim();
                EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                //Response.Write("EndDate= " + EndDate + "<br>");
                e.Row.Cells[7].Text = EndDate;

                // 結案註記
                string fgclosed = e.Row.Cells[15].Text.ToString().Trim();
                //Response.Write("fgclosed= " + fgclosed + "<br>");
                if (fgclosed == "0")
                    e.Row.Cells[15].Text = "否";
                else
                    e.Row.Cells[15].Text = "<font color='Red'>是</font>";

                // 結束 for loop

            }
        }

        protected void DataGrid2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 發票類別代碼
                string invcd = e.Row.Cells[8].Text.ToString().Trim();
                //Response.Write("invcd= " + invcd + "<br>");
                switch (invcd)
                {
                    case "2":
                        e.Row.Cells[8].Text = "<font color='Red'>二聯式</font>";
                        break;
                    case "3":
                        e.Row.Cells[8].Text = "三聯式";
                        break;
                    case "4":
                        e.Row.Cells[8].Text = "<font color='Red'>其他</font>";
                        break;
                    default:
                        e.Row.Cells[8].Text = "三聯式";
                        break;
                }

                // 發票課稅別代碼
                string taxtp = e.Row.Cells[9].Text.ToString().Trim();
                //Response.Write("taxtp= " + taxtp + "<br>");
                switch (taxtp)
                {
                    case "1":
                        e.Row.Cells[9].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[9].Text = "<font color='Red'>零稅</font>";
                        break;
                    case "3":
                        e.Row.Cells[9].Text = "<font color='Red'>免稅</font>";
                        break;
                    default:
                        e.Row.Cells[9].Text = "應稅5%";
                        break;
                }

                // 結束 for loop

            }
        }
        // 回復發票開立單 按鈕的處理
        protected void btnRecia_Click(object sender, EventArgs e)
        {
            try
            {
                string strSyscd = "C2";
                string strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());
                string strIMSeq = sec.decryptquerystring(Context.Request.QueryString["imseq"].ToString().Trim());
                string strIANo = sec.decryptquerystring(Context.Request.QueryString["iano"].ToString().Trim());

                for (int i = 0; i < DataGrid2.Rows.Count; i++)
                {
                    // 抓出 每一筆發票明細資料
                    string strYYYYMM = DataGrid2.Rows[i].Cells[12].Text.ToString().Trim();
                    string strPubSeq = DataGrid2.Rows[i].Cells[13].Text.ToString().Trim();
                    //Response.Write("i= " + i + ", ");
                    //Response.Write("strSyscd= " + strSyscd + ", ");
                    //Response.Write("strContNo= " + strContNo + ", ");
                    //Response.Write("strYYYYMM= " + strYYYYMM + ", ");
                    //Response.Write("strPubSeq= " + strPubSeq + "<br>");

                    // 更新被挑選的落版資料之 pub_fginved 從 ' ' 變為 'v'
                    // 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
                    //Response.Write("sqlCommand1.Parameters.Count= " + sqlCommand1.Parameters.Count.ToString().Trim()+ "<br>");
                    try
                    {
                        myiaFm1.UPDATEc2_pub(strSyscd, strContNo, strYYYYMM, strPubSeq);
                        //Response.Write("更新落版檔的發票開立單註記 成功!<br>");
                    }
                    catch (System.Data.SqlClient.SqlException ex1)
                    {
                        throw new Exception(ex1.Message + " <錯誤區塊:1>");
                        //Response.Write("更新落版檔的發票開立單註記 失敗!<br>");
                    }


                    // step2 - 刪除 ia & iad -- 呼叫 sp_c2_delete_ia_1
                    //Response.Write(this.sqlCommand2.CommandText);
                    //Response.Write("sqlCommand2.Parameters.Count= " + sqlCommand2.Parameters.Count.ToString().Trim()+ "<br>");
                    try
                    {
                        myiaFm1.Callsp_c2_delete_ia_1(strSyscd, strContNo, strYYYYMM, strPubSeq);
                        //Response.Write("<font size=2>刪除發票開立單成功!</font><br><br>");

                        // 以 Javascript 的 window.alert()  來告知訊息
                        //LiteralControl litAlert1 = new LiteralControl();
                        //litAlert1.Text = "<script language=javascript>alert(\"合約書編號: " + strContNo + " 的發票開立單 刪除成功\");</script>";
                        //Page.Controls.Add(litAlert1);
                    }
                    catch (System.Data.SqlClient.SqlException ex2)
                    {
                        throw new Exception(ex2.Message + " <錯誤區塊:2>");
                        //Response.Write("<font size=2>刪除發票開立單失敗!</font><br><br>");

                        // 以 Javascript 的 window.alert()  來告知訊息
                        //LiteralControl litAlert1 = new LiteralControl();
                        //litAlert1.Text = "<script language=javascript>alert(\"合約書編號: " + strContNo + " 的發票開立單 刪除失敗\");</script>";
                        //Page.Controls.Add(litAlert1);
                    }
                }


                // step3 - 更新 合約資料之 已繳金額 & 剩餘金額 欄位值
                //Response.Write(this.sqlCommand3.CommandText);
                string strNewContPaidAmt = this.lblNewContPaidAmt.Text.ToString().Trim();
                string strNewContRestAmt = this.lblNewContRestAmt.Text.ToString().Trim();
                //Response.Write("strNewContPaidAmt= " + strNewContPaidAmt + ", ");
                //Response.Write("strNewContRestAmt= " + strNewContRestAmt + ", ");
                //Response.Write("strContNo= " + strContNo + "<br>");

                // 確認執行 sqlCommand3 成功
                //Response.Write("sqlCommand3.Parameters.Count= " + sqlCommand3.Parameters.Count.ToString().Trim()+ "<br>");
                try
                {
                    myiaFm1.UDPATEc2_cont(strNewContPaidAmt, strNewContRestAmt, strContNo);
                    //Response.Write("<font size=2>更新合約之已繳金額&剩餘金額成功!</font><br><br>");
                    JavaScript.AlertMessage(this.Page, "合約書編號: " + strContNo + " 之已繳&剩餘金額 更新成功");
                    // 以 Javascript 的 window.alert()  來告知訊息
                }
                catch (System.Data.SqlClient.SqlException ex3)
                {
                    throw new Exception(ex3.Message + " 合約書編號: " + strContNo + " 之已繳&剩餘金額 更新成功失敗");
                    //Response.Write("<font size=2>更新合約之已繳金額&剩餘金額失敗!</font><br><br>");
                }


                // 轉址處理 - 發票開立單檢核表 - 一次付款
                Response.Redirect("iaFm1_chklist.aspx?contno=" + sec.encryptquerystring(strContNo) + "&imseq=" + sec.encryptquerystring(strIMSeq) + "&iano=" + sec.encryptquerystring(strIANo));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnModifyCont_Click(object sender, EventArgs e)
        {

        }

        protected void btnModifyPub_Click(object sender, EventArgs e)
        {

        }
    }
}