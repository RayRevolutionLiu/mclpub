<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="adpub_act1.aspx.cs" Src="adpub_act1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_act1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�����ʧ@ �B�J�@ / ���s�˫�ץ� �B�J�@</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left">
				<tr>
					<td align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�i�����ʧ@ �B�J�@ / ���s�˫�ץ� �B�J�@</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_act1" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE align="center" style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
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
							<asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>
							&nbsp; 
							<!-- �d�߫��s -->
							<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>
							<br>
							<font color="gray">(�п�J 4~6�X�Ʀr "�~��" �� "�~" �� "��".
								<br>
								&nbsp;�p2002�~ 1��, �п�J&nbsp;200201 �� 2002 �� 01)</font>
							<br>
							<br>
							<!-- �d�ߵ��G��� -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD valign="top" align="left" width="50%">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
2. �d�ߵ��G���]�t�w���ת����.<br> 	3. �X�{���G��, �б��۫��U "<font color="blue"><U>���s��</U></font>" ���~��i��s�i�����ʧ@!</asp:label>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</BODY>
</HTML>
