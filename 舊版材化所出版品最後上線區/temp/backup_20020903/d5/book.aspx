<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Src="book.aspx.cs" Codebehind="book.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.book" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���y��ƺ��@</TITLE>
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
		<form id="book" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
						<TR>
							<TD vAlign="top" height="22">
								<FONT title="���y��ƺ��@" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�@�P�ɮ�
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> ���y��ƺ��@
									<FONT color="dimgray">(
										<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
										�@��
										<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
										����� )</FONT>
									<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
								</FONT>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" height="224">
								<asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
									<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
									<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
									<ItemStyle BackColor="#BFCFF0"></ItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="bk_bkid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="bk_bkcd" HeaderText="���y�N�X"></asp:BoundColumn>
										<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
										<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
										<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
									</Columns>
								</asp:datagrid>
							</TD>
						</TR>
						<TR>
							<TD height="40">
								<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
								<asp:dropdownlist id="ddlQueryField" runat="server">
									<asp:ListItem Value="bk_nm" Selected="True">���y�W��</asp:ListItem>
									<asp:ListItem Value="bk_bkcd">���y�N�X</asp:ListItem>
								</asp:dropdownlist>
								<asp:button id="Query" runat="server" Text="�}�l�j�M" Font-Size="9pt" Height="23px"></asp:button>
								<asp:button id="btnShowAll" runat="server" Text="�������" Font-Size="9pt" Height="23px"></asp:button>
								&nbsp;&nbsp;&nbsp;
								<asp:button id="btnAddnew" runat="server" Text="�s�W���" Font-Size="9pt" Height="23px"></asp:button>
							</TD>
						</TR>
					</TABLE>
				</FONT>
			</P>
		</form>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
