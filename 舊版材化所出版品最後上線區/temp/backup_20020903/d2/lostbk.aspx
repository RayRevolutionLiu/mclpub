<%@ Page language="c#" Codebehind="lostbk.aspx.cs" Src="lostbk.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�ʮ� - ����s��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��")
					event.returnValue=confirm("�O�_�T�w�R��?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- Run at Server Form -->
			<form id="lostbk" method="post" runat="server">
				<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<!-- �ثe�Ҧb��m & Query Line -->
					<TR>
						<TD width="5%">
							&nbsp;
						</TD>
						<TD vAlign="top" width="*">
							<FONT title="���y��ƺ��@" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�����s�i���t��
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �������@��
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �ʮ� - 
								����s�� (
								<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
								�@��
								<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
								����� )</FONT>
							<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
							</FONT>
						</TD>
					</TR>
					<!-- DataGrid: �۸�Ʈw��̷s��� -->
					<TR>
						<TD>
							&nbsp;
						</TD>
						<TD vAlign="top">
							<asp:datagrid id="DataGrid1" runat="server" PageSize="10" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
								<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
								<ItemStyle BackColor="#BFCFF0"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="lst_lstid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_contno" HeaderText="�X���ѽs��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgclosed" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_oritem" HeaderText="����H�Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="����H�q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_seq" HeaderText="�ʮѧǸ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_cont" HeaderText="�ʮѤ��e"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_date" HeaderText="�ʮѤ��"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_rea" HeaderText="�ʮѭ�]"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_fgsent" HeaderText="�w�H�X���O">
										<ItemStyle HorizontalAlign="Center">
										</ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
					<!-- �j�M��ƥ\�� -->
					<TR>
						<TD>
							&nbsp;
							<br>
							<br>
						</TD>
						<TD>
							<br>
							<br>
							<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
							<asp:dropdownlist id="ddlQueryField" runat="server">
								<asp:ListItem Value="lst_contno" Selected="True">�X���ѽs��</asp:ListItem>
								<asp:ListItem Value="or_nm">����H�m�W</asp:ListItem>
								<asp:ListItem Value="or_tel">����H�q��</asp:ListItem>
								<asp:ListItem Value="lst_date">�ʮѤ��</asp:ListItem>
							</asp:dropdownlist>
							<asp:button id="Query" runat="server" Text="�}�l�j�M" Font-Size="9pt" Height="23px"></asp:button>
							<asp:button id="btnShowAll" runat="server" Text="�������" Font-Size="9pt" Height="23px"></asp:button>
							&nbsp;&nbsp;&nbsp;
							<asp:button id="btnReturnHome" runat="server" Text="�^�t�έ���" Font-Size="9pt" Height="23px"></asp:button>
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
