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
	/// Summary description for or.
	/// </summary>
	public class or : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

		public or()
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


		public void BindGrid()
		{
			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料
			//string strConn = "Data Source=isccom2;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			string SQL = "SELECT c2_or.*, c2_cont.cont_conttp AS cont_conttp, ";
			SQL = SQL + " c2_cont.cont_bkcd AS cont_bkcd, c2_cont.cont_signdate AS cont_signdate, ";
			SQL = SQL + " c2_cont.cont_empno AS cont_empno, c2_cont.cont_fgclosed AS cont_fgclosed, ";
			SQL = SQL + " mtp.mtp_nm AS mtp_nm";
			SQL = SQL + " FROM c2_or INNER JOIN c2_cont";
			SQL = SQL + " ON c2_or.or_syscd = c2_cont.cont_syscd AND c2_or.or_contno = c2_cont.cont_contno";
			SQL = SQL + " INNER JOIN mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd";

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
				string mtpcdnm = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
				string strfg = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				//Response.Write("mtpcdnm= " + mtpcdnm + "<br>");
				//Response.Write("strfg= " + strfg + "<br>");

				// 變更簽約日期的格式
				DataGrid1.Items[i].Cells[2].Text = signdate.Substring(0, 4) + "/" + signdate.Substring(5, 2) + "/" + signdate.Substring(6, 2);

				// 顯示結案註記的文字說明
				int intfgclosed = int.Parse(fgclosed);
				if(intfgclosed != 0)
					DataGrid1.Items[i].Cells[3].Text = "<FONT Color=Red>是</FONT>";
				else
					DataGrid1.Items[i].Cells[3].Text = "否";

				// 若郵寄類別的文字開始前二個字為 "國外", 則郵寄類別的文字以紅色字顯示
				string StartStr = mtpcdnm.Substring(0, 2);
				//Response.Write("StartStr= " + StartStr + "<br>");
				if(StartStr == "國外")
				{
					//mtpcdnm = "<FONT Color=Red>" + mtpcdnm + "</FONT>";
					//Response.Write("mtpcdnm= " + mtpcdnm + "<br>");
					DataGrid1.Items[i].Cells[10].Text = "<FONT Color=Red>" + DataGrid1.Items[i].Cells[10].Text.ToString().Trim() + "</FONT>";
				}
				else
				{
					mtpcdnm = mtpcdnm;
					//Response.Write("mtpcdnm= " + DataGrid1.Items[i].Cells[8].Text.ToString().Trim() + "<br>");
					DataGrid1.Items[i].Cells[10].Text = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
				}

				// 依註記類的值, 顯示其文字; 若為是, 則以紅色字顯示
				if(strfg == "0")
				{
					DataGrid1.Items[i].Cells[13].Text = "否";
				}
				else
				{
					DataGrid1.Items[i].Cells[13].Text = "<font color=red>是</font>";
				}

			}

			// 恢復 ddlQueryField 的預設選項
			//this.ddlQueryField.SelectedIndex = 02;

		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//String strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("delete from c2_or where or_orid=@or_orid",myConn);

			cmd.SelectCommand.Parameters.Add("@or_orid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;

			cmd.SelectCommand.Connection.Open();
			cmd.SelectCommand.ExecuteNonQuery();
			cmd.SelectCommand.Connection.Close();
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
		}


		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = "ID="+DataGrid1.SelectedItem.Cells[0].Text;
			Response.Redirect("or_edit.aspx?" + id);
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


		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("or_addnew.aspx");
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../default.aspx");
		}


	}
}
