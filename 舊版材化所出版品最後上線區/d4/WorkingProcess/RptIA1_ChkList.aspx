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
		<form id="RptIA1_ChkList" method="post" runat="server">
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
			DIM iano, sortkey
			DIM strUser
			DIM strNOW
			
			' -- ��Ƶ��� --
			DIM strRsCount, strRsDataCount
			
			' -- Excel Speed Gen ���� --
			DIM XLS
			DIM SrcBook
			
			' �]�w���
			DIM highlight1, highlight2, highlight3, highlight4, highlight5
		
			' -- �]�w��ƨӷ��P��Ʈw --
			DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
			oConn = Server.CreateObject("ADODB.Connection")
			oConn.Open(DSN)
			
			' -- �]�w�����ܼ� --
			' ����������
			iano = Request("iano")
			strUser = Request("whoami")
			
			' �p�G���`�A�N�i�H�ϥ�
			IF (Request("whoami") <> "") THEN
				strUser = Request("whoami")
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
			sqlCmdDataCounts = ""
			sqlCmdDataCounts = sqlCmdDataCounts & "SELECT COUNT(*) FROM iad "
			sqlCmdDataCounts = sqlCmdDataCounts & "WHERE (iad.iad_syscd = 'C4') AND (iad.iad_iano = '" & iano & "') "


			
			
			' ����ŦX���󪺵���
			' �p�⦳�X��p�p
			rsDataCounts = oConn.Execute(sqlCmdDataCounts)
			IF (rsDataCounts.EOF) THEN
				strRsDataCount = 0
			ELSE
				strRsDataCount = rsDataCounts(0).Value
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
			sqlCmdData = sqlCmdData & "SELECT ia.*, iad.*, mfr.mfr_inm AS im_mfr_inm, mfr_1.mfr_inm AS cont_mfr_inm, c4_cont.cont_contno, "
			sqlCmdData = sqlCmdData & "c4_cont.cont_empno, c4_cont.cont_sdate, c4_cont.cont_edate, "
			sqlCmdData = sqlCmdData & "c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, c4_adr.adr_chgamt, c4_adr.adr_remark "
			sqlCmdData = sqlCmdData & "FROM ia INNER JOIN "
			sqlCmdData = sqlCmdData & "iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano INNER JOIN "
			sqlCmdData = sqlCmdData & "c4_cont ON iad.iad_syscd = c4_cont.cont_syscd AND "
			sqlCmdData = sqlCmdData & "iad.iad_fk1 = c4_cont.cont_contno INNER JOIN "
			sqlCmdData = sqlCmdData & "c4_adr ON iad.iad_syscd = c4_adr.adr_syscd AND " 
			sqlCmdData = sqlCmdData & "iad.iad_fk1 = c4_adr.adr_contno AND iad.iad_fk3 = c4_adr.adr_seq AND "
			sqlCmdData = sqlCmdData & "iad.iad_fk2 = c4_adr.adr_addate LEFT OUTER JOIN "
			sqlCmdData = sqlCmdData & "mfr ON ia.ia_mfrno = mfr.mfr_mfrno LEFT OUTER JOIN "
			sqlCmdData = sqlCmdData & "mfr mfr_1 ON c4_cont.cont_mfrno = mfr_1.mfr_mfrno "
			sqlCmdData = sqlCmdData & "WHERE (ia.ia_syscd = 'C4') AND (ia.ia_iano = '" & iano & "') "
			sqlCmdData = SqlCmdData & "ORDER BY  iad_iaditem"
			
			' ���o���
			rsData = oConn.Execute(sqlCmdData)
									
											
			DIM i, j
			DIM iano_pre
			DIM	idx
			iano_pre = ""
			idx = 0
			j = 0
			
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
				rowCount = strRsDataCount
							
				DIM A1(rowCount, 24)
				
				DIM datestr, counter
				
				iano_pre = ""
				idx = 1
				'�o���`���B
				DIM	sum_invamt, sum_amt
				sum_invamt = 0
				sum_amt = 0
				counter = 0
				' ���ƶ�JArray��
				FOR i=0 TO rowCount STEP 1
					IF rsData.EOF THEN
						EXIT FOR
					END IF
				
					' ��ư�
					IF(rsData("ia_iano").Value=iano_pre)THEN
					'�D�ɸ�ƥu��ܤ@��
						A1(i, 0) = ""
						A1(i, 1) = ""
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
						A1(i, 18) = ""
					ELSE
						A1(i, 0) = i + 1
						iano_pre = rsData("ia_iano").Value
						A1(i, 1) = rsData("ia_iano").Value
						A1(i, 3) = rsData("ia_mfrno").Value
						A1(i, 4) = rsData("im_mfr_inm").Value
						A1(i, 5) = rsData("ia_rnm").Value & "(" & TRIM(rsData("ia_rjbti").Value) & ")"
						A1(i, 6) = rsData("ia_rzip").Value & rsData("ia_raddr").Value
						A1(i, 7) = rsData("ia_rtel").Value
						A1(i, 8) = rsData("cont_mfr_inm").Value
						IF rsData("ia_invcd").Value = "2" THEN
							A1(i, 9) = "�G�p"
						ELSE IF rsData("ia_invcd").Value = "3" THEN
							A1(i, 9) = "�T�p"
						ELSE IF rsData("ia_invcd").Value = "4" THEN
							A1(i, 9) = "��L"
						END IF
						
						IF rsData("ia_taxtp").Value = "1" THEN
							A1(i, 10) = "5%"
						ELSE IF rsData("ia_taxtp").Value = "2" THEN
							A1(i, 10) = "�s�|"
						ELSE IF rsData("ia_taxtp").Value = "3" THEN
							A1(i, 10) = "�K�|"
						END IF
						IF rsData("ia_fgitri").Value = "06" THEN
							A1(i, 11) = "�Ҥ�"
						ELSE IF rsData("ia_fgitri").Value = "07" THEN
							A1(i, 11) = "�|��"
						ELSE
							A1(i, 11) = "�@��"
						END IF
						A1(i, 12) = rsData("iad_costctr").Value
						A1(i, 13) = rsData("iad_projno").Value
						A1(i, 14) = rsData("iad_fk1").Value
						A1(i, 15) = rsData("cont_sdate").Value & "~" & rsData("cont_edate").Value
						A1(i, 18) = rsData("ia_cname").Value
					END IF								
					A1(i, 2) = rsData("iad_iaditem").Value
					A1(i, 16) = rsData("iad_fk3").Value
					A1(i, 17) = Mid(rsData("iad_fk2").Value, 5, 2) & "/" & Mid(rsData("iad_fk2").Value, 7, 2)
					A1(i, 19) = rsData("adr_adamt").Value
					A1(i, 20) = rsData("adr_desamt").Value
					A1(i, 21) = rsData("adr_chgamt").Value
					A1(i, 22) = rsData("adr_invamt").Value
					A1(i, 23) = rsData("adr_remark").Value
					
					counter=counter+1
					'�e���渹�]�w
					highlight1 = "A" & (5+i) & ":D" & (5+i)
					highlight2 = "E" & (5+i) & ":I" & (5+i)
					highlight3 = "J" & (5+i) & ":S" & (5+i)
					highlight4 = "T" & (5+i) & ":W" & (5+i)
					highlight5 = "X" & (5+i) & ":X" & (5+i)
				
					IF (i MOD 2)=0 THEN
						XLS.FormatCells(1, highlight1, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "A1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "A2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "A5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "A1", FALSE)
					ELSE
						XLS.FormatCells(1, highlight1, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight2, 2, "B1", FALSE)
						XLS.FormatCells(1, highlight3, 2, "B2", FALSE)
						XLS.FormatCells(1, highlight4, 2, "B5", FALSE)
						XLS.FormatCells(1, highlight5, 2, "B1", FALSE)
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
				XLS.AddVariable("strCount", counter)	'�bExcel���� >>$IabDate
'				XLS.AddVariable("IabSeq", strIabSeq)	'�bExcel���� >>$IabSeq
				XLS.AddVariable("WHOAMI", strUser)	'�bExcel���� >>$WHOAMI
'				XLS.AddVariable("TotAmt", sum_invamt)	'�bExcel���� >>$strDate
				
				' �Ӳz�����Ӧb�o��~��
				DIM strFilterInfo
				strFilterInfo = "�ŦX " & Session("FILTERINFO") & " ����Ʀ@ " & strRsCount & " ��"				
				XLS.AddVariable("FILTERINFO", strFilterInfo)	'>>$FILTERINFO
				
				' �d��Template
				SrcBook = Server.MapPath("RptIA1_ChkList.xls")
				
				' Bind��ƨ�Template��
				XLS.Generate(SrcBook, "RptIA1_ChkList.xls", TRUE)
				
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
