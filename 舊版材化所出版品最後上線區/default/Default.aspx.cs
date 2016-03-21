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
using MyComponents;
using System.Data.OleDb;
using System.Configuration;


namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for CDefault.
	/// </summary>
	public class CDefault : System.Web.UI.Page
	{
		public CDefault()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack) {
				CheckLogin();
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		//	判斷 Login user 是否有權限使用此部份, 去 srspn table 去做判斷
		void CheckLogin()
		{
			//抓Login Domain的工號
			//string loginID = "900103";
			string loginID = User.Identity.Name.Substring(User.Identity.Name.Length-6);

			//宣告從Database抓員工資料
			MyComponents.SQLogin MRLogin = new MyComponents.SQLogin(loginID);
			MRLogin.MLogin("5A", "sqlnts2");

			if (!MRLogin.SysExist)
			{
				//系統不存在，所以ooxx
			}

			//將員工資料是否存在於comper table存入Session變數
			Session.Add("RegOK", MRLogin.EmpNoIsValid);

			//如果不存在，就導向到login error的Page
			if (!(bool)Session["RegOK"])
			{
				Response.Redirect("/kfapp/mrlpub/login/login_error.asp");
			}

			//將變數存入Session中
			Session.Add("start", DateTime.Now.ToString());
			Session.Add("empid", MRLogin.EmpNo);
			Session.Add("orgcd", MRLogin.OrgCd);
			Session.Add("deptcd", MRLogin.DeptCd);
			Session.Add("cname", MRLogin.CName);
			//Response.Write(Session["empid"].ToString()+":"+Session["cname"].ToString());

			//拿出系統中該員工使用權限
			string strDSN = System.Configuration.ConfigurationSettings.AppSettings["mrlpub"].ToString();
			string strSelectCommand = "SELECT * FROM srspn WHERE srspn_empno='"+ Session["empid"].ToString() +"'";
			OleDbConnection cnn = new OleDbConnection(strDSN);
			OleDbCommand cmd = new OleDbCommand(strSelectCommand, cnn);
			cmd.Connection.Open();
			OleDbDataReader dr;
			dr = cmd.ExecuteReader();

			//權限判定
			if (dr.Read())
			{
				//有權限使用
				Session.Add("atype", dr["srspn_atype"].ToString());
			}
			else
			{
				//無使用權限
				Session.Add("atype", "Z");
				Response.Redirect("../temp.aspx");
			}
			Session.Add("syscode", "5A");	//不管怎麼樣都設定成5A

			MRLogin = null;
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
