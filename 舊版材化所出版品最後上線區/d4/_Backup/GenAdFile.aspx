<%@ Page language="c#" Codebehind="GenAdFile.aspx.cs" Src="GenAdFile.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.GenAdFile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body >
	
    <form id="GenAdFile" method="post" runat="server"><FONT 
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
</asp:calendar><FONT face=新細明體><BR></FONT>
<asp:Button id=btnGenXml runat="server" Text="產生()圖形落版"></asp:Button></P>
<P>
<asp:TextBox id=tbxXml runat="server" Width="100%" TextMode="MultiLine" Rows="15"></asp:TextBox></P>

     </form>
	
  </body>
</HTML>
