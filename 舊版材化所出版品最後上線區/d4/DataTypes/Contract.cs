using System;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// C4�X��
	/// </summary>
	public class Contract
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
		public Contract()
		{
			_syscd = "C4";
			_fgtemp = "1";
		}

		public Contract(string syscd, string contno)
		{
			string me = GetSingleContract(syscd, contno);

			if (me == null || me == "")
			{
				throw new Exception("���J�X������");
			}
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// ���J�浧�X�����
		/// </summary>
		/// <param name="syscd">�t�ΥN�X</param>
		/// <param name="contno">�X���s��</param>
		/// <returns>�p�G���\�N�^�ǦX���s���A�Ϥ��h�Ǧ^�Ŧr��</returns>
		public string GetSingleContract(string syscd, string contno)
		{
			if (syscd == "" || contno == "")
				throw new Exception("�t�ΥN�X�ΦX���s�����i���ť�");

			//
			// Load From DB and Assign fields
			//
			bool IsExist = false;
			if (IsExist)
			{
				return "the contno";
			}
			else
			{
				return "";
			}
		}
		#endregion
	}
}
