<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptContList" method="post" runat="server">
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
			
			
			'------------
			'報表程式開始
			'------------
				
			' -- 資料庫與資料來源設定 --
			DIM dbFile
			DIM oConn
			DIM DSN
			
			' -- 儲存資料的RecordSet --
			DIM rsUser
			DIM rsCount
			DIM rsData
			DIM rsDataCounts
			
			' -- T-SQL Command --
			DIM sqlCmdUser
			DIM sqlCmdData
			DIM sqlCmdRsCount
			DIM sqlCmdDataCounts
			DIM strFilter
			
			' -- 環境變數 --
			DIM strDate
			DIM strUser
			DIM strNOW
			
			' -- 資料筆數 --
			DIM strRsCount
			
			' -- Excel Speed Gen 物件 --
			DIM XLS
			DIM SrcBook
			
			' -- 設定資料來源與資料庫 --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- 設定環境變數 --
			' 完整反應日期
			strDate = Request("strdate")
			strUser = Request("whoami")
			
			' 如果正常，就可以使用
			IF (Request("Whoami") <> "") THEN
				strUser = Request("Whoami")
			ELSE
			' 不然就給空字串
				strUser = ""
			END IF
			

			' -- 設定T-SQL Command，取回資料 --	
			' 組合取得資料筆數的T-SQL Command
			'這個是舊的
			'sqlCmdRsCount = ""
			'sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) "
			'sqlCmdRsCount = sqlCmdRsCount & "FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno "
			'sqlCmdRsCount = sqlCmdRsCount & "LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno "
			'sqlCmdRsCount = sqlCmdRsCount & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') AND cont_fgclosed='0'"
			sqlCmdRsCount = ""
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) "
			sqlCmdRsCount = sqlCmdRsCount & "FROM wk_c4_getad "
			
			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " AND " & strFilter
			END IF
			
			' 抓取符合條件的筆數
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strRsCount = 0
			ELSE
				strRsCount = rsCount(0).Value
			END IF
			
			' 組合取得資料的T-SQL Command
			'這組是舊的
			'sqlCmdData = ""
			'sqlCmdData = SqlCmdData & "SELECT cont_syscd, cont_contno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_custno, cont_aunm, cont_autel, "
			'sqlCmdData = SqlCmdData & "cont_aufax, cont_aucell, cont_auemail, cont_freetm, cont_resttm, cont_pubtm, cont_totimgtm, cont_toturltm, cont_disc, cont_totamt, "
			'sqlCmdData = SqlCmdData & "cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_pdcont, cont_remark, cont_credate, cont_moddate, cont_modempno, cont_oldcontno, "
			'sqlCmdData = SqlCmdData & "cont_fgpayonce, cont_fgtemp, cont_fgpubed, cont_fgclosed, cont_fgcancel, cust_custno, cust_nm, mfr_mfrno, mfr_inm "
			'sqlCmdData = SqlCmdData & "FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno "
			'sqlCmdData = SqlCmdData & "LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno "
			'sqlCmdData = SqlCmdData & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') AND cont_fgclosed='0'"

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT * from wk_c4_getad "
			sqlCmdData = SqlCmdData & "ORDER BY  cont_fgout DESC, cont_contno, adr_addate "


			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF
			
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)
						
			' -- 取得員工資料 --
			DIM rsEmp
			DIM sqlCmdEmp
			
			sqlCmdEmp = sqlCmdEmp & "SELECT srspn_empno, srspn_cname FROM srspn"	
			rsEmp = oConn.Execute(sqlCmdEmp)
			
											
			DIM sqlCmdIa, sqlCmdPy
			DIM rsIa, rsPy
			DIM contno
			
			' -- 顯示資料 --
			IF (rsData.EOF) THEN
			    ' 無資料就給訊息
				Response.Write("無符合條件的資料")
			ELSE
				' 有資料就開啟Excel Speed Gen物件
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' 先第一筆
				rsData.MoveFirst
						
				' 設定Array，6個欄位
				'DIM A1(strRsCount, 40)
				
				' 設定列數，+5是額外的
				DIM rowCount
				rowCount = strRsCount+ 5
							
				DIM A1(rowCount, 32)
				
				DIM i
				DIM datestr
				DIM	edate, sdate
				sdate = Mid(strDate, 1, 4) & Mid(strDate, 6, 2) & Mid(strDate, 9, 2)
				edate = Mid(strDate, 12, 4) & Mid(strDate, 17, 2) & Mid(strDate, 20, 2)
				
				DIM contno_pre
				DIM	idx
				contno_pre=""
				idx = 1
				' 把資料填入Array中
				FOR i=0 TO rowCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' 資料區
					IF(rsData("cont_contno").Value=contno_pre) THEN
					'主檔資料只顯示一次
						A1(i, 0) = ""
						A1(i, 1) = ""
						A1(i, 2) = ""
						A1(i, 3) = ""
						A1(i, 4) = ""
						A1(i, 5) = ""
						A1(i, 6) = ""
						A1(i, 7) = ""
						A1(i, 8) = ""
						A1(i, 9) = ""
						A1(i, 11) = ""
						A1(i, 22) = ""
						A1(i, 23) = ""
						A1(i, 24) = ""
						A1(i, 25) = ""
						A1(i, 26) = ""
						A1(i, 27) = ""
						A1(i, 28) = ""
						A1(i, 29) = ""
						A1(i, 30) = ""
						A1(i, 31) = ""
					ELSE
						A1(i, 0) = idx
						idx = idx + 1
						contno_pre = rsData("cont_contno").Value
						A1(i, 1) = ""
						IF (rsData("cont_edate").Value<=edate) AND (rsData("cont_edate").Value>=sdate) THEN
							A1(i, 1) = "*"
						END IF
						A1(i, 2) = rsData("cont_contno").Value
						A1(i, 3) = rsData("cont_aunm").Value
						A1(i, 4) = rsData("mfr_inm").Value
						A1(i, 5) = rsData("cont_autel").Value
						A1(i, 6) = rsData("cont_aufax").Value
						A1(i, 7) = rsData("cont_aucell").Value
						datestr = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value	
						A1(i, 8) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
						IF TRIM(rsData("adr_sdate").Value) = "" THEN
							A1(i, 9) = ""
						ELSE
							datestr = rsData("adr_sdate").Value & "~" & rsData("adr_edate").Value
							A1(i, 9) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
						END IF
						A1(i, 11) = rsData("tot_adr_addays").Value
						A1(i, 22) = rsData("cont_pubtm").Value
						A1(i, 23) = rsData("cont_freetm").Value
						A1(i, 24) = rsData("cont_totimgtm").Value
						A1(i, 25) = rsData("res_drafttp").Value
						A1(i, 26) = rsData("cont_toturltm").Value
						A1(i, 27) = rsData("res_urltp").Value
						A1(i, 28) = rsData("cont_totamt").Value
						contno = rsData("cont_contno").Value
						'取得已繳款之總金額
						sqlCmdPy = "SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia "
						sqlCmdPy = sqlCmdPy & "WHERE (ia_syscd = 'C4') "
						sqlCmdPy = sqlCmdPy & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
						sqlCmdPy = sqlCmdPy & "AND (ia.ia_pyno <> '') GROUP BY  ia_contno"
						rsPy = oConn.Execute(sqlCmdPy)
						'取得已轉SAP的發票總金額
						sqlCmdIa = "SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia "
						sqlCmdIa = sqlCmdIa & "WHERE (ia_syscd = 'C4') "
						sqlCmdIa = sqlCmdIa & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
						sqlCmdIa = sqlCmdIa & "AND (ia_status = '7') GROUP BY  ia_contno"
						rsIa = oConn.Execute(sqlCmdIa)
						IF (rsPy.EOF) THEN
							A1(i, 30) = 0
						ELSE
							A1(i, 30) = rsPy("sum_py").Value
						END IF
						IF (rsIa.EOF) THEN
							A1(i, 29) = 0
						ELSE
							A1(i, 29) = rsIa("sum_ia").Value
						END IF
'						A1(i, 29) = rsData("ia_amt").Value
'						A1(i, 30) = rsData("cont_paidamt").Value
						'業務員姓名
						rsEmp.MoveFirst
						WHILE NOT rsEmp.EOF
							IF (RTRIM(rsEmp("srspn_empno").Value)=RTRIM(rsData("cont_empno").Value)) THEN
								'設定欄位
								A1(i,  31) = RTRIM(rsEmp("srspn_cname").Value)
								EXIT WHILE
							END IF
							rsEmp.MoveNext
						END WHILE		
					END IF								
					IF TRIM(rsData("adr_addate").Value)="" THEN
						A1(i, 10) = ""
					ELSE
						A1(i, 10) = Mid(rsData("adr_addate").Value, 5, 2) & "/" & Mid(rsData("adr_addate").Value, 7, 2)
					END IF
					IF rsData("adr_adcate").Value = "M" THEN
						A1(i, 12) = "首頁"
					ELSE IF rsData("adr_adcate").Value = "I"
						A1(i, 12) = "內頁"
					ELSE IF rsData("adr_adcate").Value = "N"
						A1(i, 12) = "奈米"
					ELSE
						A1(i, 12) = ""
					END IF		
												
					A1(i, 13) = rsData("adr_keyword").Value
					
					IF rsData("adr_keyword").Value = "h0" THEN
						A1(i, 13) = "正中"
					ELSE IF rsData("adr_keyword").Value = "h1" THEN
						A1(i, 13) = "右一"
					ELSE IF rsData("adr_keyword").Value = "h2" THEN
						A1(i, 13) = "右二"
					ELSE IF rsData("adr_keyword").Value = "h3" THEN
						A1(i, 13) = "右三"
					ELSE IF rsData("adr_keyword").Value = "h4" THEN
						A1(i, 13) = "右四"
					ELSE IF rsData("adr_keyword").Value = "w1" THEN
						A1(i, 13) = "右文一"
					ELSE IF rsData("adr_keyword").Value = "w2" THEN
						A1(i, 13) = "右文二"
					ELSE IF rsData("adr_keyword").Value = "w3" THEN
						A1(i, 13) = "右文三"
					ELSE IF rsData("adr_keyword").Value = "w4" THEN
						A1(i, 13) = "右文四"
					ELSE IF rsData("adr_keyword").Value = "w5" THEN
						A1(i, 13) = "右文五"
					ELSE IF rsData("adr_keyword").Value = "w6" THEN
						A1(i, 13) = "右文六"
					ELSE
						A1(i, 13) = ""
					END IF							

					IF rsData("adr_fgfixad").Value = "1" THEN
						A1(i, 14) = "定播"
					ELSE IF rsData("adr_fgfixad").Value = "0" THEN
						A1(i, 14) = "輪播"
					ELSE
						A1(i, 14) = ""
					END IF
							
					A1(i, 15) = rsData("adr_impr").Value
					IF rsData("adr_drafttp").Value = "1" THEN
						A1(i, 16) = "舊稿"
					ELSE IF rsData("adr_drafttp").Value = "2" THEN
						A1(i, 16) = "新稿"
					ELSE IF rsData("adr_drafttp").Value = "3" THEN
						A1(i, 16) = "改稿"
					END IF
					A1(i, 17) = rsData("adr_imgurl").Value
					IF rsData("adr_fgimggot").Value = "1" THEN
						A1(i, 18) = "是"
					ELSE IF rsData("adr_fgimggot").Value = "0" THEN
						A1(i, 18) = "否"
					ELSE
						A1(i, 18) = ""
					END IF
					IF rsData("adr_urltp").Value = "1" THEN
						A1(i, 19) = "舊稿"
					ELSE IF rsData("adr_urltp").Value = "2" THEN
						A1(i, 19) = "新稿"
					ELSE IF rsData("adr_urltp").Value = "3" THEN
						A1(i, 19) = "改稿"
					END IF
					A1(i, 20) = rsData("adr_navurl").Value
					IF rsData("adr_fgurlgot").Value = "1" THEN
						A1(i, 21) = "是"
					ELSE IF rsData("adr_fgurlgot").Value = "0" THEN
						A1(i, 21) = "否"
					ELSE
						A1(i, 21) = ""
					END IF
					
					' 設定交錯
					DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7
					'寬度欄號設定
					highlight1 = "A" & (5+i) & ":C" & (5+i)
					highlight2 = "D" & (5+i) & ":K" & (5+i)
					highlight3 = "L" & (5+i) & ":Q" & (5+i)
					highlight4 = "R" & (5+i) & ":V" & (5+i)
					highlight5 = "W" & (5+i) & ":AB" & (5+i)
					highlight6 = "AC" & (5+i) & ":AE" & (5+i)
					highlight7 = "AF" & (5+i) & ":AF" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A8", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight7, 2, "A2", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B8", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight7, 2, "B2", FALSE)
					END IF
					
					
					' RS移動
					rsData.MoveNext
					
					' 安全控制
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				
				'A1(rowCount, 1) = sqlCmdAdrCount
				'A1(rowCount, 2) = AdrCount
				'A1(rowCount, 3) = strRsCount
				
				' 把設定Sheet藏起來
				XLS.HideSheet(2, TRUE)
				
				' 使用Array作為資料來源
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' 在Excel Speed Gen中設定變數
				XLS.AddVariable("strDate", strDate)	'在Excel中用 >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'在Excel中用 >>$WHOAMI
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptGetAd_Adr.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptGetAd_Adr.xls", TRUE)
				
				' 資源釋放
				XLS = NOTHING
				
				oConn.Close
				oConn = NOTHING
				' 完成Excel Speed Gen設定
			END IF				
				
			%>
		</form>
	</body>
</HTML>
