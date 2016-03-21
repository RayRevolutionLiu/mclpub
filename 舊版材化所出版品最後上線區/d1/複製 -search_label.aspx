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
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���ҳB�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">�j�v���ҦC�L
			</FONT>
			<br>
			<asp:label id="Label1" runat="server" Font-Bold="True" Font-Names="�ө���" Font-Size="Small" ForeColor="Blue">�п�ܱ���</asp:label>
			<HR width="100%" SIZE="1">
			<asp:label id="Label3" runat="server">�l�H�a�ϡG</asp:label>
			<asp:dropdownlist id="ddlMosea" runat="server" AutoPostBack="True">
				<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
				<asp:ListItem Value="1">��~</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label4" runat="server">�l�H���O�G</asp:label>
			<asp:dropdownlist id="ddlMailType" runat="server"></asp:dropdownlist>
			<br>
			<asp:label id="Label5" runat="server">�q�����O�G</asp:label>
			<asp:dropdownlist id="ddlOrderType1" runat="server" AutoPostBack="True">
				<asp:ListItem Value="01" Selected="True">�q�\</asp:ListItem>
				<asp:ListItem Value="02">�ؾ\</asp:ListItem>
				<asp:ListItem Value="03">���s</asp:ListItem>
				<asp:ListItem Value="09">�s��</asp:ListItem>
			</asp:dropdownlist>
			<asp:dropdownlist id="ddlOrderType2" runat="server"></asp:dropdownlist>
			<br>
			<asp:label id="Label8" runat="server">���y���O�G</asp:label>
			<asp:dropdownlist id="ddlBookType" runat="server"></asp:dropdownlist>
			<br>
			<asp:label id="Label2" runat="server">�l�H���ơG</asp:label>
			<asp:dropdownlist id="ddlMnt" runat="server">
				<asp:ListItem Value="1">�楻</asp:ListItem>
				<asp:ListItem Value="2">2��</asp:ListItem>
				<asp:ListItem Value="3">3��</asp:ListItem>
				<asp:ListItem Value="4">4��</asp:ListItem>
				<asp:ListItem Value="5">5��</asp:ListItem>
				<asp:ListItem Value="0">5���H�W</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label6" runat="server">�l�H�~��G</asp:label>
			<asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>
			�~
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
			��
			<br>
			<asp:label id="Label7" runat="server">���x���ơG</asp:label>
			<asp:textbox id="tbxBookNo" runat="server" Width="75px"></asp:textbox>
			��
			<br>
			<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
			<asp:button id="btnPrintLabel" runat="server" Text="�C�L����"></asp:button>
			<asp:button id="btnPrintList" runat="server" Text="�C�L�l�H�M��"></asp:button>
			<INPUT onclick="doClose()" type="button" value="�����^�e��">
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
					<asp:BoundColumn DataField="nostr" HeaderText="�q��s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="datestr" HeaderText="�q�\�_��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ra_mnt" HeaderText="����"></asp:BoundColumn>
					<asp:BoundColumn DataField="mtp_nm" HeaderText="�l�H���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="���y���O"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
		</form>
	</body>
</HTML>
