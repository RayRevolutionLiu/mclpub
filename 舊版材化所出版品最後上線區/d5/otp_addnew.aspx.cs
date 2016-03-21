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
	/// Summary description for otp_addnew.
	/// </summary>
	public class otp_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.TextBox otp_otp1cd;
		protected System.Web.UI.WebControls.TextBox otp_otp1nm;
		protected System.Web.UI.WebControls.TextBox otp_otp2cd;
		protected System.Web.UI.WebControls.TextBox otp_otp2nm;
		protected System.Web.UI.WebControls.DropDownList ddlotp_otp1cd;
	
		public otp_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				String strConn=System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);
				
				//起始值為末值加一
				string id = ddlotp_otp1cd.SelectedItem.Value.Trim();
				SqlDataAdapter cmd=new SqlDataAdapter("select count(*) as C1,max(otp_otp2cd) as MaxCountNo from c1_otp where otp_otp1cd='" + id + "'",myConn);

				string strAssignedContNo = "";
				DataSet ds = new DataSet();
				cmd.Fill(ds, "title");
				DataView dv = ds.Tables["title"].DefaultView;

				if (dv.Count > 0 && dv[0]["C1"].ToString() != "0")
				{
					if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"])+1)) < 10)
					{
						strAssignedContNo = Convert.ToString("0"+(Convert.ToInt32(dv[0]["MaxCountNo"])+1));
					}
					else
					{
						strAssignedContNo = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"])+1));
					}
				}
				else
				{
					strAssignedContNo += "01"; 
				}

				otp_otp2cd.Text=strAssignedContNo;
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
			this.ddlotp_otp1cd.SelectedIndexChanged += new System.EventHandler(this.ddlotp_otp1cd_SelectedIndexChanged);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			String strConn=System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c1_otp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"Title");

			DataView dv = ds1.Tables["Title"].DefaultView;
			dv.RowFilter = "otp_otp1cd = '" + ddlotp_otp1cd.SelectedItem.Value.Trim() + "' AND otp_otp2cd = '" + otp_otp2cd.Text.Trim() +"'";

			//DataGrid1.DataSource = dv;
			//DataGrid1.DataBind();

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into c1_otp(otp_otp1cd,otp_otp1nm,otp_otp2cd,otp_otp2nm) values(@otp_otp1cd,@otp_otp1nm,@otp_otp2cd,@otp_otp2nm)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@otp_otp1cd",SqlDbType.Char,2).Value=ddlotp_otp1cd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@otp_otp1nm",SqlDbType.Char,8).Value=ddlotp_otp1cd.SelectedItem.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@otp_otp2cd",SqlDbType.Char,2).Value=otp_otp2cd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@otp_otp2nm",SqlDbType.Char,20).Value=otp_otp2nm.Text.Trim();
						
				DataSet ds = new DataSet();
				cmd.Fill(ds,"Title");

				Response.Redirect("otp.aspx?ID=addnew_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("otp.aspx");
		}
		
		private void ddlotp_otp1cd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			String strConn=System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
				
			//起始值為末值加一
			string id = ddlotp_otp1cd.SelectedItem.Value.Trim();
			SqlDataAdapter cmd=new SqlDataAdapter("select count(*) as C1,max(otp_otp2cd) as MaxCountNo from c1_otp where otp_otp1cd='" + id + "'",myConn);

			string strAssignedContNo = "";
			DataSet ds = new DataSet();
			cmd.Fill(ds, "title");
			DataView dv = ds.Tables["title"].DefaultView;

			if (dv.Count > 0 && dv[0]["C1"].ToString() != "0")
			{
				if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"])+1)) < 10)
				{
					strAssignedContNo = Convert.ToString("0"+(Convert.ToInt32(dv[0]["MaxCountNo"])+1));
				}
				else
				{
					strAssignedContNo = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"])+1));
				}
			}
			else
			{
				strAssignedContNo += "01"; 
			}

			otp_otp2cd.Text=strAssignedContNo;	
		}
	}
}
