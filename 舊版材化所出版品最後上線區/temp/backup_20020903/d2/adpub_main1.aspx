<%@ Page language="c#" Codebehind="adpub_main1.aspx.cs" Src="adpub_main1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�s�i������ƺ��@</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<center>
			<!-- ���� Header -->
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�i������ƪ��s�W�P���@ �B�J�@</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- ���D -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">�s�i������ƪ��s�W�P���@</FONT></B><FONT color="darkred" size="3">&nbsp;(�B�J�@: 
					�j�M�������;&nbsp;</FONT></B></FONT><FONT color="darkred" size="3"> �ثe�u���ѷj�M�ο��)</FONT></B>&nbsp;
			</DIV>
			<!-- Run at Server Form -->
			<form id="adpub_main" name="adpub_main" method="post" runat="server">
				<!-- �j�M�t�ӤΫȤ᪺ Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">�t�Ӹ��</font>
						</td>
					</tr>
					<TR>
						<TD>
							���q�W�١G
							<asp:textbox id="tbxMfrName" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
						<td rowSpan="5">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@����ȨӬd��, �M����U "�d��".<br><br>
							2. �d�X��ƫ�, ���U "�ק���" �i�ק�ӫȤ᪺���.<br>3. �d�X��ƫ�, ���U "�ԲӸ��" �i�ݨ�ӫȤ᪺���v���.<br>4. �d�X��ƫ�, ���U "�T�w" �i�i���ƺ��@�u�@.</asp:label>
						</td>
					</TR>
					<TR>
						<TD>
							�Τ@�s���G
							<asp:textbox id="tbxMfrNo" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							�Ȥ�s���G
							<asp:textbox id="tbxCustNo" runat="server" Height="18px" Width="99px"></asp:textbox>
							&nbsp;(�����T����)
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							�Ȥ�m�W�G
							<asp:textbox id="tbxCustName" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							�X���s���G
							<asp:textbox id="tbxContNo" runat="server" Height="18px" Width="99px"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							�Z�n�~��G
							<asp:textbox id="tbxPubDate" runat="server" Height="18px" Width="99px"></asp:textbox>
							&nbsp;
							<br>
							(�п�J 2~6�X�Ʀr, �p�E�@�~�@��, �п�J&nbsp;9101)
						</TD>
						<!-- �d�߫��s -->
						<td>
							<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>
							&nbsp;
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</td>
					</TR>
					<TR>
						<TD>
							�L�o����G
							<asp:DropDownList id="ddlDataFilter" runat="server" Height="18px">
								<asp:ListItem Value="0" Selected="True">�Ҧ����</asp:ListItem>
								<asp:ListItem Value="1">���Z�n</asp:ListItem>
							</asp:DropDownList>
						</TD>
					</TR>
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" BorderColor="#3366CC" Runat="server" AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:ButtonColumn Text="�ק���" CommandName="Modify"></asp:ButtonColumn>
									<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_date" HeaderText="�Z�n�~��"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_custno" HeaderText="�q��s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�q��m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:ButtonColumn Text="�ԲӸ��" CommandName="Detail"></asp:ButtonColumn>
									<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- ���� Footer -->
		</center>
	</BODY>
</HTML>
