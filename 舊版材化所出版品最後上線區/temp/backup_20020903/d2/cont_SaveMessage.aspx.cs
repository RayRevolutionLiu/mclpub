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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for cont_SaveMessage.
	/// </summary>
	public class cont_SaveMessage : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlAnchor hplNewCust;
		protected System.Web.UI.HtmlControls.HtmlForm cont_mainSave;
		protected System.Web.UI.HtmlControls.HtmlAnchor hplMainCont;
		protected System.Web.UI.HtmlControls.HtmlAnchor hplAddia;
		protected System.Web.UI.HtmlControls.HtmlAnchor A1;
		protected System.Web.UI.HtmlControls.HtmlAnchor hpladPubMain21;
		protected System.Web.UI.HtmlControls.HtmlAnchor hplNewCont;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		public cont_SaveMessage()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				// 不顯示 hplNewCust (繼續新增客戶的連結), hp2 (進入補書畫面的連結)
				hplNewCust.Visible=false;
				//hp2.Visible=false;
				
				// 依傳過來的功能變數 str, 顯示不同的訊息
				// 新增客戶要求
				if(Context.Request.QueryString["str"]=="newcust")
				{
					lblMessage.Text = "新增客戶資料已完成!";
					hplNewCust.Visible = true;
					hplMainCont.Visible = false;
					hplNewCont.Visible = false;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// 新增合約書要求
				else if(Context.Request.QueryString["str"]=="cont_newSave")
				{
					lblMessage.Text = "新增合約書已完成!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = false;
					hplNewCont.Visible = true;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// 一次付款, 立即做 "開立發票" 動作的要求
				else if(Context.Request.QueryString["str"]=="cont_newSavefg")
				{
					lblMessage.Text = "新增合約書已完成, 此為一次付款, 立即做 '開立發票'動作!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = false;
					hplNewCont.Visible = false;
					hplAddia.Visible = true;
					hpladPubMain21.Visible = false;
				}

				// 維護合約書要求
				else if(Context.Request.QueryString["str"]=="cont_mainSave")
				{
					lblMessage.Text = "維護(修改)合約書已完成!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = true;
					hplNewCont.Visible = true;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// 登錄缺書要求
				else if(Context.Request.QueryString["str"]=="newlost")
				{
					lblMessage.Text = "缺書登錄已完成!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = false;
					hplNewCont.Visible = false;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// 廣告落版資料的維護: 由年月落版進入 步驟二要求
				else if(Context.Request.QueryString["str"]=="adpub_mainSave")
				{
					lblMessage.Text = "廣告落版資料的維護已完成!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = false;
					hplNewCont.Visible = false;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = true;
				}
				

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
