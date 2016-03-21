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
	/// Summary description for PayFilter.
	/// </summary>
	public class PayFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnNextStep;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblCount;
		protected System.Web.UI.WebControls.DataList DataList1;
	
		public PayFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
			
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "ia");
				DataList1.DataSource=ds;
				DataList1.DataBind();
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
			this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iano, dbo.ia.ia_mfrno, dbo.ia.ia_pyat, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrno, dbo.ia.ia_refno FROM dbo.ia INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_pyno = '')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNextStep_Click(object sender, System.EventArgs e)
		{
			string strbuf="";
			int count=0;
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
				{
					count+=Convert.ToInt32(((Label)DataList1.Items[i].FindControl("lblAmt")).Text);
					strbuf+=((Label)DataList1.Items[i].FindControl("lblNo")).Text;
				}
			}
			if(count==0)
				lblCount.Text="<<請選擇欲付款之發票>>";
			else
			{
				if(Context.Request.QueryString["caller"]=="order")
					Response.Redirect("PayTypeForm.aspx?count="+count.ToString()+"&caller=order&no="+strbuf);
				else
					Response.Redirect("PayTypeForm.aspx?count="+count.ToString()+"&caller=&no="+strbuf);
			}
		}
	}
}
