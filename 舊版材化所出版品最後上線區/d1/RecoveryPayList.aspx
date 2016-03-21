<%@ Page language="c#" Codebehind="RecoveryPayList.aspx.cs" src="RecoveryPayList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.RecoveryPayList" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
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
		<form id="RecoveryPayList" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
				ú�ڳB�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">�R��ú�ڲM��
			</FONT>
			<br>
			<asp:label id="Label2" runat="server" ForeColor="Blue" Font-Size="Small" Font-Names="�ө���" Font-Bold="True">�п�ܱ���</asp:label>
			<HR width="100%" SIZE="1">
			<asp:label id="Label3" runat="server">�M�沣�ͦ~��G</asp:label>
			<asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>
			�~
			<asp:dropdownlist id="ddlMonth" runat="server">
				<asp:ListItem Value="01">1</asp:ListItem>
				<asp:ListItem Value="02">2</asp:ListItem>
				<asp:ListItem Value="03">3</asp:ListItem>
				<asp:ListItem Value="04">4</asp:ListItem>
				<asp:ListItem Value="05">5</asp:ListItem>
				<asp:ListItem Value="06">6</asp:ListItem>
				<asp:ListItem Value="07">7</asp:ListItem>
				<asp:ListItem Value="08">8</asp:ListItem>
				<asp:ListItem Value="09">9</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
				<asp:ListItem Value="11">11</asp:ListItem>
				<asp:ListItem Value="12">12</asp:ListItem>
			</asp:dropdownlist>
			��
			<br>
			<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
			<asp:button id="btnDelete" runat="server" Text="�R��ú�ڲM��" Enabled="False"></asp:button>
			<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
			<br>
			���ͦ~��G
			<asp:label id="lblyyyymm" runat="server" ForeColor="Purple" BackColor="#C0FFC0">0</asp:label>
			�妸�G
			<asp:label id="lblbatch" runat="server" ForeColor="Purple" BackColor="#C0FFC0">0</asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BackColor="White" AutoGenerateColumns="False" CellPadding="1" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:ButtonColumn Text="���" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="pys_pysdate" HeaderText="���ͦ~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_pysseq" HeaderText="�妸"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_toitem" HeaderText="�`����"></asp:BoundColumn>
					<asp:BoundColumn DataField="pytp_nm" HeaderText="�I�ڤ覡"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_createdate" HeaderText="�إߤ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_createmen" HeaderText="�إߪ�"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:datagrid id="DataGrid2" runat="server" BackColor="White" AutoGenerateColumns="False" CellPadding="1" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="py_pyno" HeaderText="ú�ڽs��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="ú�ڤ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysdate" HeaderText="ú�ڲM�沣�ͦ~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysseq" HeaderText="ú�ڲM��妸"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysitem" HeaderText="ú�ڲM�涵��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moseq" HeaderText="������帹"></asp:BoundColumn>
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
				</Columns>
			</asp:datagrid>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��ú�ڲM��")
				event.returnValue=confirm("���ʧ@�N�|�R���ҿ諸ú�ڲM��Ω���, �T�w�n�R������ú�ڲM��?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
