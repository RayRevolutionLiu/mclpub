<%@ Page language="c#" Codebehind="cust.aspx.cs" src="cust.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.cust" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�Ȥ��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="JScript">
			function Delete_confirm(e) 
			{
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��")
					event.returnValue=confirm("�O�_�T�w�R��?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server"></kw:header>
		<CENTER>
			<FORM id="cust" method="post" runat="server">
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="90%" border="0">
						<TR>
							<TD vAlign="top" height="22">
								<FONT color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�@�P�ɮ�
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�Ȥ��ƺ��@
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
								<P align="left">
									<asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
										<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
										<ItemStyle BackColor="#BFCFF0"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="cust_custid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_jbti" HeaderText="�Ȥ�¾��"></asp:BoundColumn>
											<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӵo�����Y"></asp:BoundColumn>
											<asp:BoundColumn DataField="srspn_cname" HeaderText="�~�ȤH��"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_fax" HeaderText="�ǯu���X"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_cell" HeaderText="������X"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_email" HeaderText="Email �a�}"></asp:BoundColumn>
											<asp:BoundColumn DataField="cust_oldcustno" HeaderText="�«Ȥ�s��"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_regdate" HeaderText="���U���"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_moddate" HeaderText="�ק���"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_itpcd" HeaderText="�Ȥ���N�X"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_btpcd" HeaderText="�Ȥ���~�N�X"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="cust_rtpcd" HeaderText="�Ȥ�\Ū�N�X"></asp:BoundColumn>
											<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
											<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
									</asp:datagrid>
								</P>
							</TD>
						</TR>
						<TR>
							<TD height="40">
								<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
								<asp:dropdownlist id="ddlQueryField" runat="server">
									<asp:ListItem Value="cust_nm" Selected="True">�Ȥ�m�W</asp:ListItem>
									<asp:ListItem Value="cust_custno">�Ȥ�s��</asp:ListItem>
									<asp:ListItem Value="cust_oldcustno">�«Ȥ�s��</asp:ListItem>
									<asp:ListItem Value="mfr_inm">�t�ӵo�����Y</asp:ListItem>
									<asp:ListItem Value="cust_mfrno">�t�ӲΤ@�s��</asp:ListItem>
									<asp:ListItem Value="cust_tel">�p���q��</asp:ListItem>
									<asp:ListItem Value="cust_srspn_empno">�~�ȤH��</asp:ListItem>
								</asp:dropdownlist>
								<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="�}�l�j�M"></asp:button>
								<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="�������"></asp:button>
								&nbsp; &nbsp;
								<asp:button id="btnAddNew" runat="server" Height="23px" Font-Size="9pt" Text="�s�W���"></asp:button>
							</TD>
						</TR>
					</TABLE>
				</FONT>
			</FORM>
		</CENTER>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server"></kw:footer>
	</body>
</HTML>
