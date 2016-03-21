<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�L�s���Ʋέp�� ���Z�n</title>
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
				Dim strConttp, strYYYYMM, strBkcd, strEmpNo, strfgmosea, strMailtp

				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim strconttpText, strYYYYMMnew, BkPNo, EmpCName, BkName, strLoginEmpNo, strLoginEmpCName
				Dim strfgmoseaText, strmailtpText


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
				strConttp = Request("conttp")
				strYYYYMM = Request("yyyymm")
				strBkcd = Request("bkcd")
				strfgmosea = Request("fgmosea")
				strMailtp = Request("mailtp")
				BkPNo = ""
				strLoginEmpNo = Request("LEmpNo")
				if(Trim(strConttp) <> "") Then
					if(Trim(strConttp) = "01") Then
						strconttpText = "�@��"
					end if
					if(Trim(strConttp) = "09") Then
						strconttpText = "���s"
					end if
				else
					strconttpText = "���M��"
				end if

				if(Trim(strfgmosea) <> "") Then
					if(Trim(strfgmosea) = "0") Then
						strfgmoseaText = "�ꤺ"
					end if
					if(Trim(strfgmosea) = "1") Then
						strfgmoseaText = "��~"
					end if
				else
					strfgmoseaText = "�ꤺ�~"
				end if

				if(Trim(strMailtp) <> "") Then
					if(Trim(strMailtp) = "0") Then
						strmailtpText = "�j�v�l�H"
					end if
					if(Trim(strMailtp) = "1") Then
						strmailtpText = "���o�Ǹg��"
					end if
				else
					strmailtpText = "���M��"
				end if

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
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
				'Response.Write("strBkcd= " & strBkcd & "<br>")
				'Response.Write("strEmpNo= " & strEmpNo & "<br>")
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")


				' Get Rs2: ��X�ثe��Ʈw���`���� -- �D�� join ������
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT DISTINCT c2_cont.cont_conttp, "
				sqlcmd2 = sqlcmd2 & " CASE WHEN cont_conttp = '01' THEN '�@��' ELSE '���s' END AS cont_conttpName, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_bkcd, book.bk_nm, c2_or.or_mtpcd, "
				sqlcmd2 = sqlcmd2 & " mtp.mtp_nm, c2_or.or_pubcnt, COUNT(c2_or.or_pubcnt) "
				sqlcmd2 = sqlcmd2 & " AS PubCounts, c2_or.or_fgmosea, c2_pub.pub_yyyymm,"
				sqlcmd2 = sqlcmd2 & " bookp.bkp_pno, c2_or.or_pubcnt * COUNT(c2_or.or_pubcnt) "
				sqlcmd2 = sqlcmd2 & " AS SumCounts "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_or ON c2_pub.pub_syscd = c2_or.or_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_contno = c2_or.or_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " bookp ON c2_pub.pub_yyyymm = bookp.bkp_date AND "
				sqlcmd2 = sqlcmd2 & " c2_pub.pub_bkcd = bookp.bkp_bkcd "
				sqlcmd2 = sqlcmd2 & " WHERE (1=1) "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgclosed = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_or.or_unpubcnt > 0) "
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd2 = sqlcmd2 & " AND (cont_conttp = '" & strConttp & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd2 = sqlcmd2 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if

				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd2 = sqlcmd2 & " AND (pub_yyyymm = '" & strYYYYMM & "') "
				else
					sqlcmd2 = sqlcmd2
				end if

				if(Request("fgmosea") <> "") then
					strfgmosea = Request("fgmosea")
					sqlcmd2 = sqlcmd2 & " AND (or_fgmosea = '" & strfgmosea & "') "
				else
					sqlcmd2 = sqlcmd2
				end if

				if(Request("mailtp") <> "") then
					strMailtp = Request("mailtp")
					if(Trim(strMailtp) = "0") Then
						sqlcmd2 = sqlcmd2 & " AND (or_mtpcd = '11') "
					else
						sqlcmd2 = sqlcmd2 & " AND ((or_mtpcd = '12') OR (or_mtpcd = '19'))"
					end if
				else
					sqlcmd2 = sqlcmd2
				end if
				sqlcmd2 = sqlcmd2 & " GROUP BY  c2_cont.cont_conttp, c2_cont.cont_bkcd, book.bk_nm, "
				sqlcmd2 = sqlcmd2 & " c2_or.or_mtpcd, mtp.mtp_nm, c2_or.or_pubcnt, "
				sqlcmd2 = sqlcmd2 & " c2_or.or_fgmosea, c2_pub.pub_yyyymm, bookp.bkp_pno "
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


				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				sqlcmd1 = sqlcmd1 & " SELECT DISTINCT c2_cont.cont_conttp, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN cont_conttp = '01' THEN '�@��' ELSE '���s' END AS cont_conttpName, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_bkcd, book.bk_nm, c2_or.or_mtpcd, "
				sqlcmd1 = sqlcmd1 & " mtp.mtp_nm, c2_or.or_pubcnt, COUNT(c2_or.or_pubcnt) "
				sqlcmd1 = sqlcmd1 & " AS PubCounts, c2_or.or_fgmosea, c2_pub.pub_yyyymm,"
				sqlcmd1 = sqlcmd1 & " bookp.bkp_pno, c2_or.or_pubcnt * COUNT(c2_or.or_pubcnt) "
				sqlcmd1 = sqlcmd1 & " AS SumCounts "
				sqlcmd1 = sqlcmd1 & " FROM             c2_cont INNER JOIN "
				sqlcmd1 = sqlcmd1 & " book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_or ON c2_pub.pub_syscd = c2_or.or_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_contno = c2_or.or_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " bookp ON c2_pub.pub_yyyymm = bookp.bkp_date AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_bkcd = bookp.bkp_bkcd "
				sqlcmd1 = sqlcmd1 & " WHERE (1=1) "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgclosed = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgtemp = '0') "
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd1 = sqlcmd1 & " AND (cont_conttp = '" & strConttp & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd1 = sqlcmd1 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd1 = sqlcmd1
				end if

				if(Request("yyyymm") <> "") then
					strYYYYMM = Request("yyyymm")
					sqlcmd1 = sqlcmd1 & " AND (pub_yyyymm = '" & strYYYYMM & "') "
				else
					sqlcmd1 = sqlcmd1
				end if

				if(Request("fgmosea") <> "") then
					strfgmosea = Request("fgmosea")
					sqlcmd1 = sqlcmd1 & " AND (or_fgmosea = '" & strfgmosea & "') "
				else
					sqlcmd1 = sqlcmd1
				end if

				if(Request("mailtp") <> "") then
					strMailtp = Request("mailtp")
					if(Trim(strMailtp) = "0") Then
						sqlcmd1 = sqlcmd1 & " AND (or_mtpcd = '11') "
					else
						sqlcmd1 = sqlcmd1 & " AND (or_mtpcd <> '11') "
					end if
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " GROUP BY  c2_cont.cont_conttp, c2_cont.cont_bkcd, book.bk_nm, "
				sqlcmd1 = sqlcmd1 & " c2_or.or_mtpcd, mtp.mtp_nm, c2_or.or_pubcnt, "
				sqlcmd1 = sqlcmd1 & " c2_or.or_fgmosea, c2_pub.pub_yyyymm, bookp.bkp_pno "
				sqlcmd1 = sqlcmd1 & " ORDER BY  c2_or.or_mtpcd "
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
					ReDim A1(rescountMD,19)
					'Response.Write("rescountMD= " & rescountMD & "<br>")

					' Populate Array 1
					Dim preNo, count, X
					Dim sum_PubCounts, sum_Counts, TotalPubCounts, TotalCounts
					preNo = ""
					count = 0
					X = 0
					sum_PubCounts = 0
					sum_Counts = 0
					TotalPubCounts = 0
					TotalCounts = 0
					for i = 0 to rescountD - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("X= " & X & "<BR>")
						'Response.Write("count= " & count & ", ")
						'Response.Write("or_mtpcd= " & Rs1("or_mtpcd").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")

						' �Y�P�W�@����Ƥ��X���s�����P, �h�������
						if (Rs1("or_mtpcd").Value <> preNo) then
							' ��X �p�p
							if(X <> 0) then
								A1(X,0) = ""
								A1(X,1) = "-----"
								A1(X,2) = "-----"
								A1(X,3) = "-----------------------------------"
								A1(X,4) = "�p�p�G"
								A1(X,5) = sum_PubCounts & " ��"
								A1(X,6) = sum_Counts & " ��"
								X = X + 1
							end if


							' �������
							A1(X,0) = count + 1
							count = count + 1
							'Response.Write("count= " & count & ", ")

							A1(X,1) = Rs1("cont_conttpName").Value
							A1(X,2) = Rs1("bk_nm").Value
							A1(X,3) = Rs1("mtp_nm").Value
							A1(X,4) = Rs1("or_pubcnt").Value & " x"
							A1(X,5) = Rs1("PubCounts").Value & " �� = "
							A1(X,6) = Rs1("SumCounts").Value & " ��"
							sum_PubCounts = Rs1("PubCounts").Value
							sum_Counts = Rs1("SumCounts").Value
							X = X + 1

						' �Y�P�W�@����Ƥ��X���s���ۦP -- �M���e������������(�p�X��+�o�t�������)
						else
							A1(X,0) = ""
							A1(X,1) = ""
							A1(X,2) = ""
							A1(X,3) = ""
							A1(X,4) = Rs1("or_pubcnt").Value & " x"
							A1(X,5) = Rs1("PubCounts").Value & " �� = "
							A1(X,6) = Rs1("SumCounts").Value & " ��"
							sum_PubCounts = sum_PubCounts + Rs1("PubCounts").Value
							sum_Counts = sum_Counts + Rs1("SumCounts").Value
							X = X + 1
						end if

						' ���w �P�_��, �n�P�U�@����Ƭۤ��
						preNo = Rs1("or_mtpcd").Value
						'Response.Write("preNo= " & preNo & ", ")
						'Response.Write("sum_PubCounts= " & sum_PubCounts & ", ")
						'Response.Write("sum_Counts= " & sum_Counts & ", ")


						' �`�p -- for ��ӳ���, �N���ȿ�X���ܼ�
						TotalPubCounts = TotalPubCounts + Rs1("PubCounts").Value
						TotalCounts = TotalCounts + Rs1("SumCounts").Value
						'Response.Write("sum_PubCounts= " & sum_PubCounts & ", ")
						'Response.Write("sum_Counts= " & sum_Counts & ", ")


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
					'A1(X,0) = ""
					'A1(X,1) = "-----"
					'A1(X,2) = "-----"
					'A1(X,3) = "-----------------------------------"
					'A1(X,4) = "�p�p�G"
					'A1(X,5) = sum_PubCounts & " ��"
					'A1(X,6) = sum_Counts & " ��"
					TotalPubCounts = TotalPubCounts & " ��"
					TotalCounts = TotalCounts & " ��"


					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("conttpText", strconttpText)	' >>$conttpText
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bkp_pno
					XLS.AddVariable("fgmoseaText", strfgmoseaText)	' >>$fgmoseaText
					XLS.AddVariable("mailtpText", strmailtpText)	' >>$mailtpText
					XLS.AddVariable("TotalPubCounts", TotalPubCounts)' >>$TotalPubCounts
					XLS.AddVariable("TotalCounts", TotalCounts)	' >>$TotalCounts
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("ORMtpCounts_stat2a.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "ORMtpCounts_stat2a.xls", True)

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
