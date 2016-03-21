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
	/// Summary description for order1.
	/// </summary>
	public class OrderForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton imbCal2;
		protected System.Web.UI.WebControls.ImageButton imbCal3;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderType2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxOrderDate;
		protected System.Web.UI.WebControls.TextBox tbxMfrno;
		protected System.Web.UI.WebControls.TextBox tbxInvoiceName;
		protected System.Web.UI.WebControls.TextBox tbxInvoiceJob;
		protected System.Web.UI.WebControls.TextBox tbxTel;
		protected System.Web.UI.WebControls.TextBox tbxFax;
		protected System.Web.UI.WebControls.TextBox tbxCell;
		protected System.Web.UI.WebControls.TextBox tbxPostCode;
		protected System.Web.UI.WebControls.TextBox tbxAddress;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.TextBox tbxOrderType1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.TextBox tbxEmail;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenRec;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenSeq;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCostctr;
		protected System.Web.UI.WebControls.Label lblCust;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlBookType;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenDate;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenFgoi;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenFgoe;
		protected System.Web.UI.WebControls.RadioButtonList rblInvcd;
		protected System.Web.UI.WebControls.RadioButtonList rblTaxtp;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderRes;
		protected System.Data.SqlClient.SqlConnection sqlConnection2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlPayType;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Web.UI.WebControls.Label lblOrderNo;
		protected System.Web.UI.WebControls.Label lblInvoiceid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenOrderNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPreXml;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBook;
		protected System.Web.UI.HtmlControls.HtmlTextArea text1;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblCoName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCoName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCoAddr;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton rblJob1;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton rblJob2;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton rblJob3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenProj;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlSpn;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlCust;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenType1;
	
		public OrderForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires=0;
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//
				// Evals true first time browser hits the page
				//
				string id=Context.Request.QueryString["id"];
				string type1=Context.Request.QueryString["type1"];
				string seq=Context.Request.QueryString["seq"];
				//付款方式
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "_pytp");
				ddlPayType.DataSource=ds;
				ddlPayType.DataTextField="pytp_nm";
				ddlPayType.DataValueField="pytp_pytpcd";
				ddlPayType.DataBind();
				//訂戶編號
				lblInvoiceid.Text=id;
				hiddenID.Value=id;
				//訂購類別
				hiddenType1.Value=type1;
				if(type1=="01")
				{
					DataSet ds2 = new DataSet();
					this.sqlDataAdapter2.Fill(ds2, "_1_otp");
					DataView dv2 = ds2.Tables["_1_otp"].DefaultView;
					ddlOrderType2.DataSource=dv2;
					dv2.RowFilter="otp_otp1cd='"+type1+"'";
					ddlOrderType2.DataTextField="otp_otp2nm";
					ddlOrderType2.DataValueField="otp_otp2cd";
					ddlOrderType2.DataBind();
					tbxOrderType1.Text="訂閱";
					lblTitle.Text="訂閱訂單";
					lblMessage.Text="<<請注意!! 此為訂閱訂單, 不接受純零售訂單>>";
				}
				else if(type1=="09")
				{
					tbxOrderType1.Text="零售";
					ddlOrderType2.Visible=false;
					lblTitle.Text="零售訂單";
				}
				//前一筆訂單資料
				DataSet ds3 = new DataSet();
				DataView dv3;
				if(seq!="000")
				{
					this.sqlDataAdapter3.Fill(ds3, "c1_order");
					dv3 = ds3.Tables["c1_order"].DefaultView;
					dv3.RowFilter="o_syscd='C1' and o_custno='"+id+"' and o_otp1cd='"+type1+"' and o_otp1seq='"+seq+"'";
					XmlNode xmlItem;
					XmlDocument xmldoc= new XmlDocument();
					if(dv3.Count>0)
					{
//						tbxMfrno.Text=dv3[0].Row["o_mfrno"].ToString();
						tbxInvoiceName.Text=dv3[0].Row["o_inm"].ToString().Trim();
						tbxInvoiceJob.Text=dv3[0].Row["o_ijbti"].ToString().Trim();
						tbxTel.Text=dv3[0].Row["o_itel"].ToString().Trim();
						tbxFax.Text=dv3[0].Row["o_ifax"].ToString().Trim();
						tbxCell.Text=dv3[0].Row["o_icell"].ToString().Trim();
						tbxEmail.Text=dv3[0].Row["o_iemail"].ToString().Trim();
						tbxPostCode.Text=dv3[0].Row["o_izip"].ToString().Trim();
						tbxAddress.Text=dv3[0].Row["o_iaddr"].ToString().Trim();
						hiddenPreXml.Value=dv3[0].Row["o_xmldata"].ToString().Trim();
						xmldoc.LoadXml(hiddenPreXml.Value);
						xmlItem = xmldoc.SelectSingleNode("/root/收件人資料");
						//收件人資料
						hiddenRec.Value=xmlItem.OuterXml;
					}
				}
				this.sqlDataAdapter3.Fill(ds3, "c1_order");
				dv3 = ds3.Tables["c1_order"].DefaultView;
				dv3.RowFilter="o_syscd='C1' and o_custno='"+id+"' and o_otp1cd='"+type1+"'";
				string str1="";
				string	str2="";
				if(dv3.Count>0)
				{
					str1+=dv3[0].Row["o_syscd"].ToString();
					str1+=dv3[0].Row["o_custno"].ToString();
					str1+=dv3[0].Row["o_otp1cd"].ToString();
					if(type1=="01")
						str2=Convert.ToString(Convert.ToInt32(dv3[0].Row["cust_otp1seq1"])+1);
					else if(type1=="09")
						str2=Convert.ToString(Convert.ToInt32(dv3[0].Row["cust_otp1seq9"])+1);
					int j=3-str2.Length;
					for(int i=0; i<j; i++)
						str2="0"+str2;
				}
				else
				{
					str1=str1+"C1"+id+type1;
					str2="001";
				}
//				string str2=((int)(dv3.Count+1)).ToString();
				//訂單流水號
				lblOrderNo.Text=str1+str2;
				hiddenOrderNo.Value=str1+str2;
				//收件人資料
//				DataSet ds4 = new DataSet("收件人資料");
//				this.sqlSelectCommand4.CommandText += " where or_syscd='C1' and or_custno='"+id+
//													"' and or_otp1cd='"+type1+"' and or_otp1seq='"+seq+"'";
//				this.sqlDataAdapter4.Fill(ds4, "收件人明細");
//				DataView dv4=ds4.Tables["收件人明細"].DefaultView;
//				if (dv4.Count>0)
//					hiddenRec.Value=ds4.GetXml();
				//書籍類別
				DataSet ds5= new DataSet("書籍資料");
				this.sqlDataAdapter5.Fill(ds5, "書籍明細");
				hiddenBook.Value=ds5.GetXml();
//				text1.Value=hiddenBook.Value;
				ds5= new DataSet();
				this.sqlDataAdapter5.Fill(ds5, "c1_obtp");
				DataView dv5=ds5.Tables["c1_obtp"].DefaultView;
				dv5.RowFilter="obtp_otp1cd='"+type1+"' and fgitri=''";
				ddlBookType.DataSource=dv5;
				ddlBookType.DataTextField="obtp_obtpnm";
				ddlBookType.DataValueField="obtp_obtpcd";
//				ddlBookType.DataValueField="nostr";
				ddlBookType.DataBind();
				//新舊訂戶註記
				DataSet ds6= new DataSet();
				this.sqlDataAdapter6.Fill(ds6, "c1_cust");
				DataView dv6=ds6.Tables["c1_cust"].DefaultView;
				dv6.RowFilter="cust_custno = '"+id+"'";
				tbxMfrno.Text=dv6[0].Row["cust_mfrno"].ToString().Trim();
				lblName.Text=dv6[0].Row["cust_nm"].ToString().Trim();
				lblCoName.Text=dv6[0].Row["mfr_inm"].ToString().Trim();
				hiddenCoName.Value=dv6[0].Row["mfr_inm"].ToString().Trim();
				hiddenCoAddr.Value=dv6[0].Row["mfr_iaddr"].ToString().Trim();
//				Response.Write(dv6[0].Row["mfr_iaddr"].ToString().Trim());
//				Response.Write(hiddenAddress.Value);
				hiddenFgoi.Value=dv6[0].Row["cust_fgoi"].ToString();
				hiddenFgoe.Value=dv6[0].Row["cust_fgoe"].ToString();
				tbxOrderDate.Value=System.DateTime.Today.ToString("yyyy/MM/dd");
				//訂單來源
				DataSet ds7 = new DataSet();
				this.sqlDataAdapter7.Fill(ds7, "c1_ores");
				ddlOrderRes.DataSource=ds7;
				ddlOrderRes.DataTextField="ores_oresnm";
				ddlOrderRes.DataValueField="ores_orescd";
				ddlOrderRes.DataBind();
				//承辦業務員
				DataSet ds8 = new DataSet();
				this.sqlDataAdapter8.Fill(ds8, "srspn");
				DataView dv8=ds8.Tables["srspn"].DefaultView;
				dv8.RowFilter="srspn_atype = 'B' OR srspn_atype = 'C'";
//				dv8.RowFilter="srspn_atype <> 'A'";
				ddlSpn.DataSource=dv8;
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter8 = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlSelectCommand8
			// 
			this.sqlSelectCommand8.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_atype FROM dbo.srspn";
			this.sqlSelectCommand8.Connection = this.sqlConnection2;
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.c1_order.o_oid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c1_order.o_inm, dbo.c1_order.o_ijbti, dbo.c1_order.o_iaddr, dbo.c1_order.o_izip, dbo.c1_order.o_itel, dbo.c1_order.o_ifax, dbo.c1_order.o_icell, dbo.c1_order.o_iemail, dbo.c1_order.o_pytpcd, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_date, dbo.c1_order.o_moddate, dbo.c1_order.o_oldvdate, dbo.c1_order.o_empno, dbo.c1_order.o_xmldata, dbo.c1_order.o_orescd, dbo.c1_order.o_invcd, dbo.c1_order.o_taxtp, dbo.c1_cust.cust_otp1seq1, dbo.c1_cust.cust_otp1seq2, dbo.c1_cust.cust_otp1seq3, dbo.c1_cust.cust_otp1seq9, dbo.c1_cust.cust_custno FROM dbo.c1_order INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno";
			this.sqlSelectCommand3.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp";
			this.sqlSelectCommand2.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp";
			this.sqlSelectCommand1.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = "SELECT ores_oresid, ores_orescd, ores_oresnm FROM dbo.c1_ores";
			this.sqlSelectCommand7.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = @"SELECT dbo.c1_cust.cust_custid, dbo.c1_cust.cust_custno, dbo.c1_cust.cust_fgoi, dbo.c1_cust.cust_fgoe, dbo.c1_cust.cust_mfrno, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_mfrno, dbo.mfr.mfr_iaddr FROM dbo.c1_cust INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand6.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = @"SELECT dbo.c1_obtp.obtp_obtpid, dbo.c1_obtp.obtp_otp1cd, dbo.c1_obtp.obtp_obtpcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.proj.proj_fgitri AS fgitri, dbo.proj.proj_bkcd, dbo.proj.proj_syscd FROM dbo.c1_obtp INNER JOIN dbo.proj ON dbo.c1_obtp.obtp_obtpcd = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C1')";
			this.sqlSelectCommand5.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT or_orid AS 序號, or_nm AS 姓名, or_jbti AS 職稱, or_addr AS 地址, or_zip AS 郵遞區號, " +
				"or_tel AS 電話, or_fax AS 傳真, or_cell AS 手機, or_email AS Email, or_fgmosea AS 海外郵寄" +
				" FROM dbo.c1_or";
			this.sqlSelectCommand4.Connection = this.sqlConnection2;
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoi", "cust_fgoi"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoe", "cust_fgoe"),
																																																				 new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr")})});
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				  new System.Data.Common.DataColumnMapping("o_taxtp", "o_taxtp"),
																																																				  new System.Data.Common.DataColumnMapping("cust_otp1seq1", "cust_otp1seq1"),
																																																				  new System.Data.Common.DataColumnMapping("cust_otp1seq2", "cust_otp1seq2"),
																																																				  new System.Data.Common.DataColumnMapping("cust_otp1seq3", "cust_otp1seq3"),
																																																				  new System.Data.Common.DataColumnMapping("cust_otp1seq9", "cust_otp1seq9")})});
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
																									  new System.Data.Common.DataTableMapping("Table", "pytp", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpid", "pytp_pytpid"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			// 
			// sqlDataAdapter7
			// 
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_ores", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("ores_oresid", "ores_oresid"),
																																																				 new System.Data.Common.DataColumnMapping("ores_orescd", "ores_orescd"),
																																																				 new System.Data.Common.DataColumnMapping("ores_oresnm", "ores_oresnm")})});
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
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("序號", "序號"),
																																																			   new System.Data.Common.DataColumnMapping("姓名", "姓名"),
																																																			   new System.Data.Common.DataColumnMapping("職稱", "職稱"),
																																																			   new System.Data.Common.DataColumnMapping("地址", "地址"),
																																																			   new System.Data.Common.DataColumnMapping("郵遞區號", "郵遞區號"),
																																																			   new System.Data.Common.DataColumnMapping("電話", "電話"),
																																																			   new System.Data.Common.DataColumnMapping("傳真", "傳真"),
																																																			   new System.Data.Common.DataColumnMapping("手機", "手機"),
																																																			   new System.Data.Common.DataColumnMapping("Email", "Email"),
																																																			   new System.Data.Common.DataColumnMapping("海外郵寄", "海外郵寄")})});
			// 
			// sqlDataAdapter8
			// 
			this.sqlDataAdapter8.SelectCommand = this.sqlSelectCommand8;
			this.sqlDataAdapter8.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
