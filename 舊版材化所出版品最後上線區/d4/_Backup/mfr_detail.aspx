<%@ Page language="c#" Codebehind="mfr_detail.aspx.cs" Src="mfr_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.mfr_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
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
			<TABLE style="WIDTH: 80%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
				<!-- Table Title -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">�t�Ӹ��</font> <FONT color="#ffffff">(ID=
							<asp:label id="lblMfrID" runat="server"></asp:label>
							)</FONT>
					</td>
				</tr>
				<!-- �Ӹ`��T�}�l -->
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						���q�W�١G
						<br>
						(�o�����Y)
					</TD>
					<TD class="cssData" colSpan="3">
						<asp:label id="lblMfrIName" runat="server" ForeColor="Red"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�Τ@�s���G
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrNo" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						���U����G
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrRegDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�t�d�H�m�W�G
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrRespName" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						�t�d�H¾�١G
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						�q�ܡG
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrTel" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						�ǯu�G
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrFax" runat="server"></asp:label>
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
			</TABLE>
			<br>
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="��������" name="btn_close">
     </form>
	
  </body>
</HTML>
