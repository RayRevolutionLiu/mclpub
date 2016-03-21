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
    public partial class iaFm2_RecAll : System.Web.UI.Page
    {
        iaFm2_RecAll_DB myiaFm2 = new iaFm2_RecAll_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnRecovery.Visible = false;
                this.btnPrintList.Visible = false;
                SearchIcon.Visible = false;
                this.tbxIabDate.Text = System.DateTime.Today.ToString("yyyy/MM");
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (tbxIabDate.Text.Trim() != "" && tbxIabNo.Text.Trim() != "")
            {
                if (tbxIabDate.Text.Trim().IndexOf("/") == 4)
                {
                    BindGrid1();
                }
                else
                {
                    JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                }
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "很抱歉, 您必須輸入查詢條件, 才能繼續!");
                return;
            }
        }


        public DataView GenTable()
        {
            // 抓出畫面上的值
            string strIabDate = this.tbxIabDate.Text.ToString().Trim();
            strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
            string strIabSeq = this.tbxIabNo.Text.ToString().Trim();
            //Response.Write("strIabDate= " + strIabDate + "<br>");
            //Response.Write("strIabSeq= " + strIabSeq + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myiaFm2.Selectia();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            if (strIabDate != "")
                rowfilterstr1 = rowfilterstr1 + " AND ia_iabdate = '" + strIabDate + "'";
            if (strIabSeq != "")
                rowfilterstr1 = rowfilterstr1 + " AND ia_iabseq = '" + strIabSeq + "'";
            dv1.RowFilter = rowfilterstr1;

            return dv1;
        }

        // 顯示 DataGrid1
        private void BindGrid1()
        {
            SearchIcon.Visible = true;
            DataView dv1 = GenTable();
            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
            DataGrid1.DataSource = dv1;
            DataGrid1.DataBind();

            if (dv1.Count > 0)
            {
                this.DataGrid1.Visible = true;
                this.btnRecovery.Visible = true;
                this.btnPrintList.Visible = true;
            }
            else
            {
                this.btnRecovery.Visible = false;
                this.btnPrintList.Visible = false;
            }
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
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

                // 刊登年月
                string yyyymm = e.Row.Cells[12].Text.ToString().Trim();
                //Response.Write("yyyymm= " + yyyymm + "<br>");
                yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
                e.Row.Cells[12].Text = yyyymm;
            }
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            DataView dv = GenTable();

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
                    for (int i = 8; i < dv.Count + 8 - 2 ; i++)
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

            Xls.SetCellValue(1, 2, "發票開立單 回復清單 -- 大批月結 ");
            Xls.SetCellValue(3, 3, "");
            Xls.SetCellValue(4, 4, tbxIabDate.Text.Trim());
            Xls.SetCellValue(5, 4, tbxIabNo.Text.Trim());
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
                    Xls.SetCellValue(i + 7, 3, "");
                    Xls.SetCellValue(i + 7, 4, "");
                    Xls.SetCellValue(i + 7, 5, "");
                    Xls.SetCellValue(i + 7, 6, "");
                    Xls.SetCellValue(i + 7, 7, "");
                    Xls.SetCellValue(i + 7, 8, "");
                    Xls.SetCellValue(i + 7, 9, "");
                    Xls.SetCellValue(i + 7, 10, "");
                    Xls.SetCellValue(i + 7, 11, "");
                    Xls.SetCellValue(i + 7, 12, "");
                }
                else
                {
                    Xls.SetCellValue(i + 7, 1, count + 1);
                    Xls.SetCellValue(i + 7, 2, dv[i]["ia_iano"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 3, dv[i]["ia_mfrno"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 4, dv[i]["mfr_inm"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 5, dv[i]["ia_rnm"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 6, dv[i]["ia_rjbti"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 7, dv[i]["ia_rzip"].ToString().Trim() + " " + dv[i]["ia_raddr"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 8, dv[i]["ia_rtel"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 9, dv[i]["ia_invcdText"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 10, dv[i]["ia_taxtpText"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 11, dv[i]["iad_iaditem"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 12, dv[i]["iad_fk1"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 13, dv[i]["iad_fk2"].ToString().Trim().Substring(0, 4) + "/" + dv[i]["iad_fk2"].ToString().Trim().Substring(4, 2));
                    Xls.SetCellValue(i + 7, 14, dv[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 15, dv[i]["iad_desc"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 16, dv[i]["iad_projno"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 17, dv[i]["iad_costctr"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 18, dv[i]["iad_qty"].ToString().Trim());
                    Xls.SetCellValue(i + 7, 19, dv[i]["iad_amt"].ToString().Trim());
                    count += 1;
                }

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

            Common.excuteExcel(Xls, "iaFm2_RecList.xls");
        }

        protected void btnRecovery_Click(object sender, EventArgs e)
        {
            if (tbxIabDate.Text.Trim().IndexOf("/") != 4)
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }

            // 抓出畫面上的值
            string strIabDate = this.tbxIabDate.Text.ToString().Trim();
            strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
            string strIabSeq = this.tbxIabNo.Text.ToString().Trim();
            //Response.Write("strIabDate= " + strIabDate + "<br>");
            //Response.Write("strIabSeq= " + strIabSeq + "<br>");


            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                // 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
                try
                {
                    myiaFm2.Runsp_c2_delete_ia_all(strIabDate, strIabSeq);

                    this.DataGrid1.Visible = false;
                    this.btnRecovery.Visible = false;
                    this.btnPrintList.Visible = false;
                }
                catch (System.Data.SqlClient.SqlException ex1)
                {
                    throw new Exception(ex1.Message);
                }
                finally
                {
                    BindGrid1();
                    JavaScript.AlertMessage(this.Page, "回復成功");
                }
            }
        }
    }
}