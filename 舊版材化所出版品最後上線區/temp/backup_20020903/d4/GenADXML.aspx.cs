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
using System.Data.SqlClient;
using System.Xml;

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for GenADXML.
	/// </summary>
	public class GenADXML : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxXML;
		protected System.Web.UI.WebControls.Button btnTextAd;
		protected System.Web.UI.WebControls.Button btnGenXML;
	
		public GenADXML()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnGenXML.Click += new System.EventHandler(this.btnGenXML_Click);
			this.btnTextAd.Click += new System.EventHandler(this.btnTextAd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnGenXML_Click(object sender, System.EventArgs e)
		{
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=MRLPub";
			string strSelectSource = "SELECT adr_imgurl AS ImageUrl, adr_navurl AS NavigateUrl, adr_alttext AS AlternateText, adr_adcate+adr_keyword AS Keyword, adr_impr AS Impression FROM c4_adr";
			//�o�ӬO�򥻱���A��r�s�i����select�i��

			//version 1�G��l��WHERE����]�w��k
			//�ھ�adr_date�o���欰�D�X�C�@�ѸӦ���ad
			//string strSelectFilter = "adr_keyword<'W1' AND adr_date='" + System.DateTime.Today.ToString("yyyyMMdd") + "'";

			//version 2�G���Ʃҭn�D���Ȯɥ�by month�A�H�K�L�̪��~�Ȳ֦�
			string strSelectFilter = "adr_keyword<'W1' AND substring(adr_date,1,6)='" + System.DateTime.Today.ToString("yyyyMM") + "'";

			string strSelectCommand = strSelectSource + " WHERE " + strSelectFilter;
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("Advertisements");
			da.Fill(ds, "Ad");
			tbxXML.Text = ds.GetXml();
			//
			//�@�w�n�[�WServer.MapPath(".")����A�n���M��m�N����F
			ds.WriteXml(Server.MapPath(".") + "/" + "RightAdXml.xml");
		}

		private void btnTextAd_Click(object sender, System.EventArgs e)
		{
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=MRLPub";
			string strSelectSource = "SELECT adr_txtadcont AS TextAdCont, adr_navurl AS NavigateUrl, adr_adcate+adr_keyword AS Keyword, adr_impr AS Impression FROM c4_adr";

			//version 1�G��l��WHERE����]�w��k
			//�ھ�adr_date�o���欰�D�X�C�@�ѸӦ���ad
			//string strSelectFilter = "adr_keyword>'H5' AND adr_date='" + System.DateTime.Today.ToString("yyyyMMdd") + "'";

			//version 2�G���Ʃҭn�D���Ȯɥ�by month�A�H�K�L�̪��~�Ȳ֦�
			string strSelectFilter = "adr_keyword>'H5' AND substring(adr_date,1,6)='" + System.DateTime.Today.ToString("yyyyMM") + "'";

			string strSelectCommand = strSelectSource + " WHERE " + strSelectFilter;
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("TextAdvertisements");
			da.Fill(ds, "TextAd");
			tbxXML.Text = ds.GetXml();
			ds.WriteXml(Server.MapPath(".") + "/" + "TextAdXml.xml");

			//Update Application Varible: TextAdData
			if (Application["TextAdData"] == null)
			{
				Application.Add("TextAdData", ds);
			}
			else
			{
				Application.Set("TextAdData", ds);
			}
		}

		private string GetScopeStr()
		{
			string retstr = "M";
			if (Request.QueryString["AdScope"] !=null)
			{
				//����QueryString�ӨM�wKeyword�n���ͦ�...	
				switch(Request.QueryString["AdScope"])
				{
					case "Main":
						retstr = "M";
						break;
					case "Inner":
						retstr = "I";
						break;
					case "Nano":
						retstr = "N";
						break;
				}
			} 
			else
			{
				//�w�]�ȩ�b����
				retstr = "M";
			}

			//Default �Ǧ^M�A�]�N�O���b�D�����W
			return retstr;
		}
	}
}
