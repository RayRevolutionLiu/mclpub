<%@ Register TagPrefix="kw" TagName="footer" Src="../../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="AdViewAd.aspx.cs" Src="AdViewAd.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.mrladm.AdViewAd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
    	<!-- CSS --><LINK href="../../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
<body vLink=blue>
		<!-- ���� Header --><kw:header id=Header runat="server">
		</kw:header>
<form id=AdViewAd method=post runat="server">
<TABLE cellSpacing=3 cellPadding=0 border=0>
  <TR vAlign=bottom>
    <TD><asp:calendar id=calSelectAdDate runat="server" Height="129px" Width="297px" BorderColor="White" BorderWidth="1px" CellPadding="0" NextPrevFormat="FullMonth" Font-Names="Verdana" ForeColor="Black" BackColor="LemonChiffon" Font-Size="9pt">
<TodayDayStyle BackColor="PaleGoldenrod">
</TodayDayStyle>

<DayStyle Font-Size="XX-Small">
</DayStyle>

<NextPrevStyle Font-Size="6pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom">
</NextPrevStyle>

<DayHeaderStyle Font-Size="5pt">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="8pt" Font-Bold="True" BorderWidth="3px" ForeColor="#333399" BorderColor="Black" BackColor="Gold">
</TitleStyle>

<WeekendDayStyle Font-Size="XX-Small">
</WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle>
</asp:calendar></TD>
    <TD><asp:image id=imgAdFiles runat="server"></asp:image></TD></TR>
  <TR>
    <TD></TD>
    <TD></TD></TR></TABLE><FONT face=�s�ө��� 
color=firebrick size=2>�аO���⬰�w���P�X���A�Ŧ⬰�w���צX��<BR></FONT><asp:datagrid id=dgdContAdr runat="server" CellPadding="2" BackColor="#ECEBFF" Font-Size="X-Small" AllowSorting="True" AutoGenerateColumns="False">
<HeaderStyle HorizontalAlign="Center" ForeColor="SteelBlue" BackColor="#BFCFF0">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" SortExpression="cont_contno" HeaderText="�X���s��">
<HeaderStyle Width="70px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" SortExpression="cont_conttp" HeaderText="�X�����O">
<HeaderStyle Width="35px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="adr_seq" HeaderText="�s�i�Ǹ�">
<HeaderStyle Width="35px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="adr_adcate" SortExpression="adr_adcate" HeaderText="����"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_keyword" HeaderText="��m"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy"></asp:BoundColumn>
<asp:ButtonColumn DataTextField="adr_imgurl" HeaderText="�s�i����" CommandName="Select"></asp:ButtonColumn>
<asp:BoundColumn DataField="adr_navurl" HeaderText="��r�Z"></asp:BoundColumn>
<asp:BoundColumn DataField="adr_impr" HeaderText="���v">
<HeaderStyle Width="15px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="adr_fggot" HeaderText="��`">
<HeaderStyle Width="35px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="adr_remark" HeaderText="�Ƶ�"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgcancel" HeaderText="fgcancel"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_fgclosed" HeaderText="fgclosed"></asp:BoundColumn>
</Columns>
</asp:datagrid></form>
	<!-- ���� Footer --><kw:footer id=Footer runat="server">
	</kw:footer>	
  </body>
</HTML>
