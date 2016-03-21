using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.Subscriber
{
    public partial class CustListFilter : System.Web.UI.Page
    {
        CustListFilter_DB myCust = new CustListFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 榜定dropdownlist預設值
                DataTable dt = new DataTable();
                dt.Columns.Add("otp_otp2cd", typeof(string));
                dt.Columns.Add("otp_otp2nm", typeof(string));
                DataRow dr = dt.NewRow();
                dr["otp_otp2cd"] = "0";
                dr["otp_otp2nm"] = "請選擇";
                dt.Rows.Add(dr);

                dt.DefaultView.Sort = "otp_otp2cd ASC";
                ddlOrderType2.DataTextField = dt.Columns[1].ToString();
                ddlOrderType2.DataValueField = dt.Columns[0].ToString();
                ddlOrderType2.DataSource = dt.DefaultView;
                ddlOrderType2.DataBind();

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("obtp_obtpcd", typeof(string));
                dt2.Columns.Add("obtp_obtpnm", typeof(string));
                DataRow dr2 = dt2.NewRow();
                dr2["obtp_obtpcd"] = "0";
                dr2["obtp_obtpnm"] = "請選擇";
                dt2.Rows.Add(dr2);

                dt2.DefaultView.Sort = "obtp_obtpcd ASC";
                ddlBookType.DataTextField = dt2.Columns[1].ToString();
                ddlBookType.DataValueField = dt2.Columns[0].ToString();
                ddlBookType.DataSource = dt2.DefaultView;
                ddlBookType.DataBind();


                DataTable dt3 = new DataTable();
                dt3.Columns.Add("mtp_mtpcd", typeof(string));
                dt3.Columns.Add("mtp_nm", typeof(string));
                DataRow dr3 = dt3.NewRow();
                dr3["mtp_mtpcd"] = "00";
                dr3["mtp_nm"] = "請選擇";
                dt3.Rows.Add(dr3);

                dt3.DefaultView.Sort = "mtp_mtpcd ASC";
                ddlMailType.DataTextField = dt3.Columns[1].ToString();
                ddlMailType.DataValueField = dt3.Columns[0].ToString();
                ddlMailType.DataSource = dt3.DefaultView;
                ddlMailType.DataBind();
                #endregion

                if (CLFGV.Rows.Count > 0)
                {
                    ExportExcel.Enabled = true;
                    SearchIcon.Visible = true;
                    ExportEmail.Enabled = true;
                }
                else
                {
                    SearchIcon.Visible = false;
                    ExportExcel.Enabled = false;
                    ExportEmail.Enabled = false;
                }
            }

        }

        protected void ddlOrderType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrderType1.SelectedValue.ToString() != "99")
            {
                DataTable dt = myCust.SelectJtype(ddlOrderType1.SelectedValue.ToString());
                DataRow dr = dt.NewRow();
                dr["otp_otp2cd"] = "0";
                dr["otp_otp2nm"] = "請選擇";
                dt.Rows.Add(dr);

                dt.DefaultView.Sort = "otp_otp2cd ASC";
                ddlOrderType2.DataTextField = dt.Columns[4].ToString();
                ddlOrderType2.DataValueField = dt.Columns[3].ToString();
                ddlOrderType2.DataSource = dt.DefaultView;
                ddlOrderType2.DataBind();


                DataTable dt2 = myCust.SelectBooktype(ddlOrderType1.SelectedValue.ToString());
                DataRow dr2 = dt2.NewRow();
                dr2["obtp_obtpcd"] = "0";
                dr2["obtp_obtpnm"] = "請選擇";
                dt2.Rows.Add(dr2);

                dt2.DefaultView.Sort = "obtp_obtpcd ASC";
                ddlBookType.DataTextField = dt2.Columns[3].ToString();
                ddlBookType.DataValueField = dt2.Columns[2].ToString();
                ddlBookType.DataSource = dt2.DefaultView;
                ddlBookType.DataBind();
            }
        }

        protected void ddlMosea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMosea.SelectedValue.ToString() != "9")
            {
                DataTable dt = myCust.SelectMailtype(ddlMosea.SelectedValue.ToString());
                DataRow dr = dt.NewRow();
                dr["mtp_mtpcd"] = "00";
                dr["mtp_nm"] = "請選擇";
                dt.Rows.Add(dr);

                dt.DefaultView.Sort = "mtp_mtpcd ASC";
                ddlMailType.DataTextField = dt.Columns[2].ToString();
                ddlMailType.DataValueField = dt.Columns[1].ToString();
                ddlMailType.DataSource = dt.DefaultView;
                ddlMailType.DataBind();
            }
        }

        public DataTable BindGrid(string top300, string WebOrExcel)
        {
            string STRtbxOrderDate1 = "";
            string STRtbxOrderDate2 = "";
            string STRtbxDate1 = "";
            string STRtbxDate2 = "";
            string STRtbxDate = "";
            try
            {
                STRtbxOrderDate1 = tbxOrderDate1.Text.Substring(0, 4) + tbxOrderDate1.Text.Substring(5, 2) + tbxOrderDate1.Text.Substring(8, 2);
            }
            catch (Exception ex)
            {
                STRtbxOrderDate1 = "";
            }
            try
            {
                STRtbxOrderDate2 = tbxOrderDate2.Text.Substring(0, 4) + tbxOrderDate2.Text.Substring(5, 2) + tbxOrderDate2.Text.Substring(8, 2);
            }
            catch (Exception ex)
            {
                STRtbxOrderDate2 = "";
            }
            try
            {
                STRtbxDate1 = tbxDate1.Text.Substring(0, 4) + tbxDate1.Text.Substring(5, 2) + tbxDate1.Text.Substring(8, 2);
            }
            catch (Exception ex)
            {
                STRtbxDate1 = "";
            }
            try
            {
                STRtbxDate2 = tbxDate2.Text.Substring(0, 4) + tbxDate2.Text.Substring(5, 2) + tbxDate2.Text.Substring(8, 2);
            }
            catch (Exception ex)
            {
                STRtbxDate2 = "";
            }

            try
            {
                STRtbxDate = tbxDate.Text.Substring(0, 4) + tbxDate.Text.Substring(5, 2) + tbxDate.Text.Substring(8, 2);
            }
            catch (Exception ex)
            {
                STRtbxDate = "";
            }

            DataTable dt = myCust.SelectChkBtn(ddlCustType.SelectedItem.Value.Trim(), STRtbxOrderDate1,
                STRtbxOrderDate2, STRtbxDate1, STRtbxDate2, ddlOrderType1.SelectedItem.Value.Trim(), ddlOrderType2.SelectedItem.Value.Trim(),
                ddlBookType.SelectedItem.Value.Trim(), ddlMailType.SelectedItem.Value.Trim(), tbxRecName.Text.Trim(), STRtbxDate, top300, WebOrExcel);
            return dt;
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            CLFGV.DataSource = BindGrid(" top 300 ","web");
            CLFGV.DataBind();
            CountNum.Text = "搜尋到" + BindGrid(" ","excel").Rows.Count.ToString() + "筆資料";

            if (BindGrid(" top 300 ","web").Rows.Count > 0)
            {
                ExportExcel.Enabled = true;
                ExportEmail.Enabled = true;
            }
            else
            {
                ExportEmail.Enabled = false;
                ExportExcel.Enabled = false;
            }
        }

        protected void ExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Subscriber/Template/" + "CustListFilter.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            TXlsCellRange myRange = new TXlsCellRange("A4:N4");

            DataTable dt = BindGrid(" ","excel");

            if (dt.Rows.Count > 1)
            {
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    Xls.InsertAndCopyRange(myRange, 5 + i, 1, 1, TFlxInsertMode.NoneDown);
                }
                // Xls.InsertAndCopyRange(myRange, 5 + i, 1, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
            }
            else
            {
                //do nothing
            }
            

            Xls.SetCellValue(2, 3, DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(2, 13, Account.GetAccInfo().srspn_cname.ToString());

            for (int i = 4; i < dt.Rows.Count + 4; i++)
            {
                Xls.SetCellValue(i, 1, i-3);
                Xls.SetCellValue(i, 2, dt.Rows[i - 4]["nostr"].ToString().Trim());
                Xls.SetCellValue(i, 3, dt.Rows[i - 4]["o_date"].ToString().Trim());
                Xls.SetCellValue(i, 4, dt.Rows[i - 4]["cust_custno"].ToString().Trim());
                Xls.SetCellValue(i, 5, dt.Rows[i - 4]["cust_nm"].ToString().Trim());
                Xls.SetCellValue(i, 6, dt.Rows[i - 4]["obtp_obtpnm"].ToString().Trim());
                Xls.SetCellValue(i, 7, dt.Rows[i - 4]["or_nm"].ToString().Trim());
                Xls.SetCellValue(i, 8, dt.Rows[i - 4]["or_inm"].ToString().Trim());
                Xls.SetCellValue(i, 9, dt.Rows[i - 4]["or_zip"].ToString().Trim());
                Xls.SetCellValue(i, 10, dt.Rows[i - 4]["or_addr"].ToString().Trim());
                Xls.SetCellValue(i, 11, dt.Rows[i - 4]["or_tel"].ToString().Trim());
                Xls.SetCellValue(i, 12, dt.Rows[i - 4]["od_sdate"].ToString().Trim() + "--" + dt.Rows[i - 4]["od_edate"].ToString().Trim());
                Xls.SetCellValue(i, 13, dt.Rows[i - 4]["mtp_nm"].ToString().Trim());
                Xls.SetCellValue(i, 14, dt.Rows[i - 4]["ra_mnt"].ToString().Trim());
            }

                //Xls.SetCellValue(, , );
                //Xls.SetCellValue(, , );
                //Xls.SetCellValue(, , );
                //Xls.SetCellValue(, , );
                //Xls.SetCellValue(, , );
                //Xls.SetCellValue(, , );
                //Xls.SetCellValue(, , );
                //Xls.SetCellValue(, , );

            Common.excuteExcel(Xls, "CustListFilter.xls");

        }

        protected void ExportEmail_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Subscriber/Template/" + "CustListFilterEmail.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            TXlsCellRange myRange = new TXlsCellRange("A4:B4");
            //TFlxFormat f = Xls.GetDefaultFormat;
            //f.Borders.SetAllBorders(TFlxBorderStyle.Dash_dot, TExcelColor.Automatic);
            //int fint = Xls.AddFormat(f);
            DataTable dt = BindGrid(" ", "excel");


            for (int i = 4; i < dt.Rows.Count + 4; i++)
            {
                Xls.MergeCells(i, 2, i, 5);
            }

            if (dt.Rows.Count > 1)
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    Xls.InsertAndCopyRange(myRange, 5 + i, 1, 1, TFlxInsertMode.NoneDown);
                //}
                Xls.InsertAndCopyRange(myRange, 5, 1, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                Xls.InsertAndCopyRange(myRange, 5, 2, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                Xls.InsertAndCopyRange(myRange, 5, 3, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                Xls.InsertAndCopyRange(myRange, 5, 4, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
            }
            else
            {
                //do nothing
            }

            Xls.SetCellValue(2, 2, DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(2, 5, Account.GetAccInfo().srspn_cname.ToString());

            for (int i = 4; i < dt.Rows.Count + 4; i++)
            {
                Xls.MergeCells(i, 2, i, 5);
                Xls.SetAutoRowHeight(i, true);
                Xls.SetCellValue(i, 1, i - 3);
                Xls.SetCellValue(i, 2, dt.Rows[i - 4]["cust_email"].ToString().Trim());
            }

            //Xls.SetCellValue(, , );
            //Xls.SetCellValue(, , );
            //Xls.SetCellValue(, , );
            //Xls.SetCellValue(, , );
            //Xls.SetCellValue(, , );
            //Xls.SetCellValue(, , );
            //Xls.SetCellValue(, , );
            //Xls.SetCellValue(, , );

            Common.excuteExcel(Xls, "CustListFilterEmail.xls");
        }
    }
}
