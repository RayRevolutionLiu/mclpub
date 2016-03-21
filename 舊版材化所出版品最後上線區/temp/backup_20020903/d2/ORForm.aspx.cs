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
	/// Summary description for ORForm.
	/// </summary>
	public class ORForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxORName;
		protected System.Web.UI.WebControls.TextBox tbxORMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxORJobTitle;
		protected System.Web.UI.WebControls.TextBox tbxORZipcode;
		protected System.Web.UI.WebControls.TextBox tbxORAddr;
		protected System.Web.UI.WebControls.TextBox tbxORTel;
		protected System.Web.UI.WebControls.TextBox tbxORFax;
		protected System.Web.UI.WebControls.TextBox tbxORCell;
		protected System.Web.UI.WebControls.TextBox tbxOREmail;
		protected System.Web.UI.WebControls.TextBox tbxORPubCount;
		protected System.Web.UI.WebControls.DropDownList ddlORmtpcd;
		protected System.Web.UI.WebControls.DropDownList ddlORfgmosea;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.TextBox tbxORSysCode;
		protected System.Web.UI.WebControls.TextBox tbxORContNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.Label lblMfrInfo;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.TextBox tbxORUnPubCount;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblORItem;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
	
		public ORForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// 載入 歷史資料
				if(Context.Request.QueryString["fgnew"].ToString().Trim() == "1")
				{
					BindGrid();
				}
				else
				{
					// do nothing
				}
				
				// 給預設資料 - 新增Form
				InitialNewData();
				
				// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
				this.btnModify.Visible = false;
				this.lblORItem.Visible = false;


				// 顯示下拉式選單 郵寄類別代碼的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "mtp");
				ddlORmtpcd.DataSource=ds1;
				ddlORmtpcd.DataTextField="mtp_nm";
				ddlORmtpcd.DataValueField="mtp_mtpcd";
				ddlORmtpcd.DataBind();
				
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 載入舊資料
		private void BindGrid()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_or");
			DataView dv5 = ds5.Tables["c2_or"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr5 = "1=1";
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			string old_contno = "";
			if(Context.Request.QueryString["old_contno"].ToString().Trim() != "")
			{
				old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				rowfilterstr5 = rowfilterstr5 + " and or_contno = '" + old_contno + "'";
			}
			dv5.RowFilter = rowfilterstr5;
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv5.Count > 0)
			{			
				DataGrid1.DataSource=dv5;
				DataGrid1.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 發票類別代碼
					string mtpcd =  DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds1 = new DataSet();
					this.sqlDataAdapter1.Fill(ds1, "mtp");
					DataView dv1 = ds1.Tables["mtp"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr1 = "1=1";
					rowfilterstr1 = rowfilterstr1 + " AND mtp_mtpcd='" + mtpcd + "'";
					dv1.RowFilter = rowfilterstr1;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
					//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
					
					if(dv1.Count > 0)
					{
						// 抓出 郵寄類別相關資料
						string mtpnm = dv1[0]["mtp_nm"].ToString().Trim();
						DataGrid1.Items[i].Cells[14].Text = mtpnm;
					}
					else
					{
						DataGrid1.Items[i].Cells[14].Text = "（資料有誤)";
					}
					
					
					// 海外郵寄註記
					string fgmosea = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
					switch (fgmosea) 
					{
						case "0":
							DataGrid1.Items[i].Cells[15].Text = "國內";
							break;
						case "1":
							DataGrid1.Items[i].Cells[15].Text = "<font color='Red'>國外</font>";
							break;
						default:
							DataGrid1.Items[i].Cells[15].Text = "國內";
							break;
					}
					
				}
				
			}
			
		}
		
		
		// 給預設資料 - 新增Form
		private void InitialNewData()
		{
			// 設預設值: 有登本數 & 未登本數
			this.tbxORPubCount.Text = "0";
			this.tbxORUnPubCount.Text = "0";
			
			
			// 藉由前一網頁傳來的變數值字串 
			string contno = "";
			string old_contno = "";
			
			// 載入預設資料 - 合約書編號
			if(Context.Request.QueryString["contno"].ToString().Trim() != "" || Context.Request.QueryString["contno"].ToString().Trim() != null)
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				//Response.Write("contno= " + contno + "<BR>");
				tbxORContNo.Text = contno;
				
			}
			
			// 載入預設資料 - 參考之合約書編號, 以抓出其廠商編號及客戶資料
			if(Context.Request.QueryString["old_contno"].ToString().Trim() != "" || Context.Request.QueryString["old_contno"].ToString().Trim() != null)
			{
				old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				//Response.Write("old_contno= " + old_contno + "<BR>");
				
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c2_cont");
				DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND cont_contno='" + old_contno + "'";
				dv2.RowFilter = rowfilterstr2;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv2.Count > 0)
				{
					string custno = "";
					string mfrno = "";
					custno = dv2[0]["cont_custno"].ToString().Trim();
					mfrno = dv2[0]["cont_mfrno"].ToString().Trim();
					// 此網頁沒有顯示 廠商統編處, 故 disable 下一行
					//tbxORMfrNo.Text = mfrno;
					//Response.Write("custno= " + custno + "<br>");
					//Response.Write("mfrno= " + mfrno + "<br>");
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds3 = new DataSet();
					this.sqlDataAdapter3.Fill(ds3, "cust");
					DataView dv3 = ds3.Tables["cust"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr3 = "1=1";
					rowfilterstr3 = rowfilterstr3 + " AND cust_custno='" + custno + "'";
					dv3.RowFilter = rowfilterstr3;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
					//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
					
					if(dv3.Count > 0)
					{
						// 抓出 客戶相關資料
						string custnm = "";
						string custjbti = "";
						string custtel = "";
						string custfax = "";
						string custcell = "";
						string custemail = "";
						custnm = dv3[0]["cust_nm"].ToString().Trim();
						custjbti = dv3[0]["cust_jbti"].ToString().Trim();
						custtel = dv3[0]["cust_tel"].ToString().Trim();
						custfax = dv3[0]["cust_fax"].ToString().Trim();
						custcell = dv3[0]["cust_cell"].ToString().Trim();
						custemail = dv3[0]["cust_email"].ToString().Trim();
						
						if(custnm != "")
							this.tbxORName.Text = custnm;
						if(custjbti != "")
							this.tbxORJobTitle.Text = custjbti;
						if(custtel != "")
							this.tbxORTel.Text = custtel;
						if(custfax != "")
							this.tbxORFax.Text = custfax;
						if(custcell != "")
							this.tbxORCell.Text = custcell;
						if(custemail != "")
							this.tbxOREmail.Text = custemail;
					}
					
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "mfr");
					DataView dv4 = ds4.Tables["mfr"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr4 = "1=1";
					rowfilterstr4 = rowfilterstr4 + " AND mfr_mfrno='" + mfrno + "'";
					dv4.RowFilter = rowfilterstr4;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
					if(dv4.Count > 0)
					{
						// 抓出 廠商相關資料
						string mfrinm = "";
						string mfrzipcode = "";
						string mfraddr = "";
						mfrinm = dv4[0]["mfr_inm"].ToString().Trim();
						mfrzipcode = dv4[0]["mfr_izip"].ToString().Trim();
						mfraddr = dv4[0]["mfr_iaddr"].ToString().Trim();
						
						if(mfrinm != "")
							this.tbxORMfrIName.Text = mfrinm;
						if(mfrzipcode != "")
							this.tbxORZipcode.Text = mfrzipcode;
						if(mfraddr != "")
							this.tbxORAddr.Text = mfraddr;
						
						// 顯示廠商發票名稱及統編
						this.lblMfrNo.Text = mfrno;
						this.lblMfrInfo.Text = "預設廠商：" + mfrinm + " (" + mfrno + ")";
					}
					
				}
				
			}
		}
		
		
		// 儲存新增 按鈕
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// 執行 新增動作
			InsertToDB();
			
			DataGrid1.CurrentPageIndex=0;
			
			// Refresh Page
			BindGrid();
		}
		
		
		// 新增資料入 DB Table
		private void InsertToDB()
		{
			// 抓出 畫面上的值
			string strsyscd = "C2";
			string strcontno = this.tbxORContNo.Text.ToString().Trim();
			string strMfrinm = this.tbxORMfrIName.Text.ToString().Trim();
			string strORName = this.tbxORName.Text.ToString().Trim();
			string strORJobTitle = this.tbxORJobTitle.Text.ToString().Trim();
			string strORZipcode = this.tbxORZipcode.Text.ToString().Trim();
			string strORAddr = this.tbxORAddr.Text.ToString().Trim();
			string strORTel = this.tbxORTel.Text.ToString().Trim();
			string strORFax = this.tbxORFax.Text.ToString().Trim();
			string strORCell = this.tbxORCell.Text.ToString().Trim();
			string strOREmail = this.tbxOREmail.Text.ToString().Trim();
			string strPubCount = this.tbxORPubCount.Text.ToString().Trim();
			string strUnPubCount = this.tbxORUnPubCount.Text.ToString().Trim();
			string strORmtpcd = this.ddlORmtpcd.SelectedItem.Value.ToString().Trim();
			string strORfgmosea = this.ddlORfgmosea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strMfrinm= " + strMfrinm + "<br>");
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_or");
			DataView dv5 = ds5.Tables["c2_or"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND or_contno='" + strcontno + "'";
			dv5.RowFilter = rowfilterstr5;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// 抓出最新的 發票廠商收件人序號
			string strORItem = "";
			if (dv5.Count > 0)
			{
				strORItem = Convert.ToString(Convert.ToInt32(dv5[0]["or_oritem"].ToString().Trim())+1);
				if(strORItem.Length < 2)
					strORItem = "0" + strORItem;
			}
			else
			{
				strORItem = "01";
			}
			//Response.Write("strORItem= " + strORItem + "<br>");
			
			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand1.Parameters["@contno"].Value = strcontno;
			this.sqlCommand1.Parameters["@oritem"].Value = strORItem;
			this.sqlCommand1.Parameters["@inm"].Value = strMfrinm;
			this.sqlCommand1.Parameters["@nm"].Value = strORName;
			this.sqlCommand1.Parameters["@jbti"].Value = strORJobTitle;
			this.sqlCommand1.Parameters["@zip"].Value = strORZipcode;
			this.sqlCommand1.Parameters["@addr"].Value = strORAddr;
			this.sqlCommand1.Parameters["@tel"].Value = strORTel;
			this.sqlCommand1.Parameters["@fax"].Value = strORFax;
			this.sqlCommand1.Parameters["@cell"].Value = strORCell;
			this.sqlCommand1.Parameters["@email"].Value = strOREmail;
			this.sqlCommand1.Parameters["@pubcnt"].Value = strPubCount;
			this.sqlCommand1.Parameters["@unpubcnt"].Value = strUnPubCount;
			this.sqlCommand1.Parameters["@mtpcd"].Value = strORmtpcd;
			this.sqlCommand1.Parameters["@fgmosea"].Value = strORfgmosea;
			
			// 確認執行 sqlSelectCommand1 成功
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
			
			// 輸出執行結果
			if (ResultFlag1)
			{
				//Response.Write("新增成功!<br>");
				
				// 以 Javascript 的 window.alert() & window.close() 來告知訊息
				LiteralControl litAlert = new LiteralControl();
				//LiteralControl litCloseWin = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"新增成功\");</script>";
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				Page.Controls.Add(litAlert);
				//Page.Controls.Add(litCloseWin);
			}
			else
			{
				//Response.Write("新增失敗!<br>");
				
				// 以 Javascript 的 window.alert() & window.close() 來告知訊息
				LiteralControl litAlert = new LiteralControl();
				//LiteralControl litCloseWin = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"新增失敗\");</script>";
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				Page.Controls.Add(litAlert);
				//Page.Controls.Add(litCloseWin);
			}
			
		}
		
		
		// DataGrid1 之 修改按鈕 功能
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 抓出 PK 值, 將相關資料載入 新增Form 裡
			string strsyscd = "C2";
			string strcontno = Context.Request.QueryString["contno"].ToString().Trim();
			string strORItem = e.Item.Cells[2].Text.ToString().Trim();
			//Response.Write("strsyscd= " + strsyscd + ", ");
			//Response.Write("strcontno= " + strcontno + ", ");
			//Response.Write("strORItem= " + strORItem + "<br>");
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_or");
			DataView dv5 = ds5.Tables["c2_or"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND or_syscd='" + strsyscd + "'";
			rowfilterstr5 = rowfilterstr5 + " AND or_contno='" + strcontno + "'";
			rowfilterstr5 = rowfilterstr5 + " AND or_oritem='" + strORItem + "'";
			dv5.RowFilter = rowfilterstr5;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// 載入資料			
			if (dv5.Count > 0)
			{
				// 將序號顯示在 lblORItem; 否則修改時無法抓出其序號
				this.lblORItem.Visible = true;
				this.lblORItem.Text = strORItem;
				
				// 顯示其相關資料
				this.tbxORContNo.Text = strcontno;
				this.tbxORMfrIName.Text = dv5[0]["or_inm"].ToString().Trim();
				this.tbxORName.Text = dv5[0]["or_nm"].ToString().Trim();
				this.tbxORJobTitle.Text = dv5[0]["or_jbti"].ToString().Trim();
				this.tbxORZipcode.Text = dv5[0]["or_zip"].ToString().Trim();
				this.tbxORAddr.Text = dv5[0]["or_addr"].ToString().Trim();
				this.tbxORTel.Text = dv5[0]["or_tel"].ToString().Trim();
				this.tbxORFax.Text = dv5[0]["or_fax"].ToString().Trim();
				this.tbxORCell.Text = dv5[0]["or_cell"].ToString().Trim();
				this.tbxOREmail.Text = dv5[0]["or_email"].ToString().Trim();
				this.tbxORPubCount.Text = dv5[0]["or_pubcnt"].ToString().Trim();
				this.tbxORUnPubCount.Text = dv5[0]["or_unpubcnt"].ToString().Trim();
				this.ddlORmtpcd.SelectedItem.Value = dv5[0]["or_mtpcd"].ToString().Trim();
				this.ddlORfgmosea.SelectedItem.Value = dv5[0]["or_fgmosea"].ToString().Trim();	
			}
			
			// 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
			// 載入資料後, 須再按 儲存修改按鈕, 才會呼叫 btnModify_Click()
			this.btnModify.Visible = true;
			this.btnSave.Visible = false;
		}
		
		
		// DataGrid1 之 刪除按鈕 功能
		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 抓出 PK 值, 以稍後做 刪除動作
			string strsyscd = "C2";
			string strcontno = Context.Request.QueryString["contno"].ToString().Trim();
			string strORItem = e.Item.Cells[2].Text.ToString().Trim();
			//Response.Write("strsyscd= " + strsyscd + ", ");
			//Response.Write("strcontno= " + strcontno + ", ");
			//Response.Write("strORItem= " + strORItem + "<br>");
			
			// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
			this.sqlCommand2.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand2.Parameters["@contno"].Value = strcontno;
			this.sqlCommand2.Parameters["@oritem"].Value = strORItem;
			
			// 確認執行 sqlSelectCommand1 成功
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
			
			// 輸出執行結果
			if (ResultFlag2)
			{
				//Response.Write("刪除成功!<br>");
				
				// 以 Javascript 的 window.alert() & window.close() 來告知訊息
				LiteralControl litAlert = new LiteralControl();
				//LiteralControl litCloseWin = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"刪除成功\");</script>";
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				Page.Controls.Add(litAlert);
				//Page.Controls.Add(litCloseWin);
			}
			else
			{
				//Response.Write("刪除失敗!<br>");
				
				// 以 Javascript 的 window.alert() & window.close() 來告知訊息
				LiteralControl litAlert = new LiteralControl();
				//LiteralControl litCloseWin = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"刪除失敗\");</script>";
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				Page.Controls.Add(litAlert);
				//Page.Controls.Add(litCloseWin);
			}
			
			DataGrid1.CurrentPageIndex=0;
			
			// Refresh Page
			BindGrid();			
		}
		
		
		// 儲存修改 按鈕
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			// 執行 修改動作
			ModifyDB();
			
			DataGrid1.CurrentPageIndex=0;
			
			// Refresh Page
			BindGrid();
		}
		
		
		// 修改資料 from DB Table
		private void ModifyDB()
		{
			// 顯示欲修改之 雜誌收件人序號
			this.lblORItem.Visible = true;
			
			// 抓出 畫面上的值
			string strsyscd = "C2";
			string strcontno = this.tbxORContNo.Text.ToString().Trim();
			// 抓出其 收件人序號 (由 DataGrid1_ItemCommand() 帶出此值到 lblORItem )
			string strORItem = this.lblORItem.Text.ToString().Trim();
			string strMfrinm = this.tbxORMfrIName.Text.ToString().Trim();
			string strORName = this.tbxORName.Text.ToString().Trim();
			string strORJobTitle = this.tbxORJobTitle.Text.ToString().Trim();
			string strORZipcode = this.tbxORZipcode.Text.ToString().Trim();
			string strORAddr = this.tbxORAddr.Text.ToString().Trim();
			string strORTel = this.tbxORTel.Text.ToString().Trim();
			string strORFax = this.tbxORFax.Text.ToString().Trim();
			string strORCell = this.tbxORCell.Text.ToString().Trim();
			string strOREmail = this.tbxOREmail.Text.ToString().Trim();
			string strORPubCount = this.tbxORPubCount.Text.ToString().Trim();
			string strORUnPubCount = this.tbxORUnPubCount.Text.ToString().Trim();
			string strORmtpcd = this.ddlORmtpcd.SelectedItem.Value.ToString().Trim();
			string strORfgmosea = this.ddlORfgmosea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strimseq= " + strimseq + "<br>");
			//Response.Write("strIMName= " + strIMName + "<br>");
			
			// 執行 將值塞入 sqlCommand3.Parameters 中, 以執行 新增入資料庫
			// 注意: 此 sqlCommand3 (update) 須到 Web Form Designer generated code 處, 手動修改其 sql型別 由 Variant 改為如 VarChar 之類
			this.sqlCommand3.Parameters["@inm"].Value = strMfrinm;
			this.sqlCommand3.Parameters["@nm"].Value = strORName;
			this.sqlCommand3.Parameters["@jbti"].Value = strORJobTitle;
			this.sqlCommand3.Parameters["@zip"].Value = strORZipcode;
			this.sqlCommand3.Parameters["@addr"].Value = strORAddr;
			this.sqlCommand3.Parameters["@tel"].Value = strORTel;
			this.sqlCommand3.Parameters["@fax"].Value = strORFax;
			this.sqlCommand3.Parameters["@cell"].Value = strORCell;
			this.sqlCommand3.Parameters["@email"].Value = strOREmail;
			this.sqlCommand3.Parameters["@pubcnt"].Value = strORPubCount;
			this.sqlCommand3.Parameters["@unpubcnt"].Value = strORUnPubCount;
			this.sqlCommand3.Parameters["@mtpcd"].Value = strORmtpcd;
			this.sqlCommand3.Parameters["@fgmosea"].Value = strORfgmosea;
			this.sqlCommand3.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand3.Parameters["@contno"].Value = strcontno;
			this.sqlCommand3.Parameters["@oritem"].Value = strORItem;
			
			// 確認執行 sqlSelectCommand1 成功
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
			
			// 輸出執行結果
			if (ResultFlag3)
			{
				//Response.Write("修改成功!<br>");
				
				// 以 Javascript 的 window.alert() & window.close() 來告知訊息
				LiteralControl litAlert = new LiteralControl();
				//LiteralControl litCloseWin = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"修改成功\");</script>";
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				Page.Controls.Add(litAlert);
				//Page.Controls.Add(litCloseWin);
			}
			else
			{
				//Response.Write("修改失敗!<br>");
				
				// 以 Javascript 的 window.alert() & window.close() 來告知訊息
				LiteralControl litAlert = new LiteralControl();
				//LiteralControl litCloseWin = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"修改失敗\");</script>";
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				Page.Controls.Add(litAlert);
				//Page.Controls.Add(litCloseWin);
			}
			
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = @"INSERT INTO c2_or (or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea) VALUES (@syscd, @contno, @oritem, @inm, @nm, @jbti, @addr, @zip, @tel, @fax, @cell, @email, @mtpcd, @pubcnt, @unpubcnt, @fgmosea)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT cust_custno, cust_nm, cust_jbti, cust_tel, cust_fax, cust_cell, cust_email" +
				" FROM cust";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT cont_contid, cont_syscd, cont_contno, cont_mfrno, cont_custno FROM c2_cont" +
				"";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM mtp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																			   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																			   new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																			   new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																			   new System.Data.Common.DataColumnMapping("or_email", "or_email"),
																																																			   new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, o" +
				"r_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea F" +
				"ROM c2_or WHERE (or_syscd = \'C2\')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip FROM mfr";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "DELETE FROM c2_or WHERE (or_syscd = @syscd) AND (or_oritem = @oritem) AND (or_con" +
				"tno = @contno)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = @"UPDATE c2_or SET or_inm = @inm, or_nm = @nm, or_jbti = @jbti, or_addr = @addr, or_zip = @zip, or_tel = @tel, or_fax = @fax, or_cell = @cell, or_email = @email, or_mtpcd = @mtpcd, or_pubcnt = @pubcnt, or_unpubcnt = @unpubcnt, or_fgmosea = @fgmosea WHERE (or_syscd = @syscd) AND (or_contno = @contno) AND (or_oritem = @oritem)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
