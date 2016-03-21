<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="ContQueryCust.aspx.cs" Src="ContQueryCust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContQueryCust" %>
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
		<form id="ContQueryCust" method="post" runat="server">
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
										新增合約書 步驟一: 挑出客戶</FONT>
								</TD>
							</TR>
						</TABLE>
						<br>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0" class="TableColor">
							<TR>
								<TD colspan="3" class="TableColorHeader">查詢條件</TD>
							</TR>
							<TR>
								<TD width="70">公司名稱：</TD>
								<TD width="160">
									<asp:TextBox id="tbxMfrNm" runat="server" Width="150px"></asp:TextBox></TD>
								<TD rowspan="4" class="ContAnnounce">
									<asp:Label ID="lblContHint" Runat="server" CssClass="ContAnnounce">
									1.請輸入任一關鍵詞來查詢，然後按下"查詢".<BR>
										2.查出資料後，按下"修改客戶資料"可修改該客戶的資料<BR>
											3.查出資料後，按下"確定"可繼續[新增合約書]步驟，並帶入該客戶的相關資料</asp:Label><BR>
									<asp:label ID="lblContRemark" Runat="server" CssClass="ContRemark">註：避免重複新增廠商資料，醒先輸入<U>廠商統一編號後</U>，按下<U>旁邊的按鈕</U>來查詢，如查無資料，再按下方之"<U>新增廠商資料</U>"來新增廠商！</asp:label><BR>
									<asp:LinkButton id="lnbNewMfr" runat="server">新增廠商資料</asp:LinkButton>&nbsp;&nbsp;
									<asp:LinkButton id="lnbNewCust" runat="server">新增客戶資料</asp:LinkButton>
								</TD>
							</TR>
							<TR>
								<TD>統一編號：</TD>
								<TD>
									<asp:TextBox id="tbxMfrNo" runat="server" Width="80px"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD>客戶編號：</TD>
								<TD>
									<asp:TextBox id="tbxCustNo" runat="server" Width="60px" MaxLength="6"></asp:TextBox>(需正確的值)</TD>
							</TR>
							<TR>
								<TD>客戶姓名：</TD>
								<TD>
									<asp:TextBox id="tbxCustNm" runat="server" Width="80px"></asp:TextBox>
									<asp:LinkButton id="lnbQuery" runat="server">查詢</asp:LinkButton></TD>
							</TR>
						</TABLE>
						<asp:Panel id="pnlQuery" runat="server" Width="90%">
							<asp:Label id="lblCustFound" runat="server" CssClass="SearchingMessage">查詢結果：共找到 0 筆客戶資料</asp:Label>
							<BR>
							<asp:DataGrid id="dgdMfrCust" runat="server" Width="100%" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False">
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<Columns>
									<asp:HyperLinkColumn Text="修改客戶資料" Target="_self" DataNavigateUrlField="cust_custid" DataNavigateUrlFormatString="~/d5/cust_edit.aspx?ID={0}"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="mfr_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_custno" HeaderText="客戶編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_jbti" HeaderText="客戶職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="聯絡電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_regdate" HeaderText="註冊日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="舊客戶編號"></asp:BoundColumn>
									<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
							</asp:DataGrid>
						</asp:Panel>
					</td>
				</tr>
			</TABLE>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
