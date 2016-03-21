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
	/// Summary description for adpgsize_addnew.
	/// </summary>
	public class adpgsize_addnew : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox pgs_pgscd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox pgs_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		public adpgsize_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//string strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);

				//起始值為末值加一
				SqlDataAdapter cmd=new SqlDataAdapter("select count(*) as CountNo,max(pgs_pgscd) as MaxCountNo from c2_pgsize",myConn);

				string strAssignedNewCode = "";
				//string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
				DataSet ds = new DataSet();
				cmd.Fill(ds, "c2_pgsize");
				DataView dv = ds.Tables["c2_pgsize"].DefaultView;

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

				pgs_pgscd.Text = strAssignedNewCode;

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
			//string strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c2_pgsize";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"c2_pgsize");

			DataView dv = ds1.Tables["c2_pgsize"].DefaultView;
			dv.RowFilter = "pgs_pgscd = '" + pgs_pgscd.Text.Trim() +"'";

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into c2_pgsize(pgs_pgscd,pgs_nm) values(@pgs_pgscd,@pgs_nm)",myConn);

				//cmd.SelectCommand.Parameters.Add("@pgs_pgsid",SqlDbType.Int,4).Value = pgs_pgsid.Text;
				cmd.SelectCommand.Parameters.Add("@pgs_pgscd",SqlDbType.Char,2).Value = pgs_pgscd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@pgs_nm",SqlDbType.Char,10).Value = pgs_nm.Text.Trim();

				DataSet ds = new DataSet();
				cmd.Fill(ds,"c2_pgsize");

				Response.Redirect("adpgsize.aspx");
			}

		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adpgsize.aspx");
		}


	}
}
