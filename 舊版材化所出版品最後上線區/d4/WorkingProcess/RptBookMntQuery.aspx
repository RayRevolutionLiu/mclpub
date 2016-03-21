<%@ Page language="c#" Codebehind="RptBookMntQuery.aspx.cs" src="RptBookMntQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptBookMntQuery" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptBookMntQuery</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptBookMntQuery" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										印製份數統計表<IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										<asp:Label id="lblTitle" runat="server"></asp:Label></FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE class="TableColor" cellSpacing="0" cellPadding="2" width="100%">
							<tr class="TableColorHeader">
								<td colSpan="2">查詢條件</td>
							</tr>
							<tr>
								<td align="right" width="150">書籍類別：</td>
								<td><asp:dropdownlist id="ddlBookCode" runat="server">
										<asp:ListItem Value="01" Selected="True">工材雜誌</asp:ListItem>
										<asp:ListItem Value="02">電材雜誌</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right">統計年月：</td>
								<td><asp:textbox id="tbxDate" runat="server" Width="60px"></asp:textbox><font color="maroon" size="2">(如 
										2004/02, 預設值: 當月)<asp:regularexpressionvalidator id="revDate" runat="server" ErrorMessage="年月輸入格式錯誤" ControlToValidate="tbxDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:regularexpressionvalidator></font></td>
							</tr>
							<tr>
								<td align="right">雜誌期數：</td>
								<td><asp:textbox id="tbxBookNo" runat="server" Width="60px"></asp:textbox><FONT color="#800000" size="2">期</FONT></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxContType" runat="server" Text="合約類別："></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlConttp" runat="server">
										<asp:ListItem Value="01" Selected="True">一般</asp:ListItem>
										<asp:ListItem Value="09">推廣</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxMosea" runat="server" Text="郵寄地區："></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlfgMOSea" runat="server">
										<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
										<asp:ListItem Value="1">國外</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxMtpcd" runat="server" Text="郵寄方式："></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlMtpcd" runat="server">
										<asp:ListItem Value="0" Selected="True">大宗郵寄</asp:ListItem>
										<asp:ListItem Value="1">收發室經辦</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxEmpno" runat="server" Text="承辦業務員："></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlEmpNo" runat="server">
										<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td></td>
								<td><asp:button id="btnPrintList" runat="server" Text="產生印製份數統計表"></asp:button></td>
							</tr>
						</TABLE>
						<br>
						<asp:literal id="Literal1" runat="server"></asp:literal><br>
						<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label><br>
						&nbsp;
					</td>
				</tr>
			</TABLE>
			<br>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
