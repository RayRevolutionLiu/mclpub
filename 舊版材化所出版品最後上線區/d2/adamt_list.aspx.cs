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
	/// Summary description for adamt_list.
	/// </summary>
	public class adamt_list : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlForm adcont_list;
	
		public adamt_list()
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
				
				
				// 顯示下拉式選單 書籍類別代碼的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "book");
				this.ddlBookCode.DataSource=ds1;
				this.ddlBookCode.DataTextField="bk_nm";
				this.ddlBookCode.DataValueField="bk_bkcd";
				this.ddlBookCode.DataBind();
				
				
				// 顯示下拉式選單 業務員的 DB 值
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				this.ddlEmpNo.DataSource=ds2;
				this.ddlEmpNo.DataTextField="srspn_cname";
				this.ddlEmpNo.DataValueField="srspn_empno";
				this.ddlEmpNo.DataBind();
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
					
				// 給 tbxYYYYMM 預設值 (今天年月)
				this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
				
				
				// 抓取登入業務員資訊 - 工號及姓名
				GetLoginEmpInfo();
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 抓取登入業務員資訊 - 工號及姓名
		private void GetLoginEmpInfo()
		{
			// 抓出登入者的工號, 作為預設 製表業務員 之值
			string LoginEmpNo = "";
			string LoginEmpCName = "";
			//Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
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
			CountPubData();
		}
		
		
		private void CountPubData()
		{
			// 抓出畫面上的值
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			string strLoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strEmpNo= " + strEmpNo + "<br>");
			//Response.Write("strLoginEmpNo= " + strLoginEmpNo + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_pub");
			DataView dv3 = ds3.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND cont_bkcd='" + strBkcd + "'";
			rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm='" + strYYYYMM + "'";
			if(this.cbx0.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND cont_empno='" + strEmpNo + "'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}
			dv3.RowFilter = rowfilterstr3;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若有資料須修正時, 顯示 DataGrid1
			if(dv3.Count > 0)
			{
				// 轉址
				string RedirectURL = "adamt_list2.aspx";
				RedirectURL = RedirectURL + "?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&LEmpNo=" + strLoginEmpNo;
				if(this.cbx0.Checked)
				{
					RedirectURL = RedirectURL + "&empno=" + strEmpNo;
				}
				else
				{
					RedirectURL = RedirectURL + "&empno=";
				}
				//Response.Write("RedirectURL= " + RedirectURL + "<br>");
				
				this.lblMessage.Text="結果: 找到 <B>" + dv3.Count + "</B>筆落版資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_blank'>此連結</A> 來繼續進行下一動作!<br>";
			}
			else
			{
				this.lblMessage.Text = "很抱歉, 當月無落版資料！";
			}
		}
		
		
		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("adamt_list.aspx");
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
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
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
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iFullAddr", "mfr_iFullAddr"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_totamt", "pub_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT DISTINCT dbo.c2_cont.cont_contno, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_empno, RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.mfr.mfr_izip) AS mfr_izip, RTRIM(dbo.mfr.mfr_iaddr) AS mfr_iaddr, RTRIM(dbo.mfr.mfr_izip) + ' ' + RTRIM(dbo.mfr.mfr_iaddr) AS mfr_iFullAddr, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_pgscd, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt AS pub_totamt, dbo.iad.iad_iano FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.iad ON dbo.c2_pub.pub_syscd = dbo.iad.iad_syscd AND dbo.c2_pub.pub_contno = dbo.iad.iad_fk1 AND dbo.c2_pub.pub_yyyymm = dbo.iad.iad_fk2 AND dbo.c2_pub.pub_pubseq = dbo.iad.iad_fk3 WHERE (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
