<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IA1Query.aspx.cs" src="IA1Query.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1Query" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>單一廠商發票開立產生：查詢條件</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IA1Query" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="90%">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										單一廠商發票開立產生：查詢條件</FONT>
								</TD>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">查詢條件</TD>
							</TR>
							<TR>
								<TD align="right" width="90">公司名稱：</TD>
								<TD width="160"><asp:textbox id="tbxMfrNm" runat="server" Width="150px"></asp:textbox></TD>
								<TD class="ContAnnounce" rowSpan="4"><asp:label id="lblContHint" Runat="server" CssClass="ContAnnounce">
									1.請輸入任一關鍵詞來查詢，然後按下"查詢".<BR>
									2.查出資料後，選擇所需的合約按下"確定"可進行下一步驟<br>
									3.如輸入確定的合約編號, 按下"GO!!"可直接進行下一步驟</asp:label><BR>
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
						<asp:datagrid id="dgdCont" runat="server" Width="90%" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False">
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
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_fgpayonce" HeaderText="一次付清註記"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_fgclosed" HeaderText="已結案"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_disc" HeaderText="優惠折數"></asp:BoundColumn>
								<asp:ButtonColumn Text="確定" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="cont_oldcontno" ReadOnly="True" HeaderText="cont_oldcontno"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
