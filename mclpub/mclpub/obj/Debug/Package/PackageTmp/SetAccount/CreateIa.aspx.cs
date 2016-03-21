using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace mclpub.SetAccount
{
    public partial class CreateIa : System.Web.UI.Page
    {
        CreateIa_DB myCreate = new CreateIa_DB();
        XmlDocument XmlDoc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataList_DataBind();
            }
        }

        private void DataList_DataBind()
        {
            DataSet ds1 = myCreate.Selectc1_order();
            DataView dv1 = ds1.Tables[0].DefaultView;
            dv1.RowFilter = "o_iano='' and o_status='1' and o_special='' and (o_otp1cd='01' or o_otp1cd='09')";
            //if (dv1.Count <= 0)
            //{
            //    JavaScript.AlertMessage(this.Page, "沒有未開發票之訂單");
            //    return;
            //}
            DataList1.DataSource = dv1;
            DataList1.DataBind();
        }
        private bool InsertIAData()
        {
            XmlNode ItemMain = XmlDoc.SelectSingleNode("/root");
            XmlNode ItemOrder = XmlDoc.SelectSingleNode("/root/訂單");
            XmlNode ItemDetail = XmlDoc.SelectSingleNode("/root/訂單明細");
            DataSet ds2 = myCreate.Selectc1_obtp();
            DataView dv2 = ds2.Tables[0].DefaultView;
            //Get Max Iano
            DataSet ds5 = myCreate.Selectia();
            DataView dv5 = ds5.Tables[0].DefaultView;
            string iano = "";
            string fy = System.DateTime.Today.Year.ToString();
            if (dv5.Count > 0)
            {
                iano = dv5[0].Row["max_iano"].ToString();           
                if (iano.Substring(0, 2) == fy.Substring(2, 2))
                    iano = Convert.ToString(Int32.Parse(iano) + 1);
                else
                    iano = fy.Substring(2, 2) + "000001";
                //			Response.Write("iano="+iano);
            }
            else
            {
                iano = fy.Substring(2, 2) + "000001";
            }


            int j1 = iano.Length;
            for (int j = 0; j < 8 - j1; j++)
                iano = "0" + iano;
            //-------新增發票開立單檔--------//
            
            int amt = 0;
            for (int i = 0; i < ItemDetail.ChildNodes.Count; i++)
            {
                amt = amt + Int32.Parse(ItemDetail.ChildNodes.Item(i).SelectSingleNode("金額").InnerText);
            }
            int amt_iv = (int)Math.Round((float)amt / 1.05F);

            string STRia_fgitri = "";
            if (ItemOrder["付款方式"].FirstChild.OuterXml == "06" || ItemOrder["付款方式"].FirstChild.OuterXml == "07")
                STRia_fgitri = ItemOrder["付款方式"].FirstChild.OuterXml;
            else
                STRia_fgitri = "";

            string STRia_rjbti = "";
            if (ItemOrder["發票收件人職稱"].FirstChild != null)
                STRia_rjbti = ItemOrder["發票收件人職稱"].FirstChild.OuterXml;
            else
                STRia_rjbti = "";

            string STRia_rtel = "";
            if (ItemOrder["發票收件人電話"].FirstChild != null)
                STRia_rtel = ItemOrder["發票收件人電話"].FirstChild.OuterXml;
            else
                STRia_rtel = "";

            bool resultflag;
            try
            {

                myCreate.INSERTia("C1", "", "", "", iano, "C1" + iano, ItemOrder["統一編號"].FirstChild.OuterXml, "", "", amt.ToString(), amt_iv, 0, "", STRia_fgitri,
                    ItemOrder["發票收件人姓名"].FirstChild.OuterXml, ItemOrder["發票收件人地址"].FirstChild.OuterXml, ItemOrder["發票收件人郵遞區號"].FirstChild.OuterXml,
                    STRia_rjbti, STRia_rtel, "0", ItemOrder["發票類別"].FirstChild.OuterXml, ItemOrder["發票課稅別"].FirstChild.OuterXml, "", "", "", ItemOrder["訂單流水號"].FirstChild.OuterXml);
                resultflag = true;
            }
            catch(Exception ex)
            {
                resultflag = false;
                throw new Exception(ex.Message);
            }


            if (resultflag)
            {
                //-------新增發票開立明細檔--------//
                int item;
                string str2;
                for (int i = 0; i < ItemDetail.ChildNodes.Count; i++)
                {
                    str2 = Convert.ToString(i + 1);
                    item = 3 - str2.Length;
                    for (int k = 0; k < item; k++)
                        str2 = "0" + str2;
                    //				dv1 = ds1.Tables["c1_obtp"].DefaultView;
                    dv2.RowFilter = "obtp_otp1cd='" + ItemOrder["訂購類別一"].FirstChild.OuterXml + "' and obtp_obtpcd='"
                        + ItemDetail.ChildNodes.Item(i).SelectSingleNode("書籍類別").InnerText + "'";

                    string STRiad_desc = dv2[0].Row["obtp_obtpnm"].ToString();
                    if ((ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱起時").InnerText != "") && (ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerText != ""))
                    {
                        if ((ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱起時").InnerText.Length >= 7) && (ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerText.Length >= 7))
                            STRiad_desc = STRiad_desc + ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱起時").InnerText.Substring(0, 7)
                                + "~" + ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerText.Substring(0, 7);
                    }

                    myCreate.INSERTiad("C1", iano, str2, ItemOrder["訂戶編號"].FirstChild.OuterXml, ItemOrder["訂購類別一"].FirstChild.OuterXml,
                        ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10, 3), ItemDetail.ChildNodes.Item(i).SelectSingleNode("項次").InnerText,
                        ItemDetail.ChildNodes.Item(i).SelectSingleNode("計劃代號").InnerText, ItemDetail.ChildNodes.Item(i).SelectSingleNode("成本中心").InnerText,
                        STRiad_desc, Convert.ToInt32(ItemDetail.ChildNodes.Item(i).SelectSingleNode("總數量").InnerText),
                        Convert.ToInt32(ItemDetail.ChildNodes.Item(i).SelectSingleNode("金額").InnerText));
                }

                myCreate.UPDATEc1_order(iano, "3", ItemOrder["系統代碼"].FirstChild.OuterXml, ItemOrder["訂戶編號"].FirstChild.OuterXml,
                    ItemOrder["訂購類別一"].FirstChild.OuterXml, ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10, 3));
            }
            return resultflag;
        }

        protected void btnCreateIa_Click(object sender, EventArgs e)
        {
            string nostr;
            XmlDoc = new System.Xml.XmlDocument();
            int j = 0;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked == true)
                {
                    nostr = ((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
                    XmlDoc.LoadXml(((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXML")).Value);
                    InsertIAData();
                    j++;
                    //					ItemMain=XmlDoc.SelectSingleNode("/root");
                    //					textarea1.Value=ItemMain.OuterXml;
                    //					textarea1.Value=((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXML")).Value;
                }
            }
            if (j <= 0)
            {
                JavaScript.AlertMessage(this.Page, "您尚未選擇任何訂單");
                return;
            }
            else
            {
                DataList_DataBind();
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
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //}
        }
    }
}