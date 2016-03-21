using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MRLPub.d4.DataTypes;
using MRLPub.d4.Configurations;
using System.IO;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for AdImages.
	/// </summary>
	public class AdrImages : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblImageInfo;
		protected System.Web.UI.WebControls.Panel pnlImages;
		protected System.Web.UI.WebControls.DataList dlImageList;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				LoadImages();
			}
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
			this.ID = "AdrImages";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		#region ���J����
		private void LoadImages()
		{
			DataView dv = GetDataSource();

			if (dv.Count>0)
			{
				dlImageList.DataSource = dv;
				dlImageList.DataBind();

				lblImageInfo.Text = "�{���s�i����";
				dlImageList.Visible = true;
			}
			else
			{
				lblImageInfo.Text = "�ثe�|�L����s�i����";
				dlImageList.Visible = false;
			}
		}
		#endregion

		#region �N�ɮ׸�T�B�z��DataView
		private DataView GetDataSource()
		{
			string path = Server.MapPath("..\\Images");
			string[] imagefiles = Directory.GetFiles(path);
			
			DataTable dt = new DataTable();
			DataColumn dc = new DataColumn("filename");
			dt.Columns.Add(dc);

			for(int i=0; i<imagefiles.Length; i++)
			{
				DataRow dr = dt.NewRow();
				string rawFileName = imagefiles.GetValue(i).ToString();
				dr["filename"] = rawFileName.Substring(rawFileName.LastIndexOf("\\")+1);
				dt.Rows.Add(dr);
			}

			return dt.DefaultView;
		}
		#endregion
	}
}
