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
//using MyComponents;
using System.Web.Security;
using System.Data.OleDb;
using System.Configuration;

namespace d5
{
	/// <summary>
	/// Summary description for SQLLogin.
	/// </summary>
	public class SQLLogin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
	
		public SQLLogin()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
									
				//Session.Add("ID2", "22");
				//Response.Write(Session["ID2"].ToString());
				//string loginID = Session["ID2"].ToString();
				//if (Request.QueryString["id"] == null) 
				//{
					//Message.Text="�䤣�즹�ϥΪ̱b��["+loginID+"],�Э��s��J";
				//	Label1.Text = "�ܩ�p,�z�èS���v���ϥΥ��t��,�Цb�����������᭫�s�n��!!";
				//	return;
				//}
				//string loginID = Request.QueryString["id"].ToString();
				//string loginID = Context.User.Identity.Name;
				string loginID = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
				//string loginID = "890691";
				
				//�N�ܼƦs�JSession��
				//Session.Add("start", DateTime.Now.ToString());
				//Session.Add("empid", MRLogin.EmpNo);
				//Session.Add("orgcd", MRLogin.OrgCd);
				//Session.Add("deptcd", MRLogin.DeptCd);
				//Session.Add("cname", MRLogin.CName);
				//Session.Timeout = 540;
				//Response.Write(Session["empid"].ToString()+":"+Session["cname"].ToString());
				
				Label1.Text = loginID+"???";
				//Response.Write(loginID);
				//string DSN = "Data Source=isccom1;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
				//SqlConnection myConnection = new SqlConnection(DSN);
				//SqlDataAdapter cmd = new SqlDataAdapter("select * from srspn where srspn_empno="+loginID+"", myConnection);
				//DataSet myDS = new DataSet();
				//cmd.Fill(myDS, "Use");
				

				//if (0==myDS.Tables["Use"].Rows.Count) 
				//{
					//Message.Text="�䤣�즹�ϥΪ̱b��["+loginID+"],�Э��s��J";
					//Label1.Text = "�ܩ�p,�z�èS���v���ϥΥ��t��,�Цb�����������᭫�s�n��!!";
					//return;
				//}
				
				//DataView dv = myDS.Tables["Use"].DefaultView;						
				//Response.Write(dv[0]["srspn_cname"].ToString());
				//Session.Add("cname", dv[0]["srspn_cname"].ToString());
				//Response.Write(Session["cname"].ToString());
				
				// Create a ticket
				//FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(loginID, false,1800);
				//FormsAuthentication.RedirectFromLoginPage(loginID,false);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
