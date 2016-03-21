<%@ Page language="c#" Codebehind="IABRecovery.aspx.cs" Src="IABRecovery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IABRecovery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <!-- CSS -->
    <LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
  <body>
	<!-- ���� Header -->
	<kw:header id=Header runat="server">
	</kw:header>	
    <form id="IABRecovery" method="post" runat="server">
<p>
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						�o���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						�o���}�߳�^�_(Recovery) - �j��뵲</font>
				</td>
			</tr>
		</table><FONT face=�s�ө���><BR>
<asp:Panel id=pnlQuery runat="server" Width="100%"></asp:Panel>
</p>
<P>�п�J�d�߱���<BR>�o���}�߳� �}�ߦ~��G
<asp:TextBox id=tbxIaMonth runat="server" Width="80px" MaxLength="7"></asp:TextBox>
<asp:RequiredFieldValidator id=rfvIaMonth runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="�п�J�~��" Font-Size="X-Small"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revIaMonth runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="�榡���~�A����yyyy/MM" Font-Size="X-Small" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator><BR>�o���}�߳� 
�}�ߧ帹�G
<asp:TextBox id=tbxIabNo runat="server" Width="80px" MaxLength="6"></asp:TextBox>
<asp:RequiredFieldValidator id=rfvIabNo runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="�п�J�}�ߧ帹" Font-Size="X-Small"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revIabNo runat="server" ControlToValidate="tbxIaMonth" Display="Dynamic" ErrorMessage="�榡�Ҧp�G000001" Font-Size="X-Small" ValidationExpression="\d{6}"></asp:RegularExpressionValidator><BR>
<asp:Button id=btnQuery runat="server" Text="�d��"></asp:Button>
<asp:Button id=btnClear runat="server" Text="�M�����d"></asp:Button></P></FONT>
     </form>
	<!-- ���� Footer -->
<asp:Panel id=pnlIaList runat="server" Width="100%"><FONT face=�s�ө���>
<asp:Label id=lblInfo runat="server"></asp:Label>
<asp:DataGrid id=dgdIa runat="server" Font-Size="X-Small" BackColor="#E7EBFF" AutoGenerateColumns="False">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_empno" HeaderText="�~�ȭ�"></asp:BoundColumn>
<asp:BoundColumn DataField="im_nm" HeaderText="�o������H"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="�o���t��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="�s�i�Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_sdate" HeaderText="�s�i�}�l���"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_edate" HeaderText="�s�i�������"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="�s�i��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="���v"></asp:BoundColumn>
<asp:BoundColumn DataField="suminvamt" HeaderText="���o�����B"></asp:BoundColumn>
</Columns>
</asp:DataGrid><BR></FONT>
<asp:Button id=btnIabRecovery runat="server" Text="�o���^�_"></asp:Button></asp:Panel>
	<kw:footer id=Footer runat="server">
	</kw:footer>	
  </body>
</HTML>
