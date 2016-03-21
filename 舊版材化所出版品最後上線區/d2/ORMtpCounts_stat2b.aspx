<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>印製份數統計表 當月未刊登</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="ormtpcount2_stat2a" method="post" runat="server">
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

				Dim Rs1, Rs2, Rs3, Rs4, Rs5, Rs6, Rs7		' Record Source 1 ~ 7
				Dim Rs9, Rs10					' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2, sqlcmd3			' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6, sqlcmd7		' SQL Command 4 ~ 7
				Dim sqlcmd9, sqlcmd10				' SQL Command 9 ~ 10
				Dim rescountD, i	' rescountD= count of Rs2
				Dim rescountM, j	' rescountM= count of Rs3
				Dim A1, A7		' Array A1, A7

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' 自訂 sql 變數
				Dim strConttp, strYYYYMM, strBkcd, strEmpNo, strfgmosea, strMailtp

				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim strconttpText, strYYYYMMnew, BkPNo, EmpCName, BkName, strLoginEmpNo, strLoginEmpCName
				Dim strfgmoseaText, strmailtpText


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
				strYYYYMM = Request("yyyymm")
				strBkcd = Request("bkcd")
				strfgmosea = Request("fgmosea")
				strMailtp = Request("mailtp")
				BkPNo = ""
				strLoginEmpNo = Request("LEmpNo")
				if(Trim(strConttp) <> "") Then
					if(Trim(strConttp) = "01") Then
						strconttpText = "一般"
					end if
					if(Trim(strConttp) = "09") Then
						strconttpText = "推廣"
					end if
				else
					strconttpText = "不清楚"
				end if

				if(Trim(strfgmosea) <> "") Then
					if(Trim(strfgmosea) = "0") Then
						strfgmoseaText = "國內"
					end if
					if(Trim(strfgmosea) = "1") Then
						strfgmoseaText = "國外"
					end if
				else
					strfgmoseaText = "國內外"
				end if

				if(Trim(strMailtp) <> "") Then
					if(Trim(strMailtp) = "0") Then
						strmailtpText = "大宗郵寄"
					end if
					if(Trim(strMailtp) = "1") Then
						strmailtpText = "收發室經辦"
					end if
				else
					strmailtpText = "不清楚"
				end if

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


				' Get Rs2: 抓出目前資料庫的總筆數 -- 主檔 join 明細檔
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT         mtpnm, bknm, conttpnm, Unpubcnt, COUNT(Unpubcnt) AS UnPubCounts,  "
				sqlcmd2 = sqlcmd2 & " 			Unpubcnt * COUNT(Unpubcnt) AS SumCounts "
				sqlcmd2 = sqlcmd2 & " FROM             dbo.wk_c2_rp3 "
				sqlcmd2 = sqlcmd2 & " GROUP BY  mtpcd, mtpnm, bknm, conttpnm, Unpubcnt "
				sqlcmd2 = sqlcmd2 & " ) DRIVERTBL "

				' Open the RecordSets
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescountD = 0
					Response.Write ("<FONT Color=Red><B>查詢結果 - 筆數為 0</B></FONT><BR>")
				else
					rescountD = Rs2(0).Value
				end if
				'Response.Write("rescountD= " & rescountD & "<br>")


				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = sqlcmd1 & " SELECT         mtpcd, mtpnm, bknm, conttpnm, Unpubcnt, COUNT(Unpubcnt) AS UnPubCounts, "
				sqlcmd1 = sqlcmd1 & " Unpubcnt * COUNT(Unpubcnt) AS SumCounts "
				sqlcmd1 = sqlcmd1 & " FROM             dbo.wk_c2_rp3 "
				sqlcmd1 = sqlcmd1 & " GROUP BY  mtpcd, mtpnm, bknm, conttpnm, Unpubcnt "
				'Response.Write("sqlcmd1= " & sqlcmd1 & "<br>")


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
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")

					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")


					' 輸出 主資料 Rs1
					Rs1.MoveFirst
					rescountD = 0
					Do while not Rs1.EOF
						rescountD = rescountD + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst


					' Array 1
					Dim rescountMD
					rescountMD = rescountD + rescountM + 1
					ReDim A1(rescountMD,7)
					'Response.Write("rescountMD= " & rescountMD & "<br>")

					' Populate Array 1
					Dim preNo, count, X
					Dim sum_UnPubCounts, sum_Counts, TotalUnPubCounts, TotalCounts
					preNo = ""
					count = 0
					X = 0
					sum_UnPubCounts = 0
					sum_Counts = 0
					TotalUnPubCounts = 0
					TotalCounts = 0
					for i = 0 to rescountD - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("X= " & X & "<BR>")
						'Response.Write("count= " & count & ", ")
						'Response.Write("or_mtpcd= " & Rs1("mtpcd").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")

						' 若與上一筆資料之合約編號不同, 則全部顯示
						if (Rs1("mtpcd").Value <> preNo) then
							' 輸出 小計
							if(X <> 0) then
								A1(X,0) = ""
								A1(X,1) = "-----"
								A1(X,2) = "-----"
								A1(X,3) = "-----------------------------------"
								A1(X,4) = "小計："
								A1(X,5) = sum_UnPubCounts & " 份"
								A1(X,6) = sum_Counts & " 本"
								X = X + 1
							end if


							' 全部顯示
							A1(X,0) = count + 1
							count = count + 1
							'Response.Write("count= " & count & ", ")

							A1(X,1) = Rs1("conttpnm").Value
							A1(X,2) = Rs1("bknm").Value
							A1(X,3) = Rs1("mtpnm").Value
							A1(X,4) = Rs1("Unpubcnt").Value & " x"
							A1(X,5) = Rs1("UnPubCounts").Value & " 份 = "
							A1(X,6) = Rs1("SumCounts").Value & " 本"
							sum_UnPubCounts = Rs1("UnPubCounts").Value
							sum_Counts = Rs1("SumCounts").Value
							X = X + 1

						' 若與上一筆資料之合約編號相同 -- 清除前面重覆顯示欄位(如合約+發廠相關資料)
						else
							A1(X,0) = ""
							A1(X,1) = ""
							A1(X,2) = ""
							A1(X,3) = ""
							A1(X,4) = Rs1("Unpubcnt").Value & " x"
							A1(X,5) = Rs1("UnPubCounts").Value & " 份 = "
							A1(X,6) = Rs1("SumCounts").Value & " 本"
							sum_UnPubCounts = sum_UnPubCounts + Rs1("UnPubCounts").Value
							sum_Counts = sum_Counts + Rs1("SumCounts").Value
							X = X + 1
						end if

						' 指定 判斷值, 好與下一筆資料相比較
						preNo = Rs1("mtpcd").Value
						'Response.Write("preNo= " & preNo & ", ")
						'Response.Write("sum_UnPubCounts= " & sum_UnPubCounts & ", ")
						'Response.Write("sum_Counts= " & sum_Counts & ", ")


						' 總計 -- for 整個報表, 將此值輸出至變數
						TotalUnPubCounts = TotalUnPubCounts + Rs1("UnPubCounts").Value
						TotalCounts = TotalCounts + Rs1("SumCounts").Value
						'Response.Write("sum_UnPubCounts= " & sum_UnPubCounts & ", ")
						'Response.Write("sum_Counts= " & sum_Counts & ", ")


						Dim highlight2, highlight3, highlight4, highlight5
						' Highlight Some Rows: 此為特別欄位使用的格式 A2/B2 (此處是欄位置中處理; 特別格式寫在 sheet 2 的指定欄位裡)
						' 特別欄位 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 注意 FormatCells 特別欄位 的程式碼一定要放在 FormatCells 一般欄位的程式碼 "前方", 否則特別欄位無法顯示
						highlight2 = "E" & (7+X)
						highlight3 = "F" & (7+X)
						'if (X mod 2) = 0
							'XLS.FormatCells( 1, highlight2, 2, "A8", false )
							'XLS.FormatCells( 1, highlight3, 2, "A8", false )
						'else
							'XLS.FormatCells( 1, highlight2, 2, "B8", false )
							'XLS.FormatCells( 1, highlight3, 2, "B8", false )
						'end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")


						Dim highlight
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						highlight = "A" & (7+X) & ":F" & (7+X)
						'if (X mod 2) = 0
							'XLS.FormatCells( 1, highlight, 2, "A1", false )
						'else
							'XLS.FormatCells( 1, highlight, 2, "B1", false )
						'end if
						'Response.Write("highlight= " & highlight & "<br>")


						Rs1.MoveNext

						if Rs1.EOF
	    						exit for
						end if
					next


					' 總計 -- for 最後一筆資料 (因此時已移到 Rs1.MoveLast)
					A1(X,0) = ""
					A1(X,1) = "-----"
					A1(X,2) = "-----"
					A1(X,3) = "-----------------------------------"
					A1(X,4) = "小計："
					A1(X,5) = sum_UnPubCounts & " 份"
					A1(X,6) = sum_Counts & " 本"
					TotalUnPubCounts = TotalUnPubCounts & " 份"
					TotalCounts = TotalCounts & " 本"


					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("conttpText", strconttpText)	' >>$conttpText
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bkp_pno
					XLS.AddVariable("fgmoseaText", strfgmoseaText)	' >>$fgmoseaText
					XLS.AddVariable("mailtpText", strmailtpText)	' >>$mailtpText
					XLS.AddVariable("TotalUnPubCounts", TotalUnPubCounts)' >>$TotalUnPubCounts
					XLS.AddVariable("TotalCounts", TotalCounts)	' >>$TotalCounts
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("ORMtpCounts_stat2b.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "ORMtpCounts_stat2b.xls", True)

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
