<%@ Page language="c#" Codebehind="AdrQueryPublished.aspx.cs" Src="AdrQueryPublished.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrQueryPublished" %>
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
		<form id="AdrQueryPublished" method="post" runat="server">
			<kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										 落版處理<IMG height="10" src="../../images/header/right02.gif" width="10" border="0">美編上稿處理
									</FONT>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">查詢條件</TD>
							</TR>
							<TR>
								<TD align="right" width="90">公司名稱：</TD>
								<TD width="160"><asp:textbox id="tbxMfrNm" runat="server" Width="150px"></asp:textbox></TD>
								<TD class="ContAnnounce" rowSpan="4"><asp:label id="lblContHint" CssClass="ContAnnounce" Runat="server">
									1.請輸入任一關鍵詞來查詢，然後按下"查詢".<BR>
											2.查出資料後，按下"選定落版"可進行[美編上稿處理]<br><br>
											3.如輸入確定的合約編號, 按下"GO!!"可直接進行[美編上稿處理]</asp:label><BR>
									<BR>
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
						<asp:DataGrid id="dgdCont" runat="server" Width="90%" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False">
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
								<asp:BoundColumn DataField="cust_custno" HeaderText="客戶編號"></asp:BoundColumn>
								<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_aunm" HeaderText="廣告聯絡人姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_autel" HeaderText="廣告聯絡人電話"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="一次付清註記"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案註記"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_disc" HeaderText="優惠折數"></asp:BoundColumn>
								<asp:ButtonColumn Text="選定落版" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="cont_oldcontno" ReadOnly="True" HeaderText="cont_oldcontno"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE> <!-- 頁首 Header -->
			<kw:footer id="Footer1" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
