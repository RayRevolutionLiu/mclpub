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
	/// Summary description for PubFm_label_search.
	/// </summary>
	public class PubFm_label_search : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.Label lblPubDate;
		protected System.Web.UI.WebControls.Label lblEmpNo;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.Label lblConttp;
		protected System.Web.UI.WebControls.DropDownList ddlConttp;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnPrintLabel;
		protected System.Web.UI.WebControls.Button btnClearAll;
		protected System.Web.UI.WebControls.Button btnBackHome;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label lblfgMOSea;
		protected System.Web.UI.WebControls.DropDownList ddlfgMOSea;
		protected System.Web.UI.WebControls.Label lblBookCode;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblv;
		protected System.Web.UI.WebControls.DropDownList ddlMtpcd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.WebControls.TextBox tbxBookPNo;
		protected System.Web.UI.WebControls.Label lblQuery2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Web.UI.WebControls.Label lblQuery;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!Page.IsPostBack)
			{
				Response.Expires = 0;

				InitialData();
			}
		}


		// 給預設值
		private void InitialData()
		{
			this.lblMessage.Text = "";
			this.btnPrintLabel.Visible = false;
			this.btnPrintList.Visible = false;


			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			ddlBookCode.ClearSelection();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv1;
			dv1.RowFilter="proj_fgitri=''";
			ddlBookCode.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();

			this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");


			// 顯示下拉式選單 業務員 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds2 = new DataSet();
			ddlEmpNo.ClearSelection();
			this.sqlDataAdapter2.Fill(ds2, "srspn");
			DataView dv2=ds2.Tables["srspn"].DefaultView;
			ddlEmpNo.DataSource=dv2;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();

			// 顯示下拉式選單 郵寄類別 DB 值
			DataSet ds4 = new DataSet();
			ddlfgMOSea.ClearSelection();
			ddlMtpcd.ClearSelection();
			this.sqlDataAdapter4.Fill(ds4, "mtp");
			DataView dv4=ds4.Tables["mtp"].DefaultView;
			ddlMtpcd.DataSource=dv4;
			ddlMtpcd.DataTextField="mtp_nm";
			ddlMtpcd.DataValueField="mtp_mtpcd";
			ddlMtpcd.DataBind();
			this.cbx0.Checked = false;
			this.cbx1.Checked = false;
				
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

			// 抓出 登入者工號
			GetLoginEmpNo();
		}


		// 抓出 登入者工號
		private void GetLoginEmpNo()
		{
			// 抓出 登入者工號
			string LoginEmpNo = "", LoginEmpCName = "";
			if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) != "")
			{
				LoginEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);


				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				DataView dv2 = ds2.Tables["srspn"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv2.RowFilter = rowfilterstr2;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

				// 若搜尋結果為 "找不到" 的處理
				if (dv2.Count > 0)
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
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.btnPrintLabel.Visible = true;
			this.btnPrintList.Visible = true;

			// 顯示 DataGrid1
			BindGrid1();
		}


		// 顯示 DataGrid1 -- 有登本數
		private void BindGrid1()
		{
			// 抓出篩選條件
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();
			string strPubCntType = "1";


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_cont");
			DataView dv3 = ds3.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			// 書籍類別 篩選條件
			rowfilterstr3 = rowfilterstr3 + " AND cont_bkcd='" + strBkcd + "'";
			// 合約類別 篩選條件
			rowfilterstr3 = rowfilterstr3 + " AND cont_conttp='" + strConttp + "'";
			// 承辦業務員 篩選條件
			if(this.cbx0.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND cont_empno='" + strEmpNo + "'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}
			rowfilterstr3 = rowfilterstr3 + " AND or_fgmosea='" + fgMOSea + "'";
			// 郵寄類別
			if(this.cbx1.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND or_mtpcd='" + strMtpcd + "'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}
			// 有登本數
			rowfilterstr3 = rowfilterstr3 + " AND cont_sdate <= '" + strYYYYMM + "'";
			rowfilterstr3 = rowfilterstr3 + " AND cont_edate >='" + strYYYYMM + "'";
			rowfilterstr3 = rowfilterstr3 + " AND or_pubcnt > 0";
			rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm='" + strYYYYMM + "'";
			dv3.RowFilter = rowfilterstr3;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv3.Count > 0)
			{
				this.DataGrid1.Visible = true;
				DataGrid1.DataSource = dv3;
				DataGrid1.DataBind();

				this.lblMessage.Text = "查詢結果: 找到 " + dv3.Count + " 筆雜誌收件人資料!";

				// 抓出書籍期別, 好代入標籤及清單中
				GetBkpNo();


				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid1.Items.Count; i++)
				{
					// 合約起日
					string StartDate = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
					//Response.Write("StartDate= " + StartDate + "<br>");
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					DataGrid1.Items[i].Cells[1].Text = StartDate;

					// 合約迄日
					string EndDate = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
					//Response.Write("EndDate= " + EndDate + "<br>");
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					DataGrid1.Items[i].Cells[2].Text = EndDate;
				}
			}
			else
			{
				this.btnPrintLabel.Visible = false;
				this.btnPrintList.Visible = false;

				this.DataGrid1.Visible = false;
				this.lblMessage.Text = "找不到符合條件的資料, 您可以 重設條件!";
			}
		}


		// 抓出書籍期別, 好代入標籤及清單中
		private void GetBkpNo()
		{
			// 抓出篩選條件
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strBkPNo = "";


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "bookp");
			DataView dv5 = ds5.Tables["bookp"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND bkp_bkcd='" + strBkcd + "'";
			rowfilterstr5 = rowfilterstr5 + " AND bkp_date='" + strYYYYMM + "'";
			dv5.RowFilter = rowfilterstr5;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv5.Count > 0)
			{
				strBkPNo = dv5[0]["bkp_pno"].ToString().Trim();
			}
			else
			{
				strBkPNo = strBkPNo;
			}
			this.tbxBookPNo.Text = strBkPNo;
			//Response.Write("strBkPNo= " + strBkPNo + "<br>");
		}


		// 清除重查  按鈕的處理
		private void btnClearAll_Click(object sender, System.EventArgs e)
		{
			//InitialData();
			//this.DataGrid1.Visible = false;
			Response.Redirect("PubFm_label_search.aspx");
		}


		// 列印標籤  按鈕的處理
		private void btnPrintLabel_Click(object sender, System.EventArgs e)
		{
			// 抓出篩選條件
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strEmpNo = "";
			if(this.cbx0.Checked)
			{
				strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			}
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string strPubCountType = "1";
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string strMtpcd = "";
			if(this.cbx1.Checked)
			{
				strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();
			}
			string strBkPNo = this.tbxBookPNo.Text.ToString().Trim();


			// 轉址
			string	strbuf;
			strbuf = "PubFm_label.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&empno=" + strEmpNo + "&conttp=" + strConttp + "&pubcnttp=" + strPubCountType + "&fgmosea=" + fgMOSea + "&mtpcd=" + strMtpcd + "&bkpno=" + strBkPNo;
			//Response.Write("strbuf= " + strbuf + "<br>");
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		// 返回首頁  按鈕的處理
		private void btnBackHome_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("../default.aspx");
		}


		// 郵寄地區 改變時的處理
		private void ddlfgMOSea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			//Response.Write("fgMOSea= " + fgMOSea + "<br>");

//			if(fgMOSea == "1")
//			{
//				this.cbx1.Checked = true;
//				this.ddlMtpcd.Items.FindByValue("21").Selected = true;
//			}
		}


		// 列印清單 按鈕的處理
		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			// 抓出篩選條件
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strEmpNo = "";
			if(this.cbx0.Checked)
			{
				strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			}
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string strPubCountType = "1";
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string strMtpcd = "";
			if(this.cbx1.Checked)
			{
				strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();
			}
			string LEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			string strBkPNo = this.tbxBookPNo.Text.ToString().Trim();


			// 轉址
			string	strbuf;
			strbuf = "PubFm_list2.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&empno=" + strEmpNo + "&conttp=" + strConttp + "&pubcnttp=" + strPubCountType + "&fgmosea=" + fgMOSea + "&mtpcd=" + strMtpcd + "&LEmpNo=" + LEmpNo + "&bkpno=" + strBkPNo;
			//Response.Write("strbuf= " + strbuf + "<br>");
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}



		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
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
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'f\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT DISTINCT TOP 100 PERCENT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, " +
				"dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, " +
				"dbo.c2_cont.cont_signdate, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, RTRIM(db" +
				"o.c2_cont.cont_mfrno) AS cont_mfrno, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_ed" +
				"ate, dbo.c2_or.or_oritem, RTRIM(dbo.c2_or.or_inm) AS or_inm, RTRIM(dbo.c2_or.or_" +
				"nm) AS or_nm, dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm, dbo.c2_or.or_" +
				"pubcnt, dbo.c2_or.or_unpubcnt, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo." +
				"c2_or.or_contno, dbo.c2_or.or_syscd, RTRIM(dbo.c2_or.or_zip) AS or_zip, RTRIM(db" +
				"o.c2_or.or_addr) AS or_addr, RTRIM(dbo.c2_or.or_jbti) AS or_jbti, RTRIM(dbo.book" +
				"p.bkp_pno) AS bkp_pno, dbo.c2_pub.pub_yyyymm, dbo.c2_or.or_fgmosea, dbo.c2_cont." +
				"cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp FROM dbo.c2_co" +
				"nt INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN db" +
				"o.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND dbo.c2_cont.cont_cont" +
				"no = dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_" +
				"mtpcd INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND" +
				" dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.srspn ON dbo.c2_" +
				"cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.bookp ON dbo.c2_pub.pub_y" +
				"yyymm = dbo.bookp.bkp_date AND dbo.c2_pub.pub_bkcd = dbo.bookp.bkp_bkcd WHERE (d" +
				"bo.c2_cont.cont_fgclosed = \'0\') AND (dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c" +
				"2_cont.cont_fgtemp = \'0\') ORDER BY dbo.c2_cont.cont_contno";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = "SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM dbo.mtp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter5
			//
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "bookp", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("bkp_bkcd", "bkp_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_date", "bkp_date"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno")})});
			//
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = "SELECT bkp_bkcd, bkp_date, bkp_pno FROM dbo.bookp";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.ddlfgMOSea.SelectedIndexChanged += new System.EventHandler(this.ddlfgMOSea_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
			this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
