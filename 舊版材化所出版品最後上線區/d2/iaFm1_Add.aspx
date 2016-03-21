<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="iaFm1_Add.aspx.cs" Src="iaFm1_Add.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_Add" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�o���}�߳沣�� - �@���I�� - �B�J�@: �D��o���t��</TITLE>
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
						�o���}�߳沣�� - �@���I�� - �B�J�@: �D��o���t��</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_Add" method="post" runat="server">
			<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
			<asp:Label id="lblMfrIName" runat="server" ForeColor="Maroon" Font-Size="X-Small">�t�ӦW�١G</asp:Label>
			<asp:TextBox id="tbxMfrIName" runat="server" Font-Size="X-Small" Width="120px" MaxLength="50"></asp:TextBox>
			&nbsp;
			<asp:Label id="lblMfrNo" runat="server" Font-Size="X-Small" ForeColor="#C00000"></asp:Label>
			<br>
			<asp:CheckBox id="cbx2" runat="server"></asp:CheckBox>
			<asp:Label id="lblIMName" runat="server" Font-Size="X-Small" ForeColor="Maroon">�o���t�Ӧ���H�m�W�G</asp:Label>
			<asp:TextBox id="tbxIMName" runat="server" Width="60px" MaxLength="30"></asp:TextBox>
			<asp:Button id="btnQuery" runat="server" Text="�d��"></asp:Button>
			&nbsp;
			<asp:Button id="btnClear" runat="server" Text="�M�����"></asp:Button>
			<br>
			<asp:Label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:Label>
			<br>
			<!-- �ާ@�B�J -->
			<asp:label id="lblMemo1" runat="server" ForeColor="#C04000" Font-Size="X-Small">�ާ@�B�J 1�G�ЬD���@���X���ѽs���εo���t�Ӧ���H, �A���U '�T�{�D��' ���s!</asp:label>
			<br>
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
		</form>
		<br>
		<!-- ���� Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
