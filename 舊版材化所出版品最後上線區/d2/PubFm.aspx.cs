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
	/// Summary description for PubFm.
	/// </summary>
	public class PubFm : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox tbxSysCode;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxBookName;
		protected System.Web.UI.WebControls.TextBox tbxBkcd;
		protected System.Web.UI.WebControls.Label lblYYYMMMessage;
		protected System.Web.UI.WebControls.TextBox tbxStartDate;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.Label lblContMessage;
		protected System.Web.UI.WebControls.Label lblTotjtm;
		protected System.Web.UI.WebControls.TextBox tbxTotjtm;
		protected System.Web.UI.WebControls.Label lblTottm;
		protected System.Web.UI.WebControls.TextBox tbxTottm;
		protected System.Web.UI.WebControls.Label lblChgjtm;
		protected System.Web.UI.WebControls.TextBox tbxChgjtm;
		protected System.Web.UI.WebControls.Label lblTotamt;
		protected System.Web.UI.WebControls.TextBox tbxTotamt;
		protected System.Web.UI.WebControls.Label lblContAdamt;
		protected System.Web.UI.WebControls.TextBox tbxContAdamt;
		protected System.Web.UI.WebControls.Label lblProjCostMessage;
		protected System.Web.UI.WebControls.Label lblProjNo;
		protected System.Web.UI.WebControls.Label lblCostCtr;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnLoadData;
		protected System.Web.UI.WebControls.Label lblPubSeq;
		protected System.Web.UI.WebControls.TextBox tbxPageNo;
		protected System.Web.UI.WebControls.DropDownList ddlColorCode;
		protected System.Web.UI.WebControls.DropDownList ddlLTypeCode;
		protected System.Web.UI.WebControls.DropDownList ddlPageSizeCode;
		protected System.Web.UI.WebControls.Label lblAddMessage;
		protected System.Web.UI.WebControls.RadioButtonList rblfgfixpage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter8;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter9;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.TextBox tbxAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxChgAmt;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.DropDownList ddlNJTypeCode;
		protected System.Web.UI.WebControls.RadioButtonList rblfggot;
		protected System.Web.UI.WebControls.Panel pnlNjtp;
		protected System.Web.UI.WebControls.Panel pnlChg;
		protected System.Web.UI.WebControls.Panel pnlOrig;
		protected System.Web.UI.WebControls.DropDownList ddlChgBookCode;
		protected System.Web.UI.WebControls.TextBox tbxChgjno;
		protected System.Web.UI.WebControls.TextBox tbxChgbkno;
		protected System.Web.UI.WebControls.RadioButtonList rblfgrechg;
		protected System.Web.UI.WebControls.DropDownList ddlOrigBookCode;
		protected System.Web.UI.WebControls.TextBox tbxOrigjno;
		protected System.Web.UI.WebControls.TextBox tbxOrigbkno;
		protected System.Web.UI.WebControls.DropDownList ddlDraftType;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter10;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter11;
		protected System.Web.UI.WebControls.Button btnGoChkList;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter12;
		protected System.Data.SqlClient.SqlCommand sqlCommand4;
		// 自訂 Html Controls
		protected System.Web.UI.HtmlControls.HtmlInputText tbxYYYYMM;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter13;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter14;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter15;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter16;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter17;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter18;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter19;
		protected System.Web.UI.WebControls.Label lblClrtm;
		protected System.Web.UI.WebControls.TextBox tbxClrtm;
		protected System.Web.UI.WebControls.Label lblGetClrtm;
		protected System.Web.UI.WebControls.TextBox tbxGetClrtm;
		protected System.Web.UI.WebControls.Label lblMenotm;
		protected System.Web.UI.WebControls.TextBox tbxMenotm;
		protected System.Web.UI.WebControls.Label lblFreetm;
		protected System.Web.UI.WebControls.TextBox tbxFreetm;
		protected System.Web.UI.WebControls.Label lblIMCount;
		protected System.Data.SqlClient.SqlCommand sqlCommand5;
		protected System.Web.UI.WebControls.DropDownList ddlIMSeq;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter20;
		protected System.Web.UI.WebControls.ImageButton imbIMRefresh;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPgNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter21;
		protected System.Web.UI.WebControls.Literal litWinOpen1;
		protected System.Web.UI.WebControls.Literal litWinAlert1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter22;
		protected System.Web.UI.WebControls.Label lblPubCounts;
		protected System.Web.UI.WebControls.Label lblDraftCounts;
		protected System.Web.UI.WebControls.Label lblAmtCounts;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand10;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand11;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand12;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand13;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand14;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand15;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand16;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand17;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand18;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand19;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand20;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand21;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand22;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenIMfgitri;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCustNo;
		protected System.Web.UI.WebControls.Label lblfgITRI;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxBkpPno;
		
		
		public PubFm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// 抓預設資料 (廠商客戶資料) - 新增Form
				InitialData();
				
				// 給預設值, 如刊登年月, 書籍期別
				//NewData();
				
				// 預設: 隱藏 落版序號; 按下 修改時才會顯示
				this.lblPubSeq.Visible = false;
				
				
				// 檢查是否 已落版 (0: 否; 1: 是)
				if(Context.Request.QueryString["fgnew"].ToString().Trim() == "0")
				{
					// do nothing 不載入 (無初始資料)
					this.lblAddMessage.Text = "無初始資料, 請自行新增!<br>";
				}
				else
				{
					BindGrid1();
				}
				//BindGrid1();
			}
			
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 給預設資料 - 新增Form
		private void InitialData()
		{
			this.hiddenMfrNo.Value = "";
			this.hiddenCustNo.Value = "";
			this.hiddenIMfgitri.Value = "";
			
			
			// 顯示下拉式選單 廣告色彩的 DB 值
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_clr");
			ddlColorCode.DataSource=ds3;
			ddlColorCode.DataTextField="clr_nm";
			ddlColorCode.DataValueField="clr_clrcd";
			ddlColorCode.DataBind();
			
			// 顯示下拉式選單 廣告版面的 DB 值
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "c2_ltp");
			ddlLTypeCode.DataSource=ds4;
			ddlLTypeCode.DataTextField="ltp_nm";
			ddlLTypeCode.DataValueField="ltp_ltpcd";
			ddlLTypeCode.DataBind();
			
			// 顯示下拉式選單 廣告篇幅的 DB 值
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_pgs");
			ddlPageSizeCode.DataSource=ds5;
			ddlPageSizeCode.DataTextField="pgs_nm";
			ddlPageSizeCode.DataValueField="pgs_pgscd";
			ddlPageSizeCode.DataBind();
			
			// 顯示下拉式選單 新稿製法的 DB 值
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "c2_njtp");
			ddlNJTypeCode.DataSource=ds6;
			ddlNJTypeCode.DataTextField="njtp_nm";
			ddlNJTypeCode.DataValueField="njtp_njtpcd";
			ddlNJTypeCode.DataBind();
			
			// 顯示下拉式選單 舊稿書類的 DB 值
			DataSet ds7 = new DataSet();
			this.sqlDataAdapter7.Fill(ds7, "book");
			DataView dv7=ds7.Tables["book"].DefaultView;
			ddlOrigBookCode.DataSource=dv7;
			dv7.RowFilter="proj_fgitri=''";
			ddlOrigBookCode.DataTextField="bk_nm";
			ddlOrigBookCode.DataValueField="bk_bkcd";
			ddlOrigBookCode.DataBind();
			
			// 顯示下拉式選單 改稿書類的 DB 值
			DataSet ds72 = new DataSet();
			this.sqlDataAdapter7.Fill(ds72, "book");
			ddlChgBookCode.DataSource=ds72;
			ddlChgBookCode.DataTextField="bk_nm";
			ddlChgBookCode.DataValueField="bk_bkcd";
			ddlChgBookCode.DataBind();
			
			string strbkcd = "";
			if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
			{
				strbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
			}
			else
			{
				strbkcd = "";
			}
			//Response.Write("strbkcd= " + strbkcd + "<br>");
			this.tbxBkcd.Text = strbkcd;
			
			
			// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
			this.btnSave.Visible = true;
			this.btnModify.Visible = false;
			this.btnLoadData.Visible = true;
			this.btnGoChkList.Visible = true;
			this.lblPubSeq.Visible = false;
			
			// 隱藏不同的稿件類別
			this.ddlLTypeCode.SelectedIndex = 0;
			this.ddlColorCode.SelectedIndex = 0;
			this.ddlPageSizeCode.SelectedIndex = 0;
			this.ddlDraftType.SelectedIndex = 0;
			this.ddlOrigBookCode.SelectedIndex = 0;
			this.rblfggot.Visible = false;
			this.pnlOrig.Visible = true;
			this.pnlChg.Visible = false;
			this.rblfgrechg.Visible = false;
			this.pnlNjtp.Visible = false;
			this.rblfggot.Visible = false;
			
			// 固定頁次預設值 (否: 0, 若變更廣告版面, 則也會變更固定頁次註記之值)
			this.rblfgfixpage.SelectedIndex = 1;
			
			
			// 載入 合約書相關資料
			LoadContData();
			
			
			// 預選 下拉式選單
			SetPullDownIndex();
		}
		
		
		// 預選 下拉式選單
		private void SetPullDownIndex()
		{
			// 廣告版面
			this.ddlLTypeCode.ClearSelection();
			this.ddlLTypeCode.Items.FindByValue("50").Selected = true;
			
			// 廣告色彩, 並判斷 合約書之彩/套/黑白次數(>0), 來預選廣告色彩 (Selected)
			// 缺點: 若同時有 兩種以上色彩存在時, 依 if elseif 的先後次序來顯示(如 彩/套=>出現彩色; 套/黑白=>出現套色)
			this.ddlColorCode.ClearSelection();
			if(int.Parse(this.tbxClrtm.Text) > 0 )
				this.ddlColorCode.Items.FindByValue("01").Selected = true;
			else if(int.Parse(this.tbxGetClrtm.Text) > 0 )
				this.ddlColorCode.Items.FindByValue("02").Selected = true;
			else if(int.Parse(this.tbxMenotm.Text) > 0 )
				this.ddlColorCode.Items.FindByValue("03").Selected = true;
			
			// 廣告篇幅
			this.ddlPageSizeCode.ClearSelection();
			this.ddlPageSizeCode.Items.FindByValue("01").Selected = true;
		}
		
		
		// 載入 合約書相關資料
		private void LoadContData()
		{
			// 抓出 合約書相關資料
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				this.tbxContNo.Text = contno;
				
				// 塞入相關合約書資料
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c2_cont");
				DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND cont_contno='" + contno + "'";
				dv2.RowFilter = rowfilterstr2;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找到" 的處理
				if (dv2.Count > 0)
				{
					// 顯示 廠商統編
					string strMfrIName = "", strMfrNo = "", strCustNo = "", strCustName = "";
					this.lblContNo.Text = "合約編號／廠商(簡)／客戶：";
					if(dv2[0]["mfr_inm"].ToString().Trim() != "")
					{
						strMfrIName = dv2[0]["mfr_inm"].ToString().Trim();
					}
					else
					{
						strMfrIName = strMfrIName;
					}
					if(dv2[0]["cont_mfrno"].ToString().Trim() != "")
					{
						strMfrNo = dv2[0]["cont_mfrno"].ToString().Trim();
						this.hiddenMfrNo.Value = strMfrNo;
					}
					else
					{
						strMfrNo = strMfrNo;
						this.hiddenMfrNo.Value = strMfrNo;
					}
					if(strMfrIName != "" && strMfrIName != "")
					{
						if(strMfrIName.Length >= 6)
						{
							strMfrIName = strMfrIName.Substring(0, 6) + "...";
						}
						else
						{
							strMfrIName = strMfrIName;
						}
						this.tbxMfrNo.Text = strMfrIName + " (" + strMfrNo + ")";
					}
					else
					{
						this.tbxMfrNo.Text = "(查無資料)";
					}
					strCustNo = dv2[0]["cont_custno"].ToString().Trim();
					this.hiddenCustNo.Value = strCustNo;
					strCustName = dv2[0]["cust_nm"].ToString().Trim();
					this.tbxCustNo.Text = strCustName + " (" + strCustNo + ")";
					//Response.Write("strMfrIName= " + strMfrIName + "<br>");
					//Response.Write("strMfrNo= " + strMfrNo + "<br>");
					//Response.Write("strCustNo= " + strCustNo + "<br>");
					//Response.Write("strCustName= " + strCustName + "<br>");
					
					// 顯示 刊登年月之合理範圍
					string strSDate = "", strEDate = "";
					strSDate = dv2[0]["cont_sdate"].ToString().Trim();
					//strSDate = strSDate.Substring(0, 4) + "/" + strSDate.Substring(4, 2);
					if(strSDate != "")
					{
						if(strSDate.Length >= 6)
							strSDate = strSDate.Substring(0, 4) + "/" + strSDate.Substring(4, 2);
						else
						{
							// 分離 \ 符號以取得數字
							if(strSDate.IndexOf("\\") != -1)
							{
								//strSDate = strSDate.Split('/', 2);
							}
							else
							{
								strSDate = strSDate;
								
								// 以 Javascript 的 window.close() 來告知訊息
								LiteralControl litAlert1 = new LiteralControl();
								litAlert1.Text = "<script language=javascript>alert(\"注意：合約起日不符合規則 'yyyy/mm'.\");</script>";
								Page.Controls.Add(litAlert1);
							}
						}
					}
					else
					{
						strSDate = strSDate;
					}
					this.tbxStartDate.Text = strSDate;
					strEDate = dv2[0]["cont_edate"].ToString().Trim();
					//strEDate = strEDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
					if(strEDate != "")
					{
						if(strEDate.Length >= 6)
							strEDate = strEDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
						else
						{
							// 分離 \ 符號以取得數字
							if(strEDate.IndexOf("\\") != -1)
							{
								//strEDate = strEDate.Split('/', 2);
							}
							else
							{
								strEDate = strEDate;
								
								// 以 Javascript 的 window.close() 來告知訊息
								LiteralControl litAlert1 = new LiteralControl();
								litAlert1.Text = "<script language=javascript>alert(\"注意：合約迄日不符合規則 'yyyy/mm'.\");</script>";
								Page.Controls.Add(litAlert1);
							}
						}
					}
					else
					{
						strEDate = strEDate;
					}
					this.tbxEndDate.Text = strEDate;
					
					// 指定 預設之刊登年月 = 合約起日之年月
					string yyyymm = dv2[0]["cont_sdate"].ToString().Trim();
					
					
					// 顯示合約書細節之相關資料
					string tottm = "";
					string totjtm = "";
					string chgjtm = "";
					string freetm = "";
					string totamt = "";
					string adamt = "";
					string Clrtm = "";
					string GetClrtm = "";
					string Menotm = "";
					string ContMessage = " ";
					ContMessage = ContMessage + "合約參考資料－";
					this.lblContMessage.Text = ContMessage;
					
					// 總刊登次數
					if(dv2[0]["cont_tottm"].ToString().Trim() != "")
					{
						tottm = dv2[0]["cont_tottm"].ToString().Trim();
					}
					else
						tottm = "0";
					this.lblTottm.Text = "總刊登次數: ";
					this.tbxTottm.Text = tottm;
					
					// 總製稿次數
					if(dv2[0]["cont_totjtm"].ToString().Trim() != "")
					{
						totjtm = dv2[0]["cont_totjtm"].ToString().Trim();
					}
					else
						totjtm = "0";
					this.lblTotjtm.Text = "總製稿次數: ";
					this.tbxTotjtm.Text = totjtm;
					
					// 換稿次數
					if(dv2[0]["cont_chgjtm"].ToString().Trim() != "")
					{
						chgjtm = dv2[0]["cont_chgjtm"].ToString().Trim();
					}
					else
						chgjtm = "0";
					this.lblChgjtm.Text = "換稿次數: ";
					this.tbxChgjtm.Text = chgjtm;
					
					// 贈送次數
					if(dv2[0]["cont_freetm"].ToString().Trim() != "")
					{
						freetm = dv2[0]["cont_freetm"].ToString().Trim();
					}
					else
						freetm = "0";
					this.lblFreetm.Text = "贈送次數: ";
					this.tbxFreetm.Text = freetm;
					
					// 合約總金額
					if(dv2[0]["cont_totamt"].ToString().Trim() != "")
					{
						totamt = dv2[0]["cont_totamt"].ToString().Trim();
					}
					else
						totamt = "0";
					this.lblTotamt.Text = "合約總金額: $ ";
					this.tbxTotamt.Text = totamt;
					
					// 合約書 廣告費單價
					if(dv2[0]["cont_adamt"].ToString().Trim() != "")
					{
						adamt = dv2[0]["cont_adamt"].ToString().Trim();
					}
					else
					{
						adamt = "0";
					}
					this.lblContAdamt.Text = "廣告費單價: $";
					this.tbxContAdamt.Text = adamt;
					// 指定預設之 廣告金額 & 換稿金額
					this.tbxAdAmt.Text = adamt;
					this.tbxChgAmt.Text = "0";
					
					// 合約書 剩餘彩色次數
					if(dv2[0]["cont_clrtm"].ToString().Trim() != "")
					{
						Clrtm = dv2[0]["cont_clrtm"].ToString().Trim();
					}
					else
					{
						Clrtm = "0";
					}
					this.lblClrtm.Text = "彩色次數: ";
					this.tbxClrtm.Text = Clrtm;
					
					// 合約書 剩餘套色次數
					if(dv2[0]["cont_getclrtm"].ToString().Trim() != "")
					{
						GetClrtm = dv2[0]["cont_getclrtm"].ToString().Trim();
					}
					else
					{
						GetClrtm = "0";
					}
					this.lblGetClrtm.Text = "套色次數: ";
					this.tbxGetClrtm.Text = GetClrtm;
					
					// 合約書 剩餘黑白次數
					if(dv2[0]["cont_menotm"].ToString().Trim() != "")
					{
						Menotm = dv2[0]["cont_menotm"].ToString().Trim();
					}
					else
					{
						Menotm = "0";
					}
					this.lblMenotm.Text = "黑白次數: ";
					this.tbxMenotm.Text = Menotm;
					
					
					// 預設 發票廠商收件人序號及其姓名
					GetInitIMData();
					
					
					
					// 載入 書籍類別, 計劃代號, 成本中心相關資料
					LoadBkcdProjCost();
				}
			}
			else
			{
				// do nothing 不載入
				this.lblAddMessage.Text = "無合約書編號資料, 無法載入落版資料; 請回上一步驟重新搜尋!<br>";
			}
			
		}
		
		
		// 預設 發票廠商收件人序號及其姓名
		private void GetInitIMData()
		{
			// 抓出 合約書相關資料
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
			}
			
			
			// 顯示下拉式選單 發票廠商收件人的 DB 值
			DataSet ds9 = new DataSet();
			this.sqlDataAdapter9.SelectCommand.Parameters["@contno"].Value = contno;
			this.sqlDataAdapter9.Fill(ds9, "invmfr");
			ddlIMSeq.DataSource=ds9;
			ddlIMSeq.DataTextField="im_nm";
			ddlIMSeq.DataValueField="im_imseq";
			ddlIMSeq.DataBind();
			
			
			// 顯示總筆數
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds20 = new DataSet();
			this.sqlDataAdapter20.Fill(ds20, "invmfr");
			DataView dv20 = ds20.Tables["invmfr"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr20 = "1=1";
			rowfilterstr20 = rowfilterstr20 + " AND im_contno='" + contno + "'";
			dv20.RowFilter = rowfilterstr20;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv20.Count= "+ dv20.Count + "<BR>");
			//Response.Write("dv20.RowFilter= " + dv20.RowFilter + "<BR>");
			
			string strfgItri = "";
			// 若搜尋結果為 "找不到" 的處理
			int IMCount = 0;
			if (dv20.Count > 0)
			{
				IMCount = Convert.ToInt16(dv20[0]["CountNo"].ToString().Trim());
				this.lblIMCount.Text = "(有 " + IMCount + " 人)";
				
				// 抓出第一筆下拉式選單之 im_fgitri, 當做串至 book+proj 時抓計劃代號及成本中心的判斷值
				DataView dv9 = ds9.Tables["invmfr"].DefaultView;
				strfgItri = dv9[0]["im_fgitri"].ToString();
			}
			else
			{
				this.lblIMCount.Text = "<font color='Red'>(查無資料!)</font>";
				
				// 抓出第一筆下拉式選單之 im_fgitri, 當做串至 book+proj 時抓計劃代號及成本中心的判斷值
				strfgItri = " ";
			}
			//Response.Write("strfgItri= " + strfgItri + "<br>");
			this.hiddenIMfgitri.Value = strfgItri;
		}
		
		
		// 載入 書籍類別, 計劃代號, 成本中心相關資料
		private void LoadBkcdProjCost()
		{
			// 檢查是否有書籍代碼, 顯示其相關資料, 並帶出 計劃代號及成本中心 DB 值
			if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
			{
				// 顯示 合約書籍的相關資料: 書籍名稱及代碼
				string strbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
				this.tbxBkcd.Text = strbkcd;
				string strIMfgitri = this.hiddenIMfgitri.Value.ToString().Trim();
				//Response.Write("strbkcd= " + strbkcd + "<br>");
				//Response.Write("strIMfgitri= " + strIMfgitri + "<br>");
				
				
				// 先變更下拉式選單 舊稿書類/改稿書類, 再載入 書籍類別, 計劃代號, 成本中心相關資料
				// 變更下拉式選單 舊稿書類
				if(this.pnlOrig.Visible == true)
				{
					this.ddlOrigBookCode.ClearSelection();
					this.ddlOrigBookCode.Items.FindByValue(strbkcd).Selected = true;
					//Response.Write("ddlOrigBookCode= " + dv7[0]["bk_bkcd"].ToString() + "<br>");
				}
					
				// 變更下拉式選單 改稿書類
				if(this.pnlChg.Visible == true)
				{
					this.ddlChgBookCode.ClearSelection();
					this.ddlChgBookCode.Items.FindByValue(strbkcd).Selected = true;
					//Response.Write("ddlChgBookCode= " + dv7[0]["bk_bkcd"].ToString() + "<br>");
				}
				
				
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds7 = new DataSet();
				this.sqlDataAdapter7.Fill(ds7, "book");
				DataView dv7 = ds7.Tables["book"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr7 = "1=1";
				rowfilterstr7 = rowfilterstr7 + " AND proj_bkcd='" + strbkcd + "'";
				rowfilterstr7 = rowfilterstr7 + " AND proj_fgitri='" + strIMfgitri + "'";
				dv7.RowFilter = rowfilterstr7;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
				//Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找到" 的處理: 載入 書籍類別, 計劃代號, 成本中心相關資料
				if (dv7.Count > 0)
				{
					//this.tbxBkcd.Text = "合約書類：" + this.tbxBkcd.Text;
					this.tbxBookName.Text = dv7[0]["bk_nm"].ToString().Trim();
					this.lblProjCostMessage.Text = "計劃代號／成本中心：";
					this.lblProjNo.Text =  dv7[0]["proj_projno"].ToString().Trim();
					this.lblCostCtr.Text = dv7[0]["proj_costctr"].ToString().Trim();
					
					// 若該發廠收件人為特殊之'發票類型', 則顯示其文字 -- 以下為 1/29/2003 added
					string strfgitri = dv7[0]["proj_fgitri"].ToString().Trim();
					if(strfgitri != "")
						this.lblfgITRI.Text = " (" + dv7[0]["fgitri_name"].ToString().Trim() + ")";
					else
						this.lblfgITRI.Text = "";
				}
			}
			else
			{
				this.lblAddMessage.Text = "該合約並未指定 書籍類別, 故此處無法帶出計劃代號及成本中心資料!<br>請回維護合約書修正!";
			}
		}
		
		
		// 載入 已新增之資料
		private void BindGrid1()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " and pub_syscd = 'C2'";
				rowfilterstr1 = rowfilterstr1 + " and pub_contno = '" + contno + "'";
			}
			else
			{
				contno = "";
			}
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
				
				// 若有落版資料, 則顯示其合計資料－已落版 總筆數, 已落版 總稿件, 已落版總廣告金額 & 已落版總換稿金額
				GetCounts();
				
				
				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 刊登年月
					//string yyyymm = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
					//yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
					//DataGrid1.Items[i].Cells[3].Text = yyyymm;
					
					// 固定頁次註記
					string fgfixpg = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					if(fgfixpg == "0")
						fgfixpg = "否";
					else
						fgfixpg = "是";
					DataGrid1.Items[i].Cells[9].Text = fgfixpg;
					
					// 稿件類別
					string drafttp =  DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					switch (drafttp) 
					{
						case "1":
							DataGrid1.Items[i].Cells[12].Text = "舊稿";
							DataGrid1.Items[i].Cells[13].Text = "";
							break;
						case "2":
							DataGrid1.Items[i].Cells[12].Text = "新稿";
							// 到稿註記
							string fggot1 = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
							if(fggot1 == "0")
								fggot1 = "否";
							else
								fggot1 = "是";
							DataGrid1.Items[i].Cells[13].Text = fggot1;
							break;
						case "3":
							DataGrid1.Items[i].Cells[12].Text = "改稿";
							// 到稿註記
							string fggot2 = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
							if(fggot2 == "0")
								fggot2 = "否";
							else
								fggot2 = "是";
							DataGrid1.Items[i].Cells[13].Text = fggot2;
							break;
						default:
							DataGrid1.Items[i].Cells[12].Text = "舊稿";
							DataGrid1.Items[i].Cells[13].Text = "";
							break;
					}
					
					// 舊稿期別 -- 只有當稿件類別是 舊稿時, 才顯示此欄資料
					if(drafttp == "1")
						DataGrid1.Items[i].Cells[14].Text = DataGrid1.Items[i].Cells[14].Text;
					else
						DataGrid1.Items[i].Cells[14].Text = "";
					
					// 改稿期別 -- 只有當稿件類別是 改稿時, 才顯示此欄資料
					if(drafttp == "3")
						DataGrid1.Items[i].Cells[15].Text = DataGrid1.Items[i].Cells[15].Text;
					else
						DataGrid1.Items[i].Cells[15].Text = "";
					
					// 已開發票開立單註記
					string fginved = DataGrid1.Items[i].Cells[18].Text.ToString().Trim();
					if(fginved != "")
					{
						if(fginved == "9")
							fginved = "<font color=Blue>已挑未開(特別處理)</font>";
						if(fginved == "t")
							fginved = "<font color=Blue>已挑未開</font>";
						if(fginved == "v")
							fginved = "<font color=Blue>已挑未開</font>";
						else if(fginved == "1")
							fginved = "<font color=Red>是(已開)</font>";
					}
					else
						fginved = "否(未開)";
					DataGrid1.Items[i].Cells[18].Text = fginved;
					
					// 發票開立單人工處理註記
					string fginvself = DataGrid1.Items[i].Cells[19].Text.ToString().Trim();
					if(fginvself == "0")
						fginvself = "否";
					else
						fginvself = "<font color=Red>是</font>";
					DataGrid1.Items[i].Cells[19].Text = fginvself;
					
					
					// 院所內註記
					string fgitri =  DataGrid1.Items[i].Cells[24].Text.ToString().Trim();
					//Response.Write("fgitri= " + fgitri + "<br>");
					switch (fgitri) 
					{
						case "":
							DataGrid1.Items[i].Cells[25].ForeColor = Color.Black;
							break;
						case "06":
							DataGrid1.Items[i].Cells[25].ForeColor = Color.OrangeRed;
							break;
						case "07":
							DataGrid1.Items[i].Cells[25].ForeColor = Color.Blue;
							break;
						default:
							DataGrid1.Items[i].Cells[25].ForeColor = Color.Black;
							break;
					}
				}
				this.lblAddMessage.Text = "";
			}
			else
			{
				// 若無 落版資料
				this.DataGrid1.Visible = false;
				this.lblAddMessage.Text = this.lblAddMessage.Text;
				
				
				// 更新 已落版註記 (以免刪除落版資料到底時, 其合約書之已落版註記是錯的資料)
				string strSyscd = "C2";
				string strContNo = this.tbxContNo.Text.ToString().Trim();
				//Response.Write("strSyscd= " + strSyscd + "<br>");
				//Response.Write("strContNo= " + strContNo + "<br>");
				
				// 執行 將值塞入 sqlCommand5.Parameters 中, 以執行 新增入資料庫
				//Response.Write(this.sqlCommand5.CommandText);
				this.sqlCommand5.Parameters["@syscd"].Value = strSyscd;
				this.sqlCommand5.Parameters["@contno"].Value = strContNo;
				
				// 確認執行 sqlCommand2 成功
				this.sqlCommand5.Connection.Open();
				// 使用 Transaction 確認有執行動作
				System.Data.SqlClient.SqlTransaction myTrans5 = this.sqlCommand5.Connection.BeginTransaction();
				this.sqlCommand5.Transaction = myTrans5;
				//Response.Write(sqlCommand5.Parameters.Count.ToString().Trim());
				try
				{
					this.sqlCommand5.ExecuteNonQuery();
					myTrans5.Commit();
					//Response.Write("更新合約書 已落版註記成功!<br>");
				}
				catch(System.Data.SqlClient.SqlException ex5)
				{
					Response.Write(ex5.Message + "<br>");
					myTrans5.Rollback();
					//Response.Write("更新合約書 已落版註記失敗!<br>");
				}
				finally
				{
					this.sqlCommand5.Connection.Close();
				}
				
			}
		}
		
		
		// 若有落版資料, 則顯示其合計資料－已落版 總筆數, 已落版 總稿件, 已落版總廣告金額 & 已落版總換稿金額
		private void GetCounts()
		{
			string strContNo = this.tbxContNo.Text.ToString().Trim();
			//Response.Write("strContNo= " + strContNo + "<br>");
			
			
			// 顯示 已落版 總筆數
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds13 = new DataSet();
			this.sqlDataAdapter13.Fill(ds13, "c2_pub");
			DataView dv13 = ds13.Tables["c2_pub"].DefaultView;
				
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr13 = "1=1";
			rowfilterstr13 = rowfilterstr13 + " AND pub_syscd='C2'";
			rowfilterstr13 = rowfilterstr13 + " AND pub_contno='" + strContNo + "'";
			dv13.RowFilter = rowfilterstr13;
			
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv13.Count= "+ dv13.Count + "<BR>");
			//Response.Write("dv13.RowFilter= " + dv13.RowFilter + "<BR>");
				
			// 若搜尋結果為 "找不到" 的處理
			int PubCounts = 0;
			if (dv13.Count > 0)
			{
				PubCounts = Convert.ToInt32(dv13[0]["CountNo"].ToString().Trim());
				this.lblPubCounts.Text = "(已落版 總筆數：" + PubCounts + ")";
			}
			else
			{
				this.lblPubCounts.Text = "<font color='Red'>(已落版 總筆數：0)</font>";
			}
			
			
			// 顯示 已落版 總稿件
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds15 = new DataSet();
			this.sqlDataAdapter15.Fill(ds15, "c2_pub");
			DataView dv15 = ds15.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr15 = "1=1";
			rowfilterstr15 = rowfilterstr15 + " AND pub_syscd='C2'";
			rowfilterstr15 = rowfilterstr15 + " AND pub_contno='" + strContNo + "'";
			dv15.RowFilter = rowfilterstr15;
			
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv15.Count= "+ dv15.Count + "<BR>");
			//Response.Write("dv15.RowFilter= " + dv15.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			string Drafttp, DraftName;
			int DraftCounts = 0;
			if (dv15.Count > 0)
			{
				this.lblDraftCounts.Text =  "（已落版 總稿件－";
				
				for(int i=0; i<dv15.Count; i++)
				{
					Drafttp = dv15[i]["pub_drafttp"].ToString().Trim();
					//Response.Write("Drafttp= " + Drafttp + "<br>");
					switch(Drafttp)
					{
						case "1":
							DraftName = "舊稿";
							break;
						case "2":
							DraftName = "新稿";
							break;
						case "3":
							DraftName = "改稿";
							break;
						default:
							DraftName = "舊稿";
							break;
					}
					DraftCounts = Convert.ToInt32(dv15[i]["CountNo"].ToString().Trim());
					this.lblDraftCounts.Text = this.lblDraftCounts.Text + DraftName + "：" + DraftCounts + "／";
				}
				int Leni = this.lblDraftCounts.Text.Length;
				//Response.Write("Leni= " + Leni + "<br>");
				this.lblDraftCounts.Text = this.lblDraftCounts.Text.Substring(0, Leni-1) + "）";
			}
			else
			{
				this.lblDraftCounts.Text = "（已落版稿件－無）";
			}
			
			
			// 顯示 已落版總廣告金額 & 已落版總換稿金額
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds13_2 = new DataSet();
			this.sqlDataAdapter13.Fill(ds13_2, "c2_pub");
			DataView dv13_2 = ds13_2.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr13_2 = "1=1";
			rowfilterstr13_2 = rowfilterstr13_2 + " AND pub_syscd='C2'";
			rowfilterstr13_2 = rowfilterstr13_2 + " AND pub_contno='" + strContNo + "'";
			dv13_2.RowFilter = rowfilterstr13_2;
			
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv13_2.Count= "+ dv13_2.Count + "<BR>");
			//Response.Write("dv13_2.RowFilter= " + dv13_2.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			int TotPubAdAmt = 0;
			int TotPubChgAmt = 0;
			if (dv13_2.Count > 0)
			{
				TotPubAdAmt = Convert.ToInt32(dv13_2[0]["pub_adamt"].ToString().Trim());
				TotPubChgAmt = Convert.ToInt32(dv13_2[0]["pub_chgamt"].ToString().Trim());
				this.lblAmtCounts.Text = "（已落版 總廣告金額／總換稿金額：$" + TotPubAdAmt +"／$" + TotPubChgAmt + "）";
			}
			else
			{
				this.lblAmtCounts.Text = "<font color='Red'>已落版 總廣告金額／總換稿金額：$0／$0</font>";
			}
		}
		
		
		// 給預設值, 如刊登年月, 書籍期別
		private void NewData()
		{
			// 抓出 合約書相關資料
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				
				// 塞入相關合約書資料
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c2_cont");
				DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND cont_contno='" + contno + "'";
				dv2.RowFilter = rowfilterstr2;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找不到" 的處理
				if (dv2.Count > 0)
				{
					// 指定 預設之刊登年月 = 合約起日之年月
					//string yyyymm = dv2[0]["cont_sdate"].ToString().Trim();
					string yyyymm = System.DateTime.Today.ToString("yyyyMM").Trim();
					tbxYYYYMM.Value = yyyymm;
					
					// 顯示 刊登年月之對應 書籍期別
					string bkcd = dv2[0]["cont_bkcd"].ToString().Trim();
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds8 = new DataSet();
					this.sqlDataAdapter8.Fill(ds8, "bookp");
					DataView dv8 = ds8.Tables["bookp"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr8 = "1=1";
					rowfilterstr8 = rowfilterstr8 + " AND bkp_bkcd='" + bkcd + "'";
					rowfilterstr8 = rowfilterstr8 + " AND bkp_date='" + yyyymm + "'";
					dv8.RowFilter = rowfilterstr8;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
					//Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR>");
					
					// 若搜尋結果為 "找不到" 的處理
					if (dv8.Count > 0)
					{
						// 顯示 書籍期別資料
						//Response.Write(dv8[0]["bkp_pno"].ToString().Trim());
						this.tbxBkpPno.Value = dv8[0]["bkp_pno"].ToString().Trim();
					}
					else
					{
						this.lblAddMessage.Text = "找不到書籍期別之預設值, 請先輸入 刊登年月!";
					}
				}
				
			}
		}
		
		
		// 載入預設資料 按鈕
		private void btnLoadData_Click(object sender, System.EventArgs e)
		{
			// 呼叫 InitialData() function
			InitialData();
			//NewData();
			
			// 清除資料
			this.tbxYYYYMM.Value = "";
			this.tbxBkpPno.Value = "";
			this.tbxPageNo.Text = "";
			this.tbxOrigjno.Text = "";
			this.tbxOrigbkno.Text = "";
		}
		
		
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// 抓出 合約起迄日, 以判斷刊登年月是否在其範圍內, 若是, 則新增; 否則不予新增
			string strSDate = this.tbxStartDate.Text.ToString().Trim();
			strSDate = strSDate.Substring(0, 4) + strSDate.Substring(5, 2);
			string strEDate = this.tbxEndDate.Text.ToString().Trim();
			strEDate = strEDate.Substring(0, 4) + strEDate.Substring(5, 2);
			//Response.Write("strEDate=" + strEDate + "<br>");
			//Response.Write("strEDate=" + strEDate + "<br>");
			int intSDate = Convert.ToInt32(strSDate);
			int intEDate = Convert.ToInt32(strEDate);
			int intYYYYMM = Convert.ToInt32(this.tbxYYYYMM.Value.ToString().Trim());
			
			// 若在範圍內
			if(intSDate <= intYYYYMM && intYYYYMM <= intEDate)
			{
				// 抓出最新的 落版序號
				GetNewPubSeq();
				
				// 檢查 版面優先次序是否存在, 若存在呼叫InsertToDB(); 否則不允許新增
				CheckLPriorSeq1();
				
//				this.lblAddMessage.Text = "";
//				
//				
//				// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
//				this.btnSave.Visible = true;
//				this.btnModify.Visible = false;
//				this.btnLoadData.Visible = true;
//				this.btnGoChkList.Visible = true;
//				this.lblPubSeq.Visible = false;
//				
//				// 資料回復初始狀態
//				InitialData();
//				//NewData();
//				
//				// Refresh DataGrid1
//				DataGrid1.Visible = true;
//				DataGrid1.CurrentPageIndex = 0;
//				BindGrid1();
			}
			// 若刊登年月不在合約起迄範圍內的處理
			else
			{
				//Response.Write("刊登年月必須在合約起迄範圍內, 否則無法新增, 請修正!<br>");
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlertError = new LiteralControl();
				litAlertError.Text = "<script language=javascript>alert(\"刊登年月必須在合約起迄範圍內, 否則無法新增, 請修正!\");</script>";
				Page.Controls.Add(litAlertError);
			}
			
			// 隱藏 序號之顯示
			this.lblPubSeq.Visible = false;
		}
		
		
		// 抓出 最新的落版序號
		// 預設 發票廠商收件人序號 - 按下 "儲存新增" 後, 再去抓出正確的落版序號 (依不同刊登年月)
		private void GetNewPubSeq()
		{
			// 顯示 序號
			this.lblPubSeq.Visible = true;

			// 抓出 合約書相關資料
			string contno = "";
			string yyyymm = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				if(this.tbxYYYYMM.Value.ToString().Trim() != "")
					yyyymm = this.tbxYYYYMM.Value;
				else
					yyyymm = yyyymm;
				//Response.Write("contno= " + contno + "<br>");
				//Response.Write("yyyymm= " + yyyymm + "<br>");
				
				// 預設 落版序號 - 按下 "儲存新增" 後, 再去抓出正確的落版序號 (依不同刊登年月)
				string NewPubSeq = "01";
				
				// 預設 發票廠商收件人 序號 & 姓名
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds10 = new DataSet();
				this.sqlDataAdapter10.Fill(ds10, "c2_pub");
				DataView dv10 = ds10.Tables["c2_pub"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr10 = "1=1";
				rowfilterstr10 = rowfilterstr10 + " AND pub_contno='" + contno + "'";
				rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm='" + yyyymm + "'";
				dv10.RowFilter = rowfilterstr10;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv10.Count= "+ dv10.Count + "<BR>");
				//Response.Write("dv10.RowFilter= " + dv10.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找不到" 的處理
				if (dv10.Count > 0)
				{
					NewPubSeq = Convert.ToString(Convert.ToInt32(dv10[0]["pub_pubseq"].ToString().Trim())+1);
					if(NewPubSeq.Length < 2)
						NewPubSeq = "0" + NewPubSeq;
					else
						NewPubSeq = NewPubSeq;
				}
				else
				{
					NewPubSeq = NewPubSeq;
				}
				//Response.Write("NewPubSeq= " + NewPubSeq + "<br>");
				
				// 顯示 序號
				this.lblPubSeq.Text = NewPubSeq;
			}
		}
		
		
		// 抓出畫面上 廣告版面/廣告色彩/廣告篇幅, 檢查此組合是否存在於 c2_lprior
		private void CheckLPriorSeq1()
		{
			// 落版檔資料 - 抓下畫面上的值
			string strBkcd = this.tbxBkcd.Text.ToString();
			string strLtpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
			string strClrcd = this.ddlColorCode.SelectedItem.Value.ToString();
			string strPgscd = this.ddlPageSizeCode.SelectedItem.Value.ToString();
			//Response.Write("strLtpcd= " + strLtpcd + "<br>");
			//Response.Write("strClrcd= " + strClrcd + "<br>");
			//Response.Write("strPgscd= " + strPgscd + "<br>");
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds21 = new DataSet();
			this.sqlDataAdapter21.Fill(ds21, "c2_lprior");
			DataView dv21 = ds21.Tables["c2_lprior"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr21 = "1=1";
			rowfilterstr21 = rowfilterstr21 + " AND lp_bkcd='" + strBkcd + "'";
			rowfilterstr21 = rowfilterstr21 + " AND lp_ltpcd='" + strLtpcd + "'";
			rowfilterstr21 = rowfilterstr21 + " AND lp_clrcd='" + strClrcd + "'";
			rowfilterstr21 = rowfilterstr21 + " AND lp_pgscd='" + strPgscd + "'";
			dv21.RowFilter = rowfilterstr21;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv21.Count= "+ dv21.Count + "<BR>");
			//Response.Write("dv21.RowFilter= " + dv21.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找到" 的處理: 允許新增/修改
			if (dv21.Count > 0)
			{
				// 判斷狀態
				if(this.btnSave.Visible = true)
				{
					// 執行新增動作
					InsertToDB();
					
					
					this.lblAddMessage.Text = "";
					
					// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
					this.btnSave.Visible = true;
					this.btnModify.Visible = false;
					this.btnLoadData.Visible = true;
					this.btnGoChkList.Visible = true;
					this.lblPubSeq.Visible = false;
					
					// 資料回復初始狀態
					InitialData();
					//NewData();
					
					// Refresh DataGrid1
					DataGrid1.Visible = true;
					DataGrid1.CurrentPageIndex = 0;
					BindGrid1();
				}
			}
			// 若找不到資料, 警告之並出現新視窗要求新增
			else
			{
				// 開啟小視窗
				string strbuf = "adlprior_addnew.aspx";
				strbuf = strbuf + "?function=new&ltpcd=" + strLtpcd + "&clrcd=" + strClrcd + "&pgscd=" + strPgscd;
				//Response.Write(strbuf);
				
				// 以 Javascript 的 window.alert()  來告知訊息 - 移至 adlprior_addnew.aspx.cs
				// 以 Javascript 的 window.open()  來告知訊息
				litWinOpen1.Text="<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=600, height=450, left=80, top=20, scrollbars=yes');</script>";
				//litWinOpen1.Text="<script language=\"javascript\">window.showModalDialog(\"" + strbuf + "\", 'new Object()', 'dialogWidth:700px; dialogHeight:400px; dialogLeft:30px; dialogTop:22px; center:yes; scroll:yes; status:no; help:no;');</script>";
			}
		}
		
		
		// 新增落版資料
		private void InsertToDB()
		{
			// 落版檔資料 - 抓下畫面上的值
			string strSyscd = "C2";
			string strContNo = this.tbxContNo.Text.ToString().Trim();
			string strYYYYMM = this.tbxYYYYMM.Value.ToString().Trim();
			string strPubSeq = this.lblPubSeq.Text.ToString().Trim();
			int strPgNo = 0;
			if(this.tbxPageNo.Text.ToString().Trim() != "")
				strPgNo = Convert.ToInt32(this.tbxPageNo.Text.ToString().Trim());
			else
				strPgNo = strPgNo;
			string strLtpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
			string strClrcd = this.ddlColorCode.SelectedItem.Value.ToString();
			string strPgscd = this.ddlPageSizeCode.SelectedItem.Value.ToString();
			float strAdAmt = 0;
			if(this.tbxAdAmt.Text.ToString().Trim() != "")
				strAdAmt = Convert.ToSingle(this.tbxAdAmt.Text.ToString().Trim());
			else
				strAdAmt = strAdAmt;
			float strChgAmt = 0;
			if(this.tbxChgAmt.Text.ToString().Trim() != "")
				strChgAmt = Convert.ToSingle(this.tbxChgAmt.Text.ToString().Trim());
			else
				strChgAmt = strChgAmt;
			string strOrigBkcd = "";
			int strOrigJNo = 0;
			if(this.tbxOrigjno.Text.ToString().Trim() != "")
				strOrigJNo = Convert.ToInt32(this.tbxOrigjno.Text.ToString().Trim());
			else
				strOrigJNo = strOrigJNo;
			int strOrigBkno = 0;
			if(this.tbxOrigbkno.Text.ToString().Trim() != "")
				strOrigBkno = Convert.ToInt32(this.tbxOrigbkno.Text.ToString().Trim());
			else
				strOrigBkno = strOrigBkno;
			string strChgBkcd = "";
			int strChgJNo = 0;
			if(this.tbxChgjno.Text.ToString().Trim() != "")
				strChgJNo = Convert.ToInt32(this.tbxChgjno.Text.ToString().Trim());
			else
				strChgJNo = strChgJNo;
			int strChgBkno = 0;
			if(this.tbxChgbkno.Text.ToString().Trim() != "")
				strChgBkno = Convert.ToInt32(this.tbxChgbkno.Text.ToString().Trim());
			else
				strChgBkno = strChgBkno;
			string strfgReChg = "";
			string strNjtpcd = "";
			string strfgGot = "0";
			string strDrafttp = this.ddlDraftType.SelectedItem.Value.ToString().Trim();
			//Response.Write("strDrafttp= " + strDrafttp + "<br>");
			switch (strDrafttp) 
			{
				case "1":
					strOrigBkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString().Trim();
					strOrigJNo = strOrigJNo;
					strOrigBkno = strOrigBkno;
					strChgBkcd = "";
					strNjtpcd = "";
					break;
				case "2":
					strNjtpcd = this.ddlNJTypeCode.SelectedItem.Value.ToString();
					strOrigBkcd = "";
					strChgBkcd = "";
					// 若 rblfggot 沒有選擇時, 給予預設值 0
					if(this.rblfggot.SelectedIndex >=  0)
						strfgGot = this.rblfggot.SelectedItem.Value.ToString().Trim();
					else
						strfgGot = strfgGot;
					break;
				case "3":
					strChgBkcd = this.ddlChgBookCode.SelectedItem.Value.ToString().Trim();
					strChgJNo = strChgJNo;
					strChgBkno = strChgBkno;
					// 若 strfgReChg 沒有選擇時, 給予預設值 0
					strfgReChg = "0";
					if(this.rblfgrechg.SelectedIndex >=  0)
						strfgReChg = this.rblfgrechg.SelectedItem.Value.ToString().Trim();
					else
						strfgReChg = strfgReChg;
					// 若 rblfggot 沒有選擇時, 給予預設值 0
					if(this.rblfggot.SelectedIndex >=  0)
						strfgGot = this.rblfggot.SelectedItem.Value.ToString().Trim();
					else
						strfgGot = strfgGot;
					break;
				default:
					strOrigBkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString().Trim();
					strOrigJNo = strOrigJNo;
					strOrigBkno = strOrigBkno;
					strChgBkcd = "";
					strNjtpcd = "";
					break;
			}
			string strProjNo = this.lblProjNo.Text.ToString().Trim();
			string strCostCtr = this.lblCostCtr.Text.ToString().Trim();
			// 給予 fginved 預設值 ' ' (表示 否 (尚未開立 發票開立單))
			string strfgInvcd = " ";
			// 給予 fginvself 預設值 0 (表示 否)
			string strfgInvSelf = "0";
			string strPNo = this.tbxBkpPno.Value;
			string strRemark = this.tbxRemark.Text.ToString().Trim();
			string strfgFixPg = "0";
			// 若 rblfgfixpage 沒有選擇時, 給予預設值 0
			if(this.rblfgfixpage.SelectedIndex >=  0)
				strfgFixPg = this.rblfgfixpage.SelectedItem.Value.ToString().Trim();
			else
				strfgFixPg = strfgFixPg;
			string strModDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
			//string strModEmpNo = "800443";
			// 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_show.aspx.cs 處不同處 
			// 抓出登入者的工號, 作為預設 修改業務員 之值
			string strModEmpNo = "";
			//Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
			// 若有登入者的資料, 則抓出並預選 修改業務員之下拉式選單
			if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!="")
			{
				strModEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			}
			// 若無登入者的資料, 則抓出並預選 修改業務員為 康靜怡 (800443, SelectedIndex=02)
			else
			{
				strModEmpNo = "800443";
			}
			string strBkcd = this.tbxBkcd.Text.ToString();
			string strImSeq = "";
			// 若找無 ddlIMSeq 資料
			if(this.ddlIMSeq.Items.Count != 0)
			{
				strImSeq = this.ddlIMSeq.SelectedItem.Value.ToString();
			}
			string strfgUpdated = "0";
			string strfgAct = "0";
			//Response.Write("strSyscd= " + strSyscd + ", ");
			//Response.Write("strContNo= " + strContNo + ", ");
			//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
			//Response.Write("strPubSeq= " + strPubSeq + "<br>");
			//Response.Write("strPgNo= " + strPgNo + "<br>");
			//Response.Write("strLtpcd= " + strLtpcd + "<br>");
			//Response.Write("strClrcd= " + strClrcd + "<br>");
			//Response.Write("strPgscd= " + strPgscd + "<br>");
			//Response.Write("strAdAmt= " + strAdAmt + "<br>");
			//Response.Write("strChgAmt= " + strChgAmt + "<br>");
			//Response.Write("strDrafttp= " + strDrafttp + "<br>");
			//Response.Write("strOrigBkcd= " + strOrigBkcd + "<br>");
			//Response.Write("strOrigJNo= " + strOrigJNo + "<br>");
			//Response.Write("strOrigBkno= " + strOrigBkno + "<br>");
			//Response.Write("strChgBkcd= " + strChgBkcd + "<br>");
			//Response.Write("strChgJNo= " + strChgJNo + "<br>");
			//Response.Write("strChgBkno= " + strChgBkno + "<br>");
			//Response.Write("strfgReChg= " + strfgReChg + "<br>");
			//Response.Write("strNjtpcd= " + strNjtpcd + "<br>");
			//Response.Write("strfgGot= " + strfgGot + "<br>");
			//Response.Write("strProjNo= " + strProjNo + "<br>");
			//Response.Write("strCostCtr= " + strCostCtr + "<br>");
			//Response.Write("strfgInvcd= " + strfgInvcd + "<br>");
			//Response.Write("strfgInvSelf= " + strfgInvSelf + "<br>");
			//Response.Write("strPNo= " + strPNo + "<br>");
			//Response.Write("strRemark= " + strRemark + "<br>");
			//Response.Write("strfgFixPg= " + strfgFixPg + "<br>");
			//Response.Write("strModDate= " + strModDate + "<br>");
			//Response.Write("strModEmpNo= " + strModEmpNo + "<br>");
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strImSeq= " + strImSeq + "<br>");
			//Response.Write("strfgUpdated= " + strfgUpdated + "<br>");
			//Response.Write("strfgAct= " + strfgAct + "<br>");
			
			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			// 此外, 若 ddlIMSeq 不為空者, 則允許新增
			if(strImSeq.Trim() != "")
			{
				this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
				this.sqlCommand1.Parameters["@contno"].Value = strContNo;
				this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
				this.sqlCommand1.Parameters["@pubseq"].Value = strPubSeq;
				this.sqlCommand1.Parameters["@pgno"].Value = strPgNo;
				this.sqlCommand1.Parameters["@ltpcd"].Value = strLtpcd;
				this.sqlCommand1.Parameters["@clrcd"].Value = strClrcd;
				this.sqlCommand1.Parameters["@pgscd"].Value = strPgscd;
				this.sqlCommand1.Parameters["@adamt"].Value = strAdAmt;
				this.sqlCommand1.Parameters["@chgamt"].Value = strChgAmt;
				this.sqlCommand1.Parameters["@drafttp"].Value = strDrafttp;
				this.sqlCommand1.Parameters["@origbkcd"].Value = strOrigBkcd;
				this.sqlCommand1.Parameters["@origjno"].Value = strOrigJNo;
				this.sqlCommand1.Parameters["@origjbkno"].Value = strOrigBkno;
				this.sqlCommand1.Parameters["@chgbkcd"].Value = strChgBkcd;
				this.sqlCommand1.Parameters["@chgjno"].Value = strChgJNo;
				this.sqlCommand1.Parameters["@chgjbkno"].Value = strChgBkno;
				this.sqlCommand1.Parameters["@fgrechg"].Value = strfgReChg;
				this.sqlCommand1.Parameters["@fggot"].Value = strfgGot;
				this.sqlCommand1.Parameters["@njtpcd"].Value = strNjtpcd;
				this.sqlCommand1.Parameters["@projno"].Value = strProjNo;
				this.sqlCommand1.Parameters["@costctr"].Value = strCostCtr;
				this.sqlCommand1.Parameters["@fginved"].Value = strfgInvcd;
				this.sqlCommand1.Parameters["@fginvself"].Value = strfgInvSelf;
				this.sqlCommand1.Parameters["@pno"].Value = strPNo;
				this.sqlCommand1.Parameters["@remark"].Value = strRemark;
				this.sqlCommand1.Parameters["@fgfixpg"].Value = strfgFixPg;
				this.sqlCommand1.Parameters["@moddate"].Value = strModDate;
				this.sqlCommand1.Parameters["@modempno"].Value = strModEmpNo;
				this.sqlCommand1.Parameters["@bkcd"].Value = strBkcd;
				this.sqlCommand1.Parameters["@imseq"].Value = strImSeq;
				this.sqlCommand1.Parameters["@fgupdated"].Value = strfgUpdated;
				this.sqlCommand1.Parameters["@fgact"].Value = strfgAct;
			
			
				// 確認執行 sqlCommand1 成功
				this.sqlCommand1.Connection.Open();
				// 使用 Transaction 確認有執行動作
				System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
				this.sqlCommand1.Transaction = myTrans1;
				//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
				try
				{
					this.sqlCommand1.ExecuteNonQuery();
					myTrans1.Commit();
					//Response.Write("新增落版資料成功!<br>");
				
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"新增落版資料成功\");</script>";
					Page.Controls.Add(litAlert1);
				}
				catch(System.Data.SqlClient.SqlException ex1)
				{
					Response.Write(ex1.Message + "<br>");
					myTrans1.Rollback();
					//Response.Write("新增落版資料失敗!<br>");
				
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"新增落版資料失敗, \n請印出畫面, 通知網頁連絡人!\");</script>";
					Page.Controls.Add(litAlert1);
				}
				finally
				{
					this.sqlCommand1.Connection.Close();
				}
			
			
				// 更新 合約檔 相關資料 - 
				// 先抓出 合約書相關資料, 再做計算
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds11 = new DataSet();
				this.sqlDataAdapter11.Fill(ds11, "c2_cont");
				DataView dv11 = ds11.Tables["c2_cont"].DefaultView;
			
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr11 = "1=1";
				rowfilterstr11 = rowfilterstr11 + " AND cont_syscd='" + strSyscd + "'";
				rowfilterstr11 = rowfilterstr11 + " AND cont_contno='" + strContNo + "'";
				dv11.RowFilter = rowfilterstr11;
			
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv11.Count= "+ dv11.Count + "<BR>");
				//Response.Write("dv11.RowFilter= " + dv11.RowFilter + "<BR>");
			
				// 若搜尋結果為 "找不到" 的處理
				float ContPubAmt = 0;
				float ContChgAmt = 0;
				int ContRestClrtm = 0;
				int ContRestGetClrtm = 0;
				int ContRestMenotm = 0;
				int ContTotjtm = 0;
				int ContMadejtm = 0;
				int ContRestjtm = 0;
				int ContPubtm = 0;
				int ContResttm = 0;
				string Contfgpubed = "1";
				int ContNjtpcnt = 0;
				if (dv11.Count > 0)
				{
					ContPubAmt = Convert.ToSingle(dv11[0]["cont_pubamt"].ToString().Trim());
					ContChgAmt = Convert.ToSingle(dv11[0]["cont_chgamt"].ToString().Trim());
					ContRestClrtm = Convert.ToInt32(dv11[0]["cont_restclrtm"].ToString().Trim());
					ContRestGetClrtm = Convert.ToInt32(dv11[0]["cont_restgetclrtm"].ToString().Trim());
					ContRestMenotm = Convert.ToInt32(dv11[0]["cont_restmenotm"].ToString().Trim());
					ContTotjtm = Convert.ToInt32(dv11[0]["cont_totjtm"].ToString().Trim());
					ContMadejtm = Convert.ToInt32(dv11[0]["cont_madejtm"].ToString().Trim());
					ContRestjtm = Convert.ToInt32(dv11[0]["cont_restjtm"].ToString().Trim());
					ContPubtm = Convert.ToInt32(dv11[0]["cont_pubtm"].ToString().Trim());
					ContResttm = Convert.ToInt32(dv11[0]["cont_resttm"].ToString().Trim());
					ContNjtpcnt = Convert.ToInt32(dv11[0]["cont_njtpcnt"].ToString().Trim());
				}
			
				// 重新計算 新結果
				// 落版總廣告金額 & 落版總換稿金額
				ContPubAmt = ContPubAmt + strAdAmt;
				ContChgAmt = ContChgAmt + strChgAmt;
			
			
				// 剩餘彩色/套色/黑白次數
				int CountClrtm = 0;
				CountClrtm = 1;
				// 若次數>0 (表示有資料), 則剩餘次數減一
				if(ContRestClrtm > 0)
				{
					ContRestClrtm = ContRestClrtm - CountClrtm;
				}
				else
				{
					ContRestClrtm = ContRestClrtm;
				}
			
				if(ContRestGetClrtm > 0)
				{
					ContRestGetClrtm = ContRestGetClrtm - CountClrtm;
				}
				else
				{
					ContRestGetClrtm = ContRestGetClrtm;
				}
			
				if(ContRestMenotm > 0)
				{
					ContRestMenotm = ContRestMenotm - CountClrtm;
				}
				else
				{
					ContRestMenotm = ContRestMenotm;
				}
			
			
				// 已製稿次數 & 剩餘製稿次數
				int CountMadejtm = 0;
				//Response.Write("strDrafttp= " + strDrafttp + "<br>");
				// 若為舊稿, 不做處理
				if(strDrafttp == "1")
				{
					CountMadejtm = 0;
					ContMadejtm = ContMadejtm;
					ContRestjtm = ContTotjtm - ContMadejtm;
				}
					// 若為 新稿/改稿, 則已製稿次數+1, 剩餘製稿次數-1
				else
				{
					CountMadejtm = 1;
					ContMadejtm = ContMadejtm + CountMadejtm;
					ContRestjtm = ContRestjtm - CountMadejtm;
				}
			
			
				// 已刊登次數 & 剩餘刊登次數
				int PubtmCount = 1;
				ContPubtm = ContPubtm + PubtmCount;
				ContResttm = ContResttm - PubtmCount;
			
			
				// 新稿份數
				int CountNjtpcd = 1;
				//Response.Write("strDrafttp= " + strDrafttp + "<br>");
				if(strDrafttp == "2")
					ContNjtpcnt = ContNjtpcnt + CountNjtpcd;
				else
					ContNjtpcnt = ContNjtpcnt;
				//Response.Write("CountNjtpcd= " + CountNjtpcd + "<br>");
			
				// 檢查欲更新的值
				//Response.Write("ContPubAmt= " + ContPubAmt + "<br>");
				//Response.Write("ContChgAmt= " + ContChgAmt + "<br>");
				//Response.Write("ContRestClrtm= " + ContRestClrtm + "<br>");
				//Response.Write("ContRestGetClrtm= " + ContRestGetClrtm + "<br>");
				//Response.Write("ContRestMenotm= " + ContRestMenotm + "<br>");
				//Response.Write("ContMadejtm= " + ContMadejtm + "<br>");
				//Response.Write("ContRestjtm= " + ContRestjtm + "<br>");
				//Response.Write("ContPubtm= " + ContPubtm + "<br>");
				//Response.Write("ContResttm= " + ContResttm + "<br>");
				//Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
			
				// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
				//Response.Write(this.sqlCommand2.CommandText);
				this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
				this.sqlCommand2.Parameters["@contno"].Value = strContNo;
				this.sqlCommand2.Parameters["@pubamt"].Value = ContPubAmt;
				this.sqlCommand2.Parameters["@chgamt"].Value = ContChgAmt;
				this.sqlCommand2.Parameters["@fgpubed"].Value = Contfgpubed;
				this.sqlCommand2.Parameters["@restclrtm"].Value = ContRestClrtm;
				this.sqlCommand2.Parameters["@restgetclrtm"].Value = ContRestGetClrtm;
				this.sqlCommand2.Parameters["@restmenotm"].Value = ContRestMenotm;
				this.sqlCommand2.Parameters["@madejtm"].Value = ContMadejtm;
				this.sqlCommand2.Parameters["@restjtm"].Value = ContRestjtm;
				this.sqlCommand2.Parameters["@pubtm"].Value = ContPubtm;
				this.sqlCommand2.Parameters["@resttm"].Value = ContResttm;
				this.sqlCommand2.Parameters["@njtpcnt"].Value = ContNjtpcnt;
			
				// 確認執行 sqlCommand2 成功
				this.sqlCommand2.Connection.Open();
				// 使用 Transaction 確認有執行動作
				System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand2.Connection.BeginTransaction();
				this.sqlCommand2.Transaction = myTrans2;
				//Response.Write(sqlCommand2.Parameters.Count.ToString().Trim());
				try
				{
					this.sqlCommand2.ExecuteNonQuery();
					myTrans2.Commit();
					//Response.Write("更新合約書相關資料成功!<br>");
				
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert2 = new LiteralControl();
					litAlert2.Text = "<script language=javascript>alert(\"更新合約書相關資料成功!\");</script>";
					Page.Controls.Add(litAlert2);
				}
				catch(System.Data.SqlClient.SqlException ex2)
				{
					Response.Write(ex2.Message + "<br>");
					myTrans2.Rollback();
					//Response.Write("更新合約書相關資料失敗!<br>");
				
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert2 = new LiteralControl();
					litAlert2.Text = "<script language=javascript>alert(\"更新合約書相關資料失敗, \n請印出畫面, 通知網頁連絡人!\");</script>";
					Page.Controls.Add(litAlert2);
				}
				finally
				{
					this.sqlCommand2.Connection.Close();
				}
			
			
				// panel 重新歸回
				this.ddlDraftType.SelectedIndex = 0;
				this.pnlOrig.Visible = true;
				this.pnlChg.Visible = false;
				this.rblfgrechg.Visible = false;
				this.pnlNjtp.Visible = false;
				
				
			// 結束: 若 ddlIMSeq 不為空者
			}
			else
			{
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"新增失敗: 不允許發票廠商收件人資料為空白. 請先補足!\");</script>";
				Page.Controls.Add(litAlert2);
			}
		}
		
		
		// 若稿件類別變更時
		private void ddlDraftType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// 抓出目前選擇的 稿件類別
			string drafttp = "";
			drafttp = this.ddlDraftType.SelectedItem.Value.ToString().Trim();
			
			// 依不同類別, 顯示不同 Panel
			if(drafttp == "1")
			{
				this.pnlOrig.Visible = true;
				this.pnlChg.Visible = false;
				this.rblfgrechg.Visible = false;
				this.pnlNjtp.Visible = false;
				this.rblfggot.Visible = false;
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"您選擇 '舊稿'! 請注意金額是否填在 '廣告金額'~\");</script>";
				Page.Controls.Add(litAlert1);
			}
			else if(drafttp == "2")
			{
				this.pnlOrig.Visible = false;
				this.pnlChg.Visible = false;
				this.rblfgrechg.Visible = false;
				this.pnlNjtp.Visible = true;
				this.rblfggot.Visible = true;
				this.rblfggot.SelectedIndex = 1;
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"您選擇 '新稿'! 請注意金額是否填在 '換稿金額', 並請註記是否到稿~\");</script>";
				Page.Controls.Add(litAlert2);
			}
			else if(drafttp == "3")
			{
				this.pnlOrig.Visible = false;
				this.pnlChg.Visible = true;
				this.rblfgrechg.Visible = true;
				this.pnlNjtp.Visible = false;
				this.rblfggot.Visible = true;
				this.rblfggot.SelectedIndex = 1;
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert3 = new LiteralControl();
				litAlert3.Text = "<script language=javascript>alert(\"您選擇 '改稿'! 請注意金額是否填在 '換稿金額', 並請註記是否到稿\");</script>";
				Page.Controls.Add(litAlert3);
			}
			else
			{
				this.pnlOrig.Visible = true;
				this.pnlChg.Visible = false;
				this.rblfgrechg.Visible = false;
				this.pnlNjtp.Visible = false;
				this.rblfggot.Visible = false;
			}
		}
		
		
		//
		private void btnGoChkList_Click(object sender, System.EventArgs e)
		{
			// 轉址處理 - 落版檢核表
			Response.Redirect("PubFm_chklist.aspx");
		}
		
		
		// 執行 刪除落版資料
		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Delete")
			{
				string strSyscd = "C2";
				string strContNo = this.tbxContNo.Text.ToString().Trim();
				string strYYYYMM = e.Item.Cells[3].Text.ToString().Trim();
				string strPubSeq = e.Item.Cells[2].Text.ToString();
				string strIMSeq = e.Item.Cells[10].Text.ToString().Trim();
				string strinved2 = e.Item.Cells[20].Text.ToString().Trim();
				//Response.Write("strSyscd= " + strSyscd + "<br>");
				//Response.Write("strContNo= " + strContNo + "<br>");
				//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
				//Response.Write("strPubSeq= " + strPubSeq + "<br>");
				//Response.Write("strIMSeq= " + strIMSeq + "<br>");
				//Response.Write("strinved2= " + strinved2 + "<br>");
				
				// 若落版資料已開發票(='v' or '1'), 則不予刪除, 但給予警告訊息; 除非將發票退回(改寫回 ' '), 才可刪除
				if(strinved2 == "v" || strinved2 == "1")
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlertInv2 = new LiteralControl();
					litAlertInv2.Text = "<script language=javascript>alert(\"不可刪除此筆落版檔, 因它已開立發票; 除非將此發票退回!\");</script>";
					Page.Controls.Add(litAlertInv2);
				}
				// 可進行刪除動作
				else
				{
					// 若落版資料 已結案且美編註記為1, 不允許刪除
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds17 = new DataSet();
					this.sqlDataAdapter17.Fill(ds17, "c2_cont");
					DataView dv17 = ds17.Tables["c2_cont"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr17 = "1=1";
					rowfilterstr17 = rowfilterstr17 + " AND pub_syscd='" + strSyscd + "'";
					rowfilterstr17 = rowfilterstr17 + " AND pub_contno='" + strContNo + "'";
					rowfilterstr17 = rowfilterstr17 + " AND pub_yyyymm='" + strYYYYMM + "'";
					rowfilterstr17 = rowfilterstr17 + " AND pub_pubseq='" + strPubSeq + "'";
					//rowfilterstr17 = rowfilterstr17 + " AND pub_imseq='" + strIMSeq + "'";
					rowfilterstr17 = rowfilterstr17 + " OR cont_fgclosed='1'";
					rowfilterstr17 = rowfilterstr17 + " OR pub_fgupdated='1'";
					rowfilterstr17 = rowfilterstr17 + " OR pub_fgact='1'";
					dv17.RowFilter = rowfilterstr17;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv17.Count= "+ dv17.Count + "<BR>");
					//Response.Write("dv17.RowFilter= " + dv17.RowFilter + "<BR>");
					
					// 若找不到此筆落版, 告知無法刪除
					if(dv17.Count < 0)
					{
						// do nothing
						// 以 Javascript 的 window.alert()  來告知訊息
						LiteralControl litAlert1 = new LiteralControl();
						litAlert1.Text = "<script language=javascript>alert(\"不可刪除此筆落版檔, 因它可能已結案\n或已做排版動作(或美編已做樣後修改)!\");</script>";
						Page.Controls.Add(litAlert1);
					}
					// 若找到(表示該合約尚未結案或尚未做排版動作或美編尚未做樣後修改動作), 則刪除該筆落版
					else
					{
						// 業務權限為 A or B 者, 才可刪除 落版資料
						string srspnAType = "";
						//				if(Session["atype"].ToString()=="a" || Session["atype"].ToString()=="b")
						//				{
						//				}
						//				else
						//				{
						//					LiteralControl litAlert = new LiteralControl();
						//					litAlert.Text = "<script language=javascript>alert(\"您沒有權限進行刪除, 請洽正式員工處理!\");</script>";
						//					Page.Controls.Add(litAlert);
						//				}
						
						
						
						// 步驟一: 刪除該筆落版資料
						// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 刪除
						this.sqlCommand3.Parameters["@syscd"].Value = strSyscd;
						this.sqlCommand3.Parameters["@contno"].Value = strContNo;
						this.sqlCommand3.Parameters["@yyyymm"].Value = strYYYYMM;
						this.sqlCommand3.Parameters["@pubseq"].Value = strPubSeq;
						
						// 確認執行 sqlCommand3 成功
						this.sqlCommand3.Connection.Open();
						// 使用 Transaction 確認有執行動作
						System.Data.SqlClient.SqlTransaction myTrans3 = this.sqlCommand3.Connection.BeginTransaction();
						this.sqlCommand3.Transaction = myTrans3;
						//Response.Write(sqlCommand3.Parameters.Count.ToString().Trim());
						try
						{
							this.sqlCommand3.ExecuteNonQuery();
							myTrans3.Commit();
							//Response.Write("刪除落版成功!<br>");
							
							// 以 Javascript 的 window.alert()  來告知訊息
							LiteralControl litAlert3 = new LiteralControl();
							litAlert3.Text = "<script language=javascript>alert(\"刪除落版成功\");</script>";
							Page.Controls.Add(litAlert3);
						}
						catch(System.Data.SqlClient.SqlException ex3)
						{
							Response.Write(ex3.Message + "<br>");
							myTrans3.Rollback();
							//Response.Write("刪除落版失敗!<br>");
							
							// 以 Javascript 的 window.alert()  來告知訊息
							LiteralControl litAlert3 = new LiteralControl();
							litAlert3.Text = "<script language=javascript>alert(\"刪除落版失敗\");</script>";
							Page.Controls.Add(litAlert3);
						}
						finally
						{
							this.sqlCommand3.Connection.Close();
						}
						
						
						// 步驟二: 抓出該落版資料的最大落版序號 MaxPubSeq; 若有(>1), 好方便抓出之後筆數之逐行資料, 再做更新處理
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds22 = new DataSet();
						// 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
						this.sqlDataAdapter22.SelectCommand.Parameters["@contno"].Value = strContNo;
						this.sqlDataAdapter22.SelectCommand.Parameters["@yyyymm"].Value = strYYYYMM;
						this.sqlDataAdapter22.Fill(ds22, "c2_pub");
						DataView dv22 = ds22.Tables["c2_pub"].DefaultView;
						
						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr22 = "1=1";
						dv22.RowFilter = rowfilterstr22;
						
						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv22.Count= "+ dv22.Count + "<BR>");
						//Response.Write("dv22.RowFilter= " + dv22.RowFilter + "<BR>");
						
						// 若搜尋結果為 "找到" 的處理
						string MaxPubSeq = "01";
						int intMaxPubSeq = Convert.ToInt16(MaxPubSeq);
						if (dv22.Count > 0)
						{
							MaxPubSeq = dv22[0]["MaxPubSeq"].ToString();
							//Response.Write("MaxPubSeq= " + MaxPubSeq + "<br>");
							intMaxPubSeq = Convert.ToInt16(MaxPubSeq);
							//Response.Write("intMaxPubSeq= " + intMaxPubSeq + "<br>");
							
							// 步驟三: 更新之後的序號之處理
							int intCurrentPubSeq = Convert.ToInt16(strPubSeq);
							if(strPubSeq == MaxPubSeq)
							{
								//Response.Write("do nothing...直接執行刪除落版資料即可<br>");
							}
							else
							{
								//Response.Write("處理更新事宜<br>");
								
								
								// 抓出 按下刪除之下一序號, 做為 for loop 起始值
								int intNextPubSeq = intCurrentPubSeq+1;
								//Response.Write("intNextPubSeq= " + intNextPubSeq + "<br>");
								
								// 抓出逐行落版資料, 做更新其落版序號之動作
								for(int i=intNextPubSeq; i<=intMaxPubSeq; i++)
								{
									string stri = Convert.ToString(i);
									if(stri.Length < 2)
										stri = "0" + stri;
									//Response.Write("stri= " + stri + "<br>");
									
									// 抓出逐行落版資料之 PK
									// 使用 DataSet 方法, 並指定使用的 table 名稱
									DataSet ds1 = new DataSet();
									// 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
									this.sqlDataAdapter1.Fill(ds1, "c2_pub");
									DataView dv1 = ds1.Tables["c2_pub"].DefaultView;
									
									// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
									// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
									string rowfilterstr1 = "1=1";
									rowfilterstr1 = rowfilterstr1 + " AND  pub_syscd='C2' ";
									rowfilterstr1 = rowfilterstr1 + " AND  pub_contno='" + strContNo + "'";
									rowfilterstr1 = rowfilterstr1 + " AND  pub_yyyymm='" + strYYYYMM + "'";
									rowfilterstr1 = rowfilterstr1 + " AND  pub_pubseq='" + stri + "'";
									dv1.RowFilter = rowfilterstr1;
									
									// 檢查並輸出 最後 Row Filter 的結果
									//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
									//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
									
									if(dv1.Count > 0)
									{
										string iSyscd = "C2";
										string iContNo = dv1[0]["pub_contno"].ToString();
										string iYYYYMM = dv1[0]["pub_yyyymm"].ToString();
										//Response.Write("iSyscd= " + iSyscd + ", ");
										//Response.Write("iContNo= " + iContNo + ", ");
										//Response.Write("iYYYYMM= " + iYYYYMM + ", ");
										//Response.Write("iPubSeq= " + stri + "<BR><BR>");
										
										int intNewPubSeq = i-1;
										string strNewPubSeq = Convert.ToString(intNewPubSeq);
										if(strNewPubSeq.Length < 2)
											strNewPubSeq = "0" + strNewPubSeq;
										//Response.Write("strNewPubSeq= " + strNewPubSeq + "<br>");
										
										
										// 執行更新動作
										string strConn9="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
										//string strConn9 = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
										SqlConnection myConn9=new SqlConnection(strConn9);
										
										SqlDataAdapter cmd9=new SqlDataAdapter("UPDATE c2_pub SET pub_pubseq = '" + strNewPubSeq + "' WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)",myConn9);
										//Response.Write("cmd9= UPDATE c2_pub SET pub_pubseq = '" + strNewPubSeq + "' WHERE (pub_syscd = " + iSyscd + ") AND (pub_contno = " + iContNo + ") AND (pub_yyyymm = " + iYYYYMM+ ") AND (pub_pubseq = " + stri + ")<br><br>");
										
										//cmd9.SelectCommand.Parameters.Add("@pub_pubid",SqlDbType.Int,4).Value = id;
										cmd9.SelectCommand.Parameters.Add("@syscd",SqlDbType.Char,2).Value = iSyscd;
										cmd9.SelectCommand.Parameters.Add("@contno",SqlDbType.Char,6).Value = iContNo;
										cmd9.SelectCommand.Parameters.Add("@yyyymm",SqlDbType.Char,6).Value = iYYYYMM;
										cmd9.SelectCommand.Parameters.Add("@pubseq",SqlDbType.Char,2).Value = stri;
										
										DataSet ds9 = new DataSet();
										cmd9.Fill(ds9,"c2_pub");
									}
									else
									{
										// Response.Write("do nothing!<br>");
									}
								
								// 結束 for loop
								}
							// 結束 步驟三 else
							}
						}
						else
						{
							MaxPubSeq = "01";
							intMaxPubSeq = 1;
						}
						
						// Refresh Page
						DataGrid1.CurrentPageIndex=0;
						BindGrid1();
						
						
						
						// 回寫 合約相關資料
						// 先抓出 合約書相關資料, 再做計算
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds11 = new DataSet();
						this.sqlDataAdapter11.Fill(ds11, "c2_cont");
						DataView dv11 = ds11.Tables["c2_cont"].DefaultView;
						
						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr11 = "1=1";
						rowfilterstr11 = rowfilterstr11 + " AND cont_syscd='" + strSyscd + "'";
						rowfilterstr11 = rowfilterstr11 + " AND cont_contno='" + strContNo + "'";
						dv11.RowFilter = rowfilterstr11;
						
						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv11.Count= "+ dv11.Count + "<BR>");
						//Response.Write("dv11.RowFilter= " + dv11.RowFilter + "<BR>");
						int ContTottm = 0;
						int ContTotClrtm = 0;
						int ContTotGetClrtm = 0;
						int ContTotMenotm = 0;
						int ContTotjtm = 0;
						int ContNjtpcnt = 0;
						if(dv11.Count > 0)
						{
							// 計算 剩餘刊登次數 - 先抓出 總刊登次數
							ContTottm = Convert.ToInt32(dv11[0]["cont_tottm"].ToString().Trim());
							
							// 計算 剩餘彩色/套色/黑白次數 - 先抓出 (總)彩色/套色/黑白次數
							ContTotClrtm = Convert.ToInt32(dv11[0]["cont_clrtm"].ToString().Trim());
							ContTotGetClrtm = Convert.ToInt32(dv11[0]["cont_getclrtm"].ToString().Trim());
							ContTotMenotm = Convert.ToInt32(dv11[0]["cont_menotm"].ToString().Trim());
							
							// 計算 剩餘製稿次數 - 先抓出 總製稿次數
							ContTotjtm = Convert.ToInt32(dv11[0]["cont_totjtm"].ToString().Trim());
							
							// 計算 新稿份數
							ContNjtpcnt = Convert.ToInt32(dv11[0]["cont_njtpcnt"].ToString().Trim());
						}
						else
						{
							ContTottm = ContTottm;
							ContTotClrtm = ContTotClrtm;
							ContTotGetClrtm = ContTotGetClrtm;
							ContTotMenotm = ContTotMenotm;
							ContTotjtm = ContTotjtm;
							ContNjtpcnt = ContNjtpcnt;
						}
						
						
						// 重新計算 新結果
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds13 = new DataSet();
						this.sqlDataAdapter13.Fill(ds13, "c2_pub");
						DataView dv13 = ds13.Tables["c2_pub"].DefaultView;
						
						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr13 = "1=1";
						rowfilterstr13 = rowfilterstr13 + " AND pub_syscd='" + strSyscd + "'";
						rowfilterstr13 = rowfilterstr13 + " AND pub_contno='" + strContNo + "'";
						dv13.RowFilter = rowfilterstr13;
						
						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv13.Count= "+ dv13.Count + "<BR>");
						//Response.Write("dv13.RowFilter= " + dv13.RowFilter + "<BR>");
						
						float PubAdAmt = 0;
						float PubChgAmt = 0;
						float ContPubAmt = 0;
						float ContChgAmt = 0;
						if (dv13.Count > 0)
						{
							// 落版總廣告金額 & 落版總換稿金額
							PubAdAmt = Convert.ToSingle(dv13[0]["pub_adamt"].ToString().Trim());
							ContPubAmt = PubAdAmt;
							//Response.Write("PubAdAmt= " + PubAdAmt + "<br>");
							//Response.Write("ContPubAmt= " + ContPubAmt + "<br>");
							PubChgAmt = Convert.ToSingle(dv13[0]["pub_chgamt"].ToString().Trim());
							ContChgAmt = PubChgAmt;
							//Response.Write("PubChgAmt= " + PubChgAmt + "<br>");
							//Response.Write("ContChgAmt= " + ContChgAmt + "<br>");
						}
						else
						{
							ContPubAmt = ContPubAmt;
							ContChgAmt = ContChgAmt;
						}
						
						
						int PubClrCount = 0;
						int ContPubClrtm = 0;
						int ContPubGetClrtm = 0;
						int ContPubMenotm = 0;
						int ContRestClrtm = 0;
						int ContRestGetClrtm = 0;
						int ContRestMenotm = 0;
						// 剩餘彩色/套色/黑白次數
						string clrcd = "";
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds14 = new DataSet();
						this.sqlDataAdapter14.Fill(ds14, "c2_pub");
						DataView dv14 = ds14.Tables["c2_pub"].DefaultView;
						
						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr14 = "1=1";
						rowfilterstr14 = rowfilterstr14 + " AND pub_syscd='" + strSyscd + "'";
						rowfilterstr14 = rowfilterstr14 + " AND pub_contno='" + strContNo + "'";
						dv14.RowFilter = rowfilterstr14;
						
						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv14.Count= "+ dv14.Count + "<BR>");
						//Response.Write("dv14.RowFilter= " + dv14.RowFilter + "<BR>");
						
						if(dv14.Count > 0)
						{
							for(int i=0; i < dv14.Count; i++)
							{
								clrcd = dv14[i]["pub_clrcd"].ToString().Trim();
								PubClrCount = Convert.ToInt32(dv14[i]["CountNo"].ToString().Trim());
								//Response.Write("clrcd= " + clrcd + "<br>");
								//Response.Write("PubClrCount= " + PubClrCount + "<br>");
							
								// 若為其他, 則依情況減一(當有資料時)
								// 依不同廣告色彩, 抓出目前已刊登的廣告色彩次數 PubClrCount, 以求得剩餘彩色/套色/黑白次數
								// 註: 以下 else 要暫時 disable, 才能抓到累積的次數; 否則是各行的正確結果
								if(clrcd == "01")
								{
									ContPubClrtm = PubClrCount;
									ContRestClrtm = ContTotClrtm - ContPubClrtm;
								}
								//else
								//ContRestClrtm = 0;
								if(clrcd == "02")
								{
									ContPubGetClrtm = PubClrCount;
									ContRestGetClrtm = ContTotGetClrtm - ContPubGetClrtm;
								}
								//else
								//ContRestGetClrtm = 0;
								if(clrcd == "03")
								{
									ContPubMenotm = PubClrCount;
									ContRestMenotm = ContTotMenotm - ContPubMenotm;
								}
								//else
								//ContRestMenotm = 0;
								//Response.Write("PubClrCount= " + PubClrCount + "<br>");
								//Response.Write("ContPubClrtm= " + ContPubClrtm + "<br>");
								//Response.Write("ContPubGetClrtm= " + ContPubGetClrtm + "<br>");
								//Response.Write("ContPubMenotm= " + ContPubMenotm + "<br>");
								//Response.Write("ContRestClrtm= " + ContRestClrtm + "<br>");
								//Response.Write("ContRestGetClrtm= " + ContRestGetClrtm + "<br>");
								//Response.Write("ContRestMenotm= " + ContRestMenotm + "<br>");
								// 結束 for loop
							}
						}
						else
						{
							PubClrCount = 0;
							ContRestClrtm = ContTotClrtm;
							ContRestGetClrtm = ContTotGetClrtm;
							ContRestMenotm = ContTotMenotm;
						}
						
						
						int PubDraftCount = 0;
						int ContMadejtm = 0;
						int ContRestjtm = 0;
						// 已製稿次數 & 剩餘製稿次數
						string drafttp = "";
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds15 = new DataSet();
						this.sqlDataAdapter15.Fill(ds15, "c2_pub");
						DataView dv15 = ds15.Tables["c2_pub"].DefaultView;
						
						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr15 = "1=1";
						rowfilterstr15 = rowfilterstr15 + " AND pub_syscd='" + strSyscd + "'";
						rowfilterstr15 = rowfilterstr15 + " AND pub_contno='" + strContNo + "'";
						dv15.RowFilter = rowfilterstr15;
						
						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv15.Count= "+ dv15.Count + "<BR>");
						//Response.Write("dv15.RowFilter= " + dv15.RowFilter + "<BR>");
						
						if(dv15.Count > 0)
						{
							for(int j=0; j < dv15.Count; j++)
							{
								drafttp = dv15[j]["pub_drafttp"].ToString().Trim();
								PubDraftCount = Convert.ToInt32(dv15[j]["CountNo"].ToString().Trim());
								//Response.Write("drafttp= " + drafttp + "<br>");
								//Response.Write("PubDraftCount= " + PubDraftCount + "<br>");
							
								// 若為舊稿, 不予處理
								if(drafttp == "1")
								{
									ContMadejtm = ContMadejtm;
									ContRestjtm = ContTotjtm - ContMadejtm;
								}
									// 若為 新稿/改稿, 則已製稿次數-1, 剩餘製稿次數+1
								else
								{
									ContMadejtm = ContMadejtm + PubDraftCount;
									ContRestjtm = ContTotjtm - ContMadejtm;
								}
							}
							//Response.Write("ContMadejtm= " + ContMadejtm + "<br>");
							//Response.Write("ContRestjtm= " + ContRestjtm + "<br>");
						}
						else
						{
							ContMadejtm = ContMadejtm;
							ContRestjtm = ContTotjtm - ContMadejtm;
						}
						
						
						int PubtmCount = 0;
						int ContPubtm = 0;
						int ContResttm = 0;
						// 已刊登次數 & 剩餘刊登次數
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds18 = new DataSet();
						this.sqlDataAdapter18.Fill(ds18, "c2_pub");
						DataView dv18 = ds18.Tables["c2_pub"].DefaultView;
						
						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr18 = "1=1";
						rowfilterstr18 = rowfilterstr18 + " AND pub_contno='" + strContNo + "'";
						dv18.RowFilter = rowfilterstr18;
						
						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv18.Count= "+ dv18.Count + "<BR>");
						//Response.Write("dv18.RowFilter= " + dv18.RowFilter + "<BR>");
						
						if(dv18.Count > 0)
						{
							PubtmCount = Convert.ToInt16(dv18[0]["CountNo"].ToString().Trim());
							ContPubtm = PubtmCount;
							ContResttm = ContTottm - PubtmCount;
						}
						else
						{
							PubtmCount = 0;
							ContPubtm = 0;
							ContResttm = ContTottm - ContPubtm;
						}
						//Response.Write("PubtmCount= " + PubtmCount + "<br>");
						//Response.Write("ContPubtm= " + ContPubtm + "<br>");
						//Response.Write("ContTottm= " + ContTottm + "<br>");
						//Response.Write("ContResttm= " + ContResttm + "<br>");
						
						
						// 新稿份數
						//Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds19 = new DataSet();
						this.sqlDataAdapter19.Fill(ds19, "c2_pub");
						DataView dv19 = ds19.Tables["c2_pub"].DefaultView;
						
						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr19 = "1=1";
						rowfilterstr19 = rowfilterstr19 + " AND pub_contno='" + strContNo + "'";
						dv19.RowFilter = rowfilterstr19;
						
						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv19.Count= "+ dv19.Count + "<BR>");
						//Response.Write("dv19.RowFilter= " + dv19.RowFilter + "<BR>");
						
						if(dv19.Count > 0)
						{
							ContNjtpcnt = Convert.ToInt16(dv19[0]["CountNo"].ToString().Trim());
						}
						else
						{
							ContNjtpcnt = ContNjtpcnt;
						}
						ContNjtpcnt = ContNjtpcnt;
						//Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
						
						
						string Contfgpubed = "1";
						// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
						//Response.Write(this.sqlCommand2.CommandText);
						this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
						this.sqlCommand2.Parameters["@contno"].Value = strContNo;
						this.sqlCommand2.Parameters["@pubamt"].Value = ContPubAmt;
						this.sqlCommand2.Parameters["@chgamt"].Value = ContChgAmt;
						this.sqlCommand2.Parameters["@fgpubed"].Value = Contfgpubed;
						this.sqlCommand2.Parameters["@restclrtm"].Value = ContRestClrtm;
						this.sqlCommand2.Parameters["@restgetclrtm"].Value = ContRestGetClrtm;
						this.sqlCommand2.Parameters["@restmenotm"].Value = ContRestMenotm;
						this.sqlCommand2.Parameters["@madejtm"].Value = ContMadejtm;
						this.sqlCommand2.Parameters["@restjtm"].Value = ContRestjtm;
						this.sqlCommand2.Parameters["@pubtm"].Value = ContPubtm;
						this.sqlCommand2.Parameters["@resttm"].Value = ContResttm;
						this.sqlCommand2.Parameters["@njtpcnt"].Value = ContNjtpcnt;
						
						
						// 確認執行 sqlCommand2 成功
						this.sqlCommand2.Connection.Open();
						// 使用 Transaction 確認有執行動作
						System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand2.Connection.BeginTransaction();
						this.sqlCommand2.Transaction = myTrans2;
						//Response.Write(sqlCommand2.Parameters.Count.ToString().Trim());
						try
						{
							this.sqlCommand2.ExecuteNonQuery();
							myTrans2.Commit();
							//Response.Write("更新合約書相關資料成功!<br>");
						
							// 以 Javascript 的 window.alert()  來告知訊息
							LiteralControl litAlert2 = new LiteralControl();
							litAlert2.Text = "<script language=javascript>alert(\"更新合約書相關資料成功\");</script>";
							Page.Controls.Add(litAlert2);
						}
						catch(System.Data.SqlClient.SqlException ex2)
						{
							Response.Write(ex2.Message + "<br>");
							myTrans2.Rollback();
							//Response.Write("更新合約書相關資料失敗!<br>");
						
							// 以 Javascript 的 window.alert()  來告知訊息
							LiteralControl litAlert2 = new LiteralControl();
							litAlert2.Text = "<script language=javascript>alert(\"更新合約書相關資料失敗, \n請印出畫面, 通知網頁連絡人!\");</script>";
							Page.Controls.Add(litAlert2);
						}
						finally
						{
							this.sqlCommand2.Connection.Close();
						}
						
						
						// Refresh DataGrid1
						// 若刪除所有資料時, 則不應再顯示 DataGrid1()
						//Response.Write("DataGrid1.Items.Count= " + DataGrid1.Items.Count + "<br>");
						DataGrid1.CurrentPageIndex = 0;
						BindGrid1();
						
						
						// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
						this.btnSave.Visible = true;
						this.btnModify.Visible = false;
						this.btnLoadData.Visible = true;
						this.btnGoChkList.Visible = true;
						
						
						// 給預設資料 - 新增Form
						if(DataGrid1.Items.Count == 1)
						{
							InitialData();
							//NewData();
						}
						
						
						// 清除畫面, 恢復至畫面初始
						ClearForm();
						
					// 結束 else -若找到(表示該合約尚未結案或尚未做排版動作或美編尚未做樣後修改動作), 則刪除該筆落版
					}
				
				// 結束 else (可進行刪除動作)
				}
			
			// 結束 if(e.CommandName == "Delete")
			}
		}
		
		
		// 修改 落版資料
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Select")
			{
				// 不允許修改 PK, 隱藏 PubSeq & YYYYMM & PNo
				// 注意: 若使用者輸錯 PK 資料, 要求刪除錯誤資料並重新輸入新的正確資料!
				this.lblPubSeq.Enabled = false;
				this.tbxYYYYMM.Disabled = true;
				this.tbxBkpPno.Disabled = true;
				
				
				// 抓出 PK 值, 將相關資料載入 新增Form 裡
				string strSyscd = "C2";
				string strContNo = this.tbxContNo.Text.ToString().Trim();
				string strYYYYMM = e.Item.Cells[3].Text.ToString().Trim();
				string strPubSeq = e.Item.Cells[2].Text.ToString();
				string strIMName = e.Item.Cells[11].Text.ToString().Trim();
				string strinved = e.Item.Cells[18].Text.ToString().Trim();
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
				//Response.Write("strPubSeq= " + strPubSeq + "<br>");
				//Response.Write("strIMName= " + strIMName + "<br>");
				//Response.Write("strinved= " + strinved + "<br>");
				
				// 若落版資料已開發票(='v' or '1'), 則不予修改, 但給予警告訊息; 除非將發票退回(改寫回 ' '), 才可修改
				if(strinved == "v" || strinved == "1")
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlertInv1 = new LiteralControl();
					litAlertInv1.Text = "<script language=javascript>alert(\"不可修改此筆落版檔, 因它已開立發票; 除非將此發票退回!\");</script>";
					Page.Controls.Add(litAlertInv1);
				}
				// 可進行修改動作
				else
				{
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds12 = new DataSet();
					this.sqlDataAdapter12.Fill(ds12, "c2_pub");
					DataView dv12 = ds12.Tables["c2_pub"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr12 = "1=1";
					rowfilterstr12 = rowfilterstr12 + " AND pub_syscd='" + strSyscd + "'";
					rowfilterstr12 = rowfilterstr12 + " AND pub_contno='" + strContNo + "'";
					rowfilterstr12 = rowfilterstr12 + " AND pub_yyyymm='" + strYYYYMM + "'";
					rowfilterstr12 = rowfilterstr12 + " AND pub_pubseq='" + strPubSeq + "'";
					dv12.RowFilter = rowfilterstr12;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv12.Count= "+ dv12.Count + "<BR>");
					//Response.Write("dv12.RowFilter= " + dv12.RowFilter + "<BR>");
					
					// 載入資料			
					if (dv12.Count > 0)
					{
						// 將序號顯示在 lblORItem; 否則修改時無法抓出其序號
						this.lblPubSeq.Visible = true;
						this.lblPubSeq.Text = strPubSeq;
						
						// 顯示其相關資料
						this.tbxYYYYMM.Value = strYYYYMM;
						this.tbxBkpPno.Value = dv12[0]["pub_pno"].ToString().Trim();
						this.tbxPageNo.Text = dv12[0]["pub_pgno"].ToString().Trim();
						this.ddlColorCode.ClearSelection();
						this.ddlColorCode.Items.FindByValue(dv12[0]["pub_clrcd"].ToString()).Selected = true;
						this.ddlLTypeCode.ClearSelection();
						this.ddlLTypeCode.Items.FindByValue(dv12[0]["pub_ltpcd"].ToString()).Selected = true;
						int ltpcd = Convert.ToInt16(dv12[0]["pub_ltpcd"].ToString().Trim());
						this.ddlPageSizeCode.ClearSelection();
						this.ddlPageSizeCode.Items.FindByValue(dv12[0]["pub_pgscd"].ToString()).Selected = true;
						// 註: rblfgfixpage 使用 SelectItem.Value並不能正確顯示其 index, 且 rblfgfixpage 的 Selected="True" 要關閉
						//Response.Write("pub_fgfixpg= " + dv12[0]["pub_fgfixpg"].ToString().Trim() + "<br>");
						this.rblfgfixpage.ClearSelection();
						this.rblfgfixpage.Items.FindByValue(dv12[0]["pub_fgfixpg"].ToString().Trim()).Selected = true;
						// 檢查 發廠收件人筆數, 來判斷下拉式選單的位置
						// 清除 下拉式選項, 再尋找其預選
						this.ddlIMSeq.ClearSelection();
						//Response.Write("this.ddlIMSeq.SelectedIndex= " + this.ddlIMSeq.SelectedIndex + "<br>");
						if(this.ddlIMSeq.SelectedIndex >= 1)
						{
							this.ddlIMSeq.Items.FindByValue(dv12[0]["pub_imseq"].ToString()).Selected = true;
						}
// 11/22/2002 debug 註：若開啟此段 else, 則客戶端偶爾會產生 ErrorMessage
//						else
//						{
//							this.ddlIMSeq.Items.FindByValue(dv12[0]["pub_imseq"].ToString()).Selected = true;
//						}
						this.tbxAdAmt.Text = dv12[0]["pub_adamt"].ToString().Trim();
						this.tbxChgAmt.Text = dv12[0]["pub_chgamt"].ToString().Trim();
						this.tbxRemark.Text = dv12[0]["pub_remark"].ToString().Trim();
						string drafttp = dv12[0]["pub_drafttp"].ToString().Trim();
						this.ddlDraftType.ClearSelection();
						this.ddlDraftType.Items.FindByValue(dv12[0]["pub_drafttp"].ToString().Trim()).Selected = true;
						if(drafttp == "1")
						{
							this.pnlOrig.Visible = true;
							this.pnlChg.Visible = false;
							this.rblfgrechg.Visible = false;
							this.pnlNjtp.Visible = false;
							this.rblfggot.Visible = false;
							
							this.ddlOrigBookCode.ClearSelection();
							this.ddlOrigBookCode.SelectedIndex = Convert.ToInt32(dv12[0]["pub_origbkcd"].ToString())-1;
							this.tbxOrigjno.Text = dv12[0]["pub_origjno"].ToString().Trim();
							this.tbxOrigbkno.Text = dv12[0]["pub_origjbkno"].ToString().Trim();
						}
						else if(drafttp == "2")
						{
							this.pnlOrig.Visible = false;
							this.pnlChg.Visible = false;
							this.rblfgrechg.Visible = false;
							this.pnlNjtp.Visible = true;
							this.rblfggot.Visible = true;
							
							this.ddlNJTypeCode.ClearSelection();
							this.ddlNJTypeCode.Items.FindByValue(dv12[0]["pub_njtpcd"].ToString()).Selected = true;
							
							this.rblfggot.ClearSelection();
							this.rblfggot.Items.FindByValue(dv12[0]["pub_fggot"].ToString().Trim()).Selected = true;
						}
						else if(drafttp == "3")
						{
							this.pnlOrig.Visible = false;
							this.pnlChg.Visible = true;
							this.rblfgrechg.Visible = true;
							this.pnlNjtp.Visible = false;
							this.rblfggot.Visible = true;
							
							this.ddlChgBookCode.ClearSelection();
							this.ddlChgBookCode.Items.FindByValue(dv12[0]["pub_chgbkcd"].ToString()).Selected = true;
							this.tbxChgjno.Text = dv12[0]["pub_chgjno"].ToString().Trim();
							this.tbxChgbkno.Text = dv12[0]["pub_chgjbkno"].ToString().Trim();
							this.rblfgrechg.ClearSelection();
							this.rblfgrechg.Items.FindByValue(dv12[0]["pub_fgrechg"].ToString().Trim()).Selected = true;
							this.rblfggot.ClearSelection();
							this.rblfggot.Items.FindByValue(dv12[0]["pub_fggot"].ToString().Trim()).Selected = true;
						}
						// 計劃代號 & 成本中心
						this.lblProjNo.Text = dv12[0]["pub_projno"].ToString().Trim();
						this.lblCostCtr.Text = dv12[0]["pub_costctr"].ToString().Trim();
					}
					
					// 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
					this.btnModify.Visible = true;
					this.btnSave.Visible = false;
					this.btnLoadData.Visible = false;
					this.btnGoChkList.Visible = false;
					
				// 結束 else (可進行修改動作)
				}
			
			// 結束 if(e.CommandName == "Delete")
			}
		}
		
		
		// 按下 儲存修改 按鈕
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			// 檢查 版面優先次序是否存在, 若存在呼叫ModifyDB(); 否則不允許修改
			CheckLPriorSeq2();
//			ModifyDB();
//			
//			// Refresh Page
//			DataGrid1.CurrentPageIndex=0;
//			BindGrid1();
//			
//			// 修改成功後, 將 儲存修改按鈕隱藏起來
//			this.btnModify.Visible = false;
//			this.btnSave.Visible = true;
//			this.btnLoadData.Visible = true;
//			
//			
//			// 回復 - 不允許修改 PK, 隱藏 PubSeq & YYYYMM & PNo
//			this.lblPubSeq.Enabled = true;
//			this.tbxYYYYMM.Disabled = false;
//			this.tbxBkpPno.Disabled = false;
//			
//			// 資料回復初始狀態
//			InitialData();
//			//NewData();
		}
		
		
		// 抓出畫面上 廣告版面/廣告色彩/廣告篇幅, 檢查此組合是否存在於 c2_lprior
		private void CheckLPriorSeq2()
		{
			// 落版檔資料 - 抓下畫面上的值
			string strBkcd = this.tbxBkcd.Text.ToString();
			string strLtpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
			string strClrcd = this.ddlColorCode.SelectedItem.Value.ToString();
			string strPgscd = this.ddlPageSizeCode.SelectedItem.Value.ToString();
			//Response.Write("strLtpcd= " + strLtpcd + "<br>");
			//Response.Write("strClrcd= " + strClrcd + "<br>");
			//Response.Write("strPgscd= " + strPgscd + "<br>");
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds21 = new DataSet();
			this.sqlDataAdapter21.Fill(ds21, "c2_lprior");
			DataView dv21 = ds21.Tables["c2_lprior"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr21 = "1=1";
			rowfilterstr21 = rowfilterstr21 + " AND lp_bkcd='" + strBkcd + "'";
			rowfilterstr21 = rowfilterstr21 + " AND lp_ltpcd='" + strLtpcd + "'";
			rowfilterstr21 = rowfilterstr21 + " AND lp_clrcd='" + strClrcd + "'";
			rowfilterstr21 = rowfilterstr21 + " AND lp_pgscd='" + strPgscd + "'";
			dv21.RowFilter = rowfilterstr21;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv21.Count= "+ dv21.Count + "<BR>");
			//Response.Write("dv21.RowFilter= " + dv21.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找到" 的處理: 允許新增/修改
			if (dv21.Count > 0)
			{
				// 執行修改動作
				ModifyDB();
				
				// Refresh Page
				DataGrid1.CurrentPageIndex=0;
				BindGrid1();
				
				// 修改成功後, 將 儲存修改按鈕隱藏起來
				this.btnModify.Visible = false;
				this.btnSave.Visible = true;
				this.btnLoadData.Visible = true;
				
				
				// 回復 - 不允許修改 PK, 隱藏 PubSeq & YYYYMM & PNo
				this.lblPubSeq.Enabled = true;
				this.tbxYYYYMM.Disabled = false;
				this.tbxBkpPno.Disabled = false;
				
				// 資料回復初始狀態
				InitialData();
				//NewData();
			}
			// 若找不到資料, 警告之並出現新視窗要求新增
			else
			{
				// 開啟小視窗
				string strbuf = "adlprior_addnew.aspx";
				strbuf = strbuf + "?function=mod&ltpcd=" + strLtpcd + "&clrcd=" + strClrcd + "&pgscd=" + strPgscd;
				//Response.Write(strbuf);
				
				// 以 Javascript 的 window.alert()  來告知訊息 - 移至 adlprior_addnew.aspx.cs
				// 以 Javascript 的 window.open()  來告知訊息
				litWinOpen1.Text="<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=600, height=450, left=80, top=20, scrollbars=yes');</script>";
				//litWinOpen1.Text="<script language=\"javascript\">window.showModalDialog(\"" + strbuf + "\", 'new Object()', 'dialogWidth:700px; dialogHeight:400px; dialogLeft:30px; dialogTop:22px; center:yes; scroll:yes; status:no; help:no;');</script>";
			}
		}
		
		
		// 修改資料 from DB Table
		private void ModifyDB()
		{
			// 抓出 畫面上的值
			string strSyscd = "C2";
			string strContNo = this.tbxContNo.Text.ToString().Trim();
			string strPubSeq = this.lblPubSeq.Text.ToString();
			string strYYYYMM = this.tbxYYYYMM.Value.ToString().Trim();
			string strBkpPno = this.tbxBkpPno.Value.ToString().Trim();
			int intPgNo = 0;
			if(this.tbxPageNo.Text.ToString().Trim() != "")
				intPgNo = Convert.ToInt32(this.tbxPageNo.Text.ToString().Trim());
			string strClrcd = this.ddlColorCode.SelectedItem.Value.ToString();
			string strLtpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
			string strPgscd = this.ddlPageSizeCode.SelectedItem.Value.ToString();
			// 若 strfgfixpg 沒有選擇時, 給予預設值 0
			string strfgfixpg = "0";
			if(this.rblfgfixpage.SelectedIndex >=  0)
				strfgfixpg = this.rblfgfixpage.SelectedItem.Value.ToString().Trim();
			else
				strfgfixpg = strfgfixpg;
			string strIMSeq = this.ddlIMSeq.SelectedItem.Value.ToString();
			float floatAdAmt = Convert.ToSingle(this.tbxAdAmt.Text.ToString().Trim());
			float floatChgAmt = Convert.ToSingle(this.tbxChgAmt.Text.ToString().Trim());
			//// 給予 strfginved 預設值 ' '  (表示 否 (尚未開立 發票開立單))
			//string strfginved = " ";
			// 給予 strfginvself 預設值 0 (表示 否)
			//string strfginvself = "0";
			string strRemark = this.tbxRemark.Text.ToString().Trim();
			string strDrafttp = this.ddlDraftType.SelectedItem.Value.ToString().Trim();
			string strOrigbkcd = "";
			int intOrigjno = 0;
			int intOrigbkno = 0;
			string strChgbkcd = "";
			int intChgjno = 0;
			int intChgbkno = 0;
			string strfgReChg = "";
			string strNjtpcd = "";
			string strfggot = "0";
			if(strDrafttp == "1")
			{
				strOrigbkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString();
				if(this.tbxOrigjno.Text.ToString().Trim() != "")
					intOrigjno = Convert.ToInt32(this.tbxOrigjno.Text.ToString().Trim());
				else
					intOrigjno = intOrigjno;
				if(this.tbxOrigbkno.Text.ToString().Trim() != "")
					intOrigbkno = Convert.ToInt32(this.tbxOrigbkno.Text.ToString().Trim());
				else
					intOrigbkno = intOrigbkno;
			}
			else if(strDrafttp == "2")
			{
				strNjtpcd = this.ddlNJTypeCode.SelectedItem.Value.ToString().Trim();
				// 若 strfggot 沒有選擇時, 給予預設值 0
				if(this.rblfggot.SelectedIndex >=  0)
					strfggot = this.rblfggot.SelectedItem.Value.ToString().Trim();
				else
					strfggot = strfggot;
			}
			else if(strDrafttp == "3")
			{
				strChgbkcd = this.ddlOrigBookCode.SelectedItem.Value.ToString();
				if(this.tbxChgjno.Text.ToString().Trim() != "")
					intChgjno = Convert.ToInt32(this.tbxChgjno.Text.ToString().Trim());
				else
					intChgjno = intChgjno;
				if(this.tbxChgbkno.Text.ToString().Trim() != "")
					intChgbkno = Convert.ToInt32(this.tbxChgbkno.Text.ToString().Trim());
				else
					intChgbkno = intChgbkno;
				// 若 strfgReChg 沒有選擇時, 給予預設值 0
				strfgReChg = "0";
				if(this.rblfgrechg.SelectedIndex >=  0)
					strfgReChg = this.rblfgrechg.SelectedItem.Value.ToString().Trim();
				else
					strfgReChg = strfgReChg;
				// 若 strfggot 沒有選擇時, 給予預設值 0
				if(this.rblfggot.SelectedIndex >=  0)
					strfggot = this.rblfggot.SelectedItem.Value.ToString().Trim();
				else
					strfggot = strfggot;
			}
			string strProjNo = this.lblProjNo.Text.ToString().Trim();
			string strCostCtr = this.lblCostCtr.Text.ToString().Trim();
			string strBkcd = this.tbxBkcd.Text.ToString();
			string strModDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
			//string strModEmpNo = "800443";
			// 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_show.aspx.cs 處不同處 
			// 抓出登入者的工號, 作為預設 修改業務員 之值
			string strModEmpNo = "";
			//Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
			// 若有登入者的資料, 則抓出並預選 修改業務員之下拉式選單
			if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!="")
			{
				strModEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			}
				// 若無登入者的資料, 則抓出並預選 修改業務員為 康靜怡 (800443, SelectedIndex=02)
			else
			{
				strModEmpNo = "800443";
			}
			//Response.Write("strSyscd= " + strSyscd + "<br>");
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strPubSeq= " + strPubSeq + "<br>");
			//Response.Write("strBkpPno= " + strBkpPno + "<br>");
			//Response.Write("floatAdAmt= " + floatAdAmt + "<br>");
			//Response.Write("floatChgAmt= " + floatChgAmt + "<br>");
			//Response.Write("strDrafttp= " + strDrafttp + "<br>");
			//Response.Write("strOrigbkcd= " + strOrigbkcd + "<br>");
			//Response.Write("intOrigjno= " + intOrigjno + "<br>");
			//Response.Write("intOrigbkno= " + intOrigbkno + "<br>");
			//Response.Write("strChgbkcd= " + strChgbkcd + "<br>");
			//Response.Write("intChgjno= " + intChgjno + "<br>");
			//Response.Write("intChgbkno= " + intChgbkno + "<br>");
			//Response.Write("strfgReChg= " + strfgReChg + "<br>");
			//Response.Write("strfggot= " + strfggot + "<br>");
			//Response.Write("strNjtpcd= " + strNjtpcd + "<br>");
			//Response.Write("strProjNo= " + strProjNo + "<br>");
			//Response.Write("strCostCtr= " + strCostCtr + "<br>");
			//Response.Write("strfginved= " + strfginved + "<br>");
			//Response.Write("strfginvself= " + strfginvself + "<br>");
			//Response.Write("intPgNo= " + intPgNo + "<br>");
			//Response.Write("strRemark= " + strRemark + "<br>");
			//Response.Write("strfgfixpg= " + strfgfixpg + "<br>");
			//Response.Write("strModDate= " + strModDate + "<br>");
			//Response.Write("strModEmpNo= " + strModEmpNo + "<br>");
			//Response.Write("strIMSeq= " + strIMSeq + "<br>");
			
			
			// 執行 將值塞入 sqlCommand4.Parameters 中, 以執行 新增入資料庫
			// 注意: 此 sqlCommand4 (update) 須到 Web Form Designer generated code 處, 手動修改其 sql型別 由 Variant 改為如 VarChar 之類
			this.sqlCommand4.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand4.Parameters["@contno"].Value = strContNo;
			this.sqlCommand4.Parameters["@yyyymm"].Value = strYYYYMM;
			this.sqlCommand4.Parameters["@pubseq"].Value = strPubSeq;
			this.sqlCommand4.Parameters["@pgno"].Value = intPgNo;
			this.sqlCommand4.Parameters["@ltpcd"].Value = strLtpcd;
			this.sqlCommand4.Parameters["@clrcd"].Value = strClrcd;
			this.sqlCommand4.Parameters["@pgscd"].Value = strPgscd;
			this.sqlCommand4.Parameters["@adamt"].Value = floatAdAmt;
			this.sqlCommand4.Parameters["@chgamt"].Value = floatChgAmt;
			this.sqlCommand4.Parameters["@drafttp"].Value = strDrafttp;
			this.sqlCommand4.Parameters["@origbkcd"].Value = strOrigbkcd;
			this.sqlCommand4.Parameters["@origjno"].Value = intOrigjno;
			this.sqlCommand4.Parameters["@origjbkno"].Value = intOrigbkno;
			this.sqlCommand4.Parameters["@chgbkcd"].Value = strChgbkcd;
			this.sqlCommand4.Parameters["@chgjno"].Value = intChgjno;
			this.sqlCommand4.Parameters["@chgjbkno"].Value = intChgbkno;
			this.sqlCommand4.Parameters["@fgrechg"].Value = strfgReChg;
			this.sqlCommand4.Parameters["@fggot"].Value = strfggot;
			this.sqlCommand4.Parameters["@njtpcd"].Value = strNjtpcd;
			this.sqlCommand4.Parameters["@projno"].Value = strProjNo;
			this.sqlCommand4.Parameters["@costctr"].Value = strCostCtr;
			//this.sqlCommand4.Parameters["@fginved"].Value = strfginved;
			//this.sqlCommand4.Parameters["@fginvself"].Value = strfginvself;
			this.sqlCommand4.Parameters["@pno"].Value = strBkpPno;
			this.sqlCommand4.Parameters["@remark"].Value = strRemark;
			this.sqlCommand4.Parameters["@fgfixpg"].Value = strfgfixpg;
			this.sqlCommand4.Parameters["@moddate"].Value = strModDate;
			this.sqlCommand4.Parameters["@modempno"].Value = strModEmpNo;
			this.sqlCommand4.Parameters["@bkcd"].Value = strBkcd;
			this.sqlCommand4.Parameters["@imseq"].Value = strIMSeq;
			
			
			// 確認執行 sqlSelectCommand1 成功
			this.sqlCommand4.Connection.Open();
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans4 = this.sqlCommand4.Connection.BeginTransaction();
			this.sqlCommand4.Transaction = myTrans4;
			//Response.Write(sqlCommand4.Parameters.Count.ToString().Trim());
			try
			{
				this.sqlCommand4.ExecuteNonQuery();
				myTrans4.Commit();
				//Response.Write("修改落版成功!<br>");
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert4 = new LiteralControl();
				litAlert4.Text = "<script language=javascript>alert(\"修改落版成功\");</script>";
				Page.Controls.Add(litAlert4);
			}
			catch(System.Data.SqlClient.SqlException ex4)
			{
				Response.Write(ex4.Message + "<br>");
				myTrans4.Rollback();
				//Response.Write("修改落版失敗!<br>");
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert4 = new LiteralControl();
				litAlert4.Text = "<script language=javascript>alert(\"修改落版失敗\");</script>";
				Page.Controls.Add(litAlert4);
			}
			finally
			{
				this.sqlCommand4.Connection.Close();
			}
			
			
			// 回寫 合約相關資料
			// 先抓出 合約書相關資料, 再做計算
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds11 = new DataSet();
			this.sqlDataAdapter11.Fill(ds11, "c2_cont");
			DataView dv11 = ds11.Tables["c2_cont"].DefaultView;
				
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr11 = "1=1";
			rowfilterstr11 = rowfilterstr11 + " AND cont_syscd='" + strSyscd + "'";
			rowfilterstr11 = rowfilterstr11 + " AND cont_contno='" + strContNo + "'";
			dv11.RowFilter = rowfilterstr11;
				
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv11.Count= "+ dv11.Count + "<BR>");
			//Response.Write("dv11.RowFilter= " + dv11.RowFilter + "<BR>");
			int ContTottm = 0;
			int ContTotClrtm = 0;
			int ContTotGetClrtm = 0;
			int ContTotMenotm = 0;
			int ContTotjtm = 0;
			int ContNjtpcnt = 0;
			if(dv11.Count > 0)
			{
				// 計算 剩餘刊登次數 - 先抓出 總刊登次數
				ContTottm = Convert.ToInt32(dv11[0]["cont_tottm"].ToString().Trim());
				
				// 計算 剩餘彩色/套色/黑白次數 - 先抓出 (總)彩色/套色/黑白次數
				ContTotClrtm = Convert.ToInt32(dv11[0]["cont_clrtm"].ToString().Trim());
				ContTotGetClrtm = Convert.ToInt32(dv11[0]["cont_getclrtm"].ToString().Trim());
				ContTotMenotm = Convert.ToInt32(dv11[0]["cont_menotm"].ToString().Trim());
				
				// 計算 剩餘製稿次數 - 先抓出 總製稿次數
				ContTotjtm = Convert.ToInt32(dv11[0]["cont_totjtm"].ToString().Trim());
				
				// 計算 新稿份數
				ContNjtpcnt = Convert.ToInt32(dv11[0]["cont_njtpcnt"].ToString().Trim());
			}
			else
			{
				ContTottm = ContTottm;
				ContTotClrtm = ContTotClrtm;
				ContTotGetClrtm = ContTotGetClrtm;
				ContTotMenotm = ContTotMenotm;
				ContTotjtm = ContTotjtm;
				ContNjtpcnt = ContNjtpcnt;
			}
			
			
			// 重新計算 新結果
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds13 = new DataSet();
			this.sqlDataAdapter13.Fill(ds13, "c2_pub");
			DataView dv13 = ds13.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr13 = "1=1";
			rowfilterstr13 = rowfilterstr13 + " AND pub_syscd='" + strSyscd + "'";
			rowfilterstr13 = rowfilterstr13 + " AND pub_contno='" + strContNo + "'";
			dv13.RowFilter = rowfilterstr13;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv13.Count= "+ dv13.Count + "<BR>");
			//Response.Write("dv13.RowFilter= " + dv13.RowFilter + "<BR>");
			
			float PubAdAmt = 0;
			float PubChgAmt = 0;
			float ContPubAmt = 0;
			float ContChgAmt = 0;
			if (dv13.Count > 0)
			{
				// 落版總廣告金額 & 落版總換稿金額
				PubAdAmt = Convert.ToSingle(dv13[0]["pub_adamt"].ToString().Trim());
				ContPubAmt = PubAdAmt;
				//Response.Write("PubAdAmt= " + PubAdAmt + "<br>");
				//Response.Write("ContPubAmt= " + ContPubAmt + "<br>");
				PubChgAmt = Convert.ToSingle(dv13[0]["pub_chgamt"].ToString().Trim());
				ContChgAmt = PubChgAmt;
				//Response.Write("PubChgAmt= " + PubChgAmt + "<br>");
				//Response.Write("ContChgAmt= " + ContChgAmt + "<br>");
			}
			else
			{
				ContPubAmt = ContPubAmt;
				ContChgAmt = ContChgAmt;
			}
			
			
			int PubClrCount = 0;
			int ContPubClrtm = 0;
			int ContPubGetClrtm = 0;
			int ContPubMenotm = 0;
			int ContRestClrtm = 0;
			int ContRestGetClrtm = 0;
			int ContRestMenotm = 0;
			// 剩餘彩色/套色/黑白次數
			string clrcd = "";
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds14 = new DataSet();
			this.sqlDataAdapter14.Fill(ds14, "c2_pub");
			DataView dv14 = ds14.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr14 = "1=1";
			rowfilterstr14 = rowfilterstr14 + " AND pub_syscd='" + strSyscd + "'";
			rowfilterstr14 = rowfilterstr14 + " AND pub_contno='" + strContNo + "'";
			dv14.RowFilter = rowfilterstr14;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv14.Count= "+ dv14.Count + "<BR>");
			//Response.Write("dv14.RowFilter= " + dv14.RowFilter + "<BR>");
			
			if(dv14.Count > 0)
			{
				for(int i=0; i < dv14.Count; i++)
				{
					clrcd = dv14[i]["pub_clrcd"].ToString().Trim();
					PubClrCount = Convert.ToInt32(dv14[i]["CountNo"].ToString().Trim());
					//Response.Write("clrcd= " + clrcd + "<br>");
					//Response.Write("PubClrCount= " + PubClrCount + "<br>");
						
					// 若為其他, 則依情況減一(當有資料時)
					// 依不同廣告色彩, 抓出目前已刊登的廣告色彩次數 PubClrCount, 以求得剩餘彩色/套色/黑白次數
					// 註: 以下 else 要暫時 disable, 才能抓到累積的次數; 否則是各行的正確結果
					if(clrcd == "01")
					{
						ContPubClrtm = PubClrCount;
						ContRestClrtm = ContTotClrtm - ContPubClrtm;
					}
					//else
					//ContRestClrtm = 0;
					if(clrcd == "02")
					{
						ContPubGetClrtm = PubClrCount;
						ContRestGetClrtm = ContTotGetClrtm - ContPubGetClrtm;
					}
					//else
					//ContRestGetClrtm = 0;
					if(clrcd == "03")
					{
						ContPubMenotm = PubClrCount;
						ContRestMenotm = ContTotMenotm - ContPubMenotm;
					}
					//else
					//ContRestMenotm = 0;
					//Response.Write("PubClrCount= " + PubClrCount + "<br>");
					//Response.Write("ContPubClrtm= " + ContPubClrtm + "<br>");
					//Response.Write("ContPubGetClrtm= " + ContPubGetClrtm + "<br>");
					//Response.Write("ContPubMenotm= " + ContPubMenotm + "<br>");
					//Response.Write("ContRestClrtm= " + ContRestClrtm + "<br>");
					//Response.Write("ContRestGetClrtm= " + ContRestGetClrtm + "<br>");
					//Response.Write("ContRestMenotm= " + ContRestMenotm + "<br>");
				// 結束 for loop
				}
			}
			else
			{
				PubClrCount = 0;
				ContRestClrtm = ContTotClrtm;
				ContRestGetClrtm = ContTotGetClrtm;
				ContRestMenotm = ContTotMenotm;
			}
			
			
			int PubDraftCount = 0;
			int ContMadejtm = 0;
			int ContRestjtm = 0;
			// 已製稿次數 & 剩餘製稿次數
			string drafttp = "";
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds15 = new DataSet();
			this.sqlDataAdapter15.Fill(ds15, "c2_pub");
			DataView dv15 = ds15.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr15 = "1=1";
			rowfilterstr15 = rowfilterstr15 + " AND pub_syscd='" + strSyscd + "'";
			rowfilterstr15 = rowfilterstr15 + " AND pub_contno='" + strContNo + "'";
			dv15.RowFilter = rowfilterstr15;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv15.Count= "+ dv15.Count + "<BR>");
			//Response.Write("dv15.RowFilter= " + dv15.RowFilter + "<BR>");
			
			if(dv15.Count > 0)
			{
				for(int j=0; j < dv15.Count; j++)
				{
					drafttp = dv15[j]["pub_drafttp"].ToString().Trim();
					PubDraftCount = Convert.ToInt32(dv15[j]["CountNo"].ToString().Trim());
					//Response.Write("drafttp= " + drafttp + "<br>");
					//Response.Write("PubDraftCount= " + PubDraftCount + "<br>");
						
					// 若為舊稿, 不予處理
					if(drafttp == "1")
					{
						ContMadejtm = ContMadejtm;
						ContRestjtm = ContTotjtm - ContMadejtm;
					}
						// 若為 新稿/改稿, 則已製稿次數-1, 剩餘製稿次數+1
					else
					{
						ContMadejtm = ContMadejtm + PubDraftCount;
						ContRestjtm = ContTotjtm - ContMadejtm;
					}
				//Response.Write("ContMadejtm= " + ContMadejtm + "<br>");
				//Response.Write("ContRestjtm= " + ContRestjtm + "<br>");
				}
			}
			else
			{
				ContMadejtm = ContMadejtm;
				ContRestjtm = ContTotjtm - ContMadejtm;
			}
			
			
			int PubtmCount = 0;
			int ContPubtm = 0;
			int ContResttm = 0;
			// 已刊登次數 & 剩餘刊登次數
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds18 = new DataSet();
			this.sqlDataAdapter18.Fill(ds18, "c2_pub");
			DataView dv18 = ds18.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr18 = "1=1";
			rowfilterstr18 = rowfilterstr18 + " AND pub_contno='" + strContNo + "'";
			dv18.RowFilter = rowfilterstr18;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv18.Count= "+ dv18.Count + "<BR>");
			//Response.Write("dv18.RowFilter= " + dv18.RowFilter + "<BR>");
			
			if(dv18.Count > 0)
			{
				PubtmCount = Convert.ToInt16(dv18[0]["CountNo"].ToString().Trim());
				ContPubtm = PubtmCount;
				ContResttm = ContTottm - PubtmCount;
			}
			else
			{
				PubtmCount = 0;
				ContPubtm = 0;
				ContResttm = ContTottm - ContPubtm;
			}
			//Response.Write("PubtmCount= " + PubtmCount + "<br>");
			//Response.Write("ContPubtm= " + ContPubtm + "<br>");
			//Response.Write("ContTottm= " + ContTottm + "<br>");
			//Response.Write("ContResttm= " + ContResttm + "<br>");
			
			
			// 新稿份數
			//Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds19 = new DataSet();
			this.sqlDataAdapter19.Fill(ds19, "c2_pub");
			DataView dv19 = ds19.Tables["c2_pub"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr19 = "1=1";
			rowfilterstr19 = rowfilterstr19 + " AND pub_contno='" + strContNo + "'";
			dv19.RowFilter = rowfilterstr19;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv19.Count= "+ dv19.Count + "<BR>");
			//Response.Write("dv19.RowFilter= " + dv19.RowFilter + "<BR>");
			
			if(dv19.Count > 0)
			{
				ContNjtpcnt = Convert.ToInt16(dv19[0]["CountNo"].ToString().Trim());
			}
			else
			{
				ContNjtpcnt = ContNjtpcnt;
			}
			//Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
			ContNjtpcnt = ContNjtpcnt;
			//Response.Write("ContNjtpcnt= " + ContNjtpcnt + "<br>");
			
			
			string Contfgpubed = "1";
			// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 更新
			//Response.Write(this.sqlCommand2.CommandText);
			this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand2.Parameters["@contno"].Value = strContNo;
			this.sqlCommand2.Parameters["@pubamt"].Value = ContPubAmt;
			this.sqlCommand2.Parameters["@chgamt"].Value = ContChgAmt;
			this.sqlCommand2.Parameters["@fgpubed"].Value = Contfgpubed;
			this.sqlCommand2.Parameters["@restclrtm"].Value = ContRestClrtm;
			this.sqlCommand2.Parameters["@restgetclrtm"].Value = ContRestGetClrtm;
			this.sqlCommand2.Parameters["@restmenotm"].Value = ContRestMenotm;
			this.sqlCommand2.Parameters["@madejtm"].Value = ContMadejtm;
			this.sqlCommand2.Parameters["@restjtm"].Value = ContRestjtm;
			this.sqlCommand2.Parameters["@pubtm"].Value = ContPubtm;
			this.sqlCommand2.Parameters["@resttm"].Value = ContResttm;
			this.sqlCommand2.Parameters["@njtpcnt"].Value = ContNjtpcnt;
			
			
			// 確認執行 sqlCommand2 成功
			this.sqlCommand2.Connection.Open();
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand2.Connection.BeginTransaction();
			this.sqlCommand2.Transaction = myTrans2;
			//Response.Write(sqlCommand2.Parameters.Count.ToString().Trim());
			try
			{
				this.sqlCommand2.ExecuteNonQuery();
				myTrans2.Commit();
				//Response.Write("更新合約書相關資料成功!<br>");
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"更新合約書相關資料成功\");</script>";
				Page.Controls.Add(litAlert2);
			}
			catch(System.Data.SqlClient.SqlException ex2)
			{
				Response.Write(ex2.Message + "<br>");
				myTrans2.Rollback();
				//Response.Write("更新合約書相關資料失敗!<br>");
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"更新合約書相關資料失敗, \n請印出畫面, 通知網頁連絡人!\");</script>";
				Page.Controls.Add(litAlert2);
			}
			finally
			{
				this.sqlCommand2.Connection.Close();
			}
			
			
			// 清除畫面, 恢復至畫面初始
			ClearForm();
			
		}
		
		
		// 若下拉式選單 廣告版面變更時 (且其為特殊版面), 則判斷是否要變更其 刊登頁碼
		private void ddlLTypeCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// 抓出 廣告版面代碼值
			string ltpcd = this.ddlLTypeCode.SelectedItem.Value.ToString();
			//Response.Write("ltpcd= " + ltpcd + "<br>");
			
			// 判斷頁碼及固定頁次註記
			string strPgno = "";
			// 封面
			if(ltpcd == "01")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 封面裡頁
			else if(ltpcd == "02")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 封底
			else if(ltpcd == "03")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 封底裡頁
			else if(ltpcd == "04")
			{
				strPgno = "0";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 首頁
			else if(ltpcd == "05")
			{
				strPgno = "3";
				this.rblfgfixpage.SelectedIndex = 0;
			}
			// 目錄右頁 - check c2_pgno 裡的資料值, 來決定此處的頁數範圍 (資料值-2 ~ 資料值-1)
			else if(ltpcd == "06")
			{
				strPgno = "";
				this.rblfgfixpage.SelectedIndex = 0;
				
				// 先抓出 內頁的起始頁碼
				if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
				{
					// 顯示 合約書籍的相關資料: 書籍名稱及代碼
					string strbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds16 = new DataSet();
					this.sqlDataAdapter16.Fill(ds16, "c2_pgno");
					DataView dv16 = ds16.Tables["c2_pgno"].DefaultView;
					
					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr16 = "1=1";
					rowfilterstr16 = rowfilterstr16 + " AND pg_bkcd='" + strbkcd + "'";
					dv16.RowFilter = rowfilterstr16;
					
					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv16.Count= "+ dv16.Count + "<BR>");
					//Response.Write("dv16.RowFilter= " + dv16.RowFilter + "<BR>");
					
					int StartPageNo = 0;
					int sNewPageNo = 0;
					int eNewPageNo = 0;
					if(dv16.Count > 0)
					{
						StartPageNo = Convert.ToInt16(dv16[0]["pg_startpgno"].ToString().Trim());
						sNewPageNo = StartPageNo - 2;
						eNewPageNo = StartPageNo -1;
						//Response.Write("StartPageNo= " + StartPageNo + "<br>");
						//Response.Write("sNewPageNo= " + sNewPageNo + "<br>");
						//Response.Write("eNewPageNo= " + eNewPageNo + "<br>");
						
						// 以 Javascript 的 window.alert()  來告知訊息
						LiteralControl litAlert2 = new LiteralControl();
						//litAlert2.Text = "<script language=javascript>alert(\"目錄右頁的刊登頁碼範圍為 " + sNewPageNo + "~" + eNewPageNo + ", 請自行填入!\");</script>";
						litAlert2.Text = "<script language=javascript>alert(\"目錄右頁的刊登頁碼, 請自行填入!\");</script>";
						Page.Controls.Add(litAlert2);
					}
					else
					{
						LiteralControl litAlert1 = new LiteralControl();
						litAlert1.Text = "<script language=javascript>alert(\"您沒有定義此種書籍類別的內頁起始頁碼, 請先至維護區維護!\n此處無法判斷目錄右頁的刊登頁碼範圍!!!\");</script>";
						Page.Controls.Add(litAlert1);
					}
				}
			}
			// 內頁
			else if(ltpcd == "50")
			{
				strPgno = this.tbxPageNo.Text;
				this.rblfgfixpage.SelectedIndex = 1;
			}
			this.tbxPageNo.Text = strPgno;
		}
		
		
		// 若增修　發票廠商收件人資料時, 要抓取最新的資料
		private void imbIMRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			GetInitIMData();
		}
		
		
		// 清除畫面, 恢復至畫面初始
		private void ClearForm()
		{
			// 回復 - 不允許修改 PK, 隱藏 PubSeq & YYYYMM & PNo
			this.lblPubSeq.Enabled = true;
			this.tbxYYYYMM.Disabled = false;
			this.tbxBkpPno.Disabled = false;
			
			
			// 清除畫面上的資料
			InitialData();
			//NewData();
			this.tbxYYYYMM.Value = "";
			this.tbxBkpPno.Value = "";
			this.tbxPageNo.Text = "";
			this.tbxRemark.Text = "";
			this.tbxOrigjno.Text = "";
			this.tbxOrigbkno.Text = "";
			
		}
		
		
		// 若變更下拉式選單 發票廠商收件人
		private void ddlIMSeq_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			// 顯示 合約書籍的相關資料: 書籍名稱及代碼
			string strContNo = this.tbxContNo.Text.ToString().Trim();
			string strIMSeq = this.ddlIMSeq.SelectedItem.Value.ToString().Trim();
			//Response.Write("strContNo= "+ strContNo + "<BR>");
			//Response.Write("strIMSeq= "+ strIMSeq + "<BR>");
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			this.sqlDataAdapter9.SelectCommand.Parameters["@contno"].Value = strContNo;
			DataSet ds9 = new DataSet();
			this.sqlDataAdapter9.Fill(ds9, "invmfr");
			DataView dv9 = ds9.Tables["invmfr"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr9 = "1=1";
			rowfilterstr9 = rowfilterstr9 + " AND im_imseq='" + strIMSeq + "'";
			dv9.RowFilter = rowfilterstr9;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv9.Count= "+ dv9.Count + "<BR>");
			//Response.Write("dv9.RowFilter= " + dv9.RowFilter + "<BR>");
			
			// 若搜尋結果為 "找不到" 的處理
			if (dv9.Count > 0)
			{
				string strbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
				this.tbxBkcd.Text = strbkcd;
				string strIMfgitri = dv9[0]["im_fgitri"].ToString().Trim();
				//Response.Write("strbkcd= " + strbkcd + "<br>");
				//Response.Write("strIMfgitri= " + strIMfgitri + "<br>");
				
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds7 = new DataSet();
				this.sqlDataAdapter7.Fill(ds7, "book");
				DataView dv7 = ds7.Tables["book"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr7 = "1=1";
				rowfilterstr7 = rowfilterstr7 + " AND proj_bkcd='" + strbkcd + "'";
				rowfilterstr7 = rowfilterstr7 + " AND proj_fgitri='" + strIMfgitri + "'";
				dv7.RowFilter = rowfilterstr7;
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
				//Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");
				
				// 若搜尋結果為 "找不到" 的處理
				if (dv7.Count > 0)
				{
					//this.tbxBkcd.Text = "合約書類：" + this.tbxBkcd.Text;
					this.tbxBookName.Text = dv7[0]["bk_nm"].ToString().Trim();
					//this.lblProjCostMessage.Text = "計劃代號／成本中心：";
					this.lblProjNo.Text =  dv7[0]["proj_projno"].ToString().Trim();
					this.lblCostCtr.Text = dv7[0]["proj_costctr"].ToString().Trim();
					
					// 若該發廠收件人為特殊之'發票類型', 則顯示其文字 -- 以下為 1/29/2003 added
					string strfgitri = dv7[0]["proj_fgitri"].ToString().Trim();
					if(strfgitri != "")
						this.lblfgITRI.Text = " (" + dv7[0]["fgitri_name"].ToString().Trim() + ")";
					else
						this.lblfgITRI.Text = "";
				}
			}
		}
		
		
//		// 若變更下拉式選單 舊稿書類 -- 1/29/2003 added
//		private void ddlOrigBookCode_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			// 載入 書籍類別, 計劃代號, 成本中心相關資料
//			LoadBkcdProjCost();
//		}
		
		
//		// 若變更下拉式選單 改稿書類 -- 1/29/2003 added
//		private void ddlChgBookCode_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			// 載入 書籍類別, 計劃代號, 成本中心相關資料
//			LoadBkcdProjCost();
//		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDataAdapter8 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter12 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand12 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter13 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand13 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter10 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter11 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand11 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter16 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand16 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter17 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand17 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter14 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand14 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter15 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand15 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter18 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand18 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter19 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand19 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter21 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand21 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter20 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand20 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter22 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand22 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter9 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.ddlLTypeCode.SelectedIndexChanged += new System.EventHandler(this.ddlLTypeCode_SelectedIndexChanged);
			this.ddlIMSeq.SelectedIndexChanged += new System.EventHandler(this.ddlIMSeq_SelectedIndexChanged);
			this.imbIMRefresh.Click += new System.Web.UI.ImageClickEventHandler(this.imbIMRefresh_Click);
			this.ddlDraftType.SelectedIndexChanged += new System.EventHandler(this.ddlDraftType_SelectedIndexChanged);
//			this.ddlChgBookCode.SelectedIndexChanged += new System.EventHandler(this.ddlChgBookCode_SelectedIndexChanged);
//			this.ddlOrigBookCode.SelectedIndexChanged += new System.EventHandler(this.ddlOrigBookCode_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			this.btnGoChkList.Click += new System.EventHandler(this.btnGoChkList_Click);
			// 
			// sqlDataAdapter8
			// 
			this.sqlDataAdapter8.SelectCommand = this.sqlSelectCommand8;
			this.sqlDataAdapter8.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "bookp", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("bkp_bkcd", "bkp_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_date", "bkp_date"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno")})});
			// 
			// sqlSelectCommand8
			// 
			this.sqlSelectCommand8.CommandText = "SELECT bkp_bkcd, RTRIM(bkp_date) AS bkp_date, RTRIM(bkp_pno) AS bkp_pno FROM dbo." +
				"bookp";
			this.sqlSelectCommand8.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter12
			// 
			this.sqlDataAdapter12.SelectCommand = this.sqlSelectCommand12;
			this.sqlDataAdapter12.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				 new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_moddate", "pub_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgact", "pub_fgact")})});
			// 
			// sqlSelectCommand12
			// 
			this.sqlSelectCommand12.CommandText = @"SELECT pub_syscd, pub_contno, pub_yyyymm, pub_pubseq, pub_pgno, pub_ltpcd, pub_clrcd, pub_pgscd, pub_adamt, pub_chgamt, pub_drafttp, pub_origbkcd, pub_origjno, pub_origjbkno, pub_chgbkcd, pub_chgjno, pub_chgjbkno, pub_fgrechg, pub_fggot, pub_njtpcd, pub_projno, pub_costctr, pub_fginved, pub_fginvself, pub_pno, pub_remark, pub_fgfixpg, pub_moddate, pub_modempno, pub_bkcd, pub_imseq, pub_fgupdated, pub_fgact FROM dbo.c2_pub";
			this.sqlSelectCommand12.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter13
			// 
			this.sqlDataAdapter13.SelectCommand = this.sqlSelectCommand13;
			this.sqlDataAdapter13.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
			// 
			// sqlSelectCommand13
			// 
			this.sqlSelectCommand13.CommandText = "SELECT pub_syscd, pub_contno, SUM(pub_adamt) AS pub_adamt, SUM(pub_chgamt) AS pub" +
				"_chgamt, COUNT(*) AS CountNo FROM dbo.c2_pub GROUP BY pub_syscd, pub_contno";
			this.sqlSelectCommand13.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter10
			// 
			this.sqlDataAdapter10.SelectCommand = this.sqlSelectCommand10;
			this.sqlDataAdapter10.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq")})});
			// 
			// sqlSelectCommand10
			// 
			this.sqlSelectCommand10.CommandText = "SELECT COUNT(*) AS CountNo, pub_contno, pub_yyyymm, pub_pubseq FROM dbo.c2_pub GR" +
				"OUP BY pub_yyyymm, pub_pubseq, pub_contno ORDER BY pub_contno, pub_yyyymm, pub_p" +
				"ubseq DESC";
			this.sqlSelectCommand10.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter11
			// 
			this.sqlDataAdapter11.SelectCommand = this.sqlSelectCommand11;
			this.sqlDataAdapter11.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				  new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				  new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				  new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				  new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				  new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				  new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_adamt", "cont_adamt"),
																																																				  new System.Data.Common.DataColumnMapping("cont_restclrtm", "cont_restclrtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_restmenotm", "cont_restmenotm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_restgetclrtm", "cont_restgetclrtm"),
																																																				  new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				  new System.Data.Common.DataColumnMapping("cont_njtpcnt", "cont_njtpcnt")})});
			// 
			// sqlSelectCommand11
			// 
			this.sqlSelectCommand11.CommandText = @"SELECT cont_syscd, cont_contno, cont_totjtm, cont_madejtm, cont_restjtm, cont_tottm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_pubamt, cont_chgamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_adamt, cont_restclrtm, cont_restmenotm, cont_restgetclrtm, cont_fgpubed, cont_njtpcnt FROM dbo.c2_cont";
			this.sqlSelectCommand11.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter16
			// 
			this.sqlDataAdapter16.SelectCommand = this.sqlSelectCommand16;
			this.sqlDataAdapter16.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pgno", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("pg_bkcd", "pg_bkcd"),
																																																				  new System.Data.Common.DataColumnMapping("pg_startpgno", "pg_startpgno")})});
			// 
			// sqlSelectCommand16
			// 
			this.sqlSelectCommand16.CommandText = "SELECT pg_bkcd, pg_startpgno FROM dbo.c2_pgno";
			this.sqlSelectCommand16.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter17
			// 
			this.sqlDataAdapter17.SelectCommand = this.sqlSelectCommand17;
			this.sqlDataAdapter17.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				  new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				  new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated"),
																																																				  new System.Data.Common.DataColumnMapping("pub_fgact", "pub_fgact"),
																																																				  new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				  new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				  new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				  new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq")})});
			// 
			// sqlSelectCommand17
			// 
			this.sqlSelectCommand17.CommandText = @"SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_cont.cont_fgclosed, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_imseq FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno";
			this.sqlSelectCommand17.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter14
			// 
			this.sqlDataAdapter14.SelectCommand = this.sqlSelectCommand14;
			this.sqlDataAdapter14.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
			// 
			// sqlSelectCommand14
			// 
			this.sqlSelectCommand14.CommandText = "SELECT pub_syscd, pub_contno, pub_clrcd, COUNT(*) AS CountNo FROM dbo.c2_pub GROU" +
				"P BY pub_syscd, pub_contno, pub_clrcd";
			this.sqlSelectCommand14.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter15
			// 
			this.sqlDataAdapter15.SelectCommand = this.sqlSelectCommand15;
			this.sqlDataAdapter15.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
			// 
			// sqlSelectCommand15
			// 
			this.sqlSelectCommand15.CommandText = "SELECT pub_syscd, pub_contno, pub_drafttp, COUNT(*) AS CountNo FROM dbo.c2_pub GR" +
				"OUP BY pub_syscd, pub_contno, pub_drafttp";
			this.sqlSelectCommand15.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter18
			// 
			this.sqlDataAdapter18.SelectCommand = this.sqlSelectCommand18;
			this.sqlDataAdapter18.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
			// 
			// sqlSelectCommand18
			// 
			this.sqlSelectCommand18.CommandText = "SELECT pub_syscd, pub_contno, COUNT(*) AS CountNo FROM dbo.c2_pub WHERE (pub_sysc" +
				"d = \'C2\') GROUP BY pub_syscd, pub_contno";
			this.sqlSelectCommand18.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter19
			// 
			this.sqlDataAdapter19.SelectCommand = this.sqlSelectCommand19;
			this.sqlDataAdapter19.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
			// 
			// sqlSelectCommand19
			// 
			this.sqlSelectCommand19.CommandText = "SELECT pub_syscd, pub_contno, pub_drafttp, COUNT(*) AS CountNo FROM dbo.c2_pub WH" +
				"ERE (pub_drafttp = \'2\') GROUP BY pub_syscd, pub_contno, pub_drafttp";
			this.sqlSelectCommand19.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter21
			// 
			this.sqlDataAdapter21.SelectCommand = this.sqlSelectCommand21;
			this.sqlDataAdapter21.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																					new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																					new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																					new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																					new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
			// 
			// sqlSelectCommand21
			// 
			this.sqlSelectCommand21.CommandText = "SELECT lp_bkcd, lp_priorseq, lp_ltpcd, lp_clrcd, lp_pgscd FROM dbo.c2_lprior";
			this.sqlSelectCommand21.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter20
			// 
			this.sqlDataAdapter20.SelectCommand = this.sqlSelectCommand20;
			this.sqlDataAdapter20.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
			// 
			// sqlSelectCommand20
			// 
			this.sqlSelectCommand20.CommandText = "SELECT im_syscd, im_contno, COUNT(*) AS CountNo FROM dbo.invmfr WHERE (im_syscd =" +
				" \'C2\') GROUP BY im_syscd, im_contno";
			this.sqlSelectCommand20.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter22
			// 
			this.sqlDataAdapter22.SelectCommand = this.sqlSelectCommand22;
			this.sqlDataAdapter22.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("MaxPubSeq", "MaxPubSeq")})});
			// 
			// sqlSelectCommand22
			// 
			this.sqlSelectCommand22.CommandText = "SELECT pub_syscd, pub_contno, pub_yyyymm, MAX(pub_pubseq) AS MaxPubSeq FROM dbo.c" +
				"2_pub WHERE (pub_syscd = \'C2\') AND (pub_contno = @contno) AND (pub_yyyymm = @yyy" +
				"ymm) GROUP BY pub_syscd, pub_contno, pub_yyyymm";
			this.sqlSelectCommand22.Connection = this.sqlConnection1;
			this.sqlSelectCommand22.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, "pub_contno"));
			this.sqlSelectCommand22.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "DELETE FROM c2_pub WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub" +
				"_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "pub_syscd"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "pub_contno"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, "pub_yyyymm"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.Char, 2, "pub_pubseq"));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = @"UPDATE c2_cont SET cont_pubamt = @pubamt, cont_chgamt = @chgamt, cont_fgpubed = @fgpubed, cont_restclrtm = @restclrtm, cont_restmenotm = @restmenotm, cont_restgetclrtm = @restgetclrtm, cont_madejtm = @madejtm, cont_restjtm = @restjtm, cont_pubtm = @pubtm, cont_resttm = @resttm, cont_njtpcnt = @njtpcnt WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubamt", System.Data.SqlDbType.Real, 4, "cont_pubamt"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgamt", System.Data.SqlDbType.Real, 4, "cont_chgamt"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgpubed", System.Data.SqlDbType.Char, 1, "cont_fgpubed"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restclrtm", System.Data.SqlDbType.Int, 4, "cont_restclrtm"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restmenotm", System.Data.SqlDbType.Int, 4, "cont_restmenotm"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restgetclrtm", System.Data.SqlDbType.Int, 4, "cont_restgetclrtm"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@madejtm", System.Data.SqlDbType.Int, 4, "cont_madejtm"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restjtm", System.Data.SqlDbType.Int, 4, "cont_restjtm"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubtm", System.Data.SqlDbType.Int, 4, "cont_pubtm"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@resttm", System.Data.SqlDbType.Int, 4, "cont_resttm"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtpcnt", System.Data.SqlDbType.Int, 4, "cont_njtpcnt"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "cont_syscd"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "cont_contno"));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = @"INSERT INTO c2_pub (pub_syscd, pub_contno, pub_yyyymm, pub_pubseq, pub_pgno, pub_ltpcd, pub_clrcd, pub_pgscd, pub_adamt, pub_chgamt, pub_drafttp, pub_origbkcd, pub_origjno, pub_origjbkno, pub_chgbkcd, pub_chgjno, pub_chgjbkno, pub_fgrechg, pub_fggot, pub_njtpcd, pub_projno, pub_costctr, pub_fginved, pub_fginvself, pub_pno, pub_remark, pub_fgfixpg, pub_moddate, pub_modempno, pub_bkcd, pub_imseq, pub_fgupdated, pub_fgact) VALUES (@syscd, @contno, @yyyymm, @pubseq, @pgno, @ltpcd, @clrcd, @pgscd, @adamt, @chgamt, @drafttp, @origbkcd, @origjno, @origjbkno, @chgbkcd, @chgjno, @chgjbkno, @fgrechg, @fggot, @njtpcd, @projno, @costctr, @fginved, @fginvself, @pno, @remark, @fgfixpg, @moddate, @modempno, @bkcd, @imseq, @fgupdated, @fgact)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "pub_syscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "pub_contno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, "pub_yyyymm"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.Char, 2, "pub_pubseq"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pgno", System.Data.SqlDbType.Int, 4, "pub_pgno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ltpcd", System.Data.SqlDbType.Char, 2, "pub_ltpcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@clrcd", System.Data.SqlDbType.Char, 2, "pub_clrcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pgscd", System.Data.SqlDbType.Char, 2, "pub_pgscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adamt", System.Data.SqlDbType.Real, 4, "pub_adamt"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgamt", System.Data.SqlDbType.Real, 4, "pub_chgamt"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@drafttp", System.Data.SqlDbType.Char, 1, "pub_drafttp"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@origbkcd", System.Data.SqlDbType.Char, 2, "pub_origbkcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@origjno", System.Data.SqlDbType.Int, 4, "pub_origjno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@origjbkno", System.Data.SqlDbType.Int, 4, "pub_origjbkno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgbkcd", System.Data.SqlDbType.Char, 2, "pub_chgbkcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgjno", System.Data.SqlDbType.Int, 4, "pub_chgjno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgjbkno", System.Data.SqlDbType.Int, 4, "pub_chgjbkno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgrechg", System.Data.SqlDbType.Char, 1, "pub_fgrechg"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fggot", System.Data.SqlDbType.Char, 1, "pub_fggot"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtpcd", System.Data.SqlDbType.Char, 2, "pub_njtpcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@projno", System.Data.SqlDbType.Char, 10, "pub_projno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@costctr", System.Data.SqlDbType.Char, 7, "pub_costctr"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fginved", System.Data.SqlDbType.Char, 1, "pub_fginved"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fginvself", System.Data.SqlDbType.Char, 1, "pub_fginvself"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pno", System.Data.SqlDbType.Char, 4, "pub_pno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@remark", System.Data.SqlDbType.VarChar, 50, "pub_remark"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgfixpg", System.Data.SqlDbType.Char, 1, "pub_fgfixpg"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@moddate", System.Data.SqlDbType.Char, 8, "pub_moddate"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@modempno", System.Data.SqlDbType.Char, 7, "pub_modempno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.Char, 2, "pub_bkcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, "pub_imseq"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgupdated", System.Data.SqlDbType.Char, 1, "pub_fgupdated"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgact", System.Data.SqlDbType.Char, 1, "pub_fgact"));
			// 
			// sqlCommand5
			// 
			this.sqlCommand5.CommandText = "UPDATE c2_cont SET cont_fgpubed = \'0\' WHERE (cont_syscd = @syscd) AND (cont_contn" +
				"o = @contno)";
			this.sqlCommand5.Connection = this.sqlConnection1;
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "cont_syscd"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "cont_contno"));
			// 
			// sqlCommand4
			// 
			this.sqlCommand4.CommandText = @"UPDATE dbo.c2_pub SET pub_pgno = @pgno, pub_ltpcd = @ltpcd, pub_clrcd = @clrcd, pub_pgscd = @pgscd, pub_adamt = @adamt, pub_chgamt = @chgamt, pub_drafttp = @drafttp, pub_origbkcd = @origbkcd, pub_origjno = @origjno, pub_origjbkno = @origjbkno, pub_chgbkcd = @chgbkcd, pub_chgjno = @chgjno, pub_chgjbkno = @chgjbkno, pub_fgrechg = @fgrechg, pub_fggot = @fggot, pub_njtpcd = @njtpcd, pub_projno = @projno, pub_costctr = @costctr, pub_pno = @pno, pub_remark = @remark, pub_fgfixpg = @fgfixpg, pub_moddate = @moddate, pub_modempno = @modempno, pub_bkcd = @bkcd, pub_imseq = @imseq WHERE (pub_syscd = @syscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand4.Connection = this.sqlConnection1;
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pgno", System.Data.SqlDbType.Int, 4, "pub_pgno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ltpcd", System.Data.SqlDbType.VarChar, 2, "pub_ltpcd"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@clrcd", System.Data.SqlDbType.VarChar, 2, "pub_clrcd"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pgscd", System.Data.SqlDbType.VarChar, 2, "pub_pgscd"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adamt", System.Data.SqlDbType.Real, 4, "pub_adamt"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgamt", System.Data.SqlDbType.Real, 4, "pub_chgamt"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@drafttp", System.Data.SqlDbType.VarChar, 1, "pub_drafttp"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@origbkcd", System.Data.SqlDbType.VarChar, 2, "pub_origbkcd"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@origjno", System.Data.SqlDbType.Int, 4, "pub_origjno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@origjbkno", System.Data.SqlDbType.Int, 4, "pub_origjbkno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgbkcd", System.Data.SqlDbType.VarChar, 2, "pub_chgbkcd"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgjno", System.Data.SqlDbType.Int, 4, "pub_chgjno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgjbkno", System.Data.SqlDbType.Int, 4, "pub_chgjbkno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgrechg", System.Data.SqlDbType.VarChar, 1, "pub_fgrechg"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fggot", System.Data.SqlDbType.VarChar, 1, "pub_fggot"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtpcd", System.Data.SqlDbType.VarChar, 2, "pub_njtpcd"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@projno", System.Data.SqlDbType.VarChar, 10, "pub_projno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@costctr", System.Data.SqlDbType.VarChar, 7, "pub_costctr"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pno", System.Data.SqlDbType.VarChar, 4, "pub_pno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@remark", System.Data.SqlDbType.VarChar, 50, "pub_remark"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgfixpg", System.Data.SqlDbType.VarChar, 1, "pub_fgfixpg"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@moddate", System.Data.SqlDbType.VarChar, 8, "pub_moddate"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@modempno", System.Data.SqlDbType.VarChar, 7, "pub_modempno"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "pub_bkcd"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.VarChar, 2, "pub_imseq"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_clr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("clr_clrid", "clr_clrid"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT clr_clrid, clr_clrcd, RTRIM(clr_nm) AS clr_nm FROM dbo.c2_clr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adamt", "cont_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freebkcnt", "cont_freebkcnt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("MaxPubTime", "MaxPubTime"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restclrtm", "cont_restclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restmenotm", "cont_restmenotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restgetclrtm", "cont_restgetclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_modempno, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_chgjtm, dbo.c2_cont.cont_custno, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pubamt, dbo.c2_cont.cont_chgamt, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_adamt, dbo.c2_cont.cont_freebkcnt, dbo.c2_cont.cont_freetm, dbo.c2_cont.cont_tottm + dbo.c2_cont.cont_freetm AS MaxPubTime, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_restclrtm, dbo.c2_cont.cont_restmenotm, dbo.c2_cont.cont_restgetclrtm, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_pubtm, dbo.c2_cont.cont_resttm, dbo.c2_cont.cont_madejtm, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont_disc, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.cust.cust_nm) AS cust_nm FROM dbo.c2_cont INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "fgitri", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgact", "pub_fgact"),
																																																				new System.Data.Common.DataColumnMapping("pub_moddate", "pub_moddate"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																				new System.Data.Common.DataColumnMapping("fgitri_fgitri", "fgitri_fgitri"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri"),
																																																				new System.Data.Common.DataColumnMapping("fgitri_name", "fgitri_name")})});
			// 
			// sqlDataAdapter7
			// 
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("fgitri_name", "fgitri_name"),
																																																			  new System.Data.Common.DataColumnMapping("fgitri_fgitri", "fgitri_fgitri")})});
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_njtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm")})});
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT njtp_njtpcd, RTRIM(njtp_nm) AS njtp_nm FROM dbo.c2_njtp";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgsize", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT pgs_pgscd, RTRIM(pgs_nm) AS pgs_nm FROM dbo.c2_pgsize";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT ltp_ltpcd, RTRIM(ltp_nm) AS ltp_nm FROM dbo.c2_ltp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter9
			// 
			this.sqlDataAdapter9.SelectCommand = this.sqlSelectCommand9;
			this.sqlDataAdapter9.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri")})});
			// 
			// sqlSelectCommand9
			// 
			this.sqlSelectCommand9.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_nm, im_fgitri FROM dbo.invmfr WHERE (im_" +
				"syscd = \'C2\') AND (im_contno = @contno)";
			this.sqlSelectCommand9.Connection = this.sqlConnection1;
			this.sqlSelectCommand9.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, "im_contno"));
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr, dbo.fgitri.fgitri_name, dbo.fgitri.fgitri_fgitri FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd INNER JOIN dbo.fgitri ON dbo.proj.proj_fgitri = dbo.fgitri.fgitri_fgitri WHERE (dbo.proj.proj_syscd = 'C2')";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT TOP 100 PERCENT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pu" +
				"b_pubseq, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pno, dbo.c2_pub.pub_pgno, dbo.c2" +
				"_pub.pub_bkcd, dbo.c2_pub.pub_clrcd, dbo.c2_clr.clr_nm, dbo.c2_pub.pub_ltpcd, db" +
				"o.c2_ltp.ltp_nm, dbo.c2_pub.pub_pgscd, dbo.c2_pgsize.pgs_nm, dbo.c2_pub.pub_fgfi" +
				"xpg, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_drafttp, dbo.c2_pub.pub_adamt, dbo.c2_" +
				"pub.pub_chgamt, dbo.invmfr.im_imseq, dbo.invmfr.im_nm, dbo.c2_pub.pub_imseq, dbo" +
				".c2_pub.pub_fgupdated, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_ltpcd, dbo.c2_pgsize" +
				".pgs_pgscd, dbo.invmfr.im_contno, dbo.invmfr.im_syscd, dbo.c2_pub.pub_fginved, d" +
				"bo.c2_pub.pub_fginvself, dbo.c2_pub.pub_fgact, dbo.c2_pub.pub_moddate, dbo.c2_pu" +
				"b.pub_origjbkno, dbo.c2_pub.pub_chgjbkno, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pu" +
				"b_origjno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_fgrechg" +
				", dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_costctr, dbo.fgit" +
				"ri.fgitri_fgitri, dbo.invmfr.im_fgitri, dbo.fgitri.fgitri_name FROM dbo.fgitri I" +
				"NNER JOIN dbo.invmfr ON dbo.fgitri.fgitri_fgitri = dbo.invmfr.im_fgitri COLLATE " +
				"Chinese_Taiwan_Stroke_BIN RIGHT OUTER JOIN dbo.c2_pub INNER JOIN dbo.c2_clr ON d" +
				"bo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_ltp ON dbo.c2_pub.p" +
				"ub_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd" +
				" = dbo.c2_pgsize.pgs_pgscd ON dbo.invmfr.im_imseq = dbo.c2_pub.pub_imseq AND dbo" +
				".invmfr.im_syscd = dbo.c2_pub.pub_syscd AND dbo.invmfr.im_contno = dbo.c2_pub.pu" +
				"b_contno ORDER BY dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yy" +
				"yymm, dbo.c2_pub.pub_pubseq";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
