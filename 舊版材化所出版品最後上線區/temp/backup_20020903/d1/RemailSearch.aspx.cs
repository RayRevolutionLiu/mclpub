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
	/// Summary description for RemailSearch.
	/// </summary>
	public class RemailSearch : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxCompanyname;
		protected System.Web.UI.WebControls.TextBox tbxMfrno;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxRecName;
		protected System.Web.UI.WebControls.TextBox tbxRecTel;
		protected System.Web.UI.WebControls.TextBox tbxRecAddr;
		protected System.Web.UI.WebControls.LinkButton lnbSearch;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.TextBox tbxOrderNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.RadioButtonList rblSent;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate1;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		public RemailSearch()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				if(Context.Request.QueryString["function1"]=="new")
				{
					rblSent.Enabled=false;
				}
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
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_remail WHERE (rm_custno = @rm_custno) AND (rm_oritem = @rm_ori" +
				"tem) AND (rm_otp1cd = @rm_otp1cd) AND (rm_otp1seq = @rm_otp1seq) AND (rm_syscd =" +
				" @rm_syscd) AND (rm_seq = @rm_seq)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT rm_rmid, rm_syscd, rm_custno, rm_otp1cd, rm_otp1seq, rm_oritem, rm_seq, rm" +
				"_cont, rm_date, rm_fgsent FROM dbo.c1_remail";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c1_remail.rm_rmid, dbo.c1_remail.rm_syscd, dbo.c1_remail.rm_custno, dbo.c1_remail.rm_otp1cd, dbo.c1_remail.rm_otp1seq, dbo.c1_remail.rm_oritem, dbo.c1_remail.rm_seq, dbo.c1_remail.rm_cont, dbo.c1_remail.rm_date, dbo.c1_remail.rm_fgsent, dbo.c1_otp.otp_otp1nm, dbo.c1_or.or_nm, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.c1_cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c1_or.or_addr, dbo.c1_or.or_tel, dbo.c1_remail.rm_syscd + dbo.c1_remail.rm_custno + dbo.c1_remail.rm_otp1cd + dbo.c1_remail.rm_otp1seq AS orderno, dbo.c1_otp.otp_otp2nm FROM dbo.c1_remail INNER JOIN dbo.c1_or ON dbo.c1_remail.rm_syscd = dbo.c1_or.or_syscd AND dbo.c1_remail.rm_custno = dbo.c1_or.or_custno AND dbo.c1_remail.rm_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_remail.rm_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_remail.rm_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.c1_cust ON dbo.c1_remail.rm_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_order ON dbo.c1_remail.rm_syscd = dbo.c1_order.o_syscd AND dbo.c1_remail.rm_custno = dbo.c1_order.o_custno AND dbo.c1_remail.rm_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_remail.rm_otp1seq = dbo.c1_order.o_otp1seq INNER JOIN dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_remail SET rm_syscd = @rm_syscd, rm_custno = @rm_custno, rm_otp1cd = @rm_otp1cd, rm_otp1seq = @rm_otp1seq, rm_oritem = @rm_oritem, rm_seq = @rm_seq, rm_cont = @rm_cont, rm_date = @rm_date, rm_fgsent = @rm_fgsent WHERE (rm_custno = @Original_rm_custno) AND (rm_oritem = @Original_rm_oritem) AND (rm_otp1cd = @Original_rm_otp1cd) AND (rm_otp1seq = @Original_rm_otp1seq) AND (rm_syscd = @Original_rm_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_cont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_cont", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_fgsent", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_remail", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("rm_rmid", "rm_rmid"),
																																																				   new System.Data.Common.DataColumnMapping("rm_syscd", "rm_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_custno", "rm_custno"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1cd", "rm_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1seq", "rm_otp1seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_oritem", "rm_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("rm_seq", "rm_seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_cont", "rm_cont"),
																																																				   new System.Data.Common.DataColumnMapping("rm_date", "rm_date"),
																																																				   new System.Data.Common.DataColumnMapping("rm_fgsent", "rm_fgsent")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO dbo.c1_remail(rm_syscd, rm_custno, rm_otp1cd, rm_otp1seq, rm_oritem, " +
				"rm_seq, rm_cont, rm_date, rm_fgsent) VALUES (@rm_syscd, @rm_custno, @rm_otp1cd, " +
				"@rm_otp1seq, @rm_oritem, @rm_seq, @rm_cont, @rm_date, @rm_fgsent)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_cont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_cont", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_fgsent", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_remail", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("rm_rmid", "rm_rmid"),
																																																				   new System.Data.Common.DataColumnMapping("rm_syscd", "rm_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_custno", "rm_custno"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1cd", "rm_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1seq", "rm_otp1seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_oritem", "rm_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("rm_seq", "rm_seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_cont", "rm_cont"),
																																																				   new System.Data.Common.DataColumnMapping("rm_date", "rm_date"),
																																																				   new System.Data.Common.DataColumnMapping("rm_fgsent", "rm_fgsent"),
																																																				   new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				   new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																				   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																				   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																				   new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				   new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				   new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				   new System.Data.Common.DataColumnMapping("orderno", "orderno"),
																																																				   new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_mfrno", "o_mfrno"),
																																																				  new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				  new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				  new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				  new System.Data.Common.DataColumnMapping("od_sdate", "od_sdate"),
																																																				  new System.Data.Common.DataColumnMapping("od_edate", "od_edate"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				  new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																				  new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																				  new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																				  new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				  new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				  new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																				  new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				  new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				  new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																				  new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("orderno", "orderno"),
																																																				  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_date", "o_date")})});
			this.lnbSearch.Click += new System.EventHandler(this.lnbSearch_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo." +
				"c1_order.o_mfrno, dbo.c1_or.or_nm, dbo.c1_or.or_addr, dbo.c1_or.or_tel, dbo.c1_o" +
				"d.od_sdate, dbo.c1_od.od_edate, dbo.c1_order.o_syscd, dbo.mfr.mfr_inm, dbo.c1_od" +
				".od_custno, dbo.c1_od.od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo." +
				"c1_od.od_syscd, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, d" +
				"bo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.mfr.mfr_mfrid, dbo.c1_obtp.obtp_obt" +
				"pnm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obtp.obtp_otp1cd, dbo.c1_otp.otp_otp1nm, db" +
				"o.c1_otp.otp_otp2cd, dbo.c1_otp.otp_otp1cd, dbo.c1_od.od_syscd + dbo.c1_od.od_cu" +
				"stno + dbo.c1_od.od_otp1cd + dbo.c1_od.od_otp1seq AS orderno, dbo.mfr.mfr_mfrno," +
				" dbo.c1_cust.cust_nm, dbo.c1_cust.cust_custno, dbo.c1_order.o_date FROM dbo.c1_o" +
				"rder INNER JOIN dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c" +
				"1_order.o_custno = dbo.c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_" +
				"otp1cd AND dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN dbo.mfr ON d" +
				"bo.c1_order.o_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_obtp ON dbo.c1_od.od_o" +
				"tp1cd = dbo.c1_obtp.obtp_otp1cd AND dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd" +
				" INNER JOIN dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo." +
				"c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd INNER JOIN dbo.c1_ramt ON dbo.c1_od.od" +
				"_syscd = dbo.c1_ramt.ra_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AN" +
				"D dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_" +
				"ramt.ra_otp1seq AND dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c" +
				"1_or ON dbo.c1_ramt.ra_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = db" +
				"o.c1_or.or_custno AND dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ram" +
				"t.ra_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_ori" +
				"tem INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno WH" +
				"ERE (dbo.c1_order.o_syscd = \'C1\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbSearch_Click(object sender, System.EventArgs e)
		{
			if(Context.Request.QueryString["function1"]=="new")
			{
				DataGrid1.CurrentPageIndex = 0;
				ShowCust();
			}
			else if(Context.Request.QueryString["function1"]=="mod")
			{
				DataGrid2.CurrentPageIndex = 0;
				DataGrid2_DataBind();
			}
		}

		private void ShowCust()
		{
			string	date1, date2;
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_order");
			DataView dv1 = ds1.Tables["c1_order"].DefaultView;
			string strbuf="1=1";
			if(tbxOrderNo.Text!="")
			{
				strbuf+=" and o_custno='"+tbxOrderNo.Text.Substring(2,6)+"'";
				strbuf+=" and o_otp1cd='"+tbxOrderNo.Text.Substring(8,2)+"'";
				strbuf+=" and o_otp1seq='"+tbxOrderNo.Text.Substring(10,3)+"'";
			}
			if(tbxCompanyname.Text!="")
				strbuf+=" and mfr_inm Like '"+tbxCompanyname.Text.Trim()+"%'";
			if(tbxMfrno.Text!="")
				strbuf+=" and o_mfrno Like '"+tbxMfrno.Text.Trim()+"%'";
			if(tbxCustNo.Text!="")
				//					if(tbxOrderNo.Text=="")
				strbuf+=" and o_custno = '"+tbxCustNo.Text.Trim()+"'";
			if(tbxCustName.Text!="")
				strbuf+=" and cust_nm Like '"+tbxCustName.Text.Trim()+"%'";
			if(tbxRecName.Text!="")
				strbuf+=" and or_nm Like '"+tbxRecName.Text.Trim()+"%'";
			if(tbxRecAddr.Text!="")
				strbuf+=" and or_addr Like '%"+tbxRecAddr.Text.Trim()+"%'";
			if(tbxRecTel.Text!="")
				strbuf+=" and or_tel="+tbxRecTel.Text;
			if(tbxOrderDate1.Text!="" && tbxOrderDate2.Text!="" )
			{
				date1=tbxOrderDate1.Text.Substring(0,4)+tbxOrderDate1.Text.Substring(5,2)+tbxOrderDate1.Text.Substring(8,2);
				date2=tbxOrderDate2.Text.Substring(0,4)+tbxOrderDate2.Text.Substring(5,2)+tbxOrderDate2.Text.Substring(8,2);
				strbuf+=" and (o_date>='"+date1+"' and o_date<='"+date2+"')";
			}
			//			string	str1=ddlYear.SelectedItem.Value.ToString().Trim()+ddlMonth.SelectedItem.Value.ToString().Trim();
			//			strbuf+=" and (substring(od_edate, 1, 6) BETWEEN "+str1+" and substring(od_sdate, 1, 6)<"+Int32.Parse(str1)+")";
			//			strbuf+=" and (substring(od_edate, 1, 6)>='"+str1+"' and substring(od_sdate, 1, 6)<='"+str1+"')";
			dv1.RowFilter=strbuf;
			if(dv1.Count==0)
			{
				lblMessage.Visible=true;
				lblMessage.Text="查無相關資料, 請重新設定條件再查詢";
			}
			else
			{
				lblMessage.Visible=false;
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
			}
		}

		private void DataGrid2_DataBind()
		{
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c1_remail");
			DataView dv2 = ds2.Tables["c1_remail"].DefaultView;
			string strbuf="";
			if(rblSent.SelectedItem.Value=="0")
				strbuf="rm_fgsent <> 'C'";
			else if(rblSent.SelectedItem.Value=="1")
				strbuf="rm_fgsent = 'C'";
			if(tbxOrderNo.Text!="")
			{
				strbuf+=" and rm_custno='"+tbxOrderNo.Text.Substring(2,6)+"'";
				strbuf+=" and rm_otp1cd='"+tbxOrderNo.Text.Substring(8,2)+"'";
				strbuf+=" and rm_otp1seq='"+tbxOrderNo.Text.Substring(10,3)+"'";
			}
			if(tbxCompanyname.Text!="")
				strbuf+=" and mfr_inm Like '"+tbxCompanyname.Text.Trim()+"%'";
			if(tbxMfrno.Text!="")
				strbuf+=" and cust_mfrno Like '"+tbxMfrno.Text.Trim()+"%'";
			if(tbxCustNo.Text!="")
				//					if(tbxOrderNo.Text=="")
				strbuf+=" and rm_custno = '"+tbxCustNo.Text.Trim()+"'";
			if(tbxCustName.Text!="")
				strbuf+=" and cust_nm Like '"+tbxCustName.Text.Trim()+"%'";
			if(tbxRecName.Text!="")
				strbuf+=" and or_nm Like '"+tbxRecName.Text.Trim()+"%'";
			if(tbxRecAddr.Text!="")
				strbuf+=" and or_addr Like '%"+tbxRecAddr.Text.Trim()+"%'";
			if(tbxRecTel.Text!="")
				strbuf+=" and or_tel="+tbxRecTel.Text.Trim();
			dv2.RowFilter=strbuf;
			lblMessage.Visible=true;
			DataGrid2.DataSource=dv2;
			DataGrid2.DataBind();
			if(dv2.Count==0)
			{
//				DataGrid2.Visible=false;
				lblMessage.Text="查無相關資料, 請重新設定條件再查詢";
			}
//			else
//			{
//				lblMessage.Text="已寄出之補書單不會列示";
//			}
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			string	strbuf;
			strbuf="RemailForm.aspx?id="+DataGrid1.SelectedItem.Cells[0].Text.Trim()+"&oritem="+DataGrid1.SelectedItem.Cells[4].Text.Trim()
				+"&date="+DataGrid1.SelectedItem.Cells[8].Text.Trim()+DataGrid1.SelectedItem.Cells[9].Text.Trim()+"&prepage=";
			if(e.CommandName=="Select")
				Response.Redirect(strbuf);
		}

		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid2.SelectedIndex=e.Item.ItemIndex;
			if(e.CommandName=="Select")
				Response.Redirect("RemailFM.aspx?id="+DataGrid2.SelectedItem.Cells[1].Text.Trim()+"&seq="+DataGrid2.SelectedItem.Cells[2].Text.Trim()+"&oritem="+DataGrid2.SelectedItem.Cells[7].Text.Trim());
		}

		private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			strbuf=DataGrid2.SelectedItem.Cells[1].Text.Trim();
			this.sqlDeleteCommand1.Parameters["@rm_syscd"].Value=strbuf.Substring(0,2);
			this.sqlDeleteCommand1.Parameters["@rm_custno"].Value=strbuf.Substring(2,6);
			this.sqlDeleteCommand1.Parameters["@rm_otp1cd"].Value=strbuf.Substring(8,2);
			this.sqlDeleteCommand1.Parameters["@rm_otp1seq"].Value=strbuf.Substring(10,3);
			this.sqlDeleteCommand1.Parameters["@rm_oritem"].Value=DataGrid2.SelectedItem.Cells[7].Text.Trim();
			this.sqlDeleteCommand1.Parameters["@rm_seq"].Value=DataGrid2.SelectedItem.Cells[2].Text.Trim();
			this.sqlDeleteCommand1.Connection.Open();
			this.sqlDeleteCommand1.ExecuteNonQuery();
			this.sqlDeleteCommand1.Connection.Close();
			DataGrid2_DataBind();
			DataGrid2.SelectedIndex=-1;
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowCust();
		}
	}
}
