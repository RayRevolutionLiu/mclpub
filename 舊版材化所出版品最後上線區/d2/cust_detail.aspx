<%@ Page language="c#" Codebehind="cust_detail.aspx.cs" Src="cust_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cust_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�Ȥᤧ�Ӹ`��T</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- ���� Header -->
		<!-- ���D -->
		<DIV align="left">
			<B><FONT color="darkblue" size="4">�Ȥᤧ�Ӹ`��T</FONT></B>&nbsp;
		</DIV>
		<br>
		<!-- Run at Server Form -->
		<form id="cust_detail" method="post" runat="server">
			<!-- Table �}�l: �Ӹ`��T -->
			<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
				<!-- Table Title -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">�t�Ӹ��</font> <FONT color="#ffffff">(ID=
							<asp:label id="lblMfrID" runat="server"></asp:label>
							)</FONT>
					</td>
				</tr>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						���q�W�١G
						<br>
						(�o�����Y)
					</TD>
					<TD class="cssData" colSpan="3">
						<asp:label id="lblMfrIName" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�Τ@�s���G
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrNo" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						�t���p���q�ܡG
					</TD>
					<TD class="cssData">
						<asp:Label id="lblMfrTel" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�a�}�G
					</TD>
					<TD class="cssData" colSpan="3">
						<asp:label id="lblMfrIZipcode" runat="server"></asp:label>
						&nbsp;
						<asp:label id="lblMfrIAddr" runat="server"></asp:label>
					</TD>
				</TR>
				<!-- �Ӹ`��T�}�l -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">�Ȥ���</font> <FONT color="#ffffff">(ID�G
							<asp:label id="lblCustID" runat="server" Font-Size="X-Small"></asp:label>
							���«Ȥ�s���G
							<asp:Label id="lblOldCustNo" runat="server" Font-Size="X-Small"></asp:Label>
							)</FONT>
					</td>
				</tr>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�m�W�νs���G
					</TD>
					<TD class="cssData" nowrap>
						<asp:label id="lblCustName" runat="server" ForeColor="Red"></asp:label>
						&nbsp;(
						<asp:Label id="lblCustNo" runat="server" ForeColor="Red"></asp:Label>
						)
					</TD>
					<TD class="cssTitle" noWrap align="right">
						¾�١G
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						���U����G
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustRegDate" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						�ק����G
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustModDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�q�ܡG
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustTel" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						�ǯu�G
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustFax" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						����G
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustCell" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						Email�G
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustEmail" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�Ȥ���G
					</TD>
					<TD class="cssData" colspan="3">
						<asp:Label id="lblCustItpcd" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�Ȥ���~�G
					</TD>
					<TD class="cssData" colspan="3">
						<asp:Label id="lblCustBtpcd" runat="server"></asp:Label>
					</TD>
				</TR>
			</TABLE>
			<br>
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="��������" name="btn_close">
		</form>
		<!-- ���� Footer -->
	</body>
</HTML>
