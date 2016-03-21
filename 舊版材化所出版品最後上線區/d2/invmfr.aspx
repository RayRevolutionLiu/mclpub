<%@ Page language="c#" Codebehind="invmfr.aspx.cs" Src="invmfr.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.invmfr" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�o���t�Ӧ���H - ����s��</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="invmfr" method="post" runat="server">
				<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
					<!-- �ثe�Ҧb��m & Query Line -->
					<TR>
						<TD width="1%">
							&nbsp;
						</TD>
						<TD vAlign="top" width="*">
							<FONT title="���y��ƺ��@" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�����s�i���t��
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �������@��
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �o���t�Ӧ���H 
								- ����s�� (
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
							<asp:datagrid id="DataGrid1" runat="server" BorderColor="Black" AutoGenerateColumns="False" AllowPaging="True">
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
								<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
								<ItemStyle BackColor="#BFCFF0"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="im_imid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_contno" HeaderText="�X���ѽs��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgclosed" HeaderText="����"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�">
										<ItemStyle HorizontalAlign="Right">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="im_addr" HeaderText="�a�}">
										<ItemStyle HorizontalAlign="Right">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu">
										<ItemStyle HorizontalAlign="Center">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_invcd" HeaderText="�o�����O"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ�����"></asp:BoundColumn>
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
								<asp:ListItem Value="im_contno" Selected="True">�X���ѽs��</asp:ListItem>
								<asp:ListItem Value="im_imseq">�Ǹ�</asp:ListItem>
								<asp:ListItem Value="mfr_inm">�t�ӦW��</asp:ListItem>
								<asp:ListItem Value="im_nm">����H�m�W</asp:ListItem>
								<asp:ListItem Value="im_addr">�a�}</asp:ListItem>
								<asp:ListItem Value="im_tel">�q��</asp:ListItem>
							</asp:dropdownlist>
							<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="�}�l�j�M"></asp:button>
							<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="�������"></asp:button>
							&nbsp;&nbsp;&nbsp;
							<asp:button id="btnReturnHome" runat="server" Height="23px" Font-Size="9pt" Text="�^�t�έ���"></asp:button>
						</TD>
						<TD height="36">
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
