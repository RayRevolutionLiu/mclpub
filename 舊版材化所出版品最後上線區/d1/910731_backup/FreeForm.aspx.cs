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
	/// Summary description for FreeForm.
	/// </summary>
	public class FreeForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblInvoiceid;
		protected System.Web.UI.WebControls.Label lblOrderNo;
		protected System.Web.UI.WebControls.TextBox tbxOrderType1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPreXml;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenOrderNo;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderRes;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxOrderDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenDate;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrderType2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenType1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenRec;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlBookType;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrno;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBook;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblCoName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCoName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCoAddress;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlSpn;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCostctr;
	
		public FreeForm()
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
				//訂購日期
				tbxOrderDate.Value=System.DateTime.Today.ToString("yyyy/MM/dd");
				//訂戶編號
				lblInvoiceid.Text=id;
				hiddenID.Value=id;
				//訂購類別
				hiddenType1.Value=type1;
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "_1_otp");
				DataView dv1 = ds1.Tables["_1_otp"].DefaultView;
				ddlOrderType2.DataSource=dv1;
				dv1.RowFilter="otp_otp1cd='"+type1+"'";
				ddlOrderType2.DataTextField="otp_otp2nm";
				ddlOrderType2.DataValueField="otp_otp2cd";
				ddlOrderType2.DataBind();
				if(type1=="02")
				{
					tbxOrderType1.Text="贈閱";
					lblTitle.Text="贈閱訂單";
				}
				else if(type1=="03")
				{
					tbxOrderType1.Text="推廣";
					lblTitle.Text="推廣訂單";
				}
				//前一筆訂單資料
				DataSet ds2 = new DataSet();
				DataView dv2;
				if(seq!="000")
				{
					this.sqlDataAdapter2.Fill(ds2, "_1_order");
					dv2 = ds2.Tables["_1_order"].DefaultView;
					dv2.RowFilter="o_syscd='C1' and o_custno='"+id+"' and o_otp1cd='"+type1+"' and o_otp1seq='"+seq+"'";
					XmlNode xmlItem;
					XmlDocument xmldoc= new XmlDocument();
					if(dv2.Count>0)
					{
						//						tbxMfrno.Text=dv3[0].Row["o_mfrno"].ToString();
						hiddenPreXml.Value=dv2[0].Row["o_xmldata"].ToString();
						xmldoc.LoadXml(hiddenPreXml.Value);
						xmlItem = xmldoc.SelectSingleNode("/root/收件人資料");
						//收件人資料
						hiddenRec.Value=xmlItem.OuterXml;
					}
				}
				this.sqlDataAdapter2.Fill(ds2, "c1_order");
				dv2 = ds2.Tables["c1_order"].DefaultView;
				dv2.RowFilter="o_syscd='C1' and o_custno='"+id+"' and o_otp1cd='"+type1+"'";
				string str1="";
				string	str2="";
				if(dv2.Count>0)
				{
					str1+=dv2[0].Row["o_syscd"].ToString();
					str1+=dv2[0].Row["o_custno"].ToString();
					str1+=dv2[0].Row["o_otp1cd"].ToString();
					if(type1=="02")
						str2=Convert.ToString(Convert.ToInt32(dv2[0].Row["cust_otp1seq2"])+1);
					else if(type1=="03")
						str2=Convert.ToString(Convert.ToInt32(dv2[0].Row["cust_otp1seq3"])+1);
					int j=3-str2.Length;
					for(int i=0; i<j; i++)
						str2="0"+str2;
				}
				else
				{
					str1=str1+"C1"+id+type1;
					str2="001";
				}
//				string str2=((int)(dv2.Count+1)).ToString();
				//訂單流水號
				lblOrderNo.Text=str1+str2;
				hiddenOrderNo.Value=str1+str2;
				//書籍類別
				DataSet ds3= new DataSet("書籍資料");
				this.sqlDataAdapter3.Fill(ds3, "書籍明細");
				hiddenBook.Value=ds3.GetXml();

				ds3= new DataSet("書籍資料");
				this.sqlDataAdapter3.Fill(ds3, "c1_obtp");
				DataView dv3=ds3.Tables["c1_obtp"].DefaultView;
				ddlBookType.DataSource=dv3;
				dv3.RowFilter="obtp_otp1cd='"+type1+"' and fgitri=''";
				ddlBookType.DataTextField="obtp_obtpnm";
				ddlBookType.DataValueField="obtp_obtpcd";
				//				ddlBookType.DataValueField="nostr";
				ddlBookType.DataBind();
				//訂單來源
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "c1_ores");
				ddlOrderRes.DataSource=ds4;
				ddlOrderRes.DataTextField="ores_oresnm";
				ddlOrderRes.DataValueField="ores_orescd";
				ddlOrderRes.DataBind();
				//統一編號
				DataSet ds5= new DataSet();
				this.sqlDataAdapter5.Fill(ds5, "c1_cust");
				DataView dv5=ds5.Tables["c1_cust"].DefaultView;
				dv5.RowFilter="cust_custno = '"+id+"'";
				hiddenMfrno.Value=dv5[0].Row["cust_mfrno"].ToString();
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT dbo.c1_cust.cust_custno, dbo.c1_cust.cust_nm, dbo.c1_cust.cust_tel, dbo.c1" +
				"_cust.cust_mfrno, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_iaddr FROM dbo" +
				".c1_cust INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
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
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.c1_obtp.obtp_obtpid, dbo.c1_obtp.obtp_otp1cd, dbo.c1_obtp.obtp_obtpcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.proj.proj_fgitri AS fgitri, dbo.proj.proj_bkcd, dbo.proj.proj_syscd FROM dbo.c1_obtp INNER JOIN dbo.proj ON dbo.c1_obtp.obtp_obtpcd = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C1')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c1_order.o_oid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c1_order.o_inm, dbo.c1_order.o_ijbti, dbo.c1_order.o_iaddr, dbo.c1_order.o_izip, dbo.c1_order.o_itel, dbo.c1_order.o_ifax, dbo.c1_order.o_icell, dbo.c1_order.o_iemail, dbo.c1_order.o_pytpcd, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_date, dbo.c1_order.o_moddate, dbo.c1_order.o_oldvdate, dbo.c1_order.o_empno, dbo.c1_order.o_xmldata, dbo.c1_order.o_orescd, dbo.c1_order.o_invcd, dbo.c1_order.o_taxtp, dbo.c1_cust.cust_otp1seq1, dbo.c1_cust.cust_otp1seq2, dbo.c1_cust.cust_otp1seq3, dbo.c1_cust.cust_otp1seq9, dbo.c1_cust.cust_custno FROM dbo.c1_order INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_atype FROM dbo.srspn";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				  new System.Data.Common.DataColumnMapping("cust_otp1seq9", "cust_otp1seq9"),
																																																				  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_otp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("otp_otpid", "otp_otpid"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm")})});
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
