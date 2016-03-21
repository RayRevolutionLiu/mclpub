<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單 檢核表 一次付款(當月刊登清單)</title>
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
				Dim strYYYYMM, strBkcd, strEmpNo

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
					BkPNo = Trim(Rs4("bkp_pno").value)
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
					BkName = Trim(Rs5("bk_nm").Value)
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
				'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")


				' Get Rs2: 抓出目前資料庫的總筆數 -- 主檔 join 明細檔
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT "
				sqlcmd2 = sqlcmd2 & " ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, ia.ia_iasseq, "
				sqlcmd2 = sqlcmd2 & " ia.ia_iaitem, ia.ia_iano, ia.ia_refno, RTRIM(ia.ia_mfrno) AS ia_mfrno, "
				sqlcmd2 = sqlcmd2 & " ia.ia_pyno, ia.ia_pyseq, ia.ia_pyat, ia.ia_ivat, ia.ia_invno, ia.ia_invdate, "
				sqlcmd2 = sqlcmd2 & " ia.ia_fgitri, RTRIM(ia.ia_rnm) AS ia_rnm, RTRIM(ia.ia_raddr) AS ia_raddr, "
				sqlcmd2 = sqlcmd2 & " RTRIM(ia.ia_rzip) AS ia_rzip, RTRIM(ia.ia_rjbti) AS ia_rjbti, RTRIM(ia.ia_rtel) "
				sqlcmd2 = sqlcmd2 & " AS ia_rtel, ia.ia_fgnonauto, ia.ia_invcd, ia.ia_taxtp, ia.ia_status, "
				sqlcmd2 = sqlcmd2 & " RTRIM(ia.ia_cname) AS ia_cname, RTRIM(ia.ia_tel) AS ia_tel, "
				sqlcmd2 = sqlcmd2 & " RTRIM(ia.ia_contno) AS ia_contno, iad.iad_iadid, iad.iad_syscd, iad.iad_iano, "
				sqlcmd2 = sqlcmd2 & " iad.iad_iaditem, RTRIM(dbo.iad.iad_fk1) AS iad_fk1, RTRIM(dbo.iad.iad_fk2) "
				sqlcmd2 = sqlcmd2 & " AS iad_fk2, RTRIM(dbo.iad.iad_fk3) AS iad_fk3, RTRIM(dbo.iad.iad_fk4) "
				sqlcmd2 = sqlcmd2 & " AS iad_fk4, RTRIM(dbo.iad.iad_desc) AS iad_desc, iad.iad_projno, "
				sqlcmd2 = sqlcmd2 & " iad.iad_costctr, iad.iad_qty, iad.iad_unit, "
				sqlcmd2 = sqlcmd2 & " iad.iad_uprice, iad.iad_amt, RTRIM(mfr.mfr_inm) AS mfr_inm, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_bkcd "
				sqlcmd2 = sqlcmd2 & " FROM             ia INNER JOIN "
				sqlcmd2 = sqlcmd2 & " iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_cont ON iad.iad_fk1 = c2_cont.cont_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mfr ON ia.ia_mfrno = mfr.mfr_mfrno "
				sqlcmd2 = sqlcmd2 & " WHERE         (ia.ia_syscd = 'C2') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgpayonce = '1') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgclosed = '0') "
				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd2 = sqlcmd2 & " AND (iad_fk2 = '" & strYYYYMM & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd2 = sqlcmd2 & " AND (cont_bkcd = '" & strBkcd & "') "
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
				sqlcmd3 = sqlcmd3 & " SELECT         ia_iano "
				sqlcmd3 = sqlcmd3 & " FROM              ia INNER JOIN "
				sqlcmd3 = sqlcmd3 & " c2_cont ON "
				sqlcmd3 = sqlcmd3 & " ia.ia_contno = c2_cont.cont_syscd + c2_cont.cont_contno "
				sqlcmd3 = sqlcmd3 & " INNER JOIN "
				sqlcmd3 = sqlcmd3 & " iad ON ia.ia_syscd = iad.iad_syscd AND "
				sqlcmd3 = sqlcmd3 & " ia.ia_iano = iad.iad_iano "
				sqlcmd3 = sqlcmd3 & " WHERE         (ia_syscd = 'C2') "
				sqlcmd3 = sqlcmd3 & " AND (ia_status = ' ') "
				sqlcmd3 = sqlcmd3 & " AND (cont_fgpayonce = '1') "
				sqlcmd3 = sqlcmd3 & " AND (cont_fgclosed = '0') "
				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd3 = sqlcmd3 & " AND (iad_fk2 = '" & strYYYYMM & "') "
				else
					sqlcmd3 = sqlcmd3
				end if
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd3 = sqlcmd3 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd3 = sqlcmd3
				end if
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
				sqlcmd1 = "SELECT DISTINCT "
				sqlcmd1 = sqlcmd1 & " ia.ia_iaid, ia.ia_syscd, ia.ia_iasdate, "
				sqlcmd1 = sqlcmd1 & " ia.ia_iasseq, ia.ia_iaitem, ia.ia_iano, ia.ia_refno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(ia.ia_mfrno) AS ia_mfrno, ia.ia_pyno, ia.ia_pyseq, "
				sqlcmd1 = sqlcmd1 & " ia.ia_pyat, ia.ia_ivat, ia.ia_invno, ia.ia_invdate, "
				sqlcmd1 = sqlcmd1 & " ia.ia_fgitri, RTRIM(ia.ia_rnm) AS ia_rnm, RTRIM(ia.ia_raddr) "
				sqlcmd1 = sqlcmd1 & " AS ia_raddr, RTRIM(ia.ia_rzip) AS ia_rzip, RTRIM(ia.ia_rjbti) AS ia_rjbti, "
				sqlcmd1 = sqlcmd1 & " RTRIM(ia.ia_rtel) AS ia_rtel, ia.ia_fgnonauto, ia.ia_invcd, "
				sqlcmd1 = sqlcmd1 & " ia.ia_taxtp, ia.ia_status, RTRIM(ia.ia_cname) AS ia_cname, "
				sqlcmd1 = sqlcmd1 & " RTRIM(ia.ia_tel) AS ia_tel, RTRIM(ia.ia_contno) AS ia_contno, "
				sqlcmd1 = sqlcmd1 & " iad.iad_iadid, iad.iad_syscd, iad.iad_iano, iad.iad_iaditem, "
				sqlcmd1 = sqlcmd1 & " RTRIM(iad.iad_fk1) AS iad_fk1, Substring(RTRIM(iad.iad_fk2), 1, 4) "
				sqlcmd1 = sqlcmd1 & " + '/' + Substring(RTRIM(iad.iad_fk2), 5, 2) AS iad_fk2, RTRIM(iad.iad_fk3) "
				sqlcmd1 = sqlcmd1 & " AS iad_fk3, RTRIM(iad.iad_fk4) AS iad_fk4, RTRIM(iad.iad_desc) "
				sqlcmd1 = sqlcmd1 & " AS iad_desc, iad.iad_projno, iad.iad_costctr, iad.iad_qty, "
				sqlcmd1 = sqlcmd1 & " iad.iad_unit, iad.iad_uprice, iad.iad_amt, RTRIM(mfr.mfr_inm) "
				sqlcmd1 = sqlcmd1 & " AS mfr_inm, c2_cont.cont_bkcd, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN ia_invcd = '2' THEN '二聯式' WHEN ia_invcd = '3' "
				sqlcmd1 = sqlcmd1 & " THEN '三聯式' WHEN ia_invcd = '4' THEN '其他' "
				sqlcmd1 = sqlcmd1 & " ELSE '不清楚' END AS ia_invcdText, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN ia_taxtp = '1' THEN '應稅5%' WHEN ia_taxtp = '2' "
				sqlcmd1 = sqlcmd1 & " THEN '零稅' WHEN ia_taxtp = '3' THEN '免稅' "
				sqlcmd1 = sqlcmd1 & " ELSE '不清楚' END AS ia_taxtpText "
				sqlcmd1 = sqlcmd1 & " FROM             ia INNER JOIN "
				sqlcmd1 = sqlcmd1 & " iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_cont ON iad.iad_fk1 = c2_cont.cont_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON ia.ia_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " WHERE         (ia.ia_syscd = 'C2') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgpayonce = '1') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgclosed = '0') "
				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd1 = sqlcmd1 & " AND (iad_fk2 = '" & strYYYYMM & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd1 = sqlcmd1 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " ORDER BY  ia.ia_iano, ia.ia_mfrno, ia.ia_rnm, iad.iad_iaditem "


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
					'Response.Write("Rs3= " & Rs3(0).value & "<br>")
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
					ReDim A1(rescountD,19)
					'Response.Write("rescountMD= " & rescountMD & "<br>")

					' Populate Array 1
					Dim preNo, count, X
					Dim sum_totamt, Totalamt
					preNo = ""
					count = 0
					X = 0
					sum_totamt = 0
					Totalamt = 0
					for i = 0 to rescountD - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("X= " & X & "<BR>")
						'Response.Write("count= " & count & ", ")
						'Response.Write("ia_iano= " & Rs1("ia_iano").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")


						' 若與上一筆資料之合約編號不同, 則全部顯示
						if (Rs1("ia_iano").Value <> preNo) then
							' 輸出 小計
							if(X <> 0) then
								'A1(X,0) = ""
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
								A1(X,15) = ""
								A1(X,16) = "小計："
								A1(X,17) = ""
								A1(X,18) = sum_totamt
								X = X + 1
							end if


							' 全部顯示
							A1(X,0) = count + 1
							count = count + 1
							'Response.Write("count= " & count & ", ")

							' 以下為非重覆時, 要顯示的資料項
							A1(X,1) = Rs1("ia_iano").Value
							A1(X,2) = Rs1("ia_mfrno").Value
							A1(X,3) = Rs1("mfr_inm").Value
							A1(X,4) = Rs1("ia_rnm").Value
							A1(X,5) = Rs1("ia_rjbti").Value
							A1(X,6) = Rs1("ia_rzip").Value & " " & Rs1("ia_raddr").Value
							A1(X,7) = Rs1("ia_rtel").Value
							A1(X,8) = Rs1("ia_invcdText").Value
							A1(X,9) = Rs1("ia_taxtpText").Value
							A1(X,10) = Rs1("iad_iaditem").Value
							A1(X,11) = Rs1("iad_fk1").Value
							A1(X,12) = Rs1("iad_fk2").Value
							A1(X,13) = Rs1("iad_fk3").Value
							A1(X,14) = Rs1("iad_desc").Value
							A1(X,15) = Rs1("iad_projno").Value
							A1(X,16) = Rs1("iad_costctr").Value
							A1(X,17) = Rs1("iad_qty").Value
							A1(X,18) = Rs1("iad_amt").Value
							sum_totamt = Rs1("iad_amt").Value
							X = X + 1

						' 若與上一筆資料之合約編號相同 -- 清除前面重覆顯示欄位(如合約相關資料)
						else
							A1(X,0) = ""
							A1(X,1) = ""
							A1(X,2) = ""
							A1(X,3) = ""
							A1(X,4) = ""
							A1(X,5) = ""
							A1(X,6) = ""
							A1(X,7) = ""
							A1(X,8) = Rs1("ia_invcdText").Value
							A1(X,9) = Rs1("ia_taxtpText").Value
							A1(X,10) = Rs1("iad_iaditem").Value
							A1(X,11) = Rs1("iad_fk1").Value
							A1(X,12) = Rs1("iad_fk2").Value
							A1(X,13) = Rs1("iad_fk3").Value
							A1(X,14) = Rs1("iad_desc").Value
							A1(X,15) = Rs1("iad_projno").Value
							A1(X,16) = Rs1("iad_costctr").Value
							A1(X,17) = Rs1("iad_qty").Value
							A1(X,18) = Rs1("iad_amt").Value
							sum_totamt = sum_totamt + Rs1("iad_amt").Value
							X = X + 1
						end if


						' 指定 判斷值, 好與下一筆資料相比較
						preNo = Rs1("ia_iano").Value
						'Response.Write("preNo= " & preNo & ", ")
						'Response.Write("sum_totamt= " & sum_totamt & "<br>")
						'Response.Write("Totalamt= " & Totalamt & "<br>")

						' 總計 -- for 整個報表, 將此值輸出至變數
						Totalamt = Totalamt + Rs1("iad_amt").Value
						'Response.Write("Totalamt= " & Totalamt & ", ")


						Dim highlight2, highlight3, highlight4
						' Highlight Some Rows: 此為特別欄位使用的格式 A2/B2 (此處是欄位置中處理; 特別格式寫在 sheet 2 的指定欄位裡)
						' 特別欄位 (如貨幣, real等) - 以 FormatCells 來重新以制式格式顯示
						' 注意 FormatCells 特別欄位 的程式碼一定要放在 FormatCells 一般欄位的程式碼 "前方", 否則特別欄位無法顯示
						'highlight2 = "R" & (7+i)
						'highlight3 = "S" & (7+i)
						'if (i mod 2) = 0
							'XLS.FormatCells( 1, highlight2, 2, "A8", false )
							'XLS.FormatCells( 1, highlight3, 2, "A5", false )
						'else
							'XLS.FormatCells( 1, highlight2, 2, "B8", false )
							'XLS.FormatCells( 1, highlight3, 2, "B5", false )
						'end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")


						'Dim highlight
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						'highlight = "A" & (7+i) & ":S" & (7+i)
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
					A1(X,15) = ""
					A1(X,16) = "小計："
					A1(X,17) = ""
					A1(X,18) = sum_totamt


					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
					'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("TotAmt", Totalamt)		' >>$TotAmt
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("iaFm1_list2b.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "iaFm1_list2b.xls", True)

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
