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
				// ����� hplNewCust (�~��s�W�Ȥ᪺�s��), hp2 (�i�J�ɮѵe�����s��)
				hplNewCust.Visible=false;
				//hp2.Visible=false;
				
				// �̶ǹL�Ӫ��\���ܼ� str, ��ܤ��P���T��
				// �s�W�Ȥ�n�D
				if(Context.Request.QueryString["str"]=="newcust")
				{
					lblMessage.Text = "�s�W�Ȥ��Ƥw����!";
					hplNewCust.Visible = true;
					hplMainCont.Visible = false;
					hplNewCont.Visible = false;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// �s�W�X���ѭn�D
				else if(Context.Request.QueryString["str"]=="cont_newSave")
				{
					lblMessage.Text = "�s�W�X���Ѥw����!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = false;
					hplNewCont.Visible = true;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// �@���I��, �ߧY�� "�}�ߵo��" �ʧ@���n�D
				else if(Context.Request.QueryString["str"]=="cont_newSavefg")
				{
					lblMessage.Text = "�s�W�X���Ѥw����, �����@���I��, �ߧY�� '�}�ߵo��'�ʧ@!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = false;
					hplNewCont.Visible = false;
					hplAddia.Visible = true;
					hpladPubMain21.Visible = false;
				}

				// ���@�X���ѭn�D
				else if(Context.Request.QueryString["str"]=="cont_mainSave")
				{
					lblMessage.Text = "���@(�ק�)�X���Ѥw����!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = true;
					hplNewCont.Visible = true;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// �n���ʮѭn�D
				else if(Context.Request.QueryString["str"]=="newlost")
				{
					lblMessage.Text = "�ʮѵn���w����!";
					hplNewCust.Visible = false;
					hplMainCont.Visible = false;
					hplNewCont.Visible = false;
					hplAddia.Visible = false;
					hpladPubMain21.Visible = false;
				}

				// �s�i������ƪ����@: �Ѧ~�븨���i�J �B�J�G�n�D
				else if(Context.Request.QueryString["str"]=="adpub_mainSave")
				{
					lblMessage.Text = "�s�i������ƪ����@�w����!";
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
