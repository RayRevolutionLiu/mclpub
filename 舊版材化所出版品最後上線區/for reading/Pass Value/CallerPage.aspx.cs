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
using System.Data.SqlClient;

namespace TestProj
{
	/// <summary>
	/// Summary description for CallerPage.
	/// </summary>
	public class CallerPage : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenData;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Button btnSave;
	
		public CallerPage()
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT o_oid, o_xmldata, o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfri" +
				"d, o_inm, o_ijbti, o_idddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd," +
				" o_fgpreinv, o_date, o_moddate, o_oldcusno, o_oldvdate, o_empno FROM [1_order]";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO [1_order] (o_xmldata, o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrid, o_inm, o_ijbti, o_idddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldcusno, o_oldvdate, o_empno) VALUES (@o_xmldata, @o_syscd, @o_custno, @o_otp1cd, @o_otp1seq, @o_otp2cd, @o_mfrid, @o_inm, @o_ijbti, @o_idddr, @o_izip, @o_itel, @o_ifax, @o_icell, @o_iemail, @o_pytpcd, @o_fgpreinv, @o_date, @o_moddate, @o_oldcusno, @o_oldvdate, @o_empno); SELECT o_oid, o_xmldata, o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrid, o_inm, o_ijbti, o_idddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldcusno, o_oldvdate, o_empno FROM [1_order] WHERE (o_oid = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 1000000, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrid", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_idddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_idddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldcusno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldcusno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldvdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE [1_order] SET o_xmldata = @o_xmldata, o_syscd = @o_syscd, o_custno = @o_cu" +
				"stno, o_otp1cd = @o_otp1cd, o_otp1seq = @o_otp1seq, o_otp2cd = @o_otp2cd, o_mfri" +
				"d = @o_mfrid, o_inm = @o_inm, o_ijbti = @o_ijbti, o_idddr = @o_idddr, o_izip = @" +
				"o_izip, o_itel = @o_itel, o_ifax = @o_ifax, o_icell = @o_icell, o_iemail = @o_ie" +
				"mail, o_pytpcd = @o_pytpcd, o_fgpreinv = @o_fgpreinv, o_date = @o_date, o_moddat" +
				"e = @o_moddate, o_oldcusno = @o_oldcusno, o_oldvdate = @o_oldvdate, o_empno = @o" +
				"_empno WHERE (o_oid = @Original_o_oid) AND (o_custno = @Original_o_custno OR @Or" +
				"iginal_o_custno1 IS NULL AND o_custno IS NULL) AND (o_date = @Original_o_date OR" +
				" @Original_o_date1 IS NULL AND o_date IS NULL) AND (o_empno = @Original_o_empno " +
				"OR @Original_o_empno1 IS NULL AND o_empno IS NULL) AND (o_fgpreinv = @Original_o" +
				"_fgpreinv OR @Original_o_fgpreinv1 IS NULL AND o_fgpreinv IS NULL) AND (o_icell " +
				"= @Original_o_icell OR @Original_o_icell1 IS NULL AND o_icell IS NULL) AND (o_id" +
				"ddr LIKE @Original_o_idddr OR @Original_o_idddr1 IS NULL AND o_idddr IS NULL) AN" +
				"D (o_iemail = @Original_o_iemail OR @Original_o_iemail1 IS NULL AND o_iemail IS " +
				"NULL) AND (o_ifax = @Original_o_ifax OR @Original_o_ifax1 IS NULL AND o_ifax IS " +
				"NULL) AND (o_ijbti = @Original_o_ijbti OR @Original_o_ijbti1 IS NULL AND o_ijbti" +
				" IS NULL) AND (o_inm = @Original_o_inm OR @Original_o_inm1 IS NULL AND o_inm IS " +
				"NULL) AND (o_itel = @Original_o_itel OR @Original_o_itel1 IS NULL AND o_itel IS " +
				"NULL) AND (o_izip = @Original_o_izip OR @Original_o_izip1 IS NULL AND o_izip IS " +
				"NULL) AND (o_mfrid = @Original_o_mfrid OR @Original_o_mfrid1 IS NULL AND o_mfrid" +
				" IS NULL) AND (o_moddate = @Original_o_moddate OR @Original_o_moddate1 IS NULL A" +
				"ND o_moddate IS NULL) AND (o_oldcusno = @Original_o_oldcusno OR @Original_o_oldc" +
				"usno1 IS NULL AND o_oldcusno IS NULL) AND (o_oldvdate = @Original_o_oldvdate OR " +
				"@Original_o_oldvdate1 IS NULL AND o_oldvdate IS NULL) AND (o_otp1cd = @Original_" +
				"o_otp1cd OR @Original_o_otp1cd1 IS NULL AND o_otp1cd IS NULL) AND (o_otp1seq = @" +
				"Original_o_otp1seq OR @Original_o_otp1seq1 IS NULL AND o_otp1seq IS NULL) AND (o" +
				"_otp2cd = @Original_o_otp2cd OR @Original_o_otp2cd1 IS NULL AND o_otp2cd IS NULL" +
				") AND (o_pytpcd = @Original_o_pytpcd OR @Original_o_pytpcd1 IS NULL AND o_pytpcd" +
				" IS NULL) AND (o_syscd = @Original_o_syscd OR @Original_o_syscd1 IS NULL AND o_s" +
				"yscd IS NULL) AND (o_xmldata LIKE @Original_o_xmldata OR @Original_o_xmldata1 IS" +
				" NULL AND o_xmldata IS NULL); SELECT o_oid, o_xmldata, o_syscd, o_custno, o_otp1" +
				"cd, o_otp1seq, o_otp2cd, o_mfrid, o_inm, o_ijbti, o_idddr, o_izip, o_itel, o_ifa" +
				"x, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldcusno, o_old" +
				"vdate, o_empno FROM [1_order] WHERE (o_oid = @Select_o_oid)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrid", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_idddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_idddr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldcusno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldcusno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldvdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_oid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_oid", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_custno1", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_date1", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_empno1", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_fgpreinv", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_fgpreinv1", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_icell1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_idddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_idddr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_idddr1", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_idddr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_iemail1", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_ifax1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_ijbti1", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_inm1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_itel1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_izip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_mfrid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrid", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_mfrid1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrid", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_moddate1", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_oldcusno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldcusno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_oldcusno1", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldcusno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_oldvdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_oldvdate1", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1cd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp2cd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_pytpcd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_syscd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_xmldata1", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_o_oid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_oid", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM [1_order] WHERE (o_oid = @o_oid) AND (o_custno = @o_custno OR @o_cust" +
				"no1 IS NULL AND o_custno IS NULL) AND (o_date = @o_date OR @o_date1 IS NULL AND " +
				"o_date IS NULL) AND (o_empno = @o_empno OR @o_empno1 IS NULL AND o_empno IS NULL" +
				") AND (o_fgpreinv = @o_fgpreinv OR @o_fgpreinv1 IS NULL AND o_fgpreinv IS NULL) " +
				"AND (o_icell = @o_icell OR @o_icell1 IS NULL AND o_icell IS NULL) AND (o_idddr L" +
				"IKE @o_idddr OR @o_idddr1 IS NULL AND o_idddr IS NULL) AND (o_iemail = @o_iemail" +
				" OR @o_iemail1 IS NULL AND o_iemail IS NULL) AND (o_ifax = @o_ifax OR @o_ifax1 I" +
				"S NULL AND o_ifax IS NULL) AND (o_ijbti = @o_ijbti OR @o_ijbti1 IS NULL AND o_ij" +
				"bti IS NULL) AND (o_inm = @o_inm OR @o_inm1 IS NULL AND o_inm IS NULL) AND (o_it" +
				"el = @o_itel OR @o_itel1 IS NULL AND o_itel IS NULL) AND (o_izip = @o_izip OR @o" +
				"_izip1 IS NULL AND o_izip IS NULL) AND (o_mfrid = @o_mfrid OR @o_mfrid1 IS NULL " +
				"AND o_mfrid IS NULL) AND (o_moddate = @o_moddate OR @o_moddate1 IS NULL AND o_mo" +
				"ddate IS NULL) AND (o_oldcusno = @o_oldcusno OR @o_oldcusno1 IS NULL AND o_oldcu" +
				"sno IS NULL) AND (o_oldvdate = @o_oldvdate OR @o_oldvdate1 IS NULL AND o_oldvdat" +
				"e IS NULL) AND (o_otp1cd = @o_otp1cd OR @o_otp1cd1 IS NULL AND o_otp1cd IS NULL)" +
				" AND (o_otp1seq = @o_otp1seq OR @o_otp1seq1 IS NULL AND o_otp1seq IS NULL) AND (" +
				"o_otp2cd = @o_otp2cd OR @o_otp2cd1 IS NULL AND o_otp2cd IS NULL) AND (o_pytpcd =" +
				" @o_pytpcd OR @o_pytpcd1 IS NULL AND o_pytpcd IS NULL) AND (o_syscd = @o_syscd O" +
				"R @o_syscd1 IS NULL AND o_syscd IS NULL) AND (o_xmldata LIKE @o_xmldata OR @o_xm" +
				"ldata1 IS NULL AND o_xmldata IS NULL)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_oid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno1", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date1", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno1", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv1", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_idddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_idddr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_idddr1", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_idddr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail1", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti1", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel1", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip1", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrid1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate1", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldcusno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldcusno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldcusno1", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldcusno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldvdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldvdate1", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd1", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata1", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=MRLPublish;password=moc1847csi;persist securi" +
				"ty info=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "1_order", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("o_oid", "o_oid"),
																																																				 new System.Data.Common.DataColumnMapping("o_xmldata", "o_xmldata"),
																																																				 new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				 new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				 new System.Data.Common.DataColumnMapping("o_otp2cd", "o_otp2cd"),
																																																				 new System.Data.Common.DataColumnMapping("o_mfrid", "o_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("o_inm", "o_inm"),
																																																				 new System.Data.Common.DataColumnMapping("o_ijbti", "o_ijbti"),
																																																				 new System.Data.Common.DataColumnMapping("o_idddr", "o_idddr"),
																																																				 new System.Data.Common.DataColumnMapping("o_izip", "o_izip"),
																																																				 new System.Data.Common.DataColumnMapping("o_itel", "o_itel"),
																																																				 new System.Data.Common.DataColumnMapping("o_ifax", "o_ifax"),
																																																				 new System.Data.Common.DataColumnMapping("o_icell", "o_icell"),
																																																				 new System.Data.Common.DataColumnMapping("o_iemail", "o_iemail"),
																																																				 new System.Data.Common.DataColumnMapping("o_pytpcd", "o_pytpcd"),
																																																				 new System.Data.Common.DataColumnMapping("o_fgpreinv", "o_fgpreinv"),
																																																				 new System.Data.Common.DataColumnMapping("o_date", "o_date"),
																																																				 new System.Data.Common.DataColumnMapping("o_moddate", "o_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("o_oldcusno", "o_oldcusno"),
																																																				 new System.Data.Common.DataColumnMapping("o_oldvdate", "o_oldvdate"),
																																																				 new System.Data.Common.DataColumnMapping("o_empno", "o_empno")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//存回資料庫
			for(int i=0;i<this.sqlInsertCommand1.Parameters.Count;i++)
			{
				this.sqlInsertCommand1.Parameters[i].Value = "1";
			}
			this.sqlInsertCommand1.Parameters["@o_fgpreinv"].Value = true;
			this.sqlInsertCommand1.Parameters["@o_xmldata"].Value = HiddenData.Value;
			this.sqlInsertCommand1.Connection.Open();
			this.sqlInsertCommand1.ExecuteNonQuery();
			this.sqlInsertCommand1.Connection.Close();
		}
	}
}
