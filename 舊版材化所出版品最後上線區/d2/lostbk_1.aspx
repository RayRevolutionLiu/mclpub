<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="lostbk_1.aspx.cs" Src="lostbk_1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk_1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�ʮѵn��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<!-- �ثe�Ҧb��m -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�ʮѳB�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�ʮѵn��</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form-->
			<form id="lostbk_1" method="post" runat="server">
				<TABLE style="WIDTH: 80%" cellSpacing="0" cellPadding="4" align="center" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">�X���Ѹ��&nbsp;
								<asp:Label id="lblMessage" runat="server" ForeColor="Yellow"></asp:Label>
							</FONT>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right" width="20%">
							�X���ѽs���G
						</TD>
						<TD class="cssData" width="*">
							<asp:label id="lblContNo" ForeColor="Maroon" Runat="server"></asp:label>
							&nbsp;&nbsp; <font size="2" color="gray">(<IMG class="ico" id="imgContDetail" alt="��ܦX���θ������" src="../images/edit.gif" width="18" border="0" onclick="javascript:window.open('ContPubFm_show.aspx?custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblContNo.Text); %>', '_new', 'Height=470, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')">��ܦX���θ������)</font>
						</TD>
						<TD class="cssTitle" align="right" width="20%">
							�X�����O�G
						</TD>
						<TD class="cssData" width="*">
							<asp:label id="lblConttp" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" align="right">
							�X���_���G
						</TD>
						<TD class="cssData">
							<asp:label id="lblContsdate" runat="server" ForeColor="Maroon"></asp:label>
							~<asp:label id="lblContedate" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
						<TD class="cssTitle" align="right">
							���ס��w���P�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblfgClosed" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;��&nbsp;
							<asp:label id="lblfgCancel" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">�Ȥ���</font>
						</td>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							�Ȥ�s���G
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustNo" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
						<TD align="right">
							�Ȥ�m�W�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							���q�W�١G
						</TD>
						<TD class="cssData" colSpan="3">
							<asp:label id="lblMfrIName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<TD class="cssTitle" colSpan="4">
							<font color="white">���x����H���</font>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							����H�m�W�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblORName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
						<TD class="cssTitle" align="right">
							�l�H�覡�G
						</TD>
						<TD class="cssData">
							<asp:Label id="lblORmtpcd" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
					</TR>
					<TR align="left">
						<TD align="right">
							����a�}�G
						</TD>
						<TD class="cssData" colSpan="3">
							<asp:label id="lblORZipcode" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;&nbsp;
							<asp:label id="lblORAddr" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">�ʮѸ��</font>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							�ʮѧǸ��G
						</TD>
						<TD class="cssData">
							<asp:label id="lblLostSeq" runat="server" ForeColor="Blue"></asp:label>
						</TD>
						<TD class="cssTitle" align="right">
							�ʮѤ���G
						</TD>
						<TD class="cssData">
							<asp:label id="lblLostDate" runat="server" ForeColor="Blue"></asp:label>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							�ʮѤ��e�G
						</TD>
						<TD class="cssData" colSpan="3">
							<TEXTAREA id="textarea1" name="textarea1" rows="3" cols="50" runat="server" tabindex="1"></TEXTAREA>
							<br>
							<font size="2" color="darkred">(�̦h��J25�Ӥ���r!)</font>
							<br>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							�ʮѭ�]�G
						</TD>
						<TD class="cssData" colSpan="3">
							<TEXTAREA id="textarea2" name="textarea2" rows="2" cols="50" runat="server" tabindex="2"></TEXTAREA>
							<br>
							<font size="2" color="darkred">(�̦h��J15�Ӥ���r!)</font>
							<br>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							�H�Ѫ��A�G
						</TD>
						<TD class="cssData" colSpan="3">
							<asp:dropdownlist id="ddlSendFlag" runat="server" tabindex="3">
								<asp:ListItem Value="Y" Selected="True">�i�H�X</asp:ListItem>
								<asp:ListItem Value="N">�ثe�ȮɵL�k�H�X</asp:ListItem>
								<asp:ListItem Value="D">���B�z</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
				</TABLE>
				<br>
				<asp:button id="btnModify" runat="server" Text="��ƿ��~,�ק�X����" tabindex="6"></asp:button>
				&nbsp;&nbsp;
				<asp:button id="btnOK" runat="server" Text="�T�w�s�W�ʮѸ��" tabindex="4"></asp:button>
				&nbsp;&nbsp;
				<asp:button id="btnCancel" runat="server" Text="�����^�e��" tabindex="5"></asp:button>
			</form>
			&nbsp; 
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
