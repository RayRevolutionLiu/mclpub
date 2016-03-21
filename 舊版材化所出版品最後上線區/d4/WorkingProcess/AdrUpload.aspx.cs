using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MRLPub.d4.DataTypes;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for AdrUpload.
	/// </summary>
	public class AdrUpload : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputFile fileUpload;
		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Web.UI.WebControls.Label lblFile;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 上傳檔案
		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			//處理檔案是否post到server
			if (Request.Files == null)
			{
				jsAlertMsg("EMPTYCOLLECTION", "上傳檔案集合為空值，請確定已選定上傳檔案");
				return;
			}

			//處理檔案是否post到server
			if (Request.Files.Count <= 0)
			{
				jsAlertMsg("EMPTYCOLLECTION2", "上傳檔案個數為零，請確定已選定上傳檔案");
				return;				
			}

			//處理檔案是否為空檔
			if (fileUpload.PostedFile.ContentLength <= 0)
			{
				jsAlertMsg("FILESIZE0", "上傳檔案大小為零，請確定已選定上傳檔案，且檔案是否完整");
				return;			
			}

			//處理檔案名稱是否存在
			if (fileUpload.PostedFile.FileName.Trim() == "")
			{
				jsAlertMsg("FILENAMEEMPTY", "上傳檔案檔名不合規則，或檔案名稱遺失");
				return;	
			}

			string rawFilename = fileUpload.PostedFile.FileName.Trim();
			string filename = rawFilename.Substring(rawFilename.LastIndexOf("\\") + 1);
			string ext = filename.Substring(filename.LastIndexOf(".") + 1);

			//只給JPG、、JPEG、BMP、GIF類的圖形上傳
			if (ext.ToUpper() != "JPG" && ext.ToUpper() != "JPEG" && ext.ToUpper() != "BMP" && ext.ToUpper() != "GIF")
			{
				jsAlertMsg("INVALIDIMAGETYPE", "目前只允許JPG、、JPEG、BMP、GIF類的圖形上傳，請重新轉換檔案格式");
			}

			string path = Server.MapPath("..\\Images") + "\\";

			//處理檔案重複
			if (File.Exists(path + filename))
			{
				jsAlertMsg("FILENAMEDUP", "相同名稱檔案已經存在，請重新命名後再上傳");
				return;	
			}

			//以下都沒問題了才可以存檔
			try
			{
				fileUpload.PostedFile.SaveAs(path + filename);
				jsAlertMsg("SAVEOK", "檔案上傳成功");
			}
			catch(Exception ex)
			{
				//jsAlertMsg("SAVEFAILED", "檔案儲存失敗，請通知聯絡人");
				//Response.Write("i am " + User.Identity.Name);
				Response.Write(ex.Message);
			}
		}
		#endregion
	}
}
