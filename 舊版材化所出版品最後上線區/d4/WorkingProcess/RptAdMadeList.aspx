<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�s�Z�έp��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptAdMadeList" method="post" runat="server">
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
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) AS adrcount, adr_contno "
			sqlCmdRsCount = sqlCmdRsCount & "FROM v_c4_admadelist "
			
			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdRsCount = sqlCmdRsCount & " WHERE " & strFilter
			END IF
			'�[�W�Ƨ�
			sqlCmdRsCount = sqlCmdRsCount & "GROUP BY  adr_contno "
			sqlCmdRsCount = sqlCmdRsCount & "ORDER BY  adr_contno "
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
			sqlCmdData = SqlCmdData & "SELECT * FROM v_c4_admadelist "

			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " WHERE " & strFilter
			END IF

			'�[�W�Ƨ�
			sqlCmdData = sqlCmdData & " ORDER BY v_c4_admadelist.adr_contno, v_c4_admadelist.adr_addate, v_c4_admadelist.adr_seq"
			
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
				DIM A1(strRsCount+strCount, 17)
				
				DIM i, j, idx
				DIM datestr
				DIM counter, sum_newimg, sum_chgimg, sum_newurl, sum_chgurl
				DIM tot_newimg, tot_chgimg, tot_newurl, tot_chgurl
				precontno = ""
				counter = 0
				sum_newimg = 0
				sum_chgimg = 0
				sum_newurl = 0
				sum_chgurl = 0
				tot_newimg = 0
				tot_chgimg = 0
				tot_newurl = 0
				tot_chgurl = 0
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
					IF (precontno <> rsData("adr_contno").Value) THEN
					
						'�X���s����e�@�����P�B���O�Ĥ@�����, �N�p�pOUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 3) = ""
							A1(i, 4) = ""
							A1(i, 5) = ""
							A1(i, 6) = ""
							A1(i, 7) = counter & " ������  �p�p�G"
							A1(i, 8) = sum_newimg
							A1(i, 9) = sum_chgimg
							A1(i, 10) = ""
							A1(i, 11) = ""
							A1(i, 12) = sum_newurl
							A1(i, 13) = sum_chgurl
							highlight1 = "A" & (5+i) & ":D" & (5+i)
							highlight2 = "E" & (5+i) & ":H" & (5+i)
							highlight3 = "I" & (5+i) & ":N" & (5+i)
							highlight4 = "O" & (5+i) & ":Q" & (5+i)
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
							tot_newimg = tot_newimg + sum_newimg
							tot_chgimg = tot_chgimg + sum_chgimg
							tot_newurl = tot_newurl + sum_newurl
							tot_chgurl = tot_chgurl + sum_chgurl
							sum_newimg = 0
							sum_chgimg = 0
							sum_newurl = 0
							sum_chgurl = 0
							counter = 0
							idx = idx + 1
							i = j + idx
						END IF
						'�����ƥX�{�����
						A1(i, 0) = idx + 1
						A1(i, 1) = rsData("adr_contno").Value
						A1(i, 3) = RTRIM(rsData("mfr_inm").Value)
						A1(i, 16) = rsData("srspn_cname").Value
					END IF
					A1(i, 2) = rsData("adr_seq").Value
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
					IF rsData("adr_drafttp").Value = "2" THEN
						A1(i, 8) = "v"
						sum_newimg = sum_newimg + 1
					ELSE IF rsData("adr_drafttp").Value = "3" THEN
						A1(i, 9) = "v"
						sum_chgimg = sum_chgimg + 1
					END IF
					A1(i, 10) = rsData("adr_imgurl").Value
					IF rsData("adr_fgimggot").Value = "1" THEN
						A1(i, 11) = "�O"
					ELSE
						A1(i, 11) = "�_"
					END IF
					IF rsData("adr_urltp").Value = "2" THEN
						A1(i, 12) = "v"
						sum_newurl = sum_newurl + 1
					ELSE IF rsData("adr_urltp").Value = "3" THEN
						A1(i, 13) = "v"
						sum_chgurl = sum_chgurl + 1
					END IF
					A1(i, 14) = rsData("adr_navurl").Value
					IF rsData("adr_fgurlgot").Value = "1" THEN
						A1(i, 15) = "�O"
					ELSE
						A1(i, 15) = "�_"
					END IF
					precontno = rsData("adr_contno").Value					
					counter = counter + 1
					
					' �]�w���
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'�e���渹�]�w
					highlight1 = "A" & (5+i) & ":C" & (5+i)
					highlight2 = "D" & (5+i) & ":D" & (5+i)
					highlight3 = "E" & (5+i) & ":J" & (5+i)
					highlight4 = "K" & (5+i) & ":K" & (5+i)
					highlight5 = "L" & (5+i) & ":N" & (5+i)
					highlight6 = "O" & (5+i) & ":O" & (5+i)
					highlight7 = "P" & (5+i) & ":Q" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight7, 2, "A2", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight7, 2, "B2", FALSE)
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
				A1(i, 7) = counter & " ������  �p�p�G"
				A1(i, 8) = sum_newimg
				A1(i, 9) = sum_chgimg
				A1(i, 10) = ""
				A1(i, 11) = ""
				A1(i, 12) = sum_newurl
				A1(i, 13) = sum_chgurl
				highlight1 = "A" & (5+i) & ":D" & (5+i)
				highlight2 = "E" & (5+i) & ":H" & (5+i)
				highlight3 = "I" & (5+i) & ":N" & (5+i)
				highlight4 = "O" & (5+i) & ":Q" & (5+i)
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
				tot_newimg = tot_newimg + sum_newimg
				tot_chgimg = tot_chgimg + sum_chgimg
				tot_newurl = tot_newurl + sum_newurl
				tot_chgurl = tot_chgurl + sum_chgurl
				'�̫��`�p
				
				' ��]�wSheet�ð_��
				XLS.HideSheet(2, TRUE)
				
				' �ϥ�Array�@����ƨӷ�
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' �bExcel Speed Gen���]�w�ܼ�
				XLS.AddVariable("strDate", strDate)	'�bExcel���� >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
				XLS.AddVariable("tot_newimg", tot_newimg)	'�bExcel���� >>$tot_newimg
				XLS.AddVariable("tot_chgimg", tot_chgimg)	'�bExcel���� >>$tot_chgimg
				XLS.AddVariable("tot_newurl", tot_newurl)	'�bExcel���� >>$tot_newurl
				XLS.AddVariable("tot_chgurl", tot_chgurl)	'�bExcel���� >>$tot_chgurl
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptAdMadeList.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptAdMadeList.xls", TRUE)
				
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
