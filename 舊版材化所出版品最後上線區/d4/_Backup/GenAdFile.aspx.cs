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
using System.Data.SqlClient;

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for GenAdFile.
	/// </summary>
	public class GenAdFile : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlCnnITRINTS8;
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Web.UI.WebControls.Button btnGenXml;
		protected System.Web.UI.WebControls.TextBox tbxXml;
		protected System.Data.SqlClient.SqlCommand sqlCmdSelXml;
	
		public GenAdFile()
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
			this.sqlCnnITRINTS8 = new System.Data.SqlClient.SqlConnection();
			this.sqlCmdSelXml = new System.Data.SqlClient.SqlCommand();
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.btnGenXml.Click += new System.EventHandler(this.btnGenXml_Click);
			// 
			// sqlCnnITRINTS8
			// 
			this.sqlCnnITRINTS8.ConnectionString = "data source=140.96.170.7,1995;password=ji3z7ha;persist security info=True;user id" +
				"=mrlpubadm;workstation id=17-0900103-01;packet size=4096";
			// 
			// sqlCmdSelXml
			// 
			this.sqlCmdSelXml.CommandText = "SELECT adr_imgurl AS ImageUrl, adr_navurl AS NavigateUrl, adr_alttext AS Alternat" +
				"eText, adr_adcate + adr_keyword AS Keyword, adr_impr AS Impression FROM dbo.c4_a" +
				"dr";
			this.sqlCmdSelXml.Connection = this.sqlCnnITRINTS8;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			this.calSelectAdDate.SelectedDate = DateTime.Today;
			this.btnGenXml.Text = "產生"+this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd", null)+"的廣告落版";
		}

		private void calSelectAdDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.btnGenXml.Text = "產生"+this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd", null)+"的廣告落版";
		}

		private void btnGenXml_Click(object sender, System.EventArgs e)
		{
			GenerateXml(this.calSelectAdDate.SelectedDate.ToString("yyyyMMdd", null));
		}

		private void GenerateXml(string TargetDate)
		{
			string strSelectFilter = "adr_keyword<'W1' AND substring(adr_date,1,6)='" + TargetDate.Substring(0,6) + "'";
			this.sqlCmdSelXml.CommandText = this.sqlCmdSelXml.CommandText + " WHERE " + strSelectFilter;
			SqlDataAdapter da = new SqlDataAdapter(this.sqlCmdSelXml);
			DataSet ds = new DataSet("Advertisements");
			da.Fill(ds, "Ad");
			this.tbxXml.Text = ds.GetXml();
			//要改路徑
			ds.WriteXml(Server.MapPath("..") + "/" + TargetDate + ".xml");
		}
	}
}
