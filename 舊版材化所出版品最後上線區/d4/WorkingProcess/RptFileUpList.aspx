<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���s�W�Z�M���</title>
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
			DIM strSrspn
			
			
			' -- Excel Speed Gen ���� --
			DIM XLS
			DIM SrcBook
			
			' �]�w���
			DIM highlight1, highlight2
			' -- �]�w��ƨӷ��P��Ʈw --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- �]�w�����ܼ� --
			' ����������
			strDate = Request("strdate")
			strUser = Request("whoami")
			strSrspn = Request("cname")
			
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
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) AS adr_count, SUM(c4_adr.adr_impr) AS sum_impr, "
			sqlCmdRsCount = sqlCmdRsCount & "c4_adr.adr_addate, c4_adr.adr_adcate "
			sqlCmdRsCount = sqlCmdRsCount & "FROM c4_adr INNER JOIN "
			sqlCmdRsCount = sqlCmdRsCount & "c4_cont ON c4_adr.adr_contno = c4_cont.cont_contno "
			
			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " WHERE " & strFilter
			END IF
			'�[�W�Ƨ�
			sqlCmdRsCount = sqlCmdRsCount & "GROUP BY  c4_adr.adr_addate, c4_adr.adr_adcate "
			sqlCmdRsCount = sqlCmdRsCount & "ORDER BY  c4_adr.adr_addate, c4_adr.adr_adcate DESC "
			' ����ŦX���󪺵���
			' -- �p�p���� --
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
			
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT COUNT(*) AS adr_count, SUM(c4_adr.adr_impr) AS sum_impr, "
			sqlCmdData = SqlCmdData & "c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword "
			sqlCmdData = SqlCmdData & "FROM c4_adr INNER JOIN "
			sqlCmdData = SqlCmdData & "c4_cont ON c4_adr.adr_contno = c4_cont.cont_contno "

			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " WHERE " & strFilter
			END IF

			'�[�W�Ƨ�
			sqlCmdData = SqlCmdData & "GROUP BY  c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword "
			sqlCmdData = SqlCmdData & "ORDER BY  c4_adr.adr_addate, c4_adr.adr_adcate DESC, c4_adr.adr_keyword "
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
			' -- ��Ƶ��� --
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
											
			' -- ��ܸ�� --
			DIM precate, predate
			rsData.MoveFirst
			rsCount.MoveFirst
			IF (rsData.EOF) THEN
			    ' �L��ƴN���T��
				Response.Write("�L�ŦX���󪺸��")
			ELSE
				' ����ƴN�}��Excel Speed Gen����
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' ���Ĥ@��
						
				' �]�wArray�A5�����
				DIM A1(strRsCount+strCount, 5)
				
				DIM i, j, idx
				DIM datestr
				precate = ""
				predate = ""
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
					IF (precate <> rsData("adr_adcate").Value) THEN
					
						'�X���s����e�@�����P�B���O�Ĥ@�����, �N�p�pOUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = "�p�p�G"
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
							A1(i, 2) = "�p�p�G"
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
						A1(i, 1) = "����"
					ELSE IF rsData("adr_adcate").Value = "I"
						A1(i, 1) = "����"
					ELSE IF rsData("adr_adcate").Value = "N"
						A1(i, 1) = "�`��"
					ELSE
						A1(i, 1) = "(���~)"
					END IF		
														
					IF rsData("adr_keyword").Value = "h0" THEN
						A1(i, 2) = "����"
					ELSE IF rsData("adr_keyword").Value = "h1" THEN
						A1(i, 2) = "�k�@"
					ELSE IF rsData("adr_keyword").Value = "h2" THEN
						A1(i, 2) = "�k�G"
					ELSE IF rsData("adr_keyword").Value = "h3" THEN
						A1(i, 2) = "�k�T"
					ELSE IF rsData("adr_keyword").Value = "h4" THEN
						A1(i, 2) = "�k�|"
					ELSE IF rsData("adr_keyword").Value = "w1" THEN
						A1(i, 2) = "�k��@"
					ELSE IF rsData("adr_keyword").Value = "w2" THEN
						A1(i, 2) = "�k��G"
					ELSE IF rsData("adr_keyword").Value = "w3" THEN
						A1(i, 2) = "�k��T"
					ELSE IF rsData("adr_keyword").Value = "w4" THEN
						A1(i, 2) = "�k��|"
					ELSE IF rsData("adr_keyword").Value = "w5" THEN
						A1(i, 2) = "�k�夭"
					ELSE IF rsData("adr_keyword").Value = "w6" THEN
						A1(i, 2) = "�k�夻"
					ELSE
					END IF							
					A1(i, 3) = rsData("adr_count").Value
					A1(i, 4) = rsData("sum_impr").Value
									
					precate = rsData("adr_adcate").Value					
					predate = rsData("adr_addate").Value					
					
					' �]�w���
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'�e���渹�]�w
					highlight1 = "A" & (6+i) & ":C" & (6+i)
					highlight2 = "D" & (6+i) & ":E" & (6+i)
				
					IF (idx MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
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
				A1(i, 2) = "�p�p�G"
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
				'�̫��`�p
				
				' ��]�wSheet�ð_��
				XLS.HideSheet(2, TRUE)
				
				' �ϥ�Array�@����ƨӷ�
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' �bExcel Speed Gen���]�w�ܼ�
				XLS.AddVariable("strDate", strDate)	'�bExcel���� >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
				XLS.AddVariable("strSrspn", strSrspn)	'�bExcel���� >>$tot_newimg
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptFileUpList.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptFileUpList.xls", TRUE)
				
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
