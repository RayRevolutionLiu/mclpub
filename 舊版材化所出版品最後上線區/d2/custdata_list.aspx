<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="custdata_list.aspx.cs" Src="custdata_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.custdata_list" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�Ȥ�򥻸�ƲM��</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
		<!-- Javascript -->
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							���s��B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�Ȥ�򥻸�ƲM��</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form ID="custdata_list" name="custdata_list" method="post" runat="server">
				<!-- �z�����, ���ܼ� -->
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">�d�߱���</font>
						</td>
					</tr>
					<TR>
						<TD>
							<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
							�Ȥ�s���d��G
							<asp:TextBox id="tbxCustNoQ1" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
							��
							<asp:TextBox id="tbxCustNoQ2" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
							<br>
							<asp:CheckBox id="cbx2" runat="server"></asp:CheckBox>
							�Ȥ�(�q�ܸ��X)�ϰ�X�G
							<asp:TextBox id="tbxTelAC" runat="server" Width="40px" MaxLength="3"></asp:TextBox>
							<br>
							<asp:CheckBox id="cbx3" runat="server"></asp:CheckBox>
							�Ȥ���N�X�G
							<asp:DropDownList id="ddlItpcd" runat="server"></asp:DropDownList>
							<br>
							<asp:CheckBox id="cbx4" runat="server"></asp:CheckBox>
							�Ȥ���~�N�X�G
							<asp:DropDownList id="ddlBtpcd" runat="server"></asp:DropDownList>&nbsp;&nbsp; 
							<!-- �d�߫��s -->
							<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;&nbsp;
							<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>
							<br>
							<!-- �d�ߵ��G��� -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD vAlign="top" align="left">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">* �пz����, �M����U "�d��".<br><br>
							</asp:label>
						</TD>
					</TR>
					<TR>
						<TD align="middle" bgColor="#ffffff" colSpan="2">
							<asp:Literal id="Literal1" runat="server"></asp:Literal>
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</BODY>
</HTML>
