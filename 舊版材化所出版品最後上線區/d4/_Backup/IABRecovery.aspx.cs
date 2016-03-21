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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for IABRecovery.
	/// </summary>
	public class IABRecovery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel pnlQuery;
		protected System.Web.UI.WebControls.TextBox tbxIaMonth;
		protected System.Web.UI.WebControls.TextBox tbxIabNo;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.RegularExpressionValidator revIaMonth;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvIaMonth;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvIabNo;
		protected System.Web.UI.WebControls.RegularExpressionValidator revIabNo;
		protected System.Web.UI.WebControls.Panel pnlIaList;
		protected System.Web.UI.WebControls.Button btnIabRecovery;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Data.SqlClient.SqlConnection sqlCnnMrlPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaIa;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataGrid dgdIa;
		protected System.Data.SqlClient.SqlCommand sqlCmdExecSp;
		protected System.Web.UI.WebControls.Button btnClear;
	
		public IABRecovery()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
				PanelState(1);
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
			this.sqlDaIa = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMrlPub = new System.Data.SqlClient.SqlConnection();
			this.sqlCmdExecSp = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnIabRecovery.Click += new System.EventHandler(this.btnIabRecovery_Click);
			// 
			// sqlDaIa
			// 
			this.sqlDaIa.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT ia_iaid, ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno FROM dbo.ia WHERE (ia_syscd = 'C4') AND (ia_iasdate = '') AND (ia_iasseq = '') AND (ia_iaitem = '')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMrlPub;
			// 
			// sqlCnnMrlPub
			// 
			this.sqlCnnMrlPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlCmdExecSp
			// 
			this.sqlCmdExecSp.CommandText = "sp_c4_delete_ia_batch";
			this.sqlCmdExecSp.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdExecSp.Connection = this.sqlCnnMrlPub;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//放一個Alert在client script
		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private void InitData()
		{
			//預設為這個月
			this.tbxIaMonth.Text = DateTime.Today.ToString("yyyy/MM");
		}

		//控制panel的顯示
		private void PanelState(int state)
		{
			switch(state)
			{
				case 1:
					this.pnlQuery.Visible = true;
					this.pnlIaList.Visible = false;
					break;
				case 2:
					this.pnlQuery.Visible = true;
					this.pnlIaList.Visible = true;
					break;
			}
		}

		//清除重查
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.tbxIaMonth.Text = "";
			this.tbxIabNo.Text = "";
			PanelState(1);
		}		
	
		//查詢
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			if (!Page.IsValid)
			{
				AlertMsg("輸入的資料格式錯誤或無資料");
				return;
			}

			DataSet ds = new DataSet();
			this.sqlDaIa.Fill(ds, "IA");
			DataView dv = ds.Tables["IA"].DefaultView;
			dv.RowFilter = "ia_iabseq='' AND ....";

			if (!(dv.Count>0))
			{
				//沒資料
				
			}
			else
			{
				dgdIa.DataSource = dv;
				dgdIa.DataBind();

			}

			PanelState(2);
		}

		private void btnIabRecovery_Click(object sender, System.EventArgs e)
		{
			string IabDate = DateTime.ParseExact(this.tbxIaMonth.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			string IabSeq = this.tbxIabNo.Text.Trim();
			//設定command
			this.sqlCmdExecSp.CommandText = "sp_c4_delete_ia_batch";
			this.sqlCmdExecSp.CommandType = CommandType.StoredProcedure;
			this.sqlCmdExecSp.Parameters.Add("@iabdate", SqlDbType.Char, 6);
			this.sqlCmdExecSp.Parameters.Add("@iabseq", SqlDbType.Char, 6);
			this.sqlCmdExecSp.Parameters["@iabdate"].Value = IabDate;
			this.sqlCmdExecSp.Parameters["@iabseq"].Value = IabSeq;
			this.sqlCmdExecSp.Connection.Open();

			try
			{
				//this.sqlCmdExecSp.ExecuteNonQuery();
				AlertMsg("大批發票回復成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("大批發票回復失敗，請通知聯絡人");
			}
			this.sqlCmdExecSp.Connection.Close();
		}


	}
}
