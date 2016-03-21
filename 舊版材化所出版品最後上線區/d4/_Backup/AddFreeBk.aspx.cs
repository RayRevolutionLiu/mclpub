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
	/// Summary description for AddFreeBk.
	/// </summary>
	public class AddFreeBk : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox tbxOrNm;
		protected System.Web.UI.WebControls.TextBox tbxOrJbti;
		protected System.Web.UI.WebControls.TextBox tbxOrZip;
		protected System.Web.UI.WebControls.TextBox tbxOrAddr;
		protected System.Web.UI.WebControls.TextBox tbxOrTel;
		protected System.Web.UI.WebControls.TextBox tbxOrFax;
		protected System.Web.UI.WebControls.TextBox tbxOrEmail;
		protected System.Web.UI.WebControls.DropDownList ddlOrMoSea;
		protected System.Web.UI.WebControls.Button btnAddOr;
		protected System.Web.UI.WebControls.TextBox tbxOrCell;


		protected System.Web.UI.WebControls.TextBox tbxFbkSdate;
		protected System.Web.UI.WebControls.TextBox tbxFbkEdate;
		protected System.Web.UI.WebControls.DropDownList ddlFbkBkCd;
		protected System.Web.UI.WebControls.TextBox tbxPubMnt;
		protected System.Web.UI.WebControls.TextBox tbxUnPubMnt;
		protected System.Web.UI.WebControls.DropDownList ddlMtpCd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAMTP;
		protected System.Web.UI.WebControls.DropDownList ddlOrSeq;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetOrSeq;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.DataGrid dgdOldOr;
		protected System.Web.UI.WebControls.DataGrid dgdNewOr;
		protected System.Web.UI.WebControls.DataGrid dgdNewFreeBk;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAFBKData;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAOr;
		protected System.Data.SqlClient.SqlConnection sqlCnnISCCOM1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.DataGrid dgdOldFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlCmdDelOr;
		protected System.Web.UI.WebControls.Button btnUpdateOr;
		protected System.Web.UI.WebControls.TextBox tbxOrSeq;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsOr;
		protected System.Web.UI.WebControls.Label lblOrMsg;
		protected System.Web.UI.WebControls.Label lblFreeBkMsg;
		protected System.Web.UI.WebControls.Button btnUpdateFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlCmdDelFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlCmdModFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlCmdModOr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAOrRef;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaCust;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Web.UI.WebControls.RegularExpressionValidator revSDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvSDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfcEDate;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAFreeCat;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Literal litAlert;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetFbkSeq;	


		public AddFreeBk()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
				BindOldOr();
				BindNewOr();
				BindOldFreeBk();
				BindNewFreeBk();
				BindDDLOR();
				BindDDLBKCD();
				BindDDLMtp();

				EnableOrAddBtn();
				EnableFreeBkAddBtn();
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

			this.sqlDAOrRef = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnISCCOM1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDAFBKData = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDAOr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetOrSeq = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetFbkSeq = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsOr = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdModFreeBk = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelFreeBk = new System.Data.SqlClient.SqlCommand();
			this.sqlDAMTP = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDAFreeCat = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdModOr = new System.Data.SqlClient.SqlCommand();
			this.sqlDaCust = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsFreeBk = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelOr = new System.Data.SqlClient.SqlCommand();
			this.dgdOldOr.SelectedIndexChanged += new System.EventHandler(this.dgdOldOr_SelectedIndexChanged);
			this.btnAddOr.Click += new System.EventHandler(this.btnAddOr_Click);
			this.btnUpdateOr.Click += new System.EventHandler(this.btnUpdateOr_Click);
			this.dgdNewOr.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewOr_DeleteCommand);
			this.dgdNewOr.SelectedIndexChanged += new System.EventHandler(this.dgdNewOr_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnUpdateFreeBk.Click += new System.EventHandler(this.btnUpdateFreeBk_Click);
			this.dgdNewFreeBk.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewFreeBk_DeleteCommand);
			this.dgdNewFreeBk.SelectedIndexChanged += new System.EventHandler(this.dgdNewFreeBk_SelectedIndexChanged);
			// 
			// sqlDAOrRef
			// 
			this.sqlDAOrRef.SelectCommand = this.sqlSelectCommand5;
			this.sqlDAOrRef.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "c4_ramt", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ma_syscd", "ma_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ma_contno", "ma_contno"),
																																																			new System.Data.Common.DataColumnMapping("ma_fbkitem", "ma_fbkitem"),
																																																			new System.Data.Common.DataColumnMapping("ma_oritem", "ma_oritem")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT ma_syscd, ma_contno, ma_fbkitem, ma_oritem FROM dbo.c4_ramt WHERE (ma_sysc" +
				"d = \'C4\') AND (ma_contno = @ma_contno) AND (ma_oritem = @ma_oritem)";
			this.sqlSelectCommand5.Connection = this.sqlCnnISCCOM1;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_contno", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_oritem", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCnnISCCOM1
			// 
			this.sqlCnnISCCOM1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDAFBKData
			// 
			this.sqlDAFBKData.SelectCommand = this.sqlSelectCommand4;
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
																																																				new System.Data.Common.DataColumnMapping("fc_nm", "fc_nm"),
																																																				new System.Data.Common.DataColumnMapping("fc_fccd", "fc_fccd")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT dbo.c4_freebk.fbk_syscd, dbo.c4_freebk.fbk_contno, dbo.c4_freebk.fbk_fbkitem, dbo.c4_freebk.fbk_sdate, dbo.c4_freebk.fbk_edate, dbo.c4_freebk.fbk_bkcd, dbo.c4_ramt.ma_oritem, dbo.c4_or.or_inm, dbo.c4_or.or_nm, dbo.c4_or.or_fgmosea, dbo.c4_or.or_contno, dbo.c4_or.or_oritem, dbo.c4_or.or_syscd, dbo.c4_ramt.ma_contno, dbo.c4_ramt.ma_fbkitem, dbo.c4_ramt.ma_syscd, dbo.c4_freebk.fbk_fbkid, dbo.c4_ramt.ma_pubmnt, dbo.c4_ramt.ma_unpubmnt, dbo.c4_ramt.ma_mtpcd, dbo.c4_ramt.ma_raid, dbo.freecat.fc_nm, dbo.freecat.fc_fccd FROM dbo.c4_freebk INNER JOIN dbo.c4_or ON dbo.c4_freebk.fbk_syscd = dbo.c4_or.or_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_or.or_contno INNER JOIN dbo.c4_ramt ON dbo.c4_freebk.fbk_syscd = dbo.c4_ramt.ma_syscd AND dbo.c4_freebk.fbk_contno = dbo.c4_ramt.ma_contno AND dbo.c4_freebk.fbk_fbkitem = dbo.c4_ramt.ma_fbkitem AND dbo.c4_or.or_oritem = dbo.c4_ramt.ma_oritem INNER JOIN dbo.freecat ON dbo.c4_freebk.fbk_bkcd = dbo.freecat.fc_fccd";
			this.sqlSelectCommand4.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlDAOr
			// 
			this.sqlDAOr.SelectCommand = this.sqlSelectCommand2;
			this.sqlDAOr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "c4_or", new System.Data.Common.DataColumnMapping[] {
																																																	   new System.Data.Common.DataColumnMapping("or_orid", "or_orid"),
																																																	   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																	   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																	   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																	   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																	   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																	   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																	   new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																	   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																	   new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																	   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																	   new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																	   new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																	   new System.Data.Common.DataColumnMapping("or_email", "or_email")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT or_orid, or_fgmosea, or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbt" +
				"i, or_addr, or_zip, or_tel, or_fax, or_cell, or_email FROM dbo.c4_or";
			this.sqlSelectCommand2.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCmdGetOrSeq
			// 
			this.sqlCmdGetOrSeq.CommandText = "SELECT MAX(or_oritem) AS MaxOrSeq FROM c4_or GROUP BY or_syscd, or_contno HAVING " +
				"(or_syscd = \'C4\') AND (or_contno = @or_contno)";
			this.sqlCmdGetOrSeq.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdGetOrSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdGetFbkSeq
			// 
			this.sqlCmdGetFbkSeq.CommandText = "SELECT MAX(fbk_fbkitem) AS MaxFbkSeq FROM c4_freebk GROUP BY fbk_syscd, fbk_contn" +
				"o HAVING (fbk_syscd = \'C4\') AND (fbk_contno = @fbk_contno)";
			this.sqlCmdGetFbkSeq.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdGetFbkSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdInsOr
			// 
			this.sqlCmdInsOr.CommandText = @"INSERT INTO dbo.c4_or (or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_fgmosea) VALUES (@or_syscd, @or_contno, @or_oritem, @or_inm, @or_nm, @or_jbti, @or_addr, @or_zip, @or_tel, @or_fax, @or_cell, @or_email, @or_fgmosea)";
			this.sqlCmdInsOr.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdModFreeBk
			// 
			this.sqlCmdModFreeBk.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCmdDelFreeBk
			// 
			this.sqlCmdDelFreeBk.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlDAMTP
			// 
			this.sqlDAMTP.SelectCommand = this.sqlSelectCommand3;
			this.sqlDAMTP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																	  new System.Data.Common.DataColumnMapping("mtp_mtpid", "mtp_mtpid"),
																																																	  new System.Data.Common.DataColumnMapping("ddl_text", "ddl_text"),
																																																	  new System.Data.Common.DataColumnMapping("ddl_value", "ddl_value")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT mtp_mtpid, mtp_nm AS ddl_text, mtp_mtpcd AS ddl_value FROM dbo.mtp";
			this.sqlSelectCommand3.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlDAFreeCat
			// 
			this.sqlDAFreeCat.SelectCommand = this.sqlSelectCommand1;
			this.sqlDAFreeCat.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "freecat", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("fc_id", "fc_id"),
																																																			  new System.Data.Common.DataColumnMapping("fc_fccd", "fc_fccd"),
																																																			  new System.Data.Common.DataColumnMapping("fc_nm", "fc_nm")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT fc_id, fc_fccd, fc_nm FROM dbo.freecat";
			this.sqlSelectCommand1.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCmdModOr
			// 
			this.sqlCmdModOr.CommandText = "UPDATE dbo.c4_or SET or_inm = @or_inm, or_nm = @or_nm, or_jbti = @or_jbti, or_add" +
				"r = @or_addr, or_zip = @or_zip, or_tel = @or_tel, or_fax = @or_fax, or_cell = @o" +
				"r_cell, or_email = @or_email, or_fgmosea = @or_fgmosea WHERE (or_orid = @or_id)";
			this.sqlCmdModOr.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.sqlCmdModOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_orid", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDaCust
			// 
			this.sqlDaCust.SelectCommand = this.sqlSelectCommand6;
			this.sqlDaCust.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
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
																																																		new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr")})});
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = @"SELECT dbo.cust.cust_custno, dbo.cust.cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_mfrno, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.cust.cust_cell, dbo.cust.cust_email, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.cust.cust_itpcd, dbo.cust.cust_btpcd, dbo.cust.cust_rtpcd, dbo.cust.cust_oldcustno, dbo.cust.cust_orgisyscd, dbo.mfr.mfr_iaddr, dbo.mfr.mfr_mfrno FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand6.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCmdInsFreeBk
			// 
			this.sqlCmdInsFreeBk.Connection = this.sqlCnnISCCOM1;
			// 
			// sqlCmdDelOr
			// 
			this.sqlCmdDelOr.CommandText = "DELETE FROM dbo.c4_or WHERE (or_orid = @or_id)";
			this.sqlCmdDelOr.Connection = this.sqlCnnISCCOM1;
			this.sqlCmdDelOr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_orid", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//��@��Alert�bclient script
		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text += "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		//��l�Ƹ��
		private void InitData()
		{
			DataSet ds = new DataSet();
			this.sqlDaCust.Fill(ds, "CUST");
			DataView dv = ds.Tables["CUST"].DefaultView;
			dv.RowFilter = "cust_custno='" + Request.QueryString["CustNo"] + "'";

			if (dv.Count>0)
			{
				this.tbxOrAddr.Text = dv[0]["mfr_iaddr"].ToString().Trim();
				this.tbxOrCell.Text = dv[0]["cust_cell"].ToString().Trim();
				this.tbxOrEmail.Text = dv[0]["cust_email"].ToString().Trim();
				this.tbxOrFax.Text = dv[0]["cust_fax"].ToString().Trim();
				this.tbxOrJbti.Text = dv[0]["cust_jbti"].ToString().Trim();
				this.tbxOrNm.Text = dv[0]["cust_nm"].ToString().Trim();
				this.tbxOrTel.Text = dv[0]["cust_tel"].ToString().Trim();
				//this.tbxOrZip.Text = dv[0]["cust_zip"].ToString().Trim();
			}
			else
			{
				//�S�F��
				return;
			}
		}

		//���J���v�X��������H���
		private void BindOldOr()
		{
			string OldContNo = Request.QueryString["OldContNo"];
			DataSet ds = new DataSet();
			this.sqlDAOr.Fill(ds, "OLDOR");
			DataView dv = ds.Tables["OLDOR"].DefaultView;
			dv.RowFilter = "or_contno='" + OldContNo + "'";

			this.dgdOldOr.DataSource = dv;
			this.dgdOldOr.DataBind();

			if (dv.Count>0)
				this.dgdOldOr.Visible = true;
			else
				this.dgdOldOr.Visible = false;
		}

		//���J�s�X��������H���
		private void BindNewOr()
		{
			string NewContNo = Request.QueryString["NewContNo"];
			DataSet ds = new DataSet();
			this.sqlDAOr.Fill(ds, "NEWOR");
			DataView dv = ds.Tables["NEWOR"].DefaultView;
			dv.RowFilter = "or_contno='" + NewContNo + "'";

			this.dgdNewOr.DataSource = dv;
			this.dgdNewOr.DataBind();

			if (dv.Count>0)
			{
				this.dgdNewOr.Visible = true;
				this.lblOrMsg.Text = "[����H���]";
			}
			else
			{
				this.dgdNewOr.Visible = false;			
				this.lblOrMsg.Text = "[�ثe�|���s�W����H���]";
			}
		}

		//���J���v�X�����خѸ��()
		private void BindOldFreeBk()
		{
			string OldContNo = Request.QueryString["OldContNo"];
			DataSet ds = new DataSet();
			this.sqlDAFBKData.Fill(ds, "OLDFBKDATA");
			DataView dv = ds.Tables["OLDFBKDATA"].DefaultView;
			dv.RowFilter = "fbk_syscd='C4' AND fbk_contno='" + OldContNo + "'";

			this.dgdOldFreeBk.DataSource = dv;
			this.dgdOldFreeBk.DataBind();

			if (dv.Count>0)
				this.dgdOldFreeBk.Visible = true;
			else
				this.dgdOldFreeBk.Visible = false;
		}

		//���J�s�X�����خѸ��
		private void BindNewFreeBk()
		{
			string NewContNo = Request.QueryString["NewContNo"];
			DataSet ds = new DataSet();
			this.sqlDAFBKData.Fill(ds, "NEWFBKDATA");
			DataView dv = ds.Tables["NEWFBKDATA"].DefaultView;
			dv.RowFilter = "fbk_contno='" + NewContNo + "'";

			this.dgdNewFreeBk.DataSource = dv;
			this.dgdNewFreeBk.DataBind();

			if (dv.Count>0)
			{
				this.dgdNewFreeBk.Visible = true;
				this.lblFreeBkMsg.Text = "[�خѸ��]";
			}
			else
			{
				this.dgdNewFreeBk.Visible = false;
				this.lblFreeBkMsg.Text = "[�ثe�|���s�W�خѸ��]";
			}
		}

		private void btnDone_Click(object sender, System.EventArgs e)
		{
			LiteralControl litSubmit = new LiteralControl();
			litSubmit.Text = "<script language=\"javascript\">"+
				"doClose();"+
				"</script>";
			Page.Controls.Add(litSubmit);
		}

		//�l�H���O
		private void BindDDLMtp()
		{
			if(Session["MTP"]==null)
			{
				DataSet ds = new DataSet();
				this.sqlDAMTP.Fill(ds, "MTP");
				DataView dv = ds.Tables["MTP"].DefaultView;
				Session.Add("MTP", dv);
			}
			DataView mtpdv = (DataView)Session["MTP"];

			this.ddlMtpCd.DataTextField = "ddl_text";
			this.ddlMtpCd.DataValueField = "ddl_value";
			this.ddlMtpCd.DataSource = mtpdv;
			this.ddlMtpCd.DataBind();
		}

		//�s�X�����{������H
		private void BindDDLOR()
		{
			DataSet ds = new DataSet();
			this.sqlDAOr.Fill(ds, "NEWOR");
			DataView dv = ds.Tables["NEWOR"].DefaultView;
			dv.RowFilter = "or_contno = '" + Request.QueryString["NewContNo"] + "'";
			ddlOrSeq.DataTextField = "or_nm";
			ddlOrSeq.DataValueField = "or_oritem";
			ddlOrSeq.DataSource = dv;
			ddlOrSeq.DataBind();
		}

		//���y���O
		private void BindDDLBKCD()
		{
			if (Session["FREECAT"] == null)
			{
				DataSet ds = new DataSet();
				this.sqlDAFreeCat.Fill(ds, "FREECAT");
				DataView dv = ds.Tables["FREECAT"].DefaultView;
				Session.Add("FREECAT", dv);
			}
			DataView bookdv = ((DataView)Session["FREECAT"]);

			this.ddlFbkBkCd.DataTextField = "fc_nm";
			this.ddlFbkBkCd.DataValueField = "fc_fccd";
			this.ddlFbkBkCd.DataSource = bookdv;
			this.ddlFbkBkCd.DataBind();
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

		//�ഫ�����~�s�X
		protected object GetYNCh(object fgmosea)
		{
			if (Convert.ToString(fgmosea) == "1")
				return "�O";
			else
				return "�_";
		}

		//�M������H�s�W��ư�
		private void CleanOrField()
		{
			this.tbxOrSeq.Text = "";
			this.tbxOrNm.Text = "";
			this.tbxOrJbti.Text = "";
			this.tbxOrZip.Text = "";
			this.tbxOrAddr.Text = "";
			this.tbxOrTel.Text = "";
			this.tbxOrFax.Text = "";
			this.tbxOrCell.Text = "";
			this.tbxOrEmail.Text = "";
			this.ddlOrMoSea.SelectedIndex = -1;
		}

		//�M���خѷs�W��ư�
		private void CleanFreeBkField()
		{
			this.tbxFbkSdate.Text = "";
			this.tbxFbkEdate.Text = "";

			this.tbxPubMnt.Text = "";
			this.tbxUnPubMnt.Text = "";

			this.ddlOrSeq.SelectedIndex = -1;
			this.ddlFbkBkCd.SelectedIndex = -1;
			this.ddlMtpCd.SelectedIndex = -1;

			//�J�M�M���F�N��X��...
			this.ddlOrSeq.Enabled = true;
		}

		//���o�̤j����H�Ǹ�
		private int GetMaxOrSeq(string GivenContNo)
		{
			int MaxSeq = 0;

			this.sqlCmdGetOrSeq.Parameters["@or_contno"].Value = GivenContNo;
			this.sqlCmdGetOrSeq.Connection.Open();
			try
			{
				string tmp = Convert.ToString(this.sqlCmdGetOrSeq.ExecuteScalar());
				if (tmp!="")
					MaxSeq = Convert.ToInt32(tmp);
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("���^ MAX ORSEQ ���~�A�Ц^��");
			}
			this.sqlCmdGetOrSeq.Connection.Close();
			return MaxSeq;
		}

		//�s�W����H���
		private void btnAddOr_Click(object sender, System.EventArgs e)
		{
//			if (!Page.IsValid)
//			{
//				AlertMessage("�Х���* ���");
//				return;
//			}

			string NewContNo = Request.QueryString["NewContNo"].ToString();
			string NewOrSeq = "";

			//�s�W���A�ҥH�����Ʈw���o�s���Ǹ�
			if (this.tbxOrSeq.Text.Trim() == "")
			{
				int tmp = GetMaxOrSeq(NewContNo) + 1;
				NewOrSeq = tmp.ToString("d2", null);
			}
			else
			{
				NewOrSeq = this.tbxOrSeq.Text.Trim();
			}

			this.sqlCmdInsOr.Parameters["@or_syscd"].Value = "C4";
			this.sqlCmdInsOr.Parameters["@or_contno"].Value = NewContNo;
			this.sqlCmdInsOr.Parameters["@or_oritem"].Value = NewOrSeq;
			this.sqlCmdInsOr.Parameters["@or_inm"].Value = this.tbxOrNm.Text;
			this.sqlCmdInsOr.Parameters["@or_nm"].Value = this.tbxOrNm.Text;
			this.sqlCmdInsOr.Parameters["@or_jbti"].Value = this.tbxOrJbti.Text;
			this.sqlCmdInsOr.Parameters["@or_addr"].Value = this.tbxOrAddr.Text;
			this.sqlCmdInsOr.Parameters["@or_zip"].Value = this.tbxOrZip.Text;
			this.sqlCmdInsOr.Parameters["@or_tel"].Value = this.tbxOrTel.Text;
			this.sqlCmdInsOr.Parameters["@or_fax"].Value = this.tbxOrFax.Text;
			this.sqlCmdInsOr.Parameters["@or_cell"].Value = this.tbxOrCell.Text;
			this.sqlCmdInsOr.Parameters["@or_email"].Value = this.tbxOrEmail.Text;
			this.sqlCmdInsOr.Parameters["@or_fgmosea"].Value = this.ddlOrMoSea.SelectedItem.Value;

			this.sqlCmdInsOr.Connection.Open();
			try
			{
				this.sqlCmdInsOr.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("�s�W����H����");
			}
			this.sqlCmdInsOr.Connection.Close();

			BindNewOr();
			BindDDLOR();
			CleanOrField();
			this.dgdOldOr.SelectedIndex = -1;
		}

		//�q��Ʈw�����o�ثe�̤j���خѧǸ�
		private int GetMaxFbkSeq(string GivenContNo)
		{
			int MaxSeq = 0;
			this.sqlCmdGetFbkSeq.Parameters["@fbk_contno"].Value = GivenContNo;
			this.sqlCmdGetFbkSeq.Connection.Open();
			try
			{
				object tmp = this.sqlCmdGetFbkSeq.ExecuteScalar();
				if (tmp!=null || tmp!="")
					MaxSeq = Convert.ToInt32(tmp);
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("���o MAX ORSEQ ���~");
			}
			this.sqlCmdGetFbkSeq.Connection.Close();
			return MaxSeq;
		}

		//�x�s�خ�
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (!Page.IsValid)
			{
				AlertMessage("�Х���* ���");
				return;
			}
			
			string contno = Request.QueryString["NewContNo"];
			int NewFbkSeq = GetMaxFbkSeq(contno) + 1;
			string oritem = this.ddlOrSeq.SelectedItem.Value;
			string fbkitem = NewFbkSeq.ToString("d2", null);
			string sdate = DateTime.ParseExact(this.tbxFbkSdate.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			string edate = DateTime.ParseExact(this.tbxFbkEdate.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			string bkcd = this.ddlFbkBkCd.SelectedItem.Value;
			string pubamt = this.tbxPubMnt.Text.Trim();
			string unpubamt = this.tbxUnPubMnt.Text.Trim();
			string mtpcd = this.ddlMtpCd.SelectedItem.Value;

			this.sqlCmdInsFreeBk.Connection.Open();
			
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdInsFreeBk.Connection.BeginTransaction();
			this.sqlCmdInsFreeBk.Transaction = myTrans;

			try
			{
				//�s�W�خ�
				this.sqlCmdInsFreeBk.CommandText = "INSERT INTO dbo.c4_freebk (fbk_syscd, fbk_contno, fbk_fbkitem, fbk_sdate, fbk_edate, fbk_bkcd) VALUES ('C4', '" + contno + "', '" + fbkitem + "', '" + sdate + "', '" + edate + "', '" + bkcd + "')";
				this.sqlCmdInsFreeBk.ExecuteNonQuery();

				//�s�W�l�H����
				this.sqlCmdInsFreeBk.CommandText = "INSERT INTO c4_ramt (ma_syscd, ma_contno, ma_fbkitem, ma_oritem, ma_pubmnt, ma_unpubmnt, ma_mtpcd) VALUES ('C4', '" + contno + "', '" + fbkitem + "', '" + oritem + "', '" + pubamt + "', '" + unpubamt + "', '" + mtpcd + "')";
				this.sqlCmdInsFreeBk.ExecuteNonQuery();

				myTrans.Commit();
				AlertMsg("�خѤΥ��Ƹ�Ʒs�W���\");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				AlertMsg("�خѤΥ��Ƹ�Ʒs�W����");
			}

			this.sqlCmdInsFreeBk.Connection.Close();

			BindNewFreeBk();

			CleanFreeBkField();
		}

		//�ק怜��H��ơG�N��Ʃ�W�榡��
		private void dgdNewOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.tbxOrSeq.Text = this.dgdNewOr.SelectedItem.Cells[3].Text.Trim();
			this.tbxOrNm.Text = this.dgdNewOr.SelectedItem.Cells[4].Text.Trim();
			this.tbxOrJbti.Text = this.dgdNewOr.SelectedItem.Cells[5].Text.Trim();
			this.tbxOrZip.Text = this.dgdNewOr.SelectedItem.Cells[6].Text.Trim();
			this.tbxOrAddr.Text = this.dgdNewOr.SelectedItem.Cells[7].Text.Trim();
			this.tbxOrTel.Text = this.dgdNewOr.SelectedItem.Cells[8].Text.Trim();
			this.tbxOrFax.Text = this.dgdNewOr.SelectedItem.Cells[9].Text.Trim();
			this.tbxOrCell.Text = this.dgdNewOr.SelectedItem.Cells[10].Text.Trim();
			this.tbxOrEmail.Text = this.dgdNewOr.SelectedItem.Cells[11].Text.Trim();
			this.ddlOrMoSea.Items.FindByValue(this.dgdNewOr.SelectedItem.Cells[13].Text.Trim()).Selected = true;

			EnableOrUpdateBtn();
		}

		//�R������H���
		private void dgdNewOr_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string orid = e.Item.Cells[0].Text.Trim();
			string contno = Request.QueryString["NewContNo"];
			string oritem = e.Item.Cells[3].Text.Trim();

			this.sqlDAOrRef.SelectCommand.Parameters["@ma_contno"].Value = contno;
			this.sqlDAOrRef.SelectCommand.Parameters["@ma_oritem"].Value = oritem;

			DataSet ds = new DataSet();
			this.sqlDAOrRef.Fill(ds, "ORREF");
			DataView dv = ds.Tables["ORREF"].DefaultView;
			if (dv.Count>0)
			{
				//�w�g��������ramt��ơA���i�H�o�˴N�R��
				AlertMsg("�w�g���������خѸ�ơA�Х��R���ϥΦ�����H���خѸ��");
				return;
			}

			this.sqlCmdDelOr.Parameters["@or_id"].Value = orid;
			this.sqlCmdDelOr.Connection.Open();
			try
			{
				this.sqlCmdDelOr.ExecuteNonQuery();
				AlertMsg("����H�R�����\");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("����H�R������");
			}
			this.sqlCmdDelOr.Connection.Close();
			
			BindNewOr();
			BindDDLOR();

			CleanOrField();

			EnableOrAddBtn();
		}

		//�N���v�X������H��Ƹ��J�榡��
		private void dgdOldOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			this.tbxOrSeq.Text = "";

			this.tbxOrNm.Text = this.dgdOldOr.SelectedItem.Cells[3].Text.Trim();
			this.tbxOrJbti.Text = this.dgdOldOr.SelectedItem.Cells[4].Text.Trim();
			this.tbxOrZip.Text = this.dgdOldOr.SelectedItem.Cells[5].Text.Trim();
			this.tbxOrAddr.Text = this.dgdOldOr.SelectedItem.Cells[6].Text.Trim();
			this.tbxOrTel.Text = this.dgdOldOr.SelectedItem.Cells[7].Text.Trim();
			this.tbxOrFax.Text = this.dgdOldOr.SelectedItem.Cells[8].Text.Trim();
			this.tbxOrCell.Text = this.dgdOldOr.SelectedItem.Cells[9].Text.Trim();
			this.tbxOrEmail.Text = this.dgdOldOr.SelectedItem.Cells[10].Text.Trim();
			this.ddlOrMoSea.Items.FindByValue(this.dgdOldOr.SelectedItem.Cells[12].Text.Trim()).Selected = true;

			EnableOrAddBtn();
		}

		//���ϥΤF
		//�N���v�X�����خѸ�Ƹ��J
//		private void dgdOldFreeBk_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			//�`�N�A�ä��O������쳣�i�H�Ѧ�
//
//			//�خѰ_���n���s�q�w�A�Ӳz���O����X�����_��...
//			this.tbxFbkSdate.Text = "";
//			this.tbxFbkEdate.Text = "";
//
//			//����H��ƭn���s�q�w
//
//			//��L�ѤU�i�H�u�Ϊ�
//			this.ddlFbkBkCd.Items.FindByText(this.dgdOldFreeBk.SelectedItem.Cells[5].Text.Trim()).Selected = true;
//			this.ddlMtpCd.Items.FindByValue(this.dgdOldFreeBk.SelectedItem.Cells[9].Text.Trim()).Selected = true;
//		}

		//�ק��خѸ��Update�^�h
		private void btnUpdateFreeBk_Click(object sender, System.EventArgs e)
		{
//			if (!Page.IsValid)
//			{
//				AlertMessage("�Х���* ���");
//				return;
//			}

			string contno = Request.QueryString["NewContNo"];
			string fbkid = this.dgdNewFreeBk.SelectedItem.Cells[0].Text.Trim();
			string fbkitem = this.dgdNewFreeBk.SelectedItem.Cells[6].Text.Trim();
			string sdate = DateTime.ParseExact(this.tbxFbkSdate.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			string edate = DateTime.ParseExact(this.tbxFbkEdate.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			string bkcd = this.ddlFbkBkCd.SelectedItem.Value;
			string mtpcd = this.ddlMtpCd.SelectedItem.Value;
			string pubamt = this.tbxPubMnt.Text.Trim();
			string unpubamt = this.tbxUnPubMnt.Text.Trim();
			string oritem = this.ddlOrSeq.SelectedItem.Value;

			this.sqlCmdModFreeBk.Connection.Open();

			//�}�lTransation
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdModFreeBk.Connection.BeginTransaction();
			this.sqlCmdModFreeBk.Transaction = myTrans;

			try
			{	
				//��s�l�H���Ƹ��
				this.sqlCmdModFreeBk.CommandText ="UPDATE dbo.c4_ramt SET ma_pubmnt ='" + pubamt + "', ma_unpubmnt ='" + unpubamt + "', ma_mtpcd ='" + mtpcd + "' WHERE (ma_syscd = 'C4') AND (ma_contno = '" + contno + "') AND (ma_fbkitem = '" + fbkitem + "') AND (ma_oritem = '" + oritem + "')";
				this.sqlCmdModFreeBk.ExecuteNonQuery();
				//Response.Write(this.sqlCmdModFreeBk.CommandText+"<br>");
				//��s�خѸ��
				this.sqlCmdModFreeBk.CommandText = "UPDATE c4_freebk SET fbk_sdate ='" + sdate + "', fbk_edate ='" + edate + "', fbk_bkcd ='" + bkcd + "' WHERE (fbk_fbkid = '" + fbkid + "')";
				this.sqlCmdModFreeBk.ExecuteNonQuery();
				//Response.Write(this.sqlCmdModFreeBk.CommandText+"<br>");			
				myTrans.Commit();
				//Response.Write(this.sqlCmdModFreeBk.CommandText+"<br>");
				AlertMsg("�خѻP�l�H���Ƹ�ƭק令�\");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				//RollBack
				myTrans.Rollback();
				AlertMsg("�خѻP�l�H���Ƹ�ƭק異��");
			}

			//Transation����

			this.sqlCmdModFreeBk.Connection.Close();
			
			BindNewFreeBk();

			CleanFreeBkField();
			EnableFreeBkAddBtn();
		}

		//���J�ק��خѸ��
		private void dgdNewFreeBk_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.tbxFbkSdate.Text = DateTime.ParseExact(this.dgdNewFreeBk.SelectedItem.Cells[7].Text.Trim(), "yyyyMM", null).ToString("yyyy/MM");
			this.tbxFbkEdate.Text = DateTime.ParseExact(this.dgdNewFreeBk.SelectedItem.Cells[8].Text.Trim(), "yyyyMM", null).ToString("yyyy/MM");

			this.tbxPubMnt.Text = this.dgdNewFreeBk.SelectedItem.Cells[11].Text.Trim();
			this.tbxUnPubMnt.Text = this.dgdNewFreeBk.SelectedItem.Cells[12].Text.Trim();

			this.ddlFbkBkCd.Items.FindByValue(this.dgdNewFreeBk.SelectedItem.Cells[2].Text.Trim()).Selected = true;
			this.ddlMtpCd.Items.FindByValue(this.dgdNewFreeBk.SelectedItem.Cells[3].Text.Trim()).Selected = true;

			//�ܭ��n�I�I�I�I�ק�ɤ��i�H���L��ʦ���H
			this.ddlOrSeq.Enabled = false;

			EnableFreeBkUpdateBtn();
		}

		//�R���خѸ��
		private void dgdNewFreeBk_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//������Table��c4_freebk�Bc4_ramt�A�n��transaction
			string fbkid = e.Item.Cells[0].Text.Trim();
			string raid = e.Item.Cells[1].Text.Trim();

			this.sqlCmdDelFreeBk.Connection.Open();

			//�}�lTransation
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdDelFreeBk.Connection.BeginTransaction();
			this.sqlCmdDelFreeBk.Transaction = myTrans;

			try
			{	
				//�R���l�H���Ƹ��
				this.sqlCmdDelFreeBk.CommandText = "DELETE FROM c4_ramt WHERE (ma_raid = '" + raid + "')";
				this.sqlCmdDelFreeBk.ExecuteNonQuery();

				//�R���خѸ��
				this.sqlCmdDelFreeBk.CommandText = "DELETE FROM c4_freebk WHERE (fbk_fbkid = '" + fbkid + "')";
				this.sqlCmdDelFreeBk.ExecuteNonQuery();

				//Commnit
				myTrans.Commit();
				AlertMsg("�خѻP�l�H���Ƹ�ƧR�����\");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				//RollBack
				myTrans.Rollback();
				AlertMsg("�خѻP�l�H���Ƹ�ƧR������");
			}

			//Transation����

			this.sqlCmdDelFreeBk.Connection.Close();
			
			BindNewFreeBk();
			CleanFreeBkField();
			EnableFreeBkAddBtn();
		}

		//�ק怜��H���
		private void btnUpdateOr_Click(object sender, System.EventArgs e)
		{
//			if (!Page.IsValid)
//			{
//				AlertMessage("�Х���* ���");
//				return;
//			}

			string NewContNo = Request.QueryString["NewContNo"].ToString();
			string orid = this.dgdNewOr.SelectedItem.Cells[0].Text.Trim();

//			this.sqlCmdInsOr.Parameters["@or_syscd"].Value = "C4";
//			this.sqlCmdInsOr.Parameters["@or_contno"].Value = NewContNo;
//			this.sqlCmdInsOr.Parameters["@or_oritem"].Value = this.tbxOrSeq.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_inm"].Value = this.tbxOrNm.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_nm"].Value = this.tbxOrNm.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_jbti"].Value = this.tbxOrJbti.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_addr"].Value = this.tbxOrAddr.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_zip"].Value = this.tbxOrZip.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_tel"].Value = this.tbxOrTel.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_fax"].Value = this.tbxOrFax.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_cell"].Value = this.tbxOrCell.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_email"].Value = this.tbxOrEmail.Text.Trim();
			this.sqlCmdModOr.Parameters["@or_fgmosea"].Value = this.ddlOrMoSea.SelectedItem.Value;
			this.sqlCmdModOr.Parameters["@or_id"].Value = orid;

			this.sqlCmdModOr.Connection.Open();
			try
			{
				this.sqlCmdModOr.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("�ק怜��H����<br>"+ex.Message);
			}

			this.sqlCmdModOr.Connection.Close();

			BindNewOr();
			//BindDDLOR();
			CleanOrField();

			EnableOrAddBtn();
		}

		//�s�WOR
		private void EnableOrAddBtn()
		{
			this.btnAddOr.Visible = true;
			this.btnUpdateOr.Visible = false;
		}

		//�ק�OR
		private void EnableOrUpdateBtn()
		{
			this.btnAddOr.Visible = false;
			this.btnUpdateOr.Visible = true;
		}

		//�s�WFreeBk
		private void EnableFreeBkAddBtn()
		{
			this.btnAdd.Visible = true;
			this.btnUpdateFreeBk.Visible = false;
		}

		//�ק�FreeBk
		private void EnableFreeBkUpdateBtn()
		{
			this.btnAdd.Visible = false;
			this.btnUpdateFreeBk.Visible = true;
		}

		//Alert Message
		private void AlertMessage(string strMsg)
		{
			LiteralControl litAlert = new LiteralControl();
			litAlert.Text = "<script language=javascript>alert(\"" + strMsg + "\");</script>";
			Page.Controls.Add(litAlert);
		}
	}
}
