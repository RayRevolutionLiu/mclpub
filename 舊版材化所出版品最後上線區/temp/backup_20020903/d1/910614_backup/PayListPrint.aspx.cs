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
	/// Summary description for PayListPrint.
	/// </summary>
	public class PayListPrint : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblyyyymm;
		protected System.Web.UI.WebControls.Label lblbatch;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
	
		public PayListPrint()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Literal1.Text="";
			Response.Expires=0;
			if (!IsPostBack)
			{
				int myYear=System.DateTime.Today.Year;
				int j=0;
				for(int i=myYear-1; i<=myYear; i++)
				{
					ddlYear.Items.Add(new ListItem(i.ToString(),i.ToString()));
					j++;
				}
				ddlYear.SelectedIndex=j-1;
				int myMonth=System.DateTime.Today.Month;
				ddlMonth.SelectedIndex=myMonth-1;
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.pyseq.pys_pysid, dbo.pyseq.pys_syscd, dbo.pyseq.pys_pysdate, dbo.pyseq.pys_pysseq, dbo.pyseq.pys_toitem, dbo.pyseq.pys_pytpcd, dbo.pyseq.pys_fgprinted, dbo.pyseq.pys_createdate, dbo.pyseq.pys_createmen, dbo.pytp.pytp_nm, dbo.pytp.pytp_pytpcd FROM dbo.pyseq INNER JOIN dbo.pytp ON dbo.pyseq.pys_pytpcd = dbo.pytp.pytp_pytpcd";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pyseq", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("pys_pysid", "pys_pysid"),
																																																			   new System.Data.Common.DataColumnMapping("pys_syscd", "pys_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("pys_pysdate", "pys_pysdate"),
																																																			   new System.Data.Common.DataColumnMapping("pys_pysseq", "pys_pysseq"),
																																																			   new System.Data.Common.DataColumnMapping("pys_toitem", "pys_toitem"),
																																																			   new System.Data.Common.DataColumnMapping("pys_pytpcd", "pys_pytpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pys_fgprinted", "pys_fgprinted"),
																																																			   new System.Data.Common.DataColumnMapping("pys_createdate", "pys_createdate"),
																																																			   new System.Data.Common.DataColumnMapping("pys_createmen", "pys_createmen"),
																																																			   new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.py(py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem) VALUES (@py_pyno, @py_amt, @py_pytpcd, @py_date, @py_moseq, @py_moitem, @py_chkno, @py_chkbnm, @py_chkdate, @py_waccno, @py_wdate, @py_wbcd, @py_ccno, @py_cctp, @py_ccauthcd, @py_ccvdate, @py_ccdate, @py_fgprinted, @py_syscd, @py_pysdate, @py_pysseq, @py_pysitem); SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py WHERE (py_pyno = @Select_py_pyno)";
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
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE dbo.py SET py_pyno = @py_pyno, py_amt = @py_amt, py_pytpcd = @py_pytpcd, p" +
				"y_date = @py_date, py_moseq = @py_moseq, py_moitem = @py_moitem, py_chkno = @py_" +
				"chkno, py_chkbnm = @py_chkbnm, py_chkdate = @py_chkdate, py_waccno = @py_waccno," +
				" py_wdate = @py_wdate, py_wbcd = @py_wbcd, py_ccno = @py_ccno, py_cctp = @py_cct" +
				"p, py_ccauthcd = @py_ccauthcd, py_ccvdate = @py_ccvdate, py_ccdate = @py_ccdate," +
				" py_fgprinted = @py_fgprinted, py_syscd = @py_syscd, py_pysdate = @py_pysdate, p" +
				"y_pysseq = @py_pysseq, py_pysitem = @py_pysitem WHERE (py_pyno = @Original_py_py" +
				"no) AND (py_amt = @Original_py_amt) AND (py_ccauthcd = @Original_py_ccauthcd) AN" +
				"D (py_ccdate = @Original_py_ccdate) AND (py_ccno = @Original_py_ccno) AND (py_cc" +
				"tp = @Original_py_cctp) AND (py_ccvdate = @Original_py_ccvdate) AND (py_chkbnm =" +
				" @Original_py_chkbnm) AND (py_chkdate = @Original_py_chkdate) AND (py_chkno = @O" +
				"riginal_py_chkno) AND (py_date = @Original_py_date) AND (py_fgprinted = @Origina" +
				"l_py_fgprinted) AND (py_moitem = @Original_py_moitem) AND (py_moseq = @Original_" +
				"py_moseq) AND (py_pysdate = @Original_py_pysdate) AND (py_pysitem = @Original_py" +
				"_pysitem) AND (py_pysseq = @Original_py_pysseq) AND (py_pytpcd = @Original_py_py" +
				"tpcd) AND (py_syscd = @Original_py_syscd) AND (py_waccno = @Original_py_waccno) " +
				"AND (py_wbcd = @Original_py_wbcd) AND (py_wdate = @Original_py_wdate); SELECT py" +
				"_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_ch" +
				"kbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, p" +
				"y_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem " +
				"FROM dbo.py WHERE (py_pyno = @Select_py_pyno)";
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
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_amt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_amt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_ccauthcd", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccauthcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_ccdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_ccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_cctp", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_cctp", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_ccvdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccvdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_chkbnm", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkbnm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_chkdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_chkno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_date", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_fgprinted", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_moitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moitem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_moseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moseq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_pysitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysitem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysseq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pytpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_waccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_waccno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_wbcd", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wbcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_py_wdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM dbo.py WHERE (py_pyno = @py_pyno) AND (py_amt = @py_amt) AND (py_ccauthcd = @py_ccauthcd) AND (py_ccdate = @py_ccdate) AND (py_ccno = @py_ccno) AND (py_cctp = @py_cctp) AND (py_ccvdate = @py_ccvdate) AND (py_chkbnm = @py_chkbnm) AND (py_chkdate = @py_chkdate) AND (py_chkno = @py_chkno) AND (py_date = @py_date) AND (py_fgprinted = @py_fgprinted) AND (py_moitem = @py_moitem) AND (py_moseq = @py_moseq) AND (py_pyid = @py_pyid) AND (py_pysdate = @py_pysdate) AND (py_pysitem = @py_pysitem) AND (py_pysseq = @py_pysseq) AND (py_pytpcd = @py_pytpcd) AND (py_syscd = @py_syscd) AND (py_waccno = @py_waccno) AND (py_wbcd = @py_wbcd) AND (py_wdate = @py_wdate)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_amt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_amt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccauthcd", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccauthcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_cctp", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_cctp", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_ccvdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_ccvdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkbnm", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkbnm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_chkno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_chkno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_date", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_fgprinted", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moitem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_moseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_moseq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysitem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysseq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pytpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_waccno", System.Data.SqlDbType.Char, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_waccno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wbcd", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wbcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_wdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_wdate", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "pyseq");
			DataView dv2 = ds2.Tables["pyseq"].DefaultView;
			dv2.RowFilter="pys_pysdate='"+ddlYear.SelectedItem.Value.Trim()+ddlMonth.SelectedItem.Value.Trim()+"'";
			DataGrid1.DataSource=dv2;
			DataGrid1.DataBind();
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			lblyyyymm.Text=DataGrid1.SelectedItem.Cells[1].Text.Trim();
			lblbatch.Text=DataGrid1.SelectedItem.Cells[2].Text.Trim();
			btnPrint.Enabled=true;
			DataSet	ds3=new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "py");
			DataView dv3 = ds3.Tables["py"].DefaultView;
			dv3.RowFilter="py_pysdate = '"+lblyyyymm.Text+"' and py_pysseq = '"+lblbatch.Text+"'";
			//				Response.Write(((Label)e.Item.FindControl("lblpysdate")).Text+"-"+((Label)e.Item.FindControl("lblpysseq")).Text);
			DataGrid2.DataSource=dv3;
			DataGrid2.DataBind();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "srspn");
			DataView dv1 = ds1.Tables["srspn"].DefaultView;
			dv1.RowFilter="srspn_empno = '"+reg+"'";
			if(dv1.Count>0)
			{
				string	cname=dv1[0].Row["srspn_cname"].ToString().Trim();
				string	strbuf="";
				if (DataGrid1.SelectedItem.Cells[4].Text.Trim()=="現金")
					strbuf="py_list1.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (DataGrid1.SelectedItem.Cells[4].Text.Trim()=="票據")
					strbuf="py_list2.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (DataGrid1.SelectedItem.Cells[4].Text.Trim()=="劃撥")
					strbuf="py_list3.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (DataGrid1.SelectedItem.Cells[4].Text.Trim()=="電匯")
					strbuf="py_list4.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (DataGrid1.SelectedItem.Cells[4].Text.Trim()=="信用卡")
					strbuf="py_list5.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
		}
	}
}
