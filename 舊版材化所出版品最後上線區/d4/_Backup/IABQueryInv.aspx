<%@ Page language="c#" Codebehind="IABQueryInv.aspx.cs" Src="IABQueryInv.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.IABQueryInv" %>
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
<form id=IABQueryInv method=post runat="server"><asp:panel 
id=pnlQuery runat="server" Width="100%">
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR>
    <TD style="WIDTH: 103px"><FONT face=�s�ө���>�s�i�����G</FONT></TD>
    <TD>
<asp:DropDownList id=ddlAdCate runat="server">
<asp:ListItem Value="M" Selected="True">����</asp:ListItem>
<asp:ListItem Value="I">����</asp:ListItem>
<asp:ListItem Value="N">�`��</asp:ListItem>
</asp:DropDownList></TD></TR>
  <TR>
    <TD style="WIDTH: 103px"><FONT face=�s�ө���>�Z�n����G</FONT></TD>
    <TD>
<asp:TextBox id=tbxAdMonth runat="server" Width="85px" MaxLength="8"></asp:TextBox><FONT 
      face=�s�ө���>&nbsp; 
<asp:RequiredFieldValidator id=RequiredFieldValidator1 runat="server" ControlToValidate="tbxAdMonth" Display="Dynamic" ErrorMessage="�п�J�~��" Font-Size="X-Small"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=RegularExpressionValidator1 runat="server" ControlToValidate="tbxAdMonth" Display="Dynamic" ErrorMessage="�榡���~�A����yyyy/MM" Font-Size="X-Small" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator></FONT></TD></TR>
  <TR>
    <TD style="WIDTH: 103px"><FONT face=�s�ө���>�ƧǱ���G</FONT></TD>
    <TD>
<asp:DropDownList id=ddlSort runat="server">
<asp:ListItem Value="0" Selected="True">�X���s��+�s�i�Ǹ�</asp:ListItem>
<asp:ListItem Value="1">�~�ȭ�</asp:ListItem>
</asp:DropDownList><FONT face=�s�ө���>&nbsp; 
<asp:Button id=BtnQuery1 runat="server" Text="�d��"></asp:Button></FONT></TD></TR></TABLE></asp:panel><asp:panel 
id=pnlStep1 runat="server" Width="100%">
<HR width="100%" color=orangered SIZE=1>
<asp:Label id=lblInfo1 runat="server" ForeColor="OrangeRed"></asp:Label><FONT 
face=�s�ө���><BR>
<asp:Button id=btnStep1SelAll runat="server" Text="����"></asp:Button>
<asp:Button id=btnStep1SelNone runat="server" Text="�M��"></asp:Button></FONT><BR>
<asp:DataGrid id=dgdStep1 runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#E7EBFF">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:TemplateColumn>
<ItemTemplate>
<asp:CheckBox id=cbxSelContAdr runat="server"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
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
</asp:DataGrid><FONT face=�s�ө���>
<asp:Button id=btnStep1Go runat="server" Text="�ˮָ��"></asp:Button></FONT></asp:panel><asp:panel 
id=pnlStep2 runat="server" Width="100%"><FONT face=�s�ө���>
<HR width="100%" color=orangered SIZE=1>
<asp:Label id=lblInfo2 runat="server" ForeColor="OrangeRed"></asp:Label><BR></FONT><FONT 
face=�s�ө���>
<asp:DataGrid id=dgdStep2 runat="server" Font-Size="X-Small" AutoGenerateColumns="False" BackColor="#E7EBFF">
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
</asp:DataGrid><BR></FONT><FONT face=�s�ө���>
<asp:Label id=lblTotAmt runat="server" ForeColor="OrangeRed"></asp:Label><BR>
<asp:Button id=btnGoInv runat="server" Text="���͵o�����"></asp:Button>
<asp:Button id=btnGoStep1 runat="server" Text="�^��W�@�B"></asp:Button></FONT></asp:panel></form>
		<!-- ���� Footer --><kw:footer id=Footer runat="server">
		</kw:footer>
	
  </body>
</HTML>
