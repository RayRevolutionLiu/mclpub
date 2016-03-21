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
    public partial class AdrXmlManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_dgdXml();
            }
        }

        #region 連結檔案資料
        private void Bind_dgdXml()
        {
            string path = CommonUtil.config_FileUploadPath + "\\XmlFiles\\";
            string[] xmlfiles = Directory.GetFiles(path);

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("filename");
            dt.Columns.Add(dc);

            for (int i = 0; i < xmlfiles.Length; i++)
            {
                DataRow dr = dt.NewRow();
                string rawFileName = xmlfiles.GetValue(i).ToString();
                string strbuf = rawFileName.Substring(rawFileName.LastIndexOf("\\") + 1);
                DateTime fileday = DateTime.Parse(strbuf.Substring(0, 4) + "/" + strbuf.Substring(4, 2) + "/" + strbuf.Substring(6, 2));
                if (fileday >= DateTime.Today)
                {
                    dr["filename"] = strbuf;
                    //dr["filename"] = rawFileName.Substring(rawFileName.LastIndexOf("\\")+1);
                    dt.Rows.Add(dr);
                }
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "filename ASC";

            dgdXml.DataSource = dv;
            dgdXml.DataBind();

            if (dv.Count > 0)
            {
                lblxml.Text = "現有 " + dv.Count.ToString() + " 筆可維護的xml檔案";
            }
            else
            {
                lblxml.Text = "目前無可維護的xml檔案";
            }

        }
        #endregion

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            string path = CommonUtil.config_FileUploadPath + "\\XmlFiles\\";
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string filename = thisRow.Cells[1].Text.Trim();
            DateTime target;
            try
            {
                target = DateTime.ParseExact(filename.Substring(0, 8), "yyyyMMdd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "檔案名稱錯誤 日期格式轉換錯誤");
                return;
            }

            string filepath = path + target.ToString("yyyyMMdd") + ".xml";

            if (!File.Exists(filepath))
            {
                JavaScript.AlertMessage(this.Page, "該檔案不存在");
                return;
            }
            else
            {
                try
                {
                    File.Delete(filepath);
                    //Advertisements adr = new Advertisements();
                    //adr.SubstractXmlFileLog(target.ToString("yyyyMMdd"));
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "檔案刪除失敗，請通知聯絡人");
                    return;
                }
            }

            Bind_dgdXml();
        }
    }
}