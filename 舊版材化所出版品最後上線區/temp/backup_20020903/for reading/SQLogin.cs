using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;

namespace MyComponents
{
	/// <summary>
	/// Summary description for SQLogin.
	/// </summary>
	public class SQLogin
	{
		public string EmpNo;
		public string OrgCd;
		public string DeptCd;
		public string CName;
		public bool EmpNoIsValid;
		public bool SysExist;

		public SQLogin(string empno)
		{
			//
			// TODO: Add constructor logic here
			//

			//���o���u���
			EmpNoIsValid = false;
			string strDSN1 = ConfigurationSettings.AppSettings["isccom1_common"].ToString();
			string strSelectCommand1 = "SELECT com_orgcd, com_deptcd, com_cname FROM comper WHERE com_empno='" + empno + "'";
			OleDbConnection cnn1 = new OleDbConnection(strDSN1);
			OleDbCommand cmd1 = new OleDbCommand(strSelectCommand1, cnn1);
			OleDbDataReader dr1;

			cmd1.Connection.Open();
			dr1 = cmd1.ExecuteReader();
			if (dr1.Read())
			{
				//�u���o�˪����u��
				EmpNo = empno;
				OrgCd = dr1["com_orgcd"].ToString();
				DeptCd = dr1["com_deptcd"].ToString();
				CName = dr1["com_cname"].ToString();
				EmpNoIsValid = true;
			}
			else
			{
				//���~�A�S���o�˪����u
			}
			dr1.Close();
			cmd1.Connection.Close();
		}

		public void MLogin(string SysCode, string sqlSource)
		{
			//�bsyss����X�O�_���o�˪��t��
			string strDSN2 = ConfigurationSettings.AppSettings[sqlSource].ToString();
			OleDbConnection cnn2 = new OleDbConnection(strDSN2);
			string strSelectCommand2 = "SELECT * FROM ssys WHERE ssys_syscode='" + SysCode + "'";
			OleDbCommand cmd2 = new OleDbCommand(strSelectCommand2, cnn2);
			cmd2.Connection.Open();
			OleDbDataReader dr2;
			dr2 = cmd2.ExecuteReader();
			if (dr2.Read())
			{
				//�u�����o�˪��t�Φs�b
				SysExist = true;
			}
			else
			{
				//�S���o�˪��t�Φs�b
				SysExist = false;
			}
			dr2.Close();
			cmd2.Connection.Close();
		}
	}
}
