using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;


namespace mclpub.Contract
{
    public partial class RptCont : System.Web.UI.Page
    {
        RptCont_DB myRpt = new RptCont_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind_ddlEmpData();
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string msg = CheckData();
            if (msg.Length > 0)
            {
                this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                return;
            }

            myRpt.RtpGenData();
            int strRsCount = 0;
            DataSet ds1 = myRpt.rsCount(tbxContNo.Text.Trim());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                strRsCount = ds1.Tables[0].Rows.Count;
            }

            DataSet ds2 = myRpt.rsData(tbxContNo.Text.Trim());

            int AdrCount = 0;
            DataSet ds3 = myRpt.rsAdrCount(tbxContNo.Text.Trim());
            if (ds3.Tables[0].Rows.Count > 0)
            {
                AdrCount = ds1.Tables[0].Rows.Count;
            }

            DataSet ds4 = myRpt.rsEmp();

            DataSet ds5 = myRpt.rsPy(tbxContNo.Text.Trim());
            DataSet ds6 = myRpt.rsIa(tbxContNo.Text.Trim());
            DataSet ds7 = myRpt.rsAdr(tbxContNo.Text.Trim());

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Contract/Template/" + "RptCont.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A6:AP6");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A7:AP7");

            TFlxFormat f = Xls.GetDefaultFormat;


            if (ds7.Tables[0].Rows.Count == 1 || ds7.Tables[0].Rows.Count == 0)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (ds7.Tables[0].Rows.Count > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 8; i < ds7.Tables[0].Rows.Count + 8 - 2; i++)
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

            Xls.SetCellValue(3, 3, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(4, 3, DateTime.Now.ToString("yyyy/MM/dd"));

            for (int i = 6; i < ds2.Tables[0].Rows.Count + 6; i++)
            {

                Xls.SetCellValue(i, 1, ds2.Tables[0].Rows[i - 6]["cont_contno"].ToString().Trim());
                Xls.SetCellValue(i, 2, ds2.Tables[0].Rows[i - 6]["cont_signdate"].ToString().Trim() == "" ? "" : ds2.Tables[0].Rows[i - 6]["cont_signdate"].ToString().Substring(0, 4) + "/" + ds2.Tables[0].Rows[i - 6]["cont_signdate"].ToString().Substring(4, 2) + "/" + ds2.Tables[0].Rows[i - 6]["cont_signdate"].ToString().Substring(6, 2));
                if (ds2.Tables[0].Rows[i - 6]["cont_conttp"].ToString().Trim() == "01")
                {
                    Xls.SetCellValue(i, 3, "一般");
                }
                else
                {
                    Xls.SetCellValue(i, 3, "推廣");
                }
                string cont_sdate = ds2.Tables[0].Rows[i - 6]["cont_sdate"].ToString().Trim() == "" ? "" : ds2.Tables[0].Rows[i - 6]["cont_sdate"].ToString().Substring(0, 4) + "/" + ds2.Tables[0].Rows[i - 6]["cont_sdate"].ToString().Substring(4, 2) + "/" + ds2.Tables[0].Rows[i - 6]["cont_sdate"].ToString().Substring(6, 2);
                string cont_edate = ds2.Tables[0].Rows[i - 6]["cont_edate"].ToString().Trim() == "" ? "" : ds2.Tables[0].Rows[i - 6]["cont_edate"].ToString().Substring(0, 4) + "/" + ds2.Tables[0].Rows[i - 6]["cont_edate"].ToString().Substring(4, 2) + "/" + ds2.Tables[0].Rows[i - 6]["cont_edate"].ToString().Substring(6, 2);

                Xls.SetCellValue(i, 4, cont_sdate + "~" + cont_edate);

                Xls.SetCellValue(i, 5, ds2.Tables[0].Rows[i - 6]["mfr_inm"].ToString().Trim());

                for (int j = 0; j < ds4.Tables[0].Rows.Count; j++)
                {
                    if (ds4.Tables[0].Rows[j]["srspn_empno"].ToString().Trim() == ds2.Tables[0].Rows[i - 6]["cont_empno"].ToString().Trim())
                    {
                        Xls.SetCellValue(i, 6, ds4.Tables[0].Rows[j]["srspn_cname"].ToString().Trim());
                    }
                }

                if (ds2.Tables[0].Rows[i - 6]["cont_fgpayonce"].ToString().Trim() == "1")
                {
                    Xls.SetCellValue(i, 7, "是");
                }
                else
                {
                    Xls.SetCellValue(i, 7, "否");
                }

                Xls.SetCellValue(i, 8, ds2.Tables[0].Rows[i - 6]["cont_remark"].ToString().Trim());
                Xls.SetCellValue(i, 9, ds2.Tables[0].Rows[i - 6]["cont_pubtm"].ToString().Trim());
                Xls.SetCellValue(i, 10, ds2.Tables[0].Rows[i - 6]["cont_resttm"].ToString().Trim());
                Xls.SetCellValue(i, 11, ds2.Tables[0].Rows[i - 6]["cont_freetm"].ToString().Trim());
                Xls.SetCellValue(i, 12, ds2.Tables[0].Rows[i - 6]["cont_totimgtm"].ToString().Trim());
                Xls.SetCellValue(i, 13, "");
                Xls.SetCellValue(i, 14, ds2.Tables[0].Rows[i - 6]["cont_toturltm"].ToString().Trim());
                Xls.SetCellValue(i, 15, "");
                Xls.SetCellValue(i, 16, ds2.Tables[0].Rows[i - 6]["cont_disc"].ToString().Trim());

                if (ds5.Tables[0].Rows.Count == 0)
                {
                    Xls.SetCellValue(i, 17, 0);
                }
                else
                {
                    Xls.SetCellValue(i, 17, Convert.ToInt32(ds5.Tables[0].Rows[0]["sum_py"].ToString().Trim()));
                }

                if (ds6.Tables[0].Rows.Count == 0)
                {
                    Xls.SetCellValue(i, 18, 0);
                }
                else
                {
                    Xls.SetCellValue(i, 18, Convert.ToInt32(ds6.Tables[0].Rows[0]["sum_ia"].ToString().Trim()));
                }

                Xls.SetCellValue(i, 19, ds2.Tables[0].Rows[i - 6]["cont_paidamt"].ToString().Trim());
                Xls.SetCellValue(i, 20, ds2.Tables[0].Rows[i - 6]["cont_aunm"].ToString().Trim());
                Xls.SetCellValue(i, 21, ds2.Tables[0].Rows[i - 6]["cont_autel"].ToString().Trim());
                Xls.SetCellValue(i, 22, ds2.Tables[0].Rows[i - 6]["cont_aufax"].ToString().Trim());
                Xls.SetCellValue(i, 23, ds2.Tables[0].Rows[i - 6]["cont_aucell"].ToString().Trim());
                Xls.SetCellValue(i, 24, ds2.Tables[0].Rows[i - 6]["cont_auemail"].ToString().Trim());
                Xls.SetCellValue(i, 25, ds2.Tables[0].Rows[i - 6]["wkmatp_matpstr"].ToString().Trim());
                Xls.SetCellValue(i, 26, ds2.Tables[0].Rows[i - 6]["wkatp_atpstr"].ToString().Trim());
                Xls.SetCellValue(i, 30, ds2.Tables[0].Rows[i - 6]["wkfbk_fbkstr"].ToString().Trim());
                Xls.SetCellValue(i, 27, ds2.Tables[0].Rows[i - 6]["cont_ccont"].ToString().Trim());
                Xls.SetCellValue(i, 28, ds2.Tables[0].Rows[i - 6]["cont_pdcont"].ToString().Trim());
                Xls.SetCellValue(i, 29, ds2.Tables[0].Rows[i - 6]["cont_csdate"].ToString().Trim() == "" ? "" : ds2.Tables[0].Rows[i - 6]["cont_csdate"].ToString().Substring(0, 4) + "/" + ds2.Tables[0].Rows[i - 6]["cont_csdate"].ToString().Substring(4, 2) + "/" + ds2.Tables[0].Rows[i - 6]["cont_csdate"].ToString().Substring(6, 2));

                for (int k = 6; k < ds7.Tables[0].Rows.Count + 6; k++)
                {
                    if (ds2.Tables[0].Rows[i - 6]["cont_contno"].ToString().Trim() == ds7.Tables[0].Rows[k - 6]["adr_contno"].ToString().Trim())
                    {
                        Xls.SetCellValue(k, 31, ds7.Tables[0].Rows[k - 6]["adr_addate"].ToString().Trim() == "" ? "" : ds7.Tables[0].Rows[k - 6]["adr_addate"].ToString().Substring(0, 4) + "/" + ds7.Tables[0].Rows[k - 6]["adr_addate"].ToString().Substring(4, 2) + "/" + ds7.Tables[0].Rows[k - 6]["adr_addate"].ToString().Substring(6, 2));
                        Xls.SetCellValue(k, 32, ds7.Tables[0].Rows[k - 6]["adr_alttext"].ToString().Trim());

                        switch (ds7.Tables[0].Rows[k - 6]["adr_adcate"].ToString().Trim())
                        {
                            case "M":
                                {
                                    Xls.SetCellValue(k, 33, "首頁");
                                    break;
                                }
                            case "I":
                                {
                                    Xls.SetCellValue(k, 33, "內頁");
                                    break;
                                }
                            case "N":
                                {
                                    Xls.SetCellValue(k, 33, "奈米");
                                    break;
                                }
                            default:
                                {
                                    Xls.SetCellValue(k, 33, "(錯誤)");
                                    break;
                                }
                        }


                        switch (ds7.Tables[0].Rows[k - 6]["adr_keyword"].ToString().Trim())
                        {
                            case "h0":
                                {
                                    Xls.SetCellValue(k, 34, "正中");
                                    break;
                                }
                            case "h1":
                                {
                                    Xls.SetCellValue(k, 34, "右一");
                                    break;
                                }
                            case "h2":
                                {
                                    Xls.SetCellValue(k, 34, "右二");
                                    break;
                                }
                            case "h3":
                                {
                                    Xls.SetCellValue(k, 34, "右三");
                                    break;
                                }
                            case "h4":
                                {
                                    Xls.SetCellValue(k, 34, "右四");
                                    break;
                                }
                            case "w1":
                                {
                                    Xls.SetCellValue(k, 34, "右文一");
                                    break;
                                }
                            case "w2":
                                {
                                    Xls.SetCellValue(k, 34, "右文二");
                                    break;
                                }
                            case "w3":
                                {
                                    Xls.SetCellValue(k, 34, "右文三");
                                    break;
                                }
                            case "w4":
                                {
                                    Xls.SetCellValue(k, 34, "右文四");
                                    break;
                                }
                            case "w5":
                                {
                                    Xls.SetCellValue(k, 34, "右文五");
                                    break;
                                }
                            case "w6":
                                {
                                    Xls.SetCellValue(k, 34, "右文六");
                                    break;
                                }
                        }


                        Xls.SetCellValue(k, 35, ds7.Tables[0].Rows[k - 6]["adr_impr"].ToString().Trim());
                        Xls.SetCellValue(k, 36, ds7.Tables[0].Rows[k - 6]["adr_imgurl"].ToString().Trim());
                        Xls.SetCellValue(k, 37, ds7.Tables[0].Rows[k - 6]["adr_navurl"].ToString().Trim());
                        Xls.SetCellValue(k, 38, ds7.Tables[0].Rows[k - 6]["im_nm"].ToString().Trim());
                        Xls.SetCellValue(k, 39, ds7.Tables[0].Rows[k - 6]["im_addr"].ToString().Trim());
                        Xls.SetCellValue(k, 40, ds7.Tables[0].Rows[k - 6]["im_tel"].ToString().Trim());

                        switch (ds7.Tables[0].Rows[k - 6]["im_invcd"].ToString().Trim())
                        {
                            case "":
                                {
                                    Xls.SetCellValue(k, 41, "");
                                    break;
                                }
                            case "2":
                                {
                                    Xls.SetCellValue(k, 41, "二聯");
                                    break;
                                }
                            case "3":
                                {
                                    Xls.SetCellValue(k, 41, "三聯");
                                    break;
                                }
                            default:
                                {
                                    Xls.SetCellValue(k, 41, "其他");
                                    break;
                                }
                        }

                        switch (ds7.Tables[0].Rows[k - 6]["im_taxtp"].ToString().Trim())
                        {
                            case "":
                                {
                                    Xls.SetCellValue(k, 42, "");
                                    break;
                                }
                            case "1":
                                {
                                    Xls.SetCellValue(k, 42, "應稅5%");
                                    break;
                                }
                            case "2":
                                {
                                    Xls.SetCellValue(k, 42, "零稅");
                                    break;
                                }
                            default:
                                {
                                    Xls.SetCellValue(k, 42, "免稅");
                                    break;
                                }
                        }



                    }
                }
                //Xls.SetCellValue(i, 27, ds2.Tables[0].Rows[i - 6]["cont_ccont"].ToString().Trim());
            }

            ds1 = null;
            ds2 = null;
            ds3 = null;
            ds4 = null;
            ds5 = null;
            ds6 = null;
            ds7 = null;
            Common.excuteExcel(Xls, "RptCont.xls");


        }

        private string CheckData()
        {
            string msg = "";
            if (tbxContNo.Text.Trim() == "")
            {
                msg += "請輸入合約編號!\\r\\n";
            }
            DataSet ds2 = myRpt.rsData(tbxContNo.Text.Trim());
            if (ds2.Tables[0].Rows.Count == 0)
            {
                msg += "無符合條件的資料!\\r\\n";
            }

            return msg;
        }

        protected void btnGoAll_Click(object sender, EventArgs e)
        {
            myRpt.RtpGenData();
            string STRtbxContNo0 = tbxContNo0.Text.Trim();
            string STRtbxSDate = tbxSDate.Text.Trim();
            string STRtbxEDate = tbxEDate.Text.Trim();
            string STRddlEmpData = "";
            string STRtbxMfrIName = "";
            string STRddlClosed = "";
            string STRddlCancel = "";

            if (ddlEmpData.SelectedValue.ToString().Trim() != "000000")
            {
                STRddlEmpData = ddlEmpData.SelectedValue.ToString().Trim();
            }
            if (ddlClosed.SelectedValue.ToString() != "99")
            {
                STRddlClosed = ddlClosed.SelectedValue.ToString();
            }
            if (ddlCancel.SelectedValue.ToString() != "99")
            {
                STRddlCancel = ddlCancel.SelectedValue.ToString();
            }

            DataSet ds1 = myRpt.rsDataBig(STRtbxContNo0, STRtbxSDate, STRtbxEDate, STRddlEmpData, STRtbxMfrIName, STRddlClosed, STRddlCancel);
            DataSet ds4 = myRpt.rsEmp();
            DataSet ds2 = myRpt.rsAdrBig(STRtbxContNo0, STRtbxSDate, STRtbxEDate, STRddlEmpData, STRtbxMfrIName, STRddlClosed, STRddlCancel);


            if (ds1.Tables[0].Rows.Count == 0)
            {
                JavaScript.AlertMessage(this.Page, "無符合條件的資料!");
                return;
            }
            else
            {
                //Response.Write(ds1.Tables[0].Rows.Count);
                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                string fileSpec = Server.MapPath("~/Contract/Template/" + "RptCont.xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;

                TXlsCellRange myRange = new TXlsCellRange("A6:AP6");
                TXlsCellRange myRangeBlue = new TXlsCellRange("A7:AP7");

                Xls.SetCellValue(3, 3, Account.GetAccInfo().srspn_cname.ToString().Trim());
                Xls.SetCellValue(4, 3, DateTime.Now.ToString("yyyy/MM/dd"));

                int flag = 6;
                int flag2 = 6;

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    //每個合約的主項也需要把格式複製過去
                    if (ds1.Tables[0].Rows.Count == 1)
                    {
                        Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                    }
                    else if (ds1.Tables[0].Rows.Count == 2)
                    {
                        //do  nothing
                    }
                    //else
                    //{
                    //    if (flag2 > 7)
                    //    {
                    //        if (flag2 % 2 == 0)
                    //        {
                    //            Xls.InsertAndCopyRange(myRange, flag2, 1, 1, TFlxInsertMode.NoneDown);
                    //        }
                    //        else
                    //        {
                    //            Xls.InsertAndCopyRange(myRangeBlue, flag2, 1, 1, TFlxInsertMode.NoneDown);
                    //        }
                    //    }
                    //}

                    for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                    {
                        if (ds1.Tables[0].Rows[i]["cont_contno"].ToString().Trim() == ds2.Tables[0].Rows[j]["adr_contno"].ToString().Trim())
                        {
                            if (flag2 > 7)
                            {
                                if (flag2 % 2 == 0)
                                {
                                    Xls.InsertAndCopyRange(myRange, flag2, 1, 1, TFlxInsertMode.NoneDown);
                                }
                                else
                                {
                                    Xls.InsertAndCopyRange(myRangeBlue, flag2, 1, 1, TFlxInsertMode.NoneDown);
                                }
                            }

                            flag2++;
                        }
                     
                    }

                }



                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {

                    Xls.SetCellValue(flag, 1, ds1.Tables[0].Rows[i]["cont_contno"].ToString().Trim());
                    Xls.SetCellValue(flag, 2, ds1.Tables[0].Rows[i]["cont_signdate"].ToString().Trim() == "" ? "" : ds1.Tables[0].Rows[i]["cont_signdate"].ToString().Substring(0, 4) + "/" + ds1.Tables[0].Rows[i]["cont_signdate"].ToString().Substring(4, 2) + "/" + ds1.Tables[0].Rows[i]["cont_signdate"].ToString().Substring(6, 2));
                    if (ds1.Tables[0].Rows[i]["cont_conttp"].ToString().Trim() == "01")
                    {
                        Xls.SetCellValue(flag, 3, "一般");
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 3, "推廣");
                    }
                    string cont_sdate = ds1.Tables[0].Rows[i]["cont_sdate"].ToString().Trim() == "" ? "" : ds1.Tables[0].Rows[i]["cont_sdate"].ToString().Substring(0, 4) + "/" + ds1.Tables[0].Rows[i]["cont_sdate"].ToString().Substring(4, 2) + "/" + ds1.Tables[0].Rows[i]["cont_sdate"].ToString().Substring(6, 2);
                    string cont_edate = ds1.Tables[0].Rows[i]["cont_edate"].ToString().Trim() == "" ? "" : ds1.Tables[0].Rows[i]["cont_edate"].ToString().Substring(0, 4) + "/" + ds1.Tables[0].Rows[i]["cont_edate"].ToString().Substring(4, 2) + "/" + ds1.Tables[0].Rows[i]["cont_edate"].ToString().Substring(6, 2);

                    Xls.SetCellValue(flag, 4, cont_sdate + "~" + cont_edate);

                    Xls.SetCellValue(flag, 5, ds1.Tables[0].Rows[i]["mfr_inm"].ToString().Trim());

                    for (int j = 0; j < ds4.Tables[0].Rows.Count; j++)
                    {
                        if (ds4.Tables[0].Rows[j]["srspn_empno"].ToString().Trim() == ds1.Tables[0].Rows[i]["cont_empno"].ToString().Trim())
                        {
                            Xls.SetCellValue(flag, 6, ds4.Tables[0].Rows[j]["srspn_cname"].ToString().Trim());
                        }
                    }

                    if (ds1.Tables[0].Rows[i]["cont_fgpayonce"].ToString().Trim() == "1")
                    {
                        Xls.SetCellValue(flag, 7, "是");
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 7, "否");
                    }

                    Xls.SetCellValue(flag, 8, ds1.Tables[0].Rows[i]["cont_remark"].ToString().Trim());
                    Xls.SetCellValue(flag, 9, ds1.Tables[0].Rows[i]["cont_pubtm"].ToString().Trim());
                    Xls.SetCellValue(flag, 10, ds1.Tables[0].Rows[i]["cont_resttm"].ToString().Trim());
                    Xls.SetCellValue(flag, 11, ds1.Tables[0].Rows[i]["cont_freetm"].ToString().Trim());
                    Xls.SetCellValue(flag, 12, ds1.Tables[0].Rows[i]["cont_totimgtm"].ToString().Trim());
                    Xls.SetCellValue(flag, 13, "");
                    Xls.SetCellValue(flag, 14, ds1.Tables[0].Rows[i]["cont_toturltm"].ToString().Trim());
                    Xls.SetCellValue(flag, 15, "");
                    Xls.SetCellValue(flag, 16, ds1.Tables[0].Rows[i]["cont_disc"].ToString().Trim());

                    DataSet ds5 = myRpt.rsPy(ds1.Tables[0].Rows[i]["cont_contno"].ToString().Trim());
                    DataSet ds6 = myRpt.rsIa(ds1.Tables[0].Rows[i]["cont_contno"].ToString().Trim());

                    if (ds5.Tables[0].Rows.Count == 0)
                    {
                        Xls.SetCellValue(flag, 17, 0);
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 17, Convert.ToInt32(ds5.Tables[0].Rows[0]["sum_py"].ToString().Trim()));
                    }

                    if (ds6.Tables[0].Rows.Count == 0)
                    {
                        Xls.SetCellValue(flag, 18, 0);
                    }
                    else
                    {
                        Xls.SetCellValue(flag, 18, Convert.ToInt32(ds6.Tables[0].Rows[0]["sum_ia"].ToString().Trim()));
                    }


                    Xls.SetCellValue(flag, 19, ds1.Tables[0].Rows[i]["cont_paidamt"].ToString().Trim());
                    Xls.SetCellValue(flag, 20, ds1.Tables[0].Rows[i]["cont_aunm"].ToString().Trim());
                    Xls.SetCellValue(flag, 21, ds1.Tables[0].Rows[i]["cont_autel"].ToString().Trim());
                    Xls.SetCellValue(flag, 22, ds1.Tables[0].Rows[i]["cont_aufax"].ToString().Trim());
                    Xls.SetCellValue(flag, 23, ds1.Tables[0].Rows[i]["cont_aucell"].ToString().Trim());
                    Xls.SetCellValue(flag, 24, ds1.Tables[0].Rows[i]["cont_auemail"].ToString().Trim());
                    Xls.SetCellValue(flag, 25, ds1.Tables[0].Rows[i]["wkmatp_matpstr"].ToString().Trim());
                    Xls.SetCellValue(flag, 26, ds1.Tables[0].Rows[i]["wkatp_atpstr"].ToString().Trim());
                    Xls.SetCellValue(flag, 30, ds1.Tables[0].Rows[i]["wkfbk_fbkstr"].ToString().Trim());
                    Xls.SetCellValue(flag, 27, ds1.Tables[0].Rows[i]["cont_ccont"].ToString().Trim());
                    Xls.SetCellValue(flag, 28, ds1.Tables[0].Rows[i]["cont_pdcont"].ToString().Trim());
                    Xls.SetCellValue(flag, 29, ds1.Tables[0].Rows[i]["cont_csdate"].ToString().Trim() == "" ? "" : ds1.Tables[0].Rows[i]["cont_csdate"].ToString().Substring(0, 4) + "/" + ds1.Tables[0].Rows[i]["cont_csdate"].ToString().Substring(4, 2) + "/" + ds1.Tables[0].Rows[i]["cont_csdate"].ToString().Substring(6, 2));

                    for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                    {
                        if (ds1.Tables[0].Rows[i]["cont_contno"].ToString().Trim() == ds2.Tables[0].Rows[j]["adr_contno"].ToString().Trim())
                        {
                            Xls.SetCellValue(flag, 31, ds2.Tables[0].Rows[j]["adr_addate"].ToString().Trim() == "" ? "" : ds2.Tables[0].Rows[j]["adr_addate"].ToString().Substring(0, 4) + "/" + ds2.Tables[0].Rows[j]["adr_addate"].ToString().Substring(4, 2) + "/" + ds2.Tables[0].Rows[j]["adr_addate"].ToString().Substring(6, 2));
                            Xls.SetCellValue(flag, 32, ds2.Tables[0].Rows[j]["adr_alttext"].ToString().Trim());

                            switch (ds2.Tables[0].Rows[j]["adr_adcate"].ToString().Trim())
                            {
                                case "M":
                                    {
                                        Xls.SetCellValue(flag, 33, "首頁");
                                        break;
                                    }
                                case "I":
                                    {
                                        Xls.SetCellValue(flag, 33, "內頁");
                                        break;
                                    }
                                case "N":
                                    {
                                        Xls.SetCellValue(flag, 33, "奈米");
                                        break;
                                    }
                                default:
                                    {
                                        Xls.SetCellValue(flag, 33, "(錯誤)");
                                        break;
                                    }
                            }


                            switch (ds2.Tables[0].Rows[j]["adr_keyword"].ToString().Trim())
                            {
                                case "h0":
                                    {
                                        Xls.SetCellValue(flag, 34, "正中");
                                        break;
                                    }
                                case "h1":
                                    {
                                        Xls.SetCellValue(flag, 34, "右一");
                                        break;
                                    }
                                case "h2":
                                    {
                                        Xls.SetCellValue(flag, 34, "右二");
                                        break;
                                    }
                                case "h3":
                                    {
                                        Xls.SetCellValue(flag, 34, "右三");
                                        break;
                                    }
                                case "h4":
                                    {
                                        Xls.SetCellValue(flag, 34, "右四");
                                        break;
                                    }
                                case "w1":
                                    {
                                        Xls.SetCellValue(flag, 34, "右文一");
                                        break;
                                    }
                                case "w2":
                                    {
                                        Xls.SetCellValue(flag, 34, "右文二");
                                        break;
                                    }
                                case "w3":
                                    {
                                        Xls.SetCellValue(flag, 34, "右文三");
                                        break;
                                    }
                                case "w4":
                                    {
                                        Xls.SetCellValue(flag, 34, "右文四");
                                        break;
                                    }
                                case "w5":
                                    {
                                        Xls.SetCellValue(flag, 34, "右文五");
                                        break;
                                    }
                                case "w6":
                                    {
                                        Xls.SetCellValue(flag, 34, "右文六");
                                        break;
                                    }
                            }


                            Xls.SetCellValue(flag, 35, ds2.Tables[0].Rows[j]["adr_impr"].ToString().Trim());
                            Xls.SetCellValue(flag, 36, ds2.Tables[0].Rows[j]["adr_imgurl"].ToString().Trim());
                            Xls.SetCellValue(flag, 37, ds2.Tables[0].Rows[j]["adr_navurl"].ToString().Trim());
                            Xls.SetCellValue(flag, 38, ds2.Tables[0].Rows[j]["im_nm"].ToString().Trim());
                            Xls.SetCellValue(flag, 39, ds2.Tables[0].Rows[j]["im_addr"].ToString().Trim());
                            Xls.SetCellValue(flag, 40, ds2.Tables[0].Rows[j]["im_tel"].ToString().Trim());

                            switch (ds2.Tables[0].Rows[j]["im_invcd"].ToString().Trim())
                            {
                                case "":
                                    {
                                        Xls.SetCellValue(flag, 41, "");
                                        break;
                                    }
                                case "2":
                                    {
                                        Xls.SetCellValue(flag, 41, "二聯");
                                        break;
                                    }
                                case "3":
                                    {
                                        Xls.SetCellValue(flag, 41, "三聯");
                                        break;
                                    }
                                default:
                                    {
                                        Xls.SetCellValue(flag, 41, "其他");
                                        break;
                                    }
                            }

                            switch (ds2.Tables[0].Rows[j]["im_taxtp"].ToString().Trim())
                            {
                                case "":
                                    {
                                        Xls.SetCellValue(flag, 42, "");
                                        break;
                                    }
                                case "1":
                                    {
                                        Xls.SetCellValue(flag, 42, "應稅5%");
                                        break;
                                    }
                                case "2":
                                    {
                                        Xls.SetCellValue(flag, 42, "零稅");
                                        break;
                                    }
                                default:
                                    {
                                        Xls.SetCellValue(flag, 42, "免稅");
                                        break;
                                    }
                            }

                            flag++;
                        }
                    }

                }

                ds1 = null;
                ds2 = null;
                ds4 = null;


                Common.excuteExcel(Xls, "RptCont.xls");
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

    }
}
