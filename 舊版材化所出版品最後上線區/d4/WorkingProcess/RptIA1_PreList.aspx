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
		<form id="RptIA1_PreList" method="post" runat="server">
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
			DIM contno
			DIM strUser
			DIM imseq
			
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
			sqlCmdRsCount = sqlCmdRsCount & "FROM wk_c4_ia_prelist "
			
			
			' 抓取符合條件的筆數
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strRsCount = 0
			ELSE
				strRsCount = rsCount(0).Value
			END IF
			
			DIM sqlCmdIa, sqlCmdPy
			DIM rsIa, rsPy
			
			
			' 組合取得資料的T-SQL Command
			
			sqlCmdData = "SELECT * , proj.proj_projno "
			sqlCmdData = sqlCmdData & "FROM wk_c4_ia_prelist INNER JOIN "
			sqlCmdData = sqlCmdData & "proj ON wk_c4_ia_prelist.cont_syscd  COLLATE Chinese_Taiwan_Stroke_CI_AS = proj.proj_syscd "
			sqlCmdData = sqlCmdData & "AND wk_c4_ia_prelist.im_fgitri = proj.proj_fgitri "
			sqlCmdData = sqlCmdData & "ORDER BY  wk_c4_ia_prelist.adr_addate"
		
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)	
											
			'取得已轉SAP的發票總金額
			sqlCmdIa = "SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia "
			sqlCmdIa = sqlCmdIa & "WHERE (ia_syscd = 'C4') "
			sqlCmdIa = sqlCmdIa & "AND (SUBSTRING(ia_contno, 3, 6) = '"& rsData("cont_contno").Value &"') "
			sqlCmdIa = sqlCmdIa & "AND (ia_status = '7') GROUP BY  ia_contno"
			rsIa = oConn.Execute(sqlCmdIa)

			'取得已繳款之總金額
			sqlCmdPy = "SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia "
			sqlCmdPy = sqlCmdPy & "WHERE (ia_syscd = 'C4') "
			sqlCmdPy = sqlCmdPy & "AND (SUBSTRING(ia_contno, 3, 6) = '"& rsData("cont_contno").Value &"') "
			sqlCmdPy = sqlCmdPy & "AND (ia.ia_pyno <> '') GROUP BY  ia_contno"
			rsPy = oConn.Execute(sqlCmdPy)
			
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
				rowCount = strRsCount
							
				DIM A1(rowCount, 22)
				
				DIM i
				DIM datestr
				
				DIM contno_pre
				DIM	idx
				contno_pre=""
				idx = 1
				'發票總金額
				DIM	sum_invamt
				sum_invamt = 0
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
						A1(i, 12) = ""
						A1(i, 13) = ""
					ELSE
						A1(i, 0) = idx
						idx = idx + 1
						contno_pre = rsData("cont_contno").Value
						A1(i, 1) = rsData("cont_contno").Value
						datestr = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value	
						A1(i, 2) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
						A1(i, 3) = rsData("cont_mfrno").Value
						A1(i, 4) = rsData("cont_mfr_inm").Value
						A1(i, 5) = rsData("srspn_cname").Value
						A1(i, 6) = rsData("cont_totamt").Value
						A1(i, 7) = rsData("im_nm").Value
						A1(i, 8) = rsData("im_mfr_inm").Value
						A1(i, 9) = rsData("im_zip").Value & " " & rsData("im_addr").Value
						IF rsData("im_invcd").Value = "2" THEN
							A1(i, 10) = "二聯"
						ELSE IF rsData("im_invcd").Value = "3" THEN
							A1(i, 10) = "三聯"
						ELSE IF rsData("im_invcd").Value = "4" THEN
							A1(i, 10) = "其他"
						END IF
						
						IF rsData("im_taxtp").Value = "1" THEN
							A1(i, 11) = "5%"
						ELSE IF rsData("im_taxtp").Value = "2" THEN
							A1(i, 11) = "零稅"
						ELSE IF rsData("im_taxtp").Value = "3" THEN
							A1(i, 11) = "免稅"
						END IF
						IF rsData("im_fgitri").Value = "06" THEN
							A1(i, 12) = "所內"
						ELSE IF rsData("im_fgitri").Value = "07" THEN
							A1(i, 12) = "院內"
						ELSE
							A1(i, 12) = "一般"
						END IF
						A1(i, 13) = rsData("proj_projno").Value
						IF (rsPy.EOF) THEN
							A1(i, 20) = 0
						ELSE
							A1(i, 20) = rsPy("sum_py").Value
						END IF
						IF (rsIa.EOF) THEN
							A1(i, 21) = 0
						ELSE
							A1(i, 21) = rsIa("sum_ia").Value
						END IF
					END IF								
'					A1(i, 14) = Mid(rsData("adr_addate").Value, 1, 4) & "/" & Mid(rsData("adr_addate").Value, 5, 2) & "/" & Mid(rsData("adr_addate").Value, 7, 2)
					A1(i, 14) = Mid(rsData("adr_addate").Value, 5, 2) & "/" & Mid(rsData("adr_addate").Value, 7, 2)
					A1(i, 15) = rsData("adr_seq").Value
					A1(i, 16) = rsData("adr_adamt").Value
					A1(i, 17) = rsData("adr_desamt").Value
					A1(i, 18) = rsData("adr_chgamt").Value
					A1(i, 19) = rsData("adr_invamt").Value
					sum_invamt = sum_invamt + rsData("adr_invamt").Value
					' 設定交錯
					DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7
					'寬度欄號設定
					highlight1 = "A" & (5+i) & ":D" & (5+i)
					highlight2 = "E" & (5+i) & ":F" & (5+i)
					highlight3 = "G" & (5+i) & ":I" & (5+i)
					highlight4 = "J" & (5+i) & ":L" & (5+i)
					highlight5 = "M" & (5+i) & ":R" & (5+i)
					highlight6 = "S" & (5+i) & ":V" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "A5", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "B5", FALSE)
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
				XLS.AddVariable("TotAmt", sum_invamt)	'在Excel中用 >>$TotAmt
				XLS.AddVariable("TotCount", rowCount)	'在Excel中用 >>$TotCount
				XLS.AddVariable("WHOAMI", strUser)	'在Excel中用 >>$WHOAMI
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptIA1_PreList.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptIA1_PreList.xls", TRUE)
				
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
