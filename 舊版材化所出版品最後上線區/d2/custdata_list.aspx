<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="custdata_list.aspx.cs" Src="custdata_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.custdata_list" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>客戶基本資料清單</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
		<!-- Javascript -->
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							推廣戶處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							客戶基本資料清單</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form ID="custdata_list" name="custdata_list" method="post" runat="server">
				<!-- 篩選條件, 傳變數 -->
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</tr>
					<TR>
						<TD>
							<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
							客戶編號範圍：
							<asp:TextBox id="tbxCustNoQ1" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
							～
							<asp:TextBox id="tbxCustNoQ2" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
							<br>
							<asp:CheckBox id="cbx2" runat="server"></asp:CheckBox>
							客戶(電話號碼)區域碼：
							<asp:TextBox id="tbxTelAC" runat="server" Width="40px" MaxLength="3"></asp:TextBox>
							<br>
							<asp:CheckBox id="cbx3" runat="server"></asp:CheckBox>
							客戶領域代碼：
							<asp:DropDownList id="ddlItpcd" runat="server"></asp:DropDownList>
							<br>
							<asp:CheckBox id="cbx4" runat="server"></asp:CheckBox>
							客戶營業代碼：
							<asp:DropDownList id="ddlBtpcd" runat="server"></asp:DropDownList>&nbsp;&nbsp; 
							<!-- 查詢按鈕 -->
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;&nbsp;
							<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton>
							<br>
							<!-- 查詢結果顯示 -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD vAlign="top" align="left">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">* 請篩選資料, 然後按下 "查詢".<br><br>
							</asp:label>
						</TD>
					</TR>
					<TR>
						<TD align="middle" bgColor="#ffffff" colSpan="2">
							<asp:Literal id="Literal1" runat="server"></asp:Literal>
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</BODY>
</HTML>
