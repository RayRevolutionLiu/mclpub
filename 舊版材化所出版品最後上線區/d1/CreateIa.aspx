<%@ Page validateRequest=false language="c#" Codebehind="CreateIa.aspx.cs" src="CreateIa.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CreateIa" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
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
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="CreateIa" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				�o���B�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">�o���}�߳沣��
			</FONT>
			<br>
			<asp:button id="btnCreateIa" runat="server" Enabled="False" Text="���͵o�����"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datalist id="DataList1" runat="server" BorderColor="#E7E7FF" BorderStyle="None" BackColor="White" CellPadding="1" GridLines="Horizontal" BorderWidth="0px">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">���</FONT>
							</TD>
							<TD width="100">
								<FONT color="white">�q��s��</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">�q�ʤ��</FONT>
							</TD>
							<TD width="80">
								<FONT color="white">�Τ@�s��</FONT>
							</TD>
							<TD width="160">
								<FONT color="white">�t�ӦW��</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">�q��m�W</FONT>
							</TD>
						</TR>
					</TABLE>
				</HeaderTemplate>
				<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
				<ItemStyle BorderWidth="1px" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
				<ItemTemplate>
					<TABLE>
						<TR>
							<TD>
								<asp:CheckBox id="cbx1" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblNo" Width="100" text='<%# DataBinder.Eval(Container.DataItem, "nostr")%>' Runat="server"></asp:Label>
								<input type="hidden" id="hiddenXML" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "o_xmldata")%>'>
							</TD>
							<TD>
								<asp:Label id="lblDate" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "o_date")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblMfrno" Width="80" text='<%# DataBinder.Eval(Container.DataItem, "o_mfrno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCompany" Width="160" text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCustName" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "cust_nm")%>' Runat="server"></asp:Label>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<br>
			&nbsp;
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
