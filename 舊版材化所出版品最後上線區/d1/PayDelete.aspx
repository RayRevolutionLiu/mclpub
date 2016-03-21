<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="PayDelete.aspx.cs" src="PayDelete.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayDelete" %>
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
		<form id="PayDelete" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							ú�ڳB�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">�R��ú�ڸ��
						</font>
					</td>
				</tr>
			</table>
			<br>
			<asp:label id="Label1" runat="server">�п�Jú�ڽs���G</asp:label>
			<asp:textbox id="tbxPyno" runat="server" MaxLength="8" Height="24px" Width="83px"></asp:textbox>
			<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="py_pyno" HeaderText="ú�ڽs��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="pytp_nm" HeaderText="�I�ڤ覡"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="ú�ڤ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moseq" HeaderText="������帹">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="py_moitem" HeaderText="����"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkno" HeaderText="���ڸ��X"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkbnm" HeaderText="�I�ڦ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkdate" HeaderText="�����"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_waccno" HeaderText="�q�ױb��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wdate" HeaderText="�פJ���"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wbcd" HeaderText="���ĥN�X"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccno" HeaderText="�H�Υd�d��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccauthcd" HeaderText="���v�X"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccvdate" HeaderText="���Ħ~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccdate" HeaderText="������"></asp:BoundColumn>
					<asp:BoundColumn DataField="pyd_pyditem" HeaderText="ú�ڧǸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="pyd_iano" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<br>
			<asp:Button id="btnDelete" runat="server" Text="�R��ú�ڸ��" Visible="False"></asp:Button>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��ú�ڸ��")
				event.returnValue=confirm("�T�w�n�R������ú�ڸ��?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
