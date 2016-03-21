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

		//	�P�_ Login user �O�_���v���ϥΦ�����, �h srspn table �h���P�_
		void CheckLogin()
		{
			//��Login Domain���u��
			//string loginID = "900103";
			string loginID = User.Identity.Name.Substring(User.Identity.Name.Length-6);

			//�ŧi�qDatabase����u���
			MyComponents.SQLogin MRLogin = new MyComponents.SQLogin(loginID);
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
				//�L�ϥ��v��
				Session.Add("atype", "Z");
				Response.Redirect("../temp.aspx");
			}
			Session.Add("syscode", "5A");	//���ޫ��˳��]�w��5A

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
