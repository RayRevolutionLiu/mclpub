<%@ Page language="c#" Codebehind="iaFm1_Addia.aspx.cs" Src="iaFm1_Addia.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_Addia" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�o���}�߳沣�� - �@���I�� - �B�J�G: ���͵o���}�߳�</TITLE>
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
						�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�o���}�߳沣�� - �@���I�� - �B�J�G: ���͵o���}�߳�</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_Addia" method="post" runat="server">
			<asp:Label id="lblContNo" runat="server" Font-Size="X-Small"></asp:Label>
			&nbsp;
			<asp:Label id="lblIMSeq" runat="server" Font-Size="X-Small"></asp:Label>
			&nbsp;&nbsp;
			<asp:Label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
			<br>
			<asp:Label id="lblMfrCust" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:Label>
			&nbsp;
			<asp:Button id="btnShowFullCont" runat="server" Text="��ܦX���������" Width="120px"></asp:Button>
			<asp:Literal id="litWinOpen1" runat="server"></asp:Literal>
			<asp:TextBox id="tbxCustNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox>
			&nbsp;
			<asp:TextBox id="tbxbkcd" runat="server" Font-Size="X-Small" Width="30px" Visible="False"></asp:TextBox>
			&nbsp;
			<asp:TextBox id="tbxfgpubed" runat="server" Font-Size="X-Small" Width="20px" Visible="False"></asp:TextBox>
			<br>
			<br>
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J�G�Хh���ثe���n�}�ߪ���� (�Q�D��̷|�Q�}�ߦ��P�@�i�}�߳�), ���� '�T�{���B', �A���U '���͵o���}�߳�' ���s�ӧ���!</asp:label>
			<br>
			<asp:DataGrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="�D��">
						<ItemTemplate>
							<asp:CheckBox id="cbxSelect" runat="server" Checked="True"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="�Z�n���X"></asp:BoundColumn>
					<asp:BoundColumn DataField="ltp_nm" HeaderText="�s�i����"></asp:BoundColumn>
					<asp:BoundColumn DataField="clr_nm" HeaderText="�s�i��m"></asp:BoundColumn>
					<asp:BoundColumn DataField="pgs_nm" HeaderText="�s�i�g�T"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="�T�w����"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_drafttp" HeaderText="�Z�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fggot" HeaderText="��Z"></asp:BoundColumn>
					<asp:BoundColumn DataField="njtp_nm" HeaderText="�s�Z�s�k"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgbkcd" HeaderText="��Z���y"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgjno" HeaderText="��Z���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgjbkno" HeaderText="��Z���X"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgrechg" HeaderText="��Z���X��"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="�½Z���y"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_origjno" HeaderText="�½Z���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_origjbkno" HeaderText="�½Z���X"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_adamt" HeaderText="�s�i���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgamt" HeaderText="���Z���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="�����~�ȭ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_remark" HeaderText="�Ƶ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_projno" HeaderText="�p���N��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_costctr" HeaderText="��������"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
			</asp:DataGrid>
			<asp:Button id="btnConfirmAmt" runat="server" Text="�T�{���B"></asp:Button>
			<br>
			<br>
			<table width="100%" border="1" bordercolor="#336699" cellpadding="4" cellspacing="2">
				<tr>
					<td width="33%">
						<asp:Panel id="pnl1" runat="server" Font-Size="X-Small">
<asp:Label id="lblContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">�X�����B ��ơG</asp:Label><BR>�X�����B�G$ 
<asp:Label id="lblContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�wú���B�G$ 
<asp:Label id="lblContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�Ѿl���B�G$ 
<asp:Label id="lblContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
					</asp:Panel>
					</td>
					<td width="33%">
						<asp:Panel id="pnl2" runat="server" Font-Size="X-Small">
<asp:Label id="lblPickMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">�w�D����B ��ơG</asp:Label><BR>�`�s�i���B�G$ 
<asp:Label id="lblPickAdAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR><U>�`���Z���B�G</U>$ 
<asp:Label id="lblPickChgAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�w�D��p�p�G$ 
<asp:Label id="lblPickTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
</asp:Panel>
					</td>
					<td width="*">
						<asp:Panel id="pnl3" runat="server" Font-Size="X-Small">
<asp:Label id="lblNewContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">�N��s���X�����B ��ơG</asp:Label><BR>�X�����B�G$ 
<asp:Label id="lblNewContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�wú���B�G$ 
<asp:Label id="lblNewContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�Ѿl���B�G$ 
<asp:Label id="lblNewContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
</asp:Panel>
					</td>
				</tr>
			</table>
			<asp:Button id="btnAddia" runat="server" Text="���͵o���}�߳�"></asp:Button>
			&nbsp;&nbsp;
			<asp:Button id="btnModifyCont" runat="server" Text="�ק�X����"></asp:Button>
			&nbsp;
			<asp:Button id="btnModifyPub" runat="server" Text="�ק︨��"></asp:Button>
			<asp:TextBox id="tbxIANo" runat="server" Font-Size="X-Small" Width="100px" Visible="False"></asp:TextBox>
		</form>
		<br>
		<!-- ���� Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
