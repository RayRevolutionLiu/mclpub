<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�s�Z�έp��</title>
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

				Dim Rs1, Rs2, Rs3, Rs4, Rs5		' Record Source 1 ~ 5
				Dim Rs9, Rs11, Rs12			' Record Source 9 ~ 12
				Dim sqlcmd1, sqlcmd2, sqlcmd3		' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5			' SQL Command 4 ~ 5
				Dim sqlcmd9, sqlcmd11, sqlcmd12		' SQL Command 9 ~ 12
				Dim rescountD, i	' rescountD= count of Rs2
				Dim rescountM, j	' rescountM= count of Rs3
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' �ۭq sql �ܼ�
				Dim strBkcd, strYYYYMM, strEmpNo

				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim strYYYYMMnew, BkPNo, EmpCName, BkName, strLoginEmpNo, strLoginEmpCName
				Dim TotalAmt, PaidAmt, RestAmt, ChgAmt


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
				Dim strSignDateBlock, strSEDateBlock, strfgclosedText
				strBkcd = Request("bkcd")
				strYYYYMM = Request("yyyymm")
				strEmpNo = Request("empno")
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

				' Get Rs4: �Ƿ~�ȭ��u����X�~�ȭ��m�W
				if(Request("empno") <> "") then
					strEmpNo = strEmpNo

					' Open the RecordSets
					sqlcmd4 = "SELECT * FROM srspn"
					sqlcmd4 = sqlcmd4 & " WHERE (srspn_empno='" + strEmpNo + "')"
					Rs4 = oConn.Execute(sqlcmd4)
					EmpCName = TRIM(Rs4("srspn_cname").Value)
					'Response.Write("EmpCName= " & EmpCName & "<br>")
				else
					strEmpNo = ""
					EmpCName = "(�Ҧ�)"
				end if

				' Get Rs9: �ǵn�J�~�ȭ��u����X�m�W
				if(Request("LEmpNo") <> "") then
					strLoginEmpNo = strLoginEmpNo

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


				' Get Rs2: ��X�ثe��Ʈw���`���� -- �D�� join ������
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & "SELECT         contno, pubseq, pgno, RTRIM(ltp_nm) AS ltp_nm, RTRIM(clr_nm) AS clr_nm, "
				sqlcmd2 = sqlcmd2 & " RTRIM(pgs_nm) AS pgs_nm, fgfixpg, RTRIM(mfr_inm) AS mfr_inm, fggot, "
				sqlcmd2 = sqlcmd2 & " njtpcd01, njtpcd02, njtpcd03, njtpcd04, njtpcd05, chgbk_nm, chgjno, chgjbkno, "
				sqlcmd2 = sqlcmd2 & " fgrechg, unfgrechg, origbk_nm, origjno, origjbkno, fgupdated, "
				sqlcmd2 = sqlcmd2 & " RTRIM(srspn_cname) AS srspn_cname "
				sqlcmd2 = sqlcmd2 & " FROM             dbo.wk_c2_rp2 INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_cont ON "
				sqlcmd2 = sqlcmd2 & " wk_c2_rp2.contno COLLATE Chinese_Taiwan_Stroke_CI_AS = c2_cont.cont_contno "
				'sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgclosed = '0') "
				'sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgpubed = '1') "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd2 = sqlcmd2 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				sqlcmd2 = sqlcmd2 & " ) DRIVERTBL "

				' Open the RecordSets
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescountD = 0
					Response.Write ("<FONT Color=Red><B>�d�ߵ��G - ���Ƭ� 0</B></FONT><BR>")
				else
					rescountD = Rs2(0).Value
				end if
				'Response.Write("rescountD= " & rescountD & "<br>")


				' Get Rs3: ��X�ثe��Ʈw���`���� -- �D��
				' Open the RecordSets
				sqlcmd3 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd3 = sqlcmd3 & " FROM             ( "
				sqlcmd3 = sqlcmd3 & " SELECT DISTINCT contno, empno "
				sqlcmd3 = sqlcmd3 & " FROM             wk_c2_rp2 "
				sqlcmd3 = sqlcmd3 & " WHERE         (1=1) "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd3 = sqlcmd3 & " AND (empno = '" & strEmpNo & "') "
				else
					sqlcmd3 = sqlcmd3
				end if
				sqlcmd3 = sqlcmd3 & " ) DRIVERTBL "

				' Open the RecordSets
				Rs3 = oConn.Execute(sqlcmd3)
				if Rs3.EOF then
					rescountM = 0
					Response.Write ("<FONT Color=Red><B>�d�ߵ��G - ���Ƭ� 0</B></FONT><BR>")
				else
					rescountM = Rs3(0).Value
				end if
				'Response.Write("rescountM= " & rescountM & "<br>")


				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				sqlcmd1 = "SELECT         contno, pubseq, pgno, RTRIM(ltp_nm) AS ltp_nm, RTRIM(clr_nm) AS clr_nm, "
				sqlcmd1 = sqlcmd1 & " RTRIM(pgs_nm) AS pgs_nm, fgfixpg, RTRIM(mfr_inm) AS mfr_inm, fggot, "
				sqlcmd1 = sqlcmd1 & " njtpcd01, njtpcd02, njtpcd03, njtpcd04, njtpcd05, chgbk_nm, chgjno, chgjbkno, "
				sqlcmd1 = sqlcmd1 & " fgrechg, unfgrechg, origbk_nm, origjno, origjbkno, fgupdated, "
				sqlcmd1 = sqlcmd1 & " RTRIM(srspn_cname) AS srspn_cname, clrcd, drafttp "
				sqlcmd1 = sqlcmd1 & " FROM             dbo.wk_c2_rp2 INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_cont ON "
				sqlcmd1 = sqlcmd1 & " wk_c2_rp2.contno COLLATE Chinese_Taiwan_Stroke_CI_AS = c2_cont.cont_contno "
				'sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgclosed = '0') "
				'sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgpubed = '1') "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd1 = sqlcmd1 & " AND (empno = '" & strEmpNo & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " ORDER BY lp_priorseq, pgno, "
				sqlcmd1 = sqlcmd1 & " contno, yyyymm DESC, pubseq "

				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)


				'------- �}�l��X���G ---
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("sqlcmd4= " & sqlcmd4 & "<br><br>")
					'Response.Write("Rs4= " & Rs4(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='��������'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='�^�W�@��'--></FORM><BR>")

				' �Y�����, �h��X�� ExcelSpeedGen
				else
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")

					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")


					' ��X �D��� Rs1
					Rs1.MoveFirst
					rescountD = 0
					Do while not Rs1.EOF
						rescountD = rescountD + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst


					' Array 1
					Dim rescountMD
					'rescountMD = rescountD + rescountM + 1
					rescountMD = rescountD + 3
					ReDim A1(rescountMD,25)
					'Response.Write("rescountMD= " & rescountMD & "<br>")

					' Populate Array 1
					Dim preClrcd, preNo, count, X
					Dim countClrcd, sum_pubcount, sum_total
					Dim sum_njtpcd01, sum_njtpcd02, sum_njtpcd03, sum_njtpcd04, sum_njtpcd05
					Dim sum_fgrechg, sum_unfgrechg, sum_fgupdated
					Dim Total_njtpcd01, Total_njtpcd02, Total_njtpcd03, Total_njtpcd04, Total_njtpcd05
					Dim Total_fgrechg, Total_unfgrechg, Total_fgupdated
					' ��X�`�p
					Dim Total_chg, Total_njtp, Total_Sum
					preNo = ""
					count = 0
					X = 0
					countClrcd = 1
					sum_pubcount = 0
					sum_total = 0
					sum_njtpcd01 = 0
					sum_njtpcd02 = 0
					sum_njtpcd03 = 0
					sum_njtpcd04 = 0
					sum_njtpcd05 = 0
					sum_fgrechg = 0
					sum_unfgrechg = 0
					sum_fgupdated = 0
					Total_njtpcd01 = 0
					Total_njtpcd02 = 0
					Total_njtpcd03 = 0
					Total_njtpcd04 = 0
					Total_njtpcd05 = 0
					Total_fgrechg = 0
					Total_unfgrechg = 0
					Total_fgupdated = 0
					for i = 0 to rescountD - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("X= " & X & "<BR>")
						'Response.Write("count= " & count & ", ")
						'Response.Write("clrcd= " & Rs1("clrcd").Value & "<br>")
						'Response.Write("contno= " & Rs1("contno").Value & "<br>")
						'Response.Write("preClrcd= " & preClrcd & "<br><br>")
						'Response.Write("preNo= " & preNo & "<br><br>")

						' �Y�P�W�@����Ƥ��X���s�����P, �h�������
						if (Rs1("clrcd").Value <> preClrcd) then
							if(X <> 0) then
								A1(X,0) = ""
								A1(X,1) = "----------"
								A1(X,2) = "-----"
								A1(X,3) = "-----"
								A1(X,4) = "�p�p�G"
								A1(X,5) = sum_total
								A1(X,6) = "-----"
								A1(X,7) = "-----"
								A1(X,8) = "----------------------------------------"
								A1(X,9) = "-----"
								A1(X,10) = sum_njtpcd01
								A1(X,11) = sum_njtpcd02
								A1(X,12) = sum_njtpcd03
								A1(X,13) = sum_njtpcd04
								A1(X,14) = sum_njtpcd05
								A1(X,15) = "-----"
								A1(X,16) = "-----"
								A1(X,17) = "-----"
								A1(X,18) = sum_fgrechg
								A1(X,19) = sum_unfgrechg
								A1(X,20) = "-----"
								A1(X,21) = "-----"
								A1(X,22) = "-----"
								A1(X,23) = sum_fgupdated
								A1(X,24) = "----------"
								X = X + 1
							end if


							' �p�p���s�k�s
							countClrcd = 1
							sum_pubcount = 0
							sum_total = 0
							sum_njtpcd01 = 0
							sum_njtpcd02 = 0
							sum_njtpcd03 = 0
							sum_njtpcd04 = 0
							sum_njtpcd05 = 0
							sum_fgrechg = 0
							sum_unfgrechg = 0
							sum_fgupdated = 0


							' �Y�P�W�@����Ƥ��X���s�����P, �h�������
							if (Rs1("contno").Value <> preNo) then
								' �������
								A1(X,0) = count + 1
								count = count + 1
								'Response.Write("count= " & count & ", ")

								A1(X,1) = Rs1("contno").Value
								A1(X,2) = Rs1("pubseq").Value
								A1(X,3) = Rs1("pgno").Value
								A1(X,4) = Rs1("ltp_nm").Value
								A1(X,5) = Rs1("clr_nm").Value
								A1(X,6) = Rs1("pgs_nm").Value
								A1(X,7) = Rs1("fgfixpg").Value
								A1(X,8) = Rs1("mfr_inm").Value
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,9) = Rs1("fggot").Value
								else
									A1(X,9) = ""
								end if
								if(Rs1("drafttp").Value = "2") Then
									A1(X,10) = Rs1("njtpcd01").Value
									A1(X,11) = Rs1("njtpcd02").Value
									A1(X,12) = Rs1("njtpcd03").Value
									A1(X,13) = Rs1("njtpcd04").Value
									A1(X,14) = Rs1("njtpcd05").Value
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
								end if
								if(Rs1("drafttp").Value = "3") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = Rs1("chgbk_nm").Value
									A1(X,16) = Rs1("chgjno").Value
									A1(X,17) = Rs1("chgjbkno").Value
									A1(X,18) = Rs1("fgrechg").Value
									A1(X,19) = Rs1("unfgrechg").Value
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
								end if
								if(Rs1("drafttp").Value = "1") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = Rs1("origbk_nm").Value
									A1(X,21) = Rs1("origjno").Value
									A1(X,22) = Rs1("origjbkno").Value
								else
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								end if
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,23) = Rs1("fgupdated").Value
								else
									A1(X,23) = ""
								end if
								A1(X,24) = Rs1("srspn_cname").Value
								sum_pubcount = countClrcd
								sum_njtpcd01 = sum_njtpcd01 + Rs1("njtpcd01").Value
								sum_njtpcd02 = sum_njtpcd02 + Rs1("njtpcd02").Value
								sum_njtpcd03 = sum_njtpcd03 + Rs1("njtpcd03").Value
								sum_njtpcd04 = sum_njtpcd04 + Rs1("njtpcd04").Value
								sum_njtpcd05 = sum_njtpcd05 + Rs1("njtpcd05").Value
								sum_fgrechg = sum_fgrechg + Rs1("fgrechg").Value
								sum_unfgrechg = sum_unfgrechg + Rs1("unfgrechg").Value
								sum_fgupdated = sum_fgupdated + Rs1("fgupdated").Value
								' sum_total (���t sum_unfgrechg, ����L sum_xxx ���[�`)
								sum_total = sum_njtpcd01 + sum_njtpcd02 + sum_njtpcd03 + sum_njtpcd04 + sum_njtpcd05 + sum_fgrechg + sum_fgupdated
								X = X + 1

							' �Y�P�W�@����Ƥ��X���s���ۦP -- �M���e������������(�p�X���s��)
							else
								A1(X,0) = ""
								A1(X,1) = ""
								A1(X,2) = Rs1("pubseq").Value
								A1(X,3) = Rs1("pgno").Value
								A1(X,4) = Rs1("ltp_nm").Value
								A1(X,5) = Rs1("clr_nm").Value
								A1(X,6) = Rs1("pgs_nm").Value
								A1(X,7) = Rs1("fgfixpg").Value
								A1(X,8) = Rs1("mfr_inm").Value
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,9) = Rs1("fggot").Value
								else
									A1(X,9) = ""
								end if
								if(Rs1("drafttp").Value = "2") Then
									A1(X,10) = Rs1("njtpcd01").Value
									A1(X,11) = Rs1("njtpcd02").Value
									A1(X,12) = Rs1("njtpcd03").Value
									A1(X,13) = Rs1("njtpcd04").Value
									A1(X,14) = Rs1("njtpcd05").Value
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
								end if
								if(Rs1("drafttp").Value = "3") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = Rs1("chgbk_nm").Value
									A1(X,16) = Rs1("chgjno").Value
									A1(X,17) = Rs1("chgjbkno").Value
									A1(X,18) = Rs1("fgrechg").Value
									A1(X,19) = Rs1("unfgrechg").Value
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
								end if
								if(Rs1("drafttp").Value = "1") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = Rs1("origbk_nm").Value
									A1(X,21) = Rs1("origjno").Value
									A1(X,22) = Rs1("origjbkno").Value
								else
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								end if
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,23) = Rs1("fgupdated").Value
								else
									A1(X,23) = ""
								end if
								A1(X,24) = Rs1("srspn_cname").Value
								sum_pubcount = countClrcd
								sum_njtpcd01 = sum_njtpcd01 + Rs1("njtpcd01").Value
								sum_njtpcd02 = sum_njtpcd02 + Rs1("njtpcd02").Value
								sum_njtpcd03 = sum_njtpcd03 + Rs1("njtpcd03").Value
								sum_njtpcd04 = sum_njtpcd04 + Rs1("njtpcd04").Value
								sum_njtpcd05 = sum_njtpcd05 + Rs1("njtpcd05").Value
								sum_fgrechg = sum_fgrechg + Rs1("fgrechg").Value
								sum_unfgrechg = sum_unfgrechg + Rs1("unfgrechg").Value
								sum_fgupdated = sum_fgupdated + Rs1("fgupdated").Value
								' sum_total (���t sum_unfgrechg, ����L sum_xxx ���[�`)
								sum_total = sum_njtpcd01 + sum_njtpcd02 + sum_njtpcd03 + sum_njtpcd04 + sum_njtpcd05 + sum_fgrechg + sum_fgupdated
								X = X + 1
							end if
						' �Y�s�i��m�ۦP��, ��X���e, ������X�p�p
						else
							countClrcd = countClrcd + 1


							' �Y�P�W�@����Ƥ��X���s�����P, �h�������
							if (Rs1("contno").Value <> preNo) then
								' �������
								A1(X,0) = count + 1
								count = count + 1
								'Response.Write("count= " & count & ", ")

								A1(X,1) = Rs1("contno").Value
								A1(X,2) = Rs1("pubseq").Value
								A1(X,3) = Rs1("pgno").Value
								A1(X,4) = Rs1("ltp_nm").Value
								A1(X,5) = Rs1("clr_nm").Value
								A1(X,6) = Rs1("pgs_nm").Value
								A1(X,7) = Rs1("fgfixpg").Value
								A1(X,8) = Rs1("mfr_inm").Value
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,9) = Rs1("fggot").Value
								else
									A1(X,9) = ""
								end if
								if(Rs1("drafttp").Value = "2") Then
									A1(X,10) = Rs1("njtpcd01").Value
									A1(X,11) = Rs1("njtpcd02").Value
									A1(X,12) = Rs1("njtpcd03").Value
									A1(X,13) = Rs1("njtpcd04").Value
									A1(X,14) = Rs1("njtpcd05").Value
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
								end if
								if(Rs1("drafttp").Value = "3") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = Rs1("chgbk_nm").Value
									A1(X,16) = Rs1("chgjno").Value
									A1(X,17) = Rs1("chgjbkno").Value
									A1(X,18) = Rs1("fgrechg").Value
									A1(X,19) = Rs1("unfgrechg").Value
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
								end if
								if(Rs1("drafttp").Value = "1") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = Rs1("origbk_nm").Value
									A1(X,21) = Rs1("origjno").Value
									A1(X,22) = Rs1("origjbkno").Value
								else
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								end if
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,23) = Rs1("fgupdated").Value
								else
									A1(X,23) = ""
								end if
								A1(X,24) = Rs1("srspn_cname").Value
								sum_pubcount = countClrcd
								sum_njtpcd01 = sum_njtpcd01 + Rs1("njtpcd01").Value
								sum_njtpcd02 = sum_njtpcd02 + Rs1("njtpcd02").Value
								sum_njtpcd03 = sum_njtpcd03 + Rs1("njtpcd03").Value
								sum_njtpcd04 = sum_njtpcd04 + Rs1("njtpcd04").Value
								sum_njtpcd05 = sum_njtpcd05 + Rs1("njtpcd05").Value
								sum_fgrechg = sum_fgrechg + Rs1("fgrechg").Value
								sum_unfgrechg = sum_unfgrechg + Rs1("unfgrechg").Value
								sum_fgupdated = sum_fgupdated + Rs1("fgupdated").Value
								' sum_total (���t sum_unfgrechg, ����L sum_xxx ���[�`)
								sum_total = sum_njtpcd01 + sum_njtpcd02 + sum_njtpcd03 + sum_njtpcd04 + sum_njtpcd05 + sum_fgrechg + sum_fgupdated
								X = X + 1

							' �Y�P�W�@����Ƥ��X���s���ۦP -- �M���e������������(�p�X���s��)
							else
								A1(X,0) = ""
								A1(X,1) = ""
								A1(X,2) = Rs1("pubseq").Value
								A1(X,3) = Rs1("pgno").Value
								A1(X,4) = Rs1("ltp_nm").Value
								A1(X,5) = Rs1("clr_nm").Value
								A1(X,6) = Rs1("pgs_nm").Value
								A1(X,7) = Rs1("fgfixpg").Value
								A1(X,8) = Rs1("mfr_inm").Value
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,9) = Rs1("fggot").Value
								else
									A1(X,9) = ""
								end if
								if(Rs1("drafttp").Value = "2") Then
									A1(X,10) = Rs1("njtpcd01").Value
									A1(X,11) = Rs1("njtpcd02").Value
									A1(X,12) = Rs1("njtpcd03").Value
									A1(X,13) = Rs1("njtpcd04").Value
									A1(X,14) = Rs1("njtpcd05").Value
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
								end if
								if(Rs1("drafttp").Value = "3") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = Rs1("chgbk_nm").Value
									A1(X,16) = Rs1("chgjno").Value
									A1(X,17) = Rs1("chgjbkno").Value
									A1(X,18) = Rs1("fgrechg").Value
									A1(X,19) = Rs1("unfgrechg").Value
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								else
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
								end if
								if(Rs1("drafttp").Value = "1") Then
									A1(X,10) = ""
									A1(X,11) = ""
									A1(X,12) = ""
									A1(X,13) = ""
									A1(X,14) = ""
									A1(X,15) = ""
									A1(X,16) = ""
									A1(X,17) = ""
									A1(X,18) = ""
									A1(X,19) = ""
									A1(X,20) = Rs1("origbk_nm").Value
									A1(X,21) = Rs1("origjno").Value
									A1(X,22) = Rs1("origjbkno").Value
								else
									A1(X,20) = ""
									A1(X,21) = ""
									A1(X,22) = ""
								end if
								if(Rs1("drafttp").Value = "2" OR Rs1("drafttp").Value = "3") Then
									A1(X,23) = Rs1("fgupdated").Value
								else
									A1(X,23) = ""
								end if
								A1(X,24) = Rs1("srspn_cname").Value
								sum_pubcount = countClrcd
								sum_njtpcd01 = sum_njtpcd01 + Rs1("njtpcd01").Value
								sum_njtpcd02 = sum_njtpcd02 + Rs1("njtpcd02").Value
								sum_njtpcd03 = sum_njtpcd03 + Rs1("njtpcd03").Value
								sum_njtpcd04 = sum_njtpcd04 + Rs1("njtpcd04").Value
								sum_njtpcd05 = sum_njtpcd05 + Rs1("njtpcd05").Value
								sum_fgrechg = sum_fgrechg + Rs1("fgrechg").Value
								sum_unfgrechg = sum_unfgrechg + Rs1("unfgrechg").Value
								sum_fgupdated = sum_fgupdated + Rs1("fgupdated").Value
								' sum_total (���t sum_unfgrechg, ����L sum_xxx ���[�`)
								sum_total = sum_njtpcd01 + sum_njtpcd02 + sum_njtpcd03 + sum_njtpcd04 + sum_njtpcd05 + sum_fgrechg + sum_fgupdated
								X = X + 1
							end if
						end if

						' ���w �P�_��, �n�P�U�@����Ƭۤ��
						preClrcd = Rs1("clrcd").Value
						preNo = Rs1("contno").Value
						'Response.Write("preClrcd= " & preClrcd & ", ")
						'Response.Write("preNo= " & preNo & ", ")
						'Response.Write("sum_total= " & sum_total & ", ")
						'Response.Write("sum_njtpcd01= " & sum_njtpcd01 & ", ")


						' �`�p -- for ��ӳ���, �N���ȿ�X���ܼ�
						Total_njtpcd01 = Total_njtpcd01 + Rs1("njtpcd01").Value
						Total_njtpcd02 = Total_njtpcd02 + Rs1("njtpcd02").Value
						Total_njtpcd03 = Total_njtpcd03 + Rs1("njtpcd03").Value
						Total_njtpcd04 = Total_njtpcd04 + Rs1("njtpcd04").Value
						Total_njtpcd05 = Total_njtpcd05 + Rs1("njtpcd05").Value
						Total_fgrechg = Total_fgrechg + Rs1("fgrechg").Value
						Total_unfgrechg = Total_unfgrechg + Rs1("unfgrechg").Value
						Total_fgupdated = Total_fgupdated + Rs1("fgupdated").Value
						Total_chg = CINT(Total_fgrechg)
						Total_njtp = CINT(Total_njtpcd01) + CINT(Total_njtpcd02) + CINT(Total_njtpcd03) + CINT(Total_njtpcd04) + CINT(Total_njtpcd05)
						Total_Sum = CINT(Total_chg) + CINT(Total_njtp) + CINT(Total_fgupdated)
						'Response.Write("sum_njtpcd01= " & sum_njtpcd01 & ", ")
						'Response.Write("Total_Sum= " & Total_Sum & "<br>")


						'Dim highlight2, highlight3, highlight4, highlight5
						' Highlight Some Rows: �����S�O���ϥΪ��榡 A2/B2 (���B�O���m���B�z; �S�O�榡�g�b sheet 2 �����w����)
						' �S�O��� (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �`�N FormatCells �S�O��� ���{���X�@�w�n��b FormatCells �@����쪺�{���X "�e��", �_�h�S�O���L�k���
						'highlight2 = "A" & (7+X) & ":T" & (7+X)
						'highlight3 = "F" & (7+X)
						'if (X mod 2) = 0
							'XLS.FormatCells( 1, highlight2, 2, "A10", false )
							'XLS.FormatCells( 1, highlight3, 2, "A10", false )
						'else
							'XLS.FormatCells( 1, highlight2, 2, "B10", false )
							'XLS.FormatCells( 1, highlight3, 2, "B10", false )
						'end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")


						Dim highlight
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (7+X) & ":T" & (7+X)
						'if (X mod 2) = 0
							'XLS.FormatCells( 1, highlight, 2, "A1", false )
						'else
							'XLS.FormatCells( 1, highlight, 2, "B1", false )
						'end if
						'Response.Write("highlight= " & highlight & "<br>")


						Rs1.MoveNext

						if Rs1.EOF
	    						exit for
						end if
					next


					' �`�p -- for �̫�@����� (�]���ɤw���� Rs1.MoveLast)
					A1(X,0) = ""
					A1(X,1) = "----------"
					A1(X,2) = "-----"
					A1(X,3) = "-----"
					A1(X,4) = "�p�p�G"
					A1(X,5) = sum_total
					A1(X,6) = "-----"
					A1(X,7) = "-----"
					A1(X,8) = "----------------------------------------"
					A1(X,9) = "-----"
					A1(X,10) = sum_njtpcd01
					A1(X,11) = sum_njtpcd02
					A1(X,12) = sum_njtpcd03
					A1(X,13) = sum_njtpcd04
					A1(X,14) = sum_njtpcd05
					A1(X,15) = "-----"
					A1(X,16) = "-----"
					A1(X,17) = "-----"
					A1(X,18) = sum_fgrechg
					A1(X,19) = sum_unfgrechg
					A1(X,20) = "-----"
					A1(X,21) = "-----"
					A1(X,22) = "-----"
					A1(X,23) = sum_fgupdated
					A1(X,24) = "----------"


					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bkp_pno
					XLS.AddVariable("Total_chg", Total_chg)		' >>$Total_chg
					XLS.AddVariable("Total_njtpcd", Total_njtp)	' >>$Total_njtpcd
					XLS.AddVariable("Total_Sum", Total_Sum)		' >>$Total_Sum
					XLS.AddVariable("n1", Total_njtpcd01)		' >>$n1
					XLS.AddVariable("n2", Total_njtpcd02)		' >>$n2
					XLS.AddVariable("n3", Total_njtpcd03)		' >>$n3
					XLS.AddVariable("n4", Total_njtpcd04)		' >>$n4
					XLS.AddVariable("n5", Total_njtpcd05)		' >>$n5
					XLS.AddVariable("Total_fgrechg", Total_fgrechg)		' >>$Total_fgrechg
					XLS.AddVariable("Total_fgunrechg", Total_unfgrechg)	' >>$Total_fgunrechg
					XLS.AddVariable("Total_fgupdated", Total_fgupdated)	' >>$Total_fgupdated
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("admade_stat2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "admade_stat2.xls", True)

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
