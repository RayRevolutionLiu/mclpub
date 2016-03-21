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
	/// Summary description for iaFm1_chklist_query.
	/// </summary>
	public class iaFm1_chklist_query : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblIANo;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.TextBox tbxIMName;
		protected System.Web.UI.WebControls.Label lblIMName;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Web.UI.WebControls.Label lblMemo2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox tbxIMName2;
		protected System.Web.UI.WebControls.TextBox tbxIMSeq;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.TextBox tbxIANo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Panel pnlSearch;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				InitialData();
			}
		}


		// 網頁預設值
		private void InitialData()
		{
			this.pnlSearch.Visible = true;
			this.lblMemo1.Visible = true;
			this.lblMemo2.Visible = false;

			this.cbx1.Checked = true;
			this.cbx2.Checked = false;
			this.cbx3.Checked = false;

			this.lblMfrNo.Text = "";
			this.tbxMfrIName.Text = "";
			this.tbxIMName.Text = "";
			this.tbxIANo.Text = "";
			this.lblMessage.Text = "";

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
			//InitialData();
			Response.Redirect("iaFm1_chklist_query.aspx");
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


		// 確認挑選 按鈕的處理
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
				//Response.Write("strIMSeq= " + strIMSeq + ", ");
				//Response.Write("strIMName= " + strIMName + "<br>");

				// 寫入隱藏值
				this.tbxContNo.Text = strContNo;
				this.tbxIMSeq.Text = strIMSeq;
				this.tbxIMName2.Text = strIMName;


				// 繼續挑選發票開立單編號
				this.DataGrid1.Visible = false;
				BindGrid2();
			}
		}


		// 當直接查詢 發票開立單編號時, 並無合約編號及發廠序號, 故要先抓出, 再執行 BindGrid2()
		private void GetContIM()
		{
			string strIANo = "";
			if(this.tbxIANo.Text.ToString().Trim() != "")
				strIANo = this.tbxIANo.Text.ToString().Trim();


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "ia");
			DataView dv2 = ds2.Tables["ia"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND ia_iano='" + strIANo + "'";
			dv2.RowFilter = rowfilterstr2;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			if(dv2.Count > 0)
			{
				string strContNo = dv2[0]["ia_contno"].ToString().Trim();
				strContNo = strContNo.Substring(2, 6);
				this.tbxContNo.Text = strContNo;
				string strIMName = dv2[0]["ia_rnm"].ToString().Trim();
				//Response.Write("strContNo= " + strContNo + "<br>");
				//Response.Write("strIMName= " + strIMName + "<br>");

				string strIMSeq = "01";
				if(strIMName != "")
				{
					// 藉 strIMName 抓出其 strIMSeq
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds3 = new DataSet();
					this.sqlDataAdapter3.Fill(ds3, "invmfr");
					DataView dv3 = ds3.Tables["invmfr"].DefaultView;

					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr3 = "1=1";
					rowfilterstr3= rowfilterstr3 + " AND im_contno='" + strContNo + "'";
					rowfilterstr3= rowfilterstr3 + " AND im_nm='" + strIMName + "'";
					dv3.RowFilter = rowfilterstr3;

					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
					//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

					if(dv3.Count > 0)
					{
						strIMSeq = dv3[0]["im_imseq"].ToString().Trim();
						this.tbxIMSeq.Text = strIMSeq;
					}
				// 結束 if(strIMName != "")
				}
			// 結束 if(dv2.Count > 0)
			}
		}


		// 顯示資料 DataGrid2 - 繼續挑選發票開立單編號
		private void BindGrid2()
		{
			// 抓出篩選條件
			string strMfrNo = this.tbxMfrNo.Text.ToString().Trim();
			string strContNo = "";
			string strIMSeq = "";
			if(this.tbxContNo.Text.ToString().Trim() == "" && this.tbxIMSeq.Text.ToString().Trim() == "")
			{
				GetContIM();
			}
			strContNo = this.tbxContNo.Text.ToString().Trim();
			strIMSeq = this.tbxIMSeq.Text.ToString();
			string strIMName = this.tbxIMName2.Text.ToString().Trim();
			string strIANo = "";
			if(this.tbxIANo.Text.ToString().Trim() != "")
				strIANo = this.tbxIANo.Text.ToString().Trim();

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
				this.cbx1.Checked = false;
				this.cbx2.Checked = false;
				this.cbx3.Checked = true;
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


		// DataGrid1 換頁處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid1();
		}


		// DataGrid2 按鈕處理
		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 判斷是否可做 回復動作
			string strContNo = this.tbxContNo.Text.ToString().Trim();
			string strIMSeq = this.tbxIMSeq.Text.ToString().Trim();
			string strIANo = e.Item.Cells[1].Text.ToString();
			string strIAStatus = e.Item.Cells[13].Text.ToString();
			//Response.Write("strIAStatus= " + strIAStatus + "<br>");

			// 轉址
			string strbuf = "iaFm1_chklist.aspx?contno=" + strContNo + "&imseq=" + strIMSeq + "&iano=" + strIANo;
			Response.Redirect(strbuf);
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
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
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, " +
				"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2" +
				"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con" +
				"t_edate, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_custno, RTRIM(dbo.cust.cust" +
				"_nm) AS cust_nm, dbo.cust.cust_tel, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pa" +
				"idamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_oldcontno, dbo.c2_cont.cont_mo" +
				"ddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, dbo.c2_cont.cont_f" +
				"gcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgp" +
				"ubed, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.invmfr.im_imseq, RTRIM(dbo.invmfr.i" +
				"m_nm) AS im_nm, dbo.cust.cust_custno, dbo.invmfr.im_contno, dbo.invmfr.im_syscd," +
				" dbo.mfr.mfr_mfrno, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname)" +
				" AS srspn_cname, dbo.book.bk_bkcd, dbo.srspn.srspn_empno, dbo.c2_cont.cont_totjt" +
				"m, dbo.c2_cont.cont_tottm FROM dbo.c2_cont INNER JOIN dbo.invmfr ON dbo.c2_cont." +
				"cont_syscd = dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_con" +
				"tno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER " +
				"JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book O" +
				"N dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.srspn ON dbo.c2_cont.c" +
				"ont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgpayonce = \'1\') AND (" +
				"dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') AND (dbo.c2" +
				"_cont.cont_fgpubed = \'1\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_refno, dbo.ia.ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat, dbo.ia.ia_ivat, dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.ia.ia_raddr, dbo.ia.ia_rzip, dbo.ia.ia_rjbti, dbo.ia.ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, dbo.ia.ia_cname, dbo.ia.ia_tel, dbo.ia.ia_contno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm FROM dbo.ia INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_syscd = 'C2') AND (dbo.ia.ia_status = ' ')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, RTRIM(im_nm) AS im_nm FROM dbo.in" +
				"vmfr WHERE (im_syscd = \'C2\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
