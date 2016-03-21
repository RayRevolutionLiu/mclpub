<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Src="mfr.aspx.cs" Codebehind="mfr.aspx.cs" AutoEventWireup="false" Inherits="d5.mfr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
		<table id="tbItems" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td width="100%" align="left">
					<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						&nbsp;�@�P�ɮ�222 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�t�Ӹ�� </font>
				</td>
			</tr>
		</table>
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<form id="mfr" method="post" runat="server">
				<TR>
					<TD style="WIDTH: 64px" height="36">
						<P align="right">
							<FONT style="FONT-SIZE: 9pt" face="�s�ө���">�o�����Y�G</FONT>
						</P>
					</TD>
					<TD style="WIDTH: 159px" height="36">
						<asp:TextBox id="QString" runat="server" Width="96px" Height="21px"></asp:TextBox>
						<FONT face="�s�ө���"></FONT>
						<asp:Button id="Query" runat="server" Text="�j�M" Width="50px" Height="22px" Font-Size="9pt"></asp:Button>
					</TD>
					<TD height="36">
						<FONT face="�s�ө���">
							<asp:Button id="Addnew" runat="server" Text="�s�W�@�����" Width="118px" Height="22px" Font-Size="9pt"></asp:Button>
						</FONT>
					</TD>
				</TR>
		</table>
		<asp:DataGrid id="DataGrid1" style="FONT-SIZE: 9pt" runat="server" AutoGenerateColumns="False" BorderColor="Black" BorderWidth="1px" CellPadding="2" BackColor="White" AllowPaging="True">
			<HeaderStyle ForeColor="White" BackColor="#214389"></HeaderStyle>
			<PagerStyle Mode="NumericPages"></PagerStyle>
			<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
			<ItemStyle BackColor="#BFCFF0"></ItemStyle>
			<Columns>
				<asp:BoundColumn DataField="mfr_mfrid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�ӲΤ@�s��"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_inm" HeaderText="�o�����Y(���q�W��)"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_iaddr" HeaderText="�t��(�o���l�H)�a�}"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_izip" HeaderText="�t�Ӷl���ϸ�"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_respnm" HeaderText="���q�t�d�H�m�W"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_respnjbti" HeaderText="���q�t�d�H¾��"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_tel" HeaderText="���q�p���q��"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_fax" HeaderText="���q�ǯu���X"></asp:BoundColumn>
				<asp:BoundColumn DataField="mfr_regdate" HeaderText="���U���"></asp:BoundColumn>
				<asp:EditCommandColumn ButtonType="PushButton" UpdateText="��s" HeaderText="�ק�" CancelText="����" EditText="�ק�">
					<HeaderStyle BackColor="ControlDarkDark">
					</HeaderStyle>
				</asp:EditCommandColumn>
				<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete">
					<HeaderStyle BackColor="ControlDarkDark">
					</HeaderStyle>
				</asp:ButtonColumn>
			</Columns>
		</asp:DataGrid>
		<P>
		</P>
		</FORM> 
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
