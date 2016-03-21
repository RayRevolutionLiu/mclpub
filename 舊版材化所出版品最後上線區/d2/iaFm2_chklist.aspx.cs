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
	/// Summary description for iaFm2_chklist.
	/// </summary>
	public class iaFm2_chklist : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Web.UI.WebControls.Button btnAddIA;
		protected System.Web.UI.WebControls.Label lblSubTotalAmt;
		protected System.Web.UI.WebControls.TextBox tbxIAStatus;
		protected System.Web.UI.WebControls.Panel pnlChklist;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label lblChklist;
		protected System.Web.UI.WebControls.Label lblContAmtCount;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblContSubTotalAmt;
		protected System.Web.UI.WebControls.TextBox tbxContSubTotalAmt;
		protected System.Web.UI.WebControls.Panel pnlContAmtCount;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblRecordCount;
	
		public iaFm2_chklist()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
							
				
				// 顯示資料
				InitialData();
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		private void InitialData()
		{
			this.pnlChklist.Visible = true;
			this.pnlContAmtCount.Visible = true;
			
			BindGrid1();
			BindGrid2();
		}
		
		
		// 返回首頁 按鈕
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("../default.aspx");
		}
		
		
		// 顯示 DataGrid1 的資料項
		private void BindGrid1()
		{
			// 抓出 QueryString
			string strBkcd = Context.Request.QueryString["bkcd"].Trim();
			string strYYYYMM = Context.Request.QueryString["yyyymm"].Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			this.sqlDataAdapter1.SelectCommand.Parameters["@bkcd"].Value = strBkcd;
			this.sqlDataAdapter1.SelectCommand.Parameters["@yyyymm"].Value = strYYYYMM;
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			rowfilterstr1 = rowfilterstr1 + " AND cont_syscd = 'C2' ";
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
				
				// 顯示總筆數
				this.lblRecordCount.Text = "目前已挑選的, 共有 " + dv1.Count.ToString().Trim() + " 筆落版資料!<br>";
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int Adamt = 0, SubTotalAmt = 0;
				for(int i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 發票類別
					string invcd = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
					if(invcd != "")  
					{
						if(invcd == "1")
						{
							DataGrid1.Items[i].Cells[7].Text = "(不詳)";
						}
						if(invcd == "2")
						{
							DataGrid1.Items[i].Cells[7].Text = "二聯式";
						}
						if(invcd == "3")
						{
							DataGrid1.Items[i].Cells[7].Text = "三聯式";
						}
						if(invcd == "4")
						{
							DataGrid1.Items[i].Cells[7].Text = "<font color=blue>其他</font>";
						}
						if(invcd == "9")
						{
							DataGrid1.Items[i].Cells[7].Text = "<font color=Red>不清楚</font>";
						}
					}
					else  
					{
						DataGrid1.Items[i].Cells[7].Text = "<font color=red>(無資料)</font>";
					}
					
					
					// 發票課稅別
					string taxtp = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					if(taxtp != "")  
					{
						if(taxtp == "1")
						{
							DataGrid1.Items[i].Cells[8].Text = "應稅";
						}
						if(taxtp == "2")
						{
							DataGrid1.Items[i].Cells[8].Text = "<font color=darkred>零稅</font>";
						}
						if(taxtp == "3")
						{
							DataGrid1.Items[i].Cells[8].Text = "<font color=red>免稅</font>";
						}
						if(taxtp == "9")
						{
							DataGrid1.Items[i].Cells[8].Text = "<font color=red>不清楚</font>";
						}
					}
					else  
					{
						DataGrid1.Items[i].Cells[8].Text = "<font color=red>(無資料)</font>";
					}
					
					// (廣告) 金額
					Adamt = Convert.ToInt32(DataGrid1.Items[i].Cells[15].Text.ToString().Trim());
					//Response.Write("Adamt= " + Adamt + "<br>");
					SubTotalAmt = SubTotalAmt + Adamt;
				}
				
				// 抓出 小計
				this.lblSubTotalAmt.Text = "小計：$" + Convert.ToString(SubTotalAmt);
			}
			else
			{
				this.lblRecordCount.Text = "查無資料!";
				this.pnlChklist.Visible = false;
				this.pnlContAmtCount.Visible = false;
			}
		}
		
		
		// 載入 開立金額確認區
		private void BindGrid2()
		{
			// 抓出 QueryString
			string strBkcd = Context.Request.QueryString["bkcd"].Trim();
			string strYYYYMM = Context.Request.QueryString["yyyymm"].Trim();
			string strSort = Context.Request.QueryString["sort"].Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strSort= " + strSort + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			this.sqlDataAdapter3.SelectCommand.Parameters["@bkcd"].Value = strBkcd;
			this.sqlDataAdapter3.SelectCommand.Parameters["@yyyymm"].Value = strYYYYMM;
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_cont");
			DataView dv3 = ds3.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			dv3.RowFilter = rowfilterstr3;
			
			// Order by Filter
			if(strSort == "1")
			{
				dv3.Sort = "cont_contno";
			}
			else if(strSort == "2")
			{
				dv3.Sort = "cont_empno";
			}
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找到" 的處理
			if (dv3.Count > 0)
			{
				//this.lblMessage.Text = "共有 " + dv3.Count + " 筆落版資料尚未產生發票開立單!";
				DataGrid2.DataSource = dv3;
				DataGrid2.DataBind();
			
				
				string TotAdAmt = "0", TotChgAmt = "0", TotAmt = "0";
				int SubTotalAmt = 0;
				for(int j=0; j < DataGrid2.Items.Count; j++)
				{
					// 抓出 當月廣告總額 & 當月換稿總額
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					this.sqlDataAdapter4.SelectCommand.Parameters["@bkcd"].Value = strBkcd;
					this.sqlDataAdapter4.SelectCommand.Parameters["@yyyymm"].Value = strYYYYMM;
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "c2_cont");
					DataView dv4 = ds4.Tables["c2_cont"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr4 = "1=1";
					dv4.RowFilter = rowfilterstr4;
					
					// 逐一計算
					if(dv4.Count > 0)
					{
						TotAdAmt = dv4[j]["TotAdAmt"].ToString().Trim();
						TotChgAmt = dv4[j]["TotChgAmt"].ToString().Trim();
						TotAmt = dv4[j]["TotAmt"].ToString().Trim();
						this.DataGrid2.Items[j].Cells[13].Text = TotAdAmt;
						this.DataGrid2.Items[j].Cells[14].Text = TotChgAmt;
						this.DataGrid2.Items[j].Cells[15].Text = TotAmt;
					}
					else
					{
						this.DataGrid2.Items[j].Cells[13].Text = TotAdAmt;
						this.DataGrid2.Items[j].Cells[14].Text = TotChgAmt;
						this.DataGrid2.Items[j].Cells[15].Text = TotAmt;
					}
					
					SubTotalAmt = SubTotalAmt + Convert.ToInt32(TotAmt);
					// 結束 for(int j=0; j < DataGrid2.Items.Count; j++)
				}
				
				
				// 顯示當月開立總金額小計
				this.tbxContSubTotalAmt.Text = Convert.ToString(SubTotalAmt);
				this.lblContSubTotalAmt.Text = "當月開立總額 小計：$" + Convert.ToString(SubTotalAmt);
				//Response.Write("SubTotalAmt= " + SubTotalAmt + "<br>");
				// 結束 if (dv3.Count > 0)
			}
		}
		
		
		// 產生發票開立單 按鈕的處理
		private void btnAddIA_Click(object sender, System.EventArgs e)
		{
			string strSyscd = "C2";
			string Bkcd = Context.Request.QueryString["bkcd"].Trim();
			string YYYYMM = Context.Request.QueryString["yyyymm"].Trim();
			string Sort = Context.Request.QueryString["sort"].Trim();
			//Response.Write("Bkcd= " + Bkcd + "<br>");
			//Response.Write("YYYYMM= " + YYYYMM + "<br>");
			//Response.Write("Sort= " + Sort + "<br>");
			
			
			if(DataGrid1.Items.Count > 0)
			{
				// 步驟一: 由 DataGrid1 抓出落版資料, 更新其 pub_fginved 由 't' 為 'v'
				for(int i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 抓出 每一筆落版資料
					string strContNo = DataGrid1.Items[i].Cells[0].Text.ToString().Trim();
					string strYYYYMM = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					string strPubSeq = DataGrid1.Items[i].Cells[10].Text.ToString();
					string strIMSeq = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
					//Response.Write("i= " + i + ", ");
					//Response.Write("strSyscd= " + strSyscd + ", ");
					//Response.Write("strContNo= " + strContNo + ", ");
					//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
					//Response.Write("strPubSeq= " + strPubSeq + "");
					//Response.Write("strIMSeq= " + strIMSeq + "<br>");
					
					// 更新 (被挑選) 的落版資料之 pub_fginved 從 't' 變為 'v'
					// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
					//Response.Write(this.sqlCommand1.CommandText);
					this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand1.Parameters["@contno"].Value = strContNo;
					this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
					this.sqlCommand1.Parameters["@pubseq"].Value = strPubSeq;
					
					// 確認執行 sqlCommand1 成功
					this.sqlCommand1.Connection.Open();
					// 使用 Transaction 確認有執行動作
					System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
					this.sqlCommand1.Transaction = myTrans1;
					try
					{
						this.sqlCommand1.ExecuteNonQuery();
						myTrans1.Commit();
						//Response.Write("落版資料更新成功");
					}
					catch(System.Data.SqlClient.SqlException ex1)
					{
						Response.Write(ex1.Message + "<br>");
						myTrans1.Rollback();
						//Response.Write("落版資料更新失敗");
					}
					finally
					{
						this.sqlCommand1.Connection.Close();
					}
				}
				
				
				// 步驟二: 呼叫 sp: 更新其 pub_fginved 由 'v' 為 '1' & 產生 ia & iad
				int intContTotalAmt = 0, intContPaidAmt = 0, intContRestAmt = 0;
				int intSelectPubTotalAmt = 0;
				int intNewContPaidAmt = 0, intNewContRestAmt = 0;
				for(int j=0; j< DataGrid2.Items.Count ; j++)
				{
					// 抓出 每一筆落版資料
					string Syscd = "C2";
					string ContNo = DataGrid2.Items[j].Cells[0].Text.ToString().Trim();
					string IMSeq = DataGrid2.Items[j].Cells[1].Text.ToString().Trim();
					intContTotalAmt = Convert.ToInt32(DataGrid2.Items[j].Cells[10].Text.ToString().Trim());
					intContPaidAmt = Convert.ToInt32(DataGrid2.Items[j].Cells[11].Text.ToString().Trim());
					intContRestAmt = Convert.ToInt32(DataGrid2.Items[j].Cells[12].Text.ToString().Trim());
					intSelectPubTotalAmt = Convert.ToInt32(DataGrid2.Items[j].Cells[15].Text.ToString().Trim());
					//Response.Write("j= " + j + ", ");
					//Response.Write("Syscd= " + Syscd + ", ");
					//Response.Write("ContNo= " + ContNo + ", ");
					//Response.Write("IMSeq= " + IMSeq + ", ");
					//Response.Write("intContTotalAmt= " + intContTotalAmt + ", ");
					//Response.Write("intContPaidAmt= " + intContPaidAmt + ", ");
					//Response.Write("intContRestAmt= " + intContRestAmt + ", ");
					//Response.Write("intSelectPubTotalAmt= " + intSelectPubTotalAmt + ", ");
					
					// 更新 (被挑選) 的落版資料之 pub_fginved 從 't' 變為 'v'
					// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 更新
					//Response.Write(this.sqlCommand2.CommandText);
					this.sqlCommand2.Parameters["@syscd"].Value = Syscd;
					this.sqlCommand2.Parameters["@contno"].Value = ContNo;
					this.sqlCommand2.Parameters["@imseq"].Value = IMSeq;
					
					// 確認執行 sqlCommand2 成功
					this.sqlCommand2.Connection.Open();
					// 使用 Transaction 確認有執行動作
					System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand1.Connection.BeginTransaction();
					this.sqlCommand2.Transaction = myTrans2;
					try
					{
						this.sqlCommand2.ExecuteNonQuery();
						myTrans2.Commit();
						//Response.Write("產生 ia&iad 成功");
					}
					catch(System.Data.SqlClient.SqlException ex2)
					{
						Response.Write(ex2.Message + "<br>");
						myTrans2.Rollback();
						//Response.Write("產生 ia&iad 失敗");
					}
					finally
					{
						this.sqlCommand2.Connection.Close();
					}
					
					
					
					// 步驟三: 更新合約資料
					intNewContPaidAmt = intContPaidAmt + intSelectPubTotalAmt;
					intNewContRestAmt =intContTotalAmt - intNewContPaidAmt;
					//Response.Write("intNewContPaidAmt= " + intNewContPaidAmt + ", ");
					//Response.Write("intNewContRestAmt= " + intNewContRestAmt + "<br>");
					
					
					// 更新 合約資料之 已繳金額 & 剩餘金額
					// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 更新
					//Response.Write(this.sqlCommand2.CommandText);
					this.sqlCommand3.Parameters["@contno"].Value = ContNo;
					this.sqlCommand3.Parameters["@paidamt"].Value = Convert.ToString(intNewContPaidAmt);
					this.sqlCommand3.Parameters["@restamt"].Value = Convert.ToString(intNewContRestAmt);
					
					// 確認執行 sqlCommand3 成功
					this.sqlCommand3.Connection.Open();
					// 使用 Transaction 確認有執行動作
					System.Data.SqlClient.SqlTransaction myTrans3 = this.sqlCommand3.Connection.BeginTransaction();
					this.sqlCommand3.Transaction = myTrans3;
					try
					{
						this.sqlCommand3.ExecuteNonQuery();
						myTrans3.Commit();
						//Response.Write("產生 ia&iad 成功");
					}
					catch(System.Data.SqlClient.SqlException ex3)
					{
						Response.Write(ex3.Message + "<br>");
						myTrans3.Rollback();
						//Response.Write("產生 ia&iad 失敗");
					}
					finally
					{
						this.sqlCommand3.Connection.Close();
					}
				}
				
				
				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"產生發票開立單成功!\\n請檢視發票開立單檢核表\");</script>";
				Page.Controls.Add(litAlert2);
				
				
				// 轉址 - 直接顯示 ia 檢核表
				string strbuf = "iaFm2_chklist_ia.aspx?bkcd=" + Bkcd + "&yyyymm=" + YYYYMM + "&sort=" + Sort + "&action=2";
				Response.Redirect(strbuf);
			}
		}
		
		
		// 返回前一步驟 按鈕的處理
		private void btnBack_Click_1(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("iaFm2_Add.aspx");
		}
		
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
			this.btnAddIA.Click += new System.EventHandler(this.btnAddIA_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				 new System.Data.Common.DataColumnMapping("im_jbti", "im_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("im_addr", "im_addr"),
																																																				 new System.Data.Common.DataColumnMapping("im_zip", "im_zip"),
																																																				 new System.Data.Common.DataColumnMapping("im_tel", "im_tel"),
																																																				 new System.Data.Common.DataColumnMapping("im_invcd", "im_invcd"),
																																																				 new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																				 new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																				 new System.Data.Common.DataColumnMapping("pub_count", "pub_count"),
																																																				 new System.Data.Common.DataColumnMapping("pub_totamt", "pub_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("Expr1", "Expr1"),
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																				 new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd")})});
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("TotAdAmt", "TotAdAmt"),
																																																				 new System.Data.Common.DataColumnMapping("TotChgAmt", "TotChgAmt"),
																																																				 new System.Data.Common.DataColumnMapping("TotAmt", "TotAmt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq")})});
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("TotAdAmt", "TotAdAmt"),
																																																				 new System.Data.Common.DataColumnMapping("TotChgAmt", "TotChgAmt"),
																																																				 new System.Data.Common.DataColumnMapping("TotAmt", "TotAmt")})});
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "UPDATE c2_pub SET pub_fginved = \'v\' WHERE (pub_syscd = @syscd) AND (pub_contno = " +
				"@contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "UPDATE c2_cont SET cont_paidamt = @paidamt, cont_restamt = @restamt WHERE (cont_s" +
				"yscd = \'C2\') AND (cont_contno = @contno)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paidamt", System.Data.SqlDbType.Real, 4, "cont_paidamt"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restamt", System.Data.SqlDbType.Real, 4, "cont_restamt"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "dbo.[sp_c2_add_ia]";
			this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.VarChar, 2));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT DISTINCT c2_cont.cont_syscd, c2_cont.cont_contno, RTRIM(c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(mfr.mfr_inm) AS mfr_inm, c2_pub.pub_imseq, RTRIM(invmfr.im_nm) AS im_nm, RTRIM(invmfr.im_jbti) AS im_jbti, RTRIM(invmfr.im_addr) AS im_addr, RTRIM(invmfr.im_zip) AS im_zip, RTRIM(invmfr.im_tel) AS im_tel, invmfr.im_invcd, invmfr.im_taxtp, c2_pub.pub_contno, c2_pub.pub_yyyymm, c2_pub.pub_pubseq, c2_pub.pub_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_projno, proj.proj_costctr, 1 AS pub_count, c2_pub.pub_adamt + c2_pub.pub_chgamt AS pub_totamt, c2_cont.cont_syscd AS Expr1, c2_pub.pub_syscd, invmfr.im_contno, invmfr.im_imseq, invmfr.im_syscd, proj.proj_bkcd, proj.proj_fgitri, proj.proj_syscd FROM c2_cont INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN invmfr ON c2_pub.pub_imseq = invmfr.im_imseq AND c2_pub.pub_syscd = invmfr.im_syscd AND c2_pub.pub_contno = invmfr.im_contno INNER JOIN book ON c2_pub.pub_bkcd = book.bk_bkcd INNER JOIN proj ON c2_cont.cont_bkcd = proj.proj_bkcd AND c2_cont.cont_syscd = proj.proj_syscd AND invmfr.im_fgitri = proj.proj_fgitri WHERE (c2_pub.pub_yyyymm <= @yyyymm) AND (c2_pub.pub_bkcd = @bkcd) AND (c2_cont.cont_fgpubed = '1') AND (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_pub.pub_fginved = 't')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "pub_bkcd"));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, SUM(c2_pub.pub_adamt) AS TotAdAmt, SUM(c2_pub.pub_chgamt) AS TotChgAmt, SUM(c2_pub.pub_adamt + c2_pub.pub_chgamt) AS TotAmt, c2_pub.pub_imseq FROM c2_cont INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contno WHERE (c2_cont.cont_bkcd = @bkcd) AND (c2_pub.pub_yyyymm <= @yyyymm) AND (c2_pub.pub_fginved = 't') AND (c2_cont.cont_fgpubed = '1') AND (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') GROUP BY c2_cont.cont_syscd, c2_cont.cont_contno, c2_pub.pub_imseq";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT DISTINCT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_totjtm, c2_cont.cont_tottm, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_cont.cont_custno, c2_cont.cont_fgclosed, c2_cont.cont_fgpayonce, c2_cont.cont_fgcancel, c2_cont.cont_fgtemp, c2_cont.cont_fgpubed, mfr.mfr_inm, cust.cust_nm, cust.cust_tel, srspn.srspn_cname, invmfr.im_imseq, invmfr.im_nm FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN invmfr ON c2_pub.pub_syscd = invmfr.im_syscd AND c2_pub.pub_contno = invmfr.im_contno AND c2_pub.pub_imseq = invmfr.im_imseq WHERE (c2_pub.pub_yyyymm <= @yyyymm) AND (c2_cont.cont_bkcd = @bkcd) AND (c2_cont.cont_fgpubed = '1') AND (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_pub.pub_fginved = 't')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, SUM(c2_pub.pub_adamt) AS TotAdAmt, SUM(c2_pub.pub_chgamt) AS TotChgAmt, SUM(c2_pub.pub_adamt + c2_pub.pub_chgamt) AS TotAmt FROM c2_cont INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contno WHERE (c2_cont.cont_bkcd = @bkcd) AND (c2_pub.pub_yyyymm <= @yyyymm) AND (c2_pub.pub_fginved = 't') AND (c2_cont.cont_fgpubed = '1') AND (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') GROUP BY c2_cont.cont_syscd, c2_cont.cont_contno";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
