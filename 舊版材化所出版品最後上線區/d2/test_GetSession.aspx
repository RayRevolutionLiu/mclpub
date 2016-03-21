<%@ Page language="c#" Codebehind="test_GetSession.aspx.cs" Src="test_GetSession.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.test_GetSession" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Get Session</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="test_GetSession" method="post" runat="server">
			LogonUser(EmpNo): &nbsp;
			<asp:TextBox id="tbxEmpNo" runat="server" BorderStyle="Outset" BorderWidth="1px"></asp:TextBox>
		</form>
	</body>
</HTML>
