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
	/// Summary description for LostSearch.
	/// </summary>
	public class LostSearch : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxCompanyname;
		protected System.Web.UI.WebControls.TextBox tbxMfrno;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxRecName;
		protected System.Web.UI.WebControls.TextBox tbxRecTel;
		protected System.Web.UI.WebControls.TextBox tbxRecAddr;
		protected System.Web.UI.WebControls.LinkButton lnbSearch;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.TextBox tbxOrderNo;
		protected System.Web.UI.WebControls.RadioButtonList rblSent;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
	
		public LostSearch()
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.lnbSearch.Click += new System.EventHandler(this.lnbSearch_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_lost WHERE (lst_custno = @lst_custno) AND (lst_oritem = @lst_o" +
				"ritem) AND (lst_otp1cd = @lst_otp1cd) AND (lst_otp1seq = @lst_otp1seq) AND (lst_" +
				"syscd = @lst_syscd) AND (lst_seq = @lst_seq)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT lst_lstid, lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_oritem, lst" +
				"_seq, lst_cont, lst_date, lst_rea, lst_fgsent FROM dbo.c1_lost";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c1_lost.lst_lstid, dbo.c1_lost.lst_syscd, dbo.c1_lost.lst_custno, dbo.c1_lost.lst_otp1cd, dbo.c1_lost.lst_otp1seq, dbo.c1_lost.lst_oritem, dbo.c1_lost.lst_seq, dbo.c1_lost.lst_cont, dbo.c1_lost.lst_date, dbo.c1_lost.lst_rea, dbo.c1_lost.lst_fgsent, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.c1_or.or_nm, dbo.c1_lost.lst_syscd + dbo.c1_lost.lst_custno + dbo.c1_lost.lst_otp1cd + dbo.c1_lost.lst_otp1seq AS orderno, dbo.c1_cust.cust_custno, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd, dbo.mfr.mfr_mfrno FROM dbo.c1_lost INNER JOIN dbo.c1_order ON dbo.c1_lost.lst_syscd = dbo.c1_order.o_syscd AND dbo.c1_lost.lst_custno = dbo.c1_order.o_custno AND dbo.c1_lost.lst_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_order.o_otp1seq INNER JOIN dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd INNER JOIN dbo.c1_cust ON dbo.c1_lost.lst_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_or ON dbo.c1_lost.lst_syscd = dbo.c1_or.or_syscd AND dbo.c1_lost.lst_custno = dbo.c1_or.or_custno AND dbo.c1_lost.lst_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_lost.lst_oritem = dbo.c1_or.or_oritem";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo." +
				"c1_or.or_nm, dbo.c1_or.or_addr, dbo.c1_or.or_tel, dbo.c1_od.od_sdate, dbo.c1_od." +
				"od_edate, dbo.c1_order.o_syscd, dbo.mfr.mfr_inm, dbo.c1_od.od_custno, dbo.c1_od." +
				"od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_syscd, dbo.c1" +
				"_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, d" +
				"bo.c1_or.or_syscd, dbo.mfr.mfr_mfrid, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_" +
				"obtpcd, dbo.c1_obtp.obtp_otp1cd, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2cd, d" +
				"bo.c1_otp.otp_otp1cd, dbo.c1_od.od_syscd + dbo.c1_od.od_custno + dbo.c1_od.od_ot" +
				"p1cd + dbo.c1_od.od_otp1seq AS orderno, dbo.mfr.mfr_mfrno, dbo.c1_order.o_date, " +
				"dbo.c1_cust.cust_nm, dbo.c1_cust.cust_custno FROM dbo.c1_order INNER JOIN dbo.c1" +
				"_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c1_order.o_custno = dbo" +
				".c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_orde" +
				"r.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN dbo.mfr ON dbo.c1_order.o_mfrno = " +
				"dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.ob" +
				"tp_otp1cd AND dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd INNER JOIN dbo.c1_otp" +
				" ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo.c1_order.o_otp2cd = db" +
				"o.c1_otp.otp_otp2cd INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.r" +
				"a_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND dbo.c1_od.od_otp1cd " +
				"= dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND db" +
				"o.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c1_or ON dbo.c1_ramt.ra" +
				"_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = dbo.c1_or.or_custno AND " +
				"dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ramt.ra_otp1seq = dbo.c1_" +
				"or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.c1_" +
				"cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno WHERE (dbo.c1_order.o_sy" +
				"scd = \'C1\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_lstid", "lst_lstid"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_custno", "lst_custno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_otp1cd", "lst_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_otp1seq", "lst_otp1seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				 new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("orderno", "orderno")})});
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_lstid", "lst_lstid"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_custno", "lst_custno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_otp1cd", "lst_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_otp1seq", "lst_otp1seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.c1_lost(lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_oritem, lst_seq, lst_cont, lst_date, lst_rea, lst_fgsent) VALUES (@lst_syscd, @lst_custno, @lst_otp1cd, @lst_otp1seq, @lst_oritem, @lst_seq, @lst_cont, @lst_date, @lst_rea, @lst_fgsent); SELECT lst_lstid, lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_oritem, lst_seq, lst_cont, lst_date, lst_rea, lst_fgsent FROM dbo.c1_lost WHERE (lst_custno = @Select_lst_custno) AND (lst_oritem = @Select_lst_oritem) AND (lst_otp1cd = @Select_lst_otp1cd) AND (lst_otp1seq = @Select_lst_otp1seq) AND (lst_syscd = @Select_lst_syscd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_cont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_cont", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_rea", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_rea", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_fgsent", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_lost SET lst_syscd = @lst_syscd, lst_custno = @lst_custno, lst_otp1cd = @lst_otp1cd, lst_otp1seq = @lst_otp1seq, lst_oritem = @lst_oritem, lst_seq = @lst_seq, lst_cont = @lst_cont, lst_date = @lst_date, lst_rea = @lst_rea, lst_fgsent = @lst_fgsent WHERE (lst_custno = @Original_lst_custno) AND (lst_oritem = @Original_lst_oritem) AND (lst_otp1cd = @Original_lst_otp1cd) AND (lst_otp1seq = @Original_lst_otp1seq) AND (lst_syscd = @Original_lst_syscd); SELECT lst_lstid, lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_oritem, lst_seq, lst_cont, lst_date, lst_rea, lst_fgsent FROM dbo.c1_lost WHERE (lst_custno = @Select_lst_custno) AND (lst_oritem = @Select_lst_oritem) AND (lst_otp1cd = @Select_lst_otp1cd) AND (lst_otp1seq = @Select_lst_otp1seq) AND (lst_syscd = @Select_lst_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_cont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_cont", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_rea", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_rea", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_fgsent", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
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
																																																				  new System.Data.Common.DataColumnMapping("o_date", "o_date"),
																																																				  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm")})});
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
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c1_order");
			DataView dv = ds.Tables["c1_order"].DefaultView;
//			string strbuf="obtp_obtpnm Like '"+ddlBookType.SelectedItem.Text.Trim()+"%'";
			string strbuf="1=1";
			if(tbxCompanyname.Text!="")
				strbuf+=" and mfr_inm Like '%"+tbxCompanyname.Text.Trim()+"%'";
			if(tbxMfrno.Text!="")
				strbuf+=" and o_mfrno = '"+tbxMfrno.Text.Trim()+"'";
			if(tbxCustNo.Text!="")
				strbuf+=" and o_custno = '"+tbxCustNo.Text+"'";
			if(tbxCustName.Text!="")
				strbuf+=" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			if(tbxRecName.Text!="")
				strbuf+=" and or_nm Like '%"+tbxRecName.Text.Trim()+"%'";
			if(tbxRecAddr.Text!="")
				strbuf+=" and or_addr Like '%"+tbxRecAddr.Text.Trim()+"%'";
			if(tbxRecTel.Text!="")
				strbuf+=" and or_tel='"+tbxRecTel.Text.Trim()+"'";
			dv.RowFilter=strbuf;
			if(dv.Count==0)
			{
				lblMessage.Visible=true;
				lblMessage.Text="查無相關資料, 請重新設定條件再查詢";
			}
			else
			{
				lblMessage.Visible=false;
				DataGrid1.DataSource=dv;
				DataGrid1.DataBind();
			}
		}

		private void DataGrid2_DataBind()
		{
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c1_lost");
			DataView dv2 = ds2.Tables["c1_lost"].DefaultView;
			string strbuf="";
			if(rblSent.SelectedItem.Value=="0")
				strbuf="lst_fgsent <> 'C'";
			else if(rblSent.SelectedItem.Value=="1")
				strbuf="lst_fgsent = 'C'";
			if(tbxOrderNo.Text!="")
			{
				strbuf+=" and lst_custno='"+tbxOrderNo.Text.Substring(2,6)+"'";
				strbuf+=" and lst_otp1cd='"+tbxOrderNo.Text.Substring(8,2)+"'";
				strbuf+=" and lst_otp1seq='"+tbxOrderNo.Text.Substring(10,3)+"'";
			}
			if(tbxCompanyname.Text!="")
				strbuf+=" and mfr_inm Like '"+tbxCompanyname.Text.Trim()+"%'";
			if(tbxMfrno.Text!="")
				strbuf+=" and cust_mfrno Like '"+tbxMfrno.Text.Trim()+"%'";
			if(tbxCustNo.Text!="")
				//					if(tbxOrderNo.Text=="")
				strbuf+=" and lst_custno = '"+tbxCustNo.Text.Trim()+"'";
			if(tbxCustName.Text!="")
				strbuf+=" and cust_nm Like '"+tbxCustName.Text.Trim()+"%'";
			if(tbxRecName.Text!="")
				strbuf+=" and or_nm Like '"+tbxRecName.Text.Trim()+"%'";
			if(tbxRecAddr.Text!="")
				strbuf+=" and or_addr Like '"+tbxRecAddr.Text.Trim()+"%'";
			if(tbxRecTel.Text!="")
				strbuf+=" and or_tel="+tbxRecTel.Text;
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
//				lblMessage.Text="已寄出之缺書單不會列示";
//			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
//			Response.Write(DataGrid1.SelectedItem.Cells[2].Text);
			string	strbuf;
			strbuf="LostForm.aspx?id="+DataGrid1.SelectedItem.Cells[0].Text.Trim()+"&oritem="+DataGrid1.SelectedItem.Cells[5].Text.Trim()
					+"&date="+DataGrid1.SelectedItem.Cells[9].Text.Trim()+DataGrid1.SelectedItem.Cells[10].Text.Trim();
			if(e.CommandName=="Select")
				Response.Redirect(strbuf);
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowCust();
		}

		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid2.SelectedIndex=e.Item.ItemIndex;
			if(e.CommandName=="Select")
				Response.Redirect("LostFM.aspx?id="+DataGrid2.SelectedItem.Cells[1].Text.Trim()+"&seq="+DataGrid2.SelectedItem.Cells[2].Text.Trim()+"&oritem="+DataGrid2.SelectedItem.Cells[7].Text.Trim());
		}

		private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			strbuf=DataGrid2.SelectedItem.Cells[1].Text.Trim();
			this.sqlDeleteCommand1.Parameters["@lst_syscd"].Value=strbuf.Substring(0,2);
			this.sqlDeleteCommand1.Parameters["@lst_custno"].Value=strbuf.Substring(2,6);
			this.sqlDeleteCommand1.Parameters["@lst_otp1cd"].Value=strbuf.Substring(8,2);
			this.sqlDeleteCommand1.Parameters["@lst_otp1seq"].Value=strbuf.Substring(10,3);
			this.sqlDeleteCommand1.Parameters["@lst_oritem"].Value=DataGrid2.SelectedItem.Cells[7].Text.Trim();
			this.sqlDeleteCommand1.Parameters["@lst_seq"].Value=DataGrid2.SelectedItem.Cells[2].Text.Trim();
			this.sqlDeleteCommand1.Connection.Open();
			this.sqlDeleteCommand1.ExecuteNonQuery();
			this.sqlDeleteCommand1.Connection.Close();
			DataGrid2_DataBind();
			DataGrid2.SelectedIndex=-1;

		}
}
}
