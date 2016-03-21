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
	/// Summary description for remail_label.
	/// </summary>
	public class remail_label : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList DataList2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataList DataList1;
	
		public remail_label()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				DataSet	ds1=new DataSet();
				//			this.sqlConnection1.ConnectionTimeout=60;
				this.sqlDataAdapter1.Fill(ds1, "c1_remail");
				DataView dv1 = ds1.Tables["c1_remail"].DefaultView;
				if(Context.Request.QueryString["mosea"]=="0")
				{
					DataList1.DataSource=dv1;
					DataList1.DataBind();
				}
				else
				{
					DataList2.DataSource=dv1;
					DataList2.DataBind();
				}
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
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_remail", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("rm_rmid", "rm_rmid"),
																																																				   new System.Data.Common.DataColumnMapping("rm_syscd", "rm_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_custno", "rm_custno"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1cd", "rm_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1seq", "rm_otp1seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_oritem", "rm_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("rm_seq", "rm_seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_cont", "rm_cont"),
																																																				   new System.Data.Common.DataColumnMapping("rm_date", "rm_date"),
																																																				   new System.Data.Common.DataColumnMapping("rm_fgsent", "rm_fgsent"),
																																																				   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				   new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				   new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_remail.rm_rmid, dbo.c1_remail.rm_syscd, dbo.c1_remail.rm_custno, dbo.c1_remail.rm_otp1cd, dbo.c1_remail.rm_otp1seq, dbo.c1_remail.rm_oritem, dbo.c1_remail.rm_seq, dbo.c1_remail.rm_cont, dbo.c1_remail.rm_date, dbo.c1_remail.rm_fgsent, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_fgmosea, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.c1_remail INNER JOIN dbo.tmp_label2 ON dbo.c1_remail.rm_syscd = dbo.tmp_label2.tmp_syscd AND dbo.c1_remail.rm_custno = dbo.tmp_label2.tmp_custno AND dbo.c1_remail.rm_otp1cd = dbo.tmp_label2.tmp_otp1cd AND dbo.c1_remail.rm_otp1seq = dbo.tmp_label2.tmp_otp1seq AND dbo.c1_remail.rm_oritem = dbo.tmp_label2.tmp_oritem AND dbo.c1_remail.rm_seq = dbo.tmp_label2.tmp_seq INNER JOIN dbo.c1_or ON dbo.c1_remail.rm_syscd = dbo.c1_or.or_syscd AND dbo.c1_remail.rm_custno = dbo.c1_or.or_custno AND dbo.c1_remail.rm_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_remail.rm_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_remail.rm_oritem = dbo.c1_or.or_oritem";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
