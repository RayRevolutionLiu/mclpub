<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i���X�M��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="RptGenXml" method="post" runat="server">
			
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
				DIM TargetDate = Request("TargetDate")
				sqlcmd1 = "SELECT adr_imgurl, adr_navurl, adr_alttext, adr_adcate=CASE WHEN adr_adcate='M' THEN '����' WHEN adr_adcate='I' THEN '����' ELSE '�`��' END, adr_keyword=CASE WHEN adr_keyword='h0' THEN '����' WHEN adr_keyword='h1' THEN '�k�@' WHEN adr_keyword='h2' THEN '�k�G' WHEN adr_keyword='h3' THEN '�k�T' WHEN adr_keyword='h4' THEN '�k�|' WHEN adr_keyword='w1' THEN '��@' WHEN adr_keyword='w2' THEN '��G' WHEN adr_keyword='w3' THEN '��T' WHEN adr_keyword='w4' THEN '��|' WHEN adr_keyword='w5' THEN '�夭' WHEN adr_keyword='w6' THEN '�夻' ELSE '' END, adr_impr, cont_contno, adr_seq, adr_remark=CASE WHEN adr_remark='&nbsp;' THEN '' END FROM  dbo.c4_adr INNER JOIN c4_cont ON cont_contno=adr_contno "+ " WHERE adr_sdate<='" + TargetDate + "' AND adr_edate>='" + TargetDate + "'"		
				
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
				ReDim A1(rescount+8, 9)	
				
				Dim count							
				i = 0
				count = 1
							
				Dim preNo
				Dim highlight
				' �Ψӭp��B�z�F�h�ֵ����
				Dim rsIndex
				'�X���p��
				Dim cc								
				
				' ��X�Ĥ@�����
				if NOT Rs1.EOF then
					A1(i,0) = Rs1("adr_imgurl").Value
					A1(i,1) = Rs1("adr_navurl").Value
					A1(i,2) = Rs1("adr_alttext").Value
					A1(i,3) = Rs1("adr_adcate").Value				
					A1(i,4) = Rs1("adr_keyword").Value
					A1(i,5) = Rs1("adr_impr").Value
					A1(i,6) = Rs1("cont_contno").Value
					A1(i,7) = Rs1("adr_seq").Value
					A1(i,8) = Rs1("adr_remark").Value
					
					'----- �榡�]�w -----
					' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
					highlight = "A" & (6+i) & ":I" & (6+i)
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
					
					A1(i,0) = Rs1("adr_imgurl").Value
					A1(i,1) = Rs1("adr_navurl").Value
					A1(i,2) = Rs1("adr_alttext").Value
					A1(i,3) = Rs1("adr_adcate").Value				
					A1(i,4) = Rs1("adr_keyword").Value
					A1(i,5) = Rs1("adr_impr").Value
					A1(i,6) = Rs1("cont_contno").Value
					A1(i,7) = Rs1("adr_seq").Value
					A1(i,8) = Rs1("adr_remark").Value
 					
					'----- �榡�]�w -----
					' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
					highlight = "A" & (6+i) & ":I" & (6+i)
					if (i mod 2) = 0
						XLS.FormatCells( 1, highlight, 2, "A1", false ) 
					else
						XLS.FormatCells( 1, highlight, 2, "B1", false )  
					end if	
					
					 					
					' Array index���W
					i = i + 1
					
					' �B�zRs1���p�ƻ��W
					rsIndex = rsIndex + 1
				
					' ���U�@�����
					Rs1.MoveNext
					
				end while
					
					
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
				XLS.AddVariable("now", DateTime.Today.ToString("yyyy/MM/dd"))
					
				' Location of Source Workbook
				SrcBook = Server.MapPath("RptGenXml.xls")
				
				' Generate SpreadSheet and Stream to Client, Open in Place
				XLS.Generate(SrcBook, "RptGenXml.xls", True)
				
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
