<%@ Register TagPrefix="kw" TagName="footer" Src="../../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="AdImgAdm.aspx.cs" Src="AdImgAdm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.mrladm.AdImgAdm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
    <!-- CSS --><LINK href="../../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
  <body>
<!-- ���� Header -->
<kw:header id="Header" runat="server">
</kw:header>	
    <form id="AdImgAdm" method="post" runat="server"><FONT face=�s�ө��� 
color=maroon>�R���ɮ׫e�Яd�N���ɮ׬O�_���{���αN�Ӥw�����n���X���s�i����</FONT>
<TABLE cellSpacing=0 cellPadding=0 width=700 border=0>
  <TR>
    <TD width=200>
<asp:DataGrid id=dgdXmlFile runat="server" BackColor="#E7EBFF" Font-Size="X-Small" CellPadding="2" Font-Names="Verdana" AutoGenerateColumns="False" AllowPaging="True">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<PagerStyle Font-Size="X-Small" HorizontalAlign="Right" PageButtonCount="5" Mode="NumericPages">
</PagerStyle>

<Columns>
<asp:TemplateColumn>
<ItemTemplate>
<FONT face=�s�ө���>
<asp:CheckBox id=cbxSelXmlFile runat="server"></asp:CheckBox></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="�ɦW">
<ItemTemplate>
<FONT face=�s�ө���>
<asp:Label id=lblFileName runat="server" Text='<%# GetFileName(DataBinder.Eval(Container.DataItem,"fullpath")) %>'></asp:Label></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:ButtonColumn Text="�˵��Ϥ�" CommandName="Select"></asp:ButtonColumn>
</Columns>
</asp:DataGrid></TD>
    <TD>
<asp:Image id=imgImageFile runat="server"></asp:Image><FONT 
      face=�s�ө���><BR>
<asp:Label id=lblFileName runat="server" Font-Size="XX-Small" Font-Names="Verdana"></asp:Label></FONT></TD></TR>
  <TR>
    <TD>
<asp:Button id=btnDelete runat="server" Text="�R��"></asp:Button></TD>
    <TD></TD></TR></TABLE><FONT face=�s�ө���><BR></FONT>

     </form>
<!-- ���� Footer -->
<kw:footer id="Footer" runat="server">
</kw:footer>	
  </body>
</HTML>
