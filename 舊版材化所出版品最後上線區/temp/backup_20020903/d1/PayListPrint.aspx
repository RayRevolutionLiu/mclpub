<%@ Page language="c#" Codebehind="PayListPrint.aspx.cs" src="PayListPrint.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayListPrint" %>
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
		<form id="PayListPrint" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
				繳款處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">列印繳款清單
			</FONT>
			<br>
			<asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="細明體" Font-Size="Small" ForeColor="Blue">請選擇條件</asp:label>
			<HR width="100%" SIZE="1">
			<asp:label id="Label3" runat="server">清單產生年月：</asp:label>
			<asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>
			年
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
			月
			<br>
			<asp:Button id="btnSearch" runat="server" Text="查詢"></asp:Button>
			<asp:Button id="btnPrint" runat="server" Text="列印繳款清單" Enabled="False"></asp:Button>
			<br>
			產生年月：
			<asp:label id="lblyyyymm" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:label>
			批次：
			<asp:label id="lblbatch" runat="server" BackColor="#C0FFC0" ForeColor="Purple">0</asp:label>
			<br>
			<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1" AutoGenerateColumns="False">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:ButtonColumn Text="選取" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="pys_pysdate" HeaderText="產生年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_pysseq" HeaderText="批次"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_toitem" HeaderText="總項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="pytp_nm" HeaderText="付款方式"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_createdate" HeaderText="建立日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_createmen" HeaderText="建立者"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:datagrid id="DataGrid2" runat="server" BorderWidth="1px" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="py_pyno" HeaderText="繳款編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="繳款日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysdate" HeaderText="繳款清單產生年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysseq" HeaderText="繳款清單批次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysitem" HeaderText="繳款清單項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moseq" HeaderText="劃撥單批號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moitem" HeaderText="項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkno" HeaderText="票據號碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkbnm" HeaderText="付款行"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkdate" HeaderText="到期日"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_waccno" HeaderText="電匯帳號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wdate" HeaderText="匯入日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wbcd" HeaderText="金融代碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccno" HeaderText="信用卡卡號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccauthcd" HeaderText="授權碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccvdate" HeaderText="有效年月"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
	</body>
</HTML>
