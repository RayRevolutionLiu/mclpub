<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告播出清單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="RptGenXml" method="post" runat="server">
			
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
				DIM TargetDate = Request("TargetDate")
				sqlcmd1 = "SELECT adr_imgurl, adr_navurl, adr_alttext, adr_adcate=CASE WHEN adr_adcate='M' THEN '首頁' WHEN adr_adcate='I' THEN '內頁' ELSE '奈米' END, adr_keyword=CASE WHEN adr_keyword='h0' THEN '正中' WHEN adr_keyword='h1' THEN '右一' WHEN adr_keyword='h2' THEN '右二' WHEN adr_keyword='h3' THEN '右三' WHEN adr_keyword='h4' THEN '右四' WHEN adr_keyword='w1' THEN '文一' WHEN adr_keyword='w2' THEN '文二' WHEN adr_keyword='w3' THEN '文三' WHEN adr_keyword='w4' THEN '文四' WHEN adr_keyword='w5' THEN '文五' WHEN adr_keyword='w6' THEN '文六' ELSE '' END, adr_impr, cont_contno, adr_seq, adr_remark=CASE WHEN adr_remark='&nbsp;' THEN '' END FROM  dbo.c4_adr INNER JOIN c4_cont ON cont_contno=adr_contno "+ " WHERE adr_sdate<='" + TargetDate + "' AND adr_edate>='" + TargetDate + "'"		
				
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
				ReDim A1(rescount+8, 9)	
				
				Dim count							
				i = 0
				count = 1
							
				Dim preNo
				Dim highlight
				' 用來計算處理了多少筆資料
				Dim rsIndex
				'合約計數
				Dim cc								
				
				' 輸出第一筆資料
				if NOT Rs1.EOF then
					A1(i,0) = Rs1("adr_imgurl").Value
					A1(i,1) = Rs1("adr_navurl").Value
					A1(i,2) = Rs1("adr_alttext").Value
					A1(i,3) = Rs1("adr_adcate").Value				
					A1(i,4) = Rs1("adr_keyword").Value
					A1(i,5) = Rs1("adr_impr").Value
					A1(i,6) = Rs1("cont_contno").Value
					A1(i,7) = Rs1("adr_seq").Value
					A1(i,8) = Rs1("adr_remark").Value
					
					'----- 格式設定 -----
					' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
					highlight = "A" & (6+i) & ":I" & (6+i)
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
					
					A1(i,0) = Rs1("adr_imgurl").Value
					A1(i,1) = Rs1("adr_navurl").Value
					A1(i,2) = Rs1("adr_alttext").Value
					A1(i,3) = Rs1("adr_adcate").Value				
					A1(i,4) = Rs1("adr_keyword").Value
					A1(i,5) = Rs1("adr_impr").Value
					A1(i,6) = Rs1("cont_contno").Value
					A1(i,7) = Rs1("adr_seq").Value
					A1(i,8) = Rs1("adr_remark").Value
 					
					'----- 格式設定 -----
					' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
					highlight = "A" & (6+i) & ":I" & (6+i)
					if (i mod 2) = 0
						XLS.FormatCells( 1, highlight, 2, "A1", false ) 
					else
						XLS.FormatCells( 1, highlight, 2, "B1", false )  
					end if	
					
					 					
					' Array index遞增
					i = i + 1
					
					' 處理Rs1的計數遞增
					rsIndex = rsIndex + 1
				
					' 換下一筆資料
					Rs1.MoveNext
					
				end while
					
					
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
				XLS.AddVariable("now", DateTime.Today.ToString("yyyy/MM/dd"))
					
				' Location of Source Workbook
				SrcBook = Server.MapPath("RptGenXml.xls")
				
				' Generate SpreadSheet and Stream to Client, Open in Place
				XLS.Generate(SrcBook, "RptGenXml.xls", True)
				
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
