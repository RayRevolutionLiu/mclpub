<%@ Page language="c#" Codebehind="PayFMFilter.aspx.cs" src="PayFMFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayFMFilter" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="PayFMFilter" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							ú�ڳB�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">�ק�ú�ڸ��
							<IMG height="10" src="images/header/right02.gif" width="10" border="0">�d��</font>
					</td>
				</tr>
			</table>
			<br>
			<asp:Label id="Label1" runat="server">�п�Jú�ڽs���G</asp:Label>
			<asp:TextBox id="tbxPyno" runat="server" Width="83px" Height="24px" MaxLength="8"></asp:TextBox>
			<asp:Button id="btnSearch" runat="server" Text="�d��"></asp:Button>
			<br>
			<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
