<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="GetInvno.aspx.cs" src="GetInvno.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.GetInvno" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�o�����X���^</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="GetInvno" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				SAP���� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				�o�����X���^</FONT>
			<br>
			<asp:button id="btnGetInvno" runat="server" Text="���^�o�����X"></asp:button>
			<br>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
