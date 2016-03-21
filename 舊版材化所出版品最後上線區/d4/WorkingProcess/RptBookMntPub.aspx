<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>印製份數統計表(當月有刊登)</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptBookMntPub" method="post" runat="server">
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
			DIM strConttp
			DIM strBook
			
			' -- Excel Speed Gen 物件 --
			DIM XLS
			DIM SrcBook
			
			' 設定交錯
			DIM highlight1, highlight2, highlight3
			' -- 設定資料來源與資料庫 --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- 設定環境變數 --
			' 完整反應日期
			strDate = Request("strdate")
			strUser = Request("whoami")
			strSrspn = Request("cname")
			strConttp = Request("conttp")
			strBook = Request("bk")
						
			' 組合的搜尋條件
			IF (Session("MAILLABEL") <> "") THEN
				strFilter = Session("MAILLABEL")
			ELSE
				strFilter = ""
			END IF		
	
	
			' -- 設定T-SQL Command，取回資料 --	
			' 組合取得資料的T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT COUNT(*) AS pub_count, dbo.wk_c4_mail_mnt.conttp, "
			sqlCmdData = SqlCmdData & "dbo.wk_c4_mail_mnt.mtpcd, dbo.wk_c4_mail_mnt.pubmnt, dbo.mtp.mtp_nm "
			sqlCmdData = SqlCmdData & "FROM dbo.wk_c4_mail_mnt INNER JOIN "
			sqlCmdData = SqlCmdData & "dbo.mtp ON dbo.wk_c4_mail_mnt.mtpcd = dbo.mtp.mtp_mtpcd "
			sqlCmdData = SqlCmdData & "WHERE (dbo.wk_c4_mail_mnt.pubmnt > 0) "
			
			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdData = SqlCmdData & " AND " & strFilter
			END IF
			'加上排序
			sqlCmdData = SqlCmdData & "GROUP BY  dbo.wk_c4_mail_mnt.conttp, dbo.wk_c4_mail_mnt.mtpcd, "
			sqlCmdData = SqlCmdData & "dbo.wk_c4_mail_mnt.pubmnt, dbo.mtp.mtp_nm "
			sqlCmdData = SqlCmdData & "ORDER BY  dbo.wk_c4_mail_mnt.mtpcd, dbo.wk_c4_mail_mnt.pubmnt "

		
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
				rsData.MoveFirst
			END IF
							
			DIM sum_pubmnt, count_pubmnt
			DIM preMtp
			' -- 顯示資料 --
			IF (rsData.EOF) THEN
			    ' 無資料就給訊息
				Response.Write("無符合條件的資料")
			ELSE
				' 有資料就開啟Excel Speed Gen物件
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' 先第一筆
						
				' 設定Array，5個欄位
				DIM A1(strRsCount+4, 6)
				
				DIM i, j, idx
				DIM datestr
				preMtp = ""
				idx = 0	'項次
				j = 0	'loop變數
				i = 0	'全部資料的序號
				sum_pubmnt = 0
				count_pubmnt = 0
				' 把資料填入Array中
				FOR j=0 TO strRsCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' 資料區
					IF (preMtp <> rsData("mtpcd").Value) AND (preMtp="11") THEN
					
						'郵寄類別跟前一筆不同且不是第一筆資料, 將小計OUTPUT
'						IF (j<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = ""
							A1(i, 3) = "合計："
							A1(i, 4) = CStr(count_pubmnt) & "份"
							A1(i, 5) = CStr(sum_pubmnt) & "本"
							highlight1 = "A" & (7+i) & ":F" & (7+i)
							IF (i MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A11", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B11", FALSE)
							END IF
							i = i + 2
							sum_pubmnt = 0
							count_pubmnt = 0
							A1(i, 0) = "收發室經辦"	
'						END IF
						
					END IF
					IF j=0 THEN
						A1(i, 0) = "大宗郵寄"
					END IF

					IF (rsData("conttp").Value = "01") THEN
						A1(i, 1) = "一般"
					ELSE IF (rsData("conttp").Value = "09") THEN
						A1(i, 1) = "推廣"
					END IF
					A1(i, 2) = rsData("mtp_nm").Value
					A1(i, 3) = rsData("pubmnt").Value & "x"
					A1(i, 4) = rsData("pub_count").Value & "份="
					count_pubmnt = count_pubmnt + rsData("pub_count").Value
					A1(i, 5) = rsData("pubmnt").Value * rsData("pub_count").Value & "本"
					sum_pubmnt = sum_pubmnt + rsData("pubmnt").Value * rsData("pub_count").Value
					preMtp = rsData("mtpcd").Value									
					' 設定交錯
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'寬度欄號設定
					highlight1 = "A" & (7+i) & ":C" & (7+i)
					highlight2 = "D" & (7+i) & ":F" & (7+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A8", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B8", FALSE)
					END IF
					' RS移動
					i = i + 1
					rsData.MoveNext
					' 安全控制
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				'最後一次小計
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 2) = ""
				A1(i, 3) = "合計："
				A1(i, 4) = CStr(count_pubmnt) & "份"
				A1(i, 5) = CStr(sum_pubmnt) & "本"
				highlight1 = "A" & (7+i) & ":F" & (7+i)
				IF (i MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A11", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B11", FALSE)
				END IF
				'最後總計
				
				' 把設定Sheet藏起來
				XLS.HideSheet(2, TRUE)
				
				' 使用Array作為資料來源
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' 在Excel Speed Gen中設定變數
				XLS.AddVariable("strDate", strDate)	'在Excel中用 >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'在Excel中用 >>$WHOAMI
				XLS.AddVariable("strSrspn", strSrspn)	'在Excel中用 >>$strSrspn
				XLS.AddVariable("strBook", strBook)	'在Excel中用 >>$strBook
				XLS.AddVariable("strConttp", strConttp)	'在Excel中用 >>$strConttp
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptBookMntPub.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptBookMntPub.xls", TRUE)
				
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
