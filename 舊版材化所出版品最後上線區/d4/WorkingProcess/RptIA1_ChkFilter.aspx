<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RptIA1_ChkFilter.aspx.cs" src="RptIA1_ChkFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptIA1_ChkFilter" %>
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
										��@�t�Ӥ��o���}�߳��ˮ֪�G�C�L</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="700" border="0">
							<TR>
								<TD class="TableColorHeader"><asp:label id="Label1" runat="server" ForeColor="Yellow">** �Ъ`�N�G�w��|�p�t�ΰ��B�z���o���}�߳�L�k�A�C�L�ˮ֪�I**</asp:label></TD>
							</TR>
							<tr>
								<td><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Small"></asp:label><asp:datagrid id="dgdIA" runat="server" Width="100%" CssClass="DataGridStyle" AutoGenerateColumns="False">
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
											<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" HeaderText="�C�L�ˮ֪�" CommandName="Select"></asp:ButtonColumn>
										</Columns>
									</asp:datagrid><asp:panel id="pnlBack" Width="100%" Visible="False" Runat="server">
										<P align="center">
											<asp:Button id="btnHome" Text="�^�D���" Runat="server"></asp:Button></P>
									</asp:panel></td>
							</tr>
						</TABLE>
						<asp:literal id="Literal1" runat="server"></asp:literal></td>
				</tr>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
