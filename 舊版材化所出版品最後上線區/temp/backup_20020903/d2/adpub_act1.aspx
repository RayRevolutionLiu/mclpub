<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="adpub_act1.aspx.cs" Src="adpub_act1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_act1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告落版動作 步驟一 / 美編樣後修正 步驟一</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left">
				<tr>
					<td align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告落版動作 步驟一 / 美編樣後修正 步驟一</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_act1" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE align="center" style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</tr>
					<TR>
						<TD width="*">
							書籍類別：
							<asp:dropdownlist id="ddlBookCode" runat="server">
								<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
								<asp:ListItem Value="01">工材</asp:ListItem>
								<asp:ListItem Value="02">電材</asp:ListItem>
								<asp:ListItem Value="04">電材叢書</asp:ListItem>
								<asp:ListItem Value="05">材料</asp:ListItem>
							</asp:dropdownlist>
							<br>
							<br>
							刊登年月：
							<asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>
							&nbsp; 
							<!-- 查詢按鈕 -->
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>
							<br>
							<font color="gray">(請輸入 4~6碼數字 "年月" 或 "年" 或 "月".
								<br>
								&nbsp;如2002年 1月, 請輸入&nbsp;200201 或 2002 或 01)</font>
							<br>
							<br>
							<!-- 查詢結果顯示 -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD valign="top" align="left" width="50%">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
2. 查詢結果不包含已結案的資料.<br> 	3. 出現結果後, 請接著按下 "<font color="blue"><U>此連結</U></font>" 來繼續進行廣告落版動作!</asp:label>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</BODY>
</HTML>
