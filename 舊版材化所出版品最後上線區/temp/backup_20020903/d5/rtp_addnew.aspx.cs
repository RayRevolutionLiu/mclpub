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
	/// Summary description for book_addnew.
	/// </summary>
	public class rtp_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.TextBox bk_nm;
		protected System.Web.UI.WebControls.TextBox bk_bkcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox bkp_date;
		protected System.Web.UI.WebControls.TextBox bkp_pno;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox rtp_rtpcd;
		protected System.Web.UI.WebControls.TextBox rtp_nm;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.DropDownList ddlbkp_bkcd;
	
		public rtp_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);
				
				//起始值為末值加一
				SqlDataAdapter cmd=new SqlDataAdapter("select count(*) as C1,max(rtp_rtpcd) as MaxCountNo from rtp",myConn);

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

				rtp_rtpcd.Text=strAssignedContNo;
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
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from rtp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"Title");

			DataView dv = ds1.Tables["Title"].DefaultView;
			dv.RowFilter = "rtp_rtpcd = '" + rtp_rtpcd.Text.Trim() + "'";

			//DataGrid1.DataSource = dv;
			//DataGrid1.DataBind();

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into rtp(rtp_rtpcd,rtp_nm) values(@rtp_rtpcd,@rtp_nm)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@rtp_rtpcd",SqlDbType.Char,2).Value=rtp_rtpcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@rtp_nm",SqlDbType.Char,12).Value=rtp_nm.Text.Trim();
						
				DataSet ds = new DataSet();
				cmd.Fill(ds,"Title");

				Response.Redirect("rtp.aspx?ID=addnew_ok");
			}
			
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("rtp.aspx");
		}

	}
}
