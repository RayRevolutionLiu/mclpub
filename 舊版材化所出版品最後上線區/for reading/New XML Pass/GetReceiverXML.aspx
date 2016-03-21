<%@ Page language="c#" Codebehind="GetReceiverXML.aspx.cs" Src="GetReceiverXML.aspx.cs" AutoEventWireup="false" Inherits="WorkWithXmlDoc.GetReceiverXML" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body >
	
    <form id="GetReceiverXML" method="post" runat="server">
<P>
<asp:DataGrid id=DataGrid1 runat="server"></asp:DataGrid>
<INPUT type="hidden" id="hidData" runat="server"> </P>
<P><FONT face=新細明體>
<INPUT type=button value=確定 onclick="ReturnData()"></FONT></P>

     </form>
	
  </body>
</HTML>

<script language="javascript">
function ReturnData()
{
	window.returnValue = document.GetReceiverXML("hidData").value;
	window.close();
}
</script>