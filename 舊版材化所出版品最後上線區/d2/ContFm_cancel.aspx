<%@ Page language="c#" Codebehind="ContFm_cancel.aspx.cs" Src="ContFm_cancel.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_cancel" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���P�X����</TITLE>
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
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							���P�X����</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="ContFm_cancel" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 96%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<TD colSpan="2">
							<font color="white">�d�߱���</font>
						</TD>
					</TR>
					<TR>
						<TD>
							���q�W�١G
							<asp:textbox id="tbxMfrName" tabIndex="1" runat="server" Width="150px" AutoPostBack="True"></asp:textbox>
						</TD>
						<TD vAlign="top" rowSpan="4">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br> 2. �d�ߵ��G���]�t<font color='Red'>
									�w���P</font> �����.<br><font color="gray">��: �קK���зs�W�t�Ӹ�� -
									<br>
									�Х� '��J<U>�t�ӲΤ@�s��</U>��, ���U<U>���䪺���s</U>�Ӭd��!</font><br> 3. ���d�ߵ��G�N�걵�� "�X���ѳB�z/����/<br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��ܦX���θ������".<br> 4. �Y�z�Q��ܩҦ����, �Фſ�J����d������r, <br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�������U "�d��" �Y�i�o��������.<br> 5. �Ŀ��, �Ы� "�T�{���P" ���s����!</asp:label>
						</TD>
					</TR>
					<TR>
						<TD>
							�Τ@�s���G
							<asp:textbox id="tbxMfrNo" tabIndex="2" runat="server" Width="60px" AutoPostBack="True" MaxLength="10"></asp:textbox>
							&nbsp; <IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(tbxMfrNo.Text.ToString().Trim()); %>', '_new', 'Height=300, Width=400, Top=100, Left=200, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�d�߼t��" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<TR>
						<TD noWrap>
							�Ȥ�s���G
							<asp:textbox id="tbxCustNo" tabIndex="3" runat="server" Width="45px" AutoPostBack="True" MaxLength="6"></asp:textbox>
							&nbsp;(�����T����)
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							�Ȥ�m�W�G
							<asp:textbox id="tbxCustName" tabIndex="4" runat="server" Width="80px" AutoPostBack="True" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							<FONT color="red">*</FONT>�X���s���G
							<asp:textbox id="tbxContNo" tabIndex="5" runat="server" Width="80px" AutoPostBack="True" MaxLength="6"></asp:textbox>&nbsp; 
							<!-- �d�߫��s --><asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;
							<asp:linkbutton id="lnbClear" runat="server">�M�����d</asp:linkbutton>
							<!-- �d�ߵ��G��� --><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:datagrid id="DataGrid1" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Runat="server">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cont_bkcd" HeaderText="���y�N�X"></asp:BoundColumn>
									<asp:BoundColumn DataField="bk_nm" HeaderText="���y���O"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_sdate" HeaderText="�X���_��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_edate" HeaderText="�X������"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="�«Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgclosed" HeaderText="�w����"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgpubed" HeaderText="�w����"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="���P">
										<ItemTemplate>
											<asp:CheckBox id="cbxCancel" runat="server" Checked='<%# GetfgUpdate(DataBinder.Eval(Container.DataItem, "cont_fgcancel")) %>'>
											</asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="��ܦX����" ButtonType="PushButton" HeaderText="��ܦX����" CommandName="ShowCont"></asp:ButtonColumn>
									<asp:ButtonColumn Text="���@�X����" ButtonType="PushButton" HeaderText="���@�X����" CommandName="ModifyCont"></asp:ButtonColumn>
								</Columns>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
				<!-- �T�{���P ���s -->
				<br>
				<asp:button id="btnCancel" runat="server" Text="�T�{���P"></asp:button>
			</form>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
