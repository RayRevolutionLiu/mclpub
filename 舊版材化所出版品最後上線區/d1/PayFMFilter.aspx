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
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="PayFMFilter" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							繳款處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">修改繳款資料
							<IMG height="10" src="images/header/right02.gif" width="10" border="0">查詢</font>
					</td>
				</tr>
			</table>
			<br>
			<asp:Label id="Label1" runat="server">請輸入繳款編號：</asp:Label>
			<asp:TextBox id="tbxPyno" runat="server" Width="83px" Height="24px" MaxLength="8"></asp:TextBox>
			<asp:Button id="btnSearch" runat="server" Text="查詢"></asp:Button>
			<br>
			<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
