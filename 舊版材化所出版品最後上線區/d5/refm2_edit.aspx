<%@ Page language="c#" Src="refm2_edit.aspx.cs" Codebehind="refm2_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.refm2_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��SAP�o���K�n�D�ɸ�ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="refm_edit" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									�� SAP �o���K�n�ɸ�ƺ��@ <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�ק��� SAP �o���K�n�ɸ�� </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="77%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">�ק��� SAP �o���K�n�ɸ��</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> �t�ΥN�X�W��:
						</P>
					</TD>
					<TD style="WIDTH: 285px">
						<asp:dropdownlist id="ddlrm_syscd" runat="server"></asp:dropdownlist>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD>
						<P align="right">
							<FONT color="#ff0033">*</FONT>&nbsp;<FONT color="#8b4513">���������&nbsp;&nbsp;</FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> �o���ƥ�:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="rm_remark" runat="server" MaxLength="25" Width="250px"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="rm_remark" ErrorMessage="�������!" Display="Dynamic"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�~�ȳ����N��:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="rm_deptcd" runat="server" Width="50px" MaxLength="5"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�o���ɤ��`�b���:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="rm_accddr" runat="server" MaxLength="7" Width="54px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�o�����ӫ~�W:
						</P>
					</TD>
					<TD style="WIDTH: 285px" colSpan="2">
						<asp:textbox id="rm_idescr" runat="server" MaxLength="40" Width="270px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="right">
							�o�����ӳ��:
						</P>
					</TD>
					<TD colSpan="2">
						<P align="left">
							<asp:textbox id="rm_iunit" runat="server" Width="50px" MaxLength="3"></asp:textbox>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�o�����ӳƵ�:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:textbox id="rm_iremark" runat="server" Width="250px" MaxLength="8"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
					<TD colSpan="2">
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
