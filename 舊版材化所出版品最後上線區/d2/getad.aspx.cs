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

namespace MRLPub_d2
{
	/// <summary>
	/// Summary description for getad.
	/// </summary>
	public class getad : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.HtmlControls.HtmlForm adpub_list;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxyyyymm;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Web.UI.WebControls.Literal Literal1;

		public getad()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			if (!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// 清除畫面資料
				this.cbx0.Checked = true;
				this.lblMessage.Text = "";
				this.Literal1.Text = "";


				// 給 催稿年月 tbxYYYYMM 預設值 (今天年月)
				this.tbxyyyymm.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();


				// 顯示下拉式選單 業務員的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "srspn");
				ddlEmpNo.DataSource=ds1;
				ddlEmpNo.DataTextField="srspn_cname";
				ddlEmpNo.DataValueField="srspn_empno";
				ddlEmpNo.DataBind();
				

				// 抓出登入者的工號, 作為預設 製表業務員 之值
				string LoginEmpNo = "";
				string LoginEmpCName = "";
				//Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
				// 若有登入者的資料, 則抓出並預選 建檔業務員之下拉式選單
				if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) != "")
				{
					LoginEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);


					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "srspn");
					DataView dv4 = ds4.Tables["srspn"].DefaultView;

					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr4 = "1=1";
					rowfilterstr4 = rowfilterstr4 + " AND srspn_empno='" + LoginEmpNo + "'";
					dv4.RowFilter = rowfilterstr4;

					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

					// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
					if(dv4.Count > 0)
					{
						LoginEmpCName = dv4[0]["srspn_cname"].ToString().Trim();
					}
					else
					{
						LoginEmpCName = "(不詳)";
					}
				}
				this.tbxLoginEmpNo.Text = LoginEmpNo;
				this.tbxLoginEmpCName.Text = LoginEmpCName;
				//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
				//Response.Write("LoginEmpCName= " + LoginEmpCName + "<br>");


				// 顯示下拉式選單 書籍類別的 DB 值
				// 關於 nostr, 請參 sqlDataAdapter3.Select statement;
				// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "book");
				DataView dv2=ds2.Tables["book"].DefaultView;
				ddlBookCode.DataSource=dv2;
				dv2.RowFilter="proj_fgitri=''";
				ddlBookCode.DataTextField="bk_nm";
				//ddlBookCode.DataValueField="nostr";
				// 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
				ddlBookCode.DataValueField="bk_bkcd";
				ddlBookCode.DataBind();

				//如果是D級管理者，僅能查看到自己的客戶資料
				if((Session["RegOK"] != null) && ((bool)Session["RegOK"] == true))
				{
					
					if(Session["atype"].ToString().Equals("D"))
					{
						if(this.ddlEmpNo.Items.FindByValue(Session["empid"].ToString()) != null)
						{
							this.ddlEmpNo.Items.FindByValue(Session["empid"].ToString()).Selected = true;
							this.ddlEmpNo.Enabled = false;
							this.cbx0.Checked = true;
							this.cbx0.Enabled = false;
						}
					}
				}
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 當按下 "查詢" 時
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";


			// 說明：
			// 若合約迄日(200302) >= 今時年月(200202), 表示未過期
			// 若合約迄日(200012) <= 今時年月(200202), 表示已過期
			// 已過期已結案 => 不顯示出
			// 已過期未結案 => 催稿, 給續約註記
			// 已過期已結案 => 催稿
			// 已過期未結案 => 催稿, 確認落版位置


			// 先判斷催稿年月是否有填, 否則不予繼續動作
			// 查詢條件二: 催稿年月為必填資料, 若沒填則不予繼續動作
			if(this.tbxyyyymm.Text.ToString().Trim() == "")
			{
				this.lblMessage.Text = "很抱歉, 催稿年月為必填資料, 否則無法繼續動作!";
			}
			else
			{
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c2_cont");
				DataView dv3 = ds3.Tables["c2_cont"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilter3 = "1=1";

				// 抓出所選取的查詢條件
				string BookCode = "";
				string yyyymm = "";
				string EmpNo = "";
				string LoginEmpNo = "";
				string strbuf="getad2.aspx?";

				// 查詢條件一
				BookCode = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
				rowfilter3 = rowfilter3 + " AND cont_bkcd ='" + BookCode + "'";
				strbuf = strbuf + "bkcd=" + BookCode + "&";
				//Response.Write("BookCode= " + BookCode + "<br>");

				// 查詢條件二
				yyyymm = this.tbxyyyymm.Text.ToString().Trim();
				yyyymm = yyyymm.Substring(0, 4) + yyyymm.Substring(5, 2);
				rowfilter3 = rowfilter3 + " AND cont_sdate <= '" + yyyymm + "' ";
				rowfilter3 = rowfilter3 + " AND cont_edate >= '" + yyyymm + "' ";
				//rowfilter3 = rowfilter3 + " AND pub_yyyymm ='" + yyyymm + "'";
				strbuf = strbuf + "yyyymm=" + yyyymm + "&";
				//Response.Write("yyyymm= " + yyyymm + "<br>");

				// 若勾選查詢條件一時
				if(cbx0.Checked)
				{
					EmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
					rowfilter3 = rowfilter3 + " AND cont_empno ='" + EmpNo + "'";
					strbuf = strbuf + "empno=" + EmpNo + "&";
					//Response.Write("EmpNo= " + EmpNo + "<br>");
				}
					// 若沒勾選 承辦業務員, 則表示不指定業務員 (則不做 rowfilter)
				else
				{
					strbuf = strbuf + "empno=" + "&";
					rowfilter3 = rowfilter3;
				}
				dv3.RowFilter = rowfilter3;

				// 抓出製表人姓名
				LoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
				strbuf = strbuf + "LEmpNo=" + LoginEmpNo;
				
				//Response.Write("dv3.Count= " + dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

				// 檢查並輸出 最後 Row Filter 的結果
				if(dv3.Count > 0)
				{
					//Response.Write("strbuf= " + strbuf + "<BR>");
					//Response.Write("getad2.aspx?BookCode=" + BookCode + "&yyyymm=" + yyyymm + "&EmpNo=" + EmpNo + "&LEmpNo=" + LoginEmpNo + "<br>");
					//this.lblMessage.Text = this.tbxyyyymm.Text.ToString().Trim() + " 全部業務員共有" + dv3.Count + " 筆資料!";

					// 先執行產生 wr -- 呼叫 2個 Stored Pro
					ExecGetadSP();


					// 轉址: 執行 ExcelSpeedGen (strbuf 將轉執行 getad2.aspx)
					//Response.Redirect(strbuf);
					Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
				}
				else
				{
					this.lblMessage.Text = "查無資料, 請重新輸入查詢條件!";
				}

				// 結束 if(this.tbxyyyymm.Text.ToString().Trim() == "")	之 else {}
			}
		}


		// 先執行產生 wr -- 呼叫 2個 Stored Procedures
		private void ExecGetadSP()
		{
			// 抓出畫面上的值, 來當成篩選條件
			string strfgclosed = "0";
			string strbkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string stryyyymm = this.tbxyyyymm.Text.ToString().Trim();
			stryyyymm = stryyyymm.Substring(0, 4) + stryyyymm.Substring(5, 2);
			//Response.Write("strfgclosed= " + strfgclosed + "<BR>");
			//Response.Write("strbkcd= " + strbkcd + "<BR>");
			//Response.Write("stryyyymm= " + stryyyymm + "<BR>");

			// 各給篩選條件
			// Stored Procedures #1 - 呼叫 sp_c2_getad_1
			this.sqlCommand1.Parameters["@fgclosed"].Value = strfgclosed;
			this.sqlCommand1.Parameters["@bkcd"].Value = strbkcd;

			// Stored Procedures #2 - 呼叫 sp_c2_rp1
			this.sqlCommand2.Parameters["@yyyymm"].Value = stryyyymm;
			this.sqlCommand2.Parameters["@bkcd"].Value = strbkcd;

			
			// 確認執行 sqlCommand1 成功
			this.sqlCommand1.Connection.Open();
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
			this.sqlCommand1.Transaction = myTrans1;
			//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
			try
			{
				this.sqlCommand1.ExecuteNonQuery();
				myTrans1.Commit();
				//Response.Write("執行 sp_c2_getad_1 成功!<br>");
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				//Response.Write(ex1.Message + "<br>");
				myTrans1.Rollback();
				//Response.Write("執行 sp_c2_getad_1 失敗!<br>");
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}

			
			// 確認執行 sqlCommand2 成功
			this.sqlCommand2.Connection.Open();
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand2.Connection.BeginTransaction();
			this.sqlCommand2.Transaction = myTrans2;
			//Response.Write(sqlCommand2.Parameters.Count.ToString().Trim());
			try
			{
				this.sqlCommand2.ExecuteNonQuery();
				myTrans2.Commit();
				//Response.Write("執行 sp_c2_getad_2 成功!<br>");
			}
			catch(System.Data.SqlClient.SqlException ex2)
			{
				Response.Write(ex2.Message + "<br>");
				myTrans2.Rollback();
				//Response.Write("執行 sp_c2_getad_2 失敗!<br>");
			}
			finally
			{
				this.sqlCommand2.Connection.Close();
			}
		}


		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("getad.aspx");
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.sqlConnection1.ConnectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgsize", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("mark", "mark"),
																																																				   new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				   new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				   new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				   new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				   new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				   new System.Data.Common.DataColumnMapping("cont_sedate", "cont_sedate"),
																																																				   new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				   new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				   new System.Data.Common.DataColumnMapping("pubmmstr", "pubmmstr"),
																																																				   new System.Data.Common.DataColumnMapping("CountNo", "CountNo"),
																																																				   new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				   new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				   new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				   new System.Data.Common.DataColumnMapping("cont_njtpcnt", "cont_njtpcnt"),
																																																				   new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				   new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				   new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				   new System.Data.Common.DataColumnMapping("cont_pubclrtm", "cont_pubclrtm"),
																																																				   new System.Data.Common.DataColumnMapping("cont_pubgetclrtm", "cont_pubgetclrtm"),
																																																				   new System.Data.Common.DataColumnMapping("cont_pubmenotm", "cont_pubmenotm"),
																																																				   new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				   new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				   new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				   new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				   new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				   new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT \'\' AS mark, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_aunm, dbo.mfr.mfr_in" +
				"m, dbo.c2_cont.cont_autel, dbo.c2_cont.cont_aufax, dbo.c2_cont.cont_aucell, SUBS" +
				"TRING(dbo.c2_cont.cont_sdate, 1, 4) + \'/\' + SUBSTRING(dbo.c2_cont.cont_sdate, 5," +
				" 6) + \' ~ \' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) + \'/\' + SUBSTRING(dbo.c2_c" +
				"ont.cont_edate, 5, 6) AS cont_sedate, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont" +
				"_resttm, dbo.c2_getad.pubmmstr, COUNT(dbo.c2_pub.pub_contno) AS CountNo, dbo.c2_" +
				"ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_cont.cont_pubamt, db" +
				"o.c2_cont.cont_njtpcnt, CASE WHEN pub_fggot = \'0\' THEN \'否\' ELSE \'是\' END AS pub_f" +
				"ggot, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_origjno, dbo.c2_cont.cont_clrtm - db" +
				"o.c2_cont.cont_restclrtm AS cont_pubclrtm, dbo.c2_cont.cont_getclrtm - dbo.c2_co" +
				"nt.cont_restgetclrtm AS cont_pubgetclrtm, dbo.c2_cont.cont_menotm - dbo.c2_cont." +
				"cont_restmenotm AS cont_pubmenotm, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, d" +
				"bo.c2_pub.pub_pgscd, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_empno, dbo.c2_cont." +
				"cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_" +
				"fgpubed, dbo.c2_pub.pub_drafttp FROM dbo.c2_pgsize RIGHT OUTER JOIN dbo.c2_pub O" +
				"N dbo.c2_pgsize.pgs_pgscd = dbo.c2_pub.pub_pgscd LEFT OUTER JOIN dbo.c2_clr ON d" +
				"bo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_ltp ON dbo.c2_" +
				"pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd RIGHT OUTER JOIN dbo.c2_cont INNER JOIN dbo" +
				".mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno LEFT OUTER JOIN dbo.c2_getad " +
				"ON dbo.c2_cont.cont_syscd = dbo.c2_getad.syscd AND dbo.c2_cont.cont_contno = dbo" +
				".c2_getad.contno ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub" +
				".pub_contno = dbo.c2_cont.cont_contno WHERE (dbo.c2_cont.cont_fgclosed = \'0\') GR" +
				"OUP BY dbo.c2_cont.cont_contno, dbo.c2_cont.cont_aunm, dbo.mfr.mfr_inm, dbo.c2_c" +
				"ont.cont_autel, dbo.c2_cont.cont_aufax, dbo.c2_cont.cont_aucell, dbo.c2_cont.con" +
				"t_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont_rest" +
				"tm, dbo.c2_getad.pubmmstr, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.p" +
				"gs_nm, dbo.c2_cont.cont_pubamt, dbo.c2_cont.cont_njtpcnt, dbo.c2_pub.pub_fggot, " +
				"dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_origjno, dbo.c2_cont.cont_clrtm, dbo.c2_co" +
				"nt.cont_restclrtm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_restgetclrtm, dbo" +
				".c2_cont.cont_menotm, dbo.c2_cont.cont_restmenotm, dbo.c2_pub.pub_ltpcd, dbo.c2_" +
				"pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_emp" +
				"no, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_fgclosed, d" +
				"bo.c2_cont.cont_fgpubed, dbo.c2_pub.pub_drafttp ORDER BY mark DESC, dbo.c2_cont." +
				"cont_fgpubed, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, " +
				"dbo.c2_cont.cont_contno";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
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
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_id, RTRIM(srspn_empno) AS srspn_empno, RTRIM(srspn_cname) AS srspn_c" +
				"name, RTRIM(srspn_tel) AS srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srs" +
				"pn_date FROM dbo.srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'f\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT RTRIM(srspn_empno) AS srspn_empno, RTRIM(srspn_cname) AS srspn_cname, RTRI" +
				"M(srspn_tel) AS srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date FR" +
				"OM dbo.srspn";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c2_getad_1";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "dbo.sp_c2_rp1";
			this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion



	}
}
