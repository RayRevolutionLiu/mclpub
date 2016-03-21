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
// SQLCommand
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for PubFm_Add.
	/// </summary>
	public class PubFm_Add : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.TextBox tbxSysCode;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnLoadData;
		protected System.Web.UI.WebControls.Label lblAddMessage;
		protected System.Web.UI.WebControls.Label lblPubSeq;
		protected System.Web.UI.WebControls.TextBox tbxPageNo;
		protected System.Web.UI.WebControls.Label lblStartDate;
		protected System.Web.UI.WebControls.Label lblEndDate;
		protected System.Web.UI.WebControls.Label lblBkcd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public PubFm_Add()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			// 抓預設資料 (廠商客戶資料) - 新增Form
			InitialData();
			
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 給預設資料 - 新增Form
		private void InitialData()
		{
//			// 顯示下拉式選單 廣告色彩的 DB 值
//			DataSet ds1 = new DataSet();
//			this.sqlDataAdapter1.Fill(ds1, "mtp");
//			ddlORmtpcd.DataSource=ds1;
//			ddlORmtpcd.DataTextField="mtp_nm";
//			ddlORmtpcd.DataValueField="mtp_mtpcd";
//			ddlORmtpcd.DataBind();
			
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				string contno = Context.Request.QueryString["contno"].ToString().Trim();
				this.tbxContNo.Text = contno;
				// 塞入相關合約書資料
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c2_cont");
				DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND cont_contno='" + contno + "'";
				dv2.RowFilter = rowfilterstr2;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找不到" 的處理
				if (dv2.Count > 0)
				{
					this.lblStartDate.Text = dv2[0]["cont_sdate"].ToString().Trim();
					this.lblEndDate.Text = dv2[0]["cont_edate"].ToString().Trim();
				}
				
				// 檢查 已新增 落版區 是否有資料
				BindGrid1();
			}
			else
			{
				// do nothing 不載入
				this.lblAddMessage.Text = "無合約書編號資料, 無法載入落版資料; 請回上一步驟重新搜尋!<br>";
			}
			
			// 檢查是否有書籍代碼
			if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
			{
				//
				this.lblBkcd.Text = Context.Request.QueryString["bkcd"].ToString().Trim();
			}
		}
		
		
		// 已新增 落版區
		private void BindGrid1()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " and pub_contno = '" + contno + "'";
			}
			else
			{
				contno = "";
			}
			dv1.RowFilter = rowfilterstr1;
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
				
			}
			else
			{
				this.lblAddMessage.Text = "無初始資料, 請自行新增!<br>";
			}
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
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																				new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				new System.Data.Common.DataColumnMapping("pub_moddate", "pub_moddate"),
																																																				new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_pubseq, c2_pub.pub_yyyymm, c2_pub.pub_pno, c2_pub.pub_pgno, c2_pub.pub_fgfixpg, c2_pub.pub_clrcd, c2_clr.clr_nm, c2_pub.pub_pgscd, c2_pgsize.pgs_nm, c2_pub.pub_ltpcd, c2_ltp.ltp_nm, c2_pub.pub_fggot, c2_pub.pub_imseq, invmfr.im_nm, c2_pub.pub_adamt, c2_pub.pub_chgamt, c2_pub.pub_drafttp, c2_pub.pub_origbkcd, c2_pub.pub_origjno, c2_pub.pub_origjbkno, c2_pub.pub_chgbkcd, c2_pub.pub_chgjno, c2_pub.pub_chgjbkno, c2_pub.pub_fgrechg, c2_pub.pub_njtpcd, c2_pub.pub_projno, c2_pub.pub_costctr, c2_pub.pub_fginved, c2_pub.pub_fginvself, c2_pub.pub_remark, c2_pub.pub_moddate, c2_pub.pub_modempno, c2_pub.pub_bkcd, c2_pub.pub_fgupdated, c2_clr.clr_clrcd, c2_ltp.ltp_ltpcd, c2_pgsize.pgs_pgscd, invmfr.im_contno, invmfr.im_imseq, invmfr.im_syscd FROM c2_pub INNER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd INNER JOIN c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd INNER JOIN c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd INNER JOIN invmfr ON c2_pub.pub_imseq = invmfr.im_imseq WHERE (invmfr.im_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adamt", "cont_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freebkcnt", "cont_freebkcnt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("MaxPubTime", "MaxPubTime")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT cont_conttp, cont_bkcd, cont_empno, cont_modempno, cont_sdate, cont_edate, cont_totjtm, cont_tottm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_adamt, cont_freebkcnt, cont_freetm, cont_tottm + cont_freetm AS MaxPubTime, cont_contno, cont_syscd FROM c2_cont";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
