<%@ Page language="c#" Codebehind="adpub_actupdate.aspx.cs" Src="adpub_actupdate.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_actupdate" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���s�˫�ץ� �B�J�G (�e���P �s�i�����ʧ@ �B�J�G)</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<CENTER>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left">
				<tr>
					<td align="left">
						<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							���s�˫�ק�&nbsp; </FONT>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_actupdate" method="post" runat="server">
				<div align="left">
					<font color="#990033" size="2">�ާ@�����G�Хѳ̥k����� '�Ŀ�' �z�n����s�����, �̫���U���������B�� '�T�{��s' ���s�Y�i.</font>
				</div>
				<div align="Right">
					<font color="DarkBlue" size="2">(�C����� 50�����.)</font>
					<br>
				</div>
				<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True" PageSize="50">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="����" HeaderText="����"></asp:BoundColumn>
						<asp:BoundColumn DataField="�X���ѽs��" HeaderText="�X���ѽs��"></asp:BoundColumn>
						<asp:BoundColumn DataField="�����Ǹ�" HeaderText="�����Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="�Z�n�~��" HeaderText="�Z�n�~��"></asp:BoundColumn>
						<asp:BoundColumn DataField="�Z�n���X" HeaderText="�Z�n���X"></asp:BoundColumn>
						<asp:BoundColumn DataField="�s�i��m" HeaderText="�s�i��m"></asp:BoundColumn>
						<asp:BoundColumn DataField="�s�i�g�T" HeaderText="�s�i�g�T"></asp:BoundColumn>
						<asp:BoundColumn DataField="�s�i����" HeaderText="�s�i����"></asp:BoundColumn>
						<asp:BoundColumn DataField="�T�w�������O" HeaderText="�T�w����">
							<ItemStyle HorizontalAlign="Center">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="���q�W��" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="�s�Z�s�k" HeaderText="�s�Z�s�k"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Z���O" HeaderText="��Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Z���y�N�X" HeaderText="��Z���y"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Z���O" HeaderText="��Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Z���X" HeaderText="��Z���X"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Z���X�����O" HeaderText="��Z���X�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="�½Z���y�W��" HeaderText="�½Z���y"></asp:BoundColumn>
						<asp:BoundColumn DataField="�½Z���O" HeaderText="�½Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="�½Z���X" HeaderText="�½Z���X"></asp:BoundColumn>
						<asp:BoundColumn DataField="�����~�ȭ��m�W" HeaderText="�����~�ȭ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="�Ƶ�" HeaderText="�Ƶ�"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="���s�˫�ק���O">
							<ItemTemplate>
								<asp:CheckBox id="cbxUpdate" runat="server" Checked='<%# GetfgUpdate(DataBinder.Eval(Container.DataItem, "���s�˫�ק���O")) %>'></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid>
				<br>
				<br>
				<asp:button id="btnUpdate" runat="server" Text="�T�{��s"></asp:button>
				<FONT face="�s�ө���">&nbsp;
					<asp:Button id="btnCancel" runat="server" Text="�����^����"></asp:Button>
				</FONT>
				<br>
			</form>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</CENTER>
	</body>
</HTML>
