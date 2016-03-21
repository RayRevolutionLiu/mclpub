<%@ Page language="c#" Codebehind="pgno.aspx.cs" Src="pgno.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.pgno" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�����_�l���X - ����s��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
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
		<!-- ���� Header -->
		<kw:header id="Header" runat="server"></kw:header>&nbsp; 
		<!-- Run at Server Form-->
		<form id="pgno" method="post" runat="server">
			<!-- Query Line-->
			<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<!-- �ثe�Ҧb��m & Query Line -->
				<TR>
					<TD width="5%">
						&nbsp;
					</TD>
					<TD vAlign="top">
						<FONT title="���y��ƺ��@" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�����s�i���t��
							<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �������@��
							<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �����_�l���X 
							- ����s�� (
							<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
							�@��
							<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
							����� )</FONT>
						<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label></FONT>
					</TD>
				</TR>
				<!-- DataGrid: �۸�Ʈw��̷s��� -->
				<TR>
					<TD>
						&nbsp;
					</TD>
					<TD vAlign="top">
						<!-- DataGrid: �۸�Ʈw��̷s��� -->
						<asp:datagrid id="DataGrid1" runat="server" BorderColor="Black" AutoGenerateColumns="False" AllowPaging="True">
							<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
							<ItemStyle BackColor="#BFCFF0"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="pg_pgid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="bk_nm" HeaderText="���y���O�W��"></asp:BoundColumn>
								<asp:BoundColumn DataField="pg_startpgno" HeaderText="�����_�l���X"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="pg_bkcd" HeaderText="���y���O�N�X"></asp:BoundColumn>
								<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
								<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<!-- �Ƶ� -->
				<TR>
					<TD colspan="2" align="left">
						<font size="2" color="darkred">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���G���קK�o�Ϳ��~�A�Фť��� 
							'�R��'�I</font>
					</TD>
				</TR>
				<!-- �j�M��ƥ\�� -->
				<TR>
					<TD>
						&nbsp;
						<br>
						<br>
					</TD>
					<TD><FONT face="�s�ө���"></FONT><FONT face="�s�ө���"></FONT>
						<br>
						<br>
						<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
						<asp:dropdownlist id="ddlQueryField" runat="server">
							<asp:ListItem Value="bk_nm" Selected="True">���y���O�W��</asp:ListItem>
						</asp:dropdownlist>
						<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="�}�l�j�M"></asp:button>
						<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="�������"></asp:button>
						&nbsp; &nbsp;
						<asp:button id="btnAddNew" runat="server" Height="23px" Font-Size="9pt" Text="�s�W���"></asp:button>
						<asp:button id="btnReturnHome" runat="server" Height="23px" Font-Size="9pt" Text="�^�t�έ���"></asp:button>
						<asp:Literal id="Literal1" runat="server"></asp:Literal>
					</TD>
				</TR>
			</TABLE>
		</form>
		<br>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server"></kw:footer>
	</body>
</HTML>
