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
	/// Summary description for invmfr.
	/// </summary>
	public class invmfr : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		public invmfr()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 指定 ddlQueryField 的預設選項
				this.ddlQueryField.SelectedIndex = 02;

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

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		public void BindGrid()
		{
			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料
			//string strConn = "Data Source=isccom2;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			string SQL = "SELECT invmfr.im_imid, invmfr.im_contno, c2_cont.cont_signdate, ";
			SQL = SQL + " c2_cont.cont_fgclosed, invmfr.im_imseq, invmfr.im_mfrno, ";
			SQL = SQL + " mfr.mfr_inm, invmfr.im_nm, invmfr.im_jbti, invmfr.im_zip, ";
			SQL = SQL + " invmfr.im_addr, invmfr.im_tel, invmfr.im_fax, invmfr.im_cell, ";
			SQL = SQL + " invmfr.im_email, invmfr.im_invcd, invmfr.im_taxtp, ";
			SQL = SQL + " invmfr.im_fgitri ";
			SQL = SQL + " FROM invmfr INNER JOIN mfr";
			SQL = SQL + " ON invmfr.im_mfrno = mfr.mfr_mfrno ";
			SQL = SQL + " LEFT OUTER JOIN c2_cont ";
			SQL = SQL + " ON invmfr.im_syscd = c2_cont.cont_syscd ";
			SQL = SQL + " AND invmfr.im_contno = c2_cont.cont_contno ";

			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;

			lblResult.Text = "";
			lblNum.Text = dv.Count.ToString();

			if (tbxQString.Text !=null && tbxQString.Text != "")
			{
				dv.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() +"%'";
				lblResult.Text = "搜尋結果...";
				lblNum.Text = dv.Count.ToString();
				lblState.Text = "";
			}

			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();


			//註記類 => 數值改以文字顯示
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 抓出 郵寄類別的文字 及 海外郵寄註記的值
				string signdate = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				string fgclosed = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				string invcd = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
				string taxtp = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
				string fgitri = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
				//Response.Write("invcd= " + invcd + "<br>");
				//Response.Write("taxtp= " + taxtp + "<br>");
				//Response.Write("fgitri= " + fgitri + "<br>");

				// 變更簽約日期的格式
				if(signdate.Length > 0 || signdate.Trim() != "")
				{
					DataGrid1.Items[i].Cells[2].Text = signdate.Substring(0, 4) + "/" + signdate.Substring(4, 2) + "/" + signdate.Substring(6, 2);
				}
				else
				{
					DataGrid1.Items[i].Cells[2].Text = signdate;
				}
				//DataGrid1.Items[i].Cells[2].Text = signdate;

				// 顯示結案註記的文字說明
				if(fgclosed != "0")
					DataGrid1.Items[i].Cells[3].Text = "<FONT Color=Red>是</FONT>";
				else
					DataGrid1.Items[i].Cells[3].Text = "否";

				// 依註記類的值, 顯示其文字
				if(invcd != "")
				{
					if(invcd == "1")
					{
						DataGrid1.Items[i].Cells[15].Text = "(不詳)";
					}
					if(invcd == "2")
					{
						DataGrid1.Items[i].Cells[15].Text = "二聯式";
					}
					if(invcd == "3")
					{
						DataGrid1.Items[i].Cells[15].Text = "三聯式";
					}
					if(invcd == "4")
					{
						DataGrid1.Items[i].Cells[15].Text = "<font color=blue>其他</font>";
					}
					if(invcd == "9")
					{
						DataGrid1.Items[i].Cells[15].Text = "<font color=Red>不清楚</font>";
					}
				}
				else
				{
					DataGrid1.Items[i].Cells[15].Text = "<font color=red>(無資料)</font>";
				}

				// 依註記類的值, 顯示其文字
				if(taxtp != "")
				{
					if(taxtp == "1")
					{
						DataGrid1.Items[i].Cells[16].Text = "應稅";
					}
					if(taxtp == "2")
					{
						DataGrid1.Items[i].Cells[16].Text = "<font color=darkred>零稅</font>";
					}
					if(taxtp == "3")
					{
						DataGrid1.Items[i].Cells[16].Text = "<font color=red>免稅</font>";
					}
					if(taxtp == "9")
					{
						DataGrid1.Items[i].Cells[16].Text = "<font color=red>不清楚</font>";
					}
				}
				else
				{
					DataGrid1.Items[i].Cells[16].Text = "<font color=red>(無資料)</font>";
				}

				// 依註記類的值, 顯示其文字
				if(fgitri != "")
				{
					if(fgitri == "06")
					{
						DataGrid1.Items[i].Cells[17].Text = "<font color=darkred>所內往來</font>";
					}
					if(fgitri == "07")
					{
						DataGrid1.Items[i].Cells[17].Text = "<font color=red>院內往來</font>";
					}
					else
					{
						DataGrid1.Items[i].Cells[17].Text = "非工研院";
					}
				}
				else
				{
					DataGrid1.Items[i].Cells[17].Text = "否";
				}

			}

			// 恢復 ddlQueryField 的預設選項
			//this.ddlQueryField.SelectedIndex = 02;

		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}


		private void Query_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();
		}


		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			tbxQString.Text="";
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../default.aspx");
		}


	}
}
