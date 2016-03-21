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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for ORForm.
	/// </summary>
	public class ORForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.TextBox tbxORName;
		protected System.Web.UI.WebControls.TextBox tbxORMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxORJobTitle;
		protected System.Web.UI.WebControls.TextBox tbxORZipcode;
		protected System.Web.UI.WebControls.TextBox tbxORAddr;
		protected System.Web.UI.WebControls.TextBox tbxORTel;
		protected System.Web.UI.WebControls.TextBox tbxORFax;
		protected System.Web.UI.WebControls.TextBox tbxORCell;
		protected System.Web.UI.WebControls.TextBox tbxOREmail;
		protected System.Web.UI.WebControls.TextBox tbxORPubCount;
		protected System.Web.UI.WebControls.TextBox tbxORPubUnCount;
		protected System.Web.UI.WebControls.DropDownList ddlORmtpcd;
		protected System.Web.UI.WebControls.DropDownList ddlORfgmosea;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.TextBox tbxORSysCode;
		protected System.Web.UI.WebControls.TextBox tbxORContNo;
		protected System.Web.UI.WebControls.Button btnClose;
	
		public ORForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// 顯示下拉式選單 郵寄類別代碼的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "mtp");
				ddlORmtpcd.DataSource=ds1;
				ddlORmtpcd.DataTextField="mtp_nm";
				ddlORmtpcd.DataValueField="mtp_mtpcd";
				ddlORmtpcd.DataBind();
				
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM mtp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
