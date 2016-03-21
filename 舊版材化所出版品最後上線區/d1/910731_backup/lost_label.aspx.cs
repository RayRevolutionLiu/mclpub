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
	/// Summary description for lost_label.
	/// </summary>
	public class lost_label : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList DataList2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataList DataList1;
	
		public lost_label()
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
				this.sqlDataAdapter1.Fill(ds1, "c1_lost");
				DataView dv1 = ds1.Tables["c1_lost"].DefaultView;
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
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_lost.lst_lstid, dbo.c1_lost.lst_syscd, dbo.c1_lost.lst_custno, dbo.c1_lost.lst_otp1cd, dbo.c1_lost.lst_otp1seq, dbo.c1_lost.lst_oritem, dbo.c1_lost.lst_seq, dbo.c1_lost.lst_cont, dbo.c1_lost.lst_date, dbo.c1_lost.lst_rea, dbo.c1_lost.lst_fgsent, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_fgmosea, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.c1_lost INNER JOIN dbo.c1_or ON dbo.c1_lost.lst_syscd = dbo.c1_or.or_syscd AND dbo.c1_lost.lst_custno = dbo.c1_or.or_custno AND dbo.c1_lost.lst_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_lost.lst_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.tmp_label2 ON dbo.c1_lost.lst_syscd = dbo.tmp_label2.tmp_syscd AND dbo.c1_lost.lst_custno = dbo.tmp_label2.tmp_custno AND dbo.c1_lost.lst_otp1cd = dbo.tmp_label2.tmp_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.tmp_label2.tmp_otp1seq AND dbo.c1_lost.lst_oritem = dbo.tmp_label2.tmp_oritem AND dbo.c1_lost.lst_seq = dbo.tmp_label2.tmp_seq";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_lstid", "lst_lstid"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_custno", "lst_custno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_otp1cd", "lst_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_otp1seq", "lst_otp1seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
