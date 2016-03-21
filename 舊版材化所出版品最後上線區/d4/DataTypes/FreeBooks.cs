using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// Summary description for FreeBooks.
	/// </summary>
	public class FreeBooks
	{
		public FreeBooks()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region ���o����H+�خѸ��
		/// <summary>
		/// ���o����H+�خѸ��
		/// </summary>
		/// <param name="contno">�X���s��</param>
		/// <returns>����H�P�خѥH�ζl�H���Ƹ��</returns>
		public DataSet GetFbkOrByContNo(string contno)
		{
			if (contno == "")
				throw new Exception("�X���s�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT c4_freebk.fbk_syscd, c4_freebk.fbk_contno, c4_freebk.fbk_fbkitem, " +
							"c4_freebk.fbk_bkcd, freecat.fc_nm, c4_ramt.ma_oritem, c4_or.or_nm, " +
							"c4_or.or_fgmosea, c4_freebk.fbk_bkcd, c4_or.or_contno, " +
							"c4_or.or_oritem, c4_or.or_syscd, c4_ramt.ma_contno, " +
							"c4_ramt.ma_fbkitem, c4_ramt.ma_syscd, c4_ramt.ma_sdate, c4_ramt.ma_edate, c4_ramt.ma_pubmnt, " +
							"c4_ramt.ma_unpubmnt, c4_ramt.ma_mtpcd, c4_or.or_addr, " +
							"SUBSTRING(ma_sdate, 1, 4) + '/' + SUBSTRING(ma_sdate, 5, 2) AS str_ma_sdate, " +
							"SUBSTRING(ma_edate, 1, 4) + '/' + SUBSTRING(ma_edate, 5, 2) AS str_ma_edate " +
							"FROM c4_freebk INNER JOIN " +
							"c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND " +
							"c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN " +
							"c4_ramt ON c4_freebk.fbk_syscd = c4_ramt.ma_syscd AND " +
							"c4_freebk.fbk_contno = c4_ramt.ma_contno AND " +
							"c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem AND " +
							"c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN " +
							"freecat ON c4_freebk.fbk_bkcd = freecat.fc_fccd " +
							"WHERE c4_freebk.fbk_contno='" + contno + "'";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region ���o��@�خѤΦ���H���
		/// <summary>
		/// ���o��@����H���
		/// </summary>
		/// <param name="contno">�X���s��</param>
		/// <param name="fbkitem">�خѧǸ�</param>
		/// <returns>��@�خѤΦ���H���</returns>
		public SqlDataReader GetSingleFbkOr(string contno, string fbkitem)
		{
			if (contno == "")
				throw new Exception("�X���s�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT c4_freebk.fbk_syscd, c4_freebk.fbk_contno, c4_freebk.fbk_fbkitem, " +
				"c4_freebk.fbk_bkcd, freecat.fc_nm, c4_ramt.ma_oritem, c4_or.or_nm, " +
				"c4_or.or_fgmosea, c5_freebk.fbk_bkcd, c4_or.or_contno, " +
				"c4_or.or_oritem, c4_or.or_syscd, c4_ramt.ma_contno, " +
				"c4_ramt.ma_fbkitem, c4_ramt.ma_syscd, c4_ramt.ma_sdate, c4_ramt.ma_edate, c4_ramt.ma_pubmnt, " +
				"c4_ramt.ma_unpubmnt, c4_ramt.ma_mtpcd, c4_or.or_addr, " +
				"SUBSTRING(ma_sdate, 1, 4) + '/' + SUBSTRING(ma_sdate, 5, 2) AS str_ma_sdate, " +
				"SUBSTRING(ma_edate, 1, 4) + '/' + SUBSTRING(ma_edate, 5, 2) AS str_ma_edate " +
				"FROM c4_freebk INNER JOIN " +
				"c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND " +
				"c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN " +
				"c4_ramt ON c4_freebk.fbk_syscd = c4_ramt.ma_syscd AND " +
				"c4_freebk.fbk_contno = c4_ramt.ma_contno AND " +
				"c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem AND " +
				"c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN " +
				"freecat ON c4_freebk.fbk_bkcd = freecat.fc_fccd " +
				"WHERE c4_freebk.fbk_contno='" + contno + "' AND fbk_fbkitem='" + fbkitem + "'";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			
			myConnection.Open();
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return dr;
		}
		#endregion

		#region �s�W�خ�
		public string AddFreeBk(string new_contno, string fbk_bkcd, string ma_oritem, string ma_sdate, string ma_edate, string ma_pubmnt, string ma_unpubmnt, string ma_mtpcd)
		{
			if (new_contno == "")
				throw new Exception("�X���s�����i���ť�");

			if (ma_oritem == "")
				throw new Exception("����H�Ǹ����i���ť�");


			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_add_freebk";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_new_contno = new SqlParameter("@new_contno", SqlDbType.Char, 6);
			param_new_contno.Value = new_contno;
			myCommand.Parameters.Add(param_new_contno);

			SqlParameter param_fbk_bkcd = new SqlParameter("@fbk_bkcd", SqlDbType.Char, 2);
			param_fbk_bkcd.Value = fbk_bkcd;
			myCommand.Parameters.Add(param_fbk_bkcd);

			SqlParameter param_ma_oritem = new SqlParameter("@ma_oritem", SqlDbType.Char, 2);
			param_ma_oritem.Value = ma_oritem;
			myCommand.Parameters.Add(param_ma_oritem);

			SqlParameter param_ma_sdate = new SqlParameter("@ma_sdate", SqlDbType.Char, 6);
			param_ma_sdate.Value = ma_sdate;
			myCommand.Parameters.Add(param_ma_sdate);

			SqlParameter param_ma_edate = new SqlParameter("@ma_edate", SqlDbType.Char, 6);
			param_ma_edate.Value = ma_edate;
			myCommand.Parameters.Add(param_ma_edate);

			SqlParameter param_ma_pubmnt = new SqlParameter("@ma_pubmnt", SqlDbType.Int);
			param_ma_pubmnt.Value = ma_pubmnt;
			myCommand.Parameters.Add(param_ma_pubmnt);

			SqlParameter param_ma_unpubmnt = new SqlParameter("@ma_unpubmnt", SqlDbType.Int);
			param_ma_unpubmnt.Value = ma_unpubmnt;
			myCommand.Parameters.Add(param_ma_unpubmnt);

			SqlParameter param_ma_mtpcd = new SqlParameter("@ma_mtpcd", SqlDbType.Char, 1);
			param_ma_mtpcd.Value = ma_mtpcd;
			myCommand.Parameters.Add(param_ma_mtpcd);

			// OUTPUT Parameter
			SqlParameter param_fbk_fbkitem = new SqlParameter("@fbk_fbkitem", SqlDbType.Char, 2);
			param_fbk_fbkitem.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_fbk_fbkitem);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			return Convert.ToString(param_fbk_fbkitem.Value);
		}
		#endregion

		#region �ק��خѸ��-���R���A�A�s�W
		/// <summary>
		/// �ק��خѸ��-���R���A�A�s�W
		/// </summary>
		/// <param name="new_contno">�X���s��</param>
		/// <param name="fbk_fbkitem">�خѶ���</param>
		/// <param name="fbk_bkcd">���y�N�X</param>
		/// <param name="ma_oritem">����H�Ǹ�</param>
		/// <param name="ma_sdate">�خѰ_��</param>
		/// <param name="ma_edate">�خѨ���</param>
		/// <param name="ma_pubmnt">��릳�Z�n�ذe�ƶq</param>
		/// <param name="ma_unpubmnt">���L�Z�n�ذe�ƶq</param>
		/// <param name="ma_mtpcd">�l�H���O�N�X</param>
		/// <returns>�R���A�s�W���خѶ���</returns>
		public string UpdateFreeBk(string new_contno, string fbk_fbkitem, string fbk_bkcd, string ma_oritem, string ma_sdate, string ma_edate, string ma_pubmnt, string ma_unpubmnt, string ma_mtpcd)
		{
			if (new_contno == "")
				throw new Exception("�X���s�����i���ť�");

			if (fbk_fbkitem == "")
				throw new Exception("�خѶ������i���ť�");

			if (ma_oritem == "")
				throw new Exception("����H�Ǹ����i���ť�");


			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_update_freebk";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_new_contno = new SqlParameter("@new_contno", SqlDbType.Char, 6);
			param_new_contno.Value = new_contno;
			myCommand.Parameters.Add(param_new_contno);

			SqlParameter param_fbk_fbkitem = new SqlParameter("@fbk_fbkitem", SqlDbType.Char, 2);
			param_fbk_fbkitem.Value = fbk_fbkitem;
			myCommand.Parameters.Add(param_fbk_fbkitem);

			SqlParameter param_fbk_bkcd = new SqlParameter("@fbk_bkcd", SqlDbType.Char, 2);
			param_fbk_bkcd.Value = fbk_bkcd;
			myCommand.Parameters.Add(param_fbk_bkcd);

			SqlParameter param_ma_oritem = new SqlParameter("@ma_oritem", SqlDbType.Char, 2);
			param_ma_oritem.Value = ma_oritem;
			myCommand.Parameters.Add(param_ma_oritem);

			SqlParameter param_ma_sdate = new SqlParameter("@ma_sdate", SqlDbType.Char, 6);
			param_ma_sdate.Value = ma_sdate;
			myCommand.Parameters.Add(param_ma_sdate);

			SqlParameter param_ma_edate = new SqlParameter("@ma_edate", SqlDbType.Char, 6);
			param_ma_edate.Value = ma_edate;
			myCommand.Parameters.Add(param_ma_edate);

			SqlParameter param_ma_pubmnt = new SqlParameter("@ma_pubmnt", SqlDbType.Int);
			param_ma_pubmnt.Value = ma_pubmnt;
			myCommand.Parameters.Add(param_ma_pubmnt);

			SqlParameter param_ma_unpubmnt = new SqlParameter("@ma_unpubmnt", SqlDbType.Int);
			param_ma_unpubmnt.Value = ma_unpubmnt;
			myCommand.Parameters.Add(param_ma_unpubmnt);

			SqlParameter param_ma_mtpcd = new SqlParameter("@ma_mtpcd", SqlDbType.Char, 1);
			param_ma_mtpcd.Value = ma_mtpcd;
			myCommand.Parameters.Add(param_ma_mtpcd);

			// OUTPUT Parameter
			SqlParameter param_ret_fbkitem = new SqlParameter("@ret_fbkitem", SqlDbType.Char, 2);
			param_ret_fbkitem.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_ret_fbkitem);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			return Convert.ToString(param_ret_fbkitem.Value);
		}
		#endregion
		
		#region �R���浧�خѸ��
		/// <summary>
		/// �R���浧�خѸ��
		/// </summary>
		/// <param name="new_contno">�X���s��</param>
		/// <param name="fbk_fbkitem">�خѶ���</param>
		/// <param name="ma_oritem">����H�Ǹ�</param>
		/// <returns>�O�_�R�����\</returns>
		public bool Delete_1_FreeBk(string new_contno, string fbk_fbkitem, string ma_oritem)
		{
			if (new_contno == "")
				throw new Exception("�X���s�����i���ť�");

			if (fbk_fbkitem == "")
				throw new Exception("�خѶ������i���ť�");

			if (ma_oritem == "")
				throw new Exception("����H�Ǹ����i���ť�");


			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_delete_1_freebk";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_new_contno = new SqlParameter("@new_contno", SqlDbType.Char, 6);
			param_new_contno.Value = new_contno;
			myCommand.Parameters.Add(param_new_contno);

			SqlParameter param_fbk_fbkitem = new SqlParameter("@fbk_fbkitem", SqlDbType.Char, 2);
			param_fbk_fbkitem.Value = fbk_fbkitem;
			myCommand.Parameters.Add(param_fbk_fbkitem);

			SqlParameter param_ma_oritem = new SqlParameter("@ma_oritem", SqlDbType.Char, 2);
			param_ma_oritem.Value = ma_oritem;
			myCommand.Parameters.Add(param_ma_oritem);			

			// OUTPUT Parameter
			SqlParameter param_success = new SqlParameter("@success", SqlDbType.Int);
			param_success.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_success);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//success=0���ѡAsuccess=1���\
			if (Convert.ToInt32(param_success.Value) == 0)
				return false;
			else
				return true;
		}
		#endregion

		//
		// ����H����
		//

		#region ���o����H���
		/// <summary>
		/// ���o����H���
		/// </summary>
		/// <param name="contno">�X���s��</param>
		/// <returns>����H���</returns>
		public DataSet GetOrByContNo(string contno)
		{
			if (contno == "")
				throw new Exception("�X���s�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT or_syscd, or_contno, or_oritem, or_nm, or_jbti, or_addr, or_zip, or_tel, " +
							"or_fax, or_cell, or_email, or_fgmosea " +
							"FROM c4_or WHERE or_contno='" + contno + "'";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region �s�W����H���
		/// <summary>
		/// �s�W����H���
		/// </summary>
		/// <param name="or_contno">�X���s��</param>
		/// <param name="or_nm">����H�m�W</param>
		/// <param name="or_jbti">¾��</param>
		/// <param name="or_addr">�a�}</param>
		/// <param name="or_zip">�l���ϸ�</param>
		/// <param name="or_tel">�q��</param>
		/// <param name="or_fax">�ǯu</param>
		/// <param name="or_cell">��ʹq��</param>
		/// <param name="or_email">�q�l�l��H�c</param>
		/// <param name="or_fgmosea">���~�l�H���O�A1�O�A0�_�A�w�]0</param>
		/// <returns>�s�W�o�Ӧ���H���Ǹ�</returns>
		public string AddOr(string or_contno, string or_nm, string or_jbti, string or_addr, string or_zip, string or_tel, string or_fax, string or_cell, string or_email, string or_fgmosea)
		{
			if (or_contno == "")
				throw new Exception("�X���s�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_add_or";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_or_contno = new SqlParameter("@or_contno", SqlDbType.Char, 6);
			param_or_contno.Value = or_contno;
			myCommand.Parameters.Add(param_or_contno);

			SqlParameter param_or_nm = new SqlParameter("@or_nm", SqlDbType.VarChar, 30);
			param_or_nm.Value = or_nm;
			myCommand.Parameters.Add(param_or_nm);

			SqlParameter param_or_jbti = new SqlParameter("@or_jbti", SqlDbType.VarChar, 12);
			param_or_jbti.Value = or_jbti;
			myCommand.Parameters.Add(param_or_jbti);

			SqlParameter param_or_addr = new SqlParameter("@or_addr", SqlDbType.VarChar, 120);
			param_or_addr.Value = or_addr;
			myCommand.Parameters.Add(param_or_addr);

			SqlParameter param_or_zip = new SqlParameter("@or_zip", SqlDbType.Char, 5);
			param_or_zip.Value = or_zip;
			myCommand.Parameters.Add(param_or_zip);

			SqlParameter param_or_tel = new SqlParameter("@or_tel", SqlDbType.VarChar, 30);
			param_or_tel.Value = or_tel;
			myCommand.Parameters.Add(param_or_tel);

			SqlParameter param_or_fax = new SqlParameter("@or_fax", SqlDbType.VarChar, 30);
			param_or_fax.Value = or_fax;
			myCommand.Parameters.Add(param_or_fax);

			SqlParameter param_or_cell = new SqlParameter("@or_cell", SqlDbType.VarChar, 30);
			param_or_cell.Value = or_cell;
			myCommand.Parameters.Add(param_or_cell);

			SqlParameter param_or_email = new SqlParameter("@or_email", SqlDbType.VarChar, 80);
			param_or_email.Value = or_email;
			myCommand.Parameters.Add(param_or_email);
			
			SqlParameter param_or_fgmosea = new SqlParameter("@or_fgmosea", SqlDbType.Char, 1);
			param_or_fgmosea.Value = or_fgmosea;
			myCommand.Parameters.Add(param_or_fgmosea);

			// OUTPUT Parameter
			SqlParameter param_or_oritem = new SqlParameter("@or_oritem", SqlDbType.Char, 2);
			param_or_oritem.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_or_oritem);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			return Convert.ToString(param_or_oritem.Value);
		}
		#endregion

		#region �ק怜��H���
		/// <summary>
		/// �ק怜��H���
		/// </summary>
		/// <param name="or_contno">�X���s��</param>
		/// <param name="or_oritem">����H�Ǹ�</param>
		/// <param name="or_nm">����H�m�W</param>
		/// <param name="or_jbti">¾��</param>
		/// <param name="or_addr">�a�}</param>
		/// <param name="or_zip">�l���ϸ�</param>
		/// <param name="or_tel">�q�ܸ��X</param>
		/// <param name="or_fax">�ǯu���X</param>
		/// <param name="or_cell">��ʹq�ܸ��X</param>
		/// <param name="or_email">�q�l�l��H�c</param>
		/// <param name="or_fgmosea">���~�l�H���O</param>
		public void UpdateOr(string new_contno, string or_oritem, string or_nm, string or_jbti, string or_addr, string or_zip, string or_tel, string or_fax, string or_cell, string or_email, string or_fgmosea)
		{
			if (new_contno == "")
				throw new Exception("�X���s�����i���ť�");

			if (or_oritem == "")
				throw new Exception("����H�Ǹ����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_update_or";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_new_contno = new SqlParameter("@new_contno", SqlDbType.Char, 6);
			param_new_contno.Value = new_contno;
			myCommand.Parameters.Add(param_new_contno);

			SqlParameter param_or_oritem = new SqlParameter("@or_oritem", SqlDbType.Char, 2);
			param_or_oritem.Value = or_oritem;
			myCommand.Parameters.Add(param_or_oritem);

			SqlParameter param_or_nm = new SqlParameter("@or_nm", SqlDbType.VarChar, 30);
			param_or_nm.Value = or_nm;
			myCommand.Parameters.Add(param_or_nm);

			SqlParameter param_or_jbti = new SqlParameter("@or_jbti", SqlDbType.VarChar, 12);
			param_or_jbti.Value = or_jbti;
			myCommand.Parameters.Add(param_or_jbti);

			SqlParameter param_or_addr = new SqlParameter("@or_addr", SqlDbType.VarChar, 120);
			param_or_addr.Value = or_addr;
			myCommand.Parameters.Add(param_or_addr);

			SqlParameter param_or_zip = new SqlParameter("@or_zip", SqlDbType.Char, 5);
			param_or_zip.Value = or_zip;
			myCommand.Parameters.Add(param_or_zip);

			SqlParameter param_or_tel = new SqlParameter("@or_tel", SqlDbType.VarChar, 30);
			param_or_tel.Value = or_tel;
			myCommand.Parameters.Add(param_or_tel);

			SqlParameter param_or_fax = new SqlParameter("@or_fax", SqlDbType.VarChar, 30);
			param_or_fax.Value = or_fax;
			myCommand.Parameters.Add(param_or_fax);

			SqlParameter param_or_cell = new SqlParameter("@or_cell", SqlDbType.VarChar, 30);
			param_or_cell.Value = or_cell;
			myCommand.Parameters.Add(param_or_cell);

			SqlParameter param_or_email = new SqlParameter("@or_email", SqlDbType.VarChar, 80);
			param_or_email.Value = or_email;
			myCommand.Parameters.Add(param_or_email);
			
			SqlParameter param_or_fgmosea = new SqlParameter("@or_fgmosea", SqlDbType.Char, 1);
			param_or_fgmosea.Value = or_fgmosea;
			myCommand.Parameters.Add(param_or_fgmosea);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}
		#endregion

		#region �R������H���
		/// <summary>
		/// �R������H���
		/// </summary>
		/// <param name="or_contno">�X���s��</param>
		/// <param name="or_oritem">����H�Ǹ�</param>
		/// <returns>�R���O�_���\�A0���\�A�D0�h������(������H��������Ƶ���)</returns>
		public int DeleteOr(string or_contno, string or_oritem)
		{
			if (or_contno == "")
				throw new Exception("�X���s�����i���ť�");

			if (or_oritem == "")
				throw new Exception("����H�Ǹ����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_delete_or";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_or_contno = new SqlParameter("@or_contno", SqlDbType.Char, 6);
			param_or_contno.Value = or_contno;
			myCommand.Parameters.Add(param_or_contno);

			SqlParameter param_or_oritem = new SqlParameter("@or_oritem", SqlDbType.Char, 2);
			param_or_oritem.Value = or_oritem;
			myCommand.Parameters.Add(param_or_oritem);

			// OUTPUT Parameter
			SqlParameter param_effects = new SqlParameter("@effects", SqlDbType.Int);
			param_effects.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_effects);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			return Convert.ToInt32(param_effects.Value);
		}
		#endregion
	}
}
