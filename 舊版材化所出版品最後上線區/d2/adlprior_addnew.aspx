<%@ Page debug="true" language="c#" Codebehind="adlprior_addnew.aspx.cs" Src="adlprior_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�����u������ - �s�W</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// <IMG class="ico" title="���y���O�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O
		function doGetLPrior(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// ���w�ǹL�h���ܼ� - ��X ���y���O�N�X & �Z�n�~��, �ӧ�X ���y���O
			var bkcd = document.all("ddlBookCode").value;
			myObject.bkcd = document.all("ddlBookCode").value;
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ myObject
			var PageName = "adlprior_get.aspx?bkcd=" + bkcd;
			vreturn=window.open(PageName,  '_new', 'Height=320, Width=280, Top=120, Left=490, toolbar=no, scrollbars=yes, status=no, resizable=no'); 
		}
		//-->
		</script>
	</HEAD>
	<body>
		<center>
			<!-- ���� Header -->
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle" bgColor="#e7ebff">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�������@�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����u������ - �s�W</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adlprior_addnew" method="post" runat="server"> <!-- �ק� Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="90%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">�s�W�����u������</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="26%">
							&nbsp;<FONT color="#ff0000">* </FONT>���y�W��:
						</TD>
						<TD width="50%">
							<asp:dropdownlist id="ddlBookCode" runat="server" AutoPostBack="True"></asp:dropdownlist>
							<br>
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD width="*" align="right">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">���������</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�����J���ƪ��u�����ǭ�: <IMG class="ico" id="imgLPrior" title="��ܪ����u�����Ǹ��" onclick="doGetLPrior(this)" src="../images/edit.gif" border="0">
						</TD>
						<TD colspan="2">
							<asp:textbox id="tbxPriorSeq" runat="server" MaxLength="2" Width="30px"></asp:textbox>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;
						</TD>
						<TD colspan="2">
							<FONT color="#8b4513">���@�G�п�J�n���N�����ǥN�X! �����s�W���\��, �N�|���N�ª������ǥN�X, ���ª����ǥN�X�N�۰ʩ��ᶶ��!
								<br>
								���G�G�p�G�z�n�Ѧҭ쥻��Ʈw���� '�ƪ��u������', �Ы��U���� <IMG class="ico" id="imgLPrior" title="��ܪ����u�����Ǹ��" onclick="doGetLPrior(this)" src="../images/edit.gif" border="0">�ϥܨӰѦ�!
								<br>
								�p��J 07, ��ܦ����s�W��ƱN���s����07, �ӭ쥻�¦��ǭ�(07~)�N�۰ʩ��ᶶ�� (�ܬ� 08~) </FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�s�i����:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlLayoutTypeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�s�i��m:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlColorCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>�s�i�g�T:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddPageSizeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD colspan="3" align="right">
							<asp:button id="btnUpdate" runat="server" Text="�T�w�s�W" Height="24px"></asp:button>
							&nbsp;
							<asp:button id="btnReturnHome" runat="server" Text="���s�W" Height="24px" CausesValidation="False"></asp:button>
							&nbsp; <INPUT id="btnCloseWin" name="btnCloseWin" type="button" value="��������" onclick="Javascript: window.close()">&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
		</center>
	</body>
</HTML>
