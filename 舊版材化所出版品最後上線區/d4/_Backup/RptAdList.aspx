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
		<form id="RptAdList" method="post" runat="server">
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
				
				
				' ---- �s��H ----
				if(Request("whoami") <> "") then
					strLoginEmpNo = Request("whoami")
					sqlcmd9 = "SELECT * FROM srspn"
					sqlcmd9 = sqlcmd9 & " WHERE (RTRIM(srspn_empno)='" + TRIM(strLoginEmpNo) + "')"
					Rs9 = oConn.Execute(sqlcmd9)
					strLoginEmpCName = Trim(Rs9("srspn_cname").Value)
					'Response.Write("strLoginEmpCName= " & strLoginEmpCName & "<br>")
				else
					strLoginEmpNo = ""
					strLoginEmpCName = ""
				end if
				
				' �p�G�䤣��
				if strLoginEmpCName="" then
					strLoginEmpCName = "(����)"
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
				sqlcmd1 = "SELECT cont_contno, mfr_inm, adr_sdate, adr_edate, adr_adcate, adr_keyword, adr_impr, adr_adamt, adr_desamt, adr_chgamt, adr_invamt, s_adr_drafttp_1, s_adr_drafttp_2, s_adr_drafttp_3, adr_imgurl, s_adr_urltp_1, s_adr_urltp_2, s_adr_urltp_3, adr_navurl,  adr_alttext, adr_remark FROM wk_c4_adlist"
				'		                  >>2      >>3        >>4        >>5         >>6          >>7       >>8        >>9        >>10        >>11        >>12             >>13	            >>14             >>15        >>16           >>17           >>18           >>19        >>20          >>21        >>22          

				'�]�w����
				Dim strFilter = Request("strFilter")
				if not strFilter = "" then
					sqlcmd1 = sqlcmd1 & " WHERE " & strFilter
				end if
				
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				' Create Excel File
				XLS = Server.CreateObject("XLSpeedGen.ASP")
									
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
				end if
				
				'Response.Write("Rs1= " & Rs1(0).value & "<br>")
				'Response.Write("Rs2= " & Rs2(0).value & "<br>")
				
				' �p��Rs1������
				rescount = 0
				if NOT Rs1.EOF then
					Rs1.MoveFirst
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst
				end if
				
				' Array 1
				ReDim A1(rescount*2+1,23)	
				
				Dim count							
				i = 0
				count = 1
				
				Dim SubSumAdAmt, SubSumDesAmt, SubSumChgAmt, SubSumInvAmt
				SubSumAdAmt = 0
				SubSumDesAmt = 0
				SubSumChgAmt = 0
				SubSumInvAmt = 0				
				
				Dim TotalSumAdAmt, TotalSumDesAmt, TotalSumChgAmt, TotalSumInvAmt
				TotalSumAdAmt = 0
				TotalSumDesAmt = 0
				TotalSumChgAmt = 0
				TotalSumInvAmt = 0								
				
				Dim preNo
				Dim highlight
				' �Ψӭp��B�z�F�h�ֵ����
				Dim rsIndex
				'�X���p��
				Dim cc								
				
				' ��X�Ĥ@�����
				if NOT Rs1.EOF then
					A1(i,0) = 1
					A1(i,2) = Rs1("cont_contno").Value
					A1(i,3) = Rs1("mfr_inm").Value				
					A1(i,4) = Rs1("adr_sdate").Value
					A1(i,5) = Rs1("adr_edate").Value
					A1(i,6) = Rs1("adr_adcate").Value
					A1(i,7) = Rs1("adr_keyword").Value
					A1(i,8) = Rs1("adr_impr").Value
					A1(i,9) = Rs1("adr_adamt").Value
					A1(i,10) = Rs1("adr_desamt").Value
					A1(i,11) = Rs1("adr_chgamt").Value
					A1(i,12) = Rs1("adr_invamt").Value
					A1(i,13) = Rs1("s_adr_drafttp_1").Value
					A1(i,14) = Rs1("s_adr_drafttp_2").Value
					A1(i,15) = Rs1("s_adr_drafttp_3").Value
					A1(i,16) = Rs1("adr_imgurl").Value
					A1(i,17) = Rs1("s_adr_urltp_1").Value
					A1(i,18) = Rs1("s_adr_urltp_2").Value
					A1(i,19) = Rs1("s_adr_urltp_3").Value
					A1(i,20) = Rs1("adr_navurl").Value
					A1(i,21) = Rs1("adr_alttext").Value
					A1(i,22) = Rs1("adr_remark").Value
					
					SubSumAdAmt = SubSumAdAmt + Rs1("adr_adamt").Value
					SubSumDesAmt = SubSumDesAmt + Rs1("adr_desamt").Value
					SubSumChgAmt = SubSumChgAmt + Rs1("adr_chgamt").Value
					SubSumInvAmt = SubSumInvAmt	+ Rs1("adr_invamt").Value

					
					preNo = ""
					preNo = Rs1("cont_contno").Value
					
					'----- �榡�]�w -----
					' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
					highlight = "A" & (6+i) & ":W" & (6+i)
					if (i mod 2) = 0
						XLS.FormatCells( 1, highlight, 2, "A1", false ) 
					else
						XLS.FormatCells( 1, highlight, 2, "B1", false )  
					end if				
					
					rsIndex = 1
					
					cc = 1				
					
					i = i + 1
					rsIndex = rsIndex + 1
					count = count + 1												
					
					
					Rs1.MoveNext
				end if
				' ---- �H�W���Ĥ@����ƿ�X	----
				
				Dim ChgBkName

				while rsIndex < rescount
					
					if Rs1("cont_contno").Value = preNo then				
						' ���Ю�, ��ܭn�M�Ū���ƶ�
						A1(i,0) = ""
						A1(i,1) = ""
						A1(i,2) = ""
						A1(i,3) = ""
					
						' ���Ʈ�, ��L�n��ܪ����
						A1(i,4) = Rs1("adr_sdate").Value
						A1(i,5) = Rs1("adr_edate").Value
						A1(i,6) = Rs1("adr_adcate").Value
						A1(i,7) = Rs1("adr_keyword").Value
						A1(i,8) = Rs1("adr_impr").Value
						A1(i,9) = Rs1("adr_adamt").Value
						A1(i,10) = Rs1("adr_desamt").Value
						A1(i,11) = Rs1("adr_chgamt").Value
						A1(i,12) = Rs1("adr_invamt").Value
						A1(i,13) = Rs1("s_adr_drafttp_1").Value
						A1(i,14) = Rs1("s_adr_drafttp_2").Value
						A1(i,15) = Rs1("s_adr_drafttp_3").Value
						A1(i,16) = Rs1("adr_imgurl").Value
						A1(i,17) = Rs1("s_adr_urltp_1").Value
						A1(i,18) = Rs1("s_adr_urltp_2").Value
						A1(i,19) = Rs1("s_adr_urltp_3").Value
						A1(i,20) = Rs1("adr_navurl").Value
						A1(i,21) = Rs1("adr_alttext").Value
						A1(i,22) = Rs1("adr_remark").Value		
					
					else
						' �����ƮɡA�n�����J�@���p�p
						A1(i, 1) = "�p�p"
						A1(i, 2) = ""
						A1(i, 3) = ""
						A1(i, 4) = ""
						A1(i, 5) = ""
						A1(i, 6) = ""
						A1(i, 7) = ""
						A1(i, 8) = ""
						A1(i, 9) = SubSumAdAmt
						A1(i, 10) = SubSumDesAmt
						A1(i, 11) = SubSumChgAmt
						A1(i, 12) = SubSumInvAmt
						A1(i, 13) = ""
						A1(i, 14) = ""
						A1(i, 15) = ""
						A1(i, 16) = ""
						A1(i, 17) = ""
						A1(i, 18) = ""
						A1(i, 19) = ""
						A1(i, 20) = ""
						A1(i, 21) = ""
						A1(i, 22) = ""
						
						' �����ƮɡA�n���]�p�p���B
						SubSumAdAmt = 0
						SubSumDesAmt = 0
						SubSumChgAmt = 0
						SubSumInvAmt = 0
						
						' �����ƮɡA�n��preNo���w���s��
						preNo = Rs1("cont_contno").Value
						
						'----- �榡�]�w -----
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (6+i) & ":W" & (6+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false ) 
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )  
						end if						
					
						' �����ƮɡA�B�z�n�p�p�F�A���Warray index
						i = i + 1
						
						' �����ơA����O�U�@���X���F
						cc = cc + 1
						
						' �����ƮɡA�B�z�ثeRs���Ҧ������
						A1(i,0) = cc
						A1(i,2) = Rs1("cont_contno").Value
						A1(i,3) = Rs1("mfr_inm").Value
						A1(i,4) = Rs1("adr_sdate").Value
						A1(i,5) = Rs1("adr_edate").Value
						A1(i,6) = Rs1("adr_adcate").Value
						A1(i,7) = Rs1("adr_keyword").Value
						A1(i,8) = Rs1("adr_impr").Value
						A1(i,9) = Rs1("adr_adamt").Value
						A1(i,10) = Rs1("adr_desamt").Value
						A1(i,11) = Rs1("adr_chgamt").Value
						A1(i,12) = Rs1("adr_invamt").Value
						A1(i,13) = Rs1("s_adr_drafttp_1").Value
						A1(i,14) = Rs1("s_adr_drafttp_2").Value
						A1(i,15) = Rs1("s_adr_drafttp_3").Value
						A1(i,16) = Rs1("adr_imgurl").Value
						A1(i,17) = Rs1("s_adr_urltp_1").Value
						A1(i,18) = Rs1("s_adr_urltp_2").Value
						A1(i,19) = Rs1("s_adr_urltp_3").Value
						A1(i,20) = Rs1("adr_navurl").Value
						A1(i,21) = Rs1("adr_alttext").Value
						A1(i,22) = Rs1("adr_remark").Value							
					
 					end if
 					
					'----- �榡�]�w -----
					' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
					highlight = "A" & (6+i) & ":W" & (6+i)
					if (i mod 2) = 0
						XLS.FormatCells( 1, highlight, 2, "A1", false ) 
					else
						XLS.FormatCells( 1, highlight, 2, "B1", false )  
					end if	
					
					 					
 					' �p�p�֥[
					SubSumAdAmt = SubSumAdAmt + Rs1("adr_adamt").Value
					SubSumDesAmt = SubSumDesAmt + Rs1("adr_desamt").Value
					SubSumChgAmt = SubSumChgAmt + Rs1("adr_chgamt").Value
					SubSumInvAmt = SubSumInvAmt	+ Rs1("adr_invamt").Value
					
					' �`�p�֥[
					TotalSumAdAmt = TotalSumAdAmt + Rs1("adr_adamt").Value
					TotalSumDesAmt = TotalSumDesAmt + Rs1("adr_desamt").Value
					TotalSumChgAmt = TotalSumChgAmt + Rs1("adr_chgamt").Value
					TotalSumInvAmt = TotalSumInvAmt	+ Rs1("adr_invamt").Value
					

					' Array index���W
					i = i + 1
					
					' �B�zRs1���p�ƻ��W
					rsIndex = rsIndex + 1
				
					' ���U�@�����
					Rs1.MoveNext
					
				end while
				
				' �B�z���F�A�̫᪺�p�p			
				A1(i, 1) = "�p�p"
				A1(i, 2) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = ""
				A1(i, 7) = ""
				A1(i, 8) = ""
				A1(i, 9) = SubSumAdAmt
				A1(i, 10) = SubSumDesAmt
				A1(i, 11) = SubSumChgAmt
				A1(i, 12) = SubSumInvAmt
				A1(i, 13) = ""
				A1(i, 14) = ""
				A1(i, 15) = ""
				A1(i, 16) = ""
				A1(i, 17) = ""
				A1(i, 18) = ""
				A1(i, 19) = ""
				A1(i, 20) = ""
				A1(i, 21) = ""
				A1(i, 22) = ""
				'----- �榡�]�w -----
				' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
				highlight = "A" & (6+i) & ":W" & (6+i)
				if (i mod 2) = 0
					XLS.FormatCells( 1, highlight, 2, "A1", false ) 
				else
					XLS.FormatCells( 1, highlight, 2, "B1", false )  
				end if	
									
				' �`�p
				i = i + 1
				A1(i, 1) = "�`�p"
				A1(i, 2) = ""
				A1(i, 3) = ""
				A1(i, 4) = ""
				A1(i, 5) = ""
				A1(i, 6) = ""
				A1(i, 7) = ""
				A1(i, 8) = ""
				A1(i, 9) = TotalSumAdAmt
				A1(i, 10) = TotalSumDesAmt
				A1(i, 11) = TotalSumChgAmt
				A1(i, 12) = TotalSumInvAmt
				A1(i, 13) = ""
				A1(i, 14) = ""
				A1(i, 15) = ""
				A1(i, 16) = ""
				A1(i, 17) = ""
				A1(i, 18) = ""
				A1(i, 19) = ""
				A1(i, 20) = ""
				A1(i, 21) = ""
				A1(i, 22) = ""				
				
				'----- �榡�]�w -----
				' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
				highlight = "A" & (6+i) & ":W" & (6+i)
				if (i mod 2) = 0
					XLS.FormatCells( 1, highlight, 2, "A1", false ) 
				else
					XLS.FormatCells( 1, highlight, 2, "B1", false )  
				end if					
					
				' Hide Sheet 2
				XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it
					
				' Rows are in 1st Dimension of Array
				XLS.AddRS_Array_2D( A1, true )
					
					
				' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
				'XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
				'XLS.AddVariable("yyyymm", strYYYYMMnew)		' >>$yyyymm
				'XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
				XLS.AddVariable("login_cname", strLoginEmpCName)	' >>$login_cname
				'XLS.AddVariable("bk_nm", BkName)		' >>$bk_nm
				'Response.Write("strYYYYMM= " & strYYYYMM & "<br>")
					
				' Location of Source Workbook
				SrcBook = Server.MapPath("RptAdList.xls")
				
				' Generate SpreadSheet and Stream to Client, Open in Place
				XLS.Generate(SrcBook, "RptAdList.xls", True)
				
				' Destroy object when done
				XLS = Nothing
					
				' Cleanup Code - Close Connection and all Recordsets
				oConn.close
				oConn = Nothing
			'End if
			%>
		</form>
	</body>
</HTML>
