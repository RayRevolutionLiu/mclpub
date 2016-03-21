<%@ Page language="c#" Codebehind="QueryHisCont.aspx.cs" Src="QueryHisCont.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.QueryHisCont" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">    
  </HEAD>
  <body >
	
    <form id="QueryHisCont" method="post" runat="server">
    <!-- 頁首 Header -->
			<kw:header id="Header" runat="server">
			</kw:header>    
<P>
<asp:DataGrid id=DataGrid1 runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="0" Font-Size="X-Small" AutoGenerateColumns="False">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle Font-Bold="True" Wrap="False" ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle Wrap="False" ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:ButtonColumn Text="載入" ButtonType="PushButton" CommandName="Select">
<ItemStyle Font-Size="XX-Small">
</ItemStyle>
</asp:ButtonColumn>
<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
</Columns></asp:DataGrid><FONT face=新細明體><BR></FONT>
<asp:Button id=btnAddNew runat="server" Text="直接新增合約"></asp:Button></P>
			<!-- Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:Footer>
     </form>
	
  </body>
</HTML>
