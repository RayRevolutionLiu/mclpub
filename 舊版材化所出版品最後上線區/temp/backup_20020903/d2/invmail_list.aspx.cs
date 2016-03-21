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

namespace MRLPub_d2
{
	/// <summary>
	/// Summary description for invmail_list.
	/// </summary>
	public class invmail_list : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label lblMemo;
	
		public invmail_list()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 顯示下拉式選單 業務員的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "book");
				this.ddlBookCode.DataSource=ds1;
				this.ddlBookCode.DataTextField="bk_nm";
				this.ddlBookCode.DataValueField="bk_bkcd";
				this.ddlBookCode.DataBind();
				
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT bk_bkcd, bk_nm FROM book";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 抓出所選取的業務員工號
			string BookCode = "";
			string BookName = "";
			BookCode = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
			BookName = this.ddlBookCode.SelectedItem.Text.ToString().Trim();
			//Response.Write("BookCode= " + BookCode + "<br>");
			//Response.Write("BookName= " + BookName + "<br>");
			//Response.Write("invmail_list2.aspx?empno=" + BookCode + " " + BookName + "<br>");
			
			// 轉址: 執行 ExcelSpeedGen
			Response.Redirect("invmail_list2.aspx?bkcd=" + BookCode);
			
		}
	}
}
