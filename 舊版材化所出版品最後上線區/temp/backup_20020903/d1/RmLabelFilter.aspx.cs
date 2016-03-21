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
	/// Summary description for RmLabelFilter.
	/// </summary>
	public class RmLabelFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlMosea;
		protected System.Web.UI.WebControls.Button btnCheckAll;
		protected System.Web.UI.WebControls.Button btnLabelPrint1;
		protected System.Web.UI.WebControls.Button btnPrintOK;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
	
		public RmLabelFilter()
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
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.ddlMosea.SelectedIndexChanged += new System.EventHandler(this.ddlMosea_SelectedIndexChanged);
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			this.btnLabelPrint1.Click += new System.EventHandler(this.btnLabelPrint1_Click);
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
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO dbo.c1_remail(rm_syscd, rm_custno, rm_otp1cd, rm_otp1seq, rm_oritem, " +
				"rm_seq, rm_date, rm_fgsent) VALUES (@rm_syscd, @rm_custno, @rm_otp1cd" +
				", @rm_otp1seq, @rm_oritem, @rm_seq, @rm_date, @rm_fgsent)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_fgsent", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT rm_rmid, rm_syscd, rm_custno, rm_otp1cd, rm_otp1seq, rm_oritem, rm_seq, rm" +
				"_date, rm_fgsent FROM dbo.c1_remail";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT tmp_id, tmp_syscd, tmp_custno, tmp_otp1cd, tmp_otp1seq, tmp_oritem, tmp_se" +
				"q FROM dbo.tmp_label2";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM dbo.c1_remail WHERE (rm_custno = @rm_custno) AND (rm_oritem = @rm_ori" +
				"tem) AND (rm_otp1cd = @rm_otp1cd) AND (rm_otp1seq = @rm_otp1seq) AND (rm_syscd =" +
				" @rm_syscd)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Original, null));
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
																									  new System.Data.Common.DataTableMapping("Table", "c1_remail", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("rm_rmid", "rm_rmid"),
																																																				   new System.Data.Common.DataColumnMapping("rm_syscd", "rm_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_custno", "rm_custno"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1cd", "rm_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("rm_otp1seq", "rm_otp1seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_oritem", "rm_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("rm_seq", "rm_seq"),
																																																				   new System.Data.Common.DataColumnMapping("rm_date", "rm_date"),
																																																				   new System.Data.Common.DataColumnMapping("rm_fgsent", "rm_fgsent")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.c1_remail SET rm_syscd = @rm_syscd, rm_custno = @rm_custno, rm_otp1cd = @rm_otp1cd, rm_otp1seq = @rm_otp1seq, rm_oritem = @rm_oritem, rm_seq = @rm_seq, rm_date = @rm_date, rm_fgsent = @rm_fgsent WHERE (rm_custno = @Original_rm_custno) AND (rm_oritem = @Original_rm_oritem) AND (rm_otp1cd = @Original_rm_otp1cd) AND (rm_otp1seq = @Original_rm_otp1seq) AND (rm_syscd = @Original_rm_syscd) AND (rm_seq = @Original_rm_seq)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_fgsent", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Current, null));
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
																									  new System.Data.Common.DataTableMapping("Table", "c1_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																			   new System.Data.Common.DataColumnMapping("rm_syscd", "rm_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("rm_custno", "rm_custno"),
																																																			   new System.Data.Common.DataColumnMapping("rm_otp1cd", "rm_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("rm_otp1seq", "rm_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("rm_oritem", "rm_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("rm_seq", "rm_seq"),
																																																			   new System.Data.Common.DataColumnMapping("rm_cont", "rm_cont"),
																																																			   new System.Data.Common.DataColumnMapping("rm_date", "rm_date"),
																																																			   new System.Data.Common.DataColumnMapping("rm_fgsent", "rm_fgsent"),
																																																			   new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("nostr", "nostr")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_or.or_nm, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1seq, dbo.c1_or.or_fgmosea, dbo.c1_remail.rm_syscd, dbo.c1_remail.rm_custno, dbo.c1_remail.rm_otp1cd, dbo.c1_remail.rm_otp1seq, dbo.c1_remail.rm_oritem, dbo.c1_remail.rm_seq, dbo.c1_remail.rm_cont, dbo.c1_remail.rm_date, dbo.c1_remail.rm_fgsent, dbo.c1_or.or_custno, dbo.c1_or.or_otp1cd, dbo.c1_or.or_syscd, dbo.c1_remail.rm_syscd + dbo.c1_remail.rm_custno + dbo.c1_remail.rm_otp1cd + dbo.c1_remail.rm_otp1seq+dbo.c1_remail.rm_oritem+dbo.c1_remail.rm_seq AS nostr FROM dbo.c1_or INNER JOIN dbo.c1_remail ON dbo.c1_or.or_syscd = dbo.c1_remail.rm_syscd AND dbo.c1_or.or_custno = dbo.c1_remail.rm_custno AND dbo.c1_or.or_otp1cd = dbo.c1_remail.rm_otp1cd AND dbo.c1_or.or_otp1seq = dbo.c1_remail.rm_otp1seq AND dbo.c1_or.or_oritem = dbo.c1_remail.rm_oritem";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);


		}
		#endregion

		private void DataBind()
		{
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_rmail");
			DataView dv1 = ds1.Tables["c1_rmail"].DefaultView;
			dv1.RowFilter="or_fgmosea='"+ddlMosea.SelectedItem.Value.Trim()+"' and rm_fgsent<>'C'";
			DataList1.DataSource=dv1;
			DataList1.DataBind();
		}

		private void btnCheckAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Enabled)
					((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked=true;
			}
		}

		private void ddlMosea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataBind();
		}

		private void btnLabelPrint1_Click(object sender, System.EventArgs e)
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
					//將所選之缺書資料的缺書日期(rm_date)填入今天的日期
					strbuf=((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@Original_rm_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@Original_rm_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@Original_rm_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@Original_rm_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@Original_rm_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@Original_rm_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@rm_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@rm_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@rm_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@rm_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@rm_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@rm_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@rm_date"].Value=System.DateTime.Today.ToString("yyyyMMdd");
					this.sqlUpdateCommand2.Parameters["@rm_fgsent"].Value="Y";
					//					this.sqlUpdateCommand2.Parameters["@rm_status"].Value="0";	//可列印
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
			strbuf="remail_label.aspx?mosea="+ddlMosea.SelectedItem.Value.Trim();
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			//			Response.Redirect("lost_label.aspx");

		}

		private void btnPrintOK_Click(object sender, System.EventArgs e)
		{
			string	strbuf;
			Literal1.Text="";
			//將所選之補書資料的補書日期(lst_date)填入今天的日期,並將寄出註記(lst_fgsent)設為'C'
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					strbuf=((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@Original_rm_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@Original_rm_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@Original_rm_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@Original_rm_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@Original_rm_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@Original_rm_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@rm_syscd"].Value=strbuf.Substring(0,2);
					this.sqlUpdateCommand2.Parameters["@rm_custno"].Value=strbuf.Substring(2,6);
					this.sqlUpdateCommand2.Parameters["@rm_otp1cd"].Value=strbuf.Substring(8,2);
					this.sqlUpdateCommand2.Parameters["@rm_otp1seq"].Value=strbuf.Substring(10,3);
					this.sqlUpdateCommand2.Parameters["@rm_oritem"].Value=strbuf.Substring(13,2);
					this.sqlUpdateCommand2.Parameters["@rm_seq"].Value=((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					this.sqlUpdateCommand2.Parameters["@rm_date"].Value=System.DateTime.Today.ToString("yyyyMMdd");
					this.sqlUpdateCommand2.Parameters["@rm_fgsent"].Value="C";
					//					this.sqlUpdateCommand2.Parameters["@rm_status"].Value="1";
					this.sqlUpdateCommand2.Connection.Open();
					this.sqlUpdateCommand2.ExecuteNonQuery();
					this.sqlUpdateCommand2.Connection.Close();
				}
			}
			DataBind();

		}

	}
}
