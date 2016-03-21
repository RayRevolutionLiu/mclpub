<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Src="otp.aspx.cs" Codebehind="otp.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.otp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�q��ӷ��ɸ�ƺ��@</TITLE>
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
		<form id="btp" method="post" runat="server">
			<P>
				<FONT face="�s�ө���">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="720" border="0" align="center">
						<TR>
							<TD align="left" width="100%" vAlign="top" height="22">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
									�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
									�q�����O�ɸ�ƺ��@ <FONT color="dimgray">(
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
										<asp:BoundColumn Visible="False" DataField="otp_otpid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
										<asp:BoundColumn DataField="otp_otp1cd" HeaderText="�q�����O1�N�X"></asp:BoundColumn>
										<asp:BoundColumn DataField="otp_otp1nm" HeaderText="�q�����O1�W��"></asp:BoundColumn>
										<asp:BoundColumn DataField="otp_otp2cd" HeaderText="�q�����O2�N�X"></asp:BoundColumn>
										<asp:BoundColumn DataField="otp_otp2nm" HeaderText="�q�����O2�W��"></asp:BoundColumn>
										<asp:ButtonColumn Text="�ק�" ButtonType="PushButton" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
										<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
									</Columns>
								</asp:DataGrid>
							</TD>
						</TR>
						<TR>
							<TD align="left" width="100%" height="40">
								<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
								<asp:DropDownList id="ddlQueryField" runat="server">
									<asp:ListItem Value="otp_otp1nm" Selected="True">�q�����O1�W��</asp:ListItem>
									<asp:ListItem Value="otp_otp2nm">�q�����O2�W��</asp:ListItem>
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
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
