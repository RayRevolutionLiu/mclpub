<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IARecoveryQuery.aspx.cs" src="IARecoveryQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IARecoveryQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IARecoveryQuery</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IARecoveryQuery" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td style="HEIGHT: 45px">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										大批月結之發票開立單回復(Recovery):查詢條件</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<asp:Panel ID="pnlSearch" Runat="server" Width="100%">
<asp:label id="Label1" runat="server" Font-Size="Small" ForeColor="Blue" Font-Bold="True">請輸入查詢條件</asp:label><FONT color="#cc33cc" size="2">
					(請注意：已於會計系統做處理之發票開立單無法做回復！)</FONT><BR>發票開立單 <FONT color="blue">產生年月</FONT>： 
<asp:textbox id="tbxYYYYMM" runat="server" Width="58px"></asp:textbox>
<asp:label id="lblyyyymm" runat="server" ForeColor="#C04000">(例如 : 2003/09)</asp:label>
<asp:regularexpressionvalidator id="revDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxYYYYMM" ErrorMessage="輸入格式錯誤"></asp:regularexpressionvalidator><BR>發票開立單 
<FONT color="blue">產生批次</FONT>： 
<asp:textbox id="tbxBatch" runat="server" Width="58px"></asp:textbox>
<asp:label id="lblBatch" runat="server" ForeColor="#C04000">(例如 : 000001)</asp:label><BR>
<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
<asp:label id="lblMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:label><BR>
			</asp:Panel>
			<asp:panel id="pnlCont" Runat="server" Visible="False">
				<asp:Button id="btnOK" runat="server" ForeColor="Red" Text="確定回復這一批資料"></asp:Button>
				<BR>
				<asp:datagrid id="dgdCont" runat="server" Width="90%" AutoGenerateColumns="False" CssClass="DataGridStyle">
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
						<asp:BoundColumn DataField="ia_status" HeaderText="進行狀態"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="ia_status"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel>
			<asp:panel id="pnlBack" Runat="server" Width="100%" Visible="False">
				<P align="center">
					<asp:Button id="btnHome" Runat="server" Text="回主選單"></asp:Button></P>
			</asp:panel>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
