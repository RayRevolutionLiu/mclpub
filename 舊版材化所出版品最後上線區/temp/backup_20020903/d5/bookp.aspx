<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Src="bookp.aspx.cs" Codebehind="bookp.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.bookp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���y���O��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��")
					event.returnValue=confirm("�O�_�T�w�R��?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<form id="bookp" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
						<TR>
							<TD align="left" width="100%" vAlign="top" height="22">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									&nbsp;�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									���y���O��ƺ��@<FONT color="dimgray">(
										<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
										�@��
										<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
										����� )</FONT>
									<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
								</FONT>
							</TD>
						</TR>
						<TR vAlign="top" height="224">
							<TD align="left" width="100%">
								<asp:datagrid id="DataGrid1" runat="server" BorderColor="Black" AutoGenerateColumns="False" AllowPaging="True">
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
									<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
									<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
									<ItemStyle BackColor="#BFCFF0"></ItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="bkp_bkpid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
										<asp:BoundColumn DataField="bkp_date" HeaderText="���y�X���~��"></asp:BoundColumn>
										<asp:BoundColumn DataField="bkp_pno" HeaderText="���y���O"></asp:BoundColumn>
										<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
										<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
									</Columns>
								</asp:datagrid>
							</TD>
						</TR>
						<TR height="40">
							<TD align="left" width="100%">
								<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
								<asp:dropdownlist id="ddlQueryField" runat="server">
									<asp:ListItem Value="bkp_pno" Selected="True">���y���O</asp:ListItem>
									<asp:ListItem Value="bkp_date">���y�X���~��</asp:ListItem>
									<asp:ListItem Value="bkp_bkcd">���y�N�X</asp:ListItem>
								</asp:dropdownlist>
								<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="�}�l�j�M"></asp:button>
								<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="�������"></asp:button>
								&nbsp;&nbsp;&nbsp;
								<asp:button id="btnAddNew" runat="server" Text="�s�W���" Font-Size="9pt" Height="23px"></asp:button>
							</TD>
						</TR>
					</TABLE>
			</P>
			</FONT>
		</form>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
