<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���}�߳� �^�_�M��</title>
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
				Dim strIabDate, strIabSeq

				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim strIabDatenew, EmpCName, strLoginEmpNo, strLoginEmpCName


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
				strIabDate = Request("iabdate")
				strIabSeq = Request("iabseq")
				strLoginEmpNo = Request("LEmpNo")
				if(strIabDate <> "") then
					strIabDate = strIabDate
					strIabDatenew = Mid(strIabDate, 1, 4) & "/" & Mid(strIabDate, 5, 2)
				else
					strIabDate = ""
				end if

				if(strIabSeq <> "") then
					strIabSeq = strIabSeq
				else
					strIabSeq = ""
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
				'Response.Write("strIabDate= " & strIabDate & "<br>")
				'Response.Write("strIabSeq " & strIabSeq & "<br>")
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")
				'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")


				' Get Rs2: ��X�ثe��Ʈw���`���� -- �D�� join ������
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT         dbo.ia.ia_syscd, dbo.ia.ia_iano, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, "
				sqlcmd2 = sqlcmd2 & " RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, "
				sqlcmd2 = sqlcmd2 & " RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rzip) AS ia_rzip, "
				sqlcmd2 = sqlcmd2 & " RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, "
				sqlcmd2 = sqlcmd2 & " dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.iad.iad_iaditem, RTRIM(dbo.iad.iad_fk1) "
				sqlcmd2 = sqlcmd2 & " AS iad_fk1, RTRIM(dbo.iad.iad_fk2) AS iad_fk2, RTRIM(dbo.iad.iad_fk3) "
				sqlcmd2 = sqlcmd2 & " AS iad_fk3, RTRIM(dbo.iad.iad_fk4) AS iad_fk4, RTRIM(dbo.iad.iad_desc) "
				sqlcmd2 = sqlcmd2 & " AS iad_desc, dbo.iad.iad_projno, dbo.iad.iad_costctr, dbo.iad.iad_qty, "
				sqlcmd2 = sqlcmd2 & " dbo.iad.iad_amt, RTRIM(dbo.ia.ia_contno) AS ia_contno, dbo.ia.ia_iabdate, "
				sqlcmd2 = sqlcmd2 & " dbo.ia.ia_iabseq "
				sqlcmd2 = sqlcmd2 & " FROM             dbo.ia INNER JOIN "
				sqlcmd2 = sqlcmd2 & " dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND "
				sqlcmd2 = sqlcmd2 & " dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN "
				sqlcmd2 = sqlcmd2 & " dbo.iab ON "
				sqlcmd2 = sqlcmd2 & " dbo.ia.ia_syscd = dbo.iab.iab_syscd COLLATE Chinese_Taiwan_Stroke_CI_AS AND "
				sqlcmd2 = sqlcmd2 & " dbo.ia.ia_iabdate = dbo.iab.iab_iabdate AND "
				sqlcmd2 = sqlcmd2 & " dbo.ia.ia_iabseq = dbo.iab.iab_iabseq INNER JOIN "
				sqlcmd2 = sqlcmd2 & " dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno INNER JOIN "
				sqlcmd2 = sqlcmd2 & " dbo.c2_cont ON "
				sqlcmd2 = sqlcmd2 & " dbo.ia.ia_contno = dbo.c2_cont.cont_syscd + dbo.c2_cont.cont_contno "
				sqlcmd2 = sqlcmd2 & " WHERE         (dbo.ia.ia_syscd = 'C2') "
				sqlcmd2 = sqlcmd2 & " AND (dbo.ia.ia_status = ' ') "
				sqlcmd2 = sqlcmd2 & " AND (dbo.c2_cont.cont_fgpayonce = '0') "
				sqlcmd2 = sqlcmd2 & " AND (dbo.c2_cont.cont_fgclosed = '0') "
				if(Request("iabdate") <> "") then
					strIabDate = Request("iabdate")
					sqlcmd2 = sqlcmd2 & " AND (ia_iabdate = '" & strIabDate & "') "
				else
					sqlcmd2 = sqlcmd2
				end if

				if(Request("iabseq") <> "") then
					strIabSeq = Request("iabseq")
					sqlcmd2 = sqlcmd2 & " AND (ia_iabseq = '" & strIabSeq & "') "
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


				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				sqlcmd1 = "SELECT         dbo.ia.ia_syscd, dbo.ia.ia_iano, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, "
				sqlcmd1 = sqlcmd1 & " RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, "
				sqlcmd1 = sqlcmd1 & " RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rzip) AS ia_rzip, "
				sqlcmd1 = sqlcmd1 & " RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, "
				sqlcmd1 = sqlcmd1 & " dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.iad.iad_iaditem, RTRIM(dbo.iad.iad_fk1) "
				sqlcmd1 = sqlcmd1 & " AS iad_fk1, RTRIM(dbo.iad.iad_fk2) AS iad_fk2, RTRIM(dbo.iad.iad_fk3) "
				sqlcmd1 = sqlcmd1 & " AS iad_fk3, RTRIM(dbo.iad.iad_fk4) AS iad_fk4, RTRIM(dbo.iad.iad_desc) "
				sqlcmd1 = sqlcmd1 & " AS iad_desc, dbo.iad.iad_projno, dbo.iad.iad_costctr, dbo.iad.iad_qty, "
				sqlcmd1 = sqlcmd1 & " dbo.iad.iad_amt, RTRIM(dbo.ia.ia_contno) AS ia_contno, dbo.ia.ia_iabdate, "
				sqlcmd1 = sqlcmd1 & " dbo.ia.ia_iabseq, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN ia_invcd = '2' THEN '�G�p��' WHEN ia_invcd = '3' "
				sqlcmd1 = sqlcmd1 & " THEN '�T�p��' WHEN ia_invcd = '4' THEN '��L' "
				sqlcmd1 = sqlcmd1 & " ELSE '���M��' END AS ia_invcdText, "
				sqlcmd1 = sqlcmd1 & " CASE WHEN ia_taxtp = '1' THEN '���|5%' WHEN ia_taxtp = '2' "
				sqlcmd1 = sqlcmd1 & " THEN '�s�|' WHEN ia_taxtp = '3' THEN '�K�|' "
				sqlcmd1 = sqlcmd1 & " ELSE '���M��' END AS ia_taxtpText "
				sqlcmd1 = sqlcmd1 & " FROM             dbo.ia INNER JOIN "
				sqlcmd1 = sqlcmd1 & " dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND "
				sqlcmd1 = sqlcmd1 & " dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN "
				sqlcmd1 = sqlcmd1 & " dbo.iab ON "
				sqlcmd1 = sqlcmd1 & " dbo.ia.ia_syscd = dbo.iab.iab_syscd COLLATE Chinese_Taiwan_Stroke_CI_AS AND "
				sqlcmd1 = sqlcmd1 & " dbo.ia.ia_iabdate = dbo.iab.iab_iabdate AND "
				sqlcmd1 = sqlcmd1 & " dbo.ia.ia_iabseq = dbo.iab.iab_iabseq INNER JOIN "
				sqlcmd1 = sqlcmd1 & " dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " dbo.c2_cont ON "
				sqlcmd1 = sqlcmd1 & " dbo.ia.ia_contno = dbo.c2_cont.cont_syscd + dbo.c2_cont.cont_contno "
				sqlcmd1 = sqlcmd1 & " WHERE         (dbo.ia.ia_syscd = 'C2') "
				sqlcmd1 = sqlcmd1 & " AND (dbo.ia.ia_status = ' ') "
				sqlcmd1 = sqlcmd1 & " AND (dbo.c2_cont.cont_fgpayonce = '0') "
				sqlcmd1 = sqlcmd1 & " AND (dbo.c2_cont.cont_fgclosed = '0') "
				if(Request("iabdate") <> "") then
					strIabDate = Request("iabdate")
					sqlcmd1 = sqlcmd1 & " AND (ia_iabdate = '" & strIabDate & "') "
				else
					sqlcmd1 = sqlcmd1
				end if

				if(Request("iabseq") <> "") then
					strIabSeq = Request("iabseq")
					sqlcmd1 = sqlcmd1 & " AND (ia_iabseq = '" & strIabSeq & "') "
				else
					sqlcmd1 = sqlcmd1
				end if
				sqlcmd1 = sqlcmd1 & " ORDER BY  dbo.ia.ia_iano, dbo.ia.ia_mfrno, dbo.ia.ia_rnm, dbo.iad.iad_iaditem "


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
					'Dim rescountMD
					'rescountMD = rescountD + rescountM + 1
					ReDim A1(rescountD,19)
					'Response.Write("rescountMD= " & rescountMD & "<br>")

					' Populate Array 1
					Dim preNo, count, X
					preNo = ""
					count = 0
					X = 0
					for i = 0 to rescountD - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("X= " & X & "<BR>")
						'Response.Write("count= " & count & ", ")
						'Response.Write("pub_contno= " & Rs1("pub_contno").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")

						' �۰ʭp�� A ��: ���� - ��ܤ�k�G�G�񦹳B, �O�]�����n��ܤ��P����(�Y�ϦX������, �]�n�v�@�[�U�h; �٦� if�� A1(i,0) = "" �n disable)
						'A1(i,0) = count + 1
						'count = count + 1

						'Response.Write("ia_iano= " & Rs1("ia_iano").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")
						' �Y��ƭ���, �h���и�ƶ��M���Y�ǭ��и�ƶ�(�p�X���������)
						if Rs1("ia_iano").Value = preNo then
							' �H�U�����Ю�, ��ܭn�M�Ū���ƶ�
							A1(i,0) = ""
							A1(i,1) = ""
							A1(i,2) = ""
							A1(i,3) = ""
							A1(i,4) = ""
							A1(i,5) = ""
							A1(i,6) = ""
							A1(i,7) = ""
							A1(i,8) = ""
							A1(i,9) = ""
							A1(i,10) = ""
							A1(i,11) = ""
							A1(i,12) = ""
						else
							' �۰ʭp�� A ��: ���� - ��ܤ�k�@�G�񦹳B�h�O�Ȥ�n�D: �X�����Ъ�, �h����ܨ�ۦP������ (if�� A1(i,0) = "" �n enable)
							A1(i,0) = count + 1
							count = count + 1

							' �H�U���D���Ю�, �n��ܪ���ƶ�
							A1(i,1) = Rs1("ia_iano").Value
							A1(i,2) = Rs1("ia_mfrno").Value
							A1(i,3) = Rs1("mfr_inm").Value
							A1(i,4) = Rs1("ia_rnm").Value
							A1(i,5) = Rs1("ia_rjbti").Value
							A1(i,6) = Rs1("ia_rzip").Value & " " & Rs1("ia_raddr").Value
							A1(i,7) = Rs1("ia_rtel").Value
							A1(i,8) = Rs1("ia_invcdText").Value
							A1(i,9) = Rs1("ia_taxtpText").Value
							A1(i,10) = Rs1("iad_iaditem").Value
							A1(i,11) = Rs1("iad_fk1").Value
							A1(i,12) = Mid(Rs1("iad_fk2").Value, 1, 4) & "/" & Mid(Rs1("iad_fk2").Value, 5, 2)
							A1(i,13) = Rs1("iad_fk3").Value
							A1(i,14) = Rs1("iad_desc").Value
							A1(i,15) = Rs1("iad_projno").Value
							A1(i,16) = Rs1("iad_costctr").Value
							A1(i,17) = Rs1("iad_qty").Value
							A1(i,18) = Rs1("iad_amt").Value
						end if


						' �H�U���L�׭��лP�_, �@�w�n�X�{����ƶ�
						A1(i,13) = Rs1("iad_fk3").Value
						A1(i,14) = Rs1("iad_desc").Value
						A1(i,15) = Rs1("iad_projno").Value
						A1(i,16) = Rs1("iad_costctr").Value
						A1(i,17) = Rs1("iad_qty").Value
						A1(i,18) = Rs1("iad_amt").Value
						preNo = Rs1("ia_iano").Value


						Dim highlight2, highlight3, highlight4
						' Highlight Some Rows: �����S�O���ϥΪ��榡 A2/B2 (���B�O���m���B�z; �S�O�榡�g�b sheet 2 �����w����)
						' �S�O��� (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �`�N FormatCells �S�O��� ���{���X�@�w�n��b FormatCells �@����쪺�{���X "�e��", �_�h�S�O���L�k���
						highlight2 = "R" & (6+i)
						highlight3 = "S" & (6+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight2, 2, "A8", false )
							XLS.FormatCells( 1, highlight3, 2, "A5", false )
						else
							XLS.FormatCells( 1, highlight2, 2, "B8", false )
							XLS.FormatCells( 1, highlight3, 2, "B5", false )
						end if
						'Response.Write("highlight2= " & highlight2 & "<br>")
						'Response.Write("highlight3= " & highlight3 & "<br>")


						Dim highlight
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (6+i) & ":S" & (6+i)
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

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					'XLS.AddVariable("iabdate", strIabDate)		' >>$iabdate
					XLS.AddVariable("iabdate", strIabDatenew)	' >>$iabdate
					XLS.AddVariable("iabseq", strIabSeq)		' >>$iabseq
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					'Response.Write("iabdate= " & strIabDatenew & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("iaFm2_RecList.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "iaFm2_RecList.xls", True)

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
