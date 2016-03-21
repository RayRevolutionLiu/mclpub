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
	/// Summary description for adlprior_get.
	/// </summary>
	public class adlprior_get : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label lblBookName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		
		public adlprior_get()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
				
				// 抓出 書籍名稱
				GetBookName();
				
				
				// 顯示 DataGrid1 資料
				BindGrid1();
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 抓出 書籍名稱
		public void GetBookName()
		{
			// 抓出 書籍類別代碼
			string BookCode;
			if(Context.Request.QueryString["bkcd"].Trim()=="")
				BookCode = "01";
			else
				BookCode = Context.Request.QueryString["bkcd"].Trim();
			//Response.Write("BookCode= " + BookCode + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "book");
			DataView dv2 = ds2.Tables["book"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + "AND bk_bkcd = " + BookCode;
			dv2.RowFilter = rowfilterstr2;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// 若有資料, 則輸出顯示之
			if(dv2.Count > 0)
			{
				// 計算及顯示筆數
				this.lblBookName.Text = dv2[0]["bk_nm"].ToString().Trim();
			}
		}
		
		
		// 顯示 DataGrid1 資料
		public void BindGrid1()
		{
			// 抓出 書籍類別代碼
			string BookCode;
			if(Context.Request.QueryString["bkcd"].Trim()=="")
				BookCode = "01";
			else
				BookCode = Context.Request.QueryString["bkcd"].Trim();
			//Response.Write("BookCode= " + BookCode + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "lprior");
			DataView dv1 = ds1.Tables["lprior"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			rowfilterstr1 = rowfilterstr1 + "AND lp_bkcd = " + BookCode;
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// 若有資料, 則輸出顯示之
			if(dv1.Count > 0)
			{
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
			
				// 計算及顯示筆數
				this.lblResult.Text = "搜尋結果...";
				this.lblNum.Text = dv1.Count.ToString();
			}
		}
		
		
		// 選取 DataGrid1 某筆資料的處理
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
		}
		
		
		// 換頁處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				   new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_lprior.lp_bkcd, c2_lprior.lp_priorseq, c2_lprior.lp_clrcd, c2_lprior.lp_ltpcd, c2_lprior.lp_pgscd, c2_ltp.ltp_nm, c2_clr.clr_nm, c2_pgsize.pgs_nm, c2_clr.clr_clrcd, c2_ltp.ltp_ltpcd, c2_pgsize.pgs_pgscd FROM c2_lprior INNER JOIN c2_clr ON c2_lprior.lp_clrcd = c2_clr.clr_clrcd INNER JOIN c2_ltp ON c2_lprior.lp_ltpcd = c2_ltp.ltp_ltpcd INNER JOIN c2_pgsize ON c2_lprior.lp_pgscd = c2_pgsize.pgs_pgscd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT bk_bkcd, bk_nm FROM book";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
