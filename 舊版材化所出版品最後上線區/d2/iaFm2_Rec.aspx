<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_Rec.aspx.cs" Src="iaFm2_Rec.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_Rec" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�o���}�߳�^�_(Recovery) - �j��뵲 �B�J�@</TITLE>
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
						�o���}�߳�^�_(Recovery) - �j��뵲 �B�J�@</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_Rec" method="post" runat="server">
			<asp:checkbox id="cbx1" runat="server"></asp:checkbox><asp:label id="lblMfrIName" runat="server" Font-Size="X-Small" ForeColor="Maroon">�t�ӦW�١G</asp:label><asp:textbox id="tbxMfrIName" runat="server" Font-Size="X-Small" Width="120px" MaxLength="50"></asp:textbox>&nbsp;
			<asp:label id="lblMfrNo" runat="server" Font-Size="X-Small" ForeColor="#C00000"></asp:label>&nbsp;
			<asp:TextBox id="tbxMfrNo" runat="server" Font-Size="X-Small" Width="80px" Visible="False"></asp:TextBox><br>
			<asp:checkbox id="cbx2" runat="server"></asp:checkbox><asp:label id="lblIMName" runat="server" Font-Size="X-Small" ForeColor="Maroon">�o���t�Ӧ���H�m�W�G</asp:label><asp:textbox id="tbxIMName" runat="server" Width="60px" MaxLength="30"></asp:textbox><br>
			<asp:checkbox id="cbx3" runat="server"></asp:checkbox><asp:label id="lblIANo" runat="server" Font-Size="X-Small" ForeColor="Maroon">�o���}�߳渹�X�G</asp:label><asp:textbox id="tbxIANo" runat="server" Width="80px" MaxLength="8"></asp:textbox>&nbsp;
			<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>
			&nbsp;
			<asp:Button id="btnClear" runat="server" Text="�M�����"></asp:Button><br>
			<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:label>
			<br>
			<!-- �ާ@�B�J -->
			<asp:label id="Label1" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J 1�G�ЬD��n�^�_���X���ѽs���εo���t�Ӧ���H, �A���U '�T�{�D��' ���s!</asp:label><br>
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J 2�G�ЬD��n�^�_���o���}�߳�s��, �A���U '�T�{�D��' ���s!</asp:label><br>
			<!-- �X�� & �o���t�Ӹ�� DataGrid1 -->
			<asp:DataGrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="�T�{�D��" ButtonType="PushButton" HeaderText="�D��" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="�o�t�Ǹ�">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="�o�t����H">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
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
					<asp:BoundColumn Visible="False" DataField="cont_fgclosed" HeaderText="���׵��O"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
			</asp:DataGrid><br>
			<asp:TextBox id="tbxContNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False" MaxLength="6"></asp:TextBox>
			<asp:TextBox id="tbxIMSeq" runat="server" Font-Size="X-Small" Width="30px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxIMName2" runat="server" Font-Size="X-Small" Width="80px" Visible="False"></asp:TextBox><br>
			<asp:DataGrid id="DataGrid2" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="�T�{�D��" ButtonType="PushButton" HeaderText="�D��" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="ia_iano" HeaderText="�o���}�߳�s��">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="�t�ӽs��">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="�ٿ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="�o���l�H�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_status" HeaderText="�ثe���A"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invno" HeaderText="�o�����X"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_status" HeaderText="�ثe���A"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_pyat" HeaderText="�t�|(��I)���B"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ia_contno" HeaderText="�X���s��"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
			</asp:DataGrid><br>
		</form>
		<asp:label id="lblMemo1" runat="server" ForeColor="Blue" Font-Size="X-Small">����1�G<br>����C�ܤ��o���}�߳�O�|�����͵o���}�߲M��B�|��ú�ڤ����, <br>�w���͵o���}�߲M��Τwú�ڤ��o����Ƥ��|�b���C��</asp:label>
		<!-- ���� Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
