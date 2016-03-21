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
	/// Summary description for ContFm_show.
	/// </summary>
	public class ContFm_show : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrFax;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblfgClosedMessage;
		protected System.Web.UI.WebControls.TextBox tbxSignDate;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblOldContNo;
		protected System.Web.UI.WebControls.DropDownList ddlContType;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxStartDate;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.RadioButtonList rblfgPayOnce;
		protected System.Web.UI.WebControls.TextBox tbxTotalJTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalTime;
		protected System.Web.UI.WebControls.TextBox tbxChangeJTime;
		protected System.Web.UI.WebControls.TextBox tbxFreeTime;
		protected System.Web.UI.WebControls.TextBox tbxDiscount;
		protected System.Web.UI.WebControls.TextBox tbxTotalAmt;
		protected System.Web.UI.WebControls.TextBox tbxColorTime;
		protected System.Web.UI.WebControls.TextBox tbxGetColorTime;
		protected System.Web.UI.WebControls.TextBox tbxMenoTime;
		protected System.Web.UI.WebControls.TextBox tbxAuName;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.Label lblORPunCnt;
		protected System.Web.UI.WebControls.Label lblORUnPubCnt;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Web.UI.WebControls.RadioButtonList rblfgCancel;
		protected System.Web.UI.WebControls.RadioButtonList rblfgClosed;
		protected System.Web.UI.WebControls.Label lblCreateDate;
		protected System.Web.UI.WebControls.Label lblModifyDate;
		protected System.Web.UI.WebControls.DropDownList ddlModEmpNo;
		protected System.Web.UI.WebControls.TextBox tbxMadeJTime;
		protected System.Web.UI.WebControls.TextBox tbxPubTime;
		protected System.Web.UI.WebControls.TextBox tbxRestJTime;
		protected System.Web.UI.WebControls.TextBox tbxRestTime;
		protected System.Web.UI.WebControls.TextBox tbxPaidAmt;
		protected System.Web.UI.WebControls.TextBox tbxRestAmt;
		protected System.Web.UI.WebControls.TextBox tbxADAmt;
		protected System.Web.UI.WebControls.TextBox tbxPubAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxPubChangeAmt;
		protected System.Web.UI.WebControls.Label lblOldContMessage;
		protected System.Web.UI.WebControls.TextBox tbxFreeBookCount;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Web.UI.WebControls.TextBox tbxRestClrtm;
		protected System.Web.UI.WebControls.TextBox tbxRestGetClrtm;
		protected System.Web.UI.WebControls.TextBox tbxRestMenotm;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.HtmlControls.HtmlTextArea tarContRemark;
		
		public ContFm_show()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// 隱藏所有的 輸入欄位, 不允許修改
				DisabledAll();
				
				
				// 抓出 廠商及客戶資料 區之資料, 藉由前一網頁傳來的變數值字串 custno
				GetMfrCust();
				
				// 抓出網頁初始值, 如動態下拉式選單 (由DB來), 系統日期等 - 主要為 合約書基本資料區
				InitialData();
				
				// 顯示 合約書編號
				if(Context.Request.QueryString["old_contno"].ToString().Trim() != "" || Context.Request.QueryString["old_contno"].ToString().Trim() != null)
				{
					this.lblContNo.Text = Context.Request.QueryString["old_contno"].ToString().Trim();
				}
				
				// 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
				LoadOldCont();
				
				// 載入 發票廠商收件人 & 雜誌收件人 之歷史資料 (依據 old_contno)
				BindGrid1();
				BindGrid2();
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 隱藏所有的 tbx輸入欄位, 不允許修改 (lbl 欄位不必 disable; 否則顯示時, 文字會不清楚)
		private void DisabledAll()
		{
			// 合約書基本資料 區 
			this.tbxSignDate.Enabled = false;
			this.ddlContType.Enabled = false;
			this.ddlBookCode.Enabled = false;
			this.tbxStartDate.Enabled = false;
			this.tbxEndDate.Enabled = false;
			this.ddlEmpNo.Enabled = false;
			this.rblfgPayOnce.Enabled = false;
			this.rblfgClosed.Enabled = false;
			this.ddlModEmpNo.Enabled = false;
			this.rblfgCancel.Enabled = false;
			//this.lblOldContNo.Enabled = false;
			//this.lblCreateDate.Enabled = false;
			//this.lblModifyDate.Enabled = false;
			
			// 合約書細節 區
			this.tbxTotalJTime.Enabled = false;
			this.tbxMadeJTime.Enabled = false;
			this.tbxRestJTime.Enabled = false;
			this.tbxTotalTime.Enabled = false;
			this.tbxPubTime.Enabled = false;
			this.tbxRestTime.Enabled = false;
			this.tbxTotalAmt.Enabled = false;
			this.tbxPaidAmt.Enabled = false;
			this.tbxRestAmt.Enabled = false;
			this.tbxChangeJTime.Enabled = false;
			this.tbxFreeTime.Enabled = false;
			this.tbxADAmt.Enabled = false;
			this.tbxDiscount.Enabled = false;
			this.tbxFreeBookCount.Enabled = false;
			this.tbxPubAdAmt.Enabled = false;
			this.tbxPubChangeAmt.Enabled = false;
			this.tbxColorTime.Enabled = false;
			this.tbxGetColorTime.Enabled = false;
			this.tbxMenoTime.Enabled = false;
			this.tbxRestClrtm.Enabled = false;
			this.tbxRestGetClrtm.Enabled = false;
			this.tbxRestMenotm.Enabled = false;
			
			// 廣告聯絡人 區
			this.tbxAuName.Enabled = false;
			this.tbxAuTel.Enabled = false;
			this.tbxAuFax.Enabled = false;
			this.tbxAuCell.Enabled = false;
			this.tbxAuEmail.Enabled = false;
			
			// 備註 區 - tarContRemark (Html Control) 已使用 disable 屬性 Disable 了
		}
		
		
		
		// 抓出 廠商及客戶資料 區之資料 
		private void GetMfrCust()
		{
			// 藉由前一網頁傳來的變數值字串 custno
			string custno = "";
			
			// 若有客戶編號, 則指定顯示之
			if(Context.Request.QueryString["custno"].ToString().Trim() != "" || Context.Request.QueryString["custno"].ToString().Trim() != null)
			{
				custno = Context.Request.QueryString["custno"].ToString().Trim();
				//Response.Write("custno= " + custno + "<BR>");
				lblCustNo.Text = custno;
				
				
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "cust");
				DataView dv1 = ds1.Tables["cust"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr = "1=1";
				rowfilterstr = rowfilterstr + " AND cust_custno='" + custno + "'";
				dv1.RowFilter = rowfilterstr;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv1.Count > 0)
				{
					// 藉由前一網頁傳來的變數值字串 custno
					this.lblCustName.Text = dv1[0]["cust_nm"].ToString().Trim();
					
					///抓出該客戶之廠商統編 mfrno (藉 cust_mfrno)
					string mfrno = dv1[0]["cust_mfrno"].ToString().Trim();
					//Response.Write("mfrno= " + mfrno + "<BR>");
					
					// 若此廠商不存在, 則顯示 顯示 "無資料" 資訊; 否則, 顯示其相關資料
					if(mfrno == "9999999999")
					{
						this.lblMfrIName.Text = "<font color='RED'>無對應統一編號</font>";
						this.lblMfrNo.Text = mfrno;
						this.lblMfrRespName.Text = "<font color='Gray'>無資料</font>";
						this.lblMfrRespJobTitle.Text = "<font color='Gray'>無資料</font>";
						this.lblMfrTel.Text = "<font color='Gray'>無資料</font>";
						this.lblMfrFax.Text = "<font color='Gray'>無資料</font>";
					}
					else
					{
						this.lblMfrNo.Text = mfrno;
						
						// 再藉 廠商統編 mfrno, 抓其相關資料
						if(dv1[0]["mfr_inm"].ToString().Trim() != "")
							this.lblMfrIName.Text = dv1[0]["mfr_inm"].ToString().Trim();
						else
							this.lblMfrIName.Text = "<font color='Gray'>無資料</font>";
						
						if(dv1[0]["mfr_respnm"].ToString().Trim() != "")
							this.lblMfrRespName.Text = dv1[0]["mfr_respnm"].ToString().Trim();
						else
							this.lblMfrRespName.Text = "<font color='Gray'>無資料</font>";
						
						if(dv1[0]["mfr_respjbti"].ToString().Trim() != "")
							this.lblMfrRespJobTitle.Text = dv1[0]["mfr_respjbti"].ToString().Trim();
						else
							this.lblMfrRespJobTitle.Text = "<font color='Gray'>無資料</font>";
						
						if(dv1[0]["mfr_tel"].ToString().Trim() != "")
							this.lblMfrTel.Text = dv1[0]["mfr_tel"].ToString().Trim();
						else
							this.lblMfrTel.Text = "<font color='Gray'>無資料</font>";
						
						if(dv1[0]["mfr_fax"].ToString().Trim() != "")
							this.lblMfrFax.Text = dv1[0]["mfr_fax"].ToString().Trim();
						else
							this.lblMfrFax.Text = "<font color='Gray'>無資料</font>";
					}
				}
					// 若找無資料, 則清除資料
				else
				{
					this.lblMfrNo.Text = "<font color='Gray'>查無此廠商統編</font>";			
					//					this.lblMfrIName.Text = "<font color='Gray'>無資料</font>";
					this.lblMfrRespName.Text = "<font color='Gray'>無資料</font>";
					this.lblMfrRespJobTitle.Text = "<font color='Gray'>無資料</font>";
					this.lblMfrTel.Text = "<font color='Gray'>無資料</font>";
					this.lblMfrFax.Text = "<font color='Gray'>無資料</font>";
					
					this.lblCustName.Text = "(<font color='RED'>查無此客戶編號</font>)";
					this.lblCustNo.Text = "<font color='Gray'>無資料</font>";
				}
			
			// 結束 if  // 若有客戶編號, 則指定顯示之
			}
		}
		
		
		// 抓出網頁初始值, 如動態下拉式選單 (由DB來), 系統日期等 - 主要為 合約書基本資料區
		private void InitialData()
		{
			// 合約書基本資料 區
			
			// 顯示 簽約日期及合約起迄日 之預設值: 抓系統日期之值	
			// 顯示 合約迄日 之預設: 系統年月 + 加 11個月
			this.tbxSignDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
			this.tbxStartDate.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
			//tbxEndDate.Value=System.DateTime.Today.AddDays(364).ToString("yyyy/MM");
			this.tbxEndDate.Text = System.DateTime.Today.AddMonths(11).ToString("yyyy/MM").Trim();
			
			// 最後修改日期之預設值
			//Response.Write("tbxStartDate.Value= " + tbxStartDate.Value + "<br>");
			//Response.Write("hiddenModDate.Value= " + hiddenModDate.Value + "<br>");
			
			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter2.Select statement; 
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "book");
			DataView dv2=ds2.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv2;
			dv2.RowFilter="proj_fgitri=''";
			ddlBookCode.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();
			
			// 顯示下拉式選單 業務員的 DB 值
			// **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "srspn");
			ddlEmpNo.DataSource=ds3;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();
			
			// 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
			// 顯示下拉式選單 修改業務員的 DB 值
			// **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
			DataSet ds8 = new DataSet();
			this.sqlDataAdapter3.Fill(ds8, "srspn");
			ddlModEmpNo.DataSource=ds8;
			ddlModEmpNo.DataTextField="srspn_cname";
			ddlModEmpNo.DataValueField="srspn_empno";
			ddlModEmpNo.DataBind();
			
			
			// 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_Add.aspx.cs 處不同處 
			// 抓出登入者的工號, 作為預設 建檔業務員 之值
			
			// 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_Add.aspx.cs 處不同處
			// 指定並顯示新的 合約書編號
			
		}
		
		
		// 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
		private void LoadOldCont()
		{
			// 抓出網頁變數: 客戶編號 
			string strOldContNo = Context.Request.QueryString["old_contno"].ToString().Trim();
			//Response.Write("strOldContNo= "+ strOldContNo + "<BR>");
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "c2_cont");
			DataView dv4 = ds4.Tables["c2_cont"].DefaultView;
				
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string rowfilterstr4 = "1=1";
			rowfilterstr4 = rowfilterstr4 + " AND cont_contno='" + strOldContNo + "'";
			dv4.RowFilter = rowfilterstr4;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
				
			// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
			if(dv4.Count > 0)
			{
				// 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
				// 合約書基本資料 區
				string SignDate = dv4[0]["cont_signdate"].ToString().Trim();
				SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
				this.tbxSignDate.Text = SignDate;
				string conttp = dv4[0]["cont_conttp"].ToString().Trim();
				int intConttpIndex = 0;
				if(conttp=="01")
					intConttpIndex = 0;
				else
					intConttpIndex = 1;
				this.ddlContType.SelectedIndex = intConttpIndex;
				this.ddlBookCode.SelectedIndex = Convert.ToInt32(dv4[0]["cont_bkcd"].ToString().Trim())-1;
				string StartDate = dv4[0]["cont_sdate"].ToString().Trim();
				//StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
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
				this.tbxStartDate.Text = StartDate;
				string EndDate = dv4[0]["cont_edate"].ToString().Trim();
				//EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
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
				this.tbxEndDate.Text = EndDate;
				
				// 抓出下拉式選單 業務員之資料
				// 註: 下一行並不能正確顯示其 index, 它只能指向第一個 index (0)
				//this.ddlEmpNo.SelectedItem.Value = dv4[0]["cont_empno"].ToString().Trim();
				this.ddlEmpNo.Items.FindByValue(dv4[0]["cont_empno"].ToString().Trim()).Selected = true;
				// 註: 下一行並不能正確顯示其 index, 且 rblfgPayOnce 的 Selected="True" 要關閉
				//this.rblfgPayOnce.SelectedItem.Value = dv4[0]["cont_fgpayonce"].ToString().Trim();
				if(Convert.ToString(this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim())) != "")
					this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim()).Selected = true;
				//else
					//this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim()).Selected = false;
				
				// 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
				this.rblfgClosed.Items.FindByValue(dv4[0]["cont_fgclosed"].ToString().Trim()).Selected = true;
				this.ddlModEmpNo.Items.FindByValue(dv4[0]["cont_modempno"].ToString().Trim()).Selected = true;
				this.rblfgCancel.Items.FindByValue(dv4[0]["cont_fgcancel"].ToString().Trim()).Selected = true;
				// 顯示 lblOldContMessage 訊息 : 判斷是否為 第一張合約 或 有歷史參考資料
				string OldContNo = dv4[0]["cont_oldcontno"].ToString().Trim();
				if(OldContNo == "0")
					this.lblOldContMessage.Text = "(無歷史資料, 此為新合約)";
				else
					this.lblOldContMessage.Text = OldContNo;
				string CreateDate = dv4[0]["cont_credate"].ToString().Trim();
				CreateDate = CreateDate.Substring(0, 4) + "/" + CreateDate.Substring(4, 2) + "/" + CreateDate.Substring(6, 2);
				this.lblCreateDate.Text = CreateDate;
				string ModifyDate = dv4[0]["cont_moddate"].ToString().Trim();
				ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
				this.lblModifyDate.Text = ModifyDate;
				
				
				// 合約書細節 區
				this.tbxTotalJTime.Text = dv4[0]["cont_totjtm"].ToString().Trim();
				this.tbxMadeJTime.Text = dv4[0]["cont_madejtm"].ToString().Trim();
				this.tbxRestJTime.Text = dv4[0]["cont_restjtm"].ToString().Trim();
				this.tbxTotalTime.Text = dv4[0]["cont_tottm"].ToString().Trim();
				this.tbxPubTime.Text = dv4[0]["cont_pubtm"].ToString().Trim();
				this.tbxRestTime.Text = dv4[0]["cont_resttm"].ToString().Trim();
				this.tbxTotalAmt.Text = dv4[0]["cont_totamt"].ToString().Trim();
				this.tbxPaidAmt.Text = dv4[0]["cont_paidamt"].ToString().Trim();
				this.tbxRestAmt.Text = dv4[0]["cont_restamt"].ToString().Trim();
				this.tbxChangeJTime.Text = dv4[0]["cont_chgjtm"].ToString().Trim();
				this.tbxFreeTime.Text = dv4[0]["cont_freetm"].ToString().Trim();
				this.tbxADAmt.Text = dv4[0]["cont_adamt"].ToString().Trim();
				this.tbxDiscount.Text = dv4[0]["cont_disc"].ToString().Trim();
				this.tbxFreeBookCount.Text = dv4[0]["cont_freebkcnt"].ToString().Trim();
				this.tbxPubAdAmt.Text = dv4[0]["cont_pubamt"].ToString().Trim();
				this.tbxPubChangeAmt.Text = dv4[0]["cont_chgamt"].ToString().Trim();
				this.tbxColorTime.Text = dv4[0]["cont_clrtm"].ToString().Trim();
				this.tbxGetColorTime.Text = dv4[0]["cont_getclrtm"].ToString().Trim();
				this.tbxMenoTime.Text = dv4[0]["cont_menotm"].ToString().Trim();
				string strfgPubed = dv4[0]["cont_fgpubed"].ToString().Trim();
				this.tbxRestClrtm.Text = dv4[0]["cont_restclrtm"].ToString().Trim();
				this.tbxRestGetClrtm.Text = dv4[0]["cont_restgetclrtm"].ToString().Trim();
				this.tbxRestMenotm.Text = dv4[0]["cont_restmenotm"].ToString().Trim();
				
				// 廣告聯絡人 區
				this.tbxAuName.Text = dv4[0]["cont_aunm"].ToString().Trim();
				this.tbxAuTel.Text = dv4[0]["cont_autel"].ToString().Trim();
				this.tbxAuFax.Text = dv4[0]["cont_aufax"].ToString().Trim();
				this.tbxAuCell.Text = dv4[0]["cont_aucell"].ToString().Trim();
				this.tbxAuEmail.Text = dv4[0]["cont_auemail"].ToString().Trim();
				
				// 備註 區 : Html Control 必須 Runat=server, 才能在 aspx.cs 中呼叫使用
				// 且在 .cs 必須自己加註 protected System.Web.UI.HtmlControls.HtmlTextArea tarContRemark;
				if(dv4[0]["cont_remark"].ToString().Trim() != "")
				{
					//Response.Write("cont_remark= " + dv4[0]["cont_remark"].ToString().Trim() + "<br>");
					this.tarContRemark.Value = dv4[0]["cont_remark"].ToString().Trim();
				}
			}
		}
		
		
		// 顯示 DataGrid1 資料
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 載入資料
			BindGrid1();
		}
		
		
		// 載入 發票廠商收件人資料
		private void BindGrid1()
		{
			// 抓出 篩選條件
			string strsyscd = "C2";
			string strConto = this.lblContNo.Text.ToString().Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "invmfr");
			DataView dv5 = ds5.Tables["invmfr"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND im_syscd='" + strsyscd + "'";
			rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strConto + "'";
			dv5.RowFilter = rowfilterstr5;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// 若有歷史資料, 則載入資料	
			if (dv5.Count > 0)
			{
				// 顯示其相關資料
				DataGrid1.DataSource=dv5;
				DataGrid1.DataBind();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 發票類別
					string invcd =  DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
					switch (invcd) 
					{
						case "2":
							DataGrid1.Items[i].Cells[10].Text = "二聯";
							break;
						case "3":
							DataGrid1.Items[i].Cells[10].Text = "三聯";
							break;
						case "4":
							DataGrid1.Items[i].Cells[10].Text = "其他";
							break;
						case "9":
							DataGrid1.Items[i].Cells[10].Text = "不清楚";
							DataGrid1.Items[i].Cells[10].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[10].Text = "三聯";
							break;
					}
					
					// 發票課稅別
					string taxtp = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
					switch (taxtp) 
					{
						case "1":
							DataGrid1.Items[i].Cells[11].Text = "應稅5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[11].Text = "零稅";
							break;
						case "3":
							DataGrid1.Items[i].Cells[11].Text = "免稅";
							break;
						case "9":
							DataGrid1.Items[i].Cells[11].Text = "不清楚";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[11].Text = "應稅5%";
							break;
					}
					
					// 院所內註記
					string fgItri = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					switch (fgItri) 
					{
						case "":
							DataGrid1.Items[i].Cells[12].Text = "否";
							break;
						case "06":
							DataGrid1.Items[i].Cells[12].Text = "<font color='Red'>所內</font>";
							break;
						case "07":
							DataGrid1.Items[i].Cells[12].Text = "<font color='Red'>院內</font>";
							break;
						default:
							DataGrid1.Items[i].Cells[12].Text = "否";
							break;
					}
					
				}
				
			}
			
		}
		
		
		// 顯示 DataGrid2 資料
		private void Datagrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 載入資料
			BindGrid2();
		}
		
		
		// 載入 發票廠商收件人資料
		private void BindGrid2()
		{
			// 抓出 篩選條件
			string strsyscd = "C2";
			string strConto = this.lblContNo.Text.ToString().Trim();
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "c2_or");
			DataView dv6 = ds6.Tables["c2_or"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr6 = "1=1";
			rowfilterstr6 = rowfilterstr6 + " AND or_syscd='" + strsyscd + "'";
			rowfilterstr6 = rowfilterstr6 + " AND or_contno='" + strConto + "'";
			dv6.RowFilter = rowfilterstr6;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
			//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");
			
			// 若有歷史資料, 則載入資料	
			if (dv6.Count > 0)
			{
				// 顯示其相關資料
				Datagrid2.DataSource=dv6;
				Datagrid2.DataBind();
				
				int PubCount = 0;
				int UnPubCount = 0;
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< Datagrid2.Items.Count ; i++)
				{
					// 發票類別代碼
					string mtpcd =  Datagrid2.Items[i].Cells[12].Text.ToString().Trim();
					
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds7 = new DataSet();
					this.sqlDataAdapter7.Fill(ds7, "mtp");
					DataView dv7 = ds7.Tables["mtp"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr7 = "1=1";
					rowfilterstr7 = rowfilterstr7 + " AND mtp_mtpcd='" + mtpcd + "'";
					dv7.RowFilter = rowfilterstr7;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
					//Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");
					
					if(dv7.Count > 0)
					{
						// 抓出 郵寄類別相關資料
						string mtpnm = dv7[0]["mtp_nm"].ToString().Trim();
						Datagrid2.Items[i].Cells[12].Text = mtpnm;
					}
					else
					{
						Datagrid2.Items[i].Cells[12].Text = "（資料有誤)";
					}
					
					
					// 海外郵寄註記
					string fgmosea = Datagrid2.Items[i].Cells[13].Text.ToString().Trim();
					switch (fgmosea) 
					{
						case "0":
							Datagrid2.Items[i].Cells[13].Text = "國內";
							break;
						case "1":
							Datagrid2.Items[i].Cells[13].Text = "<font color='Red'>國外</font>";
							break;
						default:
							Datagrid2.Items[i].Cells[13].Text = "國內";
							break;
					}
					
					// 抓出 各行 有登本數 & 未登本數 之加總值
					PubCount += int.Parse(Datagrid2.Items[i].Cells[10].Text.ToString().Trim());
					UnPubCount += int.Parse(Datagrid2.Items[i].Cells[11].Text.ToString().Trim());
				}
				
				// 顯示 總計：有登本數 & 未登本數
				//Response.Write("Toal PubCount= " + PubCount + "<br>");
				//Response.Write("Toal UnPubCount= " + UnPubCount + "<br>");
				this.lblORPunCnt.Text = Convert.ToString(PubCount);
				this.lblORUnPubCnt.Text = Convert.ToString(UnPubCount);
			}
			
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.Datagrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_ItemCommand);
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = "SELECT mtp_mtpcd, mtp_nm FROM mtp";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, o" +
				"r_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea F" +
				"ROM c2_or";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, " +
				"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM invmfr WHE" +
				"RE (im_syscd = \'C2\')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'e\') AND (srspn_atype <> \'f\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, RTRIM(proj.proj_fgitri) AS proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd, proj.proj_fgitri AS Expr1 FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cust.cust_custid, cust.cust_custno, RTRIM(cust.cust_nm) AS cust_nm, RTRIM(cust.cust_mfrno) AS cust_mfrno, cust.cust_jbti, cust.cust_tel, cust.cust_fax, mfr.mfr_mfrid, RTRIM(mfr.mfr_mfrno) AS mfr_mfrno, RTRIM(mfr.mfr_inm) AS mfr_inm, RTRIM(mfr.mfr_respnm) AS mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, RTRIM(mfr.mfr_fax) AS mfr_fax, RTRIM(mfr.mfr_iaddr) AS mfr_iaddr, mfr.mfr_izip, mfr.mfr_regdate, cust.cust_cell, cust.cust_email, RTRIM(cust.cust_oldcustno) AS cust_oldcustno, RTRIM(cust.cust_orgisyscd) AS cust_orgisyscd, cust.cust_regdate, cust.cust_moddate, mfr.mfr_mfrno AS Expr1 FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno")})});
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
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_orgisyscd", "cust_orgisyscd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate")})});
			// 
			// sqlDataAdapter7
			// 
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
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
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adamt", "cont_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freebkcnt", "cont_freebkcnt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_remark", "cont_remark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restclrtm", "cont_restclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restmenotm", "cont_restmenotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restgetclrtm", "cont_restgetclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_njtpcnt", "cont_njtpcnt")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_modempno, cont_fgcancel, cont_credate, cont_adamt, cont_freebkcnt, cont_remark, cont_fgtemp, cont_fgpubed, cont_restclrtm, cont_restmenotm, cont_restgetclrtm, cont_njtpcnt FROM c2_cont";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		
		
		
	}
}
