<%@ Page language="c#" Codebehind="adlprior_get.aspx.cs" Src="adlprior_get.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior_get" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��� �����u������ ���</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- Run at Server Form -->
		<form id="adlprior_get" method="post" runat="server">
			<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<!-- DataGrid: �۸�Ʈw��̷s��� -->
				<TR>
					<TD width="5%">
						&nbsp;
					</TD>
					<TD>
						<!-- �ާ@���� -->
						<font color="blue" size="2">�ާ@�����G�w�]�a�J
							<asp:Label id="lblBookName" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
							<FONT color="#8b0000">&nbsp;</FONT>�����.</font>
						<br>
						<font color="blue" size="2">�Ы��U "<FONT color="darkred"><U>��������</U></FONT>" ���s, 
							������������!</font>
						<br>
					</TD>
				</TR>
				<TR>
					<TD width="5%">
						&nbsp;
					</TD>
					<TD vAlign="top" width="*">
						<asp:datagrid id="DataGrid1" runat="server" BorderColor="Black" AutoGenerateColumns="False">
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
							<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
							<ItemStyle BackColor="#BFCFF0"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="lp_priorseq" HeaderText="�ƪ��u������">
									<ItemStyle HorizontalAlign="Center">
									</ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ltp_nm" HeaderText="�s�i����"></asp:BoundColumn>
								<asp:BoundColumn DataField="clr_nm" HeaderText="�s�i��m"></asp:BoundColumn>
								<asp:BoundColumn DataField="pgs_nm" HeaderText="�s�i�g�T"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_bkcd" HeaderText="���y�N�X"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_ltpcd" HeaderText="�s�i�����N�X"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_clrcd" HeaderText="�s�i��m�N�X"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_pgscd" HeaderText="�s�i�g�T�N�X"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
						<!-- ��Ƶ��� -->
						<FONT color="#333333">
							<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
							(�@��
							<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
							����� )</FONT>
					</TD>
				</TR>
				<!-- �����������s -->
				<TR>
					<TD>
						&nbsp;
					</TD>
					<TD>
						<br>
						<INPUT id="btn_close" onclick="Javascript: window.close();" type="button" value="��������" name="btn_close" Height="18px">
						&nbsp;
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
