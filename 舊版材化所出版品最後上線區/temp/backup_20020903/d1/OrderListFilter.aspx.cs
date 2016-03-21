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
	/// Summary description for OrderListFilter.
	/// </summary>
	public class OrderListFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DropDownList ddlPayType;
		protected System.Web.UI.WebControls.DropDownList ddlOrderType;
		protected System.Web.UI.WebControls.DropDownList ddlBookType;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.TextBox tbxRecName;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate1;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate2;
		protected System.Web.UI.WebControls.TextBox tbxDate1;
		protected System.Web.UI.WebControls.TextBox tbxDate2;
		protected System.Web.UI.WebControls.CheckBox cbx4;
		protected System.Web.UI.WebControls.CheckBox cbx5;
		protected System.Web.UI.WebControls.CheckBox cbx6;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
	
		public OrderListFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				//書籍類別
				DataSet	ds2=new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c1_obtp");
				DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
				dv2.RowFilter="obtp_otp1cd='"+ddlOrderType.SelectedItem.Value+"'";
				ddlBookType.DataSource=dv2;
				ddlBookType.DataTextField="obtp_obtpnm";
				ddlBookType.DataValueField="obtp_obtpcd";
				ddlBookType.DataBind();
				//付款方式
				DataSet	ds3=new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "pytp");
//				DataView dv3 = ds3.Tables["pytp"].DefaultView;
				ddlPayType.DataSource=ds3;
				ddlPayType.DataTextField="pytp_nm";
				ddlPayType.DataValueField="pytp_pytpcd";
				ddlPayType.DataBind();
//				Response.Write(Session["cname"].ToString());
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
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.ddlOrderType.SelectedIndexChanged += new System.EventHandler(this.ddlOrderType_SelectedIndexChanged);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = @"DELETE FROM dbo.srspn WHERE (srspn_empno = @srspn_empno) AND (srspn_atype = @srspn_atype) AND (srspn_cname = @srspn_cname) AND (srspn_date = @srspn_date) AND (srspn_deptcd = @srspn_deptcd) AND (srspn_id = @srspn_id) AND (srspn_orgcd = @srspn_orgcd) AND (srspn_pwd = @srspn_pwd) AND (srspn_tel = @srspn_tel)";
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_id", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO dbo.srspn(srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd) VALUES (@srspn_empno, @srspn_cname, @srspn_tel, @srspn_atype, @srspn_orgcd, @srspn_deptcd, @srspn_date, @srspn_pwd); SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn WHERE (srspn_empno = @Select_srspn_empno)";
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pytp", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT pytp_pytpcd, pytp_nm FROM dbo.pytp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_obtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpid", "obtp_obtpid"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter5.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_pwd", "srspn_pwd")})});
			this.sqlDataAdapter5.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.srspn SET srspn_empno = @srspn_empno, srspn_cname = @srspn_cname, srspn_tel = @srspn_tel, srspn_atype = @srspn_atype, srspn_orgcd = @srspn_orgcd, srspn_deptcd = @srspn_deptcd, srspn_date = @srspn_date, srspn_pwd = @srspn_pwd WHERE (srspn_empno = @Original_srspn_empno) AND (srspn_atype = @Original_srspn_atype) AND (srspn_cname = @Original_srspn_cname) AND (srspn_date = @Original_srspn_date) AND (srspn_deptcd = @Original_srspn_deptcd) AND (srspn_orgcd = @Original_srspn_orgcd) AND (srspn_pwd = @Original_srspn_pwd) AND (srspn_tel = @Original_srspn_tel); SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn WHERE (srspn_empno = @Select_srspn_empno)";
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_atype", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_atype", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_cname", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_date", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_deptcd", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_deptcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_orgcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_orgcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_pwd", System.Data.SqlDbType.Char, 14, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_pwd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_srspn_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_tel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_srspn_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "srspn_empno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter4.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tmp_list1", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("id", "id"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_no", "tmp_no"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_pytpnm", "tmp_pytpnm"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_fgpreinv", "tmp_fgpreinv"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_obtpnm", "tmp_obtpnm"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_datestr", "tmp_datestr"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_amt", "tmp_amt"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_nm", "tmp_nm"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_inm", "tmp_inm"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_zip", "tmp_zip"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_addr", "tmp_addr"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_tel", "tmp_tel"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_mnt", "tmp_mnt"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_rmcont", "tmp_rmcont"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_rmdate", "tmp_rmdate"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_cname", "tmp_cname"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_obtpcd", "tmp_obtpcd"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_pyno", "tmp_pyno"),
																																																				   new System.Data.Common.DataColumnMapping("tmp_custtp", "tmp_custtp")})});
			this.sqlDataAdapter4.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_od", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("od_odid", "od_odid"),
																																																			   new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																			   new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																			   new System.Data.Common.DataColumnMapping("od_sdate", "od_sdate"),
																																																			   new System.Data.Common.DataColumnMapping("od_edate", "od_edate"),
																																																			   new System.Data.Common.DataColumnMapping("od_btpcd", "od_btpcd"),
																																																			   new System.Data.Common.DataColumnMapping("od_amt", "od_amt"),
																																																			   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																			   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																			   new System.Data.Common.DataColumnMapping("ra_mnt", "ra_mnt"),
																																																			   new System.Data.Common.DataColumnMapping("o_pytpcd", "o_pytpcd"),
																																																			   new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("ra_oditem", "ra_oditem"),
																																																			   new System.Data.Common.DataColumnMapping("ra_oritem", "ra_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																			   new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("ra_custno", "ra_custno"),
																																																			   new System.Data.Common.DataColumnMapping("ra_otp1cd", "ra_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("ra_otp1seq", "ra_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("ra_syscd", "ra_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			   new System.Data.Common.DataColumnMapping("o_date", "o_date"),
																																																			   new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm"),
																																																			   new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																			   new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																			   new System.Data.Common.DataColumnMapping("datestr", "datestr"),
																																																			   new System.Data.Common.DataColumnMapping("o_fgpreinv", "o_fgpreinv"),
																																																			   new System.Data.Common.DataColumnMapping("o_indate", "o_indate"),
																																																			   new System.Data.Common.DataColumnMapping("o_empno", "o_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																			   new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			   new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("od_custtp", "od_custtp")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c1_od.od_odid, dbo.c1_od.od_syscd, dbo.c1_od.od_custno, dbo.c1_od.od_o" +
				"tp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_oditem, dbo.c1_od.od_sdate, dbo.c1_od." +
				"od_edate, dbo.c1_od.od_btpcd, dbo.c1_od.od_amt, dbo.c1_or.or_inm, dbo.c1_or.or_n" +
				"m, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_tel, dbo.c1_ramt.ra_mnt, db" +
				"o.c1_order.o_pytpcd, dbo.c1_order.o_otp1seq, dbo.c1_ramt.ra_oditem, dbo.c1_ramt." +
				"ra_oritem, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_syscd, d" +
				"bo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1s" +
				"eq, dbo.c1_or.or_syscd, dbo.c1_ramt.ra_custno, dbo.c1_ramt.ra_otp1cd, dbo.c1_ram" +
				"t.ra_otp1seq, dbo.c1_ramt.ra_syscd, dbo.c1_od.od_syscd + dbo.c1_od.od_custno + d" +
				"bo.c1_od.od_otp1cd + dbo.c1_od.od_otp1seq AS nostr, dbo.c1_order.o_date, dbo.pyt" +
				"p.pytp_nm, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obtp.obtp_ot" +
				"p1cd, dbo.pytp.pytp_pytpcd, dbo.c1_od.od_sdate + \'~\' + dbo.c1_od.od_edate AS dat" +
				"estr, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_indate, dbo.c1_order.o_empno, dbo." +
				"srspn.srspn_cname, dbo.srspn.srspn_empno, dbo.ia.ia_pyno, dbo.ia.ia_iano, dbo.ia" +
				".ia_syscd, dbo.c1_od.od_custtp FROM dbo.c1_od INNER JOIN dbo.c1_order ON dbo.c1_" +
				"od.od_syscd = dbo.c1_order.o_syscd AND dbo.c1_od.od_custno = dbo.c1_order.o_cust" +
				"no AND dbo.c1_od.od_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_od.od_otp1seq = db" +
				"o.c1_order.o_otp1seq INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt." +
				"ra_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND dbo.c1_od.od_otp1cd" +
				" = dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND d" +
				"bo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c1_or ON dbo.c1_ramt.r" +
				"a_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = dbo.c1_or.or_custno AND" +
				" dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ramt.ra_otp1seq = dbo.c1" +
				"_or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_oritem LEFT OUTER JOIN d" +
				"bo.ia ON dbo.c1_order.o_iano = dbo.ia.ia_iano LEFT OUTER JOIN dbo.srspn ON dbo.c" +
				"1_order.o_empno = dbo.srspn.srspn_empno LEFT OUTER JOIN dbo.c1_obtp ON dbo.c1_od" +
				".od_btpcd = dbo.c1_obtp.obtp_obtpcd AND dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_o" +
				"tp1cd LEFT OUTER JOIN dbo.pytp ON dbo.c1_order.o_pytpcd = dbo.pytp.pytp_pytpcd W" +
				"HERE (dbo.c1_od.od_syscd = \'C1\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT id, tmp_no, tmp_pytpnm, tmp_fgpreinv, tmp_obtpnm, tmp_datestr, tmp_amt, tm" +
				"p_nm, tmp_inm, tmp_zip, tmp_addr, tmp_tel, tmp_mnt, tmp_rmcont, tmp_rmdate, tmp_" +
				"cname, tmp_obtpcd, tmp_pyno, tmp_custtp FROM dbo.tmp_list1";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.tmp_list1(tmp_no, tmp_pytpnm, tmp_fgpreinv, tmp_obtpnm, tmp_datestr, tmp_amt, tmp_nm, tmp_inm, tmp_zip, tmp_addr, tmp_tel, tmp_mnt, tmp_rmcont, tmp_rmdate, tmp_cname, tmp_obtpcd, tmp_pyno, tmp_custtp) VALUES (@tmp_no, @tmp_pytpnm, @tmp_fgpreinv, @tmp_obtpnm, @tmp_datestr, @tmp_amt, @tmp_nm, @tmp_inm, @tmp_zip, @tmp_addr, @tmp_tel, @tmp_mnt, @tmp_rmcont, @tmp_rmdate, @tmp_cname, @tmp_obtpcd, @tmp_pyno, @tmp_custtp)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_no", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_no", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_pytpnm", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_pytpnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_fgpreinv", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_obtpnm", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_obtpnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_datestr", System.Data.SqlDbType.Char, 21, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_datestr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_amt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_inm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_zip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_addr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_tel", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_mnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_mnt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_rmcont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_rmcont", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_rmdate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_rmdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_cname", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_cname", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_obtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_obtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_custtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_custtp", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.tmp_list1 SET tmp_no = @tmp_no, tmp_pytpnm = @tmp_pytpnm, tmp_fgpreinv = @tmp_fgpreinv, tmp_obtpnm = @tmp_obtpnm, tmp_datestr = @tmp_datestr, tmp_amt = @tmp_amt, tmp_nm = @tmp_nm, tmp_inm = @tmp_inm, tmp_zip = @tmp_zip, tmp_addr = @tmp_addr, tmp_tel = @tmp_tel, tmp_mnt = @tmp_mnt, tmp_rmcont = @tmp_rmcont, tmp_rmdate = @tmp_rmdate, tmp_cname = @tmp_cname, tmp_obtpcd = @tmp_obtpcd, tmp_pyno = @tmp_pyno, tmp_custtp = @tmp_custtp WHERE (id = @Original_id)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_no", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_no", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_pytpnm", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_pytpnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_fgpreinv", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_obtpnm", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_obtpnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_datestr", System.Data.SqlDbType.Char, 21, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_datestr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_amt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_inm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_zip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_addr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_tel", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_mnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_mnt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_rmcont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_rmcont", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_rmdate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_rmdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_cname", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_cname", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_obtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_obtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_custtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_custtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.tmp_list1";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlOrderType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			//書籍類別
			DataSet	ds2=new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c1_obtp");
			DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
			dv2.RowFilter="obtp_otp1cd='"+ddlOrderType.SelectedItem.Value+"'";
			ddlBookType.DataSource=dv2;
			ddlBookType.DataTextField="obtp_obtpnm";
			ddlBookType.DataValueField="obtp_obtpcd";
			ddlBookType.DataBind();

		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string	strbuf="1=1";
			string	date1, date2;
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_od");
			DataView dv1 = ds1.Tables["c1_od"].DefaultView;
			if(cbx1.Checked)
				strbuf+=" and o_pytpcd='"+ddlPayType.SelectedItem.Value.Trim()+"'";
			if(cbx2.Checked){
				date1=tbxOrderDate1.Text.Substring(0,4)+tbxOrderDate1.Text.Substring(5,2)+tbxOrderDate1.Text.Substring(8,2);
				date2=tbxOrderDate2.Text.Substring(0,4)+tbxOrderDate2.Text.Substring(5,2)+tbxOrderDate2.Text.Substring(8,2);
				strbuf+=" and (o_date>='"+date1+"' and o_date<='"+date2+"')";
			}
			if(cbx3.Checked)
			{
				date1=tbxDate1.Text.Substring(0,4)+tbxDate1.Text.Substring(5,2)+tbxDate1.Text.Substring(8,2);
				date2=tbxDate2.Text.Substring(0,4)+tbxDate2.Text.Substring(5,2)+tbxDate2.Text.Substring(8,2);
				strbuf+=" and (o_indate>='"+date1+"' and o_indate<='"+date2+"')";
			}
			if(cbx4.Checked)
				strbuf+=" and od_otp1cd='"+ddlOrderType.SelectedItem.Value.Trim()+"'";
			if(cbx5.Checked)
				strbuf+=" and od_btpcd='"+ddlBookType.SelectedItem.Value.Trim()+"'";
			if(cbx6.Checked)
				strbuf+=" and or_nm LIKE '%"+tbxRecName.Text.Trim()+"%'";
			dv1.RowFilter=strbuf;
			if(dv1.Count==0)
			{
				lblMessage.Text="查無資料, 請重設查詢條件";
				DataGrid1.Visible=false;
			}
			else
			{
				DataGrid1.Visible=true;
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
				//將tmp_list1資料清空
				this.sqlDeleteCommand1.Connection.Open();
				this.sqlDeleteCommand1.ExecuteNonQuery();
				this.sqlDeleteCommand1.Connection.Close();
				for(int i=0; i<dv1.Count; i++)
				{
					this.sqlInsertCommand1.Parameters["@tmp_no"].Value=dv1[i].Row["nostr"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_pytpnm"].Value=dv1[i].Row["pytp_nm"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_fgpreinv"].Value=dv1[i].Row["o_fgpreinv"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_obtpnm"].Value=dv1[i].Row["obtp_obtpnm"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_obtpcd"].Value=dv1[i].Row["obtp_obtpcd"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_datestr"].Value=dv1[i].Row["datestr"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_amt"].Value=dv1[i].Row["od_amt"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_nm"].Value=dv1[i].Row["or_nm"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_inm"].Value=dv1[i].Row["or_inm"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_zip"].Value=dv1[i].Row["or_zip"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_addr"].Value=dv1[i].Row["or_addr"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_tel"].Value=dv1[i].Row["or_tel"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_mnt"].Value=dv1[i].Row["ra_mnt"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_rmcont"].Value="";//dv1[i].Row["rm_cont"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_rmdate"].Value="";//dv1[i].Row["rm_date"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_cname"].Value=dv1[i].Row["srspn_cname"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_pyno"].Value=dv1[i].Row["ia_pyno"].ToString().Trim();
					this.sqlInsertCommand1.Parameters["@tmp_custtp"].Value=dv1[i].Row["od_custtp"].ToString().Trim();
					this.sqlInsertCommand1.Connection.Open();
					this.sqlInsertCommand1.ExecuteNonQuery();
					this.sqlInsertCommand1.Connection.Close();
				}
				btnPrintList.Enabled=true;
			}
		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter5.Fill(ds1, "srspn");
			DataView dv1 = ds1.Tables["srspn"].DefaultView;
			dv1.RowFilter="srspn_empno = '"+reg+"'";
			if(dv1.Count>0)
			{
				string	cname=dv1[0].Row["srspn_cname"].ToString().Trim();
				string	strbuf="od_list1.aspx?cname="+cname;
				if(cbx2.Checked)
					strbuf+="&date="+tbxOrderDate1.Text.Trim()+"~"+tbxOrderDate2.Text.Trim();
				else
					strbuf+="&date=";
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
			else
				lblMessage.Text="您沒有權限列印此份報表";
		}
	}
}
