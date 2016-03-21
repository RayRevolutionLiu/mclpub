<%@ Page language="c#" Codebehind="getad.aspx.cs" Src="getad.aspx.cs"  AutoEventWireup="false" Inherits="MRLPub_d2.getad" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>催稿單</title>
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
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="center">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							催稿處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							催稿單</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="getad" name="getad" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</tr>
					<TR>
						<TD>
							書籍類別：&nbsp;
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
							&nbsp;
							<br>
							<br>
							催稿年月：
							<asp:textbox id="tbxyyyymm" runat="server" MaxLength="7" Width="60px"></asp:textbox>
							&nbsp;
							<br>
							<font color="gray">(請輸入 6碼年月, 如2002年 1月, 請輸入 2002/01)</font>
							<br>
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
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label><FONT face="新細明體"></FONT>
						</TD>
						<TD vAlign="top" align="left">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
2. 查詢結果不包含<font color='Red'>已結案/已註銷</font>的資料.<br><br>
							</asp:label>
							<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
							<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
						</TD>
					</TR>
					<TR>
						<TD align="center" bgColor="#ffffff" colSpan="2">
							&nbsp;
							<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}"
								ControlToValidate="tbxyyyymm" ErrorMessage="'催稿年月' 請依格式填入(請參旁邊文字說明)!!!"></asp:RegularExpressionValidator>
							<asp:Literal id="Literal1" runat="server"></asp:Literal>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer><FONT face="新細明體"></FONT>
		</center>
	</BODY>
</HTML>
