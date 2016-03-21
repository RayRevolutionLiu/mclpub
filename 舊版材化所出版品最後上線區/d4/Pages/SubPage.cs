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
	/// Pop-up出來的子視窗
	/// </summary>
	public class SubPage: System.Web.UI.Page
	{
		#region 初始化設定
		override protected void OnInit(EventArgs e)
		{
			if (!Request.IsAuthenticated)
			{
				//還沒設定正確的權限錯誤Page
				Response.Redirect("AccessDenied.aspx");
			}

			//設定StyleSheet File
			if (!IsClientScriptBlockRegistered("MRLPUBCSS"))
			{
				//因為繼承所以要compile過
				//因為compile過，所以路徑以bin為起點
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

		#region UrlReferer，誰Call我
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
			//照理說應該不可以給set
			set
			{
				ViewState["UrlReferer"] = value;
			}
		}
		#endregion

		#region 以JavaScript Alert一個Message
		/// <summary>
		/// 以JavaScript Alert一個Message
		/// </summary>
		/// <param name="ScriptName">script name，search key</param>
		/// <param name="Messages">要show的message</param>
		protected void jsAlertMsg(string ScriptName, string Messages)
		{
			if (!IsClientScriptBlockRegistered(ScriptName))
			{
				string jsAlertMsg = "<script Language=\"JavaScript\">alert(\"" + Messages + "\");</script>";
				RegisterClientScriptBlock(ScriptName, jsAlertMsg);
			}
		}
		#endregion

		#region 取得ITRI Domain認證過，user的基本資料
		/// <summary>
		/// 取得ITRI Domain認證過，user的基本資料
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
