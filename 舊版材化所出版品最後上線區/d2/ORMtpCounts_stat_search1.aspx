<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="ORMtpCounts_stat_search1.aspx.cs" SRC="ORMtpCounts_stat_search1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORMtpCounts_stat_search1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�L�s���Ʋέp�� ���Z�n �B�J�@: �j�M</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�έp�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �L�s���Ʋέp�� 
							���Z�n �B�J�@: �j�M</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="ORMtpCounts_stat_search1" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td colSpan="2"><font color="white">�d�߱���</font>
							</td>
						</tr>
						<TR>
							<TD width="*"><asp:checkbox id="cbx0" runat="server"></asp:checkbox><asp:label id="lblConttp" runat="server" Font-Size="X-Small">�X�����O�G</asp:label><asp:dropdownlist id="ddlConttp" runat="server">
									<asp:ListItem Value="01" Selected="True">�@��</asp:ListItem>
									<asp:ListItem Value="09">���s</asp:ListItem>
								</asp:dropdownlist><br>
								<asp:label id="lblBookCode" runat="server">���y���O�G</asp:label><asp:dropdownlist id="ddlBookCode" runat="server">
									<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
									<asp:ListItem Value="01">�u��</asp:ListItem>
									<asp:ListItem Value="02">�q��</asp:ListItem>
									<asp:ListItem Value="04">�q���O��</asp:ListItem>
									<asp:ListItem Value="05">����</asp:ListItem>
								</asp:dropdownlist><br>
								<br>
								<asp:label id="lblPubDate" runat="server">�Z�n�~��G</asp:label><asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(�p 
									2002/08, �w�]��: ���)</font><br>
								<asp:checkbox id="cbx1" runat="server"></asp:checkbox><asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">�l�H�a�ϡG</asp:label><asp:dropdownlist id="ddlfgMOSea" runat="server">
									<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
									<asp:ListItem Value="1">��~</asp:ListItem>
								</asp:dropdownlist><br>
								<asp:label id="lblMailType" runat="server">�l�H�覡�G</asp:label><asp:dropdownlist id="ddlMailType" runat="server">
									<asp:ListItem Value="0" Selected="True">�j�v�l�H</asp:ListItem>
									<asp:ListItem Value="1">���o�Ǹg��</asp:ListItem>
								</asp:dropdownlist>&nbsp;&nbsp; 
								<!-- �d�߫��s --><asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;
									<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>&nbsp;<br>
								<!-- �d�ߵ��G��� --><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
							<TD vAlign="top" align="left" width="50%"><asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
2. �d�ߵ��G���]�t '<font color='Red'>�w����/�w���P</font>' ���X��.<br> 3. �X�{���G��, �Ы� "<font color="blue">�C�L�������C�L�M��</font>" �ӦC�L���G!<br>���l�H�覡�� '�j�v�l�H' �O���ϥ� '�ꤺ���q�l�H' ���覡; <br>��'���o�Ǹg��' �O���ϥ� �D '�ꤺ���q�l�H' ���覡.</asp:label><asp:textbox id="tbxLoginEmpNo" runat="server" Font-Size="X-Small" Width="50px" Visible="False"></asp:textbox><asp:textbox id="tbxLoginEmpCName" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:textbox></TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2">&nbsp;
								<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxPubDate" ErrorMessage="'�Z�n�~��' �Ш̮榡��J(�аѮ����r����)!!!"></asp:RegularExpressionValidator>
								<asp:Literal id="Literal1" runat="server"></asp:Literal>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
				<asp:panel id="pnlCounts" runat="server">
<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="2" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
						<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
						<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
						<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
						<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
						<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
						<Columns>
							<asp:BoundColumn DataField="cont_conttpName" HeaderText="�X�����O"></asp:BoundColumn>
							<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
							<asp:BoundColumn DataField="mtp_nm" HeaderText="�l�H���O�W��"></asp:BoundColumn>
							<asp:BoundColumn DataField="or_pubcnt" HeaderText="���n����"></asp:BoundColumn>
							<asp:BoundColumn DataField="PubCounts" HeaderText="����"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="cont_conttp" HeaderText="�X�����O�N�X"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="or_mtpcd" HeaderText="�l�H���O�N�X"></asp:BoundColumn>
							<asp:BoundColumn DataField="SumCounts" HeaderText="�p�p����"></asp:BoundColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					</asp:datagrid><BR>
<INPUT id="btnPrint" onclick="Javascript:window.print();" type="button" value="�C�L����" name="btnPrint">&nbsp; 
<asp:Button id="btnPrintList" runat="server" Text="�C�L�M��"></asp:Button></asp:panel></form>
			<br>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
