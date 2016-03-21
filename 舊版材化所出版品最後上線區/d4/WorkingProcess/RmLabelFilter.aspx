<%@ Page language="c#" Codebehind="RmLabelFilter.aspx.cs" src="RmLabelFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.RmLabelFilter" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
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
		<form id="RmLabelFilter" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
				�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0"> 
				���ҳB�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">�ɮѼ��ҦC�L
			</FONT>
			<br>
			<asp:label id="Label1" runat="server">�l�H�a�ϡG</asp:label><asp:dropdownlist id="ddlMosea" runat="server" AutoPostBack="True">
				<asp:ListItem Value="0">�ꤺ</asp:ListItem>
				<asp:ListItem Value="1">��~</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:button id="btnCheckAll" runat="server" Text="����"></asp:button><asp:button id="btnUnCheckAll" runat="server" Text="�M��"></asp:button><asp:button id="btnLabelPrint1" runat="server" Text="���ҦC�L"></asp:button><asp:button id="btnPrintOK" runat="server" Text="�C�L���T" Enabled="False"></asp:button><asp:label id="Label2" runat="server" ForeColor="#C000C0">**�w�H�X���ɮѸ�Ƥ��|�b���X�{**</asp:label><br>
			<asp:datalist id="DataList1" runat="server" BorderColor="#E7E7FF" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="Horizontal" BorderWidth="1px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">���</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">�X���s��</FONT>
							</TD>
							<TD width="150">
								<FONT color="white">���q�W��</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">����H�Ǹ�</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">����H</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">�ɮѧǸ�</FONT>
							</TD>
							<TD width="150">
								<FONT color="white">�ɮѤ��e</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">�H�Ѫ��A</FONT>
							</TD>
						</TR>
					</TABLE>
				</HeaderTemplate>
				<EditItemStyle BackColor="Info"></EditItemStyle>
				<SelectedItemTemplate>
					<FONT face="�s�ө���"></FONT>
				</SelectedItemTemplate>
				<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
				<ItemStyle BorderWidth="1px" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
				<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
				<ItemTemplate>
					<TABLE>
						<TR>
							<TD>
								<asp:CheckBox id="cbx1" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblContno" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "rm_contno")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCompany" Width="150" text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblOritem" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "rm_oritem")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblRecName" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "or_nm")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblSeq" Width="40" text='<%# DataBinder.Eval(Container.DataItem, "rm_seq")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCont" Width="150" text='<%# DataBinder.Eval(Container.DataItem, "rm_cont")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblFlagSent" Width="60" text='<%# GetFgSentName(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>' Runat="server">
								</asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
