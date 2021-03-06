<%@ Page language="c#" Codebehind="adpgsize_edit.aspx.cs" Src="adpgsize_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpgsize_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廣告篇幅 - 修改</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
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
							廣告篇幅 - 修改</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpgsize_edit" method="post" runat="server">
				<!-- 修改 Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">修改廣告篇幅</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="30%">
							&nbsp;<FONT color="#ff0000">* </FONT>廣告篇幅代碼:
						</TD>
						<TD width="20%">
							<asp:textbox id="pgs_pgscd" runat="server" MaxLength="2" Width="25px"></asp:textbox>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ControlToValidate="pgs_pgscd" ErrorMessage="必填欄位!"></asp:requiredfieldvalidator>
							<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" Display="Dynamic" ControlToValidate="pgs_pgscd" ErrorMessage="請輸入 2 位數字!" ValidationExpression="[0-9]{2}"></asp:regularexpressionvalidator>
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD colSpan="3" width="*" align="right">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>廣告篇幅名稱:
						</TD>
						<TD colSpan="3">
							<asp:textbox id="pgs_nm" runat="server" MaxLength="10" Width="142px"></asp:textbox>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ControlToValidate="pgs_nm" ErrorMessage="必填欄位!"></asp:requiredfieldvalidator>
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
							<asp:button id="btnUpdate" runat="server" Text="確定更新" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="放棄修改" Height="24px" CausesValidation="False"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</body>
</HTML>
