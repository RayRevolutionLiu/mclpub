using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for RecoveryPayList.
	/// </summary>
	public class RecoveryPayList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label lblyyyymm;
		protected System.Web.UI.WebControls.Label lblbatch;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
	
		public RecoveryPayList()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.pyseq.pys_pysid, dbo.pyseq.pys_syscd, dbo.pyseq.pys_pysdate, dbo.pyseq.pys_pysseq, dbo.pyseq.pys_toitem, dbo.pyseq.pys_pytpcd, dbo.pyseq.pys_fgprinted, dbo.pyseq.pys_createdate, dbo.pyseq.pys_createmen, dbo.pytp.pytp_nm, dbo.pytp.pytp_pytpcd FROM dbo.pyseq INNER JOIN dbo.pytp ON dbo.pyseq.pys_pytpcd = dbo.pytp.pytp_pytpcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c1_delete_pyseq";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lblMessage.Text="";
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "pyseq");
			DataView dv1 = ds1.Tables["pyseq"].DefaultView;
			dv1.RowFilter="pys_pysdate='"+ddlYear.SelectedItem.Value.Trim()+ddlMonth.SelectedItem.Value.Trim()+"'";
			DataGrid1.DataSource=dv1;
			DataGrid1.DataBind();

		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblyyyymm.Text=DataGrid1.SelectedItem.Cells[1].Text.Trim();
			lblbatch.Text=DataGrid1.SelectedItem.Cells[2].Text.Trim();
			btnDelete.Enabled=true;
			DataSet	ds2=new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "py");
			DataView dv2 = ds2.Tables["py"].DefaultView;
			dv2.RowFilter="py_pysdate = '"+lblyyyymm.Text+"' and py_pysseq = '"+lblbatch.Text+"'";
			//				Response.Write(((Label)e.Item.FindControl("lblpysdate")).Text+"-"+((Label)e.Item.FindControl("lblpysseq")).Text);
			DataGrid2.DataSource=dv2;
			DataGrid2.DataBind();

		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.sqlCommand1.Parameters["@pysdate"].Value=lblyyyymm.Text.Trim();
			this.sqlCommand1.Parameters["@pysseq"].Value=lblbatch.Text.Trim();
			this.sqlCommand1.Connection.Open();
			SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
			myReader.Read();
			myReader.Close();
			this.sqlCommand1.Connection.Close();
			DataGrid2.Visible=false;
			btnDelete.Enabled=false;
			lblyyyymm.Text="";
			lblbatch.Text="";
			lblMessage.Text="<<刪除繳款資料已完成>>";
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "pyseq");
			DataView dv1 = ds1.Tables["pyseq"].DefaultView;
			dv1.RowFilter="pys_pysdate='"+ddlYear.SelectedItem.Value.Trim()+ddlMonth.SelectedItem.Value.Trim()+"'";
			DataGrid1.DataSource=dv1;
			DataGrid1.DataBind();

		}
	}
}
