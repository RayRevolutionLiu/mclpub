<%@ Page language="c#" Codebehind="WebForm2.aspx.cs" AutoEventWireup="false" Inherits="TestProj.WebForm2" src="WebForm2.aspx.cs"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body bgColor=#66cc33><FONT face=�s�ө���>
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
<asp:BoundColumn DataField="title_id" ReadOnly="True" HeaderText="�s��">
<HeaderStyle Width="80px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="title" HeaderText="�ѦW">
<HeaderStyle Width="300px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="price" HeaderText="����">
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
    <TD vAlign=top><FONT face=�s�ө���>
      <TABLE cellSpacing=1 cellPadding=1 border=0>
        <TR>
          <TD align=middle colSpan=2>�s�W���</TD></TR>
        <TR>
          <TD>�s��</TD>
          <TD>
<asp:TextBox id=tbxAddTitleID runat="server" Width="150px"></asp:TextBox></TD></TR>
        <TR>
          <TD>�ѦW</TD>
          <TD>
<asp:TextBox id=tbxAddTitle runat="server" Width="150px"></asp:TextBox></TD></TR>
        <TR>
          <TD>����</TD>
          <TD>
<asp:TextBox id=tbxAddPrice runat="server" Width="150px"></asp:TextBox></TD></TR>
        <TR>
          <TD align=middle colSpan=2><FONT face=�s�ө���>
<asp:Button id=btnAdd runat="server" Text="�s�W"></asp:Button>
<asp:Button id=btnClear runat="server" Text="�M��"></asp:Button></FONT></TD></TR>
        <TR>
          <TD 
colSpan=2></TD></TR></TABLE></FONT></TD></TR></TABLE></FORM></FONT>
	
  </body>
</HTML>
