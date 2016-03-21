<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告合約書清單</title>
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
				Dim strBkcd, strEmpNo, strSignDate1, strSignDate2, strSDate, strEDate, strfgclosed, strMfrNo

				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName, BkName, strLoginEmpNo, strLoginEmpCName
				Dim strMfrIName
				Dim ColorTime, MemoTime, GetColorTime
				Dim TotJTime, MadeJTime, TotalTime, PubTime, ChgJtime
				Dim TotalAmt, PaidAmt, RestAmt, ChgAmt


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
				Dim strSignDateBlock, strSEDateBlock, strfgclosedText
				strBkcd = Request("bkcd")
				strEmpNo = Request("empno")
				strSignDate1 = Request("signdate1")
				strSignDate2 = Request("signdate2")
				strSDate = Request("sdate")
				strEDate = Request("edate")
				strfgclosed = Request("fgclosed")
				strMfrNo = Request("mfrno")
				strLoginEmpNo = Request("LEmpNo")

				' 簽約日期區間
				if(strSignDate1 <> "") AND (strSignDate2 <> "") then
					strSignDateBlock = Mid(strSignDate1, 1, 4) & "/" & Mid(strSignDate1, 5, 2) & "/" & Mid(strSignDate1, 7, 2) & "~" & Mid(strSignDate2, 1, 4) & "/" & Mid(strSignDate2, 5, 2) & "/" & Mid(strSignDate2, 7, 2)
				else
					strSignDateBlock = "(所有)"
				end if


				' 合約起迄日期區間
				if(strSDate <> "") AND (strEDate <> "") then
					strSEDateBlock = Mid(strSDate, 1, 4) & "/" & Mid(strSDate, 5, 2) & "~" & Mid(strEDate, 1, 4) & "/" & Mid(strEDate, 5, 2)
				else
					strSEDateBlock = "(所有)"
				end if


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
				if(Request("empno") <> "") then
					strEmpNo = strEmpNo

					' Open the RecordSets
					sqlcmd4 = "SELECT * FROM srspn"
					sqlcmd4 = sqlcmd4 & " WHERE (srspn_empno='" + strEmpNo + "')"
					Rs4 = oConn.Execute(sqlcmd4)
					EmpCName = TRIM(Rs4("srspn_cname").Value)
					'Response.Write("EmpCName= " & EmpCName & "<br>")
				else
					strEmpNo = ""
					EmpCName = "(所有)"
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

				' Get Rs10: 藉廠商統編抓出廠商名稱
				if(strMfrNo <> "") then
					strMfrNo = TRIM(Request("mfrno"))

					' Open the RecordSets
					sqlcmd10 = "SELECT * FROM mfr"
					sqlcmd10 = sqlcmd10 & " WHERE (mfr_mfrno='" + strMfrNo + "')"
					Rs10 = oConn.Execute(sqlcmd10)
					if Rs10.EOF then
						strMfrIName = "(查無資料)"
					else
						strMfrIName = TRIM(Rs10("mfr_inm").Value)
					end if
					'Response.Write("strMfrNo= " & strMfrNo & "<br>")
					'Response.Write("strMfrIName= " & strMfrIName & "<br>")
				else
					strMfrNo = ""
					strMfrIName = "(所有)"
				end if

				' 藉結案註記抓出其代表意思(文字)
				if(strfgclosed <> "") then
					strfgclosed = strfgclosed

					if(strfgclosed = "0")
						strfgclosedText = "未結案"
					else
						strfgclosedText = "已結案"
					end if
				else
					strfgclosedText = "所有"
				end if


				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT "
				sqlcmd2 = sqlcmd2 & " cont_contno "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_contlist2 ON "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_syscd COLLATE Chinese_Taiwan_Stroke_BIN = c2_contlist2.syscd "
				sqlcmd2 = sqlcmd2 & " AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = c2_contlist2.contno "
				sqlcmd2 = sqlcmd2 & " WHERE         (cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (cont_bkcd = '" & strBkcd & "') "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd2 = sqlcmd2 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("signdate1") <> "") then
					strSignDate1 = Request("signdate1")
					strSignDate2 = Request("signdate2")
					sqlcmd2 = sqlcmd2 & " AND (cont_signdate >= '" & strSignDate1 & "') "
					sqlcmd2 = sqlcmd2 & " AND (cont_signdate <= '" & strSignDate2 & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("sdate") <> "") then
					strSDate = Request("sdate")
					strEDate = Request("edate")
					sqlcmd2 = sqlcmd2 & " AND (cont_sdate >= '" & strSDate & "') "
					sqlcmd2 = sqlcmd2 & " AND (cont_edate <= '" & strEDate & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("fgclosed") <> "") then
					strfgclosed = Request("fgclosed")
					sqlcmd2 = sqlcmd2 & " AND (cont_fgclosed = '" & strfgclosed & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("mfrno") <> "") then
					strMfrNo = Request("mfrno")
					sqlcmd2 = sqlcmd2 & " AND (mfr_mfrno = '" & strMfrNo & "') "
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
				sqlcmd1 = "SELECT DISTINCT"
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_signdate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_mfrno, RTRIM(mfr.mfr_inm) AS mfr_inm, c2_cont.cont_aunm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_autel, c2_cont.cont_aufax, c2_cont.cont_aucell, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_bkcd, RTRIM(book.bk_nm) AS bk_nm, c2_cont.cont_conttp, "
				'sqlcmd1 = sqlcmd1 & " substring(c2_cont.cont_sdate, 1, 4) + '/' + substring(c2_cont.cont_sdate, 4, 2) AS cont_sdate, "
				'sqlcmd1 = sqlcmd1 & " substring(c2_cont.cont_edate, 1, 4) + '/' + substring(c2_cont.cont_edate, 4, 2) AS cont_edate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_sdate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_edate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_clrtm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_clrtm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_getclrtm, c2_cont.cont_menotm, c2_cont.cont_fgclosed, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_fgpubed, c2_cont.cont_disc, c2_cont.cont_freetm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_totjtm, c2_cont.cont_madejtm, c2_cont.cont_restjtm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_tottm, c2_cont.cont_pubtm, c2_cont.cont_resttm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_pubamt, c2_cont.cont_chgamt, c2_cont.cont_fgpayonce, "
				sqlcmd1 = sqlcmd1 & " RTRIM(c2_cont.cont_empno) AS cont_empno, c2_cont.cont_fgcancel, "
				sqlcmd1 = sqlcmd1 & " RTRIM(c2_cont.cont_oldcontno) AS cont_oldcontno, c2_cont.cont_custno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(cust.cust_nm) AS cust_nm, cust.cust_jbti, cust.cust_tel, cont_freebkcnt, "
				sqlcmd1 = sqlcmd1 & " cont_chgjtm, c2_contlist2.ornamestr, "
				sqlcmd1 = sqlcmd1 & " c2_contlist2.orfullnamestr "
				sqlcmd1 = sqlcmd1 & " FROM             c2_cont INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_contlist2 ON "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_syscd COLLATE Chinese_Taiwan_Stroke_BIN = c2_contlist2.syscd "
				sqlcmd1 = sqlcmd1 & " AND "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = c2_contlist2.contno "
				sqlcmd1 = sqlcmd1 & " WHERE         (c2_cont.cont_fgtemp = '0') "
				sqlcmd1 = sqlcmd1 & " AND (cont_bkcd = '" & strBkcd & "') "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("signdate1") <> "") then
					strSignDate1 = Request("signdate1")
					strSignDate2 = Request("signdate2")
					sqlcmd1 = sqlcmd1 & " AND (cont_signdate >= '" & strSignDate1 & "') "
					sqlcmd1 = sqlcmd1 & " AND (cont_signdate <= '" & strSignDate2 & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("sdate") <> "") then
					strSDate = Request("sdate")
					strEDate = Request("edate")
					sqlcmd1 = sqlcmd1 & " AND (cont_sdate >= '" & strSDate & "') "
					sqlcmd1 = sqlcmd1 & " AND (cont_edate <= '" & strEDate & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("fgclosed") <> "") then
					strfgclosed = Request("fgclosed")
					sqlcmd1 = sqlcmd1 & " AND (cont_fgclosed = '" & strfgclosed & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("mfrno") <> "") then
					strMfrNo = Request("mfrno")
					sqlcmd1 = sqlcmd1 & " AND (mfr_mfrno = '" & strMfrNo & "') "
				else
					sqlcmd1 = sqlcmd1
				end if


				' Get Rs4: 抓出 Excel 檔的裡某些須計算的資料欄位 - 當月刊登月數 及 當月未刊登月數
				sqlcmd4 = " SELECT         c2_cont.cont_contno, c2_or.or_inm, c2_or.or_nm "
				sqlcmd4 = sqlcmd4 & " FROM             c2_cont INNER JOIN "
				sqlcmd4 = sqlcmd4 & " c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND "
				sqlcmd4 = sqlcmd4 & " c2_cont.cont_contno = c2_or.or_contno "
				'sqlcmd4 = sqlcmd4 & " WHERE (c2_cont.cont_contno = )"
				Rs4 = oConn.Execute(sqlcmd4)

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
					ReDim A1(rescount*2,15)

					' Populate Array 1
					Dim LineNo
					LineNo = 0
					for i = 0 to rescount*2 - 1 step 2
						' 測試是否抓的到 result (但要先把 XLS.Generate() 那行 disable, 才看得到 Response.Write 結果)
						'Response.Write(Rs1("cont_contno").Value & ", ")
						'Response.Write(Rs1("cont_signdate").Value & ", ")
						'Response.Write(Rs1("cont_mfrno").Value & ", ")
						'Response.Write(Rs1("cont_aunm").Value & ", ")
						'Response.Write(Rs1("cont_autel").Value & "<br>")

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
						A1(i,2) = conttpText
						A1(i+1,2) = Rs1("cont_totjtm").Value
						A1(i,3) = Mid(Rs1("cont_signdate").Value, 1, 4) & "/" & Mid(Rs1("cont_signdate").Value, 5, 2) & "/" & Mid(Rs1("cont_signdate").Value, 7, 2)
						A1(i+1,3) = Rs1("cont_madejtm").Value

						' E 欄 = A1(i,4)
						A1(i,4) = Mid(Rs1("cont_sdate").Value, 1, 4) & "/" & Mid(Rs1("cont_sdate").Value, 5, 2)
						A1(i+1,4) = Rs1("cont_tottm").Value
						A1(i,5) = Mid(Rs1("cont_edate").Value, 1, 4) & "/" & Mid(Rs1("cont_edate").Value, 5, 2)
						A1(i+1,5) = Rs1("cont_pubtm").Value
						A1(i,6) = Rs1("cont_mfrno").Value
						A1(i+1,6) = Rs1("cont_totamt").Value
						A1(i,7) = Rs1("mfr_inm").Value
						A1(i+1,7) = Rs1("cont_paidamt").Value

						' I 欄 = A1(i,8)
						A1(i,8) = Rs1("cust_nm").Value
						A1(i+1,8) = Rs1("cont_restamt").Value
						A1(i,9) = Mid(Rs1("cont_aunm").Value, 1, 4) & "/" & Mid(Rs1("cont_sdate").Value, 5, 2)
						A1(i+1,9) = Rs1("cont_chgamt").Value
						A1(i,10) = Mid(Rs1("cont_autel").Value, 1, 4) & "/" & Mid(Rs1("cont_edate").Value, 5, 2)
						A1(i+1,10) = Rs1("cont_chgjtm").Value
						A1(i,11) = Rs1("cont_aucell").Value
						A1(i+1,11) = Rs1("cont_disc").Value
						A1(i,12) = Rs1("cont_clrtm").Value
						A1(i+1,12) = Rs1("orfullnamestr").Value

						' 抓出合計之值, 並轉為變數型態
						ColorTime = ColorTime + A1(i,12)
						MemoTime = MemoTime + A1(i,13)
						GetColorTime = GetColorTime + A1(i,14)
						TotJTime = TotJTime + A1(i+1,2)
						MadeJTime = MadeJTime + A1(i+1,3)
						TotalTime = TotalTime + A1(i+1,4)
						PubTime = PubTime + A1(i+1,5)
						TotalAmt = TotalAmt + A1(i+1,6)
						PaidAmt = PaidAmt + A1(i+1,7)
						RestAmt = RestAmt + A1(i+1,8)
						ChgAmt = ChgAmt + A1(i+1,9)
						ChgJtime = ChgJtime + A1(i+1,10)
						'Response.Write("PubTime(" & i & ")= " & A1(i+1,7) & "<br>")

						' N 欄 = A1(i,13)
						A1(i,13) = Rs1("cont_menotm").Value
						if(Rs1("cont_fgpayonce").Value= "0")
							A1(i+1,13) = "否"
						else
							A1(i+1,13) = "是, 一次付款"
						end if

						A1(i,14) = Rs1("cont_getclrtm").Value
						if(Rs1("cont_fgclosed").Value= "0")
							A1(i+1,14) = "否"
						else
							A1(i+1,14) = "是, 已結案"
						end if
						if(Rs1("cont_fgcancel").Value=0)
							A1(i+1,14) = A1(i+1,14) & " / 否"
						else
							A1(i+1,14) = A1(i+1,14) & " / 是, 已註"
						end if


						' 此為特別欄位使用的格式 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 特別格式寫在 sheet 2 的指定欄位裡, 如 A5, A6; B5, B6
						Dim Discounthighlight, Amounthighlight1, Amounthighlight2, Amounthighlight3
						Discounthighlight =  "L" & (9+i)
						Amounthighlight1 = "H" & (9+i)
						Amounthighlight2 = "I" & (9+i)
						Amounthighlight3 = "J" & (9+i)
						if (i mod 4) = 0 then
							' 奇數行, 以 A5 的 貨幣 Format 顯示
							XLS.FormatCells( 1, Discounthighlight, 2, "A9", false )
							XLS.FormatCells( 1, Amounthighlight1, 2, "A5", false )
							XLS.FormatCells( 1, Amounthighlight2, 2, "A5", false )
							XLS.FormatCells( 1, Amounthighlight3, 2, "A5", false )
						else
							' 偶數行, 以 B5 的 貨幣 Format 顯示
							XLS.FormatCells( 1, Discounthighlight, 2, "B9", false )
							XLS.FormatCells( 1, Amounthighlight1, 2, "B5", false )
							XLS.FormatCells( 1, Amounthighlight2, 2, "B5", false )
							XLS.FormatCells( 1, Amounthighlight3, 2, "B5", false )
						end if

						' Highlight Some Rows: 此為一般欄位使用的格式
						Dim highlight
						highlight = "A" & (8+i) & ":O" & (9+i)
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
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("mfr_iname", strMfrIName)	' >>$mfr_iname
					XLS.AddVariable("signdate", strSignDateBlock)	' >>$signdate
					XLS.AddVariable("sedate", strSEDateBlock)	' >>$sedate
					XLS.AddVariable("fgclosed", strfgclosedText)	' >>$sedate
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					XLS.AddVariable("clrtm", ColorTime)		' >>$clrtm
					XLS.AddVariable("memotm", MemoTime)		' >>$memotm
					XLS.AddVariable("getclrtm", GetColorTime)	' >>$getclrtm
					XLS.AddVariable("chgjtm", ChgJtime)		' >>$chgjtm
					XLS.AddVariable("totjtm", TotJTime)		' >>$totjtm
					XLS.AddVariable("madejtm", MadeJTime)		' >>$madejtm
					XLS.AddVariable("tottm", TotalTime)		' >>$tottm
					XLS.AddVariable("pubtm", PubTime)		' >>$pubtm
					XLS.AddVariable("totamt", TotalAmt)		' >>$totamt
					XLS.AddVariable("paidamt", PaidAmt)		' >>$paidamt
					XLS.AddVariable("chgamt", ChgAmt)		' >>$chgamt
					'Response.Write("EmpCName= " & EmpCName & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("cont_list2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "cont_list2a.xls", True)

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
