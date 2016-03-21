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
	/// Summary description for pgno_addnew.
	/// </summary>
	public class pgno_addnew : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList ddlBkcd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rev1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.TextBox tbxStartPageNo;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
				
				// 載入預設資料
				InitialData();
			}
		}
		
		
		private void InitialData()
		{
			this.lblMessage.Text = "";
			this.tbxStartPageNo.Text = "4";
			
			
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
		}
		
		
		// 確認新增 按鈕的處理
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			// 抓出 書籍類別 PK, 檢查資料是否重覆輸入
			string strbkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_pgno");
			DataView dv2 = ds2.Tables["c2_pgno"].DefaultView;
				
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND pg_bkcd='" + strbkcd + "'";
			dv2.RowFilter = rowfilterstr2;
				
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
			// 若搜尋結果為 "找不到" 的處理
			if (dv2.Count > 0)
			{
				this.lblMessage.Text = "很抱歉, '" + this.ddlBkcd.SelectedItem.Text.ToString().Trim() + "' 已有起啟內碼資料, 新增失敗!<br>請重選書籍類別 或 放棄新增!";
			}
			else
			{
				InsertToDB();
			}
		}
		
		
		private void InsertToDB()
		{
			// 抓出畫面上的值
			string strbkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strStartPageNo = this.tbxStartPageNo.Text.ToString().Trim();
			//Response.Write("strbkcd= " + strbkcd + "<br>");
			//Response.Write("strStartPageNo= " + strStartPageNo + "<br>");
			
			
			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@bkcd"].Value = strbkcd;
			this.sqlCommand1.Parameters["@startpgno"].Value = strStartPageNo;
			//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
			
			
			// 確認執行 sqlCommand1 成功
			this.sqlCommand1.Connection.Open();
    
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCommand1.Connection.BeginTransaction();
			this.sqlCommand1.Transaction = myTrans;
			try
			{
				this.sqlCommand1.ExecuteNonQuery();
				myTrans.Commit();
				Literal1.Text = "<script language=javascript>alert(\"資料新增成功!\");</script>";
				// 轉址
				Response.Redirect("pgno.aspx");
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				Response.Write(ex1.Message + "<br>");
				myTrans.Rollback();
				Literal1.Text = "<script language=javascript>alert(\"資料新增失敗!\");</script>";
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}
		}
		
		
		// 放棄新增 按鈕的處理
		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("pgno.aspx");
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
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
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
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("Expr1", "Expr1")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, RTRIM(proj.proj_fgitri) AS proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd, proj.proj_fgitri AS Expr1 FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "INSERT INTO c2_pgno (pg_bkcd, pg_startpgno) VALUES (@bkcd, @startpgno)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "pg_bkcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startpgno", System.Data.SqlDbType.Int, 4, "pg_startpgno"));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgno", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pg_pgid", "pg_pgid"),
																																																				 new System.Data.Common.DataColumnMapping("pg_bkcd", "pg_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pg_startpgno", "pg_startpgno")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT pg_pgid, pg_bkcd, pg_startpgno FROM c2_pgno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
