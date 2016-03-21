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

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for PayTypeFM.
	/// </summary>
	public class PayTypeFM : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblPayNo;
		protected System.Web.UI.WebControls.Label lblAmt;
		protected System.Web.UI.WebControls.DropDownList ddlPayType;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.RadioButtonList rblCctp;
		protected System.Web.UI.WebControls.Panel Panel4;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxChkno;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxChkbnm;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxChkdate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMoseq;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMoitem;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxWaccno;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxWdate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno1;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno2;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno3;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno4;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcauthcd;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxYear;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMonth;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxWbcd;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Data.SqlClient.SqlCommand sqlUpdateOrder;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcDate;
	
		public PayTypeFM()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
				lblPayNo.Text=Context.Request.QueryString["pyno"];
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "py");
				DataView dv1 = ds1.Tables["py"].DefaultView;
				dv1.RowFilter="py_pyno='"+lblPayNo.Text.Trim()+"'";
				lblAmt.Text=dv1[0].Row["py_amt"].ToString();
				lblDate.Text=dv1[0].Row["py_date"].ToString();
				//付款方式
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "pytp");
				ddlPayType.DataSource=ds2;
				ddlPayType.DataTextField="pytp_nm";
				ddlPayType.DataValueField="pytp_pytpcd";
				ddlPayType.DataBind();
				ddlPayType.Items.FindByValue(dv1[0].Row["py_pytpcd"].ToString()).Selected=true;
//				ddlPayType.SelectedIndex=int.Parse(dv1[0].Row["py_pytpcd"].ToString())-1;
				PayTypeChange();
				//繳款資料
				string	strbuf;
				switch(ddlPayType.SelectedItem.Value)
				{
					case "02":
						tbxChkno.Value=dv1[0].Row["py_chkno"].ToString();
						tbxChkbnm.Value=dv1[0].Row["py_chkbnm"].ToString();
						strbuf=dv1[0].Row["py_chkdate"].ToString();
						tbxChkdate.Value=strbuf.Substring(0,4)+"/"+strbuf.Substring(4,2)+"/"+strbuf.Substring(6,2);
						break;
					case "03":
						tbxMoseq.Value=dv1[0].Row["py_moseq"].ToString();
						tbxMoitem.Value=dv1[0].Row["py_moitem"].ToString();
						break;
					case "04":
						tbxWaccno.Value=dv1[0].Row["py_waccno"].ToString();
						strbuf=dv1[0].Row["py_wdate"].ToString();
						tbxWdate.Value=strbuf.Substring(0,4)+"/"+strbuf.Substring(4,2)+"/"+strbuf.Substring(6,2);
						tbxWbcd.Value=dv1[0].Row["py_wbcd"].ToString();
						break;
					case "05":
						rblCctp.SelectedIndex=int.Parse(dv1[0].Row["py_cctp"].ToString())-1;
						strbuf=dv1[0].Row["py_ccno"].ToString();
						tbxCcno1.Value=strbuf.Substring(0,4);
						tbxCcno2.Value=strbuf.Substring(4,4);
						tbxCcno3.Value=strbuf.Substring(8,4);
						tbxCcno4.Value=strbuf.Substring(12,4);
						tbxCcauthcd.Value=dv1[0].Row["py_ccauthcd"].ToString();
						strbuf=dv1[0].Row["py_ccvdate"].ToString();
						tbxYear.Value=strbuf.Substring(0,4);
						tbxMonth.Value=strbuf.Substring(4,2);
						strbuf=dv1[0].Row["py_ccdate"].ToString();
						tbxCcDate.Value=strbuf.Substring(0,4)+"/"+strbuf.Substring(4,2)+"/"+strbuf.Substring(6,2);
						break;
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
		private void PayTypeChange()
		{
			switch(ddlPayType.SelectedItem.Value)
			{
				case "01":
				case "06":
				case "07":
					Panel1.Visible=false;
					Panel2.Visible=false;
					Panel3.Visible=false;
					Panel4.Visible=false;
					break;
				case "02":
					Panel1.Visible=true;
					Panel2.Visible=false;
					Panel3.Visible=false;
					Panel4.Visible=false;
					break;
				case "03":
					Panel1.Visible=false;
					Panel2.Visible=true;
					Panel3.Visible=false;
					Panel4.Visible=false;
					break;
				case "04":
					Panel1.Visible=false;
					Panel2.Visible=false;
					Panel3.Visible=true;
					Panel4.Visible=false;
					break;
				case "05":
					Panel1.Visible=false;
					Panel2.Visible=false;
					Panel3.Visible=false;
					Panel4.Visible=true;
					break;
			}
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
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateOrder = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.ddlPayType.SelectedIndexChanged += new System.EventHandler(this.ddlPayType_SelectedIndexChanged);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.py(py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem) VALUES (@py_pyno, @py_amt, @py_pytpcd, @py_date, @py_moseq, @py_moitem, @py_chkno, @py_chkbnm, @py_chkdate, @py_waccno, @py_wdate, @py_wbcd, @py_ccno, @py_cctp, @py_ccauthcd, @py_ccvdate, @py_ccdate, @py_fgprinted, @py_syscd, @py_pysdate, @py_pysseq, @py_pysitem)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_amt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_amt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moitem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkbnm", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkbnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_waccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_waccno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wbcd", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wbcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_cctp", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_cctp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccauthcd", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccauthcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccvdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccvdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_fgprinted", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysitem", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.py WHERE (py_pyno = @py_pyno)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Original, null));
			// 
			// sqlUpdateOrder
			// 
			this.sqlUpdateOrder.CommandText = "UPDATE dbo.c1_order SET o_pytpcd = @o_pytpcd, o_xmldata = @o_xmldata WHERE (o_sys" +
				"cd = @o_syscd) AND (o_iano = @o_iano)";
			this.sqlUpdateOrder.Connection = this.sqlConnection1;
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 8000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iano", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_xmldata", "o_xmldata"),
																																																				  new System.Data.Common.DataColumnMapping("o_iano", "o_iano"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT o_xmldata, o_iano, o_custno, o_otp1cd, o_otp1seq, o_syscd FROM dbo.c1_orde" +
				"r";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pytp", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpid", "pytp_pytpid"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "py", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("py_pyid", "py_pyid"),
																																																			new System.Data.Common.DataColumnMapping("py_pyno", "py_pyno"),
																																																			new System.Data.Common.DataColumnMapping("py_amt", "py_amt"),
																																																			new System.Data.Common.DataColumnMapping("py_pytpcd", "py_pytpcd"),
																																																			new System.Data.Common.DataColumnMapping("py_date", "py_date"),
																																																			new System.Data.Common.DataColumnMapping("py_moseq", "py_moseq"),
																																																			new System.Data.Common.DataColumnMapping("py_moitem", "py_moitem"),
																																																			new System.Data.Common.DataColumnMapping("py_chkno", "py_chkno"),
																																																			new System.Data.Common.DataColumnMapping("py_chkbnm", "py_chkbnm"),
																																																			new System.Data.Common.DataColumnMapping("py_chkdate", "py_chkdate"),
																																																			new System.Data.Common.DataColumnMapping("py_waccno", "py_waccno"),
																																																			new System.Data.Common.DataColumnMapping("py_wdate", "py_wdate"),
																																																			new System.Data.Common.DataColumnMapping("py_wbcd", "py_wbcd"),
																																																			new System.Data.Common.DataColumnMapping("py_ccno", "py_ccno"),
																																																			new System.Data.Common.DataColumnMapping("py_cctp", "py_cctp"),
																																																			new System.Data.Common.DataColumnMapping("py_ccauthcd", "py_ccauthcd"),
																																																			new System.Data.Common.DataColumnMapping("py_ccvdate", "py_ccvdate"),
																																																			new System.Data.Common.DataColumnMapping("py_ccdate", "py_ccdate"),
																																																			new System.Data.Common.DataColumnMapping("py_fgprinted", "py_fgprinted"),
																																																			new System.Data.Common.DataColumnMapping("py_syscd", "py_syscd"),
																																																			new System.Data.Common.DataColumnMapping("py_pysdate", "py_pysdate"),
																																																			new System.Data.Common.DataColumnMapping("py_pysseq", "py_pysseq"),
																																																			new System.Data.Common.DataColumnMapping("py_pysitem", "py_pysitem")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.py SET py_pyno = @py_pyno, py_amt = @py_amt, py_pytpcd = @py_pytpcd, py_date = @py_date, py_moseq = @py_moseq, py_moitem = @py_moitem, py_chkno = @py_chkno, py_chkbnm = @py_chkbnm, py_chkdate = @py_chkdate, py_waccno = @py_waccno, py_wdate = @py_wdate, py_wbcd = @py_wbcd, py_ccno = @py_ccno, py_cctp = @py_cctp, py_ccauthcd = @py_ccauthcd, py_ccvdate = @py_ccvdate, py_ccdate = @py_ccdate, py_fgprinted = @py_fgprinted, py_syscd = @py_syscd, py_pysdate = @py_pysdate, py_pysseq = @py_pysseq, py_pysitem = @py_pysitem WHERE (py_pyno = @Original_py_pyno)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_amt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_amt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkbnm", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkbnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_waccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_waccno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wbcd", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wbcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_cctp", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_cctp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccauthcd", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccauthcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccvdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccvdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_fgprinted", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Original, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlPayType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PayTypeChange();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//Insert繳款檔py, 繳款明細檔pyd, and Update 發票開立單檔 ia
			SaveToPy();
			Update_c1_order_pytpcd();
			Response.Redirect("SaveMessage.aspx?str=pay&caller=");
		}
		private void SaveToPy()
		{
			//繳款單檔 py
			for(int i=0;i<this.sqlUpdateCommand1.Parameters.Count;i++)
			{
				this.sqlUpdateCommand1.Parameters[i].Value = "";
			}
			this.sqlUpdateCommand1.Parameters["@py_pyno"].Value=lblPayNo.Text.Trim();
			this.sqlUpdateCommand1.Parameters["@Original_py_pyno"].Value=lblPayNo.Text.Trim();
			//			this.sqlInsertComPy.Parameters["@py_syscd"].Value="C1";
			this.sqlUpdateCommand1.Parameters["@py_amt"].Value=lblAmt.Text.Trim();
			this.sqlUpdateCommand1.Parameters["@py_pytpcd"].Value=ddlPayType.SelectedItem.Value.Trim();
			this.sqlUpdateCommand1.Parameters["@py_date"].Value=lblDate.Text;
			this.sqlUpdateCommand1.Parameters["@py_fgprinted"].Value="0";
			switch(ddlPayType.SelectedItem.Value)
			{
				case "01":
				case "06":
				case "07":
					break;
				case "02":
					this.sqlUpdateCommand1.Parameters["@py_chkno"].Value=tbxChkno.Value;
					this.sqlUpdateCommand1.Parameters["@py_chkbnm"].Value=tbxChkbnm.Value;
					this.sqlUpdateCommand1.Parameters["@py_chkdate"].Value=tbxChkdate.Value.Substring(0,4)+tbxChkdate.Value.Substring(5,2)+tbxChkdate.Value.Substring(8,2);
					break;
				case "03":
					this.sqlUpdateCommand1.Parameters["@py_moseq"].Value=tbxMoseq.Value;
					this.sqlUpdateCommand1.Parameters["@py_moitem"].Value=tbxMoitem.Value;
					break;
				case "04":
					this.sqlUpdateCommand1.Parameters["@py_waccno"].Value=tbxWaccno.Value;
					this.sqlUpdateCommand1.Parameters["@py_wdate"].Value=tbxWdate.Value.Substring(0,4)+tbxWdate.Value.Substring(5,2)+tbxWdate.Value.Substring(8,2);
					this.sqlUpdateCommand1.Parameters["@py_wbcd"].Value=tbxWbcd.Value;
					break;
				case "05":
					this.sqlUpdateCommand1.Parameters["@py_ccno"].Value=tbxCcno1.Value+tbxCcno2.Value+tbxCcno3.Value+tbxCcno4.Value;
					this.sqlUpdateCommand1.Parameters["@py_cctp"].Value=rblCctp.SelectedItem.Value;
					this.sqlUpdateCommand1.Parameters["@py_ccauthcd"].Value=tbxCcauthcd.Value;
					if(tbxMonth.Value.Length<2)
						tbxMonth.Value="0"+tbxMonth.Value;
					this.sqlUpdateCommand1.Parameters["@py_ccvdate"].Value=tbxYear.Value+tbxMonth.Value;
					this.sqlUpdateCommand1.Parameters["@py_ccdate"].Value=tbxCcDate.Value.Substring(0,4)+tbxCcDate.Value.Substring(5,2)+tbxCcDate.Value.Substring(8,2);
					break;
			}
			this.sqlUpdateCommand1.Connection.Open();
			this.sqlUpdateCommand1.ExecuteNonQuery();
			this.sqlUpdateCommand1.Connection.Close();
		}
		private void Update_c1_order_pytpcd()
		{
			XmlDocument XmlDoc;
			XmlDoc = new System.Xml.XmlDocument();
			
			XmlNode	ItemMain;//=XmlDoc.SelectSingleNode("/root");
			XmlNode	ItemOrder;//=XmlDoc.SelectSingleNode("/root/訂單");
			string	nostr;
			string	strbuf=Context.Request.QueryString["no"];
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c1_order");
			DataView dv3 = ds3.Tables["c1_order"].DefaultView;

			for(int i=0; i<(strbuf.Length/8);i++)
			{
				nostr=strbuf.Substring(i*8, 8);
				dv3.RowFilter="o_syscd='C1' and o_iano='"+nostr+"'";
				if(dv3.Count>0)
				{
					XmlDoc.LoadXml(dv3[0].Row["o_xmldata"].ToString());
					ItemMain=XmlDoc.SelectSingleNode("/root");
					ItemOrder=XmlDoc.SelectSingleNode("/root/訂單");
					ItemOrder["付款方式"].FirstChild.InnerText=ddlPayType.SelectedItem.Value.Trim();
					this.sqlUpdateOrder.Parameters["@o_pytpcd"].Value=ddlPayType.SelectedItem.Value.Trim();
					this.sqlUpdateOrder.Parameters["@o_xmldata"].Value=ItemMain.OuterXml;
					//				this.sqlUpdateOrder.Parameters["@o_status"].Value="5";	//已繳款
					this.sqlUpdateOrder.Parameters["@o_syscd"].Value="C1";
					this.sqlUpdateOrder.Parameters["@o_iano"].Value=nostr;
					this.sqlUpdateOrder.Connection.Open();
					this.sqlUpdateOrder.ExecuteNonQuery();
					this.sqlUpdateOrder.Connection.Close();
				}
			}
		}
	}
}
