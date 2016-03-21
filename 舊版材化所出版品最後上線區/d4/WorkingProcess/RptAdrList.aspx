<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ͼs�i�����έp��</title>
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
			'����{���}�l
			'------------
				
			' -- ��Ʈw�P��ƨӷ��]�w --
			DIM dbFile
			DIM oConn
			DIM DSN
			
			' -- �x�s��ƪ�RecordSet --
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
			
			' -- �����ܼ� --
			DIM strDate
			DIM strUser
			DIM strNOW
			
			' -- ��Ƶ��� --
			DIM strRsCount
			
			' -- Excel Speed Gen ���� --
			DIM XLS
			DIM SrcBook
			
			' -- �]�w��ƨӷ��P��Ʈw --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- �]�w�����ܼ� --
			' ����������
			strDate = Request("strdate")
			strUser = Request("whoami")
			
			' �p�G���`�A�N�i�H�ϥ�
			IF (Request("Whoami") <> "") THEN
				strUser = Request("Whoami")
			ELSE
			' ���M�N���Ŧr��
				strUser = ""
			END IF
			
			' �զX���j�M����
			IF (Session("RPTADRLIST") <> "") THEN
				strFilter = Session("RPTADRLIST")
			ELSE
				strFilter = ""
			END IF		

			' -- �]�wT-SQL Command�A���^��� --	
			' �զX���o��Ƶ��ƪ�T-SQL Command
			sqlCmdRsCount = ""
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) "
			sqlCmdRsCount = sqlCmdRsCount & "FROM wk_c4_adrlist "
			sqlCmdRsCount = sqlCmdRsCount & "WHERE adr_sdate <> ''"
			
			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " AND " & strFilter
			END IF
			
			' ����ŦX���󪺵���
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strRsCount = 0
			ELSE
				strRsCount = rsCount(0).Value
			END IF
			
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT wk_c4_adrlist.*, srspn.srspn_cname, v_c4_sum_adr_amt.sum_invamt "
			sqlCmdData = SqlCmdData & "FROM wk_c4_adrlist LEFT OUTER JOIN "
			sqlCmdData = SqlCmdData & "v_c4_sum_adr_amt ON "
			sqlCmdData = SqlCmdData & "wk_c4_adrlist.cont_contno = v_c4_sum_adr_amt.adr_contno LEFT OUTER JOIN "
			sqlCmdData = SqlCmdData & "srspn ON "
			sqlCmdData = SqlCmdData & "wk_c4_adrlist.cont_empno COLLATE Chinese_Taiwan_Stroke_CI_AS = srspn.srspn_empno "
			sqlCmdData = SqlCmdData & "WHERE adr_sdate <> ''"

			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF
			sqlCmdData = SqlCmdData & "ORDER BY cont_contno, adr_seq "
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
						
			DIM sqlCmdIa, sqlCmdPy, sqlCmdPub
			DIM rsIa, rsPy, rsPub
			DIM pre_contno, contno
			
			' -- ��ܸ�� --
			IF (rsData.EOF) THEN
			    ' �L��ƴN���T��
				Response.Write("�L�ŦX���󪺸��")
			ELSE
				' ����ƴN�}��Excel Speed Gen����
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' ���ܲĤ@��
				rsData.MoveFirst
						
				' �]�wArray�A28�����
				DIM A1(strRsCount, 28)
							
				DIM i, idx
				DIM datestr
				DIM	edate, sdate
				sdate = Mid(strDate, 1, 4) & Mid(strDate, 6, 2) & Mid(strDate, 9, 2)
				edate = Mid(strDate, 12, 4) & Mid(strDate, 17, 2) & Mid(strDate, 20, 2)
				idx = 0
				pre_contno = ""
				' ���ƶ�JArray��
				FOR i=0 TO strRsCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' ��ư�
					contno = rsData("cont_contno").Value
					IF (pre_contno <> contno) THEN
						idx = idx + 1
						A1(i, 0) = idx
						A1(i, 1) = rsData("cont_contno").Value
						A1(i, 3) = rsData("mfr_inm").Value
						A1(i, 11) = rsData("cont_pubtm").Value
						'���o�w�����`����
						sqlCmdPub = "SELECT COUNT(*) AS pubedtm FROM c4_adr WHERE adr_contno = '"& contno &"' "
						rsPub = oConn.Execute(sqlCmdPub)
						IF (rsPub.EOF) THEN
							A1(i, 12) = 0
							A1(i, 13) = rsData("cont_pubtm").Value
						ELSE
							A1(i, 12) = rsPub("pubedtm").Value
							A1(i, 13) = rsData("cont_pubtm").Value - rsPub("pubedtm").Value
						END IF
'						A1(i, 12) = rsData("cont_pubtm").Value - rsData("cont_resttm").Value
'						A1(i, 13) = rsData("cont_resttm").Value
						A1(i, 14) = rsData("cont_freetm").Value
						A1(i, 15) = rsData("cont_totimgtm").Value
						A1(i, 16) = rsData("res_drafttp").Value
						A1(i, 17) = rsData("cont_toturltm").Value
						A1(i, 18) = rsData("res_urltp").Value
						A1(i, 22) = rsData("sum_invamt").Value
						A1(i, 23) = rsData("cont_totamt").Value
						'���o�w��SAP���o���`���B
						sqlCmdIa = "SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia "
						sqlCmdIa = sqlCmdIa & "WHERE (ia_syscd = 'C4') "
						sqlCmdIa = sqlCmdIa & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
						sqlCmdIa = sqlCmdIa & "AND (ia_status = '7') GROUP BY  ia_contno"
						rsIa = oConn.Execute(sqlCmdIa)
						IF (rsIa.EOF) THEN
							A1(i, 24) = 0
						ELSE
							A1(i, 24) = rsIa("sum_ia").Value
						END IF
						'���o�wú�ڤ��`���B
						sqlCmdPy = "SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia "
						sqlCmdPy = sqlCmdPy & "WHERE (ia_syscd = 'C4') "
						sqlCmdPy = sqlCmdPy & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
						sqlCmdPy = sqlCmdPy & "AND (ia.ia_pyno <> '') GROUP BY  ia_contno"
						rsPy = oConn.Execute(sqlCmdPy)
						IF (rsPy.EOF) THEN
							A1(i, 25) = 0
						ELSE
							A1(i, 25) = rsPy("sum_py").Value
						END IF
					END IF
					A1(i, 2) = rsData("adr_seq").Value
					datestr = rsData("adr_sdate").Value
					A1(i, 4) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3)
					datestr = rsData("adr_edate").Value	
					A1(i, 5) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3)
					A1(i, 6) = rsData("adr_adcate_M").Value
					A1(i, 7) = rsData("adr_adcate_I").Value
					A1(i, 8) = rsData("adr_adcate_N").Value
					A1(i, 9) = rsData("tot_adr_addays").Value
					IF rsData("adr_fgfixad").Value = "0" THEN
						A1(i, 10) = "����"
					ELSE
						A1(i, 10) = "�w��"
					END IF
					A1(i, 19) = rsData("sum_adamt").Value
					A1(i, 20) = rsData("sum_desamt").Value
					A1(i, 21) = rsData("sum_chgamt").Value
					'�~�ȭ��m�W
					A1(i, 26) = rsData("srspn_cname").Value
					A1(i, 27) = rsData("cont_remark").Value
					'�N�e�@���X���s���O��
					pre_contno = contno
								
					' �]�w���
					DIM highlight1, highlight2, highlight3, highlight4, highlight5
					'�e���渹�]�w
					highlight1 = "A" & (5+i) & ":C" & (5+i)
					highlight2 = "D" & (5+i) & ":F" & (5+i)
					highlight3 = "G" & (5+i) & ":S" & (5+i)
					highlight4 = "T" & (5+i) & ":Z" & (5+i)
					highlight5 = "AA" & (5+i) & ":AB" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A8", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A1", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B8", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B1", FALSE)
					END IF
					
					
					' RS����
					rsData.MoveNext
					
					' �w������
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				
				
				' ��]�wSheet�ð_��
				XLS.HideSheet(2, TRUE)
				
				' �ϥ�Array�@����ƨӷ�
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' �bExcel Speed Gen���]�w�ܼ�
				XLS.AddVariable("strDate", strDate)	'�bExcel���� >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptAdrList.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptAdrList.xls", TRUE)
				
				' �귽����
				XLS = NOTHING
				
				oConn.Close
				oConn = NOTHING
				' ����Excel Speed Gen�]�w
			END IF				
				
			%>
		</form>
	</body>
</HTML>
