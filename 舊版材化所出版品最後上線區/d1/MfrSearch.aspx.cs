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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for MfrSearch.
	/// </summary>
	public class MfrSearch : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid MfrDataGrid;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden3;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Literal Literal2;
		protected System.Web.UI.WebControls.Literal Literal3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden4;
	
		public MfrSearch()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				string mfrno=Context.Request.QueryString["mfrno"].Trim();
				Hidden1.Value=Context.Request.QueryString["Field1"].Trim();
				Hidden2.Value=Context.Request.QueryString["mfrno"].Trim();
				string company=Context.Request.QueryString["company"].Trim();
				Hidden3.Value=Context.Request.QueryString["Field2"].Trim();
				Hidden4.Value=Context.Request.QueryString["company"].Trim();
				BindGrid();
//				DataSet ds = new DataSet();
//				this.sqlDataAdapter1.Fill(ds, "_mfr");
//				DataView dv = ds.Tables["_mfr"].DefaultView;
//				dv.RowFilter = "mfr_mfrno Like '%"+mfrno+"%' and mfr_inm Like '%"+company+"%'";
//				MfrDataGrid.DataSource = dv;
//				MfrDataGrid.DataBind();
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.MfrDataGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.MfrDataGrid_PageIndexChanged);
			this.MfrDataGrid.Load += new System.EventHandler(this.Page_Load);
			this.MfrDataGrid.SelectedIndexChanged += new System.EventHandler(this.MfrDataGrid_SelectedIndexChanged);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT mfr_mfrid, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, mfr_respnm, mfr_respjb" +
				"ti, mfr_tel, mfr_fax, mfr_regdate FROM dbo.mfr";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate")})});

		}
		#endregion


		private void MfrDataGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			MfrDataGrid.SelectedIndex=e.Item.ItemIndex;
			Hidden2.Value=MfrDataGrid.SelectedItem.Cells[2].Text.Trim();
			Hidden4.Value=MfrDataGrid.SelectedItem.Cells[3].Text.Trim();
			Literal1.Text="<script language=\"javascript\">window.opener.document.all(window.document.all(\"Hidden1\").value).value=\"\"+window.document.all(\"Hidden2\").value;</script>";
			Literal2.Text="<script language=\"javascript\">window.opener.document.all(window.document.all(\"Hidden3\").value).value=\"\"+window.document.all(\"Hidden4\").value;</script>";
			Literal3.Text="<script language=\"javascript\">window.close();</script>";
		}
		public void BindGrid()
		{
			string mfrno=Context.Request.QueryString["mfrno"].Trim();
//			Hidden1.Value=Context.Request.QueryString["Field1"];
//			Hidden2.Value=Context.Request.QueryString["mfrno"];
			string company=Context.Request.QueryString["company"].Trim();
//			Hidden3.Value=Context.Request.QueryString["Field2"];
//			Hidden4.Value=Context.Request.QueryString["conpany"];
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "_mfr");
			DataView dv = ds.Tables["_mfr"].DefaultView;
			dv.RowFilter = "mfr_mfrno Like '%"+mfrno+"%' and mfr_inm Like '%"+company+"%'";
			MfrDataGrid.DataSource = dv;
			MfrDataGrid.DataBind();
		}

		private void MfrDataGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			MfrDataGrid.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
	}
}
