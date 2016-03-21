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
	/// Summary description for adpub_actupdate.
	/// </summary>
	public class adpub_actupdate : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Literal litAlertWin;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;

		public adpub_actupdate()
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


				// 呼叫 BindGrid1()
				BindGrid1();
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 產生 DataGrid1
		private void BindGrid1()
		{
			//抓出網頁變數
			string Qstrbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
			string Qstryyyymm = Context.Request.QueryString["yyyymm"].ToString().Trim();

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr = "1=1";
			if(Qstrbkcd != "")
				rowfilterstr = rowfilterstr + " and (書籍類別代碼 = '" + Qstrbkcd + "')";
			else
				rowfilterstr = rowfilterstr;
			if(Qstryyyymm != "")
				rowfilterstr = rowfilterstr + " and (刊登年月 LIKE '%" + Qstryyyymm + "%')";
			else
				rowfilterstr = rowfilterstr;
			dv1.RowFilter = rowfilterstr;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若搜尋結果為 "找到" 的處理
			if (dv1.Count>0)
			{
				DataGrid1.Visible = true;

				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();


				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// 刊登年月
					string yyyymm = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
					yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
					DataGrid1.Items[i].Cells[2].Text = yyyymm;


					// 固定頁次註記
					string fgFixPg = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					if(fgFixPg=="1")
						DataGrid1.Items[i].Cells[8].Text = "<font color=Red>是</font>";
					else
						DataGrid1.Items[i].Cells[8].Text = "否";


					// 稿件類別代碼
					string drafttp = DataGrid1.Items[i].Cells[22].Text.ToString().Trim();
					//Response.Write("drafttp= " + drafttp + "<br>");
					switch (drafttp)
					{
						// 舊稿相關欄位
						case "1":
							string Origbkcd = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
							string Origjno = DataGrid1.Items[i].Cells[18].Text.ToString().Trim();
							string Origjbkno = DataGrid1.Items[i].Cells[19].Text.ToString().Trim();

							// 清除其他類別資料
							DataGrid1.Items[i].Cells[10].Text = "";
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							// 清除 已做樣後修改之值 0
							DataGrid1.Items[i].Cells[26].Text = "";
							break;

						// 新稿相關欄位
						case "2":
							// 到稿註記
							string fggot1 = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
							if(fggot1 == "0")
								fggot1 = "否";
							else
								fggot1 = "是";
							DataGrid1.Items[i].Cells[10].Text = fggot1;

							// 清除其他類別資料
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							DataGrid1.Items[i].Cells[17].Text = "";
							DataGrid1.Items[i].Cells[18].Text = "";
							DataGrid1.Items[i].Cells[19].Text = "";
							break;

						// 改稿相關欄位
						case "3":
							// 到稿註記
							string fggot2 = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
							if(fggot2 == "0")
								fggot2 = "否";
							else
								fggot2 = "是";
							DataGrid1.Items[i].Cells[10].Text = fggot2;

							// 改稿書籍類別
							string chgbkName;
							string chgbkcd = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
							if(chgbkcd == "01")
								DataGrid1.Items[i].Cells[13].Text = "工材雜誌";
							else if(chgbkcd == "02")
								DataGrid1.Items[i].Cells[13].Text = "電材雜誌";
							else
								DataGrid1.Items[i].Cells[13].Text = "（資料有誤)";

							// 改稿重出片註記
							string fgReChg = DataGrid1.Items[i].Cells[24].Text;
							//Response.Write("fgReChg= " + fgReChg + "<br>");
							if(fgReChg == "1")
								((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = true;
							else if(fgReChg == "0")
								((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = false;
							else
								((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = false;

							// 清除其他類別資料
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[17].Text = "";
							DataGrid1.Items[i].Cells[18].Text = "";
							DataGrid1.Items[i].Cells[19].Text = "";
							break;

						default:
							// 清除其他類別資料
							DataGrid1.Items[i].Cells[10].Text = "";
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							break;
					}


					// 結束 for(i=0; i< DataGrid1.Items.Count ; i++)
				}
			}
			else
			{
				DataGrid1.Visible = false;
			}
		}


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// 取消回首頁
			Response.Redirect("/mrlpub/");
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
		}


		// 按下 確認更新 按鈕的處理
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//Response.Write("DataGrid1.Items.Count= " + DataGrid1.Items.CountDataGrid1.Items.Count + "<br>");
			// 抓出各行 美編樣後修改註記 之值
			for(int i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 抓出 c2_pub 欲更新欄位值及 PK
				string iSyscd = "C2";
				string iContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
				string iYYYYMM = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				iYYYYMM = iYYYYMM.Substring(0, 4) + iYYYYMM.Substring(5, 2);
				string iPubSeq = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				string iDrafttp = DataGrid1.Items[i].Cells[22].Text.ToString().Trim();
				string injtpcd = ((TextBox)DataGrid1.Items[i].FindControl("tbxNjtpcd")).Text;
				string chgjbkno = ((TextBox)DataGrid1.Items[i].FindControl("tbxChgJBkNo")).Text;
				bool fgrechg = ((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = true;
				string ifgrechg;
				if(fgrechg = true)
					ifgrechg = "1";
				else
					ifgrechg = "0";
				string ifgupdated = ((TextBox)DataGrid1.Items[i].FindControl("tbxfgupdated")).Text;
				//Response.Write("isyscd= " + iSyscd + "," );
				//Response.Write("iContNo=" + iContNo + "," );
				//Response.Write("iYYYYMM=" + iYYYYMM + "," );
				//Response.Write("iPubSeq=" + iPubSeq + ", " );
				//Response.Write("iDrafttp=" + iDrafttp + ", ");
				//Response.Write("injtpcd=" + injtpcd + ", ");
				//Response.Write("chgjbkno=" + chgjbkno + ", ");
				//Response.Write("fgrechg=" + fgrechg + ", ");
				//Response.Write("ifgrechg=" + ifgrechg + ", ");
				//Response.Write("ifgupdated=" + ifgupdated + "<br>");


				// 若為新稿或改稿, 則執行 更新; 否則不做任何處理
				if(iDrafttp == "2" || iDrafttp == "3")
				{
					// 檢查 美編樣後修正 是否為數字型態且介於 0~9 間
					if(ifgupdated == "0" || ifgupdated == "1" || ifgupdated == "2" || ifgupdated == "3" || ifgupdated == "4" || ifgupdated == "5" || ifgupdated == "6" || ifgupdated == "7" || ifgupdated == "8" || ifgupdated == "9" )
					{
						// 新稿
						if(iDrafttp == "2")
						{
							chgjbkno = "0";
							ifgrechg = " ";
							injtpcd = injtpcd;

							// 檢查 新稿製法是否合理
							if(injtpcd.Trim() != "")
							{
								// 使用 DataSet 方法, 並指定使用的 table 名稱
								DataSet ds2 = new DataSet();
								this.sqlDataAdapter2.Fill(ds2, "c2_njtp");
								DataView dv2 = ds2.Tables["c2_njtp"].DefaultView;

								// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
								// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
								string rowfilterstr2 = "1=1";
								rowfilterstr2 = rowfilterstr2 + " AND njtp_njtpcd = '" + injtpcd + "'";
								dv2.RowFilter = rowfilterstr2;

								// 檢查並輸出 最後 Row Filter 的結果
								//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
								//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

								// 若搜尋結果為 "找到" 的處理
								if (dv2.Count > 0)
								{
									chgjbkno = "0";
									ifgrechg = " ";
									injtpcd = injtpcd;

									// 指定 sqlCommand1 Parameters
									this.sqlCommand1.Parameters["@njtpcd"].Value = injtpcd;
									this.sqlCommand1.Parameters["@chgjbkno"].Value = chgjbkno;
									this.sqlCommand1.Parameters["@fgrechg"].Value = ifgrechg;
									this.sqlCommand1.Parameters["@fgupdated"].Value = ifgupdated;
									this.sqlCommand1.Parameters["@syscd"].Value = iSyscd;
									this.sqlCommand1.Parameters["@contno"].Value = iContNo;
									this.sqlCommand1.Parameters["@yyyymm"].Value = iYYYYMM;
									this.sqlCommand1.Parameters["@pubseq"].Value = iPubSeq;
									//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());

									// 確認執行 sqlCommand1 成功
									this.sqlCommand1.Connection.Open();
									//Response.Write(sqlCommand1.CommandText.ToString().Trim());
									// Transaction Starting ...
									System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
									this.sqlCommand1.Transaction = myTrans1;
									try
									{
										this.sqlCommand1.ExecuteNonQuery();
										myTrans1.Commit();
									}
									catch(System.Data.SqlClient.SqlException ex1)
									{
										Response.Write(ex1.Message + "<br>");
										myTrans1.Rollback();
									}
									finally
									{
										this.sqlCommand1.Connection.Close();
									}
								}
								else
								{
									// 以 Javascript 的 window.alert()  來告知訊息
									LiteralControl litAlert3 = new LiteralControl();
									litAlert3.Text = "<script language=javascript>alert(\" 合約編號-刊登年月-落版序號：" + iContNo + "-" + iYYYYMM + "-" + iPubSeq + " 的新稿製法代碼 " + injtpcd + " 不合理!\\n請修正(數字0~9), 否則該筆資料無法儲存!\");</script>";
									Page.Controls.Add(litAlert3);
								}
							}
						}


						// 改稿
						if(iDrafttp == "3")
						{
							chgjbkno = chgjbkno;
							ifgrechg = ifgrechg;
							injtpcd = "  ";

							// 指定 sqlCommand1 Parameters
							this.sqlCommand1.Parameters["@njtpcd"].Value = injtpcd;
							this.sqlCommand1.Parameters["@chgjbkno"].Value = chgjbkno;
							this.sqlCommand1.Parameters["@fgrechg"].Value = ifgrechg;
							this.sqlCommand1.Parameters["@fgupdated"].Value = ifgupdated;
							this.sqlCommand1.Parameters["@syscd"].Value = iSyscd;
							this.sqlCommand1.Parameters["@contno"].Value = iContNo;
							this.sqlCommand1.Parameters["@yyyymm"].Value = iYYYYMM;
							this.sqlCommand1.Parameters["@pubseq"].Value = iPubSeq;
							//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());

							// 確認執行 sqlCommand1 成功
							this.sqlCommand1.Connection.Open();
							//Response.Write(sqlCommand1.CommandText.ToString().Trim());
							// Transaction Starting ...
							System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand1.Connection.BeginTransaction();
							this.sqlCommand1.Transaction = myTrans2;
							try
							{
								this.sqlCommand1.ExecuteNonQuery();
								myTrans2.Commit();
							}
							catch(System.Data.SqlClient.SqlException ex1)
							{
								Response.Write(ex1.Message + "<br>");
								myTrans2.Rollback();
							}
							finally
							{
								this.sqlCommand1.Connection.Close();
							}
						}
					}
					// 檢查 美編樣後修正 是否為數字型態且介於 0~9 間 => 否, 給予警告
					else
					{
						// 以 Javascript 的 window.alert()  來告知訊息
						LiteralControl litAlert3 = new LiteralControl();
						litAlert3.Text = "<script language=javascript>alert(\" 合約編號-刊登年月-落版序號：" + iContNo + "-" + iYYYYMM + "-" + iPubSeq + " 的美編樣後修正 " + ifgupdated + " 不合理!\\n請修正, 否則該筆資料無法儲存!\");</script>";
						Page.Controls.Add(litAlert3);
					}
				// 結束 if(iDrafttp == "2" || iDrafttp == "3")
				}
			// 結束 for loop
			}


			// Refresh DataGrid1
			litAlertWin.Text = "<script language=javascript>alert(\"即將更新頁面資料!\");</script>";
			BindGrid1();
		}


		// for 新稿製法
		protected object GetVisiblity1(object drafttp)
		{
			//Response.Write("drafttp= " + drafttp.ToString() + "<br>");
			bool valReturn = false;
			if (drafttp.ToString() == "2")
			{
				valReturn = true;
			}
			return valReturn;
		}


		// 檢查 新稿類別代碼 是否輸入合理
		protected object CheckNjtpcd(object njtpcd)
		{
			//Response.Write("njtpcd= " + njtpcd.ToString() + "<br>");
			bool valReturn = false;

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_njtp");
			DataView dv2 = ds2.Tables["c2_njtp"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND njtp_njtpcd = '" + njtpcd + "'";
			dv2.RowFilter = rowfilterstr2;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// 若搜尋結果為 "找到" 的處理
			if (dv2.Count > 0)
			{
				valReturn = true;
				this.litAlertWin.Text = "";
			}
			else
			{
				valReturn = valReturn;

				// 以 Javascript 的 window.alert()  來告知訊息
				this.litAlertWin.Text = "<script language=javascript>alert(\" 剛輸入的新稿製法代碼" + njtpcd + "不存在(不合理), 請修正!!!\");</script>";
			}
			return valReturn;
		}


		// for 舊稿期別
		protected object GetVisiblity2(object drafttp)
		{
			//Response.Write("drafttp= " + drafttp.ToString() + "<br>");
			bool valReturn = false;
			if (drafttp.ToString() == "3")
			{
				valReturn = true;
			}
			return valReturn;
		}


		// for 改稿重出片
		protected object GetfgReChg(object fgrechg)
		{
			bool strReturn = false;
			if(fgrechg.ToString().Trim() == "1")
				strReturn = true;
			return strReturn;
		}


		// for 美編樣後修改註記
		protected object GetfgUpdated(object drafttp)
		{
			//Response.Write("drafttp= " + drafttp.ToString() + "<br>");
			bool valReturn = false;
			if (drafttp.ToString() == "2")
			{
				valReturn = true;
			}
			if (drafttp.ToString() == "3")
			{
				valReturn = true;
			}
			return valReturn;
		}


		protected object CheckfgUpdated(object fgupdated)
		{
			fgupdated = fgupdated.ToString().Trim();
			//Response.Write("fgupdated= " + fgupdated.ToString() + "<br>");
			bool valReturn = false;

			if(fgupdated == "0" || fgupdated == "1" || fgupdated == "2" || fgupdated == "3" || fgupdated == "4" || fgupdated == "5" || fgupdated == "6" || fgupdated == "7" || fgupdated == "8" || fgupdated == "9" )
			{
				valReturn = true;
			}
			else
			{
				valReturn = valReturn;

				// 以 Javascript 的 window.alert()  來告知訊息
				this.litAlertWin.Text = "<script language=javascript>alert(\" 剛輸入的美編樣後修正" + fgupdated + "必須輸入數字型態(0~9), 請修正!!!\");</script>";
			}
			return valReturn;
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
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT pub_syscd, pub_contno, pub_yyyymm, pub_pubseq, pub_njtpcd, pub_chgjbkno, p" +
				"ub_fgrechg, pub_fgupdated FROM dbo.c2_pub";
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_njtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT njtp_njtpcd, njtp_nm FROM dbo.c2_njtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																				new System.Data.Common.DataColumnMapping("頁次", "頁次"),
																																																				new System.Data.Common.DataColumnMapping("合約書編號", "合約書編號"),
																																																				new System.Data.Common.DataColumnMapping("落版序號", "落版序號"),
																																																				new System.Data.Common.DataColumnMapping("刊登年月", "刊登年月"),
																																																				new System.Data.Common.DataColumnMapping("刊登頁碼", "刊登頁碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告色彩代碼", "廣告色彩代碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告版面代碼", "廣告版面代碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告篇幅代碼", "廣告篇幅代碼"),
																																																				new System.Data.Common.DataColumnMapping("固定頁次註記", "固定頁次註記"),
																																																				new System.Data.Common.DataColumnMapping("到稿註記", "到稿註記"),
																																																				new System.Data.Common.DataColumnMapping("落版業務員工號", "落版業務員工號"),
																																																				new System.Data.Common.DataColumnMapping("備註", "備註"),
																																																				new System.Data.Common.DataColumnMapping("舊稿書籍代碼", "舊稿書籍代碼"),
																																																				new System.Data.Common.DataColumnMapping("舊稿期別", "舊稿期別"),
																																																				new System.Data.Common.DataColumnMapping("舊稿頁碼", "舊稿頁碼"),
																																																				new System.Data.Common.DataColumnMapping("改稿書籍代碼", "改稿書籍代碼"),
																																																				new System.Data.Common.DataColumnMapping("改稿期別", "改稿期別"),
																																																				new System.Data.Common.DataColumnMapping("改稿頁碼", "改稿頁碼"),
																																																				new System.Data.Common.DataColumnMapping("改稿重出片註記", "改稿重出片註記"),
																																																				new System.Data.Common.DataColumnMapping("新稿製法代碼", "新稿製法代碼"),
																																																				new System.Data.Common.DataColumnMapping("公司名稱", "公司名稱"),
																																																				new System.Data.Common.DataColumnMapping("版面2", "版面2"),
																																																				new System.Data.Common.DataColumnMapping("書籍類別代碼", "書籍類別代碼"),
																																																				new System.Data.Common.DataColumnMapping("廣告色彩", "廣告色彩"),
																																																				new System.Data.Common.DataColumnMapping("廣告版面", "廣告版面"),
																																																				new System.Data.Common.DataColumnMapping("廣告篇幅", "廣告篇幅"),
																																																				new System.Data.Common.DataColumnMapping("新稿製法", "新稿製法"),
																																																				new System.Data.Common.DataColumnMapping("舊稿書籍名稱", "舊稿書籍名稱"),
																																																				new System.Data.Common.DataColumnMapping("落版業務員姓名", "落版業務員姓名"),
																																																				new System.Data.Common.DataColumnMapping("稿件類別代碼", "稿件類別代碼"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("美編樣後修改註記", "美編樣後修改註記"),
																																																				new System.Data.Common.DataColumnMapping("廣告優先次序", "廣告優先次序"),
																																																				new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("njtp_nostr", "njtp_nostr")})});
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "UPDATE c2_pub SET pub_njtpcd = @njtpcd, pub_chgjbkno = @chgjbkno, pub_fgrechg = @" +
				"fgrechg, pub_fgupdated = @fgupdated WHERE (pub_syscd = @syscd) AND (pub_contno =" +
				" @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtpcd", System.Data.SqlDbType.Char, 2, "pub_njtpcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgjbkno", System.Data.SqlDbType.Int, 4, "pub_chgjbkno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgrechg", System.Data.SqlDbType.Char, 1, "pub_fgrechg"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgupdated", System.Data.SqlDbType.Char, 1, "pub_fgupdated"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "pub_syscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "pub_contno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, "pub_yyyymm"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.Char, 2, "pub_pubseq"));
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT TOP 100 PERCENT dbo.c2_pub.pub_pubid AS ID, 0 AS 頁次, RTRIM(dbo.c2_pub.pub_" +
				"contno) AS 合約書編號, RTRIM(dbo.c2_pub.pub_pubseq) AS 落版序號, RTRIM(dbo.c2_pub.pub_yyy" +
				"ymm) AS 刊登年月, dbo.c2_pub.pub_pgno AS 刊登頁碼, RTRIM(dbo.c2_pub.pub_clrcd) AS 廣告色彩代碼" +
				", RTRIM(dbo.c2_pub.pub_pgscd) AS 廣告版面代碼, RTRIM(dbo.c2_pub.pub_ltpcd) AS 廣告篇幅代碼, " +
				"RTRIM(dbo.c2_pub.pub_fgfixpg) AS 固定頁次註記, RTRIM(dbo.c2_pub.pub_fggot) AS 到稿註記, RT" +
				"RIM(dbo.c2_pub.pub_modempno) AS 落版業務員工號, RTRIM(dbo.c2_pub.pub_remark) AS 備註, RTR" +
				"IM(dbo.c2_pub.pub_origbkcd) AS 舊稿書籍代碼, RTRIM(dbo.c2_pub.pub_origjno) AS 舊稿期別, RT" +
				"RIM(dbo.c2_pub.pub_origjbkno) AS 舊稿頁碼, RTRIM(dbo.c2_pub.pub_chgbkcd) AS 改稿書籍代碼, " +
				"RTRIM(dbo.c2_pub.pub_chgjno) AS 改稿期別, RTRIM(dbo.c2_pub.pub_chgjbkno) AS 改稿頁碼, RT" +
				"RIM(dbo.c2_pub.pub_fgrechg) AS 改稿重出片註記, RTRIM(dbo.c2_pub.pub_njtpcd) AS 新稿製法代碼, " +
				"RTRIM(dbo.mfr.mfr_inm) AS 公司名稱, 8 AS 版面2, RTRIM(dbo.c2_pub.pub_bkcd) AS 書籍類別代碼, " +
				"RTRIM(dbo.c2_clr.clr_nm) AS 廣告色彩, RTRIM(dbo.c2_ltp.ltp_nm) AS 廣告版面, RTRIM(dbo.c2" +
				"_pgsize.pgs_nm) AS 廣告篇幅, RTRIM(dbo.c2_njtp.njtp_nm) AS 新稿製法, RTRIM(dbo.book.bk_n" +
				"m) AS 舊稿書籍名稱, RTRIM(dbo.srspn.srspn_cname) AS 落版業務員姓名, RTRIM(dbo.c2_pub.pub_draf" +
				"ttp) AS 稿件類別代碼, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_sys" +
				"cd, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_fgupdated AS 美編樣後修改註記, dbo.c2_lprior.l" +
				"p_priorseq AS 廣告優先次序, dbo.c2_lprior.lp_bkcd, dbo.c2_pub.pub_njtpcd + \' \' + dbo.c" +
				"2_njtp.njtp_nm AS njtp_nostr FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pu" +
				"b.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.co" +
				"nt_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER " +
				"JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2_lprior.lp_ltpcd AND dbo.c2_p" +
				"ub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pub.pub_pgscd = dbo.c2_lprior.l" +
				"p_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd LEFT OUTER JOIN dbo.c2_c" +
				"lr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize " +
				"ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.c2_ltp ON " +
				"dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_njtp ON dbo.c" +
				"2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON dbo.c2_pu" +
				"b.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN dbo.srspn ON dbo.c2_cont.cont_" +
				"empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgclosed = \'0\') AND (dbo.c" +
				"2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') AND (dbo.c2_cont" +
				".cont_fgpubed = \'1\') ORDER BY 廣告優先次序, 刊登頁碼, 合約書編號, 刊登年月 DESC, 落版序號";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion




	}
}
