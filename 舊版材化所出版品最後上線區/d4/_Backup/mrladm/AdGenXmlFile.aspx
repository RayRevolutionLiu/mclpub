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
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server">
		</kw:header>		
    <form id="AdGenXmlFile" method="post" runat="server">
<FONT 
face=新細明體></FONT>
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
</asp:calendar><FONT face=新細明體><FONT color=red 
size=2>注意！產生播出檔之前一定要先確定該日要播出的廣告皆已完成落版工作！<BR>否則將會導致廣告播出異常！</FONT></FONT><FONT face=新細明體><BR></FONT>
<asp:Button id=btnGenXml runat="server" Text="產生()廣告播出檔"></asp:Button><FONT 
face=新細明體 color=#ff0000 size=2><BR></FONT><FONT face=新細明體 color=red 
size=2>產生播出檔後請列印網廣播出清單，以核對廣告播出資料</FONT></P>
<P>
<asp:TextBox id=tbxXml runat="server" Width="100%" TextMode="MultiLine" Rows="15"></asp:TextBox></P>

     
     </form></FORM>
	<!-- 頁尾 Footer -->
	<kw:footer id="Footer" runat="server">
	</kw:footer>	
  </body>
</HTML>
