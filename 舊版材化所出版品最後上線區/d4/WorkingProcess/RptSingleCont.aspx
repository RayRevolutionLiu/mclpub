<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptSingleCont" method="post" runat="server">
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
			IF (Session("RPTSINGLECONT") <> "") THEN
				strFilter = Session("RPTSINGLECONT")
			ELSE
				strFilter = ""
			END IF		
	
	
			' �{�b�ɶ�
			IF (Session("STRNOW") <> "") THEN
				strNOW = Session("STRNOW")
			ELSE
				strNOW = ""
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
			sqlCmdRsCount = sqlCmdRsCount & "FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno "
			sqlCmdRsCount = sqlCmdRsCount & "LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno "
			sqlCmdRsCount = sqlCmdRsCount & "LEFT OUTER JOIN wk_c4_matpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkmatp_contno "
			sqlCmdRsCount = sqlCmdRsCount & "LEFT OUTER JOIN wk_c4_atpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkatp_contno "
			sqlCmdRsCount = sqlCmdRsCount & "LEFT OUTER JOIN wk_c4_fbkstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkfbk_contno "
			sqlCmdRsCount = sqlCmdRsCount & "WHERE (cont_fgtemp = '0')"			
			
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
			'�o�լO�ª�
			'sqlCmdData = ""
			'sqlCmdData = SqlCmdData & "SELECT cont_syscd, cont_contno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_custno, cont_aunm, cont_autel, "
			'sqlCmdData = SqlCmdData & "cont_aufax, cont_aucell, cont_auemail, cont_freetm, cont_resttm, cont_pubtm, cont_totimgtm, cont_toturltm, cont_disc, cont_totamt, "
			'sqlCmdData = SqlCmdData & "cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_pdcont, cont_remark, cont_credate, cont_moddate, cont_modempno, cont_oldcontno, "
			'sqlCmdData = SqlCmdData & "cont_fgpayonce, cont_fgtemp, cont_fgpubed, cont_fgclosed, cont_fgcancel, cust_custno, cust_nm, mfr_mfrno, mfr_inm "
			'sqlCmdData = SqlCmdData & "FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno "
			'sqlCmdData = SqlCmdData & "LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno "
			'sqlCmdData = SqlCmdData & "WHERE (cont_fgtemp = '0') AND (cont_fgcancel = '0') AND cont_fgclosed='0'"

			sqlCmdData = ""
			sqlCmdData = SqlCmdData & "SELECT *, cust_custno, cust_nm, mfr_mfrno, mfr_inm, wkmatp_matpstr, wkatp_atpstr, wkfbk_fbkstr "
			sqlCmdData = SqlCmdData & "FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno "
			sqlCmdData = SqlCmdData & "LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno "
			sqlCmdData = SqlCmdData & "LEFT OUTER JOIN wk_c4_matpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkmatp_contno "
			sqlCmdData = SqlCmdData & "LEFT OUTER JOIN wk_c4_atpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkatp_contno "
			sqlCmdData = SqlCmdData & "LEFT OUTER JOIN wk_c4_fbkstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkfbk_contno "
			sqlCmdData = SqlCmdData & "WHERE (cont_fgtemp = '0')"


			'�[�WWhere����			
			IF (strFilter <> "") THEN
				sqlCmdData = sqlCmdData & " AND " & strFilter
			END IF
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
			
			
			
			' ���^�����P�s�i���
			DIM rsAdr
			DIM sqlCmdAdr
			sqlCmdAdr = ""
			sqlCmdAdr = sqlCmdAdr & "SELECT adr_contno, adr_seq, adr_addate, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_impr, "
            sqlCmdAdr = sqlCmdAdr & "adr_navurl, adr_drafttp, adr_urltp, adr_imseq, adr_invamt, adr_adamt, adr_desamt, adr_chgamt, "
            sqlCmdAdr = sqlCmdAdr & "adr_remark, adr_projno, adr_costctr, adr_fginved, adr_fgfixad, adr_fgimggot, adr_fgurlgot, adr_fginvself, adr_fgact, "
            sqlCmdAdr = sqlCmdAdr & "im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, cont_signdate "
			sqlCmdAdr = sqlCmdAdr & "FROM c4_adr INNER JOIN c4_cont ON adr_contno = cont_contno LEFT OUTER JOIN invmfr ON adr_syscd = im_syscd AND adr_contno = im_contno AND adr_imseq = im_imseq "
			sqlCmdAdr = sqlCmdAdr & "WHERE (1=1)"
						
			'�[�WWhere����H			
			IF (strFilter <> "") THEN
				DIM adrFilter
				adrFilter = strFilter.Replace("cont_contno", "adr_contno")
				sqlCmdAdr = sqlCmdAdr & " AND " & adrFilter
			END IF
			' ���o���
			rsAdr = oConn.Execute(sqlCmdAdr)
			
			' ���^�����P�s�i������
			DIM rsAdrCount	
			DIM sqlCmdAdrCount
			DIM AdrCount
			
			sqlCmdAdrCount = ""
			sqlCmdAdrCount = sqlCmdAdrCount & "SELECT COUNT(*) AS AdrCount "
			sqlCmdAdrCount = sqlCmdAdrCount & "FROM c4_adr INNER JOIN c4_cont ON adr_contno = cont_contno LEFT OUTER JOIN invmfr ON adr_syscd = im_syscd AND adr_contno = im_contno AND adr_imseq = im_imseq "
			sqlCmdAdrCount = sqlCmdAdrCount & "WHERE (1=1)"								
			
			'�[�WWhere����H			
			IF (strFilter <> "") THEN
				DIM adrFilter
				adrFilter = strFilter.Replace("cont_contno", "adr_contno")
				sqlCmdAdrCount = sqlCmdAdrCount & " AND " & adrFilter
			END IF
			rsAdrCount = oConn.Execute(sqlCmdAdrCount)				
			
			IF (rsAdrCount.EOF) THEN
				AdrCount = 0
			ELSE
				AdrCount = rsAdrCount(0).Value
			END IF
			
			
			

			
			' -- ���o���u��� --
			DIM rsEmp
			DIM sqlCmdEmp
			DIM datestr
			
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
				rowCount = strRsCount + AdrCount + 5
							
				DIM A1(rowCount, 42)
				
				DIM i
				
				' ���ƶ�JArray��
				FOR i=0 TO rowCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' ��ư�
					A1(i,  0) = rsData("cont_contno").Value
'					A1(i,  1) = rsData("cont_signdate").Value
					A1(i,1) = Mid(rsData("cont_signdate").Value, 1, 4) & "/" & Mid(rsData("cont_signdate").Value, 5, 2) & "/" & Mid(rsData("cont_signdate").Value, 7, 2)
					IF (rsData("cont_conttp").Value="01") THEN
						A1(i,  2) = "�@��"
					ELSE
						A1(i,  2) = "���s"
					END IF
'					A1(i,  3) = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value	
					datestr = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value	
					A1(i,3) = Mid(datestr, 1, 4) & "/" & Mid(datestr, 5, 2) & "/" & Mid(datestr, 7, 3) & Mid(datestr, 10, 4) & "/" & Mid(datestr, 14, 2) & "/" & Mid(datestr, 16, 2)
					A1(i, 38) = rsData("mfr_inm").Value
									
					'�~�ȭ��m�W
					rsEmp.MoveFirst
					WHILE NOT rsAdr.EOF
						IF (RTRIM(rsEmp("srspn_empno").Value)=RTRIM(rsData("cont_empno").Value)) THEN
							'�]�w���
							A1(i,  4) = RTRIM(rsEmp("srspn_cname").Value)
							EXIT WHILE
						END IF
						rsEmp.MoveNext
					END WHILE		
								
					IF (rsData("cont_fgpayonce").Value="1") THEN
						A1(i,  5) = "�O"
					ELSE
						A1(i,  5) = "�_"
					END IF
					
					' �γ\�H��L�̷|�Q�n
					'A1(i,  6) = rsData("mfr_mfrno").Value & "(" & rsData("cont_mfrno").Value & ")"
					'A1(i,  7) = rsData("cust_nm").Value & "(" & rsData("cont_custno").Value & ")"
					A1(i,  6) = rsData("cont_remark").Value
					A1(i,  7) = rsData("cont_pubtm").Value
					A1(i,  8) = rsData("cont_resttm").Value
					A1(i,  9) = rsData("cont_freetm").Value
					A1(i, 10) = rsData("cont_totimgtm").Value
					A1(i, 11) = ""		'�Ѿl�s���ɽZ����
					A1(i, 12) = rsData("cont_toturltm").Value
					A1(i, 13) = ""		'�Ѿl�s�����Z����		
					A1(i, 14) = rsData("cont_disc").Value
					
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
						A1(i, 15) = 0
					ELSE
						A1(i, 15) = rsPy("sum_py").Value
					END IF
					IF (rsIa.EOF) THEN
						A1(i, 16) = 0
					ELSE
						A1(i, 16) = rsIa("sum_ia").Value
					END IF
'					A1(i, 15) = rsData("cont_totamt").Value
'					A1(i, 16) = ""		'�w�}�ߵo�����B
					A1(i, 17) = rsData("cont_paidamt").Value
					A1(i, 18) = rsData("cont_aunm").Value
					A1(i, 19) = rsData("cont_autel").Value
					A1(i, 20) = rsData("cont_aufax").Value
					A1(i, 21) = rsData("cont_aucell").Value
					A1(i, 22) = rsData("cont_auemail").Value
					A1(i, 23) = rsData("wkmatp_matpstr").Value	'���ƯS��
					A1(i, 24) = rsData("wkatp_atpstr").Value	'���β��~
					A1(i, 25) = rsData("wkfbk_fbkstr").Value	'���x����H���خѸ��
					A1(i, 39) = rsData("cont_ccont").Value		'�s�i���s����
					A1(i, 40) = rsData("cont_pdcont").Value		'���~�]�Ƥ���
					A1(i, 41) = Mid(rsData("cont_csdate").Value, 1, 4) & "/" & Mid(rsData("cont_csdate").Value, 5, 2) & "/" & Mid(rsData("cont_csdate").Value, 7, 2)	'�j�M����
					
					
					IF rsAdr.EOF THEN
						' �p�G�S�������A�N�b�o��]�w
						' �]�w���
							DIM highlight1, highlight2
							'�e���渹�]�w
							highlight1 = "A" & (6+i) & ":P" & (6+i)
							highlight2 = "T" & (6+i) & ":AP" & (6+i)
					
							IF (i MOD 2)=0 THEN
								XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
								XLS.FormatCells(1, "Q"&(6+i)&":S"&(6+i), 2, "A5", FALSE)
							ELSE
								XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
								XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
								XLS.FormatCells(1, "Q"&(6+i)&":S"&(6+i), 2, "B5", FALSE)
							END IF
					ELSE
					
					'�H�U���������
					
						'DIM j
						rsAdr.MoveFirst
						WHILE NOT rsAdr.EOF
						
							IF (rsAdr("adr_contno").Value=rsData("cont_contno").Value) THEN
								'�]�w���
								A1(i,26) = Mid(rsAdr("adr_addate").Value, 1, 4) & "/" & Mid(rsAdr("adr_addate").Value, 5, 2) & "/" & Mid(rsAdr("adr_addate").Value, 7, 2)
	'							A1(i, 26) = rsAdr("adr_addate").Value						
								A1(i, 27) = rsAdr("adr_alttext").Value
							
								IF rsAdr("adr_adcate").Value = "M" THEN
									A1(i, 28) = "����"
								ELSE IF rsAdr("adr_adcate").Value = "I"
									A1(i, 28) = "����"
								ELSE IF rsAdr("adr_adcate").Value = "N"
									A1(i, 28) = "�`��"
								ELSE
								A1(i, 28) = "(���~)"
								END IF		
													
								A1(i, 29) = rsAdr("adr_keyword").Value
								
								IF rsAdr("adr_keyword").Value = "h0" THEN
									A1(i, 29) = "����"
								ELSE IF rsAdr("adr_keyword").Value = "h1" THEN
									A1(i, 29) = "�k�@"
								ELSE IF rsAdr("adr_keyword").Value = "h2" THEN
									A1(i, 29) = "�k�G"
								ELSE IF rsAdr("adr_keyword").Value = "h3" THEN
									A1(i, 29) = "�k�T"
								ELSE IF rsAdr("adr_keyword").Value = "h4" THEN
									A1(i, 29) = "�k�|"
								ELSE IF rsAdr("adr_keyword").Value = "w1" THEN
									A1(i, 29) = "�k��@"
								ELSE IF rsAdr("adr_keyword").Value = "w2" THEN
									A1(i, 29) = "�k��G"
								ELSE IF rsAdr("adr_keyword").Value = "w3" THEN
									A1(i, 29) = "�k��T"
								ELSE IF rsAdr("adr_keyword").Value = "w4" THEN
									A1(i, 29) = "�k��|"
								ELSE IF rsAdr("adr_keyword").Value = "w5" THEN
									A1(i, 29) = "�k�夭"
								ELSE IF rsAdr("adr_keyword").Value = "w6" THEN
									A1(i, 29) = "�k�夻"
								ELSE
								END IF							
								
								A1(i, 30) = rsAdr("adr_impr").Value
								A1(i, 31) = rsAdr("adr_imgurl").Value
								A1(i, 32) = rsAdr("adr_navurl").Value
								A1(i, 33) = rsAdr("im_nm").Value
								A1(i, 34) = rsAdr("im_addr").Value
								A1(i, 35) = rsAdr("im_tel").Value
								
								IF rsAdr("im_invcd").Value IS DBNull.Value THEN
									A1(i, 36) = ""
								ELSE IF rsAdr("im_invcd").Value="2" THEN
									A1(i, 36) = "�G�p"
								ELSE IF rsAdr("im_invcd").Value="3" THEN
									A1(i, 36) = "�T�p"
								ELSE
									A1(i, 36) = "��L" 
								END IF
								
								IF rsAdr("im_taxtp").Value IS DBNull.Value THEN
									A1(i, 37) = ""
								ELSE IF rsAdr("im_taxtp").Value="1" THEN
									A1(i, 37) = "���|5%"
								ELSE IF rsAdr("im_taxtp").Value="2"
									A1(i, 37) = "�s�|"
								ELSE
									A1(i, 37) = "�K�|"
								END IF
								
								' �o��]�n�]�w���
								DIM highlight1, highlight2
								'�e���渹�]�w
								highlight1 = "A" & (6+i) & ":P" & (6+i)
								highlight2 = "T" & (6+i) & ":AP" & (6+i)
						
								IF (i MOD 2)=0 THEN
									XLS.FormatCells(1, highlight1, 2, "A1", FALSE)
									XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
									XLS.FormatCells(1, "Q"&(6+i)&":S"&(6+i), 2, "A5", FALSE)
								ELSE
									XLS.FormatCells(1, highlight1, 2, "B1", FALSE)
									XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
									XLS.FormatCells(1, "Q"&(6+i)&":S"&(6+i), 2, "B5", FALSE)
								END IF
								
								i = i + 1
								'EXIT WHILE
							END IF
							rsAdr.MoveNext
						END WHILE
					END IF					
						
					' RS����
					rsData.MoveNext
					
					' �w������
					IF (rsData.EOF) THEN
						EXIT FOR
					END IF
					' LOOPING
				NEXT
				
				'A1(rowCount, 1) = sqlCmdAdrCount
				'A1(rowCount, 2) = AdrCount
				'A1(rowCount, 3) = strRsCount
				
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
				SrcBook = Server.MapPath("RptCont.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptCont.xls", TRUE)
				
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
