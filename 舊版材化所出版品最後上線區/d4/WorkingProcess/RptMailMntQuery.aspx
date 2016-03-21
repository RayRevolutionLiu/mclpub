<%@ Page language="c#" Codebehind="RptMailMntQuery.aspx.cs" src="RptMailMntQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptMailMntQuery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptMailMntQuery</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptMailMntQuery" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										郵寄本數統計表</FONT>
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
										<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right">贈書年月區間：</td>
								<td><asp:textbox id="tbxSDate" runat="server" Width="60px"></asp:textbox>~<asp:textbox id="tbxEDate" runat="server" Width="60px"></asp:textbox><font color="maroon" size="2">(如 
										2003/10, 預設值: 當月)<asp:regularexpressionvalidator id="revSDate" runat="server" ErrorMessage="起始年月輸入格式錯誤" ControlToValidate="tbxSDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="revEDate" runat="server" ErrorMessage="結束年月輸入格式錯誤" ControlToValidate="tbxEDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:regularexpressionvalidator></font></td>
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
								<td align="right"><asp:checkbox id="cbxMtpcd" runat="server" Text="郵寄類別："></asp:checkbox></td>
								<td><asp:dropdownlist id="ddlMtpcd" runat="server">
										<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
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
								<td><asp:button id="btnPrintList" runat="server" Text="產生郵寄本數統計表"></asp:button></td>
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
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
