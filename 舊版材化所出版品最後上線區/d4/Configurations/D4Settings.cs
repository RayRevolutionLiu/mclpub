using System;
using System.Configuration;

namespace MRLPub.d4.Configurations
{
	/// <summary>
	/// Summary description for D4Settings.
	/// </summary>
	public class D4Settings
	{
		public D4Settings()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string ConnectionString
		{
			get
			{
				return ConfigurationSettings.AppSettings.Get("itridpa_mrlpub");
			}
		}

		public static string HomeUrl
		{
			get
			{
				return ConfigurationSettings.AppSettings.Get("home_url");
			}
		}
	}
}
