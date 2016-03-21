<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>客戶基本資料清單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="cont_list2" method="post" runat="server">
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
				Dim sqlcmd1, sqlcmd2	' SQL Command 1 ~ 2
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook


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

				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM dbo.cust "
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
				'sqlcmd1 = sqlcmd1 & "SELECT * FROM book INNER JOIN c2_cont ON book.bk_bkcd = c2_cont.cont_bkcd"
				sqlcmd1 = "SELECT cust.cust_custno, cust.cust_mfrno, cust.cust_nm, "
				sqlcmd1 = sqlcmd1 & " cust.cust_jbti, cust.cust_tel, cust.cust_fax, cust.cust_cell, "
				sqlcmd1 = sqlcmd1 & " cust.cust_email, cust.cust_itpcd, cust.cust_btpcd, "
				sqlcmd1 = sqlcmd1 & " cust.cust_rtpcd, mfr.mfr_inm, mfr.mfr_izip, mfr.mfr_iaddr, "
				sqlcmd1 = sqlcmd1 & " cust.cust_regdate, mfr.mfr_respnm "
				sqlcmd1 = sqlcmd1 & " FROM cust INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON cust.cust_mfrno = mfr.mfr_mfrno"				
				dim sql_where = ""
				If not (Request.QueryString("CustNoQ1") Is Nothing) Then
					sql_where = sql_where & "cust_custno > '" + Request.QueryString("CustNoQ1") + "'"
				End If
				If not (Request.QueryString("CustNoQ2") Is Nothing) Then
					sql_where = sql_where & "cust_custno < '" + Request.QueryString("CustNoQ2") + "'"
				End If		
				If not (Request.QueryString("TelAC") Is Nothing) Then
					sql_where = sql_where & "cust_tel like '%" + Request.QueryString("TelAC") + "%'"
				End If								
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)


				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")

				' 若有資料, 則輸出至 ExcelSpeedGen
				else
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")

					' Array 1
					ReDim A1(rescount*2,17)

					' Populate Array 1
					for i = 0 to rescount*2 - 1 step 2
						' 測試是否抓的到 result (但要先把 XLS.Generate() 那行 disable, 才看得到 Response.Write 結果)
						'Response.Write(Rs1("cust_custno").Value + ", ")

						' A 欄 = A1(i,0)
						A1(i,0) = Rs1("cust_custno").Value
						A1(i+1,0) = ""
						A1(i,1) = Rs1("cust_mfrno").Value
						A1(i+1,1) = Rs1("mfr_inm").Value
						A1(i,2) = Rs1("cust_nm").Value
						A1(i+1,2) = Rs1("mfr_izip").Value
						A1(i,3) = Rs1("cust_jbti").Value
						A1(i+1,3) = Rs1("mfr_iaddr").Value

						' E 欄 = A1(i,4)
						A1(i,4) = Rs1("cust_tel").Value
						A1(i+1,4) = Mid(Rs1("cust_regdate").Value, 1, 4) & "/" & Mid(Rs1("cust_regdate").Value, 5, 2) & "/" & Mid(Rs1("cust_regdate").Value, 7, 2)
						A1(i,5) = Rs1("cust_fax").Value
						A1(i+1,5) = ""
						A1(i,6) = Rs1("cust_cell").Value
						A1(i+1,6) = Rs1("mfr_respnm").Value
						A1(i,7) = Rs1("cust_email").Value
						A1(i+1,7) = ""

						' I 欄 = A1(i,8)
						A1(i,8) = Rs1("cust_itpcd").Value
						A1(i+1,8) = ""
						A1(i,9) = Rs1("cust_btpcd").Value
						A1(i+1,9) = ""
						A1(i,10) = Rs1("cust_rtpcd").Value
						A1(i+1,10) = ""

						'A1(i,13) = Rs1("cust_itpcd").Value
						'if(Rs1("cust_itpcd").Value=01)
							'A1(i,13) = "否"
						'else
							'A1(i,13) = "是"
						'end if


						' Highlight Some Rows: 此為一般欄位使用的格式
						Dim highlight
						highlight = "A" & (6+i) & ":K" & (7+i)
						if (i mod 4) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false )
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )
						end if
						Rs1.MoveNext

						if Rs1.EOF
	    					exit for
						end if
					next

					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Set Estimated Output File Size (Critical for speed)
					XLS.EstimatedSize = 50000

					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )

					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					'XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname


					' Location of Source Workbook
					SrcBook = Server.MapPath("custdata_list2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "custdata_list2a.xls", True)

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
