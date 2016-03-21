<%@ Page language="c#" Codebehind="PayTypeForm.aspx.cs" src="PayTypeForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayTypeForm" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
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
		<form id="PayTypeForm" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							ú�ڳB�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">�s�Wú�ڸ��</font>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" border="0" style="WIDTH: 222px; HEIGHT: 78px">
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
						&nbsp;
						<asp:label id="lblPayNo" runat="server" ForeColor="#C04000"></asp:label>
					</TD>
				</TR>
				<TR bgColor="#e7e7ff">
					<TD style="WIDTH: 94px" align="right">
						<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���B�G</FONT>
					</TD>
					<TD style="WIDTH: 124px">
						<FONT face="�s�ө���">&nbsp; </FONT>
						<asp:label id="lblAmt" runat="server" ForeColor="#C04000"></asp:label>
						<asp:textbox id="tbxAmt" runat="server" Visible="False" Width="60px"></asp:textbox>
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
						<TD colSpan="2">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">���ڸ��</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���X�G</FONT>
						</TD>
						<TD style="WIDTH: 119px">
							<INPUT id="tbxChkno" style="WIDTH: 114px" type="text" maxLength="16" size="13" name="tbxChkno" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�I�ڦ�G</FONT>
						</TD>
						<TD style="WIDTH: 187px">
							<INPUT id="tbxChkbnm" style="WIDTH: 185px" type="text" maxLength="20" size="25" name="tbxChkbnm" runat="server">
							<FONT color="#990033">��J�r�ƽФŶW�L15�Ӥ���r</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�����G</FONT>
						</TD>
						<TD style="WIDTH: 113px">
							<INPUT id="tbxChkdate" style="WIDTH: 78px" type="text" size="7" name="tbxChkdate" runat="server">
							<IMG title="���" onclick="pick_date(tbxChkdate.name)" src="../images/calendar01.gif">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�l��G</FONT>
						</TD>
						<TD style="WIDTH: 113px">
							<INPUT id="tbxPost" style="WIDTH: 78px" type="text" size="7" name="tbxChkdate" runat="server">
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="Panel2" runat="server" Visible="False">
				<TABLE style="WIDTH: 231px; HEIGHT: 48px" cellSpacing="0" cellPadding="0" border="0">
					<TR bgColor="#4a3c8c">
						<TD colSpan="2">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">��������</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�帹�G</FONT>
						</TD>
						<TD style="WIDTH: 119px">
							<INPUT id="tbxMoseq" style="WIDTH: 53px" type="text" maxLength="5" size="3" name="tbxMoseq" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 61px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�����G</FONT>
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
						<TD colSpan="2">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�q�׸��</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 86px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�b���G</FONT>
						</TD>
						<TD style="WIDTH: 119px">
							<INPUT id="tbxWaccno" style="WIDTH: 114px" type="text" maxLength="16" size="13" name="tbxWaccno" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 86px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�פJ����G</FONT>
						</TD>
						<TD style="WIDTH: 187px">
							<INPUT id="tbxWdate" style="WIDTH: 93px" type="text" maxLength="10" size="10" name="tbxWdate" runat="server">
							<IMG title="���" onclick="pick_date(tbxWdate.name)" src="../images/calendar01.gif">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 86px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���ĥN�X�G</FONT>
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
						<TD colSpan="4">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small; COLOR: white">�H�Υd���</FONT>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�d�O�G</FONT>
						</TD>
						<TD colSpan="3">
							<asp:RadioButtonList id="rblCctp" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">�p�X�H�Υd</asp:ListItem>
								<asp:ListItem Value="2">VISA</asp:ListItem>
								<asp:ListItem Value="3">Master</asp:ListItem>
								<asp:ListItem Value="4">JCB</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�d���G</FONT>
						</TD>
						<TD colSpan="3">
							<INPUT id="tbxCcno1" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno1" runat="server">
							- <INPUT id="tbxCcno2" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno2" runat="server">
							- <INPUT id="tbxCcno3" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno3" runat="server">
							- <INPUT id="tbxCcno4" style="WIDTH: 39px" type="text" maxLength="4" size="1" name="tbxCcno4" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���v�X�G</FONT>
						</TD>
						<TD colSpan="3">
							<INPUT id="tbxCcauthcd" style="WIDTH: 78px" type="text" maxLength="6" size="7" name="tbxCcauthcd" runat="server">
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">���Ħ~��G</FONT>
						</TD>
						<TD colSpan="3">
							<asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>
							�~
							<asp:dropdownlist id="ddlMonth" runat="server">
								<asp:ListItem Value="01">1</asp:ListItem>
								<asp:ListItem Value="02">2</asp:ListItem>
								<asp:ListItem Value="03">3</asp:ListItem>
								<asp:ListItem Value="04">4</asp:ListItem>
								<asp:ListItem Value="05">5</asp:ListItem>
								<asp:ListItem Value="06">6</asp:ListItem>
								<asp:ListItem Value="07">7</asp:ListItem>
								<asp:ListItem Value="08">8</asp:ListItem>
								<asp:ListItem Value="09">9</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
							</asp:dropdownlist>
							��
						</TD>
					</TR>
					<TR bgColor="#e7e7ff">
						<TD style="WIDTH: 72px" align="right">
							<FONT style="FONT-WEIGHT: normal; FONT-SIZE: x-small">�������G</FONT>
						</TD>
						<TD>
							<INPUT id="tbxCcDate" style="WIDTH: 93px" type="text" maxLength="10" size="10" name="tbxWdate" runat="server">
							<IMG title="���" onclick="pick_date(tbxCcDate.name)" src="../images/calendar01.gif">
						</TD>
					</TR>
				</TABLE>
			</asp:panel>
			</TABLE>
			<br>
			<input id="btnCancel" onclick='javascritp:window.location.href="../default.aspx"' type="button" value="�����^����" name="btnCancel">
			<asp:button id="btnPreStep" runat="server" Text="�W�@�B"></asp:button>
			<asp:button id="btnOK" runat="server" Text="�T�w�x�sú�ڸ��"></asp:button>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<SCRIPT language="javascript">
function SelectOK(){
//	alert(xmlItems.selectSingleNode("���Ħ~��").text); dataFld="�פJ���"
	xmlItems3.selectSingleNode("���Ħ~��").text=document.all("tbx13").value+document.all("tbx14").value;
	document.all("tbx7").value=document.all("tbx7").value.replace("/", "");
	document.all("tbx7").value=document.all("tbx7").value.replace("/", "");
	if(xmlItems3.selectSingleNode("�d�O").text=="0")
	xmlItems3.selectSingleNode("�d�O").text=document.all("tbx10").value;
	xmlItems2.selectSingleNode("�פJ���").text=document.all("tbx7").value;
	document.all("tbx3").value=document.all("tbx3").value.replace("/", "");
	document.all("tbx3").value=document.all("tbx3").value.replace("/", "");
	xmlItems1.selectSingleNode("�����").text=document.all("tbx3").value;
	oMyObject.result = xmlDoc2.documentElement.cloneNode(true);
	window.returnValue = true;
	window.close();
}
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vReturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vReturn)
		window.document.all(theField).value=vReturn;
	return true;
}
function doChange(obj){
alert(obj.value);
}
		</SCRIPT>
	</body>
</HTML>
