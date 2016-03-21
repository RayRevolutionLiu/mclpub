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
	/// Summary description for NewCont.
	/// </summary>
	public class NewCont : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Button btnDiscardCont;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlConnection sqlCnnISCCOM1;
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
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidOldContNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCustNo;
		protected System.Web.UI.WebControls.ImageButton imbRefAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdr;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Web.UI.WebControls.Label lblDayCount;
		protected System.Web.UI.WebControls.TextBox tbxAdRemark;
		protected System.Web.UI.WebControls.TextBox tbxAdSpRemark;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.TextBox tbxTotImgTm;
		protected System.Web.UI.WebControls.TextBox tbxTotUrlTm;
		protected System.Web.UI.WebControls.Label lblUnPubTm;
		protected System.Web.UI.WebControls.Label lblUnImgTm;
		protected System.Web.UI.WebControls.Label lblUnUrlTm;
		protected System.Web.UI.WebControls.Label lblInvedAmt;
		protected System.Web.UI.WebControls.Label lblPaidAmt;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Web.UI.WebControls.ImageButton imgRefMisc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidIMCount;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetMaxContNo;
	
		public NewCont()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
				PreAddCont();
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
			this.sqlCmdGetMaxContNo = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnISCCOM1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDAFBKData = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlDAInvMfr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaAdr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsCont = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelCont = new System.Data.SqlClient.SqlCommand();
			this.sqlDAMTP = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdUpdateCont = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.tbxEDate.TextChanged += new System.EventHandler(this.tbxEDate_TextChanged);
			this.imbRefIM.Click += new System.Web.UI.ImageClickEventHandler(this.imbRefIM_Click);
			this.imbRefFreeBk.Click += new System.Web.UI.ImageClickEventHandler(this.imbRefFreeBk_Click);
			this.btnSaveCont.Click += new System.EventHandler(this.btnSaveCont_Click);
			this.btnDiscardCont.Click += new System.EventHandler(this.btnDiscardCont_Click);
			// 
			// sqlCmdGetMaxContNo
			// 
			this.sqlCmdGetMaxContNo.CommandText = "SELECT MAX(cont_contno) AS MaxContNo FROM dbo.c4_cont";
			this.sqlCmdGetMaxContNo.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCnnISCCOM1
			// 
			this.sqlCnnISCCOM1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
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
																																																				new System.Data.Common.DataColumnMapping("ma_unpubmnt", "ma_unpubmnt"),
																																																				new System.Data.Common.DataColumnMapping("ma_mtpcd", "ma_mtpcd"),
																																																				new System.Data.Common.DataColumnMapping("ma_raid", "ma_raid"),
																																																				new System.Data.Common.DataColumnMapping("or_addr", "or_addr")})});
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = @"SELECT dbo.c4_freebk.fbk_syscd, dbo.c4_freebk.fbk_contno, dbo.c4_freebk.fbk_fbkitem, dbo.c4_freebk.fbk_sdate, dbo.c4_freebk.fbk_edate, dbo.c4_freebk.fbk_bkcd, dbo.book.bk_nm, dbo.c4_ramt.ma_oritem, dbo.c4_or.or_inm, dbo.c4_or.or_nm, dbo.c4_or.or_fgmosea, dbo.book.bk_bkcd, dbo.c4_or.or_contno, dbo.c4_or.or_oritem, dbo.c4_or.or_syscd, dbo.c4_ramt.ma_contno, dbo.c4_ramt.ma_fbkitem, dbo.c4_ramt.ma_syscd, dbo.c4_freebk.fbk_fbkid, dbo.c4_ramt.ma_pubmnt, dbo.c4_ramt.ma_unpubmnt, dbo.c4_ramt.ma_mtpcd, dbo.c4_ramt.ma_raid, dbo.c4_or.or_addr FROM dbo.c4_freebk INNER JOIN dbo.c4_or ON dbo.c4_freebk.fbk_syscd = dbo.c4_or.or_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_or.or_contno INNER JOIN dbo.c4_ramt ON dbo.c4_freebk.fbk_syscd = dbo.c4_ramt.ma_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_ramt.ma_contno AND dbo.c4_freebk.fbk_fbkitem = dbo.c4_ramt.ma_fbkitem AND dbo.c4_or.or_oritem = dbo.c4_ramt.ma_oritem INNER JOIN dbo.book ON dbo.c4_freebk.fbk_bkcd = dbo.book.bk_bkcd";
			this.sqlSelectCommand6.Connection = this.sqlCnnISCCOM1;
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
			this.sqlSelectCommand4.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlDaAdr
			// 
			this.sqlDaAdr.SelectCommand = this.sqlSelectCommand7;
			this.sqlDaAdr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "c4_adr", new System.Data.Common.DataColumnMapping[] {
																																																		 new System.Data.Common.DataColumnMapping("adr_syscd", "adr_syscd"),
																																																		 new System.Data.Common.DataColumnMapping("adr_contno", "adr_contno"),
																																																		 new System.Data.Common.DataColumnMapping("adr_seq", "adr_seq"),
																																																		 new System.Data.Common.DataColumnMapping("adr_imseq", "adr_imseq"),
																																																		 new System.Data.Common.DataColumnMapping("adr_sdate", "adr_sdate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_edate", "adr_edate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_invamt", "adr_invamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_adcate", "adr_adcate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_keyword", "adr_keyword"),
																																																		 new System.Data.Common.DataColumnMapping("adr_alttext", "adr_alttext"),
																																																		 new System.Data.Common.DataColumnMapping("adr_imgurl", "adr_imgurl"),
																																																		 new System.Data.Common.DataColumnMapping("adr_drafttp", "adr_drafttp"),
																																																		 new System.Data.Common.DataColumnMapping("adr_navurl", "adr_navurl"),
																																																		 new System.Data.Common.DataColumnMapping("adr_urltp", "adr_urltp"),
																																																		 new System.Data.Common.DataColumnMapping("adr_impr", "adr_impr"),
																																																		 new System.Data.Common.DataColumnMapping("adr_adamt", "adr_adamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_desamt", "adr_desamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_chgamt", "adr_chgamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_remark", "adr_remark"),
																																																		 new System.Data.Common.DataColumnMapping("adr_projno", "adr_projno"),
																																																		 new System.Data.Common.DataColumnMapping("adr_costctr", "adr_costctr"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fgfixad", "adr_fgfixad"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fggot", "adr_fggot"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fginvself", "adr_fginvself"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fgact", "adr_fgact")})});
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = @"SELECT adr_syscd, adr_contno, adr_seq, adr_imseq, adr_sdate, adr_edate, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urltp, adr_impr, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_projno, adr_costctr, adr_fgfixad, adr_fggot, adr_fginvself, adr_fgact FROM dbo.c4_adr";
			this.sqlSelectCommand7.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCmdInsCont
			// 
			this.sqlCmdInsCont.CommandText = @"INSERT INTO dbo.c4_cont (cont_syscd, cont_contno, cont_custno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_totimgtm, cont_toturltm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_fgclosed, cont_adremark, cont_adsprem, cont_pdcont, cont_moddate, cont_fgpayonce, cont_fgtemp, cont_fgpubed, cont_fgcancel, cont_modempno, cont_credate) VALUES ('C4', @cont_contno, @cont_custno, @cont_conttp, '', '', '', @cont_empno, @cont_mfrno, '', '', '', '', '', '', 1.0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', '', '', '', '', '', '', '', '', '1', '0', '0', @cont_modempno, @cont_credate)";
			this.sqlCmdInsCont.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_credate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdDelCont
			// 
			this.sqlCmdDelCont.CommandText = "dbo.sp_c4_delete_cont";
			this.sqlCmdDelCont.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdDelCont.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdDelCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
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
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT mtp_mtpid, mtp_nm AS ddl_text, mtp_mtpcd AS ddl_value FROM dbo.mtp";
			this.sqlSelectCommand5.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCmdUpdateCont
			// 
			this.sqlCmdUpdateCont.CommandText = "dbo.sp_c4_add_cont";
			this.sqlCmdUpdateCont.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdUpdateCont.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.Char, 80, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totimgtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_toturltm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_adremark", System.Data.SqlDbType.Char, 50, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_adsprem", System.Data.SqlDbType.Char, 50, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpubed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_credate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateCont.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
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
																																																				 new System.Data.Common.DataColumnMapping("cont_totimgtm", "cont_totimgtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_toturltm", "cont_toturltm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adsprem", "cont_adsprem"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_custno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_fgpayonce, cont_fgtemp, cont_fgpubed, cont_modempno, cont_credate, cont_totimgtm, cont_toturltm, cont_adsprem, cont_fgcancel FROM dbo.c4_cont WHERE (cont_contno = @cont_contno)";
			this.sqlSelectCommand2.Connection = this.sqlCnnISCCOM1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
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
			this.sqlSelectCommand3.Connection = this.sqlCnnISCCOM1;
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
			this.sqlSelectCommand1.Connection = this.sqlCnnISCCOM1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
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

		//�q��Ʈw����X�ثe�̤j���X���s��
		private string GetMaxContNo()
		{
			string strReturn = "0";
//			int YY = DateTime.Today.Year - 1911;
//			this.sqlCmdGetMaxContNo.Parameters["@thisyear"].Value = YY.ToString();

			string tmp = "";
			
			this.sqlCmdGetMaxContNo.Connection.Open();

			try
			{
				tmp = this.sqlCmdGetMaxContNo.ExecuteScalar().ToString();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write(ex.Message);
			}

			this.sqlCmdGetMaxContNo.Connection.Close();

			if (tmp.Trim()!="")
			{
				strReturn = tmp;
			}
//			else
//			{
//				strReturn = YY.ToString()+ "0000";
//			}
			return strReturn;
		}

		//��J��l���
		private void InitData()
		{
			BindDDLEmpData();

			string old_contno = "";
			string custno = "";
			if (Request.QueryString["old_contno"] != null && Request.QueryString["old_contno"] != "")
			{
				old_contno = Request.QueryString["old_contno"];
			}
			else
			{
				Response.Write("�L�k�a�J�X���s��");
				return;
				//�L�k�a�J�X���s��
			}

			if (Request.QueryString["custno"] != null && Request.QueryString["custno"] != "")
			{
				custno = Request.QueryString["custno"];
			}
			else
			{
				Response.Write("�L�k�a�J�Ȥ�s��");
				return;
				//�L�k�a�J�Ȥ�s��
			}

			this.hidOldContNo.Value = old_contno;
			this.hidCustNo.Value = custno;

			int NewContNo = Convert.ToInt32(GetMaxContNo())+1;
			this.lblContNo.Text = NewContNo.ToString("d6", null);

			LoadCustMfrData(custno);
			LoadHistoryCont(old_contno);


			this.tbxDisc.Text = "1.0";
			this.tbxFreeTm.Text = "0";
			this.tbxPubTm.Text = "0";
			this.tbxTotAmt.Text = "0";
			this.tbxTotImgTm.Text = "0";
			this.tbxTotUrlTm.Text = "0";
		}

		//�s���~�ȭ����
		private void BindDDLEmpData()
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter3.Fill(ds, "PUBEMP");
			DataView dv = ds.Tables["PUBEMP"].DefaultView;
			if (dv.Count <= 0)
			{
				Response.Write("�~�ȭ���Ʋ��Ϳ��~");
				return;
			}

			this.ddlEmpData.DataTextField = "srspn_cname";
			this.ddlEmpData.DataValueField = "srspn_empno";
			this.ddlEmpData.DataSource = dv;
			this.ddlEmpData.DataBind();

			//��AD�{�Ҫ��u��
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
				this.ddlEmpData.Items.FindByValue("800443 ").Selected = true;//�C�X
				//this.ddlEmpData.SelectedIndex = 2; //�p�G�q�q�䤣��N�w�]�αd�R��
		}

		//���J�Ȥ���
		private void LoadCustMfrData(string CustNo)
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.SelectCommand.Parameters["@cust_custno"].Value = CustNo;
			this.sqlDataAdapter1.Fill(ds, "CUSTMFR");
			DataView dv = ds.Tables["CUSTMFR"].DefaultView;

			if (dv.Count != 1)
			{
				Response.Write("�Ȥ�t�Ӹ�ƿ��~�H�I");
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

		//���J���v���
		private void LoadHistoryCont(string ContNo)
		{
			if (ContNo == "0")
			{
				//�L���v�X��
				return;
			}
			
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.SelectCommand.Parameters["@cont_contno"].Value = ContNo;
			this.sqlDataAdapter2.Fill(ds, "OLD_CONT");
			DataView dv = ds.Tables["OLD_CONT"].DefaultView;

			if (ContNo!="0" && dv.Count != 1)
			{
				Response.Write("���J�X�����~");
				return;
			}

			//�o���٨S���������A�n�bcheck�q���v��Ƥ���X�Ӫ��U�ӱa�J���
			//this.tbxMfrName.Text = dv[i]["mfr_inm"].ToString();
			this.tbxAuCell.Text = dv[0]["cont_aucell"].ToString();
			this.tbxAuEmail.Text = dv[0]["cont_auemail"].ToString();
			this.tbxAuFax.Text = dv[0]["cont_aufax"].ToString();
			this.tbxAuTel.Text = dv[0]["cont_autel"].ToString();
			//this.tbxContNo.Text = this.getNewContNo();
			this.tbxDisc.Text = "1.0";
			this.tbxEDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxFreeTm.Text = "0";
			this.tbxPubTm.Text = "0";
			this.tbxTotImgTm.Text = "0";
			this.tbxTotUrlTm.Text = "0";
			this.tbxSDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxSignDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxTotAmt.Text = "0";

			this.tbxAuNm.Text = dv[0]["cont_aunm"].ToString();
			this.tbxAuTel.Text = dv[0]["cont_autel"].ToString();
			this.tbxAuCell.Text = dv[0]["cont_aucell"].ToString();
			this.tbxAuFax.Text = dv[0]["cont_aufax"].ToString();
			this.tbxAuEmail.Text = dv[0]["cont_auemail"].ToString();
			//this.tbxCCont.Text = dv[0]["cont_ccont"].ToString();
			//this.tbxCsDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			//this.tbxPdCont.Text = dv[0]["cont_pdcont"].ToString();
			this.tbxAdRemark.Text = dv[0]["cont_adremark"].ToString();
		}


		//�}�ҵo���t�Ӧ���H������
//		private void imbAddIM_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			LiteralControl litOpenInvMfr = new LiteralControl();
//			litOpenInvMfr.Text = "<script language=javascript>"+
//				"doOpenInvMfr("+ this.lblCustNo.Text + ", " + this.lblContNo.Text +", " + Request.QueryString["old_contno"].ToString() + ");"+
//				"</script>";
//			Page.Controls.Add(litOpenInvMfr);
//		}
//
//		private void imbAddFreeBk_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			LiteralControl litOpenFreeBk = new LiteralControl();
//			litOpenFreeBk.Text = "<script language=javascript>"+
//				"doOpenFreeBk("+ this.lblCustNo.Text + ", " + this.lblContNo.Text +", " + Request.QueryString["old_contno"].ToString() + ");"+
//				"</script>";
//			Page.Controls.Add(litOpenFreeBk);
//		}

		//�@�i�J�s�W�X���A�N����DB�n�s���X���s���A��INSERT���_��
		private void PreAddCont()
		{
			int NewContNo = Convert.ToInt32(GetMaxContNo()) + 1;
			string custno = Request.QueryString["custno"];
			string mfrno = "";

			DataSet ds = new DataSet();
			this.sqlDataAdapter1.SelectCommand.Parameters["@cust_custno"].Value = custno;
			this.sqlDataAdapter1.Fill(ds, "CUSTMFR");
			DataView dv = ds.Tables["CUSTMFR"].DefaultView;
			if (dv.Count>0)
			{
				mfrno = dv[0]["mfr_mfrno"].ToString().Trim();
			}

			string credate = DateTime.Today.ToString("yyyyMMdd", null);

			//��AD�{�Ҫ��u��
			string DomainUser = User.Identity.Name;
			string whoiam = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			//string whoiam = "900103";
			string conttp = "01";//�w�]���@��

			this.sqlCmdInsCont.Parameters["@cont_contno"].Value = NewContNo.ToString("d6");
			this.sqlCmdInsCont.Parameters["@cont_conttp"].Value = conttp;
			this.sqlCmdInsCont.Parameters["@cont_mfrno"].Value = mfrno;
			this.sqlCmdInsCont.Parameters["@cont_custno"].Value = custno;
			this.sqlCmdInsCont.Parameters["@cont_credate"].Value = credate;
			this.sqlCmdInsCont.Parameters["@cont_empno"].Value = whoiam;
			this.sqlCmdInsCont.Parameters["@cont_modempno"].Value = whoiam;

//			Response.Write("<br>NewContNo = " + this.sqlCmdInsCont.Parameters["@cont_contno"].Value.ToString());
//			Response.Write("<br>conttp = " + this.sqlCmdInsCont.Parameters["@cont_conttp"].Value.ToString());
//			Response.Write("<br>mfrno = " + this.sqlCmdInsCont.Parameters["@cont_mfrno"].Value.ToString());
//			Response.Write("<br>custno = " + this.sqlCmdInsCont.Parameters["@cont_custno"].Value.ToString());
//			Response.Write("<br>credate = " + this.sqlCmdInsCont.Parameters["@cont_credate"].Value.ToString());
//			Response.Write("<br>whoiam1 = " + this.sqlCmdInsCont.Parameters["@cont_empno"].Value.ToString());
//			Response.Write("<br>whoiam2 = " + this.sqlCmdInsCont.Parameters["@cont_modempno"].Value.ToString());



			this.sqlCmdInsCont.Connection.Open();
			try
			{
				this.sqlCmdInsCont.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write("��l�ƦX����ƥ���"+ex.Message);
			}
			this.sqlCmdInsCont.Connection.Close();
		}

		//Ĳ�o�x�s�X��
		private void btnSaveCont_Click(object sender, System.EventArgs e)
		{
			SaveCont();
		}

		//�x�s�X���Aupdate c4_cont
		private void SaveCont()
		{
			if (!VerifyMoney())
			{
				AlertMsg("�X���x�s���ѡA�Эק勵�T����A�x�s");
				return;
			}

			string contno = this.lblContNo.Text.Trim();
			string today = DateTime.Today.ToString("yyyyMMdd", null);
			string fgpubed = "0";//�O�_�w����
			string conttp = this.ddlContTp.SelectedItem.Value.Trim();

			//string whoami = "900103";
			//��AD�{�Ҫ��u��
			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			this.sqlCmdUpdateCont.Parameters["@cont_contno"].Value = contno;
			this.sqlCmdUpdateCont.Parameters["@cont_signdate"].Value = DateTime.ParseExact(this.tbxSignDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			this.sqlCmdUpdateCont.Parameters["@cont_sdate"].Value = DateTime.ParseExact(this.tbxSDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			this.sqlCmdUpdateCont.Parameters["@cont_edate"].Value = DateTime.ParseExact(this.tbxEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			this.sqlCmdUpdateCont.Parameters["@cont_empno"].Value = this.ddlEmpData.SelectedItem.Value.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_pubcate"].Value = ""; //�쩳�O����ڡH
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
			this.sqlCmdUpdateCont.Parameters["@cont_resttm"].Value = Convert.ToInt32("0");	//�Ѿl����
			this.sqlCmdUpdateCont.Parameters["@cont_totamt"].Value = Convert.ToSingle(this.tbxTotAmt.Text.Trim());
			this.sqlCmdUpdateCont.Parameters["@cont_paidamt"].Value = Convert.ToSingle("0");	//�w�I���B
			this.sqlCmdUpdateCont.Parameters["@cont_restamt"].Value = Convert.ToSingle("0");	//�Ѿl���B
			//this.sqlCmdUpdateCont.Parameters["@cont_ccont"].Value = "";//this.tbxCCont.Text.Trim();		//�s�i���s����
			//this.sqlCmdUpdateCont.Parameters["@cont_csdate"].Value = "";//DateTime.ParseExact(this.tbxCsDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");	//�j�M����
			//this.sqlCmdUpdateCont.Parameters["@cont_atp"].Value = "";		//���β��~�N�X
			//this.sqlCmdUpdateCont.Parameters["@cont_matp"].Value = "";		//���ƯS�ʥN�X
			//this.sqlCmdUpdateCont.Parameters["@cont_pdcont"].Value = "";//this.tbxPdCont.Text.Trim();	//���~�]�Ƥ���
			this.sqlCmdUpdateCont.Parameters["@cont_adremark"].Value = this.tbxAdRemark.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_adsprem"].Value = this.tbxAdSpRemark.Text.Trim();
			this.sqlCmdUpdateCont.Parameters["@cont_moddate"].Value = today;
			this.sqlCmdUpdateCont.Parameters["@cont_fgpayonce"].Value = this.rblPayOnce.SelectedItem.Value;
			//this.sqlCmdUpdateCont.Parameters["@cont_fgtemp"].Value = "0";
			this.sqlCmdUpdateCont.Parameters["@cont_fgpubed"].Value = fgpubed;
			this.sqlCmdUpdateCont.Parameters["@cont_modempno"].Value = whoami;
			this.sqlCmdUpdateCont.Parameters["@cont_conttp"].Value = conttp;
			this.sqlCmdUpdateCont.Parameters["@cont_credate"].Value = today;

			this.sqlCmdUpdateCont.Connection.Open();
			try
			{
				this.sqlCmdUpdateCont.ExecuteNonQuery();
				AlertMsg("�X���x�s���\�A�Э��s�q���i�J��L�\��");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("�X���x�s����"+ex.Message);
			}
			this.sqlCmdUpdateCont.Connection.Close();
		}

		//Ĳ�o���X���Adelete invmfr�Ac4_or�Ac4_freebk�Ac4_ramt�Ac4_cont
		private void btnDiscardCont_Click(object sender, System.EventArgs e)
		{
			DiscardCont();
		}

		//���X��
		/// <summary>
		/// �I�sstored procedure�A�O���R���X�������T��
		/// </summary>
		private void DiscardCont()
		{
			string contno = this.lblContNo.Text.Trim();
			bool ContDelSuccess = false;

			this.sqlCmdDelCont.Parameters["@cont_contno"].Value = this.lblContNo.Text.Trim();

			this.sqlCmdDelCont.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdDelCont.Connection.BeginTransaction();
			this.sqlCmdDelCont.Transaction = myTrans;

			try
			{
				this.sqlCmdDelCont.ExecuteNonQuery();

				myTrans.Commit();
				ContDelSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				ContDelSuccess = false;
				Response.Write("�X���R�����ѡA�гq���p���H"+ex.Message);
			}
			this.sqlCmdDelCont.Connection.Close();

			if (ContDelSuccess)
				Response.Redirect("../Default.aspx");
		}

		//�s���o������H���
		private void BindDataGridIM()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds4 = new DataSet();
			this.sqlDAInvMfr.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr4 = "1=1";
			
			string contno = "";
			if(this.lblContNo.Text.Trim() != "")
			{
				contno = this.lblContNo.Text.Trim();
				rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + contno + "'";
			}
			dv4.RowFilter = rowfilterstr4;
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
			this.hidIMCount.Value = dv4.Count.ToString();
			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv4.Count > 0)
			{		
				DataGridIM.DataSource=dv4;
				DataGridIM.DataBind();
				DataGridIM.Visible = true;
				
				
				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGridIM.Items.Count ; i++)
				{
					// �o�����O
					string invcd = DataGridIM.Items[i].Cells[10].Text.ToString().Trim();
					switch (invcd) 
					{
						case "2":
							DataGridIM.Items[i].Cells[10].Text = "�G�p";
							break;
						case "3":
							DataGridIM.Items[i].Cells[10].Text = "�T�p";
							break;
						case "4":
							DataGridIM.Items[i].Cells[10].Text = "��L";
							break;
						default:
							DataGridIM.Items[i].Cells[10].Text = "�T�p";
							break;
					}
					
					// �o���ҵ|�O
					string taxtp = DataGridIM.Items[i].Cells[11].Text.ToString().Trim();
					switch (taxtp) 
					{
						case "1":
							DataGridIM.Items[i].Cells[11].Text = "���|5%";
							break;
						case "2":
							DataGridIM.Items[i].Cells[11].Text = "�s�|";
							break;
						case "3":
							DataGridIM.Items[i].Cells[11].Text = "�K�|";
							break;
						default:
							DataGridIM.Items[i].Cells[11].Text = "���|5%";
							break;
					}
					
					// �|�Ҥ����O
					string fgItri = DataGridIM.Items[i].Cells[12].Text.ToString().Trim();
					switch (fgItri) 
					{
						case "":
							DataGridIM.Items[i].Cells[12].Text = "�_";
							break;
						case "06":
							DataGridIM.Items[i].Cells[12].Text = "<font color='Red'>�Ҥ�</font>";
							break;
						case "07":
							DataGridIM.Items[i].Cells[12].Text = "<font color='Red'>�|��</font>";
							break;
						default:
							DataGridIM.Items[i].Cells[12].Text = "�_";
							break;
					}
					
				}
				DataGridIM.Visible = true;
			}
				// �Y�����R������, ����ܴݦs���̫�@�����; �U�q���M���� bug
			else
			{
				DataGridIM.Visible = false;
			}
			
		}

		//�s���خѸ��
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

		//���o�l�H���O�W��
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
				//�s�i����
				switch(dgdAdr.Items[i].Cells[4].Text.Trim())
				{
					case "M":
						dgdAdr.Items[i].Cells[4].Text = "����";
						break;
					case "I":
						dgdAdr.Items[i].Cells[4].Text = "����";
						break;
					case "N":
						dgdAdr.Items[i].Cells[4].Text = "�`��";
						break;
					default:
						dgdAdr.Items[i].Cells[4].Text = "";
						break;
				}

				//�s�i����
				switch(dgdAdr.Items[i].Cells[5].Text.Trim())
				{
					case "h0":
						dgdAdr.Items[i].Cells[5].Text = "����";
						break;
					case "h1":
						dgdAdr.Items[i].Cells[5].Text = "�k�@";
						break;
					case "h2":
						dgdAdr.Items[i].Cells[5].Text = "�k�G";
						break;
					case "h3":
						dgdAdr.Items[i].Cells[5].Text = "�k�T";
						break;
					case "h4":
						dgdAdr.Items[i].Cells[5].Text = "�k�|";
						break;
					case "w1":
						dgdAdr.Items[i].Cells[5].Text = "��@";
						break;
					case "w2":
						dgdAdr.Items[i].Cells[5].Text = "��G";
						break;
					case "w3":
						dgdAdr.Items[i].Cells[5].Text = "��T";
						break;
					case "w4":
						dgdAdr.Items[i].Cells[5].Text = "��|";
						break;
					case "w5":
						dgdAdr.Items[i].Cells[5].Text = "�夭";
						break;
					case "w6":
						dgdAdr.Items[i].Cells[5].Text = "�夻";
						break;
					default:
						dgdAdr.Items[i].Cells[5].Text = "";
						break;
				}

				//�����H�w��
				switch(dgdAdr.Items[i].Cells[7].Text.Trim())
				{
					case "0":
						dgdAdr.Items[i].Cells[7].Text = "����";
						break;
					case "1":
						dgdAdr.Items[i].Cells[7].Text = "�w��";
						break;
					default:
						dgdAdr.Items[i].Cells[7].Text = "";
						break;
				}
			}
		}

		//�s���{���s�i���
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

		//�P�_�X�����B�P�s�i���B�O�_���T
		private bool VerifyMoney()
		{
			//�S�s�i��ƴN����
			try
			{
				if (dgdAdr.Items.Count<=0) return true;
			}
			catch
			{
				return true;
			}
			
			//���s�i���
			int adrtotamt = 0;
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//�o�O�o�����B
				adrtotamt += Convert.ToInt32(dgdAdr.Items[i].Cells[12].Text.Trim());
			}

			if (adrtotamt > Convert.ToInt32(tbxTotAmt.Text.Trim()))
			{
				AlertMsg("�s�i�o�����B�`�M�j��X�����B�A���ˬd�íק�");
				return false;
			}

			return true;
		}

		//�P�_�s�½Z����
		private bool VerifyImage()
		{
			//�S�s�i��ƴN����
			try
			{
				if (dgdAdr.Items.Count<=0) return true;
			}
			catch
			{
				return true;
			}
			
			//���s�i���
			int newimgtm = 0;
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//�s�Z���`�~�n�p��
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
				//�s�Z���`�~�n�p��
				if (dgdAdr.Items[i].Cells[14].Text.Trim() == "2" || dgdAdr.Items[i].Cells[14].Text.Trim() == "3")
				{
					newurltm ++;
				}
			}
			int unurltm = Convert.ToInt32(tbxTotUrlTm.Text.Trim()) - newurltm;
			this.lblUnUrlTm.Text = unurltm.ToString();

			if (newimgtm > Convert.ToInt32(tbxTotImgTm.Text.Trim()))
			{
				AlertMsg("�s�Z�P���Z�����`�M�W�L�`�s[����]�Z���ơA���ˬd�íק�");
				return false;
			}

			if (newurltm > Convert.ToInt32(tbxTotUrlTm.Text.Trim()))
			{
				AlertMsg("�s�Z�P���Z�����`�M�W�L�`�s[����]�Z���ơA���ˬd�íק�");
				return false;
			}
			return true;
		}

		//�ˬd�s�i�Ѽ�
		private bool VerifyAdDays()
		{
			//�S�s�i��ƴN����
			try
			{
				if (dgdAdr.Items.Count<=0) return true;
			}
			catch
			{
				return true;
			}
			
			//���s�i���
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
				AlertMsg("�s�i�Ѽ��`�M�W�L�Z�n���ơA���ˬd�íק�");
				return false;
			}

			return true;
		}

		//�i�H����:D
		private void imbRefIM_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.BindDataGridIM();
		}

		//�i�H����:D
		private void imbRefFreeBk_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.BindDataGridFreeBk();
		}

		private void tbxEDate_TextChanged(object sender, System.EventArgs e)
		{
			if (this.tbxSDate.Text.Trim() != "" && this.tbxEDate.Text.Trim() != "")
			{
				DateTime SDate;
				DateTime EDate;

				try
				{
					SDate = DateTime.ParseExact(this.tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
					EDate = DateTime.ParseExact(this.tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
					this.lblDayCount.Visible = true;
					int interval = ((TimeSpan)EDate.Subtract(SDate)).Days + 1;
					this.lblDayCount.Text = "�@" + interval.ToString() + "��";
					this.lblDayCount.ForeColor = Color.Black;
				}
				catch
				{
					this.lblDayCount.Text = "�榡����yyyy/MM/dd";
					this.lblDayCount.ForeColor = Color.Red;
				}
			}
			else
			{
				this.lblDayCount.Visible = false;
			}
		}
	}
}
