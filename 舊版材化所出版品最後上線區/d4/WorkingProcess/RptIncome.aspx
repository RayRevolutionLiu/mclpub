<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i���J�έp��</title>
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
			DIM strSrspn
			
			
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
	
	
			
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT MIN(c4_adr.adr_addate) AS sdate, MAX(c4_adr.adr_addate) AS edate, "
			sqlCmdData = SqlCmdData & "c4_adr.adr_contno, COUNT(*) AS adr_count, SUM(c4_adr.adr_invamt) "
			sqlCmdData = SqlCmdData & "AS sum_invamt, SUM(c4_adr.adr_adamt) AS sum_adamt, "
			sqlCmdData = SqlCmdData & "SUM(c4_adr.adr_desamt) AS sum_desamt, SUM(c4_adr.adr_chgamt) "
			sqlCmdData = SqlCmdData & "AS sum_chgamt, mfr.mfr_inm "
			sqlCmdData = SqlCmdData & "FROM c4_adr INNER JOIN "
			sqlCmdData = SqlCmdData & "c4_cont ON c4_adr.adr_contno = c4_cont.cont_contno INNER JOIN "
			sqlCmdData = SqlCmdData & "mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno "
			sqlCmdData = SqlCmdData & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') "


			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF

			sqlCmdData = SqlCmdData & "GROUP BY  c4_adr.adr_contno, mfr.mfr_inm "
			sqlCmdData = SqlCmdData & "ORDER BY  c4_adr.adr_contno "
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
			' ����ŦX���󪺵���
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
			
			' ���Ĥ@��
			rsData.MoveFirst
											
			' -- ��ܸ�� --
			DIM predate, precate, prekeyword
			IF (rsData.EOF) THEN
			    ' �L��ƴN���T��
				Response.Write("�L�ŦX���󪺸��")
			ELSE
				' ����ƴN�}��Excel Speed Gen����
				XLS = Server.CreateObject("XLSpeedGen.ASP")
				
						
				' �]�wArray�A9�����
										
				DIM A1(strRsCount-1, 9)
				
				DIM i
				DIM datestr
				
				' ���ƶ�JArray��
				FOR i=0 TO strRsCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
					
					A1(i, 0) = i + 1
					A1(i, 1) = rsData("adr_contno").Value
					datestr = rsData("sdate").Value & "~" & rsData("edate").Value
					A1(i, 2) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
					A1(i, 3) = RTRIM(rsData("mfr_inm").Value)
									
					A1(i, 4) = rsData("sum_adamt").Value
					A1(i, 5) = rsData("sum_chgamt").Value
					A1(i, 6) = rsData("sum_desamt").Value
					A1(i, 7) = rsData("adr_count").Value
					A1(i, 8) = rsData("sum_invamt").Value
					
					
					' �]�w���
'						DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
					'�e���渹�]�w
					highlight1 = "A" & (5+i) & ":C" & (5+i)
					highlight2 = "D" & (5+i) & ":D" & (5+i)
					highlight3 = "E" & (5+i) & ":G" & (5+i)
					highlight4 = "H" & (5+i) & ":H" & (5+i)
					highlight5 = "I" & (5+i) & ":I" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A5", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B5", FALSE)
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
				XLS.AddVariable("strSrspn", strSrspn)	'�bExcel���� >>$tot_newimg
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptIncome.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptIncome.xls", TRUE)
				
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
