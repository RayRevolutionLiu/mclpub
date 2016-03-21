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

namespace d5
{
	/// <summary>
	/// Summary description for mfr.
	/// </summary>
	public class mfr : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox QString;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox mfr_mfrno;
		protected System.Web.UI.WebControls.TextBox mfr_inm;
		protected System.Web.UI.WebControls.TextBox mfr_iaddr;
		protected System.Web.UI.WebControls.TextBox mfr_izip;
		protected System.Web.UI.WebControls.TextBox mfr_respnm;
		protected System.Web.UI.WebControls.TextBox mfr_respjbti;
		protected System.Web.UI.WebControls.TextBox mfr_tel;
		protected System.Web.UI.WebControls.TextBox mfr_fax;
		protected System.Web.UI.WebControls.TextBox mfr_regdate;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public mfr()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
				BindGrid();
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
			string DSN = "Data Source=isccom1;Initial Catalog=MRLPublish;User ID=webuser;Password=db600";
			SqlConnection myConnection = new SqlConnection(DSN);

			string SQL = "select * from mfr";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			if (QString.Text !=null && QString.Text != "")
			{
				dv.RowFilter = "mfr_inm LIKE '%" + QString.Text.Trim() +"%'";
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex=(int)e.Item.ItemIndex;
			BindGrid();

			//Andrew: 設定格式，把TextBox弄得跟Grid的欄位一樣寬
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[1].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[3].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[4].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[5].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[6].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[7].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[8].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[9].Controls[0]).Width = Unit.Percentage(100);
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex=-1;
			BindGrid();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			String strConn="server=isccom1;database=MRLPublish;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter
			("update mfr set mfr_mfrno=@mfr_mfrno,mfr_inm=@mfr_inm,mfr_iaddr=@mfr_iaddr,mfr_izip=@mfr_izip,mfr_respnm=@mfr_respnm,mfr_respjbti=@mfr_respjbti,mfr_tel=@mfr_tel,mfr_fax=@mfr_fax,mfr_regdate=@mfr_regdate where mfr_mfrid=@mfr_mfrid",myConn);
		
			cmd.SelectCommand.Parameters.Add("@mfr_mfrid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;
			cmd.SelectCommand.Parameters.Add("@mfr_mfrno",SqlDbType.Char,10).Value=((TextBox)e.Item.Cells[1].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_inm",SqlDbType.Char,50).Value=((TextBox)e.Item.Cells[2].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_iaddr",SqlDbType.Text,1000).Value=((TextBox)e.Item.Cells[3].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_izip",SqlDbType.Char,5).Value=((TextBox)e.Item.Cells[4].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_respnm",SqlDbType.Char,30).Value=((TextBox)e.Item.Cells[5].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_respjbti",SqlDbType.VarChar,12).Value=((TextBox)e.Item.Cells[6].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_tel",SqlDbType.VarChar,30).Value=((TextBox)e.Item.Cells[7].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_fax",SqlDbType.VarChar,30).Value=((TextBox)e.Item.Cells[8].Controls[0]).Text;
			cmd.SelectCommand.Parameters.Add("@mfr_regdate",SqlDbType.Char,8).Value=((TextBox)e.Item.Cells[9].Controls[0]).Text;
			
			cmd.SelectCommand.Connection.Open();
			cmd.SelectCommand.ExecuteNonQuery();
			DataGrid1.EditItemIndex=-1;
			cmd.SelectCommand.Connection.Close();
		
			BindGrid();
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			String strConn="Data Source=isccom1;database=MRLPublish;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("delete from mfr where mfr_mfrid=@mfr_mfrid",myConn);
		
			cmd.SelectCommand.Parameters.Add("@mfr_mfrid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;
		
			cmd.SelectCommand.Connection.Open();
			cmd.SelectCommand.ExecuteNonQuery();
			cmd.SelectCommand.Connection.Close();
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
		}

		private void Query_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();

		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			String strConn="server=isccom1;database=MRLPublish;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter
			("insert into mfr(mfr_mfrno,mfr_inm,mfr_iaddr,mfr_izip,mfr_respnm,mfr_respjbti,mfr_tel,mfr_fax,mfr_regdate) values(@mfr_mfrno,@mfr_inm,@mfr_iaddr,@mfr_izip,@mfr_respnm,@mfr_respjbti,@mfr_tel,@mfr_fax,@mfr_regdate)",myConn);
		
			//cmd.SelectCommand.Parameters.Add("@mfr_mfrid",SqlDbType.Int,4).Value=mfr_mfrid.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_mfrno",SqlDbType.Char,10).Value=mfr_mfrno.Text.Trim();
			cmd.SelectCommand.Parameters.Add("@mfr_inm",SqlDbType.Char,50).Value=mfr_inm.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_iaddr",SqlDbType.Text,1000).Value=mfr_iaddr.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_izip",SqlDbType.Char,5).Value=mfr_izip.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_respnm",SqlDbType.Char,30).Value=mfr_respnm.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_respjbti",SqlDbType.VarChar,12).Value=mfr_respjbti.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_tel",SqlDbType.VarChar,30).Value=mfr_tel.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_fax",SqlDbType.VarChar,30).Value=mfr_fax.Text;
			cmd.SelectCommand.Parameters.Add("@mfr_regdate",SqlDbType.Char,8).Value=mfr_regdate.Text;
			
			DataSet ds = new DataSet();
			cmd.Fill(ds,"Title");
			
			mfr_mfrno.Text="";
			mfr_inm.Text="";
			mfr_iaddr.Text="";
			mfr_izip.Text="";
			mfr_respnm.Text="";
			mfr_respjbti.Text="";
			mfr_tel.Text="";
			mfr_fax.Text="";
			mfr_regdate.Text="";
			
			BindGrid();
			DataGrid1.CurrentPageIndex=0;
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string aa = "Var0="+DataGrid1.SelectedItem.Cells[0].Text;
			aa += "&Var1='人之'" + DataGrid1.SelectedItem.Cells[5].Text;
		
			Response.Redirect("mfr.aspx?ccc=人之" + aa);
		}
	}
}
