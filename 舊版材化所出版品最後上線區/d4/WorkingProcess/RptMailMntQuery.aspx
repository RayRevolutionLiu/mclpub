<%@ Page language="c#" Codebehind="RptMailMntQuery.aspx.cs" src="RptMailMntQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptMailMntQuery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptMailMntQuery</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptMailMntQuery" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�l�H���Ʋέp��</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE class="TableColor" cellSpacing="0" cellPadding="2" width="100%">
							<tr class="TableColorHeader">
								<td colSpan="2">�d�߱���</td>
							</tr>
							<tr>
								<td align="right" width="150">���y���O�G</td>
								<td><asp:dropdownlist id="ddlBookCode" runat="server">
										<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right">�خѦ~��϶��G</td>
								<td><asp:textbox id="tbxSDate" runat="server" Width="60px"></asp:textbox>~<asp:textbox id="tbxEDate" runat="server" Width="60px"></asp:textbox><font color="maroon" size="2">(�p 
										2003/10, �w�]��: ���)<asp:regularexpressionvalidator id="revSDate" runat="server" ErrorMessage="�_�l�~���J�榡���~" ControlToValidate="tbxSDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="revEDate" runat="server" ErrorMessage="�����~���J�榡���~" ControlToValidate="tbxEDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:regularexpressionvalidator></font></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxContType" runat="server" Text="�X�����O�G"></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlConttp" runat="server">
										<asp:ListItem Value="01" Selected="True">�@��</asp:ListItem>
										<asp:ListItem Value="09">���s</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxMosea" runat="server" Text="�l�H�a�ϡG"></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlfgMOSea" runat="server">
										<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
										<asp:ListItem Value="1">��~</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxMtpcd" runat="server" Text="�l�H���O�G"></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlMtpcd" runat="server">
										<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxEmpno" runat="server" Text="�ӿ�~�ȭ��G"></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlEmpNo" runat="server">
										<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td></td>
								<td><asp:button id="btnPrintList" runat="server" Text="���Ͷl�H���Ʋέp��"></asp:button></td>
							</tr>
						</TABLE>
						<br>
						<asp:literal id="Literal1" runat="server"></asp:literal><br>
						<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label><br>
						&nbsp;
					</td>
				</tr>
			</TABLE>
			<br>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
