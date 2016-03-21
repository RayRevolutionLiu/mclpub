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
    public partial class admade_stat : System.Web.UI.Page
    {
        admade_stat_DB myadmade = new admade_stat_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                Lkdownload.Visible = false;
                lblMessage.Visible = false;
                lblMessageAfter.Visible = false;

                tbxyyyymm.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();

                DataSet ds1 = myadmade.Selectsrspn();
                DataRow dr = ds1.Tables[0].NewRow();
                dr["srspn_empno"] = "000000";
                dr["srspn_cname"] = "請選擇";
                ds1.Tables[0].Rows.Add(dr);
                ds1.Tables[0].DefaultView.Sort = "srspn_empno ASC";

                DataView dv = ds1.Tables[0].DefaultView;
                ddlEmpNo.DataSource = dv;
                ddlEmpNo.DataTextField = "srspn_cname";
                ddlEmpNo.DataValueField = "srspn_empno";
                ddlEmpNo.DataBind();

                if (Account.GetAccInfo().srspn_atype.ToString().Trim() != "" && Account.GetAccInfo().srspn_atype != null)
                {
                    if (Account.GetAccInfo().srspn_atype.ToString().Trim() == "D")
                    {
                        ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
                        ddlEmpNo.Enabled = false;
                    }
                }

                DataSet ds2 = myadmade.SelectBook();
                DataView dv2 = ds2.Tables[0].DefaultView;
                ddlBookCode.DataSource = dv2;
                dv2.RowFilter = "proj_fgitri=''";
                ddlBookCode.DataTextField = "bk_nm";
                //ddlBookCode.DataValueField="nostr";
                // 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
                ddlBookCode.DataValueField = "bk_bkcd";
                ddlBookCode.DataBind();
            
            }
        }

        protected void lnbShow_Click(object sender, EventArgs e)
        {
            ExecGetadSP();
        }

        // 呼叫 Stored Procedures, 產生 wk_c2_rp2
        private DataView ExecGetadSP()
        {
            // 抓出畫面上的值, 來當成篩選條件
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxyyyymm.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string strEmpNo = ddlEmpNo.SelectedItem.Value.ToString().Trim() == "000000" ? "" : ddlEmpNo.SelectedItem.Value.ToString().Trim();
            //Response.Write("strBkcd= " + strBkcd + "<BR>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<BR>");
            //Response.Write("strEmpNo= " + strEmpNo + "<BR>");
            //Response.Write("strLoginEmpNo= " + strLoginEmpNo + "<BR>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myadmade.wk_c2_rp2(strBkcd, strYYYYMM, strEmpNo);
            DataView dv3 = ds3.Tables[0].DefaultView;


            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv3.Count > 0)
            {
                Lkdownload.Visible = true;
                lblMessage.Visible = true;
                lblMessageAfter.Visible = true;
                lblMessage.Text = "結果: 找到 <B>" + dv3.Count + "</B>筆落版資料; 請繼續按";
                lblMessageAfter.Text = "來繼續進行下一動作!<br>";
            }
            else
            {
                lblMessage.Visible = true;
                Lkdownload.Visible = false;
                lblMessageAfter.Visible = false;
                this.lblMessage.Text = "找不到符合條件的資料, 您可以 重設條件！";
            }

            return dv3;
        }

        protected void lnbClearAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("admade_stat.aspx");
        }

        protected void Lkdownload_Click(object sender, EventArgs e)
        {
            DataView dv = ExecGetadSP();

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Layout/Template/admade_stat2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A7:Y7");
            TXlsCellRange myRange2 = new TXlsCellRange("A1:Y4");

            for (int i = 8; i < dv.Count + 3 + 7; i++)//因為彩色 套色 黑白各一個小計 所以要+3
            {
                Xls.InsertAndCopyRange(myRange, i, 1, 1, TFlxInsertMode.NoneDown);
            }

            Xls.SetCellValue(1, 17, tbxyyyymm.Text.Trim());//刊登年月20
            Xls.SetCellValue(1, 11, ddlBookCode.SelectedItem.Text);//工材
            Xls.SetCellValue(3, 24, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(4, 24, DateTime.Now.ToString("yyyy/MM/dd"));

            Xls.InsertAndCopyRange(myRange2, dv.Count + 7 + 3 + 3, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 3);


            int flag = 7;
            int firstCol = 1;

            int sum_njtpcd01 = 0;
            int sum_njtpcd02 = 0;
            int sum_njtpcd03 = 0;
            int sum_njtpcd04 = 0;
            int sum_njtpcd05 = 0;
            int sum_fgrechg = 0;
            int sum_unfgrechg = 0;
            int sum_fgupdated = 0;
            int sum_total = 0;

            int Tsum_njtpcd01 = 0;
            int Tsum_njtpcd02 = 0;
            int Tsum_njtpcd03 = 0;
            int Tsum_njtpcd04 = 0;
            int Tsum_njtpcd05 = 0;
            int Tsum_fgrechg = 0;
            int Tsum_unfgrechg = 0;
            int Tsum_fgupdated = 0;

            string clr = dv[0]["clr_nm"].ToString();
            string contno = dv[0]["contno"].ToString();

            for (int count = 0; count < dv.Count; count++)
            {
                if (dv[count]["clr_nm"].ToString() != clr)
                {
                    Xls.SetCellValue(flag, 1, "");
                    Xls.SetCellValue(flag, 2, "----------");
                    Xls.SetCellValue(flag, 3, "-----");
                    Xls.SetCellValue(flag, 4, "-----");
                    Xls.SetCellValue(flag, 5, "小計：");
                    Xls.SetCellValue(flag, 6, sum_total);
                    Xls.SetCellValue(flag, 7, "-----");
                    Xls.SetCellValue(flag, 8, "-----");
                    Xls.SetCellValue(flag, 9, "----------------------------------------");
                    Xls.SetCellValue(flag, 10, "-----");
                    Xls.SetCellValue(flag, 11, sum_njtpcd01);
                    Xls.SetCellValue(flag, 12, sum_njtpcd02);
                    Xls.SetCellValue(flag, 13, sum_njtpcd03);
                    Xls.SetCellValue(flag, 14, sum_njtpcd04);
                    Xls.SetCellValue(flag, 15, sum_njtpcd05);
                    Xls.SetCellValue(flag, 16, "-----");
                    Xls.SetCellValue(flag, 17, "-----");
                    Xls.SetCellValue(flag, 18, "-----");
                    Xls.SetCellValue(flag, 19, sum_fgrechg);
                    Xls.SetCellValue(flag, 20, sum_unfgrechg);
                    Xls.SetCellValue(flag, 21, "-----");
                    Xls.SetCellValue(flag, 22, "-----");
                    Xls.SetCellValue(flag, 23, "-----");
                    Xls.SetCellValue(flag, 24, sum_fgupdated);
                    Xls.SetCellValue(flag, 25, "----------");

                    sum_njtpcd01 = 0;
                    sum_njtpcd02 = 0;
                    sum_njtpcd03 = 0;
                    sum_njtpcd04 = 0;
                    sum_njtpcd05 = 0;
                    sum_fgrechg = 0;
                    sum_unfgrechg = 0;
                    sum_fgupdated = 0;
                    sum_total = 0;
                    //給了他小計 還要把現在這筆給放下去
                    flag++;

                    Xls.SetCellValue(flag, 1, firstCol);
                    Xls.SetCellValue(flag, 2, dv[count]["contno"].ToString());

                    Xls.SetCellValue(flag, 3, dv[count]["pubseq"].ToString());
                    Xls.SetCellValue(flag, 4, dv[count]["pgno"].ToString());
                    Xls.SetCellValue(flag, 5, dv[count]["ltp_nm"].ToString());
                    Xls.SetCellValue(flag, 6, dv[count]["clr_nm"].ToString());
                    Xls.SetCellValue(flag, 7, dv[count]["pgs_nm"].ToString());
                    Xls.SetCellValue(flag, 8, dv[count]["fgfixpg"].ToString());
                    Xls.SetCellValue(flag, 9, dv[count]["mfr_inm"].ToString());
                    if (dv[count]["drafttp"].ToString() == "2" || dv[count]["drafttp"].ToString() == "3")
                    {
                        Xls.SetCellValue(flag, 10, dv[count]["fggot"].ToString());
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 10, "");
                    }

                    if (dv[count]["drafttp"].ToString() == "2")
                    {
                        Xls.SetCellValue(flag, 11, dv[count]["njtpcd01"].ToString());
                        Xls.SetCellValue(flag, 12, dv[count]["njtpcd02"].ToString());
                        Xls.SetCellValue(flag, 13, dv[count]["njtpcd03"].ToString());
                        Xls.SetCellValue(flag, 14, dv[count]["njtpcd04"].ToString());
                        Xls.SetCellValue(flag, 15, dv[count]["njtpcd05"].ToString());
                        Xls.SetCellValue(flag, 16, "");
                        Xls.SetCellValue(flag, 17, "");
                        Xls.SetCellValue(flag, 18, "");
                        Xls.SetCellValue(flag, 19, "");
                        Xls.SetCellValue(flag, 20, "");
                        Xls.SetCellValue(flag, 21, "");
                        Xls.SetCellValue(flag, 22, "");
                        Xls.SetCellValue(flag, 23, "");
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 11, "");
                        Xls.SetCellValue(flag, 12, "");
                        Xls.SetCellValue(flag, 13, "");
                        Xls.SetCellValue(flag, 14, "");
                        Xls.SetCellValue(flag, 15, "");
                    }
                    if (dv[count]["drafttp"].ToString() == "3")
                    {
                        Xls.SetCellValue(flag, 11, "");
                        Xls.SetCellValue(flag, 12, "");
                        Xls.SetCellValue(flag, 13, "");
                        Xls.SetCellValue(flag, 14, "");
                        Xls.SetCellValue(flag, 15, "");
                        Xls.SetCellValue(flag, 16, dv[count]["chgbk_nm"].ToString());
                        Xls.SetCellValue(flag, 17, dv[count]["chgjno"].ToString());
                        Xls.SetCellValue(flag, 18, dv[count]["chgjbkno"].ToString());
                        Xls.SetCellValue(flag, 19, dv[count]["fgrechg"].ToString());
                        Xls.SetCellValue(flag, 20, dv[count]["unfgrechg"].ToString());
                        Xls.SetCellValue(flag, 21, "");
                        Xls.SetCellValue(flag, 22, "");
                        Xls.SetCellValue(flag, 23, "");
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 16, "");
                        Xls.SetCellValue(flag, 17, "");
                        Xls.SetCellValue(flag, 18, "");
                        Xls.SetCellValue(flag, 19, "");
                        Xls.SetCellValue(flag, 20, "");
                    }
                    if (dv[count]["drafttp"].ToString() == "1")
                    {
                        Xls.SetCellValue(flag, 11, "");
                        Xls.SetCellValue(flag, 12, "");
                        Xls.SetCellValue(flag, 13, "");
                        Xls.SetCellValue(flag, 14, "");
                        Xls.SetCellValue(flag, 15, "");
                        Xls.SetCellValue(flag, 16, "");
                        Xls.SetCellValue(flag, 17, "");
                        Xls.SetCellValue(flag, 18, "");
                        Xls.SetCellValue(flag, 19, "");
                        Xls.SetCellValue(flag, 20, "");
                        Xls.SetCellValue(flag, 21, dv[count]["origbk_nm"].ToString());
                        Xls.SetCellValue(flag, 22, dv[count]["origjno"].ToString());
                        Xls.SetCellValue(flag, 23, dv[count]["origjbkno"].ToString());
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 21, "");
                        Xls.SetCellValue(flag, 22, "");
                        Xls.SetCellValue(flag, 23, "");
                    }
                    if (dv[count]["drafttp"].ToString() == "2" || dv[count]["drafttp"].ToString() == "3")
                    {
                        Xls.SetCellValue(flag, 24, dv[count]["fgupdated"].ToString());
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 24, "");
                    }

                    Xls.SetCellValue(flag, 25, dv[count]["srspn_cname"].ToString());

                    sum_njtpcd01 = sum_njtpcd01 + Convert.ToInt32(dv[count]["njtpcd01"].ToString());
                    sum_njtpcd02 = sum_njtpcd02 + Convert.ToInt32(dv[count]["njtpcd02"].ToString());
                    sum_njtpcd03 = sum_njtpcd03 + Convert.ToInt32(dv[count]["njtpcd03"].ToString());
                    sum_njtpcd04 = sum_njtpcd04 + Convert.ToInt32(dv[count]["njtpcd04"].ToString());
                    sum_njtpcd05 = sum_njtpcd05 + Convert.ToInt32(dv[count]["njtpcd05"].ToString());
                    sum_fgrechg = sum_fgrechg + Convert.ToInt32(dv[count]["fgrechg"].ToString());
                    sum_unfgrechg = sum_unfgrechg + Convert.ToInt32(dv[count]["unfgrechg"].ToString());
                    sum_fgupdated = sum_fgupdated + Convert.ToInt32(dv[count]["fgupdated"].ToString());
                    sum_total = sum_njtpcd01 + sum_njtpcd02 + sum_njtpcd03 + sum_njtpcd04 + sum_njtpcd05 + sum_fgrechg + sum_fgupdated;

                    Tsum_njtpcd01 = Tsum_njtpcd01 + Convert.ToInt32(dv[count]["njtpcd01"].ToString());
                    Tsum_njtpcd02 = Tsum_njtpcd02 + Convert.ToInt32(dv[count]["njtpcd02"].ToString());
                    Tsum_njtpcd03 = Tsum_njtpcd03 + Convert.ToInt32(dv[count]["njtpcd03"].ToString());
                    Tsum_njtpcd04 = Tsum_njtpcd04 + Convert.ToInt32(dv[count]["njtpcd04"].ToString());
                    Tsum_njtpcd05 = Tsum_njtpcd05 + Convert.ToInt32(dv[count]["njtpcd05"].ToString());
                    Tsum_fgrechg = Tsum_fgrechg + Convert.ToInt32(dv[count]["fgrechg"].ToString());
                    Tsum_unfgrechg = Tsum_unfgrechg + Convert.ToInt32(dv[count]["unfgrechg"].ToString());
                    Tsum_fgupdated = Tsum_fgupdated + Convert.ToInt32(dv[count]["fgupdated"].ToString());

                    firstCol++;
                }
                else
                {
                    if (dv[count]["contno"].ToString() != contno || count == 0)
                    {
                        Xls.SetCellValue(flag, 1, firstCol);
                        Xls.SetCellValue(flag, 2, dv[count]["contno"].ToString());
                        firstCol++;
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 1, "");
                        Xls.SetCellValue(flag, 2, "");
                    }

                    Xls.SetCellValue(flag, 3, dv[count]["pubseq"].ToString());
                    Xls.SetCellValue(flag, 4, dv[count]["pgno"].ToString());
                    Xls.SetCellValue(flag, 5, dv[count]["ltp_nm"].ToString());
                    Xls.SetCellValue(flag, 6, dv[count]["clr_nm"].ToString());
                    Xls.SetCellValue(flag, 7, dv[count]["pgs_nm"].ToString());
                    Xls.SetCellValue(flag, 8, dv[count]["fgfixpg"].ToString());
                    Xls.SetCellValue(flag, 9, dv[count]["mfr_inm"].ToString());
                    if (dv[count]["drafttp"].ToString() == "2" || dv[count]["drafttp"].ToString() == "3")
                    {
                        Xls.SetCellValue(flag, 10, dv[count]["fggot"].ToString());
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 10, "");
                    }

                    if (dv[count]["drafttp"].ToString() == "2")
                    {
                        Xls.SetCellValue(flag, 11, dv[count]["njtpcd01"].ToString());
                        Xls.SetCellValue(flag, 12, dv[count]["njtpcd02"].ToString());
                        Xls.SetCellValue(flag, 13, dv[count]["njtpcd03"].ToString());
                        Xls.SetCellValue(flag, 14, dv[count]["njtpcd04"].ToString());
                        Xls.SetCellValue(flag, 15, dv[count]["njtpcd05"].ToString());
                        Xls.SetCellValue(flag, 16, "");
                        Xls.SetCellValue(flag, 17, "");
                        Xls.SetCellValue(flag, 18, "");
                        Xls.SetCellValue(flag, 19, "");
                        Xls.SetCellValue(flag, 20, "");
                        Xls.SetCellValue(flag, 21, "");
                        Xls.SetCellValue(flag, 22, "");
                        Xls.SetCellValue(flag, 23, "");
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 11, "");
                        Xls.SetCellValue(flag, 12, "");
                        Xls.SetCellValue(flag, 13, "");
                        Xls.SetCellValue(flag, 14, "");
                        Xls.SetCellValue(flag, 15, "");
                    }
                    if (dv[count]["drafttp"].ToString() == "3")
                    {
                        Xls.SetCellValue(flag, 11, "");
                        Xls.SetCellValue(flag, 12, "");
                        Xls.SetCellValue(flag, 13, "");
                        Xls.SetCellValue(flag, 14, "");
                        Xls.SetCellValue(flag, 15, "");
                        Xls.SetCellValue(flag, 16, dv[count]["chgbk_nm"].ToString());
                        Xls.SetCellValue(flag, 17, dv[count]["chgjno"].ToString());
                        Xls.SetCellValue(flag, 18, dv[count]["chgjbkno"].ToString());
                        Xls.SetCellValue(flag, 19, dv[count]["fgrechg"].ToString());
                        Xls.SetCellValue(flag, 20, dv[count]["unfgrechg"].ToString());
                        Xls.SetCellValue(flag, 21, "");
                        Xls.SetCellValue(flag, 22, "");
                        Xls.SetCellValue(flag, 23, "");
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 16, "");
                        Xls.SetCellValue(flag, 17, "");
                        Xls.SetCellValue(flag, 18, "");
                        Xls.SetCellValue(flag, 19, "");
                        Xls.SetCellValue(flag, 20, "");
                    }
                    if (dv[count]["drafttp"].ToString() == "1")
                    {
                        Xls.SetCellValue(flag, 11, "");
                        Xls.SetCellValue(flag, 12, "");
                        Xls.SetCellValue(flag, 13, "");
                        Xls.SetCellValue(flag, 14, "");
                        Xls.SetCellValue(flag, 15, "");
                        Xls.SetCellValue(flag, 16, "");
                        Xls.SetCellValue(flag, 17, "");
                        Xls.SetCellValue(flag, 18, "");
                        Xls.SetCellValue(flag, 19, "");
                        Xls.SetCellValue(flag, 20, "");
                        Xls.SetCellValue(flag, 21, dv[count]["origbk_nm"].ToString());
                        Xls.SetCellValue(flag, 22, dv[count]["origjno"].ToString());
                        Xls.SetCellValue(flag, 23, dv[count]["origjbkno"].ToString());
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 21, "");
                        Xls.SetCellValue(flag, 22, "");
                        Xls.SetCellValue(flag, 23, "");
                    }
                    if (dv[count]["drafttp"].ToString() == "2" || dv[count]["drafttp"].ToString() == "3")
                    {
                        Xls.SetCellValue(flag, 24, dv[count]["fgupdated"].ToString());
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 24, "");
                    }

                    Xls.SetCellValue(flag, 25, dv[count]["srspn_cname"].ToString());

                    sum_njtpcd01 = sum_njtpcd01 + Convert.ToInt32(dv[count]["njtpcd01"].ToString());
                    sum_njtpcd02 = sum_njtpcd02 + Convert.ToInt32(dv[count]["njtpcd02"].ToString());
                    sum_njtpcd03 = sum_njtpcd03 + Convert.ToInt32(dv[count]["njtpcd03"].ToString());
                    sum_njtpcd04 = sum_njtpcd04 + Convert.ToInt32(dv[count]["njtpcd04"].ToString());
                    sum_njtpcd05 = sum_njtpcd05 + Convert.ToInt32(dv[count]["njtpcd05"].ToString());
                    sum_fgrechg = sum_fgrechg + Convert.ToInt32(dv[count]["fgrechg"].ToString());
                    sum_unfgrechg = sum_unfgrechg + Convert.ToInt32(dv[count]["unfgrechg"].ToString());
                    sum_fgupdated = sum_fgupdated + Convert.ToInt32(dv[count]["fgupdated"].ToString());
                    sum_total = sum_njtpcd01 + sum_njtpcd02 + sum_njtpcd03 + sum_njtpcd04 + sum_njtpcd05 + sum_fgrechg + sum_fgupdated;

                    Tsum_njtpcd01 = Tsum_njtpcd01 + Convert.ToInt32(dv[count]["njtpcd01"].ToString());
                    Tsum_njtpcd02 = Tsum_njtpcd02 + Convert.ToInt32(dv[count]["njtpcd02"].ToString());
                    Tsum_njtpcd03 = Tsum_njtpcd03 + Convert.ToInt32(dv[count]["njtpcd03"].ToString());
                    Tsum_njtpcd04 = Tsum_njtpcd04 + Convert.ToInt32(dv[count]["njtpcd04"].ToString());
                    Tsum_njtpcd05 = Tsum_njtpcd05 + Convert.ToInt32(dv[count]["njtpcd05"].ToString());
                    Tsum_fgrechg = Tsum_fgrechg + Convert.ToInt32(dv[count]["fgrechg"].ToString());
                    Tsum_unfgrechg = Tsum_unfgrechg + Convert.ToInt32(dv[count]["unfgrechg"].ToString());
                    Tsum_fgupdated = Tsum_fgupdated + Convert.ToInt32(dv[count]["fgupdated"].ToString());

                    if (count == dv.Count - 1)//因為事最後一筆 所以要把小計加上去
                    {
                        Xls.SetCellValue(flag + 1, 1, "");
                        Xls.SetCellValue(flag + 1, 2, "----------");
                        Xls.SetCellValue(flag + 1, 3, "-----");
                        Xls.SetCellValue(flag + 1, 4, "-----");
                        Xls.SetCellValue(flag + 1, 5, "小計：");
                        Xls.SetCellValue(flag + 1, 6, sum_total);
                        Xls.SetCellValue(flag + 1, 7, "-----");
                        Xls.SetCellValue(flag + 1, 8, "-----");
                        Xls.SetCellValue(flag + 1, 9, "----------------------------------------");
                        Xls.SetCellValue(flag + 1, 10, "-----");
                        Xls.SetCellValue(flag + 1, 11, sum_njtpcd01);
                        Xls.SetCellValue(flag + 1, 12, sum_njtpcd02);
                        Xls.SetCellValue(flag + 1, 13, sum_njtpcd03);
                        Xls.SetCellValue(flag + 1, 14, sum_njtpcd04);
                        Xls.SetCellValue(flag + 1, 15, sum_njtpcd05);
                        Xls.SetCellValue(flag + 1, 16, "-----");
                        Xls.SetCellValue(flag + 1, 17, "-----");
                        Xls.SetCellValue(flag + 1, 18, "-----");
                        Xls.SetCellValue(flag + 1, 19, sum_fgrechg);
                        Xls.SetCellValue(flag + 1, 20, sum_unfgrechg);
                        Xls.SetCellValue(flag + 1, 21, "-----");
                        Xls.SetCellValue(flag + 1, 22, "-----");
                        Xls.SetCellValue(flag + 1, 23, "-----");
                        Xls.SetCellValue(flag + 1, 24, sum_fgupdated);
                        Xls.SetCellValue(flag + 1, 25, "----------");
                    }
                }

                flag++;
                clr = dv[count]["clr_nm"].ToString();
                contno = dv[count]["contno"].ToString();
            }

            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 11, Tsum_njtpcd01);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 12, Tsum_njtpcd02);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 13, Tsum_njtpcd03);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 14, Tsum_njtpcd04);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 15, Tsum_njtpcd05);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 19, Tsum_fgrechg);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 20, Tsum_unfgrechg);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3, 24, Tsum_fgupdated);

            Xls.SetCellValue(dv.Count + 7 + 3 + 3 , 5, Tsum_fgrechg);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3 + 1, 5, Tsum_njtpcd01 + Tsum_njtpcd02 + Tsum_njtpcd03 + Tsum_njtpcd04 + Tsum_njtpcd05);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3 + 2, 5, Tsum_fgupdated);
            Xls.SetCellValue(dv.Count + 7 + 3 + 3 + 3, 5, Tsum_fgrechg + Tsum_njtpcd01 + Tsum_njtpcd02 + Tsum_njtpcd03 + Tsum_njtpcd04 + Tsum_njtpcd05 + Tsum_fgupdated);

            Common.excuteExcel(Xls, "admade_stat2.xls");
        }
    }
}