<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="PayTypeFM.aspx.cs" src="PayTypeFM.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayTypeFM" %>
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
		<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
		<form id="PayTypeFM" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							ú�ڳB�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">�ק�ú�ڸ��</font>
					</td>
				</tr>
			</table>
			<table style="WIDTH: 222px; HEIGHT: 78px" cellSpacing="0" cellPadding="0" border="0">
				<TR bgColor="#4a3c8c">
					<TD colSpan="2">
						<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">ú�ڳ���</FONT>
					</TD>
				</TR>
				<TR bgColor="#e7e7ff">
					<TD style="WIDTH: 94px" align="right">
						<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">ú�ڳ�s���G</FONT>
					</TD>
					<TD style="WIDTH: 124px">
						<asp:label id="lblPayNo" runat="server" ForeColor="#C04000"></asp:label>
					</TD>
				</TR>
				<TR bgColor="#e7e7ff">
					<TD style="WIDTH: 94px" align="right">
						<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���B�G</FONT>
					</TD>
					<TD style="WIDTH: 124px">
						<asp:label id="lblAmt" runat="server" ForeColor="#C04000"></asp:label>
					</TD>
				</TR>
				<TR bgColor="#e7e7ff">
					<TD style="WIDTH: 94px" align="right">
						<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">ú�ڤ���G</FONT>
					</TD>
					<TD style="WIDTH: 124px">
						<asp:label id="lblDate" runat="server" ForeColor="#C04000"></asp:label>
					</TD>
				</TR>
				<TR bgColor="#e7e7ff">
					<TD style="WIDTH: 94px" align="right">
						<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�I�ڤ覡�G</FONT>
					</TD>
					<TD style="WIDTH: 124px">
						<asp:dropdownlist id="ddlPayType" runat="server" AutoPostBack="true"></asp:dropdownlist>
					</TD>
				</TR>
			</table>
			<asp:panel id="Panel1" runat="server" Visible="False">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR bgColor="#4a3c8c">
						<TD colSpan="2"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���ڸ��</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���X�G</FONT>
						</TD>
						<TD style="WIDTH: 119px">
							<INPUT id="tbxChkno" style="WIDTH: 114px" type="text" maxLength="16" size="13" name="tbxChkno" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�I�ڦ�G</FONT>
						</TD>
						<TD style="WIDTH: 187px">
							<INPUT id="tbxChkbnm" style="WIDTH: 185px" type="text" maxLength="20" size="25" name="tbxChkbnm" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�����G</FONT>
						</TD>
						<TD style="WIDTH: 113px">
							<INPUT id="tbxChkdate" style="WIDTH: 78px" type="text" size="7" name="tbxChkdate" runat="server">
							<IMG title="���" onclick="pick_date(tbxChkdate.name)" src="../images/calendar01.gif">
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="Panel2" runat="server" Visible="False">
				<TABLE style="WIDTH: 231px; HEIGHT: 48px" cellSpacing="0" cellPadding="0" border="0">
					<TR bgColor="#4a3c8c">
						<TD colSpan="2"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">��������</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�帹�G</FONT>
						</TD>
						<TD style="WIDTH: 119px">
							<INPUT id="tbxMoseq" style="WIDTH: 53px" type="text" maxLength="5" size="3" name="tbxMoseq" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�����G</FONT>
						</TD>
						<TD style="WIDTH: 187px">
							<INPUT id="tbxMoitem" style="WIDTH: 53px" type="text" maxLength="3" size="3" name="tbxMoitem" runat="server">
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="Panel3" runat="server" Visible="False">
				<TABLE style="WIDTH: 235px; HEIGHT: 72px" cellSpacing="0" cellPadding="0" border="0">
					<TR bgColor="#4a3c8c">
						<TD colSpan="2"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�q�׸��</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 86px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�b���G</FONT>
						</TD>
						<TD style="WIDTH: 119px">
							<INPUT id="tbxWaccno" style="WIDTH: 114px" type="text" maxLength="16" size="13" name="tbxWaccno" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 86px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�פJ����G</FONT>
						</TD>
						<TD style="WIDTH: 187px">
							<INPUT id="tbxWdate" style="WIDTH: 93px" type="text" maxLength="10" size="10" name="tbxWdate" runat="server">
							<IMG title="���" onclick="pick_date(tbxWdate.name)" src="../images/calendar01.gif">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 86px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���ĥN�X�G</FONT>
						</TD>
						<TD style="WIDTH: 113px">
							<INPUT id="tbxWbcd" style="WIDTH: 38px" type="text" maxLength="3" size="1" name="tbxWbcb" runat="server">
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="Panel4" runat="server" Visible="False">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TR bgColor="#4a3c8c">
						<TD colSpan="4"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�H�Υd���</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�d�O�G</FONT>
						</TD>
						<TD colSpan="3">
							<asp:RadioButtonList id="rblCctp" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">�p�X�H�Υd</asp:ListItem>
								<asp:ListItem Value="2">VISA</asp:ListItem>
								<asp:ListItem Value="3">Master</asp:ListItem>
								<asp:ListItem Value="4">JCB</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�d���G</FONT>
						</TD>
						<TD colSpan="3">
							<INPUT id="tbxCcno1" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno1" runat="server">
							- <INPUT id="tbxCcno2" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno2" runat="server">
							- <INPUT id="tbxCcno3" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno3" runat="server">
							- <INPUT id="tbxCcno4" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno4" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���v�X�G</FONT>
						</TD>
						<TD colSpan="3">
							<INPUT id="tbxCcauthcd" style="WIDTH: 78px" type="text" maxLength="6" size="7" name="tbxCcauthcd" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���Ħ~��G</FONT>
						</TD>
						<TD colSpan="3">
							<INPUT id="tbxYear" style="WIDTH: 48px; HEIGHT: 22px" type="text" maxLength="4" size="2" name="tbxYear" runat="server">
							�~ <INPUT id="tbxMonth" style="WIDTH: 31px; HEIGHT: 22px" type="text" maxLength="2" size="1" name="tbxMonth" runat="server">
							��
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right"><FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�������G</FONT>
						</TD>
						<TD>
							<INPUT id="tbxCcDate" style="WIDTH: 93px" type="text" maxLength="10" size="10" name="tbxWdate" runat="server">
							<IMG title="���" onclick="pick_date(tbxCcDate.name)" src="../images/calendar01.gif">
						</TD>
					</TR>
				</TABLE>
			</asp:panel></TABLE>
			<br>
			<input id="btnCancel" onclick='javascritp:window.location.href="../default.aspx"' type="button" value="�����^����" name="btnCancel">
			<asp:button id="btnOK" runat="server" Text="�T�w�x�sú�ڸ��"></asp:button>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
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
