using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace mclpub.Layout
{
    public partial class AdrGenXml : System.Web.UI.Page
    {
        AdrGenXml_DB myAdr = new AdrGenXml_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //只給我自己看這個資料:>
                if (Account.GetAccInfo().srspn_empno.ToString().Trim() != "529130")
                {
                    TextBox1.Visible = false;
                }
                pnlAdr.Visible = false;
            }
        }

        protected void btnQueryPublish_Click(object sender, EventArgs e)
        {
            if (tbxAdDate.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "查詢日期不可為空值");
                return;
            }

            DateTime addate;
            try
            {
                addate = DateTime.ParseExact(tbxAdDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "輸入的年月日不合理，請重新輸入");
                return;
            }

            //OK了就可以開始查詢
            DataSet ds = myAdr.GetAdrPublishFileUp(addate.ToString("yyyyMMdd"));
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "sort_adcate DESC, sort_keyword ASC";

            //Response.Write(dv.Count);
            //return;

            if (dv.Count > 0)
            {
                pnlAdr.Visible = true;
                dgdAdr.DataSource = dv;
                dgdAdr.DataBind();
            }
            else
            {
                pnlAdr.Visible = false;
                JavaScript.AlertMessage(this.Page, "該日尚無廣告落版");
            }

            //設定button文字
            btnGenXml.Text = "產生" + tbxAdDate.Text + "的廣告播出檔";

            //隱藏值，為了避免user又跑去textbox輸入日期..but..not gen檔案
            tbxSelDate.Text = tbxAdDate.Text;
        }

        protected void calDates_SelectionChanged1(object sender, EventArgs e)
        {
            tbxAdDate.Text = calDates.SelectedDate.ToString("yyyy/MM/dd");

            //一選定就把落版藏起來
            pnlAdr.Visible = false;
        }

        protected void btnGenXml_Click(object sender, EventArgs e)
        {
            //string path = CommonUtil.config_FileUploadPath + "\\XmlFiles\\";
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}

            string filename = DateTime.ParseExact(tbxSelDate.Text, "yyyy/MM/dd", null).ToString("yyyyMMdd") + ".xml";
            DateTime addate;
            try
            {
                addate = DateTime.ParseExact(tbxSelDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "轉換日期格式失敗，請通知聯絡人");
                return;
            }


            DataSet ds = myAdr.GetAdrXmlData(addate.ToString("yyyyMMdd"));

            //為了保險起見，再設定一次
            ds.DataSetName = "Advertisements";
            ds.Tables[0].TableName = "Ad";

            TextBox1.Text = ds.GetXml();


            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.ContentType = "application/vnd.xml";
            Response.Write(ds.GetXml());
            Response.End();




            //寫出XML
            //string filepath = path + addate.ToString("yyyyMMdd") + ".xml";
            //if (System.IO.File.Exists(filepath))
            //{
            //    JavaScript.AlertMessage(this.Page, "檔案已經存在，請到xml檔案維護(刪除)後，再產生一次");
            //    return;
            //}

            //try
            //{
            //    ds.WriteXml(filepath);
            //    JavaScript.AlertMessage(this.Page, addate.ToString("yyyyMMdd") + ".xml 產生成功");
            //}
            //catch
            //{
            //    JavaScript.AlertMessage(this.Page, "產生xml檔案時發生錯誤，請通知聯絡人");
            //    return;
            //}
            pnlAdr.Visible = false;

            myAdr.UpdateXmlFileLog(addate.ToString("yyyyMMdd"));
        }
    }
}