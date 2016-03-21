<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告次系統 贈書標籤清單 當月刊登</title>
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

				' 自訂 sql 變數
				Dim strYYYYMM, strBkcd, strEmpNo, strpubcnttp, strConttp, strfgmosea, strmtpcd, strFilter

				' 自訂變數 (加總等用途, 不在標準制式Array裡的其他變數)
				Dim BkPNo, EmpCName, BkName, strLoginEmpNo, WhoAmI, FreeBook
				Dim strConttpText, strfgmoseaText, strmtpcdText, strmtpText


				' -- 設定資料來源與資料庫 --
				DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
				oConn = Server.CreateObject("ADODB.Connection")
				oConn.Open(DSN)

				' 自前一頁抓傳遞 form 網頁變數 empno, 以抓出 EmpNo, EmpCName
				strYYYYMM = Request("yyyymm")
				BkName = Request("bk")
				BkPNo = Request("bkpno")
				FreeBook = BkName & " (第 " & BkPNo & " 期)"
				WhoAmI = Request("whoami")

				if(Request("srspn") <> "") then
					EmpCName = Request("srspn")
				else
					EmpCName = "(所有)"
				end if

				strConttpText = ""
				if(Request("conttp") <> "") then
					strConttp = Request("conttp")

					if(strConttp = "01")
						strConttpText = "一般合約"
					end if
					if(strConttp = "09")
						strConttpText = "推廣合約"
					end if
				else
					strConttp = ""
					strConttpText = "(不清楚)"
				end if

				strfgmoseaText = ""
				if(Request("fgmosea") <> "") then
					strfgmosea = Request("fgmosea")

					if(strfgmosea = "0")
						strfgmoseaText = "國內"
					end if
					if(strfgmosea = "1")
						strfgmoseaText = "國外"
					end if
				else
					strfgmosea = ""
					strfgmoseaText = "(所有)"
				end if

				strmtpcdText = ""
				if(Request("mtpcd") <> "") then
					strmtpcd = Request("mtpcd")

					' Get Rs7: 藉郵寄類別代碼抓出其名稱
					' Open the RecordSets
					sqlcmd7 = "SELECT * FROM mtp"
					sqlcmd7 = sqlcmd7 & " WHERE (mtp_mtpcd='" + strmtpcd + "')"
					Rs7 = oConn.Execute(sqlcmd7)
					strmtpcdText = Trim(Rs7("mtp_nm").Value)
					'Response.Write("strmtpcdText= " & strmtpcdText & "<br>")
				else
					strmtpcd = ""
					strmtpcdText = "(所有)"
				end if
				
				strmtpText = strfgmoseaText & "/" & strmtpcdText
				
				' 組合的搜尋條件
				IF (Session("MAILLABEL") <> "") THEN
					strFilter = Session("MAILLABEL")
				ELSE
					strFilter = ""
				END IF		

				' Get Rs2: 抓出目前資料庫的總筆數
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
					Response.Write ("<FONT Color=Red><B>查詢結果 - 筆數為 0</B></FONT><BR>")
				else
					rescount = Rs2(0).Value
				end if
				'Response.Write("rescount= " & rescount & "<br>")


				' Get Rs1: 抓出主檔(要輸出至 Excel 檔的主資料集)
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
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


				'------- 開始輸出結果 ---
				' 若無資料時, 則給予警告訊息
				if Rs1.EOF then
					Response.Write ("<FONT Color=Red><B>很抱歉, 目前找不到您要的資料!</B></FONT>&nbsp;&nbsp;<br><FORM><Input Type=Button OnClick='window.close();' Value='關閉視窗'><!--Input Type=Button OnClick='history.go( -1 );return true;' Value='回上一頁'--></FORM><BR>")

				' 若有資料, 則輸出至 ExcelSpeedGen
				else

					' Create Excel File
					XLS = Server.CreateObject("XLSpeedGen.ASP")


					' 輸出 主資料 Rs1
					Rs1.MoveFirst

					' Array 1
					ReDim A1(rescount,10)

					' Populate Array 1
					Dim strdate1, strdate2, count
					count = 0
					for i = 0 to rescount - 1 step 1
						' 自動計算 A 欄: 項次 - 顯示方法一：放此處則是客戶要求: 合約重覆者, 則不顯示其相同的項次 (if裡 A1(i,0) = "" 要 enable)
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


					' XLS.AddVariable("輸出至.xls裡的欄位變數名稱", 此網頁裡使用的變數名稱)
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
