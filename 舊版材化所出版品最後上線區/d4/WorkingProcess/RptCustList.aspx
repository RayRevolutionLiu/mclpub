<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>合約客戶基本資料清單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptCustList" method="post" runat="server">
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
'			DIM strNOW
			
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
			IF (Session("RPTCONTLIST") <> "") THEN
				strFilter = Session("RPTCONTLIST")
			ELSE
				strFilter = ""
			END IF		
	
	
			' 現在時間
'			IF (Session("STRNOW") <> "") THEN
'				strNOW = Session("STRNOW")
'			ELSE
'				strNOW = ""
'			END IF		

			' -- 設定T-SQL Command，取回資料 --	
			' 組合取得合約資料筆數
			sqlCmdRsCount = ""
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) "
			sqlCmdRsCount = sqlCmdRsCount & "FROM c4_cont INNER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "srspn ON c4_cont.cont_empno = srspn.srspn_empno LEFT OUTER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "wk_c4_fbkstring ON "
			sqlCmdRsCount = sqlCmdRsCount & "c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_fbkstring.wkfbk_contno "
			sqlCmdRsCount = sqlCmdRsCount & "LEFT OUTER JOIN wk_c4_matpstring ON "
			sqlCmdRsCount = sqlCmdRsCount & "c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_matpstring.wkmatp_contno "
			sqlCmdRsCount = sqlCmdRsCount & "LEFT OUTER JOIN wk_c4_atpstring ON "
			sqlCmdRsCount = sqlCmdRsCount & "c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_atpstring.wkatp_contno "
			sqlCmdRsCount = sqlCmdRsCount & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0')"
			
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
			sqlCmdData = SqlCmdData & "SELECT c4_cont.*, ISNULL(wk_c4_atpstring.wkatp_atpstr, '') AS wkatp_atpstr, "
			sqlCmdData = SqlCmdData & "ISNULL(wk_c4_fbkstring.wkfbk_fbkstr, '') AS wkfbk_fbkstr, "
			sqlCmdData = SqlCmdData & "mfr.mfr_inm, srspn.srspn_cname, ISNULL(wk_c4_matpstring.wkmatp_matpstr, '') AS wkmatp_matpstr "
			sqlCmdData = SqlCmdData & "FROM c4_cont INNER JOIN "
			sqlCmdData = SqlCmdData & "mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
			sqlCmdData = SqlCmdData & "srspn ON c4_cont.cont_empno = srspn.srspn_empno LEFT OUTER JOIN "
			sqlCmdData = SqlCmdData & "wk_c4_fbkstring ON "
			sqlCmdData = SqlCmdData & "c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_fbkstring.wkfbk_contno "
			sqlCmdData = SqlCmdData & "LEFT OUTER JOIN wk_c4_matpstring ON "
			sqlCmdData = SqlCmdData & "c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_matpstring.wkmatp_contno "
			sqlCmdData = SqlCmdData & "LEFT OUTER JOIN wk_c4_atpstring ON "
			sqlCmdData = SqlCmdData & "c4_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = wk_c4_atpstring.wkatp_contno "
			sqlCmdData = SqlCmdData & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0')"


			'加上Where條件			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF
			
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)
			
			
			DIM sqlCmdPy, sqlCmdAdr
			DIM rsPy, rsAdr
			DIM contno, sdate, edate
			
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
				
				' 設定列數
							
				DIM A1(strRsCount, 22)
				
				DIM i
				DIM datestr
				DIM highlight1, highlight2, highlight3, highlight4, highlight5
				
				' 把資料填入Array中
				FOR i=0 TO strRsCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' 資料區
					A1(i, 0) = i+1
					A1(i, 1) = rsData("cont_contno").Value
					A1(i, 2) = rsData("mfr_inm").Value
					datestr = rsData("cont_signdate").Value
					A1(i, 3) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 2)
					IF (rsData("cont_conttp").Value="01") THEN
						A1(i, 4) = "一般"
					ELSE
						A1(i, 4) = "推廣"
					END IF
					datestr = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value	
					A1(i, 5) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
					A1(i, 6) = rsData("cont_pubtm").Value
									
					contno = rsData("cont_contno").Value
					'取得已繳款之總金額
					sqlCmdPy = "SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia "
					sqlCmdPy = sqlCmdPy & "WHERE (ia_syscd = 'C4') "
					sqlCmdPy = sqlCmdPy & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
					sqlCmdPy = sqlCmdPy & "AND (ia.ia_pyno <> '') GROUP BY  ia_contno"
					rsPy = oConn.Execute(sqlCmdPy)
					IF (rsPy.EOF) THEN
						A1(i, 7) = 0
					ELSE
						A1(i, 7) = rsPy("sum_py").Value
					END IF
			
					A1(i,  8) = rsData("cont_aunm").Value
					A1(i,  9) = rsData("cont_autel").Value
					A1(i, 10) = rsData("cont_aufax").Value
					A1(i, 11) = rsData("cont_aucell").Value
					A1(i, 12) = rsData("cont_auemail").Value
					A1(i, 13) = rsData("wkmatp_matpstr").Value	'材料特性
					A1(i, 14) = rsData("wkatp_atpstr").Value	'應用產業
					A1(i, 15) = rsData("cont_ccont").Value		'廣告推廣內文
					A1(i, 16) = rsData("cont_pdcont").Value		'產品設備內文
					A1(i, 17) = Mid(rsData("cont_csdate").Value, 1, 4) & "/" & Mid(rsData("cont_csdate").Value, 5, 2) & "/" & Mid(rsData("cont_csdate").Value, 7, 2)	'搜尋期限
					A1(i, 18) = rsData("wkfbk_fbkstr").Value	'雜誌收件人及贈書資料
					'計算廣告日起迄
					sqlCmdAdr = "SELECT MIN(adr_addate) AS sdate, MAX(adr_addate) AS edate "
					sqlCmdAdr = sqlCmdAdr & "FROM c4_adr WHERE (adr_contno = '"& contno &"') "
					rsAdr = oConn.Execute(sqlCmdAdr)
					IF (rsAdr.EOF) THEN
						A1(i, 19) = ""
					ELSE
						datestr = rsAdr("sdate").Value & "~" & rsAdr("edate").Value	
						A1(i, 19) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
					END IF
					A1(i, 20) = rsData("srspn_cname").Value
					A1(i, 21) = rsData("cont_remark").Value
					
					
					highlight1 = "A" & (6+i) & ":B" & (6+i)
					highlight2 = "C" & (6+i) & ":C" & (6+i)
					highlight3 = "D" & (6+i) & ":G" & (6+i)
					highlight4 = "H" & (6+i) & ":H" & (6+i)
					highlight5 = "I" & (6+i) & ":V" & (6+i)
			
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A1", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B1", FALSE)
					END IF
										
					' RS移動
					rsData.MoveNext
					
					' 安全控制
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				
				
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
				SrcBook = Server.MapPath("RptCustList.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptCustList.xls", TRUE)
				
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
