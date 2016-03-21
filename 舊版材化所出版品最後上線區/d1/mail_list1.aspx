<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>郵寄清單</title>
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
				
				Dim Rs1		' Record Source 1
				Dim sqlcmd1	' SQL Command 1
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim EmpNo
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName, MailArea, MailType
				Dim	preNo, preIano, count
				' Open Database------------------
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				EmpCName = Request("cname") 'Session("cname")
				
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT         tmp_label1.*, c1_order.o_otp2cd, c1_cust.cust_nm, mfr.mfr_inm, c1_or.or_nm, c1_or.or_addr, c1_or.or_zip, c1_or.or_fgmosea "
				sqlcmd1 = sqlcmd1 & ",c1_order.o_date FROM c1_or INNER JOIN "
                sqlcmd1 = sqlcmd1 & "c1_order ON c1_or.or_syscd = c1_order.o_syscd AND "
                sqlcmd1 = sqlcmd1 & "c1_or.or_custno = c1_order.o_custno AND "
                sqlcmd1 = sqlcmd1 & "c1_or.or_otp1cd = c1_order.o_otp1cd AND "
                sqlcmd1 = sqlcmd1 & "c1_or.or_otp1seq = c1_order.o_otp1seq INNER JOIN "
                sqlcmd1 = sqlcmd1 & "tmp_label1 ON c1_order.o_syscd = tmp_label1.od_syscd AND "
                sqlcmd1 = sqlcmd1 & "c1_order.o_custno = tmp_label1.od_custno AND "
                sqlcmd1 = sqlcmd1 & "c1_order.o_otp1cd = tmp_label1.od_otp1cd AND "
                sqlcmd1 = sqlcmd1 & "c1_order.o_otp1seq = tmp_label1.od_otp1seq AND "
                sqlcmd1 = sqlcmd1 & "c1_or.or_oritem = tmp_label1.ra_oritem INNER JOIN "
                sqlcmd1 = sqlcmd1 & "c1_cust ON c1_order.o_custno = c1_cust.cust_custno INNER JOIN "
                sqlcmd1 = sqlcmd1 & "mfr ON c1_cust.cust_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & "WHERE c1_order.o_otp2cd = '"& Request("type2") & "'"
				if Request("mnt")="0" then '5本以上(不含5本)
					sqlcmd1 = sqlcmd1 & " and tmp_label1.ra_mnt >5"
				else
					sqlcmd1 = sqlcmd1 & " and tmp_label1.ra_mnt =" & Request("mnt")
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
					if Rs1("or_fgmosea").Value="0" then
						MailArea = "國內"
					else
						MailArea = "國外"
					end if
					MailType = Rs1("mtp_nm").Value
				
				'------- 開始輸出結果 ---
				' 若有資料, 則輸出至 ExcelSpeedGen
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					' Array 1
					ReDim A1(rescount,11)
	
					' Populate Array 1
					count = 0
					for i = 0 to rescount-1
						' A 欄 = A1(i,0)
						A1(i,0) = count + 1
						count = count + 1
						A1(i,1) = Rs1("or_nm").Value
						A1(i,2) = Rs1("or_zip").Value
						A1(i,3) = Rs1("or_addr").Value
						A1(i,4) = Rs1("od_syscd").Value & Trim(Rs1("od_custno").Value) & Trim(Rs1("od_otp1cd").Value) & Trim(Rs1("od_otp1seq").Value)
						A1(i,5) = Mid(Rs1("o_date").Value, 1, 4) & "/" & Mid(Rs1("o_date").Value, 5, 2) & "/" & Mid(Rs1("o_date").Value, 7, 2)
						A1(i,6) = Rs1("od_custno").Value
						A1(i,7) = Rs1("cust_nm").Value
						A1(i,8) = Rs1("mfr_inm").Value
						A1(i,9) = Rs1("od_sdate").Value & "~" &Rs1("od_edate").Value
						A1(i,10) = Rs1("ra_mnt").Value
						
						
						' 抓出合計之值, 並轉為變數型態
						Rs1.MoveNext
						
						if Rs1.EOF
	    					Exit For
						end if
					next
'					Loop
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("srspn_cname", EmpCName)		' >>$srspn_cname
					XLS.AddVariable("mail_area", MailArea)		' >>$mail_area
					XLS.AddVariable("mail_type", MailType)		' >>$mail_type
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("mail_list1.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "mail_list1.xls", True)
					
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
