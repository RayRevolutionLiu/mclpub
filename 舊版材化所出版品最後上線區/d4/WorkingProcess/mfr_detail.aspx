<%@ Page language="c#" Codebehind="mfr_detail.aspx.cs" Src="mfr_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.mfr_detail" %>
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
			<B><FONT color="darkblue" size="4">�t�Ӥ��Ӹ`��T</FONT></B>&nbsp;
		</DIV>
		<br>
		<form id="mfr_detail" method="post" runat="server">
			<!-- Table �}�l: �Ӹ`��T -->
			<TABLE style="WIDTH: 80%" cellSpacing="0" cellPadding="4" class="TableColor" border="1">
				<!-- Table Title -->
				<TBODY>
					<tr>
						<td class="TableColorHeader" colSpan="4">
							�t�Ӹ��(ID=
							<asp:label id="lblMfrID" runat="server"></asp:label>
							)
						</td>
					</tr>
					<!-- �Ӹ`��T�}�l -->
					<TR>
						<TD class="TableColor" noWrap align="right">
							���q�W�١G
							<br>
							(�o�����Y)
						</TD>
						<TD bgColor="#ecebff" colSpan="3">
							<asp:label id="lblMfrIName" runat="server" ForeColor="Red"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="TableColor" noWrap align="right">
							�Τ@�s���G
						</TD>
						<TD bgColor="#ecebff">
							<asp:label id="lblMfrNo" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD class="TableColor" noWrap align="right">
							���U����G
						</TD>
						<TD bgColor="#ecebff">
							<asp:label id="lblMfrRegDate" runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="TableColor" noWrap align="right">
							�t�d�H�m�W�G
						</TD>
						<TD bgColor="#ecebff">
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
						</TD>
						<TD class="TableColor" noWrap align="right">
							�t�d�H¾�١G
						</TD>
						<TD bgColor="#ecebff">
							<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="TableColor" noWrap align="right">
							�q�ܡG
						</TD>
						<TD bgColor="#ecebff">
							<asp:label id="lblMfrTel" runat="server"></asp:label>
						</TD>
						<TD class="TableColor" noWrap align="right">
							�ǯu�G
						</TD>
						<TD bgColor="#ecebff">
							<asp:label id="lblMfrFax" runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="TableColor" noWrap align="right">�a�}�G
						</TD>
						<TD bgColor="#ecebff" colSpan="3"><asp:label id="lblMfrIZipcode" runat="server"></asp:label>&nbsp;
							<asp:label id="lblMfrIAddr" runat="server"></asp:label></TD>
					</TR>
				</TBODY>
			</TABLE>
			<BR>
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="��������" name="btn_close">
		</form>
	</body>
</HTML>
