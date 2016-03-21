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
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for iaFm1_Add.
	/// </summary>
	public class iaFm1_Add : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblIMName;
		protected System.Web.UI.WebControls.TextBox tbxIMName;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;

		public iaFm1_Add()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				InitialData();
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 查詢 按鈕的處理
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			if(this.tbxMfrIName.Text.ToString().Trim() != "" || this.tbxIMName.Text.ToString().Trim() != "")
			{
				BindGrid1();
			}
			else if(this.tbxMfrIName.Text.ToString().Trim() == "" || this.tbxIMName.Text.ToString().Trim() == "")
			{
				this.lblMessage.Text = "您並未輸入條件, 無法查詢!";
				InitialData();
			}
		}


		// 清除資料 按鈕的處理
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			//InitialData();
			Response.Redirect("iaFm1_Add.aspx");
		}


		// 網頁預設值
		private void InitialData()
		{
			this.cbx1.Checked = true;
			this.cbx2.Checked = false;

			this.lblMfrNo.Text = "";
			this.tbxMfrIName.Text = "";
			this.tbxIMName.Text = "";

			this.DataGrid1.Visible = false;
			this.lblMessage.Text = "";
		}


		// 顯示資料 DataGrid1
		private void BindGrid1()
		{
			// 抓出廠商名稱
			string strMfrIName = this.tbxMfrIName.Text.ToString().Trim();
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			//Response.Write("strMfrIName=" + strMfrIName + "<br>");
			//Response.Write("strIMName=" + strIMName + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			if(this.cbx1.Checked)
				rowfilterstr1 = rowfilterstr1 + " AND mfr_inm Like '%" + strMfrIName + "%'";
			if(this.cbx2.Checked)
				rowfilterstr1 = rowfilterstr1 + " AND im_nm Like '%" + strIMName + "%'";
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			if(dv1.Count > 0)
			{
				this.DataGrid1.Visible = true;
				this.lblMessage.Text = "查有 " + dv1.Count + " 筆資料";

				string MfrIName = dv1[0]["mfr_inm"].ToString().Trim();
				string MfrNo = dv1[0]["cont_mfrno"].ToString().Trim();
				this.lblMfrNo.Text = "(廠商名稱：" + MfrIName + "；廠商統編：" + MfrNo + ")";


				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();


				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 合約類別
					string conttp = DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
					//Response.Write("conttp= " + conttp + "<br>");
					if(conttp == "01")
						DataGrid1.Items[i].Cells[6].Text = "一般";
					else if(conttp == "09")
						DataGrid1.Items[i].Cells[6].Text = "<font color='Red'>推廣</font>";

					// 簽約日期
					string SignDate = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
					SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
					//Response.Write("SignDate= " + SignDate + "<br>");
					DataGrid1.Items[i].Cells[7].Text = SignDate;

					// 合約起日
					string StartDate = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid1.Items[i].Cells[8].Text = StartDate;

					// 合約迄日
					string EndDate = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					//Response.Write("EndDate= " + EndDate + "<br>");
					DataGrid1.Items[i].Cells[9].Text = EndDate;

					// 結案註記
					string fgclosed = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
					//Response.Write("fgclosed= " + fgclosed + "<br>");
					if(fgclosed == "0")
						DataGrid1.Items[i].Cells[17].Text = "否";
					else
						DataGrid1.Items[i].Cells[17].Text = "<font color='Red'>是</font>";
				}
			}
			else
			{
				this.DataGrid1.Visible = false;

				this.lblMessage.Text = "查無資料!";
				this.lblMfrNo.Text = "無此廠商編號";
			}
		}


		// 確認挑選 按鈕的處理
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Select")
			{
				// 抓出 ItemTemplate 之 RadioButton 型態之 cbxUpdate (Controls[1])
				//bool strSelectIM = ((RadioButton)DataGrid1.Items[i].Cells[0].FindControl("rabSelectIMSeq")).Checked;
				string strContNo = e.Item.Cells[1].Text.ToString().Trim();
				string strIMSeq = e.Item.Cells[2].Text.ToString().Trim();
				string strfgclosed = e.Item.Cells[19].Text.ToString().Trim();
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strIMSeq= " + strIMSeq + "<br>");
				//Response.Write("strfgclosed= " + strfgclosed + "<br>");


				if(strfgclosed == "0")
				{
					// 先檢查該合約是否有未開發票的落版資料, 若無, 不予轉址
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds2 = new DataSet();
					this.sqlDataAdapter2.Fill(ds2, "c2_pub");
					DataView dv2 = ds2.Tables["c2_pub"].DefaultView;

					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr2 = "1=1";
					rowfilterstr2 = rowfilterstr2 + " AND pub_contno = '" + strContNo + "'";
					rowfilterstr2 = rowfilterstr2 + " AND pub_imseq = '" + strIMSeq + "'";
					dv2.RowFilter = rowfilterstr2;

					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
					//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

					if(dv2.Count > 0)
					{
						// 轉址
						string strbuf = "iaFm1_Addia.aspx?contno=" + strContNo + "&imseq=" + strIMSeq;
						Response.Redirect(strbuf);
					}
					else
					{
						// 以 Javascript 的 window.alert()  來告知訊息
						LiteralControl litAlertInv1 = new LiteralControl();
						litAlertInv1.Text = "<script language=javascript>alert(\"此合約的落版資料已全開完!\");</script>";
						Page.Controls.Add(litAlertInv1);
					}
				}
				else
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlertInv1 = new LiteralControl();
					litAlertInv1.Text = "<script language=javascript>alert(\"此合約已結案, 不允許再開立發票!\");</script>";
					Page.Controls.Add(litAlertInv1);
				}
			}
		}



		// DataGrid1 換頁處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid1();
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, " +
				"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2" +
				"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con" +
				"t_edate, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_custno, RTRIM(dbo.cust.cust" +
				"_nm) AS cust_nm, dbo.cust.cust_tel, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pa" +
				"idamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_oldcontno, dbo.c2_cont.cont_mo" +
				"ddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, dbo.c2_cont.cont_f" +
				"gcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgp" +
				"ubed, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.invmfr.im_imseq, RTRIM(dbo.invmfr.i" +
				"m_nm) AS im_nm, dbo.cust.cust_custno, dbo.invmfr.im_contno, dbo.invmfr.im_syscd," +
				" dbo.mfr.mfr_mfrno, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname)" +
				" AS srspn_cname, dbo.book.bk_bkcd, dbo.srspn.srspn_empno, dbo.c2_cont.cont_totjt" +
				"m, dbo.c2_cont.cont_tottm FROM dbo.c2_cont INNER JOIN dbo.invmfr ON dbo.c2_cont." +
				"cont_syscd = dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_con" +
				"tno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER " +
				"JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book O" +
				"N dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.srspn ON dbo.c2_cont.c" +
				"ont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgpayonce = \'1\') AND (" +
				"dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') AND (dbo.c2" +
				"_cont.cont_fgpubed = \'1\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																			   new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																			   new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																			   new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																			   new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																			   new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																			   new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																			   new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																			   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																			   new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																			   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																			   new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																			   new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																			   new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			   new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			   new System.Data.Common.DataColumnMapping("bk_nm1", "bk_nm1"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname1", "srspn_cname1"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("ltp_nm1", "ltp_nm1"),
																																																			   new System.Data.Common.DataColumnMapping("clr_nm1", "clr_nm1"),
																																																			   new System.Data.Common.DataColumnMapping("pgs_nm1", "pgs_nm1"),
																																																			   new System.Data.Common.DataColumnMapping("njtp_nm1", "njtp_nm1"),
																																																			   new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																			   new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																			   new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																			   new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																			   new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fgact", "pub_fgact")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT TOP 100 PERCENT dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.p" +
				"ub_pubseq, dbo.c2_pub.pub_pgno AS pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub" +
				"_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_fgfixpg, dbo.c2_pub.pub_remark, dbo" +
				".c2_pub.pub_drafttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub" +
				"_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pub_origjbkno, dbo.c2_pub.pub_chgb" +
				"kcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2_pub.pub_fgrechg, dbo" +
				".c2_pub.pub_bkcd, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm, RTRIM(dbo.c2_clr.clr_nm) A" +
				"S clr_nm, RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS n" +
				"jtp_nm, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cn" +
				"ame, dbo.c2_pub.pub_modempno, dbo.c2_pub.pub_imseq, dbo.c2_pub.pub_fginved, dbo." +
				"c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_c" +
				"ostctr, dbo.c2_pub.pub_syscd, dbo.mfr.mfr_inm, dbo.cust.cust_nm, dbo.book.bk_nm " +
				"AS bk_nm, dbo.srspn.srspn_cname AS srspn_cname, dbo.srspn.srspn_tel, dbo.c2_ltp." +
				"ltp_nm AS ltp_nm, dbo.c2_clr.clr_nm AS clr_nm, dbo.c2_pgsize.pgs_nm AS pgs_nm, d" +
				"bo.c2_njtp.njtp_nm AS njtp_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_lt" +
				"p.ltp_ltpcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_cus" +
				"tno, dbo.mfr.mfr_mfrno, dbo.srspn.srspn_empno, dbo.c2_pub.pub_fginvself, dbo.c2_" +
				"pub.pub_pno, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact FROM dbo.srspn RIGHT" +
				" OUTER JOIN dbo.c2_ltp RIGHT OUTER JOIN dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo" +
				".c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_c" +
				"ont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno " +
				"INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno LEFT OUTER" +
				" JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN " +
				"dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd ON dbo.c2_ltp.lt" +
				"p_ltpcd = dbo.c2_pub.pub_ltpcd LEFT OUTER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njt" +
				"pcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkc" +
				"d = dbo.book.bk_bkcd ON dbo.srspn.srspn_empno = dbo.c2_cont.cont_empno WHERE (db" +
				"o.c2_pub.pub_fginved = \' \') AND (dbo.c2_cont.cont_fgpubed = \'1\') AND (dbo.c2_con" +
				"t.cont_fgpayonce = \'1\') AND (dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.c" +
				"ont_fgtemp = \'0\') AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0) ORDER B" +
				"Y dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
