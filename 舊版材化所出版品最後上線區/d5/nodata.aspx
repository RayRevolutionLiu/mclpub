<%@ Page language="c#" Src="nodata.aspx.cs" Codebehind="nodata.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.nodata" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<title>查無此筆資料</title>
	</HEAD>
	
	<body>
		<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
		
	<P align="center">
		<FONT face="新細明體"></FONT>
	</P>
	<br>
	<p align="center"><font size=2 color=red>查無此筆資料!</font></p>
	<P align="center">
		<input onclick="javascript:window.history.back();" type="button" value="回上一頁">
	</P>
		
		<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
	</body>
</HTML>
