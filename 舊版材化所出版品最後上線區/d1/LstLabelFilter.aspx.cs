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
	/// Summary description for LstLabelFilter.
	/// </summary>
	public class LstLabelFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCheckAll;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnLabelPrint1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlMosea;
		protected System.Web.UI.WebControls.Button btnPrintOK;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataList DataList1;
	
		public LstLabelFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				DataBind();
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
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.ddlMosea.SelectedIndexChanged += new System.EventHandler(this.ddlMosea_SelectedIndexChanged);
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			this.btnLabelPrint1.Click += new System.EventHandler(this.btnLabelPrint_Click);
			this.btnPrintOK.Click += new System.EventHandler(this.btnPrintOK_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO dbo.tmp_label2(tmp_syscd, tmp_custno, tmp_otp1cd, tmp_otp1seq, tmp_or" +
				"item, tmp_seq) VALUES (@tmp_syscd, @tmp_custno, @tmp_otp1cd, @tmp_otp1seq, @tmp_" +
				"oritem, @tmp_seq)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_seq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO dbo.c1_lost(lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_orite" +
				"m, lst_seq, lst_date, lst_fgsent) VALUES (@lst_syscd, @lst_custno, @lst_otp1cd, " +
				"@lst_otp1seq, @lst_oritem, @lst_seq, @lst_date, @lst_fgsent, @lst_status)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_fgsent", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT lst_lstid, lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_oritem, lst" +
				"_seq, lst_date, lst_fgsent FROM dbo.c1_lost";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT tmp_id, tmp_syscd, tmp_custno, tmp_otp1cd, tmp_otp1seq, tmp_oritem, tmp_se" +
				"q FROM dbo.tmp_label2";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_lost.lst_lstid, dbo.c1_lost.lst_syscd, dbo.c1_lost.lst_custno, dbo.c1_lost.lst_otp1cd, dbo.c1_lost.lst_otp1seq, dbo.c1_lost.lst_oritem, dbo.c1_lost.lst_seq, dbo.c1_lost.lst_cont, dbo.c1_lost.lst_date, dbo.c1_lost.lst_rea, dbo.c1_lost.lst_fgsent, dbo.c1_or.or_nm, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.c1_or.or_fgmosea, dbo.c1_lost.lst_syscd + dbo.c1_lost.lst_custno + dbo.c1_lost.lst_otp1cd + dbo.c1_lost.lst_otp1seq + dbo.c1_lost.lst_oritem AS nostr FROM dbo.c1_lost INNER JOIN dbo.c1_or ON dbo.c1_lost.lst_syscd = dbo.c1_or.or_syscd AND dbo.c1_lost.lst_custno = dbo.c1_or.or_custno AND dbo.c1_lost.lst_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_lost.lst_oritem = dbo.c1_or.or_oritem";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM dbo.c1_lost WHERE (lst_custno = @lst_custno) AND (lst_oritem = @lst_o" +
				"ritem) AND (lst_otp1cd = @lst_otp1cd) AND (lst_otp1seq = @lst_otp1seq) AND (lst_" +
				"syscd = @lst_syscd)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.tmp_label2";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand2;
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
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.c1_lost SET lst_syscd = @lst_syscd, lst_custno = @lst_custno, lst_otp1cd = @lst_otp1cd, lst_otp1seq = @lst_otp1seq, lst_oritem = @lst_oritem, lst_seq = @lst_seq, lst_date = @lst_date, lst_fgsent = @lst_fgsent WHERE (lst_custno = @Original_lst_custno) AND (lst_oritem = @Original_lst_oritem) AND (lst_otp1cd = @Original_lst_otp1cd) AND (lst_otp1seq = @Original_lst_otp1seq) AND (lst_syscd = @Original_lst_syscd) AND (lst_seq = @Original_lst_seq)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_fgsent", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tmp_label2", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("tmp_id", "tmp_id"),
																																																					new System.Data.Common.DataColumnMapping("tmp_syscd", "tmp_syscd"),
																																																					new System.Data.Common.DataColumnMapping("tmp_custno", "tmp_custno"),
																																																					new System.Data.Common.DataColumnMapping("tmp_otp1cd", "tmp_otp1cd"),
																																																					new System.Data.Common.DataColumnMapping("tmp_otp1seq", "tmp_otp1seq"),
																																																					new System.Data.Common.DataColumnMapping("tmp_oritem", "tmp_oritem"),
																																																					new System.Data.Common.DataColumnMapping("tmp_seq", "tmp_seq")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE dbo.tmp_label2 SET tmp_syscd = @tmp_syscd, tmp_custno = @tmp_custno, tmp_o" +
				"tp1cd = @tmp_otp1cd, tmp_otp1seq = @tmp_otp1seq, tmp_oritem = @tmp_oritem, tmp_s" +
				"eq = @tmp_seq WHERE (tmp_id = @Original_tmp_id)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tmp_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_tmp_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "tmp_id", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("nostr", "nostr")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCheckAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Enabled)
					((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked=true;
			}

		}

		private void btnLabelPrint_Click(object sender, System.EventArgs e)
		{
			string	strbuf;
			//將tmp_label2資料清空
			this.sqlDeleteCommand1.Connection.Open();
			this.sqlDeleteCommand1.ExecuteNonQuery();
			this.sqlDeleteCommand1.Connection.Close();
			//將所選之缺書資料填入tmp_label2
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					//將所選之缺書資料的缺書日期(lst_date)填入今天的日期
					strbuf=((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@Original_lst_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@Original_lst_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@Original_lst_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@Original_lst_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@Original_lst_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@Original_lst_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@lst_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@lst_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@lst_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@lst_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@lst_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@lst_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@lst_date"].Value=System.DateTime.Today.ToString("yyyyMMdd");
					this.sqlUpdateCommand2.Parameters["@lst_fgsent"].Value="Y";
					//					this.sqlUpdateCommand2.Parameters["@lst_status"].Value="0";
					this.sqlUpdateCommand2.Connection.Open();
					this.sqlUpdateCommand2.ExecuteNonQuery();
					this.sqlUpdateCommand2.Connection.Close();
					//將所選之缺書資料加入tmp_label2
					this.sqlInsertCommand1.Parameters["@tmp_syscd"].Value=strbuf.Substring(0,2);
					this.sqlInsertCommand1.Parameters["@tmp_custno"].Value=strbuf.Substring(2,6);
					this.sqlInsertCommand1.Parameters["@tmp_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlInsertCommand1.Parameters["@tmp_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlInsertCommand1.Parameters["@tmp_oritem"].Value=strbuf.Substring(13,2);
					this.sqlInsertCommand1.Parameters["@tmp_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlInsertCommand1.Connection.Open();
					this.sqlInsertCommand1.ExecuteNonQuery();
					this.sqlInsertCommand1.Connection.Close();
				}
			}
			btnPrintOK.Enabled=true;
			strbuf="lost_label.aspx?mosea="+ddlMosea.SelectedItem.Value.Trim();
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			//			Response.Redirect("lost_label.aspx");
		}

		private void ddlMosea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataBind();
		}

		private void btnPrintOK_Click(object sender, System.EventArgs e)
		{
			string	strbuf;
			Literal1.Text="";
			//將所選之缺書資料的缺書日期(lst_date)填入今天的日期,並將寄出註記(lst_fgsent)設為'C'
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					strbuf=((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@Original_lst_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@Original_lst_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@Original_lst_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@Original_lst_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@Original_lst_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@Original_lst_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@lst_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@lst_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@lst_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@lst_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@lst_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@lst_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@lst_date"].Value=System.DateTime.Today.ToString("yyyyMMdd");
					this.sqlUpdateCommand2.Parameters["@lst_fgsent"].Value="C";
					//					this.sqlUpdateCommand2.Parameters["@lst_status"].Value="1";
					this.sqlUpdateCommand2.Connection.Open();
					this.sqlUpdateCommand2.ExecuteNonQuery();
					this.sqlUpdateCommand2.Connection.Close();
				}
			}
			DataBind();
		}
		private void DataBind()
		{
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_lost");
			DataView dv1 = ds1.Tables["c1_lost"].DefaultView;
			dv1.RowFilter="or_fgmosea='"+ddlMosea.SelectedItem.Value.Trim()+"' and lst_fgsent<>'C'";
			DataList1.DataSource=dv1;
			DataList1.DataBind();
		}

	}
}
