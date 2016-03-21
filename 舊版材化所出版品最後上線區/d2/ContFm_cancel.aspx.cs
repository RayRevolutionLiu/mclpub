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
	/// Summary description for ContFm_cancel.
	/// </summary>
	public class ContFm_cancel : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClear;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.Literal literal1;
	
		public ContFm_cancel()
		{
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			Page.Init += new System.EventHandler(Page_Init);
		}
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
				
				// 清除訊息文字
				literal1.Text = "";
				
			}
			
			// 隱藏 確認註銷 按鈕
			this.btnCancel.Visible = false;
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 按下 "查詢" 按鈕 的處理
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 以 Javascript 的 window.alert()  來告知訊息
			LiteralControl litAlertInv1 = new LiteralControl();
			litAlertInv1.Text = "<script language=javascript>alert(\"請先 '維護此合約' 之 '額外備註' 部分, 說明為何要註銷此合約~\\n再繼續進行本註銷動作!\");</script>";
			Page.Controls.Add(litAlertInv1);
			
			
			ShowCont();
			
			// 顯示 確認註銷 按鈕
			this.btnCancel.Visible = true;
		}
		
		
		private void ShowCont()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr1 = "mfr_mfrno Like '%"+tbxMfrNo.Text.Trim()+"%'";
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			//防呆處理: 若無資料時, 則給錯誤訊息
			if(tbxMfrName.Text!="")
				rowfilterstr1=rowfilterstr1+" and mfr_inm Like '%"+tbxMfrName.Text.Trim()+"%'";
	        	
			if(tbxCustNo.Text!="")
				rowfilterstr1=rowfilterstr1+" and cont_custno ='"+tbxCustNo.Text.Trim()+"'";
			
			if(tbxCustName.Text!="")
				rowfilterstr1=rowfilterstr1+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			
			if(tbxContNo.Text!="")
				rowfilterstr1=rowfilterstr1+" and cont_contno like '%"+tbxContNo.Text.Trim()+"%'";
			
			dv1.RowFilter = rowfilterstr1;
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count==0)
				lblMessage.Text="結果: 0筆資料 或 找不到符合條件的資料, 您可 重設條件!";
				//lblMessage.Text="查詢結果: 找不到符合條件的資料, 請重設條件!  或請先新增<A HREF='../d5/Mfr.aspx' Target='_new'>廠商</A> 或 <A HREF='../d1/NewCust.aspx?mfrno=' Target='_new'>客戶</A>, 再回來搜尋並新增.";
			else
				lblMessage.Text="結果: 找到 "+dv1.Count.ToString()+"筆資料";
			
			DataGrid1.DataSource=dv1;
			DataGrid1.DataBind();
			
			
			// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 合約類別
				int ContTypeCode = int.Parse(DataGrid1.Items[i].Cells[1].Text.ToString().Trim());
				if(ContTypeCode==1)
					DataGrid1.Items[i].Cells[1].Text = "一般合約";
				else
					DataGrid1.Items[i].Cells[1].Text = "<font color=blue>推廣合約</font>";
				
				//書籍類別
				//string bkcd = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				
				// 合約起日 & 合約迄日
				string StartDate = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
				//DataGrid1.Items[i].Cells[4].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
				if(StartDate != "")
				{
					if(StartDate.Length >= 6)
						StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					else
					{
						// 分離 \ 符號以取得數字
						if(StartDate.IndexOf("\\") != -1)
						{
							//StartDate = StartDate.Split('/', 2);
						}
						else
							StartDate = StartDate;
					}
				}
				else
				{
					StartDate = StartDate;
				}
				DataGrid1.Items[i].Cells[4].Text = StartDate;
				
				// 合約迄日
				string EndDate = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
				//DataGrid1.Items[i].Cells[5].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
				if(EndDate != "")
				{
					if(EndDate.Length >= 6)
							EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					else
					{
						// 分離 \ 符號以取得數字
						if(EndDate.IndexOf("\\") != -1)
						{
							//EndDate = EndDate.Split('/', 2);
						}
						else
							EndDate = EndDate;
					}
				}
				else
				{
					EndDate = EndDate;
				}
				DataGrid1.Items[i].Cells[5].Text = EndDate;
				
				// 舊客戶資料
				string OldCustNo = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				//Response.Write("OldCustNo= " + OldCustNo + "<br>");
				if(OldCustNo=="")
					DataGrid1.Items[i].Cells[11].Text = "<font color=Gray>無資料</font>";
				else
					DataGrid1.Items[i].Cells[11].Text = DataGrid1.Items[i].Cells[11].Text;
				
				// 已結案註記
				string strfgclosed = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
				//Response.Write("strfgclosed= " + strfgclosed + "<br>");
				if(strfgclosed == "0")
				{
					DataGrid1.Items[i].Cells[12].Text = "否";
				}
				else
				{
					DataGrid1.Items[i].Cells[12].Text = "<font color=red>是</font>";
				}
				
				// 已落版註記
				string strfgpubed = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				//Response.Write("strfgpubed= " + strfgpubed + "<br>");
				if(strfgpubed == "0")
				{
					DataGrid1.Items[i].Cells[13].Text = "否";
				}
				else
				{
					DataGrid1.Items[i].Cells[13].Text = "<font color=red>是</font>";
				}
				
			}
			
		}
		
		
		// 按下 "顯示合約書" 的按鈕處理
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[1].Text);
			
			if(e.CommandName=="ShowCont")
			{
				// 開啟小視窗
				string strbuf1 = "ContPubFm_show.aspx?custno=" + DataGrid1.SelectedItem.Cells[8].Text.Trim() + "&old_contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim();
				//Response.Write(strbuf1);
				this.literal1.Text="<script language=\"javascript\">window.open(\"" + strbuf1 + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
			}
			else if(e.CommandName == "ModifyCont")
			{
				// 開啟小視窗
				string strbuf2 = "ContFm_modify.aspx?custno=" + DataGrid1.SelectedItem.Cells[8].Text.Trim() + "&contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim();
				//Response.Write(strbuf2);
				this.literal1.Text="<script language=\"javascript\">window.open(\"" + strbuf2 + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
			}
		}
		
		
		// 換頁處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowCont();
		}
		
		
		// 清除重查 的按鈕
		private void lnbClear_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ContFm_cancel.aspx");
		}
		
		
		// 若選擇 註銷 選項的處理
		protected object GetfgUpdate(object fgupdate)
		{
			bool strReturn = false;
			if(fgupdate.ToString().Trim() == "1")
				strReturn = true;
			return strReturn;
		}
		
		
		// 確認註銷 按鈕的處理
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// 抓出各行 註銷選項 之值
			for(int i=0; i< DataGrid1.Items.Count ; i++)
			{ 
				// 抓出 c2_pub 之 PK
				string strSyscd = "C2";
				string strContNo = DataGrid1.Items[i].Cells[0].Text.ToString().Trim();
				//Response.Write("syscd= " + strSyscd + ", " );
				//Response.Write("ContNo=" + strContNo + ", " );
				
				// 抓出 ItemTemplate 之 CheckBox 型態之 cbxUpdate (Controls[1])
				string strfgUpdate = ((CheckBox)DataGrid1.Items[i].Cells[14].Controls[1]).Checked.ToString();
				//Response.Write("註銷註記= " + ((CheckBox)DataGrid1.Items[i].Cells[14].Controls[1]).Checked.ToString() + "<br>");
				//Response.Write("strfgUpdate= " + strfgUpdate + "<br>");
				
				// 執行 更新 sqlcmd1
				// 確認 myCommand 之更新指令內容 - sqlcmd1: 定義在 for loop 之前
				string sqlcmd1 = " UPDATE c2_cont ";
				
				// 若  註銷選項 有勾選, 則更新其值
				if(strfgUpdate == "True")
				{
					//Response.Write(strContNo + ": True, update sql table...<br>");
					
					// 執行 更新 sqlcmd
					sqlcmd1 = sqlcmd1 + " SET cont_fgcancel = 1";
					
				}
				else
				{
					//Response.Write("False, do nothing~<br>");
					
					// 執行 更新 sqlcmd
					sqlcmd1 = sqlcmd1 + " SET cont_fgcancel = 0";
				}
				
				sqlcmd1 = sqlcmd1 + " WHERE (cont_syscd = '" + strSyscd + "') AND (cont_contno = '" + strContNo + "')";
				//Response.Write("sqlcmd1= " + sqlcmd1 + "<br><br>");
						
				// 執行 myCommand (myCommand 是執行 sqlCommand1 ) 更新資料庫: c2_cont
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
					//Response.Write("更新註銷成功!<br>");
					
					// 以 Javascript 的 window.close() 來告知訊息
				}
				else  
				{
					//Response.Write("更新註銷失敗!<br>");
					
					// 以 Javascript 的 window.close() 來告知訊息
				}
			
			// 結束 for loop
			}
			
			// 以 Javascript 的 window.close() 來告知訊息 - 告知動作完成
			LiteralControl litAlert1 = new LiteralControl();
			litAlert1.Text = "<script language=javascript>alert(\"註銷動作完成!\");</script>";
			Page.Controls.Add(litAlert1);
			
			// Refresh DataGrid1
			DataGrid1.CurrentPageIndex=0;
			ShowCont();
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClear.Click += new System.EventHandler(this.lnbClear_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_tel, cust.cust_oldcustno, book.bk_nm, book.bk_bkcd, c2_cont.cont_fgclosed, c2_cont.cont_fgpubed, c2_cont.cont_fgcancel FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgcancel <> '1')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel")})});
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
		
	}
}
