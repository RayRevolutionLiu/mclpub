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
	/// Summary description for InvMfrForm.
	/// </summary>
	public class InvMfrForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxIMSysCode;
		protected System.Web.UI.WebControls.TextBox tbxIMMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxIMName;
		protected System.Web.UI.WebControls.TextBox tbxIMJobTitle;
		protected System.Web.UI.WebControls.TextBox tbxIMZipcode;
		protected System.Web.UI.WebControls.TextBox tbxIMTel;
		protected System.Web.UI.WebControls.TextBox tbxIMFax;
		protected System.Web.UI.WebControls.TextBox tbxIMCell;
		protected System.Web.UI.WebControls.TextBox tbxIMEmail;
		protected System.Web.UI.WebControls.DropDownList ddlIMInvtp;
		protected System.Web.UI.WebControls.DropDownList ddlIMTaxtp;
		protected System.Web.UI.WebControls.TextBox tbxIMAddr;
		protected System.Web.UI.WebControls.DropDownList ddlIMfgITRI;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Label lblImSeq;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Label lblMfrInfo;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.TextBox tbxIMContNo;
	
		public InvMfrForm()
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
				BindGrid();
				
				// 給預設資料 - 新增Form
				InitialNewData();
				
				// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
				this.btnModify.Visible = false;
				this.lblImSeq.Visible = false;
				
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
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr = "1=1";
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
			
			string old_contno = "";
			if(Context.Request.QueryString["old_contno"].ToString().Trim() != "")
			{
				old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				rowfilterstr = rowfilterstr + " and im_contno = '" + old_contno + "'";
			}
			dv4.RowFilter = rowfilterstr;
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv4.Count > 0)
			{			
				DataGrid1.DataSource=dv4;
				DataGrid1.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 發票類別
					string invcd =  DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					switch (invcd) 
					{
						case "2":
							DataGrid1.Items[i].Cells[12].Text = "二聯";
							break;
						case "3":
							DataGrid1.Items[i].Cells[12].Text = "三聯";
							break;
						case "4":
							DataGrid1.Items[i].Cells[12].Text = "其他";
							break;
						default:
							DataGrid1.Items[i].Cells[12].Text = "三聯";
							break;
					}
					
					// 發票課稅別
					string taxtp = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
					switch (invcd) 
					{
						case "1":
							DataGrid1.Items[i].Cells[13].Text = "應稅5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[13].Text = "零稅";
							break;
						case "3":
							DataGrid1.Items[i].Cells[13].Text = "免稅";
							break;
						default:
							DataGrid1.Items[i].Cells[13].Text = "應稅5%";
							break;
					}
					
					// 院所內註記
					string fgItri = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
					switch (fgItri) 
					{
						case "":
							DataGrid1.Items[i].Cells[14].Text = "否";
							break;
						case "06":
							DataGrid1.Items[i].Cells[14].Text = "<font color='Red'>所內</font>";
							break;
						case "07":
							DataGrid1.Items[i].Cells[14].Text = "<font color='Red'>院內</font>";
							break;
						default:
							DataGrid1.Items[i].Cells[14].Text = "否";
							break;
					}
					
				}
			}
			
		}
		
		
		// 給預設資料 - 新增Form
		private void InitialNewData()
		{
			// 藉由前一網頁傳來的變數值字串 
			string contno = "";
			string old_contno = "";
			
			// 載入預設資料 - 合約書編號
			if(Context.Request.QueryString["contno"].ToString().Trim() != "" || Context.Request.QueryString["contno"].ToString().Trim() != null)
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				//Response.Write("contno= " + contno + "<BR>");
				tbxIMContNo.Text = contno;
				
			}
			
			// 載入預設資料 - 參考之合約書編號, 以抓出其廠商編號及客戶資料
			if(Context.Request.QueryString["old_contno"].ToString().Trim() != "" || Context.Request.QueryString["old_contno"].ToString().Trim() != null)
			{
				old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				//Response.Write("old_contno= " + old_contno + "<BR>");
				
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c2_cont");
				DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr1 = "1=1";
				rowfilterstr1 = rowfilterstr1 + " AND cont_contno='" + old_contno + "'";
				dv1.RowFilter = rowfilterstr1;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv1.Count > 0)
				{
					string custno = "";
					string mfrno = "";
					custno = dv1[0]["cont_custno"].ToString().Trim();
					mfrno = dv1[0]["cont_mfrno"].ToString().Trim();
					// 顯示 廠商統編
					tbxIMMfrNo.Text = mfrno;
					//Response.Write("custno= " + custno + "<br>");
					//Response.Write("mfrno= " + mfrno + "<br>");
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds2 = new DataSet();
					this.sqlDataAdapter2.Fill(ds2, "cust");
					DataView dv2 = ds2.Tables["cust"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr2 = "1=1";
					rowfilterstr2 = rowfilterstr2 + " AND cust_custno='" + custno + "'";
					dv2.RowFilter = rowfilterstr2;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
					//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
					
					if(dv2.Count > 0)
					{
						// 抓出 客戶相關資料
						string custnm = "";
						string custjbti = "";
						string custtel = "";
						string custfax = "";
						string custcell = "";
						string custemail = "";
						custnm = dv2[0]["cust_nm"].ToString().Trim();
						custjbti = dv2[0]["cust_jbti"].ToString().Trim();
						custtel = dv2[0]["cust_tel"].ToString().Trim();
						custfax = dv2[0]["cust_fax"].ToString().Trim();
						custcell = dv2[0]["cust_cell"].ToString().Trim();
						custemail = dv2[0]["cust_email"].ToString().Trim();
						
						if(custnm != "")
							this.tbxIMName.Text = custnm;
						if(custjbti != "")
							this.tbxIMJobTitle.Text = custjbti;
						if(custtel != "")
							this.tbxIMTel.Text = custtel;
						if(custfax != "")
							this.tbxIMFax.Text = custfax;
						if(custcell != "")
							this.tbxIMCell.Text = custcell;
						if(custemail != "")
							this.tbxIMEmail.Text = custemail;

						// 顯示 客戶編號 (not visible)
						this.lblCustNo.Text = custno;
					}
					
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds3 = new DataSet();
					this.sqlDataAdapter3.Fill(ds3, "mfr");
					DataView dv3 = ds3.Tables["mfr"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr3 = "1=1";
					rowfilterstr3 = rowfilterstr3 + " AND mfr_mfrno='" + mfrno + "'";
					dv3.RowFilter = rowfilterstr3;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
					//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
					
					if(dv3.Count > 0)
					{
						// 抓出 廠商相關資料
						string mfrinm = "";
						string mfrzipcode = "";
						string mfraddr = "";
						mfrinm = dv3[0]["mfr_inm"].ToString().Trim();
						mfrzipcode = dv3[0]["mfr_izip"].ToString().Trim();
						mfraddr = dv3[0]["mfr_iaddr"].ToString().Trim();
						
						if(mfrzipcode != "")
							this.tbxIMZipcode.Text = mfrzipcode;
						if(mfraddr != "")
							this.tbxIMAddr.Text = mfraddr;
						
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
			string strcontno = this.tbxIMContNo.Text.ToString().Trim();
			string strMfrno = this.tbxIMMfrNo.Text.ToString().Trim();
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			string strIMJobTitle = this.tbxIMJobTitle.Text.ToString().Trim();
			string strIMZipcode = this.tbxIMZipcode.Text.ToString().Trim();
			string strIMAddr = this.tbxIMAddr.Text.ToString().Trim();
			string strIMTel = this.tbxIMTel.Text.ToString().Trim();
			string strIMFax = this.tbxIMFax.Text.ToString().Trim();
			string strIMCell = this.tbxIMCell.Text.ToString().Trim();
			string strIMEmail = this.tbxIMEmail.Text.ToString().Trim();
			string strIMinvcd = this.ddlIMInvtp.SelectedItem.Value.ToString().Trim();
			string strIMtaxtp = this.ddlIMTaxtp.SelectedItem.Value.ToString().Trim();
			string strIMfgitri = this.ddlIMfgITRI.SelectedItem.Value.ToString().Trim();
			//Response.Write("strMfrno= " + strMfrno + "<br>");
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND im_contno='" + strcontno + "'";
			dv4.RowFilter = rowfilterstr;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
			
			// 抓出最新的 發票廠商收件人序號
			string strimseq = "";
			if (dv4.Count > 0)
			{
				strimseq = Convert.ToString(Convert.ToInt32(dv4[0]["im_imseq"].ToString().Trim())+1);
				if(strimseq.Length < 2)
					strimseq = "0" + strimseq;
			}
			else
			{
				strimseq = "01";
			}
			//Response.Write("strimseq= " + strimseq + "<br>");
			
			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand1.Parameters["@contno"].Value = strcontno;
			this.sqlCommand1.Parameters["@imseq"].Value = strimseq;
			this.sqlCommand1.Parameters["@mfrno"].Value = strMfrno;
			this.sqlCommand1.Parameters["@nm"].Value = strIMName;
			this.sqlCommand1.Parameters["@jbti"].Value = strIMJobTitle;
			this.sqlCommand1.Parameters["@zip"].Value = strIMZipcode;
			this.sqlCommand1.Parameters["@addr"].Value = strIMAddr;
			this.sqlCommand1.Parameters["@tel"].Value = strIMTel;
			this.sqlCommand1.Parameters["@fax"].Value = strIMFax;
			this.sqlCommand1.Parameters["@cell"].Value = strIMCell;
			this.sqlCommand1.Parameters["@email"].Value = strIMEmail;
			this.sqlCommand1.Parameters["@invcd"].Value = strIMinvcd;
			this.sqlCommand1.Parameters["@taxtp"].Value = strIMtaxtp;
			this.sqlCommand1.Parameters["@fgitri"].Value = strIMfgitri;
			
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
			string strimseq = e.Item.Cells[2].Text.ToString().Trim();
			//Response.Write("strsyscd= " + strsyscd + ", ");
			//Response.Write("strcontno= " + strcontno + ", ");
			//Response.Write("strimseq= " + strimseq + "<br>");
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND im_syscd='" + strsyscd + "'";
			rowfilterstr = rowfilterstr + " AND im_contno='" + strcontno + "'";
			rowfilterstr = rowfilterstr + " AND im_imseq='" + strimseq + "'";
			dv4.RowFilter = rowfilterstr;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
			
			// 載入資料			
			if (dv4.Count > 0)
			{
				// 將序號顯示在 lblIMSeq; 否則修改時無法抓出其序號
				this.lblImSeq.Visible = true;
				this.lblImSeq.Text = strimseq;
				
				// 顯示其相關資料
				this.tbxIMContNo.Text = strcontno;
				this.tbxIMMfrNo.Text = dv4[0]["im_mfrno"].ToString().Trim();
				this.tbxIMName.Text = dv4[0]["im_nm"].ToString().Trim();
				this.tbxIMJobTitle.Text = dv4[0]["im_jbti"].ToString().Trim();
				this.tbxIMZipcode.Text = dv4[0]["im_zip"].ToString().Trim();
				this.tbxIMAddr.Text = dv4[0]["im_addr"].ToString().Trim();
				this.tbxIMTel.Text = dv4[0]["im_tel"].ToString().Trim();
				this.tbxIMFax.Text = dv4[0]["im_fax"].ToString().Trim();
				this.tbxIMCell.Text = dv4[0]["im_cell"].ToString().Trim();
				this.tbxIMEmail.Text = dv4[0]["im_email"].ToString().Trim();
				this.ddlIMInvtp.SelectedItem.Value = dv4[0]["im_invcd"].ToString().Trim();
				this.ddlIMTaxtp.SelectedItem.Value = dv4[0]["im_taxtp"].ToString().Trim();
				this.ddlIMfgITRI.SelectedItem.Value = dv4[0]["im_fgitri"].ToString().Trim();
			}
			
			// 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
			// 載入資料後, 須再按 儲存修改按鈕, 才會呼叫 btnModify_Click()
			this.btnModify.Visible = true;
			this.btnSave.Visible = false;
		}
		

		
		// DataGrid1 刪除按鈕 功能
		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 抓出 PK 值, 以稍後做 刪除動作
			string strsyscd = "C2";
			string strcontno = Context.Request.QueryString["contno"].ToString().Trim();
			string strimseq = e.Item.Cells[2].Text.ToString().Trim();
			//Response.Write("strsyscd= " + strsyscd + ", ");
			//Response.Write("strcontno= " + strcontno + ", ");
			//Response.Write("strimseq= " + strimseq + "<br>");
			
			// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
			this.sqlCommand2.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand2.Parameters["@contno"].Value = strcontno;
			this.sqlCommand2.Parameters["@imseq"].Value = strimseq;
			
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
			// 顯示欲修改之 發票廠商收件人序號
			this.lblImSeq.Visible = true;
			
			// 抓出 畫面上的值
			string strsyscd = "C2";
			string strcontno = this.tbxIMContNo.Text.ToString().Trim();
			// 抓出其 收件人序號 (由 DataGrid1_ItemCommand() 帶出此值到 lblImSeq )
			string strimseq = this.lblImSeq.Text.ToString().Trim();
			string strMfrno = this.tbxIMMfrNo.Text.ToString().Trim();
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			string strIMJobTitle = this.tbxIMJobTitle.Text.ToString().Trim();
			string strIMZipcode = this.tbxIMZipcode.Text.ToString().Trim();
			string strIMAddr = this.tbxIMAddr.Text.ToString().Trim();
			string strIMTel = this.tbxIMTel.Text.ToString().Trim();
			string strIMFax = this.tbxIMFax.Text.ToString().Trim();
			string strIMCell = this.tbxIMCell.Text.ToString().Trim();
			string strIMEmail = this.tbxIMEmail.Text.ToString().Trim();
			string strIMinvcd = this.ddlIMInvtp.SelectedItem.Value.ToString().Trim();
			string strIMtaxtp = this.ddlIMTaxtp.SelectedItem.Value.ToString().Trim();
			string strIMfgitri = this.ddlIMfgITRI.SelectedItem.Value.ToString().Trim();
			//Response.Write("strimseq= " + strimseq + "<br>");
			//Response.Write("strIMName= " + strIMName + "<br>");
			
			// 執行 將值塞入 sqlCommand3.Parameters 中, 以執行 新增入資料庫
			// 注意: 此 sqlCommand3 (update) 須到 Web Form Designer generated code 處, 手動修改其 sql型別 由 Variant 改為如 VarChar 之類
			this.sqlCommand3.Parameters["@mfrno"].Value = strMfrno;
			this.sqlCommand3.Parameters["@nm"].Value = strIMName;
			this.sqlCommand3.Parameters["@jbti"].Value = strIMJobTitle;
			this.sqlCommand3.Parameters["@zip"].Value = strIMZipcode;
			this.sqlCommand3.Parameters["@addr"].Value = strIMAddr;
			this.sqlCommand3.Parameters["@tel"].Value = strIMTel;
			this.sqlCommand3.Parameters["@fax"].Value = strIMFax;
			this.sqlCommand3.Parameters["@cell"].Value = strIMCell;
			this.sqlCommand3.Parameters["@email"].Value = strIMEmail;
			this.sqlCommand3.Parameters["@invcd"].Value = strIMinvcd;
			this.sqlCommand3.Parameters["@taxtp"].Value = strIMtaxtp;
			this.sqlCommand3.Parameters["@fgitri"].Value = strIMfgitri;
			this.sqlCommand3.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand3.Parameters["@contno"].Value = strcontno;
			this.sqlCommand3.Parameters["@imseq"].Value = strimseq;
			
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
		
		
		
		// 關閉視窗
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = @"UPDATE invmfr SET im_mfrno = @mfrno, im_nm = @nm, im_jbti = @jbti, im_zip = @zip, im_addr = @addr, im_tel = @tel, im_fax = @fax, im_cell = @cell, im_email = @email, im_invcd = @invcd, im_taxtp = @taxtp, im_fgitri = @fgitri WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_imseq = @imseq)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_email", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "DELETE FROM invmfr WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_im" +
				"seq = @imseq)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = @"INSERT INTO invmfr (im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri) VALUES (@syscd, @contno, @imseq, @mfrno, @nm, @jbti, @zip, @addr, @tel, @fax, @cell, @email, @invcd, @taxtp, @fgitri)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_email", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fgitri", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip FROM mfr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT cust_custno, cust_nm, cust_jbti, cust_tel, cust_fax, cust_cell, cust_email" +
				" FROM cust";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT cont_contid, cont_syscd, cont_contno, cont_mfrno, cont_custno FROM c2_cont" +
				"";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_jbti", "im_jbti"),
																																																				new System.Data.Common.DataColumnMapping("im_zip", "im_zip"),
																																																				new System.Data.Common.DataColumnMapping("im_addr", "im_addr"),
																																																				new System.Data.Common.DataColumnMapping("im_tel", "im_tel"),
																																																				new System.Data.Common.DataColumnMapping("im_fax", "im_fax"),
																																																				new System.Data.Common.DataColumnMapping("im_cell", "im_cell"),
																																																				new System.Data.Common.DataColumnMapping("im_email", "im_email"),
																																																				new System.Data.Common.DataColumnMapping("im_invcd", "im_invcd"),
																																																				new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im" +
				"_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd FROM invmfr WHE" +
				"RE (im_syscd = \'C2\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
