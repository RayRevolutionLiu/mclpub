<%@ Register TagPrefix="kw" TagName="header" Src="../../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="AdShowXmlFiles.aspx.cs" Src="AdShowXmlFiles.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.mrladm.AdShowXmlFiles" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    	<!-- CSS -->
		<LINK href="../../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
  </HEAD>
  <body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>		
    <form id="AdShowXmlFiles" method="post" runat="server"><FONT 
face=新細明體>
<asp:DataGrid id=dgdXmlFile runat="server" BackColor="#E7EBFF" Font-Size="X-Small" CellPadding="2" Font-Names="Verdana" AutoGenerateColumns="False">
<HeaderStyle BackColor="#BFCFF0">
</HeaderStyle>

<Columns>
<asp:TemplateColumn>
<ItemTemplate>
<FONT face=新細明體>
<asp:CheckBox id=cbxSelXmlFile runat="server"></asp:CheckBox></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="現有XML廣告播出檔">
<ItemTemplate>
<FONT face=新細明體>
<asp:Label id=lblFileName runat="server" Text='<%# GetFileName(DataBinder.Eval(Container.DataItem,"fullpath")) %>'></asp:Label></FONT>
</ItemTemplate>
</asp:TemplateColumn>
<asp:ButtonColumn Text="瀏覽內容" CommandName="Select"></asp:ButtonColumn>
</Columns>
</asp:DataGrid><BR>
<asp:Button id=btnDelete runat="server" Text="刪除"></asp:Button><BR>
<asp:TextBox id=tbxXml runat="server" Width="100%" TextMode="MultiLine" Rows="15"></asp:TextBox></FONT>

     </form>
	<!-- 頁尾 Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>
 </body>
</HTML>
