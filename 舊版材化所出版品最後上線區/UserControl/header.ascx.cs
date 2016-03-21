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
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace mrlpub.UserControl
{
	/// <summary>
	///		header 的摘要描述。
	/// </summary>
	public class header : System.Web.UI.UserControl
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!Page.IsPostBack)
			{
				CheckLogin();
				
				if((Session["RegOK"] != null) || (Session["atype"] != null))
				{
					//取得此網頁的檔名(沒有副檔名)
					string PageName = this.Page.ToString().Substring(4,this.Page.ToString().Length-9).ToLower();
					string type = Session["atype"].ToString();
					
					if(!isAdmin(PageName,type))
					{
						Response.Redirect("/mrlpub/login_error.aspx");
					}
				}
			}
		}

		//	判斷 Login user 是否有權限使用此部份, 去 srspn table 去做判斷
		private bool CheckLogin()
		{
			bool check = false;
			if((Session["RegOK"] != null) || (Session["empid"] != null))
			{
				check = true;
			}
			else
			{
				//抓Login Domain的工號
				string loginID = Page.User.Identity.Name.Substring(Page.User.Identity.Name.LastIndexOf("\\")+1);
				//拿出系統中該員工使用權限
				string strDSN = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				string strSelectCommand = "SELECT * FROM srspn WHERE srspn_empno='"+ loginID +"'";
				SqlConnection cnn=new SqlConnection(strDSN);
				SqlCommand cmd = new SqlCommand(strSelectCommand, cnn);
				cmd.Connection.Open();
				SqlDataReader dr;
				dr = cmd.ExecuteReader();
			
				//權限判定
				if (dr.Read())
				{
					//有權限使用
					Session.Add("RegOK", true);
					Session.Add("empid", loginID);
					Session.Add("cname", dr["srspn_cname"].ToString());
					Session.Add("atype", dr["srspn_atype"].ToString());
					check = true;
				}
				else
				{
					//無使用權限
					Session.Add("atype", "Z");
					//Response.Write(loginID);
					Response.Redirect("/mrlpub/login_error.htm");
				}
				Session.Add("syscode", "5A");	//不管怎麼樣都設定成5A
				dr.Close();
				cnn.Close();
			}
			return check;
		}

		private bool isAdmin(string PageName,string type)
		{
			string XmlDocPath = Server.MapPath("/mrlpub/srspn_manage.xml");
			XmlTextReader xReader=new XmlTextReader(XmlDocPath);
			XmlDocument xDoc=new XmlDocument();
			xDoc.Load(xReader);
			xReader.Close();
			XmlNode node = xDoc.SelectSingleNode("srspan/page[@url='" + PageName + "']/admin[@level='" + type + "']");
			if(node != null)
				return bool.Parse(node.Attributes["value"].Value);
			else
				return true;	
		}

		#region Web Form 設計工具產生的程式碼
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 此為 ASP.NET Web Form 設計工具所需的呼叫。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		此為設計工具支援所必須的方法 - 請勿使用程式碼編輯器修改
		///		這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
