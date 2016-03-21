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
// SqlConnection
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adlprior.
	/// </summary>
	public class adlprior : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

		public adlprior()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 指定 ddlQueryField 的預設選項
				this.ddlQueryField.SelectedIndex = 00;
				BindGrid();
			}

		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		public void BindGrid()
		{
//			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料
//			//string DSN = "Data Source=isccom2;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
//			//SqlConnection myConnection = new SqlConnection(DSN);
//			string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
//			//string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
//			SqlConnection myConnection = new SqlConnection(strConn);
//
//			string SQL = " SELECT         dbo.c2_lprior.lp_lpid, dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, ";
//			SQL = SQL + " dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, ";
//			SQL = SQL + " dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd, ";
//			SQL = SQL + " COUNT(dbo.c2_pub.pub_contno) AS PubCounts ";
//			SQL = SQL + " FROM             dbo.c2_lprior INNER JOIN ";
//			SQL = SQL + " dbo.book ON dbo.c2_lprior.lp_bkcd = dbo.book.bk_bkcd INNER JOIN " ;
//			SQL = SQL + " dbo.c2_clr ON dbo.c2_lprior.lp_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN ";
//			SQL = SQL + " dbo.c2_ltp ON dbo.c2_lprior.lp_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN ";
//			SQL = SQL + " dbo.c2_pgsize ON ";
//			SQL = SQL + " dbo.c2_lprior.lp_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
//			SQL = SQL + " dbo.c2_pub ON dbo.c2_ltp.ltp_ltpcd = dbo.c2_pub.pub_ltpcd AND ";
//			SQL = SQL + " dbo.c2_clr.clr_clrcd = dbo.c2_pub.pub_clrcd AND ";
//			SQL = SQL + " dbo.c2_pgsize.pgs_pgscd = dbo.c2_pub.pub_pgscd ";
//			SQL = SQL + " GROUP BY  dbo.c2_lprior.lp_lpid, dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, ";
//			SQL = SQL + " dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, ";
//			SQL = SQL + " dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd ";
//			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);
//
//			DataSet ds = new DataSet();
//			myCommand.Fill(ds,"c2_lprior");
//
//			DataView dv = ds.Tables["c2_lprior"].DefaultView;
//
//			lblResult.Text = "";
//			lblNum.Text = dv.Count.ToString();

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_lprior");
			DataView dv1 = ds1.Tables["c2_lprior"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			if(this.tbxQString.Text !=null && this.tbxQString.Text.ToString().Trim() != "")
			{
				if(this.ddlQueryField.SelectedIndex == 0)
				{
					rowfilterstr1 = rowfilterstr1 + " AND bk_nm like '%" + this.tbxQString.Text.ToString().Trim() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 1)
				{
					rowfilterstr1 = rowfilterstr1 + " AND lp_priorseq like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 2)
				{
					rowfilterstr1 = rowfilterstr1 + " AND ltp_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 3)
				{
					rowfilterstr1 = rowfilterstr1 + " AND clr_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 4)
				{
					rowfilterstr1 = rowfilterstr1 + " AND pgs_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();

				//dv1.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() +"%'";
				lblResult.Text = "搜尋結果...";
				lblNum.Text = dv1.Count.ToString();
				lblState.Text = "";
			}
			else
			{
			}


			// 檢查自 新增或修改回來時, 應給的確認訊息
			if (Request.QueryString["ID"] != null)
			{
				string id = Request.QueryString["action"].ToString();
				if (id == "addnew_ok")
				{
					lblState.Text = " ... 資料新增成功 !";
				}
				if (id == "edit_ok")
				{
					lblState.Text = " ... 資料修改成功 !";
				}
			}

			// 恢復 ddlQueryField 的預設選項
			//this.ddlQueryField.SelectedIndex = 00;
		}


		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Delete")
			{
				// 檢查資料項是否已被使用, 若是, 將不允許刪除
				DataGrid1.SelectedIndex=e.Item.ItemIndex;

				// 抓出 廣告相關欄位之值
				string strbkcd = e.Item.Cells[6].Text.ToString();
				string strltpcd = e.Item.Cells[7].Text.ToString();
				string strclrcd = e.Item.Cells[8].Text.ToString();
				string strpgscd = e.Item.Cells[9].Text.ToString();
				//Response.Write("strbkcd= "+ strbkcd + "<BR>");
				//Response.Write("strltpcd= "+ strltpcd + "<BR>");
				//Response.Write("strclrcd= "+ strclrcd + "<BR>");
				//Response.Write("strpgscd= "+ strpgscd + "<BR>");


				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c2_pub");
				DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
				string rowfilterstr1 = "1=1";
				rowfilterstr1 = rowfilterstr1 + " AND lp_bkcd='" + strbkcd + "'";
				rowfilterstr1 = rowfilterstr1 + " AND lp_ltpcd='" + strltpcd + "'";
				rowfilterstr1 = rowfilterstr1 + " AND lp_clrcd='" + strclrcd + "'";
				rowfilterstr1 = rowfilterstr1 + " AND lp_pgscd='" + strpgscd + "'";
				dv1.RowFilter = rowfilterstr1;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


				// 若搜尋結果為 "找不到" 的處理
				if (dv1.Count > 0)
				{
					int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());
					//Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

					// 若 已使用之落版筆數 > 0, 表示已有落版資料使用此優先次序, 故不可刪除
					if (intPubCounts > 0)
					{
						// 以 Javascript 的 window.close() 來告知訊息
						LiteralControl litAlert1 = new LiteralControl();
						litAlert1.Text = "<script language=javascript>alert(\"刪除無效：本筆資料已被使用, 將不允許刪除！\");</script>";
						Page.Controls.Add(litAlert1);
					}
					// 進行刪除
					else
					{
						// 抓出 指定位置之排版優先次序 值
						string CurrentBookCode = e.Item.Cells[6].Text.ToString();
						string CurrentPriorSeq = e.Item.Cells[2].Text.ToString();
						int intCurrentPriorSeq = Convert.ToInt16(CurrentPriorSeq);
						//Response.Write("CurrentBookCode= " + CurrentBookCode + "<br>");
						//Response.Write("CurrentPriorSeq= " + CurrentPriorSeq + "<br>");
						//Response.Write("intCurrentPriorSeq= " + intCurrentPriorSeq + "<br>");

						// 直接刪除 指定位置
						string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
						//string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
						SqlConnection myConn=new SqlConnection(strConn);
						SqlDataAdapter cmd=new SqlDataAdapter("delete from c2_lprior where lp_lpid=@lp_lpid",myConn);

						cmd.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;

						cmd.SelectCommand.Connection.Open();
						cmd.SelectCommand.ExecuteNonQuery();
						cmd.SelectCommand.Connection.Close();

						DataGrid1.CurrentPageIndex=0;
						BindGrid();


						// 抓出目前最大值 MaxLPSeq, 好方便抓出之後筆數之逐行資料
						// 使用 DataSet 方法, 並指定使用的 table 名稱
						DataSet ds2 = new DataSet();
						// 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
						this.sqlDataAdapter2.SelectCommand.Parameters["@bkcd"].Value = CurrentBookCode;
						this.sqlDataAdapter2.Fill(ds2, "c2_lprior");
						DataView dv2 = ds2.Tables["c2_lprior"].DefaultView;

						// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
						// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
						string rowfilterstr2 = "1=1";
						dv2.RowFilter = rowfilterstr2;

						// 檢查並輸出 最後 Row Filter 的結果
						//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
						//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

						// 若搜尋結果為 "找不到" 的處理
						string MaxLPSeq = "01";
						int intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
						if (dv2.Count > 0)
						{
							MaxLPSeq = dv2[0]["MaxSeq"].ToString();
							intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
							int intNextLPSeq = intCurrentPriorSeq+1;
							//Response.Write("intMaxLPSeq= " + intMaxLPSeq + "<br>");
							//Response.Write("intNextLPSeq= " + intNextLPSeq + "<br>");

							for(int i=intNextLPSeq; i<=intMaxLPSeq; i++)
							{
								//Response.Write("i= " + i + ", ");
								string stri = Convert.ToString(i);
								if(stri.Length < 2)
									stri = "0" + stri;
								//Response.Write("stri= " + stri + "<br>");

								// 使用 DataSet 方法, 並指定使用的 table 名稱
								DataSet ds3 = new DataSet();
								this.sqlDataAdapter3.Fill(ds3, "c2_lprior");
								DataView dv3 = ds3.Tables["c2_lprior"].DefaultView;

								// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
								// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
								string rowfilterstr3 = "1=1";
								rowfilterstr3 = rowfilterstr3 + " AND lp_bkcd=" + CurrentBookCode;
								rowfilterstr3 = rowfilterstr3 + " AND lp_priorseq=" + stri;
								dv3.RowFilter = rowfilterstr3;

								// 檢查並輸出 最後 Row Filter 的結果
								//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
								//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

								if(dv3.Count > 0)
								{
									// 抓出 之後筆數之相關值 - 書籍代碼, 廣告版面代碼, 廣告色彩代碼, 廣告篇幅代碼
									string iBookCode = dv3[0]["lp_bkcd"].ToString();
									string iLayoutTypeCode = dv3[0]["lp_ltpcd"].ToString();
									string iColorCode = dv3[0]["lp_clrcd"].ToString();
									string iPageSizeCode = dv3[0]["lp_pgscd"].ToString();
									//Response.Write("iBookCode= " + iBookCode + ", ");
									//Response.Write("iLPSeq= " + stri + ", ");
									//Response.Write("iLayoutTypeCode= " + iLayoutTypeCode + ", ");
									//Response.Write("iColorCode= " + iColorCode + ", ");
									//Response.Write("iPageSizeCode= " + iPageSizeCode + "<br>");

									int intNewLPSeq = i-1;
									string strNewLPSeq = Convert.ToString(intNewLPSeq);
									if(strNewLPSeq.Length < 2)
										strNewLPSeq = "0" + strNewLPSeq;
									//Response.Write("strNewLPSeq= " + strNewLPSeq + "<br>");

									// 執行更新動作
									//string strConn9="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
									string strConn9 = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
									SqlConnection myConn9=new SqlConnection(strConn9);

									SqlDataAdapter cmd9=new SqlDataAdapter("UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = @lp_bkcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_clrcd = @lp_clrcd) AND (lp_pgscd = @lp_pgscd)",myConn9);
									//Response.Write("iLPSeq= " + stri + "<br>");
									//Response.Write("cmd9= UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = " + iBookCode + ") AND (lp_ltpcd = " + iLayoutTypeCode + ") AND (lp_clrcd = " + iColorCode+ ") AND (lp_pgscd = " + iPageSizeCode + ")<br><br>");

									//cmd9.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value = id;
									cmd9.SelectCommand.Parameters.Add("@lp_bkcd",SqlDbType.Char,2).Value = iBookCode;
									cmd9.SelectCommand.Parameters.Add("@lp_priorseq",SqlDbType.Char,2).Value = CurrentPriorSeq;
									cmd9.SelectCommand.Parameters.Add("@lp_ltpcd",SqlDbType.Char,2).Value = iLayoutTypeCode;
									cmd9.SelectCommand.Parameters.Add("@lp_clrcd",SqlDbType.Char,2).Value = iColorCode;
									cmd9.SelectCommand.Parameters.Add("@lp_pgscd",SqlDbType.Char,2).Value = iPageSizeCode;

									DataSet ds9 = new DataSet();
									cmd9.Fill(ds9,"c2_lprior");
								}
							}
						}
						else
						{
							MaxLPSeq = MaxLPSeq;
						}
						//Response.Write("MaxLPSeq= " + MaxLPSeq + "<br>");


						DataGrid1.CurrentPageIndex=0;
						BindGrid();

						this.lblState.Text = " ... 資料刪除成功 !";
					}
				}
				// 進行刪除
				else
				{
					this.lblState.Text = "查無此筆資料, 無法刪除!";
				}

			// 結束 if(e.CommandName == "Delete")
			}
		}


		// 修改按鈕
		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// 抓出畫面上的值
			string id = DataGrid1.SelectedItem.Cells[0].Text.ToString();
			string strbkcd = DataGrid1.SelectedItem.Cells[6].Text.ToString();
			string strpriorseq = DataGrid1.SelectedItem.Cells[2].Text.ToString();
			string strltpcd = DataGrid1.SelectedItem.Cells[7].Text.ToString();
			string strclrcd = DataGrid1.SelectedItem.Cells[8].Text.ToString();
			string strpgscd = DataGrid1.SelectedItem.Cells[9].Text.ToString();
			int intPubCounts = Convert.ToInt32(DataGrid1.SelectedItem.Cells[10].Text.ToString());
			//Response.Write("strbkcd= "+ strbkcd + "<BR>");
			//Response.Write("strpriorseq= "+ strpriorseq + "<BR>");
			//Response.Write("strltpcd= "+ strltpcd + "<BR>");
			//Response.Write("strclrcd= "+ strclrcd + "<BR>");
			//Response.Write("strpgscd= "+ strpgscd + "<BR>");
			//Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

			// 若 已使用之落版筆數 > 0, 表示已有落版資料使用此優先次序, 故不可修改
			if(intPubCounts > 0)
			{
				// 以 Javascript 的 window.close() 來告知訊息
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"修改無效：本筆資料已被使用, 將不允許修改！\");</script>";
				Page.Controls.Add(litAlert1);

				//Response.Redirect("adlprior_edit.aspx?ID=" + id);
			}
			else
			{
				Response.Redirect("adlprior_edit.aspx?ID=" + id);
			}
		}


		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();

			lblState.Text = "";
		}


		private void Query_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();

			lblState.Text = "";
		}


		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			tbxQString.Text="";
			DataGrid1.CurrentPageIndex=0;
			BindGrid();

			lblState.Text = "";
		}


		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlprior_addnew.aspx?function=");
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../default.aspx");
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("MaxSeq", "MaxSeq")})});
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("PubCounts", "PubCounts"),
																																																				   new System.Data.Common.DataColumnMapping("lp_lpid", "lp_lpid"),
																																																				   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				   new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				   new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd, COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_lprior.lp_lpid, dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm FROM dbo.c2_lprior INNER JOIN dbo.book ON dbo.c2_lprior.lp_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.c2_ltp ON dbo.c2_lprior.lp_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN dbo.c2_clr ON dbo.c2_lprior.lp_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ON dbo.c2_lprior.lp_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.c2_pub ON dbo.c2_lprior.lp_clrcd = dbo.c2_pub.pub_clrcd AND dbo.c2_lprior.lp_ltpcd = dbo.c2_pub.pub_ltpcd AND dbo.c2_lprior.lp_pgscd = dbo.c2_pub.pub_pgscd AND dbo.c2_lprior.lp_bkcd = dbo.c2_pub.pub_bkcd GROUP BY dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd, dbo.c2_lprior.lp_lpid, dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm ORDER BY dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq";
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
			this.sqlSelectCommand2.CommandText = "SELECT lp_bkcd, MAX(lp_priorseq) AS MaxSeq FROM dbo.c2_lprior WHERE (lp_bkcd = @b" +
				"kcd) GROUP BY lp_bkcd";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "lp_bkcd"));
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lprior";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
