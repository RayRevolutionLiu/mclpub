<%@ Page language="c#" Src="book_addnew.aspx.cs" Codebehind="book_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.book_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���y��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="book_addnew" method="post" runat="server">
			<P>
				<FONT title="" face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�@�P�ɮ�
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> ���y��ƺ��@
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �s�W���y���
								</FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">�s�W���y���</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 74px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> ���y�N�X:
						</P>
					</TD>
					<TD style="WIDTH: 135px">
						<asp:textbox id="bk_bkcd" runat="server" MaxLength="2" Width="25px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ControlToValidate="bk_bkcd" ErrorMessage="�������!"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" Display="Dynamic" ControlToValidate="bk_bkcd" ErrorMessage="�п�J 2 ��Ʀr!" ValidationExpression="[0-9]{2}"></asp:regularexpressionvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD colSpan="3">
						<P align="right">
							<FONT color="#ff0000">*&nbsp;<FONT color="#8b4513">��������� &nbsp;</FONT></FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 74px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> ���y�W��:
						</P>
					</TD>
					<TD colSpan="3">
						<asp:textbox id="bk_nm" runat="server" MaxLength="10" Width="142px"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ControlToValidate="bk_nm" ErrorMessage="�������!"></asp:requiredfieldvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 74px">
					</TD>
					<TD style="WIDTH: 135px">
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right">
						</P>
					</TD>
					<TD>
						<P align="right">
							<asp:button id="btnAddNew" runat="server" Height="24px" Text="�T�w�s�W"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Height="24px" Text="���s�W" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
