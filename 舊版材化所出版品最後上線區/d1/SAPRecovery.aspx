<%@ Page language="c#" Codebehind="SAPRecovery.aspx.cs" src="SAPRecovery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.SAPRecovery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="SAPRecovery" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				SAP轉檔 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
				發票開立單轉SAP回復</FONT>
			<br>
			<FONT face="新細明體">
				<asp:label id="Label1" runat="server">轉檔年月：</asp:label>
				<asp:label id="lblyyyymm" runat="server" ForeColor="Purple" Width="80px" Height="18px" BackColor="#C0FFC0"></asp:label>
				<asp:label id="Label2" runat="server">批次：</asp:label>
				<asp:label id="lblbatch" runat="server" ForeColor="Purple" Width="80px" Height="18px" BackColor="#C0FFC0"></asp:label>
				<asp:button id="btn_Recovery" runat="server" Text="發票開立單轉SAP回復" Enabled="False"></asp:button>
				<asp:Button id="Button1" runat="server" Text="Button"></asp:Button>
				<br>
				<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BackColor="White" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#3366CC" CellPadding="4">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:ButtonColumn Text="選取" ButtonType="PushButton" CommandName="select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="ias_syscd" HeaderText="系統代碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_iasdate" HeaderText="轉檔年月"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_iasseq" HeaderText="批次"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_createdate" HeaderText="執行轉檔日期"></asp:BoundColumn>
						<asp:BoundColumn DataField="ias_createmen" HeaderText="轉檔者工號"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
				<br>
				<asp:label id="lblMessage1" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
				<asp:label id="lblMessage2" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:label>
			</FONT>
		</form>
	</body>
</HTML>
