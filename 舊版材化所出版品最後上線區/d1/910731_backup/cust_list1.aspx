<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�q����Ӫ�</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="cust_list" method="post" runat="server">
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
				
				Dim Rs1, Rs2, Rs4, Rs5			' Record Source 1 ~ 5
				Dim sqlcmd1, sqlcmd2, sqlcmd4, sqlcmd5	' SQL Command 1 ~ 5
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' �ۭq sql �ܼ�
				Dim EmpNo
				
				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim EmpCName
				Dim Book01_New, Book01_Old, Book02_New, Book02_Old
				Dim	Book_Other, Book01_Amt, Book02_Amt, Book_Other_Amt
				Dim	preNo, preBook, count
				' Open Database------------------
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				EmpCName = Request("cname") 'Session("cname")
				
				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				sqlcmd1 = "SELECT * FROM tmp_list1"
                sqlcmd1 = sqlcmd1 & " INNER JOIN c1_cust ON tmp_list1.tmp_pyno = c1_cust.cust_custno"
                sqlcmd1 = sqlcmd1 & " INNER JOIN mtp ON tmp_list1.tmp_obtpcd = mtp.mtp_mtpcd"
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				'------- �}�l��X���G ---
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();return true;' Value='�^�W�@��'></FORM><BR>")
				else
					Rs1.MoveFirst
					rescount = 0
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					' Array 1
					ReDim A1(rescount,17)
	
					' Populate Array 1
					preNo = ""
					preBook = ""
					count = 0
					Book01_New = 0
					Book01_Old = 0
					Book02_New = 0
					Book02_Old = 0
					Book_Other = 0
					Book01_Amt = 0
					Book02_Amt = 0
					Book_Other_Amt = 0
					for i = 0 to rescount - 1 step 1
						' A �� = A1(i,0)
						if Rs1("tmp_no").Value = preNo then
							A1(i,0) = ""
							A1(i,1) = ""
							A1(i,2) = ""
							A1(i,3) = ""
							A1(i,4) = ""
							A1(i,5) = ""
							A1(i,6) = ""
							if Rs1("tmp_obtpnm").Value = preBook then
								A1(i,7) = ""
							else
								A1(i,7) = Rs1("tmp_obtpnm").Value
							end if
						else
							A1(i,0) = count + 1
							count = count + 1
							A1(i,1) = Rs1("tmp_no").Value
							A1(i,2) = Mid(Rs1("tmp_rmdate").Value, 1, 4) & "/" & Mid(Rs1("tmp_rmdate").Value, 5, 2) & "/" & Mid(Rs1("tmp_rmdate").Value, 7, 2)
							A1(i,3) = Rs1("cust_custno").Value
							A1(i,4) = Rs1("cust_oldcustno1").Value
							A1(i,5) = Rs1("cust_oldcustno2").Value
							A1(i,6) = Rs1("cust_nm").Value
							A1(i,7) = Rs1("tmp_obtpnm").Value
						end if
						A1(i,8) = Rs1("tmp_nm").Value
						A1(i,9) = Rs1("tmp_inm").Value
						A1(i,10) = Rs1("tmp_zip").Value
						A1(i,11) = Rs1("tmp_addr").Value
						A1(i,12) = Rs1("tmp_tel").Value
						A1(i,13) = Mid(Rs1("tmp_datestr").Value, 1, 4) & "/" & Mid(Rs1("tmp_datestr").Value, 5, 2) & "/" & Mid(Rs1("tmp_datestr").Value, 7, 3) & Mid(Rs1("tmp_datestr").Value, 10, 4) & "/" & Mid(Rs1("tmp_datestr").Value, 14, 2) & "/" & Mid(Rs1("tmp_datestr").Value, 16, 2)
						A1(i,14) = Rs1("mtp_nm").Value
						A1(i,15) = Rs1("tmp_mnt").Value
						
						preNo = Rs1("tmp_no").Value
						preBook = Rs1("tmp_obtpnm").Value
						
						' ��X�X�p����, ���ର�ܼƫ��A
						
						Rs1.MoveNext
						
						if Rs1.EOF
	    					exit for
						end if
					next
					
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					
					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("srspn_cname", EmpCName)		' >>$srspn_cname
'					XLS.AddVariable("book01_new", Book01_New)		' >>$book01_new
'					XLS.AddVariable("book01_old", Book01_Old)		' >>$book01_old
'					XLS.AddVariable("book02_new", Book02_New)		' >>$book02_new
'					XLS.AddVariable("book02_old", Book02_Old)		' >>$book02_old
'					XLS.AddVariable("book_other", Book_Other)		' >>$book_other
'					XLS.AddVariable("book01_amt", Book01_Amt)		' >>$book01_amt
'					XLS.AddVariable("book02_amt", Book02_Amt)		' >>$book02_amt
'					XLS.AddVariable("book_other_amt", Book_Other_Amt)		' >>$book_other_amt
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("cust_list1.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "cust_list1.xls", True)
					
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
