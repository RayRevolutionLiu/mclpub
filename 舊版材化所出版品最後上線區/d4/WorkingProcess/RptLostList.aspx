<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ʮѲM��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="RptLostList" method="post" runat="server">
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
				Dim WhoAmI, Date1, o_Date
				Dim Book01_New, Book01_Old, Book02_New, Book02_Old
				Dim	Book_Other, Book01_Amt, Book02_Amt, Book_Other_Amt
				Dim	preNo, preBook, count
				' -- �]�w��ƨӷ��P��Ʈw --
				DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
				oConn = Server.CreateObject("ADODB.Connection")
				oConn.Open(DSN)
				
				WhoAmI = Request("whoami") 'Session("cname")
				Date1 = Request("date")
				o_Date = Request("o_date")
				
				' Get Rs1: ��X�D��(�n��X�� Excel �ɪ��D��ƶ�)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' �Ъ`�N: oConn.Execute �̪� SQL ����r, �p SELECT, FROM, INNER JOIN, ON (�Y WHERE) ���n�j�g, ���M�i�঳ error
				sqlcmd1 = "SELECT c4_lost.*, c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, c4_or.* "
				sqlcmd1 = sqlcmd1 & " FROM c4_lost INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c4_cont ON c4_lost.lst_syscd = c4_cont.cont_syscd AND "
				sqlcmd1 = sqlcmd1 & " c4_lost.lst_contno = c4_cont.cont_contno INNER JOIN "
				sqlcmd1 = sqlcmd1 & " c4_or ON c4_lost.lst_syscd = c4_or.or_syscd AND "
				sqlcmd1 = sqlcmd1 & " c4_lost.lst_contno = c4_or.or_contno AND "
				sqlcmd1 = sqlcmd1 & " c4_lost.lst_oritem = c4_or.or_oritem "
                sqlcmd1 = sqlcmd1 & "where 1=1 "
                if Request("status")="C" then	'�w�H�X
					if Date1<>"" then
						sqlcmd1 = sqlcmd1 & " AND (c4_lost.lst_date >= '" &Mid(Date1, 1,4)&Mid(Date1, 6,2)&Mid(Date1, 9,2)& "')"
						sqlcmd1 = sqlcmd1 & " AND (c4_lost.lst_date <= '" &Mid(Date1, 12,4)&Mid(Date1, 17,2)&Mid(Date1, 20,2)& "')"
					end if
					sqlcmd1 = sqlcmd1 & " AND c4_lost.lst_fgsent='C'"
				else if Request("status")="N" then	'���H�X
					sqlcmd1 = sqlcmd1 & " AND c4_lost.lst_fgsent<>'C'"
				end if
				if o_Date<>"" then
					sqlcmd1 = sqlcmd1 & " AND (c4_cont.cont_signdate >= '" &Mid(o_Date, 1,4)&Mid(o_Date, 6,2)&Mid(o_Date, 9,2)& "')"
					sqlcmd1 = sqlcmd1 & " AND (c4_cont.cont_signdate <= '" &Mid(o_Date, 12,4)&Mid(o_Date, 17,2)&Mid(o_Date, 20,2)& "')"
				end if
				
				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();return true;' Value='�^�W�@��'></FORM><BR>")
				else
				' �Y�����, �h��X�� ExcelSpeedGen
					Rs1.MoveFirst
					rescount = 0
					Do while not Rs1.EOF
						rescount = rescount + 1
						Rs1.MoveNext
					Loop
					Rs1.MoveFirst
				
				'------- �}�l��X���G ---				
					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")
					
					' Array 1
					ReDim A1(rescount,9)
	
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
					for i = 0 to rescount-1
						' A �� = A1(i,0)

						A1(i,0) = i + 1
						A1(i,1) = Rs1("lst_contno").Value
						A1(i,2) = Rs1("cont_sdate").Value & "~" & Rs1("cont_sdate").Value
						A1(i,3) = Rs1("or_nm").Value
						A1(i,4) = Rs1("or_addr").Value
						
						IF TRIM(Rs1("lst_date").Value) = "" THEN
							A1(i, 5) = ""
						ELSE
							A1(i,5) = Mid(Rs1("lst_date").Value, 1, 4) & "/" & Mid(Rs1("lst_date").Value, 5, 2) & "/" & Mid(Rs1("lst_date").Value, 7, 2)
						END IF
						A1(i,6) = Rs1("lst_cont").Value
						A1(i,7) = Rs1("lst_rea").Value
						if Rs1("lst_fgsent").Value="Y" then
							A1(i,8) = "�i�H�X"
						else if Rs1("lst_fgsent").Value="N" then
							A1(i,8) = "�ثe�ȮɵL�k�H�X"
						else if Rs1("lst_fgsent").Value="C" then
							A1(i,8) = "�w�H�X"
						else if Rs1("lst_fgsent").Value="D" then
							A1(i,8) = "���B�z"
						end if
						A1(i,9) = Mid(Rs1("cont_signdate").Value, 1, 4) & "/" & Mid(Rs1("cont_signdate").Value, 5, 2) & "/" & Mid(Rs1("cont_signdate").Value, 7, 2)
						
						Dim highlight1, highlight2
						highlight1 = "A" & (5+i) & ":C" & (5+i)
						highlight2 = "D" & (5+i) & ":J" & (5+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight1, 2, "A2", false )
							XLS.FormatCells( 1, highlight2, 2, "A1", false )
						else
							XLS.FormatCells( 1, highlight1, 2, "B2", false )
							XLS.FormatCells( 1, highlight2, 2, "B1", false )
						end if
						Rs1.MoveNext
						
						if Rs1.EOF
	    					Exit For
						end if
					next
'					Loop
					
					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Set Estimated Output File Size (Critical for speed)  
					XLS.EstimatedSize = 50000
					
					' RecordSource 1 (read 20 rows at a time)
					'XLS.AddRS_ADO(Rs1, 20)
					
					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )
					
					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("whoami", WhoAmI)		' >>$srspn_cname
					XLS.AddVariable("date1", Date1)					' >>$date1
					XLS.AddVariable("o_date", o_Date)				' >>$o_date
					'Response.Write("PubTime= " & PubTime & "<br>")
					
					' Location of Source Workbook
					SrcBook = Server.MapPath("RptLostList.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "RptLostList.xls", True)
					
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
