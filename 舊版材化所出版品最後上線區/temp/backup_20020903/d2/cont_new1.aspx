<%@ Page language="c#" Codebehind="cont_new1.aspx.cs" Src="cont_new1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_new1" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W�X���� �B�J�@</TITLE>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
			function doDetail()
			{
			//	strFeature = "";
			//	strFeature += "dialogHeight:350px;dialogWidth:600px;center:yes;scroll:yes;status:no;help:no;";
			var vReturn = window.open("CustDetail.aspx?id="); 
			}
		</script>
	</HEAD>
	<body>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<!-- �ثe�Ҧb��m -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px; HEIGHT: 24px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�W�X���� �B�J�@: �D�X�Ȥ�</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form -->
			<form id="cont_new1" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<td colSpan="2">
							<font color="white">�d�߱���</font>&nbsp;&nbsp; <FONT color="#ffffff">&nbsp;&nbsp;
								<asp:Label id="lblContTypeCode" runat="server" ForeColor="Yellow"></asp:Label>
							</FONT>
						</td>
					</TR>
					<TR>
						<TD>
							���q�W�١G
							<asp:textbox id="tbxCompanyName" runat="server" AutoPostBack="True" tabIndex="1" Width="150px"></asp:textbox>
						</TD>
						<TD rowSpan="3">
							<asp:label id="lblExplain" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
							2. �d�X��ƫ�, ���U "�ק�Ȥ���" �i�ק�ӫȤ᪺���.<br>3. �d�X��ƫ�, ���U "�T�w" �i�~��[�s�W�X����]�B�J, �ña�J�ӫȤ᪺�������.<br>
							<font color="gray">��: �קK���зs�W�t�Ӹ�� - �Х� '��J<U>�t�ӲΤ@�s��</U>��, ���U<U>���䪺���s</U>�Ӭd��!
									<br>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�p�d�L���, �A���U�褧 '<U>�s�W�t�Ӹ��</U>' �ӷs�W�t��!</font></asp:label>
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
						<TD>
							�Ȥ�m�W�G
							<asp:textbox id="tbxCustName" runat="server" AutoPostBack="True" tabIndex="4" Width="80px"></asp:textbox>
							<asp:linkbutton id="lnbShow" runat="server" tabIndex="5">�d��</asp:linkbutton>
						</TD>
						<TD>
							<asp:LinkButton id="lnbNewMfr" runat="server" ForeColor="Blue" ToolTip="�s�W�t�Ӹ��" tabIndex="6">�s�W�t�Ӹ��</asp:LinkButton>
							&nbsp;
							<asp:LinkButton id="lnbNewCust" runat="server" ForeColor="Blue" tabIndex="7">�s�W�Ȥ���</asp:LinkButton>
							<br>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
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
									<asp:ButtonColumn Text="�ק�Ȥ���" CommandName="Modify"></asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="cust_custid" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_jbti" HeaderText="�Ȥ�¾��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_regdate" HeaderText="���U���"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="�«Ȥ�s��" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
									<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
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
