using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MRLPub.d4.DataTypes;


namespace MRLPub.d4.Pages
{
	/// <summary>
	/// Pop-up�X�Ӫ��l����
	/// </summary>
	public class SubPage: System.Web.UI.Page
	{
		#region ��l�Ƴ]�w
		override protected void OnInit(EventArgs e)
		{
			if (!Request.IsAuthenticated)
			{
				//�٨S�]�w���T���v�����~Page
				Response.Redirect("AccessDenied.aspx");
			}

			//�]�wStyleSheet File
			if (!IsClientScriptBlockRegistered("MRLPUBCSS"))
			{
				//�]���~�өҥH�ncompile�L
				//�]��compile�L�A�ҥH���|�Hbin���_�I
				RegisterClientScriptBlock("MRLPUBCSS",
					"<link href=\"../mrlpub.css\" type=\"text/css\" rel=\"stylesheet\" />");
			}

			base.OnInit(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.UrlReferrer != null)
				{
					UrlReferer = Request.UrlReferrer.ToString();
				}
			}

			base.OnLoad(e);
		}
		#endregion

		#region UrlReferer�A��Call��
		/// <summary>
		/// referring url
		/// </summary>
		protected string UrlReferer
		{
			get
			{
				if (ViewState["UrlReferer"] != null)
					return (string)ViewState["UrlReferer"];
				else
					return Request.ApplicationPath + "/Default.aspx";
			}
			//�Ӳz�����Ӥ��i�H��set
			set
			{
				ViewState["UrlReferer"] = value;
			}
		}
		#endregion

		#region �HJavaScript Alert�@��Message
		/// <summary>
		/// �HJavaScript Alert�@��Message
		/// </summary>
		/// <param name="ScriptName">script name�Asearch key</param>
		/// <param name="Messages">�nshow��message</param>
		protected void jsAlertMsg(string ScriptName, string Messages)
		{
			if (!IsClientScriptBlockRegistered(ScriptName))
			{
				string jsAlertMsg = "<script Language=\"JavaScript\">alert(\"" + Messages + "\");</script>";
				RegisterClientScriptBlock(ScriptName, jsAlertMsg);
			}
		}
		#endregion

		#region ���oITRI Domain�{�ҹL�Auser���򥻸��
		/// <summary>
		/// ���oITRI Domain�{�ҹL�Auser���򥻸��
		/// </summary>
		protected ItriUser WhoAmI
		{
			get
			{
				if (Session["WHOAMI"] == null)
				{
					string DomainUser = User.Identity.Name;
					ItriUser whoami = new ItriUser(DomainUser.Substring(DomainUser.LastIndexOf("\\")+1));
					Session.Add("WHOAMI", whoami);
				}

				return (ItriUser)Session["WHOAMI"];
			}
		}
		#endregion
	}
}
