<%@ Page language="c#" Codebehind="AppriseFilter.aspx.cs" src="AppriseFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.AppriseFilter" %>
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
		<form id="AppriseFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				標籤處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">續訂標籤列印
			</FONT>
			<br>
			<asp:label id="Label1" runat="server" ForeColor="Blue" Font-Size="Small" Font-Names="細明體" Font-Bold="True">請選擇條件</asp:label>
			<HR width="100%" SIZE="1">
			<asp:label id="Label3" runat="server">郵寄地區：</asp:label>
			<asp:dropdownlist id="ddlMosea" runat="server">
				<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
				<asp:ListItem Value="1">國外</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label5" runat="server">書籍類別：</asp:label>
			<asp:dropdownlist id="ddlBookType" runat="server">
				<asp:ListItem Value="01">工材</asp:ListItem>
				<asp:ListItem Value="02">電材</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label4" runat="server">通知類別：</asp:label>
			<asp:dropdownlist id="ddlType" runat="server" AutoPostBack="True">
				<asp:ListItem Value="0" Selected="True">到期</asp:ListItem>
				<asp:ListItem Value="1">即將到期</asp:ListItem>
			</asp:dropdownlist>
			<asp:label id="Label7" runat="server" ForeColor="Maroon">(註)</asp:label>
			<br>
			<asp:label id="Label6" runat="server">訂閱迄期區間：</asp:label>
			<asp:dropdownlist id="ddlYear1" runat="server"></asp:dropdownlist>
			年
			<asp:dropdownlist id="ddlMonth1" runat="server">
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
			月～
			<asp:dropdownlist id="ddlYear2" runat="server"></asp:dropdownlist>
			年
			<asp:dropdownlist id="ddlMonth2" runat="server">
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
			<asp:label id="Label2" runat="server" ForeColor="Maroon" Font-Size="X-Small">註:<br>如通知類別選擇"到期"時, 迄期區間請輸入本月之前的月份(含本月)<br>選擇"即將到期"時, 迄期區間請輸入本月之後的月份(不含本月)</asp:label>
			<br>
			<asp:button id="btnOK" runat="server" Text="查詢"></asp:button>
			<asp:button id="btnPrintLabel" runat="server" Text="列印標籤"></asp:button>
			<asp:button id="btnPrintList" runat="server" Text="列印郵寄清單"></asp:button>
			<INPUT onclick="doClose()" type="button" value="取消回前頁">
			<asp:literal id="Literal1" runat="server"></asp:literal>
			<br>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="Vertical" BorderWidth="1px" BorderColor="#999999" BackColor="White" CellPadding="3">
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
		<script language="javascript"> 
		function doClose() {
		 window.close(); 
		 }
		</script>
	</body>
</HTML>
