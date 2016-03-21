<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>郵寄本數統計表</title>
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
				
				Dim Rs1, Rs2			' Record Source 1 ~ 2
				Dim sqlcmd1, sqlcmd2		' SQL Command 1 ~ 2
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim EndDate
				
				
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
				EndDate = Request("enddate")
				
				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT DISTINCT count(*) As CountNo "
				sqlcmd2 = sqlcmd2 & " FROM  c2_or "
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescount = 0
					Response.Write("<FONT Color=Red><B>查詢結果 - 筆數為 0</B></FONT><BR>")
				else
					rescount = Rs2(0).Value
				end if
				'Response.Write("rescount= " & rescount & "<br>")
				
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = "SELECT DISTINCT c2_or.or_contno, c2_pub.pub_yyyymm, "
				sqlcmd1 = sqlcmd1 & " mfr.mfr_inm, mtp.mtp_nm, c2_or.or_zip, "
				sqlcmd1 = sqlcmd1 & " c2_or.or_addr, c2_or.or_pubcnt, c2_cont.cont_freetm, c2_or.or_mtpcd "
				sqlcmd1 = sqlcmd1 & " FROM dbo.c2_pub "
				sqlcmd1 = sqlcmd1 & " INNER JOIN c2_or ON dbo.c2_pub.pub_syscd = c2_or.or_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_contno = c2_or.or_contno  "
				sqlcmd1 = sqlcmd1 & " INNER JOIN c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_syscd = c2_cont.cont_syscd "
				sqlcmd1 = sqlcmd1 & " INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " INNER JOIN mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd "
				sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_fgclosed <> '1') AND (c2_pub.pub_yyyymm<='" + EndDate + "')"
				sqlcmd1 = sqlcmd1 & " ORDER BY c2_or.or_contno, c2_pub.pub_yyyymm, c2_or.or_mtpcd "
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				
				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")
				
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
					
					
					Dim highlight
					Dim YYYYMMhighlight
					for i = 0 to rescount
						' 此為特別欄位使用的格式 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 特別格式寫在 sheet 2 的指定欄位裡, 如 A7/B7
						' 目前 bug: 雖然 B6~Bi 的格式以 FormatCells 有做成功, 但卻要在 B6~Bi 的值處, 按下 Enter 鍵來會顯示正確的 FormatCells 格式說!?!  但在 cont_list2.aspx 卻不會有此情形
						YYYYMMhighlight = "B" & (6+i)
						if (i mod 2) = 0
							' 奇數行, 以 sheet2 指定欄位的 Format 顯示
							XLS.FormatCells( 1, YYYYMMhighlight, 2, "A7", false ) 
						else
							' 偶數行, 以 sheet2 指定欄位的 Format 顯示
							XLS.FormatCells( 1, YYYYMMhighlight, 2, "B7", false )  
						end if
						'Response.Write("YYYYMMhighlight= " & YYYYMMhighlight & "<br>")
						
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						highlight = "A" & (6+i) & ":H" & (6+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false ) 
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )  
						end if
						'Response.Write("highlight= " & highlight & "<br>")
						Rs1.MoveNext
						
						if Rs1.EOF
	    					exit for
						end if
					next
					
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					EndDate = Mid(EndDate, 1, 4) & "/" & Mid(EndDate, 5, 2)
					XLS.AddVariable("edate", EndDate)	' >>$edate
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("ramt_stat2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "ramt_stat2a.xls", True)
					
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
