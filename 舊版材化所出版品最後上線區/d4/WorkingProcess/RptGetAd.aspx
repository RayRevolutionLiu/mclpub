<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RptGetAd.aspx.cs" src="RptGetAd.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptGetAd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptGetAd</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptGetAd" method="post" runat="server">
			<kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										催稿處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										催稿單</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="80%" align="center" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">查詢條件</TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD>催稿期間：<asp:textbox id="tbxSDate" runat="server" Width="80px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">～
									<asp:textbox id="tbxEDate" runat="server" Width="80px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
									<asp:label id="lblyyyymmdd" runat="server" ForeColor="#C04000">(yyyy/mm/dd)</asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><asp:checkbox id="cbxAddAdr" runat="server" Text="列印落版明細"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><asp:button id="btnGo" runat="server" Text="產生催稿單"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer><asp:literal id="Literal1" runat="server"></asp:literal></form>
	</body>
</HTML>
