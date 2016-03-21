using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MRLPub.d5
{
	/// <summary>
	/// Summary description for book.
	/// </summary>
	public class itp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public itp()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//if (Session["atype"].ToString() == "Z")
				//{
				//	Response.Redirect("../login_error.aspx");
				//}
				Session.Add("QString", "");
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
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			string SQL = "select * from itp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			
			lblResult.Text = "";
			lblNum.Text = dv.Count.ToString();

			if (Request.QueryString["ID"] != null)
			{
				string id = Request.QueryString["ID"].ToString();
				if (id == "addnew_ok")
				{
					lblState.Text = " ... 資料新增成功 !";
				}
				if (id == "edit_ok")
				{
					lblState.Text = " ... 資料修改成功 !";
				}
			}

			if (tbxQString.Text !=null && tbxQString.Text != "")
			{
				dv.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + Session["QString"].ToString() +"%'";
				lblResult.Text = "搜尋結果...";
				lblNum.Text = dv.Count.ToString();
				lblState.Text = "";
			}

			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Query_Click(object sender, System.EventArgs e)
		{
			Session.Add("QString", tbxQString.Text.Trim());
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();
			lblState.Text = "";
		}

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("itp_addnew.aspx");
		}

		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			tbxQString.Text="";
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
			lblState.Text = "";
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn = new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("delete from itp where itp_itpid=@itp_itpid",myConn);
		
			cmd.SelectCommand.Parameters.Add("@itp_itpid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;
		
			cmd.SelectCommand.Connection.Open();
			cmd.SelectCommand.ExecuteNonQuery();
			cmd.SelectCommand.Connection.Close();
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
			lblState.Text = " ... 資料刪除成功 !";
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			tbxQString.Text="";
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
			lblState.Text = "";
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = "ID="+DataGrid1.SelectedItem.Cells[0].Text;
			Response.Redirect("itp_edit.aspx?" + id);
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../default.aspx");
		}
	}
}
