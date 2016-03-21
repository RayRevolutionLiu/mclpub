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

namespace MRLPub.d4.mrladm
{
	/// <summary>
	/// Summary description for AdViewAd.
	/// </summary>
	public class AdViewAd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaContAdr;
		protected System.Web.UI.WebControls.DataGrid dgdContAdr;
		protected System.Web.UI.WebControls.Image imgAdFiles;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
	
		public AdViewAd()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
				Bind_dgdContAdr("");

				imgAdFiles.Visible = false;
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaContAdr = new System.Data.SqlClient.SqlDataAdapter();
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.dgdContAdr.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgdContAdr_SortCommand);
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_conttp, cont_fgcancel, cont_fgclosed, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_alttext, dbo.c4_adr.adr_imgurl, dbo.c4_adr.adr_navurl, dbo.c4_adr.adr_impr, dbo.c4_adr.adr_fggot, dbo.c4_adr.adr_remark, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_syscd FROM dbo.c4_adr INNER JOIN dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno WHERE (dbo.c4_cont.cont_fgtemp = '0')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlDaContAdr
			// 
			this.sqlDaContAdr.SelectCommand = this.sqlSelectCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			calSelectAdDate.SelectedDate = DateTime.Today;
		}

		private void Format_dgdContAdr_Fields()
		{
			for (int i=0; i<dgdContAdr.Items.Count; i++)
			{
				//合約類別
				switch(dgdContAdr.Items[i].Cells[1].Text.Trim())
				{
					case "01":
						dgdContAdr.Items[i].Cells[1].Text = "一般";
						break;
					case "09":
						dgdContAdr.Items[i].Cells[1].Text = "推廣";
						break;
					default:
						dgdContAdr.Items[i].Cells[1].Text = "";
						break;
				}

				//廣告頁面
				switch(dgdContAdr.Items[i].Cells[3].Text.Trim())
				{
					case "M":
						dgdContAdr.Items[i].Cells[3].Text = "首頁";
						break;
					case "I":
						dgdContAdr.Items[i].Cells[3].Text = "內頁";
						break;
					case "N":
						dgdContAdr.Items[i].Cells[3].Text = "奈米";
						break;
					default:
						dgdContAdr.Items[i].Cells[3].Text = "";
						break;
				}

				//廣告頁面
				switch(dgdContAdr.Items[i].Cells[4].Text.Trim())
				{
					case "h0":
						dgdContAdr.Items[i].Cells[4].Text = "正中";
						break;
					case "h1":
						dgdContAdr.Items[i].Cells[4].Text = "右一";
						break;
					case "h2":
						dgdContAdr.Items[i].Cells[4].Text = "右二";
						break;
					case "h3":
						dgdContAdr.Items[i].Cells[4].Text = "右三";
						break;
					case "h4":
						dgdContAdr.Items[i].Cells[4].Text = "右四";
						break;
					case "w1":
						dgdContAdr.Items[i].Cells[4].Text = "文一";
						break;
					case "w2":
						dgdContAdr.Items[i].Cells[4].Text = "文二";
						break;
					case "w3":
						dgdContAdr.Items[i].Cells[4].Text = "文三";
						break;
					case "w4":
						dgdContAdr.Items[i].Cells[4].Text = "文四";
						break;
					case "w5":
						dgdContAdr.Items[i].Cells[4].Text = "文五";
						break;
					case "w6":
						dgdContAdr.Items[i].Cells[4].Text = "文六";
						break;
					default:
						dgdContAdr.Items[i].Cells[4].Text = "";
						break;
				}

				//到稿註記
				switch(dgdContAdr.Items[i].Cells[9].Text.Trim())
				{
					case "1":
						dgdContAdr.Items[i].Cells[9].Text = "是";
						dgdContAdr.Items[i].Cells[9].ForeColor = Color.Black;
						break;
					case "0":
						dgdContAdr.Items[i].Cells[9].Text = "否";
						dgdContAdr.Items[i].Cells[9].ForeColor = Color.Red;
						break;
					default:
						dgdContAdr.Items[i].Cells[9].Text = "";
						break;
				}

				//註銷
				switch(dgdContAdr.Items[i].Cells[11].Text.Trim())
				{
					case "0":
						break;
					case "1":
						dgdContAdr.Items[i].BackColor = Color.Red;
						break;
				}

				//結案
				switch(dgdContAdr.Items[i].Cells[12].Text.Trim())
				{
					case "0":
						break;
					case "1":
						dgdContAdr.Items[i].BackColor = Color.Blue;
						break;
				}
			}
		}

		private void Bind_dgdContAdr(string strSort)
		{
			string strAdDate = calSelectAdDate.SelectedDate.ToString("yyyyMMdd");
			DataSet ds = new DataSet();
			this.sqlDaContAdr.Fill(ds, "CONTADR");
			DataView dv = ds.Tables["CONTADR"].DefaultView;
			dv.RowFilter = "adr_sdate<='" + strAdDate + "' AND adr_edate>='" + strAdDate + "'";

			if (strSort.Trim()!="")
			{
				dv.Sort = strSort;
			}

			dgdContAdr.DataSource = dv;
			dgdContAdr.DataBind();

			Format_dgdContAdr_Fields();
		}

		private void calSelectAdDate_SelectionChanged(object sender, System.EventArgs e)
		{
			Bind_dgdContAdr("");

			if (dgdContAdr.SelectedIndex<0)
			{
				imgAdFiles.Visible = false;
			}
			else
			{
				imgAdFiles.Visible = true;
				string strFileName = ((LinkButton)dgdContAdr.SelectedItem.Cells[6].Controls[0]).Text.Trim();
				imgAdFiles.ImageUrl = "~/d4/AdImages/" + strFileName;
			}
		}

		private void dgdContAdr_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			dgdContAdr.SelectedIndex = -1;
			Bind_dgdContAdr(e.SortExpression);

			if (dgdContAdr.SelectedIndex<0)
			{
				imgAdFiles.Visible = false;
			}
			else
			{
				imgAdFiles.Visible = true;
				string strFileName = ((LinkButton)dgdContAdr.SelectedItem.Cells[6].Controls[0]).Text.Trim();
				imgAdFiles.ImageUrl = "~/d4/AdImages/" + strFileName;
			}
		}
	}
}
