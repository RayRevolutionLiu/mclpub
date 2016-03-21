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
	/// Summary description for adprom_label.
	/// </summary>
	public class adprom_label : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DropDownList ddlConttp;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label lblv;
		protected System.Web.UI.WebControls.DropDownList ddlMtpcd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.HtmlControls.HtmlForm lbl_adprom;
	
		public adprom_label()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

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
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 給預設值
		private void InitialData()
		{
			// 預設顯示 推廣合約
			this.ddlConttp.SelectedIndex = 1;
			this.Literal1.Text = "";
			
			
			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement; 
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "book");
			DataView dv3=ds3.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv3;
			dv3.RowFilter="proj_fgitri=''";
			ddlBookCode.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();
			
			
			// 顯示下拉式選單 郵寄類別 DB 值
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "mtp");
			DataView dv4=ds4.Tables["mtp"].DefaultView;
			ddlMtpcd.DataSource=dv4;
			ddlMtpcd.DataTextField="mtp_nm";
			ddlMtpcd.DataValueField="mtp_mtpcd";
			ddlMtpcd.DataBind();
			
			this.cbx0.Checked = false;
			
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
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "srspn");
				DataView dv1 = ds1.Tables["srspn"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr1 = "1=1";
				rowfilterstr1 = rowfilterstr1 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv1.RowFilter = rowfilterstr1;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找不到" 的處理
				if (dv1.Count > 0)
				{
					LoginEmpCName = dv1[0]["srspn_cname"].ToString().Trim();
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
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("adprom_label.aspx");
		}
		
		
		// 查詢 按鈕的處理
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";
			
			// 顯示 DataGrid1
			BindGrid1();
		}
		
		
		// 顯示 DataGrid1
		private void BindGrid1()
		{
			// 抓出篩選條件
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();
			string strLoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strConttp= " + strConttp + "<br>");
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strMtpcd= " + strMtpcd + "<br>");
			//Response.Write("strLoginEmpNo= " + strLoginEmpNo + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_cont");
			DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";
			rowfilterstr2 = rowfilterstr2 + " AND cont_conttp='" + strConttp + "'";
			if(this.cbx0.Checked)
			{
				rowfilterstr2 = rowfilterstr2 + " AND or_mtpcd='" + strMtpcd + "'";
			}
			else
			{
				rowfilterstr2 = rowfilterstr2;
			}
			dv2.RowFilter = rowfilterstr2;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv2.Count > 0)
			{
				// 轉址
				string RedirectURL = "adprom_label2.aspx";
				RedirectURL = RedirectURL + "?conttp=" + strConttp + "&bkcd=" + strBkcd + "&LEmpNo=" + strLoginEmpNo;
				if(this.cbx0.Checked)
				{
					RedirectURL = RedirectURL + "&mtpcd=" + strMtpcd;
				}
				else
				{
					RedirectURL = RedirectURL + "&mtpcd=";
				}
				//Response.Write("RedirectURL= " + RedirectURL + "<br>");
				
				this.lblMessage.Text="結果: 找到 <B>" + dv2.Count + "</B>筆資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_blank'>此連結</A> 來繼續進行下一動作!<br>";
			}
			else
			{
				this.lblMessage.Text = "找不到符合條件的資料, 您可以 重設條件!";
			}
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
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["itridpa_mrlpub"];
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																				 new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																				 new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																				 new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sedate", "cont_sedate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttpName", "cont_conttpName"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT DISTINCT TOP 100 PERCENT dbo.c2_cont.cont_contno, RTRIM(dbo.c2_cont.cont_c" +
				"ustno) AS cont_custno, RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mf" +
				"r.mfr_inm) AS mfr_inm, RTRIM(dbo.cust.cust_nm) AS cust_nm, RTRIM(dbo.cust.cust_j" +
				"bti) AS cust_jbti, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.cust.cust_cell, dbo" +
				".cust.cust_email, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.cust.cust_it" +
				"pcd, dbo.cust.cust_btpcd, dbo.cust.cust_rtpcd, dbo.mfr.mfr_respnm, RTRIM(dbo.mfr" +
				".mfr_respjbti) AS mfr_respjbti, RTRIM(dbo.mfr.mfr_izip) AS mfr_izip, RTRIM(dbo.m" +
				"fr.mfr_iaddr) AS mfr_iaddr, dbo.c2_cont.cont_syscd, dbo.cust.cust_custno, dbo.mf" +
				"r.mfr_mfrno, dbo.c2_cont.cont_conttp, RTRIM(dbo.c2_cont.cont_empno) AS cont_empn" +
				"o, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.c2_cont.cont_bkcd, dbo.c2_co" +
				"nt.cont_signdate, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.co" +
				"nt_aunm, dbo.c2_cont.cont_autel, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) + \'/\' +" +
				" SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6) + \'~\' + SUBSTRING(dbo.c2_cont.cont_edat" +
				"e, 1, 4) + \'/\' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate, CASE WH" +
				"EN dbo.c2_cont.cont_conttp = \'01\' THEN \'一般\' ELSE \'推廣\' END AS cont_conttpName, db" +
				"o.c2_or.or_inm, dbo.c2_or.or_nm, dbo.c2_or.or_jbti, dbo.c2_or.or_addr, dbo.c2_or" +
				".or_zip, dbo.c2_or.or_pubcnt, dbo.c2_or.or_unpubcnt, dbo.c2_or.or_fgmosea, dbo.c" +
				"2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm, RTRIM(dbo.book.bk_nm) AS bk_nm F" +
				"ROM dbo.c2_cont INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_c" +
				"ustno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOI" +
				"N dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.c2_" +
				"or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND dbo.c2_cont.cont_contno = " +
				"dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd" +
				" INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd WHERE (dbo.c2_c" +
				"ont.cont_fgclosed = \'0\') AND (dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont." +
				"cont_fgtemp = \'0\') AND (dbo.c2_or.or_pubcnt > 0) ORDER BY dbo.c2_cont.cont_bkcd," +
				" dbo.c2_cont.cont_empno, dbo.c2_cont.cont_contno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
