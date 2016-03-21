<%@ Page language="c#" Codebehind="RptContList0.aspx.cs" Src="RptContList0.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptContList0" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptContList0" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="90%">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										合約處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;&nbsp;大批合約書清單</FONT>
								</TD>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="2">查詢條件</TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxContNo" runat="server" Text="合約書編號："></asp:checkbox><asp:textbox id="tbxContNo" runat="server" Width="100px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxDate" runat="server" Text="簽約日期區間："></asp:checkbox><asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">～
									<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
									<asp:label id="lblyyyymmdd" runat="server" CssClass="ImportantLabel">(yyyy/mm/dd)</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxEmpData" runat="server" Text="承辦業務員："></asp:checkbox><asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxMfrIName" runat="server" Text="廠商名稱："></asp:checkbox><asp:textbox id="tbxMfrIName" runat="server" Font-Size="X-Small"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									<asp:CheckBox id="cbxClosed" runat="server" Text="已結案："></asp:CheckBox><asp:dropdownlist id="ddlClosed" runat="server">
										<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
										<asp:ListItem Value="1">是</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>
									<asp:CheckBox id="cbxCancel" runat="server" Text="已註銷："></asp:CheckBox><asp:dropdownlist id="ddlCancel" runat="server">
										<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
										<asp:ListItem Value="1">是</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:button id="btnGo" runat="server" Text="產生合約書清單"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer><asp:literal id="Literal1" runat="server"></asp:literal></form>
	</body>
</HTML>
