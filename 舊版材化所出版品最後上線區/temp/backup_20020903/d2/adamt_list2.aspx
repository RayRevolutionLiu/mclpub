<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�O���ˬd�M��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="adamt_list2" method="post" runat="server">
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
				
				Dim Rs1, Rs2, Rs3, Rs5, Rs6						' Record Source 1 ~ 5
				Dim sqlcmd1, sqlcmd2, sqlcmd3, sqlcmd5, sqlcmd6	' SQL Command 1 ~ 5
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' �ۭq sql �ܼ�
				Dim EmpNo, BookCode, EndDate
				
				' �ۭq�ܼ� (�ѥN�X���X�� .xls ���W��)
				Dim EmpCName, BookName
				
				
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
				BookCode = Request("bkcd")
				EmpNo = Request("empno")
				EndDate = Request("enddate")
				'Response.Write("BookCode= " & BookCode & "<br>")			
				'Response.Write("EmpNo= " & EmpNo & "<br>")			
				'Response.Write("EndDate= " & EndDate & "<br>")			
				
				
				' Get Rs5: �Ƿ~�ȭ��u����X�~�ȭ��m�W
				' Open the RecordSets
				sqlcmd5 = "SELECT * FROM srspn"
				sqlcmd5 = sqlcmd5 & " WHERE (srspn_empno='" + EmpNo + "')"
				Rs5 = oConn.Execute(sqlcmd5)
				EmpCName = Rs5("srspn_cname").Value
				'Response.Write("EmpCName= " & EmpCName & "<br>")			
				
				' Get Rs3: �Ǯ��y���O�N�X��X���y�W��
				' Open the RecordSets
				sqlcmd3 = "SELECT * FROM book"
				sqlcmd3 = sqlcmd3 & " WHERE (bk_bkcd='" + BookCode + "')"
				Rs3 = oConn.Execute(sqlcmd3)
				BookName = Rs3("bk_nm").Value
				'Response.Write("BookName= " & BookName & "<br>")			
				
				
				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				'sqlcmd2 = "SELECT Count(*) As CountNo "
				'sqlcmd2 = sqlcmd2 & " FROM v_c2_adamt_list2a "
				sqlcmd2 = "SELECT Count(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM mfr "
				sqlcmd2 = sqlcmd2 & " INNER JOIN c2_cont ON mfr.mfr_mfrno = c2_cont.cont_mfrno "
				sqlcmd2 = sqlcmd2 & " INNER JOIN v_c2_adamt_list2 "
				sqlcmd2 = sqlcmd2 & " ON c2_cont.cont_contno = v_c2_adamt_list2.pub_contno "
				sqlcmd2 = sqlcmd2 & " LEFT OUTER JOIN c2_pgsize "
				sqlcmd2 = sqlcmd2 & " ON v_c2_adamt_list2.pub_pgscd = c2_pgsize.pgs_pgscd "
				sqlcmd2 = sqlcmd2 & " LEFT OUTER JOIN c2_clr "
				sqlcmd2 = sqlcmd2 & " ON v_c2_adamt_list2.pub_clrcd = c2_clr.clr_clrcd "
				sqlcmd2 = sqlcmd2 & " LEFT OUTER JOIN c2_ltp "
				sqlcmd2 = sqlcmd2 & " ON v_c2_adamt_list2.pub_ltpcd = c2_ltp.ltp_ltpcd "
				sqlcmd2 = sqlcmd2 & " WHERE (c2_cont.cont_bkcd = '" & BookCode & "') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_edate >= '" & EndDate & "') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_empno = '" & EmpNo & "') "
				sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgclosed <> '1' ) "
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
				'sqlcmd1 = "SELECT * "
				'sqlcmd1 = sqlcmd1 & " FROM v_c2_adamt_list2a "
				sqlcmd1 = "SELECT v_c2_adamt_list2.pub_contno, c2_clr.clr_nm, c2_pgsize.pgs_nm,  "
				sqlcmd1 = sqlcmd1 & " c2_ltp.ltp_nm, c2_cont.cont_mfrno, mfr.mfr_inm, mfr.mfr_izip, "
				sqlcmd1 = sqlcmd1 & " mfr.mfr_iaddr, v_c2_adamt_list2.Total_pub_adamt, "
				sqlcmd1 = sqlcmd1 & " v_c2_adamt_list2.Total_pub_chgamt, v_c2_adamt_list2.TotalAmt, "
				sqlcmd1 = sqlcmd1 & " v_c2_adamt_list2.ContNoCounts "
				sqlcmd1 = sqlcmd1 & " FROM mfr "
				sqlcmd1 = sqlcmd1 & " INNER JOIN c2_cont ON mfr.mfr_mfrno = c2_cont.cont_mfrno "
				sqlcmd1 = sqlcmd1 & " INNER JOIN v_c2_adamt_list2 "
				sqlcmd1 = sqlcmd1 & " ON c2_cont.cont_contno = v_c2_adamt_list2.pub_contno "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_pgsize "
				sqlcmd1 = sqlcmd1 & " ON v_c2_adamt_list2.pub_pgscd = c2_pgsize.pgs_pgscd "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_clr "
				sqlcmd1 = sqlcmd1 & " ON v_c2_adamt_list2.pub_clrcd = c2_clr.clr_clrcd "
				sqlcmd1 = sqlcmd1 & " LEFT OUTER JOIN c2_ltp "
				sqlcmd1 = sqlcmd1 & " ON v_c2_adamt_list2.pub_ltpcd = c2_ltp.ltp_ltpcd "
				sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_bkcd = '" & BookCode & "') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_edate >= '" & EndDate & "') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_empno = '" & EmpNo & "') "
				sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgclosed <> '1' ) "
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				
				' Get Rs6: ��X Excel �ɪ��̬Y�Ƕ��p�⪺������ - �s�i���B, ���Z���B, �`��, ����, �o���ӽг�s��
				'sqlcmd6 = "SELECT * "
				'sqlcmd6 = sqlcmd6 & " FROM v_c2_adamt_list2b "
				sqlcmd6 = "SELECT c2_pub.pub_contno, SUM(c2_pub.pub_adamt) AS Total_pub_adamt, "
				sqlcmd6 = sqlcmd6 & " SUM(c2_pub.pub_chgamt) AS Total_pub_chgamt, "
				sqlcmd6 = sqlcmd6 & " SUM(c2_pub.pub_adamt + c2_pub.pub_chgamt) AS TotalAmt, "
				sqlcmd6 = sqlcmd6 & " COUNT(c2_pub.pub_contno) AS ContNoCounts "
				sqlcmd6 = sqlcmd6 & " FROM c2_cont "
				sqlcmd6 = sqlcmd6 & " INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd "
				sqlcmd6 = sqlcmd6 & " AND c2_cont.cont_contno = c2_pub.pub_contno "
				sqlcmd6 = sqlcmd6 & " GROUP BY c2_pub.pub_contno, c2_cont.cont_bkcd, c2_cont.cont_edate, "
				sqlcmd6 = sqlcmd6 & " c2_cont.cont_empno, dbo.c2_cont.cont_fgclosed "
				sqlcmd6 = sqlcmd6 & " HAVING (c2_cont.cont_bkcd = '" & BookCode & "') "
				sqlcmd6 = sqlcmd6 & " AND (c2_cont.cont_edate >= '" & EndDate & "') "
				sqlcmd6 = sqlcmd6 & " AND (c2_cont.cont_empno = '" & EmpNo & "') "
				sqlcmd6 = sqlcmd6 & " AND (c2_cont.cont_fgclosed <> '1' ) "
				Rs6 = oConn.Execute(sqlcmd6)
				
				
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
					
					' Array 1
					ReDim A1(rescount*2,13)
					
					' Highlight Some Rows: �����@�����ϥΪ��榡
					Dim highlight
					for i = 0 to rescount*2 - 1 step 2
						' ���լO�_�쪺�� result (���n���� XLS.Generate() ���� disable, �~�ݱo�� Response.Write ���G)
						'Response.Write("i= " & i & ", ")
						'Response.Write(Rs1("pub_contno").Value & ", ")
						'Response.Write(Rs1("clr_nm").Value & ", ")
						'Response.Write(Rs1("pgs_nm").Value & ", ")
						'Response.Write(Rs1("ltp_nm").Value & ", ")
						'Response.Write(Rs6("pub_contno").Value & ", ")
						'Response.Write(Rs6("Total_pub_adamt").Value & ", ")
						'Response.Write(Rs6("Total_pub_chgamt").Value & "<br>")
						
						' A �� = A1(i,0)
						A1(i,0) = Rs1("pub_contno").Value 
						A1(i+1,0) = ""
						A1(i,1) = Rs1("clr_nm").Value
						A1(i+1,1) = ""
						A1(i,2) = Rs1("pgs_nm").Value
						A1(i+1,2) = ""
						A1(i,3) = Rs1("ltp_nm").Value
						A1(i+1,3) = ""
						
						' E �� = A1(i,4)
						A1(i,4) = Rs1("cont_mfrno").Value
						A1(i+1,4) = ""
						A1(i,5) = Rs1("mfr_inm").Value
						A1(i+1,5) = ""
						A1(i,6) = Rs1("mfr_izip").Value
						A1(i+1,6) = ""
						A1(i,7) = Rs1("mfr_iaddr").Value
						A1(i+1,7) = "�X���s��: " & Rs6("pub_contno").Value & " ���p�p�G"
						
						' I �� = A1(i,8)
						A1(i,8) = Rs1("Total_pub_adamt").Value
						A1(i+1,8) = Rs6("Total_pub_adamt").Value
						A1(i,9) = Rs1("Total_pub_chgamt").Value
						A1(i+1,9) = Rs6("Total_pub_chgamt").Value
						A1(i,10) = Rs1("TotalAmt").Value
						A1(i+1,10) = Rs6("TotalAmt").Value
						A1(i,11) = Rs1("ContNoCounts").Value
						A1(i+1,11) = Rs6("ContNoCounts").Value
						
						
						' �����S�O���ϥΪ��榡 (=> �`�@�h��) - �H FormatCells �ӭ��s�H��榡���
						' �S�O�榡�g�b sheet 2 �����w����, �p A8/B8, A5/B5
						Dim AdAmthighlight1, ChgAmthighlight1, TotAmthighlight1, AdAmthighlight2, ChgAmthighlight2, TotAmthighlight2, ContNoCountshighlight1, ContNoCountshighlight2
						AdAmthighlight1 = "I" & (7+i) 
						ChgAmthighlight1 = "J" & (7+i) 
						TotAmthighlight1 = "K" & (7+i) 
						ContNoCountshighlight1 = "L" & (7+i) 
						AdAmthighlight2 = "I" & (8+i) 
						ChgAmthighlight2 = "J" & (8+i) 
						TotAmthighlight2 = "K" & (8+i) 
						ContNoCountshighlight2 = "L" & (8+i) 
						Dim TotalText, TotalContNoCounts
						TotalText =  "H" & (8+i) 
						TotalContNoCounts =  "K" & (8+i)
						if (i mod 2) = 0 then
							' �_�Ʀ�, �H sheet2 ���w��쪺 Format ���
							XLS.FormatCells( 1, AdAmthighlight1, 2, "A5", false ) 
							XLS.FormatCells( 1, ChgAmthighlight1, 2, "A5", false ) 
							XLS.FormatCells( 1, TotAmthighlight1, 2, "A5", false ) 
							XLS.FormatCells( 1, ContNoCountshighlight1, 2, "A8", false ) 
							XLS.FormatCells( 1, AdAmthighlight2, 2, "A11", false ) 
							XLS.FormatCells( 1, ChgAmthighlight2, 2, "A11", false ) 
							XLS.FormatCells( 1, TotAmthighlight2, 2, "A11", false ) 
							XLS.FormatCells( 1, ContNoCountshighlight2, 2, "A8", false ) 
							XLS.FormatCells( 1, TotalText, 2, "A10", false ) 
							XLS.FormatCells( 1, TotalContNoCounts, 2, "A12", false ) 
						else
							' ���Ʀ�, �H sheet2 ���w��쪺 Format ���
							XLS.FormatCells( 1, AdAmthighlight1, 2, "B5", false )  
							XLS.FormatCells( 1, ChgAmthighlight1, 2, "B5", false )  
							XLS.FormatCells( 1, TotAmthighlight1, 2, "B5", false )  
							XLS.FormatCells( 1, ContNoCountshighlight1, 2, "B8", false )  
							XLS.FormatCells( 1, AdAmthighlight2, 2, "B11", false )  
							XLS.FormatCells( 1, ChgAmthighlight2, 2, "B11", false )  
							XLS.FormatCells( 1, TotAmthighlight2, 2, "B11", false )  
							XLS.FormatCells( 1, ContNoCountshighlight2, 2, "B8", false )  
							XLS.FormatCells( 1, TotalText, 2, "B10", false ) 
							XLS.FormatCells( 1, TotalContNoCounts, 2, "B12", false )  
						end if
						
						' Highlight Some Rows: �����@�����ϥΪ��榡
						highlight = "A" & (7+i) & ":M" & (8+i)
						if (i mod 4) = 0
							XLS.FormatCells( 1, highlight, 2, "A1", false ) 
						else
							XLS.FormatCells( 1, highlight, 2, "B1", false )  
						end if
						Rs1.MoveNext
						'Rs6.MoveNext
						
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
					EndDate = Mid(EndDate, 1, 4) & "/" & Mid(EndDate, 5, 2)
					XLS.AddVariable("srspn_canme", EmpCName)' >>$srspn_canme
					XLS.AddVariable("edate", EndDate)	' >>$edate
					XLS.AddVariable("book_name", BookName)	' >>$book_name
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("adamt_list2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "adamt_list2a.xls", True)
					
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
