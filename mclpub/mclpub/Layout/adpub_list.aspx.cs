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
    public partial class adpub_list : System.Web.UI.Page
    {
        adpub_list_DB myadpub = new adpub_list_DB();

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


            // 顯示下拉式選單 業務員的 DB 值
            DataSet ds4 = myadpub.SelectSrspn();
            DataRow dr = ds4.Tables[0].NewRow();
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds4.Tables[0].Rows.Add(dr);
            ds4.Tables[0].DefaultView.Sort = "srspn_empno ASC";

            DataView dv = ds4.Tables[0].DefaultView;

            ddlEmpNo.DataSource = dv;
            ddlEmpNo.DataTextField = "srspn_cname";
            ddlEmpNo.DataValueField = "srspn_empno";
            ddlEmpNo.DataBind();
            //如果是D級管理者，僅能查看到自己的客戶資料
            if (Account.GetAccInfo().srspn_atype.ToString().Trim() != null && Account.GetAccInfo().srspn_atype.ToString().Trim() != "")
            {
                if (Account.GetAccInfo().srspn_atype.ToString().Trim()=="D")
                {
                    //Response.Write("111");
                    if (this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                    {
                        //Response.Write("111");
                        this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
                        this.ddlEmpNo.Enabled = false;
                    }
                }
            }


            this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");

        }

        protected void lnbClearAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("adpub_list.aspx");
        }

        protected void lnbShow_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            CountPubData();
        }

        // 計算是否有該月的落版資料, 若有則提供連結串接
        private DataView CountPubData()
        {
            // 抓出 網頁變數
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
            string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
            if (strYYYYMM.Length >= 6)
            {
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            }
            else
            {
                strYYYYMM = strYYYYMM;
            }
            string strEmpNo = ddlEmpNo.SelectedItem.Value.ToString().Trim() == "000000" ? "" : ddlEmpNo.SelectedItem.Value.ToString().Trim();
            //Response.Write("strBkcd= " + strBkcd + "<br>");
            //Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
            //Response.Write("strEmpNo= " + strEmpNo + "<br>");
            //Response.Write("strLoginEmpNo= " + strLoginEmpNo + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myadpub.Selectc2_pub(strYYYYMM, strBkcd, strEmpNo);
            DataView dv2 = ds2.Tables[0].DefaultView;


            // 若有資料須修正時, 顯示 DataGrid1
            if (dv2.Count > 0)
            {
                lblMessage.Visible = true;
                Lkdownload.Visible = true;
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
            string fileSpec = Server.MapPath("~/Layout/Template/adpub_list2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A6:V6");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A7:V7");
            TXlsCellRange myRange2 = new TXlsCellRange("A1:V1");
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
                    for (int i = 8; i < dv.Count*2 + 8 - 2; i++)
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

            Xls.SetCellValue(1, 10, ddlBookCode.SelectedItem.Text.ToString());
            Xls.SetCellValue(1, 14, tbxPubDate.Text);
            string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
            if (strYYYYMM.Length >= 6)
            {
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            }
            DataSet dsBookkp = myadpub.Selectbookp(strYYYYMM, ddlBookCode.SelectedItem.Value.ToString().Trim());
            if (dsBookkp.Tables[0].Rows.Count > 0)
            {
                Xls.SetCellValue(2, 12, dsBookkp.Tables[0].Rows[0]["bkp_pno"].ToString().Trim());
            }
            else
            {
                Xls.SetCellValue(2, 12, 0);
            }
            Xls.SetCellValue(3, 21, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(4, 3, ddlEmpNo.SelectedItem.Text.ToString() == "請選擇" ? "" : ddlEmpNo.SelectedItem.Text.ToString());
            Xls.SetCellValue(4, 21, DateTime.Now.ToString("yyyy/MM/dd"));


            Xls.InsertAndCopyRange(myRange2, dv.Count*2 + 5, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);//第一個5是把上面的抬頭算進去 第二個5是要空多少格再放總合

            string contno = "";
            int dvcount = dv.Count;
            int exflag = 6;
            int flag = 1;
            int sum_AdAmt = 0;
            int sum_ChgAmt = 0;
            int TOTALsum_AdAmt = 0;
            int TOTALsum_ChgAmt = 0;
            for (int i = 0; i < dvcount; i++)
            {
                if (dv[i]["pub_contno"].ToString() != contno)
                {
                    if (i + 1 < dvcount)
                    {
                        if (dv[i]["pub_contno"].ToString() == dv[i + 1]["pub_contno"].ToString())
                        {
                            Xls.SetCellValue(exflag, 1, flag);
                            Xls.SetCellValue(exflag, 2, dv[i]["pub_contno"].ToString());
                            Xls.SetCellValue(exflag, 3, dv[i]["pub_pubseq"].ToString());
                            Xls.SetCellValue(exflag, 4, dv[i]["pub_pgno"].ToString());
                            Xls.SetCellValue(exflag, 5, dv[i]["ltp_nm"].ToString());
                            Xls.SetCellValue(exflag, 6, dv[i]["clr_nm"].ToString());
                            Xls.SetCellValue(exflag, 7, dv[i]["pgs_nm"].ToString());
                            Xls.SetCellValue(exflag, 8, dv[i]["pub_fgfixpg"].ToString());
                            Xls.SetCellValue(exflag, 9, dv[i]["mfr_inm"].ToString());
                            Xls.SetCellValue(exflag, 10, dv[i]["pub_fggot"].ToString());
                            Xls.SetCellValue(exflag, 11, dv[i]["njtp_nm"].ToString());
                            Xls.SetCellValue(exflag, 12, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 13, dv[i]["pub_chgjno"].ToString());
                            Xls.SetCellValue(exflag, 14, dv[i]["pub_fgrechg"].ToString());
                            Xls.SetCellValue(exflag, 15, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 16, dv[i]["pub_origjno"].ToString());
                            Xls.SetCellValue(exflag, 17, dv[i]["pub_origjbkno"].ToString());
                            Xls.SetCellValue(exflag, 18, dv[i]["pub_adamt"].ToString());
                            Xls.SetCellValue(exflag, 19, dv[i]["pub_chgamt"].ToString());
                            Xls.SetCellValue(exflag, 20, dv[i]["pub_fginved"].ToString());
                            Xls.SetCellValue(exflag, 21, dv[i]["ia_invno"].ToString());
                            Xls.SetCellValue(exflag, 22, dv[i]["iad_iano"].ToString());
                            sum_AdAmt = sum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            sum_ChgAmt = sum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                            TOTALsum_AdAmt = TOTALsum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            TOTALsum_ChgAmt = TOTALsum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                            exflag++;
                        }
                        else
                        {
                            Xls.SetCellValue(exflag, 1, flag);
                            Xls.SetCellValue(exflag, 2, dv[i]["pub_contno"].ToString());
                            Xls.SetCellValue(exflag, 3, dv[i]["pub_pubseq"].ToString());
                            Xls.SetCellValue(exflag, 4, dv[i]["pub_pgno"].ToString());
                            Xls.SetCellValue(exflag, 5, dv[i]["ltp_nm"].ToString());
                            Xls.SetCellValue(exflag, 6, dv[i]["clr_nm"].ToString());
                            Xls.SetCellValue(exflag, 7, dv[i]["pgs_nm"].ToString());
                            Xls.SetCellValue(exflag, 8, dv[i]["pub_fgfixpg"].ToString());
                            Xls.SetCellValue(exflag, 9, dv[i]["mfr_inm"].ToString());
                            Xls.SetCellValue(exflag, 10, dv[i]["pub_fggot"].ToString());
                            Xls.SetCellValue(exflag, 11, dv[i]["njtp_nm"].ToString());
                            Xls.SetCellValue(exflag, 12, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 13, dv[i]["pub_chgjno"].ToString());
                            Xls.SetCellValue(exflag, 14, dv[i]["pub_fgrechg"].ToString());
                            Xls.SetCellValue(exflag, 15, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 16, dv[i]["pub_origjno"].ToString());
                            Xls.SetCellValue(exflag, 17, dv[i]["pub_origjbkno"].ToString());
                            Xls.SetCellValue(exflag, 18, dv[i]["pub_adamt"].ToString());
                            Xls.SetCellValue(exflag, 19, dv[i]["pub_chgamt"].ToString());
                            Xls.SetCellValue(exflag, 20, dv[i]["pub_fginved"].ToString());
                            Xls.SetCellValue(exflag, 21, dv[i]["ia_invno"].ToString());
                            Xls.SetCellValue(exflag, 22, dv[i]["iad_iano"].ToString());
                            sum_AdAmt = sum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            sum_ChgAmt = sum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                            TOTALsum_AdAmt = TOTALsum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            TOTALsum_ChgAmt = TOTALsum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());

                            Xls.SetCellValue(exflag + 1, 1, "");
                            Xls.SetCellValue(exflag + 1, 2, "----------");
                            Xls.SetCellValue(exflag + 1, 3, "-----");
                            Xls.SetCellValue(exflag + 1, 4, "-----");
                            Xls.SetCellValue(exflag + 1, 5, "-----");
                            Xls.SetCellValue(exflag + 1, 6, "-----");
                            Xls.SetCellValue(exflag + 1, 7, "-----");
                            Xls.SetCellValue(exflag + 1, 8, "-----");
                            Xls.SetCellValue(exflag + 1, 9, "-------------------------");
                            Xls.SetCellValue(exflag + 1, 10, "-----");
                            Xls.SetCellValue(exflag + 1, 11, "-----");
                            Xls.SetCellValue(exflag + 1, 12, "-----");
                            Xls.SetCellValue(exflag + 1, 13, "-----");
                            Xls.SetCellValue(exflag + 1, 14, "-----");
                            Xls.SetCellValue(exflag + 1, 15, "-----");
                            Xls.SetCellValue(exflag + 1, 16, "-----");
                            Xls.SetCellValue(exflag + 1, 17, "小計：");
                            Xls.SetCellValue(exflag + 1, 18, "$" + sum_AdAmt);
                            Xls.SetCellValue(exflag + 1, 19, "$" + sum_ChgAmt);
                            Xls.SetCellValue(exflag + 1, 20, "-----");
                            Xls.SetCellValue(exflag + 1, 21, "----------");
                            Xls.SetCellValue(exflag + 1, 22, "---------------");
                            sum_AdAmt = 0;
                            sum_ChgAmt = 0;
                            exflag = exflag + 2;
                        }
                    }
                    else if (i + 1 == dvcount)
                    {
                        Xls.SetCellValue(exflag, 1, flag);
                        Xls.SetCellValue(exflag, 2, dv[i]["pub_contno"].ToString());
                        Xls.SetCellValue(exflag, 3, dv[i]["pub_pubseq"].ToString());
                        Xls.SetCellValue(exflag, 4, dv[i]["pub_pgno"].ToString());
                        Xls.SetCellValue(exflag, 5, dv[i]["ltp_nm"].ToString());
                        Xls.SetCellValue(exflag, 6, dv[i]["clr_nm"].ToString());
                        Xls.SetCellValue(exflag, 7, dv[i]["pgs_nm"].ToString());
                        Xls.SetCellValue(exflag, 8, dv[i]["pub_fgfixpg"].ToString());
                        Xls.SetCellValue(exflag, 9, dv[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(exflag, 10, dv[i]["pub_fggot"].ToString());
                        Xls.SetCellValue(exflag, 11, dv[i]["njtp_nm"].ToString());
                        Xls.SetCellValue(exflag, 12, dv[i]["bk_nm"].ToString());
                        Xls.SetCellValue(exflag, 13, dv[i]["pub_chgjno"].ToString());
                        Xls.SetCellValue(exflag, 14, dv[i]["pub_fgrechg"].ToString());
                        Xls.SetCellValue(exflag, 15, dv[i]["bk_nm"].ToString());
                        Xls.SetCellValue(exflag, 16, dv[i]["pub_origjno"].ToString());
                        Xls.SetCellValue(exflag, 17, dv[i]["pub_origjbkno"].ToString());
                        Xls.SetCellValue(exflag, 18, dv[i]["pub_adamt"].ToString());
                        Xls.SetCellValue(exflag, 19, dv[i]["pub_chgamt"].ToString());
                        Xls.SetCellValue(exflag, 20, dv[i]["pub_fginved"].ToString());
                        Xls.SetCellValue(exflag, 21, dv[i]["ia_invno"].ToString());
                        Xls.SetCellValue(exflag, 22, dv[i]["iad_iano"].ToString());
                        sum_AdAmt = sum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                        sum_ChgAmt = sum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                        TOTALsum_AdAmt = TOTALsum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                        TOTALsum_ChgAmt = TOTALsum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());

                        Xls.SetCellValue(exflag + 1, 1, "");
                        Xls.SetCellValue(exflag + 1, 2, "----------");
                        Xls.SetCellValue(exflag + 1, 3, "-----");
                        Xls.SetCellValue(exflag + 1, 4, "-----");
                        Xls.SetCellValue(exflag + 1, 5, "-----");
                        Xls.SetCellValue(exflag + 1, 6, "-----");
                        Xls.SetCellValue(exflag + 1, 7, "-----");
                        Xls.SetCellValue(exflag + 1, 8, "-----");
                        Xls.SetCellValue(exflag + 1, 9, "-------------------------");
                        Xls.SetCellValue(exflag + 1, 10, "-----");
                        Xls.SetCellValue(exflag + 1, 11, "-----");
                        Xls.SetCellValue(exflag + 1, 12, "-----");
                        Xls.SetCellValue(exflag + 1, 13, "-----");
                        Xls.SetCellValue(exflag + 1, 14, "-----");
                        Xls.SetCellValue(exflag + 1, 15, "-----");
                        Xls.SetCellValue(exflag + 1, 16, "-----");
                        Xls.SetCellValue(exflag + 1, 17, "小計：");
                        Xls.SetCellValue(exflag + 1, 18, "$" + sum_AdAmt);
                        Xls.SetCellValue(exflag + 1, 19, "$" + sum_ChgAmt);
                        Xls.SetCellValue(exflag + 1, 20, "-----");
                        Xls.SetCellValue(exflag + 1, 21, "----------");
                        Xls.SetCellValue(exflag + 1, 22, "---------------");
                        sum_AdAmt = 0;
                        sum_ChgAmt = 0;
                    }

                    flag++;
                }
                else
                {
                    if (i + 1 < dvcount)
                    {
                        if (dv[i]["pub_contno"].ToString() == dv[i + 1]["pub_contno"].ToString())
                        {
                            Xls.SetCellValue(exflag, 1, "");
                            Xls.SetCellValue(exflag, 2, "");
                            Xls.SetCellValue(exflag, 3, dv[i]["pub_pubseq"].ToString());
                            Xls.SetCellValue(exflag, 4, dv[i]["pub_pgno"].ToString());
                            Xls.SetCellValue(exflag, 5, dv[i]["ltp_nm"].ToString());
                            Xls.SetCellValue(exflag, 6, dv[i]["clr_nm"].ToString());
                            Xls.SetCellValue(exflag, 7, dv[i]["pgs_nm"].ToString());
                            Xls.SetCellValue(exflag, 8, dv[i]["pub_fgfixpg"].ToString());
                            Xls.SetCellValue(exflag, 9, dv[i]["mfr_inm"].ToString());
                            Xls.SetCellValue(exflag, 10, dv[i]["pub_fggot"].ToString());
                            Xls.SetCellValue(exflag, 11, dv[i]["njtp_nm"].ToString());
                            Xls.SetCellValue(exflag, 12, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 13, dv[i]["pub_chgjno"].ToString());
                            Xls.SetCellValue(exflag, 14, dv[i]["pub_fgrechg"].ToString());
                            Xls.SetCellValue(exflag, 15, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 16, dv[i]["pub_origjno"].ToString());
                            Xls.SetCellValue(exflag, 17, dv[i]["pub_origjbkno"].ToString());
                            Xls.SetCellValue(exflag, 18, dv[i]["pub_adamt"].ToString());
                            Xls.SetCellValue(exflag, 19, dv[i]["pub_chgamt"].ToString());
                            Xls.SetCellValue(exflag, 20, dv[i]["pub_fginved"].ToString());
                            Xls.SetCellValue(exflag, 21, dv[i]["ia_invno"].ToString());
                            Xls.SetCellValue(exflag, 22, dv[i]["iad_iano"].ToString());
                            sum_AdAmt = sum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            sum_ChgAmt = sum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                            TOTALsum_AdAmt = TOTALsum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            TOTALsum_ChgAmt = TOTALsum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                            exflag++;
                        }
                        else
                        {
                            Xls.SetCellValue(exflag, 1, "");
                            Xls.SetCellValue(exflag, 2, "");
                            Xls.SetCellValue(exflag, 3, dv[i]["pub_pubseq"].ToString());
                            Xls.SetCellValue(exflag, 4, dv[i]["pub_pgno"].ToString());
                            Xls.SetCellValue(exflag, 5, dv[i]["ltp_nm"].ToString());
                            Xls.SetCellValue(exflag, 6, dv[i]["clr_nm"].ToString());
                            Xls.SetCellValue(exflag, 7, dv[i]["pgs_nm"].ToString());
                            Xls.SetCellValue(exflag, 8, dv[i]["pub_fgfixpg"].ToString());
                            Xls.SetCellValue(exflag, 9, dv[i]["mfr_inm"].ToString());
                            Xls.SetCellValue(exflag, 10, dv[i]["pub_fggot"].ToString());
                            Xls.SetCellValue(exflag, 11, dv[i]["njtp_nm"].ToString());
                            Xls.SetCellValue(exflag, 12, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 13, dv[i]["pub_chgjno"].ToString());
                            Xls.SetCellValue(exflag, 14, dv[i]["pub_fgrechg"].ToString());
                            Xls.SetCellValue(exflag, 15, dv[i]["bk_nm"].ToString());
                            Xls.SetCellValue(exflag, 16, dv[i]["pub_origjno"].ToString());
                            Xls.SetCellValue(exflag, 17, dv[i]["pub_origjbkno"].ToString());
                            Xls.SetCellValue(exflag, 18, dv[i]["pub_adamt"].ToString());
                            Xls.SetCellValue(exflag, 19, dv[i]["pub_chgamt"].ToString());
                            Xls.SetCellValue(exflag, 20, dv[i]["pub_fginved"].ToString());
                            Xls.SetCellValue(exflag, 21, dv[i]["ia_invno"].ToString());
                            Xls.SetCellValue(exflag, 22, dv[i]["iad_iano"].ToString());
                            sum_AdAmt = sum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            sum_ChgAmt = sum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                            TOTALsum_AdAmt = TOTALsum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                            TOTALsum_ChgAmt = TOTALsum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());

                            Xls.SetCellValue(exflag + 1, 1, "");
                            Xls.SetCellValue(exflag + 1, 2, "----------");
                            Xls.SetCellValue(exflag + 1, 3, "-----");
                            Xls.SetCellValue(exflag + 1, 4, "-----");
                            Xls.SetCellValue(exflag + 1, 5, "-----");
                            Xls.SetCellValue(exflag + 1, 6, "-----");
                            Xls.SetCellValue(exflag + 1, 7, "-----");
                            Xls.SetCellValue(exflag + 1, 8, "-----");
                            Xls.SetCellValue(exflag + 1, 9, "-------------------------");
                            Xls.SetCellValue(exflag + 1, 10, "-----");
                            Xls.SetCellValue(exflag + 1, 11, "-----");
                            Xls.SetCellValue(exflag + 1, 12, "-----");
                            Xls.SetCellValue(exflag + 1, 13, "-----");
                            Xls.SetCellValue(exflag + 1, 14, "-----");
                            Xls.SetCellValue(exflag + 1, 15, "-----");
                            Xls.SetCellValue(exflag + 1, 16, "-----");
                            Xls.SetCellValue(exflag + 1, 17, "小計：");
                            Xls.SetCellValue(exflag + 1, 18, "$" + sum_AdAmt);
                            Xls.SetCellValue(exflag + 1, 19, "$" + sum_ChgAmt);
                            Xls.SetCellValue(exflag + 1, 20, "-----");
                            Xls.SetCellValue(exflag + 1, 21, "----------");
                            Xls.SetCellValue(exflag + 1, 22, "---------------");
                            sum_AdAmt = 0;
                            sum_ChgAmt = 0;
                            exflag = exflag + 2;
                        }
                    }
                    else if (i + 1 == dvcount)
                    {
                        Xls.SetCellValue(exflag, 1, "");
                        Xls.SetCellValue(exflag, 2, "");
                        Xls.SetCellValue(exflag, 3, dv[i]["pub_pubseq"].ToString());
                        Xls.SetCellValue(exflag, 4, dv[i]["pub_pgno"].ToString());
                        Xls.SetCellValue(exflag, 5, dv[i]["ltp_nm"].ToString());
                        Xls.SetCellValue(exflag, 6, dv[i]["clr_nm"].ToString());
                        Xls.SetCellValue(exflag, 7, dv[i]["pgs_nm"].ToString());
                        Xls.SetCellValue(exflag, 8, dv[i]["pub_fgfixpg"].ToString());
                        Xls.SetCellValue(exflag, 9, dv[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(exflag, 10, dv[i]["pub_fggot"].ToString());
                        Xls.SetCellValue(exflag, 11, dv[i]["njtp_nm"].ToString());
                        Xls.SetCellValue(exflag, 12, dv[i]["bk_nm"].ToString());
                        Xls.SetCellValue(exflag, 13, dv[i]["pub_chgjno"].ToString());
                        Xls.SetCellValue(exflag, 14, dv[i]["pub_fgrechg"].ToString());
                        Xls.SetCellValue(exflag, 15, dv[i]["bk_nm"].ToString());
                        Xls.SetCellValue(exflag, 16, dv[i]["pub_origjno"].ToString());
                        Xls.SetCellValue(exflag, 17, dv[i]["pub_origjbkno"].ToString());
                        Xls.SetCellValue(exflag, 18, dv[i]["pub_adamt"].ToString());
                        Xls.SetCellValue(exflag, 19, dv[i]["pub_chgamt"].ToString());
                        Xls.SetCellValue(exflag, 20, dv[i]["pub_fginved"].ToString());
                        Xls.SetCellValue(exflag, 21, dv[i]["ia_invno"].ToString());
                        Xls.SetCellValue(exflag, 22, dv[i]["iad_iano"].ToString());
                        sum_AdAmt = sum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                        sum_ChgAmt = sum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());
                        TOTALsum_AdAmt = TOTALsum_AdAmt + Convert.ToInt32(dv[i]["pub_adamt"].ToString());
                        TOTALsum_ChgAmt = TOTALsum_ChgAmt + Convert.ToInt32(dv[i]["pub_chgamt"].ToString());

                        Xls.SetCellValue(exflag + 1, 1, "");
                        Xls.SetCellValue(exflag + 1, 2, "----------");
                        Xls.SetCellValue(exflag + 1, 3, "-----");
                        Xls.SetCellValue(exflag + 1, 4, "-----");
                        Xls.SetCellValue(exflag + 1, 5, "-----");
                        Xls.SetCellValue(exflag + 1, 6, "-----");
                        Xls.SetCellValue(exflag + 1, 7, "-----");
                        Xls.SetCellValue(exflag + 1, 8, "-----");
                        Xls.SetCellValue(exflag + 1, 9, "-------------------------");
                        Xls.SetCellValue(exflag + 1, 10, "-----");
                        Xls.SetCellValue(exflag + 1, 11, "-----");
                        Xls.SetCellValue(exflag + 1, 12, "-----");
                        Xls.SetCellValue(exflag + 1, 13, "-----");
                        Xls.SetCellValue(exflag + 1, 14, "-----");
                        Xls.SetCellValue(exflag + 1, 15, "-----");
                        Xls.SetCellValue(exflag + 1, 16, "-----");
                        Xls.SetCellValue(exflag + 1, 17, "小計：");
                        Xls.SetCellValue(exflag + 1, 18, "$" + sum_AdAmt);
                        Xls.SetCellValue(exflag + 1, 19, "$" + sum_ChgAmt);
                        Xls.SetCellValue(exflag + 1, 20, "-----");
                        Xls.SetCellValue(exflag + 1, 21, "----------");
                        Xls.SetCellValue(exflag + 1, 22, "---------------");
                        sum_AdAmt = 0;
                        sum_ChgAmt = 0;
                    }
                }

                contno = dv[i]["pub_contno"].ToString();
            }

            Xls.SetCellValue(dv.Count * 2 + 5, 18, TOTALsum_AdAmt);
            Xls.SetCellValue(dv.Count * 2 + 5, 19, TOTALsum_ChgAmt);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRange2, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "adpub_list2.xls");

        }
    }
}