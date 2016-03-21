<%@ Page language="c#" Codebehind="IncomeFilter.aspx.cs" src="IncomeFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.IncomeFilter" %>
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
		<form id="IncomeFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				其他報表<IMG height="10" src="images/header/right02.gif" width="10" border="0">收入統計表
			</FONT>
			<br>
			<br>
			<asp:label id="Label1" runat="server">統計日期(訂購日期)區間：</asp:label>
			<asp:textbox id="tbxOrderDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate1.name)" src="../images/calendar01.gif">
			～<asp:textbox id="tbxOrderDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate2.name)" src="../images/calendar01.gif">
			<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
			<br>
			<asp:label id="Label2" runat="server">訂閱類別：</asp:label>
			<asp:dropdownlist id="ddlOrderType1" runat="server" AutoPostBack="True">
				<asp:ListItem Value="01" Selected="True">訂閱</asp:ListItem>
				<asp:ListItem Value="02">贈閱</asp:ListItem>
				<asp:ListItem Value="03">推廣</asp:ListItem>
				<asp:ListItem Value="09">零售</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx1" runat="server" AutoPostBack="True" Text="訂閱書籍類別："></asp:checkbox>
			<asp:dropdownlist id="ddlBookType" runat="server"></asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx2" runat="server" AutoPostBack="True" Text="計劃代號："></asp:checkbox>
			<asp:textbox id="tbxProj" runat="server" Width="82px"></asp:textbox>
			<asp:Label id="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
			<br>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:button id="btnPrintList" runat="server" Text="列印報表" Enabled="False"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="2" AutoGenerateColumns="False">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="otp_otp1nm" HeaderText="訂閱類別一"></asp:BoundColumn>
					<asp:BoundColumn DataField="otp_otp2nm" HeaderText="訂閱類別二"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="書籍類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="tmp_param2" HeaderText="份數"></asp:BoundColumn>
					<asp:BoundColumn DataField="tmp_param1" HeaderText="金額"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:literal id="Literal1" runat="server"></asp:literal>
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
