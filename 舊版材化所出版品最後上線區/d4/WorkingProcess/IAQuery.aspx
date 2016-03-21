<%@ Page language="c#" Codebehind="IAQuery.aspx.cs" src="IAQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IAQuery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IAQuery</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IAQuery" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td style="HEIGHT: 45px">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										大批月結發票開立產生：查詢條件</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<asp:Panel ID="pnlSearch" Runat="server">
				<asp:label id="lblDate" Runat="server" Font-Size="Small">截止播出日：</asp:label>
				<asp:textbox id="tbxDate" runat="server" Width="80px"></asp:textbox>
				<IMG onclick='javascript:pick_date_single("tbxDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
				<asp:label id="lblyyyymmdd" runat="server" ForeColor="#C04000">(yyyy/mm/dd)</asp:label>
				<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
				<asp:label id="lblMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:label>
				<BR>
				<BR>
			</asp:Panel>
			<asp:panel id="pnlSelect" Runat="server" Visible="False">
				<FONT face="新細明體">&nbsp; </FONT>
				<asp:Label id="Label1" runat="server" Font-Size="Small" ForeColor="Blue" Font-Underline="True" BorderWidth="2px" BorderStyle="Ridge" BackColor="#BFCFF0">目前可開立之落版明細</asp:Label>
				<asp:Button id="btnSelAll" runat="server" Text="全選"></asp:Button>
				<asp:Button id="btnDeSelAll" runat="server" Text="清選"></asp:Button>
				<asp:Button id="btnNextStep" runat="server" Text="勾選好了,下一步"></asp:Button>
				<asp:datagrid id="dgdAdr" runat="server" Visible="False" AutoGenerateColumns="False">
					<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
					<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemStyle"></ItemStyle>
					<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn HeaderText="勾選">
							<ItemTemplate>
								<asp:CheckBox id="cbxSelAdr" runat="server" Checked="True"></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
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
			</asp:panel><asp:panel id="pnlConfirm" Runat="server" Visible="False">
				<asp:Label id="Label5" runat="server" Font-Size="Small" ForeColor="Blue" Font-Underline="True" BorderWidth="2px" BorderStyle="Ridge" BackColor="#BFCFF0">已挑選之落版明細</asp:Label>
				<asp:Button id="btnPreStep" runat="server" Text="重新挑選,回上一步"></asp:Button>
				<asp:Button id="btnPrint" runat="server" Text="列印預覽清單"></asp:Button>
				<asp:Button id="btnOK" runat="server" ForeColor="Red" Text="確定產生發票開立單"></asp:Button>
				<asp:Button id="btnCancel" runat="server" Text="取消,回首頁"></asp:Button>
				<asp:datagrid id="dgdConfirm" runat="server" Visible="False" AutoGenerateColumns="False">
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
								<asp:Label id="Label2" runat="server" Text='<%# MatchAdCate(DataBinder.Eval(Container.DataItem, "adr_adcate")) %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="廣告位置">
							<ItemTemplate>
								<asp:Label id="Label3" runat="server" Text='<%# MatchKeyword(DataBinder.Eval(Container.DataItem, "adr_keyword")) %>'>
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
								<asp:Label id="Label4" runat="server" Text='<%# MatchFgitri(DataBinder.Eval(Container.DataItem, "im_fgitri")) %>'>
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
			</asp:panel><asp:literal id="Literal1" runat="server"></asp:literal>
			<asp:panel id="pnlBack" Runat="server" Width="100%" Visible="False">
				<P align="center">
					<asp:Button id="btnHome" Runat="server" Text="回主選單"></asp:Button></P>
			</asp:panel> <!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
