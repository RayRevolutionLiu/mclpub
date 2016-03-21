<%@ Page language="vbscript" aspcompat="true" Debug="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>催稿單</title>
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
				
				Dim Rs8, Rs11			' Record Source 8 ~ 11
				Dim sqlcmd8, sqlcmd11	' SQL Command 8 ~ 11

				Dim XLS			' Excel SpeedGen Object
				Dim SrcBook		' Source Workbook
				
				
				DSN = ConfigurationSettings.AppSettings("itridpa_mrlpub_esg")
				oConn = Server.CreateObject("ADODB.Connection")
				oConn.Open(DSN)
				
				' Get Rs8: 執行 sp 以產生 Rs1 裡的 c2_getad.pubmmstr 欄位值
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd8 = " EXEC sp_c2_getad_1 '0', '01' "
				Rs8 = oConn.Execute(sqlcmd8)
				
				
				' Get Rs11: 執行 sp 以產生 Rs1 裡的 c2_getad.pubmmstr 欄位值
				' Set SQL Statement (or Table name) & Open the RecordSets
				' 請注意: oConn.Execute 裡的 SQL 關鍵字, 如 SELECT, FROM, INNER JOIN, ON (即 WHERE) 都要大寫, 不然可能有 error
				sqlcmd11 = " EXEC sp_c2_rp1 '200209', '01' "
				Rs11 = oConn.Execute(sqlcmd11)
				
				
					' Location of Source Workbook
					SrcBook = Server.MapPath("getad2.xls")
					
					' Generate SpreadSheet and Stream to Client, Open in Place
					'XLS.Generate(SrcBook, "getad2.xls", True)
					
					' Destroy object when done
					XLS = Nothing
					
					' Cleanup Code - Close Connection and all Recordsets
					oConn.close
					oConn = Nothing
			%>
		</form>
	</body>
</HTML>
