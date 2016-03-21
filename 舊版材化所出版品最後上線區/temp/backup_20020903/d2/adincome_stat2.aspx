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
				
				Dim Rs1, Rs2, Rs5				' Record Source 1 ~ 2, 5
				Dim sqlcmd1, sqlcmd2, sqlcmd5	' SQL Command 1 ~ 2, 5
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' �ۭq sql �ܼ�
				Dim EmpNo
				
				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim EmpCName
				
				
				' Open Database------------------
				' a. Open a Microsoft Access Database
					'dbFile = Server.MapPath("test.mdb")
					'oConn = Server.CreateObject("ADODB.Connection")
					'oConn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFile)
				  
				' b. Open a Microsoft SQL Server Database
					DSN = ConfigurationSettings.AppSettings("mrlpub")
					oConn = Server.CreateObject("ADODB.Connection")
					oConn.Open(DSN)
					'oConn.Open("Provider=SQLOLEDB.1;Data Source=isccom1;User ID=webuser;Password=db600;Initial Catalog=mrlpub")
					'oConn.Open("provider=sqloledb;server=isccom1; uid=webuser; pwd=db600; database=mrlpub")
				
				' �۫e�@����ǻ� form �����ܼ� empno, �H��X EmpNo, EmpCName
				EmpNo = Request("empno")
				
				' Get Rs5: �Ƿ~�ȭ��u����X�~�ȭ��m�W
				' Open the RecordSets
				sqlcmd5 = "SELECT * FROM srspn"
				sqlcmd5 = sqlcmd5 & " WHERE (srspn_empno='" + EmpNo + "')"
				Rs5 = oConn.Execute(sqlcmd5)
				EmpCName = Rs5("srspn_cname").Value
				'Response.Write("EmpCName= " & EmpCName & "<br>")			
				
				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT COUNT(*) AS CountNo, cont_fgclosed "
				sqlcmd2 = sqlcmd2 & "FROM dbo.c2_cont "
				sqlcmd2 = sqlcmd2 & "GROUP BY cont_fgclosed, cont_empno "
				sqlcmd2 = sqlcmd2 & " HAVING (cont_fgclosed <> '1') AND (cont_empno = '" & EmpNo & "')"
				Rs2 = oConn.Execute(sqlcmd2)
				if Rs2.EOF then
					rescount = 0
					Response.Write("<FONT Color=Red><B>�d�ߵ��G - ���Ƭ� 0</B></FONT><BR>")
				else
					rescount = Rs2(0).Value
				end if
				'Response.Write("rescount= " & rescount & "<br>")
				
				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				'sqlcmd1 = sqlcmd1 & "SELECT * FROM book INNER JOIN c2_cont ON book.bk_bkcd = c2_cont.cont_bkcd"
				sqlcmd1 = "SELECT DISTINCT "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_contno, mfr.mfr_inm, c2_cont.cont_pubamt, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_chgamt, MAX(c2_pub.pub_pubseq) AS PubSeq, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_totamt "
				sqlcmd1 = sqlcmd1 & " FROM c2_cont INNER JOIN c2_pub "
				sqlcmd1 = sqlcmd1 & " ON c2_cont.cont_contno = c2_pub.pub_contno "
				sqlcmd1 = sqlcmd1 & " AND c2_cont.cont_syscd = c2_pub.pub_syscd "
				sqlcmd1 = sqlcmd1 & " INNER JOIN mfr "
				sqlcmd1 = sqlcmd1 & " ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " GROUP BY c2_cont.cont_contno, mfr.mfr_inm, c2_cont.cont_pubamt, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_chgamt, c2_cont.cont_totamt, "
				sqlcmd1 = sqlcmd1 & " c2_cont.cont_fgclosed, dbo.c2_cont.cont_empno "
				sqlcmd1 = sqlcmd1 & " HAVING (c2_cont.cont_fgclosed <> '1') "
				sqlcmd1 = sqlcmd1 & " AND (cont_empno = '" & EmpNo & "')"
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				
				'------- �}�l��X���G ---
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='history.go( -1 );return true;' Value='�^�W�@��'></FORM><BR>")
				
				' �Y�����, �h��X�� ExcelSpeedGen
				else
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					
					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it
					
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					XLS.AddRS_ADO(Rs1, 20)
					
					' Highlight Some Rows: �����@�����ϥΪ��榡
					Dim highlight
					for i = 0 to rescount
						highlight = "A" & (7+i) & ":F" & (7+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false ) 
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )  
						end if
						
						' �����S�O���ϥΪ��榡 (=> �`�@�h��) - �H FormatCells �ӭ��s�H��榡���
						' �S�O�榡�g�b sheet 2 �����w����, �p A8/B8, A5/B5
						Dim PubSeqhighlight, PubAmthighlight, ChgAmthighlight, TotAmthighlight
						PubSeqhighlight = "E" & (7+i) 
						PubAmthighlight = "C" & (7+i) 
						ChgAmthighlight = "D" & (7+i) 
						TotAmthighlight = "F" & (7+i) 
						if (i mod 2) = 0 then
							' �_�Ʀ�, �H sheet2 ���w��쪺 Format ���
							XLS.FormatCells( 1, PubSeqhighlight, 2, "A8", false ) 
							XLS.FormatCells( 1, PubAmthighlight, 2, "A5", false ) 
							XLS.FormatCells( 1, ChgAmthighlight, 2, "A5", false ) 
							XLS.FormatCells( 1, TotAmthighlight, 2, "A5", false ) 
						else
							' ���Ʀ�, �H sheet2 ���w��쪺 Format ���
							XLS.FormatCells( 1, PubSeqhighlight, 2, "B8", false )  
							XLS.FormatCells( 1, PubAmthighlight, 2, "B5", false )  
							XLS.FormatCells( 1, ChgAmthighlight, 2, "B5", false )  
							XLS.FormatCells( 1, TotAmthighlight, 2, "B5", false )  
						end if
						
						Rs1.MoveNext
						
						if Rs1.EOF
	    					exit for
						end if
					next
					
					
					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("adincome_stat2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "adincome_stat2a.xls", True)
					
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
