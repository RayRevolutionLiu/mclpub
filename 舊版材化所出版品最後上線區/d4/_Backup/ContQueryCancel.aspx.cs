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
	/// Summary description for ContQueryCancel.
	/// </summary>
	public class ContQueryCancel : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaCont;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCmdRecCancel;
		protected System.Web.UI.WebControls.DataGrid dgdCont;
	
		public ContQueryCancel()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Bind_dgdCont();
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
			this.sqlCmdRecCancel = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPPub = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaCont = new System.Data.SqlClient.SqlDataAdapter();
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			// 
			// sqlCmdRecCancel
			// 
			this.sqlCmdRecCancel.CommandText = "UPDATE dbo.c4_cont SET cont_fgcancel = \'0\' WHERE (cont_contno = @cont_contno)";
			this.sqlCmdRecCancel.Connection = this.sqlCnnMRLPPub;
			this.sqlCmdRecCancel.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCnnMRLPPub
			// 
			this.sqlCnnMRLPPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_signdate, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_empno, dbo.c4_cont.cont_mfrno, dbo.c4_cont.cont_pubcate, dbo.c4_cont.cont_aunm, dbo.c4_cont.cont_autel, dbo.c4_cont.cont_aufax, dbo.c4_cont.cont_aucell, dbo.c4_cont.cont_auemail, dbo.c4_cont.cont_disc, dbo.c4_cont.cont_freetm, dbo.c4_cont.cont_totimgtm, dbo.c4_cont.cont_toturltm, dbo.c4_cont.cont_pubtm, dbo.c4_cont.cont_resttm, dbo.c4_cont.cont_totamt, dbo.c4_cont.cont_paidamt, dbo.c4_cont.cont_restamt, dbo.c4_cont.cont_ccont, dbo.c4_cont.cont_csdate, dbo.c4_cont.cont_atp, dbo.c4_cont.cont_matp, dbo.c4_cont.cont_fgclosed, dbo.c4_cont.cont_adremark, dbo.c4_cont.cont_adsprem, dbo.c4_cont.cont_pdcont, dbo.c4_cont.cont_moddate, dbo.c4_cont.cont_fgpayonce, dbo.c4_cont.cont_fgtemp, dbo.c4_cont.cont_fgpubed, dbo.c4_cont.cont_fgcancel, dbo.c4_cont.cont_modempno, dbo.c4_cont.cont_credate, dbo.mfr.mfr_inm, dbo.cust.cust_nm, dbo.c4_cont.cont_syscd, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno FROM dbo.c4_cont INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c4_cont.cont_custno = dbo.cust.cust_custno WHERE (dbo.c4_cont.cont_fgcancel = '1') AND (dbo.c4_cont.cont_fgtemp = '0') AND (dbo.c4_cont.cont_fgclosed = '0')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPPub;
			// 
			// sqlDaCont
			// 
			this.sqlDaCont.SelectCommand = this.sqlSelectCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
		}

		/// <summary>
		/// Bind已註銷合約
		/// </summary>
		private void Bind_dgdCont()
		{
			DataSet ds = new DataSet();
			sqlDaCont.Fill(ds, "CONT");
			DataView dv = ds.Tables["CONT"].DefaultView;

			dgdCont.DataSource = dv;
			dgdCont.DataBind();

			if (dv.Count>0)
			{
				dgdCont.Visible = true;
				lblInfo.Text = "已註銷合約列表";
			}
			else
			{
				dgdCont.Visible = false;
				lblInfo.Text = "目前無已註銷合約";
			}

			Format_dgdCont_Fields();
		}

		private void Format_dgdCont_Fields()
		{
			for (int i=0; i<dgdCont.Items.Count; i++)
			{
				//一次付清註記
				switch(dgdCont.Items[i].Cells[6].Text.Trim())
				{
					case "0":
						dgdCont.Items[i].Cells[6].Text = "否";
						break;
					case "1":
						dgdCont.Items[i].Cells[6].Text = "是";
						break;
				}

				//結案註記
				switch(dgdCont.Items[i].Cells[7].Text.Trim())
				{
					case "0":
						dgdCont.Items[i].Cells[7].Text = "否";
						break;
					case "1":
						dgdCont.Items[i].Cells[7].Text = "是";
						break;
				}

				//合約類別
				switch(dgdCont.Items[i].Cells[8].Text.Trim())
				{
					case "01":
						dgdCont.Items[i].Cells[8].Text = "一般";
						break;
					case "09":
						dgdCont.Items[i].Cells[8].Text = "推廣";
						break;
				}
			}
		}

		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ContNo = dgdCont.SelectedItem.Cells[1].Text.Trim();

			sqlCmdRecCancel.Parameters["@cont_contno"].Value = ContNo;

			sqlCmdRecCancel.Connection.Open();
			try
			{
				sqlCmdRecCancel.ExecuteNonQuery();
				AlertMsg("合約[編號: "+ ContNo +"]回復成功");
			}
			catch
			{
				AlertMsg("合約回復失敗，請通知聯絡人");
			}
			sqlCmdRecCancel.Connection.Close();

			Bind_dgdCont();
		}
	}
}
