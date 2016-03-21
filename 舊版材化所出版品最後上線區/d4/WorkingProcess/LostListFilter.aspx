<%@ Page language="c#" Codebehind="LostListFilter.aspx.cs" src="LostListFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.RmListFilter" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RmListFilter" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<table id="tblX" width="100%" border="0">
				<tr>
					<td align="middle">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										缺書處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										缺書清單列印</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" style="WIDTH: 604px" cellSpacing="0" cellPadding="2">
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colspan="2">查詢條件
								</td>
							</tr>
							<TR>
								<TD align="right" width="30%">寄書狀況：</TD>
								<td><asp:dropdownlist id="ddlSent" runat="server" AutoPostBack="True">
										<asp:ListItem Value="C">已寄出</asp:ListItem>
										<asp:ListItem Value="N">尚未寄出</asp:ListItem>
										<asp:ListItem Value="ALL">全部</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</TR>
							<tr>
								<td align="right">
									<asp:checkbox id="cbx1" runat="server" Text="缺書日期區間："></asp:checkbox>
								</td>
								<td>
									<asp:textbox id="tbxLostDate1" runat="server" Width="82px"></asp:textbox>
									<IMG class="ico" title="日曆" onclick="javascript:pick_date_single(tbxLostDate1.name)" src="../../images/calendar01.gif">
									～<asp:textbox id="tbxLostDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="javascript:pick_date_single(tbxLostDate2.name)" src="../../images/calendar01.gif">
								</td>
							</tr>
							<tr>
								<td align="right">
									<asp:checkbox id="cbx2" runat="server" Text="簽約日期區間："></asp:checkbox>
								</td>
								<td>
									<asp:textbox id="tbxSignDate1" runat="server" Width="82px"></asp:textbox>
									<IMG class="ico" title="日曆" onclick="javascript:pick_date_single(tbxSignDate1.name)" src="../../images/calendar01.gif">
									～<asp:textbox id="tbxSignDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="javascript:pick_date_single(tbxSignDate2.name)" src="../../images/calendar01.gif">
								</td>
							</tr>
							<tr>
								<td align="right"><asp:button id="btnPrintList" runat="server" Text="列印清單"></asp:button></td>
								<td>
									<asp:literal id="Literal1" runat="server"></asp:literal>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
