<%@ Page language="c#" Codebehind="CardListFilter.aspx.cs" src="CardListFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CardListFilter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body ms_positioning="GridLayout">
		<form id="CardListFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				ú�ڳB�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">�C�L�H�Υd���߽дڷJ�`��
			</FONT>
			<br>
			<br>
			<asp:label id="Label1" runat="server">ú�ڲM�沣�ͤ���G</asp:label>
			<asp:textbox id="tbxOrderDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxOrderDate1.name)" src="../images/calendar01.gif">
			��<asp:textbox id="tbxOrderDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="���" onclick="pick_date(tbxOrderDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:label id="Label2" runat="server">�J�`��C�L���p�G</asp:label>
			<asp:dropdownlist id="ddlPrintFlag" runat="server">
				<asp:ListItem Value="0" Selected="True">�|���C�L</asp:ListItem>
				<asp:ListItem Value="1">�w�C�L�L</asp:ListItem>
			</asp:dropdownlist>
			<br>
			<asp:button id="btnSearch" runat="server" Text="�d��"></asp:button>
			<asp:button id="btnPrint" runat="server" Text="�C�L�J�`��" Enabled="False"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C04000"></asp:label>
			<br>
			<asp:datalist id="DataList1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" CellPadding="1" GridLines="Horizontal" BorderWidth="0px" Visible="False">
				<HeaderTemplate>
					<TABLE>
						<TR>
							<TD width="30">
								<FONT color="white">���</FONT>
							</TD>
							<TD width="50">
								<FONT color="white">ú�ڲM�沣�ͦ~��</FONT>
							</TD>
							<TD width="40">
								<FONT color="white">ú�ڲM��妸</FONT>
							</TD>
							<TD width="50">
								<FONT color="white">ú�ڲM�沣�ͤ��</FONT>
							</TD>
							<TD width="50">
								<FONT color="white">ú�ڲM�沣�ͤH��</FONT>
							</TD>
							<TD>
								<FONT color="white"></FONT>
							</TD>
						</TR>
					</TABLE>
				</HeaderTemplate>
				<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
				<ItemStyle BorderWidth="1px" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
				<ItemTemplate>
					<TABLE>
						<TR>
							<TD>
								<asp:CheckBox id="cbx1" Width="30" Runat="server"></asp:CheckBox>
							</TD>
							<TD>
								<asp:Label id="lblpysdate" Width="50" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "pys_pysdate")%>'></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblpysseq" Width="40" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "pys_pysseq")%>'></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblcreatedate" Width="50" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "pys_createdate")%>'></asp:Label>
							</TD>
							<TD>
								<asp:Label id="lblcreatemen" Width="50" Runat="server" text='<%# DataBinder.Eval(Container.DataItem, "pys_createmen")%>'></asp:Label>
							</TD>
							<TD>
								<asp:Button id="btnDetail" runat="server" Text="����" CommandName="detail"></asp:Button>
							</TD>
						</TR>
					</TABLE>
				</ItemTemplate>
				<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
			</asp:datalist>
			<asp:DataGrid id="DataGrid1" runat="server" BorderWidth="1px" CellPadding="2" BorderStyle="None" BorderColor="#3366CC" BackColor="White" AutoGenerateColumns="False" style="Z-INDEX: 101; LEFT: 303px; POSITION: absolute; TOP: 125px">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn HeaderStyle-Width="40" DataField="py_pysdate" HeaderText="���ͦ~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysseq" HeaderText="�妸"></asp:BoundColumn>
					<asp:BoundColumn HeaderStyle-Width="20" DataField="py_pysitem" HeaderText="����"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pyno" HeaderText="ú�ڽs��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="ú�ڤ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccno" HeaderText="�H�Υd�d��"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccauthcd" HeaderText="���v�X"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccvdate" HeaderText="���Ħ~��"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
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
	</script>
	</body>
</HTML>
