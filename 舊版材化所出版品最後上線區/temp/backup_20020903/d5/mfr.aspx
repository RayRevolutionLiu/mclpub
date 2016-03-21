<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Src="mfr.aspx.cs" Codebehind="mfr.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.mfr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�t�Ӹ�ƺ��@</TITLE>
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
		<form id="mfr" method="post" runat="server">
			<table id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
				<tr>
					<td align="left" width="100%" vAlign="top" height="22">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�t�Ӹ�ƺ��@ <FONT color="dimgray">(
								<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
								�@��
								<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
								����� )</FONT>
							<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
						</font>
					</td>
				</tr>
				<TR vAlign="top" height="224">
					<TD align="left" width="100%">
						<asp:DataGrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
							<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
							<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
							<ItemStyle BackColor="#BFCFF0"></ItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="mfr_mfrid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�ӲΤ@�s��"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="�o�����Y"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_iaddr" HeaderText="�o���a�}"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_izip" HeaderText="�t�Ӷl���ϸ�"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_respnm" HeaderText="�t�d�H�m�W"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_respjbti" HeaderText="���q�t�d�H¾��"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_tel" HeaderText="���q�p���q��"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_fax" HeaderText="���q�ǯu���X"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="mfr_regdate" HeaderText="���U���"></asp:BoundColumn>
								<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
								<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:DataGrid>
					</TD>
				</TR>
				<TR height="40">
					<TD align="left" width="100%">
						<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
						<asp:dropdownlist id="ddlQueryField" runat="server">
							<asp:ListItem Value="mfr_inm" Selected="True">�o�����Y</asp:ListItem>
							<asp:ListItem Value="mfr_mfrno">�Τ@�o���s��</asp:ListItem>
							<asp:ListItem Value="mfr_iaddr">�o���a�}</asp:ListItem>
							<asp:ListItem Value="mfr_tel">���q�p���q��</asp:ListItem>
						</asp:dropdownlist>
						<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="�}�l�j�M"></asp:button>
						<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="�������"></asp:button>
						<FONT face="�s�ө���">&nbsp;&nbsp;&nbsp;
							<asp:button id="btnAddNew" runat="server" Height="23px" Font-Size="9pt" Text="�s�W���"></asp:button>
						</FONT>
					</TD>
				</TR>
			</table>
		</form>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
