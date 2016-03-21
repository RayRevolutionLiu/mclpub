<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>催稿單</title>
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

				Dim Rs1, Rs2, Rs4, Rs5, Rs6, Rs7		' Record Source 1 ~ 7
				Dim Rs9, Rs10					' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6, sqlcmd7		' SQL Command 4 ~ 7
				Dim sqlcmd9, sqlcmd10				' SQL Command 9 ~ 10
				Dim rescount, i		' rescount= count of Rs2
				Dim rescount2, j	' rescount2= count of Rs10
				Dim A1, A7		' Array A1, A7

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' 自訂 sql 變數
				Dim strYYYYMM, strBkcd, strEmpNo

				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim strYYYYMMnew, BkPNo, EmpCName, BkName, strLoginEmpNo, strLoginEmpCName


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
				sqlcmd2 = sqlcmd2 & " SELECT * "
				sqlcmd2 = sqlcmd2 & " FROM wk_c2_rp1 "
				sqlcmd2 = sqlcmd2 & " WHERE cont_fgcancel = '0' "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd2 = sqlcmd2 & " AND (cont_empno = '" & strEmpNo & "') "
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


				' Get Rs8: 執行 sp 以產生 Rs1 裡的 c2_getad.pubmmstr 欄位值
				' 此段因 wk_c2_rp1 裡部份 pubmmstr 值沒有出現, 所以移至 getad.aspx 裡執行 (按了 查詢按鈕後)
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				'sqlcmd8 = " EXEC sp_c2_getad_1 '0', '" & strBkcd & "' "
				'Rs8 = oConn.Execute(sqlcmd8)


				' Get Rs11: 執行 sp 以產生 Rs1 裡的 c2_getad.pubmmstr 欄位值
				' 此段因 wk_c2_rp1 裡部份 pubmmstr 值沒有出現, 所以移至 getad.aspx 裡執行 (按了 查詢按鈕後)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				'sqlcmd11 = " EXEC sp_c2_rp1 '" & strYYYYMM & "', '" & strBkcd & "' "
				'Rs11 = oConn.Execute(sqlcmd11)


				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT  "
				sqlcmd1 = sqlcmd1 & " mark, cont_contno, RTRIM(cont_aunm) AS cont_aunm, RTRIM(mfr_inm) "
				sqlcmd1 = sqlcmd1 & " AS mfr_inm, RTRIM(cont_autel) AS cont_autel, RTRIM(cont_aufax) "
				sqlcmd1 = sqlcmd1 & " AS cont_aufax, RTRIM(cont_aucell) AS cont_aucell, "
				sqlcmd1 = sqlcmd1 & " SUBSTRING(cont_sdate, 1, 4) + '/' + SUBSTRING(cont_sdate, 5, 6) "
				sqlcmd1 = sqlcmd1 & " + ' ~ ' + SUBSTRING(cont_edate, 1, 4) + '/' "
				sqlcmd1 = sqlcmd1 & " + SUBSTRING(cont_edate, 5, 6) AS cont_sedate, "
				sqlcmd1 = sqlcmd1 & " cont_restjtm, cont_resttm, pubmmstr, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN pub_totamt IS NULL THEN 0 ELSE pub_totamt END AS pub_totamt, "
				sqlcmd1 = sqlcmd1 & " pubcnt, RTRIM(ltp_nm) AS ltp_nm, RTRIM(clr_nm) AS clr_nm, RTRIM(pgs_nm) "
				sqlcmd1 = sqlcmd1 & " AS pgs_nm, pub_drafttp, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN RTRIM(pub_fggot) = '' THEN NULL "
				sqlcmd1 = sqlcmd1 & "   WHEN pub_fggot IS NULL THEN NULL "
				sqlcmd1 = sqlcmd1 & "   ELSE (CASE WHEN pub_fggot = '0' THEN '否' ELSE '是' END) "
				sqlcmd1 = sqlcmd1 & " END AS pub_fggot, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN pub_chgjno = 0 THEN NULL ELSE pub_chgjno END AS pub_chgjno, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN pub_origjno = 0 THEN NULL ELSE pub_origjno END AS pub_origjno, "
				sqlcmd1 = sqlcmd1 & " cont_pubclrtm, cont_pubgetclrtm, "
				sqlcmd1 = sqlcmd1 & " cont_pubmenotm, cont_fgcancel "
				sqlcmd1 = sqlcmd1 & " FROM wk_c2_rp1 "
				sqlcmd1 = sqlcmd1 & " WHERE cont_fgcancel = '0' "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " ORDER BY  tid "


				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)


				' Get Rs7: 抓出則數小計之各筆資料項
				' Open the RecordSets
				sqlcmd7 = "SELECT DISTINCT "
				sqlcmd7 = sqlcmd7 & " ltp_nm, clr_nm, pgs_nm, lp_priorseq, COUNT(*) AS CountNo "
				sqlcmd7 = sqlcmd7 & " FROM  wk_c2_rp1 "
				sqlcmd7 = sqlcmd7 & " WHERE cont_fgcancel = '0' "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd7 = sqlcmd7 & " AND (cont_empno = '" & strEmpNo & "') "
					sqlcmd7 = sqlcmd7 & " AND (pub_yyyymm='" & strYYYYMM & "')"
				else
					sqlcmd7 = sqlcmd7
					sqlcmd7 = sqlcmd7 & " AND (pub_yyyymm='" & strYYYYMM & "')"
				end if
				sqlcmd7 = sqlcmd7 & " Group by ltp_nm, clr_nm, pgs_nm, lp_priorseq "
				sqlcmd7 = sqlcmd7 & " ORDER BY  lp_priorseq "

				' Open the RecordSets
				Rs7 = oConn.Execute(sqlcmd7)


				' Get Rs10: 抓出則數小計之總筆數
				' Open the RecordSets
				sqlcmd10 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd10 = sqlcmd10 & " FROM             ( "
				sqlcmd10 = sqlcmd10 & " SELECT DISTINCT "
				sqlcmd10 = sqlcmd10 & " ltp_nm, clr_nm, pgs_nm, lp_priorseq, COUNT(*) AS CountNo "
				sqlcmd10 = sqlcmd10 & " FROM  wk_c2_rp1 "
				sqlcmd10 = sqlcmd10 & " WHERE cont_fgcancel = '0' "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd10 = sqlcmd10 & " AND (cont_empno = '" & strEmpNo & "') "
					sqlcmd10 = sqlcmd10 & " AND (pub_yyyymm='" & strYYYYMM & "')"
				else
					sqlcmd10 = sqlcmd10
					sqlcmd10 = sqlcmd10 & " AND (pub_yyyymm='" & strYYYYMM & "')"
				end if
				sqlcmd10 = sqlcmd10 & " Group by ltp_nm, clr_nm, pgs_nm, lp_priorseq "
				sqlcmd10 = sqlcmd10 & " ) DRIVERTBL "

				' Open the RecordSets
				Rs10 = oConn.Execute(sqlcmd10)

				if Rs10.EOF then
					rescount2 = 0
					Response.Write ("<FONT Color=Red><B>查詢結果 - 則數小計的筆數為 0</B></FONT><BR>")
				else
					rescount2 = Rs10(0).Value
				end if
				'Response.Write("rescount2= " & rescount2 & "<br>")


				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("sqlcmd4= " & sqlcmd4 & "<br><br>")
					'Response.Write("Rs4= " & Rs4(0).value & "<br>")
					'Response.Write("sqlcmd7= " & sqlcmd7 & "<br><br>")
					'Response.Write("Rs7= " & Rs7(0).value & "<br>")
					'Response.Write("sqlcmd9= " & sqlcmd9 & "<br><br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")

				' 若有資料, 則輸出至 ExcelSpeedGen
				else
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
					ReDim A1(rescount,23)

					' Populate Array 1
					Dim preNo, count
					preNo = ""
					count = 0
					for i = 0 to rescount - 1 step 1
						' 自動計算 A 欄: 項次 - 顯示方法二：放此處, 是因項次要顯示不同跳號(即使合約重覆, 也要逐一加下去; 還有 if裡 A1(i,0) = "" 要 disable)
						'A1(i,0) = count + 1
						'count = count + 1

						'Response.Write("cont_contno= " & Rs1("cont_contno").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")
						' 若資料重覆, 則重覆資料須清除某些重覆資料項(如合約相關資料)
						if Rs1("cont_contno").Value = preNo then
							' 以下為重覆時, 顯示要清空的資料項
							A1(i,0) = ""
							A1(i,1) = ""
							A1(i,2) = ""
							A1(i,3) = ""
							A1(i,4) = ""
							A1(i,5) = ""
							A1(i,6) = ""
							A1(i,7) = ""
							A1(i,8) = ""
							A1(i,9) = ""
							A1(i,10) = ""
							A1(i,11) = ""
							'A1(i,12) = ""
							A1(i,21) = ""
							A1(i,22) = ""
							A1(i,23) = ""
						else
							' 自動計算 A 欄: 項次 - 顯示方法一：放此處則是客戶要求: 合約重覆者, 則不顯示其相同的項次 (if裡 A1(i,0) = "" 要 enable)
							A1(i,0) = count + 1
							count = count + 1

							' 以下為非重覆時, 要顯示的資料項
							' 10/22/2002 備註已註銷之合約於續約註記欄 => 改為不出現已註銷合約資料
							'if(Rs1("cont_fgcancel").Value = "1") then
								'A1(i,1) = "註銷"
							'else
								'A1(i,1) = Rs1("mark").Value
							'end if
							A1(i,1) = Rs1("mark").Value
							A1(i,2) = Rs1("cont_contno").Value
							A1(i,3) = Rs1("cont_aunm").Value
							A1(i,4) = Rs1("mfr_inm").Value
							A1(i,5) = Rs1("cont_autel").Value
							A1(i,6) = Rs1("cont_aufax").Value
							A1(i,7) = Rs1("cont_aucell").Value
							A1(i,8) = Rs1("cont_sedate").Value
							A1(i,9) = Rs1("cont_restjtm").Value
							A1(i,10) = Rs1("cont_resttm").Value
							A1(i,11) = Rs1("pubmmstr").Value
							A1(i,12) = Rs1("pub_totamt").Value
							A1(i,21) = Rs1("cont_pubclrtm").Value
							A1(i,22) = Rs1("cont_pubgetclrtm").Value
							A1(i,23) = Rs1("cont_pubmenotm").Value
						end if


						' 以下為無論重覆與否, 一定要出現的資料項
						A1(i,12) = Rs1("pub_totamt").Value
						A1(i,13) = Rs1("pubcnt").Value
						A1(i,14) = Rs1("ltp_nm").Value
						A1(i,15) = Rs1("clr_nm").Value
						A1(i,16) = Rs1("pgs_nm").Value
						A1(i,17) = Rs1("pub_drafttp").Value
						A1(i,18) = Rs1("pub_fggot").Value
						A1(i,19) = Rs1("pub_chgjno").Value
						A1(i,20) = Rs1("pub_origjno").Value
						preNo = Rs1("cont_contno").Value


						Dim highlight2, highlight3, highlight4, highlight5, highlight6
						' Highlight Some Rows: 此為特別欄位使用的格式 A2/B2 (此處是欄位置中處理; 特別格式寫在 sheet 2 的指定欄位裡)
						' 特別欄位 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 注意 FormatCells 特別欄位 的程式碼一定要放在 FormatCells 一般欄位的程式碼 "前方", 否則特別欄位無法顯示
						highlight2 = "J" & (6+i)
						highlight3 = "K" & (6+i)
						highlight4 = "M" & (6+i)
						highlight5 = "N" & (6+i)
						highlight6 = "R" & (6+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight2, 2, "A2", false )
							XLS.FormatCells( 1, highlight3, 2, "A2", false )
							XLS.FormatCells( 1, highlight4, 2, "A5", false )
							XLS.FormatCells( 1, highlight5, 2, "A2", false )
							XLS.FormatCells( 1, highlight6, 2, "A2", false )
						else
							XLS.FormatCells( 1, highlight2, 2, "B2", false )
							XLS.FormatCells( 1, highlight3, 2, "B2", false )
							XLS.FormatCells( 1, highlight4, 2, "B5", false )
							XLS.FormatCells( 1, highlight5, 2, "B2", false )
							XLS.FormatCells( 1, highlight6, 2, "B2", false )
						end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")
						'Response.Write("highlight4= " & highlight4 & "<br>")
						'Response.Write("highlight5= " & highlight5 & "<br>")


						Dim highlight
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						highlight = "A" & (6+i) & ":X" & (6+i)
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


					' 輸出 則數小計的資料 Rs7
					if not Rs7.EOF then
					Rs7.MoveFirst
					rescount2 = 0
					Do while not Rs7.EOF
						rescount2 = rescount2 + 1
						Rs7.MoveNext
					Loop
					Rs7.MoveFirst
					end if

					' Array 7
					ReDim A7(rescount2, 4)

					if not Rs7.EOF then
					' Populate Array 7
					for j = 0 to rescount2 - 1 step 1
						A7(j,0) = Rs7("ltp_nm").Value
						A7(j,1) = Rs7("clr_nm").Value
						A7(j,2) = Rs7("pgs_nm").Value
						A7(j,3) = Rs7("CountNo").Value

						Rs7.MoveNext

						if Rs7.EOF
	    						exit for
						end if
					next
					end if

					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs7, 20)

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					XLS.AddRS_Array_2D( A7, true )


					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bkp_pno
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)	' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("getad2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "getad2.xls", True)

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
