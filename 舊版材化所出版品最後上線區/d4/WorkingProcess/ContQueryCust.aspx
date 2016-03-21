<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="ContQueryCust.aspx.cs" Src="ContQueryCust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContQueryCust" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="ContQueryCust" method="post" runat="server">
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<TABLE ID="tblX" Width="100%" cellSpacing="0" cellPadding="0">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�X���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�s�W�X���� �B�J�@: �D�X�Ȥ�</FONT>
								</TD>
							</TR>
						</TABLE>
						<br>
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0" class="TableColor">
							<TR>
								<TD colspan="3" class="TableColorHeader">�d�߱���</TD>
							</TR>
							<TR>
								<TD width="70">���q�W�١G</TD>
								<TD width="160">
									<asp:TextBox id="tbxMfrNm" runat="server" Width="150px"></asp:TextBox></TD>
								<TD rowspan="4" class="ContAnnounce">
									<asp:Label ID="lblContHint" Runat="server" CssClass="ContAnnounce">
									1.�п�J���@������Ӭd�ߡA�M����U"�d��".<BR>
										2.�d�X��ƫ�A���U"�ק�Ȥ���"�i�ק�ӫȤ᪺���<BR>
											3.�d�X��ƫ�A���U"�T�w"�i�~��[�s�W�X����]�B�J�A�ña�J�ӫȤ᪺�������</asp:Label><BR>
									<asp:label ID="lblContRemark" Runat="server" CssClass="ContRemark">���G�קK���Ʒs�W�t�Ӹ�ơA������J<U>�t�ӲΤ@�s����</U>�A���U<U>���䪺���s</U>�Ӭd�ߡA�p�d�L��ơA�A���U�褧"<U>�s�W�t�Ӹ��</U>"�ӷs�W�t�ӡI</asp:label><BR>
									<asp:LinkButton id="lnbNewMfr" runat="server">�s�W�t�Ӹ��</asp:LinkButton>&nbsp;&nbsp;
									<asp:LinkButton id="lnbNewCust" runat="server">�s�W�Ȥ���</asp:LinkButton>
								</TD>
							</TR>
							<TR>
								<TD>�Τ@�s���G</TD>
								<TD>
									<asp:TextBox id="tbxMfrNo" runat="server" Width="80px"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD>�Ȥ�s���G</TD>
								<TD>
									<asp:TextBox id="tbxCustNo" runat="server" Width="60px" MaxLength="6"></asp:TextBox>(�ݥ��T����)</TD>
							</TR>
							<TR>
								<TD>�Ȥ�m�W�G</TD>
								<TD>
									<asp:TextBox id="tbxCustNm" runat="server" Width="80px"></asp:TextBox>
									<asp:LinkButton id="lnbQuery" runat="server">�d��</asp:LinkButton></TD>
							</TR>
						</TABLE>
						<asp:Panel id="pnlQuery" runat="server" Width="90%">
							<asp:Label id="lblCustFound" runat="server" CssClass="SearchingMessage">�d�ߵ��G�G�@��� 0 ���Ȥ���</asp:Label>
							<BR>
							<asp:DataGrid id="dgdMfrCust" runat="server" Width="100%" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False">
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<Columns>
									<asp:HyperLinkColumn Text="�ק�Ȥ���" Target="_self" DataNavigateUrlField="cust_custid" DataNavigateUrlFormatString="~/d5/cust_edit.aspx?ID={0}"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_jbti" HeaderText="�Ȥ�¾��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_regdate" HeaderText="���U���"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="�«Ȥ�s��"></asp:BoundColumn>
									<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
							</asp:DataGrid>
						</asp:Panel>
					</td>
				</tr>
			</TABLE>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
