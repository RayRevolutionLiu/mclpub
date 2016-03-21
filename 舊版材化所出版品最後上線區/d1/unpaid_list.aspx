<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>催款單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="unpaid_list" method="post" runat="server">
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
				
				Dim Rs1			' Record Source 1 ~ 5
				Dim sqlcmd1		' SQL Command 1 ~ 5
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim EmpNo
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName
				Dim Proj, Date1, Date2, Invdate, pydate
				Dim	Mfrno, Mfrname, Invno, Iano
				Dim	preNo, preBook, count
				' Open Database------------------
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				EmpCName = Request("cname") 'Session("cname")
				Proj = Request("proj")
				Date1 = Request("date1")
				Date2 = Request("date2")
				Mfrno = Request("mfrno")
				Mfrname = Request("mfrname")
				Invno = Request("invno")
				Iano = Request("iano")
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT *, dbo.srspn.srspn_cname, ISNULL(py_date, '') as pydate "
				sqlcmd1 = sqlcmd1 & " FROM dbo.v_ia_unpaid INNER JOIN dbo.srspn ON dbo.v_ia_unpaid.ias_createmen = dbo.srspn.srspn_empno where 1=1"
				if (Proj<>"") then
					sqlcmd1 = sqlcmd1 & " and iad_projno='" & Proj & "'"
				end if
				if (Date1<>"") then
					sqlcmd1 = sqlcmd1 & " and (ia_invdate>='" & Date1 & "' and ia_invdate<='" & Date2 & "')"
					Invdate = Date1 & "~" & Date2
				end if
				if (Mfrno<>"") then
					sqlcmd1 = sqlcmd1 & " and ia_mfrno='" & Mfrno & "'"
				end if
				if (Mfrname<>"") then
					sqlcmd1 = sqlcmd1 & " and mfr_inm LIKE '%" & Mfrname & "%'"
				end if
				if (Invno<>"") then
					sqlcmd1 = sqlcmd1 & " and ia_invno='" & Invno & "'"
				end if
				if (Iano<>"") then
					sqlcmd1 = sqlcmd1 & " and ia_iano='" & Iano & "'"
				end if
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				'------- 開始輸出結果 ---
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
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					' Array 1
					ReDim A1(rescount-1,25)
	
					' Populate Array 1
					for i = 0 to rescount - 1 step 1
						' A 欄 = A1(i,0)
						A1(i,0) = count + 1
						count = count + 1
						A1(i,1) = Rs1("mfr_inm").Value
						A1(i,2) = Rs1("ia_mfrno").Value
						if Rs1("ia_invdate").Value<>"" then
							A1(i,3) = Mid(Rs1("ia_invdate").Value, 1, 4) & "/" & Mid(Rs1("ia_invdate").Value, 5, 2) & "/" & Mid(Rs1("ia_invdate").Value, 7, 2)
						else
							A1(i,3) = ""
						end if
						A1(i,4) = Rs1("ia_invno").Value
						A1(i,5) = Rs1("iad_desc").Value
						A1(i,6) = Rs1("ia_pyat").Value
						A1(i,7) = Rs1("py_amt").Value
						A1(i,25) = Rs1("iad_amt").Value
						A1(i,8) = Rs1("py_chkno").Value
						A1(i,9) = Rs1("py_pyno").Value
'						A1(i,10) = Rs1("py_date").Value
						if Mid(Rs1("pydate").Value, 1, 1)="2" then
							A1(i,10) = Mid(Rs1("pydate").Value, 1, 4) & "/" & Mid(Rs1("pydate").Value, 5, 2) & "/" & Mid(Rs1("pydate").Value, 7, 2)
						else
							A1(i,10) = ""
						end if
						A1(i,11) = Rs1("ia_syscd").Value
						A1(i,12) = Rs1("ia_iano").Value
						A1(i,13) = Rs1("ia_iasdate").Value
						A1(i,14) = Rs1("ia_iasseq").Value
						if Rs1("ias_createdate").Value<>"" then
							A1(i,15) = Mid(Rs1("ias_createdate").Value, 1, 4) & "/" & Mid(Rs1("ias_createdate").Value, 5, 2) & "/" & Mid(Rs1("ias_createdate").Value, 7, 2)
						else
							A1(i,15) = ""
						end if
						A1(i,16) = Rs1("srspn_cname").Value
						A1(i,17) = Rs1("ia_fgitri").Value
						if Rs1("ias_trans_sap").Value="1" then
							A1(i,18) = "v"
						else
							A1(i,18) = ""
						end if
						if Rs1("ia_fgnonauto").Value="0" then
							A1(i,19) = ""
						else if Rs1("ia_fgnonauto").Value="1" then
							A1(i,19) = "手工發票"
						else if Rs1("ia_fgnonauto").Value="2" then
							A1(i,19) = "手工發票,手工繳款"
						else if Rs1("ia_fgnonauto").Value="3" then
							A1(i,19) = "手工繳款"
						end if
						A1(i,20) = Rs1("ia_remark").Value
						A1(i,21) = Rs1("iad_fk1").Value
						A1(i,22) = Rs1("iad_fk2").Value
						A1(i,23) = Rs1("iad_fk3").Value
						A1(i,24) = Rs1("iad_fk4").Value
						
						
						' 抓出合計之值, 並轉為變數型態
						
						Rs1.MoveNext
						
						if Rs1.EOF
	    					exit for
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
					XLS.AddVariable("proj", Proj)					' >>$proj
					XLS.AddVariable("invdate", Invdate)				' >>$invdate
					XLS.AddVariable("mfrno", Mfrno)					' >>$mfrno
					XLS.AddVariable("mfrname", Mfrname)				' >>$mfrname
					XLS.AddVariable("invno", Invno)					' >>$invno
					XLS.AddVariable("iano", Iano)					' >>$iano
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("unpaid_list.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "unpaid_list.xls", True)
					
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
