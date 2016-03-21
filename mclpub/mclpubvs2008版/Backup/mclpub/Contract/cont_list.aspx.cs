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

namespace mclpub.Contract
{
    public partial class cont_list : System.Web.UI.Page
    {
        cont_list_DB myCont = new cont_list_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 給 預設值
                InitialData();
            }
        }

        private void InitialData()
        {
            DataTable dt = myCont.SelectBook();
            dt.DefaultView.Sort = "bk_bkcd ASC";
            ddlBookCode.DataTextField = dt.Columns[2].ToString();
            ddlBookCode.DataValueField = dt.Columns[1].ToString();
            ddlBookCode.DataSource = dt.DefaultView;
            ddlBookCode.DataBind();

            DataTable dt2 = myCont.SelectSrspn();
            DataRow dr2 = dt2.NewRow();
            dr2["srspn_cname"] = "請選擇";
            dr2["srspn_empno"] = "000000";
            dt2.Rows.Add(dr2);
            dt2.DefaultView.Sort = "srspn_empno ASC";
            ddlEmpNo.DataTextField = dt2.Columns[1].ToString();
            ddlEmpNo.DataValueField = dt2.Columns[7].ToString();
            ddlEmpNo.DataSource = dt2.DefaultView;
            ddlEmpNo.DataBind();

            //this.tbxSignDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
            //this.tbxSignDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
            //this.tbxSDate.Text = System.DateTime.Today.ToString("yyyy") + "/01";
            //this.tbxEDate.Text = System.DateTime.Today.ToString("yyyy") + "/12";


            //如果是D級管理者，僅能查看到自己的客戶資料
            if (Account.GetAccInfo().srspn_atype.ToString().Trim() != "")
            {
                if (Account.GetAccInfo().srspn_atype.ToString().Trim() == "D")
                {
                    if (this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                    {
                        this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
                        this.ddlEmpNo.Enabled = false;
                    }
                }
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {

            // 抓出 畫面上的值為傳遞變數
            string strEmpNo, strSignDate1 = "", strSignDate2 = "", strStartDate = "", strEndDate = "", strMfrIName = "";
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            strSignDate1 = this.tbxSignDate1.Text.ToString().Trim();
            strSignDate1 = strSignDate1 == "" ? "" : strSignDate1.Substring(0, 4) + strSignDate1.Substring(5, 2) + strSignDate1.Substring(8, 2);
            strSignDate2 = this.tbxSignDate2.Text.ToString().Trim();
            strSignDate2 = strSignDate2 == "" ? "" : strSignDate2.Substring(0, 4) + strSignDate2.Substring(5, 2) + strSignDate2.Substring(8, 2);
            strStartDate = this.tbxSDate.Text.ToString().Trim();
            strStartDate = strStartDate == "" ? "" : strStartDate.Substring(0, 4) + strStartDate.Substring(5, 2);
            strEndDate = this.tbxEDate.Text.ToString().Trim();
            strEndDate = strEndDate == "" ? "" : strEndDate.Substring(0, 4) + strEndDate.Substring(5, 2);
            string strfgClosed = this.ddlfgclosed.SelectedItem.Value.ToString().Trim();
            strMfrIName = this.tbxMfrIName.Text.ToString().Trim();

            string LoginEmpNo = Account.GetAccInfo().srspn_cname.ToString().Trim();

            DataTable dt = myCont.Runsp_c2_contlist2_1(strBkcd, strEmpNo, strSignDate1, strSignDate2, strStartDate, strEndDate, strfgClosed, strMfrIName);
            //DataTable dt = myCont.SelectChkBtn(strBkcd, strEmpNo, strSignDate1, strSignDate2, strStartDate, strEndDate, strfgClosed, strMfrIName);

            string msg = CheckData(dt);
            if (msg.Length > 0)
            {
                this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                return;
            }


            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Contract/Template/" + "cont_list.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            if (strfgClosed != "99")
            {
                Xls.SetCellValue(1, 10, strfgClosed == "1" ? "已結案" : "未結案");
                //Xls.cop
            }
            else
            {
                Xls.SetCellValue(1, 10, "所有");
            }

            Xls.SetCellValue(3, 3, ddlBookCode.SelectedItem.Text.ToString());

            if (strEmpNo != "000000")
            {
                Xls.SetCellValue(4, 3, ddlEmpNo.SelectedItem.Text.ToString().Trim());
            }
            else
            {
                Xls.SetCellValue(4, 3, "所有");
            }

            if (strMfrIName != "")
            {
                Xls.SetCellValue(5, 3, tbxMfrIName.Text.Trim());
            }
            else
            {
                Xls.SetCellValue(5, 3, "所有");
            }

            if (strSignDate1 != "" && strSignDate2 != "")
            {
                Xls.SetCellValue(4, 8, tbxSignDate1.Text.ToString().Trim() + "~" + tbxSignDate2.Text.ToString().Trim());
            }
            else
            {
                Xls.SetCellValue(4, 8, "所有");
            }

            if (strStartDate != "" && strEndDate != "")
            {
                Xls.SetCellValue(5, 8, tbxSDate.Text.ToString().Trim() + "~" + tbxEDate.Text.ToString().Trim());
            }
            else
            {
                Xls.SetCellValue(5, 8, "所有");
            }

            Xls.SetCellValue(4, 14, LoginEmpNo);
            Xls.SetCellValue(5, 14, DateTime.Now.ToString("yyyy/MM/dd"));

            //==========以上為查詢條件 以下為表格呈現

            //TFlxFormat myFormat = null;
            //myFormat = Xls.GetDefaultFormat;
            ////myFormat.Font = 
            //int fmPt1 = Xls.AddFormat(myFormat);

            TXlsCellRange myRange = new TXlsCellRange("A8:O9");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A10:O11");

            if (dt.Rows.Count == 1)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (dt.Rows.Count > 2)
                {
                    //兩筆的話就不用動任何迴圈
                    int countback = 0;
                    for (int i = 12; i < (dt.Rows.Count * 2) + 12 - 4; i = i + 2)
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
                // Xls.InsertAndCopyRange(myRange, i, 1, 1, TFlxInsertMode.NoneDown);   
            }


            int totalAllColor = 0;//算底下的次數 (彩)：用
            int totalBlack = 0;//算底下的次數 (黑)：用
            int totaltoa = 0;//算底下的次數 (套)：用

            int lasttotalC = 0;
            int lasttotalD = 0;
            int lasttotalE = 0;
            int lasttotalF = 0;
            int lasttotalG = 0;
            int lasttotalH = 0;
            int lasttotalJ = 0;
            int lasttotalK = 0;

            for (int i = 8; i < (dt.Rows.Count * 2) + 8; i = i + 2)
            {
                Xls.SetCellValue(i, 1, ((i / 2) - 3).ToString());
                Xls.SetCellValue(i, 2, dt.Rows[(i / 2) - 4]["cont_contno"].ToString());

                if (dt.Rows[(i / 2) - 4]["cont_conttp"].ToString().Trim() != "")
                {
                    if (dt.Rows[(i / 2) - 4]["cont_conttp"].ToString().Trim() == "01")
                    {
                        Xls.SetCellValue(i, 3, "一般");
                    }
                    else if (dt.Rows[(i / 2) - 4]["cont_conttp"].ToString().Trim() == "09")
                    {
                        Xls.SetCellValue(i, 3, "推廣");
                    }

                }

                Xls.SetCellValue(i, 4, dt.Rows[(i / 2) - 4]["cont_signdate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 4]["cont_signdate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 4]["cont_signdate"].ToString().Substring(4, 2) + "/" + dt.Rows[(i / 2) - 4]["cont_signdate"].ToString().Substring(6, 2));
                Xls.SetCellValue(i, 5, dt.Rows[(i / 2) - 4]["cont_sdate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 4]["cont_sdate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 4]["cont_sdate"].ToString().Substring(4, 2));
                Xls.SetCellValue(i, 6, dt.Rows[(i / 2) - 4]["cont_edate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 4]["cont_edate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 4]["cont_edate"].ToString().Substring(4, 2));
                Xls.SetCellValue(i, 7, dt.Rows[(i / 2) - 4]["cont_mfrno"].ToString());
                Xls.SetCellValue(i, 8, dt.Rows[(i / 2) - 4]["mfr_inm"].ToString());
                Xls.SetCellValue(i, 9, dt.Rows[(i / 2) - 4]["cust_nm"].ToString());
                Xls.SetCellValue(i, 10, dt.Rows[(i / 2) - 4]["cont_aunm"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 4]["cont_aunm"].ToString() + "/" + dt.Rows[(i / 2) - 4]["cont_sdate"].ToString().Substring(4, 2));
                Xls.SetCellValue(i, 11, dt.Rows[(i / 2) - 4]["cont_autel"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 4]["cont_autel"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 4]["cont_edate"].ToString().Substring(4, 2));
                Xls.SetCellValue(i, 12, dt.Rows[(i / 2) - 4]["cont_aucell"].ToString());
                Xls.SetCellValue(i, 13, dt.Rows[(i / 2) - 4]["cont_clrtm"].ToString());
                Xls.SetCellValue(i, 14, dt.Rows[(i / 2) - 4]["cont_menotm"].ToString());
                Xls.SetCellValue(i, 15, dt.Rows[(i / 2) - 4]["cont_getclrtm"].ToString());


                Xls.SetCellValue(i + 1, 3, dt.Rows[(i / 2) - 4]["cont_totjtm"].ToString());
                Xls.SetCellValue(i + 1, 4, dt.Rows[(i / 2) - 4]["cont_madejtm"].ToString());
                Xls.SetCellValue(i + 1, 5, dt.Rows[(i / 2) - 4]["cont_tottm"].ToString());
                Xls.SetCellValue(i + 1, 6, dt.Rows[(i / 2) - 4]["cont_pubtm"].ToString());
                Xls.SetCellValue(i + 1, 7, dt.Rows[(i / 2) - 4]["cont_totamt"].ToString());
                Xls.SetCellValue(i + 1, 8, Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_paidamt"].ToString()));
                Xls.SetCellValue(i + 1, 9, Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_restamt"].ToString()));
                Xls.SetCellValue(i + 1, 10, Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_chgamt"].ToString()));
                Xls.SetCellValue(i + 1, 11, dt.Rows[(i / 2) - 4]["cont_chgjtm"].ToString());
                Xls.SetCellValue(i + 1, 12, dt.Rows[(i / 2) - 4]["cont_disc"].ToString());
                Xls.SetCellValue(i + 1, 13, dt.Rows[(i / 2) - 4]["product_list1"].ToString());
                //ornamestr,orfullnamestr
                if (dt.Rows[(i / 2) - 4]["cont_fgpayonce"].ToString().Trim() == "0")
                {
                    Xls.SetCellValue(i + 1, 14, "否");
                }
                else
                {
                    Xls.SetCellValue(i + 1, 14, "是");
                }

                string strCell15 = "";

                if (dt.Rows[(i / 2) - 4]["cont_fgclosed"].ToString().Trim() == "0")
                {
                    Xls.SetCellValue(i + 1, 15, "否");
                    strCell15 = "否";
                }
                else
                {
                    Xls.SetCellValue(i + 1, 15, "是, 已結案");
                    strCell15 = "是, 已結案";
                }

                if (dt.Rows[(i / 2) - 4]["cont_fgcancel"].ToString().Trim() == "0")
                {
                    Xls.SetCellValue(i + 1, 15, strCell15 + " / 否");
                }
                else
                {
                    Xls.SetCellValue(i + 1, 15, strCell15 + " / 是, 已註");
                }

                totalAllColor = totalAllColor + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_clrtm"]);
                totalBlack = totalBlack + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_menotm"]);
                totaltoa = totaltoa + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_getclrtm"]);

                lasttotalC = lasttotalC + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_totjtm"].ToString());
                lasttotalD = lasttotalD + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_madejtm"].ToString());
                lasttotalE = lasttotalE + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_tottm"].ToString());
                lasttotalF = lasttotalF + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_pubtm"].ToString());
                lasttotalG = lasttotalG + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_totamt"].ToString());
                lasttotalH = lasttotalH + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_paidamt"].ToString());
                lasttotalJ = lasttotalJ + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_chgamt"].ToString());
                lasttotalK = lasttotalK + Convert.ToInt32(dt.Rows[(i / 2) - 4]["cont_chgjtm"].ToString());
                
            }

            TFlxFormat f = Xls.GetDefaultFormat;
            f.Font.Size20 = 160;
            f.Font.Style = TFlxFontStyles.Bold;
            //f.Font.Name = "標楷體";
            int xf = Xls.AddFormat(f);
            Xls.SetRowFormat((dt.Rows.Count * 2) + 2 + 7, xf);
            Xls.SetRowFormat((dt.Rows.Count * 2) + 4 + 7, xf);
            f = null;

            TFlxFormat fRed = Xls.GetDefaultFormat;
            fRed.Font.Size20 = 160;
            fRed.Font.Style = TFlxFontStyles.Bold;
            fRed.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            int xfRed = Xls.AddFormat(fRed);
            //Xls.SetRowFormat((dt.Rows.Count * 2) + 2 + 7, xf);
            fRed = null;

            TFlxFormat tfMoney = Xls.GetDefaultFormat;
            tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            tfMoney.Font.Size20 = 160;
            tfMoney.Format = "$#,##0";
            int tfMoneyI = Xls.AddFormat(tfMoney);
            tfMoney = null;

            Xls.SetCellValue((dt.Rows.Count * 2) + 2 + 7, 11, "次數 (彩/黑/套)：");
            Xls.SetCellValue((dt.Rows.Count * 2) + 2 + 7, 13, totalAllColor, xfRed);
            Xls.SetCellValue((dt.Rows.Count * 2) + 2 + 7, 14, totalBlack, xfRed);
            Xls.SetCellValue((dt.Rows.Count * 2) + 2 + 7, 15, totaltoa, xfRed);


            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 2, "總計：");

            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 3, lasttotalC);
            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 4, lasttotalD);
            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 5, lasttotalE);
            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 6, lasttotalF);
            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 7, lasttotalG, tfMoneyI);
            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 8, lasttotalH, tfMoneyI);
            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 10, lasttotalJ, tfMoneyI);
            Xls.SetCellValue((dt.Rows.Count * 2) + 4 + 7, 11, lasttotalK);

            Common.excuteExcel(Xls, "cont_list.xls");
        }


        private string CheckData(DataTable dt)
        {
            string msg = "";
            if (dt.Rows.Count == 0)
            {
                msg += "找不到符合條件的資料, 您可以重設條件!\\r\\n";
            }
            return msg;

        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

    }
}
