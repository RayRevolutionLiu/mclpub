<%@ Page language="c#" Codebehind="OrderListFilter.aspx.cs" src="OrderListFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.OrderListFilter" %>
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
		<form id="OrderListFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				訂單處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">訂閱明細表查詢
			</FONT>
			<br>
			<asp:label id="Label1" runat="server" ForeColor="Blue" Font-Bold="True">請選擇條件</asp:label>
			<HR width="100%" SIZE="1">
			<asp:checkbox id="cbx1" runat="server" Text="付款方式："></asp:checkbox>
			<asp:dropdownlist id="ddlPayType" runat="server"></asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx2" runat="server" Text="訂購日期："></asp:checkbox>
			<asp:textbox id="tbxOrderDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate1.name)" src="../images/calendar01.gif">
			～<asp:textbox id="tbxOrderDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:checkbox id="cbx3" runat="server" Text="訂單登錄日期："></asp:checkbox>
			<asp:textbox id="tbxDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxDate1.name)" src="../images/calendar01.gif">
			～<asp:textbox id="tbxDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:checkbox id="cbx4" runat="server" Text="訂閱類別："></asp:checkbox>
			<asp:dropdownlist id="ddlOrderType" runat="server" AutoPostBack="True">
				<asp:ListItem Value="01" Selected="True">訂閱</asp:ListItem>
				<asp:ListItem Value="02">贈閱</asp:ListItem>
				<asp:ListItem Value="03">推廣</asp:ListItem>
				<asp:ListItem Value="09">零售</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx5" runat="server" Text="訂閱書籍類別："></asp:checkbox>
			<asp:dropdownlist id="ddlBookType" runat="server"></asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx6" runat="server" Text="雜誌收件人姓名："></asp:checkbox>
			<asp:textbox id="tbxRecName" runat="server"></asp:textbox>
			<br>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:button id="btnPrintList" runat="server" Text="列印報表" Enabled="False"></asp:button>
			<asp:literal id="Literal1" runat="server"></asp:literal>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<Columns>
					<asp:BoundColumn DataField="nostr" HeaderText="訂單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pytp_nm" HeaderText="付款方式"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_fgpreinv" HeaderText="預開發票"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="書籍類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="datestr" HeaderText="訂閱起迄"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_amt" HeaderText="金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="雜誌收件人"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="公司名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="寄送地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="ra_mnt" HeaderText="份數"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="承辦人員"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
		</form>
		<script language="javascript">
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
		</script>
	</body>
</HTML>
