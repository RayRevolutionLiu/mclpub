<%@ Register TagPrefix="kw" TagName="header" Src="UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="UserControl/footer.ascx" %>
<html>

<head>
<meta http-equiv="Content-Language" content="zh-tw">
<meta name="GENERATOR" content="Microsoft FrontPage 5.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<meta http-equiv="Content-Type" content="text/html; charset=big5">
<LINK href="UserControl/mrlpub.css" type="text/css" rel="stylesheet">
<title>很抱歉,您沒有權限使用</title>
</head>

<body>
<!-- 頁首 Header -->
	<kw:header id="Header" runat="server"></kw:header>

	<P align="center">
		<FONT face="新細明體"></FONT>
	</P>
	<br>
	<p align="center"><font size=2 color=red>很抱歉,您沒有權限使用!</font></p>
	<P align="center">
		<input onclick="javascript:window.history.back();" type="button" value="回上一頁">
	</P>
	
<!-- 頁尾 Footer -->
	<kw:footer id="Footer" runat="server"></kw:footer>

</body>

</html>
