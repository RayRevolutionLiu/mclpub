<%@ Page language="c#" Codebehind="Pub_LabelFilter.aspx.cs" src="Pub_LabelFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.Pub_LabelFilter" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Pub_LabelFilter</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Pub_LabelFilter" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										���ҳB�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�j�v����(���Z�n)</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE class="TableColor" style="WIDTH: 604px" cellSpacing="0" cellPadding="2">
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="2">�d�߱���
									<asp:label id="Label1" runat="server" ForeColor="Yellow">(�d�ߵ��G���]�t '�w����/�w���P' ���X��)</asp:label></td>
							</tr>
							<tr>
								<td align="right" width="30%"><asp:label id="lblBookCode" runat="server" Font-Size="X-Small">���y���O�G</asp:label></td>
								<td><asp:dropdownlist id="ddlBookCode" runat="server">
										<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblPubDate" runat="server" Font-Size="X-Small">�Z�n�~��G</asp:label></td>
								<td><asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(�p 
										2003/10, �w�]��: ���)
										<asp:regularexpressionvalidator id="revPubDate" runat="server" Font-Size="X-Small" ErrorMessage="��J�榡���~" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}"></asp:regularexpressionvalidator></font></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblConttp" runat="server" Font-Size="X-Small">�X�����O�G</asp:label></td>
								<td><asp:dropdownlist id="ddlConttp" runat="server">
										<asp:ListItem Value="01" Selected="True">�@��</asp:ListItem>
										<asp:ListItem Value="09">���s</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">�l�H�a�ϡG</asp:label></td>
								<td><asp:dropdownlist id="ddlfgMOSea" runat="server">
										<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
										<asp:ListItem Value="1">��~</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxMtpcd" runat="server"></asp:checkbox><asp:label id="lblMtpcd" runat="server" Font-Size="X-Small">�l�H���O�G</asp:label></td>
								<td><asp:dropdownlist id="ddlMtpcd" runat="server">
										<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxEmpno" runat="server"></asp:checkbox><asp:label id="lblEmpNo" runat="server" Font-Size="X-Small">�X���ӿ�~�ȭ��G</asp:label></td>
								<td><asp:dropdownlist id="ddlEmpNo" runat="server">
										<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</TABLE>
						<br>
						<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button><asp:button id="btnPrintList" runat="server" Text="�C�L�M��"></asp:button><asp:button id="btnPrintLabel" runat="server" Text="�C�L����"></asp:button><asp:button id="btnBackHome" runat="server" Text="��^����"></asp:button>&nbsp;
						<asp:literal id="Literal1" runat="server"></asp:literal><br>
						<asp:label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><br>
						<asp:datagrid id="dgdLabel" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
							<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
								<asp:BoundColumn DataField="ma_sdate" HeaderText="�ؾ\�_��"></asp:BoundColumn>
								<asp:BoundColumn DataField="ma_edate" HeaderText="�ؾ\����"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_inm" HeaderText="���q�W��"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_zip" HeaderText="�l�H�ϸ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_addr" HeaderText="�l�H�a�}"></asp:BoundColumn>
								<asp:BoundColumn DataField="ma_mnt" HeaderText="���n����"></asp:BoundColumn>
								<asp:BoundColumn DataField="mtp_nm" HeaderText="�l�H���O"></asp:BoundColumn>
							</Columns>
						</asp:datagrid><br>
						<input id="hiddenBookNm" type="hidden" name="hiddenBookNm" runat="server"> <input id="hiddenBookPno" type="hidden" name="hiddenBookPno" runat="server">
					</td>
				</tr>
			</TABLE>
			<br>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
