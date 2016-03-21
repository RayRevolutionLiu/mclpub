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
    public partial class RptAdAmtQuery : System.Web.UI.Page
    {
        RptAdAmtQuery_DB myRpt = new RptAdAmtQuery_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_ddlEmpData();
            }
        }


        #region 連結員工資料
        private void Bind_ddlEmpData()
        {
            DataSet ds = myRpt.GetSrspns();
            DataRow dr2 = ds.Tables[0].NewRow();
            dr2["srspn_cname"] = "請選擇";
            dr2["srspn_empno"] = "000000";
            ds.Tables[0].Rows.Add(dr2);
            DataView dv = ds.Tables[0].DefaultView;
            ds.Tables[0].DefaultView.Sort = "srspn_empno ASC";

            this.ddlEmpData.DataTextField = "srspn_cname";
            this.ddlEmpData.DataValueField = "srspn_empno";
            this.ddlEmpData.DataSource = dv;
            this.ddlEmpData.DataBind();


            ddlEmpData.SelectedIndex = -1;
            if (ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
            else
                ddlEmpData.SelectedIndex = 0;
        }
        #endregion

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string STRtbxMfrName = "";
            string STRtbxSDate = "";
            string STRtbxEDate = "";
            string STRddlEmpData = "";

            if (tbxMfrName.Text.Trim() != "")
            {
                STRtbxMfrName = tbxMfrName.Text.Trim();
            }
            if (tbxSDate.Text.Trim() != "")
            {
                STRtbxSDate = tbxSDate.Text.Trim();
            }
            if (tbxEDate.Text.Trim() != "")
            {
                STRtbxEDate = tbxEDate.Text.Trim();
            }
            if (ddlEmpData.SelectedValue.ToString() != "000000")
            {
                STRddlEmpData = ddlEmpData.SelectedValue.ToString().Trim();
            }

            DataSet ds = myRpt.SelectAll(STRtbxMfrName, STRtbxSDate, STRtbxEDate, STRddlEmpData);

            if (ds.Tables[0].Rows.Count == 0)
            {
                JavaScript.AlertMessage(this.Page, "無符合條件的資料!");
                return;
            }
            else
            {
                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                string fileSpec = Server.MapPath("~/Contract/Template/" + "RptAdAmtQuery.xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;

                TXlsCellRange myRange = new TXlsCellRange("A5:R5");
                TXlsCellRange myRangeBlue = new TXlsCellRange("A6:R6");

                DataSet dsAdd = myRpt.AddFormat(STRtbxMfrName, STRtbxSDate, STRtbxEDate, STRddlEmpData);//因為加了小計 所以ROW數會增加 要補上

                if (ds.Tables[0].Rows.Count == 1)
                {
                    Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                }
                if (ds.Tables[0].Rows.Count > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 7; i < ds.Tables[0].Rows.Count + 7 - 2 + dsAdd.Tables[0].Rows.Count; i++)
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

                Xls.SetCellValue(2, 13, Account.GetAccInfo().srspn_cname.ToString().Trim());
                Xls.SetCellValue(3, 13, DateTime.Now.ToString("yyyy/MM/dd"));

                string contno = "";
                int flag = 5;
                int numCount = 1;
                int SingleCount = 0;//同一個合約編號共有幾筆資料(加過FLAG之後)
                int SingleCountTotal = 0;//同一個合約編號共有幾筆資料
                
                int sum_adamt = 0;
				int sum_desamt = 0;
				int sum_chgamt = 0;
				int sum_invamt = 0;
				int tot_adamt = 0;
				int tot_desamt = 0;
				int tot_chgamt = 0;
                int tot_invamt = 0;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (contno == ds.Tables[0].Rows[i]["cont_contno"].ToString().Trim())
                    {
                        Xls.SetCellValue(flag, 1, "");
                        Xls.SetCellValue(flag, 2, "");
                        Xls.SetCellValue(flag, 3, ds.Tables[0].Rows[i]["adr_seq"].ToString().Trim());
                        Xls.SetCellValue(flag, 4, "");
                        Xls.SetCellValue(flag, 5, "");
                        Xls.SetCellValue(flag, 6, "");
                        Xls.SetCellValue(flag, 7, ds.Tables[0].Rows[i]["adr_addate"].ToString().Trim() == "" ? "" : ds.Tables[0].Rows[i]["adr_addate"].ToString().Substring(0, 4) + "/" + ds.Tables[0].Rows[i]["adr_addate"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[i]["adr_addate"].ToString().Substring(6, 2));

                        switch (ds.Tables[0].Rows[i]["adr_adcate"].ToString().Trim())
                        {
                            case "M":
                                {
                                    Xls.SetCellValue(flag, 8, "首頁");
                                    break;
                                }
                            case "I":
                                {
                                    Xls.SetCellValue(flag, 8, "內頁");
                                    break;
                                }
                            case "N":
                                {
                                    Xls.SetCellValue(flag, 8, "奈米");
                                    break;
                                }
                            default:
                                {
                                    Xls.SetCellValue(flag, 8, "(錯誤)");
                                    break;
                                }
                        }

                        switch (ds.Tables[0].Rows[i]["adr_keyword"].ToString().Trim())
                        {
                            case "h0":
                                {
                                    Xls.SetCellValue(flag, 9, "正中");
                                    break;
                                }
                            case "h1":
                                {
                                    Xls.SetCellValue(flag, 9, "右一");
                                    break;
                                }
                            case "h2":
                                {
                                    Xls.SetCellValue(flag, 9, "右二");
                                    break;
                                }
                            case "h3":
                                {
                                    Xls.SetCellValue(flag, 9, "右三");
                                    break;
                                }
                            case "h4":
                                {
                                    Xls.SetCellValue(flag, 9, "右四");
                                    break;
                                }
                            case "w1":
                                {
                                    Xls.SetCellValue(flag, 9, "右文一");
                                    break;
                                }
                            case "w2":
                                {
                                    Xls.SetCellValue(flag, 9, "右文二");
                                    break;
                                }
                            case "w3":
                                {
                                    Xls.SetCellValue(flag, 9, "右文三");
                                    break;
                                }
                            case "w4":
                                {
                                    Xls.SetCellValue(flag, 9, "右文四");
                                    break;
                                }
                            case "w5":
                                {
                                    Xls.SetCellValue(flag, 9, "右文五");
                                    break;
                                }
                            case "w6":
                                {
                                    Xls.SetCellValue(flag, 9, "右文六");
                                    break;
                                }
                        }


                        Xls.SetCellValue(flag, 10, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_impr"].ToString().Trim()));
                        Xls.SetCellValue(flag, 11, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_adamt"].ToString().Trim()));
                        sum_adamt = sum_adamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_adamt"].ToString().Trim());//小計
                        tot_adamt = tot_adamt + sum_adamt;//總計
                        Xls.SetCellValue(flag, 12, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_desamt"].ToString().Trim()));
                        sum_desamt = sum_desamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_desamt"].ToString().Trim());//小計
                        tot_desamt = tot_desamt + sum_desamt;//總計
                        Xls.SetCellValue(flag, 13, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_chgamt"].ToString().Trim()));
                        sum_chgamt = sum_chgamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_chgamt"].ToString().Trim());//小計
                        tot_chgamt = tot_chgamt + sum_chgamt;//總計
                        Xls.SetCellValue(flag, 14, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_invamt"].ToString().Trim()));
                        sum_invamt = sum_invamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_invamt"].ToString().Trim());//小計
                        tot_invamt = tot_invamt + sum_invamt;//總計
                        Xls.SetCellValue(flag, 15, "");
                        Xls.SetCellValue(flag, 16, "");
                        Xls.SetCellValue(flag, 17, "");
                        Xls.SetCellValue(flag, 18, "");

                    }
                    else
                    {
                        Xls.SetCellValue(flag, 1, numCount);
                        Xls.SetCellValue(flag, 2, ds.Tables[0].Rows[i]["cont_contno"].ToString().Trim());
                        Xls.SetCellValue(flag, 3, ds.Tables[0].Rows[i]["adr_seq"].ToString().Trim());
                        Xls.SetCellValue(flag, 4, ds.Tables[0].Rows[i]["mfr_mfrno"].ToString().Trim());
                        Xls.SetCellValue(flag, 5, ds.Tables[0].Rows[i]["mfr_inm"].ToString().Trim());
                        Xls.SetCellValue(flag, 6, ds.Tables[0].Rows[i]["mfr_inm"].ToString().Trim());
                        Xls.SetCellValue(flag, 7, ds.Tables[0].Rows[i]["adr_addate"].ToString().Trim() == "" ? "" : ds.Tables[0].Rows[i]["adr_addate"].ToString().Substring(0, 4) + "/" + ds.Tables[0].Rows[i]["adr_addate"].ToString().Substring(4, 2) + "/" + ds.Tables[0].Rows[i]["adr_addate"].ToString().Substring(6, 2));

                        switch (ds.Tables[0].Rows[i]["adr_adcate"].ToString().Trim())
                        {
                            case "M":
                                {
                                    Xls.SetCellValue(flag, 8, "首頁");
                                    break;
                                }
                            case "I":
                                {
                                    Xls.SetCellValue(flag, 8, "內頁");
                                    break;
                                }
                            case "N":
                                {
                                    Xls.SetCellValue(flag, 8, "奈米");
                                    break;
                                }
                            default:
                                {
                                    Xls.SetCellValue(flag, 8, "(錯誤)");
                                    break;
                                }
                        }

                        switch (ds.Tables[0].Rows[i]["adr_keyword"].ToString().Trim())
                        {
                            case "h0":
                                {
                                    Xls.SetCellValue(flag, 9, "正中");
                                    break;
                                }
                            case "h1":
                                {
                                    Xls.SetCellValue(flag, 9, "右一");
                                    break;
                                }
                            case "h2":
                                {
                                    Xls.SetCellValue(flag, 9, "右二");
                                    break;
                                }
                            case "h3":
                                {
                                    Xls.SetCellValue(flag, 9, "右三");
                                    break;
                                }
                            case "h4":
                                {
                                    Xls.SetCellValue(flag, 9, "右四");
                                    break;
                                }
                            case "w1":
                                {
                                    Xls.SetCellValue(flag, 9, "右文一");
                                    break;
                                }
                            case "w2":
                                {
                                    Xls.SetCellValue(flag, 9, "右文二");
                                    break;
                                }
                            case "w3":
                                {
                                    Xls.SetCellValue(flag, 9, "右文三");
                                    break;
                                }
                            case "w4":
                                {
                                    Xls.SetCellValue(flag, 9, "右文四");
                                    break;
                                }
                            case "w5":
                                {
                                    Xls.SetCellValue(flag, 9, "右文五");
                                    break;
                                }
                            case "w6":
                                {
                                    Xls.SetCellValue(flag, 9, "右文六");
                                    break;
                                }
                        }


                        Xls.SetCellValue(flag, 10, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_impr"].ToString().Trim()));
                        Xls.SetCellValue(flag, 11, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_adamt"].ToString().Trim()));
                        sum_adamt = sum_adamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_adamt"].ToString().Trim());//小計
                        tot_adamt = tot_adamt + sum_adamt;//總計
                        Xls.SetCellValue(flag, 12, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_desamt"].ToString().Trim()));
                        sum_desamt = sum_desamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_desamt"].ToString().Trim());//小計
                        tot_desamt = tot_desamt + sum_desamt;//總計
                        Xls.SetCellValue(flag, 13, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_chgamt"].ToString().Trim()));
                        sum_chgamt = sum_chgamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_chgamt"].ToString().Trim());//小計
                        tot_chgamt = tot_chgamt + sum_chgamt;//總計
                        Xls.SetCellValue(flag, 14, Convert.ToInt32(ds.Tables[0].Rows[i]["adr_invamt"].ToString().Trim()));
                        sum_invamt = sum_invamt + Convert.ToInt32(ds.Tables[0].Rows[i]["adr_invamt"].ToString().Trim());//小計
                        tot_invamt = tot_invamt + sum_invamt;//總計

                        if (ds.Tables[0].Rows[i]["adr_fginved"].ToString().Trim() == "1")
                        {
                            Xls.SetCellValue(flag, 15, "v");
                        }
                        else
                        {
                            Xls.SetCellValue(flag, 15, "");
                        }
                        Xls.SetCellValue(flag, 16, ds.Tables[0].Rows[i]["invno"].ToString().Trim());
                        Xls.SetCellValue(flag, 17, ds.Tables[0].Rows[i]["iano"].ToString().Trim());
                        Xls.SetCellValue(flag, 18, ds.Tables[0].Rows[i]["srspn_cname"].ToString().Trim());
                        numCount++;
                        contno = ds.Tables[0].Rows[i]["cont_contno"].ToString().Trim();
                        DataSet dsSub = myRpt.SubDs(STRtbxMfrName, STRtbxSDate, STRtbxEDate, STRddlEmpData, contno);
                        SingleCountTotal = Convert.ToInt32(dsSub.Tables[0].Rows[0]["countCol"].ToString());
                        SingleCount = flag + SingleCountTotal - 1;

                    }
                    if (flag == SingleCount)
                    {
                        TFlxFormat fRed = Xls.GetDefaultFormat;
                        fRed.Font.Style = TFlxFontStyles.Bold;
                        fRed.Font.Size20 = 160;
                        fRed.Format = "$#,##0";
                        fRed.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Blue.ToArgb());
                        fRed.Borders.Top.Style = TFlxBorderStyle.Double;
                        fRed.Borders.Top.Color = TExcelColor.FromArgb(System.Drawing.Color.Blue.ToArgb());
                        int xfRed = Xls.AddFormat(fRed);
                        //Xls.SetRowFormat((dt.Rows.Count * 2) + 2 + 7, xf);
                        fRed = null;

                        TFlxFormat fword = Xls.GetDefaultFormat;
                        fword.Font.Style = TFlxFontStyles.Bold;
                        fword.Font.Size20 = 160;
                        fword.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Blue.ToArgb());
                        fword.Borders.Top.Style = TFlxBorderStyle.Double;
                        fword.Borders.Top.Color = TExcelColor.FromArgb(System.Drawing.Color.Blue.ToArgb());
                        int xfword = Xls.AddFormat(fword);
                        //Xls.SetRowFormat((dt.Rows.Count * 2) + 2 + 7, xf);
                        fword = null;

                        Xls.SetCellValue(flag + 1, 1, "");
                        Xls.SetCellValue(flag + 1, 2, "");
                        Xls.SetCellValue(flag + 1, 3, "");
                        Xls.SetCellValue(flag + 1, 4, "");
                        Xls.SetCellValue(flag + 1, 5, "");
                        Xls.SetCellValue(flag + 1, 6, "");
                        Xls.SetCellValue(flag + 1, 7, SingleCountTotal, xfword);
                        Xls.SetCellValue(flag + 1, 8, "筆落版  小計：", xfRed);
                        Xls.SetCellValue(flag + 1, 9, "", xfRed);
                        Xls.SetCellValue(flag + 1, 10, "", xfRed);
                        Xls.SetCellValue(flag + 1, 11, sum_adamt, xfRed);
                        Xls.SetCellValue(flag + 1, 12, sum_desamt, xfRed);
                        Xls.SetCellValue(flag + 1, 13, sum_chgamt, xfRed);
                        Xls.SetCellValue(flag + 1, 14, sum_invamt, xfRed);
                        Xls.SetCellValue(flag + 1, 15, "");
                        Xls.SetCellValue(flag + 1, 16, "");
                        Xls.SetCellValue(flag + 1, 17, "");
                        Xls.SetCellValue(flag + 1, 18, "");
                        sum_adamt = 0;
						sum_desamt = 0;
						sum_chgamt = 0;
                        sum_invamt = 0;
                        flag++;
                    }
                    flag++;
                }

                //迴圈跑完 最後加總計
                TFlxFormat final = Xls.GetDefaultFormat;
                final.Font.Style = TFlxFontStyles.Bold;
                final.Font.Size20 = 200;
                final.Format = "$#,##0";
                final.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
                final.Borders.Top.Style = TFlxBorderStyle.Medium;
                final.Borders.Top.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
                int xfinal = Xls.AddFormat(final);
                //Xls.SetRowFormat((dt.Rows.Count * 2) + 2 + 7, xf);
                final = null;
                Xls.SetCellValue(flag + 1, 1, "", xfinal);
                Xls.SetCellValue(flag + 1, 2, "", xfinal);
                Xls.SetCellValue(flag + 1, 3, "", xfinal);
                Xls.SetCellValue(flag + 1, 4, "", xfinal);
                Xls.SetCellValue(flag + 1, 5, "", xfinal);
                Xls.SetCellValue(flag + 1, 6, "", xfinal);
                Xls.SetCellValue(flag + 1, 7, "", xfinal);
                Xls.SetCellValue(flag + 1, 8, "", xfinal);
                Xls.SetCellValue(flag + 1, 9, "總計：", xfinal);
                Xls.SetCellValue(flag + 1, 10, "", xfinal);

                Xls.SetCellValue(flag + 1, 11, tot_adamt, xfinal);
                Xls.SetCellValue(flag + 1, 12, tot_desamt, xfinal);
                Xls.SetCellValue(flag + 1, 13, tot_chgamt, xfinal);
                Xls.SetCellValue(flag + 1, 14, tot_invamt, xfinal);

                Xls.SetCellValue(flag + 1, 15, "", xfinal);
                Xls.SetCellValue(flag + 1, 16, "", xfinal);
                Xls.SetCellValue(flag + 1, 17, "", xfinal);
                Xls.SetCellValue(flag + 1, 18, "", xfinal);

                Common.excuteExcel(Xls, "RptAdAmtQuery.xls");
               // Response.Write(ds.Tables[0].Rows.Count);

                dsAdd = null;
            }

            ds = null;
        }
    }
}
