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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for CustForm.
	/// </summary>
	public class NewCust : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnNew;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.TextBox tbxFax;
		protected System.Web.UI.WebControls.TextBox tbxEmail;
		protected System.Web.UI.WebControls.TextBox tbxCustname;
		protected System.Web.UI.WebControls.TextBox tbxTel;
		protected System.Web.UI.WebControls.TextBox tbxCell;
		protected System.Web.UI.WebControls.TextBox tbxCompanyname;
		protected System.Web.UI.WebControls.TextBox tbxMfrno;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox tbxRegDate;
		protected System.Web.UI.WebControls.TextBox tbxJob;
		protected System.Web.UI.WebControls.RadioButtonList rblJob;
		protected System.Web.UI.WebControls.CheckBoxList cblbtp;
		protected System.Web.UI.WebControls.CheckBoxList cblitp;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblInvoiceid;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		DateTime	TodayDate;
	
		public NewCust()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
//				tbxCompanyname.Text=Context.Request.QueryString["coname"];
				tbxMfrno.Text=Context.Request.QueryString["mfrno"];
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "_btp");
				cblbtp.DataSource=ds2.Tables["_btp"];
				cblbtp.DataTextField="btp_nm";
				cblbtp.DataValueField="btp_btpcd";
				cblbtp.DataBind();
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "_itp");
				cblitp.DataSource=ds3.Tables["_itp"];
				cblitp.DataTextField="itp_nm";
				cblitp.DataValueField="itp_itpcd";
				cblitp.DataBind();
				TodayDate = System.DateTime.Today;
				tbxRegDate.Text=TodayDate.ToString("yyyy/MM/dd");
				this.sqlDataAdapter5.Fill(ds2, "c1_cust");
				DataView dv = ds2.Tables["c1_cust"].DefaultView;
//				string str1=((int)(dv.Count+1)).ToString();
//				int j=6-str1.Length;
//				for(int i=0; i<j; i++)
//					str1="0"+str1;
				int j=Int32.Parse(dv[0].Row["maxcustno"].ToString())+1;
				string str1=j.ToString();
				j=6-str1.Length;
				for(int i=0; i<j; i++)
					str1="0"+str1;
				lblInvoiceid.Text=str1;
//				btnClear.Attributes["onclick"]="javascript:window.history.back();";
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
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.rblJob.SelectedIndexChanged += new System.EventHandler(this.rblJob_SelectedIndexChanged);
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.c1_cust WHERE (cust_custid = @cust_custid) AND (cust_btpcd = @cust_btpcd) AND (cust_cell = @cust_cell) AND (cust_custno = @cust_custno) AND (cust_email = @cust_email) AND (cust_fax = @cust_fax) AND (cust_fgoe = @cust_fgoe) AND (cust_fgoi = @cust_fgoi) AND (cust_itpcd = @cust_itpcd) AND (cust_jbti = @cust_jbti) AND (cust_mfrno = @cust_mfrno) AND (cust_moddate = @cust_moddate) AND (cust_nm = @cust_nm) AND (cust_otp1seq1 = @cust_otp1seq1) AND (cust_otp1seq2 = @cust_otp1seq2) AND (cust_otp1seq3 = @cust_otp1seq3) AND (cust_otp1seq9 = @cust_otp1seq9) AND (cust_regdate = @cust_regdate) AND (cust_tel = @cust_tel)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_btpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_btpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_cell", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_email", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_itpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_itpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_jbti", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_nm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq1", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq2", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq2", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq3", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq3", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq9", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq9", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_regdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_regdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_tel", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT mfr_mfrid, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, mfr_respnm, mfr_respjb" +
				"ti, mfr_tel, mfr_fax, mfr_regdate FROM dbo.mfr";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT itp_itpid, itp_nm, itp_itpcd FROM dbo.itp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT btp_btpid, btp_nm, btp_btpcd FROM dbo.btp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cust_custid, cust_btpcd, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_fgoi, cust_fgoe, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9, cust_itpcd FROM dbo.c1_cust";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT MAX(cust_custno) AS maxcustno FROM dbo.c1_cust";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE dbo.c1_cust SET cust_btpcd = @cust_btpcd, cust_custno = @cust_custno, cust" +
				"_nm = @cust_nm, cust_jbti = @cust_jbti, cust_mfrno = @cust_mfrno, cust_tel = @cu" +
				"st_tel, cust_fax = @cust_fax, cust_cell = @cust_cell, cust_email = @cust_email, " +
				"cust_regdate = @cust_regdate, cust_moddate = @cust_moddate, cust_fgoi = @cust_fg" +
				"oi, cust_fgoe = @cust_fgoe, cust_otp1seq1 = @cust_otp1seq1, cust_otp1seq2 = @cus" +
				"t_otp1seq2, cust_otp1seq3 = @cust_otp1seq3, cust_otp1seq9 = @cust_otp1seq9, cust" +
				"_itpcd = @cust_itpcd WHERE (cust_custid = @Original_cust_custid) AND (cust_btpcd" +
				" = @Original_cust_btpcd) AND (cust_cell = @Original_cust_cell) AND (cust_custno " +
				"= @Original_cust_custno) AND (cust_email = @Original_cust_email) AND (cust_fax =" +
				" @Original_cust_fax) AND (cust_fgoe = @Original_cust_fgoe) AND (cust_fgoi = @Ori" +
				"ginal_cust_fgoi) AND (cust_itpcd = @Original_cust_itpcd) AND (cust_jbti = @Origi" +
				"nal_cust_jbti) AND (cust_mfrno = @Original_cust_mfrno) AND (cust_moddate = @Orig" +
				"inal_cust_moddate) AND (cust_nm = @Original_cust_nm) AND (cust_otp1seq1 = @Origi" +
				"nal_cust_otp1seq1) AND (cust_otp1seq2 = @Original_cust_otp1seq2) AND (cust_otp1s" +
				"eq3 = @Original_cust_otp1seq3) AND (cust_otp1seq9 = @Original_cust_otp1seq9) AND" +
				" (cust_regdate = @Original_cust_regdate) AND (cust_tel = @Original_cust_tel); SE" +
				"LECT cust_custid, cust_btpcd, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_" +
				"tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_fgoi, cus" +
				"t_fgoe, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9, cust_itpcd F" +
				"ROM dbo.c1_cust WHERE (cust_custid = @Select_cust_custid)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_btpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_btpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_cell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_email", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_regdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_regdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq1", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq2", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq2", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq3", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq3", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq9", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq9", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_itpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_itpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_custid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custid", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_btpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_btpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_cell", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_email", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_itpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_itpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_jbti", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_nm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq1", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_otp1seq2", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq2", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_otp1seq3", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq3", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_otp1seq9", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq9", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_regdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_regdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_tel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cust_custid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custid", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("maxcustno", "maxcustno")})});
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "itp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("itp_itpid", "itp_itpid"),
																																																			 new System.Data.Common.DataColumnMapping("itp_nm", "itp_nm"),
																																																			 new System.Data.Common.DataColumnMapping("itp_itpcd", "itp_itpcd")})});
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "btp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("btp_btpid", "btp_btpid"),
																																																			 new System.Data.Common.DataColumnMapping("btp_nm", "btp_nm"),
																																																			 new System.Data.Common.DataColumnMapping("btp_btpcd", "btp_btpcd")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
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
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoi", "cust_fgoi"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoe", "cust_fgoe"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq1", "cust_otp1seq1"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq2", "cust_otp1seq2"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq3", "cust_otp1seq3"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq9", "cust_otp1seq9"),
																																																				 new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.c1_cust(cust_btpcd, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_fgoi, cust_fgoe, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9, cust_itpcd) VALUES (@cust_btpcd, @cust_custno, @cust_nm, @cust_jbti, @cust_mfrno, @cust_tel, @cust_fax, @cust_cell, @cust_email, @cust_regdate, @cust_moddate, @cust_fgoi, @cust_fgoe, @cust_otp1seq1, @cust_otp1seq2, @cust_otp1seq3, @cust_otp1seq9, @cust_itpcd); SELECT cust_custid, cust_btpcd, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_fgoi, cust_fgoe, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9, cust_itpcd FROM dbo.c1_cust WHERE (cust_custid = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_btpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_btpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_cell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_email", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_regdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_regdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq1", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq2", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq2", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq3", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq3", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq9", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq9", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_itpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_itpcd", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			DateTime	date1;
			string cblstr1, cblstr2;
			cblstr1=cblstr2="";
			//存回資料庫
			DataSet ds=new DataSet();
			this.sqlDataAdapter4.Fill(ds, "mfr");
			DataView dv = ds.Tables["mfr"].DefaultView;
			dv.RowFilter="mfr_mfrno Like '%"+tbxMfrno.Text.Trim()+"%'";
			if(dv.Count==0)
				lblMessage.Text="無此廠商資料,請確認廠商統一編號!!";
			else
			{
				if (Page.IsValid)
				{
						//存訂戶營業檔1_custbtp
					for(int i=0; i<cblbtp.Items.Count; i++)
					{
						if(cblbtp.Items[i].Selected)
						{
							if(i+1<10)
								cblstr1=cblstr1+"0"+(i+1).ToString();
							else 
								cblstr1=cblstr1+(i+1).ToString();
						}
//						cblstr1=cblstr1+"0"+(i+1).ToString();
					}
					//存訂戶領域檔1_custitp
					for(int i=0; i<cblitp.Items.Count; i++)
					{
						if(cblitp.Items[i].Selected)
						{
							if(i+1<10)
								cblstr2=cblstr2+"0"+(i+1).ToString();
							else
								cblstr2=cblstr2+(i+1).ToString();
						}
//						cblstr2=cblstr2+"0"+(i+1).ToString();
					}
					for(int i=0;i<this.sqlInsertCommand1.Parameters.Count;i++)
					{
						this.sqlInsertCommand1.Parameters[i].Value = "";
					}
					//存訂戶檔1_cust
					this.sqlInsertCommand1.Parameters["@cust_btpcd"].Value = cblstr1;
					this.sqlInsertCommand1.Parameters["@cust_itpcd"].Value = cblstr2;
					this.sqlInsertCommand1.Parameters["@cust_custno"].Value = lblInvoiceid.Text;
					this.sqlInsertCommand1.Parameters["@cust_nm"].Value = tbxCustname.Text;
					if (rblJob.SelectedItem.Value=="自訂")
						this.sqlInsertCommand1.Parameters["@cust_jbti"].Value = tbxJob.Text;
					else
						this.sqlInsertCommand1.Parameters["@cust_jbti"].Value = rblJob.SelectedItem.Text;
					this.sqlInsertCommand1.Parameters["@cust_mfrno"].Value = tbxMfrno.Text;
					this.sqlInsertCommand1.Parameters["@cust_tel"].Value = tbxTel.Text;
					if(tbxFax.Text!="")
						this.sqlInsertCommand1.Parameters["@cust_fax"].Value = tbxFax.Text;
					if(tbxCell.Text!="")				
						this.sqlInsertCommand1.Parameters["@cust_cell"].Value = tbxCell.Text;
					if(tbxEmail.Text!="")
						this.sqlInsertCommand1.Parameters["@cust_email"].Value = tbxEmail.Text;
					date1=DateTime.Parse(tbxRegDate.Text);
					this.sqlInsertCommand1.Parameters["@cust_regdate"].Value = date1.ToString("yyyyMMdd");
					date1=System.DateTime.Today;
					this.sqlInsertCommand1.Parameters["@cust_moddate"].Value = date1.ToString("yyyyMMdd");
				
					this.sqlInsertCommand1.Parameters["@cust_fgoi"].Value = "0";
					this.sqlInsertCommand1.Parameters["@cust_fgoe"].Value = "0";
					this.sqlInsertCommand1.Parameters["@cust_otp1seq1"].Value = "000";
					this.sqlInsertCommand1.Parameters["@cust_otp1seq2"].Value = "000";
					this.sqlInsertCommand1.Parameters["@cust_otp1seq3"].Value = "000";
					this.sqlInsertCommand1.Parameters["@cust_otp1seq9"].Value = "000";
					this.sqlInsertCommand1.Connection.Open();
					this.sqlInsertCommand1.ExecuteNonQuery();
					this.sqlInsertCommand1.Connection.Close();
					Response.Redirect("SaveMessage.aspx?str=newcust");
				}
			}
		}

		private void rblJob_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(rblJob.SelectedItem.Value=="自訂"){
				tbxJob.Enabled=true;
				tbxJob.Text="請輸入";
			}
			else{
				tbxJob.Enabled=false;
				tbxJob.Text="";
			}
		}

	}
}
