using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// Summary description for Customers.
	/// </summary>
	public class Customers
	{
		#region 取得廠商客戶資料
		/// <summary>
		/// 取得廠商客戶資料
		/// </summary>
		/// <returns>廠商客戶資料</returns>
		public DataSet GetMfrCustomers()
		{
			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_iaddr, mfr.mfr_izip, " +
				"mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_regdate, cust.cust_custid, " +
				"cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_mfrno, cust.cust_tel, cust.cust_fax, " +
				"cust.cust_cell, cust.cust_email, cust.cust_regdate, cust.cust_moddate, cust.cust_itpcd, cust.cust_btpcd, " +
				"cust.cust_rtpcd, cust.cust_oldcustno FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region 取得單一客戶資料
		/// <summary>
		/// 取得單一客戶資料
		/// </summary>
		/// <param name="custno">客戶編號</param>
		/// <returns>單一客戶資料</returns>
		public SqlDataReader GetSingleCustomer(string custno)
		{
			if (custno == "")
				throw new Exception("客戶編號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, " +
							"cust_email, cust_regdate, cust_moddate, cust_itpcd, cust_btpcd, cust_rtpcd, " +
							"cust_oldcustno, cust_orgisyscd " +
							"FROM cust WHERE cust_custno='" + custno + "'";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			
			myConnection.Open();
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return dr;
		}
		#endregion

		#region 由客戶編號取得廠商客戶資料
		/// <summary>
		/// 由客戶編號取得廠商客戶資料
		/// </summary>
		/// <param name="custno">客戶編號</param>
		/// <returns>廠商客戶資料</returns>
		public SqlDataReader GetMfrCustByCustNo(string cust_custno)
		{
			if (cust_custno == "")
				throw new Exception("客戶編號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);

			string strCmd = "SELECT cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, " +
							"cust_email, cust_regdate, cust_moddate, cust_itpcd, cust_btpcd, cust_rtpcd, " +
							"cust_oldcustno, cust_orgisyscd, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, " +
							"mfr_respnm, mfr_respjbti, mfr_tel, mfr_fax, mfr_regdate " +
							"FROM cust INNER JOIN mfr ON cust_mfrno = mfr_mfrno " +
							"WHERE cust_custno=@cust_custno";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);

			// 設定Parameter
			SqlParameter param_cust_custno = new SqlParameter("@cust_custno", SqlDbType.Char, 6);
			param_cust_custno.Value = cust_custno;
			myCommand.Parameters.Add(param_cust_custno);
			
			myConnection.Open();
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return dr;
		}
		#endregion
	}
}
