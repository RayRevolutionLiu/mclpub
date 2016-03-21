<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�C�L�ʽZ��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptGetAdList" method="post" runat="server">
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
			

			' -- �]�wT-SQL Command�A���^��� --	
			' �զX���o��Ƶ��ƪ�T-SQL Command
			sqlCmdRsCount = ""
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) "
			sqlCmdRsCount = sqlCmdRsCount & "FROM wk_c4_getad "
			
			'�[�WWhere����			
'			IF (strFilter <> "") THEN
'				sqlCmdRsCount = sqlCmdRsCount & " AND " & strFilter
'			END IF
			
			' ����ŦX���󪺵���
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strRsCount = 0
			ELSE
				strRsCount = rsCount(0).Value
			END IF
			
			' �զX���o��ƪ�T-SQL Command

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT * from wk_c4_getad "
			sqlCmdData = SqlCmdData & "ORDER BY  cont_fgout DESC, cont_contno, adr_addate "


			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
						
			' -- ���o���u��� --
			DIM rsEmp
			DIM sqlCmdEmp
			
			sqlCmdEmp = sqlCmdEmp & "SELECT srspn_empno, srspn_cname FROM srspn"	
			rsEmp = oConn.Execute(sqlCmdEmp)
			
											
			DIM sqlCmdIa, sqlCmdPy
			DIM rsIa, rsPy
			DIM contno
			
			' -- ��ܸ�� --
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
				
				' �]�w�C�ơA+5�O�B�~��
				DIM rowCount
				rowCount = strRsCount+ 5
							
				DIM A1(rowCount, 21)
				
				DIM i
				DIM datestr
				DIM	edate, sdate
				sdate = Mid(strDate, 1, 4) & Mid(strDate, 6, 2) & Mid(strDate, 9, 2)
				edate = Mid(strDate, 12, 4) & Mid(strDate, 17, 2) & Mid(strDate, 20, 2)
				
				' ���ƶ�JArray��
				FOR i=0 TO rowCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' ��ư�
					A1(i, 0) = i+1
					A1(i, 1) = ""
					IF (rsData("cont_edate").Value<=edate) AND (rsData("cont_edate").Value>=sdate) THEN
						A1(i, 1) = "*"
					END IF
					A1(i, 2) = rsData("cont_contno").Value
					A1(i, 3) = rsData("cont_aunm").Value
					A1(i, 4) = rsData("mfr_inm").Value
					A1(i, 5) = rsData("cont_autel").Value
					A1(i, 6) = rsData("cont_aufax").Value
					A1(i, 7) = rsData("cont_aucell").Value
					datestr = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value	
					A1(i, 8) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
					IF TRIM(rsData("adr_sdate").Value) = "" THEN
						A1(i, 9) = ""
					ELSE
						datestr = rsData("adr_sdate").Value & "~" & rsData("adr_edate").Value
						A1(i, 9) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
					END IF
					A1(i, 10) = rsData("tot_adr_addays").Value
					A1(i, 11) = rsData("cont_pubtm").Value
					A1(i, 12) = rsData("cont_freetm").Value
					A1(i, 13) = rsData("cont_totimgtm").Value
					A1(i, 14) = rsData("res_drafttp").Value
					A1(i, 15) = rsData("cont_toturltm").Value
					A1(i, 16) = rsData("res_urltp").Value
					A1(i, 17) = rsData("cont_totamt").Value
					contno = rsData("cont_contno").Value
					'���o�wú�ڤ��`���B
					sqlCmdPy = "SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia "
					sqlCmdPy = sqlCmdPy & "WHERE (ia_syscd = 'C4') "
					sqlCmdPy = sqlCmdPy & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
					sqlCmdPy = sqlCmdPy & "AND (ia.ia_pyno <> '') GROUP BY  ia_contno"
					rsPy = oConn.Execute(sqlCmdPy)
					'���o�w��SAP���o���`���B
					sqlCmdIa = "SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia "
					sqlCmdIa = sqlCmdIa & "WHERE (ia_syscd = 'C4') "
					sqlCmdIa = sqlCmdIa & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
					sqlCmdIa = sqlCmdIa & "AND (ia_status = '7') GROUP BY  ia_contno"
					rsIa = oConn.Execute(sqlCmdIa)
					IF (rsPy.EOF) THEN
						A1(i, 19) = 0
					ELSE
						A1(i, 19) = rsPy("sum_py").Value
					END IF
					IF (rsIa.EOF) THEN
						A1(i, 18) = 0
					ELSE
						A1(i, 18) = rsIa("sum_ia").Value
					END IF
'					A1(i, 18) = rsData("ia_amt").Value
'					A1(i, 19) = rsData("cont_paidamt").Value
					'�~�ȭ��m�W
					rsEmp.MoveFirst
					WHILE NOT rsEmp.EOF
						IF (RTRIM(rsEmp("srspn_empno").Value)=RTRIM(rsData("cont_empno").Value)) THEN
							'�]�w���
							A1(i,  20) = RTRIM(rsEmp("srspn_cname").Value)
							EXIT WHILE
						END IF
						rsEmp.MoveNext
					END WHILE		
								
					' �]�w���
					DIM highlight1, highlight2, highlight3, highlight4, highlight5
					'�e���渹�]�w
					highlight1 = "A" & (5+i) & ":C" & (5+i)
					highlight2 = "D" & (5+i) & ":J" & (5+i)
					highlight3 = "K" & (5+i) & ":Q" & (5+i)
					highlight4 = "R" & (5+i) & ":T" & (5+i)
					highlight5 = "U" & (5+i) & ":U" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A8", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B8", FALSE)
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
				SrcBook = Server.MapPath("RptGetAd.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptGetAd.xls", TRUE)
				
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
