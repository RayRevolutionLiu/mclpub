<%@ Page language="c#" Codebehind="IABCheckList.aspx.cs" Src="IABCheckList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IABCheckList" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<!-- CSS --><LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
<body>
		<!-- ���� Header --><kw:header id=Header runat="server">
		</kw:header>
<table dataFld=items id=tbItems style="WIDTH: 739px">
  <tr>
    <td style="WIDTH: 100%" align=left><font 
      color=#333333 size=2><IMG height=10 src="../images/header/right02.gif" width=10 border=0 > &nbsp;�����s�i���t�� <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > �o���B�z <IMG height=10 src="../images/header/right02.gif" width=10 border=0 > �w�� �o���}���ˮ֪� 
      -&nbsp;���j��뵲</font> </td></tr></table>		
		<!-- �ثe�Ҧb��m -->
<form id=IABCheckList method=post runat="server"><FONT 
face=�s�ө���>
<asp:Panel id=pnlQuery runat="server" Width="100%">
<asp:label id=lblAdCate runat="server">�Z�n�����G</asp:label>
<asp:dropdownlist id=ddlAdCate runat="server">
<asp:ListItem Value="M" Selected="True">����</asp:ListItem>
<asp:ListItem Value="I">����</asp:ListItem>
<asp:ListItem Value="N">�`��</asp:ListItem>
</asp:dropdownlist><BR>
<asp:label id=lblYYYYMM runat="server">�Z�n�~��G</asp:label>
<asp:textbox id=tbxAdMonth runat="server" Width="60px" MaxLength="7"></asp:textbox>
<asp:RequiredFieldValidator id=rfvAdMonth runat="server" Font-Size="X-Small" ErrorMessage="�п�J�~��" Display="Dynamic" ControlToValidate="tbxAdMonth"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revAdMonth runat="server" Font-Size="X-Small" ErrorMessage="�榡���~�A����yyyy/MM" Display="Dynamic" ControlToValidate="tbxAdMonth" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator><BR>
<asp:label id=lblOrderByFilter runat="server">�ƧǱ���G</asp:label>
<asp:dropdownlist id=ddlOrderByFilter runat="server">
					<asp:ListItem Value="1" Selected="True">�X���s��+�����Ǹ�</asp:ListItem>
					<asp:ListItem Value="2">�~�ȭ�</asp:ListItem>
				</asp:dropdownlist><BR>
<asp:Label id=lblIabSeq runat="server">���o���}�߳�帹�G</asp:Label>
<asp:TextBox id=tbxIabseq runat="server" Width="60px" MaxLength="6">000001</asp:TextBox>&nbsp; 
<FONT color=darkred size=2>(�п�J���T�ȡA�p 000001)</FONT>&nbsp;&nbsp; 
<asp:button id=btnQuery runat="server" Text="�d��"></asp:button>&nbsp; 
<asp:button id=btnClear runat="server" Text="�M�����d"></asp:button>
</asp:Panel>
<asp:Panel id=pnlIaList runat="server" Width="100%">
<asp:datagrid id=dgdIaList runat="server" Font-Size="8pt" BackColor="White" AutoGenerateColumns="False" CellPadding="1" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>

<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<AlternatingItemStyle BackColor="Lavender">
</AlternatingItemStyle>

<ItemStyle ForeColor="Navy" BackColor="White">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="ia_iano" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_rjbti" HeaderText="�ٿ�"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_raddr" HeaderText="�o���l�H�a�}">
<HeaderStyle Wrap="False">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ia_rzip" HeaderText="�l���ϸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_rtel" HeaderText="�q��"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
<asp:BoundColumn DataField="ia_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_iaditem" HeaderText="�o���}�߳���ӧǸ�"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_fk2" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_fk3" HeaderText="�Z�n�~��"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_fk4" HeaderText="�����Ǹ�"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_desc" HeaderText="�~�W"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_projno" HeaderText="�p���N��"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_costctr" HeaderText="��������"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_qty" HeaderText="�ƶq"></asp:BoundColumn>
<asp:BoundColumn DataField="iad_amt" HeaderText="���B"></asp:BoundColumn>
</Columns>
</asp:datagrid>
<asp:button id=btnPrintList runat="server" Text="�C�L�ˮ֪�"></asp:button></asp:Panel>
</FONT></form>
<kw:footer id=Footer runat="server"></kw:footer>	
  </body>
</HTML>
