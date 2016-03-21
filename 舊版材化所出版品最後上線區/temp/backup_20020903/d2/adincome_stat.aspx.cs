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
	/// Summary description for adincome_list.
	/// </summary>
	public class adincome_stat : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm adincome_list;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		public adincome_stat()
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
				this.sqlDataAdapter1.Fill(ds1, "srspn");
				this.ddlEmpNo.DataSource=ds1;
				this.ddlEmpNo.DataTextField="srspn_cname";
				this.ddlEmpNo.DataValueField="srspn_empno";
				this.ddlEmpNo.DataBind();
				
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date FROM srspn WHERE (srspn_atype = \'b\') OR (srspn_atype = \'" +
				"c\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 抓出所選取的業務員工號
			string EmpNo = "";
			string EmpCName = "";
			EmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			EmpCName = this.ddlEmpNo.SelectedItem.Text.ToString().Trim();
			//Response.Write("Empno= " + EmpNo + "<br>");
			//Response.Write("EmpCName= " + EmpCName + "<br>");
			//Response.Write("adincome_stat2.aspx?empno=" + EmpNo + " " + EmpCName + "<br>");
			
			// 轉址: 執行 ExcelSpeedGen
			Response.Redirect("adincome_stat2.aspx?empno=" + EmpNo);
			
		}
	}
}
