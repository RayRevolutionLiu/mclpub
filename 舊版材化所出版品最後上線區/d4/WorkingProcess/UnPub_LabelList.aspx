<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i���t�� �خѼ��ҲM�� ���Z�n</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
	</HEAD>
	<body>
		<form id="UnPub_LabelList" method="post" runat="server">
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

				Dim Rs1, Rs2, Rs4, Rs5, Rs6, RS7		' Record Source 1 ~ 7
				Dim Rs9						' Record Source 9
				Dim sqlcmd1, sqlcmd2 				' SQL Command 1 ~ 2
				Dim sqlcmd4, sqlcmd5, sqlcmd6, sqlcmd7		' SQL Command 4 ~ 7
				Dim sqlcmd9					' SQL Command 9
				Dim rescount, i		' rescount= count of Rs2
				Dim rescount2, j	' rescount2= count of Rs10
				Dim A1			' Array A1

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook

				' �ۭq sql �ܼ�
				Dim strYYYYMM, strBkcd, strEmpNo, strpubcnttp, strConttp, strfgmosea, strmtpcd, strFilter

				' �ۭq�ܼ� (�[�`���γ~, ���b�зǨArray�̪���L�ܼ�)
				Dim BkPNo, EmpCName, BkName, strLoginEmpNo, WhoAmI, FreeBook
				Dim strConttpText, strfgmoseaText, strmtpcdText, strmtpText


				' -- �]�w��ƨӷ��P��Ʈw --
				DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
				oConn = Server.CreateObject("ADODB.Connection")
				oConn.Open(DSN)

				' �۫e�@����ǻ� form �����ܼ� empno, �H��X EmpNo, EmpCName
				strYYYYMM = Request("yyyymm")
				BkName = Request("bk")
				BkPNo = Request("bkpno")
				FreeBook = BkName & " (�� " & BkPNo & " ��)"
				WhoAmI = Request("whoami")

				if(Request("srspn") <> "") then
					EmpCName = Request("srspn")
				else
					EmpCName = "(�Ҧ�)"
				end if

				strConttpText = ""
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")

					if(strConttp = "01")
						strConttpText = "�@��X��"
					end if
					if(strConttp = "09")
						strConttpText = "���s�X��"
					end if
				else
					strConttp = ""
					strConttpText = "(���M��)"
				end if

				strfgmoseaText = ""
				if(Request("fgmosea") <> "") then
					strfgmosea = Request("fgmosea")

					if(strfgmosea = "0")
						strfgmoseaText = "�ꤺ"
					end if
					if(strfgmosea = "1")
						strfgmoseaText = "��~"
					end if
				else
					strfgmosea = ""
					strfgmoseaText = "(�Ҧ�)"
				end if

				strmtpcdText = ""
				if(Request("mtpcd") <> "") then
					strmtpcd = Request("mtpcd")

					' Get Rs7: �Ƕl�H���O�N�X��X��W��
					' Open the RecordSets
					sqlcmd7 = "SELECT * FROM mtp"
					sqlcmd7 = sqlcmd7 & " WHERE (mtp_mtpcd='" + strmtpcd + "')"
					Rs7 = oConn.Execute(sqlcmd7)
					strmtpcdText = Trim(Rs7("mtp_nm").Value)
					'Response.Write("strmtpcdText= " & strmtpcdText & "<br>")
				else
					strmtpcd = ""
					strmtpcdText = "(�Ҧ�)"
				end if
				
				strmtpText = strfgmoseaText & "/" & strmtpcdText
				
				' �զX���j�M����
				IF (Session("MAILLABEL") <> "") THEN
					strFilter = Session("MAILLABEL")
				ELSE
					strFilter = ""
				END IF		

				' Get Rs2: ��X�ثe��Ʈw���`����
				' Open the RecordSets
				sqlcmd2 = "SELECT COUNT(*) AS CountNo "
				sqlcmd2 = sqlcmd2 & " FROM wk_c4_label_list "
				sqlcmd2 = sqlcmd2 & " WHERE ma_mnt > 0  AND fgpub='0' "
				IF strFilter <>""
					sqlcmd2 = sqlcmd2 & " AND " & strFilter
				END IF
				
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
				sqlcmd1 = "SELECT wk_c4_label_list.*, srspn.srspn_cname, mtp.mtp_nm "
				sqlcmd1 = sqlcmd1 & "FROM wk_c4_label_list INNER JOIN "
				sqlcmd1 = sqlcmd1 & "srspn ON wk_c4_label_list.cont_empno = srspn.srspn_empno INNER JOIN "
				sqlcmd1 = sqlcmd1 & "mtp ON wk_c4_label_list.ma_mtpcd = mtp.mtp_mtpcd "
				sqlcmd1 = sqlcmd1 & " WHERE ma_mnt > 0  AND fgpub='0' "
				IF strFilter <>""
					sqlcmd1 = sqlcmd1 & " AND " & strFilter
				END IF
				sqlcmd1 = sqlcmd1 & " ORDER BY ma_mnt, cont_contno "


				' Open the RecordSets
				Rs1 = oConn.Execute(sqlcmd1)


				'------- �}�l��X���G ---
				' �Y�L��Ʈ�, �h����ĵ�i�T��
				if Rs1.EOF then
					Response.Write ("<FONT Color=Red><B>�ܩ�p, �ثe�䤣��z�n�����!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='��������'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='�^�W�@��'--></FORM><BR>")

				' �Y�����, �h��X�� ExcelSpeedGen
				else

					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")


					' ��X �D��� Rs1
					Rs1.MoveFirst

					' Array 1
					ReDim A1(rescount,10)

					' Populate Array 1
					Dim strdate1, strdate2, count
					count = 0
					for i = 0 to rescount - 1 step 1
						' �۰ʭp�� A ��: ���� - ��ܤ�k�@�G�񦹳B�h�O�Ȥ�n�D: �X�����Ъ�, �h����ܨ�ۦP������ (if�� A1(i,0) = "" �n enable)
						A1(i,0) = i + 1
						A1(i,1) = Rs1("cont_contno").Value
						strdate1 = Mid(Rs1("cont_sdate").Value, 1, 4) & "/" & Mid(Rs1("cont_sdate").Value, 5, 2) & "/" & Mid(Rs1("cont_sdate").Value, 7, 2)
						strdate2 = Mid(Rs1("cont_edate").Value, 1, 4) & "/" & Mid(Rs1("cont_edate").Value, 5, 2) & "/" & Mid(Rs1("cont_edate").Value, 7, 2)
						A1(i,2) =  strdate1 & "~" & strdate2
						strdate1 = Mid(Rs1("ma_sdate").Value, 1, 4) & "/" & Mid(Rs1("ma_sdate").Value, 5, 2)
						strdate2 = Mid(Rs1("ma_edate").Value, 1, 4) & "/" & Mid(Rs1("ma_edate").Value, 5, 2)
						A1(i,3) =  strdate1 & "~" & strdate2
						A1(i,4) = Rs1("or_inm").Value
						A1(i,5) = Rs1("or_nm").Value & " " & Rs1("or_jbti").Value
						A1(i,6) = Rs1("or_zip").Value & " " & Rs1("or_addr").Value
						A1(i,7) = Rs1("srspn_cname").Value
						A1(i,8) = Rs1("mtp_nm").Value
						A1(i,9) = Rs1("ma_mnt").Value
						count = count + Rs1("ma_mnt").Value

						Dim highlight1, highlight2, highlight3
						highlight1 = "A" & (8+i) & ":D" & (8+i)
						highlight2 = "E" & (8+i) & ":I" & (8+i)
						highlight3 = "J" & (8+i) & ":J" & (8+i)
						if (i mod 2) = 0
							XLS.FormatCells( 1, highlight1, 2, "A2", false )
							XLS.FormatCells( 1, highlight2, 2, "A1", false )
							XLS.FormatCells( 1, highlight3, 2, "A8", false )
						else
							XLS.FormatCells( 1, highlight1, 2, "B2", false )
							XLS.FormatCells( 1, highlight2, 2, "B1", false )
							XLS.FormatCells( 1, highlight3, 2, "B8", false )
						end if


						Rs1.MoveNext

						if Rs1.EOF
	    						exit for
						end if
					next



					' Hide Sheet 2
					XLS.HideSheet( 2, true )  ' Hide it so user cannot unhide it

					' Rows are in 1st Dimension of Array
					XLS.AddRS_Array_2D( A1, true )


					' XLS.AddVariable("��X��.xls�̪�����ܼƦW��", �������̨ϥΪ��ܼƦW��)
					XLS.AddVariable("yyyymm", strYYYYMM)		' >>$yyyymm
					XLS.AddVariable("freebook", FreeBook)		' >>$freebook
					XLS.AddVariable("srspn_cname", EmpCName)	' >>$srspn_cname
					XLS.AddVariable("whoami", WhoAmI)			'>>$whoami
					XLS.AddVariable("conttpText", strConttpText)	' >>$conttpText
'					XLS.AddVariable("fgmoseaText", strfgmoseaText)	' >>$fgmoseaText
					XLS.AddVariable("mtpText", strmtpText)	' >>$mtpcdText

					' Location of Source Workbook
					SrcBook = Server.MapPath("Pub_LabelList.xls")

					' Generate SpreadSheet and Stream to Client, Open in Place
					XLS.Generate(SrcBook, "Pub_LabelList.xls", True)

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
