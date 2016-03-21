using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.Order
{
    public partial class OrderListFilter : System.Web.UI.Page
    {
        OrderListFilter_DB myOrder = new OrderListFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //付款方式
                DataSet ds3 = myOrder.SelectPytp();
                DataRow dr2 = ds3.Tables[0].NewRow();
                dr2["pytp_pytpcd"] = "00";
                dr2["pytp_nm"] = "請選擇";
                ds3.Tables[0].Rows.Add(dr2);
                ds3.Tables[0].DefaultView.Sort = "pytp_pytpcd ASC";
                DataView dv = ds3.Tables[0].DefaultView;
                ddlPayType.DataSource = dv;
                ddlPayType.DataTextField = "pytp_nm";
                ddlPayType.DataValueField = "pytp_pytpcd";
                ddlPayType.DataBind();
                btnPrintList.Enabled = false;
                //				Response.Write(Session["cname"].ToString());
            }
        }


        private DataSet Bind()
        {
            string STRddlPayType = "";
            string STRtbxOrderDate1 = "";
            string STRtbxOrderDate2 = "";
            string STRtbxDate1 = "";
            string STRtbxDate2 = "";
            string STRddlOrderType = "";
            string STRddlBookType = "";
            string STRtbxRecName = "";

            if (ddlPayType.SelectedValue.ToString().Trim() != "00")
            {
                STRddlPayType = ddlPayType.SelectedItem.Value.Trim();
            }
            if (tbxOrderDate1.Text.Trim() != "" && tbxOrderDate2.Text.Trim() != "")
            {
                STRtbxOrderDate1 = tbxOrderDate1.Text.Substring(0, 4) + tbxOrderDate1.Text.Substring(5, 2) + tbxOrderDate1.Text.Substring(8, 2);
                STRtbxOrderDate2 = tbxOrderDate2.Text.Substring(0, 4) + tbxOrderDate2.Text.Substring(5, 2) + tbxOrderDate2.Text.Substring(8, 2);
            }
            if (tbxDate1.Text.Trim() != "" && tbxDate2.Text.Trim() != "")
            {
                STRtbxDate1 = tbxDate1.Text.Substring(0, 4) + tbxDate1.Text.Substring(5, 2) + tbxDate1.Text.Substring(8, 2);
                STRtbxDate2 = tbxDate2.Text.Substring(0, 4) + tbxDate2.Text.Substring(5, 2) + tbxDate2.Text.Substring(8, 2);
            }
            if (ddlOrderType.SelectedValue.ToString().Trim() != "00")
            {
                STRddlOrderType = ddlOrderType.SelectedItem.Value.Trim();
            }
            if (ddlBookType.SelectedValue.ToString().Trim() != "")
            {
                STRddlBookType = ddlBookType.SelectedItem.Value.Trim();
            }
            if (tbxRecName.Text.Trim() != "")
            {
                STRtbxRecName = tbxRecName.Text.Trim();
            }

            DataSet ds1 = myOrder.Selectc1_od(STRddlPayType, STRtbxOrderDate1, STRtbxOrderDate2, STRtbxDate1, STRtbxDate2, STRddlOrderType, STRddlBookType, STRtbxRecName);

            return ds1;
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {

            GVSearchCust.DataSource = Bind();
            GVSearchCust.DataBind();

            if (Bind().Tables[0].Rows.Count > 0)
            {
                btnPrintList.Enabled = true;            
            }
            else
            {
                btnPrintList.Enabled = false;
            }
        }

        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //書籍類別
            DataSet ds2 = myOrder.Selectc1_obtp();
            DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
            dv2.RowFilter = "obtp_otp1cd='" + ddlOrderType.SelectedItem.Value + "'";
            ddlBookType.DataSource = dv2;
            ddlBookType.DataTextField = "obtp_obtpnm";
            ddlBookType.DataValueField = "obtp_obtpcd";
            ddlBookType.DataBind();
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Order/Template/" + "od_list.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            DataTable dt = Bind().Tables[0];

            TXlsCellRange myRange = new TXlsCellRange("A4:S4");
            TXlsCellRange myRange2 = new TXlsCellRange("A1:S4");
            //TFlxFormat tfMoney = Xls.GetDefaultFormat;
            //tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            //tfMoney.Font.Size20 = 160;
            //tfMoney.Format = "$#,##0";
            //int tfMoneyI = Xls.AddFormat(tfMoney);
            //tfMoney = null;

            if (dt.Rows.Count > 1)
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    Xls.InsertAndCopyRange(myRange, 5 + i, 1, 1, TFlxInsertMode.NoneDown);
                }
                //Xls.InsertAndCopyRange(myRange, 5, 1, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
            }
            else
            {
                //do nothing
            }

            Xls.InsertAndCopyRange(myRange2, dt.Rows.Count + 4 - 1 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            string preNo ="";
            string preBook = "";
            int Book01_Amt = 0;
            int Book02_Amt = 0;
            int Book_Other_Amt = 0;
            int Book01_New = 0;
            int Book01_Old = 0;
            int Book02_New = 0;
            int Book02_Old = 0;
            int Book_Other = 0;

            Xls.SetCellValue(2, 12, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(2,15,DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(2, 3, tbxOrderDate1.Text.Trim() != "" && tbxOrderDate2.Text.Trim() != "" ? tbxOrderDate1.Text.Trim() + "~" + tbxOrderDate2.Text.Trim() : "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["nostr"].ToString() == preNo)
                {
                    Xls.SetCellValue(i + 4, 1, "");
                    Xls.SetCellValue(i + 4, 2, "");
                    Xls.SetCellValue(i + 4, 3, "");
                    Xls.SetCellValue(i + 4, 4, "");
                    Xls.SetCellValue(i + 4, 5, "");
                    Xls.SetCellValue(i + 4, 10, dt.Rows[i]["or_nm"].ToString());
                    Xls.SetCellValue(i + 4, 12, dt.Rows[i]["or_zip"].ToString());
                    Xls.SetCellValue(i + 4, 13, dt.Rows[i]["or_addr"].ToString());
                    Xls.SetCellValue(i + 4, 15, dt.Rows[i]["ra_mnt"].ToString());
                    Xls.SetCellValue(i + 4, 18, dt.Rows[i]["srspn_cname"].ToString());
                    Xls.SetCellValue(i + 4, 19, "");
                    if (dt.Rows[i]["obtp_obtpnm"].ToString() == preBook)
                    {
                        Xls.SetCellValue(i + 4, 6, "");
                        Xls.SetCellValue(i + 4, 7, "");
                        Xls.SetCellValue(i + 4, 8, "");
                        Xls.SetCellValue(i + 4, 9, "");
                    }
                    else
                    {
                        Xls.SetCellValue(i + 4, 6, dt.Rows[i]["obtp_obtpnm"].ToString());
                        if (dt.Rows[i]["od_custtp"].ToString() == "0")
                        {
                            Xls.SetCellValue(i + 4, 7, "新");
                        }
                        else if (dt.Rows[i]["od_custtp"].ToString() == "1")
                        {
                            Xls.SetCellValue(i + 4, 7, "續");
                        }
                        else
                        {
                            Xls.SetCellValue(i + 4, 7, "");
                        }

                        if (dt.Rows[i]["datestr"].ToString().Substring(0, 1) == "1" || dt.Rows[i]["datestr"].ToString().Substring(0, 1) == "2")
                        {
                            Xls.SetCellValue(i + 4, 8, dt.Rows[i]["datestr"].ToString() == "" ? "" : dt.Rows[i]["datestr"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["datestr"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["datestr"].ToString().Substring(6, 3) + dt.Rows[i]["datestr"].ToString().Substring(9, 4) + "/" + dt.Rows[i]["datestr"].ToString().Substring(13, 2) + "/" + dt.Rows[i]["datestr"].ToString().Substring(15, 2));
                        }
                        else
                        {
                            Xls.SetCellValue(i + 4, 8, "");
                        }
                        Xls.SetCellValue(i + 4, 9, dt.Rows[i]["od_amt"].ToString());
                        if (dt.Rows[i]["obtp_obtpcd"].ToString() == "01")
                        {
                            Book01_Amt = Book01_Amt + Convert.ToInt32(dt.Rows[i]["od_amt"].ToString());
                        }
                        else if (dt.Rows[i]["obtp_obtpcd"].ToString() == "02")
                        {
                            Book02_Amt = Book02_Amt + Convert.ToInt32(dt.Rows[i]["od_amt"].ToString());
                        }
                        else
                        {
                            Book_Other_Amt = Book_Other_Amt + Convert.ToInt32(dt.Rows[i]["od_amt"].ToString());
                        }
                    }
                    preNo = dt.Rows[i]["nostr"].ToString();
                    preBook = dt.Rows[i]["obtp_obtpnm"].ToString();

                    if (dt.Rows[i]["obtp_obtpcd"].ToString() == "01")
                    {
                        if (dt.Rows[i]["nostr"].ToString().Substring(10, 3) == "001")
                        {
                            Book01_New = Book01_New + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                        else
                        {
                            Book01_Old = Book01_Old + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                    }
                    else if (dt.Rows[i]["obtp_obtpcd"].ToString() == "02")
                    {
                        if (dt.Rows[i]["nostr"].ToString().Substring(10, 3) == "001")
                        {
                            Book02_New = Book02_New + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                        else
                        {
                            Book02_Old = Book02_Old + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                    }
                    else
                    {
                        Book_Other = Book_Other + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                    }
                }
                else
                {
                    Xls.SetCellValue(i + 4, 1, i + 1);
                    Xls.SetCellValue(i + 4, 2, dt.Rows[i]["nostr"].ToString());
                    Xls.SetCellValue(i + 4, 3, dt.Rows[i]["pytp_nm"].ToString());
                    Xls.SetCellValue(i + 4, 4, dt.Rows[i]["ia_pyno"].ToString());
                    if (dt.Rows[i]["o_fgpreinv"].ToString() == "1")
                    {
                        Xls.SetCellValue(i + 4, 5, "是");
                    }
                    else
                    {
                        Xls.SetCellValue(i + 4, 5, "否");
                    }
                    Xls.SetCellValue(i + 4, 6, dt.Rows[i]["obtp_obtpnm"].ToString());
                    Xls.SetCellValue(i + 4, 19, dt.Rows[i]["o_date"].ToString() == "" ? "" : dt.Rows[i]["o_date"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["o_date"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["o_date"].ToString().Substring(6, 2));
                    if (dt.Rows[i]["od_custtp"].ToString() == "0")
                    {
                        Xls.SetCellValue(i + 4, 7, "新");
                    }
                    else if (dt.Rows[i]["od_custtp"].ToString() == "1")
                    {
                        Xls.SetCellValue(i + 4, 7, "續");
                    }
                    else
                    {
                        Xls.SetCellValue(i + 4, 7, "");
                    }
                    if (dt.Rows[i]["datestr"].ToString().Substring(0, 1) == "1" || dt.Rows[i]["datestr"].ToString().Substring(0, 1) == "2")
                    {
                        Xls.SetCellValue(i + 4, 8, dt.Rows[i]["datestr"].ToString() == "" ? "" : dt.Rows[i]["datestr"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["datestr"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["datestr"].ToString().Substring(6, 3) + dt.Rows[i]["datestr"].ToString().Substring(9, 4) + "/" + dt.Rows[i]["datestr"].ToString().Substring(13, 2) + "/" + dt.Rows[i]["datestr"].ToString().Substring(15, 2));
                    }
                    else
                    {
                        Xls.SetCellValue(i + 4, 8, "");
                    }

                    Xls.SetCellValue(i + 4, 9, dt.Rows[i]["od_amt"].ToString());
                    if (dt.Rows[i]["obtp_obtpcd"].ToString() == "01")
                    {
                        Book01_Amt = Book01_Amt + Convert.ToInt32(dt.Rows[i]["od_amt"].ToString());
                    }
                    else if (dt.Rows[i]["obtp_obtpcd"].ToString() == "02")
                    {
                        Book02_Amt = Book02_Amt + Convert.ToInt32(dt.Rows[i]["od_amt"].ToString());
                    }
                    else
                    {
                        Book_Other_Amt = Book_Other_Amt + Convert.ToInt32(dt.Rows[i]["od_amt"].ToString());
                    }

                    Xls.SetCellValue(i + 4, 10, dt.Rows[i]["or_nm"].ToString());
                    Xls.SetCellValue(i + 4, 11, dt.Rows[i]["or_inm"].ToString());
                    Xls.SetCellValue(i + 4, 12, dt.Rows[i]["or_zip"].ToString());
                    Xls.SetCellValue(i + 4, 13, dt.Rows[i]["or_addr"].ToString());
                    Xls.SetCellValue(i + 4, 14, dt.Rows[i]["or_tel"].ToString());
                    Xls.SetCellValue(i + 4, 15, dt.Rows[i]["ra_mnt"].ToString());
                    Xls.SetCellValue(i + 4, 16, "");
                    Xls.SetCellValue(i + 4, 17, "");
                    Xls.SetCellValue(i + 4, 18, dt.Rows[i]["srspn_cname"].ToString());
                    preNo = dt.Rows[i]["nostr"].ToString();
                    preBook = dt.Rows[i]["obtp_obtpnm"].ToString();

                    if (dt.Rows[i]["obtp_obtpcd"].ToString() == "01")
                    {
                        if (dt.Rows[i]["nostr"].ToString().Substring(10, 3) == "001")
                        {
                            Book01_New = Book01_New + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                        else
                        {
                            Book01_Old = Book01_Old + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                    }
                    else if (dt.Rows[i]["obtp_obtpcd"].ToString() == "02")
                    {
                        if (dt.Rows[i]["nostr"].ToString().Substring(10, 3) == "001")
                        {
                            Book02_New = Book02_New + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                        else
                        {
                            Book02_Old = Book02_Old + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                        }
                    }
                    else
                    {
                        Book_Other = Book_Other + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                    }
                }


                //Xls.SetCellValue(i + 4, 10, i + 1);
            }

            Xls.SetCellValue(dt.Rows.Count + 3 + 1, 3, Book01_New);
            //Xls.SetCellValue(dt.Rows.Count + 3 + 2, 3, Book02_New);
            Xls.SetCellValue(dt.Rows.Count + 3 + 2, 3, Book_Other);
            Xls.SetCellValue(dt.Rows.Count + 3 + 1, 7, Book01_Old);
            //Xls.SetCellValue(dt.Rows.Count + 3 + 2, 7, Book02_Old);
            Xls.SetCellValue(dt.Rows.Count + 3 + 1, 10, Book01_Amt);
            //Xls.SetCellValue(dt.Rows.Count + 3 + 2, 10, Book02_Amt);
            Xls.SetCellValue(dt.Rows.Count + 3 + 2, 10, Book_Other_Amt);

            //最後把sheet2內的東西刪除
            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRange2, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
            Xls.ActiveSheet = 1;
            Common.excuteExcel(Xls, "od_list.xls");
        }
    }
}
