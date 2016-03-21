<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票郵寄清單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="ramt_stat2" method="post" runat="server">
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
				
				Dim Rs1, Rs2, Rs3					' Record Source 1 ~ 3
				Dim sqlcmd1, sqlcmd2, sqlcmd3		' SQL Command 1 ~ 3
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim BookCode
				
				' 自訂變數 (由代碼轉輸出至 .xls 的名稱)
				Dim BookName
				
				
				' Open Database------------------
				' a. Open a Microsoft Access Database
					'dbFile = Server.MapPath("test.mdb")
					'oConn = Server.CreateObject("ADODB.Connection")
					'oConn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFile)
				  
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("mrlpub")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				' 自前一頁抓傳遞 form 網頁變數 empno, 以抓出 EmpNo, EmpCName
				BookCode = Request("bkcd")
				
				' Get Rs3: 藉書籍類別代碼抓出書籍名稱
				' Open the RecordSets
				sqlcmd3 = "SELECT * FROM book"
				sqlcmd3 = sqlcmd3 & " WHERE (bk_bkcd='" + BookCode + "')"
				Rs3 = oConn.Execute(sqlcmd3)
				BookName = Rs3("bk_nm").Value
				'Response.Write("BookName= " & BookName & "<br>")			
				
				
				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT  COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM c2_pub "
				sqlcmd2 = sqlcmd2 & " INNER JOIN iad ON c2_pub.pub_syscd = iad.iad_fk1 "
				sqlcmd2 = sqlcmd2 & " AND c2_pub.pub_contno = iad.iad_fk2 "
				sqlcmd2 = sqlcmd2 & " AND c2_pub.pub_yyyymm = iad.iad_fk3 "
				sqlcmd2 = sqlcmd2 & " AND c2_pub.pub_pubseq = iad.iad_fk4 "
				sqlcmd2 = sqlcmd2 & " RIGHT OUTER JOIN ia "
				sqlcmd2 = sqlcmd2 & " ON iad.iad_iano = ia.ia_iano "
				sqlcmd2 = sqlcmd2 & " WHERE (ia.ia_syscd = 'C2') "
				sqlcmd2 = sqlcmd2 & " AND (ia.ia_status = '') "
				sqlcmd2 = sqlcmd2 & " GROUP BY c2_pub.pub_bkcd "
				sqlcmd2 = sqlcmd2 & " HAVING (c2_pub.pub_bkcd = '" & BookCode & "') "
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescount = 0
					Response.Write ("<FONT Color=Red><B>查詢結果 - 筆數為 0</B></FONT><BR>")
				else
					' 注意: 此處 rescount 值, 因 Sqlcmd2 抓出的值是 Double 值, 故要除以 2
					rescount = Rs2(0).Value / 2
				end if
				'Response.Write("rescount= " & rescount & "<br>")
				
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT ia.ia_iano, ia.ia_mfrno, mfr.mfr_inm, mfr.mfr_izip, "
				sqlcmd1 = sqlcmd1 & " mfr.mfr_iaddr "
				sqlcmd1 = sqlcmd1 & " FROM mfr "
				sqlcmd1 = sqlcmd1 & " INNER JOIN ia ON mfr.mfr_mfrno = ia.ia_mfrno "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_pub "
				sqlcmd1 = sqlcmd1 & " INNER JOIN iad "
				sqlcmd1 = sqlcmd1 & " ON c2_pub.pub_syscd = iad.iad_fk1 "
				sqlcmd1 = sqlcmd1 & " AND c2_pub.pub_contno = iad.iad_fk2 "
				sqlcmd1 = sqlcmd1 & " AND c2_pub.pub_yyyymm = iad.iad_fk3 "
				sqlcmd1 = sqlcmd1 & " AND c2_pub.pub_pubseq = iad.iad_fk4 "
				sqlcmd1 = sqlcmd1 & " ON ia.ia_iano = iad.iad_iano "
				sqlcmd1 = sqlcmd1 & " Group By c2_pub.pub_bkcd, ia.ia_iano, ia.ia_mfrno, mfr.mfr_inm, "
				sqlcmd1 = sqlcmd1 & " mfr.mfr_izip, mfr.mfr_iaddr, c2_pub.pub_bkcd, ia.ia_syscd, "
				sqlcmd1 = sqlcmd1 & " ia.ia_status "
				sqlcmd1 = sqlcmd1 & " HAVING (ia.ia_syscd = 'C2') "
				sqlcmd1 = sqlcmd1 & " AND (ia.ia_status = '') "
				sqlcmd1 = sqlcmd1 & " AND (c2_pub.pub_bkcd = '" & BookCode & "') "
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				
				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'></FORM><BR>")
				
				' 若有資料, 則輸出至 ExcelSpeedGen
				else
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					
					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it
					
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					XLS.AddRS_ADO(Rs1, 20)
					
					' Highlight Some Rows: 此為一般欄位使用的格式
					Dim highlight
					for i = 0 to rescount
						highlight = "A" & (6+i) & ":E" & (6+i)
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
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("book_name", BookName)	' >>$book_name
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("invmail_list2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "invmail_list2a.xls", True)
					
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
