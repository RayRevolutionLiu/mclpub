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
	/// Summary description for iaFm2_Recia.
	/// </summary>
	public class iaFm2_Recia : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblIMSeq;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMfrCust;
		protected System.Web.UI.WebControls.Button btnShowFullCont;
		protected System.Web.UI.WebControls.Literal litWinOpen1;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxbkcd;
		protected System.Web.UI.WebControls.TextBox tbxfgpubed;
		protected System.Web.UI.WebControls.Label lblMemo2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblIAMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblContMessage;
		protected System.Web.UI.WebControls.Label lblContTotalAmt;
		protected System.Web.UI.WebControls.Label lblContPaidAmt;
		protected System.Web.UI.WebControls.Label lblContRestAmt;
		protected System.Web.UI.WebControls.Panel pnl1;
		protected System.Web.UI.WebControls.Label lblPickMessage;
		protected System.Web.UI.WebControls.Label lblPickTotalAmt;
		protected System.Web.UI.WebControls.Panel pnl2;
		protected System.Web.UI.WebControls.Label lblNewContMessage;
		protected System.Web.UI.WebControls.Label lblNewContTotalAmt;
		protected System.Web.UI.WebControls.Label lblNewContPaidAmt;
		protected System.Web.UI.WebControls.Label lblNewContRestAmt;
		protected System.Web.UI.WebControls.Panel pnl3;
		protected System.Web.UI.WebControls.Button btnRecia;
		protected System.Web.UI.WebControls.Button btnModifyCont;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Button btnModifyPub;
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
				
				
				// 抓出 合約及發廠資料
				if(Context.Request.QueryString["contno"].ToString().Trim() != "" && Context.Request.QueryString["imseq"].ToString().Trim() != "")
				{
					GetContIM();
				}
			}
		}
		
		
		// 抓出 合約及發廠資料
		private void GetContIM()
		{
			this.lblMessage.Text = "";
			this.btnRecia.Visible = false;
			this.btnModifyCont.Visible = false;
			this.btnModifyPub.Visible = false;
			
			
			if(Context.Request.QueryString["contno"].Trim() != "" && Context.Request.QueryString["imseq"].Trim() != "")
			{
				// 抓出網頁變數的值
				string strContNo = Context.Request.QueryString["contno"].Trim();
				string strIMSeq = Context.Request.QueryString["imseq"].Trim();
				string strIMName = "";
				this.lblContNo.Text = "您挑選的合約書編號：" + strContNo;
				this.lblIMSeq.Text = "發票廠商收件人：" + strIMSeq;
				
				
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c2_cont");
				DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr1 = "1=1";
				rowfilterstr1 = rowfilterstr1 + " AND im_contno = '" + strContNo + "'";
				rowfilterstr1 = rowfilterstr1 + " AND im_imseq = '" + strIMSeq + "'";
				dv1.RowFilter = rowfilterstr1;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
				if(dv1.Count > 0)
				{
					strIMName = dv1[0]["im_nm"].ToString().Trim();
					this.lblContNo.Text = "您挑選的合約是：" + strContNo;
					this.lblIMSeq.Text = this.lblIMSeq.Text + "-" + strIMName;
					
					// 顯示合約相關資料 -- 含廠商/客戶, 合約金額資料
					LoadCont();
					
					// 顯示其落版資料 - 尚未開立發票的
					BindGrid1();
				}
			}
		}
		
		
		// 顯示合約相關資料 -- custno, 以便做為 '顯示合約落版資料' 的傳遞變數
		private void LoadCont()
		{
			string strContNo = Context.Request.QueryString["contno"].Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			rowfilterstr1 = rowfilterstr1 + " AND cont_contno = '" + strContNo + "'";
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
			if(dv1.Count > 0)
			{
				// 抓出資料
				string strbkcd = dv1[0]["cont_bkcd"].ToString();
				string strfgpubed = dv1[0]["cont_fgpubed"].ToString().Trim();
				string strCustNo = dv1[0]["cont_custno"].ToString().Trim();
				string strCustName = dv1[0]["cust_nm"].ToString().Trim();
				string strMfrNo = dv1[0]["cont_mfrno"].ToString().Trim();
				string strMfrIName = dv1[0]["mfr_inm"].ToString().Trim();
				string intTotalAmt = dv1[0]["cont_totamt"].ToString().Trim();
				string intPaidAmt = dv1[0]["cont_paidamt"].ToString().Trim();
				string intRestAmt = dv1[0]["cont_restamt"].ToString().Trim();
				
				// 顯示資料
				this.tbxbkcd.Text = strbkcd;
				this.tbxfgpubed.Text = strfgpubed;
				this.tbxCustNo.Text = strCustNo;
				this.lblMfrCust.Text = "(廠商名稱：" + strMfrNo + "-" + strMfrIName + "；客戶名稱：" + strCustName + ")";
				
				this.pnl1.Visible = true;
				this.pnl2.Visible = false;
				this.pnl3.Visible = false;
				this.lblContTotalAmt.Text = intTotalAmt;
				this.lblContPaidAmt.Text = intPaidAmt;
				this.lblContRestAmt.Text = intRestAmt;
			}
		}
		
		
		// 顯示其落版資料 - 尚未開立發票的
		private void BindGrid1()
		{
			// 抓出網頁變數的值
			string strContNo = Context.Request.QueryString["contno"].Trim();
			string strIMSeq = Context.Request.QueryString["imseq"].Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			rowfilterstr1 = rowfilterstr1 + " AND cont_syscd = 'C2'";
			rowfilterstr1 = rowfilterstr1 + " AND cont_contno = '" + strContNo + "'";
			//rowfilterstr1 = rowfilterstr1 + " AND im_imseq = '" + strIMSeq + "'";
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			if(dv1.Count > 0)
			{
				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 合約類別
					string conttp = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
					//Response.Write("conttp= " + conttp + "<br>");
					if(conttp == "01") 
						DataGrid1.Items[i].Cells[4].Text = "一般";
					else if(conttp == "09")
						DataGrid1.Items[i].Cells[4].Text = "<font color='Red'>推廣</font>";
					
					// 簽約日期
					string SignDate = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
					SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
					//Response.Write("SignDate= " + SignDate + "<br>");
					DataGrid1.Items[i].Cells[5].Text = SignDate;
					
					// 合約起日
					string StartDate = DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid1.Items[i].Cells[6].Text = StartDate;
					
					// 合約迄日
					string EndDate = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					//Response.Write("EndDate= " + EndDate + "<br>");
					DataGrid1.Items[i].Cells[7].Text = EndDate;
					
					// 結案註記
					string fgclosed = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
					//Response.Write("fgclosed= " + fgclosed + "<br>");
					if(fgclosed == "0") 
						DataGrid1.Items[i].Cells[15].Text = "否";
					else 
						DataGrid1.Items[i].Cells[15].Text = "<font color='Red'>是</font>";

					// 結束 for loop	
				}
				
				
				// 顯示 發票明細資料
				BindGrid2();
				
				// 抓出 確認金額
				CheckAmt();
				
				// 結束 if(dv2.Count > 0)
			}
			else
			{
				this.btnRecia.Visible = false;
				this.lblMemo2.Text = "無未開立發票開立單的落版資料, 請 '返回前頁' 重新操作! <A HREF='iaFm1_Add.aspx' Target='_self'>(按此處 返回前頁)</A>";
			}
		}
		
		
		private void BindGrid2()
		{
			string strContNo, strIANo;
			strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			strIANo = Context.Request.QueryString["iano"].ToString().Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "ia");
			DataView dv3 = ds3.Tables["ia"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND ia_syscd = 'C2'";
			rowfilterstr3 = rowfilterstr3 + " AND ia_iano = '" + strIANo + "'";
			rowfilterstr3 = rowfilterstr3 + " AND ia_iasdate = '' ";
			rowfilterstr3 = rowfilterstr3 + " AND ia_iasseq = '' ";		
			rowfilterstr3 = rowfilterstr3 + " AND ia_iaitem = '' ";		
			rowfilterstr3 = rowfilterstr3 + " AND ia_contno = 'C2" + strContNo + "'";
			dv3.RowFilter = rowfilterstr3;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv3.Count > 0)
			{
				this.lblIAMessage.Text = "本合約共有 " + dv3.Count + " 筆發票明細資料!"; 
				
				DataGrid2.DataSource=dv3;
				DataGrid2.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid2.Items.Count ; i++)
				{
					// 發票類別代碼
					string invcd = DataGrid2.Items[i].Cells[8].Text.ToString().Trim();
					//Response.Write("invcd= " + invcd + "<br>");
					switch(invcd)
					{
						case "2":
							DataGrid2.Items[i].Cells[8].Text = "<font color='Red'>二聯式</font>";
							break;
						case "3":
							DataGrid2.Items[i].Cells[8].Text = "三聯式";
							break;
						case "4":
							DataGrid2.Items[i].Cells[8].Text = "<font color='Red'>其他</font>";
							break;
						default:
							DataGrid2.Items[i].Cells[8].Text = "三聯式";
							break;
					}
					
					// 發票課稅別代碼
					string taxtp = DataGrid2.Items[i].Cells[9].Text.ToString().Trim();
					//Response.Write("taxtp= " + taxtp + "<br>");
					switch(taxtp)
					{
						case "1":
							DataGrid2.Items[i].Cells[9].Text = "應稅5%";
							break;
						case "2":
							DataGrid2.Items[i].Cells[9].Text = "<font color='Red'>零稅</font>";
							break;
						case "3":
							DataGrid2.Items[i].Cells[9].Text = "<font color='Red'>免稅</font>";
							break;
						default:
							DataGrid2.Items[i].Cells[9].Text = "應稅5%";
							break;
					}
				
					// 結束 for loop
				}				
			
				// 結束 if (dv4.Count > 0)
			}
		}
		
		
		private void CheckAmt()
		{
			// 顯示 Panel 資料
			this.pnl1.Visible = true;
			this.pnl2.Visible = true;
			this.pnl3.Visible = true;
			
			// 抓出 已挑選 pnl2 及 將更新 pnl3 之資料
			int intPickTotalAmt = 0;
			int intContTotalAmt = 0, intContPaidAmt = 0, intContRestAmt = 0;
			int intNewContTotalAmt = 0, intNewContPaidAmt = 0, intNewContRestAmt = 0;
			
			// 抓出已挑選金額資料 之 總廣告金額, 總換稿金額, 小計
			string strContNo, strIANo;
			strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			strIANo = Context.Request.QueryString["iano"].ToString().Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "ia");
			DataView dv3 = ds3.Tables["ia"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND ia_syscd = 'C2'";
			rowfilterstr3 = rowfilterstr3 + " AND ia_iano = '" + strIANo + "'";
			rowfilterstr3 = rowfilterstr3 + " AND ia_iasdate = '' ";
			rowfilterstr3 = rowfilterstr3 + " AND ia_iasseq = '' ";		
			rowfilterstr3 = rowfilterstr3 + " AND ia_iaitem = '' ";		
			rowfilterstr3 = rowfilterstr3 + " AND ia_contno = 'C2" + strContNo + "'";
			dv3.RowFilter = rowfilterstr3;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv3.Count > 0)
			{
				intPickTotalAmt = Convert.ToInt32(dv3[0]["ia_pyat"].ToString().Trim());
				this.lblPickTotalAmt.Text = Convert.ToString(intPickTotalAmt);
				//Response.Write("intPickTotalAmt= " + intPickTotalAmt + "<br>");
			}
			
			// 抓出合約金額資料 之 合約金額, 已繳金額, 剩餘金額
			intContTotalAmt = Convert.ToInt32(this.lblContTotalAmt.Text.ToString().Trim());
			intContPaidAmt = Convert.ToInt32(this.lblContPaidAmt.Text.ToString().Trim());
			intContRestAmt = Convert.ToInt32(this.lblContRestAmt.Text.ToString().Trim());
			//Response.Write("intContTotalAmt= " + intContTotalAmt + "<br>");
			//Response.Write("intContPaidAmt= " + intContPaidAmt + "<br>");
			//Response.Write("intContRestAmt= " + intContRestAmt + "<br>");
			
			
			// 抓出將更新之合約金額資料 之 合約金額, 已繳金額, 剩餘金額
			intNewContTotalAmt = intContTotalAmt;
			intNewContPaidAmt = intContPaidAmt - intPickTotalAmt;
			intNewContRestAmt = intNewContTotalAmt - intNewContPaidAmt;
			//Response.Write("intNewContTotalAmt= " + intNewContTotalAmt + "<br>");
			//Response.Write("intNewContPaidAmt= " + intNewContPaidAmt + "<br>");
			//Response.Write("intNewContRestAmt= " + intNewContRestAmt + "<br>");
			this.lblNewContTotalAmt.Text = Convert.ToString(intNewContTotalAmt);
			this.lblNewContPaidAmt.Text = Convert.ToString(intNewContPaidAmt);
			this.lblNewContRestAmt.Text = Convert.ToString(intNewContRestAmt);
			
			
			//			// 檢查 將更新之合約 '剩餘金額' & '已繳金額' 資料是否合理
			//			if(intNewContRestAmt > 0 || intNewContPaidAmt <= intContTotalAmt)
			//			{
			this.btnRecia.Visible = true;
				
			this.btnModifyCont.Visible = false;
			this.btnModifyPub.Visible = false;
			//			}
			//			else if(intNewContRestAmt < 0 || intNewContPaidAmt > intContTotalAmt)
			//			{
			//				this.btnRecia.Visible = false;
			//				
			//				// 以 Javascript 的 window.close() 來告知訊息
			//				LiteralControl litAlert1 = new LiteralControl();
			//				litAlert1.Text = "<script language=javascript>alert(\"將更新之合約 '剩餘金額' & '已繳金額' 資料不合理,\\n 無法產生發票開立單, 請先修正 合約或落版資料!!!\");</script>";
			//				Page.Controls.Add(litAlert1);
			//				
			//				this.btnModifyCont.Visible = true;
			//				this.btnModifyPub.Visible = true;
			//			}
		}
		
		
		// 回復發票開立單 按鈕的處理
		private void btnRecia_Click(object sender, System.EventArgs e)
		{
			string strSyscd = "C2";
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			string strIMSeq = Context.Request.QueryString["imseq"].ToString().Trim();
			string strIANo = Context.Request.QueryString["iano"].ToString().Trim();
			
			
			for(int i=0; i< DataGrid2.Items.Count ; i++)
			{
				// 抓出 每一筆發票明細資料
				string strYYYYMM = DataGrid2.Items[i].Cells[12].Text.ToString().Trim();
				string strPubSeq = DataGrid2.Items[i].Cells[13].Text.ToString().Trim();
				//Response.Write("i= " + i + ", ");
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
				//Response.Write("strPubSeq= " + strPubSeq + "<br>");
				
				// 更新被挑選的落版資料之 pub_fginved 從 ' ' 變為 'v'
				// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
				//Response.Write(this.sqlCommand1.CommandText);
				this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
				this.sqlCommand1.Parameters["@contno"].Value = strContNo;
				this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
				this.sqlCommand1.Parameters["@pubseq"].Value = strPubSeq;
					
				// 確認執行 sqlCommand1 成功
				bool ResultFlag1 = false;
				this.sqlCommand1.Connection.Open();
				try
				{
					this.sqlCommand1.ExecuteNonQuery();
					ResultFlag1 = true;
				}
				catch(System.Data.SqlClient.SqlException ex1)
				{
					Response.Write(ex1.Message + "<br>");
					ResultFlag1 = false;
				}
				finally
				{
					this.sqlCommand1.Connection.Close();
				}
				//Response.Write("ResultFlag1= " + ResultFlag1 + "<br>");
						
				// 輸出執行結果
				if (ResultFlag1)
				{
					//Response.Write("更新落版檔的發票開立單註記 成功!<br>");
				}
				else
				{
					//Response.Write("更新落版檔的發票開立單註記 失敗!<br>");
				}
				
				
				
				// step2 - 產生 ia & iad -- 呼叫 sp_c2_delete_ia_1
				//Response.Write(this.sqlCommand2.CommandText);
				this.sqlCommand2.Parameters["@iano"].Value = strIANo;
				this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
				this.sqlCommand2.Parameters["@contno"].Value = strContNo;
				this.sqlCommand2.Parameters["@yyyymm"].Value = strYYYYMM;
				this.sqlCommand2.Parameters["@pubseq"].Value = strPubSeq;
				
				// 確認執行 sqlCommand2 成功
				bool ResultFlag2 = false;
				this.sqlCommand2.Connection.Open();
				try
				{
					this.sqlCommand2.ExecuteNonQuery();
					ResultFlag2 = true;
				}
				catch(System.Data.SqlClient.SqlException ex2)
				{
					Response.Write(ex2.Message + "<br>");
					ResultFlag2 = false;
				}
				finally
				{
					this.sqlCommand2.Connection.Close();
				}
				//Response.Write("ResultFlag2= " + ResultFlag2 + "<br>");
			
				// 輸出執行結果
				if (ResultFlag2)
				{
					//Response.Write("<font size=2>刪除發票開立單成功!</font><br>");
					
					// 以 Javascript 的 window.close() 來告知訊息
					//LiteralControl litAlert1 = new LiteralControl();
					//litAlert1.Text = "<script language=javascript>alert(\"合約書編號: " + strContNo + " 的發票開立單 刪除成功\");</script>";
					//Page.Controls.Add(litAlert1);
				}
				else
				{
					//Response.Write("<font size=2>刪除發票開立單失敗!</font><br>");
					
					// 以 Javascript 的 window.close() 來告知訊息
					//LiteralControl litAlert1 = new LiteralControl();
					//litAlert1.Text = "<script language=javascript>alert(\"合約書編號: " + strContNo + " 的發票開立單 刪除失敗\");</script>";
					//Page.Controls.Add(litAlert1);
				}
			}
			
			
			
			// step3 - 更新 合約資料之 已繳金額 & 剩餘金額 欄位值
			//Response.Write(this.sqlCommand3.CommandText);
			string strNewContPaidAmt = this.lblNewContPaidAmt.Text.ToString().Trim();
			string strNewContRestAmt = this.lblNewContRestAmt.Text.ToString().Trim();
			this.sqlCommand3.Parameters["@paidamt"].Value = strNewContPaidAmt;
			this.sqlCommand3.Parameters["@restamt"].Value = strNewContRestAmt;
			this.sqlCommand3.Parameters["@contno"].Value = strContNo;
			
			// 確認執行 sqlCommand3 成功
			bool ResultFlag3 = false;
			this.sqlCommand3.Connection.Open();
			try
			{
				this.sqlCommand3.ExecuteNonQuery();
				ResultFlag3 = true;
			}
			catch(System.Data.SqlClient.SqlException ex3)
			{
				Response.Write(ex3.Message + "<br>");
				ResultFlag3 = false;
			}
			finally
			{
				this.sqlCommand3.Connection.Close();
			}
			//Response.Write("ResultFlag3= " + ResultFlag3 + "<br>");
			
			// 輸出執行結果
			if (ResultFlag3)
			{
				//Response.Write("<font size=2>更新合約之已繳金額&剩餘金額成功!</font><br>");
				
				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"合約書編號: " + strContNo + " 之已繳&剩餘金額 更新成功\");</script>";
				Page.Controls.Add(litAlert2);
			}
			else
			{
				//Response.Write("<font size=2>更新合約之已繳金額&剩餘金額失敗!</font><br>");
				
				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"合約書編號: " + strContNo + " 之已繳&剩餘金額 更新成功失敗\");</script>";
				Page.Controls.Add(litAlert2);
			}
			
			
			// 轉址處理 - 發票開立單檢核表 - 一次付款
			Response.Redirect("iaFm2_Chklist_ia.aspx?bkcd=&yyyymm=&sort=&action=2");
			
		}
		
		
		// 顯示合約落版資料 按鈕的處理
		private void btnShowFullCont_Click(object sender, System.EventArgs e)
		{
			// 開啟小視窗
			string strbuf = "ContPubFm_show.aspx?custno=" + this.tbxCustNo.Text.ToString().Trim() + "&old_contno=" + Context.Request.QueryString["contno"].Trim();
			//Response.Write(strbuf);
			
			// 以 Javascript 的 window.open()  來告知訊息
			litWinOpen1.Text = "<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
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
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.btnShowFullCont.Click += new System.EventHandler(this.btnShowFullCont_Click);
			this.btnRecia.Click += new System.EventHandler(this.btnRecia_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_fgclosed, c2_cont.cont_custno, RTRIM(cust.cust_nm) AS cust_nm, cust.cust_tel, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_cont.cont_oldcontno, c2_cont.cont_moddate, c2_cont.cont_fgpayonce, c2_cont.cont_modempno, c2_cont.cont_fgcancel, c2_cont.cont_credate, c2_cont.cont_fgtemp, c2_cont.cont_fgpubed, RTRIM(mfr.mfr_inm) AS mfr_inm, invmfr.im_imseq, RTRIM(invmfr.im_nm) AS im_nm, cust.cust_custno, invmfr.im_contno, invmfr.im_syscd, mfr.mfr_mfrno, RTRIM(book.bk_nm) AS bk_nm, RTRIM(srspn.srspn_cname) AS srspn_cname, book.bk_bkcd, srspn.srspn_empno, c2_cont.cont_totjtm, c2_cont.cont_tottm FROM c2_cont INNER JOIN invmfr ON c2_cont.cont_syscd = invmfr.im_syscd AND c2_cont.cont_contno = invmfr.im_contno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno WHERE (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_fgpubed = '1')";
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
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasdate", "ia_iasdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasseq", "ia_iasseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_iaitem", "ia_iaitem"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyseq", "ia_pyseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																			new System.Data.Common.DataColumnMapping("ia_ivat", "ia_ivat"),
																																																			new System.Data.Common.DataColumnMapping("ia_invno", "ia_invno"),
																																																			new System.Data.Common.DataColumnMapping("ia_invdate", "ia_invdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																			new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																			new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																			new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgnonauto", "ia_fgnonauto"),
																																																			new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																			new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("ia_status", "ia_status"),
																																																			new System.Data.Common.DataColumnMapping("ia_cname", "ia_cname"),
																																																			new System.Data.Common.DataColumnMapping("ia_tel", "ia_tel"),
																																																			new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno"),
																																																			new System.Data.Common.DataColumnMapping("iad_iadid", "iad_iadid"),
																																																			new System.Data.Common.DataColumnMapping("iad_syscd", "iad_syscd"),
																																																			new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano"),
																																																			new System.Data.Common.DataColumnMapping("iad_iaditem", "iad_iaditem"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																			new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																			new System.Data.Common.DataColumnMapping("iad_costctr", "iad_costctr"),
																																																			new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																			new System.Data.Common.DataColumnMapping("iad_qty", "iad_qty"),
																																																			new System.Data.Common.DataColumnMapping("iad_unit", "iad_unit"),
																																																			new System.Data.Common.DataColumnMapping("iad_uprice", "iad_uprice"),
																																																			new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt"),
																																																			new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, ia.ia_iasseq, ia.ia_iaitem, ia.ia_iano, ia.ia_refno, RTRIM(ia.ia_mfrno) AS ia_mfrno, ia.ia_pyno, ia.ia_pyseq, ia.ia_pyat, ia.ia_ivat, ia.ia_invno, ia.ia_invdate, ia.ia_fgitri, RTRIM(ia.ia_rnm) AS ia_rnm, RTRIM(ia.ia_raddr) AS ia_raddr, RTRIM(ia.ia_rzip) AS ia_rzip, RTRIM(ia.ia_rjbti) AS ia_rjbti, RTRIM(ia.ia_rtel) AS ia_rtel, ia.ia_fgnonauto, ia.ia_invcd, ia.ia_taxtp, ia.ia_status, RTRIM(ia.ia_cname) AS ia_cname, RTRIM(ia.ia_tel) AS ia_tel, ia.ia_contno, iad.iad_iadid, iad.iad_syscd, iad.iad_iano, iad.iad_iaditem, iad.iad_fk1, iad.iad_fk2, iad.iad_fk3, iad.iad_fk4, iad.iad_projno, iad.iad_costctr, RTRIM(iad.iad_desc) AS iad_desc, iad.iad_qty, iad.iad_unit, iad.iad_uprice, iad.iad_amt, RTRIM(mfr.mfr_inm) AS mfr_inm FROM ia INNER JOIN iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN c2_cont ON iad.iad_fk1 = c2_cont.cont_contno INNER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (c2_cont.cont_fgpayonce = '0') AND (ia.ia_syscd = 'C2') ORDER BY ia.ia_iano DESC";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasdate", "ia_iasdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasseq", "ia_iasseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_iaitem", "ia_iaitem"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyseq", "ia_pyseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																			new System.Data.Common.DataColumnMapping("ia_ivat", "ia_ivat"),
																																																			new System.Data.Common.DataColumnMapping("ia_invno", "ia_invno"),
																																																			new System.Data.Common.DataColumnMapping("ia_invdate", "ia_invdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																			new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																			new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																			new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgnonauto", "ia_fgnonauto"),
																																																			new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																			new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("ia_status", "ia_status"),
																																																			new System.Data.Common.DataColumnMapping("ia_cname", "ia_cname"),
																																																			new System.Data.Common.DataColumnMapping("ia_tel", "ia_tel"),
																																																			new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno"),
																																																			new System.Data.Common.DataColumnMapping("iad_iadid", "iad_iadid"),
																																																			new System.Data.Common.DataColumnMapping("iad_syscd", "iad_syscd"),
																																																			new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano"),
																																																			new System.Data.Common.DataColumnMapping("iad_iaditem", "iad_iaditem"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																			new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																			new System.Data.Common.DataColumnMapping("iad_costctr", "iad_costctr"),
																																																			new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																			new System.Data.Common.DataColumnMapping("iad_qty", "iad_qty"),
																																																			new System.Data.Common.DataColumnMapping("iad_unit", "iad_unit"),
																																																			new System.Data.Common.DataColumnMapping("iad_uprice", "iad_uprice"),
																																																			new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt"),
																																																			new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, ia.ia_iasseq, ia.ia_iaitem, ia.ia_iano, ia.ia_refno, RTRIM(ia.ia_mfrno) AS ia_mfrno, ia.ia_pyno, ia.ia_pyseq, ia.ia_pyat, ia.ia_ivat, ia.ia_invno, ia.ia_invdate, ia.ia_fgitri, RTRIM(ia.ia_rnm) AS ia_rnm, RTRIM(ia.ia_raddr) AS ia_raddr, RTRIM(ia.ia_rzip) AS ia_rzip, RTRIM(ia.ia_rjbti) AS ia_rjbti, RTRIM(ia.ia_rtel) AS ia_rtel, ia.ia_fgnonauto, ia.ia_invcd, ia.ia_taxtp, ia.ia_status, RTRIM(ia.ia_cname) AS ia_cname, RTRIM(ia.ia_tel) AS ia_tel, ia.ia_contno, iad.iad_iadid, iad.iad_syscd, iad.iad_iano, iad.iad_iaditem, iad.iad_fk1, iad.iad_fk2, iad.iad_fk3, iad.iad_fk4, iad.iad_projno, iad.iad_costctr, RTRIM(iad.iad_desc) AS iad_desc, iad.iad_qty, iad.iad_unit, iad.iad_uprice, iad.iad_amt, RTRIM(mfr.mfr_inm) AS mfr_inm FROM ia INNER JOIN iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN c2_cont ON iad.iad_fk1 = c2_cont.cont_contno INNER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (c2_cont.cont_fgpayonce = '0') AND (ia.ia_syscd = 'C2') ORDER BY ia.ia_iano DESC";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "UPDATE c2_pub SET pub_fginved = \' \' WHERE (pub_fginved = \'1\') AND (pub_syscd = @s" +
				"yscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @p" +
				"ubseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "dbo.[sp_c2_delete_ia_1]";
			this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iano", System.Data.SqlDbType.VarChar, 8));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2));
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "UPDATE c2_cont SET cont_paidamt = @paidamt, cont_restamt = @restamt WHERE (cont_s" +
				"yscd = \'C2\') AND (cont_contno = @contno)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paidamt", System.Data.SqlDbType.Real, 4, "cont_paidamt"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restamt", System.Data.SqlDbType.Real, 4, "cont_restamt"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
