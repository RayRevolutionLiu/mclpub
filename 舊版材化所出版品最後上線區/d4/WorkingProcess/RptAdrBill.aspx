<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i������</title>
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
'			DIM strDate
			DIM strUser
			DIM strNOW
			
			
			' -- Excel Speed Gen ���� --
			DIM XLS
			DIM SrcBook
			
			' �]�w���
			DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
			' -- �]�w��ƨӷ��P��Ʈw --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- �]�w�����ܼ� --
			' ����������
'			strDate = Request("Today")
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
			'�o�ӬO�ª�
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
			
			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " AND " & strFilter
			END IF
			
			sqlCmdRsCount = sqlCmdRsCount & "GROUP BY  c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword "
			sqlCmdRsCount = sqlCmdRsCount & "ORDER BY c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword "
			' ����ŦX���󪺵���
			' -- �p�p���� --
			DIM strCount	
			' -- ��Ƶ��� --
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
			
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT c4_adr.*, c4_cont.cont_mfrno, mfr.mfr_inm, c4_cont.cont_empno, srspn.srspn_cname "
			sqlCmdData = SqlCmdData & "FROM c4_adr INNER JOIN "
			sqlCmdData = SqlCmdData & "c4_cont ON c4_adr.adr_syscd = c4_cont.cont_syscd AND  "
			sqlCmdData = SqlCmdData & "c4_adr.adr_contno = c4_cont.cont_contno INNER JOIN "
			sqlCmdData = SqlCmdData & "srspn ON c4_cont.cont_empno = srspn.srspn_empno INNER JOIN "
			sqlCmdData = SqlCmdData & "mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno "
			sqlCmdData = SqlCmdData & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') "


			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF

			sqlCmdData = SqlCmdData & "ORDER BY c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword, c4_adr.adr_contno "
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
			
											
			' -- ��ܸ�� --
			DIM predate, precate, prekeyword
			IF (rsData.EOF) THEN
			    ' �L��ƴN���T��
				Response.Write("�L�ŦX���󪺸��")
			ELSE
				' ����ƴN�}��Excel Speed Gen����
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' ���Ĥ@��
				rsData.MoveFirst
						
				' �]�wArray�A6�����
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
				' ���ƶ�JArray��
				FOR j=0 TO strRsCount STEP 1
					i = j + idx
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' ��ư�
					IF ((predate <> rsData("adr_addate").Value) OR (precate <> rsData("adr_adcate").Value) OR (prekeyword <> rsData("adr_keyword").Value))
						'���N�p�pOUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 3) = ""
							A1(i, 4) = ""
							A1(i, 5) = ""
							A1(i, 6) = "�p�p�G"
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
						A1(i, 5) = "����"
					ELSE IF rsData("adr_adcate").Value = "I"
						A1(i, 5) = "����"
					ELSE IF rsData("adr_adcate").Value = "N"
						A1(i, 5) = "�`��"
					ELSE
						A1(i, 5) = "(���~)"
					END IF		
														
					IF rsData("adr_keyword").Value = "h0" THEN
						A1(i, 6) = "����"
					ELSE IF rsData("adr_keyword").Value = "h1" THEN
						A1(i, 6) = "�k�@"
					ELSE IF rsData("adr_keyword").Value = "h2" THEN
						A1(i, 6) = "�k�G"
					ELSE IF rsData("adr_keyword").Value = "h3" THEN
						A1(i, 6) = "�k�T"
					ELSE IF rsData("adr_keyword").Value = "h4" THEN
						A1(i, 6) = "�k�|"
					ELSE IF rsData("adr_keyword").Value = "w1" THEN
						A1(i, 6) = "�k��@"
					ELSE IF rsData("adr_keyword").Value = "w2" THEN
						A1(i, 6) = "�k��G"
					ELSE IF rsData("adr_keyword").Value = "w3" THEN
						A1(i, 6) = "�k��T"
					ELSE IF rsData("adr_keyword").Value = "w4" THEN
						A1(i, 6) = "�k��|"
					ELSE IF rsData("adr_keyword").Value = "w5" THEN
						A1(i, 6) = "�k�夭"
					ELSE IF rsData("adr_keyword").Value = "w6" THEN
						A1(i, 6) = "�k�夻"
					ELSE
					END IF							
									
					A1(i, 7) = rsData("adr_impr").Value
					counter = counter + rsData("adr_impr").Value
					A1(i, 8) = ""
					A1(i, 9) = ""
					A1(i, 10) = ""
					IF rsData("adr_drafttp").Value = "1" THEN
						A1(i, 8) = "v"		'�½Z
					ELSE IF rsData("adr_drafttp").Value = "2" THEN
						A1(i, 9) = "v"		'�s�Z
					ELSE IF rsData("adr_drafttp").Value = "3" THEN
						A1(i, 10) = "v"		'��Z
					END IF
					A1(i, 11) = rsData("adr_imgurl").Value
					IF rsData("adr_fgimggot").Value = "1" THEN
						A1(i, 12) = "�O"
					ELSE
						A1(i, 12) = "�_"
					END IF

					A1(i, 13) = ""
					A1(i, 14) = ""
					A1(i, 15) = ""
					IF rsData("adr_urltp").Value = "1" THEN
						A1(i, 13) = "v"		'�½Z
					ELSE IF rsData("adr_urltp").Value = "2" THEN
						A1(i, 14) = "v"		'�s�Z
					ELSE IF rsData("adr_urltp").Value = "3" THEN
						A1(i, 15) = "v"		'��Z
					END IF
					A1(i, 16) = rsData("adr_navurl").Value
					IF rsData("adr_fgurlgot").Value = "1" THEN
						A1(i, 17) = "�O"
					ELSE
						A1(i, 17) = "�_"
					END IF
					
					A1(i, 18) = rsData("adr_alttext").Value
					A1(i, 19) = rsData("adr_adamt").Value
					A1(i, 20) = rsData("adr_desamt").Value
					A1(i, 21) = rsData("adr_chgamt").Value
					A1(i, 22) = RTRIM(rsData("srspn_cname").Value)
					A1(i, 23) = rsData("adr_remark").Value
					
					' �]�w���
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'�e���渹�]�w
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
					' RS����
					rsData.MoveNext
					' �w������
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				'�̫�@���p�p
				i = i + 1
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = "�p�p�G"
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
				
				
				' ��]�wSheet�ð_��
				XLS.HideSheet(2, TRUE)
				
				' �ϥ�Array�@����ƨӷ�
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' �bExcel Speed Gen���]�w�ܼ�
'				XLS.AddVariable("TODAY", strNOW)	'�bExcel���� >>$TODAY
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptAdrBill.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptAdrBill.xls", TRUE)
				
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
