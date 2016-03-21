<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告落版單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="RptAdList" method="post" runat="server">
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
				
				Dim Rs1, Rs2, Rs5, Rs6				' Record Source 1 ~ 7
				Dim Rs9, RS10					' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd5, sqlcmd6				' SQL Command 4 ~ 7
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
				strLoginEmpNo = Request("LEmpNo")
				if(strYYYYMM <> "") then
					strYYYYMM = strYYYYMM
					strYYYYMMnew = Mid(strYYYYMM, 1, 4) & "/" & Mid(strYYYYMM, 5, 2)
				else
					strYYYYMM = ""
				end if
				
'				if(strBkcd <> "") then
'					strBkcd = strBkcd
'					
'					' Get Rs5: 藉書籍代碼抓出書籍名稱
'					' Open the RecordSets
'					sqlcmd5 = "SELECT * FROM book"
'					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
'					Rs5 = oConn.Execute(sqlcmd5)
'					BkName = Rs5("bk_nm").Value
'					'Response.Write("BkName= " & BkName & "<br>")
'				else
'					strBkcd = ""
'				end if
				
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
				
				
				' ---- 製表人 ----
				if(Request("whoami") <> "") then
					strLoginEmpNo = Request("whoami")
					sqlcmd9 = "SELECT * FROM srspn"
					sqlcmd9 = sqlcmd9 & " WHERE (RTRIM(srspn_empno)='" + TRIM(strLoginEmpNo) + "')"
					Rs9 = oConn.Execute(sqlcmd9)
					strLoginEmpCName = Trim(Rs9("srspn_cname").Value)
					'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")
				else
					strLoginEmpNo = ""
					strLoginEmpCName = ""
				end if
				
				' 如果找不到
				if strLoginEmpCName="" then
					strLoginEmpCName = "(未知)"
				end if
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
				'Response.Write("strBkcd= " & strBkcd & "<br>")
				'Response.Write("strEmpNo= " & strEmpNo & "<br>")
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")
				
				
				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT COUNT(*) AS CountNo  FROM wk_c4_getad"
				
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
				sqlcmd1 = "SELECT cont_contno, mfr_inm, adr_sdate, adr_edate, adr_adcate, adr_keyword, adr_impr, adr_adamt, adr_desamt, adr_chgamt, adr_invamt, s_adr_drafttp_1, s_adr_drafttp_2, s_adr_drafttp_3, adr_imgurl, s_adr_urltp_1, s_adr_urltp_2, s_adr_urltp_3, adr_navurl,  adr_alttext, adr_remark FROM wk_c4_adlist"
				'		                  >>2      >>3        >>4        >>5         >>6          >>7       >>8        >>9        >>10        >>11        >>12             >>13	            >>14             >>15        >>16           >>17           >>18           >>19        >>20          >>21        >>22          

				'設定條件
				Dim strFilter = Request("strFilter")
				if not strFilter = "" then
					sqlcmd1 = sqlcmd1 & " WHERE " & strFilter
				end if
				
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				' Create Excel File
				XLS = Server.CreateObject("XLSpeedGen.ASP")
									
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
				end if
				
				'Response.Write("Rs1= " & Rs1(0).value & "<br>")
				'Response.Write("Rs2= " & Rs2(0).value & "<br>")
				
				' 計算Rs1的筆數
				rescount = 0
				if NOT Rs1.EOF then
					Rs1.MoveFirst
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst
				end if
				
				' Array 1
				ReDim A1(rescount*2+1,23)	
				
				Dim count							
				i = 0
				count = 1
				
				Dim SubSumAdAmt, SubSumDesAmt, SubSumChgAmt, SubSumInvAmt
				SubSumAdAmt = 0
				SubSumDesAmt = 0
				SubSumChgAmt = 0
				SubSumInvAmt = 0				
				
				Dim TotalSumAdAmt, TotalSumDesAmt, TotalSumChgAmt, TotalSumInvAmt
				TotalSumAdAmt = 0
				TotalSumDesAmt = 0
				TotalSumChgAmt = 0
				TotalSumInvAmt = 0								
				
				Dim preNo
				Dim highlight
				' 用來計算處理了多少筆資料
				Dim rsIndex
				'合約計數
				Dim cc								
				
				' 輸出第一筆資料
				if NOT Rs1.EOF then
					A1(i,0) = 1
					A1(i,2) = Rs1("cont_contno").Value
					A1(i,3) = Rs1("mfr_inm").Value				
					A1(i,4) = Rs1("adr_sdate").Value
					A1(i,5) = Rs1("adr_edate").Value
					A1(i,6) = Rs1("adr_adcate").Value
					A1(i,7) = Rs1("adr_keyword").Value
					A1(i,8) = Rs1("adr_impr").Value
					A1(i,9) = Rs1("adr_adamt").Value
					A1(i,10) = Rs1("adr_desamt").Value
					A1(i,11) = Rs1("adr_chgamt").Value
					A1(i,12) = Rs1("adr_invamt").Value
					A1(i,13) = Rs1("s_adr_drafttp_1").Value
					A1(i,14) = Rs1("s_adr_drafttp_2").Value
					A1(i,15) = Rs1("s_adr_drafttp_3").Value
					A1(i,16) = Rs1("adr_imgurl").Value
					A1(i,17) = Rs1("s_adr_urltp_1").Value
					A1(i,18) = Rs1("s_adr_urltp_2").Value
					A1(i,19) = Rs1("s_adr_urltp_3").Value
					A1(i,20) = Rs1("adr_navurl").Value
					A1(i,21) = Rs1("adr_alttext").Value
					A1(i,22) = Rs1("adr_remark").Value
					
					SubSumAdAmt = SubSumAdAmt + Rs1("adr_adamt").Value
					SubSumDesAmt = SubSumDesAmt + Rs1("adr_desamt").Value
					SubSumChgAmt = SubSumChgAmt + Rs1("adr_chgamt").Value
					SubSumInvAmt = SubSumInvAmt	+ Rs1("adr_invamt").Value

					
					preNo = ""
					preNo = Rs1("cont_contno").Value
					
					'----- 格式設定 -----
					' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
					highlight = "A" & (6+i) & ":W" & (6+i)
					if (i mod 2) = 0
						XLS.FormatCells( 1, highlight, 2, "A1", false ) 
					else
						XLS.FormatCells( 1, highlight, 2, "B1", false )  
					end if				
					
					rsIndex = 1
					
					cc = 1				
					
					i = i + 1
					rsIndex = rsIndex + 1
					count = count + 1												
					
					
					Rs1.MoveNext
				end if
				' ---- 以上為第一筆資料輸出	----
				
				Dim ChgBkName

				while rsIndex < rescount
					
					if Rs1("cont_contno").Value = preNo then				
						' 重覆時, 顯示要清空的資料項
						A1(i,0) = ""
						A1(i,1) = ""
						A1(i,2) = ""
						A1(i,3) = ""
					
						' 重複時, 其他要顯示的欄位
						A1(i,4) = Rs1("adr_sdate").Value
						A1(i,5) = Rs1("adr_edate").Value
						A1(i,6) = Rs1("adr_adcate").Value
						A1(i,7) = Rs1("adr_keyword").Value
						A1(i,8) = Rs1("adr_impr").Value
						A1(i,9) = Rs1("adr_adamt").Value
						A1(i,10) = Rs1("adr_desamt").Value
						A1(i,11) = Rs1("adr_chgamt").Value
						A1(i,12) = Rs1("adr_invamt").Value
						A1(i,13) = Rs1("s_adr_drafttp_1").Value
						A1(i,14) = Rs1("s_adr_drafttp_2").Value
						A1(i,15) = Rs1("s_adr_drafttp_3").Value
						A1(i,16) = Rs1("adr_imgurl").Value
						A1(i,17) = Rs1("s_adr_urltp_1").Value
						A1(i,18) = Rs1("s_adr_urltp_2").Value
						A1(i,19) = Rs1("s_adr_urltp_3").Value
						A1(i,20) = Rs1("adr_navurl").Value
						A1(i,21) = Rs1("adr_alttext").Value
						A1(i,22) = Rs1("adr_remark").Value		
					
					else
						' 不重複時，要先插入一筆小計
						A1(i, 1) = "小計"
						A1(i, 2) = ""
						A1(i, 3) = ""
						A1(i, 4) = ""
						A1(i, 5) = ""
						A1(i, 6) = ""
						A1(i, 7) = ""
						A1(i, 8) = ""
						A1(i, 9) = SubSumAdAmt
						A1(i, 10) = SubSumDesAmt
						A1(i, 11) = SubSumChgAmt
						A1(i, 12) = SubSumInvAmt
						A1(i, 13) = ""
						A1(i, 14) = ""
						A1(i, 15) = ""
						A1(i, 16) = ""
						A1(i, 17) = ""
						A1(i, 18) = ""
						A1(i, 19) = ""
						A1(i, 20) = ""
						A1(i, 21) = ""
						A1(i, 22) = ""
						
						' 不重複時，要重設小計金額
						SubSumAdAmt = 0
						SubSumDesAmt = 0
						SubSumChgAmt = 0
						SubSumInvAmt = 0
						
						' 不重複時，要把preNo指定為新的
						preNo = Rs1("cont_contno").Value
						
						'----- 格式設定 -----
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						highlight = "A" & (6+i) & ":W" & (6+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false ) 
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )  
						end if						
					
						' 不重複時，處理好小計了，遞增array index
						i = i + 1
						
						' 不重複，等於是下一筆合約了
						cc = cc + 1
						
						' 不重複時，處理目前Rs的所有欄位資料
						A1(i,0) = cc
						A1(i,2) = Rs1("cont_contno").Value
						A1(i,3) = Rs1("mfr_inm").Value
						A1(i,4) = Rs1("adr_sdate").Value
						A1(i,5) = Rs1("adr_edate").Value
						A1(i,6) = Rs1("adr_adcate").Value
						A1(i,7) = Rs1("adr_keyword").Value
						A1(i,8) = Rs1("adr_impr").Value
						A1(i,9) = Rs1("adr_adamt").Value
						A1(i,10) = Rs1("adr_desamt").Value
						A1(i,11) = Rs1("adr_chgamt").Value
						A1(i,12) = Rs1("adr_invamt").Value
						A1(i,13) = Rs1("s_adr_drafttp_1").Value
						A1(i,14) = Rs1("s_adr_drafttp_2").Value
						A1(i,15) = Rs1("s_adr_drafttp_3").Value
						A1(i,16) = Rs1("adr_imgurl").Value
						A1(i,17) = Rs1("s_adr_urltp_1").Value
						A1(i,18) = Rs1("s_adr_urltp_2").Value
						A1(i,19) = Rs1("s_adr_urltp_3").Value
						A1(i,20) = Rs1("adr_navurl").Value
						A1(i,21) = Rs1("adr_alttext").Value
						A1(i,22) = Rs1("adr_remark").Value							
					
 					end if
 					
					'----- 格式設定 -----
					' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
					highlight = "A" & (6+i) & ":W" & (6+i)
					if (i mod 2) = 0
						XLS.FormatCells( 1, highlight, 2, "A1", false ) 
					else
						XLS.FormatCells( 1, highlight, 2, "B1", false )  
					end if	
					
					 					
 					' 小計累加
					SubSumAdAmt = SubSumAdAmt + Rs1("adr_adamt").Value
					SubSumDesAmt = SubSumDesAmt + Rs1("adr_desamt").Value
					SubSumChgAmt = SubSumChgAmt + Rs1("adr_chgamt").Value
					SubSumInvAmt = SubSumInvAmt	+ Rs1("adr_invamt").Value
					
					' 總計累加
					TotalSumAdAmt = TotalSumAdAmt + Rs1("adr_adamt").Value
					TotalSumDesAmt = TotalSumDesAmt + Rs1("adr_desamt").Value
					TotalSumChgAmt = TotalSumChgAmt + Rs1("adr_chgamt").Value
					TotalSumInvAmt = TotalSumInvAmt	+ Rs1("adr_invamt").Value
					

					' Array index遞增
					i = i + 1
					
					' 處理Rs1的計數遞增
					rsIndex = rsIndex + 1
				
					' 換下一筆資料
					Rs1.MoveNext
					
				end while
				
				' 處理完了，最後的小計			
				A1(i, 1) = "小計"
				A1(i, 2) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = ""
				A1(i, 7) = ""
				A1(i, 8) = ""
				A1(i, 9) = SubSumAdAmt
				A1(i, 10) = SubSumDesAmt
				A1(i, 11) = SubSumChgAmt
				A1(i, 12) = SubSumInvAmt
				A1(i, 13) = ""
				A1(i, 14) = ""
				A1(i, 15) = ""
				A1(i, 16) = ""
				A1(i, 17) = ""
				A1(i, 18) = ""
				A1(i, 19) = ""
				A1(i, 20) = ""
				A1(i, 21) = ""
				A1(i, 22) = ""
				'----- 格式設定 -----
				' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
				highlight = "A" & (6+i) & ":W" & (6+i)
				if (i mod 2) = 0
					XLS.FormatCells( 1, highlight, 2, "A1", false ) 
				else
					XLS.FormatCells( 1, highlight, 2, "B1", false )  
				end if	
									
				' 總計
				i = i + 1
				A1(i, 1) = "總計"
				A1(i, 2) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = ""
				A1(i, 7) = ""
				A1(i, 8) = ""
				A1(i, 9) = TotalSumAdAmt
				A1(i, 10) = TotalSumDesAmt
				A1(i, 11) = TotalSumChgAmt
				A1(i, 12) = TotalSumInvAmt
				A1(i, 13) = ""
				A1(i, 14) = ""
				A1(i, 15) = ""
				A1(i, 16) = ""
				A1(i, 17) = ""
				A1(i, 18) = ""
				A1(i, 19) = ""
				A1(i, 20) = ""
				A1(i, 21) = ""
				A1(i, 22) = ""				
				
				'----- 格式設定 -----
				' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
				highlight = "A" & (6+i) & ":W" & (6+i)
				if (i mod 2) = 0
					XLS.FormatCells( 1, highlight, 2, "A1", false ) 
				else
					XLS.FormatCells( 1, highlight, 2, "B1", false )  
				end if					
					
				' Hide Sheet 2
				XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it
					
				' Rows are in 1st Dimension of Array
				XLS.AddRS_Array_2D( A1, true )
					
					
				' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
				'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
				'XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
				'XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
				XLS.AddVariable("login_cname", strLoginEmpCName)	' >>$login_cname
				'XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
					
				' Location of Source Workbook
				SrcBook = Server.MapPath("RptAdList.xls")
				
				' Generate SpreadSheet and Stream to Client, Open in Place
				XLS.Generate(SrcBook, "RptAdList.xls", True)
				
				' Destroy object when done
				XLS = Nothing
					
				' Cleanup Code - Close Connection and all Recordsets
				oConn.close
				oConn = Nothing
			'End if
			%>
		</form>
	</body>
</HTML>
