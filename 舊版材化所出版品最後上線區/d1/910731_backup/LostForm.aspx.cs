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
	/// Summary description for order3.
	/// </summary>
	public class LostForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblNo;
		protected System.Web.UI.WebControls.Label lblRecName;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblCoName;
		protected System.Web.UI.WebControls.Label lblType1;
		protected System.Web.UI.WebControls.Label lblRecAddr;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblLostSeq;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.HtmlControls.HtmlTextArea textarea1;
		protected System.Web.UI.HtmlControls.HtmlTextArea textarea2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DropDownList ddlSendFlag;
		protected System.Web.UI.WebControls.Label lblsdate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.Label lbledate;
	
		public LostForm()
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
				string date=Context.Request.QueryString["date"];
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
//								+" and ra_oditem="+oditem;
				lblRecName.Text=dv2[0].Row["or_nm"].ToString();
				lblRecAddr.Text=dv2[0].Row["or_addr"].ToString();
				//缺書序號
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c1_lost");
				DataView dv3 = ds3.Tables["c1_lost"].DefaultView;
				dv3.RowFilter="lst_custno="+id.Substring(2,6)+" and lst_otp1cd='"+id.Substring(8,2)+"'"+
								" and lst_otp1seq="+id.Substring(10,3)+" and lst_oritem="+oritem;
				string str2=((int)(dv3.Count+1)).ToString();
				int j=2-str2.Length;
				for(int i=0; i<j; i++)
					str2="0"+str2;
				lblLostSeq.Text=str2;
				//缺書登錄日期
//				tbxLostDate.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				lblsdate.Text=date.Substring(0,4)+"/"+date.Substring(4,2)+"/"+date.Substring(6,2);
				lbledate.Text=date.Substring(8,4)+"/"+date.Substring(12,2)+"/"+date.Substring(14,2);
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_lost WHERE (lst_custno = @lst_custno) AND (lst_oritem = @lst_o" +
				"ritem) AND (lst_otp1cd = @lst_otp1cd) AND (lst_otp1seq = @lst_otp1seq) AND (lst_" +
				"syscd = @lst_syscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_otp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT DISTINCT otp_otp1cd, otp_otp1nm FROM dbo.c1_otp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT lst_lstid, lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_oritem, lst" +
				"_seq, lst_cont, lst_date, lst_rea, lst_fgsent, lst_sdate, lst_edate FROM dbo.c1_" +
				"lost WHERE (lst_syscd = \'C1\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT or_orid, or_syscd, or_custno, or_otp1cd, or_otp1seq, or_oritem, or_inm, or" +
				"_nm, or_addr FROM dbo.c1_or WHERE (or_syscd = \'C1\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c1_cust.cust_custid, dbo.c1_cust.cust_custno, dbo.c1_cust.cust_nm, dbo" +
				".mfr.mfr_inm, dbo.mfr.mfr_mfrid FROM dbo.c1_cust INNER JOIN dbo.mfr ON dbo.c1_cu" +
				"st.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
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
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr")})});
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
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("lst_sdate", "lst_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("lst_edate", "lst_edate")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.c1_lost(lst_syscd, lst_custno, lst_otp1cd, lst_otp1seq, lst_oritem, lst_seq, lst_cont, lst_date, lst_rea, lst_fgsent, lst_sdate, lst_edate) VALUES (@lst_syscd, @lst_custno, @lst_otp1cd, @lst_otp1seq, @lst_oritem, @lst_seq, @lst_cont, @lst_date, @lst_rea, @lst_fgsent, @lst_sdate, @lst_edate)";
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
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_sdate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_edate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_edate", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_lost SET lst_syscd = @lst_syscd, lst_custno = @lst_custno, lst_otp1cd = @lst_otp1cd, lst_otp1seq = @lst_otp1seq, lst_oritem = @lst_oritem, lst_seq = @lst_seq, lst_cont = @lst_cont, lst_date = @lst_date, lst_rea = @lst_rea, lst_fgsent = @lst_fgsent, lst_sdate = @lst_sdate, lst_edate = @lst_edate WHERE (lst_custno = @Original_lst_custno) AND (lst_oritem = @Original_lst_oritem) AND (lst_otp1cd = @Original_lst_otp1cd) AND (lst_otp1seq = @Original_lst_otp1seq) AND (lst_syscd = @Original_lst_syscd)";
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
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_sdate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lst_edate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_edate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lst_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			string id=Context.Request.QueryString["id"];
			if((id.Substring(8,2)=="01")||(id.Substring(8,2)=="09"))
				Response.Redirect("OrderFM.aspx?id="+id.Substring(2,6)+"&type1="+id.Substring(8,2)+"&seq="+id.Substring(10,3));
			else
				Response.Redirect("FreeFM.aspx?id="+id.Substring(2,6)+"&type1="+id.Substring(8,2)+"&seq="+id.Substring(10,3));
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string id=Context.Request.QueryString["id"];
			this.sqlInsertCommand1.Parameters["@lst_syscd"].Value="C1";
			this.sqlInsertCommand1.Parameters["@lst_custno"].Value=lblCustNo.Text;
			this.sqlInsertCommand1.Parameters["@lst_otp1cd"].Value=id.Substring(8,2);
			this.sqlInsertCommand1.Parameters["@lst_otp1seq"].Value=id.Substring(10,3);
//			this.sqlInsertCommand1.Parameters["@lst_oditem"].Value=id.Substring(14, id.Length-14);
			this.sqlInsertCommand1.Parameters["@lst_oritem"].Value=Context.Request.QueryString["oritem"];
			this.sqlInsertCommand1.Parameters["@lst_seq"].Value=lblLostSeq.Text;
			this.sqlInsertCommand1.Parameters["@lst_date"].Value="";
			this.sqlInsertCommand1.Parameters["@lst_cont"].Value=textarea1.Value;
			this.sqlInsertCommand1.Parameters["@lst_rea"].Value=textarea2.Value;
			this.sqlInsertCommand1.Parameters["@lst_fgsent"].Value=ddlSendFlag.SelectedItem.Value.Trim();
			this.sqlInsertCommand1.Parameters["@lst_sdate"].Value=lblsdate.Text.Trim();
			this.sqlInsertCommand1.Parameters["@lst_edate"].Value=lbledate.Text.Trim();
			this.sqlInsertCommand1.Connection.Open();
			this.sqlInsertCommand1.ExecuteNonQuery();
			this.sqlInsertCommand1.Connection.Close();
			Response.Redirect("SaveMessage.aspx?str=newlost");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("http://140.96.18.18/mrlpub/");
		}
	}
}
