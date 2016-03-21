<%@ Page language="c#" Codebehind="DeleteIa.aspx.cs" src="DeleteIa.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.DeleteIa" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="DeleteIa" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							�o���B�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">���P�o�� </font>
					</td>
				</tr>
			</table>
			<br>
			<asp:label id="Label1" runat="server">�п�J�o�����X�G</asp:label>
			<asp:textbox id="tbxIano" runat="server" Width="83px" Height="24px" MaxLength="10"></asp:textbox>
			<input id="hiddenIano" type="hidden" runat="server">
			<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1" AutoGenerateColumns="False">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invno" HeaderText="�o�����X"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invdate" HeaderText="�o�����"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_pyat" HeaderText="���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="�Τ@�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="nostr" HeaderText="�q��s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_date" HeaderText="�q�ʤ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="datestr" HeaderText="�q�\�_��"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="���y���O"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<br>
			<asp:button id="btnDelete" runat="server" Text="���P�o��" Visible="False"></asp:button>
			<br>
			<asp:Label id="Label2" runat="server" ForeColor="#C04000" Font-Size="X-Small">�����G<br>�o�����O---2:�G�p  3:�T�p  4:��L<br>�ҵ|�O---1:���|  2:�s�|  3:�K�|</asp:Label>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="���P�o��")
				event.returnValue=confirm("�T�w�n�R�������o�����?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
