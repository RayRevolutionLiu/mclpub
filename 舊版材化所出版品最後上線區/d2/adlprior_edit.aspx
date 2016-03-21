<%@ Page language="c#" Codebehind="adlprior_edit.aspx.cs" Src="adlprior_edit.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>版面優先次序 - 修改</TITLE>
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
							版面優先次序 - 修改</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adlprior_edit" method="post" runat="server">
				<!-- 修改 Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="55%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="3">
							<FONT color="#ffffff">修改版面優先次序</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="25%">
							&nbsp;<FONT color="#ff0000">* </FONT>書籍名稱:
						</TD>
						<TD width="40%">
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD width="*" align="right">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>排版優先次序:
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxPriorSeq" runat="server" MaxLength="2" Width="30px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>廣告版面:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlLayoutTypeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>廣告色彩:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlColorCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>廣告篇幅:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddPageSizeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD colspan="3">
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
