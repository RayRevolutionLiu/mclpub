<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i������</title>
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
				
				Dim Rs1, Rs2, Rs5, Rs6				' Record Source 1 ~ 7
				Dim Rs9, RS10					' Record Source 9 ~ 10
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd5, sqlcmd6				' SQL Command 4 ~ 7
				Dim sqlcmd9, sqlcmd10				' SQL Command 9 ~ 10
				Dim rescount, i		' rescount= count of Rs2
				Dim rescount2, j	' rescount2= count of Rs10
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
				strEmpNo = ""
				strLoginEmpNo = Request("LEmpNo")
				if(strYYYYMM <> "") then
					strYYYYMM = strYYYYMM
					strYYYYMMnew = Mid(strYYYYMM, 1, 4) & "/" & Mid(strYYYYMM, 5, 2)
				else
					strYYYYMM = ""
				end if
				
'				if(strBkcd <> "") then
'					strBkcd = strBkcd
'					
'					' Get Rs5: �Ǯ��y�N�X��X���y�W��
'					' Open the RecordSets
'					sqlcmd5 = "SELECT * FROM book"
'					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
'					Rs5 = oConn.Execute(sqlcmd5)
'					BkName = Rs5("bk_nm").Value
'					'Response.Write("BkName= " & BkName & "<br>")
'				else
'					strBkcd = ""
'				end if
				
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
				sqlcmd2 = "SELECT COUNT(*) AS CountNo  FROM wk_c4_getad"
				
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
				sqlcmd1 = "SELECT cont_contno, cont_aunm, mfr_inm, cont_autel, cont_aufax, cont_aucell, cont_dates = cont_sdate + '~' + cont_edate, adr_dates = adr_sdate + '~' + adr_edate, tot_adr_addays, s_adr_adcate, s_adr_keyword, s_adr_fgfixad, adr_impr, s_adr_drafttp, adr_imgurl, s_adr_fggot, s_adr_urltp, adr_navurl, cont_pubtm, cont_freetm, cont_totimgtm, res_drafttp, cont_toturltm, res_urltp, cont_totamt, ia_amt, cont_paidamt FROM wk_c4_getad"
  				'		                  >>1        >>2        >>3       >>4         >>5           >>6        >>7                                        >>8                                           >>9          >>10           >>11           >>12	       >>13         >>14        >>15         >>16         >>17        >>18        >>19         >>20           >>21         >>22           >>23       >>24	      >>25    >>26          >>27          
				
				if NOT Request("Qempno")="all" then
					sqlcmd1 = sqlcmd1 & " WHERE (cont_empno='" & Request("Qempno")  & "' OR cont_empno='" + Request("Qempno") +" ')" 
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
					'Response.Write("sqlcmd4= " & sqlcmd4 & "<br><br>")
					'Response.Write("Rs4= " & Rs4(0).value & "<br>")
					'Response.Write("sqlcmd9= " & sqlcmd9 & "<br><br>")
					'Response.Write("Rs9= " & Rs9(0).value & "<br>")
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
					ReDim A1(rescount,30)
					
					Dim ChgBkName
					
					' Populate Array 1
					Dim preNo, count
					preNo = ""
					count = 0
					for i = 0 to rescount - 1 step 1
						' �۰ʭp�� A ��: ���� - ��ܤ�k�G�G�񦹳B, �O�]�����n��ܤ��P����(�Y�ϦX������, �]�n�v�@�[�U�h; �٦� if�� A1(i,0) = "" �n disable)
						'A1(i,0) = count + 1
						'count = count + 1
						
						'Response.Write("pub_contno= " & Rs1("pub_contno").Value & "<br>")
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
 						end if
 						
						A1(i,2) = Rs1("cont_contno").Value
						A1(i,3) = Rs1("cont_aunm").Value
						A1(i,4) = Rs1("mfr_inm").Value
						A1(i,5) = Rs1("cont_autel").Value
						A1(i,6) = Rs1("cont_aufax").Value
						A1(i,7) = Rs1("cont_aucell").Value
						A1(i,8) = Rs1("cont_dates").Value
						A1(i,9) = Rs1("adr_dates").Value						
						A1(i,10) = Rs1("tot_adr_addays").Value
						A1(i,11) = Rs1("s_adr_adcate").Value
						A1(i,12) = Rs1("s_adr_keyword").Value
						A1(i,13) = Rs1("s_adr_fgfixad").Value
						A1(i,14) = Rs1("adr_impr").Value
						A1(i,15) = Rs1("s_adr_drafttp").Value
						A1(i,16) = Rs1("adr_imgurl").Value
						A1(i,17) = Rs1("s_adr_fggot").Value
						A1(i,18) = Rs1("s_adr_urltp").Value
						A1(i,19) = Rs1("adr_navurl").Value
						A1(i,20) = Rs1("s_adr_fggot").Value
						A1(i,21) = Rs1("cont_pubtm").Value
						A1(i,22) = Rs1("cont_freetm").Value
						A1(i,23) = Rs1("cont_totimgtm").Value
						A1(i,24) = Rs1("res_drafttp").Value
						A1(i,25) = Rs1("cont_toturltm").Value
						A1(i,26) = Rs1("res_urltp").Value
						A1(i,27) = Rs1("cont_totamt").Value
						A1(i,28) = Rs1("ia_amt").Value
						A1(i,29) = Rs1("cont_paidamt").Value							

						
						Dim highlight
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (6+i) & ":AD" & (6+i)
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
					'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("login_cname", strLoginEmpCName)	' >>$login_cname
					XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
					'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("RptGetAd.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "RptGetAd.xls", True)
					
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
