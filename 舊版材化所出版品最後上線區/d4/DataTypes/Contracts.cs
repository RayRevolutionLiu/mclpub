using System;
using System.Data;
using System.Data.SqlClient;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.DataTypes
{
	/// <summary>
	/// C4合約
	/// </summary>
	public class Contracts
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
//				throw new Exception("載入合約失敗");
//			}
//		}
		#endregion

		/*-------------------*/
		/*      Methods      */
		/*-------------------*/

		#region 載入單筆合約資料+廠商名稱+客戶名稱
		/// <summary>
		/// 載入單筆合約資料+廠商名稱+客戶名稱
		/// </summary>
		/// <param name="contno">合約書編號</param>
		/// <returns>合約書資料</returns>
		public SqlDataReader GetSingleContractByContNo(string contno)
		{
			if (contno == "")
				throw new Exception("合約編號不可為空白");

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

		#region 由客戶編號取得合約資料，註銷、暫存的不在要求範圍內
		/// <summary>
		/// 由客戶編號取得合約資料，註銷、暫存的不在要求範圍內
		/// </summary>
		/// <param name="custno">客戶編號</param>
		/// <returns>合約書資料</returns>
		public DataSet GetContractsByCustNo(string custno)
		{
			if (custno == "")
				throw new Exception("客戶編號不可為空白");

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

		#region 取得客戶的正式合約資料，fgtemp='0' fgclose='0' fgcancel='0'
		public DataSet GetFormalContractsByCustNo(string custno)
		{
			if (custno == "")
				throw new Exception("客戶編號不可為空白");

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

		#region 預先新增合約資料，此時合約狀態為暫存合約
		public string AddContract(string cont_empno)
		{
			if (cont_empno == "")
				throw new Exception("業務員工號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_add_new_cont";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
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

		#region 正式儲存新增合約，真正是做update的動作
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
				throw new Exception("合約編號空白，資料錯誤！");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_update_cont_to_be_formal";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
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

			//儲存成功救return true
			if (Convert.ToInt32(param_success.Value) == 1)
				return true;
			else
				return false;
		}
		#endregion

		#region 取得合約相關計算數目-已落版天數、已開立發票金額
		public SqlDataReader GetContCounts(string contno)
		{
			if (contno == "")
				throw new Exception("合約編號不可為空白");

//			if (cont_empno == "")
//				throw new Exception("業務員工號不可為空白");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_get_cont_conts";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
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

		#region 更新合約，維護合約用
		public void UpdateCont
			(
			string cont_contno, 
			string cont_conttp, 
			string cont_signdate, 
			string cont_sdate, 
			string cont_edate, 
			string cont_empno, 
			//string cont_mfrno, 不可以修改廠商
			//string cont_custno, 不可修改客戶
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
				throw new Exception("合約編號空白，資料錯誤！");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "sp_c4_update_cont";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			// 設定Parameter
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

			/* 不可修改廠商客戶
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

		#region 更新合約，儲存維護產品設備內文、搜尋期限、廣告推廣內文
		public void UpdateContSearch(string cont_contno, string cont_ccont, string cont_pdcont, string cont_csdate)
		{
			if (cont_contno == "")
				throw new Exception("合約編號空白，資料錯誤！");

			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "UPDATE c4_cont SET cont_ccont=@cont_ccont, cont_pdcont=@cont_pdcont, cont_csdate=@cont_csdate WHERE cont_syscd='C4' AND cont_contno=@cont_contno";

			SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
			myCommand.CommandType = CommandType.Text;

			// 設定Parameter
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
