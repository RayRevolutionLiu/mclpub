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
	/// Summary description for ORCounts_stat.
	/// </summary>
	public class ORCounts_stat : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Web.UI.WebControls.DropDownList ddlPubCountType;
		protected System.Web.UI.WebControls.Label lblCountType;
		protected System.Web.UI.WebControls.DropDownList ddlfgMOSea;
		protected System.Web.UI.WebControls.Label lblfgMOSea;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblMtpcd;
		protected System.Web.UI.WebControls.DropDownList ddlMtpcd;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		
		
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
			
			
			// 顯示下拉式選單 業務員 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement; 
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "mtp");
			DataView dv4=ds4.Tables["mtp"].DefaultView;
			ddlMtpcd.DataSource=dv4;
			ddlMtpcd.DataTextField="mtp_nm";
			ddlMtpcd.DataValueField="mtp_mtpcd";
			ddlMtpcd.DataBind();
			
			
			this.cbx0.Checked = false;
			this.cbx1.Checked = false;
			
			
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
			CountPubData();
		}
		
		
		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			//InitialData();
			Response.Redirect("ORCounts_stat.aspx");
		}
		
		
		// 計算是否有該月的資料, 若有則提供連結串接
		private void CountPubData()
		{
			// 抓出篩選條件
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string  strPubCountType = this.ddlPubCountType.SelectedItem.Value.ToString().Trim();
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string Mtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();
			string LoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strPubCountType= " + strPubCountType + "<br>");
			//Response.Write("fgMOSea= " + fgMOSea + "<br>");
			//Response.Write("Mtpcd= " + Mtpcd + "<br>");
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_cont");
			DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			// 書籍類別 篩選條件
			rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";
			// 有登本數／未登本數 篩選條件
			if(strPubCountType == "1")
			{
				rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm='" + strYYYYMM + "'";
			}
			else if(strPubCountType == "2")
			{
				// do nothing
				rowfilterstr2 = rowfilterstr2;
			}
			// 郵寄地區
			if(this.cbx0.Checked)
			{
				rowfilterstr2 = rowfilterstr2 + " AND or_fgmosea='" + fgMOSea + "'";
			}
			else
			{
				rowfilterstr2 = rowfilterstr2;
			}
			// 郵寄類別
			if(this.cbx1.Checked)
			{
				rowfilterstr2 = rowfilterstr2 + " AND or_mtpcd='" + Mtpcd + "'";
			}
			else
			{
				rowfilterstr2 = rowfilterstr2;
			}
			dv2.RowFilter = rowfilterstr2;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// 若有資料須修正時, 顯示 DataGrid1
			if(dv2.Count > 0)
			{
				// 轉址
				string RedirectURL = "ORCounts_stat2.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&pubcounttp=" + strPubCountType + "&LEmpNo=" + LoginEmpNo;
				if(this.cbx0.Checked)
				{
					RedirectURL = RedirectURL + "&fgmosea=" + fgMOSea;
				}
				else
				{
					RedirectURL = RedirectURL + "&fgmosea=";
				}
				if(this.cbx1.Checked)
				{
					RedirectURL = RedirectURL + "&mtpcd=" + Mtpcd;
				}
				else
				{
					RedirectURL = RedirectURL + "&mtpcd=";
				}
				this.lblMessage.Text="結果: 找到 <B>" + dv2.Count + "</B>筆資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_self'>此連結</A> 來繼續進行下一動作!<br>";
			}
			else
			{
				this.lblMessage.Text = "很抱歉, 當月無郵寄本數資料！";
			}
		}
		
		
		// 郵寄地區(國內外註記) 勾選變更的處理 
		private void cbx0_CheckedChanged(object sender, System.EventArgs e)
		{
			string strfgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strfgMOSea= " + strfgMOSea + "<br>");
			
			if(strfgMOSea == "1")
			{
				this.cbx1.Checked = true;
			}
			else
			{
				this.cbx1.Checked = false;
			}
		}
		
		
		// 下拉式選單 郵寄地區(國內外註記) 變更的處理
		private void ddlfgMOSea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strfgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strfgMOSea= " + strfgMOSea + "<br>");
			
			if(strfgMOSea == "1")
			{
				this.cbx0.Checked = true;
				this.cbx1.Checked = false;
				this.ddlMtpcd.ClearSelection();
				this.ddlMtpcd.Items.FindByValue("24").Selected = true;
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlertError = new LiteralControl();
				litAlertError.Text = "<script language=javascript>alert(\"請選擇您要的 '國外-郵寄類別',\n然後再按一下 '查詢' 按鈕!\");</script>";
				Page.Controls.Add(litAlertError);
			}
			else
			{
				this.cbx0.Checked = false;
				this.cbx1.Checked = false;
				this.ddlMtpcd.ClearSelection();
				this.ddlMtpcd.Items.FindByValue("11").Selected = true;
			}
		}
		 
		
		// 郵寄類別 勾選變更的處理 
		private void cbx1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbx1.Checked)
			{
				this.cbx0.Checked = true;
			}
			else
			{
				this.cbx0.Checked = false;
			}
		}
		
		
		// 下拉式選單 郵寄類別 變更的處理
		private void ddlMtpcd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intMtpcd = Convert.ToInt32(this.ddlMtpcd.SelectedItem.Value.ToString().Trim());
			//Response.Write("intMtpcd= " + intMtpcd + "<br>");
			
			if(intMtpcd >= 20)
			{
				this.cbx0.Checked = true;
				this.ddlfgMOSea.SelectedIndex = 1;
				this.cbx1.Checked = true;
			}
			else
			{
				this.cbx0.Checked = true;
				this.ddlfgMOSea.SelectedIndex = 0;
				this.cbx1.Checked = true;
			}
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
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.cbx0.CheckedChanged += new System.EventHandler(this.cbx0_CheckedChanged);
			this.ddlfgMOSea.SelectedIndexChanged += new System.EventHandler(this.ddlfgMOSea_SelectedIndexChanged);
			this.cbx1.CheckedChanged += new System.EventHandler(this.cbx1_CheckedChanged);
			this.ddlMtpcd.SelectedIndexChanged += new System.EventHandler(this.ddlMtpcd_SelectedIndexChanged);
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
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, proj.proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("TotPubCnt", "TotPubCnt"),
																																																				new System.Data.Common.DataColumnMapping("TotUnPubCnt", "TotUnPubCnt")})});
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
				"n_empno FROM srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'d\')";
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
			this.sqlSelectCommand4.CommandText = "SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM mtp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT c2_pub.pub_contno, c2_cont.cont_bkcd, RTRIM(book.bk_nm) AS bk_nm, RTRIM(c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd, RTRIM(mtp.mtp_nm) AS mtp_nm, c2_or.or_fgmosea, RTRIM(c2_or.or_zip) AS or_zip, RTRIM(c2_or.or_addr) AS or_addr, c2_pub.pub_yyyymm, SUM(c2_or.or_pubcnt) AS TotPubCnt, SUM(c2_or.or_unpubcnt) AS TotUnPubCnt FROM c2_pub INNER JOIN c2_or ON c2_pub.pub_syscd = c2_or.or_syscd AND c2_pub.pub_contno = c2_or.or_contno INNER JOIN c2_cont ON c2_pub.pub_syscd = c2_cont.cont_syscd AND c2_pub.pub_contno = c2_cont.cont_contno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd GROUP BY c2_pub.pub_contno, c2_cont.cont_bkcd, book.bk_nm, c2_cont.cont_mfrno, mfr.mfr_inm, c2_or.or_mtpcd, mtp.mtp_nm, c2_or.or_fgmosea, c2_or.or_zip, c2_or.or_addr, c2_pub.pub_yyyymm ORDER BY c2_or.or_fgmosea, c2_or.or_mtpcd, c2_pub.pub_contno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
