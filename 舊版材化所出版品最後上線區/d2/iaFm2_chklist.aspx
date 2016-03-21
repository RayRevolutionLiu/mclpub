<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_chklist.aspx.cs" Src="iaFm2_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_chklist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�w�� �o���}�߳� - �j��뵲</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
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
						�w�� �o���}�߳� - �j��뵲</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_chklist" method="post" runat="server">
			<asp:label id="lblRecordCount" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label>&nbsp;
			<asp:textbox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:textbox>&nbsp;
			<asp:Button id="btnBack" runat="server" Text="��^�e�@�B�J"></asp:Button><br>
			<asp:label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">����1�G<br>���ˮ֪�C�ܤ��o���}�߳�O�|�����͵o���}�߲M�椧���, <br>�w���͵o���}�߲M�椧�o����Ƥ��|�b���C��.<br>���]�t�w���פ����.</asp:label><br>
			<asp:panel id="pnlChklist" runat="server">
				<asp:Label id="lblChklist" runat="server" ForeColor="Blue" Font-Bold="True">�w���o���}�߳�G</asp:Label>
				<BR>
				<asp:DataGrid id="DataGrid1" runat="server" Font-Size="8pt" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
					<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
					<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="�o������H"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_addr" HeaderText="�o���l�H�a�}">
							<HeaderStyle Wrap="False"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_invcd" HeaderText="�o�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="�~�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="proj_projno" HeaderText="�p���N��"></asp:BoundColumn>
						<asp:BoundColumn DataField="proj_costctr" HeaderText="��������"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_count" HeaderText="�ƶq"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_totamt" HeaderText="���B"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="pub_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<DIV align="right">
					<asp:Label id="lblSubTotalAmt" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label></DIV>
			</asp:panel><asp:panel id="pnlContAmtCount" runat="server">
<asp:Label id="lblContAmtCount" runat="server" ForeColor="Blue" Font-Bold="True">�w���}�ߪ��B�G</asp:Label></FONT>
<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="�o�t����H"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��">
							<ItemStyle Width="60px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="srspn_cname" HeaderText="�~�ȭ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_totamt" HeaderText="�X���`���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_paidamt" HeaderText="�wú���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_restamt" HeaderText="�Ѿl���B"></asp:BoundColumn>
						<asp:BoundColumn HeaderText="���s�i�`�B"></asp:BoundColumn>
						<asp:BoundColumn HeaderText="��봫�Z�`�B"></asp:BoundColumn>
						<asp:BoundColumn HeaderText="���}���`�B"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="�~�ȭ��u��"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="�o�t�Ǹ�"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid><BR>
<DIV align="right">
					<asp:Label id="lblContSubTotalAmt" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
					<asp:TextBox id="tbxContSubTotalAmt" runat="server" Visible="False" Width="80px"></asp:TextBox></DIV>
<asp:Button id="btnAddIA" runat="server" Text="���͵o���}�߳�"></asp:Button></asp:panel></form>
		<br>
		<!-- ���� Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
