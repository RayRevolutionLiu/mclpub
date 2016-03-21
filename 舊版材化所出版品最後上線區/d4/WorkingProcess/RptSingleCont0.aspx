<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RptSingleCont0.aspx.cs" Src="RptSingleCont0.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptSingleCont0" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptSingleCont0" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle">
						<br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										合約處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;單一合約書清單</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="lblContNo" runat="server" CssClass="NormalLabel">合約書編號：</asp:Label>
						<asp:TextBox id="tbxContNo" runat="server" Width="100px"></asp:TextBox>
						<asp:Button id="btnGo" runat="server" Text="產生合約書清單"></asp:Button>
					</td>
				</tr>
			</table>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
	</body>
</HTML>
