<%@ Page language="c#" Codebehind="S_SearchCust1.aspx.cs" src="S_SearchCust1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.S_SearchCust1" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
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
		<form id="SearchCust1" method="post" runat="server">
			<center>
				<table>
					<tr>
						<td style="WIDTH: 627px" align="left">
							<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
								���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
								�q��d�� </font>
						</td>
					</tr>
				</table>
				<TABLE style="WIDTH: 610px" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td style="WIDTH: 550px" colSpan="2">
							<font color="white">�t�Ӹ��</font>
						</td>
					</tr>
					<TR>
						<TD style="WIDTH: 347px">
							���q�W�١G
							<asp:textbox id="tbxCompanyname" runat="server" Width="204px"></asp:textbox>
						</TD>
						<td rowSpan="2">
							<asp:label id="Label6" runat="server" ForeColor="DarkRed">1.�п�J����ȵM���"�d��"<br>
							2.���"�ק���"�i�i�J�q��ק�e��<br>3.���"�T�w"�i�J���q�ᤧ���v�q��e��</asp:label>
						</td>
					</TR>
					<TR>
						<TD style="WIDTH: 347px">
							�Τ@�s���G
							<asp:textbox id="tbxMfrno" runat="server" Width="80px"></asp:textbox>
							<asp:Label id="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							�q��s���G
							<asp:textbox id="tbxCustNo" runat="server" Width="80px"></asp:textbox>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							�q��m�W�G
							<asp:textbox id="tbxCustName" runat="server" Width="99px"></asp:textbox>
							<asp:linkbutton id="lnbShow" runat="server" ForeColor="#C000C0">�d��</asp:linkbutton>
							<asp:LinkButton id="lnbNewMfr" runat="server" ForeColor="Blue" ToolTip="�s�W�t�Ӹ��">�s�W�t�Ӹ��</asp:LinkButton>
							<asp:LinkButton id="lnbNewCust" runat="server" ForeColor="Blue">�s�W�q����</asp:LinkButton>
						</TD>
					</TR>
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" Runat="server" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:ButtonColumn Text="�ק���" CommandName="Modify"></asp:ButtonColumn>
									<asp:BoundColumn DataField="mfrnm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_custno" HeaderText="�q��s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno1" HeaderText="�¤u���s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno2" HeaderText="�¹q���s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�q��m�W">
										<ItemStyle Width="80px">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cust_jbti" HeaderText="�q��¾��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_regdate" HeaderText="���U���"></asp:BoundColumn>
									<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
			</center>
		</form>
		<!-- ���� Footer -->
		<kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
	</script>
	</body>
</HTML>
