<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IA1QueryCont.aspx.cs" Src="IA1QueryCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1QueryCont" %>
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
		<form id="IA1QueryCont" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<TBODY>
					<tr>
						<td align="middle"><br>
							<TABLE id="tbItems">
								<TR>
									<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
											&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
											發票 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
											單一合約發票開立：挑選開立發票項目</FONT>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD>
							<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblContInfo" runat="server" CssClass="TableColorHeader">合約基本資料</asp:label></TD>
								</TR>
								<tr>
									<td>
										<TABLE class="TableColor" id="Table11" cellSpacing="0" cellPadding="2" width="100%" border="1">
											<TR class="TableColor">
												<TD>合約編號</TD>
												<TD>合約類別</TD>
												<TD>簽約日期</TD>
												<TD>合約起迄</TD>
												<TD>刊登次數</TD>
												<TD>贈送次數</TD>
												<TD>合約金額</TD>
												<TD>優惠折數</TD>
												<TD>總製圖檔稿次數</TD>
												<TD>總製網頁稿次數</TD>
											</TR>
											<TR>
												<TD bgColor="#ecebff"><asp:label id="lblContNo" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:label>～
													<asp:label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblTotImgTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblTotUrlTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<td>
							<TABLE class="TableColor" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblAdrInfo" runat="server" CssClass="TableColorHeader">本合約廣告資料</asp:label></TD>
								</TR>
								<tr>
									<TD align="left"><asp:panel id="pnlAdr" Width="100%" Runat="server">
											<asp:Panel id="pnlOptions" Runat="server" Width="100%">
												<asp:Label id="lblSelectInvMfr" Runat="server" ForeColor="Red">發票廠商：</asp:Label>
												<asp:DropDownList id="ddlInvMfr" runat="server" AutoPostBack="True"></asp:DropDownList>
												<BR>
												<asp:Button id="btnSelAll" runat="server" Text="全選"></asp:Button>
												<asp:Button id="btnDeSelAll" runat="server" Text="清選"></asp:Button>
												<asp:Button id="btnConfirmSelected" runat="server" Text="確認已勾選的廣告項目"></asp:Button>
											</asp:Panel>
											<asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
												<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
												<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="ItemStyle"></ItemStyle>
												<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="勾選">
														<ItemTemplate>
															<asp:CheckBox id="cbxSelAdr" runat="server" Enabled="False"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="序號">
														<HeaderStyle Width="25px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="播出日期">
														<HeaderStyle Width="60px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="廣告標語">
														<HeaderStyle Width="100px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="adr_adcate" ReadOnly="True" HeaderText="廣告頁面">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="adr_keyword" ReadOnly="True" HeaderText="廣告位置">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="廣告連結">
														<HeaderStyle Width="100px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="播放機率">
														<HeaderStyle Width="25px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_adamt" HeaderText="廣告價格">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_desamt" HeaderText="設計價格">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_chgamt" HeaderText="換稿費用">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_invamt" HeaderText="發票金額">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="發票廠商">
														<ItemTemplate>
															<asp:Label id=lblEInfMfr runat="server" Text='<%# MatchImSeq(DataBinder.Eval(Container.DataItem, "adr_imseq")) %>'>
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="adr_remark" HeaderText="備註">
														<HeaderStyle Width="100px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="adr_imseq" ReadOnly="True" HeaderText="adr_imseq">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="adr_fginved" ReadOnly="True" HeaderText="adr_fginved"></asp:BoundColumn>
												</Columns>
											</asp:datagrid>
										</asp:panel></TD>
								</tr>
							</TABLE>
						</td>
					</TR>
				</TBODY>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
		</TR></TBODY></TABLE>
	</body>
</HTML>
