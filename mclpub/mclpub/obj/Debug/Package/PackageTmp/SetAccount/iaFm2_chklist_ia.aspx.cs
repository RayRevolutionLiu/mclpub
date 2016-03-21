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
    public partial class iaFm2_chklist_ia : System.Web.UI.Page
    {
        security sec = new security();
        iaFm2_chklist_ia_DB myiaFm2 = new iaFm2_chklist_ia_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GetAction();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void GetAction()
        {
            // 若 strAction 為 1, 顯示查詢選項; 若為 2, 則直接顯示 ia 檢核表內容
            SearchIcon.Visible = false;
            InitialData();
            // 顯示 DataGrid1
            string strBkcd, strIabDate, strIabSeq;
            strBkcd = Context.Request.QueryString["bkcd"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["bkcd"].ToString());
            ddlBkcd.SelectedValue = strBkcd == "" ? "01" : strBkcd;
            strIabDate = Context.Request.QueryString["yyyymm"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["yyyymm"].ToString().Trim());
            tbxYYYYMM.Text = strIabDate == "" ? tbxYYYYMM.Text : strIabDate.Substring(0, 4) + "/" + strIabDate.Substring(4, 2);
            //strAction = Context.Request.QueryString["action"].ToString().Trim();
            strIabSeq = Context.Request.QueryString["iabseq"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["iabseq"].ToString().Trim());
            tbxIabseq.Text = strIabSeq == "" ? tbxIabseq.Text : strIabSeq;


            if (strBkcd == "" && strIabDate == "" && strIabSeq == "")
            {
            }
            else
            {
                BindGrid1();
            }

        }


        // 給 預設值
        private void InitialData()
        {
            this.lblMessage.Text = "";
            this.lblMessage2.Text = "";
            this.btnPrintList.Visible = false;
            //this.btnReQuery.Visible = false;

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
            ddlBkcd.SelectedIndex = 0;

            tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM");
        }


        public DataView GenDataView()
        {
            // 自 ia 抓出 iabdate & iabseq, 以作為篩選條件
            string TodayDate = System.DateTime.Today.ToString("yyyy/MM/dd");
            string strBkcd, strIabDate, strIabSeq;
            strBkcd = Context.Request.QueryString["bkcd"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["bkcd"].ToString());
            strIabDate = Context.Request.QueryString["yyyymm"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["yyyymm"].ToString().Trim());

            strIabSeq = Context.Request.QueryString["iabseq"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["iabseq"].ToString().Trim());
            //Response.Write("strIabDate= " + strIabDate + "<br>");
            //Response.Write("strIabSeq= " + strIabSeq + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myiaFm2.Selectia();
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            if (strIabDate != "")
                rowfilterstr2 = rowfilterstr2 + " AND ia_iabdate='" + strIabDate + "'";
            if (strIabSeq != "")
                rowfilterstr2 = rowfilterstr2 + " AND ia_iabseq='" + strIabSeq + "'";
            dv2.RowFilter = rowfilterstr2;

            return dv2;
        }


        // 顯示 DataGrid1
        private void BindGrid1()
        {
            // 自 ia 抓出 iabdate & iabseq, 以作為篩選條件
            string TodayDate = System.DateTime.Today.ToString("yyyy/MM/dd");
            string strBkcd, strBkName, strIabDate, strIabSeq;
            strBkcd = Context.Request.QueryString["bkcd"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["bkcd"].ToString());
            strIabDate = Context.Request.QueryString["yyyymm"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["yyyymm"].ToString().Trim());

            strIabSeq = Context.Request.QueryString["iabseq"].ToString().Trim() == "" ? "" : sec.decryptquerystring(Context.Request.QueryString["iabseq"].ToString().Trim());
            DataView dv2 = GenDataView();

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
            DataGrid1.DataSource = dv2;
            DataGrid1.DataBind();
            SearchIcon.Visible = true;
            // 若搜尋結果為 "找不到" 的處理
            if (dv2.Count > 0)
            {
                this.btnPrintList.Visible = true;
                //this.btnReQuery.Visible = false;
                // 抓出相關資訊
                string strIabDate1 = strIabDate == "" ? "" : strIabDate.Substring(0, 4) + "/" + strIabDate.Substring(4, 2);
                string strIabDateNew = strIabDate;
                strIabDateNew = strIabDate == "" ? "" : strIabDate.Substring(0, 4) + "/" + strIabDate.Substring(4, 2);
                //string strIabEmpNo = dv2[0]["iab_createmen"].ToString().Trim();
                //string strIabEmpName = dv2[0]["srspn_cname"].ToString().Trim();
                //Response.Write("strIabDate1= " + strIabDate1 + "<br>");
                //Response.Write("strIabDateNew= " + strIabDateNew + "<br>");
                //Response.Write("strIabEmpNo= " + strIabEmpNo + "<br>");
                //Response.Write("strIabEmpName= " + strIabEmpName + "<br>");


                // 顯示總筆數
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds1 = myiaFm2.Selectbook();
                DataView dv1 = ds1.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr1 = "1=1";
                rowfilterstr1 = rowfilterstr1 + " AND bk_bkcd='" + strBkcd + "'";
                if (dv1.Count > 0)
                {
                    strBkName = dv1[0]["bk_nm"].ToString().Trim();
                }
                else
                {
                    strBkName = "";
                }
                //Response.Write("strBkName= " + strBkName + "<br>");

                lblMessage2.Text = strIabDateNew + "開立的資料為：" + strBkName + " " + strIabDate1 + "月，發票開立單批號為：" + strIabSeq + "；共開立了 " + dv2.Count.ToString().Trim() + " 筆明細資料";


                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
            }
            else
            {
                //btnReQuery.Visible = true;
                btnPrintList.Visible = false;
            }
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (tbxYYYYMM.Text.Length != 7 && tbxYYYYMM.Text.IndexOf("/") == 4)
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }

            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string strSort = this.ddlOrderByFilter.SelectedItem.Value.ToString().Trim();
            string strIabSeq = this.tbxIabseq.Text.ToString();


            // 轉址 - 直接顯示 ia 檢核表
            string strbuf = "iaFm2_chklist_ia.aspx?bkcd=" + sec.encryptquerystring(strBkcd) + "&yyyymm=" + sec.encryptquerystring(strYYYYMM) + "&sort=" + sec.encryptquerystring(strSort) + "&action=2&iabseq=" + sec.encryptquerystring(strIabSeq);
            Response.Redirect(strbuf);
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            DataView dv = GenDataView();

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/SetAccount/template/iaFm2_list2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A7:S7");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A8:S8");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:S1");

            if (dv.Count == 1)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (dv.Count > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 9; i < dv.Count + 9 - 2; i++)
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
            Xls.SetCellValue(5, 4, tbxIabseq.Text.Trim());
            Xls.SetCellValue(4, 18, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(5, 18, DateTime.Now.ToString("yyyy/MM/dd"));

            string preNo = "";
            int iad_qty = 0;
            int iad_amt = 0;
            int count = 0;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["ia_iano"].ToString().Trim() == preNo)
                {
                    Xls.SetCellValue(i + 7, 1, "");
                    Xls.SetCellValue(i + 7, 2, "");
                }
                else
                {
                    Xls.SetCellValue(i + 7, 1, count+1);         
                    Xls.SetCellValue(i + 7, 2, dv[i]["ia_iano"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 3, dv[i]["ia_mfrno"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 4, dv[i]["mfr_inm"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 5, dv[i]["ia_rnm"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 6, dv[i]["ia_rjbti"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 7, dv[i]["ia_rzip"].ToString().Trim() + " " + dv[i]["ia_raddr"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 8, dv[i]["ia_rtel"].ToString().Trim());
                    count += 1;
                }

                Xls.SetCellValue(i + 7, 9, dv[i]["ia_invcdText"].ToString().Trim());
                Xls.SetCellValue(i + 7, 10, dv[i]["ia_taxtpText"].ToString().Trim());
                Xls.SetCellValue(i + 7, 11, dv[i]["iad_iaditem"].ToString().Trim());
                Xls.SetCellValue(i + 7, 12, dv[i]["iad_fk1"].ToString().Trim());
                Xls.SetCellValue(i + 7, 13, dv[i]["iad_fk2"].ToString().Trim());
                Xls.SetCellValue(i + 7, 14, dv[i]["iad_fk3"].ToString().Trim());
                Xls.SetCellValue(i + 7, 15, dv[i]["iad_desc"].ToString().Trim());
                Xls.SetCellValue(i + 7, 16, dv[i]["iad_projno"].ToString().Trim());
                Xls.SetCellValue(i + 7, 17, dv[i]["iad_costctr"].ToString().Trim());
                Xls.SetCellValue(i + 7, 18, dv[i]["iad_qty"].ToString().Trim());
                Xls.SetCellValue(i + 7, 19, dv[i]["iad_amt"].ToString().Trim());

                iad_qty += Convert.ToInt32(dv[i]["iad_qty"].ToString().Trim());
                iad_amt += Convert.ToInt32(dv[i]["iad_amt"].ToString().Trim());
                preNo = dv[i]["ia_iano"].ToString().Trim();
            }

            Xls.InsertAndCopyRange(myRangeTotal, dv.Count + 7 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dv.Count + 7 + 1, 18, iad_qty);
            Xls.SetCellValue(dv.Count + 7 + 1, 19, iad_amt);

            Common.excuteExcel(Xls, "iaFm2_list2.xls");
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 發票類別
                string invcd = e.Row.Cells[8].Text.ToString().Trim();
                //Response.Write("invcd= " + invcd + "<br>");
                switch (invcd)
                {
                    case "2":
                        e.Row.Cells[8].Text = "二聯";
                        break;
                    case "3":
                        e.Row.Cells[8].Text = "三聯";
                        break;
                    case "4":
                        e.Row.Cells[8].Text = "其他";
                        break;
                    case "9":
                        e.Row.Cells[8].Text = "不清楚";
                        e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        e.Row.Cells[8].Text = "三聯";
                        break;
                }

                // 發票課稅別
                string taxtp = e.Row.Cells[9].Text.ToString().Trim();
                //Response.Write("taxtp= " + taxtp + "<br>");
                switch (taxtp)
                {
                    case "1":
                        e.Row.Cells[9].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[9].Text = "零稅";
                        break;
                    case "3":
                        e.Row.Cells[9].Text = "免稅";
                        break;
                    case "9":
                        e.Row.Cells[9].Text = "不清楚";
                        e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                        break;
                    default:
                        e.Row.Cells[9].Text = "應稅5%";
                        break;
                }
            }
        }
    }
}