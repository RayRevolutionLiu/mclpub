using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;


namespace mclpub.Layout
{
    public partial class RptAdrBillQuery : System.Web.UI.Page
    {
        RptAdrBillQuery_DB myRpt = new RptAdrBillQuery_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_ddlEmpData();
            }
        }

        protected void btnPrintBill_Click(object sender, EventArgs e)
        {
            string STRtbxMfrName = "";
            string STRtbxSDate = "";
            string STRtbxEDate = "";
            string STRddlEmpData = "";
            string STRddlKeyword = "";
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
                STRddlEmpData = ddlEmpData.SelectedValue.ToString();
            }
            if (ddlKeyword.SelectedValue.ToString() != "00")
            {
                STRddlKeyword = ddlKeyword.SelectedValue.ToString();
            }
            DataSet ds = myRpt.ExportExcel(STRtbxMfrName, STRtbxSDate, STRtbxEDate, STRddlEmpData, STRddlKeyword);

            DataView dv = ds.Tables[0].DefaultView;

            //Response.Write(dv.Count);
            //return;

            if (dv.Count > 0)
            {
                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                string fileSpec = Server.MapPath("~/Layout/Template/" + "RptAdrBill.xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;

                TXlsCellRange myRange = new TXlsCellRange("A5:X5");
                TXlsCellRange myRangeBlue = new TXlsCellRange("A6:X6");

                //Xls.InsertAndCopyRange(myRangeBlue,8, 1, 1, TFlxInsertMode.NoneDown);

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
                        for (int i = 7; i < dv.Count + 7 - 2; i++)
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

                Xls.SetCellValue(2, 5, Account.GetAccInfo().srspn_cname.ToString().Trim());
                Xls.SetCellValue(3, 5, DateTime.Now.ToString("yyyy/MM/dd"));

                for (int j = 0; j < dv.Count; j++)
                {
                    Xls.SetCellValue(j + 5, 1, j + 1);
                    Xls.SetCellValue(j + 5, 2, dv[j]["adr_contno"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 3, dv[j]["adr_seq"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 4, dv[j]["mfr_inm"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 5, dv[j]["adr_addate"].ToString().Trim() == "" ? "" : dv[j]["adr_addate"].ToString().Trim().Substring(0, 4) + "/" + dv[j]["adr_addate"].ToString().Trim().Substring(4, 2) + "/" + dv[j]["adr_addate"].ToString().Trim().Substring(6, 2));
                    switch (dv[j]["adr_adcate"].ToString().Trim())
                    {
                        case "M":
                            {
                                Xls.SetCellValue(j + 5, 6, "首頁");
                                break;
                            }
                        case "I":
                            {
                                Xls.SetCellValue(j + 5, 6, "內頁");
                                break;
                            }
                        case "N":
                            {
                                Xls.SetCellValue(j + 5, 6, "奈米");
                                break;
                            }
                        default:
                            {
                                Xls.SetCellValue(j + 5, 6, "錯誤");
                                break;
                            }
                    }

                    switch (dv[j]["adr_keyword"].ToString().Trim())
                    {
                        case "h0":
                            {
                                Xls.SetCellValue(j + 5, 7, "正中");
                                break;
                            }
                        case "h1":
                            {
                                Xls.SetCellValue(j + 5, 7, "右一");
                                break;
                            }
                        case "h2":
                            {
                                Xls.SetCellValue(j + 5, 7, "右二");
                                break;
                            }
                        case "h3":
                            {
                                Xls.SetCellValue(j + 5, 7, "右三");
                                break;
                            }
                        case "h4":
                            {
                                Xls.SetCellValue(j + 5, 7, "右四");
                                break;
                            }
                        case "w1":
                            {
                                Xls.SetCellValue(j + 5, 7, "右文一");
                                break;
                            }
                        case "w2":
                            {
                                Xls.SetCellValue(j + 5, 7, "右文二");
                                break;
                            }
                        case "w3":
                            {
                                Xls.SetCellValue(j + 5, 7, "右文三");
                                break;
                            }
                        case "w4":
                            {
                                Xls.SetCellValue(j + 5, 7, "右文四");
                                break;
                            }
                        case "w5":
                            {
                                Xls.SetCellValue(j + 5, 7, "右文五");
                                break;
                            }
                        case "w6":
                            {
                                Xls.SetCellValue(j + 5, 7, "右文六");
                                break;
                            }
                    }
                    Xls.SetCellValue(j + 5, 8, dv[j]["adr_impr"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 9, "");
                    Xls.SetCellValue(j + 5, 10, "");
                    Xls.SetCellValue(j + 5, 11, "");
                    switch (dv[j]["adr_drafttp"].ToString().Trim())
                    {
                        case "1":
                            {
                                Xls.SetCellValue(j + 5, 9, "v");
                                break;
                            }
                        case "2":
                            {
                                Xls.SetCellValue(j + 5, 10, "v");
                                break;
                            }
                        case "3":
                            {
                                Xls.SetCellValue(j + 5, 11, "v");
                                break;
                            }
                    }

                    Xls.SetCellValue(j + 5, 12, dv[j]["adr_imgurl"].ToString().Trim());

                    if (dv[j]["adr_fgimggot"].ToString().Trim() == "1")
                    {
                        Xls.SetCellValue(j + 5, 13, "是");
                    }
                    else
                    {
                        Xls.SetCellValue(j + 5, 13, "否");
                    }

                    Xls.SetCellValue(j + 5, 14, "");
                    Xls.SetCellValue(j + 5, 15, "");
                    Xls.SetCellValue(j + 5, 16, "");

                    switch (dv[j]["adr_urltp"].ToString().Trim())
                    {
                        case "1":
                            {
                                Xls.SetCellValue(j + 5, 14, "v");
                                break;
                            }
                        case "2":
                            {
                                Xls.SetCellValue(j + 5, 15, "v");
                                break;
                            }
                        case "3":
                            {
                                Xls.SetCellValue(j + 5, 16, "v");
                                break;
                            }
                    }

                    Xls.SetCellValue(j + 5, 17, dv[j]["adr_navurl"].ToString().Trim());

                    if (dv[j]["adr_fgurlgot"].ToString().Trim() == "1")
                    {
                        Xls.SetCellValue(j + 5, 18, "是");
                    }
                    else
                    {
                        Xls.SetCellValue(j + 5, 18, "否");
                    }

                    Xls.SetCellValue(j + 5, 19, dv[j]["adr_alttext"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 20, dv[j]["adr_adamt"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 21, dv[j]["adr_desamt"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 22, dv[j]["adr_chgamt"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 23, dv[j]["srspn_cname"].ToString().Trim());
                    Xls.SetCellValue(j + 5, 24, dv[j]["adr_remark"].ToString().Trim());
                }

                Common.excuteExcel(Xls, "RptAdrBill.xls");

            }
            else
            {
                JavaScript.AlertMessage(this.Page, "查詢無資料,請重新輸入條件");
                return;
            }
        }


        #region 連結員工資料
        private void Bind_ddlEmpData()
        {
            DataSet ds = myRpt.GetSrspns();
            DataRow dr = ds.Tables[0].NewRow();
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].DefaultView.Sort = "srspn_empno ASC";

            DataView dv = ds.Tables[0].DefaultView;

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
    }
}