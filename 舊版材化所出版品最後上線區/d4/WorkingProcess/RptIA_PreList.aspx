<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���w���M��</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptIA_PreList" method="post" runat="server">
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
			DIM contno
			DIM strUser, strDate
			DIM imseq
			
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
			strUser = Request("whoami")
			strDate = Request("strdate")
			' �p�G���`�A�N�i�H�ϥ�
			IF (Request("Whoami") <> "") THEN
				strUser = Request("Whoami")
			ELSE
			' ���M�N���Ŧr��
				strUser = ""
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
			sqlCmdRsCount = sqlCmdRsCount & "SELECT COUNT(*) "
			sqlCmdRsCount = sqlCmdRsCount & "FROM wk_c4_ia_prelist "
			
			
			' ����ŦX���󪺵���
			rsCount = oConn.Execute(sqlCmdRsCount)
			IF (rsCount.EOF) THEN
				strRsCount = 0
			ELSE
				strRsCount = rsCount(0).Value
			END IF
			
			DIM sqlCmdIa, sqlCmdPy
			DIM rsIa, rsPy
			
			'���o�w��SAP���o���`���B
			'sqlCmdIa = "SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia "
			'sqlCmdIa = sqlCmdIa & "WHERE (ia_syscd = 'C4') "
			'sqlCmdIa = sqlCmdIa & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
			'sqlCmdIa = sqlCmdIa & "AND (ia_status = '7') GROUP BY  ia_contno"
			
			'���o�wú�ڤ��`���B
			'sqlCmdPy = "SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia "
			'sqlCmdPy = sqlCmdPy & "WHERE (ia_syscd = 'C4') "
			'sqlCmdPy = sqlCmdPy & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
			'sqlCmdPy = sqlCmdPy & "AND (ia.ia_pyno <> '') GROUP BY  ia_contno"
			
			' �զX���o��ƪ�T-SQL Command
			
			sqlCmdData = "SELECT * , proj.proj_projno "
			sqlCmdData = sqlCmdData & "FROM wk_c4_ia_prelist INNER JOIN "
			sqlCmdData = sqlCmdData & "proj ON wk_c4_ia_prelist.cont_syscd  COLLATE Chinese_Taiwan_Stroke_CI_AS = proj.proj_syscd "
			sqlCmdData = sqlCmdData & "AND wk_c4_ia_prelist.im_fgitri = proj.proj_fgitri "
			sqlCmdData = sqlCmdData & "ORDER BY  wk_c4_ia_prelist.cont_contno, wk_c4_ia_prelist.im_mfrno, wk_c4_ia_prelist.adr_addate"
			

			' ���o���
			rsData = oConn.Execute(sqlCmdData)	
											
			DIM i, j
			DIM contno_pre, imseq_pre
			DIM	idx
			contno_pre = ""
			imseq_pre = ""
			idx = 0
			j = 0

			'�p�⦳�X��p�p
			rsData.MoveFirst
			FOR j=0 TO strRsCount STEP 1
				IF((rsData("cont_contno").Value=contno_pre) AND (rsData("adr_imseq").Value=imseq_pre))THEN
					j = j
				ELSE
					idx = idx + 1
					contno_pre = rsData("cont_contno").Value
					imseq_pre = rsData("adr_imseq").Value
				END IF
				rsData.MoveNext
					
				IF (rsData.EOF) THEN
					EXIT FOR
				END IF
			NEXT

			' �]�w���
			DIM highlight1, highlight2, highlight3, highlight4, highlight5, highlight6, highlight7, highlight8
			
			' -- ��ܸ�� --
'			rsIa.MoveFirst
'			rsPy.MoveFirst
			rsData.MoveFirst
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
				rowCount = strRsCount
							
				DIM A1(rowCount+idx, 22)
				
				DIM datestr, counter
				
				contno_pre = ""
				imseq_pre = ""
				idx = 1
				'�o���`���B
				DIM	sum_invamt, sum_amt
				sum_invamt = 0
				sum_amt = 0
				counter = 0
				' ���ƶ�JArray��
				FOR j=0 TO rowCount STEP 1
					i = j + idx - 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' ��ư�
					IF((rsData("cont_contno").Value=contno_pre) AND (rsData("adr_imseq").Value=imseq_pre))THEN
					'�D�ɸ�ƥu��ܤ@��
						A1(i, 0) = ""
						A1(i, 1) = ""
						A1(i, 2) = ""
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
					ELSE
						'���N�p�pOUTPUT
						IF (i<>0) THEN
							A1(i, 0) = ""
							A1(i, 1) = ""
							A1(i, 2) = ""
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
							A1(i, 16) = "�p�p���ơG" & counter
							A1(i, 17) = ""
							A1(i, 18) = "�p�p���B�G"
							A1(i, 19) = sum_amt
							highlight1 = "A" & (6+i) & ":P" & (6+i)
							highlight6 = "Q" & (6+i) & ":U" & (6+i)
							highlight7 = "V" & (6+i) & ":V" & (6+i)
							IF (i MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
								XLS.FormatCells(1, highlight6, 2, "A12", FALSE)
								XLS.FormatCells(1, highlight7, 2, "A11", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
								XLS.FormatCells(1, highlight6, 2, "B12", FALSE)
								XLS.FormatCells(1, highlight7, 2, "B11", FALSE)
							END IF
							sum_amt = 0
							idx = idx + 1
							counter = 0
						END IF
						i = j + idx - 1
						A1(i, 0) = idx
						contno_pre = rsData("cont_contno").Value
						imseq_pre = rsData("adr_imseq").Value
						A1(i, 1) = rsData("cont_contno").Value
						datestr = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value	
						A1(i, 2) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
						A1(i, 3) = rsData("cont_mfrno").Value
						A1(i, 4) = rsData("cont_mfr_inm").Value
						A1(i, 5) = rsData("srspn_cname").Value
						A1(i, 6) = rsData("cont_totamt").Value
						A1(i, 7) = rsData("im_nm").Value
						A1(i, 8) = rsData("im_mfr_inm").Value
						A1(i, 9) = rsData("im_zip").Value & " " & rsData("im_addr").Value
						IF rsData("im_invcd").Value = "2" THEN
							A1(i, 10) = "�G�p"
						ELSE IF rsData("im_invcd").Value = "3" THEN
							A1(i, 10) = "�T�p"
						ELSE IF rsData("im_invcd").Value = "4" THEN
							A1(i, 10) = "��L"
						END IF
						
						IF rsData("im_taxtp").Value = "1" THEN
							A1(i, 11) = "5%"
						ELSE IF rsData("im_taxtp").Value = "2" THEN
							A1(i, 11) = "�s�|"
						ELSE IF rsData("im_taxtp").Value = "3" THEN
							A1(i, 11) = "�K�|"
						END IF
						IF rsData("im_fgitri").Value = "06" THEN
							A1(i, 12) = "�Ҥ�"
						ELSE IF rsData("im_fgitri").Value = "07" THEN
							A1(i, 12) = "�|��"
						ELSE
							A1(i, 12) = "�@��"
						END IF
						A1(i, 13) = rsData("proj_projno").Value
						
						contno = rsData("cont_contno").Value
						'���o�w��SAP���o���`���B
						sqlCmdIa = "SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia "
						sqlCmdIa = sqlCmdIa & "WHERE (ia_syscd = 'C4') "
						sqlCmdIa = sqlCmdIa & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
						sqlCmdIa = sqlCmdIa & "AND (ia_status = '7') GROUP BY  ia_contno"
						rsIa = oConn.Execute(sqlCmdIa)
						'���o�wú�ڤ��`���B
						sqlCmdPy = "SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia "
						sqlCmdPy = sqlCmdPy & "WHERE (ia_syscd = 'C4') "
						sqlCmdPy = sqlCmdPy & "AND (SUBSTRING(ia_contno, 3, 6) = '"& contno &"') "
						sqlCmdPy = sqlCmdPy & "AND (ia.ia_pyno <> '') GROUP BY  ia_contno"
						rsPy = oConn.Execute(sqlCmdPy)
						IF (rsPy.EOF) THEN
							A1(i, 20) = 0
						ELSE
							A1(i, 20) = rsPy("sum_py").Value
						END IF
						IF (rsIa.EOF) THEN
							A1(i, 21) = 0
						ELSE
							A1(i, 21) = rsIa("sum_ia").Value
						END IF
					END IF								
'					A1(i, 14) = Mid(rsData("adr_addate").Value, 1, 4) & "/" & Mid(rsData("adr_addate").Value, 5, 2) & "/" & Mid(rsData("adr_addate").Value, 7, 2)
					A1(i, 14) = Mid(rsData("adr_addate").Value, 5, 2) & "/" & Mid(rsData("adr_addate").Value, 7, 2)
					A1(i, 15) = rsData("adr_seq").Value
					A1(i, 16) = rsData("adr_adamt").Value
					A1(i, 17) = rsData("adr_desamt").Value
					A1(i, 18) = rsData("adr_chgamt").Value
					A1(i, 19) = rsData("adr_invamt").Value
					sum_invamt = sum_invamt + rsData("adr_invamt").Value
					sum_amt = sum_amt + rsData("adr_invamt").Value
					
					counter=counter+1
					'�e���渹�]�w
					highlight1 = "A" & (6+i) & ":D" & (6+i)
					highlight2 = "E" & (6+i) & ":F" & (6+i)
					highlight3 = "G" & (6+i) & ":I" & (6+i)
					highlight4 = "J" & (6+i) & ":L" & (6+i)
					highlight5 = "M" & (6+i) & ":R" & (6+i)
					highlight6 = "S" & (6+i) & ":V" & (6+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "A5", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight6, 2, "B5", FALSE)
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
				A1(i, 2) = ""
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
				A1(i, 16) = "�p�p���ơG" & counter
				A1(i, 17) = ""
				A1(i, 18) = "�p�p���B�G"
				A1(i, 19) = sum_amt
				highlight1 = "A" & (6+i) & ":P" & (6+i)
				highlight6 = "Q" & (6+i) & ":U" & (6+i)
				highlight7 = "V" & (6+i) & ":V" & (6+i)
				IF (i MOD 2)=0 THEN
					XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
					XLS.FormatCells(1, highlight6, 2, "A12", FALSE)
					XLS.FormatCells(1, highlight7, 2, "A11", FALSE)
				ELSE
					XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
					XLS.FormatCells(1, highlight6, 2, "B12", FALSE)
					XLS.FormatCells(1, highlight7, 2, "B11", FALSE)
				END IF
				
				'A1(rowCount, 1) = sqlCmdAdrCount
				'A1(rowCount, 2) = AdrCount
				'A1(rowCount, 3) = strRsCount
				
				' ��]�wSheet�ð_��
				XLS.HideSheet(2, TRUE)
				
				' �ϥ�Array�@����ƨӷ�
				XLS.AddRS_Array_2D(A1, TRUE)
				
				' �bExcel Speed Gen���]�w�ܼ�
				XLS.AddVariable("TotAmt", sum_invamt)	'�bExcel���� >>$strDate
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
				XLS.AddVariable("strDate", strDate)	'�bExcel���� >>$strDate
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptIA_PreList.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptIA_PreList.xls", TRUE)
				
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
