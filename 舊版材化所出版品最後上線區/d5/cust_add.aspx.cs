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

namespace MRLPub.d5
{
	/// <summary>
	/// Summary description for cust_add.
	/// </summary>
	public class cust_add : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox tbxInm;
		protected System.Web.UI.WebControls.TextBox tbxMfrno;
		protected System.Web.UI.WebControls.Button btnClean;
	
		public cust_add()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Session.Add("QString1", "");
				Session.Add("QString2", "");
				//BindGrid();
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid()
		{
			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			string SQL = "select * from mfr order by mfr_inm";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");
				
			DataView dv = ds.Tables["Title"].DefaultView;

			dv.RowFilter = "mfr_inm LIKE '%" +Session["QString1"].ToString() +"%' AND mfr_mfrno LIKE '%" + Session["QString2"].ToString() + "%' ";
				
			lblResult.Text = dv.Count.ToString();
			Label1.Text = "共查到";
			Label2.Text = "筆資料!";

			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
		}

		private void btnClean_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("cust_add.aspx");
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			Session.Add("QString1", tbxInm.Text.Trim());
			Session.Add("QString2", tbxMfrno.Text.Trim());
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Session.Add("QString1", "");
			Session.Add("QString2", "");
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = "ID="+DataGrid1.SelectedItem.Cells[1].Text;
			Response.Redirect("cust_addnew.aspx?"+ id );
		}
	}
}
