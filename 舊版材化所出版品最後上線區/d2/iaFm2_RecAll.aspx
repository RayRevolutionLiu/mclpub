<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_RecAll.aspx.cs" Src="iaFm2_RecAll.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_RecAll" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���}�߳�^�_(Recovery) - �j��뵲</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- ���� Header -->
		<center><kw:header id="Header" runat="server"></kw:header></center>
		<!-- �ثe�Ҧb��m -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�o���}�߳�^�_(Recovery) - �j��뵲</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_RecAll" method="post" runat="server">
			<asp:Panel id="pnlQuery" runat="server">
<asp:label id="lblTitle" runat="server" Font-Size="Small" ForeColor="Blue" Font-Bold="True">�п�J�d�߱���G</asp:label>&nbsp;&nbsp; 
<asp:label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">(�����G�w��|�p�t�ΰ��B�z���o���}�߳�L�k���^�_�I)</asp:label><BR>
<asp:label id="lblIabDate" runat="server" Font-Size="X-Small" ForeColor="Maroon">�o���}�߳� �}�ߦ~��G</asp:label>
<asp:textbox id="tbxIabDate" runat="server" Width="60px" MaxLength="7"></asp:textbox>&nbsp;<FONT color="darkred" size="2">
					(�w�]�ȡG���A�p2002/08)</FONT><BR>
<asp:label id="lblIabNo" runat="server" Font-Size="X-Small" ForeColor="Maroon">�o���}�߳� �帹�G</asp:label>
<asp:textbox id="tbxIabNo" runat="server" Width="60px" MaxLength="6"></asp:textbox>&nbsp;<FONT color="red" size="2">
					(�Ц� "�o���}�߳� �ˮ֪�" �ѦҡA�ж񥿽T�ȡA�p 000001)</FONT><BR>
<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>&nbsp; 
<asp:Button id="btnClear" runat="server" Text="�M�����d"></asp:Button>
			</asp:Panel>
			<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:label>
			<asp:TextBox id="tbxLoginEmpNo" runat="server" Font-Size="X-Small" Width="50px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxLoginEmpCName" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox><br>
			<asp:RegularExpressionValidator id="revIabSeq" runat="server" Font-Size="X-Small" ValidationExpression="\d{6}" ControlToValidate="tbxIabNo" ErrorMessage="'�o���}�߳�帹' �Ш̮榡��J(�аѮ����r����)!!!"></asp:RegularExpressionValidator><br>
			<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxIabDate" ErrorMessage="'�o���}�߳� �}�ߦ~��' �Ш̮榡��J(�аѮ����r����)!!!"></asp:RegularExpressionValidator>
			<br>
			<!-- �ާ@�B�J -->
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">�ާ@�B�J�G�d�߫�N��ܸӧ���, �z�i<B>
					���C�L�^�_�M��</B>, �T�{��<B>�A���U '�T�{�^�_' ���s</B>!</asp:label><br>
			<!-- �o���}�߳� ��� DataGrid1 -->
			<asp:datagrid id="DataGrid1" runat="server" Font-Size="8pt" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1">
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="�ٿ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="�o���l�H�a�}">
						<HeaderStyle Wrap="False"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_iaditem" HeaderText="�o���}�߳���ӧǸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk1" HeaderText="�X���s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk2" HeaderText="�Z�n�~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk3" HeaderText="�����Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_desc" HeaderText="�~�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_projno" HeaderText="�p���N��"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_costctr" HeaderText="��������"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_qty" HeaderText="�ƶq"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_amt" HeaderText="���B"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<asp:Button id="btnRecovery" runat="server" Text="�T�{�^�_"></asp:Button><FONT face="�s�ө���">&nbsp;
				<asp:Button id="btnPrintList" runat="server" Text="�C�L�^�_�M��"></asp:Button></FONT>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
		<br>
		<!-- ���� Footer -->
		<center><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
