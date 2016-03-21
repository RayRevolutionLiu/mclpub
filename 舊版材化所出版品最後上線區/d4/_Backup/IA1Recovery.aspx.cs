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
	/// Summary description for IARecovery.
	/// </summary>
	public class IA1Recovery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvContNo;
		protected System.Web.UI.WebControls.Button btnQueryCont;
		protected System.Web.UI.WebControls.Panel pnlCont;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdr;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaSrspn;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaFreecat;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaIm;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaMtp;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaCont;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaCustMfr;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Web.UI.WebControls.Button btnRecovery;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.DataGrid dgdFreeBk;
		protected System.Web.UI.WebControls.DataGrid dgdInvMfr;
		protected System.Web.UI.WebControls.Label lblAdRemark;
		protected System.Web.UI.WebControls.Label lblResAmt;
		protected System.Web.UI.WebControls.Label lblPaidAmt;
		protected System.Web.UI.WebControls.Label lblTotAmt;
		protected System.Web.UI.WebControls.Label lblAuEmail;
		protected System.Web.UI.WebControls.Label lblAuCell;
		protected System.Web.UI.WebControls.Label lblAuFax;
		protected System.Web.UI.WebControls.Label lblAuTel;
		protected System.Web.UI.WebControls.Label lblAuNm;
		protected System.Web.UI.WebControls.Label lblTotTm;
		protected System.Web.UI.WebControls.Label lblFreeTm;
		protected System.Web.UI.WebControls.Label lblPubTm;
		protected System.Web.UI.WebControls.Label lblModDate;
		protected System.Web.UI.WebControls.Label lblCreDate;
		protected System.Web.UI.WebControls.Label lblFgClosed;
		protected System.Web.UI.WebControls.Label lblFgPayOnce;
		protected System.Web.UI.WebControls.Label lblEmpNo;
		protected System.Web.UI.WebControls.Label lblEmpNm;
		protected System.Web.UI.WebControls.Label lblEDate;
		protected System.Web.UI.WebControls.Label lblSDate;
		protected System.Web.UI.WebControls.Label lblComtTp;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblCustNm;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrNm;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Data.SqlClient.SqlCommand sqlCmdRecoveryIA;
		protected System.Data.SqlClient.SqlCommand sqlCmdExecSp;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
	
		public IA1Recovery()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaFreeBk = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaCustMfr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaMtp = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaFreecat = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaSrspn = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdRecoveryIA = new System.Data.SqlClient.SqlCommand();
			this.sqlDaAdr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDaIm = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDaCont = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdExecSp = new System.Data.SqlClient.SqlCommand();
			this.btnQueryCont.Click += new System.EventHandler(this.btnQueryCont_Click);
			this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaFreeBk
			// 
			this.sqlDaFreeBk.SelectCommand = this.sqlSelectCommand8;
			this.sqlDaFreeBk.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "c4_freebk", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("fbk_contno", "fbk_contno"),
																																																			   new System.Data.Common.DataColumnMapping("fbk_fbkitem", "fbk_fbkitem"),
																																																			   new System.Data.Common.DataColumnMapping("fbk_sdate", "fbk_sdate"),
																																																			   new System.Data.Common.DataColumnMapping("fbk_edate", "fbk_edate"),
																																																			   new System.Data.Common.DataColumnMapping("fbk_bkcd", "fbk_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																			   new System.Data.Common.DataColumnMapping("ma_pubmnt", "ma_pubmnt"),
																																																			   new System.Data.Common.DataColumnMapping("ma_unpubmnt", "ma_unpubmnt"),
																																																			   new System.Data.Common.DataColumnMapping("ma_mtpcd", "ma_mtpcd")})});
			// 
			// sqlSelectCommand8
			// 
			this.sqlSelectCommand8.CommandText = @"SELECT DISTINCT dbo.c4_freebk.fbk_contno, dbo.c4_freebk.fbk_fbkitem, dbo.c4_freebk.fbk_sdate, dbo.c4_freebk.fbk_edate, dbo.c4_freebk.fbk_bkcd, dbo.c4_or.or_oritem, dbo.c4_or.or_nm, dbo.c4_or.or_addr, dbo.c4_or.or_fgmosea, dbo.c4_ramt.ma_pubmnt, dbo.c4_ramt.ma_unpubmnt, dbo.c4_ramt.ma_mtpcd FROM dbo.c4_freebk INNER JOIN dbo.c4_or ON dbo.c4_freebk.fbk_syscd = dbo.c4_or.or_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_or.or_contno INNER JOIN dbo.c4_ramt ON dbo.c4_freebk.fbk_syscd = dbo.c4_ramt.ma_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_ramt.ma_contno AND dbo.c4_freebk.fbk_fbkitem = dbo.c4_ramt.ma_fbkitem AND dbo.c4_or.or_oritem = dbo.c4_ramt.ma_oritem";
			this.sqlSelectCommand8.Connection = this.sqlCnnMRLPub;
			// 
			// sqlDaCustMfr
			// 
			this.sqlDaCustMfr.SelectCommand = this.sqlSelectCommand7;
			this.sqlDaCustMfr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																		   new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																		   new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																		   new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																		   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = "SELECT dbo.cust.cust_custno, dbo.cust.cust_nm, dbo.mfr.mfr_mfrno, dbo.mfr.mfr_inm" +
				" FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand7.Connection = this.sqlCnnMRLPub;
			// 
			// sqlDaMtp
			// 
			this.sqlDaMtp.SelectCommand = this.sqlSelectCommand5;
			this.sqlDaMtp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																	  new System.Data.Common.DataColumnMapping("mtp_mtpid", "mtp_mtpid"),
																																																	  new System.Data.Common.DataColumnMapping("ddl_text", "ddl_text"),
																																																	  new System.Data.Common.DataColumnMapping("ddl_value", "ddl_value")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT mtp_mtpid, mtp_nm AS ddl_text, mtp_mtpcd AS ddl_value FROM dbo.mtp";
			this.sqlSelectCommand5.Connection = this.sqlCnnMRLPub;
			// 
			// sqlDaFreecat
			// 
			this.sqlDaFreecat.SelectCommand = this.sqlSelectCommand3;
			this.sqlDaFreecat.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "freecat", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("fc_fccd", "fc_fccd"),
																																																			  new System.Data.Common.DataColumnMapping("fc_nm", "fc_nm")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT fc_fccd, fc_nm FROM dbo.freecat";
			this.sqlSelectCommand3.Connection = this.sqlCnnMRLPub;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT srspn_empno, srspn_cname FROM dbo.srspn";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPub;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT adr_syscd, adr_contno, adr_sdate, adr_edate, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginvself, adr_projno, adr_costctr, adr_imseq, adr_fgact, adr_urltp FROM dbo.c4_adr";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = @"SELECT dbo.c4_cont.cont_contid, dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_signdate, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_empno, dbo.c4_cont.cont_mfrno, dbo.c4_cont.cont_pubcate, dbo.c4_cont.cont_aunm, dbo.c4_cont.cont_autel, dbo.c4_cont.cont_aufax, dbo.c4_cont.cont_aucell, dbo.c4_cont.cont_auemail, dbo.c4_cont.cont_disc, dbo.c4_cont.cont_freetm, dbo.c4_cont.cont_pubtm, dbo.c4_cont.cont_resttm, dbo.c4_cont.cont_totamt, dbo.c4_cont.cont_paidamt, dbo.c4_cont.cont_restamt, dbo.c4_cont.cont_ccont, dbo.c4_cont.cont_csdate, dbo.c4_cont.cont_atp, dbo.c4_cont.cont_matp, dbo.c4_cont.cont_fgclosed, dbo.c4_cont.cont_adremark, dbo.c4_cont.cont_pdcont, dbo.c4_cont.cont_moddate, dbo.c4_cont.cont_fgpayonce, dbo.c4_cont.cont_fgtemp, dbo.c4_cont.cont_fgpubed, dbo.c4_cont.cont_modempno, dbo.c4_cont.cont_credate, dbo.c4_cont.cont_totimgtm, dbo.c4_cont.cont_toturltm, dbo.c4_cont.cont_adsprem, dbo.c4_cont.cont_fgcancel AS mfr_mfrnm FROM dbo.c4_cont INNER JOIN (SELECT DISTINCT adrd_syscd , adrd_contno FROM c4_adrd WHERE adrd_fginved = '0') DRIVERTBL ON dbo.c4_cont.cont_syscd = DRIVERTBL.adrd_syscd AND dbo.c4_cont.cont_contno = DRIVERTBL.adrd_contno INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.c4_cont.cont_fgtemp = '0')";
			this.sqlSelectCommand6.Connection = this.sqlCnnMRLPub;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT im_imid, im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, " +
				"im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM d" +
				"bo.invmfr";
			this.sqlSelectCommand4.Connection = this.sqlCnnMRLPub;
			// 
			// sqlDaSrspn
			// 
			this.sqlDaSrspn.SelectCommand = this.sqlSelectCommand2;
			this.sqlDaSrspn.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																		  new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																		  new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname")})});
			// 
			// sqlCmdRecoveryIA
			// 
			this.sqlCmdRecoveryIA.Connection = this.sqlCnnMRLPub;
			// 
			// sqlDaAdr
			// 
			this.sqlDaAdr.SelectCommand = this.sqlSelectCommand1;
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
			// sqlDaIm
			// 
			this.sqlDaIm.SelectCommand = this.sqlSelectCommand4;
			this.sqlDaIm.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																		new System.Data.Common.DataColumnMapping("im_imid", "im_imid"),
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
																																																		new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp"),
																																																		new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri")})});
			// 
			// sqlDaCont
			// 
			this.sqlDaCont.SelectCommand = this.sqlSelectCommand6;
			this.sqlDaCont.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																		   new System.Data.Common.DataColumnMapping("mfr_mfrnm", "mfr_mfrnm")})});
			// 
			// sqlCmdExecSp
			// 
			this.sqlCmdExecSp.Connection = this.sqlCnnMRLPub;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{

		}

		private void btnQueryCont_Click(object sender, System.EventArgs e)
		{
//			if (!Page.IsValid)
//			{
//				Response.Write("ERROR");
//				return;
//			}

			BindData();
		}

		private void BindData()
		{

			DataSet ds = new DataSet();
			this.sqlDaCont.Fill(ds, "CONT");
			DataView dv = ds.Tables["CONT"].DefaultView;
	
			string strFilter = "cont_contno='" + this.tbxContNo.Text.Trim() + "'";

			if (strFilter.Length > 0)
			{
				dv.RowFilter = strFilter;
			}

			this.lblAdRemark.Text = dv[0]["cont_adremark"].ToString().Trim();
			this.lblAuCell.Text = dv[0]["cont_aucell"].ToString().Trim();
			this.lblAuEmail.Text = dv[0]["cont_email"].ToString().Trim();
			this.lblAuFax.Text = dv[0]["cont_aufax"].ToString().Trim();
			this.lblAuNm.Text = dv[0]["cont_aunm"].ToString().Trim();
			this.lblAuTel.Text = dv[0]["cont_autel"].ToString().Trim();
			this.lblComtTp.Text = dv[0]["cont_conttp"].ToString().Trim();
			this.lblContNo.Text = dv[0]["cont_contno"].ToString().Trim();
			this.lblCreDate.Text = dv[0]["cont_credate"].ToString().Trim();
			//要轉name
			this.lblCustNm.Text = GetCustMfrField(dv[0]["cont_custno"].ToString().Trim(), "cust_nm").ToString().Trim();
			this.lblCustNo.Text = dv[0]["cont_custno"].ToString().Trim();
			this.lblEDate.Text = dv[0]["cont_date"].ToString().Trim();
			//要轉name
			this.lblEmpNm.Text = GetSrspnField(dv[0]["cont_empno"].ToString().Trim(), "srspn_cname").ToString().Trim();
			this.lblEmpNo.Text = dv[0]["cont_empno"].ToString().Trim();
			this.lblFgClosed.Text = dv[0]["cont_fgclosed"].ToString().Trim();
			this.lblFgPayOnce.Text = dv[0]["cont_payonce"].ToString().Trim();
			this.lblFreeTm.Text = dv[0]["cont_freetm"].ToString().Trim();
			//要轉name
			this.lblMfrNm.Text = GetCustMfrField(dv[0]["cont_custno"].ToString().Trim(), "mfr_inm").ToString().Trim();
			this.lblMfrNo.Text = dv[0]["cont_mfrno"].ToString().Trim();
			this.lblModDate.Text = dv[0]["cont_moddate"].ToString().Trim();
			this.lblPaidAmt.Text = dv[0]["cont_paidamt"].ToString().Trim();
			this.lblPubTm.Text = dv[0]["cont_pubtm"].ToString().Trim();
			this.lblResAmt.Text = dv[0]["cont_resamt"].ToString().Trim();
			this.lblSDate.Text = dv[0]["cont_sdate"].ToString().Trim();
			this.lblSignDate.Text = dv[0]["cont_signdate"].ToString().Trim();
			this.lblTotAmt.Text = dv[0]["cont_totamt"].ToString().Trim();
			this.lblTotTm.Text = dv[0]["cont_tottm"].ToString().Trim();

			
			Bind_dgdInvMfr();
			Bind_dgdFreeBk();
			Bind_dgdAdr();
		}

		private void Bind_dgdInvMfr()
		{
			string ContNo = this.lblContNo.Text.Trim();

			DataSet ds = new DataSet();
			this.sqlDaIm.Fill(ds, "IM");
			DataView dv = ds.Tables["IM"].DefaultView;
			dv.RowFilter = "im_contno = '" + ContNo + "'";

			dgdInvMfr.DataSource = dv;
			dgdInvMfr.DataBind();

			for (int i=0; i<dgdInvMfr.Items.Count; i++)
			{
				//頁面
				if (dgdInvMfr.Items[i].Cells[12].Text.Trim() == "06")
				{
					dgdInvMfr.Items[i].Cells[12].Text = "所內";
				}
				else if (dgdInvMfr.Items[i].Cells[12].Text.Trim() == "07")
				{
					dgdInvMfr.Items[i].Cells[12].Text = "院內";
				}
				else
				{
					dgdInvMfr.Items[i].Cells[12].Text = "其他";
				}
			}
		}

		private void Bind_dgdFreeBk()
		{
			string ContNo = this.lblContNo.Text.Trim();

			DataSet ds = new DataSet();
			this.sqlDaFreeBk.Fill(ds, "FBK");
			DataView dv = ds.Tables["FBK"].DefaultView;
			dv.RowFilter = "fbk_contno = '" + ContNo + "'";

			dgdFreeBk.DataSource = dv;
			dgdFreeBk.DataBind();
		}

		private void Bind_dgdAdr()
		{
			//這個以後再弄
			string ContNo = this.lblContNo.Text.Trim();

			DataSet ds = new DataSet();
			this.sqlDaAdr.Fill(ds, "ADR");
			DataView dv = ds.Tables["ADR"].DefaultView;
			dv.RowFilter = "adr_contno='" + ContNo + "'";
			
			dgdAdr.DataSource = dv;
			dgdAdr.DataBind();

			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//頁面
				if (dgdAdr.Items[i].Cells[4].Text.Trim() == "M")
				{
					dgdAdr.Items[i].Cells[4].Text = "首頁";
				}
				else if (dgdAdr.Items[i].Cells[4].Text.Trim() == "I")
				{
					dgdAdr.Items[i].Cells[4].Text = "內頁";
				}
				else
				{
					dgdAdr.Items[i].Cells[4].Text = "奈米";
				}

				//圖檔
				if (dgdAdr.Items[i].Cells[13].Text.Trim() == "1")
				{
					dgdAdr.Items[i].Cells[13].Text = "舊稿";
				}
				else if (dgdAdr.Items[i].Cells[13].Text.Trim() == "2")
				{
					dgdAdr.Items[i].Cells[13].Text = "新稿";
				}
				else
				{
					dgdAdr.Items[i].Cells[13].Text = "改稿";
				}

				//網頁
				if (dgdAdr.Items[i].Cells[14].Text.Trim() == "1")
				{
					dgdAdr.Items[i].Cells[14].Text = "舊稿";
				}
				else if (dgdAdr.Items[i].Cells[14].Text.Trim() == "2")
				{
					dgdAdr.Items[i].Cells[14].Text = "新稿";
				}
				else
				{
					dgdAdr.Items[i].Cells[14].Text = "改稿";
				}
			}

		}

		//對應合約中的資料欄位
		protected object GetContField(object ContNo, object Field)
		{
			string strReturn = "";

			if (ContNo.ToString() == "" || Field.ToString() == "")
			{
				return "Error";
			}

			DataSet ds = new DataSet();
			this.sqlDaCont.Fill(ds, "CONT");
			DataView dv = ds.Tables["CONT"].DefaultView;


			dv.RowFilter = "cont_contno='" + ContNo.ToString() + "'";

			if ( !(dv.Count > 0) )
			{
				return "DB Error";
			}

			strReturn = dv[0][Field.ToString()].ToString().Trim();

			dv.RowFilter = "";

			if (Field.ToString() == "cont_fgclosed" || Field.ToString() == "cont_fgpayonce" )
			{
				if (strReturn == "0")
				{
					strReturn = "否";
				}
				else
				{
					strReturn = "是";
				}
			}

			return strReturn;
		}

		//對應客戶資料中的欄位
		protected object GetCustMfrField(object CustNo, object Field)
		{
			string strReturn = "";

			if (CustNo.ToString() == "" || Field.ToString() == "")
			{
				return "Error";
			}

			if (Session["CHKCUSTMFR"] == null)
			{
				DataSet ds = new DataSet();
				this.sqlDaCustMfr.Fill(ds, "CUSTMFR");
				DataView cmdv = ds.Tables["CUSTMFR"].DefaultView;
				Session.Add("CHKCUSTMFR", cmdv);
			}
			DataView dv = (DataView)Session["CHKCUSTMFR"];

			dv.RowFilter = "cust_custno='" + CustNo.ToString() + "'";

			if (!(dv.Count>0))
			{
				return "DB Error";
			}

			strReturn = dv[0][Field.ToString()].ToString().Trim();

			dv.RowFilter = "";
		
			return strReturn;
		}

		//取得Srspn中的員工資料
		protected object GetSrspnField(object EmpNo, object Field)
		{
			string strReturn = "";

			if (EmpNo.ToString() == "" || Field.ToString() == "")
			{
				return "Error";
			}

			if (Session["CHKSRSPN"] == null)
			{
				DataSet ds = new DataSet();
				this.sqlDaSrspn.Fill(ds, "SRSPN");
				DataView srspndv = ds.Tables["SRSPN"].DefaultView;
				Session.Add("CHKSRSPN", srspndv);
			}
			DataView dv = (DataView)Session["CHKSRSPN"];

			dv.RowFilter = "srspn_empno='" + EmpNo.ToString() + "'";

			if (!(dv.Count>0))
			{
				return "DB Error";
			}

			strReturn = dv[0][Field.ToString()].ToString().Trim();

			dv.RowFilter = "";
		
			return strReturn;
		}

		//取得郵寄類別名稱
		protected object GetMtpNm(object mtpcd)
		{
			string strReturn = "";
			if(Session["MTP"]==null)
			{
				DataSet ds = new DataSet();
				this.sqlDaMtp.Fill(ds, "MTP");
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

		//取得書籍名稱
		protected object GetBkNm(object bkcd)
		{
			string strReturn = "";
			if(Session["FREECAT"]==null)
			{
				DataSet ds = new DataSet();
				this.sqlDaFreecat.Fill(ds, "FREECAT");
				DataView dv = ds.Tables["FREECAT"].DefaultView;
				Session.Add("FREECAT", dv);
			}
			DataView bkdv = (DataView)Session["FREECAT"];
			bkdv.RowFilter = "fc_fccd='" + bkcd + "'";
			if (bkdv.Count>0)
			{
				strReturn = bkdv[0]["fc_nm"].ToString().Trim();
			}
			bkdv.RowFilter = "";

			return strReturn;
		}
	
		//取得發票類別名稱
		protected object GetInvNm(object itpcd)
		{
			string strReturn = "";

			switch(itpcd.ToString().Trim())
			{
				case "1":
					strReturn = "二聯";
					break;
				case "2":
					strReturn = "三連";
					break;
				case "3":
					strReturn = "其他";
					break;
				default:
					strReturn = "未定義";
					break;
			}

			return strReturn;
		}
	
		//取得課稅類別名稱
		protected object GetTaxNm(object taxcd)
		{
			string strReturn = "";

			switch(taxcd.ToString().Trim())
			{
				case "1":
					strReturn = "應稅5%";
					break;
				case "2":
					strReturn = "零稅";
					break;
				case "3":
					strReturn = "免稅";
					break;
				default:
					strReturn = "未指定";
					break;
			}

			return strReturn;
		}

		private void btnRecovery_Click(object sender, System.EventArgs e)
		{
			//
			//update ?
			//
			//UPDATE ia SET WHERE??

			//設定command
			this.sqlCmdExecSp.CommandText = "sp_c4_delete_ia_batch";
			this.sqlCmdExecSp.CommandType = CommandType.StoredProcedure;
			this.sqlCmdExecSp.Parameters.Add("@iabdate", SqlDbType.Char, 6);
			this.sqlCmdExecSp.Parameters.Add("@iabseq", SqlDbType.Char, 6);
			this.sqlCmdExecSp.Parameters["@iabdate"].Value = IabDate;
			this.sqlCmdExecSp.Parameters["@iabseq"].Value = IabSeq;
			

			this.sqlCmdExecSp.Connection.Open();
			try
			{
				//this.sqlCmdExecSp.ExecuteNonQuery();
				AlertMsg("大批發票回復成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("大批發票回復失敗，請通知聯絡人");
			}
			this.sqlCmdExecSp.Connection.Close();
		}

	}
}
