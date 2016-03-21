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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for AdCont.
	/// </summary>
	public class AdCont : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxCustTel;
		protected System.Web.UI.WebControls.TextBox tbxCustTitle;
		protected System.Web.UI.WebControls.TextBox tbxContSignDate;
		protected System.Web.UI.WebControls.DropDownList ddlContTp;
		protected System.Web.UI.WebControls.TextBox tbxContSDate;
		protected System.Web.UI.WebControls.TextBox tbxContEDate;
		protected System.Web.UI.WebControls.DropDownList ddlPubCate;
		protected System.Web.UI.WebControls.TextBox tbxContEmp;
		protected System.Web.UI.WebControls.TextBox tbxAuName;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.TextBox tbxContPubTm;
		protected System.Web.UI.WebControls.TextBox tbxContFreeTm;
		protected System.Web.UI.WebControls.TextBox tbxContTotTm;
		protected System.Web.UI.WebControls.TextBox tbxContTotAmt;
		protected System.Web.UI.WebControls.TextBox tbxContDisc;
		protected System.Web.UI.WebControls.TextBox tbxContPaidAmt;
		protected System.Web.UI.WebControls.TextBox tbxIrName;
		protected System.Web.UI.WebControls.TextBox tbxIrTel;
		protected System.Web.UI.WebControls.TextBox tbxIrAddr;
		protected System.Web.UI.WebControls.TextBox tbxIrZip;
		protected System.Web.UI.WebControls.TextBox tbxCCont;
		protected System.Web.UI.WebControls.TextBox tbxCsDate;
		protected System.Web.UI.WebControls.TextBox tbxAdRemark;
		protected System.Web.UI.WebControls.TextBox tbxPdCont;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.TextBox tbxIrCell;
		protected System.Web.UI.WebControls.TextBox tbxIrEmail;
		protected System.Web.UI.WebControls.TextBox tbxIrFax;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Button btnRefresh;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidcond;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Button btnRefIM;
		protected System.Web.UI.WebControls.Button btnRefAdr;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.Button btnRefBk;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.WebControls.Button btnRefFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidInvMfrCount;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnSave;
		//private static int lc;
	
		public AdCont()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				string old_contno = "";
				string custno = "";
				if (Request.QueryString["old_contno"] != null && Request.QueryString["old_contno"] != "")
				{
					old_contno = Request.QueryString["old_contno"];
				}
				else
				{
					Response.Write("無法帶入合約編號");
					return;
					//無法帶入合約編號
				}

				if (Request.QueryString["custno"] != null && Request.QueryString["custno"] != "")
				{
					custno = Request.QueryString["custno"];
				}
				else
				{
					Response.Write("無法帶入客戶編號");
					return;
					//無法帶入客戶編號
				}

				LoadHistoryCont(custno, old_contno);
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
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT im_imid, im_fgitri, im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbt" +
				"i, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp FROM i" +
				"nvmfr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = @"SELECT c4_freebk.fbk_syscd, c4_freebk.fbk_contno, c4_freebk.fbk_fbkitem, c4_freebk.fbk_sdate, c4_freebk.fbk_edate, c4_freebk.fbk_bkcd, book.bk_nm, c4_ramt.ma_oritem, c4_or.or_inm, c4_or.or_nm, c4_or.or_fgmosea, book.bk_bkcd, c4_or.or_contno, c4_or.or_oritem, c4_or.or_syscd, c4_ramt.ma_contno, c4_ramt.ma_fbkitem, c4_ramt.ma_syscd, c4_freebk.fbk_fbkid, c4_ramt.ma_pubmnt, c4_ramt.ma_unpubmnt FROM c4_freebk INNER JOIN c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN c4_ramt ON c4_freebk.fbk_syscd = c4_ramt.ma_syscd AND c4_freebk.fbk_contno = c4_ramt.ma_contno AND c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem AND c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN book ON c4_freebk.fbk_bkcd = book.bk_bkcd";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT adr_adrid, adr_costctr, adr_syscd, adr_contno, adr_date, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urlcate, adr_txtadcont, adr_txtadcontnm, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginved, adr_fginvself, adr_projno FROM c4_adr";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_imid", "im_imid"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri"),
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_jbti", "im_jbti"),
																																																				new System.Data.Common.DataColumnMapping("im_zip", "im_zip"),
																																																				new System.Data.Common.DataColumnMapping("im_addr", "im_addr"),
																																																				new System.Data.Common.DataColumnMapping("im_tel", "im_tel"),
																																																				new System.Data.Common.DataColumnMapping("im_fax", "im_fax"),
																																																				new System.Data.Common.DataColumnMapping("im_cell", "im_cell"),
																																																				new System.Data.Common.DataColumnMapping("im_email", "im_email"),
																																																				new System.Data.Common.DataColumnMapping("im_invcd", "im_invcd"),
																																																				new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp")})});
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_orgisyscd", "cust_orgisyscd"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubcate", "cont_pubcate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_ccont", "cont_ccont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_csdate", "cont_csdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_atp", "cont_atp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_matp", "cont_matp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irnm", "cont_irnm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_iraddr", "cont_iraddr"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irzip", "cont_irzip"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irtel", "cont_irtel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irfax", "cont_irfax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_ircell", "cont_ircell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_iremail", "cont_iremail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adremark", "cont_adremark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pdcont", "cont_pdcont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_invcd", "cont_invcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_taxtp", "cont_taxtp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgitri", "cont_fgitri"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce")})});
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_freebk", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("fbk_syscd", "fbk_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_contno", "fbk_contno"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_fbkitem", "fbk_fbkitem"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_sdate", "fbk_sdate"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_edate", "fbk_edate"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_bkcd", "fbk_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				   new System.Data.Common.DataColumnMapping("ma_oritem", "ma_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				   new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("ma_contno", "ma_contno"),
																																																				   new System.Data.Common.DataColumnMapping("ma_fbkitem", "ma_fbkitem"),
																																																				   new System.Data.Common.DataColumnMapping("ma_syscd", "ma_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_fbkid", "fbk_fbkid"),
																																																				   new System.Data.Common.DataColumnMapping("ma_pubmnt", "ma_pubmnt"),
																																																				   new System.Data.Common.DataColumnMapping("ma_unpubmnt", "ma_unpubmnt")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_adr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("adr_adrid", "adr_adrid"),
																																																				new System.Data.Common.DataColumnMapping("adr_costctr", "adr_costctr"),
																																																				new System.Data.Common.DataColumnMapping("adr_syscd", "adr_syscd"),
																																																				new System.Data.Common.DataColumnMapping("adr_contno", "adr_contno"),
																																																				new System.Data.Common.DataColumnMapping("adr_date", "adr_date"),
																																																				new System.Data.Common.DataColumnMapping("adr_seq", "adr_seq"),
																																																				new System.Data.Common.DataColumnMapping("adr_invamt", "adr_invamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_adcate", "adr_adcate"),
																																																				new System.Data.Common.DataColumnMapping("adr_keyword", "adr_keyword"),
																																																				new System.Data.Common.DataColumnMapping("adr_alttext", "adr_alttext"),
																																																				new System.Data.Common.DataColumnMapping("adr_imgurl", "adr_imgurl"),
																																																				new System.Data.Common.DataColumnMapping("adr_drafttp", "adr_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("adr_navurl", "adr_navurl"),
																																																				new System.Data.Common.DataColumnMapping("adr_urlcate", "adr_urlcate"),
																																																				new System.Data.Common.DataColumnMapping("adr_txtadcont", "adr_txtadcont"),
																																																				new System.Data.Common.DataColumnMapping("adr_txtadcontnm", "adr_txtadcontnm"),
																																																				new System.Data.Common.DataColumnMapping("adr_impr", "adr_impr"),
																																																				new System.Data.Common.DataColumnMapping("adr_fgfixad", "adr_fgfixad"),
																																																				new System.Data.Common.DataColumnMapping("adr_fggot", "adr_fggot"),
																																																				new System.Data.Common.DataColumnMapping("adr_adamt", "adr_adamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_desamt", "adr_desamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_chgamt", "adr_chgamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_remark", "adr_remark"),
																																																				new System.Data.Common.DataColumnMapping("adr_fginved", "adr_fginved"),
																																																				new System.Data.Common.DataColumnMapping("adr_fginvself", "adr_fginvself"),
																																																				new System.Data.Common.DataColumnMapping("adr_projno", "adr_projno")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_custno, cont_conttp, cont_bkcd, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_tottm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_irnm, cont_iraddr, cont_irzip, cont_irtel, cont_irfax, cont_ircell, cont_iremail, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_invcd, cont_taxtp, cont_fgitri, cont_fgpayonce FROM dbo.c4_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.cust.cust_custid, dbo.cust.cust_custno, dbo.cust.cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_mfrno, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.cust.cust_cell, dbo.cust.cust_email, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.cust.cust_itpcd, dbo.cust.cust_btpcd, dbo.cust.cust_rtpcd, dbo.cust.cust_oldcustno, dbo.cust.cust_orgisyscd, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_inm, dbo.mfr.mfr_iaddr, dbo.mfr.mfr_izip, dbo.mfr.mfr_respnm, dbo.mfr.mfr_respjbti, dbo.mfr.mfr_tel, dbo.mfr.mfr_fax, dbo.mfr.mfr_regdate, dbo.mfr.mfr_mfrno FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.cust.cust_custno = @cust_custno)";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//每當進到這個Page時，該準備一些基本的資料
		private void InitialData()
		{
//			DataSet ds = new DataSet();
//			this.sqlDataAdapter1.Fill(ds, "CONT");
//			DataView dv = ds.Tables["CONT"].DefaultView;
			Session.Timeout = 540;
			DataView dv = (DataView)Session["QDV"];
			int i = Int32.Parse(Request.QueryString["SelectedCust"]);

			this.tbxMfrName.Text = dv[i]["mfr_inm"].ToString().Trim();
			this.tbxAuCell.Text = "";
			this.tbxAuEmail.Text = "";
			this.tbxAuFax.Text = "";
			this.tbxAuTel.Text = "";
			this.tbxContNo.Text = this.getNewContNo();
			this.tbxContDisc.Text = "0";
			this.tbxContEDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContEmp.Text = "";
			this.tbxContFreeTm.Text = "0";
			this.tbxContPaidAmt.Text = "0";
			this.tbxContPubTm.Text = "0";
			this.tbxContSDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContSignDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContTotAmt.Text = "0";
			this.tbxContTotTm.Text = "0";
			this.tbxCustName.Text = dv[i]["cust_nm"].ToString().Trim();
			this.tbxCustTel.Text = dv[i]["cust_tel"].ToString().Trim();
			this.tbxCustTitle.Text = dv[i]["cust_jbti"].ToString().Trim();
			this.tbxIrAddr.Text = "";
			this.tbxIrName.Text = "";
			this.tbxIrTel.Text = "";
			this.tbxIrZip.Text = "";
			this.tbxIrCell.Text = "";
			this.tbxIrFax.Text = "";
			this.tbxIrEmail.Text = "";
			this.tbxCCont.Text = "";
			this.tbxCsDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxPdCont.Text = "";
			this.tbxAdRemark.Text = "";
		}

		//載入歷史訂單
		private void LoadHistoryCont(string custno, string contno)
		{
			//從歷史合約中載入資料
//			DataView dv = (DataView)Session["QDV"];
//			int i = Int32.Parse(Request.QueryString["SelectedCust"]);
//
//			DataView hcdv = (DataView)Session["HCDV"];
//			int j = Int32.Parse(Request.QueryString["SelectedHisCont"]);
			if (!LoadCustMfrData(custno))
			{
				Response.Write("無客戶資料？！");
				return;
			}

			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "OLD_CONT");
			DataView dv = ds.Tables["OLD_CONT"].DefaultView;
			dv.RowFilter = "cont_contno = '"+ contno +"'";

			if (dv.Count != 1)
			{
				Response.Write("載入合約錯誤，無此歷史合約？");
				return;
			}


			//這邊還沒正式完成，要在check從歷史資料中抓出來的各個帶入欄位
			//this.tbxMfrName.Text = dv[i]["mfr_inm"].ToString();
			this.tbxAuCell.Text = dv[0]["cont_aucell"].ToString();
			this.tbxAuEmail.Text = dv[0]["cont_auemail"].ToString();
			this.tbxAuFax.Text = dv[0]["cont_aufax"].ToString();
			this.tbxAuTel.Text = dv[0]["cont_autel"].ToString();
			//this.tbxContNo.Text = this.getNewContNo();
			this.tbxContDisc.Text = "0";
			this.tbxContEDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContEmp.Text = "";
			this.tbxContFreeTm.Text = "0";
			this.tbxContPaidAmt.Text = "0";
			this.tbxContPubTm.Text = "0";
			this.tbxContSDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContSignDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContTotAmt.Text = "0";
			this.tbxContTotTm.Text = "0";
			//this.tbxCustName.Text = dv[i]["cust_nm"].ToString();
			//this.tbxCustTel.Text = dv[i]["cust_tel"].ToString();
			//this.tbxCustTitle.Text = dv[i]["cust_jbti"].ToString();
			this.tbxIrAddr.Text = dv[0]["cont_iraddr"].ToString();
			this.tbxIrName.Text = dv[0]["cont_irnm"].ToString();
			this.tbxIrTel.Text = dv[0]["cont_irtel"].ToString();
			this.tbxIrZip.Text = dv[0]["cont_irzip"].ToString();
			this.tbxIrCell.Text = dv[0]["cont_ircell"].ToString();
			this.tbxIrFax.Text = dv[0]["irfax"].ToString();
			this.tbxIrEmail.Text = dv[0]["cont_iremail"].ToString();
			this.tbxCCont.Text = dv[0]["cont_ccont"].ToString();
			this.tbxCsDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxPdCont.Text = dv[0]["cont_pdcont"].ToString();
			this.tbxAdRemark.Text = dv[0]["cont_adremark"].ToString();
		}

		private bool LoadCustMfrData(string custno)
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.SelectCommand.Parameters["@cust_custno"].Value = custno;
			this.sqlDataAdapter2.Fill(ds, "CUSTMFR");
			DataView dv = ds.Tables["CUSTMFR"].DefaultView;

			if (dv.Count <= 0)
			{
				return false;
			}

			this.tbxMfrName.Text = dv[0]["mfr_inm"].ToString();
			this.tbxCustName.Text = dv[0]["cust_nm"].ToString();
			this.tbxCustTel.Text = dv[0]["cust_tel"].ToString();
			this.tbxCustTitle.Text = dv[0]["cust_jbti"].ToString();
			return true;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
/*			DataView dv = (DataView)Session["QDV"];
			int i = Int32.Parse(Request.QueryString["SelectedCust"]);

//			string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
//			DataSet ds = new DataSet();
//			this.sqlDataAdapter2.Fill(ds, "maxcontno");
//			DataView dvmax = ds.Tables["maxcontno"].DefaultView;
//
//			if (dvmax.Count > 0 && dvmax[0]["C1"].ToString() != "0")
//			{
//				strAssignedContNo = Convert.ToString(Convert.ToInt32(dvmax[0]["MaxContNo"])+1);
//			}
//			else
//			{
//				strAssignedContNo += "0000";
//			}																								

			this.sqlInsertCommand1.Parameters["@cont_fgitri"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_syscd"].Value = "C4";
			this.sqlInsertCommand1.Parameters["@cont_contno"].Value = this.tbxContNo.Text;
			this.sqlInsertCommand1.Parameters["@cont_custno"].Value = dv[i]["cust_custno"].ToString();
			this.sqlInsertCommand1.Parameters["@cont_conttp"].Value = this.ddlContTp.SelectedItem.Value;
			this.sqlInsertCommand1.Parameters["@cont_bkcd"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_signdate"].Value = this.tbxContSignDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_sdate"].Value = this.tbxContSDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_edate"].Value = this.tbxContEDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_empno"].Value = this.tbxContEmp.Text;//現在用姓名，事實上應該用工號才對
			this.sqlInsertCommand1.Parameters["@cont_mfrno"].Value = dv[i]["mfr_mfrno"].ToString();
			this.sqlInsertCommand1.Parameters["@cont_pubcate"].Value = this.ddlPubCate.SelectedItem.Value;
			this.sqlInsertCommand1.Parameters["@cont_aunm"].Value = this.tbxAuName.Text;
			this.sqlInsertCommand1.Parameters["@cont_autel"].Value = this.tbxAuTel.Text;
			this.sqlInsertCommand1.Parameters["@cont_aufax"].Value = this.tbxAuFax.Text;
			this.sqlInsertCommand1.Parameters["@cont_aucell"].Value = this.tbxAuCell.Text;
			this.sqlInsertCommand1.Parameters["@cont_auemail"].Value = this.tbxAuEmail.Text;

			this.sqlInsertCommand1.Parameters["@cont_disc"].Value = this.tbxContDisc.Text;
			this.sqlInsertCommand1.Parameters["@cont_freetm"].Value = this.tbxContFreeTm.Text;
			this.sqlInsertCommand1.Parameters["@cont_tottm"].Value = this.tbxContTotTm.Text;
			this.sqlInsertCommand1.Parameters["@cont_pubtm"].Value = this.tbxContPubTm.Text;
			this.sqlInsertCommand1.Parameters["@cont_resttm"].Value = 0;
			this.sqlInsertCommand1.Parameters["@cont_totamt"].Value = this.tbxContTotAmt.Text;
			this.sqlInsertCommand1.Parameters["@cont_paidamt"].Value = this.tbxContPaidAmt.Text;
			this.sqlInsertCommand1.Parameters["@cont_restamt"].Value = 0;

			this.sqlInsertCommand1.Parameters["@cont_ccont"].Value = this.tbxCCont.Text;
			this.sqlInsertCommand1.Parameters["@cont_csdate"].Value = this.tbxCsDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_atp"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_matp"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_irnm"].Value = this.tbxIrName.Text;
			this.sqlInsertCommand1.Parameters["@cont_iraddr"].Value = this.tbxIrAddr.Text;
			this.sqlInsertCommand1.Parameters["@cont_irzip"].Value = this.tbxIrZip.Text;
			this.sqlInsertCommand1.Parameters["@cont_irtel"].Value = this.tbxIrTel.Text;
			this.sqlInsertCommand1.Parameters["@cont_irfax"].Value = this.tbxIrFax.Text;
			this.sqlInsertCommand1.Parameters["@cont_ircell"].Value = this.tbxIrCell.Text;
			this.sqlInsertCommand1.Parameters["@cont_iremail"].Value = this.tbxIrEmail.Text;
			this.sqlInsertCommand1.Parameters["@cont_fgclosed"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_adremark"].Value = this.tbxAdRemark.Text;
			this.sqlInsertCommand1.Parameters["@cont_pdcont"].Value = this.tbxPdCont.Text;
			this.sqlInsertCommand1.Parameters["@cont_moddate"].Value = System.DateTime.Today.ToString("yyyyMMdd");
			this.sqlInsertCommand1.Parameters["@cont_invcd"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_taxtp"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_xmldata"].Value = "<xmldata></xmldata>";

			bool InsAdContSuccess = false;
			this.sqlInsertCommand1.Connection.Open();
			try
			{
				this.sqlInsertCommand1.ExecuteNonQuery();
				InsAdContSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				InsAdContSuccess = false;
			}
			this.sqlInsertCommand1.Connection.Close();
			if (InsAdContSuccess)
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"合約編號: " + this.tbxContNo.Text + " 新增成功\");</script>";
				Page.Controls.Add(litAlert);
			}
			else
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"合約編號: " + this.tbxContNo.Text + " 新增失敗\");</script>";
				Page.Controls.Add(litAlert);
			}

			GenIA_IAD();
			*/
		}

		private void btnAddAdr_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("AdManagement.aspx?ContNo=" + this.tbxContNo.Text);
			//想想要怎麼給定AdScope
		}

		private string getNewContNo()
		{
			string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.Fill(ds, "maxcontno");
			DataView dvmax = ds.Tables["maxcontno"].DefaultView;

			if (dvmax.Count > 0 && dvmax[0]["C1"].ToString() != "0")
			{
				strAssignedContNo = Convert.ToString(Convert.ToInt32(dvmax[0]["MaxContNo"])+1);
			}
			else
			{
				strAssignedContNo += "0000";
			}
			return strAssignedContNo;																					
		}

		private void btnAddInvMfr_Click(object sender, System.EventArgs e)
		{
//			LiteralControl litOpenInvMfr = new LiteralControl();
//			litOpenInvMfr.Text = "<script language=javascript>"+
//				"doOpenInvMfr();"+
//				"</script>";
//			Page.Controls.Add(litOpenInvMfr);
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			//先mark掉，因為postback就會整理了
//			BindMfrInv();
//			BindAdr();
//			BindBk();
		}

		//發票廠商資料
		private void BindMfrInv()
		{
			DataSet ds = new DataSet();
			sqlDataAdapter3.Fill(ds, "IM");
			DataView dv = ds.Tables["IM"].DefaultView;

			//系統代號、合約編號
			dv.RowFilter = "im_syscd='C4' AND im_contno='" + tbxContNo.Text + "'";
			this.hidInvMfrCount.Value = dv.Count.ToString();

			DataList1.DataSource = dv;
			DataList1.DataBind();
			if (dv.Count>0)
			{
				DataList1.Visible = true;
			}
			else
			{
				DataList1.Visible = false;
			}
		}

		private void BindAdr()
		{
			DataSet ds = new DataSet();
			sqlDataAdapter4.Fill(ds, "ADR");
			DataView dv = ds.Tables["ADR"].DefaultView;
			//合約編號，c4_adr只有c4在用吧....
			dv.RowFilter = "adr_contno='" + tbxContNo.Text + "'";
			DataGrid2.Visible = false;
			DataGrid2.DataSource = dv;
			DataGrid2.DataBind();
			if (dv.Count>0)
			{
				DataGrid2.Visible = true;
			}
			else
			{
				DataGrid2.Visible = false;
			}
		}

		private void BindBk()
		{
			DataSet ds = new DataSet();
			sqlDataAdapter5.Fill(ds, "FreeBK");
			DataView dv = ds.Tables["FreeBK"].DefaultView;

			//合約編號，c4_freebk只有c4在用吧...
			dv.RowFilter = "fbk_syscd='C4' AND fbk_contno='" + tbxContNo.Text + "'";
			DataGrid1.Visible = false;
			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();

			if (dv.Count>0)
			{
				DataGrid1.Visible = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}
		}

		private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandText = "DELETE FROM c4_adr WHERE adr_adrid=@adr_id";
			cmd.CommandType = CommandType.Text;
			cmd.Connection = this.sqlConnection1;

			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adrid", System.Data.SqlDbType.Int, 4));
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}

		private void GenIA_IAD()
		{
			//填入IAD
//			this.sqlInsCmdIA.Parameters["@iad_iano"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_iaditem"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk1"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk2"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk3"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk4"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_projno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_costctr"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_desc"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_qty"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_unit"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_uprice"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_amt"].Value = "";
//
//			//填入IA
//			//this.sqlInsCmdIA.Parameters["@ia_syscd"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_contno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iasdate"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iasseq"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iaitem"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iano"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_refno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_mfrno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_pyno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_pyseq"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_pyat"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_ivat"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_invno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_invdate"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_fgitri"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rnm"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_raddr"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rzip"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rjbti"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rtel"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_fgnonauto"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_invcd"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_taxtp"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_status"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_cname"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_tel"].Value = "";
//
//			System.Data.SqlClient.SqlTransaction sqlTran = this.sqlInsCmdIAD.Connection.BeginTransaction();
//			bool InsIaIadSuccess = false;
//			try
//			{
//				InsIaIadSuccess = true;
//				sqlTran.Commit();
//			}
//			catch(System.Data.SqlClient.SqlException ex)
//			{
//				InsIaIadSuccess = false;
//				sqlTran.Rollback();
//			}

			//顯示錯誤訊息
			//最好不管成功或失敗都給user回應..
		}
	}
}
