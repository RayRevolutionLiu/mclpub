<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告製稿統計表</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptAdMadeList" method="post" runat="server">
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
			strDate = Request("strdate")
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
			sqlCmdRsCount = ""
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) AS adrcount, adr_contno "
			sqlCmdRsCount = sqlCmdRsCount & "FROM v_c4_admadelist "
			
			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " WHERE " & strFilter
			END IF
			'加上排序
			sqlCmdRsCount = sqlCmdRsCount & "GROUP BY  adr_contno "
			sqlCmdRsCount = sqlCmdRsCount & "ORDER BY  adr_contno "
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
				strCount = 0
				Do while not rsCount.EOF
					strRsCount = strRsCount + rsCount("adrcount").Value
					strCount = strCount + 1
					rsCount.MoveNext
				Loop
			END IF
			
			' 組合取得資料的T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT * FROM v_c4_admadelist "

			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " WHERE " & strFilter
			END IF

			'加上排序
			sqlCmdData = sqlCmdData & " ORDER BY v_c4_admadelist.adr_contno, v_c4_admadelist.adr_addate, v_c4_admadelist.adr_seq"
			
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)
			Response.Write(strRsCount+strCount)
											
			' -- 顯示資料 --
			DIM precontno
			IF (rsData.EOF) THEN
			    ' 無資料就給訊息
				Response.Write("無符合條件的資料")
			ELSE
				' 有資料就開啟Excel Speed Gen物件
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' 先第一筆
				rsData.MoveFirst
						
				' 設定Array，18個欄位
				DIM A1(strRsCount+strCount, 17)
				
				DIM i, j, idx
				DIM datestr
				DIM counter, sum_newimg, sum_chgimg, sum_newurl, sum_chgurl
				DIM tot_newimg, tot_chgimg, tot_newurl, tot_chgurl
				precontno = ""
				counter = 0
				sum_newimg = 0
				sum_chgimg = 0
				sum_newurl = 0
				sum_chgurl = 0
				tot_newimg = 0
				tot_chgimg = 0
				tot_newurl = 0
				tot_chgurl = 0
				idx = 0	'項次
				j = 0	'loop變數
				i = 0	'全部資料的序號
				' 把資料填入Array中
				FOR j=0 TO strRsCount STEP 1
					i = j + idx
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' 資料區
					IF (precontno <> rsData("adr_contno").Value) THEN
					
						'合約編號跟前一筆不同且不是第一筆資料, 將小計OUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 3) = ""
							A1(i, 4) = ""
							A1(i, 5) = ""
							A1(i, 6) = ""
							A1(i, 7) = counter & " 筆落版  小計："
							A1(i, 8) = sum_newimg
							A1(i, 9) = sum_chgimg
							A1(i, 10) = ""
							A1(i, 11) = ""
							A1(i, 12) = sum_newurl
							A1(i, 13) = sum_chgurl
							highlight1 = "A" & (5+i) & ":D" & (5+i)
							highlight2 = "E" & (5+i) & ":H" & (5+i)
							highlight3 = "I" & (5+i) & ":N" & (5+i)
							highlight4 = "O" & (5+i) & ":Q" & (5+i)
							IF (i MOD 2)=0 THEN
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
							tot_newimg = tot_newimg + sum_newimg
							tot_chgimg = tot_chgimg + sum_chgimg
							tot_newurl = tot_newurl + sum_newurl
							tot_chgurl = tot_chgurl + sum_chgurl
							sum_newimg = 0
							sum_chgimg = 0
							sum_newurl = 0
							sum_chgurl = 0
							counter = 0
							idx = idx + 1
							i = j + idx
						END IF
						'不重複出現的資料
						A1(i, 0) = idx + 1
						A1(i, 1) = rsData("adr_contno").Value
						A1(i, 3) = RTRIM(rsData("mfr_inm").Value)
						A1(i, 16) = rsData("srspn_cname").Value
					END IF
					A1(i, 2) = rsData("adr_seq").Value
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
					IF rsData("adr_drafttp").Value = "2" THEN
						A1(i, 8) = "v"
						sum_newimg = sum_newimg + 1
					ELSE IF rsData("adr_drafttp").Value = "3" THEN
						A1(i, 9) = "v"
						sum_chgimg = sum_chgimg + 1
					END IF
					A1(i, 10) = rsData("adr_imgurl").Value
					IF rsData("adr_fgimggot").Value = "1" THEN
						A1(i, 11) = "是"
					ELSE
						A1(i, 11) = "否"
					END IF
					IF rsData("adr_urltp").Value = "2" THEN
						A1(i, 12) = "v"
						sum_newurl = sum_newurl + 1
					ELSE IF rsData("adr_urltp").Value = "3" THEN
						A1(i, 13) = "v"
						sum_chgurl = sum_chgurl + 1
					END IF
					A1(i, 14) = rsData("adr_navurl").Value
					IF rsData("adr_fgurlgot").Value = "1" THEN
						A1(i, 15) = "是"
					ELSE
						A1(i, 15) = "否"
					END IF
					precontno = rsData("adr_contno").Value					
					counter = counter + 1
					
					' 設定交錯
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'寬度欄號設定
					highlight1 = "A" & (5+i) & ":C" & (5+i)
					highlight2 = "D" & (5+i) & ":D" & (5+i)
					highlight3 = "E" & (5+i) & ":J" & (5+i)
					highlight4 = "K" & (5+i) & ":K" & (5+i)
					highlight5 = "L" & (5+i) & ":N" & (5+i)
					highlight6 = "O" & (5+i) & ":O" & (5+i)
					highlight7 = "P" & (5+i) & ":Q" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight7, 2, "A2", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "B1", FALSE)
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
				'最後一次小計
				i = i + 1
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = ""
				A1(i, 7) = counter & " 筆落版  小計："
				A1(i, 8) = sum_newimg
				A1(i, 9) = sum_chgimg
				A1(i, 10) = ""
				A1(i, 11) = ""
				A1(i, 12) = sum_newurl
				A1(i, 13) = sum_chgurl
				highlight1 = "A" & (5+i) & ":D" & (5+i)
				highlight2 = "E" & (5+i) & ":H" & (5+i)
				highlight3 = "I" & (5+i) & ":N" & (5+i)
				highlight4 = "O" & (5+i) & ":Q" & (5+i)
				IF (i MOD 2)=0 THEN
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
				tot_newimg = tot_newimg + sum_newimg
				tot_chgimg = tot_chgimg + sum_chgimg
				tot_newurl = tot_newurl + sum_newurl
				tot_chgurl = tot_chgurl + sum_chgurl
				'最後總計
				
				' 把設定Sheet藏起來
				XLS.HideSheet(2, TRUE)
				
				' 使用Array作為資料來源
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' 在Excel Speed Gen中設定變數
				XLS.AddVariable("strDate", strDate)	'在Excel中用 >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'在Excel中用 >>$WHOAMI
				XLS.AddVariable("tot_newimg", tot_newimg)	'在Excel中用 >>$tot_newimg
				XLS.AddVariable("tot_chgimg", tot_chgimg)	'在Excel中用 >>$tot_chgimg
				XLS.AddVariable("tot_newurl", tot_newurl)	'在Excel中用 >>$tot_newurl
				XLS.AddVariable("tot_chgurl", tot_chgurl)	'在Excel中用 >>$tot_chgurl
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptAdMadeList.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptAdMadeList.xls", TRUE)
				
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
