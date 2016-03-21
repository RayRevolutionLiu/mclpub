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
			<table id="AutoNumber1" style="BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-COLLAPSE: collapse; BORDER-RIGHT-WIDTH: 0px" borderColor="#29498c" cellSpacing="0" cellPadding="0" width="100%" bgColor="#29284a" border="1">
				<tr>
					<td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none" width="100%">
						<IMG height="30" src="/mrlpub/images/header/Logo0.jpg" border="0">
					</td>
				</tr>
			</table>
			<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				SAP���� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				�o���}�߳���SAP </FONT>
			<br>
			<FONT face="�s�ө���">
				<asp:label id="Label1" runat="server">���ɦ~��G</asp:label>
				<asp:label id="lblyyyymm" runat="server" BackColor="#C0FFC0" Height="18px" Width="80px" ForeColor="Purple"></asp:label>
				<asp:label id="Label2" runat="server">�妸�G</asp:label>
				<asp:label id="lblbatch" runat="server" BackColor="#C0FFC0" Height="18px" Width="80px" ForeColor="Purple"></asp:label>
				<asp:button id="btn_tranSAP" runat="server" Enabled="False" Text="�o���}�߳���SAP"></asp:button>
				<br>
				<asp:label id="lblMessage1" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:label id="lblMessage2" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:label id="lblMessage3" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
				<br>
				<asp:datagrid id="DataGrid1" runat="server" BackColor="White" CellPadding="1" BorderColor="#3366CC" BorderWidth="1px" AutoGenerateColumns="False" BorderStyle="None">
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
				<asp:datagrid id="DataGrid2" runat="server" BackColor="White" CellPadding="3" BorderColor="#3366CC" BorderWidth="1px" AutoGenerateColumns="False" BorderStyle="None">
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
				</asp:datagrid>
				<asp:Label id="lblAmt" runat="server" ForeColor="Red"></asp:Label>
			</FONT>
		</form>
	</body>
</HTML>
