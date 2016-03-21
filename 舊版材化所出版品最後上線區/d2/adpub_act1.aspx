<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="adpub_act1.aspx.cs" Src="adpub_act1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_act1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i�ƪ��ʧ@ �B�J�@ / ���s�˫�ץ� �B�J�@</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left">
				<tr>
					<td align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�i�ƪ��ʧ@ �B�J�@ / ���s�˫�ץ� �B�J�@</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_act1" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">�d�߱���</font>
						</td>
					</tr>
					<TR>
						<TD width="*">
							���y���O�G
							<asp:dropdownlist id="ddlBookCode" runat="server">
								<asp:ListItem Value="00" Selected="True">�п��...</asp:ListItem>
								<asp:ListItem Value="01">�u��</asp:ListItem>
								<asp:ListItem Value="02">�q��</asp:ListItem>
								<asp:ListItem Value="04">�q���O��</asp:ListItem>
								<asp:ListItem Value="05">����</asp:ListItem>
							</asp:dropdownlist>
							<br>
							<br>
							�Z�n�~��G
							<asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp; 
							<!-- �d�߫��s -->
							<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;&nbsp;
							<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>
							<br>
							<font color="gray">(�п�J 6�X�~��, �p2002�~ 1��, �п�J&nbsp;2002/01)</font>
							<br>
							<br>
							<!-- �d�ߵ��G��� -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD vAlign="top" align="left" width="50%">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
								2. �X�{���G��, �Y�����~���, �N�n�D���ץ�; <br>&nbsp;&nbsp;&nbsp;&nbsp;�Y�L���~�������, �ЦA���U "<font color="blue">
									<U>���s��</U></font>" �Ӷi��ƪ��ʧ@!</asp:label>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff" colSpan="2">&nbsp;
							<asp:RegularExpressionValidator id="revPubDate" runat="server" ErrorMessage="'�Z�n�~��' �Ш̮榡��J(�аѮ����r����)!!!" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:RegularExpressionValidator>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff" colSpan="2">
							<asp:datagrid id="DataGrid1" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Runat="server">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="pub_contno" HeaderText="�X���ѽs��"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_ltpcd" HeaderText="�s�i����"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_clrcd" HeaderText="�s�i��m"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pgscd" HeaderText="�s�i�g�T"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_fggot" HeaderText="��Z"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_drafttp" HeaderText="�Z�����O"></asp:BoundColumn>
									<asp:ButtonColumn Text="�ק︨�����" ButtonType="PushButton" HeaderText="�ק︨�����" CommandName="Select"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff" colSpan="2">
							<asp:datagrid id="DataGrid2" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Runat="server">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="pub_contno" HeaderText="�X���ѽs��"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pgno" HeaderText="�Z�n���X">
										<ItemStyle ForeColor="Red"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="�T�w����">
										<ItemStyle ForeColor="Red"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="pub_ltpcd" HeaderText="�s�i����">
										<ItemStyle ForeColor="Blue"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="pub_clrcd" HeaderText="�s�i��m"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pgscd" HeaderText="�s�i�g�T"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_fggot" HeaderText="��Z"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_drafttp" HeaderText="�Z�����O"></asp:BoundColumn>
									<asp:ButtonColumn Text="�ק︨�����" ButtonType="PushButton" HeaderText="�ק︨�����" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</BODY>
</HTML>
