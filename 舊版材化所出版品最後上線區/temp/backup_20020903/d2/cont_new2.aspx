<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="cont_new2.aspx.cs" Src="cont_new2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_new2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W�X���� �B�J�G</TITLE>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
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
							�s�W�X���� �B�J�G: �D�X�ӫȤ᪺���v�X���Ѹ��</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form -->
			<form id="cont_new2" method="post" runat="server">
				<A id="goback" href="cont_new1.aspx?function1=new&amp;conttp=01">�^�d�ߵe��</A>&nbsp;&nbsp;
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				&nbsp;&nbsp;
				<asp:button id="btnNew" runat="server" Visible="False" Text="�s�W�ťզX����"></asp:button>
				<br>
				<asp:Label id="lblCaption" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:Label>
				<asp:datagrid id="dgdCont" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="���y���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_aunm" HeaderText="�s�i�p���H�m�W"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_autel" HeaderText="�s�i�p���H�q��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="�@���I�M���O"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgclosed" HeaderText="���׵��O"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_disc" HeaderText="�u�f���"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_clrtm" HeaderText="�m�⦸��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_getclrtm" HeaderText="�M�⦸��"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_menotm" HeaderText="�¥զ���"></asp:BoundColumn>
						<asp:ButtonColumn Text="��ܦX�����v" CommandName="Detail"></asp:ButtonColumn>
						<asp:ButtonColumn Text="�T�w�s�W" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
					</Columns>
				</asp:datagrid>
				<asp:Label id="lblRemark" runat="server" ForeColor="#004040">&nbsp;</asp:Label>
				<asp:literal id="literal1" runat="server"></asp:literal>
			</form>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
