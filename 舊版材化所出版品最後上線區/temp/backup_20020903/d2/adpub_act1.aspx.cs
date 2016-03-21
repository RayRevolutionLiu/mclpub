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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_act1.
	/// </summary>
	public class adpub_act1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblMemo;
	
		public adpub_act1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 給 截止年月 tbxYYYYMM 預設值 (今天年月)
				this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyyMM").Trim();
				
				// 書籍類別給預設值
				//this.ddlBookCode.SelectedItem.Value = "00";
				

				// 清空查詢結果的訊息
				lblMessage.Text = "";
				
				
				// 下段抄自 cont_new3.aspx.cs
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
				// 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("pub_pubid", "pub_pubid"),
																																																			  new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																			  new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																			  new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																			  new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																			  new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																			  new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																			  new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																			  new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																			  new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																			  new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																			  new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																			  new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																			  new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																			  new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																			  new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																			  new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																			  new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																			  new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																			  new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																			  new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																			  new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																			  new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																			  new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																			  new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																			  new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																			  new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("bkp_bkpid", "bkp_bkpid"),
																																																			  new System.Data.Common.DataColumnMapping("bkp_bkcd", "bkp_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bkp_date", "bkp_date"),
																																																			  new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																			  new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_moddate", "pub_moddate"),
																																																			  new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																			  new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_pub.pub_pubid, c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_yyyymm, c2_pub.pub_pubseq, c2_pub.pub_pgno, c2_pub.pub_ltpcd, c2_pub.pub_clrcd, c2_pub.pub_pgscd, c2_pub.pub_adamt, c2_pub.pub_chgamt, c2_pub.pub_drafttp, c2_pub.pub_origbkcd, c2_pub.pub_origjno, c2_pub.pub_origjbkno, c2_pub.pub_chgjno, c2_pub.pub_fgrechg, c2_pub.pub_fggot, c2_pub.pub_njtpcd, c2_pub.pub_projno, c2_pub.pub_costctr, c2_pub.pub_fginved, c2_pub.pub_fginvself, c2_pub.pub_pno, c2_pub.pub_remark, c2_pub.pub_fgfixpg, c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_tel, mfr.mfr_mfrid, mfr.mfr_mfrno, bookp.bkp_bkpid, bookp.bkp_bkcd, bookp.bkp_date, bookp.bkp_pno, book.bk_bkid, book.bk_bkcd, book.bk_nm, c2_pub.pub_chgbkcd, c2_pub.pub_chgjbkno, c2_pub.pub_moddate, c2_pub.pub_modempno, c2_pub.pub_bkcd, c2_cont.cont_fgclosed FROM book INNER JOIN c2_cont ON book.bk_bkcd = c2_cont.cont_bkcd INNER JOIN bookp ON book.bk_bkcd = bookp.bkp_bkcd INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno RIGHT OUTER JOIN c2_pub ON bookp.bkp_date = c2_pub.pub_yyyymm AND c2_cont.cont_contno = c2_pub.pub_contno WHERE (c2_cont.cont_fgclosed <> '1')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
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
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, book.bk_nm, proj.proj_syscd, proj.proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c2_pub");
			DataView dv = ds.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr = "1=1";

			//防呆處理: 若無資料時, 則給錯誤訊息
			//if (dv1.Count < 1)  ...
			// 若找到資料, 則在 Server Web Control 顯示之

			// 若書籍類別有選擇(即<>00)的話, 則給予 SQL Filter 條件
			//Response.Write("tbxPubDate.Text= " + tbxPubDate.Text.ToString().Trim()  + "<br>");
			//Response.Write("ddlBookCode.value= " + ddlBookCode.SelectedItem.Value.ToString() + "<br>");
			if(ddlBookCode.SelectedItem.Value.ToString()!="")
				rowfilterstr = rowfilterstr + " and (pub_bkcd = '" + ddlBookCode.SelectedItem.Value.ToString() + "')";
			else
				rowfilterstr = rowfilterstr;
			
			// 若刊登年月有資料(即<>'')的話, 則給予 SQL Filter 條件
			if(tbxPubDate.Text!="")
				rowfilterstr = rowfilterstr + " and (pub_yyyymm like '%" + tbxPubDate.Text.ToString().Trim() +"%')";
			
			dv.RowFilter = rowfilterstr;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv.Count==0)
				lblMessage.Text="結果: 找不到符合條件的資料, 您可以重設條件";
			else
			{
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("rowfilterstr= " + rowfilterstr + "<BR>");
				
				// 抓出下一步驟要轉址到什處去?  (因此網頁由 2.3.1 & 2.3.2 共用)
				// action=1 => 2.3.1 廣告落版動作; action=2 => 2.3.2 美編樣後修正
				string RedirectURL = "";
				if(Context.Request.QueryString["action"]=="1")
					RedirectURL = "adpub_act2.aspx?bkcd=" + ddlBookCode.SelectedItem.Value.ToString() + "&yyyymm=" + tbxPubDate.Text.ToString().Trim();
				else if(Context.Request.QueryString["action"]=="2")
					RedirectURL = "adpub_actupdate.aspx?bkcd=" + ddlBookCode.SelectedItem.Value.ToString() + "&yyyymm=" + tbxPubDate.Text.ToString().Trim();
				
				//Response.Write("dv.Count= "+ dv.Count + "<BR>");
				lblMessage.Text="結果: 找到 <B>"+dv.Count.ToString()+"</B>筆資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_self'>此連結</A> 來繼續進行下一動作!<br>";
				
				//DataGrid1.DataSource=dv;
				//DataGrid1.DataBind();
			}

		}
	}
}
