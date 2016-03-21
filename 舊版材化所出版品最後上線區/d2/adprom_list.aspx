<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="adprom_list.aspx.cs" Src="adprom_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub_d2.adprom_list" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告推廣戶清單</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
		<!-- Javascript -->
	</HEAD>
	<BODY>
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
							廣告推廣戶清單</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form ID="adprom_list" name="adprom_list" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</tr>
					<TR>
						<TD>
							合約類別：
							<asp:DropDownList id="ddlConttp" runat="server">
								<asp:ListItem Value="01">一般合約</asp:ListItem>
								<asp:ListItem Value="09" Selected="True">推廣合約</asp:ListItem>
							</asp:DropDownList><br>
							<br>
							書籍類別：
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>&nbsp; 
							<!-- 查詢按鈕 -->
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;&nbsp;
							<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton>
							<br>
							<br>
							<!-- 查詢結果顯示 -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD vAlign="top" align="left">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
2. 查詢結果不包含<font color='Red'>已結案/已註銷</font>的資料.<br> 	3. 出現結果後, 請再按下 "<font color="blue"><U>此連結</U></font>" 來繼續!</asp:label>
							<asp:TextBox id="tbxLoginEmpNo" runat="server" Visible="False" Width="50px" Font-Size="X-Small"></asp:TextBox>
							<asp:TextBox id="tbxLoginEmpCName" runat="server" Visible="False" Width="60px" Font-Size="X-Small"></asp:TextBox>
						</TD>
					</TR>
					<TR>
						<TD align="middle" bgColor="#ffffff" colSpan="2">&nbsp;
							<asp:Literal id="Literal1" runat="server"></asp:Literal>
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
