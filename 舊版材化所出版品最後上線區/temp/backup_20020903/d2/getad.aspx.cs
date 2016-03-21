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

namespace MRLPub_d2
{
	/// <summary>
	/// Summary description for getad.
	/// </summary>
	public class getad : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm adpub_list;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.TextBox tbxyyyymm;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		public getad()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{	
				// 清除畫面資料
				this.cbx1.Checked = true;
				this.cbx2.Checked = true;
				this.cbx3.Checked = true;
				this.lblMessage.Text = "";

				
				// 給 催稿年月 tbxYYYYMM 預設值 (今天年月)
				//this.tbxyyyymm.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
				this.tbxyyyymm.Text = System.DateTime.Today.ToString("yyyyMM").Trim();
				
				
				// 顯示下拉式選單 業務員的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "srspn");
				ddlEmpNo.DataSource=ds1;
				ddlEmpNo.DataTextField="srspn_cname";
				ddlEmpNo.DataValueField="srspn_empno";
				ddlEmpNo.DataBind();
				this.ddlEmpNo.SelectedIndex = 0;
				
				
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, proj.proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date FROM srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <" +
				"> \'d\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("fgCont", "fgCont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sedate", "cont_sedate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("pubmmstr", "pubmmstr"),
																																																				 new System.Data.Common.DataColumnMapping("CountPubSeq", "CountPubSeq"),
																																																				 new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("contno", "contno"),
																																																				 new System.Data.Common.DataColumnMapping("syscd", "syscd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno")})});
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
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd")})});
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
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT \'No\' AS fgCont, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_aunm" +
				", mfr.mfr_inm, c2_cont.cont_autel, c2_cont.cont_aufax, c2_cont.cont_aucell, SUBS" +
				"TRING(c2_cont.cont_sdate, 1, 4) + \'/\' + SUBSTRING(c2_cont.cont_sdate, 5, 6) + \' " +
				"~ \' + SUBSTRING(c2_cont.cont_edate, 1, 4) + \'/\' + SUBSTRING(c2_cont.cont_edate, " +
				"5, 6) AS cont_sedate, c2_cont.cont_restjtm, c2_cont.cont_resttm, c2_cont.cont_sd" +
				"ate, c2_cont.cont_edate, c2_cont.cont_bkcd, c2_cont.cont_empno, c2_getad.pubmmst" +
				"r, 1 AS CountPubSeq, c2_clr.clr_nm, c2_ltp.ltp_nm, c2_pgsize.pgs_nm, c2_pub.pub_" +
				"adamt, c2_pub.pub_drafttp, c2_pub.pub_origbkcd, c2_pub.pub_origjno, c2_pub.pub_o" +
				"rigjbkno, c2_pub.pub_chgbkcd, c2_pub.pub_chgjno, c2_pub.pub_chgjbkno, c2_pub.pub" +
				"_fgrechg, c2_njtp.njtp_nm, c2_pub.pub_fggot, c2_cont.cont_clrtm, c2_cont.cont_me" +
				"notm, c2_cont.cont_getclrtm, c2_clr.clr_clrcd, c2_getad.contno, c2_getad.syscd, " +
				"c2_ltp.ltp_ltpcd, c2_njtp.njtp_njtpcd, c2_pgsize.pgs_pgscd, c2_pub.pub_contno, c" +
				"2_pub.pub_pubseq, c2_pub.pub_syscd, c2_pub.pub_yyyymm, mfr.mfr_mfrno FROM c2_con" +
				"t INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN c2_getad ON c2" +
				"_cont.cont_contno = c2_getad.contno AND c2_cont.cont_syscd = c2_getad.syscd INNE" +
				"R JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno =" +
				" c2_pub.pub_contno LEFT OUTER JOIN c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd" +
				" LEFT OUTER JOIN c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER " +
				"JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN c2_njtp ON c2" +
				"_pub.pub_njtpcd = c2_njtp.njtp_njtpcd WHERE (c2_cont.cont_fgclosed = \'0\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// 當按下 "查詢" 時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			//sqlDataAdapter3 是根據 v_c2_getad_final
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "v_c2_getad_final");
			DataView dv3 = ds3.Tables["v_c2_getad_final"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string rowfilter = "1=1";
			
			// 抓出所選取的查詢條件
			string BookCode = "";
			string yyyymm = "";
			string EmpNo = "";
			string strbuf="getad2.aspx?";
			yyyymm = this.tbxyyyymm.Text.ToString().Trim();
			rowfilter = rowfilter + " AND cont_sdate <='" + yyyymm + "'";
			
			// 若勾選查詢條件一時
			if(cbx1.Checked)
			{
				BookCode = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
				rowfilter = rowfilter + " AND cont_bkcd ='" + BookCode + "'";
				strbuf = strbuf + "bkcd=" + BookCode + "&";
				//Response.Write("BookCode= " + BookCode + "<br>");
			}
			
			// 若勾選查詢條件二時
			if(cbx2.Checked)
			{
				rowfilter = rowfilter + " AND pub_yyyymm ='" + yyyymm + "'";
				strbuf = strbuf + "yyyymm=" + yyyymm + "&";
				//Response.Write("yyyymm= " + yyyymm + "<br>");
			}
			
			// 若勾選查詢條件三時
			if(cbx3.Checked)
			{
				EmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
				rowfilter = rowfilter + " AND cont_empno ='" + EmpNo + "'";
				strbuf = strbuf + "empno=" + EmpNo;
				//Response.Write("EmpNo= " + EmpNo + "<br>");
			}
			//Response.Write("getad2.aspx?BookCode=" + BookCode + "&yyyymm=" + yyyymm + "&EmpNo=" + EmpNo + "<br>");
			dv3.RowFilter = rowfilter;
			
			// 檢查並輸出 最後 Row Filter 的結果
			if(dv3.Count > 0)
			{
				//Response.Write("dv3.Count= " + dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
				//Response.Write("strbuf= " + strbuf + "<br>");
				this.lblMessage.Text = "共有" + dv3.Count + " 筆資料!";

				// 轉址: 執行 ExcelSpeedGen
				//Response.Redirect("getad2.aspx");
				Response.Redirect(strbuf);
			}
			else
			{
				//Response.Write("<font Color='Red'>查無資料, 請重新輸入查詢條件!</font><BR>");
				this.lblMessage.Text = "查無資料, 請重新輸入查詢條件!";
			}
						
			
//			// 若合約迄日(200302) >= 今時年月(200202), 表示未過期
//			// 若合約迄日(200012) <= 今時年月(200202), 表示已過期
//			// 已過期已結案 => 不顯示出
//			// 已過期未結案 => 催稿, 給續約註記
//			// 已過期已結案 => 催稿
//			// 已過期未結案 => 催稿, 確認落版位置
//			//rowfilter = rowfilter + " and (cont_edate >='" + TodayDate + "')";
//			Response.Write("rowfilter= " + rowfilter + "<br>");
//			
//			// 再做 sort 動作 (order by)
//			//rowfilter = rowfilter + " ORDER BY cont_empno, cont_edate, pub_ltpcd, pub_clrcd";
			
			
		}


	}
}
