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
				
				Dim Rs1, Rs2, Rs4, Rs5			' Record Source 1 ~ 5
				Dim sqlcmd1, sqlcmd2, sqlcmd4, sqlcmd5	' SQL Command 1 ~ 5
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim EmpNo
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim EmpCName
				Dim Book01_New, Book01_Old, Book02_New, Book02_Old
				Dim	Book_Other, Book01_Amt, Book02_Amt, Book_Other_Amt
				Dim	preNo, preBook, count
				' Open Database------------------
				' a. Open a Microsoft Access Database
					'dbFile = Server.MapPath("test.mdb")
					'oConn = Server.CreateObject("ADODB.Connection")
					'oConn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFile)
				  
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("mrlpub")
					oConn = Server.CreateObject("ADODB.Connection")
					'oConn.Open(DSN)
					oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				' 自前一頁抓傳遞 form 網頁變數 empno, 以抓出 EmpNo, EmpCName
'				EmpNo = Request("empno")
				
				' Get Rs5: 藉業務員工號抓出業務員姓名
				' Open the RecordSets
'				sqlcmd5 = "SELECT * FROM srspn"
'				sqlcmd5 = sqlcmd5 & " WHERE (srspn_empno='" + EmpNo + "')"
'				Rs5 = oConn.Execute(sqlcmd5)
'				EmpCName = Rs5("srspn_cname").Value
				EmpCName = Request("cname") 'Session("cname")
				'Response.Write("EmpCName= " & EmpCName & "<br>")			
				
				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT count(*) As CountNo FROM tmp_list1"
'				sqlcmd2 = sqlcmd2 & " WHERE (c2_cont.cont_fgclosed <> '1') AND (c2_cont.cont_empno='" + EmpNo + "')"
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
				sqlcmd1 = "SELECT * FROM tmp_list1"
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'></FORM><BR>")
				
				' 若有資料, 則輸出至 ExcelSpeedGen
				else
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					' Array 1
					ReDim A1(rescount,18)
	
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
					for i = 0 to rescount - 1 step 1
						' 測試是否抓的到 result (但要先把 XLS.Generate() 那行 disable, 才看得到 Response.Write 結果)
						'Response.Write(Rs1("cont_contno").Value & ", ")
						'Response.Write(Rs1("cont_signdate").Value & ", ")
						'Response.Write(Rs1("cont_mfrno").Value & ", ")
						'Response.Write(Rs1("cont_aunm").Value & ", ")
						'Response.Write(Rs1("cont_autel").Value & "<br>")
						' A 欄 = A1(i,0)
						if Rs1("tmp_no").Value = preNo then
							A1(i,0) = ""
							A1(i,1) = ""
							A1(i,2) = ""
							A1(i,3) = ""
							A1(i,4) = ""
							if Rs1("tmp_obtpnm").Value = preBook then
								A1(i,5) = ""
								A1(i,6) = ""
								A1(i,7) = ""
								A1(i,8) = ""
							else
								A1(i,5) = Rs1("tmp_obtpnm").Value
								if Mid(Rs1("tmp_no").Value, 11, 3)="001" then
									A1(i,6) = "新"
								else
									A1(i,6) = "續"
								end if
'								A1(i,5) = Rs1("tmp_custtp").Value
								if (Mid(Rs1("tmp_datestr").Value, 1, 1)="1" or Mid(Rs1("tmp_datestr").Value, 1, 1)="2") then
									A1(i,7) = Mid(Rs1("tmp_datestr").Value, 1, 4) & "/" & Mid(Rs1("tmp_datestr").Value, 5, 2) & "/" & Mid(Rs1("tmp_datestr").Value, 7, 3) & Mid(Rs1("tmp_datestr").Value, 10, 4) & "/" & Mid(Rs1("tmp_datestr").Value, 14, 2) & "/" & Mid(Rs1("tmp_datestr").Value, 16, 2)
								else
									A1(i,7) = ""
								end if
'								A1(i,6) = Rs1("tmp_datestr").Value
								A1(i,8) = Rs1("tmp_amt").Value
								if Rs1("tmp_obtpcd").Value="01" then
									Book01_Amt = Book01_Amt + Rs1("tmp_amt").Value
								else if Rs1("tmp_obtpcd").Value="02" then
									Book02_Amt = Book02_Amt + Rs1("tmp_amt").Value
								else
									Book_Other_Amt = Book_Other_Amt + Rs1("tmp_amt").Value
								end if
							end if
						else
							A1(i,0) = count + 1
							count = count + 1
							A1(i,1) = Rs1("tmp_no").Value
							A1(i,2) = Rs1("tmp_pytpnm").Value
							A1(i,3) = Rs1("tmp_pyno").Value
							A1(i,4) = Rs1("tmp_fgpreinv").Value
							A1(i,5) = Rs1("tmp_obtpnm").Value
							if Mid(Rs1("tmp_no").Value, 11, 3)="001" then
								A1(i,6) = "新"
							else
								A1(i,6) = "續"
							end if
'							A1(i,5) = Rs1("tmp_custtp").Value
							if (Mid(Rs1("tmp_datestr").Value, 1, 1)="1" or Mid(Rs1("tmp_datestr").Value, 1, 1)="2") then
								A1(i,7) = Mid(Rs1("tmp_datestr").Value, 1, 4) & "/" & Mid(Rs1("tmp_datestr").Value, 5, 2) & "/" & Mid(Rs1("tmp_datestr").Value, 7, 3) & Mid(Rs1("tmp_datestr").Value, 10, 4) & "/" & Mid(Rs1("tmp_datestr").Value, 14, 2) & "/" & Mid(Rs1("tmp_datestr").Value, 16, 2)
							else
								A1(i,7) = ""
							end if
'							A1(i,6) = Rs1("tmp_datestr").Value
							A1(i,8) = Rs1("tmp_amt").Value
							if Rs1("tmp_obtpcd").Value="01" then
								Book01_Amt = Book01_Amt + Rs1("tmp_amt").Value
							else if Rs1("tmp_obtpcd").Value="02" then
								Book02_Amt = Book02_Amt + Rs1("tmp_amt").Value
							else
								Book_Other_Amt = Book_Other_Amt + Rs1("tmp_amt").Value
							end if
						end if
						A1(i,9) = Rs1("tmp_nm").Value
						A1(i,10) = Rs1("tmp_inm").Value
						A1(i,11) = Rs1("tmp_zip").Value
						A1(i,12) = Rs1("tmp_addr").Value
						A1(i,13) = Rs1("tmp_tel").Value
						A1(i,14) = Rs1("tmp_mnt").Value
						A1(i,15) = Rs1("tmp_rmcont").Value
						if (Mid(Rs1("tmp_rmdate").Value, 1, 1)="1" or Mid(Rs1("tmp_rmdate").Value, 1, 1)="2") then
'							A1(i,16) = Mid(Rs1("tmp_rmdate").Value, 1, 4) & "/" & Mid(Rs1("tmp_rmdate").Value, 5, 2) & "/" & Mid(Rs1("tmp_rmdate").Value, 7, 2)
							A1(i,16) = Mid(Rs1("tmp_rmdate").Value, 5, 2) & "/" & Mid(Rs1("tmp_rmdate").Value, 7, 2)
						else
							A1(i,16) = ""
						end if
						A1(i,17) = Rs1("tmp_cname").Value
						
						preNo = Rs1("tmp_no").Value
						preBook = Rs1("tmp_obtpnm").Value
						
						' 抓出合計之值, 並轉為變數型態
						if Rs1("tmp_obtpcd").Value="01" then
							if Mid(Rs1("tmp_no").Value, 11, 3)="001" then
								Book01_New = Book01_New + Rs1("tmp_mnt").Value
							else
								Book01_Old = Book01_Old + Rs1("tmp_mnt").Value
							end if
						else if Rs1("tmp_obtpcd").Value="02" then
							if Mid(Rs1("tmp_no").Value, 11, 3)="001" then
								Book02_New = Book02_New + Rs1("tmp_mnt").Value
							else
								Book02_Old = Book02_Old + Rs1("tmp_mnt").Value
							end if
						else
							Book_Other = Book_Other + Rs1("tmp_mnt").Value
						end if
						
						' N 欄 = A1(i,13)
						'A1(i,13) = Rs1("cont_fgclosed").Value
'						if(Rs1("cont_fgclosed").Value=0)
'							A1(i,13) = "否"
'						else
'							A1(i,13) = "是"
'						end if
						
						'A1(i+1,13) = Rs1("cont_fgpayonce").Value
'						if(Rs1("cont_fgpayonce").Value=0)
'							A1(i+1,13) = "否"
'						else
'							A1(i+1,13) = "是"
'						end if
						
						
						' 此為特別欄位使用的格式 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 特別格式寫在 sheet 2 的指定欄位裡, 如 A5, A6; B5, B6
'						Dim Discounthighlight, Amounthighlight1, Amounthighlight2, Amounthighlight3
'						Discounthighlight =  "B" & (8+i) 
'						Amounthighlight1 = "I" & (8+i) 
'						Amounthighlight2 = "J" & (8+i) 
'						Amounthighlight3 = "K" & (8+i) 
'						if (i mod 4) = 0 then
							' 奇數行, 以 A5 的 貨幣 Format 顯示
'							XLS.FormatCells( 1, Discounthighlight, 2, "A6", false ) 
'							XLS.FormatCells( 1, Amounthighlight1, 2, "A5", false ) 
'							XLS.FormatCells( 1, Amounthighlight2, 2, "A5", false ) 
'							XLS.FormatCells( 1, Amounthighlight3, 2, "A5", false ) 
'						else
							' 偶數行, 以 B5 的 貨幣 Format 顯示
'							XLS.FormatCells( 1, Discounthighlight, 2, "B6", false )  
'							XLS.FormatCells( 1, Amounthighlight1, 2, "B5", false )  
'							XLS.FormatCells( 1, Amounthighlight2, 2, "B5", false )  
'							XLS.FormatCells( 1, Amounthighlight3, 2, "B5", false )  
'						end if
						
						' Highlight Some Rows: 此為一般欄位使用的格式
'						Dim highlight
'						highlight = "A" & (7+i) & ":N" & (8+i)
'						if (i mod 4) = 0
'							XLS.FormatCells( 1, highlight, 2, "A1", false ) 
'						else
'							XLS.FormatCells( 1, highlight, 2, "B1", false )  
'						end if
						Rs1.MoveNext
						
						if Rs1.EOF
	    					exit for
						end if
					next
					
					' Hide Sheet 2
'					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it
'					XLS.HideSheet( 3, true )  ' Hide it so user cannot unhide it
'					XLS.HideSheet( 4, true )  ' Hide it so user cannot unhide it
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					XLS.AddVariable("srspn_cname", EmpCName)		' >>$srspn_cname
					XLS.AddVariable("book01_new", Book01_New)		' >>$book01_new
					XLS.AddVariable("book01_old", Book01_Old)		' >>$book01_old
					XLS.AddVariable("book02_new", Book02_New)		' >>$book02_new
					XLS.AddVariable("book02_old", Book02_Old)		' >>$book02_old
					XLS.AddVariable("book_other", Book_Other)		' >>$book_other
					XLS.AddVariable("book01_amt", Book01_Amt)		' >>$book01_amt
					XLS.AddVariable("book02_amt", Book02_Amt)		' >>$book02_amt
					XLS.AddVariable("book_other_amt", Book_Other_Amt)		' >>$book_other_amt
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("od_list1.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "od_list1.xls", True)
					
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
