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
                }
                else
                {
                    SearchIcon.Visible = false;
                    ExportExcel.Enabled = false;
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

            DataTable dt = myCust.SelectChkBtn(ddlCustType.SelectedItem.Value.Trim(), tbxOrderDate1.Text,
                tbxOrderDate2.Text, tbxDate1.Text, tbxDate2.Text, ddlOrderType1.SelectedItem.Value.Trim(), ddlOrderType2.SelectedItem.Value.Trim(),
                ddlBookType.SelectedItem.Value.Trim(), ddlMailType.SelectedItem.Value.Trim(), tbxRecName.Text.Trim(), tbxDate.Text, top300, WebOrExcel);
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
            }
            else
            {
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
            DataTable dt = BindGrid(" ","excel");

            Xls.SetCellValue(2, 3, DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(2, 13, Account.GetAccInfo().srspn_cname.ToString());

            for (int i = 4; i < dt.Rows.Count + 4; i++)
            {
                Xls.SetCellValue(i, 1, i-3);
                Xls.SetCellValue(i, 2, dt.Rows[i - 4]["nostr"].ToString());
                Xls.SetCellValue(i, 3, dt.Rows[i - 4]["o_date"].ToString());
                Xls.SetCellValue(i, 4, dt.Rows[i - 4]["cust_custno"].ToString());
                Xls.SetCellValue(i, 5, dt.Rows[i - 4]["cust_nm"].ToString());
                Xls.SetCellValue(i, 6, dt.Rows[i - 4]["obtp_obtpnm"].ToString());
                Xls.SetCellValue(i, 7, dt.Rows[i - 4]["or_nm"].ToString());
                Xls.SetCellValue(i, 8, dt.Rows[i - 4]["or_inm"].ToString());
                Xls.SetCellValue(i, 9, dt.Rows[i - 4]["or_zip"].ToString());
                Xls.SetCellValue(i, 10, dt.Rows[i - 4]["or_addr"].ToString());
                Xls.SetCellValue(i, 11, dt.Rows[i - 4]["or_tel"].ToString());
                Xls.SetCellValue(i, 12, dt.Rows[i - 4]["datestr"].ToString());
                Xls.SetCellValue(i, 13, dt.Rows[i - 4]["mtp_nm"].ToString());
                Xls.SetCellValue(i, 14, dt.Rows[i - 4]["ra_mnt"].ToString());
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
    }
}
