<%@ Page language="c#" Codebehind="cust_edit.aspx.cs" src="cust_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.cust_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�Ȥ��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function pick_date(theField)
		{
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vReturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			if(vReturn)
				window.document.all(theField).value=vReturn;
				return true;
		}
		</script>
	</HEAD>
	<body>
		<form id="cust_addnew" method="post" runat="server">
			<FONT face="�s�ө���">
				<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
					<TR>
						<TD align="left" width="100%">
							<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�@�P�ɮ�
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �Ȥ��ƺ��@
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �ק�Ȥ���
							</FONT>
						</TD>
					</TR>
				</TABLE>
				<br>
				<TABLE cellSpacing="1" cellPadding="3" width="95%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="5">
							<FONT color="#ffffff">�ק�Ȥ���</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								<FONT color="#ff0000">* </FONT>�Ȥ�s��:
							</P>
						</TD>
						<TD style="WIDTH: 255px">
							<asp:textbox id="cust_custno" runat="server" Width="46px" MaxLength="6"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="�������!"
								ControlToValidate="cust_custno"></asp:requiredfieldvalidator>
							<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" Display="Dynamic" ErrorMessage="�п�J 6 ��Ʀr!"
								ControlToValidate="cust_custno" ValidationExpression="[0-9]{6}"></asp:regularexpressionvalidator>
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD>
							<P align="right">
								�«Ȥ�s��:
							</P>
						</TD>
						<TD style="WIDTH: 124px">
							<asp:textbox id="cust_oldcustno" runat="server" Width="42px" MaxLength="5"></asp:textbox>
						</TD>
						<TD>
							<FONT color="#ff0000">
								<P align="right">
									*&nbsp;<FONT color="#8b4513">��������� &nbsp;</FONT>
							</FONT></P>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								<FONT color="#ff0000">* </FONT>�Ȥ�m�W:
							</P>
						</TD>
						<TD style="WIDTH: 255px">
							<asp:textbox id="cust_nm" runat="server" MaxLength="30"></asp:textbox>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ErrorMessage="�������!"
								ControlToValidate="cust_nm"></asp:requiredfieldvalidator>
						</TD>
						<TD style="WIDTH: 81px">
							<P align="right">
								�Ȥ�¾��:
							</P>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="cust_jbti" runat="server" Width="100px" MaxLength="12"></asp:textbox>
							<FONT color="#696969">(��:�Y�L¾�ٮɽп�J"����"��"�p�j")</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								�t�ӵo�����Y:
							</P>
						</TD>
						<TD style="WIDTH: 255px">
							<asp:dropdownlist id="ddlcust_inm" runat="server" AutoPostBack="True"></asp:dropdownlist>
						</TD>
						<TD style="WIDTH: 81px">
							<P align="right">
								�t�ӲΤ@�s��:
							</P>
						</TD>
						<TD colSpan="2">
							<asp:label id="cust_mfrno" runat="server" ForeColor="#C00000"></asp:label>
							&nbsp; <A href="mfr_addnew.aspx" target="">�s�W�t�Ӹ��</A>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								�p���q��:
							</P>
						</TD>
						<TD style="WIDTH: 280px">
							<asp:textbox id="cust_tel" runat="server" MaxLength="30"></asp:textbox>
							<FONT color="#696969">(�d��:03-1234567#123)</FONT>
						</TD>
						<TD style="WIDTH: 81px">
							<P align="right">
								�ǯu���X:
							</P>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="cust_fax" runat="server" MaxLength="30"></asp:textbox>
							<FONT color="#696969">(�d��:03-1234567#123)</FONT>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								������X:
							</P>
						</TD>
						<TD style="WIDTH: 255px">
							<asp:textbox id="cust_cell" runat="server" MaxLength="30"></asp:textbox>
							<FONT color="#696969">(�d��:0911-123456)</FONT>
						</TD>
						<TD style="WIDTH: 81px">
							<P align="right">
								Email �a�}:
							</P>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="cust_email" runat="server" Width="200px" MaxLength="80"></asp:textbox>
							<asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ErrorMessage="�榡���~!" ControlToValidate="cust_email"
								ValidationExpression=".{1,}@.{3,}"></asp:regularexpressionvalidator>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								���U���:
							</P>
						</TD>
						<TD style="WIDTH: 255px">
							<asp:textbox id="cust_regdate" runat="server" Width="60px" MaxLength="8"></asp:textbox>
							<IMG class="ico" title="���" onclick="pick_date(cust_regdate.name)" src="../images/calendar01.gif">
							<FONT color="#696969">(�d��:20020101)</FONT>
							<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" Display="Dynamic" ErrorMessage="�Ш̽d�Ү榡��J!"
								ControlToValidate="cust_regdate" ValidationExpression="[0-9]{8}"></asp:regularexpressionvalidator>
						</TD>
						<TD style="WIDTH: 81px">
							<P align="right">
								�ק���:
							</P>
						</TD>
						<TD colSpan="2">
							<asp:label id="cust_moddate" runat="server" ForeColor="#C00000"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">�~�ȤH��</P>
						</TD>
						<TD style="WIDTH: 255px">
							<asp:DropDownList id="ddlEmpNo" runat="server"></asp:DropDownList></TD>
						<TD style="WIDTH: 81px"></TD>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								�Ȥ���N�X:
							</P>
						</TD>
						<TD vAlign="top" colSpan="4">
							<asp:checkboxlist id="cblcust_itpcd" tabIndex="1" runat="server" Width="98%" BorderStyle="Inset" BorderWidth="1px"
								RepeatColumns="6" RepeatDirection="Horizontal" BackColor="#E2EAFC"></asp:checkboxlist>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								�Ȥ���~�N�X:
							</P>
						</TD>
						<TD colSpan="4">
							<asp:checkboxlist id="cblcust_btpcd" tabIndex="1" runat="server" Width="98%" BorderStyle="Inset" BorderWidth="1px"
								RepeatColumns="6" RepeatDirection="Horizontal" BackColor="#E2EAFC"></asp:checkboxlist>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 83px">
							<P align="right">
								�Ȥ�\Ū�N�X:
							</P>
						</TD>
						<TD colSpan="4">
							<asp:checkboxlist id="cblcust_rtpcd" tabIndex="1" runat="server" Width="98%" BorderStyle="Inset" BorderWidth="1px"
								RepeatColumns="6" RepeatDirection="Horizontal" BackColor="#E2EAFC"></asp:checkboxlist>
						</TD>
					</TR>
					<TR>
						<TD colSpan="5">
							<P align="right">
								<asp:button id="btnUpdate" runat="server" Height="24px" Text="�T�w��s"></asp:button>
								<asp:button id="btnReturnHome" runat="server" Height="24px" Text="���ק�" CausesValidation="False"></asp:button>
							</P>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
