<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�O���ˬd�M��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="ormtpcount2_stat2a" method="post" runat="server">
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
				Dim dbFile          ' Database File
				Dim oConn           ' ADO Connection object
				Dim DSN				' Web Application Name

				Dim Rs1, Rs2, Rs3, Rs4, Rs5, Rs6, Rs7		' Record Source 1 ~ 7
				Dim Rs9, Rs10					' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2, sqlcmd3			' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6, sqlcmd7		' SQL Command 4 ~ 7
				Dim sqlcmd9, sqlcmd10				' SQL Command 9 ~ 10
				Dim rescountD, i	' rescountD= count of Rs2
				Dim rescountM, j	' rescountM= count of Rs3
				Dim A1, A7		' Array A1, A7

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' �ۭq sql �ܼ�
				Dim strYYYYMM, strBkcd, strEmpNo

				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim strYYYYMMnew, BkPNo, EmpCName, BkName, strLoginEmpNo, strLoginEmpCName


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
				strYYYYMM = Request("yyyymm")
				strBkcd = Request("bkcd")
				BkPNo = ""
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

				if(strBkcd <> "") then
					strBkcd = strBkcd

					' Get Rs5: �Ǯ��y�N�X��X���y�W��
					' Open the RecordSets
					sqlcmd5 = "SELECT * FROM book"
					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
					Rs5 = oConn.Execute(sqlcmd5)
					BkName = Trim(Rs5("bk_nm").Value)
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
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
				'Response.Write("strBkcd= " & strBkcd & "<br>")
				'Response.Write("strEmpNo= " & strEmpNo & "<br>")
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")


				' Get Rs2: ��X�ثe��Ʈw���`���� -- �D�� join ������
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno, c2_cont.cont_bkcd, c2_cont.cont_empno, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(mfr.mfr_inm) "
				sqlcmd2 = sqlcmd2 & " AS mfr_inm, RTRIM(mfr.mfr_izip) AS mfr_izip, RTRIM(mfr.mfr_iaddr) "
				sqlcmd2 = sqlcmd2 & " AS mfr_iaddr, RTRIM(mfr.mfr_izip) + ' ' + RTRIM(mfr.mfr_iaddr) "
				sqlcmd2 = sqlcmd2 & " AS mfr_iFullAddr, RTRIM(srspn.srspn_cname) AS srspn_cname, "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_contno, c2_pub.pub_yyyymm, c2_pub.pub_pubseq, "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_clrcd, c2_pub.pub_ltpcd, c2_pub.pub_pgscd, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_ltp.ltp_nm) AS ltp_nm, RTRIM(c2_clr.clr_nm) AS clr_nm, "
				sqlcmd2 = sqlcmd2 & " RTRIM(c2_pgsize.pgs_nm) AS pgs_nm, c2_pub.pub_adamt, "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_chgamt, "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_adamt + c2_pub.pub_chgamt AS pub_totamt, "
				sqlcmd2 = sqlcmd2 & " iad.iad_iano "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " srspn ON c2_cont.cont_empno = srspn.srspn_empno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_pgsize ON "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN "
				sqlcmd2 = sqlcmd2 & " iad ON c2_pub.pub_syscd = iad.iad_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_contno = iad.iad_fk1 AND "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_yyyymm = iad.iad_fk2 AND "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_pubseq = iad.iad_fk3 "
				sqlcmd2 = sqlcmd2 & " WHERE (1=1) "
				'sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgclosed = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				'sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgpubed = '1') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				sqlcmd2 = sqlcmd2 & " AND (c2_pub.pub_yyyymm = '" & strYYYYMM & "') "
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
				sqlcmd3 = sqlcmd3 & " SELECT         TOP 100 PERCENT c2_cont.cont_contno, c2_cont.cont_bkcd, "
				sqlcmd3 = sqlcmd3 & " c2_cont.cont_empno, c2_pub.pub_pubseq "
				sqlcmd3 = sqlcmd3 & " FROM             c2_cont INNER JOIN "
				sqlcmd3 = sqlcmd3 & " c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd3 = sqlcmd3 & " c2_cont.cont_contno = c2_pub.pub_contno "
				sqlcmd3 = sqlcmd3 & " WHERE (1=1) "
				'sqlcmd3 = sqlcmd3 & " AND (c2_cont.cont_fgclosed = '0') "
				sqlcmd3 = sqlcmd3 & " AND (c2_cont.cont_fgtemp = '0') "
				'sqlcmd3 = sqlcmd3 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd3 = sqlcmd3 & " AND (c2_cont.cont_fgpubed = '1') "
				sqlcmd3 = sqlcmd3 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				sqlcmd3 = sqlcmd3 & " AND (c2_pub.pub_yyyymm = '" & strYYYYMM & "') "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd3 = sqlcmd3 & " AND (cont_empno = '" & strEmpNo & "') "
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
				sqlcmd1 = " SELECT DISTINCT "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno, c2_cont.cont_bkcd, c2_cont.cont_empno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(mfr.mfr_inm) "
				sqlcmd1 = sqlcmd1 & " AS mfr_inm, RTRIM(mfr.mfr_izip) AS mfr_izip, RTRIM(mfr.mfr_iaddr) "
				sqlcmd1 = sqlcmd1 & " AS mfr_iaddr, RTRIM(mfr.mfr_izip) + ' ' + RTRIM(mfr.mfr_iaddr) "
				sqlcmd1 = sqlcmd1 & " AS mfr_iFullAddr, RTRIM(srspn.srspn_cname) AS srspn_cname, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_contno, c2_pub.pub_yyyymm, c2_pub.pub_pubseq, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_clrcd, c2_pub.pub_ltpcd, c2_pub.pub_pgscd, "
				sqlcmd1 = sqlcmd1 & " RTRIM(c2_ltp.ltp_nm) AS ltp_nm, RTRIM(c2_clr.clr_nm) AS clr_nm, "
				sqlcmd1 = sqlcmd1 & " RTRIM(c2_pgsize.pgs_nm) AS pgs_nm, c2_pub.pub_adamt, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_chgamt, "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_adamt + c2_pub.pub_chgamt AS pub_totamt, "
				sqlcmd1 = sqlcmd1 & " iad.iad_iano "
				sqlcmd1 = sqlcmd1 & " FROM             c2_cont INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " srspn ON c2_cont.cont_empno = srspn.srspn_empno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_pgsize ON "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN "
				sqlcmd1 = sqlcmd1 & " iad ON c2_pub.pub_syscd = iad.iad_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_contno = iad.iad_fk1 AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_yyyymm = iad.iad_fk2 AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_pubseq = iad.iad_fk3 "
				sqlcmd1 = sqlcmd1 & " WHERE (1=1) "
				'sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgclosed = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgtemp = '0') "
				'sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgpubed = '1') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_bkcd = '" & strBkcd & "') "
				sqlcmd1 = sqlcmd1 & " AND (c2_pub.pub_yyyymm = '" & strYYYYMM & "') "
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " ORDER BY  dbo.c2_cont.cont_contno "
				'Response.Write("sqlcmd1= " & sqlcmd1 & "<br>")


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
					'Response.Write("sqlcmd9= " & sqlcmd9 & "<br><br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")
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
					rescountMD = rescountD + rescountM + 1
					ReDim A1(rescountMD,14)
					'Response.Write("rescountMD= " & rescountMD & "<br>")

					' Populate Array 1
					Dim preNo, count, countPub, X
					Dim sum_AdAmt, sum_ChgAmt, sum_TotAmt, sum_Counts
					Dim TotalAdAmt, TotalChgAmt, TotalAmt, TotalCounts
					preNo = ""
					count = 0
					countPub = 1
					X = 0
					sum_AdAmt = 0
					sum_ChgAmt = 0
					sum_TotAmt = 0
					sum_Counts = 0
					TotalAdAmt = 0
					TotalChgAmt = 0
					TotalAmt = 0
					TotalCounts = 0
					for i = 0 to rescountD - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("X= " & X & "<BR>")
						'Response.Write("count= " & count & ", ")
						'Response.Write("cont_contno= " & Rs1("cont_contno").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")

						' �Y�P�W�@����Ƥ��X���s�����P, �h�������
						if (Rs1("cont_contno").Value <> preNo) then
							' ��X �p�p
							if(X <> 0) then
								A1(X,0) = ""
								A1(X,1) = "----------"
								A1(X,2) = "-----"
								A1(X,3) = "-----"
								A1(X,4) = "-----"
								A1(X,5) = "-----"
								A1(X,6) = "---------------"
								A1(X,7) = "-----------------------------------"
								A1(X,8) = sum_Counts & " ������  �p�p�G"
								A1(X,9) = ""
								A1(X,10) = sum_AdAmt
								A1(X,11) = sum_ChgAmt
								A1(X,12) = sum_TotAmt
								A1(X,13) = "---------------"
								X = X + 1
							end if


							' �������
							A1(X,0) = count + 1
							count = count + 1
							'Response.Write("count= " & count & ", ")

							' �p�p���s�k�s
							countPub = 1

							A1(X,1) = Rs1("cont_contno").Value
							A1(X,2) = Rs1("pub_pubseq").Value
							A1(X,3) = Rs1("ltp_nm").Value
							A1(X,4) = Rs1("clr_nm").Value
							A1(X,5) = Rs1("pgs_nm").Value
							A1(X,6) = Rs1("cont_mfrno").Value
							A1(X,7) = Rs1("mfr_inm").Value
							A1(X,8) = Rs1("mfr_iFullAddr").Value
							A1(X,9) = Rs1("srspn_cname").Value
							A1(X,10) = Rs1("pub_adamt").Value
							A1(X,11) = Rs1("pub_chgamt").Value
							A1(X,12) = Rs1("pub_totamt").Value
							A1(X,13) = Rs1("iad_iano").Value
							sum_AdAmt = Rs1("pub_adamt").Value
							sum_ChgAmt = Rs1("pub_chgamt").Value
							sum_TotAmt = Rs1("pub_totamt").Value
							sum_Counts = countPub
							X = X + 1

						' �Y�P�W�@����Ƥ��X���s���ۦP -- �M���e������������(�p�X��+�o�t�������)
						else
							countPub = countPub + 1

							A1(X,0) = ""
							A1(X,1) = ""
							A1(X,2) = Rs1("pub_pubseq").Value
							A1(X,3) = Rs1("ltp_nm").Value
							A1(X,4) = Rs1("clr_nm").Value
							A1(X,5) = Rs1("pgs_nm").Value
							A1(X,6) = Rs1("cont_mfrno").Value
							A1(X,7) = Rs1("mfr_inm").Value
							A1(X,8) = Rs1("mfr_iFullAddr").Value
							A1(X,9) = Rs1("srspn_cname").Value
							A1(X,10) = Rs1("pub_adamt").Value
							A1(X,11) = Rs1("pub_chgamt").Value
							A1(X,12) = Rs1("pub_totamt").Value
							A1(X,13) = Rs1("iad_iano").Value
							sum_AdAmt = sum_AdAmt + Rs1("pub_adamt").Value
							sum_ChgAmt = sum_ChgAmt + Rs1("pub_chgamt").Value
							sum_TotAmt = sum_TotAmt + Rs1("pub_totamt").Value
							sum_Counts = countPub
							X = X + 1
						end if

						' ���w �P�_��, �n�P�U�@����Ƭۤ��
						preNo = Rs1("cont_contno").Value
						'Response.Write("preNo= " & preNo & ", ")
						'Response.Write("sum_AdAmt= " & sum_AdAmt & ", ")
						'Response.Write("sum_ChgAmt= " & sum_ChgAmt & ", ")
						'Response.Write("sum_Counts= " & sum_Counts & "<br>")


						' �`�p -- for ��ӳ���, �N���ȿ�X���ܼ�
						TotalAdAmt = TotalAdAmt + Rs1("pub_adamt").Value
						TotalChgAmt = TotalChgAmt + Rs1("pub_chgamt").Value
						TotalAmt = TotalAmt + Rs1("pub_totamt").Value
						TotalCounts = countPub
						'Response.Write("TotalAdAmt= " & TotalAdAmt & ", ")
						'Response.Write("TotalChgAmt= " & TotalChgAmt & ", ")
						'Response.Write("TotalAmt= " & TotalAmt & ", ")
						'Response.Write("TotalCounts= " & TotalCounts & "<br>")


						Dim highlight2, highlight3, highlight4, highlight5
						' Highlight Some Rows: �����S�O���ϥΪ��榡 A2/B2 (���B�O���m���B�z; �S�O�榡�g�b sheet 2 �����w����)
						' �S�O��� (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �`�N FormatCells �S�O��� ���{���X�@�w�n��b FormatCells �@����쪺�{���X "�e��", �_�h�S�O���L�k���
						highlight2 = "E" & (7+X)
						highlight3 = "F" & (7+X)
						'if (X mod 2) = 0
							'XLS.FormatCells( 1, highlight2, 2, "A8", false )
							'XLS.FormatCells( 1, highlight3, 2, "A8", false )
						'else
							'XLS.FormatCells( 1, highlight2, 2, "B8", false )
							'XLS.FormatCells( 1, highlight3, 2, "B8", false )
						'end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")


						Dim highlight
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (7+X) & ":F" & (7+X)
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
					A1(X,4) = "-----"
					A1(X,5) = "-----"
					A1(X,6) = "---------------"
					A1(X,7) = "-----------------------------------"
					A1(X,8) = sum_Counts & " ������  �p�p�G"
					A1(X,9) = ""
					A1(X,10) = sum_AdAmt
					A1(X,11) = sum_ChgAmt
					A1(X,12) = sum_TotAmt
					A1(X,13) = "---------------"
					X = X + 1


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
					XLS.AddVariable("TotalAdAmt", TotalAdAmt)	' >>$TotalAdAmt
					XLS.AddVariable("TotalChgAmt", TotalChgAmt)	' >>$TotalChgAmt
					XLS.AddVariable("TotalAmt", TotalAmt)		' >>$TotalAmt
					XLS.AddVariable("TotalCounts", TotalCounts)	' >>$TotalCounts
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("adamt_list2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "adamt_list2.xls", True)

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
