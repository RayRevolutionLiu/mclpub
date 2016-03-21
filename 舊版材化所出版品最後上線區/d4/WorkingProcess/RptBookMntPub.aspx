<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�L�s���Ʋέp��(��릳�Z�n)</title>
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
			DIM strConttp
			DIM strBook
			
			' -- Excel Speed Gen ���� --
			DIM XLS
			DIM SrcBook
			
			' �]�w���
			DIM highlight1, highlight2, highlight3
			' -- �]�w��ƨӷ��P��Ʈw --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- �]�w�����ܼ� --
			' ����������
			strDate = Request("strdate")
			strUser = Request("whoami")
			strSrspn = Request("cname")
			strConttp = Request("conttp")
			strBook = Request("bk")
						
			' �զX���j�M����
			IF (Session("MAILLABEL") <> "") THEN
				strFilter = Session("MAILLABEL")
			ELSE
				strFilter = ""
			END IF		
	
	
			' -- �]�wT-SQL Command�A���^��� --	
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT COUNT(*) AS pub_count, dbo.wk_c4_mail_mnt.conttp, "
			sqlCmdData = SqlCmdData & "dbo.wk_c4_mail_mnt.mtpcd, dbo.wk_c4_mail_mnt.pubmnt, dbo.mtp.mtp_nm "
			sqlCmdData = SqlCmdData & "FROM dbo.wk_c4_mail_mnt INNER JOIN "
			sqlCmdData = SqlCmdData & "dbo.mtp ON dbo.wk_c4_mail_mnt.mtpcd = dbo.mtp.mtp_mtpcd "
			sqlCmdData = SqlCmdData & "WHERE (dbo.wk_c4_mail_mnt.pubmnt > 0) "
			
			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = SqlCmdData & " AND " & strFilter
			END IF
			'�[�W�Ƨ�
			sqlCmdData = SqlCmdData & "GROUP BY  dbo.wk_c4_mail_mnt.conttp, dbo.wk_c4_mail_mnt.mtpcd, "
			sqlCmdData = SqlCmdData & "dbo.wk_c4_mail_mnt.pubmnt, dbo.mtp.mtp_nm "
			sqlCmdData = SqlCmdData & "ORDER BY  dbo.wk_c4_mail_mnt.mtpcd, dbo.wk_c4_mail_mnt.pubmnt "

		
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
				rsData.MoveFirst
			END IF
							
			DIM sum_pubmnt, count_pubmnt
			DIM preMtp
			' -- ��ܸ�� --
			IF (rsData.EOF) THEN
			    ' �L��ƴN���T��
				Response.Write("�L�ŦX���󪺸��")
			ELSE
				' ����ƴN�}��Excel Speed Gen����
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' ���Ĥ@��
						
				' �]�wArray�A5�����
				DIM A1(strRsCount+4, 6)
				
				DIM i, j, idx
				DIM datestr
				preMtp = ""
				idx = 0	'����
				j = 0	'loop�ܼ�
				i = 0	'������ƪ��Ǹ�
				sum_pubmnt = 0
				count_pubmnt = 0
				' ���ƶ�JArray��
				FOR j=0 TO strRsCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' ��ư�
					IF (preMtp <> rsData("mtpcd").Value) AND (preMtp="11") THEN
					
						'�l�H���O��e�@�����P�B���O�Ĥ@�����, �N�p�pOUTPUT
'						IF (j<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = ""
							A1(i, 3) = "�X�p�G"
							A1(i, 4) = CStr(count_pubmnt) & "��"
							A1(i, 5) = CStr(sum_pubmnt) & "��"
							highlight1 = "A" & (7+i) & ":F" & (7+i)
							IF (i MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A11", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B11", FALSE)
							END IF
							i = i + 2
							sum_pubmnt = 0
							count_pubmnt = 0
							A1(i, 0) = "���o�Ǹg��"	
'						END IF
						
					END IF
					IF j=0 THEN
						A1(i, 0) = "�j�v�l�H"
					END IF

					IF (rsData("conttp").Value = "01") THEN
						A1(i, 1) = "�@��"
					ELSE IF (rsData("conttp").Value = "09") THEN
						A1(i, 1) = "���s"
					END IF
					A1(i, 2) = rsData("mtp_nm").Value
					A1(i, 3) = rsData("pubmnt").Value & "x"
					A1(i, 4) = rsData("pub_count").Value & "��="
					count_pubmnt = count_pubmnt + rsData("pub_count").Value
					A1(i, 5) = rsData("pubmnt").Value * rsData("pub_count").Value & "��"
					sum_pubmnt = sum_pubmnt + rsData("pubmnt").Value * rsData("pub_count").Value
					preMtp = rsData("mtpcd").Value									
					' �]�w���
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'�e���渹�]�w
					highlight1 = "A" & (7+i) & ":C" & (7+i)
					highlight2 = "D" & (7+i) & ":F" & (7+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A8", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B8", FALSE)
					END IF
					' RS����
					i = i + 1
					rsData.MoveNext
					' �w������
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				'�̫�@���p�p
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 2) = ""
				A1(i, 3) = "�X�p�G"
				A1(i, 4) = CStr(count_pubmnt) & "��"
				A1(i, 5) = CStr(sum_pubmnt) & "��"
				highlight1 = "A" & (7+i) & ":F" & (7+i)
				IF (i MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A11", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B11", FALSE)
				END IF
				'�̫��`�p
				
				' ��]�wSheet�ð_��
				XLS.HideSheet(2, TRUE)
				
				' �ϥ�Array�@����ƨӷ�
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' �bExcel Speed Gen���]�w�ܼ�
				XLS.AddVariable("strDate", strDate)	'�bExcel���� >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
				XLS.AddVariable("strSrspn", strSrspn)	'�bExcel���� >>$strSrspn
				XLS.AddVariable("strBook", strBook)	'�bExcel���� >>$strBook
				XLS.AddVariable("strConttp", strConttp)	'�bExcel���� >>$strConttp
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptBookMntPub.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptBookMntPub.xls", TRUE)
				
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
