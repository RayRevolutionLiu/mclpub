<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="NewCust.aspx.cs" src="NewCust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.NewCust" %>
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
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<form id="CustForm" method="post" runat="server">
			<CENTER>
				<table id="tbItems">
					<tr>
						<td style="WIDTH: 600px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								�q���� <IMG height="10" src="images/header/right02.gif" width="10" border="0"> �s�W�q����
							</font>
						</td>
					</tr>
				</table>
			</CENTER>
			<CENTER>
				<TABLE style="WIDTH: 600px" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 647px" colSpan="4">
							<font color="white">�t�Ӹ��</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							���q�W�١G
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							&nbsp;&nbsp;
							<asp:textbox id="tbxCompanyname" runat="server" Width="200px"></asp:textbox>
							<IMG class="ico" title="�d��" onclick="doSelectMfr( tbxMfrno.name,tbxMfrno.value,tbxCompanyname.name, tbxCompanyname.value)" height="20" src="images/search.gif" width="18" border="0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<font color="blue">[</font><font color="red">*</font><font color="blue">���������]</font>
							<br>
							<asp:label id="Label1" runat="server" ForeColor="DarkRed">[�п�J����ȵM���"�d��"�H���o�Τ@�s��] </asp:label>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							�Τ@�s���G
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxMfrno" runat="server" Width="107px"></asp:textbox>
							<IMG class="ico" title="�d��" onclick="doSelectMfr( tbxMfrno.name,tbxMfrno.value,tbxCompanyname.name, tbxCompanyname.value)" height="20" src="images/search.gif" width="18" border="0">
							<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="tbxMfrno" ErrorMessage="RequiredFieldValidator">���ର�ť�</asp:requiredfieldvalidator>
							<asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label>
							<br>
							<asp:label id="Label2" runat="server" ForeColor="DarkRed">[�p�T�w��J���T���Τ@�s��,�Y�i���L�d�ߥ\���~���J�H�U���] </asp:label>
						</TD>
					</TR>
					<tr bgColor="#214389">
						<td style="WIDTH: 647px" colSpan="4">
							<font color="white">�s�q����</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							�q��s���G
						</TD>
						<TD style="WIDTH: 185px">
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:Label id="lblInvoiceid" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
						<TD style="WIDTH: 69px" align="right">
							�n������G
						</TD>
						<TD style="WIDTH: 259px">
							<asp:textbox id="tbxRegDate" runat="server" Width="107px"></asp:textbox>
							<IMG class="ico" title="���" onclick="pick_date(tbxRegDate.name)" src="../images/calendar01.gif">
							<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="tbxRegDate" ErrorMessage="����榡 2001/01/01" Font-Size="X-Small" ValidationExpression="[0-9]{4}/[0-9]{2}/[0-9]{2}"></asp:regularexpressionvalidator>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							�m�W�G
						</TD>
						<TD style="WIDTH: 185px">
							<font color="red">*</font>
							<asp:textbox id="tbxCustname" runat="server" Width="107px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbxCustname" ErrorMessage="���ର�ť�" Font-Size="X-Small"></asp:requiredfieldvalidator>
						</TD>
						<TD style="WIDTH: 69px" align="right">
							������X�G
						</TD>
						<TD style="WIDTH: 259px">
							<asp:textbox id="tbxCell" runat="server" Width="107px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							�p���q�ܡG
						</TD>
						<TD style="WIDTH: 185px">
							<font color="red">*</font>
							<asp:textbox id="tbxTel" runat="server" Width="107px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="tbxTel" ErrorMessage="���ର�ť�" Font-Size="X-Small"></asp:requiredfieldvalidator>
						</TD>
						<TD style="WIDTH: 69px" align="right">
							�ǯu���X�G
						</TD>
						<TD style="WIDTH: 259px">
							<asp:textbox id="tbxFax" runat="server" Width="107px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							¾�١G
						</TD>
						<TD style="WIDTH: 185px">
							<asp:radiobuttonlist id="rblJob" runat="server" Width="176px" RepeatDirection="Horizontal" AutoPostBack="true">
								<asp:ListItem Value="����" Selected="True">����</asp:ListItem>
								<asp:ListItem Value="�p�j">�p�j</asp:ListItem>
								<asp:ListItem Value="�ۭq">�ۭq</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD style="WIDTH: 341px" colSpan="2">
							<asp:textbox id="tbxJob" runat="server" Enabled="False" Height="26px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							Email�G
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<asp:textbox id="tbxEmail" runat="server" Width="322px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							��~���ءG
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<asp:checkboxlist id="cblbtp" runat="server" Width="506px" RepeatDirection="Horizontal" BorderStyle="Inset" BorderWidth="1px" RepeatColumns="4" BackColor="#E2EAFC"></asp:checkboxlist>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 109px" align="right">
							�M�~���G
						</TD>
						<TD style="WIDTH: 560px" colSpan="3">
							<asp:checkboxlist id="cblitp" runat="server" Width="506px" RepeatDirection="Horizontal" BorderStyle="Inset" BorderWidth="1px" RepeatColumns="4" BackColor="#E2EAFC"></asp:checkboxlist>
						</TD>
					</TR>
				</TABLE>
				<asp:button id="btnNew" runat="server" Text="�s�W���"></asp:button>
				<input onclick="javascript:window.history.back();" type="button" value="���s�W">
				<br>
			</CENTER>
		</form>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
function doSelectMfr(theField1, value1, theField2, value2)
{
	strFeature = "";
	strFeature += "dialogHeight:350px;dialogWidth:600px;center:yes;scroll:yes;status:no;help:no;";
	var vReturn = window.open("MfrSearch.aspx?Field1="+theField1+"&mfrno="+value1+"&Field2="+theField2+"&company="+value2); 
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
	</script>
	</body>
</HTML>
