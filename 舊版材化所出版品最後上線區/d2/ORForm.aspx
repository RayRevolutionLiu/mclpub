<%@ Page language="c#" Codebehind="ORForm.aspx.cs" Src="ORForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W/�ק�/�R�� ���x����H���</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- JScript -->
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��")
					event.returnValue=confirm("�O�_�T�w�R��?")
			}
			document.onclick=Delete_confirm;
		</script>
		<!-- JavaScript -->
		<script language="JavaScript">
			function WindowClose()
			{ 
				// ���s��z �e�@�����ʧ@
				window.opener.RefreshMe(); 
				
				// ����������
				window.close();
			}
		</script>
	</HEAD>
	<body>
		<form id="ORForm" method="post" runat="server">
			<!-- ���x����H ���v��� �� --><font color="#ff0066" size="2">[���x����H ���v��� ��]</font>
			<asp:label id="lblMfrInfo" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:label><FONT color="#ff0066" size="2">&nbsp;
			</FONT>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="���J���" HeaderText="���J���" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="¾��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="�l�H�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="���n����"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_unpubcnt" HeaderText="���n����"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_mtpcd" HeaderText="�l�H���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fgmosea" HeaderText="���~�l�H"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:label id="lblHistoryMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small" DESIGNTIMEDRAGDROP="424"></asp:label><br>
			<!-- ���x����H �s�W/�ק��� �� --><font color="#ff0066" size="2">[���x����H �s�W/�ק��� ��]</font>
			<asp:textbox id="tbxORSysCode" runat="server" Font-Size="X-Small" MaxLength="2" WIDTH="30px" Enabled="False" Visible="False">C2</asp:textbox><FONT color="#ff0066" size="2">&nbsp;
				<asp:textbox id="tbxORContNo" runat="server" Font-Size="X-Small" MaxLength="6" WIDTH="50px" Enabled="False" Visible="False"></asp:textbox>&nbsp;&nbsp;
				<asp:label id="lblMfrNo" runat="server" Visible="False"></asp:label><asp:label id="lblCustNo" runat="server" Visible="False"></asp:label></FONT><FONT color="#c00000" size="2">���קאּ���P�t��/�Ȥ���, 
				�Ы��U <IMG class="ico" id="imgCustDetail" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">�ϥܨӷj�M���!</FONT>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							�Ǹ�
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>���q�W��<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�t�ӸԲӸ��" src="../images/edit.gif" width="18" border="0">
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�m�W<IMG class="ico" id="Img1" onclick="javascript:window.open('../d5/Cust.aspx>', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">
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
						<TD><asp:label id="lblORItem" runat="server" Font-Size="X-Small"></asp:label></TD>
						<TD><asp:textbox id="tbxORMfrIName" runat="server" Font-Size="X-Small" MaxLength="50" Width="80px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORName" runat="server" Font-Size="X-Small" MaxLength="30" Width="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORJobTitle" runat="server" Font-Size="X-Small" MaxLength="12" Width="70px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORTel" runat="server" Font-Size="X-Small" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORPubCount" runat="server" Font-Size="X-Small" MaxLength="3" WIDTH="30px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORUnPubCount" runat="server" Font-Size="X-Small" MaxLength="3" WIDTH="30px"></asp:textbox></TD>
						<TD><asp:dropdownlist id="ddlORmtpcd" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD><asp:dropdownlist id="ddlORfgmosea" runat="server">
								<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
								<asp:ListItem Value="1">��~</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<!-- �ĤG�� -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH colSpan="3">
							�l���ϸ�&nbsp;&amp;&nbsp;&nbsp;�l�H�a�}
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
						<TD>&nbsp;
						</TD>
						<TD colSpan="3"><asp:textbox id="tbxORZipcode" runat="server" Font-Size="X-Small" MaxLength="5" Width="40px"></asp:textbox>&nbsp;
							<asp:textbox id="tbxORAddr" runat="server" Font-Size="X-Small" MaxLength="120" WIDTH="230px"></asp:textbox></TD>
						<TD><asp:textbox id="tbxORFax" runat="server" Font-Size="X-Small" MaxLength="30" WIDTH="90px"></asp:textbox></TD>
						<TD colSpan="2"><asp:textbox id="tbxORCell" runat="server" Font-Size="X-Small" MaxLength="30" WIDTH="80px"></asp:textbox></TD>
						<TD colSpan="2"><asp:textbox id="tbxOREmail" runat="server" Font-Size="X-Small" MaxLength="80" WIDTH="160px"></asp:textbox></TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* ���������!</FONT>
			<br>
			<asp:button id="btnSave" runat="server" Text="�x�s�s�W"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModify" runat="server" Text="�x�s�ק�"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnLoadData" runat="server" Text="���J�w�]���"></asp:button>&nbsp;
			<asp:button id="btnClearAll" runat="server" Text="�M�����"></asp:button>&nbsp;&nbsp;&nbsp;
			<INPUT id="btnClose" onclick="Javascript:WindowClose();" type="button" value="��������" name="btnClose">
			<br>
			<br>
			<font color="#ff0066" size="2">[�w�s�W ���x����H��� ��]</font>
			<br>
			<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="�ק�" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="¾��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="�l�H�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="���n����"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_unpubcnt" HeaderText="���n����"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_mtpcd" HeaderText="�l�H���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fgmosea" HeaderText="���~�l�H"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
		<br>
		<font color="darkred" size="2">�ާ@�����G</font>
		<br>
		<font size="2">�s�W���-����v��, �� <U>���J���</U>, �Ϋ� "���J�w�]���" ���s, ��ƽT�{��, �� "�x�s�s�W" ���s.
			<br>
			�ק���-��w�s�W�Ϫ��Ӹ�Ʀ�, ���U <U>�ק�</U>, ��ƽT�{��, �� "�x�s�ק�" ���s.
			<br>
			�R�����-��w�s�W�Ϫ��Ӹ�Ʀ�, ���U "<U>�R��</U>" �Y�i.</font>
		<br>
		<font color="blue" size="2">�����ާ@����, �� "��������" �Ӧ^��W�@��.</font>
	</body>
</HTML>
