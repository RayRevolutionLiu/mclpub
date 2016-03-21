<%@ Page language="c#" Codebehind="iaFm1_Recia.aspx.cs" Src="iaFm1_Recia.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_Recia" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���}�߳�^�_(Recovery) - �@���I�� �B�J�G: �^�_�o���}�߳�</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�o���}�߳�^�_(Recovery) - �@���I�� �B�J�G: �^�_�o���}�߳�</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_Recia" method="post" runat="server">
			<asp:label id="lblContNo" runat="server" Font-Size="X-Small"></asp:label>&nbsp;
			<asp:label id="lblIMSeq" runat="server" Font-Size="X-Small"></asp:label>&nbsp;&nbsp;
			<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label><br>
			<asp:label id="lblMfrCust" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label>&nbsp;
			<asp:button id="btnShowFullCont" runat="server" Width="120px" Text="��ܦX���������"></asp:button><asp:literal id="litWinOpen1" runat="server"></asp:literal><asp:textbox id="tbxCustNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:textbox>&nbsp;
			<asp:textbox id="tbxbkcd" runat="server" Font-Size="X-Small" Width="30px" Visible="False"></asp:textbox>&nbsp;
			<asp:textbox id="tbxfgpubed" runat="server" Font-Size="X-Small" Width="20px" Visible="False"></asp:textbox><br>
			<br>
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J�G��i�o���}�߳�óQ�^�_, �Х��� '�T�{���B', �A���U '�^�_�o���}�߳�' ���s�ӧ���!</asp:label><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="�o�t�Ǹ�">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="�o�t����H">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="���y���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�W��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_totjtm" HeaderText="�`�s�Z"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_tottm" HeaderText="�`�Z�n"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_totamt" HeaderText="�`���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_paidamt" HeaderText="�w�I���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_restamt" HeaderText="�Ѿl���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_fgclosed" HeaderText="����"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="�ӿ�~�ȭ�"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><br>
			<asp:label id="lblIAMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label><asp:datagrid id="DataGrid2" runat="server" Font-Size="8pt" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="1">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="�ٿ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="�o���l�H�a�}">
						<HeaderStyle Wrap="False"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_iaditem" HeaderText="�o���}�߳���ӧǸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk1" HeaderText="�X���s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk2" HeaderText="�Z�n�~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk3" HeaderText="�����Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_desc" HeaderText="�~�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_projno" HeaderText="�p���N��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_costctr" HeaderText="��������"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_qty" HeaderText="�ƶq"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_amt" HeaderText="���B"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><br>
			<br>
			<table borderColor="#336699" cellSpacing="2" cellPadding="4" width="100%" border="1">
				<tr>
					<td width="33%"><asp:panel id="pnl1" runat="server" Font-Size="X-Small">
<asp:Label id="lblContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">�X�����B ��ơG</asp:Label><BR>�X�����B�G$ 
<asp:Label id="lblContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�wú���B�G$ 
<asp:Label id="lblContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�Ѿl���B�G$ 
<asp:Label id="lblContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></asp:panel></td>
					<td width="33%"><asp:panel id="pnl2" runat="server" Font-Size="X-Small">
<asp:Label id="lblPickMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">���}�߳��`���B ��ơG</asp:Label><BR>$ 
<asp:Label id="lblPickTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></asp:panel></td>
					<td width="*"><asp:panel id="pnl3" runat="server" Font-Size="X-Small">
<asp:Label id="lblNewContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">�N��s���X�����B ��ơG</asp:Label><BR>�X�����B�G$ 
<asp:Label id="lblNewContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�wú���B�G$ 
<asp:Label id="lblNewContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>�Ѿl���B�G$ 
<asp:Label id="lblNewContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></asp:panel></td>
				</tr>
			</table>
			<asp:button id="btnRecia" runat="server" Text="�^�_�o���}�߳�"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModifyCont" runat="server" Text="�ק�X����"></asp:button>&nbsp;
			<asp:button id="btnModifyPub" runat="server" Text="�ק︨��"></asp:button></form>
		<br>
		<!-- ���� Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
