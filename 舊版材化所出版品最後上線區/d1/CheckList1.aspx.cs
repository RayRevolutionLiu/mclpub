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
	/// Summary description for CheckList1.
	/// </summary>
	public class CheckList1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox tbxDate1;
		protected System.Web.UI.WebControls.TextBox tbxDate2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
	
		public CheckList1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
				tbxDate1.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxDate2.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp2cd", "o_otp2cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_mfrno", "o_mfrno"),
																																																				  new System.Data.Common.DataColumnMapping("o_inm", "o_inm"),
																																																				  new System.Data.Common.DataColumnMapping("o_ijbti", "o_ijbti"),
																																																				  new System.Data.Common.DataColumnMapping("o_iaddr", "o_iaddr"),
																																																				  new System.Data.Common.DataColumnMapping("o_izip", "o_izip"),
																																																				  new System.Data.Common.DataColumnMapping("o_itel", "o_itel"),
																																																				  new System.Data.Common.DataColumnMapping("o_ifax", "o_ifax"),
																																																				  new System.Data.Common.DataColumnMapping("o_icell", "o_icell"),
																																																				  new System.Data.Common.DataColumnMapping("o_iemail", "o_iemail"),
																																																				  new System.Data.Common.DataColumnMapping("o_pytpcd", "o_pytpcd"),
																																																				  new System.Data.Common.DataColumnMapping("o_fgpreinv", "o_fgpreinv"),
																																																				  new System.Data.Common.DataColumnMapping("o_date", "o_date"),
																																																				  new System.Data.Common.DataColumnMapping("o_empno", "o_empno"),
																																																				  new System.Data.Common.DataColumnMapping("o_orescd", "o_orescd"),
																																																				  new System.Data.Common.DataColumnMapping("o_invcd", "o_invcd"),
																																																				  new System.Data.Common.DataColumnMapping("o_taxtp", "o_taxtp"),
																																																				  new System.Data.Common.DataColumnMapping("o_indate", "o_indate"),
																																																				  new System.Data.Common.DataColumnMapping("o_status", "o_status"),
																																																				  new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																				  new System.Data.Common.DataColumnMapping("od_sdate", "od_sdate"),
																																																				  new System.Data.Common.DataColumnMapping("od_edate", "od_edate"),
																																																				  new System.Data.Common.DataColumnMapping("od_btpcd", "od_btpcd"),
																																																				  new System.Data.Common.DataColumnMapping("od_projno", "od_projno"),
																																																				  new System.Data.Common.DataColumnMapping("od_costctr", "od_costctr"),
																																																				  new System.Data.Common.DataColumnMapping("od_remark", "od_remark"),
																																																				  new System.Data.Common.DataColumnMapping("od_amt", "od_amt"),
																																																				  new System.Data.Common.DataColumnMapping("od_custtp", "od_custtp"),
																																																				  new System.Data.Common.DataColumnMapping("ra_mnt", "ra_mnt"),
																																																				  new System.Data.Common.DataColumnMapping("ra_mtpcd", "ra_mtpcd"),
																																																				  new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				  new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				  new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				  new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				  new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				  new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				  new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																				  new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																				  new System.Data.Common.DataColumnMapping("or_email", "or_email"),
																																																				  new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				  new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																				  new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																				  new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				  new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("ra_custno", "ra_custno"),
																																																				  new System.Data.Common.DataColumnMapping("ra_oditem", "ra_oditem"),
																																																				  new System.Data.Common.DataColumnMapping("ra_oritem", "ra_oritem"),
																																																				  new System.Data.Common.DataColumnMapping("ra_otp1cd", "ra_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("ra_otp1seq", "ra_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("ra_syscd", "ra_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																				  new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c1_order.o_syscd + dbo.c1_order.o_custno + dbo.c1_order.o_otp1cd + dbo" +
				".c1_order.o_otp1seq AS nostr, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c" +
				"1_order.o_inm, dbo.c1_order.o_ijbti, dbo.c1_order.o_iaddr, dbo.c1_order.o_izip, " +
				"dbo.c1_order.o_itel, dbo.c1_order.o_ifax, dbo.c1_order.o_icell, dbo.c1_order.o_i" +
				"email, dbo.c1_order.o_pytpcd, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_date, dbo." +
				"c1_order.o_empno, dbo.c1_order.o_orescd, dbo.c1_order.o_invcd, dbo.c1_order.o_ta" +
				"xtp, dbo.c1_order.o_indate, dbo.c1_order.o_status, dbo.c1_od.od_oditem, dbo.c1_o" +
				"d.od_sdate, dbo.c1_od.od_edate, dbo.c1_od.od_btpcd, dbo.c1_od.od_projno, dbo.c1_" +
				"od.od_costctr, dbo.c1_od.od_remark, dbo.c1_od.od_amt, dbo.c1_od.od_custtp, dbo.c" +
				"1_ramt.ra_mnt, dbo.c1_ramt.ra_mtpcd, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_o" +
				"r.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_tel, dbo.c1_or.or_f" +
				"ax, dbo.c1_or.or_cell, dbo.c1_or.or_email, dbo.c1_or.or_fgmosea, dbo.c1_od.od_cu" +
				"stno, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_syscd, dbo.c1_orde" +
				"r.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_syscd," +
				" dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp" +
				"1seq, dbo.c1_or.or_syscd, dbo.c1_ramt.ra_custno, dbo.c1_ramt.ra_oditem, dbo.c1_r" +
				"amt.ra_oritem, dbo.c1_ramt.ra_otp1cd, dbo.c1_ramt.ra_otp1seq, dbo.c1_ramt.ra_sys" +
				"cd, dbo.c1_obtp.obtp_obtpnm, dbo.mtp.mtp_nm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obt" +
				"p.obtp_otp1cd, dbo.mtp.mtp_mtpcd FROM dbo.c1_order INNER JOIN dbo.c1_od ON dbo.c" +
				"1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c1_order.o_custno = dbo.c1_od.od_cu" +
				"stno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_order.o_otp1seq " +
				"= dbo.c1_od.od_otp1seq INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ram" +
				"t.ra_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND dbo.c1_od.od_otp1" +
				"cd = dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND" +
				" dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c1_or ON dbo.c1_ramt" +
				".ra_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = dbo.c1_or.or_custno A" +
				"ND dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ramt.ra_otp1seq = dbo." +
				"c1_or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_oritem INNER JOIN dbo." +
				"c1_obtp ON dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd AND dbo.c1_od.od_otp1cd " +
				"= dbo.c1_obtp.obtp_otp1cd INNER JOIN dbo.mtp ON dbo.c1_ramt.ra_mtpcd = dbo.mtp.m" +
				"tp_mtpcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string	date1, date2;
			date1=tbxDate1.Text.Substring(0,4)+tbxDate1.Text.Substring(5,2)+tbxDate1.Text.Substring(8,2);
			date2=tbxDate2.Text.Substring(0,4)+tbxDate2.Text.Substring(5,2)+tbxDate2.Text.Substring(8,2);
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_order");
			DataView dv1 = ds1.Tables["c1_order"].DefaultView;
			dv1.RowFilter="o_status='1' and (o_indate>='"+date1+"' and o_indate<='"+date2+"')";
			DataGrid1.DataSource=dv1;
			DataGrid1.DataBind();
		}
	}
}
