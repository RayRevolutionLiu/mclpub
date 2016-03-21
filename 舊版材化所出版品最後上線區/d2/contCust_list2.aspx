<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>C2 �Ȥ�򥻸�ƲM��</title>
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

				Dim Rs1, Rs2			' Record Source 1 ~ 2
				Dim Rs5, Rs9			' Record Source 5, 9
				Dim sqlcmd1, sqlcmd2	' SQL Command 1 ~ 2
				Dim sqlcmd5, sqlcmd9	' SQL Command 5, 9
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook


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
				Dim strCustNoQ1, strCustNoQ2, strTelAC, strItpcd, strBtpcd, strRtpcd, strConttp, strConttpName
				Dim strEmpNo, strStartDate, strEndDate, strfgclosed, strBkcd, BkName, strLoginEmpNo, strLoginEmpCName
				Dim strSearchQuery1, strSearchQuery2
				strSearchQuery1 = ""
				strSearchQuery2 = ""
				strCustNoQ1 = Request("CustNoQ1")
				strCustNoQ2 = Request("CustNoQ2")
				strTelAC = Request("TelAC")
				strItpcd = Request("Itpcd")
				strBtpcd = Request("Btpcd")
				strRtpcd = Request("Rtpcd")
				strConttp = Request("conttp")
				strEmpNo = Request("empno")
				strStartDate = Request("sdate")
				strEndDate = Request("edate")
				strfgclosed = Request("fgclosed")
				strBkcd = Request("bkcd")
				strLoginEmpNo = Request("LEmpNo")
				if(Trim(strLoginEmpNo) <> "") then
					strLoginEmpNo = Trim(Request("LEmpNo"))

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
				'Response.Write("strLoginEmpNo= " & strLoginEmpNo & "<br>")
				'Response.Write("strTelAC= " & strTelAC & "<br>")
				
				
				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM v_c2_contCust "
				sqlcmd2 = sqlcmd2 & " WHERE         (1=1) "
				if(Request("CustNoQ1") <> "") then
					strCustNoQ1 = Request("CustNoQ1")
					sqlcmd2 = sqlcmd2 & " AND (cont_custno >= '" & strCustNoQ1 & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("CustNoQ2") <> "") then
					strCustNoQ2 = Request("CustNoQ2")
					sqlcmd2 = sqlcmd2 & " AND (cont_custno <= '" & strCustNoQ2 & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("TelAC") <> "") then
					strTelAC = Request("TelAC")
					sqlcmd2 = sqlcmd2 & " AND (SUBSTRING(cust_tel, 1, 3) LIKE '" & strTelAC & "%') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("Itpcd") <> "") then
					strItpcd = Request("Itpcd")
					sqlcmd2 = sqlcmd2 & " AND (cust_itpcd = '" & strItpcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("Btpcd") <> "") then
					strBtpcd = Request("Btpcd")
					sqlcmd2 = sqlcmd2 & " AND (cust_btpcd = '" & strBtpcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("Rtpcd") <> "") then
					strRtpcd = Request("Rtpcd")
					sqlcmd2 = sqlcmd2 & " AND (cust_rtpcd = '" & strRtpcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd2 = sqlcmd2 & " AND (cont_conttp = '" & strConttp & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("EmpNo") <> "") then
					strEmpNo = Request("EmpNo")
					sqlcmd2 = sqlcmd2 & " AND (cont_empno = '" & strEmpNo & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("sdate") <> "") then
					strStartDate = Request("sdate")
					sqlcmd2 = sqlcmd2 & " AND (cont_sdate >= '" & strStartDate & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("edate") <> "") then
					strEndDate = Request("edate")
					sqlcmd2 = sqlcmd2 & " AND (cont_edate <= '" & strEndDate & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("fgclosed") <> "") then
					strfgclosed = Request("fgclosed")
					sqlcmd2 = sqlcmd2 & " AND (cont_fgclosed = '" & strfgclosed & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd2 = sqlcmd2 & " AND (cont_bkcd = '" & strBkcd & "') "
				else
					sqlcmd2 = sqlcmd2
				end if
				'Response.Write("sqlcmd2= " & sqlcmd2 & "<br>")
				
				
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
				sqlcmd1 = "SELECT * FROM v_c2_contCust "
				sqlcmd1 = sqlcmd1 & " WHERE         (1=1) "
				if(Request("CustNoQ1") <> "") then
					strCustNoQ1 = Request("CustNoQ1")
					sqlcmd1 = sqlcmd1 & " AND (cont_custno >= '" & strCustNoQ1 & "') "
					strSearchQuery1 = strSearchQuery1 & "  �Ȥ�s���d��G" & strCustNoQ1
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("CustNoQ2") <> "") then
					strCustNoQ2 = Request("CustNoQ2")
					sqlcmd1 = sqlcmd1 & " AND (cont_custno <= '" & strCustNoQ2 & "') "
					strSearchQuery1 = strSearchQuery1 & " ~ " & strCustNoQ2
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("TelAC") <> "") then
					strTelAC = Request("TelAC")
					sqlcmd1 = sqlcmd1 & " AND (SUBSTRING(cust_tel, 1, 3) LIKE '" & strTelAC & "%') "
					strSearchQuery1 = strSearchQuery1 & "  �Ȥ�(�q�ܸ��X)�ϰ�X�G" & strTelAC
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("Itpcd") <> "") then
					strItpcd = Request("Itpcd")
					sqlcmd1 = sqlcmd1 & " AND (cust_itpcd = '" & strItpcd & "') "
					strSearchQuery1 = strSearchQuery1 & "  �Ȥ���N�X�G" & strItpcd
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("Btpcd") <> "") then
					strBtpcd = Request("Btpcd")
					sqlcmd1 = sqlcmd1 & " AND (cust_btpcd = '" & strBtpcd & "') "
					strSearchQuery1 = strSearchQuery1 & "  �Ȥ���~�N�X�G" & strBtpcd
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("Rtpcd") <> "") then
					strRtpcd = Request("Rtpcd")
					sqlcmd1 = sqlcmd1 & " AND (cust_rtpcd = '" & strRtpcd & "') "
					strSearchQuery1 = strSearchQuery1 & "  �Ȥ�\Ū�N�X�G" & strRtpcd
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")
					sqlcmd1 = sqlcmd1 & " AND (cont_conttp = '" & strConttp & "') "
					if(strConttp = "01") then
						strConttpName = "�@��"
					end if
					if(strConttp = "09") then
						strConttpName = "���s"
					end if
					strSearchQuery2 = strSearchQuery2 & "  �X�����O�G" & strConttp
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("EmpNo") <> "") then
					strEmpNo = Request("EmpNo")
					sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & strEmpNo & "') "
					strSearchQuery2 = strSearchQuery2 & "  �ӿ�~�ȭ��G" & strEmpNo
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("sdate") <> "") then
					strStartDate = Request("sdate")
					sqlcmd1 = sqlcmd1 & " AND (cont_sdate >= '" & strStartDate & "') "
					strSearchQuery2 = strSearchQuery2 & "  �X���_���϶��G" & strStartDate
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("edate") <> "") then
					strEndDate = Request("edate")
					sqlcmd1 = sqlcmd1 & " AND (cont_edate <= '" & strEndDate & "') "
					strSearchQuery2 = strSearchQuery2 & " ~ " & strEndDate
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("fgclosed") <> "") then
					strfgclosed = Request("fgclosed")
					sqlcmd1 = sqlcmd1 & " AND (cont_fgclosed = '" & strfgclosed & "') "
					strSearchQuery2 = strSearchQuery2 & "  �w���סG" & strfgclosed
				else
					sqlcmd1 = sqlcmd1
				end if
				if(Request("bkcd") <> "") then
					strBkcd = Request("bkcd")
					sqlcmd1 = sqlcmd1 & " AND (cont_bkcd = '" & strBkcd & "') "
					
					' Get Rs5: �Ǯ��y�N�X��X���y�W��
					' Open the RecordSets
					sqlcmd5 = "SELECT * FROM book"
					sqlcmd5 = sqlcmd5 & " WHERE (bk_bkcd='" + strBkcd + "')"
					Rs5 = oConn.Execute(sqlcmd5)
					BkName = Rs5("bk_nm").Value
					'Response.Write("BkName= " & BkName & "<br>")
					strSearchQuery2 = strSearchQuery2 & "  ���y���O�G" & BkName
				else
					sqlcmd1 = sqlcmd1
				end if
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
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='��������'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='�^�W�@��'--></FORM><BR>")

				' �Y�����, �h��X�� ExcelSpeedGen
				else
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
					ReDim A1(rescount,26)

					' Populate Array 1
					Dim preNo, count
					preNo = ""
					count = 0
					for i = 0 to rescount - 1 step 1
						'Response.Write("i= " & i & ", ")
						'Response.Write("cont_contno= " & Rs1("cont_contno").Value & ", ")
						'Response.Write("preNo= " & preNo & "<br>")
						
						' �H�U���L�׭��лP�_, �@�w�n�X�{����ƶ�
						Dim strCustNmJbti
						A1(i,1) = Rs1("cont_custno").Value
						A1(i,2) = Rs1("cont_mfrno").Value
						A1(i,3) = Rs1("cont_aunm").Value
						A1(i,4) = Rs1("cont_autel").Value
						A1(i,5) = Rs1("cont_aufax").Value
						A1(i,6) = Rs1("cont_aucell").Value
						A1(i,7) = Rs1("cont_auemail").Value
						if(Trim(Rs1("cust_nm").Value) <> "") then
							strCustNmJbti = Rs1("cust_nm").Value
							if(Trim(Rs1("cust_jbti").Value) <> "") then
								A1(i,8) = strCustNmJbti & " / " & Trim(Rs1("cust_jbti").Value)
							 else
							 	A1(i,8) = strCustNmJbti
							 end if
						else
							strCustNmJbti = ""
							A1(i, 8) = strCustNmJbti
						end if
						A1(i,9) = Rs1("cust_tel").Value
						A1(i,10) = Rs1("cust_fax").Value
						A1(i,11) = Rs1("cust_cell").Value
						A1(i,12) = Rs1("cust_email").Value
						A1(i,13) = Rs1("cust_itpcd").Value
						A1(i,14) = Rs1("cust_btpcd").Value
						A1(i,15) = Rs1("cust_rtpcd").Value
						A1(i,16) = Rs1("mfr_inm").Value
						A1(i,17) = Rs1("mfr_izip").Value & " " & Rs1("mfr_iaddr").Value
						A1(i,18) = Rs1("cust_regdate").Value
						A1(i,19) = Rs1("or_nm").Value
						A1(i,20) = Rs1("mfr_respnm").Value
						A1(i,21) = Rs1("cont_contno").Value
						'A1(i,22) = Rs1("cont_conttp").Value
						if(Rs1("cont_conttp").Value = "01") then
							A1(i,22) = "�@��"
						end if
						if(Rs1("cont_conttp").Value = "09") then
							A1(i,22) = "���s"
						end if
						A1(i,23) = Rs1("bk_nm").Value
						'A1(i,24) = Rs1("cont_fgclosed").Value
						if(Rs1("cont_fgclosed").Value = "0") then
							A1(i,24) = "�_"
						end if
						if(Rs1("cont_fgclosed").Value = "1") then
							A1(i,24) = "�O"
						end if
						'A1(i,25) = Rs1("cont_fgcancel").Value
						if(Rs1("cont_fgcancel").Value = "0") then
							A1(i,25) = "�_"
						end if
						if(Rs1("cont_fgcancel").Value = "1") then
							A1(i,25) = "�O"
						end if
						preNo = Rs1("cont_custno").Value


						Dim highlight2, highlight3
						' Highlight Some Rows: �����S�O���ϥΪ��榡 A2/B2 (���B�O���m���B�z; �S�O�榡�g�b sheet 2 �����w����)
						' �S�O��� (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �`�N FormatCells �S�O��� ���{���X�@�w�n��b FormatCells �@����쪺�{���X "�e��", �_�h�S�O���L�k���
						'highlight2 = "G" & (6+i)
						'if (i mod 2) = 0
							'XLS.FormatCells( 1, highlight2, 2, "A8", false )
						'else
							'XLS.FormatCells( 1, highlight2, 2, "B8", false )
						'end if
						'Response.Write("highlight2= " & highlight2 & "<br>")


						Dim highlight
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (6+i) & ":Z" & (6+i)
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

					' Set Estimated Output File Size (Critical for speed)
					XLS.EstimatedSize = 50000

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )

					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					if(Trim(strSearchQuery1) = "")
						strSearchQuery1 = "(�L)"
					end if
					if(Trim(strSearchQuery2) = "")
						strSearchQuery2 = "(�L)"
					end if
					XLS.AddVariable("srspn_cname", strLoginEmpCName)	' >>$srspn_cname
					XLS.AddVariable("SearchQuery1", strSearchQuery1)' >>$SearchQuery1
					XLS.AddVariable("SearchQuery2", strSearchQuery2)' >>$SearchQuery2

					' Location of Source Workbook
					SrcBook = Server.MapPath("contCust_list2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "contCust_list2a.xls", True)

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
