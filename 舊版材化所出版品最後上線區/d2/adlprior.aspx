<%@ Page language="c#" Codebehind="adlprior.aspx.cs" Src="adlprior.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�����u������ - ����s��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
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
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>&nbsp; 
			<!-- Run at Server Form -->
			<form id="adlprior" method="post" runat="server">
				<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<!-- �ثe�Ҧb��m & Query Line -->
					<TR>
						<TD width="5%">
							&nbsp;
						</TD>
						<TD vAlign="top" width="*">
							<FONT title="���y��ƺ��@" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�����s�i���t��
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �������@��
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �����u������ 
								- ����s�� (
								<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
								�@��
								<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
								����� )</FONT>
							<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label></FONT>
						</TD>
					</TR>
					<!-- �Ƶ� -->
					<TR>
						<TD align="left" colSpan="2">
							<font color="darkred" size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���G���קK�¸��Ū�����~�A�Y�ӵ��w�Q�ϥ�(����&gt;0)�A�N�����\�ק�/�R���I</font>
						</TD>
					</TR>
					<!-- DataGrid: �۸�Ʈw��̷s��� -->
					<TR>
						<TD>
							&nbsp;
						</TD>
						<TD vAlign="top">
							<asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
								<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
								<ItemStyle BackColor="#BFCFF0"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="lp_lpid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="lp_priorseq" HeaderText="�ƪ��u������">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ltp_nm" HeaderText="�s�i����"></asp:BoundColumn>
									<asp:BoundColumn DataField="clr_nm" HeaderText="�s�i��m"></asp:BoundColumn>
									<asp:BoundColumn DataField="pgs_nm" HeaderText="�s�i�g�T"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_bkcd" HeaderText="���y�N�X"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_ltpcd" HeaderText="�s�i�����N�X"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_clrcd" HeaderText="�s�i��m�N�X"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_pgscd" HeaderText="�s�i�g�T�N�X"></asp:BoundColumn>
									<asp:BoundColumn DataField="PubCounts" HeaderText="�w�ϥΤ���������"></asp:BoundColumn>
									<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
									<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
					<!-- �Ƶ� -->
					<TR>
						<TD align="left" colSpan="2">
							<font color="darkred" size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���G���קK�¸��Ū�����~�A�Y�ӵ��w�Q�ϥ�(����&gt;0)�A�N�����\�ק�/�R���I</font>
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
								<asp:ListItem Value="bk_nm" Selected="True">���y�W��</asp:ListItem>
								<asp:ListItem Value="lp_priorseq">�ƪ��u������</asp:ListItem>
								<asp:ListItem Value="ltp_nm">�s�i����</asp:ListItem>
								<asp:ListItem Value="clr_nm">�s�i��m</asp:ListItem>
								<asp:ListItem Value="pgs_nm">�s�i�g�T</asp:ListItem>
							</asp:dropdownlist>
							<asp:button id="Query" runat="server" Text="�}�l�j�M" Font-Size="9pt" Height="23px"></asp:button>
							<asp:button id="btnShowAll" runat="server" Text="�������" Font-Size="9pt" Height="23px"></asp:button>
							&nbsp; &nbsp;
							<asp:button id="btnAddNew" runat="server" Text="�s�W���" Font-Size="9pt" Height="23px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="�^�t�έ���" Font-Size="9pt" Height="23px"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
