<%@ Page language="c#" Codebehind="lostbk_search.aspx.cs" Src="lostbk_search.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk_search" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�ʮѳB�z �B�J�@: �d��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�ʮѳB�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�B�J�@: �d��</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form-->
			<form id="lostbk_search" method="post" runat="server">
				<TABLE style="WIDTH: 80%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">�Ȥ���</font>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							�X���ѽs���G
						</TD>
						<td>
							<asp:textbox id="tbxContNo" runat="server" Width="80px"></asp:textbox>
						</td>
						<TD align="right">
							&nbsp;
						</TD>
						<TD>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							���q�W�١G
						</TD>
						<TD>
							<asp:textbox id="tbxMfrIName" runat="server" Width="150px"></asp:textbox>
						</TD>
						<TD align="right">
							�t�Ӳνs�G
						</TD>
						<TD>
							<asp:textbox id="tbxMfrNo" runat="server" Width="60px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							�Ȥ�s���G
						</TD>
						<TD>
							<asp:textbox id="tbxCustNo" runat="server" Width="45px" MaxLength="6"></asp:textbox>
							&nbsp;(�����T����)
						</TD>
						<TD align="right">
							�Ȥ�m�W�G
						</TD>
						<TD>
							<asp:textbox id="tbxCustName" runat="server" Width="80px"></asp:textbox>
						</TD>
					</TR>
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">���x����H���</font>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							����H�m�W�G
						</TD>
						<TD>
							<asp:textbox id="tbxORName" runat="server" Width="80px"></asp:textbox>
						</TD>
						<TD align="right">
							����H�q�ܡG
						</TD>
						<TD>
							<asp:textbox id="tbxORTel" runat="server" Width="100px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							����H�a�}�G
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxORAddr" runat="server" Width="400px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD align="right">
							�H�Ѫ��A�G
						</TD>
						<TD colSpan="3">
							<asp:radiobuttonlist id="rblSent" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="0" Selected="True">���H�X</asp:ListItem>
								<asp:ListItem Value="1">�w�H�X</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
					</TR>
				</TABLE>
				<asp:linkbutton id="lnbSearch" runat="server" ForeColor="#C000C0">�d��</asp:linkbutton>&nbsp;&nbsp;
				<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>
				<asp:label id="lblMessage" runat="server" ForeColor="#C00000" Visible="False" Font-Size="X-Small"></asp:label>
				<br>
				<br>
				<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" AllowPaging="True">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgclosed" HeaderText="�w����"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="�����H�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_addr" HeaderText="����a�}"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgpubed" HeaderText="�w����"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgcancel" HeaderText="�w���P"></asp:BoundColumn>
						<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
				</asp:datagrid>
				<br>
				<br>
				<asp:datagrid id="DataGrid2" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:ButtonColumn Text="�R��" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
						<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��">
							<ItemStyle Wrap="False"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="lst_seq" HeaderText="�ʮѧǸ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W">
							<ItemStyle Wrap="False"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="lst_oritem" HeaderText="�����H�Ǹ�"></asp:BoundColumn>
						<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_cont" HeaderText="�ʮѤ��e"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_date" HeaderText="�ʮѤ��"></asp:BoundColumn>
						<asp:BoundColumn DataField="lst_fgsent" HeaderText="�w�H�X"></asp:BoundColumn>
						<asp:ButtonColumn Text="�ק���" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid></TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
