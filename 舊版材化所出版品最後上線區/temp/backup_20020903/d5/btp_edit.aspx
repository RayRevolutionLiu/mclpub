<%@ Page language="c#" Src="btp_edit.aspx.cs" Codebehind="btp_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.btp_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��~�N�X��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="btp_edit" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									��~�N�X��ƺ��@ <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�ק���~�N�X��� </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="60%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">�ק���~�N�X���</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 88px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> ��~�N�X:
						</P>
					</TD>
					<TD style="WIDTH: 140px">
						<asp:textbox id="btp_btpcd" runat="server" MaxLength="2" Width="25px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ControlToValidate="btp_btpcd" ErrorMessage="�������!"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" Display="Dynamic" ControlToValidate="btp_btpcd" ErrorMessage="�п�J 2 ��Ʀr!" ValidationExpression="[0-9]{2}"></asp:regularexpressionvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD colSpan="3">
						<P align="right">
							<FONT color="#ff0000">*&nbsp;<FONT color="#8b4513">��������� &nbsp;</FONT></FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 88px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> ��~�N�X�W��:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="btp_nm" runat="server" MaxLength="12" Width="168px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ControlToValidate="btp_nm" ErrorMessage="�������!"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 88px">
					</TD>
					<TD style="WIDTH: 140px">
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
