<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IA1QueryCont.aspx.cs" Src="IA1QueryCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1QueryCont" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IA1QueryCont" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<TBODY>
					<tr>
						<td align="middle"><br>
							<TABLE id="tbItems">
								<TR>
									<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
											&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
											�o�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
											��@�X���o���}�ߡG�D��}�ߵo������</FONT>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD>
							<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblContInfo" runat="server" CssClass="TableColorHeader">�X���򥻸��</asp:label></TD>
								</TR>
								<tr>
									<td>
										<TABLE class="TableColor" id="Table11" cellSpacing="0" cellPadding="2" width="100%" border="1">
											<TR class="TableColor">
												<TD>�X���s��</TD>
												<TD>�X�����O</TD>
												<TD>ñ�����</TD>
												<TD>�X���_��</TD>
												<TD>�Z�n����</TD>
												<TD>�ذe����</TD>
												<TD>�X�����B</TD>
												<TD>�u�f���</TD>
												<TD>�`�s���ɽZ����</TD>
												<TD>�`�s�����Z����</TD>
											</TR>
											<TR>
												<TD bgColor="#ecebff"><asp:label id="lblContNo" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
												<TD bgColor="#ecebff"><asp:label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:label>��
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
									<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblAdrInfo" runat="server" CssClass="TableColorHeader">���X���s�i���</asp:label></TD>
								</TR>
								<tr>
									<TD align="left"><asp:panel id="pnlAdr" Width="100%" Runat="server">
											<asp:Panel id="pnlOptions" Runat="server" Width="100%">
												<asp:Label id="lblSelectInvMfr" Runat="server" ForeColor="Red">�o���t�ӡG</asp:Label>
												<asp:DropDownList id="ddlInvMfr" runat="server" AutoPostBack="True"></asp:DropDownList>
												<BR>
												<asp:Button id="btnSelAll" runat="server" Text="����"></asp:Button>
												<asp:Button id="btnDeSelAll" runat="server" Text="�M��"></asp:Button>
												<asp:Button id="btnConfirmSelected" runat="server" Text="�T�{�w�Ŀ諸�s�i����"></asp:Button>
											</asp:Panel>
											<asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
												<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
												<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
												<ItemStyle CssClass="ItemStyle"></ItemStyle>
												<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="�Ŀ�">
														<ItemTemplate>
															<asp:CheckBox id="cbxSelAdr" runat="server" Enabled="False"></asp:CheckBox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="�Ǹ�">
														<HeaderStyle Width="25px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="���X���">
														<HeaderStyle Width="60px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="�s�i�лy">
														<HeaderStyle Width="100px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="adr_adcate" ReadOnly="True" HeaderText="�s�i����">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="adr_keyword" ReadOnly="True" HeaderText="�s�i��m">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="�s�i�s��">
														<HeaderStyle Width="100px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="������v">
														<HeaderStyle Width="25px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_adamt" HeaderText="�s�i����">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_desamt" HeaderText="�]�p����">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_chgamt" HeaderText="���Z�O��">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="adr_invamt" HeaderText="�o�����B">
														<HeaderStyle Width="50px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="�o���t��">
														<ItemTemplate>
															<asp:Label id=lblEInfMfr runat="server" Text='<%# MatchImSeq(DataBinder.Eval(Container.DataItem, "adr_imseq")) %>'>
															</asp:Label>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="adr_remark" HeaderText="�Ƶ�">
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
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
		</TR></TBODY></TABLE>
	</body>
</HTML>
