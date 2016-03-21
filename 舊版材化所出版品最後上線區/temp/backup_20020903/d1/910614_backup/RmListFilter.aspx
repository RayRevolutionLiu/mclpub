<%@ Page language="c#" Codebehind="RmListFilter.aspx.cs" src="RmListFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.RmListFilter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RmListFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				補書處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">補書清單列印
			</FONT>
			<br>
			<asp:label id="Label2" runat="server">寄書狀況：</asp:label>
			<asp:dropdownlist id="ddlSent" runat="server" AutoPostBack="True">
				<asp:ListItem Value="C">已寄出</asp:ListItem>
				<asp:ListItem Value="N">尚未寄出</asp:ListItem>
				<asp:ListItem Value="ALL">全部</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx1" runat="server" Text="補書日期區間："></asp:checkbox>
			<asp:textbox id="tbxRemailDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxRemailDate1.name)" src="../images/calendar01.gif">
			～<asp:textbox id="tbxRemailDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxRemailDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:checkbox id="cbx2" runat="server" Text="訂購日期區間："></asp:checkbox>
			<asp:textbox id="tbxOrderDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate1.name)" src="../images/calendar01.gif">
			～<asp:textbox id="tbxOrderDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxOrderDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:button id="btnPrintList" runat="server" Text="列印報表"></asp:button>
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
