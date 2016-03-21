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
	/// Summary description for FreeFM.
	/// </summary>
	public class FreeFM : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxOrderType1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Span1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenID;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Span2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenOrderNo;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderRes;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxOrderDate;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderType2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenRec;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlBookType;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBook;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenType1;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblCoName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCoName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCoAddress;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlSpn;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenXML;
	
		public FreeFM()
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
				//訂購類別
				hiddenType1.Value=type1;
				seq=Context.Request.QueryString["seq1"];
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c1_otp");
				DataView dv2 = ds2.Tables["c1_otp"].DefaultView;
				ddlOrderType2.DataSource=dv2;
				dv2.RowFilter="otp_otp1cd='"+type1+"'";
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
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c1_ores");
				ddlOrderRes.DataSource=ds3;
				ddlOrderRes.DataTextField="ores_oresnm";
				ddlOrderRes.DataValueField="ores_orescd";
				ddlOrderRes.DataBind();
				//書籍類別
				DataSet ds4= new DataSet("書籍資料");
				this.sqlDataAdapter4.Fill(ds4, "書籍明細");
				hiddenBook.Value=ds4.GetXml();

				ds4= new DataSet("書籍資料");
				this.sqlDataAdapter4.Fill(ds4, "c1_obtp");
				DataView dv4=ds4.Tables["c1_obtp"].DefaultView;
				ddlBookType.DataSource=dv4;
				dv4.RowFilter="obtp_otp1cd='"+type1+"' and fgitri=''";
				ddlBookType.DataTextField="obtp_obtpnm";
				ddlBookType.DataValueField="obtp_obtpcd";
				//				ddlBookType.DataValueField="nostr";
				ddlBookType.DataBind();
				//訂戶資料
				DataSet ds5= new DataSet();
				this.sqlDataAdapter5.Fill(ds5, "c1_cust");
				DataView dv5=ds5.Tables["c1_cust"].DefaultView;
				dv5.RowFilter="cust_custno = '"+id+"'";
//				hiddenMfrno.Value=dv5[0].Row["cust_mfrno"].ToString();
				lblName.Text=dv5[0].Row["cust_nm"].ToString();
				lblCoName.Text=dv5[0].Row["mfr_inm"].ToString();
				hiddenCoName.Value=dv5[0].Row["mfr_inm"].ToString().Trim();
				hiddenCoAddress.Value=dv5[0].Row["mfr_iaddr"].ToString().Trim();
				//承辦業務員
				DataSet ds6 = new DataSet();
				this.sqlDataAdapter6.Fill(ds6, "srspn");
				DataView dv6=ds6.Tables["srspn"].DefaultView;
				dv6.RowFilter="srspn_atype <> 'A'";
				ddlSpn.DataSource=dv6;
				ddlSpn.DataTextField="srspn_cname";
				ddlSpn.DataValueField="srspn_empno";
				ddlSpn.DataBind();
				
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
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT ores_oresid, ores_orescd, ores_oresnm FROM dbo.c1_ores";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT o_oid, o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrno, o_inm, o_ijbti, o_iaddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldvdate, o_empno, o_xmldata, o_orescd, o_invcd, o_taxtp FROM dbo.c1_order";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT dbo.c1_obtp.obtp_obtpid, dbo.c1_obtp.obtp_otp1cd, dbo.c1_obtp.obtp_obtpcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.proj.proj_fgitri AS fgitri, dbo.proj.proj_bkcd, dbo.proj.proj_syscd FROM dbo.c1_obtp INNER JOIN dbo.proj ON dbo.c1_obtp.obtp_obtpcd = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C1')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT dbo.c1_cust.cust_custno, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.mfr.mfr" +
				"_mfrid, dbo.mfr.mfr_iaddr FROM dbo.c1_cust INNER JOIN dbo.mfr ON dbo.c1_cust.cus" +
				"t_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_ores", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("ores_oresid", "ores_oresid"),
																																																				 new System.Data.Common.DataColumnMapping("ores_orescd", "ores_orescd"),
																																																				 new System.Data.Common.DataColumnMapping("ores_oresnm", "ores_oresnm")})});
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_otp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("otp_otpid", "otp_otpid"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm")})});
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
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.srspn(srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd) VALUES (@srspn_empno, @srspn_cname, @srspn_tel, @srspn_atype, @srspn_orgcd, @srspn_deptcd, @srspn_date, @srspn_pwd); SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn WHERE (srspn_empno = @Select_srspn_empno)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.srspn SET srspn_empno = @srspn_empno, srspn_cname = @srspn_cname, srspn_tel = @srspn_tel, srspn_atype = @srspn_atype, srspn_orgcd = @srspn_orgcd, srspn_deptcd = @srspn_deptcd, srspn_date = @srspn_date, srspn_pwd = @srspn_pwd WHERE (srspn_empno = @Original_srspn_empno) AND (srspn_atype = @Original_srspn_atype) AND (srspn_cname = @Original_srspn_cname) AND (srspn_date = @Original_srspn_date) AND (srspn_deptcd = @Original_srspn_deptcd) AND (srspn_orgcd = @Original_srspn_orgcd) AND (srspn_pwd = @Original_srspn_pwd) AND (srspn_tel = @Original_srspn_tel); SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn WHERE (srspn_empno = @Select_srspn_empno)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.srspn WHERE (srspn_empno = @srspn_empno) AND (srspn_atype = @srspn_atype) AND (srspn_cname = @srspn_cname) AND (srspn_date = @srspn_date) AND (srspn_deptcd = @srspn_deptcd) AND (srspn_id = @srspn_id) AND (srspn_orgcd = @srspn_orgcd) AND (srspn_pwd = @srspn_pwd) AND (srspn_tel = @srspn_tel)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_id", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter6.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_pwd", "srspn_pwd")})});
			this.sqlDataAdapter6.UpdateCommand = this.sqlUpdateCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
