<%@ Page language="c#" Codebehind="BookMntFilter.aspx.cs" src="BookMntFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.BookMntFilter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�L�s���Ʋέp��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="BookMntFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				��L����<IMG height="10" src="images/header/right02.gif" width="10" border="0">�L�s���Ʋέp��
			</FONT>
			<br>
			<br>
			<asp:label id="Label1" runat="server">�έp����G</asp:label>
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
			<asp:label id="Label3" runat="server">�l�H���O�G</asp:label>
			<asp:dropdownlist id="ddlMailType" runat="server">
				<asp:ListItem Value="0" Selected="True">�j�v�l�H</asp:ListItem>
				<asp:ListItem Value="1">���o�Ǹg��</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label2" runat="server">���y���O�G</asp:label>
			<asp:dropdownlist id="ddlBookType" runat="server">
				<asp:ListItem Value="01" Selected="True">�u���q�\</asp:ListItem>
				<asp:ListItem Value="02">�q���q�\</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:label id="Label7" runat="server">���x���ơG</asp:label>
			<asp:textbox id="tbxBookNo" runat="server" Width="75px"></asp:textbox>
			��
			<br>
			<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
			<asp:button id="btnPrintList" runat="server" Text="�C�L����" Enabled="False"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="2" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="otp_otp1nm" HeaderText="�q�\���O�@"></asp:BoundColumn>
					<asp:BoundColumn DataField="otp_otp2nm" HeaderText="�q�\���O�G"></asp:BoundColumn>
					<asp:BoundColumn DataField="mtp_mtpcd" HeaderText="�l�H���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="tmp_param1" HeaderText="�q�\����"></asp:BoundColumn>
					<asp:BoundColumn DataField="tmp_param2" HeaderText="����"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:literal id="Literal1" runat="server"></asp:literal>
		</form>
	</body>
</HTML>
