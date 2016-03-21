<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="CreateIa.aspx.cs" src="CreateIa.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CreateIa" %>
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
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="CreateIa" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				發票處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">發票開立單(人工產生)
			</FONT>
			<br>
			<asp:Button id="btnCreateIa" runat="server" Text="產生發票資料" Enabled="False"></asp:Button>
			<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
			<br>
			<asp:datalist id="DataList1" runat="server" BorderWidth="0px" GridLines="Horizontal" CellPadding="1" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">選取</FONT>
							</TD>
							<TD width="100">
								<FONT color="white">訂單編號</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">訂購日期</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">統一編號</FONT>
							</TD>
							<TD width="100">
								<FONT color="white">廠商名稱</FONT>
							</TD>
							<TD width="60">
								<FONT color="white">訂戶姓名</FONT>
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
								<asp:Label id="lblMfrno" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "o_mfrno")%>' Runat="server"></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblCompany" Width="100" text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm")%>' Runat="server"></asp:Label>
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
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
