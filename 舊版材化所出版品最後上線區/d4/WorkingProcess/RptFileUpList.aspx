<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>美編上稿清單表</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptFileUpList" method="post" runat="server">
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
			DIM strSrspn
			
			
			' -- Excel Speed Gen 物件 --
			DIM XLS
			DIM SrcBook
			
			' 設定交錯
			DIM highlight1, highlight2
			' -- 設定資料來源與資料庫 --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- 設定環境變數 --
			' 完整反應日期
			strDate = Request("strdate")
			strUser = Request("whoami")
			strSrspn = Request("cname")
			
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
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) AS adr_count, SUM(c4_adr.adr_impr) AS sum_impr, "
			sqlCmdRsCount = sqlCmdRsCount & "c4_adr.adr_addate, c4_adr.adr_adcate "
			sqlCmdRsCount = sqlCmdRsCount & "FROM c4_adr INNER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "c4_cont ON c4_adr.adr_contno = c4_cont.cont_contno "
			
			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " WHERE " & strFilter
			END IF
			'加上排序
			sqlCmdRsCount = sqlCmdRsCount & "GROUP BY  c4_adr.adr_addate, c4_adr.adr_adcate "
			sqlCmdRsCount = sqlCmdRsCount & "ORDER BY  c4_adr.adr_addate, c4_adr.adr_adcate DESC "
			' 抓取符合條件的筆數
			' -- 小計筆數 --
			DIM strCount	
			
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strCount = 0
			ELSE
				rsCount.MoveFirst
				strCount = 0
				Do while not rsCount.EOF
					strCount = strCount + 1
					rsCount.MoveNext
				Loop
			END IF
			
			' 組合取得資料的T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT COUNT(*) AS adr_count, SUM(c4_adr.adr_impr) AS sum_impr, "
			sqlCmdData = SqlCmdData & "c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword "
			sqlCmdData = SqlCmdData & "FROM c4_adr INNER JOIN "
			sqlCmdData = SqlCmdData & "c4_cont ON c4_adr.adr_contno = c4_cont.cont_contno "

			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " WHERE " & strFilter
			END IF

			'加上排序
			sqlCmdData = SqlCmdData & "GROUP BY  c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword "
			sqlCmdData = SqlCmdData & "ORDER BY  c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword "
			
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)
			' -- 資料筆數 --
			DIM strRsCount
			
			IF (rsData.EOF) THEN
				strRsCount = 0
			ELSE
				rsData.MoveFirst
				strRsCount = 0
				Do while not rsData.EOF
					strRsCount = strRsCount + 1
					rsData.MoveNext
				Loop
			END IF
											
			' -- 顯示資料 --
			DIM precate, predate
			rsData.MoveFirst
			rsCount.MoveFirst
			IF (rsData.EOF) THEN
			    ' 無資料就給訊息
				Response.Write("無符合條件的資料")
			ELSE
				' 有資料就開啟Excel Speed Gen物件
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' 先第一筆
						
				' 設定Array，5個欄位
				DIM A1(strRsCount+strCount, 5)
				
				DIM i, j, idx
				DIM datestr
				precate = ""
				predate = ""
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
					IF (precate <> rsData("adr_adcate").Value) THEN
					
						'合約編號跟前一筆不同且不是第一筆資料, 將小計OUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = "小計："
							A1(i, 3) = rsCount("adr_count").Value
							A1(i, 4) = rsCount("sum_impr").Value
							highlight1 = "A" & (6+i) & ":B" & (6+i)
							highlight2 = "C" & (6+i) & ":E" & (6+i)
							IF (idx MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "A12", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "B12", FALSE)
							END IF
							idx = idx + 1
							i = j + idx
							rsCount.MoveNext
						END IF
					ELSE
						IF (predate <> rsData("adr_addate").Value) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = "小計："
							A1(i, 3) = rsCount("adr_count").Value
							A1(i, 4) = rsCount("sum_impr").Value
							highlight1 = "A" & (6+i) & ":B" & (6+i)
							highlight2 = "C" & (6+i) & ":E" & (6+i)
							IF (idx MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "A12", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "B12", FALSE)
							END IF
							idx = idx + 1
							i = j + idx
							rsCount.MoveNext
						END IF
					END IF
					datestr = rsData("adr_addate").Value 	
					A1(i, 0) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 2)
					IF rsData("adr_adcate").Value = "M" THEN
						A1(i, 1) = "首頁"
					ELSE IF rsData("adr_adcate").Value = "I"
						A1(i, 1) = "內頁"
					ELSE IF rsData("adr_adcate").Value = "N"
						A1(i, 1) = "奈米"
					ELSE
						A1(i, 1) = "(錯誤)"
					END IF		
														
					IF rsData("adr_keyword").Value = "h0" THEN
						A1(i, 2) = "正中"
					ELSE IF rsData("adr_keyword").Value = "h1" THEN
						A1(i, 2) = "右一"
					ELSE IF rsData("adr_keyword").Value = "h2" THEN
						A1(i, 2) = "右二"
					ELSE IF rsData("adr_keyword").Value = "h3" THEN
						A1(i, 2) = "右三"
					ELSE IF rsData("adr_keyword").Value = "h4" THEN
						A1(i, 2) = "右四"
					ELSE IF rsData("adr_keyword").Value = "w1" THEN
						A1(i, 2) = "右文一"
					ELSE IF rsData("adr_keyword").Value = "w2" THEN
						A1(i, 2) = "右文二"
					ELSE IF rsData("adr_keyword").Value = "w3" THEN
						A1(i, 2) = "右文三"
					ELSE IF rsData("adr_keyword").Value = "w4" THEN
						A1(i, 2) = "右文四"
					ELSE IF rsData("adr_keyword").Value = "w5" THEN
						A1(i, 2) = "右文五"
					ELSE IF rsData("adr_keyword").Value = "w6" THEN
						A1(i, 2) = "右文六"
					ELSE
					END IF							
					A1(i, 3) = rsData("adr_count").Value
					A1(i, 4) = rsData("sum_impr").Value
									
					precate = rsData("adr_adcate").Value					
					predate = rsData("adr_addate").Value					
					
					' 設定交錯
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'寬度欄號設定
					highlight1 = "A" & (6+i) & ":C" & (6+i)
					highlight2 = "D" & (6+i) & ":E" & (6+i)
				
					IF (idx MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
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
				A1(i, 2) = "小計："
				A1(i, 3) = rsCount("adr_count").Value
				A1(i, 4) = rsCount("sum_impr").Value
				highlight1 = "A" & (6+i) & ":B" & (6+i)
				highlight2 = "C" & (6+i) & ":E" & (6+i)
				IF (i MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "A12", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "B12", FALSE)
				END IF
				'最後總計
				
				' 把設定Sheet藏起來
				XLS.HideSheet(2, TRUE)
				
				' 使用Array作為資料來源
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' 在Excel Speed Gen中設定變數
				XLS.AddVariable("strDate", strDate)	'在Excel中用 >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'在Excel中用 >>$WHOAMI
				XLS.AddVariable("strSrspn", strSrspn)	'在Excel中用 >>$tot_newimg
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptFileUpList.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptFileUpList.xls", TRUE)
				
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
