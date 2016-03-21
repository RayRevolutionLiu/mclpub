<%@ Page language="c#" Codebehind="ContFm_chk1.aspx.cs" Src="ContFm_chk1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_chk1" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�X���� ���~��ƲM��</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- ���� Header -->
		<center>
			<kw:header id="Header" runat="server"></kw:header>
		</center>
		<!-- �ثe�Ҧb��m -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left">
					<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�X���� ���~��ƲM��</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="ContFm_chk1" method="post" runat="server">
			�п�ܱz�n�d�ߪ����ءG<asp:DropDownList id="ddlFilter" runat="server">
				<asp:ListItem Value="1">�m�M�¦��ƬҬ���</asp:ListItem>
				<asp:ListItem Value="2">�ӿ�~�ȭ���Ƥ�����</asp:ListItem>
			</asp:DropDownList>
			<asp:Button id="btnQuery" runat="server" Text="�d��"></asp:Button>
			&nbsp;
			<asp:Button id="btnClearAll" runat="server" Text="�M�����d"></asp:Button>
			<br>
			<asp:Label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:Label>
			<br>
			<br>
			<!-- ���� Footer -->
			<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="���y���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_aunm" HeaderText="�s�i�p���H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_autel" HeaderText="�s�i�p���H�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="�@���I�M"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_fgclosed" HeaderText="�w����"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_disc" HeaderText="�u�f���"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_clrtm" HeaderText="�m�⦸��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_getclrtm" HeaderText="�M�⦸��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_menotm" HeaderText="�¥զ���"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_fgpubed" HeaderText="�w����"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_fgcancel" HeaderText="�w���P"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="�~�ȭ�"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cont_oldcontno" HeaderText="�¦X���s��"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
					<asp:ButtonColumn Text="��ܦX�����v" CommandName="Show"></asp:ButtonColumn>
					<asp:ButtonColumn Text="�T�w�ק�" ButtonType="PushButton" CommandName="Modify"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
		<!-- ���� Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
