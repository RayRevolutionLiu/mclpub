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
										�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�o���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�j��뵲�o���}�߲��͡G�o���}�߽T�{</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<td>
						<TABLE class="TableColor" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblAdrInfo" runat="server" CssClass="TableColorHeader">�o���}�߳���Ӹ��</asp:label></TD>
							</TR>
							<tr>
								<td>
									<asp:datagrid id="dgdAdr" runat="server" Visible="False" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��">
												<HeaderStyle Width="45px"></HeaderStyle>
												<ItemStyle ForeColor="Blue"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_sdate" ReadOnly="True" HeaderText="�X���_��">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_edate" ReadOnly="True" HeaderText="�X������">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_mfrno" ReadOnly="True" HeaderText="�t�Ӳνs">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cont_mfr_inm" ReadOnly="True" HeaderText="�X���t�ӦW��">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="srspn_cname" ReadOnly="True" HeaderText="�~�ȭ�">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle ForeColor="Blue"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="�����Ǹ�">
												<HeaderStyle Width="15px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="���X���">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_mfrno" ReadOnly="True" HeaderText="�o���t�Ӳνs">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle ForeColor="Peru"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_mfr_inm" ReadOnly="True" HeaderText="�o���t�ӦW��">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle ForeColor="Peru"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="im_nm" ReadOnly="True" HeaderText="�o������H">
												<HeaderStyle Width="40px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="�s�i����">
												<ItemTemplate>
													<asp:Label id=lblEAdCate runat="server" Text='<%# MatchAdCate(DataBinder.Eval(Container.DataItem, "adr_adcate")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="�s�i��m">
												<ItemTemplate>
													<asp:Label id=lblEKeyword runat="server" Text='<%# MatchKeyword(DataBinder.Eval(Container.DataItem, "adr_keyword")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="������v">
												<HeaderStyle Width="15px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_adamt" HeaderText="�s�i����">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_desamt" HeaderText="�]�p����">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_chgamt" HeaderText="���Z�O��">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_invamt" HeaderText="�o�����B">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="Red"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_remark" HeaderText="�Ƶ�">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="���ӵ��O">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblFgitri" runat="server" Text='<%# MatchFgitri(DataBinder.Eval(Container.DataItem, "im_fgitri")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="proj_projno" HeaderText="�p���N��">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle ForeColor="Peru"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_imseq" ReadOnly="True" HeaderText="adr_imseq"></asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<asp:panel id="pnlAdr" Width="100%" Runat="server">
										<asp:Button id="btnBack" runat="server" ToolTip="�Ŀ諸���ؤ���, ���s�D��" Text="�����s�D��"></asp:Button>
										<asp:Button id="btnModifyAdr" runat="server" ToolTip="�������B���~, �e�������B�z" Text="�������B���~, �ק︨�����B"></asp:Button>
										<asp:Button id="btnCancel" runat="server" ToolTip="�^����" Text="����, �^����"></asp:Button>
										<asp:Button id="btnPrint" runat="server" Text="�C�L�w���M��"></asp:Button>
										<asp:Button id="btnConfirm" runat="server" ForeColor="Red" ToolTip="�T�w���͵o���}�߳�" Text="�T�w���͵o���}�߳�"></asp:Button>
									</asp:panel><asp:panel id="pnlNext" Visible="False" Width="100%" Runat="server">
										<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
										<BR>
									</asp:panel></td>
							</tr>
						</TABLE>
						<asp:Literal id="Literal1" runat="server"></asp:Literal></td>
				</TR>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
