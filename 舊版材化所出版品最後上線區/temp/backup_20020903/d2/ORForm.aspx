<%@ Page language="c#" Codebehind="ORForm.aspx.cs" Src="ORForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W ���x����H���</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- JScript -->
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��")
					event.returnValue=confirm("�O�_�T�w�R��?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<form id="ORForm" method="post" runat="server">
			<!-- ���x����H ���v��� �� -->
			<font color="#ff0066" size="2">[���x����H ���v��� ��]</font>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="¾��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="���n����"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_unpubcnt" HeaderText="���n����"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_mtpcd" HeaderText="�l�H���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fgmosea" HeaderText="���~�l�H"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<br>
			<!-- ���x����H �s�W/�ק��� �� -->
			<font color="#ff0066" size="2">[���x����H �s�W/�ק��� ��]</font>
			<asp:label id="lblORItem" runat="server" Font-Size="X-Small"></asp:label>
			<FONT color="#ff0066" size="2">&nbsp;
				<asp:label id="lblMfrInfo" runat="server" ForeColor="Blue"></asp:label>
				&nbsp;
				<asp:label id="lblMfrNo" runat="server" Visible="False"></asp:label>
				<asp:label id="lblCustNo" runat="server" Visible="False"></asp:label>
			</FONT>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							�t��
							<br>
							�N�X
						</TH>
						<TH>
							�X����
							<br>
							�s��
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>���q�W��<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�t�ӸԲӸ��" src="../images/edit.gif" width="18" border="0">
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�m�W<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('../d5/Cust.aspx>', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">
						</TH>
						<TH>
							¾��
						</TH>
						<TH>
							�q��
						</TH>
						<TH>
							���n
							<br>
							����
						</TH>
						<TH>
							���n
							<br>
							����
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�l�H���O
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>���~
							<br>
							�l�H
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD>
							<asp:textbox id="tbxORSysCode" runat="server" MaxLength="2" WIDTH="30px" Font-Size="X-Small" Enabled="False">C2</asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORContNo" runat="server" MaxLength="6" WIDTH="50px" Font-Size="X-Small" Enabled="False"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORMfrIName" runat="server" MaxLength="50" Font-Size="X-Small" Width="80px"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORName" runat="server" MaxLength="30" Font-Size="X-Small" Width="70px"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORJobTitle" runat="server" MaxLength="12" Font-Size="X-Small" Width="70px"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORTel" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORPubCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORUnPubCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORmtpcd" runat="server"></asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORfgmosea" runat="server">
								<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
								<asp:ListItem Value="1">��~</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<!-- �ĤG�� -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH>
							�l��
							<br>
							�ϸ�
						</TH>
						<TH colSpan="3">
							�a�}
						</TH>
						<TH>
							�ǯu
						</TH>
						<TH colSpan="2">
							���
						</TH>
						<TH colSpan="2">
							Email
						</TH>
					</TR>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
						</TD>
						<TD>
							<asp:textbox id="tbxORZipcode" runat="server" MaxLength="5" Font-Size="X-Small" Width="40px"></asp:textbox>
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxORAddr" runat="server" MaxLength="120" WIDTH="230px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORFax" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxORCell" runat="server" MaxLength="30" WIDTH="80px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxOREmail" runat="server" MaxLength="80" WIDTH="160px" Font-Size="X-Small"></asp:textbox>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">��1�G* ���������!</FONT>
			<br>
			<FONT color="#c00000" size="2">��2�G�w�]��ܤ��t�Ӹ�Ƭ��ӫȤᤧ�t�Ӹ��;
				<br>
				���קאּ���P�t��/�Ȥ���, �Ы��U <IMG class="ico" id="imgCustDetail" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">�ϥܨӷj�M���, 
				�A�N�ƻs��r�a�^�����K�W!</FONT>
			<br>
			<br>
			<asp:button id="btnSave" runat="server" Text="�x�s�s�W"></asp:button>
			&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="�x�s�ק�"></asp:button>
			&nbsp;&nbsp; <INPUT id="btnClose" onclick="Javascript:window.close();" type="button" value="��������" name="btnClose">
		</form>
	</body>
</HTML>
