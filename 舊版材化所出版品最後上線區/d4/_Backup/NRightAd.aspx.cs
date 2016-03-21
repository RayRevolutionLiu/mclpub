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
	/// Summary description for NRightAd.
	/// </summary>
	public class NRightAd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.AdRotator adrH2;
		protected System.Web.UI.WebControls.AdRotator adrH3;
		protected System.Web.UI.WebControls.AdRotator adrH4;
		protected System.Web.UI.WebControls.AdRotator adrH5;
		protected System.Web.UI.WebControls.HyperLink hylTextAd1;
		protected System.Web.UI.WebControls.HyperLink hylTextAd2;
		protected System.Web.UI.WebControls.HyperLink hylTextAd3;
		protected System.Web.UI.WebControls.HyperLink hylTextAd4;
		protected System.Web.UI.WebControls.HyperLink hylTextAd5;
		protected System.Web.UI.WebControls.HyperLink hylTextAd6;
	
		public NRightAd()
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
				//���J��r�s�i
				LoadTextAd();
			}
//			if (Request.QueryString["AdScope"] != null)
//			{
//				Response.Write("YES");
//			}
//			else
//			{
//				Response.Write("NO");
//			}
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

		//���J��r�s�i
		private void LoadTextAd()
		{	
			string strAdScope = "N";
			//����C�����hŪ��Ʈw�A���˷|�ܺG�A��Application�ܼƥh�x�s�n�F
			//�γ\�i�HŪ�ɮ�...
			if (Application["TextAdData"] == null)
			{
				DataSet TextAdDS = new DataSet();
				TextAdDS.ReadXml(Server.MapPath(".") + "/" + "TextAdXml.xml");
				Application.Add("TextAdData", TextAdDS);
			}
			DataSet ds = (DataSet)Application["TextAdData"];

			if (ds.Tables.Count < 1)
			{
				//Response.Write("ds empty");
				return;
			} 
			else if (ds.Tables[0].Rows.Count < 1)
			{
				//Response.Write("table empty");
				return;
			}

			//Response.Write("there are text ads");
			//�W��r�s�i�F
			DataView dv1 = ds.Tables[0].DefaultView;
			dv1.RowFilter = "Keyword = '" + strAdScope + "W1'";
			if (dv1.Count > 0)	//���b�A�קK�S�W�s�i�հ��u
			{
				int i1 = GetRandomInt(dv1.Count);
				this.hylTextAd1.Text = dv1[i1]["TextAdCont"].ToString();
				this.hylTextAd1.NavigateUrl = dv1[i1]["NavigateUrl"].ToString();
			}

			DataView dv2 = ds.Tables[0].DefaultView;
			dv2.RowFilter = "Keyword = '" + strAdScope + "W2'";
			if (dv2.Count > 0)
			{
				int i2 = GetRandomInt(dv2.Count);
				this.hylTextAd2.Text = dv2[i2]["TextAdCont"].ToString();
				this.hylTextAd2.NavigateUrl = dv2[i2]["NavigateUrl"].ToString();
			}
			
			//W3~W6�Ӱ�
			DataView dv3 = ds.Tables[0].DefaultView;
			dv3.RowFilter = "Keyword = '" + strAdScope + "W3'";
			if (dv3.Count > 0)
			{
				int i3 = GetRandomInt(dv3.Count);
				this.hylTextAd3.Text = dv3[i3]["TextAdCont"].ToString();
				this.hylTextAd3.NavigateUrl = dv3[i3]["NavigateUrl"].ToString();
			}

			DataView dv4 = ds.Tables[0].DefaultView;
			dv4.RowFilter = "Keyword = '" + strAdScope + "W4'";
			if (dv4.Count > 0)
			{
				int i4 = GetRandomInt(dv4.Count);
				this.hylTextAd4.Text = dv4[i4]["TextAdCont"].ToString();
				this.hylTextAd4.NavigateUrl = dv4[i4]["NavigateUrl"].ToString();
			}

			DataView dv5 = ds.Tables[0].DefaultView;
			dv5.RowFilter = "Keyword = '" + strAdScope + "W5'";
			if (dv5.Count > 0)
			{
				int i5 = GetRandomInt(dv5.Count);
				this.hylTextAd5.Text = dv5[i5]["TextAdCont"].ToString();
				this.hylTextAd5.NavigateUrl = dv5[i5]["NavigateUrl"].ToString();
			} 


			DataView dv6 = ds.Tables[0].DefaultView;
			dv6.RowFilter = "Keyword = '" + strAdScope + "W6'";
			if (dv6.Count > 0)
			{
				int i6 = GetRandomInt(dv6.Count);
				this.hylTextAd6.Text = dv6[i6]["TextAdCont"].ToString();
				this.hylTextAd6.NavigateUrl = dv6[i6]["NavigateUrl"].ToString();
			}
		}

		private void SetAdFile()
		{
			this.adrH2.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";
			this.adrH3.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";
			this.adrH4.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";
			this.adrH5.AdvertisementFile = DateTime.Today.ToString("yyyyMMdd", null) + ".xml";	
		}

		//���o��r�s�i��random���v
		private int GetRandomInt(int MaxInt)
		{
			//�γo�ӷ�seed
			Random rd = new Random(System.DateTime.Now.Millisecond);
			//
			return rd.Next(MaxInt);
		}

		//����RightAdXml.xml�s���s�b�A�åB�P�_���ɮפ����s�i��XML DataIsland�O�_����
		private void CheckAdXmlSource()
		{
			//			DataSet ds = new DataSet();
			//			ds.ReadXml(Server.MapPath(".") + "/" + DateTime.Today.ToString("yyyyMMdd", null) + ".xml");
			//			if (ds.Tables.Count < 1)
			//			{
			//				//No Tables in DataSet
			//				BindDefaultAdXml();
			//			} 
			//			else if (ds.Tables[0].Rows.Count < 1)
			//			{
			//				//No Rows in Table
			//				BindDefaultAdXml();
			//			}
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

		//�N�ϧμs�i�٭��w�]�u�L�s�i�w�Ʈɸ���{���ˤl�v
		private void BindDefaultAdXml()
		{
			adrH2.AdvertisementFile = "DefaultAdXml.xml";
			adrH2.KeywordFilter = "Right";
			adrH3.AdvertisementFile = "DefaultAdXml.xml";
			adrH3.KeywordFilter = "Right";
			adrH4.AdvertisementFile = "DefaultAdXml.xml";
			adrH4.KeywordFilter = "Right";
			adrH5.AdvertisementFile = "DefaultAdXml.xml";
			adrH5.KeywordFilter = "Right";
		}
	}
}
