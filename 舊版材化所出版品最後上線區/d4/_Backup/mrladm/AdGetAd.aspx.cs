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
	/// Summary description for AdGetAd.
	/// </summary>
	public class AdGetAd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.TextBox tbxAdDate;
		protected System.Web.UI.WebControls.CheckBox cbxEmpNo;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Data.SqlClient.SqlConnection sqlMRLPUB;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaSrspn;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAdDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAdDate;
		protected System.Web.UI.WebControls.Button btnGo;
	
		public AdGetAd()
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
			this.sqlMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaSrspn = new System.Data.SqlClient.SqlDataAdapter();
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// sqlMRLPUB
			// 
			this.sqlMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_empno, srspn_cname FROM dbo.srspn";
			this.sqlSelectCommand1.Connection = this.sqlMRLPUB;
			// 
			// sqlDaSrspn
			// 
			this.sqlDaSrspn.SelectCommand = this.sqlSelectCommand1;
			this.sqlDaSrspn.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																		  new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																		  new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			Bind_ddlEmpNo();
		}

		private void Bind_ddlEmpNo()
		{
			DataSet ds = new DataSet();
			this.sqlDaSrspn.Fill(ds, "SRSPN");
			DataView dv = ds.Tables["SRSPN"].DefaultView;

			this.ddlEmpNo.DataTextField = "srspn_cname";
			this.ddlEmpNo.DataValueField = "srspn_empno";
			this.ddlEmpNo.DataSource = dv;
			this.ddlEmpNo.DataBind();
		}

		private string GetFilter()
		{
			string strReturn = "";
			string addate = DateTime.ParseExact(this.tbxAdDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");

			strReturn = "adr_adcate='" + this.ddlAdCate.SelectedItem.Value + "' AND adr_sdate<='" + addate + "' AND adr_edate>='" + addate + "'";

			if (this.cbxEmpNo.Checked)
			{
				strReturn += " AND cont_empno = '" + this.ddlEmpNo.SelectedItem.Value + "'";
			}

			return strReturn;
		}

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			if (!Page.IsValid)
			{
				//Response.Write("¿ù»~¡I¡I¡I¡I¡I¡I¡I¡I¡I");
				//do nothing here
				return;
			}

			Response.Write(GetFilter());
		}
	}
}
