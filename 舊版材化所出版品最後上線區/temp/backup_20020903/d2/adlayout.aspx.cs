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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adlayout.
	/// </summary>
	public class adlayout : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public adlayout()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{

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
			string DSN = "Data Source=isccom1;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
			SqlConnection myConnection = new SqlConnection(DSN);
			
			string SQL = "select * from c2_ltp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);
			
			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");
			
			DataView dv = ds.Tables["Title"].DefaultView;
			
			lblResult.Text = "";
			lblNum.Text = dv.Count.ToString();
						
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
			

			if (tbxQString.Text !=null && tbxQString.Text != "")
			{
				dv.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() +"%'";
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			String strConn="Data Source=isccom1;database=mrlpub;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("delete from c2_ltp where ltp_ltpid=@ltp_ltpid",myConn);
		
			cmd.SelectCommand.Parameters.Add("@ltp_ltpid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;
		
			cmd.SelectCommand.Connection.Open();
			cmd.SelectCommand.ExecuteNonQuery();
			cmd.SelectCommand.Connection.Close();
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
			
			lblState.Text = " ... 資料刪除成功 !";
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = "ID="+DataGrid1.SelectedItem.Cells[0].Text;
			Response.Redirect("adlayout_edit.aspx?" + id);
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
			Response.Redirect("adlayout_addnew.aspx");
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/mrlpub/default.aspx");
		}


	}
}
