using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// C4�X��
	/// </summary>
	public class Contracts
	{
		#region private members�ATable�������
		//�t�ΥN��
		private string _syscd;
		//�X���s��
		private string _contno;
		//�Ȥ�s��
		private string _custno;
		//�X�����O
		private string _conttp;
		//ñ�����
		private string _signdate;
		//�X���}�l���
		private string _sdate;
		//�X���������
		private string _edate;
		//ñ���~�ȭ��u��
		private string _empno;
		//�t�ӽs��
		private string _mfrno;
		
		//�s�i�d��(����)�A���氱�Τ�
		private string _pubcate;

		//�p���H�m�W
		private string _aunm;
		//�p���H�q��
		private string _autel;
		//�p���H�ǯu���X
		private string _aufax;
		//�p���H��ʹq��
		private string _aucell;
		//�p���H�q�l�l��a�}
		private string _aumail;
		//�u�f���
		private float _disc;
		//�ذe����
		private int _freetm;
		//�`�s�ϽZ����
		private int _totimgtm;
		//�`�s�����Z����
		private int _toturltm;
		//�w�Z�n(����)����
		private int _pubtm;
		//�Ѿl�Z�n(����)����
		private int _resttm;
		//�X���`���B
		private float _totamt;
		//�w�I���B
		private float _paidamt;
		//�Ѿl���B
		private float _resamt;
		//�s�i���s����
		private string _ccont;
		//�s�i���s����j�M����
		private string _csdate;

		//���~�a�X�A�L�k�ϥγo������ܸ��
		private string _atp;
		//���ƯS�ʥN�X�A�L�k�ϥγo������ܸ��
		private string _matp;

		//���׵��O
		private string _fgclosed;
		//�X���Ƶ�
		private string _adremark;
		//�X���S�O�Ƶ�
		private string _adsprem;
		//���~�]�Ƥ���
		private string _pdcont;
		//�X���ק���
		private string _moddate;
		//�@���I�ڵ��O
		private string _fgpayonce;
		//�X���Ȧs���O
		private string _fgtemp;
		//�s�i�w���X���O
		private string _fgpubed;
		//�X�����P���O
		private string _fgcancel;
		//�X���ק���u�s��
		private string _modempno;
		//�X����l���
		private string _credate;
		#endregion

		#region Properties�A���H��첣��
		//�t�ΥN���A��Ū
		public string SysCd
		{
			get
			{
				return _syscd;
			}
		}

		//�X���s���A��Ū
		public string ContNo
		{
			get
			{
				return _contno;
			}
		}

		//�Ȥ�s��
		public string CustNo
		{
			get
			{
				return _custno;
			}
			set
			{
				_custno = value;
			}
		}

		//�X�����O
		public string ContTp
		{
			get
			{
				return _conttp;
			}
			set
			{
				_conttp = value;
			}
		}

		//ñ�����
		public string SignDate
		{
			get
			{
				return _signdate;
			}
			set
			{
				_signdate = value;
			}
		}

		//�X���}�l���
		public string SDate
		{
			get
			{
				return _sdate;
			}
			set
			{
				_sdate = value;
			}
		}

		//�X���������
		public string EDate
		{
			get
			{
				return _edate;
			}
			set
			{
				_edate = value;
			}
		}

		//ñ���~�ȭ��u��
		public string EmpNo
		{
			get
			{
				return _empno;
			}
			set
			{
				_empno = value;
			}
		}
		//�t�ӽs��
		public string MfrNo		
		{
			get
			{
				return _mfrno;
			}
			set
			{
				_mfrno = value;
			}
		}

		//�s�i�d��(����)�A���氱�Τ�
		public string PubCate		
		{
			get
			{
				return _pubcate;
			}
			set
			{
				_pubcate = value;
			}
		}

		//�p���H�m�W
		public string AuNm
		{
			get
			{
				return _aunm;
			}
			set
			{
				_aunm = value;
			}
		}

		//�p���H�q��
		public string AuTel
		{
			get
			{
				return _autel;
			}
			set
			{
				_autel = value;
			}
		}

		//�p���H�ǯu���X
		public string AuFax
		{
			get
			{
				return _aufax;
			}
			set
			{
				_aufax = value;
			}
		}

		//�p���H��ʹq��
		public string AuCell
		{
			get
			{
				return _aucell;
			}
			set
			{
				_aucell = value;
			}
		}

		//�p���H�q�l�l��a�}
		public string AuMail
		{
			get
			{
				return _aumail;
			}
			set
			{
				_aumail = value;
			}
		}

		//�u�f���
		public float Disc
		{
			get
			{
				return _disc;
			}
			set
			{
				_disc = value;
			}
		}
		//�ذe����
		public int FreeTm
		{
			get
			{
				return _freetm;
			}
			set
			{
				_freetm = value;
			}
		}
		//�`�s�ϽZ����
		public int TotImgTm
		{
			get
			{
				return _totimgtm;
			}
			set
			{
				_totimgtm = value;
			}
		}

		//�`�s�����Z����
		public int TotUrlTm
		{
			get
			{
				return _toturltm;
			}
			set
			{
				_toturltm = value;
			}
		}

		//�w�Z�n(����)����
		public int PubTm
		{
			get
			{
				return _pubtm;
			}
			set
			{
				_pubtm = value;
			}
		}		
		//�Ѿl�Z�n(����)����
		public int RestTm
		{
			get
			{
				return _resttm;
			}
			set
			{
				_resttm = value;
			}
		}

		//�X���`���B
		public float TotAmt
		{
			get
			{
				return _totamt;
			}
			set
			{
				_totamt = value;
			}
		}

		//�w�I���B
		public float PaidAmt
		{
			get
			{
				return _paidamt;
			}
			set
			{
				_paidamt = value;
			}
		}

		//�Ѿl���B
		public float ResAmt
		{
			get
			{
				return _resamt;
			}
			set
			{
				_resamt = value;
			}
		}

		//�s�i���s����
		public string Ccont
		{
			get
			{
				return _ccont;
			}
			set
			{
				_ccont = value;
			}
		}

		//�s�i���s����j�M����
		public string CsDate
		{
			get
			{
				return _csdate;
			}
			set
			{
				_csdate = value;
			}
		}

		//���~�a�X�A�L�k�ϥγo������ܸ��
		public string ATp
		{
			get
			{
				return _atp;
			}
			set
			{
				_atp = value;
			}
		}

		//���ƯS�ʥN�X�A�L�k�ϥγo������ܸ��
		public string MaTp
		{
			get
			{
				return _matp;
			}
			set
			{
				_matp = value;
			}
		}

		//????????????????????????????????????????????????????????????
		//���׵��O
		public string FgClosed
		{
			get
			{
				return _fgclosed;
			}
			set
			{
				_fgclosed = value;
			}
		}

		//�X���Ƶ�
		public string AdRemark
		{
			get
			{
				return _adremark;
			}
			set
			{
				_adremark = value;
			}
		}

		//�X���S�O�Ƶ�
		public string AdSpRem
		{
			get
			{
				return _adsprem;
			}
			set
			{
				_adsprem = value;
			}
		}

		//���~�]�Ƥ���
		public string PdCont
		{
			get
			{
				return _pdcont;
			}
			set
			{
				_pdcont = value;
			}
		}

		//�X���ק���
		public string ModDate
		{
			get
			{
				return _moddate;
			}
			set
			{
				_moddate = value;
			}
		}		

		//�@���I�ڵ��O
		public string FgPayOnce
		{
			get
			{
				return _fgpayonce;
			}
			set
			{
				_fgpayonce = value;
			}
		}

		//�X���Ȧs���O??????????????????????????????
		public string FgTemp
		{
			get
			{
				return _fgtemp;
			}
			set
			{
				_fgtemp = value;
			}
		}

		//�s�i�w���X���O???????????????????????????
		public string FgPubed
		{
			get
			{
				return _fgpubed;
			}
			set
			{
				_fgpubed = value;
			}
		}			

		//�X�����P���O????????????????????????????
		public string FgCancel
		{
			get
			{
				return _fgcancel;
			}
			set
			{
				_fgcancel = value;
			}
		}

		//�X���ק���u�s��
		public string ModEmpNo
		{
			get
			{
				return _modempno;
			}
			set
			{
				_modempno = value;
			}
		}

		//�X����l���
		public string CreDate
		{
			get
			{
				return _credate;
			}
			set
			{
				_credate = value;
			}
		}
		#endregion

		#region Properties�A�l��Property
		//�O���P���X���H
		public bool IsCanceled
		{
			get
			{
				if (_fgcancel == null)
					throw new Exception("�|�����J�X�����");

				if (_fgcancel == "1")
					return true;
				else
					return false;
			}
		}

		//�O�Ȧs���X���H
		public bool IsTemp
		{
			get
			{
				if (_fgtemp == null)
					throw new Exception("�|�����J�X�����");

				if (_fgtemp == "1")
					return true;
				else
					return false;
			}
		}

		//�w�g�s�i�L�F�H
		public bool IsPubed
		{
			get
			{
				if (_fgpubed == null)
					throw new Exception("�|�����J�X�����");

				if (_fgpubed == "1")
					return true;
				else
					return false;
			}		
		}

		//�O�@���I�ڪ��H
		public bool IsPayOnce
		{
			get
			{
				if (_fgpayonce == null)
					throw new Exception("�|�����J�X�����");

				if (_fgpayonce == "1")
					return true;
				else
					return false;
			}
		}

		//�O���צX��
		public bool IsClosed
		{
			get
			{
				if (_fgclosed == null)
					throw new Exception("�|�����J�X�����");

				if (_fgclosed == "1")
					return true;
				else
					return false;
			}
		}
		#endregion

		#region Construcor�AOverloaded
		//�����s���X��
		public Contracts()
		{
			_syscd = "C4";
			_fgtemp = "1";
		}

//		public Contracts(string syscd, string contno)
//		{
//			string me = GetSingleContract(syscd, contno);
//
//			if (me == null || me == "")
//			{
//				throw new Exception("���J�X������");
//			}
//		}
		#endregion

		/*-------------------*/
		/*      Methods      */
		/*-------------------*/

		#region ���J�浧�X�����+�t�ӦW��+�Ȥ�W��
		/// <summary>
		/// ���J�浧�X�����+�t�ӦW��+�Ȥ�W��
		/// </summary>
		/// <param name="contno">�X���ѽs��</param>
		/// <returns>�X���Ѹ��</returns>
		public SqlDataReader GetSingleContractByContNo(string contno)
		{
			if (contno == "")
				throw new Exception("�X���s�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, " +
				"c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, " +
				"c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, " +
				"c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, " +
				"c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, " +
				"c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, " +
				"c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, " +
				"c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, " +
				"c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, " +
				"c4_cont.cont_credate, c4_cont.cont_moddate, " +
				"c4_cont.cont_modempno, c4_cont.cont_fgpayonce, " +
				"c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, " +
				"c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, " +
				"cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, " +
				"mfr.mfr_respnm, mfr.mfr_respjbti " +
				"FROM c4_cont INNER JOIN " +
				"cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN " +
				"mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno " +
				//"WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '0') AND " +
				"WHERE c4_cont.cont_contno='" + contno + "'";

			myConnection.Open();
			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			return dr;
		}
		#endregion

		#region �ѫȤ�s�����o�X����ơA���P�B�Ȧs�����b�n�D�d��
		/// <summary>
		/// �ѫȤ�s�����o�X����ơA���P�B�Ȧs�����b�n�D�d��
		/// </summary>
		/// <param name="custno">�Ȥ�s��</param>
		/// <returns>�X���Ѹ��</returns>
		public DataSet GetContractsByCustNo(string custno)
		{
			if (custno == "")
				throw new Exception("�Ȥ�s�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, " +
                        "c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, " +
                        "c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, " +
                        "c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, " +
                        "c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, " +
                        "c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, " +
                        "c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, " +
                        "c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, " +
                        "c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, " +
                        "c4_cont.cont_credate, c4_cont.cont_moddate, " +
                        "c4_cont.cont_modempno, c4_cont.cont_fgpayonce, " +
                        "c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, " +
                        "c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, " +
                        "cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm " +
						"FROM c4_cont INNER JOIN " +
                        "cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN " +
                        "mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno " +
						"WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '0') AND " +
						"c4_cont.cont_custno='" + custno + "'";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region ���o�Ȥ᪺�����X����ơAfgtemp='0' fgclose='0' fgcancel='0'
		public DataSet GetFormalContractsByCustNo(string custno)
		{
			if (custno == "")
				throw new Exception("�Ȥ�s�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, " +
				"c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, " +
				"c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, " +
				"c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, " +
				"c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, " +
				"c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, " +
				"c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, " +
				"c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, " +
				"c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, " +
				"c4_cont.cont_credate, c4_cont.cont_moddate, " +
				"c4_cont.cont_modempno, c4_cont.cont_fgpayonce, " +
				"c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, " +
				"c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, " +
				"cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm " +
				"FROM c4_cont INNER JOIN " +
				"cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN " +
				"mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno " +
				"WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '0') AND c4_cont.cont_fgclosed='0' AND " +
				"c4_cont.cont_custno='" + custno + "'";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			return ds;
		}
		#endregion

		#region �w���s�W�X����ơA���ɦX�����A���Ȧs�X��
		public string AddContract(string cont_empno)
		{
			if (cont_empno == "")
				throw new Exception("�~�ȭ��u�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_add_new_cont";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_cont_empno = new SqlParameter("@cont_empno", SqlDbType.Char, 7);
			param_cont_empno.Value = cont_empno;
			myCommand.Parameters.Add(param_cont_empno);

			SqlParameter param_cont_contno = new SqlParameter("@cont_contno", SqlDbType.Char, 6);
			param_cont_contno.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_cont_contno);			

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
			
			return Convert.ToString(param_cont_contno.Value);
		}
		#endregion

		#region �����x�s�s�W�X���A�u���O��update���ʧ@
		public bool UpdateToBeFormal
						(
							string cont_contno, 
							string cont_conttp, 
							string cont_signdate, 
							string cont_sdate, 
							string cont_edate, 
							string cont_empno, 
							string cont_mfrno, 
							string cont_custno, 
							string cont_aunm, 
							string cont_autel, 
							string cont_aufax, 
							string cont_aucell, 
							string cont_auemail, 
							int cont_freetm, 
							int cont_pubtm, 
							int cont_resttm, 
							int cont_totimgtm, 
							int cont_toturltm, 
							float cont_disc, 
							float cont_totamt, 
							float cont_paidamt, 
							float cont_restamt, 
							string cont_remark, 
							string cont_credate, 
							string cont_moddate, 
							string cont_modempno, 
							string cont_fgpayonce
						)
		{
			if (cont_contno == "")
				throw new Exception("�X���s���ťաA��ƿ��~�I");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_update_cont_to_be_formal";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_cont_contno = new SqlParameter("@cont_contno", SqlDbType.Char, 6);
			param_cont_contno.Value = cont_contno;
			myCommand.Parameters.Add(param_cont_contno);

			SqlParameter param_cont_conttp = new SqlParameter("@cont_conttp", SqlDbType.Char, 2);
			param_cont_conttp.Value = cont_conttp;
			myCommand.Parameters.Add(param_cont_conttp);

			SqlParameter param_cont_signdate = new SqlParameter("@cont_signdate", SqlDbType.Char, 8);
			param_cont_signdate.Value = cont_signdate;
			myCommand.Parameters.Add(param_cont_signdate);

			SqlParameter param_cont_sdate = new SqlParameter("@cont_sdate", SqlDbType.Char, 8);
			param_cont_sdate.Value = cont_sdate;
			myCommand.Parameters.Add(param_cont_sdate);

			SqlParameter param_cont_edate = new SqlParameter("@cont_edate", SqlDbType.Char, 8);
			param_cont_edate.Value = cont_edate;
			myCommand.Parameters.Add(param_cont_edate);

			SqlParameter param_cont_empno = new SqlParameter("@cont_empno", SqlDbType.Char, 7);
			param_cont_empno.Value = cont_empno;
			myCommand.Parameters.Add(param_cont_empno);

			SqlParameter param_cont_mfrno = new SqlParameter("@cont_mfrno", SqlDbType.Char, 10);
			param_cont_mfrno.Value = cont_mfrno;
			myCommand.Parameters.Add(param_cont_mfrno);

			SqlParameter param_cont_custno = new SqlParameter("@cont_custno", SqlDbType.Char, 6);
			param_cont_custno.Value = cont_contno;
			myCommand.Parameters.Add(param_cont_custno);

			SqlParameter param_cont_aunm = new SqlParameter("@cont_aunm", SqlDbType.VarChar, 30);
			param_cont_aunm.Value = cont_aunm;
			myCommand.Parameters.Add(param_cont_aunm);

			SqlParameter param_cont_autel = new SqlParameter("@cont_autel", SqlDbType.VarChar, 30);
			param_cont_autel.Value = cont_autel;
			myCommand.Parameters.Add(param_cont_autel);

			SqlParameter param_cont_aufax = new SqlParameter("@cont_aufax", SqlDbType.VarChar, 30);
			param_cont_aufax.Value = cont_aufax;
			myCommand.Parameters.Add(param_cont_aufax);

			SqlParameter param_cont_aucell = new SqlParameter("@cont_aucell", SqlDbType.VarChar, 30);
			param_cont_aucell.Value = cont_aucell;
			myCommand.Parameters.Add(param_cont_aucell);

			SqlParameter param_cont_auemail = new SqlParameter("@cont_auemail", SqlDbType.VarChar, 80);
			param_cont_auemail.Value = cont_auemail;
			myCommand.Parameters.Add(param_cont_auemail);

			SqlParameter param_cont_freetm = new SqlParameter("@cont_freetm", SqlDbType.Int);
			param_cont_freetm.Value = cont_freetm;
			myCommand.Parameters.Add(param_cont_freetm);

			SqlParameter param_cont_pubtm = new SqlParameter("@cont_pubtm", SqlDbType.Int);
			param_cont_pubtm.Value = cont_pubtm;
			myCommand.Parameters.Add(param_cont_pubtm);

			SqlParameter param_cont_resttm = new SqlParameter("@cont_resttm", SqlDbType.Int);
			param_cont_resttm.Value = cont_resttm;
			myCommand.Parameters.Add(param_cont_resttm);

			SqlParameter param_cont_totimgtm = new SqlParameter("@cont_totimgtm", SqlDbType.Int);
			param_cont_totimgtm.Value = cont_totimgtm;
			myCommand.Parameters.Add(param_cont_totimgtm);

			SqlParameter param_cont_toturltm = new SqlParameter("@cont_toturltm", SqlDbType.Int);
			param_cont_toturltm.Value = cont_toturltm;
			myCommand.Parameters.Add(param_cont_toturltm);

			SqlParameter param_cont_disc = new SqlParameter("@cont_disc", SqlDbType.Real);
			param_cont_disc.Value = cont_disc;
			myCommand.Parameters.Add(param_cont_disc);

			SqlParameter param_cont_totamt = new SqlParameter("@cont_totamt", SqlDbType.Real);
			param_cont_totamt.Value = cont_totamt;
			myCommand.Parameters.Add(param_cont_totamt);

			SqlParameter param_cont_paidamt = new SqlParameter("@cont_paidamt", SqlDbType.Real);
			param_cont_paidamt.Value = cont_paidamt;
			myCommand.Parameters.Add(param_cont_paidamt);

			SqlParameter param_cont_restamt = new SqlParameter("@cont_restamt", SqlDbType.Real);
			param_cont_restamt.Value = cont_restamt;
			myCommand.Parameters.Add(param_cont_restamt);

			SqlParameter param_cont_remark = new SqlParameter("@cont_remark", SqlDbType.VarChar, 50);
			param_cont_remark.Value = cont_remark;
			myCommand.Parameters.Add(param_cont_remark);

			SqlParameter param_cont_credate = new SqlParameter("@cont_credate", SqlDbType.Char, 8);
			param_cont_credate.Value = cont_credate;
			myCommand.Parameters.Add(param_cont_credate);

			SqlParameter param_cont_moddate = new SqlParameter("@cont_moddate", SqlDbType.Char, 8);
			param_cont_moddate.Value = cont_moddate;
			myCommand.Parameters.Add(param_cont_moddate);

			SqlParameter param_cont_modempno = new SqlParameter("@cont_modempno", SqlDbType.Char, 7);
			param_cont_modempno.Value = cont_modempno;
			myCommand.Parameters.Add(param_cont_modempno);

			SqlParameter param_cont_fgpayonce = new SqlParameter("@cont_fgpayonce", SqlDbType.Char, 1);
			param_cont_fgpayonce.Value = cont_fgpayonce;
			myCommand.Parameters.Add(param_cont_fgpayonce);

			//OUTPUT Parameter
			SqlParameter param_success = new SqlParameter("@success", SqlDbType.Int);
			param_success.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_success);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();

			//�x�s���\��return true
			if (Convert.ToInt32(param_success.Value) == 1)
				return true;
			else
				return false;
		}
		#endregion

		#region ���o�X�������p��ƥ�-�w�����ѼơB�w�}�ߵo�����B
		public SqlDataReader GetContCounts(string contno)
		{
			if (contno == "")
				throw new Exception("�X���s�����i���ť�");

//			if (cont_empno == "")
//				throw new Exception("�~�ȭ��u�����i���ť�");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_get_cont_conts";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_adrd_contno = new SqlParameter("@adrd_contno", SqlDbType.Char, 6);
			param_adrd_contno.Value = contno;
			myCommand.Parameters.Add(param_adrd_contno);
			
			//OUTPUT Parameters
			SqlParameter param_pubedtm = new SqlParameter("@pubedtm", SqlDbType.Int);
			param_pubedtm.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_pubedtm);	

			SqlParameter param_paidamt = new SqlParameter("@paidamt", SqlDbType.Float);
			param_paidamt.Direction = ParameterDirection.Output;
			myCommand.Parameters.Add(param_paidamt);	

			myConnection.Open();
			SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			return dr;
		}
		#endregion

		#region ��s�X���A���@�X����
		public void UpdateCont
			(
			string cont_contno, 
			string cont_conttp, 
			string cont_signdate, 
			string cont_sdate, 
			string cont_edate, 
			string cont_empno, 
			//string cont_mfrno, ���i�H�ק�t��
			//string cont_custno, ���i�ק�Ȥ�
			string cont_aunm, 
			string cont_autel, 
			string cont_aufax, 
			string cont_aucell, 
			string cont_auemail, 
			int cont_freetm, 
			int cont_pubtm, 
			int cont_resttm, 
			int cont_totimgtm, 
			int cont_toturltm, 
			float cont_disc, 
			float cont_totamt, 
			float cont_paidamt, 
			float cont_restamt, 
			string cont_remark, 
			string cont_moddate, 
			string cont_modempno, 
			string cont_fgpayonce
			)
		{
			if (cont_contno == "")
				throw new Exception("�X���s���ťաA��ƿ��~�I");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_update_cont";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// �]�wParameter
			SqlParameter param_cont_contno = new SqlParameter("@cont_contno", SqlDbType.Char, 6);
			param_cont_contno.Value = cont_contno;
			myCommand.Parameters.Add(param_cont_contno);

			SqlParameter param_cont_conttp = new SqlParameter("@cont_conttp", SqlDbType.Char, 2);
			param_cont_conttp.Value = cont_conttp;
			myCommand.Parameters.Add(param_cont_conttp);

			SqlParameter param_cont_signdate = new SqlParameter("@cont_signdate", SqlDbType.Char, 8);
			param_cont_signdate.Value = cont_signdate;
			myCommand.Parameters.Add(param_cont_signdate);

			SqlParameter param_cont_sdate = new SqlParameter("@cont_sdate", SqlDbType.Char, 8);
			param_cont_sdate.Value = cont_sdate;
			myCommand.Parameters.Add(param_cont_sdate);

			SqlParameter param_cont_edate = new SqlParameter("@cont_edate", SqlDbType.Char, 8);
			param_cont_edate.Value = cont_edate;
			myCommand.Parameters.Add(param_cont_edate);

			SqlParameter param_cont_empno = new SqlParameter("@cont_empno", SqlDbType.Char, 7);
			param_cont_empno.Value = cont_empno;
			myCommand.Parameters.Add(param_cont_empno);

			/* ���i�ק�t�ӫȤ�
			SqlParameter param_cont_mfrno = new SqlParameter("@cont_mfrno", SqlDbType.Char, 10);
			param_cont_mfrno.Value = cont_mfrno;
			myCommand.Parameters.Add(param_cont_mfrno);

			SqlParameter param_cont_custno = new SqlParameter("@cont_custno", SqlDbType.Char, 6);
			param_cont_custno.Value = cont_contno;
			myCommand.Parameters.Add(param_cont_custno);
			*/

			SqlParameter param_cont_aunm = new SqlParameter("@cont_aunm", SqlDbType.VarChar, 30);
			param_cont_aunm.Value = cont_aunm;
			myCommand.Parameters.Add(param_cont_aunm);

			SqlParameter param_cont_autel = new SqlParameter("@cont_autel", SqlDbType.VarChar, 30);
			param_cont_autel.Value = cont_autel;
			myCommand.Parameters.Add(param_cont_autel);

			SqlParameter param_cont_aufax = new SqlParameter("@cont_aufax", SqlDbType.VarChar, 30);
			param_cont_aufax.Value = cont_aufax;
			myCommand.Parameters.Add(param_cont_aufax);

			SqlParameter param_cont_aucell = new SqlParameter("@cont_aucell", SqlDbType.VarChar, 30);
			param_cont_aucell.Value = cont_aucell;
			myCommand.Parameters.Add(param_cont_aucell);

			SqlParameter param_cont_auemail = new SqlParameter("@cont_auemail", SqlDbType.VarChar, 80);
			param_cont_auemail.Value = cont_auemail;
			myCommand.Parameters.Add(param_cont_auemail);

			SqlParameter param_cont_freetm = new SqlParameter("@cont_freetm", SqlDbType.Int);
			param_cont_freetm.Value = cont_freetm;
			myCommand.Parameters.Add(param_cont_freetm);

			SqlParameter param_cont_pubtm = new SqlParameter("@cont_pubtm", SqlDbType.Int);
			param_cont_pubtm.Value = cont_pubtm;
			myCommand.Parameters.Add(param_cont_pubtm);

			SqlParameter param_cont_resttm = new SqlParameter("@cont_resttm", SqlDbType.Int);
			param_cont_resttm.Value = cont_resttm;
			myCommand.Parameters.Add(param_cont_resttm);

			SqlParameter param_cont_totimgtm = new SqlParameter("@cont_totimgtm", SqlDbType.Int);
			param_cont_totimgtm.Value = cont_totimgtm;
			myCommand.Parameters.Add(param_cont_totimgtm);

			SqlParameter param_cont_toturltm = new SqlParameter("@cont_toturltm", SqlDbType.Int);
			param_cont_toturltm.Value = cont_toturltm;
			myCommand.Parameters.Add(param_cont_toturltm);

			SqlParameter param_cont_disc = new SqlParameter("@cont_disc", SqlDbType.Real);
			param_cont_disc.Value = cont_disc;
			myCommand.Parameters.Add(param_cont_disc);

			SqlParameter param_cont_totamt = new SqlParameter("@cont_totamt", SqlDbType.Real);
			param_cont_totamt.Value = cont_totamt;
			myCommand.Parameters.Add(param_cont_totamt);

			SqlParameter param_cont_paidamt = new SqlParameter("@cont_paidamt", SqlDbType.Real);
			param_cont_paidamt.Value = cont_paidamt;
			myCommand.Parameters.Add(param_cont_paidamt);

			SqlParameter param_cont_restamt = new SqlParameter("@cont_restamt", SqlDbType.Real);
			param_cont_restamt.Value = cont_restamt;
			myCommand.Parameters.Add(param_cont_restamt);

			SqlParameter param_cont_remark = new SqlParameter("@cont_remark", SqlDbType.VarChar, 50);
			param_cont_remark.Value = cont_remark;
			myCommand.Parameters.Add(param_cont_remark);

			SqlParameter param_cont_moddate = new SqlParameter("@cont_moddate", SqlDbType.Char, 8);
			param_cont_moddate.Value = cont_moddate;
			myCommand.Parameters.Add(param_cont_moddate);

			SqlParameter param_cont_modempno = new SqlParameter("@cont_modempno", SqlDbType.Char, 7);
			param_cont_modempno.Value = cont_modempno;
			myCommand.Parameters.Add(param_cont_modempno);

			SqlParameter param_cont_fgpayonce = new SqlParameter("@cont_fgpayonce", SqlDbType.Char, 1);
			param_cont_fgpayonce.Value = cont_fgpayonce;
			myCommand.Parameters.Add(param_cont_fgpayonce);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}
		#endregion

		#region ��s�X���A�x�s���@���~�]�Ƥ���B�j�M�����B�s�i���s����
		public void UpdateContSearch(string cont_contno, string cont_ccont, string cont_pdcont, string cont_csdate)
		{
			if (cont_contno == "")
				throw new Exception("�X���s���ťաA��ƿ��~�I");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "UPDATE c4_cont SET cont_ccont=@cont_ccont, cont_pdcont=@cont_pdcont, cont_csdate=@cont_csdate WHERE cont_syscd='C4' AND cont_contno=@cont_contno";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.Text;

			// �]�wParameter
			SqlParameter param_cont_contno = new SqlParameter("@cont_contno", SqlDbType.Char, 6);
			param_cont_contno.Value = cont_contno;
			myCommand.Parameters.Add(param_cont_contno);

			SqlParameter param_cont_ccont = new SqlParameter("@cont_ccont", SqlDbType.VarChar, 50);
			param_cont_ccont.Value = cont_ccont;
			myCommand.Parameters.Add(param_cont_ccont);

			SqlParameter param_cont_pdcont = new SqlParameter("@cont_pdcont", SqlDbType.VarChar, 500);
			param_cont_pdcont.Value = cont_pdcont;
			myCommand.Parameters.Add(param_cont_pdcont);

			SqlParameter param_cont_csdate = new SqlParameter("@cont_csdate", SqlDbType.Char, 8);
			param_cont_csdate.Value = cont_csdate;
			myCommand.Parameters.Add(param_cont_csdate);

			myConnection.Open();
			myCommand.ExecuteNonQuery();
			myConnection.Close();
		}
		#endregion
	}
}
