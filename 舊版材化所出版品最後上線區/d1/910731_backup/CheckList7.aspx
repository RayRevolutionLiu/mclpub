<%@ Page language="c#" Codebehind="CheckList7.aspx.cs" src="CheckList7.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CheckList7" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�i���Ʃ� �X���~�Ȥ�޲z�t�Ρj ú�ڳ��ˮ֪�</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="CheckList7" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				ú�ڳB�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">ú�ڳ��ˮ֪�
			</FONT>
			<br>
			<INPUT onclick="doClose()" type="button" value="�^����">
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1" AutoGenerateColumns="False" Font-Size="8pt" Font-Names="�s�ө���">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
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
			<asp:label id="Label3" runat="server" Font-Size="X-Small" ForeColor="#C04000">����1�G<br>���ˮ֪�C�ܤ�ú�ڳ�O�|������ú�ڲM�椧���, <br>�w����ú�ڲM�椧ú�ڸ�Ƥ��|�b���C��</asp:label>
		</form>
		<script language="javascript">
function doClose()
{
	window.close();
}
	</script>
	</body>
</HTML>
