<%@ Page language="c#" Codebehind="bookp_get.aspx.cs" Src="bookp_get.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.bookp_get" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���y���O���ѦҸ��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// <IMG class="ico" title="���y���O�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O
		function doGetBookp(obj)
		{
			//alert("hiddenBookPNo.Value= " + document.all("hiddenBookPNo").value);
			
			// �Ǧ^�Ȩ���������
			oMyObject.result = document.all("hiddenBookPNo").value;
			oMyObject.yyyymm = document.all("hiddenYYYYMM").value;
			//alert("oMyObject.result= " + oMyObject.result);
			//alert("oMyObject.yyyymm= " + oMyObject.yyyymm);
			
			window.returnValue = true; 
			window.close();
		}
		//-->
		</script>
	</HEAD>
	<body>
		<!-- ���� Header -->
		<!-- Run at Server Form -->
		<form id="bookp_get" method="post" target="_self" runat="server">
			<!-- �ާ@���� --><font color="blue" size="2">�ާ@�����G�w�]��Ƭ� <font color="darkred">��J�Z�n�~�뤧��~��</font>.</font>
			<br>
			<FONT color="blue" size="2">�Ы��U "<FONT color="darkred"><U>��������</U></FONT>" ���s, 
				�ӽT�{�D��"!</FONT>
			<br>
			<!-- DataGrid �}�l --><asp:datagrid id="DataGrid1" runat="server" ItemStyle-HorizontalAlign="Center" AllowPaging="False" PageSize="12" BackColor="White" BorderColor="Black" BorderStyle="None" AutoGenerateColumns="False">
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
				<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
				<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
				<ItemStyle BackColor="#BFCFF0"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="bk_nm" HeaderText="���y�W��"></asp:BoundColumn>
					<asp:BoundColumn DataField="bkp_date" HeaderText="�Z�n�~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="bkp_pno" HeaderText="���y���O"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<!-- �Ƶ����� -->
			<font color="gray" size="2">��: ����r�鬰<font color="darkred">�t�Φ~��</font>�����.</font>
			<br>
			<font color="gray" size="2">��: �Ŧ�r�鬰<font color="darkred">�j�M���G</font>, �N�a�^.</font>
			<br>
			<br>
			<!-- �����������s -->
			<INPUT id="btn_close" onclick="Javascript: doGetBookp();" type="button" value="��������" name="btn_close" Height="18px">
			&nbsp;
			<asp:label id="lblMessage" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<asp:label id="lblYYYYMM" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<asp:label id="lblGetBookPNo" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<INPUT id="hiddenBookPNo" type="hidden" size="3" name="hiddenBookPNo" runat="server">
			<INPUT id="hiddenYYYYMM" type="hidden" size="6" name="hiddenYYYYMM" runat="server">
			<br>
		</form>
		<!-- ���� Footer -->
		<!-- Javascript -->
		<SCRIPT language="javascript">
		<!--
		// �۫e�@��, �� MyObject
		var oMyObject = window.dialogArguments;
		
		// �۫e�@��, ��X��������
		//alert("oMyObject.bkcd= " + oMyObject.bkcd);
		//alert("oMyObject.ym= " + oMyObject.ym);
		
		-->
		</SCRIPT>
	</body>
</HTML>
