<%@ Page language="c#" Codebehind="UnpaidListFilter.aspx.cs" src="UnpaidListFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.UnpaidListFilter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="UnpaidListFilter" method="post" runat="server">
			<FONT color="#333333" size="2">&nbsp; <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				催款處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">催款單查詢
			</FONT>
			<br>
			<asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="Blue">請選擇條件</asp:label>
			<HR width="100%" SIZE="1">
			<asp:checkbox id="cbx1" runat="server" Text="計劃代號："></asp:checkbox><asp:textbox id="tbxProj" runat="server" Width="118px"></asp:textbox><asp:label id="lblProjMessage" runat="server" ForeColor="Red"></asp:label><br>
			<asp:checkbox id="cbx2" runat="server" Text="發票日期："></asp:checkbox><asp:textbox id="tbxDate1" runat="server" Width="82px" ReadOnly="True"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxDate1.name)" src="../images/calendar01.gif">
			～<asp:textbox id="tbxDate2" runat="server" Width="84px" ReadOnly="True"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxDate2.name)" src="../images/calendar01.gif">
			<asp:label id="lblDateMessage" runat="server" ForeColor="Red"></asp:label><br>
			<asp:checkbox id="cbx3" runat="server" Text="廠商統一編號："></asp:checkbox><asp:textbox id="tbxMfrno" runat="server" Width="122px"></asp:textbox><br>
			<asp:checkbox id="cbx4" runat="server" Text="廠商名稱："></asp:checkbox><asp:textbox id="tbxMfrname" runat="server"></asp:textbox><br>
			<asp:checkbox id="cbx5" runat="server" Text="發票號碼："></asp:checkbox><asp:textbox id="tbxInvno" runat="server" Width="120px"></asp:textbox><br>
			<asp:checkbox id="cbx6" runat="server" Text="發票開立單編號："></asp:checkbox><asp:textbox id="tbxIano" runat="server" Width="106px"></asp:textbox><br>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button><asp:button id="btnPrintList" runat="server" Text="列印報表" Enabled="False"></asp:button><asp:literal id="Literal1" runat="server"></asp:literal><asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label><br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<Columns>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱" HeaderStyle-Wrap="False"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="統一編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invdate" HeaderText="發票日"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invno" HeaderText="發票號碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_desc" HeaderText="品名"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_pyat" HeaderText="發票金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="繳款金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_amt" HeaderText="明細金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkno" HeaderText="票據號碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pyno" HeaderText="繳款單號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="繳款日"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_syscd" HeaderText="系統代號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_iano" HeaderText="發票開立單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_iasdate" HeaderText="轉檔年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_iasseq" HeaderText="批次"></asp:BoundColumn>
					<asp:BoundColumn DataField="ias_createdate" HeaderText="產生清單日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="ias_createmen" HeaderText="產生清單員工"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_fgitri" HeaderText="往來種類"></asp:BoundColumn>
					<asp:BoundColumn DataField="ias_trans_sap" HeaderText="已轉SAP"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_fgnonauto" HeaderText="人工產生註記"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_remark" HeaderText="備註"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk1" HeaderText="FK1"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk2" HeaderText="FK2"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk3" HeaderText="FK3"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk4" HeaderText="FK4"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
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
