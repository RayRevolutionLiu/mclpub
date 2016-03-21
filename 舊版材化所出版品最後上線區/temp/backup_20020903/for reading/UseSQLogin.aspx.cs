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
using System.Data.OleDb;

namespace MyComponents
{
	/// <summary>
	/// Summary description for UseSQLogin.
	/// </summary>
	public class UseSQLogin : System.Web.UI.Page
	{
		public UseSQLogin()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				CheckLogin();
				Response.Write(Session["start"].ToString()+"<br>");
				Response.Write(Session["RegOK"].ToString()+"<br>");
				Response.Write(Session["empid"].ToString()+"<br>");
				Response.Write(Session["cname"].ToString()+"<br>");
				Response.Write(Session["orgcd"].ToString()+"<br>");
				Response.Write(Session["deptcd"].ToString()+"<br>");
				Response.Write(Session["syscode"].ToString()+"<br>");
				Response.Write(Session["atype"].ToString()+"<br>");
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

		private void CheckLogin()
		{
			//��Login Domain���u��
			string loginID = "900103";
			//string loginID = User.Identity.Name.Substring(User.Identity.Name.Length-6);

			//�ŧi�qDatabase����u���
			SQLogin MRLogin = new SQLogin(loginID);
			MRLogin.MLogin("5A", "sqlnts2");

			if (!MRLogin.SysExist)
			{
				//�t�Τ��s�b�A�ҥHooxx
			}

			//�N���u��ƬO�_�s�b��comper table�s�JSession�ܼ�
			Session.Add("RegOK", MRLogin.EmpNoIsValid);

			//�p�G���s�b�A�N�ɦV��login error��Page
			if (!(bool)Session["RegOK"])
			{
				Response.Redirect("/kfapp/mrlpub/login/login_error.asp");
			}

			//�N�ܼƦs�JSession��
			Session.Add("start", DateTime.Now.ToString());
			Session.Add("empid", MRLogin.EmpNo);
			Session.Add("orgcd", MRLogin.OrgCd);
			Session.Add("deptcd", MRLogin.DeptCd);
			Session.Add("cname", MRLogin.CName);
			//Response.Write(Session["empid"].ToString()+":"+Session["cname"].ToString());

			//���X�t�Τ��ӭ��u�ϥ��v��
			string strDSN = System.Configuration.ConfigurationSettings.AppSettings["mrlpub"].ToString();
			string strSelectCommand = "SELECT * FROM srspn WHERE srspn_empno='"+ Session["empid"].ToString() +"'";
			OleDbConnection cnn = new OleDbConnection(strDSN);
			OleDbCommand cmd = new OleDbCommand(strSelectCommand, cnn);
			cmd.Connection.Open();
			OleDbDataReader dr;
			dr = cmd.ExecuteReader();

			//�v���P�w
			if (dr.Read())
			{
				//���v���ϥ�
				Session.Add("atype", dr["srspn_atype"].ToString());
			}
			else
			{
				//�L�ϥ��v��, �]���v���N�X Z
				Session.Add("atype", "Z");
			}
			Session.Add("syscode", "5A");	//���ޫ��˳��]�w��5A

			MRLogin = null;
		}
	}
}
