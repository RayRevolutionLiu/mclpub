<%@ Page aspcompat=true language="c#" Codebehind="search_label.aspx.cs" src="search_label.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.search_label" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="javascript"> 
		function doClose() {
		 window.close(); 
		 }
		  </script>
	</HEAD>
	<body>
		<form id="search_label" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				標籤處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">大宗標籤列印
			</FONT>
			<br>
			<asp:label id="Label1" runat="server" Font-Bold="True" Font-Names="細明體" Font-Size="Small" ForeColor="Blue">請選擇條件</asp:label>
			<HR width="100%" SIZE="1">
			<asp:label id="Label3" runat="server">郵寄地區：</asp:label>
			<asp:dropdownlist id="ddlMosea" runat="server" AutoPostBack="True">
				<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
				<asp:ListItem Value="1">國外</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label4" runat="server">郵寄類別：</asp:label>
			<asp:dropdownlist id="ddlMailType" runat="server"></asp:dropdownlist>
			<br>
			<asp:label id="Label5" runat="server">訂購類別：</asp:label>
			<asp:dropdownlist id="ddlOrderType1" runat="server" AutoPostBack="True">
				<asp:ListItem Value="01" Selected="True">訂閱</asp:ListItem>
				<asp:ListItem Value="02">贈閱</asp:ListItem>
				<asp:ListItem Value="03">推廣</asp:ListItem>
				<asp:ListItem Value="09">零售</asp:ListItem>
			</asp:dropdownlist>
			<asp:dropdownlist id="ddlOrderType2" runat="server"></asp:dropdownlist>
			<br>
			<asp:label id="Label8" runat="server">書籍類別：</asp:label>
			<asp:dropdownlist id="ddlBookType" runat="server"></asp:dropdownlist>
			<br>
			<asp:label id="Label2" runat="server">郵寄份數：</asp:label>
			<asp:dropdownlist id="ddlMnt" runat="server">
				<asp:ListItem Value="1">單本</asp:ListItem>
				<asp:ListItem Value="2">2本</asp:ListItem>
				<asp:ListItem Value="3">3本</asp:ListItem>
				<asp:ListItem Value="4">4本</asp:ListItem>
				<asp:ListItem Value="5">5本</asp:ListItem>
				<asp:ListItem Value="0">5本以上</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label6" runat="server">郵寄年月：</asp:label>
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
			<asp:label id="Label7" runat="server">雜誌期數：</asp:label>
			<asp:textbox id="tbxBookNo" runat="server" Width="75px"></asp:textbox>
			期
			<br>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:button id="btnPrintLabel" runat="server" Text="列印標籤"></asp:button>
			<asp:button id="btnPrintList" runat="server" Text="列印郵寄清單"></asp:button>
			<INPUT onclick="doClose()" type="button" value="取消回前頁">
			<asp:literal id="Literal1" runat="server"></asp:literal>
			<br>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="3" BackColor="White" BorderColor="#999999" BorderWidth="1px" GridLines="Vertical" BorderStyle="None" AutoGenerateColumns="False">
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="nostr" HeaderText="訂單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="datestr" HeaderText="訂閱起迄"></asp:BoundColumn>
					<asp:BoundColumn DataField="ra_mnt" HeaderText="份數"></asp:BoundColumn>
					<asp:BoundColumn DataField="mtp_nm" HeaderText="郵寄類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="書籍類別"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
		</form>
	</body>
</HTML>
