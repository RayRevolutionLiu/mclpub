using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// Summary description for InvMfrs.
	/// </summary>
	public class InvMfrs
	{
		public InvMfrs()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region 取得發票廠商資料
		public DataSet GetInvMfr(string contno)
		{
			if (contno == "")
				throw new Exception("合約編號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, " +
				"im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd " +
				"FROM invmfr " +
				"WHERE im_syscd='C4' AND im_contno='" + contno + "'";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region 取得單一發票廠商資料
		public SqlDataReader GetSingleIm(string contno, string im_imseq)
		{
			if (contno == "")
				throw new Exception("合約編號不可為空白");

			if (im_imseq == "")
				throw new Exception("發票廠商序號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, " +
				"im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd " +
				"FROM invmfr " +
				"WHERE im_syscd='C4' AND im_contno='" + contno + "' AND im_imseq='" + im_imseq + "'";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			
			myConnection.Open();
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			return dr;
		}
		#endregion

		#region 新增發票廠商
		/// <summary>
		/// 新增發票廠商
		/// </summary>
		/// <param name="im_contno">合約編號</param>
		/// <param name="im_mfrno">廠商編號</param>
		/// <param name="im_nm">發票廠商收件人姓名</param>
		/// <param name="im_jbti">稱謂</param>
		/// <param name="im_addr">住址</param>
		/// <param name="im_tel">電話</param>
		/// <param name="im_fax">傳真</param>
		/// <param name="im_cell">手機號碼</param>
		/// <param name="im_email">email</param>
		/// <param name="im_invcd">發票類別代碼</param>
		/// <param name="im_taxtp">發票課稅別代碼</param>
		/// <param name="im_fgitri">院所內往來代碼</param>
		/// <returns>新增的發票廠商收件人序號</returns>
		public string AddInvMfr(string im_contno, string im_mfrno, string im_nm, string im_jbti, string im_addr, string im_zip, string im_tel, string im_fax, string im_cell, string im_email, string im_invcd, string im_taxtp, string im_fgitri)
		{
			if (im_contno == "")
				throw new Exception("合約編號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_add_im";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
			SqlParameter param_im_contno = new SqlParameter("@im_contno", SqlDbType.Char, 6);
			param_im_contno.Value = im_contno;
			myCommand.Parameters.Add(param_im_contno);

			SqlParameter param_im_mfrno = new SqlParameter("@im_mfrno", SqlDbType.Char, 10);
			param_im_mfrno.Value = im_mfrno;
			myCommand.Parameters.Add(param_im_mfrno);

			SqlParameter param_im_nm = new SqlParameter("@im_nm", SqlDbType.VarChar, 30);
			param_im_nm.Value = im_nm;
			myCommand.Parameters.Add(param_im_nm);

			SqlParameter param_im_jbti = new SqlParameter("@im_jbti", SqlDbType.Char, 12);
			param_im_jbti.Value = im_jbti;
			myCommand.Parameters.Add(param_im_jbti);

			SqlParameter param_im_addr = new SqlParameter("@im_addr", SqlDbType.Char, 120);
			param_im_addr.Value = im_addr;
			myCommand.Parameters.Add(param_im_addr);

			SqlParameter param_im_zip = new SqlParameter("@im_zip", SqlDbType.Char, 5);
			param_im_zip.Value = im_zip;
			myCommand.Parameters.Add(param_im_zip);

			SqlParameter param_im_tel = new SqlParameter("@im_tel", SqlDbType.VarChar, 30);
			param_im_tel.Value = im_tel;
			myCommand.Parameters.Add(param_im_tel);

			SqlParameter param_im_fax = new SqlParameter("@im_fax", SqlDbType.VarChar, 30);
			param_im_fax.Value = im_fax;
			myCommand.Parameters.Add(param_im_fax);

			SqlParameter param_im_cell = new SqlParameter("@im_cell", SqlDbType.VarChar, 30);
			param_im_cell.Value = im_cell;
			myCommand.Parameters.Add(param_im_cell);

			SqlParameter param_im_email = new SqlParameter("@im_email", SqlDbType.VarChar, 80);
			param_im_email.Value = im_email;
			myCommand.Parameters.Add(param_im_email);

			SqlParameter param_im_invcd = new SqlParameter("@im_invcd", SqlDbType.Char, 1);
			param_im_invcd.Value = im_invcd;
			myCommand.Parameters.Add(param_im_invcd);

			SqlParameter param_im_taxtp = new SqlParameter("@im_taxtp", SqlDbType.Char, 1);
			param_im_taxtp.Value = im_taxtp;
			myCommand.Parameters.Add(param_im_taxtp);

			SqlParameter param_im_fgitri = new SqlParameter("@im_fgitri", SqlDbType.Char, 2);
			param_im_fgitri.Value = im_fgitri;
			myCommand.Parameters.Add(param_im_fgitri);

			// OUTPUT Parameter
			SqlParameter param_ret_imseq = new SqlParameter("@ret_imseq", SqlDbType.Char, 2);
			param_ret_imseq.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_ret_imseq);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			return Convert.ToString(param_ret_imseq.Value);
		}
		#endregion

		#region 刪除發票廠商收件人資料
		public bool DeleteIm(string im_contno, string im_imseq)
		{
			if (im_contno == "")
				throw new Exception("合約編號不可為空白");

			if (im_imseq == "")
				throw new Exception("發票廠商序號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_delete_1_im";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
			SqlParameter param_im_contno = new SqlParameter("@im_contno", SqlDbType.Char, 6);
			param_im_contno.Value = im_contno;
			myCommand.Parameters.Add(param_im_contno);

			SqlParameter param_im_imseq = new SqlParameter("@im_imseq", SqlDbType.Char, 2);
			param_im_imseq.Value = im_imseq;
			myCommand.Parameters.Add(param_im_imseq);

			// OUTPUT Parameter
			SqlParameter param_effects = new SqlParameter("@effects", SqlDbType.Int);
			param_effects.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_effects);
			
			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//影響的資料數如果大於0就是該im無法刪除
			if (Convert.ToInt32((param_effects.Value))>0)
				return false;
			else
				return true;
		}
		#endregion

		#region 修改發票廠商收件人
		public void UpdateInvMfr(string im_contno, string im_imseq, string im_mfrno, string im_nm, string im_jbti, string im_addr, string im_zip, string im_tel, string im_fax, string im_cell, string im_email, string im_invcd, string im_taxtp, string im_fgitri)
		{
			if (im_contno == "")
				throw new Exception("合約編號不可為空白");

			if (im_imseq == "")
				throw new Exception("收件人序號不可為空白");


			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_update_im";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
			SqlParameter param_im_contno = new SqlParameter("@im_contno", SqlDbType.Char, 6);
			param_im_contno.Value = im_contno;
			myCommand.Parameters.Add(param_im_contno);

			SqlParameter param_im_imseq = new SqlParameter("@im_imseq", SqlDbType.Char, 2);
			param_im_imseq.Value = im_imseq;
			myCommand.Parameters.Add(param_im_imseq);

			SqlParameter param_im_mfrno = new SqlParameter("@im_mfrno", SqlDbType.Char, 10);
			param_im_mfrno.Value = im_mfrno;
			myCommand.Parameters.Add(param_im_mfrno);

			SqlParameter param_im_nm = new SqlParameter("@im_nm", SqlDbType.VarChar, 30);
			param_im_nm.Value = im_nm;
			myCommand.Parameters.Add(param_im_nm);

			SqlParameter param_im_jbti = new SqlParameter("@im_jbti", SqlDbType.Char, 12);
			param_im_jbti.Value = im_jbti;
			myCommand.Parameters.Add(param_im_jbti);

			SqlParameter param_im_addr = new SqlParameter("@im_addr", SqlDbType.Char, 120);
			param_im_addr.Value = im_addr;
			myCommand.Parameters.Add(param_im_addr);

			SqlParameter param_im_zip = new SqlParameter("@im_zip", SqlDbType.Char, 5);
			param_im_zip.Value = im_zip;
			myCommand.Parameters.Add(param_im_zip);

			SqlParameter param_im_tel = new SqlParameter("@im_tel", SqlDbType.VarChar, 30);
			param_im_tel.Value = im_tel;
			myCommand.Parameters.Add(param_im_tel);

			SqlParameter param_im_fax = new SqlParameter("@im_fax", SqlDbType.VarChar, 30);
			param_im_fax.Value = im_fax;
			myCommand.Parameters.Add(param_im_fax);

			SqlParameter param_im_cell = new SqlParameter("@im_cell", SqlDbType.VarChar, 30);
			param_im_cell.Value = im_cell;
			myCommand.Parameters.Add(param_im_cell);

			SqlParameter param_im_email = new SqlParameter("@im_email", SqlDbType.VarChar, 80);
			param_im_email.Value = im_email;
			myCommand.Parameters.Add(param_im_email);

			SqlParameter param_im_invcd = new SqlParameter("@im_invcd", SqlDbType.Char, 1);
			param_im_invcd.Value = im_invcd;
			myCommand.Parameters.Add(param_im_invcd);

			SqlParameter param_im_taxtp = new SqlParameter("@im_taxtp", SqlDbType.Char, 1);
			param_im_taxtp.Value = im_taxtp;
			myCommand.Parameters.Add(param_im_taxtp);

			SqlParameter param_im_fgitri = new SqlParameter("@im_fgitri", SqlDbType.Char, 2);
			param_im_fgitri.Value = im_fgitri;
			myCommand.Parameters.Add(param_im_fgitri);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}
		#endregion
	}
}
