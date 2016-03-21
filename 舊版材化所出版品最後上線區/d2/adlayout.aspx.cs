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
	/// Summary description for adlayout.
	/// </summary>
	public class adlayout : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
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
			//Kevin: �z�L SqlDataAdapter �q��Ʈw��Ū�����
			//string DSN = "Data Source=isccom2;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
			//SqlConnection myConnection = new SqlConnection(DSN);
			//string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			string SQL = "select * from c2_ltp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;

			lblResult.Text = "";
			lblNum.Text = dv.Count.ToString();

			// �ˬd�� �s�W�έק�^�Ӯ�, �������T�{�T��
			if (Request.QueryString["ID"] != null)
			{
				string id = Request.QueryString["action"].ToString();
				if (id == "addnew_ok")
				{
					lblState.Text = " ... ��Ʒs�W���\ !";
				}
				if (id == "edit_ok")
				{
					lblState.Text = " ... ��ƭק令�\ !";
				}
			}


			if (tbxQString.Text !=null && tbxQString.Text != "")
			{
				dv.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() +"%'";
				lblResult.Text = "�j�M���G...";
				lblNum.Text = dv.Count.ToString();
				lblState.Text = "";
			}

			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
		}


		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// �ˬd��ƶ��O�_�w�Q�ϥ�, �Y�O, �N�����\�R��
			DataGrid1.SelectedIndex=e.Item.ItemIndex;

			// ��X �s�i������줧��
			string strltpcd = e.Item.Cells[1].Text.ToString();
			//Response.Write("strltpcd= "+ strltpcd + "<BR>");

			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �z����
			this.sqlSelectCommand1.Parameters["@ltpcd"].Value = strltpcd;


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr1 = "1=1";
			dv1.RowFilter = rowfilterstr1;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv1.Count > 0)
			{
				int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());
				//Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

				if (intPubCounts > 0)
				{
					// �H Javascript �� window.close() �ӧi���T��
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"�R���L�ġG������Ƥw�Q�ϥ�, �N�����\�R���I\");</script>";
					Page.Controls.Add(litAlert1);
				}
			}
			// �i��R��
			else
			{
				//string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);
				SqlDataAdapter cmd=new SqlDataAdapter("delete from c2_ltp where ltp_ltpid=@ltp_ltpid",myConn);

				cmd.SelectCommand.Parameters.Add("@ltp_ltpid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;

				cmd.SelectCommand.Connection.Open();
				cmd.SelectCommand.ExecuteNonQuery();
				cmd.SelectCommand.Connection.Close();
				DataGrid1.CurrentPageIndex=0;
				BindGrid();

				lblState.Text = " ... ��ƧR�����\ !";
			}
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
			Response.Redirect("../default.aspx");
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("PubCounts", "PubCounts"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_ltp.ltp_ltpcd, dbo.c2_ltp.ltp_nm FROM dbo.c2_ltp INNER JOIN dbo.c2_pub ON dbo.c2_ltp.ltp_ltpcd = dbo.c2_pub.pub_ltpcd WHERE (dbo.c2_ltp.ltp_ltpcd = @ltpcd) GROUP BY dbo.c2_ltp.ltp_ltpcd, dbo.c2_ltp.ltp_nm";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ltpcd", System.Data.SqlDbType.VarChar, 2, "ltp_ltpcd"));
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
