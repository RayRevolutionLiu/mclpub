<%@ Page language="c#" Codebehind="SaveMessage.aspx.cs" Src="SaveMessage.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.SaveMessage" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�x�s�T���T�{</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<!-- �ثe�Ҧb��m -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�x�s�T���T�{</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form-->
			<form id="SaveMessage" method="post" runat="server">
				<asp:label id="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:label>
				<br>
			</form>
			<asp:HyperLink id="hpl1" runat="server"></asp:HyperLink>
			&nbsp;&nbsp;
			<asp:HyperLink id="hpl2" runat="server"></asp:HyperLink>
			<br>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
