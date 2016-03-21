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

namespace mclpub.Subscriber
{
    public partial class Printadvert : System.Web.UI.Page
    {
        Printadvert_DB myPrint = new Printadvert_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            DataTable dt = myPrint.SelectddlItpcdDrpdownList();
            DataRow dr = dt.NewRow();
            dr["itp_itpcd"] = "00";
            dr["itp_nm"] = "請選擇";
            dt.Rows.Add(dr);

            dt.DefaultView.Sort = "itp_itpcd ASC";
            ddlItpcd.DataTextField = dt.Columns[1].ToString();
            ddlItpcd.DataValueField = dt.Columns[0].ToString();
            ddlItpcd.DataSource = dt.DefaultView;
            ddlItpcd.DataBind();

            DataTable dt2 = myPrint.SelectddlBtpcdDrpdownList();
            DataRow dr2 = dt2.NewRow();
            dr2["btp_btpcd"] = "00";
            dr2["btp_nm"] = "請選擇";
            dt2.Rows.Add(dr2);

            dt2.DefaultView.Sort = "btp_btpcd ASC";
            ddlBtpcd.DataTextField = dt2.Columns[1].ToString();
            ddlBtpcd.DataValueField = dt2.Columns[0].ToString();
            ddlBtpcd.DataSource = dt2.DefaultView;
            ddlBtpcd.DataBind();


            DataTable dt3 = myPrint.SelectddlBookCodeDrpdownList();
            DataRow dr3 = dt3.NewRow();
            dr3["bk_bkcd"] = "00";
            dr3["bk_nm"] = "請選擇";
            dt3.Rows.Add(dr3);

            dt3.DefaultView.Sort = "bk_bkcd ASC";
            ddlBookCode.DataTextField = dt3.Columns[2].ToString();
            ddlBookCode.DataValueField = dt3.Columns[1].ToString();
            ddlBookCode.DataSource = dt3.DefaultView;
            ddlBookCode.DataBind();


            dt3.DefaultView.Sort = "bk_bkcd ASC";
            ddlBookCode2.DataTextField = dt3.Columns[2].ToString();
            ddlBookCode2.DataValueField = dt3.Columns[1].ToString();
            ddlBookCode2.DataSource = dt3.DefaultView;
            ddlBookCode2.DataBind();



            DataTable dt4 = myPrint.SelectddlMtpcdDrpdownList();
            DataRow dr4 = dt4.NewRow();
            dr4["mtp_mtpcd"] = "00";
            dr4["mtp_nm"] = "請選擇";
            dt4.Rows.Add(dr4);

            dt4.DefaultView.Sort = "mtp_mtpcd ASC";
            ddlMtpcd.DataTextField = dt4.Columns[1].ToString();
            ddlMtpcd.DataValueField = dt4.Columns[0].ToString();
            ddlMtpcd.DataSource = dt4.DefaultView;
            ddlMtpcd.DataBind();
        }

        protected void CheckBtn1_Click(object sender, EventArgs e)
        {
            string CustNoQ1 = "";
            string CustNoQ2 = "";
            string TelAC = "";
            string Itpcd = "00";
            string Btpcd = "00";

            if (tbxCustNoQ1.Text.Trim() != "" && tbxCustNoQ2.Text.Trim() != "")
            {
                CustNoQ1 = this.tbxCustNoQ1.Text.ToString().Trim();
                CustNoQ2 = this.tbxCustNoQ2.Text.ToString().Trim();
            }
            if (tbxTelAC.Text.Trim() != "")
            {
                TelAC = this.tbxTelAC.Text.ToString().Trim();
            }
            if (ddlItpcd.SelectedValue.ToString() != "00")
            {
                Itpcd = ddlItpcd.SelectedValue.ToString();
            }
            if (ddlBtpcd.SelectedValue.ToString() != "00")
            {
                Btpcd = ddlBtpcd.SelectedValue.ToString();
            }

            DataTable dt = myPrint.Select1Chkbtn(CustNoQ1, CustNoQ2, TelAC, Itpcd, Btpcd);


            string msg = CheckData1(dt);
            if (msg.Length > 0)
            {
                this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                return;
            }

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Subscriber/Template/" + "Printadvert.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            Xls.SetCellValue(3, 3, DateTime.Now.ToString("yyyy/MM/dd"));

            if (dt.Rows.Count > 0)
            {
                int count = 0;//因為底下的底色的關係 所以要有個flag
                for (int i = 6; i < (dt.Rows.Count * 2) + 6; i = i + 2)
                {
                    count = count + 1;
                    if (count % 2 == 0)
                    {
                        Xls.SetCellValue(i, 1, "", 12);
                        Xls.SetCellValue(i, 2, "", 12);
                        Xls.SetCellValue(i, 3, "", 12);
                        Xls.SetCellValue(i, 4, "", 12);
                        Xls.SetCellValue(i, 5, "", 12);
                        Xls.SetCellValue(i, 6, "", 12);
                        Xls.SetCellValue(i, 7, "", 12);
                        Xls.SetCellValue(i, 8, "", 12);
                        Xls.SetCellValue(i, 9, "", 12);
                        Xls.SetCellValue(i, 10, "", 12);
                        Xls.SetCellValue(i, 11, "", 12);

                        Xls.SetCellValue(i + 1, 1, "", 12);
                        Xls.SetCellValue(i + 1, 2, "", 12);
                        Xls.SetCellValue(i + 1, 3, "", 12);
                        Xls.SetCellValue(i + 1, 4, "", 12);
                        Xls.SetCellValue(i + 1, 5, "", 12);
                        Xls.SetCellValue(i + 1, 6, "", 12);
                        Xls.SetCellValue(i + 1, 7, "", 12);
                        Xls.SetCellValue(i + 1, 8, "", 12);
                        Xls.SetCellValue(i + 1, 9, "", 12);
                        Xls.SetCellValue(i + 1, 10, "", 12);
                        Xls.SetCellValue(i + 1, 11, "", 12);
                    }

                    Xls.SetCellValue(i, 1, dt.Rows[((i + 1) / 2) - 3]["cust_custno"].ToString());
                    Xls.SetCellValue(i, 2, dt.Rows[((i + 1) / 2) - 3]["cust_mfrno"].ToString());
                    Xls.SetCellValue(i, 3, dt.Rows[((i + 1) / 2) - 3]["cust_nm"].ToString());
                    Xls.SetCellValue(i, 4, dt.Rows[((i + 1) / 2) - 3]["cust_jbti"].ToString());
                    Xls.SetCellValue(i, 5, dt.Rows[((i + 1) / 2) - 3]["cust_tel"].ToString());
                    Xls.SetCellValue(i, 6, dt.Rows[((i + 1) / 2) - 3]["cust_fax"].ToString());
                    Xls.SetCellValue(i, 7, dt.Rows[((i + 1) / 2) - 3]["cust_cell"].ToString());
                    Xls.SetCellValue(i, 8, dt.Rows[((i + 1) / 2) - 3]["cust_email"].ToString());
                    Xls.SetCellValue(i, 9, dt.Rows[((i + 1) / 2) - 3]["cust_itpcd"].ToString());
                    Xls.SetCellValue(i, 10, dt.Rows[((i + 1) / 2) - 3]["cust_btpcd"].ToString());
                    Xls.SetCellValue(i, 11, dt.Rows[((i + 1) / 2) - 3]["cust_rtpcd"].ToString());
                    Xls.SetCellValue(i + 1, 2, dt.Rows[((i + 1) / 2) - 3]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 1, 3, dt.Rows[((i + 1) / 2) - 3]["mfr_izip"].ToString());
                    Xls.SetCellValue(i + 1, 4, dt.Rows[((i + 1) / 2) - 3]["mfr_iaddr"].ToString());
                    Xls.SetCellValue(i + 1, 5, dt.Rows[((i + 1) / 2) - 3]["cust_regdate"].ToString().Trim() == "" ? "" : dt.Rows[((i + 1) / 2) - 3]["cust_regdate"].ToString().Substring(0, 4) + "/" + dt.Rows[((i + 1) / 2) - 3]["cust_regdate"].ToString().Substring(4, 2) + "/" + dt.Rows[((i + 1) / 2) - 3]["cust_regdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 1, 7, dt.Rows[((i + 1) / 2) - 3]["mfr_respnm"].ToString());


                }
            }

            Common.excuteExcel(Xls, "Printadvert.xls");

        }

        protected void CheckBtn2_Click(object sender, EventArgs e)
        {
            DataTable dt = myPrint.Select2Chkbtn(ddlConttp.SelectedValue.ToString(), ddlBookCode.SelectedValue.ToString());
            //Response.Write(dt.Rows.Count);
            string msg = CheckData2(dt);
            if (msg.Length > 0)
            {
                this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                return;
            }

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Subscriber/Template/" + "Printadvert2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            Xls.SetCellValue(3, 3, ddlConttp.SelectedItem.Text);
            Xls.SetCellValue(4, 3, ddlBookCode.SelectedItem.Text);
            Xls.SetCellValue(3, 12, Account.GetAccInfo().srspn_cname.ToString());
            Xls.SetCellValue(4, 12, DateTime.Now.ToString("yyyy/MM/dd"));
            if (dt.Rows.Count > 0)
            {
                int count = 0;//因為底下的底色的關係 所以要有個flag
                for (int i = 7; i < (dt.Rows.Count * 2) + 7; i = i + 2)
                {
                    count = count + 1;
                    if (count % 2 == 0)
                    {
                        Xls.SetCellValue(i, 1, null, 12);
                        Xls.SetCellValue(i, 2, null, 12);
                        Xls.SetCellValue(i, 3, null, 12);
                        Xls.SetCellValue(i, 4, null, 12);
                        Xls.SetCellValue(i, 5, null, 12);
                        Xls.SetCellValue(i, 6, null, 12);
                        Xls.SetCellValue(i, 7, null, 12);
                        Xls.SetCellValue(i, 8, null, 12);
                        Xls.SetCellValue(i, 9, null, 12);
                        Xls.SetCellValue(i, 10, null, 12);
                        Xls.SetCellValue(i, 11, null, 12);
                        Xls.SetCellValue(i, 12, null, 12);
                        Xls.SetCellValue(i, 13, null, 12);

                        Xls.SetCellValue(i + 1, 1, null, 12);
                        Xls.SetCellValue(i + 1, 2, null, 12);
                        Xls.SetCellValue(i + 1, 3, null, 12);
                        Xls.SetCellValue(i + 1, 4, null, 12);
                        Xls.SetCellValue(i + 1, 5, null, 12);
                        Xls.SetCellValue(i + 1, 6, null, 12);
                        Xls.SetCellValue(i + 1, 7, null, 12);
                        Xls.SetCellValue(i + 1, 8, null, 12);
                        Xls.SetCellValue(i + 1, 9, null, 12);
                        Xls.SetCellValue(i + 1, 10, null, 12);
                        Xls.SetCellValue(i + 1, 11, null, 12);
                        Xls.SetCellValue(i + 1, 12, null, 12);
                        Xls.SetCellValue(i + 1, 13, null, 12);
                    }

                    Xls.SetCellValue(i, 1, ((i / 2) - 2).ToString());
                    Xls.SetCellValue(i, 2, dt.Rows[(i / 2) - 3]["cont_contno"].ToString());
                    Xls.SetCellValue(i, 3, dt.Rows[(i / 2) - 3]["cont_custno"].ToString());
                    Xls.SetCellValue(i, 4, dt.Rows[(i / 2) - 3]["cont_mfrno"].ToString());
                    Xls.SetCellValue(i, 5, dt.Rows[(i / 2) - 3]["mfr_inm"].ToString());
                    Xls.SetCellValue(i, 6, dt.Rows[(i / 2) - 3]["cust_nm"].ToString());
                    Xls.SetCellValue(i, 7, dt.Rows[(i / 2) - 3]["cust_jbti"].ToString());
                    Xls.SetCellValue(i, 8, dt.Rows[(i / 2) - 3]["cust_tel"].ToString());
                    Xls.SetCellValue(i, 9, dt.Rows[(i / 2) - 3]["cust_fax"].ToString());
                    Xls.SetCellValue(i, 10, dt.Rows[(i / 2) - 3]["cust_cell"].ToString());
                    Xls.SetCellValue(i, 11, dt.Rows[(i / 2) - 3]["cust_email"].ToString());
                    Xls.SetCellValue(i, 12, dt.Rows[(i / 2) - 3]["cust_regdate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 3]["cust_regdate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 3]["cust_regdate"].ToString().Substring(4, 2) + "/" + dt.Rows[(i / 2) - 3]["cust_regdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i, 13, dt.Rows[(i / 2) - 3]["cust_moddate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 3]["cust_moddate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 3]["cust_moddate"].ToString().Substring(4, 2) + "/" + dt.Rows[(i / 2) - 3]["cust_moddate"].ToString().Substring(6, 2));

                    Xls.SetCellValue(i + 1, 3, dt.Rows[(i / 2) - 3]["mfr_respnm"].ToString());
                    Xls.SetCellValue(i + 1, 4, dt.Rows[(i / 2) - 3]["mfr_respjbti"].ToString());
                    Xls.SetCellValue(i + 1, 5, dt.Rows[(i / 2) - 3]["mfr_iaddr"].ToString());
                    Xls.SetCellValue(i + 1, 6, dt.Rows[(i / 2) - 3]["cont_signdate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 3]["cont_signdate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 3]["cont_signdate"].ToString().Substring(4, 2) + "/" + dt.Rows[(i / 2) - 3]["cont_signdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 1, 7, dt.Rows[(i / 2) - 3]["cont_sdate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 3]["cont_sdate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 3]["cont_sdate"].ToString().Substring(4, 2));
                    Xls.SetCellValue(i + 1, 8, dt.Rows[(i / 2) - 3]["cont_edate"].ToString().Trim() == "" ? "" : dt.Rows[(i / 2) - 3]["cont_edate"].ToString().Substring(0, 4) + "/" + dt.Rows[(i / 2) - 3]["cont_edate"].ToString().Substring(4, 2));
                    Xls.SetCellValue(i + 1, 9, dt.Rows[(i / 2) - 3]["srspn_cname"].ToString());
                    Xls.SetCellValue(i + 1, 10, dt.Rows[(i / 2) - 3]["cont_aunm"].ToString());
                    Xls.SetCellValue(i + 1, 11, dt.Rows[(i / 2) - 3]["cont_autel"].ToString());
                }
                //Xls.SetCellValue(1, 1, 1,"",12);
            }

            Common.excuteExcel(Xls, "Printadvert2.xls");

        }

        protected void CheckBtn3_Click(object sender, EventArgs e)
        {
            DataTable dt = myPrint.Select3Chkbtn(ddlConttp2.SelectedValue.ToString(), ddlBookCode2.SelectedValue.ToString(), ddlMtpcd.SelectedValue.ToString());
            string msg = CheckData3(dt);
            if (msg.Length > 0)
            {
                this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                return;
            }

            string strConttp = this.ddlConttp2.SelectedValue.ToString();
            string strBkcd = this.ddlBookCode2.SelectedValue.ToString();
            string strMtpcd = this.ddlMtpcd.SelectedValue.ToString();
            string strLoginEmpNo = Account.GetAccInfo().srspn_empno.ToString().Trim();
            string RedirectURL = "Printadvert2.aspx";
            RedirectURL = RedirectURL + "?conttp=" + strConttp + "&bkcd=" + strBkcd + "&LEmpNo=" + strLoginEmpNo;

            if (ddlMtpcd.SelectedValue.ToString() != "00")
            {
                RedirectURL = RedirectURL + "&mtpcd=" + strMtpcd;
            }
            else
            {
                RedirectURL = RedirectURL + "&mtpcd=";
            }

            this.Page.Controls.Add(new LiteralControl("<script>window.open('" + RedirectURL + "');</script>"));
        }




        private string CheckData1(DataTable dt)
        {
            string msg = "";
            if (dt.Rows.Count == 0)
            {
                msg += "找不到符合條件的資料, 您可以重設條件!\\r\\n";
            }
            return msg;
        }

        private string CheckData2(DataTable dt)
        {
            string msg = "";
            if (ddlConttp.SelectedValue.ToString() == "00")
            {
                msg += "請選擇合約類別!\\r\\n";
            }

            if (ddlBookCode.SelectedValue.ToString() == "00")
            {
                msg += "請選擇書籍類別!\\r\\n";
            }

            if (ddlConttp.SelectedValue.ToString() != "00" && dt.Rows.Count == 0 && ddlBookCode.SelectedValue.ToString() != "00")
            {
                msg += "找不到符合條件的資料, 您可以重設條件!\\r\\n";
            }

            return msg;
        }

        private string CheckData3(DataTable dt)
        {
            string msg = "";
            if (ddlConttp2.SelectedValue.ToString() == "00")
            {
                msg += "請選擇合約類別!\\r\\n";
            }

            if (ddlBookCode2.SelectedValue.ToString() == "00")
            {
                msg += "請選擇書籍類別!\\r\\n";
            }

            if (ddlConttp2.SelectedValue.ToString() != "00" && dt.Rows.Count == 0 && ddlBookCode2.SelectedValue.ToString() != "00")
            {
                msg += "找不到符合條件的資料, 您可以重設條件!\\r\\n";
            }
            return msg;
        }
    }
}
