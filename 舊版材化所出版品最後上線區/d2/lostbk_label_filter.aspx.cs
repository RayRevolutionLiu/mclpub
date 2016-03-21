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
	/// Summary description for lostbk_label_filter.
	/// </summary>
	public class lostbk_label_filter : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblLostDate;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.Panel pnlLabelData;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Button btnPrintOK;
		protected System.Web.UI.WebControls.Button btnCheckAll;
		protected System.Web.UI.WebControls.Button btnPrintLabel;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.DropDownList ddlfgmosea;
		protected System.Web.UI.WebControls.Label lblfgmosea;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Button btnPrintError;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Literal Literal1;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				// 給預設值
				InitialData();
			}
		}


		// 給預設值
		private void InitialData()
		{
			this.ddlfgmosea.SelectedIndex = 0;


			// 抓取登入業務員資訊 - 工號及姓名
			GetLoginEmpInfo();

			this.lblMessage.Text = "";
			this.Literal1.Text = "";
			this.pnlLabelData.Visible = false;
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
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				DataView dv2 = ds2.Tables["srspn"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv2.RowFilter = rowfilterstr2;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv2.Count > 0)
				{
					LoginEmpCName = dv2[0]["srspn_cname"].ToString().Trim();
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
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";

			BindList1();
		}


		// 顯示 DataList1
		private void BindList1()
		{
			// 抓出畫面上的值
			string strfgmosea = this.ddlfgmosea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strfgmosea= " + strfgmosea + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_lost");
			DataView dv3 = ds3.Tables["c2_lost"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";

			// 郵寄地區
			if(strfgmosea == "0")
			{
				rowfilterstr3 = rowfilterstr3 + " AND or_fgmosea='0'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3 + " AND or_fgmosea='1'";
			}
			dv3.RowFilter = rowfilterstr3;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");


			// 若搜尋結果為 "找到" 的處理
			if (dv3.Count > 0)
			{
				this.pnlLabelData.Visible = true;

				this.lblMessage.Text = "共找到 " + dv3.Count + "筆缺書資料!";
				this.DataList1.DataSource = dv3;
				this.DataList1.DataBind();


				// 特別欄位之輸出格式轉換
				for(int i=0; i<DataList1.Items.Count; i++)
				{
					// 測試是否可抓到顯示各行之 Controls (如 lblContNo, lblMfrNo...)
					//for(int j=0; j<DataList1.Items[i].Controls.Count; j++)
					//{
					//string ID = DataList1.Items[i].Controls[j].ID;
					//Response.Write("ID= " + ID + "<br>");
					//}

					// 缺書日期
					string LostDate = ((Label)DataList1.Items[i].FindControl("lblLostDate")).Text;
					LostDate = LostDate.Substring(0, 4) + "/" + LostDate.Substring(4, 2) + "/" + LostDate.Substring(6, 2);
					((Label)DataList1.Items[i].FindControl("lblLostDate")).Text = LostDate;

				}
			}
			else
			{
				this.pnlLabelData.Visible = false;

				this.lblMessage.Text = "找不到符合條件的資料, 您可以 重設條件!";
			}
		}


		// 全選 按鈕的處理
		private void btnCheckAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";

			for(int i=0; i < DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Enabled)
					((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked=true;
			}
		}


		// 標籤列印 按鈕的處理
		private void btnPrintLabel_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";
			this.btnPrintOK.Enabled = true;
			this.btnPrintError.Enabled = true;


			// 抓出被勾選的缺書資料, 更新其 lst_fgprepnt 值為 'v'
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					//將所選之缺書資料的缺書日期(lst_date)填入今天的日期
					string strContNo =((Label)DataList1.Items[i].FindControl("lblContNo")).Text.Trim();
					string strLostSeq =((Label)DataList1.Items[i].FindControl("lblLostSeq")).Text.Trim();
					//Response.Write("strContNo= " + strContNo + ", ");
					//Response.Write("strLostSeq= " + strLostSeq + "<br>");

					// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新資料庫
					//Response.Write(this.sqlCommand1.CommandText);
					this.sqlCommand1.Parameters["@contno"].Value = strContNo;
					this.sqlCommand1.Parameters["@seq"].Value = strLostSeq;

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
						//Response.Write("挑選缺書資料成功!<br>");
					}
					catch(System.Data.SqlClient.SqlException ex1)
					{
						Response.Write(ex1.Message + "<br>");
						myTrans1.Rollback();
						//Response.Write("挑選缺書資料失敗!<br>");
					}
					finally
					{
						this.sqlCommand1.Connection.Close();
					}
				}
			}


			// 抓出畫面上的值
			string strfgmosea = this.ddlfgmosea.SelectedItem.Value.ToString().Trim();
			string strLoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strfgmosea= " + strfgmosea + "<br>");
			//Response.Write("strLoginEmpNo= " + strLoginEmpNo + "<br>");


			// 轉址
			string	strbuf = "lostbk_label.aspx?";

			// 缺書日期區間
			strbuf += "&fgmosea=" + strfgmosea;

			// 登入業務員工號
			strbuf += "&LEmpNo=" + strLoginEmpNo;
			//Response.Write("strbuf= " + strbuf + "<br>");
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		// 列印正確 按鈕的處理
		private void btnPrintOK_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";


			// 抓出被勾選的缺書資料, 更新 lst_fgprepnt = '1', lst_fgpntlbl = '1', lst_fgsent = 'C'
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					//將所選之缺書資料的缺書日期(lst_date)填入今天的日期
					string strContNo =((Label)DataList1.Items[i].FindControl("lblContNo")).Text.Trim();
					string strLostSeq =((Label)DataList1.Items[i].FindControl("lblLostSeq")).Text.Trim();
					//Response.Write("strContNo= " + strContNo + ", ");
					//Response.Write("strLostSeq= " + strLostSeq + "<br>");

					// 執行 將值塞入 sqlCommand2.Parameters 中, 以執行 更新資料庫
					//Response.Write(this.sqlCommand2.CommandText);
					this.sqlCommand2.Parameters["@contno"].Value = strContNo;
					this.sqlCommand2.Parameters["@seq"].Value = strLostSeq;

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
						//Response.Write("完成列印缺書資料成功!<br>");
					}
					catch(System.Data.SqlClient.SqlException ex2)
					{
						Response.Write(ex2.Message + "<br>");
						myTrans2.Rollback();
						//Response.Write("完成列印缺書資料失敗!<br>");
					}
					finally
					{
						this.sqlCommand2.Connection.Close();
					}
				}
			}

			// Refresh DataList1
			BindList1();
			this.btnPrintOK.Enabled = false;
			this.btnPrintError.Enabled = false;
		}


		// 列印不正確 按鈕的處理
		private void btnPrintError_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";


			// 抓出被勾選的缺書資料, 更新回覆 lst_fgprepnt = ' ', lst_fgpntlbl = '0', lst_fgsent = 'Y'
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					//將所選之缺書資料的缺書日期(lst_date)填入今天的日期
					string strContNo =((Label)DataList1.Items[i].FindControl("lblContNo")).Text.Trim();
					string strLostSeq =((Label)DataList1.Items[i].FindControl("lblLostSeq")).Text.Trim();
					//Response.Write("strContNo= " + strContNo + ", ");
					//Response.Write("strLostSeq= " + strLostSeq + "<br>");

					// 執行 將值塞入 sqlCommand3.Parameters 中, 以執行 更新資料庫
					//Response.Write(this.sqlCommand3.CommandText);
					this.sqlCommand3.Parameters["@contno"].Value = strContNo;
					this.sqlCommand3.Parameters["@seq"].Value = strLostSeq;

					// 確認執行 sqlCommand3 成功
					this.sqlCommand3.Connection.Open();
					// 使用 Transaction 確認有執行動作
					System.Data.SqlClient.SqlTransaction myTrans3 = this.sqlCommand3.Connection.BeginTransaction();
					this.sqlCommand3.Transaction = myTrans3;
					//Response.Write(sqlCommand2.Parameters.Count.ToString().Trim());
					try
					{
						this.sqlCommand3.ExecuteNonQuery();
						myTrans3.Commit();
						//Response.Write("回復缺書資料成功!<br>");
					}
					catch(System.Data.SqlClient.SqlException ex3)
					{
						Response.Write(ex3.Message + "<br>");
						myTrans3.Rollback();
						//Response.Write("回復缺書資料失敗!<br>");
					}
					finally
					{
						this.sqlCommand3.Connection.Close();
					}
				}
			}

			// Refresh DataList1
			BindList1();
			this.btnPrintOK.Enabled = false;
			this.btnPrintError.Enabled = false;
		}


		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("lostbk_label_filter.aspx");
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
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
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
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
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
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_contno", "lst_contno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_sdate", "lst_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("lst_edate", "lst_edate"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsentText", "lst_fgsentText"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgpntlbl", "lst_fgpntlbl"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea")})});
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "UPDATE dbo.c2_lost SET lst_fgprepnt = \'v\' WHERE (lst_contno = @contno) AND (lst_s" +
				"eq = @seq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@seq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Original, null));
			//
			// sqlCommand2
			//
			this.sqlCommand2.CommandText = "UPDATE dbo.c2_lost SET lst_fgprepnt = \'1\', lst_fgpntlbl = \'1\', lst_fgsent = \'C\' W" +
				"HERE (lst_contno = @contno) AND (lst_seq = @seq)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@seq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Original, null));
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.c2_lost.lst_contno, dbo.c2_lost.lst_sdate, dbo.c2_lost.lst_edate, dbo.c2_or.or_nm, dbo.c2_or.or_zip, dbo.c2_or.or_addr, dbo.c2_lost.lst_date, dbo.c2_lost.lst_cont, dbo.c2_lost.lst_rea, dbo.c2_lost.lst_fgsent, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_lost.lst_oritem, dbo.c2_lost.lst_seq, dbo.c2_lost.lst_syscd, dbo.c2_or.or_contno, dbo.c2_or.or_oritem, dbo.c2_or.or_syscd, CASE WHEN lst_fgsent = 'Y' THEN '可寄出' WHEN lst_fgsent = 'D' THEN '不處理' WHEN lst_fgsent = 'N' THEN '目前暫時無法寄出' WHEN lst_fgsent = 'C' THEN '已寄出' ELSE '不清楚' END AS lst_fgsentText, dbo.c2_lost.lst_fgpntlbl, dbo.c2_or.or_fgmosea FROM dbo.c2_lost INNER JOIN dbo.c2_or ON dbo.c2_lost.lst_syscd = dbo.c2_or.or_syscd AND dbo.c2_lost.lst_contno = dbo.c2_or.or_contno AND dbo.c2_lost.lst_oritem = dbo.c2_or.or_oritem INNER JOIN dbo.c2_cont ON dbo.c2_or.or_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_or.or_contno = dbo.c2_cont.cont_contno WHERE (dbo.c2_lost.lst_fgpntlbl = '0') AND (dbo.c2_lost.lst_fgsent <> 'C') ORDER BY dbo.c2_lost.lst_date DESC, dbo.c2_lost.lst_contno, dbo.c2_lost.lst_fgsent";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlCommand3
			//
			this.sqlCommand3.CommandText = "UPDATE dbo.c2_lost SET lst_fgprepnt = \' \', lst_fgpntlbl = \'0\', lst_fgsent = \'Y\' W" +
				"HERE (lst_contno = @contno) AND (lst_seq = @seq)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@seq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Original, null));
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
			this.btnPrintOK.Click += new System.EventHandler(this.btnPrintOK_Click);
			this.btnPrintError.Click += new System.EventHandler(this.btnPrintError_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
