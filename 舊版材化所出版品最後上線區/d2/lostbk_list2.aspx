<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ʮѲM��</title>
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

				Dim Rs1, Rs2, Rs5			' Record Source 1 ~ 2, 5
				Dim Rs9					' Record Source 9
				Dim sqlcmd1, sqlcmd2, sqlcmd5		' SQL Command 1 ~ 2, 5
				Dim sqlcmd9				' SQL Command 9
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' �ۭq sql �ܼ�
				Dim strStatus, strBkcd, strLostDate, strSignDate

				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim strStatusText, BkName
				Dim strLostDatenew, strSignDatenew, strLoginEmpNo, strLoginEmpCName
				Dim strLostDateS, strLostDateE, strSignDateS, strSignDateE


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
				strStatus = Request("status")
				strBkcd = Request("bkcd")
				strLostDate = Request("lostdate")
				strSignDate = Request("signdate")
				strLoginEmpNo = Request("LEmpNo")

				if(strStatus <> "") then
					if(strStatus = "C")
						strStatusText = "�w�H�X"
					end if
					if(strStatus = "N")
						strStatusText = "�|���H�X"
					end if
					if(strStatus = "All")
						strStatusText = "����"
					end if
				else
					strStatusText = "(�����w�H�Ѫ��p)"
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

				if(strLostDate <> "") then
					strLostDate = strLostDate
					strLostDateS = Mid(strLostDate, 1,4) & Mid(strLostDate, 6,2) & Mid(strLostDate, 9,2)
					strLostDateE = Mid(strLostDate, 12,4)& Mid(strLostDate, 17,2)& Mid(strLostDate, 20,2)
				else
					strLostDate = ""
				end if

				if(strSignDate <> "") then
					strSignDate = strSignDate
					strSignDateS = Mid(strSignDate, 1,4) & Mid(strSignDate, 6,2) & Mid(strSignDate, 9,2)
					strSignDateE = Mid(strSignDate, 12,4)& Mid(strSignDate, 17,2)& Mid(strSignDate, 20,2)
				else
					strSignDate = ""
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
				'Response.Write("strStatus= " & strStatus & "<br>")
				'Response.Write("strLostDate= " & strLostDate & "<br>")
				'Response.Write("strLostDateS= " & strLostDateS & "<br>")
				'Response.Write("strLostDateE= " & strLostDateE & "<br>")
				'Response.Write("strSignDate= " & strSignDate & "<br>")
				'Response.Write("strSignDateS= " & strSignDateS & "<br>")
				'Response.Write("strSignDateE= " & strSignDateE & "<br>")
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")
				'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")


				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT         COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM             ( "
				sqlcmd2 = sqlcmd2 & " SELECT  c2_lost.lst_contno, c2_lost.lst_sdate, c2_lost.lst_edate, "
				sqlcmd2 = sqlcmd2 & " c2_or.or_nm, RTRIM(c2_or.or_zip) AS or_zip, c2_or.or_addr, c2_lost.lst_date, "
				sqlcmd2 = sqlcmd2 & " c2_lost.lst_cont, c2_lost.lst_rea, c2_lost.lst_fgsent, "
				sqlcmd2 = sqlcmd2 & " c2_cont.cont_signdate, dbo.c2_or.or_jbti, c2_or.or_inm "
				sqlcmd2 = sqlcmd2 & " FROM  c2_lost INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_or ON c2_lost.lst_syscd = c2_or.or_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_lost.lst_contno = c2_or.or_contno AND "
				sqlcmd2 = sqlcmd2 & " c2_lost.lst_oritem = c2_or.or_oritem INNER JOIN "
				sqlcmd2 = sqlcmd2 & " c2_cont ON c2_or.or_syscd = c2_cont.cont_syscd AND "
				sqlcmd2 = sqlcmd2 & " c2_or.or_contno = c2_cont.cont_contno "
				sqlcmd2 = sqlcmd2 & " WHERE  (1 = 1) "
				if(strBkcd <> "") then
					sqlcmd2 = sqlcmd2 & " AND  (cont_bkcd ='" & strBkcd & "') "
				end if
				'�w�H�X
		                if Request("status")= "C" then
					if strLostDate <> "" then
						sqlcmd2 = sqlcmd2 & " AND (c2_lost.lst_date >= '" & strLostDateS & "') "
						sqlcmd2 = sqlcmd2 & " AND (c2_lost.lst_date <= '" & strLostDateE & "') "
					end if
					sqlcmd2 = sqlcmd2 & " AND (c2_lost.lst_fgsent = 'C') "
				'���H�X
				else if Request("status")= "N" then
					sqlcmd2 = sqlcmd2 & " AND (c2_lost.lst_fgsent = 'N') "
				' ����
				else if Request("status")= "All" then
					sqlcmd2 = sqlcmd2
				end if
				if strSignDate <> "" then
					sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_signdate >= '" & strSignDateS & "') "
					sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_signdate <= '" & strSignDateE & "') "
				end if
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
				sqlcmd1 = sqlcmd1 & " SELECT  c2_lost.lst_contno, c2_lost.lst_sdate, c2_lost.lst_edate, "
				sqlcmd1 = sqlcmd1 & " c2_or.or_nm, c2_or.or_zip, c2_or.or_addr, c2_lost.lst_date, "
				sqlcmd1 = sqlcmd1 & " c2_lost.lst_cont, c2_lost.lst_rea, c2_lost.lst_fgsent, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_signdate, c2_or.or_jbti, c2_or.or_inm "
				sqlcmd1 = sqlcmd1 & " FROM  c2_lost INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_or ON c2_lost.lst_syscd = c2_or.or_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_lost.lst_contno = c2_or.or_contno AND "
				sqlcmd1 = sqlcmd1 & " c2_lost.lst_oritem = c2_or.or_oritem INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c2_cont ON c2_or.or_syscd = c2_cont.cont_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_or.or_contno = c2_cont.cont_contno "
				sqlcmd1 = sqlcmd1 & " WHERE  (1 = 1) "
				if(strBkcd <> "") then
					sqlcmd1 = sqlcmd1 & " AND  (cont_bkcd ='" & strBkcd & "') "
				end if
				'�w�H�X
		                if Request("status")= "C" then
					if strLostDate <> "" then
						sqlcmd1 = sqlcmd1 & " AND (c2_lost.lst_date >= '" & strLostDateS & "') "
						sqlcmd1 = sqlcmd1 & " AND (c2_lost.lst_date <= '" & strLostDateE & "') "
					end if
					sqlcmd1 = sqlcmd1 & " AND (c2_lost.lst_fgsent = 'C') "
				'���H�X
				else if Request("status")= "N" then
					sqlcmd1 = sqlcmd1 & " AND (c2_lost.lst_fgsent = 'N') "
				' ����
				else if Request("status")= "All" then
					sqlcmd1 = sqlcmd1
				end if
				if strSignDate <> "" then
					sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_signdate >= '" & strSignDateS & "') "
					sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_signdate <= '" & strSignDateE & "') "
				end if


				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)


				'------- �}�l��X���G ---
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					'Response.Write("sqlcmd2= " & sqlcmd2 & "<br><br>")
					'Response.Write("Rs2= " & Rs2(0).value & "<br>")
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
					ReDim A1(rescount,10)

					' Populate Array 1
					Dim preNo, count
					Dim contdate1, contdate2, contdate_final
					Dim lostdate, fgsent, fgsentName, signdate
					preNo = ""
					count = 0
					for i = 0 to rescount - 1 step 1
						' �۰ʭp�� A ��: ���� - ��ܤ�k�G�G�񦹳B, �O�]�����n��ܤ��P����(�Y�ϦX������, �]�n�v�@�[�U�h; �٦� if�� A1(i,0) = "" �n disable)
						'A1(i,0) = count + 1
						'count = count + 1

						' ���B�z�H�U�S���X�榡���, �p����榡
						contdate1 = Rs1("lst_sdate").Value
						contdate1 = MID(contdate1, 1, 4) & "/" & MID(contdate1, 5, 2)
						contdate2 = Rs1("lst_edate").Value
						contdate2 = MID(contdate2, 1, 4) & "/" & MID(contdate2, 5, 2)
						contdate_final = contdate1 & " ~ " & contdate2
						lostdate = Rs1("lst_date").Value
						lostdate = MID(lostdate, 1, 4) & "/" & MID(lostdate, 5, 2) & "/" & MID(lostdate, 7, 2)
						fgsent = Rs1("lst_fgsent").Value
						if(fgsent = "C") Then
							fgsentName = "�w�H�X"
						else if(fgsent = "Y") Then
							fgsentName = "�i�H�X"
						else if(fgsent = "D") Then
							fgsentName = "���B�z"
						else if(fgsent = "N") Then
							fgsentName = "�ثe�ȮɵL�k�H�X"
						end if
						signdate = Rs1("cont_signdate").Value
						signdate = MID(signdate, 1, 4) & "/" & MID(signdate, 5, 2) & "/" & MID(signdate, 7, 2)


						'Response.Write("cont_contno= " & Rs1("lst_contno").Value & "<br>")
						'Response.Write("preNo= " & preNo & "<br><br>")
						' �Y��ƭ���, �h���и�ƶ��M���Y�ǭ��и�ƶ�(�p�X���������)
						if Rs1("lst_contno").Value = preNo then
							' �H�U�����Ю�, ��ܭn�M�Ū���ƶ�
							A1(i,0) = ""
							A1(i,1) = ""
							A1(i,2) = ""
							A1(i,9) = ""
						else
							' �۰ʭp�� A ��: ���� - ��ܤ�k�@�G�񦹳B�h�O�Ȥ�n�D: �X�����Ъ�, �h����ܨ�ۦP������ (if�� A1(i,0) = "" �n enable)
							A1(i,0) = count + 1
							count = count + 1

							' �H�U���D���Ю�, �n��ܪ���ƶ�
							A1(i,2) = contdate_final
							A1(i,3) = Rs1("or_inm").Value
							A1(i,4) = Rs1("or_nm").Value & " " & Rs1("or_jbti").Value
							A1(i,5) = Rs1("or_zip").Value & " " & Rs1("or_addr").Value
							A1(i,6) = lostdate
							A1(i,7) = Rs1("lst_cont").Value
						end if


						' �H�U���L�׭��лP�_, �@�w�n�X�{����ƶ�
						A1(i,1) = Rs1("lst_contno").Value
						A1(i,2) = contdate_final
						A1(i,3) = Rs1("or_inm").Value
						A1(i,4) = Rs1("or_nm").Value & " " & Rs1("or_jbti").Value
						A1(i,5) = Rs1("or_zip").Value & " " & Rs1("or_addr").Value
						A1(i,6) = lostdate
						A1(i,7) = Rs1("lst_cont").Value
						A1(i,8) = Rs1("lst_rea").Value
						A1(i,9) = fgsentName
						A1(i,10) = signdate
						preNo = Rs1("lst_contno").Value


						Dim highlight
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (6+i) & ":K" & (6+i)
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
					if(strLostDate = "") then
						strLostDate = "(�L)"
					end if
					if(strSignDate = "") then
						strSignDate = "(�L)"
					end if
					XLS.AddVariable("lostdate", strLostDate)	' >>$lostdate
					XLS.AddVariable("signdate", strSignDate)	' >>$signdate
					XLS.AddVariable("login_cname", strLoginEmpCName)' >>$login_cname
					XLS.AddVariable("statusText", strStatusText)	' >>$statusText
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					'Response.Write("strLostDate= " & strLostDate & "<br>")

					' Location of Source Workbook
					SrcBook = Server.MapPath("lostbk_list2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "lostbk_list2.xls", True)

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
