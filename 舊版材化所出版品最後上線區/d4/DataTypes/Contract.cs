using System;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// C4合約
	/// </summary>
	public class Contract
	{
		#region private members，Table中的欄位
		//系統代號
		private string _syscd;
		//合約編號
		private string _contno;
		//客戶編號
		private string _custno;
		//合約類別
		private string _conttp;
		//簽約日期
		private string _signdate;
		//合約開始日期
		private string _sdate;
		//合約結束日期
		private string _edate;
		//簽約業務員工號
		private string _empno;
		//廠商編號
		private string _mfrno;
		
		//廣告範圍(頁面)，此欄停用中
		private string _pubcate;

		//聯絡人姓名
		private string _aunm;
		//聯絡人電話
		private string _autel;
		//聯絡人傳真號碼
		private string _aufax;
		//聯絡人行動電話
		private string _aucell;
		//聯絡人電子郵件地址
		private string _aumail;
		//優惠折數
		private float _disc;
		//贈送次數
		private int _freetm;
		//總製圖稿次數
		private int _totimgtm;
		//總製網頁稿次數
		private int _toturltm;
		//已刊登(落版)次數
		private int _pubtm;
		//剩餘刊登(落版)次數
		private int _resttm;
		//合約總金額
		private float _totamt;
		//已付金額
		private float _paidamt;
		//剩餘金額
		private float _resamt;
		//廣告推廣內文
		private string _ccont;
		//廣告推廣內文搜尋期限
		private string _csdate;

		//產業帶碼，無法使用這個欄位表示資料
		private string _atp;
		//材料特性代碼，無法使用這個欄位表示資料
		private string _matp;

		//結案註記
		private string _fgclosed;
		//合約備註
		private string _adremark;
		//合約特別備註
		private string _adsprem;
		//產品設備內文
		private string _pdcont;
		//合約修改日期
		private string _moddate;
		//一次付款註記
		private string _fgpayonce;
		//合約暫存註記
		private string _fgtemp;
		//廣告已播出註記
		private string _fgpubed;
		//合約註銷註記
		private string _fgcancel;
		//合約修改員工編號
		private string _modempno;
		//合約初始日期
		private string _credate;
		#endregion

		#region Properties，跟隨欄位產生
		//系統代號，唯讀
		public string SysCd
		{
			get
			{
				return _syscd;
			}
		}

		//合約編號，唯讀
		public string ContNo
		{
			get
			{
				return _contno;
			}
		}

		//客戶編號
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

		//合約類別
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

		//簽約日期
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

		//合約開始日期
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

		//合約結束日期
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

		//簽約業務員工號
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
		//廠商編號
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

		//廣告範圍(頁面)，此欄停用中
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

		//聯絡人姓名
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

		//聯絡人電話
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

		//聯絡人傳真號碼
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

		//聯絡人行動電話
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

		//聯絡人電子郵件地址
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

		//優惠折數
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
		//贈送次數
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
		//總製圖稿次數
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

		//總製網頁稿次數
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

		//已刊登(落版)次數
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
		//剩餘刊登(落版)次數
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

		//合約總金額
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

		//已付金額
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

		//剩餘金額
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

		//廣告推廣內文
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

		//廣告推廣內文搜尋期限
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

		//產業帶碼，無法使用這個欄位表示資料
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

		//材料特性代碼，無法使用這個欄位表示資料
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
		//結案註記
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

		//合約備註
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

		//合約特別備註
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

		//產品設備內文
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

		//合約修改日期
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

		//一次付款註記
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

		//合約暫存註記??????????????????????????????
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

		//廣告已播出註記???????????????????????????
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

		//合約註銷註記????????????????????????????
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

		//合約修改員工編號
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

		//合約初始日期
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

		#region Properties，衍生Property
		//是註銷的合約？
		public bool IsCanceled
		{
			get
			{
				if (_fgcancel == null)
					throw new Exception("尚未載入合約資料");

				if (_fgcancel == "1")
					return true;
				else
					return false;
			}
		}

		//是暫存的合約？
		public bool IsTemp
		{
			get
			{
				if (_fgtemp == null)
					throw new Exception("尚未載入合約資料");

				if (_fgtemp == "1")
					return true;
				else
					return false;
			}
		}

		//已經廣告過了？
		public bool IsPubed
		{
			get
			{
				if (_fgpubed == null)
					throw new Exception("尚未載入合約資料");

				if (_fgpubed == "1")
					return true;
				else
					return false;
			}		
		}

		//是一次付款的？
		public bool IsPayOnce
		{
			get
			{
				if (_fgpayonce == null)
					throw new Exception("尚未載入合約資料");

				if (_fgpayonce == "1")
					return true;
				else
					return false;
			}
		}

		//是結案合約
		public bool IsClosed
		{
			get
			{
				if (_fgclosed == null)
					throw new Exception("尚未載入合約資料");

				if (_fgclosed == "1")
					return true;
				else
					return false;
			}
		}
		#endregion

		#region Construcor，Overloaded
		//完全新的合約
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
				throw new Exception("載入合約失敗");
			}
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// 載入單筆合約資料
		/// </summary>
		/// <param name="syscd">系統代碼</param>
		/// <param name="contno">合約編號</param>
		/// <returns>如果成功就回傳合約編號，反之則傳回空字串</returns>
		public string GetSingleContract(string syscd, string contno)
		{
			if (syscd == "" || contno == "")
				throw new Exception("系統代碼或合約編號不可為空白");

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
