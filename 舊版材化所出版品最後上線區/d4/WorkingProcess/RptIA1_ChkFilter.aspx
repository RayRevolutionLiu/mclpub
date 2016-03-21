<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RptIA1_ChkFilter.aspx.cs" src="RptIA1_ChkFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptIA1_ChkFilter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptIA_ChkFilter</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptIA_ChkFilter" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="700">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										單一廠商之發票開立單檢核表：列印</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="700" border="0">
							<TR>
								<TD class="TableColorHeader"><asp:label id="Label1" runat="server" ForeColor="Yellow">** 請注意：已於會計系統做處理之發票開立單無法再列印檢核表！**</asp:label></TD>
							</TR>
							<tr>
								<td><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Small"></asp:label><asp:datagrid id="dgdIA" runat="server" Width="100%" CssClass="DataGridStyle" AutoGenerateColumns="False">
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="ia_iano" ReadOnly="True" HeaderText="發票開立單編號"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_contno" HeaderText="合約編號"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_mfrno" HeaderText="發票廠商統編"></asp:BoundColumn>
											<asp:BoundColumn DataField="mfr_inm" HeaderText="發票廠商名稱"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_pyat" HeaderText="發票金額"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_fgitri" HeaderText="往來註記"></asp:BoundColumn>
											<asp:BoundColumn DataField="ia_cname" HeaderText="承辦人員"></asp:BoundColumn>
											<asp:ButtonColumn Text="確定" ButtonType="PushButton" HeaderText="列印檢核表" CommandName="Select"></asp:ButtonColumn>
										</Columns>
									</asp:datagrid><asp:panel id="pnlBack" Width="100%" Visible="False" Runat="server">
										<P align="center">
											<asp:Button id="btnHome" Text="回主選單" Runat="server"></asp:Button></P>
									</asp:panel></td>
							</tr>
						</TABLE>
						<asp:literal id="Literal1" runat="server"></asp:literal></td>
				</tr>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
