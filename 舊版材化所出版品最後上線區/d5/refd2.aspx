<%@ Page language="c#" Src="refd2.aspx.cs" Codebehind="refd2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.refd2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��SAP�ǲ����ӺK�n�ɸ�ƺ��@</TITLE>
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
		<form id="refd" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
						<TR>
							<TD align="left" width="100%" vAlign="top" height="22">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									�� SAP �ǲ��K�n�ɸ�ƺ��@ <FONT color="dimgray">(
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
										<asp:BoundColumn Visible="False" DataField="rd_rdid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="sys_nm" HeaderText="�t�ΥN�X�W��"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_projno" HeaderText="�p���N��"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_costctr" HeaderText="��������"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_accdcr" HeaderText="�ǲ��U���`�b���"></asp:BoundColumn>
										<asp:BoundColumn DataField="rd_descr" HeaderText="�ǲ��K�n"></asp:BoundColumn>
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
									<asp:ListItem Value="rd_descr" Selected="True">�ǲ��K�n</asp:ListItem>
									<asp:ListItem Value="sys_nm">�t�ΥN�X�W��</asp:ListItem>
									<asp:ListItem Value="rd_projno">�p���N��</asp:ListItem>
								</asp:DropDownList>
								<asp:button id="Query" runat="server" Text="�}�l�j�M" Font-Size="9pt" Height="23px"></asp:button>
								<asp:button id="btnShowAll" runat="server" Text="�������" Font-Size="9pt" Height="23px"></asp:button>
								&nbsp;&nbsp;&nbsp;
								<asp:button id="btnAddNew" runat="server" Text="�s�W���" Font-Size="9pt" Height="23px"></asp:button>
							</TD>
						</TR>
					</TABLE>
			</P>
			</FONT>
		</form>
	</body>
</HTML>
