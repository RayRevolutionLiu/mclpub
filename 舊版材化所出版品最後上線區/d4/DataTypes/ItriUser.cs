using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// Summary description for ItriUser.
	/// </summary>
	public struct ItriUser
	{
		private string _empno;
		private string _cname;
		private string _tel;
		private string _atype;
		private string _orgcd;
		private string _deptcd;

		#region Properties
		public string EmpNo
		{
			get
			{
				return _empno;
			}
		}

		public string CName
		{
			get
			{
				return _cname;
			}
		}

		public string Tel
		{
			get
			{
				return _tel;
			}
		}

		public string AType
		{
			get
			{
				return _atype;
			}
		}

		public string OrgCd
		{
			get
			{
				return _orgcd;
			}
		}

		public string DeptCd
		{
			get
			{
				return _deptcd;
			}
		}
		#endregion

		#region Constructor，取得員工資料
		public ItriUser(string empno)
		{
			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT * FROM srspn WHERE srspn_empno=@srspn_empno";
			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.Text;

			//Parameters
			SqlParameter param_srspn_empno = new SqlParameter("@srspn_empno", SqlDbType.Char, 7);
			param_srspn_empno.Value = empno;
			myCommand.Parameters.Add(param_srspn_empno);

			myConnection.Open();
			try
			{
				SqlDataReader dr = 	myCommand.ExecuteReader(CommandBehavior.CloseConnection);
				
				if (!dr.Read())
				{
					throw new Exception("無此員工資料");
				}

				_empno = dr["srspn_empno"].ToString().Trim();
				_cname = dr["srspn_cname"].ToString().Trim();
				_tel = dr["srspn_tel"].ToString().Trim();
				_atype = dr["srspn_atype"].ToString().Trim();
				_orgcd = dr["srspn_orgcd"].ToString().Trim();
				_deptcd = dr["srspn_deptcd"].ToString().Trim();
			}
			catch(SqlException ex)
			{
				throw new Exception("取得員工資料時發生錯誤，原訊息: " + ex.Message, ex);
			}
		}
		#endregion
	}
}
