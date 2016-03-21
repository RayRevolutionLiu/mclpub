<%@ Page language="c#" Codebehind="or_addnew.aspx.cs" Src="or_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.or_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>雜誌收件人 - 新增</TITLE>
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
							雜誌收件人 - 新增</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="or_addnew" method="post" runat="server">
				<!-- 新增 Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="80%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">新增雜誌收件人</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="35%">
							&nbsp;<FONT color="#ff0000">* </FONT>系統代碼 /&nbsp;合約書編號 :
						</TD>
						<TD width="50%">
							<asp:textbox id="or_syscd" runat="server" Width="25px" MaxLength="2" ForeColor="Gray" ReadOnly="True">C2</asp:textbox>
							&nbsp;
							<asp:textbox id="or_contno" runat="server" Width="65px" MaxLength="6"></asp:textbox>
							<FONT color="#8b4513">(灰色字代表不允許修改)</FONT>&nbsp;
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD align="right" width="*">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT><FONT color="#000000">序號 / 姓名 / 職稱: </FONT>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="or_oritem" runat="server" Width="25px" MaxLength="2"></asp:textbox>
							&nbsp;&nbsp;
							<asp:textbox id="or_nm" runat="server" Width="65px" MaxLength="30"></asp:textbox>
							&nbsp;
							<asp:textbox id="or_jbti" runat="server" Width="60px" MaxLength="12"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>電話 / 傳真:
						</TD>
						<TD colSpan="2">
							<asp:textbox id="or_tel" runat="server" Width="85px" MaxLength="30"></asp:textbox>
							&nbsp;
							<asp:textbox id="or_fax" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;手機:
						</TD>
						<TD colSpan="2">
							<asp:textbox id="or_cell" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;Email:
						</TD>
						<TD colSpan="2">
							<asp:textbox id="or_email" runat="server" Width="160px" MaxLength="80"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>郵遞區號 / 地址:
						</TD>
						<TD colSpan="2">
							<asp:textbox id="or_zip" runat="server" Width="30px" MaxLength="5"></asp:textbox>
							&nbsp;&nbsp;
							<asp:textbox id="or_addr" runat="server" Width="300px" MaxLength="120"></asp:textbox>
							&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>郵寄類別 / 海外郵寄:
						</TD>
						<TD colSpan="2">
							<asp:DropDownList id="ddlORMailTypeCode" runat="server" AutoPostBack="True"></asp:DropDownList>
							&nbsp;/&nbsp;&nbsp;<asp:textbox id="or_fgmoseanm" runat="server" Width="25px" MaxLength="1" ReadOnly="True" ForeColor="Gray"></asp:textbox>
							&nbsp;<INPUT id="or_fgmosea" style="WIDTH: 20px" type="hidden" size="1" name="or_fgmosea" runat="server">&nbsp;
							<FONT color="#8b4513">(海外郵寄會根據郵寄類別而即時自動變更!)</FONT>&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;有登本數 / 未登本數:
						</TD>
						<TD colSpan="2">
							<asp:textbox id="or_pubcnt" runat="server" Width="30px" MaxLength="4"></asp:textbox>
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="or_unpubcnt" runat="server" Width="30px" MaxLength="4"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right" colSpan="3">
							<asp:button id="btnUpdate" runat="server" Text="確定新增" Height="24px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="放棄新增" Height="24px" CausesValidation="False"></asp:button>
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</body>
</HTML>
