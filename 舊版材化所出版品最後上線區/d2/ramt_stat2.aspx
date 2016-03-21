<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�l�H���Ʋέp��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="ramt_stat2" method="post" runat="server">
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
				Dim sqlcmd1, sqlcmd2		' SQL Command 1 ~ 2
				Dim rescount, i		' rescount= count of Rs2
				Dim A1			' Array A1
				
				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				' �ۭq sql �ܼ�
				Dim EndDate
				
				
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
				EndDate = Request("enddate")
				
				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT DISTINCT count(*) As CountNo "
				sqlcmd2 = sqlcmd2 & " FROM  c2_or "
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
				sqlcmd1 = "SELECT DISTINCT c2_or.or_contno, c2_pub.pub_yyyymm, "
				sqlcmd1 = sqlcmd1 & " mfr.mfr_inm, mtp.mtp_nm, c2_or.or_zip, "
				sqlcmd1 = sqlcmd1 & " c2_or.or_addr, c2_or.or_pubcnt, c2_cont.cont_freetm, c2_or.or_mtpcd "
				sqlcmd1 = sqlcmd1 & " FROM dbo.c2_pub "
				sqlcmd1 = sqlcmd1 & " INNER JOIN c2_or ON dbo.c2_pub.pub_syscd = c2_or.or_syscd AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_contno = c2_or.or_contno  "
				sqlcmd1 = sqlcmd1 & " INNER JOIN c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND "
				sqlcmd1 = sqlcmd1 & " c2_pub.pub_syscd = c2_cont.cont_syscd "
				sqlcmd1 = sqlcmd1 & " INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno "
				sqlcmd1 = sqlcmd1 & " INNER JOIN mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd "
				sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_fgclosed <> '1') AND (c2_pub.pub_yyyymm<='" + EndDate + "')"
				sqlcmd1 = sqlcmd1 & " ORDER BY c2_or.or_contno, c2_pub.pub_yyyymm, c2_or.or_mtpcd "
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				
				
				'------- �}�l��X���G ---
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					'Response.Write("sqlcmd1= " & sqlcmd1 & "<br><br>")
					'Response.Write("Rs1= " & Rs1(0).value & "<br>")
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='��������'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='�^�W�@��'--></FORM><BR>")
				
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
					
					
					Dim highlight
					Dim YYYYMMhighlight
					for i = 0 to rescount
						' �����S�O���ϥΪ��榡 (�p�f��, real��) - �H FormatCells �ӭ��s�H��榡���
						' �S�O�榡�g�b sheet 2 �����w����, �p A7/B7
						' �ثe bug: ���M B6~Bi ���榡�H FormatCells �������\, ���o�n�b B6~Bi ���ȳB, ���U Enter ��ӷ|��ܥ��T�� FormatCells �榡��!?!  ���b cont_list2.aspx �o���|��������
						YYYYMMhighlight = "B" & (6+i)
						if (i mod 2) = 0
							' �_�Ʀ�, �H sheet2 ���w��쪺 Format ���
							XLS.FormatCells( 1, YYYYMMhighlight, 2, "A7", false ) 
						else
							' ���Ʀ�, �H sheet2 ���w��쪺 Format ���
							XLS.FormatCells( 1, YYYYMMhighlight, 2, "B7", false )  
						end if
						'Response.Write("YYYYMMhighlight= " & YYYYMMhighlight & "<br>")
						
						' Highlight Some Rows: �����@�����ϥΪ��榡 A1/B1
						highlight = "A" & (6+i) & ":H" & (6+i)
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
					
					
					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					EndDate = Mid(EndDate, 1, 4) & "/" & Mid(EndDate, 5, 2)
					XLS.AddVariable("edate", EndDate)	' >>$edate
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("ramt_stat2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "ramt_stat2a.xls", True)
					
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
