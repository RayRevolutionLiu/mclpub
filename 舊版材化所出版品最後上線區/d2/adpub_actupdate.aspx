<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="adpub_actupdate.aspx.cs" Src="adpub_actupdate.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_actupdate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���s�˫�ץ� �B�J�G (�e���P �s�i�����ʧ@ �B�J�G)</title>
		<META content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"> <!-- CSS --><LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY>
		<CENTER>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<TABLE dataFld="items" id="tbItems" align="left">
				<TR>
					<TD align="left"><FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							���s�˫�ק�&nbsp; </FONT>
					</TD>
				</TR>
			</TABLE>
			&nbsp; 
			<!-- Run at Server Form -->
			<FORM id="adpub_actupdate" method="post" runat="server">
				<DIV align="left"><FONT color="#990033" size="2">�ާ@�����G�п�J�z�n�ק諸���, �̫���U���������B�� '�T�{��s' 
						���s�Y�i.
						<br>
						���G �s�Z�s�k�G�п�J "�N�X", �ſ�J��W��; �Y�����N�X, �i���k��ϥܨӰѦ�!
						<br>
						���G ��Z���X���G�Y�O���X, �ФĿ�; �_��, �ФŤĿ�</FONT>
				</DIV>
				<asp:literal id="litAlertWin" runat="server"></asp:literal><asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="False">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="����" HeaderText="����"></asp:BoundColumn>
						<asp:BoundColumn DataField="�X���ѽs��" HeaderText="�X���ѽs��"></asp:BoundColumn>
						<asp:BoundColumn DataField="�Z�n�~��" HeaderText="�Z�n�~��"></asp:BoundColumn>
						<asp:BoundColumn DataField="�����Ǹ�" HeaderText="�����Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="�Z�n���X" HeaderText="�Z�n���X"></asp:BoundColumn>
						<asp:BoundColumn DataField="�s�i����" HeaderText="�s�i����"></asp:BoundColumn>
						<asp:BoundColumn DataField="�s�i��m" HeaderText="�s�i��m"></asp:BoundColumn>
						<asp:BoundColumn DataField="�s�i�g�T" HeaderText="�s�i�g�T"></asp:BoundColumn>
						<asp:BoundColumn DataField="�T�w�������O" HeaderText="�T�w����">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="���q�W��" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Z���O" HeaderText="��Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="njtp_nostr" HeaderText="(�Ѧҷs�Z�s�k)"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="�s�Z�s�k�N�X">
							<ItemStyle Width="55px"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox id="tbxNjtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "�s�Z�s�k�N�X").ToString().Trim() %>' MaxLength="2" Width="30px" Font-Size="X-Small" Visible='<%# GetVisiblity1(DataBinder.Eval(Container.DataItem, "�Z�����O�N�X").ToString().Trim()) %>' OnTextChanged='<%# CheckNjtpcd(DataBinder.Eval(Container.DataItem, "�s�Z�s�k�N�X").ToString()) %>'>
								</asp:TextBox>
								<IMG class="ico" id="imgNjtpcd" onclick="javascript:window.open('njtp_detail.aspx', '_new', 'Height=300, Width=380, Top=100, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="�s�Z�s�k���" src="../images/edit.gif" width="18" border="0">
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="��Z���y�N�X" HeaderText="��Z���y"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Z���O" HeaderText="��Z���O"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="��Z���X">
							<ItemTemplate>
								<asp:TextBox id="tbxChgJBkNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "��Z���X").ToString().Trim() %>' Visible='<%# GetVisiblity2(DataBinder.Eval(Container.DataItem, "�Z�����O�N�X").ToString().Trim()) %>' Width="30px" Font-Size="X-Small" MaxLength="3">
								</asp:TextBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="��Z���X��">
							<ItemTemplate>
								<asp:CheckBox id="cbxfgReChg" runat="server" Checked='<%# GetfgReChg(DataBinder.Eval(Container.DataItem, "��Z���X�����O")) %>'>
								</asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="�½Z���y�W��" HeaderText="�½Z���y"></asp:BoundColumn>
						<asp:BoundColumn DataField="�½Z���O" HeaderText="�½Z���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="�½Z���X" HeaderText="�½Z���X"></asp:BoundColumn>
						<asp:BoundColumn DataField="�����~�ȭ��m�W" HeaderText="�����~�ȭ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="�Ƶ�" HeaderText="�Ƶ�"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="�Z�����O�N�X" HeaderText="�Z�����O"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="��Z���X" HeaderText="��Z���X"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="��Z���X�����O" HeaderText="��Z���X�����O"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="���s�˫�ק���O" HeaderText="���s�˫�ק���O"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="���s�˫�ק�">
							<ItemStyle Width="30px"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox id="tbxfgupdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "���s�˫�ק���O").ToString().Trim() %>' MaxLength="1" Width="20px" Font-Size="X-Small" Visible='<%# GetfgUpdated(DataBinder.Eval(Container.DataItem, "�Z�����O�N�X").ToString().Trim()) %>' OnTextChanged='<%# CheckfgUpdated(DataBinder.Eval(Container.DataItem, "���s�˫�ק���O").ToString().Trim()) %>'>
								</asp:TextBox>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid><br>
				<br>
				<asp:button id="btnUpdate" runat="server" Text="�T�{��s"></asp:button>&nbsp;
				<asp:button id="btnCancel" runat="server" Text="�����^����"></asp:button><br>
			</FORM>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</CENTER>
	</BODY>
</HTML>
