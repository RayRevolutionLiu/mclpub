<%@ Page language="c#" Codebehind="ContMisc.aspx.cs" Src="ContMisc.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.ContMisc" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=ContMisc method=post runat="server"><FONT 
face=新細明體>
<TABLE cellSpacing=0 cellPadding=1 width="100%" bgColor=#bfcff0 border=0>
  <TR>
    <TD width="15%">
      <P align=right><FONT size=2 
      >廣告推廣內文：</FONT></P></TD>
    <TD width="40%"><asp:textbox id=tbxCCont runat="server" Font-Size="XX-Small" Width="250px"></asp:textbox></TD>
    <TD width="15%">
      <P align=right><FONT size=2 
      ><FONT size=2 
      >搜尋期限：</FONT></FONT></P></TD>
    <TD width="30%"><asp:textbox id=tbxCsDate runat="server" Font-Size="XX-Small" Width="80px"></asp:textbox>
<asp:RequiredFieldValidator id=rfvCsDate runat="server" Font-Size="X-Small" ErrorMessage="請輸入日期" Display="Dynamic" ControlToValidate="tbxCsDate"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revCsDate runat="server" Font-Size="X-Small" ErrorMessage="格式錯誤，請輸入正確格式" Display="Dynamic" ControlToValidate="tbxCsDate" ValidationExpression="[1-2]\d{3}\/[0-2]\d\/[0-3]\d"></asp:RegularExpressionValidator><FONT 
      color=red size=2>(如：2002/12/31)</FONT></TD></TR>
  <TR>
    <TD>
      <P align=right><FONT size=2 
      >產品設備內文：<BR><BR 
      ><BR></FONT></P></TD>
    <TD colSpan=3>
      <P align=left><FONT size=2><asp:textbox id=tbxPdCont runat="server" Width="500px" TextMode="MultiLine" Rows="3"></asp:textbox></FONT></P></TD></TR>
  <TR bgColor=white height=2>
    <TD></TD>
    <TD colSpan=3></TD></TR>
  <TR>
    <TD vAlign=top>
      <P align=right><FONT size=2 
      >應用產業：</FONT></P></TD>
    <TD colSpan=3>
      <P align=left><FONT size=2><asp:dropdownlist id=ddlCategory1 runat="server" AutoPostBack="True"></asp:dropdownlist><BR 
      ><asp:checkboxlist id=cblClass1 runat="server" Font-Size="X-Small" Width="100%" RepeatColumns="3" RepeatDirection="Horizontal"></asp:checkboxlist><BR 
      ><asp:button id=btnAdd1 runat="server" Text="加入"></asp:button>
<asp:RequiredFieldValidator id=rfvCsDate2 runat="server" Font-Size="X-Small" ControlToValidate="tbxCsDate" Display="Dynamic" ErrorMessage="請先輸入搜尋期限"></asp:RequiredFieldValidator></FONT></P></TD></TR>
  <TR bgColor=white height=2>
    <TD vAlign=top></TD>
    <TD colSpan=3></TD></TR>
  <TR>
    <TD vAlign=top>
      <P align=right><FONT size=2 
      >材料特性：</FONT></P></TD>
    <TD colSpan=3>
      <P align=left><asp:dropdownlist id=ddlCategory2 runat="server" AutoPostBack="True"></asp:dropdownlist><BR 
      >
<asp:CheckBoxList id=cblClass2 runat="server" Font-Size="X-Small" Width="100%" RepeatColumns="3" RepeatDirection="Horizontal"></asp:CheckBoxList><BR>
<asp:Button id=btnAdd2 runat="server" Text="加入"></asp:Button>
<asp:RequiredFieldValidator id=rfvCsDate3 runat="server" Font-Size="X-Small" ControlToValidate="tbxCsDate" Display="Dynamic" ErrorMessage="請先輸入搜尋期限"></asp:RequiredFieldValidator></P></TD></TR>
  <TR></TR></TABLE></FONT>
<asp:Button id=btnSave runat="server" Text="儲存"></asp:Button><FONT 
face=新細明體>&nbsp;&nbsp; </FONT>
<asp:Button id=btnClose runat="server" Text="關閉" CausesValidation="False"></asp:Button><INPUT 
id=hidSelected type=hidden name=hidSelected runat="server"></form>
<script language=javascript>
function doClose(myaction)
{

	if (myaction == "Mod")
	{
		window.opener.ContModify.submit();
	}
	else
	{
		window.opener.NewCont.submit();
	}
	window.close();
}
</script>
	
  </body>
</HTML>
