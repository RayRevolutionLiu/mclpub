<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�Ȥ�򥻸�ƲM��</title>
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
				Dim sqlcmd1, sqlcmd2	' SQL Command 1 ~ 2
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

				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM dbo.cust "
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
				'sqlcmd1 = sqlcmd1 & "SELECT * FROM book INNER JOIN c2_cont ON book.bk_bkcd = c2_cont.cont_bkcd"
				sqlcmd1 = "SELECT cust.cust_custno, cust.cust_mfrno, cust.cust_nm, "
				sqlcmd1 = sqlcmd1 & " cust.cust_jbti, cust.cust_tel, cust.cust_fax, cust.cust_cell, "
				sqlcmd1 = sqlcmd1 & " cust.cust_email, cust.cust_itpcd, cust.cust_btpcd, "
				sqlcmd1 = sqlcmd1 & " cust.cust_rtpcd, mfr.mfr_inm, mfr.mfr_izip, mfr.mfr_iaddr, "
				sqlcmd1 = sqlcmd1 & " cust.cust_regdate, mfr.mfr_respnm "
				sqlcmd1 = sqlcmd1 & " FROM cust INNER JOIN "
				sqlcmd1 = sqlcmd1 & " mfr ON cust.cust_mfrno = mfr.mfr_mfrno"				
				dim sql_where = ""
				If not (Request.QueryString("CustNoQ1") Is Nothing) Then
					sql_where = sql_where & "cust_custno > '" + Request.QueryString("CustNoQ1") + "'"
				End If
				If not (Request.QueryString("CustNoQ2") Is Nothing) Then
					sql_where = sql_where & "cust_custno < '" + Request.QueryString("CustNoQ2") + "'"
				End If		
				If not (Request.QueryString("TelAC") Is Nothing) Then
					sql_where = sql_where & "cust_tel like '%" + Request.QueryString("TelAC") + "%'"
				End If								
				
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

					' Array 1
					ReDim A1(rescount*2,17)

					' Populate Array 1
					for i = 0 to rescount*2 - 1 step 2
						' ���լO�_�쪺�� result (���n���� XLS.Generate() ���� disable, �~�ݱo�� Response.Write ���G)
						'Response.Write(Rs1("cust_custno").Value + ", ")

						' A �� = A1(i,0)
						A1(i,0) = Rs1("cust_custno").Value
						A1(i+1,0) = ""
						A1(i,1) = Rs1("cust_mfrno").Value
						A1(i+1,1) = Rs1("mfr_inm").Value
						A1(i,2) = Rs1("cust_nm").Value
						A1(i+1,2) = Rs1("mfr_izip").Value
						A1(i,3) = Rs1("cust_jbti").Value
						A1(i+1,3) = Rs1("mfr_iaddr").Value

						' E �� = A1(i,4)
						A1(i,4) = Rs1("cust_tel").Value
						A1(i+1,4) = Mid(Rs1("cust_regdate").Value, 1, 4) & "/" & Mid(Rs1("cust_regdate").Value, 5, 2) & "/" & Mid(Rs1("cust_regdate").Value, 7, 2)
						A1(i,5) = Rs1("cust_fax").Value
						A1(i+1,5) = ""
						A1(i,6) = Rs1("cust_cell").Value
						A1(i+1,6) = Rs1("mfr_respnm").Value
						A1(i,7) = Rs1("cust_email").Value
						A1(i+1,7) = ""

						' I �� = A1(i,8)
						A1(i,8) = Rs1("cust_itpcd").Value
						A1(i+1,8) = ""
						A1(i,9) = Rs1("cust_btpcd").Value
						A1(i+1,9) = ""
						A1(i,10) = Rs1("cust_rtpcd").Value
						A1(i+1,10) = ""

						'A1(i,13) = Rs1("cust_itpcd").Value
						'if(Rs1("cust_itpcd").Value=01)
							'A1(i,13) = "�_"
						'else
							'A1(i,13) = "�O"
						'end if


						' Highlight Some Rows: �����@�����ϥΪ��榡
						Dim highlight
						highlight = "A" & (6+i) & ":K" & (7+i)
						if (i mod 4) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false )
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )
						end if
						Rs1.MoveNext

						if Rs1.EOF
	    					exit for
						end if
					next

					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Set Estimated Output File Size (Critical for speed)
					XLS.EstimatedSize = 50000

					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )

					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					'XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname


					' Location of Source Workbook
					SrcBook = Server.MapPath("custdata_list2.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "custdata_list2a.xls", True)

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
