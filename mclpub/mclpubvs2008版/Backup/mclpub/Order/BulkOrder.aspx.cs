using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;

namespace mclpub.Order
{
    public partial class BulkOrder : System.Web.UI.Page
    {
        BulkOrder_DB myBulk = new BulkOrder_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                DataSet ds3 = myBulk.Selectc1_obtp();
                DataView dv3 = ds3.Tables["c1_obtp"].DefaultView;
                dv3.RowFilter = "obtp_otp1cd='02'";
                ddlBook.DataSource = dv3;
                ddlBook.DataTextField = "obtp_obtpnm";
                ddlBook.DataValueField = "obtp_obtpcd";
                ddlBook.DataBind();
                DateTime date1;
                date1 = System.DateTime.Today;
                date1 = date1.AddYears(1);
                tbxContinueDate.Text = date1.ToString("yyyy/MM/dd");
                //				myDataBind();
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            myDataBind();
        }


        private void myDataBind()
        {
            DateTime date1, date2;
            date1 = System.DateTime.Today;
            date2 = date1.AddYears(-1);
            string StartDate, EndDate;
            DataSet ds1 = myBulk.Selectc1_order();
            DataView dv1 = ds1.Tables["c1_order"].DefaultView;
            string strbuf = "o_otp1cd='02' and od_btpcd='" + ddlBook.SelectedItem.Value + "'";
            if (tbxStartdate.Text == "")
                StartDate = date2.ToString("yyyyMMdd");
            else
                StartDate = tbxStartdate.Text.Substring(0, 4) + tbxStartdate.Text.Substring(5, 2) + tbxStartdate.Text.Substring(8, 2);
            if (tbxEndDate.Text == "")
                EndDate = date1.ToString("yyyyMMdd");
            else
                EndDate = tbxEndDate.Text.Substring(0, 4) + tbxEndDate.Text.Substring(5, 2) + tbxEndDate.Text.Substring(8, 2);
            strbuf += " and ((od_sdate<'" + StartDate + "' and od_edate>'" + StartDate + "') or (od_sdate<'" + EndDate + "' and od_edate>'" + EndDate + "')" +
                " or (od_sdate<'" + StartDate + "' and od_edate>'" + EndDate + "'))";
            if (tbxCompanyname.Text != "")
                strbuf += " and mfr_inm Like '%" + tbxCompanyname.Text + "%'";
            dv1.RowFilter = strbuf;
            //			for(int i=0; i<dv1.Count; i++)
            //				dv1.Table.Rows[i]["o_fgpreinv"]="0";
            DataList1.DataSource = dv1;
            DataList1.DataBind();
            if (dv1.Count == 0)
            {
                btnOK.Visible = false;
            }
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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string strbuf = "ShowOrder.aspx?id=" + ((Label)e.Item.FindControl("lblNo")).Text + "&type1=02&seq=" + ((Label)e.Item.FindControl("lblSeq")).Text;
                HyperLink System_SN = (HyperLink)e.Item.FindControl("HyperLink1");
                System_SN.NavigateUrl = "javascript:doDetail('800','600','" + strbuf + "');";
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                //Response.Write(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked);
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked == true)
                {
                    XmlDocument XmlDoc1 = new System.Xml.XmlDocument();
                    XmlNode ItemOrder1;
                    XmlNode ItemDetail1;
                    XmlDoc1.LoadXml(((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXml")).Value);
                    ItemOrder1 = XmlDoc1.SelectSingleNode("/root/訂單");
                    ItemDetail1 = XmlDoc1.SelectSingleNode("/root/訂單明細");
                    for (int j = 0; j < ItemDetail1.ChildNodes.Count; j++)
                    {
                        if (ItemDetail1.ChildNodes.Item(j).SelectSingleNode("書籍類別").InnerText.Substring(0, 2) == ddlBook.SelectedItem.Value)
                        {
                            ItemDetail1.ChildNodes.Item(j).SelectSingleNode("訂閱訖時").InnerXml = tbxContinueDate.Text;
                            myBulk.UpdateFirst(tbxContinueDate.Text.Substring(0, 4) + tbxContinueDate.Text.Substring(5, 2) + tbxContinueDate.Text.Substring(8, 2), ItemOrder1["訂戶編號"].FirstChild.OuterXml,
                                ItemDetail1.ChildNodes.Item(j).SelectSingleNode("項次").InnerXml, "02", ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10, 3),
                                "C1", ddlBook.SelectedItem.Value);
                        }
                    }
                    //					text1.Value=((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXml")).Value;
                    //					text1.Value=XmlDoc1.OuterXml;
                    myBulk.UpdateSec(XmlDoc1.OuterXml, System.DateTime.Today.ToString("yyyyMMdd"), ItemOrder1["訂戶編號"].FirstChild.OuterXml, "02",
                        ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10, 3), "C1", ItemOrder1["訂戶編號"].FirstChild.OuterXml, "02", ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10, 3), "C1");

                }
            }

            JavaScript.AlertMessageRedirect(this.Page, "所選贈閱訂戶之續訂動作已完成", "BulkOrder.aspx");
        }
    }
}
