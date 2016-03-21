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
using System.Xml;
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for ShowOrder.
	/// </summary>
	public class ShowOrder : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxOrderType1;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderType2;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMfrno;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxTel;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxInvoiceName;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxFax;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxInvoiceJob;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCell;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxEmail;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxPostCode;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxAddress;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlPayType;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenRec;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlBookType;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenXML;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenID;
		protected System.Web.UI.WebControls.Label lblInvoiceid;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderRes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenOrderNo;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxOrderDate;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
	
		public ShowOrder()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires=0;
			if (!IsPostBack)
			{
				// Put user code to initialize the page here
				string id=Context.Request.QueryString["id"];
				string type1=Context.Request.QueryString["type1"];
				string seq=Context.Request.QueryString["seq"];
				DataSet ds1 = new DataSet();
				DataView dv1;
				this.sqlDataAdapter1.Fill(ds1, "c1_order");
				dv1 = ds1.Tables["c1_order"].DefaultView;
				dv1.RowFilter="o_syscd='C1' and o_custno='"+id+"' and o_otp1cd='"+type1+"' and o_otp1seq='"+seq+"'";
//				dv1.RowFilter="o_syscd='C1' and o_custno='"+id+"' and o_otp1cd='"+type1+"'";
				XmlNode xmlItem;
				XmlDocument xmldoc= new XmlDocument();
				if(dv1.Count>0)
				{
					hiddenXML.Value=dv1[0].Row["o_xmldata"].ToString();
					xmldoc.LoadXml(hiddenXML.Value);
					xmlItem = xmldoc.SelectSingleNode("/root/收件人資料");
					//收件人資料
					hiddenRec.Value=xmlItem.OuterXml;
//					textarea1.Value=xmldoc.OuterXml;
				}
				//付款方式
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "_pytp");
				ddlPayType.DataSource=ds2;
				ddlPayType.DataTextField="pytp_nm";
				ddlPayType.DataValueField="pytp_pytpcd";
				ddlPayType.DataBind();
				//訂購類別
				seq=Context.Request.QueryString["seq1"];
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c1_otp");
				DataView dv3 = ds3.Tables["c1_otp"].DefaultView;
				ddlOrderType2.DataSource=dv3;
				dv3.RowFilter="otp_otp1cd='"+type1+"'";
				ddlOrderType2.DataTextField="otp_otp2nm";
				ddlOrderType2.DataValueField="otp_otp2cd";
				ddlOrderType2.DataBind();
				if(type1=="01")
					tbxOrderType1.Text="訂閱";
				if(type1=="02")
					tbxOrderType1.Text="贈閱";
				if(type1=="03")
					tbxOrderType1.Text="推廣";
				else if(type1=="09")
				{
					seq=Context.Request.QueryString["seq"];
					tbxOrderType1.Text="零售";
					ddlOrderType2.Visible=false;
				}
				//訂單來源
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "c1_ores");
				ddlOrderRes.DataSource=ds4;
				ddlOrderRes.DataTextField="ores_oresnm";
				ddlOrderRes.DataValueField="ores_orescd";
				ddlOrderRes.DataBind();
				//書籍類別
				DataSet ds5= new DataSet();
				this.sqlDataAdapter5.Fill(ds5, "c1_obtp");
				DataView dv5=ds5.Tables["c1_obtp"].DefaultView;
				ddlBookType.DataSource=dv5;
				dv5.RowFilter="obtp_otp1cd='"+type1+"' and fgitri=''";
				ddlBookType.DataTextField="obtp_obtpnm";
				ddlBookType.DataValueField="obtp_obtpcd";
//				ddlBookType.DataValueField="nostr";
				ddlBookType.DataBind();

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
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_obtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpid", "obtp_obtpid"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("fgitri", "fgitri"),
																																																				 new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = @"SELECT dbo.c1_obtp.obtp_obtpid, dbo.c1_obtp.obtp_otp1cd, dbo.c1_obtp.obtp_obtpcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.proj.proj_fgitri AS fgitri, dbo.proj.proj_bkcd, dbo.proj.proj_syscd FROM dbo.c1_obtp INNER JOIN dbo.proj ON dbo.c1_obtp.obtp_obtpcd = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C1')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_ores", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("ores_oresid", "ores_oresid"),
																																																				 new System.Data.Common.DataColumnMapping("ores_orescd", "ores_orescd"),
																																																				 new System.Data.Common.DataColumnMapping("ores_oresnm", "ores_oresnm")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT ores_oresid, ores_orescd, ores_oresnm FROM dbo.c1_ores";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_otp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("otp_otpid", "otp_otpid"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm")})});
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pytp", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpid", "pytp_pytpid"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_oid", "o_oid"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
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
																																																				  new System.Data.Common.DataColumnMapping("o_moddate", "o_moddate"),
																																																				  new System.Data.Common.DataColumnMapping("o_oldvdate", "o_oldvdate"),
																																																				  new System.Data.Common.DataColumnMapping("o_empno", "o_empno"),
																																																				  new System.Data.Common.DataColumnMapping("o_xmldata", "o_xmldata"),
																																																				  new System.Data.Common.DataColumnMapping("o_orescd", "o_orescd"),
																																																				  new System.Data.Common.DataColumnMapping("o_invcd", "o_invcd"),
																																																				  new System.Data.Common.DataColumnMapping("o_taxtp", "o_taxtp")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT o_oid, o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrno, o_inm, o_ijbti, o_iaddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldvdate, o_empno, o_xmldata, o_orescd, o_invcd, o_taxtp FROM dbo.c1_order";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
