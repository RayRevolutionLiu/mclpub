<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�l�H���Ʋέp��</title>
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
			DIM strMtp
			
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
			strMtp = Request("mtpcd")
						
			' �զX���j�M����
			IF (Session("MAILLABEL") <> "") THEN
				strFilter = Session("MAILLABEL")
			ELSE
				strFilter = ""
			END IF		
	
	
			' -- �]�wT-SQL Command�A���^��� --	
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT SUM(wk_c4_mail_mnt.pubmnt) AS sum_pubmnt, "
			sqlCmdData = SqlCmdData & "SUM(wk_c4_mail_mnt.unpubmnt) AS sum_unpubmnt, wk_c4_mail_mnt.contno, "
			sqlCmdData = SqlCmdData & "mfr.mfr_inm, mtp.mtp_nm, wk_c4_mail_mnt.empno, wk_c4_mail_mnt.conttp, "
			sqlCmdData = SqlCmdData & "wk_c4_mail_mnt.fgmosea, wk_c4_mail_mnt.mtpcd, wk_c4_mail_mnt.bkcd "
			sqlCmdData = SqlCmdData & "FROM wk_c4_mail_mnt INNER JOIN "
			sqlCmdData = SqlCmdData & "mfr ON wk_c4_mail_mnt.mfrno = mfr.mfr_mfrno INNER JOIN "
			sqlCmdData = SqlCmdData & "mtp ON wk_c4_mail_mnt.mtpcd = mtp.mtp_mtpcd "
			
			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = SqlCmdData & " WHERE " & strFilter
			END IF
			'�[�W�Ƨ�
			sqlCmdData = SqlCmdData & "GROUP BY  wk_c4_mail_mnt.contno, wk_c4_mail_mnt.mfrno, mfr.mfr_inm, mtp.mtp_nm, "
			sqlCmdData = SqlCmdData & "wk_c4_mail_mnt.empno, wk_c4_mail_mnt.conttp, wk_c4_mail_mnt.fgmosea, "
			sqlCmdData = SqlCmdData & "wk_c4_mail_mnt.mtpcd, wk_c4_mail_mnt.bkcd "
			sqlCmdData = SqlCmdData & "ORDER BY  wk_c4_mail_mnt.mtpcd, wk_c4_mail_mnt.contno "

		
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
			' -- �p�p���� --
			DIM strCount
			DIM preMtp
			' -- ��Ƶ��� --
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
			' -- ��ܸ�� --
			IF (rsData.EOF) THEN
			    ' �L��ƴN���T��
				Response.Write("�L�ŦX���󪺸��")
			ELSE
				' ����ƴN�}��Excel Speed Gen����
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
				' ���Ĥ@��
						
				' �]�wArray�A5�����
				DIM A1(strRsCount+strCount+2, 6)
				
				DIM i, j, idx
				DIM datestr
				preMtp = ""
				idx = 0	'����
				j = 0	'loop�ܼ�
				i = 0	'������ƪ��Ǹ�
				sum_pubmnt = 0
				sum_unpubmnt = 0
				tot_pubmnt = 0
				tot_unpubmnt = 0
				' ���ƶ�JArray��
				FOR j=0 TO strRsCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					' ��ư�
					IF (preMtp <> rsData("mtp_nm").Value) THEN
					
						'�l�H���O��e�@�����P�B���O�Ĥ@�����, �N�p�pOUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = ""
							A1(i, 3) = "�p�p�G"
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
					' �]�w���
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'�e���渹�]�w
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
				A1(i, 3) = "�p�p�G"
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
				'�̫��`�p
				A1(i, 0) = ""
				A1(i, 1) = ""
				A1(i, 2) = ""
				A1(i, 3) = "�`�p�G"
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
				XLS.AddVariable("strMtp", strMtp)	'�bExcel���� >>$strMtp
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptMailMnt.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptMailMnt.xls", TRUE)
				
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
