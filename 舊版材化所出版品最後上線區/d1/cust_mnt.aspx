<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>客戶份數表</title>
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
				
				Dim Rs1, Rs2, Rs4, Rs5			' Record Source 1 ~ 5
				Dim sqlcmd1, sqlcmd2, sqlcmd4, sqlcmd5	' SQL Command 1 ~ 5
				Dim rescount, i		' rescount= count of Rs2
				Dim A1, A2			' Array A1, A2
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim EmpNo
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName, date_str, title
				Dim Book01_New, Book01_Old, Book02_New, Book02_Old
				Dim	Book_Other, Book01_Amt, Book02_Amt, Book_Other_Amt
				Dim	preotp1cd, preotp2cd
				' Open Database------------------
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=140.96.254.61,6161;User ID=pubmrlpub;Password=p%#ass;Initial Catalog=mrlpub")
				
				EmpCName = Request("cname")
				title=Request("btpcd")&" 客戶份數表(雜誌叢書訂閱次系統)"
				date_str = Request("date")
		
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.c1_obtp.obtp_obtpnm "
				sqlcmd1 = sqlcmd1 & "FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON "
                sqlcmd1 = sqlcmd1 & "dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND "
                sqlcmd1 = sqlcmd1 & "dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd INNER JOIN "
                sqlcmd1 = sqlcmd1 & "dbo.c1_obtp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_otp1cd "
                sqlcmd1 = sqlcmd1 & "AND dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_obtpcd "
				sqlcmd1 = sqlcmd1 & "WHERE (dbo.tmp_statistics.tmp_otp1cd = '01') "

				sqlcmd2 = "SELECT dbo.tmp_statistics.*, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.c1_obtp.obtp_obtpnm "
				sqlcmd2 = sqlcmd2 & "FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON "
                sqlcmd2 = sqlcmd2 & "dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND "
                sqlcmd2 = sqlcmd2 & "dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd INNER JOIN "
                sqlcmd2 = sqlcmd2 & "dbo.c1_obtp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_otp1cd "
                sqlcmd2 = sqlcmd2 & "AND dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_obtpcd "
				sqlcmd2 = sqlcmd2 & "WHERE (dbo.tmp_statistics.tmp_otp1cd = '02') "
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				Rs2 = oConn.Execute(sqlcmd2)
				
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
					ReDim A1(rescount-1,4)
	
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
						A1(i,3) = Rs1("tmp_param2").Value
						
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
					ReDim A2(rescount-1,4)
	
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
						A2(i,3) = Rs2("tmp_param2").Value
						
						preotp1cd = Rs2("tmp_otp1cd").Value
						
						' 抓出合計之值, 並轉為變數型態
						
						Rs2.MoveNext
						
						if Rs2.EOF
	    					exit for
						end if
					next
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					XLS.AddRS_Array_2D( A2, true )
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("date_str", date_str)		' >>$date_str
					XLS.AddVariable("title", title)				' >>$title
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("cust_mnt.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "cust_mnt.xls", True)
					
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
