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

namespace mclpub.Layout
{
    public partial class adpub_form : System.Web.UI.Page
    {
        adpub_form_DB myadpub = new adpub_form_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialData();
                SearchIcon.Visible = false;
                Lkdownload.Visible = false;
                lblMessage.Visible = false;
                lblMessageAfter.Visible = false;
            }
        }

        // 給預設值
        private void InitialData()
        {
            this.lblMessage.Text = "";

            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds1 = myadpub.SelectBook();
            DataView dv1 = ds1.Tables[0].DefaultView;
            ddlBookCode.DataSource = dv1;
            dv1.RowFilter = "proj_fgitri=''";
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();

            this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");

        }

        protected void lnbClearAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("adpub_form.aspx");
        }

        protected void lnbShow_Click(object sender, EventArgs e)
        {
            CountPubData();
        }

        // 計算是否有該月的落版資料, 若有則提供連結串接
        private DataView CountPubData()
        {
            SearchIcon.Visible = true;
            // 抓出 網頁變數
            string bkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
            if (yyyyymm.Length >= 6)
            {
                yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);
            }

            DataSet ds2 = myadpub.Selectc2_pub(yyyyymm, bkcd);
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            dv2.RowFilter = rowfilterstr2;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

            // 若有資料須修正時, 顯示 DataGrid1
            if (dv2.Count > 0)
            {
                
                Lkdownload.Visible = true;
                lblMessage.Visible = true;
                lblMessageAfter.Visible = true;
                lblMessage.Text = "結果: 找到 <B>" + dv2.Count + "</B>筆落版資料; 請繼續按";
                lblMessageAfter.Text = "來繼續進行下一動作!<br>";
            }
            else
            {
                lblMessage.Visible = true;
                Lkdownload.Visible = false;
                lblMessageAfter.Visible = false;
                this.lblMessage.Text = "很抱歉, 本月無落版資料！";
            }

            return dv2;
        }

        protected void Lkdownload_Click(object sender, EventArgs e)
        {
            DataView dv = CountPubData();

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Layout/Template/adpub_form2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A6:T6");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A7:T7");

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
                    for (int i = 8; i < dv.Count + 8 - 2; i++)
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

            Xls.SetCellValue(1, 15, tbxPubDate.Text.Trim());//刊登年月20
            Xls.SetCellValue(1, 11, ddlBookCode.SelectedItem.Text);//工材
            Xls.SetCellValue(3, 20, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(4, 20, DateTime.Now.ToString("yyyy/MM/dd"));
            string contno = "";
            int tagNum = 0;
            for (int i = 0; i < dv.Count; i++)
            {
                if (contno == dv[i]["pub_contno"].ToString())
                {
                    Xls.SetCellValue(i + 6, 1, "");
                    Xls.SetCellValue(i + 6, 2, "");
                    tagNum--;
                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, tagNum + 1);
                    Xls.SetCellValue(i + 6, 2, dv[i]["pub_contno"].ToString());
                    Xls.SetCellValue(i + 6, 3, dv[i]["pub_pubseq"].ToString());
                    Xls.SetCellValue(i + 6, 4, dv[i]["pub_pgno"].ToString());
                    Xls.SetCellValue(i + 6, 5, dv[i]["ltp_nm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dv[i]["clr_nm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dv[i]["pgs_nm"].ToString());
                    Xls.SetCellValue(i + 6, 8, dv[i]["pub_fgfixpg"].ToString());
                    Xls.SetCellValue(i + 6, 9, dv[i]["mfr_inm"].ToString());

                    if (dv[i]["pub_drafttp"].ToString() == "2")
                    {
                        Xls.SetCellValue(i + 6, 10, dv[i]["pub_fggot"].ToString());
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 10, "");
                    }

                    Xls.SetCellValue(i + 6, 11, dv[i]["njtp_nm"].ToString());

                    if (dv[i]["pub_chgbkcd"].ToString() == "")
                    {
                        DataSet ds = myadpub.SelectBookExport(dv[i]["pub_chgbkcd"].ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Xls.SetCellValue(i + 6, 12, ds.Tables[0].Rows[0]["bk_nm"].ToString());
                        }
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 12, "");
                    }

                    Xls.SetCellValue(i + 6, 13, dv[i]["pub_chgjno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dv[i]["pub_chgjbkno"].ToString());
                    Xls.SetCellValue(i + 6, 15, dv[i]["pub_fgrechg"].ToString());
                    Xls.SetCellValue(i + 6, 16, dv[i]["bk_nm"].ToString());
                    Xls.SetCellValue(i + 6, 17, dv[i]["pub_origjno"].ToString());
                    Xls.SetCellValue(i + 6, 18, dv[i]["pub_origjbkno"].ToString());
                    Xls.SetCellValue(i + 6, 19, dv[i]["srspn_cname"].ToString());
                    Xls.SetCellValue(i + 6, 20, dv[i]["pub_remark"].ToString());

                }



                Xls.SetCellValue(i + 6, 3, dv[i]["pub_pubseq"].ToString());
                Xls.SetCellValue(i + 6, 4, dv[i]["pub_pgno"].ToString());
                Xls.SetCellValue(i + 6, 5, dv[i]["ltp_nm"].ToString());
                Xls.SetCellValue(i + 6, 6, dv[i]["clr_nm"].ToString());
                Xls.SetCellValue(i + 6, 7, dv[i]["pgs_nm"].ToString());
                Xls.SetCellValue(i + 6, 8, dv[i]["pub_fgfixpg"].ToString());
                Xls.SetCellValue(i + 6, 9, dv[i]["mfr_inm"].ToString());

                if (dv[i]["pub_drafttp"].ToString() == "2")
                {
                    Xls.SetCellValue(i + 6, 10, dv[i]["pub_fggot"].ToString());
                    Xls.SetCellValue(i + 6, 11, dv[i]["njtp_nm"].ToString());

                    Xls.SetCellValue(i + 6, 12, "");
                    Xls.SetCellValue(i + 6, 13, "");
                    Xls.SetCellValue(i + 6, 14, "");
                    Xls.SetCellValue(i + 6, 15, "");
                    Xls.SetCellValue(i + 6, 16, "");
                    Xls.SetCellValue(i + 6, 17, "");
                    Xls.SetCellValue(i + 6, 18, "");

                }
                else
                {
                    Xls.SetCellValue(i + 6, 10, "");
                    Xls.SetCellValue(i + 6, 11, "");
                }

                if (dv[i]["pub_drafttp"].ToString() == "3")
                {
                    Xls.SetCellValue(i + 6, 10, dv[i]["pub_fggot"].ToString());
                    if (dv[i]["pub_chgbkcd"].ToString() != "")
                    {
                        DataSet ds = myadpub.SelectBookExport(dv[i]["pub_chgbkcd"].ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Xls.SetCellValue(i + 6, 12, ds.Tables[0].Rows[0]["bk_nm"].ToString());
                        }
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 12, "");
                    }

                    Xls.SetCellValue(i + 6, 13, dv[i]["pub_chgjno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dv[i]["pub_chgjbkno"].ToString());
                    Xls.SetCellValue(i + 6, 15, dv[i]["pub_fgrechg"].ToString());

                    Xls.SetCellValue(i + 6, 11, "");
                    Xls.SetCellValue(i + 6, 16, "");
                    Xls.SetCellValue(i + 6, 17, "");
                    Xls.SetCellValue(i + 6, 18, "");
                }
                else
                {
                    Xls.SetCellValue(i + 6, 12, "");
                    Xls.SetCellValue(i + 6, 13, "");
                    Xls.SetCellValue(i + 6, 14, "");
                    Xls.SetCellValue(i + 6, 15, "");
                }


                if (dv[i]["pub_drafttp"].ToString() == "1")
                {
                    Xls.SetCellValue(i + 6, 16, dv[i]["bk_nm"].ToString());
                    Xls.SetCellValue(i + 6, 17, dv[i]["pub_origjno"].ToString());
                    Xls.SetCellValue(i + 6, 18, dv[i]["pub_origjbkno"].ToString());

                    Xls.SetCellValue(i + 6, 10, "");
                    Xls.SetCellValue(i + 6, 11, "");
                    Xls.SetCellValue(i + 6, 12, "");
                    Xls.SetCellValue(i + 6, 13, "");
                    Xls.SetCellValue(i + 6, 14, "");
                    Xls.SetCellValue(i + 6, 15, "");

                }
                else
                {
                    Xls.SetCellValue(i + 6, 16, "");
                    Xls.SetCellValue(i + 6, 17, "");
                    Xls.SetCellValue(i + 6, 18, "");
                }


                Xls.SetCellValue(i + 6, 19, dv[i]["srspn_cname"].ToString());
                Xls.SetCellValue(i + 6, 20, dv[i]["pub_remark"].ToString());
                tagNum++;
                contno = dv[i]["pub_contno"].ToString();
            }




                Common.excuteExcel(Xls, "adpub_form2.xls");
        }
    }
}