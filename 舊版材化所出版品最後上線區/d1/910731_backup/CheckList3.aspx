<%@ Page language="c#" Codebehind="CheckList3.aspx.cs" src="CheckList3.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CheckList3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�i���Ʃ� �X���~�Ȥ�޲z�t�Ρj �o���}�߳��ˮ֪�</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="CheckList3" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				�o���B�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">�o���}�߳��ˮ֪�
			</FONT>
			<br>
			<INPUT onclick="doClose()" type="button" value="�^����">
			<br>
			<asp:datagrid id="DataGrid1" runat="server" Font-Names="�s�ө���" Font-Size="8pt" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="�Τ@�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="�ٿ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="�o���l�H�a�}">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_iaditem" HeaderText="�o���}�߳���ӧǸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk1" HeaderText="�q��s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk2" HeaderText="�q�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk3" HeaderText="�q��y����"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk4" HeaderText="�q�涵��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_desc" HeaderText="�~�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_projno" HeaderText="�p���N��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_costctr" HeaderText="��������"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_qty" HeaderText="�ƶq"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_amt" HeaderText="���B"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:label id="Label3" runat="server" Font-Size="X-Small" ForeColor="#C04000">����1�G<br>���ˮ֪�C�ܤ��o���}�߳�O�|�����͵o���}�߲M�椧���, <br>�w���͵o���}�߲M�椧�o����Ƥ��|�b���C��</asp:label>
			<br>
			<asp:label id="Label2" runat="server" Font-Size="X-Small" ForeColor="#C04000">����2�G<br>�o�����O---2:�G�p  3:�T�p  4:��L<br>�ҵ|�O---1:���|  2:�s�|  3:�K�|</asp:label>
		</form>
		<script language="javascript">
function doClose()
{
	window.close();
}
	</script>
	</body>
</HTML>
