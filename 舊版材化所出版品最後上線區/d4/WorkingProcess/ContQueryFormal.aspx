<%@ Page language="c#" Codebehind="ContQueryFormal.aspx.cs" Src="ContQueryFormal.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContQueryFormal" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
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
		<form id="ContQueryFormal" method="post" runat="server">
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
										���@�X���� �B�J�G: �D�X�{��X���Ѹ��</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD align="middle">
						<asp:Label id="lblCustFound" runat="server" CssClass="SearchingMessage">���Ȥ�@�� 0 ���X�����</asp:Label>
						<asp:LinkButton id="lnbBack" runat="server">�^�d�ߵe��</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD align="middle">
						<asp:DataGrid id="dgdCont" runat="server" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False" Width="90%">
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_aunm" HeaderText="�s�i�p���H�m�W"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_autel" HeaderText="�s�i�p���H�q��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="�@���I�M���O"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgclosed" HeaderText="���׵��O"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_disc" HeaderText="�u�f���"></asp:BoundColumn>
								<asp:ButtonColumn Text="�T�w���@" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
