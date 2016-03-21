<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告合約書清單</title>
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
				Dim EmpCName
				Dim	preNo, preIano, count
				' Open Database------------------
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("mrlpub4")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				EmpCName = Request("cname") 'Session("cname")
				
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT py.*, ia.ia_syscd, ia.ia_mfrno, mfr.mfr_inm, ia.ia_invno, ia.ia_rnm, ia_iano, ia_pyat,"
                sqlcmd1 = sqlcmd1 & "iad_syscd, iad.iad_fk1, iad.iad_fk2, iad.iad_fk3, iad.iad_projno, iad.iad_desc "
				sqlcmd1 = sqlcmd1 & "FROM py INNER JOIN "
                sqlcmd1 = sqlcmd1 & "ia ON py.py_pyno = ia.ia_pyno INNER JOIN "
                sqlcmd1 = sqlcmd1 & "mfr ON ia.ia_mfrno = mfr.mfr_mfrno INNER JOIN "
                sqlcmd1 = sqlcmd1 & "iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano "
				sqlcmd1 = sqlcmd1 & "WHERE (py.py_pytpcd = '01') and py_pysdate='"& Request("yyyymm") & "' and py_pysseq='"&Request("batch") &"'"
				sqlcmd1 = sqlcmd1 & " ORDER BY  py.py_pyno"
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
					ReDim A1(rescount,12)
	
					' Populate Array 1
					preNo = ""
					preIano = ""
					count = 0
					for i = 0 to rescount-1
						' A 欄 = A1(i,0)
						if preNo=Rs1("iad_syscd").Value & Trim(Rs1("iad_fk1").Value) & Trim(Rs1("iad_fk2").Value) & Trim(Rs1("iad_fk3").Value) then
							A1(i,0) = ""
							A1(i,1) = ""
							A1(i,2) = ""
							if Rs1("ia_iano").Value = preIano then
								A1(i,3) = ""
								A1(i,4) = ""
								A1(i,5) = ""
								A1(i,6) = ""
								A1(i,7) = ""
								A1(i,10) = ""
								A1(i,11) = ""
							else
								A1(i,3) = Rs1("ia_pyat").Value
								A1(i,4) = Rs1("ia_rnm").Value
								A1(i,5) = Rs1("mfr_inm").Value
								A1(i,6) = Rs1("ia_mfrno").Value
								A1(i,7) = Rs1("ia_invno").Value
								A1(i,10) = Rs1("ia_syscd").Value
								A1(i,11) = Rs1("ia_iano").Value
							end if
						else
							A1(i,0) = count + 1
							count = count + 1
							A1(i,1) = Rs1("iad_syscd").Value & Trim(Rs1("iad_fk1").Value) & Trim(Rs1("iad_fk2").Value) & Trim(Rs1("iad_fk3").Value)
							A1(i,2) = Rs1("py_pyno").Value
							A1(i,3) = Rs1("ia_pyat").Value
							A1(i,4) = Rs1("ia_rnm").Value
							A1(i,5) = Rs1("mfr_inm").Value
							A1(i,6) = Rs1("ia_mfrno").Value
							A1(i,7) = Rs1("ia_invno").Value
							A1(i,10) = Rs1("ia_syscd").Value
							A1(i,11) = Rs1("ia_iano").Value
						end if
						A1(i,8) = Rs1("iad_projno").Value
						A1(i,9) = Rs1("iad_desc").Value
						
						preNo = Rs1("iad_syscd").Value & Trim(Rs1("iad_fk1").Value) & Trim(Rs1("iad_fk2").Value) & Trim(Rs1("iad_fk3").Value)
						preIano = Rs1("ia_iano").Value
						
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
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("py_list1.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "py_list1.xls", True)
					
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
