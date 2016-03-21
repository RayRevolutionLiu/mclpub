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
	/// Summary description for RemailFM.
	/// </summary>
	public class RemailFM : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblNo;
		protected System.Web.UI.WebControls.Label lblType1;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblCoName;
		protected System.Web.UI.WebControls.Label lblRecName;
		protected System.Web.UI.WebControls.Label lblRecAddr;
		protected System.Web.UI.WebControls.DropDownList ddlSendFlag;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblRemailSeq;
		protected System.Web.UI.WebControls.TextBox tbxRemailDate;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label lblsdate;
		protected System.Web.UI.WebControls.Label lbledate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.HtmlControls.HtmlTextArea textarea1;
	
		public RemailFM()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//
				// Evals true first time browser hits the page
				//
				string id=Context.Request.QueryString["id"];
				string seq=Context.Request.QueryString["seq"];
				string oritem=Context.Request.QueryString["oritem"];
				lblNo.Text=id.Substring(0,13);
				lblCustNo.Text=id.Substring(2,6);
				//訂購類別
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "c1_otp");
				DataView dv4 = ds4.Tables["c1_otp"].DefaultView;
				dv4.RowFilter="otp_otp1cd="+id.Substring(8,2);
				lblType1.Text=dv4[0].Row["otp_otp1nm"].ToString();
				//訂戶資料
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c1_cust");
				DataView dv1 = ds1.Tables["c1_cust"].DefaultView;
				dv1.RowFilter="cust_custno="+id.Substring(2,6);
				lblCustName.Text=dv1[0].Row["cust_nm"].ToString();
				lblCoName.Text=dv1[0].Row["mfr_inm"].ToString();
				//收件人資料
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c1_or");
				DataView dv2 = ds2.Tables["c1_or"].DefaultView;
				dv2.RowFilter="or_custno="+lblCustNo.Text+" and or_otp1cd="+id.Substring(8,2)+
					" and or_otp1seq="+id.Substring(10,3)+" and or_oritem="+oritem;
				//					+" and ra_oditem="+oditem;
				lblRecName.Text=dv2[0].Row["or_nm"].ToString();
				lblRecAddr.Text=dv2[0].Row["or_addr"].ToString();
				//補書序號
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c1_remail");
				DataView dv3 = ds3.Tables["c1_remail"].DefaultView;
				dv3.RowFilter="rm_custno="+id.Substring(2,6)+" and rm_otp1cd='"+id.Substring(8,2)+"'"+
					" and rm_otp1seq="+id.Substring(10,3)+" and rm_oritem="+oritem+" and rm_seq="+seq;
				lblRemailSeq.Text=dv3[0].Row["rm_seq"].ToString().Trim();
				textarea1.Value=dv3[0].Row["rm_cont"].ToString().Trim();
				if(dv3[0].Row["rm_fgsent"].ToString().Trim()=="Y")
					ddlSendFlag.SelectedIndex=0;
				else if(dv3[0].Row["rm_fgsent"].ToString().Trim()=="N")
					ddlSendFlag.SelectedIndex=1;
				else if(dv3[0].Row["rm_fgsent"].ToString().Trim()=="D")
					ddlSendFlag.SelectedIndex=2;
				else if(dv3[0].Row["rm_fgsent"].ToString().Trim()=="C")
					ddlSendFlag.SelectedIndex=3;
				//補書日期
				tbxRemailDate.Text=dv3[0].Row["rm_date"].ToString().Trim();
				lblsdate.Text=dv3[0].Row["rm_sdate"].ToString().Trim();
				lbledate.Text=dv3[0].Row["rm_edate"].ToString().Trim();
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
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.c1_remail(rm_syscd, rm_custno, rm_otp1cd, rm_otp1seq, rm_oritem, rm_seq, rm_cont, rm_date, rm_fgsent, rm_sdate, rm_edate) VALUES (@rm_syscd, @rm_custno, @rm_otp1cd, @rm_otp1seq, @rm_oritem, @rm_seq, @rm_cont, @rm_date, @rm_fgsent, @rm_sdate, @rm_edate)";
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
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_sdate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_edate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_edate", System.Data.DataRowVersion.Current, null));
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
				"_cont, rm_date, rm_fgsent, rm_sdate, rm_edate FROM dbo.c1_remail WHERE (rm_syscd" +
				" = \'C1\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c1_or.or_orid, dbo.c1_or.or_syscd, dbo.c1_or.or_custno, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_oritem, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_addr, dbo.c1_ramt.ra_mnt, dbo.c1_ramt.ra_custno, dbo.c1_ramt.ra_oditem, dbo.c1_ramt.ra_oritem, dbo.c1_ramt.ra_otp1cd, dbo.c1_ramt.ra_otp1seq, dbo.c1_ramt.ra_syscd FROM dbo.c1_or INNER JOIN dbo.c1_ramt ON dbo.c1_or.or_syscd = dbo.c1_ramt.ra_syscd AND dbo.c1_or.or_custno = dbo.c1_ramt.ra_custno AND dbo.c1_or.or_otp1cd = dbo.c1_ramt.ra_otp1cd AND dbo.c1_or.or_otp1seq = dbo.c1_ramt.ra_otp1seq WHERE (dbo.c1_or.or_syscd = 'C1')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c1_cust.cust_custid, dbo.c1_cust.cust_custno, dbo.c1_cust.cust_nm, dbo" +
				".mfr.mfr_inm, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_mfrno FROM dbo.c1_cust INNER JOIN d" +
				"bo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT DISTINCT otp_otp1cd, otp_otp1nm FROM dbo.c1_otp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_remail WHERE (rm_custno = @rm_custno) AND (rm_oritem = @rm_ori" +
				"tem) AND (rm_otp1cd = @rm_otp1cd) AND (rm_otp1seq = @rm_otp1seq) AND (rm_syscd =" +
				" @rm_syscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Original, null));
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
																																																				   new System.Data.Common.DataColumnMapping("rm_fgsent", "rm_fgsent"),
																																																				   new System.Data.Common.DataColumnMapping("rm_sdate", "rm_sdate"),
																																																				   new System.Data.Common.DataColumnMapping("rm_edate", "rm_edate")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_remail SET rm_syscd = @rm_syscd, rm_custno = @rm_custno, rm_otp1cd = @rm_otp1cd, rm_otp1seq = @rm_otp1seq, rm_oritem = @rm_oritem, rm_seq = @rm_seq, rm_cont = @rm_cont, rm_date = @rm_date, rm_fgsent = @rm_fgsent, rm_sdate = @rm_sdate, rm_edate = @rm_edate WHERE (rm_custno = @Original_rm_custno) AND (rm_oritem = @Original_rm_oritem) AND (rm_otp1cd = @Original_rm_otp1cd) AND (rm_otp1seq = @Original_rm_otp1seq) AND (rm_syscd = @Original_rm_syscd) AND (rm_seq = @Original_rm_seq)";
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
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_sdate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rm_edate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_edate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_rm_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_seq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("or_orid", "or_orid"),
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("ra_mnt", "ra_mnt"),
																																																			   new System.Data.Common.DataColumnMapping("ra_custno", "ra_custno"),
																																																			   new System.Data.Common.DataColumnMapping("ra_oditem", "ra_oditem"),
																																																			   new System.Data.Common.DataColumnMapping("ra_oritem", "ra_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("ra_otp1cd", "ra_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("ra_otp1seq", "ra_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("ra_syscd", "ra_syscd")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_otp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string id=Context.Request.QueryString["id"];
			this.sqlUpdateCommand1.Parameters["@rm_syscd"].Value=id.Substring(0,2);
			this.sqlUpdateCommand1.Parameters["@rm_custno"].Value=id.Substring(2,6);
			this.sqlUpdateCommand1.Parameters["@rm_otp1cd"].Value=id.Substring(8,2);
			this.sqlUpdateCommand1.Parameters["@rm_otp1seq"].Value=id.Substring(10,3);
			this.sqlUpdateCommand1.Parameters["@rm_oritem"].Value=Context.Request.QueryString["oritem"];
			this.sqlUpdateCommand1.Parameters["@rm_seq"].Value=lblRemailSeq.Text;
//			DateTime date1=DateTime.Parse(tbxRemailDate.Text);
			this.sqlUpdateCommand1.Parameters["@rm_date"].Value=tbxRemailDate.Text;
			this.sqlUpdateCommand1.Parameters["@rm_cont"].Value=textarea1.Value;
			this.sqlUpdateCommand1.Parameters["@rm_fgsent"].Value=ddlSendFlag.SelectedItem.Value.Trim();
			this.sqlUpdateCommand1.Parameters["@rm_sdate"].Value=lblsdate.Text.Trim();
			this.sqlUpdateCommand1.Parameters["@rm_edate"].Value=lbledate.Text.Trim();
			this.sqlUpdateCommand1.Parameters["@Original_rm_syscd"].Value=id.Substring(0,2);
			this.sqlUpdateCommand1.Parameters["@Original_rm_custno"].Value=id.Substring(2,6);
			this.sqlUpdateCommand1.Parameters["@Original_rm_otp1cd"].Value=id.Substring(8,2);
			this.sqlUpdateCommand1.Parameters["@Original_rm_otp1seq"].Value=id.Substring(10,3);
			this.sqlUpdateCommand1.Parameters["@Original_rm_oritem"].Value=Context.Request.QueryString["oritem"];
			this.sqlUpdateCommand1.Parameters["@Original_rm_seq"].Value=lblRemailSeq.Text;
			this.sqlUpdateCommand1.Connection.Open();
			this.sqlUpdateCommand1.ExecuteNonQuery();
			this.sqlUpdateCommand1.Connection.Close();
			Response.Redirect("SaveMessage.aspx?str=modremail");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("http://140.96.18.18/mrlpub/");
		}
	}
}
