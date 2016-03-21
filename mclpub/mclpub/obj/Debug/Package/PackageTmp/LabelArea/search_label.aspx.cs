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

namespace mclpub.LabelArea
{
    public partial class search_label : System.Web.UI.Page
    {
        search_label_DB mysearch = new search_label_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int myYear = System.DateTime.Today.Year;
                for (int i = myYear - 10; i <= myYear + 1; i++)
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlYear.Items.FindByValue(myYear.ToString().Trim()).Selected = true;
                int myMonth = System.DateTime.Today.Month;
                ddlMonth.SelectedIndex = myMonth - 1;
                //郵寄類別
                DataSet ds1 = mysearch.SelectMtp();
                DataView dv1 = ds1.Tables["mtp"].DefaultView;
                if (ddlMosea.SelectedItem.Value == "0")
                    dv1.RowFilter = "mtp_mtpcd LIKE '1%'";
                else
                    dv1.RowFilter = "mtp_mtpcd LIKE '2%'";
                ddlMailType.DataSource = dv1;
                ddlMailType.DataTextField = "mtp_nm";
                ddlMailType.DataValueField = "mtp_mtpcd";
                ddlMailType.DataBind();
                //書籍類別
                DataSet ds2 = mysearch.Selectc1_obtp();
                DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
                dv2.RowFilter = "obtp_otp1cd='" + ddlOrderType1.SelectedItem.Value + "'";
                ddlBookType.DataSource = dv2;
                ddlBookType.DataTextField = "obtp_obtpnm";
                ddlBookType.DataValueField = "obtp_obtpcd";
                ddlBookType.DataBind();
                //訂購類別二
                DataSet ds3 = mysearch.Selectc1_otp();
                DataView dv3 = ds3.Tables["c1_otp"].DefaultView;
                dv3.RowFilter = "otp_otp1cd='" + ddlOrderType1.SelectedItem.Value + "'";
                ddlOrderType2.DataSource = dv3;
                ddlOrderType2.DataTextField = "otp_otp2nm";
                ddlOrderType2.DataValueField = "otp_otp2cd";
                ddlOrderType2.DataBind();

                SearchIcon.Visible = false;
                btnPrintLabel.Enabled = false;
                btnPrintList.Enabled = false;

                //根據郵寄年月來改變期別欄位
                DataSet dtTop = mysearch.SelectBookpNoOrderByDate(ddlYear.SelectedItem.Value.ToString()+ddlMonth.SelectedItem.Value.ToString());
                tbxBookNo.Text = dtTop.Tables[0].Rows[0]["bkp_pno"].ToString();
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            //Response.Write("訂購類別1:" + ddlOrderType1.SelectedItem.Value + ",訂購類別2:" + ddlOrderType2.SelectedItem.Value + "書籍類別:" + ddlBookType.SelectedItem.Value);
            mysearch.UpdateTmp1("C1", ddlOrderType1.SelectedItem.Value, ddlMailType.SelectedItem.Value, ddlBookType.SelectedItem.Value, ddlYear.SelectedItem.Value.Trim() + ddlMonth.SelectedItem.Value.Trim());
            DataSet ds4 = mysearch.SelectTmp_label1();
            DataView dv4 = ds4.Tables["tmp_label1"].DefaultView;
            string strbuf = "o_otp2cd=" + ddlOrderType2.SelectedItem.Value;
            if (ddlMnt.SelectedItem.Value == "0")//5本以上(不含5本)
                strbuf += " and ra_mnt>5";
            else
                strbuf += " and ra_mnt=" + ddlMnt.SelectedItem.Value;
            dv4.RowFilter = strbuf;
            lblMessage.Text = "查詢到" + dv4.Count.ToString() + "筆資料";
            SearchIcon.Visible = true;
            if (dv4.Count <= 0)
            {
                lblMessage.Visible = false;
                btnPrintLabel.Enabled = false;
                btnPrintList.Enabled = false;
            }
            else
            {
                lblMessage.Visible = true;
                btnPrintLabel.Enabled = true;
                btnPrintList.Enabled = true;
            }
            GVSearchLabel.DataSource = dv4;
            GVSearchLabel.DataBind();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void ddlOrderType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //書籍類別
            DataSet ds2 = mysearch.Selectc1_obtp();
            DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
            dv2.RowFilter = "obtp_otp1cd='" + ddlOrderType1.SelectedItem.Value + "'";
            ddlBookType.DataSource = dv2;
            ddlBookType.DataTextField = "obtp_obtpnm";
            ddlBookType.DataValueField = "obtp_obtpcd";
            ddlBookType.DataBind();
            //訂購類別二
            DataSet ds3 = mysearch.Selectc1_otp();
            DataView dv3 = ds3.Tables["c1_otp"].DefaultView;
            dv3.RowFilter = "otp_otp1cd='" + ddlOrderType1.SelectedItem.Value + "'";
            ddlOrderType2.DataSource = dv3;
            ddlOrderType2.DataTextField = "otp_otp2nm";
            ddlOrderType2.DataValueField = "otp_otp2cd";
            ddlOrderType2.DataBind();
            if (ddlOrderType1.SelectedItem.Value == "09")
            {
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
            }
            else
            {
                ddlYear.Enabled = true;
                ddlMonth.Enabled = true;
            }
        }

        protected void ddlMosea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds1 = mysearch.SelectMtp();
            DataView dv1 = ds1.Tables["mtp"].DefaultView;
            if (ddlMosea.SelectedItem.Value == "0")
                dv1.RowFilter = "mtp_mtpcd LIKE '1%'";
            else
                dv1.RowFilter = "mtp_mtpcd LIKE '2%'";
            ddlMailType.DataSource = dv1;
            ddlMailType.DataTextField = "mtp_nm";
            ddlMailType.DataValueField = "mtp_mtpcd";
            ddlMailType.DataBind();
        }

        protected void btnPrintLabel_Click(object sender, EventArgs e)
        {
            string strbuf;
            strbuf = "label.aspx?type2=" + ddlOrderType2.SelectedItem.Value + "&mosea=" + ddlMosea.SelectedItem.Value
                    + "&book=" + tbxBookNo.Text + "&mnt=" + ddlMnt.SelectedItem.Value;
            this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>"); 
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            string empnoST = Account.GetAccInfo().srspn_empno;
            DataSet ds5 = mysearch.SelectSrspn();
            DataView dv5 = ds5.Tables[0].DefaultView;
            dv5.RowFilter = "srspn_empno = '" + empnoST + "'";
            if (dv5.Count >= 0)
            {
                DataSet ds = mysearch.SelectExportExcel(ddlOrderType2.SelectedItem.Value, ddlMnt.SelectedItem.Value);
                DataTable dt = ds.Tables[0];

                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                string fileSpec = Server.MapPath("~/LabelArea/Template/mail_list1.xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;

                TXlsCellRange myRange = new TXlsCellRange("A5:K5");
                TXlsCellRange myRange2 = new TXlsCellRange("A1:K1");

                if (dt.Rows.Count > 1)
                {
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    Xls.InsertAndCopyRange(myRange, 5 + i, 1, 1, TFlxInsertMode.NoneDown);
                    //}
                    Xls.InsertAndCopyRange(myRange, 6, 1, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                }
                else
                {
                    //do nothing
                }
                Xls.InsertAndCopyRange(myRange2, dt.Rows.Count + 4 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                if (dt.Rows[0]["or_fgmosea"].ToString() == "0")
                {
                    Xls.SetCellValue(2, 3, "國內");
                }
                else
                {
                    Xls.SetCellValue(2, 3, "國外");
                }

                Xls.SetCellValue(3, 3, dt.Rows[0]["mtp_nm"].ToString());
                Xls.SetCellValue(2, 8, DateTime.Now.ToString("yyyy/MM/dd"));
                Xls.SetCellValue(3, 8, Account.GetAccInfo().srspn_cname.ToString().Trim());
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Xls.SetAutoRowHeight(i + 5, true);
                    Xls.SetCellValue(i + 5, 1, i + 1);
                    Xls.SetCellValue(i + 5, 2, dt.Rows[i]["or_nm"].ToString());
                    Xls.SetCellValue(i + 5, 3, dt.Rows[i]["or_zip"].ToString());
                    Xls.SetCellValue(i + 5, 4, dt.Rows[i]["or_addr"].ToString());
                    Xls.SetCellValue(i + 5, 5, dt.Rows[i]["od_syscd"].ToString() + dt.Rows[i]["od_custno"].ToString().Trim() + dt.Rows[i]["od_otp1seq"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 6, dt.Rows[i]["o_date"].ToString() == "" ? "" : dt.Rows[i]["o_date"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["o_date"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["o_date"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 5, 7, dt.Rows[i]["od_custno"].ToString());
                    Xls.SetCellValue(i + 5, 8, dt.Rows[i]["cust_nm"].ToString());
                    Xls.SetCellValue(i + 5, 9, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 5, 10, dt.Rows[i]["od_sdate"].ToString() + "~" + dt.Rows[i]["od_edate"].ToString());
                    Xls.SetCellValue(i + 5, 11, dt.Rows[i]["ra_mnt"].ToString());
                    count = count + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                }

                Xls.SetCellValue(dt.Rows.Count + 4 + 1, 11, count);

                Xls.ActiveSheet = 2;
                Xls.DeleteRange(myRange2, TFlxInsertMode.NoneDown);
                Xls.ActiveSheet = 1;

                Common.excuteExcel(Xls, "mail_list1.xls");

            }
            else
            {
                JavaScript.AlertMessage(this.Page, "權限不足");
                return;
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根據郵寄年月來改變期別欄位
            DataSet dtTop = mysearch.SelectBookpNoOrderByDate(ddlYear.SelectedItem.Value.ToString() + ddlMonth.SelectedItem.Value.ToString());
            tbxBookNo.Text = dtTop.Tables[0].Rows[0]["bkp_pno"].ToString();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根據郵寄年月來改變期別欄位
            DataSet dtTop = mysearch.SelectBookpNoOrderByDate(ddlYear.SelectedItem.Value.ToString() + ddlMonth.SelectedItem.Value.ToString());
            tbxBookNo.Text = dtTop.Tables[0].Rows[0]["bkp_pno"].ToString();
        }
    }
}