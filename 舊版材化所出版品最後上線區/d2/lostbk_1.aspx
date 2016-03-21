<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="lostbk_1.aspx.cs" Src="lostbk_1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk_1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>缺書登錄</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<!-- 目前所在位置 -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							缺書處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							缺書登錄</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form-->
			<form id="lostbk_1" method="post" runat="server">
				<TABLE style="WIDTH: 80%" cellSpacing="0" cellPadding="4" align="center" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">合約書資料&nbsp;
								<asp:Label id="lblMessage" runat="server" ForeColor="Yellow"></asp:Label>
							</FONT>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right" width="20%">
							合約書編號：
						</TD>
						<TD class="cssData" width="*">
							<asp:label id="lblContNo" ForeColor="Maroon" Runat="server"></asp:label>
							&nbsp;&nbsp; <font size="2" color="gray">(<IMG class="ico" id="imgContDetail" alt="顯示合約及落版資料" src="../images/edit.gif" width="18" border="0" onclick="javascript:window.open('ContPubFm_show.aspx?custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblContNo.Text); %>', '_new', 'Height=470, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')">顯示合約及落版資料)</font>
						</TD>
						<TD class="cssTitle" align="right" width="20%">
							合約類別：
						</TD>
						<TD class="cssData" width="*">
							<asp:label id="lblConttp" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" align="right">
							合約起迄：
						</TD>
						<TD class="cssData">
							<asp:label id="lblContsdate" runat="server" ForeColor="Maroon"></asp:label>
							~<asp:label id="lblContedate" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
						<TD class="cssTitle" align="right">
							結案／已註銷：
						</TD>
						<TD class="cssData">
							<asp:label id="lblfgClosed" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;／&nbsp;
							<asp:label id="lblfgCancel" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">客戶資料</font>
						</td>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							客戶編號：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustNo" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
						<TD align="right">
							客戶姓名：
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							公司名稱：
						</TD>
						<TD class="cssData" colSpan="3">
							<asp:label id="lblMfrIName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<TD class="cssTitle" colSpan="4">
							<font color="white">雜誌收件人資料</font>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							收件人姓名：
						</TD>
						<TD class="cssData">
							<asp:label id="lblORName" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
						<TD class="cssTitle" align="right">
							郵寄方式：
						</TD>
						<TD class="cssData">
							<asp:Label id="lblORmtpcd" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
					</TR>
					<TR align="left">
						<TD align="right">
							收件地址：
						</TD>
						<TD class="cssData" colSpan="3">
							<asp:label id="lblORZipcode" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;&nbsp;
							<asp:label id="lblORAddr" ForeColor="Maroon" Runat="server"></asp:label>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">缺書資料</font>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							缺書序號：
						</TD>
						<TD class="cssData">
							<asp:label id="lblLostSeq" runat="server" ForeColor="Blue"></asp:label>
						</TD>
						<TD class="cssTitle" align="right">
							缺書日期：
						</TD>
						<TD class="cssData">
							<asp:label id="lblLostDate" runat="server" ForeColor="Blue"></asp:label>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							缺書內容：
						</TD>
						<TD class="cssData" colSpan="3">
							<TEXTAREA id="textarea1" name="textarea1" rows="3" cols="50" runat="server" tabindex="1"></TEXTAREA>
							<br>
							<font size="2" color="darkred">(最多輸入25個中文字!)</font>
							<br>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							缺書原因：
						</TD>
						<TD class="cssData" colSpan="3">
							<TEXTAREA id="textarea2" name="textarea2" rows="2" cols="50" runat="server" tabindex="2"></TEXTAREA>
							<br>
							<font size="2" color="darkred">(最多輸入15個中文字!)</font>
							<br>
						</TD>
					</TR>
					<TR align="left">
						<TD class="cssTitle" align="right">
							寄書狀態：
						</TD>
						<TD class="cssData" colSpan="3">
							<asp:dropdownlist id="ddlSendFlag" runat="server" tabindex="3">
								<asp:ListItem Value="Y" Selected="True">可寄出</asp:ListItem>
								<asp:ListItem Value="N">目前暫時無法寄出</asp:ListItem>
								<asp:ListItem Value="D">不處理</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
				</TABLE>
				<br>
				<asp:button id="btnModify" runat="server" Text="資料錯誤,修改合約書" tabindex="6"></asp:button>
				&nbsp;&nbsp;
				<asp:button id="btnOK" runat="server" Text="確定新增缺書資料" tabindex="4"></asp:button>
				&nbsp;&nbsp;
				<asp:button id="btnCancel" runat="server" Text="取消回前頁" tabindex="5"></asp:button>
			</form>
			&nbsp; 
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
