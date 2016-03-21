<%@ Page language="c#" Codebehind="adpub_list.aspx.cs" Src="adpub_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_list" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告落版清單 步驟一</title>
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
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告落版清單 步驟一</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form ID="adpub_list" name="adpub_list" method="post" runat="server">
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
								<asp:textbox id="tbxPubDate" runat="server" Width="60px" MaxLength="7"></asp:textbox><br>
								<font color="gray">(請輸入 6碼年月,&nbsp;如2002年 1月, 請輸入&nbsp;2002/01)</font>
								<br>
								<asp:checkbox id="cbx0" runat="server"></asp:checkbox>
								承辦業務員：
								<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>&nbsp;&nbsp; 
								<!-- 查詢按鈕 -->
								<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;&nbsp;
								<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton>
								<br>
								<br>
								<!-- 查詢結果顯示 -->
								<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
							</TD>
							<TD vAlign="top" align="left" width="50%">
								<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
											2. 出現結果後, 若有錯誤資料, 將要求先修正; <br>&nbsp;&nbsp;&nbsp;&nbsp;若無錯誤落版資料, 請再按下 "<font color="blue">
										<U>此連結</U></font>" 來繼續!</asp:label>
								<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
							</TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2">
								&nbsp;<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</BODY>
</HTML>
