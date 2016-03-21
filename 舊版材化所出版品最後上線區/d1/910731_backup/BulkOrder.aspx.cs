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
	/// Summary description for BulkOrder.
	/// </summary>
	public class BulkOrder : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Literal literal1;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button btnCheckAll;
		protected System.Web.UI.WebControls.DropDownList ddlBook;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.TextBox tbxStartDate;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.TextBox tbxCompanyname;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox tbxContinueDate;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
	
		public BulkOrder()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires=0;
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c1_obtp");
				DataView dv3 = ds3.Tables["c1_obtp"].DefaultView;
				dv3.RowFilter="obtp_otp1cd='02'";
				ddlBook.DataSource=dv3;
				ddlBook.DataTextField="obtp_obtpnm";
				ddlBook.DataValueField="obtp_obtpcd";
				ddlBook.DataBind();
				DateTime	date1;
				date1=System.DateTime.Today;
				date1=date1.AddYears(1);
				tbxContinueDate.Text=date1.ToString("yyyy/MM/dd");
//				myDataBind();
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
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			this.DataList1.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_ItemCommand);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_order WHERE (o_custno = @o_custno) AND (o_otp1cd = @o_otp1cd) " +
				"AND (o_otp1seq = @o_otp1seq) AND (o_syscd = @o_syscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter4.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_od", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("od_edate", "od_edate"),
																																																			   new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																			   new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																			   new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("od_btpcd", "od_btpcd")})});
			this.sqlDataAdapter4.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM dbo.c1_od WHERE (od_custno = @od_custno) AND (od_oditem = @od_oditem)" +
				" AND (od_otp1cd = @od_otp1cd) AND (od_otp1seq = @od_otp1seq) AND (od_syscd = @od" +
				"_syscd)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_oditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_oditem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO dbo.c1_od(od_edate, od_custno, od_oditem, od_otp1cd, od_otp1seq, od_s" +
				"yscd, od_btpcd) VALUES (@od_edate, @od_custno, @od_oditem, @od_otp1cd, @od_otp1s" +
				"eq, @od_syscd, @od_btpcd)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_edate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_edate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_oditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_oditem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_btpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_btpcd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT od_edate, od_custno, od_oditem, od_otp1cd, od_otp1seq, od_syscd, od_btpcd " +
				"FROM dbo.c1_od WHERE (od_syscd = \'C1\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.c1_od SET od_edate = @od_edate, od_custno = @od_custno, od_oditem = @od_oditem, od_otp1cd = @od_otp1cd, od_otp1seq = @od_otp1seq, od_syscd = @od_syscd, od_btpcd = @od_btpcd WHERE (od_custno = @Original_od_custno) AND (od_oditem = @Original_od_oditem) AND (od_otp1cd = @Original_od_otp1cd) AND (od_otp1seq = @Original_od_otp1seq) AND (od_syscd = @Original_od_syscd)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_edate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_edate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_oditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_oditem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_btpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_btpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_od_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_od_oditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_oditem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_od_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_od_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_od_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT o_xmldata, o_moddate, o_custno, o_otp1cd, o_otp1seq, o_syscd FROM dbo.c1_o" +
				"rder WHERE (o_syscd = \'C1\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_order.o_oid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c1_order.o_inm, dbo.c1_order.o_ijbti, dbo.c1_order.o_iaddr, dbo.c1_order.o_izip, dbo.c1_order.o_itel, dbo.c1_order.o_ifax, dbo.c1_order.o_icell, dbo.c1_order.o_iemail, dbo.c1_order.o_pytpcd, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_date, dbo.c1_order.o_moddate, dbo.c1_order.o_oldvdate, dbo.c1_order.o_empno, dbo.c1_order.o_xmldata, dbo.c1_order.o_orescd, dbo.c1_order.o_invcd, dbo.c1_order.o_taxtp, dbo.c1_cust.cust_nm, dbo.c1_cust.cust_custno, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrid, dbo.c1_cust.cust_tel, dbo.c1_od.od_btpcd, dbo.c1_od.od_sdate, dbo.c1_od.od_edate, dbo.c1_od.od_custno, dbo.c1_od.od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_syscd, dbo.mfr.mfr_mfrno FROM dbo.c1_order INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ON dbo.c1_order.o_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c1_order.o_custno = dbo.c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq WHERE (dbo.c1_order.o_syscd = 'C1')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_xmldata", "o_xmldata"),
																																																				  new System.Data.Common.DataColumnMapping("o_moddate", "o_moddate"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO dbo.c1_order(o_xmldata, o_moddate, o_custno, o_otp1cd, o_otp1seq, o_s" +
				"yscd) VALUES (@o_xmldata, @o_moddate, @o_custno, @o_otp1cd, @o_otp1seq, @o_syscd" +
				")";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_order SET o_xmldata = @o_xmldata, o_moddate = @o_moddate, o_custno = @o_custno, o_otp1cd = @o_otp1cd, o_otp1seq = @o_otp1seq, o_syscd = @o_syscd WHERE (o_custno = @Original_o_custno) AND (o_otp1cd = @Original_o_otp1cd) AND (o_otp1seq = @Original_o_otp1seq) AND (o_syscd = @Original_o_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 5000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_obtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpid", "obtp_obtpid"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				  new System.Data.Common.DataColumnMapping("od_btpcd", "od_btpcd"),
																																																				  new System.Data.Common.DataColumnMapping("od_sdate", "od_sdate"),
																																																				  new System.Data.Common.DataColumnMapping("od_edate", "od_edate"),
																																																				  new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																				  new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																				  new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataList1_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			string	strbuf;
//			DataList1.SelectedItem=e.Item.ItemIndex;
//			myDataBind();
			if(e.CommandName=="Detail")
			{
//				text1.Value=((HtmlInputHidden)e.Item.FindControl("hiddenXml")).Value;
//				Response.Write("test");
//				Response.Write(((Label)e.Item.FindControl("lblNo")).Text);
				strbuf="ShowOrder.aspx?id="+((Label)e.Item.FindControl("lblNo")).Text+"&type1=02&seq="+((Label)e.Item.FindControl("lblSeq")).Text;
				literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\",null,\"height=500,width=750,status=no,scrollbars=yes,toolbar=no,menubar=no,\");</script>";
			}
		}
		private void myDataBind()
		{
			DateTime	date1, date2;
			date1=System.DateTime.Today;
			date2=date1.AddYears(-1);
			string StartDate, EndDate;
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_order");
			DataView dv1 = ds1.Tables["c1_order"].DefaultView;
			string	strbuf="o_otp1cd='02' and od_btpcd='"+ddlBook.SelectedItem.Value+"'";
			if(tbxStartDate.Text=="")
				StartDate=date2.ToString("yyyyMMdd");
			else
				StartDate=tbxStartDate.Text.Substring(0,4)+tbxStartDate.Text.Substring(5,2)+tbxStartDate.Text.Substring(8,2);
			if(tbxEndDate.Text=="")
				EndDate=date1.ToString("yyyyMMdd");
			else
				EndDate=tbxEndDate.Text.Substring(0,4)+tbxEndDate.Text.Substring(5,2)+tbxEndDate.Text.Substring(8,2);
			strbuf+=" and ((od_sdate<'"+StartDate+"' and od_edate>'"+StartDate+"') or (od_sdate<'"+EndDate+"' and od_edate>'"+EndDate+"')"+
				" or (od_sdate<'"+StartDate+"' and od_edate>'"+EndDate+"'))";
			if(tbxCompanyname.Text!="")
				strbuf+=" and mfr_inm Like '%"+tbxCompanyname.Text+"%'";
			dv1.RowFilter=strbuf;
//			for(int i=0; i<dv1.Count; i++)
//				dv1.Table.Rows[i]["o_fgpreinv"]="0";
			DataList1.DataSource=dv1;
			DataList1.DataBind();
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible=true;
			literal1.Text="";
			myDataBind();
		}

		private void btnCheckAll_Click(object sender, System.EventArgs e)
		{
			literal1.Text="";
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked=true;
			}

		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			literal1.Text="";
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
				{
					XmlDocument XmlDoc1 = new System.Xml.XmlDocument();
					XmlNode	ItemOrder1;
					XmlNode	ItemDetail1;
					XmlDoc1.LoadXml(((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXml")).Value);
					ItemOrder1=XmlDoc1.SelectSingleNode("/root/訂單");
					ItemDetail1=XmlDoc1.SelectSingleNode("/root/訂單明細");
					for(int j=0; j<ItemDetail1.ChildNodes.Count; j++)
					{   
						if(ItemDetail1.ChildNodes.Item(j).SelectSingleNode("書籍類別").InnerText.Substring(0,2)==ddlBook.SelectedItem.Value)
						{
							ItemDetail1.ChildNodes.Item(j).SelectSingleNode("訂閱訖時").InnerXml=tbxContinueDate.Text;
							this.sqlUpdateCommand2.Parameters["@Original_od_syscd"].Value="C1";
							this.sqlUpdateCommand2.Parameters["@Original_od_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
							this.sqlUpdateCommand2.Parameters["@Original_od_otp1cd"].Value="02";	//贈閱
							this.sqlUpdateCommand2.Parameters["@Original_od_otp1seq"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
							this.sqlUpdateCommand2.Parameters["@Original_od_oditem"].Value=ItemDetail1.ChildNodes.Item(j).SelectSingleNode("項次").InnerXml;
							this.sqlUpdateCommand2.Parameters["@od_syscd"].Value="C1";
							this.sqlUpdateCommand2.Parameters["@od_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
							this.sqlUpdateCommand2.Parameters["@od_otp1cd"].Value="02";	//贈閱
							this.sqlUpdateCommand2.Parameters["@od_otp1seq"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
							this.sqlUpdateCommand2.Parameters["@od_oditem"].Value=ItemDetail1.ChildNodes.Item(j).SelectSingleNode("項次").InnerXml;
							this.sqlUpdateCommand2.Parameters["@od_btpcd"].Value=ddlBook.SelectedItem.Value;
							this.sqlUpdateCommand2.Parameters["@od_edate"].Value=tbxContinueDate.Text.Substring(0,4)+tbxContinueDate.Text.Substring(5,2)+tbxContinueDate.Text.Substring(8,2);
							this.sqlUpdateCommand2.CommandText=@"UPDATE dbo.c1_od SET od_edate = @od_edate WHERE (od_custno = @Original_od_custno) AND (od_oditem = @Original_od_oditem) AND (od_otp1cd = @Original_od_otp1cd) AND (od_otp1seq = @Original_od_otp1seq) AND (od_syscd = @Original_od_syscd) AND (od_btpcd = @od_btpcd)";
							this.sqlUpdateCommand2.Connection.Open();
							this.sqlUpdateCommand2.ExecuteNonQuery();
							this.sqlUpdateCommand2.Connection.Close();
						}
					} 
//					text1.Value=((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXml")).Value;
//					text1.Value=XmlDoc1.OuterXml;
					this.sqlUpdateCommand1.Parameters["@Original_o_syscd"].Value="C1";
					this.sqlUpdateCommand1.Parameters["@Original_o_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
					this.sqlUpdateCommand1.Parameters["@Original_o_otp1cd"].Value="02";	//贈閱
					this.sqlUpdateCommand1.Parameters["@Original_o_otp1seq"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
					this.sqlUpdateCommand1.Parameters["@o_syscd"].Value="C1";
					this.sqlUpdateCommand1.Parameters["@o_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
					this.sqlUpdateCommand1.Parameters["@o_otp1cd"].Value="02";		//贈閱
					this.sqlUpdateCommand1.Parameters["@o_otp1seq"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
					this.sqlUpdateCommand1.Parameters["@o_xmldata"].Value=XmlDoc1.OuterXml;
					this.sqlUpdateCommand1.Parameters["@o_moddate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
//					this.sqlUpdateCommand1.CommandText=@"UPDATE dbo.c1_order SET o_xmldata = @o_xmldata, o_moddate = @o_moddate WHERE (o_custno = @Original_o_custno) AND (o_otp1cd = @Original_o_otp1cd) AND (o_otp1seq = @Original_o_otp1seq) AND (o_syscd = @Original_o_syscd)";
					this.sqlUpdateCommand1.Connection.Open();
					this.sqlUpdateCommand1.ExecuteNonQuery();
					this.sqlUpdateCommand1.Connection.Close();
		
				}
			}
			Response.Redirect("SaveMessage.aspx?str=bulk");
		}
	}
}
