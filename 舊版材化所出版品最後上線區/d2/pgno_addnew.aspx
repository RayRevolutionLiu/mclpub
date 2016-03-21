<%@ Page language="c#" Codebehind="pgno_addnew.aspx.cs" Src="pgno_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.pgno_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>內頁起始頁碼 - 新增</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header -->
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle" bgColor="#e7ebff">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							相關維護區 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							內頁起始頁碼 - 新增</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="pgno_addnew" method="post" runat="server">
				<!-- 新增 Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">新增內頁起始頁碼</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="30%">
							&nbsp;<FONT color="#ff0000">* </FONT>書籍類別:
						</TD>
						<TD width="20%">
							<asp:DropDownList id="ddlBkcd" runat="server"></asp:DropDownList>
						</TD>
						<TD colSpan="3" width="*" align="right">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>內頁起始頁碼:
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxStartPageNo" runat="server" MaxLength="3" Width="30px"></asp:textbox>&nbsp;<FONT color="#8b4513">(預設值為 
								4)</FONT>
							<asp:requiredfieldvalidator id="rev1" runat="server" Width="114px" ErrorMessage="起始頁碼為必填欄位!" ControlToValidate="tbxStartPageNo" Display="Dynamic"></asp:requiredfieldvalidator>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;
						</TD>
						<TD>
							&nbsp;
						</TD>
						<TD align="right">
							&nbsp;
						</TD>
						<TD>
							<asp:button id="btnUpdate" runat="server" Text="確定新增" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="放棄新增" Height="24px" CausesValidation="False"></asp:button>
						</TD>
					</TR>
				</TABLE>
				<asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label>
				<asp:Literal id="Literal1" runat="server"></asp:Literal>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</body>
</HTML>
