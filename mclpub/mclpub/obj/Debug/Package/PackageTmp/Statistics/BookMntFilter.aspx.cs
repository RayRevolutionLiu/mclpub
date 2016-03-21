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

namespace mclpub.Statistics
{
    public partial class BookMntFilter : System.Web.UI.Page
    {
        BookMntFilter_DB myBook = new BookMntFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                int myYear = System.DateTime.Today.Year;
                int j = 0;
                for (int i = myYear - 1; i <= myYear + 1; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    j++;
                }
                ddlYear.SelectedIndex = j - 2;
                int myMonth = System.DateTime.Today.Month;
                string StrMonth = "";
                if (myMonth.ToString().Length < 2)
                {
                    StrMonth = "0" + myMonth.ToString();
                }

                ddlMonth.SelectedIndex = myMonth - 1;

                DataSet ds = myBook.SelectBookp(ddlYear.SelectedValue.ToString() + StrMonth);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbBookNo.Text = ds.Tables[0].Rows[0]["bkp_pno"].ToString().Trim();
                }
            }


        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string path = "";
            TXlsCellRange myRange = null;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            DataSet ds4 = new DataSet();
            DataSet ds5 = new DataSet();

            if (ddlMailType.SelectedItem.Value.Trim() == "0")
            {
                path = "~/Statistics/Template/book_mnt1.xls";
                myRange = new TXlsCellRange("A6:I6");
                ds1 = myBook.Selecttmp_statisticsForExcel1to5(1, "book_mnt1");
                ds2 = myBook.Selecttmp_statisticsForExcel1to5(2, "book_mnt1");
                ds3 = myBook.Selecttmp_statisticsForExcel1to5(3, "book_mnt1");
                ds4 = myBook.Selecttmp_statisticsForExcel1to5(4, "book_mnt1");
                ds5 = myBook.Selecttmp_statisticsForExcel1to5(5, "book_mnt1");
            }
            else
            {
                path = "~/Statistics/Template/book_mnt2.xls";
                myRange = new TXlsCellRange("A6:J6");
                ds1 = myBook.Selecttmp_statisticsForExcel1to5(1, "");
                ds2 = myBook.Selecttmp_statisticsForExcel1to5(2, "");
                ds3 = myBook.Selecttmp_statisticsForExcel1to5(3, "");
                ds4 = myBook.Selecttmp_statisticsForExcel1to5(4, "");
                ds5 = myBook.Selecttmp_statisticsForExcel1to5(5, "");
            }
            string fileSpec = Server.MapPath(path);
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            string Title = "";
            Title += ddlYear.SelectedItem.Text.ToString() + "年" + ddlMonth.SelectedItem.Text.ToString() + "月";
            if (lbBookNo.Text.Trim() != "")
            {
                Title += lbBookNo.Text.Trim() + "期 ";
            }
            Title += ddlBookType.SelectedItem.Text.ToString().Trim() + " 印製份數統計表";

            Xls.SetCellValue(1, 1, Title);
            Xls.SetCellValue(3, 2, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(3, 6, DateTime.Now.ToString("yyyy/MM/dd"));


            #region 插入空白格式
            //因為從中間塞空白進去 會讓底下的TABLE的destRow算錯 需要把前面ds.rows.count加上去
            #region 第一區塊
            for (int i1 = 0; i1 < ds1.Tables[0].Rows.Count - 1; i1++)
            {
                if (ds1.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange, i1 + 7, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion

            #region 第二區塊
            for (int i2 = 0; i2 < ds2.Tables[0].Rows.Count - 1; i2++)
            {
                if (ds2.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange, i2 + 12 + ds1.Tables[0].Rows.Count - 1, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);
                    //ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion

            #region 第三區塊
            for (int i3 = 0; i3 < ds3.Tables[0].Rows.Count - 1; i3++)
            {
                if (ds3.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange, i3 + 17 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion

            #region 第四區塊
            for (int i4 = 0; i4 < ds4.Tables[0].Rows.Count - 1; i4++)
            {
                if (ds4.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange, i4 + 22 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion

            #region 第五區塊
            for (int i5 = 0; i5 < ds5.Tables[0].Rows.Count - 1; i5++)
            {
                if (ds5.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange, i5 + 27 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion

            #region 第六區塊
            DataSet ds6 = myBook.Selecttmp_statisticsForExcel6(ddlYear.SelectedItem.Value.ToString() + ddlMonth.SelectedItem.Value.ToString(), ddlBookType.SelectedItem.Value.ToString());
            for (int i6 = 0; i6 < ds6.Tables[0].Rows.Count - 1; i6++)
            {
                if (ds6.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange, i6 + 32 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count - 5, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion

            #endregion

            string preotp1cd = "";
            string premtp = "";


            #region 總分數
            int TotalCount1 = 0;
            int TotalCount2 = 0;
            int TotalCount3 = 0;
            int TotalCount4 = 0;
            int TotalCount5 = 0;
            int TotalOther = 0;
            int TotalCountAll = 0;
            #endregion


            if (ddlMailType.SelectedItem.Value.Trim() == "0")
            {
                #region book_mnt1填入資料
                for (int ib1 = 0; ib1 < ds1.Tables[0].Rows.Count; ib1++)
                {
                    if (ds1.Tables[0].Rows[ib1]["tmp_otp1cd"].ToString() == preotp1cd)
                    {
                        Xls.SetCellValue(ib1 + 6, 2, "");
                    }
                    else
                    {
                        Xls.SetCellValue(ib1 + 6, 2, ds1.Tables[0].Rows[ib1]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib1 + 6, 3, ds1.Tables[0].Rows[ib1]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib1 + 6, 4, 1);
                    Xls.SetCellValue(ib1 + 6, 6, Convert.ToInt32(ds1.Tables[0].Rows[ib1]["tmp_param1"].ToString()));
                    preotp1cd = ds1.Tables[0].Rows[ib1]["tmp_otp1cd"].ToString();
                    TotalCount1 += Convert.ToInt32(ds1.Tables[0].Rows[ib1]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds1.Tables[0].Rows.Count + 6 + 1, 6, TotalCount1);//總分數1
                Xls.SetCellValue(ds1.Tables[0].Rows.Count + 6 + 1 + 1, 8, TotalCount1 * 1);//總本數1


                preotp1cd = "";
                for (int ib2 = 0; ib2 < ds2.Tables[0].Rows.Count; ib2++)
                {
                    if (ds2.Tables[0].Rows[ib2]["tmp_otp1cd"].ToString() == preotp1cd)
                    {
                        Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 2, "");
                    }
                    else
                    {
                        Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 2, ds2.Tables[0].Rows[ib2]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 3, ds2.Tables[0].Rows[ib2]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 4, 2);
                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 6, Convert.ToInt32(ds2.Tables[0].Rows[ib2]["tmp_param1"].ToString()));
                    preotp1cd = ds2.Tables[0].Rows[ib2]["tmp_otp1cd"].ToString();
                    TotalCount2 += Convert.ToInt32(ds2.Tables[0].Rows[ib2]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 11 + 1- 1, 6, TotalCount2);//總分數2
                Xls.SetCellValue(ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 11 + 1 + 1- 1, 8, TotalCount2 * 2);//總本數2

                preotp1cd = "";
                for (int ib3 = 0; ib3 < ds3.Tables[0].Rows.Count; ib3++)
                {
                    if (ds3.Tables[0].Rows[ib3]["tmp_otp1cd"].ToString() == preotp1cd)
                    {
                        Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 2, "");
                    }
                    else
                    {
                        Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 2, ds3.Tables[0].Rows[ib3]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 3, ds3.Tables[0].Rows[ib3]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 4, 3);
                    Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 6, Convert.ToInt32(ds3.Tables[0].Rows[ib3]["tmp_param1"].ToString()));
                    preotp1cd = ds3.Tables[0].Rows[ib3]["tmp_otp1cd"].ToString();
                    TotalCount3 += Convert.ToInt32(ds3.Tables[0].Rows[ib3]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 16 + 1 - 2, 6, TotalCount3);//總分數3
                Xls.SetCellValue(ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 16 + 1+ 1 - 2, 8, TotalCount3 * 3);//總本數3


                preotp1cd = "";
                for (int ib4 = 0; ib4 < ds4.Tables[0].Rows.Count; ib4++)
                {
                    if (ds4.Tables[0].Rows[ib4]["tmp_otp1cd"].ToString() == preotp1cd)
                    {
                        Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 2, "");
                    }
                    else
                    {
                        Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 2, ds4.Tables[0].Rows[ib4]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 3, ds4.Tables[0].Rows[ib4]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 4, 4);
                    Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 6, Convert.ToInt32(ds4.Tables[0].Rows[ib4]["tmp_param1"].ToString()));
                    preotp1cd = ds4.Tables[0].Rows[ib4]["tmp_otp1cd"].ToString();
                    TotalCount4 += Convert.ToInt32(ds4.Tables[0].Rows[ib4]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 21 + 1- 3, 6, TotalCount4);//總分數4
                Xls.SetCellValue(ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 21+ 1 + 1 - 3, 8, TotalCount4 * 4);//總本數4

                preotp1cd = "";
                for (int ib5 = 0; ib5 < ds5.Tables[0].Rows.Count; ib5++)
                {
                    if (ds5.Tables[0].Rows[ib5]["tmp_otp1cd"].ToString() == preotp1cd)
                    {
                        Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 2, "");
                    }
                    else
                    {
                        Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 2, ds5.Tables[0].Rows[ib5]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 3, ds5.Tables[0].Rows[ib5]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 4, 5);
                    Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 6, Convert.ToInt32(ds5.Tables[0].Rows[ib5]["tmp_param1"].ToString()));
                    preotp1cd = ds5.Tables[0].Rows[ib5]["tmp_otp1cd"].ToString();
                    TotalCount5 += Convert.ToInt32(ds5.Tables[0].Rows[ib5]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds5.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 26 + 1- 4, 6, TotalCount5);//總分數5
                Xls.SetCellValue(ds5.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 26 + 1 + 1 - 4, 8, TotalCount5 * 5);//總本數5

                for (int ib6 = 0; ib6 < ds6.Tables[0].Rows.Count; ib6++)
                {
                    Xls.SetCellValue(ib6 + 31 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count - 5, 4, ds6.Tables[0].Rows[ib6]["ra_mnt"].ToString());
                    Xls.SetCellValue(ib6 + 31 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count - 5, 6, 1);
                    TotalOther = 1;
                }

                //總份數
                TotalCountAll = TotalCount1 + TotalCount2 + TotalCount3 + TotalCount4 + TotalCount5 + TotalOther;
                Xls.SetCellValue(ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count + ds6.Tables[0].Rows.Count + 31 - 5 + 1 + 1, 6, TotalCountAll);
                //總本數
                TotalCountAll = TotalCount1 * 1 + TotalCount2 * 2 + TotalCount3 * 3 + TotalCount4 * 4 + TotalCount5 * 5 + TotalOther;
                Xls.SetCellValue(ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count + ds6.Tables[0].Rows.Count + 31 - 5 + 1 + 1 + 1, 8, TotalCountAll);

                #endregion
            }
            else
            {
                #region book_mnt2填入資料
                for (int ib1 = 0; ib1 < ds1.Tables[0].Rows.Count; ib1++)
                {
                    if (ds1.Tables[0].Rows[ib1]["tmp_btpcd"].ToString() == premtp)
                    {
                        Xls.SetCellValue(ib1 + 6, 2, "");
                        if (ds1.Tables[0].Rows[ib1]["tmp_otp1cd"].ToString() == preotp1cd)
                        {
                            Xls.SetCellValue(ib1 + 6, 3, "");
                        }
                        else
                        {
                            Xls.SetCellValue(ib1 + 6, 3, ds1.Tables[0].Rows[ib1]["otp_otp1nm"].ToString());
                        }
                    }
                    else
                    {
                        Xls.SetCellValue(ib1 + 6, 2, ds1.Tables[0].Rows[ib1]["mtp_nm"].ToString());
                        Xls.SetCellValue(ib1 + 6, 3, ds1.Tables[0].Rows[ib1]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib1 + 6, 4, ds1.Tables[0].Rows[ib1]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib1 + 6, 5, 1);
                    Xls.SetCellValue(ib1 + 6, 7,  Convert.ToInt32(ds1.Tables[0].Rows[ib1]["tmp_param1"].ToString()));
                    preotp1cd = ds1.Tables[0].Rows[ib1]["tmp_otp1cd"].ToString();
                    premtp = ds1.Tables[0].Rows[ib1]["tmp_btpcd"].ToString();
                    TotalCount1 += Convert.ToInt32(ds1.Tables[0].Rows[ib1]["tmp_param1"].ToString());   
                }

                Xls.SetCellValue(ds1.Tables[0].Rows.Count + 6 + 1, 7, TotalCount1);//總分數1
                Xls.SetCellValue(ds1.Tables[0].Rows.Count + 6 + 1 + 1, 9, TotalCount1 * 1);//總本數1

                preotp1cd = "";
                premtp = "";
                for (int ib2 = 0; ib2 < ds2.Tables[0].Rows.Count; ib2++)
                {
                    if (ds2.Tables[0].Rows[ib2]["tmp_btpcd"].ToString() == premtp)
                    {
                        Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 2, "");
                        if (ds2.Tables[0].Rows[ib2]["tmp_otp1cd"].ToString() == preotp1cd)
                        {
                            Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 3, "");
                        }
                        else
                        {
                            Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 3, ds2.Tables[0].Rows[ib2]["otp_otp1nm"].ToString());
                        }
                    }
                    else
                    {
                        Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 2, ds2.Tables[0].Rows[ib2]["mtp_nm"].ToString());
                        Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 3, ds2.Tables[0].Rows[ib2]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 4, ds2.Tables[0].Rows[ib2]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 5, 2);
                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 7,  Convert.ToInt32(ds2.Tables[0].Rows[ib2]["tmp_param1"].ToString()));
                    preotp1cd = ds2.Tables[0].Rows[ib2]["tmp_otp1cd"].ToString();
                    premtp = ds2.Tables[0].Rows[ib2]["tmp_btpcd"].ToString();
                    TotalCount2 += Convert.ToInt32(ds2.Tables[0].Rows[ib2]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 11 + 1 - 1, 7, TotalCount2);//總分數2
                Xls.SetCellValue(ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 11 + 1 + 1 - 1, 9, TotalCount2 * 2);//總本數2


                preotp1cd = "";
                premtp = "";
                for (int ib3 = 0; ib3 < ds3.Tables[0].Rows.Count; ib3++)
                {
                    if (ds3.Tables[0].Rows[ib3]["tmp_btpcd"].ToString() == premtp)
                    {
                        Xls.SetCellValue(ib3 + 6, 2, "");
                        if (ds3.Tables[0].Rows[ib3]["tmp_otp1cd"].ToString() == preotp1cd)
                        {
                            Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 3, "");
                        }
                        else
                        {
                            Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 3, ds3.Tables[0].Rows[ib3]["otp_otp1nm"].ToString());
                        }
                    }
                    else
                    {
                        Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 2, ds3.Tables[0].Rows[ib3]["mtp_nm"].ToString());
                        Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 3, ds3.Tables[0].Rows[ib3]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 4, ds3.Tables[0].Rows[ib3]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 5, 3);
                    Xls.SetCellValue(ib3 + 16 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count - 2, 7,  Convert.ToInt32(ds3.Tables[0].Rows[ib3]["tmp_param1"].ToString()));
                    preotp1cd = ds3.Tables[0].Rows[ib3]["tmp_otp1cd"].ToString();
                    premtp = ds3.Tables[0].Rows[ib3]["tmp_btpcd"].ToString();
                    TotalCount3 += Convert.ToInt32(ds3.Tables[0].Rows[ib3]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 16 + 1 - 2, 7, TotalCount3);//總分數3
                Xls.SetCellValue(ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 16 + 1 + 1 - 2, 9, TotalCount3 * 3);//總本數3

                preotp1cd = "";
                premtp = "";
                for (int ib4 = 0; ib4 < ds4.Tables[0].Rows.Count; ib4++)
                {
                    if (ds4.Tables[0].Rows[ib4]["tmp_btpcd"].ToString() == premtp)
                    {
                        Xls.SetCellValue(ib4 + 6, 2, "");
                        if (ds4.Tables[0].Rows[ib4]["tmp_otp1cd"].ToString() == preotp1cd)
                        {
                            Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 3, "");
                        }
                        else
                        {
                            Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 3, ds4.Tables[0].Rows[ib4]["otp_otp1nm"].ToString());
                        }
                    }
                    else
                    {
                        Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 2, ds4.Tables[0].Rows[ib4]["mtp_nm"].ToString());
                        Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 3, ds4.Tables[0].Rows[ib4]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 4, ds4.Tables[0].Rows[ib4]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 5, 4);
                    Xls.SetCellValue(ib4 + 21 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count - 3, 7,  Convert.ToInt32(ds4.Tables[0].Rows[ib4]["tmp_param1"].ToString()));
                    preotp1cd = ds4.Tables[0].Rows[ib4]["tmp_otp1cd"].ToString();
                    premtp = ds4.Tables[0].Rows[ib4]["tmp_btpcd"].ToString();
                    TotalCount4 += Convert.ToInt32(ds4.Tables[0].Rows[ib4]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 21 + 1 - 3, 7, TotalCount4);//總分數4
                Xls.SetCellValue(ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 21 + 1 + 1 - 3, 9, TotalCount4 * 4);//總本數4

                preotp1cd = "";
                premtp = "";
                for (int ib5 = 0; ib5 < ds5.Tables[0].Rows.Count; ib5++)
                {
                    if (ds5.Tables[0].Rows[ib5]["tmp_btpcd"].ToString() == premtp)
                    {
                        Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 2, "");
                        if (ds5.Tables[0].Rows[ib5]["tmp_otp1cd"].ToString() == preotp1cd)
                        {
                            Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 3, "");
                        }
                        else
                        {
                            Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 3, ds5.Tables[0].Rows[ib5]["otp_otp1nm"].ToString());
                        }
                    }
                    else
                    {
                        Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 2, ds5.Tables[0].Rows[ib5]["mtp_nm"].ToString());
                        Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 3, ds5.Tables[0].Rows[ib5]["otp_otp1nm"].ToString());
                    }

                    Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 4, ds5.Tables[0].Rows[ib5]["otp_otp2nm"].ToString());
                    Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 5, 5);
                    Xls.SetCellValue(ib5 + 26 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count - 4, 7,  Convert.ToInt32(ds5.Tables[0].Rows[ib5]["tmp_param1"].ToString()));
                    preotp1cd = ds5.Tables[0].Rows[ib5]["tmp_otp1cd"].ToString();
                    premtp = ds5.Tables[0].Rows[ib5]["tmp_btpcd"].ToString();
                    TotalCount5 += Convert.ToInt32(ds5.Tables[0].Rows[ib5]["tmp_param1"].ToString());
                }

                Xls.SetCellValue(ds5.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 26 + 1 - 4, 7, TotalCount5);//總分數5
                Xls.SetCellValue(ds5.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds1.Tables[0].Rows.Count + 26 + 1 + 1 - 4, 9, TotalCount5 * 5);//總本數5

                for (int ib6 = 0; ib6 < ds6.Tables[0].Rows.Count; ib6++)
                {
                    Xls.SetCellValue(ib6 + 31 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count - 5, 2, ds6.Tables[0].Rows[ib6]["mtp_nm"].ToString());
                    Xls.SetCellValue(ib6 + 31 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count - 5, 5, ds6.Tables[0].Rows[ib6]["ra_mnt"].ToString());
                    Xls.SetCellValue(ib6 + 31 + ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count - 5, 7, 1);
                    TotalOther = 1;
                }

                //總份數
                TotalCountAll = TotalCount1 + TotalCount2 + TotalCount3 + TotalCount4 + TotalCount5 + TotalOther;
                Xls.SetCellValue(ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count + ds6.Tables[0].Rows.Count + 31 - 5 + 1 + 1, 7, TotalCountAll);
                //總本數
                TotalCountAll = TotalCount1 * 1 + TotalCount2 * 2 + TotalCount3 * 3 + TotalCount4 * 4 + TotalCount5 * 5 + TotalOther;
                Xls.SetCellValue(ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + ds3.Tables[0].Rows.Count + ds4.Tables[0].Rows.Count + ds5.Tables[0].Rows.Count + ds6.Tables[0].Rows.Count + 31 - 5 + 1 + 1 + 1, 9, TotalCountAll);

                #endregion
            }

            Common.excuteExcel(Xls, ddlMailType.SelectedItem.Value.Trim() == "0" ? "book_mnt1.xls" : "book_mnt2.xls");
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            DataSet dsBookp = myBook.SelectBookp(ddlYear.SelectedValue.ToString() + ddlMonth.SelectedValue.ToString());

            if (dsBookp.Tables[0].Rows.Count > 0)
            {
                lbBookNo.Text = dsBookp.Tables[0].Rows[0]["bkp_pno"].ToString().Trim();
            }

            SearchIcon.Visible = true;
            myBook.sp_c1_tmp_statistics(ddlMailType.SelectedItem.Value.Trim(), ddlBookType.SelectedItem.Value.Trim()
                , ddlYear.SelectedItem.Value.Trim() + ddlMonth.SelectedItem.Value.Trim());


            DataSet ds = myBook.Selecttmp_statistics();
            GridView1.DataSource = ds;
            GridView1.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                btnPrintList.Enabled = true;
            }
            else
            {
                btnPrintList.Enabled = false;
            }
        }
    }
}