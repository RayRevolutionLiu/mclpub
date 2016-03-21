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
	/// Summary description for ContModify.
	/// </summary>
	public class ContModify : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMfrData;
		protected System.Web.UI.WebControls.Label lblRespData;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblCustData;
		protected System.Web.UI.WebControls.TextBox tbxSignDate;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.DropDownList ddlContTp;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.DropDownList ddlEmpData;
		protected System.Web.UI.WebControls.RadioButtonList rblPayOnce;
		protected System.Web.UI.WebControls.TextBox tbxPubTm;
		protected System.Web.UI.WebControls.TextBox tbxTotAmt;
		protected System.Web.UI.WebControls.TextBox tbxFreeTm;
		protected System.Web.UI.WebControls.TextBox tbxDisc;
		protected System.Web.UI.WebControls.TextBox tbxAuNm;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.ImageButton imbRefIM;
		protected System.Web.UI.WebControls.DataGrid DataGridIM;
		protected System.Web.UI.WebControls.Button btnSaveCont;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.DataGrid DataGridFreeBk;
		protected System.Web.UI.WebControls.ImageButton imbRefFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAInvMfr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAMTP;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAFBKData;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsCont;
		protected System.Data.SqlClient.SqlCommand sqlCmdDelCont;
		protected System.Data.SqlClient.SqlCommand sqlCmdUpdateCont;
		protected System.Web.UI.WebControls.ImageButton imbRefAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdr;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidOldContNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCustNo;
		protected System.Web.UI.WebControls.Label lblDayCount;
		protected System.Web.UI.WebControls.TextBox tbxAdRemark;
		protected System.Web.UI.WebControls.TextBox tbxAdSpRemark;
		protected System.Web.UI.WebControls.Button btnDiscardCont;
		protected System.Web.UI.WebControls.Button btnCloseCont;
		protected System.Web.UI.WebControls.Label lblUnPubTm;
		protected System.Web.UI.WebControls.Label lblUnImgTm;
		protected System.Web.UI.WebControls.TextBox tbxTotUrlTm;
		protected System.Web.UI.WebControls.Label lblUnUrlTm;
		protected System.Web.UI.WebControls.Label lblInvedAmt;
		protected System.Web.UI.WebControls.Label lblPaidAmt;
		protected System.Web.UI.WebControls.Label lblUnInvedAmt;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.TextBox tbxTotImgTm;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidIMCount;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.ImageButton imgRefMisc;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPPub;
		protected System.Web.UI.HtmlControls.HtmlImage imgAddAdr;
		protected System.Web.UI.HtmlControls.HtmlImage imgAddFreeBk;
		protected System.Web.UI.HtmlControls.HtmlImage imgAddIM;
		protected System.Web.UI.HtmlControls.HtmlImage imgMisc;
		protected System.Web.UI.WebControls.Panel pnlMisc;
		protected System.Web.UI.WebControls.Panel pnlIM;
		protected System.Web.UI.WebControls.Panel pnlFreebk;
		protected System.Web.UI.WebControls.Panel pblAdr;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetMaxContNo;
	
		public ContModify()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
			}

			BindDataGridIM();
			BindDataGridFreeBk();
			Bind_dgdAdr();
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

			this.sqlDAInvMfr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaAdr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDAFBKData = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdGetMaxContNo = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelCont = new System.Data.SqlClient.SqlCommand();
			this.sqlDAMTP = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdUpdateCont = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsCont = new System.Data.SqlClient.SqlCommand();
			this.tbxEDate.TextChanged += new System.EventHandler(this.tbxEDate_TextChanged);
			this.imbRefIM.Click += new System.Web.UI.ImageClickEventHandler(this.imbRefIM_Click);
			this.imbRefFreeBk.Click += new System.Web.UI.ImageClickEventHandler(this.imbRefFreeBk_Click);
			this.btnSaveCont.Click += new System.EventHandler(this.btnSaveCont_Click);
			this.btnDiscardCont.Click += new System.EventHandler(this.btnDiscardCont_Click);
			this.btnCloseCont.Click += new System.EventHandler(this.btnCloseCont_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// sqlDAInvMfr
			// 
			this.sqlDAInvMfr.SelectCommand = this.sqlSelectCommand4;
			this.sqlDAInvMfr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
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
																																																			new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri"),
																																																			new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im" +
				"_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd FROM dbo.invmfr" +
				" WHERE (im_syscd = \'C4\')";
			this.sqlSelectCommand4.Connection = this.sqlCnnMRLPPub;
			// 
			// sqlCnnMRLPPub
			// 
			this.sqlCnnMRLPPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaAdr
			// 
			this.sqlDaAdr.SelectCommand = this.sqlSelectCommand7;
			this.sqlDaAdr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "c4_adr", new System.Data.Common.DataColumnMapping[] {
																																																		 new System.Data.Common.DataColumnMapping("adr_syscd", "adr_syscd"),
																																																		 new System.Data.Common.DataColumnMapping("adr_contno", "adr_contno"),
																																																		 new System.Data.Common.DataColumnMapping("adr_sdate", "adr_sdate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_edate", "adr_edate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_seq", "adr_seq"),
																																																		 new System.Data.Common.DataColumnMapping("adr_invamt", "adr_invamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_adcate", "adr_adcate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_keyword", "adr_keyword"),
																																																		 new System.Data.Common.DataColumnMapping("adr_alttext", "adr_alttext"),
																																																		 new System.Data.Common.DataColumnMapping("adr_imgurl", "adr_imgurl"),
																																																		 new System.Data.Common.DataColumnMapping("adr_drafttp", "adr_drafttp"),
																																																		 new System.Data.Common.DataColumnMapping("adr_navurl", "adr_navurl"),
																																																		 new System.Data.Common.DataColumnMapping("adr_impr", "adr_impr"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fgfixad", "adr_fgfixad"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fggot", "adr_fggot"),
																																																		 new System.Data.Common.DataColumnMapping("adr_adamt", "adr_adamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_desamt", "adr_desamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_chgamt", "adr_chgamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_remark", "adr_remark"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fginvself", "adr_fginvself"),
																																																		 new System.Data.Common.DataColumnMapping("adr_projno", "adr_projno"),
																																																		 new System.Data.Common.DataColumnMapping("adr_costctr", "adr_costctr"),
																																																		 new System.Data.Common.DataColumnMapping("adr_imseq", "adr_imseq"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fgact", "adr_fgact"),
																																																		 new System.Data.Common.DataColumnMapping("adr_urltp", "adr_urltp")})});
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = @"SELECT adr_syscd, adr_contno, adr_sdate, adr_edate, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginvself, adr_projno, adr_costctr, adr_imseq, adr_fgact, adr_urltp FROM dbo.c4_adr";
			this.sqlSelectCommand7.Connection = this.sqlCnnMRLPPub;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = @"SELECT dbo.c4_freebk.fbk_syscd, dbo.c4_freebk.fbk_contno, dbo.c4_freebk.fbk_fbkitem, dbo.c4_freebk.fbk_sdate, dbo.c4_freebk.fbk_edate, dbo.c4_freebk.fbk_bkcd, dbo.c4_ramt.ma_oritem, dbo.c4_or.or_inm, dbo.c4_or.or_nm, dbo.c4_or.or_fgmosea, dbo.c4_or.or_contno, dbo.c4_or.or_oritem, dbo.c4_or.or_syscd, dbo.c4_ramt.ma_contno, dbo.c4_ramt.ma_fbkitem, dbo.c4_ramt.ma_syscd, dbo.c4_freebk.fbk_fbkid, dbo.c4_ramt.ma_pubmnt, dbo.c4_ramt.ma_unpubmnt, dbo.c4_ramt.ma_mtpcd, dbo.c4_ramt.ma_raid, dbo.c4_or.or_addr, dbo.freecat.fc_fccd, dbo.freecat.fc_nm FROM dbo.c4_freebk INNER JOIN dbo.c4_or ON dbo.c4_freebk.fbk_syscd = dbo.c4_or.or_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_or.or_contno INNER JOIN dbo.c4_ramt ON dbo.c4_freebk.fbk_syscd = dbo.c4_ramt.ma_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_ramt.ma_contno AND dbo.c4_freebk.fbk_fbkitem = dbo.c4_ramt.ma_fbkitem AND dbo.c4_or.or_oritem = dbo.c4_ramt.ma_oritem INNER JOIN dbo.freecat ON dbo.c4_freebk.fbk_bkcd = dbo.freecat.fc_fccd";
			this.sqlSelectCommand6.Connection = this.sqlCnnMRLPPub;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT mtp_mtpid, mtp_nm AS ddl_text, mtp_mtpcd AS ddl_value FROM dbo.mtp";
			this.sqlSelectCommand5.Connection = this.sqlCnnMRLPPub;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
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
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_ccont", "cont_ccont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_csdate", "cont_csdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_atp", "cont_atp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_matp", "cont_matp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adremark", "cont_adremark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pdcont", "cont_pdcont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adsprem", "cont_adsprem"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totimgtm", "cont_totimgtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_toturltm", "cont_toturltm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_custno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_fgpayonce, cont_fgtemp, cont_fgpubed, cont_modempno, cont_credate, cont_adsprem, cont_fgcancel, cont_totimgtm, cont_toturltm FROM dbo.c4_cont WHERE (cont_contno = @cont_contno)";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPPub;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.cust.cust_custid, dbo.cust.cust_custno, dbo.cust.cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_mfrno, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.cust.cust_cell, dbo.cust.cust_email, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.cust.cust_itpcd, dbo.cust.cust_btpcd, dbo.cust.cust_rtpcd, dbo.cust.cust_oldcustno, dbo.cust.cust_orgisyscd, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_inm, dbo.mfr.mfr_iaddr, dbo.mfr.mfr_izip, dbo.mfr.mfr_respnm, dbo.mfr.mfr_respjbti, dbo.mfr.mfr_tel, dbo.mfr.mfr_fax, dbo.mfr.mfr_regdate, dbo.mfr.mfr_mfrno FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.cust.cust_custno = @cust_custno)";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPPub;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDAFBKData
			// 
			this.sqlDAFBKData.SelectCommand = this.sqlSelectCommand6;
			this.sqlDAFBKData.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "c4_freebk", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("fbk_syscd", "fbk_syscd"),
																																																				new System.Data.Common.DataColumnMapping("fbk_contno", "fbk_contno"),
																																																				new System.Data.Common.DataColumnMapping("fbk_fbkitem", "fbk_fbkitem"),
																																																				new System.Data.Common.DataColumnMapping("fbk_sdate", "fbk_sdate"),
																																																				new System.Data.Common.DataColumnMapping("fbk_edate", "fbk_edate"),
																																																				new System.Data.Common.DataColumnMapping("fbk_bkcd", "fbk_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("ma_oritem", "ma_oritem"),
																																																				new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				new System.Data.Common.DataColumnMapping("ma_contno", "ma_contno"),
																																																				new System.Data.Common.DataColumnMapping("ma_fbkitem", "ma_fbkitem"),
																																																				new System.Data.Common.DataColumnMapping("ma_syscd", "ma_syscd"),
																																																				new System.Data.Common.DataColumnMapping("fbk_fbkid", "fbk_fbkid"),
																																																				new System.Data.Common.DataColumnMapping("ma_pubmnt", "ma_pubmnt"),
																																																				new System.Data.Common.DataColumnMapping("ma_unpubmnt", "ma_unpubmnt"),
																																																				new System.Data.Common.DataColumnMapping("ma_mtpcd", "ma_mtpcd"),
																																																				new System.Data.Common.DataColumnMapping("ma_raid", "ma_raid"),
																																																				new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				new System.Data.Common.DataColumnMapping("fc_fccd", "fc_fccd"),
																																																				new System.Data.Common.DataColumnMapping("fc_nm", "fc_nm")})});
			// 
			// sqlCmdGetMaxContNo
			// 
			this.sqlCmdGetMaxContNo.CommandText = "SELECT MAX(cont_contno) AS MaxContNo FROM dbo.c4_cont WHERE (SUBSTRING(cont_contn" +
				"o, 1, 2) = @thisyear)";
			this.sqlCmdGetMaxContNo.Connection = this.sqlCnnMRLPPub;
			this.sqlCmdGetMaxContNo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@thisyear", System.Data.SqlDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdDelCont
			// 
			this.sqlCmdDelCont.Connection = this.sqlCnnMRLPPub;
			// 
			// sqlDAMTP
			// 
			this.sqlDAMTP.SelectCommand = this.sqlSelectCommand5;
			this.sqlDAMTP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																	  new System.Data.Common.DataColumnMapping("mtp_mtpid", "mtp_mtpid"),
																																																	  new System.Data.Common.DataColumnMapping("ddl_text", "ddl_text"),
																																																	  new System.Data.Common.DataColumnMapping("ddl_value", "ddl_value")})});
			// 
			// sqlCmdUpdateCont
			// 
			this.sqlCmdUpdateCont.CommandText = @"UPDATE dbo.c4_cont SET cont_signdate = @cont_signdate, cont_sdate = @cont_sdate, cont_edate = @cont_edate, cont_empno = @cont_empno, cont_pubcate = @cont_pubcate, cont_aunm = @cont_aunm, cont_autel = @cont_autel, cont_aufax = @cont_aufax, cont_aucell = @cont_aucell, cont_auemail = @cont_auemail, cont_disc = @cont_disc, cont_freetm = @cont_freetm, cont_totimgtm = @cont_totimgtm, cont_toturltm = @cont_toturltm, cont_pubtm = @cont_pubtm, cont_resttm = @cont_resttm, cont_totamt = @cont_totamt, cont_paidamt = @cont_paidamt, cont_restamt = @cont_resamt, cont_ccont = @cont_ccont, cont_csdate = @cont_csdate, cont_atp = @cont_atp, cont_matp = @cont_matp, cont_fgclosed = '0', cont_pdcont = @cont_pdcont, cont_adremark = @cont_adremark, cont_adsprem=@cont_adsprem, cont_moddate = @cont_moddate, cont_fgpayonce = @cont_fgpayonce, cont_fgtemp = @cont_fgtemp, cont_fgpubed = @cont_fgpubed, cont_modempno = @cont_modempno, cont_conttp = @cont_conttp WHERE (cont_contno = @cont_contno)";
			this.sqlCmdUpdateCont.Connection = this.sqlCnnMRLPPub;
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubcate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totimgtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totimgtm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_toturltm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_toturltm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_ccont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_ccont", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_csdate", System.Data.SqlDbType.VarChar, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_csdate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_atp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_atp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_matp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_matp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pdcont", System.Data.SqlDbType.Text, 5000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pdcont", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_adremark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_adremark", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_adsprem", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_adsprem", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgtemp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgtemp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpubed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpubed", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_modempno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_pwd", "srspn_pwd")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT srspn_empno, srspn_id, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn WHERE (srspn_atype = \'B\') OR (" +
				"srspn_atype = \'C\')";
			this.sqlSelectCommand3.Connection = this.sqlCnnMRLPPub;
			// 
			// sqlCmdInsCont
			// 
			this.sqlCmdInsCont.CommandText = @"INSERT INTO dbo.c4_cont (cont_syscd, cont_contno, cont_custno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_totimgtm, cont_toturltm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_fgpayonce, cont_fgtemp, cont_fgpubed, cont_modempno, cont_credate, cont_fgcancel) VALUES ('C4', @cont_contno, @cont_custno, @cont_conttp, '', '', '', @cont_empno, @cont_mfrno, '', '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '', '', '', '1', '0', @cont_modempno, @cont_credate, '0')";
			this.sqlCmdInsCont.Connection = this.sqlCnnMRLPPub;
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_credate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		//從資料庫中找出目前最大的合約編號
		private string GetMaxContNo()
		{
			string strReturn = "0";
			int YY = DateTime.Today.Year - 1911;
			this.sqlCmdGetMaxContNo.Parameters["@thisyear"].Value = YY.ToString();
			this.sqlCmdGetMaxContNo.Connection.Open();
			string tmp = "";

			try
			{
				tmp = this.sqlCmdGetMaxContNo.ExecuteScalar().ToString();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write(ex.Message);
			}
			this.sqlCmdGetMaxContNo.Connection.Close();

			if (tmp!="")
			{
				strReturn = tmp;
			}
			else
			{
				strReturn = YY.ToString()+ "0000";
			}
			return strReturn;
		}

		//填入初始資料
		private void InitData()
		{
			BindDDLEmpData();

			string mod_contno = "";
			string custno = "";
			if (Request.QueryString["mod_contno"] != null && Request.QueryString["mod_contno"] != "")
			{
				mod_contno = Request.QueryString["mod_contno"];
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

			this.hidOldContNo.Value = "999999";
			this.hidCustNo.Value = custno;

			LoadCustMfrData(custno);
			LoadHistoryCont(mod_contno);
		}

		//連結業務員資料
		private void BindDDLEmpData()
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter3.Fill(ds, "PUBEMP");
			DataView dv = ds.Tables["PUBEMP"].DefaultView;
			if (dv.Count <= 0)
			{
				Response.Write("業務員資料產生錯誤");
				return;
			}

			this.ddlEmpData.DataTextField = "srspn_cname";
			this.ddlEmpData.DataValueField = "srspn_empno";
			this.ddlEmpData.DataSource = dv;
			this.ddlEmpData.DataBind();
			
			//string whoami = "900103";//找AD認證的工號
			//找AD認證的工號
			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			int foundindex = -1;
			for (int i=0; i<dv.Count; i++)
			{
				if (whoami==dv[i]["srspn_empno"].ToString().Trim())
				{
					foundindex = i;
					break;
				}
			}

			if (foundindex >= 0)
				this.ddlEmpData.SelectedIndex = foundindex;
			else
				this.ddlEmpData.Items.FindByValue("800443 ").Selected = true;//七碼
			//this.ddlEmpData.SelectedIndex = 2; //如果通通找不到就預設用康靜怡
		}

		//載入客戶資料
		private void LoadCustMfrData(string CustNo)
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.SelectCommand.Parameters["@cust_custno"].Value = CustNo;
			this.sqlDataAdapter1.Fill(ds, "CUSTMFR");
			DataView dv = ds.Tables["CUSTMFR"].DefaultView;

			if (dv.Count != 1)
			{
				Response.Write("客戶廠商資料錯誤？！");
				return ;
			}

			this.lblMfrData.Text = dv[0]["mfr_inm"].ToString().Trim();
			this.lblMfrNo.Text = dv[0]["mfr_mfrno"].ToString().Trim();
			this.lblRespData.Text = dv[0]["mfr_respnm"].ToString().Trim() + "(" + dv[0]["mfr_respjbti"].ToString().Trim() + ")";
			this.lblCustData.Text = dv[0]["cust_nm"].ToString().Trim();
			this.lblCustNo.Text = dv[0]["cust_custno"].ToString().Trim();
			this.lblMfrTel.Text = dv[0]["mfr_tel"].ToString().Trim() + "(Fax: " + dv[0]["mfr_fax"].ToString().Trim() + ")";
			return;
		}

		//載入歷史資料
		private void LoadHistoryCont(string ContNo)
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.SelectCommand.Parameters["@cont_contno"].Value = ContNo;
			this.sqlDataAdapter2.Fill(ds, "MOD_CONT");
			DataView dv = ds.Tables["MOD_CONT"].DefaultView;

			if (dv.Count != 1)
			{
				Response.Write("載入合約錯誤，無此歷史合約？");
				return;
			}


			//這邊還沒正式完成，要在check從歷史資料中抓出來的各個帶入欄位
			this.lblContNo.Text = dv[0]["cont_contno"].ToString().Trim();
			this.tbxAuCell.Text = dv[0]["cont_aucell"].ToString().Trim();
			this.tbxAuEmail.Text = dv[0]["cont_auemail"].ToString().Trim();
			this.tbxAuFax.Text = dv[0]["cont_aufax"].ToString().Trim();
			this.tbxAuTel.Text = dv[0]["cont_autel"].ToString().Trim();
			this.tbxDisc.Text = dv[0]["cont_disc"].ToString().Trim();
			this.tbxEDate.Text = DateTime.ParseExact(dv[0]["cont_edate"].ToString().Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd", null);
			this.tbxFreeTm.Text = dv[0]["cont_freetm"].ToString().Trim();
			this.tbxPubTm.Text = dv[0]["cont_pubtm"].ToString().Trim();
			this.tbxTotImgTm.Text = dv[0]["cont_totimgtm"].ToString().Trim();
			this.tbxTotUrlTm.Text = dv[0]["cont_toturltm"].ToString().Trim();
			this.tbxSDate.Text = DateTime.ParseExact(dv[0]["cont_sdate"].ToString().Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd", null);
			this.tbxSignDate.Text = DateTime.ParseExact(dv[0]["cont_signdate"].ToString().Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd", null);
			this.tbxTotAmt.Text = dv[0]["cont_totamt"].ToString().Trim();

			this.tbxAuNm.Text = dv[0]["cont_aunm"].ToString().Trim();
			this.tbxAuTel.Text = dv[0]["cont_autel"].ToString().Trim();
			this.tbxAuCell.Text = dv[0]["cont_aucell"].ToString().Trim();
			this.tbxAuFax.Text = dv[0]["cont_aufax"].ToString().Trim();
			this.tbxAuEmail.Text = dv[0]["cont_auemail"].ToString().Trim();
			//this.tbxCCont.Text = dv[0]["cont_ccont"].ToString();
			//this.tbxCsDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			//this.tbxPdCont.Text = dv[0]["cont_pdcont"].ToString();
			this.tbxAdRemark.Text = dv[0]["cont_adremark"].ToString().Trim();
			this.tbxAdSpRemark.Text = dv[0]["cont_adsprem"].ToString().Trim();
			
			string conttp = dv[0]["cont_conttp"].ToString().Trim();
			if (conttp=="01")
			{
				this.ddlContTp.SelectedIndex = 0;
			}
			else
			{
				this.ddlContTp.SelectedIndex = 1;
			}
		}

		//觸發儲存合約
		private void btnSaveCont_Click(object sender, System.EventArgs e)
		{
			SaveCont();
		}

		//儲存合約，update c4_cont
		private void SaveCont()
		{
			if (!VerifyMoney())
			{
				return;
			}

			string contno = this.lblContNo.Text.Trim();
			string today = DateTime.Today.ToString("yyyyMMdd", null);
			string fgpubed = "0";//是否已落版
			//找AD認證的工號
			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);
			//string whoami = "900103";
			string conttp = this.ddlContTp.SelectedItem.Value.Trim();

			this.sqlCmdUpdateCont.Parameters["@cont_contno"].Value = contno;
			this.sqlCmdUpdateCont.Parameters["@cont_signdate"].Value = DateTime.ParseExact(this.tbxSignDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			this.sqlCmdUpdateCont.Parameters["@cont_sdate"].Value = DateTime.ParseExact(this.tbxSDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			this.sqlCmdUpdateCont.Parameters["@cont_edate"].Value = DateTime.ParseExact(this.tbxEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			this.sqlCmdUpdateCont.Parameters["@cont_empno"].Value = this.ddlEmpData.SelectedItem.Value.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_pubcate"].Value = ""; //到底是什麼啊？
			this.sqlCmdUpdateCont.Parameters["@cont_aunm"].Value = this.tbxAuNm.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_autel"].Value = this.tbxAuTel.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_aufax"].Value = this.tbxAuFax.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_aucell"].Value = this.tbxAuCell.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_auemail"].Value = this.tbxAuEmail.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_disc"].Value = Convert.ToSingle(this.tbxDisc.Text.Trim());
			this.sqlCmdUpdateCont.Parameters["@cont_freetm"].Value = Convert.ToInt32(this.tbxFreeTm.Text.Trim());
			this.sqlCmdUpdateCont.Parameters["@cont_totimgtm"].Value = Convert.ToInt32(this.tbxTotImgTm.Text.Trim());
			this.sqlCmdUpdateCont.Parameters["@cont_toturltm"].Value = Convert.ToInt32(this.tbxTotUrlTm.Text.Trim());
			this.sqlCmdUpdateCont.Parameters["@cont_pubtm"].Value = Convert.ToInt32(this.tbxPubTm.Text.Trim());
			this.sqlCmdUpdateCont.Parameters["@cont_resttm"].Value = Convert.ToInt32("0");	//剩餘次數
			this.sqlCmdUpdateCont.Parameters["@cont_totamt"].Value = Convert.ToSingle(this.tbxTotAmt.Text.Trim());
			this.sqlCmdUpdateCont.Parameters["@cont_paidamt"].Value = Convert.ToSingle("0");	//已付金額
			this.sqlCmdUpdateCont.Parameters["@cont_resamt"].Value = Convert.ToSingle("0");	//剩餘金額
			this.sqlCmdUpdateCont.Parameters["@cont_ccont"].Value = "";		//廣告推廣內文
			this.sqlCmdUpdateCont.Parameters["@cont_csdate"].Value = "";	//搜尋期限
			this.sqlCmdUpdateCont.Parameters["@cont_atp"].Value = "";		//應用產業代碼
			this.sqlCmdUpdateCont.Parameters["@cont_matp"].Value = "";		//材料特性代碼
			this.sqlCmdUpdateCont.Parameters["@cont_pdcont"].Value = "";	//產品設備內文
			this.sqlCmdUpdateCont.Parameters["@cont_adremark"].Value = this.tbxAdRemark.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_adsprem"].Value = this.tbxAdSpRemark.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_moddate"].Value = today;
			this.sqlCmdUpdateCont.Parameters["@cont_fgpayonce"].Value = this.rblPayOnce.SelectedItem.Value;
			this.sqlCmdUpdateCont.Parameters["@cont_fgtemp"].Value = "0";
			this.sqlCmdUpdateCont.Parameters["@cont_fgpubed"].Value = fgpubed;
			this.sqlCmdUpdateCont.Parameters["@cont_modempno"].Value = whoami;
			this.sqlCmdUpdateCont.Parameters["@cont_conttp"].Value = conttp;

			this.sqlCmdUpdateCont.Connection.Open();
			try
			{
				this.sqlCmdUpdateCont.ExecuteNonQuery();
				AlertMsg("合約修改儲存成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("合約修改儲存失敗"+ex.Message);
			}
			this.sqlCmdUpdateCont.Connection.Close();
		}

		//觸發放棄合約，delete invmfr，c4_or，c4_freebk，c4_ramt，c4_cont
		private void btnDiscardCont_Click(object sender, System.EventArgs e)
		{
			DiscardCont();
		}

		//註銷合約
		/// <summary>
		/// 在此，註銷合約的意義就是說，
		/// 一旦合約註銷，所有的相關該合約的動作凍結，
		/// 如果落版、發票、繳款等項目要繼續動作，
		/// 則要先回復合約的註銷狀態
		/// </summary>
		private void DiscardCont()
		{
			string contno = this.lblContNo.Text.Trim();
			string modempno = this.ddlEmpData.SelectedItem.Value.Trim();
			string today = DateTime.Today.ToString("yyyyMMdd");

			//Login User
			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			this.sqlCmdDelCont.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdDelCont.Connection.BeginTransaction();
			this.sqlCmdDelCont.Transaction = myTrans;

			bool DiscardSuccess = false;
			try
			{
				/*
				 * 在此，註銷合約的意義就是說
				 */

				//註銷合約
				this.sqlCmdDelCont.CommandText = "UPDATE c4_cont SET cont_fgcancel='1', cont_modempno='" + whoami + "', cont_moddate='" + today + "' WHERE (cont_syscd = 'C4') AND (cont_contno = '" + contno + "')";
				this.sqlCmdDelCont.ExecuteNonQuery();

				AlertMsg("合約註銷成功");
				this.btnCloseCont.Visible = false;
				this.btnSaveCont.Visible = false;
				//Response.Redirect("../Default.aspx");
				DiscardSuccess = true;

				myTrans.Commit();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				Response.Write("合約註銷失敗，請通知聯絡人"+ex.Message);
				DiscardSuccess = false;
			}
			this.sqlCmdDelCont.Connection.Close();

			if (!DiscardSuccess) return;

			string adsdate = "";
			string adedate = "";
			if (dgdAdr.Items.Count>0)
			{
				string effs = "";
				string[] xfs = System.IO.Directory.GetFiles(Server.MapPath(".")+"\\XMLFiles");
				if (xfs.Length<=0) return;

				bool fileadd = false;

				for (int j=0; j<xfs.Length; j++)
				{
					fileadd = false;
					string filename = xfs[j].Substring(xfs[j].LastIndexOf(".")-8,8);
					//Response.Write(adsdate+":"+adedate+":"+filename);
					for (int i=0; i<dgdAdr.Items.Count; i++)
					{
						adsdate = dgdAdr.Items[i].Cells[2].Text.Trim();
						adedate = dgdAdr.Items[i].Cells[3].Text.Trim();
						
						if (DateTime.ParseExact(adsdate, "yyyyMMdd", null) <= DateTime.ParseExact(filename, "yyyyMMdd", null) &&
							DateTime.ParseExact(filename, "yyyyMMdd", null) <= DateTime.ParseExact(adedate, "yyyyMMdd", null) &&
							fileadd == false)
						{
							effs += filename + ".xml ";
							fileadd = true;
						}
					}
				}

				if (effs!="")
				{
					//Response.Write("<script language=javascript>alert(\"" + "註銷後會影響的檔案" + effs +"\");</script>");
					AlertMsg("註銷後會影響的廣告播出檔：" + effs);
				}
				
				//不準再更動了
				//this.imgAddAdr.Visible = false;
				//this.imgAddFreeBk.Visible = false;
				//this.imgAddIM.Visible = false;
				//this.imgMisc.Visible = false;
				//this.imbRefAdr.Visible = false;
				//this.imbRefFreeBk.Visible = false;
				//this.imbRefIM.Visible = false;
				//this.imgRefMisc.Visible = false;
				this.pnlMisc.Visible = false;
				this.pnlIM.Visible = false;
				this.pnlFreebk.Visible = false;
				this.pblAdr.Visible = false;

				this.btnDiscardCont.Visible = false;
				this.btnBack.Text = "回首頁";
			}
		}

		//連結發票收件人資料
		private void BindDataGridIM()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDAInvMfr.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr4 = "1=1";
			
			string contno = "";
			if(this.lblContNo.Text.Trim() != "")
			{
				contno = this.lblContNo.Text.Trim();
				rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + contno + "'";
			}
			dv4.RowFilter = rowfilterstr4;
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
			
			this.hidIMCount.Value = dv4.Count.ToString();

			// 若搜尋結果為 "找不到" 的處理
			if (dv4.Count > 0)
			{		
				DataGridIM.DataSource=dv4;
				DataGridIM.DataBind();
				DataGridIM.Visible = true;
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGridIM.Items.Count ; i++)
				{
					// 發票類別
					string invcd = DataGridIM.Items[i].Cells[10].Text.ToString().Trim();
					switch (invcd) 
					{
						case "2":
							DataGridIM.Items[i].Cells[10].Text = "二聯";
							break;
						case "3":
							DataGridIM.Items[i].Cells[10].Text = "三聯";
							break;
						case "4":
							DataGridIM.Items[i].Cells[10].Text = "其他";
							break;
						default:
							DataGridIM.Items[i].Cells[10].Text = "三聯";
							break;
					}
					
					// 發票課稅別
					string taxtp = DataGridIM.Items[i].Cells[11].Text.ToString().Trim();
					switch (taxtp) 
					{
						case "1":
							DataGridIM.Items[i].Cells[11].Text = "應稅5%";
							break;
						case "2":
							DataGridIM.Items[i].Cells[11].Text = "零稅";
							break;
						case "3":
							DataGridIM.Items[i].Cells[11].Text = "免稅";
							break;
						default:
							DataGridIM.Items[i].Cells[11].Text = "應稅5%";
							break;
					}
					
					// 院所內註記
					string fgItri = DataGridIM.Items[i].Cells[12].Text.ToString().Trim();
					switch (fgItri) 
					{
						case "":
							DataGridIM.Items[i].Cells[12].Text = "否";
							break;
						case "06":
							DataGridIM.Items[i].Cells[12].Text = "<font color='Red'>所內</font>";
							break;
						case "07":
							DataGridIM.Items[i].Cells[12].Text = "<font color='Red'>院內</font>";
							break;
						default:
							DataGridIM.Items[i].Cells[12].Text = "否";
							break;
					}
					
				}
			}
				// 若全部刪除完時, 仍顯示殘存的最後一筆資料; 下段為清除此 bug
			else
			{
				DataGridIM.Visible = false;
			}
			
		}

		//連結贈書資料
		private void BindDataGridFreeBk()
		{
			string NewContNo = this.lblContNo.Text.Trim();
			DataSet ds = new DataSet();
			this.sqlDAFBKData.Fill(ds, "NEWFBKDATA");
			DataView dv = ds.Tables["NEWFBKDATA"].DefaultView;
			dv.RowFilter = "fbk_contno='" + NewContNo + "'";

			this.DataGridFreeBk.DataSource = dv;
			this.DataGridFreeBk.DataBind();
			
			if (dv.Count>0)
			{
				this.DataGridFreeBk.Visible = true;
			}
			else
			{
				this.DataGridFreeBk.Visible = false;
			}
		}

		//取得郵寄類別名稱
		protected object GetMtpNm(object mtpcd)
		{
			string strReturn = "";
			if(Session["MTP"]==null)
			{
				DataSet ds = new DataSet();
				this.sqlDAMTP.Fill(ds, "MTP");
				DataView dv = ds.Tables["MTP"].DefaultView;
				Session.Add("MTP", dv);
			}
			DataView mtpdv = (DataView)Session["MTP"];
			mtpdv.RowFilter = "ddl_value='" + mtpcd + "'";
			if (mtpdv.Count>0)
			{
				strReturn = mtpdv[0]["ddl_text"].ToString().Trim();
			}
			mtpdv.RowFilter = "";

			return strReturn;
		}

		private void Format_dgdAdr_Fields()
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//廣告頁面
				switch(dgdAdr.Items[i].Cells[4].Text.Trim())
				{
					case "M":
						dgdAdr.Items[i].Cells[4].Text = "首頁";
						break;
					case "I":
						dgdAdr.Items[i].Cells[4].Text = "內頁";
						break;
					case "N":
						dgdAdr.Items[i].Cells[4].Text = "奈米";
						break;
					default:
						dgdAdr.Items[i].Cells[4].Text = "";
						break;
				}

				//廣告頁面
				switch(dgdAdr.Items[i].Cells[5].Text.Trim())
				{
					case "h0":
						dgdAdr.Items[i].Cells[5].Text = "正中";
						break;
					case "h1":
						dgdAdr.Items[i].Cells[5].Text = "右一";
						break;
					case "h2":
						dgdAdr.Items[i].Cells[5].Text = "右二";
						break;
					case "h3":
						dgdAdr.Items[i].Cells[5].Text = "右三";
						break;
					case "h4":
						dgdAdr.Items[i].Cells[5].Text = "右四";
						break;
					case "w1":
						dgdAdr.Items[i].Cells[5].Text = "文一";
						break;
					case "w2":
						dgdAdr.Items[i].Cells[5].Text = "文二";
						break;
					case "w3":
						dgdAdr.Items[i].Cells[5].Text = "文三";
						break;
					case "w4":
						dgdAdr.Items[i].Cells[5].Text = "文四";
						break;
					case "w5":
						dgdAdr.Items[i].Cells[5].Text = "文五";
						break;
					case "w6":
						dgdAdr.Items[i].Cells[5].Text = "文六";
						break;
					default:
						dgdAdr.Items[i].Cells[5].Text = "";
						break;
				}

				//輪播？定播
				switch(dgdAdr.Items[i].Cells[7].Text.Trim())
				{
					case "0":
						dgdAdr.Items[i].Cells[7].Text = "輪播";
						break;
					case "1":
						dgdAdr.Items[i].Cells[7].Text = "定播";
						break;
					default:
						dgdAdr.Items[i].Cells[7].Text = "";
						break;
				}
			}
		}

		//連結現有廣告資料
		private void Bind_dgdAdr()
		{
			string NewContNo = this.lblContNo.Text;
			DataSet ds = new DataSet();
			this.sqlDaAdr.Fill(ds, "ADR");
			DataView dv = ds.Tables["ADR"].DefaultView;
			dv.RowFilter = "adr_contno='" + NewContNo + "'";
			
			if (dv.Count >0)
			{
				dgdAdr.DataSource = dv;
				dgdAdr.DataBind();
				dgdAdr.Visible = true;
				Format_dgdAdr_Fields();

				VerifyMoney();
				VerifyImage();
				VerifyAdDays();
			}
			else
			{
				dgdAdr.Visible = false;
			}
		}

		private bool VerifyMoney()
		{
			//沒廣告資料就不做
			try
			{
				if (dgdAdr.Items.Count<=0) return true;
			}
			catch
			{
				return true;
			}
			
			//有廣告資料
			int adrtotamt = 0;
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//這是發票金額
				adrtotamt += Convert.ToInt32(dgdAdr.Items[i].Cells[12].Text.Trim());
			}

			if (adrtotamt > Convert.ToInt32(tbxTotAmt.Text.Trim()))
			{
				AlertMsg("廣告金額"+ adrtotamt+"總和大於合約金額"+tbxTotAmt.Text.Trim()+"，請檢查並修改");
				return false;
			}

			return true;
		}

		//判斷新舊稿次數
		private bool VerifyImage()
		{
			//沒廣告資料就不做
			try
			{
				if (dgdAdr.Items.Count<=0) return true;
			}
			catch
			{
				return true;
			}
			
			//有廣告資料
			int newimgtm = 0;
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//新稿跟改槁才要計算
				if (dgdAdr.Items[i].Cells[13].Text.Trim() == "2" || dgdAdr.Items[i].Cells[13].Text.Trim() == "3")
				{
					newimgtm ++;
				}
			}
			int unimgtm = Convert.ToInt32(tbxTotImgTm.Text.Trim()) - newimgtm;
			this.lblUnImgTm.Text = unimgtm.ToString();

			int newurltm = 0;
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//新稿跟改槁才要計算
				if (dgdAdr.Items[i].Cells[14].Text.Trim() == "2" || dgdAdr.Items[i].Cells[14].Text.Trim() == "3")
				{
					newurltm ++;
				}
			}
			int unurltm = Convert.ToInt32(tbxTotUrlTm.Text.Trim()) - newurltm;
			this.lblUnUrlTm.Text = unurltm.ToString();

			if (newimgtm > Convert.ToInt32(tbxTotImgTm.Text.Trim()))
			{
				AlertMsg("新稿與換稿次數總和超過總製[圖檔]稿次數，請檢查並修改");
				return false;
			}

			if (newurltm > Convert.ToInt32(tbxTotUrlTm.Text.Trim()))
			{
				AlertMsg("新稿與換稿次數總和超過總製[網頁]稿次數，請檢查並修改");
				return false;
			}
			return true;
		}

		//檢查廣告天數
		private bool VerifyAdDays()
		{
			//沒廣告資料就不做
			try
			{
				if (dgdAdr.Items.Count<=0) return true;
			}
			catch
			{
				return true;
			}
			
			//有廣告資料
			int totaddays = 0;
			DateTime sdate;
			DateTime edate;
			int addays = 0;
			
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				sdate = DateTime.ParseExact(dgdAdr.Items[i].Cells[2].Text.Trim(), "yyyyMMdd", null);
				edate = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null);
				addays = ((TimeSpan)edate.Subtract(sdate)).Days + 1;
				totaddays += addays;
			}
			int unpubtm = Convert.ToInt32(tbxPubTm.Text.Trim()) - totaddays;
			this.lblUnPubTm.Text = unpubtm.ToString();

			if (totaddays > Convert.ToInt32(tbxPubTm.Text.Trim()))
			{
				AlertMsg("廣告天數總和超過刊登次數，請檢查並修改");
				return false;
			}

			return true;
		}

		//可以不填:D
		private void imbRefIM_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

		}

		//可以不填:D
		private void imbRefFreeBk_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

		}

		private void tbxEDate_TextChanged(object sender, System.EventArgs e)
		{
			if (this.tbxSDate.Text.Trim() != "" && this.tbxEDate.Text.Trim() != "")
			{
				DateTime SDate = DateTime.ParseExact(this.tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
				DateTime EDate = DateTime.ParseExact(this.tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
				this.lblDayCount.Visible = true;
				int interval = ((TimeSpan)EDate.Subtract(SDate)).Days + 1;
				this.lblDayCount.Text = "共" + interval.ToString() + "天";
			}
			else
			{
				this.lblDayCount.Visible = false;
			}
		}

		private void btnCloseCont_Click(object sender, System.EventArgs e)
		{
			CloseCont();
		}

		//合約結案
		/// <summary>
		/// 由業務人員自行決定
		/// </summary>
		private void CloseCont()
		{
			string contno = this.lblContNo.Text.Trim();
			string modempno = this.ddlEmpData.SelectedItem.Value.Trim();
			string today = DateTime.Today.ToString("yyyyMMdd");

			//Login User
			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.Connection = this.sqlCnnMRLPPub;
			cmd.CommandType = CommandType.Text;

			cmd.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = cmd.Connection.BeginTransaction();
			cmd.Transaction = myTrans;

			try
			{
				//結案合約
				cmd.CommandText = "UPDATE c4_cont SET cont_fgclosed='1', cont_modempno='" + whoami + "', cont_moddate='" + today + "' WHERE (cont_syscd = 'C4') AND (cont_contno = '" + contno + "')";
				cmd.ExecuteNonQuery();

				AlertMsg("合約結案成功");


				//Response.Redirect("../Default.aspx");

				//結案成功後
				this.pnlMisc.Visible = false;
				this.pnlIM.Visible = false;
				this.pnlFreebk.Visible = false;
				this.pblAdr.Visible = false;

				this.btnCloseCont.Visible = false;
				this.btnDiscardCont.Visible = false;
				this.btnSaveCont.Visible = false;
				this.btnBack.Text = "回首頁";

				myTrans.Commit();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				Response.Write("合約結案失敗，請通知聯絡人"+ex.Message);
			}
			cmd.Connection.Close();
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../Default.aspx");
		}
	}
}
