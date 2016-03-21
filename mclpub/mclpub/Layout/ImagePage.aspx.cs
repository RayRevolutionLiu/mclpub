using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mclpub.Layout
{
    public partial class ImagePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在這裡放置使用者程式碼以初始化網頁
            try
            {
                Response.Clear();
                //			System.Web.HttpUtility.UrlEncode();
                //			System.Web.HttpUtility.UrlDecode();
                string filename = System.Web.HttpUtility.UrlDecode(Request.QueryString["filename"]);

                //string filepath=ConfigurationSettings.AppSettings["UploadPath"];

                Response.ContentType = "application/octec-stream";
                //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachement; filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8));
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));

                //Response.WriteFile(filepath+filename);
                //Response.Flush();

                //Response.WriteFile(filepath+filename);
                Response.WriteFile(filename);


            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
            finally
            {
                Response.Flush();
                Response.End();
            }
        }
    }
}