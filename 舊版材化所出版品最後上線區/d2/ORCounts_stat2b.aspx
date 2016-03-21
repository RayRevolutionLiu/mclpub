<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�l�H���Ʋέp�� ��를�Z�n</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="cont_list2" method="post" runat="server">
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
				Dim dbFile		' Database File
				Dim oConn		' ADO Connection object
				Dim DSN			' Web Application Name

				Dim Rs1, Rs2, Rs4, Rs5			' Record Source 1 ~ 5
				Dim Rs9, RS10				' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2, sqlcmd4, sqlcmd5	' SQL Command 1 ~ 5
				Dim sqlcmd9, sqlcmd10			' SQL Command 9 ~ 10
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' �ۭq sql �ܼ�
				Dim strBkcd, strYYYYMM, strConttp, strfgmosea, strMtpcd

				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim strYYYYMMNew, BkPNo, BkName, strLoginEmpNo, strLoginEmpCName


				' Open Database------------------
				' a. Open a Microsoft Access Database
					'dbFile = Server.MapPath("test.mdb")
					'oConn = Server.CreateObject("ADODB.Connection")
					'oConn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFile)

				' b. Open a Microsoft SQL Server Database
					'DSN = ConfigurationSettings.AppSettings("isccom1_mrlpub_esg")
					'DSN = ConfigurationSettings.AppSettings("isccom1_mrltest_esg")
					DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")

				' �۫e�@����ǻ� form �����ܼ� empno, �H��X EmpNo, EmpCName
				Dim strConttpText, strfgmoseaText, strMtpName
				strBkcd = Request("bkcd")
				strYYYYMM = Request("yyyymm")
				strConttp = Request("conttp")
				strfgmosea = Request("fgmosea")
				strMtpcd = Request("mtpcd")
				strLoginEmpNo = Request("LEmpNo")

				if(strYYYYMM <> "") then
					strYYYYMM = strYYYYMM
					strYYYYMMnew = Mid(strYYYYMM, 1, 4) & "/" & Mid(strYYYYMM, 5, 2)

					' Get Rs4: �� �Z�n�~�� ��X��۹����� �Z�n���O
					sqlcmd4 = "SELECT bkp_pno "
					sqlcmd4 = sqlcmd4 & " FROM bookp "
					sqlcmd4 = sqlcmd4 & " WHERE (bkp_date = '" & strYYYYMM & "') "
					sqlcmd4 = sqlcmd4 & " AND (bkp_bkcd = '" & strBkcd & "') "
					Rs4 = oConn.Execute(sqlcmd4)
					BkPNo = Rs4("bkp_pno").value
					'Response.Write("BkPNo= " & BkPNo & "<br>")
				else
					strYYYYMM = ""
					BkPNo = ""
				end if

				' �X�����O
				if(strConttp <> "") then
					if(strConttp = "01") then
						strConttpText = "�@��"
					end if
					if(strConttp = "09") then
						strConttpText = "���s"
					end if
				else
					strConttpText = "(�Ҧ�)"
				end if


				' �X���_������϶�
				if(strfgmosea <> "")then
					if(strfgmosea = "0") then
						strfgmoseaText = "�ꤺ"
					end if
					if(strfgmosea = "1") then
						strfgmoseaText = "��~"
					end if
				else
					strfgmoseaText = "(�Ҧ�)"
				end if


				' Get Rs10: �Ƕl�H�N�X��X��W��
				if(strMtpcd <> "") then
					strMtpcd = TRIM(Request("mtpcd"))

					' Open the RecordSets
					sqlcmd10 = "SELECT * FROM mtp"
					sqlcmd10 = sqlcmd10 & " WHERE (mtp_mtpcd='" + strMtpcd + "')"
					Rs10 = oConn.Execute(sqlcmd10)
					if Rs10.EOF then
						strMtpName = "(�d�L���)"
					else
						strMtpName = TRIM(Rs10("mtp_nm").Value)
					end if
					'Response.Write("strMtpcd= " & strMtpcd & "<br>")
					'Response.Write("strMtpName= " & strMtpName & "<br>")
				else
					strMtpcd = ""
					strMtpName = "(�Ҧ�)"
				end if


				' Get Rs5: �Ǯ��y�N�X��X���y�W��
				if(strBkcd <> "") then
					strBkcd = strBkcd

					' Open the RecordSets
					sqlcmd5 = "SELECT * FROM book"
					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
					Rs5 = oConn.Execute(sqlcmd5)
					BkName = Rs5("bk_nm").Value
					'Response.Write("BkName= " & BkName & "<br>")
				else
					strBkcd = ""
				end if

				if(Request("LEmpNo") <> "") then
					strLoginEmpNo = strLoginEmpNo

					' Get Rs9: �ǵn�J�~�ȭ��u����X�m�W
					' Open the RecordSets
					sqlcmd9 = "SELECT * FROM srspn"
					sqlcmd9 = sqlcmd9 & " WHERE (srspn_empno='" + strLoginEmpNo + "')"
					Rs9 = oConn.Execute(sqlcmd9)
					strLoginEmpCName = Trim(Rs9("srspn_cname").Value)
					'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")
				else
					strLoginEmpNo = ""
					strLoginEmpCName = ""
				end if


				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno, c2_cont.cont_mfrno, "
				sqlcmd2 = sqlcmd2 & " RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd, "
				sqlcmd2 = sqlcmd2 & " RTRIM(mtp.mtp_nm) AS mtp_nm, COUNT(c2_or.or_unpubcnt) "
				sqlcmd2 = sqlcmd2 & " AS UnPubCounts, c2_cont.cont_sdate, c2_cont.cont_edate, "
				sqlcmd2 = sqlcmd2 & " SUBSTRING(c2_cont.cont_sdate, 1, 4) "
				sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6) "
				sqlcmd2 = sqlcmd2 & " + ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4) "
				sqlcmd2 = sqlcmd2 & " + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_conttp, c2_or.or_fgmosea "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno = c2_or.or_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd2 = sqlcmd2 & " WHERE         (c2_cont.cont_fgclosed = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_contno NOT IN "
				sqlcmd2 = sqlcmd2 & " (SELECT DISTINCT c2_pub.pub_contno "
				sqlcmd2 = sqlcmd2 & " FROM              c2_pub "
				sqlcmd2 = sqlcmd2 & " WHERE          c2_pub.pub_yyyymm = '" & strYYYYMM & "')) "
				sqlcmd2 = sqlcmd2 & " AND (c2_or.or_unpubcnt > 0) "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd2 = sqlcmd2 & " AND (cont_conttp = '" & strConttp & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("fgmosea") <> "") then
					strfgmosea  = Request("fgmosea")
					sqlcmd2 = sqlcmd2 & " AND (or_fgmosea = '" & strfgmosea & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("mtpcd") <> "") then
					strMtpcd = Request("mtpcd")
					sqlcmd2 = sqlcmd2 & " AND (or_mtpcd = '" & strMtpcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				sqlcmd2 = sqlcmd2 & " GROUP BY  c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm, "
				sqlcmd2 = sqlcmd2 & " c2_or.or_mtpcd, mtp.mtp_nm, c2_cont.cont_sdate, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_edate, c2_cont.cont_conttp, c2_or.or_fgmosea "
				sqlcmd2 = sqlcmd2 & " ) DRIVERTBL "

				' Open the RecordSets
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescount = 0
					Response.Write ("<FONT Color=Red><B>�d�ߵ��G - ���Ƭ� 0</B></FONT><BR>")
				else
					rescount = Rs2(0).Value
				end if
				'Response.Write("rescount= " & rescount & "<br>")


				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				sqlcmd1 = sqlcmd1 & " SELECT DISTINCT "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno, c2_cont.cont_mfrno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd, "
				sqlcmd1 = sqlcmd1 & " RTRIM(mtp.mtp_nm) AS mtp_nm, COUNT(c2_or.or_unpubcnt) "
				sqlcmd1 = sqlcmd1 & " AS UnPubCounts, c2_cont.cont_sdate, c2_cont.cont_edate, "
				sqlcmd1 = sqlcmd1 & " SUBSTRING(c2_cont.cont_sdate, 1, 4) "
				sqlcmd1 = sqlcmd1 & " + '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6) "
				sqlcmd1 = sqlcmd1 & " + ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4) "
				sqlcmd1 = sqlcmd1 & " + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_conttp, c2_or.or_fgmosea "
				sqlcmd1 = sqlcmd1 & " FROM             c2_cont INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno = c2_or.or_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " WHERE         (c2_cont.cont_fgclosed = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_contno NOT IN "
				sqlcmd1 = sqlcmd1 & " (SELECT DISTINCT c2_pub.pub_contno "
				sqlcmd1 = sqlcmd1 & " FROM              c2_pub "
				sqlcmd1 = sqlcmd1 & " WHERE          c2_pub.pub_yyyymm = '" & strYYYYMM & "')) "
				sqlcmd1 = sqlcmd1 & " AND (c2_or.or_unpubcnt > 0) "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd1 = sqlcmd1 & " AND (cont_conttp = '" & strConttp & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("fgmosea") <> "") then
					strfgmosea  = Request("fgmosea")
					sqlcmd1 = sqlcmd1 & " AND (or_fgmosea = '" & strfgmosea & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("mtpcd") <> "") then
					strMtpcd = Request("mtpcd")
					sqlcmd1 = sqlcmd1 & " AND (or_mtpcd = '" & strMtpcd & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " GROUP BY  c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm, "
				sqlcmd1 = sqlcmd1 & " c2_or.or_mtpcd, mtp.mtp_nm, c2_cont.cont_sdate, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_edate, c2_cont.cont_conttp, c2_or.or_fgmosea "
				sqlcmd1 = sqlcmd1 & " ORDER BY  c2_or.or_mtpcd, c2_cont.cont_contno "

				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)

				'------- �}�l��X���G ---
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='��������'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='�^�W�@��'--></FORM><BR>")

				' �Y�����, �h��X�� ExcelSpeedGen
				else
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")

					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")


					' ��X �D��� Rs1
					Rs1.MoveFirst
					rescount = 0
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst


					' Array 1
					ReDim A1(rescount,7)

					' Populate Array 1
					Dim preNo, count
					preNo = ""
					count = 0
					for i = 0 to rescount - 1 step 1
						' �۰ʭp�� A ��: ���� - ��ܤ�k�G�G�񦹳B, �O�]�����n��ܤ��P����(�Y�ϦX������, �]�n�v�@�[�U�h; �٦� if�� A1(i,0) = "" �n disable)
						'A1(i,0) = count + 1
						'count = count + 1

						'Response.Write("cont_contno= " & Rs1("cont_contno").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")
						' �Y��ƭ���, �h���и�ƶ��M���Y�ǭ��и�ƶ�(�p�X���������)
						if Rs1("cont_contno").Value = preNo then
							' �H�U�����Ю�, ��ܭn�M�Ū���ƶ�
							A1(i,0) = ""
							A1(i,1) = ""
						else
							' �۰ʭp�� A ��: ���� - ��ܤ�k�@�G�񦹳B�h�O�Ȥ�n�D: �X�����Ъ�, �h����ܨ�ۦP������ (if�� A1(i,0) = "" �n enable)
							A1(i,0) = count + 1
							count = count + 1

							' �H�U���D���Ю�, �n��ܪ���ƶ�
							A1(i,1) = Rs1("cont_contno").Value
							A1(i,2) = Rs1("mfr_inm").Value
							A1(i,3) = Rs1("mtp_nm").Value
							A1(i,4) = Rs1("UnPubCounts").Value
						end if


						' �H�U���L�׭��лP�_, �@�w�n�X�{����ƶ�
						A1(i,2) = Rs1("mfr_inm").Value
						A1(i,3) = Rs1("mtp_nm").Value
						A1(i,4) = Rs1("UnPubCounts").Value
						preNo = Rs1("cont_contno").Value


						' �����S�O���ϥΪ��榡 (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �S�O�榡�g�b sheet 2 �����w����, �p A5, A6; B5, B6
						Dim Discounthighlight
						Discounthighlight =  "E" & (7+i)
						if (i mod 2) = 0 then
							' �_�Ʀ�, �H A8 �� �Ʀr Format ���
							XLS.FormatCells( 1, Discounthighlight, 2, "A8", false )
						else
							' ���Ʀ�, �H B8 �� �Ʀr Format ���
							XLS.FormatCells( 1, Discounthighlight, 2, "B8", false )
						end if

						' Highlight Some Rows: �����@�����ϥΪ��榡
						Dim highlight
						highlight = "A" & (7+i) & ":E" & (7+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false )
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )
						end if
						Rs1.MoveNext

						if Rs1.EOF
	    						exit for
						end if
					next

					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Set Estimated Output File Size (Critical for speed)
					XLS.EstimatedSize = 50000

					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )

					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bk_nm
					XLS.AddVariable("conttpText", strConttpText)	' >>$mfr_iname
					XLS.AddVariable("fgmoseaText", strfgmoseaText)	' >>$signdate
					XLS.AddVariable("mtpcdText", strMtpName)	' >>$sedate
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					'Response.Write("BkName= " & BkName & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("ORCounts_stat2b.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "ORCounts_stat2b.xls", True)

					' Destroy object when done
					XLS = Nothing

					' Cleanup Code - Close Connection and all Recordsets
					oConn.close
					oConn = Nothing
				End if
			%>
		</form>
	</body>
</HTML>
