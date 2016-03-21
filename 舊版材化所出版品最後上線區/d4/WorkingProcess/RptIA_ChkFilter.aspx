<%@ Page language="c#" Codebehind="RptIA_ChkFilter.aspx.cs" src="RptIA_ChkFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptIA_ChkFilter" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptIA_ChkFilter</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptIA_ChkFilter" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="700">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�o���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�j��뵲���o���}�߳��ˮ֪�&nbsp;�G �d�߱���</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="700" border="0">
							<TR>
								<TD class="TableColorHeader">�d�߱���
									<asp:Label id="Label1" runat="server" ForeColor="Yellow">(�Ъ`�N�G�w��|�p�t�ΰ��B�z���o���}�߳�L�k�A�C�L�ˮ֪�I)</asp:Label></TD>
							</TR>
							<tr>
								<td>
									�o���}�߳� <FONT color="blue">���ͦ~��</FONT>�G
									<asp:textbox id="tbxYYYYMM" runat="server" Width="58px"></asp:textbox>
									<asp:label id="lblyyyymm" runat="server" ForeColor="#C04000">(�Ҧp : 2003/09)</asp:label>
									<asp:regularexpressionvalidator id="revDate" runat="server" Font-Size="X-Small" ErrorMessage="��J�榡���~" ControlToValidate="tbxYYYYMM" ValidationExpression="\d{4}/\d{2}"></asp:regularexpressionvalidator>
									<INPUT id="hiddenSeq" type="hidden" name="hiddenSeq" runat="server"><br>
									�ƧǱ���G
									<asp:DropDownList id="ddlSort" runat="server">
										<asp:ListItem Value="1">�o���}�߳�s��</asp:ListItem>
										<asp:ListItem Value="2">�~�ȭ�+�X���s��+�����Ǹ�</asp:ListItem>
									</asp:DropDownList>
									<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
									<asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Small"></asp:label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:datagrid id="dgdIAB" runat="server" Visible="False" AutoGenerateColumns="False" CssClass="DataGridStyle">
										<SelectedItemStyle BackColor="#FFFFC0"></SelectedItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="iab_iabdate" ReadOnly="True" HeaderText="���ͦ~��"></asp:BoundColumn>
											<asp:BoundColumn DataField="iab_iabseq" HeaderText="���ͧ妸"></asp:BoundColumn>
											<asp:BoundColumn DataField="iab_createdate" HeaderText="�妸���ͤ��"></asp:BoundColumn>
											<asp:BoundColumn DataField="srspn_cname" HeaderText="�妸���ͤH���m�W"></asp:BoundColumn>
											<asp:ButtonColumn Text="���" ButtonType="PushButton" HeaderText="�Ӷ����" CommandName="Select"></asp:ButtonColumn>
										</Columns>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td>
									<asp:panel id="pnlIA" Runat="server" Visible="False">
										<asp:Button id="btnPrint" runat="server" Text="�C�L�o���}�߳��ˮ֪�"></asp:Button>
										<asp:datagrid id="dgdIA" runat="server" Width="100%" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="ia_iano" ReadOnly="True" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_contno" HeaderText="�X���s��"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_mfrno" HeaderText="�o���t�Ӳνs"></asp:BoundColumn>
												<asp:BoundColumn DataField="mfr_inm" HeaderText="�o���t�ӦW��"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_pyat" HeaderText="�o�����B"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_fgitri" HeaderText="���ӵ��O"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_cname" HeaderText="�ӿ�H��"></asp:BoundColumn>
											</Columns>
										</asp:datagrid>
									</asp:panel>
									<asp:panel id="pnlBack" Width="100%" Runat="server" Visible="False">
										<P align="center">
											<asp:Button id="btnHome" Runat="server" Text="�^�D���"></asp:Button></P>
									</asp:panel>
								</td>
							</tr>
						</TABLE>
						<asp:Literal id="Literal1" runat="server"></asp:Literal>
					</td>
				</tr>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
