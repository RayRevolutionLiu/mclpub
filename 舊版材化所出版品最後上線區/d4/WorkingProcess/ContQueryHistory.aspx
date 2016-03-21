<%@ Page language="c#" Codebehind="ContQueryHistory.aspx.cs" Src="ContQueryHistory.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContQueryHistory" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="ContQueryHistory" method="post" runat="server">
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<TABLE ID="tblX" Width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										合約處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										新增合約書 步驟二: 挑出歷史合約書資料</FONT>
								</TD>
							</TR>
						</TABLE>
						<asp:Panel id="pnlNoHistory" runat="server" Width="100%">
							<asp:Label id="lblNoHistory" runat="server" CssClass="ImportantLabel">此客戶尚無歷史合約...</asp:Label>
							<asp:Button id="btnNewCont" runat="server" Text="新增合約書"></asp:Button>
						</asp:Panel>
					</td>
				</tr>
				<TR>
					<TD align="middle">
						<asp:Label id="lblCustFound" runat="server" CssClass="SearchingMessage">此客戶共有 0 筆歷史資料</asp:Label>
						<asp:LinkButton id="lnbBack" runat="server">回查詢畫面</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD align="middle">
						<asp:DataGrid id="dgdCont" runat="server" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False" Width="90%">
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號">
									<HeaderStyle Width="50px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期">
									<HeaderStyle Width="65px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日">
									<HeaderStyle Width="65px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日">
									<HeaderStyle Width="65px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_aunm" HeaderText="廣告聯絡人姓名">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_autel" HeaderText="廣告聯絡人電話">
									<HeaderStyle Width="90px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="一次付清註記">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案註記">
									<HeaderStyle Width="30px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別">
									<HeaderStyle Width="30px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_disc" HeaderText="優惠折數">
									<HeaderStyle Width="30px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="以此合約為範本，新增合約" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
