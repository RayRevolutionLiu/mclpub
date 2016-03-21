<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>平面廣告標籤清單 當月未刊登</title>
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
				Dim dbFile          ' Database File
				Dim oConn           ' ADO Connection object
				Dim DSN				' Web Application Name

				Dim Rs1, Rs2, Rs4, Rs5, Rs6, RS7		' Record Source 1 ~ 7
				Dim Rs9						' Record Source 9
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6, sqlcmd7		' SQL Command 4 ~ 7
				Dim sqlcmd9					' SQL Command 9
				Dim rescount, i		' rescount= count of Rs2
				Dim rescount2, j	' rescount2= count of Rs10
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' 自訂 sql 變數
				Dim strYYYYMM, strBkcd, strEmpNo, strpubcnttp, strConttp, strfgmosea, strmtpcd

				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim strYYYYMMnew, BkPNo, EmpCName, BkName, strLoginEmpNo, strLoginEmpCName
				Dim strConttpText, strfgmoseaText, strmtpcdText


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
				strYYYYMM = Request("yyyymm")
				strBkcd = Request("bkcd")
				strEmpNo = ""
				strConttp = ""
				BkPNo = ""
				strLoginEmpNo = Request("LEmpNo")
				if(strYYYYMM <> "") then
					strYYYYMM = strYYYYMM
					strYYYYMMnew = Mid(strYYYYMM, 1, 4) & "/" & Mid(strYYYYMM, 5, 2)

					' Get Rs4: 由 刊登年月 抓出其相對應之 刊登期別
					sqlcmd4 = "SELECT bkp_pno "
					sqlcmd4 = sqlcmd4 & " FROM bookp "
					sqlcmd4 = sqlcmd4 & " WHERE (bkp_date = '" & strYYYYMM & "') "
					sqlcmd4 = sqlcmd4 & " AND (bkp_bkcd = '" & strBkcd & "') "
					Rs4 = oConn.Execute(sqlcmd4)
					BkPNo = Rs4("bkp_pno").value
					'Response.Write("BkPNo= " & BkPNo & "<br>")
				else
					strYYYYMM = ""
					BkPNo = ""
				end if

				if(strBkcd <> "") then
					strBkcd = strBkcd

					' Get Rs5: 藉書籍代碼抓出書籍名稱
					' Open the RecordSets
					sqlcmd5 = "SELECT * FROM book"
					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
					Rs5 = oConn.Execute(sqlcmd5)
					BkName = Rs5("bk_nm").Value
					'Response.Write("BkName= " & BkName & "<br>")
				else
					strBkcd = ""
				end if

				if(Request("empno") <> "") then
					strEmpNo = Request("empno")

					' Get Rs6: 藉承辦業務員工號抓出姓名
					' Open the RecordSets
					sqlcmd6 = "SELECT * FROM srspn"
					sqlcmd6 = sqlcmd6 & " WHERE (srspn_empno='" + strEmpNo + "')"
					Rs6 = oConn.Execute(sqlcmd6)
					EmpCName = Trim(Rs6("srspn_cname").Value)
					'Response.Write("EmpCName= " & EmpCName & "<br>")
				else
					strEmpNo = ""
					EmpCName = "(所有)"
				end if

				strConttpText = ""
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")

					if(strConttp = "01")
						strConttpText = "一般合約"
					end if
					if(strConttp = "09")
						strConttpText = "推廣合約"
					end if
				else
					strConttp = ""
					strConttpText = "(不清楚)"
				end if

				strfgmoseaText = ""
				if(Request("fgmosea") <> "") then
					strfgmosea = Request("fgmosea")

					if(strfgmosea = "0")
						strfgmoseaText = "國內"
					end if
					if(strfgmosea = "1")
						strfgmoseaText = "國外"
					end if
				else
					strfgmosea = ""
					strfgmoseaText = "(所有)"
				end if

				strmtpcdText = ""
				if(Request("mtpcd") <> "") then
					strmtpcd = Request("mtpcd")

					' Get Rs7: 藉郵寄類別代碼抓出其名稱
					' Open the RecordSets
					sqlcmd7 = "SELECT * FROM mtp"
					sqlcmd7 = sqlcmd7 & " WHERE (mtp_mtpcd='" + strmtpcd + "')"
					Rs7 = oConn.Execute(sqlcmd7)
					strmtpcdText = Trim(Rs7("mtp_nm").Value)
					'Response.Write("strmtpcdText= " & strmtpcdText & "<br>")
				else
					strmtpcd = ""
					strmtpcdText = "(所有)"
				end if

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
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
				'Response.Write("strBkcd= " & strBkcd & "<br>")
				'Response.Write("strEmpNo= " & strEmpNo & "<br>")
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")


				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno, c2_cont.cont_sdate, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_edate, SUBSTRING(c2_cont.cont_sdate, 1, 4) "
				sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6) "
				sqlcmd2 = sqlcmd2 & " + ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4) "
				sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_or.or_inm) AS or_inm, RTRIM(c2_or.or_nm) AS or_nm, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_or.or_jbti) AS or_jbti, RTRIM(c2_or.or_zip) AS or_zip, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_or.or_addr) AS or_addr, c2_or.or_unpubcnt, "
				sqlcmd2 = sqlcmd2 & " c2_or.or_mtpcd, RTRIM(mtp.mtp_nm) AS mtp_nm, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_cont.cont_empno) AS cont_empno, c2_or.or_oritem, "
				sqlcmd2 = sqlcmd2 & " RTRIM(book.bk_nm) AS bk_nm "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno = c2_or.or_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " book ON c2_cont.cont_bkcd = book.bk_bkcd "
				sqlcmd2 = sqlcmd2 & " WHERE         (c2_cont.cont_fgclosed = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_or.or_unpubcnt > 0) "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_contno NOT IN "
				sqlcmd2 = sqlcmd2 & " (SELECT DISTINCT c2_pub.pub_contno "
				sqlcmd2 = sqlcmd2 & " FROM              c2_pub "
				sqlcmd2 = sqlcmd2 & " WHERE          c2_pub.pub_yyyymm = '" & strYYYYMM & "')) "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd2 = sqlcmd2 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("mtpcd") <> "") then
					strmtpcd = Request("mtpcd")
					sqlcmd2 = sqlcmd2 & " AND (or_mtpcd = '" & strmtpcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
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
				sqlcmd1 = " exec sp_c2_pubfm_lbl_unpub "
				sqlcmd1 = sqlcmd1 & "'" & Request("bkcd") & "', "
				sqlcmd1 = sqlcmd1 & "'" & Request("conttp") & "', "
				sqlcmd1 = sqlcmd1 & "'" & Request("fgmosea") & "', "
				sqlcmd1 = sqlcmd1 & "'" & Request("yyyymm") & "' "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("mtpcd") <> "") then
					strmtpcd = Request("mtpcd")
					sqlcmd1 = sqlcmd1 & " AND (or_mtpcd = '" & strmtpcd & "') "
				else
					sqlcmd1 = sqlcmd1
				end if


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
					'Response.Write("sqlcmd9= " & sqlcmd9 & "<br><br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")

				' 若有資料, 則輸出至 ExcelSpeedGen
				else
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")

					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")


					' 輸出 主資料 Rs1
					Rs1.MoveFirst
					rescount = 0
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst


					' Array 1
					ReDim A1(rescount,7)

					' Populate Array 1
					Dim preNo, count
					preNo = ""
					count = 0
					for i = 0 to rescount - 1 step 1
						Response.Write("or_contno= " & Rs1("cont_contno").Value & "<br>")
						Response.Write("preNo= " & preNo & "<br><br>")
						' 若資料重覆, 則重覆資料須清除某些重覆資料項(如合約相關資料)
						if Rs1("cont_contno").Value = preNo then
							' 以下為重覆時, 顯示要清空的資料項
							A1(i,0) = ""
							A1(i,1) = ""
							A1(i,2) = ""
							A1(i,3) = ""
						else
							' 自動計算 A 欄: 項次 - 顯示方法一：放此處則是客戶要求: 合約重覆者, 則不顯示其相同的項次 (if裡 A1(i,0) = "" 要 enable)
							A1(i,0) = count + 1
							count = count + 1

							' 以下為非重覆時, 要顯示的資料項
							A1(i,1) = Rs1("cont_contno").Value
							A1(i,2) = Rs1("cont_sedate").Value
							A1(i,3) = Rs1("or_inm").Value
							A1(i,4) = Rs1("or_nm").Value & " " & Rs1("or_jbti").Value
							A1(i,5) = Rs1("or_zip").Value & " " & Rs1("or_addr").Value
							'A1(i,6) = Rs1("bk_nm").Value & " " & Rs1("bkp_pno").Value & " 期"
							A1(i,6) = Rs1("or_unpubcnt").Value
							A1(i,7) = Rs1("mtp_nm").Value
						end if


						' 以下為無論重覆與否, 一定要出現的資料項
						A1(i,4) = Rs1("or_nm").Value & " " & Rs1("or_jbti").Value
						A1(i,5) = Rs1("or_zip").Value & " " & Rs1("or_addr").Value
						'A1(i,6) = Rs1("bk_nm").Value & " " & Rs1("bkp_pno").Value & " 期"
						A1(i,6) = Rs1("or_unpubcnt").Value
						A1(i,7) = Rs1("mtp_nm").Value
						preNo = Rs1("cont_contno").Value


						Dim highlight2, highlight3
						' Highlight Some Rows: 此為特別欄位使用的格式 A2/B2 (此處是欄位置中處理; 特別格式寫在 sheet 2 的指定欄位裡)
						' 特別欄位 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 注意 FormatCells 特別欄位 的程式碼一定要放在 FormatCells 一般欄位的程式碼 "前方", 否則特別欄位無法顯示
						highlight2 = "G" & (8+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight2, 2, "A8", false )
						else
							XLS.FormatCells( 1, highlight2, 2, "B8", false )
						end if
						'Response.Write("highlight2= " & highlight2 & "<br>")


						Dim highlight
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						highlight = "A" & (8+i) & ":H" & (8+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false )
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )
						end if
						'Response.Write("highlight= " & highlight & "<br>")


						Rs1.MoveNext

						if Rs1.EOF
	    						exit for
						end if
					next



					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bkp_pno
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("conttpText", strConttpText)	' >>$conttpText
					XLS.AddVariable("fgmoseaText", strfgmoseaText)	' >>$fgmoseaText
					XLS.AddVariable("mtpcdText", strmtpcdText)	' >>$mtpcdText
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("PubFm_list2b.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "PubFm_list2b.xls", True)

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
