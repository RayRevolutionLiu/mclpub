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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for MTopAd.
	/// </summary>
	public class MTopAd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.AdRotator adrTopAd;
	
		public MTopAd()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				SetAdFile();
				//�ˬd��ƨӷ�
				CheckAdXmlSource();
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

		//�ˬd��ƨӷ��O���O�Ū��Τ��s�b
		private void CheckAdXmlSource()
		{
			if (!System.IO.File.Exists(Server.MapPath(".") + "/" + DateTime.Today.ToString("yyyyMMdd", null) + ".xml"))
			{
				//�ڥ��S�������ɮ׮�....
				BindDefaultAdXml();
			}																			   
			else
			{
				DataSet ds = new DataSet();
				ds.ReadXml(Server.MapPath(".") + "/" + DateTime.Today.ToString("yyyyMMdd", null) + ".xml");
				if (ds.Tables.Count < 1)
				{
					//No Tables in DataSet
					BindDefaultAdXml();
				} 
				else if (ds.Tables[0].Rows.Count < 1)
				{
					//No Rows in Table
					BindDefaultAdXml();
				}
			}
		}

		//�s����w�]�u�S���w�Ƽs�i�ɷQ��{���ˤl�v
		private void BindDefaultAdXml()
		{
			adrTopAd.AdvertisementFile = "DefaultAdXml.xml";
			adrTopAd.KeywordFilter = "Top";
		}

		private void SetAdFile()
		{
			this.adrTopAd.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";
		}
	}
}
