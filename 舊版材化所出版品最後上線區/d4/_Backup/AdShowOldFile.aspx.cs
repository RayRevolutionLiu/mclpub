using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for AdShowOldFile.
	/// </summary>
	public class AdShowOldFile : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblCaption;
	
		public AdShowOldFile()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlDaAdr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlDaAdr
			// 
			this.sqlDaAdr.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_adr.adr_syscd, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_imgurl, dbo.c4_adr.adr_drafttp, dbo.c4_adr.adr_navurl, dbo.c4_adr.adr_urltp, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrno FROM dbo.c4_adr INNER JOIN dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			string ContNo = "";
			
			if (Request.QueryString["ContNo"] != null && Request.QueryString["ContNo"].Trim()!="")
			{
				ContNo = Request.QueryString["ContNo"].Trim();
				Bind_dgdAdr(ContNo);
			}
			else
			{
				return;
			}
		}

		private void Bind_dgdAdr(string ContNo)
		{
			DataSet ds = new DataSet();
			this.sqlDaAdr.Fill(ds, "ADR");
			DataView dv = ds.Tables["ADR"].DefaultView;
			dv.RowFilter = "adr_contno='"+ContNo+"'";

			if (dv.Count>0)
			{
				this.dgdAdr.DataSource = dv;
				this.dgdAdr.DataBind();
				this.lblCaption.Text = "合約編號"+ContNo+"的相關資料";
			}
			else
			{
				this.dgdAdr.Visible = false;
				this.lblCaption.Text = "找不到該編號合約的相關資料";
			}
		}
	}
}
