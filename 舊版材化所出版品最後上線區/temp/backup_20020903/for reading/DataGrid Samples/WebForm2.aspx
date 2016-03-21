<%@ Page language="c#" Codebehind="WebForm2.aspx.cs" AutoEventWireup="false" Inherits="TestProj.WebForm2" src="WebForm2.aspx.cs"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body bgColor=#66cc33><FONT face=新細明體>
<FORM id=Form1 method=post runat="server">
<TABLE cellSpacing=1 cellPadding=1 border=0>
  <TR>
    <TD vAlign=top>
<asp:DataGrid id=DataGrid1 runat="server" AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="X-Small" BorderColor="OliveDrab">
<HeaderStyle ForeColor="White" BackColor="ForestGreen">
</HeaderStyle>

<ItemStyle BackColor="LimeGreen">
</ItemStyle>

<Columns>
<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
<HeaderStyle Width="80px">
</HeaderStyle>

<ItemStyle Font-Size="XX-Small" HorizontalAlign="Center">
</ItemStyle>
</asp:EditCommandColumn>
<asp:BoundColumn DataField="title_id" ReadOnly="True" HeaderText="編號">
<HeaderStyle Width="80px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="title" HeaderText="書名">
<HeaderStyle Width="300px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="price" HeaderText="價格">
<HeaderStyle Width="40px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:ButtonColumn Text="Delete" CommandName="Delete">
<HeaderStyle Width="60px">
</HeaderStyle>

<ItemStyle Font-Size="XX-Small" HorizontalAlign="Center">
</ItemStyle>
</asp:ButtonColumn>
</Columns></asp:DataGrid></TD>
    <TD vAlign=top><FONT face=新細明體>
      <TABLE cellSpacing=1 cellPadding=1 border=0>
        <TR>
          <TD align=middle colSpan=2>新增資料</TD></TR>
        <TR>
          <TD>編號</TD>
          <TD>
<asp:TextBox id=tbxAddTitleID runat="server" Width="150px"></asp:TextBox></TD></TR>
        <TR>
          <TD>書名</TD>
          <TD>
<asp:TextBox id=tbxAddTitle runat="server" Width="150px"></asp:TextBox></TD></TR>
        <TR>
          <TD>價格</TD>
          <TD>
<asp:TextBox id=tbxAddPrice runat="server" Width="150px"></asp:TextBox></TD></TR>
        <TR>
          <TD align=middle colSpan=2><FONT face=新細明體>
<asp:Button id=btnAdd runat="server" Text="新增"></asp:Button>
<asp:Button id=btnClear runat="server" Text="清除"></asp:Button></FONT></TD></TR>
        <TR>
          <TD 
colSpan=2></TD></TR></TABLE></FONT></TD></TR></TABLE></FORM></FONT>
	
  </body>
</HTML>
