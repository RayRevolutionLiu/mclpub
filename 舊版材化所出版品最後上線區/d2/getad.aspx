<%@ Page language="c#" Codebehind="getad.aspx.cs" Src="getad.aspx.cs"  AutoEventWireup="false" Inherits="MRLPub_d2.getad" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ʽZ��</title>
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
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="center">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�ʽZ�B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�ʽZ��</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="getad" name="getad" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">�d�߱���</font>
						</td>
					</tr>
					<TR>
						<TD>
							���y���O�G&nbsp;
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
							&nbsp;
							<br>
							<br>
							�ʽZ�~��G
							<asp:textbox id="tbxyyyymm" runat="server" MaxLength="7" Width="60px"></asp:textbox>
							&nbsp;
							<br>
							<font color="gray">(�п�J 6�X�~��, �p2002�~ 1��, �п�J 2002/01)</font>
							<br>
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
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label><FONT face="�s�ө���"></FONT>
						</TD>
						<TD vAlign="top" align="left">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
2. �d�ߵ��G���]�t<font color='Red'>�w����/�w���P</font>�����.<br><br>
							</asp:label>
							<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
							<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
						</TD>
					</TR>
					<TR>
						<TD align="center" bgColor="#ffffff" colSpan="2">
							&nbsp;
							<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}"
								ControlToValidate="tbxyyyymm" ErrorMessage="'�ʽZ�~��' �Ш̮榡��J(�аѮ����r����)!!!"></asp:RegularExpressionValidator>
							<asp:Literal id="Literal1" runat="server"></asp:Literal>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer><FONT face="�s�ө���"></FONT>
		</center>
	</BODY>
</HTML>
