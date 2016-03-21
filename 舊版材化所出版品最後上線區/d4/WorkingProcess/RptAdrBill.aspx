<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告落版單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptAdrList" method="post" runat="server">
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
'			DIM strDate
			DIM strUser
			DIM strNOW
			
			
			' -- Excel Speed Gen 物件 --
			DIM XLS
			DIM SrcBook
			
			' 設定交錯
			DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
			' -- 設定資料來源與資料庫 --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- 設定環境變數 --
			' 完整反應日期
'			strDate = Request("Today")
			strUser = Request("whoami")
			
			' 如果正常，就可以使用
			IF (Request("Whoami") <> "") THEN
				strUser = Request("Whoami")
			ELSE
			' 不然就給空字串
				strUser = ""
			END IF
			
			' 組合的搜尋條件
			IF (Session("RPTADRLIST") <> "") THEN
				strFilter = Session("RPTADRLIST")
			ELSE
				strFilter = ""
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
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) AS adrcount, c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword "
			sqlCmdRsCount = sqlCmdRsCount & "FROM c4_adr INNER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "c4_cont ON c4_adr.adr_syscd = c4_cont.cont_syscd AND  "
			sqlCmdRsCount = sqlCmdRsCount & "c4_adr.adr_contno = c4_cont.cont_contno INNER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "srspn ON c4_cont.cont_empno = srspn.srspn_empno INNER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno "
			sqlCmdRsCount = sqlCmdRsCount & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') "
			
			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " AND " & strFilter
			END IF
			
			sqlCmdRsCount = sqlCmdRsCount & "GROUP BY  c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword "
			sqlCmdRsCount = sqlCmdRsCount & "ORDER BY c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword "
			' 抓取符合條件的筆數
			' -- 小計筆數 --
			DIM strCount	
			' -- 資料筆數 --
			DIM strRsCount
			
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strRsCount = 0
			ELSE
				rsCount.MoveFirst
				strRsCount = 0
				Do while not rsCount.EOF
					strRsCount = strRsCount + rsCount("adrcount").Value
					strCount = strCount + 1
					rsCount.MoveNext
				Loop
			END IF
			
			' 組合取得資料的T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT c4_adr.*, c4_cont.cont_mfrno, mfr.mfr_inm, c4_cont.cont_empno, srspn.srspn_cname "
			sqlCmdData = SqlCmdData & "FROM c4_adr INNER JOIN "
			sqlCmdData = SqlCmdData & "c4_cont ON c4_adr.adr_syscd = c4_cont.cont_syscd AND  "
			sqlCmdData = SqlCmdData & "c4_adr.adr_contno = c4_cont.cont_contno INNER JOIN "
			sqlCmdData = SqlCmdData & "srspn ON c4_cont.cont_empno = srspn.srspn_empno INNER JOIN "
			sqlCmdData = SqlCmdData & "mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno "
			sqlCmdData = SqlCmdData & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') "


			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF

			sqlCmdData = SqlCmdData & "ORDER BY c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword, c4_adr.adr_contno "
			
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)
			
											
			' -- 顯示資料 --
			DIM predate, precate, prekeyword
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
										
				DIM A1(strRsCount+strCount, 24)
				
				DIM i, j, idx, counter, color_idx
				DIM datestr
				
				predate = ""
				precate = ""
				prekeyword = ""
				counter = 0
				idx = 0
				j = 0
				color_idx = 0
				' 把資料填入Array中
				FOR j=0 TO strRsCount STEP 1
					i = j + idx
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' 資料區
					IF ((predate <> rsData("adr_addate").Value) OR (precate <> rsData("adr_adcate").Value) OR (prekeyword <> rsData("adr_keyword").Value))
						'先將小計OUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 3) = ""
							A1(i, 4) = ""
							A1(i, 5) = ""
							A1(i, 6) = "小計："
							A1(i, 7) = counter
							highlight1 = "A" & (5+i) & ":F" & (5+i)
							highlight2 = "G" & (5+i) & ":G" & (5+i)
							highlight3 = "H" & (5+i) & ":H" & (5+i)
							highlight4 = "I" & (5+i) & ":X" & (5+i)
							IF (color_idx MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "A14", FALSE)
								XLS.FormatCells(1, highlight3, 2, "A15", FALSE)
								XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "B14", FALSE)
								XLS.FormatCells(1, highlight3, 2, "B15", FALSE)
								XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
							END IF
							counter = 0
							idx = idx + 1
							i = j + idx
						END IF
					END IF
					IF (predate <> rsData("adr_addate").Value)
						IF (i<>0) THEN
							color_idx = color_idx + 1
						END IF
					END IF
					predate = rsData("adr_addate").Value
					precate = rsData("adr_adcate").Value
					prekeyword = rsData("adr_keyword").Value
					A1(i, 0) = j + 1
					A1(i, 1) = rsData("adr_contno").Value
					A1(i, 2) = rsData("adr_seq").Value
					A1(i, 3) = RTRIM(rsData("mfr_inm").Value)
					datestr = rsData("adr_addate").Value 	
					A1(i, 4) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 2)
					IF rsData("adr_adcate").Value = "M" THEN
						A1(i, 5) = "首頁"
					ELSE IF rsData("adr_adcate").Value = "I"
						A1(i, 5) = "內頁"
					ELSE IF rsData("adr_adcate").Value = "N"
						A1(i, 5) = "奈米"
					ELSE
						A1(i, 5) = "(錯誤)"
					END IF		
														
					IF rsData("adr_keyword").Value = "h0" THEN
						A1(i, 6) = "正中"
					ELSE IF rsData("adr_keyword").Value = "h1" THEN
						A1(i, 6) = "右一"
					ELSE IF rsData("adr_keyword").Value = "h2" THEN
						A1(i, 6) = "右二"
					ELSE IF rsData("adr_keyword").Value = "h3" THEN
						A1(i, 6) = "右三"
					ELSE IF rsData("adr_keyword").Value = "h4" THEN
						A1(i, 6) = "右四"
					ELSE IF rsData("adr_keyword").Value = "w1" THEN
						A1(i, 6) = "右文一"
					ELSE IF rsData("adr_keyword").Value = "w2" THEN
						A1(i, 6) = "右文二"
					ELSE IF rsData("adr_keyword").Value = "w3" THEN
						A1(i, 6) = "右文三"
					ELSE IF rsData("adr_keyword").Value = "w4" THEN
						A1(i, 6) = "右文四"
					ELSE IF rsData("adr_keyword").Value = "w5" THEN
						A1(i, 6) = "右文五"
					ELSE IF rsData("adr_keyword").Value = "w6" THEN
						A1(i, 6) = "右文六"
					ELSE
					END IF							
									
					A1(i, 7) = rsData("adr_impr").Value
					counter = counter + rsData("adr_impr").Value
					A1(i, 8) = ""
					A1(i, 9) = ""
					A1(i, 10) = ""
					IF rsData("adr_drafttp").Value = "1" THEN
						A1(i, 8) = "v"		'舊稿
					ELSE IF rsData("adr_drafttp").Value = "2" THEN
						A1(i, 9) = "v"		'新稿
					ELSE IF rsData("adr_drafttp").Value = "3" THEN
						A1(i, 10) = "v"		'改稿
					END IF
					A1(i, 11) = rsData("adr_imgurl").Value
					IF rsData("adr_fgimggot").Value = "1" THEN
						A1(i, 12) = "是"
					ELSE
						A1(i, 12) = "否"
					END IF

					A1(i, 13) = ""
					A1(i, 14) = ""
					A1(i, 15) = ""
					IF rsData("adr_urltp").Value = "1" THEN
						A1(i, 13) = "v"		'舊稿
					ELSE IF rsData("adr_urltp").Value = "2" THEN
						A1(i, 14) = "v"		'新稿
					ELSE IF rsData("adr_urltp").Value = "3" THEN
						A1(i, 15) = "v"		'改稿
					END IF
					A1(i, 16) = rsData("adr_navurl").Value
					IF rsData("adr_fgurlgot").Value = "1" THEN
						A1(i, 17) = "是"
					ELSE
						A1(i, 17) = "否"
					END IF
					
					A1(i, 18) = rsData("adr_alttext").Value
					A1(i, 19) = rsData("adr_adamt").Value
					A1(i, 20) = rsData("adr_desamt").Value
					A1(i, 21) = rsData("adr_chgamt").Value
					A1(i, 22) = RTRIM(rsData("srspn_cname").Value)
					A1(i, 23) = rsData("adr_remark").Value
					
					' 設定交錯
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'寬度欄號設定
					highlight1 = "A" & (5+i) & ":C" & (5+i)
					highlight2 = "D" & (5+i) & ":D" & (5+i)
					highlight3 = "E" & (5+i) & ":K" & (5+i)
					highlight4 = "L" & (5+i) & ":L" & (5+i)
					highlight5 = "M" & (5+i) & ":P" & (5+i)
					highlight6 = "Q" & (5+i) & ":S" & (5+i)
					highlight7 = "T" & (5+i) & ":V" & (5+i)
					highlight8 = "W" & (5+i) & ":X" & (5+i)
				
					IF (color_idx MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight7, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight8, 2, "A1", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight7, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight8, 2, "B1", FALSE)
					END IF
					' RS移動
					rsData.MoveNext
					' 安全控制
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				'最後一次小計
				i = i + 1
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = "小計："
				A1(i, 7) = counter
				highlight1 = "A" & (5+i) & ":F" & (5+i)
				highlight2 = "G" & (5+i) & ":G" & (5+i)
				highlight3 = "H" & (5+i) & ":H" & (5+i)
				highlight4 = "I" & (5+i) & ":X" & (5+i)
				IF (color_idx MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "A14", FALSE)
					XLS.FormatCells(1, highlight3, 2, "A15", FALSE)
					XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "B14", FALSE)
					XLS.FormatCells(1, highlight3, 2, "B15", FALSE)
					XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
				END IF
				
				
				' 把設定Sheet藏起來
				XLS.HideSheet(2, TRUE)
				
				' 使用Array作為資料來源
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' 在Excel Speed Gen中設定變數
'				XLS.AddVariable("TODAY", strNOW)	'在Excel中用 >>$TODAY
				XLS.AddVariable("WHOAMI", strUser)	'在Excel中用 >>$WHOAMI
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptAdrBill.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptAdrBill.xls", TRUE)
				
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
