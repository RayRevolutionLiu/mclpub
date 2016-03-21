using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebProject1
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox FName;
		protected System.Web.UI.WebControls.TextBox LName;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox QString;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.DropDownList Team;
		protected System.Web.UI.WebControls.DropDownList Search1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public WebForm1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			BindGrid();
		}

		private void BindGrid()
		{
			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料

			string DSN = "server=isccom1;database=890691;uid=webuser;pwd=db600";
			SqlConnection myConnection = new SqlConnection(DSN);

			string SQL = "select * from Player";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			if (QString.Text !=null && QString.Text != "")
			{
				dv.RowFilter = Search1.SelectedItem.Value + " LIKE '%" + QString.Text +"%'";
			}

			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
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
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void DataGrid1_HeaderStyle_Disposed(object sender, System.EventArgs e)
		{

		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			try 
			{
				String strConn="server=isccom1;database=890691;uid=webuser;pwd=db600";
				SqlConnection myConn=new SqlConnection(strConn);
				SqlDataAdapter cmd=new SqlDataAdapter
					("insert into Player(FName,LName,Team) values(@FName,@LName,@Team)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@FName",SqlDbType.VarChar,15).Value=FName.Text;
		
				cmd.SelectCommand.Parameters.Add(new SqlParameter("@LName",SqlDbType.VarChar,15));
				cmd.SelectCommand.Parameters["@LName"].Value=LName.Text;

				cmd.SelectCommand.Parameters.Add(new SqlParameter("@Team",SqlDbType.VarChar,10));
				cmd.SelectCommand.Parameters["@Team"].Value=Team.SelectedItem.Text;

				DataSet ds = new DataSet();
				cmd.Fill(ds,"Title");
				Label1.Style["color"]="blue";
				Label1.Text="資料新增成功...";
				//cmd.SelectCommand.Connection.Close();
		
				FName.Text="";
				LName.Text="";
				//Team.SelectedItem.Text=Team.SelectedItem.Selected;

				BindGrid();
				DataGrid1.CurrentPageIndex=0;
			} 
			catch (SqlException E) 
			{
				Label1.Style["color"]="brown";
				Label1.Text="資料新增失敗...";
			}
		}

		void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try 
			{
				String strConn="server=isccom1;database=890691;uid=webuser;pwd=db600";
				SqlConnection myConn=new SqlConnection(strConn);
				SqlDataAdapter cmd=new SqlDataAdapter("delete from Player where ID=@ID1",myConn);
		
				cmd.SelectCommand.Parameters.Add("@ID1",SqlDbType.Int,4).Value=DataGrid1.DataKeys[e.Item.ItemIndex];
		
				cmd.SelectCommand.Connection.Open();
				cmd.SelectCommand.ExecuteNonQuery();
				Label1.Style["color"]="green";
				Label1.Text="資料刪除成功...";
				cmd.SelectCommand.Connection.Close();
				DataGrid1.CurrentPageIndex=0;
				BindGrid();

				//String strConn="server=localhost;database=890691;uid=sa;pwd=";
				//SqlConnection myConn=new SqlConnection(strConn);
				//SqlCommand cmd = new SqlCommand("delete from Player where ID=@ID1",myConn);
				//SqlDataAdapter da = new SqlDataAdapter();
				//da.SelectCommand = new SqlCommand("select * from Player order by LName", myConn);
				//da.DeleteCommand = new SqlCommand("delete from Player where ID=@ID1",myConn);
				//SqlCommandBuilder cb = new SqlCommandBuilder(da);

				//Response.Write(cb.GetDeleteCommand().CommandText);
				//SqlDataAdapter cmd=new SqlDataAdapter("delete from Player where ID=@ID1",myConn);
						
				//cmd.SelectCommand.Parameters.Add("@ID1",SqlDbType.VarChar,10);
				//cmd.DeleteCommand.Parameters[0].Value=DataGrid1.DataKeys[e.Item.ItemIndex];
		
				//cmd.SelectCommand.Connection.Open();
				//cmd.DeleteCommand.ExecuteNonQuery();
				//Label1.Style["color"]="green";
				//Label1.Text="資料刪除成功...";
				//cmd.SelectCommand.Connection.Close();
				//DataGrid1.CurrentPageIndex=0;
				//BindGrid();


		
			} 
			catch (SqlException E) 
			{
				Response.Write("e.ToString()");
			}
		}

		private void Query_Click(object sender, System.EventArgs e)
		{
			//DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;

			String strConn="server=isccom1;database=890691;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			
			if (Search1.SelectedItem.Value=="LName")
			{
				SqlDataAdapter cmd=new SqlDataAdapter("select * from Player where LName like '%"+QString.Text.Trim()+"%'",myConn);
				DataSet myDS=new DataSet();
				cmd.Fill(myDS,"Title");
				DataGrid1.DataSource=myDS.Tables["Title"];
			}
			if (Search1.SelectedItem.Value=="Team")
			{
				SqlDataAdapter cmd=new SqlDataAdapter("select * from Player where Team like '%"+QString.Text.Trim()+"%'",myConn);
				DataSet myDS=new DataSet();
				cmd.Fill(myDS,"Title");
				DataGrid1.DataSource=myDS.Tables["Title"];
			}
	
			DataGrid1.DataBind();	
		
			DataGrid1.CurrentPageIndex=0;
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=(int)e.Item.ItemIndex;
			Label1.Style["color"]="ff6600";
			Label1.Text="進入修改模式...";
			//Response.Write(((Label)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[1]).Text);
			string team = ((Label)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[1]).Text;
			BindGrid();
		
			//Andrew: 設定格式，把TextBox弄得跟Grid的欄位一樣寬
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[0].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[1].Controls[0]).Width = Unit.Percentage(100);
			for(int i=0; i<30; i++)
			{
				//Response.Write(((DropDownList)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[1]).Items[i].Text);
				//Response.Write(team);
				if (((DropDownList)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[1]).Items[i].Text.Trim() == team.Trim())
				{
					((DropDownList)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[1]).SelectedIndex = i;
					break;
				}
			}
			//((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[2].Controls[0]).Width = Unit.Percentage(100);
			//((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[3].Controls[0]).Width = Unit.Percentage(100);
			//((TextBox)DataGrid1.Items[e.Item.ItemIndex].Cells[4].Controls[0]).Width = Unit.Percentage(100);
			//((TextBox)dg1.Items[E.Item.ItemIndex].Cells[6].Controls[0]).Width = Unit.Percentage(100);
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex=-1;
			Label1.Style["color"]="ff6600";
			Label1.Text="進入瀏覽模式...";
			BindGrid();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try 
			{
				String strConn="server=isccom1;database=890691;uid=webuser;pwd=db600";
				SqlConnection myConn=new SqlConnection(strConn);
				SqlDataAdapter cmd=new SqlDataAdapter
					("update Player set FName=@FName,LName=@LName,Team=@Team where ID=@ID1",myConn);
		
				cmd.SelectCommand.Parameters.Add("@ID1",SqlDbType.Int,4).Value=DataGrid1.DataKeys[e.Item.ItemIndex];
				
				cmd.SelectCommand.Parameters.Add("@FName",SqlDbType.VarChar,15).Value=((TextBox)e.Item.Cells[0].Controls[0]).Text;
		
				cmd.SelectCommand.Parameters.Add(new SqlParameter("@LName",SqlDbType.VarChar,15));
				cmd.SelectCommand.Parameters["@LName"].Value=((TextBox)e.Item.Cells[1].Controls[0]).Text;

				cmd.SelectCommand.Parameters.Add(new SqlParameter("@Team",SqlDbType.VarChar,10));
				cmd.SelectCommand.Parameters["@Team"].Value=((DropDownList)e.Item.Cells[2].Controls[1]).SelectedItem.Value;

				cmd.SelectCommand.Connection.Open();
				cmd.SelectCommand.ExecuteNonQuery();
				DataGrid1.EditItemIndex=-1;
				Label1.Style["color"]="blue";
				Label1.Text="資料修改成功...";
				cmd.SelectCommand.Connection.Close();
		
				BindGrid();
				//DataGrid1.CurrentPageIndex=0;
			} 
			catch (SqlException E) 
			{
				Label1.Style["color"]="brown";
				Label1.Text="資料修改失敗...";
			}
		}
	}
}
