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
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				�q��B�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">�q�\���Ӫ�d��
			</FONT>
			<br>
			<asp:label id="Label1" runat="server" ForeColor="Blue" Font-Bold="True">�п�ܱ���</asp:label>
			<HR width="100%" SIZE="1">
			<asp:checkbox id="cbx1" runat="server" Text="�I�ڤ覡�G"></asp:checkbox>
			<asp:dropdownlist id="ddlPayType" runat="server"></asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx2" runat="server" Text="�q�ʤ���G"></asp:checkbox>
			<asp:textbox id="tbxOrderDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxOrderDate1.name)" src="../images/calendar01.gif">
			��<asp:textbox id="tbxOrderDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="���" onclick="pick_date(tbxOrderDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:checkbox id="cbx3" runat="server" Text="�q��n������G"></asp:checkbox>
			<asp:textbox id="tbxDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxDate1.name)" src="../images/calendar01.gif">
			��<asp:textbox id="tbxDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="���" onclick="pick_date(tbxDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:checkbox id="cbx4" runat="server" Text="�q�\���O�G"></asp:checkbox>
			<asp:dropdownlist id="ddlOrderType" runat="server" AutoPostBack="True">
				<asp:ListItem Value="01" Selected="True">�q�\</asp:ListItem>
				<asp:ListItem Value="02">�ؾ\</asp:ListItem>
				<asp:ListItem Value="03">���s</asp:ListItem>
				<asp:ListItem Value="09">�s��</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx5" runat="server" Text="�q�\���y���O�G"></asp:checkbox>
			<asp:dropdownlist id="ddlBookType" runat="server"></asp:dropdownlist>
			<br>
			<asp:checkbox id="cbx6" runat="server" Text="���x����H�m�W�G"></asp:checkbox>
			<asp:textbox id="tbxRecName" runat="server"></asp:textbox>
			<br>
			<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
			<asp:button id="btnPrintList" runat="server" Text="�C�L����" Enabled="False"></asp:button>
			<asp:literal id="Literal1" runat="server"></asp:literal>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<Columns>
					<asp:BoundColumn DataField="nostr" HeaderText="�q��s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pytp_nm" HeaderText="�I�ڤ覡"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_fgpreinv" HeaderText="�w�}�o��"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="���y���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="datestr" HeaderText="�q�\�_��"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_amt" HeaderText="���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="���x����H"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="���q�W��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="�H�e�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ra_mnt" HeaderText="����"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="�ӿ�H��"></asp:BoundColumn>
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
