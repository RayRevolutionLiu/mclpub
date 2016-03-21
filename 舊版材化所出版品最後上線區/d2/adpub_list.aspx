<%@ Page language="c#" Codebehind="adpub_list.aspx.cs" Src="adpub_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_list" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�����M�� �B�J�@</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
		<!-- Javascript -->
	</HEAD>
	<BODY>
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�i�����M�� �B�J�@</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form ID="adpub_list" name="adpub_list" method="post" runat="server">
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
								<asp:textbox id="tbxPubDate" runat="server" Width="60px" MaxLength="7"></asp:textbox><br>
								<font color="gray">(�п�J 6�X�~��,&nbsp;�p2002�~ 1��, �п�J&nbsp;2002/01)</font>
								<br>
								<asp:checkbox id="cbx0" runat="server"></asp:checkbox>
								�ӿ�~�ȭ��G
								<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>&nbsp;&nbsp; 
								<!-- �d�߫��s -->
								<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;&nbsp;
								<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>
								<br>
								<br>
								<!-- �d�ߵ��G��� -->
								<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
							</TD>
							<TD vAlign="top" align="left" width="50%">
								<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
											2. �X�{���G��, �Y�����~���, �N�n�D���ץ�; <br>&nbsp;&nbsp;&nbsp;&nbsp;�Y�L���~�������, �ЦA���U "<font color="blue">
										<U>���s��</U></font>" ���~��!</asp:label>
								<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
							</TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2">
								&nbsp;<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ErrorMessage="'�Z�n�~��' �Ш̮榡��J(�аѮ����r����)!!!" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</BODY>
</HTML>
