<%@ Page language="c#" Codebehind="cust_detail.aspx.cs" Src="cust_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.cust_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<!-- ���� Header -->
		<!-- ���D -->
		<DIV align="left">
			<B><FONT color="darkblue" size="4">�Ȥᤧ�Ӹ`��T</FONT></B>&nbsp;
		</DIV>
		<br>
		<form id="cust_detail" method="post" runat="server">
			<!-- Table �}�l: �Ӹ`��T -->
			<TABLE class="TableColor" style="WIDTH: 90%" cellSpacing="0" cellPadding="4" border="1">
				<!-- Table Title -->
				<tr>
					<td colSpan="4" class="TableColorHeader">
						�t�Ӹ��(ID=
						<asp:label id="lblMfrID" runat="server"></asp:label>
						)
					</td>
				</tr>
				<TR>
					<TD class="TableColor" noWrap align="right">
						���q�W�١G
						<br>
						(�o�����Y)
					</TD>
					<TD bgColor="#ecebff" colSpan="3">
						<asp:label id="lblMfrIName" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						�Τ@�s���G
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblMfrNo" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						�t���p���q�ܡG
					</TD>
					<TD bgColor="#ecebff">
						<asp:Label id="lblMfrTel" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						�a�}�G
					</TD>
					<TD bgColor="#ecebff" colSpan="3">
						<asp:label id="lblMfrIZipcode" runat="server"></asp:label>
						&nbsp;
						<asp:label id="lblMfrIAddr" runat="server"></asp:label>
					</TD>
				</TR>
				<!-- �Ӹ`��T�}�l -->
				<tr>
					<td colSpan="4" class="TableColorHeader">
						�Ȥ���(ID=
						<asp:label id="lblCustID" runat="server"></asp:label>
						)
					</td>
				</tr>
				<TR>
					<TD class="TableColor" noWrap align="right">
						�m�W�νs���G
					</TD>
					<TD bgColor="#ecebff" nowrap>
						<asp:label id="lblCustName" runat="server" ForeColor="Red"></asp:label>
						&nbsp;(
						<asp:Label id="lblCustNo" runat="server" ForeColor="Red"></asp:Label>
						)
					</TD>
					<TD class="TableColor" noWrap align="right">
						¾�١G
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						���U����G
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustRegDate" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						�ק����G
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustModDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						�q�ܡG
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustTel" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						�ǯu�G
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustFax" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						����G
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustCell" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						Email�G
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustEmail" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						�Ȥ���G
					</TD>
					<TD bgColor="#ecebff" colspan="3">
						<asp:Label id="lblCustItpcd" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						�Ȥ���~�G
					</TD>
					<TD bgColor="#ecebff" colspan="3">
						<asp:Label id="lblCustBtpcd" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						�Ȥ�\Ū�G
					</TD>
					<TD bgColor="#ecebff" colspan="3">
						<asp:Label id="lblCustRtpcd" runat="server"></asp:Label>
					</TD>
				</TR>
			</TABLE>
			<br>
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="��������" name="btn_close">
		</form>
	</body>
</HTML>
