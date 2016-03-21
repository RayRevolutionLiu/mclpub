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
	/// Summary description for InvMfrForm.
	/// </summary>
	public class InvMfrForm : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
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
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Label lblImSeq;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Label lblMfrInfo;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.Label lblHistoryMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.WebControls.Button btnLoadData;
		protected System.Web.UI.WebControls.Button btnClearAll;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlCommand sqlCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.TextBox tbxIMContNo;

		public InvMfrForm()
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

				// 抓預設資料 (廠商客戶資料) - 新增Form
				InitialData();

				// 判斷是否要 載入歷史資料
				// 若 fgnew=1 載入 歷史資料
				// 若 fgnew=0 為新合約, 並無初始資料, 故不需做 BindGrid1()
				if(Context.Request.QueryString["fgnew"].ToString().Trim() == "1")
				{
					BindGrid1();
				}
				else
				{
					// do nothing 不載入
					this.lblHistoryMessage.Text = "無初始資料, 請自行新增!<br>";
				}


				// 隱藏 儲存修改按鈕 & 修改時的發票廠商收件人之序號
				this.btnModify.Visible = false;
				this.btnSave.Visible = true;
				this.btnLoadData.Visible = true;
				this.lblImSeq.Visible = false;

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


		// 給預設資料 - 新增Form
		private void InitialData()
		{
			// 顯示下拉式選單 程式名稱的 DB 值
			DataSet ds7 = new DataSet();
			this.sqlDataAdapter7.Fill(ds7, "fgitri");
			ddlIMfgITRI.DataSource=ds7;
			ddlIMfgITRI.DataTextField="fgitri_name";
			ddlIMfgITRI.DataValueField="fgitri_fgitri";
			ddlIMfgITRI.DataBind();


			// 給下拉式選單 預選值
			this.ddlIMInvtp.ClearSelection();
			this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
			this.ddlIMTaxtp.ClearSelection();
			ddlIMTaxtp.SelectedIndex = 0;
			this.ddlIMfgITRI.ClearSelection();
			ddlIMfgITRI.SelectedIndex = 0;


			// 藉由前一網頁傳來的變數值字串
			string contno = "";
			string custno = "";

			// 載入預設資料 - 合約書編號
			if(Context.Request.QueryString["contno"].ToString().Trim() != "" || Context.Request.QueryString["contno"].ToString().Trim() != null)
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				//Response.Write("contno= " + contno + "<BR>");
			}

			// 載入預設資料 - 抓出廠商編號及客戶資料
			if(Context.Request.QueryString["custno"].ToString().Trim() != "" || Context.Request.QueryString["custno"].ToString().Trim() != null)
			{
				custno = Context.Request.QueryString["custno"].ToString().Trim();
				//Response.Write("custno= " + custno + "<BR>");


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
					string mfrno = "";
					custnm = dv2[0]["cust_nm"].ToString().Trim();
					custjbti = dv2[0]["cust_jbti"].ToString().Trim();
					custtel = dv2[0]["cust_tel"].ToString().Trim();
					custfax = dv2[0]["cust_fax"].ToString().Trim();
					custcell = dv2[0]["cust_cell"].ToString().Trim();
					custemail = dv2[0]["cust_email"].ToString().Trim();
					mfrno = dv2[0]["cust_mfrno"].ToString().Trim();
					//Response.Write("mfrno= " + mfrno + "<br>");

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


					// 顯示廠商相關資料
					if(mfrno != "")
					{
						// 顯示 廠商統編 (not visible)
						this.lblMfrNo.Text = mfrno;

						this.tbxIMMfrNo.Text = mfrno;
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
		}


		// 載入歷史資料
		private void BindGrid1()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr4 = "1=1";

			string old_contno = "";
			if(Context.Request.QueryString["old_contno"].ToString().Trim() != "")
			{
				old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + old_contno + "'";
			}
			else
			{
				old_contno = "0";
			}
			dv4.RowFilter = rowfilterstr4;
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

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
					string invcd =  DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
					switch (invcd)
					{
						case "2":
							DataGrid1.Items[i].Cells[11].Text = "二聯";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.OrangeRed;
							break;
						case "3":
							DataGrid1.Items[i].Cells[11].Text = "三聯";
							break;
						case "4":
							DataGrid1.Items[i].Cells[11].Text = "其他";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.Green;
							break;
						case "9":
							DataGrid1.Items[i].Cells[11].Text = "不清楚";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[11].Text = "三聯";
							break;
					}

					// 發票課稅別
					string taxtp = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					switch (taxtp)
					{
						case "1":
							DataGrid1.Items[i].Cells[12].Text = "應稅5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[12].Text = "零稅";
							DataGrid1.Items[i].Cells[12].ForeColor = Color.OrangeRed;
							break;
						case "3":
							DataGrid1.Items[i].Cells[12].Text = "免稅";
							DataGrid1.Items[i].Cells[12].ForeColor = Color.Green;
							break;
						case "9":
							DataGrid1.Items[i].Cells[12].Text = "不清楚";
							DataGrid1.Items[i].Cells[12].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[12].Text = "應稅5%";
							break;
					}

					// 院所內註記
					string fgItri = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
					switch (fgItri)
					{
						case "":
							DataGrid1.Items[i].Cells[13].Text = "否";
							break;
						case "06":
							DataGrid1.Items[i].Cells[13].Text = "所內";
							DataGrid1.Items[i].Cells[13].ForeColor = Color.OrangeRed;
							break;
						case "07":
							DataGrid1.Items[i].Cells[13].Text = "院內";
							DataGrid1.Items[i].Cells[13].ForeColor = Color.Blue;
							break;
						default:
							DataGrid1.Items[i].Cells[13].Text = "否";
							break;
					}

				}
			}

		}


		// 載入 已新增之資料
		private void BindGrid2()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr4 = "1=1";

			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + contno + "'";
			}
			dv4.RowFilter = rowfilterstr4;
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv4.Count > 0)
			{
				Datagrid2.DataSource=dv4;
				Datagrid2.DataBind();


				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< Datagrid2.Items.Count ; i++)
				{
					// 發票類別
					string invcd =  Datagrid2.Items[i].Cells[12].Text.ToString().Trim();
					switch (invcd)
					{
						case "2":
							Datagrid2.Items[i].Cells[12].Text = "二聯";
							Datagrid2.Items[i].Cells[12].ForeColor = Color.OrangeRed;
							break;
						case "3":
							Datagrid2.Items[i].Cells[12].Text = "三聯";
							break;
						case "4":
							Datagrid2.Items[i].Cells[12].Text = "其他";
							Datagrid2.Items[i].Cells[12].ForeColor = Color.Green;
							break;
						case "9":
							Datagrid2.Items[i].Cells[12].Text = "不清楚";
							Datagrid2.Items[i].Cells[12].ForeColor = Color.Red;
							break;
						default:
							Datagrid2.Items[i].Cells[12].Text = "三聯";
							break;
					}

					// 發票課稅別
					string taxtp = Datagrid2.Items[i].Cells[13].Text.ToString().Trim();
					switch (taxtp)
					{
						case "1":
							Datagrid2.Items[i].Cells[13].Text = "應稅5%";
							break;
						case "2":
							Datagrid2.Items[i].Cells[13].Text = "零稅";
							Datagrid2.Items[i].Cells[13].ForeColor = Color.OrangeRed;
							break;
						case "3":
							Datagrid2.Items[i].Cells[13].Text = "免稅";
							Datagrid2.Items[i].Cells[13].ForeColor = Color.Green;
							break;
						case "9":
							Datagrid2.Items[i].Cells[13].Text = "不清楚";
							Datagrid2.Items[i].Cells[13].ForeColor = Color.Red;
							break;
						default:
							Datagrid2.Items[i].Cells[13].Text = "應稅5%";
							break;
					}

					// 院所內註記
					string fgItri = Datagrid2.Items[i].Cells[14].Text.ToString().Trim();
					switch (fgItri)
					{
						case "":
							Datagrid2.Items[i].Cells[14].Text = "否";
							break;
						case "06":
							Datagrid2.Items[i].Cells[14].Text = "所內";
							Datagrid2.Items[i].Cells[14].ForeColor = Color.OrangeRed;
							break;
						case "07":
							Datagrid2.Items[i].Cells[14].Text = "院內";
							Datagrid2.Items[i].Cells[14].ForeColor = Color.Blue;
							break;
						default:
							Datagrid2.Items[i].Cells[14].Text = "否";
							break;
					}

				}
			}
			// 若全部刪除完時, 仍顯示殘存的最後一筆資料; 下段為清除此 bug
			else
			{
				Datagrid2.Visible = false;
			}

		}


		// 儲存新增 按鈕
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// 執行 新增動作 (先檢查收件人姓名是否有重覆輸入; 若否, 則新增之)
			//CheckDuplication();

			// 新增入資料庫
			InsertDB();


			// Refresh Datagrid2
			Datagrid2.Visible = true;
			Datagrid2.CurrentPageIndex=0;
			BindGrid2();
		}


		// 新增資料入 DB Table
		private void CheckDuplication()
		{
			// 抓出 畫面上的值
			string strSyscd = "C2";
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strIMName= " + strIMName + "<br>");


			// 檢查 收件人姓名 是否重覆輸入
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr4  = "1=1";
			rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strContNo + "'";
			rowfilterstr4 = rowfilterstr4 + " AND im_nm='" + strIMName + "'";
			dv4.RowFilter = rowfilterstr4;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			// 若收件人姓名重覆時
			if (dv4.Count > 0)
			{
				// 顯示初始資料
				InitialData();

				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl litCloseWin = new LiteralControl();
				litCloseWin.Text = "<script language=javascript>alert(\"此收件人姓名已存在, 下次新增時請多加注意!\");</script>";
				Page.Controls.Add(litCloseWin);

				// 執行新增
				InsertDB();
			}
			// 若不相同(為新資料), 則新增入資料庫中
			else
			{
				// 執行新增
				InsertDB();
			}
		}


		// 新增資料入 DB Table
		private void InsertDB()
		{
			// 抓出 畫面上的值
			string strSyscd = "C2";
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
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
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strMfrno= " + strMfrno + "<br>");
			//Response.Write("strIMinvcd= " + strIMinvcd + "<br>");


			// 檢查廠商統編: 若非一般編碼(十位數皆為數字), 則為個人戶, 則只允許其 "發票 類別" 為 "二聯"
			string strFirststrMfrno = strMfrno.Substring(0, 1);
			//Response.Write("strFirststrMfrno= " + strFirststrMfrno + "<br>");
			//Response.Write("Compare(strFirststrMfrno, 'A')= " + Compare(strFirststrMfrno, 'A') + "<br>");
			//Response.Write("strFirststrMfrno.CompareTo('A')= " + strFirststrMfrno.CompareTo('A') + "<br>");
			// Syntax of Compare class: Less than zero meaning strA is greater than strB
			//if(Compare(strFirststrMfrno, 'A') > 0)
//			if(strFirststrMfrno.ToUpper().CompareTo('A') > 0)
//			if(strFirststrMfrno != "0" || strFirststrMfrno != "1" || strFirststrMfrno != "2" || strFirststrMfrno != "3" || strFirststrMfrno != "4" || strFirststrMfrno != "5" || strFirststrMfrno != "6" || strFirststrMfrno != "7" || strFirststrMfrno != "8" || strFirststrMfrno != "9")
			if(strFirststrMfrno != "0" && strFirststrMfrno != "1" && strFirststrMfrno != "2" && strFirststrMfrno != "3" && strFirststrMfrno != "4" && strFirststrMfrno != "5" && strFirststrMfrno != "6" && strFirststrMfrno != "7" && strFirststrMfrno != "8" && strFirststrMfrno != "9")
			{
				if(strIMinvcd != "2")
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert = new LiteralControl();
					litAlert.Text = "<script language=javascript>alert(\"自動更新通知: 本筆為個人戶, 發票類別已更正為二聯\");</script>";
					Page.Controls.Add(litAlert);
				}

				// 做自動更正之動作
				strIMinvcd = "2";
				this.ddlIMInvtp.ClearSelection();
				this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 個人戶-二聯<br>");
			}
//			else
//			{
//				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 廠商-二聯或三聯<-br>");
//			}


			// 抓出新序號, 先抓出目前最大的 im_imseq+1
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "invmfr");
			DataView dv5 = ds5.Tables["invmfr"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strContNo + "'";
			dv5.RowFilter = rowfilterstr5;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

			// 抓出最新的 發票廠商收件人序號
			string strIMSeq = "01";
			if (dv5.Count > 0)
			{
				strIMSeq = Convert.ToString(Convert.ToInt32(dv5[0][0].ToString().Trim())+1);
				if(strIMSeq.Length < 2)
					strIMSeq = "0" + strIMSeq;
			}
			else
			{
				strIMSeq = "01";
			}
			//Response.Write("strIMSeq= " + strIMSeq + "<br>");

			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand1.Parameters["@contno"].Value = strContNo;
			this.sqlCommand1.Parameters["@imseq"].Value = strIMSeq;
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

				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"新增成功\");</script>";
				Page.Controls.Add(litAlert);

				// 以 Javascript 的 window.close() 來告知訊息
				//LiteralControl litCloseWin = new LiteralControl();
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				//Page.Controls.Add(litCloseWin);
			}
			else
			{
				//Response.Write("新增失敗!<br>");

				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"新增失敗\");</script>";
				Page.Controls.Add(litAlert);

				// 以 Javascript 的 window.close() 來告知訊息
				//LiteralControl litCloseWin = new LiteralControl();
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				//Page.Controls.Add(litCloseWin);
			}

			// 將畫面上殘餘資料清除為空
			ClearForm();
		}


		// DataGrid1 之 載入資料 按鈕 功能
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 按下 修改 按鈕的處理
			if(e.CommandName == "Select")
			{
				// 抓出 PK 值, 將相關資料載入 新增Form 裡
				string strsyscd = "C2";
				string strcontno = Context.Request.QueryString["old_contno"].ToString().Trim();
				string strimseq = e.Item.Cells[1].Text.ToString().Trim();
				//Response.Write("strsyscd= " + strsyscd + ", ");
				//Response.Write("strcontno= " + strcontno + ", ");
				//Response.Write("strimseq= " + strimseq + "<br>");


				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "invmfr");
				DataView dv4 = ds4.Tables["invmfr"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr4 = "1=1";
				rowfilterstr4 = rowfilterstr4 + " AND im_syscd='" + strsyscd + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strcontno + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_imseq='" + strimseq + "'";
				dv4.RowFilter = rowfilterstr4;

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
					// 下述 coding 無法抓出正確之 下拉式選單的預選值
					//this.ddlIMInvtp.ClearSelection();
					//this.ddlIMInvtp.SelectedItem.Value = dv4[0]["im_invcd"].ToString().Trim();
					//this.ddlIMTaxtp.ClearSelection();
					//this.ddlIMTaxtp.SelectedItem.Value = dv4[0]["im_taxtp"].ToString().Trim();
					//this.ddlIMfgITRI.ClearSelection();
					//this.ddlIMfgITRI.SelectedItem.Value = dv4[0]["im_fgitri"].ToString().Trim();
					
					// 發票類別代碼
					this.ddlIMInvtp.ClearSelection();
					string invcd = dv4[0]["im_invcd"].ToString().Trim();
					switch (invcd)
					{
						case "2":
							this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
							break;
						case "3":
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
						case "4":
							this.ddlIMInvtp.Items.FindByValue("4").Selected = true;
							break;
						case "9":
							this.ddlIMInvtp.Items.FindByValue("9").Selected = true;
							break;
						default:
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
					}

					// 發票課稅別
					this.ddlIMTaxtp.ClearSelection();
					string taxtp = dv4[0]["im_taxtp"].ToString().Trim();
					switch (taxtp)
					{
						case "1":
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
						case "2":
							this.ddlIMTaxtp.SelectedIndex = 1;
							break;
						case "3":
							this.ddlIMTaxtp.SelectedIndex = 2;
							break;
						case "9":
							this.ddlIMTaxtp.SelectedIndex = 3;
							break;
						default:
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
					}

					// 院所內註記
					this.ddlIMfgITRI.ClearSelection();
					string fgitri = dv4[0]["im_fgitri"].ToString().Trim();
					switch (fgitri)
					{
						case "":
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
						case "06":
							this.ddlIMfgITRI.SelectedIndex = 1;
							break;
						case "07":
							this.ddlIMfgITRI.SelectedIndex = 2;
							break;
						default:
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
					}
				}

				// 新增成功後, 將 儲存修改按鈕隱藏起來
				this.btnModify.Visible = false;
				this.btnSave.Visible = true;
			}
		}


		// Datagrid2 之 修改按鈕 功能
		private void Datagrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 按下 修改 按鈕的處理
			if(e.CommandName == "Select")
			{
				// 抓出 PK 值, 將相關資料載入 新增Form 裡
				string strSyscd = "C2";
				string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
				string strIMSeq = e.Item.Cells[2].Text.ToString().Trim();
				//Response.Write("strsyscd= " + strsyscd + ", ");
				//Response.Write("strcontno= " + strcontno + ", ");
				///Response.Write("strimseq= " + strimseq + "<br>");


				// 步驟一: 檢查此 IMSeq 是否有落版資料使用中, 若是, 不允許修改
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds6 = new DataSet();
				this.sqlDataAdapter6.Fill(ds6, "c2_pub");
				DataView dv6 = ds6.Tables["c2_pub"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr6 = "1=1";
				rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strSyscd + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strContNo + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_imseq='" + strIMSeq + "'";
				dv6.RowFilter = rowfilterstr6;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
				//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

				// 若已被落版使用, 給予警告訊息
				if (dv6.Count > 0)
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"請注意：本發票廠商已被落版使用, \\n請勿修改發廠收件人姓名, 造成舊資料有誤！(其他地址等資料可修改）\");</script>";
					Page.Controls.Add(litAlert1);
					this.tbxIMName.Enabled = false;
				}
				else
				{
					this.tbxIMName.Enabled = true;
				}

				// 步驟二: 進行修改動作
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "invmfr");
				DataView dv4 = ds4.Tables["invmfr"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr4 = "1=1";
				rowfilterstr4 = rowfilterstr4 + " AND im_syscd='" + strSyscd + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strContNo + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_imseq='" + strIMSeq + "'";
				dv4.RowFilter = rowfilterstr4;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
				//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

				// 載入資料
				if (dv4.Count > 0)
				{
					// 將序號顯示在 lblIMSeq; 否則修改時無法抓出其序號
					this.lblImSeq.Visible = true;
					this.lblImSeq.Text = strIMSeq;

					// 顯示其相關資料
					this.tbxIMContNo.Text = strContNo;
					this.tbxIMMfrNo.Text = dv4[0]["im_mfrno"].ToString().Trim();
					this.tbxIMName.Text = dv4[0]["im_nm"].ToString().Trim();
					this.tbxIMJobTitle.Text = dv4[0]["im_jbti"].ToString().Trim();
					this.tbxIMZipcode.Text = dv4[0]["im_zip"].ToString().Trim();
					this.tbxIMAddr.Text = dv4[0]["im_addr"].ToString().Trim();
					this.tbxIMTel.Text = dv4[0]["im_tel"].ToString().Trim();
					this.tbxIMFax.Text = dv4[0]["im_fax"].ToString().Trim();
					this.tbxIMCell.Text = dv4[0]["im_cell"].ToString().Trim();
					this.tbxIMEmail.Text = dv4[0]["im_email"].ToString().Trim();
					// 下述 coding 無法抓出正確之 下拉式選單的預選值
					//this.ddlIMInvtp.SelectedItem.Value = dv4[0]["im_invcd"].ToString().Trim();
					//this.ddlIMTaxtp.SelectedItem.Value = dv4[0]["im_taxtp"].ToString().Trim();
					//this.ddlIMfgITRI.SelectedItem.Value = dv4[0]["im_fgitri"].ToString().Trim();

					// 發票類別代碼
					this.ddlIMInvtp.ClearSelection();
					string invcd = dv4[0]["im_invcd"].ToString().Trim();
					switch (invcd)
					{
						case "2":
							this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
							break;
						case "3":
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
						case "4":
							this.ddlIMInvtp.Items.FindByValue("4").Selected = true;
							break;
						case "9":
							this.ddlIMInvtp.Items.FindByValue("9").Selected = true;
							break;
						default:
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
					}

					// 發票課稅別
					this.ddlIMTaxtp.ClearSelection();
					string taxtp = dv4[0]["im_taxtp"].ToString().Trim();
					switch (taxtp)
					{
						case "1":
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
						case "2":
							this.ddlIMTaxtp.SelectedIndex = 1;
							break;
						case "3":
							this.ddlIMTaxtp.SelectedIndex = 2;
							break;
						case "9":
							this.ddlIMTaxtp.SelectedIndex = 3;
							break;
						default:
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
					}

					// 院所內註記
					this.ddlIMfgITRI.ClearSelection();
					string fgitri = dv4[0]["im_fgitri"].ToString().Trim();
					switch (fgitri)
					{
						case "":
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
						case "06":
							this.ddlIMfgITRI.SelectedIndex = 1;
							break;
						case "07":
							this.ddlIMfgITRI.SelectedIndex = 2;
							break;
						default:
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
					}
				}

				// 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
				this.btnModify.Visible = true;
				this.btnSave.Visible = false;
				this.btnLoadData.Visible = false;

			// 結束 if(e.CommandName == "Select")
			}
		}


		// Datagrid2 刪除按鈕 功能
		private void Datagrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 按下 刪除 按鈕的處理
			if(e.CommandName == "Delete")
			{
				// 抓出 PK 值, 以稍後做 刪除動作
				string strSyscd = "C2";
				string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
				string strIMSeq = e.Item.Cells[2].Text.ToString().Trim();
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strIMSeq= " + strIMSeq + "<br>");


				// 步驟一: 檢查此 IMSeq 是否有落版資料使用中, 若是, 不允許修改
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds6 = new DataSet();
				this.sqlDataAdapter6.Fill(ds6, "c2_pub");
				DataView dv6 = ds6.Tables["c2_pub"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr6 = "1=1";
				rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strSyscd + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strContNo + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_imseq='" + strIMSeq + "'";
				dv6.RowFilter = rowfilterstr6;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
				//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

				// 若已被落版使用, 給予警告訊息
				if (dv6.Count > 0)
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"刪除失敗：本發票廠商已被落版使用, 無法刪除本筆\");</script>";
					Page.Controls.Add(litAlert1);
				}
				// 若尚未被落版使用, 允許刪除
				// 步驟二: 進行刪除動作
				else
				{
					// 步驟一：進行刪除動作
					// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 新增入資料庫
					this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand2.Parameters["@contno"].Value = strContNo;
					this.sqlCommand2.Parameters["@imseq"].Value = strIMSeq;

					// 確認執行 sqlCommand2 成功
					this.sqlCommand2.Connection.Open();
					// 使用 Transaction 確認有執行動作
					System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand2.Connection.BeginTransaction();
					this.sqlCommand2.Transaction = myTrans2;
					try
					{
						this.sqlCommand2.ExecuteNonQuery();
						myTrans2.Commit();

						// 以 Javascript 的 window.alert()  來告知訊息
						LiteralControl litAlert = new LiteralControl();
						litAlert.Text = "<script language=javascript>alert(\"刪除成功\");</script>";
						Page.Controls.Add(litAlert);
					}
					catch(System.Data.SqlClient.SqlException ex2)
					{
						Response.Write(ex2.Message + "<br>");
						myTrans2.Rollback();

						// 以 Javascript 的 window.alert()  來告知訊息
						LiteralControl litAlert = new LiteralControl();
						litAlert.Text = "<script language=javascript>alert(\"刪除失敗\");</script>";
						Page.Controls.Add(litAlert);
					}
					finally
					{
						this.sqlCommand2.Connection.Close();
					}


					// 步驟二: 抓出目前最大雜收人序號, 以判斷是否要做 or_oritem 之更新動作
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds5 = new DataSet();
					this.sqlDataAdapter5.Fill(ds5, "invmfr");
					DataView dv5 = ds5.Tables["invmfr"].DefaultView;

					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr5 = "1=1";
					rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strContNo + "'";
					dv5.RowFilter = rowfilterstr5;

					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
					//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

					// 抓出最新的 雜誌收件人序號
					string MaxIMSeq = "01";
					int intMaxIMSeq = Convert.ToInt16(MaxIMSeq);
					if (dv5.Count > 0)
					{
						MaxIMSeq = dv5[0]["MaxIMSeq"].ToString();
						//Response.Write("MaxIMSeq= " + MaxIMSeq + "<br>");
						intMaxIMSeq = Convert.ToInt16(MaxIMSeq);
						//Response.Write("intMaxIMSeq= " + intMaxIMSeq + "<br>");

						// 步驟三: 更新之後的序號之處理
						int intCurrentIMSeq = Convert.ToInt16(strIMSeq);
						if(strIMSeq == MaxIMSeq)
						{
							//Response.Write("do nothing...直接執行刪除資料即可<br>");
						}
						else
						{
							//Response.Write("處理更新事宜<br>");


							// 抓出 按下刪除之下一序號, 做為 for loop 起始值
							int intNextIMSeq = intCurrentIMSeq+1;
							//Response.Write("intNextIMSeq= " + intNextIMSeq + "<br>");

							// 抓出逐行落版資料, 做更新其落版序號之動作
							for(int i=intNextIMSeq; i<=intMaxIMSeq; i++)
							{
								string stri = Convert.ToString(i);
								if(stri.Length < 2)
									stri = "0" + stri;
								//Response.Write("stri= " + stri + "<br>");

								// 抓出逐行落版資料之 PK
								// 使用 DataSet 方法, 並指定使用的 table 名稱
								DataSet ds4 = new DataSet();
								// 給 sqlDataAdapter4 過濾條件 - 指定 Parameters
								this.sqlDataAdapter4.Fill(ds4, "c2_or");
								DataView dv4 = ds4.Tables["c2_or"].DefaultView;

								// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
								// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
								string rowfilterstr4 = "1=1";
								rowfilterstr4 = rowfilterstr4 + " AND  im_syscd='C2' ";
								rowfilterstr4 = rowfilterstr4 + " AND  im_contno='" + strContNo + "'";
								dv4.RowFilter = rowfilterstr4;

								// 檢查並輸出 最後 Row Filter 的結果
								//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
								//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

								if(dv4.Count > 0)
								{
									string iSyscd = "C2";
									string iContNo = dv4[0]["im_contno"].ToString();
									string iIMSeq = dv4[0]["im_imseq"].ToString();
									//Response.Write("iSyscd= " + iSyscd + ", ");
									//Response.Write("iContNo= " + iContNo + ", ");
									//Response.Write("iIMSeq= " + iIMSeq + "<br>");

									int intNewIMSeq = i-1;
									string strNewIMSeq = Convert.ToString(intNewIMSeq);
									if(strNewIMSeq.Length < 2)
										strNewIMSeq = "0" + strNewIMSeq;
									//Response.Write("strNewIMSeq= " + strNewIMSeq + "<br>");


									// 執行更新動作
									// 執行 將值塞入 sqlCommand4.Parameters 中, 以執行 新增入資料庫
									//Response.Write(this.sqlCommand4.CommandText);
									this.sqlCommand4.Parameters["@syscd"].Value = strSyscd;
									this.sqlCommand4.Parameters["@contno"].Value = strContNo;
									this.sqlCommand4.Parameters["@NewIMSeq"].Value = strNewIMSeq;
									this.sqlCommand4.Parameters["@imseq"].Value = stri;

									// 確認執行 sqlCommand4 成功
									this.sqlCommand4.Connection.Open();
									// 使用 Transaction 確認有執行動作
									System.Data.SqlClient.SqlTransaction myTrans4 = this.sqlCommand4.Connection.BeginTransaction();
									this.sqlCommand4.Transaction = myTrans4;
									try
									{
										this.sqlCommand4.ExecuteNonQuery();
										myTrans4.Commit();
									}
									catch(System.Data.SqlClient.SqlException ex4)
									{
										Response.Write(ex4.Message + "<br>");
										myTrans4.Rollback();
									}
									finally
									{
										this.sqlCommand4.Connection.Close();
									}
								}
							// 結束 for loop
							}
						// 結束 步驟三 else
						}
					}

					// Refresh Page
					Datagrid2.CurrentPageIndex=0;
					BindGrid2();

					// 將畫面上殘餘資料清除為空
					ClearForm();

					// 顯示 儲存修改按鈕; 隱藏 儲存新增按鈕
					this.btnModify.Visible = false;
					this.btnSave.Visible = true;
					this.btnLoadData.Visible = true;

					// 給預設資料 - 新增Form
					//Response.Write("Datagrid2.Items.Count= " + Datagrid2.Items.Count + "<br>");
					if(Datagrid2.Items.Count == 1)
					{
						InitialData();
					}
				}

			// 結束 if(e.CommandName == "Delete")
			}
		}


		// 儲存修改 按鈕
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			// 執行 修改動作
			ModifyDB();

			// Refresh Page
			Datagrid2.CurrentPageIndex=0;
			BindGrid2();

			// 修改成功後, 將 儲存修改按鈕隱藏起來
			this.btnModify.Visible = false;
			this.btnSave.Visible = true;
			this.btnLoadData.Visible = true;

			// 將畫面上殘餘資料清除為空
			ClearForm();
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
			string strimseq = this.lblImSeq.Text.ToString();
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
			//Response.Write("strIMinvcd= " + strIMinvcd + "<br>");
			//Response.Write("strIMtaxtp= " + strIMtaxtp + "<br>");
			//Response.Write("strIMfgitri= " + strIMfgitri + "<br>");


			// 本段 coding 同 InsertDB() 裡之同段
			// 檢查廠商統編: 若非一般編碼(十位數皆為數字), 則為個人戶, 則只允許其 "發票 類別" 為 "二聯"
			string strFirststrMfrno = strMfrno.Substring(0, 1);
			//Response.Write("strFirststrMfrno= " + strFirststrMfrno + "<br>");
//			if(strFirststrMfrno != "0" || strFirststrMfrno != "1" || strFirststrMfrno != "2" || strFirststrMfrno != "3" || strFirststrMfrno != "4" || strFirststrMfrno != "5" || strFirststrMfrno != "6" || strFirststrMfrno != "7" || strFirststrMfrno != "8" || strFirststrMfrno != "9")
			if(strFirststrMfrno != "0" && strFirststrMfrno != "1" && strFirststrMfrno != "2" && strFirststrMfrno != "3" && strFirststrMfrno != "4" && strFirststrMfrno != "5" && strFirststrMfrno != "6" && strFirststrMfrno != "7" && strFirststrMfrno != "8" && strFirststrMfrno != "9")
			{
				if(strIMinvcd != "2")
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert = new LiteralControl();
					litAlert.Text = "<script language=javascript>alert(\"自動更新通知: 本筆為個人戶, 發票類別已更正為二聯\");</script>";
					Page.Controls.Add(litAlert);
				}

				// 做自動更正之動作
				strIMinvcd = "2";
				this.ddlIMInvtp.ClearSelection();
				this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 個人戶-二聯<br>");
			}
//			else
//			{
//				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", 廠商-二聯或三聯<-br>");
//			}


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

			// 輸出執行結果
			if (ResultFlag3)
			{
				//Response.Write("修改成功!<br>");

				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"修改成功\");</script>";
				Page.Controls.Add(litAlert);
			}
			else
			{
				//Response.Write("修改失敗!<br>");

				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"修改失敗\");</script>";
				Page.Controls.Add(litAlert);
			}

		}


		// 將畫面上殘餘資料(按下 新增/修改/刪除後) 清除
		private void ClearForm()
		{
			// 將畫面上殘餘資料清除為空
			// 注意: 下拉式選單 要使用 SelectedIndex 的技巧
			this.lblImSeq.Text = "";
			//this.tbxIMContNo.Text = "";
			this.tbxIMMfrNo.Text = "";
			this.tbxIMName.Text = "";
			this.tbxIMJobTitle.Text = "";
			this.tbxIMZipcode.Text = "";
			this.tbxIMAddr.Text = "";
			this.tbxIMTel.Text = "";
			this.tbxIMFax.Text = "";
			this.tbxIMCell.Text = "";
			this.tbxIMEmail.Text = "";

			// 給下拉式選單 預選值 (同 InitialData() 裡同段落 )
			this.ddlIMInvtp.ClearSelection();
			this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
			this.ddlIMTaxtp.ClearSelection();
			ddlIMTaxtp.SelectedIndex = 0;
			this.ddlIMfgITRI.ClearSelection();
			ddlIMfgITRI.SelectedIndex = 0;
		}


		// 載入預設資料 - 廠商及客戶資料
		private void btnLoadData_Click(object sender, System.EventArgs e)
		{
			//
			InitialData();
		}


		// 清除畫面上的資料
		private void btnClearAll_Click(object sender, System.EventArgs e)
		{
			ClearForm();
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
			this.Datagrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_ItemCommand);
			this.Datagrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_DeleteCommand);
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
			this.sqlSelectCommand3.CommandText = "SELECT mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip FROM dbo.mfr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
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
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT cust_custno, cust_nm, cust_jbti, cust_tel, cust_fax, cust_cell, cust_email" +
				", cust_mfrno FROM dbo.cust";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
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
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT cont_contid, cont_syscd, cont_contno, cont_mfrno, cont_custno FROM dbo.c2_" +
				"cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter5
			//
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("MaxIMSeq", "MaxIMSeq"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno")})});
			//
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = "SELECT MAX(im_imseq) AS MaxIMSeq, im_contno FROM dbo.invmfr WHERE (im_syscd = \'C2" +
				"\') GROUP BY im_contno";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
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
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri"),
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd")})});
			//
			// sqlCommand3
			//
			this.sqlCommand3.CommandText = @"UPDATE invmfr SET im_mfrno = @mfrno, im_nm = @nm, im_jbti = @jbti, im_zip = @zip, im_addr = @addr, im_tel = @tel, im_fax = @fax, im_cell = @cell, im_email = @email, im_invcd = @invcd, im_taxtp = @taxtp, im_fgitri = @fgitri WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_imseq = @imseq)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mfrno", System.Data.SqlDbType.Char, 10, "im_mfrno"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, "im_nm"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, "im_jbti"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, "im_zip"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, "im_addr"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, "im_tel"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, "im_fax"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, "im_cell"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, "im_email"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@invcd", System.Data.SqlDbType.Char, 1, "im_invcd"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@taxtp", System.Data.SqlDbType.Char, 1, "im_taxtp"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgitri", System.Data.SqlDbType.Char, 2, "im_fgitri"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "im_syscd"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "im_contno"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, "im_imseq"));
			//
			// sqlCommand2
			//
			this.sqlCommand2.CommandText = "DELETE FROM invmfr WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_im" +
				"seq = @imseq)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "im_syscd"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "im_contno"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, "im_imseq"));
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = @"INSERT INTO invmfr (im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri) VALUES (@syscd, @contno, @imseq, @mfrno, @nm, @jbti, @zip, @addr, @tel, @fax, @cell, @email, @invcd, @taxtp, @fgitri)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "im_syscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "im_contno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, "im_imseq"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mfrno", System.Data.SqlDbType.Char, 10, "im_mfrno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, "im_nm"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, "im_jbti"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, "im_zip"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, "im_addr"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, "im_tel"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, "im_fax"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, "im_cell"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, "im_email"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@invcd", System.Data.SqlDbType.Char, 1, "im_invcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@taxtp", System.Data.SqlDbType.Char, 1, "im_taxtp"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgitri", System.Data.SqlDbType.Char, 2, "im_fgitri"));
			//
			// sqlDataAdapter6
			//
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq")})});
			//
			// sqlSelectCommand6
			//
			this.sqlSelectCommand6.CommandText = "SELECT dbo.invmfr.im_syscd, dbo.invmfr.im_contno, dbo.invmfr.im_imseq FROM dbo.in" +
				"vmfr INNER JOIN dbo.c2_pub ON dbo.invmfr.im_syscd = dbo.c2_pub.pub_syscd AND dbo" +
				".invmfr.im_contno = dbo.c2_pub.pub_contno AND dbo.invmfr.im_imseq = dbo.c2_pub.p" +
				"ub_imseq";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			//
			// sqlCommand4
			//
			this.sqlCommand4.CommandText = "UPDATE invmfr SET im_imseq = @NewIMSeq WHERE (im_syscd = @syscd) AND (im_contno =" +
				" @contno) AND (im_imseq = @imseq)";
			this.sqlCommand4.Connection = this.sqlConnection1;
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NewIMSeq", System.Data.SqlDbType.VarChar, 2, "im_imseq"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Original, null));
			//
			// sqlDataAdapter7
			//
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "proj", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("fgitri_fgitri", "fgitri_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("fgitri_name", "fgitri_name"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri")})});
			//
			// sqlSelectCommand7
			//
			this.sqlSelectCommand7.CommandText = "SELECT DISTINCT fgitri.fgitri_fgitri, fgitri.fgitri_name, dbo.proj.proj_fgitri FR" +
				"OM dbo.proj INNER JOIN fgitri ON dbo.proj.proj_fgitri COLLATE Chinese_Taiwan_Str" +
				"oke_BIN = fgitri.fgitri_fgitri WHERE (dbo.proj.proj_syscd = \'C2\')";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = "SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im" +
				"_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd FROM dbo.invmfr" +
				" WHERE (im_syscd = \'C2\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
