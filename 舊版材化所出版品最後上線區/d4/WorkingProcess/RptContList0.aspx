<%@ Page language="c#" Codebehind="RptContList0.aspx.cs" Src="RptContList0.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptContList0" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptContList0" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="90%">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�X���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;&nbsp;�j��X���ѲM��</FONT>
								</TD>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="2">�d�߱���</TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxContNo" runat="server" Text="�X���ѽs���G"></asp:checkbox><asp:textbox id="tbxContNo" runat="server" Width="100px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxDate" runat="server" Text="ñ������϶��G"></asp:checkbox><asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">��
									<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
									<asp:label id="lblyyyymmdd" runat="server" CssClass="ImportantLabel">(yyyy/mm/dd)</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxEmpData" runat="server" Text="�ӿ�~�ȭ��G"></asp:checkbox><asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxMfrIName" runat="server" Text="�t�ӦW�١G"></asp:checkbox><asp:textbox id="tbxMfrIName" runat="server" Font-Size="X-Small"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									<asp:CheckBox id="cbxClosed" runat="server" Text="�w���סG"></asp:CheckBox><asp:dropdownlist id="ddlClosed" runat="server">
										<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
										<asp:ListItem Value="1">�O</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>
									<asp:CheckBox id="cbxCancel" runat="server" Text="�w���P�G"></asp:CheckBox><asp:dropdownlist id="ddlCancel" runat="server">
										<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
										<asp:ListItem Value="1">�O</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:button id="btnGo" runat="server" Text="���ͦX���ѲM��"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer><asp:literal id="Literal1" runat="server"></asp:literal></form>
	</body>
</HTML>
