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
	/// Summary description for iaFm2_Rec.
	/// </summary>
	public class iaFm2_Rec : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.Label lblIMName;
		protected System.Web.UI.WebControls.TextBox tbxIMName;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.Label lblIANo;
		protected System.Web.UI.WebControls.TextBox tbxIANo;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblMemo2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxIMSeq;
		protected System.Web.UI.WebControls.TextBox tbxIMName2;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
	
		public iaFm2_Rec()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
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
		
		
		// 網頁預設值
		private void InitialData()
		{
			this.cbx1.Checked = true;
			this.cbx2.Checked = false;
			this.cbx3.Checked = false;
			
			this.lblMfrNo.Text = "";
			this.tbxMfrIName.Text = "";
			this.tbxIMName.Text = "";
			this.tbxIANo.Text = "";
			
			
			this.DataGrid1.Visible = false;
			this.DataGrid2.Visible = false;
		}
		
		
		// 查詢 按鈕的處理
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			if(this.tbxMfrIName.Text.ToString().Trim() != "" || this.tbxIMName.Text.ToString().Trim() != "")
			{
				BindGrid1();
			}
			else if(this.tbxMfrIName.Text.ToString().Trim() == "" && this.tbxIMName.Text.ToString().Trim() == "" && this.tbxIANo.Text.ToString().Trim() == "")
			{
				this.lblMessage.Text = "您並未輸入條件, 無法查詢!";
				InitialData();
			}
			if(this.tbxIANo.Text.ToString().Trim() != "")
			{
				BindGrid2();
			}
		}
		
		
		// 清除資料 按鈕的處理
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			InitialData();
		}
		
		
		// 顯示資料 DataGrid1
		private void BindGrid1()
		{
			// 抓出篩選條件
			string strMfrIName = this.tbxMfrIName.Text.ToString().Trim();
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			//Response.Write("strMfrIName=" + strMfrIName + "<br>");
			//Response.Write("strIMName=" + strIMName + "<br>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			if(this.cbx1.Checked)
				rowfilterstr1 = rowfilterstr1 + " AND mfr_inm Like '%" + strMfrIName + "%'";
			if(this.cbx2.Checked)
				rowfilterstr1 = rowfilterstr1 + " AND im_nm Like '%" + strIMName + "%'";
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			if(dv1.Count > 0)
			{
				this.DataGrid1.Visible = true;
				
				this.lblMessage.Text = "查有 " + dv1.Count + " 筆資料";
				this.lblMemo2.Visible = false;
				
				string MfrIName = dv1[0]["mfr_inm"].ToString().Trim();
				string MfrNo = dv1[0]["cont_mfrno"].ToString().Trim();
				this.lblMfrNo.Text = "(廠商名稱：" + MfrIName + "；廠商統編：" + MfrNo + ")";
				this.tbxMfrNo.Text = dv1[0]["cont_mfrno"].ToString().Trim();
				
				
				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 合約類別
					string conttp = DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
					//Response.Write("conttp= " + conttp + "<br>");
					if(conttp == "01") 
						DataGrid1.Items[i].Cells[6].Text = "一般";
					else if(conttp == "09")
						DataGrid1.Items[i].Cells[6].Text = "<font color='Red'>推廣</font>";
					
					// 簽約日期
					string SignDate = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
					SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
					//Response.Write("SignDate= " + SignDate + "<br>");
					DataGrid1.Items[i].Cells[7].Text = SignDate;
					
					// 合約起日
					string StartDate = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid1.Items[i].Cells[8].Text = StartDate;
					
					// 合約迄日
					string EndDate = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					//Response.Write("EndDate= " + EndDate + "<br>");
					DataGrid1.Items[i].Cells[9].Text = EndDate;
					
					// 結案註記
					string fgclosed = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
					//Response.Write("fgclosed= " + fgclosed + "<br>");
					if(fgclosed == "0") 
						DataGrid1.Items[i].Cells[17].Text = "否";
					else 
						DataGrid1.Items[i].Cells[17].Text = "<font color='Red'>是</font>";
				}
			}
			else
			{
				this.DataGrid1.Visible = false;
				this.lblMemo2.Visible = false;
				
				this.lblMessage.Text = "查無資料!";
				this.lblMfrNo.Text = "無此廠商編號";
			}
		}
		
		
		// DataGrid1 確認挑選 按鈕的處理
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Select")
			{
				// 抓出 ItemTemplate 之 RadioButton 型態之 cbxUpdate (Controls[1])
				//bool strSelectIM = ((RadioButton)DataGrid1.Items[i].Cells[0].FindControl("rabSelectIMSeq")).Checked;
				string strContNo = e.Item.Cells[1].Text.ToString().Trim();
				string strIMSeq = e.Item.Cells[2].Text.ToString().Trim();
				string strIMName = e.Item.Cells[3].Text.ToString().Trim();
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strIMSeq " + strIMSeq + "<br>");
				//Response.Write("strIMName " + strIMName + "<br>");
				
				// 寫入隱藏值
				this.tbxContNo.Text = strContNo;
				this.tbxIMSeq.Text = strIMSeq;
				this.tbxIMName2.Text = strIMName;
				
				
				// 繼續挑選發票開立單編號
				this.DataGrid1.Visible = false;
				BindGrid2();
			}
		}
		
		
		// DataGrid1 換頁處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid1();
		}
		
		
		// 顯示資料 DataGrid2 - 繼續挑選發票開立單編號
		private void BindGrid2()
		{
			// 抓出篩選條件
			string strMfrNo = this.tbxMfrNo.Text.ToString().Trim();
			string strContNo = "";
			string strIMSeq = "";
			string strIMName = "";
			string strIANo = "";
			if(this.tbxIANo.Text.ToString().Trim() != "")
				strIANo = this.tbxIANo.Text.ToString().Trim();
			if(this.tbxContNo.Text.ToString().Trim() != "" && this.tbxIMSeq.Text.ToString() != "")
			{
				strContNo = this.tbxContNo.Text.ToString().Trim();
				strIMSeq = this.tbxIMSeq.Text.ToString();
				strIMName = this.tbxIMName2.Text.ToString().Trim();
			}
			else
			{
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "ia");
				DataView dv3 = ds3.Tables["ia"].DefaultView;
			
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr3 = "1=1";
				rowfilterstr3 = rowfilterstr3 + " AND ia_iano='" + strIANo + "'";
				dv3.RowFilter = rowfilterstr3;
				
				// 
				if(dv3.Count > 0)
				{
					strContNo = dv3[0]["ia_contno"].ToString().Trim();
					strContNo = strContNo.Substring(2, 6);
					strIMSeq = dv3[0]["im_imseq"].ToString().Trim();
					strIMName = dv3[0]["ia_rnm"].ToString().Trim();
					this.tbxContNo.Text = strContNo;
					this.tbxIMSeq.Text = strIMSeq;
					this.tbxIMName2.Text = strIMName;
				}
			}
			
			// 先檢查該合約是否有未開發票的落版資料, 若無, 不予轉址
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "ia");
			DataView dv2 = ds2.Tables["ia"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			if(this.cbx3.Checked == true)
			{
				rowfilterstr2 = rowfilterstr2 + " AND ia_iano = '" + strIANo + "'";
			}
			else
			{
				rowfilterstr2 = rowfilterstr2 + " AND ia_mfrno ='" + strMfrNo + "'";
				rowfilterstr2 = rowfilterstr2 + " AND ia_contno = 'C2" + strContNo + "'";
				rowfilterstr2 = rowfilterstr2 + " AND ia_rnm = '" + strIMName + "'";
			}
			dv2.RowFilter = rowfilterstr2;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			if(dv2.Count > 0)
			{
				this.DataGrid1.Visible = false;
				this.DataGrid2.Visible = true;
				
				this.lblMessage.Text = "合約編號 " + strContNo + " 有 " + dv2.Count + " 筆發票開立單資料!";
				this.lblMemo1.Visible = false;
				this.lblMemo2.Visible = true;
				
				
				DataGrid2.DataSource = dv2;
				DataGrid2.DataBind();
				
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid2.Items.Count ; i++)
				{
					// 發票類別
					string invcd = DataGrid2.Items[i].Cells[9].Text.ToString().Trim();
					//Response.Write("invcd= " + invcd + "<br>");
					switch(invcd)
					{
						case "2":
							DataGrid2.Items[i].Cells[9].Text = "二聯式";
							break;
						case "3":
							DataGrid2.Items[i].Cells[9].Text = "三聯式";
							break;
						case "4":
							DataGrid2.Items[i].Cells[9].Text = "其他";
							break;
						default:
							DataGrid2.Items[i].Cells[9].Text = "三聯式";
							break;
					}
					
					// 發票類別
					string taxtp = DataGrid2.Items[i].Cells[10].Text.ToString().Trim();
					//Response.Write("taxtp= " + taxtp + "<br>");
					switch(taxtp)
					{
						case "1":
							DataGrid2.Items[i].Cells[10].Text = "應稅5%";
							break;
						case "2":
							DataGrid2.Items[i].Cells[10].Text = "零稅";
							break;
						case "3":
							DataGrid2.Items[i].Cells[10].Text = "免稅";
							break;
						default:
							DataGrid2.Items[i].Cells[10].Text = "應稅5%";
							break;
					}
					
					// 發票狀態
					string status = DataGrid2.Items[i].Cells[11].Text.ToString().Trim();
					//Response.Write("status= " + status + "<br>");
					switch(status)
					{
						case " ":
							DataGrid2.Items[i].Cells[11].Text = "已產生開立單";
							break;
						case "v":
							DataGrid2.Items[i].Cells[11].Text = "已產生開立清單";
							break;
						case "5":
							DataGrid2.Items[i].Cells[11].Text = "已列印開立單";
							break;
						case "7":
							DataGrid2.Items[i].Cells[11].Text = "已轉sap";
							break;
						default:
							DataGrid2.Items[i].Cells[11].Text = "已產生開立單";
							break;
					}
					
					// 發票號碼
					string invno = DataGrid2.Items[i].Cells[12].Text.ToString().Trim();
					//Response.Write("invno= " + invno + "<br>");
					if(invno != "")
						DataGrid2.Items[i].Cells[12].Text = invno;
					else
						DataGrid2.Items[i].Cells[12].Text = "(尚無)";
				}
			}
			else
			{
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlertInv1 = new LiteralControl();
				litAlertInv1.Text = "<script language=javascript>alert(\"無發票開立單資料!\");</script>";
				Page.Controls.Add(litAlertInv1);
			}
		}
		
		
		// DataGrid2 按鈕處理
		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Select")
			{
				// 判斷是否可做 回復動作
				string strContNo = this.tbxContNo.Text.ToString().Trim();
				string strIMSeq = this.tbxIMSeq.Text.ToString().Trim();
				string strIANo = e.Item.Cells[1].Text.ToString();
				string strIAStatus = e.Item.Cells[13].Text.ToString();
				//Response.Write("strIAStatus= " + strIAStatus + "<br>");
				
				// 轉址
				if(strIAStatus == " ")
				{
					string strbuf = "iaFm2_Recia.aspx?contno=" + strContNo + "&imseq=" + strIMSeq + "&iano=" + strIANo;
					Response.Redirect(strbuf);
				}
				else
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlertInv1 = new LiteralControl();
					litAlertInv1.Text = "<script language=javascript>alert(\"此狀態不予許做回復動作!\");</script>";
					Page.Controls.Add(litAlertInv1);
				}
			}
		}
		
		
		// DataGrid2 換頁處理
		private void DataGrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid2.CurrentPageIndex = e.NewPageIndex;
			BindGrid2();
		}
		
		
		#region Web Form Designer generated code
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged);
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
																																																			new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, ia.ia_iasseq, ia.ia_iaitem, ia.ia_iano, ia.ia_refno, ia.ia_mfrno, ia.ia_pyno, ia.ia_pyseq, ia.ia_pyat, ia.ia_ivat, ia.ia_invno, ia.ia_invdate, ia.ia_fgitri, ia.ia_rnm, ia.ia_raddr, ia.ia_rzip, ia.ia_rjbti, ia.ia_rtel, ia.ia_fgnonauto, ia.ia_invcd, ia.ia_taxtp, ia.ia_status, ia.ia_cname, ia.ia_tel, ia.ia_contno, RTRIM(mfr.mfr_inm) AS mfr_inm FROM ia INNER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (ia.ia_syscd = 'C2') AND (ia.ia_status = ' ')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT DISTINCT ia.ia_syscd, ia.ia_iano, RTRIM(ia.ia_mfrno) AS ia_mfrno, RTRIM(ia.ia_contno) AS ia_contno, RTRIM(ia.ia_rnm) AS ia_rnm, invmfr.im_imseq FROM ia INNER JOIN invmfr ON ia.ia_syscd = invmfr.im_syscd AND ia.ia_rnm = invmfr.im_nm WHERE (ia.ia_syscd = 'C2') ORDER BY ia.ia_iano";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
