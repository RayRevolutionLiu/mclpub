<%@ Page language="c#" Src="srspn_edit.aspx.cs" Codebehind="srspn_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.srspn_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�޲z�~�ȤH����ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="srspn_edit" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									�޲z�~�ȤH����ƺ��@ <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�ק�޲z�~�ȤH����� </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="77%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">�ק�޲z�~�ȤH�����</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> �~�ȤH���u��:
						</P>
					</TD>
					<TD style="WIDTH: 285px">
						<asp:textbox id="srspn_empno" runat="server" Width="46px" MaxLength="6"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="srspn_empno" ErrorMessage="�������!" Display="Dynamic"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="srspn_empno" ErrorMessage="�п�J 6 ��Ʀr!" Display="Dynamic" ValidationExpression="[0-9]{6}"></asp:regularexpressionvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD colSpan="3">
						<P align="right">
							<FONT color="#ff0033">*</FONT>&nbsp;<FONT color="#8b4513">���������&nbsp;&nbsp;</FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�~�ȤH���m�W:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="srspn_cname" runat="server" Width="142px" MaxLength="10"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�~�ȤH���q��:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="srspn_tel" runat="server" Width="100px" MaxLength="12"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> �~�ȤH���v���O:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlsrspn_atype" runat="server">
							<asp:ListItem Value="A">A - ���ε{���}�o��</asp:ListItem>
							<asp:ListItem Value="B">B - �D�n�~�ȭt�d�H</asp:ListItem>
							<asp:ListItem Value="C">C - ���n�~�ȭt�d�H</asp:ListItem>
							<asp:ListItem Value="D">D - �|�p�H��</asp:ListItem>
						</asp:dropdownlist>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�~�ȤH�����O:
						</P>
					</TD>
					<TD style="WIDTH: 285px">
						<asp:dropdownlist id="ddlsrspn_orgcd" runat="server"></asp:dropdownlist>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�~�ȤH�������O:
						</P>
					</TD>
					<TD style="WIDTH: 285px">
						<asp:textbox id="srspn_deptcd" runat="server" Width="50px" MaxLength="5"></asp:textbox>
					</TD>
					<TD style="WIDTH: 1px">
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�~�ȤH�����U��:
						</P>
					</TD>
					<TD style="WIDTH: 282px" colSpan="2">
						<asp:textbox id="srspn_date" runat="server" Width="60px" MaxLength="8"></asp:textbox>
						<FONT color="#696969">(�d��:20020101)</FONT>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="srspn_date" ErrorMessage="�Ш̽d�Ү榡��J!" Display="Dynamic" ValidationExpression="[0-9]{8}"></asp:regularexpressionvalidator>
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> �~�ȤH���K�X:
						</P>
					</TD>
					<TD style="WIDTH: 282px" colSpan="2">
						<asp:textbox id="srspn_pwd" runat="server" MaxLength="14" Width="120px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ErrorMessage="�������!" ControlToValidate="srspn_pwd"></asp:requiredfieldvalidator>
					</TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
						</P>
					</TD>
					<TD style="WIDTH: 285px">
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
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
