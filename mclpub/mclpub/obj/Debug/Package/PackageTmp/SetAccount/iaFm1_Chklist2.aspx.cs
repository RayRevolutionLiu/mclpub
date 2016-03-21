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
    public partial class iaFm1_Chklist2 : System.Web.UI.Page
    {
        iaFm2_Addia_DB myiaFm2 = new iaFm2_Addia_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialData();
                SearchIcon.Visible = false;
            }
        }

        private void InitialData()
        {
            this.lblMessage.Text = "";
            this.btnPrintList.Visible = false;

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
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindGrid1();
        }

        // 顯示 DataGrid1
        private void BindGrid1()
        {

            DataView dv2 = BindView();
            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
            SearchIcon.Visible = true;
            DataGrid1.DataSource = dv2;
            DataGrid1.DataBind();
            // 若搜尋結果為 "找不到" 的處理
            if (dv2.Count > 0)
            {
                this.btnPrintList.Visible = true;
            }
            else
            {
                this.btnPrintList.Visible = false;
            }
        }


        public DataView BindView()
        {
            // 抓出篩選條件
            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myiaFm2.SelectiaChklist2();
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";
            rowfilterstr2 = rowfilterstr2 + " AND iad_fk2='" + strYYYYMM + "'";
            dv2.RowFilter = rowfilterstr2;
            return dv2;
        }

        public DataView CountDistinctia_iano()
        {
            // 抓出篩選條件
            string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myiaFm2.CountDistinctia_iano(strBkcd, strYYYYMM);
            DataView dv = ds2.Tables[0].DefaultView;
            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            return dv;
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            DataView dv = BindView();
            DataView dvCount = CountDistinctia_iano();

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/SetAccount/template/iaFm2_list2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A7:S7");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A8:S8");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:S1");

            if (dv.Count + dvCount.Count == 1)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (dv.Count + dvCount.Count > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 8; i < dv.Count + 8 - 2 + dvCount.Count; i++)
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

            Xls.SetCellValue(1, 2, "發票開立單 檢核表 -- 一次付款(當月刊登清單) ");
            Xls.SetCellValue(3, 4, ddlBkcd.SelectedItem.Text.ToString());
            Xls.SetCellValue(4, 4, tbxYYYYMM.Text.Trim());
            Xls.SetCellValue(5, 3, "");
            Xls.SetCellValue(4, 18, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(5, 18, DateTime.Now.ToString("yyyy/MM/dd"));

            string preNo = "";
            int iad_qty = 0;
            int iad_amt = 0;
            int count = 0;
            int Xvalue = 0;
            int sum_totamt = 0;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["ia_iano"].ToString().Trim() != preNo)
                {
                    if (Xvalue != 0)
                    {
                        Xls.SetCellValue(Xvalue + 7, 1, "");
                        Xls.SetCellValue(Xvalue + 7, 2, "");
                        Xls.SetCellValue(Xvalue + 7, 3, "");
                        Xls.SetCellValue(Xvalue + 7, 4, "");
                        Xls.SetCellValue(Xvalue + 7, 5, "");
                        Xls.SetCellValue(Xvalue + 7, 6, "");
                        Xls.SetCellValue(Xvalue + 7, 7, "");
                        Xls.SetCellValue(Xvalue + 7, 8, "");
                        Xls.SetCellValue(Xvalue + 7, 9, "");
                        Xls.SetCellValue(Xvalue + 7, 10, "");
                        Xls.SetCellValue(Xvalue + 7, 11, "");
                        Xls.SetCellValue(Xvalue + 7, 12, "");
                        Xls.SetCellValue(Xvalue + 7, 13, "");
                        Xls.SetCellValue(Xvalue + 7, 14, "");
                        Xls.SetCellValue(Xvalue + 7, 15, "");
                        Xls.SetCellValue(Xvalue + 7, 16, "");
                        Xls.SetCellValue(Xvalue + 7, 17, "小計：");
                        Xls.SetCellValue(Xvalue + 7, 18, sum_totamt);
                        Xls.SetCellValue(Xvalue + 7, 19, "");
                        Xvalue++;
                    }


                    Xls.SetCellValue(i + 7, 1, count + 1);
                    count++;
                    Xls.SetCellValue(Xvalue + 7, 2, dv[i]["ia_iano"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 3, dv[i]["ia_mfrno"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 4, dv[i]["mfr_inm"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 5, dv[i]["ia_rnm"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 6, dv[i]["ia_rjbti"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 7, dv[i]["ia_rzip"].ToString().Trim() + " " + dv[i]["ia_raddr"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 8, dv[i]["ia_rtel"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 9, dv[i]["ia_invcdText"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 10, dv[i]["ia_taxtpText"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 11, dv[i]["iad_iaditem"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 12, dv[i]["iad_fk1"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 13, dv[i]["iad_fk2"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 14, dv[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 15, dv[i]["iad_desc"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 16, dv[i]["iad_projno"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 17, dv[i]["iad_costctr"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 18, dv[i]["iad_qty"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 19, dv[i]["iad_amt"].ToString().Trim());
                    Xvalue++;
                    sum_totamt += Convert.ToInt32(dv[i]["iad_amt"].ToString().Trim());

                }
                else
                {
                    Xls.SetCellValue(Xvalue + 7, 1, "");
                    Xls.SetCellValue(Xvalue + 7, 2, "");
                    Xls.SetCellValue(Xvalue + 7, 3, "");
                    Xls.SetCellValue(Xvalue + 7, 4, "");
                    Xls.SetCellValue(Xvalue + 7, 5, "");
                    Xls.SetCellValue(Xvalue + 7, 6, "");
                    Xls.SetCellValue(Xvalue + 7, 7, "");
                    Xls.SetCellValue(Xvalue + 7, 8, "");
                    Xls.SetCellValue(Xvalue + 7, 9, dv[i]["ia_invcdText"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 10, dv[i]["ia_taxtpText"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 11, dv[i]["iad_iaditem"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 12, dv[i]["iad_fk1"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 13, dv[i]["iad_fk2"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 14, dv[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 15, dv[i]["iad_desc"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 16, dv[i]["iad_projno"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 17, dv[i]["iad_costctr"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 18, dv[i]["iad_qty"].ToString().Trim());
                    Xls.SetCellValue(Xvalue + 7, 19, dv[i]["iad_amt"].ToString().Trim());
                    Xvalue++;
                }

                if (i == dv.Count - 1)
                {
                    Xls.SetCellValue(Xvalue + 7, 1, "");
                    Xls.SetCellValue(Xvalue + 7, 2, "");
                    Xls.SetCellValue(Xvalue + 7, 3, "");
                    Xls.SetCellValue(Xvalue + 7, 4, "");
                    Xls.SetCellValue(Xvalue + 7, 5, "");
                    Xls.SetCellValue(Xvalue + 7, 6, "");
                    Xls.SetCellValue(Xvalue + 7, 7, "");
                    Xls.SetCellValue(Xvalue + 7, 8, "");
                    Xls.SetCellValue(Xvalue + 7, 9, "");
                    Xls.SetCellValue(Xvalue + 7, 10, "");
                    Xls.SetCellValue(Xvalue + 7, 11, "");
                    Xls.SetCellValue(Xvalue + 7, 12, "");
                    Xls.SetCellValue(Xvalue + 7, 13, "");
                    Xls.SetCellValue(Xvalue + 7, 14, "");
                    Xls.SetCellValue(Xvalue + 7, 15, "");
                    Xls.SetCellValue(Xvalue + 7, 16, "");
                    Xls.SetCellValue(Xvalue + 7, 17, "");
                    Xls.SetCellValue(Xvalue + 7, 18, "小計：");
                    Xls.SetCellValue(Xvalue + 7, 19, sum_totamt);
                    Xvalue++;
                }
                
                iad_qty += Convert.ToInt32(dv[i]["iad_qty"].ToString().Trim());
                iad_amt += Convert.ToInt32(dv[i]["iad_amt"].ToString().Trim());
                preNo = dv[i]["ia_iano"].ToString().Trim();
            }

            Xls.InsertAndCopyRange(myRangeTotal, Xvalue + 7 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(Xvalue + 7 + 1, 18, iad_qty);
            Xls.SetCellValue(Xvalue + 7 + 1, 19, iad_amt);

            Common.excuteExcel(Xls, "iaFm2_list2b.xls");
        }
    }
}