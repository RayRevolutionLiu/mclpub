<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="SaveMessage.aspx.cs" src="SaveMessage.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.SaveMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="SaveMessage" method="post" runat="server">
			<CENTER>
				<asp:label id="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:label>
				<br>
				<A id="hp1" href="NewCust.aspx" runat="server">�~��s�W�q��</A>
				<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" Visible="False">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn DataField="orderno" HeaderText="�q��s��">
							<ItemStyle Wrap="False">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="otp_otp1nm" HeaderText="�q�����O">
							<HeaderStyle Width="28px">
							</HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="o_mfrno" HeaderText="�Τ@�s��"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="�q��m�W">
							<ItemStyle Width="40px">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�">
							<ItemStyle Width="10px">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="����H">
							<ItemStyle Wrap="False">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
						<asp:ButtonColumn Text="�ɮ�" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid>
			</CENTER>
		</form>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
	</body>
</HTML>
