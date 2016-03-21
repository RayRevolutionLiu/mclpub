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
	/// Summary description for PubFm_chklist.
	/// </summary>
	public class PubFm_chklist : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblQuery;
		protected System.Web.UI.WebControls.TextBox tbxDate1;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Label lblRecordCount;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.CheckBox cbx4;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.CheckBox cbx5;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblSEDateMemo;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.TextBox tbxDate2;

		public PubFm_chklist()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
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


		// 預設值
		private void InitialData()
		{
			// 查詢資料區
			//-----------------------
			this.cbx0.Checked = true;
			this.cbx4.Checked = false;
			this.cbx5.Checked = false;


			// 刊登年月區間
			this.tbxDate1.Text = System.DateTime.Today.ToString("yyyy/MM");
			this.tbxDate2.Text = System.DateTime.Today.ToString("yyyy/MM");


			// 合約編號及廠商名稱
			this.tbxContNo.Text = "";
			this.tbxMfrIName.Text = "";


			// 清除 DataList
			this.DataList1.Visible = false;
			this.lblRecordCount.Text = "";
		}


		// 查詢 按鈕
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			if(cbx0.Checked)
			{
				BindList1();
			}
			else
			{
				BindList2();
			}
		}


		// 以刊登年月為搜尋條件
		private void BindList1()
		{
			// 抓出篩選條件
			string date1, date2;
			date1 = tbxDate1.Text.Substring(0,4) + tbxDate1.Text.Substring(5,2);
			date2 = tbxDate2.Text.Substring(0,4) + tbxDate2.Text.Substring(5,2);

			// 先抓出 合約書編號
			// 若勾選查詢條件零時 - 刊登年月
			if(cbx0.Checked)
			{
				this.sqlDataAdapter1.SelectCommand.Parameters["@date1"].Value = date1;
				this.sqlDataAdapter1.SelectCommand.Parameters["@date2"].Value = date2;
			}

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string rowfilterstr1 = " 1=1 ";

			// 若勾選查詢條件四時 - 合約書編號
			string QstrContNo;
			if(cbx4.Checked)
			{
				QstrContNo = this.tbxContNo.Text.ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND (pub_contno Like '%" + QstrContNo + "%') ";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}

			// 若勾選查詢條件五時 - 廠商名稱
			string QstrMfrIName;
			if(cbx5.Checked)
			{
				QstrMfrIName = this.tbxMfrIName.Text.ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND (mfr_inm Like '%" + QstrMfrIName + "%') ";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter= rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


			// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
			if(dv1.Count > 0)
			{
				// 顯示 DataList
				this.DataList1.Visible = true;


				// Part I - 抓出符合條件的合約書編號及其資料
				DataList1.DataSource=dv1;
				DataList1.DataBind();

				// 告知查詢結果
				this.lblRecordCount.Text = "查詢結果：共有 " + dv1.Count + " 筆資料!";

				// 抓出 DataList1 的細節資訊
				GetDetails();
			}
			// 若找無資料時, 顯示其相關訊息
			else
			{
				this.DataList1.Visible = false;
				this.lblRecordCount.Text = "查詢結果：共有 0 筆資料! 請重新搜尋";
			}
		}


		// 以其他條件（除刊登年月外）為搜尋條件
		private void BindList2()
		{
			// 抓出篩選條件
			string date1, date2;
			date1 = tbxDate1.Text.Substring(0,4) + tbxDate1.Text.Substring(5,2);
			date2 = tbxDate2.Text.Substring(0,4) + tbxDate2.Text.Substring(5,2);

			// 先抓出 合約書編號
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_pub");
			DataView dv5 = ds5.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string rowfilterstr5 = " 1=1 ";

			// 若勾選查詢條件四時 - 合約書編號
			string QstrContNo;
			if(cbx4.Checked)
			{
				QstrContNo = this.tbxContNo.Text.ToString().Trim();
				rowfilterstr5 = rowfilterstr5 + " AND (pub_contno Like '%" + QstrContNo + "%') ";
			}
			else
			{
				rowfilterstr5 = rowfilterstr5;
			}

			// 若勾選查詢條件五時 - 廠商名稱
			string QstrMfrIName;
			if(cbx5.Checked)
			{
				QstrMfrIName = this.tbxMfrIName.Text.ToString().Trim();
				rowfilterstr5 = rowfilterstr5 + " AND (mfr_inm Like '%" + QstrMfrIName + "%') ";
			}
			else
			{
				rowfilterstr5 = rowfilterstr5;
			}
			dv5.RowFilter= rowfilterstr5;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");


			// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
			if(dv5.Count > 0)
			{
				// 顯示 DataList
				this.DataList1.Visible = true;


				// Part I - 抓出符合條件的合約書編號及其資料
				DataList1.DataSource=dv5;
				DataList1.DataBind();

				// 告知查詢結果
				this.lblRecordCount.Text = "查詢結果：共有 " + dv5.Count + " 筆資料!";


				// 抓出 DataList1 的細節資訊
				GetDetails();
			}
			// 若找無資料時, 顯示其相關訊息
			else
			{
				this.DataList1.Visible = false;
				this.lblRecordCount.Text = "查詢結果：共有 0 筆資料! 請重新搜尋";
			}
		}



		// 抓出 DataList1 的細節資訊
		private void GetDetails()
		{
			// 抓出篩選條件
			string date1, date2;
			date1 = tbxDate1.Text.Substring(0,4) + tbxDate1.Text.Substring(5,2);
			date2 = tbxDate2.Text.Substring(0,4) + tbxDate2.Text.Substring(5,2);


			// 抓出 DataGrid1 (IM) 資料
			//Response.Write("DataList1.Items.Count= " + DataList1.Items.Count + "<br>");
			//Response.Write("DataList1.Controls.Count= " + DataList1.Controls.Count + "<br>");
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				// 測試是否可抓到顯示各行之 Controls (如 lblContNo, DataList2, DataGrid1...)
				for(int j=0; j<DataList1.Items[i].Controls.Count; j++)
				{
					string ID = DataList1.Items[i].Controls[j].ID;
					//Response.Write("ID= " + ID + "<br>");
				}


				// Part II - 抓出 發票廠商收件人 IM (DataGrid1) 的資料
				// 抓出 合約書編號, 以篩選 IM 資料
				string strContNo = ((Label)DataList1.Items[i].FindControl("lblContNo")).Text;
				//Response.Write("strContNo= " + strContNo + "<br>");


				// 抓出 發票廠商收件人 DataGrid1
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "invmfr");
				DataView dv2 = ds2.Tables["invmfr"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND (im_syscd='C2')";
				rowfilterstr2 = rowfilterstr2 + " AND (im_contno='" + strContNo + "')";
				dv2.RowFilter= rowfilterstr2;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv2.Count > 0)
				{
					((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).DataSource = dv2;
					((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).DataBind();


					// 特別欄位之輸出格式轉換 - 變更發票類別等的格式
					//Response.Write("DataGrid1.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count + "<br>");
					for(int j=0; j< ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count ; j++)
					{
						// 發票類別
						string invcd = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text.ToString().Trim();
						//Response.Write("invcd = " + invcd + "<br>");
						switch (invcd)
						{
							case "2":
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "二聯";
								break;
							case "3":
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "三聯";
								break;
							case "4":
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "其他";
								break;
							default:
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "三聯";
								break;
						}

						// 發票課稅別
						string taxtp = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text.ToString().Trim();
						//Response.Write("taxtp = " + taxtp + "<br>");
						switch (taxtp)
						{
							case "1":
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "應稅5%";
								break;
							case "2":
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "零稅";
								break;
							case "3":
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "免稅";
								break;
							default:
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "應稅5%";
								break;
						}

						// 院所內註記
						string fgitri = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text.ToString().Trim();
						//Response.Write("fgitri = " + fgitri + "<br>");
						if(fgitri == "")
							((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "否";
						else
						{
							if(fgitri == "06")
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "<font color='Red'>所內</font>";
							if(fgitri == "07")
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "<font color='Red'>院內</font>";
						}
					}
					// 結束 if(dv2.Count > 0)
				}



				// 抓出 發票廠商收件人 DataGrid2
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "c2_cont");
				DataView dv4 = ds4.Tables["c2_cont"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr4 = "1=1";
				rowfilterstr4 = rowfilterstr4 + " AND (cont_syscd='C2')";
				rowfilterstr4 = rowfilterstr4 + " AND (cont_contno='" + strContNo + "')";
				dv4.RowFilter= rowfilterstr4;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
				//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv4.Count > 0)
				{
					((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).DataSource = dv4;
					((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).DataBind();


					// 特別欄位之輸出格式轉換 - 變更發票類別等的格式
					//Response.Write("DataGrid2.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items.Count + "<br>");
					for(int m=0; m< ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items.Count ; m++)
					{
						// 合約起日
						string sdate = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[4].Text.ToString().Trim();
						//Response.Write("sdate = " + sdate + "<br>");
						if(sdate.Length >=6)
							sdate = sdate.Substring(0, 4) + "/" + sdate.Substring(4, 2);
						else
							sdate = sdate;
						((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[4].Text = sdate;

						// 合約迄日
						string edate = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[5].Text.ToString().Trim();
						//Response.Write("edate = " + edate + "<br>");
						if(edate.Length >=6)
							edate = edate.Substring(0, 4) + "/" + edate.Substring(4, 2);
						else
							edate = edate;
						((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[5].Text = edate;

						// 一次付款註記
						string fgpayonce = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[6].Text.ToString().Trim();
						//Response.Write("fgpayonce = " + fgpayonce + "<br>");
						if(fgpayonce == "0")
							((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[6].Text = "否";
						else
							((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[6].Text = "<font color='Red'>是</font>";

					}
				}



				// Part IIII - 抓出符合條件的對應落版資料
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c2_pub");
				DataView dv3 = ds3.Tables["c2_pub"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterst3 = " 1=1 ";
				if(this.cbx0.Checked)
				{
					rowfilterst3 = rowfilterst3 + " AND (pub_yyyymm >= '" + date1 + "')";
					rowfilterst3 = rowfilterst3 + " AND (pub_yyyymm <= '" + date2 + "')";
				}
				rowfilterst3 = rowfilterst3 + " AND (pub_contno like '%" + strContNo + "%')";
				dv3.RowFilter= rowfilterst3;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR><BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv3.Count > 0)
				{
					((DataList)DataList1.Items[i].FindControl("DataList2")).DataSource = dv3;
					((DataList)DataList1.Items[i].FindControl("DataList2")).DataBind();

					// 特別欄位之輸出格式轉換 - 變更發票類別等的格式
					//Response.Write("DataGrid1.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count + "<br>");
					for(int k=0; k< ((DataList)DataList1.Items[i].FindControl("DataList2")).Items.Count ; k++)
					{
						// 刊登年月
						string yyyymm = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblYYYYMM")).Text.ToString().Trim();
						//Response.Write("yyyymm = " + yyyymm + "<br>");
						int intyyyymm = int.Parse(yyyymm);
						if(intyyyymm >= 6)
							yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
						else
							yyyymm = yyyymm;
						((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblYYYYMM")).Text = yyyymm;

						// 固定頁次註記
						string fgfixpg = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgFixPg")).Text.ToString().Trim();
						//Response.Write("fgfixpg = " + fgfixpg + "<br>");
						if(fgfixpg == "0")
							((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgFixPg")).Text = "否";
						else
							((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgFixPg")).Text = "<font color='Red'>是</font>";

						// 修改日期
						string ModifyDate = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblModifyDate")).Text.ToString().Trim();
						//Response.Write("ModifyDate = " + ModifyDate + "<br>");
						int intModifyDate = int.Parse(ModifyDate);
						if(intModifyDate >= 8)
							ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
						else
							ModifyDate = ModifyDate;
						((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblModifyDate")).Text = ModifyDate;

						// 已開立發票開立單註記
						string fginved = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text.ToString().Trim();
						//Response.Write("fginved = " + fginved + "<br>");
						if(fginved == "")
							((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text = "<font color='Red'>否</font>";
						if(fginved == "v")
							((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text = "<font color='Blue'>已挑未開</font>";
						if(fginved == "1")
							((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text = "已開立";

						// 發票開立單人工處理註記
						string fginvself = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInvSelf")).Text.ToString().Trim();
						//Response.Write("fginvself = " + fginvself + "<br>");
						if(fginvself == "0")
							((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInvSelf")).Text = "否";
						else
							((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInvSelf")).Text = "<font color='Red'>是</font>";

						// 稿件類別
						string drafttp = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text.ToString().Trim();
						//Response.Write("drafttp = " + drafttp + "<br>");
						switch (drafttp)
						{
							case "1":
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "舊稿";

								// 到稿註記
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "";

								// 改稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJNo")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJbkno")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "";

								// 新稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgNjtpcd")).Text = "";
								break;

							case "2":
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "新稿";

								// 到稿註記
								string fggot1 = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text.ToString().Trim();
								//Response.Write("fggot1 = " + fggot1 + "<br>");
								if(fggot1 == "0")
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "<font color='Red'>否</font>";
								else
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "是";

								// 舊稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigBkcd")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJNo")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJbkno")).Text = "";

								// 改稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJNo")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJbkno")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "";
								break;

							case "3":
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "改稿";

								// 到稿註記
								string fggot2 = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text.ToString().Trim();
								//Response.Write("fggot2 = " + fggot2 + "<br>");
								if(fggot2 == "0")
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "<font color='Red'>否</font>";
								else
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "是";

								// 改稿書類
								string chgbkcd = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text.ToString().Trim();
								//Response.Write("chgbkcd = " + chgbkcd + "<br>");
							switch (chgbkcd)
							{
								case "  ":
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
									break;
								case "01":
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "工材雜誌";
									break;
								case "02":
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "電材雜誌";
									break;
								default:
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "工材雜誌";
									break;
							}

								// 改稿重出片註記
								string fgrechg = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text.ToString().Trim();
								//Response.Write("fgrechg = " + fgrechg + "<br>");
								if(fgrechg == "0")
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "<font color='Red'>否</font>";
								else
									((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "是";

								// 舊稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigBkcd")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJNo")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJbkno")).Text = "";

								// 新稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgNjtpcd")).Text = "";
								break;

							default:
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "舊稿";

								// 到稿註記
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "";

								// 改稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJNo")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJbkno")).Text = "";
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "";

								// 新稿相關資料
								((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgNjtpcd")).Text = "";
								break;
						}
						// 	結束 for(int k=0; k< ((DataList)DataList1.Items[i].FindControl("DataList2")).Items.Count ; k++)
					}
					// 結束 if(dv3.Count > 0)
				}
				// 結束 for(int i=0; i<DataList1.Items.Count; i++)
			}
		}


		// 返回首頁 按鈕
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("../default.aspx");
		}


		// 清除重查 按鈕
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			InitialData();
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
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
																																																				new System.Data.Common.DataColumnMapping("pub_fgact", "pub_fgact"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2" +
				"_pub.pub_pubseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd" +
				", dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub." +
				"pub_drafttp, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pub_ori" +
				"gjbkno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, " +
				"dbo.c2_pub.pub_fgrechg, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub." +
				"pub_projno, dbo.c2_pub.pub_costctr, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginv" +
				"self, dbo.c2_pub.pub_pno, dbo.c2_pub.pub_remark, dbo.c2_pub.pub_fgfixpg, dbo.c2_" +
				"pub.pub_moddate, dbo.c2_pub.pub_modempno, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_im" +
				"seq, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, dbo.c2_ltp.ltp_nm, dbo.c2_c" +
				"lr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_njtp.njtp_nm, dbo.srspn.srspn_cname, dbo" +
				".book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_ltpcd, dbo.c" +
				"2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.srspn.srspn_empno, dbo.invmfr.i" +
				"m_nm, dbo.invmfr.im_mfrno, dbo.invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr" +
				".im_syscd FROM dbo.c2_pub INNER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2" +
				"_ltp.ltp_ltpcd INNER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_cl" +
				"rcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd I" +
				"NNER JOIN dbo.srspn ON dbo.c2_pub.pub_modempno = dbo.srspn.srspn_empno INNER JOI" +
				"N dbo.invmfr ON dbo.c2_pub.pub_syscd = dbo.invmfr.im_syscd AND dbo.c2_pub.pub_co" +
				"ntno = dbo.invmfr.im_contno AND dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq LEFT " +
				"OUTER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOI" +
				"N dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd";
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
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, " +
				"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM dbo.invmfr" +
				" WHERE (im_syscd = \'C2\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
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
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adamt", "cont_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freebkcnt", "cont_freebkcnt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_remark", "cont_remark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_njtpcnt", "cont_njtpcnt"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm")})});
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = @"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_totjtm, dbo.c2_cont.cont_disc, dbo.c2_cont.cont_tottm, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_adamt, dbo.c2_cont.cont_clrtm, dbo.c2_cont.cont_getclrtm, dbo.c2_cont.cont_menotm, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_custno, dbo.cust.cust_nm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_oldcontno, dbo.mfr.mfr_inm, dbo.c2_cont.cont_freebkcnt, dbo.c2_cont.cont_remark, dbo.c2_cont.cont_njtpcnt, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c2_cont.cont_freetm, dbo.c2_cont.cont_chgjtm FROM dbo.c2_cont INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter5
			//
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			//
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = @"SELECT DISTINCT dbo.c2_pub.pub_contno, dbo.mfr.mfr_inm FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT DISTINCT dbo.c2_pub.pub_contno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.c2_pub.pub_yyyymm >= @date1) AND (dbo.c2_pub.pub_yyyymm <= @date2)";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date1", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date2", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
