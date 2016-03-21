<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RptCustQuery.aspx.cs" src="RptCustQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptCustQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCustQuery</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="RptCustQuery" method="post" runat="server">
			<kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="90%">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										合約處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">&nbsp;合約客戶基本資料清單</FONT>
								</TD>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">查詢條件</TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxContType" runat="server" Text="合約類別："></asp:checkbox><asp:dropdownlist id="ddlContType" runat="server">
										<asp:ListItem Value="01" Selected="True">一般</asp:ListItem>
										<asp:ListItem Value="09">推廣</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxAdDate" runat="server" Text="合約起迄區間："></asp:checkbox><asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">～
									<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
									<asp:label id="lblyyyymmdd" runat="server" ForeColor="#C00000" CssClass="ImportantLabel">(yyyy/mm/dd)</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxClass1" runat="server" Text="材料特性："></asp:checkbox><asp:dropdownlist id="ddlClass1" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxClass2" runat="server" Text="應用產業："></asp:checkbox><asp:dropdownlist id="ddlClass2" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxSrspn" runat="server" Text="承辦業務員："></asp:checkbox><asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxClosed" runat="server" Text="已結案："></asp:checkbox><asp:dropdownlist id="ddlClosed" runat="server">
										<asp:ListItem Value="0" Selected="True">否</asp:ListItem>
										<asp:ListItem Value="1">是</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><FONT face="新細明體"></FONT><br>
									<asp:button id="btnPrint" runat="server" Text="產生合約客戶基本資料清單"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:Literal id="Literal1" runat="server"></asp:Literal></td>
				</tr>
			</table>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
