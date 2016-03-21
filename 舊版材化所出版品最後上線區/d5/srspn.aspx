<%@ Page language="c#" Src="srspn.aspx.cs" Codebehind="srspn.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.srspn" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�޲z�~�ȤH����ƺ��@</TITLE>
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
		<form id="srspn" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
						<TR>
							<TD align="left" width="100%" vAlign="top" height="22">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									�޲z�~�ȤH����ƺ��@ <FONT color="dimgray">(
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
								<asp:DataGrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
									<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
									<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
									<ItemStyle BackColor="#BFCFF0"></ItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="srspn_id" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_empno" HeaderText="�~�ȤH���u��"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_cname" HeaderText="�~�ȤH���m�W"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_tel" HeaderText="�~�ȤH���q��"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_atype" HeaderText="�~�ȤH���v���O"></asp:BoundColumn>
										<asp:BoundColumn DataField="OrgAbbName" HeaderText="�~�ȤH�����O"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_deptcd" HeaderText="�~�ȤH�������O"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_date" HeaderText="�~�ȤH�����U��"></asp:BoundColumn>
										<asp:BoundColumn DataField="srspn_pwd" HeaderText="�~�ȤH���K�X" Visible="False"></asp:BoundColumn>
										<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
										<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
									</Columns>
								</asp:DataGrid>
							</TD>
						</TR>
						<TR height="40">
							<TD align="left" width="100%">
								<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
								<asp:DropDownList id="ddlQueryField" runat="server">
									<asp:ListItem Value="srspn_cname" Selected="True">�~�ȤH���m�W</asp:ListItem>
									<asp:ListItem Value="srspn_empno">�~�ȤH���u��</asp:ListItem>
									<asp:ListItem Value="srspn_tel">�~�ȤH���q��</asp:ListItem>
								</asp:DropDownList>
								<asp:button id="Query" runat="server" Text="�}�l�j�M" Font-Size="9pt" Height="23px"></asp:button>
								<asp:button id="btnShowAll" runat="server" Text="�������" Font-Size="9pt" Height="23px"></asp:button>
								&nbsp;&nbsp;&nbsp;
								<asp:button id="btnAddNew" runat="server" Text="�s�W���" Font-Size="9pt" Height="23px"></asp:button>
							</TD>
						</TR>
						<TR height="40">
							<TD align="left" width="100%">
							<FONT size="2" color="#555555">�Ƶ��G A-���ε{���}�o�̡AB-�D�n�~�ȤH���AC-���n�~�ȤH���AD�V�|�~�~�ȤH���AE�V�q��H���AF-�|�p�H��<br><font color=red>�ܧ�ۤv���v����A�����������s�n�J�t�ΡC</font></FONT>
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
