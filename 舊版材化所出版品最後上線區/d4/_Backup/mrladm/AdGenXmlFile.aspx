<%@ Page language="c#" Codebehind="AdGenXmlFile.aspx.cs" Src="AdGenXmlFile.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.mrladm.AdGenXmlFile" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../../UserControl/header.ascx" %>
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
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>		
    <form id="AdGenXmlFile" method="post" runat="server">
<FONT 
face=�s�ө���></FONT>
<P>
<asp:calendar id=calSelectAdDate runat="server" CellPadding="0" NextPrevFormat="FullMonth" BorderColor="White" Font-Names="Verdana" BorderWidth="1px" Font-Size="9pt" BackColor="LemonChiffon" ForeColor="Black">
<TodayDayStyle BackColor="PaleGoldenrod">
</TodayDayStyle>

<DayStyle Font-Size="XX-Small">
</DayStyle>

<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom">
</NextPrevStyle>

<DayHeaderStyle Font-Size="6pt">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="X-Small" Font-Bold="True" BorderWidth="4px" ForeColor="#333399" BorderColor="Black" BackColor="Gold">
</TitleStyle>

<WeekendDayStyle Font-Size="XX-Small">
</WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle>
</asp:calendar><FONT face=�s�ө���><FONT color=red 
size=2>�`�N�I���ͼ��X�ɤ��e�@�w�n���T�w�Ӥ�n���X���s�i�Ҥw���������u�@�I<BR>�_�h�N�|�ɭP�s�i���X���`�I</FONT></FONT><FONT face=�s�ө���><BR></FONT>
<asp:Button id=btnGenXml runat="server" Text="����()�s�i���X��"></asp:Button><FONT 
face=�s�ө��� color=#ff0000 size=2><BR></FONT><FONT face=�s�ө��� color=red 
size=2>���ͼ��X�ɫ�ЦC�L���s���X�M��A�H�ֹ�s�i���X���</FONT></P>
<P>
<asp:TextBox id=tbxXml runat="server" Width="100%" TextMode="MultiLine" Rows="15"></asp:TextBox></P>

     
     </form></FORM>
	<!-- ���� Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>	
  </body>
</HTML>
