<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單 預覽清單</title>
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
				
				Dim Rs1, Rs2, Rs3, Rs4, Rs5, Rs6, Rs7		' Record Source 1 ~ 7
				Dim Rs9, Rs10					' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2, sqlcmd3			' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6, sqlcmd7		' SQL Command 4 ~ 7
				Dim sqlcmd9, sqlcmd10				' SQL Command 9 ~ 10
				Dim rescountD, i	' rescountD= count of Rs2
				Dim rescountM, j	' rescountM= count of Rs3
				Dim A1, A7		' Array A1, A7
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' 自訂 sql 變數
				Dim strYYYYMM, strBkcd, strEmpNo, strSort
				
				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim strYYYYMMnew, BkPNo, EmpCName, BkName, strLoginEmpNo, strLoginEmpCName
				
				
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
				strYYYYMM = Request("yyyymm")
				strBkcd = Request("bkcd")
				strSort = Request("sort")
				BkPNo = ""
				strLoginEmpNo = Request("LEmpNo")
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
				
				if(Request("LEmpNo") <> "") then
					strLoginEmpNo = strLoginEmpNo
					
					' Get Rs9: 藉登入業務員工號抓出姓名
					' Open the RecordSets
					sqlcmd9 = "SELECT * FROM srspn"
					sqlcmd9 = sqlcmd9 & " WHERE (srspn_empno='" + strLoginEmpNo + "')"
					Rs9 = oConn.Execute(sqlcmd9)
					strLoginEmpCName = Trim(Rs9("srspn_cname").Value)
					'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")
				else
					strLoginEmpNo = ""
					strLoginEmpCName = ""
				end if
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
				'Response.Write("strBkcd= " & strBkcd & "<br>")
				'Response.Write("strEmpNo= " & strEmpNo & "<br>")
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")
				
				
				' Get Rs2: 抓出目前資料庫的總筆數 -- 主檔 join 明細檔
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT         * "
				sqlcmd2 = sqlcmd2 & " FROM             v_c2_iaFm2_prelist2 "
				sqlcmd2 = sqlcmd2 & " WHERE (1=1) "
				'sqlcmd2 = sqlcmd2 & " SELECT         dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_cont.cont_conttp, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, "
				'sqlcmd2 = sqlcmd2 & " SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) "
				'sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6)"
				'sqlcmd2 = sqlcmd2 & " + ' ~ ' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) "
				'sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate,"
				'sqlcmd2 = sqlcmd2 & " RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mfr.mfr_inm) "
				'sqlcmd2 = sqlcmd2 & " AS mfr_inm, RTRIM(dbo.cust.cust_nm) AS cust_nm, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_modempno, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_imseq, dbo.invmfr.im_nm, dbo.invmfr.im_jbti, "
				'sqlcmd2 = sqlcmd2 & " dbo.invmfr.im_zip, dbo.invmfr.im_addr, dbo.invmfr.im_tel, dbo.invmfr.im_invcd, "
				'sqlcmd2 = sqlcmd2 & " dbo.invmfr.im_taxtp, RTRIM(dbo.invmfr.im_fgitri) AS im_fgitri, "
				'sqlcmd2 = sqlcmd2 & " SUBSTRING(dbo.c2_pub.pub_yyyymm, 1, 4) "
				'sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(dbo.c2_pub.pub_yyyymm, 5, 6) AS pub_yyyymm, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_clrcd, RTRIM(dbo.c2_clr.clr_nm) "
				'sqlcmd2 = sqlcmd2 & " AS clr_nm, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_ltpcd, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_adamt, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_chgamt, "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_adamt + dbo.c2_pub.pub_chgamt AS pub_totamt "
				'sqlcmd2 = sqlcmd2 & " FROM             dbo.c2_pub INNER JOIN "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno INNER JOIN "
				'sqlcmd2 = sqlcmd2 & " dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN "
				'sqlcmd2 = sqlcmd2 & " dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN "
				'sqlcmd2 = sqlcmd2 & " dbo.srspn ON "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_modempno = dbo.srspn.srspn_empno INNER JOIN "
				'sqlcmd2 = sqlcmd2 & " dbo.invmfr ON dbo.c2_pub.pub_syscd = dbo.invmfr.im_syscd AND "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_contno = dbo.invmfr.im_contno AND "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq INNER JOIN "
				'sqlcmd2 = sqlcmd2 & " dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd "
				'sqlcmd2 = sqlcmd2 & " WHERE         (dbo.c2_pub.pub_fginved = 't') AND (dbo.c2_cont.cont_fgpubed = '1') AND "
				'sqlcmd2 = sqlcmd2 & " (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND "
				'sqlcmd2 = sqlcmd2 & " (dbo.c2_cont.cont_fgtemp = '0') "
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd2 = sqlcmd2 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				
				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd2 = sqlcmd2 & " AND (pub_yyyymm <= '" & strYYYYMM & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				sqlcmd2 = sqlcmd2 & " ) DRIVERTBL "
				
				' Open the RecordSets
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescountD = 0
					Response.Write ("<FONT Color=Red><B>查詢結果 - 筆數為 0</B></FONT><BR>")
				else
					rescountD = Rs2(0).Value
				end if
				'Response.Write("rescountD= " & rescountD & "<br>")
				
				
				' Get Rs3: 抓出目前資料庫的總筆數 -- 主檔
				' Open the RecordSets
				sqlcmd3 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd3 = sqlcmd3 & " FROM             ( "
				'sqlcmd3 = sqlcmd3 & " SELECT         * "
				'sqlcmd3 = sqlcmd3 & " FROM             v_c2_iaFm2_prelist2 "
				sqlcmd3 = sqlcmd3 & " SELECT         TOP 100 PERCENT cont_contno, dbo.c2_cont.cont_conttp, "
				sqlcmd3 = sqlcmd3 & " dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_sdate, "
				sqlcmd3 = sqlcmd3 & " dbo.c2_cont.cont_edate, RTRIM(dbo.c2_cont.cont_mfrno) "
				sqlcmd3 = sqlcmd3 & " AS cont_mfrno, dbo.c2_cont.cont_totamt, "
				sqlcmd3 = sqlcmd3 & " dbo.c2_cont.cont_paidamt, dbo.c2_cont.cont_restamt "
				sqlcmd3 = sqlcmd3 & " FROM              dbo.c2_cont INNER JOIN "
				sqlcmd3 = sqlcmd3 & " dbo.c2_pub ON "
				sqlcmd3 = sqlcmd3 & " dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND "
				sqlcmd3 = sqlcmd3 & " dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno "
				sqlcmd3 = sqlcmd3 & " WHERE          (dbo.c2_cont.cont_fgpubed = '1') AND "
				sqlcmd3 = sqlcmd3 & " (dbo.c2_cont.cont_fgpayonce = '0') AND "
				sqlcmd3 = sqlcmd3 & " (dbo.c2_cont.cont_fgcancel = '0') AND  "
				sqlcmd3 = sqlcmd3 & " (dbo.c2_cont.cont_fgtemp = '0') AND "
				sqlcmd3 = sqlcmd3 & " (dbo.c2_pub.pub_fginved = 't') "
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd3 = sqlcmd3 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd3 = sqlcmd3
				end if
				
				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd3 = sqlcmd3 & " AND (pub_yyyymm <= '" & strYYYYMM & "') "
				else
					sqlcmd3 = sqlcmd3
				end if
				sqlcmd3 = sqlcmd3 & " GROUP BY   cont_contno, cont_conttp, cont_bkcd, cont_sdate, cont_edate, "
				sqlcmd3 = sqlcmd3 & " cont_mfrno, cont_totamt, cont_paidamt, cont_restamt "
				sqlcmd3 = sqlcmd3 & " ) DRIVERTBL "
				
				' Open the RecordSets
				Rs3 = oConn.Execute(sqlcmd3)
				if Rs3.EOF then
					rescountM = 0
					Response.Write ("<FONT Color=Red><B>查詢結果 - 筆數為 0</B></FONT><BR>")
				else
					rescountM = Rs3(0).Value
				end if
				'Response.Write("rescountM= " & rescountM & "<br>")
				
				
				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd1 = sqlcmd1 & " SELECT         *, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN im_invcd = '2' THEN '二聯式' WHEN im_invcd = '3' "
				sqlcmd1 = sqlcmd1 & " THEN '三聯式' WHEN im_invcd = '4' THEN '其他' "
				sqlcmd1 = sqlcmd1 & " ELSE '不清楚' END AS im_invcdText, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN im_taxtp = '1' THEN '應稅5%' WHEN im_taxtp = '2' "
				sqlcmd1 = sqlcmd1 & " THEN '零稅' WHEN im_taxtp = '3' THEN '免稅' "
				sqlcmd1 = sqlcmd1 & " ELSE '不清楚' END AS im_taxtpText "
				sqlcmd1 = sqlcmd1 & " FROM             v_c2_iaFm2_prelist2 "
				sqlcmd1 = sqlcmd1 & " WHERE (1=1) "
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd1 = sqlcmd1 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				
				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd1 = sqlcmd1 & " AND (pub_yyyymm <= '" & strYYYYMM & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				
				if(Request("sort") <> "") then
					strSort = Request("sort")
					if(strSort = "1") Then
						sqlcmd1 = sqlcmd1 & " ORDER BY  pub_contno, pub_imseq, pub_pubseq "
					else
						sqlcmd1 = sqlcmd1 & " ORDER BY  cont_empno, pub_contno "
					end if
				else
					sqlcmd1 = sqlcmd1 & " ORDER BY  pub_contno, pub_imseq "
				end if
				
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				
				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("sqlcmd4= " & sqlcmd4 & "<br><br>")
					'Response.Write("Rs4= " & Rs4(0).value & "<br>")
					'Response.Write("sqlcmd9= " & sqlcmd9 & "<br><br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")
				
				' 若有資料, 則輸出至 ExcelSpeedGen
				else
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")
					
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					
					' 輸出 主資料 Rs1
					Rs1.MoveFirst
					rescountD = 0
					Do while not Rs1.EOF
						rescountD = rescountD + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst
					
					
					' Array 1
					Dim rescountMD
					rescountMD = rescountD + rescountM + 1
					ReDim A1(rescountMD,19)
					'Response.Write("rescountMD= " & rescountMD & "<br>")
					
					' Populate Array 1
					Dim preNo, preIMSeq, count, X
					Dim sum_pubadamt, sum_pubchgamt, sum_pubtotamt
					Dim TotalAdamt, TotalChgamt, Totalamt
					preNo = ""
					preIMSeq = ""
					count = 0
					X = 0
					sum_pubadamt = 0
					sum_pubchgamt = 0
					sum_pubtotamt = 0
					TotalAdamt = 0
					TotalChgamt = 0
					Totalamt = 0
					for i = 0 to rescountD - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("X= " & X & "<BR>")
						'Response.Write("count= " & count & ", ")
						'Response.Write("pub_contno= " & Rs1("pub_contno").Value & "<br>")
						'Response.Write("pub_contno= " & Rs1("pub_imseq").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")
						'Response.Write("preNo= " & preIMSeq & "<br><br>")
						
						' 若與上一筆資料之合約編號不同, 則全部顯示
						if (Rs1("pub_contno").Value <> preNo) then
							' 輸出 小計
							if(X <> 0) then
								A1(X,0) = ""
								A1(X,1) = ""
								A1(X,2) = ""
								A1(X,3) = ""
								A1(X,4) = ""
								A1(X,5) = ""
								A1(X,6) = ""
								A1(X,7) = ""
								A1(X,8) = ""
								A1(X,9) = ""
								A1(X,10) = ""
								A1(X,11) = ""
								A1(X,12) = ""
								A1(X,13) = ""
								A1(X,14) = ""
								A1(X,15) = "小計："
								A1(X,16) = sum_pubadamt
								A1(X,17) = sum_pubchgamt
								A1(X,18) = sum_pubtotamt
								X = X + 1
							end if
							
							
							' 全部顯示
							A1(X,0) = count + 1
							count = count + 1
							'Response.Write("count= " & count & ", ")
							
							A1(X,1) = Rs1("pub_contno").Value
							A1(X,2) = Rs1("cont_sedate").Value
							A1(X,3) = Rs1("cont_mfrno").Value
							A1(X,4) = Rs1("mfr_inm").Value
							A1(X,5) = Rs1("srspn_cname").Value
							A1(X,6) = Rs1("cont_totamt").Value
							A1(X,7) = Rs1("im_nm").Value
							A1(X,8) = Rs1("im_mfrinm").Value
							A1(X,9) = Rs1("im_zip").Value & " " & Rs1("im_addr").Value
							A1(X,10) = Rs1("im_invcdText").Value
							A1(X,11) = Rs1("im_taxtpText").Value
							A1(X,12) = Rs1("pub_yyyymm").Value
							A1(X,13) = Rs1("pub_pubseq").Value
							A1(X,14) = Rs1("clr_nm").Value
							A1(X,15) = Rs1("pub_projno").Value
							A1(X,16) = Rs1("pub_adamt").Value					
							A1(X,17) = Rs1("pub_chgamt").Value
							A1(X,18) = Rs1("pub_totamt").Value
							sum_pubadamt = Rs1("pub_adamt").Value
							sum_pubchgamt = Rs1("pub_chgamt").Value
							sum_pubtotamt = Rs1("pub_totamt").Value
							X = X + 1
						
						' 若與上一筆資料之合約編號相同 -- 清除前面重覆顯示欄位(如合約+發廠相關資料)
						else 
							' 特例 -- 合約編號相同, 但發廠收件人不相同 -- 清除前面重覆顯示欄位(如合約相關資料)
							if(Rs1("pub_imseq").Value <> preIMSeq) Then
								' 輸出 小計
								if(X <> 0) then
									A1(X,0) = ""
									A1(X,1) = ""
									A1(X,2) = ""
									A1(X,3) = ""
									A1(X,4) = ""
									A1(X,5) = ""
									A1(X,6) = ""
									A1(X,7) = ""
									A1(X,8) = ""
									A1(X,9) = ""
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = "小計："
									A1(X,16) = sum_pubadamt
									A1(X,17) = sum_pubchgamt
									A1(X,18) = sum_pubtotamt
									X = X + 1
								end if
								
								
								A1(X,0) = ""
								A1(X,1) = ""
								A1(X,2) = ""
								A1(X,3) = ""
								A1(X,4) = ""
								A1(X,5) = ""
								A1(X,6) = ""
								A1(X,7) = Rs1("im_nm").Value
								A1(X,8) = Rs1("im_mfrinm").Value
								A1(X,9) = Rs1("im_zip").Value & " " & Rs1("im_addr").Value
								A1(X,10) = Rs1("im_invcdText").Value
								A1(X,11) = Rs1("im_taxtpText").Value
								A1(X,12) = Rs1("pub_yyyymm").Value
								A1(X,13) = Rs1("pub_pubseq").Value
								A1(X,14) = Rs1("clr_nm").Value
								A1(X,15) = Rs1("pub_projno").Value
								A1(X,16) = Rs1("pub_adamt").Value					
								A1(X,17) = Rs1("pub_chgamt").Value
								A1(X,18) = Rs1("pub_totamt").Value
								sum_pubadamt = sum_pubadamt + Rs1("pub_adamt").Value
								sum_pubchgamt = sum_pubchgamt + Rs1("pub_chgamt").Value
								sum_pubtotamt = sum_pubadamt + sum_pubchgamt
								X = X + 1
							
							' 非特例 --  -- 合約編號相同, 但發廠收件人也相同 -- 清除前面重覆顯示欄位(如合約+發廠相關資料)
							else
								A1(X,0) = ""
								A1(X,1) = ""
								A1(X,2) = ""
								A1(X,3) = ""
								A1(X,4) = ""
								A1(X,5) = ""
								A1(X,6) = ""
								A1(X,7) = ""
								A1(X,8) = ""
								A1(X,9) = ""
								A1(X,10) = ""
								A1(X,11) = ""
								A1(X,12) = Rs1("pub_yyyymm").Value
								A1(X,13) = Rs1("pub_pubseq").Value
								A1(X,14) = Rs1("clr_nm").Value
								A1(X,15) = Rs1("pub_projno").Value
								A1(X,16) = Rs1("pub_adamt").Value					
								A1(X,17) = Rs1("pub_chgamt").Value
								A1(X,18) = Rs1("pub_totamt").Value
								sum_pubadamt = sum_pubadamt + Rs1("pub_adamt").Value
								sum_pubchgamt = sum_pubchgamt + Rs1("pub_chgamt").Value
								sum_pubtotamt = sum_pubtotamt + Rs1("pub_totamt").Value
								sum_pubtotamt = sum_pubadamt + sum_pubchgamt
								X = X + 1
							end if
						end if
						
						' 指定 判斷值, 好與下一筆資料相比較
						preNo = Rs1("pub_contno").Value
						preIMSeq = Rs1("pub_imseq").Value
						'Response.Write("preNo= " & preNo & ", ")
						'Response.Write("preIMSeq= " & preIMSeq & ", ")
						'Response.Write("sum_pubadamt= " & sum_pubadamt & ", ")
						'Response.Write("sum_pubchgamt= " & sum_pubchgamt & ", ")
						'Response.Write("sum_pubtotamt= " & sum_pubtotamt & "<br><br>")

						
						' 總計 -- for 整個報表, 將此值輸出至變數
						TotalAdamt = TotalAdamt + Rs1("pub_adamt").Value
						TotalChgamt = TotalChgamt + Rs1("pub_chgamt").Value
						Totalamt = Totalamt + Rs1("pub_totamt").Value
						'Response.Write("TotalAdamt= " & TotalAdamt & ", ")
						'Response.Write("TotalChgamt= " & TotalChgamt & ", ")
						'Response.Write("Totalamt= " & Totalamt & "<br><br>")						
						
						
						Dim highlight2, highlight3, highlight4, highlight5
						' Highlight Some Rows: 此為特別欄位使用的格式 A2/B2 (此處是欄位置中處理; 特別格式寫在 sheet 2 的指定欄位裡)
						' 特別欄位 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 注意 FormatCells 特別欄位 的程式碼一定要放在 FormatCells 一般欄位的程式碼 "前方", 否則特別欄位無法顯示
						'highlight2 = "H" & (6+X)
						'highlight3 = "Q" & (6+X)
						'highlight4 = "R" & (6+X)
						'highlight5 = "S" & (6+X)
						'if (X mod 2) = 0
							'XLS.FormatCells( 1, highlight2, 2, "A9", false ) 
							'XLS.FormatCells( 1, highlight3, 2, "A9", false ) 
							'XLS.FormatCells( 1, highlight4, 2, "A9", false ) 
							'XLS.FormatCells( 1, highlight5, 2, "A9", false ) 
						'else
							'XLS.FormatCells( 1, highlight2, 2, "B9", false )  
							'XLS.FormatCells( 1, highlight3, 2, "B9", false )  
							'XLS.FormatCells( 1, highlight4, 2, "B9", false ) 
							'XLS.FormatCells( 1, highlight5, 2, "B9", false ) 
						'end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")
						'Response.Write("highlight4= " & highlight4 & "<br>")
						'Response.Write("highlight5= " & highlight5 & "<br>")
						
						
						Dim highlight
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						'highlight = "A" & (6+X) & ":S" & (6+X)
						'if (X mod 2) = 0
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
					
					
					' 總計 -- for 最後一筆資料 (因此時已移到 Rs1.MoveLast)
					A1(X,0) = ""
					A1(X,1) = ""
					A1(X,2) = ""
					A1(X,3) = ""
					A1(X,4) = ""
					A1(X,5) = ""
					A1(X,6) = ""
					A1(X,7) = ""
					A1(X,8) = ""
					A1(X,9) = ""
					A1(X,10) = ""
					A1(X,11) = ""
					A1(X,12) = ""
					A1(X,13) = ""
					A1(X,14) = ""
					A1(X,15) = "小計："
					A1(X,16) = sum_pubadamt
					A1(X,17) = sum_pubchgamt
					A1(X,18) = sum_pubtotamt
					
					
					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					
					
					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)	' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("Totadamt", TotalAdamt)		' >>$Totadamt
					XLS.AddVariable("Totchgamt", TotalChgamt)	' >>Totchgamt
					XLS.AddVariable("TotAmt", Totalamt)		' >>$TotAmt
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("iaFm2_prelist2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "iaFm2_prelist2.xls", True)
					
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
