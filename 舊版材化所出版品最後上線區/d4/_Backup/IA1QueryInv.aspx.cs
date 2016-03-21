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
	/// Summary description for IA1QueryInv.
	/// </summary>
	public class IA1QueryInv : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPUB;
		protected System.Web.UI.WebControls.Panel pnlQueryIM;
		protected System.Web.UI.WebControls.TextBox tbxIMNm;
		protected System.Web.UI.WebControls.Button btnQueryIm;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.Panel pnlVerify;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaImCont;
		protected System.Web.UI.WebControls.DataGrid dgdImCont;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdr;
		protected System.Web.UI.WebControls.Label lblContMsg;
		protected System.Web.UI.WebControls.Label lblAdrMsg;
		protected System.Web.UI.WebControls.Label lblTotalMsg;
		protected System.Web.UI.WebControls.Button btnGoGenIA;
		protected System.Data.SqlClient.SqlCommand sqlCmdRunSp;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnGoIA;
	
		public IA1QueryInv()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
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
			this.sqlCnnMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlDaImCont = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDaAdr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdRunSp = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.btnQueryIm.Click += new System.EventHandler(this.btnQueryIm_Click);
			this.dgdImCont.SelectedIndexChanged += new System.EventHandler(this.dgdImCont_SelectedIndexChanged);
			this.btnGoIA.Click += new System.EventHandler(this.btnGoIA_Click);
			this.btnGoGenIA.Click += new System.EventHandler(this.btnGoGenIA_Click);
			// 
			// sqlCnnMRLPUB
			// 
			this.sqlCnnMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaImCont
			// 
			this.sqlDaImCont.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlDaAdr
			// 
			this.sqlDaAdr.SelectCommand = this.sqlSelectCommand2;
			// 
			// sqlCmdRunSp
			// 
			this.sqlCmdRunSp.CommandText = "dbo.sp_c4_add_1_ia_1";
			this.sqlCmdRunSp.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdRunSp.Connection = this.sqlCnnMRLPUB;
			this.sqlCmdRunSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdRunSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdRunSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdRunSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdRunSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iab_createmen", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.invmfr.im_syscd, dbo.invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_mfrno, dbo.invmfr.im_nm, dbo.invmfr.im_jbti, dbo.invmfr.im_zip, dbo.invmfr.im_addr, dbo.invmfr.im_tel, dbo.invmfr.im_fax, dbo.invmfr.im_cell, dbo.invmfr.im_email, dbo.invmfr.im_invcd, dbo.invmfr.im_taxtp, dbo.invmfr.im_fgitri, dbo.c4_cont.cont_signdate, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_empno, dbo.c4_cont.cont_mfrno, dbo.c4_cont.cont_fgclosed, dbo.c4_cont.cont_fgpayonce, dbo.c4_cont.cont_fgtemp, dbo.c4_cont.cont_fgpubed, dbo.c4_cont.cont_fgcancel, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_syscd FROM dbo.invmfr INNER JOIN dbo.c4_cont ON dbo.invmfr.im_syscd = dbo.c4_cont.cont_syscd AND dbo.invmfr.im_contno = dbo.c4_cont.cont_contno WHERE (dbo.c4_cont.cont_fgclosed <> '1') AND (dbo.c4_cont.cont_fgtemp = '0') AND (dbo.c4_cont.cont_fgcancel <> '1') AND (dbo.c4_cont.cont_conttp = '01')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c4_adr.adr_syscd, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_invamt, dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_alttext, dbo.c4_adr.adr_imgurl, dbo.c4_adr.adr_drafttp, dbo.c4_adr.adr_navurl, dbo.c4_adr.adr_impr, dbo.c4_adr.adr_fgfixad, dbo.c4_adr.adr_fggot, dbo.c4_adr.adr_adamt, dbo.c4_adr.adr_desamt, dbo.c4_adr.adr_chgamt, dbo.c4_adr.adr_remark, dbo.c4_adr.adr_fginvself, dbo.c4_adr.adr_projno, dbo.c4_adr.adr_costctr, dbo.c4_adr.adr_imseq, dbo.c4_adr.adr_fgact, dbo.c4_adr.adr_urltp FROM (SELECT DISTINCT adrd_syscd , adrd_contno , adrd_adrseq FROM c4_adrd WHERE adrd_fginved = '0') DERIVEDTBL INNER JOIN dbo.c4_adr ON DERIVEDTBL.adrd_syscd = dbo.c4_adr.adr_syscd AND DERIVEDTBL.adrd_contno = dbo.c4_adr.adr_contno AND DERIVEDTBL.adrd_adrseq = dbo.c4_adr.adr_seq";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPUB;
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
			this.pnlQueryIM.Visible = true;
			this.pnlAdr.Visible = false;
			this.pnlVerify.Visible = false;
		}

		//查詢發票廠商名稱
		private void btnQueryIm_Click(object sender, System.EventArgs e)
		{
			if (this.tbxIMNm.Text.Trim() == "")
			{
				AlertMsg("請輸入發票廠商名稱");
				return;
			}

			this.pnlAdr.Visible = false;
			this.pnlVerify.Visible = false;
			this.dgdImCont.SelectedIndex = -1;
			Bind_dgdImCont();
		}

		private void Bind_dgdImCont()
		{
			DataSet ds = new DataSet();
			this.sqlDaImCont.Fill(ds, "IMCONT");
			DataView dv = ds.Tables["IMCONT"].DefaultView;
			dv.RowFilter = "im_nm LIKE '%" + this.tbxIMNm.Text.Trim() + "%'";

			if (dv.Count>0)
			{
				this.dgdImCont.DataSource = dv;
				this.dgdImCont.DataBind();
				this.dgdImCont.Visible = true;
				this.lblContMsg.Text = "該廠商發票收件人有下列資料";
			}
			else
			{
				AlertMsg("查無此發票廠商");
				this.dgdImCont.Visible = false;
				this.pnlAdr.Visible = false;
				return;
			}
		}

		//選定發票廠商資料了
		private void dgdImCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.pnlAdr.Visible = true;
			Bind_dgdAdr();
		}

		private void Bind_dgdAdr()
		{
			string ContNo = this.dgdImCont.SelectedItem.Cells[1].Text.Trim();
			string ImSeq = this.dgdImCont.SelectedItem.Cells[2].Text.Trim();

			DataSet ds = new DataSet();
			this.sqlDaAdr.Fill(ds, "ADR");
			DataView dv = ds.Tables["ADR"].DefaultView;
			dv.RowFilter = "adr_contno='" + ContNo + "' AND adr_imseq = '" + ImSeq + "'";

			if (dv.Count>0)
			{
				this.dgdAdr.DataSource = dv;
				this.dgdAdr.DataBind();
				this.dgdAdr.Visible = true;
				this.lblAdrMsg.Text = this.dgdImCont.SelectedItem.Cells[3].Text.Trim()+"有下列廣告未付";
			}
			else
			{
				AlertMsg("該發票廠商無廣告");
				this.pnlAdr.Visible = false;
				return;
			}
		}

		private void btnGoIA_Click(object sender, System.EventArgs e)
		{
			this.pnlVerify.Visible = true;
			int intTotInvAmt = 0;

			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if ( ((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked )
				{
					intTotInvAmt += Convert.ToInt32(dgdAdr.Items[i].Cells[5].Text.Trim());
				}
			}

			this.lblTotalMsg.Text = "總共選取的發票金額為 " + intTotInvAmt.ToString("c0");
		}

		private void btnGoGenIA_Click(object sender, System.EventArgs e)
		{
			int intAdrCount = 0;
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if ( ((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked )
				{
					intAdrCount++;
				}
			}

			if (intAdrCount==0)
			{
				AlertMsg("未選取要開立發票的廣告");
				return;
			}

			string ContNo = dgdImCont.SelectedItem.Cells[1].Text.Trim();
			string ImSeq = dgdImCont.SelectedItem.Cells[2].Text.Trim();
			string DomainUser = User.Identity.Name;
			string whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);

			string strOriginalCommandText = this.sqlCmdRunSp.CommandText;
			this.sqlCmdRunSp.Parameters["@syscd"].Value = "C4";
			this.sqlCmdRunSp.Parameters["@contno"].Value = ContNo;
			this.sqlCmdRunSp.Parameters["@imseq"].Value = ImSeq;
			this.sqlCmdRunSp.Parameters["@iab_createmen"].Value = whoami;

			string AdrSeq = "";
			this.sqlCmdRunSp.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdRunSp.Connection.BeginTransaction();
			this.sqlCmdRunSp.Transaction = myTrans;

//          測試update adrd的command
//			for (int i=0; i<dgdAdr.Items.Count; i++)
//			{
//				if ( ((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked )
//				{
//					AdrSeq = dgdAdr.Items[i].Cells[2].Text.Trim();
//					Response.Write("UPDATE c4_adrd SET adrd_fginved = 'v' WHERE adrd_contno='" + ContNo + "' AND adrd_adrseq='" + AdrSeq + "'<br>");
//				}
//			}

			try
			{
				//選定！
				this.sqlCmdRunSp.CommandType = CommandType.Text;
				for (int i=0; i<dgdAdr.Items.Count; i++)
				{
					if ( ((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked )
					{
						AdrSeq = dgdAdr.Items[i].Cells[2].Text.Trim();
						this.sqlCmdRunSp.CommandText = "UPDATE c4_adrd SET adrd_fginved = 'v' WHERE adrd_contno='" + ContNo + "' AND adrd_adrseq='" + AdrSeq + "'";
						this.sqlCmdRunSp.ExecuteNonQuery();
					}
				}

				//執行
				this.sqlCmdRunSp.CommandText = strOriginalCommandText;
				this.sqlCmdRunSp.CommandType = CommandType.StoredProcedure;
				this.sqlCmdRunSp.ExecuteNonQuery();

				myTrans.Commit();

				AlertMsg("產生IA、IAD成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				AlertMsg("產生IA、IAD失敗");
				AlertMsg(ex.Message);
			}
			this.sqlCmdRunSp.Connection.Close();

		}
	}
}
