<%@ Page language="c#" Codebehind="pubpgno_get.aspx.cs" Src="pubpgno_get.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.pubpgno_get" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�Z�n���X���ѦҸ��</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// <IMG class="ico" title="�Z�n���X�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O
		function doGetPgNo(obj)
		{
			//alert("hiddenPageNo.Value= " + document.all("hiddenPageNo").value);
			
			// �Ǧ^�Ȩ���������
			oMyObject.bkpno = document.all("hiddenBookPNo").value;
			oMyObject.pgno = document.all("hiddenPageNo").value;
			//alert("oMyObject.bkpno= " + oMyObject.bkpno);
			//alert("oMyObject.pgno= " + oMyObject.pgno);
			
			window.returnValue = true; 
			window.close();
		}
		//-->
		</script>
	</HEAD>
	<body>
		<!-- ���� Header -->
		<!-- Run at Server Form -->
		<form id="pubpgno_get" method="post" runat="server">
			<!-- �ާ@���� -->
			<font color="blue" size="2">�ާ@�����G�w�]��Ƭ� <FONT color="#8b0000">�Ӽt�� �Ĥ@�����w����(�g�^)�����</FONT>.</font>
			<br>
			<FONT color="blue" size="2">���U "<FONT color="darkred"><U>��������</U></FONT> " �N�a�^�w�]�� 
				(�p�ݨ�L��, �Цۦ�O�U�ק�)!</FONT>
			<br>
			<!-- DataGrid �}�l -->
			<asp:datagrid id="DataGrid1" runat="server" ItemStyle-HorizontalAlign="Center" PageSize="12" BackColor="White" BorderColor="Black" BorderStyle="None" AutoGenerateColumns="False">
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
				<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
				<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Center" BackColor="#BFCFF0"></ItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="pub_syscd" ReadOnly="True" HeaderText="�t�ΥN�X"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_contno" HeaderText="����X���ѽs��"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="�Z�n�~��"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="�����Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pno" HeaderText="������y���O"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="����Z�n���X"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<!-- �Ƶ����� -->
			<font color="gray" size="2">��: ����r�鬰<font color="darkred">�N�a�^</font>���w�]�ȸ��.</font>
			<br>
			<br>
			<!-- �����������s -->
			<INPUT id="btn_close" onclick="Javascript: doGetPgNo();" type="button" value="��������" name="btn_close" Height="18px">
			&nbsp;
			<asp:label id="lblMessage" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<asp:label id="lblMfrNo" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<br>
			<asp:label id="lblGetPageNo" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label>
			<INPUT id="hiddenMfrNo" type="hidden" size="7" name="hiddenOldContNo" runat="server">
			<INPUT id="hiddenBookPNo" type="hidden" size="6" name="hiddenBookPNo" runat="server">
			<INPUT id="hiddenPageNo" type="hidden" size="4" name="hiddenPageNo" runat="server">
		</form>
		<!-- Javascript -->
		<SCRIPT language="javascript">
		<!--
		// �۫e�@��, �� MyObject
		var oMyObject = window.dialogArguments;
		
		// �۫e�@��, ��X��������
		//alert("oMyObject.mfrno= " + oMyObject.mfrno);	
		//alert("oMyObject.bkpno= " + oMyObject.bkpno);	
		-->
		</SCRIPT>
	</body>
</HTML>
