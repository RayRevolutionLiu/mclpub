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
	/// Summary description for PayTypeForm.
	/// </summary>
	public class PayTypeForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.Label lblPayNo;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapterPytp;
		protected System.Data.SqlClient.SqlCommand sqlSelectComPytp;
		protected System.Web.UI.WebControls.DropDownList ddlPayType;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapterPyMaxNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectComPyMaxNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapterIaS;
		protected System.Data.SqlClient.SqlCommand sqlSelectComIaS;
		protected System.Web.UI.WebControls.TextBox tbxAmt;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapterPy;
		protected System.Data.SqlClient.SqlCommand sqlSelectComPy;
		protected System.Data.SqlClient.SqlCommand sqlInsertComPy;
		protected System.Data.SqlClient.SqlCommand sqlUpdateComPy;
		protected System.Data.SqlClient.SqlCommand sqlDeleteComPy;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxChkno;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxChkbnm;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxChkdate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMoseq;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMoitem;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxWaccno;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxWdate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcauthcd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapterIaU;
		protected System.Data.SqlClient.SqlCommand sqlSelectComIaU;
		protected System.Data.SqlClient.SqlCommand sqlInsertComIaU;
		protected System.Data.SqlClient.SqlCommand sqlUpdateComIaU;
		protected System.Data.SqlClient.SqlCommand sqlDeleteComIaU;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapterPyd;
		protected System.Data.SqlClient.SqlCommand sqlSelectComPyd;
		protected System.Data.SqlClient.SqlCommand sqlInsertComPyd;
		protected System.Data.SqlClient.SqlCommand sqlUpdateComPyd;
		protected System.Data.SqlClient.SqlCommand sqlDeleteComPyd;
		protected System.Web.UI.WebControls.RadioButtonList rblCctp;
		protected System.Web.UI.WebControls.Button btnPreStep;
		protected System.Web.UI.WebControls.Label lblAmt;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcDate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno1;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno2;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno3;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxCcno4;
		protected System.Data.SqlClient.SqlCommand sqlUpdateOrder;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxWbcd;
		protected System.Web.UI.WebControls.Panel Panel4;
	
		public PayTypeForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
				lblAmt.Text=Context.Request.QueryString["count"];
				//付款方式
				DataSet ds = new DataSet();
				this.sqlDataAdapterPytp.Fill(ds, "pytp");
				ddlPayType.DataSource=ds;
				ddlPayType.DataTextField="pytp_nm";
				ddlPayType.DataValueField="pytp_pytpcd";
				ddlPayType.DataBind();
				DataSet ds1 = new DataSet();
				this.sqlDataAdapterPyMaxNo.Fill(ds1, "py");
				DataView dv1 = ds1.Tables["py"].DefaultView;
				string	fy=System.DateTime.Today.Year.ToString();
				string	pyno="";
//				Response.Write(dv1[0][0].ToString());
				pyno=dv1[0].Row["max_pyno"].ToString();
				if(pyno.Substring(0,2)==fy.Substring(2,2))
					pyno=Convert.ToString(Int32.Parse(pyno)+1);
				else
					pyno=fy.Substring(2,2)+"000001";
				for(int j=0; j<8-pyno.Length; j++)
					pyno="0"+pyno;
				lblPayNo.Text=pyno;
				int myYear=System.DateTime.Today.Year;
				for(int i=myYear; i<=myYear+10; i++)
					ddlYear.Items.Add(new ListItem(i.ToString(),i.ToString()));
				ddlYear.SelectedIndex=0;
				int myMonth=System.DateTime.Today.Month;
				ddlMonth.SelectedIndex=myMonth-1;
				tbxCcDate.Value=System.DateTime.Today.ToString("yyyy/MM/dd");
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
			this.sqlDeleteComPy = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectComIaU = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterPy = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertComPy = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectComPy = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateComPy = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectComIaS = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertComIaU = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectComPyd = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterPyMaxNo = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectComPyMaxNo = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterIaU = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteComIaU = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateComIaU = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertComPyd = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapterIaS = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectComPytp = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateOrder = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateComPyd = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterPyd = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteComPyd = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapterPytp = new System.Data.SqlClient.SqlDataAdapter();
			this.ddlPayType.SelectedIndexChanged += new System.EventHandler(this.ddlPayType_SelectedIndexChanged);
			this.btnPreStep.Click += new System.EventHandler(this.btnPreStep_Click);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// sqlDeleteComPy
			// 
			this.sqlDeleteComPy.CommandText = "DELETE FROM dbo.py WHERE (py_pyno = @py_pyno) AND (py_syscd = @py_syscd)";
			this.sqlDeleteComPy.Connection = this.sqlConnection1;
			this.sqlDeleteComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectComIaU
			// 
			this.sqlSelectComIaU.CommandText = "SELECT ia_pyno, ia_pyseq, ia_iano, ia_syscd FROM dbo.ia WHERE (ia_syscd = \'C1\')";
			this.sqlSelectComIaU.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapterPy
			// 
			this.sqlDataAdapterPy.DeleteCommand = this.sqlDeleteComPy;
			this.sqlDataAdapterPy.InsertCommand = this.sqlInsertComPy;
			this.sqlDataAdapterPy.SelectCommand = this.sqlSelectComPy;
			this.sqlDataAdapterPy.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																			 new System.Data.Common.DataColumnMapping("py_fgprinted", "py_fgprinted"),
																																																			 new System.Data.Common.DataColumnMapping("py_syscd", "py_syscd"),
																																																			 new System.Data.Common.DataColumnMapping("py_pysdate", "py_pysdate"),
																																																			 new System.Data.Common.DataColumnMapping("py_pysseq", "py_pysseq"),
																																																			 new System.Data.Common.DataColumnMapping("py_pysitem", "py_pysitem")})});
			this.sqlDataAdapterPy.UpdateCommand = this.sqlUpdateComPy;
			// 
			// sqlInsertComPy
			// 
			this.sqlInsertComPy.CommandText = @"INSERT INTO dbo.py(py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem) VALUES (@py_pyno, @py_amt, @py_pytpcd, @py_date, @py_moseq, @py_moitem, @py_chkno, @py_chkbnm, @py_chkdate, @py_waccno, @py_wdate, @py_wbcd, @py_ccno, @py_cctp, @py_ccauthcd, @py_ccvdate, @py_ccdate, @py_fgprinted, @py_syscd, @py_pysdate, @py_pysseq, @py_pysitem)";
			this.sqlInsertComPy.Connection = this.sqlConnection1;
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_amt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_amt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moitem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkbnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkbnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_waccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_waccno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wbcd", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wbcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_cctp", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_cctp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccauthcd", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccauthcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccvdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccvdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_fgprinted", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysitem", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectComPy
			// 
			this.sqlSelectComPy.CommandText = @"SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate,py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py";
			this.sqlSelectComPy.Connection = this.sqlConnection1;
			// 
			// sqlUpdateComPy
			// 
			this.sqlUpdateComPy.CommandText = @"UPDATE dbo.py SET py_pyno = @py_pyno, py_amt = @py_amt, py_pytpcd = @py_pytpcd, py_date = @py_date, py_moseq = @py_moseq, py_moitem = @py_moitem, py_chkno = @py_chkno, py_chkbnm = @py_chkbnm, py_chkdate = @py_chkdate, py_waccno = @py_waccno, py_wdate = @py_wdate, py_wbcd = @py_wbcd, py_ccno = @py_ccno, py_cctp = @py_cctp, py_ccauthcd = @py_ccauthcd, py_ccvdate = @py_ccvdate, py_fgprinted = @py_fgprinted, py_syscd = @py_syscd, py_pysdate = @py_pysdate, py_pysseq = @py_pysseq, py_pysitem = @py_pysitem WHERE (py_pyno = @Original_py_pyno) AND (py_syscd = @Original_py_syscd)";
			this.sqlUpdateComPy.Connection = this.sqlConnection1;
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_amt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_amt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkbnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkbnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_waccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_waccno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wbcd", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wbcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_cctp", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_cctp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccauthcd", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccauthcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccvdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccvdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_fgprinted", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateComPy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlSelectComIaS
			// 
			this.sqlSelectComIaS.CommandText = @"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iano, dbo.ia.ia_mfrno, dbo.ia.ia_pyat, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrno, dbo.ia.ia_refno FROM dbo.ia INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_pyno = '')";
			this.sqlSelectComIaS.Connection = this.sqlConnection1;
			// 
			// sqlInsertComIaU
			// 
			this.sqlInsertComIaU.CommandText = "INSERT INTO dbo.ia(ia_pyno, ia_pyseq, ia_iano, ia_syscd) VALUES (@ia_pyno, @ia_py" +
				"seq, @ia_iano, @ia_syscd)";
			this.sqlInsertComIaU.Connection = this.sqlConnection1;
			this.sqlInsertComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT o_xmldata, o_iano, o_custno, o_otp1cd, o_otp1seq, o_syscd FROM dbo.c1_orde" +
				"r";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectComPyd
			// 
			this.sqlSelectComPyd.CommandText = "SELECT pyd_pydid, pyd_syscd, pyd_pyno, pyd_pyditem, pyd_iano FROM dbo.pyd";
			this.sqlSelectComPyd.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapterPyMaxNo
			// 
			this.sqlDataAdapterPyMaxNo.SelectCommand = this.sqlSelectComPyMaxNo;
			this.sqlDataAdapterPyMaxNo.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("max_pyno", "max_pyno")})});
			// 
			// sqlSelectComPyMaxNo
			// 
			this.sqlSelectComPyMaxNo.CommandText = "SELECT MAX(py_pyno) AS max_pyno FROM dbo.py";
			this.sqlSelectComPyMaxNo.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapterIaU
			// 
			this.sqlDataAdapterIaU.DeleteCommand = this.sqlDeleteComIaU;
			this.sqlDataAdapterIaU.InsertCommand = this.sqlInsertComIaU;
			this.sqlDataAdapterIaU.SelectCommand = this.sqlSelectComIaU;
			this.sqlDataAdapterIaU.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																			  new System.Data.Common.DataColumnMapping("ia_pyseq", "ia_pyseq"),
																																																			  new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			  new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd")})});
			this.sqlDataAdapterIaU.UpdateCommand = this.sqlUpdateComIaU;
			// 
			// sqlDeleteComIaU
			// 
			this.sqlDeleteComIaU.CommandText = "DELETE FROM dbo.ia WHERE (ia_iano = @ia_iano) AND (ia_syscd = @ia_syscd)";
			this.sqlDeleteComIaU.Connection = this.sqlConnection1;
			this.sqlDeleteComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlUpdateComIaU
			// 
			this.sqlUpdateComIaU.CommandText = "UPDATE dbo.ia SET ia_pyno = @ia_pyno, ia_pyseq = @ia_pyseq, ia_iano = @ia_iano, i" +
				"a_syscd = @ia_syscd WHERE (ia_iano = @Original_ia_iano) AND (ia_syscd = @Origina" +
				"l_ia_syscd)";
			this.sqlUpdateComIaU.Connection = this.sqlConnection1;
			this.sqlUpdateComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateComIaU.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertComPyd
			// 
			this.sqlInsertComPyd.CommandText = "INSERT INTO dbo.pyd(pyd_syscd, pyd_pyno, pyd_pyditem, pyd_iano) VALUES (@pyd_sysc" +
				"d, @pyd_pyno, @pyd_pyditem, @pyd_iano)";
			this.sqlInsertComPyd.Connection = this.sqlConnection1;
			this.sqlInsertComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_pyditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyditem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_iano", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_xmldata", "o_xmldata"),
																																																				  new System.Data.Common.DataColumnMapping("o_iano", "o_iano"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd")})});
			// 
			// sqlDataAdapterIaS
			// 
			this.sqlDataAdapterIaS.SelectCommand = this.sqlSelectComIaS;
			this.sqlDataAdapterIaS.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			  new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			  new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																			  new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno")})});
			// 
			// sqlSelectComPytp
			// 
			this.sqlSelectComPytp.CommandText = "SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp";
			this.sqlSelectComPytp.Connection = this.sqlConnection1;
			// 
			// sqlUpdateOrder
			// 
			this.sqlUpdateOrder.CommandText = "UPDATE dbo.c1_order SET o_pytpcd = @o_pytpcd, o_xmldata = @o_xmldata, o_status=@o" +
				"_status WHERE (o_syscd = @o_syscd) AND (o_iano = @o_iano)";
			this.sqlUpdateOrder.Connection = this.sqlConnection1;
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 8000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_status", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iano", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateComPyd
			// 
			this.sqlUpdateComPyd.CommandText = "UPDATE dbo.pyd SET pyd_syscd = @pyd_syscd, pyd_pyno = @pyd_pyno, pyd_pyditem = @p" +
				"yd_pyditem, pyd_iano = @pyd_iano WHERE (pyd_pyditem = @Original_pyd_pyditem) AND" +
				" (pyd_pyno = @Original_pyd_pyno) AND (pyd_syscd = @Original_pyd_syscd)";
			this.sqlUpdateComPyd.Connection = this.sqlConnection1;
			this.sqlUpdateComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_pyditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyditem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pyd_pyditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyditem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pyd_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pyd_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapterPyd
			// 
			this.sqlDataAdapterPyd.DeleteCommand = this.sqlDeleteComPyd;
			this.sqlDataAdapterPyd.InsertCommand = this.sqlInsertComPyd;
			this.sqlDataAdapterPyd.SelectCommand = this.sqlSelectComPyd;
			this.sqlDataAdapterPyd.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "pyd", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("pyd_pydid", "pyd_pydid"),
																																																			   new System.Data.Common.DataColumnMapping("pyd_syscd", "pyd_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("pyd_pyno", "pyd_pyno"),
																																																			   new System.Data.Common.DataColumnMapping("pyd_pyditem", "pyd_pyditem"),
																																																			   new System.Data.Common.DataColumnMapping("pyd_iano", "pyd_iano")})});
			this.sqlDataAdapterPyd.UpdateCommand = this.sqlUpdateComPyd;
			// 
			// sqlDeleteComPyd
			// 
			this.sqlDeleteComPyd.CommandText = "DELETE FROM dbo.pyd WHERE (pyd_pyditem = @pyd_pyditem) AND (pyd_pyno = @pyd_pyno)" +
				" AND (pyd_syscd = @pyd_syscd)";
			this.sqlDeleteComPyd.Connection = this.sqlConnection1;
			this.sqlDeleteComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_pyditem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyditem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_pyno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteComPyd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyd_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pyd_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapterPytp
			// 
			this.sqlDataAdapterPytp.SelectCommand = this.sqlSelectComPytp;
			this.sqlDataAdapterPytp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "pytp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pytp_pytpid", "pytp_pytpid"),
																																																				 new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			this.Unload += new System.EventHandler(this.PayTypeForm_Unload);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void PayTypeForm_Unload(object sender, System.EventArgs e)
		{

		}

		private void ddlPayType_SelectedIndexChanged(object sender, System.EventArgs e)
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


		private void btnOK_Click(object sender, System.EventArgs e)
		{
				//Insert繳款檔py, 繳款明細檔pyd, and Update 發票開立單檔 ia
			SaveToPy();
			Update_c1_order_pytpcd();
//			if(Context.Request.QueryString["caller"]=="order")
//				Response.Redirect("SaveMessage.aspx?str=pay&caller=order&id="+Context.Request.QueryString["no"]);
//			else
			Response.Redirect("SaveMessage.aspx?str=pay&caller=");
		}
		private void SaveToPy()
		{
			//繳款單檔 py
			for(int i=0;i<this.sqlInsertComPy.Parameters.Count;i++)
			{
				this.sqlInsertComPy.Parameters[i].Value = "";
			}
			this.sqlInsertComPy.Parameters["@py_pyno"].Value=lblPayNo.Text.Trim();
//			this.sqlInsertComPy.Parameters["@py_syscd"].Value="C1";
			this.sqlInsertComPy.Parameters["@py_amt"].Value=lblAmt.Text.Trim();
			this.sqlInsertComPy.Parameters["@py_pytpcd"].Value=ddlPayType.SelectedItem.Value.Trim();
			this.sqlInsertComPy.Parameters["@py_date"].Value=System.DateTime.Today.ToString("yyyyMMdd");
			this.sqlInsertComPy.Parameters["@py_fgprinted"].Value="0";
			switch(ddlPayType.SelectedItem.Value)
			{
				case "01":
				case "06":
				case "07":
					break;
				case "02":
					this.sqlInsertComPy.Parameters["@py_chkno"].Value=tbxChkno.Value;
					this.sqlInsertComPy.Parameters["@py_chkbnm"].Value=tbxChkbnm.Value;
					this.sqlInsertComPy.Parameters["@py_chkdate"].Value=tbxChkdate.Value.Substring(0,4)+tbxChkdate.Value.Substring(5,2)+tbxChkdate.Value.Substring(8,2);
					break;
				case "03":
					this.sqlInsertComPy.Parameters["@py_moseq"].Value=tbxMoseq.Value;
					this.sqlInsertComPy.Parameters["@py_moitem"].Value=tbxMoitem.Value;
					break;
				case "04":
					this.sqlInsertComPy.Parameters["@py_waccno"].Value=tbxWaccno.Value;
					this.sqlInsertComPy.Parameters["@py_wdate"].Value=tbxWdate.Value.Substring(0,4)+tbxWdate.Value.Substring(5,2)+tbxWdate.Value.Substring(8,2);
					this.sqlInsertComPy.Parameters["@py_wbcd"].Value=tbxWbcd.Value;
					break;
				case "05":
					this.sqlInsertComPy.Parameters["@py_ccno"].Value=tbxCcno1.Value+tbxCcno2.Value+tbxCcno3.Value+tbxCcno4.Value;
					this.sqlInsertComPy.Parameters["@py_cctp"].Value=rblCctp.SelectedItem.Value;
					this.sqlInsertComPy.Parameters["@py_ccauthcd"].Value=tbxCcauthcd.Value;
					this.sqlInsertComPy.Parameters["@py_ccvdate"].Value=ddlYear.SelectedItem.Value+ddlMonth.SelectedItem.Value;
					this.sqlInsertComPy.Parameters["@py_ccdate"].Value=tbxCcDate.Value.Substring(0,4)+tbxCcDate.Value.Substring(5,2)+tbxCcDate.Value.Substring(8,2);
					break;
			}
			this.sqlInsertComPy.Connection.Open();
			this.sqlInsertComPy.ExecuteNonQuery();
			this.sqlInsertComPy.Connection.Close();
			string	nostr;
			string	strbuf=Context.Request.QueryString["no"];
			int	j=1;
			for(int i=0; i<(strbuf.Length/10);i++)
			{
//				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
//				{
					//Insert 繳款明細檔 pyd
//					nostr=((Label)DataList1.Items[i].FindControl("lblNo")).Text;
					nostr=strbuf.Substring(i*10, 10);
					this.sqlInsertComPyd.Parameters["@pyd_syscd"].Value=nostr.Substring(0,2);
					this.sqlInsertComPyd.Parameters["@pyd_iano"].Value=nostr.Substring(2,8);
					this.sqlInsertComPyd.Parameters["@pyd_pyno"].Value=lblPayNo.Text.Trim();
					this.sqlInsertComPyd.Parameters["@pyd_pyditem"].Value=j.ToString();
					this.sqlInsertComPyd.Connection.Open();
					this.sqlInsertComPyd.ExecuteNonQuery();
					this.sqlInsertComPyd.Connection.Close();

					//Update 發票開立單檔 ia
					this.sqlUpdateComIaU.Parameters["@Original_ia_syscd"].Value=nostr.Substring(0,2);
					this.sqlUpdateComIaU.Parameters["@Original_ia_iano"].Value=nostr.Substring(2,8);
					this.sqlUpdateComIaU.Parameters["@ia_syscd"].Value=nostr.Substring(0,2);
					this.sqlUpdateComIaU.Parameters["@ia_iano"].Value=nostr.Substring(2,8);
					this.sqlUpdateComIaU.Parameters["@ia_pyno"].Value=lblPayNo.Text.Trim();
					this.sqlUpdateComIaU.Parameters["@ia_pyseq"].Value=j.ToString();
					this.sqlUpdateComIaU.Connection.Open();
					this.sqlUpdateComIaU.ExecuteNonQuery();
					this.sqlUpdateComIaU.Connection.Close();
					j++;
//				}
			}
		}
		private void Update_c1_order_pytpcd()
		{
			XmlDocument XmlDoc;
			XmlDoc = new System.Xml.XmlDocument();
			
			XmlNode	ItemMain;//=XmlDoc.SelectSingleNode("/root");
			XmlNode	ItemOrder;//=XmlDoc.SelectSingleNode("/root/訂單");
			string	nostr;
			string	strbuf=Context.Request.QueryString["no"];
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_order");
			DataView dv1 = ds1.Tables["c1_order"].DefaultView;

			for(int i=0; i<(strbuf.Length/10);i++)
			{
				nostr=strbuf.Substring(i*10, 10);
				if(nostr.Substring(0,2)=="C1")
				{
					dv1.RowFilter="o_syscd='"+nostr.Substring(0,2)+"' and o_iano='"+nostr.Substring(2,8)+"'";
					XmlDoc.LoadXml(dv1[0].Row["o_xmldata"].ToString());
					ItemMain=XmlDoc.SelectSingleNode("/root");
					ItemOrder=XmlDoc.SelectSingleNode("/root/訂單");
					ItemOrder["付款方式"].FirstChild.InnerText=ddlPayType.SelectedItem.Value.Trim();
					this.sqlUpdateOrder.Parameters["@o_pytpcd"].Value=ddlPayType.SelectedItem.Value.Trim();
					this.sqlUpdateOrder.Parameters["@o_xmldata"].Value=ItemMain.OuterXml;
					this.sqlUpdateOrder.Parameters["@o_status"].Value="5";	//已繳款
					this.sqlUpdateOrder.Parameters["@o_syscd"].Value=nostr.Substring(0,2);
					this.sqlUpdateOrder.Parameters["@o_iano"].Value=nostr.Substring(2,8);
					this.sqlUpdateOrder.Connection.Open();
					this.sqlUpdateOrder.ExecuteNonQuery();
					this.sqlUpdateOrder.Connection.Close();
				}
			}
		}
		private void btnPreStep_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PayFilter.aspx");
		}

	}
}
