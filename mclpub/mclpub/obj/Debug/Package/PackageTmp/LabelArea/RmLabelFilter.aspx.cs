using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.LabelArea
{
    public partial class RmLabelFilter : System.Web.UI.Page
    {
        RmLabelFilter_DB myRm = new RmLabelFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataSet ds1 = myRm.SelectC1_rmail();
            DataView dv1 = ds1.Tables["c1_rmail"].DefaultView;
            dv1.RowFilter = "or_fgmosea='" + ddlMosea.SelectedItem.Value.Trim() + "' and rm_fgsent<>'C'";
            DataList1.DataSource = dv1;
            DataList1.DataBind();
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                if (DataList1.Items.Count == 0)
                {
                    ((Panel)e.Item.FindControl("Panel_Noting")).Visible = true;
                }
            }
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //}
        }

        protected void ddlMosea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnLabelPrint1_Click(object sender, EventArgs e)
        {
            bool chk = false;
            string strbuf;
            myRm.DelTmp_table2();
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                //Response.Write(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked);
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked == true)
                {
                    strbuf = ((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
                    myRm.Update2(strbuf.Substring(0, 2), strbuf.Substring(2, 6), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(13, 2), ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim(),
                        System.DateTime.Today.ToString("yyyyMMdd"), "Y", strbuf.Substring(2, 6), strbuf.Substring(13, 2), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(0, 2),
                        ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim());
                    myRm.Insert1(strbuf.Substring(0, 2), strbuf.Substring(2, 6), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(13, 2), ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim());
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("請勾選需列印之訂單"));
                return;
            }
            else
            {
                btnPrintOK.Enabled = true;

                string strurl;
                strurl = "remail_label.aspx?mosea=" + ddlMosea.SelectedItem.Value.Trim();
                this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strurl + "\");</script>"); 
            }

        }

        protected void btnPrintOK_Click(object sender, EventArgs e)
        {
            bool chk = false;
            string strbuf;
            //將所選之補書資料的補書日期(lst_date)填入今天的日期,並將寄出註記(lst_fgsent)設為'C'
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
                {
                    strbuf = ((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
                    myRm.Update2(strbuf.Substring(0, 2), strbuf.Substring(2, 6), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(13, 2), ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim(),
                    System.DateTime.Today.ToString("yyyyMMdd"), "C", strbuf.Substring(2, 6), strbuf.Substring(13, 2), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(0, 2),
                    ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim());
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("請勾選需補書之資料"));
                return;
            }
            BindData();
        }
    }
}