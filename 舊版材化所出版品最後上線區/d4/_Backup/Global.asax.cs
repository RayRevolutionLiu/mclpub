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
			//先產生一次資料
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
//				//以下這段用來產生RightAdXml.xml 
//				//
//				this.GenRightAdXml();
//
//				//
//				//以下這段用來產生TextAdXml.xml
//				//
//				this.GenTextAdXml();
//
//				//重置
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
			//這個是基本條件，文字廣告不用select進來
			//string strSelectFilter = "adr_keyword<'W1' AND adr_date='" + System.DateTime.Today.ToString("yyyyMMdd") + "'";

			//version 2：材料所要求先暫時用by month，以免他們的業務累死
			string strSelectFilter = "adr_keyword<'W1' AND substring(adr_date,1,6)='" + System.DateTime.Today.ToString("yyyyMM") + "'";

			string strSelectCommand = strSelectSource + " WHERE " + strSelectFilter;
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("Advertisements");
			da.Fill(ds, "Ad");

			//一定要加上Server.MapPath(".")那鍋，要不然位置就不對了
			ds.WriteXml(Server.MapPath(".") + "/" + "RightAdXml.xml");
		}

		private void GenTextAdXml()
		{
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=mrlpub";
			string strSelectSource = "SELECT adr_txtadcont AS TextAdCont, adr_navurl AS NavigateUrl, adr_keyword AS Keyword, adr_impr AS Impression FROM c4_adr";

//			string strSelectFilter = "adr_keyword>'H5' AND adr_date='" + System.DateTime.Today.ToString("yyyyMMdd") + "'";
			
			//version 2：材料所要求先暫時用by month，以免他們的業務累死
			string strSelectFilter = "adr_keyword>'H5' AND substring(adr_date,1,6)='" + System.DateTime.Today.ToString("yyyyMM") + "'";

			string strSelectCommand = strSelectSource + " WHERE " + strSelectFilter;
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("TextAdvertisements");
			da.Fill(ds, "TextAd");
			ds.WriteXml(Server.MapPath(".") + "/" + "TextAdXml.xml");
		}
	}
}

