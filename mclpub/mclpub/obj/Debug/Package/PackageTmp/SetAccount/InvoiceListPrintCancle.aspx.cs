using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Text;

using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.SetAccount
{
    public partial class InvoiceListPrintCancle : System.Web.UI.Page
    {

        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        string listDate; //轉檔年月
        string listSeq;  //序號

        InvoiceListPrintCancle_DB myPub = new InvoiceListPrintCancle_DB();
        SetSAPManage_DB myPub2 = new SetSAPManage_DB();
        security se = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "PsGV";

            //上個月
            DateTime dt = DateTime.Now;
            string nowym = string.Format("{0:yyyyMM}", dt);

            //無任何按鈕動作
            if (!IsPostBack)
            {
                transform_time.Text = nowym;

                //系統代號下拉選單
                DataTable dtSyscd = myPub2.syscdDrpdownList();

                /*
                DataRow dr = dt.NewRow();
                dr["sys_syscd"] = "00";
                dr["sys_nm"] = "請選擇";
                dt.Rows.Add(dr);
                 */

                //將整個陣列排序
                dtSyscd.DefaultView.Sort = "sys_syscd ASC";

                sysocDrpdown.DataTextField = dtSyscd.Columns[1].ToString();
                sysocDrpdown.DataValueField = dtSyscd.Columns[0].ToString();
                sysocDrpdown.DataSource = dtSyscd.DefaultView;
                sysocDrpdown.DataBind();

                UCPager1.Visible = false;
 
                if (PsGV.Rows.Count == 0)
                {
                    SearchIcon.Visible = false;

                    select_item.Visible = false;

                }
                else
                {
                    SearchIcon.Visible = true;

                    select_item.Visible = true;

                }
            }

           

        }

        protected void Detail (object sender, EventArgs e){

            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string syscd = se.encryptquerystring(thisRow.Cells[1].Text.Trim());
            string date  = se.encryptquerystring(thisRow.Cells[2].Text.Trim());
            string seq   = se.encryptquerystring(thisRow.Cells[3].Text.Trim());
            Response.Redirect(string.Format("detail.aspx?syscd={0}&date={1}&seq={2}",syscd,date,seq));
        
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {

            SearchIcon.Visible = true;
            UCPager1.Visible = true;
            BindGrid();

        }

        public void BindGrid()
        {
            

            DataTable dt = myPub.SelectC1cust(sysocDrpdown.SelectedItem.Value.Trim(), transform_time.Text.Trim(), batch.Text.Trim());

            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();

            if (dt.Rows.Count >= 1)
            {
                select_item.Visible = true;
            }
            else {
                select_item.Visible = false;
            }

           
        }

        protected void PsGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[7].Text == "0")
                {
                    e.Row.Cells[7].Text = "否";
                }
                else {
                    e.Row.Cells[7].Text = "是";
                }

                if (e.Row.Cells[8].Text == "0")
                {
                    e.Row.Cells[8].Text = "否";
                }
                else
                {
                    e.Row.Cells[8].Text = "是";
                }

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                UCPager1.Visible = true;
            }
        }

        /* 按鈕動作 */

      

        //手動取回發票
        protected void Btn5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = new SqlConnection(Conn);
                oCmd.CommandText = @"dbo.[sp_from_sap_001]";
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter oda = new SqlDataAdapter(oCmd);
                oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                oCmd.Connection.Close();
            }
            catch(Exception ex)
            {
                JavaScript.AlertMessage(this.Page, ex.Message.ToString());
                return;
            }

           
        }

    }
}