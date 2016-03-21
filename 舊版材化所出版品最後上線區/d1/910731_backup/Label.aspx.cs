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

namespace MRLPub.b1
{
	/// <summary>
	/// Summary description for Label.
	/// </summary>
	public class Labeltest : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataList Datalist2;
		protected System.Web.UI.WebControls.DataList DataList2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataList DataList1;
	
		public Labeltest()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				DataSet	ds1=new DataSet();
				//			this.sqlConnection1.ConnectionTimeout=60;
				this.sqlDataAdapter1.Fill(ds1, "tmp_label1");
				DataView dv1 = ds1.Tables["tmp_label1"].DefaultView;
				string	strbuf="otp_otp2cd='"+Context.Request.QueryString["type2"]+"'";
				if (Context.Request.QueryString["mnt"]=="0")//5本以上(不含5本)
					strbuf+=" and ra_mnt>5";
				else
					strbuf+=" and ra_mnt="+Context.Request.QueryString["mnt"];
				dv1.RowFilter=strbuf;
				if(Context.Request.QueryString["mosea"]=="0")
				{
					DataList1.DataSource=dv1;
					DataList1.DataBind();
					for(int i=0; i<dv1.Count; i++)
						((Label)DataList1.Items[i].FindControl("lblBookNo1")).Text=Context.Request.QueryString["book"]+"期";
				}
				else
				{
					DataList2.DataSource=dv1;
					DataList2.DataBind();
					for(int i=0; i<dv1.Count; i++)
						((Label)DataList2.Items[i].FindControl("lblBookNo2")).Text=Context.Request.QueryString["book"]+"期";
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
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.tmp_label1.od_odid, dbo.tmp_label1.od_syscd, dbo.tmp_label1.od_custno, dbo.tmp_label1.od_otp1cd, dbo.tmp_label1.od_otp1seq, dbo.tmp_label1.od_oditem, dbo.tmp_label1.od_sdate, dbo.tmp_label1.od_edate, dbo.tmp_label1.ra_mnt, dbo.tmp_label1.mtp_nm, dbo.tmp_label1.obtp_obtpnm, dbo.tmp_label1.ra_oritem, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_fgmosea, dbo.c1_otp.otp_otp2nm, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd FROM dbo.tmp_label1 INNER JOIN dbo.c1_or ON dbo.tmp_label1.od_syscd = dbo.c1_or.or_syscd AND dbo.tmp_label1.od_custno = dbo.c1_or.or_custno AND dbo.tmp_label1.od_otp1cd = dbo.c1_or.or_otp1cd AND dbo.tmp_label1.od_otp1seq = dbo.c1_or.or_otp1seq AND dbo.tmp_label1.ra_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.c1_order ON dbo.tmp_label1.od_syscd = dbo.c1_order.o_syscd AND dbo.tmp_label1.od_custno = dbo.c1_order.o_custno AND dbo.tmp_label1.od_otp1cd = dbo.c1_order.o_otp1cd AND dbo.tmp_label1.od_otp1seq = dbo.c1_order.o_otp1seq INNER JOIN dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd ORDER BY dbo.tmp_label1.od_custno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tmp_label1", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("od_odid", "od_odid"),
																																																					new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd"),
																																																					new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																					new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																					new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																					new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																					new System.Data.Common.DataColumnMapping("od_sdate", "od_sdate"),
																																																					new System.Data.Common.DataColumnMapping("od_edate", "od_edate"),
																																																					new System.Data.Common.DataColumnMapping("ra_mnt", "ra_mnt"),
																																																					new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																					new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																					new System.Data.Common.DataColumnMapping("ra_oritem", "ra_oritem"),
																																																					new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																					new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																					new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																					new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																					new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																					new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																					new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm"),
																																																					new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																					new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																					new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																					new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																					new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																					new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																					new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
