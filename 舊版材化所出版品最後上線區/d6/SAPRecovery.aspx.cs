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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for SAPRecovery.
	/// </summary>
	public class SAPRecovery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btn_Recovery;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCmd1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMessage1;
		protected System.Web.UI.WebControls.TextBox lblyyyymm;
		protected System.Web.UI.WebControls.TextBox lblbatchseq;
		protected System.Data.SqlClient.SqlCommand sqlCmd2;
	
		public SAPRecovery()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
//				DataSet	ds1=new DataSet();
//				this.sqlDataAdapter1.Fill(ds1, "ias");
//				DataView dv1 = ds1.Tables["ias"].DefaultView;
//				dv1.RowFilter="ias_trans_sap = '1'";
//				DataGrid1.DataSource=dv1;
//				DataGrid1.DataBind();
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
			this.sqlCmd1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmd2 = new System.Data.SqlClient.SqlCommand();
			this.btn_Recovery.Click += new System.EventHandler(this.btn_Recovery_Click);
			// 
			// sqlCmd1
			// 
			this.sqlCmd1.CommandText = "SET XACT_ABORT ON";
			this.sqlCmd1.CommandTimeout = 300;
			this.sqlCmd1.Connection = this.sqlConnection1;
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "dbo.sp_sap_recovery_002";
			this.sqlCommand2.CommandTimeout = 300;
			this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@batch_seq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rtn", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Output, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_sap_recovery_001";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@batch_seq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rtn", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Output, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmd2
			// 
			this.sqlCmd2.CommandText = "SET XACT_ABORT OFF";
			this.sqlCmd2.CommandTimeout = 300;
			this.sqlCmd2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_Recovery_Click(object sender, System.EventArgs e)
		{
			if(lblyyyymm.Text.Trim()=="")
			{
				lblMessage1.Text="轉檔年月不可空白";
				return;
			}
			if(lblbatchseq.Text.Trim()=="")
			{
				lblMessage1.Text="批次不可空白";
				return;
			}
			if(Recovery001())
			{
				lblMessage1.Text="Recovery001-Error!";
				return;
			}
			if(Recovery002())
			{
				lblMessage1.Text="Recovery002-Error!";
				return;
			}
			lblMessage1.Text="發票開立單轉SAP回復--成功";

/*			this.sqlCommand1.Parameters["@yyyymm"].Value=lblyyyymm.Text;
			this.sqlCommand1.Parameters["@batch_seq"].Value=lblbatch.Text;
			this.sqlCommand1.Parameters["@rtn"].Value="";
			this.sqlCommand1.Connection.Open();
			SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
			myReader.Read();
			myReader.Close();
//			this.sqlCmd1.Connection.Open();
			this.sqlCmd1.ExecuteNonQuery();
			this.sqlCommand2.Parameters["@yyyymm"].Value=lblyyyymm.Text;
			this.sqlCommand2.Parameters["@batch_seq"].Value=lblbatch.Text;
			this.sqlCommand2.Parameters["@rtn"].Value="";
//			this.sqlCommand2.Connection.Open();
			myReader=this.sqlCommand2.ExecuteReader();
			myReader.Read();
			myReader.Close();
//			this.sqlCommand2.Connection.Close();
			//this.sqlCmd2.Connection.Open();
			this.sqlCmd2.ExecuteNonQuery();
//			this.sqlCmd2.Connection.Close();
			this.sqlCommand1.Connection.Close();*/

		}

		#region sp_sap_recovery_001, sp_sap_recovery_002
		public bool Recovery001()
		{

			SqlConnection myConnection = new SqlConnection();
			myConnection.ConnectionString = ConfigurationSettings.AppSettings.Get("itridpa_mrlpub");
			string strCmd = "sp_sap_recovery_001";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
			SqlParameter param_yyyymm = new SqlParameter("@yyyymm", SqlDbType.Char, 6);
			param_yyyymm.Value = lblyyyymm.Text.Trim();
			myCommand.Parameters.Add(param_yyyymm);

			SqlParameter param_batch_seq = new SqlParameter("@batch_seq", SqlDbType.Char, 6);
			param_batch_seq.Value = lblbatchseq.Text.Trim();
			myCommand.Parameters.Add(param_batch_seq);


			// OUTPUT Parameter
			SqlParameter param_rtn = new SqlParameter("@rtn", SqlDbType.Char, 6);
			param_rtn.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_rtn);
			
			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//影響的資料數如果大於0就是該im無法刪除
			if (param_rtn.Value=="1")
				return false;
			else
				return true;
		}

		public bool Recovery002()
		{

			SqlConnection myConnection = new SqlConnection();
			myConnection.ConnectionString = ConfigurationSettings.AppSettings.Get("itridpa_mrlpub");
			string strCmd = "sp_sap_recovery_002";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
			SqlParameter param_yyyymm = new SqlParameter("@yyyymm", SqlDbType.Char, 6);
			param_yyyymm.Value = lblyyyymm.Text.Trim();
			myCommand.Parameters.Add(param_yyyymm);

			SqlParameter param_batch_seq = new SqlParameter("@batch_seq", SqlDbType.Char, 6);
			param_batch_seq.Value = lblbatchseq.Text.Trim();
			myCommand.Parameters.Add(param_batch_seq);


			// OUTPUT Parameter
			SqlParameter param_rtn = new SqlParameter("@rtn", SqlDbType.Char, 6);
			param_rtn.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_rtn);
			
			myConnection.Open();
			this.sqlCmd1.ExecuteNonQuery();
			myCommand.ExecuteNonQuery();
			this.sqlCmd2.ExecuteNonQuery();
			myConnection.Close();

			//影響的資料數如果大於0就是該im無法刪除
			if (param_rtn.Value=="1")
				return false;
			else
				return true;
		}
		#endregion

	}
}
