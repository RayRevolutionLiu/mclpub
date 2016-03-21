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
	/// Summary description for AdPrePublish.
	/// </summary>
	public class AdPrePublish : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblStep1;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Web.UI.WebControls.TextBox tbxNavUrl;
		protected System.Web.UI.WebControls.TextBox tbxAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxInvAmt;
		protected System.Web.UI.WebControls.TextBox tbxAltText;
		protected System.Web.UI.WebControls.TextBox tbxDesAmt;
		protected System.Web.UI.WebControls.DropDownList ddlKey;
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Web.UI.WebControls.TextBox tbxChgAmt;
		protected System.Web.UI.WebControls.TextBox tbxBeginDate;
		protected System.Web.UI.WebControls.ImageButton imbStartDate;
		protected System.Web.UI.WebControls.DropDownList ddlFgGot;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.ImageButton imbEndDate;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.DropDownList ddlFgFixAd;
		protected System.Web.UI.WebControls.TextBox tbxImpression;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.Panel pnlInputArea;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdCnt;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Panel pnlAllAdr;
		protected System.Web.UI.WebControls.Label lblAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdr;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsAdr;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPUB;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetMaxAdrSeq;
		protected System.Data.SqlClient.SqlCommand sqlCmdDelAdr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaIm;
		protected System.Web.UI.WebControls.RadioButtonList rblDraftTp;
		protected System.Web.UI.WebControls.RadioButtonList rblUrlTp;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaProj;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Label lblTotDays;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidOldContNo;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblContTp;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblSEDate;
		protected System.Web.UI.WebControls.Label lblPubTm;
		protected System.Web.UI.WebControls.Label lblFreeTm;
		protected System.Web.UI.WebControls.Label lblDisc;
		protected System.Web.UI.WebControls.Label lblImgTm;
		protected System.Web.UI.WebControls.Label lblUrlTm;
		protected System.Web.UI.WebControls.Calendar calCntView;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Literal litAlert;
		protected System.Data.SqlClient.SqlCommand sqlCmdCheckAdrd;
		protected System.Web.UI.WebControls.Button btnDoModify;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDateTarget;
	
		public AdPrePublish()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				this.btnDoModify.Visible = false;
				this.btnSave.Visible = true;
				this.ddlFgGot.SelectedIndex = 1;
				this.ddlFgGot.Enabled = false;

				if (Request.QueryString["NewContNo"] != null)
				{
					this.tbxContNo.Text = Request.QueryString["NewContNo"];
					this.calCntView.SelectedDate = DateTime.Today;
				}

				LoadContData();

				this.hidOldContNo.Value = Request.QueryString["OldContNo"];
				BindGrid();
				Bind_dgdAdr();
				this.calSelectAdDate.Visible = false;
				Bind_ddlInvMfr();
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		//顯示參考值
		private void BindGrid()
		{
			string SinceDate = calCntView.SelectedDate.ToString("yyyyMMdd");
			DataSet ds = new DataSet();
			this.sqlDaAdCnt.Fill(ds, "ADCOUNT");
			DataView dv = ds.Tables["ADCOUNT"].DefaultView;
			dv.RowFilter = "cnt_adcate = '" + this.ddlAdCate.SelectedItem.Value + "' AND cnt_date>='" + SinceDate + "'";

			if (!(dv.Count>0))
			{
				//沒資料，所以從頭列出
				dv.RowFilter = "cnt_adcate = '" + this.ddlAdCate.SelectedItem.Value + "'";
			}

			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();

			this.lblTitle.Text = this.ddlAdCate.SelectedItem.Text + "的廣告剩餘空間表，紅色0表示該位置滿檔";

			for(int i=0; i<DataGrid1.Items.Count; i++)
			{
				for(int j=1; j<DataGrid1.Items[i].Cells.Count; j++)
				{
					int tmp = Convert.ToInt32(DataGrid1.Items[i].Cells[j].Text.Trim());
					int val = 20 - tmp;
					DataGrid1.Items[i].Cells[j].Text = val.ToString();
					if (val==0)
					{
						//DataGrid1.Items[i].Cells[j].BackColor = Color.Fuchsia;
						DataGrid1.Items[i].Cells[j].ForeColor = Color.Red;
						DataGrid1.Items[i].Cells[j].Font.Bold = true;
					}
				}
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

			this.sqlCmdInsAdr = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlDaProj = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelAdr = new System.Data.SqlClient.SqlCommand();
			this.sqlDaIm = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaAdr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetMaxAdrSeq = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaAdCnt = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdCheckAdrd = new System.Data.SqlClient.SqlCommand();
			this.dgdAdr.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_DeleteCommand);
			this.dgdAdr.SelectedIndexChanged += new System.EventHandler(this.dgdAdr_SelectedIndexChanged);
			this.imbStartDate.Click += new System.Web.UI.ImageClickEventHandler(this.imbStartDate_Click);
			this.imbEndDate.Click += new System.Web.UI.ImageClickEventHandler(this.imbEndDate_Click);
			this.ddlAdCate.SelectedIndexChanged += new System.EventHandler(this.ddlAdCate_SelectedIndexChanged);
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.ddlFgFixAd.SelectedIndexChanged += new System.EventHandler(this.ddlFgFixAd_SelectedIndexChanged);
			this.tbxAdAmt.TextChanged += new System.EventHandler(this.tbxAdAmt_TextChanged);
			this.tbxDesAmt.TextChanged += new System.EventHandler(this.tbxDesAmt_TextChanged);
			this.tbxChgAmt.TextChanged += new System.EventHandler(this.tbxChgAmt_TextChanged);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.calCntView.SelectionChanged += new System.EventHandler(this.calCntView_SelectionChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnDoModify.Click += new System.EventHandler(this.btnDoModify_Click);
			// 
			// sqlCmdInsAdr
			// 
			this.sqlCmdInsAdr.CommandText = "dbo.sp_c4_add_adr";
			this.sqlCmdInsAdr.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdInsAdr.Connection = this.sqlCnnMRLPUB;
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_sdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_edate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_invamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_keyword", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_alttext", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imgurl", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_drafttp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_navurl", System.Data.SqlDbType.Char, 255, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_urltp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_impr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_desamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(7)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_remark", System.Data.SqlDbType.Char, 50, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fgfixad", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCnnMRLPUB
			// 
			this.sqlCnnMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaProj
			// 
			this.sqlDaProj.SelectCommand = this.sqlSelectCommand4;
			this.sqlDaProj.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table", "proj", new System.Data.Common.DataColumnMapping[] {
																																																		new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																		new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																		new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																		new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																		new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																		new System.Data.Common.DataColumnMapping("proj_cont", "proj_cont")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT proj_syscd, proj_bkcd, proj_fgitri, proj_projno, proj_costctr, proj_cont F" +
				"ROM dbo.proj";
			this.sqlSelectCommand4.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdDelAdr
			// 
			this.sqlCmdDelAdr.CommandText = "dbo.sp_c4_delete_adr";
			this.sqlCmdDelAdr.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdDelAdr.Connection = this.sqlCnnMRLPUB;
			this.sqlCmdDelAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdDelAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDaIm
			// 
			this.sqlDaIm.SelectCommand = this.sqlSelectCommand3;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_fgitri, im_taxtp, im_in" +
				"vcd FROM dbo.invmfr WHERE (im_syscd = \'C4\') AND (im_contno = @im_contno)";
			this.sqlSelectCommand3.Connection = this.sqlCnnMRLPUB;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDaAdr
			// 
			this.sqlDaAdr.SelectCommand = this.sqlSelectCommand2;
			this.sqlDaAdr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "c4_adr", new System.Data.Common.DataColumnMapping[] {
																																																		 new System.Data.Common.DataColumnMapping("adr_syscd", "adr_syscd"),
																																																		 new System.Data.Common.DataColumnMapping("adr_contno", "adr_contno"),
																																																		 new System.Data.Common.DataColumnMapping("adr_sdate", "adr_sdate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_edate", "adr_edate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_seq", "adr_seq"),
																																																		 new System.Data.Common.DataColumnMapping("adr_invamt", "adr_invamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_adcate", "adr_adcate"),
																																																		 new System.Data.Common.DataColumnMapping("adr_keyword", "adr_keyword"),
																																																		 new System.Data.Common.DataColumnMapping("adr_alttext", "adr_alttext"),
																																																		 new System.Data.Common.DataColumnMapping("adr_imgurl", "adr_imgurl"),
																																																		 new System.Data.Common.DataColumnMapping("adr_drafttp", "adr_drafttp"),
																																																		 new System.Data.Common.DataColumnMapping("adr_navurl", "adr_navurl"),
																																																		 new System.Data.Common.DataColumnMapping("adr_urltp", "adr_urltp"),
																																																		 new System.Data.Common.DataColumnMapping("adr_impr", "adr_impr"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fgfixad", "adr_fgfixad"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fggot", "adr_fggot"),
																																																		 new System.Data.Common.DataColumnMapping("adr_adamt", "adr_adamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_desamt", "adr_desamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_chgamt", "adr_chgamt"),
																																																		 new System.Data.Common.DataColumnMapping("adr_remark", "adr_remark"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fginvself", "adr_fginvself"),
																																																		 new System.Data.Common.DataColumnMapping("adr_projno", "adr_projno"),
																																																		 new System.Data.Common.DataColumnMapping("adr_costctr", "adr_costctr"),
																																																		 new System.Data.Common.DataColumnMapping("adr_imseq", "adr_imseq"),
																																																		 new System.Data.Common.DataColumnMapping("adr_fgact", "adr_fgact")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT adr_syscd, adr_contno, adr_sdate, adr_edate, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urltp, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginvself, adr_projno, adr_costctr, adr_imseq, adr_fgact FROM dbo.c4_adr";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdGetMaxAdrSeq
			// 
			this.sqlCmdGetMaxAdrSeq.CommandText = "SELECT MAX(adr_seq) AS MaxSeq FROM dbo.c4_adr GROUP BY adr_contno HAVING (adr_con" +
				"tno = @adr_contno)";
			this.sqlCmdGetMaxAdrSeq.Connection = this.sqlCnnMRLPUB;
			this.sqlCmdGetMaxAdrSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT cnt_date, cnt_adcate, cnt_h0, cnt_h1, cnt_h2, cnt_h3, cnt_h4, cnt_w1, cnt_" +
				"w2, cnt_w3, cnt_w4, cnt_w5, cnt_w6 FROM dbo.c4_adcnt";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlDaAdCnt
			// 
			this.sqlDaAdCnt.SelectCommand = this.sqlSelectCommand1;
			this.sqlDaAdCnt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "c4_adcnt", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("cnt_date", "cnt_date"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_adcate", "cnt_adcated"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_h0", "cnt_h0"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_h1", "cnt_h1"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_h2", "cnt_h2"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_h3", "cnt_h3"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_h4", "cnt_h4"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_w1", "cnt_w1"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_w2", "cnt_w2"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_w3", "cnt_w3"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_w4", "cnt_w4"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_w5", "cnt_w5"),
																																																			 new System.Data.Common.DataColumnMapping("cnt_w6", "cnt_w6")})});
			// 
			// sqlCmdCheckAdrd
			// 
			this.sqlCmdCheckAdrd.CommandText = "SELECT COUNT(*) AS C1 FROM mrlpub.dbo.c4_adrd WHERE (adrd_contno = @contno) AND (" +
				"adrd_adrseq = @adrseq) AND (adrd_fginved <> \'0\')";
			this.sqlCmdCheckAdrd.Connection = this.sqlCnnMRLPUB;
			this.sqlCmdCheckAdrd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adrd_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCheckAdrd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adrseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adrd_adrseq", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadContData()
		{
			this.lblContNo.Text = Request.QueryString["NewContNo"].Trim();
			if (Request.QueryString["ContTp"].Trim()=="01")
			{
				this.lblContTp.Text = "一般";
			}
			else
			{
				this.lblContTp.Text = "推廣";
			}
			this.lblSignDate.Text = Request.QueryString["SignDate"].Trim();
			this.lblSEDate.Text = Request.QueryString["SDate"].Trim() + "~" + Request.QueryString["EDate"].Trim();
			this.lblPubTm.Text = Request.QueryString["PubTm"].Trim();
			this.lblFreeTm.Text = Request.QueryString["FreeTm"].Trim();
			this.lblDisc.Text = Request.QueryString["Disc"].Trim();
			this.lblImgTm.Text = Request.QueryString["ImgTm"].Trim();
			this.lblUrlTm.Text = Request.QueryString["UrlTm"].Trim();
		}

		//更換資料
		private void ddlAdCate_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		//遞減...
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//結束日期不可以比開始日期小
			if (DateTime.ParseExact(tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null) > 
				DateTime.ParseExact(tbxEndDate.Text.Trim(), "yyyy/MM/dd", null))
			{
				AlertMsg("結束日期不可以比開始日期小");
				return;
			}

			//日期不能比今天小....
			if ((DateTime.ParseExact(tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null) < DateTime.Today) ||
				(DateTime.ParseExact(tbxEndDate.Text.Trim(), "yyyy/MM/dd", null) < DateTime.Today))
			{
				AlertMsg("落版日期不能小於今日");
				return;
			}

			DataSet ds = new DataSet();
			this.sqlDaAdCnt.Fill(ds, "ADCOUNT");
			DataView dv = ds.Tables["ADCOUNT"].DefaultView;
			dv.RowFilter = "cnt_adcate = '" + this.ddlAdCate.SelectedItem.Value + "'";

			//日期OK了....
			int bd = -1;
			int ed = -1;
//			for (int i=0; i<DataGrid1.Items.Count; i++)
//			{
//				if (DataGrid1.Items[i].Cells[0].Text.Trim() == this.tbxBeginDate.Text.Trim())
//				{
//					bd = i;
//					break;
//				}
//			}

			for (int i=0; i<dv.Count; i++)
			{
				if (dv[i]["cnt_date"].ToString().Trim() == DateTime.ParseExact(this.tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd"))
				{
					bd = i;
					break;
				}
			}

//			for (int i=0; i<DataGrid1.Items.Count; i++)
//			{
//				if (DataGrid1.Items[i].Cells[0].Text.Trim() == this.tbxEndDate.Text.Trim())
//				{
//					ed = i;
//					break;
//				}
//			}

			for (int i=0; i<dv.Count; i++)
			{
				if (dv[i]["cnt_date"].ToString().Trim() == DateTime.ParseExact(this.tbxEndDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd"))
				{
					ed = i;
					break;
				}
			}

			//日期都合理了，再來判斷是否有空間
			int mykey = this.ddlKey.SelectedIndex + 2; //跳一下
			bool free = false;
			int imp = Convert.ToInt32(this.tbxImpression.Text.Trim());
			string AdCate = this.ddlAdCate.SelectedItem.Value;

			DateTime MaxDbDate;
			if (DataGrid1.Items.Count>0)
			{
				//MaxDbDate = DateTime.ParseExact(DataGrid1.Items[DataGrid1.Items.Count-1].Cells[0].Text.Trim(), "yyyyMMdd", null);
				MaxDbDate = DateTime.ParseExact(dv[dv.Count-1]["cnt_date"].ToString().Trim(), "yyyyMMdd", null);
			}
			else
			{
				MaxDbDate = DateTime.Today.AddDays(-1);
			}
			DateTime AdBeginDate = DateTime.ParseExact(tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime AdEndDate = DateTime.ParseExact(tbxEndDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime ISDate;
			DateTime IEDate;

			//0:整個時段都在裡面
			//1:整個時段都在外面
			//2:前半段在內，後半段在外
			int fgCond = 0;
			
			if (AdBeginDate > MaxDbDate)
			{
				//整個都在外
				fgCond = 1;
			}
			else if (AdEndDate <= MaxDbDate)
			{
				//整個都在內
				fgCond = 0;
			}
			else if (AdBeginDate<=MaxDbDate &&  AdEndDate>MaxDbDate)
			{
				//前半段在內，後半段在外
				fgCond = 2;
			}
			
			string strVDate = "";
			if (fgCond == 0)
			{
				//狀況0，做Count的檢查
				for (int i=bd; i <= ed; i++)
				{
					int orivalue = Convert.ToInt32(dv[i][mykey].ToString().Trim());

					if ((orivalue <= 20)&& (20-orivalue) < imp)
					{
						free = false;
						strVDate = dv[i]["cnt_date"].ToString();
						break;
					}
					else
						free = true;
				}

				if (!free)
				{
					AlertMsg("選取範圍中，" + DateTime.ParseExact(strVDate, "yyyyMMdd",null).ToString("yyyy/MM/dd") + "起有日期滿檔，請重新選擇");
					return;
				}
			}
			else
			{
				//狀況1、2都是要從MaxDbDate的下一天新增到落版日期最後一天

				//在此狀況2，也就是前半在內，後半在外的情況下要先檢查在內的部分是否足夠
				if (fgCond == 2)
				{
					for (int i=bd; i<dv.Count; i++)
					{
						//int orivalue = Convert.ToInt32(DataGrid1.Items[i].Cells[mykey].Text.Trim());
						int orivalue = Convert.ToInt32(dv[i][mykey].ToString().Trim());

						if ((orivalue <= 20)&& (20-orivalue) < imp)
						{
							free = false;
							strVDate = dv[i]["cnt_date"].ToString();
							break;
						}
						else
							free = true;
					}

					if (!free)
					{
						AlertMsg("選取範圍中，" + DateTime.ParseExact(strVDate, "yyyyMMdd",null).ToString("yyyy/MM/dd") + "起有日期滿檔，請重新選擇");
						return;
					}
				}

				ISDate = MaxDbDate.AddDays(1);
				IEDate = AdEndDate;
				
				//設定sqlcommand命令
				System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
				cmd.Connection = this.sqlCnnMRLPUB;
				cmd.CommandType = CommandType.Text;
				
				//執行新增
				cmd.Connection.Open();
				System.Data.SqlClient.SqlTransaction myTrans = cmd.Connection.BeginTransaction();
				cmd.Transaction = myTrans;

				try
				{
					DateTime tmpDate = ISDate;

					while (tmpDate <= IEDate)
					{
						cmd.CommandText = "INSERT INTO c4_adcnt VALUES ('" + tmpDate.ToString("yyyyMMdd", null) + "','" + AdCate + "', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0')";
						cmd.ExecuteNonQuery();
						tmpDate = tmpDate.AddDays(1);
					}

					myTrans.Commit();
					//AlertMsg("新增落版前處理成功，請按確定繼續");
					
				}
				catch(System.Data.SqlClient.SqlException ex)
				{
					myTrans.Rollback();
					AlertMsg("廣告落版記數處理失敗，請通知聯絡人");
					return;
				}

				cmd.Connection.Close();

			}
			//以上針對c4_adcnt中資料日期是否足夠做完確認
		
			//正式儲存落版：原位置
			SaveAdr();

			//更新資料
			Bind_dgdAdr();

			//這裡還要在BindGrid一次
			BindGrid();
		}

		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
//				LiteralControl litAlertt = new LiteralControl();
				litAlert.Text = "<script language=\"javascript\">alert(\"" + strMsg +"\");</script>";
//				litAlertt.Text+="<script language=\"javascript\">window.open(\"" + strMsg + "\", '', 'width=600, height=450, left=80, top=20, scrollbars=yes');</script>";
//
//				Page.Controls.Add(litAlertt);
			}
		}

		private void imbStartDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.hidDateTarget.Value = "BEGIN";
			this.calSelectAdDate.Visible = true;
		}

		private void imbEndDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.hidDateTarget.Value = "END";
			this.calSelectAdDate.Visible = true;
		}

		private void calSelectAdDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.litAlert.Text = "";

			if (this.hidDateTarget.Value == "BEGIN")
				this.tbxBeginDate.Text = this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd");
			else
				this.tbxEndDate.Text = this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd");

			this.calSelectAdDate.Visible = false;

			if (this.tbxBeginDate.Text != "" && this.tbxEndDate.Text != "")
			{
				DateTime ISDate = DateTime.ParseExact(tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null);
				DateTime IEDate = DateTime.ParseExact(tbxEndDate.Text.Trim(), "yyyy/MM/dd", null);

				int AdDays = ((TimeSpan)IEDate.Subtract(ISDate)).Days+1;
				this.lblTotDays.Text = "共" + AdDays.ToString() + "天";
			}
			else
			{
				this.lblTotDays.Text = "";
			}
		}

		//連結現有廣告資料
		private void Bind_dgdAdr()
		{
			if (Request.QueryString["NewContNo"]==null || Request.QueryString["NewContNo"] == "")
			{
				Response.Write("沒有合約編號");
				return;
			}

			string NewContNo = Request.QueryString["NewContNo"];
			DataSet ds = new DataSet();
			this.sqlDaAdr.Fill(ds, "ADR");
			DataView dv = ds.Tables["ADR"].DefaultView;
			dv.RowFilter = "adr_contno='" + NewContNo + "'";
			
			if (dv.Count >0)
			{
				dgdAdr.DataSource = dv;
				dgdAdr.DataBind();
				dgdAdr.Visible = true;
				this.lblAdr.Text = "現有的廣告落版資料";
				FormatFields();
			}
			else
			{
				dgdAdr.Visible = false;
				this.lblAdr.Text = "目前沒有廣告落版";
			}
		}

		//從資料庫中找出目前最大的廣告序號by contno
		private string GetMaxAdrSeq(string contno)
		{
			string strReturn = "0";

			this.sqlCmdGetMaxAdrSeq.Parameters["@adr_contno"].Value = contno;
			this.sqlCmdGetMaxAdrSeq.Connection.Open();
			object tmp = "";

			try
			{
				tmp = this.sqlCmdGetMaxAdrSeq.ExecuteScalar();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write(ex.Message);
			}
			this.sqlCmdGetMaxAdrSeq.Connection.Close();

			if (tmp!=null)
				strReturn = tmp.ToString();

			return strReturn;
		}
		
		//儲存廣告
		private void SaveAdr()
		{
			int AdAmt = Convert.ToInt32(this.tbxAdAmt.Text.Trim());
			int ChgAmt = Convert.ToInt32(this.tbxChgAmt.Text.Trim());
			int DesAmt = Convert.ToInt32(this.tbxDesAmt.Text.Trim());
			int InvAmt = AdAmt+ChgAmt+DesAmt;

			string ImSeq = "";
			//計畫代號、成本中心
			string ProjNo = "";
			string CostCtr = "";

			if (Request.QueryString["ContTp"].Trim() == "01")
			{
				//一般合約
				ImSeq =	this.ddlInvMfr.SelectedItem.Value;

				
				string NewContNo = Request.QueryString["NewContNo"];
				this.sqlDaIm.SelectCommand.Parameters["@im_contno"].Value = NewContNo;
				DataSet imds = new DataSet();
				this.sqlDaIm.Fill(imds, "IM");
				DataView imdv = imds.Tables["IM"].DefaultView;
				imdv.RowFilter = "im_imseq='" + ImSeq + "'";
				if (!(imdv.Count>0))
				{
					AlertMsg("發票廠商對應錯誤，請通知聯絡人");
					return;
				}


				//--2002/11/26以前的版本
				//找出計畫代號，成本中心
//				DataSet projds = new DataSet();
//				this.sqlDaProj.Fill(projds, "PROJ");
//				DataView projdv = projds.Tables["PROJ"].DefaultView;
//
//				if (imdv[0]["im_fgitri"].ToString().Trim() == "06" || imdv[0]["im_fgitri"].ToString().Trim() == "06")
//				{
//					//所內、院內的
//					projdv.RowFilter = "proj_syscd='C4' AND proj_fgitri='06'";
//				}
//				else
//				{
//					//一般
//					projdv.RowFilter = "proj_syscd='C4' AND proj_fgitri='  '";
//				}
//
//				if (!(projdv.Count>0))
//				{
//					AlertMsg("找不到對應的計畫代號，請檢查計畫代號維護或者通知聯絡人");
//					return;
//				}
//
//				ProjNo = projdv[0]["proj_projno"].ToString().Trim();
//				CostCtr = projdv[0]["proj_costctr"].ToString().Trim();
				//--2002/11/26以前的版本

			}
			else
			{
				//推廣合約
				ImSeq = "";
			}

			//抓資料欄位
			string strContNo = this.tbxContNo.Text.Trim();
			string strSDate = DateTime.ParseExact(this.tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			string strEDate = DateTime.ParseExact(this.tbxEndDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			string strAdCate = this.ddlAdCate.SelectedItem.Value;
			string strImpr = this.tbxImpression.Text.Trim();
			string strKey = this.ddlKey.SelectedItem.Value;
			string strAltText = this.tbxAltText.Text.Trim();
			string strImgUrl = "";
			string strDraftTp = this.rblDraftTp.SelectedItem.Value;
			string strNavUrl = this.tbxNavUrl.Text.Trim();
			string strUrlTp = this.rblUrlTp.SelectedItem.Value;
			string strRemark = this.tbxRemark.Text.Trim();
			string strFgFixAd = this.ddlFgFixAd.SelectedItem.Value;

			this.sqlCmdInsAdr.Parameters["@cont_contno"].Value = strContNo;
			this.sqlCmdInsAdr.Parameters["@adr_imseq"].Value = ImSeq;
			this.sqlCmdInsAdr.Parameters["@adr_sdate"].Value = strSDate;
			this.sqlCmdInsAdr.Parameters["@adr_edate"].Value = strEDate;
			this.sqlCmdInsAdr.Parameters["@adr_invamt"].Value = InvAmt;
			this.sqlCmdInsAdr.Parameters["@adr_adcate"].Value = strAdCate;
			this.sqlCmdInsAdr.Parameters["@adr_keyword"].Value = strKey;
			this.sqlCmdInsAdr.Parameters["@adr_alttext"].Value = strAltText;
			this.sqlCmdInsAdr.Parameters["@adr_imgurl"].Value = strImgUrl;//還沒美編落版
			this.sqlCmdInsAdr.Parameters["@adr_drafttp"].Value = strDraftTp;
			this.sqlCmdInsAdr.Parameters["@adr_navurl"].Value = strNavUrl;
			this.sqlCmdInsAdr.Parameters["@adr_urltp"].Value = strUrlTp;
			this.sqlCmdInsAdr.Parameters["@adr_impr"].Value = strImpr;
			this.sqlCmdInsAdr.Parameters["@adr_fgfixad"].Value = strFgFixAd;
			this.sqlCmdInsAdr.Parameters["@adr_adamt"].Value = AdAmt;
			this.sqlCmdInsAdr.Parameters["@adr_desamt"].Value = DesAmt;
			this.sqlCmdInsAdr.Parameters["@adr_chgamt"].Value = ChgAmt;
			this.sqlCmdInsAdr.Parameters["@adr_remark"].Value = strRemark;

			//目前不需要這幾個
			//this.sqlCmdInsAdr.Parameters["@adr_fggot"].Value = "0";//還沒美編落版
			//int NewSeq = Convert.ToInt32(GetMaxAdrSeq(this.tbxContNo.Text.Trim())) + 1;
			//this.sqlCmdInsAdr.Parameters["@adr_seq"].Value = NewSeq.ToString("d2", null);
//			this.sqlCmdInsAdr.Parameters["@adr_fginvself"].Value = "0";//人工開立...
			//this.sqlCmdInsAdr.Parameters["@adr_projno"].Value = ProjNo;
			//this.sqlCmdInsAdr.Parameters["@adr_costctr"].Value = CostCtr;
			//this.sqlCmdInsAdr.Parameters["@adr_fgact"].Value = "0";


//改版
//			DateTime ISDate = DateTime.ParseExact(tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null);
//			DateTime IEDate = DateTime.ParseExact(tbxEndDate.Text.Trim(), "yyyy/MM/dd", null);
//			DateTime tmpDate = ISDate;
//
//			int AdDays = ((TimeSpan)IEDate.Subtract(ISDate)).Days+1;
//			int UnitAdAmt = AdAmt/AdDays;
//			int Remainder = AdAmt%AdDays;
//			int FirstUnitAdAmt = UnitAdAmt+Remainder;
//
//
//			//複製備用，以備於復原
//			string OriginalCommandText = this.sqlCmdInsAdr.CommandText;
//改版

			this.sqlCmdInsAdr.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdInsAdr.Connection.BeginTransaction();
			this.sqlCmdInsAdr.Transaction = myTrans;

			try
			{
				//儲存合約
				this.sqlCmdInsAdr.ExecuteNonQuery();

				//更新c4_adcnt

				//UPDATE dbo.c4_adcnt
				//SET       cnt_h0 = cnt_h0 + 1
				//WHERE (cnt_date = '20020701') AND (cnt_adcate = 'M')
//改版
//				while (tmpDate <= IEDate)
//				{
//					this.sqlCmdInsAdr.CommandText = "UPDATE c4_adcnt SET cnt_" + strKey + " = cnt_" + strKey + " + " + strImpr + " WHERE (cnt_date = '" + tmpDate.ToString("yyyyMMdd", null) + "') AND (cnt_adcate = '" + strAdCate + "')";
//
//					this.sqlCmdInsAdr.ExecuteNonQuery();
//
//					tmpDate = tmpDate.AddDays(1);
//				}
//
//				//廣告落版明細for開發票用
//				tmpDate = ISDate;
//				while (tmpDate <= IEDate)
//				{
//					if (tmpDate == ISDate)
//					{
//						//第一筆，廣告金額為平均單日金額加上餘數，
//						//		換稿費用為該廣告的換稿費用
//						//		設計費用為該廣告的設計費用
//						this.sqlCmdInsAdr.CommandText = "INSERT INTO c4_adrd VALUES ('C4','" + this.tbxContNo.Text.Trim() + "', '" + NewSeq.ToString("d2", null) + "', '" + tmpDate.ToString("yyyyMMdd", null) + "', '0',"+(float)FirstUnitAdAmt+","+(float)ChgAmt+","+(float)DesAmt+")";
//					}
//					else
//					{
//						this.sqlCmdInsAdr.CommandText = "INSERT INTO c4_adrd VALUES ('C4','" + this.tbxContNo.Text.Trim() + "', '" + NewSeq.ToString("d2", null) + "', '" + tmpDate.ToString("yyyyMMdd", null) + "', '0',"+(float)UnitAdAmt+",0,0)";
//					}
//					this.sqlCmdInsAdr.ExecuteNonQuery();
//
//					tmpDate = tmpDate.AddDays(1);
//				}
//改版
				myTrans.Commit();

				AlertMsg("廣告落版儲存成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				Response.Write(ex.Message);
				AlertMsg("廣告落版儲存失敗，請通知維護人！");
			}
			this.sqlCmdInsAdr.Connection.Close();

			//復原:p
			//this.sqlCmdInsAdr.CommandText = OriginalCommandText;
		}

		//刪除落版資料
		private void dgdAdr_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = this.tbxContNo.Text.Trim();
			string AdrSeq = e.Item.Cells[2].Text.Trim();

			//先做檢查
			this.sqlCmdCheckAdrd.Parameters["@contno"].Value = ContNo;
			this.sqlCmdCheckAdrd.Parameters["@adrseq"].Value = AdrSeq;
			this.sqlCmdCheckAdrd.Connection.Open();
			int InvedCount = -1;
			try
			{
				InvedCount = Convert.ToInt32(this.sqlCmdCheckAdrd.ExecuteScalar());
			}
			catch
			{
				AlertMsg("廣告檢查發生錯誤");
			}
			this.sqlCmdCheckAdrd.Connection.Close();
			
			if (InvedCount>0 || InvedCount==-1)
			{
				AlertMsg("該廣告已產生過發票資料，無法刪除");
				return;
			}
		
			//以下是可以刪除的廣告資料
//改版
//			DateTime AdBeginDate = DateTime.ParseExact(e.Item.Cells[3].Text.Trim(), "yyyyMMdd", null);
//			DateTime AdEndDate = DateTime.ParseExact(e.Item.Cells[4].Text.Trim(), "yyyyMMdd", null);
//			DateTime tmpDate = AdBeginDate;
//			string strAdCate = e.Item.Cells[5].Text.Trim();
//			switch(strAdCate)
//			{
//				case "首頁":
//					strAdCate = "M";
//					break;
//				case "內頁":
//					strAdCate = "I";
//					break;
//				case "奈米":
//					strAdCate = "N";
//					break;
//			}
//			string strKey = e.Item.Cells[6].Text.Trim();
//			string strImpr = e.Item.Cells[7].Text.Trim();
//改版			

			this.sqlCmdDelAdr.Parameters["@adr_contno"].Value = ContNo;
			this.sqlCmdDelAdr.Parameters["@adr_seq"].Value = AdrSeq;

//			DateTime SDate = DateTime.ParseExact(tbxAdSDate.Text.Trim(), "yyyy/MM/dd", null);
//			DateTime EDate = DateTime.ParseExact(tbxAdEDate.Text.Trim(), "yyyy/MM/dd", null);
//			double interval = ((TimeSpan)EDate.Subtract(SDate)).TotalDays;
			
			//用來備份的
//			string OriginalCommandText = this.sqlCmdDelAdr.CommandText;

			this.sqlCmdDelAdr.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdDelAdr.Connection.BeginTransaction();
			this.sqlCmdDelAdr.Transaction = myTrans;

			try
			{
				//c4_adr
				this.sqlCmdDelAdr.ExecuteNonQuery();
//改版
//				//c4_adcnt
//				while (tmpDate <= AdEndDate)
//				{
//					this.sqlCmdDelAdr.CommandText = "UPDATE c4_adcnt SET cnt_" + strKey + " = cnt_" + strKey + " - " + strImpr + " WHERE (cnt_date = '" + tmpDate.ToString("yyyyMMdd", null) + "') AND (cnt_adcate = '" + strAdCate + "')";
//					this.sqlCmdDelAdr.ExecuteNonQuery();
//
//					tmpDate = tmpDate.AddDays(1);
//				}
//				
//				//刪除c4_adrd的展開
//				this.sqlCmdDelAdr.CommandText = "DELETE FROM c4_adrd WHERE adrd_syscd='C4' AND adrd_contno='" + ContNo + "' AND adrd_adrseq='" + AdrSeq + "'";
//				this.sqlCmdDelAdr.ExecuteNonQuery();

				myTrans.Commit();
				AlertMsg("落版刪除成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				Response.Write(ex.Message);
				AlertMsg("落版刪除失敗");
			}
			this.sqlCmdDelAdr.Connection.Close();

//			this.sqlCmdDelAdr.CommandText = OriginalCommandText;	

			Bind_dgdAdr();

			//這裡還要在BindGrid一次
			BindGrid();
		}

		//發票廠商資料
		private void Bind_ddlInvMfr()
		{
			if (Request.QueryString["ContTp"].Trim() == "09")
			{
				this.ddlInvMfr.Visible = false;
				return;
			}

			string NewContNo = Request.QueryString["NewContNo"];
			this.sqlDaIm.SelectCommand.Parameters["@im_contno"].Value = NewContNo;
			DataSet ds = new DataSet();
			this.sqlDaIm.Fill(ds, "IM");
			DataView dv = ds.Tables["IM"].DefaultView;

			this.ddlInvMfr.DataTextField = "im_nm";
			this.ddlInvMfr.DataValueField = "im_imseq";
			this.ddlInvMfr.DataSource = dv;
			this.ddlInvMfr.DataBind();
			this.ddlInvMfr.Visible = true;
		}

		protected object GetFgFixAdNm(object fgfixad)
		{
			string strReturn = "";
			if (fgfixad.ToString() == "0")
			{
				strReturn = "輪播";
			}
			else if (fgfixad.ToString() == "1")
			{
				strReturn = "定播";
			}
			else
			{
				strReturn = "未設定";
			}
			return strReturn;
		}

		//懶得用Template了，直接改
		private void FormatFields()
		{
			//廣告頁面的轉換
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				switch(dgdAdr.Items[i].Cells[6].Text.Trim())
				{
					case "M":
						dgdAdr.Items[i].Cells[6].Text = "首頁";
						break;
					case "I":
						dgdAdr.Items[i].Cells[6].Text = "內頁";
						break;
					case "N":
						dgdAdr.Items[i].Cells[6].Text = "奈米";
						break;
					default:
						dgdAdr.Items[i].Cells[6].Text = "未定義";
						break;
				}
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}


		//把三個金額加總
		private void tbxChgAmt_TextChanged(object sender, System.EventArgs e)
		{
			int AdAmt = Convert.ToInt32(tbxAdAmt.Text.Trim());
			int DesAmt = Convert.ToInt32(tbxDesAmt.Text.Trim());
			int ChgAmt = Convert.ToInt32(tbxChgAmt.Text.Trim());
			int TotAmt = AdAmt + DesAmt + ChgAmt;
			this.tbxInvAmt.Text = TotAmt.ToString();
		}

		//把三個金額加總
		private void tbxAdAmt_TextChanged(object sender, System.EventArgs e)
		{
			int AdAmt = Convert.ToInt32(tbxAdAmt.Text.Trim());
			int DesAmt = Convert.ToInt32(tbxDesAmt.Text.Trim());
			int ChgAmt = Convert.ToInt32(tbxChgAmt.Text.Trim());
			int TotAmt = AdAmt + DesAmt + ChgAmt;
			this.tbxInvAmt.Text = TotAmt.ToString();
		}

		//把三個金額加總
		private void tbxDesAmt_TextChanged(object sender, System.EventArgs e)
		{
			int AdAmt = Convert.ToInt32(tbxAdAmt.Text.Trim());
			int DesAmt = Convert.ToInt32(tbxDesAmt.Text.Trim());
			int ChgAmt = Convert.ToInt32(tbxChgAmt.Text.Trim());
			int TotAmt = AdAmt + DesAmt + ChgAmt;
			this.tbxInvAmt.Text = TotAmt.ToString();
		}

		private void calCntView_SelectionChanged(object sender, System.EventArgs e)
		{
			this.litAlert.Text = "";

			BindGrid();
		}

		/// <summary>
		/// 修改=先刪除後新增
		/// </summary>
		private bool ModifyAdr()
		{
			string ContNo = this.tbxContNo.Text.Trim();
			string AdrSeq = dgdAdr.SelectedItem.Cells[2].Text.Trim();


			//先做檢查
			this.sqlCmdCheckAdrd.Parameters["@contno"].Value = ContNo;
			this.sqlCmdCheckAdrd.Parameters["@adrseq"].Value = AdrSeq;
			this.sqlCmdCheckAdrd.Connection.Open();
			int InvedCount = -1;
			try
			{
				InvedCount = Convert.ToInt32(this.sqlCmdCheckAdrd.ExecuteScalar());
			}
			catch
			{
				AlertMsg("廣告檢查發生錯誤");
			}
			this.sqlCmdCheckAdrd.Connection.Close();
			
			if (InvedCount>0 || InvedCount==-1)
			{
				AlertMsg("該廣告已產生過發票資料，無法修改");
				return false;
			}

			//
			//可以修改的廣告
			//

			//設定刪除
			this.sqlCmdDelAdr.Parameters["@adr_contno"].Value = ContNo;
			this.sqlCmdDelAdr.Parameters["@adr_seq"].Value = AdrSeq;

			//設定新增
			string ImSeq = "";
			if (Request.QueryString["ContTp"].Trim() == "01")
			{
				//一般合約
				ImSeq =	this.ddlInvMfr.SelectedItem.Value;

				
				string NewContNo = Request.QueryString["NewContNo"];
				this.sqlDaIm.SelectCommand.Parameters["@im_contno"].Value = NewContNo;
				DataSet imds = new DataSet();
				this.sqlDaIm.Fill(imds, "IM");
				DataView imdv = imds.Tables["IM"].DefaultView;
				imdv.RowFilter = "im_imseq='" + ImSeq + "'";
				if (!(imdv.Count>0))
				{
					AlertMsg("發票廠商對應錯誤，請通知聯絡人");
					return false;
				}
			}
			else
			{
				//推廣合約
				ImSeq = "";
			}


			//抓資料欄位
			string strContNo = this.tbxContNo.Text.Trim();
			string strSDate = DateTime.ParseExact(this.tbxBeginDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			string strEDate = DateTime.ParseExact(this.tbxEndDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			string strAdCate = this.ddlAdCate.SelectedItem.Value;
			string strImpr = this.tbxImpression.Text.Trim();
			string strKey = this.ddlKey.SelectedItem.Value;
			string strAltText = this.tbxAltText.Text.Trim();
			string strImgUrl = "";
			string strDraftTp = this.rblDraftTp.SelectedItem.Value;
			string strNavUrl = this.tbxNavUrl.Text.Trim();
			string strUrlTp = this.rblUrlTp.SelectedItem.Value;
			string strRemark = this.tbxRemark.Text.Trim();
			string strFgFixAd = this.ddlFgFixAd.SelectedItem.Value;
			int AdAmt = Convert.ToInt32(this.tbxAdAmt.Text.Trim());
			int ChgAmt = Convert.ToInt32(this.tbxChgAmt.Text.Trim());
			int DesAmt = Convert.ToInt32(this.tbxDesAmt.Text.Trim());
			int InvAmt = AdAmt+ChgAmt+DesAmt;

			this.sqlCmdInsAdr.Parameters["@cont_contno"].Value = strContNo;
			this.sqlCmdInsAdr.Parameters["@adr_imseq"].Value = ImSeq;
			this.sqlCmdInsAdr.Parameters["@adr_sdate"].Value = strSDate;
			this.sqlCmdInsAdr.Parameters["@adr_edate"].Value = strEDate;
			this.sqlCmdInsAdr.Parameters["@adr_invamt"].Value = InvAmt;
			this.sqlCmdInsAdr.Parameters["@adr_adcate"].Value = strAdCate;
			this.sqlCmdInsAdr.Parameters["@adr_keyword"].Value = strKey;
			this.sqlCmdInsAdr.Parameters["@adr_alttext"].Value = strAltText;
			this.sqlCmdInsAdr.Parameters["@adr_imgurl"].Value = strImgUrl;//還沒美編落版
			this.sqlCmdInsAdr.Parameters["@adr_drafttp"].Value = strDraftTp;
			this.sqlCmdInsAdr.Parameters["@adr_navurl"].Value = strNavUrl;
			this.sqlCmdInsAdr.Parameters["@adr_urltp"].Value = strUrlTp;
			this.sqlCmdInsAdr.Parameters["@adr_impr"].Value = strImpr;
			this.sqlCmdInsAdr.Parameters["@adr_fgfixad"].Value = strFgFixAd;
			this.sqlCmdInsAdr.Parameters["@adr_adamt"].Value = AdAmt;
			this.sqlCmdInsAdr.Parameters["@adr_desamt"].Value = DesAmt;
			this.sqlCmdInsAdr.Parameters["@adr_chgamt"].Value = ChgAmt;
			this.sqlCmdInsAdr.Parameters["@adr_remark"].Value = strRemark;

			bool fgSuccess = false;

			this.sqlCmdDelAdr.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdDelAdr.Connection.BeginTransaction();
			this.sqlCmdDelAdr.Transaction = myTrans;
			this.sqlCmdInsAdr.Transaction = myTrans;
			try
			{
				this.sqlCmdDelAdr.ExecuteNonQuery();
				this.sqlCmdInsAdr.ExecuteNonQuery();
				fgSuccess = true;
				myTrans.Commit();
				AlertMsg("廣告修改成功");
			}
			catch
			{
				fgSuccess = false;
				myTrans.Rollback();
				AlertMsg("廣告修改失敗，請通知聯絡人");
			}
			this.sqlCmdDelAdr.Connection.Close();

			return fgSuccess;
		}

		private void btnDoModify_Click(object sender, System.EventArgs e)
		{
			bool fgSuccess = ModifyAdr();

			if (fgSuccess)
			{
				this.btnDoModify.Visible = false;
				this.btnSave.Visible = true;

				Bind_dgdAdr();
				BindGrid();
				dgdAdr.SelectedIndex = -1;
			}
			else
			{
				this.btnDoModify.Visible = true;
				this.btnSave.Visible = false;
			}
		}

		private void dgdAdr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.btnDoModify.Visible = true;
			this.btnSave.Visible = false;

			//準備修改的form
			string ContNo = this.tbxContNo.Text.Trim();
			string AdrSeq = dgdAdr.SelectedItem.Cells[2].Text.Trim();

			string strSDate = DateTime.ParseExact(dgdAdr.SelectedItem.Cells[4].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
			string strEDate = DateTime.ParseExact(dgdAdr.SelectedItem.Cells[5].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

			string strAdCate = dgdAdr.SelectedItem.Cells[6].Text.Trim();
			switch(strAdCate)
			{
				case "首頁":
					ddlAdCate.SelectedIndex = 0;
					break;
				case "內頁":
					ddlAdCate.SelectedIndex = 1;
					break;
				case "奈米":
					ddlAdCate.SelectedIndex = 2;
					break;
			}

			string strImpr = dgdAdr.SelectedItem.Cells[8].Text.Trim();

			string strKey = dgdAdr.SelectedItem.Cells[7].Text.Trim();
			switch(strKey)
			{
				case "h0":
					ddlKey.SelectedIndex = 0;
					break;
				case "h1":
					ddlKey.SelectedIndex = 1;
					break;
				case "h2":
					ddlKey.SelectedIndex = 2;
					break;
				case "h3":
					ddlKey.SelectedIndex = 3;
					break;
				case "h4":
					ddlKey.SelectedIndex = 4;
					break;
				case "w1":
					ddlKey.SelectedIndex = 5;
					break;
				case "w2":
					ddlKey.SelectedIndex = 6;
					break;
				case "w3":
					ddlKey.SelectedIndex = 7;
					break;
				case "w4":
					ddlKey.SelectedIndex = 8;
					break;
				case "w5":
					ddlKey.SelectedIndex = 9;
					break;
				case "w6":
					ddlKey.SelectedIndex = 10;
					break;
			}

			string strAltText = dgdAdr.SelectedItem.Cells[3].Text.Trim();

			string strDraftTp = dgdAdr.SelectedItem.Cells[15].Text.Trim();
			switch(strDraftTp)
			{
				case "1":
					rblDraftTp.SelectedIndex = 0;
					break;
				case "2":
					rblDraftTp.SelectedIndex = 1;
					break;
				case "3":
					rblDraftTp.SelectedIndex = 2;
					break;
			}

			string strNavUrl = dgdAdr.SelectedItem.Cells[9].Text.Trim();

			string strUrlTp = dgdAdr.SelectedItem.Cells[16].Text.Trim();
			switch(strUrlTp)
			{
				case "1":
					rblUrlTp.SelectedIndex = 0;
					break;
				case "2":
					rblUrlTp.SelectedIndex = 1;
					break;
				case "3":
					rblUrlTp.SelectedIndex = 2;
					break;
			}			

			string strRemark = dgdAdr.SelectedItem.Cells[17].Text.Trim();

			string strFgFixAd = dgdAdr.SelectedItem.Cells[10].Text.Trim();
			switch(strFgFixAd)
			{
				case "輪播":
					ddlFgFixAd.SelectedIndex = 0;
					break;
				case "定播":
					ddlFgFixAd.SelectedIndex = 1;
					break;
			}

			string strAdAmt = dgdAdr.SelectedItem.Cells[11].Text.Trim();
			string strDesAmt = dgdAdr.SelectedItem.Cells[12].Text.Trim();
			string strChgAmt = dgdAdr.SelectedItem.Cells[13].Text.Trim();
			string strInvAmt = dgdAdr.SelectedItem.Cells[14].Text.Trim();

			this.tbxBeginDate.Text = strSDate;
			this.tbxEndDate.Text = strEDate;

			switch(strFgFixAd)
			{
				case "輪播":
					this.tbxImpression.Text = strImpr;
					break;
				case "定播":
					this.tbxImpression.Text = "20";
					break;
			}			

			this.tbxAltText.Text = strAltText;
			this.tbxNavUrl.Text = strNavUrl;
			this.tbxRemark.Text = strRemark;
			this.tbxAdAmt.Text = strAdAmt;
			this.tbxDesAmt.Text = strDesAmt;
			this.tbxChgAmt.Text = strChgAmt;
			this.tbxInvAmt.Text = strInvAmt;
		}

		private void ddlFgFixAd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddlFgFixAd.SelectedItem.Value.Trim() == "1")
			{
				this.tbxImpression.Text = "20";
				this.tbxImpression.ReadOnly = true;
				this.tbxImpression.BackColor = Color.LightGray;
			}
			else
			{
				this.tbxImpression.Text = "1";
				this.tbxImpression.ReadOnly = false;
				this.tbxImpression.BackColor = Color.White;
			}
		}

	}
}
