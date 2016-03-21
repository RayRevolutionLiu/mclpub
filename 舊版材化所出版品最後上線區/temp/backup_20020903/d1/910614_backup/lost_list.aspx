<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>缺書清單</title>
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
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim EmpNo
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName, Date1, o_Date
				Dim Book01_New, Book01_Old, Book02_New, Book02_Old
				Dim	Book_Other, Book01_Amt, Book02_Amt, Book_Other_Amt
				Dim	preNo, preBook, count
				' Open Database------------------
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("mrlpub4")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				EmpCName = Request("cname") 'Session("cname")
				Date1 = Request("date")
				o_Date = Request("o_date")
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT  *, c1_or.or_nm, c1_or.or_addr, lst_syscd+lst_custno+lst_otp1cd+lst_otp1seq AS nostr ,c1_order.o_date "
				sqlcmd1 = sqlcmd1 & " FROM c1_lost INNER JOIN "
                sqlcmd1 = sqlcmd1 & "c1_or ON c1_lost.lst_syscd = c1_or.or_syscd AND "
                sqlcmd1 = sqlcmd1 & "c1_lost.lst_custno = c1_or.or_custno AND "
				sqlcmd1 = sqlcmd1 & "c1_lost.lst_otp1cd = c1_or.or_otp1cd AND "
                sqlcmd1 = sqlcmd1 & "c1_lost.lst_otp1seq = c1_or.or_otp1seq AND "
                sqlcmd1 = sqlcmd1 & "c1_lost.lst_oritem = c1_or.or_oritem  INNER JOIN "
                sqlcmd1 = sqlcmd1 & "dbo.c1_order ON dbo.c1_or.or_syscd = dbo.c1_order.o_syscd AND "
                sqlcmd1 = sqlcmd1 & "dbo.c1_or.or_custno = dbo.c1_order.o_custno AND "
                sqlcmd1 = sqlcmd1 & "dbo.c1_or.or_otp1cd = dbo.c1_order.o_otp1cd AND "
                sqlcmd1 = sqlcmd1 & "dbo.c1_or.or_otp1seq = dbo.c1_order.o_otp1seq "
                sqlcmd1 = sqlcmd1 & " where 1=1"
                if Request("status")="C" then	'已寄出
					if Date1<>"" then
						sqlcmd1 = sqlcmd1 & "AND (c1_lost.lst_date >= '" &Mid(Date1, 1,4)&Mid(Date1, 6,2)&Mid(Date1, 9,2)& "')"
						sqlcmd1 = sqlcmd1 & " AND (c1_lost.lst_date <= '" &Mid(Date1, 12,4)&Mid(Date1, 17,2)&Mid(Date1, 20,2)& "')"
					end if
					sqlcmd1 = sqlcmd1 & " AND c1_lost.lst_fgsent='C'"
				else if Request("status")="N" then	'未寄出
					sqlcmd1 = sqlcmd1 & " AND c1_lost.lst_fgsent<>'C'"
				end if
				if o_Date<>"" then
					sqlcmd1 = sqlcmd1 & " AND (c1_order.o_date >= '" &Mid(o_Date, 1,4)&Mid(o_Date, 6,2)&Mid(o_Date, 9,2)& "')"
					sqlcmd1 = sqlcmd1 & " AND (c1_order.o_date <= '" &Mid(o_Date, 12,4)&Mid(o_Date, 17,2)&Mid(o_Date, 20,2)& "')"
				end if

				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();return true;' Value='回上一頁'></FORM><BR>")
				else
					Rs1.MoveFirst
					rescount = 0
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst
				
				'------- 開始輸出結果 ---
				' 若有資料, 則輸出至 ExcelSpeedGen
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					' Array 1
					ReDim A1(rescount,11)
	
					' Populate Array 1
					preNo = ""
					preBook = ""
					count = 0
					Book01_New = 0
					Book01_Old = 0
					Book02_New = 0
					Book02_Old = 0
					Book_Other = 0
					Book01_Amt = 0
					Book02_Amt = 0
					Book_Other_Amt = 0
					for i = 0 to rescount-1
						' A 欄 = A1(i,0)
						A1(i,0) = count + 1
						count = count + 1
						A1(i,1) = Rs1("nostr").Value
						A1(i,2) = Rs1("lst_sdate").Value & "~" & Rs1("lst_edate").Value
						A1(i,3) = Rs1("or_nm").Value
						A1(i,4) = Rs1("or_addr").Value
						A1(i,5) = Mid(Rs1("lst_date").Value, 1, 4) & "/" & Mid(Rs1("lst_date").Value, 5, 2) & "/" & Mid(Rs1("lst_date").Value, 7, 3)
						A1(i,6) = Rs1("lst_cont").Value
						A1(i,7) = Rs1("lst_rea").Value
						if Rs1("lst_fgsent").Value="Y" then
							A1(i,8) = "可寄出"
						else if Rs1("lst_fgsent").Value="N" then
							A1(i,8) = "目前暫時無法寄出"
						else if Rs1("lst_fgsent").Value="C" then
							A1(i,8) = "已寄出"
						else if Rs1("lst_fgsent").Value="D" then
							A1(i,8) = "不處理"
						end if
						A1(i,9) = Mid(Rs1("o_date").Value, 1, 4) & "/" & Mid(Rs1("o_date").Value, 5, 2) & "/" & Mid(Rs1("o_date").Value, 7, 2)
						Rs1.MoveNext
						
						if Rs1.EOF
	    					Exit For
						end if
					next
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("srspn_cname", EmpCName)		' >>$srspn_cname
					XLS.AddVariable("date1", Date1)					' >>$date1
					XLS.AddVariable("o_date", o_Date)				' >>$o_date
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("lost_list.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "lost_list.xls", True)
					
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
