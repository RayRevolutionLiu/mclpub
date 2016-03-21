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
	/// Summary description for ORMtpCounts_stat_search1.
	/// </summary>
	public class ORMtpCounts_stat_search1 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Panel pnlCounts;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.Label lblConttp;
		protected System.Web.UI.WebControls.DropDownList ddlConttp;
		protected System.Web.UI.WebControls.Label lblBookCode;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.Label lblPubDate;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblfgMOSea;
		protected System.Web.UI.WebControls.DropDownList ddlfgMOSea;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Label lblMailType;
		protected System.Web.UI.WebControls.DropDownList ddlMailType;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Web.UI.WebControls.Label lblMessage;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!Page.IsPostBack)
			{
				Response.Expires = 0;

				// 給預設值
				InitialData();
			}
		}


		// 給預設值
		private void InitialData()
		{
			this.lblMessage.Text = "";
			this.pnlCounts.Visible = false;
			this.Literal1.Text = "";

			this.cbx0.Checked = true;
			this.ddlConttp.SelectedIndex = 0;
			this.ddlfgMOSea.SelectedIndex = 0;
			this.ddlMailType.SelectedIndex = 0;


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

			this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");


			// 抓取登入業務員資訊 - 工號及姓名
			GetLoginEmpInfo();
		}


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
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "srspn");
				DataView dv3 = ds3.Tables["srspn"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr3 = "1=1";
				rowfilterstr3 = rowfilterstr3 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv3.RowFilter = rowfilterstr3;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv3.Count > 0)
				{
					LoginEmpCName = dv3[0]["srspn_cname"].ToString().Trim();
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
			this.Literal1.Text = "";
			BindGrid1();
		}


		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ORMtpCounts_stat_search1.aspx");
		}


		// 顯示 DataGrid1
		private void BindGrid1()
		{
			// 抓出篩選條件
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string strMailType = this.ddlMailType.SelectedItem.Value.ToString().Trim();
			string LoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strConttp= " + strConttp + "<br>");
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("fgMOSea= " + fgMOSea + "<br>");
			//Response.Write("strMailType= " + strMailType + "<br>");
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_or");
			DataView dv2 = ds2.Tables["c2_or"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";

			// 合約類別 篩選條件
			if(this.cbx0.Checked)
			{
				rowfilterstr2 = rowfilterstr2 + " AND cont_conttp='" + strConttp + "'";
			}
			else
			{
				rowfilterstr2 = rowfilterstr2;
			}
			// 書籍類別 篩選條件
			rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";

			// 有登本數 篩選條件
			rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm='" + strYYYYMM + "'";

			// 郵寄地區
			if(this.cbx1.Checked)
			{
				rowfilterstr2 = rowfilterstr2 + " AND or_fgmosea='" + fgMOSea + "'";
			}
			else
			{
				rowfilterstr2 = rowfilterstr2;
			}

			// 郵寄類別
			if(strMailType == "0")
			{
				rowfilterstr2 = rowfilterstr2 + " AND or_mtpcd = '11'";
			}
			else
			{
				rowfilterstr2 = rowfilterstr2 + " AND or_mtpcd <> '11'";
			}
			dv2.RowFilter = rowfilterstr2;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv2.Count > 0)
			{
				this.pnlCounts.Visible = true;
				this.DataGrid1.Visible = true;

				DataGrid1.DataSource = dv2;
				DataGrid1.DataBind();


				int intSumPubCounts = 0, intTotalPubCounts = 0;
				for(int i=0; i < DataGrid1.Items.Count; i++)
				{
					// 郵寄類別
					int intMtpcd = Convert.ToInt32(this.DataGrid1.Items[i].Cells[6].Text.ToString().Trim());
					//Response.Write("intMtpcd= " + intMtpcd + "<br>");
					if(intMtpcd >= 20)
					{
						this.DataGrid1.Items[i].Cells[2].ForeColor = Color.Blue;
					}


					// 所有之有登本數的總份數
					intSumPubCounts = Convert.ToInt32(this.DataGrid1.Items[i].Cells[7].Text.ToString());
					intTotalPubCounts = intTotalPubCounts + intSumPubCounts;
				}

				this.lblMessage.Text = "查詢結果: 找到 " + dv2.Count + " 筆資料, 總本數：" + intTotalPubCounts;
				//this.lblMessage.Text = "查詢結果: 找到 " + dv2.Count + " 筆資料, 總有登本數：" + intTotalPubCount + "<br>請繼續按 <A HREF='" + RedirectURL + "' Target='_self'>此連結</A> 來繼續進行下一動作!<br>";
			}
			else
			{
				this.pnlCounts.Visible = false;
				this.DataGrid1.Visible = false;
				this.lblMessage.Text = "零本；或找不到符合條件的資料, 您可以 重設條件!";
			}
		}


		// 列印清單 按鈕的處理
		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";


			// 抓出篩選條件
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string strMailType = this.ddlMailType.SelectedItem.Value.ToString().Trim();
			string LoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strConttp= " + strConttp + "<br>");
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("fgMOSea= " + fgMOSea + "<br>");
			//Response.Write("strMailType= " + strMailType + "<br>");
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");


			// 轉址
			// 書籍類別 & 刊登年月 篩選條件
			string RedirectURL = "ORMtpCounts_stat2a.aspx";
			// 合約類別 篩選條件
			if(this.cbx0.Checked)
			{
				RedirectURL = RedirectURL + "?conttp=" + strConttp;
			}
			else
			{
				RedirectURL = RedirectURL + "?conttp=";
			}
			RedirectURL = RedirectURL + "&bkcd=" + strBkcd;
			RedirectURL = RedirectURL + "&yyyymm=" + strYYYYMM;
			if(this.cbx1.Checked)
			{
				RedirectURL = RedirectURL + "&fgmosea=" + fgMOSea;
			}
			else
			{
				RedirectURL = RedirectURL + "&fgmosea=";
			}

			// 郵寄類別
			if(strMailType == "0")
			{
				RedirectURL = RedirectURL + "&mailtp=0";
			}
			else
			{
				RedirectURL = RedirectURL + "&mailtp=1";
			}
			RedirectURL = RedirectURL + "&LEmpno=" + LoginEmpNo;
			//Response.Write("RedirectURL= " + RedirectURL + "<br>");

			// 轉址
			//Response.Redirect(RedirectURL);
			Literal1.Text="<script language=\"javascript\">window.open(\""+RedirectURL+"\");</script>";
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
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
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttpName", "cont_conttpName"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("PubCounts", "PubCounts"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno"),
																																																				 new System.Data.Common.DataColumnMapping("SumCounts", "SumCounts")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT DISTINCT dbo.c2_cont.cont_conttp, CASE WHEN cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName, dbo.c2_cont.cont_bkcd, dbo.book.bk_nm, dbo.c2_or.or_mtpcd, dbo.mtp.mtp_nm, dbo.c2_or.or_pubcnt, COUNT(dbo.c2_or.or_pubcnt) AS PubCounts, dbo.c2_or.or_fgmosea, dbo.c2_pub.pub_yyyymm, dbo.bookp.bkp_pno, dbo.c2_or.or_pubcnt * COUNT(dbo.c2_or.or_pubcnt) AS SumCounts FROM dbo.c2_cont INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.c2_or ON dbo.c2_pub.pub_syscd = dbo.c2_or.or_syscd AND dbo.c2_pub.pub_contno = dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN dbo.bookp ON dbo.c2_pub.pub_yyyymm = dbo.bookp.bkp_date AND dbo.c2_pub.pub_bkcd = dbo.bookp.bkp_bkcd WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') GROUP BY dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.book.bk_nm, dbo.c2_or.or_mtpcd, dbo.mtp.mtp_nm, dbo.c2_or.or_pubcnt, dbo.c2_or.or_fgmosea, dbo.c2_pub.pub_yyyymm, dbo.bookp.bkp_pno ORDER BY dbo.c2_or.or_mtpcd";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
