<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="RemailForm.aspx.cs" src="RemailForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.RemailForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="RemailForm" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 627px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
								�ɮѳB�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">�ɮѵn��</font>
						</td>
					</tr>
				</table>
				<TABLE style="WIDTH: 596px; HEIGHT: 68px" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">�q����</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 5px" align="right">
							�q��s���G
						</td>
						<td style="WIDTH: 148px; HEIGHT: 5px">
							<asp:label id="lblNo" ForeColor="Maroon" Runat="server"></asp:label>
						</td>
						<td style="WIDTH: 120px; HEIGHT: 5px" align="right">
							�q�����O�G
						</td>
						<td style="WIDTH: 192px; HEIGHT: 5px">
							<asp:label id="lblType1" ForeColor="Maroon" Runat="server"></asp:label>
						</td>
					</tr>
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">�q����</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 132px" align="right">
							�q��s���G
						</TD>
						<TD style="WIDTH: 148px">
							<asp:label id="lblCustNo" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
						<TD style="WIDTH: 120px" align="right">
							�m�W�G
						</TD>
						<TD style="WIDTH: 192px">
							<asp:label id="lblCustName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 132px; HEIGHT: 1px" align="right">
							���q�W�١G
						</TD>
						<TD style="WIDTH: 192px; HEIGHT: 1px" colSpan="3">
							<asp:label id="lblCoName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">����H���</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 1px" align="right">
							����H�G
						</td>
						<td style="WIDTH: 148px; HEIGHT: 1px" colSpan="3">
							<asp:label id="lblRecName" ForeColor="Maroon" Runat="server"></asp:label>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 1px" align="right">
							�a�}�G
						</td>
						<td style="WIDTH: 192px; HEIGHT: 1px" colSpan="3">
							<asp:label id="lblRecAddr" ForeColor="Maroon" Runat="server"></asp:label>
						</td>
					</tr>
					<tr bgColor="#214389">
						<td colSpan="4">
							<font color="white">�ʮѸ��</font>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 31px" align="right">
							�ɮѧǸ��G
						</td>
						<td style="WIDTH: 148px; HEIGHT: 31px">
							<asp:label id="lblRemailSeq" runat="server" ForeColor="Maroon"></asp:label>
						</td>
						<td style="WIDTH: 132px; HEIGHT: 31px" align="right">
							�q�ʰ_���G
						</td>
						<td style="WIDTH: 148px; HEIGHT: 31px">
							<asp:label id="lblsdate" runat="server" ForeColor="Maroon"></asp:label>
							~<asp:label id="lbledate" runat="server" ForeColor="Maroon"></asp:label>
						</td>
					</tr>
					<tr>
						<td class="cssTitle" style="WIDTH: 132px; HEIGHT: 75px" align="right">
							�ɮѤ��e�G
						</td>
						<td class="cssData" style="HEIGHT: 75px" colSpan="3">
							<TEXTAREA id="textarea1" style="WIDTH: 445px; HEIGHT: 77px" name="textarea1" rows="4" cols="53" runat="server"></TEXTAREA>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 132px; HEIGHT: 1px" align="right">
							�H�Ѫ��A�G
						</td>
						<td style="WIDTH: 192px; HEIGHT: 1px" colSpan="3">
							<asp:DropDownList id="ddlSendFlag" runat="server">
								<asp:ListItem Value="Y" Selected="True">�i�H�X</asp:ListItem>
								<asp:ListItem Value="N">�ثe�ȮɵL�k�H�X</asp:ListItem>
								<asp:ListItem Value="D">���B�z</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>
				</TABLE>
				<asp:button id="btnBack" runat="server" Enabled="False" Text="���٭n�ɮ�"></asp:button>
				<asp:button id="btnOK" runat="server" Text="�T�w�s�W�ɮѸ��"></asp:button>
				<asp:button id="btnCancel" runat="server" Text="�����^����"></asp:button>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
			</center>
		</form>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
		<SCRIPT language="javascript">
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vReturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vReturn)
		window.document.all(theField).value=vReturn;
	return true;
}
		</SCRIPT>
	</body>
</HTML>
