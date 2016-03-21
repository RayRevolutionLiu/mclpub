<%@ Page language="c#" Codebehind="cal.cs" Src="cal.cs" AutoEventWireup="false" Inherits="ActMsg.cal"  responseencoding="big5"%>
<html><head>
<script language=javascript>
<!--
function back_date(qsField){
	ret=window.opener.document.all(qsField).value="" + window.document.all("lbText").value;
	return true;
}
//-->
</script>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#"></head>
  <body>
	
    <form method="post" runat="server" ID=Form1>
<p align=center>
<asp:Calendar id=cal11 runat="server" Font-Size="XX-Small" CellPadding="0" dayheaderstyle-backcolor="LightSkyBlue" othermonthdaystyle-forecolor="Silver" titlestyle-forecolor="White" titlestyle-backcolor="SteelBlue" selecteddaystyle-font-bold="True" selecteddaystyle-backcolor="PaleGreen" dayheaderstyle-wrap="False" weekenddaystyle-forecolor="Red" othermonthdaystyle-backcolor="Transparent" nextprevformat="FullMonth" selecteddaystyle-forecolor="Black"></asp:Calendar>
<asp:Label id=lbText runat="server"></asp:Label>&nbsp;&nbsp; 
<a href="#" id=linkconfirm name=linkconfirm onclick='javascript:back_date("<% Response.Write(Context.Request.QueryString["field_name"]); %>");window.close();return false;'>½T©w
</p>

     </form></A>
	
  </body></html>
