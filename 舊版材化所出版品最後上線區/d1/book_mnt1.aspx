<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>印製份數統計表(大宗郵寄)</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="odlist" method="post" runat="server">
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
				
				Dim Rs1, Rs2, Rs3, Rs4, Rs5, Rs6			' Record Source 1 ~ 6
				Dim sqlcmd1, sqlcmd2, sqlcmd3, sqlcmd4, sqlcmd5, sqlcmd6	' SQL Command 1 ~ 6
				Dim rescount, i		' rescount= count of Rs2
				Dim A1, A2, A3, A4, A5, A6			' Array A1~ A6
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim EmpNo
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName, date_str, title
				Dim	preotp1cd, preotp2cd
				' Open Database------------------
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
'					oConn.Open("Provider=SQLOLEDB.1;Data Source=140.96.254.61,6161;User ID=pubmrlpub;Password=p%#ass;Initial Catalog=mrlpub")
				
				EmpCName = Request("cname")
				date_str = Request("date")
				title=Mid(date_str, 1, 4)&"年"&Mid(date_str, 5, 2)&"月"&Request("bookno")&"期  "&Request("btpcd")&" 印製份數統計表(雜誌叢書訂閱次系統)"
		
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm "
				sqlcmd1 = sqlcmd1 & "FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON "
                sqlcmd1 = sqlcmd1 & "dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND "
                sqlcmd1 = sqlcmd1 & "dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd "
				sqlcmd1 = sqlcmd1 & "WHERE (dbo.tmp_statistics.tmp_param2 = 1) "

				sqlcmd2 = "SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm "
				sqlcmd2 = sqlcmd2 & "FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON "
                sqlcmd2 = sqlcmd2 & "dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND "
                sqlcmd2 = sqlcmd2 & "dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd "
				sqlcmd2 = sqlcmd2 & "WHERE (dbo.tmp_statistics.tmp_param2 = 2) "

				sqlcmd3 = "SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm "
				sqlcmd3 = sqlcmd3 & "FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON "
                sqlcmd3 = sqlcmd3 & "dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND "
                sqlcmd3 = sqlcmd3 & "dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd "
				sqlcmd3 = sqlcmd3 & "WHERE (dbo.tmp_statistics.tmp_param2 = 3) "

				sqlcmd4 = "SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm "
				sqlcmd4 = sqlcmd4 & "FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON "
                sqlcmd4 = sqlcmd4 & "dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND "
                sqlcmd4 = sqlcmd4 & "dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd "
				sqlcmd4 = sqlcmd4 & "WHERE (dbo.tmp_statistics.tmp_param2 = 4) "

				sqlcmd5 = "SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm "
				sqlcmd5 = sqlcmd5 & "FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON "
                sqlcmd5 = sqlcmd5 & "dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND "
                sqlcmd5 = sqlcmd5 & "dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd "
				sqlcmd5 = sqlcmd5 & "WHERE (dbo.tmp_statistics.tmp_param2 = 5) "


				sqlcmd6 = "SELECT * FROM dbo.c1_od INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.ra_syscd AND "
				sqlcmd6 = sqlcmd6 & "dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND "
				sqlcmd6 = sqlcmd6 & "dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND "
				sqlcmd6 = sqlcmd6 & "dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND "
				sqlcmd6 = sqlcmd6 & "dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem "
				sqlcmd6 = sqlcmd6 & "WHERE (SUBSTRING(dbo.c1_od.od_sdate, 1, 6) <= '"& date_str 
				sqlcmd6 = sqlcmd6 & "') AND (SUBSTRING(dbo.c1_od.od_edate, 1, 6) >= '"& date_str
				sqlcmd6 = sqlcmd6 & "') AND (dbo.c1_ramt.ra_mnt > 5) AND (dbo.c1_ramt.ra_mtpcd = '11')"
				if Request("btpcd")="工材訂閱" then
					sqlcmd6 = sqlcmd6 & " AND (dbo.c1_od.od_btpcd='01') "
				else
					sqlcmd6 = sqlcmd6 & " AND (dbo.c1_od.od_btpcd='02') "
				end if
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				Rs2 = oConn.Execute(sqlcmd2)
				Rs3 = oConn.Execute(sqlcmd3)
				Rs4 = oConn.Execute(sqlcmd4)
				Rs5 = oConn.Execute(sqlcmd5)
				Rs6 = oConn.Execute(sqlcmd6)
				
				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();return true;' Value='回上一頁'></FORM><BR>")
				else
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					'A1
					Rs1.MoveFirst
					rescount = 0
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst
					
					' Array 1
					ReDim A1(rescount-1,2)
	
					' Populate Array 1
					preotp1cd = ""
					for i = 0 to rescount - 1 step 1
						' A 欄 = A1(i,0)
						if Rs1("tmp_otp1cd").Value = preotp1cd then
							A1(i,0) = ""
						else
							A1(i,0) = Rs1("otp_otp1nm").Value
						end if
						A1(i,1) = Rs1("otp_otp2nm").Value
						A1(i,2) = Rs1("tmp_param1").Value
						
						preotp1cd = Rs1("tmp_otp1cd").Value
						
						' 抓出合計之值, 並轉為變數型態
						
						Rs1.MoveNext
						
						if Rs1.EOF
	    					exit for
						end if
					next
					
					'A2
					Rs2.MoveFirst
					rescount = 0
					Do while not Rs2.EOF
						rescount = rescount + 1
						Rs2.MoveNext
					Loop
					Rs2.MoveFirst
					
					' Array 2
					ReDim A2(rescount-1,2)
	
					' Populate Array 2
					preotp1cd = ""
					for i = 0 to rescount - 1 step 1
						' A 欄 = A1(i,0)
						if Rs2("tmp_otp1cd").Value = preotp1cd then
							A2(i,0) = ""
						else
							A2(i,0) = Rs2("otp_otp1nm").Value
						end if
						A2(i,1) = Rs2("otp_otp2nm").Value
						A2(i,2) = Rs2("tmp_param1").Value
						
						preotp1cd = Rs2("tmp_otp1cd").Value
											
						Rs2.MoveNext
						
						if Rs2.EOF
	    					exit for
						end if
					next
					'A3
					Rs3.MoveFirst
					rescount = 0
					Do while not Rs3.EOF
						rescount = rescount + 1
						Rs3.MoveNext
					Loop
					Rs3.MoveFirst
					
					' Array 3
					ReDim A3(rescount-1,2)
	
					' Populate Array 3
					preotp1cd = ""
					for i = 0 to rescount - 1 step 1
						' A 欄 = A1(i,0)
						if Rs3("tmp_otp1cd").Value = preotp1cd then
							A3(i,0) = ""
						else
							A3(i,0) = Rs3("otp_otp1nm").Value
						end if
						A3(i,1) = Rs3("otp_otp2nm").Value
						A3(i,2) = Rs3("tmp_param1").Value
						
						preotp1cd = Rs3("tmp_otp1cd").Value
											
						Rs3.MoveNext
						
						if Rs3.EOF
	    					exit for
						end if
					next
					'A4
					Rs4.MoveFirst
					rescount = 0
					Do while not Rs4.EOF
						rescount = rescount + 1
						Rs4.MoveNext
					Loop
					Rs4.MoveFirst
					
					' Array 4
					ReDim A4(rescount-1,2)
	
					' Populate Array 4
					preotp1cd = ""
					for i = 0 to rescount - 1 step 1
						' A 欄 = A4(i,0)
						if Rs4("tmp_otp1cd").Value = preotp1cd then
							A4(i,0) = ""
						else
							A4(i,0) = Rs4("otp_otp1nm").Value
						end if
						A4(i,1) = Rs4("otp_otp2nm").Value
						A4(i,2) = Rs4("tmp_param1").Value
						
						preotp1cd = Rs4("tmp_otp1cd").Value
											
						Rs4.MoveNext
						
						if Rs4.EOF
	    					exit for
						end if
					next
					'A5
					Rs5.MoveFirst
					rescount = 0
					Do while not Rs5.EOF
						rescount = rescount + 1
						Rs5.MoveNext
					Loop
					Rs5.MoveFirst
					
					' Array 5
					ReDim A5(rescount-1,2)
	
					' Populate Array 5
					preotp1cd = ""
					for i = 0 to rescount - 1 step 1
						' A 欄 = A5(i,0)
						if Rs5("tmp_otp1cd").Value = preotp1cd then
							A5(i,0) = ""
						else
							A5(i,0) = Rs5("otp_otp1nm").Value
						end if
						A5(i,1) = Rs5("otp_otp2nm").Value
						A5(i,2) = Rs5("tmp_param1").Value
						
						preotp1cd = Rs5("tmp_otp1cd").Value
											
						Rs5.MoveNext
						
						if Rs5.EOF
	    					exit for
						end if
					next
					'A6
					if Rs6.EOF=false then
						Rs6.MoveFirst
						rescount = 0
						Do while not Rs6.EOF
							rescount = rescount + 1
							Rs6.MoveNext
						Loop
						Rs6.MoveFirst
					
						' Array 6
						ReDim A6(rescount-1,2)
	
						' Populate Array 6
						for i = 0 to rescount - 1 step 1
							' A 欄 = A6(i,0)
							A6(i,0) = Rs6("ra_mnt").Value
							A6(i,1)	= 1		
							Rs6.MoveNext
						
							if Rs6.EOF
	    						exit for
							end if
						next
					else
						ReDim A6(0,2)
						A6(0, 0)=0
						A6(0, 1)=0
					end if
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					XLS.AddRS_Array_2D( A2, true )
					XLS.AddRS_Array_2D( A3, true )
					XLS.AddRS_Array_2D( A4, true )
					XLS.AddRS_Array_2D( A5, true )
					XLS.AddRS_Array_2D( A6, true )
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					'XLS.AddVariable("date_str", date_str)		' >>$date_str
					XLS.AddVariable("title", title)				' >>$title
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("book_mnt1.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "book_mnt1.xls", True)
					
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
