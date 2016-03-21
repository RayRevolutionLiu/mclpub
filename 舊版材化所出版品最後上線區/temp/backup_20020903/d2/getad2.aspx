<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>催稿單</title>
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
				
				Dim Rs1, Rs2, Rs4, Rs5, Rs6, Rs7		' Record Source 1 ~ 5
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6, sqlcmd7		' SQL Command 4 ~ 7
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim strYYYYMM, strBkcd, strEmpNo
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim strYYYYMMnew, BkPNo, EmpCName, BkName
				
				
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
				strYYYYMM = Request("yyyymm")
				strBkcd = Request("bkcd")
				strEmpNo = Request("empno")
				BkPNo = ""
				if(strYYYYMM <> "") then
					strYYYYMM = strYYYYMM
					strYYYYMMnew = Mid(strYYYYMM, 1, 4) & "/" & Mid(strYYYYMM, 5, 2)
					
					' Get Rs4: 由 刊登年月 抓出其相對應之 刊登期別
					sqlcmd4 = "SELECT bkp_pno "
					sqlcmd4 = sqlcmd4 & " FROM bookp "
					sqlcmd4 = sqlcmd4 & " WHERE (bkp_date = '" & strYYYYMM & "') "
					sqlcmd4 = sqlcmd4 & " AND (bkp_bkcd = '" & strBkcd & "') "
					Rs4 = oConn.Execute(sqlcmd4)
					BkPNo = Rs4("bkp_pno").value
					'Response.Write("BkPNo= " & BkPNo & "<br>")
				else
					strYYYYMM = ""
					BkPNo = ""
				end if
				
				if(strBkcd <> "") then
					strBkcd = strBkcd
					
					' Get Rs5: 藉書籍代碼抓出書籍名稱
					' Open the RecordSets
					sqlcmd5 = "SELECT * FROM book"
					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
					Rs5 = oConn.Execute(sqlcmd5)
					BkName = Rs5("bk_nm").Value
					'Response.Write("BkName= " & BkName & "<br>")
				else
					strBkcd = ""
				end if
				
				if(strEmpNo <> "") then
					strEmpNo = strEmpNo
					
					' Get Rs6: 藉業務員工號抓出業務員姓名
					' Open the RecordSets
					sqlcmd6 = "SELECT * FROM srspn"
					sqlcmd6 = sqlcmd6 & " WHERE (srspn_empno='" + strEmpNo + "')"
					Rs6 = oConn.Execute(sqlcmd6)
					EmpCName = Rs6("srspn_cname").Value
					'Response.Write("EmpCName= " & EmpCName & "<br>")
				else
					strEmpNo = ""
				end if
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
				'Response.Write("strBkcd= " & strBkcd & "<br>")
				'Response.Write("strEmpNo= " & strEmpNo & "<br>")
				
				
				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT DISTINCT count(*) As CountNo "
				sqlcmd2 = sqlcmd2 & " FROM c2_cont INNER JOIN mfr "
				sqlcmd2 = sqlcmd2 & " ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN c2_getad "
				sqlcmd2 = sqlcmd2 & " ON c2_cont.cont_contno = c2_getad.contno "
				sqlcmd2 = sqlcmd2 & " AND c2_cont.cont_syscd = c2_getad.syscd INNER JOIN c2_pub "
				sqlcmd2 = sqlcmd2 & " ON c2_cont.cont_syscd = c2_pub.pub_syscd "
				sqlcmd2 = sqlcmd2 & " AND c2_cont.cont_contno = c2_pub.pub_contno "
				sqlcmd2 = sqlcmd2 & " LEFT OUTER JOIN c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd "
				sqlcmd2 = sqlcmd2 & " LEFT OUTER JOIN c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd "
				sqlcmd2 = sqlcmd2 & " LEFT OUTER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd "
				sqlcmd2 = sqlcmd2 & " LEFT OUTER JOIN c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd "
				sqlcmd2 = sqlcmd2 & " WHERE (c2_cont.cont_fgclosed = '0') "
				sqlcmd2 = sqlcmd2 & " AND cont_bkcd = '" & strBkcd & "' "
				sqlcmd2 = sqlcmd2 & " AND pub_yyyymm = '" & strYYYYMM & "' "
				sqlcmd2 = sqlcmd2 & " AND cont_empno = '" & strEmpNo & "' "
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
				sqlcmd1 = "SELECT ' ' AS fgCont, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno, c2_cont.cont_aunm, mfr.mfr_inm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_autel, c2_cont.cont_aufax, c2_cont.cont_aucell, "
				sqlcmd1 = sqlcmd1 & " SUBSTRING(c2_cont.cont_sdate, 1, 4) + '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6) "
				sqlcmd1 = sqlcmd1 & " + ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4) + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_restjtm, c2_cont.cont_resttm, "
				'sqlcmd1 = sqlcmd1 & " c2_cont.cont_bkcd, c2_cont.cont_empno, "
				sqlcmd1 = sqlcmd1 & " c2_getad.pubmmstr, 1 AS CountPubSeq, c2_clr.clr_nm, "
				sqlcmd1 = sqlcmd1 & " c2_ltp.ltp_nm, c2_pgsize.pgs_nm, c2_pub.pub_adamt, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_origjno, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_chgjno, "
				sqlcmd1 = sqlcmd1 & " 1 AS PubnjtpCount, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_fggot, c2_cont.cont_clrtm, c2_cont.cont_getclrtm, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_menotm, c2_clr.clr_clrcd, c2_getad.contno, "
				sqlcmd1 = sqlcmd1 & " c2_getad.syscd, c2_ltp.ltp_ltpcd, c2_njtp.njtp_njtpcd, "
				sqlcmd1 = sqlcmd1 & " c2_pgsize.pgs_pgscd, c2_pub.pub_contno, c2_pub.pub_pubseq, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_syscd, c2_pub.pub_yyyymm, mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " FROM c2_cont INNER JOIN mfr "
				sqlcmd1 = sqlcmd1 & " ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN c2_getad "
				sqlcmd1 = sqlcmd1 & " ON c2_cont.cont_contno = c2_getad.contno "
				sqlcmd1 = sqlcmd1 & " AND c2_cont.cont_syscd = c2_getad.syscd INNER JOIN c2_pub "
				sqlcmd1 = sqlcmd1 & " ON c2_cont.cont_syscd = c2_pub.pub_syscd "
				sqlcmd1 = sqlcmd1 & " AND c2_cont.cont_contno = c2_pub.pub_contno "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd "
				sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_fgclosed = '0') "
				sqlcmd1 = sqlcmd1 & " AND cont_bkcd = '" & strBkcd & "' "
				sqlcmd1 = sqlcmd1 & " AND pub_yyyymm = '" & strYYYYMM & "' "
				sqlcmd1 = sqlcmd1 & " AND cont_empno = '" & strEmpNo & "' "
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				' ReFormat 特殊欄位
				Dim fggot, strfggot
				fggot = Rs1("pub_fggot").Value
				if(fggot = "0")
					strfggot = "否"
				else
					strfggot = "是"
				end if
				'A1(i,19) = strfggot
				
				
				' Get Rs7: 抓出則數小計之筆數
				' Open the RecordSets
				sqlcmd7 = "SELECT c2_clr.clr_nm, c2_ltp.ltp_nm, c2_pgsize.pgs_nm, "
				sqlcmd7 = sqlcmd7 & " COUNT(c2_cont.cont_contno) AS CountNo "
				sqlcmd7 = sqlcmd7 & " FROM c2_cont INNER JOIN c2_pub "
				sqlcmd7 = sqlcmd7 & " ON c2_cont.cont_syscd = c2_pub.pub_syscd "
				sqlcmd7 = sqlcmd7 & " AND c2_cont.cont_contno = c2_pub.pub_contno "
				sqlcmd7 = sqlcmd7 & " LEFT OUTER JOIN c2_ltp "
				sqlcmd7 = sqlcmd7 & " ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd "
				sqlcmd7 = sqlcmd7 & " LEFT OUTER JOIN c2_pgsize "
				sqlcmd7 = sqlcmd7 & " ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd "
				sqlcmd7 = sqlcmd7 & " LEFT OUTER JOIN c2_clr "
				sqlcmd7 = sqlcmd7 & " ON c2_pub.pub_clrcd = c2_clr.clr_clrcd "
				sqlcmd7 = sqlcmd7 & " GROUP BY c2_clr.clr_nm, c2_ltp.ltp_nm, c2_pgsize.pgs_nm, "
				sqlcmd7 = sqlcmd7 & " c2_cont.cont_fgclosed, c2_cont.cont_bkcd, "
				sqlcmd7 = sqlcmd7 & " c2_pub.pub_yyyymm, c2_cont.cont_empno "
				sqlcmd7 = sqlcmd7 & " HAVING (c2_cont.cont_fgclosed = '0') "
				sqlcmd7 = sqlcmd7 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				sqlcmd7 = sqlcmd7 & " AND (c2_pub.pub_yyyymm = '" & strYYYYMM & "') "
				sqlcmd7 = sqlcmd7 & " AND (c2_cont.cont_empno = '" & strEmpNo & "') "
				
				' Open the RecordSets
				Rs7 = oConn.Execute(sqlcmd7)
				
				
				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("sqlcmd4= " & sqlcmd4 & "<br><br>")
					'Response.Write("Rs4= " & Rs4(0).value & "<br>")
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
					XLS.AddRS_ADO(Rs7, 20)
					
					Dim highlight
					for i = 0 to rescount
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						highlight = "A" & (7+i) & ":W" & (7+i)
						'if (i mod 2) = 0
							'XLS.FormatCells( 1, highlight, 2, "A1", false ) 
						'else
							'XLS.FormatCells( 1, highlight, 2, "B1", false )  
						'end if
						'Response.Write("highlight= " & highlight & "<br>")
						Rs1.MoveNext
						
						if Rs1.EOF
	    						exit for
						end if
					next
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bkp_pno
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("getad2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "getad2.xls", True)
					
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
