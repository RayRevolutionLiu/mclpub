<%@ Page debug=true language="c#" Codebehind="adlprior_addnew.aspx.cs" Src="adlprior_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�����u������ - �s�W</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<center>
			<!-- ���� Header -->
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle" bgColor="#e7ebff">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�������@�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����u������ - �s�W</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adlprior_addnew" method="post" runat="server"> <!-- �ק� Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">�s�W�����u������</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="25%">
							&nbsp;<FONT color="#ff0000">* </FONT>���y�W��:
						</TD>
						<TD width="40%">
							<asp:dropdownlist id="ddlBookCode" runat="server" AutoPostBack="True"></asp:dropdownlist>
							<br>
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD width="*" align="right">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">���������</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�ƪ��u������:
						</TD>
						<TD colspan="2">
							<asp:textbox id="tbxPriorSeq" runat="server" MaxLength="2" Width="30px" ForeColor="Gray" ReadOnly="True"></asp:textbox>
							<FONT face="�s�ө���">&nbsp;<FONT color="#8b4513">(�̮��y�W�٦۰ʧ�X, �����\�ק�)</FONT></FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�s�i��m:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlColorCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�s�i����:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlLayoutTypeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�s�i�g�T:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddPageSizeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD colspan="3" align="right">
							<asp:button id="btnUpdate" runat="server" Text="�T�w�s�W" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="���s�W" Height="24px" CausesValidation="False"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
		</center>
	</body>
</HTML>
