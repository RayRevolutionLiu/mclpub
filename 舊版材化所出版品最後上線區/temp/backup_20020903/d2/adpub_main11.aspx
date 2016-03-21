<%@ Page language="c#" Codebehind="adpub_main11.aspx.cs" Src="adpub_main11.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main11" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i������ƺ��@ - �ѦX���Ѷi�J �B�J�G</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�i������ƪ����@: �ѦX���Ѷi�J&nbsp;�B�J�@ (�N��� ���@�X���� �e��!)</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_main" name="adpub_main" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 96%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<td colSpan="2">
							<font color="white">�d�߱���</font>
						</td>
					</TR>
					<TR>
						<TD>
							���q�W�١G
							<asp:textbox id="tbxMfrName" runat="server" AutoPostBack="True" tabIndex="1" Width="150px"></asp:textbox>
						</TD>
						<TD rowSpan="4" valign="top">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br> 2. �d�ߵ��G���]�t�w���ת����.<br><font color="gray">
									��: �קK���зs�W�t�Ӹ�� -
									<br>
									�Х� '��J<U>�t�ӲΤ@�s��</U>��, ���U<U>���䪺���s</U>�Ӭd��!</font><br> 3. ���d�ߵ��G�N�걵�� "�X���ѳB�z/�@��X��/�X���Ѻ��@".</asp:label>
						</TD>
					</TR>
					<TR>
						<TD>
							�Τ@�s���G
							<asp:textbox id="tbxMfrNo" runat="server" AutoPostBack="True" tabIndex="2" Width="60px" MaxLength="10"></asp:textbox>
							&nbsp; <IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(tbxMfrNo.Text.ToString().Trim()); %>', '_new', 'Height=300, Width=400, Top=100, Left=200, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�d�߼t��" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<TR>
						<TD nowrap>
							�Ȥ�s���G
							<asp:textbox id="tbxCustNo" runat="server" AutoPostBack="True" tabIndex="3" Width="45px" MaxLength="6"></asp:textbox>
							&nbsp;(�����T����)
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							�Ȥ�m�W�G
							<asp:textbox id="tbxCustName" runat="server" AutoPostBack="True" tabIndex="4" Width="80px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							<FONT Color="red">*</FONT>�X���s���G
							<asp:textbox id="tbxContNo" runat="server" AutoPostBack="True" tabIndex="5" Width="80px"></asp:textbox>
							&nbsp; 
							<!-- �d�߫��s -->
							<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>
							&nbsp; 
							<!-- �d�ߵ��G��� -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<!-- �s�W�t�өΫȤ� -->
						<td>
							&nbsp;
							<asp:LinkButton id="lnbNewMfr" runat="server" ForeColor="Blue" ToolTip="�s�W�t�Ӹ��">�s�W�t�Ӹ��</asp:LinkButton>
							&nbsp;
							<asp:LinkButton id="lnbNewCust" runat="server" ForeColor="Blue">�s�W�q����</asp:LinkButton>
						</td>
					</TR>
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
									<asp:BoundColumn DataField="bk_nm" HeaderText="���y���O"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��">
										<ItemStyle Width="80px">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="�«Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgclosed" HeaderText="�w����"></asp:BoundColumn>
									<asp:ButtonColumn Text="�ק︨��" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</BODY>
</HTML>
