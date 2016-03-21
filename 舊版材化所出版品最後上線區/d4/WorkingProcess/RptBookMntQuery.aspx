<%@ Page language="c#" Codebehind="RptBookMntQuery.aspx.cs" src="RptBookMntQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptBookMntQuery" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptBookMntQuery</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptBookMntQuery" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�L�s���Ʋέp��<IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										<asp:Label id="lblTitle" runat="server"></asp:Label></FONT>
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
										<asp:ListItem Value="01" Selected="True">�u�����x</asp:ListItem>
										<asp:ListItem Value="02">�q�����x</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right">�έp�~��G</td>
								<td><asp:textbox id="tbxDate" runat="server" Width="60px"></asp:textbox><font color="maroon" size="2">(�p 
										2004/02, �w�]��: ���)<asp:regularexpressionvalidator id="revDate" runat="server" ErrorMessage="�~���J�榡���~" ControlToValidate="tbxDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:regularexpressionvalidator></font></td>
							</tr>
							<tr>
								<td align="right">���x���ơG</td>
								<td><asp:textbox id="tbxBookNo" runat="server" Width="60px"></asp:textbox><FONT color="#800000" size="2">��</FONT></td>
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
								<td align="right"><asp:checkbox id="cbxMtpcd" runat="server" Text="�l�H�覡�G"></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlMtpcd" runat="server">
										<asp:ListItem Value="0" Selected="True">�j�v�l�H</asp:ListItem>
										<asp:ListItem Value="1">���o�Ǹg��</asp:ListItem>
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
								<td><asp:button id="btnPrintList" runat="server" Text="���ͦL�s���Ʋέp��"></asp:button></td>
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
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
