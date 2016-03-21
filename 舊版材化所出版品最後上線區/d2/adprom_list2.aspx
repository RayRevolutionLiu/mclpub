<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告推廣戶清單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="cont_list2" method="post" runat="server">
			<%
				'-----------------------------------------------------------------------------
				' Reference Sample: vba_autofit.asp - Excel SpeedGen ASP Sample Script for ASP.NET
				' (c) 2000-2001 Optimized Software Ltd. All Rights Reserved.
				'-----------------------------------------------------------------------------
				' This script demonstrates:
				'  - Reading ADO RecordSets
				'  - running VBA code on Workbook open
				'
				' Notes:
				'  - Do NOT write any HTML or use Response.Write!
				'  - Server Side (or no) Cursors can cause queries (and stored procedures) to
				'    be executed multiple times! Using a Client Side Cursor will prevent this.
				'-----------------------------------------------------------------------------
				' Tip: Code Library at http://www.excelspeedgen.com/code
				'-----------------------------------------------------------------------------
				Dim dbFile		' Database File
				Dim oConn		' ADO Connection object
				Dim DSN			' Web Application Name

				Dim Rs1, Rs2, Rs4, Rs5			' Record Source 1 ~ 5
				Dim Rs9, RS10
				Dim sqlcmd1, sqlcmd2, sqlcmd4, sqlcmd5	' SQL Command 1 ~ 5
				Dim sqlcmd9, sqlcmd10
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' 自訂 sql 變數
				Dim strBkcd, strEmpNo, strConttp

				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName, BkName, strLoginEmpNo, strLoginEmpCName
				Dim strConttpName


				' Open Database------------------
				' a. Open a Microsoft Access Database
					'dbFile = Server.MapPath("test.mdb")
					'oConn = Server.CreateObject("ADODB.Connection")
					'oConn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFile)

				' b. Open a Microsoft SQL Server Database
					'DSN = ConfigurationSettings.AppSettings("isccom1_mrlpub_esg")
					'DSN = ConfigurationSettings.AppSettings("isccom1_mrltest_esg")
					DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")

				' 自前一頁抓傳遞 form 網頁變數 empno, 以抓出 EmpNo, EmpCName
				strConttp = Request("conttp")
				strBkcd = Request("bkcd")
				'strEmpNo = Request("empno")
				strLoginEmpNo = Request("LEmpNo")

				' 依合約類別代碼指定其名稱
				if(strConttp="01")
					strConttpName = "一般合約"
				end if
				if(strConttp="09")
					strConttpName = "推廣合約"
				end if
				'Response.Write("strConttpName= " & strConttpName & "<br>")


				' Get Rs5: 藉書籍代碼抓出書籍名稱
				if(strBkcd <> "") then
					strBkcd = strBkcd

					' Open the RecordSets
					sqlcmd5 = "SELECT * FROM book"
					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
					Rs5 = oConn.Execute(sqlcmd5)
					BkName = Rs5("bk_nm").Value
					'Response.Write("BkName= " & BkName & "<br>")
				else
					strBkcd = ""
				end if

				' Get Rs4: 藉業務員工號抓出業務員姓名
				'if(Request("empno") <> "") then
					'strEmpNo = strEmpNo

					' Open the RecordSets
					'sqlcmd4 = "SELECT * FROM srspn"
					'sqlcmd4 = sqlcmd4 & " WHERE (srspn_empno='" + strEmpNo + "')"
					'Rs4 = oConn.Execute(sqlcmd4)
					'EmpCName = TRIM(Rs4("srspn_cname").Value)
					''Response.Write("EmpCName= " & EmpCName & "<br>")
				'else
					'strEmpNo = ""
					'EmpCName = "(所有)"
				'end if

				if(Request("LEmpNo") <> "") then
					strLoginEmpNo = strLoginEmpNo

					' Get Rs9: 藉登入業務員工號抓出姓名
					' Open the RecordSets
					sqlcmd9 = "SELECT * FROM srspn"
					sqlcmd9 = sqlcmd9 & " WHERE (srspn_empno='" + strLoginEmpNo + "')"
					Rs9 = oConn.Execute(sqlcmd9)
					strLoginEmpCName = Trim(Rs9("srspn_cname").Value)
					'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")
				else
					strLoginEmpNo = ""
					strLoginEmpCName = ""
				end if


				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno, RTRIM(c2_cont.cont_custno) AS cont_custno, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(mfr.mfr_inm) "
				sqlcmd2 = sqlcmd2 & " AS mfr_inm, RTRIM(cust.cust_nm) AS cust_nm, RTRIM(cust.cust_jbti) "
				sqlcmd2 = sqlcmd2 & " AS cust_jbti, cust.cust_tel, cust.cust_fax, cust.cust_cell, "
				sqlcmd2 = sqlcmd2 & " cust.cust_email, cust.cust_regdate, cust.cust_moddate, "
				sqlcmd2 = sqlcmd2 & " cust.cust_itpcd, cust.cust_btpcd, cust.cust_rtpcd, "
				sqlcmd2 = sqlcmd2 & " mfr.mfr_respnm, RTRIM(mfr.mfr_respjbti) AS mfr_respjbti, "
				sqlcmd2 = sqlcmd2 & " RTRIM(mfr.mfr_izip) AS mfr_izip, RTRIM(mfr.mfr_iaddr) AS mfr_iaddr, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_syscd, cust.cust_custno, mfr.mfr_mfrno, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_conttp, RTRIM(c2_cont.cont_empno) "
				sqlcmd2 = sqlcmd2 & " AS cont_empno, RTRIM(srspn.srspn_cname) AS srspn_cname, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_sdate, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_edate, c2_cont.cont_aunm, c2_cont.cont_autel "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " srspn ON c2_cont.cont_empno = srspn.srspn_empno "
				sqlcmd2 = sqlcmd2 & " WHERE         (c2_cont.cont_fgclosed = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (cont_conttp = '" & strConttp & "') "
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd2 = sqlcmd2 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				'if(Request("empno") <> "") then
					'strEmpNo = Request("empno")
					'sqlcmd2 = sqlcmd2 & " AND (cont_empno = '" & strEmpNo & "') "
				'else
					'sqlcmd2 = sqlcmd2
				'end if
				sqlcmd2 = sqlcmd2 & " ) DRIVERTBL "

				' Open the RecordSets
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescount = 0
					Response.Write ("<FONT Color=Red><B>查詢結果 - 筆數為 0</B></FONT><BR>")
				else
					rescount = Rs2(0).Value
				end if
				'Response.Write("rescount= " & rescount & "<br>")


				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT DISTINCT"
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno, RTRIM(c2_cont.cont_custno) AS cont_custno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(mfr.mfr_inm) "
				sqlcmd1 = sqlcmd1 & " AS mfr_inm, RTRIM(cust.cust_nm) AS cust_nm, RTRIM(cust.cust_jbti) "
				sqlcmd1 = sqlcmd1 & " AS cust_jbti, cust.cust_tel, cust.cust_fax, cust.cust_cell, "
				sqlcmd1 = sqlcmd1 & " cust.cust_email, cust.cust_regdate, cust.cust_moddate, "
				sqlcmd1 = sqlcmd1 & " cust.cust_itpcd, cust.cust_btpcd, cust.cust_rtpcd, "
				sqlcmd1 = sqlcmd1 & " mfr.mfr_respnm, RTRIM(mfr.mfr_respjbti) AS mfr_respjbti, "
				sqlcmd1 = sqlcmd1 & " RTRIM(mfr.mfr_izip) AS mfr_izip, RTRIM(mfr.mfr_iaddr) AS mfr_iaddr, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_syscd, cust.cust_custno, mfr.mfr_mfrno, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_conttp, RTRIM(c2_cont.cont_empno) "
				sqlcmd1 = sqlcmd1 & " AS cont_empno, RTRIM(srspn.srspn_cname) AS srspn_cname, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_sdate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_edate, c2_cont.cont_aunm, c2_cont.cont_autel "
				sqlcmd1 = sqlcmd1 & " FROM             c2_cont INNER JOIN "
				sqlcmd1 = sqlcmd1 & " cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " srspn ON c2_cont.cont_empno = srspn.srspn_empno "
				sqlcmd1 = sqlcmd1 & " WHERE         (c2_cont.cont_fgclosed = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd1 = sqlcmd1 & " AND (cont_conttp = '" & strConttp & "') "
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd1 = sqlcmd1 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				'if(Request("empno") <> "") then
					'strEmpNo = Request("empno")
					'sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & strEmpNo & "') "
				'else
					'sqlcmd1 = sqlcmd1
				'end if
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "


				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)

				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("sqlcmd4= " & sqlcmd4 & "<br><br>")
					'Response.Write("Rs4= " & Rs4(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")

				' 若有資料, 則輸出至 ExcelSpeedGen
				else
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")

					' Array 1
					ReDim A1(rescount*2,13)

					' Populate Array 1
					Dim LineNo
					LineNo = 0
					for i = 0 to rescount*2 - 1 step 2
						' 測試是否抓的到 result (但要先把 XLS.Generate() 那行 disable, 才看得到 Response.Write 結果)
						'Response.Write(Rs1("cont_contno").Value & ", ")
						'Response.Write(Rs1("cont_custno").Value & ", ")
						'Response.Write(Rs1("cont_mfrno").Value & ", ")
						'Response.Write(Rs1("mfr_inm).Value & ", ")
						'Response.Write(Rs1("cust_nm").Value & "<br>")

						Dim conttpText
						conttpText = ""
						if(Rs1("cont_conttp").Value <> "") then
							if(Rs1("cont_conttp").Value = "01") Then
								conttpText = "一般"
							end if
							if(Rs1("cont_conttp").Value = "09") Then
								conttpText = "推廣"
							end if
						end if

						' A 欄 = A1(i,0)
						LineNo = LineNo + 1
						A1(i,0) = LineNo
						A1(i+1,0) = ""
						A1(i,1) = Rs1("cont_contno").Value
						A1(i+1,1) = ""
						A1(i,2) = Rs1("cont_custno").Value
						A1(i+1,2) = Trim(Rs1("mfr_respnm").Value)
						A1(i,3) = Rs1("cont_mfrno").Value
						A1(i+1,3) = Rs1("mfr_respjbti").Value

						' E 欄 = A1(i,4)
						A1(i,4) = Rs1("mfr_inm").Value
						A1(i+1,4) = Rs1("mfr_izip").Value & " " & Rs1("mfr_iaddr").Value
						A1(i,5) = Rs1("cust_nm").Value
						A1(i+1,5) = Mid(Rs1("cont_signdate").Value, 1, 4) & "/" & Mid(Rs1("cont_signdate").Value, 5, 2) & "/" & Mid(Rs1("cont_signdate").Value, 7, 2)
						A1(i,6) = Rs1("cust_jbti").Value
						A1(i+1,6) = Mid(Rs1("cont_sdate").Value, 1, 4) & "/" & Mid(Rs1("cont_sdate").Value, 5, 2)
						A1(i,7) = Rs1("cust_tel").Value
						A1(i+1,7) = Mid(Rs1("cont_edate").Value, 1, 4) & "/" & Mid(Rs1("cont_edate").Value, 5, 2)

						' I 欄 = A1(i,8)
						A1(i,8) = Rs1("cust_fax").Value
						A1(i+1,8) = Rs1("srspn_cname").Value
						A1(i,9) = Rs1("cust_cell").Value
						A1(i+1,9) = Rs1("cont_aunm").Value
						A1(i,10) = Rs1("cust_email").Value
						A1(i+1,10) = Rs1("cont_autel").Value
						if(Trim(Rs1("cust_regdate").Value) <> "") Then
							A1(i,11) = Mid(Rs1("cust_regdate").Value, 1, 4) & "/" & Mid(Rs1("cust_regdate").Value, 5, 2) & "/" & Mid(Rs1("cust_regdate").Value, 7, 2)
						else
							A1(i,11) = ""
						end if
						A1(i+1,11) = ""

						' M 欄 = A1(i,12)
						if(Trim(Rs1("cust_moddate").Value) <> "") Then
							A1(i,12) = Mid(Rs1("cust_moddate").Value, 1, 4) & "/" & Mid(Rs1("cust_moddate").Value, 5, 2) & "/" & Mid(Rs1("cust_moddate").Value, 7, 2)
						else
							A1(i,12) = ""
						end if
						A1(i+1,12) = ""


						' 此為特別欄位使用的格式 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 特別格式寫在 sheet 2 的指定欄位裡, 如 A5, A6; B5, B6
						Dim Discounthighlight, Amounthighlight1, Amounthighlight2, Amounthighlight3
						Discounthighlight =  "L" & (9+i)
						Amounthighlight1 = "H" & (9+i)
						Amounthighlight2 = "I" & (9+i)
						Amounthighlight3 = "J" & (9+i)
						if (i mod 4) = 0 then
							' 奇數行, 以 A5 的 貨幣 Format 顯示
							'XLS.FormatCells( 1, Discounthighlight, 2, "A9", false )
							'XLS.FormatCells( 1, Amounthighlight1, 2, "A5", false )
							'XLS.FormatCells( 1, Amounthighlight2, 2, "A5", false )
							'XLS.FormatCells( 1, Amounthighlight3, 2, "A5", false )
						else
							' 偶數行, 以 B5 的 貨幣 Format 顯示
							'XLS.FormatCells( 1, Discounthighlight, 2, "B9", false )
							'XLS.FormatCells( 1, Amounthighlight1, 2, "B5", false )
							'XLS.FormatCells( 1, Amounthighlight2, 2, "B5", false )
							'XLS.FormatCells( 1, Amounthighlight3, 2, "B5", false )
						end if

						' Highlight Some Rows: 此為一般欄位使用的格式
						Dim highlight
						highlight = "A" & (7+i) & ":M" & (8+i)
						if (i mod 4) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false )
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )
						end if
						Rs1.MoveNext

						if Rs1.EOF
	    						exit for
						end if
					next

					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it
					XLS.HideSheet( 3, true )  ' Hide it so user cannot unhide it
					XLS.HideSheet( 4, true )  ' Hide it so user cannot unhide it

					' Set Estimated Output File Size (Critical for speed)
					XLS.EstimatedSize = 50000

					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )

					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("conttp_Name", strConttpName)	' >>$conttp_Name
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					'XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					'Response.Write("EmpCName= " & EmpCName & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("adprom_list2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "adprom_list2.xls", True)

					' Destroy object when done
					XLS = Nothing

					' Cleanup Code - Close Connection and all Recordsets
					oConn.close
					oConn = Nothing
				End if
			%>
		</form>
	</body>
</HTML>
