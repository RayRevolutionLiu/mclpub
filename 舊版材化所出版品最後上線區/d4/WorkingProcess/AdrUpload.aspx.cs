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

		#region �W���ɮ�
		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			//�B�z�ɮ׬O�_post��server
			if (Request.Files == null)
			{
				jsAlertMsg("EMPTYCOLLECTION", "�W���ɮ׶��X���ŭȡA�нT�w�w��w�W���ɮ�");
				return;
			}

			//�B�z�ɮ׬O�_post��server
			if (Request.Files.Count <= 0)
			{
				jsAlertMsg("EMPTYCOLLECTION2", "�W���ɮ׭ӼƬ��s�A�нT�w�w��w�W���ɮ�");
				return;				
			}

			//�B�z�ɮ׬O�_������
			if (fileUpload.PostedFile.ContentLength <= 0)
			{
				jsAlertMsg("FILESIZE0", "�W���ɮפj�p���s�A�нT�w�w��w�W���ɮסA�B�ɮ׬O�_����");
				return;			
			}

			//�B�z�ɮצW�٬O�_�s�b
			if (fileUpload.PostedFile.FileName.Trim() == "")
			{
				jsAlertMsg("FILENAMEEMPTY", "�W���ɮ��ɦW���X�W�h�A���ɮצW�ٿ�");
				return;	
			}

			string rawFilename = fileUpload.PostedFile.FileName.Trim();
			string filename = rawFilename.Substring(rawFilename.LastIndexOf("\\") + 1);
			string ext = filename.Substring(filename.LastIndexOf(".") + 1);

			//�u��JPG�B�BJPEG�BBMP�BGIF�����ϧΤW��
			if (ext.ToUpper() != "JPG" && ext.ToUpper() != "JPEG" && ext.ToUpper() != "BMP" && ext.ToUpper() != "GIF")
			{
				jsAlertMsg("INVALIDIMAGETYPE", "�ثe�u���\JPG�B�BJPEG�BBMP�BGIF�����ϧΤW�ǡA�Э��s�ഫ�ɮ׮榡");
			}

			string path = Server.MapPath("..\\Images") + "\\";

			//�B�z�ɮ׭���
			if (File.Exists(path + filename))
			{
				jsAlertMsg("FILENAMEDUP", "�ۦP�W���ɮפw�g�s�b�A�Э��s�R�W��A�W��");
				return;	
			}

			//�H�U���S���D�F�~�i�H�s��
			try
			{
				fileUpload.PostedFile.SaveAs(path + filename);
				jsAlertMsg("SAVEOK", "�ɮפW�Ǧ��\");
			}
			catch(Exception ex)
			{
				//jsAlertMsg("SAVEFAILED", "�ɮ��x�s���ѡA�гq���p���H");
				//Response.Write("i am " + User.Identity.Name);
				Response.Write(ex.Message);
			}
		}
		#endregion
	}
}
