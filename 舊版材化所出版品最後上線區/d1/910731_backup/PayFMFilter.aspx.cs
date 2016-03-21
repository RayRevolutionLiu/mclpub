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

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for PayFMFilter.
	/// </summary>
	public class PayFMFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.TextBox tbxPyno;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
	
		public PayFMFilter()
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "py", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("py_pyid", "py_pyid"),
																																																			new System.Data.Common.DataColumnMapping("py_pyno", "py_pyno"),
																																																			new System.Data.Common.DataColumnMapping("py_amt", "py_amt"),
																																																			new System.Data.Common.DataColumnMapping("py_pytpcd", "py_pytpcd"),
																																																			new System.Data.Common.DataColumnMapping("py_date", "py_date"),
																																																			new System.Data.Common.DataColumnMapping("py_moseq", "py_moseq"),
																																																			new System.Data.Common.DataColumnMapping("py_moitem", "py_moitem"),
																																																			new System.Data.Common.DataColumnMapping("py_chkno", "py_chkno"),
																																																			new System.Data.Common.DataColumnMapping("py_chkbnm", "py_chkbnm"),
																																																			new System.Data.Common.DataColumnMapping("py_chkdate", "py_chkdate"),
																																																			new System.Data.Common.DataColumnMapping("py_waccno", "py_waccno"),
																																																			new System.Data.Common.DataColumnMapping("py_wdate", "py_wdate"),
																																																			new System.Data.Common.DataColumnMapping("py_wbcd", "py_wbcd"),
																																																			new System.Data.Common.DataColumnMapping("py_ccno", "py_ccno"),
																																																			new System.Data.Common.DataColumnMapping("py_cctp", "py_cctp"),
																																																			new System.Data.Common.DataColumnMapping("py_ccauthcd", "py_ccauthcd"),
																																																			new System.Data.Common.DataColumnMapping("py_ccvdate", "py_ccvdate"),
																																																			new System.Data.Common.DataColumnMapping("py_ccdate", "py_ccdate"),
																																																			new System.Data.Common.DataColumnMapping("py_fgprinted", "py_fgprinted"),
																																																			new System.Data.Common.DataColumnMapping("py_syscd", "py_syscd"),
																																																			new System.Data.Common.DataColumnMapping("py_pysdate", "py_pysdate"),
																																																			new System.Data.Common.DataColumnMapping("py_pysseq", "py_pysseq"),
																																																			new System.Data.Common.DataColumnMapping("py_pysitem", "py_pysitem")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pyd", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("pyd_pydid", "pyd_pydid"),
																																																			 new System.Data.Common.DataColumnMapping("pyd_pyno", "pyd_pyno"),
																																																			 new System.Data.Common.DataColumnMapping("pyd_pyditem", "pyd_pyditem"),
																																																			 new System.Data.Common.DataColumnMapping("pyd_syscd", "pyd_syscd"),
																																																			 new System.Data.Common.DataColumnMapping("pyd_iano", "pyd_iano"),
																																																			 new System.Data.Common.DataColumnMapping("pyd_cancel", "pyd_cancel")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT pyd_pydid, pyd_pyno, pyd_pyditem, pyd_syscd, pyd_iano, pyd_cancel FROM dbo" +
				".pyd";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			string	nostr="";
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "py");
			DataView dv1 = ds1.Tables["py"].DefaultView;
			dv1.RowFilter="py_pyno='"+tbxPyno.Text.Trim()+"'";

			if(dv1.Count<=0)
				lblMessage.Text="查無此繳款編號";
			else
			{
				if(dv1[0].Row["py_pysdate"].ToString().Trim()=="")
				{
					DataSet ds2 = new DataSet();
					this.sqlDataAdapter2.Fill(ds2, "pyd");
					DataView dv2 = ds2.Tables["pyd"].DefaultView;
					dv2.RowFilter="pyd_pyno='"+tbxPyno.Text.Trim()+"' and pyd_cancel=''";
					for(int	i=0; i<dv2.Count; i++)
						nostr+=dv2[i].Row["pyd_iano"];
					Response.Redirect("PayTypeFM.aspx?pyno="+tbxPyno.Text.Trim()+"&no="+nostr);
				}
				else
					lblMessage.Text="此繳款資料已產生繳款清單不允許修改!!";
			}
		}

	}
}
