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
	/// Summary description for PayDelete.
	/// </summary>
	public class PayDelete : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox tbxPyno;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		public PayDelete()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c1_delete_py";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
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
																																																			new System.Data.Common.DataColumnMapping("py_pysitem", "py_pysitem"),
																																																			new System.Data.Common.DataColumnMapping("pyd_pyditem", "pyd_pyditem"),
																																																			new System.Data.Common.DataColumnMapping("pyd_syscd", "pyd_syscd"),
																																																			new System.Data.Common.DataColumnMapping("pyd_iano", "pyd_iano"),
																																																			new System.Data.Common.DataColumnMapping("pyd_cancel", "pyd_cancel"),
																																																			new System.Data.Common.DataColumnMapping("pyd_pyno", "pyd_pyno"),
																																																			new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm"),
																																																			new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																			new System.Data.Common.DataColumnMapping("ias_trans_sap", "ias_trans_sap"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasdate", "ia_iasdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasseq", "ia_iasseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_iaitem", "ia_iaitem")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.py.py_pyid, dbo.py.py_pyno, dbo.py.py_amt, dbo.py.py_pytpcd, dbo.py.py_date, dbo.py.py_moseq, dbo.py.py_moitem, dbo.py.py_chkno, dbo.py.py_chkbnm, dbo.py.py_chkdate, dbo.py.py_waccno, dbo.py.py_wdate, dbo.py.py_wbcd, dbo.py.py_ccno, dbo.py.py_cctp, dbo.py.py_ccauthcd, dbo.py.py_ccvdate, dbo.py.py_ccdate, dbo.py.py_fgprinted, dbo.py.py_syscd, dbo.py.py_pysdate, dbo.py.py_pysseq, dbo.py.py_pysitem, dbo.pyd.pyd_pyditem, dbo.pyd.pyd_syscd, dbo.pyd.pyd_iano, dbo.pyd.pyd_cancel, dbo.pyd.pyd_pyno, dbo.pytp.pytp_nm, dbo.pytp.pytp_pytpcd, dbo.ias.ias_trans_sap, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_syscd, dbo.ias.ias_iasdate, dbo.ias.ias_iasseq FROM dbo.py INNER JOIN dbo.pyd ON dbo.py.py_pyno = dbo.pyd.pyd_pyno INNER JOIN dbo.pytp ON dbo.py.py_pytpcd = dbo.pytp.pytp_pytpcd INNER JOIN dbo.ia ON dbo.pyd.pyd_syscd = dbo.ia.ia_syscd AND dbo.pyd.pyd_iano = dbo.ia.ia_iano LEFT OUTER JOIN dbo.ias ON dbo.ia.ia_syscd = dbo.ias.ias_syscd AND dbo.ia.ia_iasdate = dbo.ias.ias_iasdate AND dbo.ia.ia_iasseq = dbo.ias.ias_iasseq";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataGrid1.Visible=false;
			btnDelete.Visible=false;
			bool	flag1=true;
			lblMessage.Text="";
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "py");
			DataView dv1 = ds1.Tables["py"].DefaultView;
			dv1.RowFilter="py_pyno='"+tbxPyno.Text.Trim()+"'";
			if(dv1.Count<=0)
				lblMessage.Text="<<查無此繳款編號>>";
			else
			{
				if(dv1[0].Row["py_pysdate"].ToString().Trim()=="")
				{
					for(int	i=0; i< dv1.Count; i++)
					{
						if(dv1[i].Row["ias_trans_sap"].ToString().Trim()=="1")
							flag1=false;
					}
					if(flag1)
					{
						DataGrid1.Visible=true;
						DataGrid1.DataSource=dv1;
						DataGrid1.DataBind();
						btnDelete.Visible=true;
					}
					else
						lblMessage.Text="<<此繳款資料之發票已轉SAP, 不允許刪除>>";
				}
				else
					lblMessage.Text="<<此繳款資料已產生繳款清單不允許刪除!!>>";
			}

		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.sqlCommand1.Parameters["@pyno"].Value=tbxPyno.Text.Trim();
			this.sqlCommand1.Connection.Open();
			SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
			myReader.Read();
			myReader.Close();
			this.sqlCommand1.Connection.Close();
			DataGrid1.Visible=false;
			btnDelete.Visible=false;
			lblMessage.Text="<<刪除繳款資料已完成>>";
		}
	}
}
