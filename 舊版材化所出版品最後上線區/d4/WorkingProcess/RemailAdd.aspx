<%@ Page language="c#" Codebehind="RemailAdd.aspx.cs" Src="RemailAdd.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RemailAdd" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
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
		<form id="RemailAdd" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<table id="tblX" width="100%" border="0">
				<tr>
					<td align="middle">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�ɮѳB�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�ɮѵn��</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" style="WIDTH: 604px" cellSpacing="0" cellPadding="2">
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="4">�Ȥ���
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 104px" align="right">�X���s���G
								</TD>
								<td colSpan="3"><asp:textbox id="tbxContNo" runat="server" Width="100px" MaxLength="6"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">���q�W�١G
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxMfrNm" runat="server" Width="204px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">�Τ@�s���G
								</TD>
								<td><asp:textbox id="tbxMfrNo" runat="server" Width="99px" MaxLength="10"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">�Ȥ�s���G
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxCustNo" runat="server" Width="52px" MaxLength="6"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">�Ȥ�m�W�G
								</TD>
								<td><asp:textbox id="tbxCustName" runat="server" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">ñ������G
								</TD>
								<td colSpan="3"><asp:textbox id="tbxSSDate" runat="server" Width="82px" MaxLength="10"></asp:textbox><IMG class="ico" title="���" onclick="javascript:pick_date_single(tbxSSDate.name)" src="../../images/calendar01.gif">
									��<asp:textbox id="tbxSEDate" runat="server" Width="84px" MaxLength="10"></asp:textbox><IMG class="ico" title="���" onclick="javascript:pick_date_single(tbxSEDate.name)" src="../../images/calendar01.gif">
								</td>
							</TR>
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="4">���x����H���
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 104px" align="right">����H�m�W�G
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxOrName" runat="server" Width="99px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">����H�q�ܡG
								</TD>
								<td><asp:textbox id="tbxOrTel" runat="server" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">����H�a�}�G
								</TD>
								<td colSpan="3"><asp:textbox id="tbxOrAddr" runat="server" Width="431px"></asp:textbox></td>
							</TR>
						</TABLE>
						<asp:linkbutton id="lnbSearch" runat="server">�d��</asp:linkbutton>
						<DIV align="center"><asp:datagrid id="dgdContOr" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="2" AllowPaging="True">
								<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
								<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<FooterStyle CssClass="FooterStyle"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�">
										<ItemStyle Width="10px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="����H">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_addr" HeaderText="����H�a�}"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="����H�q��"></asp:BoundColumn>
									<asp:ButtonColumn Text="�ɮ�" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle Position="Top" CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:label id="lblInfo" Runat="server"></asp:label><asp:datagrid id="dgdRemail" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellPadding="4" BackColor="White">
								<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
								<AlternatingItemStyle CssClass="AlteringItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<FooterStyle CssClass="FooterStyle"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="�R��" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
									<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" ReadOnly="True" HeaderText="�X�����O"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="�q��m�W">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="rm_oritem" ReadOnly="True" HeaderText="����H�Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" ReadOnly="True" HeaderText="����H"></asp:BoundColumn>
									<asp:BoundColumn DataField="rm_seq" ReadOnly="True" HeaderText="�ɮѧǸ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="rm_cont" HeaderText="�ɮѤ��e"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="�ɮѵ��O">
										<ItemTemplate>
											<asp:Label id=lblFgSent runat="server" Text='<%# GetFgSentName(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:DropDownList id=ddlFgSent runat="server" SelectedIndex='<%# GetSelectedIndex(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>'>
												<asp:ListItem Value="Y" Selected="True">�i�H�X</asp:ListItem>
												<asp:ListItem Value="N">�ثe���H�X</asp:ListItem>
												<asp:ListItem Value="C">�w�H�X</asp:ListItem>
												<asp:ListItem Value="D">*���B�z*</asp:ListItem>
											</asp:DropDownList>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="PushButton" UpdateText="�x�s" CancelText="����" EditText="�ק�"></asp:EditCommandColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><FONT face="�s�ө���"><BR>
							</FONT>
							<asp:label id="lblMessage" runat="server" CssClass="ImportantLabel" Visible="False"></asp:label></DIV>
					</td>
				</tr>
			</table>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></FORM>
	</body>
</HTML>
