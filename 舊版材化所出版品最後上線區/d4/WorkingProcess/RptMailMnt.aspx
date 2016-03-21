<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>郵寄本數統計表</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptMailMnt" method="post" runat="server">
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
			DIM strMtp
			
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
			strMtp = Request("mtpcd")
						
			' 組合的搜尋條件
			IF (Session("MAILLABEL") <> "") THEN
				strFilter = Session("MAILLABEL")
			ELSE
				strFilter = ""
			END IF		
	
	
			' -- 設定T-SQL Command，取回資料 --	
			' 組合取得資料的T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT SUM(wk_c4_mail_mnt.pubmnt) AS sum_pubmnt, "
			sqlCmdData = SqlCmdData & "SUM(wk_c4_mail_mnt.unpubmnt) AS sum_unpubmnt, wk_c4_mail_mnt.contno, "
			sqlCmdData = SqlCmdData & "mfr.mfr_inm, mtp.mtp_nm, wk_c4_mail_mnt.empno, wk_c4_mail_mnt.conttp, "
			sqlCmdData = SqlCmdData & "wk_c4_mail_mnt.fgmosea, wk_c4_mail_mnt.mtpcd, wk_c4_mail_mnt.bkcd "
			sqlCmdData = SqlCmdData & "FROM wk_c4_mail_mnt INNER JOIN "
			sqlCmdData = SqlCmdData & "mfr ON wk_c4_mail_mnt.mfrno = mfr.mfr_mfrno INNER JOIN "
			sqlCmdData = SqlCmdData & "mtp ON wk_c4_mail_mnt.mtpcd = mtp.mtp_mtpcd "
			
			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdData = SqlCmdData & " WHERE " & strFilter
			END IF
			'加上排序
			sqlCmdData = SqlCmdData & "GROUP BY  wk_c4_mail_mnt.contno, wk_c4_mail_mnt.mfrno, mfr.mfr_inm, mtp.mtp_nm, "
			sqlCmdData = SqlCmdData & "wk_c4_mail_mnt.empno, wk_c4_mail_mnt.conttp, wk_c4_mail_mnt.fgmosea, "
			sqlCmdData = SqlCmdData & "wk_c4_mail_mnt.mtpcd, wk_c4_mail_mnt.bkcd "
			sqlCmdData = SqlCmdData & "ORDER BY  wk_c4_mail_mnt.mtpcd, wk_c4_mail_mnt.contno "

		
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)
			' -- 小計筆數 --
			DIM strCount
			DIM preMtp
			' -- 資料筆數 --
			DIM strRsCount
			
			IF (rsData.EOF) THEN
				strRsCount = 0
				strCount = 0
			ELSE
				rsData.MoveFirst
				preMtp = rsData("mtp_nm").Value
				strRsCount = 0
				strCount = 0
				Do while not rsData.EOF
					strRsCount = strRsCount + 1
					IF (preMtp <> rsData("mtp_nm").Value) THEN
						strCount = strCount + 1
					END IF
					rsData.MoveNext
				Loop
				rsData.MoveFirst
			END IF
							
			DIM sum_pubmnt, sum_unpubmnt
			DIM tot_pubmnt, tot_unpubmnt
			' -- 顯示資料 --
			IF (rsData.EOF) THEN
			    ' 無資料就給訊息
				Response.Write("無符合條件的資料")
			ELSE
				' 有資料就開啟Excel Speed Gen物件
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' 先第一筆
						
				' 設定Array，5個欄位
				DIM A1(strRsCount+strCount+2, 6)
				
				DIM i, j, idx
				DIM datestr
				preMtp = ""
				idx = 0	'項次
				j = 0	'loop變數
				i = 0	'全部資料的序號
				sum_pubmnt = 0
				sum_unpubmnt = 0
				tot_pubmnt = 0
				tot_unpubmnt = 0
				' 把資料填入Array中
				FOR j=0 TO strRsCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' 資料區
					IF (preMtp <> rsData("mtp_nm").Value) THEN
					
						'郵寄類別跟前一筆不同且不是第一筆資料, 將小計OUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = ""
							A1(i, 3) = "小計："
							A1(i, 4) = sum_pubmnt
							A1(i, 5) = sum_unpubmnt
							highlight1 = "A" & (7+i) & ":C" & (7+i)
							highlight2 = "D" & (7+i) & ":F" & (7+i)
							IF (i MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "A14", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "B14", FALSE)
							END IF
							i = i + 1
							sum_pubmnt = 0
							sum_unpubmnt = 0
						END IF
					END IF
					A1(i, 0) = j + 1
					A1(i, 1) = rsData("contno").Value
					A1(i, 2) = rsData("mfr_inm").Value
					A1(i, 3) = rsData("mtp_nm").Value
					A1(i, 4) = rsData("sum_pubmnt").Value
					A1(i, 5) = rsData("sum_unpubmnt").Value
									
					preMtp = rsData("mtp_nm").Value
					sum_pubmnt = sum_pubmnt + rsData("sum_pubmnt").Value
					sum_unpubmnt = sum_unpubmnt + rsData("sum_unpubmnt").Value
					tot_pubmnt = tot_pubmnt + rsData("sum_pubmnt").Value
					tot_unpubmnt = tot_unpubmnt + rsData("sum_unpubmnt").Value
					' 設定交錯
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'寬度欄號設定
					highlight1 = "A" & (7+i) & ":B" & (7+i)
					highlight2 = "C" & (7+i) & ":D" & (7+i)
					highlight3 = "E" & (7+i) & ":F" & (7+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A1", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B1", FALSE)
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
				A1(i, 3) = "小計："
				A1(i, 4) = sum_pubmnt
				A1(i, 5) = sum_unpubmnt
				highlight1 = "A" & (7+i) & ":C" & (7+i)
				highlight2 = "D" & (7+i) & ":F" & (7+i)
				IF (i MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "A14", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "B14", FALSE)
				END IF
				i = i + 2
				'最後總計
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 2) = ""
				A1(i, 3) = "總計："
				A1(i, 4) = tot_pubmnt
				A1(i, 5) = tot_unpubmnt
				highlight1 = "A" & (7+i) & ":C" & (7+i)
				highlight2 = "D" & (7+i) & ":F" & (7+i)
				IF (i MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A15", FALSE)
					XLS.FormatCells(1, highlight2, 2, "A15", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B15", FALSE)
					XLS.FormatCells(1, highlight2, 2, "B15", FALSE)
				END IF
				
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
				XLS.AddVariable("strMtp", strMtp)	'在Excel中用 >>$strMtp
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptMailMnt.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptMailMnt.xls", TRUE)
				
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
