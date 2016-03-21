<%@ Page language="c#" Codebehind="ContQueryHistory.aspx.cs" Src="ContQueryHistory.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContQueryHistory" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
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
		<form id="ContQueryHistory" method="post" runat="server">
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
										�s�W�X���� �B�J�G: �D�X���v�X���Ѹ��</FONT>
								</TD>
							</TR>
						</TABLE>
						<asp:Panel id="pnlNoHistory" runat="server" Width="100%">
							<asp:Label id="lblNoHistory" runat="server" CssClass="ImportantLabel">���Ȥ�|�L���v�X��...</asp:Label>
							<asp:Button id="btnNewCont" runat="server" Text="�s�W�X����"></asp:Button>
						</asp:Panel>
					</td>
				</tr>
				<TR>
					<TD align="middle">
						<asp:Label id="lblCustFound" runat="server" CssClass="SearchingMessage">���Ȥ�@�� 0 �����v���</asp:Label>
						<asp:LinkButton id="lnbBack" runat="server">�^�d�ߵe��</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD align="middle">
						<asp:DataGrid id="dgdCont" runat="server" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False" Width="90%">
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��">
									<HeaderStyle Width="50px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����">
									<HeaderStyle Width="65px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��">
									<HeaderStyle Width="65px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_edate" HeaderText="�X������">
									<HeaderStyle Width="65px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��">
									<HeaderStyle Width="150px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_aunm" HeaderText="�s�i�p���H�m�W">
									<HeaderStyle Width="70px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_autel" HeaderText="�s�i�p���H�q��">
									<HeaderStyle Width="90px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="�@���I�M���O">
									<HeaderStyle Width="40px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_fgclosed" HeaderText="���׵��O">
									<HeaderStyle Width="30px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O">
									<HeaderStyle Width="30px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cont_disc" HeaderText="�u�f���">
									<HeaderStyle Width="30px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="�H���X�����d���A�s�W�X��" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
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
