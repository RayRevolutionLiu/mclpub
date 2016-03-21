<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RptFileUpQuery.aspx.cs" src="RptFileUpQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptFileUpQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptFileUpQuery</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptFileUpQuery" method="post" runat="server">
			<kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="90%">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										合約處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">&nbsp;美編上稿清單</FONT>
								</TD>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">查詢條件</TD>
							</TR>
							<TR>
								<TD>廣告日區間：<asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">～
									<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
									<asp:label id="lblyyyymmdd" runat="server" CssClass="ImportantLabel" ForeColor="#C00000">(yyyy/mm/dd)</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxSrspn" runat="server" Text="承辦業務員："></asp:checkbox><asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxKeyword" runat="server" Text="廣告位置："></asp:checkbox><asp:dropdownlist id="ddlKeyword" runat="server">
										<asp:ListItem Value="h0" Selected="True">正中</asp:ListItem>
										<asp:ListItem Value="h1">右一</asp:ListItem>
										<asp:ListItem Value="h2">右二</asp:ListItem>
										<asp:ListItem Value="h3">右三</asp:ListItem>
										<asp:ListItem Value="h4">右四</asp:ListItem>
										<asp:ListItem Value="w1">右文一</asp:ListItem>
										<asp:ListItem Value="w2">右文二</asp:ListItem>
										<asp:ListItem Value="w3">右文三</asp:ListItem>
										<asp:ListItem Value="w4">右文四</asp:ListItem>
										<asp:ListItem Value="w5">右文五</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:button id="btnPrint" runat="server" Text="產生美編上稿清單"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:literal id="Literal1" runat="server"></asp:literal></td>
				</tr>
			</table>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
