<%@ Page language="c#" Src="mltp_addnew.aspx.cs" Codebehind="mltp_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.mltp_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�H��H�l�H���O��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="mltp_addnew" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									�H��H�l�H���O��ƺ��@ <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�s�W�H��H�l�H���O��� </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			</FONT>
			<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">�s�W�H��H�l�H���O���</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 87px">
						<P align="right">
							�t�ΥN�X�W��:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlmltp_syscd" runat="server"></asp:dropdownlist>
						<FONT face="�s�ө���">&nbsp;<A href="syscd_addnew.aspx" target="">�s�W�t�ΥN�X���</A></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 87px">
						<P align="right">
							�H��H�m�W:
						</P>
					</TD>
					<TD colSpan="3">
						<FONT face="�s�ө���">
							<asp:dropdownlist id="ddlmltp_mlcd" runat="server"></asp:dropdownlist>
							&nbsp;<A href="mailer_addnew.aspx" target="">�s�W�H��H���</A> </FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 87px">
						<P align="right">
							�l�H���O�W��:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlmltp_mltpcd" runat="server"></asp:dropdownlist>
						<FONT face="�s�ө���">&nbsp;<A href="mtp_addnew.aspx" target="">�s�W�l�H���O���</A></FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 87px">
						<P align="right">
						</P>
					</TD>
					<TD style="WIDTH: 102px">
						<FONT face="�s�ө���">
							<P align="left">
								<asp:Label id="Label1" runat="server" ForeColor="Red"></asp:Label>
							</P>
						</FONT>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
						<P align="right">
							<asp:button id="btnAddNew" runat="server" Height="24px" Text="�T�w�s�W"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="���s�W" Height="24px" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
