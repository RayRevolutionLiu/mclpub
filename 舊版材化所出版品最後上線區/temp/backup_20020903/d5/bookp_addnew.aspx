<%@ Page language="c#" Src="bookp_addnew.aspx.cs" Codebehind="bookp_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.bookp_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���y���O��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="bookp_addnew" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									���y���O��ƺ��@ <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�s�W���y���O��� </FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4">
						<FONT color="#ffffff">�s�W���y���O���</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> ���y�W��:
						</P>
					</TD>
					<TD style="WIDTH: 178px">
						<asp:dropdownlist id="ddlbkp_bkcd" runat="server"></asp:dropdownlist>
						&nbsp;<A href="book_addnew.aspx" target="_top">�s�W���y���</A>
					</TD>
					<TD>
						<P align="right">
							&nbsp;<FONT color="#ff0000">*&nbsp;<FONT color="#8b4513">��������� </FONT></FONT>&nbsp;
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> ���y�X���~��:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:textbox id="bkp_date" runat="server" Width="70px" MaxLength="6"></asp:textbox>
						<FONT color="#696969">(�d��: 200201)</FONT>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="�������!" ControlToValidate="bkp_date" Display="Dynamic"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="�Ш̽d�Ү榡��J!" ControlToValidate="bkp_date" Display="Dynamic" ValidationExpression="[0-9]{6}"></asp:regularexpressionvalidator>
						<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">
							<FONT color="#ff0000">*</FONT> ���y���O:
						</P>
					</TD>
					<TD colSpan="2">
						<asp:textbox id="bkp_pno" runat="server" Width="50px" MaxLength="4"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="�������!" ControlToValidate="bkp_pno" Display="Dynamic"></asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ErrorMessage="�u���g�Ʀr!" ControlToValidate="bkp_pno" Display="Dynamic" ValidationExpression="[0-9]{1,4}"></asp:regularexpressionvalidator>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
					</TD>
					<TD colSpan="2">
						<P align="right">
							<asp:button id="btnAddNew" runat="server" Text="�T�w�s�W" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Height="24px" Text="���s�W" CausesValidation="False"></asp:button>
						</P>
					</TD>
				</TR>
			</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
