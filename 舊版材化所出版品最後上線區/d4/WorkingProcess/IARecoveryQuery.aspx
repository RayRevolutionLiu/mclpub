<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IARecoveryQuery.aspx.cs" src="IARecoveryQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IARecoveryQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IARecoveryQuery</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IARecoveryQuery" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td style="HEIGHT: 45px">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�o���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�j��뵲���o���}�߳�^�_(Recovery):�d�߱���</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<asp:Panel ID="pnlSearch" Runat="server" Width="100%">
<asp:label id="Label1" runat="server" Font-Size="Small" ForeColor="Blue" Font-Bold="True">�п�J�d�߱���</asp:label><FONT color="#cc33cc" size="2">
					(�Ъ`�N�G�w��|�p�t�ΰ��B�z���o���}�߳�L�k���^�_�I)</FONT><BR>�o���}�߳� <FONT color="blue">���ͦ~��</FONT>�G 
<asp:textbox id="tbxYYYYMM" runat="server" Width="58px"></asp:textbox>
<asp:label id="lblyyyymm" runat="server" ForeColor="#C04000">(�Ҧp : 2003/09)</asp:label>
<asp:regularexpressionvalidator id="revDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxYYYYMM" ErrorMessage="��J�榡���~"></asp:regularexpressionvalidator><BR>�o���}�߳� 
<FONT color="blue">���ͧ妸</FONT>�G 
<asp:textbox id="tbxBatch" runat="server" Width="58px"></asp:textbox>
<asp:label id="lblBatch" runat="server" ForeColor="#C04000">(�Ҧp : 000001)</asp:label><BR>
<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
<asp:label id="lblMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:label><BR>
			</asp:Panel>
			<asp:panel id="pnlCont" Runat="server" Visible="False">
				<asp:Button id="btnOK" runat="server" ForeColor="Red" Text="�T�w�^�_�o�@����"></asp:Button>
				<BR>
				<asp:datagrid id="dgdCont" runat="server" Width="90%" AutoGenerateColumns="False" CssClass="DataGridStyle">
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
						<asp:BoundColumn DataField="ia_status" HeaderText="�i�檬�A"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="ia_status"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</asp:panel>
			<asp:panel id="pnlBack" Runat="server" Width="100%" Visible="False">
				<P align="center">
					<asp:Button id="btnHome" Runat="server" Text="�^�D���"></asp:Button></P>
			</asp:panel>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
