<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�O���ˬd�M��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptAdAmtList" method="post" runat="server">
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
			'DIM strDate
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
			'strDate = Request("datestr")
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
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) AS adrcount, cont_contno "
			sqlCmdRsCount = sqlCmdRsCount & "FROM v_c4_adamtlist "
			
			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " WHERE " & strFilter
			END IF
			'�[�W�Ƨ�
			sqlCmdRsCount = sqlCmdRsCount & "GROUP BY  cont_contno "
			sqlCmdRsCount = sqlCmdRsCount & "ORDER BY  cont_contno "
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
				strCount = 0
				Do while not rsCount.EOF
					strRsCount = strRsCount + rsCount("adrcount").Value
					strCount = strCount + 1
					rsCount.MoveNext
				Loop
			END IF
			
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT v_c4_adamtlist.cont_contno, v_c4_adamtlist.adr_seq, "
			sqlCmdData = SqlCmdData & "v_c4_adamtlist.mfr_mfrno, v_c4_adamtlist.mfr_inm, v_c4_adamtlist.mfr_iaddr, "
			sqlCmdData = SqlCmdData & "v_c4_adamtlist.adr_addate, v_c4_adamtlist.adr_adcate, "
			sqlCmdData = SqlCmdData & "v_c4_adamtlist.adr_keyword, v_c4_adamtlist.adr_impr, "
			sqlCmdData = SqlCmdData & "v_c4_adamtlist.adr_invamt, v_c4_adamtlist.adr_adamt, "
			sqlCmdData = SqlCmdData & "v_c4_adamtlist.adr_desamt, v_c4_adamtlist.adr_chgamt, "
			sqlCmdData = SqlCmdData & "v_c4_adamtlist.adr_fginved, ISNULL(v_c4_adamtlist.ia_invno, '') AS invno, "
			sqlCmdData = SqlCmdData & "ISNULL(v_c4_adamtlist.ia_iano, '') AS iano, srspn.srspn_cname "
			sqlCmdData = SqlCmdData & "FROM v_c4_adamtlist INNER JOIN "
			sqlCmdData = SqlCmdData & "srspn ON v_c4_adamtlist.cont_empno = srspn.srspn_empno "

			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " WHERE " & strFilter
			END IF

			'�[�W�Ƨ�
			sqlCmdData = sqlCmdData & " ORDER BY v_c4_adamtlist.cont_contno, v_c4_adamtlist.adr_addate, v_c4_adamtlist.adr_seq"
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
			Response.Write(strRsCount+strCount)
											
			' -- ��ܸ�� --
			DIM precontno
			IF (rsData.EOF) THEN
			    ' �L��ƴN���T��
				Response.Write("�L�ŦX���󪺸��")
			ELSE
				' ����ƴN�}��Excel Speed Gen����
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' ���Ĥ@��
				rsData.MoveFirst
						
				' �]�wArray�A18�����
				DIM A1(strRsCount+strCount+2, 18)
'				DIM A1(1050, 18)
				
				DIM i, j, idx
				DIM datestr
				DIM counter, sum_adamt, sum_desamt, sum_chgamt, sum_invamt
				DIM tot_adamt, tot_desamt, tot_chgamt, tot_invamt
				precontno = ""
				counter = 0
				sum_adamt = 0
				sum_desamt = 0
				sum_chgamt = 0
				sum_invamt = 0
				tot_adamt = 0
				tot_desamt = 0
				tot_chgamt = 0
				tot_invamt = 0
				idx = 0	'����
				j = 0	'loop�ܼ�
				i = 0	'������ƪ��Ǹ�
				' ���ƶ�JArray��
				FOR j=0 TO strRsCount STEP 1
					i = j + idx
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' ��ư�
					IF (precontno <> rsData("cont_contno").Value) THEN
					
						'�X���s����e�@�����P�B���O�Ĥ@�����, �N�p�pOUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 3) = ""
							A1(i, 4) = ""
							A1(i, 5) = ""
							A1(i, 6) = ""
							A1(i, 7) = ""
							A1(i, 8) = counter & " ������  �p�p�G"
							A1(i, 9) = ""
							A1(i, 10) = sum_adamt
							A1(i, 11) = sum_desamt
							A1(i, 12) = sum_chgamt
							A1(i, 13) = sum_invamt
							highlight1 = "A" & (5+i) & ":F" & (5+i)
							highlight2 = "G" & (5+i) & ":J" & (5+i)
							highlight3 = "K" & (5+i) & ":N" & (5+i)
							highlight4 = "O" & (5+i) & ":R" & (5+i)
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
							tot_adamt = tot_adamt + sum_adamt
							tot_desamt = tot_desamt + sum_desamt
							tot_chgamt = tot_chgamt + sum_chgamt
							tot_invamt = tot_invamt + sum_invamt
							sum_adamt = 0
							sum_desamt = 0
							sum_chgamt = 0
							sum_invamt = 0
							counter = 0
							idx = idx + 1
							i = j + idx
						END IF
						'�����ƥX�{�����
						A1(i, 0) = idx + 1
						A1(i, 1) = rsData("cont_contno").Value
						A1(i, 3) = rsData("mfr_mfrno").Value
						A1(i, 4) = RTRIM(rsData("mfr_inm").Value)
						A1(i, 5) = RTRIM(rsData("mfr_iaddr").Value)
						A1(i, 17) = rsData("srspn_cname").Value
					END IF
					A1(i, 2) = rsData("adr_seq").Value
					datestr = rsData("adr_addate").Value 	
					A1(i, 6) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 2)
					IF rsData("adr_adcate").Value = "M" THEN
						A1(i, 7) = "����"
					ELSE IF rsData("adr_adcate").Value = "I"
						A1(i, 7) = "����"
					ELSE IF rsData("adr_adcate").Value = "N"
						A1(i, 7) = "�`��"
					ELSE
						A1(i, 7) = "(���~)"
					END IF		
														
					IF rsData("adr_keyword").Value = "h0" THEN
						A1(i, 8) = "����"
					ELSE IF rsData("adr_keyword").Value = "h1" THEN
						A1(i, 8) = "�k�@"
					ELSE IF rsData("adr_keyword").Value = "h2" THEN
						A1(i, 8) = "�k�G"
					ELSE IF rsData("adr_keyword").Value = "h3" THEN
						A1(i, 8) = "�k�T"
					ELSE IF rsData("adr_keyword").Value = "h4" THEN
						A1(i, 8) = "�k�|"
					ELSE IF rsData("adr_keyword").Value = "w1" THEN
						A1(i, 8) = "�k��@"
					ELSE IF rsData("adr_keyword").Value = "w2" THEN
						A1(i, 8) = "�k��G"
					ELSE IF rsData("adr_keyword").Value = "w3" THEN
						A1(i, 8) = "�k��T"
					ELSE IF rsData("adr_keyword").Value = "w4" THEN
						A1(i, 8) = "�k��|"
					ELSE IF rsData("adr_keyword").Value = "w5" THEN
						A1(i, 8) = "�k�夭"
					ELSE IF rsData("adr_keyword").Value = "w6" THEN
						A1(i, 8) = "�k�夻"
					ELSE
					END IF							
									
					A1(i, 9) = rsData("adr_impr").Value
					A1(i, 10) = rsData("adr_adamt").Value
					sum_adamt = sum_adamt + rsData("adr_adamt").Value
					A1(i, 11) = rsData("adr_desamt").Value
					sum_desamt = sum_desamt + rsData("adr_desamt").Value
					A1(i, 12) = rsData("adr_chgamt").Value
					sum_chgamt = sum_chgamt + rsData("adr_chgamt").Value
					A1(i, 13) = rsData("adr_invamt").Value
					sum_invamt = sum_invamt + rsData("adr_invamt").Value

					IF rsData("adr_fginved").Value = "1" THEN
						A1(i, 14) = "v"		'�w�}�o��
					ELSE
						A1(i, 14) = ""
					END IF
					
					A1(i, 15) = rsData("invno").Value
					A1(i, 16) = rsData("iano").Value
					precontno = rsData("cont_contno").Value					
					counter = counter + 1
					
					' �]�w���
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'�e���渹�]�w
					highlight1 = "A" & (5+i) & ":D" & (5+i)
					highlight2 = "E" & (5+i) & ":F" & (5+i)
					highlight3 = "G" & (5+i) & ":J" & (5+i)
					highlight4 = "K" & (5+i) & ":N" & (5+i)
					highlight5 = "O" & (5+i) & ":R" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B2", FALSE)
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
				A1(i, 6) = ""
				A1(i, 7) = ""
				A1(i, 8) = counter & " ������  �p�p�G"
				A1(i, 9) = ""
				A1(i, 10) = sum_adamt
				A1(i, 11) = sum_desamt
				A1(i, 12) = sum_chgamt
				A1(i, 13) = sum_invamt
				highlight1 = "A" & (5+i) & ":F" & (5+i)
				highlight2 = "G" & (5+i) & ":J" & (5+i)
				highlight3 = "K" & (5+i) & ":N" & (5+i)
				highlight4 = "O" & (5+i) & ":R" & (5+i)
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
				tot_adamt = tot_adamt + sum_adamt
				tot_desamt = tot_desamt + sum_desamt
				tot_chgamt = tot_chgamt + sum_chgamt
				tot_invamt = tot_invamt + sum_invamt
				'�̫��`�p
				i = i + 2
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = ""
				A1(i, 7) = ""
				A1(i, 8) = "�`�p�G"
				A1(i, 9) = ""
				A1(i, 10) = tot_adamt
				A1(i, 11) = tot_desamt
				A1(i, 12) = tot_chgamt
				A1(i, 13) = tot_invamt
				highlight1 = "A" & (5+i) & ":R" & (5+i)
				XLS.FormatCells(1, highlight1, 2, "A17", FALSE)
				
				' ��]�wSheet�ð_��
				XLS.HideSheet(2, TRUE)
				
				' �ϥ�Array�@����ƨӷ�
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' �bExcel Speed Gen���]�w�ܼ�
				'XLS.AddVariable("strDate", strDate)	'�bExcel���� >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptAdAmtList.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptAdAmtList.xls", TRUE)
				
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
