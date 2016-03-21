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
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox tbxOrNm;
		protected System.Web.UI.WebControls.TextBox tbxOrJbti;
		protected System.Web.UI.WebControls.TextBox tbxOrZip;
		protected System.Web.UI.WebControls.TextBox tbxOrAddr;
		protected System.Web.UI.WebControls.TextBox tbxOrTel;
		protected System.Web.UI.WebControls.TextBox tbxOrFax;
		protected System.Web.UI.WebControls.TextBox tbxOrEmail;
		protected System.Web.UI.WebControls.DropDownList ddlOrMoSea;
		protected System.Web.UI.WebControls.Button btnAddOr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Web.UI.WebControls.Button btnDone;
		protected System.Web.UI.WebControls.TextBox tbxOrCell;

		//這兩個東西危險啊
		//private static string OrItem;
		//private static int OrSeq;
		protected System.Web.UI.WebControls.TextBox tbxFbkSdate;
		protected System.Web.UI.WebControls.TextBox tbxFbkEdate;
		protected System.Web.UI.WebControls.DropDownList ddlFbkBkCd;
		protected System.Web.UI.WebControls.TextBox tbxPubMnt;
		protected System.Web.UI.WebControls.TextBox tbxUnPubMnt;
		protected System.Web.UI.WebControls.DropDownList ddlMtpCd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDAMTP;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.DropDownList ddlOrSeq;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetOrSeq;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetFbkSeq;	
		//private static int FbkSeq;

		public AddFreeBk()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				BindOrGrid();
				BindFreeBkGrid();
				BindDDLMtp();
				BindDDLBKCD();
				//OrSeq = 0;
				//OrItem = "";
				//FbkSeq = 0;
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
			this.sqlDAMTP = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdGetOrSeq = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetFbkSeq = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.btnAddOr.Click += new System.EventHandler(this.btnAddOr_Click);
			this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
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
			this.sqlSelectCommand3.CommandText = "SELECT mtp_mtpid, mtp_nm AS ddl_text, mtp_mtpcd AS ddl_value FROM mtp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT or_orid, or_fgmosea, or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbt" +
				"i, or_addr, or_zip, or_tel, or_fax, or_cell, or_email FROM c4_or";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT fbk_fbkid, fbk_syscd, fbk_contno, fbk_fbkitem, fbk_sdate, fbk_edate, fbk_b" +
				"kcd FROM c4_freebk";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT bk_bkid, bk_nm, bk_bkcd FROM book";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT c4_freebk.fbk_syscd, c4_freebk.fbk_contno, c4_freebk.fbk_fbkitem, c4_freebk.fbk_sdate, c4_freebk.fbk_edate, c4_freebk.fbk_bkcd, book.bk_nm, c4_ramt.ma_oritem, c4_or.or_inm, c4_or.or_nm, c4_or.or_fgmosea, book.bk_bkcd, c4_or.or_contno, c4_or.or_oritem, c4_or.or_syscd, c4_ramt.ma_contno, c4_ramt.ma_fbkitem, c4_ramt.ma_syscd, c4_freebk.fbk_fbkid, c4_ramt.ma_pubmnt, c4_ramt.ma_unpubmnt FROM c4_freebk INNER JOIN c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN c4_ramt ON c4_freebk.fbk_syscd = c4_ramt.ma_syscd AND c4_freebk.fbk_contno = c4_ramt.ma_contno AND c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem AND c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN book ON c4_freebk.fbk_bkcd = book.bk_bkcd";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = @"DELETE FROM c4_or WHERE (or_contno = @or_contno) AND (or_oritem = @or_oritem) AND (or_syscd = @or_syscd) AND (or_addr LIKE @or_addr) AND (or_cell = @or_cell) AND (or_email = @or_email) AND (or_fax = @or_fax) AND (or_fgmosea = @or_fgmosea) AND (or_inm = @or_inm) AND (or_jbti = @or_jbti) AND (or_nm = @or_nm) AND (or_orid = @or_orid) AND (or_tel = @or_tel) AND (or_zip = @or_zip)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_orid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_orid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO c4_or(or_fgmosea, or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email) VALUES (@or_fgmosea, @or_syscd, @or_contno, @or_oritem, @or_inm, @or_nm, @or_jbti, @or_addr, @or_zip, @or_tel, @or_fax, @or_cell, @or_email)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE c4_or SET or_fgmosea = @or_fgmosea, or_syscd = @or_syscd, or_contno = @or_contno, or_oritem = @or_oritem, or_inm = @or_inm, or_nm = @or_nm, or_jbti = @or_jbti, or_addr = @or_addr, or_zip = @or_zip, or_tel = @or_tel, or_fax = @or_fax, or_cell = @or_cell, or_email = @or_email WHERE (or_contno = @Original_or_contno) AND (or_oritem = @Original_or_oritem) AND (or_syscd = @Original_or_syscd) AND (or_addr LIKE @Original_or_addr) AND (or_cell = @Original_or_cell) AND (or_email = @Original_or_email) AND (or_fax = @Original_or_fax) AND (or_fgmosea = @Original_or_fgmosea) AND (or_inm = @Original_or_inm) AND (or_jbti = @Original_or_jbti) AND (or_nm = @Original_or_nm) AND (or_tel = @Original_or_tel) AND (or_zip = @Original_or_zip)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_addr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_freebk", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("fbk_fbkid", "fbk_fbkid"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_syscd", "fbk_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_contno", "fbk_contno"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_fbkitem", "fbk_fbkitem"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_sdate", "fbk_sdate"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_edate", "fbk_edate"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_bkcd", "fbk_bkcd")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM c4_freebk WHERE (fbk_contno = @fbk_contno) AND (fbk_fbkitem = @fbk_fb" +
				"kitem) AND (fbk_syscd = @fbk_syscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_fbkitem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_fbkitem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO c4_freebk(fbk_syscd, fbk_contno, fbk_fbkitem, fbk_sdate, fbk_edate, f" +
				"bk_bkcd) VALUES (@fbk_syscd, @fbk_contno, @fbk_fbkitem, @fbk_sdate, @fbk_edate, " +
				"@fbk_bkcd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_fbkitem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_fbkitem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_sdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_edate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_edate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_bkcd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE c4_freebk SET fbk_syscd = @fbk_syscd, fbk_contno = @fbk_contno, fbk_fbkitem = @fbk_fbkitem, fbk_sdate = @fbk_sdate, fbk_edate = @fbk_edate, fbk_bkcd = @fbk_bkcd WHERE (fbk_contno = @Original_fbk_contno) AND (fbk_fbkitem = @Original_fbk_fbkitem) AND (fbk_syscd = @Original_fbk_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_fbkitem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_fbkitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_sdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_edate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_edate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_fbk_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_fbk_fbkitem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_fbkitem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_fbk_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd")})});
			// 
			// sqlCmdGetOrSeq
			// 
			this.sqlCmdGetOrSeq.CommandText = "SELECT MAX(or_oritem) AS MaxOrSeq FROM c4_or GROUP BY or_syscd, or_contno HAVING " +
				"(or_syscd = \'C4\') AND (or_contno = @or_contno)";
			this.sqlCmdGetOrSeq.Connection = this.sqlConnection1;
			this.sqlCmdGetOrSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdGetFbkSeq
			// 
			this.sqlCmdGetFbkSeq.CommandText = "SELECT MAX(fbk_fbkitem) AS MaxFbkSeq FROM c4_freebk GROUP BY fbk_syscd, fbk_contn" +
				"o HAVING (fbk_syscd = \'C4\') AND (fbk_contno = @fbk_contno)";
			this.sqlCmdGetFbkSeq.Connection = this.sqlConnection1;
			this.sqlCmdGetFbkSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "fbk_contno", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDone_Click(object sender, System.EventArgs e)
		{
			LiteralControl litSubmit = new LiteralControl();
			litSubmit.Text = "<script language=\"javascript\">"+
				"doSubmit();"+
				"</script>";
			Page.Controls.Add(litSubmit);
		}

		private void BindDDLMtp()
		{
			DataSet ds = new DataSet();
			this.sqlDAMTP.Fill(ds, "MTP");
			DataView dv = ds.Tables["MTP"].DefaultView;
			this.ddlMtpCd.DataTextField = "ddl_text";
			this.ddlMtpCd.DataValueField = "ddl_value";
			this.ddlMtpCd.DataSource = dv;
			this.ddlMtpCd.DataBind();
		}

		private void BindFreeBkGrid()
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter3.Fill(ds, "FreeBK");
			DataView dv = ds.Tables["FreeBK"].DefaultView;
			dv.RowFilter = "fbk_contno = '" + Request.QueryString["ContNo"].ToString() + "'";

			if (dv.Count>0)
			{
				DataGrid2.DataSource = dv;
				DataGrid2.DataBind();
				DataGrid2.Visible = true;
			}
			else
			{
				DataGrid2.Visible = false;
			}
		}

		private void BindOrGrid()
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.Fill(ds, "OR");
			DataView dv = ds.Tables["OR"].DefaultView;
			dv.RowFilter = "or_contno = '" + Request.QueryString["ContNo"].ToString() + "'";

			Session.Add("ORDV", dv);

			if (dv.Count>0)
			{
				DataGrid1.DataSource = dv;
				DataGrid1.DataBind();
				DataGrid1.Visible = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}
			DataGrid1.SelectedIndex = -1;
			//this.tbxFbkOrItem.Text = "";
			BindDDLOR();
		}

		private void BindDDLOR()
		{
			if (Session["ORDV"] != null)
			{
				DataView dv = (DataView)Session["ORDV"];
				dv.RowFilter = "or_syscd = 'C4' AND or_contno = '" + Request.QueryString["ContNo"].ToString() + "'";
				ddlOrSeq.DataTextField = "or_nm";
				ddlOrSeq.DataValueField = "or_oritem";
				ddlOrSeq.DataSource = dv;
				ddlOrSeq.DataBind();
			}
		}

		private void BindDDLBKCD()
		{
			if (Session["BOOK"] == null)
			{
				DataSet ds = new DataSet();
				this.sqlDataAdapter4.Fill(ds, "BOOK");
				DataView dv = ds.Tables["BOOK"].DefaultView;
				Session.Add("BOOK", dv);
			}
			DataView bookdv = ((DataView)Session["BOOK"]);

			this.ddlFbkBkCd.DataTextField = "bk_nm";
			this.ddlFbkBkCd.DataValueField = "bk_bkcd";
			this.ddlFbkBkCd.DataSource = bookdv;
			this.ddlFbkBkCd.DataBind();
		}

		private int GetMaxOrSeq(string GivenContNo)
		{
			int MaxSeq = 0;
			this.sqlCmdGetOrSeq.Parameters["@or_contno"].Value = GivenContNo;
			this.sqlCmdGetOrSeq.Connection.Open();
			try
			{
				MaxSeq = Convert.ToInt32(this.sqlCmdGetOrSeq.ExecuteScalar());
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write("GET MAX ORSEQ ERROR");
			}
			this.sqlCmdGetOrSeq.Connection.Close();
			return MaxSeq;
		}

		private void btnAddOr_Click(object sender, System.EventArgs e)
		{
			int NewOrSeq = GetMaxOrSeq(Request.QueryString["ContNo"].ToString())+1;
			string ContNo = Request.QueryString["ContNo"].ToString();
			this.sqlInsertCommand2.Parameters["@or_syscd"].Value = "C4";
			this.sqlInsertCommand2.Parameters["@or_contno"].Value = ContNo;
			//this.sqlInsertCommand2.Parameters["@or_oritem"].Value = OrSeq.ToString("d2", null);
			this.sqlInsertCommand2.Parameters["@or_oritem"].Value = NewOrSeq.ToString("d2", null);
			this.sqlInsertCommand2.Parameters["@or_inm"].Value = this.tbxOrNm.Text;
			this.sqlInsertCommand2.Parameters["@or_nm"].Value = this.tbxOrNm.Text;
			this.sqlInsertCommand2.Parameters["@or_jbti"].Value = this.tbxOrJbti.Text;
			this.sqlInsertCommand2.Parameters["@or_addr"].Value = this.tbxOrAddr.Text;
			this.sqlInsertCommand2.Parameters["@or_zip"].Value = this.tbxOrZip.Text;
			this.sqlInsertCommand2.Parameters["@or_tel"].Value = this.tbxOrTel.Text;
			this.sqlInsertCommand2.Parameters["@or_fax"].Value = this.tbxOrFax.Text;
			this.sqlInsertCommand2.Parameters["@or_cell"].Value = this.tbxOrCell.Text;
			this.sqlInsertCommand2.Parameters["@or_email"].Value = this.tbxOrEmail.Text;
			this.sqlInsertCommand2.Parameters["@or_fgmosea"].Value = this.ddlOrMoSea.SelectedItem.Value;

			bool InsOrSuccess = false;

			this.sqlInsertCommand1.Connection.Open();
			try
			{
				this.sqlInsertCommand2.ExecuteNonQuery();
				InsOrSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				InsOrSuccess = true;
			}
			this.sqlInsertCommand2.Connection.Close();

			if (InsOrSuccess)
			{
				//OrSeq++;
			}
			else
			{
			}
			BindOrGrid();
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandText = "DELETE FROM c4_or WHERE or_orid=@or_orid";
			cmd.CommandType = CommandType.Text;
			cmd.Connection = this.sqlConnection1;

			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_orid", System.Data.SqlDbType.Int, 4));
			cmd.Parameters["@or_orid"].Value = e.Item.Cells[2].Text.Trim();

			bool DelOrSuccess = false;

			cmd.Connection.Open();
			try
			{
				cmd.ExecuteNonQuery();
				DelOrSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				DelOrSuccess = false;
			}
			cmd.Connection.Close();

			if (DelOrSuccess)
			{
				//OrSeq++;
			}
			else
			{
			}
			BindOrGrid();
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//OrItem = DataGrid1.SelectedItem.Cells[3].Text.Trim();
			//this.tbxFbkOrItem.Text = OrItem;
		}

		private int GetMaxFbkSeq(string GivenContNo)
		{
			int MaxSeq = 0;
			this.sqlCmdGetFbkSeq.Parameters["@fbk_contno"].Value = GivenContNo;
			this.sqlCmdGetFbkSeq.Connection.Open();
			try
			{
				MaxSeq = Convert.ToInt32(this.sqlCmdGetFbkSeq.ExecuteScalar());
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write("GET MAX ORSEQ ERROR");
			}
			this.sqlCmdGetFbkSeq.Connection.Close();
			return MaxSeq;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			int NewFfbSeq = GetMaxFbkSeq(Request.QueryString["ContNo"].ToString()) + 1;
			//新增贈書資料
			this.sqlInsertCommand1.Parameters["@fbk_syscd"].Value = "C4";
			this.sqlInsertCommand1.Parameters["@fbk_contno"].Value = Request.QueryString["ContNo"].ToString();
			this.sqlInsertCommand1.Parameters["@fbk_fbkitem"].Value = NewFfbSeq.ToString("d2", null);
			//this.sqlInsertCommand1.Parameters["@fbk_oritem"].Value = this.tbxFbkOrItem.Text;
			this.sqlInsertCommand1.Parameters["@fbk_sdate"].Value = this.tbxFbkSdate.Text;
			this.sqlInsertCommand1.Parameters["@fbk_edate"].Value = this.tbxFbkEdate.Text;
			this.sqlInsertCommand1.Parameters["@fbk_bkcd"].Value = this.ddlFbkBkCd.SelectedItem.Value;
			//this.sqlInsertCommand1.Parameters["@fbk_"].Value = "";

			int currentFbkSeq=0;
			bool InsFbkSuccess = false;

			this.sqlInsertCommand1.Connection.Open();
			try
			{
				this.sqlInsertCommand1.ExecuteNonQuery();
				InsFbkSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				InsFbkSuccess = true;
			}
			this.sqlInsertCommand1.Connection.Close();

			if (InsFbkSuccess)
			{
				currentFbkSeq = NewFfbSeq;
				//FbkSeq++;
			}
			else
			{
				Response.Write("新增贈書資料錯誤");
			}
			
			//郵寄數量檔
			// 
			// sqlCmdInsRAmt
			// 
			System.Data.SqlClient.SqlCommand sqlCmdInsRAmt = new System.Data.SqlClient.SqlCommand();
			sqlCmdInsRAmt.CommandText = "INSERT INTO c4_ramt (ma_syscd, ma_contno, ma_fbkitem, ma_oritem, ma_pubmnt, ma_un" +
				"pubmnt, ma_mtpcd) VALUES (@ma_syscd, @ma_contno, @ma_fbkitem, @ma_oritem, @ma_pu" +
				"bmnt, @ma_unpubmnt, @ma_mtpcd)";
			sqlCmdInsRAmt.CommandType = CommandType.Text;
			sqlCmdInsRAmt.Connection = this.sqlConnection1;

			sqlCmdInsRAmt.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_syscd", System.Data.DataRowVersion.Current, null));
			sqlCmdInsRAmt.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_contno", System.Data.DataRowVersion.Current, null));
			sqlCmdInsRAmt.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_fbkitem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_fbkitem", System.Data.DataRowVersion.Current, null));
			sqlCmdInsRAmt.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_oritem", System.Data.DataRowVersion.Current, null));
			sqlCmdInsRAmt.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_pubmnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_pubmnt", System.Data.DataRowVersion.Current, null));
			sqlCmdInsRAmt.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_unpubmnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_unpubmnt", System.Data.DataRowVersion.Current, null));
			sqlCmdInsRAmt.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ma_mtpcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ma_mtpcd", System.Data.DataRowVersion.Current, null));

			sqlCmdInsRAmt.Parameters["@ma_syscd"].Value = "C4";
			sqlCmdInsRAmt.Parameters["@ma_contno"].Value = Request.QueryString["ContNo"].ToString();
			sqlCmdInsRAmt.Parameters["@ma_fbkitem"].Value = currentFbkSeq.ToString("d2", null);;
			sqlCmdInsRAmt.Parameters["@ma_oritem"].Value = this.ddlOrSeq.SelectedItem.Value;
			sqlCmdInsRAmt.Parameters["@ma_pubmnt"].Value = this.tbxPubMnt.Text.Trim();
			sqlCmdInsRAmt.Parameters["@ma_unpubmnt"].Value = this.tbxUnPubMnt.Text.Trim();
			sqlCmdInsRAmt.Parameters["@ma_mtpcd"].Value = this.ddlMtpCd.SelectedItem.Value;

			bool InsRamtSuccess = false;

			sqlCmdInsRAmt.Connection.Open();
			try
			{
				sqlCmdInsRAmt.ExecuteNonQuery();
				InsRamtSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				InsRamtSuccess = true;
			}
			sqlCmdInsRAmt.Connection.Close();

			if (InsRamtSuccess)
			{
				//新增郵寄數量成功
				Response.Write("done");
			}
			else
			{
				//新增失敗
				Response.Write("新增郵寄數量資料錯誤");
			}

			BindFreeBkGrid();			
		}

		private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandText = "DELETE FROM c4_freebk WHERE fbk_fbkid=@fbk_fbkid";
			cmd.CommandType = CommandType.Text;
			cmd.Connection = this.sqlConnection1;

			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbk_fbkid", System.Data.SqlDbType.Int, 4));		
			cmd.Parameters["@fbk_fbkid"].Value = e.Item.Cells[2].Text.Trim();

			bool DelFbkSuccess = false;

			cmd.Connection.Open();
			try
			{
				cmd.ExecuteNonQuery();
				DelFbkSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				DelFbkSuccess = false;
			}
			cmd.Connection.Close();

			if (DelFbkSuccess)
			{
				//FbkSeq++;
			}
			else
			{
				//Response Error Message
			}

			BindFreeBkGrid();
		}
	}
}
