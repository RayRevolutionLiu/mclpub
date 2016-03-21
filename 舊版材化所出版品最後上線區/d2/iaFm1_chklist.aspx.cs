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
	/// Summary description for iaFm1_chklist.
	/// </summary>
	public class iaFm1_chklist : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnAddIA;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Label lblContMessage;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.TextBox tbxIANo;
		protected System.Web.UI.WebControls.Label lblCont;
		protected System.Web.UI.WebControls.Label lblIA;
		protected System.Web.UI.WebControls.Label lblIAMessage;
	
		public iaFm1_chklist()
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
				
				if(Context.Request.QueryString["contno"].ToString().Trim() != "" && Context.Request.QueryString["imseq"].ToString().Trim() != "")
				{
					// 抓出剛產生的發票開立單編號
					GetNewIANo();
					
					// 載入合約資料
					BindGrid1();
				
					// 顯示發票資料
					BindGrid2();
				}
				else
				{
					this.lblCont.Visible = false;
					this.lblIA.Visible = false;
					
					this.DataGrid1.Visible = false;
					this.DataGrid2.Visible = false;
				}
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 返回首頁 按鈕
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("../default.aspx");
		}
		
		
		// 抓出剛產生的發票開立單編號
		private void GetNewIANo()
		{
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			//this.sqlSelectCommand1.Parameters.Add("@contno",SqlDbType.Char,6).Value = "C2" + strContNo;
			//this.sqlCommand1.Parameters.Add("@contno",SqlDbType.Char,6).Value = strContNo;
			this.sqlDataAdapter1.Fill(ds1, "ia");
			DataView dv1 = ds1.Tables["ia"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				string strIANo = dv1[0]["MaxIANno"].ToString().Trim();
				this.tbxIANo.Text = strIANo;
				//Response.Write("strIANo= " + strIANo + "<br>");
				
				string strIMSeq = "", strIMName = "";
				strIMSeq = Context.Request.QueryString["imseq"].ToString().Trim();
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "invmfr");
				DataView dv2 = ds2.Tables["invmfr"].DefaultView;
			
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr2 = "1=1";
				rowfilterstr2  = rowfilterstr2 + " AND im_contno='" + strContNo + "'";
				rowfilterstr2  = rowfilterstr2 + " AND im_imseq='" + strIMSeq + "'";
				dv2.RowFilter = rowfilterstr2;
			
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
				// 若搜尋結果為 "找不到" 的處理
				if (dv2.Count > 0)
				{
					strIMName = dv2[0]["im_nm"].ToString().Trim();
				}
				else
				{
					strIMName = "";
				}
				
				
				// 顯示總筆數
				this.lblContMessage.Text = "(合約編號／發票廠商：" + strContNo + "／" + strIMSeq + "-" + strIMName + ")";
				this.lblIAMessage.Text = "(發票開立單號：" + strIANo + ")";
				
				
				// 載入合約資料
				BindGrid1();
			}
			else
			{
				this.lblContMessage.Text = "無合約資料!";
				this.lblIAMessage.Text = "無開立發票資料!";
			}
		}
		
		
		// 顯示 DataGrid1 的資料項 -- 合約資料
		private void BindGrid1()
		{
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_cont");
			DataView dv3 = ds3.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND cont_syscd='C2'";
			rowfilterstr3 = rowfilterstr3 + " AND cont_contno='" + strContNo + "'";
			dv3.RowFilter = rowfilterstr3;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv3.Count > 0)
			{
				this.DataGrid1.Visible = true;
				DataGrid1.DataSource = dv3;
				DataGrid1.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 合約類別
					string conttp = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
					//Response.Write("conttp= " + conttp + "<br>");
					if(conttp == "01") 
						DataGrid1.Items[i].Cells[5].Text = "一般";
					else if(conttp == "09")
						DataGrid1.Items[i].Cells[5].Text = "<font color='Red'>推廣</font>";
					
					// 簽約日期
					string SignDate = DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
					SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
					//Response.Write("SignDate= " + SignDate + "<br>");
					DataGrid1.Items[i].Cells[6].Text = SignDate;
					
					// 合約起日
					string StartDate = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid1.Items[i].Cells[7].Text = StartDate;
					
					// 合約迄日
					string EndDate = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					//Response.Write("EndDate= " + EndDate + "<br>");
					DataGrid1.Items[i].Cells[8].Text = EndDate;
					
					// 結案註記
					string fgclosed = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
					//Response.Write("fgclosed= " + fgclosed + "<br>");
					if(fgclosed == "0") 
						DataGrid1.Items[i].Cells[16].Text = "否";
					else 
						DataGrid1.Items[i].Cells[16].Text = "<font color='Red'>是</font>";
				}
			}
		}
		
		
		// 顯示 DataGrid2 的資料項 -- 發票資料
		private void BindGrid2()
		{
			string strContNo, strIANo;
			strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			strIANo = this.tbxIANo.Text.ToString().Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "ia");
			DataView dv4 = ds4.Tables["ia"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr4 = "1=1";
			rowfilterstr4 = rowfilterstr4 + " AND ia_syscd = 'C2'";
			rowfilterstr4 = rowfilterstr4 + " AND ia_iano = '" + strIANo + "'";
			rowfilterstr4 = rowfilterstr4 + " AND ia_iasdate = '' ";
			rowfilterstr4 = rowfilterstr4 + " AND ia_iasseq = '' ";		
			rowfilterstr4 = rowfilterstr4 + " AND ia_iaitem = '' ";		
			rowfilterstr4 = rowfilterstr4 + " AND ia_contno = 'C2" + strContNo + "'";
			dv4.RowFilter = rowfilterstr4;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv4.Count > 0)
			{
				DataGrid2.DataSource=dv4;
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
		
		
		// 繼續開立 按鈕的處理
		private void btnAddIA_Click(object sender, System.EventArgs e)
		{
			// 轉址
			string strbuf = "iaFm1_Add.aspx";
			Response.Redirect(strbuf);
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_tel, im_invcd, im_taxtp" +
				", im_fgitri FROM invmfr";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT MAX(ia_iano) AS MaxIANno FROM ia WHERE (ia_syscd = \'C2\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_tel", "im_tel"),
																																																				new System.Data.Common.DataColumnMapping("im_invcd", "im_invcd"),
																																																				new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("MaxIANno", "MaxIANno")})});
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
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_fgclosed, c2_cont.cont_custno, RTRIM(cust.cust_nm) AS cust_nm, cust.cust_tel, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_cont.cont_oldcontno, c2_cont.cont_moddate, c2_cont.cont_fgpayonce, c2_cont.cont_modempno, c2_cont.cont_fgcancel, c2_cont.cont_credate, c2_cont.cont_fgtemp, c2_cont.cont_fgpubed, RTRIM(mfr.mfr_inm) AS mfr_inm, invmfr.im_imseq, RTRIM(invmfr.im_nm) AS im_nm, cust.cust_custno, invmfr.im_contno, invmfr.im_syscd, mfr.mfr_mfrno, RTRIM(book.bk_nm) AS bk_nm, RTRIM(srspn.srspn_cname) AS srspn_cname, book.bk_bkcd, srspn.srspn_empno, c2_cont.cont_totjtm, c2_cont.cont_tottm FROM c2_cont INNER JOIN invmfr ON c2_cont.cont_syscd = invmfr.im_syscd AND c2_cont.cont_contno = invmfr.im_contno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno WHERE (c2_cont.cont_fgpayonce = '1') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_fgpubed = '1')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, ia.ia_iasseq, ia.ia_iaitem, ia.ia_iano, ia.ia_refno, RTRIM(ia.ia_mfrno) AS ia_mfrno, ia.ia_pyno, ia.ia_pyseq, ia.ia_pyat, ia.ia_ivat, ia.ia_invno, ia.ia_invdate, ia.ia_fgitri, RTRIM(ia.ia_rnm) AS ia_rnm, RTRIM(ia.ia_raddr) AS ia_raddr, RTRIM(ia.ia_rzip) AS ia_rzip, RTRIM(ia.ia_rjbti) AS ia_rjbti, RTRIM(ia.ia_rtel) AS ia_rtel, ia.ia_fgnonauto, ia.ia_invcd, ia.ia_taxtp, ia.ia_status, RTRIM(ia.ia_cname) AS ia_cname, RTRIM(ia.ia_tel) AS ia_tel, ia.ia_contno, iad.iad_iadid, iad.iad_syscd, iad.iad_iano, iad.iad_iaditem, iad.iad_fk1, iad.iad_fk2, iad.iad_fk3, iad.iad_fk4, iad.iad_projno, iad.iad_costctr, RTRIM(iad.iad_desc) AS iad_desc, iad.iad_qty, iad.iad_unit, iad.iad_uprice, iad.iad_amt, RTRIM(mfr.mfr_inm) AS mfr_inm FROM ia INNER JOIN iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN c2_cont ON iad.iad_fk1 = c2_cont.cont_contno INNER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno WHERE (c2_cont.cont_fgpayonce = '1') ORDER BY ia.ia_iano DESC";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnAddIA.Click += new System.EventHandler(this.btnAddIA_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		
		
		
		
	}
}
