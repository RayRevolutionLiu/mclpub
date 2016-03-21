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
	/// Summary description for iaFm1_chklist2.
	/// </summary>
	public class iaFm1_chklist2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label lblMessage2;
		protected System.Web.UI.WebControls.Button btnReQuery;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Web.UI.WebControls.Label lblBkcd;
		protected System.Web.UI.WebControls.DropDownList ddlBkcd;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxIAStatus;
		protected System.Web.UI.WebControls.Panel pnlQuery;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;


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


		private void InitialData()
		{
			this.lblMessage.Text  = "";
			this.lblMessage2.Text = "";
			this.btnPrintList.Visible = false;
			this.btnReQuery.Visible = false;

			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter2.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBkcd.DataSource=dv1;
			dv1.RowFilter="proj_fgitri=''";
			ddlBkcd.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			ddlBkcd.DataValueField="bk_bkcd";
			ddlBkcd.DataBind();
			this.ddlBkcd.SelectedIndex = 0;

			this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM");


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


		// 清除重查 按鈕的處理
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("iaFm1_chklist2.aspx");
		}


		// 查詢 按鈕的處理
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			BindGrid1();
		}


		// 顯示 DataGrid1
		private void BindGrid1()
		{
			// 抓出篩選條件
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "ia");
			DataView dv2 = ds2.Tables["ia"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";
			rowfilterstr2 = rowfilterstr2 + " AND iad_fk2='" + strYYYYMM + "'";
			dv2.RowFilter = rowfilterstr2;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv2.Count > 0)
			{
				this.btnPrintList.Visible = true;
				this.btnReQuery.Visible = false;

				DataGrid1.DataSource=dv2;
				DataGrid1.DataBind();
			}
			else
			{
				this.lblMessage2.Text = "當月尚未開立任何發票開立單!<br>或請重新搜尋！";
				this.btnReQuery.Visible = true;
				this.btnPrintList.Visible = false;
			}
		}



		// 重新查詢 按鈕的處理
		private void btnReQuery_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("iaFm1_chklist2.aspx");
		}


		// 列印檢核表 按鈕的處理
		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			// 抓出畫面上的值, 作為篩選資料的條件
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strLEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strLEmpNo= " + strLEmpNo + "<br>");

			// 開啟小視窗
			string strbuf = "iaFm1_list2b.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&LEmpNo=" + strLEmpNo;
			//Response.Write(strbuf);
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnReQuery.Click += new System.EventHandler(this.btnReQuery_Click);
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
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2')";
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
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasdate", "ia_iasdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasseq", "ia_iasseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_iaitem", "ia_iaitem"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyseq", "ia_pyseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																			new System.Data.Common.DataColumnMapping("ia_ivat", "ia_ivat"),
																																																			new System.Data.Common.DataColumnMapping("ia_invno", "ia_invno"),
																																																			new System.Data.Common.DataColumnMapping("ia_invdate", "ia_invdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																			new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																			new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																			new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgnonauto", "ia_fgnonauto"),
																																																			new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																			new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("ia_status", "ia_status"),
																																																			new System.Data.Common.DataColumnMapping("ia_cname", "ia_cname"),
																																																			new System.Data.Common.DataColumnMapping("ia_tel", "ia_tel"),
																																																			new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno"),
																																																			new System.Data.Common.DataColumnMapping("iad_iadid", "iad_iadid"),
																																																			new System.Data.Common.DataColumnMapping("iad_syscd", "iad_syscd"),
																																																			new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano"),
																																																			new System.Data.Common.DataColumnMapping("iad_iaditem", "iad_iaditem"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																			new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																			new System.Data.Common.DataColumnMapping("iad_costctr", "iad_costctr"),
																																																			new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																			new System.Data.Common.DataColumnMapping("iad_qty", "iad_qty"),
																																																			new System.Data.Common.DataColumnMapping("iad_unit", "iad_unit"),
																																																			new System.Data.Common.DataColumnMapping("iad_uprice", "iad_uprice"),
																																																			new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt"),
																																																			new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT TOP 100 PERCENT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_refno, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat, dbo.ia.ia_ivat, dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rzip) AS ia_rzip, RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, RTRIM(dbo.ia.ia_cname) AS ia_cname, RTRIM(dbo.ia.ia_tel) AS ia_tel, dbo.ia.ia_contno, dbo.iad.iad_iadid, dbo.iad.iad_syscd, dbo.iad.iad_iano, dbo.iad.iad_iaditem, dbo.iad.iad_fk1, dbo.iad.iad_fk2, dbo.iad.iad_fk3, dbo.iad.iad_fk4, dbo.iad.iad_projno, dbo.iad.iad_costctr, RTRIM(dbo.iad.iad_desc) AS iad_desc, dbo.iad.iad_qty, dbo.iad.iad_unit, dbo.iad.iad_uprice, dbo.iad.iad_amt, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.ia INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c2_cont ON dbo.iad.iad_fk1 = dbo.c2_cont.cont_contno INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_syscd = 'C2') AND (dbo.c2_cont.cont_fgpayonce = '1') ORDER BY dbo.ia.ia_iano DESC";
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
