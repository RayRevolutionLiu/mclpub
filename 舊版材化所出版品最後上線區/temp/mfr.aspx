<%@ Page language="c#" Src="mfr.aspx.cs" Codebehind="mfr.aspx.cs" AutoEventWireup="false" Inherits="d5.mfr" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�t�Ӹ�ƺ��@</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��")
					event.returnValue=confirm("�O�_�T�w�R��?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<form id="mfr" method="post" runat="server"> <!-- ���� Header --><kw:header id="Header" runat="server">
			</kw:header>
			<table id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
				<tr>
					<td align="left" width="100%">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							&nbsp;�@�P�ɮ� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�t�Ӹ�ƺ��@ </font>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 67px" height="36">
						<P align="right">
							<FONT style="FONT-SIZE: 9pt" face="�s�ө���">�o�����Y�G</FONT>
						</P>
					</TD>
					<TD height="36">
						<P align="left">
							<asp:textbox id="QString" runat="server" Width="96px" Height="21px"></asp:textbox>
							<FONT face="�s�ө���"></FONT>
							<asp:button id="Query" runat="server" Width="50px" Height="22px" Text="�j�M" Font-Size="9pt"></asp:button>
						</P>
					</TD>
				</TR>
			</table>
			<asp:datagrid id="DataGrid1" runat="server" PageSize="5" AllowPaging="True" BackColor="White" CellPadding="2" BorderWidth="1px" BorderColor="Black" AutoGenerateColumns="False">
				<HeaderStyle Font-Size="8pt" ForeColor="White" BackColor="#214389"></HeaderStyle>
				<PagerStyle Mode="NumericPages"></PagerStyle>
				<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
				<ItemStyle BackColor="#BFCFF0"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="mfr_mfrid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�ӲΤ@�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="�o�����Y(���q�W��)"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_iaddr" HeaderText="�t��(�o���l�H)�a�}"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_izip" HeaderText="�t�Ӷl���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_respnm" HeaderText="���q�t�d�H�m�W"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_respjbti" HeaderText="���q�t�d�H¾��"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_tel" HeaderText="���q�p���q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_fax" HeaderText="���q�ǯu���X"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_regdate" HeaderText="���U���"></asp:BoundColumn>
					<asp:EditCommandColumn ButtonType="PushButton" UpdateText="��s" HeaderText="�ק�" CancelText="����" EditText="�ק�">
						<HeaderStyle BackColor="ControlDarkDark">
						</HeaderStyle>
					</asp:EditCommandColumn>
					<asp:ButtonColumn Text="�R��" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete">
						<HeaderStyle BackColor="ControlDarkDark">
						</HeaderStyle>
					</asp:ButtonColumn>
					<asp:ButtonColumn Text="Select" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
			<FONT face="�s�ө���">
				<TABLE cellSpacing="0" cellPadding="2" width="100%" bgColor="#21418c" border="0">
					<TR>
						<TD>
							<FONT color="#ffffff">�s�W�t�Ӹ��</FONT>
						</TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="0" cellPadding="2" width="100%" bgColor="#bdcff7" border="0">
					<TR>
						<TD width="13%">
							<P align="right">
								<FONT style="FONT-SIZE: 9pt">�t�ӲΤ@�s��: </FONT>
							</P>
						</TD>
						<TD width="12%">
							<FONT style="FONT-SIZE: 9pt">
								<asp:textbox id="mfr_mfrno" runat="server" Width="85px" Height="22px"></asp:textbox>
							</FONT>
						</TD>
						<TD width="17%">
							<P align="right">
								<FONT style="FONT-SIZE: 9pt">�o�����Y(���q�W��): </FONT>
							</P>
						</TD>
						<TD width="13%">
							<FONT style="FONT-SIZE: 9pt">
								<asp:textbox id="mfr_inm" runat="server" Width="85px" Height="22px"></asp:textbox>
							</FONT>
						</TD>
						<TD width="17%">
							<P align="right">
								<FONT style="FONT-SIZE: 9pt">�t��(�o���l�H)�a�}: </FONT>
							</P>
						</TD>
						<TD width="28%">
							<FONT style="FONT-SIZE: 9pt">
								<asp:textbox id="mfr_iaddr" runat="server" Width="200px" Height="22px"></asp:textbox>
							</FONT>
						</TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="0" cellPadding="2" width="100%" bgColor="#bdcff7" border="0">
					<TR>
						<TD width="13%">
							<P align="right">
								<FONT style="FONT-SIZE: 9pt">�t�Ӷl���ϸ�: </FONT>
							</P>
						</TD>
						<TD width="12%">
							<FONT style="FONT-SIZE: 9pt">
								<asp:textbox id="mfr_izip" runat="server" Width="40px" Height="22px"></asp:textbox>
							</FONT>
						</TD>
						<TD width="17%">
							<P align="right">
								���q�t�d�H�m�W:
							</P>
						</TD>
						<TD width="11%">
							<FONT style="FONT-SIZE: 9pt">
								<asp:textbox id="mfr_respnm" runat="server" Width="68px" Height="22px"></asp:textbox>
							</FONT>
						</TD>
						<TD width="14%">
							<P align="right">
								���q�t�d�H¾��:
							</P>
						</TD>
						<TD width="9%">
							<FONT style="FONT-SIZE: 9pt">
								<asp:textbox id="mfr_respjbti" runat="server" Width="56px" Height="22px"></asp:textbox>
							</FONT>
						</TD>
						<TD width="13%">
							<P align="right">
								���q�p���q��:
							</P>
						</TD>
						<TD width="11%">
							<asp:textbox id="mfr_tel" runat="server" Width="68px" Height="22px"></asp:textbox>
						</TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="0" cellPadding="2" width="100%" bgColor="#bdcff7" border="0">
					<TR>
						<TD width="13%">
							<P align="right">
								���q�ǯu���X:
							</P>
						</TD>
						<TD width="12%">
							<asp:textbox id="mfr_fax" runat="server" Width="68px" Height="22px"></asp:textbox>
						</TD>
						<TD width="17%">
							<P align="right">
								<FONT style="FONT-SIZE: 9pt">���U���:</FONT>
							</P>
						</TD>
						<TD width="13%">
							<asp:textbox id="mfr_regdate" runat="server" Width="68px" Height="22px"></asp:textbox>
						</TD>
						<TD width="45%">
							<P align="right">
								<asp:button id="Button1" runat="server" Text="�T�w�s�W" Height="22px"></asp:button>
							</P>
						</TD>
					</TR>
				</TABLE>
			</FONT>
			<!-- ���� Footer --><FONT face="�s�ө���"></FONT>
			<P>
				<kw:footer id="Footer" runat="server">
				</kw:footer>
			</P>
		</form>
	</body>
</HTML>
