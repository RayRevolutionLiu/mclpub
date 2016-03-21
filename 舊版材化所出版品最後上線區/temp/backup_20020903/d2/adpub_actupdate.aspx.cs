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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_actupdate.
	/// </summary>
	public class adpub_actupdate : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
	
		public adpub_actupdate()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				// 呼叫 DataBinding() 
				DataBinding();
			}
		}
		

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		

		private void DataBinding()
		{
			//抓出網頁變數
			string Qstrbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
			string Qstryyyymm = Context.Request.QueryString["yyyymm"].ToString().Trim();
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c2_pub");
			DataView dv = ds.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr = "1=1";
			if(Qstrbkcd != "")
				rowfilterstr = rowfilterstr + " and (書籍類別代碼 = '" + Qstrbkcd + "')";
			else
				rowfilterstr = rowfilterstr;
			if(Qstryyyymm != "")
				rowfilterstr = rowfilterstr + " and (刊登年月 LIKE '%" + Qstryyyymm + "%')";
			else
				rowfilterstr = rowfilterstr;
			dv.RowFilter = rowfilterstr;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
//			if (dv.Count==0)
//				lblMessage.Text="查詢結果: 找不到符合條件的資料, 您可以 1.重設條件  2.新增廠商或訂戶資料";
//			else
//				lblMessage.Text="查詢結果: 找到 "+dv.Count.ToString()+"筆客戶資料";
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();
			
			
			// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 刊登年月
				string yyyymm = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
				DataGrid1.Items[i].Cells[3].Text = yyyymm;
				
				// 廣告色彩 / 廣告篇幅 / 廣告版面
				string ClrName = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
				string PgsizeName = DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
				string LtpName = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
				//Response.Write("ClrName=" + ClrName + ", ");
				//Response.Write("PgsizeName=" + PgsizeName + ", ");
				//Response.Write("LtpName=" + LtpName + "<br>");
				if(ClrName == "不知")
				{
					DataGrid1.Items[i].Cells[5].Text = "<font color=DarkRed>" + ClrName + "<font>";
				}
				else
				{
					DataGrid1.Items[i].Cells[5].Text = ClrName;
				}
				
				if(PgsizeName == "不知")
				{
					DataGrid1.Items[i].Cells[6].Text = "<font color=DarkRed>" + PgsizeName + "<font>";
				}
				else
				{
					DataGrid1.Items[i].Cells[6].Text = PgsizeName;
				}
				
				if(LtpName == "不知")
				{
					DataGrid1.Items[i].Cells[7].Text = "<font color=DarkRed>" + LtpName + "<font>";
				}
				else
				{
					DataGrid1.Items[i].Cells[7].Text = LtpName;
				}
				
				
				// 固定頁次註記
				string fgFixPg = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
				if(fgFixPg=="1")
                    DataGrid1.Items[i].Cells[8].Text = "<font color=Red>是</font>";
				else
					DataGrid1.Items[i].Cells[8].Text = "否";
				

				// 到稿註記
				string fgGot = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				if(fgGot=="1")
					DataGrid1.Items[i].Cells[11].Text = "是";
				else
					DataGrid1.Items[i].Cells[11].Text = "<font color=Red>否</font>";
				

				// 改稿相關欄位
				string Chgbkcd = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
				string Chgjno = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				string Chgjbkno = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
				string fgReChg = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
				if(Chgbkcd == "01" || Chgbkcd == "02")
				{
					// 將 改稿書籍代碼 改為文字顯示
					if(Chgbkcd == "01")
						DataGrid1.Items[i].Cells[12].Text = "工材雜誌";
					else if(Chgbkcd == "02")
						DataGrid1.Items[i].Cells[12].Text = "電材雜誌";

					// 將 改稿重出片註記 改為文字顯示
					if(fgReChg == "0")
						DataGrid1.Items[i].Cells[15].Text = "<font color=Red>是</font>";
					else
						DataGrid1.Items[i].Cells[15].Text = "否";

					// 清除新稿/舊稿資料
					DataGrid1.Items[i].Cells[11].Text = "";
					DataGrid1.Items[i].Cells[16].Text = "";
					DataGrid1.Items[i].Cells[17].Text = "";
					DataGrid1.Items[i].Cells[18].Text = "";
				}
				else
				{
					// 若非改稿, 則清除其改稿資料
					DataGrid1.Items[i].Cells[12].Text = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					Chgjno = "";
					Chgjbkno = "";
					fgReChg= "";
					DataGrid1.Items[i].Cells[13].Text = Chgjno;
					DataGrid1.Items[i].Cells[14].Text = Chgjbkno;
					DataGrid1.Items[i].Cells[15].Text = fgReChg;
				}
				

				// 舊稿相關欄位
				string Origbkcd = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
				string Origjno = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
				string Origjbkno = DataGrid1.Items[i].Cells[18].Text.ToString().Trim();
//				if(Origbkcd == "01" || Origbkcd == "02")
//				{
//				}
//				else
//				{
//					DataGrid1.Items[i].Cells[16].Text = "";
//					DataGrid1.Items[i].Cells[17].Text = "";
//					DataGrid1.Items[i].Cells[18].Text = "";
//				}

				
			// 結束 for(i=0; i< DataGrid1.Items.Count ; i++)
			}
			
			
		}

		protected object GetfgUpdate(object fgupdate)
		{
			bool strReturn = false;
			if(fgupdate.ToString().Trim() == "1")
				strReturn = true;
			return strReturn;
		}
		

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																				new System.Data.Common.DataColumnMapping("頁次", "頁次"),
																																																				new System.Data.Common.DataColumnMapping("合約書編號", "合約書編號"),
																																																				new System.Data.Common.DataColumnMapping("落版序號", "落版序號"),
																																																				new System.Data.Common.DataColumnMapping("刊登年月", "刊登年月"),
																																																				new System.Data.Common.DataColumnMapping("刊登頁碼", "刊登頁碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告色彩代碼", "廣告色彩代碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告版面代碼", "廣告版面代碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告篇幅代碼", "廣告篇幅代碼"),
																																																				new System.Data.Common.DataColumnMapping("固定頁次註記", "固定頁次註記"),
																																																				new System.Data.Common.DataColumnMapping("到稿註記", "到稿註記"),
																																																				new System.Data.Common.DataColumnMapping("落版業務員工號", "落版業務員工號"),
																																																				new System.Data.Common.DataColumnMapping("備註", "備註"),
																																																				new System.Data.Common.DataColumnMapping("舊稿書籍代碼", "舊稿書籍代碼"),
																																																				new System.Data.Common.DataColumnMapping("舊稿期別", "舊稿期別"),
																																																				new System.Data.Common.DataColumnMapping("舊稿頁碼", "舊稿頁碼"),
																																																				new System.Data.Common.DataColumnMapping("改稿書籍代碼", "改稿書籍代碼"),
																																																				new System.Data.Common.DataColumnMapping("改稿期別", "改稿期別"),
																																																				new System.Data.Common.DataColumnMapping("改稿頁碼", "改稿頁碼"),
																																																				new System.Data.Common.DataColumnMapping("改稿重出片註記", "改稿重出片註記"),
																																																				new System.Data.Common.DataColumnMapping("新稿製法代碼", "新稿製法代碼"),
																																																				new System.Data.Common.DataColumnMapping("公司名稱", "公司名稱"),
																																																				new System.Data.Common.DataColumnMapping("版面2", "版面2"),
																																																				new System.Data.Common.DataColumnMapping("書籍類別代碼", "書籍類別代碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告色彩", "廣告色彩"),
																																																				new System.Data.Common.DataColumnMapping("廣告版面", "廣告版面"),
																																																				new System.Data.Common.DataColumnMapping("廣告篇幅", "廣告篇幅"),
																																																				new System.Data.Common.DataColumnMapping("新稿製法", "新稿製法"),
																																																				new System.Data.Common.DataColumnMapping("舊稿書籍名稱", "舊稿書籍名稱"),
																																																				new System.Data.Common.DataColumnMapping("落版業務員姓名", "落版業務員姓名"),
																																																				new System.Data.Common.DataColumnMapping("稿件類別代碼", "稿件類別代碼"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("美編樣後修改註記", "美編樣後修改註記")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT c2_pub.pub_pubid AS ID, 0 AS 頁次, RTRIM(c2_pub.pub_contno) AS 合約書編號, RTRIM(" +
				"c2_pub.pub_pubseq) AS 落版序號, RTRIM(c2_pub.pub_yyyymm) AS 刊登年月, c2_pub.pub_pgno AS" +
				" 刊登頁碼, RTRIM(c2_pub.pub_clrcd) AS 廣告色彩代碼, RTRIM(c2_pub.pub_pgscd) AS 廣告版面代碼, RTR" +
				"IM(c2_pub.pub_ltpcd) AS 廣告篇幅代碼, RTRIM(c2_pub.pub_fgfixpg) AS 固定頁次註記, RTRIM(c2_pu" +
				"b.pub_fggot) AS 到稿註記, RTRIM(c2_pub.pub_modempno) AS 落版業務員工號, RTRIM(c2_pub.pub_re" +
				"mark) AS 備註, RTRIM(c2_pub.pub_origbkcd) AS 舊稿書籍代碼, RTRIM(c2_pub.pub_origjno) AS " +
				"舊稿期別, RTRIM(c2_pub.pub_origjbkno) AS 舊稿頁碼, RTRIM(c2_pub.pub_chgbkcd) AS 改稿書籍代碼, " +
				"RTRIM(c2_pub.pub_chgjno) AS 改稿期別, RTRIM(c2_pub.pub_chgjbkno) AS 改稿頁碼, RTRIM(c2_p" +
				"ub.pub_fgrechg) AS 改稿重出片註記, RTRIM(c2_pub.pub_njtpcd) AS 新稿製法代碼, RTRIM(mfr.mfr_in" +
				"m) AS 公司名稱, 8 AS 版面2, RTRIM(c2_pub.pub_bkcd) AS 書籍類別代碼, RTRIM(c2_clr.clr_nm) AS " +
				"廣告色彩, RTRIM(c2_ltp.ltp_nm) AS 廣告版面, RTRIM(c2_pgsize.pgs_nm) AS 廣告篇幅, RTRIM(c2_nj" +
				"tp.njtp_nm) AS 新稿製法, RTRIM(book.bk_nm) AS 舊稿書籍名稱, RTRIM(srspn.srspn_cname) AS 落版" +
				"業務員姓名, RTRIM(c2_pub.pub_drafttp) AS 稿件類別代碼, c2_pub.pub_contno, c2_pub.pub_pubseq" +
				", c2_pub.pub_syscd, c2_pub.pub_yyyymm, c2_pub.pub_fgupdated AS 美編樣後修改註記 FROM c2_" +
				"pub INNER JOIN c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND c2_pub.pub" +
				"_syscd = c2_cont.cont_syscd INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno" +
				" LEFT OUTER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN c" +
				"2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN c2_ltp ON c2_" +
				"pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN c2_njtp ON c2_pub.pub_njtpcd = " +
				"c2_njtp.njtp_njtpcd LEFT OUTER JOIN book ON c2_pub.pub_origbkcd = book.bk_bkcd L" +
				"EFT OUTER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno ORDER BY 刊登頁碼, 合約" +
				"書編號, 刊登年月 DESC, 落版序號";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			// 抓出各行 美編樣後修改註記 之值
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{ 
				// 抓出 c2_pub 之 PK
				string strSyscd = "C2";
				string strContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
				string strYYYYMM = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				string strPubSeq = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				//Response.Write("syscd= " + strSyscd + "," );
				//Response.Write("ContNo=" + strContNo + "," );
				//Response.Write("yyyymm=" + strYYYYMM + "," );
				//Response.Write("pubseq=" + strPubSeq + "," );
				
				// 抓出 ItemTemplate 之 CheckBox 型態之 cbxUpdate (Controls[1])
				string strfgUpdate = ((CheckBox)DataGrid1.Items[i].Cells[21].Controls[1]).Checked.ToString();
				//Response.Write("美編樣後修改註記= " + ((CheckBox)DataGrid1.Items[i].Cells[21].Controls[1]).Checked.ToString() + "<br>");
				//Response.Write("strfgUpdate= " + strfgUpdate + "<br>");
				
				// 執行 更新 sqlcmd
				string sqlcmd1 = "";
				// 確認 myCommand 之更新指令內容 - sqlcmd1: 定義在 for loop 之前
				sqlcmd1 = " UPDATE c2_pub ";

				// 若  美編樣後修改註記 有勾選, 則更新其值
				if(strfgUpdate == "True")
				{
					//Response.Write("True, update sql table...<br>");
					
//					// 執行 更新 sqlcmd
//					string sqlcmd1 = "";
//					// 確認 myCommand 之更新指令內容 - sqlcmd1: 定義在 for loop 之前
//					sqlcmd1 = " UPDATE c2_pub ";
					sqlcmd1 = sqlcmd1 + " SET pub_fgupdated = 1";
					
				}
				else
				{
					//Response.Write("False, do nothing~<br>");
					sqlcmd1 = sqlcmd1 + " SET pub_fgupdated = 0";
				}
				
				sqlcmd1 = sqlcmd1 + " WHERE (pub_syscd = '" + strSyscd + "') AND (pub_contno = '" + strContNo + "') AND (pub_yyyymm = '" + strYYYYMM + "') AND (pub_pubseq = '" + strPubSeq + "')";
				//Response.Write("sqlcmd1= " + sqlcmd1 + "<br><br>");
						
				// 執行 myCommand (myCommand 是執行 sqlCommand1: sp_c2_adpub_act3_pub ) 更新資料庫: 落版 資料 c2_pub
				SqlCommand myCommand = new SqlCommand(sqlcmd1, sqlConnection1);
				myCommand.Connection = sqlConnection1;
				myCommand.Connection.Open();
				bool ResultFlag1;
				try
				{
					myCommand.ExecuteNonQuery();
					ResultFlag1=true;
				}
				catch(System.Data.SqlClient.SqlException ex1)
				{
					ResultFlag1=false;
					Response.Write(ex1.Message + "<br>");
				}
				finally
				{
					this.sqlConnection1.Close();
				}
				
				// 輸出執行結果
				if(ResultFlag1)
				{
					//Response.Write("更新美編樣後註記成功!<br>");
				}
				else  
				{
					//Response.Write("更新美編樣後註記失敗!<br>");
				}
				
				
			// 結束 for loop
			}
			
		}
		

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// 取消回首頁
			Response.Redirect("/mrlpub/");
		}
		
		
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
		}
		
		
		// 換頁時的處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
		}
		
		
	}
}
