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
	/// Summary description for adamt_list.
	/// </summary>
	public class adamt_list : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.HtmlControls.HtmlForm adcont_list;
	
		public adamt_list()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 顯示下拉式選單 書籍類別代碼的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "book");
				this.ddlBookCode.DataSource=ds1;
				this.ddlBookCode.DataTextField="bk_nm";
				this.ddlBookCode.DataValueField="bk_bkcd";
				this.ddlBookCode.DataBind();
			

				// 顯示下拉式選單 業務員的 DB 值
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				this.ddlEmpNo.DataSource=ds2;
				this.ddlEmpNo.DataTextField="srspn_cname";
				this.ddlEmpNo.DataValueField="srspn_empno";
				this.ddlEmpNo.DataBind();

				// 給 tbxYYYYMM 預設值 (今天年月)
				//this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
				this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyyMM").Trim();
				
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
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
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT bk_bkid, bk_bkcd, bk_nm FROM book";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date FROM srspn WHERE (srspn_atype = \'B\') OR (srspn_atype = \'" +
				"C\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 抓出所選取的書籍類別代碼
			string BookCode = "";
			string BookName = "";
			BookCode = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
			BookName = this.ddlBookCode.SelectedItem.Text.ToString().Trim();
			//Response.Write("BookCode= " + BookCode + "<br>");
			//Response.Write("BookName= " + BookName + "<br>");
			
			
			// 抓出所選取的業務員工號
			string EmpNo = "";
			string EmpCName = "";
			EmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			EmpCName = this.ddlEmpNo.SelectedItem.Text.ToString().Trim();
			//Response.Write("Empno= " + EmpNo + "<br>");
			//Response.Write("EmpCName= " + EmpCName + "<br>");

			// 抓出所選取的業務員工號
			string YYYYMM = "";
			YYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			//YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
			//Response.Write("YYYYMM= " + YYYYMM + "<br>");
			//Response.Write("adamt_list2.aspx?bkcd=" + BookCode + "&empno=" + EmpNo + "&enddate=" + YYYYMM);
			
			// 轉址: 執行 ExcelSpeedGen
			Response.Redirect("adamt_list2.aspx?bkcd=" + BookCode + "&empno=" + EmpNo + "&enddate=" + YYYYMM);
			
		}


	}
}
