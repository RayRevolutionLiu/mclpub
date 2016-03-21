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
	/// Summary description for cont_list.
	/// </summary>
	public class cont_list : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Label lblSEDate;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Label lblSEDateMemo;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.TextBox tbxSignDate1;
		protected System.Web.UI.WebControls.TextBox tbxSignDate2;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.DropDownList ddlfgclosed;
		protected System.Web.UI.WebControls.Label lblfgclosed;
		protected System.Web.UI.WebControls.CheckBox cbx4;
		protected System.Web.UI.WebControls.Label lblMfrMemo;
		protected System.Web.UI.WebControls.LinkButton InbSearchMfr;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblMemo;

		public cont_list()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// Put user code to initialize the page here
				Response.Expires = 0;

				if (!Page.IsPostBack)
				{
					Response.Expires = 0;

					// 給 預設值
					InitialData();
				}
			}
			catch(Exception ex){
				Response.Write(ex.Message);
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 給 預設值
		private void InitialData()
		{
			this.lblMessage.Text = "";
			this.tbxMfrNo.Text = "";


			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv1;
			dv1.RowFilter="proj_fgitri=''";
			ddlBookCode.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();

			// 顯示下拉式選單 業務員的 DB 值
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "srspn");
			this.ddlEmpNo.DataSource=ds2;
			this.ddlEmpNo.DataTextField="srspn_cname";
			this.ddlEmpNo.DataValueField="srspn_empno";
			this.ddlEmpNo.DataBind();

			this.cbx0.Checked = false;
			this.cbx1.Checked = false;
			this.cbx2.Checked = false;
			this.cbx3.Checked = false;

			this.tbxSignDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxSignDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxSDate.Text = System.DateTime.Today.ToString("yyyy") + "/01";
			this.tbxEDate.Text = System.DateTime.Today.ToString("yyyy") + "/12";

			this.ddlBookCode.SelectedIndex = 0;
			this.ddlfgclosed.SelectedIndex = 1;

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

			// 抓取登入業務員資訊 - 工號及姓名
			GetLoginEmpInfo();
		}


		// 抓取登入業務員資訊 - 工號及姓名
		private void GetLoginEmpInfo()
		{
			// 抓出登入者的工號, 作為預設 製表業務員 之值
			string LoginEmpNo = "";
			string LoginEmpCName = "";
			//Response.Write("LoginEmpNo= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
			// 若有登入者的資料, 則抓出並預選 建檔業務員之下拉式選單
			if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) != "")
			{
				LoginEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);


				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				DataView dv2 = ds2.Tables["srspn"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv2.RowFilter = rowfilterstr2;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv2.Count > 0)
				{
					LoginEmpCName = dv2[0]["srspn_cname"].ToString().Trim();
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
		}


		// 查詢 按鈕的處理
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 抓出 畫面上的值為傳遞變數
			string strEmpNo, strSignDate1 = "", strSignDate2 = "", strStartDate = "", strEndDate = "", strMfrIName = "";
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			strSignDate1 = this.tbxSignDate1.Text.ToString().Trim();
			strSignDate1 = strSignDate1.Substring(0, 4) + strSignDate1.Substring(5, 2) + strSignDate1.Substring(8, 2);
			strSignDate2 = this.tbxSignDate2.Text.ToString().Trim();
			strSignDate2 = strSignDate2.Substring(0, 4) + strSignDate2.Substring(5, 2) + strSignDate2.Substring(8, 2);
			strStartDate = this.tbxSDate.Text.ToString().Trim();
			strStartDate = strStartDate.Substring(0, 4) + strStartDate.Substring(5, 2);
			strEndDate = this.tbxEDate.Text.ToString().Trim();
			strEndDate = strEndDate.Substring(0, 4) + strEndDate.Substring(5, 2);
			string strfgClosed = this.ddlfgclosed.SelectedItem.Value.ToString().Trim();
			strMfrIName = this.tbxMfrIName.Text.ToString().Trim();
			string LoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strEmpNo= " + strEmpNo + "<br>");
			//Response.Write("strSignDate1= " + strSignDate1 + "<br>");
			//Response.Write("strSignDate2= " + strSignDate2 + "<br>");
			//Response.Write("strStartDate= " + strStartDate + "<br>");
			//Response.Write("strEndDate= " + strEndDate + "<br>");
			//Response.Write("strfgClosed= " + strfgClosed + "<br>");
			//Response.Write("strMfrIName= " + strMfrIName + "<br>");
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
			//Response.Write("cont_list2.aspx?empno=" + EmpNo + " " + EmpCName + "<br>");

			// 轉址: 執行 ExcelSpeedGen
			//Response.Redirect("cont_list2.aspx?empno=" + EmpNo);

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_cont");
			DataView dv3 = ds3.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND (cont_bkcd='" + strBkcd + "')";

			// 若勾選查詢條件一時 - 承辦業務員
			if(this.cbx0.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND (cont_empno='" + strEmpNo + "')";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}

			// 若勾選查詢條件二時 - 合約簽約日期區間
			if(this.cbx1.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND (cont_signdate >= '" + strSignDate1 + "') ";
				rowfilterstr3 = rowfilterstr3 + " AND (cont_signdate <= '" + strSignDate2 + "') ";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}

			// 若勾選查詢條件三時 - 合約起迄區間
			if(this.cbx2.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND (cont_sdate >= '" + strStartDate + "') ";
				rowfilterstr3 = rowfilterstr3 + " AND (cont_edate <= '" + strEndDate + "') ";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}

			// 若勾選查詢條件四時 - 結案註記
			if(this.cbx3.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND (cont_fgclosed='" + strfgClosed + "')";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}

			// 若勾選查詢條件襖時 - 廠商名稱
			if(this.cbx4.Checked)
			{
				// 藉廠商名稱, 抓出其完整名稱及其廠商統編
				GetMfrNo();
				rowfilterstr3 = rowfilterstr3 + " AND (mfr_inm like '%" + strMfrIName + "%')";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}
			dv3.RowFilter = rowfilterstr3;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

			// 若有資料時
			if(dv3.Count > 0)
			{
				string strMfrNo = this.tbxMfrNo.Text.ToString().Trim();
				//Response.Write("strMfrNo= " + strMfrNo + "<br>");

				// 執行 sp, 以產生其對應的 雜誌收件人姓名集
				ExecSp();


				// 轉址
				string RedirectURL = "cont_list2.aspx?bkcd=" + strBkcd;
				if(this.cbx0.Checked)
				{
					RedirectURL = RedirectURL + "&empno=" + strEmpNo;
				}
				else
				{
					RedirectURL = RedirectURL + "&empno=";
				}

				if(this.cbx1.Checked)
				{
					RedirectURL = RedirectURL + "&signdate1=" + strSignDate1;
					RedirectURL = RedirectURL + "&signdate2=" + strSignDate2;
				}
				else
				{
					RedirectURL = RedirectURL + "&signdate1=";
					RedirectURL = RedirectURL + "&signdate2=";
				}

				if(this.cbx2.Checked)
				{
					RedirectURL = RedirectURL + "&sdate=" + strStartDate;
					RedirectURL = RedirectURL + "&edate=" + strEndDate;
				}
				else
				{
					RedirectURL = RedirectURL + "&sdate=";
					RedirectURL = RedirectURL + "&edate=";
				}

				if(this.cbx3.Checked)
				{
					RedirectURL = RedirectURL + "&fgclosed=" + strfgClosed;
				}
				else
				{
					RedirectURL = RedirectURL + "&fgclosed=";
				}

				if(this.cbx4.Checked)
				{
					RedirectURL = RedirectURL + "&mfrno=" + strMfrNo;
				}
				else
				{
					RedirectURL = RedirectURL + "&mfrno=";
				}
				RedirectURL = RedirectURL + "&LEmpno=" + LoginEmpNo;

				this.lblMessage.Text="結果: 找到 <B>" + dv3.Count + "</B>筆資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_blank'>此連結</A> 來繼續進行下一動作!<br>";
			}
			else
			{
				this.lblMessage.Text = "查無資料, 請重新輸入查詢條件!";
			}
		}


		// 執行 sp, 以產生其對應的 雜誌收件人姓名集
		private void ExecSp()
		{
			// 抓出 畫面上的值為傳遞變數
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			//Response.Write("strBkcd= " + strBkcd + "<br>");


			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@bkcd"].Value = strBkcd;

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
				//Response.Write("產生雜誌收件人姓名資料集成功!<br>");

				// 以 Javascript 的 window.alert()  來告知訊息
				//LiteralControl litAlert1 = new LiteralControl();
				//litAlert1.Text = "<script language=javascript>alert(\"產生雜誌收件人姓名資料集成功, 請繼續!\");</script>";
				//Page.Controls.Add(litAlert1);
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				Response.Write(ex1.Message + "<br>");
				myTrans1.Rollback();
				//Response.Write("產生雜誌收件人姓名資料集失敗!<br>");

				// 以 Javascript 的 window.alert()  來告知訊息
				//LiteralControl litAlert1 = new LiteralControl();
				//litAlert1.Text = "<script language=javascript>alert(\"產生雜誌收件人姓名資料集失敗!\");</script>";
				//Page.Controls.Add(litAlert1);
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}
		}


		// 藉廠商名稱, 抓出其完整名稱及其廠商統編
		private void GetMfrNo()
		{
			this.tbxMfrNo.Text = "";


			// 抓出畫面上的值
			string strMfrIName = this.tbxMfrIName.Text.ToString().Trim();
			//Response.Write("strMfrIName= " + strMfrIName + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "mfr");
			DataView dv4 = ds4.Tables["mfr"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string rowfilterstr4 = "1=1";
			rowfilterstr4 = rowfilterstr4 + " AND mfr_inm like '" + strMfrIName + "%'";
			dv4.RowFilter = rowfilterstr4;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			string strMfrNo = "";
			// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
			if(dv4.Count > 0)
			{
				strMfrNo = dv4[0]["mfr_mfrno"].ToString().Trim();

			}
			else
			{
				strMfrNo = strMfrNo;
			}
			this.tbxMfrNo.Text = strMfrNo;
			//Response.Write("strMfrNo= " + strMfrNo + "<br>");
		}


		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("cont_list.aspx");
		}


		// 查詢廠商資訊
		private void InbSearchMfr_Click(object sender, System.EventArgs e)
		{
			// 開啟小視窗
			string strbuf = "../d5/mfr.aspx";
			//Response.Write(strbuf);
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.InbSearchMfr.Click += new System.EventHandler(this.InbSearchMfr_Click);
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno")})});
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel")})});
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "dbo.[sp_c2_contlist2_1]";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2));
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'f\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = @"SELECT DISTINCT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.c2_cont.cont_aufax, dbo.c2_cont.cont_aucell, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_disc, dbo.c2_cont.cont_freetm, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_madejtm, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_pubtm, dbo.c2_cont.cont_resttm, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_pubamt, dbo.c2_cont.cont_chgamt, dbo.c2_cont.cont_fgpayonce, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, dbo.c2_cont.cont_fgcancel, RTRIM(dbo.c2_cont.cont_oldcontno) AS cont_oldcontno, dbo.c2_cont.cont_custno, RTRIM(dbo.cust.cust_nm) AS cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_tel FROM dbo.c2_cont INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno WHERE (dbo.c2_cont.cont_fgtemp = '0')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = "SELECT RTRIM(mfr_mfrno) AS mfr_mfrno, RTRIM(mfr_inm) AS mfr_inm FROM dbo.mfr";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
