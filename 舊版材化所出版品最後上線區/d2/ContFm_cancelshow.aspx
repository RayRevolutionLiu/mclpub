<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="ContFm_cancelshow.aspx.cs" Src="ContFm_cancelshow.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_cancelshow" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��ܤw���P�X����</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
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
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							��ܤw���P�X����</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="ContFm_cancelshow" method="post" runat="server">
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
							<asp:textbox id="tbxMfrName" tabIndex="1" runat="server" AutoPostBack="True" Width="150px"></asp:textbox>
						</TD>
						<TD vAlign="top" rowSpan="4">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br> 2. �d�ߵ��G���]�t<font color='Red'>
									�����P</font> �����.<br><font color="gray">��: �קK���зs�W�t�Ӹ�� -
									<br>
									�Х� '��J<U>�t�ӲΤ@�s��</U>��, ���U<U>���䪺���s</U>�Ӭd��!</font><br> 3. ���d�ߵ��G�N�걵�� "�X���ѳB�z/����/��ܦX���θ������".<br> 4. �Y�z�Q��ܩҦ����, �Фſ�J����d������r, <br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�������U "�d��" �Y�i�o��������.</asp:label>
						</TD>
					</TR>
					<TR>
						<TD>
							�Τ@�s���G
							<asp:textbox id="tbxMfrNo" tabIndex="2" runat="server" AutoPostBack="True" Width="60px" MaxLength="10"></asp:textbox>
							&nbsp; <IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(tbxMfrNo.Text.ToString().Trim()); %>', '_new', 'Height=300, Width=400, Top=100, Left=200, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�d�߼t��" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<TR>
						<TD noWrap>
							�Ȥ�s���G
							<asp:textbox id="tbxCustNo" tabIndex="3" runat="server" AutoPostBack="True" Width="45px" MaxLength="6"></asp:textbox>
							&nbsp;(�����T����)
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							�Ȥ�m�W�G
							<asp:textbox id="tbxCustName" tabIndex="4" runat="server" AutoPostBack="True" Width="80px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							<FONT color="red">*</FONT>�X���s���G
							<asp:textbox id="tbxContNo" tabIndex="5" runat="server" AutoPostBack="True" Width="80px" MaxLength="6"></asp:textbox>
							&nbsp; 
							<!-- �d�߫��s --><asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;
							<asp:LinkButton id="lnbClear" runat="server">�M�����d</asp:LinkButton>
							<br>
							<!-- �d�ߵ��G��� --><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
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
									<asp:ButtonColumn Text="��ܦX����" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
