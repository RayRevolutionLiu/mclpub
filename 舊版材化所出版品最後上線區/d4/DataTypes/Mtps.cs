using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// Summary description for Mtps.
	/// </summary>
	public class Mtps
	{
		public Mtps()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region 取郵寄類別資料
		public DataSet GetMtps()
		{
			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT mtp_mtpcd, mtp_nm FROM mtp";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion
	}
}
