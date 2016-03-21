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
	/// Summary description for AdIRight.
	/// </summary>
	public class AdIRight : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.AdRotator adrH1;
		protected System.Web.UI.WebControls.AdRotator adrH2;
		protected System.Web.UI.WebControls.AdRotator adrH3;
		protected System.Web.UI.WebControls.AdRotator adrH4;
		protected System.Web.UI.WebControls.AdRotator adrW1;
		protected System.Web.UI.WebControls.AdRotator adrW2;
		protected System.Web.UI.WebControls.AdRotator adrW3;
		protected System.Web.UI.WebControls.AdRotator adrW4;
		protected System.Web.UI.WebControls.AdRotator adrW5;
		protected System.Web.UI.WebControls.AdRotator adrW6;
	
		public AdIRight()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{					
				SetAdFile();
				//檢查資料來源			   
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

		private void SetAdFile()
		{
			this.adrH1.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
			this.adrH2.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";
			this.adrH3.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";
			this.adrH4.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";

			this.adrW1.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
			this.adrW2.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
			this.adrW3.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
			this.adrW4.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
			this.adrW5.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
			this.adrW6.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
		}

		//檢驗.xml存不存在，並且判斷此檔案中對於廣告的XML DataIsland是否為空
		private void CheckAdXmlSource()
		{
			if (!System.IO.File.Exists(Server.MapPath(".") + "/" + DateTime.Today.ToString("yyyyMMdd", null) + ".xml"))
			{
				//根本沒有落版檔案時....
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

		//將圖形廣告還原到預設「無廣告安排時該顯現的樣子」
		private void BindDefaultAdXml()
		{
			adrH1.AdvertisementFile = "DefaultAdXml.xml";
			adrH1.KeywordFilter = "Right";
			adrH2.AdvertisementFile = "DefaultAdXml.xml";
			adrH2.KeywordFilter = "Right";
			adrH3.AdvertisementFile = "DefaultAdXml.xml";
			adrH3.KeywordFilter = "Right";
			adrH4.AdvertisementFile = "DefaultAdXml.xml";
			adrH4.KeywordFilter = "Right";

			//文字圖
			adrW1.AdvertisementFile = "DefaultAdXml.xml";
			adrW1.KeywordFilter = "Right";
			adrW2.AdvertisementFile = "DefaultAdXml.xml";
			adrW2.KeywordFilter = "Right";
			adrW3.AdvertisementFile = "DefaultAdXml.xml";
			adrW3.KeywordFilter = "Right";
			adrW4.AdvertisementFile = "DefaultAdXml.xml";
			adrW4.KeywordFilter = "Right";
			adrW5.AdvertisementFile = "DefaultAdXml.xml";
			adrW5.KeywordFilter = "Right";
			adrW6.AdvertisementFile = "DefaultAdXml.xml";
			adrW6.KeywordFilter = "Right";
		}

	}
}
