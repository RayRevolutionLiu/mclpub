<%@ Page language="c#" Codebehind="or_edit.aspx.cs" Src="or_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.or_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���x����H - �ק�</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
							���x����H - �ק�</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="or_edit" method="post" runat="server">
				<!-- �ק� Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="80%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">�ק����x����H</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="35%">
							&nbsp;<FONT color="#ff0000">* </FONT>�t�ΥN�X /&nbsp;�X���ѽs�� :
						</TD>
						<TD width="50%">
							<asp:textbox id="or_syscd" runat="server" Width="25px" MaxLength="2" ForeColor="Gray" ReadOnly="True"></asp:textbox>
							&nbsp;
							<asp:textbox id="or_contno" runat="server" Width="65px" MaxLength="6" ForeColor="Gray" ReadOnly="True"></asp:textbox>
							<FONT color="#8b4513">(�Ǧ�r�N�����\�ק�)</FONT>&nbsp;
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD align="right" width="*">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">���������</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT><FONT color="#000000">�Ǹ� / �m�W / ¾��: </FONT>
						</TD>
						<TD colSpan="3">
							<asp:textbox id="or_oritem" runat="server" Width="25px" MaxLength="2"></asp:textbox>
							&nbsp;&nbsp;
							<asp:textbox id="or_nm" runat="server" Width="65px" MaxLength="30"></asp:textbox>
							&nbsp;
							<asp:textbox id="or_jbti" runat="server" Width="60px" MaxLength="12"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�q�� / �ǯu:
						</TD>
						<TD colSpan="3">
							<asp:textbox id="or_tel" runat="server" Width="85px" MaxLength="30"></asp:textbox>
							&nbsp;
							<asp:textbox id="or_fax" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;���:
						</TD>
						<TD colSpan="3">
							<asp:textbox id="or_cell" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;Email:
						</TD>
						<TD colSpan="3">
							<asp:textbox id="or_email" runat="server" Width="160px" MaxLength="80"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�l���ϸ� / �a�}:
						</TD>
						<TD colSpan="3">
							<asp:textbox id="or_zip" runat="server" Width="30px" MaxLength="5"></asp:textbox>
							&nbsp;&nbsp;
							<asp:textbox id="or_addr" runat="server" Width="300px" MaxLength="120"></asp:textbox>
							&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�l�H���O / ���~�l�H:
						</TD>
						<TD colSpan="3">
							<asp:dropdownlist id="ddlORMailTypeCode" runat="server" AutoPostBack="True"></asp:dropdownlist>
							&nbsp;/&nbsp;&nbsp;<asp:textbox id="or_fgmoseanm" runat="server" Width="25px" MaxLength="1" ReadOnly="True"></asp:textbox>
							&nbsp;<INPUT id="or_fgmosea" style="WIDTH: 20px" type="hidden" size="1" name="or_fgmosea" runat="server">&nbsp;
							<FONT color="#8b4513">(���~�l�H�|�ھڶl�H���O�ӧY�ɦ۰��ܧ�!)</FONT>&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;���n���� / ���n����:
						</TD>
						<TD colSpan="3">
							<asp:textbox id="or_pubcnt" runat="server" Width="30px" MaxLength="4"></asp:textbox>
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:textbox id="or_unpubcnt" runat="server" Width="30px" MaxLength="4"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right" colSpan="4">
							<asp:button id="btnUpdate" runat="server" Text="�T�w��s" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="���ק�" Height="24px" CausesValidation="False"></asp:button>
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<!-- ���� Footer -->
		</center>
	</body>
</HTML>
