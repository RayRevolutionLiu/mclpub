<%@ Page language="c#" Codebehind="SAP.aspx.cs" src="SAP.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.SAP" %>
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
		<form id="SAP" method="post" runat="server">
			<table border="1" cellpadding="0" cellspacing="0" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px" bordercolor="#29498c" bgcolor="#29284a" width="100%" id="AutoNumber1">
				<tr>
					<td width="100%" style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
						<img border="0" src="/mrlpub/images/header/Logo0.jpg" height="30">
					</td>
				</tr>
			</table>
			<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				SAP���� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				�o���}�߳���SAP </FONT>
			<br>
			<FONT face="�s�ө���">
				<asp:label id="Label1" runat="server">���ɦ~��G</asp:label>
				<asp:label id="lblyyyymm" runat="server" ForeColor="Purple" Width="80px" Height="18px" BackColor="#C0FFC0"></asp:label>
				<asp:label id="Label2" runat="server">�妸�G</asp:label>
				<asp:label id="lblbatch" runat="server" ForeColor="Purple" Width="80px" Height="18px" BackColor="#C0FFC0"></asp:label>
				<asp:button id="btn_tranSAP" runat="server" Text="�o���}�߳���SAP" Enabled="False"></asp:button>
				<br>
				<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BackColor="White" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#3366CC" CellPadding="4">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:ButtonColumn Text="���" ButtonType="PushButton" CommandName="select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="ias_syscd" HeaderText="�t�ΥN�X"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_iasdate" HeaderText="���ɦ~��"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_iasseq" HeaderText="�妸"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_createdate" HeaderText="�������ɤ��"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_createmen" HeaderText="���ɪ̤u��"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
				<br>
				<asp:label id="lblMessage1" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:label id="lblMessage2" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:label id="lblMessage3" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
				<br>
				<asp:DataGrid id="DataGrid2" runat="server" BackColor="White" CellPadding="4" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn DataField="ia_refno" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
						<asp:BoundColumn DataField="ia_mfrno" HeaderText="�Τ@�s��"></asp:BoundColumn>
						<asp:BoundColumn DataField="ia_pyno" HeaderText="ú�ڽs��"></asp:BoundColumn>
						<asp:BoundColumn DataField="ia_pyat" HeaderText="�t�|���B"></asp:BoundColumn>
						<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H"></asp:BoundColumn>
						<asp:BoundColumn DataField="ia_raddr" HeaderText="�o������H�a�}"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</FONT>
		</form>
	</body>
</HTML>
