<%@ Page language="c#" Codebehind="InvMfr_GetSingle.aspx.cs" Src="InvMfr_GetSingle.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.InvMfr_GetSingle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��ܩҦ� �o���t�Ӧ���H ���</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- JavaScript -->
		<script language="JavaScript">
		function WindowClose() 
		{ 
			// �Ǧ^�Ȩ���������
			//oMyObject.IMSeq = document.all("tbxIMseq").value;
			//oMyObject.IMName = document.all("tbxIMName").value;
			//alert("oMyObject.IMSeq= " + oMyObject.IMSeq);
			//alert("oMyObject.IMName= " + oMyObject.IMName);
			
			//window.returnValue = true; 
			window.close();
		}
		
		function NewWindow() 
		{ 
			// �Ǧ^�Ȩ���������
			var contno = document.all("hiddenContNo").value;
			var custno = document.all("hiddenCustNo").value;
			var old_contno = document.all("hiddenOldContNo").value;
			var fgnew = document.all("hiddenfgnew").value;
			var winName = "InvMfrForm.aspx?contno=" + contno + "&custno=" + custno + "&old_contno=" + old_contno + "&fgnew=" + fgnew + "&fmnm=ContFm_modify";
			
			var winfeatures = "'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no'";
			window.open(winName, '_new', winfeatures);
		}
		</script>
	</HEAD>
	<body>
		<form id="InvMfr_GetSingle" method="post" runat="server">
			<!-- �w�s�W �o���t�Ӧ���H��� �� -->
			<FONT color="#ff0066" size="2">[�w�s�W �o���t�Ӧ���H��� ��]&nbsp;&nbsp;
				<asp:label id="lblCountMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label>
			</FONT>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
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
			<!-- �ק��Ƥ��s�� -->
			<FONT color="#c00000" size="2">���@�G�p�G�z�n�W�׸��, �Ы�</FONT> <INPUT id="btnGoLink" style="COLOR: blue; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: white; TEXT-DECORATION: underline; BORDER-BOTTOM-STYLE: none" onclick="Javascript:NewWindow();" type="button" value="���B" name="btnGoLink">.&nbsp;
			<br>
			<FONT color="#c00000" size="2">���G�G�p�G�z�ק�F����H�m�W, �ηs�W/�R���F����H���, �^�츨���e����, �Ы��U����H�Ǫ� '<U>���s��z<img src="../images/refresh.gif" border="0"></U>' 
				�ӧ���̷s���.</FONT>
			<br>
			<INPUT id="hiddenContNo" type="hidden" name="hiddenContNo" runat="server" style="WIDTH: 50px">
			<INPUT id="hiddenCustNo" style="WIDTH: 50px" type="hidden" name="hiddenCustNo" runat="server">
			<INPUT id="hiddenOldContNo" style="WIDTH: 50px" type="hidden" name="hiddenOldContNo" runat="server">
			<INPUT id="hiddenfgnew" style="WIDTH: 30px" type="hidden" name="hiddenfgnew" runat="server">
			<br>
			<INPUT id="btnClose" onclick="Javascript:WindowClose();" type="button" value="��������" name="btnClose">
			<br>
			<!-- �ާ@���� --><FONT color="blue" size="2">���U "<FONT color="darkred"><U>��������</U></FONT>" 
				���s, �ӵ���!</FONT>
			<br>
		</form>
		<!-- Javascript -->
		<SCRIPT language="javascript">
		<!--
		// �۫e�@��, �� MyObject
		//var oMyObject = window.dialogArguments;
		
		// �۫e�@��, ��X��������
		//alert("oMyObject.syscd= " + oMyObject.syscd);
		//alert("oMyObject.contno= " + oMyObject.contno);
		-->
		</SCRIPT>
	</body>
</HTML>
