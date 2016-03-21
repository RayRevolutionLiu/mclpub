<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>郵寄本數統計表 當月未刊登</title>
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
				Dim Rs9, RS10				' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2, sqlcmd4, sqlcmd5	' SQL Command 1 ~ 5
				Dim sqlcmd9, sqlcmd10			' SQL Command 9 ~ 10
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' 自訂 sql 變數
				Dim strBkcd, strYYYYMM, strConttp, strfgmosea, strMtpcd

				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim strYYYYMMNew, BkPNo, BkName, strLoginEmpNo, strLoginEmpCName


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
				Dim strConttpText, strfgmoseaText, strMtpName
				strBkcd = Request("bkcd")
				strYYYYMM = Request("yyyymm")
				strConttp = Request("conttp")
				strfgmosea = Request("fgmosea")
				strMtpcd = Request("mtpcd")
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

				' 合約類別
				if(strConttp <> "") then
					if(strConttp = "01") then
						strConttpText = "一般"
					end if
					if(strConttp = "09") then
						strConttpText = "推廣"
					end if
				else
					strConttpText = "(所有)"
				end if


				' 合約起迄日期區間
				if(strfgmosea <> "")then
					if(strfgmosea = "0") then
						strfgmoseaText = "國內"
					end if
					if(strfgmosea = "1") then
						strfgmoseaText = "國外"
					end if
				else
					strfgmoseaText = "(所有)"
				end if


				' Get Rs10: 藉郵寄代碼抓出其名稱
				if(strMtpcd <> "") then
					strMtpcd = TRIM(Request("mtpcd"))

					' Open the RecordSets
					sqlcmd10 = "SELECT * FROM mtp"
					sqlcmd10 = sqlcmd10 & " WHERE (mtp_mtpcd='" + strMtpcd + "')"
					Rs10 = oConn.Execute(sqlcmd10)
					if Rs10.EOF then
						strMtpName = "(查無資料)"
					else
						strMtpName = TRIM(Rs10("mtp_nm").Value)
					end if
					'Response.Write("strMtpcd= " & strMtpcd & "<br>")
					'Response.Write("strMtpName= " & strMtpName & "<br>")
				else
					strMtpcd = ""
					strMtpName = "(所有)"
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
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno, c2_cont.cont_mfrno, "
				sqlcmd2 = sqlcmd2 & " RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd, "
				sqlcmd2 = sqlcmd2 & " RTRIM(mtp.mtp_nm) AS mtp_nm, COUNT(c2_or.or_unpubcnt) "
				sqlcmd2 = sqlcmd2 & " AS UnPubCounts, c2_cont.cont_sdate, c2_cont.cont_edate, "
				sqlcmd2 = sqlcmd2 & " SUBSTRING(c2_cont.cont_sdate, 1, 4) "
				sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6) "
				sqlcmd2 = sqlcmd2 & " + ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4) "
				sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_conttp, c2_or.or_fgmosea "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno = c2_or.or_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd2 = sqlcmd2 & " WHERE         (c2_cont.cont_fgclosed = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_contno NOT IN "
				sqlcmd2 = sqlcmd2 & " (SELECT DISTINCT c2_pub.pub_contno "
				sqlcmd2 = sqlcmd2 & " FROM              c2_pub "
				sqlcmd2 = sqlcmd2 & " WHERE          c2_pub.pub_yyyymm = '" & strYYYYMM & "')) "
				sqlcmd2 = sqlcmd2 & " AND (c2_or.or_unpubcnt > 0) "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd2 = sqlcmd2 & " AND (cont_conttp = '" & strConttp & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("fgmosea") <> "") then
					strfgmosea  = Request("fgmosea")
					sqlcmd2 = sqlcmd2 & " AND (or_fgmosea = '" & strfgmosea & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("mtpcd") <> "") then
					strMtpcd = Request("mtpcd")
					sqlcmd2 = sqlcmd2 & " AND (or_mtpcd = '" & strMtpcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				sqlcmd2 = sqlcmd2 & " GROUP BY  c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm, "
				sqlcmd2 = sqlcmd2 & " c2_or.or_mtpcd, mtp.mtp_nm, c2_cont.cont_sdate, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_edate, c2_cont.cont_conttp, c2_or.or_fgmosea "
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
				sqlcmd1 = sqlcmd1 & " SELECT DISTINCT "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno, c2_cont.cont_mfrno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd, "
				sqlcmd1 = sqlcmd1 & " RTRIM(mtp.mtp_nm) AS mtp_nm, COUNT(c2_or.or_unpubcnt) "
				sqlcmd1 = sqlcmd1 & " AS UnPubCounts, c2_cont.cont_sdate, c2_cont.cont_edate, "
				sqlcmd1 = sqlcmd1 & " SUBSTRING(c2_cont.cont_sdate, 1, 4) "
				sqlcmd1 = sqlcmd1 & " + '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6) "
				sqlcmd1 = sqlcmd1 & " + ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4) "
				sqlcmd1 = sqlcmd1 & " + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_conttp, c2_or.or_fgmosea "
				sqlcmd1 = sqlcmd1 & " FROM             c2_cont INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno = c2_or.or_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " WHERE         (c2_cont.cont_fgclosed = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_contno NOT IN "
				sqlcmd1 = sqlcmd1 & " (SELECT DISTINCT c2_pub.pub_contno "
				sqlcmd1 = sqlcmd1 & " FROM              c2_pub "
				sqlcmd1 = sqlcmd1 & " WHERE          c2_pub.pub_yyyymm = '" & strYYYYMM & "')) "
				sqlcmd1 = sqlcmd1 & " AND (c2_or.or_unpubcnt > 0) "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd1 = sqlcmd1 & " AND (cont_conttp = '" & strConttp & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("fgmosea") <> "") then
					strfgmosea  = Request("fgmosea")
					sqlcmd1 = sqlcmd1 & " AND (or_fgmosea = '" & strfgmosea & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("mtpcd") <> "") then
					strMtpcd = Request("mtpcd")
					sqlcmd1 = sqlcmd1 & " AND (or_mtpcd = '" & strMtpcd & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " GROUP BY  c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm, "
				sqlcmd1 = sqlcmd1 & " c2_or.or_mtpcd, mtp.mtp_nm, c2_cont.cont_sdate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_edate, c2_cont.cont_conttp, c2_or.or_fgmosea "
				sqlcmd1 = sqlcmd1 & " ORDER BY  c2_or.or_mtpcd, c2_cont.cont_contno "

				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)

				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")

				' 若有資料, 則輸出至 ExcelSpeedGen
				else
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")

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
						else
							' 自動計算 A 欄: 項次 - 顯示方法一：放此處則是客戶要求: 合約重覆者, 則不顯示其相同的項次 (if裡 A1(i,0) = "" 要 enable)
							A1(i,0) = count + 1
							count = count + 1

							' 以下為非重覆時, 要顯示的資料項
							A1(i,1) = Rs1("cont_contno").Value
							A1(i,2) = Rs1("mfr_inm").Value
							A1(i,3) = Rs1("mtp_nm").Value
							A1(i,4) = Rs1("UnPubCounts").Value
						end if


						' 以下為無論重覆與否, 一定要出現的資料項
						A1(i,2) = Rs1("mfr_inm").Value
						A1(i,3) = Rs1("mtp_nm").Value
						A1(i,4) = Rs1("UnPubCounts").Value
						preNo = Rs1("cont_contno").Value


						' 此為特別欄位使用的格式 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 特別格式寫在 sheet 2 的指定欄位裡, 如 A5, A6; B5, B6
						Dim Discounthighlight
						Discounthighlight =  "E" & (7+i)
						if (i mod 2) = 0 then
							' 奇數行, 以 A8 的 數字 Format 顯示
							XLS.FormatCells( 1, Discounthighlight, 2, "A8", false )
						else
							' 偶數行, 以 B8 的 數字 Format 顯示
							XLS.FormatCells( 1, Discounthighlight, 2, "B8", false )
						end if

						' Highlight Some Rows: 此為一般欄位使用的格式
						Dim highlight
						highlight = "A" & (7+i) & ":E" & (7+i)
						if (i mod 2) = 0
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

					' Set Estimated Output File Size (Critical for speed)
					XLS.EstimatedSize = 50000

					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )

					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bk_nm
					XLS.AddVariable("conttpText", strConttpText)	' >>$mfr_iname
					XLS.AddVariable("fgmoseaText", strfgmoseaText)	' >>$signdate
					XLS.AddVariable("mtpcdText", strMtpName)	' >>$sedate
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					'Response.Write("BkName= " & BkName & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("ORCounts_stat2b.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "ORCounts_stat2b.xls", True)

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
