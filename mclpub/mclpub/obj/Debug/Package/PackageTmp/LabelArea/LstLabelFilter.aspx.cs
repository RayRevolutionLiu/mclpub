using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.LabelArea
{
    public partial class LstLabelFilter : System.Web.UI.Page
    {
        LstLabelFilter_DB myLst = new LstLabelFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                //tbxlst_sdate.Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
                //tbxlst_edate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            }
        }

        private void BindGrid()
        {
            DataSet ds1 = myLst.Selectc1_lost();
            DataView dv1 = ds1.Tables["c1_lost"].DefaultView;
            if (ddlMosea.SelectedItem.Value.Trim() != "")
            {
                dv1.RowFilter = "or_fgmosea='" + ddlMosea.SelectedItem.Value.Trim() + "' and lst_fgsent<>'C'";
            }
            //if (tbxlst_sdate.Text.Trim() != "" && tbxlst_edate.Text.Trim() != "")
            //{
            //    dv1.RowFilter = "";
            //}
            DataList1.DataSource = dv1;
            DataList1.DataBind();
        }

        protected void btnLabelPrint1_Click(object sender, EventArgs e)
        {
            bool chk = false;
            string strbuf;
            //將tmp_label2資料清空
            myLst.DelTmp_table2();
            //將所選之缺書資料填入tmp_label2
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
                {
                    //將所選之缺書資料的缺書日期(lst_date)填入今天的日期
                    strbuf = ((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
                    myLst.Update2(strbuf.Substring(0, 2), strbuf.Substring(2, 6), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(13, 2)
                        , ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim(), System.DateTime.Today.ToString("yyyyMMdd"), "Y", strbuf.Substring(2, 6),
                        strbuf.Substring(13, 2), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(0, 2), strbuf.Substring(10, 3));

                    //將所選之缺書資料加入tmp_label2
                    myLst.Insert1(strbuf.Substring(0, 2), strbuf.Substring(2, 6), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(13, 2), ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim());
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
                strbuf = "lost_label.aspx?mosea=" + ddlMosea.SelectedItem.Value.Trim();
                this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>"); 
            }


        }

        protected void btnPrintOK_Click(object sender, EventArgs e)
        {
            bool chk = false;
            string strbuf;
            //將所選之缺書資料的缺書日期(lst_date)填入今天的日期,並將寄出註記(lst_fgsent)設為'C'
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
                {
                    strbuf = ((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
                    myLst.Update2(strbuf.Substring(0, 2), strbuf.Substring(2, 6), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(13, 2)
                        , ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim(), System.DateTime.Today.ToString("yyyyMMdd"), "C", strbuf.Substring(2, 6),
                        strbuf.Substring(13, 2), strbuf.Substring(8, 2), strbuf.Substring(10, 3), strbuf.Substring(0, 2), strbuf.Substring(10, 3));
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("請勾選缺書之資料"));
                return;
            }

            DataBind();
        }

        protected void ddlMosea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
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