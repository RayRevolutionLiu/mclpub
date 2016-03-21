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
	/// Summary description for ContFm_chk1.
	/// </summary>
	public class ContFm_chk1 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DropDownList ddlFilter;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnClearAll;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Literal Literal1;

		public ContFm_chk1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 按下 查詢 按鈕的處理
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";


			// 抓出篩選條件
			string strFilter = this.ddlFilter.SelectedItem.Value.ToString().Trim();

			// 依不同篩選條件, 做不同的資料條件篩選
			if(strFilter == "1")
			{
				BindGrid1();
			}
			if(strFilter == "2")
			{
				BindGrid2();
			}
		}


		// 顯示資料：彩套黑次數皆為０
		private void BindGrid1()
		{
			// 抓出篩選條件
			string strFilter = this.ddlFilter.SelectedItem.Value.ToString().Trim();


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			rowfilterstr1 = rowfilterstr1 + " AND (cont_clrtm = 0) AND (cont_getclrtm = 0) AND (cont_menotm = 0) " ;
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				DataGrid1.Visible = true;
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();

				this.lblMessage.Text = "您查詢的項目是：" + this.ddlFilter.SelectedItem.Text.ToString().Trim() + "；有 <font color='Red'>" + dv1.Count + "</font> 筆資料!";

				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 合約類別
					string strconttp = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
					//Response.Write("strconttp= " + strconttp + "<br>");
					if(strconttp == "01")
					{
						DataGrid1.Items[i].Cells[1].Text = "一般";
					}
					else if(strconttp == "09")
					{
						DataGrid1.Items[i].Cells[1].Text = "推廣";
					}

					// 合約起迄日
					string strSDate = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
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
								strSDate = strSDate;
						}
					}
					else
					{
						strSDate = strSDate;
					}
					//Response.Write("strSDate= " + strSDate + "<br>");
					DataGrid1.Items[i].Cells[3].Text = strSDate;
					
					string strEDate = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
					//strEDate = strEDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
					if(strEDate != "")
					{
						if(strEDate.Length >= 6)
							strEDate = strSDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
						else
						{
							// 分離 \ 符號以取得數字
							if(strEDate.IndexOf("\\") != -1)
							{
								//strEDate = strEDate.Split('/', 2);
							}
							else
								strEDate = strEDate;
						}
					}
					else
					{
						strEDate = strEDate;
					}
					//Response.Write("strEDate= " + strEDate + "<br>");
					DataGrid1.Items[i].Cells[4].Text = strEDate;

					// 簽約日期
					string strSignDate = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
					//strSignDate = strSignDate.Substring(0, 4) + "/" + strSignDate.Substring(4, 2) + "/" + strSignDate.Substring(6, 2);
					if(strSignDate != "")
					{
						if(strSignDate.Length >= 6)
							strSignDate = strSignDate.Substring(0, 4) + "/" + strSignDate.Substring(4, 2) + "/" + strSignDate.Substring(6, 2);
						else
						{
							// 分離 \ 符號以取得數字
							if(strSignDate.IndexOf("\\") != -1)
							{
								//strSignDate = strSignDate.Split('/', 2);
							}
							else
								strSignDate = strSignDate;
						}
					}
					else
					{
						strSignDate = strSignDate;
					}
					//Response.Write("strEDate= " + strEDate + "<br>");
					DataGrid1.Items[i].Cells[5].Text = strSignDate;


					// 一次付款
					string strpayonce = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					//Response.Write("strpayonce= " + strpayonce + "<br>");
					if(strpayonce == "0")
					{
						DataGrid1.Items[i].Cells[9].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[9].Text = "<font color=red>是</font>";
					}

					// 已結案
					string strfgclosed = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
					//Response.Write("strfgclosed= " + strfgclosed + "<br>");
					if(strfgclosed == "0")
					{
						DataGrid1.Items[i].Cells[10].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[10].Text = "<font color=red>是</font>";
					}

					// 已落版
					string strPubed = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
					//Response.Write("strPubed= " + strPubed + "<br>");
					if(strPubed == "0")
					{
						DataGrid1.Items[i].Cells[15].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[15].Text = "<font color=red>是</font>";
					}

					// 已註銷
					string strfgCancel = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
					//Response.Write("strfgCancel= " + strfgCancel + "<br>");
					if(strfgCancel == "0")
					{
						DataGrid1.Items[i].Cells[16].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[16].Text = "<font color=red>是</font>";
					}
				}
			}
			else
			{
				DataGrid1.Visible = false;
				this.lblMessage.Text = "查無資料!";
			}
		}


		// 清除重查 按鈕的處理
		private void btnClearAll_Click(object sender, System.EventArgs e)
		{
			//this.ddlFilter.SelectedIndex = 0;
			//this.lblMessage.Text = "";
			//DataGrid1.Visible = false;
			Response.Redirect("ContFm_chk1.aspx");
		}


		// 換頁處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid1();
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[1].Text);

			if(e.CommandName=="Show")
			{
				// 開啟小視窗
				string strbuf = "ContPubFm_show.aspx?custno=" + DataGrid1.SelectedItem.Cells[18].Text.Trim() + "&old_contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim();
				//Response.Write(strbuf);
				this.Literal1.Text="<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
			}
			else if(e.CommandName=="Modify")
			{
				// 開啟小視窗
				string strbuf = "ContFm_modify.aspx?custno=" + DataGrid1.SelectedItem.Cells[18].Text.Trim() + "&contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim();
				//Response.Write(strbuf);
				this.Literal1.Text="<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
			}
		}


		// 顯示資料：承辦業務員資料不對應
		private void BindGrid2()
		{
			// 抓出篩選條件
			string strFilter = this.ddlFilter.SelectedItem.Value.ToString().Trim();


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_cont");
			DataView dv2 = ds2.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND (cont_fgtemp = '0') " ;
			rowfilterstr2 = rowfilterstr2 + " AND (cont_fgcancel = '0') " ;
			rowfilterstr2 = rowfilterstr2 + " AND (cont_fgpubed = '1') " ;
			dv2.RowFilter = rowfilterstr2;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv2.Count > 0)
			{
				DataGrid1.Visible = true;
				DataGrid1.DataSource=dv2;
				DataGrid1.DataBind();

				this.lblMessage.Text = "您查詢的項目是：" + this.ddlFilter.SelectedItem.Text.ToString().Trim() + "；有 <font color='Red'>" + dv2.Count + "</font> 筆資料!";

				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 合約類別
					string strconttp = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
					//Response.Write("strconttp= " + strconttp + "<br>");
					if(strconttp == "01")
					{
						DataGrid1.Items[i].Cells[1].Text = "一般";
					}
					else if(strconttp == "09")
					{
						DataGrid1.Items[i].Cells[1].Text = "推廣";
					}

					// 合約起迄日
					string strSDate = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
					strSDate = strSDate.Substring(0, 4) + "/" + strSDate.Substring(4, 2);
					DataGrid1.Items[i].Cells[3].Text = strSDate;
					string strEDate = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
					strEDate = strEDate.Substring(0, 4) + "/" + strEDate.Substring(4, 2);
					DataGrid1.Items[i].Cells[4].Text = strEDate;
					//Response.Write("strSDate= " + strSDate + "<br>");
					//Response.Write("strEDate= " + strEDate + "<br>");

					// 簽約日期
					string strSignDate = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
					strSignDate = strSignDate.Substring(0, 4) + "/" + strSignDate.Substring(4, 2) + "/" + strSignDate.Substring(6, 2);
					DataGrid1.Items[i].Cells[5].Text = strSignDate;
					//Response.Write("strEDate= " + strEDate + "<br>");


					// 一次付款
					string strpayonce = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					//Response.Write("strpayonce= " + strpayonce + "<br>");
					if(strpayonce == "0")
					{
						DataGrid1.Items[i].Cells[9].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[9].Text = "<font color=red>是</font>";
					}

					// 已結案
					string strfgclosed = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
					//Response.Write("strfgclosed= " + strfgclosed + "<br>");
					if(strfgclosed == "0")
					{
						DataGrid1.Items[i].Cells[10].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[10].Text = "<font color=red>是</font>";
					}

					// 已落版
					string strPubed = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
					//Response.Write("strPubed= " + strPubed + "<br>");
					if(strPubed == "0")
					{
						DataGrid1.Items[i].Cells[15].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[15].Text = "<font color=red>是</font>";
					}

					// 已註銷
					string strfgCancel = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
					//Response.Write("strfgCancel= " + strfgCancel + "<br>");
					if(strfgCancel == "0")
					{
						DataGrid1.Items[i].Cells[16].Text = "否";
					}
					else
					{
						DataGrid1.Items[i].Cells[16].Text = "<font color=red>是</font>";
					}
				}
			}
			else
			{
				DataGrid1.Visible = false;
				this.lblMessage.Text = "查無資料!";
			}
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
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
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
																																																				 new System.Data.Common.DataColumnMapping("cont_njtpcnt", "cont_njtpcnt"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname")})});
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, dbo.c2_cont.cont_bkcd, RTRIM(dbo.c2_pub.pub_modempno) AS pub_modempno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_conttp, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.c2_cont.cont_signdate, RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.c2_cont.cont_custno) AS cont_custno, RTRIM(dbo.cust.cust_nm) AS cust_nm, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_disc, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_oldcontno, dbo.srspn.srspn_cname, dbo.srspn.srspn_empno FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno AND dbo.c2_cont.cont_empno <> dbo.c2_pub.pub_modempno INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c2_cont.cont_contid, dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, " +
				"dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c" +
				"2_cont.cont_empno, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.co" +
				"nt_autel, dbo.c2_cont.cont_aufax, dbo.c2_cont.cont_aucell, dbo.c2_cont.cont_auem" +
				"ail, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_totjtm, db" +
				"o.c2_cont.cont_madejtm, dbo.c2_cont.cont_restjtm, dbo.c2_cont.cont_disc, dbo.c2_" +
				"cont.cont_freetm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_tottm, dbo.c2_cont" +
				".cont_pubtm, dbo.c2_cont.cont_resttm, dbo.c2_cont.cont_chgjtm, dbo.c2_cont.cont_" +
				"custno, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pubamt, dbo.c2_cont.cont_chgam" +
				"t, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_clrtm, d" +
				"bo.c2_cont.cont_menotm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_oldcontno, d" +
				"bo.c2_cont.cont_moddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, " +
				"dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_adamt, dbo" +
				".c2_cont.cont_freebkcnt, dbo.c2_cont.cont_remark, dbo.c2_cont.cont_fgtemp, dbo.c" +
				"2_cont.cont_fgpubed, dbo.c2_cont.cont_restclrtm, dbo.c2_cont.cont_restmenotm, db" +
				"o.c2_cont.cont_restgetclrtm, dbo.c2_cont.cont_njtpcnt, RTRIM(dbo.book.bk_nm) AS " +
				"bk_nm, dbo.book.bk_bkcd, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.mfr.mfr_mf" +
				"rno) AS mfr_mfrno, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname FROM dbo.c2_cont " +
				"INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.m" +
				"fr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.srspn ON dbo.c2_" +
				"cont.cont_empno = dbo.srspn.srspn_empno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
