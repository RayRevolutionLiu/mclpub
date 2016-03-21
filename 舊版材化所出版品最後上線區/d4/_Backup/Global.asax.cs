using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;

namespace MRLPub.d4 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		private DateTime apStartTime;
		private DateTime xmlUpdateTime;

		protected void Application_Start(Object sender, EventArgs e)
		{
			//apStartTime = System.DateTime.Now;
			//xmlUpdateTime = apStartTime;

			//
			//�����ͤ@�����
			//
			//this.GenRightAdXml();
			//this.GenTextAdXml();
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
//			DateTime ssStartTime = System.DateTime.Now;
//
//			if (ssStartTime.Subtract(xmlUpdateTime).Ticks > TimeSpan.TicksPerDay)
//			{
//				//
//				//�H�U�o�q�ΨӲ���RightAdXml.xml 
//				//
//				this.GenRightAdXml();
//
//				//
//				//�H�U�o�q�ΨӲ���TextAdXml.xml
//				//
//				this.GenTextAdXml();
//
//				//���m
//				xmlUpdateTime = System.DateTime.Now;
//			}
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

		private void GenRightAdXml()
		{
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=MRLPub";
			string strSelectSource = "SELECT adr_imgurl AS ImageUrl, adr_navurl AS NavigateUrl, adr_alttext AS AlternateText, adr_adcate+adr_keyword AS Keyword, adr_impr AS Impression FROM c4_adr";
			//�o�ӬO�򥻱���A��r�s�i����select�i��
			//string strSelectFilter = "adr_keyword<'W1' AND adr_date='" + System.DateTime.Today.ToString("yyyyMMdd") + "'";

			//version 2�G���Ʃҭn�D���Ȯɥ�by month�A�H�K�L�̪��~�Ȳ֦�
			string strSelectFilter = "adr_keyword<'W1' AND substring(adr_date,1,6)='" + System.DateTime.Today.ToString("yyyyMM") + "'";

			string strSelectCommand = strSelectSource + " WHERE " + strSelectFilter;
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("Advertisements");
			da.Fill(ds, "Ad");

			//�@�w�n�[�WServer.MapPath(".")����A�n���M��m�N����F
			ds.WriteXml(Server.MapPath(".") + "/" + "RightAdXml.xml");
		}

		private void GenTextAdXml()
		{
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=mrlpub";
			string strSelectSource = "SELECT adr_txtadcont AS TextAdCont, adr_navurl AS NavigateUrl, adr_keyword AS Keyword, adr_impr AS Impression FROM c4_adr";

//			string strSelectFilter = "adr_keyword>'H5' AND adr_date='" + System.DateTime.Today.ToString("yyyyMMdd") + "'";
			
			//version 2�G���Ʃҭn�D���Ȯɥ�by month�A�H�K�L�̪��~�Ȳ֦�
			string strSelectFilter = "adr_keyword>'H5' AND substring(adr_date,1,6)='" + System.DateTime.Today.ToString("yyyyMM") + "'";

			string strSelectCommand = strSelectSource + " WHERE " + strSelectFilter;
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("TextAdvertisements");
			da.Fill(ds, "TextAd");
			ds.WriteXml(Server.MapPath(".") + "/" + "TextAdXml.xml");
		}
	}
}

