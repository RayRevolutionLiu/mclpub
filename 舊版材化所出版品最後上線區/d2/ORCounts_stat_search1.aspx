<%@ Page language="c#" Codebehind="ORCounts_stat_search1.aspx.cs" Src="ORCounts_stat_search1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORCounts_stat_search1" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>郵寄本數統計表 當月刊登 步驟一: 搜尋</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							統計表 當月刊登 步驟一: 搜尋<IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							郵寄本數統計表</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="ORCounts_stat_search1" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<TBODY>
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
								<asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(如 
									2002/08, 預設值: 當月)</font><br>
								<br>
								<asp:checkbox id="cbx0" runat="server"></asp:checkbox>
								<asp:label id="lblConttp" runat="server" Font-Size="X-Small">合約類別：</asp:label>
								<asp:dropdownlist id="ddlConttp" runat="server">
									<asp:ListItem Value="01" Selected="True">一般</asp:ListItem>
									<asp:ListItem Value="09">推廣</asp:ListItem>
								</asp:dropdownlist><br>
								<asp:checkbox id="cbx1" runat="server"></asp:checkbox>
								<asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">郵寄地區：</asp:label>
								<asp:dropdownlist id="ddlfgMOSea" runat="server">
									<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
									<asp:ListItem Value="1">國外</asp:ListItem>
								</asp:dropdownlist><br>
								<!-- 查詢按鈕 -->
								<asp:checkbox id="cbx2" runat="server"></asp:checkbox>
								<asp:label id="lblMtpcd" runat="server" Font-Size="X-Small">郵寄類別：</asp:label>
								<asp:dropdownlist id="ddlMtpcd" runat="server"></asp:dropdownlist>
								<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;
								<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton>
								<br>
								<!-- 查詢結果顯示 -->
								<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
							</TD>
							<TD vAlign="top" align="left" width="50%">
								<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
2. 查詢結果不包含 '<font color='Red'>已結案/已註銷</font>' 之合約.<br>3. 出現結果後, 請再按下 "<font color="blue"><U>此連結</U></font>" 來繼續!</asp:label>
								<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
							</TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2">&nbsp;
								<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxPubDate" ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!"></asp:RegularExpressionValidator>
								<asp:Literal id="Literal1" runat="server"></asp:Literal>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
