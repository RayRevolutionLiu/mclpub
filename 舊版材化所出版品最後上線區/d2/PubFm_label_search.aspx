<%@ Page language="c#" Codebehind="PubFm_label_search.aspx.cs" Src="PubFm_label_search.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm_label_search" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�����s�i���� ���Z�n �B�J�@: �j�M</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
			<!-- ���Y: �D�\���� -->
			<kw:Header runat="server" />
		<center>
		</center>
		<!-- �ثe�Ҧb��m --><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT>
		<table dataFld="items" id="tbItems" align="left" border="0">
			<tr>
				<td align="middle"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�����s�i���� ���Z�n �B�J�@: �j�M</font>&nbsp;
				</td>
			</tr>
		</table>
		&nbsp; 
		<!-- Run at Server Form -->
		<form id="PubFm_label_search" method="post" runat="server">
			<asp:label id="lblQuery" runat="server" ForeColor="Blue" Font-Bold="True">�п�ܿz�����G</asp:label>
			<asp:label id="lblQuery2" runat="server" Font-Bold="True" ForeColor="MediumBlue" Font-Size="X-Small">(�d�ߵ��G���]�t '�w����/�w���P' ���X��)</asp:label><br>
			<asp:label id="lblBookCode" runat="server" Font-Size="X-Small">���y���O�G</asp:label><asp:dropdownlist id="ddlBookCode" runat="server">
				<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:label id="lblPubDate" runat="server" Font-Size="X-Small">�Z�n�~��G</asp:label><asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(�p 
				2002/08, �w�]��: ���)</font><br>
			<asp:checkbox id="cbx0" runat="server"></asp:checkbox><asp:label id="lblEmpNo" runat="server" Font-Size="X-Small">�X���ӿ�~�ȭ��G</asp:label><asp:dropdownlist id="ddlEmpNo" runat="server">
				<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:label id="lblConttp" runat="server" Font-Size="X-Small">�X�����O�G</asp:label><asp:dropdownlist id="ddlConttp" runat="server">
				<asp:ListItem Value="01" Selected="True">�@��</asp:ListItem>
				<asp:ListItem Value="09">���s</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">�l�H�a�ϡG</asp:label><asp:dropdownlist id="ddlfgMOSea" runat="server">
				<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
				<asp:ListItem Value="1">��~</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:checkbox id="cbx1" runat="server"></asp:checkbox>
			<asp:label id="lblv" runat="server" Font-Size="X-Small">�l�H���O�G</asp:label>
			<asp:dropdownlist id="ddlMtpcd" runat="server">
				<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:Label id="lblMemo1" runat="server" ForeColor="Maroon" Font-Size="X-Small">���G�p�n�b�����A�d�ߨ�L���, �Х��� '�M�����d', �A�� '�d��'���~��!<br> �n�������L���t�Τ��\��, �Ы� '��^����' ���s.</asp:Label>
			<br>
			<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>&nbsp;
			<asp:button id="btnClearAll" runat="server" Text="�M�����d"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnPrintList" runat="server" Text="�C�L�M��"></asp:button>&nbsp;
			<asp:button id="btnPrintLabel" runat="server" Text="�C�L����"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnBackHome" runat="server" Text="��^����"></asp:button>&nbsp;
			<asp:literal id="Literal1" runat="server"></asp:literal>
			<asp:TextBox id="tbxLoginEmpNo" runat="server" Font-Size="X-Small" Width="50px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxLoginEmpCName" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxBookPNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox><br>
			<asp:label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" GridLines="Vertical" BorderWidth="1px" BorderColor="#999999" BackColor="White" CellPadding="3" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="���q�W��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="�l�H�ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="�l�H�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="���n����"></asp:BoundColumn>
					<asp:BoundColumn DataField="mtp_nm" HeaderText="�l�H���O"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><br>
			<asp:RegularExpressionValidator id="revPubDate" Font-Size="X-Small" runat="server" ErrorMessage="'�Z�n�~��' �Ш̮榡��J(�аѮ����r����)!!!" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></form>
		<br>
			<!-- ���: ���v�� -->
			<kw:Footer runat="server" />
	</body>
</HTML>
