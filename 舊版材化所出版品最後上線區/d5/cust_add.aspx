<%@ Page language="c#" Src="cust_add.aspx.cs" Codebehind="cust_add.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.cust_add" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�Ȥ��ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="cust_add" method="post" runat="server">
			<FONT face="�s�ө���">
				<P align="center">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%">
								<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;�@�P�ɮ�
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �Ȥ��ƺ��@
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> �t�Ӭd�� </FONT>
							</TD>
						</TR>
					</TABLE>
				</P>
				<P align="left">
					<TABLE cellSpacing="1" cellPadding="3" width="350" bgColor="#bfcff0" border="0">
						<TR>
							<TD bgColor="#214389" colSpan="2">
								<P align="left">
									<FONT color="#ffffff">�t�Ӭd�� </FONT>
								</P>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 87px">
								<P align="right">
									�t�ӵo�����Y:
								</P>
							</TD>
							<TD>
								<asp:textbox id="tbxInm" runat="server"></asp:textbox>
								&nbsp;&nbsp;<A href="mfr_addnew.aspx" target="">�s�W�t�Ӹ��</A>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 87px">
								<P align="right">
									�t�ӲΤ@�s��:
								</P>
							</TD>
							<TD>
								<asp:textbox id="tbxMfrno" runat="server"></asp:textbox>
							</TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<P align="right">
									<asp:button id="btnQuery" runat="server" Text="�j�M"></asp:button>
									<asp:button id="btnClean" runat="server" Text="�M��"></asp:button>
								</P>
							</TD>
						</TR>
					</TABLE>
				</P>
				<P align="left">
					<asp:label id="Label1" runat="server" ForeColor="#404040" Font-Size="X-Small"></asp:label>
			</FONT>
			<asp:label id="lblResult" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:label>
			<FONT size="2">
				<asp:label id="Label2" runat="server" ForeColor="#404040"></asp:label>
			</FONT></P>
			<P>
			</P>
			</FONT><asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
				<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��"></PagerStyle>
				<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
				<ItemStyle BackColor="#BFCFF0"></ItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="mfr_mfrid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�ӲΤ@�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="�o�����Y"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_iaddr" HeaderText="�o���a�}"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="mfr_izip" HeaderText="�t�Ӷl���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="mfr_respnm" HeaderText="�t�d�H�m�W"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="mfr_respjbti" HeaderText="���q�t�d�H¾��"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_tel" HeaderText="���q�p���q��"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="mfr_fax" HeaderText="���q�ǯu���X"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="mfr_regdate" HeaderText="���U���"></asp:BoundColumn>
					<asp:ButtonColumn Text="���" ButtonType="PushButton" HeaderText="���" CommandName="Select"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
		</form>
	</body>
</HTML>
