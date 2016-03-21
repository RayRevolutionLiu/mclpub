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
	/// Summary description for adpub_act1.
	/// </summary>
	public class adpub_act1 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label lblMemo;
	
		public adpub_act1()
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
				
				
				// 給 截止年月 tbxYYYYMM 預設值 (今天年月)
				this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
				
				// 書籍類別給預設值
				//this.ddlBookCode.SelectedItem.Value = "00";
				
				// 清空查詢結果的訊息
				lblMessage.Text = "";
				
				
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
		
		
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 清除 DataGrid1
			DataGrid1.Visible = false;
			DataGrid2.Visible = false;
			//DataGrid3.Visible = false;
			
			
			// 檢查 刊登年月是否沒輸入資料
			if(this.tbxPubDate.Text.ToString().Trim() == "")
			{
				lblMessage.Text = "刊登年月不允許空白, 請填資料 (預設填上 系統年月)!";
				this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
			}
			else
			{
				// 檢查是否有資料不合理 - 該落版之無廣告優先次序
				CheckLPriorSeqisNull();
				
				// 檢查是否有資料不合理 - 該落版(特殊版面)的刊登頁碼為 0 (因特殊版面皆為固定頁次, 故不允許此)
				CheckSpecialPgNo();
			}
		}
		
		
		// 檢查是否有資料不合理 - 該落版之無廣告優先次序
		private void CheckLPriorSeqisNull()
		{
			// 抓出 網頁變數
			string bkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
			yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_pub");
			DataView dv3 = ds3.Tables["c2_pub"].DefaultView;
				
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND pub_bkcd = '" + bkcd + "'";
			rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm = '" + yyyyymm + "'";
			rowfilterstr3 = rowfilterstr3 + " AND (lp_priorseq IS NULL)";
			dv3.RowFilter = rowfilterstr3;
				
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
				
			// 若有資料須修正時, 顯示 DataGrid1
			if(dv3.Count > 0)
			{
				this.lblMessage.Text = "很抱歉, 您必須修正：１．以下 " + dv3.Count + " 筆不合理的資料項(廣告優先次序未指定或不合理), 才能繼續進行排版動作!<br>２．全部修正完, 請再按一次 '查詢' 按鈕來繼續進行排版!";
				BindGrid1();
			}
			else
			{
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c2_pub");
				DataView dv1 = ds1.Tables["c2_pub"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
				string rowfilterstr1 = "1=1";
				
				// 若書籍類別有選擇(即<>00)的話, 則給予 SQL Filter 條件
				if(ddlBookCode.SelectedItem.Value.ToString() != "")
					rowfilterstr1 = rowfilterstr1 + " and (pub_bkcd = '" + bkcd + "')";
				else
					rowfilterstr1 = rowfilterstr1;
				
				// 刊登年月, 則給予 SQL Filter 條件
				rowfilterstr1 = rowfilterstr1 + " and (pub_yyyymm like '%" + yyyyymm +"%')";
				dv1.RowFilter = rowfilterstr1;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv.Count= "+ dv.Count + "<BR>");
				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找不到" 的處理
				if (dv1.Count==0)
					lblMessage.Text="結果: 找不到符合條件的資料, 您可以重設條件!";
				else
				{
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("rowfilterstr= " + rowfilterstr + "<BR>");
					
					// 抓出下一步驟要轉址到什處去?  (因此網頁由 2.3.1 & 2.3.2 共用)
					// action=1 => 2.3.1 廣告落版動作; action=2 => 2.3.2 美編樣後修正
					string RedirectURL = "";
					if(Context.Request.QueryString["action"]=="1")
						RedirectURL = "adpub_act2.aspx?bkcd=" + bkcd + "&yyyymm=" + yyyyymm;
					else if(Context.Request.QueryString["action"]=="2")
						RedirectURL = "adpub_actupdate.aspx?bkcd=" + bkcd + "&yyyymm=" + yyyyymm;
					
					//Response.Write("dv.Count= "+ dv.Count + "<BR>");
					lblMessage.Text="結果: 找到 <B>" + dv1.Count.ToString() + "</B>筆資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_self'>此連結</A> 來繼續進行下一動作!<br>";
					
					//DataGrid1.DataSource=dv;
					//DataGrid1.DataBind();
				}
			}
		}
		
		
		private void BindGrid1()
		{
			// 顯示 DataGrid1
			DataGrid1.Visible = true;
			
			// 抓出 網頁變數
			string bkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
			string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
			yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_pub");
			DataView dv3 = ds3.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND pub_bkcd = '" + bkcd + "'";
			rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm = '" + yyyyymm + "'";
			rowfilterstr3 = rowfilterstr3 + " AND (lp_priorseq IS NULL) ";
			dv3.RowFilter = rowfilterstr3;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若有資料須修正時, 顯示 DataGrid1
			if(dv3.Count > 0)
			{
				DataGrid1.DataSource=dv3;
				DataGrid1.DataBind();
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 廣告版面
					string strltpcd =  DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
					string strLtpName = "";
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds5 = new DataSet();
					this.sqlDataAdapter5.Fill(ds5, "c2_ltp");
					DataView dv5 = ds5.Tables["c2_ltp"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr5 = "1=1";
					rowfilterstr5 = rowfilterstr5 + " AND ltp_ltpcd='" + strltpcd + "'";
					dv5.RowFilter = rowfilterstr5;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
					//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
					
					if(dv5.Count > 0)
					{
						// 抓出相對應的 名稱
						strLtpName = dv5[0]["ltp_nm"].ToString().Trim();
						DataGrid1.Items[i].Cells[2].Text = strLtpName;
					}
					
					
					// 廣告色彩
					string strclrcd =  DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
					string strClrName = "";
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "c2_clr");
					DataView dv4 = ds4.Tables["c2_clr"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr4 = "1=1";
					rowfilterstr4 = rowfilterstr4 + " AND clr_clrcd='" + strclrcd + "'";
					dv4.RowFilter = rowfilterstr4;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
					if(dv4.Count > 0)
					{
						// 抓出相對應的 名稱
						strClrName = dv4[0]["clr_nm"].ToString().Trim();
						DataGrid1.Items[i].Cells[3].Text = strClrName;
					}
					
					
					// 廣告篇幅
					string strpgscd =  DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
					string strPgsName = "";
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds6 = new DataSet();
					this.sqlDataAdapter6.Fill(ds6, "c2_pgsize");
					DataView dv6 = ds6.Tables["c2_pgsize"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr6 = "1=1";
					rowfilterstr6 = rowfilterstr6 + " AND pgs_pgscd='" + strpgscd + "'";
					dv6.RowFilter = rowfilterstr6;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
					if(dv6.Count > 0)
					{
						// 抓出相對應的 名稱
						strPgsName = dv6[0]["pgs_nm"].ToString().Trim();
						DataGrid1.Items[i].Cells[4].Text = strPgsName;
					}
					
					
					// 到稿註記
					string strfgGot =  DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
					string strfgGotText = "";
					if(strfgGot == "1")
						strfgGotText = "<font color='Red'>否</font>";
					else
						strfgGotText = "是";
					DataGrid1.Items[i].Cells[5].Text = strfgGotText;
					
					
					// 稿件類別
					string strDrafttp =  DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
					switch(strDrafttp)
					{
						case "1":
							DataGrid1.Items[i].Cells[6].Text = "舊稿";
							break;
						case "2":
							DataGrid1.Items[i].Cells[6].Text = "新稿";
							break;
						case "3":
							DataGrid1.Items[i].Cells[6].Text = "改稿";
							break;
						default:
							break;
					}
					
					
					// 前往修改 的按鈕 - 見 DataGrid1_ItemCommand()
				
				// 結束 for loop
				}
				
			// 結束 if(dv3.Count > 0)
			}
		}
		
		
		// 檢查是否有資料不合理 - 該落版(特殊版面)的刊登頁碼為 0 (因特殊版面皆為固定頁次, 故不允許此)
		private void CheckSpecialPgNo()
		{
			// 抓出 網頁變數
			string bkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
			string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
			yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_pub");
			DataView dv3 = ds3.Tables["c2_pub"].DefaultView;
				
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_bkcd = '" + bkcd + "')";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_yyyymm = '" + yyyyymm + "')";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_ltpcd = '50')";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_pgno = 0)";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_fgfixpg = '1')";
			dv3.RowFilter = rowfilterstr3;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若有資料須修正時, 顯示 DataGrid1
			if(dv3.Count > 0)
			{
				this.lblMessage.Text = "很抱歉, 您必須修正：１．以下 " + dv3.Count + " 筆不合理的資料項<br>(一般版面資料若為 '固定頁次(是)', 其'刊登頁碼'不允許為0), <br>&nbsp;&nbsp;才能繼續進行排版動作!<br>２．全部修正完, 請再按一次 '查詢' 按鈕來繼續進行排版!";
				BindGrid2();
			}
		}
		
		
		private void BindGrid2()
		{
			// 顯示 DataGrid2
			DataGrid2.Visible = true;
			
			
			// 抓出 網頁變數
			string bkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
			string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
			yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_pub");
			DataView dv3 = ds3.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND pub_bkcd = '" + bkcd + "'";
			rowfilterstr3 = rowfilterstr3 + " AND pub_yyyymm = '" + yyyyymm + "'";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_ltpcd = '50')";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_pgno = 0)";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_fgfixpg = '1')";
			dv3.RowFilter = rowfilterstr3;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若有資料須修正時, 顯示 DataGrid1
			if(dv3.Count > 0)
			{
				DataGrid2.DataSource=dv3;
				DataGrid2.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid2.Items.Count ; i++)
				{
					// 刊登年月
					string strYYYYMM =  DataGrid2.Items[i].Cells[1].Text.ToString().Trim();
					strYYYYMM = strYYYYMM.Substring(0, 4) + "/" + strYYYYMM.Substring(4, 2);
					DataGrid2.Items[i].Cells[1].Text = strYYYYMM;
					
					
					// 固定頁次註記
					string strfixpg =  DataGrid2.Items[i].Cells[4].Text.ToString().Trim();
					if(strfixpg == "0")
						DataGrid2.Items[i].Cells[4].Text = "否";
					else
						DataGrid2.Items[i].Cells[4].Text = "是";
					
					
					// 廣告版面
					string strltpcd =  DataGrid2.Items[i].Cells[5].Text.ToString().Trim();
					string strLtpName = "";
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds5 = new DataSet();
					this.sqlDataAdapter5.Fill(ds5, "c2_ltp");
					DataView dv5 = ds5.Tables["c2_ltp"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr5 = "1=1";
					rowfilterstr5 = rowfilterstr5 + " AND ltp_ltpcd='" + strltpcd + "'";
					dv5.RowFilter = rowfilterstr5;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
					//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
					
					if(dv5.Count > 0)
					{
						// 抓出相對應的 名稱
						strLtpName = dv5[0]["ltp_nm"].ToString().Trim();
						DataGrid2.Items[i].Cells[5].Text = strLtpName;
					}
					
					
					// 廣告色彩
					string strclrcd =  DataGrid2.Items[i].Cells[6].Text.ToString().Trim();
					string strClrName = "";
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "c2_clr");
					DataView dv4 = ds4.Tables["c2_clr"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr4 = "1=1";
					rowfilterstr4 = rowfilterstr4 + " AND clr_clrcd='" + strclrcd + "'";
					dv4.RowFilter = rowfilterstr4;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
					if(dv4.Count > 0)
					{
						// 抓出相對應的 名稱
						strClrName = dv4[0]["clr_nm"].ToString().Trim();
						DataGrid2.Items[i].Cells[6].Text = strClrName;
					}
					
					
					// 廣告篇幅
					string strpgscd =  DataGrid2.Items[i].Cells[7].Text.ToString().Trim();
					string strPgsName = "";
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds6 = new DataSet();
					this.sqlDataAdapter6.Fill(ds6, "c2_pgsize");
					DataView dv6 = ds6.Tables["c2_pgsize"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr6 = "1=1";
					rowfilterstr6 = rowfilterstr6 + " AND pgs_pgscd='" + strpgscd + "'";
					dv6.RowFilter = rowfilterstr6;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
					if(dv6.Count > 0)
					{
						// 抓出相對應的 名稱
						strPgsName = dv6[0]["pgs_nm"].ToString().Trim();
						DataGrid2.Items[i].Cells[7].Text = strPgsName;
					}
					
					
					// 到稿註記
					string strfgGot =  DataGrid2.Items[i].Cells[8].Text.ToString().Trim();
					string strfgGotText = "";
					if(strfgGot == "1")
						strfgGotText = "<font color='Red'>否</font>";
					else
						strfgGotText = "是";
					DataGrid2.Items[i].Cells[8].Text = strfgGotText;
					
					
					// 稿件類別
					string strDrafttp =  DataGrid2.Items[i].Cells[9].Text.ToString().Trim();
					switch(strDrafttp)
					{
						case "1":
							DataGrid2.Items[i].Cells[9].Text = "舊稿";
							break;
						case "2":
							DataGrid2.Items[i].Cells[9].Text = "新稿";
							break;
						case "3":
							DataGrid2.Items[i].Cells[9].Text = "改稿";
							break;
						default:
							break;
					}
					
					
					// 前往修改 的按鈕 - 見 DataGrid1_ItemCommand()
				
					// 結束 for loop
				}
			
				// 結束 if(dv3.Count > 0)
			}
		}
		
		
		// 修改落版資料 的按鈕
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			
			if(e.CommandName=="Select")
			{
				// 抓出 落版 PK, 以轉址到 修改落版 畫面
				//string Syscd = "C2";
				string ContNo = e.Item.Cells[0].Text.ToString().Trim();
				string YYYYMM = this.tbxPubDate.Text.ToString().Trim();
				YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
				string PubSeq = e.Item.Cells[1].Text.ToString().Trim();
				string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
				//Response.Write("Syscd= " + Syscd + ", ");
				//Response.Write("ContNo= " + ContNo + ", ");
				//Response.Write("YYYYMM= " + YYYYMM + ", ");
				//Response.Write("PubSeq= " + PubSeq + ", ");
				//Response.Write("strBkcd= " + strBkcd + "<br>");
				
				// 轉址動作
				strbuf = "PubFm.aspx?contno=" + ContNo + "&bkcd=" + strBkcd + "&fgnew=1";
				//Response.Write("strbuf= " + strbuf + "<br>");
				//Response.Redirect(strbuf);
				
				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl Literal1 = new LiteralControl();
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\",null,\"top=30,left=30,height=480,width=730,status=no,scrollbars=yes,toolbar=no,menubar=no,\");</script>";
				Page.Controls.Add(Literal1);
			}
		}
		
		
		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid2.SelectedIndex=e.Item.ItemIndex;
			
			if(e.CommandName=="Select")
			{
				// 抓出 落版 PK, 以轉址到 修改落版 畫面
				//string Syscd = "C2";
				string ContNo = e.Item.Cells[0].Text.ToString().Trim();
				string YYYYMM = this.tbxPubDate.Text.ToString().Trim();
				YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
				string PubSeq = e.Item.Cells[1].Text.ToString().Trim();
				string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
				//Response.Write("Syscd= " + Syscd + ", ");
				//Response.Write("ContNo= " + ContNo + ", ");
				//Response.Write("YYYYMM= " + YYYYMM + ", ");
				//Response.Write("PubSeq= " + PubSeq + ", ");
				//Response.Write("strBkcd= " + strBkcd + "<br>");
				
				// 轉址動作
				strbuf = "PubFm.aspx?contno=" + ContNo + "&bkcd=" + strBkcd + "&fgnew=1";
				//Response.Write("strbuf= " + strbuf + "<br>");
				//Response.Redirect(strbuf);
				
				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl Literal1 = new LiteralControl();
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\",null,\"top=30,left=30,height=480,width=730,status=no,scrollbars=yes,toolbar=no,menubar=no,\");</script>";
				Page.Controls.Add(Literal1);
			}
		}
		
		
		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("adpub_act1.aspx?action=" + Context.Request.QueryString["action"]);
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgact", "pub_fgact"),
																																																				new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd")})});
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
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("PageNo", "PageNo"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				new System.Data.Common.DataColumnMapping("layout2", "layout2"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno1", "pub_contno1"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq1", "pub_pubseq1"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm1", "pub_yyyymm1"),
																																																				new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd")})});
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgsize", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm")})});
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT pgs_pgscd, pgs_nm FROM dbo.c2_pgsize";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT ltp_ltpcd, ltp_nm FROM dbo.c2_ltp";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_clr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT clr_clrcd, clr_nm FROM dbo.c2_clr";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c2_pub.pub_pgno AS PageNo, RTRIM(dbo.c2_pub.pub_contno) AS pub_contno," +
				" RTRIM(dbo.c2_pub.pub_pubseq) AS pub_pubseq, RTRIM(dbo.c2_pub.pub_yyyymm) AS pub" +
				"_yyyymm, dbo.c2_pub.pub_pgno AS pub_pgno, RTRIM(dbo.c2_pub.pub_ltpcd) AS pub_ltp" +
				"cd, RTRIM(dbo.c2_pub.pub_clrcd) AS pub_clrcd, RTRIM(dbo.c2_pub.pub_pgscd) AS pub" +
				"_pgscd, RTRIM(dbo.c2_pub.pub_fgfixpg) AS pub_fgfixpg, RTRIM(dbo.c2_pub.pub_fggot" +
				") AS pub_fggot, RTRIM(dbo.c2_pub.pub_modempno) AS pub_modempno, RTRIM(dbo.c2_pub" +
				".pub_remark) AS pub_remark, RTRIM(dbo.c2_pub.pub_origbkcd) AS pub_origbkcd, RTRI" +
				"M(dbo.c2_pub.pub_origjno) AS pub_origjno, RTRIM(dbo.c2_pub.pub_origjbkno) AS pub" +
				"_origjbkno, RTRIM(dbo.c2_pub.pub_chgbkcd) AS pub_chgbkcd, RTRIM(dbo.c2_pub.pub_c" +
				"hgjno) AS pub_chgjno, RTRIM(dbo.c2_pub.pub_chgjbkno) AS pub_chgjbkno, RTRIM(dbo." +
				"c2_pub.pub_fgrechg) AS pub_fgrechg, RTRIM(dbo.c2_pub.pub_njtpcd) AS pub_njtpcd, " +
				"RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, 8 AS layout2, RTRIM(dbo.c2_pub.pub_bkcd) AS p" +
				"ub_bkcd, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm," +
				" RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm, R" +
				"TRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, RTRI" +
				"M(dbo.c2_pub.pub_drafttp) AS pub_drafttp, dbo.c2_pub.pub_contno AS pub_contno, d" +
				"bo.c2_pub.pub_pubseq AS pub_pubseq, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm " +
				"AS pub_yyyymm, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_bkcd, dbo.c2_cont.con" +
				"t_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont" +
				"_fgpubed, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.c2_pub INNER " +
				"JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_p" +
				"ub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfr" +
				"no = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2" +
				"_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pu" +
				"b.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_" +
				"bkcd LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd L" +
				"EFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd L" +
				"EFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OU" +
				"TER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUT" +
				"ER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN d" +
				"bo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.co" +
				"nt_fgtemp = \'0\') AND (dbo.c2_cont.cont_fgpubed = \'1\') ORDER BY dbo.c2_lprior.lp_" +
				"priorseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo" +
				".c2_pub.pub_pubseq";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_pgno, dbo.c2_lprior.lp_priorseq, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_drafttp, dbo.c2_pub.pub_imseq, dbo.c2_pub.pub_fgfixpg, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, dbo.c2_lprior.lp_bkcd, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno LEFT OUTER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pub.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd WHERE (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
