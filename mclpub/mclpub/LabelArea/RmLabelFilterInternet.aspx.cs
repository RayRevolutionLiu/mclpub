using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.LabelArea
{
    public partial class RmLabelFilterInternet : System.Web.UI.Page
    {
        RmLabelFilterInternet_DB myRm = new RmLabelFilterInternet_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataSet ds1 = myRm.GetContRemailOrMfrCustWithFilter("");
            DataView dv1 = ds1.Tables[0].DefaultView;
            dv1.RowFilter = "or_fgmosea='" + ddlMosea.SelectedItem.Value.Trim() + "' and rm_fgsent<>'C'";
            DataList1.DataSource = dv1;
            DataList1.DataBind();
        }

        protected void btnLabelPrint1_Click(object sender, EventArgs e)
        {
            bool chk = false;
            string strbuf, contno, oritem, seq;
            //清除列印標籤註記
            myRm.ClearRemailFgPrint();
            //將所選之缺書資料的補書日期(rm_date)填入今天的日期, 並將列印標籤註記設為'v'
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
                {
                    contno = ((Label)DataList1.Items[i].FindControl("lblContno")).Text.Trim();
                    oritem = ((Label)DataList1.Items[i].FindControl("lblOritem")).Text.Trim();
                    seq = ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
                    myRm.UpdateRemailDate(contno, oritem, seq, "v");
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("請勾選補書之資料"));
                return;
            }
            else
            {
                btnPrintOK.Enabled = true;
                strbuf = "Remail_labelInternet.aspx?mosea=" + ddlMosea.SelectedItem.Value.Trim();
                this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>");
            }
        }

        protected void btnPrintOK_Click(object sender, EventArgs e)
        {
            bool chk = false;
            string strbuf, contno, oritem, seq;
            //將所選之補書資料的補書日期(lst_date)填入今天的日期,並將寄出註記(lst_fgsent)設為'C'及將列印標籤註記設為''
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
                {
                    contno = ((Label)DataList1.Items[i].FindControl("lblContno")).Text.Trim();
                    oritem = ((Label)DataList1.Items[i].FindControl("lblOritem")).Text.Trim();
                    seq = ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
                    myRm.UpdateRemailPrintOK(contno, oritem, seq, "C", "");
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("請勾選補書之資料"));
                return;
            }
            BindData();
        }

        protected void ddlMosea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
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
        }
    }
}