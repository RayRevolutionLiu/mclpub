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
	/// Summary description for iaFm2_Addia.
	/// </summary>
	public class iaFm2_Addia : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblBkcd;
		protected System.Web.UI.WebControls.DropDownList ddlBkcd;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Web.UI.WebControls.Label lblOrderByFilter;
		protected System.Web.UI.WebControls.DropDownList ddlOrderByFilter;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxIAStatus;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Web.UI.WebControls.Label lblIA;
		protected System.Web.UI.WebControls.Button btnCheckedAll;
		protected System.Web.UI.WebControls.Button btnCheckedClear;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnConfirmAmt;
		protected System.Web.UI.WebControls.Panel pnlPub;
		protected System.Web.UI.WebControls.Panel pnlQuery;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Button btnCreateIA;
		protected System.Web.UI.WebControls.Button btnPickReset;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.Label lblPickMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlCommand sqlCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter8;
		protected System.Data.SqlClient.SqlCommand sqlCommand6;
		protected System.Data.SqlClient.SqlCommand sqlCommand5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter9;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter10;
		protected System.Web.UI.WebControls.Panel pnlPubProjError;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblMemo2;
		protected System.Web.UI.WebControls.Label lblMemo3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand10;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidIAStatus;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				// 載入初始資料
				InitialData();
			}
		}


		// 載入初始資料
		private void InitialData()
		{
			this.lblMessage.Text  = "";


			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter2.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBkcd.DataSource=dv1;
			dv1.RowFilter="proj_fgitri=''";
			ddlBkcd.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			ddlBkcd.DataValueField="bk_bkcd";
			ddlBkcd.DataBind();
			this.ddlBkcd.SelectedIndex = 0;

			this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM");


			// 隱藏發票開立資料
			this.pnlPub.Visible = false;
			this.pnlPubProjError.Visible = false;
			this.btnPickReset.Visible = false;
			this.lblMemo2.Visible = false;
			this.lblMemo3.Visible = false;
			this.btnCreateIA.Visible = false;
			this.lblPickMessage.Text = "";


			// 抓取登入業務員資訊 - 工號及姓名
			GetLoginEmpInfo();
		}


		// 抓取登入業務員資訊 - 工號及姓名
		private void GetLoginEmpInfo()
		{
			// 抓出登入者的工號, 作為預設 製表業務員 之值
			string LoginEmpNo = "";
			string LoginEmpCName = "";
			//Response.Write("LoginEmpNo= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
			// 若有登入者的資料, 則抓出並預選 建檔業務員之下拉式選單
			if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) != "")
			{
				LoginEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);


				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds5 = new DataSet();
				this.sqlDataAdapter5.Fill(ds5, "srspn");
				DataView dv5 = ds5.Tables["srspn"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr5 = "1=1";
				rowfilterstr5 = rowfilterstr5 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv5.RowFilter = rowfilterstr5;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
				//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv5.Count > 0)
				{
					LoginEmpCName = dv5[0]["srspn_cname"].ToString().Trim();
				}
				else
				{
					LoginEmpCName = "(不詳)";
				}
			}
			this.tbxLoginEmpNo.Text = LoginEmpNo;
			this.tbxLoginEmpCName.Text = LoginEmpCName;
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
			//Response.Write("LoginEmpCName= " + LoginEmpCName + "<br>");
		}


		// 查詢 按鈕的處理
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			// 檢查落版檔的計劃代號是否合理 (與傳票檔 refd 做比較)
			// 若皆合理, 才允許繼續 發票開立單的產生及後續動作
			// 否則, 要求修改落版資料的計劃代號及成本中心資料至正確
			CheckPubProj();
		}


		// 清除重查 按鈕的處理
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			//InitialData();
			Response.Redirect("iaFm2_Addia.aspx");
		}


		// 檢查當月是否已做開立動作, 再判斷是否轉址
		private void CheckIAStatus()
		{
			// 抓出畫面上的值, 作為篩選資料的條件
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strBkName = this.ddlBkcd.SelectedItem.Text.ToString().Trim();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strBkName= " + strBkName + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_cont");
			DataView dv3 = ds3.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND (iab_iabdate = '" + strYYYYMM + "')";
			rowfilterstr3 = rowfilterstr3 + " AND (pub_bkcd = '" + strBkcd + "')";
			dv3.RowFilter = rowfilterstr3;


			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

			// 當月 "已" 做挑選或開立動作
			if(dv3.Count > 0)
			{
				this.tbxIAStatus.Text = "1";
				this.hidIAStatus.Value = "1";

				// 以下改以 Javascript 之 Client端 來判斷
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlertError = new LiteralControl();
				//litAlertError.Text = "<script language=javascript>confirm(\"該月已做發票開立單開立動作,\\n請問是否要直接預覽其檢核表資料!\");</script>";
				litAlertError.Text = "<script language=javascript>alert(\"" + strBkName + "當月已開立過發票開立單!\");</script>";
				Page.Controls.Add(litAlertError);
			}
				// 當月 "尚未" 做挑選或開立動作
			else
			{
				this.tbxIAStatus.Text = "0";
				this.hidIAStatus.Value = "0";
			}
			//Response.Write("this.hidIAStatus.Value= " + this.hidIAStatus.Value + "<br>");
		}


		// 顯示 DataGrid1
		private void BindGrid1()
		{
			// 抓出畫面上的值, 作為篩選資料的條件
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strBkName = this.ddlBkcd.SelectedItem.Text.ToString().Trim();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strBkName= " + strBkName + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_cont");
			DataView dv2 = ds2.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";
			rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm<='" + strYYYYMM + "'";
			// 下一行之備註: 因區隔材料所的上線資訊, 故舊落版資料小於等於 200209 的, 將不准再出現於 發票產生 流程中
			// 以免舊資訊重覆開立發票資料, 造成困擾.
			rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm>='200209'";
			dv2.RowFilter = rowfilterstr2;

			// Order By Filter
			if(this.ddlOrderByFilter.SelectedItem.Value == "1")
			{
				dv2.Sort = "cont_contno";
			}
			else if(this.ddlOrderByFilter.SelectedItem.Value == "2")
			{
				dv2.Sort = "cont_empno";
			}

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// 若搜尋結果為 "找到" 的處理
			if (dv2.Count > 0)
			{
				DataGrid1.DataSource = dv2;
				DataGrid1.DataBind();

				// 判斷當月是否已開立過 發票開立單, 並給予訊息告知
				if(this.tbxIAStatus.Text.ToString().Trim() == "0")
				{
					this.lblMessage.Text = "<font color='Red'>" + strBkName + " " + this.tbxYYYYMM.Text.ToString().Trim() + " 尚未開立過</font>發票開立單; ";
				}
				else
				{
					this.lblMessage.Text = "<font color='Red'>" + strBkName + " " + this.tbxYYYYMM.Text.ToString().Trim() + " 已開立過</font>發票開立單 (您可檢視檢核表來查詢). ";
				}
				this.lblMessage.Text = this.lblMessage.Text + "目前尚有 <font color='Red'>" + dv2.Count + "</font> 筆落版資料可供開立!";


				// 顯示相關按鈕
				this.btnPickReset.Visible = true;
				this.lblMemo2.Visible = true;
				this.btnCreateIA.Visible = true;


				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid1.Items.Count; i++)
				{
					// 合約類別
					string conttp = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
					//Response.Write("conttp= " + conttp + "<br>");
					if(conttp == "01")
						DataGrid1.Items[i].Cells[2].Text = "一般";
					else if(conttp == "09")
						DataGrid1.Items[i].Cells[2].Text = "<font color='Red'>推廣</font>";

					// 合約起日
					string StartDate = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid1.Items[i].Cells[3].Text = StartDate;

					// 合約迄日
					string EndDate = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					//Response.Write("EndDate= " + EndDate + "<br>");
					DataGrid1.Items[i].Cells[4].Text = EndDate;

					// 刊登年月 -- 針對不同月份, 整行給予不同顏色標示
					string yyyymm = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					if(yyyymm != strYYYYMM)
					{
						DataGrid1.Items[i].Cells[12].ForeColor = Color.DarkOrange;
						DataGrid1.Items[i].BackColor = Color.Lavender;
					}
					DataGrid1.Items[i].Cells[12].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);

					// 固定頁次註記
					string fgfixpg = DataGrid1.Items[i].Cells[20].Text.ToString().Trim();
					//Response.Write("fgfixpg= " + fgfixpg + "<br>");
					if(fgfixpg == "0")
						DataGrid1.Items[i].Cells[20].Text = "否";
					else
						DataGrid1.Items[i].Cells[20].Text = "是";

					// 稿件類別
					string drafttp = DataGrid1.Items[i].Cells[21].Text.ToString().Trim();
					//Response.Write("drafttp= " + drafttp + "<br>");
					switch(drafttp)
					{
						case "1":
							DataGrid1.Items[i].Cells[21].Text = "舊稿";

							// 清除其他不相關資料
							DataGrid1.Items[i].Cells[22].Text = "";
							DataGrid1.Items[i].Cells[23].Text = "";
							DataGrid1.Items[i].Cells[24].Text = "";
							break;
						case "2":
							DataGrid1.Items[i].Cells[21].Text = "新稿";

							// 到稿註記
							string fggot1 = DataGrid1.Items[i].Cells[23].Text.ToString().Trim();
							//Response.Write("fggot1= " + fggot1 + "<br>");
							if(fggot1 == "0")
								DataGrid1.Items[i].Cells[23].Text = "否";
							else
								DataGrid1.Items[i].Cells[23].Text = "是";

							// 清除其他不相關資料
							DataGrid1.Items[i].Cells[24].Text = "";
							DataGrid1.Items[i].Cells[25].Text = "";
							break;
						case "3":
							DataGrid1.Items[i].Cells[21].Text = "改稿";

							// 到稿註記
							string fggot2 = DataGrid1.Items[i].Cells[23].Text.ToString().Trim();
							//Response.Write("fggot2= " + fggot2 + "<br>");
							if(fggot2 == "0")
								DataGrid1.Items[i].Cells[23].Text = "否";
							else
								DataGrid1.Items[i].Cells[23].Text = "是";

							// 清除其他不相關資料
							DataGrid1.Items[i].Cells[22].Text = "";
							DataGrid1.Items[i].Cells[25].Text = "";
							break;
						default:
							DataGrid1.Items[i].Cells[21].Text = "舊稿";

							// 清除其他不相關資料
							DataGrid1.Items[i].Cells[22].Text = "";
							DataGrid1.Items[i].Cells[23].Text = "";
							DataGrid1.Items[i].Cells[24].Text = "";
							break;
					}
				}
				// 結束 if (dv2.Count > 0)
			}
			else
			{
				this.lblMessage.Text = "本月已無落版資料須開立！(或請重設搜尋條件)";
				this.pnlPub.Visible = false;
			}
		}


		// 全選 按鈕的處理
		private void btnCheckedAll_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				((CheckBox)this.DataGrid1.Items[i].FindControl("cbxChecked")).Checked = true;
			}
		}


		// 清選 按鈕的處理
		private void btnCheckedClear_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				((CheckBox)this.DataGrid1.Items[i].FindControl("cbxChecked")).Checked = false;
			}
		}


		// 挑畢, 確認挑選 按鈕的處理
		private void btnConfirmAmt_Click(object sender, System.EventArgs e)
		{
			// 將已挑選的落版資料 pub_fginved 值做註記 (由 ' ' 改為 't' (意指 temp)), 好由 DataGrid2 呼叫
			UpdatefgTemp();


			// 告知 被挑選之總筆數
			CountPick();


			// Refresh DataGrid1
			//DataGrid1.CurrentPageIndex=0;
			//BindGrid1();

			// 開啟新視窗 - 預覽 發票開立單 (列印清單) 的處理
			doPrintList();
		}


		// 將已挑選的落版資料 pub_fginved 值做註記 (由 ' ' 改為 't' (意指 temp)), 好由 DataGrid2 呼叫
		private void UpdatefgTemp()
		{
			// 抓出 DataGrid1 被挑選的資料
			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				// 檢查被挑選的狀態值
				bool strSelect = ((CheckBox)DataGrid1.Items[i].Cells[0].FindControl("cbxChecked")).Checked;
				//Response.Write("strSelect= " + strSelect + "<br>");

				// 抓出畫面上的值, 作為篩選資料的條件
				string strSyscd = "C2";
				string strContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();;
				string strYYYYMM = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
				strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
				string strPubSeq = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
				//Response.Write("strPubSeq= " + strPubSeq + "<br>");

				// 抓出被挑選的資料
				if(strSelect == true)
				{
					// 更新 '被挑選' 的落版資料之 pub_fginved 從 ' ' 變為 't'
					// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
					//Response.Write(this.sqlCommand1.CommandText);
					this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand1.Parameters["@contno"].Value = strContNo;
					this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
					this.sqlCommand1.Parameters["@pubseq"].Value = strPubSeq;

					// 確認執行 sqlCommand1 成功
					this.sqlCommand1.Connection.Open();
					// 使用 Transaction 確認有執行動作
					System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
					this.sqlCommand1.Transaction = myTrans1;
					try
					{
						this.sqlCommand1.ExecuteNonQuery();
						myTrans1.Commit();
						//Response.Write("落版資料更新成功");
					}
					catch(System.Data.SqlClient.SqlException ex1)
					{
						Response.Write(ex1.Message + "<br>");
						myTrans1.Rollback();
						//Response.Write("落版資料更新失敗");
					}
					finally
					{
						this.sqlCommand1.Connection.Close();
					}
					// 結束 if(strSelect == true)
				}
				else
				{
					// 更新 '沒有被挑選' 的落版資料之 pub_fginved 從 't' 變為 ' '
					// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 更新
					//Response.Write(this.sqlCommand2.CommandText);
					this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand2.Parameters["@contno"].Value = strContNo;
					this.sqlCommand2.Parameters["@yyyymm"].Value = strYYYYMM;
					this.sqlCommand2.Parameters["@pubseq"].Value = strPubSeq;

					// 確認執行 sqlCommand2 成功
					this.sqlCommand2.Connection.Open();
					// 使用 Transaction 確認有執行動作
					System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand2.Connection.BeginTransaction();
					this.sqlCommand2.Transaction = myTrans2;
					try
					{
						this.sqlCommand2.ExecuteNonQuery();
						myTrans2.Commit();
						//Response.Write("落版資料更新成功");
					}
					catch(System.Data.SqlClient.SqlException ex2)
					{
						Response.Write(ex2.Message + "<br>");
						myTrans2.Rollback();
						//Response.Write("落版資料更新失敗");
					}
					finally
					{
						this.sqlCommand2.Connection.Close();
					}
				}
				// 結束 for(int i=0; i < DataGrid1.Items.Count; i++)
			}
		}


		// 告知 被挑選之總筆數
		private void CountPick()
		{
			// 抓出畫面上的值, 作為篩選資料的條件
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "c2_cont");
			DataView dv4 = ds4.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr4 = "1=1";
			rowfilterstr4 = rowfilterstr4 + " AND cont_bkcd='" + strBkcd + "'";
			rowfilterstr4 = rowfilterstr4 + " AND pub_yyyymm<='" + strYYYYMM + "'";
			dv4.RowFilter = rowfilterstr4;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			// 若搜尋結果為 "找到" 的處理
			if (dv4.Count > 0)
			{
				this.lblPickMessage.Text = "您目前已挑選 " + dv4.Count + " 筆落版資料來開立!";
			}
			else
			{
				this.lblPickMessage.Text = "您目前沒有挑選落版資料來開立!";
			}
		}


		// 挑錯, 全部重挑 按鈕的處理
		private void btnPickReset_Click(object sender, System.EventArgs e)
		{
			// 抓出 DataGrid1 被挑選的落版資料
			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				// 抓出畫面上的值, 作為篩選資料的條件
				string strSyscd = "C2";
				string strContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();;
				string strYYYYMM = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
				strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
				string strPubSeq = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
				//Response.Write("strPubSeq= " + strPubSeq + "<br>");


				// 更新被挑選的落版資料之 pub_fginved 從 't' 變為 ' '
				// 執行 將值塞入 sqlCommand3.Parameters 中, 以執行 更新
				//Response.Write(this.sqlCommand3.CommandText);
				this.sqlCommand3.Parameters["@syscd"].Value = strSyscd;
				this.sqlCommand3.Parameters["@contno"].Value = strContNo;
				this.sqlCommand3.Parameters["@yyyymm"].Value = strYYYYMM;
				this.sqlCommand3.Parameters["@pubseq"].Value = strPubSeq;

				// 確認執行 sqlCommand3 成功
				this.sqlCommand3.Connection.Open();
				// 使用 Transaction 確認有執行動作
				System.Data.SqlClient.SqlTransaction myTrans3 = this.sqlCommand3.Connection.BeginTransaction();
				this.sqlCommand3.Transaction = myTrans3;
				try
				{
					this.sqlCommand3.ExecuteNonQuery();
					myTrans3.Commit();
					//Response.Write("落版資料回復成功, 請重新挑選");
					this.lblPickMessage.Text = "";
				}
				catch(System.Data.SqlClient.SqlException ex3)
				{
					Response.Write(ex3.Message + "<br>");
					myTrans3.Rollback();
					//Response.Write("落版資料回復失敗, 請重新挑選");
				}
				finally
				{
					this.sqlCommand3.Connection.Close();
				}
				// 結束 for(int i=0; i < DataGrid1.Items.Count; i++)
			}

			// 以 Javascript 的 window.alert()  來告知訊息
			LiteralControl litAlertError = new LiteralControl();
			litAlertError.Text = "<script language=javascript>alert(\"資料回復成功, 請重新挑選!\\n若要繼續預開, 請再按下 '清除重查' 按鈕!\");</script>";
			Page.Controls.Add(litAlertError);


			// Reset to initial status
			InitialData();
		}


		// 開啟新視窗 - 預覽 發票開立單 (列印清單) 的處理
		private void doPrintList()
		{
			// 抓出畫面上的值, 作為篩選資料的條件
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strSortFilter = this.ddlOrderByFilter.SelectedItem.Value.ToString().Trim();
			string strLEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strSortFilter= " + strSortFilter + "<br>");
			//Response.Write("strLEmpNo= " + strLEmpNo + "<br>");


			// 開啟小視窗
			string strbuf = "iaFm2_prelist2.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&sort=" + strSortFilter + "&LEmpNo=" + strLEmpNo;
			//Response.Write(strbuf);
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		// 產生 發票開立單 (檢視檢核表) 按鈕的處理
		private void btnCreateIA_Click(object sender, System.EventArgs e)
		{
			// 抓出畫面上的值, 作為 執行 sp 的 @值
			string strSyscd = "C2";
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strSortFilter = this.ddlOrderByFilter.SelectedItem.Value.ToString().Trim();
			string strIabDate = this.tbxYYYYMM.Text.ToString().Trim();
			strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
			string strLEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strSyscd= " + strSyscd + ", ");
			//Response.Write("strBkcd= " + strBkcd + ", ");
			//Response.Write("strSortFilter= " + strSortFilter + ", ");
			//Response.Write("strIabDate= " + strIabDate + ", ");
			//Response.Write("strLEmpNo= " + strLEmpNo + "<br>");


			// 步驟一: 抓出此筆資料的 iab_iabseq -- 先抓出資料庫的最大值, 再加一
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			this.sqlDataAdapter6.SelectCommand.Parameters["@date"].Value = strIabDate;
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "iab");
			DataView dv6 = ds6.Tables["iab"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr6 = "1=1";
			dv6.RowFilter = rowfilterstr6;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
			//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

			string strCurrentIabSeq;
			// 若搜尋結果為 "找到" 的處理
			if(int.Parse(dv6[0][0].ToString().Trim()) > 0)
			{
				// 抓出 新的合約書編號 = 目前資料庫中的Max合約書編號+1
				strCurrentIabSeq = Convert.ToString(Convert.ToInt32(dv6[0][1].ToString().Trim())+1);
				//Response.Write("strCurrentIabSeq= " + strCurrentIabSeq + "<br>");
			}
			else
			{
				strCurrentIabSeq = "000001";
			}
			// 做補零動作: strCurrentIabSeq 必須是六位數
			if(strCurrentIabSeq.Length == 1)
				strCurrentIabSeq = "00000" + strCurrentIabSeq;
			else if(strCurrentIabSeq.Length == 2)
				strCurrentIabSeq = "0000" + strCurrentIabSeq;
			else if(strCurrentIabSeq.Length == 3)
				strCurrentIabSeq = "000" + strCurrentIabSeq;
			else if(strCurrentIabSeq.Length == 4)
				strCurrentIabSeq = "00" + strCurrentIabSeq;
			else if(strCurrentIabSeq.Length == 5)
				strCurrentIabSeq = "0" + strCurrentIabSeq;
			else if(strCurrentIabSeq.Length == 6)
				strCurrentIabSeq = strCurrentIabSeq;
			//Response.Write("strCurrentIabSeq= " + strCurrentIabSeq + "<br>");


			// 新增 iab 資料 -- 單筆
			// 執行 將值塞入 sqlCommand6.Parameters 中, 以執行 更新
			//Response.Write(this.sqlCommand6.CommandText);
			string strIabCreDate = System.DateTime.Today.ToString("yyyyMMdd");
			this.sqlCommand6.Parameters["@iabdate"].Value = strIabDate;
			this.sqlCommand6.Parameters["@iabseq"].Value = strCurrentIabSeq;
			this.sqlCommand6.Parameters["@credate"].Value = strIabCreDate;
			this.sqlCommand6.Parameters["@creempno"].Value = strLEmpNo;
			//Response.Write("strIabDate= " + strIabDate + ", ");
			//Response.Write("strCurrentIabSeq= " + strCurrentIabSeq + ", ");
			//Response.Write("strIabCreDate= " + strIabCreDate + ", ");
			//Response.Write("strLEmpNo= " + strLEmpNo + "<br>");

			// 確認執行 sqlCommand6 成功
			this.sqlCommand6.Connection.Open();
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans6 = this.sqlCommand6.Connection.BeginTransaction();
			this.sqlCommand6.Transaction = myTrans6;
			try
			{
				this.sqlCommand6.ExecuteNonQuery();
				myTrans6.Commit();
				//Response.Write("新增 iab 資料成功<br>");
			}
			catch(System.Data.SqlClient.SqlException ex6)
			{
				Response.Write(ex6.Message + "<br>");
				myTrans6.Rollback();
				//Response.Write("新增 iab 資料失敗<br>");
			}
			finally
			{
				this.sqlCommand6.Connection.Close();
			}


			// 步驟二: 由 DataGrid1 抓出落版資料, 更新其 pub_fginved 由 't' 為 'v'
			if(DataGrid1.Items.Count > 0)
			{
				// 抓出每筆落版資料
				for(int i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 檢查被挑選的狀態值
					bool strSelect = ((CheckBox)DataGrid1.Items[i].Cells[0].FindControl("cbxChecked")).Checked;
					//Response.Write("strSelect= " + strSelect + "<br>");


					// 抓出 每一筆 '被挑選的' 落版資料, 並更新其 pub_fginved 由 't' 為 'v'
					string strContNo, strYYYYMM, strPubSeq, strIMSeq;
					// 抓出被挑選的資料
					if(strSelect == true)
					{
						strContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
						strYYYYMM = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
						strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
						strPubSeq = DataGrid1.Items[i].Cells[13].Text.ToString();
						strIMSeq = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
						//Response.Write("i= " + i + ", ");
						//Response.Write("strSyscd= " + strSyscd + ", ");
						//Response.Write("strContNo= " + strContNo + ", ");
						//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
						//Response.Write("strPubSeq= " + strPubSeq + "");
						//Response.Write("strIMSeq= " + strIMSeq + "<br>");

						// 更新 (被挑選) 的落版資料之 pub_fginved 從 't' 變為 'v'
						// 執行 將值塞入 sqlCommand4.Parameters 中, 以執行 更新
						//Response.Write(this.sqlCommand4.CommandText);
						this.sqlCommand4.Parameters["@syscd"].Value = strSyscd;
						this.sqlCommand4.Parameters["@contno"].Value = strContNo;
						this.sqlCommand4.Parameters["@yyyymm"].Value = strYYYYMM;
						this.sqlCommand4.Parameters["@pubseq"].Value = strPubSeq;

						// 確認執行 sqlCommand4 成功
						this.sqlCommand4.Connection.Open();
						// 使用 Transaction 確認有執行動作
						System.Data.SqlClient.SqlTransaction myTrans4 = this.sqlCommand4.Connection.BeginTransaction();
						this.sqlCommand4.Transaction = myTrans4;
						try
						{
							this.sqlCommand4.ExecuteNonQuery();
							myTrans4.Commit();
							//Response.Write("落版資料更新成功<br>");
						}
						catch(System.Data.SqlClient.SqlException ex4)
						{
							Response.Write(ex4.Message + "<br>");
							myTrans4.Rollback();
							//Response.Write("落版資料更新失敗<br>");
						}
						finally
						{
							this.sqlCommand4.Connection.Close();
						}
					}

					// 結束 for(int i=0; i< DataGrid1.Items.Count ; i++)
				}


				// 抓出被挑選之 contno & IMSeq, 以傳入 sp
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				this.sqlDataAdapter8.SelectCommand.Parameters["@bkcd"].Value = strBkcd;
				this.sqlDataAdapter8.SelectCommand.Parameters["@yyyymm"].Value = strIabDate;
				DataSet ds8 = new DataSet();
				this.sqlDataAdapter8.Fill(ds8, "c2_pub");
				DataView dv8 = ds8.Tables["c2_pub"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr8 = "1=1";
				dv8.RowFilter = rowfilterstr8;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
				//Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR>");

				string iSyscd = "C2", iContNo, iIMSeq, istrCurrentIabSeq, istrIabDate;
				if(dv8.Count > 0)
				{
					for(int j=0; j < dv8.Count; j++)
					{
						iContNo = dv8[j]["cont_contno"].ToString().Trim();
						iIMSeq = dv8[j]["pub_imseq"].ToString();
						istrCurrentIabSeq = strCurrentIabSeq;
						strIabDate = this.tbxYYYYMM.Text.ToString().Trim();
						strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
						istrIabDate = strIabDate;
						//istrLEmpNo = strLEmpNo;
						//Response.Write("iSyscd= " + iSyscd + ", ");
						//Response.Write("iContNo= " + iContNo + ", ");
						//Response.Write("iIMSeq= " + iIMSeq + ", ");
						//Response.Write("istrCurrentIabSeq= " + istrCurrentIabSeq + ", ");
						//Response.Write("istrIabDate= " + istrIabDate + "<br>");
						//Response.Write("istrLEmpNo= " + istrLEmpNo + "<br>");

						// 步驟二: 呼叫 sp
						// 執行 將值塞入 sqlCommand5.Parameters 中, 以執行 更新
						//Response.Write(this.sqlCommand5.CommandText);
						this.sqlCommand5.Parameters["@syscd"].Value = iSyscd;
						this.sqlCommand5.Parameters["@contno"].Value = iContNo;
						this.sqlCommand5.Parameters["@imseq"].Value = iIMSeq;
						this.sqlCommand5.Parameters["@iabdate"].Value = istrIabDate;
						this.sqlCommand5.Parameters["@iabseq"].Value = istrCurrentIabSeq;
						//this.sqlCommand5.Parameters["@lempno"].Value = istrLEmpNo;

						// 確認執行 sqlCommand5 成功
						this.sqlCommand5.Connection.Open();
						// 使用 Transaction 確認有執行動作
						System.Data.SqlClient.SqlTransaction myTrans5 = this.sqlCommand5.Connection.BeginTransaction();
						this.sqlCommand5.Transaction = myTrans5;
						try
						{
							this.sqlCommand5.ExecuteNonQuery();
							myTrans5.Commit();
							//Response.Write("執行 sp 成功<br><br>");
						}
						catch(System.Data.SqlClient.SqlException ex5)
						{
							Response.Write(ex5.Message + "<br>");
							myTrans5.Rollback();
							//Response.Write("執行 sp 失敗<br><br>");
						}
						finally
						{
							this.sqlCommand5.Connection.Close();
						}

					}
				}
				else
				{
					//Response.Write("dv8.Count <= 0<br>");
				}


				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"產生發票開立單成功!\\n請檢視發票開立單檢核表\");</script>";
				Page.Controls.Add(litAlert2);


				// 轉址 - 直接顯示 ia 檢核表
				string strbuf = "iaFm2_chklist_ia.aspx?bkcd=" + strBkcd + "&yyyymm=" + strIabDate + "&sort=" + strSortFilter + "&action=2&iabseq=" + strCurrentIabSeq;
				Response.Redirect(strbuf);

				// 結束 if(DataGrid1.Items.Count > 0)
			}
		}


		// 檢查落版檔的計劃代號是否合理 (與傳票檔 refd 做比較)
		private void CheckPubProj()
		{
			// 抓出畫面上的值, 作為篩選資料的條件
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds10 = new DataSet();
			this.sqlDataAdapter10.Fill(ds10, "c2_cont");
			DataView dv10 = ds10.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr10 = "1=1";
			rowfilterstr10 = rowfilterstr10 + " AND cont_bkcd='" + strBkcd + "'";
			rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm<='" + strYYYYMM + "'";
			// 下一行之備註: 因區隔材料所的上線資訊, 故舊落版資料小於等於 200209 的, 將不准再出現於 發票產生 流程中
			// 以免舊資訊重覆開立發票資料, 造成困擾.
			rowfilterstr10 = rowfilterstr10 + " AND pub_yyyymm>='200209'";
			dv10.RowFilter = rowfilterstr10;

			// Order By Filter
			if(this.ddlOrderByFilter.SelectedItem.Value == "1")
			{
				dv10.Sort = "cont_contno";
			}
			else if(this.ddlOrderByFilter.SelectedItem.Value == "2")
			{
				dv10.Sort = "cont_empno";
			}

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv10.Count= "+ dv10.Count + "<BR>");
			//Response.Write("dv10.RowFilter= " + dv10.RowFilter + "<BR>");

			// 若搜尋結果為 "找到" 的處理
			if (dv10.Count > 0)
			{
				// 顯示錯誤之落版資料
				this.pnlPub.Visible = false;
				this.pnlPubProjError.Visible = true;
				this.lblMemo3.Visible = true;

				DataGrid2.DataSource = dv10;
				DataGrid2.DataBind();

				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid2.Items.Count; i++)
				{
					// 合約類別
					string conttp = DataGrid2.Items[i].Cells[2].Text.ToString().Trim();
					//Response.Write("conttp= " + conttp + "<br>");
					if(conttp == "01")
						DataGrid2.Items[i].Cells[2].Text = "一般";
					else if(conttp == "09")
						DataGrid2.Items[i].Cells[2].Text = "<font color='Red'>推廣</font>";

					// 合約起日
					string StartDate = DataGrid2.Items[i].Cells[3].Text.ToString().Trim();
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid2.Items[i].Cells[3].Text = StartDate;

					// 合約迄日
					string EndDate = DataGrid2.Items[i].Cells[4].Text.ToString().Trim();
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					//Response.Write("EndDate= " + EndDate + "<br>");
					DataGrid2.Items[i].Cells[4].Text = EndDate;

					// 刊登年月 -- 針對不同月份, 整行給予不同顏色標示
					string yyyymm = DataGrid2.Items[i].Cells[12].Text.ToString().Trim();
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					if(yyyymm != strYYYYMM)
					{
						DataGrid2.Items[i].Cells[12].ForeColor = Color.DarkOrange;
						DataGrid2.Items[i].BackColor = Color.Lavender;
					}
					DataGrid2.Items[i].Cells[12].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);

					// 固定頁次註記
					string fgfixpg = DataGrid2.Items[i].Cells[20].Text.ToString().Trim();
					//Response.Write("fgfixpg= " + fgfixpg + "<br>");
					if(fgfixpg == "0")
						DataGrid2.Items[i].Cells[20].Text = "否";
					else
						DataGrid2.Items[i].Cells[20].Text = "是";

					// 稿件類別
					string drafttp = DataGrid2.Items[i].Cells[21].Text.ToString().Trim();
					//Response.Write("drafttp= " + drafttp + "<br>");
					switch(drafttp)
					{
						case "1":
							DataGrid2.Items[i].Cells[21].Text = "舊稿";

							// 清除其他不相關資料
							DataGrid2.Items[i].Cells[22].Text = "";
							DataGrid2.Items[i].Cells[23].Text = "";
							DataGrid2.Items[i].Cells[24].Text = "";
							break;
						case "2":
							DataGrid2.Items[i].Cells[21].Text = "新稿";

							// 到稿註記
							string fggot1 = DataGrid2.Items[i].Cells[23].Text.ToString().Trim();
							//Response.Write("fggot1= " + fggot1 + "<br>");
							if(fggot1 == "0")
								DataGrid2.Items[i].Cells[23].Text = "否";
							else
								DataGrid2.Items[i].Cells[23].Text = "是";

							// 清除其他不相關資料
							DataGrid2.Items[i].Cells[24].Text = "";
							DataGrid2.Items[i].Cells[25].Text = "";
							break;
						case "3":
							DataGrid2.Items[i].Cells[21].Text = "改稿";

							// 到稿註記
							string fggot2 = DataGrid2.Items[i].Cells[23].Text.ToString().Trim();
							//Response.Write("fggot2= " + fggot2 + "<br>");
							if(fggot2 == "0")
								DataGrid2.Items[i].Cells[23].Text = "否";
							else
								DataGrid2.Items[i].Cells[23].Text = "是";

							// 清除其他不相關資料
							DataGrid2.Items[i].Cells[22].Text = "";
							DataGrid2.Items[i].Cells[25].Text = "";
							break;
						default:
							DataGrid2.Items[i].Cells[21].Text = "舊稿";

							// 清除其他不相關資料
							DataGrid2.Items[i].Cells[22].Text = "";
							DataGrid2.Items[i].Cells[23].Text = "";
							DataGrid2.Items[i].Cells[24].Text = "";
							break;
					}
				}
			}
			else
			{
				// 顯示發票開立資料
				this.pnlPub.Visible = true;
				this.pnlPubProjError.Visible = false;


				// 檢查當月是否已做挑選或開立動作, 再判斷是否轉址
				CheckIAStatus();


				// 載入資料
				this.Literal1.Text = "";
				BindGrid1();
			}
		}


		// DataGrid2 維護落版資料 按鈕的處理
		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Literal1.Text = "";


			if(e.CommandName=="Select")
			{
				// 抓出 落版 PK, 以轉址到 修改落版 畫面
				string Syscd = "C2";
				string ContNo = e.Item.Cells[1].Text.ToString().Trim();
				string YYYYMM = e.Item.Cells[12].Text.ToString().Trim();
				YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
				string PubSeq = e.Item.Cells[13].Text.ToString().Trim();
				string strBkcd = e.Item.Cells[31].Text.ToString();
				//Response.Write("Syscd= " + Syscd + ", ");
				//Response.Write("ContNo= " + ContNo + ", ");
				//Response.Write("YYYYMM= " + YYYYMM + ", ");
				//Response.Write("PubSeq= " + PubSeq + ", ");
				//Response.Write("strBkcd= " + strBkcd + "<br>");

				// 轉址動作
				string strbuf = "PubFm.aspx?contno=" + ContNo + "&bkcd=" + strBkcd + "&fgnew=1";
				//Response.Write("strbuf= " + strbuf + "<br>");

				// 以 Javascript 的 window.close() 來告知訊息
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\",null,\"top=30,left=30,height=480,width=730,status=no,scrollbars=yes,toolbar=no,menubar=no,\");</script>";
			}
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter8 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter9 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter10 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnCheckedAll.Click += new System.EventHandler(this.btnCheckedAll_Click);
			this.btnCheckedClear.Click += new System.EventHandler(this.btnCheckedClear_Click);
			this.btnConfirmAmt.Click += new System.EventHandler(this.btnConfirmAmt_Click);
			this.btnPickReset.Click += new System.EventHandler(this.btnPickReset_Click);
			this.btnCreateIA.Click += new System.EventHandler(this.btnCreateIA_Click);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
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
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				 new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																				 new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, " +
				"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2" +
				"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con" +
				"t_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_totam" +
				"t, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_custno, " +
				"dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_fgcancel" +
				", dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.mfr.mfr_inm, dbo.cust.c" +
				"ust_nm, dbo.cust.cust_tel, dbo.srspn.srspn_cname, dbo.c2_pub.pub_syscd, dbo.c2_p" +
				"ub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_pgno" +
				", dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_ltp.l" +
				"tp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_pub.pub_fgfixpg, dbo.c2_p" +
				"ub.pub_drafttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_njtp.njtp_nm" +
				", dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2" +
				"_pub.pub_fgrechg, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pu" +
				"b_origjbkno, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_modempn" +
				"o, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_imseq, dbo.invmfr.im_nm, dbo.c2_pub.pub_r" +
				"emark, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_lt" +
				"pcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_custno, dbo" +
				".invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.mfr.mfr_mfrno, " +
				"dbo.srspn.srspn_empno, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginvself, dbo.c2_" +
				"pub.pub_projno, dbo.c2_pub.pub_costctr FROM dbo.c2_cont INNER JOIN dbo.mfr ON db" +
				"o.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont" +
				"_custno = dbo.cust.cust_custno INNER JOIN dbo.srspn ON dbo.c2_cont.cont_empno = " +
				"dbo.srspn.srspn_empno INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_p" +
				"ub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo." +
				"invmfr ON dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq AND dbo.c2_cont.cont_syscd " +
				"= dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_contno LEFT OU" +
				"TER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN " +
				"dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN d" +
				"bo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_" +
				"clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize" +
				" ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd WHERE (dbo.c2_cont.cont_fgpub" +
				"ed = \'1\') AND (dbo.c2_cont.cont_fgpayonce = \'0\') AND (dbo.c2_cont.cont_fgcancel " +
				"= \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') AND (dbo.c2_pub.pub_fginved = \' \' OR " +
				"dbo.c2_pub.pub_fginved = \'t\') AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt " +
				"> 0)";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "iab", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("iab_syscd", "iab_syscd"),
																																																			 new System.Data.Common.DataColumnMapping("iab_iabdate", "iab_iabdate"),
																																																			 new System.Data.Common.DataColumnMapping("iab_iabseq", "iab_iabseq"),
																																																			 new System.Data.Common.DataColumnMapping("iab_createdate", "iab_createdate"),
																																																			 new System.Data.Common.DataColumnMapping("iab_createmen", "iab_createmen"),
																																																			 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd")})});
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "UPDATE c2_pub SET pub_fginved = \'t\' WHERE (pub_syscd = @syscd) AND (pub_contno = " +
				"@contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			//
			// sqlCommand2
			//
			this.sqlCommand2.CommandText = "UPDATE c2_pub SET pub_fginved = \' \' WHERE (pub_syscd = @syscd) AND (pub_yyyymm = " +
				"@yyyymm) AND (pub_contno = @contno) AND (pub_pubseq = @pubseq)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			//
			// sqlCommand3
			//
			this.sqlCommand3.CommandText = "UPDATE c2_pub SET pub_fginved = \' \' WHERE (pub_syscd = @syscd) AND (pub_contno = " +
				"@contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq) AND (pub_fginved " +
				"= \'t\')";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				 new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself")})});
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = "SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, " +
				"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2" +
				"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con" +
				"t_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_totam" +
				"t, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_custno, " +
				"dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_fgcancel" +
				", dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.mfr.mfr_inm, dbo.cust.c" +
				"ust_nm, dbo.cust.cust_tel, dbo.srspn.srspn_cname, dbo.c2_pub.pub_syscd, dbo.c2_p" +
				"ub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_pgno" +
				", dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_ltp.l" +
				"tp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_pub.pub_fgfixpg, dbo.c2_p" +
				"ub.pub_drafttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_njtp.njtp_nm" +
				", dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2" +
				"_pub.pub_fgrechg, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pu" +
				"b_origjbkno, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_modempn" +
				"o, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_imseq, dbo.invmfr.im_nm, dbo.c2_pub.pub_r" +
				"emark, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_lt" +
				"pcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_custno, dbo" +
				".invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.mfr.mfr_mfrno, " +
				"dbo.srspn.srspn_empno, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginvself FROM dbo" +
				".c2_cont INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER " +
				"JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.s" +
				"rspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.c2_pub ON " +
				"dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo." +
				"c2_pub.pub_contno INNER JOIN dbo.invmfr ON dbo.c2_pub.pub_imseq = dbo.invmfr.im_" +
				"imseq AND dbo.c2_cont.cont_syscd = dbo.invmfr.im_syscd AND dbo.c2_cont.cont_cont" +
				"no = dbo.invmfr.im_contno LEFT OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = " +
				"dbo.book.bk_bkcd LEFT OUTER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_n" +
				"jtp.njtp_njtpcd LEFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp." +
				"ltp_ltpcd LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_cl" +
				"rcd LEFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pg" +
				"scd WHERE (dbo.c2_cont.cont_fgpubed = \'1\') AND (dbo.c2_cont.cont_fgpayonce = \'0\'" +
				") AND (dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') AND " +
				"(dbo.c2_pub.pub_fginved = \'t\') AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt" +
				" > 0)";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter5
			//
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'d\')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter6
			//
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("CountNo", "CountNo"),
																																																			   new System.Data.Common.DataColumnMapping("Maxiabseq", "Maxiabseq")})});
			//
			// sqlSelectCommand6
			//
			this.sqlSelectCommand6.CommandText = "SELECT COUNT(iab_iabid) AS CountNo, MAX(iab_iabseq) AS Maxiabseq FROM dbo.iab WHE" +
				"RE (iab_syscd = \'C2\') AND (iab_iabdate = @date)";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.VarChar, 6, "iab_iabdate"));
			//
			// sqlDataAdapter7
			//
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("TotAmt", "TotAmt")})});
			//
			// sqlSelectCommand7
			//
			this.sqlSelectCommand7.CommandText = @"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, SUM(dbo.c2_pub.pub_adamt) AS pub_adamt, SUM(dbo.c2_pub.pub_chgamt) AS pub_chgamt, SUM(dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt) AS TotAmt FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.invmfr ON dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq AND dbo.c2_cont.cont_syscd = dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_contno LEFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd WHERE (dbo.c2_cont.cont_fgpubed = '1') AND (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_pub.pub_fginved = 't') AND (dbo.c2_cont.cont_bkcd = @bkcd) AND (dbo.c2_pub.pub_yyyymm <= @yyyymm) AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0) GROUP BY dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			this.sqlSelectCommand7.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			this.sqlSelectCommand7.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			//
			// sqlCommand4
			//
			this.sqlCommand4.CommandText = "UPDATE c2_pub SET pub_fginved = \'v\' WHERE (pub_syscd = @syscd) AND (pub_contno = " +
				"@contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq) AND (pub_fginved " +
				"= \'t\')";
			this.sqlCommand4.Connection = this.sqlConnection1;
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			//
			// sqlDataAdapter8
			//
			this.sqlDataAdapter8.SelectCommand = this.sqlSelectCommand8;
			this.sqlDataAdapter8.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq")})});
			//
			// sqlSelectCommand8
			//
			this.sqlSelectCommand8.CommandText = @"SELECT DISTINCT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_pub.pub_imseq FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno WHERE (dbo.c2_cont.cont_fgpubed = '1') AND (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_pub.pub_fginved = 'v') AND (dbo.c2_cont.cont_bkcd = @bkcd) AND (dbo.c2_pub.pub_yyyymm <= @yyyymm) AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0)";
			this.sqlSelectCommand8.Connection = this.sqlConnection1;
			this.sqlSelectCommand8.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			this.sqlSelectCommand8.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			//
			// sqlCommand6
			//
			this.sqlCommand6.CommandText = "INSERT INTO iab (iab_syscd, iab_iabdate, iab_iabseq, iab_createdate, iab_createme" +
				"n) VALUES (\'C2\', @iabdate, @iabseq, @credate, @creempno)";
			this.sqlCommand6.Connection = this.sqlConnection1;
			this.sqlCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabdate", System.Data.SqlDbType.VarChar, 6, "iab_syscd"));
			this.sqlCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabseq", System.Data.SqlDbType.VarChar, 6, "iab_iabdate"));
			this.sqlCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@credate", System.Data.SqlDbType.VarChar, 8, "iab_iabseq"));
			this.sqlCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@creempno", System.Data.SqlDbType.VarChar, 8, "iab_createdate"));
			//
			// sqlCommand5
			//
			this.sqlCommand5.CommandText = "dbo.[sp_c2_add_ia]";
			this.sqlCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand5.Connection = this.sqlConnection1;
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabdate", System.Data.SqlDbType.VarChar, 6));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabseq", System.Data.SqlDbType.VarChar, 6));
			//
			// sqlDataAdapter9
			//
			this.sqlDataAdapter9.SelectCommand = this.sqlSelectCommand9;
			this.sqlDataAdapter9.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iabdate", "ia_iabdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iabseq", "ia_iabseq"),
																																																			new System.Data.Common.DataColumnMapping("iab_createdate", "iab_createdate"),
																																																			new System.Data.Common.DataColumnMapping("iab_createmen", "iab_createmen"),
																																																			new System.Data.Common.DataColumnMapping("iab_iabdate", "iab_iabdate"),
																																																			new System.Data.Common.DataColumnMapping("iab_iabseq", "iab_iabseq"),
																																																			new System.Data.Common.DataColumnMapping("iab_syscd", "iab_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano")})});
			//
			// sqlSelectCommand9
			//
			this.sqlSelectCommand9.CommandText = @"SELECT dbo.ia.ia_syscd, dbo.ia.ia_iabdate, dbo.ia.ia_iabseq, dbo.iab.iab_createdate, dbo.iab.iab_createmen, dbo.iab.iab_iabdate, dbo.iab.iab_iabseq, dbo.iab.iab_syscd, dbo.ia.ia_iano FROM dbo.ia INNER JOIN dbo.iab ON dbo.ia.ia_iabdate = dbo.iab.iab_iabdate AND dbo.ia.ia_iabseq = dbo.iab.iab_iabseq AND dbo.ia.ia_syscd = dbo.iab.iab_syscd WHERE (dbo.ia.ia_syscd = 'C2') ORDER BY dbo.ia.ia_iabdate, dbo.ia.ia_iabseq";
			this.sqlSelectCommand9.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter10
			//
			this.sqlDataAdapter10.SelectCommand = this.sqlSelectCommand10;
			this.sqlDataAdapter10.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																				 new System.Data.Common.DataColumnMapping("rd_projno", "rd_projno"),
																																																				 new System.Data.Common.DataColumnMapping("rd_costctr", "rd_costctr"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno")})});
			//
			// sqlSelectCommand10
			//
			this.sqlSelectCommand10.CommandText = @"SELECT DISTINCT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_costctr, dbo.refd.rd_projno, dbo.refd.rd_costctr, dbo.c2_pub.pub_imseq, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_empno FROM dbo.c2_pub INNER JOIN dbo.refd ON dbo.c2_pub.pub_syscd = dbo.refd.rd_syscd AND dbo.c2_pub.pub_projno <> dbo.refd.rd_projno AND dbo.c2_pub.pub_costctr <> dbo.refd.rd_costctr INNER JOIN dbo.invmfr ON dbo.c2_pub.pub_syscd = dbo.invmfr.im_syscd AND dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno WHERE (dbo.c2_cont.cont_fgpubed = '1') AND (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_pub.pub_fginved = ' ' OR dbo.c2_pub.pub_fginved = 't') AND (RTRIM(dbo.invmfr.im_fgitri) = '') AND (dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt > 0)";
			this.sqlSelectCommand10.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = @"SELECT DISTINCT dbo.iab.iab_syscd, dbo.iab.iab_iabdate, dbo.iab.iab_iabseq, dbo.iab.iab_createdate, dbo.iab.iab_createmen, dbo.c2_pub.pub_bkcd FROM dbo.iab INNER JOIN dbo.ia ON dbo.iab.iab_syscd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.ia.ia_syscd AND dbo.iab.iab_iabdate = dbo.ia.ia_iabdate AND dbo.iab.iab_iabseq = dbo.ia.ia_iabseq INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c2_pub ON dbo.iad.iad_syscd = dbo.c2_pub.pub_syscd AND dbo.iad.iad_fk1 = dbo.c2_pub.pub_contno AND dbo.iad.iad_fk2 = dbo.c2_pub.pub_yyyymm AND dbo.iad.iad_fk3 = dbo.c2_pub.pub_pubseq WHERE (dbo.iab.iab_syscd = 'C2')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
