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
	/// Summary description for bookp_get.
	/// </summary>
	public class bookp_get : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.Label lblGetBookPNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBookPNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenYYYYMM;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
	
		public bookp_get()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindGrid();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
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
																									  new System.Data.Common.DataTableMapping("Table", "bookp", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_date", "bkp_date"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno"),
																																																			   new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_bkcd", "bkp_bkcd")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT book.bk_nm, bookp.bkp_date, RTRIM(bookp.bkp_pno) AS bkp_pno, book.bk_bkcd," +
				" bookp.bkp_bkcd FROM bookp INNER JOIN book ON bookp.bkp_bkcd = book.bk_bkcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		public void BindGrid()
		{
			// Put user code to initialize the page here
			// 抓出當月的刊登年月 Currentyyyymm, (若是, 並以紅色顯示)
			string ThisYear = System.DateTime.Today.Year.ToString().Trim();
			string ThisMonth = System.DateTime.Today.Month.ToString().Trim();
			if(ThisMonth.Length==1)
					ThisMonth = "0" + ThisMonth;
			string Currentyyyymm = ThisYear + ThisMonth;
			//Response.Write("Currentyyyymm= " + Currentyyyymm + "<br>");
			
			// 抓出 書籍類別代碼
			string BookCode;
			if(Context.Request.QueryString["bkcd"].Trim()=="")
				BookCode = "01";
			else
				BookCode = Context.Request.QueryString["bkcd"].Trim();
			//Response.Write("BookCode= " + BookCode + "<br>");
			//Response.Write("ThisYear+2= " + (int.Parse(ThisYear)+2) + "<br>");
			
			// 由網頁變數抓出所填之刊登年月, 好使該筆顏色為藍
			string ym;
			if(Context.Request.QueryString["ym"].Trim()=="")
				ym = Currentyyyymm;
			else
				ym = Context.Request.QueryString["ym"].Trim();
			hiddenYYYYMM.Value= ym;
			//Response.Write("ym= " + ym + "<br>");
			// 抓出 ym 的年度碼 4碼, 好塞入 sql RowFilter
			string Gotyyyy = "";
			Gotyyyy = ym.Substring(0, 4).Trim();
			
			// 指定 lblGetBookPNo 的預設訊息顯示
			string Searchym = ym.Substring(0, 4).ToString() + "/" + ym.Substring(4, 2).ToString();
			this.lblMessage.Text = "查詢之刊登年月= " + Searchym.Trim();
			this.lblGetBookPNo.Text = "";
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "bookp");
			DataView dv = ds.Tables["bookp"].DefaultView;
			
			// **注意: 原本資料庫內之 bkp_pno  是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(dbo.bookp.bkp_pno) AS bkp_pno), 否則其值會含有空白, 如 '184 ' .
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + "AND bkp_date LIKE '" + Gotyyyy + "%'";
			rowfilterstr = rowfilterstr + "AND bk_bkcd = " + BookCode;
			dv.RowFilter = rowfilterstr;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
			
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();
			
			// 變更刊登年月的格式, 是為當月, 並且以紅色顯示
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 抓出 刊登年月, Reformat
				string yyyymm = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
				DataGrid1.Items[i].Cells[1].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
				
				// 若為當月資料, 刊登年月及書籍期別顯示為紅色字體
				if(yyyymm==Currentyyyymm)  {
					// 指定該 '書籍期別' 預設值 hiddenBookPNo (為 [當月資料] 之相對應 [書籍期別] 值.)
					hiddenBookPNo.Value = DataGrid1.Items[i].Cells[2].Text;
					//Response.Write("hiddenBookPNo.Value= " + hiddenBookPNo.Value + "<br>");
					this.lblGetBookPNo.Text = "; 書籍期別= " + hiddenBookPNo.Value;
					
					DataGrid1.Items[i].Cells[1].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
					DataGrid1.Items[i].Cells[2].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
				}
				
							
				// 若抓到所填入之年月資料, 則所填入之 '刊登年月及書籍期別' 改顯示為藍色字體
				string DByyyymm = DataGrid1.Items[i].Cells[1].Text;
				DByyyymm = DByyyymm.Substring(0, 4).ToString() + DByyyymm.Substring(5, 2).ToString();
				//Response.Write("DByyyymm= " + DByyyymm + "<br>");
				if(DByyyymm==ym)  
				{
					// 指定該 '書籍期別' 預設值 hiddenBookPNo (為 [所填入年月] 之相對應 [書籍期別] 值.)
					hiddenBookPNo.Value = DataGrid1.Items[i].Cells[2].Text;
					//Response.Write("hiddenBookPNo.Value= " + hiddenBookPNo.Value + "<br>");
					this.lblGetBookPNo.Text = "; 書籍期別= " + hiddenBookPNo.Value;
					
					DataGrid1.Items[i].Cells[1].Text = "<font color=Blue>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
					DataGrid1.Items[i].Cells[2].Text = "<font color=Blue>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
				}
				
			}
			
			
		}
		

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
		}
		

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			
			// 清除已選之 ItemStyle 之設定(顏色...)
			//DataGrid1.SelectedItemStyle.Reset();
		}
		
		
		// 此功能為原本提供 搜尋不同年份用的 coding
//		private void Query_Click(object sender, System.EventArgs e)
//		{
//			// 抓出新搜尋條件 (刊登年份)
//			string yyyyQuery = "";
//			if(this.tbxQString.Text.ToString().Trim() != "")
//			{
//				yyyyQuery = this.tbxQString.Text.ToString().Trim();
//
//				//------------------------------------------------------
//				//重做一次 BindGrid() 的動作, 但給新的 RowFilter 條件
//				// 抓出書籍類別代碼
//				string BookCode;
//				if(Context.Request.QueryString["bkcd"].Trim()=="")
//					BookCode = "01";
//				else
//					BookCode = Context.Request.QueryString["bkcd"].Trim();
//				//Response.Write("BookCode= " + BookCode + "<br>");
//				//Response.Write("ThisYear+2= " + (int.Parse(ThisYear)+2) + "<br>");
//			
//				// 使用 DataSet 方法, 並指定使用的 table 名稱
//				DataSet ds = new DataSet();
//				this.sqlDataAdapter1.Fill(ds, "bookp");
//				DataView dv = ds.Tables["bookp"].DefaultView;
//
//				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
//				// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
//				string rowfilterstr = "1=1";
//				rowfilterstr = rowfilterstr + "AND bkp_date LIKE '" + yyyyQuery + "%'";
//				//rowfilterstr = rowfilterstr + "AND bkp_date >= '" + ThisYear + "%'";
//				//rowfilterstr = rowfilterstr + "AND bkp_date <= '" + (int.Parse(ThisYear)+2) + "%'";
//				rowfilterstr = rowfilterstr + "AND bk_bkcd = " + BookCode;
//				dv.RowFilter = rowfilterstr;
//			
//				// 檢查並輸出 最後 Row Filter 的結果
//				//Response.Write("dv.Count= "+ dv.Count + "<BR>");
//				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
//			
//			
//				DataGrid1.DataSource=dv;
//				DataGrid1.DataBind();
//				
//				// 檢查是否有該年份之資料, 若有, 則輸出
//				if(DataGrid1.Items.Count>0)
//				{
//					// 抓出今年的西元年份
//					string ThisYear = System.DateTime.Today.Year.ToString().Trim();
//			
//					// 變更刊登年月的格式
//					int i;
//					for(i=0; i< DataGrid1.Items.Count ; i++)
//					{
//						// 抓出 刊登年月
//						string yyyymm = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
//						DataGrid1.Items[i].Cells[1].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
//				
//						// 若為當年資料, 刊登年月顯示為紅色字體
//						if(yyyyQuery==ThisYear)  
//						{
//							DataGrid1.Items[i].Cells[1].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
//							//DataGrid1.Items[i].Cells[2].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
//						}
//					}
//				}
//					//
//				else
//				{
//					Response.Write("<font size=2 color=Red>查無此年份的資料!</font>");
//				}
//			
//			}
//			else
//			{
//				//Response.Write("<font size=2 color=red>您沒有輸入搜尋條件喔!</font><br>");
//				BindGrid();
//			}
//			//Response.Write("yyyyQuery= " + yyyyQuery + "<br>");
//			
//
//			// 清除已選之 ItemStyle 之設定(顏色...)
//			//DataGrid1.SelectedItemStyle.Reset();
//		}
		
		
//		private void Cleartbx_Click(object sender, System.EventArgs e)
//		{
//			this.tbxQString.Text = "";
//			BindGrid();
//
//			// 清除已選之 ItemStyle 之設定(顏色...)
//			//DataGrid1.SelectedItemStyle.Reset();
//		}
		
		
//		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			// 顯示 按下此挑選連結 出現之訊息
//			this.lblMessage.Text = "=> 您挑選的是: ";
//			this.lblGetBookPNo.Text = ((LinkButton)DataGrid1.SelectedItem.Cells[3].Controls[0]).Text;
//			hiddenBookPNo.Value = this.lblGetBookPNo.Text;
//
//			this.lblYYYYMM.Text = DataGrid1.SelectedItem.Cells[1].Text.ToString();
//			string yyyymm = DataGrid1.SelectedItem.Cells[1].Text.ToString();
//			// 若yyyymm值一般顏色, 則直接抓出其值; 否則, 去除 <font> 之類文字後抓出其值
//			if(yyyymm.Length==7)
//				hiddenYYYYMM.Value = yyyymm.Substring(0, 4) + yyyymm.Substring(5, 2);
//			else if(yyyymm.Length==31)
//				hiddenYYYYMM.Value = yyyymm.Substring(17, 4) + yyyymm.Substring(22, 2);
//		}
		
		
		
	}
}
