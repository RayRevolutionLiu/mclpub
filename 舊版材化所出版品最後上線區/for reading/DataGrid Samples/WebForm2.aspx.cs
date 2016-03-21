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
using System.Data.SqlClient;

namespace TestProj
{
	/// <summary>
	/// Summary description for WebForm2.
	/// </summary>
	public class WebForm2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox tbxAddPrice;
		protected System.Web.UI.WebControls.TextBox tbxAddTitle;
		protected System.Web.UI.WebControls.TextBox tbxAddTitleID;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;

		private static string strDSN = "server=isccom1;database=900103;uid=webuser;pwd=db600";

	
		public WebForm2()
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

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid()
		{
			string strSelectCommand = "SELECT title_id, title, price FROM smallpubs";
			
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet();
			da.Fill(ds, "SMALLPUBS");
			DataView dv = ds.Tables["SMALLPUBS"].DefaultView;
			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			string strInsertCommand = "INSERT INTO smallpubs (title_id, title, price) VALUES (@title_id, @title, @price)";
			SqlConnection cnn = new SqlConnection(strDSN);
			SqlCommand cmd = new SqlCommand(strInsertCommand, cnn);

			cmd.Connection.Open();
			cmd.Parameters.Add("@title_id", SqlDbType.VarChar, 6);
			cmd.Parameters["@title_id"].Value = tbxAddTitleID.Text;
			cmd.Parameters.Add("@title", SqlDbType.VarChar, 80);
			cmd.Parameters["@title"].Value = tbxAddTitle.Text;
			cmd.Parameters.Add("@price", SqlDbType.Int, 6);
			cmd.Parameters["@price"].Value = tbxAddPrice.Text;
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

			BindGrid();
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;
			BindGrid();
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[3].Controls[0]).Width = Unit.Percentage(100);
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;
			BindGrid();
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;

			string strDeleteCommand = "DELETE FROM smallpubs WHERE title_id=@title_id";
			string target_id = e.Item.Cells[1].Text;

			SqlConnection cnn = new SqlConnection(strDSN);
			SqlCommand cmd = new SqlCommand(strDeleteCommand, cnn);

			cmd.Connection.Open();
			cmd.Parameters.Add("@title_id", SqlDbType.VarChar, 6);
			cmd.Parameters["@title_id"].Value = target_id;
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

			BindGrid();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;

			string strUpdateCommand = "UPDATE smallpubs SET title=@title, price=@price WHERE title_id=@title_id";
			string target_id = e.Item.Cells[1].Text;

			SqlConnection cnn = new SqlConnection(strDSN);
			SqlCommand cmd = new SqlCommand(strUpdateCommand, cnn);

			cmd.Connection.Open();
			cmd.Parameters.Add("@title_id", SqlDbType.VarChar, 6);
			cmd.Parameters["@title_id"].Value = e.Item.Cells[1].Text;
			cmd.Parameters.Add("@title", SqlDbType.VarChar, 80);
			cmd.Parameters["@title"].Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text.Trim();
			cmd.Parameters.Add("@price", SqlDbType.Int, 6);
			cmd.Parameters["@price"].Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text.Trim();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

			BindGrid();
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			tbxAddTitleID.Text = "";
			tbxAddTitle.Text = "";
			tbxAddPrice.Text = "";
		}
	}
}
