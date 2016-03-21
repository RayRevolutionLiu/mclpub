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
	///		header ���K�n�y�z�C
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
					//���o���������ɦW(�S�����ɦW)
					string PageName = this.Page.ToString().Substring(4,this.Page.ToString().Length-9).ToLower();
					string type = Session["atype"].ToString();
					
					if(!isAdmin(PageName,type))
					{
						Response.Redirect("/mrlpub/login_error.aspx");
					}
				}
			}
		}

		//	�P�_ Login user �O�_���v���ϥΦ�����, �h srspn table �h���P�_
		private bool CheckLogin()
		{
			bool check = false;
			if((Session["RegOK"] != null) || (Session["empid"] != null))
			{
				check = true;
			}
			else
			{
				//��Login Domain���u��
				string loginID = Page.User.Identity.Name.Substring(Page.User.Identity.Name.LastIndexOf("\\")+1);
				//���X�t�Τ��ӭ��u�ϥ��v��
				string strDSN = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				string strSelectCommand = "SELECT * FROM srspn WHERE srspn_empno='"+ loginID +"'";
				SqlConnection cnn=new SqlConnection(strDSN);
				SqlCommand cmd = new SqlCommand(strSelectCommand, cnn);
				cmd.Connection.Open();
				SqlDataReader dr;
				dr = cmd.ExecuteReader();
			
				//�v���P�w
				if (dr.Read())
				{
					//���v���ϥ�
					Session.Add("RegOK", true);
					Session.Add("empid", loginID);
					Session.Add("cname", dr["srspn_cname"].ToString());
					Session.Add("atype", dr["srspn_atype"].ToString());
					check = true;
				}
				else
				{
					//�L�ϥ��v��
					Session.Add("atype", "Z");
					//Response.Write(loginID);
					Response.Redirect("/mrlpub/login_error.htm");
				}
				Session.Add("syscode", "5A");	//���ޫ��˳��]�w��5A
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

		#region Web Form �]�p�u�㲣�ͪ��{���X
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: ���� ASP.NET Web Form �]�p�u��һݪ��I�s�C
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		�����]�p�u��䴩�ҥ�������k - �ФŨϥε{���X�s�边�ק�
		///		�o�Ӥ�k�����e�C
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
