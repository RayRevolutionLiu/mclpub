<%@ Page language="c#" Codebehind="iaFm1_chklist.aspx.cs" Src="iaFm1_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_chklist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�o���}�߳��ˮ֪� - �@���I��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- ���� Header -->
		<!-- �ثe�Ҧb��m -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�o���}�߳��ˮ֪� - �@���I��</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_chklist" method="post" runat="server">
			&nbsp;
			<asp:button id="btnBack" runat="server" Text="��^����"></asp:button>&nbsp;&nbsp;&nbsp;
			<INPUT id="btnPrint" onclick="Javascript:window.print();" type="button" value="�C�L����" name="btnPrint">&nbsp; 
			&nbsp; <INPUT id="btnClose" onclick="Javascript:window.close();" type="button" value="��������" name="btnClose">&nbsp;&nbsp;&nbsp;
			<asp:button id="btnAddIA" runat="server" Text="�~��}��"></asp:button><br>
			<br>
			<asp:label id="lblCont" runat="server" Font-Bold="True" ForeColor="Blue">�X����ơG</asp:label>&nbsp;&nbsp;<asp:label id="lblContMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
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
			</asp:datagrid><br>
			<asp:label id="lblIA" runat="server" Font-Bold="True" ForeColor="Blue">�w�}�ߤ��o����ơG</asp:label>&nbsp;&nbsp;
			<asp:label id="lblIAMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><asp:textbox id="tbxIANo" runat="server" Font-Size="X-Small" Width="80px" MaxLength="8" Visible="False"></asp:textbox><asp:datagrid id="DataGrid2" runat="server" Font-Size="8pt" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
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
		</form>
		<!-- ���� Footer -->
	</body>
</HTML>
