<%@ Page language="c#" Codebehind="PayFilter.aspx.cs" src="PayFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayFilter" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
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
		<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
		<form id="PayFilter" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							���x�O�ѭq�\���t��<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							ú�ڳB�z<IMG height="10" src="images/header/right02.gif" width="10" border="0">��ܥI�ڶ���</font>
					</td>
				</tr>
			</table>
			<asp:label id="lblMessage" runat="server" ForeColor="#C000C0" Font-Size="X-Small">**�п�ܱ��I�ڤ��o��**</asp:label><br>
			<asp:Button id="btnSelAll" runat="server" Text="����"></asp:Button>
			<asp:Button id="btnDeSelAll" runat="server" Text="�M��"></asp:Button>
			<input id="btnCancel" onclick='javascritp:window.location.href="../default.aspx"' type="button" value="�����^����" name="btnCancel">
			<asp:Button id="btnNextStep" runat="server" Text="�U�@�B"></asp:Button>
			<asp:Label id="lblCount" runat="server" ForeColor="Maroon"></asp:Label><br>
			<asp:datalist id="DataList1" runat="server" Width="555px" BorderWidth="1px" GridLines="Horizontal" CellPadding="3" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">���</FONT>
							</TD>
							<TD width="90">
								<FONT color="white">�o���}�߳�s��</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">�Τ@�s��</FONT>
							</TD>
							<TD width="160">
								<FONT color="white">���q�W��</FONT>
							</TD>
							<TD width="90">
								<FONT color="white">�o������H</FONT>
							</TD>
							<TD width="90">
								<FONT color="white">�t�|���B</FONT>
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
								<asp:Label id="lblNo" Width="90" text='<%# DataBinder.Eval(Container.DataItem, "ia_refno")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblMfrno" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "ia_mfrno")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCompanyname" Width="160" text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblName" Width="90" text='<%# DataBinder.Eval(Container.DataItem, "ia_rnm")%>' Runat="server">
								</asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblAmt" Width="90" text='<%# DataBinder.Eval(Container.DataItem, "ia_pyat")%>' Runat="server">
								</asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
	</body>
</HTML>
