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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for S_FixCostCenter.
	/// </summary>
	public class S_FixCostCenter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxCostCenterNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnbNewMfr;
		protected System.Web.UI.WebControls.LinkButton lnbNewCust;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.Label lblMessage1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button Button1;
	
		public S_FixCostCenter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("itridpa_mrlpub", typeof(string))));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "update refd set rd_costctr='"+ tbxCostCenterNo.Text + "'";
			this.sqlCommand1.Connection = this.sqlConnection1;
			
			this.sqlConnection1.Open();
			sqlCommand1.ExecuteNonQuery();
			this.sqlConnection1.Close();
			
			// sqlCommand2
			this.sqlCommand2.CommandText = "update c2_pub set pub_costctr='"+ tbxCostCenterNo.Text + "'";
			this.sqlCommand2.Connection = this.sqlConnection1;
			
			this.sqlConnection1.Open();
			sqlCommand2.ExecuteNonQuery();
			this.sqlConnection1.Close();



			this.RegisterStartupScript("MessageBox","<script>alert('成本中心異動修正成功!!');</script>"); 
		}
		


		

		

		
	}
}
