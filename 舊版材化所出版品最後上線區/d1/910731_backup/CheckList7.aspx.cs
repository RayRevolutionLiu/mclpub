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
	/// Summary description for CheckList7.
	/// </summary>
	public class CheckList7 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
	
		public CheckList7()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "py");
				DataView dv1 = ds1.Tables["py"].DefaultView;
				dv1.RowFilter="py_pysdate='' and py_pysseq='' and py_pysitem=''";
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
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
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.pyd.pyd_pyditem, dbo.pyd.pyd_iano, dbo.pyd.pyd_pyno, dbo.pyd.pyd_cancel, dbo.py.py_pyid, dbo.py.py_pyno, dbo.py.py_amt, dbo.py.py_pytpcd, dbo.py.py_date, dbo.py.py_moseq, dbo.py.py_moitem, dbo.py.py_chkno, dbo.py.py_chkbnm, dbo.py.py_chkdate, dbo.py.py_waccno, dbo.py.py_wdate, dbo.py.py_wbcd, dbo.py.py_ccno, dbo.py.py_cctp, dbo.py.py_ccauthcd, dbo.py.py_ccvdate, dbo.py.py_ccdate, dbo.py.py_fgprinted, dbo.py.py_syscd, dbo.py.py_pysdate, dbo.py.py_pysseq, dbo.py.py_pysitem, dbo.pytp.pytp_nm, dbo.pytp.pytp_pytpcd FROM dbo.py INNER JOIN dbo.pyd ON dbo.py.py_pyno = dbo.pyd.pyd_pyno INNER JOIN dbo.pytp ON dbo.py.py_pytpcd = dbo.pytp.pytp_pytpcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "py", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("pyd_pyditem", "pyd_pyditem"),
																																																			new System.Data.Common.DataColumnMapping("pyd_iano", "pyd_iano"),
																																																			new System.Data.Common.DataColumnMapping("pyd_pyno", "pyd_pyno"),
																																																			new System.Data.Common.DataColumnMapping("pyd_cancel", "pyd_cancel"),
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
																																																			new System.Data.Common.DataColumnMapping("py_pysitem", "py_pysitem"),
																																																			new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
