<%@ Page language="c#" Src="refd2_edit.aspx.cs" Codebehind="refd2_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.refd2_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��SAP�ǲ����ӺK�n�ɸ�ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="refd_edit" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									�� SAP �ǲ��K�n�ɸ�ƺ��@ <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�ק��� SAP �ǲ��K�n�ɸ�� </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="77%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">�ק��� SAP �ǲ��K�n�ɸ��</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							<FONT color="#ff0033">*</FONT> �t�ΥN�X�W��:
						</P>
					</TD>
					<TD style="WIDTH: 249px">
						<asp:dropdownlist id="ddlrd_syscd" runat="server"></asp:dropdownlist>
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
							<FONT color="#ff0033">*</FONT> �p���N��:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlrd_projno" runat="server"></asp:dropdownlist>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							��������:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="rd_costctr" runat="server" Width="67px" MaxLength="7"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�ǲ��U���`�b���:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="rd_accdcr" runat="server" MaxLength="7" Width="54px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 111px">
						<P align="right">
							�ǲ��K�n:
						</P>
					</TD>
					<TD style="WIDTH: 285px" colSpan="2">
						<asp:textbox id="rd_descr" runat="server" MaxLength="50" Width="270px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
					<TD style="WIDTH: 249px">
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
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
