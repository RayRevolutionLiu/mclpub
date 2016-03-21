<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告落版單</title>
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

				Dim Rs1, Rs2, Rs5, Rs6				' Record Source 1 ~ 7
				Dim Rs9, RS10					' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd5, sqlcmd6				' SQL Command 4 ~ 7
				Dim sqlcmd9, sqlcmd10				' SQL Command 9 ~ 10
				Dim rescount, i		' rescount= count of Rs2
				Dim rescount2, j	' rescount2= count of Rs10
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
				strEmpNo = ""
				strLoginEmpNo = Request("LEmpNo")
				if(strYYYYMM <> "") then
					strYYYYMM = strYYYYMM
					strYYYYMMnew = Mid(strYYYYMM, 1, 4) & "/" & Mid(strYYYYMM, 5, 2)
				else
					strYYYYMM = ""
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

				if(Request("empno") <> "") then
					strEmpNo = Request("empno")

					' Get Rs6: 藉承辦業務員工號抓出姓名
					' Open the RecordSets
					sqlcmd6 = "SELECT * FROM srspn"
					sqlcmd6 = sqlcmd6 & " WHERE (srspn_empno='" + strEmpNo + "')"
					Rs6 = oConn.Execute(sqlcmd6)
					EmpCName = Trim(Rs6("srspn_cname").Value)
					'Response.Write("EmpCName= " & EmpCName & "<br>")
				else
					strEmpNo = ""
					EmpCName = "(所有)"
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


				' Get Rs2: 抓出目前資料庫的總筆數
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_contno, c2_cont.cont_fgclosed, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_fgcancel, c2_cont.cont_fgtemp, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_fgpubed "
				sqlcmd2 = sqlcmd2 & " FROM              c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_pub ON "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno = c2_pub.pub_contno "
				sqlcmd2 = sqlcmd2 & " WHERE (pub_bkcd='" + strBkcd + "') "
				sqlcmd2 = sqlcmd2 & " AND (pub_yyyymm='" + strYYYYMM + "') "
				'sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgclosed = '0') "
				'sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgpubed = '1') "
				'sqlcmd2 = sqlcmd2 & " SELECT * "
				'sqlcmd2 = sqlcmd2 & " FROM c2_pub "
				'sqlcmd2 = sqlcmd2 & " WHERE (pub_bkcd='" + strBkcd + "')"
				'sqlcmd2 = sqlcmd2 & " AND (pub_yyyymm='" + strYYYYMM + "')"
				sqlcmd2 = sqlcmd2 & " ) DRIVERTBL "

				' Open the RecordSets
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
				sqlcmd1 = "SELECT  "
				sqlcmd1 = sqlcmd1 & " 0 AS ItemNo, pub_contno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(pub_pubseq) AS pub_pubseq, pub_pgno, pub_clrcd, "
				sqlcmd1 = sqlcmd1 & " pub_pgscd, pub_ltpcd, CASE WHEN pub_fgfixpg = '0' THEN '否' ELSE '是' END AS pub_fgfixpg, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN pub_fggot = '0' THEN '否' ELSE '是' END AS pub_fggot, pub_modempno, pub_remark, "
				sqlcmd1 = sqlcmd1 & " pub_origbkcd, pub_origjno, pub_origjbkno,"
				sqlcmd1 = sqlcmd1 & " pub_chgbkcd, pub_chgjno, pub_chgjbkno, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN pub_fgrechg = '0' THEN '否' ELSE '是' END AS pub_fgrechg, pub_njtpcd, RTRIM(mfr.mfr_inm) "
				sqlcmd1 = sqlcmd1 & " AS mfr_inm, pub_bkcd, RTRIM(c2_clr.clr_nm) AS clr_nm, "
				sqlcmd1 = sqlcmd1 & " RTRIM(c2_ltp.ltp_nm) AS ltp_nm, RTRIM(c2_pgsize.pgs_nm) "
				sqlcmd1 = sqlcmd1 & " AS pgs_nm, RTRIM(c2_njtp.njtp_nm) AS njtp_nm, RTRIM(book.bk_nm) "
				sqlcmd1 = sqlcmd1 & " AS bk_nm, RTRIM(srspn.srspn_cname) AS srspn_cname, "
				sqlcmd1 = sqlcmd1 & " pub_drafttp, pub_syscd, pub_yyyymm, "
				sqlcmd1 = sqlcmd1 & " pub_fgupdated, c2_lprior.lp_priorseq, c2_lprior.lp_bkcd, "
				sqlcmd1 = sqlcmd1 & " pub_njtpcd + ' ' + c2_njtp.njtp_nm AS nostr "
				sqlcmd1 = sqlcmd1 & " FROM             c2_pub INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_cont ON pub_contno = c2_cont.cont_contno AND "
				sqlcmd1 = sqlcmd1 & " pub_syscd = c2_cont.cont_syscd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_lprior ON pub_ltpcd = c2_lprior.lp_ltpcd AND "
				sqlcmd1 = sqlcmd1 & " pub_clrcd = c2_lprior.lp_clrcd AND "
				sqlcmd1 = sqlcmd1 & " pub_pgscd = c2_lprior.lp_pgscd AND "
				sqlcmd1 = sqlcmd1 & " pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_clr ON pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_pgsize ON "
				sqlcmd1 = sqlcmd1 & " pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_ltp ON pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_njtp ON "
				sqlcmd1 = sqlcmd1 & " pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN "
				sqlcmd1 = sqlcmd1 & " book ON pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN "
				sqlcmd1 = sqlcmd1 & " srspn ON c2_cont.cont_empno = srspn.srspn_empno "
				sqlcmd1 = sqlcmd1 & " WHERE (pub_bkcd='" + strBkcd + "')"
				sqlcmd1 = sqlcmd1 & " AND (pub_yyyymm='" + strYYYYMM + "')"
				'sqlcmd1 = sqlcmd1 & " AND (dbo.c2_cont.cont_fgclosed = '0') "
				'sqlcmd1 = sqlcmd1 & " AND (dbo.c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (dbo.c2_cont.cont_fgtemp = '0') "
				sqlcmd1 = sqlcmd1 & " AND (dbo.c2_cont.cont_fgpubed = '1') "
				sqlcmd1 = sqlcmd1 & " ORDER BY c2_lprior.lp_priorseq, pub_pgno "
				sqlcmd1 = sqlcmd1 & " , pub_contno, pub_yyyymm DESC, pub_pubseq "


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

					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")


					' 輸出 主資料 Rs1
					Rs1.MoveFirst
					rescount = 0
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst


					' Array 1
					ReDim A1(rescount,19)

					Dim ChgBkName

					' Populate Array 1
					Dim preNo, count
					preNo = ""
					count = 0
					for i = 0 to rescount - 1 step 1
						' 自動計算 A 欄: 項次 - 顯示方法二：放此處, 是因項次要顯示不同跳號(即使合約重覆, 也要逐一加下去; 還有 if裡 A1(i,0) = "" 要 disable)
						'A1(i,0) = count + 1
						'count = count + 1

						'Response.Write("pub_contno= " & Rs1("pub_contno").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")
						' 若資料重覆, 則重覆資料須清除某些重覆資料項(如合約相關資料)
						if Rs1("pub_contno").Value = preNo then
							' 以下為重覆時, 顯示要清空的資料項
							A1(i,0) = ""
							A1(i,1) = ""
						else
							' 自動計算 A 欄: 項次 - 顯示方法一：放此處則是客戶要求: 合約重覆者, 則不顯示其相同的項次 (if裡 A1(i,0) = "" 要 enable)
							A1(i,0) = count + 1
							count = count + 1

							' 以下為非重覆時, 要顯示的資料項
							A1(i,1) = Rs1("pub_contno").Value
							A1(i,2) = Rs1("pub_pubseq").Value
							A1(i,3) = Rs1("pub_pgno").Value
							A1(i,4) = Rs1("ltp_nm").Value
							A1(i,5) = Rs1("clr_nm").Value
							A1(i,6) = Rs1("pgs_nm").Value
							A1(i,7) = Rs1("pub_fgfixpg").Value
							A1(i,8) = Rs1("mfr_inm").Value
							if(Rs1("pub_drafttp").Value = "2") Then
								A1(i,9) = Rs1("pub_fggot").Value
							else
								A1(i,9) = ""
							end if
							A1(i,10) = Rs1("njtp_nm").Value
							' 抓出 改稿書籍類別之名稱
							if(Rs1("pub_chgbkcd").Value <> "") then
								' Get Rs10: 藉書籍代碼抓出書籍名稱
								' Open the RecordSets
								sqlcmd10 = "SELECT * FROM book"
								sqlcmd10 = sqlcmd10 & " WHERE (bk_bkcd='" + Rs1("pub_chgbkcd").Value + "')"
								Rs10 = oConn.Execute(sqlcmd10)
								if not Rs10.EOF then
									ChgBkName = Rs10("bk_nm").Value
								end if
								'Response.Write("ChgBkName= " & ChgBkName & "<br>")
							else
								ChgBkName = ""
							end if
							A1(i,11) = ChgBkName
							A1(i,12) = Rs1("pub_chgjno").Value
							A1(i,13) = Rs1("pub_chgjbkno").Value
							A1(i,14) = Rs1("pub_fgrechg").Value
							A1(i,15) = Rs1("bk_nm").Value
							A1(i,16) = Rs1("pub_origjno").Value
							A1(i,17) = Rs1("pub_origjbkno").Value
							A1(i,18) = Rs1("srspn_cname").Value
							A1(i,19) = Rs1("pub_remark").Value
							'A1(i,20) = Rs1("bk_nm").Value
 						end if


						' 以下為無論重覆與否, 一定要出現的資料項
						'A1(i,1) = Rs1("pub_contno").Value
						A1(i,2) = Rs1("pub_pubseq").Value
						A1(i,3) = Rs1("pub_pgno").Value
						A1(i,4) = Rs1("ltp_nm").Value
						A1(i,5) = Rs1("clr_nm").Value
						A1(i,6) = Rs1("pgs_nm").Value
						A1(i,7) = Rs1("pub_fgfixpg").Value
						A1(i,8) = Rs1("mfr_inm").Value
						'A1(i,9) = Rs1("pub_fggot").Value
						' 新稿
						if(Rs1("pub_drafttp").Value = "2") Then
							A1(i,9) = Rs1("pub_fggot").Value
							A1(i,10) = Rs1("njtp_nm").Value

							A1(i,11) = ""
							A1(i,12) = ""
							A1(i,13) = ""
							A1(i,14) = ""
							A1(i,15) = ""
							A1(i,16) = ""
							A1(i,17) = ""
						else
							A1(i,9) = ""
							A1(i,10) = ""
						end if
						' 改稿
						if(Rs1("pub_drafttp").Value = "3") Then
							A1(i,9) = Rs1("pub_fggot").Value
							' 抓出 改稿書籍類別之名稱
							if(Rs1("pub_chgbkcd").Value <> "") then
								' Get Rs10: 藉書籍代碼抓出書籍名稱
								' Open the RecordSets
								sqlcmd10 = "SELECT * FROM book"
								sqlcmd10 = sqlcmd10 & " WHERE (bk_bkcd='" + Rs1("pub_chgbkcd").Value + "')"
								Rs10 = oConn.Execute(sqlcmd10)
								if not Rs10.EOF then
									ChgBkName = Rs10("bk_nm").Value
								end if
								'Response.Write("ChgBkName= " & ChgBkName & "<br>")
							else
								ChgBkName = ""
							end if
							'A1(i,11) = Rs1("pub_chgbkcd").Value
							A1(i,11) = ChgBkName
							A1(i,12) = Rs1("pub_chgjno").Value
							A1(i,13) = Rs1("pub_chgjbkno").Value
							A1(i,14) = Rs1("pub_fgrechg").Value

							A1(i,10) = ""
							A1(i,15) = ""
							A1(i,16) = ""
							A1(i,17) = ""
						else
							A1(i,11) = ""
							A1(i,12) = ""
							A1(i,13) = ""
							A1(i,14) = ""
						end if
						' 舊稿
						if(Rs1("pub_drafttp").Value = "1") Then
							A1(i,15) = Rs1("bk_nm").Value
							A1(i,16) = Rs1("pub_origjno").Value
							A1(i,17) = Rs1("pub_origjbkno").Value

							A1(i,9) = ""
							A1(i,10) = ""
							A1(i,11) = ""
							A1(i,12) = ""
							A1(i,13) = ""
							A1(i,14) = ""
						else
							A1(i,15) = ""
							A1(i,16) = ""
							A1(i,17) = ""
						end if
						A1(i,18) = Rs1("srspn_cname").Value
						A1(i,19) = Rs1("pub_remark").Value
						'A1(i,20) = Rs1("bk_nm").Value
    						preNo = Rs1("pub_contno").Value


						Dim highlight
						' Highlight Some Rows: 此為一般欄位使用的格式 A1/B1
						highlight = "A" & (6+i) & ":T" & (6+i)
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
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("adpub_form2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "adpub_form2.xls", True)

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
