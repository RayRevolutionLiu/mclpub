<%@ Page language="c#" Codebehind="ORForm.aspx.cs" Src="ORForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W ���x����H���</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="ORForm" method="post" runat="server">
			<!-- ���x����H ���v��� �� -->
			<font size="2" color="#ff0066">[���x����H ���v��� ��]</font>
			<br>
			History DataGrid
			<br>
			<!-- ���x����H �s�W/�x�s��� �� -->
			<font size="2" color="#ff0066">[���x����H �s�W/�x�s��� ��]</font>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							�t��
							<br>
							�N�X
						</TH>
						<TH>
							�X����
							<br>
							�s��
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>���q�W��
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�m�W
						</TH>
						<TH>
							¾��
						</TH>
						<TH>
							�q��
						</TH>
						<TH>
							���n
							<br>
							����
						</TH>
						<TH>
							���n
							<br>
							����
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�l�H���O
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>���~
							<br>
							�l�H
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD>
							<asp:textbox id="tbxORSysCode" runat="server" MaxLength="2" WIDTH="30px" Font-Size="X-Small" Enabled="False">C2</asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORContNo" runat="server" MaxLength="6" WIDTH="50px" Font-Size="X-Small" Enabled="False"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORMfrIName" runat="server" MaxLength="50" Width="80px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORName" runat="server" MaxLength="30" Width="70px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORJobTitle" runat="server" MaxLength="12" Width="70px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORTel" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORPubCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORPubUnCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORmtpcd" runat="server"></asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORfgmosea" runat="server">
								<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
								<asp:ListItem Value="1">��~</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<!-- �ĤG�� -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH>
							�l��
							<br>
							�ϸ�
						</TH>
						<TH colSpan="3">
							�a�}
						</TH>
						<TH>
							�ǯu
						</TH>
						<TH colSpan="2">
							���
						</TH>
						<TH colSpan="2">
							Email
						</TH>
					</TR>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
						</TD>
						<TD>
							<asp:textbox id="tbxORZipcode" runat="server" MaxLength="5" Width="40px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxORAddr" runat="server" MaxLength="120" WIDTH="230px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORFax" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxORCell" runat="server" MaxLength="30" WIDTH="80px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxOREmail" runat="server" MaxLength="80" WIDTH="160px" Font-Size="X-Small"></asp:textbox>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">��1�G* ���������!</FONT>
			<br>
			<FONT color="#c00000" size="2">��1�G�w�]��ܤ��t�Ӹ�Ƭ��ӫȤᤧ�t�Ӹ��; �Y���ק�, �Цۦ�ץ�!</FONT>
			<br>
			<br>
			<asp:button id="btnSave" runat="server" Text="�x�s�s�W"></asp:button>
			&nbsp;&nbsp;
			<asp:Button id="btnModify" runat="server" Text="�x�s�ק�"></asp:Button>
			<FONT face="�s�ө���">&nbsp;&nbsp; <INPUT id="btnClose" onclick="Javascript:window.close();" type="button" value="��������" name="btnClose"></FONT>
		</form>
	</body>
</HTML>
