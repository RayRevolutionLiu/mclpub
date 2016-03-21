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

namespace MRLPub.d4.mrladm
{
	/// <summary>
	/// Summary description for AdGenXmlFile.
	/// </summary>
	public class AdGenXmlFile : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Web.UI.WebControls.Button btnGenXml;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPUB;
		protected System.Data.SqlClient.SqlCommand sqlCmdSelXml;
		protected System.Web.UI.WebControls.TextBox tbxXml;
	
		public AdGenXmlFile()
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
			this.sqlCnnMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlCmdSelXml = new System.Data.SqlClient.SqlCommand();
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.btnGenXml.Click += new System.EventHandler(this.btnGenXml_Click);
			// 
			// sqlCnnMRLPUB
			// 
			this.sqlCnnMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlCmdSelXml
			// 
			this.sqlCmdSelXml.CommandText = @"SELECT '~/AdImages/' + dbo.c4_adr.adr_imgurl AS ImageUrl, dbo.c4_adr.adr_navurl AS NavigateUrl, dbo.c4_adr.adr_alttext AS AlternateText, dbo.c4_adr.adr_adcate + dbo.c4_adr.adr_keyword AS Keyword, dbo.c4_adr.adr_impr AS Impression, dbo.c4_cont.cont_contno, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_remark FROM dbo.c4_adr INNER JOIN dbo.c4_cont ON dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno WHERE cont_fgcancel='0' AND cont_fgtemp='0'";
			this.sqlCmdSelXml.Connection = this.sqlCnnMRLPUB;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			this.calSelectAdDate.SelectedDate = DateTime.Today;
			this.btnGenXml.Text = "產生"+this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd", null)+"的廣告播出檔";

			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			if (whoami=="900103")
			{
				this.tbxXml.Visible = true;
			}
			else
			{
				this.tbxXml.Visible = false;
			}
		}

		private void AddJavaScript(string strURL)
		{
			if (strURL != null && strURL != "")
			{
				string strFeature = "toolbar=no,menubar=yes,scrollbars=yes,resizable=yes,width=800,height=600";
				LiteralControl litSC = new LiteralControl();
				litSC.Text = "<script language=javascript>window.open(\""+ strURL + "\", \"Poping\", \"" + strFeature + "\", false);</script>";
				Page.Controls.Add(litSC);
			}
		}

		private void calSelectAdDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.btnGenXml.Text = "產生"+this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd", null)+"的廣告播出檔";
		}

		private void btnGenXml_Click(object sender, System.EventArgs e)
		{
			string TargetDate = calSelectAdDate.SelectedDate.ToString("yyyyMMdd");
			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			GenerateXml(TargetDate);

			AddJavaScript("RptGenXml.aspx?TargetDate=" + TargetDate + "&whoami=" + whoami);
		}

		private void GenerateXml(string TargetDate)
		{
			string strSelectFilter = "(adr_sdate<='" + TargetDate + "' AND adr_edate>='" + TargetDate + "')";
			this.sqlCmdSelXml.CommandText = this.sqlCmdSelXml.CommandText + " AND " + strSelectFilter;
			//Response.Write(this.sqlCmdSelXml.CommandText);
			System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(this.sqlCmdSelXml);
			DataSet ds = new DataSet("Advertisements");
			da.Fill(ds, "Ad");
			this.tbxXml.Text = ds.GetXml();
			//要改路徑
			ds.WriteXml(Server.MapPath("..") + "\\XmlFiles\\" + TargetDate + ".xml");
		}
	}
}
