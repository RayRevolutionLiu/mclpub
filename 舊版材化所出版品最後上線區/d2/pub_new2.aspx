<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="pub_new2.aspx.cs" Src="pub_new2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.pub_new2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>����: �s�W/���@/�R������ - �Ѧ~�븨���i�J �B�J�@ (�D��X����)</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							����: �s�W/���@/�R������ - �Ѧ~�븨���i�J&nbsp;�B�J�@ (�D��X����)</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="pub_new2" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">�d�߱���</font>
						</td>
					</tr>
					<TR>
						<TD>
							�X���s���G<asp:textbox id="tbxContNo" tabIndex="5" runat="server" Width="60px" AutoPostBack="True" MaxLength="6"></asp:textbox>
							&nbsp;
							<br>
							<br>
							�Z�n�~��G
							<asp:textbox id="tbxPubDate" runat="server" Width="60px" MaxLength="6"></asp:textbox>&nbsp; 
							<!-- �d�߫��s --><asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp; 
							<!-- �d�ߵ��G��� --><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
							<br>
							(�п�J 4~6�X�Ʀr, �p2002�~ 1��, �п�J 200201)
						</TD>
						<td>
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J������Ӭd��, �M����U "�d��".<br>
							2. �d�X��ƫ�, ���U "�ק︨��" �ӭק���.<br>3. �d�ߵ��G���]�t<font color='Red'>�w���ס��w���P</font>���X�����.<br> 4. �Y�������ק蠟�X���ѽs��, �i�� ���s��<br> &nbsp;&nbsp;&nbsp;&nbsp; <A href="cont_main1.aspx" target="_self">
									�X���ѳB�z/�@��X��/�X���Ѻ��@</A> �Ӭd�߭ק�.</asp:label>
						</td>
					</TR>
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
									<asp:BoundColumn DataField="bk_nm" HeaderText="���y���O"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cont_bkcd" HeaderText="���y���O�N�X"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgpubed" HeaderText="�w����"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cont_fgpubed" HeaderText="�w�����N�X"></asp:BoundColumn>
									<asp:ButtonColumn Text="����" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
