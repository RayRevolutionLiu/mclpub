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
// SQL
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for njtype_addnew.
	/// </summary>
	public class njtype_addnew : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox njtp_njtpcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox njtp_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		public njtype_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//String strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);

				//起始值為末值加一
				SqlDataAdapter cmd=new SqlDataAdapter("select count(*) as CountNo,max(njtp_njtpcd) as MaxCountNo from c2_njtp",myConn);

				string strAssignedNewCode = "";
				//string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
				DataSet ds = new DataSet();
				cmd.Fill(ds, "c2_njtp");
				DataView dv = ds.Tables["c2_njtp"].DefaultView;

				if (dv.Count > 0 && dv[0]["CountNo"].ToString() != "0")
				{
					if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"])+1)) < 10)
					{
						strAssignedNewCode = Convert.ToString("0"+(Convert.ToInt32(dv[0]["MaxCountNo"])+1));
					}
					else
					{
						strAssignedNewCode = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"])+1));
					}
				}
				else
				{
					strAssignedNewCode += "01";
				}

				njtp_njtpcd.Text = strAssignedNewCode;

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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//String strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c2_njtp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"c2_njtp");

			DataView dv = ds1.Tables["c2_njtp"].DefaultView;
			dv.RowFilter = "njtp_njtpcd = '" + njtp_njtpcd.Text.Trim() +"'";

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into c2_njtp(njtp_njtpcd,njtp_nm) values(@njtp_njtpcd,@njtp_nm)",myConn);

				//cmd.SelectCommand.Parameters.Add("@njtp_njtpid",SqlDbType.Int,4).Value = njtp_njtpid.Text;
				cmd.SelectCommand.Parameters.Add("@njtp_njtpcd",SqlDbType.Char,2).Value = njtp_njtpcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@njtp_nm",SqlDbType.Char,10).Value = njtp_nm.Text.Trim();

				DataSet ds = new DataSet();
				cmd.Fill(ds,"c2_njtp");

				Response.Redirect("njtype.aspx");
			}

		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("njtype.aspx");
		}


	}
}
