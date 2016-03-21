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
		<form id="RptIA_ChkList" method="post" runat="server">
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
			DIM strIabDate, IabDate, strIabSeq, IabSeq, sortkey
			DIM strUser
			DIM strNOW
			
			' -- 資料筆數 --
			DIM strRsCount, strRsDataCount
			
			' -- Excel Speed Gen 物件 --
			DIM XLS
			DIM SrcBook
			
			' 設定交錯
			DIM highlight1, highlight2, highlight3, highlight4, highlight5
		
			' -- 設定資料來源與資料庫 --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- 設定環境變數 --
			' 完整反應日期
			IabDate = Request("iabdate")
			strIabDate = Mid(IabDate, 1, 4) & "/" & Mid(IabDate, 5, 2)
			IabSeq = Request("iabseq")
			strIabSeq = IabSeq
			strUser = Request("whoami")
			sortkey = Request("sort")
			
			' 如果正常，就可以使用
			IF (Request("whoami") <> "") THEN
				strUser = Request("whoami")
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
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) FROM ia "
			sqlCmdRsCount = sqlCmdRsCount & "WHERE (ia.ia_syscd = 'C4') AND (ia.ia_iabdate = '" & IabDate & "') AND (ia.ia_iabseq = '" & IabSeq & "') "

			sqlCmdDataCounts = ""
			sqlCmdDataCounts = sqlCmdDataCounts & "SELECT COUNT(*) "
			sqlCmdDataCounts = sqlCmdDataCounts & "FROM ia INNER JOIN "
			sqlCmdDataCounts = sqlCmdDataCounts & "iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN "
			sqlCmdDataCounts = sqlCmdDataCounts & "c4_cont ON iad.iad_syscd = c4_cont.cont_syscd AND "
			sqlCmdDataCounts = sqlCmdDataCounts & "iad.iad_fk1 = c4_cont.cont_contno INNER JOIN "
			sqlCmdDataCounts = sqlCmdDataCounts & "c4_adr ON iad.iad_syscd = c4_adr.adr_syscd AND " 
			sqlCmdDataCounts = sqlCmdDataCounts & "iad.iad_fk1 = c4_adr.adr_contno AND iad.iad_fk3 = c4_adr.adr_seq AND "
			sqlCmdDataCounts = sqlCmdDataCounts & "iad.iad_fk2 = c4_adr.adr_addate LEFT OUTER JOIN "
			sqlCmdDataCounts = sqlCmdDataCounts & "mfr ON ia.ia_mfrno = mfr.mfr_mfrno LEFT OUTER JOIN "
			sqlCmdDataCounts = sqlCmdDataCounts & "mfr mfr_1 ON c4_cont.cont_mfrno = mfr_1.mfr_mfrno "
			sqlCmdDataCounts = sqlCmdDataCounts & "WHERE (ia.ia_syscd = 'C4') AND (ia.ia_iabdate = '" & IabDate & "') AND (ia.ia_iabseq = '" & IabSeq & "') "

			
			
			' 抓取符合條件的筆數
			' 計算有幾行小計
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strRsCount = 0
			ELSE
				strRsCount = rsCount(0).Value
			END IF
			rsDataCounts = oConn.Execute(sqlCmdDataCounts)
			IF (rsDataCounts.EOF) THEN
				strRsDataCount = 0
			ELSE
				strRsDataCount = rsDataCounts(0).Value
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
			sqlCmdData = sqlCmdData & "SELECT ia.*, iad.*, mfr.mfr_inm AS im_mfr_inm, mfr_1.mfr_inm AS cont_mfr_inm, c4_cont.cont_contno, "
			sqlCmdData = sqlCmdData & "c4_cont.cont_empno, c4_cont.cont_sdate, c4_cont.cont_edate, "
			sqlCmdData = sqlCmdData & "c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, c4_adr.adr_chgamt, c4_adr.adr_remark "
			sqlCmdData = sqlCmdData & "FROM ia INNER JOIN "
			sqlCmdData = sqlCmdData & "iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN "
			sqlCmdData = sqlCmdData & "c4_cont ON iad.iad_syscd = c4_cont.cont_syscd AND "
			sqlCmdData = sqlCmdData & "iad.iad_fk1 = c4_cont.cont_contno INNER JOIN "
			sqlCmdData = sqlCmdData & "c4_adr ON iad.iad_syscd = c4_adr.adr_syscd AND " 
			sqlCmdData = sqlCmdData & "iad.iad_fk1 = c4_adr.adr_contno AND iad.iad_fk3 = c4_adr.adr_seq AND "
			sqlCmdData = sqlCmdData & "iad.iad_fk2 = c4_adr.adr_addate LEFT OUTER JOIN "
			sqlCmdData = sqlCmdData & "mfr ON ia.ia_mfrno = mfr.mfr_mfrno LEFT OUTER JOIN "
			sqlCmdData = sqlCmdData & "mfr mfr_1 ON c4_cont.cont_mfrno = mfr_1.mfr_mfrno "
			sqlCmdData = sqlCmdData & "WHERE (ia.ia_syscd = 'C4') AND (ia.ia_iabdate = '" & IabDate & "') AND (ia.ia_iabseq = '" & IabSeq & "') "
			if (sortkey="1") then
				sqlCmdData = SqlCmdData & "ORDER BY  ia_iano"
			else if (sortkey="2") then
				sqlCmdData = SqlCmdData & "ORDER BY  cont_empno, ia_contno"
			end if
			
			' 取得資料
			rsData = oConn.Execute(sqlCmdData)
									
											
			DIM i, j
			DIM iano_pre
			DIM	idx
			iano_pre = ""
			idx = 0
			j = 0
			
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
				rowCount = strRsCount + strRsDataCount
							
				DIM A1(rowCount, 24)
				
				DIM datestr, counter
				
				iano_pre = ""
				idx = 1
				'發票總金額
				DIM	sum_invamt, sum_amt
				sum_invamt = 0
				sum_amt = 0
				counter = 0
				' 把資料填入Array中
				FOR j=0 TO rowCount STEP 1
					i = j + idx - 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' 資料區
					IF(rsData("ia_iano").Value=iano_pre)THEN
					'主檔資料只顯示一次
						A1(i, 0) = ""
						A1(i, 1) = ""
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
						A1(i, 14) = ""
						A1(i, 15) = ""
						A1(i, 18) = ""
					ELSE
						'先將小計OUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
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
							A1(i, 14) = ""
							A1(i, 15) = ""
							A1(i, 16) = ""
							A1(i, 17) = ""
							A1(i, 18) = "小計筆數：" & counter
							A1(i, 19) = ""
							A1(i, 20) = ""
							A1(i, 21) = "小計金額："
							A1(i, 22) = sum_amt
							highlight1 = "A" & (6+i) & ":P" & (6+i)
							highlight2 = "Q" & (6+i) & ":V" & (6+i)
							highlight3 = "W" & (6+i) & ":W" & (6+i)
							IF (i MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "A12", FALSE)
								XLS.FormatCells(1, highlight3, 2, "A11", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "B12", FALSE)
								XLS.FormatCells(1, highlight3, 2, "B11", FALSE)
							END IF
							sum_amt = 0
							idx = idx + 1
							counter = 0
						END IF
						i = j + idx - 1
						A1(i, 0) = idx
						iano_pre = rsData("ia_iano").Value
						A1(i, 1) = rsData("ia_iano").Value
						A1(i, 3) = rsData("ia_mfrno").Value
						A1(i, 4) = rsData("im_mfr_inm").Value
						A1(i, 5) = rsData("ia_rnm").Value & "(" & TRIM(rsData("ia_rjbti").Value) & ")"
						A1(i, 6) = rsData("ia_rzip").Value & rsData("ia_raddr").Value
						A1(i, 7) = rsData("ia_rtel").Value
						A1(i, 8) = rsData("cont_mfr_inm").Value
						IF rsData("ia_invcd").Value = "2" THEN
							A1(i, 9) = "二聯"
						ELSE IF rsData("ia_invcd").Value = "3" THEN
							A1(i, 9) = "三聯"
						ELSE IF rsData("ia_invcd").Value = "4" THEN
							A1(i, 9) = "其他"
						END IF
						
						IF rsData("ia_taxtp").Value = "1" THEN
							A1(i, 10) = "5%"
						ELSE IF rsData("ia_taxtp").Value = "2" THEN
							A1(i, 10) = "零稅"
						ELSE IF rsData("ia_taxtp").Value = "3" THEN
							A1(i, 10) = "免稅"
						END IF
						IF rsData("ia_fgitri").Value = "06" THEN
							A1(i, 11) = "所內"
						ELSE IF rsData("ia_fgitri").Value = "07" THEN
							A1(i, 11) = "院內"
						ELSE
							A1(i, 11) = "一般"
						END IF
						A1(i, 12) = rsData("iad_costctr").Value
						A1(i, 13) = rsData("iad_projno").Value
						A1(i, 14) = rsData("iad_fk1").Value
						A1(i, 15) = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value
						A1(i, 18) = rsData("ia_cname").Value
					END IF								
					A1(i, 2) = rsData("iad_iaditem").Value
					A1(i, 16) = rsData("iad_fk3").Value
					A1(i, 17) = Mid(rsData("iad_fk2").Value, 5, 2) & "/" & Mid(rsData("iad_fk2").Value, 7, 2)
					A1(i, 19) = rsData("adr_adamt").Value
					A1(i, 20) = rsData("adr_desamt").Value
					A1(i, 21) = rsData("adr_chgamt").Value
					A1(i, 22) = rsData("adr_invamt").Value
					sum_invamt = sum_invamt + rsData("adr_invamt").Value
					sum_amt = sum_amt + rsData("adr_invamt").Value
					A1(i, 23) = rsData("adr_remark").Value
					
					counter=counter+1
					'寬度欄號設定
					highlight1 = "A" & (6+i) & ":D" & (6+i)
					highlight2 = "E" & (6+i) & ":I" & (6+i)
					highlight3 = "J" & (6+i) & ":S" & (6+i)
					highlight4 = "T" & (6+i) & ":W" & (6+i)
					highlight5 = "X" & (6+i) & ":X" & (6+i)
				
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
				'最後一次小計
				i = i + 1
				A1(i, 0) = ""
				A1(i, 1) = ""
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
				A1(i, 14) = ""
				A1(i, 15) = ""
				A1(i, 16) = ""
				A1(i, 17) = ""
				A1(i, 18) = "小計筆數：" & counter
				A1(i, 19) = ""
				A1(i, 20) = ""
				A1(i, 21) = "小計金額："
				A1(i, 22) = sum_amt
				highlight1 = "A" & (6+i) & ":P" & (6+i)
				highlight2 = "Q" & (6+i) & ":V" & (6+i)
				highlight3 = "W" & (6+i) & ":W" & (6+i)
				IF (i MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "A12", FALSE)
					XLS.FormatCells(1, highlight3, 2, "A11", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
					XLS.FormatCells(1, highlight2, 2, "B12", FALSE)
					XLS.FormatCells(1, highlight3, 2, "B11", FALSE)
				END IF
				
				'A1(rowCount, 1) = sqlCmdAdrCount
				'A1(rowCount, 2) = AdrCount
				'A1(rowCount, 3) = strRsCount
				
				' 把設定Sheet藏起來
				XLS.HideSheet(2, TRUE)
				
				' 使用Array作為資料來源
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' 在Excel Speed Gen中設定變數
				XLS.AddVariable("IabDate", strIabDate)	'在Excel中用 >>$IabDate
				XLS.AddVariable("IabSeq", strIabSeq)	'在Excel中用 >>$IabSeq
				XLS.AddVariable("WHOAMI", strUser)	'在Excel中用 >>$WHOAMI
				XLS.AddVariable("TotAmt", sum_invamt)	'在Excel中用 >>$strDate
				
				' 照理不應該在這邊才做
				DIM strFilterInfo
				strFilterInfo = "符合 " & Session("FILTERINFO") & " 之資料共 " & strRsCount & " 筆"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' 範本Template
				SrcBook = Server.MapPath("RptIA_ChkList.xls")
				
				' Bind資料到Template中
				XLS.Generate(SrcBook, "RptIA_ChkList.xls", TRUE)
				
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
