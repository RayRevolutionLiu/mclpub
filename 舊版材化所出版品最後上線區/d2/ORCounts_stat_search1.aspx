<%@ Page language="c#" Codebehind="ORCounts_stat_search1.aspx.cs" Src="ORCounts_stat_search1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORCounts_stat_search1" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�l�H���Ʋέp�� ���Z�n �B�J�@: �j�M</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�έp�� ���Z�n �B�J�@: �j�M<IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�l�H���Ʋέp��</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="ORCounts_stat_search1" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td colSpan="2">
								<font color="white">�d�߱���</font>
							</td>
						</tr>
						<TR>
							<TD width="*">
								���y���O�G
								<asp:dropdownlist id="ddlBookCode" runat="server">
									<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									<asp:ListItem Value="01">�u��</asp:ListItem>
									<asp:ListItem Value="02">�q��</asp:ListItem>
									<asp:ListItem Value="04">�q���O��</asp:ListItem>
									<asp:ListItem Value="05">����</asp:ListItem>
								</asp:dropdownlist>
								<br>
								<br>
								�Z�n�~��G
								<asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(�p 
									2002/08, �w�]��: ���)</font><br>
								<br>
								<asp:checkbox id="cbx0" runat="server"></asp:checkbox>
								<asp:label id="lblConttp" runat="server" Font-Size="X-Small">�X�����O�G</asp:label>
								<asp:dropdownlist id="ddlConttp" runat="server">
									<asp:ListItem Value="01" Selected="True">�@��</asp:ListItem>
									<asp:ListItem Value="09">���s</asp:ListItem>
								</asp:dropdownlist><br>
								<asp:checkbox id="cbx1" runat="server"></asp:checkbox>
								<asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">�l�H�a�ϡG</asp:label>
								<asp:dropdownlist id="ddlfgMOSea" runat="server">
									<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
									<asp:ListItem Value="1">��~</asp:ListItem>
								</asp:dropdownlist><br>
								<!-- �d�߫��s -->
								<asp:checkbox id="cbx2" runat="server"></asp:checkbox>
								<asp:label id="lblMtpcd" runat="server" Font-Size="X-Small">�l�H���O�G</asp:label>
								<asp:dropdownlist id="ddlMtpcd" runat="server"></asp:dropdownlist>
								<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;
								<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>
								<br>
								<!-- �d�ߵ��G��� -->
								<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
							</TD>
							<TD vAlign="top" align="left" width="50%">
								<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
2. �d�ߵ��G���]�t '<font color='Red'>�w����/�w���P</font>' ���X��.<br>3. �X�{���G��, �ЦA���U "<font color="blue"><U>���s��</U></font>" ���~��!</asp:label>
								<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
							</TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2">&nbsp;
								<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxPubDate" ErrorMessage="'�Z�n�~��' �Ш̮榡��J(�аѮ����r����)!!!"></asp:RegularExpressionValidator>
								<asp:Literal id="Literal1" runat="server"></asp:Literal>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
