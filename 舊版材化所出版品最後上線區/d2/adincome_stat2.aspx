<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i���J�έp��</title>
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
				Dim dbFile          ' Database File
				Dim oConn           ' ADO Connection object
				Dim DSN				' Web Application Name

				Dim Rs1, Rs2, Rs4, Rs5, Rs6			' Record Source 1 ~ 6
				Dim Rs9						' Record Source 9
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6			' SQL Command 4 ~ 6
				Dim sqlcmd9					' SQL Command 9
				Dim rescount, i		' rescount= count of Rs2
				Dim rescount2, j	' rescount2= count of Rs10
				Dim A1			' Array A1

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
				strEmpNo = ""
				BkPNo = ""
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
					BkName = Rs5("bk_nm").Value
					'Response.Write("BkName= " & BkName & "<br>")
				else
					strBkcd = ""
				end if

				if(Request("empno") <> "") then
					strEmpNo = Request("empno")

					' Get Rs6: �ǩӿ�~�ȭ��u����X�m�W
					' Open the RecordSets
					sqlcmd6 = "SELECT * FROM srspn"
					sqlcmd6 = sqlcmd6 & " WHERE (srspn_empno='" + strEmpNo + "')"
					Rs6 = oConn.Execute(sqlcmd6)
					EmpCName = Trim(Rs6("srspn_cname").Value)
					'Response.Write("EmpCName= " & EmpCName & "<br>")
				else
					strEmpNo = ""
					EmpCName = "(�Ҧ�)"
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


				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT         c2_cont.cont_contno, c2_cont.cont_bkcd,   "
				sqlcmd2 = sqlcmd2 & " RTRIM(book.bk_nm) AS bk_nm, c2_cont.cont_mfrno, RTRIM(mfr.mfr_inm) "
				sqlcmd2 = sqlcmd2 & " AS mfr_inm, SUM(c2_pub.pub_adamt) AS TotalAdamt, SUM(c2_pub.pub_chgamt) "
				sqlcmd2 = sqlcmd2 & " AS TotalChgAmt, COUNT(c2_pub.pub_pubseq) AS TotalPubCounts, "
				sqlcmd2 = sqlcmd2 & " SUM(c2_pub.pub_adamt) AS TotalAmt, RTRIM(c2_cont.cont_empno) "
				sqlcmd2 = sqlcmd2 & " AS cont_empno "
				sqlcmd2 = sqlcmd2 & " FROM             c2_cont INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN "
				sqlcmd2 = sqlcmd2 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				'sqlcmd2 = sqlcmd2 & " WHERE (c2_cont.cont_fgclosed = '0') "
				'sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgpubed = '1') "
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
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd2 = sqlcmd2 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				sqlcmd2 = sqlcmd2 & " GROUP BY  c2_cont.cont_contno, c2_cont.cont_bkcd, book.bk_nm, c2_cont.cont_mfrno, "
				sqlcmd2 = sqlcmd2 & " mfr.mfr_inm, c2_cont.cont_empno "
				'sqlcmd2 = sqlcmd2 & " ORDER BY  c2_cont.cont_contno "
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


				' Get Rs8: ���� sp �H���� Rs1 �̪� c2_getad.pubmmstr ����
				' ���q�] wk_c2_rp1 �̳��� pubmmstr �ȨS���X�{, �ҥH���� getad.aspx �̰��� (���F �d�߫��s��)
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				'sqlcmd8 = " EXEC sp_c2_getad_1 '0', '" & strBkcd & "' "
				'Rs8 = oConn.Execute(sqlcmd8)


				' Get Rs11: ���� sp �H���� Rs1 �̪� c2_getad.pubmmstr ����
				' ���q�] wk_c2_rp1 �̳��� pubmmstr �ȨS���X�{, �ҥH���� getad.aspx �̰��� (���F �d�߫��s��)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				'sqlcmd11 = " EXEC sp_c2_rp1 '" & strYYYYMM & "', '" & strBkcd & "' "
				'Rs11 = oConn.Execute(sqlcmd11)


				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				sqlcmd1 = "SELECT         c2_cont.cont_contno, c2_cont.cont_bkcd,   "
				sqlcmd1 = sqlcmd1 & " RTRIM(book.bk_nm) AS bk_nm, c2_cont.cont_mfrno, RTRIM(mfr.mfr_inm) "
				sqlcmd1 = sqlcmd1 & " AS mfr_inm, SUM(c2_pub.pub_adamt) AS TotalAdamt, SUM(c2_pub.pub_chgamt) "
				sqlcmd1 = sqlcmd1 & " AS TotalChgAmt, COUNT(c2_pub.pub_pubseq) AS TotalPubCounts, "
				sqlcmd1 = sqlcmd1 & " SUM(c2_pub.pub_adamt) AS TotalAmt, RTRIM(c2_cont.cont_empno) "
				sqlcmd1 = sqlcmd1 & " AS cont_empno "
				sqlcmd1 = sqlcmd1 & " FROM             c2_cont INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				'sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_fgclosed = '0') "
				'sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgtemp = '0') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgpubed = '1') "
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
				if(Request("empno") <> "") then
					strEmpNo = Request("empno")
					sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " GROUP BY  c2_cont.cont_contno, c2_cont.cont_bkcd, book.bk_nm, c2_cont.cont_mfrno, "
				sqlcmd1 = sqlcmd1 & " mfr.mfr_inm, c2_cont.cont_empno "
				sqlcmd1 = sqlcmd1 & " ORDER BY  c2_cont.cont_contno "

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
							A1(i,2) = ""
						else
							' �۰ʭp�� A ��: ���� - ��ܤ�k�@�G�񦹳B�h�O�Ȥ�n�D: �X�����Ъ�, �h����ܨ�ۦP������ (if�� A1(i,0) = "" �n enable)
							A1(i,0) = count + 1
							count = count + 1

							' �H�U���D���Ю�, �n��ܪ���ƶ�
							A1(i,3) = Rs1("TotalAdamt").Value
							A1(i,4) = Rs1("TotalChgAmt").Value
							A1(i,5) = Rs1("TotalPubCounts").Value
							A1(i,6) = Rs1("TotalAmt").Value
						end if


						' �H�U���L�׭��лP�_, �@�w�n�X�{����ƶ�
						A1(i,1) = Rs1("cont_contno").Value
						A1(i,2) = Rs1("mfr_inm").Value
						A1(i,3) = Rs1("TotalAdamt").Value
						A1(i,4) = Rs1("TotalChgAmt").Value
						A1(i,5) = Rs1("TotalPubCounts").Value
						A1(i,6) = Rs1("TotalAmt").Value
						preNo = Rs1("cont_contno").Value


						Dim highlight2, highlight3, highlight4
						' Highlight Some Rows: �����S�O���ϥΪ��榡 A2/B2 (���B�O���m���B�z; �S�O�榡�g�b sheet 2 �����w����)
						' �S�O��� (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �`�N FormatCells �S�O��� ���{���X�@�w�n��b FormatCells �@����쪺�{���X "�e��", �_�h�S�O���L�k���
						highlight2 = "D" & (7+i)
						highlight3 = "E" & (7+i)
						highlight4 = "G" & (7+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight2, 2, "A5", false )
							XLS.FormatCells( 1, highlight3, 2, "A5", false )
							XLS.FormatCells( 1, highlight4, 2, "A5", false )
						else
							XLS.FormatCells( 1, highlight2, 2, "B5", false )
							XLS.FormatCells( 1, highlight3, 2, "B5", false )
							XLS.FormatCells( 1, highlight4, 2, "B5", false )
						end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")
						'Response.Write("highlight4= " & highlight4 & "<br>")


						Dim highlight
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (7+i) & ":G" & (7+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false )
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )
						end if
						'Response.Write("highlight= " & highlight & "<br>")


						Rs1.MoveNext

						if Rs1.EOF
	    						exit for
						end if
					next



					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs7, 20)

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("bkp_pno", BkPNo)		' >>$bkp_pno
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)	' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("adincome_stat2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "adincome_stat2.xls", True)

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
