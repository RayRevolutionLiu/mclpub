<%@ Page language="c#" Codebehind="InvMfrForm.aspx.cs" Src="InvMfrForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvMfrForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W/�ק�/�R�� �o���t�Ӧ���H���</TITLE>
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
		<form id="InvMfrForm" method="post" runat="server">
			<!-- �o���t�Ӧ���H ���v��� �� --><FONT color="#ff0066" size="2">[�o���t�Ӧ���H ���v��� ��]&nbsp;&nbsp; </FONT>
			<asp:Label id="lblMfrInfo" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:Label>
			<FONT color="#ff0066" size="2">&nbsp; </FONT>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="���J���" HeaderText="���J���" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_addr" HeaderText="�o���a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:Label id="lblHistoryMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon" DESIGNTIMEDRAGDROP="742"></asp:Label>
			<br>
			<!-- �o���t�Ӧ���H �s�W/�ק��� �� -->
			<font color="#ff0066" size="2">[�o���t�Ӧ���H �s�W/�ק��� ��]</font>
			<asp:textbox id="tbxIMSysCode" runat="server" Enabled="False" WIDTH="30px" MaxLength="2" Visible="False">C2</asp:textbox>
			<FONT color="#ff0066" size="2">&nbsp;
				<asp:textbox id="tbxIMContNo" runat="server" Enabled="False" WIDTH="50px" MaxLength="6" Visible="False"></asp:textbox>
				&nbsp;&nbsp;
				<asp:Label id="lblMfrNo" runat="server" Visible="False"></asp:Label>
				&nbsp;
				<asp:Label id="lblCustNo" runat="server" Visible="False"></asp:Label>
			</FONT><FONT color="#c00000" size="2">���קאּ���P�t��/�Ȥ���, �Ы��U <IMG class="ico" id="imgCustDetail" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">�ϥܨӷj�M���!</FONT>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							�Ǹ�
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�t��
							<br>
							�νs<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('../d5/Mfr.aspx', '_new', 'Height=400, Width=600, Top=50, Left=50, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�t�ӸԲӸ��" src="../images/edit.gif" width="18" border="0">
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
							<FONT color="#c00000" size="2">*</FONT>�o��
							<br>
							���O
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�o��
							<br>
							�ҵ|�O
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>�|�Ҥ�
							<br>
							���O
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD>
							<asp:Label id="lblImSeq" runat="server" Font-Size="X-Small"></asp:Label>
						</TD>
						<TD>
							<asp:textbox id="tbxIMMfrNo" runat="server" WIDTH="70px" MaxLength="10"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMName" runat="server" WIDTH="70px" MaxLength="30"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMJobTitle" runat="server" WIDTH="70px" MaxLength="12"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMTel" runat="server" WIDTH="90px" MaxLength="30"></asp:textbox>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlIMInvtp" runat="server">
								<asp:ListItem Value="2">�G�p</asp:ListItem>
								<asp:ListItem Value="3" Selected="True">�T�p</asp:ListItem>
								<asp:ListItem Value="4">��L</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlIMTaxtp" runat="server">
								<asp:ListItem Value="1" Selected="True">���|5%</asp:ListItem>
								<asp:ListItem Value="2">�s�|</asp:ListItem>
								<asp:ListItem Value="3">�K�|</asp:ListItem>
							</asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlIMfgITRI" runat="server">
								<asp:ListItem Value="" Selected="True">�_</asp:ListItem>
								<asp:ListItem Value="06">�Ҥ�</asp:ListItem>
								<asp:ListItem Value="07">�|��</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<!-- �ĤG�� -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH colSpan="3">
							�l���ϸ�&nbsp;&amp;&nbsp;&nbsp;�o���a�}
						</TH>
						<TH>
							�ǯu
						</TH>
						<TH>
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
						<TD colSpan="3">
							<asp:textbox id="tbxIMZipcode" runat="server" WIDTH="40px" MaxLength="5"></asp:textbox>
							&nbsp;
							<asp:textbox id="tbxIMAddr" runat="server" WIDTH="230px" MaxLength="120"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMFax" runat="server" WIDTH="90px" MaxLength="30"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxIMCell" runat="server" WIDTH="80px" MaxLength="30"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxIMEmail" runat="server" WIDTH="160px" MaxLength="80"></asp:textbox>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">* ���������!</FONT>
			<br>
			<asp:button id="btnSave" runat="server" Text="�x�s�s�W"></asp:button>
			&nbsp;&nbsp;
			<asp:Button id="btnModify" runat="server" Text="�x�s�ק�"></asp:Button>
			&nbsp;&nbsp;
			<asp:Button id="btnLoadData" runat="server" Text="���J�w�]���"></asp:Button>
			&nbsp; &nbsp; <INPUT id="btnClose" type="button" value="��������" onclick="Javascript:WindowClose();" name="btnClose">
			<br>
			<br>
			<font color="#ff0066" size="2">[�w�s�W �o���t�Ӧ���H��� ��]</font>
			<br>
			<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:ButtonColumn Text="�ק�" HeaderText="�ק�" CommandName="Select"></asp:ButtonColumn>
					<asp:ButtonColumn Text="�R�� " HeaderText="�R��" CommandName="Delete"></asp:ButtonColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_addr" HeaderText="�o���a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
		</form>
		<br>
		<font size="2" color="darkred">�ާ@�����G</font>
		<br>
		<font size="2">�s�W���-����v��, �� <U>���J���</U>, �Ϋ� "���J�w�]���" ���s, ��ƽT�{��, �� "�x�s�s�W" ���s.
			<br>
			�ק���-��w�s�W�Ϫ��Ӹ�Ʀ�, ���U <U>�ק�</U>, ��ƽT�{��, �� "�x�s�ק�" ���s.
			<br>
			�R�����-��w�s�W�Ϫ��Ӹ�Ʀ�, ���U "<U>�R��</U>" �Y�i.</font>
		<br>
		<font size="2" color="blue">�����ާ@����, �� "��������" �Ӧ^��W�@��.</font>
	</body>
</HTML>
