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
    public partial class CheckImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Request.Files[0].SaveAs(
                if (Request.Form["filename"] != null || Request.Form["filename"] != "")
                {
                    string Url = Request.Form["filename"];
                    string filename = Url.Substring(Url.LastIndexOf("\\") + 1);
                    string path = Server.MapPath("~/UserImages");//20120222修改 因為nas不能用網路磁碟機 所以只能放在Web目錄底下
                    //string path = CommonUtil.config_FileUploadPath;//本機上直接使用路徑
                    //Dim appPath As String = Request.PhysicalApplicationPath
                    //appPath是網站 "根"目錄「轉換成」Server端硬碟路徑。
                    //處理檔案重複
                    if (File.Exists(path +"\\"+ filename))
                    {
                        Response.Write("No!");
                    }
                    else
                    {
                        string FileType = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
                        //Response.Write(FileType);
                        //return;
                        if (FileType == "jpg" || FileType == "jpeg" || FileType == "gif" || FileType == "bmp" || FileType == "png")
                        {
                            Response.Write("Ok!");
                        }
                        else
                        {
                            Response.Write("Image!");
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                //Response.Write(ex.Message);
                Response.Write("Error!");
            }
        }
    }
}