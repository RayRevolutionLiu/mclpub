<%@ Page language="c#" Codebehind="IAConfirmChecked.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IAConfirmChecked" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IAConfirmChecked</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="IAConfirmChecked" method="post" runat="server">
			<kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										大批月結發票開立產生：發票開立確認</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<td>
						<TABLE class="TableColor" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblAdrInfo" runat="server" CssClass="TableColorHeader">發票開立單明細資料</asp:label></TD>
							</TR>
							<tr>
								<td>
									<asp:datagrid id="dgdAdr" runat="server" Visible="False" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號">
												<HeaderStyle Width="45px"></HeaderStyle>
												<ItemStyle ForeColor="Blue"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_sdate" ReadOnly="True" HeaderText="合約起日">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_edate" ReadOnly="True" HeaderText="合約迄日">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_mfrno" ReadOnly="True" HeaderText="廠商統編">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_mfr_inm" ReadOnly="True" HeaderText="合約廠商名稱">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="srspn_cname" ReadOnly="True" HeaderText="業務員">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle ForeColor="Blue"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="落版序號">
												<HeaderStyle Width="15px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="播出日期">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_mfrno" ReadOnly="True" HeaderText="發票廠商統編">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle ForeColor="Peru"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_mfr_inm" ReadOnly="True" HeaderText="發票廠商名稱">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle ForeColor="Peru"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_nm" ReadOnly="True" HeaderText="發票收件人">
												<HeaderStyle Width="40px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="廣告頁面">
												<ItemTemplate>
													<asp:Label id=lblEAdCate runat="server" Text='<%# MatchAdCate(DataBinder.Eval(Container.DataItem, "adr_adcate")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="廣告位置">
												<ItemTemplate>
													<asp:Label id=lblEKeyword runat="server" Text='<%# MatchKeyword(DataBinder.Eval(Container.DataItem, "adr_keyword")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="播放機率">
												<HeaderStyle Width="15px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_adamt" HeaderText="廣告價格">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_desamt" HeaderText="設計價格">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_chgamt" HeaderText="換稿費用">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_invamt" HeaderText="發票金額">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="Red"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_remark" HeaderText="備註">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="往來註記">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblFgitri" runat="server" Text='<%# MatchFgitri(DataBinder.Eval(Container.DataItem, "im_fgitri")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="proj_projno" HeaderText="計劃代號">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle ForeColor="Peru"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_imseq" ReadOnly="True" HeaderText="adr_imseq"></asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<asp:panel id="pnlAdr" Width="100%" Runat="server">
										<asp:Button id="btnBack" runat="server" ToolTip="勾選的項目不對, 重新挑選" Text="落重新挑選"></asp:Button>
										<asp:Button id="btnModifyAdr" runat="server" ToolTip="落版金額錯誤, 前往落版處理" Text="落版金額錯誤, 修改落版金額"></asp:Button>
										<asp:Button id="btnCancel" runat="server" ToolTip="回首頁" Text="取消, 回首頁"></asp:Button>
										<asp:Button id="btnPrint" runat="server" Text="列印預覽清單"></asp:Button>
										<asp:Button id="btnConfirm" runat="server" ForeColor="Red" ToolTip="確定產生發票開立單" Text="確定產生發票開立單"></asp:Button>
									</asp:panel><asp:panel id="pnlNext" Visible="False" Width="100%" Runat="server">
										<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
										<BR>
									</asp:panel></td>
							</tr>
						</TABLE>
						<asp:Literal id="Literal1" runat="server"></asp:Literal></td>
				</TR>
			</TABLE>
			<!-- 頁首 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
