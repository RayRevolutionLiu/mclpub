<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�X���ѲM��</title>
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
				Dim ColorTime, MemoTime, GetColorTime
				Dim FreeTime, TotJTime, MadeJTime, TotalTime, PubTime
				Dim TotalAmt, PaidAmt, ChgAmt
				
				
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
				sqlcmd2 = "SELECT count(*) As CountNo FROM c2_cont"
				sqlcmd2 = sqlcmd2 & " WHERE (c2_cont.cont_fgclosed <> '1') AND (c2_cont.cont_empno='" + EmpNo + "')"
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
				sqlcmd1 = "SELECT * FROM book"
				sqlcmd1 = sqlcmd1 & " INNER JOIN c2_cont"
				sqlcmd1 = sqlcmd1 & " ON book.bk_bkcd = c2_cont.cont_bkcd"
				sqlcmd1 = sqlcmd1 & " INNER JOIN mfr"
				sqlcmd1 = sqlcmd1 & " ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " INNER JOIN  dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno "
				sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_fgclosed <> '1') AND (c2_cont.cont_empno='" + EmpNo + "')"
				
				' Get Rs4: ��X Excel �ɪ��̬Y�Ƕ��p�⪺������ - ���Z�n��� �� ��를�Z�n���
				sqlcmd4 = "SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, "
				sqlcmd4 = sqlcmd4 & " COUNT(c2_or.or_pubcnt) AS TotalPubCount, COUNT(c2_or.or_unpubcnt) AS TotalUnpubCount "
				sqlcmd4 = sqlcmd4 & " FROM c2_cont INNER JOIN c2_or "
				sqlcmd4 = sqlcmd4 & " ON c2_cont.cont_contno = c2_or.or_contno "
				sqlcmd4 = sqlcmd4 & " AND c2_cont.cont_syscd = c2_or.or_syscd "
				sqlcmd4 = sqlcmd4 & " WHERE (c2_cont.cont_fgclosed <> '1') AND (c2_cont.cont_empno='" + EmpNo + "')"
				sqlcmd4 = sqlcmd4 & " GROUP BY c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno "
				Rs4 = oConn.Execute(sqlcmd4)
				
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
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='history.go( -1 );return true;' Value='�^�W�@��'></FORM><BR>")
				
				' �Y�����, �h��X�� ExcelSpeedGen
				else
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					' Array 1
					ReDim A1(rescount*2,14)
	
					' Populate Array 1
					for i = 0 to rescount*2 - 1 step 2
						' ���լO�_�쪺�� result (���n���� XLS.Generate() ���� disable, �~�ݱo�� Response.Write ���G)
						'Response.Write(Rs1("cont_contno").Value & ", ")
						'Response.Write(Rs1("cont_signdate").Value & ", ")
						'Response.Write(Rs1("cont_mfrno").Value & ", ")
						'Response.Write(Rs1("cont_aunm").Value & ", ")
						'Response.Write(Rs1("cont_autel").Value & "<br>")
						
						' A �� = A1(i,0)
						A1(i,0) = Rs1("cont_contno").Value 
						A1(i+1,0) = ""
						A1(i,1) = Mid(Rs1("cont_signdate").Value, 1, 4) & "/" & Mid(Rs1("cont_signdate").Value, 5, 2) & "/" & Mid(Rs1("cont_signdate").Value, 7, 2)
						A1(i+1,1) = Rs1("cont_disc").Value
						A1(i,2) = Rs1("cont_mfrno").Value
						A1(i+1,2) = Rs1("cont_freetm").Value
						A1(i,3) = Rs1("cont_aunm").Value
						A1(i+1,3) = Rs1("mfr_inm").Value
						
						' E �� = A1(i,4)
						A1(i,4) = Rs1("cont_autel").Value
						A1(i+1,4) = Rs1("cont_totjtm").Value
						A1(i,5) = Rs1("cont_aufax").Value
						A1(i+1,5) = Rs1("cont_madejtm").Value
						A1(i,6) = Rs1("cont_aucell").Value
						A1(i+1,6) = Rs1("cont_tottm").Value
						A1(i,7) = Rs1("bk_nm").Value
						A1(i+1,7) = Rs1("cont_pubtm").Value
						
						' I �� = A1(i,8)
						A1(i,8) = Rs1("cont_sdate").Value
						A1(i+1,8) = Rs1("cont_totamt").Value
						A1(i,9) = Rs1("cont_edate").Value
						A1(i+1,9) = Rs1("cont_paidamt").Value
						A1(i,10) = Rs1("cont_clrtm").Value
						A1(i+1,10) = Rs1("cont_chgamt").Value
						A1(i,11) = Rs1("cont_menotm").Value
						A1(i+1,11) = Rs4("TotalPubCount").Value
						A1(i,12) = Rs1("cont_getclrtm").Value
						A1(i+1,12) = Rs4("TotalUnpubCount").Value
						
						' ��X�X�p����, ���ର�ܼƫ��A
						ColorTime = ColorTime + A1(i,10)
						MemoTime = MemoTime + A1(i,11)
						GetColorTime = GetColorTime + A1(i,12)
						FreeTime = FreeTime + A1(i+1,2)
						TotJTime = TotJTime + A1(i+1,4)
						MadeJTime = MadeJTime + A1(i+1,5)
						TotalTime = TotalTime + A1(i+1,6)
						PubTime = PubTime + A1(i+1,7)
						TotalAmt = TotalAmt + A1(i+1,8)
						PaidAmt = PaidAmt + A1(i+1,9)
						ChgAmt = ChgAmt + A1(i+1,10)
						'Response.Write("PubTime(" & i & ")= " & A1(i+1,7) & "<br>")
						
						' N �� = A1(i,13)
						'A1(i,13) = Rs1("cont_fgclosed").Value
						if(Rs1("cont_fgclosed").Value=0)
							A1(i,13) = "�_"
						else
							A1(i,13) = "�O"
						end if
						
						'A1(i+1,13) = Rs1("cont_fgpayonce").Value
						if(Rs1("cont_fgpayonce").Value=0)
							A1(i+1,13) = "�_"
						else
							A1(i+1,13) = "�O"
						end if
						
						
						' �����S�O���ϥΪ��榡 (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �S�O�榡�g�b sheet 2 �����w����, �p A5, A6; B5, B6
						Dim Discounthighlight, Amounthighlight1, Amounthighlight2, Amounthighlight3
						Discounthighlight =  "B" & (8+i) 
						Amounthighlight1 = "I" & (8+i) 
						Amounthighlight2 = "J" & (8+i) 
						Amounthighlight3 = "K" & (8+i) 
						if (i mod 4) = 0 then
							' �_�Ʀ�, �H A5 �� �f�� Format ���
							XLS.FormatCells( 1, Discounthighlight, 2, "A6", false ) 
							XLS.FormatCells( 1, Amounthighlight1, 2, "A5", false ) 
							XLS.FormatCells( 1, Amounthighlight2, 2, "A5", false ) 
							XLS.FormatCells( 1, Amounthighlight3, 2, "A5", false ) 
						else
							' ���Ʀ�, �H B5 �� �f�� Format ���
							XLS.FormatCells( 1, Discounthighlight, 2, "B6", false )  
							XLS.FormatCells( 1, Amounthighlight1, 2, "B5", false )  
							XLS.FormatCells( 1, Amounthighlight2, 2, "B5", false )  
							XLS.FormatCells( 1, Amounthighlight3, 2, "B5", false )  
						end if
						
						' Highlight Some Rows: �����@�����ϥΪ��榡
						Dim highlight
						highlight = "A" & (7+i) & ":N" & (8+i)
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
					XLS.HideSheet( 3, true )  ' Hide it so user cannot unhide it
					XLS.HideSheet( 4, true )  ' Hide it so user cannot unhide it
					
					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					
					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("clrtm", ColorTime)		' >>$clrtm
					XLS.AddVariable("memotm", MemoTime)		' >>$memotm
					XLS.AddVariable("getclrtm", GetColorTime)	' >>$getclrtm
					XLS.AddVariable("freetm", FreeTime)		' >>$freetm
					XLS.AddVariable("totjtm", TotJTime)		' >>$totjtm
					XLS.AddVariable("madejtm", MadeJTime)		' >>$madejtm
					XLS.AddVariable("tottm", TotalTime)		' >>$tottm
					XLS.AddVariable("pubtm", PubTime)		' >>$pubtm
					XLS.AddVariable("totamt", TotalAmt)		' >>$totamt
					XLS.AddVariable("paidamt", PaidAmt)		' >>$paidamt
					XLS.AddVariable("chgamt", ChgAmt)		' >>$chgamt
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("cont_list2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "cont_list2a.xls", True)
					
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
