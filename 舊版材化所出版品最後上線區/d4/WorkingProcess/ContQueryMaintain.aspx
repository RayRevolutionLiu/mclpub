<%@ Page language="c#" Codebehind="ContQueryMaintain.aspx.cs" Src="ContQueryMaintain.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContQueryMaintain" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>材料所出版品客戶管理系統</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="ContQueryMaintain" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										合約處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										維護合約書 步驟一: 挑出客戶或直接輸入合約書編號</FONT>
								</TD>
							</TR>
						</TABLE>
						<br>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">查詢條件</TD>
							</TR>
							<TR>
								<TD align="right" width="90">公司名稱：</TD>
								<TD width="160"><asp:textbox id="tbxMfrNm" runat="server" Width="150px"></asp:textbox></TD>
								<TD class="ContAnnounce" rowSpan="4"><asp:label id="lblContHint" CssClass="ContAnnounce" Runat="server">
									1.請輸入任一關鍵詞來查詢，然後按下"查詢".<BR>
										2.查出資料後，按下"修改客戶資料"可修改該客戶的資料<BR>
											3.查出資料後，按下"確定"可繼續[維護合約書]步驟</asp:label><BR>
								</TD>
							</TR>
							<TR>
								<TD align="right">統一編號：</TD>
								<TD><asp:textbox id="tbxMfrNo" runat="server" Width="80px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right">客戶編號：</TD>
								<TD><asp:textbox id="tbxCustNo" runat="server" Width="60px" MaxLength="6"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right">客戶姓名：</TD>
								<TD><asp:textbox id="tbxCustNm" runat="server" Width="80px"></asp:textbox><asp:linkbutton id="lnbQuery" runat="server">查詢</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD align="right">合約書編號：</TD>
								<TD><asp:textbox id="tbxContNo" runat="server" Width="80px"></asp:textbox><asp:linkbutton id="lngGoThis" runat="server">GO!!</asp:linkbutton></TD>
								<td><asp:label id="lblCustFound" runat="server" CssClass="SearchingMessage" ForeColor="Maroon"></asp:label></td>
							</TR>
						</TABLE>
						<asp:panel id="pnlQuery" runat="server" Width="90%">
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
						</asp:panel></td>
				</tr>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
