<%@ Page language="c#" Codebehind="LostListFilter.aspx.cs" src="LostListFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.LostListFilter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="LostListFilter" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				�ʮѳB�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">�ʮѲM��C�L
			</FONT>
			<br>
			<asp:Label id="Label2" runat="server">�H�Ѫ��p�G</asp:Label>
			<asp:DropDownList id="ddlSent" runat="server" AutoPostBack="True">
				<asp:ListItem Value="C">�w�H�X</asp:ListItem>
				<asp:ListItem Value="N">�|���H�X</asp:ListItem>
				<asp:ListItem Value="ALL">����</asp:ListItem>
			</asp:DropDownList>
			<br>
			<asp:checkbox id="cbx1" runat="server" Text="�ʮѤ���϶��G"></asp:checkbox>
			<asp:textbox id="tbxLostDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxLostDate1.name)" src="../images/calendar01.gif">
			��<asp:textbox id="tbxLostDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="���" onclick="pick_date(tbxLostDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:checkbox id="cbx2" runat="server" Text="�q�ʤ���϶��G"></asp:checkbox>
			<asp:textbox id="tbxOrderDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxOrderDate1.name)" src="../images/calendar01.gif">
			��<asp:textbox id="tbxOrderDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="���" onclick="pick_date(tbxOrderDate2.name)" src="../images/calendar01.gif">
			<br>
			<asp:Button id="btnPrintList" runat="server" Text="�C�L����"></asp:Button>
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
