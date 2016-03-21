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
	public class cust : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public cust()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
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
			//string id = Request.QueryString["ID"].ToString();

			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			//string SQL = "select * from cust";
			string SQL = "";
			if(Session["atype"] == null)
				Response.Redirect("../Default.aspx");
			else
			{
				//如果是D級業務人員，只能看到自己的客戶資料
				if(!Session["atype"].ToString().Equals("D"))
					SQL = "SELECT dbo.cust.*, dbo.srspn.srspn_cname,dbo.mfr.mfr_inm AS mfr_inm FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.srspn ON dbo.cust.cust_srspn_empno = dbo.srspn.srspn_empno ";
				else
					SQL = "SELECT dbo.cust.*, dbo.srspn.srspn_cname,dbo.mfr.mfr_inm AS mfr_inm FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.srspn ON dbo.cust.cust_srspn_empno = dbo.srspn.srspn_empno and dbo.cust.cust_srspn_empno = '" + Session["empid"].ToString() + "'";
			}
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			
			lblResult.Text = "";
			lblNum.Text = dv.Count.ToString();
			//Response.Write(Session["QString"].ToString());

			if (Request.QueryString["ID"] != null)
			{
				string id = Request.QueryString["ID"].ToString();
				if (id == "addnew_ok")
				{
					lblState.Text = " ... 資料新增成功 !";
//					lblResult.ForeColor = System.Drawing.Color.Blue;
//					LiteralControl litSus = new LiteralControl();
//					litSus.Text = "<script>alert(\"新增成功!\")</script>";
//					Page.Controls.Add(litSus);
				}
				if (id == "edit_ok")
				{
					lblState.Text = " ... 資料修改成功 !";
//					lblResult.ForeColor = System.Drawing.Color.Blue;
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
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
			Response.Redirect("cust_add.aspx");
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
			SqlDataAdapter cmd=new SqlDataAdapter("delete from cust where cust_custid=@cust_custid",myConn);
		
			cmd.SelectCommand.Parameters.Add("@cust_custid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;
		
			cmd.SelectCommand.Connection.Open();
			cmd.SelectCommand.ExecuteNonQuery();
			cmd.SelectCommand.Connection.Close();
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
			lblState.Text = " ... 資料刪除成功 !";
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//tbxQString.Text="";
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
			lblState.Text = "";
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = "ID="+DataGrid1.SelectedItem.Cells[0].Text;
			Response.Redirect("cust_edit.aspx?" + id);
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../default.aspx");
		}
	}
}
