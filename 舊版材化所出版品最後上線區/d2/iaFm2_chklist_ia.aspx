<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_chklist_ia.aspx.cs" Src="iaFm2_chklist_ia.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_chklist_ia" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�o���}�߳��ˮ֪� - �j��뵲</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		function pick_date(theField){
		var oParam = new Object();
		strFeature = "";
		strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
		var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature);
		if(vreturn)
			window.document.all(theField).value=vreturn;
		return true;
		}

		function doClose()
		{
			window.close();
		}
		</script>
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
						�o���}�߳��ˮ֪� - �j��뵲</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_chklist_ia" method="post" runat="server">
			<asp:panel id="pnlQuery" runat="server">
					<asp:label id="lblBkcd" runat="server">���y���O�G</asp:label>
					<asp:dropdownlist id="ddlBkcd" runat="server"></asp:dropdownlist><BR>
					<asp:label id="lblYYYYMM" runat="server">�Z�n�~��G</asp:label>
					<asp:textbox id="tbxYYYYMM" runat="server" Width="60px" MaxLength="7"></asp:textbox>&nbsp;<FONT color="darkred" size="2">
						(�w�]�ȡG���A�p2002/08)</FONT><BR>
					<asp:label id="lblOrderByFilter" runat="server">�ƧǱ���G</asp:label>
					<asp:dropdownlist id="ddlOrderByFilter" runat="server">
						<asp:ListItem Value="1" Selected="True">�X���s��+�����Ǹ�</asp:ListItem>
						<asp:ListItem Value="2">�~�ȭ�</asp:ListItem>
					</asp:dropdownlist><BR>
					<asp:Label id="lblIabSeq" runat="server">���o���}�߳�帹�G</asp:Label>
					<asp:TextBox id="tbxIabseq" runat="server" Width="60px" MaxLength="6">000001</asp:TextBox>&nbsp;
					<FONT color="darkred" size="2">(�п�J���T�ȡA�p 000001)</FONT>&nbsp;&nbsp;
					<asp:button id="btnQuery" runat="server" Text="�d��"></asp:button>&nbsp;
					<asp:button id="btnClear" runat="server" Text="�M�����d"></asp:button><BR>
					<asp:label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label>
					<asp:TextBox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:TextBox>
					<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxYYYYMM" ErrorMessage="'�Z�n�~��' �Ш̮榡��J(�аѮ����r����)!!!"></asp:RegularExpressionValidator><br>
					<asp:Label id="lblMemo" runat="server" ForeColor="Red" Font-Size="X-Small">���G�w��|�p�t�Τ��B�z�����, �L�k�A���˵��ΦC�L!</asp:Label>
			</asp:panel><br>
			<asp:label id="lblMessage2" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><asp:button id="btnReQuery" runat="server" Text="���s�d��"></asp:button>&nbsp;&nbsp;<asp:button id="btnPrintList" runat="server" Text="�C�L�ˮ֪�"></asp:button><br>
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
			</asp:datagrid><asp:literal id="Literal1" runat="server"></asp:literal><asp:textbox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:textbox><asp:textbox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:textbox></form>
		<br>
		<!-- ���� Footer -->
		<center><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
