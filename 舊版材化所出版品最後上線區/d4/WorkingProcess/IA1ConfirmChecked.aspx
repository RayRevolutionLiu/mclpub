<%@ Page language="c#" Codebehind="IA1ConfirmChecked.aspx.cs" src="IA1ConfirmChecked.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1ConfirmChecked" %>
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
		<form id="IA1ConfirmChecked" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										單一合約發票開立：發票開立確認</FONT>
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
											<TD align="right" bgColor="#ecebff">$<asp:label id="lblTotAmt" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
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
					<TD>
						<TABLE class="TableColor" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="Label1" runat="server" CssClass="TableColorHeader">發票開立單資料</asp:label></TD>
							</TR>
							<tr>
								<td>
									<TABLE class="TableColor" id="Table21" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>廠商統編</TD>
											<TD>發票金額</TD>
											<TD>計劃代號</TD>
											<TD>發票收件人姓名</TD>
											<TD>職稱</TD>
											<TD>郵遞區號</TD>
											<TD>地址</TD>
											<TD>電話</TD>
											<TD>發票類別</TD>
											<TD>課稅別</TD>
											<TD>往來</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lblMfrno" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD align="right" bgColor="#ecebff">$<asp:label id="lblPyat" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD align="middle" bgColor="#ecebff"><asp:label id="lblProjNo" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblNm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblJbti" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblZip" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblAddr" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTel" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblInvcd" runat="server" CssClass="NormalLabel"></asp:label><asp:label id="lblInvcd1" runat="server" CssClass="NormalLabel" Visible="False"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTaxtp" runat="server" CssClass="NormalLabel"></asp:label><asp:label id="lblTaxtp1" runat="server" CssClass="NormalLabel" Visible="False"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblFgitri" runat="server" CssClass="NormalLabel"></asp:label><asp:label id="lblFgitri1" runat="server" CssClass="NormalLabel" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<td>
						<TABLE class="TableColor" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblAdrInfo" runat="server" CssClass="TableColorHeader">發票開立單明細資料</asp:label>
									<asp:Label id="lblCount" runat="server" ForeColor="Yellow"></asp:Label></TD>
							</TR>
							<tr>
								<td><asp:datagrid id="dgdSubAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
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
											<asp:BoundColumn DataField="adr_adamt" ReadOnly="True" HeaderText="廣告價格">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_desamt" ReadOnly="True" HeaderText="設計價格">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_chgamt" ReadOnly="True" HeaderText="換稿費用">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_invamt" ReadOnly="True" HeaderText="發票金額">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_remark" ReadOnly="True" HeaderText="備註">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_imseq" ReadOnly="True" HeaderText="發票廠商">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid><asp:panel id="pnlAdr" Width="100%" Runat="server">
										<asp:Button id="btnBack" runat="server" Text="挑錯重新挑選" ToolTip="勾選的項目不對, 重新挑選"></asp:Button>
										<asp:Button id="btnModifyAdr" runat="server" Text="落版金額錯誤, 修改落版金額" ToolTip="落版金額錯誤, 前往落版處理"></asp:Button>
										<asp:Button id="btnCancel" runat="server" Text="取消, 回首頁" ToolTip="回首頁"></asp:Button>
										<asp:Button id="btnPrint" runat="server" Text="列印預覽清單"></asp:Button>
										<asp:Button id="btnConfirm" runat="server" ForeColor="Red" Text="確定產生發票開立單" ToolTip="確定產生發票開立單"></asp:Button>
									</asp:panel><asp:panel id="pnlNext" Visible="False" Width="100%" Runat="server">
										<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
										<BR>
										<asp:Button id="btnContinue" runat="server" Text="繼續發票開立作業(同合約)"></asp:Button>
										<asp:Button id="btnGoIA1" runat="server" Text="繼續發票開立作業(不同合約)"></asp:Button>
										<asp:Button id="btnExit" runat="server" Text="結束, 回首頁"></asp:Button>
									</asp:panel></td>
							</tr>
						</TABLE>
						<asp:Literal id="Literal1" runat="server"></asp:Literal></td>
				</TR>
			</TABLE>
			<!-- 頁首 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
