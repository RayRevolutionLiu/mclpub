<%@ Page language="c#" Codebehind="ViewAds.aspx.cs" Src="ViewAds.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.ViewAds" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body >
	
    <form id="ViewAds" method="post" runat="server">
<P><FONT face=�s�ө���>
<asp:Calendar id=Calendar1 runat="server" Font-Size="8pt" Font-Names="Verdana" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" ForeColor="#003399" Width="300px">
<TodayDayStyle ForeColor="White" BackColor="#99CCCC">
</TodayDayStyle>

<SelectorStyle ForeColor="#336666" BackColor="#99CCCC">
</SelectorStyle>

<NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF">
</NextPrevStyle>

<DayHeaderStyle Height="1px" ForeColor="#336666" BackColor="#99CCCC">
</DayHeaderStyle>

<SelectedDayStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedDayStyle>

<TitleStyle Font-Size="10pt" Font-Bold="True" Height="25px" BorderWidth="1px" ForeColor="#CCCCFF" BorderStyle="Solid" BorderColor="#3366CC" BackColor="#003399">
</TitleStyle>

<WeekendDayStyle BackColor="#CCCCFF">
</WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle>
</asp:Calendar>&nbsp;&nbsp;&nbsp; <A 
href="http://03212-900103/Beta2/MRLPub.d4/Contents.aspx">�^����<BR></A></FONT>
<asp:DataGrid id=DataGrid1 runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" Font-Names="Verdana" Font-Size="XX-Small" AllowSorting="True">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:ButtonColumn Text="�R��" CommandName="Delete">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:ButtonColumn>
<asp:BoundColumn DataField="adr_contno" SortExpression="adr_contno" HeaderText="�X���s��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="�s�i�s��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_date" SortExpression="adr_date" HeaderText="���X���"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_imgurl" HeaderText="�s�i����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_txtadcont" HeaderText="��r�s�i�r��"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" SortExpression="adr_keyword" HeaderText="���X��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="���X���v"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_fgfixad" HeaderText="����覡"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="adr_adrid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
</Columns></asp:DataGrid><FONT face=�s�ө���></FONT></P>

     </form>
	
  </body>
</HTML>
